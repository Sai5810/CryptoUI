using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CryptoUI.Protocol
{
    namespace manual_order_protocolN
    {
        public enum MsgTypeE : byte
        {
            invalid = 0,
            order_update_msg = 1,
            fill_update_msg = 2,
            new_order_request_msg = 3,
            new_vwap_order_request_msg = 4,
            new_mm_peg_order_request_msg = 5,
            new_peg_order_request_msg = 6,
            replace_peg_order_request_msg = 7,
            cancel_order_request_msg = 8,
            replace_order_request_msg = 9,
            cancel_all_request_msg = 10,
            exchange_connection_status_notification_msg = 11,
            strategy_status_notification_msg = 12,
            orders_snapshot_msg = 13,
            recent_fills_snapshot_msg = 14,
            heartbeat_msg = 15,
            list_quoter_strategies_request_msg = 16,
            list_quoter_strategies_snapshot_msg = 17,
            enable_quoter_strategy_request_msg = 18,
            disable_quoter_strategy_request_msg = 19,
            quoter_strategy_status_request_msg = 20,
            quoter_strategy_status_notification_msg = 21,
            filter_request_msg = 22,
            fair_notification_msg = 23,
            bulk_qty_request_msg = 24,
            cancel_all_moc_request_msg = 25,
            pos_notification_msg = 26,
            quoter_strategy_enable_failure_notification_msg = 27,
            fill_enrichment_msg = 28
        }

        public enum OrderUpdateTypeE : byte
        {
            invalid = 0,
            pending_new_order = 1,
            new_order = 2,
            new_order_rejected = 3,
            partially_filled = 4,
            filled = 5,
            cancelled = 6,
            cancel_order_rejected = 7,
            replaced = 8,
            replace_rejected = 9
        }
        public enum RejectedReasonTypeE : byte
        {
            invalid = 0,
            not_rejected = 1,
            unknown = 2
        }
        public enum TifTypeE : byte
        {
            invalid = 0,
            Day = 1,
            IOC = 2,
            MOO = 3,
            MOC = 4
        }
        public enum TriggerTypeE : byte
        {
            invalid = 0,
            local_md_changed = 1,
            leader_changed = 2,
            basket_changed = 3,
            nbbo_changed = 4,
            order_filled = 5,
            order_rejected = 6,
            order_cancelled = 7,
            hedger_qty_trigger = 8,
            hedger_timer_trigger = 9,
            param_changed = 10,
            cached_action = 11,
            ui = 12
        }
        public enum PegTypeE : byte
        {
            invalid = (byte)'\0',
            midpoint = (byte)'M',
            primary = (byte)'R',
            market = (byte)'P'
        }
        public enum OrderStatusTypeE : byte
        {
            invalid = 0,
            pending = 1,
            live = 2,
            filled = 3,
            cancelled = 4,
            replaced = 5,
            rejected = 6
        }

        public class EnumStringsT
        {
            public static string ToString(MsgTypeE e)
            {
                switch (e)
                {
                    case MsgTypeE.order_update_msg:
                        return "order_update_msg";
                    case MsgTypeE.fill_update_msg:
                        return "fill_update_msg";
                    case MsgTypeE.new_order_request_msg:
                        return "new_order_request_msg";
                    case MsgTypeE.new_vwap_order_request_msg:
                        return "new_vwap_order_request_msg";
                    case MsgTypeE.new_mm_peg_order_request_msg:
                        return "new_mm_peg_order_request_msg";
                    case MsgTypeE.new_peg_order_request_msg:
                        return "new_peg_order_request_msg";
                    case MsgTypeE.replace_peg_order_request_msg:
                        return "replace_peg_order_request_msg";
                    case MsgTypeE.cancel_order_request_msg:
                        return "cancel_order_request_msg";
                    case MsgTypeE.replace_order_request_msg:
                        return "replace_order_request_msg";
                    case MsgTypeE.cancel_all_request_msg:
                        return "cancel_all_request_msg";
                    case MsgTypeE.exchange_connection_status_notification_msg:
                        return "exchange_connection_status_notification_msg";
                    case MsgTypeE.strategy_status_notification_msg:
                        return "strategy_status_notification_msg";
                    case MsgTypeE.orders_snapshot_msg:
                        return "orders_snapshot_msg";
                    case MsgTypeE.recent_fills_snapshot_msg:
                        return "recent_fills_snapshot_msg";
                    case MsgTypeE.heartbeat_msg:
                        return "heartbeat_msg";
                    case MsgTypeE.list_quoter_strategies_request_msg:
                        return "list_quoter_strategies_request_msg";
                    case MsgTypeE.list_quoter_strategies_snapshot_msg:
                        return "list_quoter_strategies_snapshot_msg";
                    case MsgTypeE.enable_quoter_strategy_request_msg:
                        return "enable_quoter_strategy_request_msg";
                    case MsgTypeE.disable_quoter_strategy_request_msg:
                        return "disable_quoter_strategy_request_msg";
                    case MsgTypeE.quoter_strategy_status_request_msg:
                        return "quoter_strategy_status_request_msg";
                    case MsgTypeE.quoter_strategy_status_notification_msg:
                        return "quoter_strategy_status_notification_msg";
                    case MsgTypeE.filter_request_msg:
                        return "filter_request_msg";
                    case MsgTypeE.fair_notification_msg:
                        return "fair_notification_msg";
                    case MsgTypeE.bulk_qty_request_msg:
                        return "bulk_qty_request_msg";
                    case MsgTypeE.cancel_all_moc_request_msg:
                        return "cancel_all_moc_request_msg";
                    case MsgTypeE.pos_notification_msg:
                        return "pos_notification_msg";
                    case MsgTypeE.quoter_strategy_enable_failure_notification_msg:
                        return "quoter_strategy_enable_failure_notification_msg";
                    case MsgTypeE.fill_enrichment_msg:
                        return "fill_enrichment_msg";
                    case MsgTypeE.invalid:
                    default:
                        return "invalid";
                }
            }
            public static string ToString(OrderUpdateTypeE e)
            {
                switch (e)
                {
                    case OrderUpdateTypeE.pending_new_order:
                        return "pending_new_order";
                    case OrderUpdateTypeE.new_order:
                        return "new_order";
                    case OrderUpdateTypeE.new_order_rejected:
                        return "new_order_rejected";
                    case OrderUpdateTypeE.partially_filled:
                        return "partially_filled";
                    case OrderUpdateTypeE.filled:
                        return "filled";
                    case OrderUpdateTypeE.cancelled:
                        return "cancelled";
                    case OrderUpdateTypeE.cancel_order_rejected:
                        return "cancel_order_rejected";
                    case OrderUpdateTypeE.replaced:
                        return "replaced";
                    case OrderUpdateTypeE.replace_rejected:
                        return "replace_rejected";
                    case OrderUpdateTypeE.invalid:
                    default:
                        return "invalid";
                }
            }
            public static string ToString(RejectedReasonTypeE e)
            {
                switch (e)
                {
                    case RejectedReasonTypeE.not_rejected:
                        return "not_rejected";
                    case RejectedReasonTypeE.unknown:
                        return "unknown";
                    case RejectedReasonTypeE.invalid:
                    default:
                        return "invalid";
                }
            }
            public static string ToString(TifTypeE e)
            {
                switch (e)
                {
                    case TifTypeE.Day:
                        return "Day";
                    case TifTypeE.IOC:
                        return "IOC";
                    case TifTypeE.MOO:
                        return "MOO";
                    case TifTypeE.MOC:
                        return "MOC";
                    case TifTypeE.invalid:
                    default:
                        return "invalid";
                }
            }
            public static string ToString(TriggerTypeE e)
            {
                switch (e)
                {
                    case TriggerTypeE.local_md_changed:
                        return "local_md_changed";
                    case TriggerTypeE.leader_changed:
                        return "leader_changed";
                    case TriggerTypeE.basket_changed:
                        return "basket_changed";
                    case TriggerTypeE.nbbo_changed:
                        return "nbbo_changed";
                    case TriggerTypeE.order_filled:
                        return "order_filled";
                    case TriggerTypeE.order_rejected:
                        return "order_rejected";
                    case TriggerTypeE.order_cancelled:
                        return "order_cancelled";
                    case TriggerTypeE.hedger_qty_trigger:
                        return "hedger_qty_trigger";
                    case TriggerTypeE.hedger_timer_trigger:
                        return "hedger_timer_trigger";
                    case TriggerTypeE.param_changed:
                        return "param_changed";
                    case TriggerTypeE.cached_action:
                        return "cached_action";
                    case TriggerTypeE.ui:
                        return "ui";
                    case TriggerTypeE.invalid:
                    default:
                        return "invalid";
                }
            }
            public static string ToString(PegTypeE e)
            {
                switch (e)
                {
                    case PegTypeE.midpoint:
                        return "midpoint";
                    case PegTypeE.primary:
                        return "primary";
                    case PegTypeE.market:
                        return "market";
                    case PegTypeE.invalid:
                    default:
                        return "invalid";
                }
            }
            public static string ToString(OrderStatusTypeE e)
            {
                switch (e)
                {
                    case OrderStatusTypeE.pending:
                        return "pending";
                    case OrderStatusTypeE.live:
                        return "live";
                    case OrderStatusTypeE.filled:
                        return "filled";
                    case OrderStatusTypeE.cancelled:
                        return "cancelled";
                    case OrderStatusTypeE.replaced:
                        return "replaced";
                    case OrderStatusTypeE.rejected:
                        return "rejected";
                    case OrderStatusTypeE.invalid:
                    default:
                        return "invalid";
                }
            }
        }

        public unsafe class OrderUpdateTypeEPtrT
        {
            public const ushort c_len = 8;
            private OrderUpdateTypeE* ptr;

            public OrderUpdateTypeEPtrT(OrderUpdateTypeE* ptr)
            {
                this.ptr = ptr;
            }

            public Nullable<OrderUpdateTypeE> Value
            {
                get
                {
                    if (ptr == null)
                        return null;
                    return *ptr;
                }
                set
                {
                    if (value.HasValue)
                        *ptr = value.Value;
                    else
                        *ptr = OrderUpdateTypeE.invalid;
                }
            }
        }
        public unsafe class RejectedReasonTypeEPtrT
        {
            public const ushort c_len = 8;
            private RejectedReasonTypeE* ptr;

            public RejectedReasonTypeEPtrT(RejectedReasonTypeE* ptr)
            {
                this.ptr = ptr;
            }

            public Nullable<RejectedReasonTypeE> Value
            {
                get
                {
                    if (ptr == null)
                        return null;
                    return *ptr;
                }
                set
                {
                    if (value.HasValue)
                        *ptr = value.Value;
                    else
                        *ptr = RejectedReasonTypeE.invalid;
                }
            }
        }
        public unsafe class TifTypeEPtrT
        {
            public const ushort c_len = 8;
            private TifTypeE* ptr;

            public TifTypeEPtrT(TifTypeE* ptr)
            {
                this.ptr = ptr;
            }

            public Nullable<TifTypeE> Value
            {
                get
                {
                    if (ptr == null)
                        return null;
                    return *ptr;
                }
                set
                {
                    if (value.HasValue)
                        *ptr = value.Value;
                    else
                        *ptr = TifTypeE.invalid;
                }
            }
        }
        public unsafe class TriggerTypeEPtrT
        {
            public const ushort c_len = 8;
            private TriggerTypeE* ptr;

            public TriggerTypeEPtrT(TriggerTypeE* ptr)
            {
                this.ptr = ptr;
            }

            public Nullable<TriggerTypeE> Value
            {
                get
                {
                    if (ptr == null)
                        return null;
                    return *ptr;
                }
                set
                {
                    if (value.HasValue)
                        *ptr = value.Value;
                    else
                        *ptr = TriggerTypeE.invalid;
                }
            }
        }
        public unsafe class PegTypeEPtrT
        {
            public const ushort c_len = 8;
            private PegTypeE* ptr;

            public PegTypeEPtrT(PegTypeE* ptr)
            {
                this.ptr = ptr;
            }

            public Nullable<PegTypeE> Value
            {
                get
                {
                    if (ptr == null)
                        return null;
                    return *ptr;
                }
                set
                {
                    if (value.HasValue)
                        *ptr = value.Value;
                    else
                        *ptr = PegTypeE.invalid;
                }
            }
        }
        public unsafe class OrderStatusTypeEPtrT
        {
            public const ushort c_len = 8;
            private OrderStatusTypeE* ptr;

            public OrderStatusTypeEPtrT(OrderStatusTypeE* ptr)
            {
                this.ptr = ptr;
            }

            public Nullable<OrderStatusTypeE> Value
            {
                get
                {
                    if (ptr == null)
                        return null;
                    return *ptr;
                }
                set
                {
                    if (value.HasValue)
                        *ptr = value.Value;
                    else
                        *ptr = OrderStatusTypeE.invalid;
                }
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 24)]
        public struct LocalMdElementT
        { // msg_len: 24
            public const ushort c_len = 24;

            public ulong instrument_id;
            public ulong feed_id;
            public ulong pkt_seqno;

            public static unsafe LocalMdElementT* Emplace(byte* buf)
            {
                LocalMdElementT tmp = new LocalMdElementT();
                var mem = (LocalMdElementT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<LocalMdElementT{ ");
                sb.Append($"instrument_id: {this.instrument_id}");
                sb.Append($", feed_id: {this.feed_id}");
                sb.Append($", pkt_seqno: {this.pkt_seqno}");
                sb.Append("}>");
                return sb.ToString();
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 44)]
        public struct TriggerInfoElementT
        { // msg_len: 44
            public const ushort c_len = 44;

            public ulong instrument_id;
            public ulong feed_id_or_exchange_id;
            public ulong pkt_seqno_or_clordid;
            public long dequeue_ts;
            public int seqno_gap;
            public long slot_rtt;

            public static unsafe TriggerInfoElementT* Emplace(byte* buf)
            {
                TriggerInfoElementT tmp = new TriggerInfoElementT();
                var mem = (TriggerInfoElementT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<TriggerInfoElementT{ ");
                sb.Append($"instrument_id: {this.instrument_id}");
                sb.Append($", feed_id_or_exchange_id: {this.feed_id_or_exchange_id}");
                sb.Append($", pkt_seqno_or_clordid: {this.pkt_seqno_or_clordid}");
                sb.Append($", dequeue_ts: {this.dequeue_ts}");
                sb.Append($", seqno_gap: {this.seqno_gap}");
                sb.Append($", slot_rtt: {this.slot_rtt}");
                sb.Append("}>");
                return sb.ToString();
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 69)]
        public struct TriggerElementT
        { // msg_len: 69
            public const ushort c_len = 69;

            public TriggerTypeE type;
            public LocalMdElementT local_md;
            public TriggerInfoElementT trigger_info;

            public static unsafe TriggerElementT* Emplace(byte* buf)
            {
                TriggerElementT tmp = new TriggerElementT();
                var mem = (TriggerElementT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<TriggerElementT{ ");
                sb.Append($"type: {EnumStringsT.ToString(this.type)}");
                sb.Append($", local_md: {this.local_md}");
                sb.Append($", trigger_info: {this.trigger_info}");
                sb.Append("}>");
                return sb.ToString();
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 65)]
        public struct OrderElementT
        { // msg_len: 65
            public const ushort c_len = 65;

            public ulong instrument_id;
            public ulong exchange_id;
            public ulong order_new_ts;
            public ulong last_update_ts;
            public ulong clordid;
            public ulong origclordid;
            public long px;
            public uint qty;
            public OrderStatusTypeE status;
            public uint bbl_acc;

            public static unsafe OrderElementT* Emplace(byte* buf)
            {
                OrderElementT tmp = new OrderElementT();
                var mem = (OrderElementT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<OrderElementT{ ");
                sb.Append($"instrument_id: {this.instrument_id}");
                sb.Append($", exchange_id: {this.exchange_id}");
                sb.Append($", order_new_ts: {this.order_new_ts}");
                sb.Append($", last_update_ts: {this.last_update_ts}");
                sb.Append($", clordid: {this.clordid}");
                sb.Append($", origclordid: {this.origclordid}");
                sb.Append($", px: {this.px}");
                sb.Append($", qty: {this.qty}");
                sb.Append($", status: {EnumStringsT.ToString(this.status)}");
                sb.Append($", bbl_acc: {this.bbl_acc}");
                sb.Append("}>");
                return sb.ToString();
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 72)]
        public struct TradeElementT
        { // msg_len: 72
            public const ushort c_len = 72;

            public ulong instrument_id;
            public ulong exchange_id;
            public ulong order_new_ts;
            public ulong trade_ts;
            public ulong clordid;
            public ulong origclordid;
            public long order_px;
            public uint fill_qty;
            public long fill_px;
            public uint bbl_acc;

            public static unsafe TradeElementT* Emplace(byte* buf)
            {
                TradeElementT tmp = new TradeElementT();
                var mem = (TradeElementT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<TradeElementT{ ");
                sb.Append($"instrument_id: {this.instrument_id}");
                sb.Append($", exchange_id: {this.exchange_id}");
                sb.Append($", order_new_ts: {this.order_new_ts}");
                sb.Append($", trade_ts: {this.trade_ts}");
                sb.Append($", clordid: {this.clordid}");
                sb.Append($", origclordid: {this.origclordid}");
                sb.Append($", order_px: {this.order_px}");
                sb.Append($", fill_qty: {this.fill_qty}");
                sb.Append($", fill_px: {this.fill_px}");
                sb.Append($", bbl_acc: {this.bbl_acc}");
                sb.Append("}>");
                return sb.ToString();
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 25)]
        public struct StrategyElementT
        { // msg_len: 25
            public const ushort c_len = 25;

            public ulong follower_instrument_id;
            public ulong exchange_id;
            public ulong leader_instrument_id;
            [MarshalAs(UnmanagedType.I1)]
            public bool is_enabled;

            public static unsafe StrategyElementT* Emplace(byte* buf)
            {
                StrategyElementT tmp = new StrategyElementT();
                var mem = (StrategyElementT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<StrategyElementT{ ");
                sb.Append($"follower_instrument_id: {this.follower_instrument_id}");
                sb.Append($", exchange_id: {this.exchange_id}");
                sb.Append($", leader_instrument_id: {this.leader_instrument_id}");
                sb.Append($", is_enabled: {(this.is_enabled ? "true" : "false")}");
                sb.Append("}>");
                return sb.ToString();
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 13)]
        public struct QtyReqElementT
        { // msg_len: 13
            public const ushort c_len = 13;

            public ulong braavos_id;
            public uint qty;
            [MarshalAs(UnmanagedType.I1)]
            public bool is_buy;

            public static unsafe QtyReqElementT* Emplace(byte* buf)
            {
                QtyReqElementT tmp = new QtyReqElementT();
                var mem = (QtyReqElementT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<QtyReqElementT{ ");
                sb.Append($"braavos_id: {this.braavos_id}");
                sb.Append($", qty: {this.qty}");
                sb.Append($", is_buy: {(this.is_buy ? "true" : "false")}");
                sb.Append("}>");
                return sb.ToString();
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 86)]
        public struct OrderUpdateT
        { // msg_len: 86
            public const ushort c_len = 86;

            public ulong instrument_id;
            public ulong exchange_id;
            public ulong exch_ts;
            public ulong recv_ts;
            public ulong clordid;
            public ulong origclordid;
            public long px;
            public uint qty;
            [MarshalAs(UnmanagedType.I1)]
            public bool is_bid;
            [MarshalAs(UnmanagedType.I1)]
            public bool is_taking;
            public OrderUpdateTypeE type;
            public RejectedReasonTypeE reason;
            public TifTypeE TIF;
            [MarshalAs(UnmanagedType.I1)]
            public bool is_manual;
            public ulong sending_instance_id;
            public ulong sending_location_id;
            public uint bbl_acc;

            public static unsafe OrderUpdateT* Emplace(byte* buf)
            {
                OrderUpdateT tmp = new OrderUpdateT();
                var mem = (OrderUpdateT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<OrderUpdateT{ ");
                sb.Append($"instrument_id: {this.instrument_id}");
                sb.Append($", exchange_id: {this.exchange_id}");
                sb.Append($", exch_ts: {this.exch_ts}");
                sb.Append($", recv_ts: {this.recv_ts}");
                sb.Append($", clordid: {this.clordid}");
                sb.Append($", origclordid: {this.origclordid}");
                sb.Append($", px: {this.px}");
                sb.Append($", qty: {this.qty}");
                sb.Append($", is_bid: {(this.is_bid ? "true" : "false")}");
                sb.Append($", is_taking: {(this.is_taking ? "true" : "false")}");
                sb.Append($", type: {EnumStringsT.ToString(this.type)}");
                sb.Append($", reason: {EnumStringsT.ToString(this.reason)}");
                sb.Append($", TIF: {EnumStringsT.ToString(this.TIF)}");
                sb.Append($", is_manual: {(this.is_manual ? "true" : "false")}");
                sb.Append($", sending_instance_id: {this.sending_instance_id}");
                sb.Append($", sending_location_id: {this.sending_location_id}");
                sb.Append($", bbl_acc: {this.bbl_acc}");
                sb.Append("}>");
                return sb.ToString();
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 89)]
        public struct OrderUpdateMsgT
        {
            public const ushort c_len = 89;
            public const MsgTypeE c_msg_type = MsgTypeE.order_update_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public OrderUpdateT msg;

            public static unsafe OrderUpdateMsgT* Emplace(byte* buf)
            {
                OrderUpdateMsgT tmp = new OrderUpdateMsgT();
                tmp.len = c_len;
                tmp.msg_type = c_msg_type;
                var mem = (OrderUpdateMsgT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<OrderUpdateT{ ");
                sb.Append($"instrument_id: {this.msg.instrument_id}");
                sb.Append($", exchange_id: {this.msg.exchange_id}");
                sb.Append($", exch_ts: {this.msg.exch_ts}");
                sb.Append($", recv_ts: {this.msg.recv_ts}");
                sb.Append($", clordid: {this.msg.clordid}");
                sb.Append($", origclordid: {this.msg.origclordid}");
                sb.Append($", px: {this.msg.px}");
                sb.Append($", qty: {this.msg.qty}");
                sb.Append($", is_bid: {(this.msg.is_bid ? "true" : "false")}");
                sb.Append($", is_taking: {(this.msg.is_taking ? "true" : "false")}");
                sb.Append($", type: {EnumStringsT.ToString(this.msg.type)}");
                sb.Append($", reason: {EnumStringsT.ToString(this.msg.reason)}");
                sb.Append($", TIF: {EnumStringsT.ToString(this.msg.TIF)}");
                sb.Append($", is_manual: {(this.msg.is_manual ? "true" : "false")}");
                sb.Append($", sending_instance_id: {this.msg.sending_instance_id}");
                sb.Append($", sending_location_id: {this.msg.sending_location_id}");
                sb.Append($", bbl_acc: {this.msg.bbl_acc}");
                sb.Append("}>");
                return sb.ToString();
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 77)]
        public struct FillUpdateT
        { // msg_len: 77
            public const ushort c_len = 77;

            public ulong instrument_id;
            public ulong exchange_id;
            public ulong exch_ts;
            public ulong recv_ts;
            public uint clordid;
            public uint executionid;
            [MarshalAs(UnmanagedType.I1)]
            public bool is_bid;
            public long fill_px;
            public uint fill_qty;
            public long order_px;
            public long qty_remaining;
            public uint bbl_acc;
            public char Getliquidity_indAt(int idx)
            {
                switch (idx)
                {
                    case 0:
                        return (char)liquidity_ind_0;
                    case 1:
                        return (char)liquidity_ind_1;
                    case 2:
                        return (char)liquidity_ind_2;
                    case 3:
                        return (char)liquidity_ind_3;
                    default:
                        throw new System.IndexOutOfRangeException($"Attempted to access {idx} but the last valid idx is 4.");
                }
            }
            public void Setliquidity_indAt(int idx, char v)
            {
                switch (idx)
                {
                    case 0:
                        liquidity_ind_0 = Convert.ToByte(v);
                        break;
                    case 1:
                        liquidity_ind_1 = Convert.ToByte(v);
                        break;
                    case 2:
                        liquidity_ind_2 = Convert.ToByte(v);
                        break;
                    case 3:
                        liquidity_ind_3 = Convert.ToByte(v);
                        break;
                    default:
                        throw new System.IndexOutOfRangeException($"Attempted to set {idx} but the last valid idx is 4.");
                }
            }
            public string liquidity_ind_value
            {
                get
                {
                    return string.Empty + ProtocolUtilities.writeable(liquidity_ind_0) + ProtocolUtilities.writeable(liquidity_ind_1) + ProtocolUtilities.writeable(liquidity_ind_2) + ProtocolUtilities.writeable(liquidity_ind_3);
                }
                set
                {
                    for (int i = 0; i < value.Length; ++i)
                    {
                        switch (i)
                        {
                            case 0:
                                {
                                    liquidity_ind_0 = Convert.ToByte(value[i]);
                                }
                                break;
                            case 1:
                                {
                                    liquidity_ind_1 = Convert.ToByte(value[i]);
                                }
                                break;
                            case 2:
                                {
                                    liquidity_ind_2 = Convert.ToByte(value[i]);
                                }
                                break;
                            case 3:
                                {
                                    liquidity_ind_3 = Convert.ToByte(value[i]);
                                }
                                break;
                        }
                    }
                }
            }
            byte liquidity_ind_0;
            byte liquidity_ind_1;
            byte liquidity_ind_2;
            byte liquidity_ind_3;

            public static unsafe FillUpdateT* Emplace(byte* buf)
            {
                FillUpdateT tmp = new FillUpdateT();
                var mem = (FillUpdateT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<FillUpdateT{ ");
                sb.Append($"instrument_id: {this.instrument_id}");
                sb.Append($", exchange_id: {this.exchange_id}");
                sb.Append($", exch_ts: {this.exch_ts}");
                sb.Append($", recv_ts: {this.recv_ts}");
                sb.Append($", clordid: {this.clordid}");
                sb.Append($", executionid: {this.executionid}");
                sb.Append($", is_bid: {(this.is_bid ? "true" : "false")}");
                sb.Append($", fill_px: {this.fill_px}");
                sb.Append($", fill_qty: {this.fill_qty}");
                sb.Append($", order_px: {this.order_px}");
                sb.Append($", qty_remaining: {this.qty_remaining}");
                sb.Append($", bbl_acc: {this.bbl_acc}");
                sb.Append($", liquidity_ind: {this.liquidity_ind_value}");
                sb.Append("}>");
                return sb.ToString();
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 80)]
        public struct FillUpdateMsgT
        {
            public const ushort c_len = 80;
            public const MsgTypeE c_msg_type = MsgTypeE.fill_update_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public FillUpdateT msg;

            public static unsafe FillUpdateMsgT* Emplace(byte* buf)
            {
                FillUpdateMsgT tmp = new FillUpdateMsgT();
                tmp.len = c_len;
                tmp.msg_type = c_msg_type;
                var mem = (FillUpdateMsgT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<FillUpdateT{ ");
                sb.Append($"instrument_id: {this.msg.instrument_id}");
                sb.Append($", exchange_id: {this.msg.exchange_id}");
                sb.Append($", exch_ts: {this.msg.exch_ts}");
                sb.Append($", recv_ts: {this.msg.recv_ts}");
                sb.Append($", clordid: {this.msg.clordid}");
                sb.Append($", executionid: {this.msg.executionid}");
                sb.Append($", is_bid: {(this.msg.is_bid ? "true" : "false")}");
                sb.Append($", fill_px: {this.msg.fill_px}");
                sb.Append($", fill_qty: {this.msg.fill_qty}");
                sb.Append($", order_px: {this.msg.order_px}");
                sb.Append($", qty_remaining: {this.msg.qty_remaining}");
                sb.Append($", bbl_acc: {this.msg.bbl_acc}");
                sb.Append($", liquidity_ind: {this.msg.liquidity_ind_value}");
                sb.Append("}>");
                return sb.ToString();
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 119)]
        public struct NewOrderRequestT
        { // msg_len: 119
            public const ushort c_len = 119;

            public ulong instrument_id;
            public ulong exchange_id;
            public ulong order_ts;
            public uint clordid;
            [MarshalAs(UnmanagedType.I1)]
            public bool is_bid;
            public long px;
            public uint qty;
            [MarshalAs(UnmanagedType.I1)]
            public bool ioc;
            [MarshalAs(UnmanagedType.I1)]
            public bool post_only;
            [MarshalAs(UnmanagedType.I1)]
            public bool hidden;
            [MarshalAs(UnmanagedType.I1)]
            public bool is_auction;
            [MarshalAs(UnmanagedType.I1)]
            public bool is_moc;
            public uint bbl_acc;
            public TriggerElementT trigger;

            public static unsafe NewOrderRequestT* Emplace(byte* buf)
            {
                NewOrderRequestT tmp = new NewOrderRequestT();
                var mem = (NewOrderRequestT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<NewOrderRequestT{ ");
                sb.Append($"instrument_id: {this.instrument_id}");
                sb.Append($", exchange_id: {this.exchange_id}");
                sb.Append($", order_ts: {this.order_ts}");
                sb.Append($", clordid: {this.clordid}");
                sb.Append($", is_bid: {(this.is_bid ? "true" : "false")}");
                sb.Append($", px: {this.px}");
                sb.Append($", qty: {this.qty}");
                sb.Append($", ioc: {(this.ioc ? "true" : "false")}");
                sb.Append($", post_only: {(this.post_only ? "true" : "false")}");
                sb.Append($", hidden: {(this.hidden ? "true" : "false")}");
                sb.Append($", is_auction: {(this.is_auction ? "true" : "false")}");
                sb.Append($", is_moc: {(this.is_moc ? "true" : "false")}");
                sb.Append($", bbl_acc: {this.bbl_acc}");
                sb.Append($", trigger: {this.trigger}");
                sb.Append("}>");
                return sb.ToString();
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 122)]
        public struct NewOrderRequestMsgT
        {
            public const ushort c_len = 122;
            public const MsgTypeE c_msg_type = MsgTypeE.new_order_request_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public NewOrderRequestT msg;

            public static unsafe NewOrderRequestMsgT* Emplace(byte* buf)
            {
                NewOrderRequestMsgT tmp = new NewOrderRequestMsgT();
                tmp.len = c_len;
                tmp.msg_type = c_msg_type;
                var mem = (NewOrderRequestMsgT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<NewOrderRequestT{ ");
                sb.Append($"instrument_id: {this.msg.instrument_id}");
                sb.Append($", exchange_id: {this.msg.exchange_id}");
                sb.Append($", order_ts: {this.msg.order_ts}");
                sb.Append($", clordid: {this.msg.clordid}");
                sb.Append($", is_bid: {(this.msg.is_bid ? "true" : "false")}");
                sb.Append($", px: {this.msg.px}");
                sb.Append($", qty: {this.msg.qty}");
                sb.Append($", ioc: {(this.msg.ioc ? "true" : "false")}");
                sb.Append($", post_only: {(this.msg.post_only ? "true" : "false")}");
                sb.Append($", hidden: {(this.msg.hidden ? "true" : "false")}");
                sb.Append($", is_auction: {(this.msg.is_auction ? "true" : "false")}");
                sb.Append($", is_moc: {(this.msg.is_moc ? "true" : "false")}");
                sb.Append($", bbl_acc: {this.msg.bbl_acc}");
                sb.Append($", trigger: {this.msg.trigger}");
                sb.Append("}>");
                return sb.ToString();
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 35)]
        public struct NewVwapOrderRequestT
        { // msg_len: 35
            public const ushort c_len = 35;

            public ulong instrument_id;
            public ulong order_ts;
            public uint clordid;
            [MarshalAs(UnmanagedType.I1)]
            public bool is_bid;
            public byte max_participation_pct;
            public uint qty;
            [MarshalAs(UnmanagedType.I1)]
            public bool should_participate_auctions;
            public uint bbl_acc;
            public uint duration_seconds;

            public static unsafe NewVwapOrderRequestT* Emplace(byte* buf)
            {
                NewVwapOrderRequestT tmp = new NewVwapOrderRequestT();
                var mem = (NewVwapOrderRequestT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<NewVwapOrderRequestT{ ");
                sb.Append($"instrument_id: {this.instrument_id}");
                sb.Append($", order_ts: {this.order_ts}");
                sb.Append($", clordid: {this.clordid}");
                sb.Append($", is_bid: {(this.is_bid ? "true" : "false")}");
                sb.Append($", max_participation_pct: {(uint)this.max_participation_pct}");
                sb.Append($", qty: {this.qty}");
                sb.Append($", should_participate_auctions: {(this.should_participate_auctions ? "true" : "false")}");
                sb.Append($", bbl_acc: {this.bbl_acc}");
                sb.Append($", duration_seconds: {this.duration_seconds}");
                sb.Append("}>");
                return sb.ToString();
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 38)]
        public struct NewVwapOrderRequestMsgT
        {
            public const ushort c_len = 38;
            public const MsgTypeE c_msg_type = MsgTypeE.new_vwap_order_request_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public NewVwapOrderRequestT msg;

            public static unsafe NewVwapOrderRequestMsgT* Emplace(byte* buf)
            {
                NewVwapOrderRequestMsgT tmp = new NewVwapOrderRequestMsgT();
                tmp.len = c_len;
                tmp.msg_type = c_msg_type;
                var mem = (NewVwapOrderRequestMsgT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<NewVwapOrderRequestT{ ");
                sb.Append($"instrument_id: {this.msg.instrument_id}");
                sb.Append($", order_ts: {this.msg.order_ts}");
                sb.Append($", clordid: {this.msg.clordid}");
                sb.Append($", is_bid: {(this.msg.is_bid ? "true" : "false")}");
                sb.Append($", max_participation_pct: {(uint)this.msg.max_participation_pct}");
                sb.Append($", qty: {this.msg.qty}");
                sb.Append($", should_participate_auctions: {(this.msg.should_participate_auctions ? "true" : "false")}");
                sb.Append($", bbl_acc: {this.msg.bbl_acc}");
                sb.Append($", duration_seconds: {this.msg.duration_seconds}");
                sb.Append("}>");
                return sb.ToString();
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 29)]
        public struct NewMmPegOrderRequestT
        { // msg_len: 29
            public const ushort c_len = 29;

            public ulong instrument_id;
            public ulong order_ts;
            public uint clordid;
            [MarshalAs(UnmanagedType.I1)]
            public bool is_bid;
            public uint qty;
            public uint bbl_acc;

            public static unsafe NewMmPegOrderRequestT* Emplace(byte* buf)
            {
                NewMmPegOrderRequestT tmp = new NewMmPegOrderRequestT();
                var mem = (NewMmPegOrderRequestT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<NewMmPegOrderRequestT{ ");
                sb.Append($"instrument_id: {this.instrument_id}");
                sb.Append($", order_ts: {this.order_ts}");
                sb.Append($", clordid: {this.clordid}");
                sb.Append($", is_bid: {(this.is_bid ? "true" : "false")}");
                sb.Append($", qty: {this.qty}");
                sb.Append($", bbl_acc: {this.bbl_acc}");
                sb.Append("}>");
                return sb.ToString();
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 32)]
        public struct NewMmPegOrderRequestMsgT
        {
            public const ushort c_len = 32;
            public const MsgTypeE c_msg_type = MsgTypeE.new_mm_peg_order_request_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public NewMmPegOrderRequestT msg;

            public static unsafe NewMmPegOrderRequestMsgT* Emplace(byte* buf)
            {
                NewMmPegOrderRequestMsgT tmp = new NewMmPegOrderRequestMsgT();
                tmp.len = c_len;
                tmp.msg_type = c_msg_type;
                var mem = (NewMmPegOrderRequestMsgT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<NewMmPegOrderRequestT{ ");
                sb.Append($"instrument_id: {this.msg.instrument_id}");
                sb.Append($", order_ts: {this.msg.order_ts}");
                sb.Append($", clordid: {this.msg.clordid}");
                sb.Append($", is_bid: {(this.msg.is_bid ? "true" : "false")}");
                sb.Append($", qty: {this.msg.qty}");
                sb.Append($", bbl_acc: {this.msg.bbl_acc}");
                sb.Append("}>");
                return sb.ToString();
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 56)]
        public struct NewPegOrderRequestT
        { // msg_len: 56
            public const ushort c_len = 56;

            public ulong instrument_id;
            public ulong exchange_id;
            public ulong order_ts;
            public uint clordid;
            [MarshalAs(UnmanagedType.I1)]
            public bool is_bid;
            public long px;
            public uint qty;
            [MarshalAs(UnmanagedType.I1)]
            public bool hidden;
            [MarshalAs(UnmanagedType.I1)]
            public bool ioc;
            public PegTypeE pegtype;
            public long peg_difference;
            public uint bbl_acc;

            public static unsafe NewPegOrderRequestT* Emplace(byte* buf)
            {
                NewPegOrderRequestT tmp = new NewPegOrderRequestT();
                var mem = (NewPegOrderRequestT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<NewPegOrderRequestT{ ");
                sb.Append($"instrument_id: {this.instrument_id}");
                sb.Append($", exchange_id: {this.exchange_id}");
                sb.Append($", order_ts: {this.order_ts}");
                sb.Append($", clordid: {this.clordid}");
                sb.Append($", is_bid: {(this.is_bid ? "true" : "false")}");
                sb.Append($", px: {this.px}");
                sb.Append($", qty: {this.qty}");
                sb.Append($", hidden: {(this.hidden ? "true" : "false")}");
                sb.Append($", ioc: {(this.ioc ? "true" : "false")}");
                sb.Append($", pegtype: {EnumStringsT.ToString(this.pegtype)}");
                sb.Append($", peg_difference: {this.peg_difference}");
                sb.Append($", bbl_acc: {this.bbl_acc}");
                sb.Append("}>");
                return sb.ToString();
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 59)]
        public struct NewPegOrderRequestMsgT
        {
            public const ushort c_len = 59;
            public const MsgTypeE c_msg_type = MsgTypeE.new_peg_order_request_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public NewPegOrderRequestT msg;

            public static unsafe NewPegOrderRequestMsgT* Emplace(byte* buf)
            {
                NewPegOrderRequestMsgT tmp = new NewPegOrderRequestMsgT();
                tmp.len = c_len;
                tmp.msg_type = c_msg_type;
                var mem = (NewPegOrderRequestMsgT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<NewPegOrderRequestT{ ");
                sb.Append($"instrument_id: {this.msg.instrument_id}");
                sb.Append($", exchange_id: {this.msg.exchange_id}");
                sb.Append($", order_ts: {this.msg.order_ts}");
                sb.Append($", clordid: {this.msg.clordid}");
                sb.Append($", is_bid: {(this.msg.is_bid ? "true" : "false")}");
                sb.Append($", px: {this.msg.px}");
                sb.Append($", qty: {this.msg.qty}");
                sb.Append($", hidden: {(this.msg.hidden ? "true" : "false")}");
                sb.Append($", ioc: {(this.msg.ioc ? "true" : "false")}");
                sb.Append($", pegtype: {EnumStringsT.ToString(this.msg.pegtype)}");
                sb.Append($", peg_difference: {this.msg.peg_difference}");
                sb.Append($", bbl_acc: {this.msg.bbl_acc}");
                sb.Append("}>");
                return sb.ToString();
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 53)]
        public struct ReplacePegOrderRequestT
        { // msg_len: 53
            public const ushort c_len = 53;

            public ulong instrument_id;
            public ulong exchange_id;
            public ulong order_ts;
            public uint old_clordid;
            public uint new_clordid;
            public long px;
            public uint qty;
            public PegTypeE pegtype;
            public long peg_difference;

            public static unsafe ReplacePegOrderRequestT* Emplace(byte* buf)
            {
                ReplacePegOrderRequestT tmp = new ReplacePegOrderRequestT();
                var mem = (ReplacePegOrderRequestT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<ReplacePegOrderRequestT{ ");
                sb.Append($"instrument_id: {this.instrument_id}");
                sb.Append($", exchange_id: {this.exchange_id}");
                sb.Append($", order_ts: {this.order_ts}");
                sb.Append($", old_clordid: {this.old_clordid}");
                sb.Append($", new_clordid: {this.new_clordid}");
                sb.Append($", px: {this.px}");
                sb.Append($", qty: {this.qty}");
                sb.Append($", pegtype: {EnumStringsT.ToString(this.pegtype)}");
                sb.Append($", peg_difference: {this.peg_difference}");
                sb.Append("}>");
                return sb.ToString();
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 56)]
        public struct ReplacePegOrderRequestMsgT
        {
            public const ushort c_len = 56;
            public const MsgTypeE c_msg_type = MsgTypeE.replace_peg_order_request_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public ReplacePegOrderRequestT msg;

            public static unsafe ReplacePegOrderRequestMsgT* Emplace(byte* buf)
            {
                ReplacePegOrderRequestMsgT tmp = new ReplacePegOrderRequestMsgT();
                tmp.len = c_len;
                tmp.msg_type = c_msg_type;
                var mem = (ReplacePegOrderRequestMsgT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<ReplacePegOrderRequestT{ ");
                sb.Append($"instrument_id: {this.msg.instrument_id}");
                sb.Append($", exchange_id: {this.msg.exchange_id}");
                sb.Append($", order_ts: {this.msg.order_ts}");
                sb.Append($", old_clordid: {this.msg.old_clordid}");
                sb.Append($", new_clordid: {this.msg.new_clordid}");
                sb.Append($", px: {this.msg.px}");
                sb.Append($", qty: {this.msg.qty}");
                sb.Append($", pegtype: {EnumStringsT.ToString(this.msg.pegtype)}");
                sb.Append($", peg_difference: {this.msg.peg_difference}");
                sb.Append("}>");
                return sb.ToString();
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 28)]
        public struct CancelOrderRequestT
        { // msg_len: 28
            public const ushort c_len = 28;

            public ulong instrument_id;
            public ulong exchange_id;
            public ulong order_ts;
            public uint clordid;
            public TriggerElementT trigger;

            public static unsafe CancelOrderRequestT* Emplace(byte* buf)
            {
                CancelOrderRequestT tmp = new CancelOrderRequestT();
                var mem = (CancelOrderRequestT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<CancelOrderRequestT{ ");
                sb.Append($"instrument_id: {this.instrument_id}");
                sb.Append($", exchange_id: {this.exchange_id}");
                sb.Append($", order_ts: {this.order_ts}");
                sb.Append($", clordid: {this.clordid}");
                sb.Append($", trigger: {this.trigger}");
                sb.Append("}>");
                return sb.ToString();
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 31)]
        public struct CancelOrderRequestMsgT
        {
            public const ushort c_len = 31;
            public const MsgTypeE c_msg_type = MsgTypeE.cancel_order_request_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public CancelOrderRequestT msg;

            public static unsafe CancelOrderRequestMsgT* Emplace(byte* buf)
            {
                CancelOrderRequestMsgT tmp = new CancelOrderRequestMsgT();
                tmp.len = c_len;
                tmp.msg_type = c_msg_type;
                var mem = (CancelOrderRequestMsgT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<CancelOrderRequestT{ ");
                sb.Append($"instrument_id: {this.msg.instrument_id}");
                sb.Append($", exchange_id: {this.msg.exchange_id}");
                sb.Append($", order_ts: {this.msg.order_ts}");
                sb.Append($", clordid: {this.msg.clordid}");
                sb.Append($", trigger: {this.msg.trigger}");
                sb.Append("}>");
                return sb.ToString();
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 44)]
        public struct ReplaceOrderRequestT
        { // msg_len: 44
            public const ushort c_len = 44;

            public ulong instrument_id;
            public ulong exchange_id;
            public ulong order_ts;
            public uint old_clordid;
            public uint new_clordid;
            public long px;
            public uint qty;
            public TriggerElementT trigger;

            public static unsafe ReplaceOrderRequestT* Emplace(byte* buf)
            {
                ReplaceOrderRequestT tmp = new ReplaceOrderRequestT();
                var mem = (ReplaceOrderRequestT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<ReplaceOrderRequestT{ ");
                sb.Append($"instrument_id: {this.instrument_id}");
                sb.Append($", exchange_id: {this.exchange_id}");
                sb.Append($", order_ts: {this.order_ts}");
                sb.Append($", old_clordid: {this.old_clordid}");
                sb.Append($", new_clordid: {this.new_clordid}");
                sb.Append($", px: {this.px}");
                sb.Append($", qty: {this.qty}");
                sb.Append($", trigger: {this.trigger}");
                sb.Append("}>");
                return sb.ToString();
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 47)]
        public struct ReplaceOrderRequestMsgT
        {
            public const ushort c_len = 47;
            public const MsgTypeE c_msg_type = MsgTypeE.replace_order_request_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public ReplaceOrderRequestT msg;

            public static unsafe ReplaceOrderRequestMsgT* Emplace(byte* buf)
            {
                ReplaceOrderRequestMsgT tmp = new ReplaceOrderRequestMsgT();
                tmp.len = c_len;
                tmp.msg_type = c_msg_type;
                var mem = (ReplaceOrderRequestMsgT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<ReplaceOrderRequestT{ ");
                sb.Append($"instrument_id: {this.msg.instrument_id}");
                sb.Append($", exchange_id: {this.msg.exchange_id}");
                sb.Append($", order_ts: {this.msg.order_ts}");
                sb.Append($", old_clordid: {this.msg.old_clordid}");
                sb.Append($", new_clordid: {this.msg.new_clordid}");
                sb.Append($", px: {this.msg.px}");
                sb.Append($", qty: {this.msg.qty}");
                sb.Append($", trigger: {this.msg.trigger}");
                sb.Append("}>");
                return sb.ToString();
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 16)]
        public struct CancelAllRequestT
        { // msg_len: 16
            public const ushort c_len = 16;

            public ulong instrument_id;
            public ulong exchange_id;

            public static unsafe CancelAllRequestT* Emplace(byte* buf)
            {
                CancelAllRequestT tmp = new CancelAllRequestT();
                var mem = (CancelAllRequestT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<CancelAllRequestT{ ");
                sb.Append($"instrument_id: {this.instrument_id}");
                sb.Append($", exchange_id: {this.exchange_id}");
                sb.Append("}>");
                return sb.ToString();
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 19)]
        public struct CancelAllRequestMsgT
        {
            public const ushort c_len = 19;
            public const MsgTypeE c_msg_type = MsgTypeE.cancel_all_request_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public CancelAllRequestT msg;

            public static unsafe CancelAllRequestMsgT* Emplace(byte* buf)
            {
                CancelAllRequestMsgT tmp = new CancelAllRequestMsgT();
                tmp.len = c_len;
                tmp.msg_type = c_msg_type;
                var mem = (CancelAllRequestMsgT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<CancelAllRequestT{ ");
                sb.Append($"instrument_id: {this.msg.instrument_id}");
                sb.Append($", exchange_id: {this.msg.exchange_id}");
                sb.Append("}>");
                return sb.ToString();
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 9)]
        public struct ExchangeConnectionStatusNotificationT
        { // msg_len: 9
            public const ushort c_len = 9;

            public ulong exchange_id;
            [MarshalAs(UnmanagedType.I1)]
            public bool is_connected;

            public static unsafe ExchangeConnectionStatusNotificationT* Emplace(byte* buf)
            {
                ExchangeConnectionStatusNotificationT tmp = new ExchangeConnectionStatusNotificationT();
                var mem = (ExchangeConnectionStatusNotificationT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<ExchangeConnectionStatusNotificationT{ ");
                sb.Append($"exchange_id: {this.exchange_id}");
                sb.Append($", is_connected: {(this.is_connected ? "true" : "false")}");
                sb.Append("}>");
                return sb.ToString();
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 12)]
        public struct ExchangeConnectionStatusNotificationMsgT
        {
            public const ushort c_len = 12;
            public const MsgTypeE c_msg_type = MsgTypeE.exchange_connection_status_notification_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public ExchangeConnectionStatusNotificationT msg;

            public static unsafe ExchangeConnectionStatusNotificationMsgT* Emplace(byte* buf)
            {
                ExchangeConnectionStatusNotificationMsgT tmp = new ExchangeConnectionStatusNotificationMsgT();
                tmp.len = c_len;
                tmp.msg_type = c_msg_type;
                var mem = (ExchangeConnectionStatusNotificationMsgT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<ExchangeConnectionStatusNotificationT{ ");
                sb.Append($"exchange_id: {this.msg.exchange_id}");
                sb.Append($", is_connected: {(this.msg.is_connected ? "true" : "false")}");
                sb.Append("}>");
                return sb.ToString();
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 5)]
        public struct StrategyStatusNotificationT
        { // msg_len: 5
            public const ushort c_len = 5;

            [MarshalAs(UnmanagedType.I1)]
            public bool is_enabled;
            [MarshalAs(UnmanagedType.I1)]
            public bool is_ready;
            [MarshalAs(UnmanagedType.I1)]
            public bool is_running;
            [MarshalAs(UnmanagedType.I1)]
            public bool is_broker_connected;
            [MarshalAs(UnmanagedType.I1)]
            public bool is_valid;

            public static unsafe StrategyStatusNotificationT* Emplace(byte* buf)
            {
                StrategyStatusNotificationT tmp = new StrategyStatusNotificationT();
                var mem = (StrategyStatusNotificationT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<StrategyStatusNotificationT{ ");
                sb.Append($"is_enabled: {(this.is_enabled ? "true" : "false")}");
                sb.Append($", is_ready: {(this.is_ready ? "true" : "false")}");
                sb.Append($", is_running: {(this.is_running ? "true" : "false")}");
                sb.Append($", is_broker_connected: {(this.is_broker_connected ? "true" : "false")}");
                sb.Append($", is_valid: {(this.is_valid ? "true" : "false")}");
                sb.Append("}>");
                return sb.ToString();
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
        public struct StrategyStatusNotificationMsgT
        {
            public const ushort c_len = 8;
            public const MsgTypeE c_msg_type = MsgTypeE.strategy_status_notification_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public StrategyStatusNotificationT msg;

            public static unsafe StrategyStatusNotificationMsgT* Emplace(byte* buf)
            {
                StrategyStatusNotificationMsgT tmp = new StrategyStatusNotificationMsgT();
                tmp.len = c_len;
                tmp.msg_type = c_msg_type;
                var mem = (StrategyStatusNotificationMsgT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<StrategyStatusNotificationT{ ");
                sb.Append($"is_enabled: {(this.msg.is_enabled ? "true" : "false")}");
                sb.Append($", is_ready: {(this.msg.is_ready ? "true" : "false")}");
                sb.Append($", is_running: {(this.msg.is_running ? "true" : "false")}");
                sb.Append($", is_broker_connected: {(this.msg.is_broker_connected ? "true" : "false")}");
                sb.Append($", is_valid: {(this.msg.is_valid ? "true" : "false")}");
                sb.Append("}>");
                return sb.ToString();
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 5)]
        public struct OrdersSnapshotInnerT
        {
            public const ushort c_len = 5;
            public const MsgTypeE c_msg_type = MsgTypeE.orders_snapshot_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public ushort count;
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 5)]
        public struct RecentFillsSnapshotInnerT
        {
            public const ushort c_len = 5;
            public const MsgTypeE c_msg_type = MsgTypeE.recent_fills_snapshot_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public ushort count;
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
        public struct HeartbeatT
        { // msg_len: 8
            public const ushort c_len = 8;

            public ulong ts;

            public static unsafe HeartbeatT* Emplace(byte* buf)
            {
                HeartbeatT tmp = new HeartbeatT();
                var mem = (HeartbeatT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<HeartbeatT{ ");
                sb.Append($"ts: {this.ts}");
                sb.Append("}>");
                return sb.ToString();
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 11)]
        public struct HeartbeatMsgT
        {
            public const ushort c_len = 11;
            public const MsgTypeE c_msg_type = MsgTypeE.heartbeat_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public HeartbeatT msg;

            public static unsafe HeartbeatMsgT* Emplace(byte* buf)
            {
                HeartbeatMsgT tmp = new HeartbeatMsgT();
                tmp.len = c_len;
                tmp.msg_type = c_msg_type;
                var mem = (HeartbeatMsgT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<HeartbeatT{ ");
                sb.Append($"ts: {this.msg.ts}");
                sb.Append("}>");
                return sb.ToString();
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
        public struct ListQuoterStrategiesRequestT
        { // msg_len: 8
            public const ushort c_len = 8;

            public ulong ts;

            public static unsafe ListQuoterStrategiesRequestT* Emplace(byte* buf)
            {
                ListQuoterStrategiesRequestT tmp = new ListQuoterStrategiesRequestT();
                var mem = (ListQuoterStrategiesRequestT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<ListQuoterStrategiesRequestT{ ");
                sb.Append($"ts: {this.ts}");
                sb.Append("}>");
                return sb.ToString();
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 11)]
        public struct ListQuoterStrategiesRequestMsgT
        {
            public const ushort c_len = 11;
            public const MsgTypeE c_msg_type = MsgTypeE.list_quoter_strategies_request_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public ListQuoterStrategiesRequestT msg;

            public static unsafe ListQuoterStrategiesRequestMsgT* Emplace(byte* buf)
            {
                ListQuoterStrategiesRequestMsgT tmp = new ListQuoterStrategiesRequestMsgT();
                tmp.len = c_len;
                tmp.msg_type = c_msg_type;
                var mem = (ListQuoterStrategiesRequestMsgT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<ListQuoterStrategiesRequestT{ ");
                sb.Append($"ts: {this.msg.ts}");
                sb.Append("}>");
                return sb.ToString();
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 5)]
        public struct ListQuoterStrategiesSnapshotInnerT
        {
            public const ushort c_len = 5;
            public const MsgTypeE c_msg_type = MsgTypeE.list_quoter_strategies_snapshot_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public ushort count;
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 24)]
        public struct EnableQuoterStrategyRequestT
        { // msg_len: 24
            public const ushort c_len = 24;

            public ulong follower_instrument_id;
            public ulong exchange_id;
            public ulong leader_instrument_id;

            public static unsafe EnableQuoterStrategyRequestT* Emplace(byte* buf)
            {
                EnableQuoterStrategyRequestT tmp = new EnableQuoterStrategyRequestT();
                var mem = (EnableQuoterStrategyRequestT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<EnableQuoterStrategyRequestT{ ");
                sb.Append($"follower_instrument_id: {this.follower_instrument_id}");
                sb.Append($", exchange_id: {this.exchange_id}");
                sb.Append($", leader_instrument_id: {this.leader_instrument_id}");
                sb.Append("}>");
                return sb.ToString();
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 27)]
        public struct EnableQuoterStrategyRequestMsgT
        {
            public const ushort c_len = 27;
            public const MsgTypeE c_msg_type = MsgTypeE.enable_quoter_strategy_request_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public EnableQuoterStrategyRequestT msg;

            public static unsafe EnableQuoterStrategyRequestMsgT* Emplace(byte* buf)
            {
                EnableQuoterStrategyRequestMsgT tmp = new EnableQuoterStrategyRequestMsgT();
                tmp.len = c_len;
                tmp.msg_type = c_msg_type;
                var mem = (EnableQuoterStrategyRequestMsgT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<EnableQuoterStrategyRequestT{ ");
                sb.Append($"follower_instrument_id: {this.msg.follower_instrument_id}");
                sb.Append($", exchange_id: {this.msg.exchange_id}");
                sb.Append($", leader_instrument_id: {this.msg.leader_instrument_id}");
                sb.Append("}>");
                return sb.ToString();
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 24)]
        public struct DisableQuoterStrategyRequestT
        { // msg_len: 24
            public const ushort c_len = 24;

            public ulong follower_instrument_id;
            public ulong exchange_id;
            public ulong leader_instrument_id;

            public static unsafe DisableQuoterStrategyRequestT* Emplace(byte* buf)
            {
                DisableQuoterStrategyRequestT tmp = new DisableQuoterStrategyRequestT();
                var mem = (DisableQuoterStrategyRequestT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<DisableQuoterStrategyRequestT{ ");
                sb.Append($"follower_instrument_id: {this.follower_instrument_id}");
                sb.Append($", exchange_id: {this.exchange_id}");
                sb.Append($", leader_instrument_id: {this.leader_instrument_id}");
                sb.Append("}>");
                return sb.ToString();
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 27)]
        public struct DisableQuoterStrategyRequestMsgT
        {
            public const ushort c_len = 27;
            public const MsgTypeE c_msg_type = MsgTypeE.disable_quoter_strategy_request_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public DisableQuoterStrategyRequestT msg;

            public static unsafe DisableQuoterStrategyRequestMsgT* Emplace(byte* buf)
            {
                DisableQuoterStrategyRequestMsgT tmp = new DisableQuoterStrategyRequestMsgT();
                tmp.len = c_len;
                tmp.msg_type = c_msg_type;
                var mem = (DisableQuoterStrategyRequestMsgT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<DisableQuoterStrategyRequestT{ ");
                sb.Append($"follower_instrument_id: {this.msg.follower_instrument_id}");
                sb.Append($", exchange_id: {this.msg.exchange_id}");
                sb.Append($", leader_instrument_id: {this.msg.leader_instrument_id}");
                sb.Append("}>");
                return sb.ToString();
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 24)]
        public struct QuoterStrategyStatusRequestT
        { // msg_len: 24
            public const ushort c_len = 24;

            public ulong follower_instrument_id;
            public ulong exchange_id;
            public ulong leader_instrument_id;

            public static unsafe QuoterStrategyStatusRequestT* Emplace(byte* buf)
            {
                QuoterStrategyStatusRequestT tmp = new QuoterStrategyStatusRequestT();
                var mem = (QuoterStrategyStatusRequestT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<QuoterStrategyStatusRequestT{ ");
                sb.Append($"follower_instrument_id: {this.follower_instrument_id}");
                sb.Append($", exchange_id: {this.exchange_id}");
                sb.Append($", leader_instrument_id: {this.leader_instrument_id}");
                sb.Append("}>");
                return sb.ToString();
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 27)]
        public struct QuoterStrategyStatusRequestMsgT
        {
            public const ushort c_len = 27;
            public const MsgTypeE c_msg_type = MsgTypeE.quoter_strategy_status_request_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public QuoterStrategyStatusRequestT msg;

            public static unsafe QuoterStrategyStatusRequestMsgT* Emplace(byte* buf)
            {
                QuoterStrategyStatusRequestMsgT tmp = new QuoterStrategyStatusRequestMsgT();
                tmp.len = c_len;
                tmp.msg_type = c_msg_type;
                var mem = (QuoterStrategyStatusRequestMsgT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<QuoterStrategyStatusRequestT{ ");
                sb.Append($"follower_instrument_id: {this.msg.follower_instrument_id}");
                sb.Append($", exchange_id: {this.msg.exchange_id}");
                sb.Append($", leader_instrument_id: {this.msg.leader_instrument_id}");
                sb.Append("}>");
                return sb.ToString();
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 25)]
        public struct QuoterStrategyStatusNotificationT
        { // msg_len: 25
            public const ushort c_len = 25;

            public ulong follower_instrument_id;
            public ulong exchange_id;
            public ulong leader_instrument_id;
            [MarshalAs(UnmanagedType.I1)]
            public bool is_enabled;

            public static unsafe QuoterStrategyStatusNotificationT* Emplace(byte* buf)
            {
                QuoterStrategyStatusNotificationT tmp = new QuoterStrategyStatusNotificationT();
                var mem = (QuoterStrategyStatusNotificationT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<QuoterStrategyStatusNotificationT{ ");
                sb.Append($"follower_instrument_id: {this.follower_instrument_id}");
                sb.Append($", exchange_id: {this.exchange_id}");
                sb.Append($", leader_instrument_id: {this.leader_instrument_id}");
                sb.Append($", is_enabled: {(this.is_enabled ? "true" : "false")}");
                sb.Append("}>");
                return sb.ToString();
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 28)]
        public struct QuoterStrategyStatusNotificationMsgT
        {
            public const ushort c_len = 28;
            public const MsgTypeE c_msg_type = MsgTypeE.quoter_strategy_status_notification_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public QuoterStrategyStatusNotificationT msg;

            public static unsafe QuoterStrategyStatusNotificationMsgT* Emplace(byte* buf)
            {
                QuoterStrategyStatusNotificationMsgT tmp = new QuoterStrategyStatusNotificationMsgT();
                tmp.len = c_len;
                tmp.msg_type = c_msg_type;
                var mem = (QuoterStrategyStatusNotificationMsgT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<QuoterStrategyStatusNotificationT{ ");
                sb.Append($"follower_instrument_id: {this.msg.follower_instrument_id}");
                sb.Append($", exchange_id: {this.msg.exchange_id}");
                sb.Append($", leader_instrument_id: {this.msg.leader_instrument_id}");
                sb.Append($", is_enabled: {(this.msg.is_enabled ? "true" : "false")}");
                sb.Append("}>");
                return sb.ToString();
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 16)]
        public struct FilterRequestT
        { // msg_len: 16
            public const ushort c_len = 16;

            public ulong follower_instrument_id;
            public ulong exchange_id;

            public static unsafe FilterRequestT* Emplace(byte* buf)
            {
                FilterRequestT tmp = new FilterRequestT();
                var mem = (FilterRequestT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<FilterRequestT{ ");
                sb.Append($"follower_instrument_id: {this.follower_instrument_id}");
                sb.Append($", exchange_id: {this.exchange_id}");
                sb.Append("}>");
                return sb.ToString();
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 19)]
        public struct FilterRequestMsgT
        {
            public const ushort c_len = 19;
            public const MsgTypeE c_msg_type = MsgTypeE.filter_request_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public FilterRequestT msg;

            public static unsafe FilterRequestMsgT* Emplace(byte* buf)
            {
                FilterRequestMsgT tmp = new FilterRequestMsgT();
                tmp.len = c_len;
                tmp.msg_type = c_msg_type;
                var mem = (FilterRequestMsgT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<FilterRequestT{ ");
                sb.Append($"follower_instrument_id: {this.msg.follower_instrument_id}");
                sb.Append($", exchange_id: {this.msg.exchange_id}");
                sb.Append("}>");
                return sb.ToString();
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 109)]
        public struct FairNotificationT
        { // msg_len: 109
            public const ushort c_len = 109;

            public ulong follower_instrument_id;
            public ulong leader_instrument_id;
            public ulong exchange_id;
            public long bid_fair;
            public long ask_fair;
            public long bid_md_top;
            public long ask_md_top;
            public long top_bid_order_px;
            public long top_ask_order_px;
            public long unhedged_delta;
            public long pnl;
            public long follower_inav;
            public long leader_inav;
            [MarshalAs(UnmanagedType.I1)]
            public bool enabled;
            [MarshalAs(UnmanagedType.I1)]
            public bool market_closed;
            [MarshalAs(UnmanagedType.I1)]
            public bool follower_bad_state;
            [MarshalAs(UnmanagedType.I1)]
            public bool basket_bad_state;
            [MarshalAs(UnmanagedType.I1)]
            public bool leader_bad_state;

            public static unsafe FairNotificationT* Emplace(byte* buf)
            {
                FairNotificationT tmp = new FairNotificationT();
                var mem = (FairNotificationT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<FairNotificationT{ ");
                sb.Append($"follower_instrument_id: {this.follower_instrument_id}");
                sb.Append($", leader_instrument_id: {this.leader_instrument_id}");
                sb.Append($", exchange_id: {this.exchange_id}");
                sb.Append($", bid_fair: {this.bid_fair}");
                sb.Append($", ask_fair: {this.ask_fair}");
                sb.Append($", bid_md_top: {this.bid_md_top}");
                sb.Append($", ask_md_top: {this.ask_md_top}");
                sb.Append($", top_bid_order_px: {this.top_bid_order_px}");
                sb.Append($", top_ask_order_px: {this.top_ask_order_px}");
                sb.Append($", unhedged_delta: {this.unhedged_delta}");
                sb.Append($", pnl: {this.pnl}");
                sb.Append($", follower_inav: {this.follower_inav}");
                sb.Append($", leader_inav: {this.leader_inav}");
                sb.Append($", enabled: {(this.enabled ? "true" : "false")}");
                sb.Append($", market_closed: {(this.market_closed ? "true" : "false")}");
                sb.Append($", follower_bad_state: {(this.follower_bad_state ? "true" : "false")}");
                sb.Append($", basket_bad_state: {(this.basket_bad_state ? "true" : "false")}");
                sb.Append($", leader_bad_state: {(this.leader_bad_state ? "true" : "false")}");
                sb.Append("}>");
                return sb.ToString();
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 112)]
        public struct FairNotificationMsgT
        {
            public const ushort c_len = 112;
            public const MsgTypeE c_msg_type = MsgTypeE.fair_notification_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public FairNotificationT msg;

            public static unsafe FairNotificationMsgT* Emplace(byte* buf)
            {
                FairNotificationMsgT tmp = new FairNotificationMsgT();
                tmp.len = c_len;
                tmp.msg_type = c_msg_type;
                var mem = (FairNotificationMsgT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<FairNotificationT{ ");
                sb.Append($"follower_instrument_id: {this.msg.follower_instrument_id}");
                sb.Append($", leader_instrument_id: {this.msg.leader_instrument_id}");
                sb.Append($", exchange_id: {this.msg.exchange_id}");
                sb.Append($", bid_fair: {this.msg.bid_fair}");
                sb.Append($", ask_fair: {this.msg.ask_fair}");
                sb.Append($", bid_md_top: {this.msg.bid_md_top}");
                sb.Append($", ask_md_top: {this.msg.ask_md_top}");
                sb.Append($", top_bid_order_px: {this.msg.top_bid_order_px}");
                sb.Append($", top_ask_order_px: {this.msg.top_ask_order_px}");
                sb.Append($", unhedged_delta: {this.msg.unhedged_delta}");
                sb.Append($", pnl: {this.msg.pnl}");
                sb.Append($", follower_inav: {this.msg.follower_inav}");
                sb.Append($", leader_inav: {this.msg.leader_inav}");
                sb.Append($", enabled: {(this.msg.enabled ? "true" : "false")}");
                sb.Append($", market_closed: {(this.msg.market_closed ? "true" : "false")}");
                sb.Append($", follower_bad_state: {(this.msg.follower_bad_state ? "true" : "false")}");
                sb.Append($", basket_bad_state: {(this.msg.basket_bad_state ? "true" : "false")}");
                sb.Append($", leader_bad_state: {(this.msg.leader_bad_state ? "true" : "false")}");
                sb.Append("}>");
                return sb.ToString();
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 5)]
        public struct BulkQtyRequestInnerT
        {
            public const ushort c_len = 5;
            public const MsgTypeE c_msg_type = MsgTypeE.bulk_qty_request_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public ushort count;
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
        public struct CancelAllMocRequestT
        { // msg_len: 8
            public const ushort c_len = 8;

            public ulong ts;

            public static unsafe CancelAllMocRequestT* Emplace(byte* buf)
            {
                CancelAllMocRequestT tmp = new CancelAllMocRequestT();
                var mem = (CancelAllMocRequestT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<CancelAllMocRequestT{ ");
                sb.Append($"ts: {this.ts}");
                sb.Append("}>");
                return sb.ToString();
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 11)]
        public struct CancelAllMocRequestMsgT
        {
            public const ushort c_len = 11;
            public const MsgTypeE c_msg_type = MsgTypeE.cancel_all_moc_request_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public CancelAllMocRequestT msg;

            public static unsafe CancelAllMocRequestMsgT* Emplace(byte* buf)
            {
                CancelAllMocRequestMsgT tmp = new CancelAllMocRequestMsgT();
                tmp.len = c_len;
                tmp.msg_type = c_msg_type;
                var mem = (CancelAllMocRequestMsgT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<CancelAllMocRequestT{ ");
                sb.Append($"ts: {this.msg.ts}");
                sb.Append("}>");
                return sb.ToString();
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 40)]
        public struct PosNotificationT
        { // msg_len: 40
            public const ushort c_len = 40;

            public ulong instrument_id;
            public long sod_shares;
            public long sod_cash_nanos;
            public long net_shares;
            public long net_cash_nanos;

            public static unsafe PosNotificationT* Emplace(byte* buf)
            {
                PosNotificationT tmp = new PosNotificationT();
                var mem = (PosNotificationT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<PosNotificationT{ ");
                sb.Append($"instrument_id: {this.instrument_id}");
                sb.Append($", sod_shares: {this.sod_shares}");
                sb.Append($", sod_cash_nanos: {this.sod_cash_nanos}");
                sb.Append($", net_shares: {this.net_shares}");
                sb.Append($", net_cash_nanos: {this.net_cash_nanos}");
                sb.Append("}>");
                return sb.ToString();
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 43)]
        public struct PosNotificationMsgT
        {
            public const ushort c_len = 43;
            public const MsgTypeE c_msg_type = MsgTypeE.pos_notification_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public PosNotificationT msg;

            public static unsafe PosNotificationMsgT* Emplace(byte* buf)
            {
                PosNotificationMsgT tmp = new PosNotificationMsgT();
                tmp.len = c_len;
                tmp.msg_type = c_msg_type;
                var mem = (PosNotificationMsgT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<PosNotificationT{ ");
                sb.Append($"instrument_id: {this.msg.instrument_id}");
                sb.Append($", sod_shares: {this.msg.sod_shares}");
                sb.Append($", sod_cash_nanos: {this.msg.sod_cash_nanos}");
                sb.Append($", net_shares: {this.msg.net_shares}");
                sb.Append($", net_cash_nanos: {this.msg.net_cash_nanos}");
                sb.Append("}>");
                return sb.ToString();
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 28)]
        public struct QuoterStrategyEnableFailureNotificationT
        { // msg_len: 28
            public const ushort c_len = 28;

            public ulong follower_instrument_id;
            public ulong exchange_id;
            public ulong leader_instrument_id;
            [MarshalAs(UnmanagedType.I1)]
            public bool market_closed;
            [MarshalAs(UnmanagedType.I1)]
            public bool follower_bad_state;
            [MarshalAs(UnmanagedType.I1)]
            public bool basket_bad_state;
            [MarshalAs(UnmanagedType.I1)]
            public bool leader_bad_state;

            public static unsafe QuoterStrategyEnableFailureNotificationT* Emplace(byte* buf)
            {
                QuoterStrategyEnableFailureNotificationT tmp = new QuoterStrategyEnableFailureNotificationT();
                var mem = (QuoterStrategyEnableFailureNotificationT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<QuoterStrategyEnableFailureNotificationT{ ");
                sb.Append($"follower_instrument_id: {this.follower_instrument_id}");
                sb.Append($", exchange_id: {this.exchange_id}");
                sb.Append($", leader_instrument_id: {this.leader_instrument_id}");
                sb.Append($", market_closed: {(this.market_closed ? "true" : "false")}");
                sb.Append($", follower_bad_state: {(this.follower_bad_state ? "true" : "false")}");
                sb.Append($", basket_bad_state: {(this.basket_bad_state ? "true" : "false")}");
                sb.Append($", leader_bad_state: {(this.leader_bad_state ? "true" : "false")}");
                sb.Append("}>");
                return sb.ToString();
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 31)]
        public struct QuoterStrategyEnableFailureNotificationMsgT
        {
            public const ushort c_len = 31;
            public const MsgTypeE c_msg_type = MsgTypeE.quoter_strategy_enable_failure_notification_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public QuoterStrategyEnableFailureNotificationT msg;

            public static unsafe QuoterStrategyEnableFailureNotificationMsgT* Emplace(byte* buf)
            {
                QuoterStrategyEnableFailureNotificationMsgT tmp = new QuoterStrategyEnableFailureNotificationMsgT();
                tmp.len = c_len;
                tmp.msg_type = c_msg_type;
                var mem = (QuoterStrategyEnableFailureNotificationMsgT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<QuoterStrategyEnableFailureNotificationT{ ");
                sb.Append($"follower_instrument_id: {this.msg.follower_instrument_id}");
                sb.Append($", exchange_id: {this.msg.exchange_id}");
                sb.Append($", leader_instrument_id: {this.msg.leader_instrument_id}");
                sb.Append($", market_closed: {(this.msg.market_closed ? "true" : "false")}");
                sb.Append($", follower_bad_state: {(this.msg.follower_bad_state ? "true" : "false")}");
                sb.Append($", basket_bad_state: {(this.msg.basket_bad_state ? "true" : "false")}");
                sb.Append($", leader_bad_state: {(this.msg.leader_bad_state ? "true" : "false")}");
                sb.Append("}>");
                return sb.ToString();
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 116)]
        public struct FillEnrichmentT
        { // msg_len: 116
            public const ushort c_len = 116;

            public ulong instrument_id;
            public ulong leader_instrument_id;
            public ulong exchange_id;
            public uint clordid;
            public uint executionid;
            public ulong exch_ts;
            public long current_quote_px_nanos;
            public long fair_last_nanos;
            public long md_top_bid_nanos;
            public long md_top_ask_nanos;
            public uint md_top_qty;
            public long leader_merged_top_px_nanos;
            public long leader_arca_top_px_nanos;
            public long leader_nasdaq_top_px_nanos;
            public long leader_bzx_top_px_nanos;
            public long leader_px_at_placement;

            public static unsafe FillEnrichmentT* Emplace(byte* buf)
            {
                FillEnrichmentT tmp = new FillEnrichmentT();
                var mem = (FillEnrichmentT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<FillEnrichmentT{ ");
                sb.Append($"instrument_id: {this.instrument_id}");
                sb.Append($", leader_instrument_id: {this.leader_instrument_id}");
                sb.Append($", exchange_id: {this.exchange_id}");
                sb.Append($", clordid: {this.clordid}");
                sb.Append($", executionid: {this.executionid}");
                sb.Append($", exch_ts: {this.exch_ts}");
                sb.Append($", current_quote_px_nanos: {this.current_quote_px_nanos}");
                sb.Append($", fair_last_nanos: {this.fair_last_nanos}");
                sb.Append($", md_top_bid_nanos: {this.md_top_bid_nanos}");
                sb.Append($", md_top_ask_nanos: {this.md_top_ask_nanos}");
                sb.Append($", md_top_qty: {this.md_top_qty}");
                sb.Append($", leader_merged_top_px_nanos: {this.leader_merged_top_px_nanos}");
                sb.Append($", leader_arca_top_px_nanos: {this.leader_arca_top_px_nanos}");
                sb.Append($", leader_nasdaq_top_px_nanos: {this.leader_nasdaq_top_px_nanos}");
                sb.Append($", leader_bzx_top_px_nanos: {this.leader_bzx_top_px_nanos}");
                sb.Append($", leader_px_at_placement: {this.leader_px_at_placement}");
                sb.Append("}>");
                return sb.ToString();
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 119)]
        public struct FillEnrichmentMsgT
        {
            public const ushort c_len = 119;
            public const MsgTypeE c_msg_type = MsgTypeE.fill_enrichment_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public FillEnrichmentT msg;

            public static unsafe FillEnrichmentMsgT* Emplace(byte* buf)
            {
                FillEnrichmentMsgT tmp = new FillEnrichmentMsgT();
                tmp.len = c_len;
                tmp.msg_type = c_msg_type;
                var mem = (FillEnrichmentMsgT*)buf;
                *mem = tmp;
                return mem;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<FillEnrichmentT{ ");
                sb.Append($"instrument_id: {this.msg.instrument_id}");
                sb.Append($", leader_instrument_id: {this.msg.leader_instrument_id}");
                sb.Append($", exchange_id: {this.msg.exchange_id}");
                sb.Append($", clordid: {this.msg.clordid}");
                sb.Append($", executionid: {this.msg.executionid}");
                sb.Append($", exch_ts: {this.msg.exch_ts}");
                sb.Append($", current_quote_px_nanos: {this.msg.current_quote_px_nanos}");
                sb.Append($", fair_last_nanos: {this.msg.fair_last_nanos}");
                sb.Append($", md_top_bid_nanos: {this.msg.md_top_bid_nanos}");
                sb.Append($", md_top_ask_nanos: {this.msg.md_top_ask_nanos}");
                sb.Append($", md_top_qty: {this.msg.md_top_qty}");
                sb.Append($", leader_merged_top_px_nanos: {this.msg.leader_merged_top_px_nanos}");
                sb.Append($", leader_arca_top_px_nanos: {this.msg.leader_arca_top_px_nanos}");
                sb.Append($", leader_nasdaq_top_px_nanos: {this.msg.leader_nasdaq_top_px_nanos}");
                sb.Append($", leader_bzx_top_px_nanos: {this.msg.leader_bzx_top_px_nanos}");
                sb.Append($", leader_px_at_placement: {this.msg.leader_px_at_placement}");
                sb.Append("}>");
                return sb.ToString();
            }
        };

        public unsafe class OrdersSnapshotMsgT
        {
            private OrdersSnapshotInnerT* inner = null;
            private PtrVectorT orderss = new PtrVectorT();
            private byte* layer_buf_ptr = null;
            private ushort* len_ptr = null;

            public ushort Length
            {
                get
                {
                    if (inner != null)
                        return inner->len;
                    return 0;
                }
                set
                {
                    if (inner != null)
                        inner->len = value;
                }
            }
            public MsgTypeE MsgType
            {
                get
                {
                    if (inner != null)
                        return inner->msg_type;
                    return MsgTypeE.invalid;
                }
                set
                {
                    if (inner != null)
                        inner->msg_type = value;
                }
            }
            public Nullable<ushort> count
            {
                get
                {
                    if (inner == null)
                        return null;
                    return inner->count;
                }
                set
                {
                    if (inner == null)
                        return;
                    if (!value.HasValue)
                        inner->count = 0;
                    inner->count = value.Value;
                }
            }
            public Nullable<OrderElementT> get_orderss(byte idx)
            {
                if (idx > get_orders_count())
                    return null;
                return *(OrderElementT*)orderss.Get(idx);
            }
            public List<OrderElementT> get_orderss()
            {
                List<OrderElementT> l = new List<OrderElementT>();
                for (byte idx = 0; idx < get_orders_count(); ++idx)
                    l.Add(*(OrderElementT*)orderss.Get(idx));
                return l;
            }
            public OrderElementT* add_orderss(byte* buf)
            {
                ushort offset = OrdersSnapshotInnerT.c_len;
                for (byte i = 0; i < inner->count; ++i)
                    offset += OrderElementT.c_len;
                OrderElementT* ptr = OrderElementT.Emplace(layer_buf_ptr);
                byte* mem_ptr = layer_buf_ptr;
                layer_buf_ptr += 65;
                *len_ptr += 65;
                orderss.Add(mem_ptr);
                inner->count++;
                return ptr;
            }
            public OrderElementT* add_orderss(byte* buf, uint bufsz)
            {
                ushort offset = OrdersSnapshotInnerT.c_len;
                for (byte i = 0; i < inner->count; ++i)
                    offset += 65;
                if (bufsz < (offset + 65))
                    return null;
                if (bufsz - (layer_buf_ptr - buf) < 65)
                    return null;
                OrderElementT* ptr = OrderElementT.Emplace(layer_buf_ptr);
                byte* mem_ptr = layer_buf_ptr;
                layer_buf_ptr += 65;
                *len_ptr += 65;
                orderss.Add(mem_ptr);
                inner->count++;
                return ptr;
            }
            public ushort get_orders_count()
            {
                return (ushort)orderss.Count;
            }
            public void parse(byte* buf)
            {
                inner = (OrdersSnapshotInnerT*)buf;
                buf += OrdersSnapshotInnerT.c_len;
                orderss.SetBasePtr(buf);
                for (byte i = 0; i < inner->count; ++i)
                {
                    orderss.Add(buf);
                    buf += OrderElementT.c_len;
                }
            }
            public bool parse(byte* buf, uint bufsz)
            {
                if (bufsz < OrdersSnapshotInnerT.c_len)
                    return false;
                inner = (OrdersSnapshotInnerT*)buf;
                buf += OrdersSnapshotInnerT.c_len;
                if (bufsz < 0 + inner->count * 65)
                    return false;
                bufsz -= OrdersSnapshotInnerT.c_len;
                orderss.SetBasePtr(buf);
                for (byte i = 0; i < inner->count; ++i)
                {
                    orderss.Add(buf);
                    buf += OrderElementT.c_len;
                    bufsz -= OrderElementT.c_len;
                }
                return true;
            }
            public bool copy_into(byte* buf, uint bufsz)
            {
                if (Length > bufsz)
                    return false;
                byte* ptr = buffer_ptr();
                for (ushort i = 0; i < Length; ++i)
                    buf[i] = ptr[i];
                return true;
            }
            public byte* buffer_ptr()
            {
                return (byte*)inner;
            }
            public void construct(byte* buf)
            {
                inner = (OrdersSnapshotInnerT*)buf;
                inner->len = OrdersSnapshotInnerT.c_len;
                inner->msg_type = OrdersSnapshotInnerT.c_msg_type;
                len_ptr = &inner->len;
                layer_buf_ptr = buf + OrdersSnapshotInnerT.c_len;
                *len_ptr += OrdersSnapshotInnerT.c_len;
            }
            public bool construct(byte* buf, uint bufsz)
            {
                if (bufsz < OrdersSnapshotInnerT.c_len)
                    return false;
                inner = (OrdersSnapshotInnerT*)buf;
                inner->len = OrdersSnapshotInnerT.c_len;
                inner->msg_type = OrdersSnapshotInnerT.c_msg_type;
                len_ptr = &inner->len;
                layer_buf_ptr = buf + OrdersSnapshotInnerT.c_len;
                *len_ptr += OrdersSnapshotInnerT.c_len;
                return true;
            }
            public void clear()
            {
                inner = null;
                orderss.Clear();
            }
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<OrdersSnapshotT{ ");
                sb.Append($"count: {(uint)this.count}");
                for (byte idx = 0; idx < get_orders_count(); ++idx)
                {
                    sb.Append($", orders[{idx}]: {(*((OrderElementT*)orderss.Get(idx))).ToString()}");
                }
                sb.Append("}>");
                return sb.ToString();
            }
        }
        public unsafe class RecentFillsSnapshotMsgT
        {
            private RecentFillsSnapshotInnerT* inner = null;
            private PtrVectorT tradess = new PtrVectorT();
            private byte* layer_buf_ptr = null;
            private ushort* len_ptr = null;

            public ushort Length
            {
                get
                {
                    if (inner != null)
                        return inner->len;
                    return 0;
                }
                set
                {
                    if (inner != null)
                        inner->len = value;
                }
            }
            public MsgTypeE MsgType
            {
                get
                {
                    if (inner != null)
                        return inner->msg_type;
                    return MsgTypeE.invalid;
                }
                set
                {
                    if (inner != null)
                        inner->msg_type = value;
                }
            }
            public Nullable<ushort> count
            {
                get
                {
                    if (inner == null)
                        return null;
                    return inner->count;
                }
                set
                {
                    if (inner == null)
                        return;
                    if (!value.HasValue)
                        inner->count = 0;
                    inner->count = value.Value;
                }
            }
            public Nullable<TradeElementT> get_tradess(byte idx)
            {
                if (idx > get_trades_count())
                    return null;
                return *(TradeElementT*)tradess.Get(idx);
            }
            public List<TradeElementT> get_tradess()
            {
                List<TradeElementT> l = new List<TradeElementT>();
                for (byte idx = 0; idx < get_trades_count(); ++idx)
                    l.Add(*(TradeElementT*)tradess.Get(idx));
                return l;
            }
            public TradeElementT* add_tradess(byte* buf)
            {
                ushort offset = RecentFillsSnapshotInnerT.c_len;
                for (byte i = 0; i < inner->count; ++i)
                    offset += TradeElementT.c_len;
                TradeElementT* ptr = TradeElementT.Emplace(layer_buf_ptr);
                byte* mem_ptr = layer_buf_ptr;
                layer_buf_ptr += 72;
                *len_ptr += 72;
                tradess.Add(mem_ptr);
                inner->count++;
                return ptr;
            }
            public TradeElementT* add_tradess(byte* buf, uint bufsz)
            {
                ushort offset = RecentFillsSnapshotInnerT.c_len;
                for (byte i = 0; i < inner->count; ++i)
                    offset += 72;
                if (bufsz < (offset + 72))
                    return null;
                if (bufsz - (layer_buf_ptr - buf) < 72)
                    return null;
                TradeElementT* ptr = TradeElementT.Emplace(layer_buf_ptr);
                byte* mem_ptr = layer_buf_ptr;
                layer_buf_ptr += 72;
                *len_ptr += 72;
                tradess.Add(mem_ptr);
                inner->count++;
                return ptr;
            }
            public ushort get_trades_count()
            {
                return (ushort)tradess.Count;
            }
            public void parse(byte* buf)
            {
                inner = (RecentFillsSnapshotInnerT*)buf;
                buf += RecentFillsSnapshotInnerT.c_len;
                tradess.SetBasePtr(buf);
                for (byte i = 0; i < inner->count; ++i)
                {
                    tradess.Add(buf);
                    buf += TradeElementT.c_len;
                }
            }
            public bool parse(byte* buf, uint bufsz)
            {
                if (bufsz < RecentFillsSnapshotInnerT.c_len)
                    return false;
                inner = (RecentFillsSnapshotInnerT*)buf;
                buf += RecentFillsSnapshotInnerT.c_len;
                if (bufsz < 0 + inner->count * 72)
                    return false;
                bufsz -= RecentFillsSnapshotInnerT.c_len;
                tradess.SetBasePtr(buf);
                for (byte i = 0; i < inner->count; ++i)
                {
                    tradess.Add(buf);
                    buf += TradeElementT.c_len;
                    bufsz -= TradeElementT.c_len;
                }
                return true;
            }
            public bool copy_into(byte* buf, uint bufsz)
            {
                if (Length > bufsz)
                    return false;
                byte* ptr = buffer_ptr();
                for (ushort i = 0; i < Length; ++i)
                    buf[i] = ptr[i];
                return true;
            }
            public byte* buffer_ptr()
            {
                return (byte*)inner;
            }
            public void construct(byte* buf)
            {
                inner = (RecentFillsSnapshotInnerT*)buf;
                inner->len = RecentFillsSnapshotInnerT.c_len;
                inner->msg_type = RecentFillsSnapshotInnerT.c_msg_type;
                len_ptr = &inner->len;
                layer_buf_ptr = buf + RecentFillsSnapshotInnerT.c_len;
                *len_ptr += RecentFillsSnapshotInnerT.c_len;
            }
            public bool construct(byte* buf, uint bufsz)
            {
                if (bufsz < RecentFillsSnapshotInnerT.c_len)
                    return false;
                inner = (RecentFillsSnapshotInnerT*)buf;
                inner->len = RecentFillsSnapshotInnerT.c_len;
                inner->msg_type = RecentFillsSnapshotInnerT.c_msg_type;
                len_ptr = &inner->len;
                layer_buf_ptr = buf + RecentFillsSnapshotInnerT.c_len;
                *len_ptr += RecentFillsSnapshotInnerT.c_len;
                return true;
            }
            public void clear()
            {
                inner = null;
                tradess.Clear();
            }
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<RecentFillsSnapshotT{ ");
                sb.Append($"count: {(uint)this.count}");
                for (byte idx = 0; idx < get_trades_count(); ++idx)
                {
                    sb.Append($", trades[{idx}]: {(*((TradeElementT*)tradess.Get(idx))).ToString()}");
                }
                sb.Append("}>");
                return sb.ToString();
            }
        }
        public unsafe class ListQuoterStrategiesSnapshotMsgT
        {
            private ListQuoterStrategiesSnapshotInnerT* inner = null;
            private PtrVectorT strategiess = new PtrVectorT();
            private byte* layer_buf_ptr = null;
            private ushort* len_ptr = null;

            public ushort Length
            {
                get
                {
                    if (inner != null)
                        return inner->len;
                    return 0;
                }
                set
                {
                    if (inner != null)
                        inner->len = value;
                }
            }
            public MsgTypeE MsgType
            {
                get
                {
                    if (inner != null)
                        return inner->msg_type;
                    return MsgTypeE.invalid;
                }
                set
                {
                    if (inner != null)
                        inner->msg_type = value;
                }
            }
            public Nullable<ushort> count
            {
                get
                {
                    if (inner == null)
                        return null;
                    return inner->count;
                }
                set
                {
                    if (inner == null)
                        return;
                    if (!value.HasValue)
                        inner->count = 0;
                    inner->count = value.Value;
                }
            }
            public Nullable<StrategyElementT> get_strategiess(byte idx)
            {
                if (idx > get_strategies_count())
                    return null;
                return *(StrategyElementT*)strategiess.Get(idx);
            }
            public List<StrategyElementT> get_strategiess()
            {
                List<StrategyElementT> l = new List<StrategyElementT>();
                for (byte idx = 0; idx < get_strategies_count(); ++idx)
                    l.Add(*(StrategyElementT*)strategiess.Get(idx));
                return l;
            }
            public StrategyElementT* add_strategiess(byte* buf)
            {
                ushort offset = ListQuoterStrategiesSnapshotInnerT.c_len;
                for (byte i = 0; i < inner->count; ++i)
                    offset += StrategyElementT.c_len;
                StrategyElementT* ptr = StrategyElementT.Emplace(layer_buf_ptr);
                byte* mem_ptr = layer_buf_ptr;
                layer_buf_ptr += 25;
                *len_ptr += 25;
                strategiess.Add(mem_ptr);
                inner->count++;
                return ptr;
            }
            public StrategyElementT* add_strategiess(byte* buf, uint bufsz)
            {
                ushort offset = ListQuoterStrategiesSnapshotInnerT.c_len;
                for (byte i = 0; i < inner->count; ++i)
                    offset += 25;
                if (bufsz < (offset + 25))
                    return null;
                if (bufsz - (layer_buf_ptr - buf) < 25)
                    return null;
                StrategyElementT* ptr = StrategyElementT.Emplace(layer_buf_ptr);
                byte* mem_ptr = layer_buf_ptr;
                layer_buf_ptr += 25;
                *len_ptr += 25;
                strategiess.Add(mem_ptr);
                inner->count++;
                return ptr;
            }
            public ushort get_strategies_count()
            {
                return (ushort)strategiess.Count;
            }
            public void parse(byte* buf)
            {
                inner = (ListQuoterStrategiesSnapshotInnerT*)buf;
                buf += ListQuoterStrategiesSnapshotInnerT.c_len;
                strategiess.SetBasePtr(buf);
                for (byte i = 0; i < inner->count; ++i)
                {
                    strategiess.Add(buf);
                    buf += StrategyElementT.c_len;
                }
            }
            public bool parse(byte* buf, uint bufsz)
            {
                if (bufsz < ListQuoterStrategiesSnapshotInnerT.c_len)
                    return false;
                inner = (ListQuoterStrategiesSnapshotInnerT*)buf;
                buf += ListQuoterStrategiesSnapshotInnerT.c_len;
                if (bufsz < 0 + inner->count * 25)
                    return false;
                bufsz -= ListQuoterStrategiesSnapshotInnerT.c_len;
                strategiess.SetBasePtr(buf);
                for (byte i = 0; i < inner->count; ++i)
                {
                    strategiess.Add(buf);
                    buf += StrategyElementT.c_len;
                    bufsz -= StrategyElementT.c_len;
                }
                return true;
            }
            public bool copy_into(byte* buf, uint bufsz)
            {
                if (Length > bufsz)
                    return false;
                byte* ptr = buffer_ptr();
                for (ushort i = 0; i < Length; ++i)
                    buf[i] = ptr[i];
                return true;
            }
            public byte* buffer_ptr()
            {
                return (byte*)inner;
            }
            public void construct(byte* buf)
            {
                inner = (ListQuoterStrategiesSnapshotInnerT*)buf;
                inner->len = ListQuoterStrategiesSnapshotInnerT.c_len;
                inner->msg_type = ListQuoterStrategiesSnapshotInnerT.c_msg_type;
                len_ptr = &inner->len;
                layer_buf_ptr = buf + ListQuoterStrategiesSnapshotInnerT.c_len;
                *len_ptr += ListQuoterStrategiesSnapshotInnerT.c_len;
            }
            public bool construct(byte* buf, uint bufsz)
            {
                if (bufsz < ListQuoterStrategiesSnapshotInnerT.c_len)
                    return false;
                inner = (ListQuoterStrategiesSnapshotInnerT*)buf;
                inner->len = ListQuoterStrategiesSnapshotInnerT.c_len;
                inner->msg_type = ListQuoterStrategiesSnapshotInnerT.c_msg_type;
                len_ptr = &inner->len;
                layer_buf_ptr = buf + ListQuoterStrategiesSnapshotInnerT.c_len;
                *len_ptr += ListQuoterStrategiesSnapshotInnerT.c_len;
                return true;
            }
            public void clear()
            {
                inner = null;
                strategiess.Clear();
            }
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<ListQuoterStrategiesSnapshotT{ ");
                sb.Append($"count: {(uint)this.count}");
                for (byte idx = 0; idx < get_strategies_count(); ++idx)
                {
                    sb.Append($", strategies[{idx}]: {(*((StrategyElementT*)strategiess.Get(idx))).ToString()}");
                }
                sb.Append("}>");
                return sb.ToString();
            }
        }
        public unsafe class BulkQtyRequestMsgT
        {
            private BulkQtyRequestInnerT* inner = null;
            private PtrVectorT requestss = new PtrVectorT();
            private byte* layer_buf_ptr = null;
            private ushort* len_ptr = null;

            public ushort Length
            {
                get
                {
                    if (inner != null)
                        return inner->len;
                    return 0;
                }
                set
                {
                    if (inner != null)
                        inner->len = value;
                }
            }
            public MsgTypeE MsgType
            {
                get
                {
                    if (inner != null)
                        return inner->msg_type;
                    return MsgTypeE.invalid;
                }
                set
                {
                    if (inner != null)
                        inner->msg_type = value;
                }
            }
            public Nullable<ushort> count
            {
                get
                {
                    if (inner == null)
                        return null;
                    return inner->count;
                }
                set
                {
                    if (inner == null)
                        return;
                    if (!value.HasValue)
                        inner->count = 0;
                    inner->count = value.Value;
                }
            }
            public Nullable<QtyReqElementT> get_requestss(byte idx)
            {
                if (idx > get_requests_count())
                    return null;
                return *(QtyReqElementT*)requestss.Get(idx);
            }
            public List<QtyReqElementT> get_requestss()
            {
                List<QtyReqElementT> l = new List<QtyReqElementT>();
                for (byte idx = 0; idx < get_requests_count(); ++idx)
                    l.Add(*(QtyReqElementT*)requestss.Get(idx));
                return l;
            }
            public QtyReqElementT* add_requestss(byte* buf)
            {
                ushort offset = BulkQtyRequestInnerT.c_len;
                for (byte i = 0; i < inner->count; ++i)
                    offset += QtyReqElementT.c_len;
                QtyReqElementT* ptr = QtyReqElementT.Emplace(layer_buf_ptr);
                byte* mem_ptr = layer_buf_ptr;
                layer_buf_ptr += 13;
                *len_ptr += 13;
                requestss.Add(mem_ptr);
                inner->count++;
                return ptr;
            }
            public QtyReqElementT* add_requestss(byte* buf, uint bufsz)
            {
                ushort offset = BulkQtyRequestInnerT.c_len;
                for (byte i = 0; i < inner->count; ++i)
                    offset += 13;
                if (bufsz < (offset + 13))
                    return null;
                if (bufsz - (layer_buf_ptr - buf) < 13)
                    return null;
                QtyReqElementT* ptr = QtyReqElementT.Emplace(layer_buf_ptr);
                byte* mem_ptr = layer_buf_ptr;
                layer_buf_ptr += 13;
                *len_ptr += 13;
                requestss.Add(mem_ptr);
                inner->count++;
                return ptr;
            }
            public ushort get_requests_count()
            {
                return (ushort)requestss.Count;
            }
            public void parse(byte* buf)
            {
                inner = (BulkQtyRequestInnerT*)buf;
                buf += BulkQtyRequestInnerT.c_len;
                requestss.SetBasePtr(buf);
                for (byte i = 0; i < inner->count; ++i)
                {
                    requestss.Add(buf);
                    buf += QtyReqElementT.c_len;
                }
            }
            public bool parse(byte* buf, uint bufsz)
            {
                if (bufsz < BulkQtyRequestInnerT.c_len)
                    return false;
                inner = (BulkQtyRequestInnerT*)buf;
                buf += BulkQtyRequestInnerT.c_len;
                if (bufsz < 0 + inner->count * 13)
                    return false;
                bufsz -= BulkQtyRequestInnerT.c_len;
                requestss.SetBasePtr(buf);
                for (byte i = 0; i < inner->count; ++i)
                {
                    requestss.Add(buf);
                    buf += QtyReqElementT.c_len;
                    bufsz -= QtyReqElementT.c_len;
                }
                return true;
            }
            public bool copy_into(byte* buf, uint bufsz)
            {
                if (Length > bufsz)
                    return false;
                byte* ptr = buffer_ptr();
                for (ushort i = 0; i < Length; ++i)
                    buf[i] = ptr[i];
                return true;
            }
            public byte* buffer_ptr()
            {
                return (byte*)inner;
            }
            public void construct(byte* buf)
            {
                inner = (BulkQtyRequestInnerT*)buf;
                inner->len = BulkQtyRequestInnerT.c_len;
                inner->msg_type = BulkQtyRequestInnerT.c_msg_type;
                len_ptr = &inner->len;
                layer_buf_ptr = buf + BulkQtyRequestInnerT.c_len;
                *len_ptr += BulkQtyRequestInnerT.c_len;
            }
            public bool construct(byte* buf, uint bufsz)
            {
                if (bufsz < BulkQtyRequestInnerT.c_len)
                    return false;
                inner = (BulkQtyRequestInnerT*)buf;
                inner->len = BulkQtyRequestInnerT.c_len;
                inner->msg_type = BulkQtyRequestInnerT.c_msg_type;
                len_ptr = &inner->len;
                layer_buf_ptr = buf + BulkQtyRequestInnerT.c_len;
                *len_ptr += BulkQtyRequestInnerT.c_len;
                return true;
            }
            public void clear()
            {
                inner = null;
                requestss.Clear();
            }
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<BulkQtyRequestT{ ");
                sb.Append($"count: {(uint)this.count}");
                for (byte idx = 0; idx < get_requests_count(); ++idx)
                {
                    sb.Append($", requests[{idx}]: {(*((QtyReqElementT*)requestss.Get(idx))).ToString()}");
                }
                sb.Append("}>");
                return sb.ToString();
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 3)]
        public struct HeaderT
        {
            public ushort len;
            public MsgTypeE msg_type;
        };
        public class Constants
        {
            public const byte HeaderLength = 3;
        }
    };
}