#pragma once

#include "SafeWin.h"
#include "TimerHeap.h"

#include <cstdint>
#include <unordered_map>

namespace Native
{
	class base_socket_t
	{
	public:
		virtual bool on_read(uint64_t ts) = 0;
		virtual const SOCKET& get_sock() = 0;
		virtual void _on_add() = 0;
		virtual void _on_remove() = 0;
	};

	class event_manager_t
	{
	public:
		event_manager_t(void(*Log_)(std::string)) :
			Log(Log_),
			timers(Log, 1024)
		{
			tv.tv_sec = 0;
			tv.tv_usec = 0;
		}
		void poll()
		{
			const uint64_t ts(now());
			timers.poll(ts);
			poll_sockets(ts);
		}
		void add(pollable_timer_t* timer)
		{
			timers.add(timer);
		}
		void remove(pollable_timer_t* timer)
		{
			timers.remove(timer->get_timer_id());
		}
		void add(base_socket_t* sock)
		{
			socks.emplace(std::piecewise_construct, std::forward_as_tuple(sock->get_sock()), std::forward_as_tuple(sock));
		}
		void remove(const SOCKET& sock)
		{
			socks.erase(sock);
		}
		uint64_t em_now() const
		{
			return now();
		}
	private:
		void poll_sockets(uint64_t ts)
		{
			fd_set readfds;
			FD_ZERO(&readfds);
			for (std::unordered_map<SOCKET, base_socket_t*>::const_iterator it(socks.begin()); it != socks.end(); ++it)
				FD_SET(it->first, &readfds);
			const int ret(select(
				0,
				&readfds,
				nullptr,
				nullptr,
				&tv
			));
			if (ret == SOCKET_ERROR)
			{

			}
			else if (ret == 0)
				return;
			else
			{
				std::vector<SOCKET> to_remove;
				for (std::unordered_map<SOCKET, base_socket_t*>::const_iterator it(socks.begin()); it != socks.end(); ++it)
				{
					if (FD_ISSET(it->first, &readfds))
					{
						if (it->second->on_read(ts))
							to_remove.push_back(it->first);
					}
				}
				for (std::vector<SOCKET>::const_iterator it(to_remove.begin()); it != to_remove.end(); ++it)
				{
					socks.erase(*it);
				}
			}
		}
	private:
		void(*Log)(std::string);
		timer_heap_t timers;
		timeval tv;
		std::unordered_map<SOCKET, base_socket_t*> socks;
	};
}

namespace TradeCore
{
	public ref class ISocket abstract
	{
	public:
		virtual SOCKET get_sock() = 0;
		virtual Native::base_socket_t* get_native() = 0;
	};
	public ref class ITimer abstract
	{
	public:
		virtual Native::pollable_timer_t* get_native() = 0;
	};
	public ref class EventManager
	{
	public:
		EventManager(System::Action<System::String^>^ logger_) :
			logger(logger_),
			em(nullptr)
		{
			typedef void(*log_fn_t)(std::string);
			LogDelegate^ fp1 = gcnew LogDelegate(this, &EventManager::_on_log);
			gc1 = System::Runtime::InteropServices::GCHandle::Alloc(fp1);
			log_fn_t log_fn = static_cast<log_fn_t>(System::Runtime::InteropServices::Marshal::GetFunctionPointerForDelegate(fp1).ToPointer());
			em = new Native::event_manager_t(log_fn);
		}
		void _on_log(std::string log_line)
		{
			System::String^ s = gcnew System::String(log_line.c_str());
			logger(s);
		}
		uint64_t now()
		{
			return em->em_now();
		}
		void poll()
		{
			em->poll();
		}
		void add(ITimer^ timer)
		{
			em->add(timer->get_native());
		}
		void remove(ITimer^ timer)
		{
			em->remove(timer->get_native());
		}
		void add(ISocket^ sock)
		{
			em->add(sock->get_native());
		}
		void remove(ISocket^ sock)
		{
			em->remove(sock->get_sock());
		}
		~EventManager()
		{
			if (em != nullptr)
				delete em;
			em = nullptr;
			gc1.Free();
		}
	private:
		System::Action<System::String^>^ logger;
		Native::event_manager_t* em;
		System::Runtime::InteropServices::GCHandle gc1;
	};
}