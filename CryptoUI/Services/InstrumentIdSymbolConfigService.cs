using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoUI.Services
{
    public class InstrumentIdSymbolConfigService
    {
        private static Dictionary<ulong, InstrumentIdSymbolConfig> map = new Dictionary<ulong, InstrumentIdSymbolConfig>();
        private static Dictionary<string, InstrumentIdSymbolConfig> rmap = new Dictionary<string, InstrumentIdSymbolConfig>();
        public static InstrumentIdSymbolConfig Get(ulong id)
        {
            if (!map.TryGetValue(id, out InstrumentIdSymbolConfig conf))
                throw new Exception($"InstrumentIdSymbolConfigService Failed to get for {id}");
            return conf;
        }
        public static string GetSymbol(ulong id)
        {
            if (!map.TryGetValue(id, out InstrumentIdSymbolConfig conf))
                throw new Exception($"InstrumentIdSymbolConfigService Failed to get symbol for {id}");
            return conf.symbol;
        }
        public static bool Exists(ulong id)
        {
            if (!map.ContainsKey(id))
                return false;
            return true;
        }
        public static InstrumentIdSymbolConfig Get(string symbol)
        {
            if (!rmap.TryGetValue(symbol, out InstrumentIdSymbolConfig conf))
                throw new Exception($"InstrumentIdSymbolConfigService Failed to get for {symbol}");
            return conf;
        }
        public static ulong GetId(string symbol)
        {
            if (!rmap.TryGetValue(symbol, out InstrumentIdSymbolConfig conf))
                throw new Exception($"InstrumentIdSymbolConfigService Failed to get id for {symbol}");
            return conf.instrument_id;
        }
        public static bool Exists(string symbol)
        {
            if (!rmap.ContainsKey(symbol))
                return false;
            return true;
        }
        public static void Add(InstrumentIdSymbolConfig conf)
        {
            map.Add(conf.instrument_id, conf);
            rmap.Add(conf.symbol, conf);
        }
        public static InstrumentIdSymbolConfig[] AllInstruments()
        {
            return map.Values.ToArray();
        }
    }
}
