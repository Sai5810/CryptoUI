#pragma once

#include <cstdint>

namespace Native
{
	uint64_t now()
	{
		FILETIME ft;
		::GetSystemTimePreciseAsFileTime(&ft);
		uint64_t l(static_cast<uint64_t>(ft.dwHighDateTime) << 32 | ft.dwLowDateTime);
		return l * 100 - 11644473600000000000ULL;
	}
}

namespace TradeCore
{
	public ref class BoolHolder
	{
	public:
		bool get_value()
		{
			return val;
		}
		void set_value(bool v)
		{
			val = v;
		}
		property bool Value
		{
			bool get()
			{
				return val;
			}
			void set(bool value)
			{
				val = value;
			}
		}
	private:
		bool val;
	};
	std::string to_string(System::String^ s)
	{
		std::string out_str;
		const char* chars = (const char*)(System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(s)).ToPointer();
		out_str = chars;
		System::Runtime::InteropServices::Marshal::FreeHGlobal(System::IntPtr((void*)chars));
		return out_str;
	}
	public delegate void LogDelegate(std::string);
	public delegate void OnAddDelegate();
	public delegate void OnRemoveDelegate();
	public delegate size_t HandlePktDelegate(const uint8_t*, const size_t, uint64_t, void*, bool&);
}