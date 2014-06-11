using System;
using System.Data;

namespace XN
{
	/// <summary>
	/// lưu thông tin của 1 rows phiếu xét nghiệm 
	/// </summary>
	public class nodePXN : System.Windows.Forms.TreeNode 
	{
		private DataRow rPXN; 
		public nodePXN( DataRow rPXNTemp ) 
		{
			rPXN = rPXNTemp;
			this.Text = rPXN["SOGPB"].ToString();
			this.Tag=rPXN["SOGPB"].ToString();
		}
		public DataRow get_node()
		{
			return rPXN;
		}
	}
}
