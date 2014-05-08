﻿using System;
using System.Xml;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using Npgsql;
using NpgsqlTypes;

namespace LibVienphi
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class AccessData
	{
        //linh
        string dblink = "";
        //end linh
        public const int i_maxlength_mabn = 8, i_maxlength_makp = 3;
		public const string Msg="Quản lý viện phí";
        public const string Msgng = "Quản lý viện phí ngoài giờ";
		public const string links_userid="links",links_pass="715501920";
        string sConn = "Server=192.168.1.14;Port=5432;User Id=medisoft;Password=links1920;Database=medisoft;Encoding=UNICODE;Pooling=true;";
        NpgsqlDataAdapter dest;
        NpgsqlConnection con;
        NpgsqlCommand cmd;
        string sComputer = null;
        string sql = "", schema="",owner="medisoft",password="links1920",userid = "medibv",database = "medisoft",xxxxx="Ð§Ì©Î«³²°Ô£";
        string sHost = "", sPort = "";//linh 02012013
        DataSet ds = null;
		int iRownum=1;
        LibDuoc.AccessData d = new LibDuoc.AccessData();

		public AccessData()
		{
            //linh 02012013
            string s_Key = Maincode("Key");
            if (s_Key == "1")
            {
                if (Maincode("Ip") != "") sHost = DeCode(Maincode("Ip"), key);
                if (Maincode("Post") != "") sPort = DeCode(Maincode("Post"), key);
                if (Maincode("UserID") != "") owner = DeCode(Maincode("UserID"), key);
                if (Maincode("Password") != "") password = DeCode(Maincode("Password"), key);
                if (Maincode("Database") != "") database = DeCode(Maincode("Database"), key);
            }
            else
            {
                if (Maincode("Ip") != "") sHost = Maincode("Ip");
                if (Maincode("Post") != "") sPort = Maincode("Post");
                if (Maincode("UserID") != "") owner = Maincode("UserID");
                if (Maincode("Password") != "") password = Maincode("Password");
                if (Maincode("Database") != "") database = Maincode("Database");
            }
            if (Maincode("User") != "") userid = Maincode("User");
            //if (Maincode("xxxxx") == "*****") password = decode(xxxxx).ToLower();
            sComputer = System.Environment.MachineName.Trim().ToUpper();
            sConn = "Server=" + sHost + ";Port=" + sPort + ";User Id=" + owner + ";Password=" + password + ";Database=" + database + ";Encoding=UNICODE;Pooling=true;";
			upd_dmcomputer(sComputer);
            ds = get_data("select id,computer from " + userid + ".dmcomputer");
			DataRow r=getrowbyid(ds.Tables[0],"computer='"+sComputer+"'");
            int i_ChiNhanhHienTai = d.i_Chinhanh_hientai;
            if (r != null) iRownum = int.Parse(i_ChiNhanhHienTai.ToString() + r["id"].ToString().PadLeft(5, '0'));//linh 28052012
		}

        #region get_chieudai_mabn_makp
        private int iChieudai_makp
        {
            get
            {
                try
                {
                    int ilen = 2;
                    DataSet ds = get_data("select ten from " + user + ".thongso where id=-98");
                    ilen = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    if (ilen < 2) ilen = 2;
                    else if (ilen > 3) ilen = 3;
                    return ilen;
                }
                catch { return 2; }
            }
        }
        private int iChieudai_mabn
        {
            get
            {
                try
                {
                    int ilen = 8;
                    DataSet ds = get_data("select ten from " + user + ".thongso where id=-99");
                    ilen = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    if (ilen < 8) ilen = 8;
                    else if (ilen > 10) ilen = 10;
                    return ilen;
                }
                catch { return 8; }
            }
        }
        #endregion get_chieudai_mabn_makp
		public string user{get {return userid;}}
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
		public string Thongso(string sql)
		{
			XmlDocument doc=new XmlDocument();
			doc.Load("..//..//..//xml//v_thongso.xml");
			XmlNodeList nodeLst=doc.GetElementsByTagName(sql);
			return nodeLst.Item(0).InnerText;
		}

        public string Thongso(string file,string sql)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("..//..//..//xml//"+file);
            XmlNodeList nodeLst = doc.GetElementsByTagName(sql);
            return nodeLst.Item(0).InnerText;
        }

        public string ngayhienhanh_server
        {
            get
            {
                return get_data("select to_char(now(),'dd/mm/yyyy hh24:mi') as ngay").Tables[0].Rows[0]["ngay"].ToString();
            }
        }

        public string f_ngay
        {
            get
            {
                ds = get_data("select ten from " + user + ".thongso where id=-2");
                if (ds.Tables[0].Rows.Count > 0) return ds.Tables[0].Rows[0]["ten"].ToString().Trim();
                else return "dd/mm/yyyy";
            }
        }

        public void MaskDigit(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == 8) e.Handled = false;
            else e.Handled = true;
        }
        public void MaskDecimal(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == 8) e.Handled = false;
            else e.Handled = true;
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
				return Convert.ToInt64(d1.ToOADate()-d2.ToOADate()+congthem);
			}
			catch{return 0;}
		}
		public bool ngay(DateTime d1,DateTime d2,int so)
		{
			return (Math.Abs(songay(d1,StringToDate(d2.Day.ToString().PadLeft(2,'0')+"/"+d2.Month.ToString().PadLeft(2,'0')+"/"+d2.Year.ToString()),0))<=so);
		}
		public System.DateTime StringToDate(string s)
		{
			string [] format={"dd/MM/yyyy"};
			return System.DateTime.ParseExact(s.Substring(0,10),format,System.Globalization.DateTimeFormatInfo.CurrentInfo,System.Globalization.DateTimeStyles.None);
		}
        public string DateToString(System.DateTime date)
        {
            if (date.Equals(null)) return "";
            else return date.ToString("dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.CurrentInfo);
        }
		private string onlyso(string s)
		{
			string ret="",s1=" 0123456789";
			for(int i=0;i<s.Length;i++)
				if (s1.IndexOf(s.Substring(i,1))!=-1) ret+=s.Substring(i,1);
			return ret;
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

		public string Caps( string s)
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
		public void writeXml(string tenfile,string cot,string s)
		{
			ds=new DataSet();
			ds.ReadXml("..//..//..//xml//"+tenfile+".xml");
			ds.Tables[0].Rows[0][cot]=s;
			ds.WriteXml("..//..//..//xml//"+tenfile+".xml");
		}

		public int iNoitru{get{return 1;}}
		public int iNgoaitru{get{return 2;}}
		public bool bMabn{get{return Thongso("c02")=="1";}}
		public bool bNamsinh{get{return Thongso("c03")=="1";}}
		public bool bDiachi{get{return Thongso("c04")=="1";}}
		public bool bSobienlai{get{return Thongso("c05")=="1";}}
		public bool bPreview{get{return Thongso("c06")=="1";}}
		public int Ngaylv_Ngayht{get{return int.Parse(Thongso("c10"));}}
		public bool bPrintDialog{get{return Thongso("c11")=="1";}}
		public string Ketoantruong{get{return Thongso("c07");}}
        public string Giamdoc { get { return Thongso("c69"); } }
		public string Thuquy{get{return Thongso("c08");}}
		public string Ketoan{get{return Thongso("c09");}}
		public string Mausobienlai{get{return Thongso("c12");}}
		public string Masothue{get{return Thongso("c13");}}
		public string Sotaikhoan{get{return Thongso("c14");}}
		public string Diachi{get{return Thongso("c15");}}
		public bool bSuabienlai{get{return Thongso("c17")=="1";}}
		public bool bKhoaphong
		{
			get
			{
				ds=get_data("select ten from "+user+".v_thongso where id=19");
				if (ds.Tables[0].Rows.Count==0) return false;
				else return ds.Tables[0].Rows[0]["ten"].ToString().Trim()=="1";
			}
		}
		public bool bDangkykhambenh
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=16");
				if (ds.Tables[0].Rows.Count==0) return false;
				else return ds.Tables[0].Rows[0]["ten"].ToString().Trim()=="1";
			}
		}

		public bool bDuyetmien
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=18");
				if (ds.Tables[0].Rows.Count==0) return false;
				else return ds.Tables[0].Rows[0]["ten"].ToString().Trim()=="1";
			}
		}

		public bool bTamung_chitiet
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=20");
				if (ds.Tables[0].Rows.Count==0) return false;
				else return ds.Tables[0].Rows[0]["ten"].ToString().Trim()=="1";
			}
		}

		public bool bHoantra_chitiet
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=21");
				if (ds.Tables[0].Rows.Count==0) return false;
				else return ds.Tables[0].Rows[0]["ten"].ToString().Trim()=="1";
			}
		}

		public bool bThanhtoan_nhieudot
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=22");
				if (ds.Tables[0].Rows.Count==0) return false;
				else return ds.Tables[0].Rows[0]["ten"].ToString().Trim()=="1";
			}
		}

		public bool bNopthem
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=23");
				if (ds.Tables[0].Rows.Count==0) return false;
				else return ds.Tables[0].Rows[0]["ten"].ToString().Trim()=="1";
			}
		}

		public bool bThieu
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=24");
				if (ds.Tables[0].Rows.Count==0) return false;
				else return ds.Tables[0].Rows[0]["ten"].ToString().Trim()=="1";
			}
		}

		public bool bKhoaphongchitiet
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=25");
				if (ds.Tables[0].Rows.Count==0) return false;
				else return ds.Tables[0].Rows[0]["ten"].ToString().Trim()=="1";
			}
		}

		public bool bTonghoptukhoa
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=26");
				if (ds.Tables[0].Rows.Count==0) return false;
				else return ds.Tables[0].Rows[0]["ten"].ToString().Trim()=="1";
			}
		}

		public bool bChinhsuathanhtoan
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=27");
				if (ds.Tables[0].Rows.Count==0) return false;
				else return ds.Tables[0].Rows[0]["ten"].ToString().Trim()=="1";
			}
		}

		public int dongia_le
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=28");
				if (ds.Tables[0].Rows.Count==0) return 0;
				else return int.Parse(ds.Tables[0].Rows[0]["ten"].ToString().Trim());
			}
		}

		public int sotien_le
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=29");
				if (ds.Tables[0].Rows.Count==0) return 0;
				else return int.Parse(ds.Tables[0].Rows[0]["ten"].ToString().Trim());
			}
		}

		public int socot
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=30");
				if (ds.Tables[0].Rows.Count==0) return 2;
				else return int.Parse(ds.Tables[0].Rows[0]["ten"].ToString().Trim());
			}
		}

		public bool bThongtu14
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=31");
				if (ds.Tables[0].Rows.Count==0) return false;
				else return ds.Tables[0].Rows[0]["ten"].ToString().Trim()=="1";
			}
		}

        public bool bThongtu03
        {
            get
            {
                ds = get_data("select ten from " + user + ".v_thongso where id=72");
                if (ds.Tables[0].Rows.Count == 0) return false;
                else return ds.Tables[0].Rows[0]["ten"].ToString().Trim() == "1";
            }
        }

        public bool bBienlai_nhom
        {
            get
            {
                ds = get_data("select ten from " + user + ".v_thongso where id=74");
                if (ds.Tables[0].Rows.Count == 0) return false;
                else return ds.Tables[0].Rows[0]["ten"].ToString().Trim() == "1";
            }
        }

		public bool bTrongoi
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=32");
				if (ds.Tables[0].Rows.Count==0) return false;
				else return ds.Tables[0].Rows[0]["ten"].ToString().Trim()=="1";
			}
		}

		public bool bTamung_ravien
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=33");
				if (ds.Tables[0].Rows.Count==0) return false;
				else return ds.Tables[0].Rows[0]["ten"].ToString().Trim()=="1";
			}
		}

		public bool bDanhsach
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=34");
				if (ds.Tables[0].Rows.Count==0) return false;
				else return ds.Tables[0].Rows[0]["ten"].ToString().Trim()=="1";
			}
		}

		public int Loai1
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=35");
				if (ds.Tables[0].Rows.Count==0) return 380000;
				else return int.Parse(ds.Tables[0].Rows[0]["ten"].ToString().Trim());
			}
		}
		public int Loai1_t
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=36");
				if (ds.Tables[0].Rows.Count==0) return 40000;
				else return int.Parse(ds.Tables[0].Rows[0]["ten"].ToString().Trim());
			}
		}
		public int Loai1_s
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=37");
				if (ds.Tables[0].Rows.Count==0) return 90000;
				else return int.Parse(ds.Tables[0].Rows[0]["ten"].ToString().Trim());
			}
		}
		public int Loai2
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=38");
				if (ds.Tables[0].Rows.Count==0) return 220000;
				else return int.Parse(ds.Tables[0].Rows[0]["ten"].ToString().Trim());
			}
		}
		public int Loai2_t
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=39");
				if (ds.Tables[0].Rows.Count==0) return 40000;
				else return int.Parse(ds.Tables[0].Rows[0]["ten"].ToString().Trim());
			}
		}
		public int Loai2_s
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=40");
				if (ds.Tables[0].Rows.Count==0) return 70000;
				else return int.Parse(ds.Tables[0].Rows[0]["ten"].ToString().Trim());
			}
		}
		public int Loai3
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=41");
				if (ds.Tables[0].Rows.Count==0) return 150000;
				else return int.Parse(ds.Tables[0].Rows[0]["ten"].ToString().Trim());
			}
		}
		public int Loai3_t
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=42");
				if (ds.Tables[0].Rows.Count==0) return 40000;
				else return int.Parse(ds.Tables[0].Rows[0]["ten"].ToString().Trim());
			}
		}
		public int Loai3_s
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=43");
				if (ds.Tables[0].Rows.Count==0) return 60000;
				else return int.Parse(ds.Tables[0].Rows[0]["ten"].ToString().Trim());
			}
		}
		public int Tienkhac
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=44");
				if (ds.Tables[0].Rows.Count==0) return 5000;
				else return int.Parse(ds.Tables[0].Rows[0]["ten"].ToString().Trim());
			}
		}
		public int Songaysaumo
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=45");
				if (ds.Tables[0].Rows.Count==0) return 11;
				else return int.Parse(ds.Tables[0].Rows[0]["ten"].ToString().Trim());
			}
		}
		public int Nhom_pttt
		{
			get
			{
				try
				{
                    ds = get_data("select ten from " + user + ".v_thongso where id=46");
					if (ds.Tables[0].Rows.Count==0) return 0;
					else return int.Parse(ds.Tables[0].Rows[0]["ten"].ToString().Trim());
				}
				catch{return 0;}
			}
		}
		public int Nhom_giuong
		{
			get
			{
				try
				{
                    ds = get_data("select ten from " + user + ".v_thongso where id=47");
					if (ds.Tables[0].Rows.Count==0) return 0;
					else return int.Parse(ds.Tables[0].Rows[0]["ten"].ToString().Trim());
				}
				catch{return 0;}
			}
		}
		public int Nhom_khac
		{
			get
			{
				try
				{
                    ds = get_data("select ten from " + user + ".v_thongso where id=48");
					if (ds.Tables[0].Rows.Count==0) return 0;
					else return int.Parse(ds.Tables[0].Rows[0]["ten"].ToString().Trim());
				}
				catch{return 0;}
			}
		}
		public int Songay_trongoi
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=49");
				if (ds.Tables[0].Rows.Count==0) return 5;
				else return int.Parse(ds.Tables[0].Rows[0]["ten"].ToString().Trim());
			}
		}
		public int Chenhlech_trongoi
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=50");
				if (ds.Tables[0].Rows.Count==0) return 20000;
				else return int.Parse(ds.Tables[0].Rows[0]["ten"].ToString().Trim());
			}
		}
		public int Nhom_thuoc
		{
			get
			{
				try
				{
                    ds = get_data("select ten from " + user + ".v_thongso where id=51");
					if (ds.Tables[0].Rows.Count==0) return 0;
					else return int.Parse(ds.Tables[0].Rows[0]["ten"].ToString().Trim());
				}
				catch{return 0;}
			}
		}
		public int Nhom_trongoi
		{
			get
			{
				try
				{
                    ds = get_data("select ten from " + user + ".v_thongso where id=56");
					if (ds.Tables[0].Rows.Count==0) return 0;
					else return int.Parse(ds.Tables[0].Rows[0]["ten"].ToString().Trim());
				}
				catch{return 0;}
			}
		}
		public int Nhom_phongdv
		{
			get
			{
				try
				{
                    ds = get_data("select ten from " + user + ".v_thongso where id=57");
					if (ds.Tables[0].Rows.Count==0) return 0;
					else return int.Parse(ds.Tables[0].Rows[0]["ten"].ToString().Trim());
				}
				catch{return 0;}
			}
		}
		public int Nhom_vtth
		{
			get
			{
				try
				{
                    ds = get_data("select ten from " + user + ".v_thongso where id=58");
					if (ds.Tables[0].Rows.Count==0) return 0;
					else return int.Parse(ds.Tables[0].Rows[0]["ten"].ToString().Trim());
				}
				catch{return 0;}
			}
		}
		public int Nhom_lydothu
		{
			get
			{
				try
				{
                    ds = get_data("select ten from " + user + ".v_thongso where id=59");
					if (ds.Tables[0].Rows.Count==0) return 0;
					else return int.Parse(ds.Tables[0].Rows[0]["ten"].ToString().Trim());
				}
				catch{return 0;}
			}
		}
		public int Giuong_khoanhi
		{
			get
			{
				try
				{
                    ds = get_data("select ten from " + user + ".v_thongso where id=60");
					if (ds.Tables[0].Rows.Count==0) return 0;
					else return int.Parse(ds.Tables[0].Rows[0]["ten"].ToString().Trim());
				}
				catch{return 0;}
			}
		}
		public int Giuong_loai1
		{
			get
			{
				try
				{
                    ds = get_data("select ten from " + user + ".v_thongso where id=61");
					if (ds.Tables[0].Rows.Count==0) return 0;
					else return int.Parse(ds.Tables[0].Rows[0]["ten"].ToString().Trim());
				}
				catch{return 0;}
			}
		}
		public string makp_nhi
		{
			get
			{
				try
				{
                    ds = get_data("select ten from " + user + ".v_thongso where id=62");
					if (ds.Tables[0].Rows.Count==0) return "02";
					else return ds.Tables[0].Rows[0]["ten"].ToString().Trim();
				}
				catch{return "02";}
			}
		}
		public int Nhom_mien
		{
			get
			{
				try
				{
					ds=get_data("select ten from "+user+".v_thongso where id=63");
					if (ds.Tables[0].Rows.Count==0) return 0;
					else return int.Parse(ds.Tables[0].Rows[0]["ten"].ToString().Trim());
				}
				catch{return 0;}
			}
		}
		public int Doituong_bienlairieng
		{
			get
			{
				try
				{
                    ds = get_data("select ten from " + user + ".v_thongso where id=64");
					if (ds.Tables[0].Rows.Count==0) return 0;
					else return int.Parse(ds.Tables[0].Rows[0]["ten"].ToString().Trim());
				}
				catch{return 0;}
			}
		}

        public int iNhomxn
        {
            get
            {
                try
                {
                    ds = get_data("select ten from " + user + ".v_thongso where id=87");
                    if (ds.Tables[0].Rows.Count == 0) return 0;
                    else return int.Parse(ds.Tables[0].Rows[0]["ten"].ToString().Trim());
                }
                catch { return 0; }
            }
        }

        public string path_filexn
        {
            get
            {
                try
                {
                    return get_data("select ten from " + user + ".v_thongso where id=88").Tables[0].Rows[0]["ten"].ToString().Trim();
                }
                catch { return ""; }
            }
        }

		public bool bBHYT_khaibao
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=52");
				if (ds.Tables[0].Rows.Count==0) return false;
				else return ds.Tables[0].Rows[0]["ten"].ToString().Trim()=="1";
			}
		}
		public bool bMien_tructiep
		{
			get
			{
                return Thongso("c53") == "1";
			}
		}
        public bool bThieu_tructiep
        {
            get
            {
                ds = get_data("select ten from " + user + ".v_thongso where id=76");
                if (ds.Tables[0].Rows.Count == 0) return false;
                else return ds.Tables[0].Rows[0]["ten"].ToString().Trim() == "1";
            }
        }
        public bool bSuagia_tructiep
        {
            get
            {
                return Thongso("c77") == "1";
            }
        }
        public bool bChon_grid
        {
            get
            {
                return Thongso("c79") == "1";
            }
        }
        public bool bHoten
        {
            get
            {
                return Thongso("c81") == "1";
            }
        }
        public bool bGioitinh
        {
            get
            {
                return Thongso("c82") == "1";
            }
        }
        public bool bInIDVP
        {
            get
            {
                return Thongso("c85") == "1";
            }
        }
        public bool bChon_tab
        {
            get
            {
                return Thongso("c86") == "1";
            }
        }
        public bool bSoluong_1
        {
            get
            {
                ds = get_data("select ten from " + user + ".v_thongso where id=78");
                if (ds.Tables[0].Rows.Count == 0) return false;
                else return ds.Tables[0].Rows[0]["ten"].ToString().Trim() == "1";
            }
        }
        public bool bMabn_tudong
        {
            get
            {
                ds = get_data("select ten from " + user + ".v_thongso where id=80");
                if (ds.Tables[0].Rows.Count == 0) return false;
                else return ds.Tables[0].Rows[0]["ten"].ToString().Trim() == "1";
            }
        }
        public bool bQuanly_Bienlai
        {
            get
            {
                ds = get_data("select ten from " + user + ".v_thongso where id=83");
                if (ds.Tables[0].Rows.Count == 0) return false;
                else return ds.Tables[0].Rows[0]["ten"].ToString().Trim() == "1";
            }
        }
        public bool bDone_Kohoantra
        {
            get
            {
                ds = get_data("select ten from " + user + ".v_thongso where id=84");
                if (ds.Tables[0].Rows.Count == 0) return false;
                else return ds.Tables[0].Rows[0]["ten"].ToString().Trim() == "1";
            }
        }
		public bool bTenvp_tructiep
		{
			get
			{
                return Thongso("c54") == "1";
			}
		}
		public bool bLoc_kyhieu
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=55");
				if (ds.Tables[0].Rows.Count==0) return false;
				else return ds.Tables[0].Rows[0]["ten"].ToString().Trim()=="1";
			}
		}
		public bool bMasothue{get{return Thongso("c65")=="1";}}
        public bool bGhichu { get { return Thongso("c70") == "1"; } }
        public bool bChidinh { get { return Thongso("c71") == "1"; } }
        public bool bInmavach { get { return Thongso("c73") == "1"; } }
        public bool bHienthigotat { get { return Thongso("c75") == "1"; } }
		public bool bLoad_ravien
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=66");
				if (ds.Tables[0].Rows.Count==0) return false;
				else return ds.Tables[0].Rows[0]["ten"].ToString().Trim()=="1";
			}
		}
		public bool bBienlaittvp_doc
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=67");
				if (ds.Tables[0].Rows.Count==0) return false;
				else return ds.Tables[0].Rows[0]["ten"].ToString().Trim()=="1";
			}
		}
		public bool bSotien_hoantra
		{
			get
			{
                ds = get_data("select ten from " + user + ".v_thongso where id=68");
				if (ds.Tables[0].Rows.Count==0) return false;
				else return ds.Tables[0].Rows[0]["ten"].ToString().Trim()=="1";
			}
		}
		public string format_sotien
		{
			get
			{
				string ret="###,###,###,##0";
				int n=(sotien_le<0)?0:sotien_le;
				if (n>0) ret+=".";
				for(int i=0;i<n;i++) ret+="0";
				return ret;
			}
		}

		public string format_dongia
		{
			get
			{
				string ret="###,###,###,##0";
				int n=(dongia_le<0)?0:dongia_le;
				if (n>0) ret+=".";
				for(int i=0;i<n;i++) ret+="0";
				return ret;
			}
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
                ds = new DataSet();
                if (con != null)
                {
                    con.Close(); con.Dispose();
                }
                con = new NpgsqlConnection(sConn);
				con.Open();
				cmd=new NpgsqlCommand(sql,con);
				cmd.CommandType=CommandType.Text;
				dest=new NpgsqlDataAdapter(cmd);				
				dest.Fill(ds);	
				cmd.Dispose();				
				con.Close(); con.Dispose();
			}
			catch(NpgsqlException ex)
			{
				upd_error(ex.Message.ToString().Trim()+"-SQL: "+sql,sComputer,"?");
			}
			return ds;
		}

		public void execute_data(string  sql)
		{
			try
            {
                if (con != null)
                {
                    con.Close(); con.Dispose();
                }
            
				con=new NpgsqlConnection(sConn);
				con.Open();
				cmd=new NpgsqlCommand(sql,con);
				cmd.CommandType=CommandType.Text;
				cmd.ExecuteNonQuery();
				cmd.Dispose();
				con.Close(); con.Dispose();
			}
			catch(NpgsqlException ex)
			{
                upd_error(ex.Message.ToString().Trim() + "-SQL: " + sql, sComputer, "?");
			}
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

        public void upd_error_mmyy(string m_mmyy,string m_message, string m_computer, string m_table)
        {
            sql = "insert into " + user + m_mmyy + ".v_error(message,computer,tables) values (:m_message,:m_computer,:m_table)";
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

        public void upd_error(string m_ngay,string m_message, string m_computer, string m_table)
        {
            sql = "insert into " + user+mmyy(m_ngay) + ".v_error(message,computer,tables) values (:m_message,:m_computer,:m_table)";
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

		public void upd_error(string m_message,string m_computer,string m_table)
		{
			sql="insert into "+user+".v_error(message,computer,tables) values (:m_message,:m_computer,:m_table)";
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
                cmd.Parameters.Add("m_message", NpgsqlDbType.Text).Value = m_message;
                cmd.Parameters.Add("m_computer", NpgsqlDbType.Varchar, 20).Value = m_computer;
                cmd.Parameters.Add("m_table", NpgsqlDbType.Varchar, 20).Value = m_table;
				cmd.ExecuteNonQuery();
			}
			catch{}
			finally
			{
				cmd.Dispose();
				con.Close(); con.Dispose();
			}
		}

		public void updrec (DataTable dt,decimal id,string userid,string password,string right,string loaivp,string mucvp,string loai,string madoituong,int admin)
		{
			string exp="id="+id;
			DataRow r = getrowbyid (dt,exp); 
			if ( r == null )
			{
				DataRow nrow = dt.NewRow ( ) ;
				nrow[0] = id;
				nrow[2] = userid;
				nrow[3] = password;
				nrow[4] = right;
				nrow["loaivp"] = loaivp;
				nrow["mucvp"]=mucvp;
				nrow["loai"]=loai;
				nrow["madoituong"]=madoituong;
				nrow["admin"]=admin;
				dt.Rows.Add ( nrow ) ;
			}
			else
			{
				DataRow[] dr = dt.Select(exp);
				dr[0][4] = right;
				dr[0]["loaivp"] = loaivp;
				dr[0]["mucvp"]=mucvp;
				dr[0]["loai"]=loai;
				dr[0]["madoituong"]=madoituong;
				dr[0]["admin"]=admin;
			}
		}

		public void updrec_right(DataTable dt,decimal id,string right)
		{
			string exp="id="+id;
			DataRow r = getrowbyid (dt,exp); 
			if ( r == null )
			{
				DataRow nrow = dt.NewRow ( ) ;
				nrow[0] = id;
				nrow[4] = right;
				dt.Rows.Add ( nrow ) ;
			}
			else
			{
				DataRow[] dr = dt.Select(exp);
				dr[0][4] = right;
			}
		}
		public void updrec_loaivp(DataTable dt,decimal id,string loaivp,string mucvp,string loai,string madoituong,int admin)
		{
			string exp="id="+id;
			DataRow r = getrowbyid (dt,exp); 
			if ( r == null )
			{
				DataRow nrow = dt.NewRow ( ) ;
				nrow["id"] = id;
				nrow["loaivp"] = loaivp;
				nrow["mucvp"] = mucvp;
				nrow["loai"]=loai;
				nrow["madoituong"]=madoituong;
				nrow["admin"]=admin;
				dt.Rows.Add ( nrow ) ;
			}
			else
			{
				DataRow[] dr = dt.Select(exp);
				dr[0]["loaivp"] = loaivp;
				dr[0]["mucvp"] = mucvp;
				dr[0]["loai"]=loai;
				dr[0]["madoituong"]=madoituong;
				dr[0]["admin"]=admin;
			}
		}

		public void updrec_vienphill(DataTable dt,decimal id,decimal maql,decimal idkhoa,decimal quyenso,decimal sobienlai,string mabn,string hoten,int phai,string namsinh,string diachi,int loai,string sohieu,string makp,int loaibn,string sothe,int maphu,decimal st_mien,string ghichu,int maduyet,string masothue,int userid)
		{
			string exp="id="+id;
			DataRow r = getrowbyid (dt,exp); 
			if ( r == null )
			{
				DataRow nrow = dt.NewRow ( ) ;
				nrow["id"]=id;
				nrow["maql"]=maql;
				nrow["idkhoa"]=idkhoa;
				nrow["quyenso"]=quyenso;
				nrow["sobienlai"]=sobienlai;
				nrow["mabn"]=mabn;
				nrow["hoten"]=hoten;
                nrow["phai"] = phai;
				nrow["namsinh"]=namsinh;
				nrow["diachi"]=diachi;
				nrow["loai"]=loai;
				nrow["sohieu"]=sohieu;
				nrow["makp"]=makp;
				nrow["loaibn"]=loaibn;
				nrow["sothe"]=sothe;
                nrow["masothue"] = masothue;
				nrow["maphu"]=maphu;
				nrow["lanin"]=0;
				nrow["st_mien"]=st_mien;
				nrow["ghichu"]=ghichu;
				nrow["maduyet"]=maduyet;
                nrow["userid"] = userid;
				dt.Rows.Add ( nrow ) ;
			}
			else
			{
				DataRow[] dr = dt.Select(exp);
				dr[0]["id"]=id;
				dr[0]["maql"]=maql;
				dr[0]["idkhoa"]=idkhoa;
				dr[0]["quyenso"]=quyenso;
				dr[0]["sobienlai"]=sobienlai;
				dr[0]["mabn"]=mabn;
				dr[0]["hoten"]=hoten;
                dr[0]["phai"] = phai;
				dr[0]["namsinh"]=namsinh;
				dr[0]["diachi"]=diachi;
				dr[0]["loai"]=loai;
				dr[0]["sohieu"]=sohieu;
				dr[0]["makp"]=makp;
				dr[0]["loaibn"]=loaibn;
				dr[0]["sothe"]=sothe;
                dr[0]["masothue"] = masothue;
				dr[0]["maphu"]=maphu;
				dr[0]["st_mien"]=st_mien;
				dr[0]["ghichu"]=ghichu;
				dr[0]["maduyet"]=maduyet;
                dr[0]["userid"] = userid;
			}
		}

		public void updrec_vienphill_tg(DataTable dt,decimal id,decimal maql,decimal idkhoa,decimal quyenso,decimal sobienlai,string mabn,string hoten,string namsinh,string diachi,int loai,string sohieu,string makp,int loaibn,string sothe,int maphu,decimal sotien,decimal tamung,decimal hoantra,int pm,int yc,string ghichu,string diengiai,string mavp)
		{
			string exp="id="+id;
			DataRow r = getrowbyid (dt,exp); 
			if ( r == null )
			{
				DataRow nrow = dt.NewRow ( ) ;
				nrow["id"]=id;
				nrow["maql"]=maql;
				nrow["idkhoa"]=idkhoa;
				nrow["quyenso"]=quyenso;
				nrow["sobienlai"]=sobienlai;
				nrow["mabn"]=mabn;
				nrow["hoten"]=hoten;
				nrow["namsinh"]=namsinh;
				nrow["diachi"]=diachi;
				nrow["loai"]=loai;
				nrow["sohieu"]=sohieu;
				nrow["makp"]=makp;
				nrow["loaibn"]=loaibn;
				nrow["sothe"]=sothe;
				nrow["maphu"]=maphu;
				nrow["lanin"]=0;
				nrow["sotien"]=sotien;
				nrow["tamung"]=tamung;
				nrow["hoantra"]=hoantra;
				nrow["ghichu"]=ghichu;
				nrow["diengiai"]=diengiai;
				nrow["mavp"]=mavp;
				nrow["pm"]=pm;
				nrow["yc"]=yc;
				dt.Rows.Add ( nrow ) ;
			}
			else
			{
				DataRow[] dr = dt.Select(exp);
				dr[0]["id"]=id;
				dr[0]["maql"]=maql;
				dr[0]["idkhoa"]=idkhoa;
				dr[0]["quyenso"]=quyenso;
				dr[0]["sobienlai"]=sobienlai;
				dr[0]["mabn"]=mabn;
				dr[0]["hoten"]=hoten;
				dr[0]["namsinh"]=namsinh;
				dr[0]["diachi"]=diachi;
				dr[0]["loai"]=loai;
				dr[0]["sohieu"]=sohieu;
				dr[0]["makp"]=makp;
				dr[0]["loaibn"]=loaibn;
				dr[0]["sothe"]=sothe;
				dr[0]["maphu"]=maphu;
				dr[0]["sotien"]=sotien;
				dr[0]["tamung"]=tamung;
				dr[0]["hoantra"]=hoantra;
				dr[0]["ghichu"]=ghichu;
				dr[0]["diengiai"]=diengiai;
				dr[0]["mavp"]=mavp;
				dr[0]["pm"]=pm;
				dr[0]["yc"]=yc;
			}
		}

        public void updrec_vienphict_chon(DataTable dt,int stt, string doituong, int madoituong, decimal mavp, string ma, string tenvp, string dvt, decimal soluong, decimal dongia, decimal mien, decimal thieu, decimal vattu, string mabs, string makp, string diengiai,int userid,string tenuser)
        {
            string exp = "userid="+userid+" and stt=" + stt;
            DataRow r = getrowbyid(dt, exp);
            if (r == null)
            {
                DataRow nrow = dt.NewRow();
                nrow["stt"] = stt;
                nrow["doituong"] = doituong;
                nrow["madoituong"] = madoituong;
                nrow["mavp"] = mavp;
                nrow["ma"] = ma;
                nrow["tenvp"] = tenvp;
                nrow["dvt"] = dvt;
                nrow["soluong"] = soluong;
                nrow["dongia"] = dongia;
                nrow["mien"] = mien;
                nrow["thieu"] = thieu;
                nrow["vattu"] = vattu;
                nrow["thucthu"] = soluong * dongia + soluong * vattu - mien - thieu;
                nrow["mabs"] = mabs;
                nrow["makp"] = makp;
                nrow["diengiai"] = diengiai;
                nrow["tra"] = 0;
                nrow["lanin"] = 0;
                nrow["chon"] = true;
                nrow["userid"] = userid;
                nrow["tenuser"] = tenuser;
                dt.Rows.Add(nrow);
            }
            else
            {
                DataRow[] dr = dt.Select(exp);
                dr[0]["madoituong"] = madoituong;
                dr[0]["doituong"] = doituong;
                dr[0]["mavp"] = mavp;
                dr[0]["ma"] = ma;
                dr[0]["tenvp"] = tenvp;
                dr[0]["dvt"] = dvt;
                dr[0]["mavp"] = mavp;
                dr[0]["soluong"] = soluong;
                dr[0]["dongia"] = dongia;
                dr[0]["mien"] = mien;
                dr[0]["thieu"] = thieu;
                dr[0]["vattu"] = vattu;
                dr[0]["thucthu"] = soluong * dongia + soluong * vattu - mien - thieu;
                dr[0]["mabs"] = mabs;
                dr[0]["makp"] = makp;
                dr[0]["diengiai"] = diengiai;
                dr[0]["userid"] = userid;
                dr[0]["tenuser"] = tenuser;
            }
        }

        public void updrec_vienphict(DataTable dt, int stt, string doituong, int madoituong, decimal mavp, string ma, string tenvp, string dvt, decimal soluong, decimal dongia, decimal mien, decimal thieu, decimal vattu, string mabs, string makp, string diengiai, int userid, string tenuser,decimal id)
        {
            string exp = "userid=" + userid + " and stt=" + stt;
            DataRow r = getrowbyid(dt, exp);
            if (r == null)
            {
                DataRow nrow = dt.NewRow();
                nrow["stt"] = stt;
                nrow["doituong"] = doituong;
                nrow["madoituong"] = madoituong;
                nrow["mavp"] = mavp;
                nrow["ma"] = ma;
                nrow["tenvp"] = tenvp;
                nrow["dvt"] = dvt;
                nrow["soluong"] = soluong;
                nrow["dongia"] = dongia;
                nrow["mien"] = mien;
                nrow["thieu"] = thieu;
                nrow["vattu"] = vattu;
                nrow["thucthu"] = soluong * dongia + soluong * vattu - mien - thieu;
                nrow["mabs"] = mabs;
                nrow["makp"] = makp;
                nrow["diengiai"] = diengiai;
                nrow["tra"] = 0;
                nrow["lanin"] = 0;
                nrow["chon"] = true;
                nrow["userid"] = userid;
                nrow["tenuser"] = tenuser;
                nrow["id"] = id;
                dt.Rows.Add(nrow);
            }
            else
            {
                DataRow[] dr = dt.Select(exp);
                dr[0]["madoituong"] = madoituong;
                dr[0]["doituong"] = doituong;
                dr[0]["mavp"] = mavp;
                dr[0]["ma"] = ma;
                dr[0]["tenvp"] = tenvp;
                dr[0]["dvt"] = dvt;
                dr[0]["mavp"] = mavp;
                dr[0]["soluong"] = soluong;
                dr[0]["dongia"] = dongia;
                dr[0]["mien"] = mien;
                dr[0]["thieu"] = thieu;
                dr[0]["vattu"] = vattu;
                dr[0]["thucthu"] = soluong * dongia + soluong * vattu - mien - thieu;
                dr[0]["mabs"] = mabs;
                dr[0]["makp"] = makp;
                dr[0]["diengiai"] = diengiai;
                dr[0]["userid"] = userid;
                dr[0]["tenuser"] = tenuser;
                dr[0]["id"] = id;
            }
        }

		public void updrec_vienphict(DataTable dt,int stt,string doituong,int madoituong,decimal mavp,string ma,string tenvp,string dvt,decimal soluong,decimal dongia,decimal mien,decimal thieu,decimal vattu,string mabs,string makp,string diengiai)
		{
			string exp="stt="+stt;
			DataRow r = getrowbyid (dt,exp); 
			if ( r == null )
			{
				DataRow nrow = dt.NewRow ( ) ;
				nrow["stt"]=stt;
				nrow["doituong"]=doituong;
				nrow["madoituong"]=madoituong;
				nrow["mavp"]=mavp;
				nrow["ma"]=ma;
				nrow["tenvp"]=tenvp;
				nrow["dvt"]=dvt;
				nrow["soluong"]=soluong;
				nrow["dongia"]=dongia;
				nrow["mien"]=mien;
				nrow["thieu"]=thieu;
				nrow["vattu"]=vattu;
				nrow["thucthu"]=soluong*dongia+soluong*vattu-mien-thieu;
				nrow["mabs"]=mabs;
				nrow["makp"]=makp;
				nrow["diengiai"]=diengiai;
				dt.Rows.Add ( nrow ) ;
			}
			else
			{
				DataRow[] dr = dt.Select(exp);
				dr[0]["madoituong"]=madoituong;
				dr[0]["doituong"]=doituong;
				dr[0]["mavp"]=mavp;
				dr[0]["ma"]=ma;
				dr[0]["tenvp"]=tenvp;
				dr[0]["dvt"]=dvt;
				dr[0]["mavp"]=mavp;
				dr[0]["soluong"]=soluong;
				dr[0]["dongia"]=dongia;
				dr[0]["mien"]=mien;
				dr[0]["thieu"]=thieu;
				dr[0]["vattu"]=vattu;
				dr[0]["thucthu"]=soluong*dongia+soluong*vattu-mien-thieu;
				dr[0]["mabs"]=mabs;
				dr[0]["makp"]=makp;
				dr[0]["diengiai"]=diengiai;
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

		public void upd_dmcomputer(string m_computer)
		{
                      
            bool bnew = true;
            DataSet ads = get_data("select id, computer from " + user + ".dmcomputer where computer='" + m_computer + "'");
            if (ads != null && ads.Tables.Count > 0 && ads.Tables[0].Rows.Count > 0)
            {
                bnew = false;
            }
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            try
            {
                if (bnew == false)
                {
                //    sql = "update " + user + ".dmcomputer set computer=:m_computer where computer=:m_computer";

                //    con = new NpgsqlConnection(sConn);

                //    con.Open();
                //    cmd = new NpgsqlCommand(sql, con);
                //    cmd.CommandType = CommandType.Text;
                //    cmd.Parameters.Add("m_computer", NpgsqlDbType.Varchar, 20).Value = m_computer;
                //    int irec = cmd.ExecuteNonQuery();
                //    cmd.Dispose();
                //    con.Close(); con.Dispose();
                }
                else 
				{
                    sql = "insert into " + user + ".dmcomputer(id,computer) values (" + get_id_dmcomputer + ",'" + m_computer + "')";
                    execute_data(sql);
				}
			}
			catch(NpgsqlException ex)
			{
				upd_error(ex.Message,sComputer,"dmcomputer");
			}
			finally
			{
				con.Close(); con.Dispose();
			}		
		}

		/*		
				1 : quyenso
				2 : loaivp
				3 : giavp
				4 : dlogin
				5 : vienphi
				6 : tamung
				7 : nhomvp
				8 : hoantra
				9 : chidinh
				10: thanh toan ra vien
				11: vp khoa
				12: phieu chi
				13: tong hop vien phi
		*/
		public decimal get_id_quyenso{get{return get_capid(1);}}
		public decimal get_id_loaivp{get{return get_capid(2);}}
		public decimal get_id_giavp{get{return get_capid("d_capid",1);}}
		public decimal get_id_dlogin{get{return get_capid_medi(-30,"capid");}}
        public decimal get_id_vienphi
        {
            get
            {
                return getidyymmddhhmiss_stt_computer;// decimal.Parse(iRownum.ToString().PadLeft(3, '0') + get_capid_may(5, sComputer).ToString().PadLeft(9, '0'));
        }}
        public decimal get_id_tamung
        {
            get
            {
                return getidyymmddhhmiss_stt_computer;//decimal.Parse(iRownum.ToString().PadLeft(3,'0')+get_capid_may(6,sComputer).ToString().PadLeft(9,'0'));
        }}
		public decimal get_id_nhomvp{get{return get_capid(7);}}
		public decimal get_id_nhombhyt{get{return get_capid(14);}}
        public decimal get_id_hoantra
        {
            get
            {
                return getidyymmddhhmiss_stt_computer;//decimal.Parse(iRownum.ToString().PadLeft(3,'0')+get_capid_may(8,sComputer).ToString().PadLeft(9,'0'));
        }}
        public decimal get_id_chidinh
        {
            get
            {
                return getidyymmddhhmiss_stt_computer;//decimal.Parse(iRownum.ToString().PadLeft(3,'0')+get_capid_may(9,sComputer).ToString().PadLeft(9,'0'));
                //return decimal.Parse(getyymmdd() + get_capid_may(9, sComputer).ToString().PadLeft(9, '0') + iRownum.ToString().PadLeft(3, '0'));
            }
        }
        public decimal get_id_chidinhll
        {
            get
            {
                return getidyymmddhhmiss_stt_computer;//decimal.Parse(iRownum.ToString().PadLeft(3, '0') + get_capid_may(-9, sComputer).ToString().PadLeft(9, '0')); 
        } }
        public decimal get_id_thanhtoanravien
        {
            get
            {
                return getidyymmddhhmiss_stt_computer;//decimal.Parse(iRownum.ToString().PadLeft(3,'0')+get_capid_may(10,sComputer).ToString().PadLeft(9,'0'));
        }}
        public decimal get_id_vpkhoa
        {
            get
            {
                return getidyymmddhhmiss_stt_computer;//decimal.Parse(iRownum.ToString().PadLeft(3,'0')+get_capid_may(11,sComputer).ToString().PadLeft(9,'0'));
                //return decimal.Parse(getyymmdd() + get_capid_may(11, sComputer).ToString().PadLeft(9, '0') + iRownum.ToString().PadLeft(3, '0'));
            }
        }
        public decimal get_id_phieuchi
        {
            get
            {
                return getidyymmddhhmiss_stt_computer;//decimal.Parse(iRownum.ToString().PadLeft(3,'0')+get_capid_may(12,sComputer).ToString().PadLeft(9,'0'));
        }}
		public int get_lanin_tructiep(string ngay,decimal v_id){return get_lanin(mmyy(ngay)+".v_vienphill",v_id);}
        public decimal get_id_thvp()
        {
            return getidyymmddhhmiss_stt_computer;//decimal.Parse(iRownum.ToString().PadLeft(3,'0')+get_capid_may(13,sComputer).ToString().PadLeft(9,'0'));
        }
		public decimal get_id_thvp(string ngay,string mabn,decimal maql,decimal idkhoa,string ngayvao)
		{
            //if (bMmyy(mmyy(ngay)))
            //{
				sql="select id from xxx.v_thvpll where mabn='"+mabn+"' and to_char(ngayvao,'dd/mm/yyyy hh24:mi')='"+ngayvao+"'";
				if (idkhoa!=0) sql+=" and idkhoa="+idkhoa;
				else sql+=" and maql="+maql;
                sql += " and done=0";
				ds=get_data_mmyy(sql,ngayvao,ngay,true);
				if (ds.Tables[0].Rows.Count>0) return decimal.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				else return 0;
            //}
			return 0;
		}
        //Thuy 07.03.2012 get_id theo ngay ra, thay vi truoc day lay ngay vao -> sai truong hop tach thanh nhieu dot
        public string get_id_thvp(string mabn, decimal maql, decimal idkhoa, string ngayra, string ngayserver)
        {
            DateTime dt1 = StringToDate(ngayserver).AddMonths(-1);//.AddDays(-d.iNgaykiemke);
            DateTime dt2 = StringToDate(ngayserver);
            int y1 = dt1.Year, m1 = dt1.Month;
            int y2 = dt2.Year, m2 = dt2.Month;
            int itu, iden;
            string mmyy = "";
            decimal id = 0;
            for (int i = y1; i <= y2; i++)
            {
                itu = (i == y1) ? m1 : 1;
                iden = (i == y2) ? m2 : 12;
                for (int j = itu; j <= iden; j++)
                {
                    mmyy = j.ToString().PadLeft(2, '0') + i.ToString().Substring(2, 2);
                    if (bMmyy(mmyy))
                    {
                        sql = "select id from "+user+mmyy+".v_thvpll where mabn='" + mabn + "'";
                        if (idkhoa != 0)
                        {
                            sql += " and idkhoa=" + idkhoa;
                            sql += " and to_char(ngayra,'dd/mm/yyyy hh24:mi')='" + ngayra + "'";
                        }
                        else
                        {
                            sql += " and maql=" + maql;
                            sql += " and to_char(ngayra,'dd/mm/yyyy')='" + ngayra.Substring(0,10) + "'";
                        }
                        sql += " and done=0";
                        ds = get_data(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            id = decimal.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                            break;
                        }
                    }
                }
            }
            return (id == 0) ? "" : id.ToString().Trim();
        }

		public bool get_done_thvp(string ngay,string mabn,decimal maql,decimal idkhoa,string ngayvao,bool ngayra)
		{
            if (ngayvao.Trim().Length < 10) return false;
			if (bMmyy(mmyy(ngay)))
			{
				sql="select done from "+user+mmyy(ngay)+".v_thvpll where mabn='"+mabn+"'";
                if (idkhoa != 0)
                {
                    sql += " and idkhoa=" + idkhoa;
                    sql += " and to_char(ngayvao,'dd/mm/yyyy hh24:mi')='" + ngayvao + "'";
                }
                else
                {
                    sql += " and maql=" + maql;
                    sql += " and to_char(ngayvao,'dd/mm/yyyy')='" + ngayvao.Substring(0,10) + "'";
                }
                if (ngayra) sql += " and to_char(ngayra,'dd/mm/yyyy hh24:mi')='" + ngayra + "'";
				ds=get_data(sql);
				if (ds.Tables[0].Rows.Count>0) return ds.Tables[0].Rows[0]["done"].ToString()=="1";
				else return false;
			}
			return false;
		}

        public string get_thvp_idttrv(string ngay, string mabn, decimal maql, decimal idkhoa, string ngayvao, bool ngayra)
        {
            string s_idttrv = "";
            if (bMmyy(mmyy(ngay)))
            {
                sql = "select idttrv from " + user + mmyy(ngay) + ".v_thvpll where mabn='" + mabn + "' and idttrv>0";
                if (idkhoa != 0)
                {
                    sql += " and idkhoa=" + idkhoa;
                    sql += " and to_char(ngayvao,'dd/mm/yyyy hh24:mi')='" + ngayvao + "'";
                }
                else
                {
                    sql += " and maql=" + maql;
                    sql += " and to_char(ngayvao,'dd/mm/yyyy')='" + ngayvao.Substring(0, 10) + "'";
                }
                if (ngayra) sql += " and to_char(ngayra,'dd/mm/yyyy hh24:mi')='" + ngayra + "'";
                ds = get_data(sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (s_idttrv.IndexOf(dr["idttrv"].ToString() + ",") < 0) s_idttrv += dr["idttrv"].ToString() + ",";
                }                
            }
            return s_idttrv.Trim().Trim(',');
        }
        public DataSet  get_sobienlai_ttrv(string s_id,string ngayvao, string ngayra)
        {
            DataSet lds = new DataSet();
            sql = "select quyenso, sobienlai, id from xxx.v_ttrvll where id in(" + s_id.Trim().Trim(',') + ")";
            return get_data_mmyy(sql, ngayvao, ngayra, true);
        }
        public DataSet get_data_mmyy(string str, string tu, string den, bool khoangcach)
        {
            DataSet tmp = new DataSet();
            
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
                        sql = str.Replace("xxx", user + mmyy);
                        if (be)
                        {
                            tmp = get_data(sql);
                            be = false;
                        }
                        else tmp.Merge(get_data(sql));
                    }
                }
            }
            if (be || tmp == null || tmp.Tables.Count <= 0) upd_error(sql, "?", "?");
            return tmp;
        }

        public decimal get_id_thngay()
        {
            return getidyymmddhhmiss_stt_computer;//decimal.Parse(iRownum.ToString().PadLeft(3,'0')+get_capid_may(14,sComputer).ToString().PadLeft(9,'0'));
        }
        public decimal get_id_thngay(string ngay, int madoituong, string mabn, decimal maql, string makp, string tu, string den, bool tang)
		{
			if (bMmyy(mmyy(ngay)))
			{
				sql="select id from "+user+mmyy(ngay)+".v_thngayll where madoituong="+madoituong+" and mabn='"+mabn+"' and maql="+maql+" and to_char(tu,'dd/mm/yyyy')='"+tu.Substring(0,10)+"' and to_char(den,'dd/mm/yyyy')='"+den.Substring(0,10)+"' and makp='"+makp+"'";
				ds=get_data(sql);
				if (ds.Tables[0].Rows.Count>0) return decimal.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				else return (tang)?get_id_thngay():0;
			}
			return (tang)?get_id_thngay():0;
		}

		private decimal get_capid(int m_ma)
		{
			sql="update "+user+".v_capid set id=id+1 where ma=:m_ma";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
			con.Open();
            cmd = new NpgsqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("m_ma", NpgsqlDbType.Numeric).Value = m_ma;
			int irec=cmd.ExecuteNonQuery();
			cmd.Dispose();
			if (irec==0)
			{
				sql="insert into "+user+".v_capid(ma,ten,id) values (:m_ma,:m_ten,1)";
				cmd=new NpgsqlCommand(sql,con);
				cmd.CommandType=CommandType.Text;
				cmd.Parameters.Add("m_ma",NpgsqlDbType.Numeric).Value=m_ma;
				cmd.Parameters.Add("m_ten",NpgsqlDbType.Varchar,20).Value=sComputer;
				cmd.ExecuteNonQuery();
				cmd.Dispose();
			}
			sql="select id from "+user+".v_capid where ma="+m_ma;
			cmd=new NpgsqlCommand(sql,con);
			cmd.CommandType=CommandType.Text;
			dest=new NpgsqlDataAdapter(cmd);
			ds=new DataSet();
			dest.Fill(ds);	
			cmd.Dispose();				
			con.Close(); con.Dispose();
			return decimal.Parse(ds.Tables[0].Rows[0][0].ToString());
		}

        public decimal get_capid_medi(int m_ma, string m_table)
        {
            sql = "update " + user + "." + m_table + " set id=id+1 where ma=:m_ma";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
            con.Open();
            cmd = new NpgsqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("m_ma", NpgsqlDbType.Numeric).Value = m_ma;
            int irec = cmd.ExecuteNonQuery();
            cmd.Dispose();
            if (irec == 0)
            {
                sql = "insert into " + user + "." + m_table + "(ma,yy,loai,id) values (:m_ma,'??',:m_loai,1)";
                cmd = new NpgsqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("m_ma", NpgsqlDbType.Numeric).Value = m_ma;
                cmd.Parameters.Add("m_loai", NpgsqlDbType.Varchar, 20).Value = sComputer;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            sql = "select id from " + user + "." + m_table + " where ma=" + m_ma;
            cmd = new NpgsqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            dest = new NpgsqlDataAdapter(cmd);
            ds = new DataSet();
            dest.Fill(ds);
            cmd.Dispose();
            con.Close(); con.Dispose();
            return decimal.Parse(ds.Tables[0].Rows[0][0].ToString());
        }

		private decimal get_capid(string table,int m_ma)
		{
			sql="update "+user+"."+table+" set id=id+1 where ma=:m_ma";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
			con.Open();
            cmd = new NpgsqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("m_ma", NpgsqlDbType.Numeric).Value = m_ma;
			int irec=cmd.ExecuteNonQuery();
			cmd.Dispose();
			if (irec==0)
			{
				sql="insert into "+user+"."+table+"(ma,ten,id) values (:m_ma,:m_ten,1)";
				cmd=new NpgsqlCommand(sql,con);
				cmd.CommandType=CommandType.Text;
				cmd.Parameters.Add("m_ma",NpgsqlDbType.Numeric).Value=m_ma;
				cmd.Parameters.Add("m_ten",NpgsqlDbType.Varchar,20).Value=sComputer;
				cmd.ExecuteNonQuery();
				cmd.Dispose();
			}
			sql="select id from "+user+"."+table+" where ma="+m_ma;
			cmd=new NpgsqlCommand(sql,con);
			cmd.CommandType=CommandType.Text;
			dest=new NpgsqlDataAdapter(cmd);
			ds=new DataSet();
			dest.Fill(ds);	
			cmd.Dispose();				
			con.Close(); con.Dispose();
			return decimal.Parse(ds.Tables[0].Rows[0][0].ToString());
		}

		private decimal get_capid_may(int m_ma,string m_computer)
		{
			sql="update "+user+".v_capid set id=id+1 where ma=:m_ma and computer=:m_computer";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
			con.Open();
            cmd = new NpgsqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("m_ma", NpgsqlDbType.Numeric).Value = m_ma;
            cmd.Parameters.Add("m_computer", NpgsqlDbType.Varchar, 20).Value = m_computer;
			int irec=cmd.ExecuteNonQuery();
			cmd.Dispose();
			if (irec==0)
			{
				sql="insert into "+user+".v_capid(ma,ten,id,computer) values (:m_ma,:m_ten,1,:m_computer)";
				cmd=new NpgsqlCommand(sql,con);
				cmd.CommandType=CommandType.Text;
				cmd.Parameters.Add("m_ma",NpgsqlDbType.Numeric).Value=m_ma;
				cmd.Parameters.Add("m_ten",NpgsqlDbType.Varchar,20).Value=m_computer;
				cmd.Parameters.Add("m_computer",NpgsqlDbType.Varchar,20).Value=m_computer;
				cmd.ExecuteNonQuery();
				cmd.Dispose();
			}
			sql="select id from "+user+".v_capid where ma="+m_ma+" and computer='"+m_computer+"'";
			cmd=new NpgsqlCommand(sql,con);
			cmd.CommandType=CommandType.Text;
			dest=new NpgsqlDataAdapter(cmd);
			ds=new DataSet();
			dest.Fill(ds);	
			cmd.Dispose();				
			con.Close(); con.Dispose();
			return decimal.Parse(ds.Tables[0].Rows[0][0].ToString());
		}

		private int get_lanin(string m_table,decimal m_id)
		{
			sql="update "+user+"."+m_table+" set lanin=lanin+1 where id=:m_id";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
			con.Open();
            cmd = new NpgsqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("m_id", NpgsqlDbType.Numeric).Value = m_id;
			int irec=cmd.ExecuteNonQuery();
			cmd.Dispose();
			if (irec==0) return 1;
			else return int.Parse(get_data("select lanin from "+user+"."+m_table+" where id="+m_id).Tables[0].Rows[0][0].ToString());
		}

		public bool upd_thongso(int v_id,string v_loai,string v_ten)
		{
            sql = "update " + user + ".v_thongso set loai=:v_loai,ten=:v_ten where id=:v_id";
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
                cmd.Parameters.Add("v_loai", NpgsqlDbType.Text).Value = v_loai;
                cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".v_thongso(id,loai,ten) values (:v_id,:v_loai,:v_ten)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    cmd.Parameters.Add("v_loai", NpgsqlDbType.Text).Value = v_loai;
                    cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    irec = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message, sComputer, "v_thongso");
                return false;
            }
            finally
            {
                con.Close(); con.Dispose();
            }
            return true;
		}

		public bool upd_quyenso(decimal v_id,string v_ngaylinh,string v_sohieu,decimal v_tu,decimal v_den,decimal v_soghi,string v_loai,int v_khambenh,int v_userid)
		{
            sql = "update " + user + ".v_quyenso set ngaylinh=to_timestamp(:v_ngaylinh,'dd/mm/yyyy'),sohieu=:v_sohieu,tu=:v_tu,den=:v_den,soghi=:v_soghi,loai=:v_loai,khambenh=:v_khambenh,userid=:v_userid where id=:v_id";
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
                cmd.Parameters.Add("v_ngaylinh", NpgsqlDbType.Varchar, 10).Value = v_ngaylinh;
                cmd.Parameters.Add("v_sohieu", NpgsqlDbType.Varchar, 20).Value = v_sohieu;
                cmd.Parameters.Add("v_tu", NpgsqlDbType.Numeric).Value = v_tu;
                cmd.Parameters.Add("v_den", NpgsqlDbType.Numeric).Value = v_den;
                cmd.Parameters.Add("v_soghi", NpgsqlDbType.Numeric).Value = v_soghi;
                cmd.Parameters.Add("v_loai", NpgsqlDbType.Varchar, 20).Value = v_loai;
                cmd.Parameters.Add("v_khambenh", NpgsqlDbType.Numeric).Value = v_khambenh;
                cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".v_quyenso(id,ngaylinh,sohieu,tu,den,soghi,dangsd,loai,khambenh,userid) values (:v_id,to_timestamp(:v_ngaylinh,'dd/mm/yyyy'),:v_sohieu,:v_tu,:v_den,:v_soghi,0,:v_loai,:v_khambenh,:v_userid)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    cmd.Parameters.Add("v_ngaylinh", NpgsqlDbType.Varchar, 10).Value = v_ngaylinh;
                    cmd.Parameters.Add("v_sohieu", NpgsqlDbType.Varchar, 20).Value = v_sohieu;
                    cmd.Parameters.Add("v_tu", NpgsqlDbType.Numeric).Value = v_tu;
                    cmd.Parameters.Add("v_den", NpgsqlDbType.Numeric).Value = v_den;
                    cmd.Parameters.Add("v_soghi", NpgsqlDbType.Numeric).Value = v_soghi;
                    cmd.Parameters.Add("v_loai", NpgsqlDbType.Varchar, 20).Value = v_loai;
                    cmd.Parameters.Add("v_khambenh", NpgsqlDbType.Numeric).Value = v_khambenh;
                    cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                    irec = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message, sComputer, "v_quyenso");
                return false;
            }
            finally
            {
                con.Close(); con.Dispose();
            }
            return true;
		}

		public bool upd_loaivp(decimal v_id,int v_id_vdt,int v_id_nhom,int v_stt,string v_ma,string v_ten,int v_userid,string v_computer)
		{
            sql = "update " + user + ".v_loaivp set id_vdt=:v_id_vdt,id_nhom=:v_id_nhom,stt=:v_stt,ma=:v_ma,ten=:v_ten,userid=:v_userid,computer=:v_computer where id=:v_id";
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
                cmd.Parameters.Add("v_id_vdt", NpgsqlDbType.Numeric).Value = v_id_vdt;
                cmd.Parameters.Add("v_id_nhom", NpgsqlDbType.Numeric).Value = v_id_nhom;
                cmd.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                cmd.Parameters.Add("v_ma", NpgsqlDbType.Text).Value = v_ma;
                cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                cmd.Parameters.Add("v_computer", NpgsqlDbType.Text).Value = v_computer;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".v_loaivp(id,id_vdt,id_nhom,stt,ma,ten,userid,computer) values (:v_id,:v_id_vdt,:v_id_nhom,:v_stt,:v_ma,:v_ten,:v_userid,:v_computer)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    cmd.Parameters.Add("v_id_vdt", NpgsqlDbType.Numeric).Value = v_id_vdt;
                    cmd.Parameters.Add("v_id_nhom", NpgsqlDbType.Numeric).Value = v_id_nhom;
                    cmd.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    cmd.Parameters.Add("v_ma", NpgsqlDbType.Text).Value = v_ma;
                    cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                    cmd.Parameters.Add("v_computer", NpgsqlDbType.Text).Value = v_computer;
                    irec = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message, sComputer, "v_loaivp");
                return false;
            }
            finally
            {
                con.Close(); con.Dispose();
            }
            return true;
		}

		public bool upd_trongoi(decimal v_id,int v_stt,decimal v_id_nhom,decimal v_id_loai,decimal v_id_gia,decimal v_sotien)
		{
            sql = "update " + user + ".v_trongoi set stt=:v_stt,sotien=:v_sotien where id=:v_id and id_nhom=:v_id_nhom and id_loai=:v_id_loai and id_gia=:v_id_gia";
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
                cmd.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                cmd.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_id_nhom", NpgsqlDbType.Numeric).Value = v_id_nhom;
                cmd.Parameters.Add("v_id_loai", NpgsqlDbType.Numeric).Value = v_id_loai;
                cmd.Parameters.Add("v_id_gia", NpgsqlDbType.Numeric).Value = v_id_gia;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".v_trongoi(id,stt,id_nhom,id_loai,id_gia,sotien) values (:v_id,:v_stt,:v_id_nhom,:v_id_loai,:v_id_gia,:v_sotien)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    cmd.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    cmd.Parameters.Add("v_id_nhom", NpgsqlDbType.Numeric).Value = v_id_nhom;
                    cmd.Parameters.Add("v_id_loai", NpgsqlDbType.Numeric).Value = v_id_loai;
                    cmd.Parameters.Add("v_id_gia", NpgsqlDbType.Numeric).Value = v_id_gia;
                    cmd.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                    irec = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message, sComputer, "v_trongoi");
                return false;
            }
            finally
            {
                con.Close(); con.Dispose();
            }
            return true;
		}

		public bool upd_giavp(decimal v_id,decimal v_id_loai,int v_stt,string v_ma,string v_ten,string v_dvt,decimal v_gia_th,
            decimal v_gia_bh,decimal v_gia_cs,decimal v_gia_dv,decimal v_gia_nn,decimal v_bhyt,int v_userid,decimal v_vattu_th,
            decimal v_vattu_bh,decimal v_vattu_cs,decimal v_vattu_dv,decimal v_vattu_nn,int v_loaibn,int v_theobs,
            int v_chenhlech,string v_locthe)
		{
            sql = "update " + user + ".v_giavp set id_loai=:v_id_loai,stt=:v_stt,ma=:v_ma,ten=:v_ten,dvt=:v_dvt,gia_th=:v_gia_th,gia_bh=:v_gia_bh,gia_cs=:v_gia_cs,";
            sql += "gia_dv=:v_gia_dv,gia_nn=:v_gia_nn,bhyt=:v_bhyt,userid=:v_userid,vattu_th=:v_vattu_th,";
            sql += " vattu_bh=:v_vattu_bh,vattu_cs=:v_vattu_cs,vattu_dv=:v_vattu_dv,vattu_nn=:v_vattu_nn,loaibn=:v_loaibn,theobs=:v_theobs,";
            sql += " chenhlech=:v_chenhlech,locthe=:v_locthe ";
            sql+=" where id=:v_id";
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
                cmd.Parameters.Add("v_id_loai", NpgsqlDbType.Numeric).Value = v_id_loai;
                cmd.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                cmd.Parameters.Add("v_ma", NpgsqlDbType.Text).Value = v_ma;
                cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                cmd.Parameters.Add("v_dvt", NpgsqlDbType.Text, 20).Value = v_dvt;
                cmd.Parameters.Add("v_gia_th", NpgsqlDbType.Numeric).Value = v_gia_th;
                cmd.Parameters.Add("v_gia_bh", NpgsqlDbType.Numeric).Value = v_gia_bh;
                cmd.Parameters.Add("v_gia_cs", NpgsqlDbType.Numeric).Value = v_gia_cs;
                cmd.Parameters.Add("v_gia_dv", NpgsqlDbType.Numeric).Value = v_gia_dv;
                cmd.Parameters.Add("v_gia_nn", NpgsqlDbType.Numeric).Value = v_gia_nn;
                cmd.Parameters.Add("v_bhyt", NpgsqlDbType.Numeric).Value = v_bhyt;
                cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                cmd.Parameters.Add("v_vattu_th", NpgsqlDbType.Numeric).Value = v_vattu_th;
                cmd.Parameters.Add("v_vattu_bh", NpgsqlDbType.Numeric).Value = v_vattu_bh;
                cmd.Parameters.Add("v_vattu_cs", NpgsqlDbType.Numeric).Value = v_vattu_cs;
                cmd.Parameters.Add("v_vattu_dv", NpgsqlDbType.Numeric).Value = v_vattu_dv;
                cmd.Parameters.Add("v_vattu_nn", NpgsqlDbType.Numeric).Value = v_vattu_nn;
                cmd.Parameters.Add("v_loaibn", NpgsqlDbType.Numeric).Value = v_loaibn;
                cmd.Parameters.Add("v_theobs", NpgsqlDbType.Numeric).Value = v_theobs;
                cmd.Parameters.Add("v_chenhlech", NpgsqlDbType.Numeric).Value = v_chenhlech;
                cmd.Parameters.Add("v_locthe", NpgsqlDbType.Text).Value = v_locthe;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".v_giavp(id,id_loai,stt,ma,ten,dvt,gia_th,gia_bh,gia_cs,gia_dv,gia_nn,bhyt,userid,vattu_th,vattu_bh,vattu_cs,vattu_dv,vattu_nn,loaibn,theobs,chenhlech,locthe) values (:v_id,:v_id_loai,:v_stt,:v_ma,:v_ten,:v_dvt,:v_gia_th,:v_gia_bh,:v_gia_cs,:v_gia_dv,:v_gia_nn,:v_bhyt,:v_userid,:v_vattu_th,:v_vattu_bh,:v_vattu_cs,:v_vattu_dv,:v_vattu_nn,:v_loaibn,:v_theobs,:v_chenhlech,:v_locthe)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    cmd.Parameters.Add("v_id_loai", NpgsqlDbType.Numeric).Value = v_id_loai;
                    cmd.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    cmd.Parameters.Add("v_ma", NpgsqlDbType.Text).Value = v_ma;
                    cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    cmd.Parameters.Add("v_dvt", NpgsqlDbType.Text, 20).Value = v_dvt;
                    cmd.Parameters.Add("v_gia_th", NpgsqlDbType.Numeric).Value = v_gia_th;
                    cmd.Parameters.Add("v_gia_bh", NpgsqlDbType.Numeric).Value = v_gia_bh;
                    cmd.Parameters.Add("v_gia_cs", NpgsqlDbType.Numeric).Value = v_gia_cs;
                    cmd.Parameters.Add("v_gia_dv", NpgsqlDbType.Numeric).Value = v_gia_dv;
                    cmd.Parameters.Add("v_gia_nn", NpgsqlDbType.Numeric).Value = v_gia_nn;
                    cmd.Parameters.Add("v_bhyt", NpgsqlDbType.Numeric).Value = v_bhyt;
                    cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                    cmd.Parameters.Add("v_vattu_th", NpgsqlDbType.Numeric).Value = v_vattu_th;
                    cmd.Parameters.Add("v_vattu_bh", NpgsqlDbType.Numeric).Value = v_vattu_bh;
                    cmd.Parameters.Add("v_vattu_cs", NpgsqlDbType.Numeric).Value = v_vattu_cs;
                    cmd.Parameters.Add("v_vattu_dv", NpgsqlDbType.Numeric).Value = v_vattu_dv;
                    cmd.Parameters.Add("v_vattu_nn", NpgsqlDbType.Numeric).Value = v_vattu_nn;
                    cmd.Parameters.Add("v_loaibn", NpgsqlDbType.Numeric).Value = v_loaibn;
                    cmd.Parameters.Add("v_theobs", NpgsqlDbType.Numeric).Value = v_theobs;
                    cmd.Parameters.Add("v_chenhlech", NpgsqlDbType.Numeric).Value = v_chenhlech;
                    cmd.Parameters.Add("v_locthe", NpgsqlDbType.Text).Value = v_locthe; 
                    irec = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message, sComputer, "v_giavp");
                return false;
            }
            finally
            {
                con.Close(); con.Dispose();
            }
            return true;
		}

		public bool upd_giavattu(decimal v_id,decimal v_mavp,int v_stt,decimal v_soluong,decimal v_gia_th,decimal v_gia_bh,decimal v_gia_cs,decimal v_gia_dv,decimal v_gia_nn)
		{
            sql = "update " + user + ".v_giavattu set stt=:v_stt,soluong=:v_soluong,gia_th=:v_gia_th,gia_bh=:v_gia_bh,gia_cs=:v_gia_cs,gia_dv=:v_gia_dv,gia_nn=:v_gia_nn where id=:v_id and mavp=:v_mavp";
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
                cmd.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                cmd.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
                cmd.Parameters.Add("v_gia_th", NpgsqlDbType.Numeric).Value = v_gia_th;
                cmd.Parameters.Add("v_gia_bh", NpgsqlDbType.Numeric).Value = v_gia_bh;
                cmd.Parameters.Add("v_gia_cs", NpgsqlDbType.Numeric).Value = v_gia_cs;
                cmd.Parameters.Add("v_gia_dv", NpgsqlDbType.Numeric).Value = v_gia_dv;
                cmd.Parameters.Add("v_gia_nn", NpgsqlDbType.Numeric).Value = v_gia_nn;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".v_giavattu (id,mavp,stt,soluong,gia_th,gia_bh,gia_cs,gia_dv,gia_nn) values (:v_id,:v_mavp,:v_stt,:v_soluong,:v_gia_th,:v_gia_bh,:v_gia_cs,:v_gia_dv,:v_gia_nn)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    cmd.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
                    cmd.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    cmd.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
                    cmd.Parameters.Add("v_gia_th", NpgsqlDbType.Numeric).Value = v_gia_th;
                    cmd.Parameters.Add("v_gia_bh", NpgsqlDbType.Numeric).Value = v_gia_bh;
                    cmd.Parameters.Add("v_gia_cs", NpgsqlDbType.Numeric).Value = v_gia_cs;
                    cmd.Parameters.Add("v_gia_dv", NpgsqlDbType.Numeric).Value = v_gia_dv;
                    cmd.Parameters.Add("v_gia_nn", NpgsqlDbType.Numeric).Value = v_gia_nn;
                    irec = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message, sComputer,"v_giavattu");
                return false;
            }
            finally
            {
                con.Close(); con.Dispose();
            }
            return true;
		}

		public bool upd_tygia(string v_ngay,decimal v_tygia,int v_userid)
		{
            sql = "update " + user + ".v_tygia set tygia=:v_tygia,userid=:v_userid where to_char(ngay,'dd/mm/yyyy')=:v_ngay";
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
                cmd.Parameters.Add("v_tygia", NpgsqlDbType.Numeric).Value = v_tygia;
                cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                cmd.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".v_tygia (ngay,tygia,userid) values (to_timestamp(v_ngay,'dd/mm/yyyy'),:v_tygia,:v_userid)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay;
                    cmd.Parameters.Add("v_tygia", NpgsqlDbType.Numeric).Value = v_tygia;
                    cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                    irec = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message, sComputer, "v_tygia");
                return false;
            }
            finally
            {
                con.Close(); con.Dispose();
            }
            return true;
		}

		public bool upd_dlogin(decimal v_id,string v_hoten,string v_userid,string v_password_,string v_right_,string v_loaivp,string v_mucvp,string v_loai,string v_madoituong,int v_admin)
		{
            sql = "update "+user+".v_dlogin set hoten=:v_hoten,userid=:v_userid,password_=:v_password_,right_=:v_right_,loaivp=:v_loaivp,mucvp=:v_mucvp,loai=:v_loai,madoituong=:v_madoituong,admin=:v_admin where id=:v_id";
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
                cmd.Parameters.Add("v_hoten", NpgsqlDbType.Text).Value = v_hoten;
                cmd.Parameters.Add("v_userid", NpgsqlDbType.Varchar, 10).Value = v_userid;
                cmd.Parameters.Add("v_password_", NpgsqlDbType.Varchar, 10).Value = v_password_;
                cmd.Parameters.Add("v_right_", NpgsqlDbType.Text).Value = v_right_;
                cmd.Parameters.Add("v_loaivp", NpgsqlDbType.Text).Value = v_loaivp;
                cmd.Parameters.Add("v_mucvp", NpgsqlDbType.Text).Value = v_mucvp;
                cmd.Parameters.Add("v_loai", NpgsqlDbType.Text).Value = v_loai;
                cmd.Parameters.Add("v_madoituong", NpgsqlDbType.Varchar, 20).Value = v_madoituong;
                cmd.Parameters.Add("v_admin", NpgsqlDbType.Numeric).Value = v_admin;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".v_dlogin (id,hoten,userid,password_,right_,loaivp,mucvp,loai,madoituong,admin) values (:v_id,:v_hoten,:v_userid,:v_password_,:v_right_,:v_loaivp,:v_mucvp,:v_loai,:v_madoituong,:v_admin)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    cmd.Parameters.Add("v_hoten", NpgsqlDbType.Text).Value = v_hoten;
                    cmd.Parameters.Add("v_userid", NpgsqlDbType.Varchar, 10).Value = v_userid;
                    cmd.Parameters.Add("v_password_", NpgsqlDbType.Varchar, 10).Value = v_password_;
                    cmd.Parameters.Add("v_right_", NpgsqlDbType.Text).Value = v_right_;
                    cmd.Parameters.Add("v_loaivp", NpgsqlDbType.Text).Value = v_loaivp;
                    cmd.Parameters.Add("v_mucvp", NpgsqlDbType.Text).Value = v_mucvp;
                    cmd.Parameters.Add("v_loai", NpgsqlDbType.Text).Value = v_loai;
                    cmd.Parameters.Add("v_madoituong", NpgsqlDbType.Varchar, 20).Value = v_madoituong;
                    cmd.Parameters.Add("v_admin", NpgsqlDbType.Numeric).Value = v_admin;
                    irec = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message.ToString().Trim(), sComputer, "v_dlogin");
                return false;
            }
            finally
            {
                con.Close(); con.Dispose();
            }
            return true;
		}

		public bool upd_dlogin_right(decimal v_id,string v_right_)
		{
            sql = "update " + user + ".v_dlogin set right_=:v_right_ where id=:v_id";
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
                cmd.Parameters.Add("v_right_", NpgsqlDbType.Text).Value = v_right_;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message.ToString().Trim(), sComputer, "v_dlogin");
                return false;
            }
            finally
            {
                con.Close(); con.Dispose();
            }
            return true;
		}

		public bool upd_dlogin_loaivp(decimal v_id,string v_loaivp,string v_mucvp,string v_loai,string v_madoituong,int v_admin)
		{
            sql = "update " + user + ".v_dlogin set loaivp=:v_loaivp,mucvp=:v_mucvp,loai=:v_loai,madoituong=:v_madoituong,admin=:v_admin where id=:v_id";
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
                cmd.Parameters.Add("v_loaivp", NpgsqlDbType.Text).Value = v_loaivp;
                cmd.Parameters.Add("v_mucvp", NpgsqlDbType.Text).Value = v_mucvp;
                cmd.Parameters.Add("v_loai", NpgsqlDbType.Text).Value = v_loai;
                cmd.Parameters.Add("v_madoituong", NpgsqlDbType.Varchar, 20).Value = v_madoituong;
                cmd.Parameters.Add("v_admin", NpgsqlDbType.Numeric).Value = v_admin;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message.ToString().Trim(), sComputer, "v_dlogin");
                return false;
            }
            finally
            {
                con.Close(); con.Dispose();
            }
            return true;
		}

		public bool upd_tenloaivp(int v_ma,string v_ten)
		{
            sql = "update " + user + ".v_tenloaivp set ten=:v_ten where ma=:v_ma";
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
                cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                cmd.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".v_tenloaivp (ma,ten) values (:v_ma,:v_ten)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                    cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    irec = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message.ToString().Trim(), sComputer, "v_tenloaivp");
                return false;
            }
            finally
            {
                con.Close(); con.Dispose();
            }
            return true;
		}

		public bool upd_vienphill(decimal v_id,decimal v_quyenso,decimal v_sobienlai,string v_ngay,string v_mabn,decimal v_mavaovien,decimal v_maql,decimal v_idkhoa,string v_makp,string v_hoten,int v_phai,string v_namsinh,string v_diachi,int v_loai,int v_loaibn,int v_userid,string v_masothue)
		{
            schema = user + mmyy(v_ngay) + ".upd_vienphill";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
			try
			{
				con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_quyenso", NpgsqlDbType.Numeric).Value = v_quyenso;
                cmd.Parameters.Add("v_sobienlai", NpgsqlDbType.Numeric).Value = v_sobienlai;
                cmd.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 16).Value = v_ngay;
                cmd.Parameters.Add("v_mabn", NpgsqlDbType.Varchar).Value = v_mabn;
                cmd.Parameters.Add("v_mavaovien", NpgsqlDbType.Numeric).Value = v_mavaovien;
                cmd.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                cmd.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
                cmd.Parameters.Add("v_makp", NpgsqlDbType.Varchar, i_maxlength_makp).Value = v_makp;
                cmd.Parameters.Add("v_hoten", NpgsqlDbType.Text).Value = v_hoten;
                cmd.Parameters.Add("v_phai", NpgsqlDbType.Numeric).Value = v_phai;
                cmd.Parameters.Add("v_namsinh", NpgsqlDbType.Varchar, 4).Value = v_namsinh;
                cmd.Parameters.Add("v_diachi", NpgsqlDbType.Text).Value = v_diachi;
                cmd.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                cmd.Parameters.Add("v_loaibn", NpgsqlDbType.Numeric).Value = v_loaibn;
                cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                cmd.Parameters.Add("v_masothue", NpgsqlDbType.Varchar, 20).Value = v_masothue;
				cmd.ExecuteNonQuery();
			}
			catch(NpgsqlException ex)
			{
				upd_error(v_ngay,ex.Message,sComputer,"v_vienphill");
				return false;
			}
			finally
			{
                con.Close(); con.Dispose();
			}
			return true;
		}

		public bool upd_vienphict(string v_ngay,decimal v_id,int v_stt,int v_madoituong,int v_mavp,string v_ten,decimal v_soluong,decimal v_dongia,decimal v_mien,decimal v_thieu,decimal v_vattu,string v_mabs,string v_makp)
		{
            schema = user + mmyy(v_ngay) + ".upd_vienphict";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
			try
			{
				con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                cmd.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
                cmd.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
                cmd.Parameters.Add("v_ten", NpgsqlDbType.Text, 100).Value = v_ten;
                cmd.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
                cmd.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;
                cmd.Parameters.Add("v_mien", NpgsqlDbType.Numeric).Value = v_mien;
                cmd.Parameters.Add("v_thieu", NpgsqlDbType.Numeric).Value = v_thieu;
                cmd.Parameters.Add("v_vattu", NpgsqlDbType.Numeric).Value = v_vattu;
                cmd.Parameters.Add("v_mabs", NpgsqlDbType.Varchar, 4).Value = v_mabs;
                cmd.Parameters.Add("v_makp", NpgsqlDbType.Varchar, i_maxlength_makp).Value = v_makp;
				cmd.ExecuteNonQuery();
			}
			catch(NpgsqlException ex)
			{
				upd_error(v_ngay,ex.Message,sComputer,"v_vienphict");
				return false;
			}
			finally
			{
                con.Close(); con.Dispose();
			}
			return true;
		}

		public bool upd_nhom(string v_ngay,decimal v_id,int v_ma,decimal v_sotien)
		{
            schema = user + mmyy(v_ngay) + ".upd_nhom";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
			try
			{
				con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                cmd.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
				cmd.ExecuteNonQuery();
			}
			catch(NpgsqlException ex)
			{
				upd_error(v_ngay,ex.Message,sComputer,"v_nhom");
				return false;
			}
			finally
			{
                con.Close(); con.Dispose();
			}
			return true;
		}

		public bool upd_trongoi(string v_ngay,decimal v_id,decimal v_sotien,decimal v_tamung,decimal v_hoantra,int v_pm,int v_yc,string v_ghichu)
		{
            schema = user + mmyy(v_ngay) + ".upd_trongoi";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
			try
			{
				con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                cmd.Parameters.Add("v_tamung", NpgsqlDbType.Numeric).Value = v_tamung;
                cmd.Parameters.Add("v_hoantra", NpgsqlDbType.Numeric).Value = v_hoantra;
                cmd.Parameters.Add("v_pm", NpgsqlDbType.Numeric).Value = v_pm;
                cmd.Parameters.Add("v_yc", NpgsqlDbType.Numeric).Value = v_yc;
                cmd.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;
				cmd.ExecuteNonQuery();
			}
			catch(NpgsqlException ex)
			{
				upd_error(v_ngay,ex.Message,sComputer,"v_trongoi");
				return false;
			}
			finally
			{
                con.Close(); con.Dispose();
			}
			return true;
		}


		public bool upd_giuong(string ngay,decimal v_id,int v_mavp,string v_ngay,decimal v_dongia)
		{
            schema = user + mmyy(ngay) + ".upd_giuong";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
			try
			{
				con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
                cmd.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay;
                cmd.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;
				cmd.ExecuteNonQuery();
			}
			catch(NpgsqlException ex)
			{
				upd_error(ngay,ex.Message,sComputer,"v_giuong");
				return false;
			}
			finally
			{
                con.Close(); con.Dispose();
			}
			return true;
		}

        public bool upd_bhyt(string v_ngay, decimal v_id, string v_sothe, int v_maphu, string v_mabv, string v_noigioithieu,int traituyen)
        {
            string xxx = user + mmyy(v_ngay);
            sql = "update " + xxx + ".v_bhyt set sothe=:v_sothe,maphu=:v_maphu,mabv=:v_mabv,noigioithieu=:v_noigioithieu,traituyen="+traituyen;
            sql += " where id="+v_id;
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
                cmd.Parameters.Add("v_sothe", NpgsqlDbType.Varchar, 20).Value = v_sothe;
                cmd.Parameters.Add("v_maphu", NpgsqlDbType.Numeric).Value = v_maphu;
                cmd.Parameters.Add("v_mabv", NpgsqlDbType.Varchar, 8).Value = v_mabv;
                cmd.Parameters.Add("v_noigioithieu", NpgsqlDbType.Varchar, 8).Value = v_noigioithieu;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + xxx + ".v_bhyt(id,sothe,maphu,mabv,noigioithieu,traituyen) values ("+v_id+",:v_sothe,:v_maphu,:v_mabv,:v_noigioithieu,"+traituyen+")";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("v_sothe", NpgsqlDbType.Varchar, 20).Value = v_sothe;
                    cmd.Parameters.Add("v_maphu", NpgsqlDbType.Numeric).Value = v_maphu;
                    cmd.Parameters.Add("v_mabv", NpgsqlDbType.Varchar, 8).Value = v_mabv;
                    cmd.Parameters.Add("v_noigioithieu", NpgsqlDbType.Varchar, 8).Value = v_noigioithieu;
                    irec = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(v_ngay,ex.Message, sComputer, "v_bhyt");
                return false;
            }
            finally
            {
                con.Close(); con.Dispose();
            }
            return true;
        }

		public bool upd_bhyt(string v_ngay,decimal v_id,string v_sothe,int v_maphu,string v_mabv,string v_noigioithieu)
		{
            schema = user + mmyy(v_ngay) + ".upd_v_bhyt";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
			try
			{
				con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_sothe", NpgsqlDbType.Varchar, 20).Value = v_sothe;
                cmd.Parameters.Add("v_maphu", NpgsqlDbType.Numeric).Value = v_maphu;
                cmd.Parameters.Add("v_mabv", NpgsqlDbType.Varchar, 8).Value = v_mabv;
                cmd.Parameters.Add("v_noigioithieu", NpgsqlDbType.Varchar, 8).Value = v_noigioithieu;
				cmd.ExecuteNonQuery();
			}
			catch(NpgsqlException ex)
			{
				upd_error(v_ngay,ex.Message,sComputer,"v_bhyt");
				return false;
			}
			finally
			{
				cmd.Dispose();
				con.Close(); con.Dispose();
			}
			return true;
		}

		public bool upd_mienngtru(string v_ngay,decimal v_id,decimal v_sotien,string v_ghichu,int v_maduyet,int v_lydo)
		{
            sql = "update " + user + mmyy(v_ngay) + ".v_mienngtru set sotien=:v_sotien,ghichu=:v_ghichu,maduyet=:v_maduyet,lydo=:v_lydo";
            sql += " where id=:v_id";
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
                cmd.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                cmd.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;
                cmd.Parameters.Add("v_maduyet", NpgsqlDbType.Numeric).Value = v_maduyet;
                cmd.Parameters.Add("v_lydo", NpgsqlDbType.Numeric).Value = v_lydo;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
				int irec=cmd.ExecuteNonQuery();
				cmd.Dispose();
				if (irec==0)
				{
                    sql = "insert into " + user+mmyy(v_ngay) + ".v_mienngtru (id,sotien,ghichu,maduyet,lydo)";
                    sql += " values (:v_id,:v_sotien,:v_ghichu,:v_maduyet,:v_lydo)";
					cmd=new NpgsqlCommand(sql,con);
					cmd.CommandType=CommandType.Text;
                    cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    cmd.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                    cmd.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;
                    cmd.Parameters.Add("v_maduyet", NpgsqlDbType.Numeric).Value = v_maduyet;
                    cmd.Parameters.Add("v_lydo", NpgsqlDbType.Numeric).Value = v_lydo;
					irec=cmd.ExecuteNonQuery();
					cmd.Dispose();
				}
			}
			catch(NpgsqlException ex)
			{
				upd_error(v_ngay,ex.Message,sComputer,"v_mienngtru");
				return false;
			}
			finally
			{
                con.Close(); con.Dispose();
			}
			return true;
		}
		
		public bool upd_dsduyet(int v_ma,string v_ten)
		{
            sql = "update " + user + ".v_dsduyet set ten=:v_ten where ma=:v_ma";
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
                cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                cmd.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".v_dsduyet (ma,ten) values (:v_ma,:v_ten)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                    cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    irec = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
			catch(NpgsqlException ex)
			{
				upd_error(ex.Message,sComputer,"v_dsduyet");
				return false;
			}
			finally
			{
                con.Close(); con.Dispose();
			}
			return true;
		}

		public bool upd_hoantra(string ngay,decimal v_id,decimal v_quyenso,decimal v_sobienlai,string v_ngay,string v_mabn,string v_hoten,string v_makp,decimal v_sotien,string v_ghichu,int v_userid,int v_loai,int v_loaibn,string v_ngaythu)
		{
            schema = user + mmyy(ngay) + ".upd_hoantra";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
			try
			{
				con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_quyenso", NpgsqlDbType.Numeric).Value = v_quyenso;
                cmd.Parameters.Add("v_sobienlai", NpgsqlDbType.Numeric).Value = v_sobienlai;
                cmd.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 16).Value = v_ngay;
                cmd.Parameters.Add("v_mabn", NpgsqlDbType.Varchar).Value = v_mabn;
                cmd.Parameters.Add("v_hoten", NpgsqlDbType.Text).Value = v_hoten;
                cmd.Parameters.Add("v_makp", NpgsqlDbType.Varchar, i_maxlength_makp).Value = v_makp;
                cmd.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                cmd.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;
                cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                cmd.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                cmd.Parameters.Add("v_loaibn", NpgsqlDbType.Numeric).Value = v_loaibn;
                cmd.Parameters.Add("v_ngaythu", NpgsqlDbType.Varchar, 16).Value = v_ngaythu;
				cmd.ExecuteNonQuery();
			}
			catch(NpgsqlException ex)
			{
				upd_error(ngay,ex.Message,sComputer,"v_hoantra");
				return false;
			}
			finally
			{
				cmd.Dispose();
				con.Close(); con.Dispose();
			}
			return true;
		}

		public bool upd_hoantract(string ngay,decimal v_id,int v_loaivp,decimal v_sotien)
		{
            schema = user + mmyy(ngay) + ".upd_hoantract";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
			try
			{
				con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_loaivp", NpgsqlDbType.Numeric).Value = v_loaivp;
                cmd.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
				cmd.ExecuteNonQuery();
			}
			catch(NpgsqlException ex)
			{
				upd_error(ngay,ex.Message,sComputer,"v_hoantract");
				return false;
			}
			finally
			{
				cmd.Dispose();
				con.Close(); con.Dispose();
			}
			return true;
		}

		public bool upd_nhombhyt(decimal v_id,string v_ten,int v_stt)
		{
            sql = "update "+user+".v_nhombhyt set stt=:v_stt,ten=:v_ten where id=:v_id";
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
                cmd.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into "+user+".v_nhombhyt (id,ten,stt) values (:v_id,:v_ten,:v_stt)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    cmd.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    irec = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message, sComputer,"v_nhombhyt");
                return false;
            }
            finally
            {
                con.Close(); con.Dispose();
            }
            return true;
		}

		public bool upd_nhomvp(decimal v_ma,string v_matat,string v_ten,int v_stt,int v_idnhombhyt,decimal v_dongia)
		{
            sql = "update " + user + ".v_nhomvp set matat=:v_matat,ten=:v_ten,stt=:v_stt,idnhombhyt=:v_idnhombhyt,dongia=:v_dongia where ma=:v_ma";
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
                cmd.Parameters.Add("v_matat", NpgsqlDbType.Varchar, 20).Value = v_matat;
                cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                cmd.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                cmd.Parameters.Add("v_idnhombhyt", NpgsqlDbType.Numeric).Value = v_idnhombhyt;
                cmd.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;
                cmd.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".v_nhomvp (ma,matat,ten,stt,idnhombhyt,dongia) values (:v_ma,:v_matat,:v_ten,:v_stt,:v_idnhombhyt,:v_dongia)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                    cmd.Parameters.Add("v_matat", NpgsqlDbType.Varchar, 20).Value = v_matat;
                    cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    cmd.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    cmd.Parameters.Add("v_idnhombhyt", NpgsqlDbType.Numeric).Value = v_idnhombhyt;
                    cmd.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;
                    irec = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message, sComputer, "v_nhomvp");
                return false;
            }
            finally
            {
                con.Close(); con.Dispose();
            }
            return true;
		}

		public bool upd_tamung(string ngay,decimal v_id,string v_mabn,decimal v_mavaovien,decimal v_maql,decimal v_idkhoa,decimal v_quyenso,decimal v_sobienlai,string v_ngay,int v_loai,int v_loaibn,string v_makp,int v_madoituong,decimal v_sotien,int v_userid)
		{
            schema = user + mmyy(ngay) + ".upd_tamung";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
			try
			{
				con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_mabn", NpgsqlDbType.Varchar).Value = v_mabn;
                cmd.Parameters.Add("v_mavaovien", NpgsqlDbType.Numeric).Value = v_mavaovien;
                cmd.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                cmd.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
                cmd.Parameters.Add("v_quyenso", NpgsqlDbType.Numeric).Value = v_quyenso;
                cmd.Parameters.Add("v_sobienlai", NpgsqlDbType.Numeric).Value = v_sobienlai;
                cmd.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 16).Value = v_ngay;
                cmd.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                cmd.Parameters.Add("v_loaibn", NpgsqlDbType.Numeric).Value = v_loaibn;
                cmd.Parameters.Add("v_makp", NpgsqlDbType.Varchar, i_maxlength_makp).Value = v_makp;
                cmd.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
                cmd.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
				cmd.ExecuteNonQuery();
			}
			catch(NpgsqlException ex)
			{
				upd_error(ngay,ex.Message,sComputer,"v_tamung");
				return false;
			}
			finally
			{
				cmd.Dispose();
				con.Close(); con.Dispose();
			}
			return true;
		}

        public bool upd_tamungcd(decimal v_id, string v_mabn, decimal v_mavaovien, decimal v_maql, decimal v_idkhoa, string v_ngay,
            int v_loai, int v_loaibn, string v_makp, int v_madoituong,string v_ten, decimal v_sotien, int v_userid)
        {
            schema = user + mmyy(v_ngay) + ".upd_tamungcd";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_mabn", NpgsqlDbType.Varchar).Value = v_mabn;
                cmd.Parameters.Add("v_mavaovien", NpgsqlDbType.Numeric).Value = v_mavaovien;
                cmd.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                cmd.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
                cmd.Parameters.Add("v_makp", NpgsqlDbType.Varchar, i_maxlength_makp).Value = v_makp;
                cmd.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 16).Value = v_ngay;
                cmd.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
                cmd.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                cmd.Parameters.Add("v_loaibn", NpgsqlDbType.Numeric).Value = v_loaibn;
                cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                cmd.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                upd_error(v_ngay, ex.Message, sComputer, "v_tamungcd");
                return false;
            }
            finally
            {
                cmd.Dispose();
                con.Close(); con.Dispose();
            }
            return true;
        }

		public bool upd_tamungct(string ngay,decimal v_id,int v_loaivp,decimal v_sotien)
		{
            schema = user + mmyy(ngay) + ".upd_tamungct";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
			try
			{
				con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_loaivp", NpgsqlDbType.Numeric).Value = v_loaivp;
                cmd.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
				cmd.ExecuteNonQuery();
			}
			catch(NpgsqlException ex)
			{
				upd_error(ngay,ex.Message,sComputer,"v_tamungct");
				return false;
			}
			finally
			{
				cmd.Dispose();
				con.Close(); con.Dispose();
			}
			return true;
		}
        //linh
		public bool upd_chidinh(decimal v_id,string v_mabn,decimal v_mavaovien,decimal v_maql,decimal v_idkhoa,string v_ngay,int v_loai,
            string v_makp,int v_madoituong,int v_mavp,decimal v_soluong,decimal v_dongia,decimal v_vattu,int v_userid,
            int v_tinhtrang,int v_thuchien,decimal v_idchidinh,string v_maicd,string v_chandoan,string v_mabs,
            int v_loaiba,string v_ghichu)
		{
            //schema = user + mmyy(v_ngay) + ".upd_chidinh";
            dblink = dblink.Trim('@');
            dblink = dblink == "" ? "" : "@" + dblink;
            string _mmyy = mmyy(v_ngay);
            if (bMmyy(_mmyy))
            {
                string s_chema = userid + _mmyy;
                string s_sql = "update " + s_chema + ".v_chidinh" + dblink + " set mabn=:v_mabn,mavaovien=:v_mavaovien, maql=:v_maql," +
                    "idkhoa=:v_idkhoa,ngay=to_timestamp('" + v_ngay + "','dd/mm/yyyy hh24:mi'),loai=:v_loai,makp=:v_makp," +
                    "madoituong=:v_madoituong,mavp=:v_mavp,soluong=:v_soluong,dongia=:v_dongia," +
                    "vattu=:v_vattu,userid=:v_userid,tinhtrang=:v_tinhtrang,thuchien=:v_thuchien," +
                    "computer=:v_computer, maicd=:v_maicd, chandoan=:v_chandoan,mabs=:v_mabs,loaiba=:v_loaiba,ghichu=:v_ghichu " +
                    " where id=:v_id";
                if (con != null)
                {
                    con.Close(); con.Dispose();
                }
                con = new NpgsqlConnection(sConn);
                try
                {
                    con.Open();
                    cmd = new NpgsqlCommand(s_sql,con);//(schema, con);
                    cmd.CommandType = CommandType.Text;//.StoredProcedure;                    
                    cmd.Parameters.Add("v_mabn", NpgsqlDbType.Varchar).Value = v_mabn;
                    cmd.Parameters.Add("v_mavaovien", NpgsqlDbType.Numeric).Value = v_mavaovien;
                    cmd.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                    cmd.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
                    //cmd.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 16).Value = v_ngay;
                    cmd.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                    cmd.Parameters.Add("v_makp", NpgsqlDbType.Varchar, i_maxlength_makp).Value = v_makp;
                    cmd.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
                    cmd.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
                    cmd.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
                    cmd.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;
                    cmd.Parameters.Add("v_vattu", NpgsqlDbType.Numeric).Value = v_vattu;
                    cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                    cmd.Parameters.Add("v_tinhtrang", NpgsqlDbType.Numeric).Value = v_tinhtrang;
                    cmd.Parameters.Add("v_thuchien", NpgsqlDbType.Numeric).Value = v_thuchien;
                    cmd.Parameters.Add("v_computer", NpgsqlDbType.Text).Value = sComputer;
                    //cmd.Parameters.Add("v_idchidinh", NpgsqlDbType.Numeric).Value = v_idchidinh;
                    cmd.Parameters.Add("v_maicd", NpgsqlDbType.Varchar, 9).Value = v_maicd;
                    cmd.Parameters.Add("v_chandoan", NpgsqlDbType.Text).Value = v_chandoan;
                    cmd.Parameters.Add("v_mabs", NpgsqlDbType.Varchar, 4).Value = v_mabs;
                    cmd.Parameters.Add("v_loaiba", NpgsqlDbType.Numeric).Value = v_loaiba;
                    cmd.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;
                    cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    int i=cmd.ExecuteNonQuery();
                    if (i == 0)
                    {
                        cmd.Dispose();
                        s_sql = "insert into " + s_chema + ".v_chidinh" + dblink + "(id,mabn,mavaovien,maql,idkhoa,ngay,loai,makp,madoituong,mavp,soluong,dongia,vattu,userid," +
                            "tinhtrang,thuchien,computer,idchidinh,maicd,chandoan,mabs,loaiba,ghichu, paid, done) ";
                        s_sql += " values (:v_id,:v_mabn,:v_mavaovien, :v_maql, :v_idkhoa,to_date('" + v_ngay + "','dd/mm/yyyy hh24:mi'),";
                        s_sql+=" :v_loai, :v_makp, :v_madoituong, :v_mavp, :v_soluong, :v_dongia, :v_vattu, :v_userid, :v_tinhtrang, :v_thuchien, :v_computer, :v_idchidinh,:v_maicd,:v_chandoan, :v_mabs, :v_loaiba,:v_ghichu, 0, 0)";
                        cmd = new NpgsqlCommand(s_sql, con);
                        cmd.CommandType = CommandType.Text;
                        

                        cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                        cmd.Parameters.Add("v_mabn", NpgsqlDbType.Varchar).Value = v_mabn;
                        cmd.Parameters.Add("v_mavaovien", NpgsqlDbType.Numeric).Value = v_mavaovien;
                        cmd.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                        cmd.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
                        //cmd.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 16).Value = v_ngay;
                        cmd.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                        cmd.Parameters.Add("v_makp", NpgsqlDbType.Varchar, i_maxlength_makp).Value = v_makp;
                        cmd.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
                        cmd.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
                        cmd.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
                        cmd.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;
                        cmd.Parameters.Add("v_vattu", NpgsqlDbType.Numeric).Value = v_vattu;
                        cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                        cmd.Parameters.Add("v_tinhtrang", NpgsqlDbType.Numeric).Value = v_tinhtrang;
                        cmd.Parameters.Add("v_thuchien", NpgsqlDbType.Numeric).Value = v_thuchien;
                        cmd.Parameters.Add("v_computer", NpgsqlDbType.Text).Value = sComputer;
                        cmd.Parameters.Add("v_idchidinh", NpgsqlDbType.Numeric).Value = v_idchidinh;
                        cmd.Parameters.Add("v_maicd", NpgsqlDbType.Varchar, 9).Value = v_maicd;
                        cmd.Parameters.Add("v_chandoan", NpgsqlDbType.Text).Value = v_chandoan;
                        cmd.Parameters.Add("v_mabs", NpgsqlDbType.Varchar, 4).Value = v_mabs;
                        cmd.Parameters.Add("v_loaiba", NpgsqlDbType.Numeric).Value = v_loaiba;
                        cmd.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;
                        

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (NpgsqlException ex)
                {
                    upd_error(v_ngay, ex.Message + " - " + s_sql, sComputer, "v_chidinh");
                    return false;
                }
                finally
                {
                    cmd.Dispose();
                    con.Close(); con.Dispose();
                }
                return true;
            }
            else
            {
                return false;
            }
		}
        //end linh

		public bool upd_ttrvll(string ngay,decimal v_id,int v_loaibn,int v_loai,decimal v_quyenso,decimal v_sobienlai,string v_ngay,string v_makp,decimal v_sotien,decimal v_tamung,decimal v_mien,decimal v_bhyt,decimal v_nopthem,decimal v_thieu,decimal v_vattu,decimal v_chenhlech,int v_userid,decimal v_idtonghop)
		{
            schema = user + mmyy(ngay) + ".upd_ttrvll";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
			try
			{
				con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_loaibn", NpgsqlDbType.Numeric).Value = v_loaibn;
                cmd.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                cmd.Parameters.Add("v_quyenso", NpgsqlDbType.Numeric).Value = v_quyenso;
                cmd.Parameters.Add("v_sobienlai", NpgsqlDbType.Numeric).Value = v_sobienlai;
                cmd.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 16).Value = v_ngay;
                cmd.Parameters.Add("v_makp", NpgsqlDbType.Varchar, i_maxlength_makp).Value = v_makp;
                cmd.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                cmd.Parameters.Add("v_tamung", NpgsqlDbType.Numeric).Value = v_tamung;
                cmd.Parameters.Add("v_mien", NpgsqlDbType.Numeric).Value = v_mien;
                cmd.Parameters.Add("v_bhyt", NpgsqlDbType.Numeric).Value = v_bhyt;
                cmd.Parameters.Add("v_nopthem", NpgsqlDbType.Numeric).Value = v_nopthem;
                cmd.Parameters.Add("v_thieu", NpgsqlDbType.Numeric).Value = v_thieu;
                cmd.Parameters.Add("v_vattu", NpgsqlDbType.Numeric).Value = v_vattu;
                cmd.Parameters.Add("v_chenhlech", NpgsqlDbType.Numeric).Value = v_chenhlech;
                cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                cmd.Parameters.Add("v_idtonghop", NpgsqlDbType.Numeric).Value = v_idtonghop;
				cmd.ExecuteNonQuery();
			}
			catch(NpgsqlException ex)
			{
				upd_error(ngay,ex.Message,sComputer,"v_ttrvll");
				return false;
			}
			finally
			{
				cmd.Dispose();
				con.Close(); con.Dispose();
			}
			return true;
		}

		public bool upd_ttrvct(string ngay,decimal v_id,int v_stt,string v_ngay,string v_makp,int v_madoituong,decimal v_mavp,decimal v_soluong,decimal v_dongia,
            int v_vat,decimal v_vattu,decimal v_sotien,string v_sothe)
		{
            schema = user + mmyy(ngay) + ".upd_ttrvct";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
			try
			{
				con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                cmd.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay;
                cmd.Parameters.Add("v_makp", NpgsqlDbType.Varchar, i_maxlength_makp).Value = v_makp;
                cmd.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
                cmd.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
                cmd.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
                cmd.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;
                cmd.Parameters.Add("v_vat", NpgsqlDbType.Numeric).Value = v_vat;
                cmd.Parameters.Add("v_vattu", NpgsqlDbType.Numeric).Value = v_vattu;
                cmd.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                cmd.Parameters.Add("v_sothe", NpgsqlDbType.Varchar, 20).Value = v_sothe;
				cmd.ExecuteNonQuery();
			}
			catch(NpgsqlException ex)
			{
				upd_error(ngay,ex.Message,sComputer,"v_ttrvct");
				return false;
			}
			finally
			{
				cmd.Dispose();
				con.Close(); con.Dispose();
			}
			return true;
		}

		public bool upd_ttrvnhom(string ngay,decimal v_id,int v_ma,decimal v_sotien)
		{
            schema = user + mmyy(ngay) + ".upd_ttrvnhom";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
			try
			{
				con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                cmd.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
				cmd.ExecuteNonQuery();
			}
			catch(NpgsqlException ex)
			{
				upd_error(ngay,ex.Message,sComputer,"v_ttrvnhom");
				return false;
			}
			finally
			{
				cmd.Dispose();
				con.Close(); con.Dispose();
			}
			return true;
		}

		public bool upd_ttrvpttt(string ngay,decimal v_id,string v_ngay,int v_songay_tpt,int v_songay_spt,int v_mavp,string v_tenpt,int v_so,int v_loaipt)
		{
            schema = user + mmyy(ngay) + ".upd_ttrvpttt";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
			try
			{
				con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay;
                cmd.Parameters.Add("v_songay_tpt", NpgsqlDbType.Numeric).Value = v_songay_tpt;
                cmd.Parameters.Add("v_songay_spt", NpgsqlDbType.Numeric).Value = v_songay_spt;
                cmd.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
                cmd.Parameters.Add("v_tenpt", NpgsqlDbType.Text).Value = v_tenpt;
                cmd.Parameters.Add("v_so", NpgsqlDbType.Numeric).Value = v_so;
                cmd.Parameters.Add("v_loaipt", NpgsqlDbType.Numeric).Value = v_loaipt;
				cmd.ExecuteNonQuery();
			}
			catch(NpgsqlException ex)
			{
				upd_error(ngay,ex.Message,sComputer,"v_ttrvpttt");
				return false;
			}
			finally
			{
				cmd.Dispose();
				con.Close(); con.Dispose();
			}
			return true;
		}

		public bool upd_ttrvptttct(string ngay,decimal v_id,int v_stt,int v_loaipt,int v_songay,decimal v_dongia)
		{
            schema = user + mmyy(ngay) + ".upd_ttrvptttct";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
			try
			{
				con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                cmd.Parameters.Add("v_loaipt", NpgsqlDbType.Numeric).Value = v_loaipt;
                cmd.Parameters.Add("v_songay", NpgsqlDbType.Numeric).Value = v_songay;
                cmd.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;
				cmd.ExecuteNonQuery();
			}
			catch(NpgsqlException ex)
			{
				upd_error(ngay,ex.Message,sComputer,"v_ttrvptttct");
				return false;
			}
			finally
			{
				cmd.Dispose();
				con.Close(); con.Dispose();
			}
			return true;
		}

		public bool upd_ttrvds(string ngay,decimal v_id,string v_mabn,decimal v_mavaovien,decimal v_maql,decimal v_idkhoa,string v_giuong,string v_ngayvao,string v_ngayra,string v_chandoan,string v_maicd)
		{
            schema = user + mmyy(ngay) + ".upd_ttrvds";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
			try
			{
				con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_mabn", NpgsqlDbType.Varchar).Value = v_mabn;
                cmd.Parameters.Add("v_mavaovien", NpgsqlDbType.Numeric).Value = v_mavaovien;
                cmd.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                cmd.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
                cmd.Parameters.Add("v_giuong", NpgsqlDbType.Varchar, 20).Value = v_giuong;
                cmd.Parameters.Add("v_ngayvao", NpgsqlDbType.Varchar, 16).Value = v_ngayvao;
                cmd.Parameters.Add("v_ngayra", NpgsqlDbType.Varchar, 16).Value = v_ngayra;
                cmd.Parameters.Add("v_chandoan", NpgsqlDbType.Text).Value = v_chandoan;
                cmd.Parameters.Add("v_maicd", NpgsqlDbType.Varchar, 50).Value = v_maicd;
				cmd.ExecuteNonQuery();
			}
			catch(NpgsqlException ex)
			{
				upd_error(ngay,ex.Message,sComputer,"v_ttrvds");
				return false;
			}
			finally
			{
				cmd.Dispose();
				con.Close(); con.Dispose();
			}
			return true;
		}

        public bool upd_ttrvbhyt(string ngay, decimal v_id, string v_sothe, int v_maphu, string v_tungay, string v_ngay, string v_mabv, string v_noigioithieu, int v_traituyen)
		{
            schema = user + mmyy(ngay) + ".upd_ttrvbhyt";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
			try
			{
				con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_sothe", NpgsqlDbType.Varchar, 20).Value = v_sothe;
                cmd.Parameters.Add("v_maphu", NpgsqlDbType.Numeric).Value = v_maphu;
                cmd.Parameters.Add("v_tungay", NpgsqlDbType.Varchar, 10).Value = v_tungay;
                cmd.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay;
                cmd.Parameters.Add("v_mabv", NpgsqlDbType.Varchar, 8).Value = v_mabv;
                cmd.Parameters.Add("v_noigioithieu", NpgsqlDbType.Varchar, 8).Value = v_noigioithieu;
                cmd.Parameters.Add("v_traituyen", NpgsqlDbType.Numeric).Value = v_traituyen;
				cmd.ExecuteNonQuery();
			}
			catch(NpgsqlException ex)
			{
				upd_error(ngay,ex.Message,sComputer,"v_ttrvbhyt");
				return false;
			}
			finally
			{
				cmd.Dispose();
				con.Close(); con.Dispose();
			}
			return true;
		}

        public bool upd_miennoitru(string v_ngay, decimal v_id,int v_lydo,string v_ghichu, int v_maduyet)
        {
            sql = "update " + user + mmyy(v_ngay) + ".v_miennoitru set lydo=:v_lydo,ghichu=:v_ghichu,maduyet=:v_maduyet";
            sql += " where id=:v_id";
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
                cmd.Parameters.Add("v_lydo", NpgsqlDbType.Numeric).Value = v_lydo;
                cmd.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;
                cmd.Parameters.Add("v_maduyet", NpgsqlDbType.Numeric).Value = v_maduyet;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + mmyy(v_ngay) + ".v_miennoitru (id,lydo,ghichu,maduyet)";
                    sql += " values (:v_id,:v_lydo,:v_ghichu,:v_maduyet)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    cmd.Parameters.Add("v_lydo", NpgsqlDbType.Numeric).Value = v_lydo;
                    cmd.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;
                    cmd.Parameters.Add("v_maduyet", NpgsqlDbType.Numeric).Value = v_maduyet;
                    irec = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(v_ngay, ex.Message, sComputer, "v_miennoitru");
                return false;
            }
            finally
            {
                con.Close(); con.Dispose();
            }
            return true;
        }

		public bool upd_vpkhoa(decimal v_id,string v_mabn,decimal v_mavaovien,decimal v_maql,decimal v_idkhoa,string v_ngay,string v_makp,int v_madoituong,int v_mavp,decimal v_soluong,decimal v_dongia,decimal v_vattu,int v_userid,int v_buoi)
		{
            schema = user + mmyy(v_ngay) + ".upd_vpkhoa";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
			try
			{
				con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_mabn", NpgsqlDbType.Varchar).Value = v_mabn;
                cmd.Parameters.Add("v_mavaovien", NpgsqlDbType.Numeric).Value = v_mavaovien;
                cmd.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                cmd.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
                cmd.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 16).Value = v_ngay;
                cmd.Parameters.Add("v_makp", NpgsqlDbType.Varchar, i_maxlength_makp).Value = v_makp;
                cmd.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
                cmd.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
                cmd.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
                cmd.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;
                cmd.Parameters.Add("v_vattu", NpgsqlDbType.Numeric).Value = v_vattu;
                cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                cmd.Parameters.Add("v_buoi", NpgsqlDbType.Numeric).Value = v_buoi;
				cmd.ExecuteNonQuery();
			}
			catch(NpgsqlException ex)
			{
				upd_error(v_ngay,ex.Message,sComputer,"v_vpkhoa");
				return false;
			}
			finally
			{
				cmd.Dispose();
				con.Close(); con.Dispose();
			}
			return true;
		}

		public bool upd_lydomien(int v_id,string v_ten)
		{
            sql = "update " + user + ".v_lydomien set ten=:v_ten where id=:v_id";
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
                cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".v_lydomien (id,ten) values (:v_id,:v_ten)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    irec = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
			catch(NpgsqlException ex)
			{
				upd_error(ex.Message,sComputer,"v_lydomien");
				return false;
			}
			finally
			{
                con.Close(); con.Dispose();
			}
			return true;
		}

		public bool upd_phieuchill(string ngay,decimal v_id,decimal v_quyenso,decimal v_sobienlai,string v_ngay,string v_mabn,decimal v_maql,decimal v_idkhoa,string v_makp,string v_hoten,int v_loai,int v_loaibn,int v_userid)
		{
            schema = user + mmyy(ngay) + ".upd_phieuchill";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
			try
			{
				con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_quyenso", NpgsqlDbType.Numeric).Value = v_quyenso;
                cmd.Parameters.Add("v_sobienlai", NpgsqlDbType.Numeric).Value = v_sobienlai;
                cmd.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 16).Value = v_ngay;
                cmd.Parameters.Add("v_mabn", NpgsqlDbType.Varchar).Value = v_mabn;
                cmd.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                cmd.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
                cmd.Parameters.Add("v_makp", NpgsqlDbType.Varchar, i_maxlength_makp).Value = v_makp;
                cmd.Parameters.Add("v_hoten", NpgsqlDbType.Text).Value = v_hoten;
                cmd.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                cmd.Parameters.Add("v_loaibn", NpgsqlDbType.Numeric).Value = v_loaibn;
                cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
				cmd.ExecuteNonQuery();
			}
			catch(NpgsqlException ex)
			{
				upd_error(ngay,ex.Message,sComputer,"v_phieuchill");
				return false;
			}
			finally
			{
				cmd.Dispose();
				con.Close(); con.Dispose();
			}
			return true;
		}

		public bool upd_phieuchict(string ngay,decimal v_id,int v_stt,int v_mavp,decimal v_sotien)
		{
            schema = user + mmyy(ngay) + ".upd_phieuchict";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
			try
			{
				con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                cmd.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
                cmd.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
				cmd.ExecuteNonQuery();
			}
			catch(NpgsqlException ex)
			{
				upd_error(ngay,ex.Message,sComputer,"v_phieuchict");
				return false;
			}
			finally
			{
				cmd.Dispose();
				con.Close(); con.Dispose();
			}
			return true;
		}

		public int get_stt(DataTable dt,string cot)
		{
			if (dt.Rows.Count==0) return 1;
			else return int.Parse(dt.Rows[dt.Rows.Count-1][cot].ToString())+1;
		}

		public int get_stt(DataTable dt)
		{
			if (dt.Rows.Count==0) return 1;
			else return int.Parse(dt.Rows[dt.Rows.Count-1]["stt"].ToString())+1;
		}

        public int get_stt(DataTable dt,int userid)
        {
            int ret = 1;
            foreach(DataRow r in dt.Select("userid=" + userid))
                if (int.Parse(r["stt"].ToString()) > ret) ret = int.Parse(r["stt"].ToString());
            return ret;
        }

		public string get_tenvp(string ngay,decimal id)
		{
			string ret="",xxx=user+mmyy(ngay);
			decimal sotien=0;
			sql="select d.ten,sum(round(b.soluong*b.dongia+b.soluong*b.vattu-b.mien-b.thieu,0)) as sotien from "+xxx+".v_vienphill a,"+xxx+".v_vienphict b,"+user+".v_giavp c,"+user+".v_loaivp d";
			sql+=" where a.id=b.id and b.mavp=c.id and c.id_loai=d.id and a.id="+id+" group by d.ten";
			foreach(DataRow r in get_data(sql).Tables[0].Rows)
			{
				sotien=decimal.Parse(r["sotien"].ToString());
				ret+=r["ten"].ToString().Trim()+": "+sotien.ToString("###,###,###,##0").Trim()+";";
			}
			return (ret!="")?ret.Substring(0,ret.Length-1):"";
		}

		public string get_nhomvp(string ngay,decimal id)
		{
			string ret="",xxx=user+mmyy(ngay);
			decimal sotien=0;
			sql="select c.ten,sum(round(b.soluong*b.dongia+b.soluong*b.vattu-b.mien-b.thieu,0)) as sotien from "+xxx+".v_vienphill a,"+xxx+".v_vienphict b,"+user+".v_nhomvp c";
			sql+=" where a.id=b.id and b.mavp=c.ma and a.id="+id+" group by c.ten";
			foreach(DataRow r in get_data(sql).Tables[0].Rows)
			{
				sotien=decimal.Parse(r["sotien"].ToString());
				ret+=r["ten"].ToString().Trim()+": "+sotien.ToString("###,###,###,##0").Trim()+";";
			}
			return (ret!="")?ret.Substring(0,ret.Length-1):"";
		}

		public string get_tenvpct(string ngay,decimal id)
		{
			string ret="",xxx=user+mmyy(ngay);
			decimal sotien=0;
			sql="select b.ten,sum(round(b.soluong*b.dongia+b.soluong*b.vattu-b.mien-b.thieu,0)) as sotien from "+xxx+".v_vienphill a,"+xxx+".v_vienphict b";
			sql+=" where a.id=b.id and a.id="+id+" group by b.ten";
			foreach(DataRow r in get_data(sql).Tables[0].Rows)
			{
				sotien=decimal.Parse(r["sotien"].ToString());
				ret+=r["ten"].ToString().Trim()+": "+sotien.ToString("###,###,###,##0").Trim()+";";
			}
			return (ret!="")?ret.Substring(0,ret.Length-1):"";
		}

		public void updrec_tamung(DataTable dt,decimal id,string mabn,decimal mavaovien,decimal maql,decimal idkhoa,string hoten,string namsinh,string diachi,string cholam,decimal quyenso,string sohieu,decimal sobienlai,int loai,int loaibn,string makp,int madoituong,decimal sotien)
		{
			string exp="id="+id;
			DataRow r = getrowbyid (dt,exp); 
			if ( r == null )
			{
				DataRow nrow = dt.NewRow ( ) ;
				nrow["id"] = id;
				nrow["mabn"] = mabn;
                nrow["mavaovien"] = mavaovien;
				nrow["maql"] = maql;
				nrow["idkhoa"] = idkhoa;
				nrow["hoten"] = hoten;
				nrow["namsinh"]=namsinh;
				nrow["diachi"]=diachi;
				nrow["cholam"]=cholam;
				nrow["quyenso"]=quyenso;
				nrow["sohieu"]=sohieu;
				nrow["sobienlai"]=sobienlai;
				nrow["loai"]=loai;
				nrow["loaibn"]=loaibn;
				nrow["makp"]=makp;
				nrow["madoituong"]=madoituong;
				nrow["sotien"]=sotien;
				nrow["lanin"]=0;
			    dt.Rows.Add ( nrow ) ;
			}
			else
			{
				DataRow[] dr = dt.Select(exp);
				dr[0]["mabn"] = mabn;
                dr[0]["mavaovien"] = mavaovien;
				dr[0]["maql"] = maql;
				dr[0]["idkhoa"] = idkhoa;
				dr[0]["hoten"] = hoten;
				dr[0]["namsinh"]=namsinh;
				dr[0]["diachi"]=diachi;
				dr[0]["cholam"]=cholam;
				dr[0]["quyenso"]=quyenso;
				dr[0]["sohieu"]=sohieu;
				dr[0]["sobienlai"]=sobienlai;
				dr[0]["loai"]=loai;
				dr[0]["loaibn"]=loaibn;
				dr[0]["makp"]=makp;
				dr[0]["madoituong"]=madoituong;
				dr[0]["sotien"]=sotien;
			}
		}

		public void updrec_tamungct(DataTable dt,decimal loaivp,string ten)
		{
			string exp="loaivp="+loaivp;
			DataRow r = getrowbyid (dt,exp); 
			if ( r == null )
			{
				DataRow nrow = dt.NewRow ( ) ;
				nrow["loaivp"] = loaivp;
				nrow["ten"] = ten;
				nrow["sotien"]=0;
				dt.Rows.Add ( nrow ) ;
			}
		}

		public bool upd_lydonopthem(decimal v_id,int v_id_lydo)
		{
            sql = "update " + user + ".v_lydonopthem set id_lydo=:v_id_lydo where id=:v_id";
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
                cmd.Parameters.Add("v_id_lydo", NpgsqlDbType.Numeric).Value = v_id_lydo;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".v_lydonopthem (id,id_lydo) values (:v_id,:v_id_lydo)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    cmd.Parameters.Add("v_id_lydo", NpgsqlDbType.Numeric).Value = v_id_lydo;
                    irec = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
			catch(NpgsqlException ex)
			{
				upd_error(ex.Message,sComputer,"v_lydonopthem");
				return false;
			}
			finally
			{
                con.Close(); con.Dispose();
			}
			return true;
		}

		public bool upd_lydothieu(decimal v_id,int v_id_lydo)
		{
            sql = "update " + user + ".v_lydothieu set id_lydo=:v_id_lydo where id=:v_id";
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
                cmd.Parameters.Add("v_id_lydo", NpgsqlDbType.Numeric).Value = v_id_lydo;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".v_lydothieu (id,id_lydo) values (:v_id,:v_id_lydo)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    cmd.Parameters.Add("v_id_lydo", NpgsqlDbType.Numeric).Value = v_id_lydo;
                    irec = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
			catch(NpgsqlException ex)
			{
				upd_error(ex.Message,sComputer,"v_lydothieu");
				return false;
			}
			finally
			{
                con.Close(); con.Dispose();
			}
			return true;
		}

		public bool upd_dmlydonopthem(decimal v_id,string v_ten)
		{
            sql = "update " + user + ".v_dmlydonopthem set ten=:v_ten where id=:v_id";
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
                cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".v_dmlydonopthem (id,ten) values (:v_id,:v_ten)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    irec = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
			catch(NpgsqlException ex)
			{
				upd_error(ex.Message,sComputer,"v_dmlydonopthem");
				return false;
			}
			finally
			{
                con.Close(); con.Dispose();
			}
			return true;
		}

		public bool upd_dmlydothieu(decimal v_id,string v_ten)
		{
            sql = "update " + user + ".v_dmlydothieu set ten=:v_ten where id=:v_id";
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
                cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".v_dmlydothieu (id,ten) values (:v_id,:v_ten)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    irec = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
			catch(NpgsqlException ex)
			{
				upd_error(ex.Message,sComputer,"v_dmlydothieu");
				return false;
			}
			finally
			{
                con.Close(); con.Dispose();
			}
			return true;
		}

		public bool upd_thvpll(decimal v_id,string v_mabn,decimal v_mavaovien,decimal v_maql,decimal v_idkhoa,string v_ngayvao,
            string v_ngayra,string v_giuong,string v_makp,string v_chandoan,string v_maicd,decimal v_sotien,
            decimal v_tamung,decimal v_bhyt,decimal v_mien,string v_mmyy)
		{
            schema = user + v_mmyy + ".upd_thvpll";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
			try
			{
				con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_mabn", NpgsqlDbType.Varchar).Value = v_mabn;
                cmd.Parameters.Add("v_mavaovien", NpgsqlDbType.Numeric).Value = v_mavaovien;
                cmd.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                cmd.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
                cmd.Parameters.Add("v_ngayvao", NpgsqlDbType.Varchar, 16).Value = v_ngayvao;
                cmd.Parameters.Add("v_ngayra", NpgsqlDbType.Varchar, 16).Value = v_ngayra;
                cmd.Parameters.Add("v_giuong", NpgsqlDbType.Varchar, 100).Value = v_giuong;//khuong 05/11/2011
                cmd.Parameters.Add("v_makp", NpgsqlDbType.Varchar, i_maxlength_makp).Value = v_makp;
                cmd.Parameters.Add("v_chandoan", NpgsqlDbType.Text).Value = v_chandoan;
                cmd.Parameters.Add("v_maicd", NpgsqlDbType.Text).Value = v_maicd;
                cmd.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                cmd.Parameters.Add("v_tamung", NpgsqlDbType.Numeric).Value = v_tamung;
                cmd.Parameters.Add("v_bhyt", NpgsqlDbType.Numeric).Value = v_bhyt;
                cmd.Parameters.Add("v_mien", NpgsqlDbType.Numeric).Value = v_mien;
				cmd.ExecuteNonQuery();
			}
			catch(NpgsqlException ex)
			{
				upd_error_mmyy(v_mmyy,ex.Message,sComputer,"v_thvpll");
				return false;
			}
			finally
			{
				cmd.Dispose();
				con.Close(); con.Dispose();
			}
			return true;
		}

        /* public bool upd_thvpll(string v_mmyy, decimal v_id, string v_mabn, decimal v_maql, decimal v_idkhoa, string v_ngayvao, string v_ngayra, string v_giuong, string v_makp, string v_chandoan, string v_maicd, decimal v_sotien, decimal v_tamung, decimal v_bhyt, decimal v_mien, int v_khu)
        {
            string xxx = user + v_mmyy + ".upd_thvpll";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(xxx, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_mabn", NpgsqlDbType.Varchar).Value = v_mabn;
                cmd.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                cmd.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
                cmd.Parameters.Add("v_ngayvao", NpgsqlDbType.Varchar, 16).Value = v_ngayvao;
                cmd.Parameters.Add("v_ngayra", NpgsqlDbType.Varchar, 16).Value = v_ngayra;
                cmd.Parameters.Add("v_giuong", NpgsqlDbType.Varchar, 100).Value = v_giuong;//khuong 05/11/2011
                cmd.Parameters.Add("v_makp", NpgsqlDbType.Varchar, i_maxlength_makp).Value = v_makp;
                cmd.Parameters.Add("v_chandoan", NpgsqlDbType.Text).Value = v_chandoan;
                cmd.Parameters.Add("v_maicd", NpgsqlDbType.Varchar, 50).Value = v_maicd;
                cmd.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                cmd.Parameters.Add("v_tamung", NpgsqlDbType.Numeric).Value = v_tamung;
                cmd.Parameters.Add("v_bhyt", NpgsqlDbType.Numeric).Value = v_bhyt;
                cmd.Parameters.Add("v_mien", NpgsqlDbType.Numeric).Value = v_mien;
                cmd.Parameters.Add("v_khu", NpgsqlDbType.Numeric).Value = v_khu;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                upd_error(ex.Message, sComputer, "v_thvpll");
                return false;
            }
            finally
            {
                cmd.Dispose();
                con.Close(); con.Dispose();
            }
            return true;
        } */

        public bool upd_thvpll(decimal v_id, string v_mabn, decimal v_mavaovien, decimal v_maql, decimal v_idkhoa, string v_ngayvao,
            string v_ngayra, string v_giuong, string v_makp, string v_chandoan, string v_maicd, decimal v_sotien,
            decimal v_tamung, decimal v_bhyt, decimal v_mien, string v_mmyy,int v_chinhsach)
        {
            //schema = user + v_mmyy + ".upd_thvpll";
            string asql = "update " + user + v_mmyy + ".v_thvpll set mabn=:v_mabn,mavaovien=:v_mavaovien,"+
                "maql=:v_maql,idkhoa=:v_idkhoa,ngayvao=to_timestamp(:v_ngayvao,'dd/mm/yyyy hh24:mi'),"+
                "ngayra=to_timestamp(:v_ngayra,'dd/mm/yyyy hh24:mi'),giuong=:v_giuong,makp=:v_makp,chandoan=:v_chandoan,"+
                "maicd=:v_maicd,sotien=:v_sotien,tamung=:v_tamung,bhyt=:v_bhyt,mien=:v_mien,chinhsach=:v_chinhsach where id=:v_id";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(asql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("v_mabn", NpgsqlDbType.Varchar).Value = v_mabn;
                cmd.Parameters.Add("v_mavaovien", NpgsqlDbType.Numeric).Value = v_mavaovien;
                cmd.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                cmd.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
                cmd.Parameters.Add("v_ngayvao", NpgsqlDbType.Varchar, 16).Value = v_ngayvao;
                cmd.Parameters.Add("v_ngayra", NpgsqlDbType.Varchar, 16).Value = v_ngayra;
                cmd.Parameters.Add("v_giuong", NpgsqlDbType.Varchar, 100).Value = v_giuong;//khuong 05/11/2011
                cmd.Parameters.Add("v_makp", NpgsqlDbType.Varchar, i_maxlength_makp).Value = v_makp;
                cmd.Parameters.Add("v_chandoan", NpgsqlDbType.Text).Value = v_chandoan;
                cmd.Parameters.Add("v_maicd", NpgsqlDbType.Text).Value = v_maicd;
                cmd.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                cmd.Parameters.Add("v_tamung", NpgsqlDbType.Numeric).Value = v_tamung;
                cmd.Parameters.Add("v_bhyt", NpgsqlDbType.Numeric).Value = v_bhyt;
                cmd.Parameters.Add("v_mien", NpgsqlDbType.Numeric).Value = v_mien;
                cmd.Parameters.Add("v_chinhsach", NpgsqlDbType.Numeric).Value = v_chinhsach;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                int irc = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irc == 0)
                {
                    asql = "insert into " + user + v_mmyy + ".v_thvpll(id,mabn,mavaovien,maql,idkhoa,ngayvao"+
                        ",ngayra,giuong,makp,chandoan,maicd,sotien,tamung,bhyt,mien,done,chinhsach) values "+
                        "(:v_id,:v_mabn,:v_mavaovien,:v_maql,:v_idkhoa,to_timestamp(:v_ngayvao,'dd/mm/yyyy hh24:mi'),"+
                        "to_timestamp(:v_ngayra,'dd/mm/yyyy hh24:mi'),:v_giuong,:v_makp,:v_chandoan,:v_maicd,:v_sotien,"+
                        ":v_tamung,:v_bhyt,:v_mien,0,:v_chinhsach)";
                    cmd = new NpgsqlCommand(asql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    cmd.Parameters.Add("v_mabn", NpgsqlDbType.Varchar).Value = v_mabn;
                    cmd.Parameters.Add("v_mavaovien", NpgsqlDbType.Numeric).Value = v_mavaovien;
                    cmd.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                    cmd.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
                    cmd.Parameters.Add("v_ngayvao", NpgsqlDbType.Varchar, 16).Value = v_ngayvao;
                    cmd.Parameters.Add("v_ngayra", NpgsqlDbType.Varchar, 16).Value = v_ngayra;
                    cmd.Parameters.Add("v_giuong", NpgsqlDbType.Varchar, 100).Value = v_giuong;//khuong 05/11/2011
                    cmd.Parameters.Add("v_makp", NpgsqlDbType.Varchar, i_maxlength_makp).Value = v_makp;
                    cmd.Parameters.Add("v_chandoan", NpgsqlDbType.Text).Value = v_chandoan;
                    cmd.Parameters.Add("v_maicd", NpgsqlDbType.Text).Value = v_maicd;
                    cmd.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                    cmd.Parameters.Add("v_tamung", NpgsqlDbType.Numeric).Value = v_tamung;
                    cmd.Parameters.Add("v_bhyt", NpgsqlDbType.Numeric).Value = v_bhyt;
                    cmd.Parameters.Add("v_mien", NpgsqlDbType.Numeric).Value = v_mien;
                    cmd.Parameters.Add("v_chinhsach", NpgsqlDbType.Numeric).Value = v_chinhsach;
                    irc = cmd.ExecuteNonQuery();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error_mmyy(v_mmyy, ex.Message, sComputer, "v_thvpll");
                return false;
            }
            finally
            {
                cmd.Dispose();
                con.Close(); con.Dispose();
            }
            return true;
        }

        public bool upd_thvpct(decimal v_id, string v_ngay, string v_makp, int v_madoituong, decimal v_mavp, decimal v_soluong, decimal v_dongia,
            decimal v_sotien, decimal v_vattu, string v_mmyy, string v_sothe, string v_mabs, decimal v_idtonghop, int v_sttonghop)
        {
            //schema = user + v_mmyy + ".upd_thvpct";
            string asql = "update " + user + v_mmyy + ".v_thvpct set soluong=soluong+:v_soluong," +
                "sotien=sotien+:v_sotien,vattu=:v_vattu ";
            asql += ", idtonghop=:v_idtonghop, stttonghop=:v_stttonghop";
            asql += " where id=:v_id and to_char(ngay,'dd/mm/yyyy')" +
                "=:v_ngay and makp=:v_makp and madoituong=:v_madoituong and mavp=:v_mavp and dongia=:v_dongia;";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(asql, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
                cmd.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                cmd.Parameters.Add("v_vattu", NpgsqlDbType.Numeric).Value = v_vattu;

                cmd.Parameters.Add("v_idtonghop", NpgsqlDbType.Numeric).Value = v_idtonghop;
                cmd.Parameters.Add("v_stttonghop", NpgsqlDbType.Numeric).Value = v_sttonghop;

                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay;
                cmd.Parameters.Add("v_makp", NpgsqlDbType.Varchar, i_maxlength_makp).Value = v_makp;
                cmd.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
                cmd.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
                cmd.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    asql = "insert into " + user + v_mmyy + ".v_thvpct(id,ngay,makp,madoituong," +
                        "mavp,soluong,dongia,sotien,vattu,sothe,mabs,idtonghop,stttonghop) values (:v_id,to_timestamp(:v_ngay,'dd/mm/yyyy')," +
                        ":v_makp,:v_madoituong,:v_mavp,:v_soluong,:v_dongia,:v_sotien,:v_vattu,:v_sothe,:v_mabs, :v_idtonghop,:v_stttonghop);";

                    cmd = new NpgsqlCommand(asql, con);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    cmd.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay;
                    cmd.Parameters.Add("v_makp", NpgsqlDbType.Varchar, i_maxlength_makp).Value = v_makp;
                    cmd.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
                    cmd.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
                    cmd.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
                    cmd.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;
                    cmd.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                    cmd.Parameters.Add("v_vattu", NpgsqlDbType.Numeric).Value = v_vattu;
                    cmd.Parameters.Add("v_sothe", NpgsqlDbType.Varchar, 20).Value = v_sothe;
                    cmd.Parameters.Add("v_mabs", NpgsqlDbType.Varchar, 20).Value = v_mabs;

                    cmd.Parameters.Add("v_idtonghop", NpgsqlDbType.Numeric).Value = v_idtonghop;
                    cmd.Parameters.Add("v_stttonghop", NpgsqlDbType.Numeric).Value = v_sttonghop;
                    irec = cmd.ExecuteNonQuery();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error_mmyy(v_mmyy, ex.Message, sComputer, "v_thvpct");
                return false;
            }
            finally
            {
                cmd.Dispose();
                con.Close(); con.Dispose();
            }
            return true;
        }
        public bool upd_thvpct(decimal v_id, string v_ngay, string v_makp, int v_madoituong, decimal v_mavp, decimal v_soluong, decimal v_dongia,
            decimal v_sotien, decimal v_vattu, string v_mmyy, string v_sothe, int v_traituyen, string v_mabs, decimal v_idtonghop, int v_sttonghop)
        {
            //schema = user + v_mmyy + ".upd_thvpct";
            string asql = "update " + user + v_mmyy + ".v_thvpct set soluong=soluong+:v_soluong," +
                "sotien=sotien+:v_sotien,vattu=:v_vattu, traituyen=:v_traituyen ";
            asql += ", idtonghop=:v_idtonghop, stttonghop=:v_stttonghop";
            asql += " where id=:v_id " +
                "and to_char(ngay,'dd/mm/yyyy')=:v_ngay and makp=:v_makp and madoituong=:v_madoituong" +
                " and mavp=:v_mavp and dongia=:v_dongia and mabs=:v_mabs;";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(asql, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
                cmd.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                cmd.Parameters.Add("v_vattu", NpgsqlDbType.Numeric).Value = v_vattu;
                cmd.Parameters.Add("v_traituyen", NpgsqlDbType.Numeric, 20).Value = v_traituyen;

                cmd.Parameters.Add("v_idtonghop", NpgsqlDbType.Numeric).Value = v_idtonghop;
                cmd.Parameters.Add("v_stttonghop", NpgsqlDbType.Numeric).Value = v_sttonghop;

                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay;
                cmd.Parameters.Add("v_makp", NpgsqlDbType.Varchar, i_maxlength_makp).Value = v_makp;
                cmd.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
                cmd.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
                cmd.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;
                cmd.Parameters.Add("v_sothe", NpgsqlDbType.Varchar, 20).Value = v_sothe;
                cmd.Parameters.Add("v_mabs", NpgsqlDbType.Varchar, 20).Value = v_mabs;

                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    asql = "insert into " + user + v_mmyy + ".v_thvpct(id,ngay,makp,madoituong," +
                        "mavp,soluong,dongia,sotien,vattu,sothe, traituyen,mabs,idtonghop,stttonghop) values (:v_id," +
                        "to_timestamp(:v_ngay,'dd/mm/yyyy'),:v_makp,:v_madoituong,:v_mavp," +
                        ":v_soluong,:v_dongia,:v_sotien,:v_vattu,:v_sothe,:v_traituyen,:v_mabs,:v_idtonghop,:v_stttonghop );";

                    cmd = new NpgsqlCommand(asql, con);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    cmd.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay;
                    cmd.Parameters.Add("v_makp", NpgsqlDbType.Varchar, i_maxlength_makp).Value = v_makp;
                    cmd.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
                    cmd.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
                    cmd.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
                    cmd.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;
                    cmd.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                    cmd.Parameters.Add("v_vattu", NpgsqlDbType.Numeric).Value = v_vattu;
                    cmd.Parameters.Add("v_sothe", NpgsqlDbType.Varchar, 20).Value = v_sothe;
                    cmd.Parameters.Add("v_traituyen", NpgsqlDbType.Numeric, 20).Value = v_traituyen;
                    cmd.Parameters.Add("v_mabs", NpgsqlDbType.Varchar, 20).Value = v_mabs;
                    cmd.Parameters.Add("v_idtonghop", NpgsqlDbType.Numeric).Value = v_idtonghop;
                    cmd.Parameters.Add("v_stttonghop", NpgsqlDbType.Numeric).Value = v_sttonghop;
                    irec = cmd.ExecuteNonQuery();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error_mmyy(v_mmyy, ex.Message, sComputer, "v_thvpct");
                return false;
            }
            finally
            {
                cmd.Dispose();
                con.Close(); con.Dispose();
            }
            return true;
        }

        public bool upd_thvpct(decimal v_id, string v_ngay, string v_makp, int v_madoituong, decimal v_mavp, decimal v_soluong, decimal v_dongia,
           decimal v_sotien, decimal v_vattu, string v_mmyy, string v_sothe, int v_traituyen, decimal v_giachenhlech )
        {
            string schema = user + v_mmyy;
            string asql = " update " + schema + ".v_thvpct set soluong=soluong+:v_soluong,sotien=sotien+:v_sotien,vattu=:v_vattu, traituyen=:v_traituyen, giachenhlech=:v_giachenhlech ";
            asql += " where id=:v_id and to_char(ngay,'dd/mm/yyyy')=:v_ngay and makp=:v_makp and madoituong=:v_madoituong and mavp=:v_mavp and dongia=:v_dongia";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(asql, con);
                cmd.CommandType = CommandType.Text ;
                cmd.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
                cmd.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                cmd.Parameters.Add("v_vattu", NpgsqlDbType.Numeric).Value = v_vattu;
                cmd.Parameters.Add("v_traituyen", NpgsqlDbType.Numeric).Value = v_traituyen;
                cmd.Parameters.Add("v_giachenhlech", NpgsqlDbType.Numeric).Value = v_giachenhlech;

                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay;
                cmd.Parameters.Add("v_makp", NpgsqlDbType.Varchar, i_maxlength_makp).Value = v_makp;
                cmd.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
                cmd.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;                
                cmd.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;                
                //cmd.Parameters.Add("v_sothe", NpgsqlDbType.Varchar, 20).Value = v_sothe;
                
                int i_rec=cmd.ExecuteNonQuery();
                if (i_rec == 0)
                {                    
                    cmd.Dispose();
                    asql += "insert into " + schema + ".v_thvpct(id,ngay,makp,madoituong,mavp,soluong,dongia,sotien,vattu,sothe, traituyen, giachenhlech) ";
                    asql += " values (:v_id,to_timestamp(:v_ngay,'dd/mm/yyyy'),:v_makp,:v_madoituong,:v_mavp,:v_soluong,:v_dongia,:v_sotien,:v_vattu,:v_sothe,:v_traituyen,:v_giachenhlech)";
                    cmd = new NpgsqlCommand(asql, con);
                    cmd.CommandType = CommandType.Text;   
                 
                    cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    cmd.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay;
                    cmd.Parameters.Add("v_makp", NpgsqlDbType.Varchar, i_maxlength_makp).Value = v_makp;
                    cmd.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
                    cmd.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
                    cmd.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
                    cmd.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;
                    cmd.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                    cmd.Parameters.Add("v_vattu", NpgsqlDbType.Numeric).Value = v_vattu;
                    cmd.Parameters.Add("v_sothe", NpgsqlDbType.Varchar, 20).Value = v_sothe;
                    cmd.Parameters.Add("v_traituyen", NpgsqlDbType.Numeric).Value = v_traituyen;
                    cmd.Parameters.Add("v_giachenhlech", NpgsqlDbType.Numeric).Value = v_giachenhlech;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (NpgsqlException ex)
            {
                upd_error_mmyy(v_mmyy, ex.Message, sComputer, "v_thvpct");
                return false;
            }
            finally
            {
                cmd.Dispose();
                con.Close(); con.Dispose();
            }
            return true;
        }

		public bool upd_thvpbhyt(decimal v_id,string v_sothe,decimal v_maphu,string v_noigioithieu,string v_noicap,string v_mmyy,int v_traituyen)
		{
            schema = user + v_mmyy + ".upd_thvpbhyt";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
			try
			{
				con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_sothe", NpgsqlDbType.Varchar, 20).Value = v_sothe;
                cmd.Parameters.Add("v_maphu", NpgsqlDbType.Numeric).Value = v_maphu;
                cmd.Parameters.Add("v_noigioithieu", NpgsqlDbType.Varchar, 8).Value = v_noigioithieu;
                cmd.Parameters.Add("v_noicap", NpgsqlDbType.Varchar, 8).Value = v_noicap;
                cmd.Parameters.Add("v_traituyen", NpgsqlDbType.Numeric).Value = v_traituyen;
				cmd.ExecuteNonQuery();
			}
			catch(NpgsqlException ex)
			{
				upd_error_mmyy(v_mmyy,ex.Message,sComputer,"v_thvpbhyt");
				return false;
			}
			finally
			{
				cmd.Dispose();
				con.Close(); con.Dispose();
			}
			return true;
		}

		public bool upd_paid(string v_mabn,decimal v_mavaovien,decimal v_maql,decimal v_idkhoa,string v_ngayvao,string v_ngayra)
		{
            schema = user + ".upd_paid";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
			try
			{
				con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_mabn", NpgsqlDbType.Varchar).Value = v_mabn;
                cmd.Parameters.Add("v_mavaovien", NpgsqlDbType.Numeric).Value = v_mavaovien;
                cmd.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                cmd.Parameters.Add("v_idkhoa", NpgsqlDbType.Numeric).Value = v_idkhoa;
                cmd.Parameters.Add("v_ngayvao", NpgsqlDbType.Varchar, 16).Value = v_ngayvao;
                cmd.Parameters.Add("v_ngayra", NpgsqlDbType.Varchar, 16).Value = v_ngayra;
				cmd.ExecuteNonQuery();
			}
			catch(NpgsqlException ex)
			{
				upd_error(ex.Message,sComputer,"v_paid");
				return false;
			}
			finally
			{
				cmd.Dispose();
				con.Close(); con.Dispose();
			}
			return true;
		}

		public bool upd_thngayll(string ngay,decimal v_id,int v_madoituong,string v_mabn,decimal v_maql,string v_ngayvao,string v_tu,string v_den,string v_giuong,string v_makp)
		{
            schema = user + mmyy(ngay) + ".upd_thngayll";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
			try
			{
				con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
                cmd.Parameters.Add("v_mabn", NpgsqlDbType.Varchar).Value = v_mabn;
                cmd.Parameters.Add("v_maql", NpgsqlDbType.Numeric).Value = v_maql;
                cmd.Parameters.Add("v_ngayvao", NpgsqlDbType.Varchar, 10).Value = v_ngayvao;
                cmd.Parameters.Add("v_tu", NpgsqlDbType.Varchar, 10).Value = v_tu;
                cmd.Parameters.Add("v_den", NpgsqlDbType.Varchar, 10).Value = v_den;
                cmd.Parameters.Add("v_giuong", NpgsqlDbType.Varchar, 20).Value = v_giuong;
                cmd.Parameters.Add("v_makp", NpgsqlDbType.Varchar, i_maxlength_makp).Value = v_makp;
				cmd.ExecuteNonQuery();
			}
			catch(NpgsqlException ex)
			{
				upd_error(ngay,ex.Message,sComputer,"v_thngayll");
				return false;
			}
			finally
			{
				cmd.Dispose();
				con.Close(); con.Dispose();
			}
			return true;
		}

		public bool upd_thngayct(string ngay,decimal v_id,string v_ngay,decimal v_mavp,decimal v_soluong,decimal v_dongia,decimal v_sotien)
		{
            schema = user + mmyy(ngay) + ".upd_thngayct";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
			try
			{
				con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay;
                cmd.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
                cmd.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
                cmd.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;
                cmd.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
				cmd.ExecuteNonQuery();
			}
			catch(NpgsqlException ex)
			{
				upd_error(ngay,ex.Message,sComputer,"v_thngayct");
				return false;
			}
			finally
			{
				cmd.Dispose();
				con.Close(); con.Dispose();
			}
			return true;
		}

		public void updrec_ttrvll(DataTable dt,decimal id,string mabn,decimal mavaovien,decimal maql,decimal idkhoa,string hoten,string namsinh,string diachi,string makp,string sohieu,decimal quyenso,decimal sobienlai,decimal sotien,decimal tamung,decimal bhyt,decimal mien,decimal chenhlech,string ngayvao,string ngayra,string giuong,decimal idtonghop,string maicd,string chandoan,string sothe,string mabv,int maduyet,int lydo,string ghichu)
		{
			string exp="id="+id;
			DataRow r = getrowbyid (dt,exp); 
			if ( r == null )
			{
				DataRow nrow = dt.NewRow ( ) ;
				nrow["id"] = id;
				nrow["mabn"] = mabn;
                nrow["mavaovien"] = mavaovien;
				nrow["maql"] = maql;
				nrow["hoten"] = hoten;
				nrow["namsinh"] = namsinh;
				nrow["diachi"] = diachi;
				nrow["makp"]=makp;
				nrow["idkhoa"]=idkhoa;
				nrow["sohieu"]=sohieu;
				nrow["quyenso"]=quyenso;
				nrow["sobienlai"]=sobienlai;
				nrow["mien"]=mien;
				nrow["bhyt"]=bhyt;
				nrow["sotien"]=sotien;
				nrow["tamung"]=tamung;
				nrow["chenhlech"]=chenhlech;
				nrow["ngayvao"]=ngayvao;
				nrow["ngayra"]=ngayra;
				nrow["giuong"]=giuong;
				nrow["maicd"]=maicd;
				nrow["chandoan"]=chandoan;
				nrow["lanin"]=0;
				nrow["idtonghop"]=idtonghop;
				nrow["sothe"]=sothe;
				nrow["mabv"]=mabv;
				nrow["maduyet"]=maduyet;
				nrow["lydo"]=lydo;
				nrow["ghichu"]=ghichu;
				dt.Rows.Add ( nrow ) ;
			}
			else
			{
				DataRow[] dr = dt.Select(exp);
				dr[0]["id"] = id;
				dr[0]["mabn"] = mabn;
                dr[0]["mavaovien"] = mavaovien;
				dr[0]["maql"] = maql;
				dr[0]["hoten"] = hoten;
				dr[0]["namsinh"] = namsinh;
				dr[0]["diachi"] = diachi;
				dr[0]["makp"]=makp;
				dr[0]["idkhoa"]=idkhoa;
				dr[0]["sohieu"]=sohieu;
				dr[0]["quyenso"]=quyenso;
				dr[0]["sobienlai"]=sobienlai;
				dr[0]["mien"]=mien;
				dr[0]["bhyt"]=bhyt;
				dr[0]["sotien"]=sotien;
				dr[0]["tamung"]=tamung;
				dr[0]["chenhlech"]=chenhlech;
				dr[0]["ngayvao"]=ngayvao;
				dr[0]["ngayra"]=ngayra;
				dr[0]["giuong"]=giuong;
				dr[0]["maicd"]=maicd;
				dr[0]["chandoan"]=chandoan;
				dr[0]["lanin"]=0;
				dr[0]["idtonghop"]=idtonghop;
				dr[0]["sothe"]=sothe;
				dr[0]["mabv"]=mabv;
				dr[0]["maduyet"]=maduyet;
				dr[0]["lydo"]=lydo;
				dr[0]["ghichu"]=ghichu;
			}
		}

		public void updrec_ttrvll(DataTable dt,decimal id,string mabn,decimal maql,string hoten,string namsinh,string diachi,string makp,int loaibn,string sohieu,decimal quyenso,decimal sobienlai,decimal sotien,decimal chiphi,decimal conlai,decimal tamung,string ngayvao,string ngayra,string giuong,decimal idtonghop)
		{
			string exp="id="+id;
			DataRow r = getrowbyid (dt,exp); 
			if ( r == null )
			{
				DataRow nrow = dt.NewRow ( ) ;
				nrow["id"] = id;
				nrow["mabn"] = mabn;
				nrow["maql"] = maql;
				nrow["hoten"] = hoten;
				nrow["namsinh"] = namsinh;
				nrow["diachi"] = diachi;
				nrow["makp"]=makp;
				nrow["loaibn"]=loaibn;
				nrow["sohieu"]=sohieu;
				nrow["quyenso"]=quyenso;
				nrow["sobienlai"]=sobienlai;
				nrow["conlai"]=conlai;
				nrow["chiphi"]=chiphi;
				nrow["sotien"]=sotien;
				nrow["tamung"]=tamung;
				nrow["ngayvao"]=ngayvao;
				nrow["ngayra"]=ngayra;
				nrow["giuong"]=giuong;
				nrow["lanin"]=0;
				nrow["idtonghop"]=idtonghop;
				dt.Rows.Add ( nrow ) ;
			}
			else
			{
				DataRow[] dr = dt.Select(exp);
				dr[0]["id"] = id;
				dr[0]["mabn"] = mabn;
				dr[0]["maql"] = maql;
				dr[0]["hoten"] = hoten;
				dr[0]["namsinh"] = namsinh;
				dr[0]["diachi"] = diachi;
				dr[0]["makp"]=makp;
				dr[0]["loaibn"]=loaibn;
				dr[0]["sohieu"]=sohieu;
				dr[0]["quyenso"]=quyenso;
				dr[0]["sobienlai"]=sobienlai;
				dr[0]["conlai"]=conlai;
				dr[0]["chiphi"]=chiphi;
				dr[0]["sotien"]=sotien;
				dr[0]["tamung"]=tamung;
				dr[0]["ngayvao"]=ngayvao;
				dr[0]["giuong"]=giuong;
				dr[0]["ngayra"]=ngayra;
				dr[0]["idtonghop"]=idtonghop;
			}
		}

		public string get_tenbv(string mabv)
		{
			ds=get_data("select tenbv from "+user+".dmnoicapbhyt where mabv='"+mabv+"'");
			if (ds.Tables[0].Rows.Count>0) return ds.Tables[0].Rows[0]["tenbv"].ToString();
			else return "";
		}
		public decimal gia_t_pttt(int loai)
		{
			if (loai>=1 && loai<=3) return Loai1_t;
			else if (loai>=4 && loai<=6) return Loai2_t;
			else return Loai3_t;
		}
		public decimal gia_s_pttt(int loai)
		{
			if (loai>=1 && loai<=3) return Loai1_s;
			else if (loai>=4 && loai<=6) return Loai2_s;
			else return Loai3_s;
		}
		public decimal sotien_pttt(int loai)
		{
			if (loai>=1 && loai<=3) return Loai1;
			else if (loai>=4 && loai<=6) return Loai2;
			else return Loai3;
		}

		public void updrec_ptttct (DataTable dt,int stt,int loaipt,int songay,decimal dongia)
		{
			string exp="stt="+stt;
			DataRow r = getrowbyid (dt,exp); 
			if ( r == null )
			{
				DataRow nrow = dt.NewRow ( ) ;
				nrow["stt"] = stt;
				nrow["loaipt"] = loaipt;
				nrow["songay"] = songay;
				nrow["dongia"] = dongia;
				nrow["sotien"] = songay*dongia;
				dt.Rows.Add ( nrow ) ;
			}
			else
			{
				DataRow[] dr = dt.Select(exp);
				dr[0]["stt"] = stt;
				dr[0]["loaipt"] = loaipt;
				dr[0]["songay"] = songay;
				dr[0]["dongia"] = dongia;
				dr[0]["sotien"] = songay*dongia;
			}
		}
		public decimal get_chenhlech(int mavp,string makp,int songay)
		{
			decimal st=0,gia=0,giadv=0;
			int magiuong=(makp==makp_nhi)?Giuong_khoanhi:Giuong_loai1;
			ds=get_data("select * from "+user+".v_giavp where id in ("+mavp.ToString()+","+magiuong.ToString()+")");
			DataRow r;
			r=getrowbyid(ds.Tables[0],"id="+mavp);
			if (r!=null) giadv=decimal.Parse(r["gia_th"].ToString());
			r=getrowbyid(ds.Tables[0],"id="+magiuong);
			if (r!=null) gia=decimal.Parse(r["gia_th"].ToString());
			if (gia!=0 && giadv!=0) st=songay*(giadv-gia);
			return st;
		}

		public bool upd_khambenh(string v_ngay,string v_kyhieu,decimal v_tu,decimal v_den,decimal v_nguoilon,decimal v_treem,int v_userid)
		{
            schema = user + ".upd_khambenh";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
			try
			{
				con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay;
                cmd.Parameters.Add("v_kyhieu", NpgsqlDbType.Varchar, 20).Value = v_kyhieu;
                cmd.Parameters.Add("v_tu", NpgsqlDbType.Numeric).Value = v_tu;
                cmd.Parameters.Add("v_den", NpgsqlDbType.Numeric).Value = v_den;
                cmd.Parameters.Add("v_nguoilon", NpgsqlDbType.Numeric).Value = v_nguoilon;
                cmd.Parameters.Add("v_treem", NpgsqlDbType.Numeric).Value = v_treem;
                cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
				cmd.ExecuteNonQuery();
			}
			catch(NpgsqlException ex)
			{
				upd_error(ex.Message,sComputer,"v_khambenh");
				return false;
			}
			finally
			{
				cmd.Dispose();
				con.Close(); con.Dispose();
			}
			return true;
		}

		public void clear_form()
		{
			string tenfile="v_tt2_tg";
			ds=new DataSet();
			ds.ReadXml("..//..//..//xml//m_loai.xml");
			DataColumn dc=new DataColumn();
			dc.ColumnName="frmTructiep2";
			dc.DataType=Type.GetType("System.String");
			ds.Tables[0].Columns.Add(dc);
			dc=new DataColumn();
			dc.ColumnName="frmTrongoi";
			dc.DataType=Type.GetType("System.String");
			ds.Tables[0].Columns.Add(dc);
			ds.Clear();
			DataRow r1=ds.Tables[0].NewRow();
			r1["frmTructiep2"]="0";
			r1["frmTrongoi"]="0";
			ds.Tables[0].Rows.Add(r1);
			ds.WriteXml("..//..//..//xml//"+tenfile+".xml");
		}

		public void writeXml(string cot,string s)
		{
			string tenfile="v_tt2_tg";
			ds=new DataSet();
			ds.ReadXml("..//..//..//xml//"+tenfile+".xml");
			ds.Tables[0].Rows[0][cot]=s;
			ds.WriteXml("..//..//..//xml//"+tenfile+".xml");
		}

		public bool open_2_form
		{
			get
			{
				ds=new DataSet();
				ds.ReadXml("..//..//..//xml//v_tt2_tg.xml");
				return ds.Tables[0].Rows[0]["frmTructiep2"].ToString()=="1" && ds.Tables[0].Rows[0]["frmTrongoi"].ToString()=="1";
			}
		}

		public string holot_ten(string hoten)
		{
			string holot="",ten=hoten;
			hoten=hoten.Trim();
			for(;;)
			{
				if (hoten.IndexOf("  ")==-1) break;
				hoten=hoten.Replace("  "," ");
			}
			int pos=hoten.LastIndexOf(" ");
			if (pos!=-1)
			{
				ten=hoten.Substring(pos+1);
				holot=hoten.Substring(0,pos);
			}
			return holot+"~"+ten;
		}

		public bool upd_ghichu(int v_id,string v_ten)
		{
			sql="update "+user+".v_ghichu set ten=:v_ten where id=:v_id";
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
                cmd.Parameters.Add("v_ten", NpgsqlDbType.Text, 50).Value = v_ten;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
				int irec=cmd.ExecuteNonQuery();
				cmd.Dispose();
				if (irec==0)
				{
					sql="insert into "+user+".v_ghichu (id,ten) values (:v_id,:v_ten)";
					cmd=new NpgsqlCommand(sql,con);
					cmd.CommandType=CommandType.Text;
					cmd.Parameters.Add("v_ten",NpgsqlDbType.Text,50).Value=v_ten;
					cmd.Parameters.Add("v_id",NpgsqlDbType.Numeric).Value=v_id;
					irec=cmd.ExecuteNonQuery();
					cmd.Dispose();
				}
			}
			catch(NpgsqlException ex)
			{
				upd_error(ex.Message.ToString().Trim(),sComputer,"v_ghichu");
				return false;
			}
			finally
			{
                con.Close(); con.Dispose();
			}		
			return true;
		}

		public DataSet get_vienphi(string tu,string den,string str)
		{
            //if (ds != null)
            //{
            //    ds.Dispose();
            //    ds = null;
            //}
            DataSet dstmp = new DataSet();
            DateTime dt1 = StringToDate(tu);
            DateTime dt2 = StringToDate(den);
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
                        sql = str.Replace("xxx", user + mmyy);
                        if (be)
                        {
                            dstmp = get_data(sql);
                            be = false;
                        }
                        else dstmp.Merge(get_data(sql));
                    }
                }
            }
            return dstmp;
		}

        public bool upd_huybienlai(decimal v_id, string v_tables, int v_loai, string v_mabn, string v_hoten, string v_makp, string v_ngay, decimal v_quyenso, decimal v_sobienlai, string v_lydo, int v_userid)
        {
            schema = user + mmyy(v_ngay) + ".upd_huybienlai";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_tables", NpgsqlDbType.Varchar, 20).Value = v_tables;
                cmd.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                cmd.Parameters.Add("v_mabn", NpgsqlDbType.Varchar).Value = v_mabn;
                cmd.Parameters.Add("v_hoten", NpgsqlDbType.Text).Value = v_hoten;
                cmd.Parameters.Add("v_makp", NpgsqlDbType.Varchar, i_maxlength_makp).Value = v_makp;
                cmd.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay;
                cmd.Parameters.Add("v_quyenso", NpgsqlDbType.Numeric).Value = v_quyenso;
                cmd.Parameters.Add("v_sobienlai", NpgsqlDbType.Numeric).Value = v_sobienlai;
                cmd.Parameters.Add("v_lydo", NpgsqlDbType.Text).Value = v_lydo;
                cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                upd_error(v_ngay,ex.Message, sComputer, "v_huybienlai");
                return false;
            }
            finally
            {
                cmd.Dispose();
                con.Close(); con.Dispose();
            }
            return true;
        }

        public string Ngayhienhanh
        {
            get { return ngayhienhanh_server.Substring(0, 10);}// DateTime.Now.Day.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Year.ToString(); }
        }

        public string mmyy(string ngay)
        {
            ngay = (ngay == "") ? ngayhienhanh_server.Substring(0, 1) : ngay;
            return ngay.Substring(3, 2) + ngay.Substring(8, 2);
        }

        public bool bMmyy(string m_mmyy)
        {
            return get_data("select * from " + user + ".table where mmyy='" + m_mmyy + "'").Tables[0].Rows.Count > 0;
        }
        public bool kiemtra_sobienlai(decimal id, string ngay, decimal quyenso, decimal sobienlai, int userid)
        {
            sql = "select sobienlai from v_vienphill where id<>" + id + " and to_char(ngay,'dd/mm/yyyy')='" + ngay + "' and quyenso=" + quyenso + " and sobienlai=" + sobienlai + " and userid=" + userid;
            return get_data(sql).Tables[0].Rows.Count > 0;
        }

        private bool xxxx(string xx)
        {
            sql = "update xx set ";
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
                cmd.Parameters.Add("xx", NpgsqlDbType.Varchar).Value = xx;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into xx (xx) values (:xx)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("xx", NpgsqlDbType.Varchar).Value = xx;
                    irec = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message, sComputer,xx);
                return false;
            }
            finally
            {
                con.Close(); con.Dispose();
            }
            return true;
        }

        public bool upd_ng_dmloainv(decimal v_id,decimal v_stt,string v_ma,string v_ten,int v_userid)
        {
            sql = "update " + user + ".ng_dmloainv set stt=:v_stt,ma=:v_ma,ten=:v_ten,userid=:v_userid where id=:v_id";
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
                cmd.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                cmd.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
                cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".ng_dmloainv (id,stt,ma,ten,userid) values (:v_id,:v_stt,:v_ma,:v_ten,:v_userid)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    cmd.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    cmd.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
                    cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                    irec = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message, sComputer, "ng_dmloainv");
                return false;
            }
            finally
            {
                con.Close(); con.Dispose();
            }
            return true;
        }

        public bool upd_ng_dmnv(string v_ngay,decimal v_id, decimal v_stt, string v_ma, string v_ten, int v_idloai, int v_userid)
        {
            string xxx = user + mmyy(v_ngay);
            sql = "update " + xxx + ".ng_dmnv set stt=:v_stt,ma=:v_ma,ten=:v_ten,idloai=:v_idloai,userid=:v_userid where id=:v_id and to_char(ngay,'dd/mm/yyyy')=:v_ngay";
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
                cmd.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                cmd.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
                cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                cmd.Parameters.Add("v_idloai", NpgsqlDbType.Numeric).Value = v_idloai;
                cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + xxx + ".ng_dmnv (ngay,id,stt,ma,ten,idloai,userid) values (to_timestamp(:v_ngay,'dd/mm/yyyy'),:v_id,:v_stt,:v_ma,:v_ten,:v_idloai,:v_userid)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("v_ngay", NpgsqlDbType.Varchar,10).Value = v_ngay;
                    cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    cmd.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    cmd.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
                    cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    cmd.Parameters.Add("v_idloai", NpgsqlDbType.Numeric).Value = v_idloai;
                    cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                    irec = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(v_ngay,ex.Message, sComputer, "ng_dmnv");
                return false;
            }
            finally
            {
                con.Close(); con.Dispose();
            }
            return true;
        }

        public bool upd_ng_dmnv(decimal v_id, decimal v_stt, string v_ma, string v_ten,int v_idloai, int v_userid)
        {
            sql = "update " + user + ".ng_dmnv set stt=:v_stt,ma=:v_ma,ten=:v_ten,idloai=:v_idloai,userid=:v_userid where id=:v_id";
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
                cmd.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                cmd.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
                cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                cmd.Parameters.Add("v_idloai", NpgsqlDbType.Numeric).Value = v_idloai;
                cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".ng_dmnv (id,stt,ma,ten,idloai,userid) values (:v_id,:v_stt,:v_ma,:v_ten,:v_idloai,:v_userid)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    cmd.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    cmd.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
                    cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    cmd.Parameters.Add("v_idloai", NpgsqlDbType.Numeric).Value = v_idloai;
                    cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                    irec = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message, sComputer, "ng_dmnv");
                return false;
            }
            finally
            {
                con.Close(); con.Dispose();
            }
            return true;
        }

        public bool upd_ng_nhomvp(decimal v_id, decimal v_stt, string v_ma, string v_ten, int v_userid)
        {
            sql = "update " + user + ".ng_nhomvp set stt=:v_stt,ma=:v_ma,ten=:v_ten,userid=:v_userid where id=:v_id";
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
                cmd.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                cmd.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
                cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".ng_nhomvp (id,stt,ma,ten,userid) values (:v_id,:v_stt,:v_ma,:v_ten,:v_userid)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    cmd.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    cmd.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
                    cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                    irec = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message, sComputer, "ng_nhomvp");
                return false;
            }
            finally
            {
                con.Close(); con.Dispose();
            }
            return true;
        }

        public bool upd_ng_loaivp(decimal v_id, decimal v_stt, string v_ma, string v_ten, int v_idnhom, int v_userid)
        {
            sql = "update " + user + ".ng_loaivp set stt=:v_stt,ma=:v_ma,ten=:v_ten,idnhom=:v_idnhom,userid=:v_userid where id=:v_id";
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
                cmd.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                cmd.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
                cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                cmd.Parameters.Add("v_idnhom", NpgsqlDbType.Numeric).Value = v_idnhom;
                cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".ng_loaivp (id,stt,ma,ten,idnhom,userid) values (:v_id,:v_stt,:v_ma,:v_ten,:v_idnhom,:v_userid)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    cmd.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    cmd.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
                    cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    cmd.Parameters.Add("v_idnhom", NpgsqlDbType.Numeric).Value = v_idnhom;
                    cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                    irec = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message, sComputer, "ng_loaivp");
                return false;
            }
            finally
            {
                con.Close(); con.Dispose();
            }
            return true;
        }

        public bool upd_ng_giavp(decimal v_id, decimal v_stt, string v_ma, string v_ten,string v_dvt,int v_idloai,decimal v_dongia,decimal v_tylenop,decimal v_tylechia,decimal v_sotiennop,int v_userid,int v_tongso)
        {
            sql = "update " + user + ".ng_giavp set stt=:v_stt,ma=:v_ma,ten=:v_ten,dvt=:v_dvt,idloai=:v_idloai,dongia=:v_dongia,tylenop=:v_tylenop,tylechia=:v_tylechia,sotiennop=:v_sotiennop,userid=:v_userid,tongso=:v_tongso where id=:v_id";
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
                cmd.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                cmd.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
                cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                cmd.Parameters.Add("v_dvt", NpgsqlDbType.Text).Value = v_dvt;
                cmd.Parameters.Add("v_idloai", NpgsqlDbType.Numeric).Value = v_idloai;
                cmd.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;
                cmd.Parameters.Add("v_tylenop", NpgsqlDbType.Numeric).Value = v_tylenop;
                cmd.Parameters.Add("v_tylechia", NpgsqlDbType.Numeric).Value = v_tylechia;
                cmd.Parameters.Add("v_sotiennop", NpgsqlDbType.Numeric).Value = v_sotiennop;
                cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                cmd.Parameters.Add("v_tongso", NpgsqlDbType.Numeric).Value = v_tongso;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".ng_giavp (id,stt,ma,ten,dvt,idloai,dongia,tylenop,tylechia,sotiennop,userid,tongso) values (:v_id,:v_stt,:v_ma,:v_ten,:v_dvt,:v_idloai,:v_dongia,:v_tylenop,:v_tylechia,:v_sotiennop,:v_userid,:v_tongso)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    cmd.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    cmd.Parameters.Add("v_ma", NpgsqlDbType.Varchar, 10).Value = v_ma;
                    cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    cmd.Parameters.Add("v_dvt", NpgsqlDbType.Text).Value = v_dvt;
                    cmd.Parameters.Add("v_idloai", NpgsqlDbType.Numeric).Value = v_idloai;
                    cmd.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;
                    cmd.Parameters.Add("v_tylenop", NpgsqlDbType.Numeric).Value = v_tylenop;
                    cmd.Parameters.Add("v_tylechia", NpgsqlDbType.Numeric).Value = v_tylechia;
                    cmd.Parameters.Add("v_sotiennop", NpgsqlDbType.Numeric).Value = v_sotiennop;
                    cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                    cmd.Parameters.Add("v_tongso", NpgsqlDbType.Numeric).Value = v_tongso;
                    irec = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message, sComputer, "ng_giavp");
                return false;
            }
            finally
            {
                con.Close(); con.Dispose();
            }
            return true;
        }

        public bool upd_ng_chia(decimal v_id, decimal v_stt, decimal v_idgia,int v_loainv,decimal v_phan,decimal v_soluong,decimal v_sotien)
        {
            sql = "update " + user + ".ng_chia set stt=:v_stt,idgia=:v_idgia,loainv=:v_loainv,phan=:v_phan,soluong=:v_soluong,sotien=:v_sotien where id=:v_id";
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
                cmd.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                cmd.Parameters.Add("v_idgia", NpgsqlDbType.Numeric).Value = v_idgia;
                cmd.Parameters.Add("v_loainv", NpgsqlDbType.Numeric).Value = v_loainv;
                cmd.Parameters.Add("v_phan", NpgsqlDbType.Numeric).Value = v_phan;
                cmd.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
                cmd.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".ng_chia (id,stt,idgia,loainv,phan,soluong,sotien) values (:v_id,:v_stt,:v_idgia,:v_loainv,:v_phan,:v_soluong,:v_sotien)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    cmd.Parameters.Add("v_stt", NpgsqlDbType.Numeric).Value = v_stt;
                    cmd.Parameters.Add("v_idgia", NpgsqlDbType.Numeric).Value = v_idgia;
                    cmd.Parameters.Add("v_loainv", NpgsqlDbType.Numeric).Value = v_loainv;
                    cmd.Parameters.Add("v_phan", NpgsqlDbType.Numeric).Value = v_phan;
                    cmd.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
                    cmd.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                    irec = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message, sComputer, "ng_chia");
                return false;
            }
            finally
            {
                con.Close(); con.Dispose();
            }
            return true;
        }

        public bool upd_ng_dlogin(decimal v_id, string v_hoten, string v_userid, string v_password_, string v_right_, string v_loaivp, string v_mucvp, string v_loai, int v_admin)
        {
            sql = "update " + user + ".ng_dlogin set hoten=:v_hoten,userid=:v_userid,password_=:v_password_,right_=:v_right_,loaivp=:v_loaivp,mucvp=:v_mucvp,loai=:v_loai,admin=:v_admin where id=:v_id";
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
                cmd.Parameters.Add("v_hoten", NpgsqlDbType.Text).Value = v_hoten;
                cmd.Parameters.Add("v_userid", NpgsqlDbType.Varchar, 10).Value = v_userid;
                cmd.Parameters.Add("v_password_", NpgsqlDbType.Varchar, 10).Value = v_password_;
                cmd.Parameters.Add("v_right_", NpgsqlDbType.Text).Value = v_right_;
                cmd.Parameters.Add("v_loaivp", NpgsqlDbType.Text).Value = v_loaivp;
                cmd.Parameters.Add("v_mucvp", NpgsqlDbType.Text).Value = v_mucvp;
                cmd.Parameters.Add("v_loai", NpgsqlDbType.Text).Value = v_loai;
                cmd.Parameters.Add("v_admin", NpgsqlDbType.Numeric).Value = v_admin;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".ng_dlogin (id,hoten,userid,password_,right_,loaivp,mucvp,loai,admin) values (:v_id,:v_hoten,:v_userid,:v_password_,:v_right_,:v_loaivp,:v_mucvp,:v_loai,:v_admin)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    cmd.Parameters.Add("v_hoten", NpgsqlDbType.Text).Value = v_hoten;
                    cmd.Parameters.Add("v_userid", NpgsqlDbType.Varchar, 10).Value = v_userid;
                    cmd.Parameters.Add("v_password_", NpgsqlDbType.Varchar, 10).Value = v_password_;
                    cmd.Parameters.Add("v_right_", NpgsqlDbType.Text).Value = v_right_;
                    cmd.Parameters.Add("v_loaivp", NpgsqlDbType.Text).Value = v_loaivp;
                    cmd.Parameters.Add("v_mucvp", NpgsqlDbType.Text).Value = v_mucvp;
                    cmd.Parameters.Add("v_loai", NpgsqlDbType.Text).Value = v_loai;
                    cmd.Parameters.Add("v_admin", NpgsqlDbType.Numeric).Value = v_admin;
                    irec = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message.ToString().Trim(), sComputer, "ng_dlogin");
                return false;
            }
            finally
            {
                con.Close(); con.Dispose();
            }
            return true;
        }

        public bool upd_ng_dlogin_right(decimal v_id, string v_right_)
        {
            sql = "update " + user + ".ng_dlogin set right_=:v_right_ where id=:v_id";
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
                cmd.Parameters.Add("v_right_", NpgsqlDbType.Text).Value = v_right_;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message.ToString().Trim(), sComputer, "ng_dlogin");
                return false;
            }
            finally
            {
                con.Close(); con.Dispose();
            }
            return true;
        }

        public bool upd_ng_dlogin_loaivp(decimal v_id, string v_loaivp, string v_mucvp, string v_loai,int v_admin)
        {
            sql = "update " + user + ".ng_dlogin set loaivp=:v_loaivp,mucvp=:v_mucvp,loai=:v_loai,admin=:v_admin where id=:v_id";
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
                cmd.Parameters.Add("v_loaivp", NpgsqlDbType.Text).Value = v_loaivp;
                cmd.Parameters.Add("v_mucvp", NpgsqlDbType.Text).Value = v_mucvp;
                cmd.Parameters.Add("v_loai", NpgsqlDbType.Text).Value = v_loai;
                cmd.Parameters.Add("v_admin", NpgsqlDbType.Numeric).Value = v_admin;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message.ToString().Trim(), sComputer, "ng_dlogin");
                return false;
            }
            finally
            {
                con.Close(); con.Dispose();
            }
            return true;
        }

        public bool upd_ng_tenloaivp(int v_ma, string v_ten)
        {
            sql = "update " + user + ".ng_tenloaivp set ten=:v_ten where ma=:v_ma";
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
                cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                cmd.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".ng_tenloaivp (ma,ten) values (:v_ma,:v_ten)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("v_ma", NpgsqlDbType.Numeric).Value = v_ma;
                    cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    irec = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message.ToString().Trim(), sComputer, "ng_tenloaivp");
                return false;
            }
            finally
            {
                con.Close(); con.Dispose();
            }
            return true;
        }

        public bool upd_ng_quyenso(decimal v_id, string v_ngaylinh, string v_sohieu, decimal v_tu, decimal v_den, decimal v_soghi, string v_loai,int v_userid)
        {
            sql = "update " + user + ".ng_quyenso set ngaylinh=to_timestamp(:v_ngaylinh,'dd/mm/yyyy'),sohieu=:v_sohieu,tu=:v_tu,den=:v_den,soghi=:v_soghi,loai=:v_loai,userid=:v_userid where id=:v_id";
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
                cmd.Parameters.Add("v_ngaylinh", NpgsqlDbType.Varchar, 10).Value = v_ngaylinh;
                cmd.Parameters.Add("v_sohieu", NpgsqlDbType.Varchar, 20).Value = v_sohieu;
                cmd.Parameters.Add("v_tu", NpgsqlDbType.Numeric).Value = v_tu;
                cmd.Parameters.Add("v_den", NpgsqlDbType.Numeric).Value = v_den;
                cmd.Parameters.Add("v_soghi", NpgsqlDbType.Numeric).Value = v_soghi;
                cmd.Parameters.Add("v_loai", NpgsqlDbType.Varchar, 20).Value = v_loai;
                cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".ng_quyenso(id,ngaylinh,sohieu,tu,den,soghi,dangsd,loai,userid) values (:v_id,to_timestamp(:v_ngaylinh,'dd/mm/yyyy'),:v_sohieu,:v_tu,:v_den,:v_soghi,0,:v_loai,:v_userid)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    cmd.Parameters.Add("v_ngaylinh", NpgsqlDbType.Varchar, 10).Value = v_ngaylinh;
                    cmd.Parameters.Add("v_sohieu", NpgsqlDbType.Varchar, 20).Value = v_sohieu;
                    cmd.Parameters.Add("v_tu", NpgsqlDbType.Numeric).Value = v_tu;
                    cmd.Parameters.Add("v_den", NpgsqlDbType.Numeric).Value = v_den;
                    cmd.Parameters.Add("v_soghi", NpgsqlDbType.Numeric).Value = v_soghi;
                    cmd.Parameters.Add("v_loai", NpgsqlDbType.Varchar, 20).Value = v_loai;
                    cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                    irec = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message, sComputer, "ng_quyenso");
                return false;
            }
            finally
            {
                con.Close(); con.Dispose();
            }
            return true;
        }

        public bool upd_ng_thongso(int v_id, string v_loai, string v_ten)
        {
            sql = "update " + user + ".ng_thongso set loai=:v_loai,ten=:v_ten where id=:v_id";
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
                cmd.Parameters.Add("v_loai", NpgsqlDbType.Text).Value = v_loai;
                cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                int irec = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (irec == 0)
                {
                    sql = "insert into " + user + ".ng_thongso(id,loai,ten) values (:v_id,:v_loai,:v_ten)";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    cmd.Parameters.Add("v_loai", NpgsqlDbType.Text).Value = v_loai;
                    cmd.Parameters.Add("v_ten", NpgsqlDbType.Text).Value = v_ten;
                    irec = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message, sComputer, "ng_thongso");
                return false;
            }
            finally
            {
                con.Close(); con.Dispose();
            }
            return true;
        }

        public decimal get_id_ng_loainv { get { return get_ng_capid(-7); } }
        public decimal get_id_ng_dmnv { get { return get_ng_capid(-2); } }
        public decimal get_id_ng_chia { get { return get_ng_capid(-1); } }
        public decimal get_id_ng_quyenso { get { return get_ng_capid(1); } }
        public decimal get_id_ng_nhomvp { get { return get_ng_capid(7); } }
        public decimal get_id_ng_loaivp { get { return get_ng_capid(2); } }
        public decimal get_id_ng_giavp { get { return get_capid("ng_capid", 1); } }
        public decimal get_id_ng_dlogin { get { return get_ng_capid(4); } }
        public decimal get_id_ng_vienphill
        {
            get
            {
                return getidyymmddhhmiss_stt_computer;//decimal.Parse(iRownum.ToString().PadLeft(3, '0') + get_ng_capid_may(5, sComputer).ToString().PadLeft(9, '0')); 
        } }
        public decimal get_id_ng_hoantra
        {
            get
            {
                return getidyymmddhhmiss_stt_computer;//decimal.Parse(iRownum.ToString().PadLeft(3, '0') + get_ng_capid_may(8, sComputer).ToString().PadLeft(9, '0')); 
        } }
        public decimal get_id_ng_vienphict
        {
            get
            {
                return getidyymmddhhmiss_stt_computer;//decimal.Parse(iRownum.ToString().PadLeft(3, '0') + get_ng_capid_may(9, sComputer).ToString().PadLeft(9, '0')); 
        } }

        private decimal get_ng_capid(int m_ma)
        {
            sql = "update " + user + ".ng_capid set id=id+1 where ma=:m_ma";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
            con.Open();
            cmd = new NpgsqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("m_ma", NpgsqlDbType.Numeric).Value = m_ma;
            int irec = cmd.ExecuteNonQuery();
            cmd.Dispose();
            if (irec == 0)
            {
                sql = "insert into " + user + ".ng_capid(ma,ten,id) values (:m_ma,:m_ten,1)";
                cmd = new NpgsqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("m_ma", NpgsqlDbType.Numeric).Value = m_ma;
                cmd.Parameters.Add("m_ten", NpgsqlDbType.Varchar, 20).Value = sComputer;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            sql = "select id from " + user + ".ng_capid where ma=" + m_ma;
            cmd = new NpgsqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            dest = new NpgsqlDataAdapter(cmd);
            ds = new DataSet();
            dest.Fill(ds);
            cmd.Dispose();
            con.Close(); con.Dispose();
            return decimal.Parse(ds.Tables[0].Rows[0][0].ToString());
        }

        private decimal get_ng_capid_may(int m_ma, string m_computer)
        {
            sql = "update " + user + ".ng_capid set id=id+1 where ma=:m_ma and computer=:m_computer";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
            con.Open();
            cmd = new NpgsqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("m_ma", NpgsqlDbType.Numeric).Value = m_ma;
            cmd.Parameters.Add("m_computer", NpgsqlDbType.Varchar, 20).Value = m_computer;
            int irec = cmd.ExecuteNonQuery();
            cmd.Dispose();
            if (irec == 0)
            {
                sql = "insert into " + user + ".ng_capid(ma,ten,id,computer) values (:m_ma,:m_ten,1,:m_computer)";
                cmd = new NpgsqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("m_ma", NpgsqlDbType.Numeric).Value = m_ma;
                cmd.Parameters.Add("m_ten", NpgsqlDbType.Varchar, 20).Value = m_computer;
                cmd.Parameters.Add("m_computer", NpgsqlDbType.Varchar, 20).Value = m_computer;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            sql = "select id from " + user + ".ng_capid where ma=" + m_ma + " and computer='" + m_computer + "'";
            cmd = new NpgsqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            dest = new NpgsqlDataAdapter(cmd);
            ds = new DataSet();
            dest.Fill(ds);
            cmd.Dispose();
            con.Close(); con.Dispose();
            return decimal.Parse(ds.Tables[0].Rows[0][0].ToString());
        }

        public bool upd_ng_vienphill(decimal v_id,int v_loai,decimal v_quyenso, decimal v_sobienlai, string v_ngay, string v_mabn,string v_hoten, string v_masothue,int v_userid)
        {
            schema = user + mmyy(v_ngay) + ".upd_ng_vienphill";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                cmd.Parameters.Add("v_quyenso", NpgsqlDbType.Numeric).Value = v_quyenso;
                cmd.Parameters.Add("v_sobienlai", NpgsqlDbType.Numeric).Value = v_sobienlai;
                cmd.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 16).Value = v_ngay;
                cmd.Parameters.Add("v_mabn", NpgsqlDbType.Varchar).Value = v_mabn;
                cmd.Parameters.Add("v_hoten", NpgsqlDbType.Text).Value = v_hoten;
                cmd.Parameters.Add("v_masothue", NpgsqlDbType.Varchar, 20).Value = v_masothue;
                cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                upd_error(v_ngay, ex.Message, sComputer, "ng_vienphill");
                return false;
            }
            finally
            {
                cmd.Dispose();
                con.Close(); con.Dispose();
            }
            return true;
        }

        public bool upd_ng_vienphict(string v_ngay, decimal v_id,decimal v_idll,int v_mavp, string v_ten, decimal v_soluong, decimal v_dongia, decimal v_sotiennop)
        {
            schema = user + mmyy(v_ngay) + ".upd_ng_vienphict";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_idll", NpgsqlDbType.Numeric).Value = v_idll;
                cmd.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
                cmd.Parameters.Add("v_ten", NpgsqlDbType.Text, 100).Value = v_ten;
                cmd.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
                cmd.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;
                cmd.Parameters.Add("v_sotiennop", NpgsqlDbType.Numeric).Value = v_sotiennop;
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                upd_error(v_ngay, ex.Message, sComputer, "ng_vienphict");
                return false;
            }
            finally
            {
                cmd.Dispose();
                con.Close(); con.Dispose();
            }
            return true;
        }

        public bool upd_ng_tiencong(string v_ngay, decimal v_idct,int v_mavp,int v_idnv, decimal v_soluong,decimal v_phan,decimal v_sotien)
        {
            schema = user + mmyy(v_ngay) + ".upd_ng_tiencong";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay;
                cmd.Parameters.Add("v_idct", NpgsqlDbType.Numeric).Value = v_idct;
                cmd.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
                cmd.Parameters.Add("v_idnv", NpgsqlDbType.Numeric).Value = v_idnv;
                cmd.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
                cmd.Parameters.Add("v_phan", NpgsqlDbType.Numeric).Value = v_phan;
                cmd.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                upd_error(v_ngay, ex.Message, sComputer, "ng_tiencong");
                return false;
            }
            finally
            {
                cmd.Dispose();
                con.Close(); con.Dispose();
            }
            return true;
        }

        public bool upd_ng_chia(string v_ngay, decimal v_id, int v_manv, decimal v_sotien)
        {
            schema = user + mmyy(v_ngay) + ".upd_ng_chia";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_manv", NpgsqlDbType.Numeric).Value = v_manv;
                cmd.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                upd_error(v_ngay, ex.Message, sComputer, "ng_chia");
                return false;
            }
            finally
            {
                cmd.Dispose();
                con.Close(); con.Dispose();
            }
            return true;
        }
        public void updrec_ng(DataTable dt, decimal id, string userid, string password, string right, string loaivp, string mucvp, string loai,int admin)
        {
            string exp = "id=" + id;
            DataRow r = getrowbyid(dt, exp);
            if (r == null)
            {
                DataRow nrow = dt.NewRow();
                nrow[0] = id;
                nrow[2] = userid;
                nrow[3] = password;
                nrow[4] = right;
                nrow["loaivp"] = loaivp;
                nrow["mucvp"] = mucvp;
                nrow["loai"] = loai;
                nrow["admin"] = admin;
                dt.Rows.Add(nrow);
            }
            else
            {
                DataRow[] dr = dt.Select(exp);
                dr[0][4] = right;
                dr[0]["loaivp"] = loaivp;
                dr[0]["mucvp"] = mucvp;
                dr[0]["loai"] = loai;
                dr[0]["admin"] = admin;
            }
        }

        public void updrec_ng_loaivp(DataTable dt, decimal id, string loaivp, string mucvp, string loai,int admin)
        {
            string exp = "id=" + id;
            DataRow r = getrowbyid(dt, exp);
            if (r == null)
            {
                DataRow nrow = dt.NewRow();
                nrow["id"] = id;
                nrow["loaivp"] = loaivp;
                nrow["mucvp"] = mucvp;
                nrow["loai"] = loai;
                nrow["admin"] = admin;
                dt.Rows.Add(nrow);
            }
            else
            {
                DataRow[] dr = dt.Select(exp);
                dr[0]["loaivp"] = loaivp;
                dr[0]["mucvp"] = mucvp;
                dr[0]["loai"] = loai;
                dr[0]["admin"] = admin;
            }
        }

        public bool upd_ng_huybienlai(decimal v_id, string v_tables, int v_loai, string v_mabn, string v_hoten, string v_makp, string v_ngay, decimal v_quyenso, decimal v_sobienlai, string v_lydo, int v_userid)
        {
            schema = user + mmyy(v_ngay) + ".upd_ng_huybienlai";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_tables", NpgsqlDbType.Varchar, 20).Value = v_tables;
                cmd.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                cmd.Parameters.Add("v_mabn", NpgsqlDbType.Varchar).Value = v_mabn;
                cmd.Parameters.Add("v_hoten", NpgsqlDbType.Text).Value = v_hoten;
                cmd.Parameters.Add("v_makp", NpgsqlDbType.Varchar, i_maxlength_makp).Value = v_makp;
                cmd.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay;
                cmd.Parameters.Add("v_quyenso", NpgsqlDbType.Numeric).Value = v_quyenso;
                cmd.Parameters.Add("v_sobienlai", NpgsqlDbType.Numeric).Value = v_sobienlai;
                cmd.Parameters.Add("v_lydo", NpgsqlDbType.Text).Value = v_lydo;
                cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                upd_error(v_ngay, ex.Message, sComputer, "ng_huybienlai");
                return false;
            }
            finally
            {
                cmd.Dispose();
                con.Close(); con.Dispose();
            }
            return true;
        }

        public bool upd_ng_hoantra(string ngay, decimal v_id, decimal v_quyenso, decimal v_sobienlai, string v_ngay, string v_mabn, string v_hoten, string v_makp, decimal v_sotien, string v_ghichu, int v_userid, int v_loai, int v_loaibn, string v_ngaythu)
        {
            schema = user + mmyy(ngay) + ".upd_ng_hoantra";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_quyenso", NpgsqlDbType.Numeric).Value = v_quyenso;
                cmd.Parameters.Add("v_sobienlai", NpgsqlDbType.Numeric).Value = v_sobienlai;
                cmd.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 16).Value = v_ngay;
                cmd.Parameters.Add("v_mabn", NpgsqlDbType.Varchar).Value = v_mabn;
                cmd.Parameters.Add("v_hoten", NpgsqlDbType.Text).Value = v_hoten;
                cmd.Parameters.Add("v_makp", NpgsqlDbType.Varchar, i_maxlength_makp).Value = v_makp;
                cmd.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                cmd.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;
                cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                cmd.Parameters.Add("v_loai", NpgsqlDbType.Numeric).Value = v_loai;
                cmd.Parameters.Add("v_loaibn", NpgsqlDbType.Numeric).Value = v_loaibn;
                cmd.Parameters.Add("v_ngaythu", NpgsqlDbType.Varchar, 16).Value = v_ngaythu;
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                upd_error(ngay, ex.Message, sComputer, "ng_hoantra");
                return false;
            }
            finally
            {
                cmd.Dispose();
                con.Close(); con.Dispose();
            }
            return true;
        }

        public bool upd_ng_hoantract(string ngay, decimal v_id, int v_loaivp, decimal v_sotien)
        {
            schema = user + mmyy(ngay) + ".upd_ng_hoantract";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_loaivp", NpgsqlDbType.Numeric).Value = v_loaivp;
                cmd.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                upd_error(ngay, ex.Message, sComputer, "ng_hoantract");
                return false;
            }
            finally
            {
                cmd.Dispose();
                con.Close(); con.Dispose();
            }
            return true;
        }

        public bool kiemtra_bienlai(string v_table,decimal v_id, int v_sobienlai)
        {
            ds = get_data("select * from " + user + "."+v_table+" where id=" + v_id + " and " + v_sobienlai + " between tu and den");
            return ds.Tables[0].Rows.Count > 0;
        }

        public int get_sobienlai(string v_table,decimal v_id, int v_cong)
        {
            ds = get_data("select soghi from " + user + "."+v_table+" where id=" + v_id);
            if (ds.Tables[0].Rows.Count == 0) return 0;
            else return int.Parse(ds.Tables[0].Rows[0][0].ToString()) + v_cong;
        }

        public void upd_sobienlai(string v_table,decimal v_id, int v_sobienlai)
        {
            execute_data("update " + user + "."+v_table+" set soghi=" + v_sobienlai + " where id=" + v_id);
        }

        public void updrec_ng_vienphill(DataTable dt, decimal id,decimal quyenso, decimal sobienlai, string mabn, string hoten, string sohieu,string masothue)
        {
            string exp = "id=" + id;
            DataRow r = getrowbyid(dt, exp);
            if (r == null)
            {
                DataRow nrow = dt.NewRow();
                nrow["id"] = id;
                nrow["quyenso"] = quyenso;
                nrow["sobienlai"] = sobienlai;
                nrow["mabn"] = mabn;
                nrow["hoten"] = hoten;
                nrow["sohieu"] = sohieu;
                nrow["masothue"] = masothue;
                nrow["lanin"] = 0;
                dt.Rows.Add(nrow);
            }
            else
            {
                DataRow[] dr = dt.Select(exp);
                dr[0]["quyenso"] = quyenso;
                dr[0]["sobienlai"] = sobienlai;
                dr[0]["mabn"] = mabn;
                dr[0]["hoten"] = hoten;
                dr[0]["sohieu"] = sohieu;
                dr[0]["masothue"] = masothue;
            }
        }

        public void updrec_ng_vienphict(DataTable dt, decimal id,decimal mavp, string ma, string tenvp, string dvt, decimal soluong, decimal dongia, decimal sotiennop,string ten)
        {
            string exp = "id=" + id;
            DataRow r = getrowbyid(dt, exp);
            if (r == null)
            {
                DataRow nrow = dt.NewRow();
                nrow["id"] = id;
                nrow["mavp"] = mavp;
                nrow["ma"] = ma;
                nrow["tenvp"] = tenvp;
                nrow["dvt"] = dvt;
                nrow["soluong"] = soluong;
                nrow["dongia"] = dongia;
                nrow["sotiennop"] = sotiennop;
                nrow["sotien"] = soluong * dongia;
                nrow["nop"] = soluong * sotiennop;
                nrow["ten"] = ten;
                dt.Rows.Add(nrow);
            }
            else
            {
                DataRow[] dr = dt.Select(exp);
                dr[0]["ma"] = ma;
                dr[0]["tenvp"] = tenvp;
                dr[0]["dvt"] = dvt;
                dr[0]["mavp"] = mavp;
                dr[0]["soluong"] = soluong;
                dr[0]["dongia"] = dongia;
                dr[0]["sotiennop"] = sotiennop;
                dr[0]["sotien"] = soluong * dongia;
                dr[0]["nop"] = soluong * sotiennop;
                dr[0]["ten"] = ten;
            }
        }

        public string get_ng_tenvpct(string ngay, decimal id)
        {
            string ret = "", xxx = user + mmyy(ngay);
            decimal sotien = 0;
            sql = "select b.ten,sum(b.soluong*b.dongia) as sotien from " + xxx + ".ng_vienphill a," + xxx + ".ng_vienphict b";
            sql += " where a.id=b.idll and a.id=" + id + " group by b.ten";
            foreach (DataRow r in get_data(sql).Tables[0].Rows)
            {
                sotien = decimal.Parse(r["sotien"].ToString());
                ret += r["ten"].ToString().Trim() + ": " + sotien.ToString("###,###,###,##0").Trim() + ";";
            }
            return (ret != "") ? ret.Substring(0, ret.Length - 1) : "";
        }

        public bool bMabn_ng { get { return Thongso("ng_thongso.xml","c02") == "1"; } }
        public bool bSobienlai_ng { get { return Thongso("ng_thongso.xml", "c05") == "1"; } }
        public bool bPreview_ng { get { return Thongso("ng_thongso.xml", "c06") == "1"; } }
        public int Ngaylv_Ngayht_ng { get { return int.Parse(Thongso("ng_thongso.xml", "c10")); } }
        public string Ketoantruong_ng { get { return Thongso("ng_thongso.xml", "c07"); } }
        public string Thuquy_ng { get { return Thongso("ng_thongso.xml", "c08"); } }
        public string Ketoan_ng { get { return Thongso("ng_thongso.xml", "c09"); } }
        public string Masothue_ng { get { return Thongso("ng_thongso.xml", "c13"); } }
        public bool bSuabienlai_ng { get { return Thongso("ng_thongso.xml", "c17") == "1"; } }
        public bool bMasothue_ng { get { return Thongso("ng_thongso.xml", "c65") == "1"; } }
        public bool bTenvp_tructiep_ng
        {
            get
            {
                ds = get_data("select ten from " + user + ".ng_thongso where id=54");
                if (ds.Tables[0].Rows.Count == 0) return false;
                else return ds.Tables[0].Rows[0]["ten"].ToString().Trim() == "1";
            }
        }

        public bool kiemtra_ma(string table,decimal id, string ma)
        {
            sql = "select * from " + user + "." + table + " where ma='" + ma + "' and id<>" + id;
            return get_data(sql).Tables[0].Rows.Count > 0;
        }

        public int get_dmcomputer()
        {
            sql = "update " + user + ".dmcomputer set computer=:m_computer where computer=:m_computer";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
            con.Open();
            cmd = new NpgsqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("m_computer", NpgsqlDbType.Varchar, 20).Value = sComputer;
            int irec = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close(); con.Dispose();
            if (irec == 0)
            {
                sql = "insert into " + user + ".dmcomputer(id,computer) values (" + get_id_dmcomputer + ",'" + sComputer + "')";
                execute_data(sql);
            }
            return int.Parse(get_data("select id from " + user + ".dmcomputer where computer='" + sComputer + "'").Tables[0].Rows[0][0].ToString());
        }

        public int get_dmcomputer(string m_computer)
        {
            sql = "update " + user + ".dmcomputer set computer=:m_computer where computer=:m_computer";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
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
                execute_data(sql);
            }
            return int.Parse(get_data("select id from " + user + ".dmcomputer where computer='" + m_computer + "'").Tables[0].Rows[0][0].ToString());
        }

        public bool upd_eve_tables(int m_tableid, int m_userid, string m_command)
        {
            string ngay = ngayhienhanh_server.Substring(0, 10);
            int icomputerid = get_dmcomputer(), m_ins = 0, m_upd = 0, m_del = 0;
            switch (m_command)
            {
                case "upd": m_upd = 1; break;
                case "del": m_del = 1; break;
                default: m_ins = 1; break;
            }
            schema = user + ".upd_eve_tables";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("m_tableid", NpgsqlDbType.Numeric).Value = m_tableid;
                cmd.Parameters.Add("m_ngay", NpgsqlDbType.Varchar, 10).Value = ngay;
                cmd.Parameters.Add("m_userid", NpgsqlDbType.Numeric).Value = m_userid;
                cmd.Parameters.Add("m_computerid", NpgsqlDbType.Numeric).Value = icomputerid;
                cmd.Parameters.Add("m_ins", NpgsqlDbType.Numeric).Value = m_ins;
                cmd.Parameters.Add("m_upd", NpgsqlDbType.Numeric).Value = m_upd;
                cmd.Parameters.Add("m_del", NpgsqlDbType.Numeric).Value = m_del;
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message, sComputer, "eve_tables");
                return false;
            }
            finally
            {
                cmd.Dispose();
                con.Close(); con.Dispose();
            }
            return true;
        }

        public bool upd_eve_upd_del(int m_tableid, int m_userid, string m_command, string m_noidung)
        {
            int icomputerid = get_dmcomputer();
            schema = user + ".upd_eve_upd_del";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("m_tableid", NpgsqlDbType.Numeric).Value = m_tableid;
                cmd.Parameters.Add("m_userid", NpgsqlDbType.Numeric).Value = m_userid;
                cmd.Parameters.Add("m_computerid", NpgsqlDbType.Numeric).Value = icomputerid;
                cmd.Parameters.Add("m_command", NpgsqlDbType.Varchar, 3).Value = m_command;
                cmd.Parameters.Add("m_noidung", NpgsqlDbType.Text).Value = m_noidung;
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                upd_error(ex.Message, sComputer, "eve_upd_del");
                return false;
            }
            finally
            {
                cmd.Dispose();
                con.Close(); con.Dispose();
            }
            return true;
        }

        public bool upd_eve_tables(string m_ngay, int m_tableid, int m_userid, string m_command)
        {
            string ngay = ngayhienhanh_server.Substring(0, 10);
            int icomputerid = get_dmcomputer(), m_ins = 0, m_upd = 0, m_del = 0;
            switch (m_command)
            {
                case "upd": m_upd = 1; break;
                case "del": m_del = 1; break;
                default: m_ins = 1; break;
            }
            schema = user + mmyy(m_ngay) + ".upd_eve_tables";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("m_tableid", NpgsqlDbType.Numeric).Value = m_tableid;
                cmd.Parameters.Add("m_ngay", NpgsqlDbType.Varchar, 10).Value = ngay;
                cmd.Parameters.Add("m_userid", NpgsqlDbType.Numeric).Value = m_userid;
                cmd.Parameters.Add("m_computerid", NpgsqlDbType.Numeric).Value = icomputerid;
                cmd.Parameters.Add("m_ins", NpgsqlDbType.Numeric).Value = m_ins;
                cmd.Parameters.Add("m_upd", NpgsqlDbType.Numeric).Value = m_upd;
                cmd.Parameters.Add("m_del", NpgsqlDbType.Numeric).Value = m_del;
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                upd_error(m_ngay, ex.Message, sComputer, "eve_tables");
                return false;
            }
            finally
            {
                cmd.Dispose();
                con.Close(); con.Dispose();
            }
            return true;
        }

        public bool upd_eve_upd_del(string m_ngay, int m_tableid, int m_userid, string m_command, string m_noidung)
        {
            int icomputerid = get_dmcomputer();
            schema = user + mmyy(m_ngay) + ".upd_eve_upd_del";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("m_tableid", NpgsqlDbType.Numeric).Value = m_tableid;
                cmd.Parameters.Add("m_userid", NpgsqlDbType.Numeric).Value = m_userid;
                cmd.Parameters.Add("m_computerid", NpgsqlDbType.Numeric).Value = icomputerid;
                cmd.Parameters.Add("m_command", NpgsqlDbType.Varchar, 3).Value = m_command;
                cmd.Parameters.Add("m_noidung", NpgsqlDbType.Text).Value = m_noidung;
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                upd_error(m_ngay, ex.Message, sComputer, "eve_upd_del");
                return false;
            }
            finally
            {
                cmd.Dispose();
                con.Close(); con.Dispose();
            }
            return true;
        }

        private int tableid()
        {
            ds = get_data("select max(id) as id from " + user + ".dmtables");
            if (ds.Tables[0].Rows[0]["id"].ToString() == "") return 1;
            else return int.Parse(ds.Tables[0].Rows[0]["id"].ToString()) + 1;
        }

        public int tableid(string mmyy, string tables)
        {
            int ret = 1;
            ds = get_data("select * from " + user + ".dmtables where tables='" + tables + "'");
            if (ds.Tables[0].Rows.Count > 0) ret = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
            else
            {
                ret = tableid();
                string fie = "";
                for (int i = 0; i < get_data("select * from " + user + mmyy + "." + tables + " where oid=-1").Tables[0].Columns.Count; i++) fie += ds.Tables[0].Columns[i].ColumnName.ToString().Trim() + "^";
                execute_data("insert into " + user + ".dmtables(id,tables,fields) values (" + ret + ",'" + tables + "','" + fie.Substring(0, fie.Length - 1) + "')");
            }
            return ret;
        }

        public string fields(string table, string dk)
        {
            string ret = "";
            DataTable dt = get_data("select * from " + table + " where " + dk).Tables[0];
            if (dt.Rows.Count > 0) for (int i = 0; i < dt.Columns.Count; i++) ret += dt.Rows[0][i].ToString().Trim() + "^";
            return (ret != "") ? ret.Substring(0, ret.Length - 1) : ret;
        }

        public bool upd_ng_khamll(decimal v_id,string v_ngay,int v_userid)
        {
            schema = user + mmyy(v_ngay) + ".upd_ng_khamll";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 16).Value = v_ngay;
                cmd.Parameters.Add("v_userid", NpgsqlDbType.Numeric).Value = v_userid;
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                upd_error(v_ngay, ex.Message, sComputer, "ng_khamll");
                return false;
            }
            finally
            {
                cmd.Dispose();
                con.Close(); con.Dispose();
            }
            return true;
        }

        public bool upd_ng_khamct(string v_ngay, decimal v_id,string v_kyhieu,decimal v_tu,decimal v_den,int v_mavp,decimal v_soluong, decimal v_dongia)
        {
            schema = user + mmyy(v_ngay) + ".upd_ng_khamct";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(schema, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_kyhieu", NpgsqlDbType.Varchar,20).Value = v_kyhieu;
                cmd.Parameters.Add("v_tu", NpgsqlDbType.Numeric).Value = v_tu;
                cmd.Parameters.Add("v_den", NpgsqlDbType.Numeric).Value = v_den;
                cmd.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
                cmd.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
                cmd.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                upd_error(v_ngay, ex.Message, sComputer, "ng_khamct");
                return false;
            }
            finally
            {
                cmd.Dispose();
                con.Close(); con.Dispose();
            }
            return true;
        }
        public int getRandom()
        {
            System.Threading.Thread.Sleep(10);
            Random r = new Random();
            return r.Next(999);
        }

        public string getyymmdd()
        {
            return get_data("select to_char(now(),'yymmdd')").Tables[0].Rows[0][0].ToString();
        }

        public string getyymmddhhmiss()
        {
            return get_data("select to_char(now(),'yymmddhh24miss')").Tables[0].Rows[0][0].ToString();
        }

        public decimal getidyymmddhhmiss_stt_computer
        {
            get
            {
                return decimal.Parse(getyymmddhhmiss() + getRandom().ToString().PadLeft(3, '0') + iRownum.ToString().PadLeft(3, '0'));
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
        #region benh an dien tu: Tu:28/03/2011
        public string get_id_thvp(int khu, string mabn, decimal maql, decimal idkhoa, string ngayvao, string ngayserver)
        {
            DateTime dt1 = StringToDate(ngayserver).AddDays(-d.iNgaykiemke);
            DateTime dt2 = StringToDate(ngayserver);
            int y1 = dt1.Year, m1 = dt1.Month;
            int y2 = dt2.Year, m2 = dt2.Month;
            int itu, iden;
            string mmyy = "", xxx;
            decimal id = 0;
            for (int i = y1; i <= y2; i++)
            {
                itu = (i == y1) ? m1 : 1;
                iden = (i == y2) ? m2 : 12;
                for (int j = itu; j <= iden; j++)
                {
                    mmyy = j.ToString().PadLeft(2, '0') + i.ToString().Substring(2, 2);
                    xxx = user + mmyy;
                    if (bMmyy(mmyy))
                    {
                        sql = "select id from " + xxx + ".v_thvpll where mabn='" + mabn + "' and to_char(ngayvao,'dd/mm/yyyy hh24:mi')='" + ngayvao + "'";
                        if (idkhoa != 0) sql += " and idkhoa=" + idkhoa;
                        else sql += " and maql=" + maql;
                        if (khu != 0) sql += " and khu=" + khu;
                        ds = get_data(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            id = decimal.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                            break;
                        }
                    }
                }
            }
            return (id == 0) ? "" : mmyy + id.ToString().Trim();
        }
        
        public bool upd_thvpbhyt(string v_mmyy, decimal v_id, string v_sothe, int v_maphu, string v_noigioithieu, string v_noicap, int v_traituyen)
        {
            string xxx = user + v_mmyy + ".upd_thvpbhyt";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(xxx, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_sothe", NpgsqlDbType.Varchar, 20).Value = v_sothe;
                cmd.Parameters.Add("v_maphu", NpgsqlDbType.Numeric).Value = v_maphu;
                cmd.Parameters.Add("v_noigioithieu", NpgsqlDbType.Varchar, 8).Value = v_noigioithieu;
                cmd.Parameters.Add("v_noicap", NpgsqlDbType.Varchar, 8).Value = v_noicap;
                cmd.Parameters.Add("v_traituyen", NpgsqlDbType.Numeric).Value = v_traituyen;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                upd_error(ex.Message, sComputer, "v_thvpbhyt");
                return false;
            }
            finally
            {
                cmd.Dispose();
                con.Close(); con.Dispose();
            }
            return true;
        }
        public bool upd_thvpct(string v_mmyy, decimal v_id, string v_ngay, string v_makp, int v_madoituong, decimal v_mavp, decimal v_soluong,
            decimal v_dongia, decimal v_sotien, decimal v_vattu, string v_sothe)
        {
            string xxx = user + v_mmyy + ".upd_thvpct";
            if (con != null)
            {
                con.Close(); con.Dispose();
            }
            con = new NpgsqlConnection(sConn);
            try
            {
                con.Open();
                cmd = new NpgsqlCommand(xxx, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                cmd.Parameters.Add("v_ngay", NpgsqlDbType.Varchar, 10).Value = v_ngay;
                cmd.Parameters.Add("v_makp", NpgsqlDbType.Varchar, i_maxlength_makp).Value = v_makp;
                cmd.Parameters.Add("v_madoituong", NpgsqlDbType.Numeric).Value = v_madoituong;
                cmd.Parameters.Add("v_mavp", NpgsqlDbType.Numeric).Value = v_mavp;
                cmd.Parameters.Add("v_soluong", NpgsqlDbType.Numeric).Value = v_soluong;
                cmd.Parameters.Add("v_dongia", NpgsqlDbType.Numeric).Value = v_dongia;
                cmd.Parameters.Add("v_sotien", NpgsqlDbType.Numeric).Value = v_sotien;
                cmd.Parameters.Add("v_vattu", NpgsqlDbType.Numeric).Value = v_vattu;
                cmd.Parameters.Add("v_sothe", NpgsqlDbType.Varchar, 20).Value = v_sothe;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                upd_error(ex.Message, sComputer, "v_thvpct");
                return false;
            }
            finally
            {
                cmd.Dispose();
                con.Close(); con.Dispose();
            }
            return true;
        }
        #endregion
        //linh
        /// <summary>
        /// Tên databse link đến cơ sở 
        /// </summary>
        public string DatabseLinkName
        {
            set
            {
                dblink = value;
                dblink = dblink.Trim('@');
            }
        }
        public bool upd_chidinh(decimal v_id, string v_mabn, decimal v_mavaovien, decimal v_maql, decimal v_idkhoa, string v_ngay, int v_loai,
            string v_makp, int v_madoituong, int v_mavp, decimal v_soluong, decimal v_dongia, decimal v_vattu, int v_userid,
            int v_tinhtrang, int v_thuchien, decimal v_idchidinh, string v_maicd, string v_chandoan, string v_mabs,
            int v_loaiba, string v_ghichu,string v_chuyendi,int v_idchinhanh)
        {
            dblink = dblink.Trim('@');
            dblink = dblink == "" ? "" : "@" + dblink;
            string _mmyy = mmyy(v_ngay);
            if (bMmyy(_mmyy))
            {
                string s_chema = user + _mmyy;
                string s_sql = "update " + s_chema + ".v_chidinh" + dblink + " set mabn='" + v_mabn + "',mavaovien=" + v_mavaovien.ToString() + ",maql=" + v_maql.ToString() + "," +
                    "idkhoa=" + v_idkhoa.ToString() + ",ngay=to_timestamp('" + v_ngay + "','dd/mm/yyyy hh24:mi'),loai=" + v_loai.ToString() + ",makp='" + v_makp + "'," +
                    "madoituong=" + v_madoituong.ToString() + ",mavp=" + v_mavp.ToString() + ",soluong=" + v_soluong.ToString() + ",dongia=" + v_dongia.ToString() + "," +
                    "vattu=" + v_vattu.ToString() + ",userid=" + v_userid.ToString() + ",tinhtrang=" + v_tinhtrang.ToString() + ",thuchien=" + v_thuchien.ToString() + "," +
                    "computer='" + sComputer + "',maicd='" + v_maicd + "',chandoan=:v_chandoan,mabs='" + v_mabs + "',loaiba=" + v_loaiba.ToString() + ",ghichu=:v_ghichu,chuyendi='" + v_chuyendi + "',idchinhanh="+v_idchinhanh.ToString() +
                    " where id=" + v_id.ToString();
                if (con != null)
                {
                    con.Close(); con.Dispose();
                }
                con = new NpgsqlConnection(sConn);
                try
                {
                    con.Open();
                    cmd = new NpgsqlCommand(s_sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("v_chandoan", NpgsqlDbType.Text).Value = v_chandoan;
                    cmd.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;
                    int i = cmd.ExecuteNonQuery();
                    if (i == 0)
                    {
                        cmd.Dispose();
                        s_sql = "insert into " + s_chema + ".v_chidinh" + dblink + "(id,mabn,mavaovien,maql,idkhoa,ngay,loai,makp,madoituong,mavp,soluong,dongia,vattu,userid," +
                            "tinhtrang,thuchien,computer,idchidinh,maicd,chandoan,mabs,loaiba,ghichu,chuyendi,id_goi,idchinhanh, paid, done, idttrv) values (" + v_id.ToString() + ",'" + v_mabn + "'," +
                            v_mavaovien.ToString() + "," + v_maql.ToString() + "," + v_idkhoa.ToString() + ",to_timestamp('" + v_ngay + "','dd/mm/yyyy hh24:mi')," +
                            v_loai.ToString() + ",'" + v_makp + "'," + v_madoituong.ToString() + "," + v_mavp.ToString() + "," + v_soluong.ToString() + "," +
                            v_dongia.ToString() + "," + v_vattu.ToString() + "," + v_userid.ToString() + "," + v_tinhtrang.ToString() + "," + v_thuchien.ToString() + ",'" +
                            sComputer + "'," + v_idchidinh.ToString() + ",'" + v_maicd + "',:v_chandoan,'" + v_mabs + "'," + v_loaiba.ToString() + ",:v_ghichu,'" + v_chuyendi + "',0," + v_idchinhanh.ToString() + ",0,0,0)";
                        cmd = new NpgsqlCommand(s_sql, con);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("v_chandoan", NpgsqlDbType.Text).Value = v_chandoan;
                        cmd.Parameters.Add("v_ghichu", NpgsqlDbType.Text).Value = v_ghichu;
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (NpgsqlException ex)
                {
                    upd_error(v_ngay, ex.Message, sComputer, "v_chidinh");
                    return false;
                }
                finally
                {
                    cmd.Dispose();
                    con.Close(); con.Dispose();
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        //end linha
        //thuy 02012013

        //linh 02012013
        internal string PathXML = "..//..//..//xml";
        const string key = "Toancau@Medisoft.vn/03031952#0903937066.";

        internal string Key
        {
            get { return key; }
        }
        /// <summary>
        /// Dịch ngược mật khẩu
        /// </summary>
        /// <param name="values">Chuỗi đã bị mã hoá</param>
        /// <returns></returns>
        internal string DeCode(string values, string s_key)
        {
            string val = "";
            val = DeCrypt(values, s_key);
            return val;
        }

        string DeCrypt(string values, string s_key)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(values);
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(s_key));
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        /// <summary>
        /// Mã hoá mật khẩu
        /// </summary>
        /// <param name="values">Chuỗi cần được mã hoá</param>
        /// <returns></returns>
        internal string EnCode(string values)
        {
            string val = "";
            val = EnCrypt(values);
            return val;
        }

        string EnCrypt(string values)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(values);
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Key));
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
    }
}
