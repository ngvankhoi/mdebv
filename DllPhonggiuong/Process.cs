using System;
using System.Data;
using Npgsql;
using NpgsqlTypes;
namespace DllPhonggiuong
{
	public class Process
	{
		private LibMedi.AccessData m=new LibMedi.AccessData();
        NpgsqlConnection con;
		NpgsqlCommand cmd;
		string sConn="",sComputer="",sql="", s_user="";
		public Process()
		{
			sConn=m.ConStr;
			sComputer=System.Environment.MachineName.Trim().ToUpper();
		}
		public decimal songaygiuong(DateTime d1,DateTime d2,int congthem,int idgiuong)
		{
            s_user = m.user;
			double ret=0;
			try
			{	
				double so=d1.ToOADate()-d2.ToOADate();
				if (congthem!=0)
				{
                    sql = "select a.* from " + s_user + ".dmgiuong a, " + s_user + ".dmphong b where a.idphong=b.id and b.dichvu=1 and a.id=" + idgiuong;
					if (m.get_data(sql).Tables[0].Rows.Count>0)
					{
						string s=so.ToString();
						int p=s.IndexOf(".");
						if (p!=-1)
						{
							ret=double.Parse(s.Substring(0,p));
							string c="0."+s.Substring(p+1);
							ret+=((double.Parse(c)<0.5)?0.5:1.0);
						}
						else ret=0.5;
					}
					else ret=Math.Floor(so);//+congthem
				}
				else ret=Math.Floor(so)+congthem;
			}
			catch{ret=0;}
            return decimal.Parse(ret.ToString());
		}

		public bool upd_datgiuong(string m_mabn,string m_ngay,long m_idgiuong,string m_ghichu,int m_userid)
		{
            s_user = m.user;
            sql = "update " + s_user + ".datgiuong set ngay=to_date(:m_ngay,'dd/mm/yyyy hh24:mi'),ghichu=:m_ghichu,userid=:m_userid where mabn=:m_mabn and idgiuong=:m_idgiuong and den is null";
			con=new NpgsqlConnection (sConn);
			try
			{
				con.Open();
				cmd=new NpgsqlCommand(sql,con);
				cmd.CommandType=CommandType.Text;
				cmd.Parameters.Add("m_idgiuong",NpgsqlDbType.Numeric).Value=m_idgiuong;
                cmd.Parameters.Add("m_ghichu", NpgsqlDbType.Text).Value = m_ghichu;
                cmd.Parameters.Add("m_userid", NpgsqlDbType.Numeric).Value = m_userid;
                cmd.Parameters.Add("m_mabn", NpgsqlDbType.Varchar, 8).Value = m_mabn;
				cmd.Parameters.Add("m_ngay",NpgsqlDbType.Varchar,16).Value=m_ngay;
				int irec=cmd.ExecuteNonQuery();
				cmd.Dispose();
				if (irec==0)
				{
                    sql = "insert into " + s_user + ".datgiuong (mabn,ngay,idgiuong,ghichu,userid) values (:m_mabn,to_date(:m_ngay,'dd/mm/yyyy hh24:mi'),:m_idgiuong,:m_ghichu,:m_userid)";
					cmd=new NpgsqlCommand (sql,con);
					cmd.CommandType=CommandType.Text;
					cmd.Parameters.Add("m_mabn",NpgsqlDbType.Varchar,8).Value=m_mabn;
					cmd.Parameters.Add("m_ngay",NpgsqlDbType.Varchar,16).Value=m_ngay;
                    cmd.Parameters.Add("m_idgiuong", NpgsqlDbType.Numeric).Value = m_idgiuong;
					cmd.Parameters.Add("m_ghichu",NpgsqlDbType.Text).Value=m_ghichu;
                    cmd.Parameters.Add("m_userid", NpgsqlDbType.Numeric).Value = m_userid;
					irec=cmd.ExecuteNonQuery();
					cmd.Dispose();
				}
			}
			catch(NpgsqlException ex)
			{
				upd_error(ex.Message,sComputer,"datgiuong");
				return false;
			}
			finally
			{
				cmd.Dispose();
				con.Close();
			}		
			return true;
		}

		public bool upd_dmgiuong(int m_id,string m_ghichu,int m_tinhtrang)
		{
            s_user = m.user;
            sql = "update " + s_user + ".dmgiuong set ghichu=:m_ghichu,tinhtrang=:m_tinhtrang where id=:m_id";
			con=new NpgsqlConnection (sConn);
			try
			{
				con.Open();
				cmd=new NpgsqlCommand (sql,con);
				cmd.CommandType=CommandType.Text;
				cmd.Parameters.Add("m_id",NpgsqlDbType.Numeric ).Value=m_id;
				cmd.Parameters.Add("m_ghichu",NpgsqlDbType.Text).Value=m_ghichu;
                cmd.Parameters.Add("m_tinhtrang", NpgsqlDbType.Numeric ).Value = m_tinhtrang;
				int irec=cmd.ExecuteNonQuery();
				cmd.Dispose();
				con.Close();
			}
			catch(NpgsqlException ex)
			{
				upd_error(ex.Message,sComputer,"dmgiuong");
				return false;
			}
			finally
			{
				cmd.Dispose();
				con.Close();
			}		
			return true;
		}

		public void upd_error(string m_message,string m_computer,string m_table)
		{
			cmd.Dispose();
			con.Close();
            s_user = m.user;
            sql = "insert into " + s_user + ".error(message,computer,tables,ngayud) values (:m_message,:m_computer,:m_table,sysdate)";
			con=new NpgsqlConnection(sConn);
			try
			{
				con.Open();
				cmd=new NpgsqlCommand (sql,con);
				cmd.CommandType=CommandType.Text;

				cmd.Parameters.Add("m_message",NpgsqlDbType.Varchar,254).Value=m_message;
				cmd.Parameters.Add("m_computer",NpgsqlDbType.Varchar,20).Value=m_computer;
				cmd.Parameters.Add("m_table",NpgsqlDbType.Varchar,20).Value=m_table;
				cmd.ExecuteNonQuery();
			}
			catch{}
			finally
			{
				cmd.Dispose();
				con.Close();
			}
		}

        public void f_tao_db_phonggiuong()
        {
            s_user = m.user;
            string asql = "";
            asql = "select mabn from " + s_user + ".datgiuong where 1=2";
            DataSet lds = m.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = "create table " + s_user + ".datgiuong(MABN varchar(8), NGAY Timestamp, IDGIUONG numeric(12), DEN Timestamp, GHICHU text, USERID numeric(7), NGAYUD Timestamp default now(), constraint pk_datgiuong primary key (mabn, ngay, idgiuong) WITH OIDS";
                m.execute_data(asql);
            }
            
            
            asql = "select idtheodoigiuong from " + s_user + ".datgiuong where id=0";
            lds = m.get_data(sql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = "alter table " + s_user + ".datgiuong add idtheodoigiuong numeric(22) default 0";
                m.execute_data(asql);

            }

            asql = "";
        }
	}
}
