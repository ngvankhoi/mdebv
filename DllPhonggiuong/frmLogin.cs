using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DllPhonggiuong
{
	public class frmLogin : System.Windows.Forms.Form
	{
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private DataSet ds=new DataSet();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private PinkieControls.ButtonXP btnConnect;
		private PinkieControls.ButtonXP btnExit;
		private System.ComponentModel.Container components = null;
        public string s_hoten = "", s_makp = "", s_user = "";
		public int i_userid;
		private int i_log;
		private System.Windows.Forms.TextBox userid;
		private System.Windows.Forms.TextBox password;
		public frmLogin(int log)
		{
			InitializeComponent();
			i_log=log;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmLogin));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.userid = new System.Windows.Forms.TextBox();
			this.password = new System.Windows.Forms.TextBox();
			this.btnConnect = new PinkieControls.ButtonXP();
			this.btnExit = new PinkieControls.ButtonXP();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Tên đăng nhập :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(0, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Mật khẩu :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// userid
			// 
			this.userid.Location = new System.Drawing.Point(88, 16);
			this.userid.Name = "userid";
			this.userid.Size = new System.Drawing.Size(208, 20);
			this.userid.TabIndex = 1;
			this.userid.Text = "";
			this.userid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userid_KeyDown);
			// 
			// password
			// 
			this.password.Location = new System.Drawing.Point(88, 38);
			this.password.Name = "password";
			this.password.PasswordChar = '*';
			this.password.Size = new System.Drawing.Size(208, 20);
			this.password.TabIndex = 3;
			this.password.Text = "";
			this.password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userid_KeyDown);
			// 
			// btnConnect
			// 
			this.btnConnect.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btnConnect.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnConnect.DefaultScheme = true;
			this.btnConnect.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnConnect.Hint = "";
			this.btnConnect.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnConnect.Image")));
			this.btnConnect.Location = new System.Drawing.Point(64, 84);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btnConnect.Size = new System.Drawing.Size(104, 27);
			this.btnConnect.TabIndex = 6;
			this.btnConnect.Text = "&Đăng nhập";
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			this.btnConnect.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userid_KeyDown);
			// 
			// btnExit
			// 
			this.btnExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnExit.DefaultScheme = true;
			this.btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnExit.Hint = "";
			this.btnExit.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnExit.Image")));
			this.btnExit.Location = new System.Drawing.Point(168, 84);
			this.btnExit.Name = "btnExit";
			this.btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btnExit.Size = new System.Drawing.Size(80, 27);
			this.btnExit.TabIndex = 7;
			this.btnExit.Text = "&Thoát";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			this.btnExit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userid_KeyDown);
			// 
			// frmLogin
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(306, 123);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnExit,
																		  this.btnConnect,
																		  this.password,
																		  this.userid,
																		  this.label2,
																		  this.label1});
			this.ForeColor = System.Drawing.Color.MidnightBlue;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmLogin";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Đăng nhập";
			this.Load += new System.EventHandler(this.frmLogin_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmLogin_Load(object sender, System.EventArgs e)
		{
            s_user = m.user;
            f_capnhat_db();//
			userid.Focus();
		}
		private void btnConnect_Click(object sender, System.EventArgs e)
		{
			s_hoten="";            
			if(kiemtra())
			{
				string s_table=(i_log==1)?"v_dlogin":"dlogin";
				string file=(i_log==0)?",makp":"";
                ds = m.get_data("select id,hoten " + file + " from " + s_user + "." + s_table + " where lower(trim(userid))='" + userid.Text.ToLower().Trim() + "' and lower(password_)='" + password.Text.ToLower().Trim() + "'");
				if(ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show("Tên người dùng và mật khẩu không hợp lệ!");
					userid.Focus();
					return;
				}
				else
				{
					DataRow r=ds.Tables[0].Rows[0];
					if(r!=null)
					{
						if(file!="") s_makp=r["makp"].ToString();
						s_hoten=r["hoten"].ToString();
						i_userid=int.Parse(r["id"].ToString());
					}
				}
				this.Close();
			}
		}
		private bool kiemtra()
		{
			if(userid.Text.Trim()=="")
			{
				userid.Focus();
				return false;
			}
			if(password.Text.Trim()=="")
			{
				password.Focus();
				return false;
			}
			return true;
		}
		private void txtServicesName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void userid_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				SendKeys.Send("{Tab}");
			}
		}
        private void f_capnhat_db()
        {
            string asql = "select mabn from " + s_user + ".datgiuong where 1=2";
            DataSet lds = m.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = "create table " + s_user + ".datgiuong (MABN varchar(8), NGAY timestamp, IDGIUONG numeric(10), DEN timestamp, GHICHU text, USERID numeric(7) default 0, NGAYUD timestamp default now(), constraint pk_datgiuong primary key (mabn, ngay, idgiuong) USING INDEX TABLESPACE medi_index)  WITH OIDS ";
                m.execute_data(asql, false);
            }
            asql = "select ghichu from " + s_user + ".dmgiuong where 1=2";
            lds = m.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = "alter table " + s_user + ".dmgiuong add ghichu varchar(50)";
                m.execute_data(asql, false);
            }
        }
	}
}
