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
	class tcp_server_socket_t : public base_socket_t
	{
	public:
		tcp_server_socket_t(
			void* parent_,
			SOCKET child_sock,
			sockaddr child_addr,
			int child_addrlen,
			uint16_t peer_port_,
			const std::string& peer_ip_,
			void(*Log_)(std::string),
			size_t(*handlepkt)(const uint8_t*, const size_t, uint64_t, void*, bool&),
			void(*onadd_)(),
			void(*onremove_)(),
			const uint16_t local_port_,
			const std::string& local_ip_) :
			parent(parent_),
			Log(Log_),
			handlepktfn(handlepkt),
			onadd(onadd_),
			onremove(onremove_),
			local_port(local_port_),
			local_ip(local_ip_),
			sock(child_sock),
			addr(child_addr),
			addrlen(child_addrlen),
			peer_port(peer_port_),
			peer_ip(peer_ip_),
			rx(16),
			tx(16),
			closed_(false)
		{

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
					Log("Failed write to socket " + peer_ip + " : " + std::to_string(peer_port) + " local: " + local_ip + " : " + std::to_string(local_port) + "!");
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
					Log("Failed receive in socket peer: " + peer_ip + " : " + std::to_string(peer_port) + " local: " + local_ip + " : " + std::to_string(local_port) + "!");
					return true;
				}
				if (nbytes == 0)
				{
					Log("Received 0 bytes peer: " + peer_ip + " : " + std::to_string(peer_port) + " local: " + local_ip + " : " + std::to_string(local_port) + "!");
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
		void close()
		{
			_close();
		}
		size_t handle_packet(const uint8_t* buf, const size_t len, uint64_t ts, void* sock, bool& shouldDisconnect)
		{
			return handlepktfn(buf, len, ts, sock, shouldDisconnect);
		}
		ring_buffer_t* get_rx()
		{
			return &rx;
		}
		ring_buffer_t* get_tx()
		{
			return &tx;
		}
		const SOCKET& get_sock() override
		{
			return sock;
		}
		void _on_add() override
		{
			onadd();
		}
		void _on_remove() override
		{
			onremove();
		}
		uint16_t get_local_port() const
		{
			return local_port;
		}
		std::string get_local_ip() const
		{
			return local_ip;
		}
		uint16_t get_peer_port() const
		{
			return peer_port;
		}
		std::string get_peer_ip() const
		{
			return peer_ip;
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
		void* parent;
		void(*Log)(std::string);
		size_t(*handlepktfn)(const uint8_t*, const size_t, uint64_t, void*, bool&);
		void(*onadd)();
		void(*onremove)();
		const uint16_t local_port;
		const std::string local_ip;
		SOCKET sock;
		sockaddr addr;
		int addrlen;
		const uint16_t peer_port;
		const std::string peer_ip;
		ring_buffer_t rx;
		ring_buffer_t tx;
		bool closed_;
	};

	class tcp_server_t : public base_socket_t
	{
	public:
		tcp_server_t(
			void(*Log_)(std::string),
			void(*onadd_)(),
			void(*onremove_)(),
			void(*make_socket_)(void*, SOCKET, void*, int, uint16_t, std::string, uint16_t, std::string, uint64_t),
			const uint16_t port_,
			const std::string& local_ip_
		) :
			Log(Log_),
			onadd(onadd_),
			onremove(onremove_),
			make_socket(make_socket_),
			port(port_),
			local_ip(local_ip_),
			sock(INVALID_SOCKET),
			local_addr()
		{
			sock = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
			const char yes = 1;
			/* allow multiple sockets to use the same PORT number */
			if (::setsockopt(sock, SOL_SOCKET, SO_REUSEADDR, &yes, sizeof(yes)) < 0)
				Log("Failed resuse address!");
			memset(&local_addr, 0, sizeof(local_addr));
			local_addr.sin_family = AF_INET; // IPV4
			local_addr.sin_addr.s_addr = inet_addr(local_ip.c_str()); // Binding local address
			local_addr.sin_port = port; // Binding local port
		}
		bool start()
		{
			if (::bind(sock, (sockaddr*)&local_addr, sizeof(local_addr)) < 0)
			{
				Log("Failed bind address!");
				std::abort();
			}
			if (::listen(sock, SOMAXCONN) != 0)
			{
				Log("Failed to listen socket " + local_ip + " : " + std::to_string(port) + "!");
				_close();
				return false;
			}
			closed_ = false;
			return true;
		}
		void close()
		{
			_close();
		}
		bool on_read(uint64_t ts) override
		{
			sockaddr child_addr;
			int child_addrlen;
			SOCKET child_sock(::accept(sock, &child_addr, &child_addrlen));
			if (child_sock == INVALID_SOCKET)
			{
				return true; // stop listening
			}
			else
			{
				char peer_str_buf[INET_ADDRSTRLEN];
				memset(peer_str_buf, 0, INET_ADDRSTRLEN);
				sockaddr_in* sin = (sockaddr_in*)&child_addr;
				inet_ntop(AF_INET, &sin->sin_addr, peer_str_buf, INET_ADDRSTRLEN);
				const uint16_t peer_port(htons(sin->sin_port));
				const std::string peer_ip(peer_str_buf);
				make_socket(this, child_sock, &child_addr, child_addrlen, peer_port, peer_ip, port, local_ip, ts);
				return false;
			}
		}
		const SOCKET& get_sock() override
		{
			return sock;
		}
		void _on_add() override
		{
			onadd();
		}
		void _on_remove() override
		{
			onremove();
		}
		uint16_t get_local_port() const
		{
			return port;
		}
		const std::string& get_local_ip() const
		{
			return local_ip;
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
		void(*onadd)();
		void(*onremove)();
		void(*make_socket)(void*, SOCKET, void*, int, uint16_t, std::string, uint16_t, std::string, uint64_t);
		const uint16_t port;
		const std::string local_ip;
		SOCKET sock;
		sockaddr_in local_addr;
		socklen_t addrlen;
		bool closed_;
	};
}

namespace TradeCore
{
	public ref class TcpServerSocketConnectionData
	{
	public:
		TcpServerSocketConnectionData(
			void* parent_,
			SOCKET child_sock_,
			void* child_addr_,
			int child_addrlen_
		) :
			parent(parent_),
			child_sock(child_sock_),
			child_addr((sockaddr*)child_addr_),
			child_addrlen(child_addrlen_)
		{

		}
		void* get_parent()
		{
			return parent;
		}
		SOCKET get_child_sock()
		{
			return child_sock;
		}
		sockaddr* get_child_addr()
		{
			return child_addr;
		}
		int get_child_addrlen()
		{
			return child_addrlen;
		}
	private:
		void* parent;
		SOCKET child_sock;
		sockaddr* child_addr;
		int child_addrlen;
	};

	public delegate void MakeSocketDelegate(void*, SOCKET, void*, int, uint16_t, std::string, uint16_t, std::string, uint64_t);

	public ref class TcpServerSocket : public ISocket
	{
	public:
		TcpServerSocket(
			TcpServerSocketConnectionData^ conn_data,
			uint16_t peer_port_,
			System::String^ peerip_,
			uint16_t local_port_,
			System::String^ localip_,
			System::Action<System::String^>^ logger_,
			System::Func<RingBuffer^, uint64_t, BoolHolder^, size_t>^ handlePkt_,
			System::Action^ on_add_,
			System::Action^ on_remove_
		) :
			peer_port(peer_port_),
			local_port(local_port_),
			peer_ip(peerip_),
			local_ip(localip_),
			logger(logger_),
			handlePkt(handlePkt_),
			on_add(on_add_),
			on_remove(on_remove_),
			sock(nullptr),
			rx(nullptr),
			tx(nullptr),
			b(nullptr)
		{
			typedef void(*log_fn_t)(std::string);
			typedef size_t(*handlepkt_fn_t)(const uint8_t*, const size_t, uint64_t, void*, bool&);
			typedef void(*on_add_fn_t)();
			typedef void(*on_remove_fn_t)();
			const std::string native_peer_ip = to_string(peerip_);
			const std::string native_local_ip = to_string(localip_);
			LogDelegate^ fp1 = gcnew LogDelegate(this, &TcpServerSocket::_on_log);
			gc1 = System::Runtime::InteropServices::GCHandle::Alloc(fp1);
			log_fn_t log_fn = static_cast<log_fn_t>(System::Runtime::InteropServices::Marshal::GetFunctionPointerForDelegate(fp1).ToPointer());
			HandlePktDelegate^ fp2 = gcnew HandlePktDelegate(this, &TcpServerSocket::_on_handlepkt);
			gc2 = System::Runtime::InteropServices::GCHandle::Alloc(fp2);
			handlepkt_fn_t handlepkt_fn = static_cast<handlepkt_fn_t>(System::Runtime::InteropServices::Marshal::GetFunctionPointerForDelegate(fp2).ToPointer());
			OnAddDelegate^ fp4 = gcnew OnAddDelegate(this, &TcpServerSocket::_on_add);
			gc4 = System::Runtime::InteropServices::GCHandle::Alloc(fp4);
			on_add_fn_t on_add_fn = static_cast<on_add_fn_t>(System::Runtime::InteropServices::Marshal::GetFunctionPointerForDelegate(fp4).ToPointer());
			OnRemoveDelegate^ fp5 = gcnew OnRemoveDelegate(this, &TcpServerSocket::_on_remove);
			gc5 = System::Runtime::InteropServices::GCHandle::Alloc(fp5);
			on_remove_fn_t on_remove_fn = static_cast<on_remove_fn_t>(System::Runtime::InteropServices::Marshal::GetFunctionPointerForDelegate(fp5).ToPointer());
			sock = new Native::tcp_server_socket_t(conn_data->get_parent(), conn_data->get_child_sock(), *conn_data->get_child_addr(), conn_data->get_child_addrlen(), peer_port, native_peer_ip, log_fn, handlepkt_fn, on_add_fn, on_remove_fn, local_port, native_local_ip);
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
		property System::String^ PeerIp
		{
			System::String^ get()
			{
				const std::string s(sock->get_peer_ip());
				return gcnew System::String(s.c_str());
			}
		}
		property uint16_t PeerPort
		{
			uint16_t get()
			{
				return sock->get_peer_port();
			}
		}
		property uint16_t LocalPort
		{
			uint16_t get()
			{
				return sock->get_local_port();
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
		~TcpServerSocket()
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
	private:
		const uint16_t peer_port;
		const uint16_t local_port;
		const System::String^ peer_ip;
		const System::String^ local_ip;
		System::Action<System::String^>^ logger;
		System::Func<RingBuffer^, uint64_t, BoolHolder^, size_t>^ handlePkt;
		System::Action^ on_add;
		System::Action^ on_remove;
		Native::tcp_server_socket_t* sock;
		RingBuffer^ rx;
		RingBuffer^ tx;
		BoolHolder^ b;
		System::Runtime::InteropServices::GCHandle gc1;
		System::Runtime::InteropServices::GCHandle gc2;
		System::Runtime::InteropServices::GCHandle gc4;
		System::Runtime::InteropServices::GCHandle gc5;
	};

	public ref class TcpServer : public ISocket
	{
	public:
		TcpServer(
			uint16_t port_,
			System::String^ localip_,
			System::Action<System::String^>^ logger_,
			System::Func<TcpServer^, TcpServerSocketConnectionData^, uint16_t, System::String^, uint16_t, System::String^, uint64_t, TcpServerSocket^>^ makeSocket_,
			System::Action<uint64_t>^ on_connect_,
			System::Action^ on_add_,
			System::Action^ on_remove_
		) :
			port(port_),
			local_ip(localip_),
			logger(logger_),
			makeSocket(makeSocket_),
			on_add(on_add_),
			on_remove(on_remove_),
			sock(nullptr)
		{
			typedef void(*log_fn_t)(std::string);
			typedef void(*make_socket_fn_t)(void*, SOCKET, void*, int, uint16_t, std::string, uint16_t, std::string, uint64_t);
			typedef void(*on_add_fn_t)();
			typedef void(*on_remove_fn_t)();
			const std::string native_local_ip = to_string(localip_);
			LogDelegate^ fp1 = gcnew LogDelegate(this, &TcpServer::_on_log);
			gc1 = System::Runtime::InteropServices::GCHandle::Alloc(fp1);
			log_fn_t log_fn = static_cast<log_fn_t>(System::Runtime::InteropServices::Marshal::GetFunctionPointerForDelegate(fp1).ToPointer());
			MakeSocketDelegate^ fp2 = gcnew MakeSocketDelegate(this, &TcpServer::_on_make_sock);
			gc2 = System::Runtime::InteropServices::GCHandle::Alloc(fp2);
			make_socket_fn_t make_sock_fn = static_cast<make_socket_fn_t>(System::Runtime::InteropServices::Marshal::GetFunctionPointerForDelegate(fp2).ToPointer());
			OnAddDelegate^ fp4 = gcnew OnAddDelegate(this, &TcpServer::_on_add);
			gc4 = System::Runtime::InteropServices::GCHandle::Alloc(fp4);
			on_add_fn_t on_add_fn = static_cast<on_add_fn_t>(System::Runtime::InteropServices::Marshal::GetFunctionPointerForDelegate(fp4).ToPointer());
			OnRemoveDelegate^ fp5 = gcnew OnRemoveDelegate(this, &TcpServer::_on_remove);
			gc5 = System::Runtime::InteropServices::GCHandle::Alloc(fp5);
			on_remove_fn_t on_remove_fn = static_cast<on_remove_fn_t>(System::Runtime::InteropServices::Marshal::GetFunctionPointerForDelegate(fp5).ToPointer());
			sock = new Native::tcp_server_t(log_fn, on_add_fn, on_remove_fn, make_sock_fn, port, native_local_ip);
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
		void _on_make_sock(void* parent, SOCKET child_sock, void* child_addr, int child_addrlen, uint16_t peer_port, std::string peer_ip, uint16_t local_port, std::string local_ip, uint64_t ts)
		{
			TcpServerSocketConnectionData^ d = gcnew TcpServerSocketConnectionData(parent, child_sock, child_addr, child_addrlen);
			System::String^ cs_peer_ip = gcnew System::String(peer_ip.c_str());
			System::String^ cs_local_ip = gcnew System::String(local_ip.c_str());
			TcpServerSocket^ new_sock(makeSocket(this, d, peer_port, cs_peer_ip, local_port, cs_local_ip, ts));
			(void)new_sock;
		}
		property uint16_t Port
		{
			uint16_t get()
			{
				return sock->get_local_port();
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
		~TcpServer()
		{
			if (sock == nullptr)
				delete sock;
			sock = nullptr;
			gc1.Free();
			gc2.Free();
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
		bool start()
		{
			return sock->start();
		}
		void reset()
		{
			//sock->reset();
		}
		static bool init_networking()
		{
			return Native::tcp_server_t::init_networking();
		}
		static void release_networking()
		{
			Native::tcp_server_t::release_networking();
		}
	private:
		const uint16_t port;
		const System::String^ ip;
		const System::String^ local_ip;
		System::Action<System::String^>^ logger;
		System::Func<TcpServer^, TcpServerSocketConnectionData^, uint16_t, System::String^, uint16_t, System::String^, uint64_t, TcpServerSocket^>^ makeSocket;
		System::Action^ on_add;
		System::Action^ on_remove;
		Native::tcp_server_t* sock;
		System::Runtime::InteropServices::GCHandle gc1;
		System::Runtime::InteropServices::GCHandle gc2;
		System::Runtime::InteropServices::GCHandle gc4;
		System::Runtime::InteropServices::GCHandle gc5;
	};
}