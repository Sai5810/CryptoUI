using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoUI.Services
{
    public class ParamClientConfigService
    {
        private static Dictionary<ulong, ParamClientConfig> map = new Dictionary<ulong, ParamClientConfig>();

        public static void Add(ParamClientConfig conf)
        {
            map.Add(conf.id, conf);
        }
        public static ParamClientConfig Get(ulong id)
        {
            if (!map.TryGetValue(id, out ParamClientConfig conf))
                throw new Exception($"ParamClientConfigService Failed to get ParamClientConfig for {id}");
            return conf;
        }
        public static ParamClientConfig[] AllParamClients()
        {
            return map.Values.ToArray();
        }
    }
}
