using System;
using System.Xml;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using Npgsql;
using NpgsqlTypes;

namespace LibBC
{
    public class AccessData
    {
        public const string Msg = "Viện phí THIS";
        private string m_cur_mmyy = "";
        public const string s_links_username = "links";
        public const string s_links_password = "715501920";
        public const string s_links_userid = "-99999";
        private string m_db_database = "medisoft2007";
        private string m_db_host = "192.168.1.14";
        private string m_db_port = "5432";
        private string m_db_userid = "medisoft2007";
        private string m_db_password = "links1920";
        private string m_db_encoding = "UNICODE";
        private string m_db_schemaroot = "medibv";
        private string m_db_connectionstring = "Server=192.168.1.14;Port=5432;User Id=medisoft2007;Password=medisoft2007;Database=medisoft2007;Encoding=UNICODE;";
        private string m_computername = "";
        private int m_computerid = 1;
        private string m_sql = "";
        private DataSet m_ds = null;
        private DataSet m_ds_schema = null;
        private NpgsqlDataAdapter m_dataadapter;
        private NpgsqlConnection m_connection;
        private NpgsqlCommand m_command;

        public AccessData()
        {
            m_computername = System.Environment.MachineName.Trim().ToUpper();
            f_load_maincode();
            m_db_connectionstring = "Server=" + m_db_host + ";Port=" + m_db_port + ";User Id=" + m_db_userid + ";Password=" + m_db_password + ";Database=" + m_db_database + ";Encoding=" + m_db_encoding + ";Pooling=true;";
            upd_dmcomputer();
            m_computerid = get_computerid();
            m_ds_schema = get_shemaname_mmyy();
            m_cur_mmyy = s_curmmyy;
        }

        public string s_AppName
        {
            get
            {
                return Msg;
            }
        }

        #region SYSTEM CONFIGUREATION
        public string get_v_option(string v_ma)
        {
            try
            {
                return get_data("select giatri from medibv.v_option where ma='" + v_ma + "'").Tables[0].Rows[0][0].ToString().Trim();
            }
            catch
            {
                return "";
            }
        }
        public string sys_makp_khongkham
        {
            get
            {
                string atmp = get_v_option("cbKhoakhongkham").ToString().Trim();
                if (atmp == "")
                {
                    atmp = "01";
                }
                return atmp;
            }
            set
            {
                upd_v_option("cbKhoakhongkham", value);
            }
        }
        public bool sys_dungchungso
        {
            get
            {
                return get_v_option("chkDungchungso").ToString() == "1";
            }
            set
            {
                upd_v_option("chkDungchungso", (value == true) ? "1" : "0");
            }
        }
        public bool sys_nhapsotienchitiet_tu
        {
            get
            {
                return get_v_option("chkNhapsotienchitiet_tu").ToString() == "1";
            }
            set
            {
                upd_v_option("chkNhapsotienchitiet_tu", (value == true) ? "1" : "0");
            }
        }
        public bool sys_hoantramon_tt
        {
            get
            {
                return get_v_option("chkHoantramon_TT").ToString() == "1";
            }
            set
            {
                upd_v_option("chkHoantramon_TT", (value == true) ? "1" : "0");
            }
        }
        public bool sys_dongiacongvattu
        {
            get
            {
                return get_v_option("chkDongiacongvattu").ToString() == "1";
            }
            set
            {
                upd_v_option("chkDongiacongvattu", (value == true) ? "1" : "0");
            }
        }
        public string sys_tamungchitiettheo_1loai_2nhom
        {
            get
            {
                return get_v_option("cbChitiettamung");
            }
        }
        public bool sys_insotienchitiet_tamung
        {
            get
            {
                return get_v_option("chkInsotienchitiet_tamung").Trim() == "1";
            }
        }
        public string sys_thuquy
        {
            get
            {
                return get_v_option("txtThuquy").Trim();
            }
            set
            {
                upd_v_option("txtThuquy", value);
            }
        }
        public string sys_ketoanvp
        {
            get
            {
                return get_v_option("txtKetoanvp").Trim();
            }
            set
            {
                upd_v_option("txtKetoanvp", value);
            }
        }
        public string sys_phongtckt
        {
            get
            {
                return get_v_option("txtPhongtckt").Trim();
            }
            set
            {
                upd_v_option("txtPhongtckt", value);
            }
        }
        public string sys_report_thutructiep
        {
            get
            {
                string atmp = get_v_option("txtReport_Tructiep").Trim();
                if (atmp == "")
                {
                    atmp = "v_bienlaithuvienphi.rpt";
                }
                return atmp;
            }
            set
            {
                upd_v_option("txtReport_Tructiep", value);
            }
        }
        public string sys_report_thutrongoi
        {
            get
            {
                string atmp = get_v_option("txtReport_Trongoi").Trim();
                if (atmp == "")
                {
                    atmp = "v_bienlaithuvienphitrongoi.rpt";
                }
                return atmp;
            }
            set
            {
                upd_v_option("txtReport_Trongoi", value);
            }
        }
        public string sys_report_thutamung
        {
            get
            {
                string atmp = get_v_option("txtReport_Tamung").Trim();
                if (atmp == "")
                {
                    atmp = "v_bienlaitamung.rpt";
                }
                return atmp;
            }
            set
            {
                upd_v_option("txtReport_Tamung", value);
            }
        }
        public string sys_report_ravien
        {
            get
            {
                string atmp = get_v_option("txtReport_Ravien").Trim();
                if (atmp == "")
                {
                    atmp = "v_bienlaithuvienphint.rpt";
                }
                return atmp;
            }
            set
            {
                upd_v_option("txtReport_Ravien", value);
            }
        }
        public string sys_report_ravien_thuong
        {
            get
            {
                string atmp = get_v_option("txtReport_Ravien_Thuong").Trim();
                if (atmp == "")
                {
                    atmp = "v_bienlaithuvienphint_thuong.rpt";
                }
                return atmp;
            }
            set
            {
                upd_v_option("txtReport_Ravien_Thuong", value);
            }
        }
        public string sys_report_ravien_chi
        {
            get
            {
                string atmp = get_v_option("txtReport_Ravien_Chi").Trim();
                if (atmp == "")
                {
                    atmp = "v_bienlaithuvienphint_thuchi.rpt";
                }
                return atmp;
            }
            set
            {
                upd_v_option("txtReport_Ravien_Chi", value);
            }
        }
        public string sys_report_phieuchi
        {
            get
            {
                string atmp = get_v_option("txtReport_Phieuchi").Trim();
                if (atmp == "")
                {
                    atmp = "v_phieuchi.rpt";
                }
                return atmp;
            }
            set
            {
                upd_v_option("txtReport_Phieuchi", value);
            }
        }
        public string sys_report_trongoi
        {
            get
            {
                string atmp = get_v_option("txtReport_Trongoi").Trim();
                if (atmp == "")
                {
                    atmp = "v_trongoi.rpt";
                }
                return atmp;
            }
            set
            {
                upd_v_option("txtReport_Trongoi", value);
            }
        }
        public string sys_report_bhyt
        {
            get
            {
                string atmp = get_v_option("txtReport_BHYT").Trim();
                if (atmp == "")
                {
                    atmp = "v_bienlaithuvienphibhyt.rpt";
                }
                return atmp;
            }
            set
            {
                upd_v_option("txtReport_BHYT", value);
            }
        }
        #endregion

        #region OPTION FORM
        public string s_loaiform_thutructiep
        {
            get
            {
                return "1";
            }
        }
        public string s_loaiform_thutamung
        {
            get
            {
                return "2";
            }
        }
        public string s_loaiform_thuchiravien
        {
            get
            {
                return "3";
            }
        }
        public string s_loaiform_thutrongoi
        {
            get
            {
                return "4";
            }
        }
        public string s_loaiform_phieuchi
        {
            get
            {
                return "5";
            }
        }
        public string s_loaiform_bhyt
        {
            get
            {
                return "6";
            }
        }
        public bool upd_optionform(decimal v_userid, decimal v_loai, string v_ma, string v_ten, string v_giatri)
        {
            m_sql = "update " + s_schemaroot + ".v_optionform set ten=:v_ten,giatri=:v_giatri where userid=:v_userid and loai=:v_loai and ma=:v_ma";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
            m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
            m_command.Parameters.Add("v_ma", NpgsqlDbType.Text).Value = v_ma;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
            m_command.Parameters.Add("v_giatri", NpgsqlDbType.Text).Value = v_giatri;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".v_optionform(userid,loai,ma,ten,giatri) values(:v_userid,:v_loai,:v_ma,:v_ten,:v_giatri)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                    m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Text).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_giatri", NpgsqlDbType.Text).Value = v_giatri;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_optionform");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_loaitu(decimal v_id, decimal v_sotien, string v_ten, decimal v_ktt)
        {
            m_sql = "update v_loaitu set sotien=:v_sotien,ten=:v_ten,ktt=:v_ktt where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
            m_command.Parameters.Add("v_ktt", NpgsqlDbType.Numeric).Value = v_ktt;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".v_loaitu(id,sotien,ten,ktt) values(:v_id,:v_sotien,:v_ten,:v_ktt)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_ktt", NpgsqlDbType.Numeric).Value = v_ktt;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_loaitu");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_option_locgiavp(decimal v_userid, decimal v_loai, string v_ten, string v_id_vp)
        {
            m_sql = "update " + s_schemaroot + ".v_option_locgiavp set ten=:v_ten,id_vp=:v_id_vp where userid=:v_userid and loai=:v_loai";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
            m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
            m_command.Parameters.Add("v_id_vp", NpgsqlDbType.Varchar, 3000).Value = v_id_vp;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".v_option_locgiavp(userid,loai,ten,id_vp) values(:v_userid,:v_loai,:v_ten,:v_id_vp)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                    m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_id_vp", NpgsqlDbType.Varchar, 3000).Value = v_id_vp;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_option_locgiavp");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_option_thutheonhom(decimal v_id, decimal v_userid, decimal v_stt, string v_ten, string v_id_vp)
        {
            m_sql = "update " + s_schemaroot + ".v_option_thutheonhom set stt=:v_stt,ten=:v_ten,id_vp=:v_id_vp where userid=:v_userid and id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 50).Value = v_ten;
            m_command.Parameters.Add("v_id_vp", NpgsqlDbType.Varchar, 1000).Value = v_id_vp;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".v_option_thutheonhom(id,userid,stt,ten,id_vp) values(:v_id,:v_userid,:v_stt,:v_ten,:v_id_vp)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_id_vp", NpgsqlDbType.Varchar, 1000).Value = v_id_vp;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_option_thutheonhom");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool sys_quyen_suatuychon(string v_userid)
        {
            try
            {
                return get_data("select chon from medibv.v_phanquyen where chon=1 and menuname ='menu_C_3_Tuychon' and  userid=" + v_userid + " limit 1").Tables[0].Rows.Count > 0;
            }
            catch
            {
                return false;
            }
        }
        //1
        public bool get_o_multiline_frmchonvp(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='1'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        public void set_o_multiline_frmchonvp(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "1", "frmchonvp.multiline", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //2
        public bool get_o_fullscreen_frmthutructiep(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='2'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        public void set_o_fullscreen_frmthutructiep(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "2", "frmthutructiep.fullscreen", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //3
        public bool get_o_fullgrid_frmthutructiep(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='3'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        public void set_o_fullgrid_frmthutructiep(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "3", "frmthutructiep.fullgrid", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //4
        public bool get_o_fullgrid_frmtimbenhnhan(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='4'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        public void set_o_fullgrid_frmtimbenhnhan(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "4", "frmtimbenhnhan.fullgrid", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //5
        public bool get_o_fullgrid_frmtimhoadon(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='5'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        public void set_o_fullgrid_frmtimhoadon(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "5", "frmtimhoadon.fullgrid", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //6
        public bool get_o_fullgrid_frmdanhsachthutructiep(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='6'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        public void set_o_fullgrid_frmdanhsachthutructiep(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "6", "frmdanhsachthutructiep.fullgrid", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //7
        public bool get_o_fullgrid_frmdanhsachchothutructiep(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='7'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        public void set_o_fullgrid_frmdanhsachchothutructiep(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "7", "frmdanhsachchothutructiep.fullgrid", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //8
        public int get_o_limit_frmtimbenhnhan(string v_userid)
        {
            try
            {
                return int.Parse(get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='8'").Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                return 100;
            }
        }
        public void set_o_limit_frmtimbenhnhan(string v_userid, string v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "8", "frmtimbenhnhan.limit", v_giatri);
            }
            catch
            {
            }
        }
        //9
        public int get_o_limit_frmtimhoadon(string v_userid)
        {
            try
            {
                return int.Parse(get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='9'").Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                return 0;
            }
        }
        public void set_o_limit_frmtimhoadon(string v_userid, string v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "9", "frmtimhoadon.limit", v_giatri);
            }
            catch
            {
            }
        }
        //10
        public int get_o_limit_frmdanhsachthutructiep(string v_userid)
        {
            try
            {
                return int.Parse(get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='10'").Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                return 0;
            }
        }
        public void set_o_limit_frmdanhsachthutructiep(string v_userid, string v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "10", "frmdanhsachthutructiep.limit", v_giatri);
            }
            catch
            {
            }
        }
        //11
        public int get_o_limit_frmdanhsachchothutructiep(string v_userid)
        {
            try
            {
                return int.Parse(get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='11'").Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                return 100;
            }
        }
        public void set_o_limit_frmdanhsachchothutructiep(string v_userid, string v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "11", "frmdanhsachchothutructiep.limit", v_giatri);
            }
            catch
            {
            }
        }
        //12
        public bool get_o_fullgrid_frmhoantra(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='12'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        public void set_o_fullgrid_frmhoantra(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "12", "frmhoantra.fullgrid", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //14
        public bool get_o_fullgrid_frmhoantra_h(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='14'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        public void set_o_fullgrid_frmhoantra_h(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "14", "frmhoantra.fullgrid_h", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //13
        public bool get_o_fullgrid_frmhoantrachitiet(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='13'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        public void set_o_fullgrid_frmhoantrachitiet(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "13", "frmhoantrachitiet.fullgrid", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //15
        public bool get_o_fullgrid_frmhoantrachitiet_1(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='15'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        public void set_o_fullgrid_frmhoantrachitiet_1(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "15", "frmhoantrachitiet.fullgrid_1", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //16
        public bool get_o_fullgrid_frmhoantrachitiet_h(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='16'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        public void set_o_fullgrid_frmhoantrachitiet_h(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "16", "frmhoantrachitiet.fullgrid_h", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //17
        public int get_o_limit_frmhoantra(string v_userid)
        {
            try
            {
                return int.Parse(get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='17'").Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                return 100;
            }
        }
        public void set_o_limit_frmhoantra(string v_userid, string v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "17", "frmhoantra.limit", v_giatri);
            }
            catch
            {
            }
        }
        //18
        public bool get_o_show_hotkey_frmthutructiep(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='18'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_show_hotkey_frmthutructiep(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "18", "frmthutructiep.show_hotkey", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //19
        public bool get_o_luuin_hoadon_frmthutructiep(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='19'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_luuin_hoadon_frmthutructiep(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "19", "frmthutructiep.luuin_hoadon", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //20
        public bool get_o_luuin_chiphi_frmthutructiep(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='20'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_luuin_chiphi_frmthutructiep(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "20", "frmthutructiep.luuin_chiphi", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //21
        public bool get_o_xemtruockhiin_frmthutructiep(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='21'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_xemtruockhiin_frmthutructiep(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "21", "frmthutructiep.luuin_chiphi", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //22
        public bool get_o_fullgrid_frmthutamung(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='22'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        public void set_o_fullgrid_frmthutamung(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "22", "frmthutamung.fullgrid", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //23
        public int get_o_dgheight_frmthutamung(string v_userid)
        {
            try
            {
                int atmp = int.Parse(get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='23'").Tables[0].Rows[0][0].ToString());
                if (atmp < 30)
                {
                    atmp = 125;
                }
                return atmp;
            }
            catch
            {
                return 125;
            }
        }
        public void set_o_dgheight_frmthutamung(string v_userid, int v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "23", "frmthutamung.dgheight", v_giatri.ToString());
            }
            catch
            {
            }
        }
        //24
        public bool get_o_xemlaihoadon_frmthutamung(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='24'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return true;
            }
        }
        public void set_o_xemlaihoadon_frmthutamung(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "24", "frmthutamung.xemlaihoadon", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //25
        public bool get_o_xemlaidanhsach_frmthutamung(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='25'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return true;
            }
        }
        public void set_o_xemlaidanhsach_frmthutamung(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "25", "frmthutamung.xemlaidanhsach", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //26
        public bool get_o_fullgrid_frmdanhsachthutamung(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='26'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        public void set_o_fullgrid_frmdanhsachthutamung(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "26", "frmdanhsachthutamung.fullgrid", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }

        //27
        public int get_o_limit_frmdanhsachthutamung(string v_userid)
        {
            try
            {
                return int.Parse(get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='27'").Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                return 0;
            }
        }
        public void set_o_limit_frmdanhsachthutamung(string v_userid, string v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "27", "frmdanhsachthutamung.limit", v_giatri);
            }
            catch
            {
            }
        }
        //28
        public bool get_o_luuin_frmthutamung(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='28'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_luuin_frmthutamung(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "28", "frmthutamung.luuin", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //29
        public bool get_o_xemtruockhiin_frmthutamung(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='29'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_xemtruockhiin_frmthutamung(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "29", "frmthutamung.luuin_chiphi", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //30
        public bool get_o_locsotheoloai_frmthutructiep(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='30'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_locsotheoloai_frmthutructiep(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "30", "frmthutructiep.luuin_chiphi", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //31
        public bool get_o_show_hotkey_ksk_frmthutructiep(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='31'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return false;
            }
        }
        public void set_o_show_hotkey_ksk_frmthutructiep(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "31", "frmthutructiep.show_hotkey_ksk", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //32
        public bool get_o_addall_hotkey_frmthutructiep(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='32'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_addall_hotkey_frmthutructiep(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "32", "frmthutructiep.show_addall_hotkey", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //33
        public bool get_o_show_hotkey_toolbar_frmthutructiep(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='33'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_show_hotkey_toolbar_frmthutructiep(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "33", "frmthutructiep.show_hotkey_toolbar", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //34
        public bool get_o_luuin_frmhoantra(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='34'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_luuin_frmhoantra(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "34", "frm_hoantra.luuin", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //35
        public bool get_o_preview_frmhoantra(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='35'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_preview_frmhoantra(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "35", "frm_hoantra.preview", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //36
        public bool get_o_fullgrid_frmsuahoadon(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='36'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        public void set_o_fullgrid_frmsuahoadon(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "36", "frmsuahoadon.fullgrid", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //37
        public int get_o_limit_frmsuahoadon(string v_userid)
        {
            try
            {
                return int.Parse(get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='37'").Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                return 100;
            }
        }
        public void set_o_limit_frmsuahoadon(string v_userid, string v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "37", "frmsuahoadon.limit", v_giatri);
            }
            catch
            {
            }
        }
        //38
        public bool get_o_fullgrid_frmdanhsachchothutamung(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='38'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        public void set_o_fullgrid_frmdanhsachchothutamung(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "38", "frmdanhsachchothutamung.fullgrid", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //39
        public int get_o_limit_frmdanhsachchothutamung(string v_userid)
        {
            try
            {
                return int.Parse(get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='39'").Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                return 100;
            }
        }
        public void set_o_limit_frmdanhsachchothutamung(string v_userid, string v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "39", "frmdanhsachchothutamung.limit", v_giatri);
            }
            catch
            {
            }
        }
        //40
        public bool get_o_fullgridhd_frmthutamung(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='40'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        public void set_o_fullgridhd_frmthutamung(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "40", "frmthutamung.fullgridhd", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //41
        public bool get_o_fullscreen_frmthutrongoi(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='41'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        public void set_o_fullscreen_frmthutrongoi(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "41", "frmthutrongoi.fullscreen", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //42
        public bool get_o_fullgrid_frmthutrongoi(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='42'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        public void set_o_fullgrid_frmthutrongoi(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "42", "frmthutrongoi.fullgrid", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //43
        public bool get_o_fullgrid_frmdanhsachthutrongoi(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='43'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        public void set_o_fullgrid_frmdanhsachthutrongoi(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "43", "frmdanhsachthutrongoi.fullgrid", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //44
        public bool get_o_fullgrid_frmdanhsachchothutrongoi(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='44'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        public void set_o_fullgrid_frmdanhsachchothutrongoi(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "44", "frmdanhsachchothutrongoi.fullgrid", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //45
        public int get_o_limit_frmdanhsachthutrongoi(string v_userid)
        {
            try
            {
                return int.Parse(get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='45'").Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                return 0;
            }
        }
        public void set_o_limit_frmdanhsachthutrongoi(string v_userid, string v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "45", "frmdanhsachthutrongoi.limit", v_giatri);
            }
            catch
            {
            }
        }
        //46
        public int get_o_limit_frmdanhsachchothutrongoi(string v_userid)
        {
            try
            {
                return int.Parse(get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='46'").Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                return 100;
            }
        }
        public void set_o_limit_frmdanhsachchothutrongoi(string v_userid, string v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "46", "frmdanhsachchothutrongoi.limit", v_giatri);
            }
            catch
            {
            }
        }
        //47
        public bool get_o_show_hotkey_frmthutrongoi(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='47'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_show_hotkey_frmthutrongoi(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "47", "frmthutrongoi.show_hotkey", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //48
        public bool get_o_luuin_hoadon_frmthutrongoi(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='48'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_luuin_hoadon_frmthutrongoi(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "48", "frmthutrongoi.luuin_hoadon", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //49
        public bool get_o_luuin_chiphi_frmthutrongoi(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='49'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_luuin_chiphi_frmthutrongoi(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "49", "frmthutrongoi.luuin_chiphi", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //50
        public bool get_o_xemtruockhiin_frmthutrongoi(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='50'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_xemtruockhiin_frmthutrongoi(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "50", "frmthutrongoi.luuin_chiphi", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //51
        public bool get_o_show_hotkey_ksk_frmthutrongoi(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='51'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return false;
            }
        }
        public void set_o_show_hotkey_ksk_frmthutrongoi(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "51", "frmthutrongoi.show_hotkey_ksk", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //52
        public bool get_o_addall_hotkey_frmthutrongoi(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='52'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_addall_hotkey_frmthutrongoi(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "52", "frmthutrongoi.show_addall_hotkey", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //53
        public bool get_o_show_hotkey_toolbar_frmthutrongoi(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='53'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_show_hotkey_toolbar_frmthutrongoi(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "53", "frmthutrongoi.show_hotkey_toolbar", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //54
        public bool get_o_fullscreen_frmthuchiravien(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='54'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        public void set_o_fullscreen_frmthuchiravien(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "54", "frmthuchiravien.fullscreen", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //55
        public bool get_o_fullgrid_frmthuchiravien(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='55'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        public void set_o_fullgrid_frmthuchiravien(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "55", "frmthuchiravien.fullgrid", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //56
        public bool get_o_fullgrid_frmdanhsachthuchiravien(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='56'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        public void set_o_fullgrid_frmdanhsachthuchiravien(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "56", "frmdanhsachthuchiravien.fullgrid", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //57
        public bool get_o_fullgrid_frmdanhsachchothuchiravien(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='57'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        public void set_o_fullgrid_frmdanhsachchothuchiravien(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "57", "frmdanhsachchothuchiravien.fullgrid", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //58
        public int get_o_limit_frmdanhsachthuchiravien(string v_userid)
        {
            try
            {
                return int.Parse(get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='58'").Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                return 0;
            }
        }
        public void set_o_limit_frmdanhsachthuchiravien(string v_userid, string v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "58", "frmdanhsachthuchiravien.limit", v_giatri);
            }
            catch
            {
            }
        }
        //59
        public int get_o_limit_frmdanhsachchothuchiravien(string v_userid)
        {
            try
            {
                return int.Parse(get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='59'").Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                return 100;
            }
        }
        public void set_o_limit_frmdanhsachchothuchiravien(string v_userid, string v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "59", "frmdanhsachchothuchiravien.limit", v_giatri);
            }
            catch
            {
            }
        }
        //60
        public bool get_o_show_hotkey_frmthuchiravien(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='60'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_show_hotkey_frmthuchiravien(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "60", "frmthuchiravien.show_hotkey", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //61
        public bool get_o_luuin_hoadon_frmthuchiravien(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='61'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_luuin_hoadon_frmthuchiravien(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "61", "frmthuchiravien.luuin_hoadon", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //62
        public bool get_o_luuin_chiphi_frmthuchiravien(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='62'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_luuin_chiphi_frmthuchiravien(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "62", "frmthuchiravien.luuin_chiphi", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //63
        public bool get_o_xemtruockhiin_frmthuchiravien(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='63'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_xemtruockhiin_frmthuchiravien(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "63", "frmthuchiravien.luuin_chiphi", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //64
        public bool get_o_locsotheoloai_frmthuchiravien(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='64'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_locsotheoloai_frmthuchiravien(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "64", "frmthuchiravien.luuin_chiphi", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //65
        public bool get_o_show_hotkey_ksk_frmthuchiravien(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='65'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return false;
            }
        }
        public void set_o_show_hotkey_ksk_frmthuchiravien(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "65", "frmthuchiravien.show_hotkey_ksk", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //66
        public bool get_o_addall_hotkey_frmthuchiravien(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='66'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_addall_hotkey_frmthuchiravien(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "66", "frmthuchiravien.show_addall_hotkey", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //67
        public bool get_o_show_hotkey_toolbar_frmthuchiravien(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='67'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_show_hotkey_toolbar_frmthuchiravien(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "67", "frmthuchiravien.show_hotkey_toolbar", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //68
        public bool get_o_xemtonghoptheoloai_frmthuchiravien(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='68'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return false;
            }
        }
        public void set_o_xemtonghoptheoloai_frmthuchiravien(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "68", "frmthuchiravien.xemtonghoptheoloai", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //69
        public bool get_o_luuin_phieuthuphieuchi_frmthuchiravien(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='69'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_luuin_phieuthuphieuchi_frmthuchiravien(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "69", "frmthuchiravien.luuin_phieuthuphieuchi", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //70
        public bool get_o_luuin_hoadon_chitiet_frmthutrongoi(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='70'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_luuin_hoadon_chitiet_frmthutrongoi(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "70", "frmthutrongoi.luuin_hoadon_chitiet_trongoi", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //71
        public bool get_o_luuin_frmthuchiravien(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='71'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_luuin_frmthuchiravien(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "71", "frmthuchiravien.luuin", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //72
        public bool get_o_luuin_frmthutructiep(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='72'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_luuin_frmthutructiep(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "72", "frmthutructiep.luuin", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //73
        public bool get_o_luuin_frmthutrongoi(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='73'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_luuin_frmthutrongoi(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "73", "frmthutrongoi.luuin", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //74
        public bool get_o_fullscreen_frmphieuchi(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='74'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        public void set_o_fullscreen_frmphieuchi(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "74", "frmphieuchi.fullscreen", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //75
        public bool get_o_fullgrid_frmphieuchi(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='75'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        public void set_o_fullgrid_frmphieuchi(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "75", "frmphieuchi.fullgrid", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //76
        public bool get_o_fullgrid_frmdanhsachphieuchi(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='76'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        public void set_o_fullgrid_frmdanhsachphieuchi(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "76", "frmdanhsachphieuchi.fullgrid", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //77
        public bool get_o_fullgrid_frmdanhsachchophieuchi(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='77'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        public void set_o_fullgrid_frmdanhsachchophieuchi(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "77", "frmdanhsachchophieuchi.fullgrid", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //78
        public int get_o_limit_frmdanhsachphieuchi(string v_userid)
        {
            try
            {
                return int.Parse(get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='78'").Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                return 0;
            }
        }
        public void set_o_limit_frmdanhsachphieuchi(string v_userid, string v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "78", "frmdanhsachphieuchi.limit", v_giatri);
            }
            catch
            {
            }
        }
        //79
        public int get_o_limit_frmdanhsachchophieuchi(string v_userid)
        {
            try
            {
                return int.Parse(get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='79'").Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                return 100;
            }
        }
        public void set_o_limit_frmdanhsachchophieuchi(string v_userid, string v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "79", "frmdanhsachchophieuchi.limit", v_giatri);
            }
            catch
            {
            }
        }
        //80
        public bool get_o_show_hotkey_frmphieuchi(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='80'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_show_hotkey_frmphieuchi(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "80", "frmphieuchi.show_hotkey", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //81
        public bool get_o_luuin_hoadon_frmphieuchi(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='81'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_luuin_hoadon_frmphieuchi(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "81", "frmphieuchi.luuin_hoadon", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //82
        public bool get_o_luuin_chiphi_frmphieuchi(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='82'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_luuin_chiphi_frmphieuchi(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "82", "frmphieuchi.luuin_chiphi", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //83
        public bool get_o_xemtruockhiin_frmphieuchi(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='83'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_xemtruockhiin_frmphieuchi(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "83", "frmphieuchi.luuin_chiphi", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //84
        public bool get_o_locsotheoloai_frmphieuchi(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='84'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_locsotheoloai_frmphieuchi(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "84", "frmphieuchi.luuin_chiphi", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //85
        public bool get_o_show_hotkey_ksk_frmphieuchi(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='85'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return false;
            }
        }
        public void set_o_show_hotkey_ksk_frmphieuchi(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "85", "frmphieuchi.show_hotkey_ksk", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //86
        public bool get_o_addall_hotkey_frmphieuchi(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='86'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_addall_hotkey_frmphieuchi(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "86", "frmphieuchi.show_addall_hotkey", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //87
        public bool get_o_show_hotkey_toolbar_frmphieuchi(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='87'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_show_hotkey_toolbar_frmphieuchi(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "87", "frmphieuchi.show_hotkey_toolbar", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //88
        public bool get_o_luuin_frmphieuchi(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='88'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_luuin_frmphieuchi(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "88", "frmphieuchi.luuin", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //89
        public bool get_o_luuin_hoadon_frmthutamung(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='89'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_luuin_hoadon_frmthutamung(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "89", "frmthutamung.luuin_hoadon", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //90
        public bool get_o_luuin_hoadon_chitiet_frmthutamung(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='90'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_luuin_hoadon_chitiet_frmthutamung(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "90", "frmthutamung.luuin_hoadon_chitiet", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //91
        public int get_o_pchitiet_width_frmthutamung(string v_userid)
        {
            try
            {
                return int.Parse(get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='91'").Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                return 240;
            }
        }
        public void set_o_pchitiet_width_frmthutamung(string v_userid, int v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "91", "frmthutamung.pchitiet_width", v_giatri.ToString());
            }
            catch
            {
            }
        }
        //92
        public bool get_o_fullscreen_frmvienphiBHYT(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='92'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        public void set_o_fullscreen_frmvienphiBHYT(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "54", "frmvienphiBHYT.fullscreen", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //93
        public bool get_o_fullgrid_frmvienphiBHYT(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='93'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        public void set_o_fullgrid_frmvienphiBHYT(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "93", "frmvienphiBHYT.fullgrid", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //94
        public bool get_o_fullgrid_frmdanhsachBHYT(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='94'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        public void set_o_fullgrid_frmdanhsachBHYT(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "94", "frmdanhsachBHYT.fullgrid", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //95
        public bool get_o_fullgrid_frmdanhsachchoBHYT(string v_userid)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='95'").Tables[0].Rows[0][0].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }
        public void set_o_fullgrid_frmdanhsachchoBHYT(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "95", "frmdanhsachchoBHYT.fullgrid", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //96
        public int get_o_limit_frmdanhsachBHYT(string v_userid)
        {
            try
            {
                return int.Parse(get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='96'").Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                return 0;
            }
        }
        public void set_o_limit_frmdanhsachBHYT(string v_userid, string v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "96", "frmdanhsachBHYT.limit", v_giatri);
            }
            catch
            {
            }
        }
        //97
        public int get_o_limit_frmdanhsachchoBHYT(string v_userid)
        {
            try
            {
                return int.Parse(get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='97'").Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                return 100;
            }
        }
        public void set_o_limit_frmdanhsachchoBHYT(string v_userid, string v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "97", "frmdanhsachchoBHYT.limit", v_giatri);
            }
            catch
            {
            }
        }
        //98
        public bool get_o_show_hotkey_frmvienphiBHYT(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='98'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_show_hotkey_frmvienphiBHYT(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "98", "frmvienphiBHYT.show_hotkey", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //99
        public bool get_o_luuin_hoadon_frmvienphiBHYT(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='99'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_luuin_hoadon_frmvienphiBHYT(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "99", "frmvienphiBHYT.luuin_hoadon", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //100
        public bool get_o_luuin_chiphi_frmvienphiBHYT(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='100'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_luuin_chiphi_frmvienphiBHYT(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "100", "frmvienphiBHYT.luuin_chiphi", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //101
        public bool get_o_xemtruockhiin_frmvienphiBHYT(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='101'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_xemtruockhiin_frmvienphiBHYT(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "101", "frmvienphiBHYT.luuin_chiphi", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //102
        public bool get_o_locsotheoloai_frmvienphiBHYT(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='102'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_locsotheoloai_frmvienphiBHYT(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "102", "frmvienphiBHYT.luuin_chiphi", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //103
        public bool get_o_show_hotkey_ksk_frmvienphiBHYT(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='103'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return false;
            }
        }
        public void set_o_show_hotkey_ksk_frmvienphiBHYT(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "103", "frmvienphiBHYT.show_hotkey_ksk", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //104
        public bool get_o_addall_hotkey_frmvienphiBHYT(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='104'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_addall_hotkey_frmvienphiBHYT(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "104", "frmvienphiBHYT.show_addall_hotkey", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //105
        public bool get_o_show_hotkey_toolbar_frmvienphiBHYT(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='105'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_show_hotkey_toolbar_frmvienphiBHYT(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "105", "frmvienphiBHYT.show_hotkey_toolbar", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //106
        public bool get_o_xemtonghoptheoloai_frmvienphiBHYT(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='106'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return false;
            }
        }
        public void set_o_xemtonghoptheoloai_frmvienphiBHYT(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "106", "frmvienphiBHYT.xemtonghoptheoloai", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //107
        public bool get_o_luuin_phieuthuphieuchi_frmvienphiBHYT(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='107'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_luuin_phieuthuphieuchi_frmvienphiBHYT(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "107", "frmvienphiBHYT.luuin_phieuthuphieuchi", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }
        //108
        public bool get_o_luuin_frmvienphiBHYT(string v_userid)
        {
            try
            {
                return (get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=1 and ma='108'").Tables[0].Rows[0][0].ToString() == "1");
            }
            catch
            {
                return true;
            }
        }
        public void set_o_luuin_frmvienphiBHYT(string v_userid, bool v_giatri)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), 1, "108", "frmvienphiBHYT.luuin", v_giatri ? "1" : "0");
            }
            catch
            {
            }
        }

        public string get_v_optionform(int v_loai, string v_userid, string v_ma)
        {
            try
            {
                return get_data("select giatri from medibv.v_optionform where userid=" + v_userid + " and loai=" + v_loai.ToString() + " and ma='" + v_ma + "'").Tables[0].Rows[0][0].ToString().Trim();
            }
            catch
            {
                return "";
            }
        }
        public void set_v_optionform(int v_loai, string v_userid, string v_ma, bool v_val)
        {
            try
            {
                upd_v_optionform(decimal.Parse(v_userid), decimal.Parse(v_loai.ToString()), v_ma, "", v_val ? "1" : "0");
            }
            catch
            {
            }
        }
        //Truc tiep
        public bool tt_suahoadon(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TT_001") == "1";
        }
        public bool tt_suanoidunghoadon(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TT_002") == "1";
        }
        public bool tt_xoahoadon(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TT_003") == "1";
        }
        public bool tt_hoanhoadon(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TT_004") == "1";
        }
        public bool tt_gioihanvp(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TT_005") == "1";
        }
        public bool tt_nhapkhoaphong(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TT_006") == "1";
        }
        public bool tt_nhapbacsi(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TT_007") == "1";
        }
        public bool tt_nhaplydomien(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TT_008") == "1";
        }
        public bool tt_nhapduyetmien(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TT_009") == "1";
        }
        public bool tt_thuchidinh(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TT_010") == "1";
        }
        public bool tt_thutoatutruc(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TT_011") == "1";
        }
        public bool tt_thuchenhlech(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TT_017") == "1";
        }
        public bool tt_chonhapmoi(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TT_012") == "1";
        }
        public bool tt_mabntudong(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TT_018") == "1";
        }
        public bool tt_chokhongquatiepdon(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TT_013") == "1";
        }
        public bool tt_cokhambenh(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TT_014") == "1";
        }
        public bool tt_conamluu(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TT_015") == "1";
        }
        public bool tt_conhanbenh(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TT_016") == "1";
        }
        //SET TT
        public void set_tt_suahoadon(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "TT_001", v_val);
        }
        public void set_tt_suanoidunghoadon(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "TT_002", v_val);
        }
        public void set_tt_xoahoadon(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "TT_003", v_val);
        }
        public void set_tt_hoanhoadon(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "TT_004", v_val);
        }
        public void set_tt_gioihanvp(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "TT_005", v_val);
        }
        public void set_tt_nhapkhoaphong(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "TT_006", v_val);
        }
        public void set_tt_nhapbacsi(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "TT_007", v_val);
        }
        public void set_tt_nhaplydomien(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "TT_008", v_val);
        }
        public void set_tt_nhapduyetmien(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "TT_009", v_val);
        }
        public void set_tt_thuchidinh(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "TT_010", v_val);
        }
        public void set_tt_thutoatutruc(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "TT_011", v_val);
        }
        public void set_tt_thuchenhlech(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "TT_017", v_val);
        }
        public void set_tt_chonhapmoi(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "TT_012", v_val);
        }
        public void set_tt_chokhongquatiepdon(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "TT_013", v_val);
        }

        //Trongoi
        public bool tg_suahoadon(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TG_001") == "1";
        }
        public bool tg_suanoidunghoadon(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TG_002") == "1";
        }
        public bool tg_xoahoadon(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TG_003") == "1";
        }
        public bool tg_hoanhoadon(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TG_004") == "1";
        }
        public bool tg_gioihanvp(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TG_005") == "1";
        }
        public bool tg_nhapkhoaphong(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TG_006") == "1";
        }
        public bool tg_nhapbacsi(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TG_007") == "1";
        }
        public bool tg_nhaplydomien(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TG_008") == "1";
        }
        public bool tg_nhapduyetmien(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TG_009") == "1";
        }
        public bool tg_thuchidinh(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TG_010") == "1";
        }
        public bool tg_thuchenhlech(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TT_011") == "1";
        }
        public bool tg_chonhapmoi(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TG_012") == "1";
        }
        public bool tg_chokhongquatiepdon(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TG_013") == "1";
        }
        public bool tg_cokhambenh(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TG_014") == "1";
        }
        public bool tg_conamluu(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TG_015") == "1";
        }
        public bool tg_conhanbenh(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TG_016") == "1";
        }
        //SET TG
        public void set_tg_suahoadon(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "TG_001", v_val);
        }
        public void set_tg_suanoidunghoadon(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "TG_002", v_val);
        }
        public void set_tg_xoahoadon(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "TG_003", v_val);
        }
        public void set_tg_hoanhoadon(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "TG_004", v_val);
        }
        public void set_tg_gioihanvp(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "TG_005", v_val);
        }
        public void set_tg_nhapkhoaphong(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "TG_006", v_val);
        }
        public void set_tg_nhapbacsi(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "TG_007", v_val);
        }
        public void set_tg_nhaplydomien(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "TG_008", v_val);
        }
        public void set_tg_nhapduyetmien(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "TG_009", v_val);
        }
        public void set_tg_thuchidinh(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "TG_010", v_val);
        }
        public void set_tg_thuchenhlech(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "TG11", v_val);
        }
        public void set_tg_chonhapmoi(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "TG_012", v_val);
        }
        public void set_tg_chokhongquatiepdon(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "TG_013", v_val);
        }


        //TU
        public bool tu_suahoadon(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TU_001") == "1";
        }
        public bool tu_suanoidunghoadon(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TU_002") == "1";
        }
        public bool tu_xoahoadon(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TU_003") == "1";
        }
        public bool tu_hoanhoadon(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TU_004") == "1";
        }
        public bool tu_cotiepdon(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TU_005") == "1";
        }
        public bool tu_cokhambenh(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TU_006") == "1";
        }
        public bool tu_conamluu(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TU_007") == "1";
        }
        public bool tu_conhanbenh(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TU_008") == "1";
        }
        //TTRV
        public bool ttrv_suahoadon(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TTRV_001") == "1";
        }
        public bool ttrv_suanoidunghoadon(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TTRV_002") == "1";
        }
        public bool ttrv_xoahoadon(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TTRV_003") == "1";
        }
        public bool ttrv_hoanhoadon(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TTRV_004") == "1";
        }
        public bool ttrv_nhaplydomien(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TTRV_005") == "1";
        }
        public bool ttrv_nhapduyetmien(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TTRV_006") == "1";
        }
        public bool ttrv_cokhambenh(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TTRV_007") == "1";
        }
        public bool ttrv_conamluu(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TTRV_008") == "1";
        }
        public bool ttrv_conhanbenh(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TTRV_009") == "1";
        }
        public bool ttrv_thuchidinh(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TTRV_010") == "1";
        }
        public bool ttrv_thutoatutruc(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TTRV_011") == "1";
        }
        public bool ttrv_thuthuocthuongquy(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TTRV_012") == "1";
        }
        public bool ttrv_thuvienphikhoa(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TTRV_013") == "1";
        }
        public bool ttrv_thukhoatonghop(string v_userid)
        {
            return get_v_optionform(1, v_userid, "TTRV_014") == "1";
        }
        //PHIEU CHI
        public bool pc_suahoadon(string v_userid)
        {
            return get_v_optionform(1, v_userid, "PC_001") == "1";
        }
        public bool pc_suanoidunghoadon(string v_userid)
        {
            return get_v_optionform(1, v_userid, "PC_002") == "1";
        }
        public bool pc_xoahoadon(string v_userid)
        {
            return get_v_optionform(1, v_userid, "PC_003") == "1";
        }
        public bool pc_hoanhoadon(string v_userid)
        {
            return get_v_optionform(1, v_userid, "PC_004") == "1";
        }
        public bool pc_gioihanvp(string v_userid)
        {
            return get_v_optionform(1, v_userid, "PC_005") == "1";
        }
        public bool pc_nhapkhoaphong(string v_userid)
        {
            return get_v_optionform(1, v_userid, "PC_006") == "1";
        }
        public bool pc_nhapbacsi(string v_userid)
        {
            return get_v_optionform(1, v_userid, "PC_007") == "1";
        }
        public bool pc_nhaplydomien(string v_userid)
        {
            return get_v_optionform(1, v_userid, "PC_008") == "1";
        }
        public bool pc_nhapduyetmien(string v_userid)
        {
            return get_v_optionform(1, v_userid, "PC_009") == "1";
        }
        public bool pc_thuchidinh(string v_userid)
        {
            return get_v_optionform(1, v_userid, "PC_010") == "1";
        }
        public bool pc_thutoatutruc(string v_userid)
        {
            return get_v_optionform(1, v_userid, "PC_011") == "1";
        }
        public bool pc_thuchenhlech(string v_userid)
        {
            return get_v_optionform(1, v_userid, "PC_017") == "1";
        }
        public bool pc_chonhapmoi(string v_userid)
        {
            return get_v_optionform(1, v_userid, "PC_012") == "1";
        }
        public bool pc_chokhongquatiepdon(string v_userid)
        {
            return get_v_optionform(1, v_userid, "PC_013") == "1";
        }
        public bool pc_cokhambenh(string v_userid)
        {
            return get_v_optionform(1, v_userid, "PC_014") == "1";
        }
        public bool pc_conamluu(string v_userid)
        {
            return get_v_optionform(1, v_userid, "PC_015") == "1";
        }
        public bool pc_conhanbenh(string v_userid)
        {
            return get_v_optionform(1, v_userid, "PC_016") == "1";
        }
        //SET PC
        public void set_pc_suahoadon(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "PC_001", v_val);
        }
        public void set_pc_suanoidunghoadon(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "PC_002", v_val);
        }
        public void set_pc_xoahoadon(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "PC_003", v_val);
        }
        public void set_pc_hoanhoadon(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "PC_004", v_val);
        }
        public void set_pc_gioihanvp(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "PC_005", v_val);
        }
        public void set_pc_nhapkhoaphong(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "PC_006", v_val);
        }
        public void set_pc_nhapbacsi(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "PC_007", v_val);
        }
        public void set_pc_nhaplydomien(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "PC_008", v_val);
        }
        public void set_pc_nhapduyetmien(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "PC_009", v_val);
        }
        public void set_pc_thuchidinh(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "PC_010", v_val);
        }
        public void set_pc_thutoatutruc(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "PC_011", v_val);
        }
        public void set_pc_thuchenhlech(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "PC_017", v_val);
        }
        public void set_pc_chonhapmoi(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "PC_012", v_val);
        }
        public void set_pc_chokhongquatiepdon(string v_userid, bool v_val)
        {
            set_v_optionform(1, v_userid, "PC_013", v_val);
        }
        //Hoan tra
        public bool ht_suahoadon(string v_userid)
        {
            return get_v_optionform(1, v_userid, "HT_001") == "1";
        }
        public bool ht_phuchoihoatra(string v_userid)
        {
            return get_v_optionform(1, v_userid, "HT_002") == "1";
        }
        //BHYT
        public bool bhyt_suahoadon(string v_userid)
        {
            return get_v_optionform(1, v_userid, "BHYT_001") == "1";
        }
        public bool bhyt_suanoidunghoadon(string v_userid)
        {
            return get_v_optionform(1, v_userid, "BHYT_002") == "1";
        }
        public bool bhyt_xoahoadon(string v_userid)
        {
            return get_v_optionform(1, v_userid, "BHYT_003") == "1";
        }
        public bool bhyt_hoanhoadon(string v_userid)
        {
            return get_v_optionform(1, v_userid, "BHYT_004") == "1";
        }
        public bool bhyt_nhaplydomien(string v_userid)
        {
            return get_v_optionform(1, v_userid, "BHYT_005") == "1";
        }
        public bool bhyt_nhapduyetmien(string v_userid)
        {
            return get_v_optionform(1, v_userid, "BHYT_006") == "1";
        }
        public bool bhyt_cokhambenh(string v_userid)
        {
            return get_v_optionform(1, v_userid, "BHYT_007") == "1";
        }
        public bool bhyt_conamluu(string v_userid)
        {
            return get_v_optionform(1, v_userid, "BHYT_008") == "1";
        }
        public bool bhyt_conhanbenh(string v_userid)
        {
            return get_v_optionform(1, v_userid, "BHYT_009") == "1";
        }
        public bool bhyt_thuchidinh(string v_userid)
        {
            return get_v_optionform(1, v_userid, "BHYT_010") == "1";
        }
        public bool bhyt_thutoatutruc(string v_userid)
        {
            return get_v_optionform(1, v_userid, "BHYT_011") == "1";
        }
        public bool bhyt_thuthuocthuongquy(string v_userid)
        {
            return get_v_optionform(1, v_userid, "BHYT_012") == "1";
        }
        public bool bhyt_thuvienphikhoa(string v_userid)
        {
            return get_v_optionform(1, v_userid, "BHYT_013") == "1";
        }
        public bool bhyt_thukhoatonghop(string v_userid)
        {
            return get_v_optionform(1, v_userid, "BHYT_014") == "1";
        }
        public bool bhyt_thutoathuocbhyt(string v_userid)
        {
            return get_v_optionform(1, v_userid, "BHYT_015") == "1";
        }
        public bool bhyt_thutoathuocduocphat(string v_userid)
        {
            return get_v_optionform(1, v_userid, "BHYT_016") == "1";
        }

        #endregion

        #region  NGÀY HIỆN HÀNH SERVER

        public string s_curyy
        {
            get
            {
                try
                {
                    return get_data("select to_char(now(),'yy')").Tables[0].Rows[0][0].ToString();
                }
                catch
                {
                    return DateTime.Now.Year.ToString().Substring(2, 2);
                }
            }
        }
        public string s_curyyyy
        {
            get
            {
                try
                {
                    return get_data("select to_char(now(),'yyyy')").Tables[0].Rows[0][0].ToString();
                }
                catch
                {
                    return DateTime.Now.Year.ToString();
                }
            }
        }
        public string s_curmmyy
        {
            get
            {
                try
                {
                    return get_data("select to_char(now(),'mmyy')").Tables[0].Rows[0][0].ToString();
                }
                catch
                {
                    return DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString().Substring(2, 2);
                }
            }
        }
        public string s_curmmyyyy
        {
            get
            {
                try
                {
                    return get_data("select to_char(now(),'mmyyyy')").Tables[0].Rows[0][0].ToString();
                }
                catch
                {
                    return DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString();
                }
            }
        }
        public string s_curddmmyy
        {
            get
            {
                try
                {
                    return get_data("select to_char(now(),'ddmmyy')").Tables[0].Rows[0][0].ToString();
                }
                catch
                {
                    return DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString().Substring(2, 2);
                }
            }
        }
        public string s_curddmmyyyy
        {
            get
            {
                try
                {
                    return get_data("select to_char(now(),'ddmmyyyy')").Tables[0].Rows[0][0].ToString();
                }
                catch
                {
                    return DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString();
                }
            }
        }
        public string s_curdd_mm_yyyy
        {
            get
            {
                try
                {
                    return get_data("select to_char(now(),'dd/mm/yyyy')").Tables[0].Rows[0][0].ToString();
                }
                catch
                {
                    return DateTime.Now.Day.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Year.ToString();
                }
            }
        }
        public string s_curdd_mm_yyyy_hh24_mi
        {
            get
            {
                try
                {
                    return get_data("select to_char(now(),'dd/mm/yyyy hh24:mi')").Tables[0].Rows[0][0].ToString();
                }
                catch
                {
                    return DateTime.Now.Day.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Year.ToString() + " " + DateTime.Now.Hour.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0');
                }
            }
        }
        public DateTime s_server_date
        {
            get
            {
                try
                {
                    string r = get_data("select to_char(now(),'dd/mm/yyyy hh24:mi')").Tables[0].Rows[0][0].ToString();
                    return new DateTime(int.Parse(r.Substring(6, 4)), int.Parse(r.Substring(3, 2)), int.Parse(r.Substring(0, 2)));
                }
                catch
                {
                    return DateTime.Now;
                }
            }
        }
        public DateTime s_server_datetime
        {
            get
            {
                try
                {
                    string r = get_data("select to_char(now(),'dd/mm/yyyy hh24:mi')").Tables[0].Rows[0][0].ToString();
                    return new DateTime(int.Parse(r.Substring(6, 4)), int.Parse(r.Substring(3, 2)), int.Parse(r.Substring(0, 2)), int.Parse(r.Substring(11, 2)), int.Parse(r.Substring(14, 2)), 0);
                }
                catch
                {
                    return DateTime.Now;
                }
            }
        }
        public string get_mmyy(string v_ngay)
        {
            try
            {
                return v_ngay.Substring(3, 2) + v_ngay.Substring(8, 2);
            }
            catch
            {
                return s_curmmyy;
            }
        }

        #endregion  NGÀY HIỆN HÀNH SERVER

        #region CÁC HÀM VỀ NGÀY

        public DateTime f_parse_date(string v_ngay10)
        {
            try
            {
                return new DateTime(int.Parse(v_ngay10.Substring(6, 4)), int.Parse(v_ngay10.Substring(3, 2)), int.Parse(v_ngay10.Substring(0, 2)));
            }
            catch
            {
                return DateTime.Now;
            }
        }
        public string f_string_date(string v_date)
        {
            string r = "";
            if (v_date != "")
            {
                DateTime ad;
                try
                {
                    string[] ata = v_date.Split('/');
                    ad = new DateTime(int.Parse(ata[2]), int.Parse(ata[1]), int.Parse(ata[0]));
                    r = ad.Day.ToString().PadLeft(2, '0') + "/" + ad.Month.ToString().PadLeft(2, '0') + "/" + ad.Year.ToString().PadLeft(2, '0');
                }
                catch
                {
                    try
                    {
                        ad = new DateTime(int.Parse(v_date.Substring(4, 4)), int.Parse(v_date.Substring(2, 2)), int.Parse(v_date.Substring(0, 2)));
                        r = ad.Day.ToString().PadLeft(2, '0') + "/" + ad.Month.ToString().PadLeft(2, '0') + "/" + ad.Year.ToString().PadLeft(2, '0');
                    }
                    catch
                    {
                        try
                        {
                            ad = new DateTime(int.Parse("20" + v_date.Substring(4, 2)), int.Parse(v_date.Substring(2, 2)), int.Parse(v_date.Substring(0, 2)));
                            r = ad.Day.ToString().PadLeft(2, '0') + "/" + ad.Month.ToString().PadLeft(2, '0') + "/" + ad.Year.ToString().PadLeft(2, '0');
                        }
                        catch
                        {
                        }
                    }
                }
            }
            return r;
        }
        public string f_ngay10(DateTime v_date)
        {
            string art = "";
            try
            {
                art = v_date.Day.ToString().PadLeft(2, '0') + "/" + v_date.Month.ToString().PadLeft(2, '0') + "/" + v_date.Year.ToString();
            }
            catch
            {
                art = "";
            }
            return art;
        }
        public string f_ngay16(DateTime v_date)
        {
            string art = "";
            try
            {
                art = v_date.Day.ToString().PadLeft(2, '0') + "/" + v_date.Month.ToString().PadLeft(2, '0') + "/" + v_date.Year.ToString() + " " + v_date.Hour.ToString().PadLeft(2, '0') + ":" + v_date.Minute.ToString().PadLeft(2, '0');
            }
            catch
            {
                art = "";
            }
            return art;
        }
        public string tinhtuoi(string v_ngay_or_nam, int v_max_tuoi)
        {
            //ngay_or_nam:tuoi:thang:ngay
            string art = "", art1 = "";
            int n = 0, atuoi = 0, athang = 0, angay = 0;
            art = f_string_date(v_ngay_or_nam);
            DateTime adt;
            if (art == "")
            {
                try
                {
                    n = int.Parse(v_ngay_or_nam);
                }
                catch
                {
                    n = 0;
                }
                if (n > 0 && DateTime.Now.Year - n <= v_max_tuoi)
                {
                    art = n.ToString();
                }
            }
            else
            {
                adt = f_parse_date(art);
                TimeSpan ats = DateTime.Now - adt;
                if (ats.Days / 360 > v_max_tuoi)
                {
                    art = "";
                }
            }
            if (art.Length > 4)
            {
                adt = f_parse_date(art);
                atuoi = DateTime.Now.Year - adt.Year;
                if (atuoi <= 0)
                {
                    TimeSpan ats = DateTime.Now - adt;
                    if (ats.Days / 30 > 0)
                    {
                        athang = ats.Days / 30;
                        art1 = art + ":?:" + athang.ToString() + ":?";
                    }
                    else
                        if (ats.Days > 0)
                        {
                            angay = ats.Days;
                            art1 = art + ":?:?:" + angay.ToString();
                        }
                        else
                        {
                            angay = 1;
                            art = s_curdd_mm_yyyy;
                            art1 = art + ":?:?:" + angay.ToString();
                        }
                }
                else
                {
                    art1 = art + ":" + atuoi.ToString() + ":?:?";
                }
            }
            else
                if (art.Length > 0)
                {
                    atuoi = DateTime.Now.Year - int.Parse(art);
                    if (atuoi <= 0)
                    {
                        atuoi = 1;
                    }
                    art1 = art + ":" + atuoi.ToString() + ":?:?";
                }
                else
                {
                    art1 = "?:?:?:?";
                }
            return art1;
        }
        public string tinhngay(string v_tuoi, string v_loaituoi)
        {
            //ngay_or_nam:tuoi:thang:ngay
            string art = "";
            int n = 0;
            try
            {
                n = int.Parse(v_tuoi);
                if (n > 0)
                {
                    DateTime adt = DateTime.Now;
                    switch (v_loaituoi)
                    {
                        case "1"://Tuoi
                            adt = adt.AddYears((-1 * n));
                            art = adt.Day.ToString().PadLeft(2, '0') + "/" + adt.Month.ToString().PadLeft(2, '0') + "/" + adt.Year.ToString().PadLeft(2, '0') + ":" + n.ToString() + ":?:?";
                            break;
                        case "2"://Thang
                            adt = adt.AddMonths((-1 * n));
                            if (n > 12)
                            {
                                art = adt.Day.ToString().PadLeft(2, '0') + "/" + adt.Month.ToString().PadLeft(2, '0') + "/" + adt.Year.ToString().PadLeft(2, '0') + ":" + (n / 12).ToString() + ":?:?";
                            }
                            else
                            {
                                art = adt.Day.ToString().PadLeft(2, '0') + "/" + adt.Month.ToString().PadLeft(2, '0') + "/" + adt.Year.ToString().PadLeft(2, '0') + ":?:" + n.ToString() + ":?";
                            }
                            break;
                        case "3"://Ngay
                        case "4"://Gio
                            adt = adt.AddDays((-1 * n));
                            if (n > 365)
                            {
                                art = adt.Day.ToString().PadLeft(2, '0') + "/" + adt.Month.ToString().PadLeft(2, '0') + "/" + adt.Year.ToString().PadLeft(2, '0') + ":" + (n / 365).ToString() + ":?:?";
                            }
                            else
                                if (n > 30)
                                {
                                    art = adt.Day.ToString().PadLeft(2, '0') + "/" + adt.Month.ToString().PadLeft(2, '0') + "/" + adt.Year.ToString().PadLeft(2, '0') + ":?:" + (n / 30).ToString() + ":?";
                                }
                                else
                                {
                                    art = adt.Day.ToString().PadLeft(2, '0') + "/" + adt.Month.ToString().PadLeft(2, '0') + "/" + adt.Year.ToString().PadLeft(2, '0') + ":?:?:" + n.ToString();
                                }
                            break;
                    }
                }
            }
            catch
            {
                art = "";
            }
            if (art == "")
            {
                art = "?:?:?:?";
            }
            return art;
        }
        public int get_songay(string v_tn10, string v_dn10)
        {
            DateTime adt = f_parse_date(v_tn10);
            DateTime adt1 = f_parse_date(v_dn10);
            TimeSpan ats = adt1 - adt;
            int n = ats.Days + 1;
            return n;
        }
        #endregion CÁC HÀM VỀ NGÀY

        #region GIÁ TRỊ MẶC ĐỊNH
        public void f_macdinh_v_nhomdlogin()
        {
            upd_v_nhomdlogin(1, 1, "ADMINDBA", "Quản trị cơ sở dữ liệu", "", "", "");
            upd_v_nhomdlogin(2, 2, "ADMINAPP", "Quản trị chương trình", "", "", "");
            upd_v_nhomdlogin(3, 3, "ADMINDEP", "Quản trị khoa, phòng ban", "", "", "");
            upd_v_nhomdlogin(4, 4, "USER", "Nhân viên", "Nhân viên nhập liệu vi tính", "", "");
        }
        #endregion GIÁ TRỊ MẶC ĐỊNH

        #region CẬP NHẬT CẤU TRÚC TABLES
        public void drop_schema(string v_schema)
        {
            try
            {
                execute_data("drop schema " + v_schema + " cascade");
            }
            catch
            {
            }
        }
        public void drop_table(string v_schema, string v_table)
        {
            execute_data("drop table " + v_schema + "." + v_table + " cascade");
        }
        public void create_schema_vp(string v_mmyy)
        {
            execute_data("create schema " + s_schema_mmyy(v_mmyy) + " authorization " + m_db_database + "");
        }

        public void create_tables_vp()
        {
            try
            {
                execute_data("CREATE TABLE " + m_db_schemaroot + ".vp_treemenu(id numeric(5), id_cha numeric(5), stt numeric(5), ten text, sql text, tenfield text, captionfield text, width text, report text,readonly numeric(1) default 0, CONSTRAINT pk_vp_treemenu PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".vp_treemenu OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".vp_null(id text, ten text, readonly numeric(1) default 0, CONSTRAINT pk_vp_null PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".vp_null OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".v_khongdau(codau text, khongdau text, CONSTRAINT pk_v_khongdau PRIMARY KEY (codau)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".v_khongdau OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".v_phanquyen(userid numeric(5), menuname text, chon numeric(1) DEFAULT 0, chitiet text, CONSTRAINT pk_v_phanquyen PRIMARY KEY (userid,menuname)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".v_phanquyen OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".v_phanquyennhom(id_nhom numeric(5), menuname text, chon numeric(1) DEFAULT 0, chitiet text, CONSTRAINT pk_v_phanquyennhom PRIMARY KEY (id_nhom,menuname)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".v_phanquyennhom OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".v_nhomdlogin(id numeric(5),nhom numeric(1),ma varchar(20), ten text, diengiai text, id_bv_so varchar(4000) DEFAULT 0,right_ varchar(4000), readonly numeric(1) DEFAULT 0,CONSTRAINT pk_v_nhomdlogin PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".v_nhomdlogin OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".v_dlogin(id numeric(5) NOT NULL DEFAULT 0,id_nhom numeric(5) NOT NULL DEFAULT 0,hoten text,userid varchar(20),password_ varchar(20),right_ text,loaivp text,mucvp text,loai text,madoituong varchar(20),admin numeric(1) DEFAULT 0,capso numeric(6) DEFAULT 0,nhomvp text,nhombc text,id_nhom numeric(5) DEFAULT 0,CONSTRAINT pk_v_dlogin PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".v_dlogin OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".v_capid(ma numeric(3) NOT NULL DEFAULT 0,ten varchar(20),id numeric(12) DEFAULT 0,computer varchar(20) NOT NULL DEFAULT '?'::character varying,CONSTRAINT pk_v_capid PRIMARY KEY (computer, ma)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".v_capid OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".v_dmlydonopthem(id numeric(2) DEFAULT 0,ten text,ngayud timestamp DEFAULT now(), readonly numeric(1) default 0, CONSTRAINT pk_v_dmlydonopthem PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".v_dmlydonopthem OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".v_dmlydothieu(id numeric(2) NOT NULL DEFAULT 0,ten text,ngayud timestamp DEFAULT now(), readonly numeric(1) default 0,CONSTRAINT pk_v_dmlydothieu PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".v_dmlydothieu OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".v_dsduyet(ma numeric(4) NOT NULL DEFAULT 0,ten text,ngayud timestamp DEFAULT now(),readonly numeric(1) default 0, CONSTRAINT pk_v_dsduyet PRIMARY KEY (ma)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".v_dsduyet OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".v_error(message text,computer varchar(20),tables varchar(20),ngayud timestamp DEFAULT now()) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".v_error OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".v_ghichu(id numeric(1) NOT NULL DEFAULT 0,ten text,readonly numeric(1) defaulu 0,CONSTRAINT pk_v_ghichu PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".v_ghichu OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".v_nhombhyt(id numeric(2) NOT NULL DEFAULT 0,stt numeric(2) DEFAULT 0,ten text, viettat text,ngayud timestamp DEFAULT now(),readonly numeric(1) default 0,CONSTRAINT pk_v_nhombhyt PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".v_nhombhyt OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".v_nhomvp(ma numeric(3) NOT NULL DEFAULT 0,ten text,stt numeric(3) DEFAULT 0,idnhombhyt numeric(2) DEFAULT 0,matat varchar(10),dongia numeric(10) DEFAULT 0,ngayud timestamp DEFAULT now(),trongoi text,readonly numeric(1) default 0,CONSTRAINT pk_v_nhomvp PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".v_nhomvp OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".v_loaivp(id numeric(3) NOT NULL DEFAULT 0,id_nhom numeric(3) DEFAULT 0,stt numeric(3) DEFAULT 0,ma text,ten text,userid numeric(5) DEFAULT 0,ngayud timestamp DEFAULT now(),computer varchar(20),readonly numeric(1) default 0,CONSTRAINT pk_v_loaivp PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".v_loaivp OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".v_giavp(id numeric(7) NOT NULL DEFAULT 0,id_loai numeric(3) DEFAULT 0,stt numeric(5) DEFAULT 0,ma text,ten text,dvt varchar(20),gia_th numeric(10) DEFAULT 0,gia_bh numeric(10) DEFAULT 0,gia_dv numeric(10) DEFAULT 0,bhyt numeric(3) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp DEFAULT now(),gia_nn numeric(10) DEFAULT 0,gia_cs numeric(10) DEFAULT 0,vattu_th numeric(10) DEFAULT 0,vattu_bh numeric(10) DEFAULT 0,vattu_dv numeric(10) DEFAULT 0,vattu_nn numeric(10) DEFAULT 0,vattu_cs numeric(10) DEFAULT 0, loaibn numeric(1) DEFAULT 0,theobs numeric(1) DEFAULT 0,trongoi numeric(1) DEFAULT 0,chenhlech numeric(1) DEFAULT 0,loaitrongoi numeric(1) DEFAULT 0,locthe text,readonly numeric(1) default 0,CONSTRAINT pk_v_giavp PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".v_giavp OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".v_giavattu(id numeric(7) NOT NULL DEFAULT 0,mavp numeric(7) NOT NULL DEFAULT 0,stt numeric(5) DEFAULT 0,soluong numeric(7) DEFAULT 0,gia_th numeric(10) DEFAULT 0,gia_bh numeric(10) DEFAULT 0,gia_dv numeric(10) DEFAULT 0,gia_nn numeric(10) DEFAULT 0,CONSTRAINT pk_v_giavattu PRIMARY KEY (id,mavp)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".v_giavattu OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".v_khambenh(ngay timestamp NOT NULL,kyhieu varchar(20),tu numeric(7) DEFAULT 0,den numeric(7) DEFAULT 0,nguoilon numeric(7) DEFAULT 0,treem numeric(7) DEFAULT 0,userid numeric(5) NOT NULL DEFAULT 0,ngayud timestamp DEFAULT now()) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".v_khambenh OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".v_loaibn(id numeric(1) NOT NULL DEFAULT 0,ten text,readonly numeric(1) default 0,CONSTRAINT pk_v_loaibn PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".v_loaibn OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".v_lydomien(id numeric(2) NOT NULL DEFAULT 0,ten text,readonly numeric(1) default 0, ngayud timestamp DEFAULT now(),CONSTRAINT pk_v_lydomien PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".v_lydomien OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".v_lydonopthem(id numeric(12) NOT NULL DEFAULT 0,id_lydo numeric(2) DEFAULT 0,ngayud timestamp DEFAULT now(),CONSTRAINT pk_v_lydonopthem PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".v_lydonopthem OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".v_lydothieu(id numeric(12) NOT NULL DEFAULT 0,id_lydo numeric(2) DEFAULT 0,ngayud timestamp DEFAULT now(),CONSTRAINT pk_v_lydothieu PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".v_lydothieu OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".v_paid(mabn varchar(8) NOT NULL,mavaovien numeric(11) NOT NULL DEFAULT 0,maql numeric(11) NOT NULL DEFAULT 0,idkhoa numeric(11) NOT NULL DEFAULT 0,ngayvao timestamp NOT NULL,ngayra timestamp NOT NULL) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".v_paid OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".v_quyenso(id numeric(7) NOT NULL DEFAULT 0,sohieu varchar(20),tu numeric(10) DEFAULT 0,den numeric(10) DEFAULT 0,soghi numeric(10) DEFAULT 0,dangsd numeric(1) DEFAULT 0,khambenh numeric(1) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp DEFAULT now(),loai varchar(20)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".v_quyenso OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".v_tenloaivp(ma numeric(2) NOT NULL DEFAULT 0,ten text,readonly numeric(1) default 0,ngayud timestamp DEFAULT now()) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".v_tenloaivp OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".v_theodoicongno(mabn varchar(8),mavaovien numeric(11) DEFAULT 0,maql numeric(11) NOT NULL DEFAULT 0,idkhoa numeric(11) NOT NULL DEFAULT 0,madoituong numeric(1) NOT NULL DEFAULT 0,thuoc numeric(15) DEFAULT 0,vienphi numeric(15) DEFAULT 0,tamung numeric(10) DEFAULT 0,mien numeric(15) DEFAULT 0,done numeric(1) DEFAULT 0) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".v_theodoicongno OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".v_thongso(id numeric(3) NOT NULL DEFAULT 0,loai text,ten text,ngayud timestamp DEFAULT now()) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".v_thongso OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".v_trongoi(id numeric(7) NOT NULL DEFAULT 0,id_nhom numeric(3) NOT NULL DEFAULT 0,id_loai numeric(3) NOT NULL DEFAULT 0,id_gia numeric(7) NOT NULL DEFAULT 0,sotien numeric(12) DEFAULT 0,stt numeric(3) DEFAULT 0) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".v_trongoi OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".v_tygia(ngay timestamp NOT NULL,tygia numeric(10) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp DEFAULT now()) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".v_tygia OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".v_viettat(stt numeric(7), ma text, ten text, readonly numeric(1) DEFAULT 0,CONSTRAINT pk_v_viettat PRIMARY KEY (ma)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".v_viettat OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".vp_license(computer_key text NOT NULL,license_key text) WITHOUT OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".vp_license OWNER TO " + m_db_database + "");
            }
            catch
            {
            }
        }
        public void f_create_v_khoaso()
        {
            execute_data("CREATE TABLE " + m_db_schemaroot + ".v_khoaso(userid numeric(5),ngay varchar2(10), songay numeric(3) default 0, constraint pk_v_khoaso primary key(userid)) WITH OIDS");
            execute_data("ALTER TABLE " + m_db_schemaroot + ".v_khoaso OWNER TO " + m_db_database + "");
        }
        public void f_upd_v_khoaso()
        {
            try
            {
                try
                {
                    int atmp = get_data("select songay from medibv.v_khoaso limit 1").Tables[0].Rows.Count;
                }
                catch
                {
                    f_create_v_khoaso();
                }
                execute_data("insert into medibv.v_khoaso(userid,ngay,songay) select id,'xx/xx/xxxx',0 from medibv.v_dlogin where id not in (select id from medibv.v_khoaso)");
                foreach (DataRow r in get_data("select userid,songay from medibv.v_khoaso where songay>0").Tables[0].Rows)
                {
                    execute_data("update medibv.v_khoaso set ngay=to_char(now()-" + r["songay"].ToString() + ",'dd/mm/yyyy') where userid=" + r["userid"].ToString());
                }
            }
            catch
            {
            }
        }
        public void f_create_v_nhomdlogin()
        {
            execute_data("CREATE TABLE " + m_db_schemaroot + ".v_nhomdlogin(id numeric(5),nhom numeric(1),ma varchar(20), ten text, diengiai text, id_bv_so varchar(4000) DEFAULT 0,right_ varchar(4000), readonly numeric(1) DEFAULT 0,CONSTRAINT pk_v_nhomdlogin PRIMARY KEY (id)) WITH OIDS");
            execute_data("ALTER TABLE " + m_db_schemaroot + ".v_nhomdlogin OWNER TO " + m_db_database + "");
            execute_data("ALTER TABLE " + m_db_schemaroot + ".v_dlogin add id_nhom numeric(5) default 0");
            execute_data("update " + m_db_schemaroot + ".v_dlogin set id_nhom=1 where id_nhom is null or id_nhom=0");
        }
        public void f_create_v_optionhotkey()
        {
            execute_data("CREATE TABLE " + m_db_schemaroot + ".v_optionhotkey(userid numeric(5),loai numeric(2),hotkey varchar(10), id numeric(7), ghichu text, CONSTRAINT pk_v_optionhotkey PRIMARY KEY (userid,loai,hotkey,id)) WITH OIDS");
            execute_data("ALTER TABLE " + m_db_schemaroot + ".v_optionhotkey OWNER TO " + m_db_database + "");
        }
        public void f_create_v_optionhotkey_ksk()
        {
            execute_data("CREATE TABLE " + m_db_schemaroot + ".v_optionhotkey_ksk(userid numeric(5),loai numeric(2),hotkey varchar(10), id numeric(7), ghichu text, CONSTRAINT pk_v_optionhotkey_ksk PRIMARY KEY (userid,loai,hotkey,id)) WITH OIDS");
            execute_data("ALTER TABLE " + m_db_schemaroot + ".v_optionhotkey_ksk OWNER TO " + m_db_database + "");
        }
        public void f_create_v_optionlien()
        {
            execute_data("CREATE TABLE " + m_db_schemaroot + ".v_optionlien(stt numeric(5),ten text, tenreport text) WITH OIDS");
            execute_data("ALTER TABLE " + m_db_schemaroot + ".v_optionlien OWNER TO " + m_db_database + "");
        }
        public void f_Macdinh_Solien()
        {
            string atmp = "";
            execute_data("delete from medibv.v_optionlien");

            atmp = sys_report_thutructiep;
            upd_v_optionlien(1, "Liên 1: Giao cho bệnh nhân", atmp);
            upd_v_optionlien(2, "Liên 2: Lưu", atmp);

            atmp = sys_report_thutamung;
            upd_v_optionlien(1, "Liên 1: Giao cho bệnh nhân", atmp);
            upd_v_optionlien(2, "Liên 2: Lưu", atmp);

            atmp = sys_report_ravien;
            upd_v_optionlien(1, "Liên 1: Giao cho bệnh nhân", atmp);
            upd_v_optionlien(2, "Liên 2: Lưu", atmp);

            atmp = sys_report_ravien_thuong;
            upd_v_optionlien(1, "Liên 1: Giao cho bệnh nhân", atmp);
            upd_v_optionlien(2, "Liên 2: Lưu", atmp);

            atmp = sys_report_ravien_chi;
            upd_v_optionlien(1, "Liên 1: Giao cho bệnh nhân", atmp);
            upd_v_optionlien(2, "Liên 2: Lưu", atmp);

            atmp = sys_report_phieuchi;
            upd_v_optionlien(1, "Liên 1: Giao cho bệnh nhân", atmp);
            upd_v_optionlien(2, "Liên 2: Lưu", atmp);

            atmp = sys_report_thutrongoi;
            upd_v_optionlien(1, "Liên 1: Giao cho bệnh nhân", atmp);
            upd_v_optionlien(2, "Liên 2: Lưu", atmp);

            atmp = sys_report_bhyt;
            upd_v_optionlien(1, "Liên 1: Giao cho bệnh nhân", atmp);
            upd_v_optionlien(2, "Liên 2: Lưu", atmp);
        }
        public DataSet f_get_hotkey(string v_userid, string v_loai)
        {
            string asql = "", auserid = "", aloai = "";
            try
            {
                auserid = decimal.Parse(v_userid).ToString();
            }
            catch
            {
                auserid = "-1";
            }
            try
            {
                aloai = decimal.Parse(v_loai).ToString();
            }
            catch
            {
                aloai = "-1";
            }
            asql = "select userid,loai,trim(hotkey) as hotkey,id,trim(ghichu) as ghichu from medibv.v_optionhotkey where userid=" + v_userid + " and loai = " + v_loai;
            DataSet ads = null;
            try
            {
                ads = get_data(asql);
                if (ads == null)
                {
                    f_create_v_optionhotkey();
                    ads = get_data(asql);
                }
            }
            catch
            {
                f_create_v_optionhotkey();
                ads = get_data(asql);
            }
            return ads;
        }
        public DataSet f_get_hotkey_frmthutructiep(string v_userid)
        {
            return f_get_hotkey(v_userid, s_loaiform_thutructiep);
        }
        public DataSet f_get_hotkey_frmthuchiravien(string v_userid)
        {
            return f_get_hotkey(v_userid, s_loaiform_thuchiravien);
        }
        public DataSet f_get_hotkey_frmthutrongoi(string v_userid)
        {
            return f_get_hotkey(v_userid, s_loaiform_thutrongoi);
        }
        public DataSet f_get_hotkey_frmphieuchi(string v_userid)
        {
            return f_get_hotkey(v_userid, s_loaiform_phieuchi);
        }
        public DataSet f_get_hotkey_frmvienphibhyt(string v_userid)
        {
            return f_get_hotkey(v_userid, s_loaiform_bhyt);
        }
        public DataSet f_get_hotkey_ksk(string v_userid, string v_loai)
        {
            string asql = "", auserid = "", aloai = "";
            try
            {
                auserid = decimal.Parse(v_userid).ToString();
            }
            catch
            {
                auserid = "-1";
            }
            try
            {
                aloai = decimal.Parse(v_loai).ToString();
            }
            catch
            {
                aloai = "-1";
            }
            asql = "select userid,loai,trim(hotkey) as hotkey,id,trim(ghichu) as ghichu from medibv.v_optionhotkey_ksk where userid=" + v_userid + " and loai = " + v_loai;
            DataSet ads = null;
            try
            {
                ads = get_data(asql);
                if (ads == null)
                {
                    f_create_v_optionhotkey_ksk();
                    ads = get_data(asql);
                }
            }
            catch
            {
                f_create_v_optionhotkey_ksk();
                ads = get_data(asql);
            }
            return ads;
        }
        public DataSet f_get_hotkey_ksk_frmthutructiep(string v_userid)
        {
            return f_get_hotkey_ksk(v_userid, s_loaiform_thutructiep);
        }
        public DataSet f_get_hotkey_ksk_frmthuchiravien(string v_userid)
        {
            return f_get_hotkey_ksk(v_userid, s_loaiform_thuchiravien);
        }
        public DataSet f_get_hotkey_ksk_frmthutrongoi(string v_userid)
        {
            return f_get_hotkey_ksk(v_userid, s_loaiform_thutrongoi);
        }
        public DataSet f_get_hotkey_ksk_frmphieuchi(string v_userid)
        {
            return f_get_hotkey_ksk(v_userid, s_loaiform_phieuchi);
        }
        public DataSet f_get_hotkey_ksk_frmvienphibhyt(string v_userid)
        {
            return f_get_hotkey_ksk(v_userid, s_loaiform_bhyt);
        }
        public DataSet f_get_solien(string v_report)
        {
            return get_data("select ten from medibv.v_optionlien where tenreport = '" + v_report + "' order by stt");
        }
        public DataSet f_get_solien()
        {
            return get_data("select * from medibv.v_optionlien");
        }

        public void create_tables_vp_mmyy(string v_mmyy)
        {
            try
            {
                string aschema = s_schema_mmyy(v_mmyy);

                execute_data("CREATE TABLE " + aschema + ".v_bhyt(id numeric(12) NOT NULL DEFAULT 0,sothe varchar(16),maphu numeric(1) DEFAULT 0,mabv varchar(8),noigioithieu varchar(8)) WITH OIDS");
                execute_data("ALTER TABLE " + aschema + ".v_bhyt OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + aschema + ".v_chidinh(id numeric(12) NOT NULL DEFAULT 0,mabn varchar(8),mavaovien numeric(11) DEFAULT 0,maql numeric(11) DEFAULT 0,idkhoa numeric(11) DEFAULT 0,ngay timestamp,loai numeric(1) DEFAULT 0,makp varchar(2),madoituong numeric(2) DEFAULT 0,mavp numeric(7) DEFAULT 0,soluong numeric(7) DEFAULT 0,dongia numeric(11) DEFAULT 0,paid numeric(1) DEFAULT 0,done numeric(1) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp DEFAULT now(),vattu numeric(10) DEFAULT 0,tinhtrang numeric(1) DEFAULT 0,thuchien numeric(1) DEFAULT 0,computer varchar(20)) WITH OIDS");
                execute_data("ALTER TABLE " + aschema + ".v_chidinh OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + aschema + ".v_congno(mabn varchar(8),mavaovien numeric(11) DEFAULT 0,maql numeric(11) NOT NULL DEFAULT 0,idkhoa numeric(11) NOT NULL DEFAULT 0,mavp numeric(7) NOT NULL DEFAULT 0,sotien numeric(15,4) DEFAULT 0,dathu numeric(15,4) DEFAULT 0) WITH OIDS");
                execute_data("ALTER TABLE " + aschema + ".v_congno OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + aschema + ".v_error(message text,computer varchar(20),tables varchar(20),ngayud timestamp DEFAULT now()) WITH OIDS");
                execute_data("ALTER TABLE " + aschema + ".v_error OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + aschema + ".v_giuong(id numeric(12) NOT NULL DEFAULT 0,mavp numeric(7) NOT NULL DEFAULT 0,ngay timestamp NOT NULL,dongia numeric(10) DEFAULT 0) WITH OIDS");
                execute_data("ALTER TABLE " + aschema + ".v_giuong OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + aschema + ".v_hoantra(id numeric(12) NOT NULL DEFAULT 0,quyenso numeric(7) DEFAULT 0,sobienlai numeric(7) DEFAULT 0,ngay timestamp,mabn varchar(8),mavaovien numeric(11) DEFAULT 0,maql numeric(11) DEFAULT 0,hoten text,sotien numeric(15,4) DEFAULT 0,ghichu text,userid numeric(5) DEFAULT 0,ngayud timestamp DEFAULT now(),loai numeric(1) DEFAULT 0,loaibn numeric(2) DEFAULT 0) WITH OIDS");
                execute_data("ALTER TABLE " + aschema + ".v_hoantra OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + aschema + ".v_hoantract(id numeric(12) NOT NULL DEFAULT 0,loaivp numeric(7) NOT NULL DEFAULT 0,sotien numeric(15,4) DEFAULT 0) WITH OIDS");
                execute_data("ALTER TABLE " + aschema + ".v_hoantract OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + aschema + ".v_huybienlai(id numeric(12) NOT NULL DEFAULT 0,tables varchar(20) NOT NULL,loai numeric(2) DEFAULT 0,mabn varchar(8),hoten text,makp varchar(2),ngay timestamp,quyenso numeric(7) DEFAULT 0,sobienlai numeric(7) DEFAULT 0,lydo text,userid numeric(5) DEFAULT 0,ngayud timestamp DEFAULT now()) WITH OIDS");
                execute_data("ALTER TABLE " + aschema + ".v_huybienlai OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + aschema + ".v_mienngtru(id numeric(12) NOT NULL DEFAULT 0,sotien numeric(15,4) DEFAULT 0,ghichu text,maduyet numeric(4) DEFAULT 0,lydo numeric(2) DEFAULT 0) WITH OIDS");
                execute_data("ALTER TABLE " + aschema + ".v_mienngtru OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + aschema + ".v_miennoitru(id numeric(12) NOT NULL DEFAULT 0,lydo numeric(2) DEFAULT 0,ghichu text,maduyet numeric(4) DEFAULT 0) WITH OIDS");
                execute_data("ALTER TABLE " + aschema + ".v_miennoitru OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + aschema + ".v_nhom(id numeric(12) NOT NULL DEFAULT 0,ma numeric(3) NOT NULL DEFAULT 0,sotien numeric(15,4) DEFAULT 0) WITH OIDS");
                execute_data("ALTER TABLE " + aschema + ".v_nhom OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + aschema + ".v_phieuchict(id numeric(12) NOT NULL DEFAULT 0,stt numeric(3) NOT NULL DEFAULT 0,mavp numeric(7) DEFAULT 0,sotien numeric(15,4) DEFAULT 0) WITH OIDS");
                execute_data("ALTER TABLE " + aschema + ".v_phieuchict OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + aschema + ".v_phieuchill(id numeric(12) NOT NULL DEFAULT 0,quyenso numeric(7) DEFAULT 0,sobienlai numeric(7) DEFAULT 0,ngay timestamp,mabn varchar(8),maql numeric(11) DEFAULT 0,idkhoa numeric(11) DEFAULT 0,makp varchar(2),hoten text,loai numeric(2) DEFAULT 0,loaibn numeric(2) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp DEFAULT now()) WITH OIDS");
                execute_data("ALTER TABLE " + aschema + ".v_phieuchill OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + aschema + ".v_tamung(id numeric(12) NOT NULL DEFAULT 0,mabn varchar(8),mavaovien numeric(11) DEFAULT 0,maql numeric(11) DEFAULT 0,idkhoa numeric(11) DEFAULT 0,quyenso numeric(7) DEFAULT 0,sobienlai numeric(7) DEFAULT 0,ngay timestamp,loai numeric(1) DEFAULT 0,makp varchar(2),madoituong numeric(2) DEFAULT 0,sotien numeric(15,4) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp DEFAULT now(),done numeric(1) DEFAULT 0,lanin numeric(2) DEFAULT 0,loaibn numeric(2) DEFAULT 0,idttrv numeric(12) DEFAULT 0) WITH OIDS");
                execute_data("ALTER TABLE " + aschema + ".v_tamung OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + aschema + ".v_tamungct(id numeric(12) NOT NULL DEFAULT 0,loaivp numeric(3) NOT NULL DEFAULT 0,sotien numeric(15,4) DEFAULT 0) WITH OIDS");
                execute_data("ALTER TABLE " + aschema + ".v_tamungct OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + aschema + ".v_theodoihuy(tables varchar(20),id numeric(12) DEFAULT 0,ma numeric(7) DEFAULT 0,soluong numeric(10,2) DEFAULT 0,computer varchar(20),userid numeric(5) DEFAULT 0,ngayud timestamp DEFAULT now()) WITH OIDS");
                execute_data("ALTER TABLE " + aschema + ".v_theodoihuy OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + aschema + ".v_theodoisua(tables varchar(20),id numeric(12) DEFAULT 0,ma numeric(7) DEFAULT 0,soluong numeric(10,2) DEFAULT 0,computer varchar(20),userid numeric(5) DEFAULT 0,ngayud timestamp DEFAULT now()) WITH OIDS");
                execute_data("ALTER TABLE " + aschema + ".v_theodoisua OWNER TO " + m_db_database + "");


                execute_data("CREATE TABLE " + aschema + ".v_thngayct(id numeric(12) NOT NULL DEFAULT 0,ngay timestamp NOT NULL,mavp numeric(7) NOT NULL DEFAULT 0,soluong numeric(10,2) DEFAULT 0,dongia numeric(24,10) NOT NULL DEFAULT 0,sotien numeric(15,4) DEFAULT 0) WITH OIDS");
                execute_data("ALTER TABLE " + aschema + ".v_thngayct OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + aschema + ".v_thngayll(id numeric(12) NOT NULL DEFAULT 0,madoituong numeric(2) DEFAULT 0,mabn varchar(8),mavaovien numeric(11) DEFAULT 0,maql numeric(11) DEFAULT 0,ngayvao timestamp,tu timestamp,den timestamp,giuong varchar(10),makp varchar(2),conlai numeric(15,4) DEFAULT 0,sotien numeric(15,4) DEFAULT 0,datra numeric(15,4) DEFAULT 0,done numeric(1) DEFAULT 0) WITH OIDS");
                execute_data("ALTER TABLE " + aschema + ".v_thngayll OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + aschema + ".v_thvpbhyt(id numeric(12) NOT NULL DEFAULT 0,sothe varchar(16),maphu numeric(1) DEFAULT 0,noigioithieu varchar(8),noicap varchar(8)) WITH OIDS");
                execute_data("ALTER TABLE " + aschema + ".v_thvpbhyt OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + aschema + ".v_thvpct(id numeric(12) NOT NULL DEFAULT 0,ngay timestamp NOT NULL,makp varchar(2) NOT NULL,madoituong numeric(2) NOT NULL DEFAULT 0,mavp numeric(7) NOT NULL DEFAULT 0,soluong numeric(10,2) DEFAULT 0,dongia numeric(24,10) NOT NULL DEFAULT 0,sotien numeric(15,4) DEFAULT 0,vattu numeric(10) DEFAULT 0) WITH OIDS");
                execute_data("ALTER TABLE " + aschema + ".v_thvpct OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + aschema + ".v_thvpll(id numeric(12) NOT NULL DEFAULT 0,mabn varchar(8),mavaovien numeric(11) DEFAULT 0,maql numeric(11) DEFAULT 0,idkhoa numeric(11) DEFAULT 0,ngayvao timestamp,ngayra timestamp,giuong varchar(10),makp varchar(2),chandoan text,maicd varchar(9),sotien numeric(15,4) DEFAULT 0,tamung numeric(10) DEFAULT 0,bhyt numeric(15,4) DEFAULT 0,mien numeric(15,4) DEFAULT 0,done numeric(1) DEFAULT 0) WITH OIDS");
                execute_data("ALTER TABLE " + aschema + ".v_thvpll OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + aschema + ".v_trongoi(id numeric(12) NOT NULL DEFAULT 0,sotien numeric(10) DEFAULT 0,tamung numeric(10) DEFAULT 0,hoantra numeric(10) DEFAULT 0,pm numeric(1) DEFAULT 0,yc numeric(1) DEFAULT 0,ghichu text) WITH OIDS");
                execute_data("ALTER TABLE " + aschema + ".v_trongoi OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + aschema + ".v_ttrvbhyt(id numeric(12) NOT NULL DEFAULT 0,sothe varchar(16),maphu numeric(1) DEFAULT 0,tungay timestamp,ngay timestamp,mabv varchar(8),noigioithieu varchar(8)) WITH OIDS");
                execute_data("ALTER TABLE " + aschema + ".v_ttrvbhyt OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + aschema + ".v_ttrvct(id numeric(12) NOT NULL DEFAULT 0,stt numeric(5) NOT NULL DEFAULT 0,ngay timestamp,makp varchar(2),madoituong numeric(2) DEFAULT 0,mavp numeric(7) DEFAULT 0,soluong numeric(10,2) DEFAULT 0,dongia numeric(24,10) DEFAULT 0,vat numeric(3) DEFAULT 0,vattu numeric(10) DEFAULT 0,sotien numeric(15,4) DEFAULT 0) WITH OIDS");
                execute_data("ALTER TABLE " + aschema + ".v_ttrvct OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + aschema + ".v_ttrvds(id numeric(12) NOT NULL DEFAULT 0,mabn varchar(8),mavaovien numeric(11) DEFAULT 0,maql numeric(11) DEFAULT 0,idkhoa numeric(11) DEFAULT 0,giuong varchar(10),ngayvao timestamp,ngayra timestamp,chandoan text,maicd varchar(9)) WITH OIDS");
                execute_data("ALTER TABLE " + aschema + ".v_ttrvds OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + aschema + ".v_ttrvll(id numeric(12) NOT NULL DEFAULT 0,loaibn numeric(2) DEFAULT 0,loai numeric(2) DEFAULT 0,quyenso numeric(7) DEFAULT 0,sobienlai numeric(7) DEFAULT 0,ngay timestamp,makp varchar(2),sotien numeric(15,4) DEFAULT 0,tamung numeric(10) DEFAULT 0,mien numeric(15,4) DEFAULT 0,bhyt numeric(15,4) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp DEFAULT now(),nopthem numeric(15,4) DEFAULT 0,thieu numeric(15,4) DEFAULT 0,vattu numeric(10) DEFAULT 0,lanin numeric(2) DEFAULT 0,idtonghop numeric(12) DEFAULT 0,chenhlech numeric(15,4) DEFAULT 0) WITH OIDS");
                execute_data("ALTER TABLE " + aschema + ".v_ttrvll OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + aschema + ".v_ttrvnhom(id numeric(12) NOT NULL DEFAULT 0,ma numeric(3) NOT NULL DEFAULT 0,sotien numeric(15,4) DEFAULT 0) WITH OIDS");
                execute_data("ALTER TABLE " + aschema + ".v_ttrvnhom OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + aschema + ".v_ttrvpttt(id numeric(12) NOT NULL DEFAULT 0,ngay timestamp,songay_tpt numeric(3) DEFAULT 0,songay_spt numeric(3) DEFAULT 0,mavp numeric(7) DEFAULT 0,so numeric(1) DEFAULT 0,loaipt numeric(1) DEFAULT 0,tenpt text) WITH OIDS");
                execute_data("ALTER TABLE " + aschema + ".v_ttrvpttt OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + aschema + ".v_ttrvptttct(id numeric(12) NOT NULL DEFAULT 0,stt numeric(1) NOT NULL DEFAULT 0,songay numeric(3) DEFAULT 0,dongia numeric(10) DEFAULT 0,loaipt numeric(2) DEFAULT 0) WITH OIDS");
                execute_data("ALTER TABLE " + aschema + ".v_ttrvptttct OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + aschema + ".v_vienphict(id numeric(12) NOT NULL DEFAULT 0,stt numeric(3) NOT NULL DEFAULT 0,madoituong numeric(2) DEFAULT 0,mavp numeric(7) DEFAULT 0,ten text,soluong numeric(10,2) DEFAULT 0,dongia numeric(15,4) DEFAULT 0,mien numeric(15,4) DEFAULT 0,thieu numeric(15,4) DEFAULT 0,vattu numeric(10) DEFAULT 0,mabs varchar(4),makp varchar(2)) WITH OIDS");
                execute_data("ALTER TABLE " + aschema + ".v_vienphict OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + aschema + ".v_vienphill(id numeric(12) NOT NULL DEFAULT 0,quyenso numeric(7) DEFAULT 0,sobienlai numeric(7) DEFAULT 0,ngay timestamp,mabn varchar(8),mavaovien numeric(11) DEFAULT 0,maql numeric(11) DEFAULT 0,idkhoa numeric(11) DEFAULT 0,makp varchar(2),hoten text,namsinh varchar(4),diachi text,loai numeric(2) DEFAULT 0,loaibn numeric(2) DEFAULT 0,lanin numeric(2) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp DEFAULT now(),masothue varchar(20)) WITH OIDS");
                execute_data("ALTER TABLE " + aschema + ".v_vienphill OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + aschema + ".v_vpkhoa(id numeric(12) NOT NULL DEFAULT 0,mabn varchar(8),mavaovien numeric(11) DEFAULT 0,maql numeric(11) DEFAULT 0,idkhoa numeric(11) DEFAULT 0,ngay timestamp,makp varchar(2),madoituong numeric(2) DEFAULT 0,mavp numeric(7) DEFAULT 0,soluong numeric(10,2) DEFAULT 0,dongia numeric(15,4) DEFAULT 0,done numeric(1) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp DEFAULT now(),vattu numeric(10) DEFAULT 0,readonly numeric(1) DEFAULT 0,buoi numeric(1) DEFAULT 0) WITH OIDS");
                execute_data("ALTER TABLE " + aschema + ".v_vpkhoa OWNER TO " + m_db_database + "");
            }
            catch
            {
            }
        }
        public void modify_tables_vp()
        {
            try
            {
                execute_data("CREATE TABLE " + m_db_schemaroot + ".vp_treemenu(id numeric(5), id_cha numeric(5), stt numeric(5), ten text, sql text, tenfield text, captionfield text, width text, report text,readonly numeric(1) default 0, CONSTRAINT pk_vp_treemenu PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".vp_treemenu OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".vp_null(id text, ten text, readonly numeric(1) default 0, CONSTRAINT pk_vp_null PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".vp_null OWNER TO " + m_db_database + "");

                execute_data("alter table " + m_db_schemaroot + ".v_quyenso add ngaylinh timestamp DEFAULT now()");

                execute_data("alter table " + m_db_schemaroot + ".v_giavp add thuong numeric(1) default 0");
                execute_data("alter table " + m_db_schemaroot + ".v_giavp add readonly numeric(1) default 0");
                execute_data("alter table " + m_db_schemaroot + ".v_giavp add ndm numeric(1) default 0");

                execute_data("alter table " + m_db_schemaroot + ".v_dlogin add id_nhom numeric(5) default 0");
                execute_data("update " + m_db_schemaroot + ".v_dlogin set id_nhom=1 where id_nhom=0 or id_nhom is null");
                execute_data("alter table " + m_db_schemaroot + ".v_nhombhyt add viettat text");
                execute_data("alter table " + m_db_schemaroot + ".v_nhombhyt add readonly numeric(1) default 0");
                execute_data("alter table " + m_db_schemaroot + ".v_nhomvp add matat varchar(20)");
                execute_data("alter table " + m_db_schemaroot + ".v_nhomvp add viettat text");
                execute_data("alter table " + m_db_schemaroot + ".v_nhomvp add readonly numeric(1) default 0");
                execute_data("alter table " + m_db_schemaroot + ".v_loaivp add viettat text");
                execute_data("alter table " + m_db_schemaroot + ".v_loaivp add readonly numeric(1) default 0");
                execute_data("alter table " + m_db_schemaroot + ".v_giavp add theobs numeric(1) default 0");
                execute_data("alter table " + m_db_schemaroot + ".v_giavp add gia_cs numeric(10) default 0");
                execute_data("alter table " + m_db_schemaroot + ".v_giavp add vattu_cs numeric(10) default 0");
                execute_data("alter table " + m_db_schemaroot + ".v_giavp add loaitrongoi numeric(1) default 0");
                execute_data("alter table " + m_db_schemaroot + ".v_giavp add locthe text");
                execute_data("create table " + m_db_schemaroot + ".v_dmghe(id numeric(5),stt numeric(5), makp varchar2(2), ma text,ten text,constraint pk_v_dmghe primary key(id)) with oids");
                execute_data("alter table " + m_db_schemaroot + ".v_dmghe owner to " + m_db_database + "");
                execute_data("create table " + m_db_schemaroot + ".v_sdghe(id numeric(12), loai numeric(1), ghe numeric(5),constraint pk_v_sdghe primary key(id,loai,ghe)) with oids");
                execute_data("alter table " + m_db_schemaroot + ".v_sdghe owner to " + m_db_database + "");
                execute_data("create table " + m_db_schemaroot + ".v_sdvattu(mavp numeric(7), mavt numeric(7), soluong numeric(5,2), dongia numeric(12,2), sotien numeric(12,2), constraint pk_v_sdvattu primary key(mavp,mavt)) with oids");
                execute_data("alter table " + m_db_schemaroot + ".v_sdvattu owner to " + m_db_database + "");
                execute_data("create table " + m_db_schemaroot + ".v_theodoigia(mabd numeric(7), dongia numeric(12,2), constraint pk_v_theodoigia primary key(mabd)) with oids");
                execute_data("alter table " + m_db_schemaroot + ".v_theodoigia owner to " + m_db_database + "");
                execute_data("create table " + m_db_schemaroot + ".v_loaitu(id numeric(3), sotien numeric(10), ten text, ktt numeric(1) default 0, constraint pk_v_loaitu primary key(id)) with oids");
                execute_data("alter table " + m_db_schemaroot + ".v_loaitu owner to " + m_db_database + "");
                execute_data("create table " + m_db_schemaroot + ".v_option_locgiavp(userid numeric(5), loai numeric(5), ten text, id_vp varchar2(3000),constraint pk_v_option_locgiavp primary key(userid,loai)) with oids");
                execute_data("alter table " + m_db_schemaroot + ".v_option_locgiavp owner to " + m_db_database + "");
                execute_data("create table " + m_db_schemaroot + ".v_option_thutheonhom(id numeric(7), userid numeric(5), stt numeric(5), ten text, id_vp varchar2(1000), constraint pk_v_option_thutheonhom primary key(id,userid)) with oids");
                execute_data("alter table " + m_db_schemaroot + ".v_option_thutheonhom owner to " + m_db_database + "");
                execute_data("create table " + m_db_schemaroot + ".v_option(ma text,giatri text, constraint pk_v_option primary key(ma)) with oids");
                execute_data("alter table " + m_db_schemaroot + ".v_option owner to " + m_db_database + "");
                execute_data("create table " + m_db_schemaroot + ".v_optionform(userid numeric(5), loai numeric(2), ma text, ten text,giatri text, constraint pk_v_optionform primary key(userid,loai,ma)) with oids");
                execute_data("alter table " + m_db_schemaroot + ".v_optionform owner to " + m_db_database + "");
                execute_data("create table " + m_db_schemaroot + ".v_tylebhyt(id numeric(3), mabhyt varchar2(1000), tu numeric(3), den numeric(3), tyle numeric(6,2), dieukien varchar2(20), sotiengh numeric(12,2), tylegh numeric(6,2), chieudai numeric(2) default 16, constraint pk_v_tylebhyt primary key(id)) with oids");
                execute_data("alter table " + m_db_schemaroot + ".v_tylebhyt owner to " + m_db_database + "");
                execute_data("alter table " + m_db_schemaroot + ".v_sdvattu add soluong numeric(5,2), dongia numeric(12,2)");
                execute_data("alter table " + m_db_schemaroot + ".v_lydomien add readonly numeric(1) default 0");
                execute_data("alter table " + m_db_schemaroot + ".v_dsduyet add readonly numeric(1) default 0");
                execute_data("alter table " + m_db_schemaroot + ".v_dsduyet add ngayud timestamp DEFAULT now()");
                execute_data("alter table " + m_db_schemaroot + ".v_loaibn add readonly numeric(1) default 0");
                execute_data("alter table " + m_db_schemaroot + ".v_loaibn add ngayud timestamp DEFAULT now()");
                execute_data("alter table " + m_db_schemaroot + ".v_tenloaivp add readonly numeric(1) default 0");
                execute_data("alter table " + m_db_schemaroot + ".v_tenloaivp add ngayud timestamp DEFAULT now()");
                execute_data("alter table " + m_db_schemaroot + ".v_dmlydonopthem add readonly numeric(1) default 0");
                execute_data("alter table " + m_db_schemaroot + ".v_dmlydonopthem add ngayud timestamp DEFAULT now()");
                execute_data("alter table " + m_db_schemaroot + ".v_dmlydothieu add readonly numeric(1) default 0");
                execute_data("alter table " + m_db_schemaroot + ".v_dmlydothieu add ngayud timestamp DEFAULT now()");
                execute_data("alter table " + m_db_schemaroot + ".v_loaitu add ktt numeric(1) default 0");
                execute_data("alter table " + m_db_schemaroot + ".v_loaitu add ten text)");
                execute_data("alter table " + m_db_schemaroot + ".v_tylebhyt add chieudai numeric(2) default 16");
                execute_data("alter table " + m_db_schemaroot + ".v_quyenso add sohieubl varchar2(20)");
                execute_data("update " + m_db_schemaroot + ".v_quyenso set sohieubl=sohieu where sohieubl is null");
                execute_data("alter table " + m_db_schemaroot + ".v_quyenso add soghiam numeric(7) default -1");
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    try
                    {
                        execute_data("alter table " + r[0].ToString() + ".v_ttrvll add (idtonghop numeric(12) default 0");
                        execute_data("alter table " + r[0].ToString() + ".v_vienphict add (makp varchar2(2))");
                        execute_data("alter table " + r[0].ToString() + ".v_vienphict add (mabs varchar2(4))");
                        execute_data("alter table " + r[0].ToString() + ".v_mienngtru add (lydo numeric(2) default 0)");
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }
        public void upd_v_capid()
        {
            try
            {
                /*
                execute_data("update v_capid set id="+maxid_v_quyenso().ToString()+" where ma=1");//v_quyenso
                execute_data("update v_capid set id="+maxid_v_loaivp().ToString()+" where ma=2");//v_loaivp
                execute_data("update d_capid set id="+maxid_v_giavp_d_dmbd().ToString()+" where ma=1");//v_giavp+d_dmbd
                execute_data("update v_capid set id="+maxid_v_dlogin().ToString()+" where ma=4");//v_dlogin
                execute_data("update v_capid set id="+maxid_v_vienphill().ToString()+" where ma=5");//v_vienphill
                execute_data("update v_capid set id="+maxid_v_tamung().ToString()+" where ma=6");//v_tamung
                execute_data("update v_capid set id="+maxid_v_nhomvp().ToString()+" where ma=7");//v_nhomvp
                execute_data("update v_capid set id="+maxid_v_hoantra().ToString()+" where ma=8");//v_hoantra
                execute_data("update v_capid set id="+maxid_v_chidinh().ToString()+" where ma=9");//v_chidinh
                execute_data("update v_capid set id="+maxid_v_ttrvll().ToString()+" where ma=10");//v_ttrvll
                execute_data("update v_capid set id="+maxid_v_vpkhoa().ToString()+" where ma=11");//v_vpkhoa 
                execute_data("update v_capid set id="+maxid_v_phieuchi().ToString()+" where ma=12");//v_phieuchi
                execute_data("update d_capid set id="+maxid_bhytkb().ToString()+" where ma=12");//bhytkb
                */
            }
            catch
            {
            }
        }
        public void f_default_nhomvp()
        {
            upd_v_nhomvp(1, 1, "Khám bệnh", "KB", "KB", 1, 1);
            upd_v_nhomvp(2, 2, "Xét nghiệm", "XN", "XN", 2, 1);
            upd_v_nhomvp(3, 3, "Chẩn đoán hình ảnh", "CDHA", "CDHA", 3, 1);
            upd_v_nhomvp(4, 4, "Thăm dò chức năng", "TDCN", "TDCN", 4, 1);
            upd_v_nhomvp(5, 5, "Dịch truyền, Máu, Đạm", "DT", "DT", 5, 1);
            upd_v_nhomvp(6, 6, "Thủ thuật - Phẩu thuật", "PTTT", "PTTT", 6, 1);
            upd_v_nhomvp(7, 7, "Thuốc", "THUOC", "THUOC", 7, 1);
            upd_v_nhomvp(8, 8, "Giường", "GIUONG", "GIUONG", 8, 1);
            upd_v_nhomvp(9, 9, "Khác", "KHAC", "KHAC", 9, 1);
        }
        public void f_default_nhombhyt()
        {
            upd_v_nhombhyt(1, 1, "Khám bệnh", "KB", 1);
            upd_v_nhombhyt(2, 2, "Xét nghiệm", "XN", 1);
            upd_v_nhombhyt(3, 3, "Chẩn đoán hình ảnh", "CDHA", 1);
            upd_v_nhombhyt(4, 4, "Thăm dò chức năng", "TDCN", 1);
            upd_v_nhombhyt(5, 5, "Dịch truyền, Máu, Đạm", "DT", 1);
            upd_v_nhombhyt(6, 6, "Thủ thuật - Phẩu thuật", "PTTT", 1);
            upd_v_nhombhyt(7, 7, "Thuốc", "THUOC", 1);
            upd_v_nhombhyt(8, 8, "Giường", "GIUONG", 1);
            upd_v_nhombhyt(9, 9, "Khác", "KHAC", 1);
        }
        public void f_default_loaivp()
        {
            upd_v_loaivp(1, 1, 1, "KBTT", "Khám thông thường", "", 1, "", 1);
            upd_v_loaivp(2, 1, 2, "KBCK", "Khám chuyên khoa", "", 1, "", 1);
            upd_v_loaivp(3, 1, 3, "KBSK", "Khám sức khỏe", "", 1, "", 1);

            upd_v_loaivp(4, 2, 1, "XNHH", "Huyết học Truyền máu", "", 1, "", 1);
            upd_v_loaivp(5, 2, 2, "XNHS", "Hóa sinh", "", 1, "", 1);
            upd_v_loaivp(6, 2, 3, "XNVS", "Vi sinh", "", 1, "", 1);
            upd_v_loaivp(7, 2, 4, "CTBL", "Cơ thể bệnh lý", "", 1, "", 1);
            upd_v_loaivp(8, 2, 5, "XNKH", "Xét nghiệm khác", "", 1, "", 1);

            upd_v_loaivp(9, 3, 1, "NS", "Nội soi", "", 1, "", 1);
            upd_v_loaivp(10, 3, 2, "SADT", "Siêu âm đen trắng", "", 1, "", 1);
            upd_v_loaivp(11, 3, 3, "SAM", "Siêu âm màu", "", 1, "", 1);
            upd_v_loaivp(12, 3, 4, "XQ", "X Quang", "", 1, "", 1);
            upd_v_loaivp(13, 3, 5, "CT", "City", "", 1, "", 1);
            upd_v_loaivp(14, 3, 6, "MRAY", "M-Ray", "", 1, "", 1);
            upd_v_loaivp(15, 3, 7, "CDK", "Các kỹ thuật CĐHA khác", "", 1, "", 1);

            upd_v_loaivp(16, 4, 1, "KTC", "Dịch vụ kỹ thuật cao", "", 1, "", 1);
            upd_v_loaivp(17, 4, 2, "SADT", "Thăm dò chức năng", "", 1, "", 1);
            upd_v_loaivp(18, 4, 3, "SAM", "DVKTC Khác", "", 1, "", 1);

            upd_v_loaivp(19, 5, 1, "DT", "Dịch truyền", "", 1, "", 1);
            upd_v_loaivp(20, 5, 2, "MAU", "Máu", "", 1, "", 1);
            upd_v_loaivp(21, 5, 3, "DAM", "Đạm", "", 1, "", 1);

            upd_v_loaivp(22, 6, 1, "TT", "Thủ thuật", "", 1, "", 1);
            upd_v_loaivp(23, 6, 2, "PT", "Phẩu thuật", "", 1, "", 1);
            upd_v_loaivp(24, 6, 3, "MNS", "Mổ nội soi", "", 1, "", 1);

            upd_v_loaivp(25, 7, 1, "THUOC", "Thuốc", "", 1, "", 1);
            upd_v_loaivp(26, 7, 2, "VTYT", "Vật tư y tế", "", 1, "", 1);

            upd_v_loaivp(27, 8, 1, "GITT", "Giường thông thường", "", 1, "", 1);
            upd_v_loaivp(28, 8, 2, "GIYC", "Giường yêu cầu", "", 1, "", 1);

            upd_v_loaivp(29, 9, 1, "KHAC", "Loại khác", "", 1, "", 1);
        }
        #endregion CẬP NHẬT CẤU TRÚC TABLES

        #region LẤY CẤU TRÚC DATABASE

        private void f_load_maincode()
        {
            try
            {
                m_ds = new DataSet();
                m_ds.ReadXml("..//..//..//xml//maincode.xml");
                try
                {
                    m_db_database = m_ds.Tables[0].Rows[0]["database"].ToString();
                }
                catch
                {
                    m_db_database = "";
                }
                if (m_db_database == "")
                {
                    m_db_database = "medisoft";
                }

                m_db_host = m_ds.Tables[0].Rows[0]["ip"].ToString();
                m_db_port = m_ds.Tables[0].Rows[0]["post"].ToString();
                try
                {
                    m_db_userid = m_ds.Tables[0].Rows[0]["userid"].ToString();
                }
                catch
                {
                    m_db_userid = "";
                }
                if (m_db_userid == "")
                {
                    m_db_userid = "medisoft";
                }

                try
                {
                    m_db_password = m_ds.Tables[0].Rows[0]["password"].ToString();
                }
                catch
                {
                    m_db_password = "";
                }
                if (m_db_password == "")
                {
                    m_db_password = "links1920";
                }
                m_db_encoding = "UNICODE";// m_ds.Tables[0].Rows[0]["encoding"].ToString();
                try
                {
                    m_db_schemaroot = m_ds.Tables[0].Rows[0]["user"].ToString();
                }
                catch
                {
                    m_db_schemaroot = "";
                }
                if (m_db_schemaroot == "")
                {
                    m_db_schemaroot = "medibv";
                }
            }
            catch
            {
            }
        }
        public string s_database
        {
            get
            {
                return m_db_database;
            }
        }
        public string s_schemaroot
        {
            get
            {
                return m_db_schemaroot;
            }
        }
        public DataSet f_get_sys_schema()
        {
            return get_data("select * from pg_tables where tableowner ='" + m_db_userid + "' and schemaname like '" + m_db_schemaroot + "%' order by schemaname, tablename");
        }
        public DataSet f_get_sys_table_structure(string v_schemaname, string v_tablename)
        {
            DataSet ads = null;
            try
            {
                ads = new DataSet();
                ads.Tables.Add("Table");
                ads.Tables[0].Columns.Add("name");
                ads.Tables[0].Columns.Add("type");
                if (v_schemaname != "" && v_tablename != "")
                {
                    foreach (DataColumn c in get_data("select * from " + v_schemaname + "." + v_tablename + " where 1=0").Tables[0].Columns)
                    {
                        ads.Tables[0].Rows.Add(new string[] { c.ColumnName, c.DataType.ToString().Split('.')[c.DataType.ToString().Split('.').Length - 1] });
                    }
                }
                else
                    if (v_tablename == "")
                    {
                        foreach (DataRow r in get_data("select distinct tablename from pg_tables where schemaname='" + v_schemaname + "'").Tables[0].Rows)
                        {
                            ads.Tables[0].Rows.Add(new string[] { r[0].ToString(), "table" });
                        }
                    }
                    else
                        if (v_schemaname == "")
                        {
                            foreach (DataRow r in get_data("select distinct schemaname from pg_tables where tableowner='" + m_db_database + "'").Tables[0].Rows)
                            {
                                ads.Tables[0].Rows.Add(new string[] { r[0].ToString(), "schema" });
                            }
                        }
            }
            catch
            {
                ads = null;
            }
            return ads;
        }

        #endregion LẤY CẤU TRÚC DATABASE

        #region CÁC HÀM DÙNG CHUNG HỆ THỐNG

        public string Maincode(string v_columnname)
        {
            string r = "";
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("..\\..\\..\\xml\\maincode.xml");
                XmlNodeList nodeLst = doc.GetElementsByTagName(v_columnname);
                r = nodeLst.Item(0).InnerText;
            }
            catch
            {
                r = "";
            }
            return r;
        }
        public string f_thongso(string v_columname)
        {
            string r = "";
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("..\\..\\..\\xml\\v_thongso.xml");
                XmlNodeList nodeLst = doc.GetElementsByTagName(v_columname);
                r = nodeLst.Item(0).InnerText;
            }
            catch
            {
                r = "";
            }
            return r;
        }
        public bool s_iscreated(string v_schemaname)
        {
            bool art = false;
            try
            {
                art = (get_data("select schemaname from pg_tables where schemaname = '" + v_schemaname + "' group by schemaname").Tables[0].Rows.Count > 0);
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool s_iscreated_mmyy(string v_mmyy)
        {
            return s_iscreated(s_schema_mmyy(v_mmyy));
        }
        public DataSet s_all_tables_vp
        {
            get
            {
                DataSet ads = new DataSet();
                ads.Tables.Add("Table");
                ads.Tables[0].Columns.Add("TABLE_NAME");
                ads.Tables[0].Rows.Add(new string[] { "V_BHYT" });
                ads.Tables[0].Rows.Add(new string[] { "V_CHIDINH" });
                ads.Tables[0].Rows.Add(new string[] { "V_CONGNO" });
                ads.Tables[0].Rows.Add(new string[] { "V_ERROR" });
                ads.Tables[0].Rows.Add(new string[] { "V_GIUONG" });
                ads.Tables[0].Rows.Add(new string[] { "V_SUATAN" });
                ads.Tables[0].Rows.Add(new string[] { "V_HOANTRA" });
                ads.Tables[0].Rows.Add(new string[] { "V_HOANTRACT" });
                ads.Tables[0].Rows.Add(new string[] { "V_MIENNGTRU" });
                ads.Tables[0].Rows.Add(new string[] { "V_MIENNOITRU" });
                ads.Tables[0].Rows.Add(new string[] { "V_NHOM" });
                ads.Tables[0].Rows.Add(new string[] { "V_PHIEUCHICT" });
                ads.Tables[0].Rows.Add(new string[] { "V_PHIEUCHILL" });
                ads.Tables[0].Rows.Add(new string[] { "V_TAMUNGCT" });
                ads.Tables[0].Rows.Add(new string[] { "V_TAMUNG" });
                ads.Tables[0].Rows.Add(new string[] { "V_THNGAYCT" });
                ads.Tables[0].Rows.Add(new string[] { "V_THNGAYLL" });
                ads.Tables[0].Rows.Add(new string[] { "V_THVPBHYT" });
                ads.Tables[0].Rows.Add(new string[] { "V_THVPCT" });
                ads.Tables[0].Rows.Add(new string[] { "V_THVPLL" });
                ads.Tables[0].Rows.Add(new string[] { "V_TRONGOI" });
                ads.Tables[0].Rows.Add(new string[] { "V_TTRVBHYT" });
                ads.Tables[0].Rows.Add(new string[] { "V_TTRVCT" });
                ads.Tables[0].Rows.Add(new string[] { "V_TTRVDS" });
                ads.Tables[0].Rows.Add(new string[] { "V_TTRVLL" });
                ads.Tables[0].Rows.Add(new string[] { "V_TTRVNHOM" });
                ads.Tables[0].Rows.Add(new string[] { "V_TTRVPTTT" });
                ads.Tables[0].Rows.Add(new string[] { "V_TTRVPTTTCT" });
                ads.Tables[0].Rows.Add(new string[] { "V_VIENPHICT" });
                ads.Tables[0].Rows.Add(new string[] { "V_VIENPHILL" });
                ads.Tables[0].Rows.Add(new string[] { "V_VPKHOA" });
                return ads;
            }
        }
        public DataSet s_all_tables_d
        {
            get
            {
                DataSet ads = new DataSet();
                ads.Tables.Add("Table");
                ads.Tables[0].Columns.Add("TABLE_NAME");
                ads.Tables[0].Rows.Add(new string[] { "BHYTCLS" });
                ads.Tables[0].Rows.Add(new string[] { "BHYTDS" });
                ads.Tables[0].Rows.Add(new string[] { "BHYTKB" });
                ads.Tables[0].Rows.Add(new string[] { "BHYTTHUOC" });
                ads.Tables[0].Rows.Add(new string[] { "D_BIENLAI" });
                ads.Tables[0].Rows.Add(new string[] { "D_BUCSTT" });
                ads.Tables[0].Rows.Add(new string[] { "D_CAPSOTOA" });
                ads.Tables[0].Rows.Add(new string[] { "D_CHANDOAN" });
                ads.Tables[0].Rows.Add(new string[] { "D_CHUYENCT" });
                ads.Tables[0].Rows.Add(new string[] { "D_CHUYENLL" });
                ads.Tables[0].Rows.Add(new string[] { "D_CTGHISOCT" });
                ads.Tables[0].Rows.Add(new string[] { "D_CTGHISOLL" });
                ads.Tables[0].Rows.Add(new string[] { "D_DUTRUCAPCT" });
                ads.Tables[0].Rows.Add(new string[] { "D_DUTRUCAPLL" });
                ads.Tables[0].Rows.Add(new string[] { "D_ERROR" });
                ads.Tables[0].Rows.Add(new string[] { "D_HUYBANCT" });
                ads.Tables[0].Rows.Add(new string[] { "D_HUYBANLL" });
                ads.Tables[0].Rows.Add(new string[] { "D_KIEMTRA" });
                ads.Tables[0].Rows.Add(new string[] { "D_NGTRUCT" });
                ads.Tables[0].Rows.Add(new string[] { "D_NGTRULL" });
                ads.Tables[0].Rows.Add(new string[] { "D_NHAPCT" });
                ads.Tables[0].Rows.Add(new string[] { "D_NHAPCT2" });
                ads.Tables[0].Rows.Add(new string[] { "D_NHAPLL" });
                ads.Tables[0].Rows.Add(new string[] { "D_NHAPSLCT" });
                ads.Tables[0].Rows.Add(new string[] { "D_NHAPSLLL" });
                ads.Tables[0].Rows.Add(new string[] { "D_PHIEUXUAT" });
                ads.Tables[0].Rows.Add(new string[] { "D_SOPHIEU" });
                ads.Tables[0].Rows.Add(new string[] { "D_THANHTOAN" });
                ads.Tables[0].Rows.Add(new string[] { "D_THEODOI" });
                ads.Tables[0].Rows.Add(new string[] { "D_THEODOIGIA" });
                ads.Tables[0].Rows.Add(new string[] { "D_THEODOITSCD" });
                ads.Tables[0].Rows.Add(new string[] { "D_THUCBUCSTT" });
                ads.Tables[0].Rows.Add(new string[] { "D_THUCXUAT" });
                ads.Tables[0].Rows.Add(new string[] { "D_THUCXUAT2" });
                ads.Tables[0].Rows.Add(new string[] { "D_TIENTHUOC" });
                ads.Tables[0].Rows.Add(new string[] { "D_TONKHOCT" });
                ads.Tables[0].Rows.Add(new string[] { "D_TONKHOKEMTHEO" });
                ads.Tables[0].Rows.Add(new string[] { "D_TONKHOTH" });
                ads.Tables[0].Rows.Add(new string[] { "D_TUTRUCCT" });
                ads.Tables[0].Rows.Add(new string[] { "D_TUTRUCKEMTHEO" });
                ads.Tables[0].Rows.Add(new string[] { "D_TUTRUCTH" });
                ads.Tables[0].Rows.Add(new string[] { "D_XUATCT" });
                ads.Tables[0].Rows.Add(new string[] { "D_XUATLL" });
                ads.Tables[0].Rows.Add(new string[] { "D_XUATSDCT" });
                ads.Tables[0].Rows.Add(new string[] { "D_XUATSDLL" });
                return ads;
            }
        }
        public DataSet s_all_field_name
        {
            get
            {
                DataSet ads = new DataSet();
                ads.Tables.Add("Tables");
                ads.Tables[0].Columns.Add("loai");
                ads.Tables[0].Columns.Add("table_name");
                ads.Tables[0].Columns.Add("field_name");
                ads.Tables[0].Rows.Add(new string[] { "VP", "V_BHYT", "id,sothe,maphu,mabv,noigioithieu" });
                ads.Tables[0].Rows.Add(new string[] { "VP", "V_CHIDINH", "id,mabn,maql,idkhoa,ngay,loai,makp,madoituong,mavp,soluong,dongia,paid,done,userid,ngayud,vattu,tinhtrang,thuchien,computer" });
                ads.Tables[0].Rows.Add(new string[] { "VP", "V_CONGNO", "mabn,maql,idkhoa,mavp,sotien,dathu" });
                ads.Tables[0].Rows.Add(new string[] { "VP", "V_ERROR", "message,computer,tables,ngayud" });
                ads.Tables[0].Rows.Add(new string[] { "VP", "V_GIUONG", "id,mavp,ngay,dongia" });
                ads.Tables[0].Rows.Add(new string[] { "VP", "V_HOANTRA", "id,quyenso,sobienlai,ngay,mabn,hoten,sotien,ghichu,userid,ngayud,loai,loaibn" });
                ads.Tables[0].Rows.Add(new string[] { "VP", "V_HOANTRACT", "id,loaivp,sotien" });
                ads.Tables[0].Rows.Add(new string[] { "VP", "V_MIENNGTRU", "id,sotien,ghichu,maduyet,lydo" });
                ads.Tables[0].Rows.Add(new string[] { "VP", "V_MIENNOITRU", "id,lydo,ghichu,maduyet" });
                ads.Tables[0].Rows.Add(new string[] { "VP", "V_NHOM", "id,ma,sotien" });
                ads.Tables[0].Rows.Add(new string[] { "VP", "V_PHIEUCHICT", "id,stt,mavp,sotien" });
                ads.Tables[0].Rows.Add(new string[] { "VP", "V_PHIEUCHILL", "id,quyenso,sobienlai,ngay,mabn,maql,idkhoa,makp,hoten,loai,loaibn,userid,ngayud" });
                ads.Tables[0].Rows.Add(new string[] { "VP", "V_TAMUNG", "id,mabn,maql,idkhoa,quyenso,sobienlai,ngay,loai,makp,madoituong,sotien,userid,ngayud,done,lanin,loaibn,idttrv" });
                ads.Tables[0].Rows.Add(new string[] { "VP", "V_TAMUNGCT", "id,loaivp,sotien" });
                ads.Tables[0].Rows.Add(new string[] { "VP", "V_THNGAYCT", "id,ngay,mavp,soluong,dongia,sotien" });
                ads.Tables[0].Rows.Add(new string[] { "VP", "V_THNGAYLL", "id,madoituong,mabn,maql,ngayvao,tu,den,giuong,makp,conlai,sotien,datra,done" });
                ads.Tables[0].Rows.Add(new string[] { "VP", "V_THVPBHYT", "id,sothe,maphu,noigioithieu,noicap" });
                ads.Tables[0].Rows.Add(new string[] { "VP", "V_THVPCT", "id,ngay,makp,madoituong,mavp,soluong,dongia,sotien,vattu" });
                ads.Tables[0].Rows.Add(new string[] { "VP", "V_THVPLL", "id,mabn,maql,idkhoa,ngayvao,ngayra,giuong,makp,chandoan,maicd,sotien,tamung,bhyt,mien,done" });
                ads.Tables[0].Rows.Add(new string[] { "VP", "V_TRONGOI", "id,sotien,tamung,hoantra,pm,yc,ghichu" });
                ads.Tables[0].Rows.Add(new string[] { "VP", "V_TTRVBHYT", "id,sothe,maphu,tungay,ngay,mabv,noigioithieu" });
                ads.Tables[0].Rows.Add(new string[] { "VP", "V_TTRVCT", "id,stt,ngay,makp,madoituong,mavp,soluong,dongia,vat,vattu,sotien" });
                ads.Tables[0].Rows.Add(new string[] { "VP", "V_TTRVDS", "id,mabn,maql,idkhoa,giuong,ngayvao,ngayra,chandoan,maicd" });
                ads.Tables[0].Rows.Add(new string[] { "VP", "V_TTRVLL", "ngay,makp,sotien,tamung,mien,bhyt,userid,ngayud,lanin,id,loaibn,loai,quyenso,sobienlai" });//,nopthem,thieu,vattu,chenhlech,idtonghop"});
                ads.Tables[0].Rows.Add(new string[] { "VP", "V_TTRVNHOM", "id,ma,sotien" });
                ads.Tables[0].Rows.Add(new string[] { "VP", "V_TTRVPTTT", "id,ngay,songay_tpt,songay_spt,mavp,so,loaipt,tenpt" });
                ads.Tables[0].Rows.Add(new string[] { "VP", "V_TTRVPTTTCT", "id,stt,songay,dongia,loaipt" });
                ads.Tables[0].Rows.Add(new string[] { "VP", "V_VIENPHICT", "id,stt,madoituong,mavp,soluong,dongia,mien,thieu,vattu,mabs,makp" });
                ads.Tables[0].Rows.Add(new string[] { "VP", "V_VIENPHILL", "id,quyenso,sobienlai,ngay,mabn,maql,idkhoa,makp,hoten,namsinh,diachi,loai,loaibn,lanin,userid,ngayud" });
                ads.Tables[0].Rows.Add(new string[] { "VP", "V_VPKHOA", "id,mabn,maql,idkhoa,ngay,makp,madoituong,mavp,soluong,dongia,done,userid,ngayud,vattu" });
                ads.Tables[0].Rows.Add(new string[] { "D", "BHYTCLS", "id,stt,mavp,soluong,dongia,idchidinh" });
                ads.Tables[0].Rows.Add(new string[] { "D", "BHYTDS", "mabn,hoten,namsinh,diachi" });
                ads.Tables[0].Rows.Add(new string[] { "D", "BHYTKB", "mabn,maql,makp,chandoan,maicd,mabs,sothe,maphu,mabv,congkham,thuoc,cls,bntra,bhyttra,mmyy,userid,ngayud,done,sotoa,id,nhom,quyenso,sobienlai,ngay" });
                ads.Tables[0].Rows.Add(new string[] { "D", "BHYTTHUOC", "id,stt,sttt,makho,manguon,nhomcc,mabd,handung,losx,soluong,sotien,giaban,giamua,cachdung" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_BIENLAI", "id,sohieu,sobienlai,sotien" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_BUCSTT", "id,stt,sttt,makho,manguon,nhomcc,mabd,handung,losx,soluong,sotien,giaban,giamua,sttduyet" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_CAPSOTOA", "id,ngay,loai,sotoa" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_CHANDOAN", "id,loai,maicd,chandoan" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_CHUYENCT", "id,stt,sttt,makho,manguon,nhomcc,mabd,handung,losx,soluong,sotien,giaban,giamua,nguonchuyen,stttchuyen" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_CHUYENLL", "id,nhom,sophieu,ngay,lydo,mmyy,userid,ngayud" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_CTGHISOCT", "id,makho,makp,no,co,sotien,diengiai" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_CTGHISOLL", "id,nhom,soct,ngay,mmyy,userid,ngayud" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_DUTRUCAPCT", "id,manguon,mabd,slyeucau,slthuc" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_DUTRUCAPLL", "id,nhom,sophieu,ngay,loai,khox,khon,userid,ngayud,done" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_ERROR", "message,computer,tables,ngayud" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_HUYBANCT", "id,stt,sttt,makho,manguon,nhomcc,mabd,handung,losx,soluong,sotien,giaban,giamua" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_HUYBANLL", "id,nhom,mabn,hoten,namsinh,ngay,mabs,makp,loai,mmyy,done,userid,ngayud,lanin,sotoa,maql" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_KIEMTRA", "nhom,ngay,userid,ngayud" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_NGTRUCT", "id,stt,sttt,makho,manguon,nhomcc,mabd,handung,losx,soluong,sotien,giaban,giamua" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_NGTRULL", "id,nhom,mabn,hoten,namsinh,ngay,mabs,makp,loai,mmyy,done,userid,ngayud,lanin,sotoa,maql" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_NHAPCT", "vat,soluong,dongia,sotien,giaban,giamua,sl1,sl2,tyle,cuocvc,chaythu,namsx,tailieu,baohanh,nguongoc,tinhtrang,sothe,giabancu,id,stt,mabd,handung,losx" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_NHAPCT2", "id,stt,mabd,soluong,sotien" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_NHAPLL", "id,nhom,sophieu,ngaysp,sohd,ngayhd,bbkiem,ngaykiem,loai,nguoigiao,madv,makho,manguon,nhomcc,no,co,mmyy,userid,ngayud,paid,lydo" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_NHAPSLCT", "id,stt,mabd,handung,losx,soluong,sl1,sl2" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_NHAPSLLL", "id,nhom,sophieu,ngaysp,sohd,ngayhd,loai,nguoigiao,madv,makho,mmyy,done,userid,ngayud" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_PHIEUXUAT", "id,soct,ngay,makp,nhom,loai,phieu,kho,sotien,no,co,diengiai,mmyy,userid,ngayud" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_SOPHIEU", "mmyy,nhom,ngay,makp,loai,phieu,loaiin,makho,madoituong,so,lanin,manguon,nguoilinh" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_THANHTOAN", "ngay,no,co,sotien,datra,mmyy,userid,ngayud,id" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_THEODOI", "id,mabd,manguon,nhomcc,handung,losx,sothe,namsx,namsd,baohanh,nguongoc,tinhtrang,giamua,giaban,ngayud" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_THEODOIGIA", "mabd,ngay,dongia,ngayud" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_THEODOITSCD", "makho,sttt,nam,namsx,namsd,tyle,phanloai,baohanh,nguongoc,tinhtrang,sothe" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_THUCBUCSTT", "id,sttt,makho,manguon,nhomcc,mabd,handung,losx,soluong,sotien,giaban,giamua,stt" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_THUCXUAT", "id,sttt,madoituong,makho,manguon,nhomcc,mabd,handung,losx,soluong,sotien,giaban,giamua,sothe,namsx,namsd,stt" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_THUCXUAT2", "id,sttt,makho,mabd,soluong,sotien,giamua,stt" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_TIENTHUOC", "mabn,maql,idkhoa,ngay,makp,madoituong,mabd,soluong,sotien,giaban,giamua,done" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_TONKHOCT", "mmyy,makho,manguon,nhomcc,stt,idn,sttn,mabd,handung,losx,tondau,sttondau,slnhap,stnhap,slxuat,stxuat,giaban,giamua" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_TONKHOKEMTHEO", "makhot,sttt,makho,stt,idn,sttn,mabd,tondau,sttondau,slnhap,stnhap,slxuat,stxuat,giamua" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_TONKHOTH", "mmyy,makho,mabd,tondau,slnhap,slxuat,slyeucau,manguon" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_TUTRUCCT", "mmyy,makp,makho,manguon,nhomcc,stt,mabd,handung,losx,tondau,sttondau,slnhap,stnhap,slxuat,stxuat,giaban,giamua" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_TUTRUCKEMTHEO", "makhot,sttt,makp,makho,stt,mabd,tondau,sttondau,slnhap,stnhap,slxuat,stxuat,giamua" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_TUTRUCTH", "mmyy,makp,makho,mabd,tondau,slnhap,slxuat,slyeucau,manguon" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_XUATCT", "sothe,mabs,hotenbn,id,stt,sttt,manguon,nhomcc,mabd,handung,losx,soluong,sotien,giaban,giamua" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_XUATLL", "id,nhom,sophieu,ngay,loai,khox,khon,lydo,mmyy,userid,ngayud,idduyet" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_XUATSDCT", "id,stt,sttt,madoituong,makho,manguon,nhomcc,mabd,handung,losx,soluong,sotien,giaban,giamua,sttduyet,sothe,namsx,namsd" });
                ads.Tables[0].Rows.Add(new string[] { "D", "D_XUATSDLL", "id,nhom,mabn,maql,idkhoa,ngay,loai,phieu,makp,mmyy,userid,ngayud,idduyet,thuoc,makhoa,lydo,lk,ghichu" });
                return ads;
            }
        }
        public string s_schema_mmyy(string v_mmyy)
        {
            return (m_db_schemaroot + "" + v_mmyy);
        }
        public DataSet get_shemaname_mmyy(string v_schemaroot)
        {
            m_ds = get_data("select distinct schemaname from pg_tables where schemaname like '" + v_schemaroot + "____'");
            return m_ds;
        }
        public DataSet get_shemaname_mmyy()
        {
            m_ds = get_data("select distinct schemaname from pg_tables where schemaname like '" + s_schemaroot + "____'");
            return m_ds;
        }
        public DataSet get_tablename(string v_schemaname)
        {
            m_ds = get_data("select tablename from pg_tables where schemaname ='" + v_schemaname + "' group by tablename");
            return m_ds;
        }
        public DataSet get_tablename_root()
        {
            return get_tablename(s_schemaroot);
        }
        public string get_field_vp(string v_table)
        {
            string rt = "";
            try
            {
                rt = s_all_field_name.Tables[0].Select("table_name='" + v_table.ToUpper() + "' and loai='VP'")[0]["field_name"].ToString();
            }
            catch
            {
                rt = "*";
            }
            if (rt.Trim() == "") rt = "*";
            return rt;
        }
        public string get_field_d(string v_table)
        {
            string rt = "";
            try
            {
                rt = s_all_field_name.Tables[0].Select("table_name='" + v_table.ToUpper() + "' and loai='D'")[0]["field_name"].ToString();
            }
            catch
            {
                rt = "*";
            }
            if (rt.Trim() == "") rt = "*";
            return rt;
        }
        public void f_write_error(string v_error)
        {
            try
            {
                System.IO.StreamWriter ast = System.IO.File.AppendText("..\\..\\..\\xml\\v_tables_sql.txt");
                ast.WriteLine(v_error);
                ast.WriteLine("");
                ast.Close();
            }
            catch
            {
            }
        }
        public void execute_data(string v_sql)
        {
            v_sql = v_sql.Replace("medibv.", m_db_schemaroot + ".");
            try
            {
                m_connection = new NpgsqlConnection(m_db_connectionstring);
                m_connection.Open();
                m_command = new NpgsqlCommand(v_sql, m_connection);
                m_command.CommandType = CommandType.Text;
                m_command.ExecuteNonQuery();
            }
            catch//(Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
        }
        public void execute_data_mmyy(string v_mmyy, string v_sql)
        {
            try
            {
                v_sql = v_sql.Replace("medibvmmyy.", s_schema_mmyy(v_mmyy) + ".");
                v_sql = v_sql.Replace("medibv.", m_db_schemaroot + ".");
                m_connection = new NpgsqlConnection(m_db_connectionstring);
                m_connection.Open();
                m_command = new NpgsqlCommand(v_sql, m_connection);
                m_command.CommandType = CommandType.Text;
                m_command.ExecuteNonQuery();
                //m_command.Dispose();
                //m_connection.Dispose();
            }
            catch
            {
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
        }
        public DataSet get_data(string v_sql)
        {
            string ammyy = "";
            ammyy = m_cur_mmyy;
            m_ds = null;
            try
            {
                v_sql = v_sql.Replace("medibvmmyy.", m_db_schemaroot + ammyy + ".");
                v_sql = v_sql.Replace("medibv.", m_db_schemaroot + ".");
                m_connection = new NpgsqlConnection(m_db_connectionstring);
                m_connection.Open();
                m_command = new NpgsqlCommand(v_sql, m_connection);
                m_command.CommandType = CommandType.Text;
                m_dataadapter = new NpgsqlDataAdapter(m_command);
                m_ds = new DataSet();
                m_dataadapter.Fill(m_ds);
                //m_command.Dispose();
                //m_connection.Dispose();
            }
            catch
            {
                m_ds = null;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return m_ds;
        }
        public DataSet get_data_all(string v_sql)
        {
            try
            {
                string asql = "", asql1 = "";
                DataSet ads = null, adst = null, adsschema = null;
                if (v_sql.IndexOf(":medibvmmyy") >= 0)
                {
                    adsschema = get_shemaname_mmyy();
                    foreach (DataRow r in adsschema.Tables[0].Rows)
                    {
                        asql1 = v_sql;
                        asql = asql1.Replace(":medibvmmyy", r["schemaname"].ToString());
                        asql = asql.Replace(":medibv", s_schemaroot);
                        adst = get_data(asql);
                        if (ads == null)
                        {
                            if (adst != null)
                            {
                                ads = adst;
                            }
                        }
                        else
                        {
                            if (adst != null)
                            {
                                ads.Merge(adst);
                            }
                        }
                    }
                }
                else
                {
                    asql = v_sql.Replace(":medibv", s_schemaroot);
                    ads = get_data(asql);
                }
                return ads;
            }
            catch
            {
                return null;
            }
        }
        public DataSet get_data_all(DateTime v_tn, DateTime v_dn, string v_sql)
        {
            try
            {
                string asql = "", asql1 = "";
                DataSet ads = null, adst = null, adsschema = null;
                if (v_sql.IndexOf(":medibvmmyy") >= 0)
                {
                    adsschema = get_shemaname_mmyy();
                    int atu = v_tn.Month + int.Parse(v_tn.Year.ToString().Substring(2)) * 12;
                    int aden = v_dn.Month + int.Parse(v_dn.Year.ToString().Substring(2)) * 12;
                    foreach (DataRow r in adsschema.Tables[0].Rows)
                    {
                        int ahientai = int.Parse(r["schemaname"].ToString().Substring(r["schemaname"].ToString().Length - 4, 2)) + int.Parse(r["schemaname"].ToString().Substring(r["schemaname"].ToString().Length - 2, 2)) * 12;
                        if (ahientai >= atu && ahientai <= aden)
                        {
                            asql1 = v_sql;
                            asql = asql1.Replace(":medibvmmyy", r["schemaname"].ToString());
                            asql = asql.Replace(":medibv", s_schemaroot);
                            adst = get_data(asql);
                            if (ads == null)
                            {
                                if (adst != null)
                                {
                                    ads = adst;
                                }
                            }
                            else
                            {
                                if (adst != null)
                                {
                                    ads.Merge(adst);
                                }
                            }
                        }
                    }
                }
                else
                {
                    asql = v_sql.Replace(":medibv", s_schemaroot);
                    ads = get_data(asql);
                }
                return ads;
            }
            catch
            {
                return null;
            }
        }
        //public DataSet get_data_ora(string v_sql)
        //{
        //    m_ds = null;
        //    try
        //    {
        //        m_connnection_ora = new NpgsqlConnection(m_connectionstring_ora);
        //        m_connnection_ora.Open();
        //        m_command_ora = new NpgsqlCommand(v_sql, m_connnection_ora);
        //        m_command_ora.CommandType = CommandType.Text;
        //        m_dataadapter_ora = new OracleDataAdapter(m_command_ora);
        //        m_ds = new DataSet();
        //        m_dataadapter_ora.Fill(m_ds);
        //        m_command_ora.Dispose();
        //        m_connnection_ora.Dispose();
        //    }
        //    catch (OracleException ex)
        //    {
        //        upd_v_error(ex.Message.ToString().Trim(), m_computername, "?");
        //    }
        //    return m_ds;
        //}

        public string s_doituong_giadv
        {
            get
            {
                try
                {
                    string ar = "";
                    foreach (DataRow r in get_data("select madoituong from " + s_schemaroot + ".d_doituong where loai=1").Tables[0].Rows)
                    {
                        ar = ar.Trim() + r[0].ToString() + ",";
                    }
                    return ar;
                }
                catch
                {
                    return "";
                }
            }
        }
        #endregion CÁC HÀM DÙNG CHUNG HỆ THỐNG

        #region CAPID
        public string get_cap_mabn(string v_yy)
        {
            string amabn = "";
            decimal ayy = 0, astt = 0, auserid = 1;

            try
            {
                ayy = decimal.Parse(v_yy);
            }
            catch
            {
                ayy = decimal.Parse(DateTime.Now.Year.ToString().Substring(2));
            }
            try
            {
                astt = decimal.Parse(get_data("select stt+1 from medibv.capmabn where yy=" + ayy.ToString() + " and loai=1 and userid=" + auserid.ToString()).Tables[0].Rows[0][0].ToString());
                execute_data("update medibv.capmabn set stt=stt+1 where yy=" + ayy.ToString() + " and loai=1 and userid=" + auserid.ToString() + " and stt<" + astt.ToString());
            }
            catch
            {
                astt = 1;
                execute_data("insert into medibv.capmabn(yy,stt,loai,userid) values(" + ayy.ToString() + ",1,1," + auserid.ToString() + ")");
            }
            amabn = ayy.ToString().PadLeft(2, '0') + astt.ToString().PadLeft(6, '0');
            return amabn;
        }

        /*		
                1 : quyenso
                2 : loaivp
                3 : giavp - 1 : d_dmbd
                4 : dlogin
                5 : vienphi
                6 : tamung
                7 : nhomvp
                8 : hoantra
                9 : chidinh
                10: thanh toan ra vien
        */
        private int get_computerid()
        {
            int art = 1;
            try
            {
                art = int.Parse(get_data("select id, computer from " + m_db_schemaroot + ".dmcomputer").Tables[0].Select("computer='" + m_computername + "'")[0][0].ToString());
            }
            catch
            {
                upd_dmcomputer();
                try
                {
                    art = int.Parse(get_data("select id, computer from " + m_db_schemaroot + ".dmcomputer").Tables[0].Select("computer='" + m_computername + "'")[0][0].ToString().Trim());
                }
                catch
                {
                    art = 1;
                }
            }
            return art;
        }
        private decimal get_xn_capid(decimal v_ma)
        {
            decimal art = 1;
            try
            {
                m_sql = "update " + m_db_schemaroot + ".xn_capid set id=id+1 where ma=:v_ma";
                m_connection = new NpgsqlConnection(m_db_connectionstring);
                m_command = new NpgsqlCommand(m_sql, m_connection);
                m_command.CommandType = CommandType.Text;
                m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_capid(ma,ten,id,computer) values (:v_ma,:v_ten,1,'????')";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Varchar, 20).Value = "????";
                    m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
                m_connection.Dispose();
                art = decimal.Parse(get_data("select id from xn_capid where ma=" + v_ma).Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                return art = 1;
            }
            return art;
        }
        private decimal get_xn_capid_may(decimal v_ma, string v_computer)
        {
            decimal art = 1;
            try
            {
                m_sql = "update " + m_db_schemaroot + ".xn_capid set id=id+1 where ma=:v_ma and computer=:v_computer";
                m_connection = new NpgsqlConnection(m_db_connectionstring);
                m_command = new NpgsqlCommand(m_sql, m_connection);
                m_command.CommandType = CommandType.Text;
                m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                m_command.Parameters.Add("v_computer", NpgsqlDbType.Varchar, 20).Value = v_computer;
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_capid(ma,ten,id,computer,ngayud) values (:v_ma,:v_ten,1,:v_computer,now())";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Varchar, 20).Value = v_computer;
                    m_command.Parameters.Add("v_computer", NpgsqlDbType.Varchar, 20).Value = v_computer;
                    m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
                m_sql = "select id from " + m_db_schemaroot + ".xn_capid where ma=:v_ma and computer=:v_computer";
                m_command = new NpgsqlCommand(m_sql, m_connection);
                m_command.CommandType = CommandType.Text;
                m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                m_command.Parameters.Add("v_computer", NpgsqlDbType.Varchar, 20).Value = v_computer;
                m_dataadapter = new NpgsqlDataAdapter(m_command);
                m_ds = new DataSet();
                m_dataadapter.Fill(m_ds);
                m_command.Dispose();
                m_connection.Dispose();
                art = decimal.Parse(m_ds.Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                art = 1;
            }
            return art;
        }
        private decimal get_d_capid_may(decimal v_ma, string v_computer)
        {
            decimal art = 1;
            try
            {
                m_sql = "update " + m_db_schemaroot + ".d_capid set id=id+1 where ma=:v_ma and computer=:v_computer";
                m_connection = new NpgsqlConnection(m_db_connectionstring);
                m_command = new NpgsqlCommand(m_sql, m_connection);
                m_command.CommandType = CommandType.Text;
                m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                m_command.Parameters.Add("v_computer", NpgsqlDbType.Varchar, 20).Value = v_computer;
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".d_capid(ma,ten,id,computer,ngayud) values (:m_ma,:m_ten,1,:m_computer,now())";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Varchar, 20).Value = "????";
                    m_command.Parameters.Add("v_computer", NpgsqlDbType.Varchar, 20).Value = v_computer;
                    m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
                m_sql = "select id from " + m_db_schemaroot + ".d_capid where ma=:v_ma and computer=:v_computer";
                m_command = new NpgsqlCommand(m_sql, m_connection);
                m_command.CommandType = CommandType.Text;
                m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                m_command.Parameters.Add("v_computer", NpgsqlDbType.Varchar, 20).Value = v_computer;
                m_dataadapter = new NpgsqlDataAdapter(m_command);
                m_ds = new DataSet();
                m_dataadapter.Fill(m_ds);
                m_command.Dispose();
                m_connection.Dispose();
                art = decimal.Parse(m_ds.Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                art = 1;
            }
            return art;
        }
        private decimal get_v_capid(decimal v_ma)
        {
            decimal art = 1;
            try
            {
                m_sql = "update " + m_db_schemaroot + ".v_capid set id=id+1 where ma=:v_ma";
                m_connection = new NpgsqlConnection(m_db_connectionstring);
                m_command = new NpgsqlCommand(m_sql, m_connection);
                m_command.CommandType = CommandType.Text;
                m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".v_capid(ma,ten,id,computer) values (:v_ma,:v_ten,1,'????')";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Varchar, 20).Value = "????";
                    m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
                m_connection.Dispose();
                art = decimal.Parse(get_data("select id from " + m_db_schemaroot + ".v_capid where ma=" + v_ma).Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                return art = 1;
            }
            return art;
        }
        private decimal get_v_capid_may(decimal v_ma, string v_computer)
        {
            decimal art = 1;
            try
            {
                m_sql = "update " + m_db_schemaroot + ".v_capid set id=id+1 where ma=:v_ma and computer=:v_computer";
                m_connection = new NpgsqlConnection(m_db_connectionstring);
                m_command = new NpgsqlCommand(m_sql, m_connection);
                m_command.CommandType = CommandType.Text;
                m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                m_command.Parameters.Add("v_computer", NpgsqlDbType.Varchar, 20).Value = v_computer;
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".v_capid(ma,ten,id,computer,ngayud) values (:v_ma,:v_ten,1,:v_computer,now())";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Varchar, 20).Value = "????";
                    m_command.Parameters.Add("v_computer", NpgsqlDbType.Varchar, 20).Value = v_computer;
                    m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
                m_sql = "select id from " + m_db_schemaroot + ".v_capid where ma=:v_ma and computer=:v_computer";
                m_command = new NpgsqlCommand(m_sql, m_connection);
                m_command.CommandType = CommandType.Text;
                m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                m_command.Parameters.Add("v_computer", NpgsqlDbType.Varchar, 20).Value = v_computer;
                m_dataadapter = new NpgsqlDataAdapter(m_command);
                m_ds = new DataSet();
                m_dataadapter.Fill(m_ds);
                m_command.Dispose();
                m_connection.Dispose();
                art = decimal.Parse(m_ds.Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                art = 1;
            }
            return art;
        }
        private decimal get_v_capid(string v_table, int v_ma)
        {
            decimal art = 1;
            try
            {
                m_sql = "update " + m_db_schemaroot + "." + v_table + " set id=id+1 where ma=:v_ma";
                m_connection = new NpgsqlConnection(m_db_connectionstring);
                m_command = new NpgsqlCommand(m_sql, m_connection);
                m_command.CommandType = CommandType.Text;
                m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + "." + v_table + "(ma,ten,id) values (:v_ma,:v_ten,1)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Varchar, 20).Value = "????";
                    m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
                m_connection.Dispose();
                art = decimal.Parse(get_data("select id from " + m_db_schemaroot + "." + v_table + " where ma=" + v_ma).Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                art = 1;
            }
            return art;
        }
        private decimal get_capid(decimal v_ma)
        {
            decimal art = 1;
            try
            {
                m_sql = "update " + m_db_schemaroot + ".capid set id=id+1 where ma=:v_ma";
                m_connection = new NpgsqlConnection(m_db_connectionstring);
                m_command = new NpgsqlCommand(m_sql, m_connection);
                m_command.CommandType = CommandType.Text;
                m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".capid(ma,yy,loai,id,ngayud) values (:v_ma,'??','??',1,now())";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                    m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
                m_connection.Dispose();
                art = decimal.Parse(get_data("select id from " + m_db_schemaroot + ".capid where ma=" + v_ma).Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                return art = 1;
            }
            return art;
        }
        public decimal get_id_v_quyenso { get { return get_v_capid(1); } }
        public decimal get_id_v_nhomdlogin
        {
            get
            {
                decimal art = 1;
                try
                {
                    decimal i = 0;
                    DataSet ads = get_data("select id from " + s_schemaroot + ".v_nhomdlogin order by id asc");
                    while (i < 99999)
                    {
                        i++;
                        if (ads.Tables[0].Select("id=" + i.ToString()).Length <= 0)
                        {
                            break;
                        }
                    }
                    art = decimal.Parse(i.ToString());
                }
                catch
                {
                    art = 1;
                }
                return art;
            }
        }
        public decimal get_id_v_dlogin { get { return get_v_capid(4); } }
        public decimal get_id_bhytkb { get { return decimal.Parse(m_computerid.ToString() + get_v_capid_may(12, m_computername).ToString().PadLeft(9, '0')); } }
        public decimal get_id_v_vienphill { get { return decimal.Parse(m_computerid.ToString() + get_v_capid_may(5, m_computername).ToString().PadLeft(9, '0')); } }
        public decimal get_id_v_tamung { get { return decimal.Parse(m_computerid.ToString() + get_v_capid_may(6, m_computername).ToString().PadLeft(9, '0')); } }
        public decimal get_id_v_hoantra { get { return decimal.Parse(m_computerid.ToString() + get_v_capid_may(8, m_computername).ToString().PadLeft(9, '0')); } }
        public decimal get_id_v_chidinh { get { return decimal.Parse(m_computerid.ToString() + get_v_capid_may(9, m_computername).ToString().PadLeft(9, '0')); } }
        public decimal get_id_v_ttrvll { get { return decimal.Parse(m_computerid.ToString() + get_v_capid_may(10, m_computername).ToString().PadLeft(9, '0')); } }
        public decimal get_id_v_vpkhoa { get { return decimal.Parse(m_computerid.ToString() + get_v_capid_may(11, m_computername).ToString().PadLeft(9, '0')); } }
        public decimal get_id_v_phieuchi { get { return decimal.Parse(m_computerid.ToString() + get_v_capid_may(12, m_computername).ToString().PadLeft(9, '0')); } }
        public decimal get_id_v_thvp { get { return decimal.Parse(m_computerid.ToString() + get_v_capid_may(13, m_computername).ToString().PadLeft(9, '0')); } }
        public decimal get_id_v_dmghe
        {
            get
            {
                try
                {
                    return decimal.Parse(get_data("select max(id)+1 from v_dmghe").Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    return 1;
                }
            }
        }
        public decimal get_id_v_thutheonhom
        {
            get
            {
                try
                {
                    return decimal.Parse(get_data("select max(id)+1 from v_option_thutheonhom").Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    return 1;
                }
            }
        }
        public decimal get_id_v_bhyt { get { return decimal.Parse(m_computerid.ToString() + get_d_capid_may(12, m_computername).ToString().PadLeft(9, '0')); } }
        public decimal get_id_v_treebaocao
        {
            get
            {
                decimal art = 1;
                try
                {
                    decimal i = 0;
                    DataSet ads = get_data("select id from " + s_schemaroot + ".v_treebaocao order by id asc");
                    while (i < 999999999999)
                    {
                        i = i + 1;
                        if (ads.Tables[0].Select("id=" + i.ToString()).Length <= 0)
                        {
                            break;
                        }
                    }
                    art = decimal.Parse(i.ToString());
                }
                catch
                {
                    art = 1;
                }
                return art;
            }
        }
        public decimal get_id_v_lydomien
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select id from " + s_schemaroot + ".v_lydomien order by id asc");
                    while (i < 99)
                    {
                        i = i + 1;
                        if (ads.Tables[0].Select("id=" + i.ToString()).Length <= 0)
                        {
                            break;
                        }
                    }
                    art = decimal.Parse(i.ToString());
                }
                catch
                {
                    art = 1;
                }
                return art;
            }
        }
        public decimal get_id_v_dmlydonopthem
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select id from " + s_schemaroot + ".v_dmlydonopthem order by id asc");
                    while (i < 99)
                    {
                        i = i + 1;
                        if (ads.Tables[0].Select("id=" + i.ToString()).Length <= 0)
                        {
                            break;
                        }
                    }
                    art = decimal.Parse(i.ToString());
                }
                catch
                {
                    art = 1;
                }
                return art;
            }
        }
        public decimal get_id_v_dmlydothieu
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select id from " + s_schemaroot + ".v_dmlydothieu order by id asc");
                    while (i < 99)
                    {
                        i = i + 1;
                        if (ads.Tables[0].Select("id=" + i.ToString()).Length <= 0)
                        {
                            break;
                        }
                    }
                    art = decimal.Parse(i.ToString());
                }
                catch
                {
                    art = 1;
                }
                return art;
            }
        }
        public decimal get_id_v_loaibn
        {
            get
            {
                decimal art = 1;
                try
                {
                    decimal i = 0;
                    DataSet ads = get_data("select id from " + s_schemaroot + ".v_loaibn order by id asc");
                    while (i < 9)
                    {
                        i = i + 1;
                        if (ads.Tables[0].Select("id=" + i.ToString()).Length <= 0)
                        {
                            break;
                        }
                    }
                    art = decimal.Parse(i.ToString());
                }
                catch
                {
                    art = 1;
                }
                return art;
            }
        }
        public decimal get_id_v_tenloaivp
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select ma from " + s_schemaroot + ".v_tenloaivp order by ma asc");
                    while (i < 99)
                    {
                        i = i + 1;
                        if (ads.Tables[0].Select("ma=" + i.ToString()).Length <= 0)
                        {
                            break;
                        }
                    }
                    art = decimal.Parse(i.ToString());
                }
                catch
                {
                    art = 1;
                }
                return art;
            }
        }
        public decimal get_id_v_dsduyet
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select ma from " + s_schemaroot + ".v_dsduyet order by ma asc");
                    while (i < 9999)
                    {
                        i = i + 1;
                        if (ads.Tables[0].Select("ma=" + i.ToString()).Length <= 0)
                        {
                            break;
                        }
                    }
                    art = decimal.Parse(i.ToString());
                }
                catch
                {
                    art = 1;
                }
                return art;
            }
        }
        public decimal get_stt_v_nhombhyt
        {
            get
            {
                decimal art = 1;
                try
                {
                    decimal i = 0;
                    DataSet ads = get_data("select distinct stt from " + s_schemaroot + ".v_nhombhyt order by stt asc");
                    while (i < 99)
                    {
                        i = i + 1;
                        if (ads.Tables[0].Select("id=" + i.ToString()).Length <= 0)
                        {
                            break;
                        }
                    }
                    art = decimal.Parse(i.ToString());
                }
                catch
                {
                    art = 1;
                }
                return art;
            }
        }
        public decimal get_id_v_nhombhyt
        {
            get
            {
                decimal art = 1;
                try
                {
                    decimal i = 0;
                    DataSet ads = get_data("select id from " + s_schemaroot + ".v_nhombhyt order by id asc");
                    while (i < 99)
                    {
                        i = i + 1;
                        if (ads.Tables[0].Select("id=" + i.ToString()).Length <= 0)
                        {
                            break;
                        }
                    }
                    art = decimal.Parse(i.ToString());
                }
                catch
                {
                    art = 1;
                }
                return art;
            }
        }
        public decimal get_stt_v_nhomvp
        {
            get
            {
                decimal art = 1;
                try
                {
                    decimal i = 0;
                    DataSet ads = get_data("select distinct stt from " + s_schemaroot + ".v_nhomvp order by stt asc");
                    while (i < 999)
                    {
                        i = i + 1;
                        if (ads.Tables[0].Select("id=" + i.ToString()).Length <= 0)
                        {
                            break;
                        }
                    }
                    art = decimal.Parse(i.ToString());
                }
                catch
                {
                    art = 1;
                }
                return art;
            }
        }
        public decimal get_id_v_nhomvp
        {
            get
            {
                decimal art = 1;
                try
                {
                    decimal i = 0;
                    DataSet ads = get_data("select ma from " + s_schemaroot + ".v_nhomvp order by ma asc");
                    while (i < 999)
                    {
                        i = i + 1;
                        if (ads.Tables[0].Select("ma=" + i.ToString()).Length <= 0)
                        {
                            break;
                        }
                    }
                    art = decimal.Parse(i.ToString());
                }
                catch
                {
                    art = 1;
                }
                return art;
            }
        }
        public decimal get_stt_v_loaivp
        {
            get
            {
                decimal art = 1;
                try
                {
                    decimal i = 0;
                    DataSet ads = get_data("select distinct stt from " + s_schemaroot + ".v_loaivp order by stt asc");
                    while (i < 999)
                    {
                        i = i + 1;
                        if (ads.Tables[0].Select("id=" + i.ToString()).Length <= 0)
                        {
                            break;
                        }
                    }
                    art = decimal.Parse(i.ToString());
                }
                catch
                {
                    art = 1;
                }
                return art;
            }
        }
        public decimal f_get_stt_v_loaivp(string v_id_nhom)
        {
            try
            {
                decimal art = 1;
                try
                {
                    decimal i = 0;
                    DataSet ads = get_data("select distinct stt from " + s_schemaroot + ".v_loaivp where id_nhom=" + v_id_nhom + " order by stt asc");
                    while (i < 999)
                    {
                        i = i + 1;
                        if (ads.Tables[0].Select("id=" + i.ToString()).Length <= 0)
                        {
                            break;
                        }
                    }
                    art = decimal.Parse(i.ToString());
                }
                catch
                {
                    art = 1;
                }
                return art;
            }
            catch
            {
                return 1;
            }
        }
        public decimal get_id_v_loaivp
        {
            get
            {
                decimal art = 1;
                try
                {
                    decimal i = 0;
                    DataSet ads = get_data("select id from " + s_schemaroot + ".v_loaivp order by id asc");
                    while (i < 999)
                    {
                        i = i + 1;
                        if (ads.Tables[0].Select("id=" + i.ToString()).Length <= 0)
                        {
                            break;
                        }
                    }
                    art = decimal.Parse(i.ToString());
                }
                catch
                {
                    art = 1;
                }
                return art;
            }
        }
        public decimal get_id_v_giavp
        {
            get
            {
                return get_capid(1);
            }
        }
        public decimal get_stt_v_giavp
        {
            get
            {
                decimal art = 1;
                try
                {
                    decimal i = 0;
                    DataSet ads = get_data("select distinct stt from " + s_schemaroot + ".v_giavp order by stt asc");
                    while (i < 9999999)
                    {
                        i = i + 1;
                        if (ads.Tables[0].Select("id=" + i.ToString()).Length <= 0)
                        {
                            break;
                        }
                    }
                    art = decimal.Parse(i.ToString());
                }
                catch
                {
                    art = 1;
                }
                return art;
            }
        }
        public decimal f_get_stt_v_giavp(string v_id_loai)
        {
            try
            {
                decimal art = 1;
                try
                {
                    decimal i = 0;
                    DataSet ads = get_data("select distinct stt from " + s_schemaroot + ".v_giavp where id_loai=" + v_id_loai + " order by stt asc");
                    while (i < 9999999)
                    {
                        i = i + 1;
                        if (ads.Tables[0].Select("id=" + i.ToString()).Length <= 0)
                        {
                            break;
                        }
                    }
                    art = decimal.Parse(i.ToString());
                }
                catch
                {
                    art = 1;
                }
                return art;
            }
            catch
            {
                return 1;
            }
        }

        public decimal get_maql { get { return decimal.Parse(get_capid(1).ToString()); } }
        #endregion CAPID

        #region KIỂM TRA DANH MỤC ĐÃ DÙNG
        public int dadung_v_dlogin(string v_id)
        {
            try
            {
                //if (get_data("select readonly from " + s_schemaroot + ".v_dlogin where id=" + v_id + " and readonly=1").Tables[0].Rows.Count > 0) return -1;
                if (get_data("select id from " + s_schemaroot + ".v_quyenso where userid=" + v_id + " limit 1").Tables[0].Rows.Count > 0) return 1;
                if (get_data("select id from " + s_schemaroot + ".v_nhomvp where userid=" + v_id + " limit 1").Tables[0].Rows.Count > 0) return 1;
                if (get_data("select id from " + s_schemaroot + ".v_loaivp where userid=" + v_id + " limit 1").Tables[0].Rows.Count > 0) return 1;
                if (get_data("select id from " + s_schemaroot + ".v_giavp where userid=" + v_id + " limit 1").Tables[0].Rows.Count > 0) return 1;
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    if (get_data("select id from " + r["schamaname"].ToString() + ".v_vienphill where userid=" + v_id + " limit 1").Tables[0].Rows.Count > 0) return 1;
                    if (get_data("select id from " + r["schamaname"].ToString() + ".v_ttrvll where userid=" + v_id + " limit 1").Tables[0].Rows.Count > 0) return 1;
                    if (get_data("select id from " + r["schamaname"].ToString() + ".v_tamung where userid=" + v_id + " limit 1").Tables[0].Rows.Count > 0) return 1;
                    if (get_data("select id from " + r["schamaname"].ToString() + ".v_hoantra where userid=" + v_id + " limit 1").Tables[0].Rows.Count > 0) return 1;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_v_nhomdlogin(string v_id)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".v_nhomdlogin where id=" + v_id + " and readonly=1 limit 1").Tables[0].Rows.Count > 0) return -1;
                if (get_data("select id from " + s_schemaroot + ".v_dlogin where id_nhom=" + v_id + " limit 1").Tables[0].Rows.Count > 0) return 1;
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_v_treebaocao(string v_id)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".v_treebaocao where id=" + v_id + " and readonly=1 limit 1").Tables[0].Rows.Count > 0) return -1;
                if (get_data("select id from " + s_schemaroot + ".v_treebaocao where id_cha=" + v_id + " limit 1").Tables[0].Rows.Count > 0) return 1;
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_v_quyenso(string v_id)
        {
            try
            {
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    if (get_data("select id from " + r["schemaname"].ToString() + ".v_vienphill where quyenso=" + v_id + " limit 1").Tables[0].Rows.Count > 0) return 1;
                    if (get_data("select id from " + r["schemaname"].ToString() + ".v_ttrvll where quyenso=" + v_id + " limit 1").Tables[0].Rows.Count > 0) return 1;
                    if (get_data("select id from " + r["schemaname"].ToString() + ".v_tamung where quyenso=" + v_id + " limit 1").Tables[0].Rows.Count > 0) return 1;
                    if (get_data("select id from " + r["schemaname"].ToString() + ".v_phieuchi where quyenso=" + v_id + " limit 1").Tables[0].Rows.Count > 0) return 1;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_v_dsduyet(string v_id)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".v_dsduyet where ma=" + v_id + " and readonly=1 limit 1").Tables[0].Rows.Count > 0) return -1;
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    if (get_data("select maduyet from " + r["schamaname"].ToString() + ".v_mienngtru where maduyet=" + v_id + " limit 1").Tables[0].Rows.Count > 0) return 1;
                    if (get_data("select maduyet from " + r["schamaname"].ToString() + ".v_miennoitru where maduyet=" + v_id + " limit 1").Tables[0].Rows.Count > 0) return 1;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_v_lydomien(string v_id)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".v_lydomien where id=" + v_id + " and readonly=1 limit 1").Tables[0].Rows.Count > 0) return -1;
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    if (get_data("select lydo from " + r["schamaname"].ToString() + ".v_mienngtru where lydo=" + v_id + " limit 1").Tables[0].Rows.Count > 0) return 1;
                    if (get_data("select lydo from " + r["schamaname"].ToString() + ".v_miennoitru where lydo=" + v_id + " limit 1").Tables[0].Rows.Count > 0) return 1;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_v_dmlydonopthem(string v_id)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".v_dmlydonopthem where id=" + v_id + " and readonly=1 limit 1").Tables[0].Rows.Count > 0) return -1;
                if (get_data("select id_lydo from " + s_schemaroot + ".v_lydonopthem where id_lydo=" + v_id + " limit 1").Tables[0].Rows.Count > 0) return 1;
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_v_dmlydothieu(string v_id)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".v_dmlydothieu where id=" + v_id + " and readonly=1 limit 1").Tables[0].Rows.Count > 0) return -1;
                if (get_data("select id_lydo from " + s_schemaroot + ".v_lydothieu where id_lydo=" + v_id + " limit 1").Tables[0].Rows.Count > 0) return 1;
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_v_loaibn(string v_id)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".v_loaibn where id=" + v_id + " and readonly=1 limit 1").Tables[0].Rows.Count > 0) return -1;
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    if (get_data("select loai from " + r["schamaname"].ToString() + ".v_phieuchill where loaibn=" + v_id + " limit 1").Tables[0].Rows.Count > 0) return 1;
                    if (get_data("select loai from " + r["schamaname"].ToString() + ".v_vienphill where loaibn=" + v_id + " limit 1").Tables[0].Rows.Count > 0) return 1;
                    if (get_data("select loai from " + r["schamaname"].ToString() + ".v_ttrvll where loaibn=" + v_id + " limit 1").Tables[0].Rows.Count > 0) return 1;
                    if (get_data("select loai from " + r["schamaname"].ToString() + ".v_tamung where loaibn=" + v_id + " limit 1").Tables[0].Rows.Count > 0) return 1;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_v_tenloaivp(string v_ma)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".v_tenloaivp where ma=" + v_ma + " and readonly=1 limit 1").Tables[0].Rows.Count > 0) return -1;
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    if (get_data("select loai from " + r["schamaname"].ToString() + ".v_phieuchill where loai=" + v_ma + " limit 1").Tables[0].Rows.Count > 0) return 1;
                    if (get_data("select loai from " + r["schamaname"].ToString() + ".v_vienphill where loai=" + v_ma + " limit 1").Tables[0].Rows.Count > 0) return 1;
                    if (get_data("select loai from " + r["schamaname"].ToString() + ".v_ttrvll where loai=" + v_ma + " limit 1").Tables[0].Rows.Count > 0) return 1;
                    if (get_data("select loai from " + r["schamaname"].ToString() + ".v_tamung where loai=" + v_ma + " limit 1").Tables[0].Rows.Count > 0) return 1;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_v_nhombhyt(string v_id)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".v_nhombhyt where id=" + v_id + " and readonly=1 limit 1").Tables[0].Rows.Count > 0) return -1;
                if (get_data("select idnhombhyt from " + s_schemaroot + ".v_nhomvp where idnhombhyt=" + v_id + " limit 1").Tables[0].Rows.Count > 0) return 1;
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_v_giavp(string v_id)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".v_giavp where id=" + v_id + " and readonly=1").Tables[0].Rows.Count > 0) return -1;
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    if (decimal.Parse(get_data("select count(id) from " + r["schemaname"].ToString() + ".v_vpkhoa where mavp=" + v_id + "").Tables[0].Rows[0][0].ToString()) > 0) return 1;
                    if (decimal.Parse(get_data("select id from " + r["schemaname"].ToString() + ".v_vienphict where mavp=" + v_id + "").Tables[0].Rows[0][0].ToString()) > 0) return 1;
                    if (decimal.Parse(get_data("select id from " + r["schemaname"].ToString() + ".v_ttrvct where mavp=" + v_id + "").Tables[0].Rows[0][0].ToString()) > 0) return 1;
                    if (decimal.Parse(get_data("select id from " + r["schemaname"].ToString() + ".v_chidinh where mavp=" + v_id + "").Tables[0].Rows[0][0].ToString()) > 0) return 1;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_v_loaivp(string v_id)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".v_loaivp where id=" + v_id + " and readonly=1 limit 1").Tables[0].Rows.Count > 0) return -1;
                if (get_data("select id from " + s_schemaroot + ".v_giavp where id_loai=" + v_id + " limit 1").Tables[0].Rows.Count > 0) return 1;

                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    if (get_data("select id from " + r["schemaname"].ToString() + ".v_tamungct where loaivp=" + v_id + " limit 1").Tables[0].Rows.Count > 0) return 1;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_v_nhomvp(string v_id)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".v_nhomvp where ma=" + v_id + " and readonly=1 limit 1").Tables[0].Rows.Count > 0) return -1;
                if (get_data("select id from " + s_schemaroot + ".v_loaivp where id_nhom=" + v_id + " limit 1").Tables[0].Rows.Count > 0) return 1;
                if (get_data("select id from " + s_schemaroot + ".d_dmnhom where nhomvp=" + v_id + " limit 1").Tables[0].Rows.Count > 0) return 1;

                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public decimal min_sobienlai(string v_quyensoid)
        {
            try
            {
                decimal amin = 0, atmp = 0;
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    atmp = decimal.Parse(get_data("select min(sobienlai) sobienlai from (select min(sobienlai) sobienlai from " + r["schamaname"].ToString() + ".v_vienphill where quyenso=" + v_quyensoid + " and sobienlai>0 union all select min(sobienlai) sobienlai from " + r["schamaname"].ToString() + ".v_ttrvll where quyenso=" + v_quyensoid + " and sobienlai>0 union all select min(sobienlai) sobienlai from " + r["schamaname"].ToString() + ".v_tamung where quyenso=" + v_quyensoid + " and sobienlai>0)").Tables[0].Rows[0][0].ToString());
                    if (atmp < amin) amin = atmp;
                }
                return amin;
            }
            catch
            {
                return 0;
            }
        }
        public decimal max_sobienlai(string v_quyensoid)
        {
            try
            {
                decimal amax = 0, atmp = 0;
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    atmp = decimal.Parse(get_data("select max(sobienlai) from (select max(sobienlai) sobienlai from " + r["schamaname"].ToString() + ".v_vienphill where quyenso=" + v_quyensoid + " and sobienlai>0 union all select max(sobienlai) sobienlai from " + r["schamaname"].ToString() + ".v_ttrvll where quyenso=" + v_quyensoid + " and sobienlai>0 union all select max(sobienlai) sobienlai from " + r["schamaname"].ToString() + ".v_tamung where quyenso=" + v_quyensoid + " and sobienlai>0)").Tables[0].Rows[0][0].ToString());
                    if (atmp > amax) amax = atmp;
                }
                return amax;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_v_vienphill(string v_mmyy, string v_id)
        {
            try
            {
                if (get_data_mmyy(v_mmyy, "select lanin from medibvmmyy.v_vienphill where lanin <> 0 and id=" + v_id + "").Tables[0].Rows.Count > 0) return 1;
                if (get_data_mmyy(v_mmyy, "select id from medibvmmyy.v_vienphict where lanin <> 0 and id=" + v_id + "").Tables[0].Rows.Count > 0) return 1;

                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_v_ttrvll(string v_mmyy, string v_id)
        {
            try
            {
                if (get_data_mmyy(v_mmyy, "select lanin from medibvmmyy.v_ttrvll where lanin <> 0 and id=" + v_id + "").Tables[0].Rows.Count > 0) return 1;

                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_v_tamung(string v_mmyy, string v_id)
        {
            try
            {
                if (get_data_mmyy(v_mmyy, "select lanin from medibvmmyy.v_tamung where lanin <> 0 and id=" + v_id + "").Tables[0].Rows.Count > 0) return 1;

                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_bhytkb(string v_mmyy, string v_id)
        {
            try
            {
                if (get_data_mmyy(v_mmyy, "select sotoa from medibvmmyy.bhytkb where sotoa <> 0 and id=" + v_id + "").Tables[0].Rows.Count > 0) return 1;

                return 0;
            }
            catch
            {
                return 0;
            }
        }

        #endregion KIỂM TRA DANH MỤC ĐÃ DÙNG

        #region CÁC HÀM THÔNG DỤNG

        public string f_kytuso(string v_so)
        {
            string ret = "", s1 = " 0123456789";
            try
            {
                for (int i = 0; i < v_so.Length; i++)
                    if (s1.IndexOf(v_so.Substring(i, 1)) != -1) ret += v_so.Substring(i, 1);
            }
            catch
            {
                ret = "";
            }
            return ret;
        }
        public string f_caps(string v_s)
        {
            string art = "";
            try
            {
                if (v_s.Length == 0) return null;
                System.Text.StringBuilder sb = new System.Text.StringBuilder(v_s.ToLower());
                sb[0] = Char.ToUpper(sb[0]);
                int num = 0; int ispace = 0;
                while (num < sb.Length)
                {
                    if (Char.IsWhiteSpace(sb[num])) ispace++;
                    if (!Char.IsWhiteSpace(sb[num]))
                    {
                        if (ispace > 0 && num > 0)
                        {
                            sb[num] = Char.ToUpper(sb[num]);
                            ispace = 0;
                        }
                    }
                    num++;
                }
                num = 0;
                ispace = 0;
                while (num < sb.Length)
                {
                    if (Char.IsWhiteSpace(sb[num]))
                    {
                        if (ispace < 1 && num > 0)
                        {
                            art += sb[num];
                        }
                        ispace++;
                    }
                    else
                    {
                        art += sb[num];
                        ispace = 0;
                    }
                    num++;
                }
            }
            catch
            {
                art = v_s;
            }
            return art;
        }
        public string f_writexml(string v_path, DataSet v_ds)
        {
            string art = v_path;
            try
            {
                v_ds.WriteXml(v_path, XmlWriteMode.WriteSchema);
            }
            catch
            {
                art = "";
            }
            return art;
        }
        public string f_write_option_history(string v_filename, string v_value)
        {
            string art = "..//..//option//" + v_filename;
            try
            {
                m_ds = new DataSet();
                m_ds.Tables.Add("table");
                m_ds.Tables[0].Columns.Add("val");
                m_ds.Tables[0].Rows.Add(new string[] { v_value });
                m_ds.WriteXml("..//..//option//" + v_filename, XmlWriteMode.WriteSchema);
            }
            catch
            {
                art = "";
            }
            return art;
        }
        public string f_get_option_history(string v_filename)
        {
            string art = "";
            try
            {
                m_ds = new DataSet();
                m_ds.ReadXml("..//..//option//" + v_filename);
                art = m_ds.Tables[0].Rows[0][0].ToString();
            }
            catch
            {
                art = "";
            }
            return art;
        }
        public string f_khongdau(string s)
        {
            try
            {
                m_ds = new DataSet();
                m_ds.ReadXml("..\\..\\..\\xml\\khongdau.xml");
                string s1 = s.Trim().ToUpper(), s2 = "";
                DataRow r;
                for (int i = 0; i < s1.Length; i++)
                {
                    if (s1[i].ToString().Trim() != "")
                    {
                        try
                        {
                            r = m_ds.Tables[0].Select("codau='" + s1[i].ToString() + "'")[0];
                        }
                        catch
                        {
                            r = null;
                        }

                        if (r != null) s2 += r[1].ToString();
                        else s2 += s1[i];
                    }
                }
                return s2;
            }
            catch
            {
                return "";
            }
        }

        #endregion CÁC HÀM THÔNG DỤNG

        #region BIẾN TOÀN CỤC
        public int s_loaibn_tiepdon
        {
            get
            {
                return 0;
            }
        }
        public int s_loaibn_noitru
        {
            get
            {
                return 1;
            }
        }
        public int s_loaibn_ngoaitru
        {
            get
            {
                return 2;
            }
        }
        public int s_loaibn_phongkham
        {
            get
            {
                return 3;
            }
        }
        public int s_loaibn_phongluu
        {
            get
            {
                return 4;
            }
        }
        public bool s_bienlainoitru_inchitiet
        {
            get
            {
                return false;
            }
        }
        public string s_diachi
        {
            get
            {
                return "";
            }
        }
        public string s_masothue
        {
            get
            {
                return "";
            }
        }
        public string s_maubienlai
        {
            get
            {
                return "";
            }
        }
        public bool is_dba_admin(string v_userid)
        {
            try
            {
                return get_data("select a.id from medibv.v_dlogin a left join medibv.v_nhomdlogin b on a.id_nhom=b.id where a.id=" + v_userid + " and b.nhom=1").Tables[0].Rows.Count > 0;
            }
            catch
            {
                return false;
            }
        }
        public bool is_app_admin(string v_userid)
        {
            try
            {
                return get_data("select a.id from medibv.v_dlogin a left join medibv.v_nhomdlogin b on a.id_nhom=b.id where a.id=" + v_userid + " and b.nhom=2").Tables[0].Rows.Count > 0;
            }
            catch
            {
                return false;
            }
        }
        public bool is_dep_admin(string v_userid)
        {
            try
            {
                return get_data("select a.id from medibv.v_dlogin a left join medibv.v_nhomdlogin b on a.id_nhom=b.id where a.id=" + v_userid + " and b.nhom=3").Tables[0].Rows.Count > 0;
            }
            catch
            {
                return false;
            }
        }
        public bool is_admin(string v_userid)
        {
            try
            {
                return get_data("select a.id from medibv.v_dlogin a left join medibv.v_nhomdlogin b on a.id_nhom=b.id where a.id=" + v_userid + " and b.nhom in(1,2,3)").Tables[0].Rows.Count > 0;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region THÔNG SỐ HỆ THỐNG

        public string f_thongso_soyte
        {
            get
            {
                string art = "";
                try
                {
                    art = get_data("select giatri from " + s_schemaroot + ".v_systhongso where ma = ''").Tables[0].Rows[0][0].ToString();
                }
                catch
                {
                    art = "";
                }
                return art;
            }
        }
        public string f_thongso_benhvien
        {
            get
            {
                string art = "";
                try
                {
                    art = get_data("select giatri from " + s_schemaroot + ".v_systhongso where ma = ''").Tables[0].Rows[0][0].ToString();
                }
                catch
                {
                    art = "";
                }
                return art;
            }
        }

        #endregion THÔNG SỐ HỆ THỐNG

        #region CẬP NHẬT DATA TABLES
        //New
        public void upd_dmcomputer(string m_computer)
        {
            string aid = "1";
            try
            {
                aid = get_data("select max(id)+1 from " + m_db_schemaroot + ".dmcomputer").Tables[0].Rows[0][0].ToString();
            }
            catch
            {
                aid = "1";
            }

            m_sql = "update " + m_db_schemaroot + ".dmcomputer set computer=:m_computer where computer=:m_computer";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;
            m_command.Parameters.Add("m_computer", NpgsqlDbType.Varchar, 20).Value = m_computer;
            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    if (aid == "") aid = "1";
                    m_sql = "insert into " + m_db_schemaroot + ".dmcomputer(id,computer,ngayud) values (" + aid + ",:m_computer,now())";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("m_computer", NpgsqlDbType.Varchar, 20).Value = m_computer;
                    m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                //f_write_error(ex.ToString());
                upd_v_error(ex.Message, m_computername, "dmcomputer");
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
        }
        public void upd_dmcomputer()
        {
            upd_dmcomputer(m_computername);
        }
        public void upd_table()
        {
            try
            {
                DataSet ads = get_data("select trim(mmyy) as mmyy from " + s_schemaroot + ".table");
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    string atmp = r["schemaname"].ToString();
                    if (ads.Tables[0].Select("mmyy='" + r["schemaname"].ToString().Trim().Replace(s_schemaroot, "") + "'").Length < 0)
                    {
                        execute_data("insert into " + s_schemaroot + ".table (mmyy,userid,ngayud,computer) values('" + r["schemaname"].ToString().Replace(s_schemaroot, "") + "',1,now(),'" + m_computername + "')");
                    }
                }
            }
            catch
            {
            }
        }
        public bool upd_v_option(string v_ma, string v_giatri)
        {
            m_sql = "update " + m_db_schemaroot + ".v_option set giatri=:v_giatri where ma=:v_ma";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_ma", NpgsqlDbType.Text).Value = v_ma;
            m_command.Parameters.Add("v_giatri", NpgsqlDbType.Text).Value = v_giatri;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".v_option(ma, giatri) values(:v_ma, :v_giatri)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Text).Value = v_ma;
                    m_command.Parameters.Add("v_giatri", NpgsqlDbType.Text).Value = v_giatri;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_option");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_treebaocao(decimal v_id, decimal v_id_cha, decimal v_stt, string v_ten, string v_asql, string v_tenreport, decimal v_readonly)
        {
            m_sql = "update " + m_db_schemaroot + ".v_treebaocao set id_cha=:v_id_cha, stt=:v_stt,ten=:v_ten, asql=:v_asql,tenreport=:v_tenreport, readonly=:v_readonly where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_id_cha", NpgsqlDbType.Numeric).Value = v_id_cha;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
            m_command.Parameters.Add("v_asql", NpgsqlDbType.Text).Value = v_asql;
            m_command.Parameters.Add("v_tenreport", NpgsqlDbType.Text).Value = v_tenreport;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".v_treebaocao(id,id_cha,stt,ten,asql,tenreport,readonly) values(:v_id,:v_id_cha,:v_stt,:v_ten,:v_asql,:v_tenreport,:v_readonly)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_id_cha", NpgsqlDbType.Numeric).Value = v_id_cha;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_asql", NpgsqlDbType.Text).Value = v_asql;
                    m_command.Parameters.Add("v_tenreport", NpgsqlDbType.Text).Value = v_tenreport;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_treebaocao");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public void upd_v_error(string v_message, string v_computer, string v_table)
        {
            m_sql = "insert into " + s_schemaroot + ".v_error(message,computer,tables,ngayud) values (:v_message,:v_computer,:v_table,now())";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_message", NpgsqlDbType.Varchar, 254).Value = v_message;
            m_command.Parameters.Add("v_computer", NpgsqlDbType.Varchar, 20).Value = v_computer;
            m_command.Parameters.Add("v_table", NpgsqlDbType.Varchar, 20).Value = v_table;
            try
            {
                m_connection.Open();
                m_command.ExecuteNonQuery();
            }
            catch { }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
        }
        public void upd_v_error(string v_mmyy, string m_message, string m_computer, string m_table)
        {
            m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".v_error(message,computer,tables,ngayud) values (:m_message,:m_computer,:m_table,now())";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("m_message", NpgsqlDbType.Varchar, 254).Value = m_message;
            m_command.Parameters.Add("m_computer", NpgsqlDbType.Varchar, 20).Value = m_computer;
            m_command.Parameters.Add("m_table", NpgsqlDbType.Varchar, 20).Value = m_table;
            try
            {
                m_connection.Open();
                m_command.ExecuteNonQuery();
            }
            catch { }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
        }
        public bool upd_v_phanquyen(decimal v_userid, string v_menuname, decimal v_chon, string v_chitiet)
        {
            m_sql = "update " + m_db_schemaroot + ".v_phanquyen set chon=:v_chon, chitiet=:v_chitiet where userid=:v_userid and menuname=:v_menuname";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
            m_command.Parameters.Add("v_menuname", NpgsqlDbType.Text).Value = v_menuname;
            m_command.Parameters.Add("v_chon", NpgsqlDbType.Numeric).Value = v_chon;
            m_command.Parameters.Add("v_chitiet", NpgsqlDbType.Text).Value = v_chitiet;
            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".v_phanquyen(userid,menuname,chon,chitiet) values (:v_userid,:v_menuname,:v_chon,:v_chitiet)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                    m_command.Parameters.Add("v_menuname", NpgsqlDbType.Text).Value = v_menuname;
                    m_command.Parameters.Add("v_chon", NpgsqlDbType.Numeric).Value = v_chon;
                    m_command.Parameters.Add("v_chitiet", NpgsqlDbType.Text).Value = v_chitiet;
                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_v_error(ex.Message, m_computername, "v_phanquyen");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_phanquyennhom(decimal v_id_nhom, string v_menuname, decimal v_chon, string v_chitiet)
        {
            m_sql = "update " + m_db_schemaroot + ".v_phanquyennhom set chon=:v_chon, chitiet=:v_chitiet where id_nhom=:v_id_nhom and menuname=:v_menuname";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id_nhom", NpgsqlDbType.Numeric).Value = v_id_nhom;
            m_command.Parameters.Add("v_menuname", NpgsqlDbType.Text).Value = v_menuname;
            m_command.Parameters.Add("v_chon", NpgsqlDbType.Numeric).Value = v_chon;
            m_command.Parameters.Add("v_chitiet", NpgsqlDbType.Text).Value = v_chitiet;
            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".v_phanquyennhom(id_nhom,menuname,chon,chitiet) values (:v_id_nhom,:v_menuname,:v_chon,:v_chitiet)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id_nhom", NpgsqlDbType.Numeric).Value = v_id_nhom;
                    m_command.Parameters.Add("v_menuname", NpgsqlDbType.Text).Value = v_menuname;
                    m_command.Parameters.Add("v_chon", NpgsqlDbType.Numeric).Value = v_chon;
                    m_command.Parameters.Add("v_chitiet", NpgsqlDbType.Text).Value = v_chitiet;
                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_v_error(ex.Message, m_computername, "v_phanquyennhom");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_viettat(decimal v_stt, string v_ma, string v_ten, decimal v_readonly)
        {
            m_sql = "update " + m_db_schemaroot + ".v_viettat set stt=:v_stt,ten=:v_ten, readonly=:v_readonly where ma=:v_ma";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_ma", NpgsqlDbType.Text).Value = v_ma;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".v_viettat(stt,ma,ten,readonly) values(:v_stt,:v_ma,:v_ten,:v_readonly)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Text).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_viettat");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }

        //New

        public bool upd_v_bhyt(string v_mmyy, decimal v_id, string v_sothe, decimal v_maphu, string v_mabv, string v_noigioithieu)
        {
            m_sql = "update " + s_schemaroot + v_mmyy + ".v_bhyt set sothe=:v_sothe, maphu=:v_maphu, mabv=:v_mabv, noigioithieu=:v_noigioithieu where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_sothe", NpgsqlDbType.Varchar, 16).Value = v_sothe;
            m_command.Parameters.Add("v_maphu", NpgsqlDbType.Numeric).Value = v_maphu;
            m_command.Parameters.Add("v_mabv", NpgsqlDbType.Varchar, 8).Value = v_mabv;
            m_command.Parameters.Add("v_noigioithieu", NpgsqlDbType.Varchar, 8).Value = v_noigioithieu;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".v_bhyt(id,sothe,maphu,mabv,noigioithieu) values(:v_id,:v_sothe,:v_maphu,:v_mabv,:v_noigioithieu)";
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_sothe", NpgsqlDbType.Varchar, 16).Value = v_sothe;
                    m_command.Parameters.Add("v_maphu", NpgsqlDbType.Numeric).Value = v_maphu;
                    m_command.Parameters.Add("v_mabv", NpgsqlDbType.Varchar, 8).Value = v_mabv;
                    m_command.Parameters.Add("v_noigioithieu", NpgsqlDbType.Varchar, 8).Value = v_noigioithieu;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(v_mmyy, ex.Message, m_computername, "v_bhyt");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_bhyt(string v_mmyy, decimal v_id, decimal v_maql)
        {
            string v_sothe = "", v_ngay = "", v_mabv = "", v_noigioithieu = "";
            int v_maphu = 0;
            try
            {
                m_ds = get_data("select sothe,to_char(denngay,'dd/mm/yyyy hh24:mi') denngay,mabv,maphu from " + s_schema_mmyy(v_mmyy) + ".bhyt where maql=" + v_maql);
                v_sothe = m_ds.Tables[0].Rows[0]["sothe"].ToString().Trim();
                v_ngay = m_ds.Tables[0].Rows[0]["denngay"].ToString().Trim();
                v_mabv = m_ds.Tables[0].Rows[0]["mabv"].ToString().Trim();
                v_noigioithieu = v_mabv;
                v_maphu = int.Parse(m_ds.Tables[0].Rows[0]["maphu"].ToString().Trim());
            }
            catch
            {
                return false;
            }
            return upd_v_bhyt(v_mmyy, v_id, v_sothe, v_maphu, v_mabv, v_noigioithieu);
        }
        public bool upd_v_chidinh(string v_mmyy, decimal v_id, string v_mabn, decimal v_mavaovien, decimal v_maql, decimal v_idkhoa, string v_ngay, decimal v_loai, string v_makp, decimal v_madoituong, decimal v_mavp, decimal v_soluong, decimal v_dongia, decimal v_userid)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".v_chidinh set mabn=:v_mabn, mavaovien=:v_mavaovien, maql=:v_maql, idkhoa=:v_idkhoa, ngay=to_date(:v_ngay,'dd/mm/yyyy hh24:mi'), loai=:v_loai, makp=:v_makp, madoituong=:v_madoituong,mavp=:v_mavp,soluong=:v_soluong, dongia=:v_dongia,userid=:v_userid where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 8).Value = v_mabn;
            m_command.Parameters.Add("v_mavaovien", NpgsqlDbType.Numeric).Value = v_mavaovien;
            m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
            m_command.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
            m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 16).Value = v_ngay;
            m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
            m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 3).Value = v_makp;
            m_command.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
            m_command.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
            m_command.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
            m_command.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;
            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".v_chidinh(id,mabn,mavaovien,maql,idkhoa,ngay,loai,makp,madoituong,mavp,soluong,dongia,userid,ngayud) values(:v_id,:v_mabn,:v_mavaovien,:v_maql,:v_idkhoa,to_date(:v_ngay,'dd/mm/yyyy hh24:mi'),:v_loai,:v_makp,:v_madoituong,:v_mavp,:v_soluong,:v_dongia,:v_userid,now())";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 8).Value = v_mabn;
                    m_command.Parameters.Add("v_mavaovien", NpgsqlDbType.Numeric).Value = v_mavaovien;
                    m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                    m_command.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
                    m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 16).Value = v_ngay;
                    m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                    m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 3).Value = v_makp;
                    m_command.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
                    m_command.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
                    m_command.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
                    m_command.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;
                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(v_mmyy, ex.Message, m_computername, "v_chidinh");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_congno(string v_mmyy, string v_mabn, decimal v_maql, decimal v_idkhoa, decimal v_mavp, decimal v_sotien, decimal v_dathu)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".v_congno set maql=:v_maql, idkhoa=:v_idkhoa, sotien=:v_sotien, dathu=:v_dathu where mabn=:v_mabn and mavp=:v_mavp";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 8).Value = v_mabn;
            m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
            m_command.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
            m_command.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
            m_command.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
            m_command.Parameters.Add("v_dathu", NpgsqlDbType.Numeric).Value = v_dathu;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".v_congno(mabn,maql,idkhoa,mavp,sotien,dathu) values(:v_mabn,:v_maql,:v_idkhoa,:v_mavp,:v_sotien,:v_dathu)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 8).Value = v_mabn;
                    m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                    m_command.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
                    m_command.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
                    m_command.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                    m_command.Parameters.Add("v_dathu", NpgsqlDbType.Numeric).Value = v_dathu;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(v_mmyy, ex.Message, m_computername, "v_congno");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;

        }
        public string upd_v_hoantra(string v_mmyy, decimal v_id, decimal v_quyenso, decimal v_sobienlai, string v_ngay10, string v_ngaythu10, string v_mabn, decimal v_mavaovien, decimal v_maql, string v_hoten, string v_makp, decimal v_sotien, string v_ghichu, decimal v_userid, decimal v_loai, decimal v_loaibn)
        {
            if (v_id == 0)
            {
                v_id = get_id_v_hoantra;
            }
            if (v_mmyy == "")
            {
                v_mmyy = get_mmyy(v_ngay10);
            }
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".v_hoantra set quyenso=:v_quyenso, sobienlai=:v_sobienlai, ngay=to_date(:v_ngay,'dd/mm/yyyy'), mabn=:v_mabn, mavaovien=:v_mavaovien, maql=:v_maql, hoten=:v_hoten, makp=:v_makp,sotien=:v_sotien,ghichu=:v_ghichu, userid=:v_userid, loai=:v_loai, loaibn=:v_loaibn,ngayud=to_date(:v_ngaythu,'dd/mm/yyyy') where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_quyenso", NpgsqlDbType.Numeric).Value = v_quyenso;
            m_command.Parameters.Add("v_sobienlai", NpgsqlDbType.Numeric).Value = v_sobienlai;
            m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay10;
            m_command.Parameters.Add("v_ngaythu", NpgsqlDbType.Varchar, 10).Value = v_ngaythu10;
            m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 8).Value = v_mabn;
            m_command.Parameters.Add("v_mavaovien", NpgsqlDbType.Numeric).Value = v_mavaovien;
            m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
            m_command.Parameters.Add("v_hoten", NpgsqlDbType.Text).Value = v_hoten;
            m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 3).Value = v_makp;
            m_command.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
            m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;
            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
            m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
            m_command.Parameters.Add("v_loaibn", NpgsqlDbType.Numeric).Value = v_loaibn;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".v_hoantra(id,quyenso,sobienlai,ngay,mabn,mavaovien,maql,hoten,makp,sotien,ghichu,userid,loai,loaibn,ngayud) values(:v_id,:v_quyenso,:v_sobienlai,to_date(:v_ngay,'dd/mm/yyyy'),:v_mabn,:v_mavaovien,:v_maql,:v_hoten,:v_makp,:v_sotien,:v_ghichu,:v_userid,:v_loai,:v_loaibn,to_date(:v_ngaythu,'dd/mm/yyyy'))";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_quyenso", NpgsqlDbType.Numeric).Value = v_quyenso;
                    m_command.Parameters.Add("v_sobienlai", NpgsqlDbType.Numeric).Value = v_sobienlai;
                    m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay10;
                    m_command.Parameters.Add("v_ngaythu", NpgsqlDbType.Varchar, 10).Value = v_ngaythu10;
                    m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 8).Value = v_mabn;
                    m_command.Parameters.Add("v_mavaovien", NpgsqlDbType.Numeric).Value = v_mavaovien;
                    m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                    m_command.Parameters.Add("v_hoten", NpgsqlDbType.Text).Value = v_hoten;
                    m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 3).Value = v_makp;
                    m_command.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                    m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;
                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                    m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                    m_command.Parameters.Add("v_loaibn", NpgsqlDbType.Numeric).Value = v_loaibn;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(v_mmyy, ex.Message, m_computername, "v_hoantra");
                v_id = 0;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return v_id.ToString();
        }
        public bool upd_v_hoantract(string v_mmyy, decimal v_id, decimal v_loaivp, decimal v_sotien)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".v_hoantract set sotien=:v_sotien where id=:v_id and loaivp=:v_loaivp";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_loaivp", NpgsqlDbType.Numeric).Value = v_loaivp;
            m_command.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".v_hoantract(id,loaivp,sotien) values(:v_id,:v_loaivp,:v_sotien)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_loaivp", NpgsqlDbType.Numeric).Value = v_loaivp;
                    m_command.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(v_mmyy, ex.Message, m_computername, "v_hoantract");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_mienngtru(string v_mmyy, decimal v_id, decimal v_lydo, decimal v_sotien, string v_ghichu, decimal v_maduyet)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".v_mienngtru set lydo=:v_lydo,sotien=:v_sotien, ghichu=:v_ghichu, maduyet=:v_maduyet where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;
            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_lydo", NpgsqlDbType.Numeric).Value = v_lydo;
            m_command.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
            m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text, 100).Value = v_ghichu;
            m_command.Parameters.Add("v_maduyet", NpgsqlDbType.Numeric).Value = v_maduyet;
            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".v_mienngtru(id,lydo,sotien,ghichu,maduyet) values(:v_id,:v_lydo,:v_sotien,:v_ghichu,:v_maduyet)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_lydo", NpgsqlDbType.Numeric).Value = v_lydo;
                    m_command.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                    m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text, 100).Value = v_ghichu;
                    m_command.Parameters.Add("v_maduyet", NpgsqlDbType.Numeric).Value = v_maduyet;
                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(v_mmyy, ex.Message, m_computername, "v_mienngtru");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_miennoitru(string v_mmyy, decimal v_id, decimal v_lydo, string v_ghichu, decimal v_maduyet)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".v_miennoitru set lydo=:v_lydo,ghichu=:v_ghichu, maduyet=:v_maduyet where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;
            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_lydo", NpgsqlDbType.Numeric).Value = v_lydo;
            m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text, 100).Value = v_ghichu;
            m_command.Parameters.Add("v_maduyet", NpgsqlDbType.Numeric).Value = v_maduyet;
            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".v_miennoitru(id,lydo,ghichu,maduyet) values(:v_id,:v_lydo,:v_ghichu,:v_maduyet)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_lydo", NpgsqlDbType.Numeric).Value = v_lydo;
                    m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text, 100).Value = v_ghichu;
                    m_command.Parameters.Add("v_maduyet", NpgsqlDbType.Numeric).Value = v_maduyet;
                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(v_mmyy, ex.Message, m_computername, "v_miennoitru");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public string upd_v_phieuchill(string v_mmyy, decimal v_id, decimal v_quyenso, decimal v_sobienlai, string v_ngay10, string v_mabn, decimal v_maql, decimal v_idkhoa, string v_makp, string v_hoten, decimal v_loai, decimal v_loaibn, decimal v_userid)
        {
            if (v_id == 0)
            {
                v_id = get_id_v_phieuchi;
            }
            if (v_mmyy == "")
            {
                v_mmyy = get_mmyy(v_ngay10);
            }
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".v_phieuchill set quyenso=:v_quyenso,sobienlai=:v_sobienlai, ngay=to_date(:v_ngay,'dd/mm/yyyy'), mabn=:v_mabn,maql=:v_maql,idkhoa=:v_idkhoa,makp=:v_makp,hoten=:v_hoten, loai=:v_loai,loaibn=:v_loaibn,userid=:v_userid where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;
            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_quyenso", NpgsqlDbType.Numeric).Value = v_quyenso;
            m_command.Parameters.Add("v_sobienlai", NpgsqlDbType.Numeric).Value = v_sobienlai;
            m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay10;
            m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 8).Value = v_mabn;
            m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
            m_command.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
            m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 3).Value = v_makp;
            m_command.Parameters.Add("v_hoten", NpgsqlDbType.Text, 50).Value = v_hoten;
            m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
            m_command.Parameters.Add("v_loaibn", NpgsqlDbType.Numeric).Value = v_loaibn;
            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".v_phieuchill(id,quyenso,sobienlai,ngay,mabn,maql,idkhoa,makp,hoten,loai,loaibn,userid) values(:v_id,:v_quyenso,:v_sobienlai,to_date(:v_ngay,'dd/mm/yyyy'),:v_mabn,:v_maql,:v_idkhoa,:v_makp,:v_hoten,:v_loai,:v_loaibn,:v_userid)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_quyenso", NpgsqlDbType.Numeric).Value = v_quyenso;
                    m_command.Parameters.Add("v_sobienlai", NpgsqlDbType.Numeric).Value = v_sobienlai;
                    m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay10;
                    m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 8).Value = v_mabn;
                    m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                    m_command.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
                    m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 3).Value = v_makp;
                    m_command.Parameters.Add("v_hoten", NpgsqlDbType.Text, 50).Value = v_hoten;
                    m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                    m_command.Parameters.Add("v_loaibn", NpgsqlDbType.Numeric).Value = v_loaibn;
                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(v_mmyy, ex.Message, m_computername, "v_phieuchill");
                v_id = 0;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return v_id.ToString();
        }
        public string upd_v_phieuchict(string v_mmyy, decimal v_id, decimal v_stt, decimal v_mavp, decimal v_sotien)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".v_phieuchict set mavp=:v_mavp,sotien=:v_sotien where id=:v_id and stt=:v_stt";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
            m_command.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".v_phieuchict(id,stt,mavp,sotien) values(:v_id,:v_stt,:v_mavp,:v_sotien)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
                    m_command.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(v_mmyy, ex.Message, m_computername, "v_phieuchict");
                v_id = 0;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return v_id.ToString();
        }
        public string upd_v_tamung(string v_mmyy, decimal v_id, string v_mabn, decimal v_mavaovien, decimal v_maql, decimal v_idkhoa, decimal v_quyenso, decimal v_sobienlai, string v_ngay10, decimal v_loai, string v_makp, decimal v_madoituong, decimal v_loaibn, decimal v_sotien, decimal v_userid)
        {
            if (v_id == 0)
            {
                v_id = get_id_v_tamung;
            }
            if (v_mmyy == "")
            {
                v_mmyy = get_mmyy(v_ngay10);
            }
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".v_tamung set mabn=:v_mabn,mavaovien=:v_mavaovien,maql=:v_maql,idkhoa=:v_idkhoa,quyenso=:v_quyenso,sobienlai=:v_sobienlai,ngay=to_date(:v_ngay,'dd/mm/yyyy'),loai=:v_loai, makp=:v_makp,madoituong=:v_madoituong,sotien=:v_sotien,loaibn=:v_loaibn,userid=:v_userid where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 8).Value = v_mabn;
            m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
            m_command.Parameters.Add("v_mavaovien", NpgsqlDbType.Numeric).Value = v_mavaovien;
            m_command.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
            m_command.Parameters.Add("v_quyenso", NpgsqlDbType.Numeric).Value = v_quyenso;
            m_command.Parameters.Add("v_sobienlai", NpgsqlDbType.Numeric).Value = v_sobienlai;
            m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay10;
            m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
            m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 3).Value = v_makp;
            m_command.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
            m_command.Parameters.Add("v_loaibn", NpgsqlDbType.Numeric).Value = v_loaibn;
            m_command.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".v_tamung(id,mabn,mavaovien,maql,idkhoa,quyenso,sobienlai,ngay,loai,makp,madoituong,loaibn,sotien,userid) values(:v_id,:v_mabn,:v_mavaovien,:v_maql,:v_idkhoa,:v_quyenso,:v_sobienlai,to_date(:v_ngay,'dd/mm/yyyy'),:v_loai,:v_makp,:v_madoituong,:v_loaibn,:v_sotien,:v_userid)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 8).Value = v_mabn;
                    m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                    m_command.Parameters.Add("v_mavaovien", NpgsqlDbType.Numeric).Value = v_mavaovien;
                    m_command.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
                    m_command.Parameters.Add("v_quyenso", NpgsqlDbType.Numeric).Value = v_quyenso;
                    m_command.Parameters.Add("v_sobienlai", NpgsqlDbType.Numeric).Value = v_sobienlai;
                    m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay10;
                    m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                    m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 3).Value = v_makp;
                    m_command.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
                    m_command.Parameters.Add("v_loaibn", NpgsqlDbType.Numeric).Value = v_loaibn;
                    m_command.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(v_mmyy, ex.Message, m_computername, "v_tamung");
                v_id = 0;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return v_id.ToString();
        }
        public bool upd_v_tamungct(string v_mmyy, decimal v_id, decimal v_loaivp, decimal v_sotien)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".v_tamungct set sotien=:v_sotien where id=:v_id and loaivp=:v_loaivp";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_loaivp", NpgsqlDbType.Numeric).Value = v_loaivp;
            m_command.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".v_tamungct(id,loaivp,sotien) values(:v_id,:v_loaivp,:v_sotien)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_loaivp", NpgsqlDbType.Numeric).Value = v_loaivp;
                    m_command.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(v_mmyy, ex.Message, m_computername, "v_tamungct");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public string upd_v_ttrvll(string v_mmyy, decimal v_id, decimal v_loaibn, decimal v_loai, decimal v_quyenso, decimal v_sobienlai, string v_ngay10, string v_makp, decimal v_sotien, decimal v_tamung, decimal v_mien, decimal v_bhyt, decimal v_thieu, decimal v_nopthem, decimal v_chenhlech, decimal v_vattu, decimal v_idtonghop, decimal v_userid)
        {
            if (v_id == 0)
            {
                return "0";
            }
            if (v_mmyy == "")
            {
                v_mmyy = get_mmyy(v_ngay10);
            }
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".v_ttrvll set loaibn=:v_loaibn, loai=:v_loai,quyenso=:v_quyenso,sobienlai=:v_sobienlai,ngay=to_date(:v_ngay,'dd/mm/yyyy'), makp=:v_makp,sotien=:v_sotien,tamung=:v_tamung,mien=:v_mien,bhyt=:v_bhyt, thieu=:v_thieu, nopthem=:v_nopthem, chenhlech=:v_chenhlech, vattu=:v_vattu, idtonghop=:v_idtonghop, userid=:v_userid where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_loaibn", NpgsqlDbType.Numeric).Value = v_loaibn;
            m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
            m_command.Parameters.Add("v_quyenso", NpgsqlDbType.Numeric).Value = v_quyenso;
            m_command.Parameters.Add("v_sobienlai", NpgsqlDbType.Numeric).Value = v_sobienlai;
            m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay10;
            m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 3).Value = v_makp;
            m_command.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
            m_command.Parameters.Add("v_tamung", NpgsqlDbType.Numeric).Value = v_tamung;
            m_command.Parameters.Add("v_mien", NpgsqlDbType.Numeric).Value = v_mien;
            m_command.Parameters.Add("v_bhyt", NpgsqlDbType.Numeric).Value = v_bhyt;
            m_command.Parameters.Add("v_thieu", NpgsqlDbType.Numeric).Value = v_thieu;
            m_command.Parameters.Add("v_nopthem", NpgsqlDbType.Numeric).Value = v_nopthem;
            m_command.Parameters.Add("v_chenhlech", NpgsqlDbType.Numeric).Value = v_chenhlech;
            m_command.Parameters.Add("v_vattu", NpgsqlDbType.Numeric).Value = v_vattu;
            m_command.Parameters.Add("v_idtonghop", NpgsqlDbType.Numeric).Value = v_idtonghop;
            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".v_ttrvll(id,loaibn,loai,quyenso,sobienlai,ngay,makp,sotien,tamung,mien,bhyt,thieu,nopthem,chenhlech,vattu,idtonghop,userid) values(:v_id,:v_loaibn,:v_loai,:v_quyenso,:v_sobienlai,to_date(:v_ngay,'dd/mm/yyyy'),:v_makp,:v_sotien,:v_tamung,:v_mien,:v_bhyt,:v_thieu,:v_nopthem,:v_chenhlech,:v_vattu,:v_idtonghop,:v_userid)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_loaibn", NpgsqlDbType.Numeric).Value = v_loaibn;
                    m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                    m_command.Parameters.Add("v_quyenso", NpgsqlDbType.Numeric).Value = v_quyenso;
                    m_command.Parameters.Add("v_sobienlai", NpgsqlDbType.Numeric).Value = v_sobienlai;
                    m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay10;
                    m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 3).Value = v_makp;
                    m_command.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                    m_command.Parameters.Add("v_tamung", NpgsqlDbType.Numeric).Value = v_tamung;
                    m_command.Parameters.Add("v_mien", NpgsqlDbType.Numeric).Value = v_mien;
                    m_command.Parameters.Add("v_bhyt", NpgsqlDbType.Numeric).Value = v_bhyt;
                    m_command.Parameters.Add("v_thieu", NpgsqlDbType.Numeric).Value = v_thieu;
                    m_command.Parameters.Add("v_nopthem", NpgsqlDbType.Numeric).Value = v_nopthem;
                    m_command.Parameters.Add("v_chenhlech", NpgsqlDbType.Numeric).Value = v_chenhlech;
                    m_command.Parameters.Add("v_vattu", NpgsqlDbType.Numeric).Value = v_vattu;
                    m_command.Parameters.Add("v_idtonghop", NpgsqlDbType.Numeric).Value = v_idtonghop;
                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(v_mmyy, ex.Message, m_computername, "v_ttrvll");
                v_id = 0;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return v_id.ToString();
        }
        public bool upd_v_ttrvct(string v_mmyy, decimal v_id, decimal v_stt, string v_ngay10, string v_makp, decimal v_madoituong, decimal v_mavp, decimal v_soluong, decimal v_dongia, decimal v_vat, decimal v_vattu, decimal v_sotien)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".v_ttrvct set ngay=to_date(:v_ngay,'dd/mm/yyyy'), makp=:v_makp,madoituong=:v_madoituong,mavp=:v_mavp,soluong=:v_soluong, dongia=:v_dongia, vat=:v_vat, vattu=:v_vattu, sotien=:v_sotien where id=:v_id and stt=:v_stt";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay10;
            m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 3).Value = v_makp;
            m_command.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
            m_command.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
            m_command.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
            m_command.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;
            m_command.Parameters.Add("v_vat", NpgsqlDbType.Numeric).Value = v_vat;
            m_command.Parameters.Add("v_vattu", NpgsqlDbType.Numeric).Value = v_vattu;
            m_command.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".v_ttrvct(id,stt,ngay,makp,madoituong,mavp,soluong,dongia,vat,vattu,sotien) values(:v_id,:v_stt,to_date(:v_ngay,'dd/mm/yyyy'),:v_makp,:v_madoituong,:v_mavp,:v_soluong,:v_dongia,:v_vat,:v_vattu,:v_sotien)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay10;
                    m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 3).Value = v_makp;
                    m_command.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
                    m_command.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
                    m_command.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
                    m_command.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;
                    m_command.Parameters.Add("v_vat", NpgsqlDbType.Numeric).Value = v_vat;
                    m_command.Parameters.Add("v_vattu", NpgsqlDbType.Numeric).Value = v_vattu;
                    m_command.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(v_mmyy, ex.Message, m_computername, "v_ttrvct");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_ttrvnhom(string v_mmyy, decimal v_id, decimal v_ma, decimal v_sotien)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".v_ttrvnhom set sotien=:v_sotien where id=:v_id and ma=:v_ma";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
            m_command.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".v_ttrvnhom(id,ma,sotien) values(:v_id,:v_ma,:v_sotien)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                    m_command.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(v_mmyy, ex.Message, m_computername, "v_ttrvnhom");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_ttrvpttt(string v_mmyy, decimal v_id, string v_ngay16, decimal v_songay_tpt, decimal v_songay_spt, decimal v_mavp, decimal v_mamau, decimal v_so, decimal v_loaipt, string v_ghichu)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".v_ttrvpttt set ngay=to_date(:v_ngay,'dd/mm/yyyy hh24:mi'), songay_tpt=:v_songay_tpt,songay_spt=:v_songay_spt,mavp=:v_mavp,mamau=:v_mamau,so=:v_so, loaipt=:v_loaipt, ghichu=:v_ghichu where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 16).Value = v_ngay16;
            m_command.Parameters.Add("v_songay_tpt", NpgsqlDbType.Numeric).Value = v_songay_tpt;
            m_command.Parameters.Add("v_songay_spt", NpgsqlDbType.Numeric).Value = v_songay_spt;
            m_command.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
            m_command.Parameters.Add("v_mamau", NpgsqlDbType.Numeric).Value = v_mamau;
            m_command.Parameters.Add("v_so", NpgsqlDbType.Numeric).Value = v_so;
            m_command.Parameters.Add("v_loaipt", NpgsqlDbType.Numeric).Value = v_loaipt;
            m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text, 50).Value = v_ghichu;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".v_ttrvpttt(id,ngay,songay_tpt,songay_spt,mavp,mamau,so,loaipt,ghichu) values(:v_id,to_date(:v_ngay,'dd/mm/yyyy hh24:mi'),:v_songay_tpt,:v_songay_spt,:v_mavp,:v_mamau,:v_so,:v_loaipt,:v_ghichu)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 16).Value = v_ngay16;
                    m_command.Parameters.Add("v_songay_tpt", NpgsqlDbType.Numeric).Value = v_songay_tpt;
                    m_command.Parameters.Add("v_songay_spt", NpgsqlDbType.Numeric).Value = v_songay_spt;
                    m_command.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
                    m_command.Parameters.Add("v_mamau", NpgsqlDbType.Numeric).Value = v_mamau;
                    m_command.Parameters.Add("v_so", NpgsqlDbType.Numeric).Value = v_so;
                    m_command.Parameters.Add("v_loaipt", NpgsqlDbType.Numeric).Value = v_loaipt;
                    m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text, 50).Value = v_ghichu;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(v_mmyy, ex.Message, m_computername, "v_ttrvpttt");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public string upd_v_ttrvds(string v_mmyy, decimal v_id, string v_mabn, decimal v_mavaovien, decimal v_maql, decimal v_idkhoa, string v_giuong, string v_ngayvao, string v_ngayra, string v_chandoan, string v_maicd)
        {
            if (v_id == 0)
            {
                v_id = get_id_v_ttrvll;
            }
            if (v_mmyy == "")
            {
                v_mmyy = get_mmyy(v_ngayra);
            }
            if (v_ngayvao.Length > 10)
            {
                v_ngayvao = v_ngayvao.Substring(0, 10);
            }
            if (v_ngayra.Length > 10)
            {
                v_ngayra = v_ngayra.Substring(0, 10);
            }

            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".v_ttrvds set mabn=:v_mabn,mavaovien=:v_mavaovien,maql=:v_maql, idkhoa=:v_idkhoa, giuong=:v_giuong";
            if (v_ngayvao.Length == 10) m_sql += ",ngayvao=to_date(:v_ngayvao,'dd/mm/yyyy')";
            if (v_ngayra.Length == 10) m_sql += ",ngayra=to_date(:v_ngayra,'dd/mm/yyyy')";
            m_sql += ",chandoan=:v_chandoan, maicd=:v_maicd where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 8).Value = v_mabn;
            m_command.Parameters.Add("v_mavaovien", NpgsqlDbType.Numeric).Value = v_mavaovien;
            m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
            m_command.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
            m_command.Parameters.Add("v_giuong", NpgsqlDbType.Varchar, 10).Value = v_giuong;
            if (v_ngayvao.Length == 10) m_command.Parameters.Add("v_ngayvao", NpgsqlDbType.Varchar, 10).Value = v_ngayvao;
            if (v_ngayra.Length == 10) m_command.Parameters.Add("v_ngayra", NpgsqlDbType.Varchar, 10).Value = v_ngayra;
            m_command.Parameters.Add("v_chandoan", NpgsqlDbType.Text).Value = v_chandoan;
            m_command.Parameters.Add("v_maicd", NpgsqlDbType.Varchar, 9).Value = v_maicd;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".v_ttrvds(id,mabn,mavaovien,maql,idkhoa,giuong";
                    if (v_ngayvao.Length == 10) m_sql += ",ngayvao";
                    if (v_ngayra.Length == 10) m_sql += ",ngayra";
                    m_sql += ",chandoan,maicd)";
                    m_sql += " values (:v_id,:v_mabn,:v_mavaovien,:v_maql,:v_idkhoa,:v_giuong";
                    if (v_ngayvao.Length == 10) m_sql += ",to_date(:v_ngayvao,'dd/mm/yyyy')";
                    if (v_ngayra.Length == 10) m_sql += ",to_date(:v_ngayra,'dd/mm/yyyy')";
                    m_sql += ",:v_chandoan,:v_maicd)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 8).Value = v_mabn;
                    m_command.Parameters.Add("v_mavaovien", NpgsqlDbType.Numeric).Value = v_mavaovien;
                    m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                    m_command.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
                    m_command.Parameters.Add("v_giuong", NpgsqlDbType.Varchar, 10).Value = v_giuong;
                    if (v_ngayvao.Length == 10) m_command.Parameters.Add("v_ngayvao", NpgsqlDbType.Varchar, 10).Value = v_ngayvao;
                    if (v_ngayra.Length == 10) m_command.Parameters.Add("v_ngayra", NpgsqlDbType.Varchar, 10).Value = v_ngayra;
                    m_command.Parameters.Add("v_chandoan", NpgsqlDbType.Text).Value = v_chandoan;
                    m_command.Parameters.Add("v_maicd", NpgsqlDbType.Varchar, 9).Value = v_maicd;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(v_mmyy, ex.Message, m_computername, "v_ttrvds");
                v_id = 0;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return v_id.ToString();
        }
        public bool upd_v_ttrvds(string v_mmyy, decimal v_id, string v_chandoan, string v_maicd)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".v_ttrvds set chandoan=:v_chandoan, maicd=:v_maicd where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_chandoan", NpgsqlDbType.Text, 254).Value = v_chandoan;
            m_command.Parameters.Add("v_maicd", NpgsqlDbType.Varchar, 9).Value = v_maicd;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
            }
            catch (Exception ex)
            {
                upd_v_error(v_mmyy, ex.Message, m_computername, "v_ttrvds");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_ttrvbhyt(string v_mmyy, decimal v_id, string v_sothe, decimal v_maphu, string v_ngay10, string v_tungay10, string v_mabv, string v_noigioithieu)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".v_ttrvbhyt set sothe=:v_sothe,maphu=:v_maphu,ngay=to_date(:v_ngay,'dd/mm/yyyy'),tungay=to_date(:v_tungay,'dd/mm/yyyy'),mabv=:v_mabv,noigioithieu=:v_noigioithieu where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_sothe", NpgsqlDbType.Varchar, 16).Value = v_sothe;
            m_command.Parameters.Add("v_maphu", NpgsqlDbType.Numeric).Value = v_maphu;
            m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay10;
            m_command.Parameters.Add("v_tungay", NpgsqlDbType.Varchar, 10).Value = v_tungay10;
            m_command.Parameters.Add("v_mabv", NpgsqlDbType.Varchar, 8).Value = v_mabv;
            m_command.Parameters.Add("v_noigioithieu", NpgsqlDbType.Varchar, 8).Value = v_noigioithieu;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".v_ttrvbhyt(id,sothe,maphu,tungay,ngay,mabv,noigioithieu) values(:v_id,:v_sothe,:v_maphu,to_date(:v_tungay,'dd/mm/yyyy'),to_date(:v_ngay,'dd/mm/yyyy'),:v_mabv,:v_noigioithieu)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_sothe", NpgsqlDbType.Varchar, 16).Value = v_sothe;
                    m_command.Parameters.Add("v_maphu", NpgsqlDbType.Numeric).Value = v_maphu;
                    m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay10;
                    m_command.Parameters.Add("v_tungay", NpgsqlDbType.Varchar, 10).Value = v_tungay10;
                    m_command.Parameters.Add("v_mabv", NpgsqlDbType.Varchar, 8).Value = v_mabv;
                    m_command.Parameters.Add("v_noigioithieu", NpgsqlDbType.Varchar, 8).Value = v_noigioithieu;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(v_mmyy, ex.Message, m_computername, "v_ttrvbhyt");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public string upd_v_vienphill(string v_mmyy, decimal v_id, decimal v_quyenso, decimal v_sobienlai, string v_ngay10, string v_mabn, decimal v_mavaovien, decimal v_maql, decimal v_idkhoa, string v_makp, string v_hoten, string v_namsinh, string v_diachi, decimal v_loai, decimal v_loaibn, decimal v_userid)
        {
            if (v_id == 0)
            {
                v_id = get_id_v_vienphill;
            }
            if (v_mmyy == "")
            {
                v_mmyy = get_mmyy(v_ngay10);
            }
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".v_vienphill set quyenso=:v_quyenso,sobienlai=:v_sobienlai,ngay=to_date(:v_ngay,'dd/mm/yyyy'),mabn=:v_mabn,mavaovien=:v_mavaovien,maql=:v_maql, idkhoa=:v_idkhoa,makp=:v_makp,hoten=:v_hoten,namsinh=:v_namsinh,diachi=:v_diachi,loai=:v_loai,loaibn=:v_loaibn,userid=:v_userid where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_quyenso", NpgsqlDbType.Numeric).Value = v_quyenso;
            m_command.Parameters.Add("v_sobienlai", NpgsqlDbType.Numeric).Value = v_sobienlai;
            m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay10;
            m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 8).Value = v_mabn;
            m_command.Parameters.Add("v_mavaovien", NpgsqlDbType.Numeric).Value = v_mavaovien;
            m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
            m_command.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
            m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 3).Value = v_makp;
            m_command.Parameters.Add("v_hoten", NpgsqlDbType.Text).Value = v_hoten;
            m_command.Parameters.Add("v_namsinh", NpgsqlDbType.Varchar, 4).Value = v_namsinh;
            m_command.Parameters.Add("v_diachi", NpgsqlDbType.Text).Value = v_diachi;
            m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
            m_command.Parameters.Add("v_loaibn", NpgsqlDbType.Numeric).Value = v_loaibn;
            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".v_vienphill(id,quyenso,sobienlai,ngay,mabn,mavaovien,maql,idkhoa,makp,hoten,namsinh,diachi,loai,loaibn,userid) values(:v_id,:v_quyenso,:v_sobienlai,to_date(:v_ngay,'dd/mm/yyyy'),:v_mabn,:v_mavaovien,:v_maql,:v_idkhoa,:v_makp,:v_hoten,:v_namsinh,:v_diachi,:v_loai,:v_loaibn,:v_userid)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_quyenso", NpgsqlDbType.Numeric).Value = v_quyenso;
                    m_command.Parameters.Add("v_sobienlai", NpgsqlDbType.Numeric).Value = v_sobienlai;
                    m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay10;
                    m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 8).Value = v_mabn;
                    m_command.Parameters.Add("v_mavaovien", NpgsqlDbType.Numeric).Value = v_mavaovien;
                    m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                    m_command.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
                    m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 3).Value = v_makp;
                    m_command.Parameters.Add("v_hoten", NpgsqlDbType.Text).Value = v_hoten;
                    m_command.Parameters.Add("v_namsinh", NpgsqlDbType.Varchar, 4).Value = v_namsinh;
                    m_command.Parameters.Add("v_diachi", NpgsqlDbType.Text).Value = v_diachi;
                    m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                    m_command.Parameters.Add("v_loaibn", NpgsqlDbType.Numeric).Value = v_loaibn;
                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(v_mmyy, ex.Message, m_computername, "v_vienphill");
                return "0";
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return v_id.ToString();
        }
        public bool upd_v_vienphict(string v_mmyy, decimal v_id, decimal v_stt, decimal v_madoituong, string v_makp, decimal v_mavp, decimal v_soluong, decimal v_dongia, decimal v_mien, decimal v_thieu, decimal v_vattu, string v_mabs)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".v_vienphict set madoituong=:v_madoituong,makp=:v_makp,mavp=:v_mavp,soluong=:v_soluong, dongia=:v_dongia,mien=:v_mien,thieu=:v_thieu, vattu=:v_vattu, mabs=:v_mabs where id=:v_id and stt=:v_stt";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
            m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 3).Value = v_makp;
            m_command.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
            m_command.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
            m_command.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;
            m_command.Parameters.Add("v_mien", NpgsqlDbType.Numeric).Value = v_mien;
            m_command.Parameters.Add("v_thieu", NpgsqlDbType.Numeric).Value = v_thieu;
            m_command.Parameters.Add("v_vattu", NpgsqlDbType.Numeric).Value = v_vattu;
            m_command.Parameters.Add("v_mabs", NpgsqlDbType.Varchar, 4).Value = v_mabs;
            m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 3).Value = v_makp;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".v_vienphict(id,stt,madoituong,makp,mavp,soluong,dongia,mien,thieu,vattu,mabs) values(:v_id,:v_stt,:v_madoituong,:v_makp,:v_mavp,:v_soluong,:v_dongia,:v_mien,:v_thieu,:v_vattu,:v_mabs)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
                    m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 3).Value = v_makp;
                    m_command.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
                    m_command.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
                    m_command.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;
                    m_command.Parameters.Add("v_mien", NpgsqlDbType.Numeric).Value = v_mien;
                    m_command.Parameters.Add("v_thieu", NpgsqlDbType.Numeric).Value = v_thieu;
                    m_command.Parameters.Add("v_vattu", NpgsqlDbType.Numeric).Value = v_vattu;
                    m_command.Parameters.Add("v_mabs", NpgsqlDbType.Varchar, 4).Value = v_mabs;
                    m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 3).Value = v_makp;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(v_mmyy, ex.Message, m_computername, "v_vienphict??");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public string upd_v_trongoi(string v_mmyy, decimal v_id, decimal v_sotien, decimal v_tamung, decimal v_hoantra, decimal v_pm, decimal v_yc, string v_ghichu)
        {
            if (v_id == 0)
            {
                return "0";
            }
            if (v_mmyy == "")
            {
                v_mmyy = s_curmmyy;
            }
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".v_trongoi set sotien=:v_sotien,tamung=:v_tamung,hoantra=:v_hoantra,pm=:v_pm,yc=:v_yc, ghichu=:v_ghichu where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
            m_command.Parameters.Add("v_tamung", NpgsqlDbType.Numeric).Value = v_tamung;
            m_command.Parameters.Add("v_hoantra", NpgsqlDbType.Numeric).Value = v_hoantra;
            m_command.Parameters.Add("v_pm", NpgsqlDbType.Numeric).Value = v_pm;
            m_command.Parameters.Add("v_yc", NpgsqlDbType.Numeric).Value = v_yc;
            m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".v_trongoi(id,sotien,tamung,hoantra,pm,yc,ghichu) values(:v_id,:v_sotien,:v_tamung,:v_hoantra,:v_pm,:v_yc,:v_ghichu)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                    m_command.Parameters.Add("v_tamung", NpgsqlDbType.Numeric).Value = v_tamung;
                    m_command.Parameters.Add("v_hoantra", NpgsqlDbType.Numeric).Value = v_hoantra;
                    m_command.Parameters.Add("v_pm", NpgsqlDbType.Numeric).Value = v_pm;
                    m_command.Parameters.Add("v_yc", NpgsqlDbType.Numeric).Value = v_yc;
                    m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(v_mmyy, ex.Message, m_computername, "v_trongoi");
                return "0";
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return v_id.ToString();
        }
        public string upd_v_nhom(string v_mmyy, decimal v_id, decimal v_id_loaivp, decimal v_sotien)
        {
            if (v_id == 0)
            {
                return "0";
            }
            if (v_mmyy == "")
            {
                v_mmyy = s_curmmyy;
            }
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".v_nhom set sotien=:v_sotien where id=:v_id and  ma=:v_ma";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_id_loaivp;
            m_command.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".v_nhom(id,ma,sotien) values(:v_id,:v_ma,:v_sotien)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_id_loaivp;
                    m_command.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(v_mmyy, ex.Message, m_computername, "v_nhom");
                return "0";
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return v_id.ToString();
        }
        public bool upd_v_giuong(string v_mmyy, decimal v_id, decimal v_mavp, string v_ngay10, decimal v_dongia)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".v_giuong set dongia=:v_dongia where id=:v_id and mavp=:v_mavp and to_char(ngay,'dd/mm/yyyy')=:v_ngay";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
            m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay10;
            m_command.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".v_giuong(id,mavp,ngay,dongia) values(:v_id,:v_mavp,to_date(:v_ngay,'dd/mm/yyyy'),:v_dongia)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
                    m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay10;
                    m_command.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(v_mmyy, ex.Message, m_computername, "v_giuong");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_suatan(string v_mmyy, decimal v_id, decimal v_mavp, string v_ngay16, decimal v_dongia)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".v_suatan set dongia=:v_dongia where id=:v_id and mavp=:v_mavp and to_char(ngay,'dd/mm/yyyy hh24:mi')=:v_ngay";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
            m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 16).Value = v_ngay16;
            m_command.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".v_suatan(id,mavp,ngay,dongia) values(:v_id,:v_mavp,to_date(:v_ngay,'dd/mm/yyyy hh24:mi'),:v_dongia)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
                    m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 16).Value = v_ngay16;
                    m_command.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(v_mmyy, ex.Message, m_computername, "v_suatan");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_vpkhoa(string v_mmyy, decimal v_id, string v_mabn, decimal v_maql, decimal v_idkhoa, string v_ngay16, string v_makp, decimal v_madoituong, decimal v_mavp, decimal v_soluong, decimal v_dongia, decimal v_vattu, decimal v_userid)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".v_vpkhoa set mabn=:v_mabn,maql=:v_maql,idkhoa=:v_idkhoa,ngay=to_date(:v_ngay,'dd/mm/yyyy hh24:mi'), makp=:v_makp, madoituong=:v_madoituong,mavp=:v_mavp,soluong=:v_soluong,dongia=:v_dongia,vattu=:v_vattu,userid=:v_userid where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 8).Value = v_mabn;
            m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
            m_command.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
            m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 16).Value = v_ngay16;
            m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 3).Value = v_makp;
            m_command.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
            m_command.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
            m_command.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
            m_command.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;
            m_command.Parameters.Add("v_vattu", NpgsqlDbType.Numeric).Value = v_vattu;
            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".v_vpkhoa(id,mabn, maql, idkhoa,ngay,makp,madoituong,mavp,soluong,dongia,vattu,userid,done) values(:v_id,:v_mabn,:v_maql,:v_idkhoa, to_date(:v_ngay,'dd/mm/yyyy hh24:mi'),:v_makp,:v_madoituong,:v_mavp,:v_soluong,:v_dongia,:v_vattu,:v_userid,0)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 8).Value = v_mabn;
                    m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                    m_command.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
                    m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 16).Value = v_ngay16;
                    m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 3).Value = v_makp;
                    m_command.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
                    m_command.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
                    m_command.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
                    m_command.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;
                    m_command.Parameters.Add("v_vattu", NpgsqlDbType.Numeric).Value = v_vattu;
                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(v_mmyy, ex.Message, m_computername, "v_vpkhoa");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public string upd_bhytkb(string v_mmyy, decimal v_id, decimal v_nhom, decimal v_quyenso, decimal v_sobienlai, string v_ngay10, string v_mabn, decimal v_mavaovien, decimal v_maql, string v_makp, string v_chandoan, string v_maicd, string v_mabs, string v_sothe, decimal v_maphu, string v_mabv, decimal v_congkham, decimal v_thuoc, decimal v_cls, decimal v_bntra, decimal v_bhyttra, decimal v_loaiba, decimal v_userid, decimal v_done)
        {
            if (v_id == 0)
            {
                v_id = get_id_bhytkb;
            }
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".bhytkb set quyenso=:v_quyenso,sobienlai=:v_sobienlai,bntra=:v_bntra,bhyttra=:v_bhyttra,done=:v_done where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_quyenso", NpgsqlDbType.Numeric).Value = v_quyenso;
            m_command.Parameters.Add("v_sobienlai", NpgsqlDbType.Numeric).Value = v_sobienlai;
            m_command.Parameters.Add("v_bntra", NpgsqlDbType.Numeric).Value = v_bntra;
            m_command.Parameters.Add("v_bhyttra", NpgsqlDbType.Numeric).Value = v_bhyttra;
            m_command.Parameters.Add("v_done", NpgsqlDbType.Numeric).Value = v_done;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".bhytkb(id,nhom,quyenso,sobienlai,ngay,mabn,mavaovien,maql,makp,chandoan,maicd,mabs,sothe,maphu,mabv,congkham,thuoc,cls,bntra,bhyttra,loaiba,userid,done) values(:v_id,:v_nhom,:v_quyenso,:v_sobienlai,to_date(:v_ngay,'dd/mm/yyyy'),:v_mabn,:v_mavaovien,:v_maql,:v_makp,:v_chandoan,:v_maicd,:v_mabs,:v_sothe,:v_maphu,:v_mabv,:v_congkham,:v_thuoc,:v_cls,:v_bntra,:v_bhyttra,:v_loaiba,:v_userid,:v_done)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_nhom", NpgsqlDbType.Numeric).Value = v_nhom;
                    m_command.Parameters.Add("v_quyenso", NpgsqlDbType.Numeric).Value = v_quyenso;
                    m_command.Parameters.Add("v_sobienlai", NpgsqlDbType.Numeric).Value = v_sobienlai;
                    m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay10;
                    m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 8).Value = v_mabn;
                    m_command.Parameters.Add("v_mavaovien", NpgsqlDbType.Numeric).Value = v_mavaovien;
                    m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                    m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 3).Value = v_makp;
                    m_command.Parameters.Add("v_chandoan", NpgsqlDbType.Text).Value = v_chandoan;
                    m_command.Parameters.Add("v_maicd", NpgsqlDbType.Varchar, 9).Value = v_maicd;
                    m_command.Parameters.Add("v_mabs", NpgsqlDbType.Varchar, 4).Value = v_mabs;
                    m_command.Parameters.Add("v_sothe", NpgsqlDbType.Varchar, 20).Value = v_sothe;
                    m_command.Parameters.Add("v_maphu", NpgsqlDbType.Numeric).Value = v_maphu;
                    m_command.Parameters.Add("v_mabv", NpgsqlDbType.Varchar, 8).Value = v_mabv;
                    m_command.Parameters.Add("v_congkham", NpgsqlDbType.Numeric).Value = v_congkham;
                    m_command.Parameters.Add("v_thuoc", NpgsqlDbType.Numeric).Value = v_thuoc;
                    m_command.Parameters.Add("v_cls", NpgsqlDbType.Numeric).Value = v_cls;
                    m_command.Parameters.Add("v_bntra", NpgsqlDbType.Numeric).Value = v_bntra;
                    m_command.Parameters.Add("v_bhyttra", NpgsqlDbType.Numeric).Value = v_bhyttra;
                    m_command.Parameters.Add("v_loaiba", NpgsqlDbType.Numeric).Value = v_loaiba;
                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                    m_command.Parameters.Add("v_done", NpgsqlDbType.Numeric).Value = v_done;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(v_mmyy, ex.Message, m_computername, "mmyy.bhytkb");
                v_id = 0;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return v_id.ToString();
        }
        public bool upd_bhytcls(string v_mmyy, decimal v_id, decimal v_stt, decimal v_mavp, decimal v_soluong, decimal v_dongia, decimal v_idchidinh)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".bhytcls set mavp=:v_mavp,soluong=:v_soluong,dongia=:v_dongia,idchidinh=:v_idchidinh where id=:v_id and stt=:v_stt";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
            m_command.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
            m_command.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;
            m_command.Parameters.Add("v_idchidinh", NpgsqlDbType.Numeric).Value = v_idchidinh;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".bhytcls(id,stt,mavp,soluong,dongia,idchidinh) values(:v_id,:v_stt,:v_mavp,:v_soluong,:v_dongia,:v_idchidinh)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
                    m_command.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
                    m_command.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;
                    m_command.Parameters.Add("v_idchidinh", NpgsqlDbType.Numeric).Value = v_idchidinh;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(v_mmyy, ex.Message, m_computername, "bhytcls");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_bhytds(string v_mmyy, string v_mabn, string v_hoten, string v_namsinh, string v_diachi)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".bhytds set hoten=:v_hoten,namsinh=:v_namsinh,diachi=:v_diachi where mabn=:v_mabn";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 8).Value = v_mabn;
            m_command.Parameters.Add("v_hoten", NpgsqlDbType.Text).Value = v_hoten;
            m_command.Parameters.Add("v_namsinh", NpgsqlDbType.Varchar, 4).Value = v_namsinh;
            m_command.Parameters.Add("v_diachi", NpgsqlDbType.Text).Value = v_diachi;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".bhytds(mabn,hoten,namsinh,diachi) values(:v_mabn,:v_hoten,:v_namsinh,:v_diachi)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 8).Value = v_mabn;
                    m_command.Parameters.Add("v_hoten", NpgsqlDbType.Text).Value = v_hoten;
                    m_command.Parameters.Add("v_namsinh", NpgsqlDbType.Varchar, 4).Value = v_namsinh;
                    m_command.Parameters.Add("v_diachi", NpgsqlDbType.Text).Value = v_diachi;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(v_mmyy, ex.Message, m_computername, "bhytds");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public void upd_done_d_tienthuoc(string v_mabn, string v_maql, string v_mabd, string v_denngay)
        {
            try
            {
                string asql = "";
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    asql = "update " + r["schemaname"].ToString() + ".d_tienthuoc set done=1 where mabn='" + v_mabn + "' and maql=" + v_maql + " and mabd in(" + v_mabd.Trim(',') + ")";
                    if (v_denngay.Trim().Length == 10)
                    {
                        asql += " and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + v_denngay + "','dd/mm/yyyy')";
                    }
                    execute_data(asql);
                }
            }
            catch
            {
            }
        }
        public void upd_done_d_tienthuoc(string v_mabn, string v_maql, string v_mabd, string v_denngay, DateTime v_tn, DateTime v_dn)
        {
            try
            {
                string asql = "";
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    v_tn = v_tn.AddMonths(-1);
                    v_dn = v_dn.AddMonths(1);
                    while (v_tn <= v_dn)
                    {
                        if (s_schema_mmyy(v_tn.Month.ToString().PadLeft(2, '0') + v_tn.Year.ToString().PadLeft(4, '0').Substring(2)).ToLower().Trim() == r["schemaname"].ToString().ToLower().Trim())
                        {
                            asql = "update " + r["schemaname"].ToString() + ".d_tienthuoc set done=1 where mabn='" + v_mabn + "' and maql=" + v_maql + " and mabd in(" + v_mabd.Trim(',') + ")";
                            if (v_denngay.Trim().Length == 10)
                            {
                                asql += " and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + v_denngay + "','dd/mm/yyyy')";
                            }
                            execute_data(asql);
                        }
                        v_tn = v_tn.AddMonths(1);
                    }
                }
            }
            catch
            {
            }
        }
        public void upd_done_d_tienthuoc_maql(string v_mabn, string v_maql, string v_denngay)
        {
            try
            {
                string asql = "";
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    try
                    {
                        asql = "update " + r["schemaname"].ToString() + ".d_tienthuoc set done=1 where mabn='" + v_mabn + "' and maql=" + v_maql;
                        if (v_denngay.Trim().Length == 10)
                        {
                            asql += " and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + v_denngay + "','dd/mm/yyyy')";
                        }
                        execute_data(asql);
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }
        public void upd_done_d_tienthuoc_maql(string v_mabn, string v_maql, string v_denngay, DateTime v_tn, DateTime v_dn)
        {
            try
            {
                string asql = "update d_tienthuoc set done=1 where mabn='" + v_mabn + "' and maql=" + v_maql;
                if (v_denngay.Trim().Length == 10)
                {
                    asql += " and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + v_denngay + "','dd/mm/yyyy')";
                }
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    v_tn = v_tn.AddMonths(-1);
                    v_dn = v_dn.AddMonths(1);
                    while (v_tn <= v_dn)
                    {
                        if (s_schema_mmyy(v_tn.Month.ToString().PadLeft(2, '0') + v_tn.Year.ToString().PadLeft(4, '0').Substring(2)).ToLower().Trim() == r["schemaname"].ToString().ToLower().Trim())
                        {
                            asql = "update " + r["schemaname"].ToString() + ".d_tienthuoc set done=1 where mabn='" + v_mabn + "' and maql=" + v_maql;
                            if (v_denngay.Trim().Length == 10)
                            {
                                asql += " and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + v_denngay + "','dd/mm/yyyy')";
                            }
                            execute_data(asql);
                        }
                        v_tn = v_tn.AddMonths(1);
                    }
                }
            }
            catch
            {
            }
        }
        public void upd_done_d_tienthuoc_in(string v_mabn, string v_maql, string v_mabd, string v_rowid, string v_mmyy, DateTime v_tn, DateTime v_dn)
        {
            try
            {
                string asql = "";
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    while (v_tn <= v_dn)
                    {
                        if (s_schema_mmyy(v_tn.Month.ToString().PadLeft(2, '0') + v_tn.Year.ToString().PadLeft(4, '0').Substring(2)).ToLower().Trim() == r["schemaname"].ToString().ToLower().Trim())
                        {
                            asql = "update " + r["schemaname"].ToString() + ".d_tienthuoc set done=1 where mabn='" + v_mabn + "' and maql=" + v_maql + " and mabd in(" + v_mabd.Trim(',') + ")";
                            if (v_rowid != "")
                            {
                                asql += " and rowid in (" + v_rowid + ")";
                            }
                            if (v_mmyy != "")
                            {
                                asql += " and to_char(ngay,'mmyy') in (" + v_mmyy + ")";
                            }
                            execute_data(asql);
                        }
                        v_tn = v_tn.AddMonths(1);
                    }
                }
            }
            catch
            {
            }
        }
        public void upd_done_v_vpkhoa(string v_mabn, string v_maql, string v_mavp, string v_denngay)
        {
            try
            {
                string asql = "";
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    try
                    {
                        asql = "update v_vpkhoa set done=1 where mabn='" + v_mabn + "' and maql=" + v_maql + " and mavp in(" + v_mavp.Trim(',') + ")";
                        if (v_denngay.Length == 10)
                        {
                            asql += " and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + v_denngay + "','dd/mm/yyyy')";
                        }
                        execute_data(asql);
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }
        public void upd_done_v_vpkhoa_maql(string v_mabn, string v_maql, string v_denngay)
        {
            try
            {
                string asql = "";
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    try
                    {
                        asql = "update " + r["schemaname"].ToString() + ".v_vpkhoa set done=1 where mabn='" + v_mabn + "' and maql=" + v_maql;
                        if (v_denngay.Length == 10)
                        {
                            asql += " and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + v_denngay + "','dd/mm/yyyy')";
                        }
                        execute_data(asql);
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }
        public void upd_done_v_vpkhoa_in(string v_mabn, string v_maql, string v_mavp, string v_rowid, string v_mmyy)
        {
            try
            {
                string asql = "";
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    try
                    {
                        asql = "update " + r["schemaname"].ToString() + ".v_vpkhoa set done=1 where mabn='" + v_mabn + "' and maql=" + v_maql + " and mavp in(" + v_mavp.Trim(',') + ")";
                        if (v_rowid != "")
                        {
                            asql += " and rowid in (" + v_rowid + ")";
                        }
                        if (v_mmyy != "")
                        {
                            asql += " and to_char(ngay,'mmyy') in (" + v_mmyy + ")";
                        }
                        execute_data(asql);
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }
        public void upd_paid_v_chidinh(string v_mabn, string v_maql, string v_mavp, string v_denngay)
        {
            try
            {
                string asql = "";
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    try
                    {
                        asql = "update " + r["schemaname"].ToString() + ".v_chidinh set paid=1 where mabn='" + v_mabn + "' and maql=" + v_maql + " and mavp in(" + v_mavp.Trim(',') + ")";
                        if (v_denngay.Length == 10)
                        {
                            asql += " and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + v_denngay + "','dd/mm/yyyy')";
                        }
                        execute_data(asql);
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }
        public void upd_tamung_v_ttrvll(string v_id_tamung, string v_id_ttrv_delimiter)
        {
            try
            {
                if (v_id_tamung.Trim() == "" || v_id_ttrv_delimiter.Trim() == "") return;
                string asql = "";
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    asql = "update " + r["schemaname"].ToString() + ".v_tamung set done=1, idttrv=" + v_id_ttrv_delimiter + " where id in(" + v_id_tamung.Trim(',') + ")";
                    execute_data(asql);
                }
            }
            catch
            {
            }
        }
        public bool upd_v_thongso(decimal v_id, string v_loai, string v_ten)
        {
            m_sql = "update " + s_schemaroot + ".v_thongso set loai=:v_loai, ten=:v_ten where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_loai", NpgsqlDbType.Text, 50).Value = v_loai;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 100).Value = v_ten;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".v_thongso(id,loai,ten) values(:v_id,:v_loai,:v_ten)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_loai", NpgsqlDbType.Text, 50).Value = v_loai;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 100).Value = v_ten;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_thongso");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_quyenso(decimal v_id, string v_sohieubl, string v_sohieu, decimal v_tu, decimal v_den, decimal v_soghi, string v_loai, decimal v_khambenh, decimal v_dangsd, decimal v_userid, string v_ngaylinh10)
        {
            m_sql = "update " + m_db_schemaroot + ".v_quyenso set sohieubl=:v_sohieubl, sohieu=:v_sohieu, tu=:v_tu, den=:v_den, soghi=:v_soghi,loai=:v_loai,khambenh=:v_khambenh,dangsd=:v_dangsd, ngaylinh=to_date(:v_ngaylinh,'dd/mm/yyyy'),userid=:v_userid, ngayud=now() where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_sohieubl", NpgsqlDbType.Varchar, 20).Value = v_sohieubl;
            m_command.Parameters.Add("v_sohieu", NpgsqlDbType.Varchar, 20).Value = v_sohieu;
            m_command.Parameters.Add("v_tu", NpgsqlDbType.Numeric).Value = v_tu;
            m_command.Parameters.Add("v_den", NpgsqlDbType.Numeric).Value = v_den;
            m_command.Parameters.Add("v_soghi", NpgsqlDbType.Numeric).Value = v_soghi;
            m_command.Parameters.Add("v_dangsd", NpgsqlDbType.Numeric).Value = v_dangsd;
            m_command.Parameters.Add("v_loai", NpgsqlDbType.Varchar).Value = v_loai;
            m_command.Parameters.Add("v_khambenh", NpgsqlDbType.Numeric).Value = v_khambenh;
            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
            m_command.Parameters.Add("v_ngaylinh", NpgsqlDbType.Varchar, 10).Value = v_ngaylinh10;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".v_quyenso(id,sohieu,sohieubl,tu,den,soghi,dangsd,loai,khambenh,ngaylinh,userid,ngayud) values(:v_id,:v_sohieu,:v_sohieubl,:v_tu,:v_den,:v_soghi,:v_dangsd,:v_loai,:v_khambenh,to_date(:v_ngaylinh,'dd/mm/yyyy'),:v_userid,now())";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_sohieubl", NpgsqlDbType.Varchar, 20).Value = v_sohieubl;
                    m_command.Parameters.Add("v_sohieu", NpgsqlDbType.Varchar, 20).Value = v_sohieu;
                    m_command.Parameters.Add("v_tu", NpgsqlDbType.Numeric).Value = v_tu;
                    m_command.Parameters.Add("v_den", NpgsqlDbType.Numeric).Value = v_den;
                    m_command.Parameters.Add("v_soghi", NpgsqlDbType.Numeric).Value = v_soghi;
                    m_command.Parameters.Add("v_dangsd", NpgsqlDbType.Numeric).Value = v_dangsd;
                    m_command.Parameters.Add("v_loai", NpgsqlDbType.Varchar).Value = v_loai;
                    m_command.Parameters.Add("v_khambenh", NpgsqlDbType.Numeric).Value = v_khambenh;
                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                    m_command.Parameters.Add("v_ngaylinh", NpgsqlDbType.Varchar, 10).Value = v_ngaylinh10;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_quyenso");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public void upd_v_quyenso(decimal v_id, decimal v_soghi, bool v_valid)
        {
            try
            {
                string asql = "update medibv.v_quyenso set soghi = " + v_soghi + " where id = " + v_id.ToString();
                if (v_valid)
                {
                    asql += " and soghi <" + v_soghi.ToString();
                }
                execute_data(asql);
            }
            catch
            {
            }
        }
        public bool upd_v_loaivp(decimal v_id, decimal v_id_nhom, decimal v_stt, string v_ma, string v_ten, string v_viettat, decimal v_userid, string v_computer, decimal v_readonly)
        {
            m_sql = "update " + m_db_schemaroot + ".v_loaivp set id_nhom=:v_id_nhom, stt=:v_stt, ma=:v_ma,ten=:v_ten,viettat=:v_viettat,userid=:v_userid, computer=:v_computer, readonly=:v_readonly,ngayud=now() where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_id_nhom", NpgsqlDbType.Numeric).Value = v_id_nhom;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_ma", NpgsqlDbType.Text).Value = v_ma;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
            m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_viettat;
            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
            m_command.Parameters.Add("v_computer", NpgsqlDbType.Varchar, 20).Value = v_computer;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".v_loaivp(id,id_nhom,stt,ma,ten,viettat,userid,computer,readonly,ngayud) values(:v_id,:v_id_nhom,:v_stt,:v_ma,:v_ten,:v_viettat,:v_userid,:v_computer,:v_readonly,now())";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_id_nhom", NpgsqlDbType.Numeric).Value = v_id_nhom;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Text).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_viettat;
                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                    m_command.Parameters.Add("v_computer", NpgsqlDbType.Varchar, 20).Value = v_computer;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_loaivp");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_loaivp(decimal v_id, string v_computer)
        {
            m_sql = "update " + m_db_schemaroot + ".v_loaivp set computer=:v_computer where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_computer", NpgsqlDbType.Varchar, 20).Value = v_computer;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_loaivp");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_giavp(decimal v_id, decimal v_id_loai, decimal v_stt, string v_ma, string v_ten, string v_dvt, decimal v_gia_th, decimal v_gia_bh, decimal v_gia_dv, decimal v_gia_nn, decimal v_gia_cs, decimal v_vattu_th, decimal v_vattu_bh, decimal v_vattu_dv, decimal v_vattu_nn, decimal v_vattu_cs, decimal v_bhyt, decimal v_loaibn, decimal v_theobs, decimal v_thuong, decimal v_trongoi, decimal v_loaitrongoi, decimal v_chenhlech, decimal v_ndm, string v_locthe, decimal v_readonly, decimal v_userid)
        {
            m_sql = "update " + m_db_schemaroot + ".v_giavp set id_loai=:v_id_loai, stt=:v_stt, ma=:v_ma,ten=:v_ten,dvt=:v_dvt,gia_th=:v_gia_th,gia_bh=:v_gia_bh,gia_dv=:v_gia_dv, gia_nn=:v_gia_nn, gia_cs=:v_gia_cs, vattu_th=:v_vattu_th,vattu_bh=:v_vattu_bh,vattu_dv=:v_vattu_dv,vattu_nn=:v_vattu_nn,vattu_cs=:v_vattu_cs,bhyt=:v_bhyt,loaibn=:v_loaibn,theobs=:v_theobs,thuong=:v_thuong,trongoi=:v_trongoi,chenhlech=:v_chenhlech,ndm=:v_ndm, locthe=:v_locthe,readonly=:v_readonly, userid=:v_userid where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_id_loai", NpgsqlDbType.Numeric).Value = v_id_loai;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_ma", NpgsqlDbType.Text, 50).Value = v_ma;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 100).Value = v_ten;
            m_command.Parameters.Add("v_dvt", NpgsqlDbType.Text, 20).Value = v_dvt;
            m_command.Parameters.Add("v_gia_th", NpgsqlDbType.Numeric).Value = v_gia_th;
            m_command.Parameters.Add("v_gia_bh", NpgsqlDbType.Numeric).Value = v_gia_bh;
            m_command.Parameters.Add("v_gia_dv", NpgsqlDbType.Numeric).Value = v_gia_dv;
            m_command.Parameters.Add("v_gia_nn", NpgsqlDbType.Numeric).Value = v_gia_nn;
            m_command.Parameters.Add("v_gia_cs", NpgsqlDbType.Numeric).Value = v_gia_cs;
            m_command.Parameters.Add("v_vattu_th", NpgsqlDbType.Numeric).Value = v_vattu_th;
            m_command.Parameters.Add("v_vattu_bh", NpgsqlDbType.Numeric).Value = v_vattu_bh;
            m_command.Parameters.Add("v_vattu_dv", NpgsqlDbType.Numeric).Value = v_vattu_dv;
            m_command.Parameters.Add("v_vattu_nn", NpgsqlDbType.Numeric).Value = v_vattu_nn;
            m_command.Parameters.Add("v_vattu_cs", NpgsqlDbType.Numeric).Value = v_vattu_cs;
            m_command.Parameters.Add("v_bhyt", NpgsqlDbType.Numeric).Value = v_bhyt;
            m_command.Parameters.Add("v_loaibn", NpgsqlDbType.Numeric).Value = v_loaibn;
            m_command.Parameters.Add("v_theobs", NpgsqlDbType.Numeric).Value = v_theobs;
            m_command.Parameters.Add("v_thuong", NpgsqlDbType.Numeric).Value = v_thuong;
            m_command.Parameters.Add("v_trongoi", NpgsqlDbType.Numeric).Value = v_trongoi;
            m_command.Parameters.Add("v_loaitrongoi", NpgsqlDbType.Numeric).Value = v_loaitrongoi;
            m_command.Parameters.Add("v_chenhlech", NpgsqlDbType.Numeric).Value = v_chenhlech;
            m_command.Parameters.Add("v_locthe", NpgsqlDbType.Text).Value = v_locthe;
            m_command.Parameters.Add("v_ndm", NpgsqlDbType.Numeric).Value = v_ndm;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;
            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".v_giavp(id,id_loai,stt,ma,ten,dvt,gia_th,gia_bh,gia_dv,gia_nn,gia_cs,vattu_th,vattu_bh,vattu_dv,vattu_nn,vattu_cs,bhyt,loaibn,theobs,thuong,trongoi,loaitrongoi,locthe,chenhlech,ndm,readonly,userid) values(:v_id,:v_id_loai,:v_stt,:v_ma,:v_ten,:v_dvt,:v_gia_th,:v_gia_bh,:v_gia_dv,:v_gia_nn,:v_gia_cs,:v_vattu_th,:v_vattu_bh,:v_vattu_dv,:v_vattu_nn,:v_vattu_cs,:v_bhyt,:v_loaibn,:v_theobs,:v_thuong,:v_trongoi,:v_loaitrongoi,:v_locthe,:v_chenhlech,:v_ndm,:v_readonly,:v_userid)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_id_loai", NpgsqlDbType.Numeric).Value = v_id_loai;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Text, 50).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 100).Value = v_ten;
                    m_command.Parameters.Add("v_dvt", NpgsqlDbType.Text, 20).Value = v_dvt;
                    m_command.Parameters.Add("v_gia_th", NpgsqlDbType.Numeric).Value = v_gia_th;
                    m_command.Parameters.Add("v_gia_bh", NpgsqlDbType.Numeric).Value = v_gia_bh;
                    m_command.Parameters.Add("v_gia_dv", NpgsqlDbType.Numeric).Value = v_gia_dv;
                    m_command.Parameters.Add("v_gia_nn", NpgsqlDbType.Numeric).Value = v_gia_nn;
                    m_command.Parameters.Add("v_gia_cs", NpgsqlDbType.Numeric).Value = v_gia_cs;
                    m_command.Parameters.Add("v_vattu_th", NpgsqlDbType.Numeric).Value = v_vattu_th;
                    m_command.Parameters.Add("v_vattu_bh", NpgsqlDbType.Numeric).Value = v_vattu_bh;
                    m_command.Parameters.Add("v_vattu_dv", NpgsqlDbType.Numeric).Value = v_vattu_dv;
                    m_command.Parameters.Add("v_vattu_nn", NpgsqlDbType.Numeric).Value = v_vattu_nn;
                    m_command.Parameters.Add("v_vattu_cs", NpgsqlDbType.Numeric).Value = v_vattu_cs;
                    m_command.Parameters.Add("v_bhyt", NpgsqlDbType.Numeric).Value = v_bhyt;
                    m_command.Parameters.Add("v_loaibn", NpgsqlDbType.Numeric).Value = v_loaibn;
                    m_command.Parameters.Add("v_theobs", NpgsqlDbType.Numeric).Value = v_theobs;
                    m_command.Parameters.Add("v_thuong", NpgsqlDbType.Numeric).Value = v_thuong;
                    m_command.Parameters.Add("v_trongoi", NpgsqlDbType.Numeric).Value = v_trongoi;
                    m_command.Parameters.Add("v_loaitrongoi", NpgsqlDbType.Numeric).Value = v_loaitrongoi;
                    m_command.Parameters.Add("v_chenhlech", NpgsqlDbType.Numeric).Value = v_chenhlech;
                    m_command.Parameters.Add("v_locthe", NpgsqlDbType.Text).Value = v_locthe;
                    m_command.Parameters.Add("v_ndm", NpgsqlDbType.Numeric).Value = v_ndm;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;
                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_giavp");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            execute_data("update medibv.v_giavp set locthe=null where locthe=''");
            return true;
        }
        public bool upd_dasuamadt(string v_mmyy, decimal v_maql, decimal v_idkhoa)
        {
            m_sql = "update " + m_db_schemaroot + v_mmyy + ".dasuamadt set maql=:v_maql,idkhoa=:v_idkhoa where maql=:v_maql and idkhoa=:v_idkhoa";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
            m_command.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + v_mmyy + ".dasuamadt (maql,idkhoa) values (:v_maql,:v_idkhoa)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                    m_command.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_v_error(ex.Message, m_computername, "v_dasuamadt");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_hoten_hotenkdau(bool v_all)
        {
            string v_mabn = "", v_hoten = "", v_hotenkdau = "", aexp = "";
            if (!v_all) aexp = " where hotenkdau is null";
            foreach (DataRow r in get_data("select mabn,hoten from " + m_db_schemaroot + ".btdbn" + aexp).Tables[0].Rows)
            {
                v_mabn = r["mabn"].ToString();
                v_hoten = r["hoten"].ToString().ToUpper().Trim();
                v_hotenkdau = f_khongdau(v_hoten);
                try
                {
                    m_sql = "update " + s_schemaroot + ".btdbn set hoten=:v_hoten ";
                    if (v_hotenkdau.Trim() != "")
                        m_sql += " ,hotenkdau=:v_hotenkdau";
                    m_sql += " where mabn=:v_mabn";
                    m_connection = new NpgsqlConnection(m_db_connectionstring);
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 8).Value = v_mabn;
                    m_command.Parameters.Add("v_hoten", NpgsqlDbType.Text, 50).Value = v_hoten;
                    if (v_hotenkdau.Trim() != "")
                        m_command.Parameters.Add("v_hotenkdau", NpgsqlDbType.Varchar, 50).Value = v_hotenkdau;
                    try
                    {
                        m_connection.Open();
                        int irec = m_command.ExecuteNonQuery();
                        m_command.Dispose();
                    }
                    catch (Exception ex)
                    {
                        upd_v_error(ex.Message, m_computername, "v_hotenkdau");
                        //return false;
                    }
                    finally
                    {
                        m_command.Dispose();
                        m_connection.Dispose();
                    }
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }
        public bool upd_tygia(string v_ngay, decimal v_tygia, decimal v_userid)
        {
            m_sql = "update " + m_db_schemaroot + ".v_tygia set tygia=:v_tygia, userid=:v_userid where to_char(ngay,'dd/mm/yyyy') =:v_ngay";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_ngay", NpgsqlDbType.Text, 10).Value = v_ngay;
            m_command.Parameters.Add("v_tygia", NpgsqlDbType.Numeric).Value = v_tygia;
            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".v_tygia(ngay,tygia,userid) values(to_date(:v_ngay,'dd/mm/yyyy'),:v_tygia,:v_userid)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay;
                    m_command.Parameters.Add("v_tygia", NpgsqlDbType.Numeric).Value = v_tygia;
                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_tygia");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_nhomdlogin(decimal v_id, decimal v_nhom, string v_ma, string v_ten, string v_diengiai, string v_id_bv_so, string v_right_)
        {
            m_sql = "update " + m_db_schemaroot + ".v_nhomdlogin set nhom=:v_nhom, ma=:v_ma,ten=:v_ten,diengiai=:v_diengiai, id_bv_so=:v_id_bv_so, right_=:v_right_ where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_nhom", NpgsqlDbType.Numeric).Value = v_nhom;
            m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 20).Value = v_ma;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
            m_command.Parameters.Add("v_diengiai", NpgsqlDbType.Text).Value = v_diengiai;
            m_command.Parameters.Add("v_id_bv_so", NpgsqlDbType.Varchar, 4000).Value = v_id_bv_so;
            m_command.Parameters.Add("v_right_", NpgsqlDbType.Varchar, 4000).Value = v_right_;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".v_nhomdlogin(id,nhom,ma,ten,diengiai,id_bv_so,right_) values(:v_id,:v_nhom,:v_ma,:v_ten,:v_diengiai,:v_id_bv_so,:v_right_)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_nhom", NpgsqlDbType.Numeric).Value = v_nhom;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 20).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_diengiai", NpgsqlDbType.Text).Value = v_diengiai;
                    m_command.Parameters.Add("v_id_bv_so", NpgsqlDbType.Varchar, 4000).Value = v_id_bv_so;
                    m_command.Parameters.Add("v_right_", NpgsqlDbType.Varchar, 4000).Value = v_right_;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();

                    execute_data("insert into " + s_schemaroot + ".v_phanquyennhom(id_nhom,menuname,chon,chitiet) select " + v_id + ",menuname,chon,chitiet from " + s_schemaroot + ".v_phanquyennhom where id_nhom=" + (v_nhom * -1).ToString());
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_nhomdlogin");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_dlogin(decimal v_id, decimal v_id_nhom, string v_hoten, string v_userid, string v_password_, string v_right_, string v_loaivp)
        {
            m_sql = "update " + m_db_schemaroot + ".v_dlogin set hoten=:v_hoten,userid=:v_userid,password_=:v_password_,right_=:v_right_,loaivp=:v_loaivp,id_nhom=:v_id_nhom where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_id_nhom", NpgsqlDbType.Numeric).Value = v_id_nhom;
            m_command.Parameters.Add("v_hoten", NpgsqlDbType.Text, 50).Value = v_hoten;
            m_command.Parameters.Add("v_userid", NpgsqlDbType.Varchar, 20).Value = v_userid;
            m_command.Parameters.Add("v_password_", NpgsqlDbType.Varchar, 20).Value = v_password_;
            m_command.Parameters.Add("v_right_", NpgsqlDbType.Varchar, 4000).Value = v_right_;
            m_command.Parameters.Add("v_loaivp", NpgsqlDbType.Varchar, 254).Value = v_loaivp;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".v_dlogin(id,id_nhom,hoten,userid,password_,right_,loaivp) values(:v_id,:v_id_nhom,:v_hoten,:v_userid,:v_password_,:v_right_,:v_loaivp)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_id_nhom", NpgsqlDbType.Numeric).Value = v_id_nhom;
                    m_command.Parameters.Add("v_hoten", NpgsqlDbType.Text, 50).Value = v_hoten;
                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Varchar, 20).Value = v_userid;
                    m_command.Parameters.Add("v_password_", NpgsqlDbType.Varchar, 20).Value = v_password_;
                    m_command.Parameters.Add("v_right_", NpgsqlDbType.Varchar, 1000).Value = v_right_;
                    m_command.Parameters.Add("v_loaivp", NpgsqlDbType.Varchar, 254).Value = v_loaivp;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_dlogin");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public void upd_v_khongdau()
        {
            try
            {
                execute_data("delete from v_khongdau");
                string acodau = "", akhongdau = "";
                acodau = "ÁÀẢÃÂẠẬẤẦẨẪĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘÝỲỶỸỴƯỨỪỬỮỰƠỚỜỞỠỢÚÙỦŨỤ";
                akhongdau = "AAAAAAAAAAAAAAAAADEEEEEEEEEEEIIIIIOOOOOOOOOOOYYYYYUUUUUUOOOOOOUUUUU";
                for (int i = 0; i < acodau.Length; i++)
                {
                    upd_v_khongdau(acodau[i].ToString(), akhongdau[i].ToString());
                }
            }
            catch
            {
            }
        }
        public bool upd_v_khongdau(string v_codau, string v_khongdau)
        {
            m_sql = "update " + m_db_schemaroot + ".v_khongdau set khongdau=:v_khongdau where codau=:v_codau";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_codau", NpgsqlDbType.Text).Value = v_codau;
            m_command.Parameters.Add("v_khongdau", NpgsqlDbType.Text).Value = v_khongdau;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".v_khongdau(codau,khongdau) values(:v_codau,:v_khongdau)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_codau", NpgsqlDbType.Text).Value = v_codau;
                    m_command.Parameters.Add("v_khongdau", NpgsqlDbType.Text).Value = v_khongdau;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_khongdau");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_dlogin_right(decimal v_id, string v_right_)
        {
            m_sql = "update " + m_db_schemaroot + ".v_dlogin set right_=:v_right_ where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_right_", NpgsqlDbType.Varchar, 1000).Value = v_right_;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_giavp_right");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_dlogin_loaivp(decimal v_id, string v_loaivp)
        {
            m_sql = "update " + m_db_schemaroot + ".v_dlogin set loaivp=:v_loaivp where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_loaivp", NpgsqlDbType.Varchar, 254).Value = v_loaivp;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_dlogin_loaivp");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_tenloaivp(decimal v_ma, string v_ten, decimal v_readonly)
        {
            m_sql = "update " + s_schemaroot + ".v_tenloaivp set ten=:v_ten,readonly=:v_readonly,ngayud=now() where ma=:v_ma";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".v_tenloaivp(ma,ten,readonly,ngayud) values(:v_ma,:v_ten,:v_readonly,now())";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_tenloaivp");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_dmlydothieu(decimal v_id, string v_ten, decimal v_readonly)
        {
            m_sql = "update " + s_schemaroot + ".v_dmlydothieu set ten=:v_ten,readonly=:v_readonly,ngayud=now() where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".v_dmlydothieu(id,ten,readonly,ngayud) values(:v_id,:v_ten,:v_readonly,now())";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_dmlydothieu");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_dmlydonopthem(decimal v_id, string v_ten, decimal v_readonly)
        {
            m_sql = "update " + s_schemaroot + ".v_dmlydonopthem set ten=:v_ten,readonly=:v_readonly,ngayud=now() where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".v_dmlydonopthem(id,ten,readonly,ngayud) values(:v_id,:v_ten,:v_readonly,now())";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_dmlydonopthem");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_dsduyet(string v_ma, string v_ten, decimal v_readonly)
        {
            m_sql = "update " + s_schemaroot + ".v_dsduyet set ten=:v_ten, readonly=:v_readonly,ngayud=now() where ma=:v_ma";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 4).Value = v_ma;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".v_dsduyet(ma,ten,readonly,ngayud) values(:v_ma,:v_ten,:v_readonly,now())";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 4).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_dsduyet");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_nhomvp(decimal v_ma, decimal v_stt, string v_ten, string v_matat, string v_viettat, decimal v_idnhombhyt, decimal v_readonly)
        {
            m_sql = "update " + s_schemaroot + ".v_nhomvp set ten=:v_ten, stt=:v_stt, idnhombhyt=:v_idnhombhyt, matat=:v_matat, viettat=:v_viettat, readonly=:v_readonly, ngayud=now() where ma=:v_ma";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
            m_command.Parameters.Add("v_matat", NpgsqlDbType.Varchar, 20).Value = v_matat;
            m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_viettat;
            m_command.Parameters.Add("v_idnhombhyt", NpgsqlDbType.Numeric).Value = v_idnhombhyt;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".v_nhomvp(ma,stt,ten,matat,viettat,idnhombhyt,readonly,ngayud) values(:v_ma,:v_stt,:v_ten,:v_matat,:v_viettat,:v_idnhombhyt,:v_readonly,now())";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_matat", NpgsqlDbType.Varchar, 20).Value = v_matat;
                    m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_viettat;
                    m_command.Parameters.Add("v_idnhombhyt", NpgsqlDbType.Numeric).Value = v_idnhombhyt;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_nhomvp");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_nhombhyt(decimal v_id, decimal v_stt, string v_ten, string v_viettat, decimal v_readonly)
        {
            m_sql = "update " + s_schemaroot + ".v_nhombhyt set ten=:v_ten,stt=:v_stt,viettat=:v_viettat,readonly=:v_readonly where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
            m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_viettat;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".v_nhombhyt(id,stt,ten,viettat,readonly,ngayud) values(:v_id,:v_stt,:v_ten,:v_viettat,:v_readonly,now())";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_viettat;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_nhombhyt");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_lydomien(decimal v_id, string v_ten, decimal v_readonly)
        {
            m_sql = "update " + s_schemaroot + ".v_lydomien set ten=:v_ten,readonly=:v_readonly,ngayud=now() where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".v_lydomien(id,ten,readonly,ngayud) values(:v_id,:v_ten,:v_readonly,now())";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_lydomien");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_loaibn(decimal v_id, string v_ten, decimal v_readonly)
        {
            m_sql = "update " + s_schemaroot + ".v_loaibn set ten=:v_ten,readonly=:v_readonly where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 50).Value = v_ten;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".v_loaibn(id,ten,readonly) values(:v_id,:v_ten,:v_readonly)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 50).Value = v_ten;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_loaibn");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_btdvt(string v_matat, string v_daydu)
        {
            m_sql = "update " + s_schemaroot + ".btdvt set daydu=:v_daydu where trim(matat)=trim(:v_matat)";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_matat", NpgsqlDbType.Text, 30).Value = v_matat.Trim();
            m_command.Parameters.Add("v_daydu", NpgsqlDbType.Text, 100).Value = v_daydu.Trim();

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".btdvt(matat,daydu) values(:v_matat,:v_daydu)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_matat", NpgsqlDbType.Text, 30).Value = v_matat.Trim();
                    m_command.Parameters.Add("v_daydu", NpgsqlDbType.Text, 100).Value = v_daydu.Trim();

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "btdvt");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_dmphu(decimal v_id, string v_ten, decimal v_tyle)
        {
            m_sql = "update " + s_schemaroot + ".dmphu set ten=:v_ten,tyle=:v_tyle where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 50).Value = v_ten;
            m_command.Parameters.Add("v_tyle", NpgsqlDbType.Numeric).Value = v_tyle;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".dmphu(id,ten,tyle) values(:v_id,:v_ten,:v_tyle)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 50).Value = v_ten;
                    m_command.Parameters.Add("v_tyle", NpgsqlDbType.Numeric).Value = v_tyle;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "dmphu");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }

        public bool hoantra_ttrvll(string v_mmyy, string v_id)
        {
            try
            {
                execute_data("update " + s_schema_mmyy(v_mmyy) + ".v_thvpll set done=0 where id in (select idtonghop from v_ttrvll where idtonghop<> 0 and id=" + v_id + ")");
                execute_data("update " + s_schema_mmyy(v_mmyy) + ".v_tamung set idttrv=0, done=0 where idttrv=" + v_id + "");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool del_ttrvll(string v_mmyy, string v_id)
        {
            try
            {
                execute_data("update " + s_schema_mmyy(v_mmyy) + ".v_thvpll set done=0 where id in (select idtonghop from " + s_schema_mmyy(v_mmyy) + ".v_ttrvll where idtonghop<> 0 and id=" + v_id + ")");
                execute_data("delete from " + s_schema_mmyy(v_mmyy) + ".v_ttrvds where id=" + v_id + "");
                execute_data("delete from " + s_schema_mmyy(v_mmyy) + ".v_ttrvbhyt where id=" + v_id + "");
                execute_data("delete from " + s_schema_mmyy(v_mmyy) + ".v_ttrvll where id=" + v_id + "");
                execute_data("delete from " + s_schema_mmyy(v_mmyy) + ".v_ttrvct where id=" + v_id + "");
                execute_data("delete from " + s_schema_mmyy(v_mmyy) + ".v_miennoitru where id=" + v_id + "");
                execute_data("update " + s_schema_mmyy(v_mmyy) + ".v_tamung set idttrv=0, done=0 where idttrv=" + v_id + "");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool upd_v_maubaocao(decimal v_id, string v_ma, string v_ten, decimal v_loai)
        {
            m_sql = "update " + s_schemaroot + ".v_maubaocao set ma=:v_ma,ten=:v_ten,loai=:v_loai where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_ma", NpgsqlDbType.Text, 100).Value = v_ma;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 100).Value = v_ten;
            m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".v_maubaocao(id,ma,ten,loai) values(:v_id,:v_ma,:v_ten,:v_loai)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Text, 100).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 100).Value = v_ten;
                    m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_maubaocao");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_dmghe(decimal v_id, decimal v_stt, string v_makp, string v_ma, string v_ten)
        {
            m_sql = "update " + s_schemaroot + ".v_dmghe set stt=:v_stt,makp=:v_makp,ma=:v_ma,ten=:v_ten where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 3).Value = v_makp;
            m_command.Parameters.Add("v_ma", NpgsqlDbType.Text, 50).Value = v_ma;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 100).Value = v_ten;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".v_dmghe(id,stt,makp,ma,ten) values(:v_id,:v_stt,:v_makp,:v_ma,:v_ten)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 3).Value = v_makp;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Text, 50).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 100).Value = v_ten;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_maubaocao");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_sdghe(decimal v_id, decimal v_loai, decimal v_ghe)
        {
            m_sql = "update " + s_schemaroot + ".v_sdghe set id=:v_id,loai=:v_loai,ghe=:v_ghe where id=:v_id and loai=:v_loai and ghe=:v_ghe";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
            m_command.Parameters.Add("v_ghe", NpgsqlDbType.Numeric).Value = v_ghe;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".v_sdghe(id,loai,ghe) values(:v_id,:v_loai,:v_ghe)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                    m_command.Parameters.Add("v_ghe", NpgsqlDbType.Numeric).Value = v_ghe;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_sdghe");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_loaitu(decimal v_id, decimal v_sotien, string v_ten, decimal v_ktt)
        {
            m_sql = "update " + s_schemaroot + ".v_loaitu set sotien=:v_sotien,ten=:v_ten,ktt=:v_ktt where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 50).Value = v_ten;
            m_command.Parameters.Add("v_ktt", NpgsqlDbType.Numeric).Value = v_ktt;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".v_loaitu(id,sotien,ten,ktt) values(:v_id,:v_sotien,:v_ten,:v_ktt)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 50).Value = v_ten;
                    m_command.Parameters.Add("v_ktt", NpgsqlDbType.Numeric).Value = v_ktt;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_loaitu");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_loaithn(decimal v_id, decimal v_id_gia, decimal v_stt, string v_ten)
        {
            m_sql = "update " + s_schemaroot + ".v_loaithn set id_gia=:v_id_gia,stt=:v_stt,ten=:v_ten where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_id_gia", NpgsqlDbType.Numeric).Value = v_id_gia;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 50).Value = v_ten;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".v_loaithn(id,id_gia,stt,ten) values(:v_id,:v_id_gia,:v_stt,:v_ten)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_id_gia", NpgsqlDbType.Numeric).Value = v_id_gia;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 50).Value = v_ten;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_loaithn");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_option_locgiavp(decimal v_userid, decimal v_loai, string v_ten, string v_id_vp)
        {
            m_sql = "update " + s_schemaroot + ".v_option_locgiavp set ten=:v_ten,id_vp=:v_id_vp where userid=:v_userid and loai=:v_loai";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
            m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 50).Value = v_ten;
            m_command.Parameters.Add("v_id_vp", NpgsqlDbType.Varchar, 3000).Value = v_id_vp;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".v_option_locgiavp(userid,loai,ten,id_vp) values(:v_userid,:v_loai,:v_ten,:v_id_vp)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                    m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 50).Value = v_ten;
                    m_command.Parameters.Add("v_id_vp", NpgsqlDbType.Varchar, 3000).Value = v_id_vp;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_option_locgiavp");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_option_thutheonhom(decimal v_id, decimal v_userid, decimal v_stt, string v_ten, string v_id_vp)
        {
            m_sql = "update " + s_schemaroot + ".v_option_thutheonhom set stt=:v_stt,ten=:v_ten,id_vp=:v_id_vp where userid=:v_userid and id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 50).Value = v_ten;
            m_command.Parameters.Add("v_id_vp", NpgsqlDbType.Varchar, 1000).Value = v_id_vp;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".v_option_thutheonhom(id,userid,stt,ten,id_vp) values(:v_id,:v_userid,:v_stt,:v_ten,:v_id_vp)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 50).Value = v_ten;
                    m_command.Parameters.Add("v_id_vp", NpgsqlDbType.Varchar, 1000).Value = v_id_vp;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_option_thutheonhom");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_v_optionform(decimal v_userid, decimal v_loai, string v_ma, string v_ten, string v_giatri)
        {
            bool art = false;
            m_sql = "update " + s_schemaroot + ".v_optionform set ten=:v_ten,giatri=:v_giatri where userid=:v_userid and loai=:v_loai and ma=:v_ma";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
            m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
            m_command.Parameters.Add("v_ma", NpgsqlDbType.Text).Value = v_ma;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
            m_command.Parameters.Add("v_giatri", NpgsqlDbType.Text).Value = v_giatri;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".v_optionform(userid,loai,ma,ten,giatri) values(:v_userid,:v_loai,:v_ma,:v_ten,:v_giatri)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                    m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Text).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_giatri", NpgsqlDbType.Text).Value = v_giatri;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                    art = true;
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_optionform");
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return art;
        }
        public bool upd_v_optionhotkey(decimal v_userid, decimal v_loai, string v_hotkey, decimal v_id, string v_ghichu)
        {
            bool art = false;
            m_sql = "update " + s_schemaroot + ".v_optionhotkey set ghichu=:v_ghichu where userid=:v_userid and loai=:v_loai and hotkey=:v_hotkey and id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
            m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
            m_command.Parameters.Add("v_hotkey", NpgsqlDbType.Varchar, 10).Value = v_hotkey;
            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".v_optionhotkey(userid,loai,hotkey,id,ghichu) values(:v_userid,:v_loai,:v_hotkey,:v_id,:v_ghichu)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                    m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                    m_command.Parameters.Add("v_hotkey", NpgsqlDbType.Varchar, 10).Value = v_hotkey;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                    art = true;
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_optionhotkey");
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return art;
        }
        public bool upd_v_optionhotkey_ksk(decimal v_userid, decimal v_loai, string v_hotkey, decimal v_id, string v_ghichu)
        {
            bool art = false;
            m_sql = "update " + s_schemaroot + ".v_optionhotkey_ksk set ghichu=:v_ghichu where userid=:v_userid and loai=:v_loai and hotkey=:v_hotkey and id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
            m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
            m_command.Parameters.Add("v_hotkey", NpgsqlDbType.Varchar, 10).Value = v_hotkey;
            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".v_optionhotkey_ksk(userid,loai,hotkey,id,ghichu) values(:v_userid,:v_loai,:v_hotkey,:v_id,:v_ghichu)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                    m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                    m_command.Parameters.Add("v_hotkey", NpgsqlDbType.Varchar, 10).Value = v_hotkey;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                    art = true;
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_optionhotkey_ksk");
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return art;
        }
        public bool upd_v_optionlien(decimal v_stt, string v_ten, string v_tenreport)
        {
            bool art = false;
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            try
            {
                m_connection.Open();
                m_sql = "insert into " + s_schemaroot + ".v_optionlien(stt,ten,tenreport) values(:v_stt,:v_ten,:v_tenreport)";
                m_command = new NpgsqlCommand(m_sql, m_connection);
                m_command.CommandType = CommandType.Text;

                m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                m_command.Parameters.Add("v_tenreport", NpgsqlDbType.Text).Value = v_tenreport;

                m_command.ExecuteNonQuery();
                m_command.Dispose();
                art = true;
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_optionlien");
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return art;
        }
        //Tiepdon
        public bool upd_btdbn(string v_mabn, string v_hoten, string v_ngaysinh, string v_namsinh, decimal v_phai, string v_mann, string v_madantoc, string v_sonha, string v_thon, string v_cholam, string v_matt, string v_maqu, string v_maphuongxa, decimal v_userid)
        {
            bool art = true;
            m_sql = "update " + s_schemaroot + ".btdbn set hoten=:v_hoten";
            if (v_ngaysinh.Trim().Length == 10)
            {
                m_sql += ", ngaysinh=to_date(:v_ngaysinh,'dd/mm/yyyy')";
            }
            m_sql += ",namsinh=:v_namsinh, phai=:v_phai, mann=:v_mann,madantoc=:v_madantoc,sonha=:v_sonha, thon=:v_thon,cholam=:v_cholam,matt=:v_matt, maqu=:v_maqu,maphuongxa=:v_maphuongxa,userid=:v_userid, ngayud=now() where mabn=:v_mabn";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 8).Value = v_mabn.Trim();
            m_command.Parameters.Add("v_hoten", NpgsqlDbType.Text).Value = v_hoten.Trim();
            if (v_ngaysinh.Trim().Length == 10)
            {
                m_command.Parameters.Add("v_ngaysinh", NpgsqlDbType.Varchar, 10).Value = v_ngaysinh.Trim();
            }
            m_command.Parameters.Add("v_namsinh", NpgsqlDbType.Varchar, 4).Value = v_namsinh.Trim();
            m_command.Parameters.Add("v_phai", NpgsqlDbType.Numeric).Value = v_phai;
            m_command.Parameters.Add("v_mann", NpgsqlDbType.Varchar, 2).Value = v_mann.Trim();
            m_command.Parameters.Add("v_madantoc", NpgsqlDbType.Varchar, 2).Value = v_madantoc.Trim();
            m_command.Parameters.Add("v_sonha", NpgsqlDbType.Varchar, 15).Value = v_sonha.Trim();
            m_command.Parameters.Add("v_thon", NpgsqlDbType.Text).Value = v_thon;
            m_command.Parameters.Add("v_cholam", NpgsqlDbType.Text).Value = v_cholam;
            m_command.Parameters.Add("v_matt", NpgsqlDbType.Varchar, 3).Value = v_matt;
            m_command.Parameters.Add("v_maqu", NpgsqlDbType.Varchar, 5).Value = v_maqu;
            m_command.Parameters.Add("v_maphuongxa", NpgsqlDbType.Varchar, 7).Value = v_maphuongxa;
            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    if (v_ngaysinh.Trim().Length == 10)
                    {
                        m_sql = "insert into " + s_schemaroot + ".btdbn(mabn,hoten,ngaysinh,namsinh,phai,mann,madantoc,sonha,thon,cholam,matt,maqu,maphuongxa,userid,ngayud) values(:v_mabn,:v_hoten,to_date(:v_ngaysinh,'dd/mm/yyyy'),:v_namsinh,:v_phai,:v_mann,:v_madantoc,:v_sonha,:v_thon,:v_cholam,:v_matt,:v_maqu,:v_maphuongxa,:v_userid,now())";
                    }
                    else
                    {
                        m_sql = "insert into " + s_schemaroot + ".btdbn(mabn,hoten,namsinh,phai,mann,madantoc,sonha,thon,cholam,matt,maqu,maphuongxa,userid,ngayud) values(:v_mabn,:v_hoten,:v_namsinh,:v_phai,:v_mann,:v_madantoc,:v_sonha,:v_thon,:v_cholam,:v_matt,:v_maqu,:v_maphuongxa,:v_userid,now())";
                    }

                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 8).Value = v_mabn;
                    m_command.Parameters.Add("v_hoten", NpgsqlDbType.Text).Value = v_hoten;
                    if (v_ngaysinh.Trim().Length == 10)
                    {
                        m_command.Parameters.Add("v_ngaysinh", NpgsqlDbType.Varchar, 10).Value = v_ngaysinh.Trim();
                    }
                    m_command.Parameters.Add("v_namsinh", NpgsqlDbType.Varchar, 4).Value = v_namsinh;
                    m_command.Parameters.Add("v_phai", NpgsqlDbType.Numeric).Value = v_phai;
                    m_command.Parameters.Add("v_mann", NpgsqlDbType.Varchar, 2).Value = v_mann;
                    m_command.Parameters.Add("v_madantoc", NpgsqlDbType.Varchar, 2).Value = v_madantoc;
                    m_command.Parameters.Add("v_sonha", NpgsqlDbType.Varchar, 15).Value = v_sonha;
                    m_command.Parameters.Add("v_thon", NpgsqlDbType.Text).Value = v_thon;
                    m_command.Parameters.Add("v_cholam", NpgsqlDbType.Text).Value = v_cholam;
                    m_command.Parameters.Add("v_matt", NpgsqlDbType.Varchar, 3).Value = v_matt;
                    m_command.Parameters.Add("v_maqu", NpgsqlDbType.Varchar, 5).Value = v_maqu;
                    m_command.Parameters.Add("v_maphuongxa", NpgsqlDbType.Varchar, 7).Value = v_maphuongxa;
                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.ToString(), m_computername, s_schemaroot + ".btdbn");
                art = false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return art;
        }
        public decimal upd_tiepdon(string v_mabn, decimal v_maql, string v_makp, string v_ngay16, decimal v_madoituong, string v_sovaovien, string v_tuoivao, decimal v_benhnhanmoi, decimal v_noitiepdon, decimal v_loai, decimal v_userid)
        {
            try
            {
                if (v_maql == 0)
                {
                    v_maql = get_maql;
                }
                string ammyy = "";
                ammyy = v_ngay16.Split('/')[1] + v_ngay16.Split('/')[2].Substring(2, 2);
                if (ammyy.Length < 4)
                {
                    ammyy = s_curmmyy;
                }
                if (v_ngay16.Length < 16)
                {
                    v_ngay16 = v_ngay16.Substring(0, 10);
                    v_ngay16 = v_ngay16 + " " + DateTime.Now.Hour.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0');
                }
                m_sql = "update " + s_schema_mmyy(ammyy) + ".tiepdon set mabn=:v_mabn, makp=:v_makp, ngay=to_date(:v_ngay,'dd/mm/yyyy hh24:mi'), madoituong=:v_madoituong, sovaovien=:v_sovaovien, tuoivao=:v_tuoivao,bnmoi=:v_bnmoi,noitiepdon=:v_noitiepdon,loai=:v_loai,userid=:v_userid where maql=:v_maql";
                m_connection = new NpgsqlConnection(m_db_connectionstring);
                m_command = new NpgsqlCommand(m_sql, m_connection);
                m_command.CommandType = CommandType.Text;

                m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 8).Value = v_mabn;
                m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 3).Value = v_makp;
                m_command.Parameters.Add("v_ngay", NpgsqlDbType.Text).Value = v_ngay16;
                m_command.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
                m_command.Parameters.Add("v_sovaovien", NpgsqlDbType.Varchar, 10).Value = v_sovaovien;
                m_command.Parameters.Add("v_tuoivao", NpgsqlDbType.Varchar, 4).Value = v_tuoivao;
                m_command.Parameters.Add("v_bnmoi", NpgsqlDbType.Numeric).Value = v_benhnhanmoi;
                m_command.Parameters.Add("v_noitiepdon", NpgsqlDbType.Numeric).Value = v_noitiepdon;
                m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;

                try
                {
                    m_connection.Open();
                    int irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                    if (irec == 0)
                    {
                        m_sql = "insert into " + s_schema_mmyy(ammyy) + ".tiepdon(mabn,maql,makp,ngay,madoituong,sovaovien,tuoivao,bnmoi,noitiepdon,loai,done,userid,ngayud) values(:v_mabn,:v_maql,:v_makp,to_date(:v_ngay,'dd/mm/yyyy hh24:mi'),:v_madoituong,:v_sovaovien,:v_tuoivao,:v_bnmoi,:v_noitiepdon,:v_loai,0,:v_userid,now())";
                        m_command = new NpgsqlCommand(m_sql, m_connection);
                        m_command.CommandType = CommandType.Text;

                        m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 8).Value = v_mabn;
                        m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                        m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 3).Value = v_makp;
                        m_command.Parameters.Add("v_ngay", NpgsqlDbType.Text).Value = v_ngay16;
                        m_command.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
                        m_command.Parameters.Add("v_sovaovien", NpgsqlDbType.Varchar, 10).Value = v_sovaovien;
                        m_command.Parameters.Add("v_tuoivao", NpgsqlDbType.Varchar, 4).Value = v_tuoivao;
                        m_command.Parameters.Add("v_bnmoi", NpgsqlDbType.Numeric).Value = v_benhnhanmoi;
                        m_command.Parameters.Add("v_noitiepdon", NpgsqlDbType.Numeric).Value = v_noitiepdon;
                        m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                        m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;

                        irec = m_command.ExecuteNonQuery();
                        m_command.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    upd_v_error(ammyy, ex.Message, m_computername, s_schema_mmyy(ammyy) + ".tiepdon");
                    return 0;
                }
                finally
                {
                    m_command.Dispose();
                    m_connection.Dispose();
                }
                return v_maql;
            }
            catch
            {
                return 0;
            }
        }
        public bool upd_lienhe_mmyy(string v_mmyy, decimal v_maql, string v_sonha, string v_thon, string v_cholam, string v_matt, string v_maqu, string v_maphuongxa, string v_tuoivao, string v_soluutru, decimal v_honnhan, string v_mabs, decimal v_loai, decimal v_bnmoi)
        {
            if (v_maql == 0)
            {
                return false;
            }
            if (v_mmyy.Length < 4)
            {
                v_mmyy = s_curmmyy;
            }
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".lienhe set sonha=:v_sonha, thon=:v_thon, cholam=:v_cholam, matt=:v_matt, maqu=:v_maqu, maphuongxa=:v_maphuongxa, tuoivao=:v_tuoivao, soluutru=:v_soluutru, honnhan=:v_honnhan, mabs=:v_mabs, loai=:v_loai, bnmoi=:v_bnmoi where maql=:v_maql";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
            m_command.Parameters.Add("v_sonha", NpgsqlDbType.Varchar, 15).Value = v_sonha;
            m_command.Parameters.Add("v_thon", NpgsqlDbType.Text).Value = v_thon;
            m_command.Parameters.Add("v_cholam", NpgsqlDbType.Text).Value = v_cholam;
            m_command.Parameters.Add("v_matt", NpgsqlDbType.Varchar, 3).Value = v_matt;
            m_command.Parameters.Add("v_maqu", NpgsqlDbType.Varchar, 5).Value = v_maqu;
            m_command.Parameters.Add("v_maphuongxa", NpgsqlDbType.Varchar, 7).Value = v_maphuongxa;
            m_command.Parameters.Add("v_tuoivao", NpgsqlDbType.Varchar, 4).Value = v_tuoivao;
            m_command.Parameters.Add("v_soluutru", NpgsqlDbType.Varchar, 10).Value = v_soluutru;
            m_command.Parameters.Add("v_honnhan", NpgsqlDbType.Numeric).Value = v_honnhan;
            m_command.Parameters.Add("v_mabs", NpgsqlDbType.Varchar, 4).Value = v_mabs;
            m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
            m_command.Parameters.Add("v_bnmoi", NpgsqlDbType.Numeric).Value = v_bnmoi;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".lienhe(maql,sonha,thon,cholam,matt,maqu,maphuongxa,tuoivao,soluutru,honnhan,mabs,loai,bnmoi) values(:v_maql,:v_sonha,:v_thon,:v_cholam,:v_matt,:v_maqu,:v_maphuongxa,:v_tuoivao,:v_soluutru,:v_honnhan,:v_mabs,:v_loai,:v_bnmoi)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                    m_command.Parameters.Add("v_sonha", NpgsqlDbType.Varchar, 15).Value = v_sonha;
                    m_command.Parameters.Add("v_thon", NpgsqlDbType.Text).Value = v_thon;
                    m_command.Parameters.Add("v_cholam", NpgsqlDbType.Text).Value = v_cholam;
                    m_command.Parameters.Add("v_matt", NpgsqlDbType.Varchar, 3).Value = v_matt;
                    m_command.Parameters.Add("v_maqu", NpgsqlDbType.Varchar, 5).Value = v_maqu;
                    m_command.Parameters.Add("v_maphuongxa", NpgsqlDbType.Varchar, 7).Value = v_maphuongxa;
                    m_command.Parameters.Add("v_tuoivao", NpgsqlDbType.Varchar, 4).Value = v_tuoivao;
                    m_command.Parameters.Add("v_soluutru", NpgsqlDbType.Varchar, 10).Value = v_soluutru;
                    m_command.Parameters.Add("v_honnhan", NpgsqlDbType.Numeric).Value = v_honnhan;
                    m_command.Parameters.Add("v_mabs", NpgsqlDbType.Varchar, 4).Value = v_mabs;
                    m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                    m_command.Parameters.Add("v_bnmoi", NpgsqlDbType.Numeric).Value = v_bnmoi;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(v_mmyy, ex.Message, m_computername, "lienhe");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_lienhe(decimal v_maql, string v_sonha, string v_thon, string v_cholam, string v_matt, string v_maqu, string v_maphuongxa, string v_tuoivao, string v_soluutru, decimal v_honnhan, string v_mabs, decimal v_loai, decimal v_bnmoi)
        {
            if (v_maql == 0)
            {
                return false;
            }
            m_sql = "update " + s_schemaroot + ".lienhe set sonha=:v_sonha, thon=:v_thon, cholam=:v_cholam, matt=:v_matt, maqu=:v_maqu, maphuongxa=:v_maphuongxa, tuoivao=:v_tuoivao, soluutru=:v_soluutru, honnhan=:v_honnhan, mabs=:v_mabs, loai=:v_loai, bnmoi=:v_bnmoi where maql=:v_maql";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
            m_command.Parameters.Add("v_sonha", NpgsqlDbType.Varchar, 15).Value = v_sonha;
            m_command.Parameters.Add("v_thon", NpgsqlDbType.Text).Value = v_thon;
            m_command.Parameters.Add("v_cholam", NpgsqlDbType.Text).Value = v_cholam;
            m_command.Parameters.Add("v_matt", NpgsqlDbType.Varchar, 3).Value = v_matt;
            m_command.Parameters.Add("v_maqu", NpgsqlDbType.Varchar, 5).Value = v_maqu;
            m_command.Parameters.Add("v_maphuongxa", NpgsqlDbType.Varchar, 7).Value = v_maphuongxa;
            m_command.Parameters.Add("v_tuoivao", NpgsqlDbType.Varchar, 4).Value = v_tuoivao;
            m_command.Parameters.Add("v_soluutru", NpgsqlDbType.Varchar, 10).Value = v_soluutru;
            m_command.Parameters.Add("v_honnhan", NpgsqlDbType.Numeric).Value = v_honnhan;
            m_command.Parameters.Add("v_mabs", NpgsqlDbType.Varchar, 4).Value = v_mabs;
            m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
            m_command.Parameters.Add("v_bnmoi", NpgsqlDbType.Numeric).Value = v_bnmoi;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".lienhe(maql,sonha,thon,cholam,matt,maqu,maphuongxa,tuoivao,soluutru,honnhan,mabs,loai,bnmoi) values(:v_maql,:v_sonha,:v_thon,:v_cholam,:v_matt,:v_maqu,:v_maphuongxa,:v_tuoivao,:v_soluutru,:v_honnhan,:v_mabs,:v_loai,:v_bnmoi)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                    m_command.Parameters.Add("v_sonha", NpgsqlDbType.Varchar, 15).Value = v_sonha;
                    m_command.Parameters.Add("v_thon", NpgsqlDbType.Text).Value = v_thon;
                    m_command.Parameters.Add("v_cholam", NpgsqlDbType.Text).Value = v_cholam;
                    m_command.Parameters.Add("v_matt", NpgsqlDbType.Varchar, 3).Value = v_matt;
                    m_command.Parameters.Add("v_maqu", NpgsqlDbType.Varchar, 5).Value = v_maqu;
                    m_command.Parameters.Add("v_maphuongxa", NpgsqlDbType.Varchar, 7).Value = v_maphuongxa;
                    m_command.Parameters.Add("v_tuoivao", NpgsqlDbType.Varchar, 4).Value = v_tuoivao;
                    m_command.Parameters.Add("v_soluutru", NpgsqlDbType.Varchar, 10).Value = v_soluutru;
                    m_command.Parameters.Add("v_honnhan", NpgsqlDbType.Numeric).Value = v_honnhan;
                    m_command.Parameters.Add("v_mabs", NpgsqlDbType.Varchar, 4).Value = v_mabs;
                    m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                    m_command.Parameters.Add("v_bnmoi", NpgsqlDbType.Numeric).Value = v_bnmoi;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "lienhe");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_quanhe_mmyy(string v_mmyy, decimal v_maql, string v_quanhe, string v_hoten, string v_diachi, string v_dienthoai)
        {
            if (v_maql == 0)
            {
                return false;
            }
            if (v_mmyy.Length < 4)
            {
                v_mmyy = s_curmmyy;
            }
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".quanhe set quanhe=:v_quanhe, hoten=:v_hoten, diachi=:v_diachi, dienthoai=:v_dienthoai where maql=:v_maql";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
            m_command.Parameters.Add("v_quanhe", NpgsqlDbType.Varchar, 30).Value = v_quanhe;
            m_command.Parameters.Add("v_hoten", NpgsqlDbType.Text).Value = v_hoten;
            m_command.Parameters.Add("v_diachi", NpgsqlDbType.Text).Value = v_diachi;
            m_command.Parameters.Add("v_dienthoai", NpgsqlDbType.Varchar, 20).Value = v_dienthoai;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".quanhe(maql,quanhe,hoten,diachi,dienthoai) values(:v_maql,:v_quanhe,:v_hoten,:v_diachi,:v_dienthoai)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                    m_command.Parameters.Add("v_quanhe", NpgsqlDbType.Varchar, 30).Value = v_quanhe;
                    m_command.Parameters.Add("v_hoten", NpgsqlDbType.Text).Value = v_hoten;
                    m_command.Parameters.Add("v_diachi", NpgsqlDbType.Text).Value = v_diachi;
                    m_command.Parameters.Add("v_dienthoai", NpgsqlDbType.Varchar, 20).Value = v_dienthoai;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(v_mmyy, ex.Message, m_computername, "quanhe");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_quanhe(decimal v_maql, string v_quanhe, string v_hoten, string v_diachi, string v_dienthoai)
        {
            if (v_maql == 0)
            {
                return false;
            }
            m_sql = "update " + s_schemaroot + ".quanhe set quanhe=:v_quanhe, hoten=:v_hoten, diachi=:v_diachi, dienthoai=:v_dienthoai where maql=:v_maql";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
            m_command.Parameters.Add("v_quanhe", NpgsqlDbType.Varchar, 30).Value = v_quanhe;
            m_command.Parameters.Add("v_hoten", NpgsqlDbType.Text).Value = v_hoten;
            m_command.Parameters.Add("v_diachi", NpgsqlDbType.Text).Value = v_diachi;
            m_command.Parameters.Add("v_dienthoai", NpgsqlDbType.Varchar, 20).Value = v_dienthoai;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".quanhe(maql,quanhe,hoten,diachi,dienthoai) values(:v_maql,:v_quanhe,:v_hoten,:v_diachi,:v_dienthoai)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                    m_command.Parameters.Add("v_quanhe", NpgsqlDbType.Varchar, 30).Value = v_quanhe;
                    m_command.Parameters.Add("v_hoten", NpgsqlDbType.Text).Value = v_hoten;
                    m_command.Parameters.Add("v_diachi", NpgsqlDbType.Text).Value = v_diachi;
                    m_command.Parameters.Add("v_dienthoai", NpgsqlDbType.Varchar, 20).Value = v_dienthoai;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "quanhe");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_bhyt_mmyy(string v_mmyy, string v_mabn, decimal v_maql, string v_sothe, string v_tn, string v_dn, string v_mabv, decimal v_maphu)
        {
            if (v_maql == 0)
            {
                return false;
            }
            if (v_mmyy.Length < 4)
            {
                v_mmyy = s_curmmyy;
            }
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".bhyt set mabn=:v_mabn, sothe=:v_sothe";
            if (v_tn.Length == 10)
            {
                m_sql += ", tungay=to_date(:v_tn,'dd/mm/yyyy')";
            }
            if (v_dn.Length == 10)
            {
                m_sql += ", denngay=to_date(:v_dn,'dd/mm/yyyy')";
            }
            m_sql += ",mabv=:v_mabv,maphu=:v_maphu where maql=:v_maql";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 8).Value = v_mabn;
            m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
            m_command.Parameters.Add("v_sothe", NpgsqlDbType.Varchar, 20).Value = v_sothe;
            if (v_tn.Length == 10)
            {
                m_command.Parameters.Add("v_tn", NpgsqlDbType.Varchar, 10).Value = v_tn;
            }
            if (v_dn.Length == 10)
            {
                m_command.Parameters.Add("v_dn", NpgsqlDbType.Varchar, 10).Value = v_dn;
            }
            m_command.Parameters.Add("v_mabv", NpgsqlDbType.Varchar, 9).Value = v_mabv;
            m_command.Parameters.Add("v_maphu", NpgsqlDbType.Numeric).Value = v_maphu;
            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".bhyt(mabn,maql,sothe,tungay,denngay,mabv,maphu) values(:v_mabn,:v_maql,:v_sothe," + (v_tn.Length == 10 ? "to_date(:v_tn,'dd/mm/yyyy')" : "null") + "," + (v_dn.Length == 10 ? "to_date(:v_dn,'dd/mm/yyyy')" : "null") + ",:v_mabv,:v_maphu)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 8).Value = v_mabn;
                    m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                    m_command.Parameters.Add("v_sothe", NpgsqlDbType.Varchar, 20).Value = v_sothe;
                    if (v_tn.Length == 10)
                    {
                        m_command.Parameters.Add("v_tn", NpgsqlDbType.Varchar, 10).Value = v_tn;
                    }
                    if (v_dn.Length == 10)
                    {
                        m_command.Parameters.Add("v_dn", NpgsqlDbType.Varchar, 10).Value = v_dn;
                    }
                    m_command.Parameters.Add("v_mabv", NpgsqlDbType.Varchar, 9).Value = v_mabv;
                    m_command.Parameters.Add("v_maphu", NpgsqlDbType.Numeric).Value = v_maphu;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(v_mmyy, ex.Message, m_computername, "bhyt");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_bhyt(string v_mabn, decimal v_maql, string v_sothe, string v_tn, string v_dn, string v_mabv, decimal v_maphu)
        {
            if (v_maql == 0)
            {
                return false;
            }
            m_sql = "update " + s_schemaroot + ".bhyt set mabn=:v_mabn, sothe=:v_sothe";
            if (v_tn.Length == 10)
            {
                m_sql += ", tungay=to_date(:v_tn,'dd/mm/yyyy')";
            }
            if (v_dn.Length == 10)
            {
                m_sql += ", denngay=to_date(:v_dn,'dd/mm/yyyy')";
            }
            m_sql += ",mabv=:v_mabv,maphu=:v_maphu where maql=:v_maql";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 8).Value = v_mabn;
            m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
            m_command.Parameters.Add("v_sothe", NpgsqlDbType.Varchar, 20).Value = v_sothe;
            if (v_tn.Length == 10)
            {
                m_command.Parameters.Add("v_tn", NpgsqlDbType.Varchar, 10).Value = v_tn;
            }
            if (v_dn.Length == 10)
            {
                m_command.Parameters.Add("v_dn", NpgsqlDbType.Varchar, 10).Value = v_dn;
            }
            m_command.Parameters.Add("v_mabv", NpgsqlDbType.Varchar, 9).Value = v_mabv;
            m_command.Parameters.Add("v_maphu", NpgsqlDbType.Numeric).Value = v_maphu;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".bhyt(mabn,maql,sothe,tungay,denngay,mabv,maphu) values(:v_mabn,:v_maql,:v_sothe," + (v_tn.Length == 10 ? "to_date(:v_tn,'dd/mm/yyyy')" : "null") + "," + (v_dn.Length == 10 ? "to_date(:v_dn,'dd/mm/yyyy')" : "null") + ",:v_mabv,:v_maphu)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 8).Value = v_mabn;
                    m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                    m_command.Parameters.Add("v_sothe", NpgsqlDbType.Varchar, 20).Value = v_sothe;
                    if (v_tn.Length == 10)
                    {
                        m_command.Parameters.Add("v_tn", NpgsqlDbType.Varchar, 10).Value = v_tn;
                    }
                    if (v_dn.Length == 10)
                    {
                        m_command.Parameters.Add("v_dn", NpgsqlDbType.Varchar, 10).Value = v_dn;
                    }
                    m_command.Parameters.Add("v_mabv", NpgsqlDbType.Varchar, 8).Value = v_mabv;
                    m_command.Parameters.Add("v_maphu", NpgsqlDbType.Numeric).Value = v_maphu;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "bhyt");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_dienthoai(string v_mabn, string v_nha, string v_coquan, string v_didong, string v_email)
        {
            if (v_mabn.Length < 8)
            {
                return false;
            }
            m_sql = "update " + s_schemaroot + ".dienthoai set nha=:v_nha, coquan=:v_coquan, didong=:v_didong, email=:v_email where mabn=:v_mabn";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 8).Value = v_mabn;
            m_command.Parameters.Add("v_nha", NpgsqlDbType.Varchar, 8).Value = v_nha;
            m_command.Parameters.Add("v_coquan", NpgsqlDbType.Varchar, 20).Value = v_coquan;
            m_command.Parameters.Add("v_didong", NpgsqlDbType.Varchar, 15).Value = v_didong;
            m_command.Parameters.Add("v_email", NpgsqlDbType.Text).Value = v_email;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".dienthoai(mabn,nha,coquan,didong,email) values(:v_mabn,:v_nha,:v_coquan,:v_didong,:v_email)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 8).Value = v_mabn;
                    m_command.Parameters.Add("v_nha", NpgsqlDbType.Varchar, 8).Value = v_nha;
                    m_command.Parameters.Add("v_coquan", NpgsqlDbType.Varchar, 20).Value = v_coquan;
                    m_command.Parameters.Add("v_didong", NpgsqlDbType.Varchar, 15).Value = v_didong;
                    m_command.Parameters.Add("v_email", NpgsqlDbType.Text).Value = v_email;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "dienthoai");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }

        #endregion CẬP NHẬT DATA TABLE

        #region GIỚI HẠN QUYỀN MENU TẮT
        public void f_create_table_ghquyen()
        {
            try
            {
                execute_data("create table " + s_schemaroot + ".v_ghquyen_danhmuc(id numeric(5),loai numeric(2), ma varchar2(20), ten text, ghichu text,dung numeric(1) default 1, constraint pk_v_ghquyen_dmquyen primary key(id,loai)) with oids");
                execute_data("alter table " + m_db_schemaroot + ".v_ghquyen owner to " + m_db_database + "");
                execute_data("create table " + s_schemaroot + ".v_ghquyen_phanquyen(userid numeric(5),loai numeric(2), id_quyen numeric(5), nhap numeric(1) default 0, constraint pk_v_ghquyen_phanquyen primary key(userid,loai,id_quyen)) with oids");
                execute_data("alter table " + m_db_schemaroot + ".v_ghquyen owner to " + m_db_database + "");
                upd_v_ghquyen_danhmuc();
            }
            catch
            {
            }
        }
        public void upd_v_ghquyen_danhmuc()
        {
            try
            {
                execute_data("delete from v_ghquyen_danhmuc");
                //Thu truc tiep: loai=1
                upd_v_ghquyen_danhmuc(2, 1, "2", "Hoàn trả biên lai (Menu tắt)", "", 1);
                upd_v_ghquyen_danhmuc(3, 1, "3", "Sửa ngày, quyển sổ, số biên lai (Menu tắt)", "", 1);
                upd_v_ghquyen_danhmuc(4, 1, "4", "Nhập biên lai bổ sung (Menu tắt)", "", 1);
                upd_v_ghquyen_danhmuc(5, 1, "5", "Số biên lai tăng tự động (Menu tắt)", "", 1);
                upd_v_ghquyen_danhmuc(6, 1, "6", "Lấy ngày chỉ định chưa thu viện phí (Menu tắt)", "", 1);

                //Thu BHYT: loai=2
                upd_v_ghquyen_danhmuc(2, 2, "2", "Hoàn trả biên lai (Menu tắt)", "", 1);
                upd_v_ghquyen_danhmuc(3, 2, "3", "Sửa ngày, quyển sổ, số biên lai (Menu tắt)", "", 1);
                upd_v_ghquyen_danhmuc(4, 2, "4", "Nhập biên lai bổ sung (Menu tắt)", "", 1);
                upd_v_ghquyen_danhmuc(4, 2, "5", "Lấy lại chi phí đã in (Menu tắt)", "", 1);

                //Thu tamung: loai=3
                upd_v_ghquyen_danhmuc(2, 3, "2", "Hoàn trả biên lai (Menu tắt)", "", 1);
                upd_v_ghquyen_danhmuc(3, 3, "3", "Sửa ngày, quyển sổ, số biên lai (Menu tắt)", "", 1);
                upd_v_ghquyen_danhmuc(4, 3, "4", "Nhập bổ sung (cho nhập số biên lai) (Menu tắt)", "", 1);

                //Thanh toan ra vien: loai=4
                upd_v_ghquyen_danhmuc(2, 4, "2", "Hoàn trả biên lai (Menu tắt)", "", 1);
                upd_v_ghquyen_danhmuc(3, 4, "3", "Sửa ngày, quyển sổ, số biên lai (Menu tắt)", "", 1);
                upd_v_ghquyen_danhmuc(4, 4, "4", "Nhập biên lai bổ sung (Menu tắt)", "", 1);
                upd_v_ghquyen_danhmuc(5, 4, "5", "Lấy lại chi phí đã in (Menu tắt)", "", 1);
                upd_v_ghquyen_danhmuc(6, 4, "6", "Tổng hợp lại số liệu khoa chưa chuyển thanh toán (Menu tắt)", "", 1);
                upd_v_ghquyen_danhmuc(7, 4, "7", "Tự động tổng hợp lại số liệu nếu khoa chưa chuyển thanh toán (Menu tắt)", "", 1);

                //Hoan tra bien lai: loai=5
                upd_v_ghquyen_danhmuc(2, 5, "HT", "Xoá biên lai hoàn trả)", "", 1);
            }
            catch
            {
            }
        }
        private bool upd_v_ghquyen_danhmuc(decimal v_id, decimal v_loai, string v_ma, string v_ten, string v_ghichu, decimal v_dung)
        {
            m_sql = "update " + s_schemaroot + ".v_ghquyen_danhmuc set ma=:v_ma, ten=:v_ten,ghichu=:v_ghichu,dung=:v_dung where id=:v_id and loai=:v_loai";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
            m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 20).Value = v_ma;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 255).Value = v_ten;
            m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text, 50).Value = v_ghichu;
            m_command.Parameters.Add("v_dung", NpgsqlDbType.Numeric).Value = v_dung;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".v_ghquyen_danhmuc(id,loai,ma,ten,ghichu,dung) values(:v_id,:v_loai,:v_ma,:v_ten,:v_ghichu,:v_dung)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 20).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 255).Value = v_ten;
                    m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text, 50).Value = v_ghichu;
                    m_command.Parameters.Add("v_dung", NpgsqlDbType.Numeric).Value = v_dung;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "v_ghquyen_danhmuc");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }

        public DataSet frmDMQuyencapnhat_f_load_dg0(string v_userid)
        {
            try
            {
                string asql = "select a.id, a.ma, a.ten, c.nhap from v_ghquyen_danhmuc a, (select * from v_ghquyen_phanquyen where loai=1 and userid=" + v_userid + ") c where a.loai=1 and a.id=c.id_quyen(+)";
                return get_data(asql);
            }
            catch
            {
                return null;
            }
        }
        public DataSet frmDMQuyencapnhat_f_load_dg1(string v_userid)
        {
            try
            {
                string asql = "select a.id, a.ma, a.ten, c.nhap from v_ghquyen_danhmuc a, (select * from v_ghquyen_phanquyen where loai=2 and userid=" + v_userid + ") c where a.loai=2 and a.id=c.id_quyen(+)";
                return get_data(asql);
            }
            catch
            {
                return null;
            }
        }
        public DataSet frmDMQuyencapnhat_f_load_dg2(string v_userid)
        {
            try
            {
                string asql = "select a.id, a.ma, a.ten, c.nhap from v_ghquyen_danhmuc a, (select * from v_ghquyen_phanquyen where loai=3 and userid=" + v_userid + ") c where a.loai=3 and a.id=c.id_quyen(+)";
                return get_data(asql);
            }
            catch
            {
                return null;
            }
        }
        public DataSet frmDMQuyencapnhat_f_load_dg3(string v_userid)
        {
            try
            {
                string asql = "select a.id, a.ma, a.ten, c.nhap from v_ghquyen_danhmuc a, (select * from v_ghquyen_phanquyen where loai=4 and userid=" + v_userid + ") c where a.loai=4 and a.id=c.id_quyen(+)";
                return get_data(asql);
            }
            catch
            {
                return null;
            }
        }
        public DataSet frmDMQuyencapnhat_f_load_dg4(string v_userid)
        {
            try
            {
                string asql = "select a.id, a.ma, a.ten, c.nhap from " + m_db_schemaroot + ".v_ghquyen_danhmuc a, (select * from " + m_db_schemaroot + ".v_ghquyen_phanquyen where loai=5 and userid=" + v_userid + ") c where a.loai=5 and a.id=c.id_quyen(+)";
                return get_data(asql);
            }
            catch
            {
                return null;
            }
        }
        public DataSet frmDMQuyencapnhat_f_load_dg5(string v_userid)
        {
            try
            {
                string asql = "select a.id, a.ma, a.ten, nhap from " + m_db_schemaroot + ".v_ghquyen_danhmuc a, (select * from " + m_db_schemaroot + ".v_ghquyen_phanquyen where loai=6 and userid=" + v_userid + ") c where a.loai=6 and a.id=c.id_quyen(+)";
                return get_data(asql);
            }
            catch
            {
                return null;
            }
        }
        private bool f_ghquyen_thutructiep_nhap(string v_userid, string v_id_quyen, bool v_default)
        {
            bool r = v_default;
            try
            {
                r = get_data("select nhap from " + m_db_schemaroot + ".v_ghquyen_phanquyen where loai=1 and userid=" + v_userid + " and id_quyen=" + v_id_quyen + "").Tables[0].Rows[0][0].ToString().Trim() == "1";
            }
            catch
            {
                r = v_default;
            }
            return r;
        }
        public bool f_ghquyen_thutructiep_hoantra(string v_userid)
        {
            return f_ghquyen_thutructiep_nhap(v_userid, "2", true);
        }
        public bool f_ghquyen_thutructiep_sua_ngay_quyenso_sobienlai(string v_userid)
        {
            return f_ghquyen_thutructiep_nhap(v_userid, "3", true);
        }
        public bool f_ghquyen_thutructiep_nhapbosung(string v_userid)
        {
            return f_ghquyen_thutructiep_nhap(v_userid, "4", true);
        }
        public bool f_ghquyen_thutructiep_sobienlaitangtudong(string v_userid)
        {
            return f_ghquyen_thutructiep_nhap(v_userid, "5", true);
        }
        public bool f_ghquyen_thutructiep_layngaychidinhchuathu(string v_userid)
        {
            return f_ghquyen_thutructiep_nhap(v_userid, "6", true);
        }
        private bool f_ghquyen_thubhyt_nhap(string v_userid, string v_id_quyen, bool v_default)
        {
            bool r = v_default;
            try
            {
                r = get_data("select nhap from " + m_db_schemaroot + ".v_ghquyen_phanquyen where loai=2 and userid=" + v_userid + " and id_quyen=" + v_id_quyen + "").Tables[0].Rows[0][0].ToString().Trim() == "1";
            }
            catch
            {
                r = v_default;
            }
            return r;
        }
        public bool f_ghquyen_thubhyt_hoantra(string v_userid)
        {
            return f_ghquyen_thubhyt_nhap(v_userid, "2", true);
        }
        public bool f_ghquyen_thubhyt_sua_ngay_quyenso_sobienlai(string v_userid)
        {
            return f_ghquyen_thubhyt_nhap(v_userid, "3", true);
        }
        public bool f_ghquyen_thubhyt_nhapbosung(string v_userid)
        {
            return f_ghquyen_thubhyt_nhap(v_userid, "4", true);
        }
        public bool f_ghquyen_thubhyt_laylaichiphidain(string v_userid)
        {
            return f_ghquyen_thubhyt_nhap(v_userid, "5", true);
        }
        private bool f_ghquyen_thutamung_nhap(string v_userid, string v_id_quyen, bool v_default)
        {
            bool r = v_default;
            try
            {
                r = get_data("select nhap from " + m_db_schemaroot + ".v_ghquyen_phanquyen where loai=3 and userid=" + v_userid + " and id_quyen=" + v_id_quyen + "").Tables[0].Rows[0][0].ToString().Trim() == "1";
            }
            catch
            {
                r = v_default;
            }
            return r;
        }
        public bool f_ghquyen_thutamung_hoantra(string v_userid)
        {
            return f_ghquyen_thutamung_nhap(v_userid, "2", true);
        }
        public bool f_ghquyen_thutamung_sua_ngay_quyenso_sobienlai(string v_userid)
        {
            return f_ghquyen_thutamung_nhap(v_userid, "3", true);
        }
        public bool f_ghquyen_thutamung_nhapbosung(string v_userid)
        {
            return f_ghquyen_thutamung_nhap(v_userid, "4", true);
        }
        private bool f_ghquyen_thanhtoanravien_nhap(string v_userid, string v_id_quyen, bool v_default)
        {
            bool r = v_default;
            try
            {
                r = get_data("select nhap nhap from " + m_db_schemaroot + ".v_ghquyen_phanquyen where loai=4 and userid=" + v_userid + " and id_quyen=" + v_id_quyen + "").Tables[0].Rows[0][0].ToString().Trim() == "1";
            }
            catch
            {
                r = v_default;
            }
            return r;
        }
        public bool f_ghquyen_thanhtoanravien_hoantra(string v_userid)
        {
            return f_ghquyen_thanhtoanravien_nhap(v_userid, "2", true);
        }
        public bool f_ghquyen_thanhtoanravien_sua_ngay_quyenso_sobienlai(string v_userid)
        {
            return f_ghquyen_thanhtoanravien_nhap(v_userid, "3", true);
        }
        public bool f_ghquyen_thanhtoanravien_nhapbosung(string v_userid)
        {
            return f_ghquyen_thanhtoanravien_nhap(v_userid, "4", true);
        }
        public bool f_ghquyen_thanhtoanravien_laylaichiphi(string v_userid)
        {
            return f_ghquyen_thanhtoanravien_nhap(v_userid, "5", true);
        }
        public bool f_ghquyen_thanhtoanravien_tonghoplaineukhoachuachuyen(string v_userid)
        {
            return f_ghquyen_thanhtoanravien_nhap(v_userid, "6", true);
        }
        public bool f_ghquyen_thanhtoanravien_tutonghoplaineukhoachuachuyen(string v_userid)
        {
            return f_ghquyen_thanhtoanravien_nhap(v_userid, "7", true);
        }
        private bool f_ghquyen_hoantra_nhap(string v_userid, string v_id_quyen, bool v_default)
        {
            bool r = v_default;
            try
            {
                r = get_data("select nhap from " + m_db_schemaroot + ".v_ghquyen_phanquyen where loai=5 and userid=" + v_userid + " and id_quyen=" + v_id_quyen + "").Tables[0].Rows[0][0].ToString().Trim() == "1";
            }
            catch
            {
                r = v_default;
            }
            return r;
        }
        public bool f_ghquyen_hoantra_xoa(string v_userid)
        {
            return f_ghquyen_hoantra_nhap(v_userid, "2", true);
        }
        #endregion GIỚI HẠN QUYỀN MENU TẮT

        #region KẾT XUẤT EXCEL

        public string f_export_excel(DataSet v_ds, string v_file)
        {
            try
            {
                if (v_file.ToLower().IndexOf(".xls") != v_file.Length - 4)
                {
                    v_file = v_file + ".xls";
                }
                System.IO.StreamWriter sw = new System.IO.StreamWriter(v_file, false, System.Text.Encoding.UTF8);
                string astr = "";
                astr = "<Table>";
                astr = astr + "<tr>";
                for (int i = 0; i < v_ds.Tables[0].Columns.Count; i++)
                {
                    astr = astr + "<th>";
                    astr = astr + v_ds.Tables[0].Columns[i].ColumnName;
                    astr = astr + "</th>";
                }
                astr = astr + "</tr>";
                sw.Write(astr);
                for (int i = 0; i < v_ds.Tables[0].Rows.Count; i++)
                {
                    astr = "<tr>";
                    for (int j = 0; j < v_ds.Tables[0].Columns.Count; j++)
                    {
                        astr = astr + "<td>";
                        astr = astr + v_ds.Tables[0].Rows[i][j].ToString();
                        astr = astr + "</td>";
                    }
                    astr = astr + "</tr>";
                    sw.Write(astr);
                }
                astr = "</Table>";
                sw.Write(astr);
                sw.Close();
                return v_file;
            }
            catch
            {
                return "";
            }
        }
        public string f_export_excel(DataSet v_ds, string v_file, string v_field, string v_caption, string v_title, string v_ghichu)
        {
            try
            {
                if (v_file.ToLower().IndexOf(".xls") != v_file.Length - 4)
                {
                    v_file = v_file + ".xls";
                }
                System.IO.StreamWriter sw = new System.IO.StreamWriter(v_file, false, System.Text.Encoding.UTF8);
                string astr = "";
                astr = "<Table>";
                foreach (string atmp in v_title.Split(','))
                {
                    astr = astr + "<tr>";
                    astr = astr + "<th colspan=\"" + v_caption.Split(',').Length.ToString() + "\" style=\"font-family: Tahoma; font-weight: bold\" valign=\"middle\" align=\"center\">";
                    astr = astr + atmp.Trim();
                    astr = astr + "</th>";
                    astr = astr + "</tr>";
                }
                foreach (string atmp in v_ghichu.Split(','))
                {
                    astr = astr + "<tr>";
                    astr = astr + "<th colspan=\"" + v_caption.Split(',').Length.ToString() + "\" style=\"font-family: Tahoma; font-weight: bold\" valign=\"middle\" align=\"left\">";
                    astr = astr + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + atmp.Trim();
                    astr = astr + "</th>";
                    astr = astr + "</tr>";
                }
                sw.Write(astr);

                astr = "<tr>";
                int aindex = 0;
                foreach (string atmp in v_field.Split(','))
                {
                    for (int i = 0; i < v_ds.Tables[0].Columns.Count; i++)
                    {
                        if (v_ds.Tables[0].Columns[i].ColumnName.ToLower() == atmp)
                        {
                            astr = astr + "<th>";
                            astr = astr + v_caption.Split(',')[aindex].Trim();
                            astr = astr + "</th>";
                            aindex++;
                        }
                    }
                }
                astr = astr + "</tr>";
                sw.Write(astr);
                for (int i = 0; i < v_ds.Tables[0].Rows.Count; i++)
                {
                    astr = "<tr>";
                    foreach (string atmp in v_field.Split(','))
                    {
                        for (int j = 0; j < v_ds.Tables[0].Columns.Count; j++)
                        {
                            if (v_ds.Tables[0].Columns[j].ColumnName.ToLower() == atmp)
                            {
                                astr = astr + "<td>";
                                astr = astr + v_ds.Tables[0].Rows[i][j].ToString();
                                astr = astr + "</td>";
                            }
                        }
                    }
                    astr = astr + "</tr>";
                    sw.Write(astr);
                }
                astr = "</Table>";
                sw.Write(astr);
                sw.Close();
                return v_file;
            }
            catch
            {
                return "";
            }
        }
        public void f_kill_excel()
        {
            Process[] processes = Process.GetProcesses();

            if (processes.Length > 1)
            {
                int i = 0;
                for (int n = 0; n <= processes.Length - 1; n++)
                {
                    if (((Process)processes[n]).ProcessName == "EXCEL")
                    {
                        i++;
                        ((Process)processes[n]).Kill();
                    }
                }
            }
        }
        public void f_format_excel(string v_file)
        {
            try
            {
                //using Excel
                /*
                int be=3,dong=5,sodong=m_ds.Tables[0].Rows.Count+5,socot=ds.Tables[0].Columns.Count-2,dongke=sodong-1;
                tenfile=d.Export_Excel(m_ds,"bcsudung");
                oxl=new Excel.Application();
                owb=(Excel._Workbook)(oxl.Workbooks.Open(tenfile,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value));
                osheet=(Excel._Worksheet)owb.ActiveSheet;
                oxl.ActiveWindow.DisplayGridlines=true;
                osheet.get_Range(d.getIndex(0)+"1",d.getIndex(0)+"1").EntireColumn.Delete(Missing.Value);
                for(int i=0;i<be;i++) osheet.get_Range(d.getIndex(i)+"1",d.getIndex(i)+"1").EntireRow.Insert(Missing.Value);
                osheet.get_Range(d.getIndex(be)+dong.ToString(),d.getIndex(socot+1)+sodong.ToString()).NumberFormat="#,##0.0";
                osheet.get_Range(d.getIndex(0)+"4",d.getIndex(socot)+dongke.ToString()).Borders.LineStyle=XlBorderWeight.xlHairline;
                for(int i=1;i<dong;i++) osheet.Cells[dong-1,i]=get_ten(i-1);
                orange=osheet.get_Range(d.getIndex(0)+"1",d.getIndex(socot)+sodong.ToString());
                orange.Font.Name="Arial";
                orange.Font.Size=8;
                orange.EntireColumn.AutoFit();
                oxl.ActiveWindow.DisplayZeros=false;
                osheet.PageSetup.Orientation=XlPageOrientation.xlLandscape;
                osheet.PageSetup.PaperSize=XlPaperSize.xlPaperA4;
                osheet.PageSetup.LeftMargin=20;
                osheet.PageSetup.RightMargin=20;
                osheet.PageSetup.TopMargin=30;
                osheet.PageSetup.CenterFooter="Trang : &P/&N";
                osheet.Cells[1,2]=d.Syte;osheet.Cells[2,2]=d.Tenbv;
                s_mmyy=tu.Value.ToString().PadLeft(2,'0')+yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
                s_tu=tu.Value.ToString().PadLeft(2,'0');
                s_den=den.Value.ToString().PadLeft(2,'0');
                s_yy=yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
                if(chkTra.Checked==false) osheet.Cells[1,4]="BÁO CÁO SỬ DỤNG";
                else osheet.Cells[1,4]="BÁO CÁO HOÀN TRẢ";
                string s_title=(tu.Value==den.Value)?"Tháng : "+s_tu+"/"+yyyy.Value.ToString():"Từ tháng :"+s_tu+"/"+yyyy.Value.ToString()+" đến tháng :"+s_den+"/"+yyyy.Value.ToString();
                if(optthang.Checked==false)s_title=(tun.Text==denn.Text)?"Ngày "+tun.Text:"Từ ngày "+tun.Text+" đến ngày "+denn.Text;
                if(noingoai.SelectedIndex>=0)s_title+=" ("+noingoai.Text+")";
                if(s_tennhom!="")s_title+=" ("+s_tennhom+")";
                osheet.Cells[2,4]=s_title;
                orange=osheet.get_Range(d.getIndex(3)+"1",d.getIndex(socot-1)+"2");
                orange.HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
                orange.Font.Size=12;
                orange.Font.Bold=true;
                osheet.Cells[dong-1,dtkp.Rows.Count+5]="Tổng cộng";
                //
                osheet.Cells[dong-1,dtkp.Rows.Count+6]="Đơng giá";
                osheet.Cells[dong-1,dtkp.Rows.Count+7]="Tổng tiền";
                osheet.Cells[dong-1,dtkp.Rows.Count+8]="Tổng trả";
                //
                for(int i=0;i<dtkp.Rows.Count;i++)
                    osheet.Cells[dong-1,i+5]=dtkp.Rows[i]["ten"].ToString();
                orange=osheet.get_Range(d.getIndex(4)+"5",d.getIndex(socot+1)+sodong.ToString());				
                orange.ColumnWidth=4;
                //				
                orange=osheet.get_Range(d.getIndex(4)+"4",d.getIndex(m_ds.Tables[0].Columns.Count+8)+"4");
                orange.Font.Name="Arial";
                orange.Font.Size=8;			
                orange.WrapText=false;
                orange.Orientation=90;
                orange.RowHeight=70;

                if (print) osheet.PrintOut(Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value);
                else oxl.Visible=true;
                */
            }
            catch
            {
            }
        }

        #endregion

        #region TÙY CHỌN
        public string Mabv
        {
            get
            {
                string art = "";
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load("..\\..\\..\\xml\\maincode.xml");
                    XmlNodeList nodeLst = doc.GetElementsByTagName("Mabv");
                    art = (nodeLst.Item(0).InnerText == "") ? "701.1.01" : nodeLst.Item(0).InnerText;
                }
                catch
                {
                    art = "";
                }
                return art;
            }
        }
        public string Tenbv
        {
            get
            {
                string art = "";
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load("..\\..\\..\\xml\\maincode.xml");
                    XmlNodeList nodeLst = doc.GetElementsByTagName("Tenbv");
                    art = nodeLst.Item(0).InnerText;
                }
                catch
                {
                    art = "";
                }
                return art;
            }
        }
        public string Syte
        {
            get
            {
                string art = "";
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load("..\\..\\..\\xml\\maincode.xml");
                    XmlNodeList nodeLst = doc.GetElementsByTagName("Syte");
                    art = nodeLst.Item(0).InnerText;
                }
                catch
                {
                    art = "";
                }
                return art;
            }
        }
        public string Dienthoai
        {
            get
            {
                string art = "";
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load("..\\..\\..\\xml\\maincode.xml");
                    XmlNodeList nodeLst = doc.GetElementsByTagName("Dienthoai");
                    art = nodeLst.Item(0).InnerText;
                }
                catch
                {
                    art = "";
                }
                return art;
            }
        }
        public DataSet Tqx(string s)
        {
            return get_data("select a.tentt||' - '||b.tenquan||' - '||c.tenpxa as TEN,c.MAPHUONGXA,c.VIETTAT from " + s_schemaroot + ".btdtt a," + s_schemaroot + ".btdquan b," + s_schemaroot + ".btdpxa c where a.matt=b.matt and b.maqu=c.maqu and upper(c.viettat) like '" + s.Trim().ToUpper() + "%'" + " order by c.maphuongxa");
        }
        public int get_maphu(string sothe)
        {
            if (sothe.Trim().Length > 13) return (get_ma16.IndexOf(sothe.Trim().Substring(4, 2)) == -1) ? 0 : 1;
            else return (get_ma13.IndexOf(sothe.Trim().Substring(4, 1)) == -1) ? 0 : 1;
        }
        private string get_ma13 { get { return get_data("select ten from " + s_schemaroot + ".thongso where id=49").Tables[0].Rows[0][0].ToString(); } }
        private string get_ma16 { get { return get_data("select ten from " + s_schemaroot + ".thongso where id=50").Tables[0].Rows[0][0].ToString(); } }
        private string f_mavp(string s, int so)
        {
            DataSet m_ds = new DataSet();
            try
            {
                if (!System.IO.File.Exists("..\\..\\..\\xml\\v_khongdau.xml"))
                {
                    upd_v_khongdau();
                    m_ds = f_get_v_khongdau();
                    m_ds.WriteXml("..\\..\\..\\xml\\v_khongdau.xml", XmlWriteMode.WriteSchema);
                    //System.IO.File.Copy("..\\..\\..\\xml\\khongdau.xml","..\\..\\..\\xml\\v_khongdau.xml",false);
                }
            }
            catch
            {
            }
            m_ds = new DataSet();
            m_ds.ReadXml("..\\..\\..\\xml\\v_khongdau.xml");
            string s1 = s.Trim().ToUpper(), s2 = "";
            DataRow r;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i].ToString() != " ")
                {
                    try
                    {
                        r = m_ds.Tables[0].Select("codau='" + s1[i].ToString() + "'")[0];
                    }
                    catch
                    {
                        r = null;
                    }
                    if (r != null) s2 += r[1].ToString();
                    else s2 += s1[i];
                }
                if (s2.Length == so) break;
            }
            return s2;
        }
        public string f_get_mavp(string s)
        {
            string ret = "", s1 = f_mavp(s, 3);
            try
            {
                int i = int.Parse(get_data("select max(substr(ma,4)) from " + s_schemaroot + ".v_giavp where substr(ma,1,3)='" + s1.ToUpper() + "'").Tables[0].Rows[0][0].ToString()) + 1;
                ret = s1 + i.ToString().PadLeft(3, '0');
            }
            catch { ret = s1 + "001"; }
            return ret;
        }
        public void f_reset_mavp()
        {
            try
            {
                execute_data("update " + s_schemaroot + ".v_giavp set ma=''");
                DataSet ads = get_data("select trim(to_char(id,999999)) id, trim(ten) ten from " + s_schemaroot + ".v_giavp order by ten asc,id asc");
                for (int i = 0; i < ads.Tables[0].Rows.Count; i++)
                {
                    try
                    {
                        execute_data("update " + s_schemaroot + ".v_giavp set ma='" + f_get_mavp(ads.Tables[0].Rows[i]["ten"].ToString().Trim()) + "' where id=" + ads.Tables[0].Rows[i]["id"].ToString() + "");
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }

        public string f_ngaykhoaso(string v_userid)
        {
            string art = "";
            try
            {
                art = get_data("select ngay from medibv.v_khoaso where userid=" + v_userid).Tables[0].Rows[0][0].ToString();
            }
            catch
            {
            }
            return art;
        }
        #endregion TÙY CHỌN

        #region TÌM KIẾM
        public DataSet v_find_bienlaithuvienphi(DateTime v_tu, DateTime v_den, string v_mabn, string v_hoten, string v_namsinh, string v_diachi, string v_ngaythu, string v_nguoithu, string v_quyenso, string v_sobienlai, string v_tuso, string v_denso, string v_loaibn, string v_loaibl)
        {
            try
            {
                string sql1 = "", sql2 = "", sql3 = "";
                // truc tiep
                sql1 = "select a.id, decode(aa.id,null,0,1) huy, c.mabn, c.hoten, nvl(to_char(c.ngaysinh,'dd/mm/yyyy'),c.namsinh) namsinh, to_char(a.ngay,'dd/mm/yyyy')||' '||to_char(a.ngayud,'hh24:mi') ngay, d.sohieu quyenso, d.id quyensoid, a.sobienlai, d.sohieu||' - '||to_char(a.sobienlai) sochungtu, sum(nvl(b.soluong,0)*nvl(b.dongia,0)-nvl(b.thieu,0))- nvl(f.sotien,sum(nvl(b.mien,0))) sotien, e.hoten tennguoithu, c.sonha,c.thon,i.tenpxa xa,h.tenquan quan, g.tentt tinh, a.userid, '1' loaihd, a.loaibn, a.loai ";
                sql1 += "from v_vienphill a, v_hoantra aa, v_vienphict b, btdbn c, v_quyenso d, v_dlogin e, v_mienngtru f, btdtt g, btdquan h, btdpxa i ";
                sql1 += "where (a.id=b.id(+)) ";
                sql1 += "and (a.id=f.id(+)) ";
                sql1 += "and (a.quyenso=aa.quyenso(+) and a.sobienlai=aa.sobienlai(+)) ";
                sql1 += "and (a.mabn=c.mabn(+)) ";
                sql1 += "and (a.quyenso=d.id(+)) ";
                sql1 += "and (a.userid=e.id(+)) ";
                sql1 += "and (c.matt=g.matt(+))";
                sql1 += "and (c.maqu=h.maqu(+))";
                sql1 += "and (c.maphuongxa=i.maphuongxa(+)) ";
                if (v_mabn.Trim() != "")
                {
                    sql1 += "and (trim(c.mabn) like '%'||trim(:v_mabn)||'%') ";
                }
                if (v_hoten.Trim() != "")
                {
                    sql1 += "and (trim(c.hoten) like '%'||trim(:v_hoten)||'%') ";
                }
                if (v_diachi.Trim() != "")
                {
                    sql1 += "and (upper(trim(c.sonha)) like '%'||upper(trim(:v_diachi))||'%' ";
                    sql1 += "or upper(trim(c.thon)) like '%'||upper(trim(:v_diachi))||'%' ";
                    sql1 += "or upper(trim(i.tenpxa)) like '%'||upper(trim(:v_diachi))||'%' ";
                    sql1 += "or upper(trim(h.tenquan)) like '%'||upper(trim(:v_diachi))||'%' ";
                    sql1 += "or upper(trim(g.tentt)) like '%'||upper(trim(:v_diachi))||'%') ";
                }

                if (v_namsinh.Trim() != "")
                {
                    sql1 += "and (trim(c.namsinh) like '%'||trim(:v_namsinh)||'%') ";
                    sql1 += "and (to_char(c.ngaysinh,'dd/mm/yyyy hh24:mi') like '%'||:v_namsinh||'%' or c.ngaysinh is null) ";
                }
                if (v_ngaythu.Trim() != "")
                {
                    sql1 += "and (to_char(a.ngay,'dd/mm/yyyy hh24:mi') like '%'||:v_ngaythu||'%') ";
                }
                if (v_nguoithu.Trim() != "")
                {
                    sql1 += "and (trim(e.hoten) like '%'||trim(:v_nguoithu)||'%') ";
                }
                if (v_quyenso.Trim() != "")
                {
                    sql1 += "and (trim(d.sohieu) like '%'||trim(:v_quyenso)||'%') ";
                }
                if (v_sobienlai.Trim() != "")
                {
                    sql1 += "and (to_char(a.sobienlai) like '%'||trim(:v_sobienlai)||'%') ";
                }
                if (v_tuso.Trim() != "")
                {
                    sql1 += "and (a.sobienlai>=to_number(:v_tuso)) ";
                }
                if (v_denso.Trim() != "")
                {
                    sql1 += "and (a.sobienlai<=to_number(:v_denso)) ";
                }
                sql1 += "group by a.id, decode(aa.id,null,0,1), c.mabn, c.hoten, nvl(to_char(c.ngaysinh,'dd/mm/yyyy'),c.namsinh), to_char(a.ngay,'dd/mm/yyyy')||' '||to_char(a.ngayud,'hh24:mi'), d.sohieu, d.id, a.sobienlai, d.sohieu||' - '||to_char(a.sobienlai), f.sotien, e.hoten, c.sonha,c.thon,i.tenpxa,h.tenquan,g.tentt, a.userid, a.loai,a.loaibn";

                //Tam ung

                sql2 = "select a.id, decode(aa.id,null,0,1) huy, c.mabn, c.hoten, nvl(to_char(c.ngaysinh,'dd/mm/yyyy'),c.namsinh) namsinh, to_char(a.ngay,'dd/mm/yyyy')||' '||to_char(a.ngayud,'hh24:mi') ngay, d.sohieu quyenso, d.id quyensoid, a.sobienlai, d.sohieu||' - '||to_char(a.sobienlai) sochungtu, a.sotien, e.hoten tennguoithu, c.sonha,c.thon,i.tenpxa xa,h.tenquan quan, g.tentt tinh, a.userid, '2' loaihd, a.loaibn, a.loai ";
                sql2 += "from v_tamung a, v_hoantra aa, btdbn c, v_quyenso d, v_dlogin e, btdtt g, btdquan h, btdpxa i ";
                sql2 += "where (a.mabn=c.mabn(+)) ";
                sql2 += "and (a.quyenso=d.id(+)) ";
                sql2 += "and (a.quyenso=aa.quyenso(+) and a.sobienlai=aa.sobienlai(+)) ";
                sql2 += "and (a.userid=e.id(+)) ";
                sql2 += "and (c.matt=g.matt(+)) ";
                sql2 += "and (c.maqu=h.maqu(+)) ";
                sql2 += "and (c.maphuongxa=i.maphuongxa(+)) ";

                if (v_mabn.Trim() != "")
                {
                    sql2 += "and (trim(c.mabn) like '%'||trim(:v_mabn)||'%') ";
                }
                if (v_hoten.Trim() != "")
                {
                    sql2 += "and (trim(c.hoten) like '%'||trim(:v_hoten)||'%') ";
                }
                if (v_diachi.Trim() != "")
                {
                    sql2 += "and (upper(trim(c.sonha)) like '%'||upper(trim(:v_diachi))||'%' ";
                    sql2 += "or upper(trim(c.thon)) like '%'||upper(trim(:v_diachi))||'%' ";
                    sql2 += "or upper(trim(i.tenpxa)) like '%'||upper(trim(:v_diachi))||'%' ";
                    sql2 += "or upper(trim(h.tenquan)) like '%'||upper(trim(:v_diachi))||'%' ";
                    sql2 += "or upper(trim(g.tentt)) like '%'||upper(trim(:v_diachi))||'%') ";
                }

                if (v_namsinh.Trim() != "")
                {
                    sql2 += "and (trim(c.namsinh) like '%'||trim(:v_namsinh)||'%') ";
                    sql2 += "and (to_char(c.ngaysinh,'dd/mm/yyyy hh24:mi') like '%'||:v_namsinh||'%' or c.ngaysinh is null) ";
                }
                if (v_ngaythu.Trim() != "")
                {
                    sql2 += "and (to_char(a.ngay,'dd/mm/yyyy hh24:mi') like '%'||:v_ngaythu||'%') ";
                }
                if (v_nguoithu.Trim() != "")
                {
                    sql2 += "and (trim(e.hoten) like '%'||trim(:v_nguoithu)||'%') ";
                }
                if (v_quyenso.Trim() != "")
                {
                    sql2 += "and (trim(d.sohieu) like '%'||trim(:v_quyenso)||'%') ";
                }
                if (v_sobienlai.Trim() != "")
                {
                    sql2 += "and (to_char(a.sobienlai) like '%'||:v_sobienlai||'%') ";
                }
                if (v_tuso.Trim() != "")
                {
                    sql2 += "and (a.sobienlai>=to_number(:v_tuso)) ";
                }
                if (v_denso.Trim() != "")
                {
                    sql2 += "and (a.sobienlai<=to_number(:v_denso));";
                }

                //Thanh toán ra viện
                sql3 = "select a.id, decode(aa.id,null,0,1) huy, c.mabn, c.hoten, nvl(to_char(c.ngaysinh,'dd/mm/yyyy'),c.namsinh) namsinh, to_char(b.ngay,'dd/mm/yyyy')||' '||to_char(b.ngayud,'hh24:mi') ngay, d.sohieu quyenso, d.id quyensoid, b.sobienlai, d.sohieu||' - '||to_char(b.sobienlai) sochungtu, b.sotien, e.hoten tennguoithu, c.sonha,c.thon,i.tenpxa xa,h.tenquan quan, g.tentt tinh, b.userid, '3' loaihd, b.loaibn, b.loai ";
                sql3 += "from v_ttrvds a, v_hoantra aa, v_ttrvll b, btdbn c, v_quyenso d, v_dlogin e, btdtt g, btdquan h, btdpxa i ";
                sql3 += "where (a.id=b.id(+)) ";
                sql3 += "and (a.mabn=c.mabn(+)) ";
                sql3 += "and (b.quyenso=d.id(+)) ";
                sql3 += "and (b.quyenso=aa.quyenso(+) and b.sobienlai=aa.sobienlai(+)) ";
                sql3 += "and (b.userid=e.id(+)) ";
                sql3 += "and (c.matt=g.matt(+)) ";
                sql3 += "and (c.maqu=h.maqu(+)) ";
                sql3 += "and (c.maphuongxa=i.maphuongxa(+)) ";

                if (v_mabn.Trim() != "")
                {
                    sql3 += "and (trim(c.mabn) like '%'||trim(:v_mabn)||'%') ";
                }
                if (v_hoten.Trim() != "")
                {
                    sql3 += "and (trim(c.hoten) like '%'||trim(:v_hoten)||'%') ";
                }
                if (v_diachi.Trim() != "")
                {
                    sql3 += "and (upper(trim(c.sonha)) like '%'||upper(trim(:v_diachi))||'%' ";
                    sql3 += "or upper(trim(c.thon)) like '%'||upper(trim(:v_diachi))||'%' ";
                    sql3 += "or upper(trim(i.tenpxa)) like '%'||upper(trim(:v_diachi))||'%' ";
                    sql3 += "or upper(trim(h.tenquan)) like '%'||upper(trim(:v_diachi))||'%' ";
                    sql3 += "or upper(trim(g.tentt)) like '%'||upper(trim(:v_diachi))||'%') ";
                }
                if (v_namsinh.Trim() != "")
                {
                    sql3 += "and (trim(c.namsinh) like '%'||trim(:v_namsinh)||'%') ";
                    sql3 += "and (to_char(c.ngaysinh,'dd/mm/yyyy hh24:mi') like '%'||:v_namsinh||'%' or c.ngaysinh is null) ";
                }
                if (v_ngaythu.Trim() != "")
                {
                    sql3 += "and (to_char(b.ngay,'dd/mm/yyyy hh24:mi') like '%'||:v_ngaythu||'%') ";
                }
                if (v_nguoithu.Trim() != "")
                {
                    sql3 += "and (trim(e.hoten) like '%'||trim(:v_nguoithu)||'%') ";
                }
                if (v_quyenso.Trim() != "")
                {
                    sql3 += "and (trim(d.sohieu) like '%'||trim(:v_quyenso)||'%') ";
                }
                if (v_sobienlai.Trim() != "")
                {
                    sql3 += "and (to_char(b.sobienlai) like '%'||:v_sobienlai||'%') ";
                }
                if (v_tuso.Trim() != "")
                {
                    sql3 += "and (b.sobienlai>=to_number(:v_tuso)) ";
                }
                if (v_denso.Trim() != "")
                {
                    sql3 += "and (b.sobienlai<=to_number(:v_denso))";
                }

                switch (v_loaibl)
                {
                    case "1":
                        m_sql = sql1.Trim();
                        break;
                    case "2":
                        m_sql = sql2.Trim();
                        break;
                    case "3":
                        m_sql = sql3.Trim();
                        break;
                    case "0":
                    default:
                        m_sql = sql1.Trim() + " union all " + sql2.Trim() + " union all " + sql3.Trim();
                        break;
                }

                m_connection = new NpgsqlConnection(m_db_connectionstring);
                m_connection.Open();
                m_command = new NpgsqlCommand(m_sql, m_connection);
                m_command.CommandType = CommandType.Text;

                if (v_mabn.Trim() != "")
                {
                    m_command.Parameters.Add("v_mabn", NpgsqlDbType.Text, 8).Value = v_mabn;
                }
                if (v_hoten.Trim() != "")
                {
                    m_command.Parameters.Add("v_hoten", NpgsqlDbType.Text, 100).Value = v_hoten;
                }
                if (v_namsinh.Trim() != "")
                {
                    m_command.Parameters.Add("v_namsinh", NpgsqlDbType.Text, 20).Value = v_namsinh;
                }
                if (v_diachi.Trim() != "")
                {
                    m_command.Parameters.Add("v_diachi", NpgsqlDbType.Text, 200).Value = v_diachi;
                }
                if (v_ngaythu.Trim() != "")
                {
                    m_command.Parameters.Add("v_ngaythu", NpgsqlDbType.Text, 20).Value = v_ngaythu;
                }
                if (v_nguoithu.Trim() != "")
                {
                    m_command.Parameters.Add("v_nguoithu", NpgsqlDbType.Text, 100).Value = v_nguoithu;
                }
                if (v_quyenso.Trim() != "")
                {
                    m_command.Parameters.Add("v_quyenso", NpgsqlDbType.Text, 100).Value = v_quyenso;
                }
                if (v_sobienlai.Trim() != "")
                {
                    m_command.Parameters.Add("v_sobienlai", NpgsqlDbType.Text, 10).Value = v_sobienlai;
                }
                if (v_tuso.Trim() != "")
                {
                    m_command.Parameters.Add("v_tuso", NpgsqlDbType.Text, 10).Value = v_tuso;
                }
                if (v_denso.Trim() != "")
                {
                    m_command.Parameters.Add("v_denso", NpgsqlDbType.Text, 10).Value = v_denso;
                }
                m_dataadapter = new NpgsqlDataAdapter(m_command);
                m_ds = new DataSet();
                m_dataadapter.Fill(m_ds);
                m_command.Dispose();
                m_connection.Dispose();
            }
            catch (NpgsqlException ex)
            {
                upd_v_error(ex.Message.ToString().Trim(), m_computername, "v_find_bienlaivienphi");
            }
            return m_ds;
        }
        public DataSet v_find_benhnhan(string v_mabn1, string v_mabn2, string v_hoten, string v_namsinh, string v_gioitinh, string v_diachi, string v_mabhyt, string v_dienthoai, string v_email)
        {
            try
            {
                m_sql = "select a.mabn, a.hoten, nvl(to_char(a.ngaysinh,'dd/mm/yyyy'),a.namsinh) ngaysinh, b.ten phai, trim(f.sothe) mabhyt, to_char(f.denngay,'dd/mm/yyyy') denngay, trim(a.sonha) sonha, trim(a.thon) thon, trim(c.tenpxa) xa, trim(d.tenquan) quan, trim(e.tentt) tinh, g.nha, g.coquan, g.didong, g.email,'' ngay,'' makp,'' tenkp ";
                m_sql += "from btdbn a, dmphai b, btdpxa c, btdquan d, btdtt e, bhyt f, dienthoai g ";
                m_sql += "where (a.phai=b.ma(+)) ";
                m_sql += "and (a.mabn=g.mabn(+)) ";
                m_sql += "and (a.mabn=f.mabn(+)) ";
                m_sql += "and (a.maphuongxa=c.maphuongxa(+)) ";
                m_sql += "and (a.maqu=d.maqu(+)) ";
                m_sql += "and (a.matt=e.matt(+)) ";
                if (v_mabn1.Trim() != "")
                {
                    m_sql += "and (substr(trim(a.mabn),1,2) like '%'||trim(:v_mabn1)||'%') ";
                }
                if (v_mabn2.Trim() != "")
                {
                    m_sql += "and (substr(trim(a.mabn),3) like '%'||trim(:v_mabn2)||'%') ";
                }
                if (v_mabhyt.Trim() != "")
                {
                    m_sql += "and (trim(f.sothe) like '%'||trim(:v_mabhyt)||'%') ";
                }
                if (v_hoten.Trim() != "")
                {
                    m_sql += "and (trim(a.hoten) like '%'||trim(:v_hoten)||'%') ";
                }
                if (v_namsinh.Trim() != "")
                {
                    m_sql += "and (trim(a.namsinh) like '%'||trim(:v_namsinh)||'%') ";
                    m_sql += "and (to_char(a.ngaysinh,'dd/mm/yyyy hh24:mi') like '%'||:v_namsinh||'%' or a.ngaysinh is null) ";
                }
                if (v_gioitinh.Trim() != "")
                {
                    m_sql += "and (to_char(a.phai) like '%'||trim(:v_gioitinh)||'%') ";
                }
                if (v_dienthoai.Trim() != "")
                {
                    m_sql += "and (trim(g.nha) like '%'||trim(:v_dienthoai)||'%' or trim(g.coquan) like '%'||trim(:v_dienthoai)||'%' or trim(g.didong) like '%'||trim(:v_dienthoai)||'%') ";
                }
                if (v_email.Trim() != "")
                {
                    m_sql += "and (trim(g.email) like '%'||trim(:v_email)||'%') ";
                }
                if (v_diachi.Trim() != "")
                {
                    m_sql += "and (upper(trim(a.sonha)) like '%'||upper(trim(:v_diachi))||'%' ";
                    m_sql += "or upper(trim(a.thon)) like '%'||upper(trim(:v_diachi))||'%' ";
                    m_sql += "or upper(trim(c.tenpxa)) like '%'||upper(trim(:v_diachi))||'%' ";
                    m_sql += "or upper(trim(d.tenquan)) like '%'||upper(trim(:v_diachi))||'%' ";
                    m_sql += "or upper(trim(e.tentt)) like '%'||upper(trim(:v_diachi))||'%') ";
                }
                m_sql += "group by a.mabn, a.hoten, nvl(to_char(a.ngaysinh,'dd/mm/yyyy'),a.namsinh), b.ten, trim(f.sothe), to_char(f.denngay,'dd/mm/yyyy'), trim(a.sonha), trim(a.thon), trim(c.tenpxa), trim(d.tenquan), trim(e.tentt),g.nha,g.coquan,g.didong,g.email";

                m_connection = new NpgsqlConnection(m_db_connectionstring);
                m_connection.Open();
                m_command = new NpgsqlCommand(m_sql, m_connection);
                m_command.CommandType = CommandType.Text;

                if (v_mabn1.Trim() != "")
                {
                    m_command.Parameters.Add("v_mabn1", NpgsqlDbType.Text, 2).Value = v_mabn1;
                }
                if (v_mabn2.Trim() != "")
                {
                    m_command.Parameters.Add("v_mabn2", NpgsqlDbType.Text, 6).Value = v_mabn2;
                }
                if (v_hoten.Trim() != "")
                {
                    m_command.Parameters.Add("v_hoten", NpgsqlDbType.Text, 100).Value = v_hoten;
                }
                if (v_namsinh.Trim() != "")
                {
                    m_command.Parameters.Add("v_namsinh", NpgsqlDbType.Text, 20).Value = v_namsinh;
                }
                if (v_gioitinh.Trim() != "")
                {
                    m_command.Parameters.Add("v_gioitinh", NpgsqlDbType.Text, 2).Value = v_gioitinh;
                }
                if (v_diachi.Trim() != "")
                {
                    m_command.Parameters.Add("v_diachi", NpgsqlDbType.Text, 200).Value = v_diachi;
                }
                if (v_mabhyt.Trim() != "")
                {
                    m_command.Parameters.Add("v_mabhyt", NpgsqlDbType.Text, 20).Value = v_mabhyt;
                }
                if (v_dienthoai.Trim() != "")
                {
                    m_command.Parameters.Add("v_dienthoai", NpgsqlDbType.Text, 20).Value = v_dienthoai;
                }
                if (v_email.Trim() != "")
                {
                    m_command.Parameters.Add("v_email", NpgsqlDbType.Text, 50).Value = v_email;
                }

                m_dataadapter = new NpgsqlDataAdapter(m_command);
                m_ds = new DataSet();
                m_dataadapter.Fill(m_ds);
                m_command.Dispose();
                m_connection.Dispose();
            }
            catch (NpgsqlException ex)
            {
                upd_v_error(ex.Message.ToString().Trim(), m_computername, "v_find_benhnhan");
            }
            return m_ds;
        }
        public DataSet v_find_hiendien()
        {
            m_sql = "select a.mabn, a.hoten, nvl(to_char(a.ngaysinh,'dd/mm/yyyy'),a.namsinh) ngaysinh, b.ten phai, trim(f.sothe) mabhyt, to_char(f.denngay,'dd/mm/yyyy') denngay, trim(a.sonha) sonha, trim(a.thon) thon, trim(c.tenpxa) xa, trim(d.tenquan) quan, trim(e.tentt) tinh, g.nha, g.coquan, g.didong, g.email, to_char(h.ngay,'dd/mm/yyyy hh24:mi') ngay, i.makp, i.tenkp ";
            m_sql += "from btdbn a, dmphai b, btdpxa c, btdquan d, btdtt e, bhyt f, dienthoai g, hiendien h, btdkp_bv i ";
            m_sql += "where (a.phai=b.ma(+)) ";
            m_sql += "and (a.mabn=g.mabn(+)) ";
            m_sql += "and (a.mabn=f.mabn(+)) ";
            m_sql += "and (a.maphuongxa=c.maphuongxa(+)) ";
            m_sql += "and (a.maqu=d.maqu(+)) ";
            m_sql += "and (a.matt=e.matt(+)) ";
            m_sql += "and (h.makp=i.makp(+)) ";
            m_sql += "and (a.mabn=h.mabn and h.nhapkhoa=1 and h.xuatkhoa=0) ";
            m_sql += "group by a.mabn, a.hoten, nvl(to_char(a.ngaysinh,'dd/mm/yyyy'),a.namsinh), b.ten, trim(f.sothe), to_char(f.denngay,'dd/mm/yyyy'), trim(a.sonha), trim(a.thon), trim(c.tenpxa), trim(d.tenquan), trim(e.tentt),g.nha,g.coquan,g.didong,g.email,to_char(h.ngay,'dd/mm/yyyy hh24:mi'), i.makp, i.tenkp";
            return get_data(m_sql);
        }
        public DataSet v_find_viettat(string v_matat)
        {
            try
            {
                m_sql = "select trim(matat) matat, trim(daydu) daydu from " + s_schemaroot + ".btdvt";
                if (v_matat.Trim() != "")
                {
                    m_sql += " where lower(trim(matat))=lower(trim(:v_matat))";
                }
                m_connection = new NpgsqlConnection(m_db_connectionstring);
                m_connection.Open();
                m_command = new NpgsqlCommand(m_sql, m_connection);
                m_command.CommandType = CommandType.Text;

                if (v_matat.Trim() != "")
                {
                    m_command.Parameters.Add("v_matat", NpgsqlDbType.Text, 30).Value = v_matat;
                }

                m_dataadapter = new NpgsqlDataAdapter(m_command);
                m_ds = new DataSet();
                m_dataadapter.Fill(m_ds);
                m_command.Dispose();
                m_connection.Dispose();
            }
            catch (NpgsqlException ex)
            {
                upd_v_error(ex.Message.ToString().Trim(), m_computername, "?");
            }
            return m_ds;
        }
        public string v_viettat(string v_matat)
        {
            string r = "";
            try
            {
                m_sql = "select trim(matat) matat, trim(daydu) daydu from " + s_schemaroot + ".btdvt";
                if (v_matat.Trim() != "")
                {
                    m_sql += " where lower(trim(matat))=lower(trim(:v_matat))";
                }
                m_connection = new NpgsqlConnection(m_db_connectionstring);
                m_connection.Open();
                m_command = new NpgsqlCommand(m_sql, m_connection);
                m_command.CommandType = CommandType.Text;

                if (v_matat.Trim() != "")
                {
                    m_command.Parameters.Add("v_matat", NpgsqlDbType.Text, 30).Value = v_matat;
                }

                m_dataadapter = new NpgsqlDataAdapter(m_command);
                m_ds = new DataSet();
                m_dataadapter.Fill(m_ds);
                r = m_ds.Tables[0].Rows[0]["daydu"].ToString();
                m_command.Dispose();
                m_connection.Dispose();
            }
            catch (NpgsqlException ex)
            {
                upd_v_error(ex.Message.ToString().Trim(), m_computername, "?");
            }
            return r;
        }
        public DataSet v_find_daydu(string v_daydu)
        {
            try
            {
                m_sql = "select trim(matat) matat, trim(daydu) daydu from " + s_schemaroot + ".btdvt ";
                if (v_daydu.Trim() != "")
                {
                    m_sql += "where lower(trim(daydu))=lower(trim(:v_daydu))";
                }

                m_connection = new NpgsqlConnection(m_db_connectionstring);
                m_connection.Open();
                m_command = new NpgsqlCommand(m_sql, m_connection);
                m_command.CommandType = CommandType.Text;

                if (v_daydu.Trim() != "")
                {
                    m_command.Parameters.Add("v_daydu", NpgsqlDbType.Text, 100).Value = v_daydu;
                }

                m_dataadapter = new NpgsqlDataAdapter(m_command);
                m_ds = new DataSet();
                m_dataadapter.Fill(m_ds);
                m_command.Dispose();
                m_connection.Dispose();
            }
            catch (NpgsqlException ex)
            {
                upd_v_error(ex.Message.ToString().Trim(), m_computername, "?");
            }
            return m_ds;
        }
        public string v_daydu(string v_daydu)
        {
            string r = "";
            try
            {
                m_sql = "select trim(matat) matat, trim(daydu) daydu from " + s_schemaroot + ".btdvt";
                if (v_daydu.Trim() != "")
                {
                    m_sql += " where lower(trim(daydu))=lower(trim(:v_daydu))";
                }

                m_connection = new NpgsqlConnection(m_db_connectionstring);
                m_connection.Open();
                m_command = new NpgsqlCommand(m_sql, m_connection);
                m_command.CommandType = CommandType.Text;

                if (v_daydu.Trim() != "")
                {
                    m_command.Parameters.Add("v_daydu", NpgsqlDbType.Text, 100).Value = v_daydu;
                }

                m_dataadapter = new NpgsqlDataAdapter(m_command);
                m_ds = new DataSet();
                m_dataadapter.Fill(m_ds);
                r = m_ds.Tables[0].Rows[0]["matat"].ToString();
                m_command.Dispose();
                m_connection.Dispose();
            }
            catch (NpgsqlException ex)
            {
                upd_v_error(ex.Message.ToString().Trim(), m_computername, "?");
            }
            return r;
        }
        public bool v_kiemtrauserid(string v_userid)
        {
            bool r = false;
            try
            {
                m_sql = "select id from " + s_schemaroot + ".v_dlogin ";
                if (v_userid.Trim() != "")
                {
                    m_sql += "where lower(trim(userid))=lower(trim(:v_userid))";
                }

                m_connection = new NpgsqlConnection(m_db_connectionstring);
                m_connection.Open();
                m_command = new NpgsqlCommand(m_sql, m_connection);
                m_command.CommandType = CommandType.Text;

                if (v_userid.Trim() != "")
                {
                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Text, 100).Value = v_userid;
                }

                m_dataadapter = new NpgsqlDataAdapter(m_command);
                m_ds = new DataSet();
                m_dataadapter.Fill(m_ds);
                m_command.Dispose();
                m_connection.Dispose();
                r = m_ds.Tables[0].Rows.Count > 0;
            }
            catch (NpgsqlException ex)
            {
                upd_v_error(ex.Message.ToString().Trim(), m_computername, "kiemtrauserid");
            }
            return r;
        }
        #endregion

        #region DELETE DATA TABLE
        public bool del_v_viettat(string v_ma)
        {
            bool art = false;
            try
            {
                execute_data("delete from " + s_schemaroot + ".v_viettat where ma='" + v_ma.Replace("'", "''") + "' and readonly!=1");
                art = (get_data("select id from " + s_schemaroot + ".v_viettat where ma='" + v_ma.Replace("'", "''") + "'").Tables[0].Rows.Count == 0);
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_v_viettat()
        {
            bool art = false;
            try
            {
                execute_data("delete from " + s_schemaroot + ".v_viettat where readonly!=1");
                art = (get_data("select id from " + s_schemaroot + ".v_viettat").Tables[0].Rows.Count == 0);
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_v_treebaocao(string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_v_treebaocao(v_id) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".v_treebaocao where id=" + v_id);
                    art = (get_data("select id from " + s_schemaroot + ".v_treebaocao where id=" + v_id).Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_v_dlogin(string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_v_dlogin(v_id) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".v_dlogin where id=" + v_id);
                    art = (get_data("select id from " + s_schemaroot + ".v_dlogin where id=" + v_id).Tables[0].Rows.Count == 0);
                    if (art)
                    {
                        execute_data("delete from " + s_schemaroot + ".v_phanquyen where userid=" + v_id);
                    }
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_v_nhomdlogin(string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_v_nhomdlogin(v_id) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".v_nhomdlogin where id=" + v_id + " and id not in (select disctinct id_nhom from " + s_schemaroot + ".v_dlogin where id_nhom = " + v_id + ")");
                    art = (get_data("select id from " + s_schemaroot + ".v_nhomdlogin where id=" + v_id).Tables[0].Rows.Count == 0);
                    if (art)
                    {
                        execute_data("delete from " + s_schemaroot + ".v_phanquyennhom where id_nhom=" + v_id);
                    }
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public void del_v_phanquyen(string v_userid)
        {
            execute_data("delete from " + s_schemaroot + ".v_phanquyen where userid=" + v_userid);
        }
        public void del_v_phanquyennhom(string v_id_nhom)
        {
            execute_data("delete from " + s_schemaroot + ".v_phanquyennhom where id_nhom=" + v_id_nhom);
        }
        public void copy_treebaocao(string v_id_copy, string v_id_cha_dest)
        {
            try
            {
                decimal aid = get_id_v_treebaocao, astt = get_stt_v_treebaocao(v_id_cha_dest);
                execute_data("insert into " + s_schemaroot + ".v_treebaocao(id,id_cha,stt,ten,asql,tenreport,readonly) select " + aid.ToString() + "," + v_id_cha_dest + "," + astt.ToString() + ",ten,asql,tenreport,readonly from " + s_schemaroot + ".v_treebaocao where id=" + v_id_copy + "");
            }
            catch
            {
            }
        }
        public void copy_phanquyen(string v_id_copy, string v_loai_copy, string v_id_dest, string v_loai_dest)
        {
            try
            {
                if (v_loai_dest == "U")
                {
                    execute_data("delete from " + s_schemaroot + ".v_phanquyen where userid=" + v_id_dest + " and userid <>" + v_id_copy);
                }
                else
                {
                    execute_data("delete from " + s_schemaroot + ".v_phanquyennhom where id_nhom=" + v_id_dest + " and id_nhom <>" + v_id_copy);
                }
                if (v_loai_dest == "N")
                {
                    if (v_loai_copy == "U")
                    {
                        execute_data("insert into " + s_schemaroot + ".v_phanquyennhom(id_nhom,menuname,chon,chitiet) select " + v_id_dest.ToString() + ",menuname,chon,chitiet from " + s_schemaroot + ".v_phanquyen where userid=" + v_id_copy + "");
                    }
                    else
                    {
                        execute_data("insert into " + s_schemaroot + ".v_phanquyennhom(id_nhom,menuname,chon,chitiet) select " + v_id_dest.ToString() + ",menuname,chon,chitiet from " + s_schemaroot + ".v_phanquyennhom where id_nhom=" + v_id_copy + "");
                    }
                }
                else
                {
                    if (v_loai_copy == "U")
                    {
                        execute_data("insert into " + s_schemaroot + ".v_phanquyen(userid,menuname,chon,chitiet,id_bv_so) select " + v_id_dest.ToString() + ",menuname,chon,chitiet,id_bv_so from " + s_schemaroot + ".v_phanquyen where userid=" + v_id_copy + "");
                    }
                    else
                    {
                        execute_data("insert into " + s_schemaroot + ".v_phanquyen(userid,menuname,chon,chitiet,id_bv_so) select " + v_id_dest.ToString() + ",menuname,chon,chitiet,id_bv_so from " + s_schemaroot + ".v_phanquyennhom where id_nhom=" + v_id_copy + "");
                    }
                }
            }
            catch
            {
            }
        }
        public bool del_v_dsduyet(string v_ma)
        {
            bool art = false;
            try
            {
                if (dadung_v_dsduyet(v_ma) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".v_dsduyet where ma=" + v_ma.Replace("'", "''") + "");
                    art = (get_data("select ma from " + s_schemaroot + ".v_dsduyet where ma=" + v_ma.Replace("'", "''") + "").Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_v_lydomien(string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_v_lydomien(v_id) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".v_lydomien where id=" + v_id + "");
                    art = (get_data("select id from " + s_schemaroot + ".v_lydomien where id=" + v_id + "").Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_v_dmlydonopthem(string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_v_dmlydonopthem(v_id) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".v_dmlydonopthem where id=" + v_id + "");
                    art = (get_data("select id from " + s_schemaroot + ".v_dmlydonopthem where id=" + v_id + "").Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_v_dmlydothieu(string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_v_dmlydothieu(v_id) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".v_dmlydothieu where id=" + v_id + "");
                    art = (get_data("select id from " + s_schemaroot + ".v_dmlydothieu where id=" + v_id + "").Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_v_loaibn(string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_v_loaibn(v_id) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".v_loaibn where id=" + v_id + "");
                    art = (get_data("select id from " + s_schemaroot + ".v_loaibn where id=" + v_id + "").Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_v_tenloaivp(string v_ma)
        {
            bool art = false;
            try
            {
                if (dadung_v_dsduyet(v_ma) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".v_tenloaivp where ma=" + v_ma + "");
                    art = (get_data("select ma from " + s_schemaroot + ".v_tenloaivp where ma=" + v_ma + "").Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_v_nhombhyt(string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_v_nhombhyt(v_id) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".v_nhombhyt where id=" + v_id + "");
                    art = (get_data("select id from " + s_schemaroot + ".v_nhombhyt where id=" + v_id + "").Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_v_nhomvp(string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_v_nhomvp(v_id) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".v_nhomvp where ma=" + v_id + "");
                    art = (get_data("select ma from " + s_schemaroot + ".v_nhomvp where ma=" + v_id + "").Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_v_loaivp(string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_v_loaivp(v_id) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".v_loaivp where id=" + v_id + "");
                    art = (get_data("select id from " + s_schemaroot + ".v_loaivp where id=" + v_id + "").Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_v_giavp(string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_v_giavp(v_id) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".v_giavp where id=" + v_id + "");
                    art = (get_data("select id from " + s_schemaroot + ".v_giavp where id=" + v_id + "").Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_v_error()
        {
            bool art = false;
            try
            {
                execute_data("delete from " + s_schemaroot + ".v_error");
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    execute_data("delete from " + r["schemaname"].ToString() + ".v_error");
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_v_quyenso(string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_v_quyenso(v_id) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".v_quyenso where id=" + v_id + "");
                    art = (get_data("select id from " + s_schemaroot + ".v_quyenso where id=" + v_id + "").Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_v_vienphill(string v_mmyy, string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_v_vienphill(v_mmyy, v_id) == 0)
                {
                    execute_data_mmyy(v_mmyy, "delete from medibvmmyy.v_vienphict where lanin=0 and id=" + v_id + "");
                    execute_data_mmyy(v_mmyy, "delete from medibvmmyy.v_mienngtru where id=" + v_id + "");
                    execute_data_mmyy(v_mmyy, "delete from medibvmmyy.v_vienphill where lanin=0 and id=" + v_id + "");
                    art = (get_data("select id from medibvmmyy.v_vienphill where id=" + v_id + "").Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_v_ttrvll(string v_mmyy, string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_v_ttrvll(v_mmyy, v_id) == 0)
                {
                    execute_data_mmyy(v_mmyy, "delete from medibvmmyy.v_ttrvct where id=" + v_id + "");
                    execute_data_mmyy(v_mmyy, "delete from medibvmmyy.v_ttrvbhyt where id=" + v_id + "");
                    execute_data_mmyy(v_mmyy, "delete from medibvmmyy.v_ttrvnhom where id=" + v_id + "");
                    execute_data_mmyy(v_mmyy, "delete from medibvmmyy.v_ttrvpttt where id=" + v_id + "");
                    execute_data_mmyy(v_mmyy, "delete from medibvmmyy.v_ttrvptttct where id=" + v_id + "");
                    execute_data_mmyy(v_mmyy, "update medibvmmyy.v_thvpll set done = 0 where id in (select idtonghop from medibvmmyy.v_ttrvll where lanin=0 and id=" + v_id + ")");
                    execute_data_mmyy(v_mmyy, "delete from medibvmmyy.v_miennoitru where id=" + v_id + "");
                    execute_data_mmyy(v_mmyy, "delete from medibvmmyy.v_ttrvll where lanin=0 and id=" + v_id + "");
                    execute_data_mmyy(v_mmyy, "delete from medibvmmyy.v_ttrvds where id=" + v_id + "");
                    art = (get_data("select id from medibvmmyy.v_ttrvll where id=" + v_id + "").Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_v_tamung(string v_mmyy, string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_v_tamung(v_mmyy, v_id) == 0)
                {
                    execute_data_mmyy(v_mmyy, "delete from medibvmmyy.v_tamung where lanin=0 and id=" + v_id + "");
                    execute_data_mmyy(v_mmyy, "delete from medibvmmyy.v_tamungct where id=" + v_id + "");
                    art = (get_data("select id from medibvmmyy.v_tamung where id=" + v_id + "").Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_bhytkb(string v_mmyy, string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_bhytkb(v_mmyy, v_id) == 0)
                {
                    execute_data_mmyy(v_mmyy, "update medibvmmyy.bhytkb set done=0 where id=" + v_id + "");
                    art = (get_data("select id from medibvmmyy.bhytkb where done!=0 and id=" + v_id + "").Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        #endregion

        #region GET DATA TABLE
        public DataSet f_get_v_error()
        {
            try
            {
                DataSet ads = null, adst = null;
                string asql = "";
                asql = "select message, computer,tables, to_char(ngayud,'dd/mm/yyyy hh24:mi') as ngayud,'' as blank from " + s_schemaroot + ".v_error order by ngayud desc";
                ads = get_data(asql);

                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    asql = "select message, computer,'" + r["schemaname"].ToString() + ".' || tables as tables, to_char(ngayud,'dd/mm/yyyy hh24:mi') as ngayud,'' as blank from " + r["schemaname"].ToString() + ".v_error order by ngayud desc";
                    adst = get_data(asql);
                    if (ads == null)
                    {
                        if (adst != null)
                        {
                            ads = adst;
                        }
                    }
                    else
                    {
                        if (adst != null)
                        {
                            ads.Merge(adst);
                        }
                    }
                }
                return ads;
            }
            catch
            {
                return null;
            }
        }
        public DataSet f_get_v_khongdau()
        {
            string asql = "";
            asql = "select codau,khongdau from " + s_schemaroot + ".v_khongdau order by codau";
            return get_data(asql);
        }
        public DataSet f_get_dmcomputer()
        {
            string asql = "select a.id, a.computer,'' as ip, '' as status, to_char(a.ngayud,'dd/mm/yyyy hh24:mi') as ngayud from " + s_schemaroot + ".dmcomputer a order by a.computer";
            return get_data(asql);
        }
        public DataSet f_get_v_dmcapnhat_frmMedisoftcenterupdate()
        {
            try
            {
                DataSet ads = new DataSet();
                ads.Tables.Add("Table");
                ads.Tables[0].Columns.Add("id", typeof(Decimal));
                ads.Tables[0].Columns.Add("chon", typeof(Decimal));
                ads.Tables[0].Columns.Add("ten");
                ads.Tables[0].Columns.Add("status");
                DataRow r;

                r = ads.Tables[0].NewRow();
                r["id"] = 1;
                r["chon"] = 0;
                r["ten"] = "Danh mục xét nghiệm";
                r["status"] = "OK";
                ads.Tables[0].Rows.Add(r.ItemArray);

                r = ads.Tables[0].NewRow();
                r["id"] = 2;
                r["chon"] = 0;
                r["ten"] = "Danh mục vi trùng";
                r["status"] = "OK";
                ads.Tables[0].Rows.Add(r.ItemArray);

                r = ads.Tables[0].NewRow();
                r["id"] = 3;
                r["chon"] = 0;
                r["ten"] = "Danh mục mẫu bệnh phẩm";
                r["status"] = "OK";
                ads.Tables[0].Rows.Add(r.ItemArray);

                r = ads.Tables[0].NewRow();
                r["id"] = 4;
                r["chon"] = 0;
                r["ten"] = "Danh mục vị trí lấy mẫu trên cơ thể";
                r["status"] = "OK";
                ads.Tables[0].Rows.Add(r.ItemArray);

                r = ads.Tables[0].NewRow();
                r["id"] = 5;
                r["chon"] = 0;
                r["ten"] = "Danh mục kháng sinh";
                r["status"] = "OK";
                ads.Tables[0].Rows.Add(r.ItemArray);

                r = ads.Tables[0].NewRow();
                r["id"] = 6;
                r["chon"] = 0;
                r["ten"] = "Danh mục vị trí lấy mẫu trên cơ thể";
                r["status"] = "OK";
                ads.Tables[0].Rows.Add(r.ItemArray);

                r = ads.Tables[0].NewRow();
                r["id"] = 7;
                r["chon"] = 0;
                r["ten"] = "Bộ kháng sinh tương ứng với từng loại vi trùng";
                r["status"] = "OK";
                ads.Tables[0].Rows.Add(r.ItemArray);

                r = ads.Tables[0].NewRow();
                r["id"] = 8;
                r["chon"] = 0;
                r["ten"] = "Bộ kháng mẫu thử theo xét nghiệm";
                r["status"] = "OK";
                ads.Tables[0].Rows.Add(r.ItemArray);

                r = ads.Tables[0].NewRow();
                r["id"] = 9;
                r["chon"] = 0;
                r["ten"] = "Bộ hoá chất định mức theo xét nghiệm";
                r["status"] = "OK";
                ads.Tables[0].Rows.Add(r.ItemArray);

                r = ads.Tables[0].NewRow();
                r["id"] = 10;
                r["chon"] = 0;
                r["ten"] = "Danh mục đơn vị đo";
                r["status"] = "OK";
                ads.Tables[0].Rows.Add(r.ItemArray);

                r = ads.Tables[0].NewRow();
                r["id"] = 11;
                r["chon"] = 0;
                r["ten"] = "Danh mục đơn vị đo (HL7)";
                r["status"] = "OK";
                ads.Tables[0].Rows.Add(r.ItemArray);

                r = ads.Tables[0].NewRow();
                r["id"] = 12;
                r["chon"] = 0;
                r["ten"] = "Bộ từ điển viết tắt kết quả xét nghiệm";
                r["status"] = "OK";
                ads.Tables[0].Rows.Add(r.ItemArray);

                r = ads.Tables[0].NewRow();
                r["id"] = 13;
                r["chon"] = 0;
                r["ten"] = "Bộ từ điển viết tắt";
                r["status"] = "OK";
                ads.Tables[0].Rows.Add(r.ItemArray);

                return ads;
            }
            catch
            {
                return null;
            }
        }
        public DataSet f_get_v_phanquyen(string v_userid)
        {
            string auserid = "";

            try
            {
                auserid = int.Parse(v_userid).ToString();
            }
            catch
            {
                auserid = "-99999";
            }
            return get_data("select userid,menuname,chon,chitiet from " + s_schemaroot + ".v_phanquyen where userid=" + auserid);
        }
        public DataSet f_get_v_phanquyennhom(string v_id_nhom)
        {
            string aid = "";

            try
            {
                aid = int.Parse(v_id_nhom).ToString();
            }
            catch
            {
                aid = "-99999";
            }
            return get_data("select id_nhom,menuname,chon,chitiet from " + s_schemaroot + ".v_phanquyennhom where id_nhom=" + aid);
        }
        public DataSet f_get_v_nhomdlogin(string v_id, string v_nhom, string v_ma, string v_ten, string v_diengiai)
        {
            string asql = "", aexp = "";
            v_ma = v_ma.Replace("'", "''");
            v_ten = v_ten.Replace("'", "''");
            v_diengiai = v_diengiai.Replace("'", "''");
            asql = "select a.id,a.nhom,a.ma,a.ten,a.diengiai,a.id_bv_so,a.right_,a.readonly,'' as blank from " + s_schemaroot + ".v_nhomdlogin a";
            if (v_id != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id=" + v_id;
            }
            if (v_nhom != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.nhom=" + v_nhom + "";
            }
            if (v_ma != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.ma='" + v_ma.Replace("'", "''") + "'";
            }
            if (v_ten != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.ten='" + v_ten.Replace("'", "''") + "'";
            }
            if (v_diengiai != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.diengiai='" + v_diengiai.Replace("'", "''") + "'";
            }

            if (aexp != "")
            {
                aexp = " where " + aexp;
            }
            asql += aexp;
            asql += " order by a.ten";
            return get_data(asql);
        }
        public DataSet f_get_v_dlogin(string v_id, string v_id_nhom, string v_hoten, string v_userid, string v_password_)
        {
            string asql = "", aexp = "";
            asql = "select a.id,a.id_nhom,a.hoten,a.userid,a.password_,right_,loaivp,'' as blank from " + s_schemaroot + ".v_dlogin a";
            if (v_id != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id=" + v_id;
            }
            if (v_id_nhom != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id_nhom=" + v_id_nhom;
            }
            if (v_hoten != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.hoten='" + v_hoten + "'";
            }
            if (v_userid != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.userid='" + v_userid + "'";
            }
            if (v_password_ != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.password_='" + v_password_ + "'";
            }

            if (aexp != "")
            {
                aexp = " where " + aexp;
            }
            asql += aexp;
            asql += " order by a.hoten";
            return get_data(asql);
        }
        public DataSet f_get_v_viettat()
        {
            string asql = "select a.stt, a.ma, a.ten,a.readonly from " + s_schemaroot + ".v_viettat a order by a.stt";
            return get_data(asql);
        }
        public DataSet f_get_v_treebaocao(string v_id, string v_id_cha, string v_stt, string v_ten, string v_asql, string v_tenreport, string v_readonly)
        {
            string asql = "", aexp = "";
            asql = "select a.id,a.id_cha,a.stt,a.ten,a.asql,a.tenreport,a.readonly from " + s_schemaroot + ".v_treebaocao a";
            if (v_id != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id=" + v_id;
            }
            if (v_id_cha != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id_cha=" + v_id_cha;
            }
            if (v_stt != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.stt=" + v_stt;
            }
            if (v_ten != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.ten='" + v_ten.Replace("'", "''") + "'";
            }
            if (v_asql != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.asql='" + v_asql.Replace("'", "''") + "'";
            }
            if (v_tenreport != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.tenreport='" + v_tenreport.Replace("'", "''") + "'";
            }
            if (v_readonly != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.readonly=" + v_readonly + "";
            }

            if (aexp != "")
            {
                aexp = " where " + aexp;
            }
            asql += aexp;
            asql += " order by a.stt,a.ten";
            return get_data(asql);
        }
        public decimal get_stt_v_treebaocao(string v_id_cha)
        {
            decimal art = 1;
            try
            {
                decimal i = 0;
                DataSet ads = get_data("select distinct stt from " + s_schemaroot + ".v_treebaocao where id_cha=" + v_id_cha + " order by stt asc");
                while (i < 999999999999)
                {
                    i = i + 1;
                    if (ads.Tables[0].Select("stt=" + i.ToString()).Length <= 0)
                    {
                        break;
                    }
                }
                art = decimal.Parse(i.ToString());
            }
            catch
            {
                art = 1;
            }
            return art;
        }
        public DataSet f_get_v_dsduyet(string v_ma, string v_ten, string v_readonly)
        {
            string asql = "", aexp = "";
            asql = "select a.ma,a.ten,to_char(a.ngayud,'dd/mm/yyyy hh24:mi') as ngayud,a.readonly,'' as blank from " + s_schemaroot + ".v_dsduyet a";
            if (v_ma != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.ma=" + v_ma.Replace("'", "''") + "";
            }
            if (v_ten != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.ten='" + v_ten.Replace("'", "''") + "'";
            }
            if (v_readonly != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.readonly=" + v_readonly + "";
            }

            if (aexp != "")
            {
                aexp = " where " + aexp;
            }
            asql += aexp;
            asql += " order by a.ten";
            return get_data(asql);
        }
        public DataSet f_get_v_lydomien(string v_id, string v_ten, string v_readonly)
        {
            string asql = "", aexp = "";
            asql = "select a.id,a.ten,to_char(a.ngayud,'dd/mm/yyyy hh24:mi') as ngayud,a.readonly,'' as blank from " + s_schemaroot + ".v_lydomien a";
            if (v_id != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id=" + v_id;
            }
            if (v_ten != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.ten='" + v_ten.Replace("'", "''") + "'";
            }
            if (v_readonly != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.readonly=" + v_readonly + "";
            }

            if (aexp != "")
            {
                aexp = " where " + aexp;
            }
            asql += aexp;
            asql += " order by a.ten";
            return get_data(asql);
        }
        public DataSet f_get_v_dmlydonopthem(string v_id, string v_ten, string v_readonly)
        {
            string asql = "", aexp = "";
            asql = "select a.id,a.ten,to_char(a.ngayud,'dd/mm/yyyy hh24:mi') as ngayud,a.readonly,'' as blank from " + s_schemaroot + ".v_dmlydonopthem a";
            if (v_id != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id=" + v_id;
            }
            if (v_ten != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.ten='" + v_ten.Replace("'", "''") + "'";
            }
            if (v_readonly != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.readonly=" + v_readonly + "";
            }

            if (aexp != "")
            {
                aexp = " where " + aexp;
            }
            asql += aexp;
            asql += " order by a.ten";
            return get_data(asql);
        }
        public DataSet f_get_v_dmlydothieu(string v_id, string v_ten, string v_readonly)
        {
            string asql = "", aexp = "";
            asql = "select a.id,a.ten,to_char(a.ngayud,'dd/mm/yyyy hh24:mi') as ngayud,a.readonly,'' as blank from " + s_schemaroot + ".v_dmlydothieu a";
            if (v_id != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id=" + v_id;
            }
            if (v_ten != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.ten='" + v_ten.Replace("'", "''") + "'";
            }
            if (v_readonly != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.readonly=" + v_readonly + "";
            }

            if (aexp != "")
            {
                aexp = " where " + aexp;
            }
            asql += aexp;
            asql += " order by a.ten";
            return get_data(asql);
        }
        public DataSet f_get_v_loaibn(string v_id, string v_ten, string v_readonly)
        {
            string asql = "", aexp = "";
            asql = "select a.id,a.ten,to_char(a.ngayud,'dd/mm/yyyy hh24:mi') as ngayud,a.readonly,'' as blank from " + s_schemaroot + ".v_loaibn a";
            if (v_id != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id=" + v_id;
            }
            if (v_ten != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.ten='" + v_ten.Replace("'", "''") + "'";
            }
            if (v_readonly != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.readonly=" + v_readonly + "";
            }

            if (aexp != "")
            {
                aexp = " where " + aexp;
            }
            asql += aexp;
            asql += " order by a.id";
            return get_data(asql);
        }
        public DataSet f_get_v_tenloaivp(string v_ma, string v_ten, string v_readonly)
        {
            string asql = "", aexp = "";
            asql = "select a.ma,a.ten,to_char(a.ngayud,'dd/mm/yyyy hh24:mi') as ngayud,a.readonly,'' as blank from " + s_schemaroot + ".v_tenloaivp a";
            if (v_ma != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.ma=" + v_ma;
            }
            if (v_ten != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.ten='" + v_ten.Replace("'", "''") + "'";
            }
            if (v_readonly != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.readonly=" + v_readonly + "";
            }

            if (aexp != "")
            {
                aexp = " where " + aexp;
            }
            asql += aexp;
            asql += " order by a.ten";
            return get_data(asql);
        }
        public DataSet f_get_v_nhombhyt(string v_id, string v_stt, string v_ten, string v_viettat, string v_readonly)
        {
            string asql = "", aexp = "";
            asql = "select a.id,a.stt,a.ten,a.viettat, to_char(a.ngayud,'dd/mm/yyyy hh24:mi') as ngayud,a.readonly,'' as blank from " + s_schemaroot + ".v_nhombhyt a";
            if (v_id != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id=" + v_id;
            }
            if (v_stt != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.stt=" + v_stt;
            }
            if (v_ten != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.ten='" + v_ten.Replace("'", "''") + "'";
            }
            if (v_viettat != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.viettat='" + v_viettat.Replace("'", "''") + "'";
            }
            if (v_readonly != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.readonly=" + v_readonly + "";
            }

            if (aexp != "")
            {
                aexp = " where " + aexp;
            }
            asql += aexp;
            asql += " order by a.ten";
            return get_data(asql);
        }
        public DataSet f_get_v_nhomvp(string v_ma, string v_id_nhombhyt, string v_stt, string v_ten, string v_matat, string v_viettat, string v_readonly)
        {
            string asql = "", aexp = "";
            asql = "select a.ma,a.idnhombhyt, a.stt,a.matat,a.ten,a.viettat, to_char(a.ngayud,'dd/mm/yyyy hh24:mi') as ngayud,a.readonly,'' as blank from " + s_schemaroot + ".v_nhomvp a";
            if (v_ma != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.ma=" + v_ma;
            }
            if (v_id_nhombhyt != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.idnhombhyt=" + v_id_nhombhyt;
            }
            if (v_stt != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.stt=" + v_stt;
            }
            if (v_ten != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.ten='" + v_ten.Replace("'", "''") + "'";
            }
            if (v_matat != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.matat='" + v_matat.Replace("'", "''") + "'";
            }
            if (v_viettat != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.viettat='" + v_viettat.Replace("'", "''") + "'";
            }
            if (v_readonly != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.readonly=" + v_readonly + "";
            }

            if (aexp != "")
            {
                aexp = " where " + aexp;
            }
            asql += aexp;
            asql += " order by a.ten";
            return get_data(asql);
        }
        public DataSet f_get_v_nhomvp_frmnhomvp()
        {
            string asql = "";
            asql = "select a.ma, a.stt, a.matat, a.ten, a.viettat, case when b.id is null then -999 else b.id end as idnhombhyt, b.ten as ten_nhombhyt, to_char(a.ngayud,'dd/mm/yyyy hh24:mi') as ngayud, a.readonly, '' as blank from " + s_schemaroot + ".v_nhomvp a left join " + s_schemaroot + ".v_nhombhyt b on a.idnhombhyt=b.id order by a.stt, a.ten";
            return get_data(asql);
        }
        public DataSet f_get_v_loaivp(string v_id, string v_id_nhom, string v_stt, string v_ma, string v_ten, string v_viettat, string v_readonly)
        {
            string asql = "", aexp = "";
            asql = "select a.id,a.id_vdt,a.id_nhom,a.stt,a.ma,a.ten,a.viettat,a.computer,to_char(a.ngayud,'dd/mm/yyyy hh24:mi') as ngayud,a.readonly,'' as blank from " + s_schemaroot + ".v_loaivp a";
            if (v_id != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id=" + v_id;
            }
            if (v_id_nhom != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id_nhom=" + v_id;
            }
            if (v_stt != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.stt=" + v_stt;
            }
            if (v_ma != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.ma='" + v_ma.Replace("'", "''") + "'";
            }
            if (v_ten != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.ten='" + v_ten.Replace("'", "''") + "'";
            }
            if (v_viettat != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.viettat='" + v_viettat.Replace("'", "''") + "'";
            }
            if (v_readonly != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.readonly=" + v_readonly + "";
            }

            if (aexp != "")
            {
                aexp = " where " + aexp;
            }
            asql += aexp;
            asql += " order by a.ten";
            return get_data(asql);
        }
        public DataSet f_get_v_loaivp_frmloaivp()
        {
            string asql = "";
            asql = "select a.readonly,a.id,a.id_vdt,a.stt,a.ma,a.ten,a.viettat, a.computer,to_char(a.ngayud,'dd/mm/yyyy hh24:mi') as ngayud, b.ten as ten_nhom, c.ten as ten_nhombhyt,'' as blank, case when b.ma is null then -999 else b.ma end as id_nhom, case when c.id is null then -999 else c.id end as idnhombhyt from " + s_schemaroot + ".v_loaivp a left join " + s_schemaroot + ".v_nhomvp b on a.id_nhom=b.ma left join " + s_schemaroot + ".v_nhombhyt c on b.idnhombhyt=c.id order by a.stt,a.ten";
            return get_data(asql);
        }
        public DataSet f_get_v_giavp(string v_id, string v_id_loai, string v_stt, string v_ma, string v_ten, string v_dvt, string v_readonly)
        {
            string asql = "", aexp = "";
            asql = "select a.id,a.id_loai,a.stt,a.ma,a.ten,a.dvt,to_char(a.ngayud,'dd/mm/yyyy hh24:mi') as ngayud,a.readonly,'' as blank from " + s_schemaroot + ".v_giavp a";
            if (v_id != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id=" + v_id;
            }
            if (v_id_loai != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id_loai=" + v_id;
            }
            if (v_stt != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.stt=" + v_stt;
            }
            if (v_ma != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.ma='" + v_ma.Replace("'", "''") + "'";
            }
            if (v_ten != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.ten='" + v_ten.Replace("'", "''") + "'";
            }
            if (v_dvt != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.dvt='" + v_dvt.Replace("'", "''") + "'";
            }
            if (v_readonly != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.readonly=" + v_readonly + "";
            }

            if (aexp != "")
            {
                aexp = " where " + aexp;
            }
            asql += aexp;
            asql += " order by a.ten";
            return get_data(asql);
        }
        public DataSet f_get_v_nhombhyt_frmgiavp()
        {
            string asql = "";
            asql = "select a.id, a.stt, a.ten from " + s_schemaroot + ".v_nhombhyt a order by a.ten";
            return get_data(asql);
        }
        public DataSet f_get_v_nhomvp_frmgiavp()
        {
            string asql = "";
            asql = "select a.ma, a.stt, a.ten, a.idnhombhyt from " + s_schemaroot + ".v_nhomvp a order by a.ten";
            return get_data(asql);
        }
        public DataSet f_get_v_loaivp_frmgiavp()
        {
            string asql = "";
            asql = "select a.id, a.stt, a.ten, a.id_nhom from " + s_schemaroot + ".v_loaivp a order by a.ten";
            return get_data(asql);
        }
        public DataSet f_get_v_giavp_frmgiavp()
        {
            string asql = "";
            asql = "select a.readonly,a.id,a.stt,a.ma,a.ten,a.dvt,a.gia_th,a.gia_bh,a.gia_dv,a.gia_nn,a.gia_cs,a.vattu_th,a.vattu_bh,a.vattu_dv,a.vattu_nn,a.vattu_cs,case when a.bhyt is null then 0 else a.bhyt end as bhyt,b.ten as ten_loaivp, d.ten as ten_nhomvp,'' as tenloaitrongoi,e.ten as ten_nhombhyt, c.ten as ten_loaibn,case when a.theobs is null then 0 else a.theobs end as theobs, case when a.trongoi is null then 0 else a.trongoi end as trongoi,case when a.chenhlech is null then 0 else a.chenhlech end as chenhlech,case when a.chenhlech is null then 0 else a.chenhlech end as thuong,case when a.ndm is null then 0 else a.ndm end as ndm,a.locthe,to_char(a.ngayud,'dd/mm/yyyy hh24:mi') as ngayud,case when a.loaibn is null then 0 else a.loaibn end as loaibn,a.loaitrongoi,case when b.id is null then -999 else b.id end as id_loai,b.id_nhom,'' as blank from medibv.v_giavp a left join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_loaibn c on a.loaibn=c.id left join medibv.v_nhomvp d on b.id_nhom=d.ma left join medibv.v_nhombhyt e on d.idnhombhyt=e.id order by a.stt,a.ten";
            asql = asql.Replace("medibv.", s_schemaroot + ".");
            return get_data(asql);
        }
        public DataSet f_get_v_loaibn_frmgiavp()
        {
            try
            {
                DataSet ads = new DataSet();
                ads.Tables.Add("Table");
                ads.Tables[0].Columns.Add("id");
                ads.Tables[0].Columns.Add("ten");
                DataRow r;

                r = ads.Tables[0].NewRow();
                r["id"] = "0";
                r["ten"] = "Tất cả";
                ads.Tables[0].Rows.Add(r.ItemArray);

                r = ads.Tables[0].NewRow();
                r["id"] = "1";
                r["ten"] = "Nội trú";
                ads.Tables[0].Rows.Add(r.ItemArray);

                r = ads.Tables[0].NewRow();
                r["id"] = "2";
                r["ten"] = "Ngoại trú";
                ads.Tables[0].Rows.Add(r.ItemArray);
                return ads;
            }
            catch
            {
                return null;
            }
        }
        public DataSet f_get_d_loaikho_frmphannhomduoc()
        {
            string asql = "";
            asql = "select a.id,a.ten,to_char(a.ngayud,'dd/mm/yyyy hh24:mi') as ngayud,'' as blank from medibv.d_loaikho a order by a.ten";
            asql = asql.Replace("medibv.", s_schemaroot + ".");
            return get_data(asql);
        }
        public DataSet f_get_d_dmnhom_frmphannhomduoc()
        {
            string asql = "";
            asql = "select a.id,a.nhom,case when b.ma is null then -999 else b.ma end as nhomvp, b.ten as ten_nhomvp,case when b.ma is null then -999 else b.idnhombhyt end as idnhombhyt,a.stt,a.ten,to_char(a.ngayud,'dd/mm/yyyy hh24:mi') as ngayud,'' as blank from medibv.d_dmnhom a left join medibv.v_nhomvp b on a.nhomvp=b.ma order by a.stt,a.ten";
            asql = asql.Replace("medibv.", s_schemaroot + ".");
            return get_data(asql);
        }
        public DataSet f_get_dmtuoi()
        {
            DataSet ads = new DataSet();
            ads.Tables.Add("Table");
            ads.Tables[0].Columns.Add("id");
            ads.Tables[0].Columns.Add("ten");
            ads.Tables[0].Rows.Add(new string[] { "1", "Tuổi" });
            ads.Tables[0].Rows.Add(new string[] { "2", "Tháng" });
            ads.Tables[0].Rows.Add(new string[] { "3", "Ngày" });
            return ads;
        }
        public void f_set_d_dmnhom_nhomvp_frmphannhomduoc(string v_id_d_dmnhom, string v_id_v_nhomvp)
        {
            execute_data("update " + s_schemaroot + ".d_dmnhom set nhomvp=" + v_id_v_nhomvp + " where id=" + v_id_d_dmnhom);
        }
        #endregion

        #region GET DATA BÁO CÁO
        public DataSet get_data_bc(DateTime v_tn, DateTime v_dn, string v_sql)
        {
            try
            {
                string asql = "", ammyy = "";
                DataSet ads = null, ads1 = null;
                if (v_tn > v_dn)
                {
                    v_tn = v_dn;
                }
                if (v_sql.IndexOf("medibvmmyy.") >= 0)
                {
                    while (int.Parse(v_dn.Year.ToString() + v_dn.Month.ToString().PadLeft(2, '0')) >= int.Parse(v_tn.Year.ToString() + v_tn.Month.ToString().PadLeft(2, '0')))
                    {
                        ammyy = v_dn.Month.ToString().PadLeft(2, '0') + v_dn.Year.ToString().Substring(2);
                        asql = v_sql.Replace("medibvmmyy.", m_db_schemaroot + ammyy + ".");
                        asql = asql.Replace("medibv.", m_db_schemaroot + ".");
                        ads1 = get_data(asql);
                        if (ads1 != null)
                        {
                            if (ads == null)
                            {
                                ads = ads1;
                            }
                            else
                            {
                                ads.Merge(ads1);
                            }
                        }
                        v_dn = v_dn.AddMonths(-1);
                    }
                }
                else
                {
                    asql = v_sql.Replace("medibv.", m_db_schemaroot + ".");
                    ads = get_data(asql);
                }
                return ads;
            }
            catch
            {
                return null;
            }
        }
        public DataSet get_data_bc(DateTime v_tn, DateTime v_dn, string v_sql, bool bkhoangcach)
        {
            try
            {
                string asql = "", ammyy = "";
                DataSet ads = null, ads1 = null;
                if (v_tn > v_dn)
                {
                    v_tn = v_dn;
                }
                if (bkhoangcach) v_dn = v_dn.AddMonths(1);

                if (v_sql.IndexOf("medibvmmyy.") >= 0)
                {
                    while (int.Parse(v_dn.Year.ToString() + v_dn.Month.ToString().PadLeft(2, '0')) >= int.Parse(v_tn.Year.ToString() + v_tn.Month.ToString().PadLeft(2, '0')))
                    {
                        ammyy = v_dn.Month.ToString().PadLeft(2, '0') + v_dn.Year.ToString().Substring(2);
                        asql = v_sql.Replace("medibvmmyy.", m_db_schemaroot + ammyy + ".");
                        asql = asql.Replace("medibv.", m_db_schemaroot + ".");
                        ads1 = get_data(asql);
                        if (ads1 != null)
                        {
                            if (ads == null)
                            {
                                ads = ads1;
                            }
                            else
                            {
                                ads.Merge(ads1);
                            }
                        }
                        v_dn = v_dn.AddMonths(-1);
                    }
                }
                else
                {
                    asql = v_sql.Replace("medibv.", m_db_schemaroot + ".");
                    ads = get_data(asql);
                }
                return ads;
            }
            catch
            {
                return null;
            }
        }
        public DataSet get_data_bc(DateTime v_tn, DateTime v_dn, string v_sql, int v_limit)
        {
            try
            {
                if (v_tn > v_dn)
                {
                    v_tn = v_dn;
                }

                string asql = "", ammyy = "", alimit = "";
                if (v_limit > 0)
                {
                    alimit = " limit " + v_limit.ToString();
                }
                DataSet ads = null, ads1 = null;
                if (v_sql.IndexOf("medibvmmyy.") >= 0)
                {
                    while (v_dn >= v_tn)
                    {
                        ammyy = v_dn.Month.ToString().PadLeft(2, '0') + v_dn.Year.ToString().Substring(2);
                        asql = v_sql.Replace("medibvmmyy.", m_db_schemaroot + ammyy + ".");
                        asql = asql.Replace("medibv.", m_db_schemaroot + ".");
                        if (asql.IndexOf("limit") < 0 && alimit != "")
                        {
                            asql += alimit;
                        }
                        ads1 = get_data(asql);
                        if (ads1 != null)
                        {
                            if (ads == null)
                            {
                                ads = ads1;
                            }
                            else
                            {
                                ads.Merge(ads1);
                            }
                            if (ads != null)
                            {
                                if (alimit != "" && ads.Tables[0].Rows.Count >= v_limit)
                                {
                                    return ads;
                                }
                            }
                        }
                        v_dn = v_dn.AddMonths(-1);
                    }
                }
                else
                {
                    asql = v_sql.Replace("medibv.", m_db_schemaroot + ".");
                    if (asql.IndexOf("limit") < 0 && alimit != "")
                    {
                        asql += alimit;
                    }
                    ads = get_data(asql);
                }
                return ads;
            }
            catch
            {
                return null;
            }
        }
        public DataSet get_data_bc_1(string v_tn10, string v_dn10, string v_sql)
        {
            try
            {
                string asql = "", ammyy = "";
                DataSet ads = null, adst = null;
                asql = v_sql;
                if (v_tn10.Length < 10)
                {
                    v_tn10 = s_curdd_mm_yyyy;
                }
                else
                {
                    v_tn10 = v_tn10.Substring(0, 10);
                }
                if (v_dn10.Length < 10)
                {
                    v_dn10 = s_curdd_mm_yyyy;
                }
                else
                {
                    v_dn10 = v_dn10.Substring(0, 10);
                }
                if (v_sql.IndexOf("medibvmmyy.") >= 0)
                {
                    if (v_tn10.Length == 10 && v_dn10.Length == 10)
                    {
                        DateTime atu = f_parse_date(v_tn10);
                        DateTime aden = f_parse_date(v_dn10);
                        atu = atu.AddMonths(-1);
                        aden = aden.AddMonths(1);

                        if (atu > aden)
                        {
                            atu = aden;
                        }

                        while (aden >= atu)
                        {
                            ammyy = aden.Month.ToString().PadLeft(2, '0') + aden.Year.ToString().Substring(2);
                            asql = v_sql.Replace("medibvmmyy.", m_db_schemaroot + "" + ammyy + ".");
                            asql = asql.Replace("medibv.", m_db_schemaroot + ".");
                            if (s_iscreated_mmyy(ammyy))
                            {
                                adst = get_data(asql);
                                if (adst != null)
                                {
                                    if (ads == null)
                                    {
                                        ads = adst;
                                    }
                                    else
                                    {
                                        ads.Merge(adst);
                                    }
                                }
                            }
                            aden = aden.AddMonths(-1);
                        }
                    }
                }
                else
                {
                    asql = v_sql.Replace("medibv.", m_db_schemaroot + ".");
                    ads = get_data(asql);
                }
                return ads;
            }
            catch
            {
                return null;
            }
        }

        public DataSet get_data_bc_1(string v_tn10, string v_dn10, string v_sql, int v_limit)
        {
            try
            {
                string asql = "", ammyy = "", alimit = "";
                if (v_limit > 0)
                {
                    alimit = " limit " + v_limit.ToString();
                }
                DataSet ads = null, adst = null;
                asql = v_sql;
                if (v_tn10.Length < 10)
                {
                    v_tn10 = s_curdd_mm_yyyy;
                }
                else
                {
                    v_tn10 = v_tn10.Substring(0, 10);
                }
                if (v_dn10.Length < 10)
                {
                    v_dn10 = s_curdd_mm_yyyy;
                }
                else
                {
                    v_dn10 = v_dn10.Substring(0, 10);
                }
                if (v_sql.IndexOf("medibvmmyy.") >= 0)
                {
                    if (v_tn10.Length == 10 && v_dn10.Length == 10)
                    {
                        DateTime atu = f_parse_date(v_tn10);
                        DateTime aden = f_parse_date(v_dn10);
                        atu = atu.AddMonths(-1);
                        aden = aden.AddMonths(1);

                        while (aden >= atu)
                        {
                            ammyy = aden.Month.ToString().PadLeft(2, '0') + aden.Year.ToString().Substring(2);
                            asql = v_sql.Replace("medibvmmyy.", m_db_schemaroot + "" + ammyy + ".");
                            asql = asql.Replace("medibv.", m_db_schemaroot + ".");
                            if (asql.IndexOf("limit") < 0 && alimit != "")
                            {
                                asql += alimit;
                            }
                            if (s_iscreated_mmyy(ammyy))
                            {
                                adst = get_data(asql);
                                if (adst != null)
                                {
                                    if (ads == null)
                                    {
                                        ads = adst;
                                    }
                                    else
                                    {
                                        ads.Merge(adst);
                                    }
                                    if (ads != null)
                                    {
                                        if (alimit != "" && ads.Tables[0].Rows.Count >= v_limit)
                                        {
                                            return ads;
                                        }
                                    }
                                }
                            }
                            aden = aden.AddMonths(-1);
                        }
                    }
                }
                else
                {
                    asql = v_sql.Replace("medibv.", m_db_schemaroot + ".");
                    ads = get_data(asql);
                }
                return ads;
            }
            catch
            {
                return null;
            }
        }
        public DataSet get_data_mmyy(string v_mmyy, string v_sql)
        {
            v_sql = v_sql.Replace("medibvmmyy.", m_db_schemaroot + v_mmyy + ".");
            v_sql = v_sql.Replace("medibv.", m_db_schemaroot + ".");
            return get_data(v_sql);
        }
        public DataSet get_data_mmyy(string v_mmyy, string v_sql, int v_limit)
        {
            v_sql = v_sql.Replace("medibvmmyy.", m_db_schemaroot + v_mmyy + ".");
            v_sql = v_sql.Replace("medibv.", m_db_schemaroot + ".");
            if (v_sql.IndexOf("limit") < 0 && v_limit > 0)
            {
                v_sql += " limit " + v_limit.ToString();
            }
            return get_data(v_sql);
        }
        public void execute_data(string v_tn10, string v_dn10, string v_sql)
        {
            try
            {
                string asql = "", ammyy = "";
                asql = v_sql;
                if (v_tn10.Length < 10)
                {
                    v_tn10 = s_curdd_mm_yyyy;
                }
                else
                {
                    v_tn10 = v_tn10.Substring(0, 10);
                }
                if (v_dn10.Length < 10)
                {
                    v_dn10 = s_curdd_mm_yyyy;
                }
                else
                {
                    v_dn10 = v_dn10.Substring(0, 10);
                }

                if (v_sql.IndexOf("medibvmmyy.") >= 0)
                {
                    if (v_tn10.Length == 10 && v_dn10.Length == 10)
                    {
                        DateTime atu = f_parse_date(v_tn10);
                        DateTime aden = f_parse_date(v_dn10);
                        atu = atu.AddMonths(-1);
                        aden = aden.AddMonths(1);

                        while (aden >= atu)
                        {
                            ammyy = aden.Month.ToString().PadLeft(2, '0') + aden.Year.ToString().Substring(2);
                            asql = v_sql.Replace("medibvmmyy.", m_db_schemaroot + "" + ammyy + ".");
                            asql = asql.Replace("medibv.", m_db_schemaroot + ".");
                            if (s_iscreated_mmyy(ammyy))
                            {
                                execute_data(asql);
                            }
                            aden = aden.AddMonths(-1);
                        }
                    }
                }
                else
                {
                    ammyy = s_curmmyy;
                    asql = v_sql.Replace("medibvmmyy.", m_db_schemaroot + "" + ammyy + ".");
                    asql = asql.Replace("medibv.", m_db_schemaroot + ".");
                    execute_data(asql);
                }
            }
            catch
            {
            }
        }
        #endregion

        #region CÁC SỰ KIỆN WINDOWS
        public void f_SetEvent(System.Windows.Forms.Control v_c)
        {
            try
            {
                if (v_c.Controls.Count > 0)
                {
                    foreach (Control c in v_c.Controls)
                    {
                        if (c.Controls.Count > 0)
                        {
                            f_SetEvent(c);
                        }
                        else
                        {
                            c.Leave += new System.EventHandler(this.f_Control_Leave);
                            c.Enter += new System.EventHandler(this.f_Control_Enter);
                        }
                    }
                }
                else
                {
                    v_c.Leave += new System.EventHandler(this.f_Control_Leave);
                    v_c.Enter += new System.EventHandler(this.f_Control_Enter);
                }
            }
            catch
            {
            }
        }
        public void f_SetEvent_Keydown(System.Windows.Forms.Control v_c)
        {
            try
            {
                if (v_c.Controls.Count > 0)
                {
                    foreach (Control c in v_c.Controls)
                    {
                        if (c.Controls.Count > 0)
                        {
                            f_SetEvent_Keydown(c);
                        }
                        else
                        {
                            c.Leave += new System.EventHandler(this.f_Control_Leave);
                            c.Enter += new System.EventHandler(this.f_Control_Enter);
                            c.KeyDown += new System.Windows.Forms.KeyEventHandler(this.f_Control_KeyDown);
                        }
                    }
                }
                else
                {
                    v_c.Leave += new System.EventHandler(this.f_Control_Leave);
                    v_c.Enter += new System.EventHandler(this.f_Control_Enter);
                    v_c.KeyDown += new System.Windows.Forms.KeyEventHandler(this.f_Control_KeyDown);
                }
            }
            catch
            {
            }
        }
        public void f_Control_Enter(object sender, System.EventArgs e)
        {
            try
            {
                System.Windows.Forms.Control c = (System.Windows.Forms.Control)(sender);
                if (c.GetType().ToString() == "System.Windows.Forms.Button")
                {
                    c.ForeColor = Color.Red;
                }
                else
                    if ((c.GetType().ToString() == "System.Windows.Forms.TextBox") || (c.GetType().ToString() == "System.Windows.Forms.MaskedTextBox") || (c.GetType().ToString() == "System.Windows.Forms.ComboBox") || (c.GetType().ToString() == "AsYetUnnamed.MultiColumnListBox") || (c.GetType().ToString() == "System.Windows.Forms.TreeView") || (c.GetType().ToString() == "System.Windows.Forms.DataGrid") || (c.GetType().ToString() == "System.Windows.Forms.DateTimePicker") || (c.GetType().ToString() == "System.Windows.Forms.CheckedListBox") || (c.GetType().ToString() == "System.Windows.Forms.NumericUpDown"))
                    {
                        c.BackColor = Color.LightYellow;
                        if (c.ForeColor != Color.Black)
                        {
                            //c.ForeColor=SystemColors.InfoText;
                        }
                        if (c.GetType().ToString() == "System.Windows.Forms.DataGrid")
                        {
                            System.Windows.Forms.DataGrid c1 = (System.Windows.Forms.DataGrid)(sender);
                            c1.BackgroundColor = Color.LightYellow;
                        }
                        else
                            if (c.GetType().ToString() == "System.Windows.Forms.DataGridView")
                            {
                                System.Windows.Forms.DataGridView c2 = (System.Windows.Forms.DataGridView)(sender);
                                c2.BackgroundColor = Color.LightYellow;
                            }
                            else
                                if (c.GetType().ToString() == "System.Windows.Forms.RichTextBox")
                                {
                                    System.Windows.Forms.RichTextBox c3 = (System.Windows.Forms.RichTextBox)(sender);
                                    c3.BackColor = Color.LightYellow;
                                }
                                else
                                    if (c.GetType().ToString() == "System.Windows.Forms.ComboBox")
                                    {
                                        /*
                                        System.Windows.Forms.ComboBox c1 = (System.Windows.Forms.ComboBox)(sender);
                                        if (c1.SelectedIndex < 0)
                                        {
                                            c1.SelectedIndex = 0;
                                        }
                                        */
                                    }
                    }
            }
            catch
            {
            }
        }
        public void f_Control_Leave(object sender, System.EventArgs e)
        {
            try
            {
                System.Windows.Forms.Control c = (System.Windows.Forms.Control)(sender);
                if (c.GetType().ToString() == "System.Windows.Forms.Button")
                {
                    c.ForeColor = Color.FromArgb(0, 51, 0);
                }
                else
                    if ((c.GetType().ToString() == "System.Windows.Forms.TextBox") || (c.GetType().ToString() == "System.Windows.Forms.MaskedTextBox") || (c.GetType().ToString() == "System.Windows.Forms.ComboBox") || (c.GetType().ToString() == "AsYetUnnamed.MultiColumnListBox") || (c.GetType().ToString() == "System.Windows.Forms.TreeView") || (c.GetType().ToString() == "System.Windows.Forms.DataGrid") || (c.GetType().ToString() == "System.Windows.Forms.DateTimePicker") || (c.GetType().ToString() == "System.Windows.Forms.CheckedListBox") || (c.GetType().ToString() == "System.Windows.Forms.NumericUpDown"))
                    {
                        c.BackColor = Color.White;//GhostWhite;
                        if (c.ForeColor != Color.Red && c.ForeColor != Color.DarkRed)
                        {
                            //c.ForeColor=SystemColors.ControlText;
                        }
                        if (c.GetType().ToString() == "System.Windows.Forms.TreeView")
                        {
                            c.BackColor = Color.MintCream;
                        }
                        else
                            if (c.GetType().ToString() == "System.Windows.Forms.DataGrid")
                            {
                                System.Windows.Forms.DataGrid c1 = (System.Windows.Forms.DataGrid)(sender);
                                c1.BackgroundColor = Color.MintCream;
                            }
                            else
                                if (c.GetType().ToString() == "System.Windows.Forms.DataGridView")
                                {
                                    System.Windows.Forms.DataGridView c2 = (System.Windows.Forms.DataGridView)(sender);
                                    c2.BackgroundColor = Color.MintCream;
                                }
                                else
                                    if (c.GetType().ToString() == "System.Windows.Forms.RichTextBox")
                                    {
                                        System.Windows.Forms.RichTextBox c3 = (System.Windows.Forms.RichTextBox)(sender);
                                        c3.BackColor = Color.White;
                                    }
                    }
            }
            catch
            {
            }
        }
        private void f_Control_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }
        #endregion CÁC SỰ KIỆN WINDOWS

        #region TREEMNU
        public void f_create_treemenu(string v_table)
        {
            execute_data("CREATE TABLE " + m_db_schemaroot + "." + v_table + "(id numeric(5), id_cha numeric(5), stt numeric(5), ten text, sql text, tenfield text, captionfield text, width text, report text,readonly numeric(1) default 0, CONSTRAINT pk_" + v_table + " PRIMARY KEY (id)) WITH OIDS");
            execute_data("ALTER TABLE " + m_db_schemaroot + "." + v_table + " OWNER TO " + m_db_database + "");

            execute_data("CREATE TABLE " + m_db_schemaroot + "." + v_table + "_null(id text, ten text, readonly numeric(1) default 0, CONSTRAINT pk_" + v_table + "_null PRIMARY KEY (id)) WITH OIDS");
            execute_data("ALTER TABLE " + m_db_schemaroot + "." + v_table + "_null OWNER TO " + m_db_database + "");
        }
        public DataSet get_treemenu(string v_table)
        {
            string asql = "select * from medibv." + v_table;
            return get_data(asql);
        }
        public bool reorder_treemenu(string v_table, string v_id, int v_step)
        {
            try
            {
                DataRow r = get_data("select * from medibv." + v_table + " where id=" + v_id + "").Tables[0].Rows[0];
                DataRow r1;
                if (v_step > 0)
                {
                    r1 = get_data("select * from medibv." + v_table + " where id_cha=" + r["id_cha"].ToString() + " and stt>" + r["stt"].ToString() + " order by stt asc").Tables[0].Rows[0];
                }
                else
                {
                    r1 = get_data("select * from medibv." + v_table + " where id_cha=" + r["id_cha"].ToString() + " and stt<" + r["stt"].ToString() + " order by stt desc").Tables[0].Rows[0];
                }
                execute_data("update medibv." + v_table + " set stt=" + r1["stt"].ToString() + " where id=" + r["id"].ToString());
                execute_data("update medibv." + v_table + " set stt=" + r["stt"].ToString() + " where id=" + r1["id"].ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string get_stt_treemenu(string v_table, string v_id_cha)
        {
            try
            {
                if (v_id_cha == "") v_id_cha = "0";
                return get_data("select case when max(stt) is null then 0 else max(stt) end + 1 as stt from medibv." + v_table + " where id_cha=" + v_id_cha + "").Tables[0].Rows[0][0].ToString();
            }
            catch
            {
                return "1";
            }
        }
        public string get_id_treemenu(string v_table)
        {
            try
            {
                return get_data("select case when max(id) is null then 0 else max(id) end + 1 as stt from medibv." + v_table + "").Tables[0].Rows[0][0].ToString();
            }
            catch
            {
                return "1";
            }
        }
        public bool del_treemenu(string v_table, string v_id)
        {
            try
            {
                execute_data("delete from medibv." + v_table + " where id=" + v_id + " and readonly=0");
                return !(get_data("select id from medibv." + v_table + " where id=" + v_id).Tables[0].Rows.Count > 0);
            }
            catch
            {
                return false;
            }
        }
        public bool upd_null(string v_table, string v_id, string v_ten)
        {
            m_sql = "update " + m_db_schemaroot + "." + v_table + "_null set ten=:v_ten where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Text).Value = v_id;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + "." + v_table + "_null(id, ten) values(:v_id, :v_ten)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Text).Value = v_id;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "vp_null");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_treemenu(string v_table, decimal v_id, decimal v_id_cha, decimal v_stt, string v_ten, string v_sql, string v_tenfield, string v_captionfield, string v_width, string v_report, decimal v_readonly)
        {
            m_sql = "update " + m_db_schemaroot + "." + v_table + " set id_cha=:v_id_cha, stt=:v_stt,ten=:v_ten,sql=:v_sql, tenfield=:v_tenfield, captionfield=:v_captionfield, width=:v_width, report=:v_report, readonly=:v_readonly where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_id_cha", NpgsqlDbType.Numeric).Value = v_id_cha;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
            m_command.Parameters.Add("v_sql", NpgsqlDbType.Text).Value = v_sql;
            m_command.Parameters.Add("v_tenfield", NpgsqlDbType.Text).Value = v_tenfield;
            m_command.Parameters.Add("v_captionfield", NpgsqlDbType.Text).Value = v_captionfield;
            m_command.Parameters.Add("v_width", NpgsqlDbType.Text).Value = v_width;
            m_command.Parameters.Add("v_report", NpgsqlDbType.Text).Value = v_report;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + "." + v_table + "(id,id_cha,stt,ten,sql,tenfield,captionfield,width,report,readonly) values(:v_id,:v_id_cha,:v_stt,:v_ten,:v_sql,:v_tenfield,:v_captionfield,:v_width,:v_report,:v_readonly)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_id_cha", NpgsqlDbType.Numeric).Value = v_id_cha;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_sql", NpgsqlDbType.Text).Value = v_sql;
                    m_command.Parameters.Add("v_tenfield", NpgsqlDbType.Text).Value = v_tenfield;
                    m_command.Parameters.Add("v_captionfield", NpgsqlDbType.Text).Value = v_captionfield;
                    m_command.Parameters.Add("v_width", NpgsqlDbType.Text).Value = v_width;
                    m_command.Parameters.Add("v_report", NpgsqlDbType.Text).Value = v_report;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_v_error(ex.Message, m_computername, "vp_treemenu");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        #endregion

        #region TỔNG HỢP SỐ LIỆU: CHUA CONVERT
        public DataSet get_v_chidinh(string v_mabn, string v_maql, string v_paid, string v_done)
        {
            string asql = "";
            string aexp = "";
            if (v_mabn == "" && v_maql == "")
            {
                return null;
            }

            if (v_mabn != "")
            {
                if (aexp == "")
                {
                    aexp = "a.mabn='" + v_mabn + "'";
                }
                else
                {
                    aexp += " and a.mabn='" + v_mabn + "'";
                }
            }
            if (v_maql != "")
            {
                if (aexp == "")
                {
                    aexp = "a.maql=" + v_maql;
                }
                else
                {
                    aexp += " and a.maql=" + v_maql;
                }
            }
            if (v_paid != "")
            {
                if (aexp == "")
                {
                    aexp = "a.paid=" + v_paid;
                }
                else
                {
                    aexp += " and a.paid=" + v_paid;
                }
            }
            if (v_done != "")
            {
                if (aexp == "")
                {
                    aexp = "a.done=" + v_done;
                }
                else
                {
                    aexp += " and a.done=" + v_done;
                }
            }
            aexp = aexp.Trim();
            if (aexp.Length > 0)
            {
                aexp = " where " + aexp;
            }
            foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
            {
                if (asql != "")
                {
                    asql += " union all ";
                }
                asql += "select a.id,a.mabn,a.maql,a.idkhoa,a.ngay,a.loai,a.makp,a.madoituong,a.mavp,a.soluong,a.dongia,a.paid,a.done,a.userid,a.ngayud,a.vattu,a.tinhtrang,a.thuchien,a.computer, to_char(a.ngay,'dd/mm/yyyy') ngaynhap from " + r["schemaname"].ToString() + ".v_chidinh a" + aexp;
            }
            return get_data(asql);
        }
        public DataSet get_v_vpkhoa(string v_mabn, string v_maql, string v_idkhoa, string v_done)
        {
            string asql = "";
            string aexp = "";
            if (v_mabn == "" && v_maql == "")
            {
                return null;
            }

            if (v_mabn != "")
            {
                if (aexp == "")
                {
                    aexp += "a.mabn='" + v_mabn + "'";
                }
                else
                {
                    aexp += " and a.mabn='" + v_mabn + "'";
                }
            }
            if (v_maql != "")
            {
                if (aexp == "")
                {
                    aexp += "a.maql=" + v_maql;
                }
                else
                {
                    aexp += " and a.maql=" + v_maql;
                }
            }
            if (v_idkhoa != "")
            {
                if (aexp == "")
                {
                    aexp += "a.idkhoa=" + v_idkhoa;
                }
                else
                {
                    aexp += " and a.idkhoa=" + v_idkhoa;
                }
            }
            if (v_done != "")
            {
                if (aexp == "")
                {
                    aexp += "a.done=" + v_done;
                }
                else
                {
                    aexp += " and a.done=" + v_done;
                }
            }
            aexp = aexp.Trim();
            if (aexp.Length > 0)
            {
                aexp = " where " + aexp;
            }

            foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
            {
                if (asql != "")
                {
                    asql += " union all ";
                }
                asql += "select a.id,a.mabn,a.maql,a.idkhoa,a.ngay,a.makp,a.madoituong,a.mavp,a.soluong,a.dongia,a.done,a.userid,a.ngayud,a.vattu,to_char(a.ngay,'dd/mm/yyyy') ngaynhap from " + r["schemaname"].ToString() + ".v_vpkhoa a" + aexp;
            }
            return get_data(asql);

        }
        public DataSet get_v_vpkhoa_in(string v_mabn, string v_maql, string v_idkhoa, string v_done, string v_ngayin)
        {
            string asql = "";
            string aexp = "";
            if (v_mabn == "" && v_maql == "")
            {
                return null;
            }
            if (v_mabn != "")
            {
                aexp += " and a.mabn='" + v_mabn + "'";
            }
            if (v_maql != "")
            {
                aexp += " and a.maql=" + v_maql;
            }
            if (v_idkhoa != "")
            {
                aexp += " and a.idkhoa=" + v_idkhoa;
            }
            if (v_ngayin != "")
            {
                aexp += " and trim(b.ngayin)='" + v_ngayin + "'";
            }
            if (v_done != "")
            {
                aexp += " and a.done=" + v_done;
            }
            aexp = aexp.Trim();
            if (aexp.Length > 0)
            {
                aexp = " " + aexp;
            }

            foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
            {
                if (asql != "")
                {
                    asql += " union all ";
                }
                asql += "select a.rowid, b.mmyy, a.id,a.mabn,a.maql,a.idkhoa,a.ngay,a.makp,a.madoituong,a.mavp,a.soluong,a.dongia,a.done,a.userid,a.ngayud,a.vattu,to_char(a.ngay,'dd/mm/yyyy') ngaynhap from " + r["schemaname"].ToString() + ".v_vpkhoa a, " + r["schemaname"].ToString() + ".v_tmpttrv b where a.rowid=b.row_id and b.loai=2 and to_char(a.ngay,'mmyy')=b.mmyy" + aexp;
            }
            return get_data(asql);
        }
        public DataSet get_v_tamung(string v_mabn, string v_maql, string v_idkhoa, string v_done, string v_hoan)
        {
            string asql = "";
            string aexp = "";
            if (v_mabn == "" && v_maql == "")
            {
                return null;
            }

            if (v_mabn != "")
            {
                if (aexp == "")
                {
                    aexp += "a.mabn='" + v_mabn + "'";
                }
                else
                {
                    aexp += " and a.mabn='" + v_mabn + "'";
                }
            }
            if (v_maql != "")
            {
                if (aexp == "")
                {
                    aexp += "a.maql=" + v_maql;
                }
                else
                {
                    aexp += " and a.maql=" + v_maql;
                }
            }
            if (v_idkhoa != "")
            {
                if (aexp == "")
                {
                    aexp += "a.idkhoa=" + v_idkhoa;
                }
                else
                {
                    aexp += " and a.idkhoa=" + v_idkhoa;
                }
            }
            if (v_done != "")
            {
                if (aexp == "")
                {
                    aexp += "a.done=" + v_done;
                }
                else
                {
                    aexp += " and a.done=" + v_done;
                }
            }
            if (v_hoan != "")
            {
                if (v_hoan == "1")
                {
                    if (aexp == "")
                    {
                        aexp += " and b.id is not null";
                    }
                    else
                    {
                        aexp += " and b.id is not null";
                    }
                }
                else
                {
                    if (aexp == "")
                    {
                        aexp += " and b.id is null";
                    }
                    else
                    {
                        aexp += " and b.id is null";
                    }
                }
            }
            aexp = aexp.Trim();
            if (aexp.Length > 0)
            {
                aexp = " and " + aexp;
            }

            foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
            {
                if (asql != "")
                {
                    asql += " union all ";
                }
                asql += "select a.id,a.mabn,a.maql,a.idkhoa,a.quyenso,a.sobienlai,a.ngay,a.loai,a.makp,a.madoituong,a.sotien,a.userid,a.ngayud,a.done,a.lanin,a.loaibn,a.idttrv,decode(b.id,null,0,1) hoan, to_char(a.ngay,'dd/mm/yyyy') ngaynhap from " + r["schemaname"].ToString() + ".v_tamung a, " + r["schemaname"].ToString() + ".v_hoantra b where a.quyenso=b.quyenso(+) and a.sobienlai=b.sobienlai(+)" + aexp;
            }
            return get_data(asql);
        }
        public DataSet get_v_tamungct(string v_mabn, string v_maql, string v_idkhoa, string v_done, string v_hoan)
        {
            string asql = "";
            string aexp = "";
            if (v_mabn == "" && v_maql == "")
            {
                return null;
            }

            if (v_mabn != "")
            {
                if (aexp == "")
                {
                    aexp += "a.mabn='" + v_mabn + "'";
                }
                else
                {
                    aexp += " and a.mabn='" + v_mabn + "'";
                }
            }
            if (v_maql != "")
            {
                if (aexp == "")
                {
                    aexp += "a.maql=" + v_maql;
                }
                else
                {
                    aexp += " and a.maql=" + v_maql;
                }
            }
            if (v_idkhoa != "")
            {
                if (aexp == "")
                {
                    aexp += "a.idkhoa=" + v_idkhoa;
                }
                else
                {
                    aexp += " and a.idkhoa=" + v_idkhoa;
                }
            }
            if (v_done != "")
            {
                if (aexp == "")
                {
                    aexp += "a.done=" + v_done;
                }
                else
                {
                    aexp += " and a.done=" + v_done;
                }
            }
            if (v_hoan != "")
            {
                if (v_hoan == "1")
                {
                    if (aexp == "")
                    {
                        aexp += " and b.id is not null";
                    }
                    else
                    {
                        aexp += " and b.id is not null";
                    }
                }
                else
                {
                    if (aexp == "")
                    {
                        aexp += " and b.id is null";
                    }
                    else
                    {
                        aexp += " and b.id is null";
                    }
                }
            }
            aexp = aexp.Trim();
            if (aexp.Length > 0)
            {
                aexp = " and " + aexp;
            }

            foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
            {
                if (asql != "")
                {
                    asql += " union all ";
                }
                asql += "select aa.id,aa.loaivp,aa.sotien, decode(b.id,null,0,1) hoan, to_char(a.ngay,'dd/mm/yyyy') ngaynhap from " + s_schemaroot + ".v_tamung a, " + r["schemaname"].ToString() + ".v_tamungct aa, " + r["schemaname"].ToString() + ".v_hoantra b where a.id=aa.id and a.quyenso=b.quyenso(+) and a.sobienlai=b.sobienlai(+)" + aexp;
            }
            return get_data(asql);
        }
        public DataSet get_v_vienphill(string v_mabn, string v_maql, string v_idkhoa, string v_hoan)
        {
            string asql = "";
            string aexp = "";
            if (v_mabn == "" && v_maql == "")
            {
                return null;
            }

            if (v_mabn != "")
            {
                if (aexp == "")
                {
                    aexp += "a.mabn='" + v_mabn + "'";
                }
                else
                {
                    aexp += " and a.mabn='" + v_mabn + "'";
                }
            }
            if (v_maql != "")
            {
                if (aexp == "")
                {
                    aexp += "a.maql=" + v_maql;
                }
                else
                {
                    aexp += " and a.maql=" + v_maql;
                }
            }
            if (v_idkhoa != "")
            {
                if (aexp == "")
                {
                    aexp += "a.idkhoa=" + v_idkhoa;
                }
                else
                {
                    aexp += " and a.idkhoa=" + v_idkhoa;
                }
            }
            if (v_hoan != "")
            {
                if (v_hoan == "1")
                {
                    if (aexp == "")
                    {
                        aexp += " and b.id is not null";
                    }
                    else
                    {
                        aexp += " and b.id is not null";
                    }
                }
                else
                {
                    if (aexp == "")
                    {
                        aexp += " and b.id is null";
                    }
                    else
                    {
                        aexp += " and b.id is null";
                    }
                }
            }
            aexp = aexp.Trim();
            if (aexp.Length > 0)
            {
                aexp = " and " + aexp;
            }

            foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
            {
                if (asql != "")
                {
                    asql += " union all ";
                }
                asql += "select a.id,a.quyenso,a.sobienlai,a.ngay,a.mabn,a.maql,a.idkhoa,a.makp,a.hoten,a.namsinh,a.diachi,a.loai,a.loaibn,a.lanin,a.userid,a.ngayud,decode(b.id,null,0,1) hoan, to_char(a.ngay,'dd/mm/yyyy') ngaynhap from " + r["schemaname"].ToString() + ".v_vienphill a, " + r["schemaname"].ToString() + ".v_hoantra b where a.quyenso=b.quyenso(+) and a.sobienlai=b.sobienlai(+)" + aexp;
            }
            return get_data(asql);
        }
        public DataSet get_v_vienphict(string v_mabn, string v_maql, string v_idkhoa, string v_hoan)
        {
            string asql = "";
            string aexp = "";
            if (v_mabn == "" && v_maql == "")
            {
                return null;
            }

            if (v_mabn != "")
            {
                if (aexp == "")
                {
                    aexp += "a.mabn='" + v_mabn + "'";
                }
                else
                {
                    aexp += " and a.mabn='" + v_mabn + "'";
                }
            }
            if (v_maql != "")
            {
                if (aexp == "")
                {
                    aexp += "a.maql=" + v_maql;
                }
                else
                {
                    aexp += " and a.maql=" + v_maql;
                }
            }
            if (v_idkhoa != "")
            {
                if (aexp == "")
                {
                    aexp += "a.idkhoa=" + v_idkhoa;
                }
                else
                {
                    aexp += " and a.idkhoa=" + v_idkhoa;
                }
            }
            if (v_hoan != "")
            {
                if (v_hoan == "1")
                {
                    if (aexp == "")
                    {
                        aexp += " and b.id is not null";
                    }
                    else
                    {
                        aexp += " and b.id is not null";
                    }
                }
                else
                {
                    if (aexp == "")
                    {
                        aexp += " and b.id is null";
                    }
                    else
                    {
                        aexp += " and b.id is null";
                    }
                }
            }
            aexp = aexp.Trim();
            if (aexp.Length > 0)
            {
                aexp = " and " + aexp;
            }

            foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
            {
                if (asql != "")
                {
                    asql += " union all ";
                }
                asql += "select aa.id,aa.stt,aa.madoituong,aa.mavp,aa.soluong,aa.dongia,aa.mien,aa.thieu,aa.vattu,aa.mabs,aa.makp, decode(b.id,null,0,1) hoan,to_char(a.ngay,'dd/mm/yyyy') ngaynhap from " + r["schemaname"].ToString() + ".v_vienphill a, " + r["schemaname"].ToString() + ".v_vienphict aa, " + r["schemaname"].ToString() + ".v_hoantra b where a.id=aa.id and a.quyenso=b.quyenso(+) and a.sobienlai=b.sobienlai(+)" + aexp;
            }
            return get_data(asql);
        }
        public DataSet get_v_phieuchill(string v_mabn, string v_maql, string v_idkhoa)
        {
            string asql = "";
            string aexp = "";
            if (v_mabn == "" && v_maql == "")
            {
                return null;
            }

            if (v_mabn != "")
            {
                if (aexp == "")
                {
                    aexp += "a.mabn='" + v_mabn + "'";
                }
                else
                {
                    aexp += " and a.mabn='" + v_mabn + "'";
                }
            }
            if (v_maql != "")
            {
                if (aexp == "")
                {
                    aexp += "a.maql=" + v_maql;
                }
                else
                {
                    aexp += " and a.maql=" + v_maql;
                }
            }
            if (v_idkhoa != "")
            {
                if (aexp == "")
                {
                    aexp += "a.idkhoa=" + v_idkhoa;
                }
                else
                {
                    aexp += " and a.idkhoa=" + v_idkhoa;
                }
            }
            aexp = aexp.Trim();
            if (aexp.Length > 0)
            {
                aexp = " and " + aexp;
            }

            foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
            {
                if (asql != "")
                {
                    asql += " union all ";
                }
                asql += "select a.id,a.quyenso,a.sobienlai,a.ngay,a.mabn,a.maql,a.idkhoa,a.makp,a.hoten,a.loai,a.loaibn,a.userid,a.ngayud,to_char(a.ngay,'dd/mm/yyyy') ngaynhap from " + r["schemaname"].ToString() + ".v_phieuchill a, " + r["schemaname"].ToString() + ".v_phieuchict b where a.id=b.id" + aexp;
            }
            return get_data(asql);
        }
        public DataSet get_v_phieuchict(string v_mabn, string v_maql, string v_idkhoa)
        {
            string asql = "";
            string aexp = "";
            if (v_mabn == "" && v_maql == "")
            {
                return null;
            }

            if (v_mabn != "")
            {
                if (aexp == "")
                {
                    aexp += "a.mabn='" + v_mabn + "'";
                }
                else
                {
                    aexp += " and a.mabn='" + v_mabn + "'";
                }
            }
            if (v_maql != "")
            {
                if (aexp == "")
                {
                    aexp += "a.maql=" + v_maql;
                }
                else
                {
                    aexp += " and a.maql=" + v_maql;
                }
            }
            if (v_idkhoa != "")
            {
                if (aexp == "")
                {
                    aexp += "a.idkhoa=" + v_idkhoa;
                }
                else
                {
                    aexp += " and a.idkhoa=" + v_idkhoa;
                }
            }
            aexp = aexp.Trim();
            if (aexp.Length > 0)
            {
                aexp = " and " + aexp;
            }

            foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
            {
                if (asql != "")
                {
                    asql += " union all ";
                }
                asql += "select a.id,a.stt,a.mavp,a.sotien from " + r["schemaname"].ToString() + ".v_phieuchict a, " + r["schemaname"].ToString() + ".v_phieuchill b where a.id=b.id" + aexp;
            }
            return get_data(asql);
        }
        public DataSet get_v_ttrvll(string v_mabn, string v_maql, string v_idkhoa, string v_hoan)
        {
            string asql = "";
            string aexp = "";
            if (v_mabn == "" && v_maql == "")
            {
                return null;
            }

            if (v_mabn != "")
            {
                if (aexp == "")
                {
                    aexp += "aa.mabn='" + v_mabn + "'";
                }
                else
                {
                    aexp += " and aa.mabn='" + v_mabn + "'";
                }
            }
            if (v_maql != "")
            {
                if (aexp == "")
                {
                    aexp += "aa.maql=" + v_maql;
                }
                else
                {
                    aexp += " and aa.maql=" + v_maql;
                }
            }
            if (v_idkhoa != "")
            {
                if (aexp == "")
                {
                    aexp += "aa.idkhoa=" + v_idkhoa;
                }
                else
                {
                    aexp += " and aa.idkhoa=" + v_idkhoa;
                }
            }
            if (v_hoan != "")
            {
                if (v_hoan == "1")
                {
                    if (aexp == "")
                    {
                        aexp += " and b.id is not null";
                    }
                    else
                    {
                        aexp += " and b.id is not null";
                    }
                }
                else
                {
                    if (aexp == "")
                    {
                        aexp += " and b.id is null";
                    }
                    else
                    {
                        aexp += " and b.id is null";
                    }
                }
            }
            aexp = aexp.Trim();
            if (aexp.Length > 0)
            {
                aexp = " and " + aexp;
            }

            foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
            {
                if (asql != "")
                {
                    asql += " union all ";
                }
                asql += "select a.id,a.loaibn,a.loai,a.quyenso,a.sobienlai,a.ngay,a.makp,a.sotien,a.tamung,a.mien,a.bhyt,a.userid,a.ngayud,a.nopthem,a.thieu,a.vattu,a.lanin,a.idtonghop,aa.mabn,aa.maql, decode(b.id,null,0,1) hoan,to_char(a.ngay,'dd/mm/yyyy') ngaynhap from " + r["schemaname"].ToString() + ".v_ttrvll a, " + r["schemaname"].ToString() + ".v_ttrvds aa," + r["schemaname"].ToString() + ".v_hoantra b where a.id=aa.id and a.quyenso=b.quyenso(+) and a.sobienlai=b.sobienlai(+)" + aexp;
            }
            return get_data(asql);
        }
        public DataSet get_v_ttrvct(string v_mabn, string v_maql, string v_idkhoa, string v_hoan)
        {
            string asql = "";
            string aexp = "";
            if (v_mabn == "" && v_maql == "")
            {
                return null;
            }

            if (v_mabn != "")
            {
                if (aexp == "")
                {
                    aexp += "a.mabn='" + v_mabn + "'";
                }
                else
                {
                    aexp += " and a.mabn='" + v_mabn + "'";
                }
            }
            if (v_maql != "")
            {
                if (aexp == "")
                {
                    aexp += "a.maql=" + v_maql;
                }
                else
                {
                    aexp += " and a.maql=" + v_maql;
                }
            }
            if (v_idkhoa != "")
            {
                if (aexp == "")
                {
                    aexp += "a.idkhoa=" + v_idkhoa;
                }
                else
                {
                    aexp += " and a.idkhoa=" + v_idkhoa;
                }
            }
            if (v_hoan != "")
            {
                if (v_hoan == "1")
                {
                    if (aexp == "")
                    {
                        aexp += " and b.id is not null";
                    }
                    else
                    {
                        aexp += " and b.id is not null";
                    }
                }
                else
                {
                    if (aexp == "")
                    {
                        aexp += " and b.id is null";
                    }
                    else
                    {
                        aexp += " and b.id is null";
                    }
                }
            }
            aexp = aexp.Trim();
            if (aexp.Length > 0)
            {
                aexp = " and " + aexp;
            }

            foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
            {
                if (asql != "")
                {
                    asql += " union all ";
                }
                asql += "select aaa.id,aaa.stt,aaa.ngay,aaa.makp,aaa.madoituong,aaa.mavp,aaa.soluong,aaa.dongia,aaa.vat,aaa.vattu,aaa.sotien,decode(b.id,null,0,1) hoan, to_char(aa.ngay,'dd/mm/yyyy') ngaynhap from v_ttrvds a, " + r["schemaname"].ToString() + ".v_ttrvll aa, " + r["schemaname"].ToString() + ".v_ttrvct aaa, " + r["schemaname"].ToString() + ".v_hoantra b where a.id=aa.id and a.id=aaa.id and aa.quyenso=b.quyenso(+) and aa.sobienlai=b.sobienlai(+)" + aexp;
            }
            return get_data(asql);
        }
        public DataSet get_v_mienngtru(string v_mabn, string v_maql, string v_idkhoa, string v_hoan)
        {
            string asql = "";
            string aexp = "";
            if (v_mabn == "" && v_maql == "")
            {
                return null;
            }

            if (v_mabn != "")
            {
                if (aexp == "")
                {
                    aexp += "a.mabn='" + v_mabn + "'";
                }
                else
                {
                    aexp += " and a.mabn='" + v_mabn + "'";
                }
            }
            if (v_maql != "")
            {
                if (aexp == "")
                {
                    aexp += "a.maql=" + v_maql;
                }
                else
                {
                    aexp += " and a.maql=" + v_maql;
                }
            }
            if (v_idkhoa != "")
            {
                if (aexp == "")
                {
                    aexp += "a.idkhoa=" + v_idkhoa;
                }
                else
                {
                    aexp += " and a.idkhoa=" + v_idkhoa;
                }
            }
            if (v_hoan != "")
            {
                if (v_hoan == "1")
                {
                    if (aexp == "")
                    {
                        aexp += " and b.id is not null";
                    }
                    else
                    {
                        aexp += " and b.id is not null";
                    }
                }
                else
                {
                    if (aexp == "")
                    {
                        aexp += " and b.id is null";
                    }
                    else
                    {
                        aexp += " and b.id is null";
                    }
                }
            }
            aexp = aexp.Trim();
            if (aexp.Length > 0)
            {
                aexp = " and " + aexp;
            }

            foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
            {
                if (asql != "")
                {
                    asql += " union all ";
                }
                asql += "select aa.id,aa.sotien,aa.ghichu,aa.maduyet,aa.lydo, decode(b.id,null,0,1) hoan, to_char(a.ngay,'dd/mm/yyyy') ngaynhap from " + r["schemaname"].ToString() + ".v_vienphill a, " + r["schemaname"].ToString() + ".v_mienngtru aa, " + r["schemaname"].ToString() + ".v_hoantra b where a.id=aa.id and a.quyenso=b.quyenso(+) and a.sobienlai=b.sobienlai(+)" + aexp;
            }
            return get_data(asql);
        }
        public DataSet get_v_hoantra(string v_mabn, string v_quyensoid, string v_sobienlai, string v_ngay10, string v_loai, string v_loaibn)
        {
            string asql = "";
            string aexp = "";
            if (v_mabn == "")
            {
                return null;
            }

            if (v_mabn != "")
            {
                if (aexp == "")
                {
                    aexp += "a.mabn='" + v_mabn + "'";
                }
                else
                {
                    aexp += " and a.mabn='" + v_mabn + "'";
                }
            }
            if (v_quyensoid != "")
            {
                if (aexp == "")
                {
                    aexp += "a.quyenso=" + v_quyensoid + "";
                }
                else
                {
                    aexp += " and a.quyenso=" + v_quyensoid + "";
                }
            }
            if (v_sobienlai != "")
            {
                if (aexp == "")
                {
                    aexp += "a.sobienlai=" + v_sobienlai + "";
                }
                else
                {
                    aexp += " and a.sobienlai=" + v_sobienlai + "";
                }
            }
            if (v_ngay10 != "")
            {
                if (aexp == "")
                {
                    aexp += "to_char(a.ngay,'dd/mm/yyyy')='" + v_ngay10 + "'";
                }
                else
                {
                    aexp += " and to_char(a.ngay,'dd/mm/yyyy')='" + v_ngay10 + "'";
                }
            }
            if (v_loai != "")
            {
                if (aexp == "")
                {
                    aexp += "a.loai=" + v_loai + "";
                }
                else
                {
                    aexp += " and a.loai=" + v_loai + "";
                }
            }
            if (v_loaibn != "")
            {
                if (aexp == "")
                {
                    aexp += "a.loaibn=" + v_loaibn + "";
                }
                else
                {
                    aexp += " and a.loaibn=" + v_loaibn + "";
                }
            }
            aexp = aexp.Trim();
            if (aexp.Length > 0)
            {
                aexp = " and " + aexp;
            }

            foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
            {
                if (asql != "")
                {
                    asql += " union all ";
                }
                asql += "select a.id,a.quyenso,a.sobienlai,a.ngay,a.mabn,a.hoten,a.sotien,a.ghichu,a.userid,a.ngayud,a.loai,a.loaibn,to_char(a.ngay,'dd/mm/yyyy') ngaynhap from " + r["schemaname"].ToString() + ".v_hoantra a where 1=1" + aexp;
            }
            return get_data(asql);
        }
        public DataSet get_d_tienthuoc(string v_mabn, string v_maql, string v_idkhoa, string v_done)
        {
            string asql = "";
            string aexp = "";
            if (v_mabn == "" && v_maql == "")
            {
                return null;
            }

            if (v_mabn != "")
            {
                if (aexp == "")
                {
                    aexp += "a.mabn='" + v_mabn + "'";
                }
                else
                {
                    aexp += " and a.mabn='" + v_mabn + "'";
                }
            }
            if (v_maql != "")
            {
                if (aexp == "")
                {
                    aexp += "a.maql=" + v_maql;
                }
                else
                {
                    aexp += " and a.maql=" + v_maql;
                }
            }
            if (v_idkhoa != "")
            {
                if (aexp == "")
                {
                    aexp += "a.idkhoa=" + v_idkhoa;
                }
                else
                {
                    aexp += " and a.idkhoa=" + v_idkhoa;
                }
            }
            if (v_done != "")
            {
                if (aexp == "")
                {
                    aexp += "a.done=" + v_done;
                }
                else
                {
                    aexp += " and a.done=" + v_done;
                }
            }
            aexp = aexp.Trim();
            if (aexp.Length > 0)
            {
                aexp = " where " + aexp;
            }

            foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
            {
                if (asql != "")
                {
                    asql += " union all ";
                }
                asql += "select a.mabn,a.maql,a.idkhoa,a.ngay,a.makp,a.madoituong,a.mabd,a.soluong,a.sotien,a.giaban,a.giamua,a.done,to_char(a.ngay,'dd/mm/yyyy') ngaynhap from " + r["schemaname"].ToString() + ".d_tienthuoc a" + aexp;
            }
            return get_data(asql);
        }
        public DataSet get_d_tienthuoc_in(string v_mabn, string v_maql, string v_idkhoa, string v_done, string v_ngayin)
        {
            string asql = "";
            string aexp = "";
            if (v_mabn == "" && v_maql == "")
            {
                return null;
            }

            if (v_mabn != "")
            {
                aexp += " and a.mabn='" + v_mabn + "'";
            }
            if (v_maql != "")
            {
                aexp += " and a.maql=" + v_maql;
            }
            if (v_idkhoa != "")
            {
                aexp += " and a.idkhoa=" + v_idkhoa;
            }
            if (v_ngayin != "")
            {
                aexp += " and trim(b.ngayin)='" + v_ngayin + "'";
            }
            if (v_done != "")
            {
                aexp += " and a.done=" + v_done;
            }
            aexp = aexp.Trim();
            if (aexp.Length > 0)
            {
                aexp = " " + aexp;
            }

            foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
            {
                if (asql != "")
                {
                    asql += " union all ";
                }
                asql += "select a.rowid,b.mmyy,a.mabn,a.maql,a.idkhoa,a.ngay,a.makp,a.madoituong,a.mabd,a.soluong,a.sotien,a.giaban,a.giamua,a.done,to_char(a.ngay,'dd/mm/yyyy') ngaynhap from " + r["schemaname"].ToString() + ".d_tienthuoc a, " + r["schemaname"].ToString() + ".v_tmpttrv b where a.rowid=b.row_id and b.loai=1 and to_char(a.ngay,'mmyy')=b.mmyy" + aexp;
            }
            return get_data(asql);
        }
        public DataSet get_d_tienthuoc(DateTime v_tu, DateTime v_den, string v_mabn, string v_maql, string v_idkhoa, string v_done)
        {
            string asql = "";
            string aexp = "";
            if (v_mabn == "" && v_maql == "")
            {
                return null;
            }

            if (v_mabn != "")
            {
                if (aexp == "")
                {
                    aexp += "a.mabn='" + v_mabn + "'";
                }
                else
                {
                    aexp += " and a.mabn='" + v_mabn + "'";
                }
            }
            if (v_maql != "")
            {
                if (aexp == "")
                {
                    aexp += "a.maql=" + v_maql;
                }
                else
                {
                    aexp += " and a.maql=" + v_maql;
                }
            }
            if (v_idkhoa != "")
            {
                if (aexp == "")
                {
                    aexp += "a.idkhoa=" + v_idkhoa;
                }
                else
                {
                    aexp += " and a.idkhoa=" + v_idkhoa;
                }
            }
            if (v_done != "")
            {
                if (aexp == "")
                {
                    aexp += "a.done=" + v_done;
                }
                else
                {
                    aexp += " and a.done=" + v_done;
                }
            }
            aexp = aexp.Trim();
            if (aexp.Length > 0)
            {
                aexp = " where " + aexp;
            }

            foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
            {
                if (asql != "")
                {
                    asql += " union all ";
                }
                asql += "select a.mabn,a.maql,a.idkhoa,a.ngay,a.makp,a.madoituong,a.mabd,a.soluong,a.sotien,a.giaban,a.giamua,a.done,to_char(a.ngay,'dd/mm/yyyy') ngaynhap from " + r["schemaname"].ToString() + ".d_tienthuoc a" + aexp;
            }
            return get_data(asql);
        }
        public DataSet get_d_tienthuoc_in(DateTime v_tu, DateTime v_den, string v_mabn, string v_maql, string v_idkhoa, string v_done, string v_ngayin)
        {
            string asql = "";
            string aexp = "";
            if (v_mabn == "" && v_maql == "")
            {
                return null;
            }

            if (v_mabn != "")
            {
                aexp += " and a.mabn='" + v_mabn + "'";
            }
            if (v_maql != "")
            {
                aexp += " and a.maql=" + v_maql;
            }
            if (v_idkhoa != "")
            {
                aexp += " and a.idkhoa=" + v_idkhoa;
            }
            if (v_ngayin != "")
            {
                aexp += " and trim(b.ngayin)='" + v_ngayin + "'";
            }
            if (v_done != "")
            {
                aexp += " and a.done=" + v_done;
            }
            aexp = aexp.Trim();
            if (aexp.Length > 0)
            {
                aexp = " " + aexp;
            }

            foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
            {
                if (asql != "")
                {
                    asql += " union all ";
                }
                asql += "select a.rowid,b.mmyy,a.mabn,a.maql,a.idkhoa,a.ngay,a.makp,a.madoituong,a.mabd,a.soluong,a.sotien,a.giaban,a.giamua,a.done,to_char(a.ngay,'dd/mm/yyyy') ngaynhap from " + r["schemaname"].ToString() + ".d_tienthuoc a, " + r["schemaname"].ToString() + ".v_tmpttrv b where a.rowid=b.row_id and b.loai=1 and to_char(a.ngay,'mmyy')=b.mmyy" + aexp;
            }
            return get_data(asql);
        }
        public DataSet get_bhytkb(string v_id, string v_mabn, string v_maql, string v_ngay, string v_quyenso, string v_sobienlai, string v_done)
        {
            string asql = "";
            string aexp = "";
            if (v_mabn == "" && v_maql == "" && v_id == "")
            {
                return null;
            }
            if (v_id != "")
            {
                if (aexp == "")
                {
                    aexp += "a.id=" + v_id;
                }
                else
                {
                    aexp += " and a.id=" + v_id;
                }
            }
            if (v_mabn != "")
            {
                if (aexp == "")
                {
                    aexp += "a.mabn='" + v_mabn + "'";
                }
                else
                {
                    aexp += " and a.mabn='" + v_mabn + "'";
                }
            }
            if (v_maql != "")
            {
                if (aexp == "")
                {
                    aexp += "a.maql=" + v_maql;
                }
                else
                {
                    aexp += " and a.maql=" + v_maql;
                }
            }
            if (v_ngay != "")
            {
                if (aexp == "")
                {
                    aexp += "to_char(a.ngay,'dd/mm/yyyy')='" + v_ngay + "'";
                }
                else
                {
                    aexp += " and to_char(a.ngay,'dd/mm/yyyy')='" + v_ngay + "'";
                }
            }
            if (v_quyenso != "")
            {
                if (aexp == "")
                {
                    aexp += "a.quyenso=" + v_quyenso;
                }
                else
                {
                    aexp += " and a.quyenso=" + v_quyenso;
                }
            }
            if (v_sobienlai != "")
            {
                if (aexp == "")
                {
                    aexp += "a.sobienlai=" + v_sobienlai;
                }
                else
                {
                    aexp += " and a.done=" + v_sobienlai;
                }
            }
            if (v_done != "")
            {
                if (aexp == "")
                {
                    aexp += "a.done=" + v_done;
                }
                else
                {
                    aexp += " and a.done=" + v_done;
                }
            }
            aexp = aexp.Trim();
            if (aexp.Length > 0)
            {
                aexp = " where " + aexp;
            }

            foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
            {
                if (asql != "")
                {
                    asql += " union all ";
                }
                asql += "select a.id,a.nhom,a.quyenso,a.sobienlai,a.ngay,a.mabn,a.maql,a.makp,a.chandoan,a.maicd,a.mabs,a.sothe,a.maphu,a.mabv,a.congkham,a.thuoc,a.cls,a.bntra,a.bhyttra,a.mmyy,a.userid,a.ngayud,a.done,a.sotoa from " + r["schemaname"].ToString() + ".bhytkb a" + aexp;
            }
            return get_data(asql);
        }
        public DataSet get_bhytthuoc(string v_id, string v_mabn, string v_maql, string v_ngay, string v_quyenso, string v_sobienlai, string v_done)
        {
            string asql = "";
            string aexp = "";
            if (v_mabn == "" && v_maql == "" && v_id == "")
            {
                return null;
            }

            if (v_id != "")
            {
                if (aexp == "")
                {
                    aexp += "a.id=" + v_id;
                }
                else
                {
                    aexp += " and a.id=" + v_id;
                }
            }
            if (v_mabn != "")
            {
                if (aexp == "")
                {
                    aexp += "a.mabn='" + v_mabn + "'";
                }
                else
                {
                    aexp += " and a.mabn='" + v_mabn + "'";
                }
            }
            if (v_maql != "")
            {
                if (aexp == "")
                {
                    aexp += "a.maql=" + v_maql;
                }
                else
                {
                    aexp += " and a.maql=" + v_maql;
                }
            }
            if (v_ngay != "")
            {
                if (aexp == "")
                {
                    aexp += "to_char(a.ngay,'dd/mm/yyyy')='" + v_ngay + "'";
                }
                else
                {
                    aexp += " and to_char(a.ngay,'dd/mm/yyyy')='" + v_ngay + "'";
                }
            }
            if (v_quyenso != "")
            {
                if (aexp == "")
                {
                    aexp += "a.quyenso=" + v_quyenso;
                }
                else
                {
                    aexp += " and a.quyenso=" + v_quyenso;
                }
            }
            if (v_sobienlai != "")
            {
                if (aexp == "")
                {
                    aexp += "a.sobienlai=" + v_sobienlai;
                }
                else
                {
                    aexp += " and a.done=" + v_sobienlai;
                }
            }
            if (v_done != "")
            {
                if (aexp == "")
                {
                    aexp += "a.done=" + v_done;
                }
                else
                {
                    aexp += " and a.done=" + v_done;
                }
            }
            aexp = aexp.Trim();
            if (aexp.Length > 0)
            {
                aexp = " and " + aexp;
            }

            foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
            {
                if (asql != "")
                {
                    asql += " union all ";
                }
                asql += "select b.id,b.stt,b.sttt,b.makho,b.manguon,b.nhomcc,b.mabd,b.handung,b.losx,b.soluong,b.sotien,b.giaban,b.cachdung,b.giamua, a.makp from " + r["schemaname"].ToString() + ".bhytkb a, " + r["schemaname"].ToString() + ".bhytthuoc b where a.id=b.id" + aexp;
            }
            return get_data(asql);
        }
        public DataSet get_bhytcls(string v_id, string v_mabn, string v_maql, string v_ngay, string v_quyenso, string v_sobienlai, string v_done)
        {
            string asql = "";
            string aexp = "";
            if (v_mabn == "" && v_maql == "" && v_id == "")
            {
                return null;
            }

            if (v_id != "")
            {
                if (aexp == "")
                {
                    aexp += "a.id=" + v_id;
                }
                else
                {
                    aexp += " and a.id=" + v_id;
                }
            }

            if (v_mabn != "")
            {
                if (aexp == "")
                {
                    aexp += "a.mabn='" + v_mabn + "'";
                }
                else
                {
                    aexp += " and a.mabn='" + v_mabn + "'";
                }
            }
            if (v_maql != "")
            {
                if (aexp == "")
                {
                    aexp += "a.maql=" + v_maql;
                }
                else
                {
                    aexp += " and a.maql=" + v_maql;
                }
            }
            if (v_ngay != "")
            {
                if (aexp == "")
                {
                    aexp += "to_char(a.ngay,'dd/mm/yyyy')='" + v_ngay + "'";
                }
                else
                {
                    aexp += " and to_char(a.ngay,'dd/mm/yyyy')='" + v_ngay + "'";
                }
            }
            if (v_quyenso != "")
            {
                if (aexp == "")
                {
                    aexp += "a.quyenso=" + v_quyenso;
                }
                else
                {
                    aexp += " and a.quyenso=" + v_quyenso;
                }
            }
            if (v_sobienlai != "")
            {
                if (aexp == "")
                {
                    aexp += "a.sobienlai=" + v_sobienlai;
                }
                else
                {
                    aexp += " and a.done=" + v_sobienlai;
                }
            }
            if (v_done != "")
            {
                if (aexp == "")
                {
                    aexp += "a.done=" + v_done;
                }
                else
                {
                    aexp += " and a.done=" + v_done;
                }
            }
            aexp = aexp.Trim();
            if (aexp.Length > 0)
            {
                aexp = " and " + aexp;
            }

            foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
            {
                if (asql != "")
                {
                    asql += " union all ";
                }
                asql += "select b.id,b.stt,b.mavp,b.soluong,b.dongia,b.idchidinh, a.makp from " + r["schemaname"].ToString() + ".bhytkb a, " + r["schemane"].ToString() + ".bhytcls b where a.id=b.id" + aexp;
            }
            return get_data(asql);
        }
        public DataSet get_d_ngtrull(string v_id, string v_mabn, string v_maql)
        {
            string asql = "";
            string aexp = "";
            if (v_mabn == "" && v_maql == "" && v_id == "")
            {
                return null;
            }

            if (v_id != "")
            {
                if (aexp == "")
                {
                    aexp += "a.id=" + v_id;
                }
                else
                {
                    aexp += " and a.id=" + v_id;
                }
            }

            if (v_mabn != "")
            {
                if (aexp == "")
                {
                    aexp += "a.mabn='" + v_mabn + "'";
                }
                else
                {
                    aexp += " and a.mabn='" + v_mabn + "'";
                }
            }
            if (v_maql != "")
            {
                if (aexp == "")
                {
                    aexp += "a.maql=" + v_maql;
                }
                else
                {
                    aexp += " and a.maql=" + v_maql;
                }
            }
            aexp = aexp.Trim();
            if (aexp.Length > 0)
            {
                aexp = " and " + aexp;
            }

            foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
            {
                if (asql != "")
                {
                    asql += " union all ";
                }
                asql += "select a.id,a.nhom,a.mabn,a.hoten,a.namsinh,a.ngay,a.mabs,a.makp,a.loai,a.mmyy,a.done,a.userid,a.ngayud,a.lanin,a.sotoa,a.maql, to_char(a.ngay,'dd/mm/yyyy') ngaynhap from " + r["schemaname"].ToString() + ".d_ngtrull a, " + r["schemaname"].ToString() + ".d_ngtruct b where a.id=b.id" + aexp;
            }
            return get_data(asql);
        }
        public DataSet get_d_ngtruct(string v_id, string v_mabn, string v_maql)
        {
            string asql = "";
            string aexp = "";
            if (v_mabn == "" && v_maql == "" && v_id == "")
            {
                return null;
            }

            if (v_id != "")
            {
                if (aexp == "")
                {
                    aexp += "a.id=" + v_id;
                }
                else
                {
                    aexp += " and a.id=" + v_id;
                }
            }

            if (v_mabn != "")
            {
                if (aexp == "")
                {
                    aexp += "a.mabn='" + v_mabn + "'";
                }
                else
                {
                    aexp += " and a.mabn='" + v_mabn + "'";
                }
            }
            if (v_maql != "")
            {
                if (aexp == "")
                {
                    aexp += "a.maql=" + v_maql;
                }
                else
                {
                    aexp += " and a.maql=" + v_maql;
                }
            }
            aexp = aexp.Trim();
            if (aexp.Length > 0)
            {
                aexp = " and " + aexp;
            }

            foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
            {
                if (asql != "")
                {
                    asql += " union all ";
                }
                asql += "select b.id,b.stt,b.sttt,b.makho,b.manguon,b.nhomcc,b.mabd,b.handung,b.losx,b.soluong,b.sotien,b.giaban,b.giamua, to_char(a.ngay,'dd/mm/yyyy') ngaynhap from " + r["schemaname"].ToString() + ".d_ngtrull a, " + r["schemaname"].ToString() + ".d_ngtruct b where a.id=b.id" + aexp;
            }
            return get_data(asql);
        }
        public DataSet get_v_danhsachchidinh(string v_tn, string v_dn, string v_paid, string v_done, string v_madoituong)
        {
            string asql = "";
            string aexp = "", ayy = "";
            if (v_tn == "" || v_dn == "")
            {
                return null;
            }
            ayy = v_tn.Substring(8, 2);

            if (v_tn != "")
            {
                if (aexp == "")
                {
                    aexp = "to_date(to_char(a.ngay,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi')>=to_date('" + v_tn + "','dd/mm/yyyy hh24:mi')";
                }
                else
                {
                    aexp += " and to_date(to_char(a.ngay,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi')>=to_date('" + v_tn + "','dd/mm/yyyy hh24:mi')";
                }
            }
            if (v_dn != "")
            {
                if (aexp == "")
                {
                    aexp = "to_date(to_char(a.ngay,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi')<=to_date('" + v_dn + "','dd/mm/yyyy hh24:mi')";
                }
                else
                {
                    aexp += " and to_date(to_char(a.ngay,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi')<=to_date('" + v_dn + "','dd/mm/yyyy hh24:mi')";
                }
            }
            if (v_paid != "")
            {
                if (aexp == "")
                {
                    aexp = "a.paid=" + v_paid;
                }
                else
                {
                    aexp += " and a.paid=" + v_paid;
                }
            }
            if (v_done != "")
            {
                if (aexp == "")
                {
                    aexp = "a.done=" + v_done;
                }
                else
                {
                    aexp += " and a.done=" + v_done;
                }
            }
            if (v_madoituong != "")
            {
                if (aexp == "")
                {
                    aexp = "a.madoituong in(" + v_madoituong + ")";
                }
                else
                {
                    aexp += " and a.madoituong in(" + v_madoituong + ")";
                }
            }
            aexp = aexp.Trim();
            if (aexp.Length > 0)
            {
                aexp = " and " + aexp;
            }

            asql = "select '0' chon, b.mabn, b.hoten, nvl(to_char(b.ngaysinh,'dd/mm/yyyy'),b.namsinh) namsinh, c.ten  gioitinh, d.sothe, to_char(d.denngay,'dd/mm/yyyy') denngay, trim(trim(b.sonha)||' '||trim(b.thon)) diachi, to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngay, a.id, a.maql, a.mavp, e.ma, e.ten, e.dvt, a.madoituong, f.doituong, nvl(a.soluong,0) soluong, nvl(a.dongia,0) dongia, nvl(a.vattu,0) vattu, (a.soluong*a.dongia) sotien, 0 mien, 0 bhyt, 0 thucthu, 0 lydo, 0 maduyet from " + s_schema_mmyy(ayy) + ".v_chidinh a, btdbn b, dmphai c, bhyt d, v_giavp e, doituong f where a.mabn=b.mabn and b.phai=c.ma(+) and a.maql=d.maql(+) and a.mavp=e.id and a.madoituong=f.madoituong and nvl(a.soluong,0)>0 and nvl(a.dongia,0)>0 " + aexp;
            return get_data(asql);
        }
        public bool dahoantra(string v_mabn, string v_mavaovien, string v_maql, string v_quyenso, string v_sobienlai, string v_loai, string v_loaibn)
        {
            try
            {
                string asql = "";
                string aexp = "";
                aexp = "a.mabn='" + v_mabn + "' and a.mavaovien=" + v_mavaovien + " and a.maql=" + v_maql + " and a.quyenso=" + v_quyenso + " and a.sobienlai=" + v_sobienlai + " and a.loai=" + v_loai;// +" and a.loaibn=" + v_loaibn + "";
                DataSet adss = get_shemaname_mmyy();
                DataSet adst = null;
                foreach (DataRow r in adss.Tables[0].Rows)
                {
                    adst = null;
                    asql = "select a.id from " + r["schemaname"].ToString() + ".v_hoantra a where " + aexp + " limit 1";
                    adst = get_data(asql);
                    if (adst != null)
                    {
                        if (adst.Tables[0].Rows.Count > 0)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion

    }
}
