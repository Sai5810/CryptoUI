using CryptoUI.Protocol.manual_order_protocolN;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TradeCore;

namespace CryptoUI.Network
{
    class ManualOrderHandler : INetworkHandler
    {
        private ITcpClient network = null;
        private IEventHandler handler;
        private uint starting_clordid;
        private uint session_idx;


        public ManualOrderHandler(IEventHandler handler_, uint starting_clordid_, uint idx)
        {
            handler = handler_;
            starting_clordid = starting_clordid_;
            session_idx = idx;
        }
        public uint GetStartingClordid()
        {
            return starting_clordid;
        }
        public override unsafe long recv(RingBuffer rx, int nbytes, out bool shoulddisconnect)
        {
            shoulddisconnect = false;
            long nbytesread = 0;
            while (rx.Usedspace - nbytesread > Protocol.manual_order_protocolN.Constants.HeaderLength)
            {
                byte* rxbuf = rx.BeginRead;
                {
                    byte* buf = rxbuf + nbytesread;
                    var header = (Protocol.manual_order_protocolN.HeaderT*)buf;
                    if (header->len > rx.Usedspace - nbytesread)
                        break;
                    switch (header->msg_type)
                    {
                        case Protocol.manual_order_protocolN.MsgTypeE.heartbeat_msg:
                            break;
                        case Protocol.manual_order_protocolN.MsgTypeE.order_update_msg:
                            {
                                var msg = (Protocol.manual_order_protocolN.OrderUpdateMsgT*)buf;
                                handler.onOrderUpdate(ref msg->msg, session_idx);
                            }
                            break;
                        case Protocol.manual_order_protocolN.MsgTypeE.fill_update_msg:
                            {
                                var msg = (Protocol.manual_order_protocolN.FillUpdateMsgT*)buf;
                                handler.onFillUpdate(ref msg->msg, session_idx);
                            }
                            break;
                        case Protocol.manual_order_protocolN.MsgTypeE.strategy_status_notification_msg:
                            {
                                var msg = (Protocol.manual_order_protocolN.StrategyStatusNotificationMsgT*)buf;
                                handler.onStrategyStatusNotification(ref msg->msg, session_idx);
                                Logger.Log(Logger.Level.info, msg->msg.ToString());
                            }
                            break;
                        case Protocol.manual_order_protocolN.MsgTypeE.exchange_connection_status_notification_msg:
                            {
                                var msg = (Protocol.manual_order_protocolN.ExchangeConnectionStatusNotificationMsgT*)buf;
                                handler.onExchangeConnectionStatusNotification(ref msg->msg, session_idx);
                                //Logger.Log(Logger.Level.info, $"ExchangeConnectionStatusNotificationMsgT {Services.ExchangeDefinitionConfigService.GetExchange(msg->msg.exchange_id)} {(msg->msg.is_connected ? "UP" : "DOWN")}");
                            }
                            break;
                        case Protocol.manual_order_protocolN.MsgTypeE.orders_snapshot_msg:
                            {
                                var msg = new Protocol.manual_order_protocolN.OrdersSnapshotMsgT();
                                if (msg.parse(buf, (uint)(rx.Usedspace - nbytesread)))
                                {
                                    handler.onOrdersSnapshot(ref msg, session_idx);
                                }
                                else
                                {
                                    // error
                                }
                            }
                            break;
                        case Protocol.manual_order_protocolN.MsgTypeE.recent_fills_snapshot_msg:
                            {
                                var msg = new Protocol.manual_order_protocolN.RecentFillsSnapshotMsgT();
                                if (msg.parse(buf, (uint)(rx.Usedspace - nbytesread)))
                                {
                                    handler.onRecentFillsSnapshot(ref msg, session_idx);
                                }
                                else
                                {
                                    // error
                                }
                            }
                            break;
                        case Protocol.manual_order_protocolN.MsgTypeE.list_quoter_strategies_snapshot_msg:
                            {
                                var msg = new Protocol.manual_order_protocolN.ListQuoterStrategiesSnapshotMsgT();
                                if (msg.parse(buf, (uint)(rx.Usedspace - nbytesread)))
                                {
                                    handler.onListQuoterStrategiesSnapshot(ref msg, session_idx);
                                }
                                else
                                {
                                    // error
                                }
                            }
                            break;
                        case Protocol.manual_order_protocolN.MsgTypeE.quoter_strategy_status_notification_msg:
                            {
                                var msg = (Protocol.manual_order_protocolN.QuoterStrategyStatusNotificationMsgT*)buf;
                                handler.onQuoterStrategyStatusNotification(ref msg->msg, session_idx);
                            }
                            break;
                        case Protocol.manual_order_protocolN.MsgTypeE.fair_notification_msg:
                            {
                                var msg = (Protocol.manual_order_protocolN.FairNotificationMsgT*)buf;
                                handler.onFairNotification(ref msg->msg, session_idx);
                            }
                            break;
                        case Protocol.manual_order_protocolN.MsgTypeE.pos_notification_msg:
                            {
                                var msg = (Protocol.manual_order_protocolN.PosNotificationMsgT*)buf;
                                handler.onPosNotification(ref msg->msg, session_idx);
                            }
                            break;
                        case Protocol.manual_order_protocolN.MsgTypeE.fill_enrichment_msg:
                            {
                                var msg = (Protocol.manual_order_protocolN.FillEnrichmentMsgT*)buf;
                                handler.onFillEnrichment(ref msg->msg, session_idx);
                            }
                            break;
                        case Protocol.manual_order_protocolN.MsgTypeE.quoter_strategy_enable_failure_notification_msg:
                            {
                                var msg = (Protocol.manual_order_protocolN.QuoterStrategyEnableFailureNotificationMsgT*)buf;
                                handler.onQuoterEnableFailureNotification(ref msg->msg, session_idx);
                            }
                            break;
                        case Protocol.manual_order_protocolN.MsgTypeE.list_quoter_strategies_request_msg:
                        case Protocol.manual_order_protocolN.MsgTypeE.enable_quoter_strategy_request_msg:
                        case Protocol.manual_order_protocolN.MsgTypeE.disable_quoter_strategy_request_msg:
                        case Protocol.manual_order_protocolN.MsgTypeE.quoter_strategy_status_request_msg:
                        case Protocol.manual_order_protocolN.MsgTypeE.new_order_request_msg:
                        case Protocol.manual_order_protocolN.MsgTypeE.new_vwap_order_request_msg:
                        case Protocol.manual_order_protocolN.MsgTypeE.new_mm_peg_order_request_msg:
                        case Protocol.manual_order_protocolN.MsgTypeE.cancel_order_request_msg:
                        case Protocol.manual_order_protocolN.MsgTypeE.replace_order_request_msg:
                        case Protocol.manual_order_protocolN.MsgTypeE.cancel_all_request_msg:
                        case Protocol.manual_order_protocolN.MsgTypeE.cancel_all_moc_request_msg:
                        case Protocol.manual_order_protocolN.MsgTypeE.invalid:
                        default:
                            {
                                Logger.Log(Logger.Level.error, $"manual_order_client recvd unknown hdr, disconnecting, {header->msg_type} {header->len}");
                                shoulddisconnect = true;
                            }
                            break;
                    }
                    nbytesread += header->len;
                }
            }
            return nbytesread;
        }

        public override void SetNetwork(ITcpClient network_)
        {
            network = network_;
        }

        public override void onConnectionReset(ulong ts)
        {
            handler.onManualOrderDisconnect(ts, session_idx);
        }
        public override unsafe bool onHeartbeat(ulong ts)
        {
            byte* pos = network.EmplaceReserve(Protocol.manual_order_protocolN.HeartbeatMsgT.c_len);
            if (pos == null)
            {
                Logger.Log(Logger.Level.error, "ManualOrderClient Failed to write Heartbeat!!");
                return false;
            }
            byte* buf = pos;
            var hb = Protocol.manual_order_protocolN.HeartbeatMsgT.Emplace(buf);
            hb->msg.ts = ts;
            return network.EmplaceCommit(Protocol.manual_order_protocolN.HeartbeatMsgT.c_len) == Protocol.manual_order_protocolN.HeartbeatMsgT.c_len;
        }
        public static unsafe string Hexify(RingBuffer ba, uint offset, uint len)
        {
            StringBuilder hex = new StringBuilder((int)len * 3 + ((int)len / 8));
            uint j = 0;
            for (int i = 0; i < (int)len; ++i)
            {
                byte b = ba.BeginRead[i + offset];
                if (j % 8 == 0 && j != 0)
                {
                    if (j % 16 == 0)
                        hex.AppendFormat("\n{0:x2} ", b);
                    else
                        hex.AppendFormat(" {0:x2} ", b);
                }
                else
                    hex.AppendFormat("{0:x2} ", b);
                ++j;
            }
            return hex.ToString();
        }
        public unsafe bool list_quoter_strategies_request()
        {
            byte* pos = network.EmplaceReserve(Protocol.manual_order_protocolN.ListQuoterStrategiesRequestMsgT.c_len);
            if (pos == null)
                return false;
            byte* buf = pos;
            var subMsg = Protocol.manual_order_protocolN.ListQuoterStrategiesRequestMsgT.Emplace(buf);
            subMsg->msg.ts = 0;
            Logger.Log(Logger.Level.info, $"sending list quoter strategies request {subMsg->ToString()}");
            return network.EmplaceCommit(Protocol.manual_order_protocolN.ListQuoterStrategiesRequestMsgT.c_len) == Protocol.manual_order_protocolN.ListQuoterStrategiesRequestMsgT.c_len;
        }
        public unsafe bool toggle_quoter_strategy_status(ulong follower_instrument_id, ulong exchange_id, ulong leader_instrument_id, bool should_enable)
        {
            if (should_enable)
                return enable_quoter_strategy_request(follower_instrument_id, exchange_id, leader_instrument_id);
            else
                return disable_quoter_strategy_request(follower_instrument_id, exchange_id, leader_instrument_id);
        }
        public unsafe bool enable_quoter_strategy_request(ulong follower_instrument_id, ulong exchange_id, ulong leader_instrument_id)
        {
            byte* pos = network.EmplaceReserve(Protocol.manual_order_protocolN.EnableQuoterStrategyRequestMsgT.c_len);
            if (pos == null)
                return false;
            byte* buf = pos;
            var subMsg = Protocol.manual_order_protocolN.EnableQuoterStrategyRequestMsgT.Emplace(buf);
            subMsg->msg.follower_instrument_id = follower_instrument_id;
            subMsg->msg.exchange_id = exchange_id;
            subMsg->msg.leader_instrument_id = leader_instrument_id;
            Logger.Log(Logger.Level.info, $"sending enable quoter strategy request {subMsg->ToString()}");
            return network.EmplaceCommit(Protocol.manual_order_protocolN.EnableQuoterStrategyRequestMsgT.c_len) == Protocol.manual_order_protocolN.EnableQuoterStrategyRequestMsgT.c_len;
        }
        public unsafe bool disable_quoter_strategy_request(ulong follower_instrument_id, ulong exchange_id, ulong leader_instrument_id)
        {
            byte* pos = network.EmplaceReserve(Protocol.manual_order_protocolN.DisableQuoterStrategyRequestMsgT.c_len);
            if (pos == null)
                return false;
            byte* buf = pos;
            var subMsg = Protocol.manual_order_protocolN.DisableQuoterStrategyRequestMsgT.Emplace(buf);
            subMsg->msg.follower_instrument_id = follower_instrument_id;
            subMsg->msg.exchange_id = exchange_id;
            subMsg->msg.leader_instrument_id = leader_instrument_id;
            Logger.Log(Logger.Level.info, $"sending disable quoter strategy request {subMsg->ToString()}");
            return network.EmplaceCommit(Protocol.manual_order_protocolN.DisableQuoterStrategyRequestMsgT.c_len) == Protocol.manual_order_protocolN.DisableQuoterStrategyRequestMsgT.c_len;
        }
        public unsafe bool quoter_strategy_status_request(ulong follower_instrument_id, ulong exchange_id, ulong leader_instrument_id)
        {
            byte* pos = network.EmplaceReserve(Protocol.manual_order_protocolN.QuoterStrategyStatusRequestMsgT.c_len);
            if (pos == null)
                return false;
            byte* buf = pos;
            var subMsg = Protocol.manual_order_protocolN.QuoterStrategyStatusRequestMsgT.Emplace(buf);
            subMsg->msg.follower_instrument_id = follower_instrument_id;
            subMsg->msg.exchange_id = exchange_id;
            subMsg->msg.leader_instrument_id = leader_instrument_id;
            Logger.Log(Logger.Level.info, $"sending quoter strategy status request {subMsg->ToString()}");
            return network.EmplaceCommit(Protocol.manual_order_protocolN.QuoterStrategyStatusRequestMsgT.c_len) == Protocol.manual_order_protocolN.QuoterStrategyStatusRequestMsgT.c_len;
        }
        public unsafe bool quoter_filter_request(ulong follower_instrument_id, ulong exchange_id)
        {
            byte* pos = network.EmplaceReserve(Protocol.manual_order_protocolN.FilterRequestMsgT.c_len);
            if (pos == null)
                return false;
            byte* buf = pos;
            var subMsg = Protocol.manual_order_protocolN.FilterRequestMsgT.Emplace(buf);
            subMsg->msg.follower_instrument_id = follower_instrument_id;
            subMsg->msg.exchange_id = exchange_id;
            return network.EmplaceCommit(Protocol.manual_order_protocolN.FilterRequestMsgT.c_len) == Protocol.manual_order_protocolN.FilterRequestMsgT.c_len;
        }
        public unsafe bool bulk_qty_request(List<Protocol.manual_order_protocolN.QtyReqElementT> req)
        {
            uint bufsize = Protocol.manual_order_protocolN.BulkQtyRequestInnerT.c_len + Protocol.manual_order_protocolN.QtyReqElementT.c_len * (uint)req.Count;
            byte* pos = network.EmplaceReserve(bufsize);
            if (pos == null)
            {
                Logger.Log(Logger.Level.info, $"sending bulk qty request failed, bufsize too small");
                return false;
            }
            byte* buf = pos;
            Protocol.manual_order_protocolN.BulkQtyRequestMsgT msg = new BulkQtyRequestMsgT();
            if (!msg.construct(buf, bufsize))
            {
                Logger.Log(Logger.Level.info, $"sending bulk qty request failed, construct failed");
                return false;
            }
            for (int i = 0; i < req.Count; ++i)
            {
                QtyReqElementT* req_ptr = msg.add_requestss(buf, bufsize);
                if (req_ptr == null)
                {
                    Logger.Log(Logger.Level.info, $"sending bulk qty request failed, req add failed");
                    return false;
                }
                *req_ptr = req[i];
            }
            Logger.Log(Logger.Level.info, $"sending bulk qty request {msg.ToString()}");
            return network.EmplaceCommit(bufsize) == bufsize;
        }
        public unsafe bool new_order_request(uint clordid, ulong exchange_id, ulong instrument_id, long px, uint qty, bool is_bid, bool ioc, bool post_only, bool hidden, bool is_auction, bool is_moc, ushort bbl_acc, ulong ts)
        {
            byte* pos = network.EmplaceReserve(Protocol.manual_order_protocolN.NewOrderRequestMsgT.c_len);
            if (pos == null)
                return false;
            byte* buf = pos;
            var subMsg = Protocol.manual_order_protocolN.NewOrderRequestMsgT.Emplace(buf);
            subMsg->msg.clordid = clordid;
            subMsg->msg.exchange_id = exchange_id;
            subMsg->msg.hidden = hidden;
            subMsg->msg.instrument_id = instrument_id;
            subMsg->msg.ioc = ioc;
            subMsg->msg.is_bid = is_bid;
            subMsg->msg.order_ts = ts;
            subMsg->msg.post_only = post_only;
            subMsg->msg.px = px;
            subMsg->msg.qty = qty;
            subMsg->msg.is_auction = is_auction;
            subMsg->msg.is_moc = is_moc;
            subMsg->msg.bbl_acc = bbl_acc;
            Logger.Log(Logger.Level.info, $"sending new order request {subMsg->ToString()}");
            return network.EmplaceCommit(Protocol.manual_order_protocolN.NewOrderRequestMsgT.c_len) == Protocol.manual_order_protocolN.NewOrderRequestMsgT.c_len;
        }
        public unsafe bool new_vwap_order_request(uint clordid, ulong instrument_id, byte pct, uint qty, bool is_bid, bool should_participate_auctions, ushort bbl_acc, uint duration_seconds, ulong ts)
        {
            byte* pos = network.EmplaceReserve(Protocol.manual_order_protocolN.NewVwapOrderRequestMsgT.c_len);
            if (pos == null)
                return false;
            byte* buf = pos;
            var subMsg = Protocol.manual_order_protocolN.NewVwapOrderRequestMsgT.Emplace(buf);
            subMsg->msg.clordid = clordid;
            subMsg->msg.instrument_id = instrument_id;
            subMsg->msg.is_bid = is_bid;
            subMsg->msg.order_ts = ts;
            subMsg->msg.max_participation_pct = pct;
            subMsg->msg.qty = qty;
            subMsg->msg.should_participate_auctions = should_participate_auctions;
            subMsg->msg.bbl_acc = bbl_acc;
            subMsg->msg.duration_seconds = duration_seconds;
            Logger.Log(Logger.Level.info, $"sending new vwap order request {subMsg->ToString()}");
            return network.EmplaceCommit(Protocol.manual_order_protocolN.NewVwapOrderRequestMsgT.c_len) == Protocol.manual_order_protocolN.NewVwapOrderRequestMsgT.c_len;
        }
        public unsafe bool new_mm_peg_order_request(uint clordid, ulong instrument_id, uint qty, bool is_bid, ushort bbl_acc, ulong ts)
        {
            byte* pos = network.EmplaceReserve(Protocol.manual_order_protocolN.NewMmPegOrderRequestMsgT.c_len);
            if (pos == null)
                return false;
            byte* buf = pos;
            var subMsg = Protocol.manual_order_protocolN.NewMmPegOrderRequestMsgT.Emplace(buf);
            subMsg->msg.clordid = clordid;
            subMsg->msg.instrument_id = instrument_id;
            subMsg->msg.is_bid = is_bid;
            subMsg->msg.order_ts = ts;
            subMsg->msg.qty = qty;
            subMsg->msg.bbl_acc = bbl_acc;
            Logger.Log(Logger.Level.info, $"sending new MM Peg order request {subMsg->ToString()}");
            return network.EmplaceCommit(Protocol.manual_order_protocolN.NewMmPegOrderRequestMsgT.c_len) == Protocol.manual_order_protocolN.NewMmPegOrderRequestMsgT.c_len;
        }
        public unsafe bool cancel_order_request(uint clordid, ulong exchange_id, ulong instrument_id, ulong ts)
        {
            byte* pos = network.EmplaceReserve(Protocol.manual_order_protocolN.CancelOrderRequestMsgT.c_len);
            if (pos == null)
                return false;
            byte* buf = pos;
            var subMsg = Protocol.manual_order_protocolN.CancelOrderRequestMsgT.Emplace(buf);
            subMsg->msg.clordid = clordid;
            subMsg->msg.exchange_id = exchange_id;
            subMsg->msg.instrument_id = instrument_id;
            subMsg->msg.order_ts = ts;
            Logger.Log(Logger.Level.info, $"sending cancel order request {subMsg->ToString()}");
            return network.EmplaceCommit(Protocol.manual_order_protocolN.CancelOrderRequestMsgT.c_len) == Protocol.manual_order_protocolN.CancelOrderRequestMsgT.c_len;
        }
        public unsafe bool replace_order_request(uint old_clordid, uint new_clordid, ulong exchange_id, ulong instrument_id, long px, uint qty, ulong ts)
        {
            byte* pos = network.EmplaceReserve(Protocol.manual_order_protocolN.ReplaceOrderRequestMsgT.c_len);
            if (pos == null)
                return false;
            byte* buf = pos;
            var subMsg = Protocol.manual_order_protocolN.ReplaceOrderRequestMsgT.Emplace(buf);
            subMsg->msg.old_clordid = old_clordid;
            subMsg->msg.new_clordid = new_clordid;
            subMsg->msg.exchange_id = exchange_id;
            subMsg->msg.instrument_id = instrument_id;
            subMsg->msg.order_ts = ts;
            subMsg->msg.px = px;
            subMsg->msg.qty = qty;
            Logger.Log(Logger.Level.info, $"sending replace order request {subMsg->ToString()}");
            return network.EmplaceCommit(Protocol.manual_order_protocolN.ReplaceOrderRequestMsgT.c_len) == Protocol.manual_order_protocolN.ReplaceOrderRequestMsgT.c_len;
        }
        public unsafe bool cancel_all_request(ulong exchange_id, ulong instrument_id)
        {
            byte* pos = network.EmplaceReserve(Protocol.manual_order_protocolN.CancelAllRequestMsgT.c_len);
            if (pos == null)
                return false;
            byte* buf = pos;
            var subMsg = Protocol.manual_order_protocolN.CancelAllRequestMsgT.Emplace(buf);
            subMsg->msg.exchange_id = exchange_id;
            subMsg->msg.instrument_id = instrument_id;
            Logger.Log(Logger.Level.info, $"sending cancel all request {subMsg->ToString()}");
            return network.EmplaceCommit(Protocol.manual_order_protocolN.CancelAllRequestMsgT.c_len) == Protocol.manual_order_protocolN.CancelAllRequestMsgT.c_len;
        }
        public unsafe bool cancel_all_moc_request(ulong when)
        {
            byte* pos = network.EmplaceReserve(Protocol.manual_order_protocolN.CancelAllMocRequestMsgT.c_len);
            if (pos == null)
                return false;
            byte* buf = pos;
            var subMsg = Protocol.manual_order_protocolN.CancelAllMocRequestMsgT.Emplace(buf);
            subMsg->msg.ts = when;
            Logger.Log(Logger.Level.info, $"sending cancel all MOCs request {subMsg->ToString()}");
            return network.EmplaceCommit(Protocol.manual_order_protocolN.CancelAllMocRequestMsgT.c_len) == Protocol.manual_order_protocolN.CancelAllMocRequestMsgT.c_len;
        }
        public override void onConnect(ulong ts)
        {
            handler.onManualOrderConnect(ts, session_idx);
        }
    }
}