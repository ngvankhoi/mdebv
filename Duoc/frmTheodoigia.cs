using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using System.Reflection;
using System.Runtime.InteropServices;
using Excel;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmTheodoigia.
	/// </summary>
	public class frmTheodoigia : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		Excel.Application oxl;
		Excel._Workbook owb;
		Excel._Worksheet osheet;
		private DataSet ds=new DataSet();
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private string sql,user;
		private int i_nhom;	
		private AccessData d;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTheodoigia(AccessData acc,int nhom)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;i_nhom=nhom;
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            //
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTheodoigia));
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butIn
            // 
            this.butIn.Image = global::Duoc.Properties.Resources.Print1;
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(33, 32);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(72, 25);
            this.butIn.TabIndex = 0;
            this.butIn.Text = "      &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(105, 32);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(72, 25);
            this.butKetthuc.TabIndex = 2;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // frmTheodoigia
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(208, 93);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTheodoigia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Theo dõi giá thuốc";
            this.Load += new System.EventHandler(this.frmTheodoigia_Load);
            this.ResumeLayout(false);

		}
		#endregion


		private string get_ten(int i)
		{
			string [] map={"Mã","Tên thuốc - hàm lượng","ĐVT","Giá mua","Giá bán","Tỷ lệ %","Hãng sản xuất","Nước sản xuất","Nhà cung cấp","Nhóm"};
			return map[i];
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			d.check_process_Excel();
			sql="select a.ma,trim(a.ten)||' '||trim(a.hamluong) as ten,a.dang,trunc(a.dongia,2) as dongia,trunc(a.giaban,0) as giaban,";
			sql+="case when a.dongia<>0 and a.giaban<>0 then round((a.giaban/(a.dongia)-1)*100,2) else 0 end as tyle,";
			sql+="b.ten as tenhang,c.ten as tennuoc,d.ten as tennx,e.ten as tennhom ";
            sql += "from " + user + ".d_dmbd a inner join " + user + ".d_dmhang b on a.mahang=b.id ";
            sql += " inner join " + user + ".d_dmnuoc c on a.manuoc=c.id ";
            sql += " left join " + user + ".d_dmnx d on a.madv=d.id ";
            sql += " inner join " + user + ".d_dmnhom e on a.manhom=e.id ";
			sql+="where a.dongia<>0 and a.giaban<>0 and a.giaban>=a.dongia and a.nhom="+i_nhom;
			sql+=" order by a.ma";
			ds=d.get_data(sql);
			DataSet tmp=new DataSet();
			tmp=ds.Copy();
			tmp.Clear();
			tmp.Merge(ds.Tables[0].Select("true","ma"));
			string tenfile=d.Export_Excel(tmp,"dmthuoc");
			oxl=new Excel.Application();
			owb=(Excel._Workbook)(oxl.Workbooks.Open(tenfile,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value));
			osheet=(Excel._Worksheet)owb.ActiveSheet;
			for(int i=0;i<10;i++) osheet.Cells[1,i+1]=get_ten(i);
			oxl.ActiveWindow.DisplayGridlines=true;
			oxl.ActiveWindow.DisplayZeros=false;
			int row=tmp.Tables[0].Rows.Count+1;
			osheet.get_Range(d.getIndex(0)+"1",d.getIndex(tmp.Tables[0].Columns.Count-1)+row.ToString()).Borders.LineStyle=XlBorderWeight.xlHairline;
			osheet.PageSetup.CenterFooter="Trang : &P/&N";
			osheet.PageSetup.LeftHeader = d.Syte+"\n"+d.Tenbv;
			osheet.PageSetup.RightFooter="Ngày in :"+d.Ngay_hethong_gio.ToString();
			osheet.PageSetup.CenterHeader = "&\"Arial,Bold\"&14THEO DÕI GIÁ THUỐC NHÀ THUỐC BỆNH VIỆN";
			oxl.Visible=true;		
		}

        private void frmTheodoigia_Load(object sender, EventArgs e)
        {
            user = d.user;            
        }
	}
}
