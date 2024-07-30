#pragma once

#include "SafeWin.h"

#include <stdio.h>
#include <string.h>
#include <cstdint>
#include <functional>

namespace Native
{
	class ring_buffer_t
	{
		HANDLE mapping;
		size_t size_;
		uint8_t* data_;
		uint32_t head_;
		uint32_t tail_;
	public:
		ring_buffer_t(const uint64_t order)
			: mapping(INVALID_HANDLE_VALUE), size_(1ULL << order), data_(nullptr), head_(0), tail_(0)
		{
			if (_alloc(size_, 10) == nullptr)
			{
				abort();
			}
		}
		~ring_buffer_t()
		{
			_free();
		}
		uint8_t* begin_write(const size_t size)
		{
			/* prevent buffer from getting completely full or over commited */
			if (unusedspace() <= size)
			{
				return nullptr;
			}
			else
			{
				return static_cast<uint8_t*>(data_) + tail_;
			}
		}
		uint8_t* shift_write(const size_t size)
		{
			tail_ += (uint32_t)size;
			if (size_ < tail_)
			{
				tail_ %= size_;
			}
			return static_cast<uint8_t*>(data_) + tail_;
		}
		/** Look at data at the circular buffer's head.
		* Use usedspace to determine how much data in bytes can be read.
		* @return pointer to the head of the circular buffer */
		uint8_t* begin_read()
		{
			if (is_empty())
			{
				return nullptr;
			}
			else
			{
				return static_cast<uint8_t*>(data_) + head_;
			}
		}
		const uint8_t* begin_read() const
		{
			if (is_empty())
			{
				return nullptr;
			}
			else
			{
				return static_cast<uint8_t const*>(data_) + head_;
			}
		}
		/** Release data at the head from the circular buffer.
		* Increase the position of the head.
		*
		* WARNING: this is a dangerous call if:
		*  1. You are using the returned data pointer.
		*  2. Another thread has offerred data to the circular buffer.
		*
		* If you want to access the data from the returned  pointer you are better off
		* using peek.
		*
		* @param size Number of bytes to release
		* @return pointer to data; NULL if we can't poll this much data */
		uint8_t* shift_read(const size_t size)
		{
			if (is_empty())
			{
				return nullptr;
			}
			else
			{
				uint8_t* end = static_cast<uint8_t*>(data_) + head_;
				head_ += (uint32_t)size;
				if (size_ < head_)
				{
					head_ %= size_;
				}
				return static_cast<uint8_t*>(end);
			}
		}
		uint8_t* shift_to_read(const uint8_t* to)
		{
			if (is_empty())
			{
				return nullptr;
			}
			else
			{
				head_ = (uint32_t)(to - data_);
				if (size_ < head_)
				{
					head_ %= size_;
				}
				return static_cast<uint8_t*>(data_) + head_;
			}
		}
		/** Size in bytes of the circular buffer.
		* Is equal to 2 ^ order.
		*
		* @return size of the circular buffer in bytes */
		size_t size() const
		{
			return size_;
		}
		/** Tell how much data has been written in bytes to the circular buffer.
		* @return number of bytes of how data has been written */
		size_t usedspace() const
		{
			if (head_ <= tail_)
			{
				return tail_ - head_;
			}
			else
			{
				return size_ - (head_ - tail_);
			}
		}
		/** Tell how much data we can write in bytes to the circular buffer.
		* @return number of bytes of how much data can be written */
		size_t unusedspace() const
		{
			return size_ - usedspace();
		}
		/** Tell if the circular buffer is empty.
		* @return 1 if empty; otherwise 0 */
		bool is_empty() const
		{
			return head_ == tail_;
		}
		void reset()
		{
			head_ = 0;
			tail_ = 0;
		}
	private:
		// Determine a viable target address of "size" memory mapped bytes by
		// allocating memory using VirtualAlloc and immediately freeing it. This
		// is subject to a potential race condition, see notes above.
		static void* determine_viable_addr(size_t size)
		{
			void* ptr = ::VirtualAlloc(0, size, MEM_RESERVE, PAGE_NOACCESS);
			if (!ptr)
				return 0;
			::VirtualFree(ptr, 0, MEM_RELEASE);
			return ptr;
		}
		// Frees the allocated region again.
		void _free()
		{
			if (data_ != nullptr)
			{
				::UnmapViewOfFile(data_);
				::UnmapViewOfFile(data_ + size_);
				data_ = nullptr;
			}
			if (mapping != 0)
			{
				::CloseHandle(mapping);
				mapping = 0;
			}
			size_ = 0;
		}
		// Allocate a magic ring buffer at a given target address.
		//   ring_size      size of one copy of the ring; must be a multiple of 64k.
		//   desired_addr   location where you'd like it.
		void* _alloc_at(size_t ring_size, void* desired_addr = nullptr)
		{
			// if we already hold one allocation, refuse to make another.
			if (data_)
				return nullptr;
			// is ring_size a multiple of 64k? if not, this won't ever work!
			if ((ring_size & 0xffff) != 0)
				return nullptr;
			// try to allocate and map our space
			const size_t alloc_size = ring_size * 2;
			if (!(mapping = ::CreateFileMappingA(INVALID_HANDLE_VALUE, 0, PAGE_READWRITE, (uint64_t)alloc_size >> 32, alloc_size & 0xffffffffu, 0)) ||
				!(data_ = (uint8_t*)::MapViewOfFileEx(mapping, FILE_MAP_ALL_ACCESS, 0, 0, ring_size, desired_addr)) ||
				!::MapViewOfFileEx(mapping, FILE_MAP_ALL_ACCESS, 0, 0, ring_size, (uint8_t*)desired_addr + ring_size))
			{
				// something went wrong - clean up
				_free();
			}
			else // success!
				size_ = ring_size;
			return data_;
		}

		// This function will allocate a magic ring buffer at a system-determined base address.
		//
		// Sadly, there's no way (that I can see) in the Win32 API to first reserve
		// a memory region then fill it in using mmaps; you can reserve memory via
		// VirtualAlloc, but that address range can then only be used to commit
		// memory via another VirtualAlloc, and can not be mmap'ed. Furthermore,
		// there's also no way to do the two back-to-back mmaps atomically. What we
		// do here is to reserve enough memory via VirtualAlloc, then immediately
		// free it and try to put our allocation there. This is subject to a race
		// condition - another thread might end up allocating that very memory
		// region in the interim. What this means is that even when an alloc should
		// work (i.e. there's enough memory available) it can still fail spuriously
		// sometimes. Hence the "dicey" comment above.
		//
		// What we do here is just retry the alloc a given number of times and hope
		// that we don't get screwed every single time. This increases the
		// likelihood of success, but doesn't eliminate the chance of spurious
		// failure, so be religious about checking return values!
		void* _alloc(size_t ring_size, int num_retries = 5)
		{
			void* ptr = 0;
			while (!ptr && num_retries-- != 0)
			{
				void* target_addr = determine_viable_addr(ring_size * 2);
				if (target_addr)
					ptr = _alloc_at(ring_size, target_addr);
			}
			return ptr;
		}
	};
}

namespace TradeCore
{
	public ref class RingBuffer
	{
	public:
		RingBuffer(uint64_t order) :
			shared(false),
			rb(new Native::ring_buffer_t(order))
		{

		}
		RingBuffer(Native::ring_buffer_t* rb_) :
			shared(true),
			rb(rb_)
		{

		}
		~RingBuffer()
		{
			this->!RingBuffer();
		}
		!RingBuffer()
		{
			if (!shared && rb != nullptr)
				delete rb;
			rb = nullptr;
		}
		void Reset()
		{
			rb->reset();
		}
		property uint8_t* BeginRead
		{
			uint8_t* get()
			{
				return rb->begin_read();
			}
		}
		property bool IsEmpty
		{
			bool get()
			{
				return rb->is_empty();
			}
		}
		property uint32_t Size
		{
			uint32_t get()
			{
				return rb->is_empty();
			}
		}
		property uint32_t Usedspace
		{
			uint32_t get()
			{
				return (uint32_t)rb->usedspace();
			}
		}
		property uint32_t Unusedspace
		{
			uint32_t get()
			{
				return (uint32_t)rb->unusedspace();
			}
		}
		uint8_t* BeginWrite(uint32_t sz)
		{
			return rb->begin_write(sz);
		}
		uint8_t* ShiftRead(uint32_t sz)
		{
			return rb->shift_read(sz);
		}
		uint8_t* ShiftWrite(uint32_t sz)
		{
			return rb->shift_write(sz);
		}
	private:
		const bool shared;
		Native::ring_buffer_t* rb;
	};
}