using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoUI.Services
{
    public struct NicInfo
    {
        public ulong nic_id;
        public ulong host_id;
        public string ip;
        public string mac;

        public NicInfo(ulong nic_id_, ulong host_id_, string ip_, string mac_)
        {
            nic_id = nic_id_;
            host_id = host_id_;
            ip = ip_;
            mac = mac_;
        }
    }

    public struct TcpClientConfig
    {
        public ulong id;
        public string ip;
        public ushort port;
        public ulong nic_id;

        public TcpClientConfig(ulong id_, string ip_, ushort port_, ulong nic_id_)
        {
            id = id_;
            ip = ip_;
            port = port_;
            nic_id = nic_id_;
        }
    }

    public struct ParamClientConfig
    {
        public ulong id;
        public ulong tcp_client_id;

        public ParamClientConfig(ulong id_, ulong tcp_client_id_)
        {
            id = id_;
            tcp_client_id = tcp_client_id_;
        }
    }

    public struct ManualOrderClientConfig
    {
        public ulong id;
        public ulong tcp_client_id;
        public uint starting_clordid;

        public ManualOrderClientConfig(ulong id_, ulong tcp_client_id_, uint starting_clordid_)
        {
            id = id_;
            tcp_client_id = tcp_client_id_;
            starting_clordid = starting_clordid_;
        }
    }

    public struct TcpServerConfig
    {
        public ulong id;
        public ulong instance_id;
        public ushort port;
        public ulong nic_id;
        public TcpServerConfig(
           ulong id_, ulong instance_id_,
           ushort port_, ulong nic_id_)
        {
            id = id_;
            instance_id = instance_id_;
            port = port_;
            nic_id = nic_id_;
        }
    }
    public struct ExchangeDefinitionConfig
    {
        public ulong id;
        public string exchange;
        public string family;
        public string letter_code;

        public ExchangeDefinitionConfig(ulong id_, string exchange_, string family_, string letter_code_)
        {
            id = id_;
            exchange = exchange_;
            family = family_;
            letter_code = letter_code_;
        }
    }
    public struct InstrumentIdSymbolConfig
    {
        public ulong instrument_id;
        public string symbol;

        public InstrumentIdSymbolConfig(ulong instrument_id_, string symbol_)
        {
            instrument_id = instrument_id_;
            symbol = symbol_;
        }
    }
    public struct UniqueInstrumentIdConfig
    {
        public ulong instrument_id;
        public ulong unique_instrument_id;

        public UniqueInstrumentIdConfig(ulong instrument_id_, ulong unique_instrument_id_)
        {
            instrument_id = instrument_id_;
            unique_instrument_id = unique_instrument_id_;
        }
    }

}