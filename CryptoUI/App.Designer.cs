namespace CryptoUI
{
    partial class App
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.orderManagementPanelOrdersGridControl = new DevExpress.XtraGrid.GridControl();
            this.orderManagementPanelOrdersGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ordersLastUpdateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ordersLastUpdateTimeNs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ordersSymbol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ordersVenue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ordersPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ordersQuantityLeft = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ordersSide = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ordersClOrdId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ordersIsTaking = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ordersLastOrderState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ordersOrderQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ordersOrderCreationTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ordersOrderCreationTimeNs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ordersTIF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ordersIsManual = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ordersAvgFillPx = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ordersSendingInstance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ordersSendingLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.orderManagementPanelTradesGridControl = new DevExpress.XtraGrid.GridControl();
            this.orderManagementPanelTradesGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tradesExecutionTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tradesExecutionTimeNs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tradesClOrdId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tradesSymbol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tradesVenue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tradesOrderPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tradesFillPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tradesRemainingQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tradesFillQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tradesOrderSide = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tradesFair = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tradesEdge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tradesLeader = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tradesStrategy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.orderManagementPanelSymbolLabel = new DevExpress.XtraEditors.LabelControl();
            this.orderManagementPanelVenueLabel = new DevExpress.XtraEditors.LabelControl();
            this.orderManagementPanelSymbolBox = new DevExpress.XtraEditors.TextEdit();
            this.orderManagementPanelVenueBox = new DevExpress.XtraEditors.TextEdit();
            this.orderManagementPanelSharesBox = new DevExpress.XtraEditors.TextEdit();
            this.orderManagementPanelPriceBox = new DevExpress.XtraEditors.TextEdit();
            this.orderManagementPanelSharesLabel = new DevExpress.XtraEditors.LabelControl();
            this.orderManagementPanelPriceLabel = new DevExpress.XtraEditors.LabelControl();
            this.orderManagementPanelSendOrderButton = new DevExpress.XtraEditors.SimpleButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dockManagerOrderManagement = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockParamManagementPanel = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer8 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.paramManagementMenuSplitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.paramManagementUploadButton = new DevExpress.XtraEditors.SimpleButton();
            this.paramManagementValueBox = new DevExpress.XtraEditors.TextEdit();
            this.paramManagementPriKeyBox = new DevExpress.XtraEditors.TextEdit();
            this.paramManagementSecKeyBox = new DevExpress.XtraEditors.TextEdit();
            this.paramManagementIdxBox = new DevExpress.XtraEditors.TextEdit();
            this.paramManagementParamTypeComboBox = new DevExpress.XtraEditors.ComboBoxEdit();
            this.paramManagementParamLevelComboBox = new DevExpress.XtraEditors.ComboBoxEdit();
            this.paramManagementDefineButton = new DevExpress.XtraEditors.SimpleButton();
            this.paramManagementParamNameBox = new DevExpress.XtraEditors.TextEdit();
            this.paramManagementSeqNoBox = new DevExpress.XtraEditors.TextEdit();
            this.paramManagementCurrentSeqNoLabel = new DevExpress.XtraEditors.LabelControl();
            this.paramManagementNumChangesBox = new DevExpress.XtraEditors.TextEdit();
            this.paramManagementClearButton = new DevExpress.XtraEditors.SimpleButton();
            this.paramManagementApplyButton = new DevExpress.XtraEditors.SimpleButton();
            this.paramManagementNumChangesLabel = new DevExpress.XtraEditors.LabelControl();
            this.paramManagementStatusBox = new DevExpress.XtraEditors.TextEdit();
            this.paramManagerGridControl = new DevExpress.XtraGrid.GridControl();
            this.paramManagerGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.paramGridName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.paramGridLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.paramGridType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.paramGridPrimary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.paramGridSecondary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.paramGridIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.paramGridValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dockOrderManagementPanel = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer6 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.orderManagementMenuSplitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.orderManagementMassActionUploadButton = new DevExpress.XtraEditors.SimpleButton();
            this.orderManagementAccountPicker = new DevExpress.XtraEditors.ComboBoxEdit();
            this.orderManagementCancelAllButton = new DevExpress.XtraEditors.DropDownButton();
            this.orderManagementBitkubStatusBox = new DevExpress.XtraEditors.TextEdit();
            this.orderManagementBitstampStatusBox = new DevExpress.XtraEditors.TextEdit();
            this.orderManagementBitrueStatusBox = new DevExpress.XtraEditors.TextEdit();
            this.orderManagerConnectionStatus = new DevExpress.XtraEditors.TextEdit();
            this.orderManagementCryptocomStatusBox = new DevExpress.XtraEditors.TextEdit();
            this.orderManagementFollowToggle = new DevExpress.XtraEditors.ToggleSwitch();
            this.orderManagementBitgetStatusBox = new DevExpress.XtraEditors.TextEdit();
            this.orderManagementUpbitStatusBox = new DevExpress.XtraEditors.TextEdit();
            this.orderManagementbitFlyerStatusBox = new DevExpress.XtraEditors.TextEdit();
            this.orderManagementBithumbStatusBox = new DevExpress.XtraEditors.TextEdit();
            this.orderManagementPhemexStatusBox = new DevExpress.XtraEditors.TextEdit();
            this.orderManagementMEXCStatusBox = new DevExpress.XtraEditors.TextEdit();
            this.orderManagementHTXStatusBox = new DevExpress.XtraEditors.TextEdit();
            this.orderManagementIsBidToggle = new DevExpress.XtraEditors.ToggleSwitch();
            this.orderManagementCMEStatusBox = new DevExpress.XtraEditors.TextEdit();
            this.orderMangementAggressionToggle = new DevExpress.XtraEditors.ToggleSwitch();
            this.orderManagementDeribitStatusBox = new DevExpress.XtraEditors.TextEdit();
            this.orderManagementBitfinexStatusBox = new DevExpress.XtraEditors.TextEdit();
            this.orderManagementKrakenStatusBox = new DevExpress.XtraEditors.TextEdit();
            this.orderManagementRequestStatus = new DevExpress.XtraEditors.TextEdit();
            this.orderManagementGateIOStatusBox = new DevExpress.XtraEditors.TextEdit();
            this.orderManagementVWAPPercentLabel = new DevExpress.XtraEditors.LabelControl();
            this.orderManagementCoinbaseStatusBox = new DevExpress.XtraEditors.TextEdit();
            this.orderManagementMaxParticipationPercentBox = new DevExpress.XtraEditors.TextEdit();
            this.orderManagementKuCoinStatusBox = new DevExpress.XtraEditors.TextEdit();
            this.orderManagementVWAPButton = new DevExpress.XtraEditors.SimpleButton();
            this.orderManagementByBitStatusBox = new DevExpress.XtraEditors.TextEdit();
            this.orderManagementStrategyStatusLabel = new DevExpress.XtraEditors.LabelControl();
            this.orderManagementOKEXStatusBox = new DevExpress.XtraEditors.TextEdit();
            this.orderManagementStrategyStatusBox = new DevExpress.XtraEditors.TextEdit();
            this.orderManagementBinanceStatusBox = new DevExpress.XtraEditors.TextEdit();
            this.orderManagementClearTradesButton = new DevExpress.XtraEditors.SimpleButton();
            this.orderManagementClearGridButton = new DevExpress.XtraEditors.SimpleButton();
            this.orderManagementSplitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementPanelOrdersGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementPanelOrdersGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementPanelTradesGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementPanelTradesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementPanelSymbolBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementPanelVenueBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementPanelSharesBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementPanelPriceBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManagerOrderManagement)).BeginInit();
            this.dockParamManagementPanel.SuspendLayout();
            this.controlContainer8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paramManagementMenuSplitContainerControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paramManagementMenuSplitContainerControl.Panel1)).BeginInit();
            this.paramManagementMenuSplitContainerControl.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paramManagementMenuSplitContainerControl.Panel2)).BeginInit();
            this.paramManagementMenuSplitContainerControl.Panel2.SuspendLayout();
            this.paramManagementMenuSplitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paramManagementValueBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paramManagementPriKeyBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paramManagementSecKeyBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paramManagementIdxBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paramManagementParamTypeComboBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paramManagementParamLevelComboBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paramManagementParamNameBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paramManagementSeqNoBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paramManagementNumChangesBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paramManagementStatusBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paramManagerGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paramManagerGridView)).BeginInit();
            this.dockOrderManagementPanel.SuspendLayout();
            this.controlContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementMenuSplitContainerControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementMenuSplitContainerControl.Panel1)).BeginInit();
            this.orderManagementMenuSplitContainerControl.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementMenuSplitContainerControl.Panel2)).BeginInit();
            this.orderManagementMenuSplitContainerControl.Panel2.SuspendLayout();
            this.orderManagementMenuSplitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementAccountPicker.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementBitkubStatusBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementBitstampStatusBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementBitrueStatusBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagerConnectionStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementCryptocomStatusBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementFollowToggle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementBitgetStatusBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementUpbitStatusBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementbitFlyerStatusBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementBithumbStatusBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementPhemexStatusBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementMEXCStatusBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementHTXStatusBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementIsBidToggle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementCMEStatusBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderMangementAggressionToggle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementDeribitStatusBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementBitfinexStatusBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementKrakenStatusBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementRequestStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementGateIOStatusBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementCoinbaseStatusBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementMaxParticipationPercentBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementKuCoinStatusBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementByBitStatusBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementOKEXStatusBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementStrategyStatusBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementBinanceStatusBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementSplitContainerControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementSplitContainerControl.Panel1)).BeginInit();
            this.orderManagementSplitContainerControl.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementSplitContainerControl.Panel2)).BeginInit();
            this.orderManagementSplitContainerControl.Panel2.SuspendLayout();
            this.orderManagementSplitContainerControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // orderManagementPanelOrdersGridControl
            // 
            this.orderManagementPanelOrdersGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderManagementPanelOrdersGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementPanelOrdersGridControl.Location = new System.Drawing.Point(0, 0);
            this.orderManagementPanelOrdersGridControl.MainView = this.orderManagementPanelOrdersGridView;
            this.orderManagementPanelOrdersGridControl.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementPanelOrdersGridControl.Name = "orderManagementPanelOrdersGridControl";
            this.orderManagementPanelOrdersGridControl.Size = new System.Drawing.Size(1910, 308);
            this.orderManagementPanelOrdersGridControl.TabIndex = 0;
            this.orderManagementPanelOrdersGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.orderManagementPanelOrdersGridView});
            // 
            // orderManagementPanelOrdersGridView
            // 
            this.orderManagementPanelOrdersGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ordersLastUpdateTime,
            this.ordersLastUpdateTimeNs,
            this.ordersSymbol,
            this.ordersVenue,
            this.ordersPrice,
            this.ordersQuantityLeft,
            this.ordersSide,
            this.ordersClOrdId,
            this.ordersIsTaking,
            this.ordersLastOrderState,
            this.ordersOrderQty,
            this.ordersOrderCreationTime,
            this.ordersOrderCreationTimeNs,
            this.ordersTIF,
            this.ordersIsManual,
            this.ordersAvgFillPx,
            this.ordersSendingInstance,
            this.ordersSendingLocation});
            this.orderManagementPanelOrdersGridView.DetailHeight = 431;
            this.orderManagementPanelOrdersGridView.GridControl = this.orderManagementPanelOrdersGridControl;
            this.orderManagementPanelOrdersGridView.Name = "orderManagementPanelOrdersGridView";
            this.orderManagementPanelOrdersGridView.OptionsBehavior.Editable = false;
            // 
            // ordersLastUpdateTime
            // 
            this.ordersLastUpdateTime.Caption = "LastUpdateTime";
            this.ordersLastUpdateTime.DisplayFormat.FormatString = "d";
            this.ordersLastUpdateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ordersLastUpdateTime.FieldName = "LastUpdateTime";
            this.ordersLastUpdateTime.MinWidth = 23;
            this.ordersLastUpdateTime.Name = "ordersLastUpdateTime";
            this.ordersLastUpdateTime.Visible = true;
            this.ordersLastUpdateTime.VisibleIndex = 0;
            this.ordersLastUpdateTime.Width = 87;
            // 
            // ordersLastUpdateTimeNs
            // 
            this.ordersLastUpdateTimeNs.Caption = "LastUpdateTimeNs";
            this.ordersLastUpdateTimeNs.FieldName = "LastUpdateTimeNs";
            this.ordersLastUpdateTimeNs.MinWidth = 23;
            this.ordersLastUpdateTimeNs.Name = "ordersLastUpdateTimeNs";
            this.ordersLastUpdateTimeNs.Visible = true;
            this.ordersLastUpdateTimeNs.VisibleIndex = 16;
            this.ordersLastUpdateTimeNs.Width = 87;
            // 
            // ordersSymbol
            // 
            this.ordersSymbol.Caption = "Symbol";
            this.ordersSymbol.FieldName = "Symbol";
            this.ordersSymbol.MinWidth = 23;
            this.ordersSymbol.Name = "ordersSymbol";
            this.ordersSymbol.Visible = true;
            this.ordersSymbol.VisibleIndex = 1;
            this.ordersSymbol.Width = 87;
            // 
            // ordersVenue
            // 
            this.ordersVenue.Caption = "Venue";
            this.ordersVenue.FieldName = "Venue";
            this.ordersVenue.MinWidth = 23;
            this.ordersVenue.Name = "ordersVenue";
            this.ordersVenue.Visible = true;
            this.ordersVenue.VisibleIndex = 2;
            this.ordersVenue.Width = 87;
            // 
            // ordersPrice
            // 
            this.ordersPrice.Caption = "Price";
            this.ordersPrice.FieldName = "Price";
            this.ordersPrice.MinWidth = 23;
            this.ordersPrice.Name = "ordersPrice";
            this.ordersPrice.Visible = true;
            this.ordersPrice.VisibleIndex = 3;
            this.ordersPrice.Width = 87;
            // 
            // ordersQuantityLeft
            // 
            this.ordersQuantityLeft.Caption = "QuantityLeft";
            this.ordersQuantityLeft.FieldName = "QuantityLeft";
            this.ordersQuantityLeft.MinWidth = 23;
            this.ordersQuantityLeft.Name = "ordersQuantityLeft";
            this.ordersQuantityLeft.Visible = true;
            this.ordersQuantityLeft.VisibleIndex = 6;
            this.ordersQuantityLeft.Width = 87;
            // 
            // ordersSide
            // 
            this.ordersSide.Caption = "Side";
            this.ordersSide.FieldName = "Side";
            this.ordersSide.MinWidth = 23;
            this.ordersSide.Name = "ordersSide";
            this.ordersSide.Visible = true;
            this.ordersSide.VisibleIndex = 4;
            this.ordersSide.Width = 87;
            // 
            // ordersClOrdId
            // 
            this.ordersClOrdId.Caption = "ClOrdId";
            this.ordersClOrdId.FieldName = "ClOrdId";
            this.ordersClOrdId.MinWidth = 23;
            this.ordersClOrdId.Name = "ordersClOrdId";
            this.ordersClOrdId.Visible = true;
            this.ordersClOrdId.VisibleIndex = 7;
            this.ordersClOrdId.Width = 87;
            // 
            // ordersIsTaking
            // 
            this.ordersIsTaking.Caption = "IsTaking";
            this.ordersIsTaking.FieldName = "IsTaking";
            this.ordersIsTaking.MinWidth = 23;
            this.ordersIsTaking.Name = "ordersIsTaking";
            this.ordersIsTaking.Visible = true;
            this.ordersIsTaking.VisibleIndex = 5;
            this.ordersIsTaking.Width = 87;
            // 
            // ordersLastOrderState
            // 
            this.ordersLastOrderState.Caption = "LastOrderState";
            this.ordersLastOrderState.FieldName = "LastOrderState";
            this.ordersLastOrderState.MinWidth = 23;
            this.ordersLastOrderState.Name = "ordersLastOrderState";
            this.ordersLastOrderState.Visible = true;
            this.ordersLastOrderState.VisibleIndex = 9;
            this.ordersLastOrderState.Width = 87;
            // 
            // ordersOrderQty
            // 
            this.ordersOrderQty.Caption = "OrderQty";
            this.ordersOrderQty.FieldName = "OrderQty";
            this.ordersOrderQty.MinWidth = 23;
            this.ordersOrderQty.Name = "ordersOrderQty";
            this.ordersOrderQty.Visible = true;
            this.ordersOrderQty.VisibleIndex = 8;
            this.ordersOrderQty.Width = 87;
            // 
            // ordersOrderCreationTime
            // 
            this.ordersOrderCreationTime.Caption = "OrderCreationTime";
            this.ordersOrderCreationTime.FieldName = "OrderCreationTime";
            this.ordersOrderCreationTime.MinWidth = 23;
            this.ordersOrderCreationTime.Name = "ordersOrderCreationTime";
            this.ordersOrderCreationTime.Visible = true;
            this.ordersOrderCreationTime.VisibleIndex = 10;
            this.ordersOrderCreationTime.Width = 87;
            // 
            // ordersOrderCreationTimeNs
            // 
            this.ordersOrderCreationTimeNs.Caption = "OrderCreationTimeNs";
            this.ordersOrderCreationTimeNs.FieldName = "OrderCreationTimeNs";
            this.ordersOrderCreationTimeNs.MinWidth = 23;
            this.ordersOrderCreationTimeNs.Name = "ordersOrderCreationTimeNs";
            this.ordersOrderCreationTimeNs.Visible = true;
            this.ordersOrderCreationTimeNs.VisibleIndex = 17;
            this.ordersOrderCreationTimeNs.Width = 87;
            // 
            // ordersTIF
            // 
            this.ordersTIF.Caption = "TIF";
            this.ordersTIF.FieldName = "TIF";
            this.ordersTIF.MinWidth = 23;
            this.ordersTIF.Name = "ordersTIF";
            this.ordersTIF.Visible = true;
            this.ordersTIF.VisibleIndex = 11;
            this.ordersTIF.Width = 87;
            // 
            // ordersIsManual
            // 
            this.ordersIsManual.Caption = "IsManual";
            this.ordersIsManual.FieldName = "IsManual";
            this.ordersIsManual.MinWidth = 23;
            this.ordersIsManual.Name = "ordersIsManual";
            this.ordersIsManual.Visible = true;
            this.ordersIsManual.VisibleIndex = 12;
            this.ordersIsManual.Width = 87;
            // 
            // ordersAvgFillPx
            // 
            this.ordersAvgFillPx.Caption = "AvgFillPx";
            this.ordersAvgFillPx.FieldName = "AvgFillPx";
            this.ordersAvgFillPx.MinWidth = 23;
            this.ordersAvgFillPx.Name = "ordersAvgFillPx";
            this.ordersAvgFillPx.Visible = true;
            this.ordersAvgFillPx.VisibleIndex = 13;
            this.ordersAvgFillPx.Width = 87;
            // 
            // ordersSendingInstance
            // 
            this.ordersSendingInstance.Caption = "SendingInstance";
            this.ordersSendingInstance.FieldName = "SendingInstance";
            this.ordersSendingInstance.MinWidth = 23;
            this.ordersSendingInstance.Name = "ordersSendingInstance";
            this.ordersSendingInstance.Visible = true;
            this.ordersSendingInstance.VisibleIndex = 14;
            this.ordersSendingInstance.Width = 87;
            // 
            // ordersSendingLocation
            // 
            this.ordersSendingLocation.Caption = "SendingLocation";
            this.ordersSendingLocation.FieldName = "SendingLocation";
            this.ordersSendingLocation.MinWidth = 23;
            this.ordersSendingLocation.Name = "ordersSendingLocation";
            this.ordersSendingLocation.Visible = true;
            this.ordersSendingLocation.VisibleIndex = 15;
            this.ordersSendingLocation.Width = 87;
            // 
            // orderManagementPanelTradesGridControl
            // 
            this.orderManagementPanelTradesGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderManagementPanelTradesGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementPanelTradesGridControl.Location = new System.Drawing.Point(0, 0);
            this.orderManagementPanelTradesGridControl.MainView = this.orderManagementPanelTradesGridView;
            this.orderManagementPanelTradesGridControl.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementPanelTradesGridControl.Name = "orderManagementPanelTradesGridControl";
            this.orderManagementPanelTradesGridControl.Size = new System.Drawing.Size(1910, 483);
            this.orderManagementPanelTradesGridControl.TabIndex = 1;
            this.orderManagementPanelTradesGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.orderManagementPanelTradesGridView});
            // 
            // orderManagementPanelTradesGridView
            // 
            this.orderManagementPanelTradesGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.tradesExecutionTime,
            this.tradesExecutionTimeNs,
            this.tradesClOrdId,
            this.tradesSymbol,
            this.tradesVenue,
            this.tradesOrderPrice,
            this.tradesFillPrice,
            this.tradesRemainingQuantity,
            this.tradesFillQuantity,
            this.tradesOrderSide,
            this.tradesFair,
            this.tradesEdge,
            this.tradesLeader,
            this.tradesStrategy});
            this.orderManagementPanelTradesGridView.DetailHeight = 431;
            this.orderManagementPanelTradesGridView.GridControl = this.orderManagementPanelTradesGridControl;
            this.orderManagementPanelTradesGridView.Name = "orderManagementPanelTradesGridView";
            this.orderManagementPanelTradesGridView.OptionsBehavior.AutoSelectAllInEditor = false;
            this.orderManagementPanelTradesGridView.OptionsBehavior.Editable = false;
            this.orderManagementPanelTradesGridView.OptionsBehavior.ReadOnly = true;
            this.orderManagementPanelTradesGridView.OptionsBehavior.SmartVertScrollBar = false;
            this.orderManagementPanelTradesGridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.orderManagementPanelTradesGridView.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.orderManagementPanelTradesGridView.OptionsSelection.UseIndicatorForSelection = false;
            this.orderManagementPanelTradesGridView.OptionsView.ShowIndicator = false;
            // 
            // tradesExecutionTime
            // 
            this.tradesExecutionTime.Caption = "ExecutionTime";
            this.tradesExecutionTime.FieldName = "ExecutionTime";
            this.tradesExecutionTime.MinWidth = 23;
            this.tradesExecutionTime.Name = "tradesExecutionTime";
            this.tradesExecutionTime.OptionsColumn.ReadOnly = true;
            this.tradesExecutionTime.Visible = true;
            this.tradesExecutionTime.VisibleIndex = 0;
            this.tradesExecutionTime.Width = 87;
            // 
            // tradesExecutionTimeNs
            // 
            this.tradesExecutionTimeNs.Caption = "ExecutionTimeNs";
            this.tradesExecutionTimeNs.FieldName = "ExecutionTimeNs";
            this.tradesExecutionTimeNs.MinWidth = 23;
            this.tradesExecutionTimeNs.Name = "tradesExecutionTimeNs";
            this.tradesExecutionTimeNs.OptionsColumn.ReadOnly = true;
            this.tradesExecutionTimeNs.Visible = true;
            this.tradesExecutionTimeNs.VisibleIndex = 9;
            this.tradesExecutionTimeNs.Width = 87;
            // 
            // tradesClOrdId
            // 
            this.tradesClOrdId.Caption = "ClOrdId";
            this.tradesClOrdId.FieldName = "ClOrdId";
            this.tradesClOrdId.MinWidth = 23;
            this.tradesClOrdId.Name = "tradesClOrdId";
            this.tradesClOrdId.OptionsColumn.ReadOnly = true;
            this.tradesClOrdId.Visible = true;
            this.tradesClOrdId.VisibleIndex = 8;
            this.tradesClOrdId.Width = 87;
            // 
            // tradesSymbol
            // 
            this.tradesSymbol.Caption = "Symbol";
            this.tradesSymbol.FieldName = "Symbol";
            this.tradesSymbol.MinWidth = 23;
            this.tradesSymbol.Name = "tradesSymbol";
            this.tradesSymbol.OptionsColumn.ReadOnly = true;
            this.tradesSymbol.Visible = true;
            this.tradesSymbol.VisibleIndex = 1;
            this.tradesSymbol.Width = 87;
            // 
            // tradesVenue
            // 
            this.tradesVenue.Caption = "Venue";
            this.tradesVenue.FieldName = "Venue";
            this.tradesVenue.MinWidth = 23;
            this.tradesVenue.Name = "tradesVenue";
            this.tradesVenue.OptionsColumn.ReadOnly = true;
            this.tradesVenue.Visible = true;
            this.tradesVenue.VisibleIndex = 2;
            this.tradesVenue.Width = 87;
            // 
            // tradesOrderPrice
            // 
            this.tradesOrderPrice.Caption = "OrderPrice";
            this.tradesOrderPrice.FieldName = "OrderPrice";
            this.tradesOrderPrice.MinWidth = 23;
            this.tradesOrderPrice.Name = "tradesOrderPrice";
            this.tradesOrderPrice.OptionsColumn.ReadOnly = true;
            this.tradesOrderPrice.Visible = true;
            this.tradesOrderPrice.VisibleIndex = 3;
            this.tradesOrderPrice.Width = 87;
            // 
            // tradesFillPrice
            // 
            this.tradesFillPrice.Caption = "FillPrice";
            this.tradesFillPrice.FieldName = "FillPrice";
            this.tradesFillPrice.MinWidth = 23;
            this.tradesFillPrice.Name = "tradesFillPrice";
            this.tradesFillPrice.OptionsColumn.ReadOnly = true;
            this.tradesFillPrice.Visible = true;
            this.tradesFillPrice.VisibleIndex = 4;
            this.tradesFillPrice.Width = 87;
            // 
            // tradesRemainingQuantity
            // 
            this.tradesRemainingQuantity.Caption = "RemainingQuantity";
            this.tradesRemainingQuantity.FieldName = "RemainingQuantity";
            this.tradesRemainingQuantity.MinWidth = 23;
            this.tradesRemainingQuantity.Name = "tradesRemainingQuantity";
            this.tradesRemainingQuantity.OptionsColumn.ReadOnly = true;
            this.tradesRemainingQuantity.Visible = true;
            this.tradesRemainingQuantity.VisibleIndex = 5;
            this.tradesRemainingQuantity.Width = 87;
            // 
            // tradesFillQuantity
            // 
            this.tradesFillQuantity.Caption = "FillQuantity";
            this.tradesFillQuantity.FieldName = "FillQuantity";
            this.tradesFillQuantity.MinWidth = 23;
            this.tradesFillQuantity.Name = "tradesFillQuantity";
            this.tradesFillQuantity.OptionsColumn.ReadOnly = true;
            this.tradesFillQuantity.Visible = true;
            this.tradesFillQuantity.VisibleIndex = 6;
            this.tradesFillQuantity.Width = 87;
            // 
            // tradesOrderSide
            // 
            this.tradesOrderSide.Caption = "Side";
            this.tradesOrderSide.FieldName = "Side";
            this.tradesOrderSide.MinWidth = 23;
            this.tradesOrderSide.Name = "tradesOrderSide";
            this.tradesOrderSide.OptionsColumn.ReadOnly = true;
            this.tradesOrderSide.Visible = true;
            this.tradesOrderSide.VisibleIndex = 7;
            this.tradesOrderSide.Width = 87;
            // 
            // tradesFair
            // 
            this.tradesFair.Caption = "Fair";
            this.tradesFair.FieldName = "Fair";
            this.tradesFair.MinWidth = 23;
            this.tradesFair.Name = "tradesFair";
            this.tradesFair.OptionsColumn.ReadOnly = true;
            this.tradesFair.Visible = true;
            this.tradesFair.VisibleIndex = 10;
            this.tradesFair.Width = 87;
            // 
            // tradesEdge
            // 
            this.tradesEdge.Caption = "Edge";
            this.tradesEdge.FieldName = "Edge";
            this.tradesEdge.MinWidth = 23;
            this.tradesEdge.Name = "tradesEdge";
            this.tradesEdge.OptionsColumn.ReadOnly = true;
            this.tradesEdge.Visible = true;
            this.tradesEdge.VisibleIndex = 11;
            this.tradesEdge.Width = 87;
            // 
            // tradesLeader
            // 
            this.tradesLeader.Caption = "Leader";
            this.tradesLeader.FieldName = "Leader";
            this.tradesLeader.MinWidth = 23;
            this.tradesLeader.Name = "tradesLeader";
            this.tradesLeader.OptionsColumn.ReadOnly = true;
            this.tradesLeader.Visible = true;
            this.tradesLeader.VisibleIndex = 12;
            this.tradesLeader.Width = 87;
            // 
            // tradesStrategy
            // 
            this.tradesStrategy.Caption = "Strategy";
            this.tradesStrategy.FieldName = "Strategy";
            this.tradesStrategy.MinWidth = 23;
            this.tradesStrategy.Name = "tradesStrategy";
            this.tradesStrategy.OptionsColumn.ReadOnly = true;
            this.tradesStrategy.Visible = true;
            this.tradesStrategy.VisibleIndex = 13;
            this.tradesStrategy.Width = 87;
            // 
            // orderManagementPanelSymbolLabel
            // 
            this.orderManagementPanelSymbolLabel.Location = new System.Drawing.Point(9, 7);
            this.orderManagementPanelSymbolLabel.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementPanelSymbolLabel.Name = "orderManagementPanelSymbolLabel";
            this.orderManagementPanelSymbolLabel.Size = new System.Drawing.Size(42, 16);
            this.orderManagementPanelSymbolLabel.TabIndex = 2;
            this.orderManagementPanelSymbolLabel.Text = "Symbol";
            // 
            // orderManagementPanelVenueLabel
            // 
            this.orderManagementPanelVenueLabel.Location = new System.Drawing.Point(9, 31);
            this.orderManagementPanelVenueLabel.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementPanelVenueLabel.Name = "orderManagementPanelVenueLabel";
            this.orderManagementPanelVenueLabel.Size = new System.Drawing.Size(36, 16);
            this.orderManagementPanelVenueLabel.TabIndex = 3;
            this.orderManagementPanelVenueLabel.Text = "Venue";
            // 
            // orderManagementPanelSymbolBox
            // 
            this.orderManagementPanelSymbolBox.Location = new System.Drawing.Point(90, 4);
            this.orderManagementPanelSymbolBox.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementPanelSymbolBox.Name = "orderManagementPanelSymbolBox";
            this.orderManagementPanelSymbolBox.Size = new System.Drawing.Size(117, 22);
            this.orderManagementPanelSymbolBox.TabIndex = 4;
            this.orderManagementPanelSymbolBox.EditValueChanged += new System.EventHandler(this.orderManagementPanelSymbolBox_EditValueChanged);
            // 
            // orderManagementPanelVenueBox
            // 
            this.orderManagementPanelVenueBox.Location = new System.Drawing.Point(90, 27);
            this.orderManagementPanelVenueBox.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementPanelVenueBox.Name = "orderManagementPanelVenueBox";
            this.orderManagementPanelVenueBox.Size = new System.Drawing.Size(117, 22);
            this.orderManagementPanelVenueBox.TabIndex = 5;
            // 
            // orderManagementPanelSharesBox
            // 
            this.orderManagementPanelSharesBox.Location = new System.Drawing.Point(90, 70);
            this.orderManagementPanelSharesBox.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementPanelSharesBox.Name = "orderManagementPanelSharesBox";
            this.orderManagementPanelSharesBox.Size = new System.Drawing.Size(117, 22);
            this.orderManagementPanelSharesBox.TabIndex = 9;
            // 
            // orderManagementPanelPriceBox
            // 
            this.orderManagementPanelPriceBox.Location = new System.Drawing.Point(90, 47);
            this.orderManagementPanelPriceBox.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementPanelPriceBox.Name = "orderManagementPanelPriceBox";
            this.orderManagementPanelPriceBox.Size = new System.Drawing.Size(117, 22);
            this.orderManagementPanelPriceBox.TabIndex = 8;
            // 
            // orderManagementPanelSharesLabel
            // 
            this.orderManagementPanelSharesLabel.Location = new System.Drawing.Point(9, 74);
            this.orderManagementPanelSharesLabel.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementPanelSharesLabel.Name = "orderManagementPanelSharesLabel";
            this.orderManagementPanelSharesLabel.Size = new System.Drawing.Size(40, 16);
            this.orderManagementPanelSharesLabel.TabIndex = 7;
            this.orderManagementPanelSharesLabel.Text = "Shares";
            // 
            // orderManagementPanelPriceLabel
            // 
            this.orderManagementPanelPriceLabel.Location = new System.Drawing.Point(9, 50);
            this.orderManagementPanelPriceLabel.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementPanelPriceLabel.Name = "orderManagementPanelPriceLabel";
            this.orderManagementPanelPriceLabel.Size = new System.Drawing.Size(28, 16);
            this.orderManagementPanelPriceLabel.TabIndex = 6;
            this.orderManagementPanelPriceLabel.Text = "Price";
            // 
            // orderManagementPanelSendOrderButton
            // 
            this.orderManagementPanelSendOrderButton.Location = new System.Drawing.Point(90, 102);
            this.orderManagementPanelSendOrderButton.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementPanelSendOrderButton.Name = "orderManagementPanelSendOrderButton";
            this.orderManagementPanelSendOrderButton.Size = new System.Drawing.Size(88, 28);
            this.orderManagementPanelSendOrderButton.TabIndex = 10;
            this.orderManagementPanelSendOrderButton.Text = "Send Order";
            this.orderManagementPanelSendOrderButton.Click += new System.EventHandler(this.OrderManagementPanelSendOrderButton_Click);
            // 
            // dockManagerOrderManagement
            // 
            this.dockManagerOrderManagement.Form = this;
            this.dockManagerOrderManagement.HiddenPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockParamManagementPanel});
            this.dockManagerOrderManagement.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockOrderManagementPanel});
            this.dockManagerOrderManagement.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl",
            "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"});
            // 
            // dockParamManagementPanel
            // 
            this.dockParamManagementPanel.Controls.Add(this.controlContainer8);
            this.dockParamManagementPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            this.dockParamManagementPanel.FloatSize = new System.Drawing.Size(1920, 1020);
            this.dockParamManagementPanel.ID = new System.Guid("b58f24e6-88cd-446c-89bb-445df7d273c3");
            this.dockParamManagementPanel.Location = new System.Drawing.Point(-32768, -32768);
            this.dockParamManagementPanel.Margin = new System.Windows.Forms.Padding(4);
            this.dockParamManagementPanel.Name = "dockParamManagementPanel";
            this.dockParamManagementPanel.OriginalSize = new System.Drawing.Size(800, 800);
            this.dockParamManagementPanel.SavedIndex = 1;
            this.dockParamManagementPanel.Size = new System.Drawing.Size(1920, 1020);
            this.dockParamManagementPanel.Text = "Param Management";
            this.dockParamManagementPanel.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // controlContainer8
            // 
            this.controlContainer8.Controls.Add(this.paramManagementMenuSplitContainerControl);
            this.controlContainer8.Location = new System.Drawing.Point(5, 56);
            this.controlContainer8.Margin = new System.Windows.Forms.Padding(4);
            this.controlContainer8.Name = "controlContainer8";
            this.controlContainer8.Size = new System.Drawing.Size(1910, 960);
            this.controlContainer8.TabIndex = 0;
            // 
            // paramManagementMenuSplitContainerControl
            // 
            this.paramManagementMenuSplitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paramManagementMenuSplitContainerControl.Horizontal = false;
            this.paramManagementMenuSplitContainerControl.Location = new System.Drawing.Point(0, 0);
            this.paramManagementMenuSplitContainerControl.Margin = new System.Windows.Forms.Padding(4);
            this.paramManagementMenuSplitContainerControl.Name = "paramManagementMenuSplitContainerControl";
            // 
            // paramManagementMenuSplitContainerControl.Panel1
            // 
            this.paramManagementMenuSplitContainerControl.Panel1.Controls.Add(this.paramManagementUploadButton);
            this.paramManagementMenuSplitContainerControl.Panel1.Controls.Add(this.paramManagementValueBox);
            this.paramManagementMenuSplitContainerControl.Panel1.Controls.Add(this.paramManagementPriKeyBox);
            this.paramManagementMenuSplitContainerControl.Panel1.Controls.Add(this.paramManagementSecKeyBox);
            this.paramManagementMenuSplitContainerControl.Panel1.Controls.Add(this.paramManagementIdxBox);
            this.paramManagementMenuSplitContainerControl.Panel1.Controls.Add(this.paramManagementParamTypeComboBox);
            this.paramManagementMenuSplitContainerControl.Panel1.Controls.Add(this.paramManagementParamLevelComboBox);
            this.paramManagementMenuSplitContainerControl.Panel1.Controls.Add(this.paramManagementDefineButton);
            this.paramManagementMenuSplitContainerControl.Panel1.Controls.Add(this.paramManagementParamNameBox);
            this.paramManagementMenuSplitContainerControl.Panel1.Controls.Add(this.paramManagementSeqNoBox);
            this.paramManagementMenuSplitContainerControl.Panel1.Controls.Add(this.paramManagementCurrentSeqNoLabel);
            this.paramManagementMenuSplitContainerControl.Panel1.Controls.Add(this.paramManagementNumChangesBox);
            this.paramManagementMenuSplitContainerControl.Panel1.Controls.Add(this.paramManagementClearButton);
            this.paramManagementMenuSplitContainerControl.Panel1.Controls.Add(this.paramManagementApplyButton);
            this.paramManagementMenuSplitContainerControl.Panel1.Controls.Add(this.paramManagementNumChangesLabel);
            this.paramManagementMenuSplitContainerControl.Panel1.Controls.Add(this.paramManagementStatusBox);
            this.paramManagementMenuSplitContainerControl.Panel1.Text = "Panel1";
            // 
            // paramManagementMenuSplitContainerControl.Panel2
            // 
            this.paramManagementMenuSplitContainerControl.Panel2.Controls.Add(this.paramManagerGridControl);
            this.paramManagementMenuSplitContainerControl.Panel2.Text = "Panel2";
            this.paramManagementMenuSplitContainerControl.Size = new System.Drawing.Size(1910, 960);
            this.paramManagementMenuSplitContainerControl.SplitterPosition = 98;
            this.paramManagementMenuSplitContainerControl.TabIndex = 0;
            // 
            // paramManagementUploadButton
            // 
            this.paramManagementUploadButton.Location = new System.Drawing.Point(910, 63);
            this.paramManagementUploadButton.Margin = new System.Windows.Forms.Padding(4);
            this.paramManagementUploadButton.Name = "paramManagementUploadButton";
            this.paramManagementUploadButton.Size = new System.Drawing.Size(88, 28);
            this.paramManagementUploadButton.TabIndex = 10;
            this.paramManagementUploadButton.Text = "Upload CSV";
            // 
            // paramManagementValueBox
            // 
            this.paramManagementValueBox.Location = new System.Drawing.Point(688, 66);
            this.paramManagementValueBox.Margin = new System.Windows.Forms.Padding(4);
            this.paramManagementValueBox.Name = "paramManagementValueBox";
            this.paramManagementValueBox.Properties.NullText = "<Value>";
            this.paramManagementValueBox.Size = new System.Drawing.Size(117, 22);
            this.paramManagementValueBox.TabIndex = 8;
            // 
            // paramManagementPriKeyBox
            // 
            this.paramManagementPriKeyBox.Location = new System.Drawing.Point(378, 65);
            this.paramManagementPriKeyBox.Margin = new System.Windows.Forms.Padding(4);
            this.paramManagementPriKeyBox.Name = "paramManagementPriKeyBox";
            this.paramManagementPriKeyBox.Properties.NullText = "<Primary Key>";
            this.paramManagementPriKeyBox.Size = new System.Drawing.Size(117, 22);
            this.paramManagementPriKeyBox.TabIndex = 5;
            // 
            // paramManagementSecKeyBox
            // 
            this.paramManagementSecKeyBox.Location = new System.Drawing.Point(502, 65);
            this.paramManagementSecKeyBox.Margin = new System.Windows.Forms.Padding(4);
            this.paramManagementSecKeyBox.Name = "paramManagementSecKeyBox";
            this.paramManagementSecKeyBox.Properties.NullText = "<Secondary Key>";
            this.paramManagementSecKeyBox.Size = new System.Drawing.Size(117, 22);
            this.paramManagementSecKeyBox.TabIndex = 6;
            // 
            // paramManagementIdxBox
            // 
            this.paramManagementIdxBox.Location = new System.Drawing.Point(623, 65);
            this.paramManagementIdxBox.Margin = new System.Windows.Forms.Padding(4);
            this.paramManagementIdxBox.Name = "paramManagementIdxBox";
            this.paramManagementIdxBox.Properties.NullText = "<Idx>";
            this.paramManagementIdxBox.Size = new System.Drawing.Size(58, 22);
            this.paramManagementIdxBox.TabIndex = 7;
            // 
            // paramManagementParamTypeComboBox
            // 
            this.paramManagementParamTypeComboBox.Location = new System.Drawing.Point(254, 65);
            this.paramManagementParamTypeComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.paramManagementParamTypeComboBox.Name = "paramManagementParamTypeComboBox";
            this.paramManagementParamTypeComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.paramManagementParamTypeComboBox.Properties.Items.AddRange(new object[] {
            "boolean",
            "uint8",
            "uint16",
            "uint32",
            "uint64",
            "int8",
            "int16",
            "int32",
            "int64",
            "char",
            "float",
            "double",
            "time_series_date_double_element",
            "time_series_datetime_double_element",
            "time_series_date_uint64_element",
            "time_series_datetime_uint64_element",
            "time_series_date_int64_element",
            "time_series_datetime_int64_element"});
            this.paramManagementParamTypeComboBox.Properties.NullText = "<Param Type>";
            this.paramManagementParamTypeComboBox.Size = new System.Drawing.Size(117, 22);
            this.paramManagementParamTypeComboBox.TabIndex = 4;
            // 
            // paramManagementParamLevelComboBox
            // 
            this.paramManagementParamLevelComboBox.Location = new System.Drawing.Point(131, 65);
            this.paramManagementParamLevelComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.paramManagementParamLevelComboBox.Name = "paramManagementParamLevelComboBox";
            this.paramManagementParamLevelComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.paramManagementParamLevelComboBox.Properties.Items.AddRange(new object[] {
            "global",
            "major",
            "minor",
            "instrument"});
            this.paramManagementParamLevelComboBox.Properties.NullText = "<Param Level>";
            this.paramManagementParamLevelComboBox.Size = new System.Drawing.Size(117, 22);
            this.paramManagementParamLevelComboBox.TabIndex = 3;
            // 
            // paramManagementDefineButton
            // 
            this.paramManagementDefineButton.Location = new System.Drawing.Point(817, 63);
            this.paramManagementDefineButton.Margin = new System.Windows.Forms.Padding(4);
            this.paramManagementDefineButton.Name = "paramManagementDefineButton";
            this.paramManagementDefineButton.Size = new System.Drawing.Size(88, 28);
            this.paramManagementDefineButton.TabIndex = 9;
            this.paramManagementDefineButton.Text = "Define Param";
            // 
            // paramManagementParamNameBox
            // 
            this.paramManagementParamNameBox.Location = new System.Drawing.Point(4, 65);
            this.paramManagementParamNameBox.Margin = new System.Windows.Forms.Padding(4);
            this.paramManagementParamNameBox.Name = "paramManagementParamNameBox";
            this.paramManagementParamNameBox.Properties.NullText = "<Param Name>";
            this.paramManagementParamNameBox.Size = new System.Drawing.Size(117, 22);
            this.paramManagementParamNameBox.TabIndex = 2;
            // 
            // paramManagementSeqNoBox
            // 
            this.paramManagementSeqNoBox.Location = new System.Drawing.Point(648, 6);
            this.paramManagementSeqNoBox.Margin = new System.Windows.Forms.Padding(4);
            this.paramManagementSeqNoBox.Name = "paramManagementSeqNoBox";
            this.paramManagementSeqNoBox.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.paramManagementSeqNoBox.Properties.Appearance.Options.UseForeColor = true;
            this.paramManagementSeqNoBox.Properties.NullText = "Invalid";
            this.paramManagementSeqNoBox.Properties.ReadOnly = true;
            this.paramManagementSeqNoBox.Size = new System.Drawing.Size(117, 22);
            this.paramManagementSeqNoBox.TabIndex = 65536;
            // 
            // paramManagementCurrentSeqNoLabel
            // 
            this.paramManagementCurrentSeqNoLabel.Location = new System.Drawing.Point(548, 9);
            this.paramManagementCurrentSeqNoLabel.Margin = new System.Windows.Forms.Padding(4);
            this.paramManagementCurrentSeqNoLabel.Name = "paramManagementCurrentSeqNoLabel";
            this.paramManagementCurrentSeqNoLabel.Size = new System.Drawing.Size(93, 16);
            this.paramManagementCurrentSeqNoLabel.TabIndex = 65536;
            this.paramManagementCurrentSeqNoLabel.Text = "Current SeqNo: ";
            // 
            // paramManagementNumChangesBox
            // 
            this.paramManagementNumChangesBox.Location = new System.Drawing.Point(420, 6);
            this.paramManagementNumChangesBox.Margin = new System.Windows.Forms.Padding(4);
            this.paramManagementNumChangesBox.Name = "paramManagementNumChangesBox";
            this.paramManagementNumChangesBox.Properties.NullText = "0";
            this.paramManagementNumChangesBox.Properties.ReadOnly = true;
            this.paramManagementNumChangesBox.Size = new System.Drawing.Size(117, 22);
            this.paramManagementNumChangesBox.TabIndex = 65536;
            // 
            // paramManagementClearButton
            // 
            this.paramManagementClearButton.Location = new System.Drawing.Point(233, 6);
            this.paramManagementClearButton.Margin = new System.Windows.Forms.Padding(4);
            this.paramManagementClearButton.Name = "paramManagementClearButton";
            this.paramManagementClearButton.Size = new System.Drawing.Size(88, 28);
            this.paramManagementClearButton.TabIndex = 1;
            this.paramManagementClearButton.Text = "Clear";
            // 
            // paramManagementApplyButton
            // 
            this.paramManagementApplyButton.Location = new System.Drawing.Point(139, 6);
            this.paramManagementApplyButton.Margin = new System.Windows.Forms.Padding(4);
            this.paramManagementApplyButton.Name = "paramManagementApplyButton";
            this.paramManagementApplyButton.Size = new System.Drawing.Size(88, 28);
            this.paramManagementApplyButton.TabIndex = 0;
            this.paramManagementApplyButton.Text = "Apply";
            // 
            // paramManagementNumChangesLabel
            // 
            this.paramManagementNumChangesLabel.Location = new System.Drawing.Point(332, 9);
            this.paramManagementNumChangesLabel.Margin = new System.Windows.Forms.Padding(4);
            this.paramManagementNumChangesLabel.Name = "paramManagementNumChangesLabel";
            this.paramManagementNumChangesLabel.Size = new System.Drawing.Size(82, 16);
            this.paramManagementNumChangesLabel.TabIndex = 65536;
            this.paramManagementNumChangesLabel.Text = "# of Changes:";
            // 
            // paramManagementStatusBox
            // 
            this.paramManagementStatusBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.paramManagementStatusBox.EditValue = "disconnected";
            this.paramManagementStatusBox.Location = new System.Drawing.Point(4, 6);
            this.paramManagementStatusBox.Margin = new System.Windows.Forms.Padding(4);
            this.paramManagementStatusBox.Name = "paramManagementStatusBox";
            this.paramManagementStatusBox.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.paramManagementStatusBox.Properties.Appearance.Options.UseForeColor = true;
            this.paramManagementStatusBox.Properties.ReadOnly = true;
            this.paramManagementStatusBox.Size = new System.Drawing.Size(117, 22);
            this.paramManagementStatusBox.TabIndex = 65536;
            // 
            // paramManagerGridControl
            // 
            this.paramManagerGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paramManagerGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.paramManagerGridControl.Location = new System.Drawing.Point(0, 0);
            this.paramManagerGridControl.MainView = this.paramManagerGridView;
            this.paramManagerGridControl.Margin = new System.Windows.Forms.Padding(4);
            this.paramManagerGridControl.Name = "paramManagerGridControl";
            this.paramManagerGridControl.Size = new System.Drawing.Size(1910, 850);
            this.paramManagerGridControl.TabIndex = 0;
            this.paramManagerGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.paramManagerGridView});
            // 
            // paramManagerGridView
            // 
            this.paramManagerGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.paramGridName,
            this.paramGridLevel,
            this.paramGridType,
            this.paramGridPrimary,
            this.paramGridSecondary,
            this.paramGridIndex,
            this.paramGridValue});
            this.paramManagerGridView.DetailHeight = 431;
            this.paramManagerGridView.GridControl = this.paramManagerGridControl;
            this.paramManagerGridView.Name = "paramManagerGridView";
            // 
            // paramGridName
            // 
            this.paramGridName.Caption = "Name";
            this.paramGridName.FieldName = "Name";
            this.paramGridName.MinWidth = 23;
            this.paramGridName.Name = "paramGridName";
            this.paramGridName.OptionsColumn.AllowEdit = false;
            this.paramGridName.Visible = true;
            this.paramGridName.VisibleIndex = 0;
            this.paramGridName.Width = 87;
            // 
            // paramGridLevel
            // 
            this.paramGridLevel.Caption = "Level";
            this.paramGridLevel.FieldName = "Level";
            this.paramGridLevel.MinWidth = 23;
            this.paramGridLevel.Name = "paramGridLevel";
            this.paramGridLevel.OptionsColumn.AllowEdit = false;
            this.paramGridLevel.Visible = true;
            this.paramGridLevel.VisibleIndex = 1;
            this.paramGridLevel.Width = 87;
            // 
            // paramGridType
            // 
            this.paramGridType.Caption = "Type";
            this.paramGridType.FieldName = "Type";
            this.paramGridType.MinWidth = 23;
            this.paramGridType.Name = "paramGridType";
            this.paramGridType.OptionsColumn.AllowEdit = false;
            this.paramGridType.Visible = true;
            this.paramGridType.VisibleIndex = 2;
            this.paramGridType.Width = 87;
            // 
            // paramGridPrimary
            // 
            this.paramGridPrimary.Caption = "Primary Key";
            this.paramGridPrimary.FieldName = "Primary";
            this.paramGridPrimary.MinWidth = 23;
            this.paramGridPrimary.Name = "paramGridPrimary";
            this.paramGridPrimary.OptionsColumn.AllowEdit = false;
            this.paramGridPrimary.Visible = true;
            this.paramGridPrimary.VisibleIndex = 3;
            this.paramGridPrimary.Width = 87;
            // 
            // paramGridSecondary
            // 
            this.paramGridSecondary.Caption = "Secondary Key";
            this.paramGridSecondary.FieldName = "Secondary";
            this.paramGridSecondary.MinWidth = 23;
            this.paramGridSecondary.Name = "paramGridSecondary";
            this.paramGridSecondary.OptionsColumn.AllowEdit = false;
            this.paramGridSecondary.Visible = true;
            this.paramGridSecondary.VisibleIndex = 4;
            this.paramGridSecondary.Width = 87;
            // 
            // paramGridIndex
            // 
            this.paramGridIndex.Caption = "Index";
            this.paramGridIndex.FieldName = "Index";
            this.paramGridIndex.MinWidth = 23;
            this.paramGridIndex.Name = "paramGridIndex";
            this.paramGridIndex.OptionsColumn.AllowEdit = false;
            this.paramGridIndex.Visible = true;
            this.paramGridIndex.VisibleIndex = 5;
            this.paramGridIndex.Width = 87;
            // 
            // paramGridValue
            // 
            this.paramGridValue.Caption = "Value";
            this.paramGridValue.FieldName = "Val";
            this.paramGridValue.MinWidth = 23;
            this.paramGridValue.Name = "paramGridValue";
            this.paramGridValue.Visible = true;
            this.paramGridValue.VisibleIndex = 6;
            this.paramGridValue.Width = 87;
            // 
            // dockOrderManagementPanel
            // 
            this.dockOrderManagementPanel.Controls.Add(this.controlContainer6);
            this.dockOrderManagementPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            this.dockOrderManagementPanel.FloatLocation = new System.Drawing.Point(-34, 5);
            this.dockOrderManagementPanel.FloatSize = new System.Drawing.Size(1920, 1020);
            this.dockOrderManagementPanel.ID = new System.Guid("a280f91e-53ff-40c7-ac2a-ec3d5de280be");
            this.dockOrderManagementPanel.Location = new System.Drawing.Point(0, 0);
            this.dockOrderManagementPanel.Margin = new System.Windows.Forms.Padding(4);
            this.dockOrderManagementPanel.Name = "dockOrderManagementPanel";
            this.dockOrderManagementPanel.OriginalSize = new System.Drawing.Size(512, 200);
            this.dockOrderManagementPanel.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockOrderManagementPanel.SavedIndex = 0;
            this.dockOrderManagementPanel.Size = new System.Drawing.Size(1920, 1020);
            this.dockOrderManagementPanel.Text = "Order Management";
            // 
            // controlContainer6
            // 
            this.controlContainer6.Controls.Add(this.orderManagementMenuSplitContainerControl);
            this.controlContainer6.Location = new System.Drawing.Point(5, 56);
            this.controlContainer6.Margin = new System.Windows.Forms.Padding(4);
            this.controlContainer6.Name = "controlContainer6";
            this.controlContainer6.Size = new System.Drawing.Size(1910, 960);
            this.controlContainer6.TabIndex = 0;
            // 
            // orderManagementMenuSplitContainerControl
            // 
            this.orderManagementMenuSplitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderManagementMenuSplitContainerControl.Horizontal = false;
            this.orderManagementMenuSplitContainerControl.Location = new System.Drawing.Point(0, 0);
            this.orderManagementMenuSplitContainerControl.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementMenuSplitContainerControl.Name = "orderManagementMenuSplitContainerControl";
            // 
            // orderManagementMenuSplitContainerControl.Panel1
            // 
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementMassActionUploadButton);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementAccountPicker);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementCancelAllButton);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementPanelSymbolLabel);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementPanelVenueLabel);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementBitkubStatusBox);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementPanelPriceLabel);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementBitstampStatusBox);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementPanelSharesLabel);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementBitrueStatusBox);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagerConnectionStatus);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementCryptocomStatusBox);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementFollowToggle);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementBitgetStatusBox);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementUpbitStatusBox);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementPanelSymbolBox);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementbitFlyerStatusBox);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementPanelVenueBox);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementBithumbStatusBox);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementPanelPriceBox);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementPhemexStatusBox);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementPanelSharesBox);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementMEXCStatusBox);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementPanelSendOrderButton);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementHTXStatusBox);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementIsBidToggle);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementCMEStatusBox);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderMangementAggressionToggle);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementDeribitStatusBox);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementBitfinexStatusBox);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementKrakenStatusBox);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementRequestStatus);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementGateIOStatusBox);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementVWAPPercentLabel);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementCoinbaseStatusBox);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementMaxParticipationPercentBox);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementKuCoinStatusBox);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementVWAPButton);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementByBitStatusBox);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementStrategyStatusLabel);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementOKEXStatusBox);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementStrategyStatusBox);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementBinanceStatusBox);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementClearTradesButton);
            this.orderManagementMenuSplitContainerControl.Panel1.Controls.Add(this.orderManagementClearGridButton);
            this.orderManagementMenuSplitContainerControl.Panel1.Text = "Menu";
            // 
            // orderManagementMenuSplitContainerControl.Panel2
            // 
            this.orderManagementMenuSplitContainerControl.Panel2.Controls.Add(this.orderManagementSplitContainerControl);
            this.orderManagementMenuSplitContainerControl.Panel2.Text = "Grids";
            this.orderManagementMenuSplitContainerControl.Size = new System.Drawing.Size(1910, 960);
            this.orderManagementMenuSplitContainerControl.SplitterPosition = 145;
            this.orderManagementMenuSplitContainerControl.TabIndex = 1039;
            // 
            // orderManagementMassActionUploadButton
            // 
            this.orderManagementMassActionUploadButton.Location = new System.Drawing.Point(502, 31);
            this.orderManagementMassActionUploadButton.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementMassActionUploadButton.Name = "orderManagementMassActionUploadButton";
            this.orderManagementMassActionUploadButton.Size = new System.Drawing.Size(82, 25);
            this.orderManagementMassActionUploadButton.TabIndex = 1040;
            this.orderManagementMassActionUploadButton.Text = "Upload";
            // 
            // orderManagementAccountPicker
            // 
            this.orderManagementAccountPicker.EditValue = "<Account>";
            this.orderManagementAccountPicker.Location = new System.Drawing.Point(502, 0);
            this.orderManagementAccountPicker.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementAccountPicker.Name = "orderManagementAccountPicker";
            this.orderManagementAccountPicker.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.orderManagementAccountPicker.Properties.Items.AddRange(new object[] {
            "MOC",
            "VWAP"});
            this.orderManagementAccountPicker.Properties.NullText = "<AccountType>";
            this.orderManagementAccountPicker.Size = new System.Drawing.Size(82, 22);
            this.orderManagementAccountPicker.TabIndex = 1039;
            // 
            // orderManagementCancelAllButton
            // 
            this.orderManagementCancelAllButton.Location = new System.Drawing.Point(257, 105);
            this.orderManagementCancelAllButton.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementCancelAllButton.Name = "orderManagementCancelAllButton";
            this.orderManagementCancelAllButton.Size = new System.Drawing.Size(88, 28);
            this.orderManagementCancelAllButton.TabIndex = 1005;
            this.orderManagementCancelAllButton.Text = "Cancel All";
            this.orderManagementCancelAllButton.ToolTip = "All Venues, All Symbols";
            // 
            // orderManagementBitkubStatusBox
            // 
            this.orderManagementBitkubStatusBox.EditValue = "Bitkub";
            this.orderManagementBitkubStatusBox.Enabled = false;
            this.orderManagementBitkubStatusBox.Location = new System.Drawing.Point(700, 118);
            this.orderManagementBitkubStatusBox.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementBitkubStatusBox.Name = "orderManagementBitkubStatusBox";
            this.orderManagementBitkubStatusBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.orderManagementBitkubStatusBox.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.orderManagementBitkubStatusBox.Properties.Appearance.Options.UseFont = true;
            this.orderManagementBitkubStatusBox.Properties.Appearance.Options.UseForeColor = true;
            this.orderManagementBitkubStatusBox.Size = new System.Drawing.Size(58, 22);
            this.orderManagementBitkubStatusBox.TabIndex = 1037;
            // 
            // orderManagementBitstampStatusBox
            // 
            this.orderManagementBitstampStatusBox.EditValue = "Bitstamp";
            this.orderManagementBitstampStatusBox.Enabled = false;
            this.orderManagementBitstampStatusBox.Location = new System.Drawing.Point(700, 98);
            this.orderManagementBitstampStatusBox.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementBitstampStatusBox.Name = "orderManagementBitstampStatusBox";
            this.orderManagementBitstampStatusBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.orderManagementBitstampStatusBox.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.orderManagementBitstampStatusBox.Properties.Appearance.Options.UseFont = true;
            this.orderManagementBitstampStatusBox.Properties.Appearance.Options.UseForeColor = true;
            this.orderManagementBitstampStatusBox.Size = new System.Drawing.Size(58, 22);
            this.orderManagementBitstampStatusBox.TabIndex = 1036;
            // 
            // orderManagementBitrueStatusBox
            // 
            this.orderManagementBitrueStatusBox.EditValue = "Bitrue";
            this.orderManagementBitrueStatusBox.Enabled = false;
            this.orderManagementBitrueStatusBox.Location = new System.Drawing.Point(700, 79);
            this.orderManagementBitrueStatusBox.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementBitrueStatusBox.Name = "orderManagementBitrueStatusBox";
            this.orderManagementBitrueStatusBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.orderManagementBitrueStatusBox.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.orderManagementBitrueStatusBox.Properties.Appearance.Options.UseFont = true;
            this.orderManagementBitrueStatusBox.Properties.Appearance.Options.UseForeColor = true;
            this.orderManagementBitrueStatusBox.Size = new System.Drawing.Size(58, 22);
            this.orderManagementBitrueStatusBox.TabIndex = 1035;
            // 
            // orderManagerConnectionStatus
            // 
            this.orderManagerConnectionStatus.EditValue = "disconnected";
            this.orderManagerConnectionStatus.Enabled = false;
            this.orderManagerConnectionStatus.Location = new System.Drawing.Point(4, 98);
            this.orderManagerConnectionStatus.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagerConnectionStatus.Name = "orderManagerConnectionStatus";
            this.orderManagerConnectionStatus.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7F);
            this.orderManagerConnectionStatus.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.orderManagerConnectionStatus.Properties.Appearance.Options.UseFont = true;
            this.orderManagerConnectionStatus.Properties.Appearance.Options.UseForeColor = true;
            this.orderManagerConnectionStatus.Size = new System.Drawing.Size(82, 22);
            this.orderManagerConnectionStatus.TabIndex = 999;
            this.orderManagerConnectionStatus.TabStop = false;
            // 
            // orderManagementCryptocomStatusBox
            // 
            this.orderManagementCryptocomStatusBox.EditValue = "Cryptocom";
            this.orderManagementCryptocomStatusBox.Enabled = false;
            this.orderManagementCryptocomStatusBox.Location = new System.Drawing.Point(700, 59);
            this.orderManagementCryptocomStatusBox.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementCryptocomStatusBox.Name = "orderManagementCryptocomStatusBox";
            this.orderManagementCryptocomStatusBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.orderManagementCryptocomStatusBox.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.orderManagementCryptocomStatusBox.Properties.Appearance.Options.UseFont = true;
            this.orderManagementCryptocomStatusBox.Properties.Appearance.Options.UseForeColor = true;
            this.orderManagementCryptocomStatusBox.Size = new System.Drawing.Size(58, 22);
            this.orderManagementCryptocomStatusBox.TabIndex = 1034;
            // 
            // orderManagementFollowToggle
            // 
            this.orderManagementFollowToggle.Location = new System.Drawing.Point(4, 123);
            this.orderManagementFollowToggle.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementFollowToggle.Name = "orderManagementFollowToggle";
            this.orderManagementFollowToggle.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.orderManagementFollowToggle.Properties.Appearance.Options.UseFont = true;
            this.orderManagementFollowToggle.Properties.AutoWidth = true;
            this.orderManagementFollowToggle.Properties.OffText = "Off";
            this.orderManagementFollowToggle.Properties.OnText = "On";
            this.orderManagementFollowToggle.Size = new System.Drawing.Size(66, 24);
            this.orderManagementFollowToggle.TabIndex = 1033;
            this.orderManagementFollowToggle.ToolTip = "(Off) Follow, (On) Freeze";
            // 
            // orderManagementBitgetStatusBox
            // 
            this.orderManagementBitgetStatusBox.EditValue = "Bitget";
            this.orderManagementBitgetStatusBox.Enabled = false;
            this.orderManagementBitgetStatusBox.Location = new System.Drawing.Point(700, 39);
            this.orderManagementBitgetStatusBox.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementBitgetStatusBox.Name = "orderManagementBitgetStatusBox";
            this.orderManagementBitgetStatusBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.orderManagementBitgetStatusBox.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.orderManagementBitgetStatusBox.Properties.Appearance.Options.UseFont = true;
            this.orderManagementBitgetStatusBox.Properties.Appearance.Options.UseForeColor = true;
            this.orderManagementBitgetStatusBox.Size = new System.Drawing.Size(58, 22);
            this.orderManagementBitgetStatusBox.TabIndex = 1031;
            // 
            // orderManagementUpbitStatusBox
            // 
            this.orderManagementUpbitStatusBox.EditValue = "Upbit";
            this.orderManagementUpbitStatusBox.Enabled = false;
            this.orderManagementUpbitStatusBox.Location = new System.Drawing.Point(700, 20);
            this.orderManagementUpbitStatusBox.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementUpbitStatusBox.Name = "orderManagementUpbitStatusBox";
            this.orderManagementUpbitStatusBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.orderManagementUpbitStatusBox.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.orderManagementUpbitStatusBox.Properties.Appearance.Options.UseFont = true;
            this.orderManagementUpbitStatusBox.Properties.Appearance.Options.UseForeColor = true;
            this.orderManagementUpbitStatusBox.Size = new System.Drawing.Size(58, 22);
            this.orderManagementUpbitStatusBox.TabIndex = 1030;
            // 
            // orderManagementbitFlyerStatusBox
            // 
            this.orderManagementbitFlyerStatusBox.EditValue = "bitFlyer";
            this.orderManagementbitFlyerStatusBox.Enabled = false;
            this.orderManagementbitFlyerStatusBox.Location = new System.Drawing.Point(700, 0);
            this.orderManagementbitFlyerStatusBox.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementbitFlyerStatusBox.Name = "orderManagementbitFlyerStatusBox";
            this.orderManagementbitFlyerStatusBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.orderManagementbitFlyerStatusBox.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.orderManagementbitFlyerStatusBox.Properties.Appearance.Options.UseFont = true;
            this.orderManagementbitFlyerStatusBox.Properties.Appearance.Options.UseForeColor = true;
            this.orderManagementbitFlyerStatusBox.Size = new System.Drawing.Size(58, 22);
            this.orderManagementbitFlyerStatusBox.TabIndex = 1029;
            // 
            // orderManagementBithumbStatusBox
            // 
            this.orderManagementBithumbStatusBox.EditValue = "Bithumb";
            this.orderManagementBithumbStatusBox.Enabled = false;
            this.orderManagementBithumbStatusBox.Location = new System.Drawing.Point(642, 118);
            this.orderManagementBithumbStatusBox.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementBithumbStatusBox.Name = "orderManagementBithumbStatusBox";
            this.orderManagementBithumbStatusBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.orderManagementBithumbStatusBox.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.orderManagementBithumbStatusBox.Properties.Appearance.Options.UseFont = true;
            this.orderManagementBithumbStatusBox.Properties.Appearance.Options.UseForeColor = true;
            this.orderManagementBithumbStatusBox.Size = new System.Drawing.Size(58, 22);
            this.orderManagementBithumbStatusBox.TabIndex = 1028;
            this.orderManagementBithumbStatusBox.ToolTip = "Bithumb";
            // 
            // orderManagementPhemexStatusBox
            // 
            this.orderManagementPhemexStatusBox.EditValue = "Phemex";
            this.orderManagementPhemexStatusBox.Enabled = false;
            this.orderManagementPhemexStatusBox.Location = new System.Drawing.Point(642, 98);
            this.orderManagementPhemexStatusBox.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementPhemexStatusBox.Name = "orderManagementPhemexStatusBox";
            this.orderManagementPhemexStatusBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.orderManagementPhemexStatusBox.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.orderManagementPhemexStatusBox.Properties.Appearance.Options.UseFont = true;
            this.orderManagementPhemexStatusBox.Properties.Appearance.Options.UseForeColor = true;
            this.orderManagementPhemexStatusBox.Size = new System.Drawing.Size(58, 22);
            this.orderManagementPhemexStatusBox.TabIndex = 1027;
            this.orderManagementPhemexStatusBox.ToolTip = "Phemex";
            // 
            // orderManagementMEXCStatusBox
            // 
            this.orderManagementMEXCStatusBox.EditValue = "MEXC";
            this.orderManagementMEXCStatusBox.Enabled = false;
            this.orderManagementMEXCStatusBox.Location = new System.Drawing.Point(642, 79);
            this.orderManagementMEXCStatusBox.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementMEXCStatusBox.Name = "orderManagementMEXCStatusBox";
            this.orderManagementMEXCStatusBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.orderManagementMEXCStatusBox.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.orderManagementMEXCStatusBox.Properties.Appearance.Options.UseFont = true;
            this.orderManagementMEXCStatusBox.Properties.Appearance.Options.UseForeColor = true;
            this.orderManagementMEXCStatusBox.Size = new System.Drawing.Size(58, 22);
            this.orderManagementMEXCStatusBox.TabIndex = 1026;
            // 
            // orderManagementHTXStatusBox
            // 
            this.orderManagementHTXStatusBox.EditValue = "HTX";
            this.orderManagementHTXStatusBox.Enabled = false;
            this.orderManagementHTXStatusBox.Location = new System.Drawing.Point(642, 59);
            this.orderManagementHTXStatusBox.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementHTXStatusBox.Name = "orderManagementHTXStatusBox";
            this.orderManagementHTXStatusBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.orderManagementHTXStatusBox.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.orderManagementHTXStatusBox.Properties.Appearance.Options.UseFont = true;
            this.orderManagementHTXStatusBox.Properties.Appearance.Options.UseForeColor = true;
            this.orderManagementHTXStatusBox.Size = new System.Drawing.Size(58, 22);
            this.orderManagementHTXStatusBox.TabIndex = 1025;
            this.orderManagementHTXStatusBox.ToolTip = "HTX";
            // 
            // orderManagementIsBidToggle
            // 
            this.orderManagementIsBidToggle.Location = new System.Drawing.Point(214, -2);
            this.orderManagementIsBidToggle.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementIsBidToggle.Name = "orderManagementIsBidToggle";
            this.orderManagementIsBidToggle.Properties.OffText = "Ask";
            this.orderManagementIsBidToggle.Properties.OnText = "Bid";
            this.orderManagementIsBidToggle.Size = new System.Drawing.Size(111, 24);
            this.orderManagementIsBidToggle.TabIndex = 1001;
            // 
            // orderManagementCMEStatusBox
            // 
            this.orderManagementCMEStatusBox.EditValue = "CME";
            this.orderManagementCMEStatusBox.Enabled = false;
            this.orderManagementCMEStatusBox.Location = new System.Drawing.Point(642, 39);
            this.orderManagementCMEStatusBox.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementCMEStatusBox.Name = "orderManagementCMEStatusBox";
            this.orderManagementCMEStatusBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.orderManagementCMEStatusBox.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.orderManagementCMEStatusBox.Properties.Appearance.Options.UseFont = true;
            this.orderManagementCMEStatusBox.Properties.Appearance.Options.UseForeColor = true;
            this.orderManagementCMEStatusBox.Size = new System.Drawing.Size(58, 22);
            this.orderManagementCMEStatusBox.TabIndex = 1024;
            // 
            // orderMangementAggressionToggle
            // 
            this.orderMangementAggressionToggle.Location = new System.Drawing.Point(214, 23);
            this.orderMangementAggressionToggle.Margin = new System.Windows.Forms.Padding(4);
            this.orderMangementAggressionToggle.Name = "orderMangementAggressionToggle";
            this.orderMangementAggressionToggle.Properties.OffText = "Taking";
            this.orderMangementAggressionToggle.Properties.OnText = "Quoting";
            this.orderMangementAggressionToggle.Size = new System.Drawing.Size(128, 24);
            this.orderMangementAggressionToggle.TabIndex = 1003;
            // 
            // orderManagementDeribitStatusBox
            // 
            this.orderManagementDeribitStatusBox.EditValue = "Deribit";
            this.orderManagementDeribitStatusBox.Enabled = false;
            this.orderManagementDeribitStatusBox.Location = new System.Drawing.Point(642, 20);
            this.orderManagementDeribitStatusBox.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementDeribitStatusBox.Name = "orderManagementDeribitStatusBox";
            this.orderManagementDeribitStatusBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.orderManagementDeribitStatusBox.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.orderManagementDeribitStatusBox.Properties.Appearance.Options.UseFont = true;
            this.orderManagementDeribitStatusBox.Properties.Appearance.Options.UseForeColor = true;
            this.orderManagementDeribitStatusBox.Size = new System.Drawing.Size(58, 22);
            this.orderManagementDeribitStatusBox.TabIndex = 1023;
            // 
            // orderManagementBitfinexStatusBox
            // 
            this.orderManagementBitfinexStatusBox.EditValue = "Bitfinex";
            this.orderManagementBitfinexStatusBox.Enabled = false;
            this.orderManagementBitfinexStatusBox.Location = new System.Drawing.Point(642, 0);
            this.orderManagementBitfinexStatusBox.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementBitfinexStatusBox.Name = "orderManagementBitfinexStatusBox";
            this.orderManagementBitfinexStatusBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.orderManagementBitfinexStatusBox.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.orderManagementBitfinexStatusBox.Properties.Appearance.Options.UseFont = true;
            this.orderManagementBitfinexStatusBox.Properties.Appearance.Options.UseForeColor = true;
            this.orderManagementBitfinexStatusBox.Size = new System.Drawing.Size(58, 22);
            this.orderManagementBitfinexStatusBox.TabIndex = 1022;
            // 
            // orderManagementKrakenStatusBox
            // 
            this.orderManagementKrakenStatusBox.EditValue = "Kraken";
            this.orderManagementKrakenStatusBox.Enabled = false;
            this.orderManagementKrakenStatusBox.Location = new System.Drawing.Point(583, 118);
            this.orderManagementKrakenStatusBox.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementKrakenStatusBox.Name = "orderManagementKrakenStatusBox";
            this.orderManagementKrakenStatusBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.orderManagementKrakenStatusBox.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.orderManagementKrakenStatusBox.Properties.Appearance.Options.UseFont = true;
            this.orderManagementKrakenStatusBox.Properties.Appearance.Options.UseForeColor = true;
            this.orderManagementKrakenStatusBox.Size = new System.Drawing.Size(58, 22);
            this.orderManagementKrakenStatusBox.TabIndex = 1021;
            // 
            // orderManagementRequestStatus
            // 
            this.orderManagementRequestStatus.Enabled = false;
            this.orderManagementRequestStatus.Location = new System.Drawing.Point(184, 105);
            this.orderManagementRequestStatus.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementRequestStatus.Name = "orderManagementRequestStatus";
            this.orderManagementRequestStatus.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7F);
            this.orderManagementRequestStatus.Properties.Appearance.Options.UseFont = true;
            this.orderManagementRequestStatus.Size = new System.Drawing.Size(70, 22);
            this.orderManagementRequestStatus.TabIndex = 1000;
            this.orderManagementRequestStatus.TabStop = false;
            // 
            // orderManagementGateIOStatusBox
            // 
            this.orderManagementGateIOStatusBox.EditValue = "GateIO";
            this.orderManagementGateIOStatusBox.Enabled = false;
            this.orderManagementGateIOStatusBox.Location = new System.Drawing.Point(583, 98);
            this.orderManagementGateIOStatusBox.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementGateIOStatusBox.Name = "orderManagementGateIOStatusBox";
            this.orderManagementGateIOStatusBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.orderManagementGateIOStatusBox.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.orderManagementGateIOStatusBox.Properties.Appearance.Options.UseFont = true;
            this.orderManagementGateIOStatusBox.Properties.Appearance.Options.UseForeColor = true;
            this.orderManagementGateIOStatusBox.Size = new System.Drawing.Size(58, 22);
            this.orderManagementGateIOStatusBox.TabIndex = 1020;
            // 
            // orderManagementVWAPPercentLabel
            // 
            this.orderManagementVWAPPercentLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 7F);
            this.orderManagementVWAPPercentLabel.Appearance.Options.UseFont = true;
            this.orderManagementVWAPPercentLabel.Location = new System.Drawing.Point(350, 4);
            this.orderManagementVWAPPercentLabel.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementVWAPPercentLabel.Name = "orderManagementVWAPPercentLabel";
            this.orderManagementVWAPPercentLabel.Size = new System.Drawing.Size(98, 14);
            this.orderManagementVWAPPercentLabel.TabIndex = 1009;
            this.orderManagementVWAPPercentLabel.Text = "Max Participate %";
            // 
            // orderManagementCoinbaseStatusBox
            // 
            this.orderManagementCoinbaseStatusBox.EditValue = "Coinbase";
            this.orderManagementCoinbaseStatusBox.Enabled = false;
            this.orderManagementCoinbaseStatusBox.Location = new System.Drawing.Point(583, 79);
            this.orderManagementCoinbaseStatusBox.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementCoinbaseStatusBox.Name = "orderManagementCoinbaseStatusBox";
            this.orderManagementCoinbaseStatusBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.orderManagementCoinbaseStatusBox.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.orderManagementCoinbaseStatusBox.Properties.Appearance.Options.UseFont = true;
            this.orderManagementCoinbaseStatusBox.Properties.Appearance.Options.UseForeColor = true;
            this.orderManagementCoinbaseStatusBox.Size = new System.Drawing.Size(58, 22);
            this.orderManagementCoinbaseStatusBox.TabIndex = 1019;
            // 
            // orderManagementMaxParticipationPercentBox
            // 
            this.orderManagementMaxParticipationPercentBox.EditValue = "";
            this.orderManagementMaxParticipationPercentBox.Location = new System.Drawing.Point(443, 0);
            this.orderManagementMaxParticipationPercentBox.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementMaxParticipationPercentBox.Name = "orderManagementMaxParticipationPercentBox";
            this.orderManagementMaxParticipationPercentBox.Size = new System.Drawing.Size(58, 22);
            this.orderManagementMaxParticipationPercentBox.TabIndex = 1011;
            this.orderManagementMaxParticipationPercentBox.ToolTip = "1-100";
            // 
            // orderManagementKuCoinStatusBox
            // 
            this.orderManagementKuCoinStatusBox.EditValue = "KuCoin";
            this.orderManagementKuCoinStatusBox.Enabled = false;
            this.orderManagementKuCoinStatusBox.Location = new System.Drawing.Point(583, 59);
            this.orderManagementKuCoinStatusBox.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementKuCoinStatusBox.Name = "orderManagementKuCoinStatusBox";
            this.orderManagementKuCoinStatusBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.orderManagementKuCoinStatusBox.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.orderManagementKuCoinStatusBox.Properties.Appearance.Options.UseFont = true;
            this.orderManagementKuCoinStatusBox.Properties.Appearance.Options.UseForeColor = true;
            this.orderManagementKuCoinStatusBox.Size = new System.Drawing.Size(58, 22);
            this.orderManagementKuCoinStatusBox.TabIndex = 1018;
            // 
            // orderManagementVWAPButton
            // 
            this.orderManagementVWAPButton.Location = new System.Drawing.Point(414, 27);
            this.orderManagementVWAPButton.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementVWAPButton.Name = "orderManagementVWAPButton";
            this.orderManagementVWAPButton.Size = new System.Drawing.Size(88, 28);
            this.orderManagementVWAPButton.TabIndex = 1010;
            this.orderManagementVWAPButton.Text = "Send VWAP";
            this.orderManagementVWAPButton.ToolTip = "Sends a VWAP New Order";
            // 
            // orderManagementByBitStatusBox
            // 
            this.orderManagementByBitStatusBox.EditValue = "ByBit";
            this.orderManagementByBitStatusBox.Enabled = false;
            this.orderManagementByBitStatusBox.Location = new System.Drawing.Point(583, 39);
            this.orderManagementByBitStatusBox.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementByBitStatusBox.Name = "orderManagementByBitStatusBox";
            this.orderManagementByBitStatusBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.orderManagementByBitStatusBox.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.orderManagementByBitStatusBox.Properties.Appearance.Options.UseFont = true;
            this.orderManagementByBitStatusBox.Properties.Appearance.Options.UseForeColor = true;
            this.orderManagementByBitStatusBox.Size = new System.Drawing.Size(58, 22);
            this.orderManagementByBitStatusBox.TabIndex = 1017;
            // 
            // orderManagementStrategyStatusLabel
            // 
            this.orderManagementStrategyStatusLabel.Location = new System.Drawing.Point(350, 78);
            this.orderManagementStrategyStatusLabel.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementStrategyStatusLabel.Name = "orderManagementStrategyStatusLabel";
            this.orderManagementStrategyStatusLabel.Size = new System.Drawing.Size(93, 16);
            this.orderManagementStrategyStatusLabel.TabIndex = 1014;
            this.orderManagementStrategyStatusLabel.Text = "Strategy Status:";
            // 
            // orderManagementOKEXStatusBox
            // 
            this.orderManagementOKEXStatusBox.EditValue = "OKEX";
            this.orderManagementOKEXStatusBox.Enabled = false;
            this.orderManagementOKEXStatusBox.Location = new System.Drawing.Point(583, 20);
            this.orderManagementOKEXStatusBox.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementOKEXStatusBox.Name = "orderManagementOKEXStatusBox";
            this.orderManagementOKEXStatusBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.orderManagementOKEXStatusBox.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.orderManagementOKEXStatusBox.Properties.Appearance.Options.UseFont = true;
            this.orderManagementOKEXStatusBox.Properties.Appearance.Options.UseForeColor = true;
            this.orderManagementOKEXStatusBox.Size = new System.Drawing.Size(58, 22);
            this.orderManagementOKEXStatusBox.TabIndex = 1016;
            // 
            // orderManagementStrategyStatusBox
            // 
            this.orderManagementStrategyStatusBox.EditValue = "Invalid";
            this.orderManagementStrategyStatusBox.Enabled = false;
            this.orderManagementStrategyStatusBox.Location = new System.Drawing.Point(449, 76);
            this.orderManagementStrategyStatusBox.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementStrategyStatusBox.Name = "orderManagementStrategyStatusBox";
            this.orderManagementStrategyStatusBox.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.orderManagementStrategyStatusBox.Properties.Appearance.Options.UseForeColor = true;
            this.orderManagementStrategyStatusBox.Size = new System.Drawing.Size(117, 22);
            this.orderManagementStrategyStatusBox.TabIndex = 1012;
            // 
            // orderManagementBinanceStatusBox
            // 
            this.orderManagementBinanceStatusBox.EditValue = "Binance";
            this.orderManagementBinanceStatusBox.Enabled = false;
            this.orderManagementBinanceStatusBox.Location = new System.Drawing.Point(583, 0);
            this.orderManagementBinanceStatusBox.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementBinanceStatusBox.Name = "orderManagementBinanceStatusBox";
            this.orderManagementBinanceStatusBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.orderManagementBinanceStatusBox.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.orderManagementBinanceStatusBox.Properties.Appearance.Options.UseFont = true;
            this.orderManagementBinanceStatusBox.Properties.Appearance.Options.UseForeColor = true;
            this.orderManagementBinanceStatusBox.Size = new System.Drawing.Size(58, 22);
            this.orderManagementBinanceStatusBox.TabIndex = 1015;
            // 
            // orderManagementClearTradesButton
            // 
            this.orderManagementClearTradesButton.Location = new System.Drawing.Point(440, 105);
            this.orderManagementClearTradesButton.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementClearTradesButton.Name = "orderManagementClearTradesButton";
            this.orderManagementClearTradesButton.Size = new System.Drawing.Size(88, 28);
            this.orderManagementClearTradesButton.TabIndex = 1013;
            this.orderManagementClearTradesButton.Text = "Clear Trades";
            // 
            // orderManagementClearGridButton
            // 
            this.orderManagementClearGridButton.Location = new System.Drawing.Point(350, 105);
            this.orderManagementClearGridButton.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementClearGridButton.Name = "orderManagementClearGridButton";
            this.orderManagementClearGridButton.Size = new System.Drawing.Size(88, 28);
            this.orderManagementClearGridButton.TabIndex = 1006;
            this.orderManagementClearGridButton.Text = "Clear Grid";
            this.orderManagementClearGridButton.ToolTip = "Cannot be reversed";
            this.orderManagementClearGridButton.Click += new System.EventHandler(this.OrderManagementClearGridButton_Click);
            // 
            // orderManagementSplitContainerControl
            // 
            this.orderManagementSplitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderManagementSplitContainerControl.Horizontal = false;
            this.orderManagementSplitContainerControl.Location = new System.Drawing.Point(0, 0);
            this.orderManagementSplitContainerControl.Margin = new System.Windows.Forms.Padding(4);
            this.orderManagementSplitContainerControl.Name = "orderManagementSplitContainerControl";
            // 
            // orderManagementSplitContainerControl.Panel1
            // 
            this.orderManagementSplitContainerControl.Panel1.Controls.Add(this.orderManagementPanelOrdersGridControl);
            this.orderManagementSplitContainerControl.Panel1.Text = "Orders";
            // 
            // orderManagementSplitContainerControl.Panel2
            // 
            this.orderManagementSplitContainerControl.Panel2.Controls.Add(this.orderManagementPanelTradesGridControl);
            this.orderManagementSplitContainerControl.Panel2.Text = "Fills";
            this.orderManagementSplitContainerControl.Size = new System.Drawing.Size(1910, 803);
            this.orderManagementSplitContainerControl.SplitterPosition = 308;
            this.orderManagementSplitContainerControl.TabIndex = 0;
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 342);
            this.IconOptions.Image = global::CryptoUI.Properties.Resources.logo;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "App";
            this.Text = "App";
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementPanelOrdersGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementPanelOrdersGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementPanelTradesGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementPanelTradesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementPanelSymbolBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementPanelVenueBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementPanelSharesBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementPanelPriceBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManagerOrderManagement)).EndInit();
            this.dockParamManagementPanel.ResumeLayout(false);
            this.controlContainer8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paramManagementMenuSplitContainerControl.Panel1)).EndInit();
            this.paramManagementMenuSplitContainerControl.Panel1.ResumeLayout(false);
            this.paramManagementMenuSplitContainerControl.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paramManagementMenuSplitContainerControl.Panel2)).EndInit();
            this.paramManagementMenuSplitContainerControl.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paramManagementMenuSplitContainerControl)).EndInit();
            this.paramManagementMenuSplitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paramManagementValueBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paramManagementPriKeyBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paramManagementSecKeyBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paramManagementIdxBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paramManagementParamTypeComboBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paramManagementParamLevelComboBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paramManagementParamNameBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paramManagementSeqNoBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paramManagementNumChangesBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paramManagementStatusBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paramManagerGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paramManagerGridView)).EndInit();
            this.dockOrderManagementPanel.ResumeLayout(false);
            this.controlContainer6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementMenuSplitContainerControl.Panel1)).EndInit();
            this.orderManagementMenuSplitContainerControl.Panel1.ResumeLayout(false);
            this.orderManagementMenuSplitContainerControl.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementMenuSplitContainerControl.Panel2)).EndInit();
            this.orderManagementMenuSplitContainerControl.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementMenuSplitContainerControl)).EndInit();
            this.orderManagementMenuSplitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementAccountPicker.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementBitkubStatusBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementBitstampStatusBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementBitrueStatusBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagerConnectionStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementCryptocomStatusBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementFollowToggle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementBitgetStatusBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementUpbitStatusBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementbitFlyerStatusBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementBithumbStatusBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementPhemexStatusBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementMEXCStatusBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementHTXStatusBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementIsBidToggle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementCMEStatusBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderMangementAggressionToggle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementDeribitStatusBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementBitfinexStatusBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementKrakenStatusBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementRequestStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementGateIOStatusBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementCoinbaseStatusBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementMaxParticipationPercentBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementKuCoinStatusBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementByBitStatusBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementOKEXStatusBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementStrategyStatusBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementBinanceStatusBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementSplitContainerControl.Panel1)).EndInit();
            this.orderManagementSplitContainerControl.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementSplitContainerControl.Panel2)).EndInit();
            this.orderManagementSplitContainerControl.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orderManagementSplitContainerControl)).EndInit();
            this.orderManagementSplitContainerControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton orderManagementPanelSendOrderButton;
        private DevExpress.XtraEditors.TextEdit orderManagementPanelSharesBox;
        private DevExpress.XtraEditors.TextEdit orderManagementPanelPriceBox;
        private DevExpress.XtraEditors.LabelControl orderManagementPanelSharesLabel;
        private DevExpress.XtraEditors.LabelControl orderManagementPanelPriceLabel;
        private DevExpress.XtraEditors.TextEdit orderManagementPanelVenueBox;
        private DevExpress.XtraEditors.TextEdit orderManagementPanelSymbolBox;
        private DevExpress.XtraEditors.LabelControl orderManagementPanelVenueLabel;
        private DevExpress.XtraEditors.LabelControl orderManagementPanelSymbolLabel;
        private DevExpress.XtraGrid.GridControl orderManagementPanelTradesGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView orderManagementPanelTradesGridView;
        private DevExpress.XtraGrid.Columns.GridColumn tradesExecutionTime;
        private DevExpress.XtraGrid.Columns.GridColumn tradesSymbol;
        private DevExpress.XtraGrid.Columns.GridColumn tradesVenue;
        private DevExpress.XtraGrid.Columns.GridColumn tradesFillPrice;
        private DevExpress.XtraGrid.Columns.GridColumn tradesFillQuantity;
        private DevExpress.XtraGrid.GridControl orderManagementPanelOrdersGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView orderManagementPanelOrdersGridView;
        private DevExpress.XtraGrid.Columns.GridColumn ordersLastUpdateTime;
        private DevExpress.XtraGrid.Columns.GridColumn ordersSymbol;
        private DevExpress.XtraGrid.Columns.GridColumn ordersVenue;
        private DevExpress.XtraGrid.Columns.GridColumn ordersPrice;
        private DevExpress.XtraGrid.Columns.GridColumn ordersQuantityLeft;
        private DevExpress.XtraGrid.Columns.GridColumn ordersClOrdId;
        private DevExpress.XtraGrid.Columns.GridColumn ordersLastOrderState;
        private DevExpress.XtraGrid.Columns.GridColumn ordersOrderQty;
        private DevExpress.XtraGrid.Columns.GridColumn ordersOrderCreationTime;
        private DevExpress.XtraBars.Docking.DockPanel dockOrderManagementPanel;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer6;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraBars.Docking.DockManager dockManagerOrderManagement;
        private DevExpress.XtraEditors.TextEdit orderManagerConnectionStatus;
        private DevExpress.XtraEditors.ToggleSwitch orderMangementAggressionToggle;
        private DevExpress.XtraEditors.ToggleSwitch orderManagementIsBidToggle;
        private DevExpress.XtraEditors.TextEdit orderManagementRequestStatus;
        private DevExpress.XtraGrid.Columns.GridColumn ordersSide;
        private DevExpress.XtraGrid.Columns.GridColumn ordersIsTaking;
        private DevExpress.XtraGrid.Columns.GridColumn tradesOrderSide;
        private DevExpress.XtraEditors.SimpleButton orderManagementClearGridButton;
        private DevExpress.XtraGrid.Columns.GridColumn ordersTIF;
        private DevExpress.XtraGrid.Columns.GridColumn ordersIsManual;
        private DevExpress.XtraGrid.Columns.GridColumn ordersAvgFillPx;
        private DevExpress.XtraGrid.Columns.GridColumn ordersSendingInstance;
        private DevExpress.XtraGrid.Columns.GridColumn ordersSendingLocation;
        private DevExpress.XtraEditors.TextEdit orderManagementMaxParticipationPercentBox;
        private DevExpress.XtraEditors.SimpleButton orderManagementVWAPButton;
        private DevExpress.XtraEditors.LabelControl orderManagementVWAPPercentLabel;
        private DevExpress.XtraGrid.Columns.GridColumn tradesOrderPrice;
        private DevExpress.XtraGrid.Columns.GridColumn tradesClOrdId;
        private DevExpress.XtraGrid.Columns.GridColumn tradesRemainingQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn tradesFair;
        private DevExpress.XtraGrid.Columns.GridColumn tradesEdge;
        private DevExpress.XtraGrid.Columns.GridColumn tradesLeader;
        private DevExpress.XtraGrid.Columns.GridColumn tradesStrategy;
        private DevExpress.XtraEditors.TextEdit orderManagementBitgetStatusBox;
        private DevExpress.XtraEditors.TextEdit orderManagementUpbitStatusBox;
        private DevExpress.XtraEditors.TextEdit orderManagementbitFlyerStatusBox;
        private DevExpress.XtraEditors.TextEdit orderManagementBithumbStatusBox;
        private DevExpress.XtraEditors.TextEdit orderManagementPhemexStatusBox;
        private DevExpress.XtraEditors.TextEdit orderManagementMEXCStatusBox;
        private DevExpress.XtraEditors.TextEdit orderManagementHTXStatusBox;
        private DevExpress.XtraEditors.TextEdit orderManagementCMEStatusBox;
        private DevExpress.XtraEditors.TextEdit orderManagementDeribitStatusBox;
        private DevExpress.XtraEditors.TextEdit orderManagementBitfinexStatusBox;
        private DevExpress.XtraEditors.TextEdit orderManagementKrakenStatusBox;
        private DevExpress.XtraEditors.TextEdit orderManagementGateIOStatusBox;
        private DevExpress.XtraEditors.TextEdit orderManagementCoinbaseStatusBox;
        private DevExpress.XtraEditors.TextEdit orderManagementKuCoinStatusBox;
        private DevExpress.XtraEditors.TextEdit orderManagementByBitStatusBox;
        private DevExpress.XtraEditors.TextEdit orderManagementOKEXStatusBox;
        private DevExpress.XtraEditors.TextEdit orderManagementBinanceStatusBox;
        private DevExpress.XtraEditors.LabelControl orderManagementStrategyStatusLabel;
        private DevExpress.XtraEditors.SimpleButton orderManagementClearTradesButton;
        private DevExpress.XtraEditors.TextEdit orderManagementStrategyStatusBox;
        private DevExpress.XtraEditors.ToggleSwitch orderManagementFollowToggle;
        private DevExpress.XtraEditors.TextEdit orderManagementBitkubStatusBox;
        private DevExpress.XtraEditors.TextEdit orderManagementBitstampStatusBox;
        private DevExpress.XtraEditors.TextEdit orderManagementBitrueStatusBox;
        private DevExpress.XtraEditors.TextEdit orderManagementCryptocomStatusBox;
        private DevExpress.XtraEditors.SplitContainerControl orderManagementMenuSplitContainerControl;
        private DevExpress.XtraEditors.SplitContainerControl orderManagementSplitContainerControl;
        private DevExpress.XtraBars.Docking.DockPanel dockParamManagementPanel;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer8;
        private DevExpress.XtraEditors.SplitContainerControl paramManagementMenuSplitContainerControl;
        private DevExpress.XtraEditors.TextEdit paramManagementSeqNoBox;
        private DevExpress.XtraEditors.LabelControl paramManagementCurrentSeqNoLabel;
        private DevExpress.XtraEditors.TextEdit paramManagementNumChangesBox;
        private DevExpress.XtraEditors.SimpleButton paramManagementClearButton;
        private DevExpress.XtraEditors.SimpleButton paramManagementApplyButton;
        private DevExpress.XtraEditors.LabelControl paramManagementNumChangesLabel;
        private DevExpress.XtraEditors.TextEdit paramManagementStatusBox;
        private DevExpress.XtraEditors.TextEdit paramManagementValueBox;
        private DevExpress.XtraEditors.TextEdit paramManagementPriKeyBox;
        private DevExpress.XtraEditors.TextEdit paramManagementSecKeyBox;
        private DevExpress.XtraEditors.TextEdit paramManagementIdxBox;
        private DevExpress.XtraEditors.ComboBoxEdit paramManagementParamTypeComboBox;
        private DevExpress.XtraEditors.ComboBoxEdit paramManagementParamLevelComboBox;
        private DevExpress.XtraEditors.SimpleButton paramManagementDefineButton;
        private DevExpress.XtraEditors.TextEdit paramManagementParamNameBox;
        private DevExpress.XtraGrid.GridControl paramManagerGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView paramManagerGridView;
        private DevExpress.XtraGrid.Columns.GridColumn paramGridName;
        private DevExpress.XtraGrid.Columns.GridColumn paramGridLevel;
        private DevExpress.XtraGrid.Columns.GridColumn paramGridType;
        private DevExpress.XtraGrid.Columns.GridColumn paramGridPrimary;
        private DevExpress.XtraGrid.Columns.GridColumn paramGridSecondary;
        private DevExpress.XtraGrid.Columns.GridColumn paramGridIndex;
        private DevExpress.XtraGrid.Columns.GridColumn paramGridValue;
        private DevExpress.XtraEditors.DropDownButton orderManagementCancelAllButton;
        private DevExpress.XtraEditors.ComboBoxEdit orderManagementAccountPicker;
        private DevExpress.XtraEditors.SimpleButton paramManagementUploadButton;
        private DevExpress.XtraEditors.SimpleButton orderManagementMassActionUploadButton;
        private DevExpress.XtraGrid.Columns.GridColumn tradesExecutionTimeNs;
        private DevExpress.XtraGrid.Columns.GridColumn ordersLastUpdateTimeNs;
        private DevExpress.XtraGrid.Columns.GridColumn ordersOrderCreationTimeNs;

    }
}

