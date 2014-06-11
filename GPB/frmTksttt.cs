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
	public class frmTksttt : System.Windows.Forms.Form
	{
		private MaskedBox.MaskedBox den;
		private MaskedBox.MaskedBox tu;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private BaseFormat bf=new BaseFormat();
		private DataSet ds=new DataSet();
		private AccessData b=new AccessData();
		private DateUtil du=new DateUtil();
        private string user;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button btntk;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTksttt(string tngay,string dngay)
		{
		
			InitializeComponent();
			
			this.tu.Text=tngay;
			this.den.Text=dngay;
		}
		
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmTksttt));
			this.den = new MaskedBox.MaskedBox();
			this.tu = new MaskedBox.MaskedBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.butKetthuc = new System.Windows.Forms.Button();
			this.btntk = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// den
			// 
			this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.den.Location = new System.Drawing.Point(192, 16);
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
			this.tu.Location = new System.Drawing.Point(64, 16);
			this.tu.Mask = "##/##/####";
			this.tu.Name = "tu";
			this.tu.Size = new System.Drawing.Size(64, 21);
			this.tu.TabIndex = 3;
			this.tu.Text = "";
			this.tu.Validated += new System.EventHandler(this.tu_Validated);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(120, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "đến ngày :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Từ ngày :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// butKetthuc
			// 
			this.butKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("butKetthuc.Image")));
			this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butKetthuc.Location = new System.Drawing.Point(138, 56);
			this.butKetthuc.Name = "butKetthuc";
			this.butKetthuc.Size = new System.Drawing.Size(68, 25);
			this.butKetthuc.TabIndex = 24;
			this.butKetthuc.Text = "&Kết thúc";
			this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
			// 
			// btntk
			// 
			this.btntk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btntk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btntk.Image = ((System.Drawing.Bitmap)(resources.GetObject("btntk.Image")));
			this.btntk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btntk.Location = new System.Drawing.Point(67, 56);
			this.btntk.Name = "btntk";
			this.btntk.Size = new System.Drawing.Size(68, 25);
			this.btntk.TabIndex = 34;
			this.btntk.Text = "      &In";
			this.btntk.Click += new System.EventHandler(this.btntk_Click);
			// 
			// frmTksttt
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(272, 109);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btntk,
																		  this.butKetthuc,
																		  this.den,
																		  this.tu,
																		  this.label2,
																		  this.label1});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmTksttt";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Báo cáo tình hình";
			this.Load += new System.EventHandler(this.frmTksttt_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmTksttt_Load(object sender, System.EventArgs e)
		{
            user = b.user;
		}

		private void get_bs()
		{
			try
			{
                string sql = "select a.sogpb,to_char(a.ngaynhan,'dd/mm/yyyy') as ngaynhan,hotenbn,tuoibn,b.magpb,b.masttt,case when b.magpb=b.masttt then 1 else 0 end as dung from " + user + ".GPB_PXN a," + user + ".GPB_VTSTXN b where a.sogpb=b.sogpb ";
                sql += " and a.ngaynhan between to_date('" + tu.Text + "','dd/mm/yyyy') and to_date('" + den.Text + "','dd/mm/yyyy')";
				ds=b.get_data(sql);
				int sldung=ds.Tables[0].Select("dung=1").Length;
				int slsai=ds.Tables[0].Rows.Count-sldung;
				frmPrintAll f=new frmPrintAll();
				//f.Sttt(false,ds,b.Syte,b.Tenbv,b.Diachi ,sldung,slsai);
				f.ShowDialog();
//				ds.WriteXml("sttt.xml",XmlWriteMode.WriteSchema);
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
			get_bs();		
			this.Cursor=Cursors.Default;
		}
	}
}
