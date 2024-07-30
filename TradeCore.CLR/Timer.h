#pragma once

#include "EventManager.h"
#include "Utilities.h"

namespace Native
{
	class relative_schedule_timer_t : public pollable_timer_t
	{
	public:
		relative_schedule_timer_t(
			void(*onadd_)(),
			void(*onremove_)(),
			void(*ontimer_)(uint64_t),
			const uint64_t nanosecondInterval, const uint64_t nanosecondOffset = 0) :
			onadd(onadd_),
			onremove(onremove_),
			ontimer(ontimer_),
			em(nullptr),
			last(0),
			interval_(nanosecondInterval),
			offset_(nanosecondOffset),
			timer_id(0),
			heap(nullptr),
			name("relative_schedule_timer_t") {}
		virtual ~relative_schedule_timer_t()
		{
			remove();
		}
		void set_event_manager(event_manager_t* em_)
		{
			em = em_;
		}
		pollable_timer_type_e::Enum timer_type() const override
		{
			return pollable_timer_type_e::Enum::Relative;
		}
		void set_heap(base_timer_heap_t* heap_) override
		{
			heap = heap_;
		}
		uint64_t get_timer_id() override
		{
			return timer_id;
		}
		void set_timer_id(uint64_t id) override
		{
			timer_id = id;
		}
		const std::string& get_name() override
		{
			return name;
		}
		void set_name(const std::string& name_) override
		{
			name = name_;
		}
		uint64_t next() const override
		{
			return last + interval_;
		}
		void _on_timer(uint64_t ts) override
		{
			// exactly every interval
			// last += interval_;
			// allowed to skip / delay intervals, best attempt
			last = ts + interval_;
			on_timer(ts);
		}
		void _set() override
		{
			last = offset_ + now();
		}
		bool _on_add() override
		{
			const bool flag(start());
			if (flag)
				on_add();
			return flag;
		}
		void _on_remove() override
		{
			on_remove();
			timer_id = 0;
		}
		void reset()
		{
			last = 0;
			timer_id = 0;
		}
		void on_add()
		{
			onadd();
		}
		void on_remove()
		{
			onremove();
		}
		void on_timer(uint64_t ts)
		{
			ontimer(ts);
		}
	protected:
		void(*onadd)();
		void(*onremove)();
		void(*ontimer)(uint64_t);
		event_manager_t* em;
		uint64_t last;
		const uint64_t interval_;
		const uint64_t offset_;
		uint64_t timer_id;
		base_timer_heap_t* heap;
		std::string name;
		bool start()
		{
			return true;
		}
		void remove()
		{
			if (heap == nullptr)
				return;
			heap->remove(timer_id);
		}
	};

	class one_shot_timer_t : public pollable_timer_t
	{
	public:
		one_shot_timer_t(
			void(*onadd_)(),
			void(*onremove_)(),
			void(*ontimer_)(uint64_t),
			const uint64_t nanosecondInterval) :
			onadd(onadd_),
			onremove(onremove_),
			ontimer(ontimer_),
			em(nullptr),
			last(0),
			interval_(nanosecondInterval),
			timer_id(0),
			heap(nullptr),
			name("one_shot_timer_t"),
			is_on_timer(false)
		{}
		virtual ~one_shot_timer_t()
		{
			if (heap != nullptr && timer_id != 0)
				remove();
		}
		void set_event_manager(event_manager_t* em_)
		{
			em = em_;
		}
		pollable_timer_type_e::Enum timer_type() const override
		{
			return pollable_timer_type_e::Enum::OneShot;
		}
		void set_heap(base_timer_heap_t* heap_) override
		{
			heap = heap_;
		}
		uint64_t get_timer_id() override
		{
			return timer_id;
		}
		void set_timer_id(uint64_t id) override
		{
			timer_id = id;
		}
		const std::string& get_name() override
		{
			return name;
		}
		void set_name(const std::string& name_) override
		{
			name = name_;
		}
		uint64_t next() const override
		{
			return last + interval_;
		}
		void _on_timer(uint64_t ts) override
		{
			// exactly every interval
			// last += interval_;
			// allowed to skip / delay intervals, best attempt
			last = ts + interval_;
			is_on_timer = true;
			on_timer(ts);
			is_on_timer = false;
		}
		bool remove_safely()
		{
			if (!is_on_timer)
			{
				if (heap == nullptr)
					return false;
				heap->remove(timer_id);
				return true;
			}
			return false;
		}
		void _set() override
		{
			last = now();
		}
		bool _on_add() override
		{
			const bool flag(start());
			if (flag)
				on_add();
			return flag;
		}
		void _on_remove() override
		{
			on_remove();
			timer_id = 0;
		}
		void reset_interval(const uint64_t new_interval)
		{
			interval_ = new_interval;
		}
		void reset()
		{
			last = 0;
			timer_id = 0;
		}
		void on_add()
		{
			onadd();
		}
		void on_remove()
		{
			onremove();
		}
		void on_timer(uint64_t ts)
		{
			ontimer(ts);
		}
	protected:
		void(*onadd)();
		void(*onremove)();
		void(*ontimer)(uint64_t);
		event_manager_t* em;
		uint64_t last;
		uint64_t interval_;
		uint64_t timer_id;
		base_timer_heap_t* heap;
		std::string name;
		bool is_on_timer;
		bool start()
		{
			return true;
		}
		void remove()
		{
			if (heap == nullptr)
				return;
			heap->remove(timer_id);
		}
	};
}

namespace TradeCore
{
	public delegate void OnTimerDelegate(uint64_t);

	public ref class RelativeTimer : public ITimer
	{
	public:
		RelativeTimer(
			System::Action^ on_add_,
			System::Action^ on_remove_,
			System::Action<uint64_t>^ on_timer_,
			uint64_t ns_iternval,
			uint64_t ns_offset
		) :
			on_add(on_add_),
			on_remove(on_remove_),
			on_timer(on_timer_),
			timer(nullptr)
		{
			typedef void(*on_add_fn_t)();
			typedef void(*on_remove_fn_t)();
			typedef void(*on_timer_fn_t)(uint64_t);
			OnAddDelegate^ fp1 = gcnew OnAddDelegate(this, &RelativeTimer::_on_add);
			gc1 = System::Runtime::InteropServices::GCHandle::Alloc(fp1);
			on_add_fn_t on_add_fn = static_cast<on_add_fn_t>(System::Runtime::InteropServices::Marshal::GetFunctionPointerForDelegate(fp1).ToPointer());
			OnRemoveDelegate^ fp2 = gcnew OnRemoveDelegate(this, &RelativeTimer::_on_remove);
			gc2 = System::Runtime::InteropServices::GCHandle::Alloc(fp2);
			on_remove_fn_t on_remove_fn = static_cast<on_remove_fn_t>(System::Runtime::InteropServices::Marshal::GetFunctionPointerForDelegate(fp2).ToPointer());
			OnTimerDelegate^ fp3 = gcnew OnTimerDelegate(this, &RelativeTimer::_on_timer);
			gc3 = System::Runtime::InteropServices::GCHandle::Alloc(fp3);
			on_timer_fn_t on_timer_fn = static_cast<on_timer_fn_t>(System::Runtime::InteropServices::Marshal::GetFunctionPointerForDelegate(fp3).ToPointer());
			timer = new Native::relative_schedule_timer_t(on_add_fn, on_remove_fn, on_timer_fn, ns_iternval, ns_offset);
		}
		void _on_timer(uint64_t ts)
		{
			on_timer(ts);
		}
		void _on_add()
		{
			on_add();
		}
		void _on_remove()
		{
			on_remove();
		}
		~RelativeTimer()
		{
			if (timer != nullptr)
				delete timer;
			timer = nullptr;
			gc1.Free();
			gc2.Free();
			gc3.Free();
		}
		Native::pollable_timer_t* get_native() override
		{
			return (Native::pollable_timer_t*)timer;
		}
	private:
		System::Action^ on_add;
		System::Action^ on_remove;
		System::Action<uint64_t>^ on_timer;
		Native::relative_schedule_timer_t* timer;
		System::Runtime::InteropServices::GCHandle gc1;
		System::Runtime::InteropServices::GCHandle gc2;
		System::Runtime::InteropServices::GCHandle gc3;
	};

	public ref class OneShotTimer : public ITimer
	{
	public:
		OneShotTimer(
			System::Action^ on_add_,
			System::Action^ on_remove_,
			System::Action<uint64_t>^ on_timer_,
			uint64_t ns_iternval
		) :
			on_add(on_add_),
			on_remove(on_remove_),
			on_timer(on_timer_),
			timer(nullptr)
		{
			typedef void(*on_add_fn_t)();
			typedef void(*on_remove_fn_t)();
			typedef void(*on_timer_fn_t)(uint64_t);
			OnAddDelegate^ fp1 = gcnew OnAddDelegate(this, &OneShotTimer::_on_add);
			gc1 = System::Runtime::InteropServices::GCHandle::Alloc(fp1);
			on_add_fn_t on_add_fn = static_cast<on_add_fn_t>(System::Runtime::InteropServices::Marshal::GetFunctionPointerForDelegate(fp1).ToPointer());
			OnRemoveDelegate^ fp2 = gcnew OnRemoveDelegate(this, &OneShotTimer::_on_remove);
			gc2 = System::Runtime::InteropServices::GCHandle::Alloc(fp2);
			on_remove_fn_t on_remove_fn = static_cast<on_remove_fn_t>(System::Runtime::InteropServices::Marshal::GetFunctionPointerForDelegate(fp2).ToPointer());
			OnTimerDelegate^ fp3 = gcnew OnTimerDelegate(this, &OneShotTimer::_on_timer);
			gc3 = System::Runtime::InteropServices::GCHandle::Alloc(fp3);
			on_timer_fn_t on_timer_fn = static_cast<on_timer_fn_t>(System::Runtime::InteropServices::Marshal::GetFunctionPointerForDelegate(fp3).ToPointer());
			timer = new Native::one_shot_timer_t(on_add_fn, on_remove_fn, on_timer_fn, ns_iternval);
		}
		void _on_timer(uint64_t ts)
		{
			on_timer(ts);
		}
		void _on_add()
		{
			on_add();
		}
		void _on_remove()
		{
			on_remove();
		}
		~OneShotTimer()
		{
			if (timer != nullptr)
				delete timer;
			timer = nullptr;
			gc1.Free();
			gc2.Free();
			gc3.Free();
		}
		Native::pollable_timer_t* get_native() override
		{
			return (Native::pollable_timer_t*)timer;
		}
	private:
		System::Action^ on_add;
		System::Action^ on_remove;
		System::Action<uint64_t>^ on_timer;
		Native::one_shot_timer_t* timer;
		System::Runtime::InteropServices::GCHandle gc1;
		System::Runtime::InteropServices::GCHandle gc2;
		System::Runtime::InteropServices::GCHandle gc3;
	};
}