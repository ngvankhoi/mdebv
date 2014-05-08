using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmUser.
	/// </summary>
	public class frmPbacsy : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox password;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.Button butCancel;
		private AccessData m;
		private DataSet	ds=new DataSet();
		private string s_mabs,psw,user;
		private System.Windows.Forms.TextBox passcu;
		private System.Windows.Forms.Label label6;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		public frmPbacsy(AccessData acc,string mabs)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; s_mabs = mabs; if (m.bBogo) tv.GanBogo(this, textBox111);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPbacsy));
			this.label1 = new System.Windows.Forms.Label();
			this.hoten = new System.Windows.Forms.TextBox();
			this.password = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.butOk = new System.Windows.Forms.Button();
			this.butCancel = new System.Windows.Forms.Button();
			this.passcu = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Họ tên :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// hoten
			// 
			this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
			this.hoten.Enabled = false;
			this.hoten.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.hoten.Location = new System.Drawing.Point(88, 11);
			this.hoten.MaxLength = 50;
			this.hoten.Name = "hoten";
			this.hoten.Size = new System.Drawing.Size(152, 23);
			this.hoten.TabIndex = 0;
			this.hoten.Text = "";
			this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
			// 
			// password
			// 
			this.password.BackColor = System.Drawing.SystemColors.HighlightText;
			this.password.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.password.Location = new System.Drawing.Point(88, 62);
			this.password.MaxLength = 10;
			this.password.Name = "password";
			this.password.PasswordChar = '*';
			this.password.Size = new System.Drawing.Size(152, 23);
			this.password.TabIndex = 2;
			this.password.Text = "";
			this.password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.password_KeyDown);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(-8, 62);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Mật khẩu mới :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// butOk
			// 
			this.butOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.butOk.Image = ((System.Drawing.Bitmap)(resources.GetObject("butOk.Image")));
			this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butOk.Location = new System.Drawing.Point(54, 97);
			this.butOk.Name = "butOk";
			this.butOk.Size = new System.Drawing.Size(70, 25);
			this.butOk.TabIndex = 3;
			this.butOk.Text = "      &Lưu";
			this.butOk.Click += new System.EventHandler(this.butOk_Click);
			// 
			// butCancel
			// 
			this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.butCancel.Image = ((System.Drawing.Bitmap)(resources.GetObject("butCancel.Image")));
			this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butCancel.Location = new System.Drawing.Point(127, 97);
			this.butCancel.Name = "butCancel";
			this.butCancel.Size = new System.Drawing.Size(70, 25);
			this.butCancel.TabIndex = 4;
			this.butCancel.Text = "&Kết thúc";
			this.butCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
			// 
			// passcu
			// 
			this.passcu.BackColor = System.Drawing.SystemColors.HighlightText;
			this.passcu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.passcu.Location = new System.Drawing.Point(88, 36);
			this.passcu.MaxLength = 10;
			this.passcu.Name = "passcu";
			this.passcu.PasswordChar = '*';
			this.passcu.Size = new System.Drawing.Size(152, 23);
			this.passcu.TabIndex = 1;
			this.passcu.Text = "";
			this.passcu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.password_KeyDown);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 36);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 23);
			this.label6.TabIndex = 4;
			this.label6.Text = "Mật khẩu củ :";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// frmPbacsy
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(250, 135);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.passcu,
																		  this.label6,
																		  this.butCancel,
																		  this.butOk,
																		  this.password,
																		  this.label3,
																		  this.hoten,
																		  this.label1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmPbacsy";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Chỉnh sửa mật khẩu";
			this.Load += new System.EventHandler(this.frmPbacsy_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private bool kiemtra()
		{
			if (passcu.Text!=psw)
			{
				MessageBox.Show(lan.Change_language_MessageText("Mật khẩu củ không đúng !"),LibMedi.AccessData.Msg);
				passcu.Focus();
				return false;
			}
			return true;
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			m.execute_data("update "+user+".dmbs set password_='"+password.Text+"' where ma='"+s_mabs+"'");
			m.close();this.Close();
		}

		private void butCancel_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void frmPbacsy_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			ds=m.get_data("select * from "+user+".dmbs");
			DataRow r=m.getrowbyid(ds.Tables[0],"ma='"+s_mabs+"'");
			if (r!=null)
			{
				hoten.Text=r["hoten"].ToString();
				psw=r["password_"].ToString();
			}
		}

		private void hoten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void password_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
		}
	}
}
