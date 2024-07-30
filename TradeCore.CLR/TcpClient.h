#pragma once

#include "SafeWin.h"
#include "TcpError.h"

#include <exception>
#include <functional>
#include <string>
#include <vector>
#include <deque>
#include <unordered_map>

#include "EventManager.h"
#include "RingBuffer.h"
#include "Utilities.h"

namespace Native
{
	class tcp_client_t : public base_socket_t
	{
	public:
		tcp_client_t(
			void(*Log_)(std::string),
			size_t(*handlepkt)(const uint8_t*, const size_t, uint64_t, void*, bool&),
			void(*onconnect)(uint64_t),
			void(*onadd_)(),
			void(*onremove_)(),
			const std::string& ip_,
			const uint16_t port_,
			const std::string& local_ip_
		) :
			Log(Log_),
			handlepktfn(handlepkt),
			onconnectfn(onconnect),
			onadd(onadd_),
			onremove(onremove_),
			ip(ip_),
			port(port_),
			local_ip(local_ip_),
			sock(INVALID_SOCKET),
			rx(16),
			tx(16),
			local_addr(),
			addr(),
			addrlen(sizeof(addr))
		{
			sock = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
			const char yes = 1;
			// allow multiple sockets to use the same PORT number
			if (::setsockopt(sock, SOL_SOCKET, SO_REUSEADDR, &yes, sizeof(yes)) < 0)
			{
				setsockopt_error(Log);
				Log("Failed resuse address! " + local_ip + ':' + std::to_string(port));
			}
			memset(&local_addr, 0, sizeof(local_addr));
			local_addr.sin_family = AF_INET; // IPV4
			local_addr.sin_addr.s_addr = inet_addr(local_ip.c_str()); // Binding local address
			local_addr.sin_port = 0; // Binding local port
			memset(&addr, 0, sizeof(addr));
			addr.sin_family = AF_INET;
			addr.sin_addr.s_addr = inet_addr(ip.c_str());
			addr.sin_port = htons(port);
			addrlen = sizeof(addr);
		}
		static bool init_networking()
		{
			WSADATA wsaData;
			if (::WSAStartup(0x202, &wsaData) == 0)
			{
				return true;
			}
			return false;
		}
		static void release_networking()
		{
			::WSACleanup();
		}
		uint8_t* emplace_reserve(const size_t len)
		{
			uint8_t* p(tx.begin_write(len));
			if (p != nullptr)
				return p;
			return nullptr;
		}
		size_t emplace_commit(const size_t len_)
		{
			tx.shift_write(len_);
			const uint8_t* tx_ptr(tx.begin_read());
			if (tx_ptr == nullptr)
			{
				Log("Tried to write when there was no data to write!");
				std::abort();
			}
			const size_t len(tx.usedspace());
			try
			{
				const int nbytes(sendto(
					sock,
					(const char*)tx_ptr,
					(int)len,
					0,
					(const sockaddr*)&addr,
					(int)addrlen
				));
				if (nbytes < 0)
				{
					Log("Failed write to socket " + ip + " : " + std::to_string(port) + "!");
					return 0;
				}
				tx.shift_read(nbytes);
				return nbytes;
			}
			catch (const std::exception& exc)
			{
				Log("Writing: Caught: " + std::string(exc.what()));
				return 0;
			}
		}
		bool start()
		{
			if (::bind(sock, (sockaddr*)&local_addr, sizeof(local_addr)) < 0)
			{
				bind_error(Log);
				Log("Failed bind address! " + local_ip + ':' + std::to_string(port));
				std::abort();
			}
			if (::connect(sock, (sockaddr*)&addr, addrlen) < 0)
			{
				Log("Failed to connect socket " + ip + " : " + std::to_string(port) + "!");
				_close();
				return false;
				/*if (errno == ECONNREFUSED)
				{

				}
				if (errno == ETIMEDOUT)
				{
					Log("Failed to connect socket " + ip + " : " + std::to_string(port) + "!");
					_close();
					return false;
				}
				Log("Failed to connect socket with Error!");
				std::abort();*/
			}
			closed_ = false;
			on_connect();
			char opt = 1;
			::setsockopt(sock, IPPROTO_TCP, TCP_NODELAY, &opt, sizeof(char));
			return true;
		}
		void close()
		{
			_close();
		}
		void reset()
		{
			if (!closed_)
			{
				Log("Cannot reset an open socket");
				std::abort();
			}
			sock = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
			if (sock == INVALID_SOCKET)
			{
				Log("Failed to create socket!");
				std::abort();
			}
			rx.reset();
			closed_ = true;
			char yes = 1;
			/* allow multiple sockets to use the same PORT number */
			if (::setsockopt(sock, SOL_SOCKET, SO_REUSEADDR, &yes, sizeof(yes)) < 0)
			{
				Log("Failed resuse address!");
				std::abort();
			}
			memset(&local_addr, 0, sizeof(local_addr));
			local_addr.sin_family = AF_INET; // IPV4
			local_addr.sin_addr.s_addr = inet_addr(local_ip.c_str()); // Binding local address
			local_addr.sin_port = 0; // Binding local port
			memset(&addr, 0, sizeof(addr));
			addr.sin_family = AF_INET;
			addr.sin_addr.s_addr = inet_addr(ip.c_str());
			addr.sin_port = htons(port);
			addrlen = sizeof(addr);
			tx.reset();
		}
		void on_connect()
		{
			onconnectfn(now());
		}
		size_t handle_packet(const uint8_t* buf, const size_t len, uint64_t ts, void* sock, bool& shouldDisconnect)
		{
			return handlepktfn(buf, len, ts, sock, shouldDisconnect);
		}
		const SOCKET& get_sock() override
		{
			return sock;
		}
		bool on_read(uint64_t ts) override
		{
			return read(ts);
		}
		bool read(uint64_t ts)
		{
			const size_t rlen(rx.unusedspace() == 0 ? 0 : rx.unusedspace() - 1);
			uint8_t* rx_ptr(rx.begin_write(rlen));
			if (rx_ptr == nullptr)
			{
				bool shouldDisconect = false;
				handle_packet(nullptr, 0, ts, this, shouldDisconect);
				Log("Failed to allocate enough bytes in the ring buffer!");
				return true;
			}
			try
			{
				const int nbytes(::recvfrom(sock, (char*)rx_ptr, (int)rlen, 0, (sockaddr*)&addr, &addrlen));
				if (nbytes < 0)
				{
					Log("Failed receive in socket " + ip + " : " + std::to_string(port) + "!");
					return true;
				}
				if (nbytes == 0)
				{
					Log("Received 0 bytes " + ip + " : " + std::to_string(port) + "!");
					return true;
				}
				rx.shift_write(nbytes);
				bool shouldDisconect = false;
				const size_t nread(handle_packet(rx.begin_read(), rx.usedspace(), ts, this, shouldDisconect));
				if (shouldDisconect)
					return true;
				rx.shift_read(nread);
				return false;
			}
			catch (const std::exception& exc)
			{
				Log("Reading: Caught: " + std::string(exc.what()));
				_close();
				return true;
			}
		}
		ring_buffer_t* get_rx()
		{
			return &rx;
		}
		ring_buffer_t* get_tx()
		{
			return &tx;
		}
		std::string get_ip() const
		{
			return ip;
		}
		uint16_t get_port() const
		{
			return port;
		}
		std::string get_local_ip() const
		{
			return local_ip;
		}
		void _on_add() override
		{
			onadd();
		}
		void _on_remove() override
		{
			onremove();
		}
	private:
		void _close()
		{
			if (closed_) return;
			if (shutdown(sock, SD_BOTH))
			{
				Log("Failed to shutdown socket, likely disconnected from server!");
			}
			if (closesocket(sock) < 0)
			{
				Log("Failed to close socket!");
			}
			closed_ = true;
		}
	private:
		void(*Log)(std::string);
		size_t(*handlepktfn)(const uint8_t*, const size_t, uint64_t, void*, bool&);
		void(*onconnectfn)(uint64_t);
		void(*onadd)();
		void(*onremove)();
		const std::string ip;
		const uint16_t port;
		const std::string local_ip;
		SOCKET sock;
		ring_buffer_t rx;
		ring_buffer_t tx;
		sockaddr_in local_addr;
		sockaddr_in addr;
		socklen_t addrlen;
		bool closed_;
	};
}

namespace TradeCore
{
	public delegate void OnConnectDelegate(uint64_t);

	public ref class TcpClient : public ISocket
	{
	public:
		TcpClient(
			System::String^ ip_,
			uint16_t port_,
			System::String^ localip_,
			System::Action<System::String^>^ logger_,
			System::Func<RingBuffer^, uint64_t, BoolHolder^, size_t>^ handlePkt_,
			System::Action<uint64_t>^ on_connect_,
			System::Action^ on_add_,
			System::Action^ on_remove_
		) :
			port(port_),
			ip(ip_),
			local_ip(localip_),
			logger(logger_),
			handlePkt(handlePkt_),
			on_connect(on_connect_),
			on_add(on_add_),
			on_remove(on_remove_),
			sock(nullptr),
			rx(nullptr),
			tx(nullptr),
			b(nullptr)
		{
			typedef void(*log_fn_t)(std::string);
			typedef size_t(*handlepkt_fn_t)(const uint8_t*, const size_t, uint64_t, void*, bool&);
			typedef void(*onconnect_fn_t)(uint64_t);
			typedef void(*on_add_fn_t)();
			typedef void(*on_remove_fn_t)();
			const std::string native_ip = to_string(ip_);
			const std::string native_local_ip = to_string(localip_);
			LogDelegate^ fp1 = gcnew LogDelegate(this, &TcpClient::_on_log);
			gc1 = System::Runtime::InteropServices::GCHandle::Alloc(fp1);
			log_fn_t log_fn = static_cast<log_fn_t>(System::Runtime::InteropServices::Marshal::GetFunctionPointerForDelegate(fp1).ToPointer());
			HandlePktDelegate^ fp2 = gcnew HandlePktDelegate(this, &TcpClient::_on_handlepkt);
			gc2 = System::Runtime::InteropServices::GCHandle::Alloc(fp2);
			handlepkt_fn_t handlepkt_fn = static_cast<handlepkt_fn_t>(System::Runtime::InteropServices::Marshal::GetFunctionPointerForDelegate(fp2).ToPointer());
			OnConnectDelegate^ fp3 = gcnew OnConnectDelegate(this, &TcpClient::_on_connect);
			gc3 = System::Runtime::InteropServices::GCHandle::Alloc(fp3);
			onconnect_fn_t onconnect_fn = static_cast<onconnect_fn_t>(System::Runtime::InteropServices::Marshal::GetFunctionPointerForDelegate(fp3).ToPointer());
			OnAddDelegate^ fp4 = gcnew OnAddDelegate(this, &TcpClient::_on_add);
			gc4 = System::Runtime::InteropServices::GCHandle::Alloc(fp4);
			on_add_fn_t on_add_fn = static_cast<on_add_fn_t>(System::Runtime::InteropServices::Marshal::GetFunctionPointerForDelegate(fp4).ToPointer());
			OnRemoveDelegate^ fp5 = gcnew OnRemoveDelegate(this, &TcpClient::_on_remove);
			gc5 = System::Runtime::InteropServices::GCHandle::Alloc(fp5);
			on_remove_fn_t on_remove_fn = static_cast<on_remove_fn_t>(System::Runtime::InteropServices::Marshal::GetFunctionPointerForDelegate(fp5).ToPointer());
			sock = new Native::tcp_client_t(log_fn, handlepkt_fn, onconnect_fn, on_add_fn, on_remove_fn, native_ip, port, native_local_ip);
			rx = gcnew RingBuffer(sock->get_rx());
			tx = gcnew RingBuffer(sock->get_tx());
			b = gcnew BoolHolder();
		}
		void _on_add()
		{
			on_add();
		}
		void _on_remove()
		{
			on_remove();
		}
		void _on_log(std::string log_line)
		{
			System::String^ s = gcnew System::String(log_line.c_str());
			logger(s);
		}
		size_t _on_handlepkt(const uint8_t* buf, const size_t len, uint64_t ts, void* sock, bool& shouldDisconnect)
		{
			BoolHolder^ b = gcnew BoolHolder();
			b->set_value(false);
			const size_t ret(handlePkt(rx, ts, b));
			shouldDisconnect = b->get_value();
			delete b;
			return ret;
		}
		void _on_connect(uint64_t ts)
		{
			on_connect(ts);
		}
		property RingBuffer^ Rx
		{
			RingBuffer^ get()
			{
				return rx;
			}
		}
		property RingBuffer^ Tx
		{
			RingBuffer^ get()
			{
				return tx;
			}
		}
		property System::String^ Ip
		{
			System::String^ get()
			{
				const std::string s(sock->get_ip());
				return gcnew System::String(s.c_str());
			}
		}
		property uint16_t Port
		{
			uint16_t get()
			{
				return sock->get_port();
			}
		}
		property System::String^ LocalIp
		{
			System::String^ get()
			{
				const std::string s(sock->get_local_ip());
				return gcnew System::String(s.c_str());
			}
		}
		void close()
		{
			sock->close();
		}
		~TcpClient()
		{
			if (sock == nullptr)
				delete sock;
			sock = nullptr;
			if (rx == nullptr)
				delete rx;
			rx = nullptr;
			if (tx == nullptr)
				delete tx;
			tx = nullptr;
			if (b == nullptr)
				delete b;
			b = nullptr;
			gc1.Free();
			gc2.Free();
			gc3.Free();
			gc4.Free();
			gc5.Free();
		}
		SOCKET get_sock() override
		{
			return sock->get_sock();
		}
		Native::base_socket_t* get_native() override
		{
			return (Native::base_socket_t*)sock;
		}
		uint8_t* emplace_reserve(const size_t len)
		{
			return sock->emplace_reserve(len);
		}
		size_t emplace_commit(const size_t len)
		{
			return sock->emplace_commit(len);
		}
		bool start()
		{
			return sock->start();
		}
		void reset()
		{
			sock->reset();
		}
		static bool init_networking()
		{
			return Native::tcp_client_t::init_networking();
		}
		static void release_networking()
		{
			Native::tcp_client_t::release_networking();
		}
	private:
		const uint16_t port;
		const System::String^ ip;
		const System::String^ local_ip;
		System::Action<System::String^>^ logger;
		System::Func<RingBuffer^, uint64_t, BoolHolder^, size_t>^ handlePkt;
		System::Action<uint64_t>^ on_connect;
		System::Action^ on_add;
		System::Action^ on_remove;
		Native::tcp_client_t* sock;
		RingBuffer^ rx;
		RingBuffer^ tx;
		BoolHolder^ b;
		System::Runtime::InteropServices::GCHandle gc1;
		System::Runtime::InteropServices::GCHandle gc2;
		System::Runtime::InteropServices::GCHandle gc3;
		System::Runtime::InteropServices::GCHandle gc4;
		System::Runtime::InteropServices::GCHandle gc5;
	};
}