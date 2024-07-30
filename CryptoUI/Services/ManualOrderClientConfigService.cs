using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoUI.Services
{
    public class ManualOrderClientConfigService
    {
        private static Dictionary<ulong, ManualOrderClientConfig> map = new Dictionary<ulong, ManualOrderClientConfig>();

        public static void Add(ManualOrderClientConfig conf)
        {
            map.Add(conf.id, conf);
        }
        public static ManualOrderClientConfig Get(ulong id)
        {
            if (!map.TryGetValue(id, out ManualOrderClientConfig conf))
                throw new Exception($"ManualOrderClientConfigService Failed to get ManualOrderClientConfig for {id}");
            return conf;
        }
        public static ManualOrderClientConfig[] AllManualOrderClients()
        {
            return map.Values.ToArray();
        }
    }
}
