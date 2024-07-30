#pragma once

#pragma comment(lib, "ws2_32.lib")
#pragma comment(lib, "Shlwapi.lib")
#define WIN32_LEAN_AND_MEAN
#define NOMINMAX
#define _WINSOCK_DEPRECATED_NO_WARNINGS
#include <winsock2.h>
#include <Ws2tcpip.h>
#include <Ws2ipdef.h>
#include <mswsock.h>
#include <Windows.h>
#include <process.h>
#include "Shlwapi.h"
#include <Shlobj.h>
#include <Mswsockdef.h>