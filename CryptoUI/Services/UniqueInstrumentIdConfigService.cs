using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoUI.Services
{
    public class UniqueInstrumentIdConfigService
    {
        private static Dictionary<ulong, UniqueInstrumentIdConfig> map = new Dictionary<ulong, UniqueInstrumentIdConfig>();
        private static Dictionary<ulong, UniqueInstrumentIdConfig> map2 = new Dictionary<ulong, UniqueInstrumentIdConfig>();
        public static ulong GetUniqueInstrumentId(ulong id)
        {
            if (!map.TryGetValue(id, out UniqueInstrumentIdConfig conf))
                throw new Exception($"UniqueInstrumentIdConfigService Failed to get UniqueInstrumentId for {id}");
            return conf.unique_instrument_id;
        }
        public static ulong GetInstrumentId(ulong id)
        {
            if (!map2.TryGetValue(id, out UniqueInstrumentIdConfig conf))
                throw new Exception($"UniqueInstrumentIdConfigService Failed to get InstrumentId for {id}");
            return conf.instrument_id;
        }

        public static bool DoesUniqueInstrumentIdExist(ulong id)
        {
            if (!map2.TryGetValue(id, out UniqueInstrumentIdConfig conf))
                return false;
            return true;
        }
        public static bool DoesInstrumentIdExist(ulong id)
        {
            if (!map.TryGetValue(id, out UniqueInstrumentIdConfig conf))
                return false;
            return true;
        }

        public static void Add(UniqueInstrumentIdConfig conf)
        {
            try
            {
                map.Add(conf.instrument_id, conf);
            }
            catch (Exception e)
            {
                Network.Logger.Log(Network.Logger.Level.info, $"UID error: inst not unique, inst: {conf.instrument_id} uid: {conf.unique_instrument_id} {e}");
                throw e;
            }
            try
            {
                map2.Add(conf.unique_instrument_id, conf);
            }
            catch (Exception e)
            {
                Network.Logger.Log(Network.Logger.Level.info, $"UID error: uid not unique, inst: {conf.instrument_id} uid: {conf.unique_instrument_id} {e}");
                throw e;
            }
        }

        public static UniqueInstrumentIdConfig GetByInstrumentId(ulong id)
        {
            if (!map.TryGetValue(id, out UniqueInstrumentIdConfig conf))
                throw new Exception($"UniqueInstrumentIdConfigService Failed to get UniqueInstrumentIdConfig for {id}");
            return conf;
        }
        public static UniqueInstrumentIdConfig GetByUniqueInstrumentId(ulong id)
        {
            if (!map2.TryGetValue(id, out UniqueInstrumentIdConfig conf))
                throw new Exception($"UniqueInstrumentIdConfigService Failed to get UniqueInstrumentIdConfig for {id}");
            return conf;
        }
        public static UniqueInstrumentIdConfig[] AllConfigs()
        {
            return map.Values.ToArray();
        }
    }
}
