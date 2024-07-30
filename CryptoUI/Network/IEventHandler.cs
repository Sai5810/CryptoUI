using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoUI.Network
{
    public abstract class IEventHandler
    {
        public abstract void onParamServerConnect();
        public abstract void onParamDisconnect();
        public abstract void onParamChange(Protocol.ParamServerN.ParamChangeMsgT param);
        public abstract void onMajorGroupSubscribeAck(Protocol.ParamServerN.MajorGroupSubscribeAckT ack);
        public abstract void onSnapshotLock();
        public abstract void onSnapshotUnlock();
        public abstract void onParamHeartbeatSeq(uint seqno);
        public abstract bool publishParam(Protocol.ParamServerN.ParamChangeMsgT msg);
        public abstract bool publishSubscribe(ulong id);
        public abstract bool publishUnsubscribe(ulong id);


        public abstract void on_ps_account_creation_ack(ref Protocol.PositionServerN.AccountCreationAckT msg);
        public abstract void on_ps_account_creation_notification(ref Protocol.PositionServerN.AccountCreationNotificationT msg);
        public abstract void on_ps_account_instrument_subscription_ack(ref Protocol.PositionServerN.AccountInstrumentSubscriptionAckT msg);
        public abstract void on_ps_account_parent_change_ack(ref Protocol.PositionServerN.AccountParentChangeAckT msg);
        public abstract void on_ps_account_relation_change_notification(ref Protocol.PositionServerN.AccountRelationChangeNotificationT msg);
        public abstract void on_ps_account_removal_ack(ref Protocol.PositionServerN.AccountRemovalAckT msg);
        public abstract void on_ps_account_removal_notification(ref Protocol.PositionServerN.AccountRemovalNotificationT msg);
        public abstract void on_ps_account_subscription_ack(ref Protocol.PositionServerN.AccountSubscriptionAckT msg);
        public abstract void on_ps_get_account_children_response(ref Protocol.PositionServerN.GetAccountChildrenResponseMsgT msg);
        public abstract void on_ps_get_account_details_response(ref Protocol.PositionServerN.GetAccountDetailsResponseT msg);
        public abstract void on_ps_get_transaction_details_response(ref Protocol.PositionServerN.GetTransactionDetailsResponseMsgT msg);
        public abstract void on_ps_list_accounts_response(ref Protocol.PositionServerN.ListAccountsResponseMsgT msg);
        public abstract void on_ps_list_account_balances_response(ref Protocol.PositionServerN.ListAccountBalancesResponseMsgT msg);
        public abstract void on_ps_list_transactions_for_account_response(ref Protocol.PositionServerN.ListTransactionsForAccountResponseMsgT msg);
        public abstract void on_ps_position_cleared_update_ack(ref Protocol.PositionServerN.PositionClearedUpdateAckT msg);
        public abstract void on_ps_position_clearing_notification(ref Protocol.PositionServerN.PositionClearingNotificationT msg);
        public abstract void on_ps_position_update_ack(ref Protocol.PositionServerN.PositionUpdateAckT msg);
        public abstract void on_ps_position_update_notification(ref Protocol.PositionServerN.PositionUpdateNotificationMsgT msg);

        public abstract void onOrderUpdate(ref Protocol.manual_order_protocolN.OrderUpdateT msg, uint session_idx);
        public abstract void onFillUpdate(ref Protocol.manual_order_protocolN.FillUpdateT msg, uint session_idx);
        public abstract void onExchangeConnectionStatusNotification(ref Protocol.manual_order_protocolN.ExchangeConnectionStatusNotificationT msg, uint session_idx);
        public abstract void onStrategyStatusNotification(ref Protocol.manual_order_protocolN.StrategyStatusNotificationT msg, uint session_idx);
        public abstract void onOrdersSnapshot(ref Protocol.manual_order_protocolN.OrdersSnapshotMsgT msg, uint session_idx);
        public abstract void onRecentFillsSnapshot(ref Protocol.manual_order_protocolN.RecentFillsSnapshotMsgT msg, uint session_idx);
        public abstract void onListQuoterStrategiesSnapshot(ref Protocol.manual_order_protocolN.ListQuoterStrategiesSnapshotMsgT msg, uint session_idx);
        public abstract void onQuoterStrategyStatusNotification(ref Protocol.manual_order_protocolN.QuoterStrategyStatusNotificationT msg, uint session_idx);
        public abstract void onFairNotification(ref Protocol.manual_order_protocolN.FairNotificationT msg, uint session_idx);
        public abstract void onPosNotification(ref Protocol.manual_order_protocolN.PosNotificationT msg, uint session_idx);
        public abstract void onFillEnrichment(ref Protocol.manual_order_protocolN.FillEnrichmentT msg, uint session_idx);
        public abstract void onQuoterEnableFailureNotification(ref Protocol.manual_order_protocolN.QuoterStrategyEnableFailureNotificationT msg, uint session_idx);
        public abstract void onManualOrderConnect(ulong ts, uint session_idx);
        public abstract void onManualOrderDisconnect(ulong ts, uint session_idx);
    }
}
