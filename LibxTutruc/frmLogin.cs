using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using LibMedi;
using System.Data;

namespace libxTutruc
{
	/// <summary>
	/// Summary description for frmLogin.
	/// </summary>
	public class frmLogin : System.Windows.Forms.Form
	{
		Language lan = new Language();
		private AccessData m;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtuser;
		private System.Windows.Forms.TextBox txtpassword;
		private Wildgrape.Aqua.Controls.Button cmdOk;
		private Wildgrape.Aqua.Controls.Button cmdCancle;
        private string user;
		public string mRight="",mMakp="",mUserid="",sql,mMadoituong,mNhomkho,mCls,mMabs,mMay;
        public int iUserid = 0, iMabv = 0, iProcess;
		private DataSet ds=new DataSet();
		public bool mExit;
        private GroupBox gLicense;
        private TextBox txtLicense;
        private Label label4;
        private TextBox txtThongsomay;
        private Label label3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmLogin(AccessData acc)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			m=acc;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.cmdOk = new Wildgrape.Aqua.Controls.Button();
            this.cmdCancle = new Wildgrape.Aqua.Controls.Button();
            this.gLicense = new System.Windows.Forms.GroupBox();
            this.txtLicense = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtThongsomay = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gLicense.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(5, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Tên người sử dụng :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(10, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "&Mật khẩu truy cập :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtuser
            // 
            this.txtuser.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtuser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtuser.Location = new System.Drawing.Point(106, 20);
            this.txtuser.MaxLength = 10;
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(120, 23);
            this.txtuser.TabIndex = 1;
            this.txtuser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtuser_KeyDown);
            // 
            // txtpassword
            // 
            this.txtpassword.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpassword.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtpassword.Location = new System.Drawing.Point(106, 47);
            this.txtpassword.MaxLength = 20;
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '*';
            this.txtpassword.Size = new System.Drawing.Size(120, 23);
            this.txtpassword.TabIndex = 3;
            this.txtpassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpassword_KeyDown);
            // 
            // cmdOk
            // 
            this.cmdOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOk.Location = new System.Drawing.Point(49, 85);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.SizeToLabel = false;
            this.cmdOk.TabIndex = 4;
            this.cmdOk.Text = "Chọn";
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // cmdCancle
            // 
            this.cmdCancle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancle.Location = new System.Drawing.Point(129, 85);
            this.cmdCancle.Name = "cmdCancle";
            this.cmdCancle.SizeToLabel = false;
            this.cmdCancle.TabIndex = 5;
            this.cmdCancle.Text = "Kết thúc";
            this.cmdCancle.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // gLicense
            // 
            this.gLicense.Controls.Add(this.txtLicense);
            this.gLicense.Controls.Add(this.label4);
            this.gLicense.Controls.Add(this.txtThongsomay);
            this.gLicense.Controls.Add(this.label3);
            this.gLicense.Location = new System.Drawing.Point(8, 121);
            this.gLicense.Name = "gLicense";
            this.gLicense.Size = new System.Drawing.Size(238, 72);
            this.gLicense.TabIndex = 6;
            this.gLicense.TabStop = false;
            this.gLicense.Text = "License";
            // 
            // txtLicense
            // 
            this.txtLicense.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLicense.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtLicense.Location = new System.Drawing.Point(77, 43);
            this.txtLicense.Name = "txtLicense";
            this.txtLicense.Size = new System.Drawing.Size(159, 23);
            this.txtLicense.TabIndex = 1;
            this.txtLicense.Validated += new System.EventHandler(this.txtLicense_Validated);
            this.txtLicense.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtuser_KeyDown);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(-15, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "License :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtThongsomay
            // 
            this.txtThongsomay.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThongsomay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtThongsomay.Location = new System.Drawing.Point(77, 19);
            this.txtThongsomay.Name = "txtThongsomay";
            this.txtThongsomay.Size = new System.Drawing.Size(159, 23);
            this.txtThongsomay.TabIndex = 0;
            this.txtThongsomay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtuser_KeyDown);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(-15, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Thông số máy :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmLogin
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(249, 205);
            this.ControlBox = false;
            this.Controls.Add(this.gLicense);
            this.Controls.Add(this.cmdCancle);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.txtuser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký sử dụng";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.gLicense.ResumeLayout(false);
            this.gLicense.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void txtuser_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");	
		}

		private void txtpassword_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

		private void cmdOk_Click(object sender, System.EventArgs e)
		{
            DataTable dtver = m.get_data("select * from " + user + ".version").Tables[0];
            if (dtver.Rows.Count > 0)
            {
                if (dtver.Rows[0]["medisoft"].ToString().Trim() != "")
                {
                    string tenfile = m.file_exe("medisoft");
                    if (dtver.Rows[0]["medisoft"].ToString().Trim() != m.file_modify(tenfile))
                    {
                        MessageBox.Show("Không đúng version đang sử dụng !", LibMedi.AccessData.Msg);
                        Application.Exit();
                    }
                }
            }
			if (!kiemtra())
			{
				MessageBox.Show(lan.Change_language_MessageText("Tên người dùng và mật khẩu không tìm thấy !"),this.Text,MessageBoxButtons.OK,MessageBoxIcon.Warning);
				txtuser.Focus();
				return ;
			}
			foreach(DataRow r in m.get_data("select makp,capso from "+m.user+".btdkp_bv where capso>0").Tables[0].Rows)
			{
				if (m.get_data("select * from "+m.user+".capmabn where yy="+int.Parse(DateTime.Now.Year.ToString().Substring(2,2))+" and loai=2 and userid="+int.Parse(r["makp"].ToString())).Tables[0].Rows.Count==0)
					m.upd_capmabn(int.Parse(DateTime.Now.Year.ToString().Substring(2,2)),2,int.Parse(r["makp"].ToString()),int.Parse(r["capso"].ToString())-1);
			}
			foreach(DataRow r in m.get_data("select * from "+m.user+".capmatudong where stt>0").Tables[0].Rows)
			{
				if (m.get_data("select * from "+m.user+".capmabn where yy="+int.Parse(DateTime.Now.Year.ToString().Substring(2,2))+" and loai="+int.Parse(r["loai"].ToString())+" and userid="+int.Parse(r["loai"].ToString())).Tables[0].Rows.Count==0)
					m.upd_capmabn(int.Parse(DateTime.Now.Year.ToString().Substring(2,2)),int.Parse(r["loai"].ToString()),int.Parse(r["loai"].ToString()),int.Parse(r["stt"].ToString())-1);
			}
            if (!m.bMmyy(m.mmyy(m.ngayhienhanh_server)))
            {
                Cursor = Cursors.WaitCursor;
                m.tao_schema(m.mmyy(m.ngayhienhanh_server), iUserid);
                Cursor = Cursors.Default;
            }
			this.mExit=false;
			this.Close();
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			mUserid="";
			this.mExit=true;
			Application.Exit();
		}

		private bool kiemtra()
		{
			if (txtuser.Text==LibMedi.AccessData.links_userid && txtpassword.Text==LibMedi.AccessData.links_pass)
			{
				mUserid=txtuser.Text.Trim()+txtpassword.Text.Trim();
				return true;
			}
			try
			{
                sql = "select * from " + m.user + ".dlogin where upper(trim(userid))='" + txtuser.Text.ToString().Trim().ToUpper() + "'" + " and upper(trim(password_))='" + txtpassword.Text.ToString().Trim().ToUpper() + "'";
				ds=m.get_data(sql);
				if (ds.Tables[0].Rows.Count>0)
				{
					mRight=ds.Tables[0].Rows[0]["right_"].ToString();
					mMakp=ds.Tables[0].Rows[0]["makp"].ToString();
					mUserid=ds.Tables[0].Rows[0]["hoten"].ToString();
					iUserid=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
					mMadoituong=ds.Tables[0].Rows[0]["madoituong"].ToString();
					mNhomkho=ds.Tables[0].Rows[0]["nhomkho"].ToString();
					mCls=ds.Tables[0].Rows[0]["cls"].ToString();
					mMabs=ds.Tables[0].Rows[0]["mabs"].ToString();
                    mMay = ds.Tables[0].Rows[0]["may"].ToString();
					return true;
				}
				else return false;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				return false;
			}
		}

        private void frmLogin_Load(object sender, EventArgs e)
        {
            iProcess = m.soprocess;
            user = m.user;
            if (m.get_data("select * from "+user+".thongso where id=-2").Tables[0].Rows.Count > 0)
                f_Check_License();///Dung license
            else
                f_Uncheck_License();//Khong dung license
        }

        #region LICENSE
        private void f_Uncheck_License()
        {
            try
            {
                txtThongsomay.Text = m.s_computer_key;
                txtThongsomay.BackColor = Color.SteelBlue;
                txtThongsomay.ForeColor = Color.White;
                gLicense.Visible = false;
                this.Height = 150;

                txtuser.Enabled = true;
                txtpassword.Enabled = true;
                cmdOk.Enabled = true;
                this.Activate();
                //SendKeys.Send("{Tab}");
            }
            catch
            {
            }
        }
        private void f_Check_License()
        {
            try
            {
                txtThongsomay.Text = m.s_computer_key;
                if (!m.is_licensed)
                {
                    txtThongsomay.BackColor = Color.Black;
                    txtThongsomay.ForeColor = Color.White;
                    gLicense.Visible = true;
                    this.Height = 225;

                    txtuser.Enabled = false;
                    txtpassword.Enabled = false;
                    cmdOk.Enabled = false;

                    txtLicense.Focus();
                }
                else
                {
                    txtThongsomay.BackColor = Color.SteelBlue;
                    txtThongsomay.ForeColor = Color.White;
                    gLicense.Visible = false;
                    this.Height = 150;

                    txtuser.Enabled = true;
                    txtpassword.Enabled = true;
                    cmdOk.Enabled = true;
                    this.Activate();
                    //SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void txtLicense_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void txtLicense_Validated(object sender, System.EventArgs e)
        {
            try
            {
                m.f_set_licensed(txtLicense.Text);
                if (m.is_licensed)
                {
                    frmLogin_Load(null, null);
                }
            }
            catch
            {
            }
        }
        #endregion LICENSE	
	}
}
