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
	public class frmBangiao : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker ngay;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private DataSet ds=new DataSet();
		public bool ok=false;
		private string s_daidien;
		private System.Windows.Forms.TextBox bena;
		private System.Windows.Forms.TextBox nguoigiao;
		private System.Windows.Forms.TextBox bangiao;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox cva;
		private System.Windows.Forms.TextBox cvb;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox benb;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox nguoinhan;
		private System.Windows.Forms.Button butCancel;
		private System.Windows.Forms.Button butOk;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmBangiao(string daidien)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			s_daidien=daidien;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBangiao));
            this.label1 = new System.Windows.Forms.Label();
            this.ngay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.bena = new System.Windows.Forms.TextBox();
            this.nguoigiao = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bangiao = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cva = new System.Windows.Forms.TextBox();
            this.cvb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.benb = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nguoinhan = new System.Windows.Forms.TextBox();
            this.butCancel = new System.Windows.Forms.Button();
            this.butOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(40, 8);
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
            this.ngay.Location = new System.Drawing.Point(80, 8);
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(80, 21);
            this.ngay.TabIndex = 1;
            this.ngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bên giao (A)  :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bena
            // 
            this.bena.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bena.Location = new System.Drawing.Point(80, 32);
            this.bena.Name = "bena";
            this.bena.Size = new System.Drawing.Size(176, 21);
            this.bena.TabIndex = 3;
            this.bena.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // nguoigiao
            // 
            this.nguoigiao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nguoigiao.Location = new System.Drawing.Point(80, 56);
            this.nguoigiao.Name = "nguoigiao";
            this.nguoigiao.Size = new System.Drawing.Size(176, 21);
            this.nguoigiao.TabIndex = 7;
            this.nguoigiao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 23);
            this.label4.TabIndex = 14;
            this.label4.Text = "Đã tiến hành bàn giao các vật tư ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bangiao
            // 
            this.bangiao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bangiao.Location = new System.Drawing.Point(176, 128);
            this.bangiao.Name = "bangiao";
            this.bangiao.Size = new System.Drawing.Size(280, 21);
            this.bangiao.TabIndex = 15;
            this.bangiao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(264, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 23);
            this.label8.TabIndex = 4;
            this.label8.Text = "Chức vụ :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cva
            // 
            this.cva.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cva.Location = new System.Drawing.Point(320, 32);
            this.cva.Name = "cva";
            this.cva.Size = new System.Drawing.Size(136, 21);
            this.cva.TabIndex = 5;
            this.cva.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // cvb
            // 
            this.cvb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cvb.Location = new System.Drawing.Point(320, 80);
            this.cvb.Name = "cvb";
            this.cvb.Size = new System.Drawing.Size(136, 21);
            this.cvb.TabIndex = 11;
            this.cvb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(265, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "Chức vụ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // benb
            // 
            this.benb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.benb.Location = new System.Drawing.Point(80, 80);
            this.benb.Name = "benb";
            this.benb.Size = new System.Drawing.Size(176, 21);
            this.benb.TabIndex = 9;
            this.benb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(0, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 23);
            this.label9.TabIndex = 8;
            this.label9.Text = "Bên nhận (B)  :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 23);
            this.label10.TabIndex = 6;
            this.label10.Text = "Người giao :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "Người nhận :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nguoinhan
            // 
            this.nguoinhan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nguoinhan.Location = new System.Drawing.Point(80, 104);
            this.nguoinhan.Name = "nguoinhan";
            this.nguoinhan.Size = new System.Drawing.Size(176, 21);
            this.nguoinhan.TabIndex = 13;
            this.nguoinhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // butCancel
            // 
            this.butCancel.Image = ((System.Drawing.Image)(resources.GetObject("butCancel.Image")));
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(234, 160);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(70, 25);
            this.butCancel.TabIndex = 17;
            this.butCancel.Text = "&Kết thúc";
            this.butCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butOk
            // 
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(162, 160);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 25);
            this.butOk.TabIndex = 16;
            this.butOk.Text = "    Đồng ý";
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // frmBangiao
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(466, 207);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nguoinhan);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cvb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.benb);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cva);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.bangiao);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nguoigiao);
            this.Controls.Add(this.bena);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBangiao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Biên bản bàn giao";
            this.Load += new System.EventHandler(this.frmBangiao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmBangiao_Load(object sender, System.EventArgs e)
		{
			ds.ReadXml("..\\..\\..\\xml\\d_bangiao.xml");
			bena.Text=s_daidien;
			cva.Text=ds.Tables[0].Rows[0]["CVA"].ToString();
			benb.Text=ds.Tables[0].Rows[0]["BENB"].ToString();
			cvb.Text=ds.Tables[0].Rows[0]["CVB"].ToString();
			nguoigiao.Text=ds.Tables[0].Rows[0]["NGUOIGIAO"].ToString();
			nguoinhan.Text=ds.Tables[0].Rows[0]["NGUOINHAN"].ToString();
			bangiao.Text=ds.Tables[0].Rows[0]["BANGIAO"].ToString();
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
			ds.Tables[0].Rows[0]["BENA"]=bena.Text.ToString();
			ds.Tables[0].Rows[0]["CVA"]=cva.Text.ToString();
			ds.Tables[0].Rows[0]["BENB"]=benb.Text.ToString();
			ds.Tables[0].Rows[0]["CVB"]=cvb.Text.ToString();
			ds.Tables[0].Rows[0]["NGUOIGIAO"]=nguoigiao.Text.ToString();
			ds.Tables[0].Rows[0]["NGUOINHAN"]=nguoinhan.Text.ToString();
			ds.Tables[0].Rows[0]["BANGIAO"]=bangiao.Text.ToString();
			ds.WriteXml("..\\..\\..\\xml\\d_bangiao.xml",XmlWriteMode.WriteSchema);
			ok=true;
			this.Close();
		}
	}
}
