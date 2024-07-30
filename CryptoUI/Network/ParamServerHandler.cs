using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCore;

namespace CryptoUI.Network
{
    class ParamServerHandler : INetworkHandler
    {
        private ITcpClient network = null;
        private IEventHandler handler;
        uint sequenceNum;
        public ParamServerHandler(IEventHandler handler_)
        {
            handler = handler_;
            sequenceNum = 0;
        }
        public override unsafe long recv(RingBuffer rx, int nbytes, out bool shoulddisconnect)
        {
            long nbytesread = 0;
            shoulddisconnect = false;
            while (rx.Usedspace - nbytesread > Protocol.ParamServerN.Constants.HeaderLength)
            {
                //Logger.Log(Logger.Level.info, $"ParamServerN {nbytes} \n{Hexify(rx.Data, rx.ReadOffset, rx.UsedSpace)}");
                byte* rxbuf = rx.BeginRead;
                {
                    byte* buf = rxbuf + nbytesread;
                    var header = (Protocol.ParamServerN.HeaderT*)buf;
                    if (header->len > rx.Usedspace - nbytesread)
                        break;
                    switch (header->msg_type)
                    {
                        case Protocol.ParamServerN.MsgTypeE.param_change_msg:
                            {
                                Protocol.ParamServerN.ParamChangeMsgT msg = new Protocol.ParamServerN.ParamChangeMsgT();
                                if (msg.parse(buf, rx.Usedspace - (uint)nbytesread))
                                    handler.onParamChange(msg);
                                else
                                {
                                    Logger.Log(Logger.Level.error, "Failed to parse ParamChangeMsg");
                                    byte[] d = new byte[rx.Usedspace - nbytesread];
                                    for (int i = 0; i < rx.Usedspace - nbytesread; ++i)
                                        d[i] = buf[i];
                                    Logger.Log(Logger.Level.info, $"ParamServerN {nbytes} \n{Hexify(d, 0, (uint)(rx.Usedspace - nbytesread))}");
                                }
                            }
                            break;
                        case Protocol.ParamServerN.MsgTypeE.major_group_subscribe_ack_msg:
                            {
                                var msg = (Protocol.ParamServerN.MajorGroupSubscribeAckMsgT*)buf;
                                handler.onMajorGroupSubscribeAck(msg->subscription_ack);
                            }
                            break;
                        case Protocol.ParamServerN.MsgTypeE.lock_for_snapshot_msg:
                            {
                                var msg = (Protocol.ParamServerN.LockForSnapshotMsgT*)buf;
                                handler.onSnapshotLock();
                            }
                            break;
                        case Protocol.ParamServerN.MsgTypeE.unlock_for_snapshot_msg:
                            {
                                var msg = (Protocol.ParamServerN.UnlockForSnapshotMsgT*)buf;
                                handler.onSnapshotUnlock();
                            }
                            break;
                        case Protocol.ParamServerN.MsgTypeE.heartbeat_msg:
                            {
                                var msg = (Protocol.ParamServerN.HeartbeatMsgT*)buf;
                                handler.onParamHeartbeatSeq(msg->heartbeat.sequence);
                            }
                            break;
                        case Protocol.ParamServerN.MsgTypeE.major_group_subscribe_msg:
                        case Protocol.ParamServerN.MsgTypeE.major_group_unsubscribe_msg:
                        case Protocol.ParamServerN.MsgTypeE.invalid:
                        default:
                            {
                                Logger.Log(Logger.Level.error, $"param_server_client recvd unknown hdr, disconnecting, {header->msg_type} {header->len}");
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
            handler.onParamDisconnect();
        }
        public override unsafe bool onHeartbeat(ulong ts)
        {
            byte* pos = network.EmplaceReserve(Protocol.ParamServerN.HeartbeatMsgT.c_len);
            if (pos == null)
            {
                Logger.Log(Logger.Level.error, "ParamClient Failed to write Heartbeat!!");
                return false;
            }
            byte* buf = pos;
            var hb = Protocol.ParamServerN.HeartbeatMsgT.Emplace(buf);
            hb->heartbeat.sequence = sequenceNum;
            hb->heartbeat.ts = ts;
            //Logger.Log(Logger.Level.info, $"writing hb:\n{Hexify(network.Tx.PeekBytes, 0, Protocol.ParamServerN.HeartbeatMsgT.c_len)}");
            return network.EmplaceCommit(Protocol.ParamServerN.HeartbeatMsgT.c_len) == Protocol.ParamServerN.HeartbeatMsgT.c_len;
        }
        public unsafe bool publishSubscribe(ulong id)
        {
            byte* pos = network.EmplaceReserve(Protocol.ParamServerN.MajorGroupSubscribeMsgT.c_len);
            if (pos == null)
            {
                Logger.Log(Logger.Level.error, "ParamClient Failed to write MajorGroupSubscribeMsg!!");
                return false;
            }
            byte* buf = pos;
            var hb = Protocol.ParamServerN.MajorGroupSubscribeMsgT.Emplace(buf);
            hb->subscription.major_group_id = id;
            return network.EmplaceCommit(Protocol.ParamServerN.MajorGroupSubscribeMsgT.c_len) == Protocol.ParamServerN.MajorGroupSubscribeMsgT.c_len;
        }
        public unsafe bool publishUnsubscribe(ulong id)
        {
            byte* pos = network.EmplaceReserve(Protocol.ParamServerN.MajorGroupUnsubscribeMsgT.c_len);
            if (pos == null)
            {
                Logger.Log(Logger.Level.error, "ParamClient Failed to write MajorGroupUnsubscribeMsg!!");
                return false;
            }
            byte* buf = pos;
            var hb = Protocol.ParamServerN.MajorGroupUnsubscribeMsgT.Emplace(buf);
            hb->unsubscription.major_group_id = id;
            return network.EmplaceCommit(Protocol.ParamServerN.MajorGroupUnsubscribeMsgT.c_len) == Protocol.ParamServerN.MajorGroupUnsubscribeMsgT.c_len;
        }
        public unsafe bool publishParam(Protocol.ParamServerN.ParamChangeMsgT msg)
        {
            uint len = msg.Length;
            byte* pos = network.EmplaceReserve(len);
            if (pos == null)
            {
                Logger.Log(Logger.Level.error, "ParamClient Failed to write Param!!");
                return false;
            }
            byte* buf = pos;
            if (!msg.copy_into(buf, network.Tx.Unusedspace))
                return false;
            bool flag = network.EmplaceCommit(len) == len;
            Logger.Log(Logger.Level.info, $"sent Param Definition Which: {msg.get_param_change_t(0).ParamEnum} for {msg.get_param_change_t(0).PrimaryInstrumentId}");
            return flag;
        }
        public static string Hexify(byte[] ba, uint offset, uint len)
        {
            StringBuilder hex = new StringBuilder((int)len * 3 + ((int)len / 8));
            uint j = 0;
            for (int i = 0; i < (int)len; ++i)
            {
                byte b = ba[i + offset];
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
        public override void onConnect(ulong ts)
        {
            handler.onParamServerConnect();
        }
    }
}
