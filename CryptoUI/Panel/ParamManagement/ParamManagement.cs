using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoUI.Panel.ParamManagement
{
    public struct ParamStringsT
    {
        public string Name;
        public string Level;
        public string Type;
        public string PriKey;
        public string SecKey;
        public string Idx;
        public string Value;
    }
    public class ParamManagement
    {
        private GridControl gridControl;
        private CryptoUI.App app;
        private DataTable dt;
        private Dictionary<ushort, Dictionary<ulong, Dictionary<ulong, Dictionary<ulong, object>>>> cache_for_checks;
        public ParamManagement(GridControl gridControlView, CryptoUI.App app)
        {
            this.gridControl = gridControlView;
            this.app = app;
            this.dt = new DataTable();
            this.gridControl.DataSource = dt;
            this.cache_for_checks = new Dictionary<ushort, Dictionary<ulong, Dictionary<ulong, Dictionary<ulong, object>>>>();
            dt.Columns.Add("Name");
            dt.Columns.Add("Level");
            dt.Columns.Add("Type");
            dt.Columns.Add("Primary");
            dt.Columns.Add("Secondary");
            dt.Columns.Add("Index");
            dt.Columns.Add("Val");
            dt.PrimaryKey = new DataColumn[] { dt.Columns["Level"], dt.Columns["Name"], dt.Columns["Primary"], dt.Columns["Secondary"], dt.Columns["Index"] };
        }

        public bool should_validate(ushort param_enum)
        {
            if (param_enum == 107) // efp
                return true;
            return false;
        }

        public bool set_value(int row, string value)
        {
            try
            {
                dt.Rows[row]["Val"] = value;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void cache_value(ushort param_enum, ulong primary_uid, ulong secondary_uid, ulong idx, object val)
        {
            if (!this.cache_for_checks.ContainsKey(param_enum))
                this.cache_for_checks.Add(param_enum, new Dictionary<ulong, Dictionary<ulong, Dictionary<ulong, object>>>());
            if (!this.cache_for_checks[param_enum].ContainsKey(primary_uid))
                this.cache_for_checks[param_enum].Add(primary_uid, new Dictionary<ulong, Dictionary<ulong, object>>());
            if (!this.cache_for_checks[param_enum][primary_uid].ContainsKey(secondary_uid))
                this.cache_for_checks[param_enum][primary_uid].Add(secondary_uid, new Dictionary<ulong, object>());
            if (!this.cache_for_checks[param_enum][primary_uid][secondary_uid].ContainsKey(idx))
                this.cache_for_checks[param_enum][primary_uid][secondary_uid].Add(idx, val);
            else
                this.cache_for_checks[param_enum][primary_uid][secondary_uid][idx] = val;
        }
        public object get_cache_value(ushort param_enum, ulong primary_uid, ulong secondary_uid, ulong idx)
        {
            if (!this.cache_for_checks.ContainsKey(param_enum))
                return null;
            if (!this.cache_for_checks[param_enum].ContainsKey(primary_uid))
                return null;
            if (!this.cache_for_checks[param_enum][primary_uid].ContainsKey(secondary_uid))
                return null;
            if (!this.cache_for_checks[param_enum][primary_uid][secondary_uid].ContainsKey(idx))
                return null;
            return this.cache_for_checks[param_enum][primary_uid][secondary_uid][idx];
        }
        public bool validate(ushort param_enum, ulong primary_uid, ulong secondary_uid, ulong idx, object old_val, string new_val_in, out string new_val)
        {
            //if (param_enum == 107) // efp
            //{
            //    ulong efp_id = CryptoUI.Services.UniqueInstrumentIdConfigService.GetInstrumentId(primary_uid);
            //    if (CryptoUI.Services.EFPConfigService.ExistsByEFP(efp_id))
            //    {
            //        ulong future_id = CryptoUI.Services.EFPConfigService.GetFutureIdFromEFPId(efp_id);
            //        long leader_inav = this.CryptoUI.GetEtfManager().GetLeaderInav(future_id);
            //        if (leader_inav != long.MaxValue)
            //        {
            //            double.TryParse(new_val_in, out double base_efp);
            //            double old_base_efp = (double)old_val;
            //            if ((Math.Abs(base_efp - old_base_efp) / (leader_inav / 1000000000.0)) > 0.0005)
            //            {
            //                new_val = old_base_efp.ToString();
            //                return false;
            //            }
            //        }
            //    }
            //}
            new_val = new_val_in;
            return true;
        }
        public bool should_hover_over(ushort param_enum)
        {
            if (param_enum == 107) // efp
                return true;
            return false;
        }
        private static long multiply_nanos(long a, long b)
        {
            if (a == long.MaxValue || b == long.MaxValue)
                return long.MaxValue;
            return (long)(((a / 1000000000.0) * (b / 1000000000.0)) * 1000000000);
        }
        private static long divide_nanos(long a, long b)
        {
            if (a == long.MaxValue || b == long.MaxValue)
                return long.MaxValue;
            return (long)(((a / 1000000000.0) / (b / 1000000000.0)) * 1000000000);
        }
        public string get_hover_over_value(ushort param_enum, ulong primary_uid, ulong secondary_uid, ulong idx, string current_value)
        {
            //if (param_enum == 107) // efp
            //{
            //    ulong efp_id = CryptoUI.Services.UniqueInstrumentIdConfigService.GetInstrumentId(primary_uid);
            //    ulong fut_chain_id = CryptoUI.Services.UniqueInstrumentIdConfigService.GetInstrumentId(secondary_uid);
            //    string fut_chain_sym = CryptoUI.Services.InstrumentIdSymbolConfigService.GetSymbol(fut_chain_id);
            //    if (CryptoUI.Services.EFPConfigService.ExistsByEFP(efp_id))
            //    {
            //        ulong future_id = CryptoUI.Services.EFPConfigService.GetFutureIdFromEFPId(efp_id);
            //        if (CryptoUI.Services.FuturesChainConfigService.ExistsByFuture(future_id))
            //        {
            //            if (CryptoUI.Services.FuturesChainConfigService.GetChainIdFromFutureId(future_id) != fut_chain_id)
            //            {
            //                return "NaN";
            //            }
            //        }
            //        long leader_inav = this.CryptoUI.GetEtfManager().GetLeaderInav(future_id);
            //        if (leader_inav == long.MaxValue)
            //            return "NaN";
            //        ulong fut_idx_id = 0;
            //        if (fut_chain_sym == "ES.CHAIN")
            //        {
            //            if (CryptoUI.Services.InstrumentIdSymbolConfigService.Exists("SPX.IDX"))
            //                fut_idx_id = CryptoUI.Services.InstrumentIdSymbolConfigService.GetId("SPX.IDX");
            //        }
            //        else if (fut_chain_sym == "NQ.CHAIN")
            //        {
            //            if (CryptoUI.Services.InstrumentIdSymbolConfigService.Exists("NDX.IDX"))
            //                fut_idx_id = CryptoUI.Services.InstrumentIdSymbolConfigService.GetId("NDX.IDX");
            //        }
            //        else if (fut_chain_sym == "EMD.CHAIN")
            //        {
            //            if (CryptoUI.Services.InstrumentIdSymbolConfigService.Exists("MID.IDX"))
            //                fut_idx_id = CryptoUI.Services.InstrumentIdSymbolConfigService.GetId("MID.IDX");
            //        }
            //        else if (fut_chain_sym == "YM.CHAIN")
            //        {
            //            if (CryptoUI.Services.InstrumentIdSymbolConfigService.Exists("INDU.IDX"))
            //                fut_idx_id = CryptoUI.Services.InstrumentIdSymbolConfigService.GetId("INDU.IDX");
            //        }
            //        else if (fut_chain_sym == "RTY.CHAIN")
            //        {
            //            if (CryptoUI.Services.InstrumentIdSymbolConfigService.Exists("RTY.IDX"))
            //                fut_idx_id = CryptoUI.Services.InstrumentIdSymbolConfigService.GetId("RTY.IDX");
            //        }
            //        if (CryptoUI.Services.IndexDividendConfigService.Exists(fut_idx_id, future_id))
            //        {
            //            CryptoUI.Services.IndexDividendConfig c = CryptoUI.Services.IndexDividendConfigService.Get(fut_idx_id, future_id).Value;
            //            double.TryParse(current_value, out double base_efp);
            //            long efp_nanos = (long)(base_efp * 1000000000);
            //            long idx_close_ex_dvd = c.idx_close - c.ex_dvd;
            //            long result = efp_nanos + multiply_nanos(leader_inav - idx_close_ex_dvd, divide_nanos(efp_nanos + c.fut_dvd_to_exp, idx_close_ex_dvd));
            //            return CryptoUI.Protocol.ProtocolUtilities.nanos_to_string(result);
            //        }
            //        else
            //            return "NaN";
            //    }
            //    else
            //        return "NaN";
            //}
            return string.Empty;
        }
        public void remove_cache_value(ushort param_enum, ulong primary_uid, ulong secondary_uid, ulong idx)
        {
            if (!this.cache_for_checks.ContainsKey(param_enum))
                return;
            if (!this.cache_for_checks[param_enum].ContainsKey(primary_uid))
                return;
            if (!this.cache_for_checks[param_enum][primary_uid].ContainsKey(secondary_uid))
                return;
            if (!this.cache_for_checks[param_enum][primary_uid][secondary_uid].ContainsKey(idx))
                return;
            this.cache_for_checks[param_enum][primary_uid][secondary_uid].Remove(idx);
            if (this.cache_for_checks[param_enum][primary_uid][secondary_uid].Count == 0)
                this.cache_for_checks[param_enum][primary_uid].Remove(secondary_uid);
            if (this.cache_for_checks[param_enum][primary_uid].Count == 0)
                this.cache_for_checks[param_enum].Remove(primary_uid);
            if (this.cache_for_checks[param_enum].Count == 0)
                this.cache_for_checks.Remove(param_enum);
        }

        public DataRow[] get_rows_by_primary(string primary)
        {
            return dt.AsEnumerable().Where(r => r.Field<string>("Primary") == primary).ToArray();
        }

        public void add_new(ParamStringsT ps, CryptoUI.Protocol.ParamServerN.ParamChangeMsgT p)
        {
            DataRow row = dt.NewRow();
            row["Name"] = ps.Name;
            row["Level"] = ps.Level;
            row["Type"] = ps.Type;
            row["Primary"] = ps.PriKey;
            row["Secondary"] = ps.SecKey;
            row["Index"] = ps.Idx;
            row["Val"] = ps.Value;
            dt.Rows.Add(row);
            CryptoUI.Network.Logger.Log(CryptoUI.Network.Logger.Level.info, "Sending Param Definition for " + ps.Name + ": " + ps.Value);
            this.app.publishParam(p);
        }

        public bool exists(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, CryptoUI.Protocol.ParamServerN.ParamTypeE ptype, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx)
        {
            string name = this.app.get_param_name_from_param_enum(which);
            if (name.Length == 0)
                name = which.ToString();
            string lvl = this.app.get_text_from_param_level(level);
            if (lvl.Length == 0)
                return false;
            string ttype = this.app.get_text_from_param_type(ptype);
            ulong pri_inst_id = CryptoUI.Services.UniqueInstrumentIdConfigService.DoesUniqueInstrumentIdExist(primary_instrument_id) ? CryptoUI.Services.UniqueInstrumentIdConfigService.GetInstrumentId(primary_instrument_id) : 0;
            ulong sec_inst_id = CryptoUI.Services.UniqueInstrumentIdConfigService.DoesUniqueInstrumentIdExist(secondary_instrument_id) ? CryptoUI.Services.UniqueInstrumentIdConfigService.GetInstrumentId(secondary_instrument_id) : 0;
            string primary = (pri_inst_id > 0 && CryptoUI.Services.InstrumentIdSymbolConfigService.Exists(pri_inst_id)) ? CryptoUI.Services.InstrumentIdSymbolConfigService.GetSymbol(pri_inst_id) : "";
            string secondary = (sec_inst_id > 0 && CryptoUI.Services.InstrumentIdSymbolConfigService.Exists(sec_inst_id)) ? CryptoUI.Services.InstrumentIdSymbolConfigService.GetSymbol(sec_inst_id) : "";
            try
            {
                if (dt.Rows.Find(new object[] { lvl, name, primary, secondary, param_idx.ToString() }) != null)
                    return true;
                return false;
            }
            catch (MissingPrimaryKeyException)
            {
                return false;
            }
            catch (NullReferenceException)
            {
                return false;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        public string get(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, CryptoUI.Protocol.ParamServerN.ParamTypeE ptype, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx)
        {
            string name = this.app.get_param_name_from_param_enum(which);
            if (name.Length == 0)
                name = which.ToString();
            string lvl = this.app.get_text_from_param_level(level);
            if (lvl.Length == 0)
                return null;
            string ttype = this.app.get_text_from_param_type(ptype);
            ulong pri_inst_id = CryptoUI.Services.UniqueInstrumentIdConfigService.DoesUniqueInstrumentIdExist(primary_instrument_id) ? CryptoUI.Services.UniqueInstrumentIdConfigService.GetInstrumentId(primary_instrument_id) : 0;
            ulong sec_inst_id = CryptoUI.Services.UniqueInstrumentIdConfigService.DoesUniqueInstrumentIdExist(secondary_instrument_id) ? CryptoUI.Services.UniqueInstrumentIdConfigService.GetInstrumentId(secondary_instrument_id) : 0;
            string primary = (pri_inst_id > 0 && CryptoUI.Services.InstrumentIdSymbolConfigService.Exists(pri_inst_id)) ? CryptoUI.Services.InstrumentIdSymbolConfigService.GetSymbol(pri_inst_id) : "";
            string secondary = (sec_inst_id > 0 && CryptoUI.Services.InstrumentIdSymbolConfigService.Exists(sec_inst_id)) ? CryptoUI.Services.InstrumentIdSymbolConfigService.GetSymbol(sec_inst_id) : "";
            try
            {
                DataRow row = dt.Rows.Find(new object[] { lvl, name, primary, secondary, param_idx.ToString() });
                if (row != null)
                    return row["Val"].ToString();
                return null;
            }
            catch (MissingPrimaryKeyException)
            {
                return null;
            }
            catch (NullReferenceException)
            {
                return null;
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }

        public bool update(CryptoUI.Protocol.ParamServerN.ParamChangeMsgT p)
        {
            return this.app.publishParam(p);
        }
        public bool on_param_setup(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, CryptoUI.Protocol.ParamServerN.ParamTypeE ptype, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, out DataRow row, out bool should_add)
        {
            string name = this.app.get_param_name_from_param_enum(which);
            if (name.Length == 0)
                name = which.ToString();
            string lvl = this.app.get_text_from_param_level(level);
            if (lvl.Length == 0)
            {
                row = null;
                should_add = false;
                return false;
            }
            string ttype = this.app.get_text_from_param_type(ptype);
            ulong pri_inst_id = CryptoUI.Services.UniqueInstrumentIdConfigService.DoesUniqueInstrumentIdExist(primary_instrument_id) ? CryptoUI.Services.UniqueInstrumentIdConfigService.GetInstrumentId(primary_instrument_id) : 0;
            ulong sec_inst_id = CryptoUI.Services.UniqueInstrumentIdConfigService.DoesUniqueInstrumentIdExist(secondary_instrument_id) ? CryptoUI.Services.UniqueInstrumentIdConfigService.GetInstrumentId(secondary_instrument_id) : 0;
            string primary = (pri_inst_id > 0 && CryptoUI.Services.InstrumentIdSymbolConfigService.Exists(pri_inst_id)) ? CryptoUI.Services.InstrumentIdSymbolConfigService.GetSymbol(pri_inst_id) : "";
            string secondary = (sec_inst_id > 0 && CryptoUI.Services.InstrumentIdSymbolConfigService.Exists(sec_inst_id)) ? CryptoUI.Services.InstrumentIdSymbolConfigService.GetSymbol(sec_inst_id) : "";
            should_add = true;
            try
            {
                row = dt.Rows.Find(new object[] { lvl, name, primary, secondary, param_idx.ToString() });
                if (row != null)
                    should_add = false;
                else
                    row = dt.NewRow();
            }
            catch (MissingPrimaryKeyException)
            {
                row = dt.NewRow();
            }
            catch (NullReferenceException)
            {
                row = dt.NewRow();
            }
            catch (IndexOutOfRangeException)
            {
                row = dt.NewRow();
            }
            if (should_add)
            {
                row["Name"] = name;
                row["Level"] = lvl;
                row["Type"] = ttype;
                row["Primary"] = primary;
                row["Secondary"] = secondary;
                row["Index"] = param_idx.ToString();
            }
            return true;
        }
        #region param_update_handlers
        public void on_removal_param(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx)
        {
            if (app.InvokeRequired)
            {
                app.Invoke(new System.Action<ushort, CryptoUI.Protocol.ParamServerN.LevelE, uint, ulong, ulong, ushort>(on_removal_param), new object[] { which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx });
                return;
            }
            string name = this.app.get_param_name_from_param_enum(which);
            if (name.Length == 0)
                name = which.ToString();
            string lvl = this.app.get_text_from_param_level(level);
            if (lvl.Length == 0)
                return;
            ulong pri_inst_id = CryptoUI.Services.UniqueInstrumentIdConfigService.DoesUniqueInstrumentIdExist(primary_instrument_id) ? CryptoUI.Services.UniqueInstrumentIdConfigService.GetInstrumentId(primary_instrument_id) : 0;
            ulong sec_inst_id = CryptoUI.Services.UniqueInstrumentIdConfigService.DoesUniqueInstrumentIdExist(secondary_instrument_id) ? CryptoUI.Services.UniqueInstrumentIdConfigService.GetInstrumentId(secondary_instrument_id) : 0;
            string primary = (pri_inst_id > 0 && CryptoUI.Services.InstrumentIdSymbolConfigService.Exists(pri_inst_id)) ? CryptoUI.Services.InstrumentIdSymbolConfigService.GetSymbol(pri_inst_id) : "";
            string secondary = (sec_inst_id > 0 && CryptoUI.Services.InstrumentIdSymbolConfigService.Exists(sec_inst_id)) ? CryptoUI.Services.InstrumentIdSymbolConfigService.GetSymbol(sec_inst_id) : "";
            DataRow row = dt.Rows.Find(new object[] { lvl, name, primary, secondary, param_idx.ToString() });
            if (row == null)
                return;
            dt.Rows.Remove(row);
            if (should_validate(which))
                remove_cache_value(which, primary_instrument_id, secondary_instrument_id, param_idx);
        }
        public void on_bool_param(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, bool value)
        {
            if (app.InvokeRequired)
            {
                app.Invoke(new System.Action<ushort, CryptoUI.Protocol.ParamServerN.LevelE, uint, ulong, ulong, ushort, bool>(on_bool_param), new object[] { which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value });
                return;
            }
            if (!on_param_setup(which, level, CryptoUI.Protocol.ParamServerN.ParamTypeE.boolean, seq, primary_instrument_id, secondary_instrument_id, param_idx, out DataRow row, out bool should_add))
                return;
            row["Val"] = value.ToString();
            if (should_add)
                dt.Rows.Add(row);
            if (should_validate(which))
                cache_value(which, primary_instrument_id, secondary_instrument_id, param_idx, value);
        }
        public void on_char_param(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, char value)
        {
            if (app.InvokeRequired)
            {
                app.Invoke(new System.Action<ushort, CryptoUI.Protocol.ParamServerN.LevelE, uint, ulong, ulong, ushort, char>(on_char_param), new object[] { which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value });
                return;
            }
            if (!on_param_setup(which, level, CryptoUI.Protocol.ParamServerN.ParamTypeE.char_e, seq, primary_instrument_id, secondary_instrument_id, param_idx, out DataRow row, out bool should_add))
                return;
            row["Val"] = value.ToString();
            if (should_add)
                dt.Rows.Add(row);
            if (should_validate(which))
                cache_value(which, primary_instrument_id, secondary_instrument_id, param_idx, value);
        }
        public void on_float_param(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, float value)
        {
            if (app.InvokeRequired)
            {
                app.Invoke(new System.Action<ushort, CryptoUI.Protocol.ParamServerN.LevelE, uint, ulong, ulong, ushort, float>(on_float_param), new object[] { which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value });
                return;
            }
            if (!on_param_setup(which, level, CryptoUI.Protocol.ParamServerN.ParamTypeE.float_e, seq, primary_instrument_id, secondary_instrument_id, param_idx, out DataRow row, out bool should_add))
                return;
            row["Val"] = value.ToString();
            if (should_add)
                dt.Rows.Add(row);
            if (should_validate(which))
                cache_value(which, primary_instrument_id, secondary_instrument_id, param_idx, value);
        }
        public void on_double_param(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, double value)
        {
            if (app.InvokeRequired)
            {
                app.Invoke(new System.Action<ushort, CryptoUI.Protocol.ParamServerN.LevelE, uint, ulong, ulong, ushort, double>(on_double_param), new object[] { which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value });
                return;
            }
            if (!on_param_setup(which, level, CryptoUI.Protocol.ParamServerN.ParamTypeE.double_e, seq, primary_instrument_id, secondary_instrument_id, param_idx, out DataRow row, out bool should_add))
                return;
            row["Val"] = value.ToString();
            if (should_add)
                dt.Rows.Add(row);
            if (should_validate(which))
                cache_value(which, primary_instrument_id, secondary_instrument_id, param_idx, value);
        }
        public void on_uint8_param(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, byte value)
        {
            if (app.InvokeRequired)
            {
                app.Invoke(new System.Action<ushort, CryptoUI.Protocol.ParamServerN.LevelE, uint, ulong, ulong, ushort, byte>(on_uint8_param), new object[] { which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value });
                return;
            }
            if (!on_param_setup(which, level, CryptoUI.Protocol.ParamServerN.ParamTypeE.uint8_e, seq, primary_instrument_id, secondary_instrument_id, param_idx, out DataRow row, out bool should_add))
                return;
            row["Val"] = value.ToString();
            if (should_add)
                dt.Rows.Add(row);
            if (should_validate(which))
                cache_value(which, primary_instrument_id, secondary_instrument_id, param_idx, value);
        }
        public void on_uint16_param(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ushort value)
        {
            if (app.InvokeRequired)
            {
                app.Invoke(new System.Action<ushort, CryptoUI.Protocol.ParamServerN.LevelE, uint, ulong, ulong, ushort, ushort>(on_uint16_param), new object[] { which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value });
                return;
            }
            if (!on_param_setup(which, level, CryptoUI.Protocol.ParamServerN.ParamTypeE.uint16_e, seq, primary_instrument_id, secondary_instrument_id, param_idx, out DataRow row, out bool should_add))
                return;
            row["Val"] = value.ToString();
            if (should_add)
                dt.Rows.Add(row);
            if (should_validate(which))
                cache_value(which, primary_instrument_id, secondary_instrument_id, param_idx, value);
        }
        public void on_uint32_param(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, uint value)
        {
            if (app.InvokeRequired)
            {
                app.Invoke(new System.Action<ushort, CryptoUI.Protocol.ParamServerN.LevelE, uint, ulong, ulong, ushort, uint>(on_uint32_param), new object[] { which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value });
                return;
            }
            if (!on_param_setup(which, level, CryptoUI.Protocol.ParamServerN.ParamTypeE.uint32_e, seq, primary_instrument_id, secondary_instrument_id, param_idx, out DataRow row, out bool should_add))
                return;
            row["Val"] = value.ToString();
            if (should_add)
                dt.Rows.Add(row);
            if (should_validate(which))
                cache_value(which, primary_instrument_id, secondary_instrument_id, param_idx, value);
        }
        public void on_uint64_param(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ulong value)
        {
            if (app.InvokeRequired)
            {
                app.Invoke(new System.Action<ushort, CryptoUI.Protocol.ParamServerN.LevelE, uint, ulong, ulong, ushort, ulong>(on_uint64_param), new object[] { which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value });
                return;
            }
            if (!on_param_setup(which, level, CryptoUI.Protocol.ParamServerN.ParamTypeE.uint64_e, seq, primary_instrument_id, secondary_instrument_id, param_idx, out DataRow row, out bool should_add))
                return;
            row["Val"] = value.ToString();
            if (should_add)
                dt.Rows.Add(row);
            if (should_validate(which))
                cache_value(which, primary_instrument_id, secondary_instrument_id, param_idx, value);
        }
        public void on_int8_param(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, sbyte value)
        {
            if (app.InvokeRequired)
            {
                app.Invoke(new System.Action<ushort, CryptoUI.Protocol.ParamServerN.LevelE, uint, ulong, ulong, ushort, sbyte>(on_int8_param), new object[] { which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value });
                return;
            }
            if (!on_param_setup(which, level, CryptoUI.Protocol.ParamServerN.ParamTypeE.int8_e, seq, primary_instrument_id, secondary_instrument_id, param_idx, out DataRow row, out bool should_add))
                return;
            row["Val"] = value.ToString();
            if (should_add)
                dt.Rows.Add(row);
            if (should_validate(which))
                cache_value(which, primary_instrument_id, secondary_instrument_id, param_idx, value);
        }
        public void on_int16_param(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, short value)
        {
            if (app.InvokeRequired)
            {
                app.Invoke(new System.Action<ushort, CryptoUI.Protocol.ParamServerN.LevelE, uint, ulong, ulong, ushort, short>(on_int16_param), new object[] { which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value });
                return;
            }
            if (!on_param_setup(which, level, CryptoUI.Protocol.ParamServerN.ParamTypeE.int16_e, seq, primary_instrument_id, secondary_instrument_id, param_idx, out DataRow row, out bool should_add))
                return;
            row["Val"] = value.ToString();
            if (should_add)
                dt.Rows.Add(row);
            if (should_validate(which))
                cache_value(which, primary_instrument_id, secondary_instrument_id, param_idx, value);
        }
        public void on_int32_param(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, int value)
        {
            if (app.InvokeRequired)
            {
                app.Invoke(new System.Action<ushort, CryptoUI.Protocol.ParamServerN.LevelE, uint, ulong, ulong, ushort, int>(on_int32_param), new object[] { which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value });
                return;
            }
            if (!on_param_setup(which, level, CryptoUI.Protocol.ParamServerN.ParamTypeE.int32_e, seq, primary_instrument_id, secondary_instrument_id, param_idx, out DataRow row, out bool should_add))
                return;
            row["Val"] = value.ToString();
            if (should_add)
                dt.Rows.Add(row);
            if (should_validate(which))
                cache_value(which, primary_instrument_id, secondary_instrument_id, param_idx, value);
        }
        public void on_int64_param(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, long value)
        {
            if (app.InvokeRequired)
            {
                app.Invoke(new System.Action<ushort, CryptoUI.Protocol.ParamServerN.LevelE, uint, ulong, ulong, ushort, long>(on_int64_param), new object[] { which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value });
                return;
            }
            if (!on_param_setup(which, level, CryptoUI.Protocol.ParamServerN.ParamTypeE.int64_e, seq, primary_instrument_id, secondary_instrument_id, param_idx, out DataRow row, out bool should_add))
                return;
            row["Val"] = value.ToString();
            if (should_add)
                dt.Rows.Add(row);
            if (should_validate(which))
                cache_value(which, primary_instrument_id, secondary_instrument_id, param_idx, value);
        }
        public void on_time_series_date_double_param_inner(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ref CryptoUI.Protocol.ParamServerN.TimeSeriesDateDoubleParamT value)
        {
            if (!on_param_setup(which, level, CryptoUI.Protocol.ParamServerN.ParamTypeE.time_series_date_double_element, seq, primary_instrument_id, secondary_instrument_id, param_idx, out DataRow row, out bool should_add))
                return;
            row["Val"] = value.ToString();
            if (should_add)
                dt.Rows.Add(row);
        }
        public void on_time_series_datetime_double_param_inner(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ref CryptoUI.Protocol.ParamServerN.TimeSeriesDateTimeDoubleParamT value)
        {
            if (!on_param_setup(which, level, CryptoUI.Protocol.ParamServerN.ParamTypeE.time_series_datetime_double_element, seq, primary_instrument_id, secondary_instrument_id, param_idx, out DataRow row, out bool should_add))
                return;
            row["Val"] = value.ToString();
            if (should_add)
                dt.Rows.Add(row);
        }
        public void on_time_series_date_uint64_param_inner(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ref CryptoUI.Protocol.ParamServerN.TimeSeriesDateUint64ParamT value)
        {
            if (!on_param_setup(which, level, CryptoUI.Protocol.ParamServerN.ParamTypeE.time_series_date_uint64_element, seq, primary_instrument_id, secondary_instrument_id, param_idx, out DataRow row, out bool should_add))
                return;
            row["Val"] = value.ToString();
            if (should_add)
                dt.Rows.Add(row);
        }
        public void on_time_series_datetime_uint64_param_inner(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ref CryptoUI.Protocol.ParamServerN.TimeSeriesDateTimeUint64ParamT value)
        {
            if (!on_param_setup(which, level, CryptoUI.Protocol.ParamServerN.ParamTypeE.time_series_datetime_uint64_element, seq, primary_instrument_id, secondary_instrument_id, param_idx, out DataRow row, out bool should_add))
                return;
            row["Val"] = value.ToString();
            if (should_add)
                dt.Rows.Add(row);
        }
        public void on_time_series_date_int64_param_inner(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ref CryptoUI.Protocol.ParamServerN.TimeSeriesDateInt64ParamT value)
        {
            if (!on_param_setup(which, level, CryptoUI.Protocol.ParamServerN.ParamTypeE.time_series_date_int64_element, seq, primary_instrument_id, secondary_instrument_id, param_idx, out DataRow row, out bool should_add))
                return;
            row["Val"] = value.ToString();
            if (should_add)
                dt.Rows.Add(row);
        }
        public void on_time_series_datetime_int64_param_inner(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ref CryptoUI.Protocol.ParamServerN.TimeSeriesDateTimeInt64ParamT value)
        {
            if (!on_param_setup(which, level, CryptoUI.Protocol.ParamServerN.ParamTypeE.time_series_datetime_int64_element, seq, primary_instrument_id, secondary_instrument_id, param_idx, out DataRow row, out bool should_add))
                return;
            row["Val"] = value.ToString();
            if (should_add)
                dt.Rows.Add(row);
        }

        public void on_time_series_date_double_param(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ref CryptoUI.Protocol.ParamServerN.TimeSeriesDateDoubleParamT value)
        {
            if (app.InvokeRequired)
            {
                app.Invoke(new System.Action<ushort, CryptoUI.Protocol.ParamServerN.LevelE, uint, ulong, ulong, ushort, CryptoUI.Protocol.ParamServerN.TimeSeriesDateDoubleParamT>(on_time_series_date_double_param), new object[] { which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value });
                return;
            }
            on_time_series_date_double_param_inner(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, ref value);
        }
        public void on_time_series_datetime_double_param(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ref CryptoUI.Protocol.ParamServerN.TimeSeriesDateTimeDoubleParamT value)
        {
            if (app.InvokeRequired)
            {
                app.Invoke(new System.Action<ushort, CryptoUI.Protocol.ParamServerN.LevelE, uint, ulong, ulong, ushort, CryptoUI.Protocol.ParamServerN.TimeSeriesDateTimeDoubleParamT>(on_time_series_datetime_double_param), new object[] { which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value });
                return;
            }
            on_time_series_datetime_double_param_inner(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, ref value);
        }
        public void on_time_series_date_uint64_param(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ref CryptoUI.Protocol.ParamServerN.TimeSeriesDateUint64ParamT value)
        {
            if (app.InvokeRequired)
            {
                app.Invoke(new System.Action<ushort, CryptoUI.Protocol.ParamServerN.LevelE, uint, ulong, ulong, ushort, CryptoUI.Protocol.ParamServerN.TimeSeriesDateUint64ParamT>(on_time_series_date_uint64_param), new object[] { which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value });
                return;
            }
            on_time_series_date_uint64_param_inner(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, ref value);
        }
        public void on_time_series_datetime_uint64_param(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ref CryptoUI.Protocol.ParamServerN.TimeSeriesDateTimeUint64ParamT value)
        {
            if (app.InvokeRequired)
            {
                app.Invoke(new System.Action<ushort, CryptoUI.Protocol.ParamServerN.LevelE, uint, ulong, ulong, ushort, CryptoUI.Protocol.ParamServerN.TimeSeriesDateTimeUint64ParamT>(on_time_series_datetime_uint64_param), new object[] { which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value });
                return;
            }
            on_time_series_datetime_uint64_param_inner(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, ref value);
        }
        public void on_time_series_date_int64_param(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ref CryptoUI.Protocol.ParamServerN.TimeSeriesDateInt64ParamT value)
        {
            if (app.InvokeRequired)
            {
                app.Invoke(new System.Action<ushort, CryptoUI.Protocol.ParamServerN.LevelE, uint, ulong, ulong, ushort, CryptoUI.Protocol.ParamServerN.TimeSeriesDateInt64ParamT>(on_time_series_date_int64_param), new object[] { which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value });
                return;
            }
            on_time_series_date_int64_param_inner(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, ref value);
        }
        public void on_time_series_datetime_int64_param(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, ref CryptoUI.Protocol.ParamServerN.TimeSeriesDateTimeInt64ParamT value)
        {
            if (app.InvokeRequired)
            {
                app.Invoke(new System.Action<ushort, CryptoUI.Protocol.ParamServerN.LevelE, uint, ulong, ulong, ushort, CryptoUI.Protocol.ParamServerN.TimeSeriesDateTimeInt64ParamT>(on_time_series_datetime_int64_param), new object[] { which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, value });
                return;
            }
            on_time_series_datetime_int64_param_inner(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, ref value);
        }

        public void on_time_series_date_double_param(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, CryptoUI.Protocol.ParamServerN.TimeSeriesDateDoubleParamT value)
        {
            on_time_series_date_double_param_inner(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, ref value);
        }
        public void on_time_series_datetime_double_param(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, CryptoUI.Protocol.ParamServerN.TimeSeriesDateTimeDoubleParamT value)
        {
            on_time_series_datetime_double_param_inner(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, ref value);
        }
        public void on_time_series_date_uint64_param(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, CryptoUI.Protocol.ParamServerN.TimeSeriesDateUint64ParamT value)
        {
            on_time_series_date_uint64_param_inner(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, ref value);
        }
        public void on_time_series_datetime_uint64_param(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, CryptoUI.Protocol.ParamServerN.TimeSeriesDateTimeUint64ParamT value)
        {
            on_time_series_datetime_uint64_param_inner(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, ref value);
        }
        public void on_time_series_date_int64_param(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, CryptoUI.Protocol.ParamServerN.TimeSeriesDateInt64ParamT value)
        {
            on_time_series_date_int64_param_inner(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, ref value);
        }
        public void on_time_series_datetime_int64_param(ushort which, CryptoUI.Protocol.ParamServerN.LevelE level, uint seq, ulong primary_instrument_id, ulong secondary_instrument_id, ushort param_idx, CryptoUI.Protocol.ParamServerN.TimeSeriesDateTimeInt64ParamT value)
        {
            on_time_series_datetime_int64_param_inner(which, level, seq, primary_instrument_id, secondary_instrument_id, param_idx, ref value);
        }
        #endregion
    }
}

namespace CryptoUI
{
    public class ParamManagerHandle
    {
        public ParamManagerHandle(string name, string level, string type, string primary, string secondary, string index, string val, ushort which, Protocol.ParamServerN.LevelE levele, ulong primary_id, ulong secondary_id, Protocol.ParamServerN.ParamTypeE etype, ushort idx)
        {
            this.name = name;
            this.level = level;
            this.type = type;
            this.primary = primary;
            this.secondary = secondary;
            this.index = index;
            this.val = val;
            this.which = which;
            this.levele = levele;
            this.primary_id = primary_id;
            this.secondary_id = secondary_id;
            this.etype = etype;
            this.idx = idx;
        }
        public string name;
        public string level;
        public string type;
        public string primary;
        public string secondary;
        public string index;
        public string val;
        public ushort which;
        public Protocol.ParamServerN.LevelE levele;
        public ulong primary_id;
        public ulong secondary_id;
        public Protocol.ParamServerN.ParamTypeE etype;
        public ushort idx;
    }
    public partial class App
    {
        private CryptoUI.Panel.ParamManagement.ParamManagement paramManagement;
        private Dictionary<string, uint> paramEnumSet;
        private Dictionary<uint, string> paramEnumSet2;
        private DevExpress.XtraEditors.XtraOpenFileDialog paramManagementFileDialog;
        private DevExpress.XtraEditors.XtraOpenFileDialog paramManagementExportCSVFileDialog;
        private DevExpress.XtraEditors.XtraOpenFileDialog paramManagementExportPDFFileDialog;
        private DevExpress.Utils.ToolTipController appToolTipController;

        private unsafe void InitializeComponentParamManagement()
        {
            appToolTipController = new DevExpress.Utils.ToolTipController();
            this.paramEnumSet = new Dictionary<string, uint>();
            this.paramEnumSet2 = new Dictionary<uint, string>();
            #region param_enum initialization
            this.paramEnumSet.Add("max_super_cross_local_markets", 1);
            this.paramEnumSet.Add("max_follower_fair_move_bps_tick_to_tick", 2);
            this.paramEnumSet.Add("max_filtered_bps", 3);
            this.paramEnumSet.Add("max_follower_edge_bps", 4);
            this.paramEnumSet.Add("max_follower_edge_dollar", 5);
            this.paramEnumSet.Add("max_follower_mid_pnl", 6);
            this.paramEnumSet.Add("max_aggregate_mid_pnl", 7);
            this.paramEnumSet.Add("max_iso_trade_through_level", 8);
            this.paramEnumSet.Add("leader_cross_time_out_seconds", 9);
            this.paramEnumSet.Add("max_leader_premium_bps", 10);
            this.paramEnumSet.Add("max_leader_cross_markets", 11);
            this.paramEnumSet.Add("max_nbbo_cross", 12);
            this.paramEnumSet.Add("max_order_including_one_per_route", 13);
            this.paramEnumSet.Add("max_leader_side_edge_bps", 14);
            this.paramEnumSet.Add("max_unhedged_dollar_delta", 15);
            this.paramEnumSet.Add("min_follower_beta", 16);
            this.paramEnumSet.Add("min_follower_mid_pnl_strategy", 17);
            this.paramEnumSet.Add("min_follower_mid_pnl_symbol", 18);
            this.paramEnumSet.Add("min_follower_mid_pnl_symbol_violations", 19);
            this.paramEnumSet.Add("strategy_traded_shares_to_stop", 20);
            this.paramEnumSet.Add("disable_when_negative_bps", 21);
            this.paramEnumSet.Add("wait_seconsds_before_restart", 22);
            this.paramEnumSet.Add("follower_tracked_stale_seconds", 23);
            this.paramEnumSet.Add("follower_basket_tracked_stale_seconds", 24);
            this.paramEnumSet.Add("credit_expire_interval_seconds", 25);
            this.paramEnumSet.Add("credit_update_interval_ms", 26);
            this.paramEnumSet.Add("dark_total_take_order_limit_stategy", 27);
            this.paramEnumSet.Add("dark_take_throttle_seconds", 28);
            this.paramEnumSet.Add("dark_taker_enable", 29);
            this.paramEnumSet.Add("ignore_follower_size_larger_than_leader", 30);
            this.paramEnumSet.Add("max_taking_orders_per_host_per_symbol", 31);
            this.paramEnumSet.Add("taker_orders_limit_per_credit_interval", 32);
            this.paramEnumSet.Add("taker_order_limit_per_leader", 33);
            this.paramEnumSet.Add("opening_auction_seconds_since_midnight", 34);
            this.paramEnumSet.Add("closing_auction_seconds_since_midnight", 35);
            this.paramEnumSet.Add("auction_mode_duration_seconds_pre_auction", 36);
            this.paramEnumSet.Add("turn_on_hedger_after_auction_second", 37);
            this.paramEnumSet.Add("bps_multiplier_if_auction", 38);
            this.paramEnumSet.Add("bps_multiplier_if_no_auction", 39);
            this.paramEnumSet.Add("enable_auction", 40);
            this.paramEnumSet.Add("max_volume_shares", 41);
            this.paramEnumSet.Add("max_volume_fraction", 42);
            this.paramEnumSet.Add("num_orders_per_side_auction", 43);
            this.paramEnumSet.Add("credit_shares_per_exchange", 44);
            this.paramEnumSet.Add("max_orders_per_strategy_per_venue", 45);
            this.paramEnumSet.Add("distinct_fill_to_turn_off_interval_ms", 46);
            this.paramEnumSet.Add("number_of_distinct_fills", 47);
            this.paramEnumSet.Add("max_num_penny_back_per_second", 48);
            this.paramEnumSet.Add("dark_pool_gap_filler_ms", 49);
            this.paramEnumSet.Add("max_final_cxl_age_sec", 50);
            this.paramEnumSet.Add("max_additional_cxl_after_cxl_nak", 51);
            this.paramEnumSet.Add("max_opposite_sided_bps_edge_before_quoting", 52);
            this.paramEnumSet.Add("max_opposite_sided_dollars_edge_before_quoting", 53);
            this.paramEnumSet.Add("min_second_nak_throttle_timeout", 54);
            this.paramEnumSet.Add("max_second_nak_throttle_timeout", 55);
            this.paramEnumSet.Add("dark_pool_penalty_entering_requirement_count", 56);
            this.paramEnumSet.Add("dark_pool_penalty_exiting_requirement_count", 57);
            this.paramEnumSet.Add("dark_pool_penalty_entering_moving_window_seconds", 58);
            this.paramEnumSet.Add("dark_pool_penalty_window", 59);
            this.paramEnumSet.Add("quote_if_no_market", 60);
            this.paramEnumSet.Add("unsolicited_cancel_timeout_seconds", 61);
            this.paramEnumSet.Add("number_of_unsolicited_cancel_timeout_to_deactivate", 62);
            this.paramEnumSet.Add("quoter_trade_through_timeout_second", 63);
            this.paramEnumSet.Add("quoter_widen_on_trade_through", 64);
            this.paramEnumSet.Add("unit_size", 65);
            this.paramEnumSet.Add("bps_floor", 66);
            this.paramEnumSet.Add("bracket_bps", 67);
            this.paramEnumSet.Add("extra_bps_to_improve", 68);
            this.paramEnumSet.Add("min_qty_fraction_to_cxl_replace", 69);
            this.paramEnumSet.Add("max_bbo_edge_bps_before_quoting", 70);
            this.paramEnumSet.Add("max_match_nbbo_per_sec", 71);
            this.paramEnumSet.Add("max_match_bpq_when_nbbo_better_per_sec", 72);
            this.paramEnumSet.Add("num_order_per_side", 73);
            this.paramEnumSet.Add("max_order_per_side", 74);
            this.paramEnumSet.Add("max_top_improvement_per_sec", 75);
            this.paramEnumSet.Add("max_penny_back_per_sec", 76);
            this.paramEnumSet.Add("bps_mult", 77);
            this.paramEnumSet.Add("close_lean_bps", 78);
            this.paramEnumSet.Add("open_lean_bps", 79);
            this.paramEnumSet.Add("is_penny_back", 80);
            this.paramEnumSet.Add("is_penny_forward", 81);
            this.paramEnumSet.Add("bid_bps", 82);
            this.paramEnumSet.Add("bid_bps_alone", 83);
            this.paramEnumSet.Add("ask_bps", 84);
            this.paramEnumSet.Add("ask_bps_alone", 85);
            this.paramEnumSet.Add("bid_unit", 86);
            this.paramEnumSet.Add("ask_unit", 87);
            this.paramEnumSet.Add("lean_bps", 88);
            this.paramEnumSet.Add("size_to_lean", 89);
            this.paramEnumSet.Add("taker_stop_time", 90);
            this.paramEnumSet.Add("bps_multiplier_if_follower_market_move", 91);
            this.paramEnumSet.Add("bps_mutliplier_if_follower_basket_move", 92);
            this.paramEnumSet.Add("fraction_leader_delta_to_use", 93);
            this.paramEnumSet.Add("max_signal_age_ms", 94);
            this.paramEnumSet.Add("min_leader_size_increase_fraction_to_check", 95);
            this.paramEnumSet.Add("check_if_follower_basket_move", 96);
            this.paramEnumSet.Add("check_if_follower_price_move_inward", 97);
            this.paramEnumSet.Add("check_if_leader_price_move_inward", 98);
            this.paramEnumSet.Add("check_if_leader_price_move_outward", 99);
            this.paramEnumSet.Add("check_if_leader_size_decrease", 100);
            this.paramEnumSet.Add("check_if_leader_size_increase", 101);
            this.paramEnumSet.Add("taker_bid_bps", 102);
            this.paramEnumSet.Add("taker_ask_bps", 103);
            this.paramEnumSet.Add("take_size", 104);
            this.paramEnumSet.Add("beta", 105);
            this.paramEnumSet.Add("leader_tracked_stale_seconds", 106);
            this.paramEnumSet.Add("efp", 107);
            this.paramEnumSet.Add("leader_inav_stale_seconds", 108);
            this.paramEnumSet.Add("leader_md_stale_seconds", 109);
            this.paramEnumSet.Add("max_net_dollar_delta", 110);
            this.paramEnumSet.Add("max_net_dollar_delta_before_disable", 111);
            this.paramEnumSet.Add("leader_premium_publish_epsilon", 112);
            this.paramEnumSet.Add("min_leader_size_increase_fraction", 113);
            this.paramEnumSet.Add("check_if_leader_qty_increase", 114);

            foreach (var n in this.paramEnumSet)
            {
                this.paramEnumSet2.Add(n.Value, n.Key);
            }
            #endregion
            paramManagementFileDialog = new DevExpress.XtraEditors.XtraOpenFileDialog();
            paramManagementExportCSVFileDialog = new DevExpress.XtraEditors.XtraOpenFileDialog();
            paramManagementExportPDFFileDialog = new DevExpress.XtraEditors.XtraOpenFileDialog();
            this.paramManagementDefineButton.Click += ParamManagementDefineButton_Click;
            this.paramGridValue.View.CellValueChanged += View_CellValueChanged;
            this.paramManagementUploadButton.Click += ParamManagementUploadButton_Click;
            this.paramManagerGridView.PopupMenuShowing += ParamManagerGridView_PopupMenuShowing;
            this.paramManagerGridControl.MouseMove += ParamManagerGridControl_MouseMove;
            this.paramManagerGridControl.MouseLeave += ParamManagerGridControl_MouseLeave;
            this.paramManagement = new CryptoUI.Panel.ParamManagement.ParamManagement(this.paramManagerGridControl, this);
        }

        private void ParamManagerGridControl_MouseLeave(object sender, EventArgs e)
        {
            appToolTipController.HideHint();
        }

        private void ParamManagerGridControl_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            GridControl grid = sender as GridControl;
            if (grid == null) return;
            DevExpress.XtraGrid.Views.Base.BaseView view = grid.GetViewAt(e.Location);
            if (view == null) return;
            GridView gview = view as GridView;
            if (gview == null) return;
            // Retrieve information on the current View element.
            DevExpress.XtraGrid.Views.Base.ViewInfo.BaseHitInfo baseHI = view.CalcHitInfo(e.Location);
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo gridHI = baseHI as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo;
            if (gridHI == null) return;
            if (gridHI.InRowCell)
            {
                if (gridHI.Column.FieldName == "Val")
                {
                    string param_name = gview.GetRowCellValue(gridHI.RowHandle, gview.Columns["Name"]).ToString();
                    string param_primary_sym = gview.GetRowCellValue(gridHI.RowHandle, gview.Columns["Primary"]).ToString();
                    string param_secondary_sym = gview.GetRowCellValue(gridHI.RowHandle, gview.Columns["Secondary"]).ToString();
                    string param_idx_str = gview.GetRowCellValue(gridHI.RowHandle, gview.Columns["Index"]).ToString();
                    string param_val_str = gview.GetRowCellValue(gridHI.RowHandle, gview.Columns["Val"]).ToString();
                    uint param_enum = get_param_enum_from_name(param_name);
                    if (param_enum == uint.MaxValue)
                        return;
                    ulong primary_id = Services.InstrumentIdSymbolConfigService.Exists(param_primary_sym) ? Services.InstrumentIdSymbolConfigService.GetId(param_primary_sym) : ulong.MaxValue;
                    if (primary_id == ulong.MaxValue)
                        return;
                    primary_id = Services.UniqueInstrumentIdConfigService.DoesInstrumentIdExist(primary_id) ? Services.UniqueInstrumentIdConfigService.GetUniqueInstrumentId(primary_id) : ulong.MaxValue;
                    if (primary_id == ulong.MaxValue)
                        return;
                    ulong secondary_id = Services.InstrumentIdSymbolConfigService.Exists(param_secondary_sym) ? Services.InstrumentIdSymbolConfigService.GetId(param_secondary_sym) : ulong.MaxValue;
                    if (secondary_id == ulong.MaxValue)
                        return;
                    secondary_id = Services.UniqueInstrumentIdConfigService.DoesInstrumentIdExist(secondary_id) ? Services.UniqueInstrumentIdConfigService.GetUniqueInstrumentId(secondary_id) : ulong.MaxValue;
                    if (secondary_id == ulong.MaxValue)
                        return;
                    if (!ushort.TryParse(param_idx_str, out ushort idx))
                        return;
                    ushort param_idx = idx;
                    if (this.paramManagement.should_hover_over((ushort)param_enum))
                    {
                        string tooltip_str = this.paramManagement.get_hover_over_value((ushort)param_enum, primary_id, secondary_id, param_idx, param_val_str);
                        appToolTipController.ShowHint(tooltip_str, e.Location);
                        return;
                    }
                }
            }
        }

        public void OnParamSymbolExportPDFMenuClick(object sender, EventArgs e)
        {
            DevExpress.Utils.Menu.DXMenuItem item = sender as DevExpress.Utils.Menu.DXMenuItem;
            ParamManagerHandle info = item.Tag as ParamManagerHandle;
            paramManagementExportPDFFileDialog = new DevExpress.XtraEditors.XtraOpenFileDialog();
            paramManagementExportPDFFileDialog.Title = "Save PDF to Export";
            paramManagementExportPDFFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
            paramManagementExportPDFFileDialog.FilterIndex = 2;
            paramManagementExportPDFFileDialog.RestoreDirectory = true;
            paramManagementExportPDFFileDialog.Multiselect = false;
            paramManagementExportPDFFileDialog.AllowDragDrop = true;
            paramManagementExportPDFFileDialog.CheckFileExists = false;
            paramManagementExportPDFFileDialog.CheckPathExists = true;
            System.Windows.Forms.DialogResult res = paramManagementExportPDFFileDialog.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
                this.paramManagerGridView.ExportToPdf(paramManagementExportPDFFileDialog.FileName);
        }
        public void OnParamSymbolExportCSVMenuClick(object sender, EventArgs e)
        {
            DevExpress.Utils.Menu.DXMenuItem item = sender as DevExpress.Utils.Menu.DXMenuItem;
            ParamManagerHandle info = item.Tag as ParamManagerHandle;
            paramManagementExportCSVFileDialog = new DevExpress.XtraEditors.XtraOpenFileDialog();
            paramManagementExportCSVFileDialog.Title = "Save CSV to Export";
            paramManagementExportCSVFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            paramManagementExportCSVFileDialog.FilterIndex = 2;
            paramManagementExportCSVFileDialog.RestoreDirectory = true;
            paramManagementExportCSVFileDialog.Multiselect = false;
            paramManagementExportCSVFileDialog.AllowDragDrop = true;
            paramManagementExportCSVFileDialog.CheckFileExists = false;
            paramManagementExportCSVFileDialog.CheckPathExists = true;
            System.Windows.Forms.DialogResult res = paramManagementExportCSVFileDialog.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
                this.paramManagerGridView.ExportToCsv(paramManagementExportCSVFileDialog.FileName);
        }

        public void OnParamStatusMenuClick(object sender, EventArgs e)
        {
            DevExpress.Utils.Menu.DXMenuItem item = sender as DevExpress.Utils.Menu.DXMenuItem;
            ParamManagerHandle info = item.Tag as ParamManagerHandle;
            request_param_removal(info);
        }
        public void OnParamSymbolPurgeMenuClick(object sender, EventArgs e)
        {
            DevExpress.Utils.Menu.DXMenuItem item = sender as DevExpress.Utils.Menu.DXMenuItem;
            ParamManagerHandle info = item.Tag as ParamManagerHandle;
            foreach (ParamManagerHandle param in get_params_for_symbol(info.primary))
            {
                try
                {
                    request_param_removal(param);
                    Thread.Sleep(300);
                }
                catch (Exception) { }
            }
        }

        private List<ParamManagerHandle> get_params_for_symbol(string primary_symbol)
        {
            List<ParamManagerHandle> l = new List<ParamManagerHandle>();
            foreach (DataRow r in paramManagement.get_rows_by_primary(primary_symbol))
            {
                ushort which = (ushort)get_param_enum_from_name(r["Name"].ToString());
                if (which == ushort.MaxValue)
                    continue;
                Protocol.ParamServerN.LevelE level = get_param_level_from_text(r["Level"].ToString());
                if (level == Protocol.ParamServerN.LevelE.invalid)
                    continue;
                ulong primary_id = Services.InstrumentIdSymbolConfigService.Exists(r["Primary"].ToString()) ? Services.InstrumentIdSymbolConfigService.GetId(r["Primary"].ToString()) : ulong.MaxValue;
                if (primary_id == ulong.MaxValue)
                    continue;
                primary_id = Services.UniqueInstrumentIdConfigService.DoesInstrumentIdExist(primary_id) ? Services.UniqueInstrumentIdConfigService.GetUniqueInstrumentId(primary_id) : ulong.MaxValue;
                if (primary_id == ulong.MaxValue)
                    continue;
                ulong secondary_id = Services.InstrumentIdSymbolConfigService.Exists(r["Secondary"].ToString()) ? Services.InstrumentIdSymbolConfigService.GetId(r["Secondary"].ToString()) : ulong.MaxValue;
                if (secondary_id == ulong.MaxValue)
                    continue;
                secondary_id = Services.UniqueInstrumentIdConfigService.DoesInstrumentIdExist(secondary_id) ? Services.UniqueInstrumentIdConfigService.GetUniqueInstrumentId(secondary_id) : ulong.MaxValue;
                if (secondary_id == ulong.MaxValue)
                    continue;
                Protocol.ParamServerN.ParamTypeE param_type = get_param_type_from_text(r["Type"].ToString());
                if (param_type == Protocol.ParamServerN.ParamTypeE.invalid)
                    continue;
                if (!ushort.TryParse(r["Index"].ToString(), out ushort idx))
                    continue;
                ushort param_idx = idx;
                l.Add(new ParamManagerHandle(r["Name"].ToString(), r["Level"].ToString(), r["Type"].ToString(), r["Primary"].ToString(), r["Secondary"].ToString(), r["Index"].ToString(), r["Val"].ToString(), which, level, primary_id, secondary_id, param_type, idx));
            }
            return l;
        }

        public unsafe void request_param_removal(ParamManagerHandle info)
        {
            byte[] buf = new byte[65536];
            Protocol.ParamServerN.ParamChangeMsgT p = new Protocol.ParamServerN.ParamChangeMsgT();
            fixed (byte* pbuf = buf)
            {
                p.construct(pbuf, 65536);
                Protocol.ParamServerN.ParamChangeT pc = p.add_param_change_t(pbuf, 65536);
                pc.Flag = Protocol.ParamServerN.ParamFlagE.is_remove;
                pc.ParamEnum = info.which;
                pc.Level = info.levele;
                pc.ParamType = info.etype;
                pc.PrimaryInstrumentId = info.primary_id;
                pc.SecondaryInstrumentId = info.secondary_id;
                pc.ParamIdx = info.idx;
                pc.IsRemoval = true;
                switch (pc.ParamType)
                {
                    case Protocol.ParamServerN.ParamTypeE.boolean:
                        pc.add_bool_param_t();
                        break;
                    case Protocol.ParamServerN.ParamTypeE.char_e:
                        pc.add_char_param_t();
                        break;
                    case Protocol.ParamServerN.ParamTypeE.double_e:
                        pc.add_double_param_t();
                        break;
                    case Protocol.ParamServerN.ParamTypeE.float_e:
                        pc.add_float_param_t();
                        break;
                    case Protocol.ParamServerN.ParamTypeE.int16_e:
                        pc.add_int16_param_t();
                        break;
                    case Protocol.ParamServerN.ParamTypeE.int32_e:
                        pc.add_int32_param_t();
                        break;
                    case Protocol.ParamServerN.ParamTypeE.int64_e:
                        pc.add_int64_param_t();
                        break;
                    case Protocol.ParamServerN.ParamTypeE.int8_e:
                        pc.add_int8_param_t();
                        break;
                    case Protocol.ParamServerN.ParamTypeE.uint16_e:
                        pc.add_uint16_param_t();
                        break;
                    case Protocol.ParamServerN.ParamTypeE.uint32_e:
                        pc.add_uint32_param_t();
                        break;
                    case Protocol.ParamServerN.ParamTypeE.uint64_e:
                        pc.add_uint64_param_t();
                        break;
                    case Protocol.ParamServerN.ParamTypeE.uint8_e:
                        pc.add_uint8_param_t();
                        break;
                    case Protocol.ParamServerN.ParamTypeE.time_series_datetime_double_element:
                        pc.add_time_series_datetime_double_param_t();
                        break;
                    case Protocol.ParamServerN.ParamTypeE.time_series_datetime_int64_element:
                        pc.add_time_series_datetime_int64_param_t();
                        break;
                    case Protocol.ParamServerN.ParamTypeE.time_series_datetime_uint64_element:
                        pc.add_time_series_datetime_uint64_param_t();
                        break;
                    case Protocol.ParamServerN.ParamTypeE.time_series_date_double_element:
                        pc.add_time_series_date_double_param_t();
                        break;
                    case Protocol.ParamServerN.ParamTypeE.time_series_date_int64_element:
                        pc.add_time_series_date_int64_param_t();
                        break;
                    case Protocol.ParamServerN.ParamTypeE.time_series_date_uint64_element:
                        pc.add_time_series_date_uint64_param_t();
                        break;
                    default:
                        break;
                }
            }
            this.paramManagement.update(p);
        }

        private void ParamManagerGridView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                int rowHandle = e.HitInfo.RowHandle;
                int j = paramManagerGridView.GetDataSourceRowIndex(e.HitInfo.RowHandle);
                DataRow r = paramManagerGridView.GetDataRow(e.HitInfo.RowHandle);
                e.Menu.Enabled = true;
                e.Menu.Items.Clear();
                ushort which = (ushort)get_param_enum_from_name(r["Name"].ToString());
                if (which == ushort.MaxValue)
                    return;
                Protocol.ParamServerN.LevelE level = get_param_level_from_text(r["Level"].ToString());
                if (level == Protocol.ParamServerN.LevelE.invalid)
                    return;
                ulong primary_id = Services.InstrumentIdSymbolConfigService.Exists(r["Primary"].ToString()) ? Services.InstrumentIdSymbolConfigService.GetId(r["Primary"].ToString()) : ulong.MaxValue;
                if (primary_id == ulong.MaxValue)
                    return;
                primary_id = Services.UniqueInstrumentIdConfigService.DoesInstrumentIdExist(primary_id) ? Services.UniqueInstrumentIdConfigService.GetUniqueInstrumentId(primary_id) : ulong.MaxValue;
                if (primary_id == ulong.MaxValue)
                    return;
                ulong secondary_id = Services.InstrumentIdSymbolConfigService.Exists(r["Secondary"].ToString()) ? Services.InstrumentIdSymbolConfigService.GetId(r["Secondary"].ToString()) : ulong.MaxValue;
                if (secondary_id == ulong.MaxValue)
                    return;
                secondary_id = Services.UniqueInstrumentIdConfigService.DoesInstrumentIdExist(secondary_id) ? Services.UniqueInstrumentIdConfigService.GetUniqueInstrumentId(secondary_id) : ulong.MaxValue;
                if (secondary_id == ulong.MaxValue)
                    return;
                Protocol.ParamServerN.ParamTypeE param_type = get_param_type_from_text(r["Type"].ToString());
                if (param_type == Protocol.ParamServerN.ParamTypeE.invalid)
                    return;
                if (!ushort.TryParse(r["Index"].ToString(), out ushort idx))
                    return;
                ushort param_idx = idx;
                DevExpress.Utils.Menu.DXMenuItem remove_button_elm = new DevExpress.Utils.Menu.DXMenuItem("Remove Param", new EventHandler(OnParamStatusMenuClick));
                remove_button_elm.Tag = new ParamManagerHandle(r["Name"].ToString(), r["Level"].ToString(), r["Type"].ToString(), r["Primary"].ToString(), r["Secondary"].ToString(), r["Index"].ToString(), r["Val"].ToString(), which, level, primary_id, secondary_id, param_type, param_idx);
                e.Menu.Items.Add(remove_button_elm);
                DevExpress.Utils.Menu.DXMenuItem purge_button_elm = new DevExpress.Utils.Menu.DXMenuItem("Purge Symbol Params", new EventHandler(OnParamSymbolPurgeMenuClick));
                purge_button_elm.Tag = new ParamManagerHandle(r["Name"].ToString(), r["Level"].ToString(), r["Type"].ToString(), r["Primary"].ToString(), r["Secondary"].ToString(), r["Index"].ToString(), r["Val"].ToString(), which, level, primary_id, secondary_id, param_type, param_idx);
                e.Menu.Items.Add(purge_button_elm);
                DevExpress.Utils.Menu.DXSubMenuItem exportSubMenu = new DevExpress.Utils.Menu.DXSubMenuItem("Export");
                DevExpress.Utils.Menu.DXMenuItem export_csv_button_elm = new DevExpress.Utils.Menu.DXMenuItem("CSV Symbol Params", new EventHandler(OnParamSymbolExportCSVMenuClick));
                export_csv_button_elm.Tag = new ParamManagerHandle(r["Name"].ToString(), r["Level"].ToString(), r["Type"].ToString(), r["Primary"].ToString(), r["Secondary"].ToString(), r["Index"].ToString(), r["Val"].ToString(), which, level, primary_id, secondary_id, param_type, param_idx);
                DevExpress.Utils.Menu.DXMenuItem export_pdf_button_elm = new DevExpress.Utils.Menu.DXMenuItem("PDF Symbol Params", new EventHandler(OnParamSymbolExportPDFMenuClick));
                export_pdf_button_elm.Tag = new ParamManagerHandle(r["Name"].ToString(), r["Level"].ToString(), r["Type"].ToString(), r["Primary"].ToString(), r["Secondary"].ToString(), r["Index"].ToString(), r["Val"].ToString(), which, level, primary_id, secondary_id, param_type, param_idx);
                exportSubMenu.Items.Add(export_csv_button_elm);
                exportSubMenu.Items.Add(export_pdf_button_elm);
                e.Menu.Items.Add(exportSubMenu);
            }
        }

        private unsafe void ParamManagementUploadButton_Click(object sender, EventArgs e)
        {
            paramManagementFileDialog.Title = "Pick Parameter Mass Action CSV to Apply";
            paramManagementFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            paramManagementFileDialog.FilterIndex = 2;
            paramManagementFileDialog.RestoreDirectory = true;
            paramManagementFileDialog.Multiselect = false;
            paramManagementFileDialog.AllowDragDrop = true;
            paramManagementFileDialog.CheckFileExists = true;
            paramManagementFileDialog.CheckPathExists = true;
            System.Windows.Forms.DialogResult res = paramManagementFileDialog.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                bool isFirst = true;
                using (System.IO.StreamReader reader = new System.IO.StreamReader(paramManagementFileDialog.FileName))
                {
                    while (!reader.EndOfStream)
                    {
                        if (isFirst)
                        {
                            isFirst = false;
                            continue;
                        }
                        string line = reader.ReadLine();
                        string[] values = line.Split(',');
                        byte[] buf = new byte[65536];
                        Protocol.ParamServerN.ParamChangeMsgT p = new Protocol.ParamServerN.ParamChangeMsgT();
                        fixed (byte* pbuf = buf)
                        {
                            p.construct(pbuf, 65536);
                            Protocol.ParamServerN.ParamChangeT pc = p.add_param_change_t(pbuf, 65536);
                            pc.Flag = Protocol.ParamServerN.ParamFlagE.insert;
                            pc.ParamEnum = (ushort)get_param_enum_from_name(values[0]);
                            if (pc.ParamEnum == ushort.MaxValue)
                            {
                                Network.Logger.Log(Network.Logger.Level.error, $"Failed to upload line: '{line}' unrecognized param");
                                continue;
                            }
                            pc.Level = get_param_level_from_text(values[1]);
                            if (pc.Level == Protocol.ParamServerN.LevelE.invalid)
                            {
                                Network.Logger.Log(Network.Logger.Level.error, $"Failed to upload line: '{line}' unrecognized level");
                                continue;
                            }
                            pc.ParamType = get_param_type_from_text(values[2]);
                            if (pc.ParamType == Protocol.ParamServerN.ParamTypeE.invalid)
                            {
                                Network.Logger.Log(Network.Logger.Level.error, $"Failed to upload line: '{line}' unrecognized type");
                                continue;
                            }
                            pc.PrimaryInstrumentId = Services.InstrumentIdSymbolConfigService.Exists(values[3]) ? Services.InstrumentIdSymbolConfigService.GetId(values[3]) : ulong.MaxValue;
                            if (pc.PrimaryInstrumentId == ulong.MaxValue)
                            {
                                Network.Logger.Log(Network.Logger.Level.error, $"Failed to upload line: '{line}' unrecognized primary instrument");
                                continue;
                            }
                            pc.PrimaryInstrumentId = Services.UniqueInstrumentIdConfigService.DoesInstrumentIdExist(pc.PrimaryInstrumentId) ? Services.UniqueInstrumentIdConfigService.GetUniqueInstrumentId(pc.PrimaryInstrumentId) : ulong.MaxValue;
                            if (pc.PrimaryInstrumentId == ulong.MaxValue)
                            {
                                Network.Logger.Log(Network.Logger.Level.error, $"Failed to upload line: '{line}' missing UID for primary instrument[{pc.PrimaryInstrumentId}]");
                                continue;
                            }
                            pc.SecondaryInstrumentId = Services.InstrumentIdSymbolConfigService.Exists(values[4]) ? Services.InstrumentIdSymbolConfigService.GetId(values[4]) : ulong.MaxValue;
                            if (pc.SecondaryInstrumentId == ulong.MaxValue)
                            {
                                Network.Logger.Log(Network.Logger.Level.error, $"Failed to upload line: '{line}' unrecognized secondary instrument");
                                continue;
                            }
                            pc.SecondaryInstrumentId = Services.UniqueInstrumentIdConfigService.DoesInstrumentIdExist(pc.SecondaryInstrumentId) ? Services.UniqueInstrumentIdConfigService.GetUniqueInstrumentId(pc.SecondaryInstrumentId) : ulong.MaxValue;
                            if (pc.SecondaryInstrumentId == ulong.MaxValue)
                            {
                                Network.Logger.Log(Network.Logger.Level.error, $"Failed to upload line: '{line}' missing UID for secondary instrument[{pc.SecondaryInstrumentId}]");
                                continue;
                            }
                            if (!ushort.TryParse(values[5], out ushort idx))
                            {
                                Network.Logger.Log(Network.Logger.Level.error, $"Failed to upload line: '{line}' unrecognized index");
                                continue;
                            }
                            pc.ParamIdx = idx;
                            //bool is_change_existing = paramManagement.exists(pc.ParamEnum, pc.Level, pc.ParamType, pc.PrimaryInstrumentId, pc.SecondaryInstrumentId, pc.ParamIdx);
                            pc.Flag = Protocol.ParamServerN.ParamFlagE.modify;
                            string val = values[6].Trim();
                            switch (pc.ParamType)
                            {
                                case Protocol.ParamServerN.ParamTypeE.boolean:
                                    {
                                        if (val.ToLower() == "true")
                                        {
                                            Protocol.ParamServerN.BoolParamT* b = pc.add_bool_param_t(pbuf, 65536);
                                            b->value = true;
                                        }
                                        else if (val.ToLower() == "false")
                                        {
                                            Protocol.ParamServerN.BoolParamT* b = pc.add_bool_param_t(pbuf, 65536);
                                            b->value = false;
                                        }
                                        else
                                            continue;
                                    }
                                    break;
                                case Protocol.ParamServerN.ParamTypeE.char_e:
                                    {
                                        if (val.Length == 1)
                                        {
                                            Protocol.ParamServerN.CharParamT* b = pc.add_char_param_t(pbuf, 65536);
                                            b->value = val[0];
                                        }
                                        else
                                            continue;
                                    }
                                    break;
                                case Protocol.ParamServerN.ParamTypeE.double_e:
                                    {
                                        if (double.TryParse(val, out double d))
                                        {
                                            Protocol.ParamServerN.DoubleParamT* b = pc.add_double_param_t(pbuf, 65536);
                                            b->value = d;
                                        }
                                        else
                                            continue;
                                    }
                                    break;
                                case Protocol.ParamServerN.ParamTypeE.float_e:
                                    {
                                        if (float.TryParse(val, out float d))
                                        {
                                            Protocol.ParamServerN.FloatParamT* b = pc.add_float_param_t(pbuf, 65536);
                                            b->value = d;
                                        }
                                        else
                                            continue;
                                    }
                                    break;
                                case Protocol.ParamServerN.ParamTypeE.int8_e:
                                    {
                                        if (sbyte.TryParse(val, out sbyte d))
                                        {
                                            Protocol.ParamServerN.Int8ParamT* b = pc.add_int8_param_t(pbuf, 65536);
                                            b->value = d;
                                        }
                                        else
                                            continue;
                                    }
                                    break;
                                case Protocol.ParamServerN.ParamTypeE.int16_e:
                                    {
                                        if (short.TryParse(val, out short d))
                                        {
                                            Protocol.ParamServerN.Int16ParamT* b = pc.add_int16_param_t(pbuf, 65536);
                                            b->value = d;
                                        }
                                        else
                                            continue;
                                    }
                                    break;
                                case Protocol.ParamServerN.ParamTypeE.int32_e:
                                    {
                                        if (int.TryParse(val, out int d))
                                        {
                                            Protocol.ParamServerN.Int32ParamT* b = pc.add_int32_param_t(pbuf, 65536);
                                            b->value = d;
                                        }
                                        else
                                            continue;
                                    }
                                    break;
                                case Protocol.ParamServerN.ParamTypeE.int64_e:
                                    {
                                        if (long.TryParse(val, out long d))
                                        {
                                            Protocol.ParamServerN.Int64ParamT* b = pc.add_int64_param_t(pbuf, 65536);
                                            b->value = d;
                                        }
                                        else
                                            continue;
                                    }
                                    break;
                                case Protocol.ParamServerN.ParamTypeE.uint8_e:
                                    {
                                        if (byte.TryParse(val, out byte d))
                                        {
                                            Protocol.ParamServerN.Uint8ParamT* b = pc.add_uint8_param_t(pbuf, 65536);
                                            b->value = d;
                                        }
                                        else
                                            continue;
                                    }
                                    break;
                                case Protocol.ParamServerN.ParamTypeE.uint16_e:
                                    {
                                        if (ushort.TryParse(val, out ushort d))
                                        {
                                            Protocol.ParamServerN.Uint16ParamT* b = pc.add_uint16_param_t(pbuf, 65536);
                                            b->value = d;
                                        }
                                        else
                                            continue;
                                    }
                                    break;
                                case Protocol.ParamServerN.ParamTypeE.uint32_e:
                                    {
                                        if (uint.TryParse(val, out uint d))
                                        {
                                            Protocol.ParamServerN.Uint32ParamT* b = pc.add_uint32_param_t(pbuf, 65536);
                                            b->value = d;
                                        }
                                        else
                                            continue;
                                    }
                                    break;
                                case Protocol.ParamServerN.ParamTypeE.uint64_e:
                                    {
                                        if (ulong.TryParse(val, out ulong d))
                                        {
                                            Protocol.ParamServerN.Uint64ParamT* b = pc.add_uint64_param_t(pbuf, 65536);
                                            b->value = d;
                                        }
                                        else
                                            continue;
                                    }
                                    break;
                                case Protocol.ParamServerN.ParamTypeE.time_series_datetime_double_element:
                                    {
                                        if (ulong.TryParse(val, out ulong d) && double.TryParse(val, out double d1))
                                        {
                                            Protocol.ParamServerN.TimeSeriesDateTimeDoubleParamT* b = pc.add_time_series_datetime_double_param_t(pbuf, 65536);
                                            b->datetime = d;
                                            b->value = d1;
                                        }
                                        else
                                            continue;
                                    }
                                    break;
                                case Protocol.ParamServerN.ParamTypeE.time_series_date_double_element:
                                    {
                                        if (uint.TryParse(val, out uint d) && double.TryParse(val, out double d1))
                                        {
                                            Protocol.ParamServerN.TimeSeriesDateDoubleParamT* b = pc.add_time_series_date_double_param_t(pbuf, 65536);
                                            b->date = d;
                                            b->value = d1;
                                        }
                                        else
                                            continue;
                                    }
                                    break;
                                case Protocol.ParamServerN.ParamTypeE.time_series_datetime_int64_element:
                                    {
                                        if (ulong.TryParse(val, out ulong d) && long.TryParse(val, out long d1))
                                        {
                                            Protocol.ParamServerN.TimeSeriesDateTimeInt64ParamT* b = pc.add_time_series_datetime_int64_param_t(pbuf, 65536);
                                            b->datetime = d;
                                            b->value = d1;
                                        }
                                        else
                                            continue;
                                    }
                                    break;
                                case Protocol.ParamServerN.ParamTypeE.time_series_date_int64_element:
                                    {
                                        if (uint.TryParse(val, out uint d) && long.TryParse(val, out long d1))
                                        {
                                            Protocol.ParamServerN.TimeSeriesDateInt64ParamT* b = pc.add_time_series_date_int64_param_t(pbuf, 65536);
                                            b->date = d;
                                            b->value = d1;
                                        }
                                        else
                                            continue;
                                    }
                                    break;
                                case Protocol.ParamServerN.ParamTypeE.time_series_datetime_uint64_element:
                                    {
                                        if (ulong.TryParse(val, out ulong d) && ulong.TryParse(val, out ulong d1))
                                        {
                                            Protocol.ParamServerN.TimeSeriesDateTimeUint64ParamT* b = pc.add_time_series_datetime_uint64_param_t(pbuf, 65536);
                                            b->datetime = d;
                                            b->value = d1;
                                        }
                                        else
                                            continue;
                                    }
                                    break;
                                case Protocol.ParamServerN.ParamTypeE.time_series_date_uint64_element:
                                    {
                                        if (uint.TryParse(val, out uint d) && ulong.TryParse(val, out ulong d1))
                                        {
                                            Protocol.ParamServerN.TimeSeriesDateUint64ParamT* b = pc.add_time_series_date_uint64_param_t(pbuf, 65536);
                                            b->date = d;
                                            b->value = d1;
                                        }
                                        else
                                            continue;
                                    }
                                    break;
                                default:
                                    continue;
                            }
                            CryptoUI.Panel.ParamManagement.ParamStringsT ps = new CryptoUI.Panel.ParamManagement.ParamStringsT();
                            ps.Name = values[0];
                            ps.Level = values[1];
                            ps.Type = values[2];
                            ps.PriKey = values[3];
                            ps.SecKey = values[4];
                            ps.Idx = values[5];
                            ps.Value = val;
                            try
                            {
                                this.paramManagement.add_new(ps, p);
                                Thread.Sleep(300);
                            }
                            catch (Exception ex)
                            {
                                Network.Logger.Log(Network.Logger.Level.info, "Param upload error for " + ps.Name + ": " + ex.ToString());
                            }
                        }
                    }
                }
            }
        }



        public unsafe bool request_param_change(ushort param_enum, Protocol.ParamServerN.ParamTypeE param_type, string tprimary, string tsecondary, string val)
        {
            byte[] buf = new byte[65536];
            Protocol.ParamServerN.ParamChangeMsgT p = new Protocol.ParamServerN.ParamChangeMsgT();
            fixed (byte* pbuf = buf)
            {
                p.construct(pbuf, 65536);
                Protocol.ParamServerN.ParamChangeT pc = p.add_param_change_t(pbuf, 65536);
                pc.Flag = Protocol.ParamServerN.ParamFlagE.modify;
                pc.ParamEnum = param_enum;
                pc.Level = Protocol.ParamServerN.LevelE.instrument;
                pc.ParamType = param_type;
                pc.PrimaryInstrumentId = Services.InstrumentIdSymbolConfigService.Exists(tprimary) ? Services.InstrumentIdSymbolConfigService.GetId(tprimary) : ulong.MaxValue;
                if (pc.PrimaryInstrumentId == ulong.MaxValue)
                    return false;
                pc.PrimaryInstrumentId = Services.UniqueInstrumentIdConfigService.DoesInstrumentIdExist(pc.PrimaryInstrumentId) ? Services.UniqueInstrumentIdConfigService.GetUniqueInstrumentId(pc.PrimaryInstrumentId) : ulong.MaxValue;
                if (pc.PrimaryInstrumentId == ulong.MaxValue)
                    return false;
                pc.SecondaryInstrumentId = Services.InstrumentIdSymbolConfigService.Exists(tsecondary) ? Services.InstrumentIdSymbolConfigService.GetId(tsecondary) : ulong.MaxValue;
                if (pc.SecondaryInstrumentId == ulong.MaxValue)
                    return false;
                pc.SecondaryInstrumentId = Services.UniqueInstrumentIdConfigService.DoesInstrumentIdExist(pc.SecondaryInstrumentId) ? Services.UniqueInstrumentIdConfigService.GetUniqueInstrumentId(pc.SecondaryInstrumentId) : ulong.MaxValue;
                if (pc.SecondaryInstrumentId == ulong.MaxValue)
                    return false;
                //if (Services.FuturesChainConfigService.ExistsByFutureUID(pc.SecondaryInstrumentId))
                //    pc.SecondaryInstrumentId = Services.FuturesChainConfigService.GetChainUIDFromFutureUID(pc.SecondaryInstrumentId);
                pc.ParamIdx = 0;
                switch (pc.ParamType)
                {
                    case Protocol.ParamServerN.ParamTypeE.boolean:
                        {
                            if (val.ToLower() == "true")
                            {
                                Protocol.ParamServerN.BoolParamT* b = pc.add_bool_param_t(pbuf, 65536);
                                b->value = true;
                            }
                            else if (val.ToLower() == "false")
                            {
                                Protocol.ParamServerN.BoolParamT* b = pc.add_bool_param_t(pbuf, 65536);
                                b->value = false;
                            }
                            else
                                return false;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.char_e:
                        {
                            if (val.Length == 1)
                            {
                                Protocol.ParamServerN.CharParamT* b = pc.add_char_param_t(pbuf, 65536);
                                b->value = this.paramManagementValueBox.Text[0];
                            }
                            else
                                return false;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.double_e:
                        {
                            if (double.TryParse(val, out double d))
                            {
                                Protocol.ParamServerN.DoubleParamT* b = pc.add_double_param_t(pbuf, 65536);
                                b->value = d;
                            }
                            else
                                return false;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.float_e:
                        {
                            if (float.TryParse(val, out float d))
                            {
                                Protocol.ParamServerN.FloatParamT* b = pc.add_float_param_t(pbuf, 65536);
                                b->value = d;
                            }
                            else
                                return false;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.int8_e:
                        {
                            if (sbyte.TryParse(val, out sbyte d))
                            {
                                Protocol.ParamServerN.Int8ParamT* b = pc.add_int8_param_t(pbuf, 65536);
                                b->value = d;
                            }
                            else
                                return false;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.int16_e:
                        {
                            if (short.TryParse(val, out short d))
                            {
                                Protocol.ParamServerN.Int16ParamT* b = pc.add_int16_param_t(pbuf, 65536);
                                b->value = d;
                            }
                            else
                                return false;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.int32_e:
                        {
                            if (int.TryParse(val, out int d))
                            {
                                Protocol.ParamServerN.Int32ParamT* b = pc.add_int32_param_t(pbuf, 65536);
                                b->value = d;
                            }
                            else
                                return false;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.int64_e:
                        {
                            if (long.TryParse(val, out long d))
                            {
                                Protocol.ParamServerN.Int64ParamT* b = pc.add_int64_param_t(pbuf, 65536);
                                b->value = d;
                            }
                            else
                                return false;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.uint8_e:
                        {
                            if (byte.TryParse(val, out byte d))
                            {
                                Protocol.ParamServerN.Uint8ParamT* b = pc.add_uint8_param_t(pbuf, 65536);
                                b->value = d;
                            }
                            else
                                return false;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.uint16_e:
                        {
                            if (ushort.TryParse(val, out ushort d))
                            {
                                Protocol.ParamServerN.Uint16ParamT* b = pc.add_uint16_param_t(pbuf, 65536);
                                b->value = d;
                            }
                            else
                                return false;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.uint32_e:
                        {
                            if (uint.TryParse(val, out uint d))
                            {
                                Protocol.ParamServerN.Uint32ParamT* b = pc.add_uint32_param_t(pbuf, 65536);
                                b->value = d;
                            }
                            else
                                return false;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.uint64_e:
                        {
                            if (ulong.TryParse(val, out ulong d))
                            {
                                Protocol.ParamServerN.Uint64ParamT* b = pc.add_uint64_param_t(pbuf, 65536);
                                b->value = d;
                            }
                            else
                                return false;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.time_series_datetime_double_element:
                        {
                            if (ulong.TryParse(val, out ulong d) && double.TryParse(val, out double d1))
                            {
                                Protocol.ParamServerN.TimeSeriesDateTimeDoubleParamT* b = pc.add_time_series_datetime_double_param_t(pbuf, 65536);
                                b->datetime = d;
                                b->value = d1;
                            }
                            else
                                return false;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.time_series_date_double_element:
                        {
                            if (uint.TryParse(val, out uint d) && double.TryParse(val, out double d1))
                            {
                                Protocol.ParamServerN.TimeSeriesDateDoubleParamT* b = pc.add_time_series_date_double_param_t(pbuf, 65536);
                                b->date = d;
                                b->value = d1;
                            }
                            else
                                return false;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.time_series_datetime_int64_element:
                        {
                            if (ulong.TryParse(val, out ulong d) && long.TryParse(val, out long d1))
                            {
                                Protocol.ParamServerN.TimeSeriesDateTimeInt64ParamT* b = pc.add_time_series_datetime_int64_param_t(pbuf, 65536);
                                b->datetime = d;
                                b->value = d1;
                            }
                            else
                                return false;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.time_series_date_int64_element:
                        {
                            if (uint.TryParse(val, out uint d) && long.TryParse(val, out long d1))
                            {
                                Protocol.ParamServerN.TimeSeriesDateInt64ParamT* b = pc.add_time_series_date_int64_param_t(pbuf, 65536);
                                b->date = d;
                                b->value = d1;
                            }
                            else
                                return false;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.time_series_datetime_uint64_element:
                        {
                            if (ulong.TryParse(val, out ulong d) && ulong.TryParse(val, out ulong d1))
                            {
                                Protocol.ParamServerN.TimeSeriesDateTimeUint64ParamT* b = pc.add_time_series_datetime_uint64_param_t(pbuf, 65536);
                                b->datetime = d;
                                b->value = d1;
                            }
                            else
                                return false;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.time_series_date_uint64_element:
                        {
                            if (uint.TryParse(val, out uint d) && ulong.TryParse(val, out ulong d1))
                            {
                                Protocol.ParamServerN.TimeSeriesDateUint64ParamT* b = pc.add_time_series_date_uint64_param_t(pbuf, 65536);
                                b->date = d;
                                b->value = d1;
                            }
                            else
                                return false;
                        }
                        break;
                    default:
                        return false;
                }
                return this.paramManagement.update(p);
            }
        }
        private unsafe void View_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.Column.Caption != "Value") return;
            string val = e.Value.ToString();
            string name = view.GetRowCellValue(e.RowHandle, view.Columns["Name"]).ToString();
            string level = view.GetRowCellValue(e.RowHandle, view.Columns["Level"]).ToString();
            string ttype = view.GetRowCellValue(e.RowHandle, view.Columns["Type"]).ToString();
            string tprimary = view.GetRowCellValue(e.RowHandle, view.Columns["Primary"]).ToString();
            string tsecondary = view.GetRowCellValue(e.RowHandle, view.Columns["Secondary"]).ToString();
            string tidx = view.GetRowCellValue(e.RowHandle, view.Columns["Index"]).ToString();
            byte[] buf = new byte[65536];
            Protocol.ParamServerN.ParamChangeMsgT p = new Protocol.ParamServerN.ParamChangeMsgT();
            fixed (byte* pbuf = buf)
            {
                p.construct(pbuf, 65536);
                Protocol.ParamServerN.ParamChangeT pc = p.add_param_change_t(pbuf, 65536);
                pc.Flag = Protocol.ParamServerN.ParamFlagE.modify;
                pc.ParamEnum = (ushort)get_param_enum_from_name(name);
                if (pc.ParamEnum == ushort.MaxValue)
                    return;
                pc.Level = get_param_level_from_text(level);
                if (pc.Level == Protocol.ParamServerN.LevelE.invalid)
                    return;
                pc.ParamType = get_param_type_from_text(ttype);
                if (pc.ParamType == Protocol.ParamServerN.ParamTypeE.invalid)
                    return;
                pc.PrimaryInstrumentId = Services.InstrumentIdSymbolConfigService.Exists(tprimary) ? Services.InstrumentIdSymbolConfigService.GetId(tprimary) : ulong.MaxValue;
                if (pc.PrimaryInstrumentId == ulong.MaxValue)
                    return;
                pc.PrimaryInstrumentId = Services.UniqueInstrumentIdConfigService.DoesInstrumentIdExist(pc.PrimaryInstrumentId) ? Services.UniqueInstrumentIdConfigService.GetUniqueInstrumentId(pc.PrimaryInstrumentId) : ulong.MaxValue;
                if (pc.PrimaryInstrumentId == ulong.MaxValue)
                    return;
                pc.SecondaryInstrumentId = Services.InstrumentIdSymbolConfigService.Exists(tsecondary) ? Services.InstrumentIdSymbolConfigService.GetId(tsecondary) : ulong.MaxValue;
                if (pc.SecondaryInstrumentId == ulong.MaxValue)
                    return;
                pc.SecondaryInstrumentId = Services.UniqueInstrumentIdConfigService.DoesInstrumentIdExist(pc.SecondaryInstrumentId) ? Services.UniqueInstrumentIdConfigService.GetUniqueInstrumentId(pc.SecondaryInstrumentId) : ulong.MaxValue;
                if (pc.SecondaryInstrumentId == ulong.MaxValue)
                    return;
                if (!ushort.TryParse(tidx, out ushort idx))
                    return;
                pc.ParamIdx = idx;
                switch (pc.ParamType)
                {
                    case Protocol.ParamServerN.ParamTypeE.boolean:
                        {
                            if (val.ToLower() == "true")
                            {
                                Protocol.ParamServerN.BoolParamT* b = pc.add_bool_param_t(pbuf, 65536);
                                b->value = true;
                            }
                            else if (val.ToLower() == "false")
                            {
                                Protocol.ParamServerN.BoolParamT* b = pc.add_bool_param_t(pbuf, 65536);
                                b->value = false;
                            }
                            else
                                return;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.char_e:
                        {
                            if (val.Length == 1)
                            {
                                Protocol.ParamServerN.CharParamT* b = pc.add_char_param_t(pbuf, 65536);
                                b->value = this.paramManagementValueBox.Text[0];
                            }
                            else
                                return;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.double_e:
                        {
                            if (double.TryParse(val, out double d))
                            {
                                Protocol.ParamServerN.DoubleParamT* b = pc.add_double_param_t(pbuf, 65536);
                                b->value = d;
                            }
                            else
                                return;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.float_e:
                        {
                            if (float.TryParse(val, out float d))
                            {
                                Protocol.ParamServerN.FloatParamT* b = pc.add_float_param_t(pbuf, 65536);
                                b->value = d;
                            }
                            else
                                return;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.int8_e:
                        {
                            if (sbyte.TryParse(val, out sbyte d))
                            {
                                Protocol.ParamServerN.Int8ParamT* b = pc.add_int8_param_t(pbuf, 65536);
                                b->value = d;
                            }
                            else
                                return;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.int16_e:
                        {
                            if (short.TryParse(val, out short d))
                            {
                                Protocol.ParamServerN.Int16ParamT* b = pc.add_int16_param_t(pbuf, 65536);
                                b->value = d;
                            }
                            else
                                return;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.int32_e:
                        {
                            if (int.TryParse(val, out int d))
                            {
                                Protocol.ParamServerN.Int32ParamT* b = pc.add_int32_param_t(pbuf, 65536);
                                b->value = d;
                            }
                            else
                                return;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.int64_e:
                        {
                            if (long.TryParse(val, out long d))
                            {
                                Protocol.ParamServerN.Int64ParamT* b = pc.add_int64_param_t(pbuf, 65536);
                                b->value = d;
                            }
                            else
                                return;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.uint8_e:
                        {
                            if (byte.TryParse(val, out byte d))
                            {
                                Protocol.ParamServerN.Uint8ParamT* b = pc.add_uint8_param_t(pbuf, 65536);
                                b->value = d;
                            }
                            else
                                return;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.uint16_e:
                        {
                            if (ushort.TryParse(val, out ushort d))
                            {
                                Protocol.ParamServerN.Uint16ParamT* b = pc.add_uint16_param_t(pbuf, 65536);
                                b->value = d;
                            }
                            else
                                return;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.uint32_e:
                        {
                            if (uint.TryParse(val, out uint d))
                            {
                                Protocol.ParamServerN.Uint32ParamT* b = pc.add_uint32_param_t(pbuf, 65536);
                                b->value = d;
                            }
                            else
                                return;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.uint64_e:
                        {
                            if (ulong.TryParse(val, out ulong d))
                            {
                                Protocol.ParamServerN.Uint64ParamT* b = pc.add_uint64_param_t(pbuf, 65536);
                                b->value = d;
                            }
                            else
                                return;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.time_series_datetime_double_element:
                        {
                            if (ulong.TryParse(val, out ulong d) && double.TryParse(val, out double d1))
                            {
                                Protocol.ParamServerN.TimeSeriesDateTimeDoubleParamT* b = pc.add_time_series_datetime_double_param_t(pbuf, 65536);
                                b->datetime = d;
                                b->value = d1;
                            }
                            else
                                return;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.time_series_date_double_element:
                        {
                            if (uint.TryParse(val, out uint d) && double.TryParse(val, out double d1))
                            {
                                Protocol.ParamServerN.TimeSeriesDateDoubleParamT* b = pc.add_time_series_date_double_param_t(pbuf, 65536);
                                b->date = d;
                                b->value = d1;
                            }
                            else
                                return;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.time_series_datetime_int64_element:
                        {
                            if (ulong.TryParse(val, out ulong d) && long.TryParse(val, out long d1))
                            {
                                Protocol.ParamServerN.TimeSeriesDateTimeInt64ParamT* b = pc.add_time_series_datetime_int64_param_t(pbuf, 65536);
                                b->datetime = d;
                                b->value = d1;
                            }
                            else
                                return;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.time_series_date_int64_element:
                        {
                            if (uint.TryParse(val, out uint d) && long.TryParse(val, out long d1))
                            {
                                Protocol.ParamServerN.TimeSeriesDateInt64ParamT* b = pc.add_time_series_date_int64_param_t(pbuf, 65536);
                                b->date = d;
                                b->value = d1;
                            }
                            else
                                return;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.time_series_datetime_uint64_element:
                        {
                            if (ulong.TryParse(val, out ulong d) && ulong.TryParse(val, out ulong d1))
                            {
                                Protocol.ParamServerN.TimeSeriesDateTimeUint64ParamT* b = pc.add_time_series_datetime_uint64_param_t(pbuf, 65536);
                                b->datetime = d;
                                b->value = d1;
                            }
                            else
                                return;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.time_series_date_uint64_element:
                        {
                            if (uint.TryParse(val, out uint d) && ulong.TryParse(val, out ulong d1))
                            {
                                Protocol.ParamServerN.TimeSeriesDateUint64ParamT* b = pc.add_time_series_date_uint64_param_t(pbuf, 65536);
                                b->date = d;
                                b->value = d1;
                            }
                            else
                                return;
                        }
                        break;
                    default:
                        return;
                }

                if (this.paramManagement.should_validate(pc.ParamEnum))
                {
                    object cached_v = this.paramManagement.get_cache_value(pc.ParamEnum, pc.PrimaryInstrumentId, pc.SecondaryInstrumentId, pc.ParamIdx);
                    if (cached_v == null)
                        this.paramManagement.update(p);
                    else
                    {
                        if (this.paramManagement.validate(pc.ParamEnum, pc.PrimaryInstrumentId, pc.SecondaryInstrumentId, pc.ParamIdx, cached_v, val, out string new_val))
                        {
                            this.paramManagement.update(p);
                        }
                        else
                        { // change cell back
                            this.paramManagement.set_value(e.RowHandle, new_val);
                            view.RefreshRowCell(e.RowHandle, view.Columns["Val"]);
                            request_param_change(pc.ParamEnum, pc.ParamType, tprimary, tsecondary, new_val);
                        }
                    }
                }
                else
                {
                    this.paramManagement.update(p);
                }
            }
        }

        public string get_param_name_from_param_enum(uint id)
        {
            if (!this.paramEnumSet2.ContainsKey(id))
                return "";
            return this.paramEnumSet2[id];
        }
        private uint get_param_enum_from_name(string name)
        {
            if (!this.paramEnumSet.ContainsKey(name))
                return uint.MaxValue;
            return this.paramEnumSet[name];
        }
        public string get_text_from_param_level(Protocol.ParamServerN.LevelE lvl)
        {
            switch (lvl)
            {
                case Protocol.ParamServerN.LevelE.global:
                    return "global";
                case Protocol.ParamServerN.LevelE.instrument:
                    return "instrument";
                case Protocol.ParamServerN.LevelE.major_instrument_group:
                    return "major";
                case Protocol.ParamServerN.LevelE.minor_instrument_group:
                    return "minor";
                default:
                    return "";
            }
        }
        public string get_text_from_param_type(Protocol.ParamServerN.ParamTypeE type)
        {
            switch (type)
            {
                case Protocol.ParamServerN.ParamTypeE.boolean:
                    return "boolean";
                case Protocol.ParamServerN.ParamTypeE.char_e:
                    return "char";
                case Protocol.ParamServerN.ParamTypeE.double_e:
                    return "double";
                case Protocol.ParamServerN.ParamTypeE.float_e:
                    return "float";
                case Protocol.ParamServerN.ParamTypeE.int8_e:
                    return "int8";
                case Protocol.ParamServerN.ParamTypeE.int16_e:
                    return "int16";
                case Protocol.ParamServerN.ParamTypeE.int32_e:
                    return "int32";
                case Protocol.ParamServerN.ParamTypeE.int64_e:
                    return "int32";
                case Protocol.ParamServerN.ParamTypeE.uint8_e:
                    return "uint8";
                case Protocol.ParamServerN.ParamTypeE.uint16_e:
                    return "uint16";
                case Protocol.ParamServerN.ParamTypeE.uint32_e:
                    return "uint32";
                case Protocol.ParamServerN.ParamTypeE.uint64_e:
                    return "uint32";
                case Protocol.ParamServerN.ParamTypeE.time_series_datetime_double_element:
                    return "time_series_datetime_double_element";
                case Protocol.ParamServerN.ParamTypeE.time_series_date_double_element:
                    return "time_series_date_double_element";
                case Protocol.ParamServerN.ParamTypeE.time_series_datetime_int64_element:
                    return "time_series_datetime_int64_element";
                case Protocol.ParamServerN.ParamTypeE.time_series_date_int64_element:
                    return "time_series_date_int64_element";
                case Protocol.ParamServerN.ParamTypeE.time_series_datetime_uint64_element:
                    return "time_series_datetime_uint64_element";
                case Protocol.ParamServerN.ParamTypeE.time_series_date_uint64_element:
                    return "time_series_date_uint64_element";
                default:
                    return "";
            }
        }
        private Protocol.ParamServerN.LevelE get_param_level_from_text(string txt)
        {
            if (txt == "global")
                return Protocol.ParamServerN.LevelE.global;
            if (txt == "major")
                return Protocol.ParamServerN.LevelE.major_instrument_group;
            if (txt == "minor")
                return Protocol.ParamServerN.LevelE.minor_instrument_group;
            if (txt == "instrument")
                return Protocol.ParamServerN.LevelE.instrument;
            return Protocol.ParamServerN.LevelE.invalid;
        }
        private Protocol.ParamServerN.ParamTypeE get_param_type_from_text(string txt)
        {
            if (txt == "boolean" || txt == "bool")
                return Protocol.ParamServerN.ParamTypeE.boolean;
            if (txt == "uint8" || txt == "uint8_t" || txt == "u8" || txt == "byte")
                return Protocol.ParamServerN.ParamTypeE.uint8_e;
            if (txt == "uint16" || txt == "uint16_t" || txt == "u16" || txt == "ushort")
                return Protocol.ParamServerN.ParamTypeE.uint16_e;
            if (txt == "uint32" || txt == "uint32_t" || txt == "u32" || txt == "uint")
                return Protocol.ParamServerN.ParamTypeE.uint32_e;
            if (txt == "uint64" || txt == "uint64_t" || txt == "u64" || txt == "ulong")
                return Protocol.ParamServerN.ParamTypeE.uint64_e;
            if (txt == "int8" || txt == "int8_t" || txt == "i8" || txt == "sbyte")
                return Protocol.ParamServerN.ParamTypeE.int8_e;
            if (txt == "int16" || txt == "int16_t" || txt == "i16" || txt == "short")
                return Protocol.ParamServerN.ParamTypeE.int16_e;
            if (txt == "int32" || txt == "int32_t" || txt == "i32" || txt == "int")
                return Protocol.ParamServerN.ParamTypeE.int32_e;
            if (txt == "int64" || txt == "int64_t" || txt == "i64" || txt == "long")
                return Protocol.ParamServerN.ParamTypeE.int64_e;
            if (txt == "char")
                return Protocol.ParamServerN.ParamTypeE.char_e;
            if (txt == "float")
                return Protocol.ParamServerN.ParamTypeE.float_e;
            if (txt == "double")
                return Protocol.ParamServerN.ParamTypeE.double_e;
            if (txt == "time_series_date_double_element")
                return Protocol.ParamServerN.ParamTypeE.time_series_date_double_element;
            if (txt == "time_series_datetime_double_element")
                return Protocol.ParamServerN.ParamTypeE.time_series_datetime_double_element;
            if (txt == "time_series_date_uint64_element")
                return Protocol.ParamServerN.ParamTypeE.time_series_date_uint64_element;
            if (txt == "time_series_datetime_uint64_element")
                return Protocol.ParamServerN.ParamTypeE.time_series_datetime_uint64_element;
            if (txt == "time_series_date_int64_element")
                return Protocol.ParamServerN.ParamTypeE.time_series_date_int64_element;
            if (txt == "time_series_datetime_int64_element")
                return Protocol.ParamServerN.ParamTypeE.time_series_datetime_int64_element;
            return Protocol.ParamServerN.ParamTypeE.invalid;
        }
        private unsafe void ParamManagementDefineButton_Click(object sender, EventArgs e)
        {
            byte[] buf = new byte[65536];
            Protocol.ParamServerN.ParamChangeMsgT p = new Protocol.ParamServerN.ParamChangeMsgT();
            fixed (byte* pbuf = buf)
            {
                p.construct(pbuf, 65536);
                Protocol.ParamServerN.ParamChangeT pc = p.add_param_change_t(pbuf, 65536);
                pc.Flag = Protocol.ParamServerN.ParamFlagE.modify;
                pc.ParamEnum = (ushort)get_param_enum_from_name(this.paramManagementParamNameBox.Text);
                if (pc.ParamEnum == ushort.MaxValue)
                {
                    Network.Logger.Log(Network.Logger.Level.info, $"Attempted to define parameter but {this.paramManagementParamNameBox.Text} is not a defined param_enum");
                    return;
                }
                pc.Level = get_param_level_from_text(this.paramManagementParamLevelComboBox.Text);
                if (pc.Level == Protocol.ParamServerN.LevelE.invalid)
                {
                    Network.Logger.Log(Network.Logger.Level.info, $"Attempted to define parameter but {this.paramManagementParamLevelComboBox.Text} is not a defined level");
                    return;
                }
                pc.ParamType = get_param_type_from_text(this.paramManagementParamTypeComboBox.Text);
                if (pc.ParamType == Protocol.ParamServerN.ParamTypeE.invalid)
                {
                    Network.Logger.Log(Network.Logger.Level.info, $"Attempted to define parameter but {this.paramManagementParamTypeComboBox.Text} is not a defined param_type");
                    return;
                }
                pc.PrimaryInstrumentId = Services.InstrumentIdSymbolConfigService.Exists(this.paramManagementPriKeyBox.Text) ? Services.InstrumentIdSymbolConfigService.GetId(this.paramManagementPriKeyBox.Text) : ulong.MaxValue;
                if (pc.PrimaryInstrumentId == ulong.MaxValue)
                {
                    Network.Logger.Log(Network.Logger.Level.info, $"Attempted to define parameter but {this.paramManagementPriKeyBox.Text} is not a defined ticker");
                    return;
                }
                pc.PrimaryInstrumentId = Services.UniqueInstrumentIdConfigService.DoesInstrumentIdExist(pc.PrimaryInstrumentId) ? Services.UniqueInstrumentIdConfigService.GetUniqueInstrumentId(pc.PrimaryInstrumentId) : ulong.MaxValue;
                if (pc.PrimaryInstrumentId == ulong.MaxValue)
                    return;
                pc.SecondaryInstrumentId = Services.InstrumentIdSymbolConfigService.Exists(this.paramManagementSecKeyBox.Text) ? Services.InstrumentIdSymbolConfigService.GetId(this.paramManagementSecKeyBox.Text) : ulong.MaxValue;
                if (pc.SecondaryInstrumentId == ulong.MaxValue)
                {
                    Network.Logger.Log(Network.Logger.Level.info, $"Attempted to define parameter but {this.paramManagementSecKeyBox.Text} is not a defined ticker");
                    return;
                }
                pc.SecondaryInstrumentId = Services.UniqueInstrumentIdConfigService.DoesInstrumentIdExist(pc.SecondaryInstrumentId) ? Services.UniqueInstrumentIdConfigService.GetUniqueInstrumentId(pc.SecondaryInstrumentId) : ulong.MaxValue;
                if (pc.SecondaryInstrumentId == ulong.MaxValue)
                    return;
                if (!ushort.TryParse(this.paramManagementIdxBox.Text, out ushort idx))
                {
                    Network.Logger.Log(Network.Logger.Level.info, $"Attempted to define parameter but {this.paramManagementIdxBox.Text} is a badly formatted idx");
                    return;
                }
                pc.ParamIdx = idx;
                switch (pc.ParamType)
                {
                    case Protocol.ParamServerN.ParamTypeE.boolean:
                        {
                            if (this.paramManagementValueBox.Text.ToLower() == "true")
                            {
                                Protocol.ParamServerN.BoolParamT* b = pc.add_bool_param_t(pbuf, 65536);
                                b->value = true;
                            }
                            else if (this.paramManagementValueBox.Text.ToLower() == "false")
                            {
                                Protocol.ParamServerN.BoolParamT* b = pc.add_bool_param_t(pbuf, 65536);
                                b->value = false;
                            }
                            else
                            {
                                Network.Logger.Log(Network.Logger.Level.info, $"Attempted to define parameter but {this.paramManagementValueBox.Text} is a badly formatted bool value (true/false, case-insensitive)");
                                return;
                            }
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.char_e:
                        {
                            if (this.paramManagementValueBox.Text.Length == 1)
                            {
                                Protocol.ParamServerN.CharParamT* b = pc.add_char_param_t(pbuf, 65536);
                                b->value = this.paramManagementValueBox.Text[0];
                            }
                            else
                            {
                                Network.Logger.Log(Network.Logger.Level.info, $"Attempted to define parameter but {this.paramManagementValueBox.Text} is a badly formatted char value (only 1 character allowed)");
                                return;
                            }
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.double_e:
                        {
                            if (double.TryParse(this.paramManagementValueBox.Text, out double d))
                            {
                                Protocol.ParamServerN.DoubleParamT* b = pc.add_double_param_t(pbuf, 65536);
                                b->value = d;
                            }
                            else
                            {
                                Network.Logger.Log(Network.Logger.Level.info, $"Attempted to define parameter but {this.paramManagementValueBox.Text} is a badly formatted double value");
                                return;
                            }
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.float_e:
                        {
                            if (float.TryParse(this.paramManagementValueBox.Text, out float d))
                            {
                                Protocol.ParamServerN.FloatParamT* b = pc.add_float_param_t(pbuf, 65536);
                                b->value = d;
                            }
                            else
                            {
                                Network.Logger.Log(Network.Logger.Level.info, $"Attempted to define parameter but {this.paramManagementValueBox.Text} is a badly formatted float value");
                                return;
                            }
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.int8_e:
                        {
                            if (sbyte.TryParse(this.paramManagementValueBox.Text, out sbyte d))
                            {
                                Protocol.ParamServerN.Int8ParamT* b = pc.add_int8_param_t(pbuf, 65536);
                                b->value = d;
                            }
                            else
                                return;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.int16_e:
                        {
                            if (short.TryParse(this.paramManagementValueBox.Text, out short d))
                            {
                                Protocol.ParamServerN.Int16ParamT* b = pc.add_int16_param_t(pbuf, 65536);
                                b->value = d;
                            }
                            else
                                return;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.int32_e:
                        {
                            if (int.TryParse(this.paramManagementValueBox.Text, out int d))
                            {
                                Protocol.ParamServerN.Int32ParamT* b = pc.add_int32_param_t(pbuf, 65536);
                                b->value = d;
                            }
                            else
                                return;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.int64_e:
                        {
                            if (long.TryParse(this.paramManagementValueBox.Text, out long d))
                            {
                                Protocol.ParamServerN.Int64ParamT* b = pc.add_int64_param_t(pbuf, 65536);
                                b->value = d;
                            }
                            else
                                return;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.uint8_e:
                        {
                            if (byte.TryParse(this.paramManagementValueBox.Text, out byte d))
                            {
                                Protocol.ParamServerN.Uint8ParamT* b = pc.add_uint8_param_t(pbuf, 65536);
                                b->value = d;
                            }
                            else
                                return;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.uint16_e:
                        {
                            if (ushort.TryParse(this.paramManagementValueBox.Text, out ushort d))
                            {
                                Protocol.ParamServerN.Uint16ParamT* b = pc.add_uint16_param_t(pbuf, 65536);
                                b->value = d;
                            }
                            else
                                return;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.uint32_e:
                        {
                            if (uint.TryParse(this.paramManagementValueBox.Text, out uint d))
                            {
                                Protocol.ParamServerN.Uint32ParamT* b = pc.add_uint32_param_t(pbuf, 65536);
                                b->value = d;
                            }
                            else
                                return;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.uint64_e:
                        {
                            if (ulong.TryParse(this.paramManagementValueBox.Text, out ulong d))
                            {
                                Protocol.ParamServerN.Uint64ParamT* b = pc.add_uint64_param_t(pbuf, 65536);
                                b->value = d;
                            }
                            else
                                return;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.time_series_datetime_double_element:
                        {
                            if (ulong.TryParse(this.paramManagementValueBox.Text, out ulong d) && double.TryParse(this.paramManagementValueBox.Text, out double d1))
                            {
                                Protocol.ParamServerN.TimeSeriesDateTimeDoubleParamT* b = pc.add_time_series_datetime_double_param_t(pbuf, 65536);
                                b->datetime = d;
                                b->value = d1;
                            }
                            else
                                return;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.time_series_date_double_element:
                        {
                            if (uint.TryParse(this.paramManagementValueBox.Text, out uint d) && double.TryParse(this.paramManagementValueBox.Text, out double d1))
                            {
                                Protocol.ParamServerN.TimeSeriesDateDoubleParamT* b = pc.add_time_series_date_double_param_t(pbuf, 65536);
                                b->date = d;
                                b->value = d1;
                            }
                            else
                                return;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.time_series_datetime_int64_element:
                        {
                            if (ulong.TryParse(this.paramManagementValueBox.Text, out ulong d) && long.TryParse(this.paramManagementValueBox.Text, out long d1))
                            {
                                Protocol.ParamServerN.TimeSeriesDateTimeInt64ParamT* b = pc.add_time_series_datetime_int64_param_t(pbuf, 65536);
                                b->datetime = d;
                                b->value = d1;
                            }
                            else
                                return;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.time_series_date_int64_element:
                        {
                            if (uint.TryParse(this.paramManagementValueBox.Text, out uint d) && long.TryParse(this.paramManagementValueBox.Text, out long d1))
                            {
                                Protocol.ParamServerN.TimeSeriesDateInt64ParamT* b = pc.add_time_series_date_int64_param_t(pbuf, 65536);
                                b->date = d;
                                b->value = d1;
                            }
                            else
                                return;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.time_series_datetime_uint64_element:
                        {
                            if (ulong.TryParse(this.paramManagementValueBox.Text, out ulong d) && ulong.TryParse(this.paramManagementValueBox.Text, out ulong d1))
                            {
                                Protocol.ParamServerN.TimeSeriesDateTimeUint64ParamT* b = pc.add_time_series_datetime_uint64_param_t(pbuf, 65536);
                                b->datetime = d;
                                b->value = d1;
                            }
                            else
                                return;
                        }
                        break;
                    case Protocol.ParamServerN.ParamTypeE.time_series_date_uint64_element:
                        {
                            if (uint.TryParse(this.paramManagementValueBox.Text, out uint d) && ulong.TryParse(this.paramManagementValueBox.Text, out ulong d1))
                            {
                                Protocol.ParamServerN.TimeSeriesDateUint64ParamT* b = pc.add_time_series_date_uint64_param_t(pbuf, 65536);
                                b->date = d;
                                b->value = d1;
                            }
                            else
                                return;
                        }
                        break;
                    default:
                        return;
                }
                CryptoUI.Panel.ParamManagement.ParamStringsT ps = new CryptoUI.Panel.ParamManagement.ParamStringsT();
                ps.Name = this.paramManagementParamNameBox.Text;
                ps.Type = this.paramManagementParamTypeComboBox.Text;
                ps.Level = this.paramManagementParamLevelComboBox.Text;
                ps.PriKey = this.paramManagementPriKeyBox.Text;
                ps.SecKey = this.paramManagementSecKeyBox.Text;
                ps.Idx = this.paramManagementIdxBox.Text;
                ps.Value = this.paramManagementValueBox.Text;
                this.paramManagement.add_new(ps, p);
            }
        }

        public void onParamHeartbeatSeq(uint seqno)
        {
            if (InvokeRequired)
            {
                this.Invoke(new System.Action<uint>(onParamHeartbeatSeq), new object[] { seqno });
                return;
            }
            paramManagementSeqNoBox.Text = seqno.ToString();
            paramManagementSeqNoBox.ForeColor = System.Drawing.Color.White;
        }
        public void onParamServerConnect()
        {
            if (InvokeRequired)
            {
                this.Invoke(new System.Action(onParamServerConnect), new object[] { });
                return;
            }
            paramManagementStatusBox.Text = "connected";
            paramManagementStatusBox.ForeColor = System.Drawing.Color.Green;
        }
        public void onParamDisconnect()
        {
            if (InvokeRequired)
            {
                this.Invoke(new System.Action(onParamDisconnect), new object[] { });
                return;
            }
            paramManagementStatusBox.Text = "disconnected";
            paramManagementStatusBox.ForeColor = System.Drawing.Color.Red;
        }
        public CryptoUI.Panel.ParamManagement.ParamManagement GetParamManager()
        {
            return this.paramManagement;
        }
    }
}