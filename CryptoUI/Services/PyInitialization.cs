using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoUI.Services
{
    public delegate void Action<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10, in T11, in T12, in T13, in T14, in T15, in T16, in T17, in T18, in T19, in T20, in T21, in T22, in T23, in T24, in T25, in T26, in T27, in T28, in T29, in T30, in T31, in T32, in T33, in T34, in T35, in T36, in T37, in T38, in T39, in T40, in T41, in T42, in T43, in T44, in T45, in T46>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, T17 arg17, T18 arg18, T19 arg19, T20 arg20, T21 arg21, T22 arg22, T23 arg23, T24 arg24, T25 arg25, T26 arg26, T27 arg27, T28 arg28, T29 arg29, T30 arg30, T31 arg31, T32 arg32, T33 arg33, T34 arg34, T35 arg35, T36 arg36, T37 arg37, T38 arg38, T39 arg39, T40 arg40, T41 arg41, T42 arg42, T43 arg43, T44 arg44, T45 arg45, T46 arg46);
    // https://github.com/IronLanguages/ironpython2/releases/tag/ipy-2.7.8
    public class PyInitialization
    {
        public static void Attach(dynamic scope, Splash splash)
        {
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            scope.today_est = new Func<uint>(() =>
            {
                var timeUtc = DateTime.UtcNow;
                DateTime easternTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, easternZone);
                return ((uint)easternTime.Year) * 10000 + ((uint)easternTime.Month) * 100 + ((uint)easternTime.Day);
            });
            scope.splash_log = new Action<string>((msg) => { splash.Update(msg); });
            AttachNicConfigService(scope);
            AttachTcpClientConfigService(scope);
            AttachTcpServerConfig(scope);
            AttachExchangeDefinitionConfigService(scope);
            AttachParamClientConfigService(scope);
            AttachManualOrderClientConfigService(scope);
            AttachUniqueInstrumentIdConfigService(scope);
            AttachSymbolGroupConfig(scope);
        }
        private static void AttachNicConfigService(dynamic scope)
        {
            scope.add_nic_config = new Action<ulong, ulong, string, string>((id, host_id, ip, mac) => NicConfigService.Add(new NicInfo(id, host_id, ip, mac)));
        }
        private static void AttachTcpClientConfigService(dynamic scope)
        {
            scope.add_tcp_client_config = new Action<ulong, string, ushort, ulong>((id, ip, port, nic_id) => TcpClientConfigService.Add(new TcpClientConfig(id, ip, port, nic_id)));
        }
        private static void AttachTcpServerConfig(dynamic scope)
        {
            scope.create_tcp_server_config = new Func<ulong, ulong, ushort, ulong, TcpServerConfig>((server_id, instance_id, port, nic_id) => new TcpServerConfig(server_id, instance_id, port, nic_id));
            scope.add_tcp_server_config = new Action<TcpServerConfig>(config => TcpServerConfigService.Add(config));
        }
        private static void AttachExchangeDefinitionConfigService(dynamic scope)
        {
            scope.add_exchange_definition_config = new Action<ulong, string, string, string>((exchange_id, exchange_name, family_name, letter_code) => ExchangeDefinitionConfigService.Add(new ExchangeDefinitionConfig(exchange_id, exchange_name, family_name, letter_code)));
        }
        private static void AttachParamClientConfigService(dynamic scope)
        {
            scope.add_param_client_config = new Action<ulong, ulong>((id, tcp_client_id) => ParamClientConfigService.Add(new ParamClientConfig(id, tcp_client_id)));
        }
        private static void AttachManualOrderClientConfigService(dynamic scope)
        {
            scope.add_manual_order_client_config = new Action<ulong, ulong, uint>((id, tcp_client_id, starting_clordid) => ManualOrderClientConfigService.Add(new ManualOrderClientConfig(id, tcp_client_id, starting_clordid)));
        }
        private static void AttachUniqueInstrumentIdConfigService(dynamic scope)
        {
            scope.add_unique_instrument_id_config = new Action<ulong, ulong>((instrument_id, unique_instrument_id) => UniqueInstrumentIdConfigService.Add(new UniqueInstrumentIdConfig(instrument_id, unique_instrument_id)));
        }
        private static void AttachSymbolGroupConfig(dynamic scope)
        {
            scope.add_instrument_id_symbol_config = new Action<ulong, string>((basket_id, symbol) => InstrumentIdSymbolConfigService.Add(new InstrumentIdSymbolConfig(basket_id, symbol)));
        }
    }
}
