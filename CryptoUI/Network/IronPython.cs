using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using CryptoUI.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;

namespace CryptoUI.Network
{
    public class IronPythonConfiguration
    {
        public static void run(Splash splash)
        {
            string m_exePath = Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).FullName).FullName;
            string pyPath = m_exePath + "\\" + "py_setup.py";
            ScriptEngine engine = Python.CreateEngine();
            dynamic scope = engine.CreateScope();
            ICollection<string> paths = engine.GetSearchPaths();
            paths.Add(Path.GetDirectoryName(@"C:\ironpython\__future__.py"));
            engine.SetSearchPaths(paths);
            scope.log = new Action<string>((s) => { Logger.Log(Logger.Level.info, s); });
            scope.rootpath = m_exePath;
            scope.resolve_ip = new Func<string, string>((s) => Dns.GetHostAddresses(s)[0].ToString());
            PyInitialization.Attach(scope, splash);
            engine.ExecuteFile(pyPath, scope);
            dynamic initializeFunction = scope.GetVariable("initialize");
            try
            {
                var result = initializeFunction();
                Logger.Log(Logger.Level.info, $"result {result}");
            }
            catch (Exception ex)
            {
                string exStr = engine.GetService<ExceptionOperations>().FormatException(ex);
                Logger.Log(Logger.Level.error, exStr);
            }
        }
    }
}
