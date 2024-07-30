using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CryptoUI.Protocol
{
    namespace PositionServerN
    {
        public enum MsgTypeE : byte
        {
            invalid = 0x00,
            heartbeat_msg = 0x01,
            position_update_request_msg = 0x02,
            position_update_ack_msg = 0x03,
            position_cleared_update_request_msg = 0x04,
            position_cleared_update_ack_msg = 0x05,
            account_creation_request_msg = 0x06,
            account_creation_ack_msg = 0x07,
            account_removal_request_msg = 0x08,
            account_removal_ack_msg = 0x09,
            account_parent_change_request_msg = 0x10,
            account_parent_change_ack_msg = 0x11,
            list_accounts_request_msg = 0x12,
            list_accounts_response_msg = 0x13,
            get_account_details_request_msg = 0x14,
            get_account_details_response_msg = 0x15,
            get_account_children_request_msg = 0x16,
            get_account_children_response_msg = 0x17,
            list_account_balances_request_msg = 0x18,
            list_account_balances_response_msg = 0x19,
            list_transactions_for_account_request_msg = 0x20,
            list_transactions_for_account_response_msg = 0x21,
            get_transaction_details_request_msg = 0x22,
            get_transaction_details_response_msg = 0x23,
            account_subscription_request_msg = 0x24,
            account_subscription_ack_msg = 0x25,
            account_unsubscription_request_msg = 0x26,
            account_instrument_subscription_request_msg = 0x27,
            account_instrument_subscription_ack_msg = 0x28,
            account_instrument_unsubscription_request_msg = 0x29,
            position_update_notification_msg = 0x30,
            account_creation_notification_msg = 0x31,
            account_removal_notification_msg = 0x32,
            account_relation_change_notification_msg = 0x33,
            position_clearing_notification = 0x34
        }

        public class EnumStringsT
        {
            public static string ToString(MsgTypeE e)
            {
                switch (e)
                {
                    case MsgTypeE.heartbeat_msg:
                        return "heartbeat_msg";
                    case MsgTypeE.position_update_request_msg:
                    case MsgTypeE.position_update_ack_msg:
                    case MsgTypeE.position_cleared_update_request_msg:
                    case MsgTypeE.position_cleared_update_ack_msg:
                    case MsgTypeE.account_creation_request_msg:
                    case MsgTypeE.account_creation_ack_msg:
                    case MsgTypeE.account_removal_request_msg:
                    case MsgTypeE.account_removal_ack_msg:
                    case MsgTypeE.account_parent_change_request_msg:
                    case MsgTypeE.account_parent_change_ack_msg:
                    case MsgTypeE.list_accounts_request_msg:
                    case MsgTypeE.list_accounts_response_msg:
                    case MsgTypeE.get_account_details_request_msg:
                    case MsgTypeE.get_account_details_response_msg:
                    case MsgTypeE.get_account_children_request_msg:
                    case MsgTypeE.get_account_children_response_msg:
                    case MsgTypeE.list_account_balances_request_msg:
                    case MsgTypeE.list_account_balances_response_msg:
                    case MsgTypeE.list_transactions_for_account_request_msg:
                    case MsgTypeE.list_transactions_for_account_response_msg:
                    case MsgTypeE.get_transaction_details_request_msg:
                    case MsgTypeE.get_transaction_details_response_msg:
                    case MsgTypeE.account_subscription_request_msg:
                    case MsgTypeE.account_subscription_ack_msg:
                    case MsgTypeE.account_unsubscription_request_msg:
                    case MsgTypeE.account_instrument_subscription_request_msg:
                    case MsgTypeE.account_instrument_subscription_ack_msg:
                    case MsgTypeE.account_instrument_unsubscription_request_msg:
                    case MsgTypeE.position_update_notification_msg:
                    case MsgTypeE.account_creation_notification_msg:
                    case MsgTypeE.account_removal_notification_msg:
                    case MsgTypeE.account_relation_change_notification_msg:
                    case MsgTypeE.position_clearing_notification:
                        return "position_clearing_notification";
                    case MsgTypeE.invalid:
                    default:
                        return "invalid";
                }
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PositionUpdateAckT
        {
            public ulong request_id;
            public ulong transaction_id;
            [MarshalAs(UnmanagedType.I1)]
            public bool success;

            public static unsafe PositionUpdateAckT* Emplace(byte* buf)
            {
                PositionUpdateAckT tmp = new PositionUpdateAckT();
                var mem = (PositionUpdateAckT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PositionUpdateAckMsgT
        {
            public const ushort c_len = 24;
            public const MsgTypeE c_msg_type = MsgTypeE.position_update_ack_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public PositionUpdateAckT msg;

            public static unsafe PositionUpdateAckMsgT* Emplace(byte* buf)
            {
                PositionUpdateAckMsgT tmp = new PositionUpdateAckMsgT();
                var mem = (PositionUpdateAckMsgT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PositionClearedUpdateRequestT
        {
            public ulong request_id;
            public ulong transaction_id;
            [MarshalAs(UnmanagedType.I1)]
            public bool was_cleared;
            [MarshalAs(UnmanagedType.I1)]
            public bool was_rejected;

            public static unsafe PositionClearedUpdateRequestT* Emplace(byte* buf)
            {
                PositionClearedUpdateRequestT tmp = new PositionClearedUpdateRequestT();
                var mem = (PositionClearedUpdateRequestT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PositionClearedUpdateRequestMsgT
        {
            public const ushort c_len = 24;
            public const MsgTypeE c_msg_type = MsgTypeE.position_cleared_update_request_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public PositionClearedUpdateRequestT msg;

            public static unsafe PositionClearedUpdateRequestMsgT* Emplace(byte* buf)
            {
                PositionClearedUpdateRequestMsgT tmp = new PositionClearedUpdateRequestMsgT();
                var mem = (PositionClearedUpdateRequestMsgT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PositionClearingNotificationT
        {
            public ulong transaction_id;
            [MarshalAs(UnmanagedType.I1)]
            public bool was_cleared;
            [MarshalAs(UnmanagedType.I1)]
            public bool was_rejected;

            public static unsafe PositionClearingNotificationT* Emplace(byte* buf)
            {
                PositionClearingNotificationT tmp = new PositionClearingNotificationT();
                var mem = (PositionClearingNotificationT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PositionClearingNotificationMsgT
        {
            public const ushort c_len = 24;
            public const MsgTypeE c_msg_type = MsgTypeE.position_clearing_notification;

            public ushort len;
            public MsgTypeE msg_type;
            public PositionClearingNotificationT msg;

            public static unsafe PositionClearingNotificationMsgT* Emplace(byte* buf)
            {
                PositionClearingNotificationMsgT tmp = new PositionClearingNotificationMsgT();
                var mem = (PositionClearingNotificationMsgT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PositionClearedUpdateAckT
        {
            public ulong request_id;
            public ulong transaction_id;
            [MarshalAs(UnmanagedType.I1)]
            public bool success;

            public static unsafe PositionClearedUpdateAckT* Emplace(byte* buf)
            {
                PositionClearedUpdateAckT tmp = new PositionClearedUpdateAckT();
                var mem = (PositionClearedUpdateAckT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PositionClearedUpdateAckMsgT
        {
            public const ushort c_len = 24;
            public const MsgTypeE c_msg_type = MsgTypeE.position_clearing_notification;

            public ushort len;
            public MsgTypeE msg_type;
            public PositionClearedUpdateAckT msg;

            public static unsafe PositionClearedUpdateAckMsgT* Emplace(byte* buf)
            {
                PositionClearedUpdateAckMsgT tmp = new PositionClearedUpdateAckMsgT();
                var mem = (PositionClearedUpdateAckMsgT*)buf;
                *mem = tmp;
                return mem;
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AccountCreationRequestT
        {
            public Str128T account_name;
            [MarshalAs(UnmanagedType.I1)]
            public bool is_virtual_account;

            public static unsafe AccountCreationRequestT* Emplace(byte* buf)
            {
                AccountCreationRequestT tmp = new AccountCreationRequestT();
                var mem = (AccountCreationRequestT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AccountCreationRequestMsgT
        {
            public const ushort c_len = 132;
            public const MsgTypeE c_msg_type = MsgTypeE.account_creation_request_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public AccountCreationRequestT msg;

            public static unsafe AccountCreationRequestMsgT* Emplace(byte* buf)
            {
                AccountCreationRequestMsgT tmp = new AccountCreationRequestMsgT();
                var mem = (AccountCreationRequestMsgT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AccountCreationAckT
        {
            public Str128T account_name;
            public ulong account_id;
            [MarshalAs(UnmanagedType.I1)]
            public bool success;

            public static unsafe AccountCreationAckT* Emplace(byte* buf)
            {
                AccountCreationAckT tmp = new AccountCreationAckT();
                var mem = (AccountCreationAckT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AccountCreationAckMsgT
        {
            public const ushort c_len = 24;
            public const MsgTypeE c_msg_type = MsgTypeE.account_creation_ack_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public AccountCreationAckT msg;

            public static unsafe AccountCreationAckMsgT* Emplace(byte* buf)
            {
                AccountCreationAckMsgT tmp = new AccountCreationAckMsgT();
                var mem = (AccountCreationAckMsgT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AccountCreationNotificationT
        {
            public ulong account_id;
            public Str128T account_name;

            public static unsafe AccountCreationNotificationT* Emplace(byte* buf)
            {
                AccountCreationNotificationT tmp = new AccountCreationNotificationT();
                var mem = (AccountCreationNotificationT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AccountCreationNotificationMsgT
        {
            public const ushort c_len = 139;
            public const MsgTypeE c_msg_type = MsgTypeE.account_creation_notification_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public AccountCreationNotificationT msg;

            public static unsafe AccountCreationNotificationMsgT* Emplace(byte* buf)
            {
                AccountCreationNotificationMsgT tmp = new AccountCreationNotificationMsgT();
                var mem = (AccountCreationNotificationMsgT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AccountRemovalRequestT
        {
            public ulong account_id;

            public static unsafe AccountRemovalRequestT* Emplace(byte* buf)
            {
                AccountRemovalRequestT tmp = new AccountRemovalRequestT();
                var mem = (AccountRemovalRequestT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AccountRemovalRequestMsgT
        {
            public const ushort c_len = 11;
            public const MsgTypeE c_msg_type = MsgTypeE.account_removal_request_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public AccountRemovalRequestT msg;

            public static unsafe AccountRemovalRequestMsgT* Emplace(byte* buf)
            {
                AccountRemovalRequestMsgT tmp = new AccountRemovalRequestMsgT();
                var mem = (AccountRemovalRequestMsgT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AccountRemovalNotificationT
        {
            public ulong account_id;

            public static unsafe AccountRemovalNotificationT* Emplace(byte* buf)
            {
                AccountRemovalNotificationT tmp = new AccountRemovalNotificationT();
                var mem = (AccountRemovalNotificationT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AccountRemovalNotificationMsgT
        {
            public const ushort c_len = 11;
            public const MsgTypeE c_msg_type = MsgTypeE.account_removal_notification_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public AccountRemovalNotificationT msg;

            public static unsafe AccountRemovalNotificationMsgT* Emplace(byte* buf)
            {
                AccountRemovalNotificationMsgT tmp = new AccountRemovalNotificationMsgT();
                var mem = (AccountRemovalNotificationMsgT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AccountRemovalAckT
        {
            public ulong account_id;
            [MarshalAs(UnmanagedType.I1)]
            public bool success;

            public static unsafe AccountRemovalAckT* Emplace(byte* buf)
            {
                AccountRemovalAckT tmp = new AccountRemovalAckT();
                var mem = (AccountRemovalAckT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AccountRemovalAckMsgT
        {
            public const ushort c_len = 11;
            public const MsgTypeE c_msg_type = MsgTypeE.account_removal_ack_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public AccountRemovalAckT msg;

            public static unsafe AccountRemovalAckMsgT* Emplace(byte* buf)
            {
                AccountRemovalAckMsgT tmp = new AccountRemovalAckMsgT();
                var mem = (AccountRemovalAckMsgT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AccountParentChangeRequestT
        {
            public ulong request_id;
            public ulong account_id;
            [MarshalAs(UnmanagedType.I1)]
            public bool will_have_parent_account;
            public ulong new_parent_account_id;

            public static unsafe AccountParentChangeRequestT* Emplace(byte* buf)
            {
                AccountParentChangeRequestT tmp = new AccountParentChangeRequestT();
                var mem = (AccountParentChangeRequestT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AccountParentChangeRequestMsgT
        {
            public const ushort c_len = 28;
            public const MsgTypeE c_msg_type = MsgTypeE.account_parent_change_request_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public AccountParentChangeRequestT msg;

            public static unsafe AccountParentChangeRequestMsgT* Emplace(byte* buf)
            {
                AccountParentChangeRequestMsgT tmp = new AccountParentChangeRequestMsgT();
                var mem = (AccountParentChangeRequestMsgT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AccountRelationChangeNotificationT
        {
            public ulong account_id;
            [MarshalAs(UnmanagedType.I1)]
            public bool will_have_parent_account;
            public ulong new_parent_account_id;

            public static unsafe AccountRelationChangeNotificationT* Emplace(byte* buf)
            {
                AccountRelationChangeNotificationT tmp = new AccountRelationChangeNotificationT();
                var mem = (AccountRelationChangeNotificationT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AccountRelationChangeNotificationMsgT
        {
            public const ushort c_len = 20;
            public const MsgTypeE c_msg_type = MsgTypeE.account_relation_change_notification_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public AccountRelationChangeNotificationT msg;

            public static unsafe AccountRelationChangeNotificationMsgT* Emplace(byte* buf)
            {
                AccountRelationChangeNotificationMsgT tmp = new AccountRelationChangeNotificationMsgT();
                var mem = (AccountRelationChangeNotificationMsgT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AccountParentChangeAckT
        {
            public ulong request_id;
            public ulong account_id;
            [MarshalAs(UnmanagedType.I1)]
            public bool success;

            public static unsafe AccountParentChangeAckT* Emplace(byte* buf)
            {
                AccountParentChangeAckT tmp = new AccountParentChangeAckT();
                var mem = (AccountParentChangeAckT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AccountParentChangeAckMsgT
        {
            public const ushort c_len = 20;
            public const MsgTypeE c_msg_type = MsgTypeE.account_parent_change_ack_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public AccountParentChangeAckT msg;

            public static unsafe AccountParentChangeAckMsgT* Emplace(byte* buf)
            {
                AccountParentChangeAckMsgT tmp = new AccountParentChangeAckMsgT();
                var mem = (AccountParentChangeAckMsgT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ListAccountsRequestMsgT
        {
            public const ushort c_len = 3;
            public const MsgTypeE c_msg_type = MsgTypeE.list_accounts_request_msg;

            public ushort len;
            public MsgTypeE msg_type;

            public static unsafe ListAccountsRequestMsgT* Emplace(byte* buf)
            {
                ListAccountsRequestMsgT tmp = new ListAccountsRequestMsgT();
                var mem = (ListAccountsRequestMsgT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct GetAccountDetailsRequestT
        {
            public ulong account_id;

            public static unsafe GetAccountDetailsRequestT* Emplace(byte* buf)
            {
                GetAccountDetailsRequestT tmp = new GetAccountDetailsRequestT();
                var mem = (GetAccountDetailsRequestT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct GetAccountDetailsRequestMsgT
        {
            public const ushort c_len = 20;
            public const MsgTypeE c_msg_type = MsgTypeE.account_parent_change_ack_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public GetAccountDetailsRequestT msg;

            public static unsafe GetAccountDetailsRequestMsgT* Emplace(byte* buf)
            {
                GetAccountDetailsRequestMsgT tmp = new GetAccountDetailsRequestMsgT();
                var mem = (GetAccountDetailsRequestMsgT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct GetAccountDetailsResponseT
        {
            [MarshalAs(UnmanagedType.I1)]
            public bool found;
            public ulong account_id;
            public Str128T account_name;
            [MarshalAs(UnmanagedType.I1)]
            public bool is_virtual_account;
            [MarshalAs(UnmanagedType.I1)]
            public bool has_parent_account_id;
            public ulong parent_account_id;

            public static unsafe GetAccountDetailsResponseT* Emplace(byte* buf)
            {
                GetAccountDetailsResponseT tmp = new GetAccountDetailsResponseT();
                var mem = (GetAccountDetailsResponseT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct GetAccountDetailsResponseMsgT
        {
            public const ushort c_len = 150;
            public const MsgTypeE c_msg_type = MsgTypeE.get_account_details_response_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public GetAccountDetailsResponseT msg;

            public static unsafe GetAccountDetailsResponseMsgT* Emplace(byte* buf)
            {
                GetAccountDetailsResponseMsgT tmp = new GetAccountDetailsResponseMsgT();
                var mem = (GetAccountDetailsResponseMsgT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct GetAccountChildrenRequestT
        {
            public ulong account_id;

            public static unsafe GetAccountChildrenRequestT* Emplace(byte* buf)
            {
                GetAccountChildrenRequestT tmp = new GetAccountChildrenRequestT();
                var mem = (GetAccountChildrenRequestT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct GetAccountChildrenRequestMsgT
        {
            public const ushort c_len = 11;
            public const MsgTypeE c_msg_type = MsgTypeE.get_account_children_request_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public GetAccountChildrenRequestT msg;

            public static unsafe GetAccountChildrenRequestMsgT* Emplace(byte* buf)
            {
                GetAccountChildrenRequestMsgT tmp = new GetAccountChildrenRequestMsgT();
                var mem = (GetAccountChildrenRequestMsgT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ListAccountBalancesRequestT
        {
            public ulong account_id;

            public static unsafe ListAccountBalancesRequestT* Emplace(byte* buf)
            {
                ListAccountBalancesRequestT tmp = new ListAccountBalancesRequestT();
                var mem = (ListAccountBalancesRequestT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ListAccountBalancesRequestMsgT
        {
            public const ushort c_len = 11;
            public const MsgTypeE c_msg_type = MsgTypeE.list_account_balances_request_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public ListAccountBalancesRequestT msg;

            public static unsafe ListAccountBalancesRequestMsgT* Emplace(byte* buf)
            {
                ListAccountBalancesRequestMsgT tmp = new ListAccountBalancesRequestMsgT();
                var mem = (ListAccountBalancesRequestMsgT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ListTransactionsForAccountRequestT
        {
            public ulong account_id;
            [MarshalAs(UnmanagedType.I1)]
            public bool is_to_account;

            public static unsafe ListTransactionsForAccountRequestT* Emplace(byte* buf)
            {
                ListTransactionsForAccountRequestT tmp = new ListTransactionsForAccountRequestT();
                var mem = (ListTransactionsForAccountRequestT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ListTransactionsForAccountRequestMsgT
        {
            public const ushort c_len = 12;
            public const MsgTypeE c_msg_type = MsgTypeE.list_transactions_for_account_request_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public ListTransactionsForAccountRequestT msg;

            public static unsafe ListTransactionsForAccountRequestMsgT* Emplace(byte* buf)
            {
                ListTransactionsForAccountRequestMsgT tmp = new ListTransactionsForAccountRequestMsgT();
                var mem = (ListTransactionsForAccountRequestMsgT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct GetTransactionDetailsRequestT
        {
            public ulong transaction_id;

            public static unsafe GetTransactionDetailsRequestT* Emplace(byte* buf)
            {
                GetTransactionDetailsRequestT tmp = new GetTransactionDetailsRequestT();
                var mem = (GetTransactionDetailsRequestT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct GetTransactionDetailsRequestMsgT
        {
            public const ushort c_len = 11;
            public const MsgTypeE c_msg_type = MsgTypeE.get_transaction_details_request_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public GetTransactionDetailsRequestT msg;

            public static unsafe GetTransactionDetailsRequestMsgT* Emplace(byte* buf)
            {
                GetTransactionDetailsRequestMsgT tmp = new GetTransactionDetailsRequestMsgT();
                var mem = (GetTransactionDetailsRequestMsgT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AccountSubscriptionRequestT
        {
            public ulong request_id;
            public ulong account_id;

            public static unsafe AccountSubscriptionRequestT* Emplace(byte* buf)
            {
                AccountSubscriptionRequestT tmp = new AccountSubscriptionRequestT();
                var mem = (AccountSubscriptionRequestT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AccountSubscriptionRequestMsgT
        {
            public const ushort c_len = 11;
            public const MsgTypeE c_msg_type = MsgTypeE.account_subscription_request_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public AccountSubscriptionRequestT msg;

            public static unsafe AccountSubscriptionRequestMsgT* Emplace(byte* buf)
            {
                AccountSubscriptionRequestMsgT tmp = new AccountSubscriptionRequestMsgT();
                var mem = (AccountSubscriptionRequestMsgT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AccountSubscriptionAckT
        {
            public ulong request_id;
            public ulong account_id;
            [MarshalAs(UnmanagedType.I1)]
            public bool success;
            [MarshalAs(UnmanagedType.I1)]
            public bool was_subscribe;

            public static unsafe AccountSubscriptionAckT* Emplace(byte* buf)
            {
                AccountSubscriptionAckT tmp = new AccountSubscriptionAckT();
                var mem = (AccountSubscriptionAckT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AccountSubscriptionAckMsgT
        {
            public const ushort c_len = 21;
            public const MsgTypeE c_msg_type = MsgTypeE.account_subscription_ack_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public AccountSubscriptionAckT msg;

            public static unsafe AccountSubscriptionAckMsgT* Emplace(byte* buf)
            {
                AccountSubscriptionAckMsgT tmp = new AccountSubscriptionAckMsgT();
                var mem = (AccountSubscriptionAckMsgT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AccountUnsubscriptionRequestT
        {
            public ulong request_id;
            public ulong account_id;

            public static unsafe AccountUnsubscriptionRequestT* Emplace(byte* buf)
            {
                AccountUnsubscriptionRequestT tmp = new AccountUnsubscriptionRequestT();
                var mem = (AccountUnsubscriptionRequestT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AccountUnsubscriptionRequestMsgT
        {
            public const ushort c_len = 11;
            public const MsgTypeE c_msg_type = MsgTypeE.account_unsubscription_request_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public AccountUnsubscriptionRequestT msg;

            public static unsafe AccountUnsubscriptionRequestMsgT* Emplace(byte* buf)
            {
                AccountUnsubscriptionRequestMsgT tmp = new AccountUnsubscriptionRequestMsgT();
                var mem = (AccountUnsubscriptionRequestMsgT*)buf;
                *mem = tmp;
                return mem;
            }
        }



        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AccountInstrumentSubscriptionRequestT
        {
            public ulong request_id;
            public ulong account_id;
            public ulong instrument_id;

            public static unsafe AccountInstrumentSubscriptionRequestT* Emplace(byte* buf)
            {
                AccountInstrumentSubscriptionRequestT tmp = new AccountInstrumentSubscriptionRequestT();
                var mem = (AccountInstrumentSubscriptionRequestT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AccountInstrumentSubscriptionRequestMsgT
        {
            public const ushort c_len = 19;
            public const MsgTypeE c_msg_type = MsgTypeE.account_instrument_subscription_request_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public AccountInstrumentSubscriptionRequestT msg;

            public static unsafe AccountInstrumentSubscriptionRequestMsgT* Emplace(byte* buf)
            {
                AccountInstrumentSubscriptionRequestMsgT tmp = new AccountInstrumentSubscriptionRequestMsgT();
                var mem = (AccountInstrumentSubscriptionRequestMsgT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AccountInstrumentSubscriptionAckT
        {
            public ulong request_id;
            public ulong account_id;
            public ulong instrument_id;
            [MarshalAs(UnmanagedType.I1)]
            public bool success;
            [MarshalAs(UnmanagedType.I1)]
            public bool was_subscribe;

            public static unsafe AccountInstrumentSubscriptionAckT* Emplace(byte* buf)
            {
                AccountInstrumentSubscriptionAckT tmp = new AccountInstrumentSubscriptionAckT();
                var mem = (AccountInstrumentSubscriptionAckT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AccountInstrumentSubscriptionAckMsgT
        {
            public const ushort c_len = 29;
            public const MsgTypeE c_msg_type = MsgTypeE.account_instrument_subscription_ack_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public AccountInstrumentSubscriptionAckT msg;

            public static unsafe AccountInstrumentSubscriptionAckMsgT* Emplace(byte* buf)
            {
                AccountInstrumentSubscriptionAckMsgT tmp = new AccountInstrumentSubscriptionAckMsgT();
                var mem = (AccountInstrumentSubscriptionAckMsgT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AccountInstrumentUnsubscriptionRequestT
        {
            public ulong request_id;
            public ulong account_id;
            public ulong instrument_id;

            public static unsafe AccountInstrumentUnsubscriptionRequestT* Emplace(byte* buf)
            {
                AccountInstrumentUnsubscriptionRequestT tmp = new AccountInstrumentUnsubscriptionRequestT();
                var mem = (AccountInstrumentUnsubscriptionRequestT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AccountInstrumentUnsubscriptionRequestMsgT
        {
            public const ushort c_len = 19;
            public const MsgTypeE c_msg_type = MsgTypeE.account_instrument_unsubscription_request_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public AccountInstrumentUnsubscriptionRequestT msg;

            public static unsafe AccountInstrumentUnsubscriptionRequestMsgT* Emplace(byte* buf)
            {
                AccountInstrumentUnsubscriptionRequestMsgT tmp = new AccountInstrumentUnsubscriptionRequestMsgT();
                var mem = (AccountInstrumentUnsubscriptionRequestMsgT*)buf;
                *mem = tmp;
                return mem;
            }
        }

        // Inner

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct GetAccountChildrenResponseInnerT
        {
            public const ushort c_len = 12;
            public const MsgTypeE c_msg_type = MsgTypeE.get_account_children_response_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public ulong account_id;
            public byte account_ids_count;

            public static unsafe AccountInstrumentUnsubscriptionRequestT* Emplace(byte* buf)
            {
                AccountInstrumentUnsubscriptionRequestT tmp = new AccountInstrumentUnsubscriptionRequestT();
                var mem = (AccountInstrumentUnsubscriptionRequestT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ListAccountsResponseInnerT
        {
            public const ushort c_len = 4;
            public const MsgTypeE c_msg_type = MsgTypeE.list_accounts_response_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public byte account_ids_count;

            public static unsafe ListAccountsResponseInnerT* Emplace(byte* buf)
            {
                ListAccountsResponseInnerT tmp = new ListAccountsResponseInnerT();
                var mem = (ListAccountsResponseInnerT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PositionUpdateRequestInnerT
        {
            public const ushort c_len = 13;
            public const MsgTypeE c_msg_type = MsgTypeE.position_update_request_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public ulong request_id;
            [MarshalAs(UnmanagedType.I1)]
            public bool is_immediately_cleared;
            public byte position_update_count;

            public static unsafe PositionUpdateRequestInnerT* Emplace(byte* buf)
            {
                PositionUpdateRequestInnerT tmp = new PositionUpdateRequestInnerT();
                var mem = (PositionUpdateRequestInnerT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PositionUpdateNotificationInnerT
        {
            public const ushort c_len = 13;
            public const MsgTypeE c_msg_type = MsgTypeE.position_update_notification_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public ulong ts;
            [MarshalAs(UnmanagedType.I1)]
            public bool is_immediately_cleared;
            public byte position_update_count;

            public static unsafe PositionUpdateNotificationInnerT* Emplace(byte* buf)
            {
                PositionUpdateNotificationInnerT tmp = new PositionUpdateNotificationInnerT();
                var mem = (PositionUpdateNotificationInnerT*)buf;
                *mem = tmp;
                return mem;
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ListAccountBalancesResponseInnerT
        {
            public const ushort c_len = 12;
            public const MsgTypeE c_msg_type = MsgTypeE.list_account_balances_response_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public ulong ts;
            public byte balances_count;

            public static unsafe ListAccountBalancesResponseInnerT* Emplace(byte* buf)
            {
                ListAccountBalancesResponseInnerT tmp = new ListAccountBalancesResponseInnerT();
                var mem = (ListAccountBalancesResponseInnerT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ListTransactionsForAccountResponseInnerT
        {
            public const ushort c_len = 21;
            public const MsgTypeE c_msg_type = MsgTypeE.list_transactions_for_account_response_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public ulong account_id;
            public ulong ts;
            [MarshalAs(UnmanagedType.I1)]
            public bool is_to_account;
            public byte transactions_count;

            public static unsafe ListTransactionsForAccountResponseInnerT* Emplace(byte* buf)
            {
                ListTransactionsForAccountResponseInnerT tmp = new ListTransactionsForAccountResponseInnerT();
                var mem = (ListTransactionsForAccountResponseInnerT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct GetTransactionDetailsResponseInnerT
        {
            public const ushort c_len = 12;
            public const MsgTypeE c_msg_type = MsgTypeE.get_transaction_details_response_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public ulong transaction_id;
            public byte details_count;

            public static unsafe GetTransactionDetailsResponseInnerT* Emplace(byte* buf)
            {
                GetTransactionDetailsResponseInnerT tmp = new GetTransactionDetailsResponseInnerT();
                var mem = (GetTransactionDetailsResponseInnerT*)buf;
                *mem = tmp;
                return mem;
            }
        }

        // Element

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PositionUpdateElementT
        {
            public const ushort c_len = 32;

            public ulong instrument_id;
            public ulong from_account_id;
            public ulong to_account_id;
            public ulong change_amount_nanos;

            public override string ToString()
            {
                return $"<position_update_element_t[ instrument_id: {instrument_id}, from_account_id: {from_account_id}, to_account_id: {to_account_id}, change_amount_nanos: {change_amount_nanos}]>";
            }

            public static unsafe PositionUpdateElementT* Emplace(byte* buf)
            {
                PositionUpdateElementT tmp = new PositionUpdateElementT();
                var mem = (PositionUpdateElementT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct BalanceElementT
        {
            public const ushort c_len = 24;

            public ulong instrument_id;
            public long pending_balance;
            public long cleared_balance;

            public override string ToString()
            {
                return $"<balance_element_t[ instrument_id: {instrument_id}, pending_balance: {pending_balance}, cleared_balance: {cleared_balance}]>";
            }

            public static unsafe BalanceElementT* Emplace(byte* buf)
            {
                BalanceElementT tmp = new BalanceElementT();
                var mem = (BalanceElementT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct TransactionElementT
        {
            public const ushort c_len = 24;

            public ulong transaction_id;
            public ulong ts;
            public ulong request_id;

            public override string ToString()
            {
                return $"<transaction_element_t[ transaction_id: {transaction_id}, ts: {ts}, request_id: {request_id}]>";
            }

            public static unsafe TransactionElementT* Emplace(byte* buf)
            {
                TransactionElementT tmp = new TransactionElementT();
                var mem = (TransactionElementT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct TransactionDetailElementT
        {
            public const ushort c_len = 37;

            public ulong instrument_id;
            public ulong from_account_id;
            public ulong to_account_id;
            public ulong change;
            [MarshalAs(UnmanagedType.I1)]
            public bool is_cleared;
            [MarshalAs(UnmanagedType.I1)]
            public bool is_reverted;

            public override string ToString()
            {
                return $"<transaction_detail_element_t[ instrument_id: {instrument_id}, from_account_id: {from_account_id}, to_account_id: {to_account_id}, change: {change}, is_cleared: {(is_cleared ? 'T' : 'F')}, is_reverted: {(is_reverted ? 'T' : 'F')}]>";
            }

            public static unsafe TransactionDetailElementT* Emplace(byte* buf)
            {
                TransactionDetailElementT tmp = new TransactionDetailElementT();
                var mem = (TransactionDetailElementT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        public unsafe class GetAccountChildrenResponseMsgT
        {
            private GetAccountChildrenResponseInnerT* inner = null;
            private List<ulong> elements = new List<ulong>();
            private byte* layer_buf_ptr = null;
            private ushort* len_ptr = null;
            public Nullable<ulong> account_id
            {
                get
                {
                    if (inner == null)
                        return null;
                    return inner->account_id;
                }
                set
                {
                    if (inner == null)
                        return;
                    if (!value.HasValue)
                        inner->account_id = 0;
                    inner->account_id = value.Value;
                }
            }
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
            public byte Count
            {
                get
                {
                    if (inner != null)
                        return inner->account_ids_count;
                    return 0;
                }
                set
                {
                    if (inner != null)
                        inner->account_ids_count = value;
                }
            }
            public Nullable<ulong> get_account_ids(byte idx)
            {
                if (idx > get_account_ids_count())
                    return null;
                return elements[idx];
            }
            public ushort get_account_ids_count()
            {
                return (ushort)elements.Count;
            }
            public void parse(byte* buf)
            {
                inner = (GetAccountChildrenResponseInnerT*)buf;
                buf += GetAccountChildrenResponseInnerT.c_len;
                for (byte i = 0; i < Count; ++i)
                {
                    ulong* elm = (ulong*)buf;
                    elements.Add(*elm);
                    buf += UlongPtrT.c_len;
                }
            }
            public bool parse(byte* buf, uint bufsz)
            {
                if (bufsz < GetAccountChildrenResponseInnerT.c_len)
                    return false;
                inner = (GetAccountChildrenResponseInnerT*)buf;
                buf += GetAccountChildrenResponseInnerT.c_len;
                if (bufsz < Count * UlongPtrT.c_len)
                    return false;
                bufsz -= GetAccountChildrenResponseInnerT.c_len;
                for (byte i = 0; i < Count; ++i)
                {
                    ulong* elm = (ulong*)buf;
                    elements.Add(*elm);
                    buf += UlongPtrT.c_len;
                    bufsz -= UlongPtrT.c_len;
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
                inner = (GetAccountChildrenResponseInnerT*)buf;
                inner->len = GetAccountChildrenResponseInnerT.c_len;
                inner->msg_type = GetAccountChildrenResponseInnerT.c_msg_type;
                len_ptr = &inner->len;
                layer_buf_ptr = buf + GetAccountChildrenResponseInnerT.c_len;
                *len_ptr += GetAccountChildrenResponseInnerT.c_len;
            }
            public bool construct(byte* buf, uint bufsz)
            {
                if (bufsz < GetAccountChildrenResponseInnerT.c_len)
                    return false;
                inner = (GetAccountChildrenResponseInnerT*)buf;
                inner->len = GetAccountChildrenResponseInnerT.c_len;
                inner->msg_type = GetAccountChildrenResponseInnerT.c_msg_type;
                len_ptr = &inner->len;
                layer_buf_ptr = buf + GetAccountChildrenResponseInnerT.c_len;
                *len_ptr += GetAccountChildrenResponseInnerT.c_len;
                return true;
            }
            public UlongPtrT add_account_ids(byte* buf)
            {
                ushort offset = GetAccountChildrenResponseInnerT.c_len;
                for (byte i = 0; i < Count; ++i)
                    offset += UlongPtrT.c_len;
                ulong* ptr = (ulong*)layer_buf_ptr;
                layer_buf_ptr += UlongPtrT.c_len;
                *len_ptr += UlongPtrT.c_len;
                elements.Add(*ptr);
                inner->account_ids_count++;
                return new UlongPtrT(ptr);
            }
            public UlongPtrT add_account_ids(byte* buf, uint bufsz)
            {
                ushort offset = GetAccountChildrenResponseInnerT.c_len;
                for (byte i = 0; i < Count; ++i)
                    offset += UlongPtrT.c_len;
                if (bufsz < (offset + UlongPtrT.c_len))
                    return null;
                if (bufsz - (layer_buf_ptr - buf) < UlongPtrT.c_len)
                    return null;
                ulong* ptr = (ulong*)layer_buf_ptr;
                layer_buf_ptr += UlongPtrT.c_len;
                *len_ptr += UlongPtrT.c_len;
                elements.Add(*ptr);
                inner->account_ids_count++;
                return new UlongPtrT(ptr);
            }
            public void clear()
            {
                inner = null;
                elements.Clear();
            }
        }
        public unsafe class ListAccountsResponseMsgT
        {
            private ListAccountsResponseInnerT* inner = null;
            private List<ulong> elements = new List<ulong>();
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
            public byte Count
            {
                get
                {
                    if (inner != null)
                        return inner->account_ids_count;
                    return 0;
                }
                set
                {
                    if (inner != null)
                        inner->account_ids_count = value;
                }
            }
            public Nullable<ulong> get_account_ids(byte idx)
            {
                if (idx > get_account_ids_count())
                    return null;
                return elements[idx];
            }
            public ushort get_account_ids_count()
            {
                return (ushort)elements.Count;
            }
            public void parse(byte* buf)
            {
                inner = (ListAccountsResponseInnerT*)buf;
                buf += ListAccountsResponseInnerT.c_len;
                for (byte i = 0; i < Count; ++i)
                {
                    ulong* elm = (ulong*)buf;
                    elements.Add(*elm);
                    buf += UlongPtrT.c_len;
                }
            }
            public bool parse(byte* buf, uint bufsz)
            {
                if (bufsz < ListAccountsResponseInnerT.c_len)
                    return false;
                inner = (ListAccountsResponseInnerT*)buf;
                buf += ListAccountsResponseInnerT.c_len;
                if (bufsz < Count * UlongPtrT.c_len)
                    return false;
                bufsz -= ListAccountsResponseInnerT.c_len;
                for (byte i = 0; i < Count; ++i)
                {
                    ulong* elm = (ulong*)buf;
                    elements.Add(*elm);
                    buf += UlongPtrT.c_len;
                    bufsz -= UlongPtrT.c_len;
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
                inner = (ListAccountsResponseInnerT*)buf;
                inner->len = ListAccountsResponseInnerT.c_len;
                inner->msg_type = ListAccountsResponseInnerT.c_msg_type;
                len_ptr = &inner->len;
                layer_buf_ptr = buf + ListAccountsResponseInnerT.c_len;
                *len_ptr += ListAccountsResponseInnerT.c_len;
            }
            public bool construct(byte* buf, uint bufsz)
            {
                if (bufsz < ListAccountsResponseInnerT.c_len)
                    return false;
                inner = (ListAccountsResponseInnerT*)buf;
                inner->len = ListAccountsResponseInnerT.c_len;
                inner->msg_type = ListAccountsResponseInnerT.c_msg_type;
                len_ptr = &inner->len;
                layer_buf_ptr = buf + ListAccountsResponseInnerT.c_len;
                *len_ptr += ListAccountsResponseInnerT.c_len;
                return true;
            }
            public UlongPtrT add_account_ids(byte* buf)
            {
                ushort offset = ListAccountsResponseInnerT.c_len;
                for (byte i = 0; i < Count; ++i)
                    offset += UlongPtrT.c_len;
                ulong* ptr = (ulong*)layer_buf_ptr;
                layer_buf_ptr += UlongPtrT.c_len;
                *len_ptr += UlongPtrT.c_len;
                elements.Add(*ptr);
                inner->account_ids_count++;
                return new UlongPtrT(ptr);
            }
            public UlongPtrT add_account_ids(byte* buf, uint bufsz)
            {
                ushort offset = ListAccountsResponseInnerT.c_len;
                for (byte i = 0; i < Count; ++i)
                    offset += UlongPtrT.c_len;
                if (bufsz < (offset + UlongPtrT.c_len))
                    return null;
                if (bufsz - (layer_buf_ptr - buf) < UlongPtrT.c_len)
                    return null;
                ulong* ptr = (ulong*)layer_buf_ptr;
                layer_buf_ptr += UlongPtrT.c_len;
                *len_ptr += UlongPtrT.c_len;
                elements.Add(*ptr);
                inner->account_ids_count++;
                return new UlongPtrT(ptr);
            }
            public void clear()
            {
                inner = null;
                elements.Clear();
            }
        }
        public unsafe class PositionUpdateRequestMsgT
        {
            private PositionUpdateRequestInnerT* inner = null;
            private PtrVectorT elements = new PtrVectorT();
            private byte* layer_buf_ptr = null;
            private ushort* len_ptr = null;
            public Nullable<bool> is_immediately_cleared
            {
                get
                {
                    if (inner == null)
                        return null;
                    return inner->is_immediately_cleared;
                }
                set
                {
                    if (inner == null)
                        return;
                    if (!value.HasValue)
                        inner->is_immediately_cleared = false;
                    inner->is_immediately_cleared = value.Value;
                }
            }
            public Nullable<ulong> request_id
            {
                get
                {
                    if (inner == null)
                        return null;
                    return inner->request_id;
                }
                set
                {
                    if (inner == null)
                        return;
                    if (!value.HasValue)
                        inner->request_id = 0;
                    inner->request_id = value.Value;
                }
            }
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
            public byte Count
            {
                get
                {
                    if (inner != null)
                        return inner->position_update_count;
                    return 0;
                }
                set
                {
                    if (inner != null)
                        inner->position_update_count = value;
                }
            }
            public PositionUpdateElementT* get_positions_updates(byte idx)
            {
                if (idx > get_position_update_count())
                    return null;
                return (PositionUpdateElementT*)elements.Get(idx);
            }
            public ushort get_position_update_count()
            {
                return (ushort)elements.Count;
            }
            public void parse(byte* buf)
            {
                inner = (PositionUpdateRequestInnerT*)buf;
                buf += PositionUpdateRequestInnerT.c_len;
                for (byte i = 0; i < Count; ++i)
                {
                    elements.Add(buf);
                    buf += PositionUpdateElementT.c_len;
                }
            }
            public bool parse(byte* buf, uint bufsz)
            {
                if (bufsz < PositionUpdateRequestInnerT.c_len)
                    return false;
                inner = (PositionUpdateRequestInnerT*)buf;
                buf += PositionUpdateRequestInnerT.c_len;
                if (bufsz < Count * 8)
                    return false;
                bufsz -= PositionUpdateRequestInnerT.c_len;
                for (byte i = 0; i < Count; ++i)
                {
                    elements.Add(buf);
                    buf += PositionUpdateElementT.c_len;
                    bufsz -= PositionUpdateElementT.c_len;
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
                inner = (PositionUpdateRequestInnerT*)buf;
                inner->len = PositionUpdateRequestInnerT.c_len;
                inner->msg_type = PositionUpdateRequestInnerT.c_msg_type;
                len_ptr = &inner->len;
                layer_buf_ptr = buf + PositionUpdateRequestInnerT.c_len;
                *len_ptr += PositionUpdateRequestInnerT.c_len;
            }
            public bool construct(byte* buf, uint bufsz)
            {
                if (bufsz < PositionUpdateRequestInnerT.c_len)
                    return false;
                inner = (PositionUpdateRequestInnerT*)buf;
                inner->len = PositionUpdateRequestInnerT.c_len;
                inner->msg_type = PositionUpdateRequestInnerT.c_msg_type;
                len_ptr = &inner->len;
                layer_buf_ptr = buf + PositionUpdateRequestInnerT.c_len;
                *len_ptr += PositionUpdateRequestInnerT.c_len;
                return true;
            }
            public PositionUpdateElementT* add_positions_updates(byte* buf)
            {
                ushort offset = PositionUpdateRequestInnerT.c_len;
                for (byte i = 0; i < Count; ++i)
                    offset += PositionUpdateElementT.c_len;
                PositionUpdateElementT* ptr = PositionUpdateElementT.Emplace(layer_buf_ptr);
                byte* mem_ptr = layer_buf_ptr;
                layer_buf_ptr += PositionUpdateElementT.c_len;
                *len_ptr += PositionUpdateElementT.c_len;
                elements.Add(mem_ptr);
                inner->position_update_count++;
                return ptr;
            }
            public PositionUpdateElementT* add_positions_updates(byte* buf, uint bufsz)
            {
                ushort offset = PositionUpdateRequestInnerT.c_len;
                for (byte i = 0; i < Count; ++i)
                    offset += PositionUpdateElementT.c_len;
                if (bufsz < (offset + PositionUpdateElementT.c_len))
                    return null;
                if (bufsz - (layer_buf_ptr - buf) < PositionUpdateElementT.c_len)
                    return null;
                PositionUpdateElementT* ptr = PositionUpdateElementT.Emplace(layer_buf_ptr);
                byte* mem_ptr = layer_buf_ptr;
                layer_buf_ptr += PositionUpdateElementT.c_len;
                *len_ptr += PositionUpdateElementT.c_len;
                elements.Add(mem_ptr);
                inner->position_update_count++;
                return ptr;
            }
            public void clear()
            {
                inner = null;
                elements.Clear();
            }
        }
        public unsafe class PositionUpdateNotificationMsgT
        {
            private PositionUpdateNotificationInnerT* inner = null;
            private PtrVectorT elements = new PtrVectorT();
            private byte* layer_buf_ptr = null;
            private ushort* len_ptr = null;
            public Nullable<bool> is_immediately_cleared
            {
                get
                {
                    if (inner == null)
                        return null;
                    return inner->is_immediately_cleared;
                }
                set
                {
                    if (inner == null)
                        return;
                    if (!value.HasValue)
                        inner->is_immediately_cleared = false;
                    inner->is_immediately_cleared = value.Value;
                }
            }
            public Nullable<ulong> ts
            {
                get
                {
                    if (inner == null)
                        return null;
                    return inner->ts;
                }
                set
                {
                    if (inner == null)
                        return;
                    if (!value.HasValue)
                        inner->ts = 0;
                    inner->ts = value.Value;
                }
            }

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
            public byte Count
            {
                get
                {
                    if (inner != null)
                        return inner->position_update_count;
                    return 0;
                }
                set
                {
                    if (inner != null)
                        inner->position_update_count = value;
                }
            }
            public PositionUpdateElementT* get_positions_updates(byte idx)
            {
                if (idx > get_position_update_count())
                    return null;
                return (PositionUpdateElementT*)elements.Get(idx);
            }
            public ushort get_position_update_count()
            {
                return (ushort)elements.Count;
            }
            public void parse(byte* buf)
            {
                inner = (PositionUpdateNotificationInnerT*)buf;
                buf += PositionUpdateNotificationInnerT.c_len;
                for (byte i = 0; i < Count; ++i)
                {
                    elements.Add(buf);
                    buf += PositionUpdateElementT.c_len;
                }
            }
            public bool parse(byte* buf, uint bufsz)
            {
                if (bufsz < PositionUpdateNotificationInnerT.c_len)
                    return false;
                inner = (PositionUpdateNotificationInnerT*)buf;
                buf += PositionUpdateNotificationInnerT.c_len;
                if (bufsz < Count * 8)
                    return false;
                bufsz -= PositionUpdateNotificationInnerT.c_len;
                for (byte i = 0; i < Count; ++i)
                {
                    elements.Add(buf);
                    buf += PositionUpdateElementT.c_len;
                    bufsz -= PositionUpdateElementT.c_len;
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
                inner = (PositionUpdateNotificationInnerT*)buf;
                inner->len = PositionUpdateNotificationInnerT.c_len;
                inner->msg_type = PositionUpdateNotificationInnerT.c_msg_type;
                len_ptr = &inner->len;
                layer_buf_ptr = buf + PositionUpdateNotificationInnerT.c_len;
                *len_ptr += PositionUpdateNotificationInnerT.c_len;
            }
            public bool construct(byte* buf, uint bufsz)
            {
                if (bufsz < PositionUpdateNotificationInnerT.c_len)
                    return false;
                inner = (PositionUpdateNotificationInnerT*)buf;
                inner->len = PositionUpdateNotificationInnerT.c_len;
                inner->msg_type = PositionUpdateNotificationInnerT.c_msg_type;
                len_ptr = &inner->len;
                layer_buf_ptr = buf + PositionUpdateNotificationInnerT.c_len;
                *len_ptr += PositionUpdateNotificationInnerT.c_len;
                return true;
            }
            public PositionUpdateElementT* add_positions_updates(byte* buf)
            {
                ushort offset = PositionUpdateNotificationInnerT.c_len;
                for (byte i = 0; i < Count; ++i)
                    offset += PositionUpdateElementT.c_len;
                PositionUpdateElementT* ptr = PositionUpdateElementT.Emplace(layer_buf_ptr);
                byte* mem_ptr = layer_buf_ptr;
                layer_buf_ptr += PositionUpdateElementT.c_len;
                *len_ptr += PositionUpdateElementT.c_len;
                elements.Add(mem_ptr);
                inner->position_update_count++;
                return ptr;
            }
            public PositionUpdateElementT* add_positions_updates(byte* buf, uint bufsz)
            {
                ushort offset = PositionUpdateNotificationInnerT.c_len;
                for (byte i = 0; i < Count; ++i)
                    offset += PositionUpdateElementT.c_len;
                if (bufsz < (offset + PositionUpdateElementT.c_len))
                    return null;
                if (bufsz - (layer_buf_ptr - buf) < PositionUpdateElementT.c_len)
                    return null;
                PositionUpdateElementT* ptr = PositionUpdateElementT.Emplace(layer_buf_ptr);
                byte* mem_ptr = layer_buf_ptr;
                layer_buf_ptr += PositionUpdateElementT.c_len;
                *len_ptr += PositionUpdateElementT.c_len;
                elements.Add(mem_ptr);
                inner->position_update_count++;
                return ptr;
            }
            public void clear()
            {
                inner = null;
                elements.Clear();
            }
        }
        public unsafe class ListAccountBalancesResponseMsgT
        {
            private ListAccountBalancesResponseInnerT* inner = null;
            private PtrVectorT elements = new PtrVectorT();
            private byte* layer_buf_ptr = null;
            private ushort* len_ptr = null;
            public Nullable<ulong> ts
            {
                get
                {
                    if (inner == null)
                        return null;
                    return inner->ts;
                }
                set
                {
                    if (inner == null)
                        return;
                    if (!value.HasValue)
                        inner->ts = 0;
                    inner->ts = value.Value;
                }
            }
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
            public byte Count
            {
                get
                {
                    if (inner != null)
                        return inner->balances_count;
                    return 0;
                }
                set
                {
                    if (inner != null)
                        inner->balances_count = value;
                }
            }
            public BalanceElementT* get_balances(byte idx)
            {
                if (idx > get_balances_count())
                    return null;
                return (BalanceElementT*)elements.Get(idx);
            }
            public ushort get_balances_count()
            {
                return (ushort)elements.Count;
            }
            public void parse(byte* buf)
            {
                inner = (ListAccountBalancesResponseInnerT*)buf;
                buf += ListAccountBalancesResponseInnerT.c_len;
                for (byte i = 0; i < Count; ++i)
                {
                    elements.Add(buf);
                    buf += BalanceElementT.c_len;
                }
            }
            public bool parse(byte* buf, uint bufsz)
            {
                if (bufsz < ListAccountBalancesResponseInnerT.c_len)
                    return false;
                inner = (ListAccountBalancesResponseInnerT*)buf;
                buf += ListAccountBalancesResponseInnerT.c_len;
                if (bufsz < Count * 8)
                    return false;
                bufsz -= ListAccountBalancesResponseInnerT.c_len;
                for (byte i = 0; i < Count; ++i)
                {
                    elements.Add(buf);
                    buf += BalanceElementT.c_len;
                    bufsz -= BalanceElementT.c_len;
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
                inner = (ListAccountBalancesResponseInnerT*)buf;
                inner->len = ListAccountBalancesResponseInnerT.c_len;
                inner->msg_type = ListAccountBalancesResponseInnerT.c_msg_type;
                len_ptr = &inner->len;
                layer_buf_ptr = buf + ListAccountBalancesResponseInnerT.c_len;
                *len_ptr += ListAccountBalancesResponseInnerT.c_len;
            }
            public bool construct(byte* buf, uint bufsz)
            {
                if (bufsz < ListAccountBalancesResponseInnerT.c_len)
                    return false;
                inner = (ListAccountBalancesResponseInnerT*)buf;
                inner->len = ListAccountBalancesResponseInnerT.c_len;
                inner->msg_type = ListAccountBalancesResponseInnerT.c_msg_type;
                len_ptr = &inner->len;
                layer_buf_ptr = buf + ListAccountBalancesResponseInnerT.c_len;
                *len_ptr += ListAccountBalancesResponseInnerT.c_len;
                return true;
            }
            public BalanceElementT* add_balances(byte* buf)
            {
                ushort offset = ListAccountBalancesResponseInnerT.c_len;
                for (byte i = 0; i < Count; ++i)
                    offset += BalanceElementT.c_len;
                BalanceElementT* ptr = BalanceElementT.Emplace(layer_buf_ptr);
                byte* mem_ptr = layer_buf_ptr;
                layer_buf_ptr += BalanceElementT.c_len;
                *len_ptr += BalanceElementT.c_len;
                elements.Add(mem_ptr);
                inner->balances_count++;
                return ptr;
            }
            public BalanceElementT* add_balances(byte* buf, uint bufsz)
            {
                ushort offset = ListAccountBalancesResponseInnerT.c_len;
                for (byte i = 0; i < Count; ++i)
                    offset += BalanceElementT.c_len;
                if (bufsz < (offset + BalanceElementT.c_len))
                    return null;
                if (bufsz - (layer_buf_ptr - buf) < BalanceElementT.c_len)
                    return null;
                BalanceElementT* ptr = BalanceElementT.Emplace(layer_buf_ptr);
                byte* mem_ptr = layer_buf_ptr;
                layer_buf_ptr += BalanceElementT.c_len;
                *len_ptr += BalanceElementT.c_len;
                elements.Add(mem_ptr);
                inner->balances_count++;
                return ptr;
            }
            public void clear()
            {
                inner = null;
                elements.Clear();
            }
        }
        public unsafe class ListTransactionsForAccountResponseMsgT
        {
            private ListTransactionsForAccountResponseInnerT* inner = null;
            private PtrVectorT elements = new PtrVectorT();
            private byte* layer_buf_ptr = null;
            private ushort* len_ptr = null;
            public Nullable<ulong> account_id
            {
                get
                {
                    if (inner == null)
                        return null;
                    return inner->account_id;
                }
                set
                {
                    if (inner == null)
                        return;
                    if (!value.HasValue)
                        inner->account_id = 0;
                    inner->account_id = value.Value;
                }
            }
            public Nullable<ulong> ts
            {
                get
                {
                    if (inner == null)
                        return null;
                    return inner->ts;
                }
                set
                {
                    if (inner == null)
                        return;
                    if (!value.HasValue)
                        inner->ts = 0;
                    inner->ts = value.Value;
                }
            }
            public Nullable<bool> is_to_account
            {
                get
                {
                    if (inner == null)
                        return null;
                    return inner->is_to_account;
                }
                set
                {
                    if (inner == null)
                        return;
                    if (!value.HasValue)
                        inner->is_to_account = false;
                    inner->is_to_account = value.Value;
                }
            }
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
            public byte Count
            {
                get
                {
                    if (inner != null)
                        return inner->transactions_count;
                    return 0;
                }
                set
                {
                    if (inner != null)
                        inner->transactions_count = value;
                }
            }
            public TransactionElementT* get_transactions(byte idx)
            {
                if (idx > get_transactions_count())
                    return null;
                return (TransactionElementT*)elements.Get(idx);
            }
            public ushort get_transactions_count()
            {
                return (ushort)elements.Count;
            }
            public void parse(byte* buf)
            {
                inner = (ListTransactionsForAccountResponseInnerT*)buf;
                buf += ListTransactionsForAccountResponseInnerT.c_len;
                for (byte i = 0; i < Count; ++i)
                {
                    elements.Add(buf);
                    buf += TransactionElementT.c_len;
                }
            }
            public bool parse(byte* buf, uint bufsz)
            {
                if (bufsz < ListTransactionsForAccountResponseInnerT.c_len)
                    return false;
                inner = (ListTransactionsForAccountResponseInnerT*)buf;
                buf += ListTransactionsForAccountResponseInnerT.c_len;
                if (bufsz < Count * 8)
                    return false;
                bufsz -= ListTransactionsForAccountResponseInnerT.c_len;
                for (byte i = 0; i < Count; ++i)
                {
                    elements.Add(buf);
                    buf += TransactionElementT.c_len;
                    bufsz -= TransactionElementT.c_len;
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
                inner = (ListTransactionsForAccountResponseInnerT*)buf;
                inner->len = ListTransactionsForAccountResponseInnerT.c_len;
                inner->msg_type = ListTransactionsForAccountResponseInnerT.c_msg_type;
                len_ptr = &inner->len;
                layer_buf_ptr = buf + ListTransactionsForAccountResponseInnerT.c_len;
                *len_ptr += ListTransactionsForAccountResponseInnerT.c_len;
            }
            public bool construct(byte* buf, uint bufsz)
            {
                if (bufsz < ListTransactionsForAccountResponseInnerT.c_len)
                    return false;
                inner = (ListTransactionsForAccountResponseInnerT*)buf;
                inner->len = ListTransactionsForAccountResponseInnerT.c_len;
                inner->msg_type = ListTransactionsForAccountResponseInnerT.c_msg_type;
                len_ptr = &inner->len;
                layer_buf_ptr = buf + ListTransactionsForAccountResponseInnerT.c_len;
                *len_ptr += ListTransactionsForAccountResponseInnerT.c_len;
                return true;
            }
            public TransactionElementT* add_transaction(byte* buf)
            {
                ushort offset = ListTransactionsForAccountResponseInnerT.c_len;
                for (byte i = 0; i < Count; ++i)
                    offset += TransactionElementT.c_len;
                TransactionElementT* ptr = TransactionElementT.Emplace(layer_buf_ptr);
                byte* mem_ptr = layer_buf_ptr;
                layer_buf_ptr += TransactionElementT.c_len;
                *len_ptr += TransactionElementT.c_len;
                elements.Add(mem_ptr);
                inner->transactions_count++;
                return ptr;
            }
            public TransactionElementT* add_transaction(byte* buf, uint bufsz)
            {
                ushort offset = ListTransactionsForAccountResponseInnerT.c_len;
                for (byte i = 0; i < Count; ++i)
                    offset += TransactionElementT.c_len;
                if (bufsz < (offset + TransactionElementT.c_len))
                    return null;
                if (bufsz - (layer_buf_ptr - buf) < TransactionElementT.c_len)
                    return null;
                TransactionElementT* ptr = TransactionElementT.Emplace(layer_buf_ptr);
                byte* mem_ptr = layer_buf_ptr;
                layer_buf_ptr += TransactionElementT.c_len;
                *len_ptr += TransactionElementT.c_len;
                elements.Add(mem_ptr);
                inner->transactions_count++;
                return ptr;
            }
            public void clear()
            {
                inner = null;
                elements.Clear();
            }
        }
        public unsafe class GetTransactionDetailsResponseMsgT
        {
            private GetTransactionDetailsResponseInnerT* inner = null;
            private PtrVectorT elements = new PtrVectorT();
            private byte* layer_buf_ptr = null;
            private ushort* len_ptr = null;
            public Nullable<ulong> transaction_id
            {
                get
                {
                    if (inner == null)
                        return null;
                    return inner->transaction_id;
                }
                set
                {
                    if (inner == null)
                        return;
                    if (!value.HasValue)
                        inner->transaction_id = 0;
                    inner->transaction_id = value.Value;
                }
            }
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
            public byte Count
            {
                get
                {
                    if (inner != null)
                        return inner->details_count;
                    return 0;
                }
                set
                {
                    if (inner != null)
                        inner->details_count = value;
                }
            }
            public TransactionDetailElementT* get_details(byte idx)
            {
                if (idx > get_details_count())
                    return null;
                return (TransactionDetailElementT*)elements.Get(idx);
            }
            public ushort get_details_count()
            {
                return (ushort)elements.Count;
            }
            public void parse(byte* buf)
            {
                inner = (GetTransactionDetailsResponseInnerT*)buf;
                buf += GetTransactionDetailsResponseInnerT.c_len;
                for (byte i = 0; i < Count; ++i)
                {
                    elements.Add(buf);
                    buf += TransactionDetailElementT.c_len;
                }
            }
            public bool parse(byte* buf, uint bufsz)
            {
                if (bufsz < GetTransactionDetailsResponseInnerT.c_len)
                    return false;
                inner = (GetTransactionDetailsResponseInnerT*)buf;
                buf += GetTransactionDetailsResponseInnerT.c_len;
                if (bufsz < Count * 8)
                    return false;
                bufsz -= GetTransactionDetailsResponseInnerT.c_len;
                for (byte i = 0; i < Count; ++i)
                {
                    elements.Add(buf);
                    buf += TransactionDetailElementT.c_len;
                    bufsz -= TransactionDetailElementT.c_len;
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
                inner = (GetTransactionDetailsResponseInnerT*)buf;
                inner->len = GetTransactionDetailsResponseInnerT.c_len;
                inner->msg_type = GetTransactionDetailsResponseInnerT.c_msg_type;
                len_ptr = &inner->len;
                layer_buf_ptr = buf + GetTransactionDetailsResponseInnerT.c_len;
                *len_ptr += GetTransactionDetailsResponseInnerT.c_len;
            }
            public bool construct(byte* buf, uint bufsz)
            {
                if (bufsz < GetTransactionDetailsResponseInnerT.c_len)
                    return false;
                inner = (GetTransactionDetailsResponseInnerT*)buf;
                inner->len = GetTransactionDetailsResponseInnerT.c_len;
                inner->msg_type = GetTransactionDetailsResponseInnerT.c_msg_type;
                len_ptr = &inner->len;
                layer_buf_ptr = buf + GetTransactionDetailsResponseInnerT.c_len;
                *len_ptr += GetTransactionDetailsResponseInnerT.c_len;
                return true;
            }
            public TransactionDetailElementT* add_details(byte* buf)
            {
                ushort offset = GetTransactionDetailsResponseInnerT.c_len;
                for (byte i = 0; i < Count; ++i)
                    offset += TransactionDetailElementT.c_len;
                TransactionDetailElementT* ptr = TransactionDetailElementT.Emplace(layer_buf_ptr);
                byte* mem_ptr = layer_buf_ptr;
                layer_buf_ptr += TransactionDetailElementT.c_len;
                *len_ptr += TransactionDetailElementT.c_len;
                elements.Add(mem_ptr);
                inner->details_count++;
                return ptr;
            }
            public TransactionDetailElementT* add_details(byte* buf, uint bufsz)
            {
                ushort offset = GetTransactionDetailsResponseInnerT.c_len;
                for (byte i = 0; i < Count; ++i)
                    offset += TransactionDetailElementT.c_len;
                if (bufsz < (offset + TransactionDetailElementT.c_len))
                    return null;
                if (bufsz - (layer_buf_ptr - buf) < TransactionDetailElementT.c_len)
                    return null;
                TransactionDetailElementT* ptr = TransactionDetailElementT.Emplace(layer_buf_ptr);
                byte* mem_ptr = layer_buf_ptr;
                layer_buf_ptr += TransactionDetailElementT.c_len;
                *len_ptr += TransactionDetailElementT.c_len;
                elements.Add(mem_ptr);
                inner->details_count++;
                return ptr;
            }
            public void clear()
            {
                inner = null;
                elements.Clear();
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct HeartbeatT
        {
            public ulong ts;

            public static unsafe HeartbeatT* Emplace(byte* buf)
            {
                HeartbeatT tmp = new HeartbeatT();
                var mem = (HeartbeatT*)buf;
                *mem = tmp;
                return mem;
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct HeartbeatMsgT
        {
            public const ushort c_len = 11;
            public const MsgTypeE c_msg_type = MsgTypeE.heartbeat_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public HeartbeatT heartbeat;

            public static unsafe HeartbeatMsgT* Emplace(byte* buf)
            {
                var mem = (HeartbeatMsgT*)buf;
                mem->len = c_len;
                mem->msg_type = c_msg_type;
                return mem;
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
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