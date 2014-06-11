using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using gpblib;
using Medisoft.Utilities;

namespace XN
{
	/// <summary>
	/// Summary description for frmTkgpb.
	/// </summary>
	public class frmTktinhhinh : System.Windows.Forms.Form
	{
		private MaskedBox.MaskedBox den;
		private MaskedBox.MaskedBox tu;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.DataGrid pxn;
		private BaseFormat bf=new BaseFormat();
		private DataSet ds=new DataSet();
		private AccessData b=new AccessData();
		private DateUtil du=new DateUtil();
        private string user;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.DataGrid nhuom;
		private System.Windows.Forms.DataGrid gpb;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label sopxn;
		private System.Windows.Forms.Label sonhuom;
		private System.Windows.Forms.Label sobenh;
		private System.Windows.Forms.Button btntk;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTktinhhinh(string tngay,string dngay)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.tu.Text=tngay;
			this.den.Text=dngay;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmTktinhhinh));
			this.den = new MaskedBox.MaskedBox();
			this.tu = new MaskedBox.MaskedBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.pxn = new System.Windows.Forms.DataGrid();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.nhuom = new System.Windows.Forms.DataGrid();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.gpb = new System.Windows.Forms.DataGrid();
			this.butKetthuc = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.sopxn = new System.Windows.Forms.Label();
			this.sonhuom = new System.Windows.Forms.Label();
			this.sobenh = new System.Windows.Forms.Label();
			this.btntk = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pxn)).BeginInit();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nhuom)).BeginInit();
			this.tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gpb)).BeginInit();
			this.SuspendLayout();
			// 
			// den
			// 
			this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.den.Location = new System.Drawing.Point(181, 14);
			this.den.Mask = "##/##/####";
			this.den.Name = "den";
			this.den.Size = new System.Drawing.Size(64, 21);
			this.den.TabIndex = 4;
			this.den.Text = "";
			this.den.Validated += new System.EventHandler(this.den_Validated);
			// 
			// tu
			// 
			this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tu.Location = new System.Drawing.Point(56, 14);
			this.tu.Mask = "##/##/####";
			this.tu.Name = "tu";
			this.tu.Size = new System.Drawing.Size(64, 21);
			this.tu.TabIndex = 3;
			this.tu.Text = "";
			this.tu.Validated += new System.EventHandler(this.tu_Validated);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(109, 14);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "đến ngày :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Từ ngày :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.tabPage1,
																					  this.tabPage2,
																					  this.tabPage3});
			this.tabControl1.Location = new System.Drawing.Point(248, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(536, 504);
			this.tabControl1.TabIndex = 10;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.pxn});
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(528, 478);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Phiếu xét nghiệm";
			// 
			// pxn
			// 
			this.pxn.CaptionVisible = false;
			this.pxn.DataMember = "";
			this.pxn.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.pxn.Name = "pxn";
			this.pxn.Size = new System.Drawing.Size(528, 480);
			this.pxn.TabIndex = 0;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.nhuom});
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(528, 478);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Xét nghiệm";
			// 
			// nhuom
			// 
			this.nhuom.CaptionVisible = false;
			this.nhuom.DataMember = "";
			this.nhuom.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.nhuom.Name = "nhuom";
			this.nhuom.Size = new System.Drawing.Size(528, 488);
			this.nhuom.TabIndex = 1;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.gpb});
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(528, 478);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Bệnh";
			// 
			// gpb
			// 
			this.gpb.CaptionVisible = false;
			this.gpb.DataMember = "";
			this.gpb.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gpb.Name = "gpb";
			this.gpb.Size = new System.Drawing.Size(528, 480);
			this.gpb.TabIndex = 1;
			// 
			// butKetthuc
			// 
			this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butKetthuc.ForeColor = System.Drawing.SystemColors.WindowText;
			this.butKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("butKetthuc.Image")));
			this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butKetthuc.Location = new System.Drawing.Point(126, 46);
			this.butKetthuc.Name = "butKetthuc";
			this.butKetthuc.Size = new System.Drawing.Size(68, 25);
			this.butKetthuc.TabIndex = 24;
			this.butKetthuc.Text = "&Kết thúc";
			this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(24, 432);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(96, 16);
			this.label5.TabIndex = 27;
			this.label5.Text = "Số phiếu xn";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(24, 456);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 16);
			this.label3.TabIndex = 28;
			this.label3.Text = "Số nhuộm db";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(24, 480);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 16);
			this.label4.TabIndex = 29;
			this.label4.Text = "Số lượng bệnh";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// sopxn
			// 
			this.sopxn.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.sopxn.ForeColor = System.Drawing.Color.Red;
			this.sopxn.Location = new System.Drawing.Point(128, 432);
			this.sopxn.Name = "sopxn";
			this.sopxn.Size = new System.Drawing.Size(96, 16);
			this.sopxn.TabIndex = 31;
			this.sopxn.Text = "Số phiếu xn";
			this.sopxn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// sonhuom
			// 
			this.sonhuom.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.sonhuom.ForeColor = System.Drawing.Color.Red;
			this.sonhuom.Location = new System.Drawing.Point(128, 456);
			this.sonhuom.Name = "sonhuom";
			this.sonhuom.Size = new System.Drawing.Size(96, 16);
			this.sonhuom.TabIndex = 32;
			this.sonhuom.Text = "Số phiếu xn";
			this.sonhuom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// sobenh
			// 
			this.sobenh.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.sobenh.ForeColor = System.Drawing.Color.Red;
			this.sobenh.Location = new System.Drawing.Point(128, 480);
			this.sobenh.Name = "sobenh";
			this.sobenh.Size = new System.Drawing.Size(96, 16);
			this.sobenh.TabIndex = 33;
			this.sobenh.Text = "Số phiếu xn";
			this.sobenh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btntk
			// 
			this.btntk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btntk.ForeColor = System.Drawing.SystemColors.WindowText;
			this.btntk.Image = ((System.Drawing.Bitmap)(resources.GetObject("btntk.Image")));
			this.btntk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btntk.Location = new System.Drawing.Point(56, 46);
			this.btntk.Name = "btntk";
			this.btntk.Size = new System.Drawing.Size(68, 25);
			this.btntk.TabIndex = 34;
			this.btntk.Text = "Đồng ý";
			this.btntk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btntk.Click += new System.EventHandler(this.btntk_Click);
			// 
			// frmTktinhhinh
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 573);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btntk,
																		  this.sobenh,
																		  this.sonhuom,
																		  this.sopxn,
																		  this.label4,
																		  this.label3,
																		  this.label5,
																		  this.butKetthuc,
																		  this.tabControl1,
																		  this.den,
																		  this.tu,
																		  this.label2,
																		  this.label1});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmTktinhhinh";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Báo cáo tình hình";
			this.Load += new System.EventHandler(this.frmTktinhhinh_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pxn)).EndInit();
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nhuom)).EndInit();
			this.tabPage3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gpb)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmTktinhhinh_Load(object sender, System.EventArgs e)
		{
            user = b.user;
			init();
		}
		private void init()
		{
			get_tongso();
			get_pxn(true);
			get_nhuom(true);
			get_gpb(true);
		}
		private void get_tongso()
		{

            string sql = "select count(*) as soluong from " + user + ".GPB_PXN a ";
			sql+=" where a.ngaynhan between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy') ";
			ds=b.get_data(sql);
			sopxn.Text=ds.Tables[0].Rows[0][0].ToString();
			//tong so nhuom db
            sql = "select count(*) as soluong from " + user + ".GPB_PXN a," + user + ".GPB_XNHMMD b where a.sogpb=b.sogpb ";
			sql+=" and a.ngaynhan between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy') ";
			ds=b.get_data(sql) ;
			sonhuom.Text=ds.Tables[0].Rows[0][0].ToString();
			//tong so gpb
            sql = "select count(*) as soluong from " + user + ".GPB_PXN a," + user + ".GPB_VTSTXN b where a.sogpb=b.sogpb ";
			sql+=" and  a.ngaynhan between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy') ";
			ds=b.get_data(sql);
			sobenh.Text=ds.Tables[0].Rows[0][0].ToString();
		}
		private void get_pxn(bool addstyle)
		{
			try
			{
                string sql = "select a.sogpb,to_char(ngaynhan,'dd/mm/yyyy') as ngaynhan,b.hoten,c.hotenbn from " + user + ".GPB_PXN a," + user + ".DMBS b," + user + ".GPB_BTDBN c where a.bacsidoc=b.ma ";
				sql+=" and a.ngaynhan between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
				sql+=" and a.sohs=c.mabn ";
				ds=b.get_data(sql);
				if(addstyle)
				{
					bf.f_LoadDG(pxn,ds,new String[]{"Số gpb","Ngày nhận","Bác sĩ đọc     .","Tên bn"});
					bf.f_ResizeDG(pxn,4);
				}
				pxn.DataSource=ds.Tables[0];
			}
			catch{}
		}
		private void get_nhuom(bool addstyle)
		{
			try
			{
                string sql = "select b.mahmmd,c.tenhmmd,count(1) as soluong from " + user + ".GPB_PXN a," + user + ".GPB_XNHMMD b," + user + ".GPB_HMMD c where a.sogpb=b.sogpb and b.mahmmd=c.mahmmd ";
				sql+=" and a.ngaynhan between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
				sql+=" group by b.mahmmd,c.tenhmmd ";
				ds=b.get_data(sql);
				if(addstyle)
				{
					bf.f_LoadDG(nhuom,ds,new String[]{"Mã","Tên hmmd","Số lượng"});
					bf.f_ResizeDG(nhuom,1);
				}
				nhuom.DataSource=ds.Tables[0];
			}catch{}
		}
		private void get_gpb(bool addstyle)
		{
			try
			{
                string sql = "select b.magpb,c.tengpb,count(1) as soluong from " + user + ".GPB_PXN a," + user + ".GPB_VTSTXN b," + user + ".GPB_GPB c where a.sogpb=b.sogpb and b.magpb=c.magpb ";
				sql+=" and a.ngaynhan between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
				sql+=" group by b.magpb,c.tengpb ";
				ds=b.get_data(sql);
				if(addstyle)
				{
					bf.f_LoadDG(gpb,ds,new String[]{"Mã gpb","Tên gpb","Số lượng"});
					bf.f_ResizeDG(gpb,1);
				}
				gpb.DataSource=ds.Tables[0];
			}
			catch{}			
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void tu_Validated(object sender, System.EventArgs e)
		{
			if(!du.isValidDate(tu.Text))
			{
				MessageBox.Show("Ngày không hợp lệ !",b.Msg);
				tu.Focus();
			}		
		}

		private void den_Validated(object sender, System.EventArgs e)
		{
			if(!du.isValidDate(den.Text))
			{
				MessageBox.Show("Ngày không hợp lệ !",b.Msg);
				den.Focus();
			}		
		}

		private void btntk_Click(object sender, System.EventArgs e)
		{
			this.Cursor=Cursors.WaitCursor;
			get_tongso();
			get_pxn(false);
			get_nhuom(false);
			get_gpb(false);		
			this.Cursor=Cursors.Default;
		}
	}
}
