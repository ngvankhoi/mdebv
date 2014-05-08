using System;
using System.Data;
using LibMedi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for Export.
	/// </summary>
	public class Export
	{
		private AccessData m=new AccessData();
		private DataColumn dc;
		private DataSet ds;
		private DataTable dt;
		private string sql;
		public Export()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private void tongcong(string exp,string stt,int k)
		{
			Decimal l_tong=0;
			DataRow[] r1=ds.Tables[0].Select(exp);
			Int16 iRec=Convert.ToInt16(r1.Length);
			for(int j=k;j<ds.Tables[0].Columns.Count;j++)
			{
				l_tong=0;
				for(Int16 i=0;i<iRec;i++) l_tong+=Decimal.Parse(r1[i][j].ToString());
				m.updrec_02(ds.Tables[0],stt,j,l_tong);
			}
		}

		private void tongcong(string exp,int ma,int k)
		{
			Decimal l_tong=0;
			DataRow[] r1=ds.Tables[0].Select(exp);
			Int16 iRec=Convert.ToInt16(r1.Length);
			for(int j=k;j<ds.Tables[0].Columns.Count;j++)
			{
				l_tong=0;
				for(Int16 i=0;i<iRec;i++) l_tong+=Decimal.Parse(r1[i][j].ToString());
				m.updrec_145(ds.Tables[0],ma,j,l_tong);
			}
		}

		public DataSet bieu_02(string s_tu,string s_den,string s_table,bool benhan,bool thongke,bool phatsinh)
		{
			ds=new DataSet();
			DataRow[] dr;
			Int64 songay,c02,c03,c04,c05,c06,c07;
			string ngay;
			ds=m.get_data("select * from "+s_table+" order by ma"); 
			if (benhan)
			{			
				sql="SELECT a.ngay as ngayvv,a.madoituong,a.nhantu,b.ttlucrv,a.loaiba,";
				sql+="b.ngay as ngayrv,c.makpbo as ma"; 
				sql+=" FROM (BENHANDT a LEFT JOIN XUATVIEN b ON a.MAQL = b.MAQL)";
				sql+=" INNER JOIN BTDKP_BV c ON a.MAKP = c.MAKP";
				sql+=" WHERE (a.loaiba<>1) and (b.ngay is null  or to_date(a.ngay,'dd/mm/yy') between to_date('"+s_tu+"','dd/mm/yy') and to_date('"+s_den+"','dd/mm/yy'))";
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					dr=ds.Tables[0].Select("ma="+int.Parse(r["ma"].ToString()));
					if (dr!=null)
					{
						c02=(r["madoituong"].ToString()=="1")?1:0;
						c03=(r["madoituong"].ToString()=="2")?1:0;
						c04=(c02+c03==0)?1:0;
						c05=(r["nhantu"].ToString()=="1")?1:0;
						c06=(r["ttlucrv"].ToString()=="5")?1:0;
						c07=(r["ttlucrv"].ToString()=="6")?1:0;
						dr[0]["c01"]=Decimal.Parse(dr[0]["c01"].ToString())+1;
						dr[0]["c02"]=Decimal.Parse(dr[0]["c02"].ToString())+c02;
						dr[0]["c03"]=Decimal.Parse(dr[0]["c03"].ToString())+c03;
						dr[0]["c04"]=Decimal.Parse(dr[0]["c04"].ToString())+c04;
						dr[0]["c05"]=Decimal.Parse(dr[0]["c05"].ToString())+c05;
						dr[0]["c06"]=Decimal.Parse(dr[0]["c06"].ToString())+c06;
						dr[0]["c07"]=Decimal.Parse(dr[0]["c07"].ToString())+c07;
						if (r["loaiba"].ToString()=="2")
						{
							if (r["ngayrv"].ToString()=="") ngay=s_den;
							else ngay=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayrv"].ToString()));
							songay=m.songay(m.StringToDate(ngay),m.StringToDate(m.Max(m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayvv"].ToString())),s_tu)),1);
							dr[0]["c08"]=Decimal.Parse(dr[0]["c08"].ToString())+1;
							dr[0]["c09"]=Decimal.Parse(dr[0]["c09"].ToString())+songay;
						}
					}
				}
				tongcong("ma>1","A",3);
			}
			
			if (thongke)
			{
				sql="select a.ma,sum(a.c01) as c01,sum(a.c02) as c02,sum(a.c03) as c03,sum(a.c04) as c04,";
				sql+="sum(a.c05) as c05,sum(a.c06) as c06,sum(a.c07) as c07,sum(a.c08) as c08,";
				sql+="sum(a.c09) as c09";
				sql+=" from bieu_02 a,dm_02 b where a.ma=b.ma ";
				sql+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+s_tu+"','dd/mm/yy') and to_date('"+s_den+"','dd/mm/yy')";
				sql+=" group by a.ma";
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					dr=ds.Tables[0].Select("ma="+int.Parse(r["ma"].ToString()));
					if (dr!=null)
					{
						dr[0]["c01"]=Decimal.Parse(dr[0]["c01"].ToString())+Decimal.Parse(r["c01"].ToString());
						dr[0]["c02"]=Decimal.Parse(dr[0]["c02"].ToString())+Decimal.Parse(r["c02"].ToString());
						dr[0]["c03"]=Decimal.Parse(dr[0]["c03"].ToString())+Decimal.Parse(r["c03"].ToString());
						dr[0]["c04"]=Decimal.Parse(dr[0]["c04"].ToString())+Decimal.Parse(r["c04"].ToString());
						dr[0]["c05"]=Decimal.Parse(dr[0]["c05"].ToString())+Decimal.Parse(r["c05"].ToString());
						dr[0]["c06"]=Decimal.Parse(dr[0]["c06"].ToString())+Decimal.Parse(r["c06"].ToString());
						dr[0]["c07"]=Decimal.Parse(dr[0]["c07"].ToString())+Decimal.Parse(r["c07"].ToString());
						dr[0]["c08"]=Decimal.Parse(dr[0]["c08"].ToString())+Decimal.Parse(r["c08"].ToString());
						dr[0]["c09"]=Decimal.Parse(dr[0]["c09"].ToString())+Decimal.Parse(r["c09"].ToString());
					}
				}
			}
			if (phatsinh) m.delrec(ds.Tables[0],"c01+c02+c03+c04+c05+c06+c07+c08+c09=0");
			return ds;
		}

		public DataSet bieu_02_bv(string s_tu,string s_den,string s_table,bool benhan,bool thongke,bool phatsinh)
		{
			ds=new DataSet();
			DataRow[] dr;
			DataRow r1;
			Int64 songay,c02,c03,c04,c05,c06,c07,ma;
			string ngay;
			ds=m.get_data("select * from "+s_table+" order by ma"); 
			m.delrec(ds.Tables[0],"ma>1");
			ds.AcceptChanges();
			if (benhan)
			{			
				sql="SELECT a.ngay as ngayvv,a.madoituong,a.nhantu,b.ttlucrv,a.loaiba,";
				sql+="b.ngay as ngayrv,c.makp as ma,c.tenkp"; 
				sql+=" FROM (BENHANDT a LEFT JOIN XUATVIEN b ON a.MAQL = b.MAQL)";
				sql+=" INNER JOIN BTDKP_BV c ON a.MAKP = c.MAKP";
				sql+=" WHERE (a.loaiba<>1) and (b.ngay is null  or to_date(a.ngay,'dd/mm/yy') between to_date('"+s_tu+"','dd/mm/yy') and to_date('"+s_den+"','dd/mm/yy'))";
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					ma=int.Parse(r["ma"].ToString());
					r1=m.getrowbyid(ds.Tables[0],"ma="+ma);
					if (r1==null) m.updrec_bieu(ds.Tables[0],ma,r["tenkp"].ToString(),9);
					dr=ds.Tables[0].Select("ma="+ma);
					if (dr!=null)
					{
						c02=(r["madoituong"].ToString()=="1")?1:0;
						c03=(r["madoituong"].ToString()=="2")?1:0;
						c04=(c02+c03==0)?1:0;
						c05=(r["nhantu"].ToString()=="1")?1:0;
						c06=(r["ttlucrv"].ToString()=="5")?1:0;
						c07=(r["ttlucrv"].ToString()=="6")?1:0;
						dr[0]["c01"]=Decimal.Parse(dr[0]["c01"].ToString())+1;
						dr[0]["c02"]=Decimal.Parse(dr[0]["c02"].ToString())+c02;
						dr[0]["c03"]=Decimal.Parse(dr[0]["c03"].ToString())+c03;
						dr[0]["c04"]=Decimal.Parse(dr[0]["c04"].ToString())+c04;
						dr[0]["c05"]=Decimal.Parse(dr[0]["c05"].ToString())+c05;
						dr[0]["c06"]=Decimal.Parse(dr[0]["c06"].ToString())+c06;
						dr[0]["c07"]=Decimal.Parse(dr[0]["c07"].ToString())+c07;
						if (r["loaiba"].ToString()=="2")
						{
							if (r["ngayrv"].ToString()=="") ngay=s_den;
							else ngay=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayrv"].ToString()));
							songay=m.songay(m.StringToDate(ngay),m.StringToDate(m.Max(m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayvv"].ToString())),s_tu)),1);
							dr[0]["c08"]=Decimal.Parse(dr[0]["c08"].ToString())+1;
							dr[0]["c09"]=Decimal.Parse(dr[0]["c09"].ToString())+songay;
						}
					}
				}
				tongcong("ma>1","A",3);
			}
			#region 29102004
			/*
			if (thongke)
			{
				sql="select a.ma,sum(a.c01) as c01,sum(a.c02) as c02,sum(a.c03) as c03,sum(a.c04) as c04,";
				sql+="sum(a.c05) as c05,sum(a.c06) as c06,sum(a.c07) as c07,sum(a.c08) as c08,";
				sql+="sum(a.c09) as c09";
				sql+=" from bieu_02 a,dm_02 b where a.ma=b.ma ";
				sql+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+s_tu+"','dd/mm/yy') and to_date('"+s_den+"','dd/mm/yy')";
				sql+=" group by a.ma";
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					dr=ds.Tables[0].Select("ma="+int.Parse(r["ma"].ToString()));
					if (dr!=null)
					{
						dr[0]["c01"]=Decimal.Parse(dr[0]["c01"].ToString())+Decimal.Parse(r["c01"].ToString());
						dr[0]["c02"]=Decimal.Parse(dr[0]["c02"].ToString())+Decimal.Parse(r["c02"].ToString());
						dr[0]["c03"]=Decimal.Parse(dr[0]["c03"].ToString())+Decimal.Parse(r["c03"].ToString());
						dr[0]["c04"]=Decimal.Parse(dr[0]["c04"].ToString())+Decimal.Parse(r["c04"].ToString());
						dr[0]["c05"]=Decimal.Parse(dr[0]["c05"].ToString())+Decimal.Parse(r["c05"].ToString());
						dr[0]["c06"]=Decimal.Parse(dr[0]["c06"].ToString())+Decimal.Parse(r["c06"].ToString());
						dr[0]["c07"]=Decimal.Parse(dr[0]["c07"].ToString())+Decimal.Parse(r["c07"].ToString());
						dr[0]["c08"]=Decimal.Parse(dr[0]["c08"].ToString())+Decimal.Parse(r["c08"].ToString());
						dr[0]["c09"]=Decimal.Parse(dr[0]["c09"].ToString())+Decimal.Parse(r["c09"].ToString());
					}
				}
			}
			*/
			#endregion
			if (phatsinh) m.delrec(ds.Tables[0],"c01+c02+c03+c04+c05+c06+c07+c08+c09=0");
			return ds;
		}

		public DataSet bieu_031(string s_tu,string s_den,string s_table,bool benhan,bool thongke,bool phatsinh)
		{
			DataRow[] dr;
			Int64 songay,c04,c05,c08,c09,c10,ma;
			string ngay;
			ds=m.get_data("select * from "+s_table+" order by ma"); 
			if (benhan)
			{	
				sql="SELECT a.ngay as ngayvv,a.madoituong,a.nhantu,b.ttlucrv,c.namsinh,";
				sql+="b.ngay as ngayrv,d.makpbo as ma,c.phai";
				sql+=" FROM ((BENHANDT a LEFT JOIN XUATVIEN b ON a.MAQL=b.MAQL)";
				sql+=" INNER JOIN BTDBN c ON a.MABN=c.MABN) INNER JOIN BTDKP_BV d ON a.MAKP=d.MAKP";
				sql+=" where  to_date(a.ngay,'dd/mm/yy') between to_date('"+s_tu+"','dd/mm/yy') and to_date('"+s_den+"','dd/mm/yy')";
				sql+=" and a.loaiba=1";
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					ma=int.Parse(r["ma"].ToString())+2;
					dr=ds.Tables[0].Select("ma="+ma);
					if (dr!=null)
					{
						c10=(r["madoituong"].ToString()=="1")?1:0;
						c04=(DateTime.Now.Year-int.Parse(r["namsinh"].ToString())<15)?1:0;
						c05=(r["nhantu"].ToString()=="1")?1:0;
						dr[0]["c04"]=Decimal.Parse(dr[0]["c04"].ToString())+c04;
						dr[0]["c05"]=Decimal.Parse(dr[0]["c05"].ToString())+c05;				
						dr[0]["c10"]=Decimal.Parse(dr[0]["c10"].ToString())+c10;
					}
				}
				//phai=1 nu
				sql+=" and c.phai=1";
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					ma=2;
					dr=ds.Tables[0].Select("ma="+ma);
					if (dr!=null)
					{
						c10=(r["madoituong"].ToString()=="1")?1:0;
						c04=(DateTime.Now.Year-int.Parse(r["namsinh"].ToString())<15)?1:0;
						c05=(r["nhantu"].ToString()=="1")?1:0;
						dr[0]["c04"]=Decimal.Parse(dr[0]["c04"].ToString())+c04;
						dr[0]["c05"]=Decimal.Parse(dr[0]["c05"].ToString())+c05;				
						dr[0]["c10"]=Decimal.Parse(dr[0]["c10"].ToString())+c10;
					}
				}
				//
				sql="SELECT a.khoachuyen,a.ngay as ngayvv,b.ttlucrk as ttlucrv,c.namsinh,";
				sql+="b.ngay as ngayrv,d.makpbo as ma,c.phai";
				sql+=" FROM ((nhapkhoa a LEFT JOIN xuatkhoa b ON a.id=b.id)";
				sql+=" INNER JOIN BTDBN c ON a.MABN=c.MABN) INNER JOIN BTDKP_BV d ON a.MAKP=d.MAKP";
				sql+=" where  b.ngay is null and to_date(a.ngay,'dd/mm/yy') between to_date('"+s_tu+"','dd/mm/yy') and to_date('"+s_den+"','dd/mm/yy')";
				sql+=" and a.maba<20";
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					ma=int.Parse(r["ma"].ToString())+2;
					dr=ds.Tables[0].Select("ma="+ma);
					if (dr!=null)
					{
						if (r["ngayrv"].ToString()=="") ngay=s_den;
						else ngay=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayrv"].ToString()));
						songay=m.songay(m.StringToDate(ngay),m.StringToDate(m.Max(m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayvv"].ToString())),s_tu)),(r["khoachuyen"].ToString()=="01")?1:0);
						dr[0]["c06"]=Decimal.Parse(dr[0]["c06"].ToString())+songay;
						if (r["ttlucrv"].ToString()=="7")
						{
							c08=(DateTime.Now.Year-int.Parse(r["namsinh"].ToString())<15)?1:0;
							c09=(m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayvv"].ToString()))==m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayrv"].ToString())))?1:0;
							dr[0]["c07"]=Decimal.Parse(dr[0]["c07"].ToString())+1;
							dr[0]["c08"]=Decimal.Parse(dr[0]["c08"].ToString())+c08;
							dr[0]["c09"]=Decimal.Parse(dr[0]["c09"].ToString())+c09;
						}
					}
				}
				//
				sql="SELECT a.khoachuyen,a.ngay as ngayvv,b.ttlucrk as ttlucrv,c.namsinh,";
				sql+="b.ngay as ngayrv,d.makpbo as ma,c.phai";
				sql+=" FROM ((nhapkhoa a LEFT JOIN xuatkhoa b ON a.id=b.id)";
				sql+=" INNER JOIN BTDBN c ON a.MABN=c.MABN) INNER JOIN BTDKP_BV d ON a.MAKP=d.MAKP";
				sql+=" where  to_date(b.ngay,'dd/mm/yy') between to_date('"+s_tu+"','dd/mm/yy') and to_date('"+s_den+"','dd/mm/yy')";
				sql+=" and a.maba<20";
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					ma=int.Parse(r["ma"].ToString())+2;
					dr=ds.Tables[0].Select("ma="+ma);
					if (dr!=null)
					{
						if (r["ngayrv"].ToString()=="") ngay=s_den;
						else ngay=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayrv"].ToString()));
						songay=m.songay(m.StringToDate(ngay),m.StringToDate(m.Max(m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayvv"].ToString())),s_tu)),(r["khoachuyen"].ToString()=="01")?1:0);
						dr[0]["c06"]=Decimal.Parse(dr[0]["c06"].ToString())+songay;
						if (r["ttlucrv"].ToString()=="7")
						{
							c08=(DateTime.Now.Year-int.Parse(r["namsinh"].ToString())<15)?1:0;
							c09=(m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayvv"].ToString()))==m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayrv"].ToString())))?1:0;
							dr[0]["c07"]=Decimal.Parse(dr[0]["c07"].ToString())+1;
							dr[0]["c08"]=Decimal.Parse(dr[0]["c08"].ToString())+c08;
							dr[0]["c09"]=Decimal.Parse(dr[0]["c09"].ToString())+c09;
						}
					}
				}
				//phai=1
				//
				sql="SELECT a.khoachuyen,a.ngay as ngayvv,b.ttlucrk as ttlucrv,c.namsinh,";
				sql+="b.ngay as ngayrv,d.makpbo as ma,c.phai";
				sql+=" FROM ((nhapkhoa a LEFT JOIN xuatkhoa b ON a.id=b.id)";
				sql+=" INNER JOIN BTDBN c ON a.MABN=c.MABN) INNER JOIN BTDKP_BV d ON a.MAKP=d.MAKP";
				sql+=" where  b.ngay is null and to_date(a.ngay,'dd/mm/yy') between to_date('"+s_tu+"','dd/mm/yy') and to_date('"+s_den+"','dd/mm/yy')";
				sql+=" and a.maba<20 and c.phai=1";
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					ma=2;
					dr=ds.Tables[0].Select("ma="+ma);
					if (dr!=null)
					{
						if (r["ngayrv"].ToString()=="") ngay=s_den;
						else ngay=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayrv"].ToString()));
						songay=m.songay(m.StringToDate(ngay),m.StringToDate(m.Max(m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayvv"].ToString())),s_tu)),(r["khoachuyen"].ToString()=="01")?1:0);
						dr[0]["c06"]=Decimal.Parse(dr[0]["c06"].ToString())+songay;
						if (r["ttlucrv"].ToString()=="7")
						{
							c08=(DateTime.Now.Year-int.Parse(r["namsinh"].ToString())<15)?1:0;
							c09=(m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayvv"].ToString()))==m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayrv"].ToString())))?1:0;
							dr[0]["c07"]=Decimal.Parse(dr[0]["c07"].ToString())+1;
							dr[0]["c08"]=Decimal.Parse(dr[0]["c08"].ToString())+c08;
							dr[0]["c09"]=Decimal.Parse(dr[0]["c09"].ToString())+c09;
						}
					}
				}
				//
				sql="SELECT a.khoachuyen,a.ngay as ngayvv,b.ttlucrk as ttlucrv,c.namsinh,";
				sql+="b.ngay as ngayrv,d.makpbo as ma,c.phai";
				sql+=" FROM ((nhapkhoa a LEFT JOIN xuatkhoa b ON a.id=b.id)";
				sql+=" INNER JOIN BTDBN c ON a.MABN=c.MABN) INNER JOIN BTDKP_BV d ON a.MAKP=d.MAKP";
				sql+=" where  to_date(b.ngay,'dd/mm/yy') between to_date('"+s_tu+"','dd/mm/yy') and to_date('"+s_den+"','dd/mm/yy')";
				sql+=" and a.maba<20 and c.phai=1";
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					ma=2;
					dr=ds.Tables[0].Select("ma="+ma);
					if (dr!=null)
					{
						if (r["ngayrv"].ToString()=="") ngay=s_den;
						else ngay=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayrv"].ToString()));
						songay=m.songay(m.StringToDate(ngay),m.StringToDate(m.Max(m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayvv"].ToString())),s_tu)),(r["khoachuyen"].ToString()=="01")?1:0);
						dr[0]["c06"]=Decimal.Parse(dr[0]["c06"].ToString())+songay;
						if (r["ttlucrv"].ToString()=="7")
						{
							c08=(DateTime.Now.Year-int.Parse(r["namsinh"].ToString())<15)?1:0;
							c09=(m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayvv"].ToString()))==m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayrv"].ToString())))?1:0;
							dr[0]["c07"]=Decimal.Parse(dr[0]["c07"].ToString())+1;
							dr[0]["c08"]=Decimal.Parse(dr[0]["c08"].ToString())+c08;
							dr[0]["c09"]=Decimal.Parse(dr[0]["c09"].ToString())+c09;
						}
					}
				}
				//dau ky + cuoi ky
				sql="SELECT c.MAKPBO ma,sum(case when (to_date(a.ngay,'dd/mm/yy')<to_date('"+s_tu+"','dd/mm/yy') and (b.ngay is null or to_date(b.ngay,'dd/mm/yy')>=to_date('"+s_tu+"','dd/mm/yy'))) then 1 else 0 end) C03,";
				sql+="sum(case when a.khoachuyen='01' and to_date(a.ngay,'dd/mm/yy') Between to_date('"+s_tu+"','dd/mm/yy') And to_date('"+s_den+"','dd/mm/yy') then 1 else 0 end) C04,";
				sql+="sum(case when a.khoachuyen<>'01' and to_date(a.ngay,'dd/mm/yy') Between to_date('"+s_tu+"','dd/mm/yy') And to_date('"+s_den+"','dd/mm/yy') then 1 else 0 end) C05,";
				sql+="Sum(case when b.ngay is null then 0 else case when b.ttlucrk=1 And to_date(b.ngay,'dd/mm/yy') Between to_date('"+s_tu+"','dd/mm/yy') And to_date('"+s_den+"','dd/mm/yy') then 1 else 0 end end) C06,";
				sql+="Sum(case when b.ngay is null then 0 else case when b.ttlucrk=2 And to_date(b.ngay,'dd/mm/yy') Between to_date('"+s_tu+"','dd/mm/yy') And to_date('"+s_den+"','dd/mm/yy') then 1 else 0 end end) C07,";
				sql+="Sum(case when b.ngay is null then 0 else case when b.ttlucrk=3 And to_date(b.ngay,'dd/mm/yy') Between to_date('"+s_tu+"','dd/mm/yy') And to_date('"+s_den+"','dd/mm/yy') then 1 else 0 end end) C08,";
				sql+="Sum(case when b.ngay is null then 0 else case when b.ttlucrk=4 And to_date(b.ngay,'dd/mm/yy') Between to_date('"+s_tu+"','dd/mm/yy') And to_date('"+s_den+"','dd/mm/yy') then 1 else 0 end end) C09,";
				sql+="Sum(case when b.ngay is null then 0 else case when b.ttlucrk=5 And to_date(b.ngay,'dd/mm/yy') Between to_date('"+s_tu+"','dd/mm/yy') And to_date('"+s_den+"','dd/mm/yy') then 1 else 0 end end) C10,";
				sql+="Sum(case when b.ngay is null then 0 else case when b.ttlucrk=6 And to_date(b.ngay,'dd/mm/yy') Between to_date('"+s_tu+"','dd/mm/yy') And to_date('"+s_den+"','dd/mm/yy') then 1 else 0 end end) C11,";
				sql+="Sum(case when b.ngay is null then 0 else case when b.ttlucrk=7 And to_date(b.ngay,'dd/mm/yy') Between to_date('"+s_tu+"','dd/mm/yy') And to_date('"+s_den+"','dd/mm/yy') then 1 else 0 end end) C12,";
				sql+="sum(case when b.ngay is null or to_date(b.ngay,'dd/mm/yy')>to_date('"+s_den+"','dd/mm/yy') then 1 else 0 end) C13";
				sql+=" FROM NHAPKHOA a,XUATKHOA b,BTDKP_BV c,BTDBN d ";
				sql+=" WHERE a.MAKP=c.MAKP and a.ID=b.ID(+) and a.mabn=d.mabn and a.maba<20 ";
				foreach(DataRow r in m.get_data(sql+"GROUP BY c.makpbo ORDER BY c.makpbo").Tables[0].Rows)
				{
					ma=int.Parse(r["ma"].ToString())+2;
					dr=ds.Tables[0].Select("ma="+ma);
					if (dr!=null)
					{
						dr[0]["c02"]=Decimal.Parse(r["c03"].ToString());
						dr[0]["c03"]=Decimal.Parse(dr[0]["c03"].ToString())+Decimal.Parse(r["c04"].ToString());
						dr[0]["c11"]=Decimal.Parse(r["c03"].ToString())+Decimal.Parse(r["c04"].ToString())+Decimal.Parse(r["c05"].ToString())-(Decimal.Parse(r["c06"].ToString())+Decimal.Parse(r["c07"].ToString())+Decimal.Parse(r["c08"].ToString())+Decimal.Parse(r["c09"].ToString())+Decimal.Parse(r["c10"].ToString())+Decimal.Parse(r["c11"].ToString())+Decimal.Parse(r["c12"].ToString()));
					}
				}
				//phai=1
				sql+=" and d.phai=1 ";
				foreach(DataRow r in m.get_data(sql+"GROUP BY c.makpbo ORDER BY c.makpbo").Tables[0].Rows)
				{
					ma=2;
					dr=ds.Tables[0].Select("ma="+ma);
					if (dr!=null)
					{
						dr[0]["c02"]=Decimal.Parse(r["c03"].ToString());
						dr[0]["c03"]=Decimal.Parse(dr[0]["c03"].ToString())+Decimal.Parse(r["c04"].ToString());
						dr[0]["c11"]=Decimal.Parse(r["c03"].ToString())+Decimal.Parse(r["c04"].ToString())+Decimal.Parse(r["c05"].ToString())-(Decimal.Parse(r["c06"].ToString())+Decimal.Parse(r["c07"].ToString())+Decimal.Parse(r["c08"].ToString())+Decimal.Parse(r["c09"].ToString())+Decimal.Parse(r["c10"].ToString())+Decimal.Parse(r["c11"].ToString())+Decimal.Parse(r["c12"].ToString()));
					}
				}
				DataRow r2;
				int i_ma;
				foreach(DataRow r in m.get_data("select makpbo,sum(kehoach) as kh from btdkp_bv group by makpbo order by makpbo").Tables[0].Rows)
				{
					i_ma=int.Parse(r["makpbo"].ToString())+2;
					r2=m.getrowbyid(ds.Tables[0],"ma="+i_ma);
					if (r2!=null) r2["c01"]=r["kh"].ToString();
				}
				tongcong("ma>2","1",3);
			}
			
			if (thongke)
			{
				sql="select a.ma,sum(a.c01) as c01,sum(a.c02) as c02,sum(a.c03) as c03,sum(a.c04) as c04,";
				sql+="sum(a.c05) as c05,sum(a.c06) as c06,sum(a.c07) as c07,sum(a.c08) as c08,";
				sql+="sum(a.c09) as c09,sum(a.c10) as c10,sum(a.c11) as c11";
				sql+=" from bieu_031 a,dm_031 b where a.ma=b.ma ";
				sql+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+s_tu+"','dd/mm/yy') and to_date('"+s_den+"','dd/mm/yy')";
				sql+=" group by a.ma";
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					dr=ds.Tables[0].Select("ma="+int.Parse(r["ma"].ToString()));
					if (dr!=null)
					{
						dr[0]["c01"]=r["c01"].ToString();
						dr[0]["c02"]=Decimal.Parse(dr[0]["c02"].ToString())+Decimal.Parse(r["c02"].ToString());
						dr[0]["c03"]=Decimal.Parse(dr[0]["c03"].ToString())+Decimal.Parse(r["c03"].ToString());
						dr[0]["c04"]=Decimal.Parse(dr[0]["c04"].ToString())+Decimal.Parse(r["c04"].ToString());
						dr[0]["c05"]=Decimal.Parse(dr[0]["c05"].ToString())+Decimal.Parse(r["c05"].ToString());
						dr[0]["c06"]=Decimal.Parse(dr[0]["c06"].ToString())+Decimal.Parse(r["c06"].ToString());
						dr[0]["c07"]=Decimal.Parse(dr[0]["c07"].ToString())+Decimal.Parse(r["c07"].ToString());
						dr[0]["c08"]=Decimal.Parse(dr[0]["c08"].ToString())+Decimal.Parse(r["c08"].ToString());
						dr[0]["c09"]=Decimal.Parse(dr[0]["c09"].ToString())+Decimal.Parse(r["c09"].ToString());
						dr[0]["c10"]=Decimal.Parse(dr[0]["c10"].ToString())+Decimal.Parse(r["c10"].ToString());
						dr[0]["c11"]=Decimal.Parse(dr[0]["c11"].ToString())+Decimal.Parse(r["c11"].ToString());
					}
				}
			}
			if (phatsinh) m.delrec(ds.Tables[0],"c02+c03+c04+c05+c06+c07+c08+c09+c10+c11=0");
			return ds;
		}

		public DataSet bieu_031_bv(string s_tu,string s_den,string s_table,bool benhan,bool thongke,bool phatsinh)
		{
			DataRow[] dr;
			DataRow r1;
			Int64 songay,c04,c05,c08,c09,c10,ma;
			string ngay;
			ds=m.get_data("select * from "+s_table+" order by ma"); 
			m.delrec(ds.Tables[0],"ma>2");
			ds.AcceptChanges();
			if (benhan)
			{	
				sql="SELECT a.ngay as ngayvv,a.madoituong,a.nhantu,b.ttlucrv,c.namsinh,";
				sql+="b.ngay as ngayrv,d.makp as ma,c.phai,d.tenkp";
				sql+=" FROM ((BENHANDT a LEFT JOIN XUATVIEN b ON a.MAQL=b.MAQL)";
				sql+=" INNER JOIN BTDBN c ON a.MABN=c.MABN) INNER JOIN BTDKP_BV d ON a.MAKP=d.MAKP";
				sql+=" where  to_date(a.ngay,'dd/mm/yy') between to_date('"+s_tu+"','dd/mm/yy') and to_date('"+s_den+"','dd/mm/yy')";
				sql+=" and a.loaiba=1";
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					ma=int.Parse(r["ma"].ToString())+2;
					r1=m.getrowbyid(ds.Tables[0],"ma="+ma);
					if (r1==null) m.updrec_bieu(ds.Tables[0],ma,r["tenkp"].ToString(),11);
					dr=ds.Tables[0].Select("ma="+ma);
					if (dr!=null)
					{
						c10=(r["madoituong"].ToString()=="1")?1:0;
						c04=(DateTime.Now.Year-int.Parse(r["namsinh"].ToString())<15)?1:0;
						c05=(r["nhantu"].ToString()=="1")?1:0;
						dr[0]["c04"]=Decimal.Parse(dr[0]["c04"].ToString())+c04;
						dr[0]["c05"]=Decimal.Parse(dr[0]["c05"].ToString())+c05;				
						dr[0]["c10"]=Decimal.Parse(dr[0]["c10"].ToString())+c10;
					}
				}
				//phai=1 nu
				sql+=" and c.phai=1";
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					ma=2;
					dr=ds.Tables[0].Select("ma="+ma);
					if (dr!=null)
					{
						c10=(r["madoituong"].ToString()=="1")?1:0;
						c04=(DateTime.Now.Year-int.Parse(r["namsinh"].ToString())<15)?1:0;
						c05=(r["nhantu"].ToString()=="1")?1:0;
						dr[0]["c04"]=Decimal.Parse(dr[0]["c04"].ToString())+c04;
						dr[0]["c05"]=Decimal.Parse(dr[0]["c05"].ToString())+c05;				
						dr[0]["c10"]=Decimal.Parse(dr[0]["c10"].ToString())+c10;
					}
				}
				//
				sql="SELECT a.khoachuyen,to_char(a.ngay,'dd/mm/yyyy') as ngayvv,b.ttlucrk as ttlucrv,c.namsinh,";
				sql+="to_char(b.ngay,'dd/mm/yyyy') as ngayrv,d.makp as ma,c.phai,d.tenkp";
				sql+=" FROM ((nhapkhoa a LEFT JOIN xuatkhoa b ON a.id=b.id)";
				sql+=" INNER JOIN BTDBN c ON a.MABN=c.MABN) INNER JOIN BTDKP_BV d ON a.MAKP=d.MAKP";
				sql+=" where  b.ngay is null and to_date(a.ngay,'dd/mm/yy') between to_date('"+s_tu+"','dd/mm/yy') and to_date('"+s_den+"','dd/mm/yy')";
				sql+=" and a.maba<20";
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					ma=int.Parse(r["ma"].ToString())+2;
					r1=m.getrowbyid(ds.Tables[0],"ma="+ma);
					if (r1==null) m.updrec_bieu(ds.Tables[0],ma,r["tenkp"].ToString(),11);
					dr=ds.Tables[0].Select("ma="+ma);
					if (dr!=null)
					{
						if (r["ngayrv"].ToString()=="") ngay=s_den;
						else ngay=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayrv"].ToString()));
						songay=m.songay(m.StringToDate(ngay),m.StringToDate(m.Max(m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayvv"].ToString())),s_tu)),(r["khoachuyen"].ToString()=="01")?1:0);
						dr[0]["c06"]=Decimal.Parse(dr[0]["c06"].ToString())+songay;
						if (r["ttlucrv"].ToString()=="7")
						{
							c08=(DateTime.Now.Year-int.Parse(r["namsinh"].ToString())<15)?1:0;
							c09=(m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayvv"].ToString()))==m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayrv"].ToString())))?1:0;
							dr[0]["c07"]=Decimal.Parse(dr[0]["c07"].ToString())+1;
							dr[0]["c08"]=Decimal.Parse(dr[0]["c08"].ToString())+c08;
							dr[0]["c09"]=Decimal.Parse(dr[0]["c09"].ToString())+c09;
						}
					}
				}
				//
				sql="SELECT a.khoachuyen,to_char(a.ngay,'dd/mm/yyyy') as ngayvv,b.ttlucrk as ttlucrv,c.namsinh,";
				sql+="to_char(b.ngay,'dd/mm/yyyy') as ngayrv,d.makp as ma,c.phai,d.tenkp";
				sql+=" FROM ((nhapkhoa a LEFT JOIN xuatkhoa b ON a.id=b.id)";
				sql+=" INNER JOIN BTDBN c ON a.MABN=c.MABN) INNER JOIN BTDKP_BV d ON a.MAKP=d.MAKP";
				sql+=" where  to_date(b.ngay,'dd/mm/yy') between to_date('"+s_tu+"','dd/mm/yy') and to_date('"+s_den+"','dd/mm/yy')";
				sql+=" and a.maba<20";
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					ma=int.Parse(r["ma"].ToString())+2;
					r1=m.getrowbyid(ds.Tables[0],"ma="+ma);
					if (r1==null) m.updrec_bieu(ds.Tables[0],ma,r["tenkp"].ToString(),11);
					dr=ds.Tables[0].Select("ma="+ma);
					if (dr!=null)
					{
						if (r["ngayrv"].ToString()=="") ngay=s_den;
						else ngay=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayrv"].ToString()));
						songay=m.songay(m.StringToDate(ngay),m.StringToDate(m.Max(m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayvv"].ToString())),s_tu)),(r["khoachuyen"].ToString()=="01")?1:0);
						dr[0]["c06"]=Decimal.Parse(dr[0]["c06"].ToString())+songay;
						if (r["ttlucrv"].ToString()=="7")
						{
							c08=(DateTime.Now.Year-int.Parse(r["namsinh"].ToString())<15)?1:0;
							c09=(m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayvv"].ToString()))==m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayrv"].ToString())))?1:0;
							dr[0]["c07"]=Decimal.Parse(dr[0]["c07"].ToString())+1;
							dr[0]["c08"]=Decimal.Parse(dr[0]["c08"].ToString())+c08;
							dr[0]["c09"]=Decimal.Parse(dr[0]["c09"].ToString())+c09;
						}
					}
				}
				//phai=1
				//
				sql="SELECT a.khoachuyen,to_char(a.ngay,'dd/mm/yyyy') as ngayvv,b.ttlucrk as ttlucrv,c.namsinh,";
				sql+="to_char(b.ngay,'dd/mm/yyyy') as ngayrv,d.makp as ma,c.phai";
				sql+=" FROM ((nhapkhoa a LEFT JOIN xuatkhoa b ON a.id=b.id)";
				sql+=" INNER JOIN BTDBN c ON a.MABN=c.MABN) INNER JOIN BTDKP_BV d ON a.MAKP=d.MAKP";
				sql+=" where  b.ngay is null and to_date(a.ngay,'dd/mm/yy') between to_date('"+s_tu+"','dd/mm/yy') and to_date('"+s_den+"','dd/mm/yy')";
				sql+=" and a.maba<20 and c.phai=1";
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					ma=2;
					dr=ds.Tables[0].Select("ma="+ma);
					if (dr!=null)
					{
						if (r["ngayrv"].ToString()=="") ngay=s_den;
						else ngay=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayrv"].ToString()));
						songay=m.songay(m.StringToDate(ngay),m.StringToDate(m.Max(m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayvv"].ToString())),s_tu)),(r["khoachuyen"].ToString()=="01")?1:0);
						dr[0]["c06"]=Decimal.Parse(dr[0]["c06"].ToString())+songay;
						if (r["ttlucrv"].ToString()=="7")
						{
							c08=(DateTime.Now.Year-int.Parse(r["namsinh"].ToString())<15)?1:0;
							c09=(m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayvv"].ToString()))==m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayrv"].ToString())))?1:0;
							dr[0]["c07"]=Decimal.Parse(dr[0]["c07"].ToString())+1;
							dr[0]["c08"]=Decimal.Parse(dr[0]["c08"].ToString())+c08;
							dr[0]["c09"]=Decimal.Parse(dr[0]["c09"].ToString())+c09;
						}
					}
				}
				//
				sql="SELECT a.khoachuyen,to_char(a.ngay,'dd/mm/yyyy') as ngayvv,b.ttlucrk as ttlucrv,c.namsinh,";
				sql+="to_char(b.ngay,'dd/mm/yyyy') as ngayrv,d.makp as ma,c.phai";
				sql+=" FROM ((nhapkhoa a LEFT JOIN xuatkhoa b ON a.id=b.id)";
				sql+=" INNER JOIN BTDBN c ON a.MABN=c.MABN) INNER JOIN BTDKP_BV d ON a.MAKP=d.MAKP";
				sql+=" where  to_date(b.ngay,'dd/mm/yy') between to_date('"+s_tu+"','dd/mm/yy') and to_date('"+s_den+"','dd/mm/yy')";
				sql+=" and a.maba<20 and c.phai=1";
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					ma=2;
					dr=ds.Tables[0].Select("ma="+ma);
					if (dr!=null)
					{
						if (r["ngayrv"].ToString()=="") ngay=s_den;
						else ngay=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayrv"].ToString()));
						songay=m.songay(m.StringToDate(ngay),m.StringToDate(m.Max(m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayvv"].ToString())),s_tu)),(r["khoachuyen"].ToString()=="01")?1:0);
						dr[0]["c06"]=Decimal.Parse(dr[0]["c06"].ToString())+songay;
						if (r["ttlucrv"].ToString()=="7")
						{
							c08=(DateTime.Now.Year-int.Parse(r["namsinh"].ToString())<15)?1:0;
							c09=(m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayvv"].ToString()))==m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngayrv"].ToString())))?1:0;
							dr[0]["c07"]=Decimal.Parse(dr[0]["c07"].ToString())+1;
							dr[0]["c08"]=Decimal.Parse(dr[0]["c08"].ToString())+c08;
							dr[0]["c09"]=Decimal.Parse(dr[0]["c09"].ToString())+c09;
						}
					}
				}
				//dau ky + cuoi ky
				sql="SELECT c.MAKP ma,sum(case when (to_date(a.ngay,'dd/mm/yy')<to_date('"+s_tu+"','dd/mm/yy') and (b.ngay is null or to_date(b.ngay,'dd/mm/yy')>=to_date('"+s_tu+"','dd/mm/yy'))) then 1 else 0 end) C03,";
				sql+="sum(case when a.khoachuyen='01' and to_date(a.ngay,'dd/mm/yy') Between to_date('"+s_tu+"','dd/mm/yy') And to_date('"+s_den+"','dd/mm/yy') then 1 else 0 end) C04,";
				sql+="sum(case when a.khoachuyen<>'01' and to_date(a.ngay,'dd/mm/yy') Between to_date('"+s_tu+"','dd/mm/yy') And to_date('"+s_den+"','dd/mm/yy') then 1 else 0 end) C05,";
				sql+="Sum(case when b.ngay is null then 0 else case when b.ttlucrk=1 And to_date(b.ngay,'dd/mm/yy') Between to_date('"+s_tu+"','dd/mm/yy') And to_date('"+s_den+"','dd/mm/yy') then 1 else 0 end end) C06,";
				sql+="Sum(case when b.ngay is null then 0 else case when b.ttlucrk=2 And to_date(b.ngay,'dd/mm/yy') Between to_date('"+s_tu+"','dd/mm/yy') And to_date('"+s_den+"','dd/mm/yy') then 1 else 0 end end) C07,";
				sql+="Sum(case when b.ngay is null then 0 else case when b.ttlucrk=3 And to_date(b.ngay,'dd/mm/yy') Between to_date('"+s_tu+"','dd/mm/yy') And to_date('"+s_den+"','dd/mm/yy') then 1 else 0 end end) C08,";
				sql+="Sum(case when b.ngay is null then 0 else case when b.ttlucrk=4 And to_date(b.ngay,'dd/mm/yy') Between to_date('"+s_tu+"','dd/mm/yy') And to_date('"+s_den+"','dd/mm/yy') then 1 else 0 end end) C09,";
				sql+="Sum(case when b.ngay is null then 0 else case when b.ttlucrk=5 And to_date(b.ngay,'dd/mm/yy') Between to_date('"+s_tu+"','dd/mm/yy') And to_date('"+s_den+"','dd/mm/yy') then 1 else 0 end end) C10,";
				sql+="Sum(case when b.ngay is null then 0 else case when b.ttlucrk=6 And to_date(b.ngay,'dd/mm/yy') Between to_date('"+s_tu+"','dd/mm/yy') And to_date('"+s_den+"','dd/mm/yy') then 1 else 0 end end) C11,";
				sql+="Sum(case when b.ngay is null then 0 else case when b.ttlucrk=7 And to_date(b.ngay,'dd/mm/yy') Between to_date('"+s_tu+"','dd/mm/yy') And to_date('"+s_den+"','dd/mm/yy') then 1 else 0 end end) C12,";
				sql+="sum(case when b.ngay is null or to_date(b.ngay,'dd/mm/yy')>to_date('"+s_den+"','dd/mm/yy') then 1 else 0 end) C13";
				sql+=" FROM NHAPKHOA a,XUATKHOA b,BTDKP_BV c,BTDBN d ";
				sql+=" WHERE a.MAKP=c.MAKP and a.ID=b.ID(+) and a.mabn=d.mabn and a.maba<20 ";
				foreach(DataRow r in m.get_data(sql+"GROUP BY c.makp ORDER BY c.makp").Tables[0].Rows)
				{
					ma=int.Parse(r["ma"].ToString())+2;
					r1=m.getrowbyid(ds.Tables[0],"ma="+ma);
					if (r1==null) m.updrec_bieu(ds.Tables[0],ma,m.get_data("select tenkp from btdkp_bv where makp='"+r["ma"].ToString()+"'").Tables[0].Rows[0][0].ToString(),11);
					dr=ds.Tables[0].Select("ma="+ma);
					if (dr!=null)
					{
						dr[0]["c02"]=Decimal.Parse(r["c03"].ToString());
						dr[0]["c03"]=Decimal.Parse(dr[0]["c03"].ToString())+Decimal.Parse(r["c04"].ToString());
						dr[0]["c11"]=Decimal.Parse(r["c03"].ToString())+Decimal.Parse(r["c04"].ToString())+Decimal.Parse(r["c05"].ToString())-(Decimal.Parse(r["c06"].ToString())+Decimal.Parse(r["c07"].ToString())+Decimal.Parse(r["c08"].ToString())+Decimal.Parse(r["c09"].ToString())+Decimal.Parse(r["c10"].ToString())+Decimal.Parse(r["c11"].ToString())+Decimal.Parse(r["c12"].ToString()));
					}
				}
				//phai=1
				sql+=" and d.phai=1 ";
				foreach(DataRow r in m.get_data(sql+"GROUP BY c.makp ORDER BY c.makp").Tables[0].Rows)
				{
					ma=2;
					dr=ds.Tables[0].Select("ma="+ma);
					if (dr!=null)
					{
						dr[0]["c02"]=Decimal.Parse(r["c03"].ToString());
						dr[0]["c03"]=Decimal.Parse(dr[0]["c03"].ToString())+Decimal.Parse(r["c04"].ToString());
						dr[0]["c11"]=Decimal.Parse(r["c03"].ToString())+Decimal.Parse(r["c04"].ToString())+Decimal.Parse(r["c05"].ToString())-(Decimal.Parse(r["c06"].ToString())+Decimal.Parse(r["c07"].ToString())+Decimal.Parse(r["c08"].ToString())+Decimal.Parse(r["c09"].ToString())+Decimal.Parse(r["c10"].ToString())+Decimal.Parse(r["c11"].ToString())+Decimal.Parse(r["c12"].ToString()));
					}
				}
				DataRow r2;
				int i_ma;
				foreach(DataRow r in m.get_data("select makp,sum(kehoach) as kh from btdkp_bv group by makp order by makp").Tables[0].Rows)
				{
					i_ma=int.Parse(r["makp"].ToString())+2;
					r2=m.getrowbyid(ds.Tables[0],"ma="+i_ma);
					if (r2!=null) r2["c01"]=r["kh"].ToString();
				}
				tongcong("ma>2","1",3);
			}
			#region 29102004
			/*
			if (thongke)
			{
				sql="select a.ma,sum(a.c01) as c01,sum(a.c02) as c02,sum(a.c03) as c03,sum(a.c04) as c04,";
				sql+="sum(a.c05) as c05,sum(a.c06) as c06,sum(a.c07) as c07,sum(a.c08) as c08,";
				sql+="sum(a.c09) as c09,sum(a.c10) as c10,sum(a.c11) as c11";
				sql+=" from bieu_031 a,dm_031 b where a.ma=b.ma ";
				sql+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+s_tu+"','dd/mm/yy') and to_date('"+s_den+"','dd/mm/yy')";
				sql+=" group by a.ma";
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					dr=ds.Tables[0].Select("ma="+int.Parse(r["ma"].ToString()));
					if (dr!=null)
					{
						dr[0]["c01"]=r["c01"].ToString();
						dr[0]["c02"]=Decimal.Parse(dr[0]["c02"].ToString())+Decimal.Parse(r["c02"].ToString());
						dr[0]["c03"]=Decimal.Parse(dr[0]["c03"].ToString())+Decimal.Parse(r["c03"].ToString());
						dr[0]["c04"]=Decimal.Parse(dr[0]["c04"].ToString())+Decimal.Parse(r["c04"].ToString());
						dr[0]["c05"]=Decimal.Parse(dr[0]["c05"].ToString())+Decimal.Parse(r["c05"].ToString());
						dr[0]["c06"]=Decimal.Parse(dr[0]["c06"].ToString())+Decimal.Parse(r["c06"].ToString());
						dr[0]["c07"]=Decimal.Parse(dr[0]["c07"].ToString())+Decimal.Parse(r["c07"].ToString());
						dr[0]["c08"]=Decimal.Parse(dr[0]["c08"].ToString())+Decimal.Parse(r["c08"].ToString());
						dr[0]["c09"]=Decimal.Parse(dr[0]["c09"].ToString())+Decimal.Parse(r["c09"].ToString());
						dr[0]["c10"]=Decimal.Parse(dr[0]["c10"].ToString())+Decimal.Parse(r["c10"].ToString());
						dr[0]["c11"]=Decimal.Parse(dr[0]["c11"].ToString())+Decimal.Parse(r["c11"].ToString());
					}
				}
			}
			*/
			#endregion
			if (phatsinh) m.delrec(ds.Tables[0],"c02+c03+c04+c05+c06+c07+c08+c09+c10+c11=0");
			return ds;
		}

		public DataSet bieu_04(string s_tu,string s_den,string s_table,bool benhan,bool thongke,bool phatsinh)
		{
			DataRow[] dr;
			int c02,c03,c05,c06,c07,c09,c10,ma,so;
			ds=m.get_data("select * from "+s_table+" order by ma"); 
			if (benhan)
			{	
				sql="SELECT a.mapt,b.loaipt,a.tinhhinh,a.taibien,a.tuvong";
				sql+=" FROM PTTT a INNER JOIN DMPTTT b ON a.MAPT = b.MAPT";
				sql+=" where to_date(a.ngay,'dd/mm/yy') between to_date('"+s_tu+"','dd/mm/yy') and to_date('"+s_den+"','dd/mm/yy')";
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					so=(r["mapt"].ToString().Substring(0,1)=="P")?1:10;
					ma=int.Parse(r["loaipt"].ToString())+so;
					dr=ds.Tables[0].Select("ma="+ma);
					if (dr!=null)
					{
						c02=(r["tinhhinh"].ToString()=="2")?1:0;
						c03=(r["tinhhinh"].ToString()!="2")?1:0;
						dr[0]["c01"]=Decimal.Parse(dr[0]["c01"].ToString())+1;
						dr[0]["c02"]=Decimal.Parse(dr[0]["c02"].ToString())+c02;
						dr[0]["c03"]=Decimal.Parse(dr[0]["c03"].ToString())+c03;
						if (r["taibien"].ToString()!="0")
						{
							c05=(r["taibien"].ToString()=="2")?1:0;
							c06=(r["taibien"].ToString()=="3")?1:0;
							c07=(r["taibien"].ToString()!="2" || r["taibien"].ToString()!="3")?1:0;
							dr[0]["c04"]=Decimal.Parse(dr[0]["c04"].ToString())+1;
							dr[0]["c05"]=Decimal.Parse(dr[0]["c05"].ToString())+c05;
							dr[0]["c06"]=Decimal.Parse(dr[0]["c06"].ToString())+c06;
							dr[0]["c07"]=Decimal.Parse(dr[0]["c07"].ToString())+c07;
						}
						if (r["tuvong"].ToString()!="0")
						{
							c09=(r["tuvong"].ToString()=="1")?1:0;
							c10=(r["tuvong"].ToString()=="2")?1:0;
							dr[0]["c08"]=Decimal.Parse(dr[0]["c08"].ToString())+1;
							dr[0]["c09"]=Decimal.Parse(dr[0]["c09"].ToString())+c09;
							dr[0]["c10"]=Decimal.Parse(dr[0]["c10"].ToString())+c10;
						}
					}
				}
				tongcong("ma>1 and ma<10","A",3);
				tongcong("ma>10","B",3);
			}
			
			if (thongke)
			{
				sql="select a.ma,sum(a.c01) as c01,sum(a.c02) as c02,sum(a.c03) as c03,sum(a.c04) as c04,";
				sql+="sum(a.c05) as c05,sum(a.c06) as c06,sum(a.c07) as c07,sum(a.c08) as c08,";
				sql+="sum(a.c09) as c09,sum(a.c10) as c10";
				sql+=" from bieu_04 a,dm_04 b where a.ma=b.ma ";
				sql+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+s_tu+"','dd/mm/yy') and to_date('"+s_den+"','dd/mm/yy')";
				sql+=" group by a.ma";
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					dr=ds.Tables[0].Select("ma="+int.Parse(r["ma"].ToString()));
					if (dr!=null)
					{
						dr[0]["c01"]=Decimal.Parse(dr[0]["c01"].ToString())+Decimal.Parse(r["c01"].ToString());
						dr[0]["c02"]=Decimal.Parse(dr[0]["c02"].ToString())+Decimal.Parse(r["c02"].ToString());
						dr[0]["c03"]=Decimal.Parse(dr[0]["c03"].ToString())+Decimal.Parse(r["c03"].ToString());
						dr[0]["c04"]=Decimal.Parse(dr[0]["c04"].ToString())+Decimal.Parse(r["c04"].ToString());
						dr[0]["c05"]=Decimal.Parse(dr[0]["c05"].ToString())+Decimal.Parse(r["c05"].ToString());
						dr[0]["c06"]=Decimal.Parse(dr[0]["c06"].ToString())+Decimal.Parse(r["c06"].ToString());
						dr[0]["c07"]=Decimal.Parse(dr[0]["c07"].ToString())+Decimal.Parse(r["c07"].ToString());
						dr[0]["c08"]=Decimal.Parse(dr[0]["c08"].ToString())+Decimal.Parse(r["c08"].ToString());
						dr[0]["c09"]=Decimal.Parse(dr[0]["c09"].ToString())+Decimal.Parse(r["c09"].ToString());
						dr[0]["c10"]=Decimal.Parse(dr[0]["c10"].ToString())+Decimal.Parse(r["c10"].ToString());
					}
				}
			}
			if (phatsinh) m.delrec(ds.Tables[0],"c01+c02+c03+c04+c05+c06+c07+c08+c09+c10=0");
			return ds;
		}

		public DataSet bieu_11(string s_tu,string s_den,string s_table,bool benhan,bool thongke,bool phatsinh)
		{
			DataRow[] dr;
			ds=m.get_data("select * from "+s_table+" order by ma"); 
			if (benhan)
			{	
				sql="SELECT d.STT,sum(decode(b.loaiba,3,1,0)) as c01,sum(case when b.loaiba=3 and to_char(sysdate,'yyyy')-c.namsinh<15 then 1 else 0 end) as c02,";
				sql+="sum(case when b.loaiba=3 and to_char(sysdate,'yyyy')-c.namsinh<15 and a.ttlucrv=7 then 1 else 0 end) as c03,";
				sql+="sum(decode(b.loaiba,1,1,0)) as c04,sum(case when b.loaiba=1 and a.ttlucrv=7 then 1 else 0 end) as c05,";
				sql+="sum(decode(b.loaiba,1,to_date(a.ngay,'dd/mm/yy')-to_date(b.ngay,'dd/mm/yy')+1,0)) as c06,";
				sql+="sum(case when b.loaiba=1 and to_char(sysdate,'yyyy')-c.namsinh<15 then 1 else 0 end) as c07,";
				sql+="sum(case when b.loaiba=1 and to_char(sysdate,'yyyy')-c.namsinh<=4 then 1 else 0 end) as c08,";
				sql+="sum(case when b.loaiba=1 and to_char(sysdate,'yyyy')-c.namsinh<15 and a.ttlucrv=7 then 1 else 0 end) as c09,";
				sql+="sum(case when b.loaiba=1 and to_char(sysdate,'yyyy')-c.namsinh<=4 and a.ttlucrv=7 then 1 else 0 end) as c10,";
				sql+="sum(case when b.loaiba=1 and to_char(sysdate,'yyyy')-c.namsinh<15 then to_date(a.ngay,'dd/mm/yy')-to_date(b.ngay,'dd/mm/yy')+1 else 0 end) as c11,";
				sql+="sum(case when b.loaiba=1 and to_char(sysdate,'yyyy')-c.namsinh<=4 then to_date(a.ngay,'dd/mm/yy')-to_date(b.ngay,'dd/mm/yy')+1 else 0 end) as c12";
				sql+=" FROM XUATVIEN a,BENHANDT b,BTDBN c,ICD10 d";
				sql+=" where a.MAQL = b.MAQL and a.MABN = c.MABN and a.MAICD = d.CICD10 and d.stt is not null and to_date(a.ngay,'dd/mm/yy') between to_date('"+s_tu+"','dd/mm/yy') and to_date('"+s_den+"','dd/mm/yy')";
				sql+="group by d.stt";
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					dr=ds.Tables[0].Select("stt='"+r["stt"].ToString()+"'");
					if (dr!=null)
					{
						dr[0]["c01"]=r["c01"].ToString();
						dr[0]["c02"]=r["c02"].ToString();
						dr[0]["c03"]=r["c03"].ToString();
						dr[0]["c04"]=r["c04"].ToString();
						dr[0]["c05"]=r["c05"].ToString();
						dr[0]["c06"]=r["c06"].ToString();
						dr[0]["c07"]=r["c07"].ToString();
						dr[0]["c08"]=r["c08"].ToString();
						dr[0]["c09"]=r["c09"].ToString();
						dr[0]["c10"]=r["c10"].ToString();
						dr[0]["c11"]=r["c11"].ToString();
						dr[0]["c12"]=r["c12"].ToString();
					}
				}
				tongcong("ma>=2 and ma<=58","C01",4);
				tongcong("ma>=60 and ma<=98","C02",4);
				tongcong("ma>=100 and ma<=103","C03",4);
				tongcong("ma>=105 and ma<=115","C04",4);
				tongcong("ma>=117 and ma<=124","C05",4);
				tongcong("ma>=126 and ma<=135","C06",4);
				tongcong("ma>=137 and ma<=146","C07",4);
				tongcong("ma>=148 and ma<=150","C08",4);
				tongcong("ma>=152 and ma<=173","C09",4);
				tongcong("ma>=175 and ma<=189","C10",4);
				tongcong("ma>=191 and ma<=208","C11",4);
				tongcong("ma>=210 and ma<=211","C12",4);
				tongcong("ma>=213 and ma<=223","C13",4);
				tongcong("ma>=225 and ma<=247","C14",4);
				tongcong("ma>=249 and ma<=259","C15",4);
				tongcong("ma>=261 and ma<=269","C16",4);
				tongcong("ma>=271 and ma<=283","C17",4);
				tongcong("ma>=285 and ma<=288","C18",4);
				tongcong("ma>=290 and ma<=308","C19",4);
				tongcong("ma>=310 and ma<=323","C20",4);
				tongcong("ma>=325 and ma<=333","C21",4);
			}
			
			if (thongke)
			{
				sql="select a.ma,sum(a.c01) as c01,sum(a.c02) as c02,sum(a.c03) as c03,sum(a.c04) as c04,";
				sql+="sum(a.c05) as c05,sum(a.c06) as c06,sum(a.c07) as c07,sum(a.c08) as c08,";
				sql+="sum(a.c09) as c09,sum(a.c10) as c10,sum(a.c11) as c11,sum(a.c12) as c12";
				sql+=" from bieu_11 a,dm_11 b where a.ma=b.ma ";
				sql+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+s_tu+"','dd/mm/yy') and to_date('"+s_den+"','dd/mm/yy')";
				sql+=" group by a.ma";
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					dr=ds.Tables[0].Select("ma="+int.Parse(r["ma"].ToString()));
					if (dr!=null)
					{
						dr[0]["c01"]=Decimal.Parse(dr[0]["c01"].ToString())+Decimal.Parse(r["c01"].ToString());
						dr[0]["c02"]=Decimal.Parse(dr[0]["c02"].ToString())+Decimal.Parse(r["c02"].ToString());
						dr[0]["c03"]=Decimal.Parse(dr[0]["c03"].ToString())+Decimal.Parse(r["c03"].ToString());
						dr[0]["c04"]=Decimal.Parse(dr[0]["c04"].ToString())+Decimal.Parse(r["c04"].ToString());
						dr[0]["c05"]=Decimal.Parse(dr[0]["c05"].ToString())+Decimal.Parse(r["c05"].ToString());
						dr[0]["c06"]=Decimal.Parse(dr[0]["c06"].ToString())+Decimal.Parse(r["c06"].ToString());
						dr[0]["c07"]=Decimal.Parse(dr[0]["c07"].ToString())+Decimal.Parse(r["c07"].ToString());
						dr[0]["c08"]=Decimal.Parse(dr[0]["c08"].ToString())+Decimal.Parse(r["c08"].ToString());
						dr[0]["c09"]=Decimal.Parse(dr[0]["c09"].ToString())+Decimal.Parse(r["c09"].ToString());
						dr[0]["c10"]=Decimal.Parse(dr[0]["c10"].ToString())+Decimal.Parse(r["c10"].ToString());
						dr[0]["c11"]=Decimal.Parse(dr[0]["c11"].ToString())+Decimal.Parse(r["c11"].ToString());
						dr[0]["c12"]=Decimal.Parse(dr[0]["c12"].ToString())+Decimal.Parse(r["c12"].ToString());
					}
				}
			}
			if (phatsinh) m.delrec(ds.Tables[0],"c01+c02+c03+c04+c05+c06+c07+c08+c09+c10+c11+c12=0");
			return ds;
		}

		public DataSet kh_bieu_15(string s_tu,string s_den,string s_table,bool benhan,bool thongke,bool phatsinh)
		{
			DataRow[] dr;
			ds=m.get_data("select * from "+s_table+" order by ma"); 
			if (benhan)
			{	
				sql="SELECT d.STT,count(*) as c01,sum(decode(a.ttlucrv,7,1,0)) as c02,";
				sql+="sum(case when to_char(sysdate,'yyyy')-c.namsinh<15 then 1 else 0 end) as c03,";
				sql+="sum(case when to_char(sysdate,'yyyy')-c.namsinh<=4 then 1 else 0 end) as c04,";
				sql+="sum(case when to_char(sysdate,'yyyy')-c.namsinh<15 and a.ttlucrv=7 then 1 else 0 end) as c05,";
				sql+="sum(case when to_char(sysdate,'yyyy')-c.namsinh<=4 and a.ttlucrv=7 then 1 else 0 end) as c06";
				sql+=" FROM XUATVIEN a,BENHANDT b,BTDBN c,ICD10 d";
				sql+=" where a.MAQL = b.MAQL and a.MABN = c.MABN and a.MAICD = d.CICD10 and d.stt is not null and to_date(a.ngay,'dd/mm/yy') between to_date('"+s_tu+"','dd/mm/yy') and to_date('"+s_den+"','dd/mm/yy')";
				sql+="group by d.stt";
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					dr=ds.Tables[0].Select("stt='"+r["stt"].ToString()+"'");
					if (dr!=null)
					{
						dr[0]["c01"]=r["c01"].ToString();
						dr[0]["c02"]=r["c02"].ToString();
						dr[0]["c03"]=r["c03"].ToString();
						dr[0]["c04"]=r["c04"].ToString();
						dr[0]["c05"]=r["c05"].ToString();
						dr[0]["c06"]=r["c06"].ToString();
					}
				}
				tongcong("ma>=2 and ma<=58","C01",4);
				tongcong("ma>=60 and ma<=98","C02",4);
				tongcong("ma>=100 and ma<=103","C03",4);
				tongcong("ma>=105 and ma<=115","C04",4);
				tongcong("ma>=117 and ma<=124","C05",4);
				tongcong("ma>=126 and ma<=135","C06",4);
				tongcong("ma>=137 and ma<=146","C07",4);
				tongcong("ma>=148 and ma<=150","C08",4);
				tongcong("ma>=152 and ma<=173","C09",4);
				tongcong("ma>=175 and ma<=189","C10",4);
				tongcong("ma>=191 and ma<=208","C11",4);
				tongcong("ma>=210 and ma<=211","C12",4);
				tongcong("ma>=213 and ma<=223","C13",4);
				tongcong("ma>=225 and ma<=247","C14",4);
				tongcong("ma>=249 and ma<=259","C15",4);
				tongcong("ma>=261 and ma<=269","C16",4);
				tongcong("ma>=271 and ma<=283","C17",4);
				tongcong("ma>=285 and ma<=288","C18",4);
				tongcong("ma>=290 and ma<=308","C19",4);
				tongcong("ma>=310 and ma<=323","C20",4);
				tongcong("ma>=325 and ma<=333","C21",4);
			}
			
			if (thongke)
			{
				sql="select a.ma,sum(a.c01) as c01,sum(a.c02) as c02,sum(a.c03) as c03,sum(a.c04) as c04,";
				sql+="sum(a.c05) as c05,sum(a.c06) as c06";
				sql+=" from kh_bieu_15 a,dm_11 b where a.ma=b.ma ";
				sql+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+s_tu+"','dd/mm/yy') and to_date('"+s_den+"','dd/mm/yy')";
				sql+=" group by a.ma";
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					dr=ds.Tables[0].Select("ma="+int.Parse(r["ma"].ToString()));
					if (dr!=null)
					{
						dr[0]["c01"]=Decimal.Parse(dr[0]["c01"].ToString())+Decimal.Parse(r["c01"].ToString());
						dr[0]["c02"]=Decimal.Parse(dr[0]["c02"].ToString())+Decimal.Parse(r["c02"].ToString());
						dr[0]["c03"]=Decimal.Parse(dr[0]["c03"].ToString())+Decimal.Parse(r["c03"].ToString());
						dr[0]["c04"]=Decimal.Parse(dr[0]["c04"].ToString())+Decimal.Parse(r["c04"].ToString());
						dr[0]["c05"]=Decimal.Parse(dr[0]["c05"].ToString())+Decimal.Parse(r["c05"].ToString());
						dr[0]["c06"]=Decimal.Parse(dr[0]["c06"].ToString())+Decimal.Parse(r["c06"].ToString());
					}
				}
			}
			if (phatsinh) m.delrec(ds.Tables[0],"c01+c02+c03+c04+c05+c06=0");
			return ds;
		}

		public DataSet kh_bieu_145(string s_tu,string s_den,string s_table,bool benhan,bool thongke,bool phatsinh)
		{
			DataRow[] dr;
			ds=m.get_data("select * from "+s_table+" order by ma"); 
			if (benhan)
			{	
				sql="SELECT e.stt,sum(decode(c.phai,0,1,0)) as c01, sum(case when c.phai=0 and a.ttlucrv=7 then 1 else 0 end) as c02,";
				sql+="sum(decode(c.phai,1,1,0)) as c03, sum(case when c.phai=1 and a.ttlucrv=7 then 1 else 0 end) as c04,";
				sql+="sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh<=4 then 1 else 0 end) as c05, sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh<=4 and a.ttlucrv=7 then 1 else 0 end) as c06,";
				sql+="sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh<=4 then 1 else 0 end) as c07, sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh<=4 and a.ttlucrv=7 then 1 else 0 end) as c08,";
				sql+="sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh>4 and to_char(sysdate,'yyyy')-c.namsinh<=14 then 1 else 0 end) as c09,";
				sql+="sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh>4 and to_char(sysdate,'yyyy')-c.namsinh<=14  and a.ttlucrv=7 then 1 else 0 end) as c10,";
				sql+="sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh>4 and to_char(sysdate,'yyyy')-c.namsinh<=14 then 1 else 0 end) as c11,";
				sql+="sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh>4 and to_char(sysdate,'yyyy')-c.namsinh<=14  and a.ttlucrv=7 then 1 else 0 end) as c12,";
				sql+="sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh>14 and to_char(sysdate,'yyyy')-c.namsinh<=60 then 1 else 0 end) as c13,";
				sql+="sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh>14 and to_char(sysdate,'yyyy')-c.namsinh<=60  and a.ttlucrv=7 then 1 else 0 end) as c14,";
				sql+="sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh>14 and to_char(sysdate,'yyyy')-c.namsinh<=60 then 1 else 0 end) as c15,";
				sql+="sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh>14 and to_char(sysdate,'yyyy')-c.namsinh<=60  and a.ttlucrv=7 then 1 else 0 end) as c16,";
				sql+="sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh>60 then 1 else 0 end) as c17, sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh>60 and a.ttlucrv=7 then 1 else 0 end) as c18,";
				sql+="sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh>60 then 1 else 0 end) as c19, sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh>60 and a.ttlucrv=7 then 1 else 0 end) as c20";
				sql+=" FROM (((XUATVIEN a INNER JOIN TAINANTT b ON a.MAQL = b.MAQL) INNER JOIN BTDBN c ON a.MABN = c.MABN) INNER JOIN BTDNN_BV d ON c.MANN = d.MANN) INNER JOIN BTDNN e ON d.MANNBO = e.MANN";
				sql+=" where to_date(a.ngay,'dd/mm/yy') between to_date('"+s_tu+"','dd/mm/yy') and to_date('"+s_den+"','dd/mm/yy')";
				sql+=" group by e.stt";
				upd_data(sql);
				//dia diem
				sql="SELECT d.stt,sum(decode(c.phai,0,1,0)) as c01, sum(case when c.phai=0 and a.ttlucrv=7 then 1 else 0 end) as c02,";
				sql+="sum(decode(c.phai,1,1,0)) as c03, sum(case when c.phai=1 and a.ttlucrv=7 then 1 else 0 end) as c04,";
				sql+="sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh<=4 then 1 else 0 end) as c05, sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh<=4 and a.ttlucrv=7 then 1 else 0 end) as c06,";
				sql+="sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh<=4 then 1 else 0 end) as c07, sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh<=4 and a.ttlucrv=7 then 1 else 0 end) as c08,";
				sql+="sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh>4 and to_char(sysdate,'yyyy')-c.namsinh<=14 then 1 else 0 end) as c09,";
				sql+="sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh>4 and to_char(sysdate,'yyyy')-c.namsinh<=14  and a.ttlucrv=7 then 1 else 0 end) as c10,";
				sql+="sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh>4 and to_char(sysdate,'yyyy')-c.namsinh<=14 then 1 else 0 end) as c11,";
				sql+="sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh>4 and to_char(sysdate,'yyyy')-c.namsinh<=14  and a.ttlucrv=7 then 1 else 0 end) as c12,";
				sql+="sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh>14 and to_char(sysdate,'yyyy')-c.namsinh<=60 then 1 else 0 end) as c13,";
				sql+="sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh>14 and to_char(sysdate,'yyyy')-c.namsinh<=60  and a.ttlucrv=7 then 1 else 0 end) as c14,";
				sql+="sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh>14 and to_char(sysdate,'yyyy')-c.namsinh<=60 then 1 else 0 end) as c15,";
				sql+="sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh>14 and to_char(sysdate,'yyyy')-c.namsinh<=60  and a.ttlucrv=7 then 1 else 0 end) as c16,";
				sql+="sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh>60 then 1 else 0 end) as c17, sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh>60 and a.ttlucrv=7 then 1 else 0 end) as c18,";
				sql+="sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh>60 then 1 else 0 end) as c19, sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh>60 and a.ttlucrv=7 then 1 else 0 end) as c20";
				sql+=" FROM ((XUATVIEN a INNER JOIN TAINANTT b ON a.MAQL = b.MAQL) INNER JOIN BTDBN c ON a.MABN = c.MABN) INNER JOIN DMDIADIEM d ON b.DIADIEM = d.MA";
				sql+=" where d.stt<>0 and to_date(a.ngay,'dd/mm/yy') between to_date('"+s_tu+"','dd/mm/yy') and to_date('"+s_den+"','dd/mm/yy')";
				sql+=" group by d.stt";
				upd_data(sql);
				//bo phan
				sql="SELECT d.stt,sum(decode(c.phai,0,1,0)) as c01, sum(case when c.phai=0 and a.ttlucrv=7 then 1 else 0 end) as c02,";
				sql+="sum(decode(c.phai,1,1,0)) as c03, sum(case when c.phai=1 and a.ttlucrv=7 then 1 else 0 end) as c04,";
				sql+="sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh<=4 then 1 else 0 end) as c05, sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh<=4 and a.ttlucrv=7 then 1 else 0 end) as c06,";
				sql+="sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh<=4 then 1 else 0 end) as c07, sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh<=4 and a.ttlucrv=7 then 1 else 0 end) as c08,";
				sql+="sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh>4 and to_char(sysdate,'yyyy')-c.namsinh<=14 then 1 else 0 end) as c09,";
				sql+="sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh>4 and to_char(sysdate,'yyyy')-c.namsinh<=14  and a.ttlucrv=7 then 1 else 0 end) as c10,";
				sql+="sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh>4 and to_char(sysdate,'yyyy')-c.namsinh<=14 then 1 else 0 end) as c11,";
				sql+="sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh>4 and to_char(sysdate,'yyyy')-c.namsinh<=14  and a.ttlucrv=7 then 1 else 0 end) as c12,";
				sql+="sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh>14 and to_char(sysdate,'yyyy')-c.namsinh<=60 then 1 else 0 end) as c13,";
				sql+="sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh>14 and to_char(sysdate,'yyyy')-c.namsinh<=60  and a.ttlucrv=7 then 1 else 0 end) as c14,";
				sql+="sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh>14 and to_char(sysdate,'yyyy')-c.namsinh<=60 then 1 else 0 end) as c15,";
				sql+="sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh>14 and to_char(sysdate,'yyyy')-c.namsinh<=60  and a.ttlucrv=7 then 1 else 0 end) as c16,";
				sql+="sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh>60 then 1 else 0 end) as c17, sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh>60 and a.ttlucrv=7 then 1 else 0 end) as c18,";
				sql+="sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh>60 then 1 else 0 end) as c19, sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh>60 and a.ttlucrv=7 then 1 else 0 end) as c20";
				sql+=" FROM ((XUATVIEN a INNER JOIN TAINANTT b ON a.MAQL = b.MAQL) INNER JOIN BTDBN c ON a.MABN = c.MABN) INNER JOIN DMBOPHAN d ON b.BOPHAN = d.MA";
				sql+=" where d.stt<>0 and to_date(a.ngay,'dd/mm/yy') between to_date('"+s_tu+"','dd/mm/yy') and to_date('"+s_den+"','dd/mm/yy')";
				sql+=" group by d.stt";
				upd_data(sql);
				//nguyen nhan
				sql="SELECT d.stt,sum(decode(c.phai,0,1,0)) as c01, sum(case when c.phai=0 and a.ttlucrv=7 then 1 else 0 end) as c02,";
				sql+="sum(decode(c.phai,1,1,0)) as c03, sum(case when c.phai=1 and a.ttlucrv=7 then 1 else 0 end) as c04,";
				sql+="sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh<=4 then 1 else 0 end) as c05, sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh<=4 and a.ttlucrv=7 then 1 else 0 end) as c06,";
				sql+="sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh<=4 then 1 else 0 end) as c07, sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh<=4 and a.ttlucrv=7 then 1 else 0 end) as c08,";
				sql+="sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh>4 and to_char(sysdate,'yyyy')-c.namsinh<=14 then 1 else 0 end) as c09,";
				sql+="sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh>4 and to_char(sysdate,'yyyy')-c.namsinh<=14  and a.ttlucrv=7 then 1 else 0 end) as c10,";
				sql+="sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh>4 and to_char(sysdate,'yyyy')-c.namsinh<=14 then 1 else 0 end) as c11,";
				sql+="sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh>4 and to_char(sysdate,'yyyy')-c.namsinh<=14  and a.ttlucrv=7 then 1 else 0 end) as c12,";
				sql+="sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh>14 and to_char(sysdate,'yyyy')-c.namsinh<=60 then 1 else 0 end) as c13,";
				sql+="sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh>14 and to_char(sysdate,'yyyy')-c.namsinh<=60  and a.ttlucrv=7 then 1 else 0 end) as c14,";
				sql+="sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh>14 and to_char(sysdate,'yyyy')-c.namsinh<=60 then 1 else 0 end) as c15,";
				sql+="sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh>14 and to_char(sysdate,'yyyy')-c.namsinh<=60  and a.ttlucrv=7 then 1 else 0 end) as c16,";
				sql+="sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh>60 then 1 else 0 end) as c17, sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh>60 and a.ttlucrv=7 then 1 else 0 end) as c18,";
				sql+="sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh>60 then 1 else 0 end) as c19, sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh>60 and a.ttlucrv=7 then 1 else 0 end) as c20";
				sql+=" FROM ((XUATVIEN a INNER JOIN TAINANTT b ON a.MAQL = b.MAQL) INNER JOIN BTDBN c ON a.MABN = c.MABN) INNER JOIN DMNGUYENNHAN d ON b.NGUYENNHAN = d.MA";
				sql+=" where d.stt<>0 and to_date(a.ngay,'dd/mm/yy') between to_date('"+s_tu+"','dd/mm/yy') and to_date('"+s_den+"','dd/mm/yy')";
				sql+=" group by d.stt";
				upd_data(sql);
				//ngo doc
				sql="SELECT d.stt,sum(decode(c.phai,0,1,0)) as c01, sum(case when c.phai=0 and a.ttlucrv=7 then 1 else 0 end) as c02,";
				sql+="sum(decode(c.phai,1,1,0)) as c03, sum(case when c.phai=1 and a.ttlucrv=7 then 1 else 0 end) as c04,";
				sql+="sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh<=4 then 1 else 0 end) as c05, sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh<=4 and a.ttlucrv=7 then 1 else 0 end) as c06,";
				sql+="sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh<=4 then 1 else 0 end) as c07, sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh<=4 and a.ttlucrv=7 then 1 else 0 end) as c08,";
				sql+="sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh>4 and to_char(sysdate,'yyyy')-c.namsinh<=14 then 1 else 0 end) as c09,";
				sql+="sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh>4 and to_char(sysdate,'yyyy')-c.namsinh<=14  and a.ttlucrv=7 then 1 else 0 end) as c10,";
				sql+="sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh>4 and to_char(sysdate,'yyyy')-c.namsinh<=14 then 1 else 0 end) as c11,";
				sql+="sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh>4 and to_char(sysdate,'yyyy')-c.namsinh<=14  and a.ttlucrv=7 then 1 else 0 end) as c12,";
				sql+="sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh>14 and to_char(sysdate,'yyyy')-c.namsinh<=60 then 1 else 0 end) as c13,";
				sql+="sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh>14 and to_char(sysdate,'yyyy')-c.namsinh<=60  and a.ttlucrv=7 then 1 else 0 end) as c14,";
				sql+="sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh>14 and to_char(sysdate,'yyyy')-c.namsinh<=60 then 1 else 0 end) as c15,";
				sql+="sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh>14 and to_char(sysdate,'yyyy')-c.namsinh<=60  and a.ttlucrv=7 then 1 else 0 end) as c16,";
				sql+="sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh>60 then 1 else 0 end) as c17, sum(case when c.phai=0 and to_char(sysdate,'yyyy')-c.namsinh>60 and a.ttlucrv=7 then 1 else 0 end) as c18,";
				sql+="sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh>60 then 1 else 0 end) as c19, sum(case when c.phai=1 and to_char(sysdate,'yyyy')-c.namsinh>60 and a.ttlucrv=7 then 1 else 0 end) as c20";
				sql+=" FROM ((XUATVIEN a INNER JOIN TAINANTT b ON a.MAQL = b.MAQL) INNER JOIN BTDBN c ON a.MABN = c.MABN) INNER JOIN DMNGODOC d ON b.NGODOC = d.MA";
				sql+=" where d.stt<>0 and to_date(a.ngay,'dd/mm/yy') between to_date('"+s_tu+"','dd/mm/yy') and to_date('"+s_den+"','dd/mm/yy')";
				sql+=" group by d.stt";
				upd_data(sql);
				//
				tongcong("ma>=3 and ma<=9",1,3);
				tongcong("ma>=3 and ma<=9",2,3);
				tongcong("ma>=3 and ma<=9",36,3);
				tongcong("ma>=11 and ma<=16",10,3);
				tongcong("ma>=18 and ma<=20",17,3);
				tongcong("ma>=27 and ma<=30",26,3);
				tongcong("ma in (22,23,24,25,26,31,32,33)",21,3);				
			}
			
			if (thongke)
			{
				sql="select a.ma,sum(a.c01) as c01,sum(a.c02) as c02,sum(a.c03) as c03,sum(a.c04) as c04,";
				sql+="sum(a.c05) as c05,sum(a.c06) as c06,sum(a.c07) as c07,sum(a.c08) as c08,";
				sql+="sum(a.c09) as c09,sum(a.c10) as c10,sum(a.c11) as c11,sum(a.c12) as c12,";
				sql+="sum(a.c13) as c13,sum(a.c14) as c14,sum(a.c15) as c15,sum(a.c16) as c16,";
				sql+="sum(a.c17) as c17,sum(a.c18) as c18,sum(a.c19) as c19,sum(a.c20) as c20";
				sql+=" from kh_bieu_1451 a,kh_dm_1451 b where a.ma=b.ma ";
				sql+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+s_tu+"','dd/mm/yy') and to_date('"+s_den+"','dd/mm/yy')";
				sql+=" group by a.ma";
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					dr=ds.Tables[0].Select("ma="+int.Parse(r["ma"].ToString()));
					if (dr!=null)
					{
						dr[0]["c01"]=Decimal.Parse(dr[0]["c01"].ToString())+Decimal.Parse(r["c01"].ToString());
						dr[0]["c02"]=Decimal.Parse(dr[0]["c02"].ToString())+Decimal.Parse(r["c02"].ToString());
						dr[0]["c03"]=Decimal.Parse(dr[0]["c03"].ToString())+Decimal.Parse(r["c03"].ToString());
						dr[0]["c04"]=Decimal.Parse(dr[0]["c04"].ToString())+Decimal.Parse(r["c04"].ToString());
						dr[0]["c05"]=Decimal.Parse(dr[0]["c05"].ToString())+Decimal.Parse(r["c05"].ToString());
						dr[0]["c06"]=Decimal.Parse(dr[0]["c06"].ToString())+Decimal.Parse(r["c06"].ToString());
						dr[0]["c07"]=Decimal.Parse(dr[0]["c07"].ToString())+Decimal.Parse(r["c07"].ToString());
						dr[0]["c08"]=Decimal.Parse(dr[0]["c08"].ToString())+Decimal.Parse(r["c08"].ToString());
						dr[0]["c09"]=Decimal.Parse(dr[0]["c09"].ToString())+Decimal.Parse(r["c09"].ToString());
						dr[0]["c10"]=Decimal.Parse(dr[0]["c10"].ToString())+Decimal.Parse(r["c10"].ToString());
						dr[0]["c11"]=Decimal.Parse(dr[0]["c11"].ToString())+Decimal.Parse(r["c11"].ToString());
						dr[0]["c12"]=Decimal.Parse(dr[0]["c12"].ToString())+Decimal.Parse(r["c12"].ToString());
						dr[0]["c13"]=Decimal.Parse(dr[0]["c13"].ToString())+Decimal.Parse(r["c13"].ToString());
						dr[0]["c14"]=Decimal.Parse(dr[0]["c14"].ToString())+Decimal.Parse(r["c14"].ToString());
						dr[0]["c15"]=Decimal.Parse(dr[0]["c15"].ToString())+Decimal.Parse(r["c15"].ToString());
						dr[0]["c16"]=Decimal.Parse(dr[0]["c16"].ToString())+Decimal.Parse(r["c16"].ToString());
						dr[0]["c17"]=Decimal.Parse(dr[0]["c17"].ToString())+Decimal.Parse(r["c17"].ToString());
						dr[0]["c18"]=Decimal.Parse(dr[0]["c18"].ToString())+Decimal.Parse(r["c18"].ToString());
						dr[0]["c19"]=Decimal.Parse(dr[0]["c19"].ToString())+Decimal.Parse(r["c19"].ToString());
						dr[0]["c20"]=Decimal.Parse(dr[0]["c20"].ToString())+Decimal.Parse(r["c20"].ToString());
					}
				}
			}
			if (phatsinh) m.delrec(ds.Tables[0],"c01+c02+c03+c04+c05+c06+c07+c08+c09+c10+c11+c12+c13+c14+c15+c16+c17+c18+c19+c20=0");
			return ds;
		}

		private void upd_data(string sql)
		{
			DataRow[] dr;
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				dr=ds.Tables[0].Select("ma="+int.Parse(r["stt"].ToString()));
				if (dr!=null)
				{
					dr[0]["c01"]=r["c01"].ToString();
					dr[0]["c02"]=r["c02"].ToString();
					dr[0]["c03"]=r["c03"].ToString();
					dr[0]["c04"]=r["c04"].ToString();
					dr[0]["c05"]=r["c05"].ToString();
					dr[0]["c06"]=r["c06"].ToString();
					dr[0]["c07"]=r["c07"].ToString();
					dr[0]["c08"]=r["c08"].ToString();
					dr[0]["c09"]=r["c09"].ToString();
					dr[0]["c10"]=r["c10"].ToString();
					dr[0]["c11"]=r["c11"].ToString();
					dr[0]["c12"]=r["c12"].ToString();
					dr[0]["c13"]=r["c13"].ToString();
					dr[0]["c14"]=r["c14"].ToString();
					dr[0]["c15"]=r["c15"].ToString();
					dr[0]["c16"]=r["c16"].ToString();
					dr[0]["c17"]=r["c17"].ToString();
					dr[0]["c18"]=r["c18"].ToString();
					dr[0]["c19"]=r["c19"].ToString();
					dr[0]["c20"]=r["c20"].ToString();
				}
			}
		}

		public DataSet upd_ththbn(string tu,string den)
		{
			Int64 songay=m.songay(m.StringToDate(den),m.StringToDate(tu),1);
			dt=new DataTable();
			dt=m.get_data("select * from btdkp_bv").Tables[0];
			ds=new DataSet();
			DataRow r1,r2;
			ds=m.get_data("select * from ththbn");
			dc=new DataColumn();
			dc.ColumnName="C15";//ngaydt
			dc.DataType=Type.GetType("System.Decimal");
			ds.Tables[0].Columns.Add(dc);
			dc=new DataColumn();
			dc.ColumnName="C16";//ngaydt ravien
			dc.DataType=Type.GetType("System.Decimal");
			ds.Tables[0].Columns.Add(dc);
			dc=new DataColumn();
			dc.ColumnName="C17";//songay
			dc.DataType=Type.GetType("System.Decimal");
			ds.Tables[0].Columns.Add(dc);
			sql="SELECT c.MAKP,sum(case when (to_date(a.ngay,'dd/mm/yy')<to_date('"+tu+"','dd/mm/yy') and (b.ngay is null or to_date(b.ngay,'dd/mm/yy')>=to_date('"+tu+"','dd/mm/yy'))) then 1 else 0 end) C03,";
			sql+="sum(case when a.khoachuyen='01' and to_date(a.ngay,'dd/mm/yy') Between to_date('"+tu+"','dd/mm/yy') And to_date('"+den+"','dd/mm/yy') then 1 else 0 end) C04,";
			sql+="sum(case when a.khoachuyen<>'01' and to_date(a.ngay,'dd/mm/yy') Between to_date('"+tu+"','dd/mm/yy') And to_date('"+den+"','dd/mm/yy') then 1 else 0 end) C05,";
			sql+="Sum(case when b.ngay is null then 0 else case when b.ttlucrk=1 And to_date(b.ngay,'dd/mm/yy') Between to_date('"+tu+"','dd/mm/yy') And to_date('"+den+"','dd/mm/yy') then 1 else 0 end end) C06,";
			sql+="Sum(case when b.ngay is null then 0 else case when b.ttlucrk=2 And to_date(b.ngay,'dd/mm/yy') Between to_date('"+tu+"','dd/mm/yy') And to_date('"+den+"','dd/mm/yy') then 1 else 0 end end) C07,";
			sql+="Sum(case when b.ngay is null then 0 else case when b.ttlucrk=3 And to_date(b.ngay,'dd/mm/yy') Between to_date('"+tu+"','dd/mm/yy') And to_date('"+den+"','dd/mm/yy') then 1 else 0 end end) C08,";
			sql+="Sum(case when b.ngay is null then 0 else case when b.ttlucrk=4 And to_date(b.ngay,'dd/mm/yy') Between to_date('"+tu+"','dd/mm/yy') And to_date('"+den+"','dd/mm/yy') then 1 else 0 end end) C09,";
			sql+="Sum(case when b.ngay is null then 0 else case when b.ttlucrk=5 And to_date(b.ngay,'dd/mm/yy') Between to_date('"+tu+"','dd/mm/yy') And to_date('"+den+"','dd/mm/yy') then 1 else 0 end end) C10,";
			sql+="Sum(case when b.ngay is null then 0 else case when b.ttlucrk=6 And to_date(b.ngay,'dd/mm/yy') Between to_date('"+tu+"','dd/mm/yy') And to_date('"+den+"','dd/mm/yy') then 1 else 0 end end) C11,";
			sql+="Sum(case when b.ngay is null then 0 else case when b.ttlucrk=7 And to_date(b.ngay,'dd/mm/yy') Between to_date('"+tu+"','dd/mm/yy') And to_date('"+den+"','dd/mm/yy') then 1 else 0 end end) C12,";
			sql+="sum(case when b.ngay is null or to_date(b.ngay,'dd/mm/yy')>to_date('"+den+"','dd/mm/yy') then 1 else 0 end) C13";
			sql+=" FROM NHAPKHOA a,XUATKHOA b,BTDKP_BV c ";
			sql+=" WHERE a.MAKP=c.MAKP and a.ID=b.ID(+) and a.maba<20 GROUP BY c.makp ORDER BY c.makp";
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				r2=m.getrowbyid(dt,"makp='"+r["makp"].ToString()+"'");
				if (r2!=null)
				{
					r1 = ds.Tables[0].NewRow();
					r1["makp"] = r["makp"].ToString();
					r1["tenkp"] = r2["tenkp"].ToString();
					r1["c02"] = Decimal.Parse(r2["kehoach"].ToString());
					r1["c14"]= Decimal.Parse(r2["thucke"].ToString());
					r1["c03"] = Decimal.Parse(r["c03"].ToString());
					r1["c13"]= Decimal.Parse(r["c13"].ToString());
					r1["c17"]= songay.ToString();
					r1["c04"]=Decimal.Parse(r["c04"].ToString());
					r1["c05"]=Decimal.Parse(r["c05"].ToString());
					r1["c06"]=Decimal.Parse(r["c06"].ToString());
					r1["c07"]=Decimal.Parse(r["c07"].ToString());
					r1["c08"]=Decimal.Parse(r["c08"].ToString());
					r1["c09"]=Decimal.Parse(r["c09"].ToString());
					r1["c10"]=Decimal.Parse(r["c10"].ToString());
					r1["c11"]=Decimal.Parse(r["c11"].ToString());
					r1["c12"]=Decimal.Parse(r["c12"].ToString());
					r1["c13"]=Decimal.Parse(r["c03"].ToString())+Decimal.Parse(r["c04"].ToString())+Decimal.Parse(r["c05"].ToString())-(Decimal.Parse(r["c06"].ToString())+Decimal.Parse(r["c07"].ToString())+Decimal.Parse(r["c08"].ToString())+Decimal.Parse(r["c09"].ToString())+Decimal.Parse(r["c10"].ToString())+Decimal.Parse(r["c11"].ToString())+Decimal.Parse(r["c12"].ToString()));
					r1["c15"]=0;
					r1["c16"]=0;
					ds.Tables[0].Rows.Add(r1);
				}
			}
			//ngaydt
			sql="SELECT a.makp,";
			sql+="sum(case when b.ngay is null or to_date(b.ngay,'dd/mm/yy')>to_date('"+den+"','dd/mm/yy') ";
			sql+="then to_date('"+den+"','dd/mm/yy') else to_date(b.ngay,'dd/mm/yy') end-";
			sql+="case when to_date(a.ngay,'dd/mm/yy')>to_date('"+tu+"','dd/mm/yy')";
			sql+="then to_date(a.ngay,'dd/mm/yy') else to_date('"+tu+"','dd/mm/yy') end+decode(a.khoachuyen,'01',1,0)) c15,";
			sql+="sum(case when b.ngay is null then 0 else case when to_date(b.ngay,'dd/mm/yy')>to_date('"+den+"','dd/mm/yy') then 0 else to_date(b.ngay,'dd/mm/yy')-to_date(a.ngay,'dd/mm/yy') end end+decode(a.khoachuyen,'01',1,0)) c16 ";
			sql+="FROM NHAPKHOA a,XUATKHOA b where  a.ID = b.ID(+) and a.maba<20 ";
			sql+="and b.ngay is not null and to_date(b.ngay,'dd/mm/yy') between to_date('"+tu+"','dd/mm/yy') and to_date('"+den+"','dd/mm/yy') ";
			sql+="group by a.makp";
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				r1=m.getrowbyid(ds.Tables[0],"makp='"+r["makp"].ToString()+"'");
				if (r1!=null)
				{
					r1["c15"]=Decimal.Parse(r1["c15"].ToString())+Decimal.Parse(r["c15"].ToString());
					r1["c16"]=Decimal.Parse(r1["c16"].ToString())+Decimal.Parse(r["c16"].ToString());
				}
			}
			sql="SELECT a.makp,";
			sql+="sum(case when b.ngay is null or to_date(b.ngay,'dd/mm/yy')>to_date('"+den+"','dd/mm/yy') ";
			sql+="then to_date('"+den+"','dd/mm/yy') else to_date(b.ngay,'dd/mm/yy') end-";
			sql+="case when to_date(a.ngay,'dd/mm/yy')>to_date('"+tu+"','dd/mm/yy')";
			sql+="then to_date(a.ngay,'dd/mm/yy') else to_date('"+tu+"','dd/mm/yy') end+decode(a.khoachuyen,'01',1,0)) c15,";
			sql+="sum(case when b.ngay is null then 0 else case when to_date(b.ngay,'dd/mm/yy')>to_date('"+den+"','dd/mm/yy') then 0 else to_date(b.ngay,'dd/mm/yy')-to_date(a.ngay,'dd/mm/yy') end end +decode(a.khoachuyen,'01',1,0)) c16 ";
			sql+="FROM NHAPKHOA a,XUATKHOA b where  a.ID = b.ID(+) and a.maba<20 ";
			sql+="and b.ngay is null and to_date(a.ngay,'dd/mm/yy') between to_date('"+tu+"','dd/mm/yy') and to_date('"+den+"','dd/mm/yy') ";
			sql+="group by a.makp";
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				r1=m.getrowbyid(ds.Tables[0],"makp='"+r["makp"].ToString()+"'");
				if (r1!=null)
				{
					r1["c15"]=Decimal.Parse(r1["c15"].ToString())+Decimal.Parse(r["c15"].ToString());
					r1["c16"]=Decimal.Parse(r1["c16"].ToString())+Decimal.Parse(r["c16"].ToString());
				}
			}
			/*
			sql="SELECT a.makp,";
			sql+="sum(case when b.ngay is null or to_date(b.ngay,'dd/mm/yy')>to_date('"+den+"','dd/mm/yy') ";
			sql+="then to_date('"+den+"','dd/mm/yy') else to_date(b.ngay,'dd/mm/yy') end-";
			sql+="case when to_date(a.ngay,'dd/mm/yy')>to_date('"+tu+"','dd/mm/yy')";
			sql+="then to_date(a.ngay,'dd/mm/yy') else to_date('"+tu+"','dd/mm/yy') end+decode(a.khoachuyen,'01',1,0)) c15,";
			sql+="sum(case when b.ngay is null then 0 else case when to_date(b.ngay,'dd/mm/yy')>to_date('"+den+"','dd/mm/yy') then 0 else to_date(b.ngay,'dd/mm/yy')-to_date(a.ngay,'dd/mm/yy') end end +decode(a.khoachuyen,'01',1,0)) c16 ";
			sql+="FROM NHAPKHOA a,XUATKHOA b where a.ID = b.ID(+) and a.maba<20 ";
			sql+="and to_date(a.ngay,'dd/mm/yy') between to_date('"+tu+"','dd/mm/yy') and to_date('"+den+"','dd/mm/yy') ";
			sql+="group by a.makp";
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				r1=m.getrowbyid(ds.Tables[0],"makp='"+r["makp"].ToString()+"'");
				if (r1!=null)
				{
					r1["c15"]=Decimal.Parse(r1["c15"].ToString())+Decimal.Parse(r["c15"].ToString());
					r1["c16"]=Decimal.Parse(r1["c16"].ToString())+Decimal.Parse(r["c16"].ToString());
				}
			}
			*/
			return ds;
		}
	}
}
