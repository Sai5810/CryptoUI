using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoUI.Protocol;
using System.Net.NetworkInformation;
using CryptoUI.Network;

using TradeCore;
using CryptoUI.Protocol.PositionServerN;
using CryptoUI.Protocol.manual_order_protocolN;

namespace CryptoUI.Network
{
    class EventManager : IEventHandler
    {
        private List<ParamServerHandler> paramServers = new List<ParamServerHandler>();
        private List<ManualOrderHandler> manualOrderServers = new List<ManualOrderHandler>();
        private List<TcpClient<ParamServerHandler>> paramserverNetworks = new List<TcpClient<ParamServerHandler>>();
        private List<TcpClient<ManualOrderHandler>> manaualOrderNetworks = new List<TcpClient<ManualOrderHandler>>();
        private App raven;
        private ParamRouter paramRouter;
        private TradeCore.EventManager em;
        public System.Net.IPAddress GetNic()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if ((nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet || nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                    && nic.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (System.Net.IPAddress addr in nic.GetIPProperties().UnicastAddresses.Select((a) => { return a.Address; }))
                    {
                        if (addr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork && !nic.Name.Contains("Loopback") && !nic.Name.Contains("VMware") && !nic.Name.Contains("Tunnel") && !nic.Name.Contains("Virtual"))
                        {
                            Logger.Log(Logger.Level.info, "Connecting to Controller with " + nic.Name + " " + nic.Description);
                            return addr;
                        }
                    }
                }
            }
            return null;
        }

        public ulong now()
        {
            return em.now();
        }
        ~EventManager()
        {
            TradeCore.TcpClient.release_networking();
        }
        public EventManager(App raven)
        {
            TradeCore.TcpClient.init_networking();
            this.raven = raven;
            Action<string> logger_fn = (string line) => { Logger.Log(Logger.Level.warning, line); };
            this.em = new TradeCore.EventManager(logger_fn);
            this.paramRouter = new ParamRouter(this.raven, this);
            System.Net.IPAddress nic = GetNic();
            foreach (Services.ParamClientConfig conf in Services.ParamClientConfigService.AllParamClients())
            {
                var s = new ParamServerHandler(this);
                paramServers.Add(s);
                var t = Services.TcpClientConfigService.Get(conf.tcp_client_id);
                Logger.Log(Logger.Level.info, $"Connecting to {t.ip}:{t.port}");
                paramserverNetworks.Add(new TcpClient<ParamServerHandler>(s, em, nic.ToString(), t.ip, t.port, 3, 120));
            }
            uint idx = 0;
            foreach (Services.ManualOrderClientConfig conf in Services.ManualOrderClientConfigService.AllManualOrderClients())
            {
                var s = new ManualOrderHandler(this, conf.starting_clordid, idx);
                manualOrderServers.Add(s);
                var t = Services.TcpClientConfigService.Get(conf.tcp_client_id);
                Logger.Log(Logger.Level.info, $"Connecting to {t.ip}:{t.port}");
                manaualOrderNetworks.Add(new TcpClient<ManualOrderHandler>(s, em, nic.ToString(), t.ip, t.port, 3, 120));
                idx++;
            }
        }

        public void Start()
        {
            Task t = new Task(() =>
            {
                foreach (var s in paramserverNetworks)
                {
                    bool b = s.Start();
                }
                foreach (var s in manaualOrderNetworks)
                {
                    bool b = s.Start();
                }
                while (true)
                {
                    em.poll();
                }
            });
            t.Start();
        }

        public void setParamManager()
        {
            this.paramRouter.setParamManager();
        }

        public override bool publishParam(Protocol.ParamServerN.ParamChangeMsgT msg)
        {
            if (paramServers.Count <= 0)
                return false;
            return paramServers[0].publishParam(msg);
        }
        public override bool publishSubscribe(ulong id)
        {
            if (paramServers.Count <= 0)
                return false;
            return paramServers[0].publishSubscribe(id);
        }
        public override bool publishUnsubscribe(ulong id)
        {
            if (paramServers.Count <= 0)
                return false;
            return paramServers[0].publishUnsubscribe(id);
        }

        public override void onParamServerConnect()
        {
            paramRouter.onConnect();
            raven.onParamServerConnect();
        }

        public override void onParamDisconnect()
        {
            raven.onParamDisconnect();
        }

        public override void onParamHeartbeatSeq(uint seqno)
        {
            raven.onParamHeartbeatSeq(seqno);
        }

        public override unsafe void onParamChange(Protocol.ParamServerN.ParamChangeMsgT msg)
        {
            for (byte i = 0; i < msg.NumChanges; ++i)
            {
                Protocol.ParamServerN.ParamChangeT param = msg.get_param_change_t(i);
                if (param.IsRemoval)
                {
                    paramRouter.onParamRemoval(param.ParamEnum, param.Level, param.Sequence, param.PrimaryInstrumentId, param.SecondaryInstrumentId, param.ParamIdx);
                }
                else
                {
                    switch (param.ParamType)
                    {
                        case Protocol.ParamServerN.ParamTypeE.boolean:
                            {

                                Protocol.ParamServerN.BoolParamT* elm = param.get_bool_param_t(0);
                                paramRouter.on_bool_param(param.ParamEnum, param.Level, param.Sequence, param.PrimaryInstrumentId, param.SecondaryInstrumentId, param.ParamIdx, elm->value);
                            }
                            break;
                        case Protocol.ParamServerN.ParamTypeE.char_e:
                            {

                                Protocol.ParamServerN.CharParamT* elm = param.get_char_param_t(0);
                                paramRouter.on_char_param(param.ParamEnum, param.Level, param.Sequence, param.PrimaryInstrumentId, param.SecondaryInstrumentId, param.ParamIdx, elm->value);
                            }
                            break;
                        case Protocol.ParamServerN.ParamTypeE.float_e:
                            {

                                Protocol.ParamServerN.FloatParamT* elm = param.get_float_param_t(0);
                                paramRouter.on_float_param(param.ParamEnum, param.Level, param.Sequence, param.PrimaryInstrumentId, param.SecondaryInstrumentId, param.ParamIdx, elm->value);
                            }
                            break;
                        case Protocol.ParamServerN.ParamTypeE.double_e:
                            {

                                Protocol.ParamServerN.DoubleParamT* elm = param.get_double_param_t(0);
                                paramRouter.on_double_param(param.ParamEnum, param.Level, param.Sequence, param.PrimaryInstrumentId, param.SecondaryInstrumentId, param.ParamIdx, elm->value);
                            }
                            break;
                        case Protocol.ParamServerN.ParamTypeE.uint8_e:
                            {

                                Protocol.ParamServerN.Uint8ParamT* elm = param.get_uint8_param_t(0);
                                paramRouter.on_uint8_param(param.ParamEnum, param.Level, param.Sequence, param.PrimaryInstrumentId, param.SecondaryInstrumentId, param.ParamIdx, elm->value);
                            }
                            break;
                        case Protocol.ParamServerN.ParamTypeE.uint16_e:
                            {

                                Protocol.ParamServerN.Uint16ParamT* elm = param.get_uint16_param_t(0);
                                paramRouter.on_uint16_param(param.ParamEnum, param.Level, param.Sequence, param.PrimaryInstrumentId, param.SecondaryInstrumentId, param.ParamIdx, elm->value);
                            }
                            break;
                        case Protocol.ParamServerN.ParamTypeE.uint32_e:
                            {

                                Protocol.ParamServerN.Uint32ParamT* elm = param.get_uint32_param_t(0);
                                paramRouter.on_uint32_param(param.ParamEnum, param.Level, param.Sequence, param.PrimaryInstrumentId, param.SecondaryInstrumentId, param.ParamIdx, elm->value);
                            }
                            break;
                        case Protocol.ParamServerN.ParamTypeE.uint64_e:
                            {

                                Protocol.ParamServerN.Uint64ParamT* elm = param.get_uint64_param_t(0);
                                paramRouter.on_uint64_param(param.ParamEnum, param.Level, param.Sequence, param.PrimaryInstrumentId, param.SecondaryInstrumentId, param.ParamIdx, elm->value);
                            }
                            break;
                        case Protocol.ParamServerN.ParamTypeE.int8_e:
                            {

                                Protocol.ParamServerN.Int8ParamT* elm = param.get_int8_param_t(0);
                                paramRouter.on_int8_param(param.ParamEnum, param.Level, param.Sequence, param.PrimaryInstrumentId, param.SecondaryInstrumentId, param.ParamIdx, elm->value);
                            }
                            break;
                        case Protocol.ParamServerN.ParamTypeE.int16_e:
                            {

                                Protocol.ParamServerN.Int16ParamT* elm = param.get_int16_param_t(0);
                                paramRouter.on_int16_param(param.ParamEnum, param.Level, param.Sequence, param.PrimaryInstrumentId, param.SecondaryInstrumentId, param.ParamIdx, elm->value);
                            }
                            break;
                        case Protocol.ParamServerN.ParamTypeE.int32_e:
                            {

                                Protocol.ParamServerN.Int32ParamT* elm = param.get_int32_param_t(0);
                                paramRouter.on_int32_param(param.ParamEnum, param.Level, param.Sequence, param.PrimaryInstrumentId, param.SecondaryInstrumentId, param.ParamIdx, elm->value);
                            }
                            break;
                        case Protocol.ParamServerN.ParamTypeE.int64_e:
                            {

                                Protocol.ParamServerN.Int64ParamT* elm = param.get_int64_param_t(0);
                                paramRouter.on_int64_param(param.ParamEnum, param.Level, param.Sequence, param.PrimaryInstrumentId, param.SecondaryInstrumentId, param.ParamIdx, elm->value);
                            }
                            break;
                        case Protocol.ParamServerN.ParamTypeE.time_series_date_double_element:
                            {

                                Protocol.ParamServerN.TimeSeriesDateDoubleParamT* elm = param.get_time_series_date_double_param_t(0);
                                paramRouter.on_time_series_date_double_param(param.ParamEnum, param.Level, param.Sequence, param.PrimaryInstrumentId, param.SecondaryInstrumentId, param.ParamIdx, ref *elm);
                            }
                            break;
                        case Protocol.ParamServerN.ParamTypeE.time_series_datetime_double_element:
                            {

                                Protocol.ParamServerN.TimeSeriesDateTimeDoubleParamT* elm = param.get_time_series_datetime_double_param_t(0);
                                paramRouter.on_time_series_datetime_double_param(param.ParamEnum, param.Level, param.Sequence, param.PrimaryInstrumentId, param.SecondaryInstrumentId, param.ParamIdx, ref *elm);
                            }
                            break;
                        case Protocol.ParamServerN.ParamTypeE.time_series_date_uint64_element:
                            {

                                Protocol.ParamServerN.TimeSeriesDateUint64ParamT* elm = param.get_time_series_date_uint64_param_t(0);
                                paramRouter.on_time_series_date_uint64_param(param.ParamEnum, param.Level, param.Sequence, param.PrimaryInstrumentId, param.SecondaryInstrumentId, param.ParamIdx, ref *elm);
                            }
                            break;
                        case Protocol.ParamServerN.ParamTypeE.time_series_datetime_uint64_element:
                            {

                                Protocol.ParamServerN.TimeSeriesDateTimeUint64ParamT* elm = param.get_time_series_datetime_uint64_param_t(0);
                                paramRouter.on_time_series_datetime_uint64_param(param.ParamEnum, param.Level, param.Sequence, param.PrimaryInstrumentId, param.SecondaryInstrumentId, param.ParamIdx, ref *elm);
                            }
                            break;
                        case Protocol.ParamServerN.ParamTypeE.time_series_date_int64_element:
                            {

                                Protocol.ParamServerN.TimeSeriesDateInt64ParamT* elm = param.get_time_series_date_int64_param_t(0);
                                paramRouter.on_time_series_date_int64_param(param.ParamEnum, param.Level, param.Sequence, param.PrimaryInstrumentId, param.SecondaryInstrumentId, param.ParamIdx, ref *elm);
                            }
                            break;
                        case Protocol.ParamServerN.ParamTypeE.time_series_datetime_int64_element:
                            {

                                Protocol.ParamServerN.TimeSeriesDateTimeInt64ParamT* elm = param.get_time_series_datetime_int64_param_t(0);
                                paramRouter.on_time_series_datetime_int64_param(param.ParamEnum, param.Level, param.Sequence, param.PrimaryInstrumentId, param.SecondaryInstrumentId, param.ParamIdx, ref *elm);
                            }
                            break;
                        case Protocol.ParamServerN.ParamTypeE.invalid:
                        default:
                            break;
                    }
                }
            }
        }
        public override void onMajorGroupSubscribeAck(Protocol.ParamServerN.MajorGroupSubscribeAckT ack)
        {
            paramRouter.onMajorGroupSubscribeAck(ack.major_group_id, ack.success);
        }
        public override void onSnapshotLock()
        {

        }
        public override void onSnapshotUnlock()
        {

        }

        public override void on_ps_account_creation_ack(ref AccountCreationAckT msg)
        {
            throw new NotImplementedException();
        }

        public override void on_ps_account_creation_notification(ref AccountCreationNotificationT msg)
        {
            throw new NotImplementedException();
        }

        public override void on_ps_account_instrument_subscription_ack(ref AccountInstrumentSubscriptionAckT msg)
        {
            throw new NotImplementedException();
        }

        public override void on_ps_account_parent_change_ack(ref AccountParentChangeAckT msg)
        {
            throw new NotImplementedException();
        }

        public override void on_ps_account_relation_change_notification(ref AccountRelationChangeNotificationT msg)
        {
            throw new NotImplementedException();
        }

        public override void on_ps_account_removal_ack(ref AccountRemovalAckT msg)
        {
            throw new NotImplementedException();
        }

        public override void on_ps_account_removal_notification(ref AccountRemovalNotificationT msg)
        {
            throw new NotImplementedException();
        }

        public override void on_ps_account_subscription_ack(ref AccountSubscriptionAckT msg)
        {
            throw new NotImplementedException();
        }

        public override void on_ps_get_account_children_response(ref GetAccountChildrenResponseMsgT msg)
        {
            throw new NotImplementedException();
        }

        public override void on_ps_get_account_details_response(ref GetAccountDetailsResponseT msg)
        {
            throw new NotImplementedException();
        }

        public override void on_ps_get_transaction_details_response(ref GetTransactionDetailsResponseMsgT msg)
        {
            throw new NotImplementedException();
        }

        public override void on_ps_list_accounts_response(ref ListAccountsResponseMsgT msg)
        {
            throw new NotImplementedException();
        }

        public override void on_ps_list_account_balances_response(ref ListAccountBalancesResponseMsgT msg)
        {
            throw new NotImplementedException();
        }

        public override void on_ps_list_transactions_for_account_response(ref ListTransactionsForAccountResponseMsgT msg)
        {
            throw new NotImplementedException();
        }

        public override void on_ps_position_cleared_update_ack(ref PositionClearedUpdateAckT msg)
        {
            throw new NotImplementedException();
        }

        public override void on_ps_position_clearing_notification(ref PositionClearingNotificationT msg)
        {
            throw new NotImplementedException();
        }

        public override void on_ps_position_update_ack(ref PositionUpdateAckT msg)
        {
            throw new NotImplementedException();
        }

        public override void on_ps_position_update_notification(ref PositionUpdateNotificationMsgT msg)
        {
            throw new NotImplementedException();
        }

        public bool sendEnableQuoterStrategyRequest(ulong follower_instrument_id, ulong exchange_id, ulong leader_instrument_id)
        {
            bool flag = true;
            for (int i = 0; i < manualOrderServers.Count; ++i)
            {
                flag = flag && manualOrderServers[i].enable_quoter_strategy_request(follower_instrument_id, exchange_id, leader_instrument_id);
            }
            return flag;
        }
        public bool sendDisableQuoterStrategyRequest(ulong follower_instrument_id, ulong exchange_id, ulong leader_instrument_id)
        {
            bool flag = true;
            for (int i = 0; i < manualOrderServers.Count; ++i)
            {
                flag = flag && manualOrderServers[i].disable_quoter_strategy_request(follower_instrument_id, exchange_id, leader_instrument_id);
            }
            return flag;
        }
        public bool sendQuoterStrategyStatusRequest(ulong follower_instrument_id, ulong exchange_id, ulong leader_instrument_id)
        {
            bool flag = true;
            for (int i = 0; i < manualOrderServers.Count; ++i)
            {
                flag = flag && manualOrderServers[i].quoter_strategy_status_request(follower_instrument_id, exchange_id, leader_instrument_id);
            }
            return flag;
        }
        public bool sendToggleQuoterStrategyStatus(ulong follower_instrument_id, ulong exchange_id, ulong leader_instrument_id, bool should_enable)
        {
            bool flag = true;
            for (int i = 0; i < manualOrderServers.Count; ++i)
            {
                flag = flag && manualOrderServers[i].toggle_quoter_strategy_status(follower_instrument_id, exchange_id, leader_instrument_id, should_enable);
            }
            return flag;
        }

        public bool sendNewMMPegOrderRequest(uint clordid, ulong instrument_id, uint qty, bool is_bid, ushort bbl_acc, ulong ts, uint session_idx)
        {
            return manualOrderServers[(int)session_idx].new_mm_peg_order_request(clordid, instrument_id, qty, is_bid, bbl_acc, ts);
        }
        public bool sendNewVWAPOrderRequest(uint clordid, ulong instrument_id, uint pct, uint qty, bool is_bid, bool include_auction, ushort bbl_acc, uint duration_seconds, ulong ts, uint session_idx)
        {
            return manualOrderServers[(int)session_idx].new_vwap_order_request(clordid, instrument_id, (byte)pct, qty, is_bid, include_auction, bbl_acc, duration_seconds, ts);
        }
        public bool bulk_qty_request(List<Protocol.manual_order_protocolN.QtyReqElementT> req, uint session_idx)
        {
            return manualOrderServers[(int)session_idx].bulk_qty_request(req);
        }
        public bool sendNewOrderRequest(uint clordid, ulong exchange_id, ulong instrument_id, long px, uint qty, bool is_bid, bool ioc, bool post_only, bool hidden, bool is_auction, bool is_moo, ushort bbl_acc, ulong ts, uint session_idx)
        {
            return manualOrderServers[(int)session_idx].new_order_request(clordid, exchange_id, instrument_id, px, qty, is_bid, ioc, post_only, hidden, is_auction, !is_moo, bbl_acc, ts);
        }
        public bool sendCancelOrderRequest(uint clordid, ulong exchange_id, ulong instrument_id, ulong ts, uint session_idx)
        {
            return manualOrderServers[(int)session_idx].cancel_order_request(clordid, exchange_id, instrument_id, ts);
        }
        public bool sendCancelAllRequest(ulong exchange_id, ulong instrument_id)
        {
            bool flag = true;
            for (int i = 0; i < manualOrderServers.Count; ++i)
            {
                flag = flag && manualOrderServers[i].cancel_all_request(exchange_id, instrument_id);
            }
            return flag;
        }
        public bool sendCancelAllMOCRequest(ulong when)
        {
            bool flag = true;
            for (int i = 0; i < manualOrderServers.Count; ++i)
            {
                flag = flag && manualOrderServers[i].cancel_all_moc_request(when);
            }
            return flag;
        }
        public bool sendreplaceOrderRequest(uint old_clordid, uint new_clordid, ulong exchange_id, ulong instrument_id, long px, uint qty, ulong ts, uint session_idx)
        {
            return manualOrderServers[(int)session_idx].replace_order_request(old_clordid, new_clordid, exchange_id, instrument_id, px, qty, ts);
        }
        public bool sendListQuoterStrategiesRequest(uint session_idx)
        {
            return manualOrderServers[(int)session_idx].list_quoter_strategies_request();
        }
        public bool sendFilterRequest(ulong follower_instrument_id, ulong exchange_id)
        {
            bool flag = true;
            for (int i = 0; i < manualOrderServers.Count; ++i)
            {
                flag = flag && manualOrderServers[i].quoter_filter_request(follower_instrument_id, exchange_id);
            }
            return flag;
        }
        public uint GetStartingClordid()
        {
            if (manualOrderServers.Count == 0)
                return uint.MaxValue;
            return manualOrderServers[0].GetStartingClordid();
        }

        public override void onOrderUpdate(ref OrderUpdateT msg, uint session_idx)
        {
            raven.onUpdateOrder(ref msg, session_idx);
        }
        public override void onFillUpdate(ref FillUpdateT msg, uint session_idx)
        {
            raven.onFillOrder(ref msg, session_idx);
        }
        public override void onFairNotification(ref FairNotificationT msg, uint session_idx)
        {
            //raven.onFairNotification(ref msg, session_idx);
        }
        public override void onPosNotification(ref PosNotificationT msg, uint session_idx)
        {
            //raven.onPosNotification(ref msg, session_idx);
        }
        public override void onFillEnrichment(ref Protocol.manual_order_protocolN.FillEnrichmentT msg, uint session_idx)
        {
            raven.onFillEnrichment(ref msg, session_idx);
        }
        public override void onQuoterEnableFailureNotification(ref Protocol.manual_order_protocolN.QuoterStrategyEnableFailureNotificationT msg, uint session_idx)
        {
            //raven.onQuoterEnableFailureNotification(ref msg, session_idx);
        }

        public override void onExchangeConnectionStatusNotification(ref Protocol.manual_order_protocolN.ExchangeConnectionStatusNotificationT msg, uint session_idx)
        {
            raven.onExchangeConnectionStatusNotification(ref msg, session_idx);
        }
        public override void onStrategyStatusNotification(ref Protocol.manual_order_protocolN.StrategyStatusNotificationT msg, uint session_idx)
        {
            raven.onStrategyStatusNotification(ref msg, session_idx);
        }

        public override void onOrdersSnapshot(ref OrdersSnapshotMsgT msg, uint session_idx)
        {
            throw new NotImplementedException();
        }

        public override void onRecentFillsSnapshot(ref RecentFillsSnapshotMsgT msg, uint session_idx)
        {
            throw new NotImplementedException();
        }

        public override void onListQuoterStrategiesSnapshot(ref Protocol.manual_order_protocolN.ListQuoterStrategiesSnapshotMsgT msg, uint session_idx)
        {
            //this.raven.onListQuoterStrategiesSnapshot(ref msg, session_idx);
        }
        public override void onQuoterStrategyStatusNotification(ref Protocol.manual_order_protocolN.QuoterStrategyStatusNotificationT msg, uint session_idx)
        {
            //this.raven.onQuoterStrategyStatusNotification(ref msg, session_idx);
        }

        public override void onManualOrderConnect(ulong ts, uint session_idx)
        {
            this.raven.onManualOrderConnectionStatusChanged(true, session_idx);
            this.sendListQuoterStrategiesRequest(session_idx);
        }

        public override void onManualOrderDisconnect(ulong ts, uint session_idx)
        {
            this.raven.onManualOrderConnectionStatusChanged(false, session_idx);
        }
    }
}


namespace CryptoUI
{
    public partial class App
    {
        private Network.EventManager em;
        System.Windows.Forms.Timer controllerRelativeTimer = new System.Windows.Forms.Timer();
        private void InitializeComponentEventManager()
        {
            this.em = new Network.EventManager(this);

        }
        private void StartEventManager()
        {
            this.em.Start();
        }

        public bool sendNewMMPegOrderRequest(uint clordid, ulong instrument_id, uint qty, bool is_bid, ushort bbl_acc, ulong ts, uint session_idx)
        {
            return em.sendNewMMPegOrderRequest(clordid, instrument_id, qty, is_bid, bbl_acc, ts, session_idx);
        }
        public bool sendNewVWAPOrderRequest(uint clordid, ulong instrument_id, uint pct, uint qty, bool is_bid, bool include_auction, ushort bbl_acc, uint vwap_duriaton, ulong ts, uint session_idx)
        {
            return em.sendNewVWAPOrderRequest(clordid, instrument_id, pct, qty, is_bid, include_auction, bbl_acc, vwap_duriaton, ts, session_idx);
        }
        public bool bulk_qty_request(List<Protocol.manual_order_protocolN.QtyReqElementT> req, uint session_idx)
        {
            return em.bulk_qty_request(req, session_idx);
        }
        public bool sendNewOrderRequest(uint clordid, ulong exchange_id, ulong instrument_id, long px, uint qty, bool is_bid, bool ioc, bool post_only, bool hidden, bool is_auction, bool is_moo, ushort bbl_acc, ulong ts, uint session_idx)
        {
            return em.sendNewOrderRequest(clordid, exchange_id, instrument_id, px, qty, is_bid, ioc, post_only, hidden, is_auction, is_moo, bbl_acc, ts, session_idx);
        }
        public bool sendCancelOrderRequest(uint clordid, ulong exchange_id, ulong instrument_id, ulong ts, uint session_idx)
        {
            return em.sendCancelOrderRequest(clordid, exchange_id, instrument_id, ts, session_idx);
        }
        public uint GetStartingClordid()
        {
            return em.GetStartingClordid();
        }
        public bool publishParam(Protocol.ParamServerN.ParamChangeMsgT msg)
        {
            if (em == null)
                return false;
            return em.publishParam(msg);
        }
    }
}
