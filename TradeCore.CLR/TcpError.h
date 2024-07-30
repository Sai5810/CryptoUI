#pragma once

#include "SafeWin.h"

void WSASocket_error_log(std::function<void(std::string)> Log)
{
	switch (::WSAGetLastError())
	{
	case WSANOTINITIALISED:
	{
		Log("WSASocketA Error 10093,WSANOTINITIALISED: A successful WSAStartup call must occur before using this function.");
		break;
	}
	case WSAENETDOWN:
	{
		Log("WSASocketA Error 10050,WSAENETDOWN: The network subsystem has failed.");
		break;
	}
	case WSAEAFNOSUPPORT:
	{
		Log("WSASocketA Error 10047,WSAEAFNOSUPPORT: The specified address family is not supported.");
		break;
	}
	case WSAEFAULT:
	{
		Log("WSASocketA Error 10014,WSAEFAULT: The lpProtocolInfo parameter is not in a valid part of the process address space.");
		break;
	}
	case WSAEINPROGRESS:
	{
		Log("WSASocketA Error 10036,WSAEINPROGRESS: A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.");
		break;
	}
	case WSAEINVAL:
	{
		Log("WSASocketA Error 10022,WSAEINVAL: https://msdn.microsoft.com/en-us/library/windows/desktop/ms742212(v=vs.85).aspx");
		break;
	}
	case WSAEINVALIDPROVIDER:
	{
		Log("WSASocketA Error 10105,WSAEINVALIDPROVIDER: The service provider returned a version other than 2.2.");
		break;
	}
	case WSAEINVALIDPROCTABLE:
	{
		Log("WSASocketA Error 10104,WSAEINVALIDPROCTABLE: The service provider returned an invalid or incomplete procedure table to the WSPStartup.");
		break;
	}
	case WSAEMFILE:
	{
		Log("WSASocketA Error 10024,WSAEMFILE: No more socket descriptors are available.");
		break;
	}
	case WSAENOBUFS:
	{
		Log("WSASocketA Error 10055,WSAENOBUFS: No buffer space is available. The socket cannot be created.");
		break;
	}
	case WSAEPROTONOSUPPORT:
	{
		Log("WSASocketA Error 10043,WSAEPROTONOSUPPORT: The specified protocol is not supported.");
		break;
	}
	case WSAEPROTOTYPE:
	{
		Log("WSASocketA Error 10041,WSAEPROTOTYPE: The specified protocol is the wrong type for this socket.");
		break;
	}
	case WSAEPROVIDERFAILEDINIT:
	{
		Log("WSASocketA Error 10106,WSAEPROVIDERFAILEDINIT: The service provider failed to initialize. This error is returned if a layered service provider (LSP) or namespace provider was improperly installed or the provider fails to operate correctly.");
		break;
	}
	case WSAESOCKTNOSUPPORT:
	{
		Log("WSASocketA Error 10044,WSAESOCKTNOSUPPORT: The specified socket type is not supported in this address family.");
		break;
	}
	default:
	{
		Log("WSASocketA Unknown Error: " + std::to_string(::WSAGetLastError()));
		break;
	}
	}
}

void WSAIoctl_error(std::function<void(std::string)> Log)
{
	switch (::WSAGetLastError())
	{
	case ERROR_IO_PENDING:
	{
		Log("WSAIoctl Error 997,ERROR_IO_PENDING: An overlapped operation was successfully initiated and completion will be indicated at a later time.");
		break;
	}
	case WSAENETDOWN:
	{
		Log("WSAIoctl Error 10050,WSAENETDOWN: The network subsystem has failed.");
		break;
	}
	case WSAEFAULT:
	{
		Log("WSAIoctl Error 10014,WSAEFAULT: The lpvInBuffer, lpvOutBuffer, lpcbBytesReturned, lpOverlapped, or lpCompletionRoutine parameter is not totally contained in a valid part of the user address space, or the cbInBuffer or cbOutBuffer parameter is too small.");
		break;
	}
	case WSAEINVAL:
	{
		Log("WSAIoctl Error 10022,WSAEINVAL: The dwIoControlCode parameter is not a valid command, or a specified input parameter is not acceptable, or the command is not applicable to the type of socket specified.");
		break;
	}
	case WSAEINPROGRESS:
	{
		Log("WSAIoctl Error 10036,WSAEINPROGRESS: The function is invoked when a callback is in progress.");
		break;
	}
	case WSAENOTSOCK:
	{
		Log("WSAIoctl Error 10038,WSAENOTSOCK: The descriptor s is not a socket.");
		break;
	}
	case WSAEOPNOTSUPP:
	{
		Log("WSAIoctl Error 10045,WSAEOPNOTSUPP: The specified IOCTL command cannot be realized. (For example, the FLOWSPEC structures specified in SIO_SET_QOS or SIO_SET_GROUP_QOS cannot be satisfied.)");
		break;
	}
	case WSAEWOULDBLOCK:
	{
		Log("WSAIoctl Error 10035,WSAEWOULDBLOCK: The socket is marked as non-blocking and the requested operation would block.");
		break;
	}
	case WSAENOPROTOOPT:
	{
		Log("WSAIoctl Error 10042,WSAENOPROTOOPT: The socket option is not supported on the specified protocol. For example, an attempt to use the SIO_GET_BROADCAST_ADDRESS IOCTL was made on an IPv6 socket or an attempt to use the TCP SIO_KEEPALIVE_VALS IOCTL was made on a datagram socket.");
		break;
	}
	default:
	{
		Log("WSAIoctl Unknown Error: " + std::to_string(::WSAGetLastError()));
		break;
	}
	}
}

void bind_error(std::function<void(std::string)> Log)
{
	switch (::WSAGetLastError())
	{
	case WSANOTINITIALISED:
	{
		Log("bind Error 10093,WSANOTINITIALISED: A successful WSAStartup call must occur before using this function.");
		break;
	}
	case WSAENETDOWN:
	{
		Log("bind Error 10050,WSAENETDOWN: The network subsystem has failed.");
		break;
	}
	case WSAEACCES:
	{
		Log("bind Error 10013,WSAEACCES: An attempt was made to access a socket in a way forbidden by its access permissions.");
		break;
	}
	case WSAEADDRINUSE:
	{
		Log("bind Error 10048,WSAEADDRINUSE: Only one usage of each socket address (protocol/network address/port) is normally permitted.");
		break;
	}
	case WSAEADDRNOTAVAIL:
	{
		Log("bind Error 10049,WSAEADDRNOTAVAIL: This error is returned if the specified address pointed to by the name parameter is not a valid local IP address on this computer.");
		break;
	}
	case WSAEFAULT:
	{
		Log("bind Error 10014,WSAEFAULT: This error is returned if the name parameter is NULL, the name or namelen parameter is not a valid part of the user address space, the namelen parameter is too small, the name parameter contains an incorrect address format for the associated address family, or the first two bytes of the memory block specified by name do not match the address family associated with the socket descriptor s.");
		break;
	}
	case WSAEINPROGRESS:
	{
		Log("bind Error 10036,WSAEINPROGRESS: A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.");
		break;
	}
	case WSAEINVAL:
	{
		Log("bind Error 10022,WSAEINVAL: This error is returned of the socket s is already bound to an address.");
		break;
	}
	case WSAENOBUFS:
	{
		Log("bind Error 10055,WSAENOBUFS: This error is returned of not enough buffers are available or there are too many connections.");
		break;
	}
	case WSAENOTSOCK:
	{
		Log("bind Error 10038,WSAENOTSOCK: This error is returned if the descriptor in the s parameter is not a socket.");
		break;
	}
	default:
	{
		Log("bind Unknown Error: " + std::to_string(::WSAGetLastError()));
		break;
	}
	}
}

void closesocket_error(std::function<void(std::string)> Log)
{
	switch (::WSAGetLastError())
	{
	case WSANOTINITIALISED:
	{
		Log("closesocket Error 10093,WSANOTINITIALISED: A successful WSAStartup call must occur before using this function.");
		break;
	}
	case WSAENETDOWN:
	{
		Log("closesocket Error 10050,WSAENETDOWN: The network subsystem has failed.");
		break;
	}
	case WSAENOTSOCK:
	{
		Log("closesocket Error 10038,WSAENOTSOCK: The descriptor is not a socket.");
		break;
	}
	case WSAEINPROGRESS:
	{
		Log("closesocket Error 10036,WSAEINPROGRESS: A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.");
		break;
	}
	case WSAEINTR:
	{
		Log("closesocket Error 10004,WSAEINTR: The (blocking) Windows Socket 1.1 call was canceled through WSACancelBlockingCall.");
		break;
	}
	case WSAEWOULDBLOCK:
	{
		Log("closesocket Error 10035,WSAEWOULDBLOCK: The socket is marked as nonblocking, but the l_onoff member of the linger structure is set to nonzero and the l_linger member of the linger structure is set to a nonzero timeout value.");
		break;
	}
	default:
		Log("closesocket Unknown Error: " + std::to_string(::WSAGetLastError()));
		break;
	}
}

void setsockopt_error(std::function<void(std::string)> Log)
{
	switch (::WSAGetLastError())
	{
	case WSANOTINITIALISED:
	{
		Log("setsockopt Error 10093,WSANOTINITIALISED: A successful WSAStartup call must occur before using this function.");
		break;
	}
	case WSAENETDOWN:
	{
		Log("setsockopt Error 10050,WSAENETDOWN: The network subsystem has failed.");
		break;
	}
	case WSAEFAULT:
	{
		Log("setsockopt Error 10014,WSAEFAULT: The buffer pointed to by the optval parameter is not in a valid part of the process address space or the optlen parameter is too small.");
		break;
	}
	case WSAEINPROGRESS:
	{
		Log("setsockopt Error 10036,WSAEINPROGRESS: A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.");
		break;
	}
	case WSAEINVAL:
	{
		Log("setsockopt Error 10022,WSAEINVAL: The level parameter is not valid, or the information in the buffer pointed to by the optval parameter is not valid.");
		break;
	}
	case WSAENETRESET:
	{
		Log("setsockopt Error 10052,WSAENETRESET: The connection has timed out when SO_KEEPALIVE is set.");
		break;
	}
	case WSAENOPROTOOPT:
	{
		Log("setsockopt Error 10042,WSAENOPROTOOPT: The option is unknown or unsupported for the specified provider or socket (see SO_GROUP_PRIORITY limitations).");
		break;
	}
	case WSAENOTCONN:
	{
		Log("setsockopt Error 10057,WSAENOTCONN: The connection has been reset when SO_KEEPALIVE is set.");
		break;
	}
	case WSAENOTSOCK:
	{
		Log("setsockopt Error 10038,WSAENOTSOCK: The descriptor is not a socket.");
		break;
	}
	default:
	{
		Log("setsockopt Unknown Error: " + std::to_string(::WSAGetLastError()));
		break;
	}
	}
}

bool connectEx_error(std::function<void(std::string)> Log, bool& sentConnect)
{
	int err(::WSAGetLastError());
	switch (err)
	{
	case ERROR_IO_PENDING:
	{
		// Not an error
		sentConnect = true;
		return true;
		break;
	}
	case WSANOTINITIALISED:
	{
		Log("ConnectEx Error 10093,WSANOTINITIALISED: A successful WSAStartup function call must occur before using ConnectEx.");
		sentConnect = false;
		return false;
		break;
	}
	case WSAENETDOWN:
	{
		Log("ConnectEx Error 10050,WSAENETDOWN: The network subsystem has failed.");
		sentConnect = false;
		return false;
		break;
	}
	case WSAEADDRINUSE:
	{
		Log("ConnectEx Error 10048,WSAEADDRINUSE: The local address of the socket is already in use, and the socket was not marked to allow address reuse with SO_REUSEADDR. This error usually occurs during a bind operation, but the error could be delayed until a ConnectEx function call, if the bind function was called with a wildcard address (INADDR_ANY or in6addr_any) specified for the local IP address. A specific IP address needs to be implicitly bound by theConnectEx function.");
		sentConnect = false;
		return false;
		break;
	}
	case WSAEALREADY:
	{
		Log("ConnectEx Error 10037,WSAEALREADY: A nonblocking connect, WSAConnect, or ConnectEx function call is in progress on the specified socket.");
		return true;
		break;
	}
	case WSAEADDRNOTAVAIL:
	{
		Log("ConnectEx Error 10049,WSAEADDRNOTAVAIL: The remote address is not a valid address, such as ADDR_ANY (the ConnectEx function is only supported for connection-oriented sockets).");
		sentConnect = false;
		return false;
		break;
	}
	case WSAEAFNOSUPPORT:
	{
		Log("ConnectEx Error 10047,WSAEAFNOSUPPORT: Addresses in the specified family cannot be used with this socket.");
		sentConnect = false;
		return false;
		break;
	}
	case WSAECONNREFUSED:
	{
		Log("ConnectEx Error 10061,WSAECONNREFUSED: The attempt to connect was rejected.");
		sentConnect = false;
		return false;
		break;
	}
	case WSAEFAULT:
	{
		Log("ConnectEx Error 10014,WSAEFAULT: The name, lpSendBuffer, or lpOverlapped parameter is not a valid part of the user address space, or namelen is too small.");
		sentConnect = false;
		return false;
		break;
	}
	case WSAEINVAL:
	{
		Log("ConnectEx Error 10022,WSAEINVAL: The parameter s is an unbound or a listening socket.");
		sentConnect = false;
		return false;
		break;
	}
	case WSAEISCONN:
	{
		Log("ConnectEx Error 10056,WSAEISCONN: The socket is already connected.");
		sentConnect = false;
		return true;
		break;
	}
	case WSAENETUNREACH:
	{
		Log("ConnectEx Error 10051,WSAENETUNREACH: The network cannot be reached from this host at this time.");
		sentConnect = false;
		return false;
		break;
	}
	case WSAEHOSTUNREACH:
	{
		Log("ConnectEx Error 10065,WSAEHOSTUNREACH: A socket operation was attempted to an unreachable host.");
		sentConnect = false;
		return false;
		break;
	}
	case WSAENOBUFS:
	{
		Log("ConnectEx Error 10055,WSAENOBUFS: No buffer space is available; the socket cannot be connected.");
		sentConnect = false;
		return false;
		break;
	}
	case WSAENOTSOCK:
	{
		Log("ConnectEx Error 10038,WSAENOTSOCK: The descriptor is not a socket.");
		sentConnect = false;
		return false;
		break;
	}
	case WSAETIMEDOUT:
	{
		Log("ConnectEx Error 10060,WSAETIMEDOUT: The attempt to connect timed out without establishing a connection.");
		sentConnect = false;
		return false;
		break;
	}
	default:
	{
		Log("ConnectEx Unknown Error: " + std::to_string(err));
		sentConnect = false;
		return false;
		break;
	}
	}
}

void getsockopt_error(std::function<void(std::string)> Log)
{
	switch (::WSAGetLastError())
	{
	case WSANOTINITIALISED:
	{
		Log("getsockopt Error 10093,WSANOTINITIALISED: A successful WSAStartup call must occur before using this function.");
		break;
	}
	case WSAENETDOWN:
	{
		Log("getsockopt Error 10050,WSAENETDOWN: The network subsystem has failed.");
		break;
	}
	case WSAEFAULT:
	{
		Log("getsockopt Error 10014,WSAEFAULT: One of the optval or the optlen parameters is not a valid part of the user address space, or the optlen parameter is too small.");
		break;
	}
	case WSAEINPROGRESS:
	{
		Log("getsockopt Error 10036,WSAEINPROGRESS: A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.");
		break;
	}
	case WSAEINVAL:
	{
		Log("getsockopt Error 10022,WSAEINVAL: The level parameter is unknown or invalid.");
		break;
	}
	case WSAENOPROTOOPT:
	{
		Log("getsockopt Error 10042,WSAENOPROTOOPT: The option is unknown or unsupported by the indicated protocol family.");
		break;
	}
	case WSAENOTSOCK:
	{
		Log("getsockopt Error 10038,WSAENOTSOCK: The descriptor is not a socket.");
		break;
	}
	default:
	{
		Log("getsockopt Unknown Error: " + std::to_string(::WSAGetLastError()));
		break;
	}
	}
}

void socketshutdown_error(std::function<void(std::string)> Log)
{
	switch (::WSAGetLastError())
	{
	case WSAECONNABORTED:
	{
		Log("Socket Shutdown Error 10053,WSAECONNABORTED: The virtual circuit was terminated due to a time-out or other failure. The application should close the socket as it is no longer usable.");
		break;
	}
	case WSAECONNRESET:
	{
		Log("Socket Shutdown Error 10054,WSAECONNRESET: The virtual circuit was reset by the remote side executing a hard or abortive close. The application should close the socket as it is no longer usable.");
		break;
	}
	case WSAEINPROGRESS:
	{
		Log("Socket Shutdown Error 10036,WSAEINPROGRESS: A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.");
		break;
	}
	case WSAEINVAL:
	{
		Log("Socket Shutdown Error 10022,WSAEINVAL: The how parameter is not valid, or is not consistent with the socket type. For example, SD_SEND is used with a UNI_RECV socket type.");
		break;
	}
	case WSAENETDOWN:
	{
		Log("Socket Shutdown Error 10050,WSAENETDOWN: The network subsystem has failed.");
		break;
	}
	case WSAENOTCONN:
	{
		Log("Socket Shutdown Error 10057,WSAENOTCONN: The socket is not connected. This error applies only to a connection-oriented socket.");
		break;
	}
	case WSAENOTSOCK:
	{
		Log("Socket Shutdown Error 10038,WSAENOTSOCK: The descriptor is not a socket.");
		break;
	}
	case WSANOTINITIALISED:
	{
		Log("Socket Shutdown Error 10093,WSANOTINITIALISED: A successful WSAStartup call must occur before using this function.");
		break;
	}
	default:
	{
		Log("Socket Shutdown Unknown Error: " + std::to_string(::WSAGetLastError()));
		break;
	}
	}
}