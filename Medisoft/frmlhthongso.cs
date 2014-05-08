using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Lib_LH;
using LibMedi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmlhthongso.
	/// </summary>
	public class frmlhthongso : System.Windows.Forms.Form
	{
        Language lan = new Language();
		Lib_LH.Access_Data k = new Lib_LH.Access_Data();
		private AccessData m=new AccessData();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtp1;
		private System.Windows.Forms.DateTimePicker dtp2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmlhthongso()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmlhthongso));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dtp1 = new System.Windows.Forms.DateTimePicker();
			this.dtp2 = new System.Windows.Forms.DateTimePicker();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Từ Ngày";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(128, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Ðến Ngày";
			// 
			// dtp1
			// 
			this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtp1.Location = new System.Drawing.Point(16, 32);
			this.dtp1.Name = "dtp1";
			this.dtp1.Size = new System.Drawing.Size(88, 20);
			this.dtp1.TabIndex = 2;
			// 
			// dtp2
			// 
			this.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtp2.Location = new System.Drawing.Point(128, 32);
			this.dtp2.Name = "dtp2";
			this.dtp2.Size = new System.Drawing.Size(88, 20);
			this.dtp2.TabIndex = 3;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(16, 72);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(88, 32);
			this.button1.TabIndex = 4;
			this.button1.Text = "Ðồng ý";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(128, 72);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(88, 32);
			this.button2.TabIndex = 5;
			this.button2.Text = "Kết thúc";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// frmlhthongso
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(232, 125);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button2,
																		  this.button1,
																		  this.dtp2,
																		  this.dtp1,
																		  this.label2,
																		  this.label1});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmlhthongso";
			this.Text = "Chọn Thông Số";
			this.ResumeLayout(false);

		}
		#endregion

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			string sql ="select b.ngaykham, a.mabn,a.hoten,a.sonha||' '||a.thon||' '||c.tenpxa||' - '||d.tenquan||' - '||e.tentt diachi,f.tenkp,g.hoten as bacsi,b.stt,h.tenhk from lh_benhnhan a,lh_khambenh b,btdpxa c,btdquan d,btdtt e,btdkp_bv f,dmbs g,lh_loaihen h where b.ngaykham between to_date('"+dtp1.Text+"','dd/mm/yyyy') and to_date('"+dtp2.Text+"','dd/mm/yyyy')and a.maphuongxa=c.maphuongxa and a.maqu=d.maqu and	a.matt=e.matt and b.phongkham=f.makp and b.mabs=g.ma and b.lydohen = h.mahk and a.maql=b.maql";
			DataSet ds = k.get_data(sql);
			if(ds.Tables[0].Rows.Count<=0)
			{
				MessageBox.Show("Không có dữ liệu","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return ;
			}
			frmReport f=new frmReport(m,ds,"Từ ngày "+dtp1.Text+" đến "+dtp2.Text,"lh_dangkyhen.rpt");
			f.ShowDialog();
			button2.Focus();
		}
	}
}
