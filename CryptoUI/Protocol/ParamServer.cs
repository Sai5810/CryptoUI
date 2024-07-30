using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CryptoUI.Protocol
{
    namespace ParamServerN
    {
        public enum MsgTypeE : byte
        {
            invalid = 0x00,
            param_change_msg = 0x01,
            heartbeat_msg = 0x02,
            major_group_subscribe_msg = 0x03,
            major_group_subscribe_ack_msg = 0x04,
            major_group_unsubscribe_msg = 0x05,
            lock_for_snapshot_msg = 0x06,
            unlock_for_snapshot_msg = 0x07,
            subscribe_all_msg = 0x08,
            unsubscribe_all_msg = 0x09,
            new_major_group_defined_notification_msg = 0x10,
            request_list_all_major_group_ids_msg = 0x11,
            major_group_id_response_msg = 0x12,
            param_change_ack_msg = 0x13
        }
        public enum LevelE : byte
        {
            invalid = 0x00,
            global = 0x01,
            major_instrument_group = 0x02,
            minor_instrument_group = 0x03,
            instrument = 0x04
        };
        public enum ParamFlagE : byte
        {
            invalid = 0x00,
            no_flags = 0x01,
            is_remove = 0x02,
            modify = 0x03,
            insert = 0x04
        };

        public enum ParamTypeE : byte
        {
            invalid = 0x00,
            boolean = 0x01,
            uint8_e = 0x02,
            uint16_e = 0x03,
            uint32_e = 0x04,
            uint64_e = 0x05,
            int8_e = 0x06,
            int16_e = 0x07,
            int32_e = 0x08,
            int64_e = 0x09,
            char_e = 0x0A,
            float_e = 0x0B,
            double_e = 0x0C,
            time_series_date_double_element = 0x0D,
            time_series_datetime_double_element = 0x0E,
            time_series_date_uint64_element = 0x0F,
            time_series_datetime_uint64_element = 0x10,
            time_series_date_int64_element = 0x11,
            time_series_datetime_int64_element = 0x12
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct BoolParamT
        {
            public const ushort c_len = 2;

            public ParamTypeE param_type;
            [MarshalAs(UnmanagedType.I1)]
            public bool value;

            public static unsafe BoolParamT* Emplace(byte* buf)
            {
                BoolParamT tmp = new BoolParamT();
                var mem = (BoolParamT*)buf;
                *mem = tmp;
                mem->param_type = ParamTypeE.boolean;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Uint8ParamT
        {
            public const ushort c_len = 2;

            public ParamTypeE param_type;
            public byte value;

            public static unsafe Uint8ParamT* Emplace(byte* buf)
            {
                Uint8ParamT tmp = new Uint8ParamT();
                var mem = (Uint8ParamT*)buf;
                *mem = tmp;
                mem->param_type = ParamTypeE.uint8_e;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Uint16ParamT
        {
            public const ushort c_len = 3;

            public ParamTypeE param_type;
            public ushort value;

            public static unsafe Uint16ParamT* Emplace(byte* buf)
            {
                Uint16ParamT tmp = new Uint16ParamT();
                var mem = (Uint16ParamT*)buf;
                *mem = tmp;
                mem->param_type = ParamTypeE.uint16_e;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Uint32ParamT
        {
            public const ushort c_len = 5;

            public ParamTypeE param_type;
            public uint value;

            public static unsafe Uint32ParamT* Emplace(byte* buf)
            {
                Uint32ParamT tmp = new Uint32ParamT();
                var mem = (Uint32ParamT*)buf;
                *mem = tmp;
                mem->param_type = ParamTypeE.uint32_e;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Uint64ParamT
        {
            public const ushort c_len = 9;

            public ParamTypeE param_type;
            public ulong value;

            public static unsafe Uint64ParamT* Emplace(byte* buf)
            {
                Uint64ParamT tmp = new Uint64ParamT();
                var mem = (Uint64ParamT*)buf;
                *mem = tmp;
                mem->param_type = ParamTypeE.uint64_e;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Int8ParamT
        {
            public const ushort c_len = 2;

            public ParamTypeE param_type;
            public sbyte value;

            public static unsafe Int8ParamT* Emplace(byte* buf)
            {
                Int8ParamT tmp = new Int8ParamT();
                var mem = (Int8ParamT*)buf;
                *mem = tmp;
                mem->param_type = ParamTypeE.int8_e;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Int16ParamT
        {
            public const ushort c_len = 3;

            public ParamTypeE param_type;
            public short value;

            public static unsafe Int16ParamT* Emplace(byte* buf)
            {
                Int16ParamT tmp = new Int16ParamT();
                var mem = (Int16ParamT*)buf;
                *mem = tmp;
                mem->param_type = ParamTypeE.int16_e;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Int32ParamT
        {
            public const ushort c_len = 5;

            public ParamTypeE param_type;
            public int value;

            public static unsafe Int32ParamT* Emplace(byte* buf)
            {
                Int32ParamT tmp = new Int32ParamT();
                var mem = (Int32ParamT*)buf;
                *mem = tmp;
                mem->param_type = ParamTypeE.int32_e;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Int64ParamT
        {
            public const ushort c_len = 9;

            public ParamTypeE param_type;
            public long value;

            public static unsafe Int64ParamT* Emplace(byte* buf)
            {
                Int64ParamT tmp = new Int64ParamT();
                var mem = (Int64ParamT*)buf;
                *mem = tmp;
                mem->param_type = ParamTypeE.int64_e;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct CharParamT
        {
            public const ushort c_len = 2;

            public ParamTypeE param_type;
            public char value;

            public static unsafe CharParamT* Emplace(byte* buf)
            {
                CharParamT tmp = new CharParamT();
                var mem = (CharParamT*)buf;
                *mem = tmp;
                mem->param_type = ParamTypeE.char_e;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FloatParamT
        {
            public const ushort c_len = 5;

            public ParamTypeE param_type;
            public float value;

            public static unsafe FloatParamT* Emplace(byte* buf)
            {
                FloatParamT tmp = new FloatParamT();
                var mem = (FloatParamT*)buf;
                *mem = tmp;
                mem->param_type = ParamTypeE.float_e;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DoubleParamT
        {
            public const ushort c_len = 9;

            public ParamTypeE param_type;
            public double value;

            public static unsafe DoubleParamT* Emplace(byte* buf)
            {
                DoubleParamT tmp = new DoubleParamT();
                var mem = (DoubleParamT*)buf;
                *mem = tmp;
                mem->param_type = ParamTypeE.double_e;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct TimeSeriesDateDoubleParamT
        {
            public const ushort c_len = 13;

            public ParamTypeE param_type;
            public uint date;
            public double value;

            public System.DateTime Date
            {
                get
                {
                    return new System.DateTime((int)(date / 10000), (int)((date % 10000) / 100), (int)(date % 100));
                }
            }

            public static unsafe TimeSeriesDateDoubleParamT* Emplace(byte* buf)
            {
                TimeSeriesDateDoubleParamT tmp = new TimeSeriesDateDoubleParamT();
                var mem = (TimeSeriesDateDoubleParamT*)buf;
                *mem = tmp;
                mem->param_type = ParamTypeE.time_series_date_double_element;
                return mem;
            }

            public override string ToString()
            {
                return $"{date}:{value}";
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct TimeSeriesDateTimeDoubleParamT
        {
            public const ushort c_len = 17;

            public ParamTypeE param_type;
            public ulong datetime;
            public double value;

            public System.DateTime DateTime
            {
                get
                {
                    return new System.DateTime((long)(((datetime / 100UL) + 621355968000000000UL)), System.DateTimeKind.Utc);
                }
            }

            public System.DateTime Date
            {
                get
                {
                    return DateTime.Date;
                }
            }

            public static unsafe TimeSeriesDateTimeDoubleParamT* Emplace(byte* buf)
            {
                TimeSeriesDateTimeDoubleParamT tmp = new TimeSeriesDateTimeDoubleParamT();
                var mem = (TimeSeriesDateTimeDoubleParamT*)buf;
                *mem = tmp;
                mem->param_type = ParamTypeE.time_series_datetime_double_element;
                return mem;
            }
            public override string ToString()
            {
                return $"{datetime}:{value}";
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct TimeSeriesDateUint64ParamT
        {
            public const ushort c_len = 13;

            public ParamTypeE param_type;
            public uint date;
            public ulong value;

            public System.DateTime Date
            {
                get
                {
                    return new System.DateTime((int)(date / 10000), (int)((date % 10000) / 100), (int)(date % 100));
                }
            }

            public static unsafe TimeSeriesDateUint64ParamT* Emplace(byte* buf)
            {
                TimeSeriesDateUint64ParamT tmp = new TimeSeriesDateUint64ParamT();
                var mem = (TimeSeriesDateUint64ParamT*)buf;
                *mem = tmp;
                mem->param_type = ParamTypeE.time_series_date_uint64_element;
                return mem;
            }

            public override string ToString()
            {
                return $"{date}:{value}";
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct TimeSeriesDateTimeUint64ParamT
        {
            public const ushort c_len = 17;

            public ParamTypeE param_type;
            public ulong datetime;
            public ulong value;

            public System.DateTime DateTime
            {
                get
                {
                    return new System.DateTime((long)(((datetime / 100UL) + 621355968000000000UL)), System.DateTimeKind.Utc);
                }
            }

            public System.DateTime Date
            {
                get
                {
                    return DateTime.Date;
                }
            }

            public static unsafe TimeSeriesDateTimeUint64ParamT* Emplace(byte* buf)
            {
                TimeSeriesDateTimeUint64ParamT tmp = new TimeSeriesDateTimeUint64ParamT();
                var mem = (TimeSeriesDateTimeUint64ParamT*)buf;
                *mem = tmp;
                mem->param_type = ParamTypeE.time_series_datetime_uint64_element;
                return mem;
            }

            public override string ToString()
            {
                return $"{datetime}:{value}";
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct TimeSeriesDateInt64ParamT
        {
            public const ushort c_len = 13;

            public ParamTypeE param_type;
            public uint date;
            public long value;

            public System.DateTime Date
            {
                get
                {
                    return new System.DateTime((int)(date / 10000), (int)((date % 10000) / 100), (int)(date % 100));
                }
            }

            public static unsafe TimeSeriesDateInt64ParamT* Emplace(byte* buf)
            {
                TimeSeriesDateInt64ParamT tmp = new TimeSeriesDateInt64ParamT();
                var mem = (TimeSeriesDateInt64ParamT*)buf;
                *mem = tmp;
                mem->param_type = ParamTypeE.time_series_date_int64_element;
                return mem;
            }

            public override string ToString()
            {
                return $"{date}:{value}";
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct TimeSeriesDateTimeInt64ParamT
        {
            public const ushort c_len = 17;

            public ParamTypeE param_type;
            public ulong datetime;
            public long value;

            public System.DateTime DateTime
            {
                get
                {
                    return new System.DateTime((long)(((datetime / 100UL) + 621355968000000000UL)), System.DateTimeKind.Utc);
                }
            }

            public System.DateTime Date
            {
                get
                {
                    return DateTime.Date;
                }
            }

            public static unsafe TimeSeriesDateTimeInt64ParamT* Emplace(byte* buf)
            {
                TimeSeriesDateTimeInt64ParamT tmp = new TimeSeriesDateTimeInt64ParamT();
                var mem = (TimeSeriesDateTimeInt64ParamT*)buf;
                *mem = tmp;
                mem->param_type = ParamTypeE.time_series_datetime_int64_element;
                return mem;
            }

            public override string ToString()
            {
                return $"{datetime}:{value}";
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ParamChangeInnerT
        {
            public const ushort c_len = 27;

            public uint sequence;
            public LevelE level;
            public ParamFlagE flag;
            public ulong primary_instrument_id;
            public ulong secondary_instrument_id;
            public ParamTypeE param_type;
            public ushort param_enum;
            public ushort param_idx;

            public bool is_removal => flag == ParamFlagE.is_remove;

            public static unsafe ParamChangeInnerT* Emplace(byte* buf)
            {
                ParamChangeInnerT tmp = new ParamChangeInnerT();
                var mem = (ParamChangeInnerT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ParamChangeMsgInnerT
        {
            public const ushort c_len = 4;
            public const MsgTypeE c_msg_type = MsgTypeE.param_change_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public byte num_changes;

            public static unsafe ParamChangeMsgInnerT* Emplace(byte* buf)
            {
                ParamChangeMsgInnerT tmp = new ParamChangeMsgInnerT();
                var mem = (ParamChangeMsgInnerT*)buf;
                *mem = tmp;
                mem->len = c_len;
                mem->msg_type = c_msg_type;
                return mem;
            }
        }
        public unsafe class ParamChangeT
        {
            private ParamChangeInnerT* inner = null;
            private PtrVectorT bool_params = new PtrVectorT(); // BoolParamT
            private PtrVectorT uint8_params = new PtrVectorT(); // Uint8ParamT
            private PtrVectorT uint16_params = new PtrVectorT(); // Uint16ParamT
            private PtrVectorT uint32_params = new PtrVectorT(); // Uint32ParamT
            private PtrVectorT uint64_params = new PtrVectorT(); // Uint64ParamT
            private PtrVectorT int8_params = new PtrVectorT(); // Int8ParamT
            private PtrVectorT int16_params = new PtrVectorT(); // Int16ParamT
            private PtrVectorT int32_params = new PtrVectorT(); // Int32ParamT
            private PtrVectorT int64_params = new PtrVectorT(); // Int64ParamT
            private PtrVectorT char_params = new PtrVectorT(); // CharParamT
            private PtrVectorT float_params = new PtrVectorT(); // FloatParamT
            private PtrVectorT double_params = new PtrVectorT(); // DoubleParamT
            private PtrVectorT time_series_date_double_params = new PtrVectorT(); // TimeSeriesDateDoubleParamT
            private PtrVectorT time_series_datetime_double_params = new PtrVectorT(); // TimeSeriesDateTimeDoubleParamT
            private PtrVectorT time_series_date_uint64_params = new PtrVectorT(); // TimeSeriesDateUint64ParamT
            private PtrVectorT time_series_datetime_uint64_params = new PtrVectorT(); // TimeSeriesDateTimeUint64ParamT
            private PtrVectorT time_series_date_int64_params = new PtrVectorT(); // TimeSeriesDateInt64ParamT
            private PtrVectorT time_series_datetime_int64_params = new PtrVectorT(); // TimeSeriesDateTimeInt64ParamT
            private byte* layer_buf_ptr = null;
            private ushort* len_ptr = null;
            public uint Sequence
            {
                get
                {
                    if (inner != null)
                        return inner->sequence;
                    return 0;
                }
                set
                {
                    if (inner != null)
                        inner->sequence = value;
                }
            }
            public LevelE Level
            {
                get
                {
                    if (inner != null)
                        return inner->level;
                    return LevelE.invalid;
                }
                set
                {
                    if (inner != null)
                        inner->level = value;
                }
            }
            public bool IsRemoval
            {
                get
                {
                    if (inner != null)
                        return inner->is_removal;
                    return false;
                }
                set
                {
                    if (inner != null && value)
                        inner->flag = ParamFlagE.is_remove;
                }
            }
            public ParamFlagE Flag
            {
                get
                {
                    if (inner != null)
                        return inner->flag;
                    return ParamFlagE.invalid;
                }
                set
                {
                    if (inner != null)
                        inner->flag = value;
                }
            }
            public ulong PrimaryInstrumentId
            {
                get
                {
                    if (inner != null)
                        return inner->primary_instrument_id;
                    return 0;
                }
                set
                {
                    if (inner != null)
                        inner->primary_instrument_id = value;
                }
            }
            public ulong SecondaryInstrumentId
            {
                get
                {
                    if (inner != null)
                        return inner->secondary_instrument_id;
                    return 0;
                }
                set
                {
                    if (inner != null)
                        inner->secondary_instrument_id = value;
                }
            }
            public ushort ParamEnum
            {
                get
                {
                    if (inner != null)
                        return inner->param_enum;
                    return 0; // 0 is reserved for invalid
                }
                set
                {
                    if (inner != null)
                        inner->param_enum = value;
                }
            }
            public ParamTypeE ParamType
            {
                get
                {
                    if (inner != null)
                        return inner->param_type;
                    return ParamTypeE.invalid;
                }
                set
                {
                    if (inner != null)
                        inner->param_type = value;
                }
            }
            public ushort ParamIdx
            {
                get
                {
                    if (inner != null)
                        return inner->param_idx;
                    return 0;
                }
                set
                {
                    if (inner != null)
                        inner->param_idx = value;
                }
            }
            public static ushort size_from_param_type(ParamTypeE e)
            {
                switch (e)
                {
                    case ParamTypeE.boolean:
                        return BoolParamT.c_len;
                    case ParamTypeE.uint8_e:
                        return Uint8ParamT.c_len;
                    case ParamTypeE.uint16_e:
                        return Uint16ParamT.c_len;
                    case ParamTypeE.uint32_e:
                        return Uint32ParamT.c_len;
                    case ParamTypeE.uint64_e:
                        return Uint64ParamT.c_len;
                    case ParamTypeE.int8_e:
                        return Int8ParamT.c_len;
                    case ParamTypeE.int16_e:
                        return Int16ParamT.c_len;
                    case ParamTypeE.int32_e:
                        return Int32ParamT.c_len;
                    case ParamTypeE.int64_e:
                        return Int64ParamT.c_len;
                    case ParamTypeE.char_e:
                        return CharParamT.c_len;
                    case ParamTypeE.float_e:
                        return FloatParamT.c_len;
                    case ParamTypeE.double_e:
                        return DoubleParamT.c_len;
                    case ParamTypeE.time_series_date_double_element:
                        return TimeSeriesDateDoubleParamT.c_len;
                    case ParamTypeE.time_series_datetime_double_element:
                        return TimeSeriesDateTimeDoubleParamT.c_len;
                    case ParamTypeE.time_series_date_uint64_element:
                        return TimeSeriesDateUint64ParamT.c_len;
                    case ParamTypeE.time_series_datetime_uint64_element:
                        return TimeSeriesDateTimeUint64ParamT.c_len;
                    case ParamTypeE.time_series_date_int64_element:
                        return TimeSeriesDateInt64ParamT.c_len;
                    case ParamTypeE.time_series_datetime_int64_element:
                        return TimeSeriesDateTimeInt64ParamT.c_len;
                    case ParamTypeE.invalid:
                    default:
                        break;
                }
                return 0;
            }

            public byte len()
            {
                ushort l = ParamChangeInnerT.c_len;
                if (!IsRemoval)
                    l += size_from_param_type(ParamType);
                return (byte)l;
            }
            public void _set_len_ptr(ushort* ptr)
            {
                len_ptr = ptr;
            }
            public static byte max_len()
            {
                return (byte)(ParamChangeInnerT.c_len + size_from_param_type(ParamTypeE.time_series_datetime_uint64_element));
            }
            public static byte min_len()
            {
                return (byte)(ParamChangeInnerT.c_len + size_from_param_type(ParamTypeE.boolean));
            }
            public void parse(byte* buf)
            {
                inner = (ParamChangeInnerT*)buf;
                buf += ParamChangeInnerT.c_len;
                if (inner->is_removal)
                    return;
                for (byte i = 0; i < 1; ++i)
                {
                    ParamTypeE* hdr = (ParamTypeE*)buf;
                    layer_buf_ptr = buf;
                    switch (*hdr)
                    {
                        case ParamTypeE.boolean:
                            {
                                bool_params.Add(buf);
                                buf += BoolParamT.c_len;
                            }
                            break;
                        case ParamTypeE.uint8_e:
                            {
                                uint8_params.Add(buf);
                                buf += Uint8ParamT.c_len;
                            }
                            break;
                        case ParamTypeE.uint16_e:
                            {
                                uint16_params.Add(buf);
                                buf += Uint16ParamT.c_len;
                            }
                            break;
                        case ParamTypeE.uint32_e:
                            {
                                uint32_params.Add(buf);
                                buf += Uint32ParamT.c_len;
                            }
                            break;
                        case ParamTypeE.uint64_e:
                            {
                                uint64_params.Add(buf);
                                buf += Uint64ParamT.c_len;
                            }
                            break;
                        case ParamTypeE.int8_e:
                            {
                                int8_params.Add(buf);
                                buf += Int8ParamT.c_len;
                            }
                            break;
                        case ParamTypeE.int16_e:
                            {
                                int16_params.Add(buf);
                                buf += Int16ParamT.c_len;
                            }
                            break;
                        case ParamTypeE.int32_e:
                            {
                                int32_params.Add(buf);
                                buf += Int32ParamT.c_len;
                            }
                            break;
                        case ParamTypeE.int64_e:
                            {
                                int64_params.Add(buf);
                                buf += Int64ParamT.c_len;
                            }
                            break;
                        case ParamTypeE.char_e:
                            {
                                char_params.Add(buf);
                                buf += CharParamT.c_len;
                            }
                            break;
                        case ParamTypeE.float_e:
                            {
                                float_params.Add(buf);
                                buf += FloatParamT.c_len;
                            }
                            break;
                        case ParamTypeE.double_e:
                            {
                                double_params.Add(buf);
                                buf += DoubleParamT.c_len;
                            }
                            break;
                        case ParamTypeE.time_series_date_double_element:
                            {
                                time_series_date_double_params.Add(buf);
                                buf += TimeSeriesDateDoubleParamT.c_len;
                            }
                            break;
                        case ParamTypeE.time_series_datetime_double_element:
                            {
                                time_series_datetime_double_params.Add(buf);
                                buf += TimeSeriesDateTimeDoubleParamT.c_len;
                            }
                            break;
                        case ParamTypeE.time_series_date_uint64_element:
                            {
                                time_series_date_uint64_params.Add(buf);
                                buf += TimeSeriesDateUint64ParamT.c_len;
                            }
                            break;
                        case ParamTypeE.time_series_datetime_uint64_element:
                            {
                                time_series_datetime_uint64_params.Add(buf);
                                buf += TimeSeriesDateTimeUint64ParamT.c_len;
                            }
                            break;
                        case ParamTypeE.time_series_date_int64_element:
                            {
                                time_series_date_int64_params.Add(buf);
                                buf += TimeSeriesDateInt64ParamT.c_len;
                            }
                            break;
                        case ParamTypeE.time_series_datetime_int64_element:
                            {
                                time_series_datetime_int64_params.Add(buf);
                                buf += TimeSeriesDateTimeInt64ParamT.c_len;
                            }
                            break;
                        case ParamTypeE.invalid:
                        default:
                            break;
                    }
                }
            }
            public bool parse(byte* buf, uint bufsz)
            {
                if (bufsz < ParamChangeInnerT.c_len)
                    return false;
                inner = (ParamChangeInnerT*)buf;
                buf += ParamChangeInnerT.c_len;
                byte* cur_buf = buf;
                if (inner->is_removal)
                    return true;
                for (byte i = 0; i < 1; ++i)
                {
                    if (cur_buf - buf + 1 > bufsz)
                        return false;
                    ParamTypeE* hdr = (ParamTypeE*)buf;
                    if (cur_buf - buf + size_from_param_type(*hdr) > bufsz)
                        return false;
                    layer_buf_ptr = buf;
                    bool_params.SetBasePtr(buf);
                    uint8_params.SetBasePtr(buf);
                    uint16_params.SetBasePtr(buf);
                    uint32_params.SetBasePtr(buf);
                    uint64_params.SetBasePtr(buf);
                    int16_params.SetBasePtr(buf);
                    int32_params.SetBasePtr(buf);
                    int64_params.SetBasePtr(buf);
                    char_params.SetBasePtr(buf);
                    float_params.SetBasePtr(buf);
                    double_params.SetBasePtr(buf);
                    time_series_date_double_params.SetBasePtr(buf);
                    time_series_datetime_double_params.SetBasePtr(buf);
                    time_series_date_uint64_params.SetBasePtr(buf);
                    time_series_datetime_uint64_params.SetBasePtr(buf);
                    time_series_date_int64_params.SetBasePtr(buf);
                    time_series_datetime_int64_params.SetBasePtr(buf);
                    switch (*hdr)
                    {
                        case ParamTypeE.boolean:
                            {
                                bool_params.Add(buf);
                                buf += BoolParamT.c_len;
                            }
                            break;
                        case ParamTypeE.uint8_e:
                            {
                                uint8_params.Add(buf);
                                buf += Uint8ParamT.c_len;
                            }
                            break;
                        case ParamTypeE.uint16_e:
                            {
                                uint16_params.Add(buf);
                                buf += Uint16ParamT.c_len;
                            }
                            break;
                        case ParamTypeE.uint32_e:
                            {
                                uint32_params.Add(buf);
                                buf += Uint32ParamT.c_len;
                            }
                            break;
                        case ParamTypeE.uint64_e:
                            {
                                uint64_params.Add(buf);
                                buf += Uint64ParamT.c_len;
                            }
                            break;
                        case ParamTypeE.int8_e:
                            {
                                int8_params.Add(buf);
                                buf += Int8ParamT.c_len;
                            }
                            break;
                        case ParamTypeE.int16_e:
                            {
                                int16_params.Add(buf);
                                buf += Int16ParamT.c_len;
                            }
                            break;
                        case ParamTypeE.int32_e:
                            {
                                int32_params.Add(buf);
                                buf += Int32ParamT.c_len;
                            }
                            break;
                        case ParamTypeE.int64_e:
                            {
                                int64_params.Add(buf);
                                buf += Int64ParamT.c_len;
                            }
                            break;
                        case ParamTypeE.char_e:
                            {
                                char_params.Add(buf);
                                buf += CharParamT.c_len;
                            }
                            break;
                        case ParamTypeE.float_e:
                            {
                                float_params.Add(buf);
                                buf += FloatParamT.c_len;
                            }
                            break;
                        case ParamTypeE.double_e:
                            {
                                double_params.Add(buf);
                                buf += DoubleParamT.c_len;
                            }
                            break;
                        case ParamTypeE.time_series_date_double_element:
                            {
                                time_series_date_double_params.Add(buf);
                                buf += TimeSeriesDateDoubleParamT.c_len;
                            }
                            break;
                        case ParamTypeE.time_series_datetime_double_element:
                            {
                                time_series_datetime_double_params.Add(buf);
                                buf += TimeSeriesDateTimeDoubleParamT.c_len;
                            }
                            break;
                        case ParamTypeE.time_series_date_uint64_element:
                            {
                                time_series_date_uint64_params.Add(buf);
                                buf += TimeSeriesDateUint64ParamT.c_len;
                            }
                            break;
                        case ParamTypeE.time_series_datetime_uint64_element:
                            {
                                time_series_datetime_uint64_params.Add(buf);
                                buf += TimeSeriesDateTimeUint64ParamT.c_len;
                            }
                            break;
                        case ParamTypeE.time_series_date_int64_element:
                            {
                                time_series_date_int64_params.Add(buf);
                                buf += TimeSeriesDateInt64ParamT.c_len;
                            }
                            break;
                        case ParamTypeE.time_series_datetime_int64_element:
                            {
                                time_series_datetime_int64_params.Add(buf);
                                buf += TimeSeriesDateTimeInt64ParamT.c_len;
                            }
                            break;
                        case ParamTypeE.invalid:
                        default:
                            return false;
                    }
                }
                return true;
            }
            public void construct(byte* buf)
            {
                inner = (ParamChangeInnerT*)buf;
                layer_buf_ptr = buf + ParamChangeInnerT.c_len;
                *len_ptr += ParamChangeInnerT.c_len;
            }
            public bool construct(byte* buf, uint bufsz)
            {
                if (bufsz < ParamChangeInnerT.c_len)
                    return false;
                inner = (ParamChangeInnerT*)buf;
                layer_buf_ptr = buf + ParamChangeInnerT.c_len;
                *len_ptr += ParamChangeInnerT.c_len;
                return true;
            }
            public BoolParamT* get_bool_param_t(byte idx)
            {
                if (idx > bool_params.Length)
                    return null;
                return (BoolParamT*)bool_params[idx];
            }
            public ushort get_bool_param_t_count()
            {
                return bool_params.Length;
            }
            public Uint8ParamT* get_uint8_param_t(byte idx)
            {
                if (idx > uint8_params.Length)
                    return null;
                return (Uint8ParamT*)uint8_params[idx];
            }
            public ushort get_uint8_param_t_count()
            {
                return uint8_params.Length;
            }
            public Uint16ParamT* get_uint16_param_t(byte idx)
            {
                if (idx > uint16_params.Length)
                    return null;
                return (Uint16ParamT*)uint16_params[idx];
            }
            public ushort get_uint16_param_t_count()
            {
                return uint16_params.Length;
            }
            public Uint32ParamT* get_uint32_param_t(byte idx)
            {
                if (idx > uint32_params.Length)
                    return null;
                return (Uint32ParamT*)uint32_params[idx];
            }
            public ushort get_uint32_param_t_count()
            {
                return uint32_params.Length;
            }
            public Uint64ParamT* get_uint64_param_t(byte idx)
            {
                if (idx > uint64_params.Length)
                    return null;
                return (Uint64ParamT*)uint64_params[idx];
            }
            public ushort get_uint64_param_t_count()
            {
                return uint64_params.Length;
            }
            public Int8ParamT* get_int8_param_t(byte idx)
            {
                if (idx > int8_params.Length)
                    return null;
                return (Int8ParamT*)int8_params[idx];
            }
            public ushort get_int8_param_t_count()
            {
                return int8_params.Length;
            }
            public Int16ParamT* get_int16_param_t(byte idx)
            {
                if (idx > int16_params.Length)
                    return null;
                return (Int16ParamT*)int16_params[idx];
            }
            public ushort get_int16_param_t_count()
            {
                return int16_params.Length;
            }
            public Int32ParamT* get_int32_param_t(byte idx)
            {
                if (idx > int32_params.Length)
                    return null;
                return (Int32ParamT*)int32_params[idx];
            }
            public ushort get_int32_param_t_count()
            {
                return int32_params.Length;
            }
            public Int64ParamT* get_int64_param_t(byte idx)
            {
                if (idx > int64_params.Length)
                    return null;
                return (Int64ParamT*)int64_params[idx];
            }
            public ushort get_int64_param_t_count()
            {
                return int64_params.Length;
            }
            public CharParamT* get_char_param_t(byte idx)
            {
                if (idx > char_params.Length)
                    return null;
                return (CharParamT*)char_params[idx];
            }
            public ushort get_char_param_t_count()
            {
                return char_params.Length;
            }
            public FloatParamT* get_float_param_t(byte idx)
            {
                if (idx > float_params.Length)
                    return null;
                return (FloatParamT*)float_params[idx];
            }
            public ushort get_float_param_t_count()
            {
                return float_params.Length;
            }
            public DoubleParamT* get_double_param_t(byte idx)
            {
                if (idx > double_params.Length)
                    return null;
                return (DoubleParamT*)double_params[idx];
            }
            public ushort get_double_param_t_count()
            {
                return double_params.Length;
            }
            public TimeSeriesDateDoubleParamT* get_time_series_date_double_param_t(byte idx)
            {
                if (idx > time_series_date_double_params.Length)
                    return null;
                return (TimeSeriesDateDoubleParamT*)time_series_date_double_params[idx];
            }
            public ushort get_time_series_date_double_param_t_count()
            {
                return time_series_date_double_params.Length;
            }
            public TimeSeriesDateTimeDoubleParamT* get_time_series_datetime_double_param_t(byte idx)
            {
                if (idx > time_series_datetime_double_params.Length)
                    return null;
                return (TimeSeriesDateTimeDoubleParamT*)time_series_datetime_double_params[idx];
            }
            public ushort get_time_series_datetime_double_param_t_count()
            {
                return time_series_datetime_double_params.Length;
            }
            public TimeSeriesDateUint64ParamT* get_time_series_date_uint64_param_t(byte idx)
            {
                if (idx > time_series_date_uint64_params.Length)
                    return null;
                return (TimeSeriesDateUint64ParamT*)time_series_date_uint64_params[idx];
            }
            public ushort get_time_series_date_uint64_param_t_count()
            {
                return time_series_date_uint64_params.Length;
            }
            public TimeSeriesDateTimeUint64ParamT* get_time_series_datetime_uint64_param_t(byte idx)
            {
                if (idx > time_series_datetime_uint64_params.Length)
                    return null;
                return (TimeSeriesDateTimeUint64ParamT*)time_series_datetime_uint64_params[idx];
            }
            public ushort get_time_series_datetime_uint64_param_t_count()
            {
                return time_series_datetime_uint64_params.Length;
            }
            public TimeSeriesDateInt64ParamT* get_time_series_date_int64_param_t(byte idx)
            {
                if (idx > time_series_date_int64_params.Length)
                    return null;
                return (TimeSeriesDateInt64ParamT*)time_series_date_int64_params[idx];
            }
            public ushort get_time_series_date_int64_param_t_count()
            {
                return time_series_date_int64_params.Length;
            }
            public TimeSeriesDateTimeInt64ParamT* get_time_series_datetime_int64_param_t(byte idx)
            {
                if (idx > time_series_datetime_int64_params.Length)
                    return null;
                return (TimeSeriesDateTimeInt64ParamT*)time_series_datetime_int64_params[idx];
            }
            public ushort get_time_series_datetime_int64_param_t_count()
            {
                return time_series_datetime_int64_params.Length;
            }
            public BoolParamT* add_bool_param_t()
            {
                BoolParamT* ptr = BoolParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += BoolParamT.c_len;
                *len_ptr += BoolParamT.c_len;
                bool_params.Add((byte*)ptr);
                return ptr;
            }
            public BoolParamT* add_bool_param_t(byte* buf, uint bufsz)
            {
                if (bufsz - (layer_buf_ptr - buf) < BoolParamT.c_len)
                    return null;
                BoolParamT* ptr = BoolParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += BoolParamT.c_len;
                *len_ptr += BoolParamT.c_len;
                bool_params.Add((byte*)ptr);
                return ptr;
            }
            public Uint8ParamT* add_uint8_param_t()
            {
                Uint8ParamT* ptr = Uint8ParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += Uint8ParamT.c_len;
                *len_ptr += Uint8ParamT.c_len;
                uint8_params.Add((byte*)ptr);
                return ptr;
            }
            public Uint8ParamT* add_uint8_param_t(byte* buf, uint bufsz)
            {
                if (bufsz - (layer_buf_ptr - buf) < Uint8ParamT.c_len)
                    return null;
                Uint8ParamT* ptr = Uint8ParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += Uint8ParamT.c_len;
                *len_ptr += Uint8ParamT.c_len;
                uint8_params.Add((byte*)ptr);
                return ptr;
            }
            public Uint16ParamT* add_uint16_param_t()
            {
                Uint16ParamT* ptr = Uint16ParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += Uint16ParamT.c_len;
                *len_ptr += Uint16ParamT.c_len;
                uint16_params.Add((byte*)ptr);
                return ptr;
            }
            public Uint16ParamT* add_uint16_param_t(byte* buf, uint bufsz)
            {
                if (bufsz - (layer_buf_ptr - buf) < Uint16ParamT.c_len)
                    return null;
                Uint16ParamT* ptr = Uint16ParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += Uint16ParamT.c_len;
                *len_ptr += Uint16ParamT.c_len;
                uint16_params.Add((byte*)ptr);
                return ptr;
            }
            public Uint32ParamT* add_uint32_param_t()
            {
                Uint32ParamT* ptr = Uint32ParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += Uint32ParamT.c_len;
                *len_ptr += Uint32ParamT.c_len;
                uint32_params.Add((byte*)ptr);
                return ptr;
            }
            public Uint32ParamT* add_uint32_param_t(byte* buf, uint bufsz)
            {
                if (bufsz - (layer_buf_ptr - buf) < Uint32ParamT.c_len)
                    return null;
                Uint32ParamT* ptr = Uint32ParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += Uint32ParamT.c_len;
                *len_ptr += Uint32ParamT.c_len;
                uint32_params.Add((byte*)ptr);
                return ptr;
            }
            public Uint64ParamT* add_uint64_param_t()
            {
                Uint64ParamT* ptr = Uint64ParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += Uint64ParamT.c_len;
                *len_ptr += Uint64ParamT.c_len;
                uint64_params.Add((byte*)ptr);
                return ptr;
            }
            public Uint64ParamT* add_uint64_param_t(byte* buf, uint bufsz)
            {
                if (bufsz - (layer_buf_ptr - buf) < Uint64ParamT.c_len)
                    return null;
                Uint64ParamT* ptr = Uint64ParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += Uint64ParamT.c_len;
                *len_ptr += Uint64ParamT.c_len;
                uint64_params.Add((byte*)ptr);
                return ptr;
            }
            public Int8ParamT* add_int8_param_t()
            {
                Int8ParamT* ptr = Int8ParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += Int8ParamT.c_len;
                *len_ptr += Int8ParamT.c_len;
                int8_params.Add((byte*)ptr);
                return ptr;
            }
            public Int8ParamT* add_int8_param_t(byte* buf, uint bufsz)
            {
                if (bufsz - (layer_buf_ptr - buf) < Int8ParamT.c_len)
                    return null;
                Int8ParamT* ptr = Int8ParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += Int8ParamT.c_len;
                *len_ptr += Int8ParamT.c_len;
                int8_params.Add((byte*)ptr);
                return ptr;
            }
            public Int16ParamT* add_int16_param_t()
            {
                Int16ParamT* ptr = Int16ParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += Int16ParamT.c_len;
                *len_ptr += Int16ParamT.c_len;
                int16_params.Add((byte*)ptr);
                return ptr;
            }
            public Int16ParamT* add_int16_param_t(byte* buf, uint bufsz)
            {
                if (bufsz - (layer_buf_ptr - buf) < Int16ParamT.c_len)
                    return null;
                Int16ParamT* ptr = Int16ParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += Int16ParamT.c_len;
                *len_ptr += Int16ParamT.c_len;
                int16_params.Add((byte*)ptr);
                return ptr;
            }
            public Int32ParamT* add_int32_param_t()
            {
                Int32ParamT* ptr = Int32ParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += Int32ParamT.c_len;
                *len_ptr += Int32ParamT.c_len;
                int32_params.Add((byte*)ptr);
                return ptr;
            }
            public Int32ParamT* add_int32_param_t(byte* buf, uint bufsz)
            {
                if (bufsz - (layer_buf_ptr - buf) < Int32ParamT.c_len)
                    return null;
                Int32ParamT* ptr = Int32ParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += Int32ParamT.c_len;
                *len_ptr += Int32ParamT.c_len;
                int32_params.Add((byte*)ptr);
                return ptr;
            }
            public Int64ParamT* add_int64_param_t()
            {
                Int64ParamT* ptr = Int64ParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += Int64ParamT.c_len;
                *len_ptr += Int64ParamT.c_len;
                int64_params.Add((byte*)ptr);
                return ptr;
            }
            public Int64ParamT* add_int64_param_t(byte* buf, uint bufsz)
            {
                if (bufsz - (layer_buf_ptr - buf) < Int64ParamT.c_len)
                    return null;
                Int64ParamT* ptr = Int64ParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += Int64ParamT.c_len;
                *len_ptr += Int64ParamT.c_len;
                int64_params.Add((byte*)ptr);
                return ptr;
            }
            public CharParamT* add_char_param_t()
            {
                CharParamT* ptr = CharParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += CharParamT.c_len;
                *len_ptr += CharParamT.c_len;
                char_params.Add((byte*)ptr);
                return ptr;
            }
            public CharParamT* add_char_param_t(byte* buf, uint bufsz)
            {
                if (bufsz - (layer_buf_ptr - buf) < CharParamT.c_len)
                    return null;
                CharParamT* ptr = CharParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += CharParamT.c_len;
                *len_ptr += CharParamT.c_len;
                char_params.Add((byte*)ptr);
                return ptr;
            }
            public FloatParamT* add_float_param_t()
            {
                FloatParamT* ptr = FloatParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += FloatParamT.c_len;
                *len_ptr += FloatParamT.c_len;
                float_params.Add((byte*)ptr);
                return ptr;
            }
            public FloatParamT* add_float_param_t(byte* buf, uint bufsz)
            {
                if (bufsz - (layer_buf_ptr - buf) < FloatParamT.c_len)
                    return null;
                FloatParamT* ptr = FloatParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += FloatParamT.c_len;
                *len_ptr += FloatParamT.c_len;
                float_params.Add((byte*)ptr);
                return ptr;
            }
            public DoubleParamT* add_double_param_t()
            {
                DoubleParamT* ptr = DoubleParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += DoubleParamT.c_len;
                *len_ptr += DoubleParamT.c_len;
                double_params.Add((byte*)ptr);
                return ptr;
            }
            public DoubleParamT* add_double_param_t(byte* buf, uint bufsz)
            {
                if (bufsz - (layer_buf_ptr - buf) < DoubleParamT.c_len)
                    return null;
                DoubleParamT* ptr = DoubleParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += DoubleParamT.c_len;
                *len_ptr += DoubleParamT.c_len;
                double_params.Add((byte*)ptr);
                return ptr;
            }
            public TimeSeriesDateDoubleParamT* add_time_series_date_double_param_t()
            {
                TimeSeriesDateDoubleParamT* ptr = TimeSeriesDateDoubleParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += TimeSeriesDateDoubleParamT.c_len;
                *len_ptr += TimeSeriesDateDoubleParamT.c_len;
                time_series_date_double_params.Add((byte*)ptr);
                return ptr;
            }
            public TimeSeriesDateDoubleParamT* add_time_series_date_double_param_t(byte* buf, uint bufsz)
            {
                if (bufsz - (layer_buf_ptr - buf) < TimeSeriesDateDoubleParamT.c_len)
                    return null;
                TimeSeriesDateDoubleParamT* ptr = TimeSeriesDateDoubleParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += TimeSeriesDateDoubleParamT.c_len;
                *len_ptr += TimeSeriesDateDoubleParamT.c_len;
                time_series_date_double_params.Add((byte*)ptr);
                return ptr;
            }
            public TimeSeriesDateTimeDoubleParamT* add_time_series_datetime_double_param_t()
            {
                TimeSeriesDateTimeDoubleParamT* ptr = TimeSeriesDateTimeDoubleParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += TimeSeriesDateTimeDoubleParamT.c_len;
                *len_ptr += TimeSeriesDateTimeDoubleParamT.c_len;
                time_series_datetime_double_params.Add((byte*)ptr);
                return ptr;
            }
            public TimeSeriesDateTimeDoubleParamT* add_time_series_datetime_double_param_t(byte* buf, uint bufsz)
            {
                if (bufsz - (layer_buf_ptr - buf) < TimeSeriesDateTimeDoubleParamT.c_len)
                    return null;
                TimeSeriesDateTimeDoubleParamT* ptr = TimeSeriesDateTimeDoubleParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += TimeSeriesDateTimeDoubleParamT.c_len;
                *len_ptr += TimeSeriesDateTimeDoubleParamT.c_len;
                time_series_datetime_double_params.Add((byte*)ptr);
                return ptr;
            }
            public TimeSeriesDateUint64ParamT* add_time_series_date_uint64_param_t()
            {
                TimeSeriesDateUint64ParamT* ptr = TimeSeriesDateUint64ParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += TimeSeriesDateUint64ParamT.c_len;
                *len_ptr += TimeSeriesDateUint64ParamT.c_len;
                time_series_date_uint64_params.Add((byte*)ptr);
                return ptr;
            }
            public TimeSeriesDateUint64ParamT* add_time_series_date_uint64_param_t(byte* buf, uint bufsz)
            {
                if (bufsz - (layer_buf_ptr - buf) < TimeSeriesDateUint64ParamT.c_len)
                    return null;
                TimeSeriesDateUint64ParamT* ptr = TimeSeriesDateUint64ParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += TimeSeriesDateUint64ParamT.c_len;
                *len_ptr += TimeSeriesDateUint64ParamT.c_len;
                time_series_date_uint64_params.Add((byte*)ptr);
                return ptr;
            }
            public TimeSeriesDateTimeUint64ParamT* add_time_series_datetime_uint64_param_t()
            {
                TimeSeriesDateTimeUint64ParamT* ptr = TimeSeriesDateTimeUint64ParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += TimeSeriesDateTimeUint64ParamT.c_len;
                *len_ptr += TimeSeriesDateTimeUint64ParamT.c_len;
                time_series_datetime_uint64_params.Add((byte*)ptr);
                return ptr;
            }
            public TimeSeriesDateTimeUint64ParamT* add_time_series_datetime_uint64_param_t(byte* buf, uint bufsz)
            {
                if (bufsz - (layer_buf_ptr - buf) < TimeSeriesDateTimeUint64ParamT.c_len)
                    return null;
                TimeSeriesDateTimeUint64ParamT* ptr = TimeSeriesDateTimeUint64ParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += TimeSeriesDateTimeUint64ParamT.c_len;
                *len_ptr += TimeSeriesDateTimeUint64ParamT.c_len;
                time_series_datetime_uint64_params.Add((byte*)ptr);
                return ptr;
            }
            public TimeSeriesDateInt64ParamT* add_time_series_date_int64_param_t()
            {
                TimeSeriesDateInt64ParamT* ptr = TimeSeriesDateInt64ParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += TimeSeriesDateInt64ParamT.c_len;
                *len_ptr += TimeSeriesDateInt64ParamT.c_len;
                time_series_date_int64_params.Add((byte*)ptr);
                return ptr;
            }
            public TimeSeriesDateInt64ParamT* add_time_series_date_int64_param_t(byte* buf, uint bufsz)
            {
                if (bufsz - (layer_buf_ptr - buf) < TimeSeriesDateInt64ParamT.c_len)
                    return null;
                TimeSeriesDateInt64ParamT* ptr = TimeSeriesDateInt64ParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += TimeSeriesDateInt64ParamT.c_len;
                *len_ptr += TimeSeriesDateInt64ParamT.c_len;
                time_series_date_int64_params.Add((byte*)ptr);
                return ptr;
            }
            public TimeSeriesDateTimeInt64ParamT* add_time_series_datetime_int64_param_t()
            {
                TimeSeriesDateTimeInt64ParamT* ptr = TimeSeriesDateTimeInt64ParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += TimeSeriesDateTimeInt64ParamT.c_len;
                *len_ptr += TimeSeriesDateTimeInt64ParamT.c_len;
                time_series_datetime_int64_params.Add((byte*)ptr);
                return ptr;
            }
            public TimeSeriesDateTimeInt64ParamT* add_time_series_datetime_int64_param_t(byte* buf, uint bufsz)
            {
                if (bufsz - (layer_buf_ptr - buf) < TimeSeriesDateTimeInt64ParamT.c_len)
                    return null;
                TimeSeriesDateTimeInt64ParamT* ptr = TimeSeriesDateTimeInt64ParamT.Emplace(layer_buf_ptr);
                layer_buf_ptr += TimeSeriesDateTimeInt64ParamT.c_len;
                *len_ptr += TimeSeriesDateTimeInt64ParamT.c_len;
                time_series_datetime_int64_params.Add((byte*)ptr);
                return ptr;
            }
        }
        public unsafe class ParamChangeMsgT
        {
            private ParamChangeMsgInnerT* inner = null;
            private List<ParamChangeT> elements = new List<ParamChangeT>();
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
            public byte NumChanges
            {
                get
                {
                    if (inner != null)
                        return inner->num_changes;
                    return 0;
                }
                set
                {
                    if (inner != null)
                        inner->num_changes = value;
                }
            }
            public ParamChangeT get_param_change_t(byte idx)
            {
                if (idx > get_param_change_t_count())
                    return null;
                return elements[idx];
            }
            public ushort get_param_change_t_count()
            {
                return (ushort)elements.Count;
            }
            public void parse(byte* buf)
            {
                inner = (ParamChangeMsgInnerT*)buf;
                buf += ParamChangeMsgInnerT.c_len;
                for (byte i = 0; i < NumChanges; ++i)
                {
                    ParamChangeT elm = new ParamChangeT();
                    elm._set_len_ptr(&inner->len);
                    elm.parse(buf);
                    elements.Add(elm);
                    buf += elm.len();
                }
            }
            public bool parse(byte* buf, uint bufsz)
            {
                if (bufsz < ParamChangeMsgInnerT.c_len)
                    return false;
                inner = (ParamChangeMsgInnerT*)buf;
                buf += ParamChangeMsgInnerT.c_len;
                if (bufsz < NumChanges * ParamChangeT.min_len())
                    return false;
                bufsz -= ParamChangeMsgInnerT.c_len;
                for (byte i = 0; i < NumChanges; ++i)
                {
                    ParamChangeT elm = new ParamChangeT();
                    elm._set_len_ptr(&inner->len);
                    if (!elm.parse(buf, bufsz))
                        return false;
                    elements.Add(elm);
                    buf += elm.len();
                    bufsz -= elm.len();
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
                inner = (ParamChangeMsgInnerT*)buf;
                inner->len = ParamChangeMsgInnerT.c_len;
                inner->msg_type = MsgTypeE.param_change_msg;
            }
            public bool construct(byte* buf, uint bufsz)
            {
                if (bufsz < ParamChangeMsgInnerT.c_len)
                    return false;
                inner = (ParamChangeMsgInnerT*)buf;
                inner->len = ParamChangeMsgInnerT.c_len;
                inner->msg_type = MsgTypeE.param_change_msg;
                return true;
            }
            public ParamChangeT add_param_change_t(byte* buf)
            {
                ushort offset = ParamChangeMsgInnerT.c_len;
                for (byte i = 0; i < NumChanges; ++i)
                    offset += elements[i].len();
                ParamChangeT pc = new ParamChangeT();
                ushort* len_ptr = &inner->len;
                pc._set_len_ptr(len_ptr);
                pc.construct(buf + offset);
                elements.Add(pc);
                inner->num_changes++;
                return pc;
            }
            public ParamChangeT add_param_change_t(byte* buf, uint bufsz)
            {
                ushort offset = ParamChangeMsgInnerT.c_len;
                for (byte i = 0; i < NumChanges; ++i)
                    offset += elements[i].len();
                if (bufsz < (offset + ParamChangeT.max_len()))
                    return null;
                ParamChangeT pc = new ParamChangeT();
                ushort* len_ptr = &inner->len;
                pc._set_len_ptr(len_ptr);
                if (!pc.construct(buf + offset, bufsz - offset))
                    return null;
                elements.Add(pc);
                inner->num_changes++;
                return pc;
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
            public uint sequence;
            public ulong ts;

            public static unsafe HeartbeatT* Emplace(byte* buf)
            {
                HeartbeatT tmp = new HeartbeatT();
                var mem = (HeartbeatT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct HeartbeatMsgT
        {
            public const ushort c_len = 15;
            public const MsgTypeE c_msg_type = MsgTypeE.heartbeat_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public HeartbeatT heartbeat;

            public static unsafe HeartbeatMsgT* Emplace(byte* buf)
            {
                HeartbeatMsgT tmp = new HeartbeatMsgT();
                var mem = (HeartbeatMsgT*)buf;
                *mem = tmp;
                mem->len = c_len;
                mem->msg_type = c_msg_type;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct LockForSnapshotT
        {
            public uint sequence;
            public ulong ts;

            public static unsafe LockForSnapshotT* Emplace(byte* buf)
            {
                LockForSnapshotT tmp = new LockForSnapshotT();
                var mem = (LockForSnapshotT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct LockForSnapshotMsgT
        {
            public const ushort c_len = 15;
            public const MsgTypeE c_msg_type = MsgTypeE.lock_for_snapshot_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public LockForSnapshotT lockelem;

            public static unsafe LockForSnapshotMsgT* Emplace(byte* buf)
            {
                LockForSnapshotMsgT tmp = new LockForSnapshotMsgT();
                var mem = (LockForSnapshotMsgT*)buf;
                *mem = tmp;
                mem->len = c_len;
                mem->msg_type = c_msg_type;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct UnlockForSnapshotT
        {
            public uint sequence;
            public ulong ts;

            public static unsafe UnlockForSnapshotT* Emplace(byte* buf)
            {
                UnlockForSnapshotT tmp = new UnlockForSnapshotT();
                var mem = (UnlockForSnapshotT*)buf;
                *mem = tmp;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct UnlockForSnapshotMsgT
        {
            public const ushort c_len = 15;
            public const MsgTypeE c_msg_type = MsgTypeE.unlock_for_snapshot_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public UnlockForSnapshotT lockelem;

            public static unsafe UnlockForSnapshotMsgT* Emplace(byte* buf)
            {
                UnlockForSnapshotMsgT tmp = new UnlockForSnapshotMsgT();
                var mem = (UnlockForSnapshotMsgT*)buf;
                *mem = tmp;
                mem->len = c_len;
                mem->msg_type = c_msg_type;
                return mem;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct MajorGroupSubscribeT
        {
            public ulong major_group_id;

            public static unsafe MajorGroupSubscribeT* Emplace(byte* buf)
            {
                MajorGroupSubscribeT tmp = new MajorGroupSubscribeT();
                var mem = (MajorGroupSubscribeT*)buf;
                *mem = tmp;
                return mem;
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct MajorGroupSubscribeMsgT
        {
            public const ushort c_len = 11;
            public const MsgTypeE c_msg_type = MsgTypeE.major_group_subscribe_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public MajorGroupSubscribeT subscription;

            public static unsafe MajorGroupSubscribeMsgT* Emplace(byte* buf)
            {
                MajorGroupSubscribeMsgT tmp = new MajorGroupSubscribeMsgT();
                var mem = (MajorGroupSubscribeMsgT*)buf;
                *mem = tmp;
                mem->len = c_len;
                mem->msg_type = c_msg_type;
                return mem;
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct MajorGroupSubscribeAckT
        {
            public ulong major_group_id;
            [MarshalAs(UnmanagedType.I1)]
            public bool success;

            public static unsafe MajorGroupSubscribeAckT* Emplace(byte* buf)
            {
                MajorGroupSubscribeAckT tmp = new MajorGroupSubscribeAckT();
                var mem = (MajorGroupSubscribeAckT*)buf;
                *mem = tmp;
                return mem;
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct MajorGroupSubscribeAckMsgT
        {
            public const ushort c_len = 12;
            public const MsgTypeE c_msg_type = MsgTypeE.major_group_subscribe_ack_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public MajorGroupSubscribeAckT subscription_ack;

            public static unsafe MajorGroupSubscribeAckMsgT* Emplace(byte* buf)
            {
                MajorGroupSubscribeAckMsgT tmp = new MajorGroupSubscribeAckMsgT();
                var mem = (MajorGroupSubscribeAckMsgT*)buf;
                *mem = tmp;
                mem->len = c_len;
                mem->msg_type = c_msg_type;
                return mem;
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct MajorGroupUnsubscribeT
        {
            public ulong major_group_id;
            public static unsafe MajorGroupUnsubscribeT* Emplace(byte* buf)
            {
                MajorGroupUnsubscribeT tmp = new MajorGroupUnsubscribeT();
                var mem = (MajorGroupUnsubscribeT*)buf;
                *mem = tmp;
                return mem;
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct MajorGroupUnsubscribeMsgT
        {
            public const ushort c_len = 11;
            public const MsgTypeE c_msg_type = MsgTypeE.major_group_unsubscribe_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public MajorGroupUnsubscribeT unsubscription;

            public static unsafe MajorGroupUnsubscribeMsgT* Emplace(byte* buf)
            {
                MajorGroupUnsubscribeMsgT tmp = new MajorGroupUnsubscribeMsgT();
                var mem = (MajorGroupUnsubscribeMsgT*)buf;
                *mem = tmp;
                mem->len = c_len;
                mem->msg_type = c_msg_type;
                return mem;
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct SubscribeAllT
        {
            public uint sequence;
            public ulong ts;
            public static unsafe SubscribeAllT* Emplace(byte* buf)
            {
                SubscribeAllT tmp = new SubscribeAllT();
                var mem = (SubscribeAllT*)buf;
                *mem = tmp;
                return mem;
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct SubscribeAllMsgT
        {
            public const ushort c_len = 15;
            public const MsgTypeE c_msg_type = MsgTypeE.subscribe_all_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public SubscribeAllT msg;

            public static unsafe SubscribeAllMsgT* Emplace(byte* buf)
            {
                SubscribeAllMsgT tmp = new SubscribeAllMsgT();
                var mem = (SubscribeAllMsgT*)buf;
                *mem = tmp;
                mem->len = c_len;
                mem->msg_type = c_msg_type;
                return mem;
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct UnsubscribeAllT
        {
            public uint sequence;
            public ulong ts;
            public static unsafe UnsubscribeAllT* Emplace(byte* buf)
            {
                UnsubscribeAllT tmp = new UnsubscribeAllT();
                var mem = (UnsubscribeAllT*)buf;
                *mem = tmp;
                return mem;
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct UnsubscribeAllMsgT
        {
            public const ushort c_len = 15;
            public const MsgTypeE c_msg_type = MsgTypeE.unsubscribe_all_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public UnsubscribeAllT msg;

            public static unsafe UnsubscribeAllMsgT* Emplace(byte* buf)
            {
                UnsubscribeAllMsgT tmp = new UnsubscribeAllMsgT();
                var mem = (UnsubscribeAllMsgT*)buf;
                *mem = tmp;
                mem->len = c_len;
                mem->msg_type = c_msg_type;
                return mem;
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct NewMajorGroupDefinedNotificationT
        {
            public uint sequence;
            public ulong ts;
            public ulong major_group_id;
            public static unsafe NewMajorGroupDefinedNotificationT* Emplace(byte* buf)
            {
                NewMajorGroupDefinedNotificationT tmp = new NewMajorGroupDefinedNotificationT();
                var mem = (NewMajorGroupDefinedNotificationT*)buf;
                *mem = tmp;
                return mem;
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct NewMajorGroupDefinedNotificationMsgT
        {
            public const ushort c_len = 23;
            public const MsgTypeE c_msg_type = MsgTypeE.new_major_group_defined_notification_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public NewMajorGroupDefinedNotificationT msg;

            public static unsafe NewMajorGroupDefinedNotificationMsgT* Emplace(byte* buf)
            {
                NewMajorGroupDefinedNotificationMsgT tmp = new NewMajorGroupDefinedNotificationMsgT();
                var mem = (NewMajorGroupDefinedNotificationMsgT*)buf;
                *mem = tmp;
                mem->len = c_len;
                mem->msg_type = c_msg_type;
                return mem;
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct RequestListAllMajorGroupIdsT
        {
            public uint sequence;
            public ulong ts;
            public ulong request_id;
            public static unsafe RequestListAllMajorGroupIdsT* Emplace(byte* buf)
            {
                RequestListAllMajorGroupIdsT tmp = new RequestListAllMajorGroupIdsT();
                var mem = (RequestListAllMajorGroupIdsT*)buf;
                *mem = tmp;
                return mem;
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct RequestListAllMajorGroupIdsMsgT
        {
            public const ushort c_len = 23;
            public const MsgTypeE c_msg_type = MsgTypeE.request_list_all_major_group_ids_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public NewMajorGroupDefinedNotificationT msg;

            public static unsafe RequestListAllMajorGroupIdsMsgT* Emplace(byte* buf)
            {
                RequestListAllMajorGroupIdsMsgT tmp = new RequestListAllMajorGroupIdsMsgT();
                var mem = (RequestListAllMajorGroupIdsMsgT*)buf;
                *mem = tmp;
                mem->len = c_len;
                mem->msg_type = c_msg_type;
                return mem;
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct MajorGroupIdResponseT
        {
            public uint sequence;
            public ulong ts;
            public ulong request_id;
            public static unsafe MajorGroupIdResponseT* Emplace(byte* buf)
            {
                MajorGroupIdResponseT tmp = new MajorGroupIdResponseT();
                var mem = (MajorGroupIdResponseT*)buf;
                *mem = tmp;
                return mem;
            }
        };
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct MajorGroupIdResponseMsgT
        {
            public const ushort c_len = 23;
            public const MsgTypeE c_msg_type = MsgTypeE.major_group_id_response_msg;

            public ushort len;
            public MsgTypeE msg_type;
            public MajorGroupIdResponseT msg;

            public static unsafe MajorGroupIdResponseMsgT* Emplace(byte* buf)
            {
                MajorGroupIdResponseMsgT tmp = new MajorGroupIdResponseMsgT();
                var mem = (MajorGroupIdResponseMsgT*)buf;
                *mem = tmp;
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