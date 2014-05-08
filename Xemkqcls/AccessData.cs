using System;
using System.Data;
using System.Data.OleDb;
using System.Xml;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace frmCanlamsan
{
	/// <summary>
	/// Summary description for AccessData.
	/// </summary>
	public class AccessData
	{
		private string strCon="";
		private MySqlConnection con;
		private MySqlCommand cmd;
		private MySqlDataAdapter adap;
		private string root=Environment.CurrentDirectory.ToString();
		//public int 
		//string  System.Environment 
		public AccessData()
		{
			try
			{
				XmlDocument doc=new XmlDocument();
				doc.Load(@"..\\..\\..\\xml\\maincode_mysql.xml");
				XmlNodeList nodelst=doc.GetElementsByTagName("Con");
				strCon=nodelst.Item(0).InnerText;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		public DataSet set_query(string sql)
		{
			DataSet ds=new DataSet();
			try
			{
				con=new MySqlConnection(strCon );
                con.Open();
                cmd=new MySqlCommand(sql,con);
				adap=new MySqlDataAdapter(cmd);
				adap.Fill(ds);
				cmd.ExecuteNonQuery();
			}
			catch
			{
				MessageBox.Show("Không truy xuất được thông tin !");
			}
			cmd.Dispose();
            con.Dispose();
			adap.Dispose();
			return ds;
		}
	}
	public class KhaiBaoTS
	{
		public KhaiBaoTS()
		{
		
		}

		public static string hostname=null;
		public static string ipaddress=null;
		public static string directory=null;
		public static string port=null;

	}
}
