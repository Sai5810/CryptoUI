using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoUI.Services
{
    public class TcpClientConfigService
    {
        private static Dictionary<ulong, TcpClientConfig> map = new Dictionary<ulong, TcpClientConfig>();
        public static string GetIP(ulong id)
        {
            if (!map.TryGetValue(id, out TcpClientConfig conf))
                throw new Exception($"TcpClientConfigService Failed to get IP for {id}");
            return conf.ip;
        }

        public static ushort GetPort(ulong id)
        {
            if (!map.TryGetValue(id, out TcpClientConfig conf))
                throw new Exception($"TcpClientConfigService Failed to get Port for {id}");
            return conf.port;
        }
        public static ulong GetNicId(ulong id)
        {
            if (!map.TryGetValue(id, out TcpClientConfig conf))
                throw new Exception($"TcpClientConfigService Failed to get NicId for {id}");
            return conf.nic_id;
        }

        public static void Add(TcpClientConfig conf)
        {
            map.Add(conf.id, conf);
        }

        public static TcpClientConfig Get(ulong id)
        {
            if (!map.TryGetValue(id, out TcpClientConfig conf))
                throw new Exception($"TcpClientConfigService Failed to get TcpClientConfig for {id}");
            return conf;
        }
        public static TcpClientConfig[] AllConnections()
        {
            return map.Values.ToArray();
        }
    }
}
