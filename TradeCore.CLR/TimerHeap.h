#pragma once

#include <vector>
#include <functional> // std::less
#include <utility> // std::swap
#include <stdexcept>
#include <cassert>
#include <functional>
#include <string>
#include "Utilities.h"

namespace Native
{
	// A binary min-heap implemented using the given comparator.
	template<typename T, typename Comparator = std::less<T>>
	class heap_t
	{
	public:
		void reserve(size_t sz)
		{
			m_data.reserve(sz);
		}
		void pop()
		{
			assert(!m_data.empty());
			m_data.front() = std::move(m_data.back());
			m_data.pop_back();
			sift_down(0);
		}
		const T& top() const
		{
			assert(!m_data.empty());
			return m_data.front();
		}
		// Just dont change how the comparator would evaluate
		T& top()
		{
			assert(!m_data.empty());
			return m_data.front();
		}
		bool empty() const
		{
			return m_data.empty();
		}
		void push(const T& value)
		{
			emplace(value);
		}
		void push(T&& value)
		{
			emplace(std::move(value));
		}
		template <class... Args>
		T& emplace(Args&& ... args)
		{
			auto idx = m_data.size();
			T& ref = m_data.emplace_back(std::forward<Args>(args)...);
			sift_up(idx);
			return ref;
		}
		void print(std::function<void(T&)> fn)
		{
			heap_t<T, Comparator> cp;
			cp.m_data = m_data;
			while (!cp.empty())
			{
				fn(cp.top());
				cp.pop();
			}
		}
		std::vector<T>& get_vector()
		{
			return m_data;
		}
	private:
		constexpr static size_t parent_of(size_t index)
		{
			return (index - 1) / 2;
		}
		constexpr static size_t left_of(size_t index)
		{
			return 2 * index + 1;
		}
		constexpr static size_t right_of(size_t index)
		{
			return 2 * index + 2;
		}
		constexpr static bool root(size_t index)
		{
			return index == 0;
		}
		bool less(size_t lhs, size_t rhs) const
		{
			return m_cmp(m_data[lhs], m_data[rhs]);
		}
		void swap(size_t lhs, size_t rhs)
		{
			std::swap(m_data[lhs], m_data[rhs]);
		}
		void sift_up(size_t child)
		{
			if (root(child))
				return;
			auto parent = parent_of(child);
			if (!less(parent, child))
			{
				swap(parent, child);
				sift_up(parent);
			}
		}
		void sift_down(size_t parent)
		{
			auto left = left_of(parent);
			auto right = right_of(parent);
			// Note: "right <= parent" means that the index calculation of the right child overflowed.
			// Assume: 0 <= parent < 2^k  (i.e. parent is valid index) for some positive k depending on the index type.
			// The index of right is calculated as: 
			//
			//     right = 2*parent + 2 (0)
			//
			// Then an overflow that the above test would return false for can only occurr if:
			//     
			//     (2*parent + 2 =) (parent + x) % (2^k) > parent  (1)
			//
			// Where x = parent + 2. Inequality (1) can only be true if:
			// 
			//     x = n*2^k + y; where "n >= 1" and "0 < y < 2^k - parent" (2).
			//
			// Now we know that "parent < 2^k" thus "n >= 1" can only occur if "2^k - 2 <= parent < 2^k"
			// so we can test the two cases:
			// 
			// Case: parent = 2^k - 2
			// From the above we know that n=1. Inserting "parent = 2^k - 2"  into (2) yields: 0 < y < 2 
			// and calculating y yields y = 0, thus this case contradicts (1).
			// 
			// Case: parent = 2^k - 1
			// From the above we know that n=1. Inserting "parent = 2^k - 1" into (2) yields: 0 < y < 1
			// and calculating y yields y = 1. This case too contradicts (1). 
			//
			// Thus we have proven that if "right <= parent" is sufficienct and necessary conditions for
			// detecting if an overflow has occurred. For the left index replace "2*parent + 2" with "2*parent + 1"
			// and repeat the same steps. The result will be that the first case cannot occurr.

			auto has_right = right < m_data.size() && right > parent; // right > parent == !(right <= parent) - overflow
			auto has_left = left < m_data.size() && left > parent;

			if (has_right && less(right, parent))
			{
				// By design, left < right so if has_right is true then has_left is also true.
				if (less(left, right))
				{
					swap(left, parent);
					sift_down(left);
				}
				else
				{
					swap(right, parent);
					sift_down(right);
				}
			}
			else if (has_left && less(left, parent))
			{
				swap(left, parent);
				sift_down(left);
			}
			// Else, well we're either on the last level or the heap property holds
		}
	private:
		std::vector<T> m_data;
		Comparator m_cmp;
	};

	namespace pollable_timer_type_e
	{
		enum Enum
		{
			Relative = 0,
			OneShot = 1
		};
	}

	class base_timer_heap_t;
	class pollable_timer_t
	{
	public:
		virtual void on_add() = 0;
		virtual void on_remove() = 0;
		virtual bool _on_add() = 0;
		virtual void _on_remove() = 0;
		virtual void on_timer(uint64_t ts) = 0;
		virtual void _on_timer(uint64_t ts) = 0;
		virtual uint64_t next() const = 0;
		virtual void set_heap(base_timer_heap_t*) = 0;
		virtual uint64_t get_timer_id() = 0;
		virtual void set_timer_id(uint64_t id) = 0;
		virtual const std::string& get_name() = 0;
		virtual void set_name(const std::string& name) = 0;
		virtual void _set() = 0;
		virtual pollable_timer_type_e::Enum timer_type() const = 0;
		virtual ~pollable_timer_t() {}
	};

	class base_timer_heap_t
	{
	public:
		virtual void add(pollable_timer_t* timer) = 0;
		virtual void remove(uint64_t timer_id) = 0;
		virtual void poll(uint64_t ts) = 0;
	};

	struct timer_heap_element_t
	{
		pollable_timer_t* timer;
		bool _removed;

		explicit timer_heap_element_t(pollable_timer_t* timer_) :
			timer(timer_),
			_removed(false)
		{}
		uint64_t next() const
		{
			return timer->next();
		}
		bool removed() const
		{
			return _removed;
		}
		const std::string& name() const
		{
			return timer->get_name();
		}
		uint64_t timer_id() const
		{
			return timer->get_timer_id();
		}
	};

	class pollable_timer_comparator_t
	{
	public:
		bool operator()(const timer_heap_element_t& a, const timer_heap_element_t& b) const
		{
			return a.timer->next() < b.timer->next();
		}
	};

	class timer_heap_t : public base_timer_heap_t
	{
	public:
		explicit timer_heap_t(void(*Log_)(std::string), uint32_t expected_size) :
			heap(),
			current_timer_id(0)
		{
			heap.reserve(expected_size);
		}
		void add(pollable_timer_t* timer) override
		{
			timer->set_heap(this);
			timer->_set();
			heap.emplace(timer);
			timer->set_timer_id(++current_timer_id);
			timer->_on_add();
		}
		void remove(uint64_t timer_id) override
		{
			std::vector<timer_heap_element_t>& v(heap.get_vector());
			std::vector<timer_heap_element_t> vc(v);
			v.clear();
			for (timer_heap_element_t& e : vc)
			{
				if (e.timer_id() == timer_id)
					continue;
				heap.push(e);
			}
		}
		void print()
		{
			int i = 0;
			heap.print([&i, this](timer_heap_element_t& elem) -> void
				{
					Log(std::to_string(++i) + " " + std::to_string(elem.next()) + " " + elem.name());
				});
		}
		void poll(uint64_t ts) override
		{
			while (true)
			{
				if (heap.empty())
					return;
				timer_heap_element_t timer(heap.top());
				if (ts < timer.next())  // now is before the next timer fire, therefore no timers are ready
					return;
				heap.pop();
				if (timer.removed())
					continue;
				timer.timer->_on_timer(ts);
				switch (timer.timer->timer_type())
				{
				case pollable_timer_type_e::Relative:
				{
					heap.push(timer);
				}
				break;
				case pollable_timer_type_e::OneShot:
				{
					timer.timer->_on_remove();
				}
				break;
				default:
				{
					Log("Unrecognized pollable_timer_type " + std::to_string((int)(timer.timer->timer_type())));
					std::abort();
				}
				}
			}
		}
	private:
		void(*Log)(std::string);
		heap_t<timer_heap_element_t, pollable_timer_comparator_t> heap;
		uint64_t current_timer_id;
	};
}