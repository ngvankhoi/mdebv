using System;
using System.Xml;
using System.Data;
using Npgsql;
using NpgsqlTypes;
using System.Diagnostics;
using LinksLicense;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;

namespace LibXN
{
    public class AccessData
    {
        public const string Msg = "Xét nghiệm 2007";

        private string xxxxx = "ð§ì©î«³²°ô£";
        public const string s_links_username = "links";
        public const string s_links_password = "link7155019s20";
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
        public int i_maxlength_mabn = 8, i_maxlength_makp = 2, i_maxlength_Stt=0;

        public AccessData()
        {
            m_computername = System.Environment.MachineName.Trim().ToUpper();
            f_load_maincode();
            if (Maincode("xxxxx") == "*****") m_db_password = decode(xxxxx).ToLower();           
            m_db_connectionstring = "Server=" + m_db_host + ";Port=" + m_db_port + ";User Id=" + m_db_userid + ";Password=" + m_db_password + ";Database=" + m_db_database + ";Encoding=" + m_db_encoding + ";";
            if (!upd_dmcomputer(1))
            {
                System.Windows.Forms.MessageBox.Show("Không kết nối được Server !", Msg);
                System.Windows.Forms.Application.Exit();
            }
            m_computerid = get_computerid();
            m_ds_schema = get_shemaname_mmyy();
            i_maxlength_makp = iChieudai_makp;
            i_maxlength_mabn = iChieudai_mabn;
            i_maxlength_Stt = ichieudai_stt;
        }
        #region get_chieudai_mabn_makp
        private int iChieudai_makp
        {
            get
            {
                try
                {
                    DataSet ds = get_data("select ten from " + user + ".thongso where id=-98");
                    return int.Parse(ds.Tables[0].Rows[0][0].ToString());
                }
                catch { return 2; }
            }
        }
        private int ichieudai_stt
        {
            get
            {
                try
                {
                    if (s_o_dang_sothuthu.ToString() == "1")
                    {
                        if (bQuanly_Theo_Chinhanh)
                            return 6;
                        else
                            return 4;
                    }
                    else
                    {
                        return 10;
                    }
                }
                catch
                {
                    return 4;
                }
            }
        }
        private int iChieudai_mabn
        {
            get
            {
                try
                {
                    DataSet ds = get_data("select ten from " + user + ".thongso where id=-99");
                    return int.Parse(ds.Tables[0].Rows[0][0].ToString());
                }
                catch { return 8; }
            }
        }
        public bool bQuanly_Theo_Chinhanh
        {
            //A14.2
            get
            {
                try
                {
                    DataSet ds = get_data("select ten from " + user + ".thongso where id=998");
                    return ds.Tables[0].Rows[0][0].ToString() == "1";
                }
                catch { return false; }
            }
        }
        public int i_Chinhanh_hientai
        {
            //A30: lay id chi nhanh hien tai
            get
            {
                try
                {
                    DataSet ds = get_data("select ten from " + user + ".thongso where id=999");
                    return (ds.Tables[0].Rows[0][0].ToString() == "") ? 0 : int.Parse(ds.Tables[0].Rows[0][0].ToString());
                }
                catch { return 0; }
            }
        }
        #endregion get_chieudai_mabn_makp
        public bool upd_anhxa(int m_ma_medisoft, int m_ma_benhvien, string m_loai)
        {
            string strsql = "insert into " + user + ".anhxa (ma_medisoft,ma_benhvien,loai) values (:m_ma_medisoft,:m_ma_benhvien,:m_loai)";           
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            try
            {
                if (m_connection.State == ConnectionState.Closed) m_connection.Open();
                m_command = new NpgsqlCommand(strsql, m_connection);
                m_command.CommandType = CommandType.Text;
                m_command.Parameters.Add("m_ma_medisoft", NpgsqlDbType.Integer).Value = m_ma_medisoft;
                m_command.Parameters.Add("m_ma_benhvien", NpgsqlDbType.Integer).Value = m_ma_benhvien;
                m_command.Parameters.Add("m_loai", NpgsqlDbType.Varchar, 50).Value = m_loai;
                m_command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Close();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_bv_tentd(int m_id_bv_ten, int m_id_bv_tentd)
        {
            string strsql="";
            if (get_data("select * from " + user + ".xn_bv_tentd where id_bv_ten=" + m_id_bv_ten + " and id_bv_tentd=" + m_id_bv_tentd).Tables[0].Rows.Count == 0)
            {
                strsql = "insert into " + user + ".xn_bv_tentd (id_bv_ten,id_bv_tentd) values (:m_id_bv_ten,:m_id_bv_tentd)";
                m_connection = new NpgsqlConnection(m_db_connectionstring);
                try
                {
                    if (m_connection.State == ConnectionState.Closed) m_connection.Open();
                    m_command = new NpgsqlCommand(strsql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("m_id_bv_ten", NpgsqlDbType.Integer).Value = m_id_bv_ten;
                    m_command.Parameters.Add("m_id_bv_tentd", NpgsqlDbType.Integer).Value = m_id_bv_tentd;
                    m_command.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
                finally
                {
                    m_command.Dispose();
                    m_connection.Close();
                    m_connection.Dispose();
                }
            }
            return true;
        }
        public string s_AppName
        {
            get
            {
                return Msg;
            }
        }
        public string s_computername
        {
            get
            {
                return m_computername;
            }
        }
        public string user
        {
            get
            {
                return m_db_schemaroot;
            }
        }

        #region LICENSE

        private LinksLicense.LibLicense m_license = new LinksLicense.LibLicense();
        public bool upd_xn_license(string v_computer_key, string v_license_key)
        {
            if (v_computer_key == "" || v_license_key == "") return false;
            m_sql = "update " + m_db_schemaroot + ".license set license_key=:v_license_key where computer_key=:v_computer_key";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_computer_key", NpgsqlDbType.Text, 255).Value = v_computer_key;
            m_command.Parameters.Add("v_license_key", NpgsqlDbType.Text, 255).Value = v_license_key;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".license(computer_key,license_key) values(:v_computer_key,:v_license_key)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_computer_key", NpgsqlDbType.Text, 255).Value = v_computer_key;
                    m_command.Parameters.Add("v_license_key", NpgsqlDbType.Text, 255).Value = v_license_key;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_license");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool is_licensed
        {
            get
            {
                bool ar = false;
                try
                {
                    ar = get_xn_license(m_license.f_generate_computer_key(), m_license.f_generate_license_key()).Tables[0].Rows.Count > 0;
                }
                catch
                {
                    ar = false;
                }
                return ar;
            }
        }
        public DataSet get_xn_license(string v_computer_key, string v_license_key)
        {
            DataSet ads = null;
            try
            {
                string asql = "", aexp = "";
                asql = "select * from " + m_db_schemaroot + ".license";

                if (v_computer_key != "")
                {
                    if (aexp.Length > 0)
                    {
                        aexp += " and";
                    }
                    aexp += " computer_key=:v_computer_key";
                }
                if (v_license_key != "")
                {
                    if (aexp.Length > 0)
                    {
                        aexp += " and";
                    }
                    aexp += " license_key=:v_license_key";
                }

                if (aexp.Length > 0)
                {
                    asql += " where" + aexp;
                }

                m_connection = new NpgsqlConnection(m_db_connectionstring);
                m_connection.Open();
                m_command = new NpgsqlCommand(asql, m_connection);
                m_command.CommandType = CommandType.Text;

                if (v_computer_key != "")
                {
                    m_command.Parameters.Add("v_computer_key", NpgsqlDbType.Text, 255).Value = v_computer_key;
                }

                if (v_license_key != "")
                {
                    m_command.Parameters.Add("v_license_key", NpgsqlDbType.Text, 255).Value = v_license_key;
                }

                m_dataadapter = new NpgsqlDataAdapter(m_command);
                ads = new DataSet();
                m_dataadapter.Fill(ads);
                m_command.Dispose();
                m_connection.Dispose();
            }
            catch (NpgsqlException ex)
            {
                create_xn_license();
                upd_xn_error(ex.Message.ToString().Trim(), m_computername, "xn_license");
            }
            return ads;
        }
        public void set_licensed(string v_password_)
        {
            try
            {
                if (v_password_ == m_license.f_generate_password_key())
                {
                    string acomputer_key = "", alicence_key = "";
                    acomputer_key = m_license.f_generate_computer_key();
                    alicence_key = m_license.f_generate_license_key();
                    if (acomputer_key != "" && alicence_key != "")
                    {
                        upd_xn_license(acomputer_key, alicence_key);
                    }
                }
            }
            catch
            {
            }
        }
        public string s_computer_key
        {
            get
            {
                return m_license.f_generate_computer_key();
            }
        }
        public void create_xn_license()
        {
            try
            {
                int n = get_data("select * from " + m_db_schemaroot + ".license where 1=0").Tables[0].Rows.Count;
            }
            catch
            {
                execute_data("create table " + m_db_schemaroot + ".license(computer_key text, license_key text, constraint pk_license primary key(computer_key))");
                execute_data("alter table " + m_db_schemaroot + ".license owner to " + m_db_database + "");
            }
        }

        #endregion LICENSE

        #region  NGÀY HIỆN HÀNH SERVER

        public string s_curyy
        {
            get
            {
                return get_data("select to_char(now(),'yy')").Tables[0].Rows[0][0].ToString();
            }
        }
        public string s_curyyyy
        {
            get
            {
                return get_data("select to_char(now(),'yyyy')").Tables[0].Rows[0][0].ToString();
            }
        }
        public string s_curmmyy
        {
            get
            {
                return get_data("select to_char(now(),'mmyy')").Tables[0].Rows[0][0].ToString();
            }
        }
        public string s_curmmyyyy
        {
            get
            {
                return get_data("select to_char(now(),'mmyyyy')").Tables[0].Rows[0][0].ToString();
            }
        }
        public string s_curddmmyy
        {
            get
            {
                return get_data("select to_char(now(),'ddmmyy')").Tables[0].Rows[0][0].ToString();
            }
        }
        public string s_curddmmyyyy
        {
            get
            {
                return get_data("select to_char(now(),'ddmmyyyy')").Tables[0].Rows[0][0].ToString();
            }
        }
        public string s_curdd_mm_yyyy
        {
            get
            {
                return get_data("select to_char(now(),'dd/mm/yyyy')").Tables[0].Rows[0][0].ToString();
            }
        }
        public string s_curdd_mm_yyyy_hh24_mi
        {
            get
            {
                return get_data("select to_char(now(),'dd/mm/yyyy hh24:mi')").Tables[0].Rows[0][0].ToString();
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
        public string f_ngay16_curtime(string v_ngay10)
        {
            string art = "";
            try
            {
                art = v_ngay10 + " " + DateTime.Now.Hour.ToString().PadLeft(2,'0')+":"+DateTime.Now.Minute.ToString().PadLeft(2, '0');
            }
            catch
            {
                art = "";
            }
            return art;
        }
        public string get_mmyy(string v_ngay)
        {
            try
            {
                return (v_ngay.Substring(3,2)+v_ngay.Substring(8,2));
            }
            catch
            {
                return s_curmmyy;
            }
        }
        public System.DateTime StringToDate(string s)
        {
            s = (s == "") ? s_curdd_mm_yyyy_hh24_mi.Substring(0, 10) : s;
            string[] format ={ "dd/MM/yyyy" };
            return System.DateTime.ParseExact(s.ToString().Substring(0, 10), format, System.Globalization.DateTimeFormatInfo.CurrentInfo, System.Globalization.DateTimeStyles.None);
        }
        public string DateToString(string format, System.DateTime date)
        {
            if (date.Equals(null)) return "";
            else return date.ToString(format, System.Globalization.DateTimeFormatInfo.CurrentInfo);
        }
        #endregion CÁC HÀM VỀ NGÀY

        #region GIÁ TRỊ MẶC ĐỊNH
        public void f_macdinh_xn_nhomdlogin()
        {
            upd_xn_nhomdlogin(1,1,"ADMINDBA", "Quản trị cơ sở dữ liệu","", "", "");
            upd_xn_nhomdlogin(2,2,"ADMINAPP", "Quản trị chương trình","","", "");
            upd_xn_nhomdlogin(3,3,"ADMINDEP", "Quản trị khoa, phòng ban","", "", "");
            upd_xn_nhomdlogin(4, 4, "USER", "Nhân viên", "Nhân viên nhập liệu vi tính", "", "");
        }
        #endregion GIÁ TRỊ MẶC ĐỊNH

        #region CẬP NHẬT CẤU TRÚC TABLES
        public void drop_schema(string v_schema)
        {
            try
            {
                execute_data("drop schema "+v_schema+" cascade");
            }
            catch
            {
            }
        }
        public void drop_table(string v_schema, string v_table)
        {
            execute_data("drop table " + v_schema + "." + v_table + " cascade");
        }
        public void create_schema_xn(string v_mmyy)
        {
            execute_data("create schema " + s_schema_mmyy(v_mmyy) + " authorization " + m_db_database + "");
        }
        public void create_xn_thongsomay()
        {
            try
            {
                string a_schema = m_db_schemaroot;
                execute_data("CREATE TABLE " + a_schema + ".xn_thongsomay(id numeric(5), stt numeric(5), ma text, ten text, id_bv_chitiet numeric(11), tyle text, constraint pk_xn_thongsomay primary key(id, stt)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_thongsomay OWNER TO " + m_db_database + "");
            }
            catch
            {
            }
        }
        public void create_xn_may()
        {
            try
            {
                string a_schema = m_db_schemaroot;

                execute_data("CREATE TABLE " + a_schema + ".xn_may(id numeric(5),stt numeric(3),ma text, ten text, readonly numeric(1) default 0, ksd numeric(1) default 0, constraint pk_xn_may primary key(id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_may OWNER TO " + m_db_database + "");
            }
            catch
            {
            }
        }
        public void create_xn_dmnuoicay()
        {
            try
            {
                string a_schema = m_db_schemaroot;

                execute_data("CREATE TABLE " + a_schema + ".xn_dmnuoicay(id numeric(11), constraint pk_xn_dmnuoicay primary key(id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_dmnuoicay OWNER TO " + m_db_database + "");
            }
            catch
            {
            }
        }
        public void create_tables_xn()
        {
            try
            {
                string a_schema = m_db_schemaroot;

                execute_data("CREATE TABLE " + a_schema + ".create table xn_may(id numeric(5),stt numeric(3),ma text, ten text, readonly numeric(1) default 0, ksd numeric(1) default 0, constraint pk_xn_may primary key(id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_may OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_thongsomay(id numeric(5), stt numeric(5), ma text, ten text, id_bv_chitiet numeric(11), tyle text, constraint pk_xn_thongsomay primary key(id, stt)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_thongsomay OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_treebaocao(id numeric(12) NOT NULL DEFAULT 0, id_cha numeric(12) NOT NULL DEFAULT 0,stt numeric(12) DEFAULT 0,ten text, asql text, readonly numeric(1) default 0, tenreport text,CONSTRAINT pk_xn_treebaocao PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_treebaocao OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_so(id numeric(2) NOT NULL DEFAULT 0,stt numeric(2) DEFAULT 0,ma varchar(10),ten text, viettat text,readonly numeric(1) DEFAULT 0,CONSTRAINT pk_xn_so PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_so OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_nhom(id numeric(4) NOT NULL DEFAULT 0,id_so numeric(2) DEFAULT 0,stt numeric(4) DEFAULT 0,ma varchar(10),ten text, viettat text,readonly numeric(1) DEFAULT 0,CONSTRAINT pk_xn_nhom PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_nhom OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_loai(id numeric(5) NOT NULL DEFAULT 0,id_nhom numeric(4) DEFAULT 0,stt numeric(5) DEFAULT 0,ma varchar(10),ten text, viettat text,readonly numeric(1) DEFAULT 0,tieuban numeric(2) DEFAULT 0,CONSTRAINT pk_xn_loai PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_loai OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_ten(id numeric(7) NOT NULL DEFAULT 0,id_nhom numeric(4) DEFAULT 0,id_loai numeric(5) DEFAULT 0,stt numeric(7) DEFAULT 0,ma varchar(10),ten text, viettat text, ghichu text, donvi numeric(5) DEFAULT 0,csbt_nu text,csbt_nam text,ghichu text,readonly numeric(1) DEFAULT 0,mincsbt_nu numeric(10) DEFAULT 0,maxcsbt_nu numeric(10) DEFAULT 0,mincsbt_nam numeric(10) DEFAULT 0,maxcsbt_nam numeric(10) DEFAULT 0,CONSTRAINT pk_xn_ten PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_ten OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_donvi(id numeric(5) NOT NULL DEFAULT 0,ma varchar(10),ten text,ten1 text,heso numeric(6,4) default 0,readonly numeric(1) DEFAULT 0,id_hl7 numeric(5) DEFAULT 0,CONSTRAINT pk_xn_donvi PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_donvi OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_donvi_hl7(id numeric(5) NOT NULL DEFAULT 0,stt numeric(5) DEFAULT 0,ma varchar(30),ten text,anh text,readonly numeric(1) DEFAULT 0,CONSTRAINT pk_xn_donvi_hl7 PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_donvi_hl7 OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_khangsinh(id numeric(7) NOT NULL DEFAULT 0,stt numeric(7) DEFAULT 0,ma varchar(10), mabv varchar(10),ten text, viettat text,readonly numeric(1) DEFAULT 0,CONSTRAINT pk_xn_khangsinh PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_khangsinh OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_vitrung(id numeric(5) NOT NULL DEFAULT 0,stt numeric(5) DEFAULT 0,ma varchar(10),ten text, viettat text,gram varchar(10),status varchar(10),readonly numeric(1) DEFAULT 0,CONSTRAINT pk_xn_vitrung PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_vitrung OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_mauthu(id numeric(4) NOT NULL DEFAULT 0,stt numeric(4) DEFAULT 0,ma varchar(10), mabv varchar2(10),ten text,anh text, viettat text, donvi numeric(5) DEFAULT 0,readonly numeric(1) DEFAULT 0,CONSTRAINT pk_xn_mauthu PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_mauthu OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_vitri(id numeric(4) NOT NULL DEFAULT 0,stt numeric(4) DEFAULT 0,ma varchar(10), mabv varchar(10),ten text, viettat text,readonly numeric(1) DEFAULT 0,anh text,CONSTRAINT pk_xn_vitri PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_vitri OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_diadiem(id numeric(4) NOT NULL DEFAULT 0,stt numeric(4) DEFAULT 0,ma varchar(10),ten text, viettat text,readonly numeric(1) DEFAULT 0,CONSTRAINT pk_xn_diadiem PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_diadiem OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_tinhtrang(id numeric(1) NOT NULL DEFAULT 0,stt numeric(1) DEFAULT 0,ma varchar(10),ten text, viettat text,readonly numeric(1) DEFAULT 0,CONSTRAINT pk_xn_tinhtrang PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_tinhtrang OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_ktv(ma varchar(4) NOT NULL,hoten text, viettat text,readonly numeric(1) DEFAULT 0,CONSTRAINT pk_xn_ktv PRIMARY KEY (ma)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_ktv OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_nhomdlogin(id numeric(5),nhom numeric(1),ma varchar(20), ten text, diengiai text, id_bv_so varchar(4000),right_ varchar(4000), readonly numeric(1) DEFAULT 0,CONSTRAINT pk_xn_nhomdlogin PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_nhomdlogin OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_dlogin(id numeric(5) NOT NULL DEFAULT 0,id_nhom numeric(5), hoten text, userid text, password_ text,id_bv_so varchar(4000),right_ varchar(4000), readonly numeric(1) DEFAULT 0,CONSTRAINT pk_xn_dlogin PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_dlogin OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_capid(ma numeric(3) NOT NULL DEFAULT 0,ten varchar(20),id numeric(12) DEFAULT 0,computer varchar(20) NOT NULL DEFAULT '?'::character varying,ngayud timestamp DEFAULT now()) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_capid OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_error(message text,computer varchar(20),tables varchar(20),ngayud timestamp) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_error OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_license(computer_key text NOT NULL,license_key text,CONSTRAINT pk_xn_license PRIMARY KEY (computer_key)) WITHOUT OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_license OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_thongso(id numeric(3) NOT NULL DEFAULT 0,loai varchar(10),ten text,CONSTRAINT pk_xn_thongso PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_thongso OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_thuoc(id numeric(5) NOT NULL DEFAULT 0,stt numeric(3) DEFAULT 0,ma numeric(7) DEFAULT 0,CONSTRAINT pk_xn_thuoc PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_thuoc OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".xn_hoachatDM(id numeric NOT NULL DEFAULT 0,mmyy varchar(4),stt numeric(2) DEFAULT 0,id_ten numeric(7) DEFAULT 0,makho numeric(3) NOT NULL DEFAULT 0,manguon numeric(2) DEFAULT 0,makp varchar(3),  mahc numeric(7) DEFAULT 0,soluong numeric(10,2) DEFAULT 0,soluongqd numeric(10,2) DEFAULT 0,readonly numeric(1) DEFAULT 0,CONSTRAINT pk_xn_hoachatDM PRIMARY KEY (id,stt,id_ten)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".xn_hoachatDM OWNER TO " + m_db_database + "");

                
                execute_data("CREATE TABLE " + a_schema + ".xn_vienphi(id numeric(7) NOT NULL DEFAULT 0,CONSTRAINT pk_xn_vienphi PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_vienphi OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_vitrung_thuoc(id numeric(5) NOT NULL DEFAULT 0,sir varchar(1),id_thuoc numeric(5) DEFAULT 0,CONSTRAINT pk_xn_vitrung_thuoc PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_vitrung_thuoc OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_sdmauthu(id_ten numeric(7) NOT NULL DEFAULT 0,id_mauthu numeric(4) NOT NULL DEFAULT 0,soluong numeric(10) DEFAULT 0, readonly numeric(1) DEFAULT 0, CONSTRAINT pk_xn_sdmauthu PRIMARY KEY (id_mauthu, id_ten)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_sdmauthu OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_sdxetnghiem(id_vienphi numeric(7) NOT NULL DEFAULT 0,id_bv_ten numeric(7) NOT NULL DEFAULT 0,CONSTRAINT pk_xn_sdxetnghiem PRIMARY KEY (id_bv_ten, id_vienphi)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_sdxetnghiem OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_bv_so(id numeric(2) NOT NULL DEFAULT 0,stt numeric(2) DEFAULT 0,ma varchar(10),ten text, viettat text,id_so numeric(2) DEFAULT 0,readonly numeric(1) DEFAULT 0,tenreport text,CONSTRAINT pk_xn_bv_so PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_bv_so OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_bv_ten(id numeric(7) NOT NULL DEFAULT 0,id_bv_so numeric(2) DEFAULT 0,id_vienphi numeric(7) DEFAULT 0,stt numeric(7) DEFAULT 0,ma varchar(10),ten text,viettat text, readonly numeric(1) DEFAULT 0,tieuban numeric(2) DEFAULT 0,CONSTRAINT pk_xn_bv_ten PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_bv_ten OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_bv_chitiet(id numeric(11) NOT NULL DEFAULT 0,id_bv_ten numeric(7) DEFAULT 0,id_ten numeric(7) DEFAULT 0,viettat text,stt numeric(11) DEFAULT 0,tieuban numeric(2) DEFAULT 0,readonly numeric(1) DEFAULT 0,CONSTRAINT pk_xn_bv_chitiet PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_bv_chitiet OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_bv_vitrung(id numeric(5) NOT NULL DEFAULT 0, id_vitrung numeric(5) NOT NULL DEFAULT 0,stt numeric(5) DEFAULT 0,ma varchar(10),ten text, viettat text, gram varchar(10),status varchar(10),id_giavp numeric(7), readonly numeric(1) DEFAULT 0,CONSTRAINT pk_xn_bv_vitrung PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_bv_vitrung OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_bv_khangsinh(id numeric(7) NOT NULL DEFAULT 0,id_bv_vitrung numeric(5) DEFAULT 0,stt numeric(7) DEFAULT 0,id_khangsinh numeric(7) DEFAULT 0,maxr numeric(10) DEFAULT 0,mins numeric(10) DEFAULT 0, hamluong text, readonly numeric(1) DEFAULT 0,CONSTRAINT pk_xn_bv_khangsinh PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_bv_khangsinh OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_phanquyen(userid numeric(5), menuname text, chon numeric(1) DEFAULT 0, chitiet text, CONSTRAINT pk_xn_phanquyen PRIMARY KEY (userid,menuname)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_phanquyen OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_phanquyennhom(id_nhom numeric(5), menuname text, chon numeric(1) DEFAULT 0, chitiet text, CONSTRAINT pk_xn_phanquyennhom PRIMARY KEY (id_nhom,menuname)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_phanquyennhom OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_gram_vt(ma varchar(10),ten text,readonly numeric(1) DEFAULT 0, CONSTRAINT pk_xn_gram_vt PRIMARY KEY (ma)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_gram_vt OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_status_vt(ma varchar(10), ten text, readonly numeric(1) DEFAULT 0,CONSTRAINT pk_xn_status_vt PRIMARY KEY (ma)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_status_vt OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_viettatkq(stt numeric(7), ma text, ten text, readonly numeric(1) DEFAULT 0,CONSTRAINT pk_xn_viettatkq PRIMARY KEY (ma)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_viettatkq OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_viettat(stt numeric(7), ma text, ten text, readonly numeric(1) DEFAULT 0,CONSTRAINT pk_xn_viettat PRIMARY KEY (ma)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_viettat OWNER TO " + m_db_database + "");

                execute_data("create table " + m_db_schemaroot + ".xn_option(ma text, val text, constraint pk_xn_option primary key(ma)) with oids");
                execute_data("alter table " + m_db_schemaroot + ".xn_option owner to " + m_db_database + "");

                execute_data("create table " + m_db_schemaroot + ".xn_optionform(userid numeric(5), loai numeric(2), ma text, ten text,giatri text, constraint pk_xn_optionform primary key(userid,loai,ma)) with oids");
                execute_data("alter table " + m_db_schemaroot + ".xn_optionform owner to " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".xn_treemenu(id numeric(5), id_cha numeric(5), stt numeric(5), ten text, sql text, tenfield text, captionfield text, width text, report text,readonly numeric(1) default 0, CONSTRAINT pk_xn_treemenu PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".xn_treemenu OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".xn_null(id text, ten text, readonly numeric(1) default 0, CONSTRAINT pk_xn_null PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".xn_null OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".xn_dmnuoicay(id numeric(11),CONSTRAINT pk_xn_dmnuoicay PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".xn_dmnuoicay OWNER TO " + m_db_database + "");
            }
            catch
            {
            }
        }
        public bool bMmyy(string m_mmyy)
        {
            return get_data("select * from medibv.table where mmyy='" + ((m_mmyy.Trim().Length == 4) ? m_mmyy : get_mmyy(m_mmyy)) + "'").Tables[0].Rows.Count > 0;
        }
        public void create_tables_xn_mmyy(string v_mmyy)
        {
            try
            {
                string a_schema = s_schema_mmyy(v_mmyy);

                execute_data("CREATE TABLE " + a_schema + ".xn_error(message text,computer varchar(20),tables varchar(20),ngayud timestamp) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_error OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_phieu_ctc(id numeric(12) NOT NULL DEFAULT 0,sophieu numeric(5) DEFAULT 0,mabn varchar(10),maql numeric DEFAULT 0,idkhoa numeric(11) DEFAULT 0,ngay timestamp,makp varchar(2),mabs varchar(4),loaibn numeric(1) DEFAULT 0,tinhtrang numeric(1) DEFAULT 0,loai numeric(1) DEFAULT 0,maicd varchar(9),madoituong numeric(1) DEFAULT 0,ktv varchar(4),ngayra timestamp,mabsdoc varchar(4),ghichu text,nhanxet text,ketluan text,denghi text,mabenhpham text,userid numeric(5) DEFAULT 0,ngayud timestamp,stt text,lanin numeric DEFAULT 0,ngaylaymau timestamp DEFAULT now(), mavp numeric(7) default 0, cd_para text, cd_vitri1 numeric(1) default 0, cd_vitri2 numeric(1) default 0, cd_vitri3 numeric(1) default 0,cd_ngaykinh text,cd_thai numeric(1) default 0, cd_dieutri numeric(1) default 0, cd_lamsang text, cd_soi text, cd_gpb text, cd_tebao1 text, cd_tebao2 text, cd_tebao3 text, cd_ngaygui text,cd_ngaynhan text, cd_mabs text, kq_danhgia numeric(1) default 0, kq_lydo text, kq_diengiai numeric(1) default 0, kq_diengiai1 text, kq_nt1 numeric(1) default 0 , kq_nt2 numeric(1) default 0 , kq_nt3 numeric(1) default 0, kq_nt4 numeric(1) default 0 , kq_nt5 numeric(1) default 0, kq_nt6 numeric(1) default 0, kq_pu1 numeric(1) default 0 ,kq_pu2 numeric(1) default 0 ,kq_pu3 numeric(1) default 0 ,kq_pu4 numeric(1) default 0 ,kq_pu5 numeric(1) default 0 ,kq_tbg1 numeric(1) default 0 ,kq_tbg2 numeric(1) default 0 ,kq_tbg3 numeric(1) default 0 ,kq_tbg4 numeric(1) default 0 ,kq_tbg5 numeric(1) default 0 ,kq_tbg6 numeric(1) default 0 ,kq_tbt1 numeric(1) default 0 ,kq_tbt2 numeric(1) default 0 ,kq_tbt3 numeric(1) default 0 ,kq_tbt4 numeric(1) default 0 ,kq_tbt5 numeric(1) default 0 , CONSTRAINT pk_xn_phieu_ctc PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_phieu_ctc OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_phieu(id numeric(12) NOT NULL DEFAULT 0,sophieu numeric(5) DEFAULT 0,mabn varchar(10),maql numeric DEFAULT 0,idkhoa numeric(11) DEFAULT 0,ngay timestamp,makp varchar(2),mabs varchar(4),loaibn numeric(1) DEFAULT 0,tinhtrang numeric(1) DEFAULT 0,loai numeric(1) DEFAULT 0,maicd varchar(9),madoituong numeric(1) DEFAULT 0,ktv varchar(4),ngayra timestamp,mabsdoc varchar(4),ghichu text,nhanxet text,ketluan text,denghi text,mabenhpham text,userid numeric(5) DEFAULT 0,ngayud timestamp,stt text,lanin numeric DEFAULT 0,ngaylaymau timestamp DEFAULT now(),CONSTRAINT pk_xn_phieu PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_phieu OWNER TO " + m_db_database + "");
              
                execute_data("CREATE TABLE " + a_schema + ".xn_phieu_done(id numeric(11) NOT NULL DEFAULT 0,id_chidinh numeric(12) NOT NULL DEFAULT 0, id_vpkhoa numeric(12) default 0, CONSTRAINT pk_xn_phieu_done PRIMARY KEY (id,id_chidinh)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_phieu_done OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_phieu_ktv(id numeric(11) NOT NULL DEFAULT 0, ktv varchar(4), tyle numeric(4,2) default 0, CONSTRAINT pk_xn_phieu_ktv PRIMARY KEY (id,ktv)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_phieu_ktv OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_ketqua(id numeric(12) NOT NULL DEFAULT 0,id_ten numeric(7) NOT NULL DEFAULT 0,idvienphi numeric(12) DEFAULT 0,idduoc numeric(12) DEFAULT 0,ketqua text,ghichu text,done numeric(1) DEFAULT 0,id_may numeric(5) DEFAULT 0,CONSTRAINT pk_xn_ketqua PRIMARY KEY (id, id_ten)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_ketqua OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_ksd(id numeric(12) NOT NULL DEFAULT 0,id_phieu numeric(12) DEFAULT 0,id_bv_vitrung numeric(5) DEFAULT 0, id_mauthu numeric(4) default 0, maso_mt varchar(10), gram varchar(1), ketqua text,CONSTRAINT pk_xn_ksd PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_ksd OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_ketqua_ksd(id numeric(12) NOT NULL DEFAULT 0,id_ksd numeric(12) DEFAULT 0,id_khangsinh numeric(7) DEFAULT 0,bankinh numeric(10) DEFAULT 0,sir varchar(1),maxr numeric(10) default 0,mins numeric(10) default 0, CONSTRAINT pk_xn_ketqua_ksd PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_ketqua_ksd OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_laymau(id numeric(11) NOT NULL DEFAULT 0,mabn varchar(10),maql numeric DEFAULT 0,id_mauthu numeric(4) DEFAULT 0,id_tinhtrang numeric(1) DEFAULT 0,ngay timestamp,soluong numeric(7) DEFAULT 0,ktv varchar(4),id_vitri numeric(4) DEFAULT 0,id_diadiem numeric(4) DEFAULT 0,cothai numeric(1) DEFAULT 0,ghichu text, mavach text,userid numeric(5) DEFAULT 0, loaibn numeric(1) default 0, loai numeric(1) default 0, madoituong numeric(1) default 2, readonly numeric(1) default 0, CONSTRAINT pk_xn_laymau PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_laymau OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_laymau_done(id numeric(11) NOT NULL DEFAULT 0,id_chidinh numeric(12) NOT NULL DEFAULT 0, id_vpkhoa numeric(12) default 0, CONSTRAINT pk_xn_laymau_done PRIMARY KEY (id,id_chidinh)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_laymau_done OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_nhuomgram(id numeric(12) NOT NULL DEFAULT 0,id_phieu numeric(12) DEFAULT 0,id_mauthu numeric(4) DEFAULT 0,gram varchar(10),CONSTRAINT pk_xn_nhuomgram PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_nhuomgram OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_vpkhoa(id numeric(7) NOT NULL DEFAULT 0,id_phieu numeric(12) DEFAULT 0,mabn varchar(10),maql numeric DEFAULT 0,id_bv_chitiet numeric(17) DEFAULT 0,mavp numeric(7) DEFAULT 0,soluong numeric(10) DEFAULT 0,dongia numeric(12) DEFAULT 0,idvpkhoa numeric(12) DEFAULT 0,CONSTRAINT pk_xn_vpkhoa PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_vpkhoa OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_done(id numeric(12) NOT NULL DEFAULT 0,mabn varchar(10),maql numeric DEFAULT 0,ngaycd timestamp,maxnvp text,mavp numeric(7) DEFAULT 0,ngayxn timestamp,done numeric(1) DEFAULT 0,CONSTRAINT pk_xn_done PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_done OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + a_schema + ".xn_hoachatbn(id numeric(12) NOT NULL DEFAULT 0,id_phieu numeric(12) DEFAULT 0,mabn varchar(10),maql numeric DEFAULT 0,id_bv_chitiet numeric(11) DEFAULT 0,mahc numeric(7) DEFAULT 0,soluong numeric(10) DEFAULT 0, slquidoi numeric(10) DEFAULT 0,id_xtutrucll numeric(12) DEFAULT 0,idduyet numeric(12) DEFAULT 0,CONSTRAINT pk_xn_hoachatbn PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_hoachatbn OWNER TO " + m_db_database + "");
            }
            catch
            {
            }

        }
        public void modify_tables_xn(string v_mmyy)
        {
            try
            {
                string a_schema = s_schema_mmyy(v_mmyy),sql="";

                execute_data("ALTER TABLE medibv.xn_capid drop CONSTRAINT pk_xn_capid");
                execute_data("ALTER TABLE medibv.xn_capid ADD CONSTRAINT pk_xn_capid PRIMARY KEY (ma, computer)");
                execute_data("ALTER TABLE medibv.xn_ten ADD PRIMARY KEY (id)");
                execute_data("ALTER TABLE medibv.xn_capid ALTER computer TYPE character varying(254)");
                execute_data("ALTER TABLE medibv.d_capid ALTER ten TYPE character varying(254)");
                execute_data("ALTER TABLE medibv.d_capid ALTER computer TYPE character varying(254)");
                sql = "CREATE TABLE medibv.xn_ten_ct (id serial,id_xn_ten numeric DEFAULT 0,tuoitu numeric(3),tuoiden numeric(3),";
                sql += " loaituoi numeric(1),csbt_nam varchar(50), mincsbt_nam numeric(10,4) DEFAULT 0, maxcsbt_nam numeric(10,4) DEFAULT 0, ";
                sql += " csbt_nu varchar(50),mincsbt_nu numeric(10,4) DEFAULT 0, maxcsbt_nu numeric(10,4) DEFAULT 0, ";
                sql += " cs_nguycap varchar(50),mincs_nc numeric(10,4) DEFAULT 0,maxcs_nc numeric(10,4) DEFAULT 0,primary key(id),userid numeric(5) DEFAULT 0,ngayud timestamp DEFAULT now(),FOREIGN KEY (id_xn_ten) REFERENCES medibv.xn_ten (id) )";
                if (get_data("SELECT relname FROM pg_class WHERE relname = 'xn_ten_ct'").Tables[0].Rows.Count == 0)
                {
                    execute_data(sql);
                }
                sql = "";
                sql = "CREATE TABLE medibv.xn_worksheetll(id serial,ma varchar(5),tenws varchar(50),id_mayxn numeric DEFAULT 0,sl_mau numeric(5) DEFAULT 0,sl_test numeric(5) DEFAULT 0,userid numeric(5) DEFAULT 0  , ngayud timestamp DEFAULT now(), primary key(id)) ";
                if (get_data("SELECT relname FROM pg_class WHERE relname = 'xn_worksheetll'").Tables[0].Rows.Count == 0)
                {
                    execute_data(sql);
                }
                sql = "CREATE TABLE medibv.xn_worksheetct(id numeric default 0,stt numeric default 0,id_xn_ten numeric DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp DEFAULT now(),primary key(id,id_xn_ten)) ";
                if (get_data("SELECT relname FROM pg_class WHERE relname = 'xn_worksheetct'").Tables[0].Rows.Count == 0)
                {
                    execute_data(sql);
                }


                sql = "CREATE TABLE medibv.xn_noigoimau(id numeric default 0,ten varchar(50),diachi varchar(100) , ngayud timestamp DEFAULT now(), primary key(id)) ";
                if (get_data("SELECT relname FROM pg_class WHERE relname = 'xn_noigoimau'").Tables[0].Rows.Count == 0)
                {
                    execute_data(sql);
                }
                sql = "CREATE TABLE medibv.xn_worksheetct(id numeric default 0,stt numeric default 0,id_xn_ten numeric DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp DEFAULT now(),primary key(id,id_xn_ten)) ";

                if (get_data(" SELECT attname FROM pg_attribute WHERE attrelid = (SELECT oid FROM pg_class WHERE relname = 'xn_donvi') AND attname = 'ten1'").Tables[0].Rows.Count==0)
                {
                    execute_data("alter table " + m_db_schemaroot + ".xn_donvi add ten1 text");
                    execute_data("alter table " + m_db_schemaroot + ".xn_donvi add heso numeric(6,4) default 0");
                }

                sql = " CREATE TABLE medibv.xn_donvi_dinhmuc (id numeric(5) NOT NULL DEFAULT 0, stt numeric(5) DEFAULT 0, ma character varying(30),ten text,anh text,readonly numeric(1) DEFAULT 0, constraint pk_xn_donvi_dinhmuc primary key(id))WITH OIDS; ALTER TABLE medibv.xn_donvi_dinhmuc OWNER TO medisoft; ";
                if (get_data("SELECT relname FROM pg_class WHERE relname = 'xn_donvi_dinhmuc'").Tables[0].Rows.Count == 0)
                {
                    execute_data(sql);
                }

                if (get_data(" SELECT attname FROM pg_attribute WHERE attrelid = (SELECT oid FROM pg_class WHERE relname = 'xn_ten') AND attname = 'cs_nguycap'").Tables[0].Rows.Count == 0)
                {
                    execute_data("alter table " + m_db_schemaroot + ".xn_ten add cs_nguycap varchar(50)");
                    execute_data("alter table " + m_db_schemaroot + ".xn_ten add min_csnuycap numeric(10,4) default 0");
                    execute_data("alter table " + m_db_schemaroot + ".xn_ten add max_csnuycap numeric(10,4) default 0");
                }
                try
                {
                    //if (get_data("select id_bv_chitiet1 from medibv.xn_thongsomay where id_bv_chitiet1<>''").Tables[0].Rows.Count < 0)
                    //{
                    if (get_data(" SELECT attname FROM pg_attribute WHERE attrelid = (SELECT oid FROM pg_class WHERE relname = 'xn_thongsomay') AND attname = 'id_bv_chitiet1'").Tables[0].Rows.Count == 0)
                    {
                        execute_data("alter table medibv.xn_thongsomay add id_bv_chitiet1 varchar(50) ");
                        execute_data("update medibv.xn_thongsomay set id_bv_chitiet1=id_bv_chitiet||','");
                    }
                }
                catch
                {
                    execute_data("alter table medibv.xn_thongsomay add id_bv_chitiet1 varchar(50) ");
                    execute_data("update medibv.xn_thongsomay set id_bv_chitiet1=id_bv_chitiet||','");
                }

                execute_data("alter table " + m_db_schemaroot + ".xn_donvi add ten1 text");
                execute_data("alter table " + m_db_schemaroot + ".xn_donvi add heso numeric(6,4) default 0");
                execute_data("alter table " + a_schema + ".xn_phieu alter column maql type numeric");
                execute_data("alter table " + a_schema + ".xn_vpkhoa alter column maql type numeric");
                execute_data("alter table " + a_schema + ".xn_laymau alter column maql type numeric");
                execute_data("alter table " + a_schema + ".xn_done alter column maql type numeric");
                execute_data("alter table " + a_schema + ".xn_ketqua add column id_may numeric(5) default 0");
                execute_data("alter table " + a_schema + ".xn_error rename massage to message");
                execute_data("alter table " + a_schema + ".xn_laymau rename column makt to ktv");
                execute_data("alter table " + a_schema + ".xn_laymau add column loaibn numeric(1) default 0");
                execute_data("alter table " + a_schema + ".xn_laymau add column loai numeric(1) default 0");
                execute_data("alter table " + a_schema + ".xn_laymau add readonly numeric(1) default 0");
                execute_data("alter table " + a_schema + ".xn_laymau add column madoituong numeric(1) default 2");
                execute_data("alter table " + a_schema + ".xn_phieu add column nhanxet text");
                execute_data("alter table " + a_schema + ".xn_phieu add column ketluan text");
                execute_data("alter table " + a_schema + ".xn_phieu add column denghi text");
                execute_data("alter table " + a_schema + ".xn_phieu add column mabenhpham text");
                execute_data("alter table " + a_schema + ".xn_phieu add stt text");
                execute_data("alter table " + a_schema + ".xn_phieu add lanin numeric default 0");
                execute_data("alter table " + a_schema + ".xn_phieu add ngaylaymau timestamp DEFAULT now()");
                execute_data("CREATE TABLE " + a_schema + ".xn_phieu_done(id numeric(11) NOT NULL DEFAULT 0,id_chidinh numeric(12) NOT NULL DEFAULT 0, id_vpkhoa numeric(12) default 0, CONSTRAINT pk_xn_phieu_done PRIMARY KEY (id,id_chidinh)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_phieu_done OWNER TO " + m_db_database + "");
                execute_data("CREATE TABLE " + a_schema + ".xn_laymau_done(id numeric(11) NOT NULL DEFAULT 0,id_chidinh numeric(12) NOT NULL DEFAULT 0, id_vpkhoa numeric(12) default 0, CONSTRAINT pk_xn_laymau_done PRIMARY KEY (id,id_chidinh)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_laymau_done OWNER TO " + m_db_database + "");
                execute_data("ALTER TABLE " + a_schema + ".xn_ksd add id_mauthu numeric(4) DEFAULT 0");
                execute_data("ALTER TABLE " + a_schema + ".xn_ksd add maso_mt varchar(10)");
                execute_data("ALTER TABLE " + a_schema + ".xn_ksd add gram varchar(1)");
                execute_data("ALTER TABLE " + a_schema + ".xn_ksd add ketqua text");
                execute_data("ALTER TABLE " + a_schema + ".xn_ketqua_ksd add maxr numeric(10) DEFAULT 0");
                execute_data("ALTER TABLE " + a_schema + ".xn_ketqua_ksd add mins numeric(10) DEFAULT 0");
                execute_data("ALTER TABLE " + a_schema + ".xn_ksd add mavp numeric(7) DEFAULT 0");


                execute_data("CREATE TABLE " + m_db_schemaroot + ".xn_dmnuoicay(id numeric(11),CONSTRAINT pk_xn_dmnuoicay PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".xn_dmnuoicay OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".xn_nhomdlogin(id numeric(5),nhom numeric(1),ma varchar(20), ten text, diengiai text, id_bv_so varchar(4000),right_ varchar(4000), readonly numeric(1) DEFAULT 0,CONSTRAINT pk_xn_nhomdlogin PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".xn_nhomdlogin OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".xn_phanquyen(userid numeric(5), menuname text, chon numeric(1) DEFAULT 0, chitiet text, CONSTRAINT pk_xn_phanquyen PRIMARY KEY (userid,menuname)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".xn_phanquyen OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".xn_phanquyennhom(id_nhom numeric(5), menuname text, chon numeric(1) DEFAULT 0, chitiet text, CONSTRAINT pk_xn_phanquyennhom PRIMARY KEY (id_nhom,menuname)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".xn_phanquyennhom OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".xn_hoachat(id numeric(7) NOT NULL DEFAULT 0,id_ten numeric(7) DEFAULT 0,mahc numeric(7) DEFAULT 0,soluong numeric(10) DEFAULT 0,soluongqd numeric(10) DEFAULT 0,readonly numeric(1) DEFAULT 0, CONSTRAINT pk_xn_hoachat PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".xn_hoachat OWNER TO " + m_db_database + "");

                execute_data("alter table " + m_db_schemaroot + ".xn_capid add computer character varying(20) NOT NULL DEFAULT '?'::character varying");
                execute_data("alter table " + m_db_schemaroot + ".xn_capid add ngayud timestamp without time zone DEFAULT now()");

                execute_data("create table " + m_db_schemaroot + ".xn_option(ma text, val text, constraint pk_xn_option primary key(ma)) with oids");
                execute_data("alter table " + m_db_schemaroot + ".xn_option owner to " + m_db_database + "");

                execute_data("create table " + m_db_schemaroot + ".xn_optionform(userid numeric(5), loai numeric(2), ma text, ten text,giatri text, constraint pk_xn_optionform primary key(userid,loai,ma)) with oids");
                execute_data("alter table " + m_db_schemaroot + ".xn_optionform owner to " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".xn_treemenu(id numeric(5), id_cha numeric(5), stt numeric(5), ten text, sql text, tenfield text, captionfield text, width text, report text,readonly numeric(1) default 0, CONSTRAINT pk_xn_treemenu PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".xn_treemenu OWNER TO " + m_db_database + "");

                execute_data("CREATE TABLE " + m_db_schemaroot + ".xn_null(id text, ten text, readonly numeric(1) default 0, CONSTRAINT pk_xn_null PRIMARY KEY (id)) WITH OIDS");
                execute_data("ALTER TABLE " + m_db_schemaroot + ".xn_null OWNER TO " + m_db_database + "");

                execute_data("alter table " + m_db_schemaroot + ".xn_dlogin rename so to id_bv_so");
                execute_data("alter table " + m_db_schemaroot + ".xn_dlogin rename id_bv_so to id_bv_so1");
                execute_data("alter table " + m_db_schemaroot + ".xn_dlogin add id_bv_so varchar(4000)");
                execute_data("update " + m_db_schemaroot + ".xn_dlogin set id_bv_so=id_bv_so1");
                execute_data("alter table " + m_db_schemaroot + ".xn_dlogin drop column id_bv_so1");
                execute_data("alter table " + m_db_schemaroot + ".xn_dlogin drop column so");
                // thang
                execute_data("alter table " + m_db_schemaroot + ".xn_dlogin add makp character varying(2)");
                //

                execute_data("alter table " + m_db_schemaroot + ".xn_nhomdlogin rename so to id_bv_so");
                execute_data("alter table " + m_db_schemaroot + ".xn_nhomdlogin rename id_bv_so to id_bv_so1");
                execute_data("alter table " + m_db_schemaroot + ".xn_nhomdlogin add id_bv_so varchar(4000)");
                execute_data("update " + m_db_schemaroot + ".xn_dlogin set id_bv_so=id_bv_so1");
                execute_data("alter table " + m_db_schemaroot + ".xn_nhomdlogin drop column id_bv_so1");
                execute_data("alter table " + m_db_schemaroot + ".xn_nhomdlogin drop column so");

                execute_data("alter table " + m_db_schemaroot + ".xn_error rename massage to message");
                execute_data("alter table " + m_db_schemaroot + ".xn_vitrung add viettat text");
                execute_data("alter table " + m_db_schemaroot + ".xn_khangsinh add viettat text");
                execute_data("alter table " + m_db_schemaroot + ".xn_mauthu add viettat text");
                execute_data("alter table " + m_db_schemaroot + ".xn_sdmauthu add readonly numeric(1) DEFAULT 0");
                execute_data("alter table " + m_db_schemaroot + ".xn_hoachat add readonly numeric(1) DEFAULT 0");
                execute_data("alter table " + m_db_schemaroot + ".xn_hoachat rename slquidoi to soluongqd");
                execute_data("alter table " + m_db_schemaroot + ".xn_vitri add viettat text");
                execute_data("alter table " + m_db_schemaroot + ".xn_vitri add mabv varchar(10)");
                execute_data("alter table " + m_db_schemaroot + ".xn_diadiem add viettat text");
                execute_data("alter table " + m_db_schemaroot + ".xn_ktv add viettat text");
                execute_data("alter table " + m_db_schemaroot + ".xn_ktv add readonly numeric(1) DEFAULT 0");
                execute_data("alter table " + m_db_schemaroot + ".xn_khangsinh add mabv varchar(10)");
                execute_data("alter table " + m_db_schemaroot + ".xn_mauthu add mabv varchar(10)");
                execute_data("alter table " + m_db_schemaroot + ".xn_dlogin add id_nhom numeric(5) DEFAULT 0");
                execute_data("alter table " + m_db_schemaroot + ".xn_so add viettat text");
                execute_data("alter table " + m_db_schemaroot + ".xn_nhom add viettat text");
                execute_data("alter table " + m_db_schemaroot + ".xn_loai add viettat text");
                execute_data("alter table " + m_db_schemaroot + ".xn_ten add viettat text");
                execute_data("alter table " + m_db_schemaroot + ".xn_ten add tieuban numeric(2) default 0");
                execute_data("alter table " + m_db_schemaroot + ".xn_bv_so add viettat text");
                execute_data("alter table " + m_db_schemaroot + ".xn_bv_so rename rpt to tenreport");
                execute_data("alter table " + m_db_schemaroot + ".xn_bv_ten add viettat text");
                execute_data("alter table " + m_db_schemaroot + ".xn_bv_chitiet add viettat text");
                execute_data("alter table " + m_db_schemaroot + ".xn_bv_chitiet add readonly numeric(1) DEFAULT 0");
                execute_data("alter table " + m_db_schemaroot + ".xn_bv_vitrung add viettat text");
                execute_data("alter table " + m_db_schemaroot + ".xn_bv_vitrung add tenboks text");
                execute_data("alter table " + m_db_schemaroot + ".xn_bv_khangsinh add hamluong text");
                execute_data("alter table " + m_db_schemaroot + ".xn_bv_ten add dvt text");

                //delta_chk=:v_delta,tg_tinh=:v_thoigian
                execute_data("alter table " + m_db_schemaroot + ".xn_ten add delta_chk numeric");
                execute_data("alter table " + m_db_schemaroot + ".xn_ten add tg_tinh numeric");
                //f_add_colum(m_db_schemaroot,"xn_ten","

                execute_data("delete from " + s_schemaroot + ".v_loaibn");
                execute_data("insert into " + s_schemaroot + ".v_loaibn (id,ten) values(0,'Tiếp đón')");
                execute_data("insert into " + s_schemaroot + ".v_loaibn (id,ten) values(1,'Nội trú')");
                execute_data("insert into " + s_schemaroot + ".v_loaibn (id,ten) values(2,'Ngoại trú')");
                execute_data("insert into " + s_schemaroot + ".v_loaibn (id,ten) values(3,'Phòng khám')");
                execute_data("insert into " + s_schemaroot + ".v_loaibn (id,ten) values(4,'Phòng lưu')");
                execute_data("alter table " + s_schemaroot + ".xn_hoachatdm drop constraint pk_xn_hoachatdm");
                execute_data("alter table " + s_schemaroot + ".xn_hoachatdm drop column id");
                execute_data("alter table " + s_schemaroot + ".xn_hoachatdm drop column stt");
                execute_data("alter table " + s_schemaroot + ".xn_hoachatdm add constraint pk_xn_hoachatdm primary key (id_ten,mahc)");
                execute_data("alter table " + s_schemaroot + ".xn_hoachatdm add column dvt numeric(2) default 1");
                execute_data("ALTER TABLE " + s_schemaroot + ".xn_hoachatdm ALTER soluong TYPE numeric(10, 5) ");
                //xn_ktv
                execute_data("alter table " + s_schemaroot + ".xn_ktv alter column ma type varchar(15)");
                execute_data("alter table " + s_schemaroot + ".xn_ktv add column chucvu numeric(2) default 0");
                execute_data("alter table " + s_schemaroot + ".xn_ktv add column duyetmau numeric(2) default 0");
                execute_data("alter table " + s_schemaroot + ".xn_ktv add column passwd varchar(15) default 0");
                execute_data("alter table " + s_schemaroot + ".xn_ktv add column id serial");
                execute_data("alter table " + s_schemaroot + ".xn_ktv add primary key (id)");
                execute_data("CREATE TABLE " + s_schemaroot + ".xn_bv_tentd(id_bv_ten numeric NOT NULL,id_bv_tentd numeric DEFAULT 0,ngayud timestamp DEFAULT now(),PRIMARY KEY (id_bv_ten,id_bv_tentd))");
                
                sql = "CREATE TABLE " + s_schemaroot + ".xn_kiemkehc(ngaykk timestamp,mahc varchar,slconlai numeric,userid  numeric,ngayud timestamp DEFAULT now(), mavach varchar, CONSTRAINT pk_xn_kiemkehc PRIMARY KEY (ngaykk, mahc, mavach) USING INDEX TABLESPACE medi_data) ";
                if (get_data("SELECT relname FROM pg_class WHERE relname = 'xn_kiemkehc'").Tables[0].Rows.Count == 0)
                {
                    execute_data(sql);
                }
                //execute_data(sql);

                sql = " create table " + s_schemaroot + ".xn_hcdangsudung(id_may numeric(5) default 0,mahc numeric(7) default 0,mavach text,vtdungchung numeric(1) default 0, ";
	            sql+=" soluong numeric (10) default 0,sudung numeric (1) default 0,userid numeric(5) DEFAULT 0,	ngayud timestamp without time zone DEFAULT now(),";
                sql += " constraint pk_xn_hcdangsudung primary key(id_may,mahc,mavach)) ";
                //medibv.xn_bv_ten

                if (get_data("SELECT relname FROM pg_class WHERE relname = 'xn_hcdangsudung'").Tables[0].Rows.Count == 0)
                {
                    execute_data(sql);
                }
                execute_data("alter table " + s_schemaroot + ".xn_bv_ten add primary key (id)");
                execute_data("alter table " + s_schemaroot + ".xn_bv_chitiet add primary key (id)");
                execute_data("alter table medibv.xn_bv_so add id_tutruc numeric(5) default 0");
                execute_data("alter table medibv.xn_kiemkehc add id_tutruc numeric(5) default 0");
                //sql = " create table " + s_schemaroot + ".xn_indsguimau(id serial,id_xnphieu numeric,id_xnten numeric,ngayin timestamp without time zone DEFAULT now(),in_tu timestamp,in_den timestamp,primary key(id))  ";
                //execute_data(sql);

                sql = " create table " + s_schemaroot + ".xn_daingui(id numeric(5),tenlanin varchar,ngayin timestamp without time zone ,primary key(id,ngayin))  ";
                execute_data(sql);
            }
            catch
            {
            }
        }
        public bool upd_xn_hcdangsudung(int m_id_may, int m_mahc, string m_mavach, string m_soluong, int m_userid, string m_vtdungchung)
        {
            m_sql = "insert into " + user + ".xn_hcdangsudung(id_may,mahc,mavach,userid,soluong,sudung,vtdungchung) values (" + m_id_may + "," + m_mahc + ",:m_mavach," + m_userid + "," + m_soluong + ",1," + m_vtdungchung + ")";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;
            m_command.Parameters.Add("m_mavach", NpgsqlDbType.Text).Value = m_mavach;

            try
            {
                m_connection.Open();
                m_command.ExecuteNonQuery();
                m_command.Dispose();
            }
            catch (NpgsqlException ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_hcdangsudung");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_hc(string _mmyy, decimal m_id, int m_id_ten, int m_mahc, string m_sttt, string m_mavach, string m_soluong, int m_userid)
        {
            m_sql = "insert into " + user + _mmyy + ".xn_hc(id,id_ten,mahc,sttt,mavach,soluong,userid) values (" + m_id.ToString() + "," + m_id_ten.ToString() + "," + m_mahc.ToString() + "," + m_sttt + "," + m_mavach + "," + m_soluong + "," + m_userid + ")";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            try
            {
                m_connection.Open();
                m_command.ExecuteNonQuery();
                m_command.Dispose();
            }
            catch (NpgsqlException ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_hc");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }

        public bool upd_xn_kiemkehc(string mahc, string mavach, decimal soluong, string ngay, int userid, string tutruc)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_kiemkehc set slconlai=:soluong,mavach=:mavach,id_tutruc=" + tutruc + " where ngaykk=to_date(:ngay,'dd/mm/yyyy') and mahc=:mahc and mavach=:mavach";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("soluong", NpgsqlDbType.Numeric).Value = soluong;
            m_command.Parameters.Add("mavach", NpgsqlDbType.Varchar).Value = mavach;
            m_command.Parameters.Add("ngay", NpgsqlDbType.Text).Value = ngay;
            m_command.Parameters.Add("mahc", NpgsqlDbType.Varchar).Value = mahc;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_kiemkehc(mahc,slconlai,mavach,ngaykk,userid,id_tutruc) values(:mahc,:soluong,:mavach,to_date(:ngay,'dd/mm/yyyy'),:userid," + tutruc + ")";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("mahc", NpgsqlDbType.Varchar).Value = mahc;
                    m_command.Parameters.Add("soluong", NpgsqlDbType.Numeric).Value = soluong;
                    m_command.Parameters.Add("mavach", NpgsqlDbType.Varchar).Value = mavach;
                    m_command.Parameters.Add("ngay", NpgsqlDbType.Text).Value = ngay;
                    m_command.Parameters.Add("userid", NpgsqlDbType.Numeric).Value = userid;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_kiemkehc");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }

        public void upd_noigoimau(int ma, string ten, string diachi)
        {
            m_sql = "update " + user + ".xn_noigoimau set ten=:ten,diachi=:diachi where id=:id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            try
            {
                m_connection.Open();
                m_command = new NpgsqlCommand(m_sql, m_connection);
                m_command.CommandType = CommandType.Text;
                m_command.Parameters.Add("ten", NpgsqlDbType.Text).Value = ten;
                m_command.Parameters.Add("diachi", NpgsqlDbType.Text).Value = diachi;
                m_command.Parameters.Add("id", NpgsqlDbType.Numeric).Value = ma;
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + user + ".xn_noigoimau(id,ten,diachi) values (:id,:ten,:diachi)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("ten", NpgsqlDbType.Text).Value = ten;
                    m_command.Parameters.Add("diachi", NpgsqlDbType.Text).Value = diachi;
                    m_command.Parameters.Add("id", NpgsqlDbType.Numeric).Value = ma;
                    m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_xn_error(ex.Message.ToString().Trim(), m_computername, "xn_noigoimau");
            }
            finally
            {
                m_command.Dispose();
                m_connection.Close();

                m_connection.Dispose();
            }
        }
        public void modify_tables_xn_mmyy(string v_mmyy)
        {
            try
            {
                string aschema = m_db_schemaroot + v_mmyy;

                execute_data("alter table " + aschema + ".xn_phieu alter column maql type numeric");
                execute_data("alter table " + aschema + ".xn_vpkhoa alter column maql type numeric");
                execute_data("alter table " + aschema + ".xn_laymau alter column maql type numeric");
                execute_data("alter table " + aschema + ".xn_done alter column maql type numeric");
                if (get_data("SELECT relname FROM pg_class WHERE relname = 'xn_phieu_ctc'").Tables[0].Rows.Count == 0)
                {
                    execute_data("CREATE TABLE " + aschema + ".xn_phieu_ctc(id numeric(12) NOT NULL DEFAULT 0,sophieu numeric(5) DEFAULT 0,mabn varchar(10),maql numeric DEFAULT 0,idkhoa numeric(11) DEFAULT 0,ngay timestamp,makp varchar(2),mabs varchar(4),loaibn numeric(1) DEFAULT 0,tinhtrang numeric(1) DEFAULT 0,loai numeric(1) DEFAULT 0,maicd varchar(9),madoituong numeric(1) DEFAULT 0,ktv varchar(4),ngayra timestamp,mabsdoc varchar(4),ghichu text,nhanxet text,ketluan text,denghi text,mabenhpham text,userid numeric(5) DEFAULT 0,ngayud timestamp,stt text,lanin numeric DEFAULT 0,ngaylaymau timestamp DEFAULT now(), mavp numeric(7) default 0, cd_para text, cd_vitri1 numeric(1) default 0, cd_vitri2 numeric(1) default 0, cd_vitri3 numeric(1) default 0,cd_ngaykinh text,cd_thai numeric(1) default 0, cd_dieutri numeric(1) default 0, cd_lamsang text, cd_soi text, cd_gpb text, cd_tebao1 text, cd_tebao2 text, cd_tebao3 text, cd_ngaygui text,cd_ngaynhan text, cd_mabs text, kq_danhgia numeric(1) default 0, kq_lydo text, kq_diengiai numeric(1) default 0, kq_diengiai1 text, kq_nt1 numeric(1) default 0 , kq_nt2 numeric(1) default 0 , kq_nt3 numeric(1) default 0, kq_nt4 numeric(1) default 0 , kq_nt5 numeric(1) default 0, kq_nt6 numeric(1) default 0, kq_pu1 numeric(1) default 0 ,kq_pu2 numeric(1) default 0 ,kq_pu3 numeric(1) default 0 ,kq_pu4 numeric(1) default 0 ,kq_pu5 numeric(1) default 0 ,kq_tbg1 numeric(1) default 0 ,kq_tbg2 numeric(1) default 0 ,kq_tbg3 numeric(1) default 0 ,kq_tbg4 numeric(1) default 0 ,kq_tbg5 numeric(1) default 0 ,kq_tbg6 numeric(1) default 0 ,kq_tbt1 numeric(1) default 0 ,kq_tbt2 numeric(1) default 0 ,kq_tbt3 numeric(1) default 0 ,kq_tbt4 numeric(1) default 0 ,kq_tbt5 numeric(1) default 0 , CONSTRAINT pk_xn_phieu_ctc PRIMARY KEY (id)) WITH OIDS");
                }
                execute_data("ALTER TABLE " + aschema + ".xn_phieu_ctc OWNER TO " + m_db_database + "");
                if (get_data("SELECT attname FROM pg_attribute WHERE attrelid in (SELECT oid FROM pg_class WHERE relname = 'xn_ketqua') AND attname = 'id_may'").Tables[0].Rows.Count == 0)
                {
                    execute_data("alter table " + aschema + ".xn_ketqua add column id_may numeric(5) default 0");
                }
                execute_data("alter table " + aschema + ".xn_error rename massage to message");
                execute_data("alter table " + aschema + ".xn_laymau rename column makt to ktv");
                if (get_data("SELECT attname FROM pg_attribute WHERE attrelid in (SELECT oid FROM pg_class WHERE relname = 'xn_laymau') AND attname = 'loaibn'").Tables[0].Rows.Count == 0)
                {
                    execute_data("alter table " + aschema + ".xn_laymau add column loaibn numeric(1) default 0");
                }
                f_add_colum(aschema, "xn_laymau", "loai", "numeric", "1","default 0");
                //execute_data("alter table " + aschema + ".xn_laymau add column loai numeric(1) default 0");
                f_add_colum(aschema, "xn_laymau", "readonly", "numeric", "1", "default 0");
                //execute_data("alter table " + aschema + ".xn_laymau add readonly numeric(1) default 0");
                f_add_colum(aschema, "xn_laymau", "madoituong", "numeric", "1", "default 2");
                //execute_data("alter table " + aschema + ".xn_laymau add column madoituong numeric(1) default 2");
                f_add_colum(aschema, "xn_phieu", "nhanxet", "text", "", "");
                //execute_data("alter table " + aschema + ".xn_phieu add column nhanxet text");
                f_add_colum(aschema, "xn_phieu", "ketluan", "text", "", "");
               // execute_data("alter table " + aschema + ".xn_phieu add column ketluan text");
                f_add_colum(aschema, "xn_phieu", "denghi", "text", "", "");
                //execute_data("alter table " + aschema + ".xn_phieu add column denghi text");
                //execute_data("alter table " + aschema + ".xn_phieu add column mabenhpham text");
                f_add_colum(aschema, "xn_phieu", "mabenhpham", "text", "", "");
                //execute_data("alter table " + aschema + ".xn_phieu add stt text");
                f_add_colum(aschema, "xn_phieu", "stt", "text", "", "");
                //
                //execute_data("alter table " + aschema + ".xn_phieu add dalay_mau numeric(1) default 0");
                f_add_colum(aschema, "xn_phieu", "dalay_mau", "numeric", "1", "default 0");
                //execute_data("alter table " + aschema + ".xn_phieu add chandoan text default ''");
                f_add_colum(aschema, "xn_phieu", "chandoan", "text", "", "");
                //
                if (get_data("SELECT attname FROM pg_attribute WHERE attrelid in (SELECT oid FROM pg_class WHERE relname = 'xn_phieu') AND attname = 'lanin'").Tables[0].Rows.Count == 0)
                {
                    execute_data("alter table " + aschema + ".xn_phieu add lanin numeric default 0");
                }
                if (get_data("SELECT attname FROM pg_attribute WHERE attrelid in (SELECT oid FROM pg_class WHERE relname = 'xn_phieu') AND attname = 'ngaylaymau'").Tables[0].Rows.Count == 0)
                {
                    execute_data("alter table " + aschema + ".xn_phieu add ngaylaymau timestamp DEFAULT now()");
                }
                if (get_data("SELECT relname FROM pg_class WHERE relname = 'xn_phieu_done'").Tables[0].Rows.Count == 0)
                {
                    execute_data("CREATE TABLE " + aschema + ".xn_phieu_done(id numeric(11) NOT NULL DEFAULT 0,id_chidinh numeric(12) NOT NULL DEFAULT 0, id_vpkhoa numeric(12) default 0, CONSTRAINT pk_xn_phieu_done PRIMARY KEY (id,id_chidinh)) WITH OIDS");
                }            
                execute_data("ALTER TABLE " + aschema + ".xn_phieu_done OWNER TO " + m_db_database + "");
                if (get_data("SELECT relname FROM pg_class WHERE relname = 'xn_phieu_ktv'").Tables[0].Rows.Count == 0)
                {
                    execute_data("CREATE TABLE " + aschema + ".xn_phieu_ktv(id numeric(11) NOT NULL DEFAULT 0, ktv varchar(4), tyle numeric(4,2) default 0, CONSTRAINT pk_xn_phieu_ktv PRIMARY KEY (id,ktv)) WITH OIDS");
                }
                execute_data("ALTER TABLE " + aschema + ".xn_phieu_ktv OWNER TO " + m_db_database + "");
                if (get_data("SELECT relname FROM pg_class WHERE relname = 'xn_laymau_done'").Tables[0].Rows.Count == 0)
                {
                    execute_data("CREATE TABLE " + aschema + ".xn_laymau_done(id numeric(11) NOT NULL DEFAULT 0,id_chidinh numeric(12) NOT NULL DEFAULT 0, id_vpkhoa numeric(12) default 0, CONSTRAINT pk_xn_laymau_done PRIMARY KEY (id,id_chidinh)) WITH OIDS");
                }
                execute_data("ALTER TABLE " + aschema + ".xn_laymau_done OWNER TO " + m_db_database + "");
                
                //execute_data("ALTER TABLE " + aschema + ".xn_ksd add id_mauthu numeric(4) DEFAULT 0");
                f_add_colum(aschema, "xn_ksd", "id_mauthu", "numeric", "4", "default 0");
                //execute_data("ALTER TABLE " + aschema + ".xn_ksd add maso_mt varchar(10)");
                f_add_colum(aschema, "xn_ksd", "maso_mt", "varchar", "10", "");
                //execute_data("ALTER TABLE " + aschema + ".xn_ksd add gram varchar(1)");
                f_add_colum(aschema, "xn_ksd", "gram", "varchar", "1", "");

                //execute_data("ALTER TABLE " + aschema + ".xn_ksd add ketqua text");
                f_add_colum(aschema, "xn_ksd", "ketqua", "text", "", "");
                //execute_data("ALTER TABLE " + aschema + ".xn_ketqua_ksd add maxr numeric(10) DEFAULT 0");
                f_add_colum(aschema, "xn_ketqua_ksd", "maxr", "numeric", "10", "DEFAULT 0");
                //execute_data("ALTER TABLE " + aschema + ".xn_ketqua_ksd add mins numeric(10) DEFAULT 0");
                f_add_colum(aschema, "xn_ketqua_ksd", "mins", "numeric", "10", "DEFAULT 0");
                //execute_data("alter table " + m_db_schemaroot + ".xn_bv_ten add dvt text");
                f_add_colum(m_db_schemaroot, "xn_bv_ten", "dvt", "text", "", "");
                if (get_data("SELECT attname FROM pg_attribute WHERE attrelid in (SELECT oid FROM pg_class WHERE relname = 'xn_phieu') AND attname = 'chandoan'").Tables[0].Rows.Count == 0)
                {
                    execute_data("alter table " + aschema + ".xn_phieu add chandoan text");
                }
              
                //execute_data("alter table " + aschema + ".xn_phieu add traketqua numeric(1)");
                f_add_colum(aschema, "xn_phieu", "traketqua", "numeric", "1", "default 0");
                //execute_data("alter table " + aschema + ".xn_ketqua add ketqua_hople numeric(1) default 0 ");
                f_add_colum(aschema, "xn_ketqua", "ketqua_hople", "numeric", "1", "default 0");
                //execute_data("alter table " + aschema + ".xn_ketqua add ketqua_ori text default ''");
                f_add_colum(aschema, "xn_ketqua", "ketqua_ori", "text", "", "");
                //userd
                //execute_data("alter table " + aschema + ".xn_ketqua add  userd numeric default 0");
                f_add_colum(aschema, "xn_ketqua", "userd", "numeric", "", "default 0");
                //if (get_data("SELECT relname FROM pg_class WHERE relname = 'xn_maubenhpham_ct'").Tables[0].Rows.Count == 0)
                //{

                execute_data("CREATE TABLE " + aschema + ".xn_maubenhpham_ct(id_xnphieu numeric NOT NULL,id_mauthu numeric DEFAULT -1,id_vatchuamau numeric DEFAULT 0,soluong numeric DEFAULT 0,chatluongmau numeric(1) DEFAULT 0,Ghichu varchar(200) default '',laymaulai numeric(1) DEFAULT 0,userid numeric DEFAULT 0,userD numeric DEFAULT 0,ngayud timestamp DEFAULT now(),PRIMARY KEY (id_xnphieu,id_mauthu,id_vatchuamau))");
                //}
                //if (get_data("SELECT relname FROM pg_class WHERE relname = 'xn_worksheet'").Tables[0].Rows.Count == 0)
                //{
                execute_data("CREATE TABLE " + aschema + ".xn_worksheet(id serial,ma varchar(20),id_master numeric NOT NULL, ngay timestamp,userid numeric DEFAULT 0, PRIMARY KEY (id) )");
                //}

                execute_data("ALTER TABLE " + aschema + ".xn_laymau_done OWNER TO " + m_db_database + "");

                //if (get_data("SELECT relname FROM pg_class WHERE relname = 'xn_worksheet_ct'").Tables[0].Rows.Count == 0)
               // {
                execute_data("CREATE TABLE " + aschema + ".xn_worksheet_ct(id numeric NOT NULL,id_xn_phieu numeric NOT NULL,id_xn_ten numeric NOT NULL,stt numeric ,userid numeric DEFAULT 0, PRIMARY KEY (id,id_xn_phieu,id_xn_ten) )");
                //}
                f_add_colum(aschema, "xn_ketqua", "wsheet", "numeric", "1", "default 0");
                f_add_colum(aschema, "xn_ketqua", "ma_wsheet", "varchar", "20", "default ''");
                f_add_colum(aschema, "xn_ketqua", "yt_anhhuong", "text", "", "");
                f_add_colum(aschema, "xn_phieu", "idchinhanh", "numeric", "", "default 0");
                f_add_colum(aschema, "xn_ketqua", "goimau", "numeric", "", "default 0");
                f_add_colum(aschema, "xn_ketqua", "in_goimau", "numeric", "", "default 0");
                f_add_colum(aschema, "xn_ketqua", "ngaygoi", "timestamp", "", "");
                //if (get_data("SELECT relname FROM pg_class WHERE relname = 'xn_maugoingoaidm'").Tables[0].Rows.Count == 0)
                //{
                execute_data("CREATE TABLE " + aschema + ".xn_maugoingoaidm(id_xnphieu numeric NOT NULL,id_xn_bv_ten numeric DEFAULT 0,id_chidinh numeric DEFAULT 0,id_noigoi numeric DEFAULT 0,lydo varchar(50) default '',duyet numeric(1) DEFAULT 0,userid numeric DEFAULT 0,useridD numeric DEFAULT 0,dagui numeric(1) DEFAULT 0,ngay timestamp,ngayud timestamp DEFAULT now(),PRIMARY KEY (id_xnphieu,id_xn_bv_ten))");
               // }
                f_add_colum(aschema, "xn_worksheet", "ketthuc", "numeric", "1", "default 0");
                f_add_colum(aschema, "xn_phieu", "chuyendi", "text", "", "");
                f_add_colum(aschema, "xn_ketqua", "chuyendi", "text", "", "");
                f_add_colum(aschema, "xn_ketqua", "chaylai", "numeric", "1", "default 0");
                //lydochaylai
                f_add_colum(aschema, "xn_ketqua", "lydochaylai", "varchar", "100", "default ''");
                f_add_colum(aschema, "xn_ketqua", "ketquachaylai", "varchar", "100", "default ''");
                f_add_colum(aschema, "xn_ketqua", "chaykiemtra", "numeric", "1", "default 0");
                f_add_colum(aschema, "xn_ketqua", "ketquakiemtra", "varchar", "100", "default ''");

                //chuyendi text
                string sql = "";
                sql = "create table "+aschema+".xn_hc(id numeric NOT NULL DEFAULT 0,id_ten numeric(7) NOT NULL DEFAULT 0,mahc numeric(7) default 0,sttt numeric NOT NULL DEFAULT 0, ";
                sql += " mavach text,soluong numeric(10,5) default 0,userid numeric(5) DEFAULT 0,ngayud timestamp without time zone DEFAULT now(), constraint pk_xn_hc primary key(id,id_ten,mahc), ";
                sql += " constraint fk_xn_hc_xn_phieu foreign key(id) references " + aschema + ".xn_phieu(id)) ";
                execute_data(sql);

                f_add_colum(aschema, "xn_hoachatdm", "haohut", "numeric", "3", "default 0");
                f_add_colum(aschema, "xn_ketqua", "inguimaulan", "numeric", "3", "default 0");
            }
            catch
            {
            }
        }
        private void f_add_colum(string aschema, string _tentable, string _field, string _datatype, string datalen,string _defauvalue)
        {
            string sql = "";
            sql = " alter table " + aschema + "."+_tentable+" add "+_field+" "+_datatype+""+(datalen!=""?"("+datalen+")":"")+" "+_defauvalue;
            if (get_data("SELECT attname FROM pg_attribute WHERE attrelid in (SELECT oid FROM pg_class WHERE relname = '" + aschema+"."+_tentable + "') AND attname = '" + _field + "'").Tables[0].Rows.Count == 0)
            {
                execute_data(sql);
            }
        }
        public void modify_xn_bv_chitiet()
        {
            try
            {
                if (get_data("select macdinh from medibv.xn_bv_chitiet limit 1") == null)
                {
                    execute_data("alter table " + m_db_schemaroot + ".xn_bv_chitiet add macdinh text");
                }
            }
            catch
            {
            }
        }
        public void modify_xn_phieu(string v_mmyy)
        {
            try
            {
                if (get_data_mmyy(v_mmyy,"select stt,lanin,ngaylaymau from medibvmmyy.xn_phieu limit 1") == null)
                {
                    execute_data("alter table " + m_db_schemaroot+v_mmyy + ".xn_phieu add stt text");
                    execute_data("alter table " + m_db_schemaroot + v_mmyy + ".xn_phieu add lanin numeric DEFAULT 0");
                    execute_data("alter table " + m_db_schemaroot + v_mmyy + ".xn_phieu add ngaylaymau timestamp without time zone DEFAULT now()");
                }
            }
            catch
            {
            }
        }
        public void create_tables_xn_inmavach()
        {
            try
            {
                string a_schema = m_db_schemaroot;
                execute_data("CREATE TABLE " + a_schema + ".xn_inmavach(ngay timestamp, tu numeric(10) default 0, den numeric(10) default 0, constraint pk_xn_inmavach primary key(ngay)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_inmavach OWNER TO " + m_db_database + "");
            }
            catch
            {
            }
        }
        public void create_tables_xn_reportphieu()
        {
            try
            {
                string a_schema = m_db_schemaroot;
                execute_data("CREATE TABLE " + a_schema + ".xn_reportphieu(loai numeric(1) default 0, tenfile text, ten text,macdinh numeric(1) default 0, constraint pk_xn_reportphieu primary key(tenfile)) WITH OIDS");
                execute_data("ALTER TABLE " + a_schema + ".xn_reportphieu OWNER TO " + m_db_database + "");
            }
            catch
            {
            }
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
                        ads.Tables[0].Rows.Add(new string[] { c.ColumnName, c.DataType.ToString().Split('.')[c.DataType.ToString().Split('.').Length-1]});
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

        public string Mabv_xml
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
        public string Mabv
        {
            get
            {
                try
                {
                    DataTable tmp = get_data("select ten from " + user + ".thongso where id=2").Tables[0];
                    if (tmp.Rows[0]["ten"].ToString().Trim().Length == 8) return tmp.Rows[0]["ten"].ToString();
                    else
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load("..\\..\\..\\xml\\maincode.xml");
                        XmlNodeList nodeLst = doc.GetElementsByTagName("Mabv");
                        return (nodeLst.Item(0).InnerText == "") ? "701.1.01" : nodeLst.Item(0).InnerText;
                    }
                }
                catch
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load("..\\..\\..\\xml\\maincode.xml");
                    XmlNodeList nodeLst = doc.GetElementsByTagName("Mabv");
                    return (nodeLst.Item(0).InnerText == "") ? "701.1.01" : nodeLst.Item(0).InnerText;
                }
            }
        }
        public string Tenbv
        {
            get
            {
                try
                {
                    return get_data("select ten from " + user + ".thongso where id=3").Tables[0].Rows[0]["ten"].ToString();
                }
                catch
                {
                    return Maincode("Tenbv");
                }
            }
        }
        //public string Tenbv
        //{
        //    get
        //    {
        //        string art = "";
        //        try
        //        {
        //            XmlDocument doc = new XmlDocument();
        //            doc.Load("..\\..\\..\\xml\\maincode.xml");
        //            XmlNodeList nodeLst = doc.GetElementsByTagName("Tenbv");
        //            art = nodeLst.Item(0).InnerText;
        //        }
        //        catch
        //        {
        //            art = "";
        //        }
        //        return art;
        //    }
        //}
        //public string Syte
        //{
        //    get
        //    {
        //        string art = "";
        //        try
        //        {
        //            XmlDocument doc = new XmlDocument();
        //            doc.Load("..\\..\\..\\xml\\maincode.xml");
        //            XmlNodeList nodeLst = doc.GetElementsByTagName("Syte");
        //            art = nodeLst.Item(0).InnerText;
        //        }
        //        catch
        //        {
        //            art = "";
        //        }
        //        return art;
        //    }
        //}
        public string Syte
        {
            get
            {
                try
                {
                    return get_data("select ten from " + user + ".thongso where id=4").Tables[0].Rows[0]["ten"].ToString();
                }
                catch
                {
                    return Maincode("Syte");
                }
            }
        }
        public string s_path_hinhbn
        {
            get
            {
                try
                {
                    return get_data("select ten from " + user + ".thongso where id=265").Tables[0].Rows[0]["ten"].ToString();
                }
                catch
                {
                    return "";
                }
            }
        }
        
        public string Diachi
        {
            get
            {
                try
                {
                    return get_data("select ten from " + user + ".thongso where id=5").Tables[0].Rows[0]["ten"].ToString();
                }
                catch
                {
                    return Maincode("Diachi");
                }
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
            m_ds = get_data("select distinct schemaname from pg_tables where schemaname like '" + s_schemaroot + "____' order by schemaname desc");
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
            if (v_sql.IndexOf("medibvmmyy.") >= 0)
            {
                string ammyy = s_curmmyy;
                v_sql = v_sql.Replace("medibvmmyy.", m_db_schemaroot + ammyy + ".");
            }
            v_sql = v_sql.Replace("medibv.", m_db_schemaroot + ".");

            try
            {
                m_connection = new NpgsqlConnection(m_db_connectionstring);
                m_connection.Open();
                m_command = new NpgsqlCommand(v_sql, m_connection);
                m_command.CommandType = CommandType.Text;
                m_command.ExecuteNonQuery();
                //m_command.Dispose();
                //m_connection.Dispose();
            }
            catch (NpgsqlException ex)
            {
                upd_xn_error(ex.Message.ToString().Trim(), m_computername, "execute_data");
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
        }
        public void execute_data_mmyy(string v_mmyy, string v_sql)
        {
            if (v_mmyy == "")
            {
                v_mmyy = s_curmmyy;
            }
            if (v_sql.IndexOf("medibvmmyy.") >= 0)
            {
                v_sql = v_sql.Replace("medibvmmyy.", m_db_schemaroot + v_mmyy + ".");
            }
            v_sql = v_sql.Replace("medibv.", m_db_schemaroot + ".");
            try
            {
                m_connection = new NpgsqlConnection(m_db_connectionstring);
                m_connection.Open();
                m_command = new NpgsqlCommand(v_sql, m_connection);
                m_command.CommandType = CommandType.Text;
                m_command.ExecuteNonQuery();
                //m_command.Dispose();
                //m_connection.Dispose();
            }
            catch (NpgsqlException ex)
            {
                upd_xn_error(ex.Message.ToString().Trim(), m_computername, "execute_data");
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
        }
        public DataSet get_data(string v_sql)
        {
            if (v_sql.IndexOf("medibvmmyy.") >= 0)
            {
                string ammyy = s_curmmyy;
                v_sql = v_sql.Replace("medibvmmyy.", m_db_schemaroot + ammyy + ".");
            }
            v_sql = v_sql.Replace("medibv.", m_db_schemaroot + ".");
            m_ds = null;
            try
            {
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
            catch (NpgsqlException ex)
            {
                upd_xn_error(ex.Message.ToString().Trim(),m_computername,"get_data");
                m_ds = null;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Close();
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
                string asql = "",asql1 = "";
                DataSet ads = null, adst = null, adsschema = null;
                if (v_sql.IndexOf(":medibvmmyy") >= 0)
                {
                    adsschema = get_shemaname_mmyy();
                    int atu = v_tn.Month + int.Parse(v_tn.Year.ToString().Substring(2)) * 12;
                    int aden = v_dn.Month + int.Parse(v_dn.Year.ToString().Substring(2)) * 12;
                    foreach (DataRow r in adsschema.Tables[0].Rows)
                    {
                        int ahientai = int.Parse(r["schemaname"].ToString().Substring(r["schemaname"].ToString().Length - 4, 2)) + int.Parse(r["schemaname"].ToString().Substring(r["schemaname"].ToString().Length - 2,2)) * 12;
                        if (ahientai>=atu && ahientai<=aden)
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


        #endregion CÁC HÀM DÙNG CHUNG HỆ THỐNG

        #region OPTION 

        public bool s_o_benhnhanmoi_lm
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkLM_Benhnhanmoi'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                upd_xn_option("chkLM_Benhnhanmoi", value == true ? "1" : "0");
            }
        }
        public bool bNhaptheochidinh_Ketqua
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkKQ_Theochidinh'").Tables[0].Rows[0][0].ToString() == "1"?true:false;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool s_o_chuatiepdon_lm
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkLM_Chuaquatiepdon'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                upd_xn_option("chkLM_Chuaquatiepdon", value == true ? "1" : "0");
            }
        }
        public bool s_o_theochidinh_lm
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkLaymau_Theochidinh'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                upd_xn_option("chkLaymau_Theochidinh", value == true ? "1" : "0");
            }
        }
        public bool s_o_stttangtudong_lm
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkLaymau_SttTangtudong'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                upd_xn_option("chkLaymau_SttTangtudong", value == true ? "1" : "0");
            }
        }
        public bool bStt_Laymau_Tangtudong
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkLaymau_SttTangtudong'").Tables[0].Rows[0][0].ToString() == "1"?true:false;
                }
                catch
                {
                    return false;
                }
            }
            
        }
        public int s_o_lanin
        {
            get
            {
                int i=0;
                try
                {
                     i = int.Parse(get_data("select val from medibv.xn_option where ma='cbLanin'").Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    i=0;
                }
                if(i<0) i=0;
                return i;
            }
            set
            {
                upd_xn_option("cbLanin", value.ToString());
            }
        }
        public int s_o_khoangcachngaylamviec
        {
            get
            {
                int i = 1;
                try
                {
                    i = int.Parse(get_data("select val from medibv.xn_option where ma='txtKhoangcach'").Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    i = 1;
                }
                if (i < 0) i = 1;
                return i;
            }
            set
            {
                upd_xn_option("txtKhoangcach", value.ToString());
            }
        }

        public bool s_o_nhap_nhanvientruc
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkNVTruc'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                upd_xn_option("chkNVTruc", value == true ? "1" : "0");
            }
        }
        public bool s_o_nhieumay
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkNhieumay'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return true;
                }
            }
            set
            {
                upd_xn_option("chkNhieumay", value == true ? "1" : "0");
            }
        }
        //nhap theo phieu
        public string s_phieulaymau
        {
            get
            {      
                string r="";
                try
                {
                    r= get_data("select val from medibv.xn_option where ma='cbPhieuxetnghiem'").Tables[0].Rows[0][0].ToString();       
                }
                catch
                {
                    r= "1";
                }
                if(r=="")
                {
                    r="1";
                }
                return r;
            }
            set
            {
                upd_xn_option("cbPhieuxetnghiem",value);
            }

        }
        public string f_MaXnPcr
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='f_MaXnPcr'").Tables[0].Rows[0][0].ToString().Trim().Trim(',');
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                upd_xn_option("f_MaXnPcr", value.Trim().Trim(','));
            }
        }
        public string s_chinhanh
        {
            get
            {
                string r = "";
                try
                {
                    r = get_data("select val from medibv.xn_option where ma='cboChinhanh'").Tables[0].Rows[0][0].ToString();
                }
                catch
                {
                    r = "-1";
                }
                if (r == "")
                {
                    r = "-1";
                }
                return r;
            }
            set
            {
                upd_xn_option("cboChinhanh", value);
            }

        }

        //Hoá chất xét nghiệm theo kho và tử trực
        public string s_HoachatXNtheokho
        {
            get
            {
                string r = "";
                try
                {
                    r = get_data("select val from medibv.xn_option where ma='cbKho'").Tables[0].Rows[0][0].ToString();
                }
                catch
                {
                    r = "";
                }
                if (r == "")
                {
                    r = "";
                }
                return r;
            }
            set
            {
                upd_xn_option("cbKho", value);
            }

        }
        public string s_HoachatXNtheotutruc
        {
            get
            {
                string r = "";
                try
                {
                    r = get_data("select val from medibv.xn_option where ma='cbTutruc'").Tables[0].Rows[0][0].ToString();
                }
                catch
                {
                    r = "";
                }
                if (r == "")
                {
                    r = "";
                }
                return r;
            }
            set
            {
                upd_xn_option("cbTutruc", value);
            }

        }
        public string s_Port
        {
            get
            {
                string r = "";
                try
                {
                    r = get_data("select val from medibv.xn_option where ma='cboPort'").Tables[0].Rows[0][0].ToString();
                }
                catch
                {
                    r = "";
                }
                if (r == "")
                {
                    r = "";
                }
                return r;
            }
            set
            {
                upd_xn_option("cboPort", value);
            }

        }
        public string s_Settings
        {
            get
            {
                string r = "";
                try
                {
                    r = get_data("select val from medibv.xn_option where ma='txtSetting'").Tables[0].Rows[0][0].ToString();
                }
                catch
                {
                    r = "";
                }
                if (r == "")
                {
                    r = "";
                }
                return r;
            }
            set
            {
                upd_xn_option("txtSetting", value);
            }

        }
        public string s_truongkhoa
        {
            get
            {
                string r = "";
                try
                {
                    r = get_data("select val from medibv.xn_option where ma='txtTruongkhoa'").Tables[0].Rows[0][0].ToString();
                }
                catch
                {
                    r = "";
                }
                if (r == "")
                {
                    r = "";
                }
                return r;
            }
            set
            {
                upd_xn_option("txtTruongkhoa", value);
            }

        }
        public bool s_QuanlyHCXN
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkQuanlyHC'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                upd_xn_option("chkQuanlyHC", value == true ? "1" : "0");
            }
        }
        public bool s_CapnhatHCtutruc
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkCapnhathoachattutruc'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                upd_xn_option("chkCapnhathoachattutruc", value == true ? "1" : "0");
            }
        }
        public bool s_KhongphanquyenBVSo
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chk_khongphanquyentheoso'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                upd_xn_option("chk_khongphanquyentheoso", value == true ? "1" : "0");
            }
        }
        public bool s_XuatfileTEXT
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chk_TXT'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                upd_xn_option("chk_TXT", value == true ? "1" : "0");
            }
        }
        //nhap theo phieu
        public string s_sttlaymautang
        {
            //1:ngay - 2:thang - 3 Năm
            get
            {
                string r = "";
                try
                {
                    r = get_data("select val from medibv.xn_option where ma='cbSTTLaymau'").Tables[0].Rows[0][0].ToString();
                }
                catch
                {
                    r = "1";
                }
                if (r == "")
                {
                    r = "1";
                }
                return r;
            }
            set
            {
                upd_xn_option("cbSTTLaymau", value);
            }

        }
        public bool s_o_benhnhanmoi_kq
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkKQ_Benhnhanmoi'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                upd_xn_option("chkKQ_Benhnhanmoi", value == true ? "1" : "0");
            }
        }
        public bool s_o_chuatiepdon_kq
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkKQ_Chuaquatiepdon'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                upd_xn_option("chkKQ_Chuaquatiepdon", value == true ? "1" : "0");
            }
        }
        public bool s_o_theochidinh_kq
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkKQ_Theochidinh'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                upd_xn_option("chkKQ_Theochidinh", value == true ? "1" : "0");
            }
        }

        public bool s_o_benhnhanmoi_ksd
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkKSD_Benhnhanmoi'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                upd_xn_option("chkKSD_Benhnhanmoi", value == true ? "1" : "0");
            }
        }
        public bool s_o_chuatiepdon_ksd
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkKSQ_Chuaquatiepdon'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                upd_xn_option("chkKSQ_Chuaquatiepdon", value == true ? "1" : "0");
            }
        }
        public bool s_o_theochidinh_ksd
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkKSD_Theochidinh'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                upd_xn_option("chkKSD_Theochidinh", value == true ? "1" : "0");
            }
        }

        public bool s_o_capnhatvpkhoa_lm_nt
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkNoitru_1_1'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                upd_xn_option("chkNoitru_1_1", value == true ? "1" : "0");
            }
        }
        public bool s_o_capnhatvpkhoa_lm_ngt
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkNgoaitru_1_1'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                upd_xn_option("chkNgoaitru_1_1", value == true ? "1" : "0");
            }
        }
        public bool s_o_capnhatvpkhoa_lm_pk
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkPhongkham_1_1'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                upd_xn_option("chkPhongkham_1_1", value == true ? "1" : "0");
            }
        }
        public bool s_o_capnhatvpkhoa_lm_pl
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkPhongluu_1_1'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                upd_xn_option("chkPhongluu_1_1", value == true ? "1" : "0");
            }
        }

        public bool s_o_capnhatvpkhoa_kq_nt
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkNoitru_1_2'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                upd_xn_option("chkNoitru_1_2", value == true ? "1" : "0");
            }
        }
        public bool s_o_capnhatvpkhoa_kq_ngt
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkNgoaitru_1_2'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                upd_xn_option("chkNgoaitru_1_2", value == true ? "1" : "0");
            }
        }
        public bool s_o_capnhatvpkhoa_kq_pk
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkPhongkham_1_2'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                upd_xn_option("chkPhongkham_1_2", value == true ? "1" : "0");
            }
        }
        public bool s_o_capnhatvpkhoa_kq_pl
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkPhongluu_1_2'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                upd_xn_option("chkPhongluu_1_2", value == true ? "1" : "0");
            }
        }

        public bool s_o_phaidongtien_kq
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkKQ_Phaidongtien'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return true;
                }
            }
            set
            {
                upd_xn_option("chkKQ_Phaidongtien", value == true ? "1" : "0");
            }
        }
        public bool s_o_phaidongtien_lm
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkLM_Phaidongtien'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return true;
                }
            }
            set
            {
                upd_xn_option("chkLM_Phaidongtien", value == true ? "1" : "0");
            }
        }
        public bool s_o_lm_stt_tudong
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkLM_Stt'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                upd_xn_option("chkLM_Stt", value == true ? "1" : "0");
            }
        }
        public string s_o_dang_sothuthu
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='groupStt'").Tables[0].Rows[0][0].ToString() ;
                }
                catch
                {
                    return "1";
                }
            }
            set
            {
                upd_xn_option("groupStt", value );
            }
        }
        public bool s_o_nhieu_chinhanh
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chk_coso'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                upd_xn_option("chk_coso", value == true ? "1" : "0");
            }
        }
        public string s_o_mavp_ctc
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='mavp_ctc'").Tables[0].Rows[0][0].ToString().Trim().Trim(',');
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                upd_xn_option("mavp_ctc", value.Trim().Trim(','));
            }
        }
        public string s_o_mavp_KSD
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='m_mavp_KSD'").Tables[0].Rows[0][0].ToString().Trim().Trim(',');
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                upd_xn_option("m_mavp_KSD", value.Trim().Trim(','));
            }
        }
        //CTC
        public bool ctc_Quyensua(string s_userid)
        {
            return get_xn_optionform(1, s_userid, "CTC_001") == "1";            
        }
        public bool ctc_Quyenxoa(string s_userid)
        {
            return get_xn_optionform(1, s_userid, "CTC_002") == "1";

        }

        //Phiếu lấy mẫu
        public bool PLM_Quyensua(string s_userid)
        {
            return get_xn_optionform(1, s_userid, "PLM_001") == "1";
        }
        public bool PLM_Quyenxoa(string s_userid)
        {
            return get_xn_optionform(1, s_userid, "PLM_002") == "1";
        }
        public bool s_o_Phongluu_phaidongtien_LM
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkLM_PLphaidongtien'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return true;
                }
            }
            set
            {
                upd_xn_option("chkLM_PLphaidongtien", value == true ? "1" : "0");
            }
        }
        public bool s_o_Ngoaitru_phaidongtien_LM
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkLM_NGTphaidongtien'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return true;
                }
            }
            set
            {
                upd_xn_option("chkLM_NGTphaidongtien", value == true ? "1" : "0");
            }
        }
        //Phiếu kết quả
        public bool PKQ_Quyensua(string s_userid)
        {
            return get_xn_optionform(1, s_userid, "PKQ_001") == "1";
        }
        public bool PKQ_Quyenxoa(string s_userid)
        {
            return get_xn_optionform(1, s_userid, "PKQ_002") == "1";
        }
        #endregion

        #region PHÂN QUYỀN SỬ DỤNG
        public string s_phanquyen_id_bv_so(string v_userid)
        {
            try
            {
                string atmp = get_data("select id_bv_so from medibv.xn_dlogin where id=" + v_userid).Tables[0].Rows[0][0].ToString().Trim();
                atmp = atmp.Trim();
                atmp = atmp.Trim(',');
                atmp = atmp.Trim(',');
                return atmp;
            }
            catch
            {
                return "";
            }
        }
        #endregion PHÂN QUYỀN SỬ DỤNG

        #region CAPID

        private int get_computerid()
        {
            int art = 1;
            try
            {
                art = int.Parse(get_data("select id,computer from " + m_db_schemaroot + ".dmcomputer").Tables[0].Select("computer='" + m_computername + "'")[0][0].ToString());
            }
            catch
            {
                upd_dmcomputer();
                try
                {
                    art = int.Parse(get_data("select id,computer from " + m_db_schemaroot + ".dmcomputer").Tables[0].Select("computer='" + m_computername + "'")[0][0].ToString().Trim());
                }
                catch
                {
                    art = 1;
                }
            }
            return art;
        }
        private long get_xn_capid(int v_ma)
        {
            long art = 1;
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
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Varchar, 254).Value = "????";
                    m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
                m_connection.Dispose();
                art = long.Parse(get_data("select id from xn_capid where ma=" + v_ma).Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                return art = 1;
            }
            return art;
        }
        private long get_xn_capid_may(int v_ma, string v_computer)
        {
            long art = 1;
            try
            {
                m_sql = "update " + m_db_schemaroot + ".xn_capid set id=id+1 where ma=:v_ma and computer=:v_computer";
                m_connection = new NpgsqlConnection(m_db_connectionstring);
                m_command = new NpgsqlCommand(m_sql, m_connection);
                m_command.CommandType = CommandType.Text;
                m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                m_command.Parameters.Add("v_computer", NpgsqlDbType.Varchar,254).Value = v_computer;
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_capid(ma,ten,id,computer,ngayud) values (:v_ma,:v_ten,1,:v_computer,now())";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Varchar, 254).Value = v_computer;
                    m_command.Parameters.Add("v_computer", NpgsqlDbType.Varchar,254).Value = v_computer;
                    m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
                m_sql = "select id from " + m_db_schemaroot + ".xn_capid where ma=:v_ma and computer=:v_computer";
                m_command = new NpgsqlCommand(m_sql, m_connection);
                m_command.CommandType = CommandType.Text;
                m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                m_command.Parameters.Add("v_computer", NpgsqlDbType.Varchar,254).Value = v_computer;
                m_dataadapter = new NpgsqlDataAdapter(m_command);
                m_ds = new DataSet();
                m_dataadapter.Fill(m_ds);
                m_command.Dispose();
                m_connection.Dispose();
                art = long.Parse(m_ds.Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                art = 1;
            }
            return art;
        }

        public long get_xn_cap_stt_ngay(int v_ma, string v_ngay)
        {
            long art = 1;
            try
            {
                m_sql = "update " + m_db_schemaroot + ".xn_capsott set so=so+1 where loai=:v_ma and to_char(ngay,'dd/mm/yyyy')=:v_ngay";
                m_connection = new NpgsqlConnection(m_db_connectionstring);
                m_command = new NpgsqlCommand(m_sql, m_connection);
                m_command.CommandType = CommandType.Text;
                m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay;
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    try
                    {
                        m_sql = "insert into " + m_db_schemaroot + ".xn_capsott(so,loai,ngay) values (1,:v_ma,to_date(:v_ngay,'dd/mm/yyyy'))";
                        m_command = new NpgsqlCommand(m_sql, m_connection);
                        m_command.CommandType = CommandType.Text;
                        m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                        m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay;
                        m_command.ExecuteNonQuery();
                        m_command.Dispose();
                    }
                    catch(Exception exx )
                    {
                        MessageBox.Show(exx.ToString());
                    }
                }
                m_sql = "select so from " + m_db_schemaroot + ".xn_capsott where loai=:v_ma and to_char(ngay,'dd/mm/yyyy')=:v_ngay";
                m_command = new NpgsqlCommand(m_sql, m_connection);
                m_command.CommandType = CommandType.Text;
                m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay;
                m_dataadapter = new NpgsqlDataAdapter(m_command);
                m_ds = new DataSet();
                m_dataadapter.Fill(m_ds);
                m_command.Dispose();
                m_connection.Dispose();
                art = long.Parse(m_ds.Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                art = 1;
            }
            return art;
        }

        private long get_d_capid_may(int v_ma, string v_computer)
        {
            long art = 1;
            try
            {
                m_sql = "update " + m_db_schemaroot + ".d_capid set id=id+1 where ma=:v_ma and computer=:v_computer";
                m_connection = new NpgsqlConnection(m_db_connectionstring);
                m_command = new NpgsqlCommand(m_sql, m_connection);
                m_command.CommandType = CommandType.Text;
                m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                m_command.Parameters.Add("v_computer", NpgsqlDbType.Varchar, 254).Value = v_computer;
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".d_capid(ma,ten,id,computer,ngayud) values (:m_ma,:m_ten,1,:m_computer,now())";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Varchar, 254).Value = "????";
                    m_command.Parameters.Add("v_computer", NpgsqlDbType.Varchar, 254).Value = v_computer;
                    m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
                m_sql = "select id from " + m_db_schemaroot + ".d_capid where ma=:v_ma and computer=:v_computer";
                m_command = new NpgsqlCommand(m_sql, m_connection);
                m_command.CommandType = CommandType.Text;
                m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                m_command.Parameters.Add("v_computer", NpgsqlDbType.Varchar, 254).Value = v_computer;
                m_dataadapter = new NpgsqlDataAdapter(m_command);
                m_ds = new DataSet();
                m_dataadapter.Fill(m_ds);
                m_command.Dispose();
                m_connection.Dispose();
                art = long.Parse(m_ds.Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                art = 1;
            }
            return art;
        }
        private long get_v_capid_may(int v_ma, string v_computer)
        {
            long art = 1;
            try
            {
                m_sql = "update " + m_db_schemaroot + ".v_capid set id=id+1 where ma=:v_ma and computer=:v_computer";
                m_connection = new NpgsqlConnection(m_db_connectionstring);
                m_command = new NpgsqlCommand(m_sql, m_connection);
                m_command.CommandType = CommandType.Text;
                m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                m_command.Parameters.Add("v_computer", NpgsqlDbType.Varchar, 254).Value = v_computer;
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".v_capid(ma,ten,id,computer,ngayud) values (:m_ma,:m_ten,1,:m_computer,now())";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Varchar, 254).Value = "????";
                    m_command.Parameters.Add("v_computer", NpgsqlDbType.Varchar,254).Value = v_computer;
                    m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
                m_sql = "select id from " + m_db_schemaroot + ".v_capid where ma=:v_ma and computer=:v_computer";
                m_command = new NpgsqlCommand(m_sql, m_connection);
                m_command.CommandType = CommandType.Text;
                m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                m_command.Parameters.Add("v_computer", NpgsqlDbType.Varchar, 254).Value = v_computer;
                m_dataadapter = new NpgsqlDataAdapter(m_command);
                m_ds = new DataSet();
                m_dataadapter.Fill(m_ds);
                m_command.Dispose();
                m_connection.Dispose();
                art = long.Parse(m_ds.Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                art = 1;
            }
            return art;
        }
        private long get_xn_capid(string v_table, int v_ma)
        {
            long art = 1;
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
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Varchar, 254).Value = "????";
                    m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
                m_connection.Dispose();
                art = long.Parse(get_data("select id from " + m_db_schemaroot + "." + v_table + " where ma=" + v_ma).Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                art = 1;
            }
            return art;
        }
        public decimal get_id_xn_treebaocao
        {
            get
            {
                decimal art = 1;
                try
                {
                    decimal i = 0;
                    DataSet ads = get_data("select id from " + s_schemaroot + ".xn_treebaocao order by id asc");
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
        public decimal get_id_xn_so
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select id from " + s_schemaroot + ".xn_so order by id asc");
                    while (i < 99)
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
        public decimal get_id_xn_nhom
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select id from " + s_schemaroot + ".xn_nhom order by id asc");
                    while (i < 9999)
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
        public decimal get_id_xn_loai
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select id from " + s_schemaroot + ".xn_loai order by id asc");
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
        public decimal get_id_xn_ten
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select id from " + s_schemaroot + ".xn_ten order by id asc");
                    while (i < 9999999)
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
        public decimal get_id_xn_bv_so
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select id from " + s_schemaroot + ".xn_bv_so order by id asc");
                    while (i < 99)
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
        public decimal get_id_xn_bv_ten
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select id from " + s_schemaroot + ".xn_bv_ten order by id asc");
                    while (i < 9999999)
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
        public decimal get_id_xn_bv_chitiet
        {
            get
            {
                decimal art = 1;
                try
                {
                    decimal i = 0;
                    DataSet ads = get_data("select id from " + s_schemaroot + ".xn_bv_chitiet order by id asc");
                    while (i < 99999999999)
                    {
                        i += 1;
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
        public decimal get_id_xn_bv_vitrung
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select id from " + s_schemaroot + ".xn_bv_vitrung order by id asc");
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
        public decimal get_id_xn_bv_khangsinh
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select id from " + s_schemaroot + ".xn_bv_khangsinh order by id asc");
                    while (i < 9999999)
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
        public decimal get_id_xn_hoachat
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select id from " + s_schemaroot + ".xn_hoachatdm order by id asc");
                    while (i < 9999999)
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
        public decimal get_id_xn_thongso
        {
            get
            {
                return get_xn_capid(9);
            }
        }
        public decimal get_id_xn_vitrung
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select id from " + s_schemaroot + ".xn_vitrung order by id asc");
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
        public decimal get_id_xn_khangsinh
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select id from " + s_schemaroot + ".xn_khangsinh order by id asc");
                    while (i < 9999999)
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
        public decimal get_id_xn_mauthu
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select id from " + s_schemaroot + ".xn_mauthu order by id asc");
                    while (i < 9999)
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
        public decimal get_id_xn_tinhtrang
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select id from " + s_schemaroot + ".xn_tinhtrang order by id asc");
                    while (i < 9)
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
        public decimal get_id_xn_sdmauthu
        {
            get
            {
                return get_xn_capid(21);
            }
        }
        public decimal get_id_xn_vitri
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select id from " + s_schemaroot + ".xn_vitri order by id asc");
                    while (i < 9999)
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
        public decimal get_id_xn_diadiem
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select id from " + s_schemaroot + ".xn_diadiem order by id asc");
                    while (i < 9999)
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
        public decimal get_id_xn_nhomdlogin
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select id from " + s_schemaroot + ".xn_nhomdlogin order by id asc");
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
        public decimal get_id_xn_dlogin
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select id from medibv.xn_dlogin union all select id from medibv.xn_may order by id asc");
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
        public decimal get_id_xn_donvi
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select id from " + s_schemaroot + ".xn_donvi order by id asc");
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
        public decimal get_id_xn_donvi_hl7
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select id from " + s_schemaroot + ".xn_donvi_hl7 order by id asc");
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
        public decimal get_id_xn_vitrung_thuoc
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select id from " + s_schemaroot + ".xn_vitrung_thuoc order by id asc");
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
        public decimal get_id_xn_thuoc
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select id from " + s_schemaroot + ".xn_thuoc order by id asc");
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
        public decimal get_id_xn_laymau
        {
            get
            {
                return decimal.Parse(m_computerid.ToString() + get_xn_capid_may(1, m_computername).ToString().PadLeft(7, '0'));
            }
        }
        public decimal get_id_xn_phieu
        {
            get
            {
                return decimal.Parse(m_computerid.ToString() + get_xn_capid_may(2, m_computername).ToString().PadLeft(8, '0'));
            }
        }
        public decimal get_id_xn_ksd
        {
            get
            {
                return decimal.Parse(m_computerid.ToString() + get_xn_capid_may(3, m_computername).ToString().PadLeft(8, '0'));
            }
        }
        public decimal get_id_xn_ketqua_ksd
        {
            get
            {
                return decimal.Parse(m_computerid.ToString() + get_xn_capid_may(4, m_computername).ToString().PadLeft(8, '0'));
            }
        }
        public decimal get_id_xn_nhuomgram
        {
            get
            {
                return decimal.Parse(m_computerid.ToString() + get_xn_capid_may(5, m_computername).ToString().PadLeft(8, '0'));
            }
        }
        public decimal get_id_xn_done
        {
            get
            {
                return decimal.Parse(m_computerid.ToString() + get_xn_capid_may(6, m_computername).ToString().PadLeft(8, '0'));
            }
        }
        public decimal get_id_xn_hoachatbn
        {
            get
            {
                return decimal.Parse(m_computerid.ToString() + get_xn_capid_may(7, m_computername).ToString().PadLeft(8, '0'));
            }
        }
        public decimal get_id_xn_ten_default
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select id from " + s_schemaroot + ".xn_ten_default order by id asc");
                    while (i < 9999999)
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
        public decimal get_id_xn_chitiet_default
        {
            get
            {
                decimal art = 1;
                try
                {
                    decimal i = 0;
                    DataSet ads = get_data("select id from " + s_schemaroot + ".xn_chitiet_default order by id asc");
                    while (i < 99999999999)
                    {
                        i += 1;
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
        #endregion CAPID

        #region KIỂM TRA DANH MỤC ĐÃ DÙNG
        public int dadung_xn_dlogin(string v_id)
        {
            try
            {
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    if (get_data("select userid from " + r["schamaname"].ToString() + ".xn_laymau where userid=" + v_id + "").Tables[0].Rows.Count > 0) return 1;
                    if (get_data("select userid from " + r["schamaname"].ToString() + ".xn_phieu where userid=" + v_id + "").Tables[0].Rows.Count > 0) return 1;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_xn_nhomdlogin(string v_id)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".xn_nhomdlogin where id=" + v_id + " and readonly=1").Tables[0].Rows.Count > 0) return -1;
                if (get_data("select id from " + s_schemaroot + ".xn_dlogin where id_nhom=" + v_id + "").Tables[0].Rows.Count > 0) return 1;
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        public int dadung_xn_treebaocao(string v_id)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".xn_treebaocao where id=" + v_id + " and readonly=1").Tables[0].Rows.Count > 0) return -1;
                if (get_data("select id from " + s_schemaroot + ".xn_treebaocao where id_cha=" + v_id + "").Tables[0].Rows.Count > 0) return 1;
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_xn_so(string v_id)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".xn_so where id=" + v_id + " and readonly=1").Tables[0].Rows.Count > 0) return -1;
                if (get_data("select id from " + s_schemaroot + ".xn_nhom where id_so=" + v_id + "").Tables[0].Rows.Count > 0) return 1;
                if (get_data("select id from " + s_schemaroot + ".xn_bv_so where id_so=" + v_id + "").Tables[0].Rows.Count > 0) return 1;
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_xn_nhom(string v_id)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".xn_nhom where id=" + v_id + " and readonly=1").Tables[0].Rows.Count > 0) return -1;
                if (get_data("select id from " + s_schemaroot + ".xn_loai where id_nhom=" + v_id + "").Tables[0].Rows.Count > 0) return 1;
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_xn_loai(string v_id)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".xn_loai where readonly=1 and id=" + v_id + "").Tables[0].Rows.Count > 0) return -1;
                if (get_data("select id from " + s_schemaroot + ".xn_ten where id_loai=" + v_id + "").Tables[0].Rows.Count > 0) return 1;
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_xn_ten(string v_id)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".xn_ten where readonly=1 and id=" + v_id + "").Tables[0].Rows.Count > 0) return -1;
                if (get_data("select id from " + s_schemaroot + ".xn_bv_chitiet where id_ten=" + v_id + "").Tables[0].Rows.Count > 0) return 1;

                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_xn_bv_so(string v_id)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".xn_bv_so where id=" + v_id + " and readonly=1").Tables[0].Rows.Count > 0) return -1;
                if (get_data("select id_bv_so from " + s_schemaroot + ".xn_bv_ten where id_bv_so=" + v_id + "").Tables[0].Rows.Count > 0) return 1;
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_xn_bv_ten(string v_id)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".xn_bv_ten where readonly=1 and id=" + v_id + "").Tables[0].Rows.Count > 0) return -1;
                if (get_data("select id from " + s_schemaroot + ".xn_bv_chitiet where id_bv_ten=" + v_id + "").Tables[0].Rows.Count > 0) return 1;
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_xn_bv_chitiet(string v_id)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".xn_bv_chitiet where id=" + v_id + " and readonly=1").Tables[0].Rows.Count > 0) return -1;
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    if (get_data("select id from " + r["schemaname"].ToString() + ".xn_ketqua where id_ten=" + v_id + "").Tables[0].Rows.Count > 0) return 1;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_xn_bv_vitrung(string v_id)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".xn_bv_vitrung where id=" + v_id + " and readonly=1").Tables[0].Rows.Count > 0) return -1;
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    if (get_data("select id from " + r["schemaname"].ToString() + ".xn_ksd where id_bv_vitrung=" + v_id + "").Tables[0].Rows.Count > 0) return 1;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_xn_bv_khangsinh(string v_id)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".xn_bv_khangsinh where id=" + v_id + " and readonly=1").Tables[0].Rows.Count > 0) return -1;
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_xn_sdmauthu(string v_id_ten, string v_id_mauthu)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".xn_sdmauthu where id_ten=" + v_id_ten + " and id_mauthu=" + v_id_mauthu + " and readonly=1").Tables[0].Rows.Count > 0) return -1;
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_xn_donvi(string v_id)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".xn_donvi where id=" + v_id + " and readonly=1").Tables[0].Rows.Count > 0) return -1;
                if (get_data("select donvi from " + s_schemaroot + ".xn_ten where donvi=" + v_id + "").Tables[0].Rows.Count > 0) return 1;
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_xn_donvi_hl7(string v_id)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".xn_donvi_hl7 where id=" + v_id + " and readonly=1").Tables[0].Rows.Count > 0) return -1;
                if (get_data("select id_hl7 from " + s_schemaroot + ".xn_donvi where id_hl7=" + v_id + "").Tables[0].Rows.Count > 0) return 1;
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_xn_vitri(string v_id)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".xn_vitri where id=" + v_id + " and readonly=1").Tables[0].Rows.Count > 0) return -1;
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    if (get_data("select id_vitri from " + r["schamaname"].ToString() + ".xn_laymau where id_vitri=" + v_id + "").Tables[0].Rows.Count > 0) return 1;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_xn_diadiem(string v_id)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".xn_diadiem where id=" + v_id + " and readonly=1").Tables[0].Rows.Count > 0) return -1;
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    if (get_data("select id_diadiem from " + r["schamaname"].ToString() + ".xn_laymau where id_diadiem=" + v_id + "").Tables[0].Rows.Count > 0) return 1;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_xn_ktv(string v_id)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".xn_ktv where ma='" + v_id + "' and readonly=1").Tables[0].Rows.Count > 0) return -1;
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    if (get_data("select ktv from " + r["schamaname"].ToString() + ".xn_phieu where ktv='" + v_id + "'").Tables[0].Rows.Count > 0) return 1;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_xn_gram_vt(string v_ma)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".xn_gram_vt where ma='" + v_ma.Replace("'","''") + "' and readonly=1").Tables[0].Rows.Count > 0) return -1;
                if (get_data("select id from " + s_schemaroot + ".xn_vitrung where gram='" + v_ma.Replace("'","''") + "'").Tables[0].Rows.Count > 0) return 1;
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_xn_status_vt(string v_ma)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".xn_status_vt where ma='" + v_ma.Replace("'", "''") + "' and readonly=1").Tables[0].Rows.Count > 0) return -1;
                if (get_data("select id from " + s_schemaroot + ".xn_vitrung where status='" + v_ma.Replace("'", "''") + "'").Tables[0].Rows.Count > 0) return 1;
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_xn_vitrung(string v_id)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".xn_vitrung where id=" + v_id + " and readonly=1").Tables[0].Rows.Count > 0) return -1;
                if (get_data("select id_bv_vitrung from " + s_schemaroot + ".xn_bv_vitrung where id_vitrung=" + v_id + "").Tables[0].Rows.Count > 0) return 1;
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_xn_khangsinh(string v_id)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".xn_khangsinh where id=" + v_id + " and readonly=1").Tables[0].Rows.Count > 0) return -1;
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    if (get_data("select id_khangsinh from " + r["schamaname"].ToString() + ".xn_ketqua_ksd where id_khangsinh=" + v_id + "").Tables[0].Rows.Count > 0) return 1;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_xn_mauthu(string v_id)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".xn_mauthu where id=" + v_id + " and readonly=1").Tables[0].Rows.Count > 0) return -1;
                if (get_data("select id_mauthu from " + s_schemaroot + ".xn_sdmauthu where id_mauthu=" + v_id + "").Tables[0].Rows.Count > 0) return 1;
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    if (get_data("select id_mauthu from " + r["schamaname"].ToString() + ".xn_laymau where id_mauthu=" + v_id + "").Tables[0].Rows.Count > 0) return 1;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_xn_hoachat(string v_id)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".xn_hoachat where id=" + v_id + " and readonly=1").Tables[0].Rows.Count > 0) return -1;
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int dadung_xn_laymau(string v_mmyy, string v_id)
        {
            try
            {
                if (get_data("select readonly from " + s_schema_mmyy(v_mmyy) + ".xn_laymau where id=" + v_id + " and readonly=1").Tables[0].Rows.Count > 0) return -1;
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int daketthuc_workSheet(string v_mmyy, string v_id)
        {
            try
            {
                if (get_data("select ketthuc from " + s_schema_mmyy(v_mmyy) + ".xn_worksheet where id=" + v_id + " and ketthuc=1").Tables[0].Rows.Count > 0) return -1;
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
        public bool is_dba_admin(string v_userid)
        {
            try
            {
                return get_data("select a.id from medibv.xn_dlogin a left join medibv.xn_nhomdlogin b on a.id_nhom=b.id where a.id=" + v_userid + " and b.nhom=1").Tables[0].Rows.Count > 0;
            }
            catch
            {
                return false;
            }
        }
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

        #endregion BIẾN TOÀN CỤC

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
        public bool upd_dmcomputer(int i)
        {
            if (m_connection != null)
            {
                m_connection.Close(); m_connection.Dispose();
            }
            m_sql = "update " + user + ".dmcomputer set computer=:m_computer where computer=:m_computer";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            try
            {
                m_connection.Open();
                m_command = new NpgsqlCommand(m_sql, m_connection);
                m_command.CommandType = CommandType.Text;
                m_command.Parameters.Add("m_computer", NpgsqlDbType.Varchar).Value = System.Environment.MachineName;
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                m_connection.Close(); m_connection.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + user + ".dmcomputer(id,computer) values (" + get_id_dmcomputer + ",'" + System.Environment.MachineName + "')";
                    execute_data(m_sql);
                }
            }
            catch (NpgsqlException ex)
            {
                return false;
            }
            finally
            {
                m_connection.Close(); m_connection.Dispose();
            }
            return true;
        }
        private int get_id_dmcomputer
        {
            get
            {
                DataSet lds = get_data("select id from " + user + ".dmcomputer");
                DataRow dr;
                int i_id = 1;
                int i_cn = i_Chinhanh_hientai;
                string exp = "";
                for (int j = 1; j < 1000; j++)
                {
                    i_id = j;
                    if (i_cn > 0 && i_cn < 10)
                        exp = "id=" + (i_cn.ToString() + j.ToString().PadLeft(3, '0'));
                    else exp = "id=" + j.ToString();
                    dr = getrowbyid(lds.Tables[0], exp);
                    if (dr == null) break;
                }
                if (i_id >= 1000)
                {
                    lds = get_data("select max(id) as id from " + user + ".dmcomputer where id<9999");
                    if (lds.Tables[0].Rows[0]["id"].ToString() == "") i_id = 1;
                    else i_id = int.Parse(lds.Tables[0].Rows[0]["id"].ToString()) + 1;
                }
                if (bQuanly_Theo_Chinhanh || i_cn > 0)
                {
                    if (i_id.ToString().Length >= 4) i_id = int.Parse(i_id.ToString().Substring(0, 4));
                    else i_id = int.Parse(i_cn.ToString() + i_id.ToString().PadLeft(3, '0'));
                }
                return i_id;
            }
        }
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
                upd_xn_error(ex.Message, m_computername, "dmcomputer");
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
                DataSet ads = get_data("select trim(mmyy) as mmyy from "+s_schemaroot+".table");
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    string atmp = r["schemaname"].ToString();
                    if (ads.Tables[0].Select("mmyy='" + r["schemaname"].ToString().Trim().Replace(s_schemaroot,"")+"'").Length < 0)
                    {
                        execute_data("insert into " + s_schemaroot + ".table (mmyy,userid,ngayud,computer) values('" + r["schemaname"].ToString().Replace(s_schemaroot, "") + "',1,now(),'" + m_computername + "')");
                    }
                }
            }
            catch
            {
            }
        }
        public bool upd_xn_option(string v_ma, string v_val)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_option set val=:v_val where ma=:v_ma";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_ma", NpgsqlDbType.Text).Value = v_ma;
            m_command.Parameters.Add("v_val", NpgsqlDbType.Text).Value = v_val;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_option(ma, val) values(:v_ma, :v_val)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Text).Value = v_ma;
                    m_command.Parameters.Add("v_val", NpgsqlDbType.Text).Value = v_val;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_option");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_treebaocao(decimal v_id, decimal v_id_cha, decimal v_stt, string v_ten, string v_asql, string v_tenreport,decimal v_readonly)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_treebaocao set id_cha=:v_id_cha, stt=:v_stt,ten=:v_ten, asql=:v_asql,tenreport=:v_tenreport, readonly=:v_readonly where id=:v_id";
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
                    m_sql = "insert into " + m_db_schemaroot + ".xn_treebaocao(id,id_cha,stt,ten,asql,tenreport,readonly) values(:v_id,:v_id_cha,:v_stt,:v_ten,:v_asql,:v_tenreport,:v_readonly)";
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
                upd_xn_error(ex.Message, m_computername, "xn_treebaocao");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_so(decimal v_id, decimal v_stt, string v_ma, string v_ten, string v_viettat, decimal v_readonly)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_so set stt=:v_stt,ma=:v_ma,ten=:v_ten,viettat=:v_viettat, readonly=:v_readonly where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
            m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_viettat;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly ;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_so(id,stt,ma,ten,viettat,readonly) values(:v_id,:v_stt,:v_ma,:v_ten,:v_viettat,:v_readonly)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_viettat;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_nhom");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_nhom(decimal v_id, decimal v_id_so, decimal v_stt, string v_ma, string v_ten, string v_viettat, decimal v_readonly)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_nhom set id_so=:v_id_so,stt=:v_stt,ma=:v_ma,ten=:v_ten,viettat=:v_viettat,readonly=:v_readonly where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_id_so", NpgsqlDbType.Numeric).Value = v_id_so;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
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
                    m_sql = "insert into " + m_db_schemaroot + ".xn_nhom(id,id_so,stt,ma,ten,viettat,readonly) values(:v_id,:v_id_so,:v_stt,:v_ma,:v_ten,:v_viettat,:v_readonly)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_id_so", NpgsqlDbType.Numeric).Value = v_id_so;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_viettat;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_nhom");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_loai(decimal v_id, decimal v_id_nhom, decimal v_stt, string v_ma, string v_ten, string v_viettat, decimal v_tieuban, decimal v_readonly)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_loai set id_nhom=:v_id_nhom,stt=:v_stt,ma=:v_ma,ten=:v_ten, viettat=:v_viettat,tieuban=:v_tieuban,readonly=:v_readonly where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_id_nhom", NpgsqlDbType.Numeric).Value = v_id_nhom;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
            m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_viettat;
            m_command.Parameters.Add("v_tieuban", NpgsqlDbType.Numeric).Value = v_tieuban;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_loai(id,id_nhom,stt,ma,ten,viettat,tieuban,readonly) values(:v_id,:v_id_nhom,:v_stt,:v_ma,:v_ten,:v_viettat,:v_tieuban,:v_readonly)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_id_nhom", NpgsqlDbType.Numeric).Value = v_id_nhom;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_viettat;
                    m_command.Parameters.Add("v_tieuban", NpgsqlDbType.Numeric).Value = v_tieuban;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_loai");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_ten(decimal v_id, decimal v_id_nhom, decimal v_id_loai, decimal v_stt, string v_ma, string v_ten, string v_viettat, decimal v_donvi, string v_csbt_nu, string v_csbt_nam, decimal v_mincsbt_nu, decimal v_maxcsbt_nu, decimal v_mincsbt_nam, decimal v_maxcsbt_nam, decimal v_tieuban, string v_ghichu, decimal v_readonly)
        {
            //m_sql = "update " + m_db_schemaroot + ".xn_ten set id_nhom=:v_id_nhom,id_loai=:v_id_loai,stt=:v_stt,ma=:v_ma, ten=:v_ten,viettat=:v_viettat,donvi=:v_donvi,csbt_nu=:v_csbt_nu,csbt_nam=:v_csbt_nam, mincsbt_nu=:v_mincsbt_nu,maxcsbt_nu=:v_maxcsbt_nu,mincsbt_nam=:v_minscbt_nam,maxcsbt_nam=:v_maxcsbt_nam,tieuban=:v_tieuban,ghichu=:v_ghichu,readonly=:v_readonly where id=:v_id";
            m_sql = "update " + m_db_schemaroot + ".xn_ten set id_nhom=:v_id_nhom,id_loai=:v_id_loai,stt=:v_stt,ma=:v_ma, ten=:v_ten,viettat=:v_viettat,donvi=:v_donvi,csbt_nu=:v_csbt_nu,csbt_nam=:v_csbt_nam,mincsbt_nu=:v_mincsbt_nu,maxcsbt_nu=:v_maxcsbt_nu,mincsbt_nam=:v_mincsbt_nam,maxcsbt_nam=:v_maxcsbt_nam,tieuban=:v_tieuban,ghichu=:v_ghichu,readonly=:v_readonly where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_id_loai", NpgsqlDbType.Numeric).Value = v_id_loai;
            m_command.Parameters.Add("v_id_nhom", NpgsqlDbType.Numeric).Value = v_id_nhom;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
            m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_viettat;
            m_command.Parameters.Add("v_donvi", NpgsqlDbType.Numeric).Value = v_donvi;
            m_command.Parameters.Add("v_csbt_nu", NpgsqlDbType.Text).Value = v_csbt_nu;
            m_command.Parameters.Add("v_csbt_nam", NpgsqlDbType.Text).Value = v_csbt_nam;
            m_command.Parameters.Add("v_mincsbt_nu", NpgsqlDbType.Numeric).Value = v_mincsbt_nu;
            m_command.Parameters.Add("v_maxcsbt_nu", NpgsqlDbType.Numeric).Value = v_maxcsbt_nu;
            m_command.Parameters.Add("v_mincsbt_nam", NpgsqlDbType.Numeric).Value = v_mincsbt_nam;
            m_command.Parameters.Add("v_maxcsbt_nam", NpgsqlDbType.Numeric).Value = v_maxcsbt_nam;
            m_command.Parameters.Add("v_tieuban", NpgsqlDbType.Numeric).Value = v_tieuban;
            m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_ten(id,id_loai,id_nhom,stt,ma,ten,viettat,donvi,csbt_nu,csbt_nam,mincsbt_nu,maxcsbt_nu,mincsbt_nam,maxcsbt_nam,tieuban,ghichu,readonly) values(:v_id,:v_id_loai,:v_id_nhom,:v_stt,:v_ma,:v_ten,:v_viettat,:v_donvi,:v_csbt_nu,:v_csbt_nam,:v_mincsbt_nu,:v_maxcsbt_nu,:v_mincsbt_nam,:v_maxcsbt_nam,:v_tieuban,:v_ghichu,:v_readonly)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_id_loai", NpgsqlDbType.Numeric).Value = v_id_loai;
                    m_command.Parameters.Add("v_id_nhom", NpgsqlDbType.Numeric).Value = v_id_nhom;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_viettat;
                    m_command.Parameters.Add("v_donvi", NpgsqlDbType.Numeric).Value = v_donvi;
                    m_command.Parameters.Add("v_csbt_nu", NpgsqlDbType.Text).Value = v_csbt_nu;
                    m_command.Parameters.Add("v_csbt_nam", NpgsqlDbType.Text).Value = v_csbt_nam;
                    m_command.Parameters.Add("v_mincsbt_nu", NpgsqlDbType.Numeric).Value = v_mincsbt_nu;
                    m_command.Parameters.Add("v_maxcsbt_nu", NpgsqlDbType.Numeric).Value = v_maxcsbt_nu;
                    m_command.Parameters.Add("v_mincsbt_nam", NpgsqlDbType.Numeric).Value = v_mincsbt_nam;
                    m_command.Parameters.Add("v_maxcsbt_nam", NpgsqlDbType.Numeric).Value = v_maxcsbt_nam;
                    m_command.Parameters.Add("v_tieuban", NpgsqlDbType.Numeric).Value = v_tieuban;
                    m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_ten");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_ten(decimal v_id, decimal v_id_nhom, decimal v_id_loai, decimal v_stt, string v_ma,
            string v_ten, string v_viettat, decimal v_donvi, string v_csbt_nu, 
            string v_csbt_nam, decimal v_mincsbt_nu, decimal v_maxcsbt_nu, decimal v_mincsbt_nam, 
            decimal v_maxcsbt_nam, decimal v_tieuban, string v_ghichu, decimal v_readonly,
            string v_csnguycap, decimal v_min_csnguycap, decimal v_max_csnguycap, decimal v_delta, int v_thoigian)
        {
            //m_sql = "update " + m_db_schemaroot + ".xn_ten set id_nhom=:v_id_nhom,id_loai=:v_id_loai,stt=:v_stt,ma=:v_ma, ten=:v_ten,viettat=:v_viettat,donvi=:v_donvi,csbt_nu=:v_csbt_nu,csbt_nam=:v_csbt_nam, mincsbt_nu=:v_mincsbt_nu,maxcsbt_nu=:v_maxcsbt_nu,mincsbt_nam=:v_minscbt_nam,maxcsbt_nam=:v_maxcsbt_nam,tieuban=:v_tieuban,ghichu=:v_ghichu,readonly=:v_readonly where id=:v_id";
            m_sql = "update " + m_db_schemaroot + ".xn_ten set id_nhom=:v_id_nhom,id_loai=:v_id_loai,stt=:v_stt,ma=:v_ma, ten=:v_ten,viettat=:v_viettat,donvi=:v_donvi,csbt_nu=:v_csbt_nu,csbt_nam=:v_csbt_nam,mincsbt_nu=:v_mincsbt_nu,maxcsbt_nu=:v_maxcsbt_nu,mincsbt_nam=:v_mincsbt_nam,maxcsbt_nam=:v_maxcsbt_nam,tieuban=:v_tieuban,ghichu=:v_ghichu,readonly=:v_readonly, ";
            m_sql += " cs_nguycap=:v_csnguycap,min_csnuycap=:v_min_csnguycap,max_csnuycap=:v_max_csnguycap,delta_chk=:v_delta,tg_tinh=:v_thoigian";
            m_sql+=" where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_id_loai", NpgsqlDbType.Numeric).Value = v_id_loai;
            m_command.Parameters.Add("v_id_nhom", NpgsqlDbType.Numeric).Value = v_id_nhom;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
            m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_viettat;
            m_command.Parameters.Add("v_donvi", NpgsqlDbType.Numeric).Value = v_donvi;
            m_command.Parameters.Add("v_csbt_nu", NpgsqlDbType.Text).Value = v_csbt_nu;
            m_command.Parameters.Add("v_csbt_nam", NpgsqlDbType.Text).Value = v_csbt_nam;
            m_command.Parameters.Add("v_mincsbt_nu", NpgsqlDbType.Numeric).Value = v_mincsbt_nu;
            m_command.Parameters.Add("v_maxcsbt_nu", NpgsqlDbType.Numeric).Value = v_maxcsbt_nu;
            m_command.Parameters.Add("v_mincsbt_nam", NpgsqlDbType.Numeric).Value = v_mincsbt_nam;
            m_command.Parameters.Add("v_maxcsbt_nam", NpgsqlDbType.Numeric).Value = v_maxcsbt_nam;
            m_command.Parameters.Add("v_tieuban", NpgsqlDbType.Numeric).Value = v_tieuban;
            m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;
            m_command.Parameters.Add("v_csnguycap", NpgsqlDbType.Varchar,50).Value = v_csnguycap;
            m_command.Parameters.Add("v_min_csnguycap", NpgsqlDbType.Numeric).Value = v_min_csnguycap;
            m_command.Parameters.Add("v_max_csnguycap", NpgsqlDbType.Numeric).Value = v_max_csnguycap;
            m_command.Parameters.Add("v_delta", NpgsqlDbType.Numeric).Value = v_delta;
            m_command.Parameters.Add("v_thoigian", NpgsqlDbType.Integer).Value = v_thoigian;
            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_ten(id,id_loai,id_nhom,stt,ma,ten,viettat,donvi,csbt_nu,csbt_nam,mincsbt_nu,maxcsbt_nu,mincsbt_nam,maxcsbt_nam,tieuban,ghichu,readonly,cs_nguycap,min_csnuycap,max_csnuycap,delta_chk,tg_tinh) ";//delta_chk=:v_delta,tg_tinh=:v_thoigian
                    m_sql += " values(:v_id,:v_id_loai,:v_id_nhom,:v_stt,:v_ma,:v_ten,:v_viettat,:v_donvi,:v_csbt_nu,:v_csbt_nam,:v_mincsbt_nu,:v_maxcsbt_nu,:v_mincsbt_nam,:v_maxcsbt_nam,:v_tieuban,:v_ghichu,:v_readonly,:v_csnguycap,:v_min_csnguycap,:v_max_csnguycap,:v_delta,:v_thoigian)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_id_loai", NpgsqlDbType.Numeric).Value = v_id_loai;
                    m_command.Parameters.Add("v_id_nhom", NpgsqlDbType.Numeric).Value = v_id_nhom;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_viettat;
                    m_command.Parameters.Add("v_donvi", NpgsqlDbType.Numeric).Value = v_donvi;
                    m_command.Parameters.Add("v_csbt_nu", NpgsqlDbType.Text).Value = v_csbt_nu;
                    m_command.Parameters.Add("v_csbt_nam", NpgsqlDbType.Text).Value = v_csbt_nam;
                    m_command.Parameters.Add("v_mincsbt_nu", NpgsqlDbType.Numeric).Value = v_mincsbt_nu;
                    m_command.Parameters.Add("v_maxcsbt_nu", NpgsqlDbType.Numeric).Value = v_maxcsbt_nu;
                    m_command.Parameters.Add("v_mincsbt_nam", NpgsqlDbType.Numeric).Value = v_mincsbt_nam;
                    m_command.Parameters.Add("v_maxcsbt_nam", NpgsqlDbType.Numeric).Value = v_maxcsbt_nam;
                    m_command.Parameters.Add("v_tieuban", NpgsqlDbType.Numeric).Value = v_tieuban;
                    m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;
                    m_command.Parameters.Add("v_csnguycap", NpgsqlDbType.Varchar, 50).Value = v_csnguycap;
                    m_command.Parameters.Add("v_min_csnguycap", NpgsqlDbType.Numeric).Value = v_min_csnguycap;
                    m_command.Parameters.Add("v_max_csnguycap", NpgsqlDbType.Numeric).Value = v_max_csnguycap;
                    m_command.Parameters.Add("v_delta", NpgsqlDbType.Numeric).Value = v_delta;
                    m_command.Parameters.Add("v_thoigian", NpgsqlDbType.Integer).Value = v_thoigian;
                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_ten");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_capid(decimal v_ma, string v_ten, decimal v_id)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_capid set ten=:v_ten,id=:v_id where ma=:v_ma";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 10).Value = v_ten;
            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_capid(ma,ten,id) values(:v_ma,:v_ten,:v_id)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 10).Value = v_ten;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_capid");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_bv_so(decimal v_id, decimal v_id_so, decimal v_stt, string v_ma, string v_ten, string v_viettat, string v_tenreport, decimal v_readonly)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_bv_so set stt=:v_stt,ma=:v_ma,ten=:v_ten,viettat=:v_viettat,tenreport=:v_tenreport, id_so=:v_id_so,readonly=:v_readonly where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_ma", NpgsqlDbType.Text, 10).Value = v_ma;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 100).Value = v_ten;
            m_command.Parameters.Add("v_id_so", NpgsqlDbType.Numeric).Value = v_id_so;
            m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_viettat;
            m_command.Parameters.Add("v_tenreport", NpgsqlDbType.Text).Value = v_tenreport;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_bv_so(id,stt,ma,ten,viettat,tenreport,id_so,readonly) values(:v_id,:v_stt,:v_ma,:v_ten,:v_viettat,:v_tenreport,:v_id_so,:v_readonly)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Text, 10).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 100).Value = v_ten;
                    m_command.Parameters.Add("v_id_so", NpgsqlDbType.Numeric).Value = v_id_so;
                    m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_viettat;
                    m_command.Parameters.Add("v_tenreport", NpgsqlDbType.Text).Value = v_tenreport;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_bv_so");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_bv_ten(decimal v_id, decimal v_id_bv_so, decimal v_id_vienphi, decimal v_stt, string v_ma, string v_ten, string v_viettat, decimal v_tieuban, decimal v_readonly)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_bv_ten set id_bv_so=:v_id_bv_so,id_vienphi=:v_id_vienphi,stt=:v_stt,ma=:v_ma,ten=:v_ten,viettat=:v_viettat,tieuban=:v_tieuban,readonly=:v_readonly where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_id_bv_so", NpgsqlDbType.Numeric).Value = v_id_bv_so;
            m_command.Parameters.Add("v_id_vienphi", NpgsqlDbType.Numeric).Value = v_id_vienphi;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_ma", NpgsqlDbType.Text).Value = v_ma;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
            m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_viettat;
            m_command.Parameters.Add("v_tieuban", NpgsqlDbType.Numeric).Value = v_tieuban;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_bv_ten(id,id_bv_so,id_vienphi,stt,ma,ten,viettat,tieuban,readonly) values(:v_id,:v_id_bv_so,:v_id_vienphi,:v_stt,:v_ma,:v_ten,:v_viettat,:v_tieuban,:v_readonly)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_id_bv_so", NpgsqlDbType.Numeric).Value = v_id_bv_so;
                    m_command.Parameters.Add("v_id_vienphi", NpgsqlDbType.Numeric).Value = v_id_vienphi;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Text).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_viettat;
                    m_command.Parameters.Add("v_tieuban", NpgsqlDbType.Numeric).Value = v_tieuban;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_bv_ten");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_bv_ten_only_update(decimal v_id, decimal v_stt, string v_ma, string v_ten, string v_viettat, decimal v_tieuban,string v_dvt)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_bv_ten set stt=:v_stt,ma=:v_ma,ten=:v_ten, viettat=:v_viettat,tieuban=:v_tieuban,dvt=:v_dvt where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_ma", NpgsqlDbType.Text).Value = v_ma;
            m_command.Parameters.Add("v_dvt", NpgsqlDbType.Text).Value = v_dvt;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
            m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_viettat;
            m_command.Parameters.Add("v_tieuban", NpgsqlDbType.Numeric).Value = v_tieuban;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_bv_ten_only_update");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_vitrung_thuoc(decimal v_id, string v_sir, decimal v_id_thuoc)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_vitrung_thuoc set sir=:v_sir, id_thuoc=:v_id_thuoc where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_sir", NpgsqlDbType.Varchar, 1).Value = v_sir;
            m_command.Parameters.Add("v_id_thuoc", NpgsqlDbType.Numeric).Value = v_id_thuoc;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_vitrung_thuoc(id,sir,id_thuoc) values(:v_id,:v_sir,:v_id_thuoc)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_sir", NpgsqlDbType.Varchar, 1).Value = v_sir;
                    m_command.Parameters.Add("v_id_thuoc", NpgsqlDbType.Numeric).Value = v_id_thuoc;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_thuoc");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_thuoc(decimal v_id, decimal v_stt, decimal v_ma)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_thuoc set stt=:v_stt, ma=:v_ma where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_thuoc(id,stt,ma) values(:v_id,:v_stt,:v_ma)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_thuoc");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_bv_chitiet(decimal v_id, decimal v_id_bv_ten, decimal v_id_ten, decimal v_stt, decimal v_tieuban, string v_viettat, decimal v_readonly)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_bv_chitiet set id_bv_ten=:v_id_bv_ten, id_ten=:v_id_ten, stt=:v_stt, tieuban=:v_tieuban,viettat=:v_viettat,readonly=:v_readonly where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_id_bv_ten", NpgsqlDbType.Numeric).Value = v_id_bv_ten;
            m_command.Parameters.Add("v_id_ten", NpgsqlDbType.Numeric).Value = v_id_ten;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_tieuban", NpgsqlDbType.Numeric).Value = v_tieuban;
            m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_viettat;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_bv_chitiet(id,id_bv_ten,id_ten,stt,tieuban,viettat,readonly) values(:v_id,:v_id_bv_ten,:v_id_ten,:v_stt,:v_tieuban,:v_viettat,:v_readonly)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_id_bv_ten", NpgsqlDbType.Numeric).Value = v_id_bv_ten;
                    m_command.Parameters.Add("v_id_ten", NpgsqlDbType.Numeric).Value = v_id_ten;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_tieuban", NpgsqlDbType.Numeric).Value = v_tieuban;
                    m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_viettat;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_bv_chitiet");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_bv_chitiet_only_update(decimal v_id, decimal v_stt, decimal v_tieuban, string v_viettat, string v_macdinh)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_bv_chitiet set stt=:v_stt, tieuban=:v_tieuban, viettat=:v_viettat,macdinh=:v_macdinh where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_tieuban", NpgsqlDbType.Numeric).Value = v_tieuban;
            m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_viettat;
            m_command.Parameters.Add("v_macdinh", NpgsqlDbType.Text).Value = v_macdinh;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_bv_chitiet_only_update");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }

        public bool upd_xn_hoachatdm(decimal v_id_ten, decimal v_makho, decimal v_manguon, string v_makp, decimal v_mahc, decimal v_soluong, decimal v_soluongqd, decimal v_readonly, int v_dvt)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_hoachatdm set makho=:v_makho,makp=:v_makp,manguon=:v_manguon,soluong=:v_soluong,soluongqd=:v_soluongqd,readonly=:v_readonly,dvt=" + v_dvt.ToString() + " where id_ten=:v_id_ten and mahc=:v_mahc";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            //m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            //m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            //m_command.Parameters.Add("v_mmyy", NpgsqlDbType.Varchar,4).Value = v_mmyy;

            m_command.Parameters.Add("v_makho", NpgsqlDbType.Numeric).Value = v_makho;
            m_command.Parameters.Add("v_manguon", NpgsqlDbType.Numeric).Value = v_manguon;
            m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 3).Value = v_makp;
            m_command.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
            m_command.Parameters.Add("v_soluongqd", NpgsqlDbType.Numeric).Value = v_soluongqd;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;
            m_command.Parameters.Add("v_id_ten", NpgsqlDbType.Numeric).Value = v_id_ten;
            m_command.Parameters.Add("v_mahc", NpgsqlDbType.Numeric).Value = v_mahc;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_hoachatdm(id_ten,makho,manguon,makp,mahc,soluong,soluongqd,readonly,dvt) values(:v_id_ten,:v_makho,:v_manguon,:v_makp,:v_mahc,:v_soluong,:v_soluongqd,:v_readonly," + v_dvt.ToString() + ")";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    //m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    //m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    //m_command.Parameters.Add("v_mmyy", NpgsqlDbType.Varchar, 4).Value = v_mmyy;
                    m_command.Parameters.Add("v_id_ten", NpgsqlDbType.Numeric).Value = v_id_ten;
                    m_command.Parameters.Add("v_makho", NpgsqlDbType.Numeric).Value = v_makho;
                    m_command.Parameters.Add("v_manguon", NpgsqlDbType.Numeric).Value = v_manguon;
                    m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 3).Value = v_makp;
                    m_command.Parameters.Add("v_mahc", NpgsqlDbType.Numeric).Value = v_mahc;
                    m_command.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
                    m_command.Parameters.Add("v_soluongqd", NpgsqlDbType.Numeric).Value = v_soluongqd;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_hoachatdm");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }


        public bool upd_xn_hoachatdm(decimal v_id_ten, decimal v_makho, decimal v_manguon, string v_makp, decimal v_mahc, decimal v_soluong, decimal v_soluongqd, decimal v_readonly, int v_dvt, int v_haohut)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_hoachatdm set makho=:v_makho,makp=:v_makp,manguon=:v_manguon,soluong=:v_soluong,soluongqd=:v_soluongqd,readonly=:v_readonly,dvt=" + v_dvt.ToString() + ",haohut=" + v_haohut.ToString() + " where id_ten=:v_id_ten and mahc=:v_mahc";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            //m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            //m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            //m_command.Parameters.Add("v_mmyy", NpgsqlDbType.Varchar,4).Value = v_mmyy;

            m_command.Parameters.Add("v_makho", NpgsqlDbType.Numeric).Value = v_makho;
            m_command.Parameters.Add("v_manguon", NpgsqlDbType.Numeric).Value = v_manguon;
            m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 3).Value = v_makp;
            m_command.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
            m_command.Parameters.Add("v_soluongqd", NpgsqlDbType.Numeric).Value = v_soluongqd;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;
            m_command.Parameters.Add("v_id_ten", NpgsqlDbType.Numeric).Value = v_id_ten;
            m_command.Parameters.Add("v_mahc", NpgsqlDbType.Numeric).Value = v_mahc;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_hoachatdm(id_ten,makho,manguon,makp,mahc,soluong,soluongqd,readonly,dvt,haohut) values(:v_id_ten,:v_makho,:v_manguon,:v_makp,:v_mahc,:v_soluong,:v_soluongqd,:v_readonly," + v_dvt.ToString() + "," + v_haohut.ToString() + ")";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    //m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    //m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    //m_command.Parameters.Add("v_mmyy", NpgsqlDbType.Varchar, 4).Value = v_mmyy;
                    m_command.Parameters.Add("v_id_ten", NpgsqlDbType.Numeric).Value = v_id_ten;
                    m_command.Parameters.Add("v_makho", NpgsqlDbType.Numeric).Value = v_makho;
                    m_command.Parameters.Add("v_manguon", NpgsqlDbType.Numeric).Value = v_manguon;
                    m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 3).Value = v_makp;
                    m_command.Parameters.Add("v_mahc", NpgsqlDbType.Numeric).Value = v_mahc;
                    m_command.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
                    m_command.Parameters.Add("v_soluongqd", NpgsqlDbType.Numeric).Value = v_soluongqd;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_hoachatdm");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_done(decimal v_id, string v_mabn, decimal v_maql, string v_ngaycd10, string v_maxnvp, decimal v_mavp, string v_ngayxn10, decimal v_done)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_done set mabn=:v_mabn,maql=:v_maql,ngaycd=to_date(:v_ngaycd,'dd/mm/yyyy'),maxnvp=:v_maxnvp,mavp=:v_mavp,ngayxn=to_date(:v_ngayxn,'dd/mm/yyyy'),done=:v_done where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 10).Value = v_mabn;
            m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
            m_command.Parameters.Add("v_ngaycd", NpgsqlDbType.Text).Value = v_ngaycd10;
            m_command.Parameters.Add("v_maxnvp", NpgsqlDbType.Text, 50).Value = v_maxnvp;
            m_command.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
            m_command.Parameters.Add("v_ngayxn", NpgsqlDbType.Text).Value = v_ngayxn10;
            m_command.Parameters.Add("v_done", NpgsqlDbType.Numeric).Value = v_done;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_done(id,mabn,maql,ngaycd,maxnvp,mavp,ngayxn,done) values(:v_id,:v_man,:v_maql,to_date(:v_ngaycd,'dd/mm/yyyy'),:v_maxnvp,:v_mavp,to_date(:v_ngayxn,'dd/mm/yyyy'),:v_done)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 10).Value = v_mabn;
                    m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                    m_command.Parameters.Add("v_ngaycd", NpgsqlDbType.Text).Value = v_ngaycd10;
                    m_command.Parameters.Add("v_maxnvp", NpgsqlDbType.Text, 50).Value = v_maxnvp;
                    m_command.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
                    m_command.Parameters.Add("v_ngayxn", NpgsqlDbType.Text).Value = v_ngayxn10;
                    m_command.Parameters.Add("v_done", NpgsqlDbType.Numeric).Value = v_done;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_done");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_sdmauthu(decimal v_id_ten, decimal v_id_mauthu, decimal v_soluong, decimal v_readonly)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_sdmauthu set soluong=:v_soluong, readonly=:v_readonly where id_ten=:v_id_ten and id_mauthu=:v_id_mauthu";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id_ten", NpgsqlDbType.Numeric).Value = v_id_ten;
            m_command.Parameters.Add("v_id_mauthu", NpgsqlDbType.Numeric).Value = v_id_mauthu;
            m_command.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_sdmauthu(id_ten,id_mauthu,soluong,readonly) values(:v_id_ten,:v_id_mauthu,:v_soluong,:v_readonly)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id_ten", NpgsqlDbType.Numeric).Value = v_id_ten;
                    m_command.Parameters.Add("v_id_mauthu", NpgsqlDbType.Numeric).Value = v_id_mauthu;
                    m_command.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_sdmauthu");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_ktv(string v_ma, string v_hoten, string v_viettat,int v_chucvu,int v_duyetmau,string v_passwd, decimal v_readonly)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_ktv set hoten=:v_hoten, viettat=:v_viettat,";
            m_sql += "chucvu=:v_chucvu,duyetmau=:v_duyetmau,passwd=:v_passwd, readonly=:v_readonly where ma=:v_ma";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 15).Value = v_ma;
            m_command.Parameters.Add("v_hoten", NpgsqlDbType.Text).Value = v_hoten;
            m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_viettat;
            m_command.Parameters.Add("v_chucvu", NpgsqlDbType.Integer).Value = v_chucvu;
            m_command.Parameters.Add("v_duyetmau", NpgsqlDbType.Integer).Value = v_duyetmau;
            m_command.Parameters.Add("v_passwd", NpgsqlDbType.Varchar, 20).Value = v_passwd;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_ktv(ma,hoten,viettat,chucvu,duyetmau,passwd,readonly) values(:v_ma,:v_hoten,:v_viettat,:v_chucvu,:v_duyetmau,:v_passwd,:v_readonly)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 15).Value = v_ma;
                    m_command.Parameters.Add("v_hoten", NpgsqlDbType.Text).Value = v_hoten;
                    m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_viettat;
                    m_command.Parameters.Add("v_chucvu", NpgsqlDbType.Integer).Value = v_chucvu;
                    m_command.Parameters.Add("v_duyetmau", NpgsqlDbType.Integer).Value = v_duyetmau;
                    m_command.Parameters.Add("v_passwd", NpgsqlDbType.Varchar, 20).Value = v_passwd;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_ktv");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_gram_vt(string v_ma, string v_ten, decimal v_readonly)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_gram_vt set ten=:v_ten, readonly=:v_readonly where ma=:v_ma";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_gram_vt(ma,ten,readonly) values(:v_ma,:v_ten,:v_readonly)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_gram_vt");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_status_vt(string v_ma, string v_ten, decimal v_readonly)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_status_vt set ten=:v_ten, readonly=:v_readonly where ma=:v_ma";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_status_vt(ma,ten,readonly) values(:v_ma,:v_ten,:v_readonly)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_status_vt");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_thongso(decimal v_id, string v_loai, string v_ten)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_thongso set loai=:v_loai,ten=:v_ten where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_loai", NpgsqlDbType.Text, 10).Value = v_loai;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 100).Value = v_ten;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_thongso(id,loai,ten) values(:v_id,:v_loai,:v_ten)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_loai", NpgsqlDbType.Text, 10).Value = v_loai;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 100).Value = v_ten;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_thongso");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_nhomdlogin(decimal v_id, decimal v_nhom, string v_ma, string v_ten, string v_diengiai, string v_id_bv_so, string v_right_)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_nhomdlogin set nhom=:v_nhom, ma=:v_ma,ten=:v_ten,diengiai=:v_diengiai, id_bv_so=:v_id_bv_so, right_=:v_right_ where id=:v_id";
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
                    m_sql = "insert into " + m_db_schemaroot + ".xn_nhomdlogin(id,nhom,ma,ten,diengiai,id_bv_so,right_) values(:v_id,:v_nhom,:v_ma,:v_ten,:v_diengiai,:v_id_bv_so,:v_right_)";
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

                    execute_data("insert into " + s_schemaroot + ".xn_phanquyennhom(id_nhom,menuname,chon,chitiet) select " + v_id + ",menuname,chon,chitiet from " + s_schemaroot + ".xn_phanquyennhom where id_nhom=" + (v_nhom*-1).ToString());
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_nhomdlogin");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_dlogin(decimal v_id, decimal v_id_nhom, string v_hoten, string v_userid, string v_password_, string v_id_bv_so,string v_makp)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_dlogin set id_nhom=:v_id_nhom, hoten=:v_hoten, userid=:v_userid,password_=:v_password_,id_bv_so=:v_id_bv_so,makp=:v_makp where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_id_nhom", NpgsqlDbType.Numeric).Value = v_id_nhom;
            m_command.Parameters.Add("v_hoten", NpgsqlDbType.Text, 50).Value = v_hoten;
            m_command.Parameters.Add("v_userid", NpgsqlDbType.Text).Value = v_userid;
            m_command.Parameters.Add("v_password_", NpgsqlDbType.Text).Value = v_password_;
            m_command.Parameters.Add("v_id_bv_so", NpgsqlDbType.Varchar, 4000).Value = v_id_bv_so;
            m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 2).Value = v_makp;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_dlogin(id,id_nhom,hoten,userid,password_,id_bv_so,makp) values(:v_id,:v_id_nhom,:v_hoten,:v_userid,:v_password_,:v_id_bv_so,:v_makp)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_id_nhom", NpgsqlDbType.Numeric).Value = v_id_nhom;
                    m_command.Parameters.Add("v_hoten", NpgsqlDbType.Text, 50).Value = v_hoten;
                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Text).Value = v_userid;
                    m_command.Parameters.Add("v_password_", NpgsqlDbType.Text).Value = v_password_;
                    m_command.Parameters.Add("v_id_bv_so", NpgsqlDbType.Varchar, 4000).Value = v_id_bv_so;
                    m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 2).Value = v_makp;
                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();

                    execute_data("insert into " + s_schemaroot + ".xn_phanquyen(userid,menuname,chon,chitiet) select " + v_id + ",menuname,chon,chitiet from " + s_schemaroot + ".xn_phanquyennhom where id_nhom=" + v_id_nhom);
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_dlogin");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_vitrung(decimal v_id, decimal v_stt, string v_ma, string v_ten, string v_gram, string v_status, string v_viettat)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_vitrung set stt=:v_stt, ma=:v_ma, ten=:v_ten, gram=:v_gram, status=:v_status, viettat=:v_viettat where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
            m_command.Parameters.Add("v_gram", NpgsqlDbType.Text).Value = v_gram;
            m_command.Parameters.Add("v_status", NpgsqlDbType.Text).Value = v_status;
            m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_viettat;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_vitrung(id,stt,ma,ten,gram,status,viettat) values(:v_id,:v_stt,:v_ma,:v_ten,:v_gram,:v_status,:v_viettat)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_gram", NpgsqlDbType.Text).Value = v_gram;
                    m_command.Parameters.Add("v_status", NpgsqlDbType.Text).Value = v_status;
                    m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_viettat;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_vitrung");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_bv_vitrung(decimal v_id, decimal v_id_vitrung, decimal v_id_giavp, decimal v_stt, string v_ma, string v_ten, string v_viettat, string v_khangsinh, string v_gram, string v_status,string v_tenboks, decimal v_readonly)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_bv_vitrung set id_vitrung=:v_id_vitrung, id_giavp=:v_id_giavp, stt=:v_stt, ma=:v_ma, ten=:v_ten,viettat=:v_viettat, khangsinh=:v_khangsinh, gram=:v_gram, status=:v_status,tenboks=:v_tenboks,readonly=:v_readonly where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_id_vitrung", NpgsqlDbType.Numeric).Value = v_id_vitrung;
            m_command.Parameters.Add("v_id_giavp", NpgsqlDbType.Numeric).Value = v_id_giavp;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
            m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_viettat;
            m_command.Parameters.Add("v_khangsinh", NpgsqlDbType.Varchar, 1000).Value = v_khangsinh;
            m_command.Parameters.Add("v_gram", NpgsqlDbType.Text).Value = v_gram;
            m_command.Parameters.Add("v_status", NpgsqlDbType.Text).Value = v_status;
            m_command.Parameters.Add("v_tenboks", NpgsqlDbType.Text).Value = v_tenboks;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_bv_vitrung(id,id_vitrung,id_giavp,stt,ma,ten,viettat,khangsinh,gram,status,tenboks,readonly) values(:v_id,:v_id_vitrung,:v_id_giavp,:v_stt,:v_ma,:v_ten,:v_viettat,:v_khangsinh,:v_gram,:v_status,:v_tenboks,:v_readonly)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_id_vitrung", NpgsqlDbType.Numeric).Value = v_id_vitrung;
                    m_command.Parameters.Add("v_id_giavp", NpgsqlDbType.Numeric).Value = v_id_giavp;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_viettat;
                    m_command.Parameters.Add("v_khangsinh", NpgsqlDbType.Varchar, 1000).Value = v_khangsinh;
                    m_command.Parameters.Add("v_gram", NpgsqlDbType.Text).Value = v_gram;
                    m_command.Parameters.Add("v_status", NpgsqlDbType.Text).Value = v_status;
                    m_command.Parameters.Add("v_tenboks", NpgsqlDbType.Text).Value = v_tenboks;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_bv_vitrung");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_bv_vitrung(decimal v_id, string v_tenboks)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_bv_vitrung set tenboks=:v_tenboks where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_tenboks", NpgsqlDbType.Text).Value = v_tenboks;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_bv_vitrung");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_khangsinh(decimal v_id, decimal v_stt, string v_ma, string v_mabv, string v_ten, string v_viettat, decimal v_readonly)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_khangsinh set stt=:v_stt, ma=:v_ma, mabv=:v_mabv, ten=:v_ten,viettat=:v_viettat, readonly=:v_readonly where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
            m_command.Parameters.Add("v_mabv", NpgsqlDbType.Varchar, 10).Value = v_mabv;
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
                    m_sql = "insert into " + m_db_schemaroot + ".xn_khangsinh(id,stt,ma,mabv,ten,readonly) values(:v_id,:v_stt,:v_ma,:v_mabv,:v_ten,:v_readonly)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
                    m_command.Parameters.Add("v_mabv", NpgsqlDbType.Varchar, 10).Value = v_mabv;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_viettat;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_khangsinh");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_bv_khangsinh(decimal v_id, decimal v_id_bv_vitrung, decimal v_stt, decimal v_id_khangsinh, decimal v_maxR, decimal v_minS, string v_hamluong, decimal v_readonly)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_bv_khangsinh set stt=:v_stt,id_bv_vitrung=:v_id_bv_vitrung,id_khangsinh=:v_id_khangsinh,maxr=:v_maxr,mins=:v_mins,hamluong=:v_hamluong,readonly=:v_readonly where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_id_bv_vitrung", NpgsqlDbType.Numeric).Value = v_id_bv_vitrung;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_id_khangsinh", NpgsqlDbType.Numeric).Value = v_id_khangsinh;
            m_command.Parameters.Add("v_maxr", NpgsqlDbType.Numeric).Value = v_maxR;
            m_command.Parameters.Add("v_mins", NpgsqlDbType.Numeric).Value = v_minS;
            m_command.Parameters.Add("v_hamluong", NpgsqlDbType.Text).Value = v_hamluong;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;
            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_bv_khangsinh(id,id_bv_vitrung,stt,id_khangsinh,maxr,mins,hamluong,readonly) values (:v_id,:v_id_bv_vitrung,:v_stt,:v_id_khangsinh,:v_maxr,:v_mins,:v_hamluong,:v_readonly)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_id_bv_vitrung", NpgsqlDbType.Numeric).Value = v_id_bv_vitrung;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_id_khangsinh", NpgsqlDbType.Numeric).Value = v_id_khangsinh;
                    m_command.Parameters.Add("v_maxr", NpgsqlDbType.Numeric).Value = v_maxR;
                    m_command.Parameters.Add("v_mins", NpgsqlDbType.Numeric).Value = v_minS;
                    m_command.Parameters.Add("v_hamluong", NpgsqlDbType.Text).Value = v_hamluong;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;
                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_bv_khangsinh");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_mauthu(decimal v_id, decimal v_stt, string v_ma, string v_mabv, string v_ten, string v_anh, string v_viettat, decimal v_donvi, decimal v_readonly, decimal v_id_vatchuabp)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_mauthu set stt=:v_stt,ma=:v_ma,mabv=:v_mabv,ten=:v_ten,anh=:v_anh,viettat=:v_viettat,donvi=:v_donvi, readonly=:v_readonly,id_vatchuabp=:v_id_vatchuabp where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
            m_command.Parameters.Add("v_mabv", NpgsqlDbType.Varchar, 10).Value = v_mabv;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
            m_command.Parameters.Add("v_anh", NpgsqlDbType.Text).Value = v_anh;
            m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_viettat;
            m_command.Parameters.Add("v_donvi", NpgsqlDbType.Numeric).Value = v_donvi;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;
            m_command.Parameters.Add("v_id_vatchuabp", NpgsqlDbType.Numeric).Value = v_id_vatchuabp;
            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_mauthu(id,stt,ma,mabv,ten,anh,viettat,donvi,readonly,id_vatchuabp) ";
                    m_sql += " values (:v_id,:v_stt,:v_ma,:v_mabv,:v_ten,:v_anh,:v_viettat,:v_donvi,:v_readonly,:v_id_vatchuabp)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
                    m_command.Parameters.Add("v_mabv", NpgsqlDbType.Varchar, 10).Value = v_mabv;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_anh", NpgsqlDbType.Text).Value = v_anh;
                    m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_viettat;
                    m_command.Parameters.Add("v_donvi", NpgsqlDbType.Numeric).Value = v_donvi;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;
                    m_command.Parameters.Add("v_id_vatchuabp", NpgsqlDbType.Numeric).Value = v_id_vatchuabp;
                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_mauthu");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        //TU:22/06/2011 cap nhat danh muc vat chua benh pham
        public bool upd_xn_dmvatchuabp(decimal v_id, string v_ten, string v_dvt)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_dmvatchuabp set ten=:v_ten, dvt=:v_dvt where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
            m_command.Parameters.Add("v_dvt", NpgsqlDbType.Text).Value = v_dvt;
            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_dmvatchuabp(id,ten,dvt) values(:v_id,:v_ten,:v_dvt)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_dvt", NpgsqlDbType.Text).Value = v_dvt;
                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_dmvatchuabp");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        //end Tu
        public bool upd_xn_tinhtrang(decimal v_id, decimal v_stt, string v_ma, string v_ten)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_tinhtrang set stt=:v_stt,ma=:v_ma,ten=:v_ten where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_ma", NpgsqlDbType.Text, 10).Value = v_ma;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 100).Value = v_ten;
            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_tinhtrang(id,stt,ma,ten,readonly) values (:v_id,:v_stt,:v_ma,:v_ten,0)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Text, 10).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 100).Value = v_ten;
                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_tinhtrang");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_vitri(decimal v_id, decimal v_stt, string v_ma, string v_mabv, string v_ten, string v_anh, string v_viettat, decimal v_readonly)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_vitri set stt=:v_stt,ma=:v_ma,mabv=:v_mabv,ten=:v_ten,anh=:v_anh, viettat=:v_viettat, readonly=:v_readonly where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_ma", NpgsqlDbType.Text, 10).Value = v_ma;
            m_command.Parameters.Add("v_mabv", NpgsqlDbType.Varchar, 10).Value = v_mabv;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
            m_command.Parameters.Add("v_anh", NpgsqlDbType.Text).Value = v_anh;
            m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_anh;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;
            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_vitri(id,stt,ma,mabv,ten,anh,viettat,readonly) values (:v_id,:v_stt,:v_ma,:v_mabv,:v_ten,:v_anh,:v_viettat,:v_readonly)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Text, 10).Value = v_ma;
                    m_command.Parameters.Add("v_mabv", NpgsqlDbType.Varchar, 10).Value = v_mabv;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_anh", NpgsqlDbType.Text).Value = v_anh;
                    m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_anh;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;
                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_vitri");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_donvi(decimal v_id, string v_ma, string v_ten, string v_ten1, decimal v_heso, decimal v_id_hl7)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_donvi set ma=:v_ma,ten=:v_ten,ten1=:v_ten1,heso=:v_heso,id_hl7=:v_id_hl7 where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 100).Value = v_ten;
            m_command.Parameters.Add("v_ten1", NpgsqlDbType.Text, 100).Value = v_ten1;
            m_command.Parameters.Add("v_heso", NpgsqlDbType.Numeric).Value = v_heso;
            m_command.Parameters.Add("v_id_hl7", NpgsqlDbType.Numeric).Value = v_id_hl7;
            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_donvi(id,ma,ten,ten1,heso,id_hl7,readonly) values (:v_id,:v_ma,:v_ten,:v_ten1,:v_heso,:v_id_hl7,0)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 100).Value = v_ten;
                    m_command.Parameters.Add("v_ten1", NpgsqlDbType.Text, 100).Value = v_ten1;
                    m_command.Parameters.Add("v_heso", NpgsqlDbType.Numeric).Value = v_heso;
                    m_command.Parameters.Add("v_id_hl7", NpgsqlDbType.Numeric).Value = v_id_hl7;
                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_donvi");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_donvi_hl7(decimal v_id, decimal v_stt, string v_ma, string v_ten, string v_anh, decimal v_readonly)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_donvi_hl7 set stt=:v_stt, ma=:v_ma,ten=:v_ten,anh=:v_anh, readonly=:v_readonly where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_ma", NpgsqlDbType.Text, 30).Value = v_ma;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 100).Value = v_ten;
            m_command.Parameters.Add("v_anh", NpgsqlDbType.Text, 100).Value = v_anh;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;
            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_donvi_hl7(id,stt,ma,ten,anh,readonly) values (:v_id,:v_stt,:v_ma,:v_ten,:v_anh,:v_readonly)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Text, 30).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 100).Value = v_ten;
                    m_command.Parameters.Add("v_anh", NpgsqlDbType.Text, 100).Value = v_anh;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;
                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_donvi_hl7");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_diadiem(decimal v_id, decimal v_stt, string v_ma, string v_ten, string v_viettat, decimal v_readonly)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_diadiem set stt=:v_stt, ma=:v_ma,ten=:v_ten,viettat=:v_viettat, readonly=:v_readonly where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_ma", NpgsqlDbType.Text, 10).Value = v_ma;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
            m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_ten;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;
            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_diadiem(id,stt,ma,ten,viettat,readonly) values (:v_id,:v_stt,:v_ma,:v_ten,:v_viettat,:v_readonly)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Text, 10).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_viettat", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;
                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_diadiem");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_btdvt(string m_matat, string m_daydu)
        {
            m_sql = "update btdvt set daydu=:m_daydu where lower(trim(matat))=:m_matat";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("m_daydu", NpgsqlDbType.Text, 100).Value = m_daydu;
            m_command.Parameters.Add("m_matat", NpgsqlDbType.Text, 30).Value = m_matat.Trim().ToLower();
            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into btdvt(matat,daydu) values (:m_matat,:m_daydu)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("m_matat", NpgsqlDbType.Text, 30).Value = m_matat.Trim().ToLower();
                    m_command.Parameters.Add("m_daydu", NpgsqlDbType.Text, 100).Value = m_daydu;
                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_xn_error(ex.Message, m_computername, "btdvt");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public void upd_xn_error(string v_message, string v_computer, string v_table)
        {
            m_sql = "insert into " + s_schemaroot + ".xn_error(message,computer,tables,ngayud) values (:v_message,:v_computer,:v_table,now())";
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
        public void upd_xn_error(string v_mmyy, string m_message, string m_computer, string m_table)
        {
            m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".xn_error(message,computer,tables,ngayud) values (:m_message,:m_computer,:m_table,now())";
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
        public bool upd_xn_phanquyen(decimal v_userid, string v_menuname, decimal v_chon, string v_chitiet)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_phanquyen set chon=:v_chon, chitiet=:v_chitiet where userid=:v_userid and menuname=:v_menuname";
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
                    m_sql = "insert into " + m_db_schemaroot + ".xn_phanquyen(userid,menuname,chon,chitiet) values (:v_userid,:v_menuname,:v_chon,:v_chitiet)";
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
                upd_xn_error(ex.Message, m_computername, "xn_phanquyen");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_phanquyennhom(decimal v_id_nhom, string v_menuname, decimal v_chon, string v_chitiet)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_phanquyennhom set chon=:v_chon, chitiet=:v_chitiet where id_nhom=:v_id_nhom and menuname=:v_menuname";
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
                    m_sql = "insert into " + m_db_schemaroot + ".xn_phanquyennhom(id_nhom,menuname,chon,chitiet) values (:v_id_nhom,:v_menuname,:v_chon,:v_chitiet)";
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
                upd_xn_error(ex.Message, m_computername, "xn_phanquyennhom");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_viettatkq(decimal v_stt,string v_ma, string v_ten, decimal v_readonly)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_viettatkq set stt=:v_stt,ten=:v_ten, readonly=:v_readonly where ma=:v_ma";
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
                    m_sql = "insert into " + m_db_schemaroot + ".xn_viettatkq(stt,ma,ten,readonly) values(:v_stt,:v_ma,:v_ten,:v_readonly)";
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
                upd_xn_error(ex.Message, m_computername, "xn_viettatkq");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_viettat(decimal v_stt, string v_ma, string v_ten, decimal v_readonly)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_viettat set stt=:v_stt,ten=:v_ten, readonly=:v_readonly where ma=:v_ma";
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
                    m_sql = "insert into " + m_db_schemaroot + ".xn_viettat(stt,ma,ten,readonly) values(:v_stt,:v_ma,:v_ten,:v_readonly)";
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
                upd_xn_error(ex.Message, m_computername, "xn_viettat");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }

        public bool upd_xn_laymau(string v_mmyy, decimal v_id, string v_mabn, decimal v_maql, decimal v_id_mauthu, decimal v_id_tinhtrang, string v_ngay16, decimal v_soluong, string v_ktv, decimal v_id_vitri, decimal v_id_diadiem, decimal v_cothai, string v_ghichu, decimal v_loaibn, decimal v_loai, decimal v_madoituong, decimal v_readonly, decimal v_userid)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".xn_laymau set mabn=:v_mabn, maql=:v_maql,id_mauthu=:v_id_mauthu,id_tinhtrang=:v_id_tinhtrang, ngay=to_date(:v_ngay,'dd/mm/yyyy hh24:mi'),soluong=:v_soluong,ktv=:v_ktv,id_vitri=:v_id_vitri, id_diadiem=:v_id_diadiem,cothai=:v_cothai,ghichu=:v_ghichu,loaibn=:v_loaibn, loai=:v_loai,madoituong=:v_madoituong,readonly=:v_readonly, userid=:v_userid where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_mabn", NpgsqlDbType.Text, 10).Value = v_mabn;
            m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
            m_command.Parameters.Add("v_id_mauthu", NpgsqlDbType.Numeric).Value = v_id_mauthu;
            m_command.Parameters.Add("v_id_tinhtrang", NpgsqlDbType.Numeric).Value = v_id_tinhtrang;
            m_command.Parameters.Add("v_ngay", NpgsqlDbType.Text, 16).Value = v_ngay16;
            m_command.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
            m_command.Parameters.Add("v_ktv", NpgsqlDbType.Varchar, 4).Value = v_ktv;
            m_command.Parameters.Add("v_id_vitri", NpgsqlDbType.Numeric).Value = v_id_vitri;
            m_command.Parameters.Add("v_id_diadiem", NpgsqlDbType.Numeric).Value = v_id_diadiem;
            m_command.Parameters.Add("v_cothai", NpgsqlDbType.Numeric).Value = v_cothai;
            m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text, 100).Value = v_ghichu;
            m_command.Parameters.Add("v_loaibn", NpgsqlDbType.Numeric).Value = v_loaibn;
            m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
            m_command.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;
            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".xn_laymau(id,mabn,maql,id_mauthu,id_tinhtrang,ngay,soluong,ktv,id_vitri,id_diadiem,cothai,ghichu, loaibn,loai,madoituong,readonly,userid) values (:v_id,:v_mabn,:v_maql,:v_id_mauthu,:v_id_tinhtrang,to_date(:v_ngay,'dd/mm/yyyy hh24:mi'),:v_soluong,:v_ktv,:v_id_vitri,:v_id_diadiem,:v_cothai,:v_ghichu,:v_loaibn,:v_loai,:v_madoituong,:v_readonly,:v_userid)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_mabn", NpgsqlDbType.Text, 10).Value = v_mabn;
                    m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                    m_command.Parameters.Add("v_id_mauthu", NpgsqlDbType.Numeric).Value = v_id_mauthu;
                    m_command.Parameters.Add("v_id_tinhtrang", NpgsqlDbType.Numeric).Value = v_id_tinhtrang;
                    m_command.Parameters.Add("v_ngay", NpgsqlDbType.Text, 16).Value = v_ngay16;
                    m_command.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
                    m_command.Parameters.Add("v_ktv", NpgsqlDbType.Varchar, 4).Value = v_ktv;
                    m_command.Parameters.Add("v_id_vitri", NpgsqlDbType.Numeric).Value = v_id_vitri;
                    m_command.Parameters.Add("v_id_diadiem", NpgsqlDbType.Numeric).Value = v_id_diadiem;
                    m_command.Parameters.Add("v_cothai", NpgsqlDbType.Numeric).Value = v_cothai;
                    m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text, 100).Value = v_ghichu;
                    m_command.Parameters.Add("v_loaibn", NpgsqlDbType.Numeric).Value = v_loaibn;
                    m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                    m_command.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;
                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_laymau");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_phieu(string v_mmyy, decimal v_id, decimal v_sophieu, string v_mabn, decimal v_maql, decimal v_idkhoa, string v_ngay16, string v_makp, string v_mabs, decimal v_loaibn, decimal v_tinhtrang, decimal v_loai, string v_maicd, decimal v_madoituong, string v_ktv, string v_ngayra16, string v_mabsdoc, string v_ghichu, string v_nhanxet, string v_ketluan, string v_denghi, string v_mabenhpham, decimal v_userid)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".xn_phieu set sophieu=:v_sophieu, mabn=:v_mabn,  maql=:v_maql, idkhoa=:v_idkhoa, ngay=to_date(:v_ngay,'dd/mm/yyyy hh24:mi'),makp=:v_makp,mabs=:v_mabs,loaibn=:v_loaibn,tinhtrang=:v_tinhtrang, loai=:v_loai, maicd=:v_maicd,madoituong=:v_madoituong,ktv=:v_ktv, ngayra=to_date(:v_ngayra,'dd/mm/yyyy hh24:mi'), mabsdoc=:v_mabsdoc, ghichu=:v_ghichu, nhanxet=:v_nhanxet, ketluan=:v_ketluan, denghi=:v_denghi,mabenhpham=:v_mabenhpham,userid=:v_userid where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_sophieu", NpgsqlDbType.Numeric).Value = v_sophieu;
            m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 10).Value = v_mabn;
            m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
            m_command.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
            m_command.Parameters.Add("v_ngay", NpgsqlDbType.Text, 16).Value = v_ngay16;
            m_command.Parameters.Add("v_ngayra", NpgsqlDbType.Text, 16).Value = v_ngayra16;
            m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 2).Value = v_makp;
            m_command.Parameters.Add("v_mabs", NpgsqlDbType.Varchar, 4).Value = v_mabs;
            m_command.Parameters.Add("v_loaibn", NpgsqlDbType.Numeric).Value = v_loaibn;
            m_command.Parameters.Add("v_tinhtrang", NpgsqlDbType.Numeric).Value = v_tinhtrang;
            m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
            m_command.Parameters.Add("v_maicd", NpgsqlDbType.Varchar, 9).Value = v_maicd;
            m_command.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
            m_command.Parameters.Add("v_ktv", NpgsqlDbType.Varchar, 4).Value = v_ktv;
            m_command.Parameters.Add("v_mabsdoc", NpgsqlDbType.Varchar, 4).Value = v_mabsdoc;
            m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;
            m_command.Parameters.Add("v_nhanxet", NpgsqlDbType.Text).Value = v_nhanxet;
            m_command.Parameters.Add("v_ketluan", NpgsqlDbType.Text).Value = v_ketluan;
            m_command.Parameters.Add("v_denghi", NpgsqlDbType.Text).Value = v_denghi;
            m_command.Parameters.Add("v_mabenhpham", NpgsqlDbType.Text).Value = v_mabenhpham;
            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".xn_phieu(id,sophieu,mabn,maql,idkhoa,ngay,ngayra,makp,mabs,loaibn,tinhtrang,loai,maicd,madoituong,ktv,mabsdoc,ghichu,nhanxet,ketluan,denghi,mabenhpham,userid) values(:v_id,:v_sophieu,:v_mabn,:v_maql,:v_idkhoa,to_date(:v_ngay,'dd/mm/yyyy hh24:mi'),to_date(:v_ngayra,'dd/mm/yyyy hh24:mi'),:v_makp,:v_mabs,:v_loaibn,:v_tinhtrang,:v_loai,:v_maicd,:v_madoituong,:v_ktv,:v_mabsdoc,:v_ghichu,:v_nhanxet,:v_ketluan,:v_denghi,:v_mabenhpham,:v_userid)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_sophieu", NpgsqlDbType.Numeric).Value = v_sophieu;
                    m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 10).Value = v_mabn;
                    m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                    m_command.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
                    m_command.Parameters.Add("v_ngay", NpgsqlDbType.Text, 16).Value = v_ngay16;
                    m_command.Parameters.Add("v_ngayra", NpgsqlDbType.Text, 16).Value = v_ngayra16;
                    m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 2).Value = v_makp;
                    m_command.Parameters.Add("v_mabs", NpgsqlDbType.Varchar, 4).Value = v_mabs;
                    m_command.Parameters.Add("v_loaibn", NpgsqlDbType.Numeric).Value = v_loaibn;
                    m_command.Parameters.Add("v_tinhtrang", NpgsqlDbType.Numeric).Value = v_tinhtrang;
                    m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                    m_command.Parameters.Add("v_maicd", NpgsqlDbType.Varchar, 9).Value = v_maicd;
                    m_command.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
                    m_command.Parameters.Add("v_ktv", NpgsqlDbType.Varchar, 4).Value = v_ktv;
                    m_command.Parameters.Add("v_mabsdoc", NpgsqlDbType.Varchar, 4).Value = v_mabsdoc;
                    m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;
                    m_command.Parameters.Add("v_nhanxet", NpgsqlDbType.Text).Value = v_nhanxet;
                    m_command.Parameters.Add("v_ketluan", NpgsqlDbType.Text).Value = v_ketluan;
                    m_command.Parameters.Add("v_denghi", NpgsqlDbType.Text).Value = v_denghi;
                    m_command.Parameters.Add("v_mabenhpham", NpgsqlDbType.Text).Value = v_mabenhpham;
                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(v_mmyy, ex.Message, m_computername, "xn_phieu");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_phieu(string v_mmyy, decimal v_id, string v_ngayra16)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".xn_ketqua set ngayra=to_date(:v_ngayra,'dd/mm/yyyy hh24:mi') where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_ngayra", NpgsqlDbType.Text, 16).Value = v_ngayra16;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
            }
            catch (Exception ex)
            {
                upd_xn_error(v_mmyy, ex.Message, m_computername, "xn_phieu");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
#region Dong bo data - dblinks
        public string get_Tendatabase(int i_idcoso)
        {
            string stendata = "";
            try
            {
                stendata = get_data("select database from " + user + ".dmchinhanh where id=" + i_idcoso + "").Tables[0].Rows[0]["database"].ToString();
            }
            catch
            {
                return stendata;
            }
            return stendata;
        }

        public bool upd_xn_maubenhpham_ct(string _dblinks,string v_mmyy, decimal v_id, decimal v_mauthu, decimal v_idvattuchua, int v_soluong, decimal v_userid)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".xn_maubenhpham_ct@" +_dblinks+" set  ";
            m_sql += " soluong=:v_soluong,userid=:v_userid where id_xnphieu=:v_id and id_mauthu=:v_mauthu and id_vatchuamau=:v_idvattuchua";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;


            m_command.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_mauthu", NpgsqlDbType.Numeric).Value = v_mauthu;
            m_command.Parameters.Add("v_idvattuchua", NpgsqlDbType.Numeric).Value = v_idvattuchua;
            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".xn_maubenhpham_ct@" + _dblinks + "(id_xnphieu,id_mauthu,id_vatchuamau,soluong,userid,nhanmau) values(:v_id,:v_mauthu,:v_idvattuchua,:v_soluong,:v_userid,0)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_mauthu", NpgsqlDbType.Numeric).Value = v_mauthu;
                    m_command.Parameters.Add("v_idvattuchua", NpgsqlDbType.Numeric).Value = v_idvattuchua;
                    m_command.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(v_mmyy, ex.Message, m_computername, "xn_maubenhpham_ct@" + _dblinks + "");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_phieu_laymau(string _dblinks,string v_mmyy, decimal v_id, decimal v_sophieu, string v_mabn, decimal v_maql, decimal v_idkhoa, string v_ngay16, string v_makp, string v_mabs, decimal v_loaibn, decimal v_tinhtrang, decimal v_loai, string v_maicd, decimal v_madoituong, string v_ktv, string v_ngayra16, string v_mabsdoc, string v_ghichu, string v_nhanxet, string v_ketluan, string v_denghi, string v_mabenhpham, decimal v_userid, string v_stt, string v_ngayud, string v_ngay_laymau16, string v_chandoan,string v_chinhanh,string v_chuyen)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".xn_phieu@" + _dblinks + " set sophieu=:v_sophieu,stt=:v_stt, mabn=:v_mabn,  maql=:v_maql, idkhoa=:v_idkhoa, ngay=to_date(:v_ngay,'dd/mm/yyyy hh24:mi'),makp=:v_makp,mabs=:v_mabs,loaibn=:v_loaibn,tinhtrang=:v_tinhtrang, loai=:v_loai, maicd=:v_maicd,madoituong=:v_madoituong,ktv=:v_ktv, ngayra=to_date(:v_ngayra,'dd/mm/yyyy hh24:mi'), mabsdoc=:v_mabsdoc, ghichu=:v_ghichu, nhanxet=:v_nhanxet, ketluan=:v_ketluan, denghi=:v_denghi,mabenhpham=:v_mabenhpham,userid=:v_userid,ngayud=to_date(:v_ngayud,'dd/mm/yyyy hh24:mi'), ngaylaymau= to_date(:v_ngay_laymau16,'dd/mm/yyyy hh24:mi'),chandoan=:v_chandoan,idchinhanh=:v_chinhanh,chuyendi=:v_chuyen where id=:v_id"; 
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_sophieu", NpgsqlDbType.Numeric).Value = v_sophieu;
            m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 10).Value = v_mabn;
            m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
            m_command.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
            m_command.Parameters.Add("v_ngay", NpgsqlDbType.Text, 16).Value = v_ngay16;
            m_command.Parameters.Add("v_ngayra", NpgsqlDbType.Text, 16).Value = v_ngayra16;
            m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 2).Value = v_makp;
            m_command.Parameters.Add("v_mabs", NpgsqlDbType.Varchar, 4).Value = v_mabs;
            m_command.Parameters.Add("v_loaibn", NpgsqlDbType.Numeric).Value = v_loaibn;
            m_command.Parameters.Add("v_tinhtrang", NpgsqlDbType.Numeric).Value = v_tinhtrang;
            m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
            m_command.Parameters.Add("v_maicd", NpgsqlDbType.Varchar, 9).Value = v_maicd;
            m_command.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
            m_command.Parameters.Add("v_ktv", NpgsqlDbType.Varchar, 4).Value = v_ktv;
            m_command.Parameters.Add("v_mabsdoc", NpgsqlDbType.Varchar, 4).Value = v_mabsdoc;
            m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;
            m_command.Parameters.Add("v_nhanxet", NpgsqlDbType.Text).Value = v_nhanxet;
            m_command.Parameters.Add("v_ketluan", NpgsqlDbType.Text).Value = v_ketluan;
            m_command.Parameters.Add("v_denghi", NpgsqlDbType.Text).Value = v_denghi;
            m_command.Parameters.Add("v_mabenhpham", NpgsqlDbType.Text).Value = v_mabenhpham;
            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
            m_command.Parameters.Add("v_ngayud", NpgsqlDbType.Text, 16).Value = v_ngayud;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Text).Value = v_stt;
            m_command.Parameters.Add("v_ngay_laymau16", NpgsqlDbType.Text, 16).Value = v_ngay_laymau16;
            m_command.Parameters.Add("v_chandoan", NpgsqlDbType.Text, 256).Value = v_chandoan;
            m_command.Parameters.Add("v_chinhanh", NpgsqlDbType.Numeric).Value = v_chinhanh;
            m_command.Parameters.Add("v_chuyen", NpgsqlDbType.Text, 256).Value = v_chuyen;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".xn_phieu@" + _dblinks + "(id,sophieu,mabn,maql,idkhoa,ngay,ngayra,makp,mabs,loaibn,tinhtrang,loai,maicd,madoituong,ktv,mabsdoc,ghichu,nhanxet,ketluan,denghi,mabenhpham,userid,ngayud,stt,ngaylaymau,chandoan,idchinhanh,chuyendi) values(:v_id,:v_sophieu,:v_mabn,:v_maql,:v_idkhoa,to_date(:v_ngay,'dd/mm/yyyy hh24:mi'),to_date(:v_ngayra,'dd/mm/yyyy hh24:mi'),:v_makp,:v_mabs,:v_loaibn,:v_tinhtrang,:v_loai,:v_maicd,:v_madoituong,:v_ktv,:v_mabsdoc,:v_ghichu,:v_nhanxet,:v_ketluan,:v_denghi,:v_mabenhpham,:v_userid,to_date(:v_ngayud,'dd/mm/yyyy hh24:mi'),:v_stt,to_date(:v_ngay_laymau16,'dd/mm/yyyy hh24:mi'),:v_chandoan,:v_chinhanh,:v_chuyen)"; 
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_sophieu", NpgsqlDbType.Numeric).Value = v_sophieu;
                    m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 10).Value = v_mabn;
                    m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                    m_command.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
                    m_command.Parameters.Add("v_ngay", NpgsqlDbType.Text, 16).Value = v_ngay16;
                    m_command.Parameters.Add("v_ngayra", NpgsqlDbType.Text, 16).Value = v_ngayra16;
                    m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 2).Value = v_makp;
                    m_command.Parameters.Add("v_mabs", NpgsqlDbType.Varchar, 4).Value = v_mabs;
                    m_command.Parameters.Add("v_loaibn", NpgsqlDbType.Numeric).Value = v_loaibn;
                    m_command.Parameters.Add("v_tinhtrang", NpgsqlDbType.Numeric).Value = v_tinhtrang;
                    m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                    m_command.Parameters.Add("v_maicd", NpgsqlDbType.Varchar, 9).Value = v_maicd;
                    m_command.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
                    m_command.Parameters.Add("v_ktv", NpgsqlDbType.Varchar, 4).Value = v_ktv;
                    m_command.Parameters.Add("v_mabsdoc", NpgsqlDbType.Varchar, 4).Value = v_mabsdoc;
                    m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;
                    m_command.Parameters.Add("v_nhanxet", NpgsqlDbType.Text).Value = v_nhanxet;
                    m_command.Parameters.Add("v_ketluan", NpgsqlDbType.Text).Value = v_ketluan;
                    m_command.Parameters.Add("v_denghi", NpgsqlDbType.Text).Value = v_denghi;
                    m_command.Parameters.Add("v_mabenhpham", NpgsqlDbType.Text).Value = v_mabenhpham;
                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                    m_command.Parameters.Add("v_ngayud", NpgsqlDbType.Text, 16).Value = v_ngayud;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Text).Value = v_stt;
                    m_command.Parameters.Add("v_ngay_laymau16", NpgsqlDbType.Text, 16).Value = v_ngay_laymau16;
                    m_command.Parameters.Add("v_chandoan", NpgsqlDbType.Text, 256).Value = v_chandoan;
                    m_command.Parameters.Add("v_chinhanh", NpgsqlDbType.Numeric).Value = v_chinhanh;
                    m_command.Parameters.Add("v_chuyen", NpgsqlDbType.Text, 256).Value = v_chuyen;
                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(v_mmyy, ex.Message, m_computername, "xn_phieu@" + _dblinks + "");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_ketqua_laymau(string _dblinks,string v_mmyy, decimal v_id, decimal v_id_ten, decimal v_idvienphi, decimal v_idduoc, decimal v_done,string v_chuyen)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".xn_ketqua@" + _dblinks + " set idvienphi=:v_idvienphi, idduoc=:v_idduoc, done=:v_done,chuyendi=:v_chuyen where id=:v_id and id_ten=:v_id_ten";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_id_ten", NpgsqlDbType.Numeric).Value = v_id_ten;
            m_command.Parameters.Add("v_idvienphi", NpgsqlDbType.Numeric).Value = v_idvienphi;
            m_command.Parameters.Add("v_idduoc", NpgsqlDbType.Numeric).Value = v_idduoc;
            m_command.Parameters.Add("v_done", NpgsqlDbType.Numeric).Value = v_done;
            m_command.Parameters.Add("v_chuyen", NpgsqlDbType.Text, 256).Value = v_chuyen;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".xn_ketqua@" + _dblinks + "(id,id_ten,idvienphi,idduoc,ketqua,ghichu,done,chuyendi) values(:v_id,:v_id_ten,:v_idvienphi,:v_idduoc,'','',:v_done,:v_chuyen)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_id_ten", NpgsqlDbType.Numeric).Value = v_id_ten;
                    m_command.Parameters.Add("v_idvienphi", NpgsqlDbType.Numeric).Value = v_idvienphi;
                    m_command.Parameters.Add("v_idduoc", NpgsqlDbType.Numeric).Value = v_idduoc;
                    m_command.Parameters.Add("v_done", NpgsqlDbType.Numeric).Value = v_done;
                    m_command.Parameters.Add("v_chuyen", NpgsqlDbType.Text, 256).Value = v_chuyen;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(v_mmyy, ex.Message, m_computername, "xn_ketqua");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_phieu(string _dblinks,string v_mmyy, decimal v_id, decimal v_sophieu, string v_mabn, decimal v_maql, decimal v_idkhoa, string v_ngay16, string v_makp, string v_mabs, decimal v_loaibn, decimal v_tinhtrang, decimal v_loai, string v_maicd, decimal v_madoituong, string v_ktv, string v_ngayra16, string v_mabsdoc, string v_ghichu, string v_nhanxet, string v_ketluan, string v_denghi, string v_mabenhpham, decimal v_userid)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".xn_phieu@" + _dblinks + " set sophieu=:v_sophieu, mabn=:v_mabn,  maql=:v_maql, idkhoa=:v_idkhoa, ngay=to_date(:v_ngay,'dd/mm/yyyy hh24:mi'),makp=:v_makp,mabs=:v_mabs,loaibn=:v_loaibn,tinhtrang=:v_tinhtrang, loai=:v_loai, maicd=:v_maicd,madoituong=:v_madoituong,ktv=:v_ktv, ngayra=to_date(:v_ngayra,'dd/mm/yyyy hh24:mi'), mabsdoc=:v_mabsdoc, ghichu=:v_ghichu, nhanxet=:v_nhanxet, ketluan=:v_ketluan, denghi=:v_denghi,mabenhpham=:v_mabenhpham,userid=:v_userid where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_sophieu", NpgsqlDbType.Numeric).Value = v_sophieu;
            m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 10).Value = v_mabn;
            m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
            m_command.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
            m_command.Parameters.Add("v_ngay", NpgsqlDbType.Text, 16).Value = v_ngay16;
            m_command.Parameters.Add("v_ngayra", NpgsqlDbType.Text, 16).Value = v_ngayra16;
            m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 2).Value = v_makp;
            m_command.Parameters.Add("v_mabs", NpgsqlDbType.Varchar, 4).Value = v_mabs;
            m_command.Parameters.Add("v_loaibn", NpgsqlDbType.Numeric).Value = v_loaibn;
            m_command.Parameters.Add("v_tinhtrang", NpgsqlDbType.Numeric).Value = v_tinhtrang;
            m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
            m_command.Parameters.Add("v_maicd", NpgsqlDbType.Varchar, 9).Value = v_maicd;
            m_command.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
            m_command.Parameters.Add("v_ktv", NpgsqlDbType.Varchar, 4).Value = v_ktv;
            m_command.Parameters.Add("v_mabsdoc", NpgsqlDbType.Varchar, 4).Value = v_mabsdoc;
            m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;
            m_command.Parameters.Add("v_nhanxet", NpgsqlDbType.Text).Value = v_nhanxet;
            m_command.Parameters.Add("v_ketluan", NpgsqlDbType.Text).Value = v_ketluan;
            m_command.Parameters.Add("v_denghi", NpgsqlDbType.Text).Value = v_denghi;
            m_command.Parameters.Add("v_mabenhpham", NpgsqlDbType.Text).Value = v_mabenhpham;
            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".xn_phieu@" + _dblinks + "(id,sophieu,mabn,maql,idkhoa,ngay,ngayra,makp,mabs,loaibn,tinhtrang,loai,maicd,madoituong,ktv,mabsdoc,ghichu,nhanxet,ketluan,denghi,mabenhpham,userid) values(:v_id,:v_sophieu,:v_mabn,:v_maql,:v_idkhoa,to_date(:v_ngay,'dd/mm/yyyy hh24:mi'),to_date(:v_ngayra,'dd/mm/yyyy hh24:mi'),:v_makp,:v_mabs,:v_loaibn,:v_tinhtrang,:v_loai,:v_maicd,:v_madoituong,:v_ktv,:v_mabsdoc,:v_ghichu,:v_nhanxet,:v_ketluan,:v_denghi,:v_mabenhpham,:v_userid)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_sophieu", NpgsqlDbType.Numeric).Value = v_sophieu;
                    m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 10).Value = v_mabn;
                    m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                    m_command.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
                    m_command.Parameters.Add("v_ngay", NpgsqlDbType.Text, 16).Value = v_ngay16;
                    m_command.Parameters.Add("v_ngayra", NpgsqlDbType.Text, 16).Value = v_ngayra16;
                    m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 2).Value = v_makp;
                    m_command.Parameters.Add("v_mabs", NpgsqlDbType.Varchar, 4).Value = v_mabs;
                    m_command.Parameters.Add("v_loaibn", NpgsqlDbType.Numeric).Value = v_loaibn;
                    m_command.Parameters.Add("v_tinhtrang", NpgsqlDbType.Numeric).Value = v_tinhtrang;
                    m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                    m_command.Parameters.Add("v_maicd", NpgsqlDbType.Varchar, 9).Value = v_maicd;
                    m_command.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
                    m_command.Parameters.Add("v_ktv", NpgsqlDbType.Varchar, 4).Value = v_ktv;
                    m_command.Parameters.Add("v_mabsdoc", NpgsqlDbType.Varchar, 4).Value = v_mabsdoc;
                    m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;
                    m_command.Parameters.Add("v_nhanxet", NpgsqlDbType.Text).Value = v_nhanxet;
                    m_command.Parameters.Add("v_ketluan", NpgsqlDbType.Text).Value = v_ketluan;
                    m_command.Parameters.Add("v_denghi", NpgsqlDbType.Text).Value = v_denghi;
                    m_command.Parameters.Add("v_mabenhpham", NpgsqlDbType.Text).Value = v_mabenhpham;
                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(v_mmyy, ex.Message, m_computername, "xn_phieu@" + _dblinks + "");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_ketqua(string _dblinks,string v_mmyy, decimal v_id, decimal v_id_ten, decimal v_idvienphi, decimal v_idduoc, string v_ketqua, string v_ghichu, decimal v_done, decimal v_idmay, int v_hople, int v_userd)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".xn_ketqua@" + _dblinks + " set idvienphi=:v_idvienphi, idduoc=:v_idduoc, ketqua=:v_ketqua, ghichu=:v_ghichu, done=:v_done,id_may=:v_idmay,ketqua_hople=:v_hople,userd=:v_userd where id=:v_id and id_ten=:v_id_ten";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_id_ten", NpgsqlDbType.Numeric).Value = v_id_ten;
            m_command.Parameters.Add("v_idvienphi", NpgsqlDbType.Numeric).Value = v_idvienphi;
            m_command.Parameters.Add("v_idduoc", NpgsqlDbType.Numeric).Value = v_idduoc;
            m_command.Parameters.Add("v_ketqua", NpgsqlDbType.Text, 50).Value = v_ketqua;
            m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text, 50).Value = v_ghichu;
            m_command.Parameters.Add("v_done", NpgsqlDbType.Numeric).Value = v_done;
            m_command.Parameters.Add("v_idmay", NpgsqlDbType.Numeric).Value = v_idmay;
            m_command.Parameters.Add("v_hople", NpgsqlDbType.Numeric).Value = v_hople;
            m_command.Parameters.Add("v_userd", NpgsqlDbType.Numeric).Value = v_userd;
            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".xn_ketqua@" + _dblinks + "(id,id_ten,idvienphi,idduoc,ketqua,ghichu,done) values(:v_id,:v_id_ten,:v_idvienphi,:v_idduoc,:v_ketqua,:v_ghichu,:v_done)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_id_ten", NpgsqlDbType.Numeric).Value = v_id_ten;
                    m_command.Parameters.Add("v_idvienphi", NpgsqlDbType.Numeric).Value = v_idvienphi;
                    m_command.Parameters.Add("v_idduoc", NpgsqlDbType.Numeric).Value = v_idduoc;
                    m_command.Parameters.Add("v_ketqua", NpgsqlDbType.Text, 50).Value = v_ketqua;
                    m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text, 50).Value = v_ghichu;
                    m_command.Parameters.Add("v_done", NpgsqlDbType.Numeric).Value = v_done;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(v_mmyy, ex.Message, m_computername, "xn_ketqua");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_ketqua(string v_mmyy, decimal v_id, decimal v_id_ten, string v_ketqua, string v_ghichu)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".xn_ketqua set ketqua=:v_ketqua, ghichu=:v_ghichu where id=:v_id and id_ten=:v_id_ten";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_id_ten", NpgsqlDbType.Numeric).Value = v_id_ten;
            //m_command.Parameters.Add("v_idvienphi", NpgsqlDbType.Numeric).Value = v_idvienphi;
            // m_command.Parameters.Add("v_idduoc", NpgsqlDbType.Numeric).Value = v_idduoc;
            m_command.Parameters.Add("v_ketqua", NpgsqlDbType.Text).Value = v_ketqua;
            m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();

            }
            catch (Exception ex)
            {
                upd_xn_error(v_mmyy, ex.Message, m_computername, "xn_ketqua");
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
        public bool upd_xn_phieu_laymau(string v_mmyy, decimal v_id, decimal v_sophieu, string v_mabn, decimal v_maql, decimal v_idkhoa, string v_ngay16, string v_makp, string v_mabs, decimal v_loaibn, decimal v_tinhtrang, decimal v_loai, string v_maicd, decimal v_madoituong, string v_ktv, string v_ngayra16, string v_mabsdoc, string v_ghichu, string v_nhanxet, string v_ketluan, string v_denghi, string v_mabenhpham, decimal v_userid, string v_stt,string v_ngayud, string v_ngay_laymau16,string v_chandoan,decimal v_idchinhanh)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".xn_phieu set sophieu=:v_sophieu,stt=:v_stt, mabn=:v_mabn,  maql=:v_maql, idkhoa=:v_idkhoa, ngay=to_date(:v_ngay,'dd/mm/yyyy hh24:mi'),makp=:v_makp,mabs=:v_mabs,loaibn=:v_loaibn,tinhtrang=:v_tinhtrang, loai=:v_loai, maicd=:v_maicd,madoituong=:v_madoituong,ktv=:v_ktv, ngayra=to_date(:v_ngayra,'dd/mm/yyyy hh24:mi'), mabsdoc=:v_mabsdoc, ghichu=:v_ghichu, nhanxet=:v_nhanxet, ketluan=:v_ketluan, denghi=:v_denghi,mabenhpham=:v_mabenhpham,userid=:v_userid,ngayud=to_date(:v_ngayud,'dd/mm/yyyy hh24:mi'), ngaylaymau= to_date(:v_ngay_laymau16,'dd/mm/yyyy hh24:mi'),chandoan=:v_chandoan,idchinhanh=:v_idchinhanh where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_sophieu", NpgsqlDbType.Numeric).Value = v_sophieu;
            m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 10).Value = v_mabn;
            m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
            m_command.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
            m_command.Parameters.Add("v_ngay", NpgsqlDbType.Text, 16).Value = v_ngay16;
            m_command.Parameters.Add("v_ngayra", NpgsqlDbType.Text, 16).Value = v_ngayra16;
            m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 2).Value = v_makp;
            m_command.Parameters.Add("v_mabs", NpgsqlDbType.Varchar, 4).Value = v_mabs;
            m_command.Parameters.Add("v_loaibn", NpgsqlDbType.Numeric).Value = v_loaibn;
            m_command.Parameters.Add("v_tinhtrang", NpgsqlDbType.Numeric).Value = v_tinhtrang;
            m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
            m_command.Parameters.Add("v_maicd", NpgsqlDbType.Varchar, 9).Value = v_maicd;
            m_command.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
            m_command.Parameters.Add("v_ktv", NpgsqlDbType.Varchar, 4).Value = v_ktv;
            m_command.Parameters.Add("v_mabsdoc", NpgsqlDbType.Varchar, 4).Value = v_mabsdoc;
            m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;
            m_command.Parameters.Add("v_nhanxet", NpgsqlDbType.Text).Value = v_nhanxet;
            m_command.Parameters.Add("v_ketluan", NpgsqlDbType.Text).Value = v_ketluan;
            m_command.Parameters.Add("v_denghi", NpgsqlDbType.Text).Value = v_denghi;
            m_command.Parameters.Add("v_mabenhpham", NpgsqlDbType.Text).Value = v_mabenhpham;
            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
            m_command.Parameters.Add("v_ngayud", NpgsqlDbType.Text, 16).Value = v_ngayud;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Text).Value = v_stt;
            m_command.Parameters.Add("v_ngay_laymau16", NpgsqlDbType.Text, 16).Value = v_ngay_laymau16;
            m_command.Parameters.Add("v_chandoan", NpgsqlDbType.Text, 256).Value = v_chandoan;
            m_command.Parameters.Add("v_idchinhanh", NpgsqlDbType.Numeric).Value = v_idchinhanh;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".xn_phieu(id,sophieu,mabn,maql,idkhoa,ngay,ngayra,makp,mabs,loaibn,tinhtrang,loai,maicd,madoituong,ktv,mabsdoc,ghichu,nhanxet,ketluan,denghi,mabenhpham,userid,ngayud,stt,ngaylaymau,chandoan,idchinhanh) values(:v_id,:v_sophieu,:v_mabn,:v_maql,:v_idkhoa,to_date(:v_ngay,'dd/mm/yyyy hh24:mi'),to_date(:v_ngayra,'dd/mm/yyyy hh24:mi'),:v_makp,:v_mabs,:v_loaibn,:v_tinhtrang,:v_loai,:v_maicd,:v_madoituong,:v_ktv,:v_mabsdoc,:v_ghichu,:v_nhanxet,:v_ketluan,:v_denghi,:v_mabenhpham,:v_userid,to_date(:v_ngayud,'dd/mm/yyyy hh24:mi'),:v_stt,to_date(:v_ngay_laymau16,'dd/mm/yyyy hh24:mi'),:v_chandoan,:v_idchinhanh)"; 
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_sophieu", NpgsqlDbType.Numeric).Value = v_sophieu;
                    m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 10).Value = v_mabn;
                    m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                    m_command.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
                    m_command.Parameters.Add("v_ngay", NpgsqlDbType.Text, 16).Value = v_ngay16;
                    m_command.Parameters.Add("v_ngayra", NpgsqlDbType.Text, 16).Value = v_ngayra16;
                    m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 2).Value = v_makp;
                    m_command.Parameters.Add("v_mabs", NpgsqlDbType.Varchar, 4).Value = v_mabs;
                    m_command.Parameters.Add("v_loaibn", NpgsqlDbType.Numeric).Value = v_loaibn;
                    m_command.Parameters.Add("v_tinhtrang", NpgsqlDbType.Numeric).Value = v_tinhtrang;
                    m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                    m_command.Parameters.Add("v_maicd", NpgsqlDbType.Varchar, 9).Value = v_maicd;
                    m_command.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
                    m_command.Parameters.Add("v_ktv", NpgsqlDbType.Varchar, 4).Value = v_ktv;
                    m_command.Parameters.Add("v_mabsdoc", NpgsqlDbType.Varchar, 4).Value = v_mabsdoc;
                    m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;
                    m_command.Parameters.Add("v_nhanxet", NpgsqlDbType.Text).Value = v_nhanxet;
                    m_command.Parameters.Add("v_ketluan", NpgsqlDbType.Text).Value = v_ketluan;
                    m_command.Parameters.Add("v_denghi", NpgsqlDbType.Text).Value = v_denghi;
                    m_command.Parameters.Add("v_mabenhpham", NpgsqlDbType.Text).Value = v_mabenhpham;
                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                    m_command.Parameters.Add("v_ngayud", NpgsqlDbType.Text, 16).Value = v_ngayud;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Text).Value = v_stt;
                    m_command.Parameters.Add("v_ngay_laymau16", NpgsqlDbType.Text, 16).Value = v_ngay_laymau16;
                    m_command.Parameters.Add("v_chandoan", NpgsqlDbType.Text, 256).Value = v_chandoan;
                    m_command.Parameters.Add("v_idchinhanh", NpgsqlDbType.Numeric).Value = v_idchinhanh;
                    

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(v_mmyy, ex.Message, m_computername, "xn_phieu");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_phieu_ctc(string v_mmyy, decimal v_id, decimal v_sophieu, string v_mabn, decimal v_maql, decimal v_idkhoa, string v_ngay16, string v_makp, string v_mabs, decimal v_loaibn, decimal v_tinhtrang, decimal v_loai, string v_maicd, decimal v_madoituong, string v_ktv, string v_ngayra16, string v_mabsdoc, string v_ghichu, string v_nhanxet, string v_ketluan, string v_denghi, string v_mabenhpham, decimal v_userid, decimal v_mavp, string v_cd_para, decimal v_cd_vitri1, decimal v_cd_vitri2, decimal v_cd_vitri3, string v_cd_ngaykinh, decimal v_cd_thai, string v_cd_dieutri, string v_cd_lamsang, string v_cd_soi, string v_cd_gpb, string v_cd_tebao1, string v_cd_tebao2, string v_cd_tebao3, string v_cd_ngaygui, string v_cd_ngaynhan, string v_cd_mabs, decimal v_kq_danhgia, string v_kq_lydo, decimal v_kq_diengiai, string v_kq_diengiai1, decimal v_kq_nt1, decimal v_kq_nt2, decimal v_kq_nt3, decimal v_kq_nt4, decimal v_kq_nt5, decimal v_kq_nt6, decimal v_kq_pu1, decimal v_kq_pu2, decimal v_kq_pu3, decimal v_kq_pu4, decimal v_kq_pu5, decimal v_kq_tbg1, decimal v_kq_tbg2, decimal v_kq_tbg3, decimal v_kq_tbg4, decimal v_kq_tbg5, decimal v_kq_tbg6, decimal v_kq_tbt1, decimal v_kq_tbt2, decimal v_kq_tbt3, decimal v_kq_tbt4, decimal v_kq_tbt5)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".xn_phieu_ctc set sophieu=:v_sophieu, mabn=:v_mabn,  maql=:v_maql, idkhoa=:v_idkhoa, ngay=to_date(:v_ngay,'dd/mm/yyyy hh24:mi'),makp=:v_makp,mabs=:v_mabs,loaibn=:v_loaibn,tinhtrang=:v_tinhtrang, loai=:v_loai, maicd=:v_maicd,madoituong=:v_madoituong,ktv=:v_ktv, ngayra=to_date(:v_ngayra,'dd/mm/yyyy hh24:mi'), mabsdoc=:v_mabsdoc, ghichu=:v_ghichu, nhanxet=:v_nhanxet, ketluan=:v_ketluan, denghi=:v_denghi,mabenhpham=:v_mabenhpham,userid=:v_userid,mavp=:v_mavp, cd_para=:v_cd_para, cd_vitri1=:v_cd_vitri1, cd_vitri2=:v_cd_vitri2, cd_vitri3=:v_cd_vitri3, cd_ngaykinh=:v_cd_ngaykinh, cd_thai=:v_cd_thai, cd_dieutri=:v_cd_dieutri, cd_lamsang=:v_cd_lamsang, cd_soi=:v_cd_soi, cd_gpb=:v_cd_gpb, cd_tebao1=:v_cd_tebao1, cd_tebao2=:v_cd_tebao2, cd_tebao3=:v_cd_tebao3, cd_ngaygui=:v_cd_ngaygui,cd_ngaynhan=:v_cd_ngaynhan, cd_mabs=:v_cd_mabs, kq_danhgia=:v_kq_danhgia, kq_lydo=:v_kq_lydo, kq_diengiai=:v_kq_diengiai, kq_diengiai1=:v_kq_diengiai1, kq_nt1=:v_kq_nt1, kq_nt2=:v_kq_nt2, kq_nt3=:v_kq_nt3, kq_nt4=:v_kq_nt4, kq_nt5=:v_kq_nt5, kq_nt6=:v_kq_nt6, kq_pu1=:v_kq_pu1, kq_pu2=:v_kq_pu2, kq_pu3=:v_kq_pu3, kq_pu4=:v_kq_pu4, kq_pu5=:v_kq_pu5, kq_tbg1=:v_kq_tbg1, kq_tbg2=:v_kq_tbg2, kq_tbg3=:v_kq_tbg3, kq_tbg4=:v_kq_tbg4, kq_tbg5=:v_kq_tbg5, kq_tbg6=:v_kq_tbg6, kq_tbt1=:v_kq_tbt1, kq_tbt2=:v_kq_tbt2, kq_tbt3=:v_kq_tbt3, kq_tbt4=:v_kq_tbt4, kq_tbt5=:v_kq_tbt5 where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_sophieu", NpgsqlDbType.Numeric).Value = v_sophieu;
            m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 10).Value = v_mabn;
            m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
            m_command.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
            m_command.Parameters.Add("v_ngay", NpgsqlDbType.Text, 16).Value = v_ngay16;
            m_command.Parameters.Add("v_ngayra", NpgsqlDbType.Text, 16).Value = v_ngayra16;
            m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 2).Value = v_makp;
            m_command.Parameters.Add("v_mabs", NpgsqlDbType.Varchar, 4).Value = v_mabs;
            m_command.Parameters.Add("v_loaibn", NpgsqlDbType.Numeric).Value = v_loaibn;
            m_command.Parameters.Add("v_tinhtrang", NpgsqlDbType.Numeric).Value = v_tinhtrang;
            m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
            m_command.Parameters.Add("v_maicd", NpgsqlDbType.Varchar, 9).Value = v_maicd;
            m_command.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
            m_command.Parameters.Add("v_ktv", NpgsqlDbType.Varchar, 4).Value = v_ktv;
            m_command.Parameters.Add("v_mabsdoc", NpgsqlDbType.Varchar, 4).Value = v_mabsdoc;
            m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;
            m_command.Parameters.Add("v_nhanxet", NpgsqlDbType.Text).Value = v_nhanxet;
            m_command.Parameters.Add("v_ketluan", NpgsqlDbType.Text).Value = v_ketluan;
            m_command.Parameters.Add("v_denghi", NpgsqlDbType.Text).Value = v_denghi;
            m_command.Parameters.Add("v_mabenhpham", NpgsqlDbType.Text).Value = v_mabenhpham;
            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;

            m_command.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
            m_command.Parameters.Add("v_cd_para", NpgsqlDbType.Text).Value = v_cd_para;
            m_command.Parameters.Add("v_cd_vitri1", NpgsqlDbType.Numeric).Value = v_cd_vitri1;
            m_command.Parameters.Add("v_cd_vitri2", NpgsqlDbType.Numeric).Value = v_cd_vitri2;
            m_command.Parameters.Add("v_cd_vitri3", NpgsqlDbType.Numeric).Value = v_cd_vitri3;
            m_command.Parameters.Add("v_cd_ngaykinh", NpgsqlDbType.Text).Value = v_cd_ngaykinh;
            m_command.Parameters.Add("v_cd_thai", NpgsqlDbType.Numeric).Value = v_cd_thai;
            m_command.Parameters.Add("v_cd_dieutri", NpgsqlDbType.Text).Value = v_cd_dieutri;
            m_command.Parameters.Add("v_cd_lamsang", NpgsqlDbType.Text).Value = v_cd_lamsang;
            m_command.Parameters.Add("v_cd_soi", NpgsqlDbType.Text).Value = v_cd_soi;
            m_command.Parameters.Add("v_cd_gpb", NpgsqlDbType.Text).Value = v_cd_gpb;
            m_command.Parameters.Add("v_cd_tebao1", NpgsqlDbType.Text).Value = v_cd_tebao1;
            m_command.Parameters.Add("v_cd_tebao2", NpgsqlDbType.Text).Value = v_cd_tebao2;
            m_command.Parameters.Add("v_cd_tebao3", NpgsqlDbType.Text).Value = v_cd_tebao3;
            m_command.Parameters.Add("v_cd_ngaygui", NpgsqlDbType.Text).Value = v_cd_ngaygui;
            m_command.Parameters.Add("v_cd_ngaynhan", NpgsqlDbType.Text).Value = v_cd_ngaynhan;
            m_command.Parameters.Add("v_cd_mabs", NpgsqlDbType.Text).Value = v_cd_mabs;
            m_command.Parameters.Add("v_kq_danhgia", NpgsqlDbType.Numeric).Value = v_kq_danhgia;
            m_command.Parameters.Add("v_kq_lydo", NpgsqlDbType.Text).Value = v_kq_lydo;
            m_command.Parameters.Add("v_kq_diengiai", NpgsqlDbType.Numeric).Value = v_kq_diengiai;
            m_command.Parameters.Add("v_kq_diengiai1", NpgsqlDbType.Text).Value = v_kq_diengiai1;
            m_command.Parameters.Add("v_kq_nt1", NpgsqlDbType.Numeric).Value = v_kq_nt1;
            m_command.Parameters.Add("v_kq_nt2", NpgsqlDbType.Numeric).Value = v_kq_nt2;
            m_command.Parameters.Add("v_kq_nt3", NpgsqlDbType.Numeric).Value = v_kq_nt3;
            m_command.Parameters.Add("v_kq_nt4", NpgsqlDbType.Numeric).Value = v_kq_nt4;
            m_command.Parameters.Add("v_kq_nt5", NpgsqlDbType.Numeric).Value = v_kq_nt5;
            m_command.Parameters.Add("v_kq_nt6", NpgsqlDbType.Numeric).Value = v_kq_nt6;
            m_command.Parameters.Add("v_kq_pu1", NpgsqlDbType.Numeric).Value = v_kq_pu1;
            m_command.Parameters.Add("v_kq_pu2", NpgsqlDbType.Numeric).Value = v_kq_pu2;
            m_command.Parameters.Add("v_kq_pu3", NpgsqlDbType.Numeric).Value = v_kq_pu3;
            m_command.Parameters.Add("v_kq_pu4", NpgsqlDbType.Numeric).Value = v_kq_pu4;
            m_command.Parameters.Add("v_kq_pu5", NpgsqlDbType.Numeric).Value = v_kq_pu5;
            m_command.Parameters.Add("v_kq_tbg1", NpgsqlDbType.Numeric).Value = v_kq_tbg1;
            m_command.Parameters.Add("v_kq_tbg2", NpgsqlDbType.Numeric).Value = v_kq_tbg2;
            m_command.Parameters.Add("v_kq_tbg3", NpgsqlDbType.Numeric).Value = v_kq_tbg3;
            m_command.Parameters.Add("v_kq_tbg4", NpgsqlDbType.Numeric).Value = v_kq_tbg4;
            m_command.Parameters.Add("v_kq_tbg5", NpgsqlDbType.Numeric).Value = v_kq_tbg5;
            m_command.Parameters.Add("v_kq_tbg6", NpgsqlDbType.Numeric).Value = v_kq_tbg6;
            m_command.Parameters.Add("v_kq_tbt1", NpgsqlDbType.Numeric).Value = v_kq_tbt1;
            m_command.Parameters.Add("v_kq_tbt2", NpgsqlDbType.Numeric).Value = v_kq_tbt2;
            m_command.Parameters.Add("v_kq_tbt3", NpgsqlDbType.Numeric).Value = v_kq_tbt3;
            m_command.Parameters.Add("v_kq_tbt4", NpgsqlDbType.Numeric).Value = v_kq_tbt4;
            m_command.Parameters.Add("v_kq_tbt5", NpgsqlDbType.Numeric).Value = v_kq_tbt5;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".xn_phieu_ctc(id,sophieu,mabn,maql,idkhoa,ngay,ngayra,makp,mabs,loaibn,tinhtrang,loai,maicd,madoituong,ktv,mabsdoc,ghichu,nhanxet,ketluan,denghi,mabenhpham,userid,mavp,cd_para, cd_vitri1, cd_vitri2, cd_vitri3, cd_ngaykinh, cd_thai, cd_dieutri, cd_lamsang, cd_soi, cd_gpb, cd_tebao1, cd_tebao2, cd_tebao3, cd_ngaygui, cd_ngaynhan, cd_mabs, kq_danhgia, kq_lydo, kq_diengiai, kq_diengiai1, kq_nt1, kq_nt2, kq_nt3, kq_nt4, kq_nt5, kq_nt6, kq_pu1, kq_pu2, kq_pu3, kq_pu4, kq_pu5, kq_tbg1, kq_tbg2, kq_tbg3, kq_tbg4, kq_tbg5, kq_tbg6, kq_tbt1, kq_tbt2, kq_tbt3, kq_tbt4, kq_tbt5) values(:v_id,:v_sophieu,:v_mabn,:v_maql,:v_idkhoa,to_date(:v_ngay,'dd/mm/yyyy hh24:mi'),to_date(:v_ngayra,'dd/mm/yyyy hh24:mi'),:v_makp,:v_mabs,:v_loaibn,:v_tinhtrang,:v_loai,:v_maicd,:v_madoituong,:v_ktv,:v_mabsdoc,:v_ghichu,:v_nhanxet,:v_ketluan,:v_denghi,:v_mabenhpham,:v_userid,:v_mavp,:v_cd_para,:v_cd_vitri1,:v_cd_vitri2,:v_cd_vitri3,:v_cd_ngaykinh,:v_cd_thai,:v_cd_dieutri,:v_cd_lamsang,:v_cd_soi,:v_cd_gpb,:v_cd_tebao1,:v_cd_tebao2,:v_cd_tebao3,:v_cd_ngaygui,:v_cd_ngaynhan,:v_cd_mabs,:v_kq_danhgia,:v_kq_lydo,:v_kq_diengiai,:v_kq_diengiai1,:v_kq_nt1,:v_kq_nt2,:v_kq_nt3,:v_kq_nt4,:v_kq_nt5,:v_kq_nt6,:v_kq_pu1,:v_kq_pu2,:v_kq_pu3,:v_kq_pu4,:v_kq_pu5,:v_kq_tbg1,:v_kq_tbg2,:v_kq_tbg3,:v_kq_tbg4,:v_kq_tbg5,:v_kq_tbg6,:v_kq_tbt1,:v_kq_tbt2,:v_kq_tbt3,:v_kq_tbt4,:v_kq_tbt5)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_sophieu", NpgsqlDbType.Numeric).Value = v_sophieu;
                    m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 10).Value = v_mabn;
                    m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                    m_command.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
                    m_command.Parameters.Add("v_ngay", NpgsqlDbType.Text, 16).Value = v_ngay16;
                    m_command.Parameters.Add("v_ngayra", NpgsqlDbType.Text, 16).Value = v_ngayra16;
                    m_command.Parameters.Add("v_makp", NpgsqlDbType.Varchar, 2).Value = v_makp;
                    m_command.Parameters.Add("v_mabs", NpgsqlDbType.Varchar, 4).Value = v_mabs;
                    m_command.Parameters.Add("v_loaibn", NpgsqlDbType.Numeric).Value = v_loaibn;
                    m_command.Parameters.Add("v_tinhtrang", NpgsqlDbType.Numeric).Value = v_tinhtrang;
                    m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                    m_command.Parameters.Add("v_maicd", NpgsqlDbType.Varchar, 9).Value = v_maicd;
                    m_command.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
                    m_command.Parameters.Add("v_ktv", NpgsqlDbType.Varchar, 4).Value = v_ktv;
                    m_command.Parameters.Add("v_mabsdoc", NpgsqlDbType.Varchar, 4).Value = v_mabsdoc;
                    m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;
                    m_command.Parameters.Add("v_nhanxet", NpgsqlDbType.Text).Value = v_nhanxet;
                    m_command.Parameters.Add("v_ketluan", NpgsqlDbType.Text).Value = v_ketluan;
                    m_command.Parameters.Add("v_denghi", NpgsqlDbType.Text).Value = v_denghi;
                    m_command.Parameters.Add("v_mabenhpham", NpgsqlDbType.Text).Value = v_mabenhpham;
                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;

                    m_command.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
                    m_command.Parameters.Add("v_cd_para", NpgsqlDbType.Text).Value = v_cd_para;
                    m_command.Parameters.Add("v_cd_vitri1", NpgsqlDbType.Numeric).Value = v_cd_vitri1;
                    m_command.Parameters.Add("v_cd_vitri2", NpgsqlDbType.Numeric).Value = v_cd_vitri2;
                    m_command.Parameters.Add("v_cd_vitri3", NpgsqlDbType.Numeric).Value = v_cd_vitri3;
                    m_command.Parameters.Add("v_cd_ngaykinh", NpgsqlDbType.Text).Value = v_cd_ngaykinh;
                    m_command.Parameters.Add("v_cd_thai", NpgsqlDbType.Numeric).Value = v_cd_thai;
                    m_command.Parameters.Add("v_cd_dieutri", NpgsqlDbType.Text).Value = v_cd_dieutri;
                    m_command.Parameters.Add("v_cd_lamsang", NpgsqlDbType.Text).Value = v_cd_lamsang;
                    m_command.Parameters.Add("v_cd_soi", NpgsqlDbType.Text).Value = v_cd_soi;
                    m_command.Parameters.Add("v_cd_gpb", NpgsqlDbType.Text).Value = v_cd_gpb;
                    m_command.Parameters.Add("v_cd_tebao1", NpgsqlDbType.Text).Value = v_cd_tebao1;
                    m_command.Parameters.Add("v_cd_tebao2", NpgsqlDbType.Text).Value = v_cd_tebao2;
                    m_command.Parameters.Add("v_cd_tebao3", NpgsqlDbType.Text).Value = v_cd_tebao3;
                    m_command.Parameters.Add("v_cd_ngaygui", NpgsqlDbType.Text).Value = v_cd_ngaygui;
                    m_command.Parameters.Add("v_cd_ngaynhan", NpgsqlDbType.Text).Value = v_cd_ngaynhan;
                    m_command.Parameters.Add("v_cd_mabs", NpgsqlDbType.Text).Value = v_cd_mabs;
                    m_command.Parameters.Add("v_kq_danhgia", NpgsqlDbType.Numeric).Value = v_kq_danhgia;
                    m_command.Parameters.Add("v_kq_lydo", NpgsqlDbType.Text).Value = v_kq_lydo;
                    m_command.Parameters.Add("v_kq_diengiai", NpgsqlDbType.Numeric).Value = v_kq_diengiai;
                    m_command.Parameters.Add("v_kq_diengiai1", NpgsqlDbType.Text).Value = v_kq_diengiai1;
                    m_command.Parameters.Add("v_kq_nt1", NpgsqlDbType.Numeric).Value = v_kq_nt1;
                    m_command.Parameters.Add("v_kq_nt2", NpgsqlDbType.Numeric).Value = v_kq_nt2;
                    m_command.Parameters.Add("v_kq_nt3", NpgsqlDbType.Numeric).Value = v_kq_nt3;
                    m_command.Parameters.Add("v_kq_nt4", NpgsqlDbType.Numeric).Value = v_kq_nt4;
                    m_command.Parameters.Add("v_kq_nt5", NpgsqlDbType.Numeric).Value = v_kq_nt5;
                    m_command.Parameters.Add("v_kq_nt6", NpgsqlDbType.Numeric).Value = v_kq_nt6;
                    m_command.Parameters.Add("v_kq_pu1", NpgsqlDbType.Numeric).Value = v_kq_pu1;
                    m_command.Parameters.Add("v_kq_pu2", NpgsqlDbType.Numeric).Value = v_kq_pu2;
                    m_command.Parameters.Add("v_kq_pu3", NpgsqlDbType.Numeric).Value = v_kq_pu3;
                    m_command.Parameters.Add("v_kq_pu4", NpgsqlDbType.Numeric).Value = v_kq_pu4;
                    m_command.Parameters.Add("v_kq_pu5", NpgsqlDbType.Numeric).Value = v_kq_pu5;
                    m_command.Parameters.Add("v_kq_tbg1", NpgsqlDbType.Numeric).Value = v_kq_tbg1;
                    m_command.Parameters.Add("v_kq_tbg2", NpgsqlDbType.Numeric).Value = v_kq_tbg2;
                    m_command.Parameters.Add("v_kq_tbg3", NpgsqlDbType.Numeric).Value = v_kq_tbg3;
                    m_command.Parameters.Add("v_kq_tbg4", NpgsqlDbType.Numeric).Value = v_kq_tbg4;
                    m_command.Parameters.Add("v_kq_tbg5", NpgsqlDbType.Numeric).Value = v_kq_tbg5;
                    m_command.Parameters.Add("v_kq_tbg6", NpgsqlDbType.Numeric).Value = v_kq_tbg6;
                    m_command.Parameters.Add("v_kq_tbt1", NpgsqlDbType.Numeric).Value = v_kq_tbt1;
                    m_command.Parameters.Add("v_kq_tbt2", NpgsqlDbType.Numeric).Value = v_kq_tbt2;
                    m_command.Parameters.Add("v_kq_tbt3", NpgsqlDbType.Numeric).Value = v_kq_tbt3;
                    m_command.Parameters.Add("v_kq_tbt4", NpgsqlDbType.Numeric).Value = v_kq_tbt4;
                    m_command.Parameters.Add("v_kq_tbt5", NpgsqlDbType.Numeric).Value = v_kq_tbt5;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(v_mmyy, ex.Message, m_computername, "xn_phieu_ctc");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_ketqua_may(string v_mmyy, decimal v_id, decimal v_id_ten, decimal v_idvienphi, decimal v_idduoc, string v_ketqua, string v_ghichu, decimal v_done, decimal v_idmay, string v_ketqua_save)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".xn_ketqua set idvienphi=:v_idvienphi, idduoc=:v_idduoc, ketqua=:v_ketqua, ghichu=:v_ghichu, done=:v_done,id_may=:v_idmay,ketqua_ori=:v_ketqua_save where id=" + v_id + " and id_ten=" + v_id_ten;
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_idvienphi", NpgsqlDbType.Numeric).Value = v_idvienphi;
            m_command.Parameters.Add("v_idduoc", NpgsqlDbType.Double).Value = v_idduoc;
            m_command.Parameters.Add("v_ketqua", NpgsqlDbType.Varchar, 50).Value = v_ketqua;
            m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Varchar, 50).Value = v_ghichu;
            m_command.Parameters.Add("v_done", NpgsqlDbType.Double).Value = v_done;
            m_command.Parameters.Add("v_idmay", NpgsqlDbType.Double).Value = v_idmay;
            m_command.Parameters.Add("v_ketqua_save", NpgsqlDbType.Varchar, 50).Value = v_ketqua_save;
            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".xn_ketqua(id,id_ten,idvienphi,idduoc,ketqua,ghichu,done) values(:v_id,:v_id_ten,:v_idvienphi,:v_idduoc,:v_ketqua,:v_ghichu,:v_done)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Double).Value = v_id;
                    m_command.Parameters.Add("v_id_ten", NpgsqlDbType.Double).Value = v_id_ten;
                    m_command.Parameters.Add("v_idvienphi", NpgsqlDbType.Double).Value = v_idvienphi;
                    m_command.Parameters.Add("v_idduoc", NpgsqlDbType.Double).Value = v_idduoc;
                    m_command.Parameters.Add("v_ketqua", NpgsqlDbType.Varchar, 50).Value = v_ketqua;
                    m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Varchar, 50).Value = v_ghichu;
                    m_command.Parameters.Add("v_done", NpgsqlDbType.Double).Value = v_done;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(v_mmyy, ex.Message, m_computername, "xn_ketqua");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_ketqua(string v_mmyy, decimal v_id, decimal v_id_ten, decimal v_idvienphi, decimal v_idduoc, string v_ketqua, string v_ghichu, decimal v_done, decimal v_idmay, int v_hople, int v_userd, string v_ketqua_ori)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".xn_ketqua set idvienphi=:v_idvienphi, idduoc=:v_idduoc, ketqua=:v_ketqua, ghichu=:v_ghichu, done=:v_done,id_may=:v_idmay,ketqua_hople=:v_hople,userd=:v_userd,ketqua_ori=:v_ketqua_ori where id=:v_id and id_ten=:v_id_ten";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_id_ten", NpgsqlDbType.Numeric).Value = v_id_ten;
            m_command.Parameters.Add("v_idvienphi", NpgsqlDbType.Numeric).Value = v_idvienphi;
            m_command.Parameters.Add("v_idduoc", NpgsqlDbType.Numeric).Value = v_idduoc;
            m_command.Parameters.Add("v_ketqua", NpgsqlDbType.Text, 50).Value = v_ketqua;
            m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text, 50).Value = v_ghichu;
            m_command.Parameters.Add("v_done", NpgsqlDbType.Numeric).Value = v_done;
            m_command.Parameters.Add("v_idmay", NpgsqlDbType.Numeric).Value = v_idmay;
            m_command.Parameters.Add("v_hople", NpgsqlDbType.Numeric).Value = v_hople;
            m_command.Parameters.Add("v_userd", NpgsqlDbType.Numeric).Value = v_userd;
            m_command.Parameters.Add("v_ketqua_ori", NpgsqlDbType.Text, 50).Value = v_ketqua_ori;
            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".xn_ketqua(id,id_ten,idvienphi,idduoc,ketqua,ghichu,done) values(:v_id,:v_id_ten,:v_idvienphi,:v_idduoc,:v_ketqua,:v_ghichu,:v_done)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_id_ten", NpgsqlDbType.Numeric).Value = v_id_ten;
                    m_command.Parameters.Add("v_idvienphi", NpgsqlDbType.Numeric).Value = v_idvienphi;
                    m_command.Parameters.Add("v_idduoc", NpgsqlDbType.Numeric).Value = v_idduoc;
                    m_command.Parameters.Add("v_ketqua", NpgsqlDbType.Text, 50).Value = v_ketqua;
                    m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Text, 50).Value = v_ghichu;
                    m_command.Parameters.Add("v_done", NpgsqlDbType.Numeric).Value = v_done;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(v_mmyy, ex.Message, m_computername, "xn_ketqua");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_ketqua_laymau(string v_mmyy, decimal v_id, decimal v_id_ten, decimal v_idvienphi, decimal v_idduoc, decimal v_done,string v_ketqua)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".xn_ketqua set idvienphi=:v_idvienphi, idduoc=:v_idduoc, done=:v_done,ketqua=:v_ketqua where id=:v_id and id_ten=:v_id_ten";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_id_ten", NpgsqlDbType.Numeric).Value = v_id_ten;
            m_command.Parameters.Add("v_idvienphi", NpgsqlDbType.Numeric).Value = v_idvienphi;
            m_command.Parameters.Add("v_idduoc", NpgsqlDbType.Numeric).Value = v_idduoc;
            m_command.Parameters.Add("v_done", NpgsqlDbType.Numeric).Value = v_done;
            m_command.Parameters.Add("v_ketqua", NpgsqlDbType.Varchar,200).Value = v_ketqua;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".xn_ketqua(id,id_ten,idvienphi,idduoc,ketqua,ghichu,done) values(:v_id,:v_id_ten,:v_idvienphi,:v_idduoc,:v_ketqua,'',:v_done)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_id_ten", NpgsqlDbType.Numeric).Value = v_id_ten;
                    m_command.Parameters.Add("v_idvienphi", NpgsqlDbType.Numeric).Value = v_idvienphi;
                    m_command.Parameters.Add("v_ketqua", NpgsqlDbType.Varchar, 200).Value = v_ketqua;
                    m_command.Parameters.Add("v_idduoc", NpgsqlDbType.Numeric).Value = v_idduoc;
                    m_command.Parameters.Add("v_done", NpgsqlDbType.Numeric).Value = v_done;
                    

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(v_mmyy, ex.Message, m_computername, "xn_ketqua");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_ksd(string v_mmyy, decimal v_id, decimal v_id_phieu, decimal v_id_bv_vitrung,decimal v_id_mauthu, string v_maso_mt,string v_gram, string v_ketqua,decimal v_mavp)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".xn_ksd set id_phieu=:v_id_phieu, id_bv_vitrung=:v_id_bv_vitrung, id_mauthu=:v_id_mauthu, maso_mt=:v_maso_mt, gram=:v_gram, ketqua=:v_ketqua,mavp=:v_mavp where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_id_phieu", NpgsqlDbType.Numeric).Value = v_id_phieu;
            m_command.Parameters.Add("v_id_bv_vitrung", NpgsqlDbType.Numeric).Value = v_id_bv_vitrung;
            m_command.Parameters.Add("v_id_mauthu", NpgsqlDbType.Numeric).Value = v_id_mauthu;
            m_command.Parameters.Add("v_maso_mt", NpgsqlDbType.Varchar, 10).Value = v_maso_mt;
            m_command.Parameters.Add("v_gram", NpgsqlDbType.Varchar, 1).Value = v_gram.Trim();
            m_command.Parameters.Add("v_ketqua", NpgsqlDbType.Text).Value = v_ketqua;
            m_command.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".xn_ksd(id,id_phieu,id_bv_vitrung,id_mauthu,maso_mt,gram,ketqua,mavp) values(:v_id,:v_id_phieu,:v_id_bv_vitrung,:v_id_mauthu,:v_maso_mt,:v_gram,:v_ketqua,:v_mavp)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_id_phieu", NpgsqlDbType.Numeric).Value = v_id_phieu;
                    m_command.Parameters.Add("v_id_bv_vitrung", NpgsqlDbType.Numeric).Value = v_id_bv_vitrung;
                    m_command.Parameters.Add("v_id_mauthu", NpgsqlDbType.Numeric).Value = v_id_mauthu;
                    m_command.Parameters.Add("v_maso_mt", NpgsqlDbType.Varchar, 10).Value = v_maso_mt;
                    m_command.Parameters.Add("v_gram", NpgsqlDbType.Varchar, 1).Value = v_gram.Trim();
                    m_command.Parameters.Add("v_ketqua", NpgsqlDbType.Text).Value = v_ketqua;
                    m_command.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(v_mmyy, ex.Message, m_computername, "xn_ksd");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_ketqua_ksd(string v_mmyy, decimal v_id, decimal v_id_ksd, decimal v_id_khangsinh, decimal v_bankinh, string v_sir, decimal v_maxr, decimal v_mins)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".xn_ketqua_ksd set id_ksd=:v_id_ksd, id_khangsinh=:v_id_khangsinh, bankinh=:v_bankinh, sir=:v_sir, maxr=:v_maxr, mins=:v_mins where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_id_ksd", NpgsqlDbType.Numeric).Value = v_id_ksd;
            m_command.Parameters.Add("v_id_khangsinh", NpgsqlDbType.Numeric).Value = v_id_khangsinh;
            m_command.Parameters.Add("v_bankinh", NpgsqlDbType.Numeric).Value = v_bankinh;
            m_command.Parameters.Add("v_sir", NpgsqlDbType.Varchar, 1).Value = v_sir;
            m_command.Parameters.Add("v_maxr", NpgsqlDbType.Numeric).Value = v_maxr;
            m_command.Parameters.Add("v_mins", NpgsqlDbType.Numeric).Value = v_mins;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".xn_ketqua_ksd(id,id_ksd,id_khangsinh,bankinh,sir,maxr,mins) values(:v_id,:v_id_ksd,:v_id_khangsinh,:v_bankinh,:v_sir,:v_maxr,:v_mins)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_id_ksd", NpgsqlDbType.Numeric).Value = v_id_ksd;
                    m_command.Parameters.Add("v_id_khangsinh", NpgsqlDbType.Numeric).Value = v_id_khangsinh;
                    m_command.Parameters.Add("v_bankinh", NpgsqlDbType.Numeric).Value = v_bankinh;
                    m_command.Parameters.Add("v_sir", NpgsqlDbType.Varchar, 1).Value = v_sir;
                    m_command.Parameters.Add("v_maxr", NpgsqlDbType.Numeric).Value = v_maxr;
                    m_command.Parameters.Add("v_mins", NpgsqlDbType.Numeric).Value = v_mins;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(v_mmyy, ex.Message, m_computername, "xn_ketqua_ksd");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_nhuomgram(string v_mmyy, decimal v_id, decimal v_id_phieu, decimal v_id_mauthu, string v_gram)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".xn_vitrung set stt=:v_stt, ma=:v_ma, ten=:v_ten, gram=:v_gram, status=:v_status where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_id_phieu", NpgsqlDbType.Numeric).Value = v_id_phieu;
            m_command.Parameters.Add("v_id_mauthu", NpgsqlDbType.Numeric).Value = v_id_mauthu;
            m_command.Parameters.Add("v_gram", NpgsqlDbType.Text, 10).Value = v_gram;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".xn_vitrung(id,stt,ma,ten,gram,status) values(:v_id,:v_stt,:v_ma,:v_ten,:v_gram,:v_status)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_id_phieu", NpgsqlDbType.Numeric).Value = v_id_phieu;
                    m_command.Parameters.Add("v_id_mauthu", NpgsqlDbType.Numeric).Value = v_id_mauthu;
                    m_command.Parameters.Add("v_gram", NpgsqlDbType.Text, 10).Value = v_gram;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(v_mmyy, ex.Message, m_computername, "xn_nhuomgram");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_hoachatbn(string v_mmyy, decimal v_id, decimal v_id_phieu, string v_mabn, decimal v_maql, decimal v_id_bv_chitiet, decimal v_mahc, decimal v_soluong, decimal v_soluongqd)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".xn_hoachatbn set id_phieu=:v_id_phieu, mabn=:v_mabn,maql=:v_maql,id_bv_chitiet=:v_id_bv_chitiet, mahc=:v_mahc,soluong=:v_soluong,soluongqd=:v_soluongqd where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_id_phieu", NpgsqlDbType.Numeric).Value = v_id_phieu;
            m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 10).Value = v_mabn;
            m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
            m_command.Parameters.Add("v_id_bv_chitiet", NpgsqlDbType.Numeric).Value = v_id_bv_chitiet;
            m_command.Parameters.Add("v_mahc", NpgsqlDbType.Numeric).Value = v_mahc;
            m_command.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
            m_command.Parameters.Add("v_soluongqd", NpgsqlDbType.Numeric).Value = v_soluongqd;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".xn_hoachatbn(id,id_phieu,mabn,maql,id_bv_chitiet,mahc,soluong,soluongqd) values(:v_id,:v_id_phieu,:v_mabn,:v_maql,:v_id_bv_chitiet,:v_mahc,:v_soluong,:v_soluongqd)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_id_phieu", NpgsqlDbType.Numeric).Value = v_id_phieu;
                    m_command.Parameters.Add("v_mabn", NpgsqlDbType.Varchar, 10).Value = v_mabn;
                    m_command.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                    m_command.Parameters.Add("v_id_bv_chitiet", NpgsqlDbType.Numeric).Value = v_id_bv_chitiet;
                    m_command.Parameters.Add("v_mahc", NpgsqlDbType.Numeric).Value = v_mahc;
                    m_command.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
                    m_command.Parameters.Add("v_soluongqd", NpgsqlDbType.Numeric).Value = v_soluongqd;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(v_mmyy, ex.Message, m_computername, "xn_hoachatbn");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }

        public bool upd_xn_optionform(decimal v_userid, decimal v_loai, string v_ma, string v_ten, string v_giatri)
        {
            bool art = false;
            m_sql = "update " + s_schemaroot + ".xn_optionform set ten=:v_ten,giatri=:v_giatri where userid=:v_userid and loai=:v_loai and ma=:v_ma";
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
                    m_sql = "insert into " + s_schemaroot + ".xn_optionform(userid,loai,ma,ten,giatri) values(:v_userid,:v_loai,:v_ma,:v_ten,:v_giatri)";
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
                upd_xn_error(ex.Message, m_computername, "xn_optionform");
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return art;
        }
        public string get_xn_optionform(int v_loai, string v_userid, string v_ma)
        {
            try
            {
                return get_data("select giatri from medibv.xn_optionform where userid=" + v_userid + " and loai=" + v_loai.ToString() + " and ma='" + v_ma + "'").Tables[0].Rows[0][0].ToString().Trim();
            }
            catch
            {
                return "";
            }
        }
        public void set_xn_optionform(int v_loai, string v_userid, string v_ma, bool v_val)
        {
            try
            {
                upd_xn_optionform(decimal.Parse(v_userid), decimal.Parse(v_loai.ToString()), v_ma, "", v_val ? "1" : "0");
            }
            catch
            {
            }
        }
        public string s_loaiform_phieulaymau
        {
            get
            {
                return "1";
            }
        }
        public string s_loaiform_phieuxetnghiem_dg
        {
            get
            {
                return "2";
            }
        }
        public string s_loaiform_duyetlaymau
        {
            get
            {
                return "3";
            }
        }
        public int f_get_sott_Laymau(string ngay)
        {
            try
            {
                int astt = 0;
                try
                {
                    //astt = int.Parse(get_data("select stt from " + s_schemaroot + ngay.Substring(3, 2) + ngay.Substring(8, 2) + ".xn_phieu where to_char(ngaylaymau,'dd/mm/yyyy')='" + ngay.Substring(0, 10) + "' and stt is not null and stt<>'' order by ngaylaymau desc limit 1").Tables[0].Rows[0][0].ToString().Trim()) + 1;
                    astt = int.Parse(get_data("select stt from " + s_schemaroot + ngay.Substring(3, 2) + ngay.Substring(8, 2) + ".xn_phieu where to_char(ngaylaymau,'dd/mm/yyyy')='" + ngay.Substring(0, 10) + "' and stt is not null and stt<>'' order by to_number(stt) desc limit 2").Tables[0].Rows[0][0].ToString().Trim()) + 1;
                }
                catch
                {
                    astt = 0;
                }
                if (astt <= 0)
                {
                    try
                    {
                        astt = int.Parse(get_data("select max(to_number(stt)) as stt from " + s_schemaroot + ngay.Substring(3, 2) + ngay.Substring(8, 2) + ".xn_phieu where to_char(ngaylaymau,'dd/mm/yyyy')='" + ngay.Substring(0, 10) + "' and stt is not null and stt<>''").Tables[0].Rows[0][0].ToString().Trim()) + 1;
                    }
                    catch
                    {
                        astt = 0;
                    }
                }
                if (astt <= 0) astt = 1;
                return astt;
            }
            catch
            {
                return 1;
            }
        }
        public int f_get_sott_Laymau_mmyy(string ngay)
        {
            try
            {
                int astt = 0;
                try
                {
                    //astt = int.Parse(get_data("select stt from " + s_schemaroot + ngay.Substring(3, 2) + ngay.Substring(8, 2) + ".xn_phieu where to_char(ngaylaymau,'dd/mm/yyyy')='" + ngay.Substring(0, 10) + "' and stt is not null and stt<>'' order by ngaylaymau desc limit 1").Tables[0].Rows[0][0].ToString().Trim()) + 1;
                    astt = int.Parse(get_data("select stt from " + s_schemaroot + ngay.Substring(3, 2) + ngay.Substring(8, 2) + ".xn_phieu where stt is not null and stt<>'' order by ngaylaymau desc,to_number(stt) desc limit 2").Tables[0].Rows[0][0].ToString().Trim()) + 1;
                }
                catch
                {
                    astt = 0;
                }
                if (astt <= 0)
                {
                    try
                    {
                        astt = int.Parse(get_data("select max(to_number(stt)) as stt from " + s_schemaroot + ngay.Substring(3, 2) + ngay.Substring(8, 2) + ".xn_phieu where stt is not null and stt<>''").Tables[0].Rows[0][0].ToString().Trim()) + 1;
                    }
                    catch
                    {
                        astt = 0;
                    }
                }
                if (astt <= 0) astt = 1;
                return astt;
            }
            catch
            {
                return 1;
            }
        }
        public bool upd_xn_thongsomay(decimal v_id, decimal v_stt, string v_ma, string v_ten, string v_tyle, decimal v_id_bv_chitiet, string v_id_bv_chitiet1)
        {
            m_sql = "update " + s_schemaroot + ".xn_thongsomay set ma=:v_ma, ten=:v_ten, tyle=:v_tyle, ";
            m_sql += " id_bv_chitiet=:v_id_bv_chitiet,id_bv_chitiet1=:v_id_bv_chitiet1 where id=:v_id and stt=:v_stt";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_ma", NpgsqlDbType.Text).Value = v_ma;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
            m_command.Parameters.Add("v_tyle", NpgsqlDbType.Text).Value = v_tyle;
            m_command.Parameters.Add("v_id_bv_chitiet", NpgsqlDbType.Numeric).Value = v_id_bv_chitiet;
            m_command.Parameters.Add("v_id_bv_chitiet1", NpgsqlDbType.Varchar,200).Value = v_id_bv_chitiet1;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".xn_thongsomay(id,stt,ma,ten,tyle,id_bv_chitiet,id_bv_chitiet1) values(:v_id,:v_stt,:v_ma,:v_ten,:v_tyle,:v_id_bv_chitiet,:v_id_bv_chitiet1)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Text).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_tyle", NpgsqlDbType.Text).Value = v_tyle;
                    m_command.Parameters.Add("v_id_bv_chitiet", NpgsqlDbType.Numeric).Value = v_id_bv_chitiet;
                    m_command.Parameters.Add("v_id_bv_chitiet1", NpgsqlDbType.Varchar, 200).Value = v_id_bv_chitiet1;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_thongsomay");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_may(decimal v_id, decimal v_stt, string v_ma, string v_ten)
        {
            m_sql = "update " + s_schemaroot + ".xn_may set stt=:v_stt, ma=:v_ma, ten=:v_ten where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_ma", NpgsqlDbType.Text).Value = v_ma;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".xn_may(id,stt,ma,ten) values(:v_id,:v_stt,:v_ma,:v_ten)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Text).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_may");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }

        public bool upd_xn_inmavach(string v_ngay10, decimal v_tu, decimal v_den)
        {
            m_sql = "update " + s_schemaroot + ".xn_inmavach set tu=:v_tu, den=:v_den where to_char(ngay,'dd/mm/yyyy')=:v_ngay";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar,10).Value = v_ngay10;
            m_command.Parameters.Add("v_tu", NpgsqlDbType.Numeric).Value = v_tu;
            m_command.Parameters.Add("v_den", NpgsqlDbType.Numeric).Value = v_den;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".xn_inmavach(ngay,tu,den) values(to_date(:v_ngay,'dd/mm/yyyy'),:v_tu,:v_den)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay10;
                    m_command.Parameters.Add("v_tu", NpgsqlDbType.Numeric).Value = v_tu;
                    m_command.Parameters.Add("v_den", NpgsqlDbType.Numeric).Value = v_den;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_inmavach");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_indsguimau(string id,string ten,string v_ngayin)
        {
            m_sql = "update " + s_schemaroot + ".xn_daingui set tenlanin=:ten where ";
            m_sql += " to_char(ngayin,'dd/mm/yyyy')='"+v_ngayin+"' and id=:id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

           
            
            m_command.Parameters.Add("ten", NpgsqlDbType.Varchar, 10).Value = ten;
           // m_command.Parameters.Add("v_ngayin", NpgsqlDbType.Varchar, 10).Value = v_ngayin;
            m_command.Parameters.Add("id", NpgsqlDbType.Numeric).Value = id;
          

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    //m_sql = "insert into " + s_schemaroot + ".xn_indsguimau(ngay,tu,den) values(to_date(:v_ngay,'dd/mm/yyyy'),:v_tu,:v_den)";
                    m_sql = "insert into " + s_schemaroot + ".xn_daingui(id,tenlanin,ngayin) values(:id,:ten,to_date(:v_ngayin,'dd/mm/yyyy')) ";
                    
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("id", NpgsqlDbType.Numeric).Value = id;
                    m_command.Parameters.Add("ten", NpgsqlDbType.Varchar, 10).Value = ten;
                    m_command.Parameters.Add("v_ngayin", NpgsqlDbType.Varchar, 10).Value = v_ngayin;
                    
                    

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_inmavach");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_reportphieu(decimal v_loai, string v_tenfile,string v_ten, decimal v_macdinh)
        {
            m_sql = "update " + s_schemaroot + ".xn_reportphieu set ten=:v_ten, loai=:v_loai,macdinh=:v_macdinh where tenfile=:v_tenfile";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
            m_command.Parameters.Add("v_tenfile", NpgsqlDbType.Text).Value = v_tenfile;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
            m_command.Parameters.Add("v_macdinh", NpgsqlDbType.Numeric).Value = v_macdinh;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".xn_reportphieu(loai,tenfile,ten,macdinh) values(:v_loai,:v_tenfile,:v_ten,:v_macdinh)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                    m_command.Parameters.Add("v_tenfile", NpgsqlDbType.Text).Value = v_tenfile;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    m_command.Parameters.Add("v_macdinh", NpgsqlDbType.Numeric).Value = v_macdinh;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_reportphieu");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }

        public bool upd_xn_ten_default(decimal v_id, decimal v_stt, string v_ma, string v_ten)
        {
            m_sql = "update " + s_schemaroot + ".xn_ten_default set stt=:v_stt, ma=:v_ma, ten=:v_ten where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar,10).Value = v_ma;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".xn_ten_default(id,stt,ma,ten) values(:v_id,:v_stt,:v_ma,:v_ten)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_ten_default");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_chitiet_default(decimal v_id,decimal v_id_ten_default,decimal v_id_ten,decimal v_stt)
        {
            m_sql = "update " + s_schemaroot + ".xn_chitiet_default set id_ten_default=:v_id_ten_default, id_ten=:v_id_ten, stt=:v_stt where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_id_ten_default", NpgsqlDbType.Numeric).Value = v_id_ten_default;
            m_command.Parameters.Add("v_id_ten", NpgsqlDbType.Numeric).Value = v_id_ten;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".xn_chitiet_default(id,id_ten_default,id_ten,stt) values(:v_id,:v_id_ten_default,:v_id_ten,:v_stt)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_id_ten_default", NpgsqlDbType.Numeric).Value = v_id_ten_default;
                    m_command.Parameters.Add("v_id_ten", NpgsqlDbType.Numeric).Value = v_id_ten;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_chitiet_default");
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

        #region Lay ket qua tu may
        public void f_may_save_local(string v_idmay, string v_path, string v_text, bool v_sophieu, bool v_mabn, bool v_ngay)
        {
            try
            {
                if (!System.IO.Directory.Exists("..//..//option//"))
                {
                    System.IO.Directory.CreateDirectory("..//..//option");
                }
            }
            catch
            {
            }
            try
            {
                DataSet ads = new DataSet();
                ads.Tables.Add("Table");
                ads.Tables[0].Columns.Add("lpath");
                ads.Tables[0].Columns.Add("text");
                ads.Tables[0].Columns.Add("sophieu");
                ads.Tables[0].Columns.Add("mabn");
                ads.Tables[0].Columns.Add("ngay");
                ads.Tables[0].Rows.Add(new string[] { v_path, v_text, v_sophieu ? "1" : "0", v_mabn ? "1" : "0", v_ngay ? "1" : "0" });
                ads.WriteXml("..//..//option//v_option_may_" + v_idmay + ".xml", XmlWriteMode.WriteSchema);
            }
            catch
            {
            }
        }
        public string f_may_get_local_path(string v_idmay)
        {
            try
            {
                DataSet ads = new DataSet();
                ads.ReadXml("..//..//option//v_option_may_" + v_idmay + ".xml");
                return ads.Tables[0].Rows[0]["lpath"].ToString().Trim();
            }
            catch
            {
                return "";
            }
        }
        public string f_may_get_local_text(string v_idmay)
        {
            try
            {
                DataSet ads = new DataSet();
                ads.ReadXml("..//..//option//v_option_may_" + v_idmay + ".xml");
                return ads.Tables[0].Rows[0]["text"].ToString().Trim();
            }
            catch
            {
                return "";
            }
        }
        public bool f_may_get_local_sophieu(string v_idmay)
        {
            try
            {
                DataSet ads = new DataSet();
                ads.ReadXml("..//..//option//v_option_may_" + v_idmay + ".xml");
                return ads.Tables[0].Rows[0]["sophieu"].ToString().Trim() == "1";
            }
            catch
            {
                return false;
            }
        }
        public bool f_may_get_local_mabn(string v_idmay)
        {
            try
            {
                DataSet ads = new DataSet();
                ads.ReadXml("..//..//option//v_option_may_" + v_idmay + ".xml");
                return ads.Tables[0].Rows[0]["mabn"].ToString().Trim() == "1";
            }
            catch
            {
                return false;
            }
        }
        public bool f_may_get_local_ddmmyyyy(string v_idmay)
        {
            try
            {
                DataSet ads = new DataSet();
                ads.ReadXml("..//..//option//v_option_may_" + v_idmay + ".xml");
                return ads.Tables[0].Rows[0]["ngay"].ToString().Trim() == "1";
            }
            catch
            {
                return false;
            }
        }
        public string f_may_get_local_tenfile(string v_text, string v_sophieu, string v_mabn, string v_ngay)
        {
            try
            {
                return v_text + v_sophieu + v_mabn + v_ngay;
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region GET DATA TABLE
        public DataSet f_get_xn_error()
        {
            try
            {
                DataSet ads = null, adst = null;
                string asql = "";
                asql = "select message, computer,tables, to_char(ngayud,'dd/mm/yyyy hh24:mi') as ngayud,'' as blank from " + s_schemaroot + ".xn_error order by ngayud desc";
                ads = get_data(asql);

                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    asql = "select message, computer,'" + r["schemaname"].ToString() + ".' || tables as tables, to_char(ngayud,'dd/mm/yyyy hh24:mi') as ngayud,'' as blank from " + r["schemaname"].ToString() + ".xn_error order by ngayud desc";
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
        public DataSet f_get_dmcomputer()
        {
            string asql = "select a.id, a.computer,'' as ip, '' as status, to_char(a.ngayud,'dd/mm/yyyy hh24:mi') as ngayud from " + s_schemaroot + ".dmcomputer a order by a.computer";
            return get_data(asql);
        }
        public DataSet f_get_xn_dmcapnhat_frmMedisoftcenterupdate()
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
        public DataSet f_get_xn_phanquyen(string v_userid)
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
            return get_data("select userid,menuname,chon,chitiet from " + s_schemaroot + ".xn_phanquyen where userid=" + auserid);
        }
        public string f_get_quyen_chitiet(string v_userid, string v_menuname)
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
            try
            {
                return get_data("select userid,menuname,chon,chitiet from " + s_schemaroot + ".xn_phanquyen where userid=" + auserid + " and menuname='" + v_menuname + "'").Tables[0].Rows[0]["chitiet"].ToString().PadLeft(6,'0');
            }
            catch
            {
                return "000000";
            }
        }
        public bool f_quyen_them(string v_quyen)
        {
            try
            {
                return (v_quyen.Substring(0,1)=="1");
            }
            catch
            {
                return true;
            }
        }
        public bool f_quyen_xoa(string v_quyen)
        {
            try
            {
                return (v_quyen.Substring(1, 1) == "1");
            }
            catch
            {
                return false;
            }
        }
        public bool f_quyen_sua(string v_quyen)
        {
            try
            {
                return (v_quyen.Substring(2, 1) == "1");
            }
            catch
            {
                return true;
            }
        }
        public bool f_quyen_xem(string v_quyen)
        {
            try
            {
                return (v_quyen.Substring(3, 1) == "1");
            }
            catch
            {
                return true;
            }
        }
        public bool f_quyen_in(string v_quyen)
        {
            try
            {
                return (v_quyen.Substring(4, 1) == "1");
            }
            catch
            {
                return true;
            }
        }
        public bool f_quyen_export(string v_quyen)
        {
            try
            {
                return (v_quyen.Substring(5, 1) == "1");
            }
            catch
            {
                return true;
            }
        }

        public DataSet f_get_xn_phanquyennhom(string v_id_nhom)
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
            return get_data("select id_nhom,menuname,chon,chitiet from " + s_schemaroot + ".xn_phanquyennhom where id_nhom=" + aid);
        }
        public DataSet f_get_xn_nhomdlogin(string v_id, string v_nhom, string v_ma, string v_ten, string v_diengiai)
        {
            string asql = "", aexp = "";
            v_ma = v_ma.Replace("'","''");
            v_ten = v_ten.Replace("'", "''");
            v_diengiai = v_diengiai.Replace("'", "''");
            asql = "select a.id,a.nhom,a.ma,a.ten,a.diengiai,a.id_bv_so,a.right_,a.readonly,'' as blank from " + s_schemaroot + ".xn_nhomdlogin a";
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
                aexp += "a.ma='" + v_ma.Replace("'","''") + "'";
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
        public DataSet f_get_xn_dlogin(string v_id, string v_id_nhom, string v_hoten, string v_userid, string v_password_)
        {
            string asql = "", aexp = "";
            asql = "select a.id,a.id_nhom,a.hoten,a.userid,a.password_,a.id_bv_so,'' as blank,makp,idchinhanh  from " + s_schemaroot + ".xn_dlogin a";
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
        public DataSet f_get_xn_donvi(string v_id, string v_ma, string v_ten, string v_id_hl7)
        {
            string asql = "", aexp = "";
            asql = "select a.id,a.ma,a.ten,a.ten1,a.heso,a.readonly, a.id_hl7, b.ten as ten_hl7, '' as blank from " + s_schemaroot + ".xn_donvi a left join " + s_schemaroot + ".xn_donvi_hl7 b on a.id_hl7=b.id";
            if (v_id != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id=" + v_id;
            }
            if (v_ma != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.ma='" + v_ma.Replace("'","''") + "'";
            }
            if (v_ten != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.ten='" + v_ten.Replace("'","''") + "'";
            }
            if (v_id_hl7 != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id_hl7=" + v_id_hl7 + "";
            }

            if (aexp != "")
            {
                aexp = " where " + aexp;
            }
            asql += aexp;
            asql += " order by a.ten";
            return get_data(asql);
        }
        public DataSet f_get_xn_donvi_hl7(string v_id, string v_stt, string v_ma, string v_ten, string v_anh, string v_readonly)
        {
            string asql = "", aexp = "";
            asql = "select a.id, a.stt, a.ma, a.ten, a.anh, a.readonly, '' as blank from " + s_schemaroot + ".xn_donvi_hl7 a";
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
            if (v_ma != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.ma='" + v_ma.Replace("'","''") + "'";
            }
            if (v_ten != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.ten='" + v_ten.Replace("'","''") + "'";
            }
            if (v_anh != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.anh='" + v_anh.Replace("'", "''") + "'";
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
        public DataSet f_get_xn_gram_vt(string v_ma, string v_ten, string v_readonly)
        {
            string asql = "", aexp = "";
            asql = "select a.ma,a.ten,a.readonly, '' as blank from " + s_schemaroot + ".xn_gram_vt a";
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
        public DataSet f_get_xn_status_vt(string v_ma, string v_ten, string v_readonly)
        {
            string asql = "", aexp = "";
            asql = "select a.ma,a.ten,a.readonly,'' as blank from " + s_schemaroot + ".xn_status_vt a";
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
        public DataSet f_get_xn_vitrung(string v_id, string v_stt, string v_ma, string v_ten, string v_viettat, string v_gram, string v_status, string v_readonly)
        {
            string asql = "", aexp = "";
            asql = "select a.id,a.stt,a.ma,a.ten,a.gram,a.status,a.viettat, b.ten as gram_ten, c.ten as status_ten, a.readonly,'' as blank from " + s_schemaroot + ".xn_vitrung a left join " + s_schemaroot + ".xn_gram_vt b on a.gram=b.ma left join " + s_schemaroot + ".xn_status_vt c on a.status=b.ma";
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
            if (v_gram != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.gram='" + v_gram.Replace("'", "''") + "'";
            }
            if (v_status != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.status='" + v_status.Replace("'", "''") + "'";
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
        public DataSet f_get_xn_khangsinh(string v_id, string v_stt, string v_ma, string v_mabv, string v_ten, string v_viettat, string v_readonly)
        {
            string asql = "", aexp = "";
            asql = "select a.id, a.stt,a.ma,a.mabv,a.ten,viettat,a.readonly, '' as blank from " + s_schemaroot + ".xn_khangsinh a";
            if (v_id != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id=" + v_id + "";
            }
            if (v_stt != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.stt=" + v_stt + "";
            }
            if (v_mabv != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.mabv='" + v_mabv.Replace("'", "''") + "'";
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
        public DataSet f_get_xn_mauthu(string v_id, string v_stt, string v_ma, string v_mabv,string v_ten, string v_anh, string v_viettat,string v_donvi, string v_readonly)
        {
            string asql = "", aexp = "";
            asql = "select a.id,a.stt,a.ma,a.ten,a.anh,a.viettat,a.donvi, b.ten as tendonvi,a.mabv, a.readonly,'' as blank from " + s_schemaroot + ".xn_mauthu a left join " + s_schemaroot + ".xn_donvi b on a.donvi=b.id";
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
            if (v_ma != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.ma='" + v_ma.Replace("'", "''") + "'";
            }
            if (v_mabv != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.mabv='" + v_mabv.Replace("'", "''") + "'";
            }
            if (v_ten != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.ten='" + v_ten.Replace("'", "''") + "'";
            }
            if (v_anh != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.anh='" + v_anh.Replace("'", "''") + "'";
            }
            if (v_viettat != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.viettat='" + v_viettat.Replace("'", "''") + "'";
            }
            if (v_donvi != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.donvi=" + v_donvi + "";
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
        public DataSet f_get_xn_vitri(string v_id, string v_stt, string v_ma, string v_mabv, string v_ten, string v_anh, string v_viettat, string v_readonly)
        {
            string asql = "", aexp = "";
            asql = "select a.id,a.stt,a.ma,a.mabv,a.ten,a.anh,a.viettat,a.readonly,'' as blank from " + s_schemaroot + ".xn_vitri a";
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
            if (v_ma != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.ma='" + v_ma.Replace("'", "''") + "'";
            }
            if (v_mabv != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.mabv='" + v_mabv.Replace("'", "''") + "'";
            }
            if (v_ten != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.ten='" + v_ten.Replace("'", "''") + "'";
            }
            if (v_anh != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.anh='" + v_anh.Replace("'", "''") + "'";
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
        public DataSet f_get_xn_ktv(string v_ma, string v_hoten, string v_viettat, string v_readonly)
        {
            string asql = "", aexp = "";
            asql = "select a.ma,a.hoten,a.viettat,a.chucvu,a.duyetmau,a.passwd,a.readonly,'' as blank from " + s_schemaroot + ".xn_ktv a";
            if (v_ma != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.ma='" + v_ma.Replace("'", "''") + "'";
            }
            if (v_hoten != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.hoten='" + v_hoten.Replace("'", "''") + "'";
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
            asql += " order by a.hoten";
            return get_data(asql);
        }
        public DataSet f_get_xn_diadiem(string v_id, string v_stt, string v_ma, string v_ten, string v_viettat, string v_readonly)
        {
            string asql = "", aexp = "";
            asql = "select a.id,a.stt,a.ma,a.ten,a.viettat,a.readonly,'' as blank from " + s_schemaroot + ".xn_diadiem a";
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
        public DataSet f_get_xn_so_conhom()
        {
            string asql = "select a.id,a.ten from " + s_schemaroot + ".xn_so a ";
            return get_data(asql);
        }
        public DataSet f_get_xn_treebaocao(string v_id, string v_id_cha, string v_stt, string v_ten, string v_asql, string v_tenreport, string v_readonly)
        {
            string asql = "", aexp = "";
            asql = "select a.id,a.id_cha,a.stt,a.ten,a.asql,a.tenreport,a.readonly from " + s_schemaroot + ".xn_treebaocao a";
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
        public DataSet f_get_xn_so(string v_id, string v_stt, string v_ma, string v_ten, string v_viettat, string v_readonly)
        {
            string asql = "", aexp = "";
            asql = "select a.id,a.stt,a.ma,a.ten,a.viettat,a.readonly,'' as blank from " + s_schemaroot + ".xn_so a";
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
        public DataSet f_get_xn_nhom(string v_id, string v_id_so, string v_stt, string v_ma, string v_ten, string v_viettat, string v_readonly)
        {
            string asql = "", aexp = "";
            asql = "select a.id,a.id_so, a.stt,a.ma,a.ten,a.viettat,a.readonly,'' as blank from " + s_schemaroot + ".xn_nhom a";
            if (v_id != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id=" + v_id;
            }
            if (v_id_so != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id_so=" + v_id_so;
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
        public DataSet f_get_xn_loai(string v_id, string v_id_nhom,string v_stt, string v_ma, string v_ten, string v_viettat, string v_tieuban, string v_readonly)
        {
            string asql = "", aexp = "";
            asql = "select a.id,a.id_nhom,a.stt,a.ma,a.ten,a.viettat,a.tieuban, a.readonly,'' as blank from " + s_schemaroot + ".xn_loai a";
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
            if (v_tieuban != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.tieuban=" + v_tieuban;
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
        public DataSet f_get_xn_ten_frmNewten(string v_id, string v_id_loai, string v_id_nhom, string v_stt, string v_ma, string v_ten, string v_viettat, string v_tieuban, string v_donvi, string v_csbt_nu, string v_mincsbt_nu, string v_maxcsbt_nu, string v_csbt_nam, string v_mincsbt_nam, string v_maxcsbt_nam, string v_ghichu, string v_readonly)
        {
            string asql = "", aexp = "";
            ///delta_chk=:v_delta,tg_tinh=:v_thoigian
            asql = "select a.id,a.id_loai,a.id_nhom, a.stt,a.ma,a.ten,a.viettat,a.tieuban, a.ghichu, a.csbt_nu,a.mincsbt_nu,a.maxcsbt_nu,a.csbt_nam,a.mincsbt_nam,a.maxcsbt_nam,a.readonly,a.donvi,a.cs_nguycap,a.min_csnuycap,a.max_csnuycap,a.delta_chk,a.tg_tinh,'' as blank from " + s_schemaroot + ".xn_ten a";
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
                aexp += "a.id_loai=" + v_id_loai;
            }
            if (v_id_nhom != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id_nhom=" + v_id_nhom;
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
            if (v_tieuban != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.tieuban=" + v_tieuban + "";
            }
            if (v_donvi != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.donvi=" + v_donvi + "";
            }
            if (v_csbt_nu != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.csbt_nu='" + v_csbt_nu.Replace("'", "''") + "'";
            }
            if (v_mincsbt_nu != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.mincsbt_nu=" + v_mincsbt_nu + "";
            }
            if (v_maxcsbt_nu != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.maxcsbt_nu=" + v_maxcsbt_nu + "";
            }
            if (v_csbt_nam != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.csbt_nam='" + v_csbt_nam.Replace("'", "''") + "'";
            }
            if (v_mincsbt_nam != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.mincsbt_nam=" + v_mincsbt_nam + "";
            }
            if (v_maxcsbt_nam != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.maxcsbt_nam=" + v_maxcsbt_nam + "";
            }
            if (v_ghichu != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.ghichu='" + v_ghichu.Replace("'", "''") + "'";
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
        public DataSet f_get_xn_ten(string v_id, string v_id_loai, string v_id_nhom, string v_stt, string v_ma, string v_ten, string v_viettat, string v_tieuban, string v_donvi, string v_csbt_nu, string v_mincsbt_nu, string v_maxcsbt_nu, string v_csbt_nam, string v_mincsbt_nam, string v_maxcsbt_nam, string v_ghichu, string v_readonly)
        {
            string asql = "", aexp = "";
            asql = "select a.id,a.id_loai,a.id_nhom, a.stt,a.ma,a.ten,a.viettat,a.tieuban, a.ghichu, a.csbt_nu,a.mincsbt_nu,a.maxcsbt_nu,a.csbt_nam,a.mincsbt_nam,a.maxcsbt_nam,a.readonly,'' as blank from " + s_schemaroot + ".xn_ten a";
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
                aexp += "a.id_loai=" + v_id_loai;
            }
            if (v_id_nhom != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id_nhom=" + v_id_nhom;
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
            if (v_tieuban != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.tieuban=" + v_tieuban + "";
            }
            if (v_donvi != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.donvi=" + v_donvi + "";
            }
            if (v_csbt_nu != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.csbt_nu='" + v_csbt_nu.Replace("'", "''") + "'";
            }
            if (v_mincsbt_nu != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.mincsbt_nu=" + v_mincsbt_nu + "";
            }
            if (v_maxcsbt_nu != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.maxcsbt_nu=" + v_maxcsbt_nu + "";
            }
            if (v_csbt_nam != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.csbt_nam='" + v_csbt_nam.Replace("'", "''") + "'";
            }
            if (v_mincsbt_nam != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.mincsbt_nam=" + v_mincsbt_nam + "";
            }
            if (v_maxcsbt_nam != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.maxcsbt_nam=" + v_maxcsbt_nam + "";
            }
            if (v_ghichu != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.ghichu='" + v_ghichu.Replace("'", "''") + "'";
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

        public DataSet f_get_xn_bv_so(string v_id, string v_id_so, string v_stt, string v_ma, string v_ten, string v_viettat, string v_tenreport, string v_readonly)
        {
            string asql = "", aexp = "";
            asql = "select a.id,a.id_so,a.stt,a.ma,a.ten,a.viettat,a.tenreport,a.readonly,'' as blank from " + s_schemaroot + ".xn_bv_so a";
            if (v_id != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id=" + v_id;
            }
            if (v_id_so != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id_so=" + v_id_so;
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
            asql += " order by a.ten";
            return get_data(asql);
        }
        public DataSet f_get_xn_bv_ten(string v_id, string v_id_bv_so, string v_id_vienphi, string v_stt, string v_ma, string v_ten, string v_viettat, string v_tieuban, string v_readonly)
        {
            string asql = "", aexp = "";
            asql = "select a.id,a.id_bv_so,a.id_vienphi,a.stt,a.ma,a.ten,a.viettat,a.tieuban,a.readonly,'' as blank from " + s_schemaroot + ".xn_bv_ten a";
            if (v_id != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id=" + v_id;
            }
            if (v_id_bv_so != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id_bv_so=" + v_id_bv_so;
            }
            if (v_id_vienphi != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id_vienphi=" + v_id_vienphi;
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
            if (v_tieuban != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.tieuban=" + v_readonly + "";
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
        public DataSet f_get_xn_bv_chitiet(string v_id, string v_id_bv_ten, string v_id_ten, string v_stt, string v_viettat, string v_tieuban, string v_readonly)
        {
            string asql = "", aexp = "";
            asql = "select a.id,a.id_bv_ten,a.id_ten, a.stt,a.tieuban,a.viettat,a.readonly,'' as blank from " + s_schemaroot + ".xn_bv_chitiet a";
            if (v_id != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id=" + v_id;
            }
            if (v_id_bv_ten != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id_bv_ten=" + v_id_bv_ten;
            }
            if (v_id_ten != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id_ten=" + v_id_ten;
            }
            if (v_stt != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.stt=" + v_stt;
            }
            if (v_tieuban != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.tieuban=" + v_tieuban;
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
        public DataSet f_get_xn_bv_vitrung(string v_id, string v_id_vitrung, string v_stt, string v_ma, string v_ten, string v_viettat, string v_gram, string v_status, string v_id_giavp, string v_tenboks, string v_readonly)
        {
            string asql = "", aexp = "";
            asql = "select a.id,a.stt,a.ma,a.ten,a.viettat,a.tenboks,a.readonly,'' as blank from " + s_schemaroot + ".xn_bv_vitrung a";
            if (v_id != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id=" + v_id;
            }
            if (v_id_vitrung != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id_vitrung=" + v_id_vitrung;
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
            if (v_gram != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.gram='" + v_gram.Replace("'", "''") + "'";
            }
            if (v_status != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.status='" + v_status.Replace("'", "''") + "'";
            }
            if (v_viettat != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.viettat='" + v_viettat.Replace("'", "''") + "'";
            }
            if (v_tenboks != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.tenboks='" + v_tenboks.Replace("'", "''") + "'";
            }
            if (v_id_giavp != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id_giavp=" + v_id_giavp + "";
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
        public DataSet f_get_xn_bv_khangsinh(string v_id, string v_id_bv_vitrung, string v_id_khangsinh, string v_stt, string v_maxr, string v_mins,string v_hamluong, string v_readonly)
        {
            string asql = "", aexp = "";
            asql = "select a.id,a.id_bv_vitrung,a.id_khangsinh,a.stt,a.maxr,a.mins,a.hamluong,a.readonly,'' as blank from " + s_schemaroot + ".xn_bv_khangsinh a";
            if (v_id != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id=" + v_id;
            }
            if (v_id_bv_vitrung != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id_bv_vitrung=" + v_id_bv_vitrung;
            }
            if (v_id_khangsinh != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.id_khangsinh=" + v_id_khangsinh;
            }
            if (v_stt != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.stt=" + v_stt;
            }
            if (v_maxr != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.maxr=" + v_maxr + "";
            }
            if (v_mins != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.mins=" + v_mins + "";
            }
            if (v_hamluong != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.hamluong='" + v_hamluong.Replace("'","''") + "'";
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
            asql += " order by a.stt";
            return get_data(asql);
        }
        public DataSet f_get_xn_so(string v_fieldsort)
        {
            if (v_fieldsort == "")
            {
                v_fieldsort = "ten";
            }
            return get_data("select * from " + s_schemaroot + ".xn_so order by "+v_fieldsort);
        }
        public DataSet f_get_xn_nhom(string v_fieldsort)
        {
            if (v_fieldsort == "")
            {
                v_fieldsort = "ten";
            }
            return get_data("select * from " + s_schemaroot + ".xn_nhom order by "+v_fieldsort);
        }
        public DataSet f_get_xn_loai(string v_fieldsort)
        {
            if (v_fieldsort == "")
            {
                v_fieldsort = "ten";
            }
            return get_data("select * from " + s_schemaroot + ".xn_loai order by "+v_fieldsort);
        }
        public DataSet f_get_xn_ten(string v_fieldsort)
        {
            if (v_fieldsort == "")
            {
                v_fieldsort = "ten";
            }
            return get_data("select * from " + s_schemaroot + ".xn_ten order by "+v_fieldsort);
        }
        public DataSet f_get_xn_bv_so(string v_fieldsort,string id_bv_so)
        {
            if (v_fieldsort == "")
            {
                v_fieldsort = "ten";
            }

            return get_data("select * from " + s_schemaroot + ".xn_bv_so " + (id_bv_so.Trim(',') != "" ? " where  id in(" + id_bv_so.Trim(',') + ")" : "") + " order by " + v_fieldsort);
        }
        public DataSet f_get_xn_bv_ten(string v_fieldsort)
        {
            if (v_fieldsort == "")
            {
                v_fieldsort = "ten";
            }
            return get_data("select * from " + s_schemaroot + ".xn_bv_ten order by "+v_fieldsort);
        }
        public DataSet f_get_xn_bv_chitiet(string v_fieldsort)
        {
            if (v_fieldsort == "")
            {
                v_fieldsort = "stt";
            }
            return get_data("select * from " + s_schemaroot + ".xn_chitiet order by " + v_fieldsort);
        }
        public DataSet f_get_xn_dlogin_frmoption()
        {
            return get_data("select id, hoten || ' (' || userid || ')' as hoten from " + s_schemaroot + ".xn_dlogin order by hoten");
        }
        public DataSet f_get_xn_ten_frmxetnghiem()
        {
            return get_data("select a.id, a.stt,a.ma,a.ten, b.ten as donvi, a.csbt_nu,to_number(a.maxcsbt_nu) as maxcsbt_nu,to_number(a.mincsbt_nu) as mincsbt_nu, a.csbt_nam, to_number(a.maxcsbt_nam) as maxcsbt_nam,to_number(a.mincsbt_nam) as mincsbt_nam,a.readonly,a.ghichu,a.viettat,  '' as blank, a.id_loai, a.id_nhom, c.id_so from " + s_schemaroot + ".xn_ten a left join " + s_schemaroot + ".xn_donvi b on a.donvi=b.id left join " + s_schemaroot + ".xn_nhom c on a.id_nhom=c.id order by a.ten");
        }
        public DataSet f_get_xn_ten_frmmauthu_bv()
        {
            return get_data("select a.id, a.stt,a.ma,a.ten, b.ten as donvi, a.csbt_nu,a.maxcsbt_nu,a.mincsbt_nu, a.csbt_nam, a.maxcsbt_nam,a.mincsbt_nam,a.readonly,a.ghichu,a.viettat,a.id_loai, a.id_nhom, c.id_so, count(d.id_mauthu) as n, 0 as chon, '' as blank  from " + s_schemaroot + ".xn_ten a left join " + s_schemaroot + ".xn_donvi b on a.donvi=b.id left join " + s_schemaroot + ".xn_nhom c on a.id_nhom=c.id left join " + s_schemaroot + ".xn_sdmauthu d on a.id=d.id_ten group by a.id, a.stt,a.ma,a.ten, b.ten, a.csbt_nu,a.maxcsbt_nu,a.mincsbt_nu, a.csbt_nam, a.maxcsbt_nam,a.mincsbt_nam,a.readonly,a.ghichu,a.viettat,a.id_loai, a.id_nhom, c.id_so order by ten");
        }
        public DataSet f_get_xn_sdmauthu_frmmauthu_bv()
        {
            return get_data("select case when c.id_ten is null then 0 else c.id_ten end as id_ten, case when c.soluong is null then 0 else c.soluong end as soluong, a.id, a.stt,a.ma, a.mabv,a.ten, a.anh, b.ten as donvi,a.viettat, 0 as chon, '' as blank from " + s_schemaroot + ".xn_mauthu a left join " + s_schemaroot + ".xn_donvi b on a.donvi=b.id left join " + s_schemaroot + ".xn_sdmauthu c on c.id_mauthu=a.id order by a.ten");
        }
        public DataSet f_get_xn_ten_frmchonxetnghiem()
        {
            return get_data("select a.id, a.stt,a.ma,a.ten, b.ten as donvi, a.csbt_nu,a.maxcsbt_nu,a.mincsbt_nu, a.csbt_nam, a.maxcsbt_nam,a.mincsbt_nam,a.readonly,a.ghichu,a.viettat, 0 as chon,  '' as blank, a.id_loai, a.id_nhom, c.id_so,a.tieuban from " + s_schemaroot + ".xn_ten a left join " + s_schemaroot + ".xn_donvi b on a.donvi=b.id left join " + s_schemaroot + ".xn_nhom c on a.id_nhom=c.id order by a.ten");
        }
   
        public DataSet f_get_xn_bv_chitiet_frmchonxetnghiem(string v_id_bv_ten)
        {
            return get_data("select a.id, a.id_ten from " + s_schemaroot + ".xn_bv_chitiet a where a.id_bv_ten=" + v_id_bv_ten + " order by a.id_ten");
        }
        public decimal f_get_stt_xn_bv_chitiet(string v_id_bv_ten)
        {
            decimal art = 0;
            try
            {
                art = decimal.Parse(get_data("select max(a.stt) from " + s_schemaroot + ".xn_bv_chitiet a where a.id_bv_ten=" + v_id_bv_ten + "").Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                art = 0;
            }
            return art;
        }
        public decimal f_get_stt_xn_chitiet_default(string v_id_ten_default)
        {
            decimal art = 0;
            try
            {
                art = decimal.Parse(get_data("select max(a.stt) from " + s_schemaroot + ".xn_chitiet_default a where a.id_ten_default=" + v_id_ten_default + "").Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                art = 0;
            }
            return art;
        }

        public DataSet f_get_xn_bv_ten_frmchonxetnghiem(string v_id_bv_so)
        {
            return get_data("select a.id, a.id_vienphi from " + s_schemaroot + ".xn_bv_ten a where a.id_bv_so=" + v_id_bv_so + " order by a.id_vienphi");
        }
        public decimal f_get_stt_xn_bv_ten(string v_id_bv_so)
        {
            decimal art = 0;
            try
            {
                art = decimal.Parse(get_data("select max(a.stt) from " + s_schemaroot + ".xn_bv_ten a where a.id_bv_so=" + v_id_bv_so + "").Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                art = 0;
            }
            return art;
        }
        public decimal f_get_stt_xn_bv_vitrung()
        {
            decimal art = 0;
            try
            {
                art = decimal.Parse(get_data("select max(a.stt) from " + s_schemaroot + ".xn_bv_vitrung a").Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                art = 0;
            }
            return art;
        }
        public decimal f_get_stt_xn_bv_khangsinh(string v_id_bv_vitrung)
        {
            decimal art = 0;
            try
            {
                art = decimal.Parse(get_data("select max(a.stt) from " + s_schemaroot + ".xn_bv_khangsinh a where a.id_bv_vitrung="+v_id_bv_vitrung).Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                art = 0;
            }
            return art;
        }
        public DataSet f_get_v_giavp_frmchonvienphi()
        {
            return get_data("select a.id, a.stt,a.ma,a.ten, a.dvt, a.gia_th,a.gia_bh,a.gia_dv, a.gia_nn, a.id_loai, b.id_nhom, 0 as chon, '' as blank from " + s_schemaroot + ".v_giavp a left join " + s_schemaroot + ".v_loaivp b on a.id_loai=b.id left join " + s_schemaroot + ".v_nhomvp c on b.id_nhom=c.ma order by a.ten");
        }
        public DataSet f_get_v_loaivp_frmchonvienphi(string v_sort)
        {
            return get_data("select id, ma, stt, ten, id_nhom from "+s_schemaroot+".v_loaivp order by "+v_sort);
        }
        public DataSet f_get_v_nhomvp_frmchonvienphi(string v_sort)
        {
            return get_data("select ma,stt,ten from " + s_schemaroot + ".v_nhomvp order by "+v_sort);
        }
        public DataSet f_get_xn_so_frmxetnghiem()
        {
            return get_data("select id, ten from " + s_schemaroot + ".xn_so order by ten");
        }
        public DataSet f_get_xn_nhom_frmxetnghiem()
        {
            return get_data("select id, ten, id_so from " + s_schemaroot + ".xn_nhom order by ten");
        }
        public DataSet f_get_xn_loai_frmxetnghiem()
        {
            return get_data("select id, ten, id_loai from " + s_schemaroot + ".xn_loai order by ten");
        }
        public DataSet f_get_xn_bv_ten_frmxetnghiem_bv()
        {
            return get_data("select a.id, a.stt,a.ma,a.ten,a.viettat,a.tieuban,d.ma as ma_vp,d.ten as ten_vp,a.readonly,a.id_bv_so, 0 as chon, '' as blank, count(c.id) as n,a.dvt,case when a.guimau=1 then 1 else 0 end as gui_noibo,case when a.guimau=2 then 1 else 0 end as gui_ngoai from medibv.xn_bv_ten a left join medibv.xn_bv_so b on a.id_bv_so=b.id left join medibv.xn_bv_chitiet c on a.id=c.id_bv_ten left join medibv.v_giavp d on a.id_vienphi=d.id group by a.id, a.stt,a.ma,a.ten,d.ma,d.ten,a.viettat,a.tieuban,a.readonly,a.id_bv_so,a.dvt,a.guimau  order by ten");
        }
        public DataSet f_get_xn_bv_chitiet_frmxetnghiem_bv()
        {
            return get_data("select distinct a.id, a.readonly, a.id_bv_ten, b.id_bv_so, a.stt,b.ten as ten_bv_ten, c.ma, c.ten, a.viettat, d.ten as donvi,a.macdinh, c.csbt_nu, c.mincsbt_nu,c.maxcsbt_nu, c.csbt_nam, c.mincsbt_nam, c.maxcsbt_nam, c.tieuban, 0 as chon, '' as blank from " + s_schemaroot + ".xn_bv_chitiet a left join " + s_schemaroot + ".xn_bv_ten b on a.id_bv_ten=b.id left join " + s_schemaroot + ".xn_ten c on a.id_ten=c.id left join " + s_schemaroot + ".xn_donvi d on c.donvi=d.id order by a.stt");
        }
        public DataSet f_get_xn_bv_so_frmxetnghiem_bv()
        {
            return get_data("select a.id, a.ten, b.ten as ten_bo from " + s_schemaroot + ".xn_bv_so a left join " + s_schemaroot + ".xn_so b on a.id_so=b.id order by a.ten, b.ten");
        }
        public DataSet f_get_xn_bv_gram_frmvitrung_bv()
        {
            return get_data("select distinct a.gram from " + s_schemaroot + ".xn_vitrung a order by a.gram");
        }
        public DataSet f_get_xn_vitrung_frmnhapksd()
        {
            return get_data("select a.id,a.stt,a.ma,a.ten,a.gram,a.status,a.viettat,a.readonly,0 as chon, '' as blank, count(b.id) as n from " + s_schemaroot + ".xn_vitrung a inner join " + s_schemaroot + ".xn_bv_vitrung b on a.id=b.id_vitrung group by a.id,a.stt,a.ma,a.ten,a.gram,a.status,a.viettat,a.readonly order by ten");
        }
        public DataSet f_get_xn_vitrung_frmvitrung_bv()
        {
            return get_data("select a.id,a.stt,a.ma,a.ten,a.gram,a.status,a.viettat,a.readonly,0 as chon, '' as blank, count(b.id) as n from " + s_schemaroot + ".xn_vitrung a left join " + s_schemaroot + ".xn_bv_vitrung b on a.id=b.id_vitrung group by a.id,a.stt,a.ma,a.ten,a.gram,a.status,a.viettat,a.readonly order by ten");
        }
        public DataSet f_get_xn_bv_vitrung_frmvitrung_bv()
        {
            return get_data("select a.id,a.id_vitrung,a.stt,a.ma,a.ten,a.khangsinh,a.gram,a.status,a.readonly,a.tenboks from " + s_schemaroot + ".xn_bv_vitrung a order by a.id,a.stt,a.ten");
        }
        public DataSet f_get_xn_bv_vitrung_frmnhapksd()
        {
            return get_data("select a.id,a.id_vitrung,a.stt,a.ma,a.ten,a.khangsinh,a.gram,a.status,a.readonly,a.tenboks from " + s_schemaroot + ".xn_bv_vitrung a order by a.id,a.stt,a.ten");
        }
        public DataSet f_get_xn_bv_khangsinh_frmvitrung_bv()
        {
            return get_data("select a.id, a.id_bv_vitrung, a.id_khangsinh, a.stt,b.ma,b.ten as ten_khangsinh,a.hamluong,case when a.maxr is null then 0 else a.maxr end as maxr,case when a.mins is null then 0 else a.mins end as mins,a.readonly,0 as chon, '' as blank from " + s_schemaroot + ".xn_bv_khangsinh a left join " + s_schemaroot + ".xn_khangsinh b on a.id_khangsinh=b.id order by a.id,a.stt,b.ten");
        }
        public DataSet f_get_xn_bv_khangsinh_frmnhapksd()
        {
            return get_data("select 0 as chon,a.id,a.stt,b.ma,b.ten as ten_khangsinh,a.hamluong,0 as ketqua,0 as s, 0 as i, 0 as r,case when a.maxr is null then 0 else a.maxr end as maxr,case when a.mins is null then 0 else a.mins end as mins,'' as blank,a.readonly,a.id_khangsinh,a.id_bv_vitrung from " + s_schemaroot + ".xn_bv_khangsinh a inner join " + s_schemaroot + ".xn_khangsinh b on a.id_khangsinh=b.id order by a.id,a.stt,b.ten");
        }
        public DataSet f_get_xn_mauthu_frmchonmauthu()
        {
            return get_data("select a.id,a.stt,a.ma,a.mabv,a.ten,a.anh,a.viettat, 0 as soluong, b.ten as donvi,0 as chon,substr(a.ten,1,1) as abc, 0 as readonly from " + s_schemaroot + ".xn_mauthu a left join " + s_schemaroot + ".xn_donvi b on a.donvi=b.id order by a.ten");
        }
        public DataSet f_get_xn_sdmauthu_frmchonmauthu(string v_id_ten)
        {
            return get_data("select a.id_mauthu, case when a.soluong is null then 0 else a.soluong end as soluong, case when a.readonly is null then 0 else a.readonly end as readonly from " + s_schemaroot + ".xn_sdmauthu a where a.id_ten=" + v_id_ten + " order by a.id_mauthu");
        }
        public DataSet f_get_d_dmbd_frmchonhoachat()
        {
            return get_data("select 0 as chon, a.id,a.ma,a.ten,a.dang,a.hamluong, a.manhom,a.maloai, 0 as soluong, 0 as soluongqd, 0 as readonly,'' as blank  from " + s_schemaroot + ".d_dmbd a order by a.ten");
        }
        public DataSet f_get_d_dmnhom_frmchonhoachat()
        {
            return get_data("select a.id,a.ten, a.loai,a.nhom from " + s_schemaroot + ".d_dmnhom a order by a.ten");
        }
        public DataSet f_get_d_dmloai_frmchonhoachat()
        {
            return get_data("select a.id,a.ten, a.loai,a.nhom from " + s_schemaroot + ".d_dmloai a order by a.ten");
        }

        public DataSet f_get_xn_hoachat_frmchonhoachat(string v_id_ten)
        {
            return get_data("select a.id, a.mahc, case when a.soluong is null then 0 else a.soluong end as soluong, case when a.soluongqd is null then 0 else a.soluongqd end as soluongqd, case when a.readonly is null then 0 else a.readonly end as readonly from " + s_schemaroot + ".xn_hoachatdm a where a.id_ten=" + v_id_ten + " order by a.mahc");
        }
        public DataSet f_get_xn_khangsinh_frmchonkhangsinh()
        {
            return get_data("select a.id,a.stt,a.ma,a.ten, a.viettat,0 as chon,substr(a.ten,1,1) as abc from " + s_schemaroot + ".xn_khangsinh a order by a.ten");
        }
        public DataSet f_get_xn_bv_khangsinh_frmchonkhangsinh(string v_id_bv_vitrung)
        {
            return get_data("select a.id,a.id_khangsinh from " + s_schemaroot + ".xn_bv_khangsinh a where a.id_bv_vitrung=" + v_id_bv_vitrung + " order by a.id_khangsinh");
        }
        public DataSet f_get_xn_vitrung_frmvitrung()
        {
            string asql = "select a.id,a.stt,a.ma,a.ten,a.gram,a.status,a.viettat, b.ten as gram_ten, c.ten as status_ten, a.readonly,'' as blank from " + s_schemaroot + ".xn_vitrung a left join " + s_schemaroot + ".xn_gram_vt b on a.gram=b.ma left join " + s_schemaroot + ".xn_status_vt c on a.status=b.ma order by a.ten";
            return get_data(asql);
        }

        public decimal get_stt_xn_donvi_hl7
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select distinct stt from " + s_schemaroot + ".xn_donvi_hl7 order by stt asc");
                    while (i < 99999)
                    {
                        i++;
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
        }
        public decimal get_stt_xn_vitrung
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select distinct stt from " + s_schemaroot + ".xn_vitrung order by stt asc");
                    while (i < 99999)
                    {
                        i++;
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
        }
        public decimal get_stt_xn_khangsinh
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select distinct stt from " + s_schemaroot + ".xn_khangsinh order by stt asc");
                    while (i < 99999)
                    {
                        i++;
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
        }
        public decimal get_stt_xn_mauthu
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select distinct stt from " + s_schemaroot + ".xn_mauthu order by stt asc");
                    while (i < 9999)
                    {
                        i++;
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
        }
        public decimal get_stt_xn_vitri
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select distinct stt from " + s_schemaroot + ".xn_vitri order by stt asc");
                    while (i < 9999)
                    {
                        i++;
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
        }
        public decimal get_stt_xn_diadiem
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select distinct stt from " + s_schemaroot + ".xn_diadiem order by stt asc");
                    while (i < 9999)
                    {
                        i++;
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
        }
        public decimal get_stt_xn_so
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select distinct stt from " + s_schemaroot + ".xn_so order by stt asc");
                    while (i < 99)
                    {
                        i++;
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
        }
        public decimal get_stt_xn_treebaocao(string v_id_cha)
        {
            decimal art = 1;
            try
            {
                decimal i = 0;
                DataSet ads = get_data("select distinct stt from " + s_schemaroot + ".xn_treebaocao where id_cha=" + v_id_cha + " order by stt asc");
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
        public decimal get_stt_xn_nhom
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select distinct stt from " + s_schemaroot + ".xn_nhom order by stt asc");
                    while (i < 9999)
                    {
                        i++;
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
        }
        public decimal get_stt_xn_loai
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select distinct stt from " + s_schemaroot + ".xn_loai order by stt asc");
                    while (i < 99999)
                    {
                        i++;
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
        }
        public decimal get_stt_xn_ten
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select distinct stt from " + s_schemaroot + ".xn_ten order by stt asc");
                    while (i < 9999999)
                    {
                        i++;
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
        }
        public decimal get_stt_xn_bv_so
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select distinct stt from " + s_schemaroot + ".xn_bv_so order by stt asc");
                    while (i < 99)
                    {
                        i++;
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
        }
        public decimal get_stt_xn_bv_ten
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select distinct stt from " + s_schemaroot + ".xn_bv_ten order by stt asc");
                    while (i < 9999999)
                    {
                        i++;
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
        }
        public decimal get_stt_xn_bv_chitiet
        {
            get
            {
                decimal art = 1;
                try
                {
                    decimal i = 0;
                    DataSet ads = get_data("select distinct stt from " + s_schemaroot + ".xn_bv_chitiet order by stt asc");
                    while (i < 99999999999)
                    {
                        i+=1;
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
                //return get_xn_capid(7);
            }
        }
        public decimal get_stt_xn_bv_vitrung
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select distinct stt from " + s_schemaroot + ".xn_bv_vitrung order by stt asc");
                    while (i < 99999)
                    {
                        i++;
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
                //return get_xn_capid(16);
            }
        }
        public decimal get_stt_xn_bv_khangsinh
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select distinct stt from " + s_schemaroot + ".xn_bv_khangsinh order by stt asc");
                    while (i < 9999999)
                    {
                        i++;
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
                //return get_xn_capid(25);
            }
        }

        public DataSet f_get_hanhchanh(string v_mabn)
        {
            try
            {
                string asql = "";
                asql = "select a.mabn,a.hoten,to_char(a.ngaysinh,'dd/mm/yyyy') as ngaysinh, a.namsinh, a.sonha,a.thon,a.cholam,b.tentt, c.tenquan, d.tenpxa,a.phai from medibv.btdbn a left join medibv.btdtt b on a.matt=b.matt left join medibv.btdquan c on a.maqu=c.maqu left join medibv.btdpxa d on a.maphuongxa=d.maphuongxa where a.mabn='" + v_mabn + "'";
                asql = asql.Replace("medibv",s_schemaroot);
                return get_data(asql);
            }
            catch
            {
                return null;
            }
        }
        public string Tuoivao(string ngayvao, string ngaysinh)
        {
            string tuoi = "";
            int namht = DateTime.Now.Year;
            int thanght = DateTime.Now.Month;
            int ngayht = DateTime.Now.Day;
            int gioht = DateTime.Now.Hour;

            int nam = int.Parse(ngaysinh.Substring(6, 4));
            int thang = int.Parse(ngaysinh.Substring(3, 2));
            int ngay = int.Parse(ngaysinh.Substring(0, 2));
            int gio = (ngaysinh.Length > 10) ? int.Parse(ngaysinh.Substring(11, 2)) : 0;
            if (ngayvao != "")
            {
                namht = int.Parse(ngayvao.Substring(6, 4));
                thanght = int.Parse(ngayvao.Substring(3, 2));
                ngayht = int.Parse(ngayvao.Substring(0, 2));
                gioht = int.Parse(ngayvao.Substring(11, 2));
            }
            if (nam == namht)
            {
                if (thang == thanght)
                {
                    if (ngay == ngayht) tuoi = "3/" + (gioht - gio);
                    else tuoi = "2/" + (ngayht - ngay);
                }
                else tuoi = "1/" + (thanght - thang);
            }
            else tuoi = "0/" + (namht - nam);
            return tuoi;
        }
        //Laymau
        public DataSet f_get_dslandieutri_frmlaymau(string v_mabn, string v_maql)
        {
            try
            {
                string asql = "", aexp = "";
                asql = "select a.mabn,a.maql,a.makp,b.tenkp,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.nhantu, c.ten as ten_nhantu,a.dentu, d.ten as ten_dentu,a.lanthu,a.chandoan,a.maicd,a.mabs, e.hoten as hotenbs,a.sovaovien,a.mavaovien,a.loaiba,a.userid,a.ngayud from medibv.benhandt a left join medibv.btdkp_bv b on a.makp=b.makp left join medibv.nhantu c on a.nhantu=c.ma left join medibv.dentu d on a.dentu=d.ma left join medibv.dmbs e on a.mabs=e.ma";
                if (aexp.Length > 0)
                {
                    aexp += " and ";
                }
                aexp += "a.mabn='" + v_mabn.Replace("'", "''") + "'";
                if (v_maql != "")
                {
                    if (aexp.Length > 0)
                    {
                        aexp += " and ";
                    }
                    aexp += "a.maql=" + v_maql;
                }
                if (aexp.Length > 0)
                {
                    aexp = " where " + aexp;
                }
                asql += aexp;
                asql = asql.Replace("medibv", s_schemaroot);
                
                return get_data(asql);
            }
            catch
            {
                return null;
            }
        }
        public DataSet f_get_dslaymau_frmlaymau(string v_mabn, string v_maql, string v_id_phieu)
        {
            try
            {
                string asql = "",asql1="";
                asql1 = "select a.id,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.maql,a.id_mauthu, b.ten as ten_mauthu,a.id_tinhtrang, d.ten as ten_tinhtrang,a.id_vitri,e.ten as ten_vitri,a.id_diadiem,f.ten as ten_diadiem,a.ktv, c.hoten as ten_ktv,a.soluong,a.cothai,a.ghichu from medibvmmyy.xn_laymau a left join medibv.xn_mauthu b on a.id_mauthu=b.id left join medibv.xn_ktv c on a.ktv=c.ma left join medibv.xn_tinhtrang d on a.id_tinhtrang=d.id left join medibv.xn_vitri e on a.id_vitri=e.id left join medibv.xn_diadiem f on a.id_diadiem=f.id left join medibv.doituong g on a.madoituong=g.madoituong where a.mabn='" + v_mabn + "'";
                DataSet ads=null,adst=null;
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    asql = asql1.Replace("medibvmmyy", r["schemaname"].ToString());
                    asql = asql.Replace("medibv", s_schemaroot);
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

        //Phieuxetnghiem
        public DataSet f_get_dslandieutri_frmphieuxetnghiem(string v_mabn, string v_maql)
        {
            try
            {
                string asql = "", aexp = "";
                asql = "select a.mabn,a.maql,a.makp,b.tenkp,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.nhantu, c.ten as ten_nhantu,a.dentu, d.ten as ten_dentu,a.lanthu,a.chandoan,a.maicd,a.mabs, e.hoten as hotenbs,a.sovaovien,a.mavaovien,a.loaiba,a.userid,a.ngayud from medibv.benhandt a left join medibv.btdkp_bv b on a.makp=b.makp left join medibv.nhantu c on a.nhantu=c.ma left join medibv.dentu d on a.dentu=d.ma left join medibv.dmbs e on a.mabs=e.ma";
                if (aexp.Length > 0)
                {
                    aexp += " and ";
                }
                aexp += "a.mabn='" + v_mabn.Replace("'", "''") + "'";
                if (v_maql != "")
                {
                    if (aexp.Length > 0)
                    {
                        aexp += " and ";
                    }
                    aexp += "a.maql=" + v_maql;
                }
                if (aexp.Length > 0)
                {
                    aexp = " where " + aexp;
                }
                asql += aexp;
                asql = asql.Replace("medibv", s_schemaroot);

                return get_data(asql);
            }
            catch
            {
                return null;
            }
        }
        public DataSet f_get_dslaymau_frmphieuxetnghiem(string v_mabn, string v_maql, string v_id_phieu)
        {
            try
            {
                string asql = "", asql1 = "";
                asql1 = "select a.id,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.maql,a.id_mauthu, b.ten as ten_mauthu,a.id_tinhtrang, d.ten as ten_tinhtrang,a.id_vitri,e.ten as ten_vitri,a.id_diadiem,f.ten as ten_diadiem,a.ktv, c.hoten as ten_ktv,a.soluong,a.cothai,a.ghichu from medibvmmyy.xn_laymau a left join medibv.xn_mauthu b on a.id_mauthu=b.id left join medibv.xn_ktv c on a.ktv=c.ma left join medibv.xn_tinhtrang d on a.id_tinhtrang=d.id left join medibv.xn_vitri e on a.id_vitri=e.id left join medibv.xn_diadiem f on a.id_diadiem=f.id left join medibv.doituong g on a.madoituong=g.madoituong where a.mabn='" + v_mabn + "'";
                DataSet ads = null, adst = null;
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    asql = asql1.Replace("medibvmmyy", r["schemaname"].ToString());
                    asql = asql.Replace("medibv", s_schemaroot);
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
        public DataSet f_get_dsphieuxetnghiem_frmphieuxetnghiem(string v_mabn, string v_maql, string v_id_phieu)
        {
            try
            {
                string asql = "", asql1 = "";
                asql1 = "select a.id,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.maql,a.sophieu,b.makp,b.tenkp,c.ma as mabs,c.hoten as tenbs, d.ma as mabsdoc,d.hoten as tenbsdoc,e.ma as ktv,e.hoten as tenktv, f.doituong, g.ten as tinhtrang, h.ten as loaibn, a.nhanxet, a.ketluan, a.denghi, a.ghichu from medibvmmyy.xn_phieu a left join medibv.btdkp_bv b on a.makp=b.makp left join medibv.dmbs c on a.mabs=c.ma left join medibv.dmbs d on a.mabsdoc=d.ma left join medibv.xn_ktv e on a.ktv=e.ma left join medibv.doituong f on a.madoituong=f.madoituong left join medibv.xn_tinhtrang g on a.tinhtrang=g.id left join medibv.v_loaibn h on a.loaibn=h.id where a.mabn='" + v_mabn + "'";
                DataSet ads = null, adst = null;
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    asql = asql1.Replace("medibvmmyy", r["schemaname"].ToString());
                    asql = asql.Replace("medibv", s_schemaroot);
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
        public DataSet f_get_xn_bv_so_frmphieuxetnghiem(string v_sort)
        {
            if (v_sort == "")
            {
                v_sort = "ten";
            }
            string asql = "select c.id,c.stt,c.ma,c.ten,c.viettat from medibv.xn_bv_chitiet a inner join medibv.xn_bv_ten b on a.id_bv_ten=b.id inner join medibv.xn_bv_so c on b.id_bv_so=c.id inner join medibv.xn_ten d on a.id_ten=d.id group by c.id,c.stt,c.ma,c.ten,c.viettat order by c." + v_sort;
            asql = asql.Replace("medibv.", s_schemaroot + ".");
            return get_data(asql);
        }
        public DataSet f_get_xn_bv_chitiet_frmphieuxetnghiem()
        {
            string asql = "select c.id as id_bv_so, b.id as id_bv_ten, b.stt as stt_bv_ten, b.ma as ma_bv_ten, b.ten as ten_bv_ten, b.viettat as viettat_bv_ten,a.id, a.stt, a.id_ten, d.ma, d.ten, a.viettat, e.ten as donvi, d.csbt_nu, d.csbt_nam, d.maxcsbt_nu, d.maxcsbt_nam,d.mincsbt_nu, d.mincsbt_nam from medibv.xn_bv_chitiet a inner join medibv.xn_bv_ten b on a.id_bv_ten=b.id inner join medibv.xn_bv_so c on b.id_bv_so=c.id inner join medibv.xn_ten d on a.id_ten=d.id inner join medibv.xn_donvi e on d.donvi=e.id";
            asql = asql.Replace("medibv.",s_schemaroot+".");
            return get_data(asql);
        }
        
        //Danh muc
        public DataSet f_get_xn_tinhtrang()
        {
            string asql = "select a.id,a.stt,a.ma,a.ten, a.readonly from " + s_schemaroot + ".xn_tinhtrang a order by a.stt";
            return get_data(asql);
        }
        public DataSet f_get_v_loaibn()
        {
            try
            {
                string asql = "select a.id,a.ten from " + s_schemaroot + ".v_loaibn a order by a.id";
                DataSet ads = get_data(asql);
                if (ads.Tables[0].Rows.Count <= 0)
                {
                    execute_data("insert into " + s_schemaroot + ".v_loaibn (id,ten) values(0,'Tiếp đón')");
                    execute_data("insert into " + s_schemaroot + ".v_loaibn (id,ten) values(1,'Nội trú')");
                    execute_data("insert into " + s_schemaroot + ".v_loaibn (id,ten) values(2,'Ngoại trú')");
                    execute_data("insert into " + s_schemaroot + ".v_loaibn (id,ten) values(3,'Phòng khám')");
                    execute_data("insert into " + s_schemaroot + ".v_loaibn (id,ten) values(4,'Phòng lưu')");
                    ads = get_data(asql);
                }
                return ads;
            }
            catch
            {
                return null;
            }
        }
        public DataSet f_get_dmphai()
        {
            try
            {
                string asql = "select a.ma as id,a.ten from " + s_schemaroot + ".dmphai a order by a.ma desc";
                DataSet ads = get_data(asql);
                if (ads.Tables[0].Rows.Count <= 0)
                {
                    execute_data("insert into " + s_schemaroot + ".dmphai (ma,ten) values(1,'Nữ')");
                    execute_data("insert into " + s_schemaroot + ".dmphai (ma,ten) values(0,'Nam')");
                    ads = get_data(asql);
                }
                return ads;
            }
            catch
            {
                return null;
            }
        }
        public DataSet f_get_v_tenloaivp()
        {
            try
            {
                string asql = "select a.ma as id,a.ten from " + s_schemaroot + ".v_tenloaivp a order by a.ten";
                DataSet ads = get_data(asql);
                if (ads.Tables[0].Rows.Count <=0)
                {
                    execute_data("insert into " + s_schemaroot + ".v_tenloaivp (ma,ten) values(1,'Thường')");
                    ads = get_data(asql);
                }
                return ads;
            }
            catch
            {
                return null;
            }
        }
        public DataSet f_get_xn_tinhtrang_frmlaymau()
        {
            try
            {
                string asql = "select a.id,a.ten from " + s_schemaroot + ".xn_tinhtrang a order by a.ten";
                DataSet ads = get_data(asql);
                if (ads.Tables[0].Rows.Count <= 0)
                {
                    execute_data("insert into " + s_schemaroot + ".xn_tinhtrang (id,stt,ma,ten,readonly) values(1,1,'1','Thường',0)");
                    execute_data("insert into " + s_schemaroot + ".xn_tinhtrang (id,stt,ma,ten,readonly) values(1,1,'2','Cấp cứu',0)");
                    ads = get_data(asql);
                }
                return ads;
            }
            catch
            {
                return null;
            }
        }
        public DataSet f_get_doituong()
        {
            string asql = "select a.madoituong,a.doituong from " + s_schemaroot + ".doituong a order by a.madoituong";
            return get_data(asql);
        }
        public DataSet f_get_xn_viettatkq()
        {
            string asql = "select a.stt, a.ma, a.ten,a.readonly from " + s_schemaroot + ".xn_viettatkq a order by a.stt";
            return get_data(asql);
        }
        public DataSet f_get_xn_viettat()
        {
            string asql = "select a.stt, a.ma, a.ten,a.readonly from " + s_schemaroot + ".xn_viettat a order by a.stt";
            return get_data(asql);
        }

        public string get_nam(string m_mabn)
        {
            return get_data("select nam from medibv.btdbn where mabn='" + m_mabn + "'").Tables[0].Rows[0]["nam"].ToString().Trim();
        }
        public DataSet get_data_nam_dec(string nam, string str)
        {
            if (m_ds != null)
            {
                m_ds.Dispose();
                m_ds = null;
            }
            m_ds = new DataSet();
            try
            {
                nam = f_Sort_String(nam);
            }
            catch
            {
            }
            m_ds = new DataSet();
            int i = nam.Trim().Length;
            bool bFound = false;
            string mmyy = "", sql = "";
            while (i > 0 && !bFound)
            {
                mmyy = nam.Substring(i - 5, 4);
                if (bMmyy(mmyy))
                {
                    sql = str.Replace("medibvmmyy", user + mmyy);
                    m_ds = get_data(sql);
                    bFound = m_ds.Tables[0].Rows.Count > 0;
                }
                i -= 5;
            }
            return m_ds;
        }
        public DataSet get_data_nam_New(string nam, string str)
        { 
            DataSet tmp = new DataSet();
            DataSet tmp1 = new DataSet();
            try
            {

                try
                {
                    nam = f_Sort_String(nam);
                }
                catch
                {
                }
                int i = 0;
                bool be = true;
                string mmyy = "", sql = "";
                while (i < nam.Trim().Length)
                {
                    mmyy = nam.Substring(i, 4);
                    tmp1 = new DataSet();
                    if (bMmyy(mmyy))
                    {
                        sql = str.Replace("medibvmmyy", user + mmyy);
                        if (be)
                        {
                            tmp = get_data(sql);
                            if (tmp != null)
                                be = false;
                        }
                        else
                        {
                            tmp1 = get_data(sql);
                            if (tmp1!=null)
                                tmp.Merge(tmp1);
                        }
                    }
                    i += 5;
                }
            }
            catch
            { }
            return tmp;
        }
        private string f_Sort_String(string s)
        {
            string[] arr = s.Split('+');
            string s1 = "", s2 = "", s_return = "";
            try
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].ToString() != "")
                    {
                        s1 = arr[i].ToString().Substring(2) + arr[i].Substring(0, 2) + "+";
                        if (s2.IndexOf(s1) == -1)
                        {
                            s2 += s1;
                        }
                    }
                }
            }
            catch
            {
                s2 = "";
            }
            if (s2 != "")
            {
                string[] arr1 = s2.Split('+');

                try
                {
                    Array.Sort(arr1);
                    for (int i = 0; i < arr1.Length; i++)
                    {
                        if (arr1[i].ToString() != "")
                        {
                            s_return += arr1[i].ToString().Substring(2) + arr1[i].ToString().Substring(0, 2) + "+";
                        }
                    }
                }
                catch
                {
                    s_return = "";
                }
            }
            return s_return;
        }
        public string f_Get_Mmyy_Namvien(string mabn)
        {
            DataSet tmp = new DataSet();
            DateTime dt1, dt2;
            int y1, y2, m1, m2;
            int itu, iden;
            string sMmyy = "", mmyy, stu = "", sden = "", sql = "";
            sql = "select to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,case when b.ngay is null then to_char(now(),'dd/mm/yyyy hh24:mi') else to_char(b.ngay,'dd/mm/yyyy hh24:mi') end as ngayra from " + user + ".benhandt a left join " + user + ".xuatvien b on a.maql=b.maql where a.mabn='" + mabn + "'";

            foreach (DataRow r in get_data(sql).Tables[0].Rows)
            {
                stu = r["ngayvao"].ToString();
                sden = r["ngayra"].ToString();
                dt1 = StringToDate(stu);
                dt2 = StringToDate(sden);
                y1 = dt1.Year;
                m1 = dt1.Month;
                y2 = dt2.Year;
                m2 = dt2.Month;
                for (int i = y1; i <= y2; i++)
                {
                    itu = (i == y1) ? m1 : 1;
                    iden = (i == y2) ? m2 : 12;
                    for (int j = itu; j <= iden; j++)
                    {
                        mmyy = j.ToString().PadLeft(2, '0') + i.ToString().Substring(2, 2);
                        if (bMmyy(mmyy))
                        {
                            if (sMmyy.IndexOf(mmyy + "+") == -1) sMmyy += mmyy + "+";
                        }
                    }
                }
            }
            return sMmyy;
        }
        public DataRow getrowbyid(DataTable dt, string exp)
        {
            try
            {
                DataRow[] r = dt.Select(exp);
                return r[0];
            }
            catch { return null; }
        }
        #endregion GET DATA TABLE

        #region DELETE DATA TABLE
        
        public bool del_xn_dlogin(string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_xn_dlogin(v_id)==0)
                {
                    execute_data("delete from "+s_schemaroot+".xn_dlogin where id="+v_id);
                    art = (get_data("select id from "+s_schemaroot+".xn_dlogin where id="+v_id).Tables[0].Rows.Count==0);
                    if (art)
                    {
                        execute_data("delete from " + s_schemaroot + ".xn_phanquyen where userid=" + v_id);
                    }
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_xn_nhomdlogin(string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_xn_nhomdlogin(v_id) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".xn_nhomdlogin where id=" + v_id +" and id not in (select disctinct id_nhom from "+s_schemaroot+".xn_dlogin where id_nhom = "+v_id+")");
                    art = (get_data("select id from " + s_schemaroot + ".xn_nhomdlogin where id=" + v_id).Tables[0].Rows.Count == 0);
                    if (art)
                    {
                        execute_data("delete from " + s_schemaroot + ".xn_phanquyennhom where id_nhom=" + v_id);
                    }
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public void f_del_xn_phanquyen(string v_userid)
        {
            execute_data("delete from " + s_schemaroot + ".xn_phanquyen where userid=" + v_userid);
        }
        public void f_del_xn_phanquyennhom(string v_id_nhom)
        {
            execute_data("delete from " + s_schemaroot + ".xn_phanquyennhom where id_nhom=" + v_id_nhom);
        }
        public bool del_xn_donvi(string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_xn_donvi(v_id) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".xn_donvi where id=" + v_id);
                    art = (get_data("select id from " + s_schemaroot + ".xn_donvi where id=" + v_id).Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_xn_donvi_hl7(string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_xn_donvi_hl7(v_id) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".xn_donvi_hl7 where id=" + v_id);
                    art = (get_data("select id from " + s_schemaroot + ".xn_donvi_hl7 where id=" + v_id).Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_xn_gram_vt(string v_ma)
        {
            bool art = false;
            try
            {
                if (dadung_xn_gram_vt(v_ma) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".xn_gram_vt where ma='" + v_ma.Replace("'","''") + "'");
                    art = (get_data("select id from " + s_schemaroot + ".xn_gram_vt where ma='" + v_ma.Replace("'","''")+"'").Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_xn_status_vt(string v_ma)
        {
            bool art = false;
            try
            {
                if (dadung_xn_status_vt(v_ma) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".xn_status_vt where ma='" + v_ma.Replace("'", "''") + "'");
                    art = (get_data("select id from " + s_schemaroot + ".xn_status_vt where ma='" + v_ma.Replace("'", "''") + "'").Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_xn_vitrung(string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_xn_vitrung(v_id) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".xn_vitrung where id=" + v_id);
                    art = (get_data("select id from " + s_schemaroot + ".xn_vitrung where id=" + v_id).Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_xn_khangsinh(string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_xn_khangsinh(v_id) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".xn_khangsinh where id=" + v_id);
                    art = (get_data("select id from " + s_schemaroot + ".xn_khangsinh where id=" + v_id).Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_xn_mauthu(string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_xn_mauthu(v_id) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".xn_mauthu where id=" + v_id);
                    art = (get_data("select id from " + s_schemaroot + ".xn_mauthu where id=" + v_id).Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_xn_hoachat(string v_maxn, int v_mahc)
        {
            bool art = false;
            try
            {
                if (dadung_xn_hoachat(v_maxn) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".xn_hoachatdm where id_ten=" + v_maxn + " and mahc=" + v_mahc);
                    art = (get_data("select id_ten from " + s_schemaroot + ".xn_hoachatdm where id_ten=" + v_maxn + " and mahc=" + v_mahc).Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public DataSet f_get_xn_donvi_dinhmuc(string v_id, string v_stt, string v_ma, string v_ten, string v_anh, string v_readonly)
        {
            string asql = "", aexp = "";
            asql = "select a.id, a.stt, a.ma, a.ten, a.anh, a.readonly, '' as blank from " + s_schemaroot + ".xn_donvi_dinhmuc a";
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
            if (v_anh != "")
            {
                if (aexp != "")
                {
                    aexp += " and ";
                }
                aexp += "a.anh='" + v_anh.Replace("'", "''") + "'";
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
        public decimal get_stt_xn_donvi_dinhmuc
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select distinct stt from " + s_schemaroot + ".xn_donvi_dinhmuc order by stt asc");
                    while (i < 99999)
                    {
                        i++;
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
        }
        public decimal get_id_xn_donvi_dinhmuc
        {
            get
            {
                decimal art = 1;
                try
                {
                    int i = 0;
                    DataSet ads = get_data("select id from " + s_schemaroot + ".xn_donvi_dinhmuc order by id asc");
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
        public bool upd_xn_donvi_dinhmuc(decimal v_id, decimal v_stt, string v_ma, string v_ten, string v_anh, decimal v_readonly)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_donvi_dinhmuc set stt=:v_stt, ma=:v_ma,ten=:v_ten,anh=:v_anh, readonly=:v_readonly where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_ma", NpgsqlDbType.Text, 30).Value = v_ma;
            m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 100).Value = v_ten;
            m_command.Parameters.Add("v_anh", NpgsqlDbType.Text, 100).Value = v_anh;
            m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;
            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_donvi_dinhmuc(id,stt,ma,ten,anh,readonly) values (:v_id,:v_stt,:v_ma,:v_ten,:v_anh,:v_readonly)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Text, 30).Value = v_ma;
                    m_command.Parameters.Add("v_ten", NpgsqlDbType.Text, 100).Value = v_ten;
                    m_command.Parameters.Add("v_anh", NpgsqlDbType.Text, 100).Value = v_anh;
                    m_command.Parameters.Add("v_readonly", NpgsqlDbType.Numeric).Value = v_readonly;
                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_donvi_dinhmuc");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public int dadung_xn_donvi_dinhmuc(string v_id)
        {
            try
            {
                if (get_data("select readonly from " + s_schemaroot + ".xn_donvi_dinhmuc where id=" + v_id + " and readonly=1").Tables[0].Rows.Count > 0) return -1;
                //if (get_data("select id_hl7 from " + s_schemaroot + ".xn_donvi where id_hl7=" + v_id + "").Tables[0].Rows.Count > 0) return 1;
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public bool del_xn_vitri(string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_xn_vitri(v_id) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".xn_vitri where id=" + v_id);
                    art = (get_data("select id from " + s_schemaroot + ".xn_vitri where id=" + v_id).Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_xn_diadiem(string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_xn_diadiem(v_id) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".xn_diadiem where id=" + v_id);
                    art = (get_data("select id from " + s_schemaroot + ".xn_diadiem where id=" + v_id).Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_xn_ktv(string v_ma)
        {
            bool art = false;
            try
            {
                if (dadung_xn_ktv(v_ma) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".xn_ktv where ma='" + v_ma.Replace("'", "''") + "'");
                    art = (get_data("select ma from " + s_schemaroot + ".xn_ktv where ma='" + v_ma.Replace("'", "''") + "'").Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_xn_so(string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_xn_so(v_id) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".xn_so where id=" + v_id);
                    art = (get_data("select id from " + s_schemaroot + ".xn_so where id=" + v_id).Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_xn_treebaocao(string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_xn_treebaocao(v_id) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".xn_treebaocao where id=" + v_id);
                    art = (get_data("select id from " + s_schemaroot + ".xn_treebaocao where id=" + v_id).Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_xn_nhom(string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_xn_nhom(v_id) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".xn_nhom where id=" + v_id);
                    art = (get_data("select id from " + s_schemaroot + ".xn_nhom where id=" + v_id).Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_xn_loai(string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_xn_loai(v_id) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".xn_loai where id=" + v_id);
                    art = (get_data("select id from " + s_schemaroot + ".xn_loai where id=" + v_id).Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_xn_ten(string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_xn_ten(v_id) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".xn_ten where id=" + v_id);
                    art = (get_data("select id from " + s_schemaroot + ".xn_ten where id=" + v_id).Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_xn_bv_so(string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_xn_bv_so(v_id) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".xn_bv_so where id=" + v_id);
                    art = (get_data("select id from " + s_schemaroot + ".xn_bv_so where id=" + v_id).Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_xn_bv_ten(string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_xn_bv_ten(v_id) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".xn_bv_ten where id=" + v_id);
                    art = (get_data("select id from " + s_schemaroot + ".xn_bv_ten where id=" + v_id).Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_xn_bv_chitiet(string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_xn_bv_chitiet(v_id) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".xn_bv_chitiet where id=" + v_id);
                    art = (get_data("select id from " + s_schemaroot + ".xn_bv_chitiet where id=" + v_id).Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_xn_bv_vitrung(string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_xn_so(v_id) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".xn_bv_vitrung where id=" + v_id);
                    art = (get_data("select id from " + s_schemaroot + ".xn_bv_vitrung where id=" + v_id).Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_xn_bv_khangsinh(string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_xn_bv_khangsinh(v_id) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".xn_bv_khangsinh where id=" + v_id);
                    art = (get_data("select id from " + s_schemaroot + ".xn_bv_khangsinh where id=" + v_id).Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_xn_bv_hoachat(string v_id)
        {
            bool art = false;
            try
            {
                if (dadung_xn_hoachat(v_id) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".xn_hoachat where id=" + v_id);
                    art = (get_data("select id from " + s_schemaroot + ".xn_hoachat where id=" + v_id).Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_xn_sdmauthu(string v_id_ten, string v_id_mauthu)
        {
            bool art = false;
            try
            {
                if (dadung_xn_sdmauthu(v_id_ten,v_id_mauthu) == 0)
                {
                    execute_data("delete from " + s_schemaroot + ".xn_sdmauthu where id_ten=" + v_id_ten + " and id_mauthu=" + v_id_mauthu);
                    art = (get_data("select id_ten from " + s_schemaroot + ".xn_sdmauthu where id_ten=" + v_id_ten + " and id_mauthu=" + v_id_mauthu).Tables[0].Rows.Count == 0);
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public void f_copy_bokhangsinh(string v_id_bv_vitrung_source, string v_id_vitrung_dest, string v_id_bv_vitrung_dest)
        {
            try
            {
                decimal aid_bv_vitrung = get_id_xn_bv_vitrung, astt = f_get_stt_xn_bv_vitrung(),aid_khangsinh=0;
                execute_data("insert into " + s_schemaroot + ".xn_bv_vitrung (id,id_vitrung,stt,ma,ten,khangsinh,gram,status,id_giavp,readonly,viettat,tenboks) select " + aid_bv_vitrung.ToString() + "," + v_id_vitrung_dest + "," + astt.ToString() + ",ma,ten,'',gram,status,0,0,viettat,'Bộ số 1' from " + s_schemaroot + ".xn_vitrung where id=" + v_id_vitrung_dest + "");
                foreach (DataRow r in get_data("select id from " + s_schemaroot + ".xn_bv_khangsinh where id_bv_vitrung = " + v_id_bv_vitrung_source).Tables[0].Rows)
                {
                    aid_khangsinh = get_id_xn_bv_khangsinh;
                    execute_data("insert into " + s_schemaroot + ".xn_bv_khangsinh(id,id_bv_vitrung,stt,id_khangsinh,maxr,mins,readonly,hamluong) select " + aid_khangsinh.ToString() + "," + aid_bv_vitrung + "," + astt.ToString() + ",id_khangsinh, maxr,mins,readonly,hamluong from " + s_schemaroot + ".xn_bv_khangsinh where id=" + r["id"].ToString() + "");
                }
            }
            catch
            {
            }
        }
        public void f_copy_bothongso(string v_id_bv_ten_source, string v_id_bv_ten_dest)
        {
            try
            {
                decimal aid_bv_chitiet = 0;
                foreach (DataRow r in get_data("select id, id_ten from " + s_schemaroot + ".xn_bv_chitiet where id_bv_ten = " + v_id_bv_ten_source).Tables[0].Rows)
                {
                    aid_bv_chitiet = get_id_xn_bv_chitiet;
                    execute_data("insert into " + s_schemaroot + ".xn_bv_chitiet(id,id_bv_ten,id_ten,stt,tieuban,viettat,readonly) select " + aid_bv_chitiet.ToString() + "," + v_id_bv_ten_dest + ",id_ten,stt,tieuban,viettat,readonly from " + s_schemaroot + ".xn_bv_chitiet where id=" + r["id"].ToString() + " and id_ten not in (select id_ten from " + s_schemaroot + ".xn_bv_chitiet where id_bv_ten=" + v_id_bv_ten_dest + ")");
                }
            }
            catch
            {
            }
        }
        public void f_copy_sdmauthu(string v_id_ten_source, string v_id_ten_dest)
        {
            try
            {
                execute_data("insert into " + s_schemaroot + ".xn_sdmauthu(id_ten,id_mauthu,soluong,readonly) select " + v_id_ten_dest + ",id_mauthu,soluong,0 from " + s_schemaroot + ".xn_sdkhangsinh where id_ten=" + v_id_ten_source + "");
            }
            catch
            {
            }
        }
        public void f_copy_hoachat(string v_id_ten_source, string v_id_ten_dest)
        {
            try
            {
                decimal aid=0;
                foreach (DataRow r in get_data("select mahc, max(soluong) as soluong, max(soluongqd) as soluongqd from (select distinct mahc, soluong,soluongqd from " + s_schemaroot + ".xn_hoachat where id_ten = " + v_id_ten_source + " and mahc not in (select distinct mahc from " + s_schemaroot + ".xn_hoachat where id_ten=" + v_id_ten_dest + ")) a group by mahc").Tables[0].Rows)
                {
                    try
                    {
                        aid = get_id_xn_hoachat;
                        execute_data("insert into " + s_schemaroot + ".xn_hoachat(id,id_ten,mahc,soluong,soluongqd,readonly) values(" + aid.ToString() + "," + v_id_ten_dest + "," + r["mahc"].ToString() + "," + r["soluong"].ToString() + "," + r["soluongqd"].ToString() + ",0)");
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
        public void f_copy_treebaocao(string v_id_copy, string v_id_cha_dest)
        {
            try
            {
                decimal aid = get_id_xn_treebaocao, astt = get_stt_xn_treebaocao(v_id_cha_dest);
                execute_data("insert into " + s_schemaroot + ".xn_treebaocao(id,id_cha,stt,ten,asql,tenreport,readonly) select " + aid.ToString() + "," + v_id_cha_dest + "," + astt.ToString() + ",ten,asql,tenreport,readonly from " + s_schemaroot + ".xn_treebaocao where id=" + v_id_copy + "");
            }
            catch
            {
            }
        }
        public void f_copy_phanquyen(string v_id_copy, string v_loai_copy, string v_id_dest, string v_loai_dest)
        {
            try
            {
                if (v_loai_dest == "U")
                {
                    execute_data("delete from " + s_schemaroot + ".xn_phanquyen where userid=" + v_id_dest + " and userid <>" + v_id_copy);
                }
                else
                {
                    execute_data("delete from " + s_schemaroot + ".xn_phanquyennhom where id_nhom=" + v_id_dest + " and id_nhom <>" + v_id_copy);
                }
                if (v_loai_dest == "N")
                {
                    if (v_loai_copy == "U")
                    {
                        execute_data("insert into " + s_schemaroot + ".xn_phanquyennhom(id_nhom,menuname,chon,chitiet) select " + v_id_dest.ToString() + ",menuname,chon,chitiet from " + s_schemaroot + ".xn_phanquyen where userid=" + v_id_copy + "");
                    }
                    else
                    {
                        execute_data("insert into " + s_schemaroot + ".xn_phanquyennhom(id_nhom,menuname,chon,chitiet) select " + v_id_dest.ToString() + ",menuname,chon,chitiet from " + s_schemaroot + ".xn_phanquyennhom where id_nhom=" + v_id_copy + "");
                    }
                }
                else
                {
                    if (v_loai_copy == "U")
                    {
                        execute_data("insert into " + s_schemaroot + ".xn_phanquyen(userid,menuname,chon,chitiet,id_bv_so) select " + v_id_dest.ToString() + ",menuname,chon,chitiet,id_bv_so from " + s_schemaroot + ".xn_phanquyen where userid=" + v_id_copy + "");
                    }
                    else
                    {
                        execute_data("insert into " + s_schemaroot + ".xn_phanquyen(userid,menuname,chon,chitiet,id_bv_so) select " + v_id_dest.ToString() + ",menuname,chon,chitiet,id_bv_so from " + s_schemaroot + ".xn_phanquyennhom where id_nhom=" + v_id_copy + "");
                    }
                }
            }
            catch
            {
            }
        }
        public bool del_xn_dmmenu_phanquyen(string v_menuten)
        {
            bool art = false;
            try
            {
                execute_data("delete from " + s_schemaroot + ".xn_dmmenu where menuten='" + v_menuten+"'");
                execute_data("delete from " + s_schemaroot + ".xn_phanquyen where menuten='" + v_menuten + "'");
                execute_data("delete from " + s_schemaroot + ".xn_phanquyennhom where menuten='" + v_menuten + "'");
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_xn_viettatkq(string v_ma)
        {
            bool art = false;
            try
            {
                execute_data("delete from " + s_schemaroot + ".xn_viettatkq where ma='" + v_ma.Replace("'", "''") + "' and readonly!=1");
                art = (get_data("select id from " + s_schemaroot + ".xn_viettatkq where ma='" + v_ma.Replace("'", "''") + "'").Tables[0].Rows.Count == 0);
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_xn_viettat(string v_ma)
        {
            bool art = false;
            try
            {
                execute_data("delete from " + s_schemaroot + ".xn_viettat where ma='" + v_ma.Replace("'", "''") + "' and readonly!=1");
                art = (get_data("select id from " + s_schemaroot + ".xn_viettat where ma='" + v_ma.Replace("'", "''") + "'").Tables[0].Rows.Count == 0);
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_xn_viettatkq()
        {
            bool art = false;
            try
            {
                execute_data("delete from " + s_schemaroot + ".xn_viettatkq where readonly!=1");
                art = (get_data("select id from " + s_schemaroot + ".xn_viettatkq").Tables[0].Rows.Count == 0);
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_xn_viettat()
        {
            bool art = false;
            try
            {
                execute_data("delete from " + s_schemaroot + ".xn_viettat where readonly!=1");
                art = (get_data("select id from " + s_schemaroot + ".xn_viettat").Tables[0].Rows.Count == 0);
            }
            catch
            {
                art = false;
            }
            return art;
        }
        public bool del_xn_error()
        {
            bool art = false;
            try
            {
                execute_data("delete from " + s_schemaroot + ".xn_error");
                foreach (DataRow r in get_shemaname_mmyy().Tables[0].Rows)
                {
                    execute_data("delete from " + r["schemaname"].ToString() + ".xn_error");
                }
            }
            catch
            {
                art = false;
            }
            return art;
        }
        #endregion DELETE DATA TABLE

        #region GET DATA BÁO CÁO
        public DataSet get_data_mmyy(string tu, string den, string str, bool khoangcach)
        {
            DataSet tmp = new DataSet();
            DataSet tmp1 = new DataSet();
            DateTime dt1 = (khoangcach) ? StringToDate(tu).AddDays(-s_o_khoangcachngaylamviec) : StringToDate(tu);
            DateTime dt2 = (khoangcach) ? StringToDate(den).AddDays(s_o_khoangcachngaylamviec) : StringToDate(den);
            int y1 = dt1.Year, m1 = dt1.Month;
            int y2 = dt2.Year, m2 = dt2.Month;
            int itu, iden;
            string mmyy = "", sql = "";
            bool be = true;
            for (int i = y1; i <= y2; i++)
            {
                tmp1 = new DataSet();
                itu = (i == y1) ? m1 : 1;
                iden = (i == y2) ? m2 : 12;
                for (int j = itu; j <= iden; j++)
                {
                    mmyy = j.ToString().PadLeft(2, '0') + i.ToString().Substring(2, 2);
                    if (bMmyy(mmyy))
                    {
                        sql = str.Replace("medibvmmyy.", m_db_schemaroot + mmyy + ".");
                        if (be)
                        {
                            tmp = get_data(sql);
                            if (tmp != null)
                                be = false;
                        }
                        else
                        {
                            tmp1 = get_data(sql);
                            if (tmp1!=null)
                                tmp.Merge(tmp1);
                        }
                    }
                }
            }
            return tmp;
        }
        public DataSet get_data_mmyy(string v_mmyy, string v_sql)
        {
            if (v_mmyy == "")
            {
                v_mmyy = s_curmmyy;
            }
            v_sql = v_sql.Replace("medibvmmyy.", m_db_schemaroot + v_mmyy + ".");
            v_sql = v_sql.Replace("medibv.", m_db_schemaroot + ".");
            return get_data(v_sql);
        }
        public DataSet get_data_mmyy(string v_mmyy, string v_sql, int v_limit)
        {
            if (v_mmyy == "")
            {
                v_mmyy = s_curmmyy;
            }
            v_sql = v_sql.Replace("medibvmmyy.", m_db_schemaroot + v_mmyy + ".");
            v_sql = v_sql.Replace("medibv.", m_db_schemaroot + ".");
            if (v_sql.IndexOf("limit") < 0 && v_limit > 0)
            {
                v_sql += " limit " + v_limit.ToString();
            }
            return get_data(v_sql);
        }

        public void execute_data_mmyy(string tu, string den,string str,bool khoangcach)
        {
            DateTime dt1 = (khoangcach) ? StringToDate(tu).AddDays(-s_o_khoangcachngaylamviec) : StringToDate(tu);
            DateTime dt2 = (khoangcach) ? StringToDate(den).AddDays(s_o_khoangcachngaylamviec) : StringToDate(den);
            int y1 = dt1.Year, m1 = dt1.Month;
            int y2 = dt2.Year, m2 = dt2.Month;
            int itu, iden;
            string mmyy = "", sql = "";
            for (int i = y1; i <= y2; i++)
            {
                itu = (i == y1) ? m1 : 1;
                iden = (i == y2) ? m2 : 12;
                for (int j = itu; j <= iden; j++)
                {
                    mmyy = j.ToString().PadLeft(2, '0') + i.ToString().Substring(2, 2);
                    if (bMmyy(mmyy))
                    {
                        sql = str.Replace("medibvmmyy", user + mmyy);
                        execute_data(sql);
                    }
                }
            }
        }
        #endregion

        #region KẾT XUẤT EXCEL

        public string f_export_excel(DataTable dset, string tenfile)
        {
            try
            {

                string dirPath = AppDomain.CurrentDomain.BaseDirectory + "Excel";
                string filePath = dirPath + "\\" + tenfile + ".xls";
                if (!System.IO.Directory.Exists(dirPath)) System.IO.Directory.CreateDirectory(dirPath);
                System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, false, System.Text.Encoding.Unicode);
                string astr = "";
                astr = "<Table>";//"<Table border=1>";
                astr = astr + "<tr>";
                for (int i = 0; i < dset.Columns.Count; i++)
                {
                    astr = astr + "<th>";
                    astr = astr + dset.Columns[i].ColumnName;
                    astr = astr + "</th>";
                }
                astr = astr + "</tr>";
                sw.Write(astr);
                for (int i = 0; i < dset.Rows.Count; i++)
                {
                    astr = "<tr>";
                    for (int j = 0; j < dset.Columns.Count; j++)
                    {
                        astr = astr + "<td>";
                        astr = astr + dset.Rows[i][j].ToString();
                        astr = astr + "</td>";
                    }
                    astr = astr + "</tr>";
                    sw.Write(astr);
                }
                astr = "</Table>";
                sw.Write(astr);
                sw.Close();
                return filePath;
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
        public string getIndex(int i)
        {
            string[] map = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
							   "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ",
							   "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ",
							   "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ",
							   "DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", "DI", "DJ", "DK", "DL", "DM", "DN", "DO", "DP", "DQ", "DR", "DS", "DT", "DU", "DV", "DW", "DX", "DY", "DZ",
							   "EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", "EI", "EJ", "EK", "EL", "EM", "EN", "EO", "EP", "EQ", "ER", "ES", "ET", "EU", "EV", "EW", "EX", "EY", "EZ",
							   "FA", "FB", "FC", "FD", "FE", "FF", "FG", "FH", "FI", "FJ", "FK", "FL", "FM", "FN", "FO", "FP", "FQ", "FR", "FS", "FT", "FU", "FV", "FW", "FX", "FY", "FZ",
							   "GA", "GB", "GC", "GD", "GE", "GF", "GG", "GH", "GI", "GJ", "GK", "GL", "GM", "GN", "GO", "GP", "GQ", "GR", "GS", "GT", "GU", "GV", "GW", "GX", "GY", "GZ",
							   "HA", "HB", "HC", "HD", "HE", "HF", "HG", "HH", "HI", "HJ", "HK", "HL", "HM", "HN", "HO", "HP", "HQ", "HR", "HS", "HT", "HU", "HV", "HW", "HX", "HY", "HZ",
							   "IA", "IB", "IC", "ID", "IE", "IF", "IG", "IH", "II", "IJ", "IK", "IL", "IM", "IN", "IO", "IP", "IQ", "IR", "IS", "IT", "IU", "IV", "IW", "IX", "IY", "IZ",
							   "JA", "JB", "JC", "JD", "JE", "JF", "JG", "JH", "JI", "JJ", "JK", "JL", "JM", "JN", "JO", "JP", "JQ", "JR", "JS", "JT", "JU", "JV", "JW", "JX", "JY", "JZ",
							   "KA", "KB", "KC", "KD", "KE", "KF", "KG", "KH", "KI", "KJ", "KK", "KL", "KM", "KN", "KO", "KP", "KQ", "KR", "KS", "KT", "KU", "KV", "KW", "KX", "KY", "KZ",
							   "LA", "LB", "LC", "LD", "LE", "LF", "LG", "LH", "LI", "LJ", "LK", "LL", "LM", "LN", "LO", "LP", "LQ", "LR", "LS", "LT", "LU", "LV", "LW", "LX", "LY", "LZ",
							   "MA", "MB", "MC", "MD", "ME", "MF", "MG", "MH", "MI", "MJ", "MK", "ML", "MM", "MN", "MO", "MP", "MQ", "MR", "MS", "MT", "MU", "MV", "MW", "MX", "MY", "MZ",
							   "NA", "NB", "NC", "ND", "NE", "NF", "NG", "NH", "NI", "NJ", "NK", "NL", "NM", "NN", "NO", "NP", "NQ", "NR", "NS", "NT", "NU", "NV", "NW", "NX", "NY", "NZ",
							   "OA", "OB", "OC", "OD", "OE", "OF", "OG", "OH", "OI", "OJ", "OK", "OL", "OM", "ON", "OO", "OP", "OQ", "OR", "OS", "OT", "OU", "OV", "OW", "OX", "OY", "OZ",
							   "PA", "PB", "PC", "PD", "PE", "PF", "PG", "PH", "PI", "PJ", "PK", "PL", "PM", "PN", "PO", "PP", "PQ", "PR", "PS", "PT", "PU", "PV", "PW", "PX", "PY", "PZ",
							   "QA", "QB", "QC", "QD", "QE", "QF", "QG", "QH", "QI", "QJ", "QK", "QL", "QM", "QN", "QO", "QP", "QQ", "QR", "QS", "QT", "QU", "QV", "QW", "QX", "QY", "QZ",
							   "RA", "RB", "RC", "RD", "RE", "RF", "RG", "RH", "RI", "RJ", "RK", "RL", "RM", "RN", "RO", "RP", "RQ", "RR", "RS", "RT", "RU", "RV", "RW", "RX", "RY", "RZ",
							   "SA", "SB", "SC", "SD", "SE", "SF", "SG", "SH", "SI", "SJ", "SK", "SL", "SM", "SN", "SO", "SP", "SQ", "SR", "SS", "ST", "SU", "SV", "SW", "SX", "SY", "SZ",
							   "TA", "TB", "TC", "TD", "TE", "TF", "TG", "TH", "TI", "TJ", "TK", "TL", "TM", "TN", "TO", "TP", "TQ", "TR", "TS", "TT", "TU", "TV", "TW", "TX", "TY", "TZ",
							   "UA", "UB", "UC", "UD", "UE", "UF", "UG", "UH", "UI", "UJ", "UK", "UL", "UM", "UN", "UO", "UP", "UQ", "UR", "US", "UT", "UU", "UV", "UW", "UX", "UY", "UZ",
							   "VA", "VB", "VC", "VD", "VE", "VF", "VG", "VH", "VI", "VJ", "VK", "VL", "VM", "VN", "VO", "VP", "VQ", "VR", "VS", "VT", "VU", "VV", "VW", "VX", "VY", "VZ",
							   "WA", "WB", "WC", "WD", "WE", "WF", "WG", "WH", "WI", "WJ", "WK", "WL", "WM", "WN", "WO", "WP", "WQ", "WR", "WS", "WT", "WU", "WV", "WW", "WX", "WY", "WZ",
							   "XA", "XB", "XC", "XD", "XE", "XF", "XG", "XH", "XI", "XJ", "XK", "XL", "XM", "XN", "XO", "XP", "XQ", "XR", "XS", "XT", "XU", "XV", "XW", "XX", "XY", "XZ",
							   "YA", "YB", "YC", "YD", "YE", "YF", "YG", "YH", "YI", "YJ", "YK", "YL", "YM", "YN", "YO", "YP", "YQ", "YR", "YS", "YT", "YU", "YV", "YW", "YX", "YY", "YZ",
							   "ZA", "ZB", "ZC", "ZD", "ZE", "ZF", "ZG", "ZH", "ZI", "ZJ", "ZK", "ZL", "ZM", "ZN", "ZO", "ZP", "ZQ", "ZR", "ZS", "ZT", "ZU", "ZV", "ZW", "ZX", "ZY", "ZZ"};

            return map[i];
        }
        #endregion KẾT XUẤT EXCEL

        #region CÁC SỰ KIỆN WINDOWS
        public void f_SetEvent(System.Windows.Forms.Control v_c)
        {
            try
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
            catch
            {
            }
        }
        public void f_SetEvent_Keydown(System.Windows.Forms.Control v_c)
        {
            try
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
            catch
            {
            }
        }
        public void f_Control_Enter(object sender, System.EventArgs e)
        {
            try
            {
                System.Windows.Forms.Control c = (System.Windows.Forms.Control)(sender);
                if ((c.GetType().ToString() == "System.Windows.Forms.TextBox") || (c.GetType().ToString()=="System.Windows.Forms.MaskedTextBox") || (c.GetType().ToString() == "System.Windows.Forms.ComboBox") || (c.GetType().ToString() == "AsYetUnnamed.MultiColumnListBox") || (c.GetType().ToString() == "System.Windows.Forms.TreeView") || (c.GetType().ToString() == "System.Windows.Forms.DataGrid") || (c.GetType().ToString() == "System.Windows.Forms.DateTimePicker") || (c.GetType().ToString() == "System.Windows.Forms.CheckedListBox") || (c.GetType().ToString() == "System.Windows.Forms.NumericUpDown"))
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
                if ((c.GetType().ToString() == "System.Windows.Forms.TextBox") || (c.GetType().ToString() == "System.Windows.Forms.MaskedTextBox") || (c.GetType().ToString() == "System.Windows.Forms.ComboBox") || (c.GetType().ToString() == "AsYetUnnamed.MultiColumnListBox") || (c.GetType().ToString() == "System.Windows.Forms.TreeView") || (c.GetType().ToString() == "System.Windows.Forms.DataGrid") || (c.GetType().ToString() == "System.Windows.Forms.DateTimePicker") || (c.GetType().ToString() == "System.Windows.Forms.CheckedListBox") || (c.GetType().ToString() == "System.Windows.Forms.NumericUpDown"))
                {
                    c.BackColor = Color.White;//GhostWhite;
                    if (c.ForeColor != Color.Red)
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

        #region XN_TREEMNU
        public DataSet get_xn_treemenu()
        {
            string asql = "select * from medibv.xn_treemenu";
            return get_data(asql);
        }
        public bool reorder_xn_treemenu(string v_id, int v_step)
        {
            try
            {
                DataRow r = get_data("select * from medibv.xn_treemenu where id=" + v_id + "").Tables[0].Rows[0];
                DataRow r1;
                if (v_step > 0)
                {
                    r1 = get_data("select * from medibv.xn_treemenu where id_cha=" + r["id_cha"].ToString() + " and stt>" + r["stt"].ToString() + " order by stt asc").Tables[0].Rows[0];
                }
                else
                {
                    r1 = get_data("select * from medibv.xn_treemenu where id_cha=" + r["id_cha"].ToString() + " and stt<" + r["stt"].ToString() + " order by stt desc").Tables[0].Rows[0];
                }
                execute_data("update medibv.xn_treemenu set stt=" + r1["stt"].ToString() + " where id=" + r["id"].ToString());
                execute_data("update medibv.xn_treemenu set stt=" + r["stt"].ToString() + " where id=" + r1["id"].ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string get_stt_xn_treemenu(string v_id_cha)
        {
            try
            {
                if (v_id_cha == "") v_id_cha = "0";
                return get_data("select case when max(stt) is null then 0 else max(stt) end + 1 as stt from medibv.xn_treemenu where id_cha=" + v_id_cha + "").Tables[0].Rows[0][0].ToString();
            }
            catch
            {
                return "1";
            }
        }
        public string get_id_xn_treemenu()
        {
            try
            {
                return get_data("select case when max(id) is null then 0 else max(id) end + 1 as stt from medibv.xn_treemenu").Tables[0].Rows[0][0].ToString();
            }
            catch
            {
                return "1";
            }
        }
        public bool del_xn_treemenu(string v_id)
        {
            try
            {
                execute_data("delete medibv.xn_treemenu where id=" + v_id + " and readonly=0");
                return !(get_data("select id from medibv.xn_treemenu where id=" + v_id).Tables[0].Rows.Count > 0);
            }
            catch
            {
                return false;
            }
        }
        public bool upd_xn_null(string v_id, string v_ten)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_null set ten=:v_ten where id=:v_id";
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
                    m_sql = "insert into " + m_db_schemaroot + ".xn_null(id, ten) values(:v_id, :v_ten)";
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
                upd_xn_error(ex.Message, m_computername, "xn_null");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_treemenu(decimal v_id, decimal v_id_cha, decimal v_stt, string v_ten, string v_sql, string v_tenfield, string v_captionfield, string v_width, string v_report, decimal v_readonly)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_treemenu set id_cha=:v_id_cha, stt=:v_stt,ten=:v_ten,sql=:v_sql, tenfield=:v_tenfield, captionfield=:v_captionfield, width=:v_width, report=:v_report, readonly=:v_readonly where id=:v_id";
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
                    m_sql = "insert into " + m_db_schemaroot + ".xn_treemenu(id,id_cha,stt,ten,sql,tenfield,captionfield,width,report,readonly) values(:v_id,:v_id_cha,:v_stt,:v_ten,:v_sql,:v_tenfield,:v_captionfield,:v_width,:v_report,:v_readonly)";
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
                upd_xn_error(ex.Message, m_computername, "xn_treemenu");
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

        #region KSK
        public void f_create_ct_kham(string v_mmyy)
        {
            int n = 0;
            if (v_mmyy != "")
            {
                try
                {
                    n = get_data_mmyy(v_mmyy, "select * from medibvmmyy.ct_kham limit 1").Tables[0].Rows.Count;
                }
                catch
                {
                    execute_data_mmyy(v_mmyy, "CREATE TABLE medibvmmyy.ct_kham(id numeric(12) NOT NULL DEFAULT 0,tiencan text, hientai text, chieucao text,cannang text,vongnguc text,mach text, tim text, phoi text, bung text, huyetap text,khac text,lamsang text,ngayud timestamp DEFAULT now(),CONSTRAINT pk_ct_kham PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH OIDS");
                    execute_data_mmyy(v_mmyy, "ALTER TABLE medibvmmyy.ct_kham OWNER TO " + m_db_database);
                }
                try
                {
                    n = get_data_mmyy(v_mmyy, "select quyettoan from medibvmmyy.ct_ketqua limit 1").Tables[0].Rows.Count;
                }
                catch
                {
                    execute_data_mmyy(v_mmyy, "ALTER TABLE medibvmmyy.ct_ketqua add quyettoan numeric(10) default 0");
                }
                try
                {
                    n = get_data_mmyy(v_mmyy, "select ngayqt from medibvmmyy.ct_ketqua limit 1").Tables[0].Rows.Count;
                }
                catch
                {
                    execute_data_mmyy(v_mmyy, "ALTER TABLE medibvmmyy.ct_ketqua add ngayqt timestamp without time zone default now()");
                }
            }
            else
            {
                foreach (DataRow r in get_data("select distinct to_char(ngayud,'mmyy') as mmyy from medibv.ct_doan").Tables[0].Rows)
                {
                    v_mmyy = r["mmyy"].ToString();
                    try
                    {
                        n = get_data_mmyy(v_mmyy, "select * from medibvmmyy.ct_kham limit 1").Tables[0].Rows.Count;
                    }
                    catch
                    {
                        execute_data_mmyy(v_mmyy, "CREATE TABLE medibvmmyy.ct_kham(id numeric(12) NOT NULL DEFAULT 0,tiencan text, hientai text, chieucao text,cannang text,vongnguc text,mach text, tim text, phoi text, bung text, huyetap text,khac text,lamsang text,ngayud timestamp DEFAULT now(),CONSTRAINT pk_ct_kham PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH OIDS");
                        execute_data_mmyy(v_mmyy, "ALTER TABLE medibvmmyy.ct_kham OWNER TO " + m_db_database);
                    }
                    try
                    {
                        n = get_data_mmyy(v_mmyy, "select quyettoan from medibvmmyy.ct_ketqua limit 1").Tables[0].Rows.Count;
                    }
                    catch
                    {
                        execute_data_mmyy(v_mmyy, "ALTER TABLE medibvmmyy.ct_ketqua add quyettoan numeric(10) default 0");
                    }
                    try
                    {
                        n = get_data_mmyy(v_mmyy, "select ngayqt from medibvmmyy.ct_ketqua limit 1").Tables[0].Rows.Count;
                    }
                    catch
                    {
                        execute_data_mmyy(v_mmyy, "ALTER TABLE medibvmmyy.ct_ketqua add ngayqt timestamp without time zone default now()");
                    }
                }
            }
        }
        public void f_modify_ct_giavp()
        {
            try
            {
                int a = get_data("select mavp from medibv.ct_giavp limit 1").Tables[0].Rows.Count;
            }
            catch
            {
                execute_data("alter table medibv.ct_giavp add mavp numeric(7) default 0");
            }
        }
        public bool upd_ct_kham(string v_mmyy, string v_id, string v_tiencan, string v_hientai, string v_chieucao, string v_cannang, string v_vongnguc, string v_mach, string v_tim, string v_phoi, string v_bung, string v_huyetap, string v_khac, string v_lamsang)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".ct_kham set tiencan=:v_tiencan, hientai=:v_hientai, chieucao=:v_chieucao, cannang=:v_cannang, vongnguc=:v_vongnguc, mach=:v_mach, tim=:v_tim, phoi=:v_phoi, bung=:v_bung, huyetap=:v_huyetap, khac=:v_khac, lamsang=:v_lamsang where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_tiencan", NpgsqlDbType.Text).Value = v_tiencan;
            m_command.Parameters.Add("v_hientai", NpgsqlDbType.Text).Value = v_hientai;
            m_command.Parameters.Add("v_chieucao", NpgsqlDbType.Text).Value = v_chieucao;
            m_command.Parameters.Add("v_cannang", NpgsqlDbType.Text).Value = v_cannang;
            m_command.Parameters.Add("v_vongnguc", NpgsqlDbType.Text).Value = v_vongnguc;
            m_command.Parameters.Add("v_mach", NpgsqlDbType.Text).Value = v_mach;
            m_command.Parameters.Add("v_tim", NpgsqlDbType.Text).Value = v_tim;
            m_command.Parameters.Add("v_phoi", NpgsqlDbType.Text).Value = v_phoi;
            m_command.Parameters.Add("v_bung", NpgsqlDbType.Text).Value = v_bung;
            m_command.Parameters.Add("v_huyetap", NpgsqlDbType.Text).Value = v_huyetap;
            m_command.Parameters.Add("v_khac", NpgsqlDbType.Text).Value = v_khac;
            m_command.Parameters.Add("v_lamsang", NpgsqlDbType.Text).Value = v_lamsang;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".ct_kham(id,tiencan,hientai,chieucao,cannang,vongnguc,mach,tim,phoi,bung,huyetap,khac,lamsang) values(:v_id,:v_tiencan,:v_hientai,:v_chieucao,:v_cannang,:v_vongnguc,:v_mach,:v_tim,:v_phoi,:v_bung,:v_huyetap,:v_khac,:v_lamsang)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_tiencan", NpgsqlDbType.Text).Value = v_tiencan;
                    m_command.Parameters.Add("v_hientai", NpgsqlDbType.Text).Value = v_hientai;
                    m_command.Parameters.Add("v_chieucao", NpgsqlDbType.Text).Value = v_chieucao;
                    m_command.Parameters.Add("v_cannang", NpgsqlDbType.Text).Value = v_cannang;
                    m_command.Parameters.Add("v_vongnguc", NpgsqlDbType.Text).Value = v_vongnguc;
                    m_command.Parameters.Add("v_mach", NpgsqlDbType.Text).Value = v_mach;
                    m_command.Parameters.Add("v_tim", NpgsqlDbType.Text).Value = v_tim;
                    m_command.Parameters.Add("v_phoi", NpgsqlDbType.Text).Value = v_phoi;
                    m_command.Parameters.Add("v_bung", NpgsqlDbType.Text).Value = v_bung;
                    m_command.Parameters.Add("v_huyetap", NpgsqlDbType.Text).Value = v_huyetap;
                    m_command.Parameters.Add("v_khac", NpgsqlDbType.Text).Value = v_khac;
                    m_command.Parameters.Add("v_lamsang", NpgsqlDbType.Text).Value = v_lamsang;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(v_mmyy, ex.Message, m_computername, "ct_kham");
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

        #region XÁC ĐỊNH FILE
        public string f_modify(string tenfile)
        {
            return System.IO.File.GetLastWriteTime(tenfile).ToString("dd/MM/yyyy HH:mm");
        }
        public string f_size(string tenfile)
        {
            System.IO.FileInfo fi = new System.IO.FileInfo(tenfile);
            return (fi.Length / 1024).ToString();
        }
        public string file_exe(string tenfilegoc)
        {
            string ret = "";
            string[] files = System.IO.Directory.GetFiles(System.IO.Directory.GetCurrentDirectory());
            for (int i = 0; i < files.GetLength(0); i++)
            {
                if (files[i].ToString().ToUpper().IndexOf(".EXE") != -1 && tenfile_goc(files[i].ToString()) == tenfilegoc.ToLower())
                {
                    ret = files[i].ToString();
                    break;
                }
            }
            return ret;
        }
        public string file_exe(string path, string tenfilegoc)
        {
            string[] files = System.IO.Directory.GetFiles(path);
            for (int i = 0; i < files.GetLength(0); i++)
            {
                if ((files[i].ToString().ToUpper().IndexOf(".EXE") != -1) && (tenfile_goc(files[i].ToString()) == tenfilegoc.ToLower()))
                {
                    return files[i].ToString();
                }
            }
            return "";
        }
        public string tenfile_goc(string tenfile)
        {
            System.Reflection.Assembly asm = null;
            asm = System.Reflection.Assembly.LoadFrom(tenfile);
            return asm.GetName().Name.ToString().ToLower();
        }
        public string path_medisofthis()
        {
            string currentDirectory = System.IO.Directory.GetCurrentDirectory();
            int num = 0;
            int length = currentDirectory.Length;
            while (length > 0)
            {
                if (currentDirectory.Substring(length - 1, 1) == @"\")
                {
                    num++;
                }
                if (num == 3)
                {
                    break;
                }
                length--;
            }
            return currentDirectory.Substring(0, length - 1);
        }
        public void writeXml(string tenfile, string cot, string s)
        {
            DataSet ds = new DataSet();
            try
            {
                ds.ReadXml(@"..\..\..\xml\" + tenfile + ".xml");
                ds.Tables[0].Rows[0][cot] = s;
            }
            catch
            {
                DataColumn column = new DataColumn();
                column.ColumnName = cot;
                column.DataType = Type.GetType("System.String");
                ds.Tables[0].Columns.Add(column);
                ds.Tables[0].Rows[0][cot] = s;
            }
            ds.WriteXml(@"..\..\..\xml\" + tenfile + ".xml");
        }
        public bool bAutoupdate
        {
            get
            {
                try
                {
                    return (int.Parse(get_data("select ten from " + user + ".thongso where id=340").Tables[0].Rows[0][0].ToString()) == 1);
                }
                catch
                {
                    return false;
                }
            }
        }
        public string Path_medisoft
        {
            get
            {
                try
                {
                    return get_data("select ten from " + user + ".thongso where id=341").Tables[0].Rows[0][0].ToString();
                }
                catch
                {
                    return "";
                }
            }
        }
        public bool bUpdate(string p_localhost, string p_server, string file)
        {
            bool flag = f_modify(file_exe(p_localhost, file)) == f_modify(file_exe(p_server, file));
            bool flag2 = f_size(file_exe(p_localhost, file)) == f_size(file_exe(p_server, file));
            return (flag && flag2);
        }
        #endregion

        #region MA HOA MAT KHAU
        public bool bMahoamatkhau
        {
            get
            {
                return get_data("select ten from medibv.thongso where id=-13").Tables[0].Rows.Count > 0;
            }
        }

        public string encode(string s)
        {
            string s1 = "";
            char c;
            byte b;
            s = s.Trim();
            for (int i = 0; i < s.Length; i++)
            {
                c = Convert.ToChar(s.Substring(i, 1).ToUpper());
                b = (byte)(c);
                s1 = s1 + Convert.ToChar((b % 2 == 0) ? b + 128 : b + 96);
            }
            return s1;
        }

        public string decode(string s)
        {
            string s1 = "";
            char c;
            byte b;
            s = s.Trim();
            for (int i = 0; i < s.Length; i++)
            {
                c = Convert.ToChar(s.Substring(i, 1));
                b = (byte)(c);
                s1 = s1 + Convert.ToChar((b % 2 == 0) ? b - 128 : b - 96);
            }
            return s1;
        }
       

        #endregion

        #region THONG SO MEDISOFT
        public void upd_thongso(int m_id, string m_fie, string m_ten)
        {
            m_sql = "update " + user + ".thongso set " + m_fie + "=:m_ten ";
            if (m_fie == "tencur") m_sql += ",ngayud=now()";
            m_sql += " where id=" + m_id;
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            try
            {
                m_connection.Open();
                m_command = new NpgsqlCommand(m_sql, m_connection);
                m_command.CommandType = CommandType.Text;
                m_command.Parameters.Add("m_ten", NpgsqlDbType.Text).Value = m_ten;
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + user + ".thongso(id," + m_fie + ") values (:m_id,:m_ten)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("m_id", NpgsqlDbType.Numeric).Value = m_id;
                    m_command.Parameters.Add("m_ten", NpgsqlDbType.Text).Value = m_ten;
                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_xn_error(ex.Message.ToString().Trim(), m_computername, "Thongso");
            }
            finally
            {
                m_command.Dispose();
                m_connection.Close(); 
                m_connection.Dispose();
            }
        }

        public void upd_thongso(int id, string ten, string tendef, string tencur)
        {
            m_sql = "update " + user + ".thongso set ten=:ten,tendef=:tendef,tencur=:tencur where id=:id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            try
            {
                m_connection.Open();
                m_command = new NpgsqlCommand(m_sql, m_connection);
                m_command.CommandType = CommandType.Text;
                m_command.Parameters.Add("ten", NpgsqlDbType.Text).Value = ten;
                m_command.Parameters.Add("tendef", NpgsqlDbType.Text).Value = tendef;
                m_command.Parameters.Add("tencur", NpgsqlDbType.Text).Value = tencur;
                m_command.Parameters.Add("id", NpgsqlDbType.Numeric).Value = id;
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + user + ".thongso(id,ten,tendef,tencur) values (:id,:ten,:tendef,:tencur)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("id", NpgsqlDbType.Numeric).Value = id;
                    m_command.Parameters.Add("ten", NpgsqlDbType.Text).Value = ten;
                    m_command.Parameters.Add("tendef", NpgsqlDbType.Text).Value = tendef;
                    m_command.Parameters.Add("tencur", NpgsqlDbType.Text).Value = tencur;
                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_xn_error(ex.Message.ToString().Trim(), m_computername, "Thongso");
            }
            finally
            {
                m_command.Dispose();
                m_connection.Close(); 
                
                m_connection.Dispose();
            }
        }

        #endregion

        #region Kien tra so
        public void MaskDigit(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == 8) e.Handled = false;
            else e.Handled = true;
        }
        public void MaskDigit_dautru(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == '-') e.Handled = false;
            else e.Handled = true;
        }
        public void MaskDecimal(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == 8) e.Handled = false;
            else e.Handled = true;
        }
        #endregion

        #region Bảng điện
        public int LocationX
        {
            get
            {
                return int.Parse(Mau("x"));
            }
        }

        public int LocationY
        {
            get
            {
                return int.Parse(Mau("y"));
            }
        }

        public int width
        {
            get
            {
                return int.Parse(Mau("w"));
            }
        }

        public int height
        {
            get
            {
                return int.Parse(Mau("h"));
            }
        }

        public int size
        {
            get
            {
                return int.Parse(Mau("s"));
            }
        }
        public string Mau(string sql)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("..\\..\\..\\xml\\mau.xml");
                XmlNodeList nodeLst = doc.GetElementsByTagName(sql);
                return nodeLst.Item(0).InnerText;
            }
            catch
            {
                return "";
            }
        }
        public int sogiay_loaddata
        {
            get
            {
                int i = 0;
                try
                {
                    i = int.Parse(get_data("select val from medibv.xn_option where ma='sogiay_laydata'").Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    i = 0;
                }
                if (i < 0) i = 0;
                return i;
            }
            set
            {
                upd_xn_option("sogiay_laydata", value.ToString());
            }
        }

        public int delay
        {
            get
            {
                int i = 0;
                try
                {
                    i = int.Parse(get_data("select val from medibv.xn_option where ma='txtdeplay'").Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    i = 0;
                }
                if (i < 0) i = 0;
                return i;
            }
            set
            {
                upd_xn_option("txtdeplay", value.ToString());
            }
        }
        public bool bHien_holotten
        {
            get
            {
                try
                {
                    DataSet ds = get_data("select ten from thongso where id=292");
                    return (ds.Tables[0].Rows[0][0].ToString().Trim() == "1");
                }
                catch { return false; }
            }
        }
        public string f_Get_Trieuchunglamsang(string s_Tu, string s_Den, long s_maql, bool bKhoangcach)
        {
            try
            {
                s_Tu = bKhoangcach ? StringToDate(s_Tu).AddDays(-s_o_khoangcachngaylamviec).ToString("dd/MM/yyyy", null) : s_Tu;
                return get_data_mmyy(s_Tu, s_Den, "select lydo as ten from medibvmmyy.lydokham where maql=" + s_maql + " ", false).Tables[0].Rows[0][0].ToString();
            }
            catch
            {
                return "";
            }
        }
        public bool s_hienthidanhsachcho
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkHienthi_tivi'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                upd_xn_option("chkHienthi_tivi", value == true ? "1" : "0");
            }
        }
        public bool s_chukymau
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkChuky'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                upd_xn_option("chkChuky", value == true ? "1" : "0");
            }
        }
        public bool s_xemcaclanxn
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkxemcaclanxn'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                upd_xn_option("chkxemcaclanxn", value == true ? "1" : "0");
            }
        }
        public bool s_quanlyhinhbn
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkChonHinh'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                upd_xn_option("chkChonHinh", value == true ? "1" : "0");
            }
        }
        public bool s_xuat_stt_bangdien
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkSttcho'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                upd_xn_option("chkSttcho", value == true ? "1" : "0");
            }
        }
        //chkHoloten
        public bool s_hienthi_ho_ten
        {
            get
            {
                try
                {
                    return get_data("select val from medibv.xn_option where ma='chkHoloten'").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                upd_xn_option("chkHoloten", value == true ? "1" : "0");
            }
        }
        public string s_o_maunen_tivi
        {
            get
            {
                string  gttv="0,0,160";
                try
                {
                    gttv = get_data("select val from medibv.xn_option where ma='lblMaunen'").Tables[0].Rows[0][0].ToString();
                }
                catch
                {
                    gttv = "0,0,160";
                    upd_xn_option("lblMaunen", gttv);
                }
                
                return gttv;
            }
            set
            {
                upd_xn_option("lblMaunen", value.ToString());
            }
        }
        public string s_o_mauchu_tivi
        {
            get
            {
                string gttv = "255,255,0";
                try
                {
                    gttv = get_data("select val from medibv.xn_option where ma='lblMauchu_tivi'").Tables[0].Rows[0][0].ToString();
                }
                catch
                {
                    //gttv = "0,0,160";
                    upd_xn_option("lblMauchu_tivi", gttv);
                }

                return gttv;
            }
            set
            {
                upd_xn_option("lblMauchu_tivi", value.ToString());
            }
        }
        #endregion
        public bool upd_xn_maubenhpham_ct(string v_mmyy, decimal v_id, decimal v_mauthu, decimal v_idvattuchua, int v_chatluongmau, 
            string v_ghichu, int v_laymaulai, int v_nhanmau, string v_ngaynhan, decimal v_userDuyet)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".xn_maubenhpham_ct set  ";
            m_sql += " chatluongmau=:v_chatluongmau,ghichu=:v_ghichu,laymaulai=:v_laymaulai,nhanmau=:v_nhanmau, ";
            m_sql += " ngaynhan=to_date(:v_ngaynhan,'dd/mm/yyyy hh24:mi'),userd=:v_userDuyet where id_xnphieu=:v_id and id_mauthu=:v_mauthu and id_vatchuamau=:v_idvattuchua";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;
            m_command.Parameters.Add("v_chatluongmau", NpgsqlDbType.Numeric).Value = v_chatluongmau;
            m_command.Parameters.Add("v_ghichu", NpgsqlDbType.Varchar,200).Value = v_ghichu;
            m_command.Parameters.Add("v_laymaulai", NpgsqlDbType.Numeric).Value = v_laymaulai;
            m_command.Parameters.Add("v_nhanmau", NpgsqlDbType.Numeric).Value = v_nhanmau;
            m_command.Parameters.Add("v_ngaynhan", NpgsqlDbType.Text, 16).Value = v_ngaynhan;            
            m_command.Parameters.Add("v_userDuyet", NpgsqlDbType.Numeric).Value = v_userDuyet;
            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_mauthu", NpgsqlDbType.Numeric).Value = v_mauthu;
            m_command.Parameters.Add("v_idvattuchua", NpgsqlDbType.Numeric).Value = v_idvattuchua;
            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();               
            }
            catch (Exception ex)
            {
                upd_xn_error(v_mmyy, ex.Message, m_computername, "xn_maubenhpham_ct");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public string get_mabn_nam(string mabn)
        {
            DataSet  dstmp = get_data("select nam from " + user + ".btdbn where mabn='" + mabn + "'");
            if (dstmp.Tables[0].Rows.Count > 0) return dstmp.Tables[0].Rows[0]["nam"].ToString().Trim();
            else return "";
        }
        public bool upd_xn_maubenhpham_ct(string v_mmyy, decimal v_id, decimal v_mauthu, decimal v_idvattuchua, int v_soluong, decimal v_userid)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".xn_maubenhpham_ct set  ";
            m_sql += " soluong=:v_soluong,userid=:v_userid where id_xnphieu=:v_id and id_mauthu=:v_mauthu and id_vatchuamau=:v_idvattuchua";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            
            m_command.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_mauthu", NpgsqlDbType.Numeric).Value = v_mauthu;
            m_command.Parameters.Add("v_idvattuchua", NpgsqlDbType.Numeric).Value = v_idvattuchua;
            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".xn_maubenhpham_ct(id_xnphieu,id_mauthu,id_vatchuamau,soluong,userid) values(:v_id,:v_mauthu,:v_idvattuchua,:v_soluong,:v_userid)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_mauthu", NpgsqlDbType.Numeric).Value = v_mauthu; 
                    m_command.Parameters.Add("v_idvattuchua", NpgsqlDbType.Numeric).Value = v_idvattuchua;
                    m_command.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(v_mmyy, ex.Message, m_computername, "xn_maubenhpham_ct");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_maugoingoaidm(string v_mmyy, decimal v_id_xnphieu, decimal v_id_xn_bv_ten, 
            decimal v_id_chidinh, decimal v_id_noigoi, string v_lydo, decimal v_duyet, decimal v_userid,
            decimal v_useridd,string v_ngay)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".xn_maugoingoaidm  set  ";
            m_sql += " id_chidinh=:v_id_chidinh";
            m_sql += ",id_noigoi=:v_id_noigoi";
            m_sql += ",lydo=:v_lydo";
            m_sql += " ,duyet=:v_duyet,userid=:v_userid,useridd=:v_useridd,ngay=to_date(:v_ngay,'dd/mm/yyyy') ";
            m_sql += " where id_xnphieu=:v_id_xnphieu and id_xn_bv_ten=:v_id_xn_bv_ten";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;


            m_command.Parameters.Add("v_id_chidinh", NpgsqlDbType.Numeric).Value = v_id_chidinh;
            m_command.Parameters.Add("v_id_noigoi", NpgsqlDbType.Numeric).Value = v_id_noigoi;
            m_command.Parameters.Add("v_lydo", NpgsqlDbType.Varchar,50).Value = v_lydo;
            m_command.Parameters.Add("v_duyet", NpgsqlDbType.Numeric).Value = v_duyet;
            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
            m_command.Parameters.Add("v_useridd", NpgsqlDbType.Numeric).Value = v_useridd;
            m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay;
            m_command.Parameters.Add("v_id_xnphieu", NpgsqlDbType.Numeric).Value = v_id_xnphieu;
            m_command.Parameters.Add("v_id_xn_bv_ten", NpgsqlDbType.Numeric).Value = v_id_xn_bv_ten;            
            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".xn_maugoingoaidm(id_xnphieu,id_xn_bv_ten,id_chidinh,id_noigoi,lydo,duyet,userid,useridd,ngay)";
                    m_sql += " values(:v_id_xnphieu,:v_id_xn_bv_ten,:v_id_chidinh,:v_id_noigoi,:v_lydo,:v_duyet,:v_userid,:v_useridd,to_date(:v_ngay,'dd/mm/yyyy'))";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id_xnphieu", NpgsqlDbType.Numeric).Value = v_id_xnphieu;
                    m_command.Parameters.Add("v_id_xn_bv_ten", NpgsqlDbType.Numeric).Value = v_id_xn_bv_ten;   
                    m_command.Parameters.Add("v_id_chidinh", NpgsqlDbType.Numeric).Value = v_id_chidinh;
                    m_command.Parameters.Add("v_id_noigoi", NpgsqlDbType.Numeric).Value = v_id_noigoi;
                    m_command.Parameters.Add("v_lydo", NpgsqlDbType.Varchar,50).Value = v_lydo;
                    m_command.Parameters.Add("v_duyet", NpgsqlDbType.Numeric).Value = v_duyet;
                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                    m_command.Parameters.Add("v_useridd", NpgsqlDbType.Numeric).Value = v_useridd;
                    m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay;
                    

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(v_mmyy, ex.Message, m_computername, "xn_maugoingoaidm");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public  decimal f_get_id_xn_tenct
        {
            get
            {
                try
                {
                    decimal _value = 1;
                    m_sql = "select nextval('" + user + ".xn_ten_ct_id_seq');";
                    m_connection = new NpgsqlConnection(m_db_connectionstring);
                    m_connection.Open();
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    object obj = m_command.ExecuteScalar();
                    if (obj != null)
                    {
                        _value = decimal.Parse(obj.ToString());
                    }
                    return _value;
                }
                catch
                {
                    return 1;
                }
                finally
                {
                    m_connection.Dispose(); m_command.Dispose();
                }
            }
        }
        public bool upd_xn_ten_ct(decimal v_id, decimal v_id_xn_ten, int v_tuoitu, int v_tuoiden,int v_loaituoi,string v_csbt_nam, 
            decimal v_mincsbt_nam, decimal v_maxcsbt_nam,string v_csbt_nu, decimal v_mincsbt_nu, decimal v_maxcsbt_nu,
            string v_cs_nguycap,decimal v_mincs_nc, decimal v_maxcs_nc, decimal v_userid)
        {
            m_sql = "update " + s_schemaroot + ".xn_ten_ct set  ";
            m_sql += " tuoitu=:v_tuoitu,tuoiden=:v_tuoiden,loaituoi=:v_loaituoi,csbt_nam=:v_csbt_nam,";
            m_sql += " mincsbt_nam=:v_mincsbt_nam,maxcsbt_nam=:v_maxcsbt_nam,csbt_nu=:v_csbt_nu, mincsbt_nu=:v_mincsbt_nu,";
            m_sql += " maxcsbt_nu=:v_maxcsbt_nu,cs_nguycap=:v_cs_nguycap,mincs_nc=:v_mincs_nc,maxcs_nc=:v_maxcs_nc,userid=:v_userid where id=:v_id and id_xn_ten=:v_id_xn_ten";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;
            
            m_command.Parameters.Add("v_tuoitu", NpgsqlDbType.Numeric).Value = v_tuoitu;
            m_command.Parameters.Add("v_tuoiden", NpgsqlDbType.Numeric).Value = v_tuoiden;
            m_command.Parameters.Add("v_loaituoi", NpgsqlDbType.Numeric).Value = v_loaituoi;
            m_command.Parameters.Add("v_csbt_nam", NpgsqlDbType.Varchar,50).Value = v_csbt_nam;
            m_command.Parameters.Add("v_mincsbt_nam", NpgsqlDbType.Numeric).Value = v_mincsbt_nam;
            m_command.Parameters.Add("v_maxcsbt_nam", NpgsqlDbType.Numeric).Value = v_maxcsbt_nam;
            m_command.Parameters.Add("v_csbt_nu", NpgsqlDbType.Varchar, 50).Value = v_csbt_nu;
            m_command.Parameters.Add("v_mincsbt_nu", NpgsqlDbType.Numeric).Value = v_mincsbt_nu;
            m_command.Parameters.Add("v_maxcsbt_nu", NpgsqlDbType.Numeric).Value = v_maxcsbt_nu;
            m_command.Parameters.Add("v_cs_nguycap", NpgsqlDbType.Varchar, 50).Value = v_cs_nguycap;
            m_command.Parameters.Add("v_mincs_nc", NpgsqlDbType.Numeric).Value = v_mincs_nc;
            m_command.Parameters.Add("v_maxcs_nc", NpgsqlDbType.Numeric).Value = v_maxcs_nc;
            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_id_xn_ten", NpgsqlDbType.Numeric).Value = v_id_xn_ten;
            
            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".xn_ten_ct(id,id_xn_ten,tuoitu,tuoiden,loaituoi,csbt_nam,mincsbt_nam,maxcsbt_nam,csbt_nu,mincsbt_nu,maxcsbt_nu,cs_nguycap,mincs_nc,maxcs_nc,userid) ";
                    m_sql += " values(:v_id,:v_id_xn_ten,:v_tuoitu,:v_tuoiden,:v_loaituoi,:v_csbt_nam,:v_mincsbt_nam,:v_maxcsbt_nam,:v_csbt_nu,:v_mincsbt_nu,:v_maxcsbt_nu,:v_cs_nguycap,:v_mincs_nc,:v_maxcs_nc,:v_userid)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_id_xn_ten", NpgsqlDbType.Numeric).Value = v_id_xn_ten;
                    m_command.Parameters.Add("v_tuoitu", NpgsqlDbType.Numeric).Value = v_tuoitu;
                    m_command.Parameters.Add("v_tuoiden", NpgsqlDbType.Numeric).Value = v_tuoiden;
                    m_command.Parameters.Add("v_loaituoi", NpgsqlDbType.Numeric).Value = v_loaituoi;
                    m_command.Parameters.Add("v_csbt_nam", NpgsqlDbType.Varchar, 50).Value = v_csbt_nam;
                    m_command.Parameters.Add("v_mincsbt_nam", NpgsqlDbType.Numeric).Value = v_mincsbt_nam;
                    m_command.Parameters.Add("v_maxcsbt_nam", NpgsqlDbType.Numeric).Value = v_maxcsbt_nam;
                    m_command.Parameters.Add("v_csbt_nu", NpgsqlDbType.Varchar, 50).Value = v_csbt_nu;
                    m_command.Parameters.Add("v_mincsbt_nu", NpgsqlDbType.Numeric).Value = v_mincsbt_nu;
                    m_command.Parameters.Add("v_maxcsbt_nu", NpgsqlDbType.Numeric).Value = v_maxcsbt_nu;
                    m_command.Parameters.Add("v_cs_nguycap", NpgsqlDbType.Varchar, 50).Value = v_cs_nguycap;
                    m_command.Parameters.Add("v_mincs_nc", NpgsqlDbType.Numeric).Value = v_mincs_nc;
                    m_command.Parameters.Add("v_maxcs_nc", NpgsqlDbType.Numeric).Value = v_maxcs_nc;
                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                   

                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_ten_ct");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public decimal f_get_id_xn_worksheetll
        {
            get
            {
                try
                {
                    decimal _value = 1;
                    m_sql = "select nextval('" + user + ".xn_worksheetll_id_seq');";
                    m_connection = new NpgsqlConnection(m_db_connectionstring);
                    m_connection.Open();
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    object obj = m_command.ExecuteScalar();
                    if (obj != null)
                    {
                        _value = decimal.Parse(obj.ToString());
                    }
                    return _value;
                }
                catch
                {
                    return 1;
                }
                finally
                {
                    m_connection.Dispose(); m_command.Dispose();
                }
            }

        }

        public bool upd_xn_worksheetct(decimal v_id, decimal v_id_bv_ten, decimal v_stt, decimal v_userid)
        {
            m_sql = "update " + m_db_schemaroot + ".xn_worksheetct set stt=:v_stt, userid=:v_userid where id=:v_id and id_xn_ten=:v_id_bv_ten";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_id_bv_ten", NpgsqlDbType.Numeric).Value = v_id_bv_ten;
                                   
            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m_db_schemaroot + ".xn_worksheetct(id,id_xn_ten,stt,userid) values(:v_id,:v_id_bv_ten,:v_stt,:v_userid)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_id_bv_ten", NpgsqlDbType.Numeric).Value = v_id_bv_ten;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;                    
                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_worksheetct");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_worksheetll(decimal v_id, string v_ma, string v_tenws, int v_id_mayxn,
            int v_sl_mau, int v_sl_test,  decimal v_userid)
        {
            m_sql = "update " + s_schemaroot + ".xn_worksheetll set  ";
            m_sql += " ma=:v_ma,tenws=:v_tenws,id_mayxn=:v_id_mayxn,sl_mau=:v_sl_mau,";
            m_sql += " sl_test=:v_sl_test ,userid=:v_userid where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar,5).Value = v_ma;
            m_command.Parameters.Add("v_tenws", NpgsqlDbType.Varchar,50).Value = v_tenws;
            m_command.Parameters.Add("v_id_mayxn", NpgsqlDbType.Numeric).Value = v_id_mayxn;
            m_command.Parameters.Add("v_sl_mau", NpgsqlDbType.Numeric).Value = v_sl_mau;
            m_command.Parameters.Add("v_sl_test", NpgsqlDbType.Numeric).Value = v_sl_test;            
            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
           
            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schemaroot + ".xn_worksheetll(id,ma,tenws,id_mayxn,sl_mau,sl_test,userid) ";
                    m_sql += " values(:v_id,:v_ma,:v_tenws,:v_id_mayxn,:v_sl_mau,:v_sl_test,:v_userid)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 5).Value = v_ma;
                    m_command.Parameters.Add("v_tenws", NpgsqlDbType.Varchar, 50).Value = v_tenws;
                    m_command.Parameters.Add("v_id_mayxn", NpgsqlDbType.Numeric).Value = v_id_mayxn;
                    m_command.Parameters.Add("v_sl_mau", NpgsqlDbType.Numeric).Value = v_sl_mau;
                    m_command.Parameters.Add("v_sl_test", NpgsqlDbType.Numeric).Value = v_sl_test;
                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;


                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_worksheetll");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }

        public bool upd_xn_worksheet(string v_mmyy,decimal v_id, string v_ma, decimal v_id_master,
            string  v_ngay, decimal v_userid)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".xn_worksheet set  ";
            m_sql += " ma=:v_ma,id_master=:v_id_master,ngay=to_date(:v_ngay,'dd/mm/yyyy'),";
            m_sql += " userid=:v_userid where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
            m_command.Parameters.Add("v_id_master", NpgsqlDbType.Numeric).Value = v_id_master;
            m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar,10).Value = v_ngay;            
            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".xn_worksheet(id,ma,id_master,ngay,userid) ";
                    m_sql += " values(:v_id,:v_ma,:v_id_master,to_date(:v_ngay,'dd/mm/yyyy'),:v_userid)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
                    m_command.Parameters.Add("v_id_master", NpgsqlDbType.Numeric).Value = v_id_master;
                    m_command.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay;
                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;


                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(v_mmyy, ex.Message, m_computername, "xn_worksheetll");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_worksheetct(string v_mmyy,decimal v_id,decimal v_id_xn_phieu, decimal v_id_xn_ten, decimal v_stt, decimal v_userid)
        {
            m_sql = "update " + s_schema_mmyy(v_mmyy) + ".xn_worksheet_ct set stt=:v_stt, userid=:v_userid where id=:v_id and id_xn_phieu=:v_id_xn_phieu and id_xn_ten=:v_id_xn_ten ";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;

            m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
            m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
            m_command.Parameters.Add("v_id_xn_phieu", NpgsqlDbType.Numeric).Value = v_id_xn_phieu;
            m_command.Parameters.Add("v_id_xn_ten", NpgsqlDbType.Numeric).Value = v_id_xn_ten;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + s_schema_mmyy(v_mmyy) + ".xn_worksheet_ct(id,id_xn_phieu,id_xn_ten,stt,userid) values(:v_id,:v_id_xn_phieu,:v_id_xn_ten,:v_stt,:v_userid)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;

                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_id_xn_phieu", NpgsqlDbType.Numeric).Value = v_id_xn_phieu;
                    m_command.Parameters.Add("v_id_xn_ten", NpgsqlDbType.Numeric).Value = v_id_xn_ten;
                    m_command.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    m_command.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                    
                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                upd_xn_error(v_mmyy, ex.Message, m_computername, "xn_worksheetct");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public bool upd_xn_hc(string _mmyy, decimal m_id, DataTable dtvattu, int m_userid)
        {
            try
            {
                m_connection = new NpgsqlConnection(m_db_connectionstring);

                m_connection.Open();
                foreach (DataRow r in dtvattu.Rows)
                {
                    //m_x.upd_xn_hc(ammyy, decimal.Parse(m_id), int.Parse(r["id_ten"].ToString()), int.Parse(r["mahc"].ToString()), r["mavach"].ToString().Split('+')[0], r["mavach"].ToString(), r["soluong"].ToString(), int.Parse(m_userid));
                    try
                    {
                        m_sql = "insert into " + user + _mmyy + ".xn_hc(id,id_ten,mahc,sttt,mavach,soluong,userid) values (" + m_id.ToString() + "," + r["id_ten"].ToString() + "," + r["mahc"].ToString() + "," + r["mavach"].ToString().Split('+')[0] + "," + r["mavach"].ToString() + "," + r["soluong"].ToString() + "," + m_userid + ")";
                        m_command = new NpgsqlCommand(m_sql, m_connection);
                        m_command.CommandType = CommandType.Text;
                        m_command.ExecuteNonQuery();
                    }
                    catch (Exception exx) { }
                }
                //m_command.Dispose();
            }
            catch (NpgsqlException ex)
            {
                upd_xn_error(ex.Message, m_computername, "xn_hc");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
        public decimal f_get_id_xn_worksheet
        {
            get
            {
                try
                {
                    decimal _value = 1;
                    m_sql = "select nextval('medibvmmyy.xn_worksheet_id_seq');";
                    if (m_sql.IndexOf("medibvmmyy.") >= 0)
                    {
                        string ammyy = s_curmmyy;
                        m_sql = m_sql.Replace("medibvmmyy.", m_db_schemaroot + ammyy + ".");
                    }
                    m_sql = m_sql.Replace("medibv.", m_db_schemaroot + ".");
                    m_connection = new NpgsqlConnection(m_db_connectionstring);
                    m_connection.Open();
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    object obj = m_command.ExecuteScalar();
                    if (obj != null)
                    {
                        _value = decimal.Parse(obj.ToString());
                    }
                    return _value;
                }
                catch
                {
                    return 1;
                }
                finally
                {
                    m_connection.Dispose(); m_command.Dispose();
                }
            }

        }

    }
}
