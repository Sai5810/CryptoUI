using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoUI.Protocol.manual_order_protocolN;

namespace CryptoUI.Panel.OrderManagement
{
    class OrderManagement
    {
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private GridControl gridControl;
        private DataTable dt;
        private GridControl fill_gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView fill_gridview;
        private DataTable fill_dt;
        private Dictionary<uint, Dictionary<uint, FillEnrichmentT>> cached_fill_enrichment;
        private Dictionary<uint, uint> instance_id_to_session_idx;
        private CryptoUI.App app;
        public OrderManagement(GridControl gridControlView, GridControl fillgridControlView, CryptoUI.App app, DevExpress.XtraGrid.Views.Grid.GridView fillgridview, DevExpress.XtraGrid.Views.Grid.GridView ordersgridview)
        {
            this.app = app;
            this.gridView = ordersgridview;
            this.gridControl = gridControlView;
            this.fill_gridview = fillgridview;
            cached_fill_enrichment = new Dictionary<uint, Dictionary<uint, FillEnrichmentT>>();
            instance_id_to_session_idx = new Dictionary<uint, uint>();
            this.dt = new DataTable();
            this.gridControl.DataSource = dt;
            dt.Columns.Add("LastUpdateTime");
            dt.Columns.Add("LastUpdateTimeNs");
            dt.Columns.Add("Symbol");
            dt.Columns.Add("Venue");
            dt.Columns.Add("Price");
            dt.Columns.Add("QuantityLeft");
            dt.Columns.Add("Side");
            dt.Columns.Add("IsTaking");
            dt.Columns.Add("ClOrdId");
            dt.Columns.Add("LastOrderState");
            dt.Columns.Add("OrderQty");
            dt.Columns.Add("OrderCreationTime");
            dt.Columns.Add("OrderCreationTimeNs");
            dt.Columns.Add("TIF");
            dt.Columns.Add("IsManual");
            dt.Columns.Add("AvgFillPx");
            dt.Columns.Add("SendingInstance");
            dt.Columns.Add("SendingLocation");
            dt.PrimaryKey = new DataColumn[] { dt.Columns["ClOrdId"] };
            this.fill_gridControl = fillgridControlView;
            this.fill_dt = new DataTable();
            this.fill_gridControl.DataSource = fill_dt;
            fill_dt.Columns.Add("ExecutionTime");
            fill_dt.Columns.Add("ExecutionTimeNs");
            fill_dt.Columns.Add("Symbol");
            fill_dt.Columns.Add("Venue");
            fill_dt.Columns.Add("FillPrice");
            fill_dt.Columns.Add("OrderPrice");
            fill_dt.Columns.Add("FillQuantity");
            fill_dt.Columns.Add("RemainingQuantity");
            fill_dt.Columns.Add("Side");
            fill_dt.Columns.Add("ClOrdId");
            fill_dt.Columns.Add("LiquidityCode");
            fill_dt.Columns.Add("Fair");
            fill_dt.Columns.Add("Edge");
            fill_dt.Columns.Add("Leader");
            fill_dt.Columns.Add("Strategy");
        }

        private void onUpdateOrderHelper(ref OrderUpdateT msg, uint session_idx)
        {
            DataRow row = dt.NewRow();
            row["LastUpdateTimeNs"] = msg.recv_ts.ToString();
            row["LastUpdateTime"] = epochNsToHumanTime(msg.recv_ts);
            if (msg.px == long.MaxValue && msg.exchange_id == 21 && (msg.TIF != TifTypeE.MOC && msg.TIF != TifTypeE.MOO))
            { // VWAP
                row["Venue"] = "BAML VWAP";
                row["Price"] = "VWAP";
            }
            else
            {
                //row["Venue"] = CryptoUI.Services.ExchangeDefinitionConfigService.Exists(msg.exchange_id) ? CryptoUI.Services.ExchangeDefinitionConfigService.GetExchange(msg.exchange_id) : $"[{msg.exchange_id}]";
                if (msg.px == long.MaxValue)
                    row["Price"] = "Market";
                else
                    row["Price"] = CryptoUI.Protocol.ProtocolUtilities.nanos_to_string(msg.px);
            }
            //row["Symbol"] = CryptoUI.Services.InstrumentIdSymbolConfigService.Exists(msg.instrument_id) ? CryptoUI.Services.InstrumentIdSymbolConfigService.GetSymbol(msg.instrument_id) : $"[{msg.instrument_id}]";
            row["Side"] = msg.is_bid ? "Bid" : "Ask";
            row["IsTaking"] = msg.is_taking.ToString();
            row["QuantityLeft"] = msg.qty.ToString();
            row["ClOrdId"] = msg.clordid.ToString();
            row["OrderQty"] = msg.qty.ToString();
            row["OrderCreationTimeNs"] = msg.exch_ts.ToString();
            row["OrderCreationTime"] = epochNsToHumanTime(msg.exch_ts);
            row["TIF"] = EnumStringsT.ToString(msg.TIF);
            row["IsManual"] = msg.is_manual ? "True" : "False";
            row["AvgFillPx"] = "";
            //row["SendingInstance"] = CryptoUI.Services.InstanceDefinitionConfigService.Exists(msg.sending_instance_id) ? $"{CryptoUI.Services.InstanceDefinitionConfigService.GetName(msg.sending_instance_id)} [{msg.sending_instance_id}]" : $"[{msg.sending_instance_id}]";
            //row["SendingLocation"] = CryptoUI.Services.DatacenterDefinitionConfigService.Exists(msg.sending_instance_id) ? CryptoUI.Services.DatacenterDefinitionConfigService.GetLocationName(msg.sending_location_id) : $"[{msg.sending_location_id}]";
            if (!instance_id_to_session_idx.ContainsKey((uint)msg.sending_instance_id))
            {
                instance_id_to_session_idx.Add((uint)msg.sending_instance_id, session_idx);
            }
            switch (msg.type)
            {
                case OrderUpdateTypeE.pending_new_order:
                    {
                        row["LastOrderState"] = "Pending";
                    }
                    break;
                case OrderUpdateTypeE.new_order:
                    {
                        row["LastOrderState"] = "Live";
                    }
                    break;
                case OrderUpdateTypeE.new_order_rejected:
                    {
                        row["LastOrderState"] = "Rejected";
                    }
                    break;
                case OrderUpdateTypeE.partially_filled:
                    {
                    }
                    break;
                case OrderUpdateTypeE.filled:
                    {
                        row["LastOrderState"] = "Filled";
                    }
                    break;
                case OrderUpdateTypeE.cancelled:
                    {
                        row["LastOrderState"] = "Cancelled";
                    }
                    break;
                case OrderUpdateTypeE.cancel_order_rejected:
                    {
                    }
                    break;
                case OrderUpdateTypeE.replaced:
                    {
                        row["LastOrderState"] = "Replaced";
                    }
                    break;
                case OrderUpdateTypeE.replace_rejected:
                    {
                    }
                    break;
                case OrderUpdateTypeE.invalid:
                default:
                    break;
            }
            dt.Rows.InsertAt(row, 0);
            gridView.FocusedRowHandle = 0;
        }
        public void onUpdateOrder(ref OrderUpdateT msg, uint session_idx)
        {
            CryptoUI.Network.Logger.Log(CryptoUI.Network.Logger.Level.info, msg.ToString());
            try
            {
                DataRow row = dt.Rows.Find(msg.clordid.ToString());
                if (row == null)
                {
                    onUpdateOrderHelper(ref msg, session_idx);
                    return;
                }
                row["QuantityLeft"] = msg.qty.ToString();
                row["AvgFillPx"] = "";
                switch (msg.type)
                {
                    case OrderUpdateTypeE.pending_new_order:
                        {
                            row["LastOrderState"] = "Pending";
                        }
                        break;
                    case OrderUpdateTypeE.new_order:
                        {
                            row["LastOrderState"] = "Live";
                        }
                        break;
                    case OrderUpdateTypeE.new_order_rejected:
                        {
                            row["LastOrderState"] = "Rejected";
                        }
                        break;
                    case OrderUpdateTypeE.partially_filled:
                        {
                        }
                        break;
                    case OrderUpdateTypeE.filled:
                        {
                            row["LastOrderState"] = "Filled";
                        }
                        break;
                    case OrderUpdateTypeE.cancelled:
                        {
                            row["LastOrderState"] = "Cancelled";
                        }
                        break;
                    case OrderUpdateTypeE.cancel_order_rejected:
                        {
                        }
                        break;
                    case OrderUpdateTypeE.replaced:
                        {
                            row["LastOrderState"] = "Replaced";
                        }
                        break;
                    case OrderUpdateTypeE.replace_rejected:
                        {
                            if (row["LastOrderState"] == null || row["LastOrderState"].ToString() == "" || row["LastOrderState"].ToString() == "Pending")
                                row["LastOrderState"] = "Replace Rejected";
                        }
                        break;
                    case OrderUpdateTypeE.invalid:
                    default:
                        break;
                }
            }
            catch (MissingPrimaryKeyException)
            {
                onUpdateOrderHelper(ref msg, session_idx);
            }
            catch (NullReferenceException)
            {
                onUpdateOrderHelper(ref msg, session_idx);
            }
        }
        private string epochNsToHumanTime(ulong ts)
        {
            DateTime epochTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime result = (epochTime.AddTicks((long)ts / 100)).ToLocalTime();
            //bool is_am = result.Hour < 12;
            //int hour = result.Hour % 12;
            //if (hour == 0)
            //    hour = 12;
            return $"{result.Hour.ToString("D2")}:{result.Minute.ToString("D2")}:{result.Second.ToString("D2")}.{result.Millisecond.ToString("D3")}{(ts % 1000000).ToString("D6")}";
        }

        public void onFillEnrichment(ref FillEnrichmentT msg, uint session_idx)
        {
            string clordid = msg.clordid.ToString();
            string executionid = msg.executionid.ToString();
            DataRow row = null;
            int c = 0;
            for (var i = fill_dt.Rows.Count - 1; i >= 0; i--)
            {
                ++c;
                if (c > 10)
                    break;
                DataRow r = fill_dt.Rows[i];
                if (r["ClOrdId"].ToString() != clordid)
                    continue;
                if (r["ExecutionId"].ToString() != executionid)
                    continue;
                row = r;
                break;
            }
            if (row == null)
            {
                if (!cached_fill_enrichment.ContainsKey(msg.clordid))
                    cached_fill_enrichment.Add(msg.clordid, new Dictionary<uint, FillEnrichmentT>());
                cached_fill_enrichment[msg.clordid].Add(msg.executionid, msg);
                return;
            }
            row["Fair"] = msg.fair_last_nanos == long.MaxValue ? "NaN" : (msg.fair_last_nanos / 1000000000.0).ToString("N03");
            bool is_bid = row["Side"].ToString() == "Bid";
            if (row["FillPrice"].ToString() == "NaN" || row["FillPrice"].ToString() == "" || msg.fair_last_nanos == long.MaxValue)
            {
                row["Edge"] = "NaN";
                return;
            }
            if (!decimal.TryParse(row["FillPrice"].ToString(), out decimal d)) return;
            long fillpx = (long)(d * 1000000000L);
            row["Edge"] = ((is_bid ? msg.fair_last_nanos - fillpx : fillpx - msg.fair_last_nanos) / 1000000000.0).ToString("N03");
            //row["Leader"] = CryptoUI.Services.InstrumentIdSymbolConfigService.Exists(msg.leader_instrument_id) ? CryptoUI.Services.InstrumentIdSymbolConfigService.GetSymbol(msg.leader_instrument_id) : $"[{msg.leader_instrument_id}]";
        }
        public void onNewFill(ref FillUpdateT msg, uint session_idx)
        {
            try
            {
                DataRow row = fill_dt.NewRow();
                row["ExecutionTime"] = epochNsToHumanTime(msg.exch_ts);
                row["ExecutionTimeNs"] = msg.exch_ts.ToString();
                //row["Symbol"] = CryptoUI.Services.InstrumentIdSymbolConfigService.Exists(msg.instrument_id) ? CryptoUI.Services.InstrumentIdSymbolConfigService.GetSymbol(msg.instrument_id) : $"[{msg.instrument_id}]";
                if (msg.exchange_id == 21 && msg.order_px == long.MaxValue)
                {
                    row["Venue"] = "BAML VWAP";
                    row["OrderPrice"] = "VWAP";
                }
                else
                {
                    //row["Venue"] = CryptoUI.Services.ExchangeDefinitionConfigService.Exists(msg.exchange_id) ? CryptoUI.Services.ExchangeDefinitionConfigService.GetExchange(msg.exchange_id) : $"[{msg.exchange_id}]";
                    if (msg.order_px == long.MaxValue)
                        row["OrderPrice"] = "Market";
                    else
                        row["OrderPrice"] = CryptoUI.Protocol.ProtocolUtilities.nanos_to_string(msg.order_px);
                }
                row["FillPrice"] = CryptoUI.Protocol.ProtocolUtilities.nanos_to_string(msg.fill_px);
                row["Side"] = msg.is_bid ? "Bid" : "Ask";
                row["FillQuantity"] = msg.fill_qty.ToString();
                row["RemainingQuantity"] = msg.qty_remaining.ToString();
                row["ClOrdId"] = msg.clordid.ToString();
                if (msg.exchange_id == 21)
                {
                    row["LiquidityCode"] = msg.liquidity_ind_value;
                    if (msg.liquidity_ind_value.Length == 0)
                        row["LiquidityCode"] = "U";
                    else
                    {
                        switch (msg.liquidity_ind_value[0])
                        {
                            case '1':
                                row["LiquidityCode"] = "A";
                                break;
                            case '2':
                                row["LiquidityCode"] = "R";
                                break;
                            case '3': // Liquidity Routed Out
                                row["LiquidityCode"] = "X";
                                break;
                            case '4': // Auction execution
                                row["LiquidityCode"] = "C";
                                break;
                            default:
                                row["LiquidityCode"] = "U";
                                break;
                        }
                    }
                }
                else
                    row["LiquidityCode"] = msg.liquidity_ind_value;
                if (cached_fill_enrichment.ContainsKey(msg.clordid))
                {
                    if (cached_fill_enrichment[msg.clordid].ContainsKey(msg.executionid))
                    {
                        var msg2 = cached_fill_enrichment[msg.clordid][msg.executionid];
                        row["Fair"] = msg2.fair_last_nanos == long.MaxValue ? "NaN" : (msg2.fair_last_nanos / 1000000000.0).ToString("N03");
                        bool is_bid = row["Side"].ToString() == "Bid";
                        if (row["FillPrice"].ToString() == "NaN" || row["FillPrice"].ToString() == "" || msg2.fair_last_nanos == long.MaxValue)
                            row["Edge"] = "NaN";
                        else
                        {
                            if (!decimal.TryParse(row["FillPrice"].ToString(), out decimal d)) return;
                            long fillpx = (long)(d * 1000000000L);
                            row["Edge"] = ((is_bid ? msg2.fair_last_nanos - fillpx : fillpx - msg2.fair_last_nanos) / 1000000000.0).ToString("N03");
                        }
                        //row["Leader"] = CryptoUI.Services.InstrumentIdSymbolConfigService.Exists(msg2.leader_instrument_id) ? CryptoUI.Services.InstrumentIdSymbolConfigService.GetSymbol(msg2.leader_instrument_id) : $"[{msg2.leader_instrument_id}]";
                        //row["Strategy"] = CryptoUI.App.get_strategy_name(row["Leader"].ToString(), row["Symbol"].ToString());
                        long edge = (is_bid ? msg2.fair_last_nanos - msg.fill_px : msg.fill_px - msg2.fair_last_nanos);
                        //app.GetEtfManager().OnEdgedTrade(row["Strategy"].ToString(), row["Symbol"].ToString(), row["Leader"].ToString(), msg.instrument_id, msg2.leader_instrument_id, edge, msg.fill_qty);
                        cached_fill_enrichment[msg.clordid].Remove(msg.executionid);
                        if (cached_fill_enrichment[msg.clordid].Count == 0)
                            cached_fill_enrichment.Remove(msg.clordid);
                    }
                }
                fill_dt.Rows.InsertAt(row, 0);
                fill_gridview.FocusedRowHandle = 0;
            }
            catch (MissingPrimaryKeyException)
            {
            }
            catch (NullReferenceException)
            {
            }
        }

        public uint getSessionIdxFromInstanceId(uint instance_id)
        {
            if (!instance_id_to_session_idx.ContainsKey(instance_id))
                return 0;
            return instance_id_to_session_idx[instance_id];
        }

        public void Clear()
        {
            dt.Rows.Clear();
        }
        public void ClearFills()
        {
            fill_dt.Rows.Clear();
        }
    }
}

namespace CryptoUI
{
    public class OrderHandle
    {
        public OrderHandle(uint clordid, ulong exchange_id, ulong instrument_id, long px, uint qty, ulong ts, uint instance_id)
        {
            this.clordid = clordid;
            this.exchange_id = exchange_id;
            this.instrument_id = instrument_id;
            this.px = px;
            this.qty = qty;
            this.ts = ts;
            this.instance_id = instance_id;
        }
        public uint clordid;
        public ulong exchange_id;
        public ulong instrument_id;
        public long px;
        public uint qty;
        public ulong ts;
        public uint instance_id;
    }
    public class ReplaceOrderDialogControl : DevExpress.XtraEditors.XtraUserControl
    {
        private OrderHandle myord;
        private DevExpress.XtraEditors.SimpleButton ok_button;
        private DevExpress.XtraEditors.TextEdit te_price;
        private DevExpress.XtraEditors.TextEdit te_qty;
        private bool px_ready;
        private bool qty_ready;

        public void SetOkButton(DevExpress.XtraEditors.SimpleButton ok_button)
        {
            this.ok_button = ok_button;
            if (px_ready && qty_ready)
                ok_button.Enabled = true;
            else
                ok_button.Enabled = false;
        }
        public ReplaceOrderDialogControl(OrderHandle ord)
        {
            this.myord = ord;
            this.px_ready = false;
            this.qty_ready = false;
            DevExpress.XtraLayout.LayoutControl lc = new DevExpress.XtraLayout.LayoutControl();
            lc.Dock = System.Windows.Forms.DockStyle.Fill;
            DevExpress.XtraEditors.TextEdit teClOrdId = new DevExpress.XtraEditors.TextEdit();
            teClOrdId.ReadOnly = true;
            teClOrdId.Text = ord.clordid.ToString();
            DevExpress.XtraEditors.TextEdit teSymbol = new DevExpress.XtraEditors.TextEdit();
            teSymbol.ReadOnly = true;
            //teSymbol.Text = Services.InstrumentIdSymbolConfigService.Exists(ord.instrument_id) ? Services.InstrumentIdSymbolConfigService.GetSymbol(ord.instrument_id) : $"[{ord.instrument_id}]";
            DevExpress.XtraEditors.TextEdit teVenue = new DevExpress.XtraEditors.TextEdit();
            teVenue.ReadOnly = true;
            //teVenue.Text = ord.exchange_id == 21 ? "BAML VWAP" : (Services.ExchangeDefinitionConfigService.Exists(ord.exchange_id) ? Services.ExchangeDefinitionConfigService.GetExchange(ord.exchange_id) : $"[{ord.exchange_id}]");
            DevExpress.XtraEditors.TextEdit tePrice = new DevExpress.XtraEditors.TextEdit();
            DevExpress.XtraEditors.TextEdit teQty = new DevExpress.XtraEditors.TextEdit();
            te_price = tePrice;
            te_qty = teQty;
            if (ord.px == long.MaxValue)
            {
                if (ord.exchange_id == 21)
                    tePrice.Text = "VWAP";
                else
                    tePrice.Text = "Market";
                tePrice.ReadOnly = true;
                te_price.ForeColor = System.Drawing.Color.Green;
                this.px_ready = true;
            }
            else
            {
                tePrice.Text = Protocol.ProtocolUtilities.nanos_to_string(ord.px);
                tePrice.EditValueChanging += Price_EditValueChanging;
                tePrice.LostFocus += Price_LostFocus;
                tePrice.GotFocus += Price_GotFocus;
                if (!decimal.TryParse(te_price.Text, out decimal unused))
                {
                    te_price.ForeColor = System.Drawing.Color.Red;
                    this.px_ready = false;
                }
                else
                {
                    te_price.ForeColor = System.Drawing.Color.Green;
                    this.px_ready = true;
                }
            }
            teQty.Text = ord.qty.ToString();
            teQty.EditValueChanging += Qty_EditValueChanging;
            teQty.LostFocus += Qty_LostFocus;
            teQty.GotFocus += Qty_GotFocus;
            lc.AddItem(String.Empty, teClOrdId).TextVisible = false;
            lc.AddItem(String.Empty, teSymbol).TextVisible = false;
            lc.AddItem(String.Empty, teVenue).TextVisible = false;
            lc.AddItem(String.Empty, tePrice).TextVisible = false;
            lc.AddItem(String.Empty, teQty).TextVisible = false;
            this.Controls.Add(lc);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            if (!uint.TryParse(te_qty.Text, out uint unused2) || unused2 < 1)
            {
                te_qty.ForeColor = System.Drawing.Color.Red;
                this.qty_ready = false;
            }
            else
            {
                te_qty.ForeColor = System.Drawing.Color.Green;
                this.qty_ready = true;
            }
        }

        public OrderHandle OrderDetails
        {
            get
            {
                return myord;
            }
        }
        private void Qty_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            string s = (string)e.NewValue;
            if (s == null || s.Length == 0)
                return;
            if (!uint.TryParse(s, out uint unused))
                e.Cancel = true;
            else
            {
                myord.qty = unused;
                if (unused >= 1)
                {
                    qty_ready = true;
                    if (px_ready && qty_ready)
                        ok_button.Enabled = true;
                }
            }
        }

        private void Price_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            string s = (string)e.NewValue;
            if (s == null || s.Length == 0)
                return;
            if (s.Length == 1 && (s[0] == '-' || s[0] == '.'))
                return;
            if (!decimal.TryParse(s, out decimal unused))
                e.Cancel = true;
            else
            {
                myord.px = (long)(unused * 1000000000L);
                px_ready = true;
                if (px_ready && qty_ready)
                    ok_button.Enabled = true;
            }
        }

        private void Price_GotFocus(object sender, EventArgs e)
        {
            te_price.ForeColor = System.Drawing.Color.White;
            this.px_ready = false;
        }
        private void Price_LostFocus(object sender, EventArgs e)
        {
            if (!decimal.TryParse(te_price.Text, out decimal unused))
            {
                te_price.ForeColor = System.Drawing.Color.Red;
                this.px_ready = false;
                return;
            }
            else
            {
                te_price.ForeColor = System.Drawing.Color.Green;
                this.px_ready = true;
                if (px_ready && qty_ready)
                    ok_button.Enabled = true;
                return;
            }
        }
        private void Qty_GotFocus(object sender, EventArgs e)
        {
            te_qty.ForeColor = System.Drawing.Color.White;
            this.qty_ready = false;
        }
        private void Qty_LostFocus(object sender, EventArgs e)
        {
            if (!uint.TryParse(te_qty.Text, out uint unused) || unused < 1)
            {
                te_qty.ForeColor = System.Drawing.Color.Red;
                this.qty_ready = false;
                return;
            }
            else
            {
                te_qty.ForeColor = System.Drawing.Color.Green;
                this.qty_ready = true;
                if (px_ready && qty_ready)
                    ok_button.Enabled = true;
                return;
            }
        }
    }
    public partial class App
    {
        private CryptoUI.Panel.OrderManagement.OrderManagement orderManagement;
        private uint cur_clid = 0;
        private DevExpress.XtraBars.BarManager orderManagementCancelAllBarManager;
        private DevExpress.XtraBars.PopupMenu orderManagementCancelAllPopupMenu;
        private DevExpress.XtraBars.BarButtonItem cancelMOCItem;
        private DevExpress.XtraEditors.XtraOpenFileDialog orderManagementUploadFileDialog;
        private DevExpress.XtraEditors.XtraOpenFileDialog orderManagementTradesExportCSVFileDialog;
        private DevExpress.XtraEditors.XtraOpenFileDialog orderManagementTradesExportPDFFileDialog;
        private DevExpress.XtraEditors.XtraOpenFileDialog orderManagementOrdersExportCSVFileDialog;
        private DevExpress.XtraEditors.XtraOpenFileDialog orderManagementOrdersExportPDFFileDialog;

        private void CancelAllMOC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            em.sendCancelAllMOCRequest(em.now());
        }

        public void onUpdateOrder(ref OrderUpdateT msg, uint session_idx)
        {
            if (InvokeRequired)
            {
                this.Invoke(new System.Action<OrderUpdateT, uint>(onUpdateOrder), new object[] { msg, session_idx });
                return;
            }
            this.orderManagement.onUpdateOrder(ref msg, session_idx);
        }
        public void onFillOrder(ref FillUpdateT msg, uint session_idx)
        {
            if (InvokeRequired)
            {
                this.Invoke(new System.Action<FillUpdateT, uint>(onFillOrder), new object[] { msg, session_idx });
                return;
            }
            this.orderManagement.onNewFill(ref msg, session_idx);
        }
        public void onFillOrder(FillUpdateT msg, uint session_idx)
        {
            this.orderManagement.onNewFill(ref msg, session_idx);
        }
        public void onUpdateOrder(OrderUpdateT msg, uint session_idx)
        {
            this.orderManagement.onUpdateOrder(ref msg, session_idx);
        }
        public void onExchangeConnectionStatusNotification(ref ExchangeConnectionStatusNotificationT msg, uint session_idx)
        {
            if (InvokeRequired)
            {
                this.Invoke(new System.Action<ExchangeConnectionStatusNotificationT, uint>(onExchangeConnectionStatusNotification), new object[] { msg, session_idx });
                return;
            }
            onExchangeConnectionStatusNotification_inner(ref msg, session_idx);
        }
        public void onStrategyStatusNotification(ref StrategyStatusNotificationT msg, uint session_idx)
        {
            if (InvokeRequired)
            {
                this.Invoke(new System.Action<StrategyStatusNotificationT, uint>(onStrategyStatusNotification), new object[] { msg, session_idx });
                return;
            }
            onStrategyStatusNotification_inner(ref msg, session_idx);
        }

        public void onFillEnrichment(ref Protocol.manual_order_protocolN.FillEnrichmentT msg, uint session_idx)
        {
            Network.Logger.Log(Network.Logger.Level.info, msg.ToString());
            if (InvokeRequired)
            {
                this.Invoke(new System.Action<FillEnrichmentT, uint>(onFillEnrichment), new object[] { msg, session_idx });
                return;
            }
            onFillEnrichment_inner(ref msg, session_idx);
        }

        public void onFillEnrichment(Protocol.manual_order_protocolN.FillEnrichmentT msg, uint session_idx)
        {
            onFillEnrichment_inner(ref msg, session_idx);
        }

        public void onFillEnrichment_inner(ref Protocol.manual_order_protocolN.FillEnrichmentT msg, uint session_idx)
        {
            orderManagement.onFillEnrichment(ref msg, session_idx);
        }

        public void onExchangeConnectionStatusNotification(ExchangeConnectionStatusNotificationT msg, uint session_idx)
        {
            onExchangeConnectionStatusNotification_inner(ref msg, session_idx);
        }
        public void onStrategyStatusNotification(StrategyStatusNotificationT msg, uint session_idx)
        {
            onStrategyStatusNotification_inner(ref msg, session_idx);
        }

        public void onExchangeConnectionStatusNotification_inner(ref ExchangeConnectionStatusNotificationT msg, uint session_idx)
        {
            switch (msg.exchange_id)
            {
                case 1: // Binance
                    {
                        if (msg.is_connected)
                            orderManagementBinanceStatusBox.ForeColor = System.Drawing.Color.Green;
                        else
                            orderManagementBinanceStatusBox.ForeColor = System.Drawing.Color.Red;
                    }
                    break;
            }
        }
        public void onStrategyStatusNotification_inner(ref StrategyStatusNotificationT msg, uint session_idx)
        {
            Network.Logger.Log(Network.Logger.Level.info, msg.ToString());
            if (msg.is_valid && msg.is_enabled && msg.is_ready && msg.is_running && msg.is_broker_connected)
            {
                orderManagementStrategyStatusBox.ForeColor = System.Drawing.Color.Green;
                orderManagementStrategyStatusBox.Text = "Can Send";
            }
            else
            {
                orderManagementStrategyStatusBox.ForeColor = System.Drawing.Color.Red;
                if (!msg.is_valid)
                    orderManagementStrategyStatusBox.Text = "Invalid";
                else if (!msg.is_enabled)
                    orderManagementStrategyStatusBox.Text = "KillSwitched";
                else if (!msg.is_ready)
                    orderManagementStrategyStatusBox.Text = "Not Inited";
                else if (!msg.is_running)
                    orderManagementStrategyStatusBox.Text = "WebGUI Blocked";
                else if (!msg.is_broker_connected)
                    orderManagementStrategyStatusBox.Text = "SharedPos Blocked";
                else
                    orderManagementStrategyStatusBox.Text = "Unknown Block";
            }
        }
        private void InitializeOrderManagementClOrdId()
        {
            cur_clid = GetStartingClordid();
        }
        private unsafe void InitializeComponentOrderManagement()
        {
            orderManagementCancelAllBarManager = new DevExpress.XtraBars.BarManager();
            orderManagementCancelAllPopupMenu = new DevExpress.XtraBars.PopupMenu(orderManagementCancelAllBarManager);
            cancelMOCItem = new DevExpress.XtraBars.BarButtonItem(orderManagementCancelAllBarManager, "Cancel All MOC");
            cancelMOCItem.Tag = "cancelallmoc";
            cancelMOCItem.Size = new System.Drawing.Size { Width = 75, Height = 23 };
            orderManagementCancelAllPopupMenu.AddItem(cancelMOCItem);
            cancelMOCItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CancelAllMOC_ItemClick);
            orderManagementCancelAllButton.DropDownControl = orderManagementCancelAllPopupMenu;
            orderManagementCancelAllButton.Click += OrderManagementCancelAllButton_Click;
            orderManagementPanelSymbolBox.LostFocus += OrderManagementPanelSymbolBox_LostFocus;
            orderManagementPanelSymbolBox.GotFocus += OrderManagementPanelSymbolBox_GotFocus;
            orderManagementPanelVenueBox.LostFocus += OrderManagementPanelVenueBox_LostFocus;
            orderManagementPanelVenueBox.GotFocus += OrderManagementPanelVenueBox_GotFocus;
            orderManagementPanelPriceBox.EditValueChanging += OrderManagementPanelPriceBox_EditValueChanging;
            orderManagementPanelSharesBox.EditValueChanging += OrderManagementPanelSharesBox_EditValueChanging;
            //orderManagementPanelOrdersGridView.RowClick += OrderManagementPanelOrdersGridView_RowClick;
            orderManagementMaxParticipationPercentBox.EditValueChanging += OrderManagementMaxParticipationPercentBox_EditValueChanging;
            orderManagementVWAPButton.Click += OrderManagementVWAPButton_Click;
            orderManagementClearTradesButton.Click += OrderManagementClearTradesButton_Click;

            orderManagementTradesExportCSVFileDialog = new DevExpress.XtraEditors.XtraOpenFileDialog();
            orderManagementTradesExportPDFFileDialog = new DevExpress.XtraEditors.XtraOpenFileDialog();
            orderManagementOrdersExportCSVFileDialog = new DevExpress.XtraEditors.XtraOpenFileDialog();
            orderManagementOrdersExportPDFFileDialog = new DevExpress.XtraEditors.XtraOpenFileDialog();
            this.orderManagementPanelTradesGridView.PopupMenuShowing += OrderManagementPanelTradesGridView_PopupMenuShowing;

            orderManagementPanelOrdersGridView.OptionsMenu.EnableGroupRowMenu = true;
            orderManagementPanelOrdersGridView.PopupMenuShowing += OrderManagementPanelOrdersGridView_PopupMenuShowing;
            this.orderManagement = new CryptoUI.Panel.OrderManagement.OrderManagement(this.orderManagementPanelOrdersGridControl, this.orderManagementPanelTradesGridControl, this, this.orderManagementPanelTradesGridView, this.orderManagementPanelOrdersGridView);
            orderManagementUploadFileDialog = new DevExpress.XtraEditors.XtraOpenFileDialog();
            orderManagementMassActionUploadButton.Click += OrderManagementMassActionUploadButton_Click;
        }

        private void OrderManagementPanelTradesGridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Column)
            {
                DevExpress.Utils.Menu.DXSubMenuItem exportSubMenu = new DevExpress.Utils.Menu.DXSubMenuItem("Export");
                DevExpress.Utils.Menu.DXMenuItem export_csv_button_elm = new DevExpress.Utils.Menu.DXMenuItem("To CSV", new EventHandler(OnOrderManagementTradesExportCSVMenuClick));
                DevExpress.Utils.Menu.DXMenuItem export_pdf_button_elm = new DevExpress.Utils.Menu.DXMenuItem("To PDF", new EventHandler(OnOrderManagementTradesExportPDFMenuClick));
                exportSubMenu.Items.Add(export_csv_button_elm);
                exportSubMenu.Items.Add(export_pdf_button_elm);
                e.Menu.Items.Add(exportSubMenu);
            }
        }

        public void OnOrderManagementTradesExportPDFMenuClick(object sender, EventArgs e)
        {
            orderManagementTradesExportPDFFileDialog = new DevExpress.XtraEditors.XtraOpenFileDialog();
            orderManagementTradesExportPDFFileDialog.Title = "Save PDF to Export";
            orderManagementTradesExportPDFFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
            orderManagementTradesExportPDFFileDialog.FilterIndex = 2;
            orderManagementTradesExportPDFFileDialog.RestoreDirectory = true;
            orderManagementTradesExportPDFFileDialog.Multiselect = false;
            orderManagementTradesExportPDFFileDialog.AllowDragDrop = true;
            orderManagementTradesExportPDFFileDialog.CheckFileExists = false;
            orderManagementTradesExportPDFFileDialog.CheckPathExists = true;
            System.Windows.Forms.DialogResult res = orderManagementTradesExportPDFFileDialog.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
                this.orderManagementPanelTradesGridView.ExportToPdf(orderManagementTradesExportPDFFileDialog.FileName);
        }
        public void OnOrderManagementTradesExportCSVMenuClick(object sender, EventArgs e)
        {
            orderManagementTradesExportCSVFileDialog = new DevExpress.XtraEditors.XtraOpenFileDialog();
            orderManagementTradesExportCSVFileDialog.Title = "Save CSV to Export";
            orderManagementTradesExportCSVFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            orderManagementTradesExportCSVFileDialog.FilterIndex = 2;
            orderManagementTradesExportCSVFileDialog.RestoreDirectory = true;
            orderManagementTradesExportCSVFileDialog.Multiselect = false;
            orderManagementTradesExportCSVFileDialog.AllowDragDrop = true;
            orderManagementTradesExportCSVFileDialog.CheckFileExists = false;
            orderManagementTradesExportCSVFileDialog.CheckPathExists = true;
            System.Windows.Forms.DialogResult res = orderManagementTradesExportCSVFileDialog.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
                this.orderManagementPanelTradesGridView.ExportToCsv(orderManagementTradesExportCSVFileDialog.FileName);
        }

        public void OnOrderManagementOrdersExportPDFMenuClick(object sender, EventArgs e)
        {
            orderManagementOrdersExportPDFFileDialog = new DevExpress.XtraEditors.XtraOpenFileDialog();
            orderManagementOrdersExportPDFFileDialog.Title = "Save PDF to Export";
            orderManagementOrdersExportPDFFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
            orderManagementOrdersExportPDFFileDialog.FilterIndex = 2;
            orderManagementOrdersExportPDFFileDialog.RestoreDirectory = true;
            orderManagementOrdersExportPDFFileDialog.Multiselect = false;
            orderManagementOrdersExportPDFFileDialog.AllowDragDrop = true;
            orderManagementOrdersExportPDFFileDialog.CheckFileExists = false;
            orderManagementOrdersExportPDFFileDialog.CheckPathExists = true;
            System.Windows.Forms.DialogResult res = orderManagementOrdersExportPDFFileDialog.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
                this.orderManagementPanelOrdersGridView.ExportToPdf(orderManagementOrdersExportPDFFileDialog.FileName);
        }
        public void OnOrderManagementOrdersExportCSVMenuClick(object sender, EventArgs e)
        {
            orderManagementOrdersExportCSVFileDialog = new DevExpress.XtraEditors.XtraOpenFileDialog();
            orderManagementOrdersExportCSVFileDialog.Title = "Save CSV to Export";
            orderManagementOrdersExportCSVFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            orderManagementOrdersExportCSVFileDialog.FilterIndex = 2;
            orderManagementOrdersExportCSVFileDialog.RestoreDirectory = true;
            orderManagementOrdersExportCSVFileDialog.Multiselect = false;
            orderManagementOrdersExportCSVFileDialog.AllowDragDrop = true;
            orderManagementOrdersExportCSVFileDialog.CheckFileExists = false;
            orderManagementOrdersExportCSVFileDialog.CheckPathExists = true;
            System.Windows.Forms.DialogResult res = orderManagementOrdersExportCSVFileDialog.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
                this.orderManagementPanelOrdersGridView.ExportToCsv(orderManagementOrdersExportCSVFileDialog.FileName);
        }

        private void OrderManagementMassActionUploadButton_Click(object sender, EventArgs e)
        {
            orderManagementUploadFileDialog.Title = "Pick Order Mass Action CSV to Apply";
            orderManagementUploadFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            orderManagementUploadFileDialog.FilterIndex = 2;
            orderManagementUploadFileDialog.RestoreDirectory = true;
            orderManagementUploadFileDialog.Multiselect = false;
            orderManagementUploadFileDialog.AllowDragDrop = true;
            orderManagementUploadFileDialog.CheckFileExists = true;
            orderManagementUploadFileDialog.CheckPathExists = true;
            System.Windows.Forms.DialogResult res = orderManagementUploadFileDialog.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                List<QtyReqElementT> bulk_req = new List<QtyReqElementT>();
                bool isFirst = true;
                using (System.IO.StreamReader reader = new System.IO.StreamReader(orderManagementUploadFileDialog.FileName))
                {
                    while (!reader.EndOfStream)
                    {
                        if (isFirst)
                        {
                            isFirst = false;
                            continue;
                        }
                        bool is_bulk = false;
                        string line = reader.ReadLine();
                        string[] values = line.Split(',');
                        // SYMBOL,SIDE,VENUE,QTY,PX,ORDER_TYPE,ACCOUNT
                        //ulong instrumentId = Services.InstrumentIdSymbolConfigService.Exists(values[0]) ? Services.InstrumentIdSymbolConfigService.GetId(values[0]) : ulong.MaxValue;
                        ulong instrumentId = 0; // TODO
                        bool is_bid;
                        ulong exchangeId;
                        long px;
                        byte pct;
                        if (instrumentId == ulong.MaxValue)
                            continue;
                        if (values[1].ToLower() == "ask" || values[1].ToLower() == "offer" || values[1].ToLower() == "sell")
                            is_bid = false;
                        else if (values[1].ToLower() == "bid" || values[1].ToLower() == "buy")
                            is_bid = true;
                        else
                            continue;
                        string key = values[2];
                        if (values[2].ToLower() == "cme")
                            key = "GLOBEX";
                        else if (values[2].ToLower() == "ubs" || values[2].ToLower() == "ubs_ats")
                            key = "UBS ATS";
                        else if (values[2].ToLower() == "cs" || values[2].ToLower() == "crossfinder")
                            key = "CS Crossfinder";
                        else if (values[2].ToLower() == "gs" || values[2].ToLower() == "sigmax")
                            key = "GS SIGMAX";
                        else if (values[2].ToLower() == "barclays" || values[2].ToLower() == "lx")
                            key = "Barclays LX";
                        else if (values[2].ToLower() == "virtu" || values[2].ToLower() == "matchIt")
                            key = "Virtu MatchIt";
                        else if (values[2].ToLower() == "nyse" || values[2].ToLower() == "nyse equities")
                            key = "NYSE Equities";
                        else if (values[2].ToLower() == "arca" || values[2].ToLower() == "arca equities" || values[2].ToLower() == "nyse arca equities")
                            key = "NYSE ARCA Equities";
                        else if (values[2].ToLower() == "national" || values[2].ToLower() == "national equities" || values[2].ToLower() == "nyse national equities" || values[2].ToLower() == "nyse national")
                            key = "NYSE National";
                        else if (values[2].ToLower() == "chxe" || values[2].ToLower() == "chicago")
                            key = "CHXE";
                        else if (values[2].ToLower() == "bzx" || values[2].ToLower() == "bzx equities" || values[2].ToLower() == "bats")
                            key = "BZX";
                        else if (values[2].ToLower() == "byx" || values[2].ToLower() == "byx equities")
                            key = "BYX";
                        else if (values[2].ToLower() == "edga" || values[2].ToLower() == "edga equities")
                            key = "EDGA";
                        else if (values[2].ToLower() == "edgx" || values[2].ToLower() == "edgx equities")
                            key = "EDGX Equities";
                        else if (values[2].ToLower() == "cbsx")
                            key = "CBSX";
                        else if (values[2].ToLower() == "bx")
                            key = "BX";
                        else if (values[2].ToLower() == "psx")
                            key = "PSX";
                        else if (values[2].ToLower() == "nasdaq")
                            key = "NASDAQ";
                        else if (values[2].ToLower() == "ise")
                            key = "ISE";
                        else if (values[2].ToLower() == "iex")
                            key = "iex";
                        else if (values[2].ToLower() == "level")
                            key = "Level";
                        else if (values[2].ToLower() == "miax" || values[2].ToLower() == "miax equities")
                            key = "MIAX Equities";
                        else if (values[2].ToLower() == "baml vwap" || values[2].ToLower() == "vwap" || values[2].ToLower() == "baml")
                            key = "BAML VWAP";
                        if (!Services.ExchangeDefinitionConfigService.ExistsText(key, true))
                        {
                            if (values[2].ToLower() == "bulk")
                            {
                                is_bulk = true;
                                exchangeId = Services.ExchangeDefinitionConfigService.GetId("BAML VWAP");
                            }
                            else
                                continue;
                        }
                        else
                        {
                            exchangeId = Services.ExchangeDefinitionConfigService.GetId(key);
                        }
                        if (!uint.TryParse(values[3], out uint qty))
                            continue;
                        if (!decimal.TryParse(values[4], out decimal dd))
                        {
                            if (values[4].ToLower() == "mkt" || values[4].ToLower() == "market")
                            {
                                px = long.MaxValue;
                                pct = 0;
                            }
                            else
                            {
                                Network.Logger.Log(Network.Logger.Level.info, $"Failed to parse price / pct field");
                                continue;
                            }
                        }
                        else
                        {
                            if (exchangeId == 21)
                            {
                                px = long.MaxValue;
                                pct = (byte)(ulong)dd;
                                if (pct <= 0 || pct > 100)
                                    continue;
                            }
                            else
                            {
                                px = (long)(dd * 1000000000L);
                                pct = 0;
                            }
                        }
                        if (values[5].ToLower() == "vwap")
                            if (exchangeId != 21)
                                continue;
                        HashSet<ulong> listingVenues = new HashSet<ulong>();
                        listingVenues.Add(1);
                        listingVenues.Add(2);
                        listingVenues.Add(3);
                        listingVenues.Add(6);
                        listingVenues.Add(12);
                        HashSet<string> normalOrderTypes = new HashSet<string>();
                        normalOrderTypes.Add("day");
                        normalOrderTypes.Add("postonly");
                        normalOrderTypes.Add("ioc");
                        normalOrderTypes.Add("moc");
                        normalOrderTypes.Add("moo");
                        if (values[5].ToLower() == "moc" || values[5].ToLower() == "moo")
                            if (!listingVenues.Contains(exchangeId))
                                continue;
                        ulong account_id = 0;
                        //ulong account_id = Services.AccountIdConfigService.Get(values[6]);
                        if (account_id == 0)
                            continue;
                        if (normalOrderTypes.Contains(values[5].ToLower()))
                        {
                            bool is_ioc = values[5].ToLower() == "ioc";
                            bool is_post_only = values[5].ToLower() == "day" || values[5].ToLower() == "postonly";
                            bool is_auction = values[5].ToLower() == "moc" || values[5].ToLower() == "moo";
                            bool is_moo = values[5].ToLower() == "moo";
                            sendNewOrderRequest(++cur_clid, exchangeId, instrumentId, px, qty, is_bid, is_ioc, is_post_only, false, is_auction, is_moo, (ushort)account_id, em.now(), 0);
                        }
                        else if (values[5].ToLower() == "vwap")
                        {
                            if (is_bulk)
                            {
                                QtyReqElementT elm;
                                elm.braavos_id = instrumentId;
                                elm.is_buy = is_bid;
                                elm.qty = qty;
                                bulk_req.Add(elm);
                                Network.Logger.Log(Network.Logger.Level.info, $"add bulk req {elm}");
                            }
                            else
                            {
                                sendNewVWAPOrderRequest(++cur_clid, instrumentId, pct, qty, is_bid, true, (ushort)account_id, 0, em.now(), 0);
                            }
                        }
                        else
                            continue;
                    }
                }
                if (bulk_req.Count > 0)
                {
                    Network.Logger.Log(Network.Logger.Level.info, $"sending bulk req {bulk_req.Count}");
                    bulk_qty_request(bulk_req, 0);
                }
            }
        }

        private void OrderManagementClearTradesButton_Click(object sender, EventArgs e)
        {
            orderManagement.ClearFills();
        }

        private void OrderManagementVWAPButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Services.InstrumentIdSymbolConfigService.Exists(orderManagementPanelSymbolBox.Text))
                {
                    orderManagementRequestStatus.Text = "Bad Symbol";
                    orderManagementRequestStatus.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                ulong instrument_id = Services.InstrumentIdSymbolConfigService.GetId(orderManagementPanelSymbolBox.Text);
                uint pct = uint.Parse(orderManagementMaxParticipationPercentBox.Text);
                uint shares = uint.Parse(orderManagementPanelSharesBox.Text);
                bool is_bid = orderManagementIsBidToggle.IsOn;
                bool is_participate_auction = false;
                ulong ts = this.em.now();
                ulong account_id = 0;
                //ulong account_id = Services.AccountIdConfigService.Get(orderManagementAccountPicker.Text);
                uint vwap_duration_minutes = 0;
                //if (uint.TryParse(orderManagementVWAPDurationBox.Text, out uint v))
                //    vwap_duration_minutes = v;
                if (account_id == 0)
                {
                    orderManagementRequestStatus.Text = "Bad Account";
                    orderManagementRequestStatus.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (!sendNewVWAPOrderRequest(++cur_clid, instrument_id, pct, shares, is_bid, is_participate_auction, (ushort)account_id, vwap_duration_minutes * 60, ts, 0))
                {
                    orderManagementRequestStatus.Text = "Bad Conn";
                    orderManagementRequestStatus.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                orderManagementRequestStatus.Text = "Sent";
                orderManagementRequestStatus.ForeColor = System.Drawing.Color.Green;
                return;
            }
            catch (Exception)
            {
                orderManagementRequestStatus.Text = "Exception";
                orderManagementRequestStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }

        private void OrderManagementMaxParticipationPercentBox_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            string s = (string)e.NewValue;
            if (s == null || s.Length == 0)
                return;
            if (!uint.TryParse(s, out uint pct))
                e.Cancel = true;
            if (pct == 0 || pct > 100)
                e.Cancel = true;
        }

        private void OrderManagementPanelOrdersGridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                int rowHandle = e.HitInfo.RowHandle;
                int j = orderManagementPanelOrdersGridView.GetDataSourceRowIndex(e.HitInfo.RowHandle);
                DataRow r = orderManagementPanelOrdersGridView.GetDataRow(e.HitInfo.RowHandle);
                if (!((r["LastOrderState"].ToString() == "Live") || (r["LastOrderState"].ToString() == "Pending")))
                {
                    e.Menu.Items.Clear();
                    e.Menu.Enabled = false;
                    return;
                }
                e.Menu.Enabled = true;
                e.Menu.Items.Clear();
                DevExpress.Utils.Menu.DXMenuItem cxlOrdMenuItem = new DevExpress.Utils.Menu.DXMenuItem("Cancel Order", new EventHandler(OnCancelMenuClick));
                DevExpress.Utils.Menu.DXMenuItem rplOrdMenuItem = new DevExpress.Utils.Menu.DXMenuItem("Replace Order", new EventHandler(OnReplaceMenuClick));
                ulong instrument_id = (r["Symbol"].ToString()[0] == '[') ? ulong.Parse(r["Symbol"].ToString().Substring(1, r["Symbol"].ToString().Length - 2)) : Services.InstrumentIdSymbolConfigService.GetId(r["Symbol"].ToString());
                ulong exchange_id;
                long px;
                if (r["Venue"].ToString() == "BAML VWAP" && r["Price"].ToString() == "VWAP")
                {
                    exchange_id = 21;
                    px = long.MaxValue;
                }
                else
                {
                    exchange_id = (r["Venue"].ToString()[0] == '[') ? ulong.Parse(r["Venue"].ToString().Substring(1, r["Venue"].ToString().Length - 2)) : Services.ExchangeDefinitionConfigService.GetId(r["Venue"].ToString());
                    if (r["Price"].ToString() == "Market")
                        px = long.MaxValue;
                    else
                        px = (long)(decimal.Parse(r["Price"].ToString()) * 1000000000L);
                }
                uint qty = uint.Parse(r["QuantityLeft"].ToString());
                uint clordid = uint.Parse(r["ClOrdId"].ToString());
                string instance_str = r["SendingInstance"].ToString();
                uint instance_id = 0;
                if (instance_str.StartsWith("["))
                {
                    if (uint.TryParse(instance_str.Substring(1, instance_str.Length - 2), out uint tmp_id))
                        instance_id = tmp_id;
                }
                else
                {
                    string[] tmp = instance_str.Split('[');
                    if (tmp.Length > 1)
                    {
                        if (uint.TryParse(tmp[1].Substring(0, tmp[1].Length), out uint tmp_id))
                            instance_id = tmp_id;
                    }
                }
                OrderHandle ordh = new OrderHandle(clordid, exchange_id, instrument_id, px, qty, em.now(), instance_id);
                cxlOrdMenuItem.Tag = ordh;
                rplOrdMenuItem.Tag = ordh;
                e.Menu.Items.Add(cxlOrdMenuItem);
                e.Menu.Items.Add(rplOrdMenuItem);
                DevExpress.Utils.Menu.DXSubMenuItem exportSubMenu = new DevExpress.Utils.Menu.DXSubMenuItem("Export");
                DevExpress.Utils.Menu.DXMenuItem export_csv_button_elm = new DevExpress.Utils.Menu.DXMenuItem("To CSV", new EventHandler(OnOrderManagementOrdersExportCSVMenuClick));
                DevExpress.Utils.Menu.DXMenuItem export_pdf_button_elm = new DevExpress.Utils.Menu.DXMenuItem("To PDF", new EventHandler(OnOrderManagementOrdersExportPDFMenuClick));
                exportSubMenu.Items.Add(export_csv_button_elm);
                exportSubMenu.Items.Add(export_pdf_button_elm);
                e.Menu.Items.Add(exportSubMenu);
            }
            else if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Column)
            {
                DevExpress.Utils.Menu.DXSubMenuItem exportSubMenu = new DevExpress.Utils.Menu.DXSubMenuItem("Export");
                DevExpress.Utils.Menu.DXMenuItem export_csv_button_elm = new DevExpress.Utils.Menu.DXMenuItem("To CSV", new EventHandler(OnOrderManagementOrdersExportCSVMenuClick));
                DevExpress.Utils.Menu.DXMenuItem export_pdf_button_elm = new DevExpress.Utils.Menu.DXMenuItem("To PDF", new EventHandler(OnOrderManagementOrdersExportPDFMenuClick));
                exportSubMenu.Items.Add(export_csv_button_elm);
                exportSubMenu.Items.Add(export_pdf_button_elm);
                e.Menu.Items.Add(exportSubMenu);
            }
        }

        void OnCancelMenuClick(object sender, EventArgs e)
        {
            DevExpress.Utils.Menu.DXMenuItem item = sender as DevExpress.Utils.Menu.DXMenuItem;
            OrderHandle info = item.Tag as OrderHandle;
            if (!em.sendCancelOrderRequest(info.clordid, info.exchange_id, info.instrument_id, info.ts, orderManagement.getSessionIdxFromInstanceId(info.instance_id)))
            {
                orderManagementRequestStatus.Text = "Bad Conn";
                orderManagementRequestStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                orderManagementRequestStatus.Text = "Sent Cancel";
                orderManagementRequestStatus.ForeColor = System.Drawing.Color.Green;
            }
        }

        void OnReplaceMenuClick(object sender, EventArgs e)
        {
            DevExpress.Utils.Menu.DXMenuItem item = sender as DevExpress.Utils.Menu.DXMenuItem;
            OrderHandle info = item.Tag as OrderHandle;
            ReplaceOrderDialogControl myControl = new ReplaceOrderDialogControl(info);
            DevExpress.XtraEditors.XtraDialogArgs args = new DevExpress.XtraEditors.XtraDialogArgs(caption: $"Replace {info.clordid}", content: myControl, buttons: new System.Windows.Forms.DialogResult[] { System.Windows.Forms.DialogResult.OK, System.Windows.Forms.DialogResult.Cancel });
            args.Showing += ReplaceDialog_Showing;
            if (DevExpress.XtraEditors.XtraDialog.Show(args) == System.Windows.Forms.DialogResult.OK)
            {
                if (!em.sendreplaceOrderRequest(info.clordid, ++cur_clid, info.exchange_id, info.instrument_id, info.px, info.qty, em.now(), orderManagement.getSessionIdxFromInstanceId(info.instance_id)))
                {
                    orderManagementRequestStatus.Text = "Bad Conn";
                    orderManagementRequestStatus.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    orderManagementRequestStatus.Text = "Sent Replace";
                    orderManagementRequestStatus.ForeColor = System.Drawing.Color.Green;
                }
            }
        }

        private void ReplaceDialog_Showing(object sender, DevExpress.XtraEditors.XtraMessageShowingArgs e)
        {
            DevExpress.XtraEditors.XtraDialogArgs args = (DevExpress.XtraEditors.XtraDialogArgs)sender;
            ReplaceOrderDialogControl dialog = args.Content as ReplaceOrderDialogControl;
            OrderHandle ord = dialog.OrderDetails;
            DevExpress.XtraEditors.SimpleButton ok = e.Form.AcceptButton as DevExpress.XtraEditors.SimpleButton;
            dialog.SetOkButton(ok);
        }

        //private void OrderManagementPanelOrdersGridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        //{
        //   if (e.Button != System.Windows.Forms.MouseButtons.Right)
        //      return;
        //   int j = orderManagementPanelOrdersGridView.GetDataSourceRowIndex(e.RowHandle);
        //   LoginUserControl myControl = new LoginUserControl();
        //   DevExpress.XtraEditors.XtraDialog.Show(myControl, "Sign in", System.Windows.Forms.MessageBoxButtons.OKCancel);
        //}

        private void OrderManagementPanelSharesBox_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            string s = (string)e.NewValue;
            if (s == null || s.Length == 0)
                return;
            if (!uint.TryParse(s, out uint unused))
                e.Cancel = true;
        }

        private void OrderManagementPanelPriceBox_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            string s = (string)e.NewValue;
            if (s == null || s.Length == 0)
                return;
            if (s.Length == 1 && (s[0] == '-' || s[0] == '.'))
                return;
            if (!decimal.TryParse(s, out decimal unused))
                e.Cancel = true;
        }

        private void OrderManagementPanelVenueBox_GotFocus(object sender, EventArgs e)
        {
            orderManagementPanelVenueBox.ToolTip = "";
            orderManagementPanelVenueBox.ForeColor = System.Drawing.Color.White;
        }

        private void OrderManagementPanelVenueBox_LostFocus(object sender, EventArgs e)
        {
            string key = orderManagementPanelVenueBox.Text;
            if (orderManagementPanelVenueBox.Text == "CME")
                key = "GLOBEX";
            else if (orderManagementPanelVenueBox.Text == "UBS" || orderManagementPanelVenueBox.Text == "UBS_ATS")
                key = "UBS ATS";
            else if (orderManagementPanelVenueBox.Text == "CS" || orderManagementPanelVenueBox.Text.ToLower() == "crossfinder")
                key = "CS Crossfinder";
            else if (orderManagementPanelVenueBox.Text == "GS" || orderManagementPanelVenueBox.Text == "SIGMAX")
                key = "GS SIGMAX";
            else if (orderManagementPanelVenueBox.Text.ToLower() == "barclays" || orderManagementPanelVenueBox.Text == "LX")
                key = "Barclays LX";
            else if (orderManagementPanelVenueBox.Text.ToLower() == "virtu" || orderManagementPanelVenueBox.Text.ToLower() == "matchIt")
                key = "Virtu MatchIt";
            if (!Services.ExchangeDefinitionConfigService.ExistsText(key, true))
            {
                orderManagementPanelVenueBox.ToolTip = "Bad Exchange";
                orderManagementPanelVenueBox.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                orderManagementPanelVenueBox.ToolTip = Services.ExchangeDefinitionConfigService.GetIdText(key, true).ToString();
                orderManagementPanelVenueBox.ForeColor = System.Drawing.Color.Green;
                return;
            }
        }

        private void OrderManagementPanelSymbolBox_GotFocus(object sender, EventArgs e)
        {
            orderManagementPanelSymbolBox.ToolTip = "";
            orderManagementPanelSymbolBox.ForeColor = System.Drawing.Color.White;
        }

        private void OrderManagementPanelSymbolBox_LostFocus(object sender, EventArgs e)
        {
            if (!Services.InstrumentIdSymbolConfigService.Exists(orderManagementPanelSymbolBox.Text))
            {
                orderManagementPanelSymbolBox.ToolTip = "Bad Symbol";
                orderManagementPanelSymbolBox.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                orderManagementPanelSymbolBox.ToolTip = Services.InstrumentIdSymbolConfigService.GetId(orderManagementPanelSymbolBox.Text).ToString();
                orderManagementPanelSymbolBox.ForeColor = System.Drawing.Color.Green;
                return;
            }
        }

        private void OrderManagementPanelSendOrderButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!Services.InstrumentIdSymbolConfigService.Exists(orderManagementPanelSymbolBox.Text))
                {
                    orderManagementRequestStatus.Text = "Bad Symbol";
                    orderManagementRequestStatus.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                ulong instrument_id = Services.InstrumentIdSymbolConfigService.GetId(orderManagementPanelSymbolBox.Text);
                string key = orderManagementPanelVenueBox.Text;
                if (orderManagementPanelVenueBox.Text == "CME")
                    key = "GLOBEX";
                else if (orderManagementPanelVenueBox.Text == "UBS" || orderManagementPanelVenueBox.Text == "UBS_ATS")
                    key = "UBS ATS";
                else if (orderManagementPanelVenueBox.Text == "CS" || orderManagementPanelVenueBox.Text.ToLower() == "crossfinder")
                    key = "CS Crossfinder";
                else if (orderManagementPanelVenueBox.Text == "GS" || orderManagementPanelVenueBox.Text == "SIGMAX")
                    key = "GS SIGMAX";
                else if (orderManagementPanelVenueBox.Text.ToLower() == "barclays" || orderManagementPanelVenueBox.Text == "LX")
                    key = "Barclays LX";
                else if (orderManagementPanelVenueBox.Text.ToLower() == "virtu" || orderManagementPanelVenueBox.Text.ToLower() == "matchIt")
                    key = "Virtu MatchIt";
                if (!Services.ExchangeDefinitionConfigService.ExistsText(key, true))
                {
                    orderManagementRequestStatus.Text = "Bad Exch";
                    orderManagementRequestStatus.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                ulong exchange_id = Services.ExchangeDefinitionConfigService.GetIdText(key, true);

                long px;
                decimal dd = decimal.Parse(orderManagementPanelPriceBox.Text);
                px = (long)(dd * 1000000000L);
                uint shares = uint.Parse(orderManagementPanelSharesBox.Text);
                bool is_bid = orderManagementIsBidToggle.IsOn;
                bool is_ioc = !orderMangementAggressionToggle.IsOn;
                bool is_post_only = orderMangementAggressionToggle.IsOn;
                bool is_auction = false;
                bool is_moo = false;
                bool is_hidden = false;
                ulong ts = this.em.now();
                ulong account_id = 0;
                //ulong account_id = Services.AccountIdConfigService.Get(orderManagementAccountPicker.Text);
                if (account_id == 0)
                {
                    orderManagementRequestStatus.Text = "Bad Account";
                    orderManagementRequestStatus.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (!sendNewOrderRequest(++cur_clid, exchange_id, instrument_id, px, shares, is_bid, is_ioc, is_post_only, is_hidden, is_auction, is_moo, (ushort)account_id, ts, 0))
                {
                    orderManagementRequestStatus.Text = "Bad Conn";
                    orderManagementRequestStatus.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                orderManagementRequestStatus.Text = "Sent";
                orderManagementRequestStatus.ForeColor = System.Drawing.Color.Green;
                return;
            }
            catch (Exception)
            {
                orderManagementRequestStatus.Text = "Exception";
                orderManagementRequestStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }
        public void onManualOrderConnectionStatusChanged(bool connected, uint session_idx)
        {
            if (InvokeRequired)
            {
                this.Invoke(new System.Action<bool, uint>(onManualOrderConnectionStatusChanged), new object[] { connected, session_idx });
                return;
            }
            if (connected)
            {
                orderManagerConnectionStatus.Text = "connected";
                orderManagerConnectionStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                orderManagerConnectionStatus.Text = "disconnected";
                orderManagerConnectionStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void OrderManagementCancelAllButton_Click(object sender, System.EventArgs e)
        {
            em.sendCancelAllRequest(0, 0);
        }

        private void OrderManagementClearGridButton_Click(object sender, System.EventArgs e)
        {
            orderManagement.Clear();
        }
    }
}