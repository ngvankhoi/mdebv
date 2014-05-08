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
	public class frmEditUser : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox userid;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox password;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox nhom;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.Button butCancel;
		private AccessData m;
		private DataSet	ds=new DataSet();
		private DataSet dsr=new DataSet();
		private string user,v_user="",v_psw="",v_right="",s_makp,s_madoituong,s_nhomkho,s_cls,s_mabs,s_may;
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.Label label5;
		private int m_id;
		private System.Windows.Forms.TextBox passcu;
		private System.Windows.Forms.Label label6;
        private bool bMahoa;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		public frmEditUser(AccessData acc,DataSet dset,int id,string user,string psw,string right,string _makp,string _madoituong,string _nhomkho,string cls,string _mabs,string _may)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			m=acc;dsr=dset;m_id=id;v_user=user;v_psw=psw;v_right=right;s_nhomkho=_nhomkho;
            s_makp = _makp; s_madoituong = _madoituong; s_cls = cls; s_mabs = _mabs; s_may = _may;
            if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditUser));
            this.label1 = new System.Windows.Forms.Label();
            this.hoten = new System.Windows.Forms.TextBox();
            this.userid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nhom = new System.Windows.Forms.ComboBox();
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.makp = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
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
            this.hoten.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(88, 9);
            this.hoten.MaxLength = 50;
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(152, 23);
            this.hoten.TabIndex = 1;
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
            // 
            // userid
            // 
            this.userid.BackColor = System.Drawing.SystemColors.HighlightText;
            this.userid.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userid.Location = new System.Drawing.Point(88, 36);
            this.userid.MaxLength = 10;
            this.userid.Name = "userid";
            this.userid.Size = new System.Drawing.Size(96, 23);
            this.userid.TabIndex = 3;
            this.userid.Validated += new System.EventHandler(this.userid_Validated);
            this.userid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userid_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Login :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // password
            // 
            this.password.BackColor = System.Drawing.SystemColors.HighlightText;
            this.password.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(88, 88);
            this.password.MaxLength = 10;
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(96, 23);
            this.password.TabIndex = 7;
            this.password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.password_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-8, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mật khẩu mới :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(272, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nhóm :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhom
            // 
            this.nhom.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhom.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhom.Items.AddRange(new object[] {
            "Quản trị hệ thống",
            "Quản trị khoa/Phòng",
            "Người dùng",
            "Nhập liệu khoa/phòng"});
            this.nhom.Location = new System.Drawing.Point(336, 114);
            this.nhom.Name = "nhom";
            this.nhom.Size = new System.Drawing.Size(160, 24);
            this.nhom.TabIndex = 9;
            this.nhom.SelectedIndexChanged += new System.EventHandler(this.nhom_SelectedIndexChanged);
            this.nhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhom_KeyDown);
            // 
            // butOk
            // 
            this.butOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(54, 123);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 25);
            this.butOk.TabIndex = 12;
            this.butOk.Text = "     &Lưu";
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Image = global::Medisoft.Properties.Resources.exit1;
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(126, 123);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(70, 25);
            this.butCancel.TabIndex = 13;
            this.butCancel.Text = "&Kết thúc";
            this.butCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makp.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Items.AddRange(new object[] {
            "Quản trị",
            "Các khoa"});
            this.makp.Location = new System.Drawing.Point(336, 141);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(160, 24);
            this.makp.TabIndex = 11;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(272, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "Khoa :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // passcu
            // 
            this.passcu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.passcu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passcu.Location = new System.Drawing.Point(88, 62);
            this.passcu.MaxLength = 10;
            this.passcu.Name = "passcu";
            this.passcu.PasswordChar = '*';
            this.passcu.Size = new System.Drawing.Size(96, 23);
            this.passcu.TabIndex = 5;
            this.passcu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.password_KeyDown);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 23);
            this.label6.TabIndex = 4;
            this.label6.Text = "Mật khẩu củ :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmEditUser
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(250, 167);
            this.Controls.Add(this.passcu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.nhom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.userid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chỉnh sửa mật khẩu";
            this.Load += new System.EventHandler(this.frmEditUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private bool kiemtra()
		{
			if (hoten.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Yều cầu nhập họ tên !"),LibMedi.AccessData.Msg);
				hoten.Focus();
				return false;
			}
			if (userid.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Yều cầu nhập tên login !"),LibMedi.AccessData.Msg);
				userid.Focus();
				return false;
			}
            if (bMahoa)
            {
                string makhau = passcu.Text.ToString().Trim().ToUpper();
                string sql = "select * from "+m.user+".dlogin where id=" + m_id;
                sql += " and password_='" + m.encode(makhau) + "'";
                if (m.get_data(sql).Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Mật khẩu củ không đúng !"), LibMedi.AccessData.Msg);
                    passcu.Focus();
                    return false;
                }
            }
            else
            {
                if (passcu.Text != v_psw)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Mật khẩu củ không đúng !"), LibMedi.AccessData.Msg);
                    passcu.Focus();
                    return false;
                }
            }
			return true;
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
            string mahoa = password.Text;
            if (bMahoa) mahoa = m.encode(password.Text);
			m.upd_dlogin(m_id,hoten.Text,userid.Text,mahoa,nhom.SelectedIndex,s_makp,v_right,s_madoituong,s_nhomkho,s_cls,s_mabs,s_may);
			m.updrec(dsr.Tables[0],m_id,userid.Text,mahoa,v_right);
			m.close();this.Close();
		}

		private void butCancel_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private bool test()
		{
			if (hoten.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Yều cầu nhập họ tên !"),LibMedi.AccessData.Msg);
				hoten.Focus();
				return false;
			}

			if (userid.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Yều cầu nhập tên login !"),LibMedi.AccessData.Msg);
				userid.Focus();
				return false;
			}

			return true;
		}
		private void frmEditUser_Load(object sender, System.EventArgs e)
		{
            user = m.user;
            bMahoa = m.bMahoamatkhau;
            makp.DataSource = m.get_data("select * from " + user + ".btdkp_bv").Tables[0];
			makp.DisplayMember="TENKP";
			makp.ValueMember="MAKP";
			nhom.SelectedIndex=0;
			if (m_id!=0)
			{
                foreach (DataRow r in m.get_data("select * from " + user + ".dlogin where id=" + m_id).Tables[0].Rows)
				{
					hoten.Text=r["hoten"].ToString();
					nhom.SelectedIndex=int.Parse(r["manhom"].ToString());
					if (r["makp"].ToString()!="") makp.SelectedValue=r["makp"].ToString();
					else makp.SelectedIndex=-1;
					break;
				}
				if (hoten.Text=="") hoten.Text=v_user;
				if (nhom.SelectedIndex==-1) nhom.SelectedIndex=0;
				userid.Text=v_user;
				password.Text="";
				passcu.Text="";
				hoten.Enabled=false;
				userid.Enabled=false;
				nhom.Enabled=false;
			}
			else
			{
				m_id=0;
				try
				{
                    m_id = int.Parse(m.get_data("select max(id) from " + user + ".dlogin").Tables[0].Rows[0][0].ToString()) + 1;
				}
				catch{}
			}
		}

		private void hoten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void userid_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void password_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void userid_Validated(object sender, System.EventArgs e)
		{
			if (userid.Text!="")
			{
				DataRow r=m.getrowbyid(dsr.Tables[0],"userid='"+userid.Text+"'");
				if (r!=null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Tên login đã có !"),LibMedi.AccessData.Msg);
					userid.Focus();
					return;
				}
			}
		}

		private void nhom_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				SendKeys.Send("{Tab}");
				if (makp.Enabled) SendKeys.Send("{F4}");
			}
		}

		private void nhom_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				makp.Enabled=nhom.SelectedIndex==1;
				makp.SelectedIndex=-1;
			}
			catch{makp.SelectedIndex=-1;}
		}

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (makp.SelectedIndex==-1) makp.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		public DataSet dsright
		{
			get
			{
				return dsr;
			}
		}
	}
}
