using System;
using System.Data;
using System.Xml;
using System.Drawing;
using Npgsql;
using NpgsqlTypes;
using System.Windows.Forms;
using System.Diagnostics;

namespace gpblib
{
	public class AccessData
	{
		public string Msg="Giải phẫu bệnh lý";
        public const string links_userid = "links", links_pass = "link7155019s20";
        private int iRownum = 1;
        string sConn = "Server=192.168.1.14;Port=5432;User Id=medisoft;Password=links1920;Database=medisoft;Encoding=UNICODE;Pooling=true;";
        NpgsqlDataAdapter dest;
        NpgsqlConnection con;
        NpgsqlCommand cmd;
        string sComputer = null;
        string sql = "",  owner = "medisoft", password = "links1920", userid = "medibv", database = "medisoft", xxxxx = "Ð§Ì©Î«³²°Ô£";
        DataSet ds = null;
		public const string sPathDefault="..\\..\\..\\database\\xetnghiem.mdb";
		public AccessData()
		{
            sComputer = System.Environment.MachineName.Trim().ToUpper();
            if (Maincode("Con") != "") sConn = Maincode("Con");
            Msg = Thongso("kho").Trim();
            if (Maincode("User") != "") userid = Maincode("User");
            if (Maincode("UserID") != "") owner = Maincode("UserID");
            if (Maincode("Password") != "") password = Maincode("Password");
            if (Maincode("Database") != "") database = Maincode("Database");
            if (Maincode("xxxxx") == "*****") password = decode(xxxxx).ToLower();
            sConn = "Server=" + Maincode("Ip") + ";Port=" + Maincode("Post") + ";User Id=" + owner + ";Password=" + password + ";Database=" + database + ";Encoding=UNICODE;Pooling=true;";
            if (!upd_dmcomputer())
            {
                System.Windows.Forms.MessageBox.Show("Không kết nối được Server !", Msg);
                System.Windows.Forms.Application.Exit();
            }
            ds = get_data("select id,computer from " + userid + ".dmcomputer");
            DataRow r = getrowbyid(ds.Tables[0], "computer='" + sComputer + "'");
            if (r != null) iRownum = int.Parse(r["id"].ToString());
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
                    execute_data(sql);
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                con.Close(); con.Dispose();
            }
            return true;
        }

        public DataSet get_data(string sql)
        {
            try
            {
                if (ds != null)
                {
                    ds.Dispose();
                    ds = null;
                }
                if (con != null)
                {
                    con.Close(); con.Dispose();
                }
                ds = new DataSet();
                con = new NpgsqlConnection(sConn);
                con.Open();
                cmd = new NpgsqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                dest = new NpgsqlDataAdapter(cmd);
                dest.Fill(ds);
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message.ToString().Trim(), sComputer, "?");
            }
            return ds;
        }

        public bool execute_data(string sql)
        {
            try
            {
                con = new NpgsqlConnection(sConn);
                con.Open();
                cmd = new NpgsqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close(); con.Dispose();
                return true;
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message.ToString().Trim(), sComputer, "?");
                return false;
            }
        }

        public bool execute_data_noerror(string sql)
        {
            try
            {
                con = new NpgsqlConnection(sConn);
                con.Open();
                cmd = new NpgsqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close(); con.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }


        private int get_id_dmcomputer
        {
            get
            {
                ds = get_data("select max(id) as id from " + user + ".dmcomputer");
                if (ds.Tables[0].Rows[0]["id"].ToString() == "") return 1;
                else return int.Parse(ds.Tables[0].Rows[0]["id"].ToString()) + 1;
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

        public string Mabv_xml
        {
            get
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("..\\..\\..\\xml\\maincode.xml");
                XmlNodeList nodeLst = doc.GetElementsByTagName("Mabv");
                return (nodeLst.Item(0).InnerText == "") ? "701.1.01" : nodeLst.Item(0).InnerText;
            }
        }

        public int Mabv_so
        {
            get
            {
                string mabv = (Mabv != "") ? Mabv : Mabv_xml, s = "";
                for (int i = 0; i < mabv.Length; i++)
                    s += (mabv.Substring(i, 1) == ".") ? "" : mabv.Substring(i, 1);
                return int.Parse(s);
            }
        }

        public string user { get { return userid; } }
        public string Maincode(string sql)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("..\\..\\..\\xml\\maincode.xml");
                XmlNodeList nodeLst = doc.GetElementsByTagName(sql);
                return nodeLst.Item(0).InnerText;
            }
            catch
            {
                ds = new DataSet();
                ds.ReadXml("..\\..\\..\\xml\\maincode.xml");
                DataColumn dc = new DataColumn();
                dc.ColumnName = sql;
                dc.DataType = Type.GetType("System.String");
                ds.Tables[0].Columns.Add(dc);
                ds.Tables[0].Rows[0][sql] = "";
                ds.WriteXml("..\\..\\..\\xml\\maincode.xml");
                return "";
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
                    XmlDocument doc = new XmlDocument();
                    doc.Load("..//..//..//xml//maincode.xml");
                    XmlNodeList nodeLst = doc.GetElementsByTagName("Tenbv");
                    return nodeLst.Item(0).InnerText;
                }
            }
        }

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
                    XmlDocument doc = new XmlDocument();
                    doc.Load("..//..//..//xml//maincode.xml");
                    XmlNodeList nodeLst = doc.GetElementsByTagName("Syte");
                    return nodeLst.Item(0).InnerText;
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
                    XmlDocument doc = new XmlDocument();
                    doc.Load("..//..//..//xml//maincode.xml");
                    XmlNodeList nodeLst = doc.GetElementsByTagName("Diachi");
                    return nodeLst.Item(0).InnerText;
                }
            }
        }

        public string Dienthoai
        {
            get
            {
                try
                {
                    return get_data("select ten from " + user + ".thongso where id=6").Tables[0].Rows[0]["ten"].ToString();
                }
                catch
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load("..//..//..//xml//maincode.xml");
                    XmlNodeList nodeLst = doc.GetElementsByTagName("Dienthoai");
                    return nodeLst.Item(0).InnerText;
                }
            }
        }
		
		public string Thongso(string sql)
		{
			
			XmlDocument doc=new XmlDocument();
			doc.Load("..\\..\\..\\xml\\d_thongso.xml");
			XmlNodeList nodeLst=doc.GetElementsByTagName(sql);
			return nodeLst.Item(0).InnerText;
			
		}


		public string Thongso(string tenfile,string cot)
		{
			XmlDocument doc=new XmlDocument();
			doc.Load("..\\..\\..\\xml\\"+tenfile+".xml");
			XmlNodeList nodeLst=doc.GetElementsByTagName(cot);
			return nodeLst.Item(0).InnerText;
		}


		public string MaxNgay(string ngay1,string ngay2)
		{
			DateTime t1=StringTodestte(ngay1),t2=StringTodestte(ngay2);
			return (t1>t2)?ngay1:ngay2;
		}

		public string MinNgay(string ngay1,string ngay2)
		{
			DateTime t1=StringTodestte(ngay1),t2=StringTodestte(ngay2);
			return (t1>t2)?ngay2:ngay1;
		}
		public bool bNgay(string ngayvao,string ngaysinh)
		{
            int d1 = DateTime.Now.Day;
			int m1 = DateTime.Now.Month;
			int y1 = DateTime.Now.Year;
			if (ngayvao!="")
			{
				y1=int.Parse(ngayvao.Substring(6,4));
				m1=int.Parse(ngayvao.Substring(3,2));
				d1=int.Parse(ngayvao.Substring(0,2));
			}
			int d2 = int.Parse(ngaysinh.Substring(0,2));
			int m2 = int.Parse(ngaysinh.Substring(3,2));
			int y2 = int.Parse(ngaysinh.Substring(6,4));

			if (y2>y1) return false;
			else if (y2<y1) return true;
			if (m2>m1) return false;
			else if (m2<m1) return true;
			if (d2>d1) return false;
			return true;
		}
		public bool bNgay(string ngay)
		{
			try
			{
				if (ngay.IndexOf("_")!=-1) return false;
				int len=ngay.Length;
				if (len==0) return false;
				string dd=ngay.Substring(0,2),mm=ngay.Substring(3,2),yyyy=ngay.Substring(6,4);
				string s31="01+03+05+07+08+10+12+",s30="04+06+09+11+",s2829=(int.Parse(yyyy)%4==0)?"29":"28";
				if (int.Parse(yyyy.Substring(0,1))<1) return false;
				if (int.Parse(mm)<1 || int.Parse(mm)>12) return false;
				if (s31.IndexOf(mm+"+")>-1)
				{
					if (int.Parse(dd)<0 || int.Parse(dd)>31) return false;
				}
				else if (s30.IndexOf(mm+"+")>-1)
				{
					if (int.Parse(dd)<0 || int.Parse(dd)>30) return false;
				}
				else if (int.Parse(dd)<0 || int.Parse(dd)>int.Parse(s2829)) return false;
				if (len>10)
				{
					string hh=ngay.Substring(11,2),MM=ngay.Substring(14,2);
					if (int.Parse(hh)>23) return false;
					if (int.Parse(MM)>59) return false;
				}
				return true;
			}
			catch{return false;};
		}
		public Int64 songay(DateTime d1,DateTime d2,int congthem)
		{
			try
			{
                return Convert.ToInt64(d1.ToOADate() - d2.ToOADate() + congthem);
			}
			catch{return 0;}
		}
		public bool ngay(DateTime d1,DateTime d2,int so)
		{
			return (Math.Abs(songay(d1,StringTodestte(d2.Day.ToString().PadLeft(2,'0')+"/"+d2.Month.ToString().PadLeft(2,'0')+"/"+d2.Year.ToString()),0))<=so);
		}
		public System.DateTime StringTodestte(string s)
		{
			string [] format={"dd/MM/yyyy"};
			return System.DateTime.ParseExact(s.ToString(),format,System.Globalization.DateTimeFormatInfo.CurrentInfo,System.Globalization.DateTimeStyles.None);
		}
		
		public string destteToString(System.DateTime date)
		{
			string format="dd/MM/yyyy";
			return  date.ToString(format,System.Globalization.DateTimeFormatInfo.CurrentInfo);
		}

		public string onlyso(string s)
		{
			string ret="",s1=" 0123456789";
			for(int i=0;i<s.Length;i++)
				if (s1.IndexOf(s.Substring(i,1))!=-1) ret+=s.Substring(i,1);
			return ret;
		}

		public string Mmyy_truoc(string d_mmyy)
		{
			int t_mm,t_yy;
			string mm=d_mmyy.Substring(0,2),yy=d_mmyy.Substring(2,2);
			if (mm=="01")
			{
				t_mm=12;t_yy=int.Parse(yy)-1;
			}
			else
			{
				t_mm=int.Parse(mm)-1;t_yy=int.Parse(yy);
			}
			return t_mm.ToString().PadLeft(2,'0')+t_yy.ToString().PadLeft(2,'0');
		}
		public string Ktngaygio(string s,int len)
		{
			try
			{
				string s1=onlyso(s);
				if (len==10)
					return s1.Substring(0,2).Trim().PadLeft(2,'0')+"/"+s1.Substring(2,2).Trim().PadLeft(2,'0')+"/"+s1.Substring(4).Trim().PadLeft(4,'0');
				else
					return s1.Substring(0,2).Trim().PadLeft(2,'0')+"/"+s1.Substring(2,2).Trim().PadLeft(2,'0')+"/"+s1.Substring(4,4).Trim().PadLeft(4,'0')+" "+s1.Substring(9,2).Trim().PadLeft(2,'0')+":"+s1.Substring(11,2).Trim().PadLeft(2,'0');
			}
			catch{return s;}
		}

		public string getSogpb(string table)
		{
			string ret="";
			string s_yy=DateTime.Now.Year.ToString().Substring(2,2);
			try
			{
				string t=get_data("select case when max(substr(sogpb,0,7)) is null then '0' else max(substr(sogpb,0,7)) end as sogpb from "+table+" where substr(sogpb,9,2)='"+s_yy+"'").Tables[0].Rows[0][0].ToString();
				long i=long.Parse(t)+1;
				ret=i.ToString().PadLeft(7,'0')+"/"+s_yy;
			}
			catch
			{
				ret="0000001"+"/"+s_yy;
			}
			return ret;
		}

		public string Caps(string s)
		{
			if (s.Length==0) return null;
			System.Text.StringBuilder sb = new System.Text.StringBuilder(s.ToLower());
			sb[0] = Char.ToUpper( sb[0]);
			string ret=null;			
			int num = 0;int ispace =0;
			while(num < sb.Length)
			{
				if(Char.IsWhiteSpace(sb[num])) ispace++;
				if(!Char.IsWhiteSpace(sb[num])) 							
				{
					if (ispace>0 && num>0)
					{
						sb[num] = Char.ToUpper( sb[num]);
						ispace=0;
					}
				}				
				num++;				
			}
			num = 0;
			ispace=0;
			while(num < sb.Length)
			{
				if(Char.IsWhiteSpace(sb[num]))
				{
					if (ispace<1 && num>0 ) ret+=sb[num];
					ispace++;
				}
				else
				{
					ret+=sb[num];
					ispace=0;
				}				
				num++;
			}
			return ret;
		}
        public Color getColor(int i)
        {
            Color[] color = {Color.FromArgb(255,192,192),Color.FromArgb(192,192,255),Color.FromArgb(255,224,192),Color.FromArgb(192,255,192),Color.FromArgb(255,192,255),
								Color.Aqua,Color.Aquamarine,Color.BurlyWood,Color.CadetBlue,Color.Chartreuse,Color.Chocolate,Color.Coral,Color.CornflowerBlue,
								Color.Crimson,Color.Cyan,Color.DarkBlue,Color.DarkCyan,Color.DarkGoldenrod,Color.DarkGray,Color.DarkGreen,Color.DarkKhaki,Color.DarkMagenta,Color.DarkOliveGreen,
								Color.DarkOrange,Color.DarkOrchid,Color.DarkRed,Color.DarkSalmon,Color.DarkSeaGreen,Color.DarkSlateBlue,Color.DarkSlateGray,Color.DarkTurquoise,Color.DarkViolet,Color.DeepPink,
								Color.DeepSkyBlue,Color.DimGray,Color.DodgerBlue,Color.Firebrick,Color.FloralWhite,Color.ForestGreen,Color.Fuchsia,Color.Gainsboro,Color.Gold,Color.Goldenrod,
								Color.Gray,Color.Green,Color.GreenYellow,Color.Honeydew,Color.HotPink,Color.IndianRed,Color.Indigo,Color.Ivory,Color.Khaki,Color.Lavender,
								Color.LavenderBlush,Color.LawnGreen,Color.LemonChiffon,Color.LightBlue,Color.LightCoral,Color.LightCyan,Color.LightGoldenrodYellow,Color.LightGray,Color.LightGreen,Color.LightPink,
								Color.LightSalmon,Color.LightSeaGreen,Color.LightSkyBlue,Color.LightSlateGray,Color.LightSteelBlue,Color.LightYellow,Color.Lime,Color.LimeGreen,Color.Linen,Color.Magenta};
            return color[i];
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
		public string Export_Excel(DataSet dset,string tenfile)
		{
			try
			{
				string dirPath=AppDomain.CurrentDomain.BaseDirectory+"Excel";
				string filePath=dirPath+"\\"+tenfile+".xls";
				if (!System.IO.Directory.Exists(dirPath)) System.IO.Directory.CreateDirectory(dirPath);
				System.IO.StreamWriter sw  =  new System.IO.StreamWriter(filePath,false,System.Text.Encoding.Unicode);
				string astr="";
				astr="<Table>";//"<Table border=1>";
				astr=astr + "<tr>";
				for(int i=0;i<dset.Tables[0].Columns.Count;i++)
				{
					astr=astr + "<th>";
					astr=astr + dset.Tables[0].Columns[i].ColumnName;
					astr=astr + "</th>";
				}
				astr=astr + "</tr>";
				sw.Write(astr);
				for(int i=0;i<dset.Tables[0].Rows.Count;i++)
				{
					astr="<tr>";
					for(int j=0;j<dset.Tables[0].Columns.Count;j++)
					{
						astr=astr + "<td>";
						astr=astr + dset.Tables[0].Rows[i][j].ToString();
						astr=astr + "</td>";
					}
					astr=astr + "</tr>";
					sw.Write(astr);
				}
				astr="</Table>";
				sw.Write(astr);
				sw.Close();
				return filePath;
			}
			catch(Exception ex)
			{
				upd_error(ex.Message,sComputer,tenfile);
				return "";
			}
		}

		public void writeXml(string tenfile,string cot,string s)
		{
			ds=new DataSet();
			ds.ReadXml("..\\..\\..\\xml\\"+tenfile+".xml");
			ds.Tables[0].Rows[0][cot]=s;
			ds.WriteXml("..\\..\\..\\xml\\"+tenfile+".xml");
		}
		public void delrec(DataTable dt,string exp)
		{
			try
			{
				DataRow[] r = dt.Select(exp);
				for(int i=0;i<r.Length;i++)	r[i].Delete();
			}
			catch{}
		}

		public DataRow getrowbyid (DataTable dt,string exp ) 
		{
			try
			{
				DataRow[] r = dt.Select ( exp ) ;
				return r[0] ;
			}
			catch{return null ;}
		}

		public void upd_error(string m_message,string m_computer,string m_table)
		{
			sql="insert into d_error(message,computer,tables,ngayud) values (:m_message,:m_computer,:m_table,now())";
			con=new NpgsqlConnection(sConn);
			//maccesscon = new LibMedi.AccessData();
			cmd=new NpgsqlCommand(sql,con);
			cmd.CommandType=CommandType.Text;

			cmd.Parameters.Add("m_message",NpgsqlDbType.Text,254).Value=m_message;
			cmd.Parameters.Add("m_computer",NpgsqlDbType.Text,20).Value=m_computer;
			cmd.Parameters.Add("m_table",NpgsqlDbType.Text,20).Value=m_table;
			try
			{
				con.Open();
				cmd.ExecuteNonQuery();
			}
			catch{}
			finally
			{
				cmd.Dispose();
				con.Dispose();
			}
		}

		public string Ngayhienhanh
		{
			get{return DateTime.Now.Day.ToString().PadLeft(2,'0')+"/"+DateTime.Now.Month.ToString().PadLeft(2,'0')+"/"+DateTime.Now.Year.ToString();}
		}
		public string Ngaylocal(string s)
		{
			try
			{
				string s1=s.Substring(0,10),s2="";
				if (s.Length>16) s=s.Substring(0,16);
				if (s.Length==16) s2=s.Substring(10,6);
				return StringTodestte(s1).ToLocalTime().ToShortDateString()+s2;
			}
			catch{return "";};
		}

		public string StringToMMDDYYYY(string s)
		{
			return s.Substring(3,2)+"/"+s.Substring(0,2)+"/"+s.Substring(6,4);
		}

		public string StringToDDMMYYYY(string s)
		{
			return s.Substring(0,2)+s.Substring(3,2)+s.Substring(6,4);
		}

		public System.DateTime StringToDateTime(string s)
		{
			string [] format={"dd/MM/yyyy "};
			return System.DateTime.ParseExact(s.ToString(),format,System.Globalization.DateTimeFormatInfo.CurrentInfo,System.Globalization.DateTimeStyles.None);
		}
		
		public System.DateTime StringToDateTime(string s,string f)
		{
			string [] format={f};
			return System.DateTime.ParseExact(s.ToString(),format,System.Globalization.DateTimeFormatInfo.CurrentInfo,System.Globalization.DateTimeStyles.None);
		}

		public string destteToString(string format,System.DateTime date)
		{
			if (date.Equals(null)) return "";
			else return  date.ToString(format,System.Globalization.DateTimeFormatInfo.CurrentInfo);
		}

		public void End_process(string program)
		{

			Process[] processes = Process.GetProcesses();
			if (processes.Length > 1)
				for (int n = 0; n <= processes.Length - 1; n++)
				{
					if (((Process)processes[n]).ProcessName.ToString().ToUpper() == program)
						processes[n].Kill();
				}

		}

		public long get_id_gpb
		{
			get
			{
				return long.Parse(getyymmddhhmiss()+getRandom().ToString().PadLeft(3,'0')+iRownum.ToString().PadLeft(3,'0'));
			}
		}

	    public int getRandom()
		{
			System.Threading.Thread.Sleep(10);
			Random r = new Random();
			return r.Next(999);
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

        public string tenbs(string mabs)
        {
            DataSet ds = get_data(" select hoten from " + user + ".dmbs where ma='" + mabs + "'");
            if (ds != null)
            {
                return ds.Tables[0].Rows[0]["hoten"].ToString();
            }
            return null;
        }

        public bool updgpb_vtstxn(long l_id, string m_sogpb, string m_mavtst, string m_magpb, string m_masttt, string m_malvtst)
        {
            sql = "update " + user + ".gpb_vtstxn set sogpb=:m_sogpb, mavtst=:m_mavtst, malvtst=:m_malvtst,magpb=:m_magpb,masttt=:m_masttt where id=:l_id";
            con = new NpgsqlConnection(sConn);
            cmd = new NpgsqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("m_malvtst", NpgsqlDbType.Text, 2).Value = m_malvtst;
            cmd.Parameters.Add("m_magpb", NpgsqlDbType.Text, 10).Value = m_magpb;
            cmd.Parameters.Add("m_masttt", NpgsqlDbType.Text, 6).Value = m_masttt;
            cmd.Parameters.Add("m_sogpb", NpgsqlDbType.Text, 10).Value = m_sogpb;
            cmd.Parameters.Add("m_mavtst", NpgsqlDbType.Text, 6).Value = m_mavtst;
            cmd.Parameters.Add("l_id", NpgsqlDbType.Numeric, 18).Value = l_id;
            try
            {
                con.Open();
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".gpb_vtstxn(sogpb,mavtst,malvtst,magpb,masttt,id) values(:m_sogpb,:m_mavtst,:m_malvtst,:m_magpb,:m_masttt,:l_id)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("m_sogpb", NpgsqlDbType.Text, 10).Value = m_sogpb;
                    cmd.Parameters.Add("m_mavtst", NpgsqlDbType.Text, 6).Value = m_mavtst;
                    cmd.Parameters.Add("m_malvtst", NpgsqlDbType.Text, 2).Value = m_malvtst;
                    cmd.Parameters.Add("m_magpb", NpgsqlDbType.Text, 10).Value = m_magpb;
                    cmd.Parameters.Add("m_masttt", NpgsqlDbType.Text, 6).Value = m_masttt;
                    cmd.Parameters.Add("l_id", NpgsqlDbType.Numeric, 18).Value = l_id;
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                cmd.Dispose();
                con.Dispose();
                return false;
            }
            cmd.Dispose();
            con.Dispose();
            return true;
        }

        public bool updgpb_loaivtst(string m_maloai, string m_tenloai)
        {
            sql = "update " + user + ".gpb_loaivtst set ten=:m_tenloai where ma=:m_maloai";
            con = new NpgsqlConnection(sConn);
            cmd = new NpgsqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("m_tenloai", NpgsqlDbType.Text).Value = m_tenloai;
            cmd.Parameters.Add("m_maloai", NpgsqlDbType.Text, 2).Value = m_maloai;

            try
            {
                con.Open();
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".gpb_loaivtst(ma,ten) values(:m_maloai,:m_tenloai)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("m_maloai", NpgsqlDbType.Text, 2).Value = m_maloai;
                    cmd.Parameters.Add("m_tenloai", NpgsqlDbType.Text).Value = m_tenloai;
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                cmd.Dispose();
                con.Dispose();
                return false;
            }
            cmd.Dispose();
            con.Dispose();
            return true;
        }

        public bool updgpb_btdbn(string m_mabn, string m_hotenbn, string m_namsinh, string m_dantoc, int m_gioitinh, string m_diachi, int m_tinhtrang)
        {
            sql = "update " + user + ".gpb_btdbn set hotenbn=:m_hotenbn,namsinh=:m_namsinh,dantoc=:m_dantoc,gioitinh=:m_gioitinh,diachi=:m_diachi,tinhtrang=:m_tinhtrang where mabn=:m_mabn";
            con = new NpgsqlConnection(sConn);
            cmd = new NpgsqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("m_hotenbn", NpgsqlDbType.Text,70).Value = m_hotenbn;
            cmd.Parameters.Add("m_namsinh", NpgsqlDbType.Text, 4).Value = m_namsinh;
            cmd.Parameters.Add("m_dantoc", NpgsqlDbType.Text,2).Value = m_dantoc;
            cmd.Parameters.Add("m_gioitinh", NpgsqlDbType.Numeric).Value = m_gioitinh;
            cmd.Parameters.Add("m_diachi", NpgsqlDbType.Text).Value = m_diachi;
            cmd.Parameters.Add("m_tinhtrang", NpgsqlDbType.Numeric).Value = m_tinhtrang;
            cmd.Parameters.Add("m_mabn", NpgsqlDbType.Text, 8).Value = m_mabn;

            try
            {
                con.Open();
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".gpb_btdbn(mabn,hotenbn,namsinh,dantoc,gioitinh,diachi,tinhtrang) values(:m_mabn,:m_hotenbn,:m_namsinh,:m_dantoc,:m_gioitinh,:m_diachi,:m_tinhtrang)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("m_mabn", NpgsqlDbType.Text, 8).Value = m_mabn;
                    cmd.Parameters.Add("m_hotenbn", NpgsqlDbType.Text, 70).Value = m_hotenbn;
                    cmd.Parameters.Add("m_namsinh", NpgsqlDbType.Text, 4).Value = m_namsinh;
                    cmd.Parameters.Add("m_dantoc", NpgsqlDbType.Text, 2).Value = m_dantoc;
                    cmd.Parameters.Add("m_gioitinh", NpgsqlDbType.Numeric).Value = m_gioitinh;
                    cmd.Parameters.Add("m_diachi", NpgsqlDbType.Text).Value = m_diachi;
                    cmd.Parameters.Add("m_tinhtrang", NpgsqlDbType.Numeric).Value = m_tinhtrang;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message.ToString().Trim(), sComputer, "?");
                cmd.Dispose();
                con.Dispose();
                return false;
            }
            cmd.Dispose();
            con.Dispose();
            return true;
        }

        public bool updgpb_ttkhac(long l_id, string m_sogpb, string m_tt_tcls, string m_kq_sttd, string m_nx_dtkst, string m_qtdt)
        {
            sql = "update " + user + ".gpb_ttkhac set sogpb=:m_sogpb, tt_tcls=:m_tt_cls,kq_sttd=:m_kq_sttd,nx_dtkst=:m_nx_dtkst,qtdt=:m_qtdt where id=:l_id";
            con = new NpgsqlConnection(sConn);
            cmd = new NpgsqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("m_tt_cls", NpgsqlDbType.Text).Value = m_tt_tcls;
            cmd.Parameters.Add("m_kq_sttd", NpgsqlDbType.Text).Value = m_kq_sttd;
            cmd.Parameters.Add("m_nx_dtkst", NpgsqlDbType.Text).Value = m_nx_dtkst;
            cmd.Parameters.Add("m_qtdt", NpgsqlDbType.Text).Value = m_qtdt;
            cmd.Parameters.Add("m_sogpb", NpgsqlDbType.Text, 10).Value = m_sogpb;
            cmd.Parameters.Add("l_id", NpgsqlDbType.Numeric).Value = l_id;

            try
            {
                con.Open();
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".gpb_ttkhac(sogpb,tt_tcls,kq_sttd,nx_dtkst,qtdt,id) values(:m_sogpb,:m_tt_cls,:m_kq_sttd,:m_nx_dtkst,:m_qtdt,:l_id)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("m_sogpb", NpgsqlDbType.Text, 10).Value = m_sogpb;
                    cmd.Parameters.Add("m_tt_cls", NpgsqlDbType.Text).Value = m_tt_tcls;
                    cmd.Parameters.Add("m_kq_sttd", NpgsqlDbType.Text).Value = m_kq_sttd;
                    cmd.Parameters.Add("m_nx_dtkst", NpgsqlDbType.Text).Value = m_nx_dtkst;
                    cmd.Parameters.Add("m_qtdt", NpgsqlDbType.Text).Value = m_qtdt;
                    cmd.Parameters.Add("l_id", NpgsqlDbType.Numeric).Value = l_id;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message.ToString().Trim(),sComputer,"?");
                cmd.Dispose();
                con.Dispose();
                return false;
            }
            cmd.Dispose();
            con.Dispose();
            return true;
        }

        public bool updgpb_vtsthmmd(long l_id, string m_sogpb, string m_mavtst, string m_malvtst)
        {
            sql = "update " + user + ".gpb_vtsthmmd set sogpb=:m_sogpb, mavtst=:m_mavtst,malvtst=:m_malvtst where id=:l_id";
            con = new NpgsqlConnection(sConn);
            cmd = new NpgsqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("m_mavtst", NpgsqlDbType.Text, 6).Value = m_mavtst;
            cmd.Parameters.Add("m_malvtst", NpgsqlDbType.Text, 2).Value = m_malvtst;
            cmd.Parameters.Add("m_sogpb", NpgsqlDbType.Text, 10).Value = m_sogpb;
            cmd.Parameters.Add("l_id", NpgsqlDbType.Numeric).Value = l_id;

            try
            {
                con.Open();
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".gpb_vtsthmmd(mavtst,malvtst,sogpb,id) values(:m_mavtst,:m_malvtst,:m_sogpb,:l_id)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("m_sogpb", NpgsqlDbType.Text, 10).Value = m_sogpb;
                    cmd.Parameters.Add("m_mavtst", NpgsqlDbType.Text, 6).Value = m_mavtst;
                    cmd.Parameters.Add("m_malvtst", NpgsqlDbType.Text, 2).Value = m_malvtst;
                    cmd.Parameters.Add("l_id", NpgsqlDbType.Numeric).Value = l_id;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message.ToString().Trim(), sComputer, "?");
                cmd.Dispose();
                con.Dispose();
                return false;
            }
            cmd.Dispose();
            con.Dispose();
            return true;
        }

        public bool updgpb_xnhmmd(long l_id, string m_sogpb, string m_mavtst, decimal m_mahmmd, int m_duongtinh, string m_cuongdo, decimal m_mucdo, string m_ghichu)
        {
            sql = "update " + user + ".gpb_xnhmmd set sogpb=:m_sogpb, mavtst=:m_mavtst, mahmmd=:m_mahmmd, duongtinh=:m_duongtinh,cuongdo=:m_cuongdo,mucdo=:m_mucdo,ghichu=:m_ghichu where id=:l_id";
            con = new NpgsqlConnection(sConn);
            cmd = new NpgsqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("m_duongtinh", NpgsqlDbType.Numeric).Value = m_duongtinh;
            cmd.Parameters.Add("m_cuongdo", NpgsqlDbType.Text, 15).Value = m_cuongdo;
            cmd.Parameters.Add("m_mucdo", NpgsqlDbType.Numeric).Value = m_mucdo;
            cmd.Parameters.Add("m_ghichu", NpgsqlDbType.Text).Value = m_ghichu;
            cmd.Parameters.Add("m_sogpb", NpgsqlDbType.Text, 10).Value = m_sogpb;
            cmd.Parameters.Add("m_mavtst", NpgsqlDbType.Text, 6).Value = m_mavtst;
            cmd.Parameters.Add("m_mahmmd", NpgsqlDbType.Numeric).Value = m_mahmmd;
            cmd.Parameters.Add("l_id", NpgsqlDbType.Numeric).Value = l_id;

            try
            {
                con.Open();
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".gpb_xnhmmd(sogpb,mavtst,mahmmd,duongtinh,cuongdo,mucdo,ghichu,id) values(:m_sogpb,:m_mavtst,:m_mahmmd,:m_duongtinh,:m_cuongdo,:m_mucdo,:m_ghichu,:l_id)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("m_sogpb", NpgsqlDbType.Text, 10).Value = m_sogpb;
                    cmd.Parameters.Add("m_mavtst", NpgsqlDbType.Text, 6).Value = m_mavtst;
                    cmd.Parameters.Add("m_mahmmd", NpgsqlDbType.Numeric).Value = m_mahmmd;
                    cmd.Parameters.Add("m_duongtinh", NpgsqlDbType.Numeric).Value = m_duongtinh;
                    cmd.Parameters.Add("m_cuongdo", NpgsqlDbType.Text, 15).Value = m_cuongdo;
                    cmd.Parameters.Add("m_mucdo", NpgsqlDbType.Numeric).Value = m_mucdo;
                    cmd.Parameters.Add("m_ghichu", NpgsqlDbType.Text).Value = m_ghichu;
                    cmd.Parameters.Add("l_id", NpgsqlDbType.Numeric).Value = l_id;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message.ToString().Trim(), sComputer, "?");
                cmd.Dispose();
                con.Dispose();
                return false;
            }
            cmd.Dispose();
            con.Dispose();
            return true;
        }

        public bool updgpb_chandoan(long l_id, string m_sogpb, string m_mavtst, string m_magpb, string m_masttt)
        {
            sql = "update " + user + ".gpb_chandoan set sogpb=:m_sogpb, mavtst=:m_mavtst, magpb=:m_magpb, masttt=:m_masttt where id=:l_id";
            con = new NpgsqlConnection(sConn);
            cmd = new NpgsqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("m_masttt", NpgsqlDbType.Text, 6).Value = m_masttt;
            cmd.Parameters.Add("m_sogpb", NpgsqlDbType.Text, 10).Value = m_sogpb;
            cmd.Parameters.Add("m_mavtst", NpgsqlDbType.Text, 6).Value = m_mavtst;
            cmd.Parameters.Add("m_magpb", NpgsqlDbType.Text, 10).Value = m_magpb;
            cmd.Parameters.Add("l_id", NpgsqlDbType.Numeric).Value = l_id;

            try
            {
                con.Open();
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".gpb_chandoan(sogpb,mavtst,magpb,masttt,id) values(:m_sogpb,:m_mavtst,:m_magpb,:m_masttt,:l_id)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("m_sogpb", NpgsqlDbType.Text, 10).Value = m_sogpb;
                    cmd.Parameters.Add("m_mavtst", NpgsqlDbType.Text, 6).Value = m_mavtst;
                    cmd.Parameters.Add("m_magpb", NpgsqlDbType.Text, 10).Value = m_magpb;
                    cmd.Parameters.Add("m_masttt", NpgsqlDbType.Text, 6).Value = m_masttt;
                    cmd.Parameters.Add("l_id", NpgsqlDbType.Numeric).Value = l_id;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message.ToString().Trim(), sComputer, "?");
                cmd.Dispose();
                con.Dispose();
                return false;
            }
            cmd.Dispose();
            con.Dispose();
            return true;
        }

        public string get_viettat(string mavt)
        {
            try
            {
                DataSet ads = new DataSet();
                ads.ReadXml(@"..\\..\\..\\xml\\dmviettat.xml", XmlReadMode.Auto);
                string sql = "matat='" + mavt + "'";
                DataRow[] r = ads.Tables[0].Select(sql);
                if (r != null) return r[0]["daydu"].ToString();
                else return mavt;
                //return get_data("select daydu from btdvt a where lower(trim(a.matat))='"+mavt+"'").Tables[0].Rows[0][0].ToString();
            }
            catch
            {
                return mavt;
            }
        }

      

        public void updgpb_pxn(long m_id, string m_sogpb, decimal l_maql, byte[] anh1, byte[] anh2)
        {
            sql = "update " + user + ".gpb_pxn set sogpb=:m_sogpb, anh1=:anh1, anh2=:anh2 where id=:m_id";
            try
            {
                con = new NpgsqlConnection(sConn);
                cmd = new NpgsqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("m_sogpb", NpgsqlDbType.Text, 10).Value = m_sogpb;
                cmd.Parameters.Add("anh1", NpgsqlDbType.Bytea, anh1.Length).Value = anh1;
                cmd.Parameters.Add("anh2", NpgsqlDbType.Bytea, anh2.Length).Value = anh2;                
                cmd.Parameters.Add("m_id", NpgsqlDbType.Numeric).Value = m_id;
                con.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch
            {

            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
        }

        public bool updgpb_pxn(long m_id, string m_sogpb, string m_sohs, string m_ngaynhan, string m_dvyc, string m_bsyc, string m_cdls, string m_hadt, string m_havt, int m_nhuomdb, int m_coanh, byte[] m_anh1, byte[] m_anh2, int m_sttt, string m_lcdgpb, string m_banluan, string m_ngaytra, string m_bacsidoc, string m_truongkhoa, string m_mabn, decimal m_maql, int m_nhuomhe, string m_mabs_bp, string m_ngaybdpha, int m_somanh, string m_ngaykttb, string m_mabs_tb, int m_phuhop, long m_id_vpkhoa)
        {
            sql = "update " + user + ".gpb_pxn set sogpb=:m_sogpb,sohs=:m_sohs,ngaynhan=to_timestamp(:m_ngaynhan,'dd/mm/yyyy hh24:mi'),";
            sql+="maql=:m_maql, dvyc=:m_dvyc,bsyc=:m_bsyc,cdls=:m_cdls,";
            sql+="hadt=:m_hadt,havt=:m_havt,nhuomdb=:m_nhuomdb,coanh=:m_coanh,sttt=:m_sttt,lcdgpb=:m_lcdgpb,";
            sql+="banluan=:m_banluan,ngaytra=to_timestamp(:m_ngaytra,'dd/mm/yyyy hh24:mi'),bacsidoc=:m_bacsidoc,";
            sql+="truongkhoa=:m_truongkhoa,nhuomhe=:m_nhuomhe,mabs_bp=:m_mabs_bp";
            if (m_ngaybdpha != "") sql += ",ngaybdpha=to_timestamp(:m_ngaybdpha,'dd/mm/yyyy hh24:mi')";
            sql += ",somanh=:m_somanh";
            if (m_ngaykttb != "") sql += ",ngaykttb=to_timestamp(:m_ngaykttb,'dd/mm/yyyy hh24:mi')";
            sql += ",mabs_tb=:m_mabs_tb,phuhop=:m_phuhop,id_vpkhoa=:m_id_vpkhoa";
            if (m_coanh != 0) sql += ",anh1=:m_anh1, anh2=:m_anh2";
            sql += " where id=:m_id";
            con = new NpgsqlConnection(sConn);
            cmd = new NpgsqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("m_sogpb", NpgsqlDbType.Text, 10).Value = m_sogpb;
            cmd.Parameters.Add("m_sohs", NpgsqlDbType.Text, 8).Value = m_sohs;
            cmd.Parameters.Add("m_ngaynhan", NpgsqlDbType.Text).Value = m_ngaynhan;
            cmd.Parameters.Add("m_maql", NpgsqlDbType.Numeric).Value = m_maql;
            cmd.Parameters.Add("m_dvyc", NpgsqlDbType.Text, 2).Value = m_dvyc;
            cmd.Parameters.Add("m_bsyc", NpgsqlDbType.Text, 4).Value = m_bsyc;
            cmd.Parameters.Add("m_cdls", NpgsqlDbType.Text).Value = m_cdls;
            cmd.Parameters.Add("m_hadt", NpgsqlDbType.Text).Value = m_hadt;
            cmd.Parameters.Add("m_havt", NpgsqlDbType.Text).Value = m_havt;
            cmd.Parameters.Add("m_nhuomdb", NpgsqlDbType.Numeric).Value = m_nhuomdb;
            cmd.Parameters.Add("m_coanh", NpgsqlDbType.Numeric).Value = m_coanh;
            cmd.Parameters.Add("m_sttt", NpgsqlDbType.Numeric).Value = m_sttt;
            cmd.Parameters.Add("m_lcdgpb", NpgsqlDbType.Text).Value = m_lcdgpb;
            cmd.Parameters.Add("m_banluan", NpgsqlDbType.Text).Value = m_banluan;
            cmd.Parameters.Add("m_ngaytra", NpgsqlDbType.Text).Value = m_ngaytra;
            cmd.Parameters.Add("m_bacsidoc", NpgsqlDbType.Text, 4).Value = m_bacsidoc;
            cmd.Parameters.Add("m_truongkhoa", NpgsqlDbType.Text, 4).Value = m_truongkhoa;
            cmd.Parameters.Add("m_nhuomhe", NpgsqlDbType.Numeric).Value = m_nhuomhe;
            cmd.Parameters.Add("m_mabs_bp", NpgsqlDbType.Text, 4).Value = m_mabs_bp;
            if (m_ngaybdpha != "") cmd.Parameters.Add("m_ngaybdpha", NpgsqlDbType.Text).Value = m_ngaybdpha;
            cmd.Parameters.Add("m_somanh", NpgsqlDbType.Numeric, 2).Value = m_somanh;
            if (m_ngaykttb != "") cmd.Parameters.Add("m_ngaykttb", NpgsqlDbType.Text).Value = m_ngaykttb;
            cmd.Parameters.Add("m_mabs_tb", NpgsqlDbType.Text, 4).Value = m_mabs_tb;
            cmd.Parameters.Add("m_phuhop", NpgsqlDbType.Numeric).Value = m_phuhop;
            cmd.Parameters.Add("m_id_vpkhoa", NpgsqlDbType.Numeric).Value = m_id_vpkhoa;
            if (m_coanh != 0)
            {
                cmd.Parameters.Add("m_anh1", NpgsqlDbType.Bytea, m_anh1.Length).Value = m_anh1;
                cmd.Parameters.Add("m_anh2", NpgsqlDbType.Bytea, m_anh2.Length).Value = m_anh2;
            }                        
            cmd.Parameters.Add("m_id", NpgsqlDbType.Numeric).Value = m_id;
            try
            {
                con.Open();
                int k = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (k == 0)
                {
                    sql = "insert into " + user + ".gpb_pxn(sogpb,sohs,ngaynhan,dvyc,bsyc,cdls,hadt,havt,nhuomdb,coanh";
                    if (m_coanh != 0) sql += ",anh1,anh2";
                    sql += ",sttt,lcdgpb,banluan,ngaytra,bacsidoc,truongkhoa,nhuomhe,mabn,maql,mabs_bp";
                    if (m_ngaybdpha != "") sql += ",ngaybdpha";
                    sql += ",somanh";
                    if (m_ngaykttb != "") sql += ",ngaykttb";
                    sql += ",mabs_tb,phuhop,id_vpkhoa,id)";
                    sql += " values(:m_sogpb,:m_sohs,to_timestamp(:m_ngaynhan,'dd/mm/yyyy hh24:mi'),:m_dvyc,:m_bsyc,:m_cdls,:m_hadt,:m_havt,:m_nhuomdb,:m_coanh";
                    if (m_coanh != 0) sql += ",:m_anh1,:m_anh2";
                    sql += ",:m_sttt,:m_lcdgpb,:m_banluan,to_timestamp(:m_ngaytra,'dd/mm/yyyy hh24:mi'),:m_bacsidoc,:m_truongkhoa,:m_nhuomhe,:m_mabn,:m_maql,:m_mabs_bp";
                    if (m_ngaybdpha != "") sql += ",to_timestamp(:m_ngaybdpha,'dd/mm/yyyy hh24:mi')";
                    sql += ",:m_somanh";
                    if (m_ngaykttb != "") sql += ",to_timestamp(:m_ngaykttb,'dd/mm/yyyy hh24:mi')";
                    sql += ",:m_mabs_tb,:m_phuhop,:m_id_vpkhoa,:m_id)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("m_sogpb", NpgsqlDbType.Text, 10).Value = m_sogpb;
                    cmd.Parameters.Add("m_sohs", NpgsqlDbType.Text, 8).Value = m_sohs;
                    cmd.Parameters.Add("m_ngaynhan", NpgsqlDbType.Text).Value = m_ngaynhan;
                    cmd.Parameters.Add("m_dvyc", NpgsqlDbType.Text, 2).Value = m_dvyc;
                    cmd.Parameters.Add("m_bsyc", NpgsqlDbType.Text, 4).Value = m_bsyc;
                    cmd.Parameters.Add("m_cdls", NpgsqlDbType.Text).Value = m_cdls;
                    cmd.Parameters.Add("m_hadt", NpgsqlDbType.Text).Value = m_hadt;
                    cmd.Parameters.Add("m_havt", NpgsqlDbType.Text).Value = m_havt;
                    cmd.Parameters.Add("m_nhuomdb", NpgsqlDbType.Numeric).Value = m_nhuomdb;
                    cmd.Parameters.Add("m_coanh", NpgsqlDbType.Numeric).Value = m_coanh;
                    if (m_coanh != 0)
                    {
                        cmd.Parameters.Add("m_anh1", NpgsqlDbType.Bytea, m_anh1.Length).Value = m_anh1;
                        cmd.Parameters.Add("m_anh2", NpgsqlDbType.Bytea, m_anh2.Length).Value = m_anh2;
                    }
                    cmd.Parameters.Add("m_sttt", NpgsqlDbType.Numeric).Value = m_sttt;
                    cmd.Parameters.Add("m_lcdgpb", NpgsqlDbType.Text).Value = m_lcdgpb;
                    cmd.Parameters.Add("m_banluan", NpgsqlDbType.Text).Value = m_banluan;
                    cmd.Parameters.Add("m_ngaytra", NpgsqlDbType.Text).Value = m_ngaytra;
                    cmd.Parameters.Add("m_bacsidoc", NpgsqlDbType.Text, 4).Value = m_bacsidoc;
                    cmd.Parameters.Add("m_truongkhoa", NpgsqlDbType.Text, 4).Value = m_truongkhoa;
                    cmd.Parameters.Add("m_nhuomhe", NpgsqlDbType.Numeric).Value = m_nhuomhe;
                    cmd.Parameters.Add("m_mabs_bp", NpgsqlDbType.Text, 4).Value = m_mabs_bp;
                    if (m_ngaybdpha != "") cmd.Parameters.Add("m_ngaybdpha", NpgsqlDbType.Text).Value = m_ngaybdpha;
                    cmd.Parameters.Add("m_somanh", NpgsqlDbType.Numeric).Value = m_somanh;
                    if (m_ngaykttb != "") cmd.Parameters.Add("m_ngaykttb", NpgsqlDbType.Text).Value = m_ngaykttb;
                    cmd.Parameters.Add("m_mabs_tb", NpgsqlDbType.Text, 4).Value = m_mabs_tb;
                    cmd.Parameters.Add("m_phuhop", NpgsqlDbType.Numeric).Value = m_phuhop;
                    cmd.Parameters.Add("m_id_vpkhoa", NpgsqlDbType.Numeric).Value = m_id_vpkhoa;
                    cmd.Parameters.Add("m_mabn", NpgsqlDbType.Text, 8).Value = m_mabn;
                    cmd.Parameters.Add("m_maql", NpgsqlDbType.Numeric).Value = m_maql;
                    cmd.Parameters.Add("m_id", NpgsqlDbType.Numeric).Value = m_id;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    con.Close();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message.ToString().Trim(), sComputer, "?");
                cmd.Dispose();
                con.Close();
                return false;
            }
            return true;
        }

        public bool updgpb_pxn(long m_id, string m_sogpb, string m_sohs, string m_ngaynhan, string m_dvyc, string m_bsyc, string m_cdls, string m_hadt, string m_havt, int m_nhuomdb, int m_coanh, int m_sttt, string m_lcdgpb, string m_banluan, string m_ngaytra, string m_bacsidoc, string m_truongkhoa, string m_mabn, decimal m_maql, int m_nhuomhe, string m_mabs_bp, string m_ngaybdpha, int m_somanh, string m_ngaykttb, string m_mabs_tb, int m_phuhop, long m_id_vpkhoa)
        {
            sql = "update " + user + ".gpb_pxn set sogpb=:m_sogpb,sohs=:m_sohs,ngaynhan=to_timestamp(:m_ngaynhan,'dd/mm/yyyy hh24:mi'),";
            sql+="maql=:m_maql, dvyc=:m_dvyc,bsyc=:m_bsyc,cdls=:m_cdls,hadt=:m_hadt,";
            sql+="havt=:m_havt,nhuomdb=:m_nhuomdb,coanh=:m_coanh,sttt=:m_sttt,lcdgpb=:m_lcdgpb,banluan=:m_banluan,";
            sql+="ngaytra=to_timestamp(:m_ngaytra,'dd/mm/yyyy hh24:mi'),bacsidoc=:m_bacsidoc,truongkhoa=:m_truongkhoa,";
            sql+="nhuomhe=:m_nhuomhe,mabs_bp=:m_mabs_bp";
            if (m_ngaybdpha != "") sql += ",ngaybdpha=to_timestamp(:m_ngaybdpha,'dd/mm/yyyy hh24:mi')";
            sql += ",somanh=:m_somanh";
            if (m_ngaykttb != "") sql += ",ngaykttb=to_timestamp(:m_ngaykttb,'dd/mm/yyyy hh24:mi')";
            sql += ",mabs_tb=:m_mabs_tb,phuhop=:m_phuhop,id_vpkhoa=:m_id_vpkhoa";
            sql += " where id=:m_id";
            con = new NpgsqlConnection(sConn);
            cmd = new NpgsqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("m_sogpb", NpgsqlDbType.Text, 10).Value = m_sogpb;
            cmd.Parameters.Add("m_sohs", NpgsqlDbType.Text, 8).Value = m_sohs;
            cmd.Parameters.Add("m_ngaynhan", NpgsqlDbType.Text).Value = m_ngaynhan;
            cmd.Parameters.Add("m_maql", NpgsqlDbType.Numeric).Value = m_maql;
            cmd.Parameters.Add("m_dvyc", NpgsqlDbType.Text, 2).Value = m_dvyc;
            cmd.Parameters.Add("m_bsyc", NpgsqlDbType.Text, 4).Value = m_bsyc;
            cmd.Parameters.Add("m_cdls", NpgsqlDbType.Text).Value = m_cdls;
            cmd.Parameters.Add("m_hadt", NpgsqlDbType.Text).Value = m_hadt;
            cmd.Parameters.Add("m_havt", NpgsqlDbType.Text).Value = m_havt;
            cmd.Parameters.Add("m_nhuomdb", NpgsqlDbType.Numeric).Value = m_nhuomdb;
            cmd.Parameters.Add("m_coanh", NpgsqlDbType.Numeric).Value = m_coanh;
            cmd.Parameters.Add("m_sttt", NpgsqlDbType.Numeric).Value = m_sttt;
            cmd.Parameters.Add("m_lcdgpb", NpgsqlDbType.Text).Value = m_lcdgpb;
            cmd.Parameters.Add("m_banluan", NpgsqlDbType.Text).Value = m_banluan;
            cmd.Parameters.Add("m_ngaytra", NpgsqlDbType.Text).Value = m_ngaytra;
            cmd.Parameters.Add("m_bacsidoc", NpgsqlDbType.Text, 4).Value = m_bacsidoc;
            cmd.Parameters.Add("m_truongkhoa", NpgsqlDbType.Text, 4).Value = m_truongkhoa;
            cmd.Parameters.Add("m_nhuomhe", NpgsqlDbType.Numeric).Value = m_nhuomhe;
            cmd.Parameters.Add("m_mabs_bp", NpgsqlDbType.Text, 4).Value = m_mabs_bp;
            if (m_ngaybdpha != "") cmd.Parameters.Add("m_ngaybdpha", NpgsqlDbType.Text).Value = m_ngaybdpha;
            cmd.Parameters.Add("m_somanh", NpgsqlDbType.Numeric, 2).Value = m_somanh;
            if (m_ngaykttb != "") cmd.Parameters.Add("m_ngaykttb", NpgsqlDbType.Text).Value = m_ngaykttb;
            cmd.Parameters.Add("m_mabs_tb", NpgsqlDbType.Text, 4).Value = m_mabs_tb;
            cmd.Parameters.Add("m_phuhop", NpgsqlDbType.Numeric).Value = m_phuhop;
            cmd.Parameters.Add("m_id_vpkhoa", NpgsqlDbType.Numeric).Value = m_id_vpkhoa;                        
            cmd.Parameters.Add("m_id", NpgsqlDbType.Numeric).Value = m_id;

            try
            {
                con.Open();
                int k = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (k == 0)
                {
                    sql = "insert into " + user + ".gpb_pxn(sogpb,sohs,ngaynhan,dvyc,bsyc,cdls,hadt,havt,nhuomdb,coanh";
                    sql += ",sttt,lcdgpb,banluan,ngaytra,bacsidoc,truongkhoa,nhuomhe,mabn,maql,mabs_bp";
                    if (m_ngaybdpha != "") sql += ",ngaybdpha";
                    sql += ",somanh";
                    if (m_ngaybdpha != "") sql += ",ngaykttb";
                    sql += ",mabs_tb,phuhop,id_vpkhoa,id)";
                    sql += " values(:m_sogpb,:m_sohs,to_timestamp(:m_ngaynhan,'dd/mm/yyyy hh24:mi'),:m_dvyc,:m_bsyc,:m_cdls,:m_hadt,:m_havt,:m_nhuomdb,:m_coanh";
                    sql += ",:m_sttt,:m_lcdgpb,:m_banluan,to_timestamp(:m_ngaytra,'dd/mm/yyyy hh24:mi'),:m_bacsidoc,:m_truongkhoa,:m_nhuomhe,:m_mabn,:m_maql,:m_mabs_bp";
                    if (m_ngaybdpha != "") sql += ",to_timestamp(:m_ngaybdpha,'dd/mm/yyyy hh24:mi')";
                    sql += ",:m_somanh";
                    if (m_ngaybdpha != "") sql += ",to_timestamp(:m_ngaykttb,'dd/mm/yyyy hh24:mi')";
                    sql += ",:m_mabs_tb,:m_phuhop,:m_id_vpkhoa,:m_id)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("m_sogpb", NpgsqlDbType.Text, 10).Value = m_sogpb;
                    cmd.Parameters.Add("m_sohs", NpgsqlDbType.Text, 8).Value = m_sohs;
                    cmd.Parameters.Add("m_ngaynhan", NpgsqlDbType.Text).Value = m_ngaynhan;
                    cmd.Parameters.Add("m_dvyc", NpgsqlDbType.Text, 2).Value = m_dvyc;
                    cmd.Parameters.Add("m_bsyc", NpgsqlDbType.Text, 4).Value = m_bsyc;
                    cmd.Parameters.Add("m_cdls", NpgsqlDbType.Text).Value = m_cdls;
                    cmd.Parameters.Add("m_hadt", NpgsqlDbType.Text).Value = m_hadt;
                    cmd.Parameters.Add("m_havt", NpgsqlDbType.Text).Value = m_havt;
                    cmd.Parameters.Add("m_nhuomdb", NpgsqlDbType.Numeric).Value = m_nhuomdb;
                    cmd.Parameters.Add("m_coanh", NpgsqlDbType.Numeric).Value = m_coanh;
                    cmd.Parameters.Add("m_sttt", NpgsqlDbType.Numeric).Value = m_sttt;
                    cmd.Parameters.Add("m_lcdgpb", NpgsqlDbType.Text).Value = m_lcdgpb;
                    cmd.Parameters.Add("m_banluan", NpgsqlDbType.Text).Value = m_banluan;
                    cmd.Parameters.Add("m_ngaytra", NpgsqlDbType.Text).Value = m_ngaytra;
                    cmd.Parameters.Add("m_bacsidoc", NpgsqlDbType.Text, 4).Value = m_bacsidoc;
                    cmd.Parameters.Add("m_truongkhoa", NpgsqlDbType.Text, 4).Value = m_truongkhoa;
                    cmd.Parameters.Add("m_nhuomhe", NpgsqlDbType.Numeric).Value = m_nhuomhe;
                    cmd.Parameters.Add("m_mabs_bp", NpgsqlDbType.Text, 4).Value = m_mabs_bp;
                    if (m_ngaybdpha != "") cmd.Parameters.Add("m_ngaybdpha", NpgsqlDbType.Text).Value = m_ngaybdpha;
                    cmd.Parameters.Add("m_somanh", NpgsqlDbType.Numeric).Value = m_somanh;
                    if (m_ngaykttb != "") cmd.Parameters.Add("m_ngaykttb", NpgsqlDbType.Text).Value =m_ngaykttb;
                    cmd.Parameters.Add("m_mabs_tb", NpgsqlDbType.Text, 4).Value = m_mabs_tb;
                    cmd.Parameters.Add("m_phuhop", NpgsqlDbType.Numeric).Value = m_phuhop;
                    cmd.Parameters.Add("m_id_vpkhoa", NpgsqlDbType.Numeric).Value = m_id_vpkhoa;
                    cmd.Parameters.Add("m_mabn", NpgsqlDbType.Text, 8).Value = m_mabn;
                    cmd.Parameters.Add("m_maql", NpgsqlDbType.Numeric).Value = m_maql;
                    cmd.Parameters.Add("m_id", NpgsqlDbType.Numeric).Value = m_id;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    con.Close();
                }
            }
            catch
            {
                cmd.Dispose();
                con.Close();
                return false;
            }
            return true;
        }

        public bool updgpb_dmgpb(string m_manhomgpb, string m_magpb, string m_tengpb, string m_name, int m_sudung, string m_nhanxet, string m_chandoan)
        {
            sql = "update " + user + ".gpb_gpb set tengpb=:m_tengpb, name=:m_name, sudung=:m_sudung, nhanxet=:m_nhanxet, chandoan=:m_chandoan where magpb=:m_magpb";
            con = new NpgsqlConnection(sConn);
            cmd = new NpgsqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("m_tengpb", NpgsqlDbType.Text).Value = m_tengpb;
            cmd.Parameters.Add("m_name", NpgsqlDbType.Text).Value = m_name;
            cmd.Parameters.Add("m_sudung", NpgsqlDbType.Numeric).Value = m_sudung;            
            cmd.Parameters.Add("m_nhanxet", NpgsqlDbType.Text).Value = m_nhanxet;
            cmd.Parameters.Add("m_chandoan", NpgsqlDbType.Text).Value = m_chandoan;
            cmd.Parameters.Add("m_magpb", NpgsqlDbType.Text, 10).Value = m_magpb;

            try
            {
                con.Open();
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".gpb_gpb(manhomgpb, magpb, tengpb, name, sudung, nhanxet, chandoan) values(:m_manhomgpb, :m_magpb, :m_tengpb, :m_name, :m_sudung, :m_nhanxet, :m_chandoan)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("m_manhomgpb", NpgsqlDbType.Text, 6).Value = m_manhomgpb;
                    cmd.Parameters.Add("m_magpb", NpgsqlDbType.Text, 10).Value = m_magpb;
                    cmd.Parameters.Add("m_tengpb", NpgsqlDbType.Text).Value = m_tengpb;
                    cmd.Parameters.Add("m_name", NpgsqlDbType.Text).Value = m_name;
                    cmd.Parameters.Add("m_sudung", NpgsqlDbType.Numeric).Value = m_sudung;
                    cmd.Parameters.Add("m_nhanxet", NpgsqlDbType.Text).Value = m_nhanxet;
                    cmd.Parameters.Add("m_chandoan", NpgsqlDbType.Text).Value = m_chandoan;

                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                cmd.Dispose();
                con.Dispose();
                return false;
            }
            cmd.Dispose();
            con.Dispose();
            return true;
        }

        public string get_tenbs(string ma)
        {
            try
            {
                return get_data("select hoten from " + user + ".dmbs where ma='" + ma.ToString() + "'").Tables[0].Rows[0][0].ToString();
            }
            catch
            {
                return "";
            }
        }

        public string get_tenvtst(string mavtst)
        {
            try
            {
                return get_data("select tenvtst from " + user + ".gpb_vtst where mavtst='" + mavtst.ToString() + "'").Tables[0].Rows[0][0].ToString();
            }
            catch
            {
                return "";
            }
        }

        public string get_tengpb(string magpb)
        {
            try
            {
                return get_data("select tengpb from " + user + ".gpb_gpb where magpb='" + magpb.ToString() + "'").Tables[0].Rows[0][0].ToString();
            }
            catch
            {
                return "";
            }
        }

        public bool updgpb_dmhmmd(string m_mahmmd, string m_tenhmmd)
        {
            sql = "update " + user + ".gpb_hmmd set tenhmmd=:m_tenhmmd where mahmmd=:m_mahmmd";
            con = new NpgsqlConnection(sConn);
            cmd = new NpgsqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("m_tenhmmd", NpgsqlDbType.Text).Value = m_tenhmmd;
            cmd.Parameters.Add("m_mahmmd", NpgsqlDbType.Varchar,10).Value = m_mahmmd;

            try
            {
                con.Open();
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".gpb_hmmd(mahmmd,tenhmmd) values(:m_mahmmd,:m_tenhmmd)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("m_mahmmd", NpgsqlDbType.Varchar, 10).Value = m_mahmmd;
                    cmd.Parameters.Add("m_tenhmmd", NpgsqlDbType.Text).Value = m_tenhmmd;
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                cmd.Dispose();
                con.Dispose();
                return false;
            }
            cmd.Dispose();
            con.Dispose();
            return true;
        }

        public bool updgpb_dmvtst(string m_manhomvtst, string m_mavtst, string m_tenvtst, string m_namevtst, string m_hadt, string m_havt)
        {
            sql = "update " + user + ".gpb_vtst set tenvtst=:m_tenvtst, namevtst=:m_namevtst, hadt=:m_hadt, havt=:m_havt where mavtst=:m_mavtst";
            con = new NpgsqlConnection(sConn);
            cmd = new NpgsqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("m_tenvtst", NpgsqlDbType.Text).Value = m_tenvtst;
            cmd.Parameters.Add("m_namevtst", NpgsqlDbType.Text).Value = m_namevtst;            
            cmd.Parameters.Add("m_hadt", NpgsqlDbType.Text).Value = m_hadt;
            cmd.Parameters.Add("m_havt", NpgsqlDbType.Text).Value = m_havt;
            cmd.Parameters.Add("m_mavtst", NpgsqlDbType.Text, 6).Value = m_mavtst;

            try
            {
                con.Open();
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".gpb_vtst(manhomvtst, mavtst, tenvtst, namevtst, hadt, havt) values(:m_manhomvtst, :m_mavtst, :m_tenvtst, :m_namevtst, :m_hadt, :m_havt)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("m_manhomvtst", NpgsqlDbType.Text, 6).Value = m_manhomvtst;
                    cmd.Parameters.Add("m_mavtst", NpgsqlDbType.Text, 6).Value = m_mavtst;
                    cmd.Parameters.Add("m_tenvtst", NpgsqlDbType.Text).Value = m_tenvtst;
                    cmd.Parameters.Add("m_namevtst", NpgsqlDbType.Text).Value = m_namevtst;
                    cmd.Parameters.Add("m_hadt", NpgsqlDbType.Text).Value = m_hadt;
                    cmd.Parameters.Add("m_havt", NpgsqlDbType.Text).Value = m_havt;

                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                cmd.Dispose();
                con.Dispose();
                return false;
            }
            cmd.Dispose();
            con.Dispose();
            return true;
        }

        public bool updgpb_nhomvtst(string m_manhomvtst, string m_tennhomvtst, string m_name)
        {
            sql = "update " + user + ".gpb_nhomvtst set tennhomvtst=:m_tennhomvtst, name=:m_name where manhomvtst=:m_manhomvtst";
            con = new NpgsqlConnection(sConn);
            cmd = new NpgsqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("m_tennhomvtst", NpgsqlDbType.Text).Value = m_tennhomvtst;
            cmd.Parameters.Add("m_name", NpgsqlDbType.Text).Value = m_name;
            cmd.Parameters.Add("m_manhomvtst", NpgsqlDbType.Text).Value = m_manhomvtst;
            try
            {
                con.Open();
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".gpb_nhomvtst(manhomvtst, tennhomvtst,name) values(:m_manhomvtst, :m_tennhomvtst, :m_name)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("m_manhomvtst", NpgsqlDbType.Text, 6).Value = m_manhomvtst;
                    cmd.Parameters.Add("m_tennhomvtst", NpgsqlDbType.Text).Value = m_tennhomvtst;
                    cmd.Parameters.Add("m_name", NpgsqlDbType.Text).Value = m_name;                    

                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                cmd.Dispose();
                con.Dispose();
                return false;
            }
            cmd.Dispose();
            con.Dispose();
            return true;
        }

        public DataSet get_bangkq(string sogpb)
        {
            string sql1 = "select to_char(a.ngaynhan,'dd/mm/yyyy') as ngaynhan, a.*,c.tenvtst,d.tenkp,e.hotenbn ,to_number(to_char(now(),'yyyy'))-to_number(e.namsinh) tuoibn ,e.gioitinh,e.diachi,f.*,h.tenvtst kqvtst,i.tengpb,j.hoten bacsibp,k.hoten bacsitb ";
            sql1 += " from " + user + ".gpb_pxn a," + user + ".gpb_vtstxn b," + user + ".gpb_vtst c," + user + ".btdkp_bv d," + user + ".gpb_btdbn e," + user + ".gpb_ttkhac f," + user + ".gpb_chandoan g," + user + ".gpb_vtst h," + user + ".gpb_gpb i," + user + ".dmbs j," + user + ".dmbs k ";
            sql1 += " where a.sogpb=b.sogpb and b.mavtst=c.mavtst and a.sogpb=g.sogpb and g.mavtst=h.mavtst and g.magpb=i.magpb and a.mabs_bp=j.ma(+) and a.mabs_tb=k.ma(+) and ";
            sql1 += " a.dvyc=d.makp and a.sohs= e.mabn and a.sogpb=f.sogpb and a.sogpb='" + sogpb + "'";
            string sql2 = "SELECT a.*,b.tenhmmd FROM " + user + ".GPB_XNHMMD a," + user + ".GPB_HMMD b where a.mahmmd=b.mahmmd and a.sogpb='" + sogpb + "'";
            try
            {
                con = new NpgsqlConnection(sConn);
                con.Open();
                cmd = new NpgsqlCommand(sql1, con);
                cmd.CommandType = CommandType.Text;
                dest = new NpgsqlDataAdapter(cmd);
                ds = new DataSet();
                dest.Fill(ds, "Table1");
                cmd = new NpgsqlCommand(sql2, con);
                dest = new NpgsqlDataAdapter(cmd);
                dest.Fill(ds, "Table2");
                cmd.Dispose();
                con.Dispose();
            }
            catch
            {
            }
            return ds;
        }

      
        public string getyymmddhhmiss()
        {
            return get_data("select to_char(now(),'yymmddhh24miss')").Tables[0].Rows[0][0].ToString();
        }

        public long getidyymmddhhmiss_stt_computer
        {
            get
            {
                return long.Parse(getyymmddhhmiss() + getRandom().ToString().PadLeft(3, '0') + iRownum.ToString().PadLeft(3, '0'));
            }
        }


        public long get_cap_id_gpb
        {
            get
            {
                return getidyymmddhhmiss_stt_computer;
            }
        }
        #region linh

        public void upd_thongso(int m_id, string m_loai, string m_value)
        {
            sql = "update " + user + ".gpb_thongso set loai=:m_loai,value=:m_value ";
            sql += " where id=" + m_id;
            con = new NpgsqlConnection(sConn);
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("m_loai", NpgsqlDbType.Text).Value = m_loai;
                cmd.Parameters.Add("m_value", NpgsqlDbType.Text).Value = m_value;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".gpb_thongso(id,loai,value) values (:m_id,:m_loai,:m_value)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("m_id", NpgsqlDbType.Numeric).Value = m_id;
                    cmd.Parameters.Add("m_loai", NpgsqlDbType.Text).Value = m_loai;
                    cmd.Parameters.Add("m_value", NpgsqlDbType.Text).Value = m_value;
                    irec = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message.ToString().Trim(), sComputer, "gpb_thongso");
            }
            finally
            {
                con.Close(); con.Dispose();
            }
        }
        public int i_mavp
        {
            get
            {
                int i = -1;
                try
                {
                    i = int.Parse(get_data("select nvl(value,-1) from " + user + ".gpb_thongso where id=1").Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    i = -1;
                }
                return i;
            }
        }
        public int i_ngayhethong
        {
            get
            {
                int i = -1;
                try
                {
                    i = int.Parse(get_data("select nvl(value,-1) from " + user + ".gpb_thongso where id=2").Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    i = -1;
                }
                return i;
            }
        }
        public bool b_capnhatvp
        {
            get
            {
                int i = -1;
                try
                {
                    i = int.Parse(get_data("select nvl(value,-1) from " + user + ".gpb_thongso where id=3").Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    i = -1;
                }
                if (i == 1) return true;
                else return false;
            }
        }
        public bool b_hiendien(long g_maql)
        {
            return get_data("select * from " + user + ".hiendien where nhapkhoa=1 and xuatkhoa=0 and maql=" + g_maql.ToString()).Tables[0].Rows.Count > 0;
        }
        public bool b_nhapkhoa(long g_maql, string g_makp)
        {
            return get_data("select * from " + user + ".nhapkhoa where maql=" + g_maql.ToString() + " and makp='" + g_makp.ToString() + "'").Tables[0].Rows.Count > 0;
        }
        #endregion

        public bool Kiemtratrungma(string sql, string ma)
        {
            try
            {
                con = new NpgsqlConnection(sConn);
                con.Open();
                cmd = new NpgsqlCommand(sql, con);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.GetValue(0).ToString() == ma)
                    {
                        con.Close();
                        return true;
                    }
                }
                con.Close();
            }
            catch (Exception caught)
            {
                MessageBox.Show(caught.Message);
            }
            return false;
        }

        public void OutputCMB(ComboBox Cmb, DataTable tb, string Value, string Display)
        {
            Cmb.Items.Clear();
            try
            {
                Cmb.DataSource = null;
                Cmb.ValueMember = Value.ToUpper();
                Cmb.DisplayMember = Display.ToUpper();
                Cmb.DataSource = tb;
                Cmb.SelectedIndex = -1;
            }
            catch //(Exception ex) 
            {
            }
        }

        public void OutputCMBB(ComboBox Cmb, DataTable tb, string Value, string Display)
        {
            Cmb.ValueMember = Value.ToUpper();
            Cmb.DisplayMember = Display.ToUpper();
            Cmb.DataSource = tb;
            if (Cmb.Items.Count > 0) Cmb.SelectedIndex = 0;
            else Cmb.SelectedIndex = -1;
        }

        /*
        public void Del_XNHMMD1()
        {
            execute_data("delete  from "+user+".GPB_XNHMMD1");
        }

        public void Del_VTST1()
        {
            execute_data("delete  from " + user + ".GPB_VTST1");
        }
        */
        public DataSet Get_DataToanbo(string sql, string table)
        {
            try
            {
                con = new NpgsqlConnection(sConn);
                con.Open();
                cmd = new NpgsqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                dest = new NpgsqlDataAdapter(cmd);
                ds = new DataSet();
                int numrows = dest.Fill(ds, table);
                if (numrows <= 0) { return null; }
                cmd.Dispose();
                con.Dispose();
                return ds;
            }
            catch (Exception caught)
            {
                MessageBox.Show(caught.Message);
            }
            return null;
        }

        public string DateToString(string format, System.DateTime date)
        {
            if (date.Equals(null)) return "";
            else return date.ToString(format, System.Globalization.DateTimeFormatInfo.CurrentInfo);
        }

        public string ngayhienhanh_server
        {
            get
            {
                return get_data("select to_char(now(),'dd/mm/yyyy hh24:mi')").Tables[0].Rows[0][0].ToString();
            }
        }

        public System.DateTime StringToDate(string s)
        {
            s = (s == "") ? ngayhienhanh_server.Substring(0, 10) : s;
            string[] format ={ "dd/MM/yyyy" };
            return System.DateTime.ParseExact(s.ToString().Substring(0, 10), format, System.Globalization.DateTimeFormatInfo.CurrentInfo, System.Globalization.DateTimeStyles.None);
        }
	}
}
