using System;
using System.Runtime.InteropServices;

namespace CryptoUI.Network
{
    public static class HighResTime
    {
        public static bool IsAvailable { get; private set; }

        [DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        private static extern void GetSystemTimePreciseAsFileTime(out long filetime);

        public static DateTime UtcNow
        {
            get
            {
                if (!IsAvailable)
                {
                    Logger.Log(Logger.Level.critical, "HighResTime Is not available on your version of Windows!");
                    throw new InvalidOperationException(
                        "High resolution clock isn't available.");
                }

                long filetime;
                GetSystemTimePreciseAsFileTime(out filetime);
                return DateTime.FromFileTimeUtc(filetime);
            }
        }
        public static ulong UtcNowN
        {
            get
            {
                if (!IsAvailable)
                {
                    Logger.Log(Logger.Level.critical, "HighResTime Is not available on your version of Windows!");
                    throw new InvalidOperationException(
                        "High resolution clock isn't available.");
                }
                long filetime;
                GetSystemTimePreciseAsFileTime(out filetime);
                ulong ftm = (ulong)filetime;
                return ftm - 116444736000000000UL;
            }
        }

        static HighResTime()
        {
            try
            {
                long filetime;
                GetSystemTimePreciseAsFileTime(out filetime);
                IsAvailable = true;
            }
            catch (EntryPointNotFoundException)
            {
                // Not running Windows 8 or higher.
                IsAvailable = false;
            }
        }
    }
}