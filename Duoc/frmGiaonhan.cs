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
	public class frmGiaonhan : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker ngay;
		private System.Windows.Forms.Label label2;
		private DataSet ds=new DataSet();
		private AccessData d;
		public bool ok=false;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button butCancel;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.TextBox ht1;
		private System.Windows.Forms.TextBox soqd;
		private System.Windows.Forms.TextBox cv1;
		private System.Windows.Forms.TextBox cv2;
		private System.Windows.Forms.TextBox ht2;
		private System.Windows.Forms.TextBox dd;
		private MaskedBox.MaskedBox ngayqd;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox cuaqd;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox cv3;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox ht3;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmGiaonhan(AccessData acc)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGiaonhan));
            this.label1 = new System.Windows.Forms.Label();
            this.ngay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.ht1 = new System.Windows.Forms.TextBox();
            this.soqd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cv1 = new System.Windows.Forms.TextBox();
            this.cv2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ht2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dd = new System.Windows.Forms.TextBox();
            this.butCancel = new System.Windows.Forms.Button();
            this.butOk = new System.Windows.Forms.Button();
            this.ngayqd = new MaskedBox.MaskedBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cuaqd = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cv3 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ht3 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
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
            this.label2.Location = new System.Drawing.Point(-1, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 23);
            this.label2.TabIndex = 16;
            this.label2.Text = "- Ông/Bà :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ht1
            // 
            this.ht1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ht1.Location = new System.Drawing.Point(80, 80);
            this.ht1.Name = "ht1";
            this.ht1.Size = new System.Drawing.Size(176, 21);
            this.ht1.TabIndex = 5;
            this.ht1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // soqd
            // 
            this.soqd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soqd.Location = new System.Drawing.Point(112, 32);
            this.soqd.Name = "soqd";
            this.soqd.Size = new System.Drawing.Size(64, 21);
            this.soqd.TabIndex = 2;
            this.soqd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(253, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 23);
            this.label8.TabIndex = 17;
            this.label8.Text = "Chức vụ :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cv1
            // 
            this.cv1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cv1.Location = new System.Drawing.Point(309, 80);
            this.cv1.Name = "cv1";
            this.cv1.Size = new System.Drawing.Size(115, 21);
            this.cv1.TabIndex = 6;
            this.cv1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // cv2
            // 
            this.cv2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cv2.Location = new System.Drawing.Point(309, 104);
            this.cv2.Name = "cv2";
            this.cv2.Size = new System.Drawing.Size(115, 21);
            this.cv2.TabIndex = 8;
            this.cv2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(253, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 19;
            this.label5.Text = "Chức vụ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ht2
            // 
            this.ht2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ht2.Location = new System.Drawing.Point(80, 104);
            this.ht2.Name = "ht2";
            this.ht2.Size = new System.Drawing.Size(176, 21);
            this.ht2.TabIndex = 7;
            this.ht2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(-1, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 23);
            this.label9.TabIndex = 18;
            this.label9.Text = "- Ông/Bà :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(-16, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 23);
            this.label10.TabIndex = 14;
            this.label10.Text = "Căn cứ Quyết định số :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-16, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 23);
            this.label3.TabIndex = 22;
            this.label3.Text = "Địa điểm giao nhận TSCĐ :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dd
            // 
            this.dd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dd.Location = new System.Drawing.Point(136, 152);
            this.dd.Name = "dd";
            this.dd.Size = new System.Drawing.Size(384, 21);
            this.dd.TabIndex = 11;
            this.dd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // butCancel
            // 
            this.butCancel.Image = ((System.Drawing.Image)(resources.GetObject("butCancel.Image")));
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(270, 184);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(70, 25);
            this.butCancel.TabIndex = 13;
            this.butCancel.Text = "&Kết thúc";
            this.butCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butOk
            // 
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(199, 184);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 25);
            this.butOk.TabIndex = 12;
            this.butOk.Text = "     Đồng ý";
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // ngayqd
            // 
            this.ngayqd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayqd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayqd.Location = new System.Drawing.Point(210, 32);
            this.ngayqd.Mask = "##/##/####";
            this.ngayqd.MaxLength = 10;
            this.ngayqd.Name = "ngayqd";
            this.ngayqd.Size = new System.Drawing.Size(64, 21);
            this.ngayqd.TabIndex = 3;
            this.ngayqd.Text = "  /  /    ";
            this.ngayqd.Validated += new System.EventHandler(this.ngayqd_Validated);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(170, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 23);
            this.label6.TabIndex = 23;
            this.label6.Text = "Ngày :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(272, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 23);
            this.label7.TabIndex = 24;
            this.label7.Text = "của :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cuaqd
            // 
            this.cuaqd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuaqd.Location = new System.Drawing.Point(304, 32);
            this.cuaqd.Name = "cuaqd";
            this.cuaqd.Size = new System.Drawing.Size(216, 21);
            this.cuaqd.TabIndex = 4;
            this.cuaqd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(0, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(144, 23);
            this.label11.TabIndex = 15;
            this.label11.Text = "Ban giao nhận TSCĐ gồm :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cv3
            // 
            this.cv3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cv3.Location = new System.Drawing.Point(309, 128);
            this.cv3.Name = "cv3";
            this.cv3.Size = new System.Drawing.Size(115, 21);
            this.cv3.TabIndex = 10;
            this.cv3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(253, 128);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 23);
            this.label12.TabIndex = 21;
            this.label12.Text = "Chức vụ :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ht3
            // 
            this.ht3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ht3.Location = new System.Drawing.Point(80, 128);
            this.ht3.Name = "ht3";
            this.ht3.Size = new System.Drawing.Size(176, 21);
            this.ht3.TabIndex = 9;
            this.ht3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(-1, 128);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 23);
            this.label13.TabIndex = 20;
            this.label13.Text = "- Ông/Bà :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(426, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 23);
            this.label4.TabIndex = 25;
            this.label4.Text = "Đại diện bên giao";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(426, 105);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 23);
            this.label14.TabIndex = 26;
            this.label14.Text = "Đại diện bên nhận";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(426, 128);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 23);
            this.label15.TabIndex = 27;
            this.label15.Text = "Đại diện";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmGiaonhan
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(538, 231);
            this.Controls.Add(this.dd);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ht3);
            this.Controls.Add(this.ht2);
            this.Controls.Add(this.ht1);
            this.Controls.Add(this.cv3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.ngayqd);
            this.Controls.Add(this.soqd);
            this.Controls.Add(this.cuaqd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cv2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cv1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGiaonhan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Biên bản giao nhận TSCĐ";
            this.Load += new System.EventHandler(this.frmGiaonhan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmGiaonhan_Load(object sender, System.EventArgs e)
		{
			ds.ReadXml("..\\..\\..\\xml\\d_giaonhan.xml");
			soqd.Text=ds.Tables[0].Rows[0]["SOQD"].ToString();
			ngayqd.Text=ds.Tables[0].Rows[0]["NGAYQD"].ToString();
			cuaqd.Text=ds.Tables[0].Rows[0]["CUAQD"].ToString();
			ht1.Text=ds.Tables[0].Rows[0]["HT1"].ToString();
			cv1.Text=ds.Tables[0].Rows[0]["CV1"].ToString();
			ht2.Text=ds.Tables[0].Rows[0]["HT2"].ToString();
			cv2.Text=ds.Tables[0].Rows[0]["CV2"].ToString();
			ht3.Text=ds.Tables[0].Rows[0]["HT3"].ToString();
			cv3.Text=ds.Tables[0].Rows[0]["CV3"].ToString();
			dd.Text=ds.Tables[0].Rows[0]["DD"].ToString();
		}

		private void ngay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butCancel_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{
			ds.Tables[0].Rows[0]["NGAY"]=ngay.Text;
			ds.Tables[0].Rows[0]["SOQD"]=soqd.Text;
			ds.Tables[0].Rows[0]["NGAYQD"]=ngayqd.Text;
			ds.Tables[0].Rows[0]["CUAQD"]=cuaqd.Text;
			ds.Tables[0].Rows[0]["HT1"]=ht1.Text;
			ds.Tables[0].Rows[0]["CV1"]=cv1.Text;
			ds.Tables[0].Rows[0]["HT2"]=ht2.Text;
			ds.Tables[0].Rows[0]["CV2"]=cv2.Text;
			ds.Tables[0].Rows[0]["HT3"]=ht3.Text;
			ds.Tables[0].Rows[0]["CV3"]=cv3.Text;
			ds.Tables[0].Rows[0]["DD"]=dd.Text;
			ds.WriteXml("..\\..\\..\\xml\\d_giaonhan.xml",XmlWriteMode.WriteSchema);
			ok=true;
			d.close();this.Close();
		}

		private void ngayqd_Validated(object sender, System.EventArgs e)
		{
			if (ngayqd.Text=="") return;
			ngayqd.Text=ngayqd.Text.Trim();
			if (!d.bNgay(ngayqd.Text))
			{
				MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ !"),d.Msg);
				ngayqd.Focus();
				return;
			}
			ngayqd.Text=d.Ktngaygio(ngayqd.Text,10);
		}
	}
}
