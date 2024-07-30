using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoUI.Services
{
    public class ExchangeDefinitionConfigService
    {
        private static Dictionary<ulong, ExchangeDefinitionConfig> map = new Dictionary<ulong, ExchangeDefinitionConfig>();
        private static Dictionary<string, ulong> map2 = new Dictionary<string, ulong>();

        public static bool Exists(ulong id)
        {
            return map.ContainsKey(id); ;
        }

        public static bool ExistsText(string exchange_name, bool is_equities)
        {
            if (!Exists(exchange_name))
            {
                if (is_equities)
                {
                    if (!Exists(exchange_name + " Equities"))
                    {
                        if (!Exists("NYSE " + exchange_name))
                        {
                            if (!Exists("NYSE " + exchange_name + " Equities"))
                            {
                                return false;
                            }
                            else
                                return true;
                        }
                        else
                            return true;
                    }
                    else
                        return true;
                }
                return false;
            }
            else
                return true;
        }
        public static bool Exists(string exchange_name)
        {
            return map2.ContainsKey(exchange_name);
        }

        public static ulong GetIdText(string exchange_name, bool is_equities)
        {
            if (!Exists(exchange_name))
            {
                if (is_equities)
                {
                    if (!Exists(exchange_name + " Equities"))
                    {
                        if (!Exists("NYSE " + exchange_name))
                        {
                            if (!Exists("NYSE " + exchange_name + " Equities"))
                            {
                                return 0;
                            }
                            else
                                return GetId("NYSE " + exchange_name + " Equities");
                        }
                        else
                            return GetId("NYSE " + exchange_name);
                    }
                    else
                        return GetId(exchange_name + " Equities");
                }
                return 0;
            }
            else
                return GetId(exchange_name);
        }
        public static ulong GetId(string exchange_name)
        {
            return map2[exchange_name];
        }

        public static string GetExchange(ulong id)
        {
            if (!map.TryGetValue(id, out ExchangeDefinitionConfig conf))
                throw new Exception($"ExchangeDefinitionConfigService Failed to get Exchange for {id}");
            return conf.exchange;
        }

        public static string GetFamily(ulong id)
        {
            if (!map.TryGetValue(id, out ExchangeDefinitionConfig conf))
                throw new Exception($"ExchangeDefinitionConfigService Failed to get Family for {id}");
            return conf.family;
        }

        public static string GetLetterCode(ulong id)
        {
            if (!map.TryGetValue(id, out ExchangeDefinitionConfig conf))
                throw new Exception($"ExchangeDefinitionConfigService Failed to get LetterCode for {id}");
            return conf.letter_code;
        }

        public static void Add(ExchangeDefinitionConfig conf)
        {
            map.Add(conf.id, conf);
            map2.Add(conf.exchange, conf.id);
        }

        public static ExchangeDefinitionConfig[] AllExchanges()
        {
            return map.Values.ToArray();
        }
    }
}
