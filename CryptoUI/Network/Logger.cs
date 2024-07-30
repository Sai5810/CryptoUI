using System;
using System.IO;
using System.Reflection;

namespace CryptoUI.Network
{
    // Use PowerShell navigate to CryptoUI Project Folder
    // Get-Content -Path "ui.log" -Wait
    public static class Logger
    {
        public enum Level
        {
            critical = 0,
            error = 1,
            warning = 2,
            info = 3,
            debug = 4
        }

        private static string m_exePath = string.Empty;
        public static void Log(Level level, string logMessage)
        {
            m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (!File.Exists(m_exePath + "\\" + "ui.log"))
                File.Create(m_exePath + "\\" + "ui.log");

            try
            {
                using (StreamWriter w = File.AppendText(m_exePath + "\\" + "ui.log"))
                    AppendLog(level, logMessage, w);
            }
            catch (Exception ex)
            {
                if (typeof(System.IO.IOException).IsInstanceOfType(ex))
                {
                    if (!ex.Message.Contains("because it is being used by another process."))
                        Console.WriteLine(ex.Message);
                }
                else
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void AppendLog(Level level, string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.WriteLine("[{0}] [{1}] {2}", level.ToString(), DateTime.Now.ToShortTimeString(), logMessage);
            }
            catch (Exception)
            {
            }
        }
    }
}
