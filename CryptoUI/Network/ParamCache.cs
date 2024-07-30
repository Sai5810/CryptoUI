using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoUI.Network
{
    public class ParamCache
    {
        private List<param_update_cache_t> updates = new List<param_update_cache_t>();
        private ParamRouter router;
        enum param_cache_type_e
        {
            invalid = 0,
            removal = 1,
            bool_e = 2,
            char_e = 3,
            float_e = 4,
            double_e = 5,
            uint8_e = 6,
            uint16_e = 7,
            uint32_e = 8,
            uint64_e = 9,
            int8_e = 10,
            int16_e = 11,
            int32_e = 12,
            int64_e = 13,

            date_double_e = 14,
            datetime_double_e = 15,
            date_uint64_e = 16,
            datetime_uint64_e = 17,
            date_int64_e = 18,
            datetime_int64_e = 19
        }
        public struct param_removal_cache_t
        {
            public ushort which;
            public Protocol.ParamServerN.LevelE level;
            public uint seq;
            public ulong primary_instrument_id;
            public ulong secondary_instrument_id;
            public ushort param_idx;
        }
        public struct param_bool_cache_t
        {
            public ushort which;
            public Protocol.ParamServerN.LevelE level;
            public uint seq;
            public ulong primary_instrument_id;
            public ulong secondary_instrument_id;
            public ushort param_idx;
            public bool val;
        }
        public struct param_char_cache_t
        {
            public ushort which;
            public Protocol.ParamServerN.LevelE level;
            public uint seq;
            public ulong primary_instrument_id;
            public ulong secondary_instrument_id;
            public ushort param_idx;
            public char val;
        }
        public struct param_float_cache_t
        {
            public ushort which;
            public Protocol.ParamServerN.LevelE level;
            public uint seq;
            public ulong primary_instrument_id;
            public ulong secondary_instrument_id;
            public ushort param_idx;
            public float val;
        }
        public struct param_double_cache_t
        {
            public ushort which;
            public Protocol.ParamServerN.LevelE level;
            public uint seq;
            public ulong primary_instrument_id;
            public ulong secondary_instrument_id;
            public ushort param_idx;
            public double val;
        }

        public struct param_uint8_cache_t
        {
            public ushort which;
            public Protocol.ParamServerN.LevelE level;
            public uint seq;
            public ulong primary_instrument_id;
            public ulong secondary_instrument_id;
            public ushort param_idx;
            public byte val;
        }
        public struct param_uint16_cache_t
        {
            public ushort which;
            public Protocol.ParamServerN.LevelE level;
            public uint seq;
            public ulong primary_instrument_id;
            public ulong secondary_instrument_id;
            public ushort param_idx;
            public ushort val;
        }
        public struct param_uint32_cache_t
        {
            public ushort which;
            public Protocol.ParamServerN.LevelE level;
            public uint seq;
            public ulong primary_instrument_id;
            public ulong secondary_instrument_id;
            public ushort param_idx;
            public uint val;
        }
        public struct param_uint64_cache_t
        {
            public ushort which;
            public Protocol.ParamServerN.LevelE level;
            public uint seq;
            public ulong primary_instrument_id;
            public ulong secondary_instrument_id;
            public ushort param_idx;
            public ulong val;
        }
        public struct param_int8_cache_t
        {
            public ushort which;
            public Protocol.ParamServerN.LevelE level;
            public uint seq;
            public ulong primary_instrument_id;
            public ulong secondary_instrument_id;
            public ushort param_idx;
            public sbyte val;
        }
        public struct param_int16_cache_t
        {
            public ushort which;
            public Protocol.ParamServerN.LevelE level;
            public uint seq;
            public ulong primary_instrument_id;
            public ulong secondary_instrument_id;
            public ushort param_idx;
            public short val;
        }
        public struct param_int32_cache_t
        {
            public ushort which;
            public Protocol.ParamServerN.LevelE level;
            public uint seq;
            public ulong primary_instrument_id;
            public ulong secondary_instrument_id;
            public ushort param_idx;
            public int val;
        }
        public struct param_int64_cache_t
        {
            public ushort which;
            public Protocol.ParamServerN.LevelE level;
            public uint seq;
            public ulong primary_instrument_id;
            public ulong secondary_instrument_id;
            public ushort param_idx;
            public long val;
        }

        public struct param_date_double_cache_t
        {
            public ushort which;
            public Protocol.ParamServerN.LevelE level;
            public uint seq;
            public ulong primary_instrument_id;
            public ulong secondary_instrument_id;
            public ushort param_idx;
            public Protocol.ParamServerN.TimeSeriesDateDoubleParamT value;
        }

        public struct param_datetime_double_cache_t
        {
            public ushort which;
            public Protocol.ParamServerN.LevelE level;
            public uint seq;
            public ulong primary_instrument_id;
            public ulong secondary_instrument_id;
            public ushort param_idx;
            public Protocol.ParamServerN.TimeSeriesDateTimeDoubleParamT value;
        }

        public struct param_date_uint64_cache_t
        {
            public ushort which;
            public Protocol.ParamServerN.LevelE level;
            public uint seq;
            public ulong primary_instrument_id;
            public ulong secondary_instrument_id;
            public ushort param_idx;
            public Protocol.ParamServerN.TimeSeriesDateUint64ParamT value;
        }

        public struct param_datetime_uint64_cache_t
        {
            public ushort which;
            public Protocol.ParamServerN.LevelE level;
            public uint seq;
            public ulong primary_instrument_id;
            public ulong secondary_instrument_id;
            public ushort param_idx;
            public Protocol.ParamServerN.TimeSeriesDateTimeUint64ParamT value;
        }

        public struct param_date_int64_cache_t
        {
            public ushort which;
            public Protocol.ParamServerN.LevelE level;
            public uint seq;
            public ulong primary_instrument_id;
            public ulong secondary_instrument_id;
            public ushort param_idx;
            public Protocol.ParamServerN.TimeSeriesDateInt64ParamT value;
        }

        public struct param_datetime_int64_cache_t
        {
            public ushort which;
            public Protocol.ParamServerN.LevelE level;
            public uint seq;
            public ulong primary_instrument_id;
            public ulong secondary_instrument_id;
            public ushort param_idx;
            public Protocol.ParamServerN.TimeSeriesDateTimeInt64ParamT value;
        }


        class param_update_cache_t
        {
            public param_cache_type_e type;
            public param_removal_cache_t removal;
            public param_bool_cache_t bool_cache;
            public param_char_cache_t char_cache;
            public param_float_cache_t float_cache;
            public param_double_cache_t double_cache;
            public param_uint8_cache_t uint8_cache;
            public param_uint16_cache_t uint16_cache;
            public param_uint32_cache_t uint32_cache;
            public param_uint64_cache_t uint64_cache;
            public param_int8_cache_t int8_cache;
            public param_int16_cache_t int16_cache;
            public param_int32_cache_t int32_cache;
            public param_int64_cache_t int64_cache;
            public param_date_double_cache_t date_double_cache;
            public param_datetime_double_cache_t datetime_double_cache;
            public param_date_uint64_cache_t date_uint64_cache;
            public param_datetime_uint64_cache_t datetime_uint64_cache;
            public param_date_int64_cache_t date_int64_cache;
            public param_datetime_int64_cache_t datetime_int64_cache;
        }
        public ParamCache(ParamRouter router)
        {
            this.router = router;
        }
        public void onParamRemoval(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx)
        {
            param_update_cache_t elem = new param_update_cache_t();
            elem.type = param_cache_type_e.removal;
            elem.removal.which = which;
            elem.removal.level = level;
            elem.removal.seq = seq;
            elem.removal.primary_instrument_id = primary_instrument_id;
            elem.removal.secondary_instrument_id = secondary_instrument_id;
            elem.removal.param_idx = param_idx;
            updates.Add(elem);
        }
        public void on_bool_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, bool value)
        {
            param_update_cache_t elem = new param_update_cache_t();
            elem.type = param_cache_type_e.bool_e;
            elem.bool_cache.which = which;
            elem.bool_cache.level = level;
            elem.bool_cache.seq = seq;
            elem.bool_cache.primary_instrument_id = primary_instrument_id;
            elem.bool_cache.secondary_instrument_id = secondary_instrument_id;
            elem.bool_cache.param_idx = param_idx;
            elem.bool_cache.val = value;
            updates.Add(elem);
        }
        public void on_char_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, char value)
        {
            param_update_cache_t elem = new param_update_cache_t();
            elem.type = param_cache_type_e.char_e;
            elem.char_cache.which = which;
            elem.char_cache.level = level;
            elem.char_cache.seq = seq;
            elem.char_cache.primary_instrument_id = primary_instrument_id;
            elem.char_cache.secondary_instrument_id = secondary_instrument_id;
            elem.char_cache.param_idx = param_idx;
            elem.char_cache.val = value;
            updates.Add(elem);
        }
        public void on_float_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, float value)
        {
            param_update_cache_t elem = new param_update_cache_t();
            elem.type = param_cache_type_e.float_e;
            elem.float_cache.which = which;
            elem.float_cache.level = level;
            elem.float_cache.seq = seq;
            elem.float_cache.primary_instrument_id = primary_instrument_id;
            elem.float_cache.secondary_instrument_id = secondary_instrument_id;
            elem.float_cache.param_idx = param_idx;
            elem.float_cache.val = value;
            updates.Add(elem);
        }
        public void on_double_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, double value)
        {
            param_update_cache_t elem = new param_update_cache_t();
            elem.type = param_cache_type_e.double_e;
            elem.double_cache.which = which;
            elem.double_cache.level = level;
            elem.double_cache.seq = seq;
            elem.double_cache.primary_instrument_id = primary_instrument_id;
            elem.double_cache.secondary_instrument_id = secondary_instrument_id;
            elem.double_cache.param_idx = param_idx;
            elem.double_cache.val = value;
            updates.Add(elem);
        }
        public void on_uint8_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, byte value)
        {
            param_update_cache_t elem = new param_update_cache_t();
            elem.type = param_cache_type_e.uint8_e;
            elem.uint8_cache.which = which;
            elem.uint8_cache.level = level;
            elem.uint8_cache.seq = seq;
            elem.uint8_cache.primary_instrument_id = primary_instrument_id;
            elem.uint8_cache.secondary_instrument_id = secondary_instrument_id;
            elem.uint8_cache.param_idx = param_idx;
            elem.uint8_cache.val = value;
            updates.Add(elem);
        }
        public void on_uint16_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ushort value)
        {
            param_update_cache_t elem = new param_update_cache_t();
            elem.type = param_cache_type_e.uint16_e;
            elem.uint16_cache.which = which;
            elem.uint16_cache.level = level;
            elem.uint16_cache.seq = seq;
            elem.uint16_cache.primary_instrument_id = primary_instrument_id;
            elem.uint16_cache.secondary_instrument_id = secondary_instrument_id;
            elem.uint16_cache.param_idx = param_idx;
            elem.uint16_cache.val = value;
            updates.Add(elem);
        }
        public void on_uint32_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, uint value)
        {
            param_update_cache_t elem = new param_update_cache_t();
            elem.type = param_cache_type_e.uint32_e;
            elem.uint32_cache.which = which;
            elem.uint32_cache.level = level;
            elem.uint32_cache.seq = seq;
            elem.uint32_cache.primary_instrument_id = primary_instrument_id;
            elem.uint32_cache.secondary_instrument_id = secondary_instrument_id;
            elem.uint32_cache.param_idx = param_idx;
            elem.uint32_cache.val = value;
            updates.Add(elem);
        }
        public void on_uint64_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ulong value)
        {
            param_update_cache_t elem = new param_update_cache_t();
            elem.type = param_cache_type_e.uint64_e;
            elem.uint64_cache.which = which;
            elem.uint64_cache.level = level;
            elem.uint64_cache.seq = seq;
            elem.uint64_cache.primary_instrument_id = primary_instrument_id;
            elem.uint64_cache.secondary_instrument_id = secondary_instrument_id;
            elem.uint64_cache.param_idx = param_idx;
            elem.uint64_cache.val = value;
            updates.Add(elem);
        }
        public void on_int8_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, sbyte value)
        {
            param_update_cache_t elem = new param_update_cache_t();
            elem.type = param_cache_type_e.int8_e;
            elem.int8_cache.which = which;
            elem.int8_cache.level = level;
            elem.int8_cache.seq = seq;
            elem.int8_cache.primary_instrument_id = primary_instrument_id;
            elem.int8_cache.secondary_instrument_id = secondary_instrument_id;
            elem.int8_cache.param_idx = param_idx;
            elem.int8_cache.val = value;
            updates.Add(elem);
        }
        public void on_int16_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, short value)
        {
            param_update_cache_t elem = new param_update_cache_t();
            elem.type = param_cache_type_e.int16_e;
            elem.int16_cache.which = which;
            elem.int16_cache.level = level;
            elem.int16_cache.seq = seq;
            elem.int16_cache.primary_instrument_id = primary_instrument_id;
            elem.int16_cache.secondary_instrument_id = secondary_instrument_id;
            elem.int16_cache.param_idx = param_idx;
            elem.int16_cache.val = value;
            updates.Add(elem);
        }
        public void on_int32_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, int value)
        {
            param_update_cache_t elem = new param_update_cache_t();
            elem.type = param_cache_type_e.int32_e;
            elem.int32_cache.which = which;
            elem.int32_cache.level = level;
            elem.int32_cache.seq = seq;
            elem.int32_cache.primary_instrument_id = primary_instrument_id;
            elem.int32_cache.secondary_instrument_id = secondary_instrument_id;
            elem.int32_cache.param_idx = param_idx;
            elem.int32_cache.val = value;
            updates.Add(elem);
        }
        public void on_int64_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, long value)
        {
            param_update_cache_t elem = new param_update_cache_t();
            elem.type = param_cache_type_e.int64_e;
            elem.int64_cache.which = which;
            elem.int64_cache.level = level;
            elem.int64_cache.seq = seq;
            elem.int64_cache.primary_instrument_id = primary_instrument_id;
            elem.int64_cache.secondary_instrument_id = secondary_instrument_id;
            elem.int64_cache.param_idx = param_idx;
            elem.int64_cache.val = value;
            updates.Add(elem);
        }
        public void on_time_series_date_double_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ref Protocol.ParamServerN.TimeSeriesDateDoubleParamT value)
        {
            param_update_cache_t elem = new param_update_cache_t();
            elem.type = param_cache_type_e.date_double_e;
            elem.int64_cache.which = which;
            elem.date_double_cache.level = level;
            elem.date_double_cache.seq = seq;
            elem.date_double_cache.primary_instrument_id = primary_instrument_id;
            elem.date_double_cache.secondary_instrument_id = secondary_instrument_id;
            elem.date_double_cache.param_idx = param_idx;
            elem.date_double_cache.value = value;
            updates.Add(elem);
        }
        public void on_time_series_datetime_double_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ref Protocol.ParamServerN.TimeSeriesDateTimeDoubleParamT value)
        {
            param_update_cache_t elem = new param_update_cache_t();
            elem.type = param_cache_type_e.datetime_double_e;
            elem.datetime_double_cache.which = which;
            elem.datetime_double_cache.level = level;
            elem.datetime_double_cache.seq = seq;
            elem.datetime_double_cache.primary_instrument_id = primary_instrument_id;
            elem.datetime_double_cache.secondary_instrument_id = secondary_instrument_id;
            elem.datetime_double_cache.param_idx = param_idx;
            elem.datetime_double_cache.value = value;
            updates.Add(elem);
        }
        public void on_time_series_date_uint64_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ref Protocol.ParamServerN.TimeSeriesDateUint64ParamT value)
        {
            param_update_cache_t elem = new param_update_cache_t();
            elem.type = param_cache_type_e.date_uint64_e;
            elem.date_uint64_cache.which = which;
            elem.date_uint64_cache.level = level;
            elem.date_uint64_cache.seq = seq;
            elem.date_uint64_cache.primary_instrument_id = primary_instrument_id;
            elem.date_uint64_cache.secondary_instrument_id = secondary_instrument_id;
            elem.date_uint64_cache.param_idx = param_idx;
            elem.date_uint64_cache.value = value;
            updates.Add(elem);
        }
        public void on_time_series_datetime_uint64_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ref Protocol.ParamServerN.TimeSeriesDateTimeUint64ParamT value)
        {
            param_update_cache_t elem = new param_update_cache_t();
            elem.type = param_cache_type_e.datetime_uint64_e;
            elem.datetime_uint64_cache.which = which;
            elem.datetime_uint64_cache.level = level;
            elem.datetime_uint64_cache.seq = seq;
            elem.datetime_uint64_cache.primary_instrument_id = primary_instrument_id;
            elem.datetime_uint64_cache.secondary_instrument_id = secondary_instrument_id;
            elem.datetime_uint64_cache.param_idx = param_idx;
            elem.datetime_uint64_cache.value = value;
            updates.Add(elem);
        }
        public void on_time_series_date_int64_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ref Protocol.ParamServerN.TimeSeriesDateInt64ParamT value)
        {
            param_update_cache_t elem = new param_update_cache_t();
            elem.type = param_cache_type_e.date_int64_e;
            elem.date_int64_cache.which = which;
            elem.date_int64_cache.level = level;
            elem.date_int64_cache.seq = seq;
            elem.date_int64_cache.primary_instrument_id = primary_instrument_id;
            elem.date_int64_cache.secondary_instrument_id = secondary_instrument_id;
            elem.date_int64_cache.param_idx = param_idx;
            elem.date_int64_cache.value = value;
            updates.Add(elem);
        }
        public void on_time_series_datetime_int64_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ref Protocol.ParamServerN.TimeSeriesDateTimeInt64ParamT value)
        {
            param_update_cache_t elem = new param_update_cache_t();
            elem.type = param_cache_type_e.datetime_int64_e;
            elem.datetime_int64_cache.which = which;
            elem.datetime_int64_cache.level = level;
            elem.datetime_int64_cache.seq = seq;
            elem.datetime_int64_cache.primary_instrument_id = primary_instrument_id;
            elem.datetime_int64_cache.secondary_instrument_id = secondary_instrument_id;
            elem.datetime_int64_cache.param_idx = param_idx;
            elem.datetime_int64_cache.value = value;
            updates.Add(elem);
        }
        public void apply_updates()
        {
            foreach (param_update_cache_t update in updates)
            {
                switch (update.type)
                {
                    case param_cache_type_e.removal:
                        {
                            router.onParamRemovalFromCache(update.removal.which, update.removal.level, update.removal.seq, update.removal.primary_instrument_id, update.removal.secondary_instrument_id, update.removal.param_idx);
                        }
                        break;
                    case param_cache_type_e.bool_e:
                        {
                            router.on_bool_param_from_cache(update.bool_cache.which, update.bool_cache.level, update.bool_cache.seq, update.bool_cache.primary_instrument_id, update.bool_cache.secondary_instrument_id, update.bool_cache.param_idx, update.bool_cache.val);
                        }
                        break;
                    case param_cache_type_e.char_e:
                        {
                            router.on_char_param_from_cache(update.char_cache.which, update.char_cache.level, update.char_cache.seq, update.char_cache.primary_instrument_id, update.char_cache.secondary_instrument_id, update.char_cache.param_idx, update.char_cache.val);
                        }
                        break;
                    case param_cache_type_e.float_e:
                        {
                            router.on_float_param_from_cache(update.float_cache.which, update.float_cache.level, update.float_cache.seq, update.float_cache.primary_instrument_id, update.float_cache.secondary_instrument_id, update.float_cache.param_idx, update.float_cache.val);
                        }
                        break;
                    case param_cache_type_e.double_e:
                        {
                            router.on_double_param_from_cache(update.double_cache.which, update.double_cache.level, update.double_cache.seq, update.double_cache.primary_instrument_id, update.double_cache.secondary_instrument_id, update.double_cache.param_idx, update.double_cache.val);
                        }
                        break;
                    case param_cache_type_e.uint8_e:
                        {
                            router.on_uint8_param_from_cache(update.uint8_cache.which, update.uint8_cache.level, update.uint8_cache.seq, update.uint8_cache.primary_instrument_id, update.uint8_cache.secondary_instrument_id, update.uint8_cache.param_idx, update.uint8_cache.val);
                        }
                        break;
                    case param_cache_type_e.uint16_e:
                        {
                            router.on_uint16_param_from_cache(update.uint16_cache.which, update.uint16_cache.level, update.uint16_cache.seq, update.uint16_cache.primary_instrument_id, update.uint16_cache.secondary_instrument_id, update.uint16_cache.param_idx, update.uint16_cache.val);
                        }
                        break;
                    case param_cache_type_e.uint32_e:
                        {
                            router.on_uint32_param_from_cache(update.uint32_cache.which, update.uint32_cache.level, update.uint32_cache.seq, update.uint32_cache.primary_instrument_id, update.uint32_cache.secondary_instrument_id, update.uint32_cache.param_idx, update.uint32_cache.val);
                        }
                        break;
                    case param_cache_type_e.uint64_e:
                        {
                            router.on_uint64_param_from_cache(update.uint64_cache.which, update.uint64_cache.level, update.uint64_cache.seq, update.uint64_cache.primary_instrument_id, update.uint64_cache.secondary_instrument_id, update.uint64_cache.param_idx, update.uint64_cache.val);
                        }
                        break;
                    case param_cache_type_e.int8_e:
                        {
                            router.on_int8_param_from_cache(update.int8_cache.which, update.int8_cache.level, update.int8_cache.seq, update.int8_cache.primary_instrument_id, update.int8_cache.secondary_instrument_id, update.int8_cache.param_idx, update.int8_cache.val);
                        }
                        break;
                    case param_cache_type_e.int16_e:
                        {
                            router.on_int16_param_from_cache(update.int16_cache.which, update.int16_cache.level, update.int16_cache.seq, update.int16_cache.primary_instrument_id, update.int16_cache.secondary_instrument_id, update.int16_cache.param_idx, update.int16_cache.val);
                        }
                        break;
                    case param_cache_type_e.int32_e:
                        {
                            router.on_int32_param_from_cache(update.int32_cache.which, update.int32_cache.level, update.int32_cache.seq, update.int32_cache.primary_instrument_id, update.int32_cache.secondary_instrument_id, update.int32_cache.param_idx, update.int32_cache.val);
                        }
                        break;
                    case param_cache_type_e.int64_e:
                        {
                            router.on_int64_param_from_cache(update.int64_cache.which, update.int64_cache.level, update.int64_cache.seq, update.int64_cache.primary_instrument_id, update.int64_cache.secondary_instrument_id, update.int64_cache.param_idx, update.int64_cache.val);
                        }
                        break;
                    case param_cache_type_e.date_double_e:
                        {
                            router.on_time_series_date_double_param_from_cache(update.date_double_cache.which, update.date_double_cache.level, update.date_double_cache.seq, update.date_double_cache.primary_instrument_id, update.date_double_cache.secondary_instrument_id, update.date_double_cache.param_idx, ref update.date_double_cache.value);
                        }
                        break;
                    case param_cache_type_e.datetime_double_e:
                        {
                            router.on_time_series_datetime_double_param_from_cache(update.datetime_double_cache.which, update.datetime_double_cache.level, update.datetime_double_cache.seq, update.datetime_double_cache.primary_instrument_id, update.datetime_double_cache.secondary_instrument_id, update.datetime_double_cache.param_idx, ref update.datetime_double_cache.value);
                        }
                        break;
                    case param_cache_type_e.date_uint64_e:
                        {
                            router.on_time_series_date_uint64_param_from_cache(update.date_uint64_cache.which, update.date_uint64_cache.level, update.date_uint64_cache.seq, update.date_uint64_cache.primary_instrument_id, update.date_uint64_cache.secondary_instrument_id, update.date_uint64_cache.param_idx, ref update.date_uint64_cache.value);
                        }
                        break;
                    case param_cache_type_e.datetime_uint64_e:
                        {
                            router.on_time_series_datetime_uint64_param_from_cache(update.datetime_uint64_cache.which, update.datetime_uint64_cache.level, update.datetime_uint64_cache.seq, update.datetime_uint64_cache.primary_instrument_id, update.datetime_uint64_cache.secondary_instrument_id, update.datetime_uint64_cache.param_idx, ref update.datetime_uint64_cache.value);
                        }
                        break;
                    case param_cache_type_e.date_int64_e:
                        {
                            router.on_time_series_date_int64_param_from_cache(update.date_int64_cache.which, update.date_int64_cache.level, update.date_int64_cache.seq, update.date_int64_cache.primary_instrument_id, update.date_int64_cache.secondary_instrument_id, update.date_int64_cache.param_idx, ref update.date_int64_cache.value);
                        }
                        break;
                    case param_cache_type_e.datetime_int64_e:
                        {
                            router.on_time_series_datetime_int64_param_from_cache(update.datetime_int64_cache.which, update.datetime_int64_cache.level, update.datetime_int64_cache.seq, update.datetime_int64_cache.primary_instrument_id, update.datetime_int64_cache.secondary_instrument_id, update.datetime_int64_cache.param_idx, ref update.datetime_int64_cache.value);
                        }
                        break;
                    case param_cache_type_e.invalid:
                    default:
                        {
                            Logger.Log(Logger.Level.error, "Recieved a unrecognized param update from param_cache");
                        }
                        break;
                }
            }
            updates.Clear();
        }
    }
}