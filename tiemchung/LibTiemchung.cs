using System;
using System.Xml;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Text;
using Npgsql;
using NpgsqlTypes;
using System.Windows.Forms;
using System.Drawing;
using LibMedi;
namespace tiemchung
{
    public class LibTiemchung
    {
        
        LibMedi.AccessData m = new LibMedi.AccessData();
        public string Msg = "Báo cáo 2007";
        private int iRownum = 1;
        public const string links_userid = "links", links_pass = "link7155019s20";
        string xxxxx = "Ð§Ì©Î«³²°Ô£";
        string sConn = "Server=192.168.1.14;Port=5432;User Id=medisoft;Password=links1920;Database=medisoft;Encoding=UNICODE;Pooling=true;";
        NpgsqlDataAdapter dest;
        NpgsqlConnection con;
        NpgsqlCommand cmd;        
        string sComputer = null;
        private int flag_language = 0;
        string sql = "",  owner = "medisoft", password = "links1920", userid = "medibv", database = "medisoft";
        private const string sformat = "dd/mm/yyyy";
        private DataSet ds = null;
        private string m_db_schemaroot = "medibv";
        private string vsql = "";
        private DataSet vds = null;
        private DataRow r1, r2;

        public string Xq = "02";
        public string Sa = "01";
        public string Ns = "03";
        public string Dtim = "04";
        public string CTSCan = "05";
        public string MRI = "06";
        public string Diennao = "07";
        public string CTG = "08";
        public string Luuhuyetnao = "09";

        public string insert = "ins", delete = "del", dutru = "dutru", duyet = "duyet";
        public string Maincode(string sql)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("..//..//..//xml//maincode.xml");
                XmlNodeList nodeLst = doc.GetElementsByTagName(sql);
                return nodeLst.Item(0).InnerText;
            }
            catch
            {
                ds = new DataSet();
                ds.ReadXml("..//..//..//xml//maincode.xml");
                DataColumn dc = new DataColumn();
                dc.ColumnName = sql;
                dc.DataType = Type.GetType("System.String");
                ds.Tables[0].Columns.Add(dc);
                ds.Tables[0].Rows[0][sql] = "";
                ds.WriteXml("..//..//..//xml//maincode.xml");
                return "";
            }
        }

        public LibTiemchung()
        {
            sComputer = System.Environment.MachineName.Trim().ToUpper();
            if (Maincode("Con") != "") sConn = Maincode("Con");
            if (Maincode("User") != "") userid = Maincode("User");
            if (Maincode("UserID") != "") owner = Maincode("UserID");
            if (Maincode("Password") != "") password = Maincode("Password");
            if (Maincode("Database") != "") database = Maincode("Database");
            if (Maincode("xxxxx") == "*****") password = decode(xxxxx).ToLower();
            
            sComputer = System.Environment.MachineName.Trim().ToUpper();
            sConn = "Server=" + Maincode("Ip") + ";Port=" + Maincode("Post") + ";User Id=" + owner + ";Password=" + password + ";Database=" + database + ";Encoding=UNICODE;Pooling=true;";
            upd_dmcomputer(sComputer);
            ds = m.get_data("select id,computer from " + userid + ".dmcomputer");
            DataRow r = m.getrowbyid(ds.Tables[0], "computer='" + sComputer + "'");
            if (r != null) iRownum = int.Parse(r["id"].ToString());
        }
        public void upd_dmcomputer(string m_computer)
        {
            sql = "update " + user + ".dmcomputer set computer=:m_computer where computer=:m_computer";
            con = new NpgsqlConnection(sConn);
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("m_computer", NpgsqlDbType.Varchar, 20).Value = m_computer;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close(); con.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".dmcomputer(id,computer) values (" + get_id_dmcomputer + ",'" + m_computer + "')";
                    m.execute_data(sql);
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message, sComputer, "dmcomputer");
            }
            finally
            {
                con.Close(); con.Dispose();
            }
        }
        private int get_id_dmcomputer
        {
            get
            {
                ds = m.get_data("select max(id) as id from " + user + ".dmcomputer");
                if (ds.Tables[0].Rows[0]["id"].ToString() == "") return 1;
                else return int.Parse(ds.Tables[0].Rows[0]["id"].ToString()) + 1;
            }
        }

        public bool upd_dmcomputer()
        {
            sql = "update " + user + ".dmcomputer set computer=:m_computer where computer=:m_computer";
            con = new NpgsqlConnection(sConn);
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("m_computer", NpgsqlDbType.Varchar).Value = System.Environment.MachineName;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close(); con.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".dmcomputer(id,computer) values (" + get_id_dmcomputer + ",'" + System.Environment.MachineName + "')";
                    m.execute_data(sql);
                }
            }
            catch (NpgsqlException ex)
            {
                return false;
            }
            finally
            {
                con.Close(); con.Dispose();
            }
            return true;
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

        public bool upd_tiemchung(string mabn, decimal maql, decimal mavv, string ngay, string benh, string diung, string phanungthuoc, string dongkinh, string ungthu, string benhbathang, string benhmotnam, string thai, string vacxin, string nhanxet, int userid)
        {
            sql = " update " + user + ".benhantc set benh=:m_benh,diung=:m_diung,phanungthuoc=:m_phanungthuoc,dongkinh=:m_dongkinh,ungthu=:m_ungthu,"+
                " benhbathang=:m_benhbathang,benhmotnam=:m_benhmotnam,thai=:m_thai,vacxin=:m_vacxin,nhanxet=:m_nhanxet,nguoinhap=:m_userid ,mabn=:m_mabn, "+
                " mavaovien=:m_mavv,ngay=to_timestamp(:m_ngay,'dd/mm/yyyy hh24:mi') where maql=:m_maql ";
            con = new NpgsqlConnection(sConn);
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("m_benh", NpgsqlDbType.Text).Value = benh;
                cmd.Parameters.Add("m_diung", NpgsqlDbType.Text).Value = diung;
                cmd.Parameters.Add("m_phanungthuoc", NpgsqlDbType.Text).Value = phanungthuoc;
                cmd.Parameters.Add("m_dongkinh", NpgsqlDbType.Text).Value = dongkinh;
                cmd.Parameters.Add("m_ungthu", NpgsqlDbType.Text).Value = ungthu;
                cmd.Parameters.Add("m_benhbathang", NpgsqlDbType.Text).Value = benhbathang;
                cmd.Parameters.Add("m_benhmotnam", NpgsqlDbType.Text).Value = benhmotnam;
                cmd.Parameters.Add("m_thai", NpgsqlDbType.Text).Value = thai;
                cmd.Parameters.Add("m_vacxin", NpgsqlDbType.Text).Value = vacxin;
                cmd.Parameters.Add("m_nhanxet", NpgsqlDbType.Text).Value = nhanxet;
                cmd.Parameters.Add("m_userid", NpgsqlDbType.Numeric).Value = userid;
                cmd.Parameters.Add("m_mabn", NpgsqlDbType.Varchar,10).Value = mabn;
                cmd.Parameters.Add("m_mavv", NpgsqlDbType.Numeric).Value = mavv;
                cmd.Parameters.Add("m_ngay", NpgsqlDbType.Varchar).Value = ngay == "" ? null : ngay;
                cmd.Parameters.Add("m_maql", NpgsqlDbType.Numeric).Value = maql;

                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".benhantc(mabn,maql,mavaovien,ngay,benh,diung,phanungthuoc,dongkinh,ungthu,benhbathang,benhmotnam,"+
                        "thai,vacxin,nhanxet,nguoinhap) values (:m_mabn,:m_maql,:m_mavv,to_timestamp(:m_ngay,'dd/mm/yyyy hh24:mi'),:m_benh,:m_diung,:m_phanungthuoc," +
                        ":m_dongkinh,:m_ungthu,:m_benhbathang,:m_benhmotnam,:m_thai,:m_vacxin,:m_nhanxet,:m_userid)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("m_mabn", NpgsqlDbType.Varchar).Value = mabn;
                    cmd.Parameters.Add("m_maql", NpgsqlDbType.Numeric).Value = maql;
                    cmd.Parameters.Add("m_mavv", NpgsqlDbType.Numeric).Value = mavv;
                    cmd.Parameters.Add("m_ngay", NpgsqlDbType.Varchar).Value = ngay == "" ? null : ngay;
                    cmd.Parameters.Add("m_benh", NpgsqlDbType.Text).Value = benh;
                    cmd.Parameters.Add("m_diung", NpgsqlDbType.Text).Value = diung;
                    cmd.Parameters.Add("m_phanungthuoc", NpgsqlDbType.Text).Value = phanungthuoc;
                    cmd.Parameters.Add("m_dongkinh", NpgsqlDbType.Text).Value = dongkinh;
                    cmd.Parameters.Add("m_ungthu", NpgsqlDbType.Text).Value = ungthu;
                    cmd.Parameters.Add("m_benhbathang", NpgsqlDbType.Text).Value = benhbathang;
                    cmd.Parameters.Add("m_benhmotnam", NpgsqlDbType.Text).Value = benhmotnam;
                    cmd.Parameters.Add("m_thai", NpgsqlDbType.Text).Value = thai;
                    cmd.Parameters.Add("m_vacxin", NpgsqlDbType.Numeric).Value = vacxin;
                    cmd.Parameters.Add("m_nhanxet", NpgsqlDbType.Text).Value = nhanxet;
                    cmd.Parameters.Add("m_userid", NpgsqlDbType.Text).Value = userid;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message, sComputer, "benhantc");
                return false;
            }
            finally
            {
                cmd.Dispose();
                con.Dispose();
            }
            return true;
        }
        public string user { get { return userid; } }

        public int iTreem6
        {
            get
            {
                try
                {
                    return int.Parse(m.get_data("select ten from medibv.thongso where id=42").Tables[0].Rows[0][0].ToString());
                }
                catch { return 6; }
            }
        }
        public void upd_error(string m_ngay, string m_message, string m_computer, string m_table)
        {
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            if (!bMmyy(mmyy(m_ngay))) return;
            sql = "insert into " + user + mmyy(m_ngay) + ".error(message,computer,tables) values (:m_message,:m_computer,:m_table)";
            con = new NpgsqlConnection(sConn);
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("m_message", NpgsqlDbType.Text).Value = m_message;
                cmd.Parameters.Add("m_computer", NpgsqlDbType.Varchar, 20).Value = m_computer;
                cmd.Parameters.Add("m_table", NpgsqlDbType.Varchar, 20).Value = m_table;
                cmd.ExecuteNonQuery();
            }
            catch { }
            finally
            {
                cmd.Dispose();
                con.Close(); con.Dispose();
            }
        }
        public string mmyy(string ngay)
        {
            return ngay.Substring(3, 2) + ngay.Substring(8, 2);
        }

        public bool bMmyy(string m_mmyy)
        {
            return m.get_data("select * from " + user + ".table where mmyy='" + ((m_mmyy.Trim().Length == 4) ? m_mmyy : m.mmyy(m_mmyy)) + "'").Tables[0].Rows.Count > 0;
        }

        public void upd_error(string m_message, string m_computer, string m_table)
        {
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            string sql1 = "insert into " + user + ".error(message,computer,tables) values (:m_message,:m_computer,:m_table)";
            con = new NpgsqlConnection(sConn);
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(sql1, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("m_message", NpgsqlDbType.Text).Value = m_message;
                cmd.Parameters.Add("m_computer", NpgsqlDbType.Varchar, 20).Value = m_computer;
                cmd.Parameters.Add("m_table", NpgsqlDbType.Varchar, 20).Value = m_table;
                cmd.ExecuteNonQuery();
            }
            catch { }
            finally
            {
                cmd.Dispose();
                con.Close(); con.Dispose();
            }
        }

    }

}
