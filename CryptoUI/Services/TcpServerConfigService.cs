using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoUI.Services
{
    public class TcpServerConfigService
    {
        private static Dictionary<ulong, Dictionary<ulong, TcpServerConfig>> map = new Dictionary<ulong, Dictionary<ulong, TcpServerConfig>>();
        public static TcpServerConfig Get(ulong instance_id, ulong id)
        {
            if (!map.TryGetValue(instance_id, out Dictionary<ulong, TcpServerConfig> m1))
                throw new Exception($"TcpServerConfigService Failed to get for {instance_id}");
            if (!m1.TryGetValue(id, out TcpServerConfig conf))
                throw new Exception($"TcpServerConfigService Failed to get for {instance_id} {id}");
            return conf;
        }
        public static void Add(TcpServerConfig conf)
        {
            if (map.ContainsKey(conf.instance_id))
            {
                map[conf.instance_id].Add(conf.id, conf);
            }
            else
            {
                Dictionary<ulong, TcpServerConfig> d = new Dictionary<ulong, TcpServerConfig>();
                d.Add(conf.id, conf);
                map.Add(conf.instance_id, d);
            }
        }
    }
}
