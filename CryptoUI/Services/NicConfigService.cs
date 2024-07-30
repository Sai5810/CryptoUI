using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoUI.Services
{
    public class NicConfigService
    {
        private static Dictionary<ulong, NicInfo> map = new Dictionary<ulong, NicInfo>();
        private static Dictionary<ulong, Dictionary<ulong, NicInfo>> global_map = new Dictionary<ulong, Dictionary<ulong, NicInfo>>();

        public static string GetIP(ulong nicId)
        {
            if (!map.TryGetValue(nicId, out NicInfo info))
                throw new Exception($"NicConfigService Failed to get IP for {nicId}");
            return info.ip;
        }

        public static string GetMac(ulong nicId)
        {
            if (!map.TryGetValue(nicId, out NicInfo info))
                throw new Exception($"NicConfigService Failed to get MAC for {nicId}");
            return info.mac;
        }
        public static string GetIP(ulong host_id, ulong nic_id)
        {
            if (!global_map.TryGetValue(host_id, out Dictionary<ulong, NicInfo> m1))
                throw new Exception($"NicConfigService Failed to get IP for {host_id} {nic_id}");
            if (!m1.TryGetValue(host_id, out NicInfo info))
                throw new Exception($"NicConfigService Failed to get IP for {host_id} {nic_id}");
            return info.ip;
        }

        public static string GetMac(ulong host_id, ulong nic_id)
        {
            if (!global_map.TryGetValue(host_id, out Dictionary<ulong, NicInfo> m1))
                throw new Exception($"NicConfigService Failed to get MAC for {host_id} {nic_id}");
            if (!m1.TryGetValue(host_id, out NicInfo info))
                throw new Exception($"NicConfigService Failed to get MAC for {host_id} {nic_id}");
            return info.mac;
        }
        public static void Add(NicInfo info)
        {
            map.Add(info.nic_id, info);
            Dictionary<ulong, NicInfo> d = new Dictionary<ulong, NicInfo>();
            d.Add(info.nic_id, info);
            global_map.Add(info.host_id, d);
        }
    }
}
