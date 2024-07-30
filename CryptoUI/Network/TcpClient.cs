using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCore;

namespace CryptoUI.Network
{
    abstract class ITcpClient
    {
        public abstract bool Start();
        public abstract RingBuffer Rx { get; }
        public abstract RingBuffer Tx { get; }
        public abstract string Ip { get; }
        public abstract int Port { get; }
        public abstract unsafe byte* EmplaceReserve(ulong size);
        public abstract ulong EmplaceCommit(ulong size);
    }
    abstract class INetworkHandler
    {
        public abstract void SetNetwork(ITcpClient network);
        public abstract unsafe long recv(RingBuffer rx, int nbytes, out bool shoulddisconnect);
        public abstract void onConnectionReset(ulong ts);
        public abstract bool onHeartbeat(ulong ts);
        public abstract void onConnect(ulong ts);
    }

    class TcpClient<Handler_t> : ITcpClient where Handler_t : INetworkHandler
    {
        private TradeCore.TcpClient tcpClient;
        private TradeCore.RelativeTimer timer;
        private Handler_t handler;
        private ulong lastRecv;
        private ulong connectTime;
        private DateTime lastSend;
        private bool IsConnected
        {
            get { return isConnected; }
        }
        private bool isConnected;
        private readonly ulong heartbeatNsFreq;
        private readonly ulong timeoutNs;
        private readonly TradeCore.EventManager em;

        public override RingBuffer Rx { get { return tcpClient.Rx; } }
        public override RingBuffer Tx { get { return tcpClient.Tx; } }
        public override string Ip { get { return tcpClient.Ip; } }
        public override int Port { get { return tcpClient.Port; } }
        public string BindIp { get { return tcpClient.LocalIp; } }

        public override unsafe byte* EmplaceReserve(ulong size)
        {
            return tcpClient.emplace_reserve(size);
        }

        public override ulong EmplaceCommit(ulong size)
        {
            return tcpClient.emplace_commit(size);
        }

        private void Reset()
        {
            tcpClient.reset();
        }
        public TcpClient(Handler_t handler_, TradeCore.EventManager em_, string bindIp, string ip, int port, int heartbeatSecFreq_, int timeout_)
        {
            handler = handler_;
            em = em_;
            handler.SetNetwork(this);
            lastRecv = 0;
            connectTime = 0;
            lastSend = DateTime.MinValue;
            Action<string> log_fn = (string x) => Logger.Log(Logger.Level.warning, x);
            Func<RingBuffer, ulong, BoolHolder, ulong> handlepkt_fn = (RingBuffer rb, ulong ts, BoolHolder shoulddisconnect) =>
            {
                long nread = handler.recv(rb, (int)rb.Usedspace, out bool nativeshoulddisconnect);
                shoulddisconnect.Value = nativeshoulddisconnect;
                lastRecv = ts;
                return (ulong)nread;
            };
            Action<ulong> connect_fn = (ulong ts) => {
                handler.onConnect(ts);
                isConnected = true;
                connectTime = ts;
                lastRecv = 0;
            };
            Action on_add_fn = () => {
                OnAdd();
            };
            Action on_remove_fn = () => {
                OnRemove();
            };
            Action on_timer_add_fn = () => {
                OnTimerAdd();
            };
            Action on_timer_remove_fn = () => {
                OnTimerRemove();
            };
            Action<ulong> on_timer_fn = (ulong ts) => {
                if (isConnected)
                {
                    if (lastRecv == 0)
                    {
                        if (ts - connectTime > timeoutNs)
                        {
                            ResetConnection(ts);
                            return;
                        }
                    }
                    else
                    {
                        if (ts - lastRecv > timeoutNs)
                        {
                            ResetConnection(ts);
                            return;
                        }
                    }
                    if (!handler.onHeartbeat(ts))
                    {
                        isConnected = false;
                    }
                }
                else
                {
                    ResetConnection(ts);
                }
            };
            heartbeatNsFreq = ((ulong)heartbeatSecFreq_) * 1000000000;
            timeoutNs = ((ulong)timeout_) * 1000000000;
            tcpClient = new TradeCore.TcpClient(ip, (ushort)port, bindIp, log_fn, handlepkt_fn, connect_fn, on_add_fn, on_remove_fn);
            timer = new TradeCore.RelativeTimer(on_timer_add_fn, on_timer_remove_fn, on_timer_fn, heartbeatNsFreq, 0);
            isConnected = false;
        }

        public bool ResetConnection(ulong ts)
        {
            isConnected = false;
            connectTime = 0;
            em.remove(tcpClient);
            tcpClient.close();
            handler.onConnectionReset(ts);
            tcpClient.reset();
            em.add(tcpClient);
            return tcpClient.start();
        }

        public override bool Start()
        {
            em.add(tcpClient);
            em.add(timer);
            return tcpClient.start();
        }

        private void OnAdd()
        {

        }
        private void OnRemove()
        {

        }
        private void OnTimerAdd()
        {

        }
        private void OnTimerRemove()
        {

        }
    }
}
