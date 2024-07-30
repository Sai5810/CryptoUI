using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DevExpress.XtraPrinting.Native.ExportOptionsPropertiesNames;

namespace CryptoUI.Network
{
    public class ParamRouter
    {
        private App raven;
        private IEventHandler em;
        private CryptoUI.Panel.ParamManagement.ParamManagement manager = null;
        private ParamCache cache = null;
        public ParamRouter(App raven_, IEventHandler em_)
        {
            raven = raven_;
            em = em_;
            cache = new ParamCache(this);
        }
        public void onMajorGroupSubscribeAck(ulong major_group_id, bool success)
        {
            //string sym = Services.UniqueInstrumentIdConfigService.DoesUniqueInstrumentIdExist(major_group_id) ? (Services.InstrumentIdSymbolConfigService.Exists(Services.UniqueInstrumentIdConfigService.GetInstrumentId(major_group_id)) ? Services.InstrumentIdSymbolConfigService.GetSymbol(Services.UniqueInstrumentIdConfigService.GetInstrumentId(major_group_id)) : $"instid[{Services.UniqueInstrumentIdConfigService.GetInstrumentId(major_group_id)}]") : $"uid[{major_group_id}]";
            //Logger.Log(Logger.Level.info, $"Param Subscription {(success ? "Ack" : "Failure")} {sym}");
        }
        public void setParamManager()
        {
            manager = raven.GetParamManager();
            cache.apply_updates();
        }
        public bool publishParam(Protocol.ParamServerN.ParamChangeMsgT msg)
        {
            return em.publishParam(msg);
        }
        public bool publishSubscribe(ulong id)
        {
            return em.publishSubscribe(id);
        }
        public bool publishUnsubscribe(ulong id)
        {
            return em.publishUnsubscribe(id);
        }

        public void onConnect()
        {

        }
        public void onParamRemoval(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx)
        {
            if (manager == null)
            {
                cache.onParamRemoval(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx);
            }
            else
            {
                manager.on_removal_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx);
            }
        }
        public void on_bool_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, bool value)
        {
            if (manager == null)
            {
                cache.on_bool_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
            }
            else
            {
                manager.on_bool_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
            }
        }
        public void on_char_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, char value)
        {
            if (manager == null)
            {
                cache.on_char_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
            }
            else
            {
                manager.on_char_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
            }
        }
        public void on_float_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, float value)
        {
            if (manager == null)
            {
                cache.on_float_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
            }
            else
            {
                manager.on_float_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
            }
        }
        public void on_double_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, double value)
        {
            if (manager == null)
            {
                cache.on_double_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
            }
            else
            {
                manager.on_double_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
            }
        }
        public void on_uint8_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, byte value)
        {
            if (manager == null)
            {
                cache.on_uint8_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
            }
            else
            {
                manager.on_uint8_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
            }
        }
        public void on_uint16_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ushort value)
        {
            if (manager == null)
            {
                cache.on_uint16_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
            }
            else
            {
                manager.on_uint16_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
            }
        }
        public void on_uint32_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, uint value)
        {
            if (manager == null)
            {
                cache.on_uint32_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
            }
            else
            {
                manager.on_uint32_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
            }
        }
        public void on_uint64_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ulong value)
        {
            if (manager == null)
            {
                cache.on_uint64_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
            }
            else
            {
                manager.on_uint64_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
            }
        }
        public void on_int8_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, sbyte value)
        {
            if (manager == null)
            {
                cache.on_int8_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
            }
            else
            {
                manager.on_int8_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
            }
        }
        public void on_int16_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, short value)
        {
            if (manager == null)
            {
                cache.on_int16_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
            }
            else
            {
                manager.on_int16_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
            }
        }
        public void on_int32_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, int value)
        {
            if (manager == null)
            {
                cache.on_int32_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
            }
            else
            {
                manager.on_int32_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
            }
        }
        public void on_int64_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, long value)
        {
            if (manager == null)
            {
                cache.on_int64_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
            }
            else
            {
                manager.on_int64_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
            }
        }
        public void on_time_series_date_double_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ref Protocol.ParamServerN.TimeSeriesDateDoubleParamT value)
        {
            if (manager == null)
            {
                cache.on_time_series_date_double_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, ref value);
            }
            else
            {
                manager.on_time_series_date_double_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, ref value);
            }
        }
        public void on_time_series_datetime_double_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ref Protocol.ParamServerN.TimeSeriesDateTimeDoubleParamT value)
        {
            if (manager == null)
            {
                cache.on_time_series_datetime_double_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, ref value);
            }
            else
            {
                manager.on_time_series_datetime_double_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, ref value);
            }
        }
        public void on_time_series_date_uint64_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ref Protocol.ParamServerN.TimeSeriesDateUint64ParamT value)
        {
            if (manager == null)
            {
                cache.on_time_series_date_uint64_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, ref value);
            }
            else
            {
                manager.on_time_series_date_uint64_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, ref value);
            }
        }
        public void on_time_series_datetime_uint64_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ref Protocol.ParamServerN.TimeSeriesDateTimeUint64ParamT value)
        {
            if (manager == null)
            {
                cache.on_time_series_datetime_uint64_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, ref value);
            }
            else
            {
                manager.on_time_series_datetime_uint64_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, ref value);
            }
        }
        public void on_time_series_date_int64_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ref Protocol.ParamServerN.TimeSeriesDateInt64ParamT value)
        {
            if (manager == null)
            {
                cache.on_time_series_date_int64_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, ref value);
            }
            else
            {
                manager.on_time_series_date_int64_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, ref value);
            }
        }
        public void on_time_series_datetime_int64_param(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ref Protocol.ParamServerN.TimeSeriesDateTimeInt64ParamT value)
        {
            if (manager == null)
            {
                cache.on_time_series_datetime_int64_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, ref value);
            }
            else
            {
                manager.on_time_series_datetime_int64_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, ref value);
            }
        }


        public void onParamRemovalFromCache(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx)
        {
            manager.on_removal_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx);
        }
        public void on_bool_param_from_cache(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, bool value)
        {
            manager.on_bool_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
        }
        public void on_char_param_from_cache(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, char value)
        {
            manager.on_char_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
        }
        public void on_float_param_from_cache(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, float value)
        {
            manager.on_float_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
        }
        public void on_double_param_from_cache(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, double value)
        {
            manager.on_double_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
        }
        public void on_uint8_param_from_cache(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, byte value)
        {
            manager.on_uint8_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
        }
        public void on_uint16_param_from_cache(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ushort value)
        {
            manager.on_uint16_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
        }
        public void on_uint32_param_from_cache(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, uint value)
        {
            manager.on_uint32_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
        }
        public void on_uint64_param_from_cache(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ulong value)
        {
            manager.on_uint64_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
        }
        public void on_int8_param_from_cache(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, sbyte value)
        {
            manager.on_int8_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
        }
        public void on_int16_param_from_cache(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, short value)
        {
            manager.on_int16_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
        }
        public void on_int32_param_from_cache(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, int value)
        {
            manager.on_int32_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
        }
        public void on_int64_param_from_cache(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, long value)
        {
            manager.on_int64_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value);
        }
        public void on_time_series_date_double_param_from_cache(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ref Protocol.ParamServerN.TimeSeriesDateDoubleParamT value)
        {
            manager.on_time_series_date_double_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, ref value);
        }
        public void on_time_series_datetime_double_param_from_cache(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ref Protocol.ParamServerN.TimeSeriesDateTimeDoubleParamT value)
        {
            manager.on_time_series_datetime_double_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, ref value);
        }
        public void on_time_series_date_uint64_param_from_cache(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ref Protocol.ParamServerN.TimeSeriesDateUint64ParamT value)
        {
            manager.on_time_series_date_uint64_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, ref value);
        }
        public void on_time_series_datetime_uint64_param_from_cache(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ref Protocol.ParamServerN.TimeSeriesDateTimeUint64ParamT value)
        {
            manager.on_time_series_datetime_uint64_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, ref value);
        }
        public void on_time_series_date_int64_param_from_cache(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ref Protocol.ParamServerN.TimeSeriesDateInt64ParamT value)
        {
            manager.on_time_series_date_int64_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, ref value);
        }
        public void on_time_series_datetime_int64_param_from_cache(ushort which, Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ref Protocol.ParamServerN.TimeSeriesDateTimeInt64ParamT value)
        {
            manager.on_time_series_datetime_int64_param(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, ref value);
        }
    }
}
