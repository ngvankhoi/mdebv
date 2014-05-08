using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmDenghi.
	/// </summary>
	public class frmDenghi : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker ngay;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox kinhgui;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox bophan;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox denghi;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox noidung;
		private System.Windows.Forms.TextBox ketoan;
		private System.Windows.Forms.TextBox giamdoc;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.Button butCancel;
		private DataSet ds=new DataSet();
		public bool ok=false;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDenghi()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDenghi));
            this.label1 = new System.Windows.Forms.Label();
            this.ngay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.kinhgui = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bophan = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.denghi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.noidung = new System.Windows.Forms.TextBox();
            this.ketoan = new System.Windows.Forms.TextBox();
            this.giamdoc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(99, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngay
            // 
            this.ngay.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.CustomFormat = "dd/MM/yyyy";
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngay.Location = new System.Drawing.Point(140, 9);
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(80, 21);
            this.ngay.TabIndex = 1;
            this.ngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(80, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kính gửi :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kinhgui
            // 
            this.kinhgui.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.kinhgui.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kinhgui.Location = new System.Drawing.Point(140, 32);
            this.kinhgui.Name = "kinhgui";
            this.kinhgui.Size = new System.Drawing.Size(294, 21);
            this.kinhgui.TabIndex = 3;
            this.kinhgui.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(80, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bộ phận :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bophan
            // 
            this.bophan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bophan.Location = new System.Drawing.Point(140, 80);
            this.bophan.Name = "bophan";
            this.bophan.Size = new System.Drawing.Size(294, 21);
            this.bophan.TabIndex = 5;
            this.bophan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(80, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nội dung :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // denghi
            // 
            this.denghi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.denghi.Location = new System.Drawing.Point(140, 56);
            this.denghi.Name = "denghi";
            this.denghi.Size = new System.Drawing.Size(294, 21);
            this.denghi.TabIndex = 4;
            this.denghi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-37, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Người đề nghị thanh toán :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // noidung
            // 
            this.noidung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noidung.Location = new System.Drawing.Point(140, 104);
            this.noidung.Name = "noidung";
            this.noidung.Size = new System.Drawing.Size(294, 21);
            this.noidung.TabIndex = 6;
            this.noidung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // ketoan
            // 
            this.ketoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ketoan.Location = new System.Drawing.Point(140, 128);
            this.ketoan.Name = "ketoan";
            this.ketoan.Size = new System.Drawing.Size(294, 21);
            this.ketoan.TabIndex = 7;
            this.ketoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // giamdoc
            // 
            this.giamdoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giamdoc.Location = new System.Drawing.Point(140, 152);
            this.giamdoc.Name = "giamdoc";
            this.giamdoc.Size = new System.Drawing.Size(294, 21);
            this.giamdoc.TabIndex = 8;
            this.giamdoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(35, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 23);
            this.label6.TabIndex = 12;
            this.label6.Text = "Phụ trách kế toán :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(35, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 23);
            this.label7.TabIndex = 13;
            this.label7.Text = "Người duyệt :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butOk
            // 
            this.butOk.Image = global::Duoc.Properties.Resources.ok;
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(155, 183);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 25);
            this.butOk.TabIndex = 9;
            this.butOk.Text = "Đồng ý";
            this.butOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancel
            // 
            this.butCancel.Image = global::Duoc.Properties.Resources.close_r;
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(224, 183);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(70, 25);
            this.butCancel.TabIndex = 10;
            this.butCancel.Text = "&Kết thúc";
            this.butCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // frmDenghi
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(446, 227);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.giamdoc);
            this.Controls.Add(this.ketoan);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.noidung);
            this.Controls.Add(this.denghi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bophan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.kinhgui);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDenghi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đề nghị thanh toán";
            this.Load += new System.EventHandler(this.frmDenghi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmDenghi_Load(object sender, System.EventArgs e)
		{
			ds.ReadXml("..\\..\\..\\xml\\d_denghi.xml");
			kinhgui.Text=ds.Tables[0].Rows[0]["KINHGUI"].ToString();
			denghi.Text=ds.Tables[0].Rows[0]["DENGHI"].ToString();
			bophan.Text=ds.Tables[0].Rows[0]["BOPHAN"].ToString();
			noidung.Text=ds.Tables[0].Rows[0]["NOIDUNG"].ToString();
			ketoan.Text=ds.Tables[0].Rows[0]["KETOAN"].ToString();
			giamdoc.Text=ds.Tables[0].Rows[0]["GIAMDOC"].ToString();
		}

		private void ngay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{
			ds.Tables[0].Rows[0]["NGAY"]=ngay.Text.ToString();
			ds.Tables[0].Rows[0]["KINHGUI"]=kinhgui.Text.ToString();
			ds.Tables[0].Rows[0]["DENGHI"]=denghi.Text.ToString();
			ds.Tables[0].Rows[0]["BOPHAN"]=bophan.Text.ToString();
			ds.Tables[0].Rows[0]["NOIDUNG"]=noidung.Text.ToString();
			ds.Tables[0].Rows[0]["KETOAN"]=ketoan.Text.ToString();
			ds.Tables[0].Rows[0]["GIAMDOC"]=giamdoc.Text.ToString();
			ds.WriteXml("..\\..\\..\\xml\\d_denghi.xml",XmlWriteMode.WriteSchema);
			ok=true;
			this.Close();
		}
	}
}
