using System;
using System.Data;
using Npgsql;
using NpgsqlTypes;
using System.Xml;
using System.Windows.Forms;
using LibMedi;


namespace frmCanlamsan
{
	/// <summary>
	/// Summary description for MyClass.
	/// </summary>
	public class MyClass
	{
		LibMedi.AccessData m = new LibMedi.AccessData();
		string MyConnn="";
		private NpgsqlConnection con;
		private NpgsqlCommand cmd;
		private NpgsqlDataAdapter adap;
		//DataSet ds = new DataSet();
		public MyClass()
		{
			//
			// TODO: Add constructor logic here
			//
			MyConnn=m.ConStr;

		}
        //public DataSet Load_tt_xn(string strMabn)
        //{
        //    con = new OracleConnection(MyConnn);
        //    con.Open();
        //    cmd = new OracleCommand("pkg_xem_cls.Load_tt_xn",con);
        //    cmd.CommandType=CommandType.StoredProcedure;
        //    cmd.Parameters.Add("io_cursor",OracleType.Cursor).Direction=ParameterDirection.Output;
        //    cmd.Parameters.Add("strMabn",OracleType.VarChar,8).Value=strMabn;
        //    adap=new OracleDataAdapter(cmd);			
        //    DataSet ds=new DataSet();
        //    try
        //    {
        //        adap.Fill(ds,"Tablbe0");
        //    }
        //    catch(OracleException exx)
        //    {
        //        string strerr=exx.ToString();
        //        MessageBox.Show(strerr);
        //    }
        //    cmd.Dispose();
        //    con.Dispose();
        //    return ds;	
        //}
        //public DataSet Load_kq_xn(string strMabn,string strNgay)
        //{
			
        //    con = new OracleConnection(MyConnn);
        //    con.Open();
			
        //    cmd = new OracleCommand("pkg_xem_cls.Load_kq_xn",con);
        //    cmd.CommandType=CommandType.StoredProcedure;
        //    cmd.Parameters.Add("io_cursor",OracleType.Cursor).Direction=ParameterDirection.Output;
        //    cmd.Parameters.Add("strMabn",OracleType.VarChar,8).Value=strMabn;
        //    cmd.Parameters.Add("strNgay",OracleType.VarChar,16).Value=strNgay;
        //    adap=new OracleDataAdapter(cmd);			
			
        //    DataSet ds=new DataSet();
        //    try
        //    {
        //        adap.Fill(ds,"Tablbe0");
        //    }
        //    catch(OracleException exx)
        //    {
        //        string strerr=exx.ToString();
        //        MessageBox.Show(strerr);
        //    }
        //    cmd.Dispose();
        //    con.Dispose();
        //    return ds;	
        //}
	}
}
