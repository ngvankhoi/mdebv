using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Npgsql;
using NpgsqlTypes;
using System.Xml;
using System.Windows.Forms;
namespace DAL
{
    public class Accessdata:IDisposable
    {
        bool b_chuyenlai = false;
        string sConn = "Server=0.0.0.0;Port=5432;User Id=medisoft;Password=links1920;Database=medisoft;Encoding=UNICODE;Pooling=true;";
        NpgsqlDataAdapter dest;
        NpgsqlConnection con, con_client, con_server;
        NpgsqlCommand cmd;
        string sComputer = "";
        string  schema = "", owner = "medisoft", password = "links1920", database = "medisoft", xxxxx = "Ð§Ì©Î«³²°Ô£";
        public  string userid="medibv";
        DataSet ds = null;
        //DataTable dtChinhanh = new DataTable();
        private string sql="";
        private string _rdbName = "";
        private string _port;
        private string _host;
        private string _userdb = "medisoft";
        private string _passworddb = "links1920";
        private string _server;
        private string _datbasename;

        private string user = "medibv";
        public static string error = "";
        public Accessdata()
        {
            sComputer = System.Environment.MachineName.Trim().ToUpper();
            if (Maincode("Con") != "") sConn = Maincode("Con");
            if (Maincode("User") != "") userid = Maincode("User");
            if (Maincode("UserID") != "") owner = Maincode("UserID");
            if (Maincode("Password") != "") password = Maincode("Password");
            if (Maincode("Database") != "") database = Maincode("Database");
            if (Maincode("xxxxx") == "*****") password = decode(xxxxx).ToLower();
            sConn = "Server=" + Maincode("Ip") + ";Port=" + Maincode("Post") + ";User Id=" + owner + ";Password=" + password + ";Database=" + database + ";Encoding=UNICODE;Pooling=true;";
            //dtChinhanh = get_data("select id,host as ip,port,databasename as database,userdb as user,passworddb as password from "+userid+".dmchinhanh");
        }
        /// <summary>
        /// Thuộc tính tên database của máy remote để lấy dữ liệu.get,set
        /// </summary>
        public string DataBaseName
        {
            get { return _rdbName; }
            set { _rdbName = value; }
        }
        /// <summary>
        /// Thuộc tính port của database của máy remote dùng để kết nối vào máy remote. get,set
        /// </summary>
        public string Port
        {
            get { return _port; }
            set { _port = value; }
        }
        /// <summary>
        /// Thuộc tính host là địa chỉ IP của máy cần remote, nó cũng có thể là tên máy. get,set
        /// </summary>
        public string Host
        {
            get { return _host; }
            set { _host = value; }
        }
        /// <summary>
        /// Username của database máy remote. mặc định medisoft. get,set
        /// </summary>
        public string UserNameDatabase
        {
            get { return _userdb; }
            set { _userdb = value; }
        }
        /// <summary>
        /// password để vào database máy remote.get,set
        /// </summary>
        public string User
        {
            get { return user; }
        }
        public string PasswordDatabase
        {
            get { return _passworddb; }
            set { _passworddb = value; }
        }
        public string ServerName
        {
            get { return _server; }
            set { _server = value; }
        }
        public string DatabaseName
        {
            get { return _datbasename; }
            set { _datbasename = value; }
        }
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
        public bool execute_data(string sql1)
        {
            try
            {
                if (con != null)
                {
                    con.Close(); con.Dispose();
                }
                con = new NpgsqlConnection(sConn);
                con.Open();
                cmd = new NpgsqlCommand(sql1, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close(); con.Dispose();
                return true;
            }
            catch (NpgsqlException ex)
            {
                error = ex.Message;
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
        public bool execute_data(string sql1,string sconn)
        {
            try
            {
                if (con != null)
                {
                    con.Close(); con.Dispose();
                }
                con = new NpgsqlConnection(sconn);
                con.Open();
                cmd = new NpgsqlCommand(sql1, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close(); con.Dispose();
                return true;
            }
            catch (NpgsqlException ex)
            {
                error = ex.Message;
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
        /// <summary>
        /// Thuc thi Query --> tra ve loi: 1: ket noi loi; 2: cau sql loi
        /// </summary>
        /// <param name="sql1"></param>
        /// <param name="sconn"></param>
        /// <returns></returns>
        public int execute_sql(string sql1, string sconn)
        {
            int i_error = 0;

            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sconn);
            try
            {
                con.Open();
            }
            catch 
            {
                i_error = 1;
                return i_error;
            }
            cmd = new NpgsqlCommand(sql1, con);
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close(); con.Dispose();
                i_error = 0;

            }
            catch (NpgsqlException ex)
            {

                error = ex.ToString();//.Message;
                i_error = 2;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return i_error;
        }
        /// <summary>
        /// Phương thức được dùng để lấy số liệu từ máy trạm về máy chủ.
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="table"></param>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="client"></param>
        public void Syschronise(string schema,string table,string key, string field,Client client)
        {
            try
            {
                // chuyển đi = 2 là trạng thái chờ chuyển.
                // chuyển đi = 1 là đã chuyển.
                // chuyển đi = 0 là chưa chuyển.
                // tương tự cho lấy về.
                bool ok = false;
                // thực hiện update table cần đồng bộ hóa của máy remote vào trạng thái chờ.
                if(client.STT==1)
                    sql = "update " + schema + "." + table + "@" + client.DbLink + " set chuyendi='www'||substr(chuyendi," + (client.STT + 3).ToString() + ") where substr(chuyendi," + (client.STT).ToString() + ",3)='000'";
                else
                    sql = "update " + schema + "." + table + "@" + client.DbLink + " set chuyendi=substr(chuyendi,1," + (client.STT-1).ToString() + ")||'www'||substr(chuyendi," + (client.STT + 3).ToString() + ") where substr(chuyendi," + (client.STT).ToString() + ",3)='000'";
                ok = execute_data(sql);
                //cập nhật database giữa máy remote với máy server đang kết nối.
                sql = "insert into  " + schema + "." + table + "(" + field + ") (select " + field +
                    "  from " + schema + "." + table + "@" + client.DbLink + " where substr(chuyendi," + (client.STT).ToString() + ",3)='www' and " + dieukien(key, schema, table,client,true)+")";
                    //key+" not in(select "+key+"  from "+schema+"."+table+"))";
               if(ok) ok = execute_data(sql);
                // update trạng thái nhận được của máy server
                if (client.STT == 1)
                    sql = "update " + schema + "." + table + " set chuyendi='111'||substr(chuyendi," + (client.STT + 3).ToString() + ") where substr(chuyendi," + client.STT + ",3)='www'";
                else
                    sql = "update " + schema + "." + table +" set chuyendi=substr(chuyendi,1," + (client.STT - 1).ToString() + ")||'111'||substr(chuyendi," + (client.STT + 3).ToString() + ") where substr(chuyendi," + client.STT + ",3)='www'";
               if(ok) ok = execute_data(sql);
                // update từ trạng thái chờ sang trang thái đã thực hiện chuyển. 
                if (client.STT == 1)
                    sql = "update " + schema + "." + table + "@" + client.DbLink + " set chuyendi='111'||substr(chuyendi," + (client.STT + 3).ToString() + ") where substr(chuyendi," + client.STT + ",3)='www'";
                else
                    sql = "update " + schema + "." + table + "@" + client.DbLink + " set chuyendi=substr(chuyendi,1," + (client.STT-1).ToString() + ")||'111'||substr(chuyendi," + (client.STT + 3).ToString() + ") where substr(chuyendi," + client.STT + ",3)='www'";
                if (ok) execute_data(sql);
                // Lưu id của giao dịch vào bảng section.
                //sql = "insert into medibv.section(id,noidung," + client.ServerName + ") values(" + idsection + ",'" + table + "',1)";
                //execute_data(sql);
            }
            catch { }

        }
        /// <summary>
        /// Phương thức dùng để đẩy số liệu từ máy chủ xuống máy trạm.
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="table"></param>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="client"></param>
        /// <param name="send"></param>
        public void Syschronise(string schema,string table,string key, string field,Client client,bool send)
        {
            try
            {
                // chuyển đi = 2 là trạng thái chờ chuyển.
                // chuyển đi = 1 là đã chuyển.
                // chuyển đi = 0 là chưa chuyển.
                // tương tự cho lấy về.
                bool ok = false;
                // thực hiện update table cần đồng bộ hóa vào trạng thái chờ.
                if(client.STT==1)
                    sql = "update " + schema + "." + table + " set chuyendi='www'||substr(chuyendi," + (client.STT + 3).ToString() + ") where substr(chuyendi," + (client.STT).ToString() + ",3)='000'";
                else
                    sql = "update " + schema + "." + table  + " set chuyendi=substr(chuyendi,1," + (client.STT-1).ToString() + ")||'www'||substr(chuyendi," + (client.STT + 3).ToString() + ") where substr(chuyendi," + (client.STT).ToString() + ",3)='000'";
                ok = execute_data(sql);
                //cập nhật database giữa máy remote với máy server đang kết nối.
                sql = "insert into  " + schema + "." + table + "@" + client.DbLink + "(" + field + ") (select " + field +
                    "  from " + schema + "." + table  + " where substr(chuyendi," + (client.STT).ToString() + ",3)='www' and " + dieukien(key, schema, table,client);
                    //key+" not in(select "+key+"  from "+schema+"."+table+"))";
               if(ok) ok = execute_data(sql);
                // update trạng thái nhận được của máy server được remote.
                if (client.STT == 1)
                    sql = "update " + schema + "." + table + "@" + client.DbLink + " set chuyendi='111'||substr(chuyendi," + (client.STT + 3).ToString() + ") where substr(chuyendi," + client.STT + ",3)='www'";
                else
                    sql = "update " + schema + "." + table + "@" + client.DbLink + " set chuyendi=substr(chuyendi,1," + (client.STT - 1).ToString() + ")||'111'||substr(chuyendi," + (client.STT + 3).ToString() + ") where substr(chuyendi," + client.STT + ",3)='www'";
               if(ok) ok = execute_data(sql);
                // update từ trạng thái chờ sang trang thái đã thực hiện chuyển. 
                if (client.STT == 1)
                    sql = "update " + schema + "." + table  + " set chuyendi='111'||substr(chuyendi," + (client.STT + 3).ToString() + ") where substr(chuyendi," + client.STT + ",3)='www'";
                else
                    sql = "update " + schema + "." + table  + " set chuyendi=substr(chuyendi,1," + (client.STT-1).ToString() + ")||'111'||substr(chuyendi," + (client.STT + 3).ToString() + ") where substr(chuyendi," + client.STT + ",3)='www'";
                if (ok) execute_data(sql);
                // Lưu id của giao dịch vào bảng section.
                //sql = "insert into medibv.section(id,noidung," + client.ServerName + ") values(" + idsection + ",'" + table + "',1)";
                //execute_data(sql);
            }
            catch { }

        }
        /// <summary>
        /// phương thức sử dụng posgres làm trung gian giữa hai server.
        /// client là máy sẽ được lấy data vê
        /// server là máy sẽ được nhận data
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="table"></param>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="client"></param>
        /// <param name="Server"></param>
        public void Syschronise2Server(string schema, string table, string key, string field, Client client,Client Server) 
        {
            try
            {
                // chuyển đi = 2 là trạng thái chờ chuyển.
                // chuyển đi = 1 là đã chuyển.
                // chuyển đi = 0 là chưa chuyển.
                // tương tự cho lấy về.
                error = "";
                bool ok = false;
                // thực hiện update table cần đồng bộ hóa của máy remote vào trạng thái chờ.
                if (client.STT == 1)
                    sql = "update " + schema + "." + table + "@" + client.DbLink + " set chuyendi='www'||substr(chuyendi," + (client.STT + 3).ToString() + ") where substr(chuyendi," + (client.STT).ToString() + ",3)='000'";
                else
                    sql = "update " + schema + "." + table + "@" + client.DbLink + " set chuyendi=substr(chuyendi,1," + (client.STT - 1).ToString() + ")||'www'||substr(chuyendi," + (client.STT + 3).ToString() + ") where substr(chuyendi," + (client.STT).ToString() + ",3)='000'";
                ok = execute_data(sql);
                //cập nhật database giữa máy remote với máy server đang kết nối.
                sql = "insert into  " + schema + "." + table+"@"+Server.DbLink + "(" + field + ") (select " + field +
                    "  from " + schema + "." + table + "@" + client.DbLink + " where substr(chuyendi," + (client.STT).ToString() + ",3)='www' " + dieukien(key, schema, table,Server)+")";
                //key+" not in(select "+key+"  from "+schema+"."+table+"))";
                if (ok) ok = execute_data(sql);
                // update trạng thái nhận được của máy server
                if (client.STT == 1)
                    sql = "update " + schema + "." + table+"@"+Server.DbLink + " set chuyendi='111'||substr(chuyendi," + (client.STT + 3).ToString() + ") where substr(chuyendi," + client.STT + ",3)='www'";
                else
                    sql = "update " + schema + "." + table+"@"+Server.DbLink + " set chuyendi=substr(chuyendi,1," + (client.STT - 1).ToString() + ")||'111'||substr(chuyendi," + (client.STT + 3).ToString() + ") where substr(chuyendi," + client.STT + ",3)='www'";
                if (ok) ok = execute_data(sql);
                // update từ trạng thái chờ sang trang thái đã thực hiện chuyển. 
                if (client.STT == 1)
                    sql = "update " + schema + "." + table + "@" + client.DbLink + " set chuyendi='111'||substr(chuyendi," + (client.STT + 3).ToString() + ") where substr(chuyendi," + client.STT + ",3)='www'";
                else
                    sql = "update " + schema + "." + table + "@" + client.DbLink + " set chuyendi=substr(chuyendi,1," + (client.STT - 1).ToString() + ")||'111'||substr(chuyendi," + (client.STT + 3).ToString() + ") where substr(chuyendi," + client.STT + ",3)='www'";
                if (ok) execute_data(sql);
                //cập nhật sự kiện 
                if (!ok)
                {
                    upd_Events(DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.Hour.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Second.ToString().PadLeft(2, '0'), "Auto", client.Host, Server.Host, schema, table, error,"0", sComputer, "", Server);
                }
            }
            catch { }

        }
        /// <summary>
        /// phương thức dùng để tách các table có nhiều hơn 1 key.
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="_chema"></param>
        /// <param name="_table"></param>
        /// <returns></returns>
        private string dieukien(string keys,string _schema,string _table,Client _server)
        {
            string dk = "";
            if (keys != "")
            {
                string[] arrkeys = keys.Split(',');
                for (int i = 0; i < arrkeys.Length; i++)
                {
                    if (dk == "") dk = " and "+arrkeys[i] + " not in(select " + arrkeys[i] + "  from " + _schema + "." + _table + "@" + _server.DbLink + ")";
                    else
                        dk += " and " + arrkeys[i] + " not in(select " + arrkeys[i] + "  from " + _schema + "." + _table + "@" + _server.DbLink + ")";
                }
            }
            return dk;
        }
        /// <summary>
        /// phương thức dùng để tách các table có nhiều hơn 1 key.
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="_chema"></param>
        /// <param name="_table"></param>
        /// <returns></returns>
        private string dieukien(string keys, string _schema, string _table, Client clien,bool bClient)
        {
            string[] arrkeys = keys.Split(',');
            string dk = "";
            for (int i = 0; i < arrkeys.Length; i++)
            {
                if (dk == "") dk = " and " +arrkeys[i] + " not in(select " + arrkeys[i] + "  from " + _schema + "." + _table + "@" + clien.DbLink + ")";
                else
                    dk += " and " + arrkeys[i] + " not in(select " + arrkeys[i] + "  from " + _schema + "." + _table + "@" + clien.DbLink + ")";
            }
            return dk;
        }
        public long capid(string ma)
        {
			sql="update "+user+".syn_capid set id=id+1 where ten='"+ma+"'";
			con=new NpgsqlConnection(sConn);
			con.Open();
            cmd = new NpgsqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
			int irec=cmd.ExecuteNonQuery();
			cmd.Dispose();
			if (irec==0)
			{
				sql="insert into "+user+".syn_capid(id,ten) values (1,'"+ma+"')";
				cmd=new NpgsqlCommand(sql,con);
				cmd.CommandType=CommandType.Text;
				cmd.ExecuteNonQuery();
				cmd.Dispose();
			}
			sql="select id from "+user+".syn_capid where ten='"+ma+"'";
			cmd=new NpgsqlCommand(sql,con);
			cmd.CommandType=CommandType.Text;
			dest=new NpgsqlDataAdapter(cmd);
			ds=new DataSet();
			dest.Fill(ds);	
			cmd.Dispose();				
			con.Close();con.Dispose();
            return long.Parse(ds.Tables[0].Rows[0][0].ToString());
        }
        public DataSet get_data(string asql)
        {
            DataSet ds1 = new DataSet();
            try
            {
                if (ds1 != null)
                {
                    ds1.Dispose();
                    ds1 = null;
                }
                if (con != null)
                {
                    con.Close(); con.Dispose();
                }
                ds1 = new DataSet();
                con = new NpgsqlConnection(sConn);
                con.Open();
                asql = asql.Replace("medibv.", user + ".");
                cmd = new NpgsqlCommand(asql, con);
                cmd.CommandType = CommandType.Text;
                dest = new NpgsqlDataAdapter(cmd);
                dest.Fill(ds1);
                cmd.Dispose();
                con.Close(); con.Dispose();
            }
            catch (NpgsqlException ex)
            {
                //upd_error(asql + "-" + ex.Message.ToString().Trim(), sComputer, "?");
            }
            return ds1;
        }
        public DataSet get_data(string asql,string Sconnecting)
        {
            if (Sconnecting == "") Sconnecting = sConn;
            DataSet ds1 = new DataSet();
            try
            {
                if (ds1 != null)
                {
                    ds1.Dispose();
                    ds1 = null;
                }
                if (con != null)
                {
                    con.Close(); con.Dispose();
                }
                ds1 = new DataSet();
                con = new NpgsqlConnection(Sconnecting);
                con.Open();
                asql = asql.Replace("medibv.", user + ".");                
                cmd = new NpgsqlCommand(asql, con);
                cmd.CommandType = CommandType.Text;
                dest = new NpgsqlDataAdapter(cmd);
                dest.Fill(ds1);
                cmd.Dispose();
                con.Close(); con.Dispose();
            }
            catch (NpgsqlException ex)
            {
                //upd_error(asql + "-" + ex.Message.ToString().Trim(), sComputer, "?");
            }
            return ds1;
        }

        public DataSet get_data_mmyy(string str, string tu, string den, bool khoangcach)
        {
            DataSet tmp = new DataSet();
            string sql = "";
            DateTime dt1 = (khoangcach) ? StringToDate(tu).AddDays(-22) : StringToDate(tu);
            DateTime dt2 = (khoangcach) ? StringToDate(den).AddDays(22) : StringToDate(den);
            int y1 = dt1.Year, m1 = dt1.Month;
            int y2 = dt2.Year, m2 = dt2.Month;
            int itu, iden;
            string mmyy = "";
            bool be = true;
            for (int i = y1; i <= y2; i++)
            {
                itu = (i == y1) ? m1 : 1;
                iden = (i == y2) ? m2 : 12;
                for (int j = itu; j <= iden; j++)
                {
                    mmyy = j.ToString().PadLeft(2, '0') + i.ToString().Substring(2, 2);
                    if (bMmyy(mmyy))
                    {
                        sql = str.Replace("xxx.", user + mmyy + ".");
                        sql = sql.Replace("medibvmmyy.", user + mmyy + ".");
                        sql = sql.Replace("medibv.", user + ".");
                        if (be || tmp == null)
                        {
                            tmp = get_data(sql);
                            be = false;
                        }
                        else tmp.Merge(get_data(sql));
                    }
                }
            }
            
            return tmp;
        }
        public string ngayhienhanh_server
        {
            get
            {
                return get_data("select to_char(now(),'dd/MM/yyyy hh24:mi')").Tables[0].Rows[0][0].ToString();
            }
        }
        public System.DateTime StringToDate(string s)
        {
            s = (s == "" || s == null) ? ngayhienhanh_server.Substring(0, 10) : s;
            string[] format ={ "dd/MM/yyyy" };
            return System.DateTime.ParseExact(s.Substring(0, 10), format, System.Globalization.DateTimeFormatInfo.CurrentInfo, System.Globalization.DateTimeStyles.None);
        }
        public bool bMmyy(string m_mmyy)
        {
            return get_data("select * from " + user + ".table where mmyy='" + ((m_mmyy.Trim().Length == 4) ? m_mmyy : mmyy(m_mmyy)) + "'").Tables[0].Rows.Count > 0;
        }
        public string mmyy(string ngay)
        {
            if (ngay.Length < 10) ngay = ngayhienhanh_server.Substring(0, 10);
            return ngay.Substring(3, 2) + ngay.Substring(8, 2);
        }
        public void execute_data_mmyy(string str, string tu, string den, bool khoangcach)
        {            
            string sql = "";
            DateTime dt1 = (khoangcach) ? StringToDate(tu).AddDays(-22) : StringToDate(tu);
            DateTime dt2 = (khoangcach) ? StringToDate(den).AddDays(22) : StringToDate(den);
            int y1 = dt1.Year, m1 = dt1.Month;
            int y2 = dt2.Year, m2 = dt2.Month;
            int itu, iden;
            string mmyy = "";
            for (int i = y1; i <= y2; i++)
            {
                itu = (i == y1) ? m1 : 1;
                iden = (i == y2) ? m2 : 12;
                for (int j = itu; j <= iden; j++)
                {
                    mmyy = j.ToString().PadLeft(2, '0') + i.ToString().Substring(2, 2);
                    if (bMmyy(mmyy))
                    {
                        sql = str.Replace("xxx", user + mmyy);
                        execute_data(sql);
                    }
                }
            }
        }
        public DataSet get_data_Schema(string asql)
        {
            DataSet ds1 = new DataSet();
            try
            {
                if (ds1 != null)
                {
                    ds1.Dispose();
                    ds1 = null;
                }
                if (con != null)
                {
                    con.Close(); con.Dispose();
                }
                ds1 = new DataSet();
                con = new NpgsqlConnection(sConn);
                con.Open();
                cmd = new NpgsqlCommand(asql, con);
                cmd.CommandType = CommandType.Text;
                dest = new NpgsqlDataAdapter(cmd);
                dest.FillSchema(ds1, SchemaType.Mapped);
                cmd.Dispose();
                con.Close(); con.Dispose();
            }
            catch (NpgsqlException ex)
            {
                //upd_error(asql + "-" + ex.Message.ToString().Trim(), sComputer, "?");
            }
            return ds1;
        }
        public List<Client> getClient(Client server)
        {
                List<Client> list = new List<Client>();
                sql = "select * from medibv.client@"+server.DbLink;
                DataSet ds1 = new DataSet();
                ds1 = get_data(sql);
                try
                {
                    foreach (DataRow row in ds1.Tables[0].Rows)
                    {
                        try
                        {
                            Client client = new Client(row["HOST"].ToString(), row["Port"].ToString(), row["databasename"].ToString(), row["userdb"].ToString(), row["passworddb"].ToString(), row["servername"].ToString());
                            client.ID = long.Parse(row["id"].ToString());
                            client.DbLink = row["dblinks"].ToString();
                            list.Add(client);
                        }
                        catch
                        { }
                    }
                }
                catch { }
            
            return list;
        }
        public List<Client> getClient()
        {
            List<Client> list = new List<Client>();
            sql = "select * from medibv.client order by id";
            DataSet ds1 = new DataSet();
            ds1 = get_data(sql);
            try
            {
                foreach (DataRow row in ds1.Tables[0].Rows)
                {
                    try
                    {
                        Client client = new Client(row["HOST"].ToString(), row["Port"].ToString(), row["databasename"].ToString(), row["userdb"].ToString(), row["passworddb"].ToString(), row["servername"].ToString());
                        client.ID = long.Parse(row["id"].ToString());
                        client.DbLink = row["dblinks"].ToString();
                        client.ImagePath = row["imagepath"].ToString();
                        client.ImagePath_BN  = row["imagepath_hinhbn"].ToString();
                        client.ImagePath_Chungtu = row["imagepath_hinhchungtu"].ToString();
                        client.DatabaseName = row["databasename"].ToString();
                        list.Add(client);
                    }
                    catch
                    { }
                }
            }
            catch { }
            return list;
        }
        public bool LuuClient(Client clien, Client server)
        {
            sql = "update medibv.client@" + server.DbLink + " set host='" + clien.Host + "',port='" + clien.Port + "',databasename='" + clien.DatabaseName + "',userdb='" + clien.Userdb + "',passworddb='" + clien.Passworddb + "',servername='" + clien.ServerName + "' where id=" + clien.ID + " and dblinks='" + clien.DbLink + "'";
            con = new NpgsqlConnection(sConn);
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into medibv.client@" + server.DbLink + "(id,host,port,databasename,userdb,passworddb,servername,STT,dblinks) values (" + clien.ID + ",'" + clien.Host + "','" + clien.Port + "','" + clien.DatabaseName + "','" + clien.Userdb + "','" + clien.Passworddb + "','" + clien.ServerName + "'," + clien.STT + ",'" + clien.DbLink + "')";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                error = ex.Message;
                return false;
            }
            finally
            {

                con.Close(); con.Dispose();
            }
            return true;
        }
        public bool LuuClient(Client clien)
        {
            sql = "update " + User + ".client set host='" + clien.Host + "',port='" + clien.Port +
                "',databasename='" + clien.DatabaseName + "',userdb='" + clien.Userdb + "',passworddb='" +
                clien.Passworddb + "',servername='" + clien.ServerName + "',imagepath=:s_path_cdha, imagepath_hinhbn=:s_path_hinhbn, imagepath_hinhchungtu=:s_path_hinhchungtu where id=" + clien.ID +                
                " and dblinks='" + clien.DbLink + "'";
            con = new NpgsqlConnection(sConn);
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("s_path_cdha", NpgsqlDbType.Varchar).Value  = clien.ImagePath;
                cmd.Parameters.Add("s_path_hinhbn", NpgsqlDbType.Varchar).Value  = clien.ImagePath_BN;
                cmd.Parameters.Add("s_path_hinhchungtu", NpgsqlDbType.Varchar).Value = clien.ImagePath_Chungtu;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + User + ".client(id,host,port,databasename,userdb,passworddb,servername,STT,dblinks,imagepath,imagepath_hinhbn,imagepath_hinhchungtu) " +
                        " values (" + clien.ID + ",'" + clien.Host + "','" + clien.Port + "','" + clien.DatabaseName + "','" + clien.Userdb + "','" + clien.Passworddb + "','" + clien.ServerName + "'," + clien.STT + ",'" + clien.DbLink + "',:s_path_cdha,:s_path_hinhbn,:s_path_hinhchungtu)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("s_path_cdha", NpgsqlDbType.Varchar).Value  = clien.ImagePath;
                    cmd.Parameters.Add("s_path_hinhbn", NpgsqlDbType.Varchar).Value  = clien.ImagePath_BN;
                    cmd.Parameters.Add("s_path_hinhchungtu", NpgsqlDbType.Varchar).Value = clien.ImagePath_Chungtu;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                error = ex.Message;
                return false;
            }
            finally
            {

                con.Close(); con.Dispose();
            }
            return true;
        }
        public bool XoaClient(Client client)
        {
            sql = "DROP PUBLIC DATABASE LINK "+client.DbLink;
            execute_data(sql);
            //if (execute_data(sql))
            //{
                sql = "delete from "+User+".client where id="+client.ID+" and dblinks='"+client.DbLink+"'";
                return execute_data(sql);
            //}
            //return false;
        }
        /// <summary>
        /// phương thức được dùng để thêm field chuyendi vào các table được đồng bộ hóa.
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="table"></param>
        /// <param name="valueDefault"></param>
        /// <param name="dblink"></param>
        /// <returns></returns>
        public bool AlterTable(string schema, string table,string valueDefault,Client server)
        {
            string _sConn = "Server=" + server.Host + ";Port=" + server.Port + ";User Id=" + server.Userdb + ";Password=" + server.Passworddb + ";Database=" + server.DatabaseName + ";Encoding=UNICODE;Pooling=true;";
            sql = "ALTER TABLE " + schema + "." + table + " add chuyendi text not null default '" + valueDefault + "'";
            try
            {
                string sql1 = "select chuyendi from " + schema + "." + table;
                DataTable tmp = get_data(sql1, _sConn).Tables[0];
                return true;
            }
            catch
            {
                return execute_data(sql, _sConn);
            }
           
        }

        /// <summary>
        /// phương thức được dùng để thêm field chuyendi vào các table được đồng bộ hóa.
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="table"></param>
        /// <param name="valueDefault"></param>
        /// <param name="dblink"></param>
        /// <returns></returns>
        public void Add_chuyendi_to_table(DataTable dt, string valueDefault, Client server, int khoang_cach_ngay)
        {
            string _sConn = "";
            if (server != null) _sConn = "Server=" + server.Host + ";Port=" + server.Port + ";User Id=" + server.Userdb + ";Password=" + server.Passworddb + ";Database=" + server.DatabaseName + ";Encoding=UNICODE;Pooling=true;";
            else _sConn = "";
            DateTime tn = DateTime.Now.AddDays(-(double)khoang_cach_ngay);
            DateTime dn = DateTime.Now.AddDays((double)khoang_cach_ngay);
            DataSet lds;
            int y1 = tn.Year, y2 = dn.Year;
            int m1 = tn.Month, m2 = dn.Month;
            int itu = 0, iden = 0;
            for (int j = y1; j <= y2; j++)
            {
                itu = (j == y1) ? m1 : 1;
                iden = (j == y2) ? m2 : 12;
                for (int i = itu; i <= iden; i++)
                {

                    string mmyy = i.ToString().PadLeft(2, '0') + j.ToString().Substring(2, 2);
                    foreach (DataRow row in dt.Rows)
                    {
                        if (bShemaValid(row["schema_name"].ToString().Replace("xxx", mmyy), _sConn))
                        {
                            lds = get_data("select chuyendi from " + row["schema_name"].ToString().Replace("xxx", mmyy) + "." + row["table_name"].ToString() + " where 1=2",_sConn);

                            if (lds == null || lds.Tables.Count <= 0) 
                            {
                                sql = "ALTER TABLE " + row["schema_name"].ToString().Replace("xxx", mmyy) + "." + row["table_name"].ToString() +
                                    " add chuyendi varchar(300) default '" + valueDefault + "'";
                                if (_sConn != "")
                                    execute_data(sql, _sConn);
                                else
                                    execute_data(sql);
                            }
                        }
                    }
                }
            }
        }
        public void drop_notnull_chuyendi_to_table(DataTable dt, string valueDefault, Client server, int khoang_cach_ngay)
        {
            string _sConn = "";
            if (server != null) _sConn = "Server=" + server.Host + ";Port=" + server.Port + ";User Id=" + server.Userdb + ";Password=" + server.Passworddb + ";Database=" + server.DatabaseName + ";Encoding=UNICODE;Pooling=true;";
            DateTime tn = DateTime.Now.AddDays(-(double)khoang_cach_ngay);
            DateTime dn = DateTime.Now.AddDays((double)khoang_cach_ngay);
            for (int j = tn.Year; j <= dn.Year; j++)
            {
                for (int i = tn.Month; i <= dn.Month; i++)
                {
                    string mmyy = i.ToString().PadLeft(2, '0') + j.ToString().Substring(2, 2);
                    foreach (DataRow row in dt.Rows)
                    {
                        if (bShemaValid(row["schema_name"].ToString().Replace("xxx", mmyy)))
                        {
                            sql = "ALTER TABLE " + row["schema_name"].ToString().Replace("xxx", mmyy) + "." + row["table_name"].ToString() +
                                " alter chuyendi drop not null ";
                            if (_sConn != "")
                                execute_data(sql, _sConn);
                            else
                                execute_data(sql);
                        }
                    }
                }
            }
        }
        public void Set_chuyendi_to_1(DataTable dt, string valueDefault, Client server, int khoang_cach_ngay)
        {
            string _sConn = "";
            if (server != null) _sConn = "Server=" + server.Host + ";Port=" + server.Port + ";User Id=" + server.Userdb + ";Password=" + server.Passworddb + ";Database=" + server.DatabaseName + ";Encoding=UNICODE;Pooling=true;";
            DateTime tn = DateTime.Now.AddDays(-(double)khoang_cach_ngay);
            DateTime dn = DateTime.Now.AddDays((double)khoang_cach_ngay);
            for (int j = tn.Year; j <= dn.Year; j++)
            {
                for (int i = tn.Month; i <= dn.Month; i++)
                {
                    string mmyy = i.ToString().PadLeft(2, '0') + j.ToString().Substring(2, 2);
                    foreach (DataRow row in dt.Rows)
                    {
                        if (bShemaValid(row["schema_name"].ToString().Replace("xxx", mmyy)))
                        {
                            sql = "update " + row["schema_name"].ToString().Replace("xxx", mmyy) + "." + row["table_name"].ToString() +
                                " set chuyendi ='" + valueDefault + "'";
                            if (_sConn != "")
                                execute_data(sql, _sConn);
                            else
                                execute_data(sql);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// phương thức được dùng để thêm field chuyendi vào các table được đồng bộ hóa.
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="table"></param>
        /// <param name="valueDefault"></param>
        /// <param name="dblink"></param>
        /// <returns></returns>
        public bool ModifyField(string schema, string table, string valueDefault, Client server)
        {
            string _sConn = "Server=" + server.Host + ";Port=" + server.Port + ";User Id=" + server.Userdb + ";Password=" + server.Passworddb + ";Database=" + server.DatabaseName + ";Encoding=UNICODE;Pooling=true;";
            sql = "ALTER TABLE " + schema + "." + table + " add chuyendi text default '" + valueDefault + "'";
            return execute_data(sql, _sConn);
        }

        /// <summary>
        /// Phương thức update các table có field chuyển đi về giá trị cần
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="table"></param>
        /// <param name="valueDefault"></param>
        /// <param name="server"></param>
        /// <returns></returns>
        public bool update(string schema, string table, string valueDefault,Client server)
        {
            string _sConn = "Server=" + server.Host + ";Port=" + server.Port + ";User Id=" + server.Userdb + ";Password=" + server.Passworddb + ";Database=" + server.DatabaseName + ";Encoding=UNICODE;Pooling=true;";
           // return execute_data("UPDATE " + schema + "." + table+"@"+dblink+ " set chuyendi='" + valueDefault + "'");
            return execute_data("UPDATE " + schema + "." + table  + " set chuyendi='" + valueDefault + "'",_sConn);
        }
        /// <summary>
        /// Phương thức tạo table client dùng cho việc lưu lại các thông tin của máy trạm.
        /// </summary>
        /// <param name="server"></param>
        public void TaoTable(Client server)
        {
            string _sConn = "Server="+server.Host+";Port="+server.Port+";User Id="+server.Userdb+";Password="+server.Passworddb+";Database="+server.DatabaseName+";Encoding=UNICODE;Pooling=true;";
            sql = "create table "+User+".client(id numeric(5) not null,host varchar2(100) not null ,port varchar2(10) default '5432',databasename varchar2(100) default 'medisoft',userdb varchar2(50) default 'medisoft',passworddb varchar2(50) default 'links1920',servername varchar2(50),stt numeric(5) default 0,dblinks varchar2(50) not null, constraint pk_client primary key(ID,dblinks))";
            execute_data(sql,_sConn);
            sql = "create table " + User + ".eve_au_update(ngay datetime default now(),thoigian varchar2(8),ten text,srvSend varchar2(50),srvReceive varchar2(50),schema_ varchar2(30),tablename varchar2(50),event text,code varchar2(1) default '0', computer varchar2(100),userid varchar2(5)  )";
            execute_data(sql, _sConn);
            sql = "create table "+User+".syn_dmTable(stt numeric(5) not null default 0, schema_name varchar2(100) not null, table_name varchar2(255) not null,lastday numeric(1) default 0, constraint pk_syn_dmTable primary key (schema_name,table_name) )";
            execute_data(sql);
            //sql = "create table " + User + ".syn_capid(id numeric(5) default 0,ten varchar2(10), constraint pk_syn_capid primary key (id) )";
            //execute_data(sql);
            sql = "create table " + User + ".syn_manager_schema(mmyy varchar2(4),schemas varchar2(20), syn numeric(1) default 1 )";
            execute_data(sql,_sConn);
            //// doc file xml
            //if (!System.IO.File.Exists("..//..//..//xml//upd_table.xml"))
            //{
            //    return;
            //}
            ////DataSet dsxml = new DataSet();
            //dsxml.ReadXml("..//..//..//xml//upd_table.xml");
            ////execute_data("delete from " + User + ".syn_dmTable");
            //for (int i = 0; i < dsxml.Tables[0].Rows.Count; i++)
            //{
            //    //upd_dmTable(dsxml.Tables[0].Rows[i]["schema"].ToString(), dsxml.Tables[0].Rows[i]["tablename"].ToString(), int.Parse(dsxml.Tables[0].Rows[i]["lastday"].ToString()), i);
            //}
        }
        public void TaoTable()
        {
            //string _sConn = "Server=" + server.Host + ";Port=" + server.Port + ";User Id=" + server.Userdb + ";Password=" + server.Passworddb + ";Database=" + server.DatabaseName + ";Encoding=UNICODE;Pooling=true;";
            // table dung để lưu thông tin các máy trạm
            sql = "create table " + User + ".client(id numeric(5) not null,host varchar2(100) not null ,port varchar2(10) default '5432',databasename varchar2(100) default 'medisoft',userdb varchar2(50) default 'medisoft',passworddb varchar2(50) default 'links1920',servername varchar2(50),stt numeric(5) default 0,dblinks varchar2(50) not null,imagepath text,ngayud date default now(), constraint pk_client primary key(ID,dblinks))";
            execute_data(sql);
            // table lưu lại các sự kiện đồng bộ lỗi
            sql = "create table " + User + ".eve_au_update(ngay datetime default now(),thoigian varchar2(8),ten text,srvSend varchar2(50),srvReceive varchar2(50),schema_ varchar2(30),tablename varchar2(50),event text,code varchar2(1) default '0', computer varchar2(100),userid varchar2(5)  )";
            execute_data(sql);
            // table chứa danh sách các table cần đồng bộ
            sql = "create table " + User + ".syn_dmTable(stt numeric(5) not null default 0, schema_name varchar2(100) not null, table_name varchar2(255) not null,lastday numeric(1) default 0, constraint pk_syn_dmTable primary key (schema_name,table_name) )";
            execute_data(sql);
            // table lưu thông số đồng bộ.
            sql = "create table " + User + ".syn_thongso(id numeric(5) default 0,giatri varchar2(20), constraint pk_syn_thongso primary key (id) )";
            execute_data(sql);
            // table chứa danh dách các shema đã được taofunction
            sql = "create table " + User + ".syn_manager_schema(mmyy varchar2(4),schemas varchar2(20), syn numeric(1) not null default 0,constraint pk_syn_man_schema primary key(mmyy)  )";
            execute_data(sql);
            //
            sql = "alter table " + user + ".syn_dmtable add hide numeric(1) default 0;";
            execute_data(sql);

            sql = "alter table " + user + ".syn_dmtable_chungtu add hide numeric(1) default 0;";
            execute_data(sql);

            sql = "alter table " + user + ".syn_dmtable_ksk add hide numeric(1) default 0;";
            execute_data(sql);
            //
            // doc file xml
            if (!System.IO.File.Exists("..//..//..//xml//upd_table.xml"))
            {
                System.Windows.Forms.MessageBox.Show("Không tìm thấy file upd_table.xml trong thư mục xml", "Sinchronize");
                return;
            }
            //DataSet dsxml = new DataSet();
            //dsxml.ReadXml("..//..//..//xml//upd_table.xml");
            //execute_data("delete from " + User + ".syn_dmTable");
            //for (int i = 0; i < dsxml.Tables[0].Rows.Count; i++)
            //{
            //    upd_dmTable(dsxml.Tables[0].Rows[i]["schema"].ToString(), dsxml.Tables[0].Rows[i]["tablename"].ToString(), int.Parse(dsxml.Tables[0].Rows[i]["lastday"].ToString()), i);
            //}
        }
        public bool CreateDblink(Client server)
        {
            //server.DbLink = "dblink" + server.ServerName;
            if (!TestConntect(server)) return false;
            sql = "CREATE PUBLIC DATABASE LINK " + server.DbLink + " CONNECT TO " + server.Userdb + 
                " IDENTIFIED BY '" + server.Passworddb + 
                "' USING libpq 'host=" + server.Host + " port=" + server.Port + 
                " dbname=" + server.DatabaseName + "';";
            return execute_data(sql);
        }
        public bool DropdbLink(Client client)
        {
            sql = "DROP PUBLIC DATABASE LINK "+client.DbLink;
            return (execute_data(sql));
        }
        public bool bDbLinkName(string namedb)
        {
            try
            {
                sql = "SELECT lnkname, lnkuser, lnkconnstr FROM pg_catalog.edb_dblink where lnkname='dblink" + namedb + "'";
                return get_data(sql).Tables[0].Rows.Count > 0;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Phương thức dùng cho các máy trạm lên máy chủ để lấy vị trí trong chuỗi chuyendi trên máy server trung tâm.
        /// </summary>
        /// <param name="server"></param>
        /// <returns></returns>
        public long getID(string dblinkServer,string ClientName,string ClientHostName)
        {
            sql = "select id from " + User + ".client" + "@" + dblinkServer + " where host='" + ClientHostName + "'";
            try
            {
                return long.Parse(get_data(sql).Tables[0].Rows[0]["id"].ToString());
            }
            catch
            {
                return -1;
            }
        }
        public void upd_thongso(string ten, string giatri)
        {
            sql = "update " + User + ".syn_thongso set giatri='" +giatri + "' where ten='"+ten+"'";
            try
            {
                con = new NpgsqlConnection(sConn);
                con.Open();
                cmd = new NpgsqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (i == 0)
                {
                    sql = "insert into " + user + ".syn_thongso (ten,giatri) values ('" + ten + "','" + giatri + "')";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            { }
            finally
            {
                con.Close();
                con.Dispose();
                cmd.Dispose();
            }

        }
        public void upd_thongso(int id, string giatri)
        {
            sql = "update " + User + ".syn_thongso set giatri='" + giatri + "' where id=" + id ;
            try
            {
                con = new NpgsqlConnection(sConn);
                con.Open();
                cmd = new NpgsqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (i == 0)
                {
                    sql = "insert into " + user + ".syn_thongso (id,giatri) values (" + id+ ",'" + giatri + "')";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            { }
            finally
            {
                con.Close();
                con.Dispose();
                cmd.Dispose();
            }

        }
        public void upd_Events(string ngayddmmyyyy, string thoigian, string ten, string srvSend, string srvReceive, string schema, string tablename, string _event, string _code, string _computer, string userid)
        {
            //string _sConn = "Server=" + server.Host + ";Port=" + server.Port + ";User Id=" + server.Userdb + ";Password=" + server.Passworddb + ";Database=" + server.DatabaseName + ";Encoding=UNICODE;Pooling=true;";
            sql = "insert into " + user + ".eve_au_update(ngay,thoigian,ten,srvSend,srvReceive,schema_,tablename,event,code,computer,userid) values " +
                "(to_date('" + ngayddmmyyyy + "','dd/mm/yyyy'),'" + thoigian + "',:ten,'" + srvSend + "','" + srvReceive + "','" + schema + "'," +
                "'" + tablename + "',:event,'" + _code + "','" + _computer + "','" + userid + "')";
            try
            {
                if (con != null)
                {
                    con.Close(); con.Dispose();
                }
                con = new NpgsqlConnection(sConn);
                con.Open();
                cmd = new NpgsqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("ten", NpgsqlDbType.Text).Value = ten;
                cmd.Parameters.Add("event", NpgsqlDbType.Text).Value = _event;
                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                cmd.Dispose();
                con.Close(); con.Dispose();
            }
        }
        public void upd_Events(string ngayddmmyyyy, string thoigian, string ten, string srvSend, string srvReceive, string schema, string tablename, string _event, string _code, string _computer, string userid, Client server)
        {
            string _sConn = "Server=" + server.Host + ";Port=" + server.Port + ";User Id=" + server.Userdb + ";Password=" + server.Passworddb + ";Database=" + server.DatabaseName + ";Encoding=UNICODE;Pooling=true;";
            sql = "insert into " + user + ".eve_au_update(ngay,thoigian,ten,srvSend,srvReceive,schema_,tablename,event,code,computer,userid) values " +
                "(to_date('" + ngayddmmyyyy + "','dd/mm/yyyy'),'" + thoigian + "',:ten,'" + srvSend + "','" + srvReceive + "','" + schema + "'," +
                "'" + tablename + "',:event,'" + _code + "','" + _computer + "','" + userid + "')";
            try
            {
                if (con != null)
                {
                    con.Close(); con.Dispose();
                }
                con = new NpgsqlConnection(_sConn);
                con.Open();
                cmd = new NpgsqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("ten", NpgsqlDbType.Text).Value = ten;
                cmd.Parameters.Add("event", NpgsqlDbType.Text).Value = _event;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close(); con.Dispose();
                //return true;
            }
            catch 
            {
            }
        }
        public bool XoaClient(Client clien, Client server)
        {
            sql = "delete from medibv.client@" + server.DbLink + " where id=" + clien.ID + " and dblinks='" + clien.DbLink + "'";
            con = new NpgsqlConnection(sConn);
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close(); con.Dispose();
            }
            return true;
        }
        public DataTable getEvent(Client server)
        {
            string sql1 = "select to_char(ngay,'dd/mm/yyyy') as ngay,thoigian,ten,srvSend,srvReceive,schema_,tablename,event,code,computer,userid from " + user + ".eve_au_update@" + server.DbLink + " order by to_char(ngay,'dd/mm/yyyy') desc ";
            return get_data(sql1).Tables[0];
        }
        public DataTable getEvent()
        {
            string sql1 = "select to_char(ngay,'dd/mm/yyyy') as ngay,thoigian,ten,srvSend,srvReceive,schema_,tablename,event,code,computer,userid from " + user + ".eve_au_update order by to_char(ngay,'dd/mm/yyyy') desc ";
            return get_data(sql1).Tables[0];
        }
        public void delEventlog(Client server)
        {
            sql = "delete from "+user+".eve_au_update@"+server.DbLink;
            execute_data(sql);
        }
        public void delEventlog()
        {
            sql = "delete from " + user + ".eve_au_update";
            execute_data(sql);
        }
        private bool TestConntect(Client server)
        {
            string _sConn = "Server=" + server.Host + ";Port=" + server.Port + ";User Id=" + server.Userdb + ";Password=" + server.Passworddb + ";Database=" + server.DatabaseName + ";Encoding=UNICODE;Pooling=true;";
            try
            {
                con = new NpgsqlConnection(_sConn);
                con.Open();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Dispose();
            }
        }

        public void CreateFunction(Client server, Client client, string schema, string table, string fields, string primaryKeys)
        {
            bool bTonkho = false;
            if (table.ToLower() == "d_tonkhoth" || table.ToLower() == "d_tonkhoct")
            {
                bTonkho = true;
            }
            if (!bShemaValid(schema))
            {
                createSchema(schema);
            }
            sql = " CREATE OR REPLACE FUNCTION " + schema + ".syn_" + table + "_from_" + client.ServerName.ToUpper() + "()";
            sql += " RETURNS void AS ";
            sql += " $BODY$ \n";
            sql += " DECLARE " + get_Agument(server, schema, table).Replace(',', ';') + ";\n";
            sql += " cur_" + table + " cursor is select " + get_columnsname(server, schema, table) + " from " + schema + "." + table + "@" + client.DbLink;
            if (!bTonkho)
            {
                sql += " where substr(chuyendi," + (client.STT).ToString() + ",3)='www' ";
            }
            sql += ";\n";
            sql += " begin \n";
            sql += " update " + schema + "." + table + "@" + client.DbLink + " set chuyendi=lpad('0',300,'0') where chuyendi='' or chuyendi is null;\n";
            // sql += " commit;\n";
            if (!bTonkho)
            {
                if (client.STT == 1)
                    sql += " update " + schema + "." + table + "@" + client.DbLink + " set chuyendi='www'||substr(chuyendi," + (client.STT + 3).ToString() + ") where substr(chuyendi," + (client.STT).ToString() + ",3)='000';\n";
                else
                    sql += " update " + schema + "." + table + "@" + client.DbLink + " set chuyendi=substr(chuyendi,1," + (client.STT - 1).ToString() + ")||'www'||substr(chuyendi," + (client.STT + 3).ToString() + ") where substr(chuyendi," + (client.STT).ToString() + ",3)='000';\n";
            }
            // exception postgresSql
            // sql += " if(found = false) then  raise exception 'không cập nhật được vào trạng thái chờ của table "+table+" ';end if;\n";
            if (bTonkho)
            {
                sql += "delete from " + schema + "." + table + "@" + server.DbLink + " where makho in( select id from " + user + ".d_dmkho@" + client.DbLink + ");\n";
            }
            sql += " open cur_" + table + ";\n";
            // sql += " if(found = false) then  raise exception 'không mở được kết nối tới table " + table + " ';end if;\n";
            sql += " loop ";
            sql += " fetch cur_" + table + " into " + get_variable(server, schema, table) + ";\n";
            sql += " if found = false then exit;\n end if;\n";
            sql += " update " + schema + "." + table + "@" + server.DbLink + " set " + get_Parameter(server, schema, table, getPrimaryKeys(server, schema, table)) + get_Condition(getPrimaryKeys(server, schema, table)) + ";\n";
            sql += " if found = false then ";
            sql += " insert into " + schema + "." + table + "@" + server.DbLink + "(" + get_columnsname(server, schema, table) + ") values (" + get_variable(server, schema, table) + ");\n";
            //sql += " if(found = false) then  raise exception 'cập nhật table " + table + " bị lỗi ';end if;\n";
            sql += " end if;\n";
            sql += " end loop ;";
            sql += " close cur_" + table + ";\n";
            // update trạng thái nhận được của máy server
            if (!bTonkho)
            {
                if (client.STT == 1)
                    sql += " update " + schema + "." + table + "@" + server.DbLink + " set chuyendi='111'||substr(chuyendi," + (client.STT + 3).ToString() + ") where substr(chuyendi," + client.STT + ",3)='www';\n";
                else
                    sql += " update " + schema + "." + table + "@" + server.DbLink + " set chuyendi=substr(chuyendi,1," + (client.STT - 1).ToString() + ")||'111'||substr(chuyendi," + (client.STT + 3).ToString() + ") where substr(chuyendi," + client.STT + ",3)='www';\n";
                // sql += " if(found = false) then  raise exception 'không cập nhật được trạng thái nhận được của máy server ';end if;\n";
                // update từ trạng thái chờ sang trang thái đã thực hiện chuyển. 
                if (client.STT == 1)
                    sql += " update " + schema + "." + table + "@" + client.DbLink + " set chuyendi='111'||substr(chuyendi," + (client.STT + 3).ToString() + ") where substr(chuyendi," + client.STT + ",3)='www';\n";
                else
                    sql += " update " + schema + "." + table + "@" + client.DbLink + " set chuyendi=substr(chuyendi,1," + (client.STT - 1).ToString() + ")||'111'||substr(chuyendi," + (client.STT + 3).ToString() + ") where substr(chuyendi," + client.STT + ",3)='www';\n";
            }
            // sql += " if(found = false) then  raise exception 'cập nhật trạng thái đã chuyên trên máy trạm không thành công ';end if;\n";
            sql += " end;\n";
            sql += " $BODY$ ";
            sql += " LANGUAGE 'plpgsql' VOLATILE;\n";

            if (!execute_data(sql))
            {
                upd_Events(DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("hh:mm:ss"), "create function", server.ServerName, client.ServerName, schema, table, error, "1", sComputer, " ", server);
            }
        }
        /// <summary>
        /// Phương thức dùng để tạo function phục vụ cho việc cập nhật tự động.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="schema"></param>
        /// <param name="table"></param>
        public void CreateFunction(Client client, string schema, string table)
        {
            bool bTonkho = false;
            string dblinks_client = client.DbLink;
            int stt = client.STT;
            if (table.ToLower() == "d_tonkhoth" || table.ToLower() == "d_tonkhoct")
            {
                bTonkho = true;
            }

            if (!bShemaValid(schema))
            {
                return;
            }
            sql = " CREATE OR REPLACE FUNCTION " + schema + ".syn_" + table + "_from_" + client.ServerName.ToLower() + "()";
            sql += " RETURNS void AS ";
            sql += " $BODY$ \n";
            sql += " DECLARE " + get_Agument(schema, table).Replace(',', ';') + ";\n";
            sql += " cur_" + table + " cursor is select " + get_columnsname( schema, table) + " from " + schema + "." + table + "@" + dblinks_client;
            if (!bTonkho)
            {
                sql += " where substr(lpad(chuyendi,300,'0')," + (stt).ToString() + ",3)='www' ";
            }
            sql += ";\n";
            sql += " begin \n";
            sql += " update " + schema + "." + table + "@" + client.DbLink + " set chuyendi=lpad('0',300,'0') where chuyendi='' or chuyendi is null;\n";
            //sql += " commit;\n";
            if (!bTonkho)
            {
                if (stt == 1)
                    sql += " update " + schema + "." + table + "@" + dblinks_client + " set chuyendi='www'||substr(lpad(chuyendi,300,'0')," + (stt + 3).ToString() + ") where substr(lpad(chuyendi,300,'0')," + (stt).ToString() + ",3)='000';\n";
                else
                    sql += " update " + schema + "." + table + "@" + dblinks_client + " set chuyendi=substr(lpad(chuyendi,300,'0'),1," + (stt - 1).ToString() + ")||'www'||substr(lpad(chuyendi,300,'0')," + (stt + 3).ToString() + ") where substr(lpad(chuyendi,300,'0')," + (stt).ToString() + ",3)='000';\n";
            }
            // exception postgresSql
            // sql += " if(found = false) then  raise exception 'không cập nhật được vào trạng thái chờ của table "+table+" ';end if;\n";
            if (bTonkho)
            {
                sql += "delete from " + schema + "." + table + " where makho in( select id from " + user + ".d_dmkho@" + dblinks_client+ ");\n";
            }
            sql += " open cur_" + table + ";\n";
            // sql += " if(found = false) then  raise exception 'không mở được kết nối tới table " + table + " ';end if;\n";
            sql += " loop ";
            sql += " fetch cur_" + table + " into " + get_variable(schema, table) + ";\n";
            sql += " if found = false then exit;end if;\n";
            sql += " update " + schema + "." + table + " set " + get_Parameter(schema, table, getPrimaryKeys(schema, table)) + get_Condition(getPrimaryKeys(schema, table)) + ";\n";
            sql += " if found = false then ";
            sql += " insert into " + schema + "." + table +"(" + get_columnsname(schema, table) + ") values (" + get_variable(schema, table) + ");\n";
            //sql += " if(found = false) then  raise exception 'cập nhật table " + table + " bị lỗi ';end if;\n";
            sql += " end if;\n";
            sql += " end loop ;";
            sql += " close cur_" + table + ";\n";
            // update trạng thái nhận được của máy server
            if (!bTonkho)
            {
                if (stt == 1)
                    sql += " update " + schema + "." + table + " set chuyendi='111'||substr(lpad(chuyendi,300,'0')," + (stt + 3).ToString() + ") where substr(lpad(chuyendi,300,'0')," + stt + ",3)='www';\n";
                else
                    sql += " update " + schema + "." + table + " set chuyendi=substr(lpad(chuyendi,300,'0'),1," + (stt - 1).ToString() + ")||'111'||substr(lpad(chuyendi,300,'0')," + (stt + 3).ToString() + ") where substr(chuyendi," + stt + ",3)='www';\n";
                // sql += " if(found = false) then  raise exception 'không cập nhật được trạng thái nhận được của máy server ';end if;\n";
                // update từ trạng thái chờ sang trang thái đã thực hiện chuyển. 
                if (stt == 1)
                    sql += " update " + schema + "." + table + "@" + dblinks_client + " set chuyendi='111'||substr(lpad(chuyendi,300,'0')," + (stt + 3).ToString() + ") where substr(lpad(chuyendi,300,'0')," + stt + ",3)='www';\n";
                else
                    sql += " update " + schema + "." + table + "@" + dblinks_client + " set chuyendi=substr(lpad(chuyendi,300,'0'),1," + (stt - 1).ToString() + ")||'111'||substr(lpad(chuyendi,300,'0')," + (stt + 3).ToString() + ") where substr(lpad(chuyendi,300,'0')," + stt + ",3)='www';\n";
            }
            // sql += " if(found = false) then  raise exception 'cập nhật trạng thái đã chuyên trên máy trạm không thành công ';end if;\n";
            sql += " end;\n";
            sql += " $BODY$ ";
            sql += " LANGUAGE 'plpgsql' VOLATILE;\n";

            if (!execute_data(sql))
            {
                upd_Events(DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("hh:mm:ss"), "create function", "", client.ServerName, schema, table, error, "1", sComputer, " ");
            }
        }
        public bool update(string functionname)
        {
            try
            {
                if (con != null)
                {
                    con.Dispose();
                }
                con = new NpgsqlConnection(sConn);
                con.Open();
                cmd = new NpgsqlCommand();
                cmd.CommandText = functionname;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception er)
            {
                error = er.Message;
                return false;
                //upd_Events(DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.Hour.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Second.ToString().PadLeft(2, '0'), "Auto", functionname, functionname, functionname, functionname, error, "0", sComputer, "", Server);
            }
            finally
            {
                con.Dispose();
                cmd.Dispose();
            }
        }
        private string get_Condition(string primaryKeys)
        {
            string[] arr = primaryKeys.Split(',');
            string condition ="";
            if (arr.Length > 0)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (condition == "")
                    {
                        if (arr[i] != "")
                        {
                            condition = " where " + arr[i] + " =s_" + arr[i];
                        }
                    }
                    else
                    {
                        if (arr[i] != "")
                        {
                            condition += " and " + arr[i] + " =s_" + arr[i];
                        }
                    }
                }
            }
            return condition;
        }
        private string get_Condition_trigger(string primaryKeys)
        {
            string[] arr = primaryKeys.Split(',');
            string condition = "";
            if (arr.Length > 0)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (condition == "")
                    {
                        if (arr[i] != "")
                        {
                            condition = " where " + arr[i] + " =OLD." + arr[i];
                        }
                    }
                    else
                    {
                        if (arr[i] != "")
                        {
                            condition += " and " + arr[i] + " =OLD." + arr[i];
                        }
                    }
                }
            }
            return condition;
        }

        private string get_dataType(Client server, string schema, string table)
        {
            string sql1 = "select lower(column_name) column_name,lower(data_type) data_type from information_schema.columns@" + server.DbLink + " where table_schema='" + schema + "' and table_name='" + table + "'";
            string agument = "";
            foreach (DataRow row in get_data(sql1).Tables[0].Rows)
            {
                if (agument == "")
                {
                    //if (row["data_type"].ToString().Trim() == "timestamp without time zone")
                    //{
                    //    agument = " character varying ";
                    //}
                    //else
                    if (row["column_name"].ToString().Trim() != "chuyendi")
                    {
                        agument = row["data_type"].ToString().Trim();
                    }
                }
                else
                {
                    //if (row["data_type"].ToString().Trim() == "timestamp without time zone")
                    //{
                    //    agument += "," + " character varying ";
                    //}
                    //else
                    if ( row["column_name"].ToString().Trim() != "chuyendi")
                    {
                        agument += "," + row["data_type"].ToString().Trim();
                    }
                }
            }
            return agument;
        }
        /// <summary>
        /// ta5o 1 phần trong lệnh update: field1=s_field1,field2=s_field2... theo table, k đụng đến primary key
        /// </summary>
        /// <param name="server"></param>
        /// <param name="schema"></param>
        /// <param name="table"></param>
        /// <param name="primarykeys"></param>
        /// <returns></returns>
        private string get_Parameter(Client server, string schema, string table, string primarykeys)
        {
            string sql1 = "select lower(column_name) column_name,lower(data_type) data_type from information_schema.columns@"+server.DbLink+" where table_schema='"+schema+"' and table_name='"+table+"'";
            string parameter = "";
            foreach (DataRow row in get_data(sql1).Tables[0].Rows)
            {
                if (!sosanh(primarykeys.Split(','),row["column_name"].ToString()))
                {
                    if (parameter == "")
                    {
                        if (row["column_name"].ToString().Trim() != "chuyendi")
                        {
                            parameter = row["column_name"].ToString().Trim() + "=s_" + row["column_name"].ToString().Trim();
                        }
                    }
                    else
                    {
                        if (row["column_name"].ToString().Trim() != "chuyendi")
                        {
                            parameter += "," + row["column_name"].ToString().Trim() + "=s_" + row["column_name"].ToString().Trim();
                        }
                    }
                }
            }
            return parameter;
        }
        /// <summary>
        /// Phương thức trả về các field được insert.
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="table"></param>
        /// <param name="primarykeys"></param>
        /// <returns></returns>
        private string get_Parameter( string schema, string table, string primarykeys)
        {
            string sql1 = "select lower(column_name) column_name,lower(data_type) data_type from information_schema.columns where table_schema='" + schema + "' and table_name='" + table + "'";
            string parameter = "";
            foreach (DataRow row in get_data(sql1).Tables[0].Rows)
            {
                if (!sosanh(primarykeys.Split(','), row["column_name"].ToString()))
                {
                    if (parameter == "")
                    {
                        //if (row["data_type"].ToString().Trim() == "timestamp without time zone")
                        //{
                        //    parameter = row["column_name"].ToString().Trim() + "=to_timestamp(s_" + row["column_name"].ToString().Trim() + ",''dd/mm/yyyy hh24:mi'')";
                        //}
                        //else
                        if (row["column_name"].ToString().Trim() != "chuyendi")
                        {
                            parameter = row["column_name"].ToString().Trim() + "=s_" + row["column_name"].ToString().Trim();
                        }
                    }
                    else
                    {
                        //if (row["data_type"].ToString().Trim() == "timestamp without time zone")
                        //{
                        //    parameter += "," + row["column_name"].ToString().Trim() + "=to_timestamp(s_" + row["column_name"].ToString().Trim() + ",''dd/mm/yyyy hh24:mi'')";
                        //}
                        //else
                        if (row["column_name"].ToString().Trim() != "chuyendi")
                        {
                            parameter += "," + row["column_name"].ToString().Trim() + "=s_" + row["column_name"].ToString().Trim();
                        }
                    }
                }
            }
            return parameter;
        }

        private bool sosanh(string[] arr, string columnname)
        {
            bool _equals = false;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == columnname)
                {
                    _equals = true;
                    break;
                }
            }
            return _equals;
        }
        private string get_Agument(Client server, string schema, string table)
        {
            string sql1 = "select lower(column_name) column_name,lower(data_type) data_type from information_schema.columns@" + server.DbLink + " where table_schema='" + schema + "' and table_name='" + table + "'";
            string agument = "";
            foreach (DataRow row in get_data(sql1).Tables[0].Rows)
            {
                if (agument == "")
                {
                    //if (row["data_type"].ToString().Trim() == "timestamp without time zone")
                    //{
                    //    agument = "s_" + row["column_name"].ToString().Trim() + " character varying ";
                    //}
                    //else
                    //if ( row["column_name"].ToString().Trim() != "chuyendi")
                    {
                        agument = "s_" + row["column_name"].ToString().Trim() + " " + row["data_type"].ToString().Trim();
                    }
                }
                else
                {
                    //if (row["data_type"].ToString().Trim() == "timestamp without time zone")
                    //{
                    //    agument += "," + "s_" + row["column_name"].ToString().Trim() + " character varying ";
                    //}
                    //else
                    //if (row["column_name"].ToString().Trim() != "chuyendi")
                    {
                        agument += "," + "s_" + row["column_name"].ToString().Trim() + " " + row["data_type"].ToString().Trim();
                    }
                }
            }
            return agument;
        }
        private string get_Agument(string schema, string table)
        {
            string sql1 = "select lower(column_name) column_name,lower(data_type) data_type from information_schema.columns where table_schema='" + schema + "' and table_name='" + table + "'";
            string agument = "";
            foreach (DataRow row in get_data(sql1).Tables[0].Rows)
            {
                if (agument == "")
                {
                    //if (row["data_type"].ToString().Trim() == "timestamp without time zone")
                    //{
                    //    agument = "s_" + row["column_name"].ToString().Trim() + " character varying ";
                    //}
                    //else
                    //if ( row["column_name"].ToString().Trim() != "chuyendi")
                    {
                        agument = "s_" + row["column_name"].ToString().Trim() + " " + row["data_type"].ToString().Trim();
                    }
                }
                else
                {
                    //if (row["data_type"].ToString().Trim() == "timestamp without time zone")
                    //{
                    //    agument += "," + "s_" + row["column_name"].ToString().Trim() + " character varying ";
                    //}
                    //else
                    //if (row["column_name"].ToString().Trim() != "chuyendi")
                    {
                        agument += "," + "s_" + row["column_name"].ToString().Trim() + " " + row["data_type"].ToString().Trim();
                    }
                }
            }
            return agument;
        }
        private string get_variable(Client server, string schema, string table)
        {
            string sql1 = "select lower(column_name) column_name,lower(data_type) data_type from information_schema.columns@" + server.DbLink + " where table_schema='" + schema + "' and table_name='" + table + "'";
            string agument = "";
            foreach (DataRow row in get_data(sql1).Tables[0].Rows)
            {
                if (agument == "")
                {
                    //if (row["data_type"].ToString().Trim() == "timestamp without time zone")
                    //{
                    //    agument = "s_" + row["column_name"].ToString().Trim() + " character varying ";
                    //}
                    //else
                  //  if(row["column_name"].ToString().Trim()!="chuyendi")
                    {
                        agument = "s_" + row["column_name"].ToString().Trim();
                    }
                }
                else
                {
                    //if (row["data_type"].ToString().Trim() == "timestamp without time zone")
                    //{
                    //    agument += "," + "s_" + row["column_name"].ToString().Trim() + " character varying ";
                    //}
                    //else
                   // if ( row["column_name"].ToString().Trim() != "chuyendi")
                    {
                        agument += "," + "s_" + row["column_name"].ToString().Trim();
                    }
                }
            }
            return agument;
        }
        /// <summary>
        /// Phương thức trả về là chuổi các biến dùng để lưu dữ liệu lấy về.
        /// </summary>
        /// <param name="server"></param>
        /// <param name="schema"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        private string get_variable( string schema, string table)
        {
            string sql1 = "select lower(column_name) column_name,lower(data_type) data_type from information_schema.columns where table_schema='" + schema + "' and table_name='" + table + "'";
            string agument = "";
            foreach (DataRow row in get_data(sql1).Tables[0].Rows)
            {
                if (agument == "")
                {
                    //if (row["data_type"].ToString().Trim() == "timestamp without time zone")
                    //{
                    //    agument = "s_" + row["column_name"].ToString().Trim() + " character varying ";
                    //}
                    //else
                    //  if(row["column_name"].ToString().Trim()!="chuyendi")
                    {
                        agument = "s_" + row["column_name"].ToString().Trim();
                    }
                }
                else
                {
                    //if (row["data_type"].ToString().Trim() == "timestamp without time zone")
                    //{
                    //    agument += "," + "s_" + row["column_name"].ToString().Trim() + " character varying ";
                    //}
                    //else
                    // if ( row["column_name"].ToString().Trim() != "chuyendi")
                    {
                        agument += "," + "s_" + row["column_name"].ToString().Trim();
                    }
                }
            }
            return agument;
        }
        private string get_columnsname(Client server, string schema, string table)
        {
            string sql1 = "select lower(column_name) column_name,lower(data_type) data_type from information_schema.columns@" + server.DbLink + " where table_schema='" + schema + "' and table_name='" + table + "'";
            string agument = "";
            foreach (DataRow row in get_data(sql1).Tables[0].Rows)
            {
                if (agument == "")
                {
                    //if (row["data_type"].ToString().Trim() == "timestamp without time zone")
                    //{
                    //    agument = "s_" + row["column_name"].ToString().Trim() + " character varying ";
                    //}
                    //else
                    //if (row["column_name"].ToString().Trim() != "route")
                    {
                        agument =  row["column_name"].ToString().Trim();
                    }
                }
                else
                {
                    //if (row["data_type"].ToString().Trim() == "timestamp without time zone")
                    //{
                    //    agument += "," + "s_" + row["column_name"].ToString().Trim() + " character varying ";
                    //}
                    //else
                    //if (row["column_name"].ToString().Trim() != "route")
                    {
                        agument += ","  + row["column_name"].ToString().Trim();
                    }
                }
            }
            return agument;
        }
        private string get_columnsname( string schema, string table)
        {
            string sql1 = "select lower(column_name) column_name,lower(data_type) data_type from information_schema.columns where table_schema='" + schema + "' and table_name='" + table + "'";
            string agument = "";
            foreach (DataRow row in get_data(sql1).Tables[0].Rows)
            {
                if (agument == "")
                {
                    agument = row["column_name"].ToString().Trim();
                }
                else
                {
                    agument += "," + row["column_name"].ToString().Trim();
                }
            }
            return agument;
        }
        public bool bShemaValid(string schema)
        {
            try
            {
                return get_data("select schema_name from information_schema.schemata where schema_name='" + schema + "'").Tables[0].Rows.Count > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool bShemaValid(string schema, string strconn)
        {
            try
            {
                if(strconn=="")
                    return get_data("select schema_name from information_schema.schemata where schema_name='" + schema + "'").Tables[0].Rows.Count > 0;
                else 
                    return get_data("select schema_name from information_schema.schemata where schema_name='" + schema + "'", strconn).Tables[0].Rows.Count > 0;
            }
            catch
            {
                return false;
            }
        }
        private bool createSchema(string schema_name)
        {
            return execute_data("CREATE SCHEMA "+schema_name+"  AUTHORIZATION "+owner+";");
        }

        public void dropFunction(string funcName)
        {
            sql = " DROP FUNCTION "+funcName+";";
            execute_data(sql);
        }

        public bool upd_dmTable(string _schema, string _table, int _lastday,long _stt)
        {
            try
            {
                con = new NpgsqlConnection(sConn);
                con.Open();
                string sql1 = "insert into " + User + ".syn_dmTable(stt,schema_name,table_name,lastday) values (" + _stt + ",'" + _schema + "','" + _table + "'," + _lastday + ")";
                cmd = new NpgsqlCommand(sql1, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception er)
            {
                error = er.Message;
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
                cmd.Dispose();
            }
        }
        /// <summary>
        /// Phương thức được dùng để tự động tìm kiếm các schema được tạo ra trên edb. đem vào quản lý đồng bộ
        /// </summary>
        /// <param name="dblink_server"></param>
        public void upd_manager_schema(string dblink_server)
        {
            sql = "select mmyy from " + user + ".table@" + dblink_server;
            foreach (DataRow row in get_data(sql).Tables[0].Rows)
            {
                if(!mmyy(row["mmyy"].ToString(),dblink_server))
                {
                    sql = " insert into " + user + ".syn_manager_schema@"+dblink_server+" (mmyy,schemas)values ('" + row["mmyy"].ToString() + "','" + user + row["mmyy"].ToString() + "')";
                    execute_data(sql);
                }
            }
        }
        private bool mmyy(string _mmyy,string dblink)
        {
            try
            {
                return get_data("select mmyy from " + user + ".syn_manager_schema@"+dblink+" where mmyy='" + _mmyy + "'").Tables[0].Rows.Count > 0;
            }
            catch 
            {
                return false;
            }
        }
        /// <summary>
        /// Tạo trigger delete tại các máy trạm 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="schema"></param>
        /// <param name="table"></param>
        public void create_trigger(Client client,string schema, string table)
        {
           //sql = " CREATE OR REPLACE FUNCTION " + schema + ".syn_trigger_" + table + "() RETURNS TRIGGER AS \n $BODY$ \n";
           //sql +=" BEGIN \n";
           //sql +=" IF (TG_OP = 'DELETE') THEN \n";
           //sql += " INSERT INTO "+schema +".del_"+table+"(schema_name,table_name,key_name, VALUES( SELECT '"+schema+"','"+table+"','"+get_Condition_trigger(getPrimaryKeys(schema,table))+"',);\n";
           //sql +=" RETURN OLD;\n";
           //     //ELSIF (TG_OP = 'UPDATE') THEN
           //     //    INSERT INTO emp_audit SELECT 'U', now(), user, NEW.*;
           //     //    RETURN NEW;
           //     //ELSIF (TG_OP = 'INSERT') THEN
           //     //    INSERT INTO emp_audit SELECT 'I', now(), user, NEW.*;
           //     //    RETURN NEW;
           //sql += " END IF;\n";
           //sql += "  RETURN NULL; -- result is ignored since this is an AFTER trigger \n";
           //sql += " END;\n";
           //sql += " $BODY$ \n LANGUAGE plpgsql;\n";

           //sql += " CREATE TRIGGER tri_del_" + table + " \n";
           //sql += " AFTER DELETE ON " + schema + "." + table + " \n";
           //sql += " FOR EACH ROW EXECUTE PROCEDURE " + schema + ".syn_trigger_" + table + "();";
           //execute_data(sql, _sConn);
        }
        /// <summary>
        /// Phương thức được sử dụng để tạo table del trên các máy trạm
        /// </summary>
        /// <param name="client"></param>
        /// <param name="schema"></param>
        /// <param name="table"></param>
        public bool create_del_table_on_client(Client client, string schema, string table)
        {
            if (client != null)
            {
                string _sConn = "Server=" + client.Host + ";Port=" + client.Port + ";User Id=" + client.Userdb + ";Password=" + client.Passworddb + ";Database=" + client.DatabaseName + ";Encoding=UNICODE;Pooling=true;";
                sql = "create table " + schema + ".del_table(schema_name varchar2(50) not null,table_name varchar2(50) not null, key_name text not null,stt numeric(5) default 0, daxoa numeric(1) default 0 ) ";
                return execute_data(sql, _sConn);
            }
            else
            {
                sql = "create table " + schema + ".del_table(schema_name varchar2(50) not null,table_name varchar2(50) not null, key_name text not null,stt numeric(14) default 0, daxoa numeric(1) default 0 ) ";
                return execute_data(sql);
            }
        }
        public void syn_del(string  dblink_server, List<Client> list)
        {
            
            for (int i = 0; i < list.Count; i++)
            {
                sql = " update " + userid + ".del_table@" + list[i].DbLink + " set daxoa=2 where daxoa=0";
                if (execute_data(sql))
                {
                    sql = "select * from " + userid + ".del_table@" + list[i].DbLink + " where daxoa=2 order by stt";
                    foreach (DataRow row in get_data(sql).Tables[0].Rows)
                    {
                        if (row["key_name"].ToString() != "")
                        {
                            sql = "delete from " + row["schema_name"].ToString() + "." + row["table_name"].ToString() + "@" + dblink_server;
                            sql += " where " + row["key_name"].ToString();
                            if (execute_data(sql))
                            {
                                sql = " update " + userid + ".del_table@" + list[i].DbLink + " set daxoa=1 where daxoa= 2 ";
                                sql += " and schema_name='"+row["schema_name"].ToString()+"'";
                                sql += " and table_name='"+row["table_name"].ToString()+"'";
                                sql += " and key_name='"+row["key_name"].ToString()+"'";
                                execute_data(sql);
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Xóa đồng bộ.
        /// </summary>
        /// <param name="dblink_server"></param>
        /// <param name="list"></param>
        public void syn_del( List<Client> list)
        {

            for (int i = 0; i < list.Count; i++)
            {
                sql = " update " + userid + ".del_table@" + list[i].DbLink + " set daxoa=2 where daxoa=0";
                if (execute_data(sql))
                {
                    sql = "select * from " + userid + ".del_table@" + list[i].DbLink + " where daxoa=2 order by stt";
                    foreach (DataRow row in get_data(sql).Tables[0].Rows)
                    {
                        if (row["key_name"].ToString() != "")
                        {
                            sql = "delete from " + row["schema_name"].ToString() + "." + row["table_name"].ToString();
                            sql += " where " + row["key_name"].ToString();
                            if (execute_data(sql))
                            {
                                sql = " update " + userid + ".del_table@" + list[i].DbLink + " set daxoa=1 where daxoa= 2 ";
                                sql += " and schema_name='" + row["schema_name"].ToString() + "'";
                                sql += " and table_name='" + row["table_name"].ToString() + "'";
                                sql += " and key_name='" + row["key_name"].ToString() + "'";
                                execute_data(sql);
                            }
                        }
                    }
                }
            }
        }

        private string getPrimaryKeys(Client m_server,string schemas, string tablename)
        {
            string keys = "";
            DataTable dt = get_data("select column_name from information_schema.key_column_usage@" + m_server.DbLink + " where constraint_schema='" + schemas + "' and table_name='" + tablename + "' and constraint_name like '%pk%' ").Tables[0];
            foreach (DataRow r1 in dt.Rows)
            {
                if (keys == "")
                {
                    keys = r1["column_name"].ToString();
                }
                else
                {
                    keys += "," + r1["column_name"].ToString();
                }
            }
            return keys;
        }
        /// <summary>
        /// Phương thức trả về danh sách các primary key của table.
        /// </summary>
        /// <param name="schemas"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        private string getPrimaryKeys( string schemas, string tablename)
        {
            string keys = "";
            DataTable dt = get_data("select column_name from information_schema.key_column_usage where constraint_schema='" + schemas + "' and table_name='" + tablename + "' and constraint_name like '%pk%' ").Tables[0];
            foreach (DataRow r1 in dt.Rows)
            {
                if (keys == "")
                {
                    keys = r1["column_name"].ToString();
                }
                else
                {
                    keys += "," + r1["column_name"].ToString();
                }
            }
            return keys;
        }

        public void CreateDatabase()
        {
            string sconnect = "Server=" + Maincode("Ip") + ";Port=" + Maincode("Post") + ";User Id=enterprisedb;Password=links1920;Database=postgres;Encoding=UNICODE;Pooling=true;";
            sql = "CREATE DATABASE "+database+" \n";
            sql +=" WITH OWNER = "+owner+" \n";
            sql +=" ENCODING = 'UTF8' \n";
            sql +=" CONNECTION LIMIT = -1;\n";
            execute_data(sql, sconnect);
        }
        public void CreateRole()
        {
            string sconnect = "Server=" + Maincode("Ip") + ";Port=" + Maincode("Post") + ";User Id=enterprisedb;Password=links1920;Database=postgres;Encoding=UNICODE;Pooling=true;";
            sql  = "create role "+owner+" \n"; 
            sql += "login \n";
            sql += "superuser \n";
            sql += "createdb \n";
            sql += " createrole \n";
            sql += "connection limit -1 \n";
            sql += "encrypted password 'links1920' \n";
            execute_data(sql, sconnect);
        }
        public bool ValidRole()
        {
            string sconnect = "Server=" + Maincode("Ip") + ";Port=" + Maincode("Post") + ";User Id=enterprisedb;Password=links1920;Database=postgres;Encoding=UNICODE;Pooling=true;";
            try
            {
                return get_data("select * from pg_user where usename='" + owner + "'",sconnect).Tables[0].Rows.Count > 0;
            }
            catch
            {
                return false;
            }
        }
        public bool ValidDatabase()
        {
            string sconnect = "Server=" + Maincode("Ip") + ";Port=" + Maincode("Post") + ";User Id=enterprisedb;Password=links1920;Database=postgres;Encoding=UNICODE;Pooling=true;";
            try
            {
                return get_data("select * from pg_database where datname='" + database + "'").Tables[0].Rows.Count > 0;
            }
            catch
            {
                return false;
            }
        }
        public bool HasPrimaryKey(string tablename, string schemaname)
        {
            sql = "select constraint_name from sys.dba_constraints where schema_name='" + schemaname.ToUpper() + "' and table_name='" + tablename.ToUpper() + "' and upper(constraint_type)='P'";
            try
            {
                return get_data(sql).Tables[0].Rows.Count > 0;
            }
            catch
            {
                return false;
            }
        }
        public DataTable get_Information_constraint()
        {
            sql = "select a.schema_name r_schema,a.constraint_name f,a.table_name r_table,a.r_constraint_name,"+
                  "upper(b.table_schema) table_schema , upper(b.table_name ) table_name from "+
                  "(select * from sys.dba_constraints where constraint_type='F') a,"+"INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE b "+
                  " where a.r_constraint_name = upper(b.constraint_name)";
            return get_data(sql).Tables[0];
        }
        /// <summary>
        /// Giờ bắt đầu đồng bộ cuối ngày.
        /// </summary>
        public int Gio_bat_dau
        { // id=4;
            get 
            {
                try
                {
                    return int.Parse(get_data("select giatri from " + user + ".syn_thongso where id=4").Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    return 18;
                }
            }
            
        }
        /// <summary>
        /// Phút bắt đầu đồng bộ cuối ngày id=5;
        /// </summary>
        public int Phut_bat_dau
        { // id=5;
            get
            {
                try
                {
                    return int.Parse(get_data("select giatri from " + user + ".syn_thongso where id=5").Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    return 0;
                }
            }
        }
        /// <summary>
        /// Tu Dong Mail
        /// </summary>
        public bool TuDong_Mail
        { // id=4;
            get
            {
                try
                {
                    return get_data("select giatri from " + user + ".syn_thongso where id=9").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }

        }
        /// <summary>
        /// Giờ bắt đầu đồng bộ cuối ngày.
        /// </summary>
        public int Gio_bat_dau_mail
        { // id=4;
            get
            {
                try
                {
                    return int.Parse(get_data("select giatri from " + user + ".syn_thongso where id=7").Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    return 8;
                }
            }

        }

        public int NgayNhacMail
        { // id=10;
            get
            {
                try
                {
                    return int.Parse(get_data("select giatri from " + user + ".syn_thongso where id=10").Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    return 2;
                }
            }

        }
        public bool HinhBN_GhiDe
        { // id=11;
            get
            {
                try
                {
                    return get_data("select giatri from " + user + ".syn_thongso where id=11").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }

        }
        public bool HinhCDHA_GhiDe
        { // id=12;
            get
            {
                try
                {
                    return get_data("select giatri from " + user + ".syn_thongso where id=12").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }

        }
        public bool HinhChungTu_GhiDe
        { // id=22;
            get
            {
                try
                {
                    return get_data("select giatri from " + user + ".syn_thongso where id=22").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }

        }
        public bool Dongbo_HinhBN
        { // id=17;
            get
            {
                try
                {
                    return get_data("select giatri from " + user + ".syn_thongso where id=17").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }

        }

        public bool Dongbo_HinhCDHA
        { // id=18;
            get
            {
                try
                {
                    return get_data("select giatri from " + user + ".syn_thongso where id=18").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }

        }

        public bool Dongbo_HinhChungtu
        { // id=19;
            get
            {
                try
                {
                    return get_data("select giatri from " + user + ".syn_thongso where id=19").Tables[0].Rows[0][0].ToString() == "1";
                }
                catch
                {
                    return false;
                }
            }

        }

        /// <summary>
        /// Phút bắt đầu đồng bộ cuối ngày id=5;
        /// </summary>
        public int Phut_bat_dau_mail
        { // id=5;
            get
            {
                try
                {
                    return int.Parse(get_data("select giatri from " + user + ".syn_thongso where id=8").Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    return 0;
                }
            }
        }
        /// <summary>
        /// Thời gian đồng bộ liên tục.
        /// </summary>
        public int Khoang_thoi_gian_dong_bo
        {
            //id=1
            get
            {
                try
                {
                    return int.Parse(get_data("select giatri from " + user + ".syn_thongso where id=1").Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    return 10;
                }
            }
        }
        /// <summary>
        /// Khoảng cách ngày so với ngày hiện tại.
        /// </summary>
        public int Khoang_cach_ngay
        {
            //id=1
            get
            {
                try
                {
                    return int.Parse(get_data("select giatri from " + user + ".syn_thongso where id=6").Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    return 3;
                }
            }
        }
        /// <summary>
        /// kiểm tra xem mmyy đã được tạo function chưa?,table = syn_manager_schema,syn_function 
        /// </summary>
        /// <param name="mmyy"></param>
        public bool Da_tao_function(string mmyy,string table_name)
        {
            try
            {
                return get_data("select mmyy from " + user + "."+table_name+" where mmyy='" + mmyy + "' and syn=0").Tables[0].Rows.Count > 0;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Giờ bắt đầu đồng bộ hình bn .
        /// </summary>
        public int Gio_bat_dau_dongbo_hinhbn
        { // id=13;
            get
            {
                try
                {
                    return int.Parse(get_data("select giatri from " + user + ".syn_thongso where id=13").Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    return 1;
                }
            }

        }

        /// <summary>
        /// Phut bắt đầu đồng bộ hình bn .
        /// </summary>
        public int Phut_bat_dau_dongbo_hinhbn
        { // id=14;
            get
            {
                try
                {
                    return int.Parse(get_data("select giatri from " + user + ".syn_thongso where id=14").Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    return 0;
                }
            }

        }

        /// <summary>
        /// Giờ bắt đầu đồng bộ hình cdha .
        /// </summary>
        public int Gio_bat_dau_dongbo_hinhCDHA
        { // id=15;
            get
            {
                try
                {
                    return int.Parse(get_data("select giatri from " + user + ".syn_thongso where id=15").Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    return 1;
                }
            }

        }

        /// <summary>
        /// Phut bắt đầu đồng bộ hình bn .
        /// </summary>
        public int Phut_bat_dau_dongbo_hinhcdha
        { // id=16;
            get
            {
                try
                {
                    return int.Parse(get_data("select giatri from " + user + ".syn_thongso where id=16").Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    return 0;
                }
            }

        }

        /// <summary>
        /// Giờ bắt đầu đồng bộ hình cdha .
        /// </summary>
        public int Gio_bat_dau_dongbo_hinhChungtu
        { // id=20;
            get
            {
                try
                {
                    return int.Parse(get_data("select giatri from " + user + ".syn_thongso where id=20").Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    return 4;
                }
            }

        }
        /// <summary>
        /// Phút bắt đầu đồng bộ hình cdha .
        /// </summary>
        public int Phut_bat_dau_dongbo_hinhChungtu
        { // id=21;
            get
            {
                try
                {
                    return int.Parse(get_data("select giatri from " + user + ".syn_thongso where id=21").Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    return 1;
                }
            }

        }
        /// <summary>
        /// Đánh dấu những mmyy đã được tạo function
        /// </summary>
        /// <param name="mmyy"></param>
        /// <param name="syn"></param>
        /// <param name="table_name"></param>
        public void udp_syn_manager_schema(string mmyy, int syn,string table_name)
        {
            sql = "update " + user + "."+table_name+" set syn =" + syn + " where mmyy='" + mmyy + "'";
            try
            {
                con = new NpgsqlConnection(sConn);
                cmd = new NpgsqlCommand(sql, con);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (i == 0)
                {
                    sql = "insert into " + user + ".syn_manager_schema(mmyy,syn) values ('" + mmyy + "'," + syn + ")";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
        /// <summary>
        /// Chuyển số liệu xuống máy trạm.client chính là máy trạm
        /// </summary>
        /// <param name="client"></param>
        /// <param name="schema"></param>
        /// <param name="table"></param>
        //public void Syn_table(Client client, string schema, string table)
        //{
        //    string dblinks_client = client.DbLink;
        //    if (!bShemaValid(schema))
        //    {
        //        return;
        //    }
        //    sql = " CREATE OR REPLACE FUNCTION " + schema + ".syn_" + table+ "()";
        //    sql += " RETURNS void AS ";
        //    sql += " $BODY$ \n";
        //    // Khai báo biến cho function.
        //    sql += " DECLARE " + get_Agument(schema, table).Replace(',', ';') + ";\n";
        //    sql += " cur_" + table + " cursor is select " + get_columnsname(schema, table) + " from " + schema + "." + table;
        //    sql += " begin \n";
        //    // mở đọc dữ liệu từ table.
        //    sql += " open cur_" + table + ";\n";
        //    // sql += " if(found = false) then  raise exception 'không mở được kết nối tới table " + table + " ';end if;\n";
        //    sql += " loop ";
        //    // chuyển số liệu vào biến.
        //    sql += " fetch cur_" + table + " into " + get_variable(schema, table) + ";\n";
        //    sql += " if found = false then exit;end if;\n";
        //    // cập nhật giá trị nếu 
        //    sql += " update " + schema + "." + table + " set " + get_Parameter(schema, table, getPrimaryKeys(schema, table)) + get_Condition(getPrimaryKeys(schema, table)) + ";\n";
        //    sql += " if found = false then ";
        //    sql += " insert into " + schema + "." + table + "(" + get_columnsname(schema, table) + ") values (" + get_variable(schema, table) + ");\n";
        //    //sql += " if(found = false) then  raise exception 'cập nhật table " + table + " bị lỗi ';end if;\n";
        //    sql += " end if;\n";
        //    sql += " end loop ;";
        //    sql += " close cur_" + table + ";\n";
        //    // update trạng thái nhận được của máy server
        //    if (!bTonkho)
        //    {
        //        if (stt == 1)
        //            sql += " update " + schema + "." + table + " set chuyendi='111'||substr(chuyendi," + (stt + 3).ToString() + ") where substr(chuyendi," + stt + ",3)='www';\n";
        //        else
        //            sql += " update " + schema + "." + table + " set chuyendi=substr(chuyendi,1," + (stt - 1).ToString() + ")||'111'||substr(chuyendi," + (stt + 3).ToString() + ") where substr(chuyendi," + stt + ",3)='www';\n";
        //        // sql += " if(found = false) then  raise exception 'không cập nhật được trạng thái nhận được của máy server ';end if;\n";
        //        // update từ trạng thái chờ sang trang thái đã thực hiện chuyển. 
        //        if (stt == 1)
        //            sql += " update " + schema + "." + table + "@" + dblinks_client + " set chuyendi='111'||substr(chuyendi," + (stt + 3).ToString() + ") where substr(chuyendi," + stt + ",3)='www';\n";
        //        else
        //            sql += " update " + schema + "." + table + "@" + dblinks_client + " set chuyendi=substr(chuyendi,1," + (stt - 1).ToString() + ")||'111'||substr(chuyendi," + (stt + 3).ToString() + ") where substr(chuyendi," + stt + ",3)='www';\n";
        //    }
        //    // sql += " if(found = false) then  raise exception 'cập nhật trạng thái đã chuyên trên máy trạm không thành công ';end if;\n";
        //    sql += " end;\n";
        //    sql += " $BODY$ ";
        //    sql += " LANGUAGE 'plpgsql' VOLATILE;\n";

        //    if (!execute_data(sql))
        //    {
        //        upd_Events(DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("hh:mm:ss"), "create function", "", client.ServerName, schema, table, error, "1", sComputer, " ");
        //    }
        //}
        #region IDisposable Members

        public void Dispose()
        {
            if (con != null) { con.Close(); con.Dispose(); }
            if (cmd != null) cmd.Dispose();
        }

        #endregion

        public DataRow getrowbyid(DataTable dt, string exp)
        {
            try
            {
                DataRow[] r = dt.Select(exp);
                return r[0];
            }
            catch { return null; }
        }
        public void KiemTraCauTruc_CN(string aschema, string atablename,string dbname_nguon, string dbname_dich, string s_connnguon, string s_connDich)
        {
            DataSet dsnguon;
            DataSet dsdich;

            string asql = "";
            asql = " select table_schema as a1, table_name as a2, column_name as a3, 'alter table '||table_schema||'.'||table_name ||' add '||column_name||' '|| data_type ||' '|| case when trim(numeric_precision)='' or numeric_precision is null then '' else '('||numeric_precision||') ' end ||case when column_default is null then '' else ' default '||column_default end ||';' as sql, to_number('0') as khac ";
            asql += " from information_schema.columns  where table_catalog='" + dbname_nguon + "' AND table_schema='" + aschema + "' and table_name ='"+atablename+"' and data_type<>'character varying' ";
            asql += " UNION ALL ";
            asql += " select table_schema as a1, table_name as a2, column_name as a3, 'alter table '||table_schema||'.'||table_name ||' add '||column_name||' '|| data_type ||' ('|| character_maximum_length||')'||';' as sql , to_number('0') as khac ";
            asql += " from information_schema.columns  where table_catalog='" + dbname_nguon + "' AND table_schema='" + aschema + "' and table_name ='" + atablename + "' and data_type='character varying' ";
            dsnguon = get_data(asql, s_connnguon);
            //            
            asql = " select table_schema as a1, table_name as a2, column_name as a3, 'alter table '||table_schema||'.'||table_name ||' add '||column_name||' '|| data_type ||' '|| case when trim(numeric_precision)='' or numeric_precision is null then '' else '('||numeric_precision||')' end ||case when column_default is null then '' else ' default '||column_default end ||';' as sql, to_number('0') as khac ";
            asql += " from information_schema.columns  where table_catalog='" + dbname_dich + "' AND table_schema='" + aschema + "' and table_name ='" + atablename + "' and data_type<>'character varying' ";
            asql += " UNION ALL ";
            asql += " select table_schema as a1, table_name as a2, column_name as a3, 'alter table '||table_schema||'.'||table_name ||' add '||column_name||' '|| data_type ||' ('|| character_maximum_length||')'||';' as sql , to_number('0') as khac ";
            asql += " from information_schema.columns  where table_catalog='" + dbname_dich + "' AND table_schema='" + aschema + "' and table_name ='" + atablename + "' and data_type='character varying' ";
            if (s_connDich != "") dsdich = get_data(asql, s_connDich);
            else dsdich = get_data(asql);

            string s_exp = "";
            DataRow dr1;
            int iCount = 0, iStt = 0, iKhac = 0;
            //neu server nguon khac dich --> tao ben dich
            foreach (DataRow dr in dsnguon.Tables[0].Rows)
            {
                iStt += 1;
                s_exp = "a2='" + dr["a2"].ToString() + "' and a3='" + dr["a3"].ToString() + "'";
                dr1 = getrowbyid(dsdich.Tables[0], s_exp);
                if (dr1 == null)
                {            
                    asql = dr["sql"].ToString();
                    if (s_connDich == "")
                    {
                        execute_data(asql);
                    }
                    else execute_data(asql, s_connDich);
                    iKhac += 1;
                }                
            }
            //neu ben dich khac nguon --> tao nguon
            foreach (DataRow dr in dsdich.Tables[0].Rows)
            {
                iStt += 1;
                s_exp = "a2='" + dr["a2"].ToString() + "' and a3='" + dr["a3"].ToString() + "'";
                dr1 = getrowbyid(dsnguon.Tables[0], s_exp);
                if (dr1 == null)
                {
                    asql = dr["sql"].ToString();
                    execute_sql(asql, s_connnguon);
                    iKhac += 1;
                }
            }

        }
        public void update(Client c_client,string schema,string tablename,System.Windows.Forms.RichTextBox text,
            System.Windows.Forms.ToolStripStatusLabel status,System.Windows.Forms.ProgressBar prostatus, ref string  s_HostErrorConnection)
        {
            try
            {
                prostatus.Value = 0;
                prostatus.Minimum = 0;
                //Kiem tra cau truc truoc khi dong bo
                
                //System.Windows.Forms.ToolTip tooltip = new ToolTip();
                string strConn_client = "Server=0.0.0.0;Port=5432;User Id=medisoft;Password=links1920;Database=medisoft2007;Encoding=UNICODE;Pooling=true;";
                strConn_client = "Server=" + c_client.Host + ";Port=" + c_client.Port + ";User Id=" + c_client.Userdb + ";Password=" + c_client.Passworddb + ";Database=" + c_client.DatabaseName + ";Encoding=UNICODE;Pooling=true;";
                //
                string s_dbNameDich = Maincode("Database");
                KiemTraCauTruc_CN(schema, tablename, c_client.DatabaseName, s_dbNameDich, strConn_client, "");
                //
                //tu dong add field chuyendi
                string asql0 = "select chuyendi from " + schema + "." + tablename + " where 1=2";
                DataSet lds00 = get_data(asql0);
                if (lds00 == null || lds00.Tables.Count <= 0)
                {
                    asql0 = "alter table " + schema + "." + tablename + " add chuyendi varchar(300) default lpad('0',300,'0')";
                    execute_data(asql0);
                }
                asql0 = "select chuyendi from " + schema + "." + tablename + " where 1=2";
                lds00 = get_data(asql0,strConn_client);
                if (lds00 == null || lds00.Tables.Count <= 0)
                {
                    asql0 = "alter table " + schema + "." + tablename + " add chuyendi varchar(300) default lpad('0',300,'0')";
                    execute_data(asql0, strConn_client);
                }
                //
                string s_select = "";//field nay part kieu date thanh kieu character
                string s_insert = "insert into " + schema + "." + tablename + "(";//menh de insert
                string s_update = "update " + schema + "." + tablename + " set ";//menh de update
                string s_value_insert = " (";//value cua menh de insert
                string s_dk_update = "";// dieu kien udpdate
                string s_para_update = "", s_para_update_dk = "";
                #region build_sql
                status.Text = "Build query";
                //string s_sql = "select lower(a.column_name) as column_name,lower(a.data_type) as data_type,decode(substr(b.constraint_name,1,3),'pk_',b.constraint_name,'') as key,b.ordinal_position as stt " +
                string s_sql = "select lower(a.column_name) as column_name,lower(a.data_type) as data_type, case when b.position_in_unique_constraint is not null then '' else b.constraint_name end as key,b.ordinal_position as stt " +
                " from information_schema.columns a,information_schema.key_column_usage b where a.table_schema=b.table_schema(+) " +
                " and a.table_name=b.table_name(+) and a.column_name=b.column_name(+) and lower(a.column_name) not in('ngayud','oid') and " +
                 " a.table_schema='" + schema.ToLower() + "' and a.table_name='" + tablename.ToLower() + "'";
                string s_column_name = "", s_data_type = "", s_keys = "";
                DataSet dstmp = new DataSet();
                dstmp = get_data(s_sql);
                Application.DoEvents();
                string tmp_column = ",";
                string s_cols_type = "", s_cols_type_upd = "", s_cols_type1 = "";
                foreach (DataRow row in dstmp.Tables[0].Select("", "key desc, column_name"))
                {
                    //
                    s_cols_type1 = "0";
                    //
                    s_column_name = row["column_name"].ToString();
                    if (tmp_column.IndexOf("," + s_column_name + ",") >= 0) continue;//binh 100212
                    else
                    {                        
                        tmp_column += s_column_name + ",";//binh 100212
                    }
                    //
                    //if (s_column_name == row["column_name"].ToString()) continue;////binh 100212 comment                    
                    s_data_type = row["data_type"].ToString();
                    s_keys = row["key"].ToString();
                    s_insert += s_column_name + ",";
                    if (s_data_type.IndexOf("timestamp") > -1)
                    {
                        s_select += "to_char(" + s_column_name + ",'dd/mm/yyyy hh24:mi') as " + s_column_name + ",";
                        s_value_insert += "to_date(:" + s_column_name + ",'dd/mm/yyyy hh24:mi')" + ",";
                    }
                    else if (s_data_type.IndexOf("date") > -1)
                    {
                        s_select += "to_char(" + s_column_name + ",'dd/mm/yyyy') as " + s_column_name + ",";
                        s_value_insert += "to_date(:" + s_column_name + ",'dd/mm/yyyy')" + ",";
                    }
                    else if (s_data_type.IndexOf("character") > -1 || s_data_type.IndexOf("text") > -1)
                    {
                        s_select += s_column_name + ",";
                        s_value_insert += ":" + s_column_name + ",";
                    }//
                    else if (s_data_type.IndexOf("numeric") > -1)
                    {
                        s_select += " coalesce(" + s_column_name + ",0) as " + s_column_name + ",";
                        s_value_insert += ":" + s_column_name + ",";
                        s_cols_type1 = "1";
                    }//numeric
                    else
                    {
                        s_select += s_column_name + ",";
                        s_value_insert += ":" + s_column_name + ",";
                    }
                    if (s_keys != "")
                    {
                        s_dk_update += s_dk_update == "" ? "" : " and ";
                        s_para_update_dk += s_column_name + ",";
                        if (s_data_type.IndexOf("timestamp") > -1)
                        {
                            s_dk_update += " to_char(" + s_column_name + ",'dd/mm/yyyy hh24:mi')=:" + s_column_name;// +",";
                        }
                        else if (s_data_type.IndexOf("date") > -1)
                        {
                            s_dk_update += " to_char(" + s_column_name + ",'dd/mm/yyyy')=:" + s_column_name;// +",";
                        }
                        else if (s_data_type.IndexOf("character") > -1 || s_data_type.IndexOf("text") > -1)
                        {
                            s_dk_update += s_column_name + "=:" + s_column_name + "";// ",";//binh 110112: bo dau ,
                        }
                        else
                        {
                            s_dk_update += s_column_name + "=:" + s_column_name + "";// ",";
                        }
                    }
                    else
                    {
                        s_para_update += s_column_name + ",";
                        if (s_data_type.IndexOf("timestamp") > -1)
                        {
                            s_update += s_column_name + "=to_date(:" + s_column_name + ",'dd/mm/yyyy hh24:mi')" + ",";
                        }
                        else if (s_data_type.IndexOf("date") > -1)
                        {
                            s_update += s_column_name + "=to_date(:" + s_column_name + ",'dd/mm/yyyy')" + ",";
                        }
                        else if (s_data_type.IndexOf("character") > -1 || s_data_type.IndexOf("text") > -1)
                        {
                            s_update += s_column_name + "=:" + s_column_name + ",";
                        }
                        else
                        {
                            s_update += s_column_name + "=:" + s_column_name + ",";
                        }
                    }
                    s_cols_type += s_cols_type1 + ",";
                    Application.DoEvents();
                }
                
                dstmp.Dispose();
                #endregion
                s_select = s_select.Trim(',');
                s_update = s_update.Trim(',');
                s_dk_update = s_dk_update.Trim(',');
                s_para_update_dk = s_para_update_dk.Trim(',');
                s_insert = s_insert.Trim(',') + ")";
                s_value_insert = s_value_insert.Trim(',') + ")";
                s_para_update = s_para_update.Trim(',') + "," + s_para_update_dk;
                Application.DoEvents();
                #region xu ly client
                status.Text = "Update client";
                int iOK = execute_sql("update " + schema + "." + tablename + " set chuyendi=lpad('0',300,'0') where chuyendi is null or chuyendi=''", strConn_client);
                if (iOK == 2) return;//loi khi ket noi client: exit
                else if (iOK == 1)
                {
                    s_HostErrorConnection = c_client.Host;
                    return;
                }
                int i_stt = c_client.STT;
                int i_index = i_stt - 1;
                Application.DoEvents();
                status.Text = "Mark client";
                s_sql = "update " + schema + "." + tablename + " set " +
                    " chuyendi=coalesce(substr(chuyendi,1," + i_index + "),'')||'www'||substr(chuyendi," + ((int)(i_stt + 3)).ToString() + ") " +
                    " where substr(chuyendi," + i_stt+ ",3)='000'";
                execute_data(s_sql, strConn_client);
               
                Application.DoEvents();
                status.Text = "Get data...";
                //
                if(tablename.ToLower()=="ct_doan")
                {
                    string asql2 = "update medibv.ct_doan set laymau_tungay=ngay, laymau_denngay=ngay, giolaymausang=to_timestamp('00:00','hh24:mi'), giolaymauchieu=to_timestamp('00:00','hh24:mi') where laymau_tungay is null";
                    execute_data(asql2);
                    asql2 = " update medibv.ct_doan set khuvuclaymau=false where khuvuclaymau is null";
                    execute_data(asql2);
                }
                //
                DataTable data = new DataTable();
                data = get_data("select " + s_select + " from " + schema + "." + tablename + " where substr(chuyendi," + i_stt + ",3)='www'", strConn_client).Tables[0];
                #endregion
                #region chuyen ve may local
                string _update = s_update + " where " + s_dk_update;
                string _insert = s_insert + " values " + s_value_insert;
                if (con_server != null)
                {
                    con_server.Close(); con_server.Dispose();
                }
                con_server = new NpgsqlConnection(sConn);
                con_server.Open();
                if (con_client != null)
                {
                    con_client.Close(); con_client.Dispose();
                }
                con_client = new NpgsqlConnection(strConn_client);
                con_client.Open();
                Application.DoEvents();
                status.Text = "Syn..." + tablename.ToUpper();
                prostatus.ForeColor = System.Drawing.Color.Red;
                int i_count = data.Rows.Count;
                prostatus.Maximum = i_count;
                text.Text = "";
                text.Refresh();
                string s_text = "";
                string[] arr_type = s_cols_type.Trim().Trim(',').Split(',');
                int icol=0;                
                int i_current = 0;
                foreach (DataRow rSave in data.Rows)
                {
                    prostatus.Value += 1;
                    i_current += 1;
                    status.Text = "Syn..." + tablename.ToUpper() + " - " + i_current.ToString() + "/" + i_count;                    
                    Application.DoEvents();
                    try
                    {
                        cmd = new NpgsqlCommand(_update, con_server);
                        cmd.CommandType = CommandType.Text;
                        s_text = "";
                        icol=0;
                        foreach (string s_col in s_para_update.Trim(',').Split(','))
                        {
                            string s_val = rSave[s_col].ToString();
                            //if (arr_type[icol] == "1" && s_val == "") s_val = "0";//binh 260612
                            if (s_col.ToLower() == "chuyendi") { s_val = s_val.Substring(0, i_index) + "111" + s_val.Substring(i_index + 3); }
                            if (s_val == "") s_val = null;
                            cmd.Parameters.Add(s_col, s_val);
                            s_text += s_val + ",";
                            icol += 1;
                        }
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            s_text = s_text.Trim(',') + "\n";
                            if (text.Lines.Length > 30) text.Text = "Update: " + s_text;
                            else text.Text = "Update: " + s_text + text.Text;
                        }
                        s_text = "";
                        if (i == 0)
                        {
                            cmd = new NpgsqlCommand(_insert, con_server);
                            cmd.CommandType = CommandType.Text;
                            icol = 0;
                            foreach (DataColumn col in data.Columns)
                            {
                                string s_val = rSave[col.ColumnName].ToString();
                                if (arr_type[icol] == "1" && s_val == "") s_val = "0";//binh 260612
                                if (col.ColumnName.ToLower() == "chuyendi") { s_val = s_val.Substring(0, i_index) + "111" + s_val.Substring(i_index + 3); }
                                else { s_text += s_val + ","; }
                                if (s_val == "") s_val = null;
                                cmd.Parameters.Add(col.ColumnName, s_val);
                                //
                                icol += 1;
                            }
                            cmd.ExecuteNonQuery();
                            s_text = s_text.Trim(',') + "\n";

                            if (text.Lines.Length > 30) text.Text = s_text;
                            else text.Text = s_text + text.Text;
                        }
                        //tooltip.SetToolTip(text, prostatus.Value.ToString() + "/" + i_count.ToString());
                        s_sql = "update " + schema + "." + tablename + " set chuyendi=coalesce(substr(chuyendi,1," + i_index.ToString() + "),'')||'111'||substr(chuyendi," + ((int)(i_stt + 3)).ToString() + ") where substr(chuyendi," + i_stt + ",3)='www' and " + s_dk_update;
                        cmd.Dispose();
                        cmd = new NpgsqlCommand(s_sql, con_client);
                        cmd.CommandType = CommandType.Text;
                        foreach (string s_col in s_para_update_dk.Trim(',').Split(','))
                        {
                            cmd.Parameters.Add(s_col, rSave[s_col].ToString());
                        }
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        string s = ex.ToString();
                        if (ex.ToString().IndexOf("No connection could be made") >= 0)
                        {
                            s_HostErrorConnection = c_client.Host;
                            break;
                        }
                        upd_Events(DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("hh:mm"), c_client.Host + "^" + c_client.DatabaseName, rSave[0].ToString(), "", schema, tablename, "", s, System.Environment.MachineName.ToUpper(), "");
                      
                    }
                    finally
                    {
                        cmd.Dispose();
                    }
                    Application.DoEvents();
                }
                #endregion
                data.Dispose();
                prostatus.ForeColor = System.Drawing.SystemColors.Highlight;
                status.Text = "Finish.";
                Application.DoEvents();
                con_client.Close();
                con_client.Dispose();
                con_server.Close();
                con_server.Dispose();
            }
            catch (Exception er)
            {
                error = er.Message;
            }
            finally
            {                
                cmd.Dispose();
                con.Dispose();                
            }
        }

        public void update_chungtu(Client c_client, string schema, string tablename, System.Windows.Forms.RichTextBox text,
            System.Windows.Forms.ToolStripStatusLabel status, System.Windows.Forms.ProgressBar prostatus,string dieukien)
        {
            try
            {
                prostatus.Value = 0;
                prostatus.Minimum = 0;
                //System.Windows.Forms.ToolTip tooltip = new ToolTip();
                string strConn_client = "Server=0.0.0.0;Port=5432;User Id=medisoft;Password=links1920;Database=medisoft2007;Encoding=UNICODE;Pooling=true;";
                strConn_client = "Server=" + c_client.Host + ";Port=" + c_client.Port + ";User Id=" + c_client.Userdb + ";Password=" + c_client.Passworddb + ";Database=" + c_client.DatabaseName + ";Encoding=UNICODE;Pooling=true;";
                string s_select = "";//field nay part kieu date thanh kieu character
                string s_insert = "insert into " + schema + "." + tablename + "(";//menh de insert
                string s_update = "update " + schema + "." + tablename + " set ";//menh de update
                string s_value_insert = " (";//value cua menh de insert
                string s_dk_update = "";// dieu kien udpdate
                string s_para_update = "", s_para_update_dk = "";
                #region build_sql
                status.Text = "Build query";
                string s_sql = "select lower(a.column_name) as column_name,lower(a.data_type) as data_type,decode(substr(b.constraint_name,1,3),'pk_',b.constraint_name,'') as key,b.ordinal_position as stt " +
                " from information_schema.columns a,information_schema.key_column_usage b where a.table_schema=b.table_schema(+) " +
                " and a.table_name=b.table_name(+) and a.column_name=b.column_name(+) and lower(a.column_name) not in('ngayud','oid') and " +
                 " a.table_schema='" + schema.ToLower() + "' and a.table_name='" + tablename.ToLower() + "'";
                string s_column_name = "", s_data_type = "", s_keys = "";
                DataSet dstmp = new DataSet();
                dstmp = get_data(s_sql);
                Application.DoEvents();
                string tmp_column = ",";
                foreach (DataRow row in dstmp.Tables[0].Select("", "key desc, column_name"))
                {
                    s_column_name = row["column_name"].ToString();
                    if (tmp_column.IndexOf("," + s_column_name + ",") >= 0) continue;//binh 100212
                    else
                    {
                        tmp_column += s_column_name + ",";//binh 100212
                    }
                    //
                    //if (s_column_name == row["column_name"].ToString()) continue;////binh 100212 comment                    
                    s_data_type = row["data_type"].ToString();
                    s_keys = row["key"].ToString();
                    s_insert += s_column_name + ",";
                    if (s_data_type.IndexOf("timestamp") > -1)
                    {
                        s_select += "to_char(" + s_column_name + ",'dd/mm/yyyy hh24:mi') as " + s_column_name + ",";
                        s_value_insert += "to_date(:" + s_column_name + ",'dd/mm/yyyy hh24:mi')" + ",";
                    }
                    else if (s_data_type.IndexOf("character") > -1 || s_data_type.IndexOf("text") > -1)
                    {
                        s_select += s_column_name + ",";
                        s_value_insert += ":" + s_column_name + ",";
                    }//
                    else if (s_data_type.IndexOf("numeric") > -1)
                    {
                        s_select += " coalesce(" + s_column_name + ",0) as " + s_column_name + ",";
                        s_value_insert += ":" + s_column_name + ",";
                    }//numeric
                    else
                    {
                        s_select += s_column_name + ",";
                        s_value_insert += ":" + s_column_name + ",";
                    }
                    if (s_keys != "")
                    {
                        s_dk_update += s_dk_update == "" ? "" : " and ";
                        s_para_update_dk += s_column_name + ",";
                        if (s_data_type.IndexOf("timestamp") > -1)
                        {
                            s_dk_update += " to_char(" + s_column_name + ",'dd/mm/yyyy hh24:mi')=:" + s_column_name;// +",";
                        }
                        else if (s_data_type.IndexOf("character") > -1 || s_data_type.IndexOf("text") > -1)
                        {
                            s_dk_update += s_column_name + "=:" + s_column_name + "";// ",";//binh 110112: bo dau ,
                        }
                        else
                        {
                            s_dk_update += s_column_name + "=:" + s_column_name + "";// ",";
                        }
                    }
                    else
                    {
                        s_para_update += s_column_name + ",";
                        if (s_data_type.IndexOf("timestamp") > -1)
                        {
                            s_update += s_column_name + "=to_date(:" + s_column_name + ",'dd/mm/yyyy hh24:mi')" + ",";
                        }
                        else if (s_data_type.IndexOf("character") > -1 || s_data_type.IndexOf("text") > -1)
                        {
                            s_update += s_column_name + "=:" + s_column_name + ",";
                        }
                        else
                        {
                            s_update += s_column_name + "=:" + s_column_name + ",";
                        }
                    }
                    Application.DoEvents();
                }

                dstmp.Dispose();
                #endregion
                s_select = s_select.Trim(',');
                s_update = s_update.Trim(',');
                s_dk_update = s_dk_update.Trim(',');
                s_para_update_dk = s_para_update_dk.Trim(',');
                s_insert = s_insert.Trim(',') + ")";
                s_value_insert = s_value_insert.Trim(',') + ")";
                s_para_update = s_para_update.Trim(',') + "," + s_para_update_dk;
                Application.DoEvents();
                #region xu ly client
                status.Text = "Update client";
                execute_data("update " + schema + "." + tablename + " set chuyendi=lpad('0',300,'0') where chuyendi is null or chuyendi=''", strConn_client);
                int i_stt = c_client.STT;
                int i_index = i_stt - 1;
                Application.DoEvents();
                status.Text = "Mark client";
                s_sql = "update " + schema + "." + tablename + " set " +
                    " chuyendi=coalesce(substr(chuyendi,1," + i_index + "),'')||'www'||substr(chuyendi," + ((int)(i_stt + 3)).ToString() + ") " +
                    " where substr(chuyendi," + i_stt + ",3)='000'";
                execute_data(s_sql, strConn_client);
                Application.DoEvents();
                status.Text = "Get data...";
                DataTable data = new DataTable();
                data = get_data("select " + s_select + " from " + schema + "." + tablename + " where substr(chuyendi," + i_stt + ",3)='www' "+dieukien, strConn_client).Tables[0];
                #endregion
                #region chuyen ve may local
                string _update = s_update + " where " + s_dk_update;
                string _insert = s_insert + " values " + s_value_insert;
                NpgsqlConnection con_server = new NpgsqlConnection(sConn);
                con_server.Open();
                NpgsqlConnection con_client = new NpgsqlConnection(strConn_client);
                con_client.Open();
                Application.DoEvents();
                status.Text = "Syn..." + tablename.ToUpper();
                prostatus.ForeColor = System.Drawing.Color.Red;
                int i_count = data.Rows.Count;
                prostatus.Maximum = i_count;
                text.Text = "";
                text.Refresh();
                foreach (DataRow rSave in data.Rows)
                {
                    prostatus.Value += 1;
                    Application.DoEvents();
                    try
                    {
                        cmd = new NpgsqlCommand(_update, con_server);
                        cmd.CommandType = CommandType.Text;
                        foreach (string s_col in s_para_update.Trim(',').Split(','))
                        {
                            string s_val = rSave[s_col].ToString();
                            if (s_col.ToLower() == "chuyendi") { s_val = s_val.Substring(0, i_index) + "111" + s_val.Substring(i_index + 3); }
                            cmd.Parameters.Add(s_col, s_val);
                        }
                        int i = cmd.ExecuteNonQuery();
                        string s_text = "";
                        if (i == 0)
                        {
                            cmd = new NpgsqlCommand(_insert, con_server);
                            cmd.CommandType = CommandType.Text;
                            foreach (DataColumn col in data.Columns)
                            {
                                string s_val = rSave[col.ColumnName].ToString();
                                if (col.ColumnName.ToLower() == "chuyendi") { s_val = s_val.Substring(0, i_index) + "111" + s_val.Substring(i_index + 3); }
                                else { s_text += s_val + ","; }
                                cmd.Parameters.Add(col.ColumnName, s_val);
                            }
                            cmd.ExecuteNonQuery();
                            s_text = s_text.Trim(',') + "\n";

                            if (text.Lines.Length > 500) text.Text = s_text;
                            else text.Text = s_text + text.Text;
                        }
                        //tooltip.SetToolTip(text, prostatus.Value.ToString() + "/" + i_count.ToString());
                        s_sql = "update " + schema + "." + tablename + " set chuyendi=coalesce(substr(chuyendi,1," + i_index.ToString() + "),'')||'111'||substr(chuyendi," + ((int)(i_stt + 3)).ToString() + ") where substr(chuyendi," + i_stt + ",3)='www' and " + s_dk_update;
                        cmd.Dispose();
                        cmd = new NpgsqlCommand(s_sql, con_client);
                        cmd.CommandType = CommandType.Text;
                        foreach (string s_col in s_para_update_dk.Trim(',').Split(','))
                        {
                            cmd.Parameters.Add(s_col, rSave[s_col].ToString());
                        }
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        string s = ex.ToString();
                        upd_Events(DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("hh:mm"), c_client.Host + "^" + c_client.DatabaseName, rSave[0].ToString(), "", schema, tablename, "", s, System.Environment.MachineName.ToUpper(), "");
                    }
                    Application.DoEvents();
                }
                #endregion
                data.Dispose();
                prostatus.ForeColor = System.Drawing.SystemColors.Highlight;
                status.Text = "Finish.";
                Application.DoEvents();
                con_client.Close();
                con_client.Dispose();
                con_server.Close();
                con_server.Dispose();
            }
            catch (Exception er)
            {
                error = er.Message;
            }
            finally
            {
                con.Dispose();
                cmd.Dispose();
            }
        }

        public void update(Client c_client, string schema, string tablename, System.Windows.Forms.RichTextBox text,
            System.Windows.Forms.ToolStripStatusLabel status,System.Windows.Forms.ProgressBar prostatus,
            string field_key,string s_tungay,string s_denngay)
        {
            try
            {
                prostatus.Value = 0;
                prostatus.Minimum = 0;
                //System.Windows.Forms.ToolTip tooltip = new ToolTip();
                string strConn_client = "Server=0.0.0.0;Port=5432;User Id=medisoft;Password=links1920;Database=medisoft2007;Encoding=UNICODE;Pooling=true;";
                strConn_client = "Server=" + c_client.Host + ";Port=" + c_client.Port + ";User Id=" + c_client.Userdb + ";Password=" + c_client.Passworddb + ";Database=" + c_client.DatabaseName + ";Encoding=UNICODE;Pooling=true;";
                //
                string s_dbNameDich = Maincode("Database");
                KiemTraCauTruc_CN(schema, tablename, c_client.DatabaseName, s_dbNameDich, strConn_client, "");
                //
                //tu dong add field chuyendi
                string asql0 = "select chuyendi from " + schema + "." + tablename + " where 1=2";
                DataSet lds00 = get_data(asql0);
                if (lds00 == null && lds00.Tables.Count <= 0)
                {
                    asql0 = "alter table " + schema + "." + tablename + " add chuyendi varchar(300) default lpad('0',300,'0')";
                    execute_data(asql0);
                }
                asql0 = "select chuyendi from " + schema + "." + tablename + " where 1=2";
                lds00 = get_data(asql0, strConn_client);
                if (lds00 == null && lds00.Tables.Count <= 0)
                {
                    asql0 = "alter table " + schema + "." + tablename + " add chuyendi varchar(300) default lpad('0',300,'0')";
                    execute_data(asql0, strConn_client);
                }
                //
                string s_select = "";//field nay part kieu date thanh kieu character
                string s_insert = "insert into " + schema + "." + tablename + "(";//menh de insert
                string s_update = "update " + schema + "." + tablename + " set ";//menh de update
                string s_value_insert = " (";//value cua menh de insert
                string s_dk_update = "";// dieu kien udpdate
                string s_para_update = "", s_para_update_dk = "";
                #region build_sql
                status.Text = "Build query";
                string s_sql = "select lower(a.column_name) as column_name,lower(a.data_type) as data_type,decode(substr(b.constraint_name,1,3),'pk_',b.constraint_name,'') as key,b.ordinal_position as stt " +
                " from information_schema.columns a,information_schema.key_column_usage b where a.table_schema=b.table_schema(+) " +
                " and a.table_name=b.table_name(+) and a.column_name=b.column_name(+) and lower(a.column_name) not in('ngayud','oid') and " +
                 " a.table_schema='" + schema.ToLower() + "' and a.table_name='" + tablename.ToLower() + "'";
                string s_column_name = "", s_data_type = "", s_keys = "";
                DataSet dstmp = new DataSet();
                dstmp = get_data(s_sql);
                Application.DoEvents();
                foreach (DataRow row in dstmp.Tables[0].Rows)
                {
                    s_column_name = row["column_name"].ToString();
                    s_data_type = row["data_type"].ToString();
                    s_keys = row["key"].ToString();
                    s_insert += s_column_name + ",";
                    if (s_data_type.IndexOf("timestamp") > -1)
                    {
                        s_select += "to_char(" + s_column_name + ",'dd/mm/yyyy hh24:mi') as " + s_column_name + ",";
                        s_value_insert += "to_date(:" + s_column_name + ",'dd/mm/yyyy hh24:mi')" + ",";
                    }
                    else if (s_data_type.IndexOf("character") > -1 || s_data_type.IndexOf("text") > -1)
                    {
                        s_select += s_column_name + ",";
                        s_value_insert += ":" + s_column_name + ",";
                    }
                    else if (s_data_type.IndexOf("numeric") > -1)
                    {
                        s_select += " coalesce(" + s_column_name + ",0) as " + s_column_name + ",";
                        s_value_insert += ":" + s_column_name + ",";
                    }
                    else
                    {
                        s_select += s_column_name + ",";
                        s_value_insert += ":" + s_column_name + ",";
                    }
                    if (s_keys != "")
                    {
                        s_dk_update += s_dk_update == "" ? "" : " and ";
                        s_para_update_dk += s_column_name + ",";
                        if (s_data_type.IndexOf("timestamp") > -1)
                        {
                            s_dk_update += " to_char(" + s_column_name + ",'dd/mm/yyyy hh24:mi')=:" + s_column_name + ",";
                        }
                        else if (s_data_type.IndexOf("character") > -1 || s_data_type.IndexOf("text") > -1)
                        {
                            s_dk_update += s_column_name + "=:" + s_column_name + ",";
                        }
                        else
                        {
                            s_dk_update += s_column_name + "=:" + s_column_name + ",";
                        }
                    }
                    else
                    {
                        s_para_update += s_column_name + ",";
                        if (s_data_type.IndexOf("timestamp") > -1)
                        {
                            s_update += s_column_name + "=to_date(:" + s_column_name + ",'dd/mm/yyyy hh24:mi')" + ",";
                        }
                        else if (s_data_type.IndexOf("character") > -1 || s_data_type.IndexOf("text") > -1)
                        {
                            s_update += s_column_name + "=:" + s_column_name + ",";
                        }
                        else
                        {
                            s_update += s_column_name + "=:" + s_column_name + ",";
                        }
                    }
                    Application.DoEvents();
                }
                dstmp.Dispose();
                #endregion
                s_select = s_select.Trim(',');
                s_update = s_update.Trim(',');
                s_dk_update = s_dk_update.Trim(',');
                s_para_update_dk = s_para_update_dk.Trim(',');
                s_insert = s_insert.Trim(',') + ")";
                s_value_insert = s_value_insert.Trim(',') + ")";
                s_para_update = s_para_update.Trim(',') + "," + s_para_update_dk;
                Application.DoEvents();
                #region xu ly client
                status.Text = "Update client";
                execute_data("update " + schema + "." + tablename + " set chuyendi=lpad('0',300,'0') where chuyendi is null or chuyendi=''", strConn_client);
                int i_stt = c_client.STT;
                int i_index = i_stt - 1;
                Application.DoEvents();
                status.Text = "Mark client";
                s_sql = "update " + schema + "." + tablename + " set " +
                    " chuyendi=coalesce(substr(chuyendi,1," + i_index + "),'')||'www'||substr(chuyendi," + ((int)(i_stt + 3)).ToString() + ") " +
                    " where " + field_key + "<>0 and to_date(to_char(to_date(substr(to_char(" + field_key + "),1,6),'yymmdd'),'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tungay + "','dd/mm/yyyy') and to_date('" + s_denngay + "','dd/mm/yyyy') ";
                execute_data(s_sql, strConn_client);
                Application.DoEvents();
                status.Text = "Get data...";
                DataTable data = new DataTable();
                data = get_data("select " + s_select + " from " + schema + "." + tablename + " where substr(chuyendi," + i_stt + ",3)='www'", strConn_client).Tables[0];
                #endregion
                #region chuyen ve may local
                string _update = s_update + " where " + s_dk_update;
                string _insert = s_insert + " values " + s_value_insert;
                NpgsqlConnection con_server = new NpgsqlConnection(sConn);
                con_server.Open();
                NpgsqlConnection con_client = new NpgsqlConnection(strConn_client);
                con_client.Open();
                Application.DoEvents();
                status.Text = "Syn..." + tablename.ToUpper();
                //prostatus.ForeColor = System.Drawing.Color.Red;
                int i_count = data.Rows.Count;
                prostatus.Maximum = i_count;
                text.Text = "";
                text.Refresh();
                foreach (DataRow rSave in data.Rows)
                {
                    prostatus.Value += 1;
                    Application.DoEvents();
                    try
                    {
                        cmd = new NpgsqlCommand(_update, con_server);
                        cmd.CommandType = CommandType.Text;
                        foreach (string s_col in s_para_update.Split(','))
                        {
                            string s_val = rSave[s_col].ToString();
                            if (s_col.ToLower() == "chuyendi") { s_val = s_val.Substring(0, i_index) + "111" + s_val.Substring(i_index + 3); }
                            if (s_val == "") s_val = null;
                            cmd.Parameters.Add(s_col, s_val);
                        }
                        int i = cmd.ExecuteNonQuery();
                        string s_text = "";
                        if (i == 0)
                        {
                            cmd = new NpgsqlCommand(_insert, con_server);
                            cmd.CommandType = CommandType.Text;
                            foreach (DataColumn col in data.Columns)
                            {
                                string s_val = rSave[col.ColumnName].ToString();
                                if (col.ColumnName.ToLower() == "chuyendi") { s_val = s_val.Substring(0, i_index) + "111" + s_val.Substring(i_index + 3); }
                                else { s_text += s_val + ","; }
                                if (s_val == "") s_val = null;
                                cmd.Parameters.Add(col.ColumnName, s_val);
                            }
                            cmd.ExecuteNonQuery();
                            s_text = s_text.Trim(',') + "\n";
                            text.Text = s_text + text.Text;
                        }
                        //tooltip.SetToolTip(text, prostatus.Value.ToString() + "/" + i_count.ToString());
                        string s_upd_done = "";
                        if (tablename.Trim() == "v_chidinh") s_upd_done = ",done=1 ";
                        s_sql = "update " + schema + "." + tablename + " set chuyendi=coalesce(substr(chuyendi,1," + i_index.ToString() + "),'')||'111'||substr(chuyendi," + ((int)(i_stt + 3)).ToString() + ")" + s_upd_done + " where substr(chuyendi," + i_stt + ",3)='www' and " + s_dk_update;
                        cmd.Dispose();
                        cmd = new NpgsqlCommand(s_sql, con_client);
                        cmd.CommandType = CommandType.Text;
                        foreach (string s_col in s_para_update_dk.Trim(',').Split(','))
                        {
                            cmd.Parameters.Add(s_col, rSave[s_col].ToString());
                        }
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        string s = ex.ToString();
                        upd_Events(DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("hh:mm"), c_client.Host + "^" + c_client.DatabaseName, rSave[0].ToString(), "", schema, tablename, "", s, System.Environment.MachineName.ToUpper(), "");
                    }
                    Application.DoEvents();
                }
                #endregion
                data.Dispose();
                //prostatus.ForeColor = System.Drawing.SystemColors.Highlight;
                status.Text = "Finish.";
                Application.DoEvents();
                con_client.Close();
                con_client.Dispose();
                con_server.Close();
                con_server.Dispose();
            }
            catch (Exception er)
            {
                error = er.Message;
            }
            finally
            {
                con.Dispose();
                cmd.Dispose();
            }
        }
        public void update(Client c_client, string schema, string tablename, System.Windows.Forms.RichTextBox text,
            System.Windows.Forms.ToolStripStatusLabel status, System.Windows.Forms.ProgressBar prostatus,
            string field_key, string s_tungay, string s_denngay,ref string s_id,string s_idkq)
        {
            try
            {
                prostatus.Value = 0;
                prostatus.Minimum = 0;
                //System.Windows.Forms.ToolTip tooltip = new ToolTip();
                string strConn_client = "Server=0.0.0.0;Port=5432;User Id=medisoft;Password=links1920;Database=medisoft2007;Encoding=UNICODE;Pooling=true;";
                strConn_client = "Server=" + c_client.Host + ";Port=" + c_client.Port + ";User Id=" + c_client.Userdb + ";Password=" + c_client.Passworddb + ";Database=" + c_client.DatabaseName + ";Encoding=UNICODE;Pooling=true;";
                //
                string s_dbNameDich = Maincode("Database");
                KiemTraCauTruc_CN(schema, tablename, c_client.DatabaseName, s_dbNameDich, strConn_client, "");
                //
                //tu dong add field chuyendi
                string asql0 = "select chuyendi from " + schema + "." + tablename + " where 1=2";
                DataSet lds00 = get_data(asql0);
                if (lds00 == null && lds00.Tables.Count <= 0)
                {
                    asql0 = "alter table " + schema + "." + tablename + " add chuyendi varchar(300) default lpad('0',300,'0')";
                    execute_data(asql0);
                }
                asql0 = "select chuyendi from " + schema + "." + tablename + " where 1=2";
                lds00 = get_data(asql0, strConn_client);
                if (lds00 == null && lds00.Tables.Count <= 0)
                {
                    asql0 = "alter table " + schema + "." + tablename + " add chuyendi varchar(300) default lpad('0',300,'0')";
                    execute_data(asql0, strConn_client);
                }
                //
                string s_select = "";//field nay part kieu date thanh kieu character
                string s_insert = "insert into " + schema + "." + tablename + "(";//menh de insert
                string s_update = "update " + schema + "." + tablename + " set ";//menh de update
                string s_value_insert = " (";//value cua menh de insert
                string s_dk_update = "";// dieu kien udpdate
                string s_para_update = "", s_para_update_dk = "", s_dk = "";
                #region build_sql
                status.Text = "Build query";
                string s_sql = "select lower(a.column_name) as column_name,lower(a.data_type) as data_type,decode(substr(b.constraint_name,1,3),'pk_',b.constraint_name,'') as key,b.ordinal_position as stt " +
                " from information_schema.columns a,information_schema.key_column_usage b where a.table_schema=b.table_schema(+) " +
                " and a.table_name=b.table_name(+) and a.column_name=b.column_name(+) and lower(a.column_name) not in('ngayud','oid') and " +
                 " a.table_schema='" + schema.ToLower() + "' and a.table_name='" + tablename.ToLower() + "'";
                string s_column_name = "", s_data_type = "", s_keys = "";
                DataSet dstmp = new DataSet();
                dstmp = get_data(s_sql);
                Application.DoEvents();
                foreach (DataRow row in dstmp.Tables[0].Rows)
                {
                    s_column_name = row["column_name"].ToString();
                    s_data_type = row["data_type"].ToString();
                    s_keys = row["key"].ToString();
                    s_insert += s_column_name + ",";
                    if (s_data_type.IndexOf("timestamp") > -1)
                    {
                        s_select += "to_char(" + s_column_name + ",'dd/mm/yyyy hh24:mi') as " + s_column_name + ",";
                        s_value_insert += "to_date(:" + s_column_name + ",'dd/mm/yyyy hh24:mi')" + ",";
                    }
                    else if (s_data_type.IndexOf("character") > -1 || s_data_type.IndexOf("text") > -1)
                    {
                        s_select += s_column_name + ",";
                        s_value_insert += ":" + s_column_name + ",";
                    }
                    else if (s_data_type.IndexOf("numeric") > -1)
                    {
                        s_select += " coalesce(" + s_column_name + ",0) as " + s_column_name + ",";
                        s_value_insert += ":" + s_column_name + ",";
                    }
                    else
                    {
                        s_select += s_column_name + ",";
                        s_value_insert += ":" + s_column_name + ",";
                    }
                    if (s_keys != "")
                    {
                        s_dk_update += s_dk_update == "" ? "" : " and ";
                        s_para_update_dk += s_column_name + ",";
                        if (s_data_type.IndexOf("timestamp") > -1)
                        {
                            s_dk_update += " to_char(" + s_column_name + ",'dd/mm/yyyy hh24:mi')=:" + s_column_name;// + ","
                        }
                        else if (s_data_type.IndexOf("character") > -1 || s_data_type.IndexOf("text") > -1)
                        {
                            s_dk_update += s_column_name + "=:" + s_column_name;// + ","
                        }
                        else
                        {
                            s_dk_update += s_column_name + "=:" + s_column_name;// + ","
                        }
                    }
                    else
                    {
                        s_para_update += s_column_name + ",";
                        if (s_data_type.IndexOf("timestamp") > -1)
                        {
                            s_update += s_column_name + "=to_date(:" + s_column_name + ",'dd/mm/yyyy hh24:mi')" + ",";
                        }
                        else if (s_data_type.IndexOf("character") > -1 || s_data_type.IndexOf("text") > -1)
                        {
                            s_update += s_column_name + "=:" + s_column_name + ",";
                        }
                        else
                        {
                            s_update += s_column_name + "=:" + s_column_name + ",";
                        }
                    }
                    Application.DoEvents();
                }
                dstmp.Dispose();
                #endregion
                s_select = s_select.Trim(',');
                s_update = s_update.Trim(',');
                s_dk_update = s_dk_update.Trim(',');
                s_para_update_dk = s_para_update_dk.Trim(',');
                s_insert = s_insert.Trim(',') + ")";
                s_value_insert = s_value_insert.Trim(',') + ")";
                s_para_update = s_para_update.Trim(',') + "," + s_para_update_dk;
                Application.DoEvents();
                #region xu ly client
                status.Text = "Update client";
                if (tablename.Trim() == "xn_phieu") s_dk = " and madoituong=8 and lanin>0 ";
                if (s_idkq != "") s_dk += " and id in(" + s_idkq.Trim(',') + ")";
                execute_data("update " + schema + "." + tablename + " set chuyendi=lpad('0',300,'0') where (chuyendi is null or chuyendi='') "+s_dk+" ", strConn_client);
                int i_stt = c_client.STT;
                int i_index = i_stt - 1;
                Application.DoEvents();
                status.Text = "Mark client";
                s_sql = "update " + schema + "." + tablename + " set " +
                    " chuyendi=coalesce(substr(chuyendi,1," + i_index + "),'')||'www'||substr(chuyendi," + ((int)(i_stt + 3)).ToString() + ") " +
                    " where " + field_key + "<>0 " + s_dk + " and to_date(to_char(to_date(substr(to_char(" + field_key + "),1,6),'yymmdd'),'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tungay + "','dd/mm/yyyy') and to_date('" + s_denngay + "','dd/mm/yyyy') ";
                execute_data(s_sql, strConn_client);
                Application.DoEvents();
                status.Text = "Get data...";
                DataTable data = new DataTable();
                data = get_data("select " + s_select + " from " + schema + "." + tablename + " where substr(chuyendi," + i_stt + ",3)='www'", strConn_client).Tables[0];
                #endregion
                #region chuyen ve may local
                string _update = s_update + " where " + s_dk_update;
                string _insert = s_insert + " values " + s_value_insert;
                NpgsqlConnection con_server = new NpgsqlConnection(sConn);
                con_server.Open();
                NpgsqlConnection con_client = new NpgsqlConnection(strConn_client);
                con_client.Open();
                Application.DoEvents();
                status.Text = "Syn..." + tablename.ToUpper();
                //prostatus.ForeColor = System.Drawing.Color.Red;
                int i_count = data.Rows.Count;
                prostatus.Maximum = i_count;
                text.Text = "";
                text.Refresh();
                string s_idtmp = ""; s_id = "";
                foreach (DataRow rSave in data.Rows)
                {
                    if (s_idtmp != rSave["id"].ToString())
                    {
                        s_idtmp = rSave["id"].ToString();
                        s_id += rSave["id"].ToString() + ",";
                    }
                    prostatus.Value += 1;
                    Application.DoEvents();
                    try
                    {
                        cmd = new NpgsqlCommand(_update, con_server);
                        cmd.CommandType = CommandType.Text;
                        foreach (string s_col in s_para_update.Split(','))
                        {
                            string s_val = rSave[s_col].ToString();
                            if (s_col.ToLower() == "chuyendi") { s_val = s_val.Substring(0, i_index) + "111" + s_val.Substring(i_index + 3); }
                            if (s_val == "") s_val = null;
                            cmd.Parameters.Add(s_col, s_val);
                        }
                        int i = cmd.ExecuteNonQuery();
                        string s_text = "";
                        if (i == 0)
                        {
                            cmd = new NpgsqlCommand(_insert, con_server);
                            cmd.CommandType = CommandType.Text;
                            foreach (DataColumn col in data.Columns)
                            {
                                string s_val = rSave[col.ColumnName].ToString();
                                if (col.ColumnName.ToLower() == "chuyendi") { s_val = s_val.Substring(0, i_index) + "111" + s_val.Substring(i_index + 3); }
                                else { s_text += s_val + ","; }
                                if (s_val == "") s_val = null;
                                cmd.Parameters.Add(col.ColumnName, s_val);
                            }
                            cmd.ExecuteNonQuery();
                            s_text = s_text.Trim(',') + "\n";
                            text.Text = s_text + text.Text;
                        }
                        //tooltip.SetToolTip(text, prostatus.Value.ToString() + "/" + i_count.ToString());
                        s_sql = "update " + schema + "." + tablename + " set chuyendi=coalesce(substr(chuyendi,1," + i_index.ToString() + "),'')||'111'||substr(chuyendi," + ((int)(i_stt + 3)).ToString() + ") where substr(chuyendi," + i_stt + ",3)='www' and " + s_dk_update;
                        cmd.Dispose();
                        cmd = new NpgsqlCommand(s_sql, con_client);
                        cmd.CommandType = CommandType.Text;
                        foreach (string s_col in s_para_update_dk.Trim(',').Split(','))
                        {
                            cmd.Parameters.Add(s_col, rSave[s_col].ToString());
                        }
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        string s = ex.ToString();
                        upd_Events(DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("hh:mm"), c_client.Host + "^" + c_client.DatabaseName, rSave[0].ToString(), "", schema, tablename, "", s, System.Environment.MachineName.ToUpper(), "");
                    }
                    Application.DoEvents();
                }
                #endregion
                data.Dispose();
                //prostatus.ForeColor = System.Drawing.SystemColors.Highlight;
                status.Text = "Finish.";
                Application.DoEvents();
                con_client.Close();
                con_client.Dispose();
                con_server.Close();
                con_server.Dispose();
            }
            catch (Exception er)
            {
                error = er.Message;
            }
            finally
            {
                con.Dispose();
                cmd.Dispose();
            }
        }

        public void update(Client c_client, string schema, string tablename, System.Windows.Forms.RichTextBox text,
            System.Windows.Forms.ToolStripStatusLabel status, System.Windows.Forms.ProgressBar prostatus,
            string field_key, string s_tungay, string s_denngay, string _mabn)
        {
            try
            {
                prostatus.Value = 0;
                prostatus.Minimum = 0;
                //System.Windows.Forms.ToolTip tooltip = new ToolTip();
                string strConn_client = "Server=0.0.0.0;Port=5432;User Id=medisoft;Password=links1920;Database=medisoft2007;Encoding=UNICODE;Pooling=true;";
                strConn_client = "Server=" + c_client.Host + ";Port=" + c_client.Port + ";User Id=" + c_client.Userdb + ";Password=" + c_client.Passworddb + ";Database=" + c_client.DatabaseName + ";Encoding=UNICODE;Pooling=true;";
                //
                string s_dbNameDich = Maincode("Database");
                KiemTraCauTruc_CN(schema, tablename, c_client.DatabaseName, s_dbNameDich, strConn_client, "");
                //
                //tu dong add field chuyendi
                string asql0 = "select chuyendi from " + schema + "." + tablename + " where 1=2";
                DataSet lds00 = get_data(asql0);
                if (lds00 == null && lds00.Tables.Count <= 0)
                {
                    asql0 = "alter table " + schema + "." + tablename + " add chuyendi varchar(300) default lpad('0',300,'0')";
                    execute_data(asql0);
                }
                asql0 = "select chuyendi from " + schema + "." + tablename + " where 1=2";
                lds00 = get_data(asql0, strConn_client);
                if (lds00 == null && lds00.Tables.Count <= 0)
                {
                    asql0 = "alter table " + schema + "." + tablename + " add chuyendi varchar(300) default lpad('0',300,'0')";
                    execute_data(asql0, strConn_client);
                }
                //
                string s_select = "";//field nay part kieu date thanh kieu character
                string s_insert = "insert into " + schema + "." + tablename + "(";//menh de insert
                string s_update = "update " + schema + "." + tablename + " set ";//menh de update
                string s_value_insert = " (";//value cua menh de insert
                string s_dk_update = "";// dieu kien udpdate
                string s_para_update = "", s_para_update_dk = "";
                #region build_sql
                status.Text = "Build query";
                string s_sql = "select lower(a.column_name) as column_name,lower(a.data_type) as data_type,decode(substr(b.constraint_name,1,3),'pk_',b.constraint_name,'') as key,b.ordinal_position as stt " +
                " from information_schema.columns a,information_schema.key_column_usage b where a.table_schema=b.table_schema(+) " +
                " and a.table_name=b.table_name(+) and a.column_name=b.column_name(+) and lower(a.column_name) not in('ngayud','oid') and " +
                 " a.table_schema='" + schema.ToLower() + "' and a.table_name='" + tablename.ToLower() + "'";
                string s_column_name = "", s_data_type = "", s_keys = "";
                DataSet dstmp = new DataSet();
                dstmp = get_data(s_sql);
                Application.DoEvents();
                foreach (DataRow row in dstmp.Tables[0].Rows)
                {
                    s_column_name = row["column_name"].ToString();
                    s_data_type = row["data_type"].ToString();
                    s_keys = row["key"].ToString();
                    s_insert += s_column_name + ",";
                    if (s_data_type.IndexOf("timestamp") > -1)
                    {
                        s_select += "to_char(" + s_column_name + ",'dd/mm/yyyy hh24:mi') as " + s_column_name + ",";
                        s_value_insert += "to_date(:" + s_column_name + ",'dd/mm/yyyy hh24:mi')" + ",";
                    }
                    else if (s_data_type.IndexOf("character") > -1 || s_data_type.IndexOf("text") > -1)
                    {
                        s_select += s_column_name + ",";
                        s_value_insert += ":" + s_column_name + ",";
                    }
                    else if (s_data_type.IndexOf("numeric") > -1)
                    {
                        s_select += " coalesce(" + s_column_name + ",0) as " + s_column_name + ",";
                        s_value_insert += ":" + s_column_name + ",";
                    }
                    else
                    {
                        s_select += s_column_name + ",";
                        s_value_insert += ":" + s_column_name + ",";
                    }
                    if (s_keys != "")
                    {
                        s_dk_update += s_dk_update == "" ? "" : " and ";
                        s_para_update_dk += s_column_name + ",";
                        if (s_data_type.IndexOf("timestamp") > -1)
                        {
                            s_dk_update += " to_char(" + s_column_name + ",'dd/mm/yyyy hh24:mi')=:" + s_column_name + ",";
                        }
                        else if (s_data_type.IndexOf("character") > -1 || s_data_type.IndexOf("text") > -1)
                        {
                            s_dk_update += s_column_name + "=:" + s_column_name + ",";
                        }
                        else
                        {
                            s_dk_update += s_column_name + "=:" + s_column_name + ",";
                        }
                    }
                    else
                    {
                        s_para_update += s_column_name + ",";
                        if (s_data_type.IndexOf("timestamp") > -1)
                        {
                            s_update += s_column_name + "=to_date(:" + s_column_name + ",'dd/mm/yyyy hh24:mi')" + ",";
                        }
                        else if (s_data_type.IndexOf("character") > -1 || s_data_type.IndexOf("text") > -1)
                        {
                            s_update += s_column_name + "=:" + s_column_name + ",";
                        }
                        else
                        {
                            s_update += s_column_name + "=:" + s_column_name + ",";
                        }
                    }
                    Application.DoEvents();
                }
                dstmp.Dispose();
                #endregion
                s_select = s_select.Trim(',');
                s_update = s_update.Trim(',');
                s_dk_update = s_dk_update.Trim(',');
                s_para_update_dk = s_para_update_dk.Trim(',');
                s_insert = s_insert.Trim(',') + ")";
                s_value_insert = s_value_insert.Trim(',') + ")";
                s_para_update = s_para_update.Trim(',') + "," + s_para_update_dk;
                Application.DoEvents();
                #region xu ly client
                status.Text = "Update client";
                execute_data("update " + schema + "." + tablename + " set chuyendi=lpad('0',300,'0') where chuyendi is null or chuyendi=''", strConn_client);
                int i_stt = c_client.STT;
                int i_index = i_stt - 1;
                Application.DoEvents();
                status.Text = "Mark client";
                s_sql = "update " + schema + "." + tablename + " set " +
                    " chuyendi=coalesce(substr(chuyendi,1," + i_index + "),'')||'www'||substr(chuyendi," + ((int)(i_stt + 3)).ToString() + ") " +
                    " where " + field_key + "<>0 and to_date(to_char(to_date(substr(to_char(" + field_key + "),1,6),'yymmdd'),'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tungay + "','dd/mm/yyyy') and to_date('" + s_denngay + "','dd/mm/yyyy') ";
                if (_mabn.Trim() != "")
                {
                    if (tablename.Trim() == "btdbn")
                        s_sql = s_sql + " and mabn in('" + _mabn + "')";
                    else if (tablename.Trim() == "lienhe")
                        s_sql = s_sql + " and maql in(select maql from " + schema + ".tiepdon where mabn in ('" + _mabn + "'))";
                    else if (tablename.Trim() == "tiepdon")
                        s_sql = s_sql + " and mabn in('" + _mabn + "')";
                    else if (tablename.Trim() == "bhyt")
                        s_sql = s_sql + " and mabn in('" + _mabn + "')";
                    else if (tablename.Trim() == "lydokham")
                        s_sql = s_sql + " and maql in(select maql from " + schema + ".tiepdon where mabn in('" + _mabn + "'))";
                    else if (tablename.Trim() == "v_chidinh")
                        s_sql = s_sql + " and mabn in('" + _mabn + "') and kskphatsinh=0";
                    //s_sql = s_sql + " and mabn='" + _mabn + "'";
                }
                else
                {
                }
                execute_data(s_sql, strConn_client);
                Application.DoEvents();
                status.Text = "Get data...";
                DataTable data = new DataTable();
                data = get_data("select " + s_select + " from " + schema + "." + tablename + " where substr(chuyendi," + i_stt + ",3)='www'", strConn_client).Tables[0];
                #endregion
                #region chuyen ve may local
                string _update = s_update + " where " + s_dk_update;
                string _insert = s_insert + " values " + s_value_insert;
                NpgsqlConnection con_server = new NpgsqlConnection(sConn);
                con_server.Open();
                NpgsqlConnection con_client = new NpgsqlConnection(strConn_client);
                con_client.Open();
                Application.DoEvents();
                status.Text = "Syn..." + tablename.ToUpper();
                //prostatus.ForeColor = System.Drawing.Color.Red;
                int i_count = data.Rows.Count;
                prostatus.Maximum = i_count;
                text.Text = "";
                text.Refresh();
                foreach (DataRow rSave in data.Rows)
                {
                    prostatus.Value += 1;
                    Application.DoEvents();
                    try
                    {
                        cmd = new NpgsqlCommand(_update, con_server);
                        cmd.CommandType = CommandType.Text;
                        foreach (string s_col in s_para_update.Split(','))
                        {
                            string s_val = rSave[s_col].ToString();
                            if (s_col.ToLower() == "chuyendi") { s_val = s_val.Substring(0, i_index) + "111" + s_val.Substring(i_index + 3); }
                            if (s_val == "") s_val = null;
                            cmd.Parameters.Add(s_col, s_val);
                        }
                        int i = cmd.ExecuteNonQuery();
                        string s_text = "";
                        if (i == 0)
                        {
                            cmd = new NpgsqlCommand(_insert, con_server);
                            cmd.CommandType = CommandType.Text;
                            foreach (DataColumn col in data.Columns)
                            {
                                string s_val = rSave[col.ColumnName].ToString();
                                if (col.ColumnName.ToLower() == "chuyendi") { s_val = s_val.Substring(0, i_index) + "111" + s_val.Substring(i_index + 3); }
                                else { s_text += s_val + ","; }
                                if (s_val == "") s_val = null;
                                cmd.Parameters.Add(col.ColumnName, s_val);
                            }
                            cmd.ExecuteNonQuery();
                            s_text = s_text.Trim(',') + "\n";
                            text.Text = s_text + text.Text;
                        }
                        //tooltip.SetToolTip(text, prostatus.Value.ToString() + "/" + i_count.ToString());
                        string s_upd_done = "";
                        if (tablename.Trim() == "v_chidinh") s_upd_done = ",done=0 ";
                        s_sql = "update " + schema + "." + tablename + " set chuyendi=coalesce(substr(chuyendi,1," + i_index.ToString() + "),'')||'111'||substr(chuyendi," + ((int)(i_stt + 3)).ToString() + ")" + s_upd_done + " where substr(chuyendi," + i_stt + ",3)='www' and " + s_dk_update;
                        cmd.Dispose();
                        cmd = new NpgsqlCommand(s_sql, con_client);
                        cmd.CommandType = CommandType.Text;
                        foreach (string s_col in s_para_update_dk.Trim(',').Split(','))
                        {
                            cmd.Parameters.Add(s_col, rSave[s_col].ToString());
                        }
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        string s = ex.ToString();
                        upd_Events(DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("hh:mm"), c_client.Host + "^" + c_client.DatabaseName, rSave[0].ToString(), "", schema, tablename, "", s, System.Environment.MachineName.ToUpper(), "");
                    }
                    Application.DoEvents();
                }
                #endregion
                data.Dispose();
                //prostatus.ForeColor = System.Drawing.SystemColors.Highlight;
                status.Text = "Finish.";
                Application.DoEvents();
                con_client.Close();
                con_client.Dispose();
                con_server.Close();
                con_server.Dispose();
            }
            catch (Exception er)
            {
                error = er.Message;
            }
            finally
            {
                con.Dispose();
                cmd.Dispose();
            }
        }
        public bool ChuyenLai
        {
            set { b_chuyenlai = value; }
        }

        public void CapNhatDKSynDMTableKSK()
        {
            string exp = "";
            string asql = "";
            //cty
            exp = " and id in(select id_cty from medibv.ct_doan where id=:ksk_iddoan)";
            asql = "update medibv.syn_dmtable_ksk set dieukien='" + exp + "' where schema_name='medibv' and table_name='ct_cty'";
            execute_data(asql);//
            //
            exp = " and id=:ksk_iddoan";
            asql = "update medibv.syn_dmtable_ksk set dieukien='" + exp + "' where schema_name='medibv' and table_name='ct_doan'";
            execute_data(asql);//
            //
            exp = " and iddoan = :ksk_iddoan";
            asql = "update medibv.syn_dmtable_ksk set dieukien='" + exp + "' where schema_name='medibv' and table_name='ct_donvi'";
            execute_data(asql);
            //ct_doan_dv
            exp = " and id_doan = :ksk_iddoan";
            asql = "update medibv.syn_dmtable_ksk set dieukien='" + exp + "' where schema_name='medibv' and table_name='ct_doan_dv'";
            execute_data(asql);

            //ct_muc
            exp = " and iddoan = :ksk_iddoan";
            asql = "update medibv.syn_dmtable_ksk set dieukien='" + exp + "' where schema_name='medibv' and table_name='ct_muc'";
            execute_data(asql);
        }
        public int i_ChiNhanhHienTai
        {
            get
            {
                try
                {
                    int idchinhanh = 0;
                    string s_ip_local = Maincode("Ip");
                    string s_database_local = Maincode("Database");
                    DataSet dsChinhanh = get_data(" select id from " + userid + ".dmchinhanh where ip='" + s_ip_local + "' and lower(database_local)='" + s_database_local + "' and port='" + Maincode("Post") + "'");

                    if (dsChinhanh.Tables[0].Rows.Count == 0)
                    {
                        idchinhanh = 0;
                    }
                    else
                    {
                        idchinhanh = int.Parse(dsChinhanh.Tables[0].Rows[0][0].ToString());
                    }
                    if (idchinhanh == 0)
                    {
                        DataSet dstmp = get_data("select ten from " + userid + ".thongso where id=999");
                        return int.Parse(dstmp.Tables[0].Rows[0][0].ToString());
                    }
                    return idchinhanh;
                }
                catch { return 0; }
            }
        }
        public bool ChiNhanhTrungTam
        {
            get
            {
                return get_data("select id from medibv.dmchinhanh where id=" + i_ChiNhanhHienTai + " and trungtam=1").Tables[0].Rows.Count > 0;
            }
        }
        public DataSet LayDanhSachDoan()
        {
            string asql = "select to_number('0') as chon, a.* from medibv.ct_doan a where done=0 ";
            DataSet lds = get_data(asql);
            return lds;
        }

        #region Email
        public bool upd_dmemail(int m_id, string m_ten, string m_tieude, string m_noidung, int m_userid, int m_loai)
        {
            string sql = "update " + userid + ".dmemail set ten=:m_ten,tieude=:m_tieude,noidung=:m_noidung,userid=:m_userid where id=" + m_id + " and loai=" + m_loai;
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("m_ten", NpgsqlDbType.Varchar).Value = m_ten;
                cmd.Parameters.Add("m_tieude", NpgsqlDbType.Varchar).Value = m_tieude;
                cmd.Parameters.Add("m_noidung", NpgsqlDbType.Text).Value = m_noidung;
                cmd.Parameters.Add("m_userid", NpgsqlDbType.Numeric).Value = m_userid;
                cmd.Parameters.Add("m_id", NpgsqlDbType.Numeric).Value = m_id;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + userid + ".dmemail (id,ten,tieude,noidung,userid, loai)";
                    sql += " values (:m_id,:m_ten,:m_tieude,:m_noidung,:m_userid," + m_loai + ")";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("m_id", NpgsqlDbType.Numeric).Value = m_id;
                    cmd.Parameters.Add("m_ten", NpgsqlDbType.Varchar).Value = m_ten;
                    cmd.Parameters.Add("m_tieude", NpgsqlDbType.Varchar).Value = m_tieude;
                    cmd.Parameters.Add("m_noidung", NpgsqlDbType.Text).Value = m_noidung;
                    cmd.Parameters.Add("m_userid", NpgsqlDbType.Numeric).Value = m_userid;
                    irec = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                //upd_error(ex.Message, sComputer, "dmemail");
                return false;
            }
            finally
            {
                con.Close(); con.Dispose();
            }
            return true;
        }
        #endregion

        #region DongBoHinhAnh
        public string get_DuongDan_HinhAnhBN(Client c_client)
        {
            string strConn_client = "Server=0.0.0.0;Port=5432;User Id=medisoft;Password=links1920;Database=medisoft2007;Encoding=UNICODE;Pooling=true;";
            strConn_client = "Server=" + c_client.Host + ";Port=" + c_client.Port + ";User Id=" + c_client.Userdb + ";Password=" + c_client.Passworddb + ";Database=" + c_client.DatabaseName + ";Encoding=UNICODE;Pooling=true;";
            string asql = "select ten from medibv.thongso where id=265";
            DataSet lds = get_data(asql, strConn_client);
            if (lds == null || lds.Tables.Count <= 0 || lds.Tables[0].Rows.Count <= 0)
                return "";
            else return lds.Tables[0].Rows[0]["ten"].ToString();
        }
        public string get_DuongDan_HinhAnhBN()
        {
            string asql = "select ten from medibv.thongso where id=265";
            DataSet lds = get_data(asql);
            if (lds == null || lds.Tables.Count <= 0 || lds.Tables[0].Rows.Count <= 0)
                return "";
            else return lds.Tables[0].Rows[0]["ten"].ToString();
        }
        public string get_DuongDan_HinhAnhCDHA()
        {
            string asql = "select ten from medibv.cdha_thongso where id=21";
            DataSet lds = get_data(asql);
            if (lds == null || lds.Tables.Count <= 0 || lds.Tables[0].Rows.Count <= 0)
                return "";
            else return lds.Tables[0].Rows[0]["ten"].ToString();
            return "";
        }
        public string get_DuongDan_HinhAnhChungTu()
        {
            string asql = "select ten from medibv.thongso where id=1085";
            DataSet lds = get_data(asql);
            if (lds == null || lds.Tables.Count <= 0 || lds.Tables[0].Rows.Count <= 0)
                return "";
            else return lds.Tables[0].Rows[0]["ten"].ToString();
        }
        public void CopyFile_HinhBN(string s_DirSource, string s_DirDest)
        {
            string afilename="",afilename_dest="";
            if (System.IO.Directory.Exists(s_DirSource))
            {
                string[] sf = System.IO.Directory.GetFiles(s_DirSource);
                for (int i = 0; i < sf.Length; i++)
                {
                    afilename = sf[i].Substring(sf[i].LastIndexOf("\\") + 1);

                    if (afilename != "" && (afilename.IndexOf(".jpg") != -1 || afilename.IndexOf(".bmp") != -1))
                    {
                        if (System.IO.File.Exists(s_DirSource + "\\" + afilename)) 
                        {
                            afilename_dest = s_DirDest + "\\" + afilename;
                            System.IO.File.Copy(s_DirSource + "\\" + afilename, afilename_dest);
                        }                        
                    }
                }
            }
        }
        public void CopyFile_HinhCDHA(string s_DirSource, string s_DirDest, int i_songay)
        {
            //string afilename = "", afilename_dest = "";
            //string tmp_DirSource = s_DirSource, tmp_DirDest = s_DirDest, dir_yymmdd = "", s_ngayhienhanh="";
            //int i_yyyy=0, i_yy=0, i_mm=0, i_dd=0;
            //s_ngayhienhanh=ngayhienhanh_server.Substring(0,10);
            //i_yy = s_ngayhienhanh.Substring(8, 2);
            //i_yyyy  = s_ngayhienhanh.Substring(6, 4);
            //i_mm = s_ngayhienhanh.Substring(3, 2);
            //i_dd = s_ngayhienhanh.Substring(0, 2);
            //for (int i = 0; i < i_songay; i++)
            //{

            //    if (i_dd - i < 0)
            //    {
            //        i_mm = i_mm - 1;
            //        if (i_mm < 0) i_dd = 31;//thang 12
            //        else if (i_mm = 1 || i_mm = 3 || i_mm = 5 || i_mm = 7 || i_mm = 8 || i_mm = 10 || i_mm = 12)
            //        {
            //            i_dd = 31;
            //        }
            //        else if (i_mm = 4 || i_mm = 6 || i_mm = 9 || i_mm = 11)
            //        {
            //            i_dd = 30;
            //        }
            //        else if (i_mm = 2 && i_yyyy % 4 == 0)
            //        {
            //            i_dd = 29;
            //        }
            //        else i_dd = 28;
            //    }
            //    if (i_mm < 0)
            //    {
            //        i_mm = 12;
            //    }
            //    i_yy = i_yy - 1;
            //    if (System.IO.Directory.Exists(s_DirSource))
            //    {
            //        string[] sf = System.IO.Directory.GetFiles(s_DirSource);
            //        for (int i = 0; i < sf.Length; i++)
            //        {
            //            afilename = sf[i].Substring(sf[i].LastIndexOf("\\") + 1);

            //            if (afilename != "" && (afilename.IndexOf(".jpg") != -1 || afilename.IndexOf(".bmp") != -1))
            //            {
            //                if (System.IO.File.Exists(s_DirSource + "\\" + afilename))
            //                {
            //                    afilename_dest = s_DirDest + "\\" + afilename;
            //                    System.IO.File.Copy(s_DirSource + "\\" + afilename, afilename_dest);
            //                }
            //            }
            //        }
            //    }
            //}
        }
        #endregion

        public void DeleteClient(int d_id)
        {
            string asql = "delete from medibv.client where id=" + d_id;
            execute_data(asql);
        }
        public Client TimClient(int d_id)
        {
            Client c_client = new Client();
            if (d_id <= 0) c_client = null;
            string asql = "select * from medibv.client where id=" + d_id;
            DataSet lds = get_data(asql);
            if (lds == null || lds.Tables.Count <= 0 || lds.Tables[0].Rows.Count <= 0)
            {
                c_client = null;
            }
            else
            {
                foreach (DataRow dr in lds.Tables[0].Rows)
                {
                    c_client.Host = dr["host"].ToString();
                    c_client.DatabaseName = dr["DatabaseName"].ToString();
                    c_client.Port = dr["Port"].ToString();
                    c_client.DbLink = dr["dblinks"].ToString();
                    c_client.ServerName = dr["ServerName"].ToString();
                    c_client.Passworddb = dr["Passworddb"].ToString();
                    c_client.Userdb = dr["Userdb"].ToString();
                    c_client.STT = int.Parse(dr["stt"].ToString());
                    c_client.ImagePath = dr["ImagePath"].ToString();
                    c_client.ImagePath_BN = dr["ImagePath_hinhbn"].ToString();
                    c_client.ImagePath_Chungtu = dr["ImagePath_hinhchungtu"].ToString();
                    c_client.ID = d_id;
                }
            }
            return c_client;
        }

        //
        public bool TimClient_TheoSTT(int d_STT)
        {
            bool bFound = false;
            if (d_STT <= 0) bFound = false;
            string asql = "select * from medibv.client where stt=" + d_STT;
            DataSet lds = get_data(asql);
            bFound = (lds != null && lds.Tables.Count > 0 && lds.Tables[0].Rows.Count > 0);
            return bFound;
        }
        //
        public int i_themngay_letet(string b_ngay_hientai, int i_ngaythem)
        {
            DataSet dsle = get_data("select * from medibv.letet ");
            int i_themngay = 0;
            if (b_ngay_hientai == "") i_themngay = 0;
            else
            {
                for (int j = 1; j <= i_ngaythem; j++)
                {
                    DateTime dt1 = StringToDate(b_ngay_hientai).AddDays(j);
                    string b_ngay = DateToString("dd/MM/yyyy", dt1);
                    DataRow r = getrowbyid(dsle.Tables[0], "ngay='" + b_ngay.Substring(0, 5) + "'");
                    if (r != null) i_themngay += 1;
                }
            }
            return i_themngay + i_ngaythem;
        }

        public int i_themngay_nghi(string b_ngay_hientai, int i_ngaythem)
        {
            DataSet dsle = get_data("select * from medibv.ngaynghi where nghi=1 ");
            int i_themngay = 0;
            if (b_ngay_hientai == "") i_themngay = 0;
            else
            {
                DateTime dt1 = StringToDate(b_ngay_hientai).AddDays(i_ngaythem);
                string b_ngay = dt1.DayOfWeek.ToString().ToUpper();
                foreach (DataRow r in dsle.Tables[0].Rows)
                {
                    if (r["ngay"].ToString() == b_ngay) i_themngay = 1;
                    else i_themngay = 0;
                }
            }
            return i_themngay + i_ngaythem;
        }

        public string DateToString(string format, System.DateTime date)
        {
            if (date.Equals(null)) return "";
            else return date.ToString(format, System.Globalization.DateTimeFormatInfo.CurrentInfo);
        }
        //
        public void update_lai_ketqua_xn(Client c_client, string schema, string tablename, System.Windows.Forms.RichTextBox text,
            System.Windows.Forms.ToolStripStatusLabel status, System.Windows.Forms.ProgressBar prostatus, ref string s_HostErrorConnection)
        {
            try
            {
                prostatus.Value = 0;
                prostatus.Minimum = 0;
                //Kiem tra cau truc truoc khi dong bo

                //System.Windows.Forms.ToolTip tooltip = new ToolTip();
                string strConn_client = "Server=0.0.0.0;Port=5432;User Id=medisoft;Password=links1920;Database=medisoft2007;Encoding=UNICODE;Pooling=true;";
                strConn_client = "Server=" + c_client.Host + ";Port=" + c_client.Port + ";User Id=" + c_client.Userdb + ";Password=" + c_client.Passworddb + ";Database=" + c_client.DatabaseName + ";Encoding=UNICODE;Pooling=true;";
                //
                string s_dbNameDich = Maincode("Database");
                KiemTraCauTruc_CN(schema, tablename, c_client.DatabaseName, s_dbNameDich, strConn_client, "");
                //
                //tu dong add field chuyendi
                string asql0 = "select chuyendi from " + schema + "." + tablename + " where 1=2";
                DataSet lds00 = get_data(asql0);
                if (lds00 == null || lds00.Tables.Count <= 0)
                {
                    asql0 = "alter table " + schema + "." + tablename + " add chuyendi varchar(300) default lpad('0',300,'0')";
                    execute_data(asql0);
                }
                asql0 = "select chuyendi from " + schema + "." + tablename + " where 1=2";
                lds00 = get_data(asql0, strConn_client);
                if (lds00 == null || lds00.Tables.Count <= 0)
                {
                    asql0 = "alter table " + schema + "." + tablename + " add chuyendi varchar(300) default lpad('0',300,'0')";
                    execute_data(asql0, strConn_client);
                }
                //
                string s_select = "";//field nay part kieu date thanh kieu character
                string s_insert = "insert into " + schema + "." + tablename + "(";//menh de insert
                string s_update = "update " + schema + "." + tablename + " set ";//menh de update
                string s_value_insert = " (";//value cua menh de insert
                string s_dk_update = "";// dieu kien udpdate
                string s_para_update = "", s_para_update_dk = "";
                #region build_sql
                status.Text = "Build query";
                //string s_sql = "select lower(a.column_name) as column_name,lower(a.data_type) as data_type,decode(substr(b.constraint_name,1,3),'pk_',b.constraint_name,'') as key,b.ordinal_position as stt " +
                string s_sql = "select lower(a.column_name) as column_name,lower(a.data_type) as data_type, case when b.position_in_unique_constraint is not null then '' else b.constraint_name end as key,b.ordinal_position as stt " +
                " from information_schema.columns a,information_schema.key_column_usage b where a.table_schema=b.table_schema(+) " +
                " and a.table_name=b.table_name(+) and a.column_name=b.column_name(+) and lower(a.column_name) not in('ngayud','oid') and " +
                 " a.table_schema='" + schema.ToLower() + "' and a.table_name='" + tablename.ToLower() + "'";
                string s_column_name = "", s_data_type = "", s_keys = "";
                DataSet dstmp = new DataSet();
                dstmp = get_data(s_sql);
                Application.DoEvents();
                string tmp_column = ",";
                string s_cols_type = "", s_cols_type_upd = "", s_cols_type1 = "";
                foreach (DataRow row in dstmp.Tables[0].Select("", "key desc, column_name"))
                {
                    //
                    s_cols_type1 = "0";
                    //
                    s_column_name = row["column_name"].ToString();
                    if (tmp_column.IndexOf("," + s_column_name + ",") >= 0) continue;//binh 100212
                    else
                    {
                        tmp_column += s_column_name + ",";//binh 100212
                    }
                    //
                    //if (s_column_name == row["column_name"].ToString()) continue;////binh 100212 comment                    
                    s_data_type = row["data_type"].ToString();
                    s_keys = row["key"].ToString();
                    s_insert += s_column_name + ",";
                    if (s_data_type.IndexOf("timestamp") > -1)
                    {
                        s_select += "to_char(" + s_column_name + ",'dd/mm/yyyy hh24:mi') as " + s_column_name + ",";
                        s_value_insert += "to_date(:" + s_column_name + ",'dd/mm/yyyy hh24:mi')" + ",";
                    }
                    else if (s_data_type.IndexOf("date") > -1)
                    {
                        s_select += "to_char(" + s_column_name + ",'dd/mm/yyyy') as " + s_column_name + ",";
                        s_value_insert += "to_date(:" + s_column_name + ",'dd/mm/yyyy')" + ",";
                    }
                    else if (s_data_type.IndexOf("character") > -1 || s_data_type.IndexOf("text") > -1)
                    {
                        s_select += s_column_name + ",";
                        s_value_insert += ":" + s_column_name + ",";
                    }//
                    else if (s_data_type.IndexOf("numeric") > -1)
                    {
                        s_select += " coalesce(" + s_column_name + ",0) as " + s_column_name + ",";
                        s_value_insert += ":" + s_column_name + ",";
                        s_cols_type1 = "1";
                    }//numeric
                    else
                    {
                        s_select += s_column_name + ",";
                        s_value_insert += ":" + s_column_name + ",";
                    }
                    if (s_keys != "")
                    {
                        s_dk_update += s_dk_update == "" ? "" : " and ";
                        s_para_update_dk += s_column_name + ",";
                        if (s_data_type.IndexOf("timestamp") > -1)
                        {
                            s_dk_update += " to_char(" + s_column_name + ",'dd/mm/yyyy hh24:mi')=:" + s_column_name;// +",";
                        }
                        else if (s_data_type.IndexOf("date") > -1)
                        {
                            s_dk_update += " to_char(" + s_column_name + ",'dd/mm/yyyy')=:" + s_column_name;// +",";
                        }
                        else if (s_data_type.IndexOf("character") > -1 || s_data_type.IndexOf("text") > -1)
                        {
                            s_dk_update += s_column_name + "=:" + s_column_name + "";// ",";//binh 110112: bo dau ,
                        }
                        else
                        {
                            s_dk_update += s_column_name + "=:" + s_column_name + "";// ",";
                        }
                    }
                    else
                    {
                        s_para_update += s_column_name + ",";
                        if (s_data_type.IndexOf("timestamp") > -1)
                        {
                            s_update += s_column_name + "=to_date(:" + s_column_name + ",'dd/mm/yyyy hh24:mi')" + ",";
                        }
                        else if (s_data_type.IndexOf("date") > -1)
                        {
                            s_update += s_column_name + "=to_date(:" + s_column_name + ",'dd/mm/yyyy')" + ",";
                        }
                        else if (s_data_type.IndexOf("character") > -1 || s_data_type.IndexOf("text") > -1)
                        {
                            s_update += s_column_name + "=:" + s_column_name + ",";
                        }
                        else
                        {
                            s_update += s_column_name + "=:" + s_column_name + ",";
                        }
                    }
                    s_cols_type += s_cols_type1 + ",";
                    Application.DoEvents();
                }

                dstmp.Dispose();
                #endregion
                s_select = s_select.Trim(',');
                s_update = s_update.Trim(',');
                s_dk_update = s_dk_update.Trim(',');
                s_para_update_dk = s_para_update_dk.Trim(',');
                s_insert = s_insert.Trim(',') + ")";
                s_value_insert = s_value_insert.Trim(',') + ")";
                s_para_update = s_para_update.Trim(',') + "," + s_para_update_dk;
                Application.DoEvents();
                #region xu ly client
                status.Text = "Update client";
                int iOK = execute_sql("update " + schema + "." + tablename + " set chuyendi=lpad('0',300,'0') where chuyendi is null or chuyendi=''", strConn_client);
                if (iOK == 2) return;//loi khi ket noi client: exit
                else if (iOK == 1)
                {
                    s_HostErrorConnection = c_client.Host;
                    return;
                }
                int i_stt = c_client.STT;
                int i_index = i_stt - 1;
                Application.DoEvents();
                status.Text = "Mark client";
                s_sql = "update " + schema + "." + tablename + " set " +
                    " chuyendi=coalesce(substr(chuyendi,1," + i_index + "),'')||'www'||substr(chuyendi," + ((int)(i_stt + 3)).ToString() + ") " +
                    " where substr(chuyendi," + i_stt + ",3)='000'";
                execute_data(s_sql, strConn_client);

                Application.DoEvents();
                status.Text = "Get data...";
                //
                if (tablename.ToLower() == "ct_doan")
                {
                    string asql2 = "update medibv.ct_doan set laymau_tungay=ngay, laymau_denngay=ngay, giolaymausang=to_timestamp('00:00','hh24:mi'), giolaymauchieu=to_timestamp('00:00','hh24:mi') where laymau_tungay is null";
                    execute_data(asql2);
                    asql2 = " update medibv.ct_doan set khuvuclaymau=false where khuvuclaymau is null";
                    execute_data(asql2);
                }
                //
                DataTable data = new DataTable();
                data = get_data("select " + s_select + " from " + schema + "." + tablename + " where substr(chuyendi," + i_stt + ",3)='www'", strConn_client).Tables[0];
                #endregion
                #region chuyen ve may local
                string _update = s_update + " where " + s_dk_update;
                string _insert = s_insert + " values " + s_value_insert;
                if (con_server != null)
                {
                    con_server.Close(); con_server.Dispose();
                }
                con_server = new NpgsqlConnection(sConn);
                con_server.Open();
                if (con_client != null)
                {
                    con_client.Close(); con_client.Dispose();
                }
                con_client = new NpgsqlConnection(strConn_client);
                con_client.Open();
                Application.DoEvents();
                status.Text = "Syn..." + tablename.ToUpper();
                prostatus.ForeColor = System.Drawing.Color.Red;
                int i_count = data.Rows.Count;
                prostatus.Maximum = i_count;
                text.Text = "";
                text.Refresh();
                string s_text = "";
                string[] arr_type = s_cols_type.Trim().Trim(',').Split(',');
                int icol = 0;
                int i_current = 0;
                int i_error = 0;
                foreach (DataRow rSave in data.Rows)
                {
                    prostatus.Value += 1;
                    i_current += 1;
                    status.Text = "Syn..." + tablename.ToUpper() + " - " + i_current.ToString() + "/" + i_count + "/ Err: " + i_error;
                    Application.DoEvents();
                    try
                    {
                        
                        cmd = new NpgsqlCommand(_update, con_server);
                        cmd.CommandType = CommandType.Text;
                        s_text = "";
                        icol = 0;
                        foreach (string s_col in s_para_update.Trim(',').Split(','))
                        {
                            string s_val = rSave[s_col].ToString();
                            //if (arr_type[icol] == "1" && s_val == "") s_val = "0";//binh 260612
                            if (s_col.ToLower() == "chuyendi") { s_val = s_val.Substring(0, i_index) + "111" + s_val.Substring(i_index + 3); }
                            cmd.Parameters.Add(s_col, s_val);
                            s_text += s_val + ",";
                            icol += 1;
                        }
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            s_text = s_text.Trim(',') + "\n";
                            if (text.Lines.Length > 30) text.Text = "Update: " + s_text;
                            else text.Text = "Update: " + s_text + text.Text;
                        }
                        s_text = "";
                        if (i == 0)
                        {
                            cmd = new NpgsqlCommand(_insert, con_server);
                            cmd.CommandType = CommandType.Text;
                            icol = 0;
                            foreach (DataColumn col in data.Columns)
                            {
                                string s_val = rSave[col.ColumnName].ToString();
                                if (arr_type[icol] == "1" && s_val == "") s_val = "0";//binh 260612
                                if (col.ColumnName.ToLower() == "chuyendi") { s_val = s_val.Substring(0, i_index) + "111" + s_val.Substring(i_index + 3); }
                                else { s_text += s_val + ","; }
                                cmd.Parameters.Add(col.ColumnName, s_val);
                                //
                                icol += 1;
                            }
                            cmd.ExecuteNonQuery();
                            s_text = s_text.Trim(',') + "\n";

                            if (text.Lines.Length > 30) text.Text = s_text;
                            else text.Text = s_text + text.Text;
                        }
                        //tooltip.SetToolTip(text, prostatus.Value.ToString() + "/" + i_count.ToString());
                        s_sql = "update " + schema + "." + tablename + " set chuyendi=coalesce(substr(chuyendi,1," + i_index.ToString() + "),'')||'111'||substr(chuyendi," + ((int)(i_stt + 3)).ToString() + ") where substr(chuyendi," + i_stt + ",3)='www' and " + s_dk_update;
                        cmd.Dispose();
                        cmd = new NpgsqlCommand(s_sql, con_client);
                        cmd.CommandType = CommandType.Text;
                        foreach (string s_col in s_para_update_dk.Trim(',').Split(','))
                        {
                            cmd.Parameters.Add(s_col, rSave[s_col].ToString());
                        }
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        string s = ex.ToString();
                        if (ex.ToString().IndexOf("No connection could be made") >= 0)
                        {
                            s_HostErrorConnection = c_client.Host;
                            break;
                        }
                        upd_Events(DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("hh:mm"), c_client.Host + "^" + c_client.DatabaseName, rSave[0].ToString(), "", schema, tablename, "", s, System.Environment.MachineName.ToUpper(), "");
                        i_error += 1;
                    }
                    finally
                    {
                        cmd.Dispose();
                    }
                    Application.DoEvents();
                }
                #endregion
                data.Dispose();
                prostatus.ForeColor = System.Drawing.SystemColors.Highlight;
                status.Text = "Finish.";
                Application.DoEvents();
                con_client.Close();
                con_client.Dispose();
                con_server.Close();
                con_server.Dispose();
            }
            catch (Exception er)
            {
                error = er.Message;
            }
            finally
            {
                cmd.Dispose();
                con.Dispose();
            }
        }

        //
    }
}
