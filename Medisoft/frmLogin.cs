using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using LibMedi;
using System.Data;

namespace Medisoft
{
	public class frmLogin : System.Windows.Forms.Form
    {
        bool bChuaDangKiLicense=false;
        #region Khai bao
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();
        private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private AccessData m;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtuser;
		private System.Windows.Forms.TextBox txtpassword;
		private Wildgrape.Aqua.Controls.Button cmdOk;
		private Wildgrape.Aqua.Controls.Button cmdCancle;
        private string user;
		public string mRight="",mMakp="",mUserid="",sql,mMadoituong,mNhomkho,mCls,mMabs,mMay,s_khudt="";
        public int iUserid = 0, iMabv = 0, iProcess, i_chinhanh=0;
		private DataSet ds=new DataSet();
		public bool mExit;
        private GroupBox groLicense;
        private Label label4;
        private Label label3;
        private GroupBox groLogin;
        private RichTextBox txtLicense;
        private RichTextBox txtKey;
        private Button butTiepTuc;
        private Button butDangKi;
        private Label lblLicense;
		private System.ComponentModel.Container components = null;
        #endregion

        public frmLogin(AccessData acc)
		{
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
            //
            string s_cn = m.f_getten_chinhanh(m.i_Chinhanh_hientai);
            this.Text = "Medisoft - " + ((s_cn.Trim() == "") ? "" : " - " + s_cn);
            //
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.cmdOk = new Wildgrape.Aqua.Controls.Button();
            this.cmdCancle = new Wildgrape.Aqua.Controls.Button();
            this.groLicense = new System.Windows.Forms.GroupBox();
            this.lblLicense = new System.Windows.Forms.Label();
            this.txtLicense = new System.Windows.Forms.RichTextBox();
            this.txtKey = new System.Windows.Forms.RichTextBox();
            this.butTiepTuc = new System.Windows.Forms.Button();
            this.butDangKi = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groLogin = new System.Windows.Forms.GroupBox();
            this.groLicense.SuspendLayout();
            this.groLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(15, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên người sử dụng ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(19, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu truy cập ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtuser
            // 
            this.txtuser.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtuser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtuser.Location = new System.Drawing.Point(123, 25);
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
            this.txtpassword.Location = new System.Drawing.Point(123, 54);
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
            this.cmdOk.Location = new System.Drawing.Point(60, 95);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.SizeToLabel = false;
            this.cmdOk.TabIndex = 4;
            this.cmdOk.Text = "Chọn";
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // cmdCancle
            // 
            this.cmdCancle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancle.Location = new System.Drawing.Point(146, 95);
            this.cmdCancle.Name = "cmdCancle";
            this.cmdCancle.SizeToLabel = false;
            this.cmdCancle.TabIndex = 5;
            this.cmdCancle.Text = "Kết thúc";
            this.cmdCancle.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // groLicense
            // 
            this.groLicense.Controls.Add(this.lblLicense);
            this.groLicense.Controls.Add(this.txtLicense);
            this.groLicense.Controls.Add(this.txtKey);
            this.groLicense.Controls.Add(this.butTiepTuc);
            this.groLicense.Controls.Add(this.butDangKi);
            this.groLicense.Controls.Add(this.label4);
            this.groLicense.Controls.Add(this.label3);
            this.groLicense.Location = new System.Drawing.Point(1, 0);
            this.groLicense.Name = "groLicense";
            this.groLicense.Size = new System.Drawing.Size(389, 235);
            this.groLicense.TabIndex = 6;
            this.groLicense.TabStop = false;
            this.groLicense.Text = "License";
            // 
            // lblLicense
            // 
            this.lblLicense.ForeColor = System.Drawing.Color.Red;
            this.lblLicense.Location = new System.Drawing.Point(2, 12);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(381, 44);
            this.lblLicense.TabIndex = 14;
            this.lblLicense.Text = "Bạn chưa có bản quyền sử dụng. Vui lòng copy key bên dưới và gởi cho quản trị hệ " +
                "thống.\r\nBạn còn 30 ngày sử dụng";
            this.lblLicense.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLicense
            // 
            this.txtLicense.Location = new System.Drawing.Point(73, 105);
            this.txtLicense.Name = "txtLicense";
            this.txtLicense.Size = new System.Drawing.Size(299, 91);
            this.txtLicense.TabIndex = 13;
            this.txtLicense.Text = "";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(73, 62);
            this.txtKey.Name = "txtKey";
            this.txtKey.ReadOnly = true;
            this.txtKey.Size = new System.Drawing.Size(299, 39);
            this.txtKey.TabIndex = 12;
            this.txtKey.Text = "";
            // 
            // butTiepTuc
            // 
            this.butTiepTuc.Image = ((System.Drawing.Image)(resources.GetObject("butTiepTuc.Image")));
            this.butTiepTuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTiepTuc.Location = new System.Drawing.Point(202, 201);
            this.butTiepTuc.Name = "butTiepTuc";
            this.butTiepTuc.Size = new System.Drawing.Size(75, 23);
            this.butTiepTuc.TabIndex = 11;
            this.butTiepTuc.Text = "   Tiếp tục";
            this.butTiepTuc.UseVisualStyleBackColor = true;
            this.butTiepTuc.Click += new System.EventHandler(this.butTiepTuc_Click);
            // 
            // butDangKi
            // 
            this.butDangKi.Image = ((System.Drawing.Image)(resources.GetObject("butDangKi.Image")));
            this.butDangKi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDangKi.Location = new System.Drawing.Point(121, 201);
            this.butDangKi.Name = "butDangKi";
            this.butDangKi.Size = new System.Drawing.Size(75, 23);
            this.butDangKi.TabIndex = 10;
            this.butDangKi.Text = "    Đăng ký";
            this.butDangKi.UseVisualStyleBackColor = true;
            this.butDangKi.Click += new System.EventHandler(this.butDangKi_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(-17, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "License :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(21, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 22);
            this.label3.TabIndex = 7;
            this.label3.Text = "Key";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groLogin
            // 
            this.groLogin.BackColor = System.Drawing.SystemColors.Control;
            this.groLogin.Controls.Add(this.txtuser);
            this.groLogin.Controls.Add(this.txtpassword);
            this.groLogin.Controls.Add(this.label1);
            this.groLogin.Controls.Add(this.cmdCancle);
            this.groLogin.Controls.Add(this.label2);
            this.groLogin.Controls.Add(this.cmdOk);
            this.groLogin.Location = new System.Drawing.Point(0, -9);
            this.groLogin.Name = "groLogin";
            this.groLogin.Size = new System.Drawing.Size(278, 148);
            this.groLogin.TabIndex = 7;
            this.groLogin.TabStop = false;
            // 
            // frmLogin
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(385, 229);
            this.ControlBox = false;
            this.Controls.Add(this.groLogin);
            this.Controls.Add(this.groLicense);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký sử dụng";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.groLicense.ResumeLayout(false);
            this.groLogin.ResumeLayout(false);
            this.groLogin.PerformLayout();
            this.ResumeLayout(false);

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
            m.setStandar();
            string Ngaydemo = m.Ngaydemo("medisoft");
            if (Ngaydemo != "")
            {
                int songay = m.Songaydemo;
                if (songay != 0)
                {
                    decimal conlai = songay - m.songay(m.StringToDate(m.ngayhienhanh_server.Substring(0, 10)), m.StringToDate(Ngaydemo), 0);
                    if (conlai <= 0)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Đã hết thời gian chạy thử.") + "\n" + lan.Change_language_MessageText("Liên hệ nhà cung cấp:") + "\nPhone : 08.7155019\nMobile : 090 3937066", LibMedi.AccessData.Msg);
                        return;
                    }
                    else if (conlai <= 3)
                        MessageBox.Show(lan.Change_language_MessageText("Thời gian chạy thử còn ") + conlai.ToString() + " ngày", LibMedi.AccessData.Msg);
                }
            }
            DataTable dtver = m.get_data("select * from " + user + ".version").Tables[0];
            if (dtver.Rows.Count > 0)
            {
                if (dtver.Rows[0]["medisoft"].ToString().Trim() != "")
                {
                    string tenfile = m.file_exe("medisoft");
                    if (dtver.Rows[0]["medisoft"].ToString().Trim() != m.file_modify(tenfile))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Không đúng version đang sử dụng !"), LibMedi.AccessData.Msg);
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
            string ngayhienhanh = m.Ngaygio_hienhanh.Substring(0, 10);
            try
            {
                m.reset_sequence(ngayhienhanh);
            }
            catch { }
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
                CreateTableMMYY CrTa = new CreateTableMMYY(m);
                m.upd_table(m.mmyy(m.ngayhienhanh_server), iUserid);
                CrTa.CreateTable_MMYY(m.user + m.mmyy(m.ngayhienhanh_server));
                m.tao_function(m.mmyy(m.ngayhienhanh_server));
                //m.tao_schema(m.mmyy(m.ngayhienhanh_server), iUserid);
                Cursor = Cursors.Default;
            }
            if (m.bDelFileTemp) m.delFileTemp();
            Cursor = Cursors.WaitCursor;
            if (m.get_data("select * from pg_tables where tableowner='medisoft' and schemaname='" + m.user.ToLower() + "' and tablename='tiepdon'").Tables[0].Rows.Count>0)
                m.upd_hen(m.ngayhienhanh_server);
            Cursor = Cursors.Default;
			this.mExit=false;
			m.close();this.Close();
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			mUserid="";
			this.mExit=true;
			Application.Exit();
		}

		private bool kiemtra()
		{
            string ddmmyy = DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString().PadLeft(4, '0').Substring(2);
            if (txtuser.Text == LibMedi.AccessData.links_userid && txtpassword.Text == LibMedi.AccessData.links_pass.Trim() + ddmmyy)
            {
                mUserid = txtuser.Text.Trim() + txtpassword.Text.Trim().Replace(ddmmyy, "");
                i_chinhanh = m.i_Chinhanh_hientai;
                return true;
            }
			try
			{
                bool bMahoa = m.bMahoamatkhau;
                string makhau = txtpassword.Text.ToString().Trim().ToUpper();
                sql = "select * from "+m.user+".dlogin where upper(trim(userid))='" + txtuser.Text.ToString().Trim().ToUpper() + "'";
                if (bMahoa) sql += " and password_='" + m.encode(makhau) + "'";
                else sql += " and upper(trim(password_))='" + makhau + "'";
                if (m.i_Chinhanh_hientai > 0)
                {
                    sql += " and chinhanh="+m.i_Chinhanh_hientai;
                }
                ds = m.get_data(sql);
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
                    //Tu:20/05/2011
                    s_khudt = ds.Tables[0].Rows[0]["khu"].ToString();
                    i_chinhanh = int.Parse(ds.Tables[0].Rows[0]["chinhanh"].ToString());

                    //if (m.bQuanly_Theo_Chinhanh && i_chinhanh != 0 && i_chinhanh != m.i_Chinhanh_hientai)
                    //{
                    //    MessageBox.Show(lan.Change_language_MessageText("Bạn không thuộc chi nhánh này. Đề nghị liên hệ phòng máy tính."), "Medisoft", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    //    return false;
                    //}
                    //end Tu
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
            user = m.user;
            try { string chinhanh = m.get_data("select chinhanh from " + user + ".dlogin where 1=0").Tables[0].Rows[0][0].ToString(); }
            catch { m.execute_data("alter table medibv.dlogin add chinhanh numeric(2) default 0;",false); }
            iProcess = m.soprocess;
            
            f_capnhat_db();
            groLogin.BringToFront();
            groLicense.Visible = false;
            bool bQuanLyLicense = m.QuanLyLicense;
            if (bQuanLyLicense)
            {
                m.RegisterDateStart();
                if (m.DaDangKiLicense == false)
                {
                    string s_NgayHeThong = m.ngayhienhanh_server;
                    DateTime dtNgayHeThong = m.StringToDate(s_NgayHeThong);
                    string s_NgayBatDau = m.RegisterGetDateStart;
                    DateTime dtNgayBatDau = m.StringToDate(s_NgayBatDau.Substring(0, 10));
                    TimeSpan tp = dtNgayHeThong - dtNgayBatDau;
                    int i_SoNgayConLai = tp.Days;
                    txtKey.Text = Medisoft2009.MACAddress.MedisoftMAC.KeyInfo;
                    groLicense.Visible = true;
                    groLicense.BringToFront();
                    bChuaDangKiLicense = true;
                    if (i_SoNgayConLai <= 30)
                    {
                        lblLicense.Text = "Hệ thống chưa được đăng ký bản quyền sử dụng. " +
                            "Hãy copy key bên dưới gởi cho quản trị hệ thống." +
                            "\nBạn chỉ có " + (30 - i_SoNgayConLai).ToString() + " ngày dùng thử";
                    }
                    else
                    {
                        lblLicense.Text = "Hệ thống chưa được đăng ký bản quyền sử dụng. " +
                            "Hãy copy key bên dưới gởi cho quản trị hệ thống." +
                            "\nBạn đã hết số ngày dùng thử";
                        butTiepTuc.Enabled = false;
                        groLogin.Enabled = false;
                    }
                }
                else
                {
                    groLogin.Enabled = true;
                    bChuaDangKiLicense = false;
                    this.Width = 280;
                    this.Height = 146;
                }
            }
            else
            {
                this.Width = 280;
                this.Height = 146;
            }
            try
            {
                bool update = m.bAutoupdate && m.Path_medisoft != "";
                if (update)
                {
                    string file = "medisoft", path = m.Path_medisoft + "//" + file + "//bin//debug";
                    if (!m.bUpdate(System.IO.Directory.GetCurrentDirectory(), path, file))
                    {
                        m.writeXml("thongso", "version", "Version " + m.f_modify(m.file_exe_update(path, file)));
                        m.writeXml("thongso", "file", file);
                        mUserid = "";
                        this.mExit = true;
                        Application.Exit();
                        string filerun = @m.path_medisofthis() + "//version//bin//debug//version.exe";
                        backup f = new backup(filerun);
                        f.Launch();
                    }
                }
            }
            catch { }
        }

        private void f_capnhat_db()
        {
            int i_maxlength_mabn = LibMedi.AccessData.i_maxlength_mabn;
            string s_user = m.user;
            //
            DataSet lds = new DataSet();
            string user = m.user;
            string asql = "";//
            //
            //m.f_capnhat_db_danhmuc("medisoft.exe");
            //
            //            
            //hien them
            asql = "select STT from " + s_user + ".khdm_01 where stt='?'";
            lds = m.get_data(asql, false);
            if (lds == null || lds.Tables.Count <=0)
            {
                Capnhat_DB_BYT();
            }

            asql = "select duyetcv from " + s_user + ".dlogin where 1=0";
            lds = m.get_data(asql, false);
            if (lds == null || lds.Tables.Count <= 0)
            {
                m.execute_data("alter table " + user + ".dlogin add duyetcv numeric(1) default 0", false);
            }

            //Taodatabase_ba(m.mmyy(m.ngayhienhanh_server.Substring(0,10)));//binh 091106: goi trong libmedi.f_capnhat_db_danhmuc
           // m.f_capnhat_db_danhmuc("medisoft.exe", m.mmyy(m.ngayhienhanh_server.Substring(0, 10)));
        }

        
        #region Tao databse ba
        private void Taodatabase_ba(string mmyy)
        {
            string xxx = user + mmyy;

            m.execute_data("CREATE TABLE "+xxx+".bask_chiso(mabn varchar(10),maql numeric(22) NOT NULL DEFAULT 0,ngay timestamp,socmnd varchar(20),capngay timestamp,tai varchar(3),lydo text,tiensu text,CONSTRAINT pk_bask_chiso PRIMARY KEY (maql) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("CREATE TABLE "+xxx+".bask_cls(maql numeric(22) NOT NULL DEFAULT 0,mavaovien numeric(22) DEFAULT 0,stt numeric(3) default 0,idchidinh numeric(22) default 0,loai numeric(1) default 0,ketluan text,  image bytea,  CONSTRAINT pk_bask_cls PRIMARY KEY (idchidinh) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("CREATE TABLE "+xxx+".bask_donvi(mabn varchar(10),maql numeric(22) NOT NULL DEFAULT 0,madonvi numeric(22) DEFAULT 0,mach numeric(3) DEFAULT 0,chieucao numeric(6) DEFAULT 0, nhietdo numeric(5,2) DEFAULT 0,  cannang numeric(7,2) DEFAULT 0,  huyetap varchar(7),  nhiptho numeric(3) DEFAULT 0,  CONSTRAINT pk_bask_donvi PRIMARY KEY (maql) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("CREATE TABLE "+xxx+".bask_mat(maql numeric(22) NOT NULL DEFAULT 0,  mavaovien numeric(22) DEFAULT 0,  ngay timestamp,  makp varchar(3),  mat text,  thiluc text,  tlcp text,  tlct text,  tlkp text,  tlkt text,  sop text,  sot text,  sacgiac text,  khac text,  mabs varchar(4),  userid numeric(5) DEFAULT 0,  ngayud timestamp DEFAULT now(),  CONSTRAINT pk_bask_mat PRIMARY KEY (maql) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("CREATE TABLE "+xxx+".bask_ngkhoa(maql numeric(22) NOT NULL DEFAULT 0,  mavaovien numeric(22) DEFAULT 0,  ngay timestamp,  makp varchar(3),  ngoai text,  dalieu text,  khac text,  mabs varchar(4),  userid numeric(5) DEFAULT 0,  ngayud timestamp DEFAULT now(),CONSTRAINT pk_bask_ngkhoa PRIMARY KEY (maql) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("CREATE TABLE "+xxx+".bask_noikhoa(maql numeric(22) NOT NULL DEFAULT 0,  mavaovien numeric(22) DEFAULT 0,  ngay timestamp,  makp varchar(3),  toanthan text,  tonghop text,timmach text,  tamthan text,  thankinh text,  khac text,  mabs varchar(4),  userid numeric(5) DEFAULT 0,  ngayud timestamp DEFAULT now(),  CONSTRAINT pk_bask_noikhoa PRIMARY KEY (maql) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("CREATE TABLE "+xxx+".bask_rmh(maql numeric(22) NOT NULL DEFAULT 0,  mavaovien numeric(22) DEFAULT 0,  ngay timestamp,  makp varchar(3),  rhm text,  saurang text,  nhanhu text,  matrang text,  hammat text,  khac text,  mabs varchar(4),  userid numeric(5) DEFAULT 0,  ngayud timestamp DEFAULT now(),  CONSTRAINT pk_bask_rmh PRIMARY KEY (maql) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("CREATE TABLE "+xxx+".bask_sanphu(maql numeric(22) NOT NULL DEFAULT 0,  mavaovien numeric(22) DEFAULT 0,  ngay timestamp,  makp varchar(3),  san text,  phu text,  khac text,  mabs varchar(4),  userid numeric(5) DEFAULT 0,  ngayud timestamp DEFAULT now(),  CONSTRAINT pk_bask_sanphu PRIMARY KEY (maql) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("CREATE TABLE "+xxx+".bask_tmh(maql numeric(22) NOT NULL DEFAULT 0,  mavaovien numeric(22) DEFAULT 0,  ngay timestamp,  makp varchar(3),  tmh text,  thuongt text,  thamt text,  thuongp text,  thamp text,  khac text,  mabs varchar(4),  userid numeric(5) DEFAULT 0,  ngayud timestamp DEFAULT now(),  CONSTRAINT pk_bask_tmh PRIMARY KEY (maql) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("CREATE TABLE "+xxx+".bask_tongket(maql numeric(22) NOT NULL DEFAULT 0,  mavaovien numeric(22) DEFAULT 0,  ngay timestamp,  makp varchar(3),  phanloai numeric(2) DEFAULT 0,  ketluan text,  khac text,  mabs varchar(4),  userid numeric(5) DEFAULT 0,  ngayud timestamp DEFAULT now(),  CONSTRAINT pk_bask_tongket PRIMARY KEY (maql) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("CREATE TABLE "+xxx+".BAVV_CHUNG(MAQL NUMERIC(22,0), LYDO TEXT, HB_BENHLY TEXT, HB_BANTHAN TEXT, HB_GIADINH TEXT, KB_TOANTHAN TEXT, KB_BOPHAN TEXT, KB_TOMTAT TEXT, KB_XULI TEXT, KB_CHUY TEXT, SOBO TEXT, PHANBIET TEXT, USERID NUMERIC, NGAYUD timestamp DEFAULT now(),CONSTRAINT PK_BAVV_CHUNG PRIMARY KEY (MAQL) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("CREATE TABLE "+xxx+".BAVV_DAUSINHTON(MAQL NUMERIC(22,0),MACH NUMERIC(3,0) DEFAULT 0,NHIETDO NUMERIC(5,2) DEFAULT 0,HUYETAP VARCHAR(7), NHIPTHO NUMERIC(3,0) DEFAULT 0, CANNANG NUMERIC(7,2) DEFAULT 0, CHIEUCAO NUMERIC(5,0) DEFAULT 0,CONSTRAINT PK_BAVV_DAUSINHTON PRIMARY KEY (MAQL) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("CREATE TABLE "+xxx+".STTNGAY(NGAY timestamp,SO numeric(5,0),CONSTRAINT PK_BAVV_STTNGAY PRIMARY KEY (NGAY) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("CREATE TABLE "+xxx+".BAVV_TMH(MAQL numeric(22,0),TAI text,MUI text,HONG text,KHAM text,IMAGE1 bytea,IMAGE2 bytea,IMAGE3 bytea,IMAGE4 bytea,CONSTRAINT PK_BAVV_TMH PRIMARY KEY (MAQL) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("CREATE TABLE "+xxx+".BAVV_RHM(MAQL numeric(22,0),IMAGE bytea,NHANXET text,CHANDOAN text,CONSTRAINT PK_BAVV_RHM PRIMARY KEY (MAQL) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("CREATE TABLE "+xxx+".BAVV_MAT(MAQL numeric(22,0),KB_MAT text,TLKK_MP text,TLKK_MT text,TLCK_MP text,TLCK_MT text,NA_MP text,NA_MT text,TT_MP text,TT_MT text,CONSTRAINT PK_BAVV_MAT PRIMARY KEY (MAQL) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("CREATE TABLE "+xxx+".BAVV_TMHCT(MAQL numeric(22,0),STT text,TAIP text,TAIT text,CONSTRAINT PK_BAVV_TMHCT PRIMARY KEY (MAQL) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("create table "+xxx+".ba_locmaull(ID numeric(22,0),IDTHUCHIEN numeric(22,0),NGAYBD timestamp,CANTLOC numeric(7,2),RUTNUOC numeric(5,0),DICHVAMAU numeric(5,0),CANSLOC numeric(7,2),FAV numeric(1,0),TTMD numeric(1,0),MTCT numeric(1,0),TMDD numeric(1,0),HEPARIN numeric(1,0),TLPT numeric(1,0),LIEUDAU text,DUYTRI text,TONGLIEU text,LIENTUC numeric(1,0),CACHQUANG numeric(1,0),KHAC text,NGAYKT timestamp,MANGLOC text,NHANHIEU text,DIENTICH text,HESO text,BAOQUAN text,LANDUNG numeric(5,0),MABS VARCHAR(4),YTA VARCHAR(4),USERID  numeric(5,0),NGAYUD timestamp DEFAULT sysdate,CONSTRAINT PK_BAVV_LOCMAULL PRIMARY KEY (ID) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("create table "+xxx+".ba_locmauct(ID numeric(22,0),STT numeric(5,0),NGAY DATE,MACH numeric(3,0),HUYETAP VARCHAR(7),NHIETDO numeric(5,2),NHIPTHO numeric(3,0),TOCDO numeric(5,0),DM text,TM text,SIEULOC numeric(7,0),TAIBIEN text,THUOC text,MABS VARCHAR(4),YTA VARCHAR(4),CONSTRAINT PK_BAVV_LOCMAUCT PRIMARY KEY (ID) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("create table "+xxx+".ba_thuchien(ID numeric(22,0),MABN VARCHAR(10),MAQL numeric(22,0),IDKHOA numeric(22,0),makp varchar(3),PHONG VARCHAR(10),GIUONG VARCHAR(20),CHANDOAN text,CONSTRAINT PK_BAVV_THUCHIEN PRIMARY KEY (ID) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("create table "+xxx+".ba_scan(ID numeric(22,0),STT numeric(5,0),NGAY timestamp,NHOM numeric(1,0) DEFAULT 0,LOAI numeric(3,0) DEFAULT 0,TEN text,IMAGE bytea,CONSTRAINT PK_BA_SCAN PRIMARY KEY (ID) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("create table "+xxx+".ba_chung(ID numeric(22,0),IDTHUCHIEN numeric(22,0),LYDO text,LANTHU numeric(3,0) DEFAULT 0,HB_BENHLY text,HB_BANTHAN text,HB_GIADINH text,KB_TOANTHAN text,KB_NGOAI text,KB_TUANHOAN text,KB_HOHAP text,KB_TIEUHOA text,KB_THAN text,KB_THANKINH text,KB_CO text,KB_TMH text,KB_RHM text,KB_MAT text,KB_NOITIET text,KB_KHAC text,KB_TOMTAT text,PHANBIET text,TIENLUONG text,DIEUTRI text,BSLBAN VARCHAR(4),TK_BENHLY text,TK_TOMTAT text,TK_PHUONGPHAP text,TK_TINHTRANG text,TK_DIEUTRI text,NGUOIGIAO VARCHAR(4),NGUOINHAN VARCHAR(4),MABS VARCHAR(4),USERID numeric(5,0),NGAYUD timestamp DEFAULT sysdate,CONSTRAINT PK_BA_CHUNG PRIMARY KEY (ID) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("create table "+xxx+".ba_kbdausinhton(ID numeric(22,0),MACH numeric(3,0) DEFAULT 0,NHIETDO numeric(5,2) DEFAULT 0,HUYETAP VARCHAR(7),NHIPTHO numeric(3,0) DEFAULT 0,CANNANG numeric(7,2) DEFAULT 0,CHIEUCAO numeric(5,0) DEFAULT 0,CONSTRAINT PK_BA_KBDAUSINHTON PRIMARY KEY (ID) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("create table "+xxx+".ba_tkhoso(ID numeric(22,0),MA numeric(3,0),KHAC text,SO numeric(5,0) DEFAULT 0,CONSTRAINT PK_BA_TKHOSO PRIMARY KEY (ID) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("create table "+xxx+".ba_dieutri(ID numeric(22,0),IDTHUCHIEN numeric(22,0),SOPHIEU numeric(7,0) DEFAULT 0,NGAY timestamp,DIENBIEN text,YLENH text,IDYLENH numeric(22,0),CHEDOAN numeric(3,0),MABS VARCHAR(4),LOAI numeric(1,0) DEFAULT 0,SANKHOA numeric(22,0) DEFAULT 0,DONE numeric(1,0) DEFAULT 0,USERID numeric(5,0),NGAYUD timestamp DEFAULT now(),CONSTRAINT PK_BA_DIEUTRI PRIMARY KEY (ID) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("create table "+xxx+".ba_dieutrict(ID numeric(22,0),STT numeric(3,0),LOAI numeric(2,0),NOIDUNG text,GHICHU text,THUCHIEN text,CONSTRAINT PK_BA_DIEUTRICT PRIMARY KEY (ID,STT) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("create table "+xxx+".ba_chamsoc(ID numeric(22,0),IDTHUCHIEN numeric(22,0),NGAY timestamp,SOPHIEU numeric(7,0) DEFAULT 0,MACH numeric(3,0) DEFAULT 0,HUYETAP VARCHAR(7),NHIETDO numeric(5,2) DEFAULT 0,NHIPTHO numeric(3,0) DEFAULT 0,DIENBIEN text,YLENH text,YTA VARCHAR(4),USERID numeric(5,0),IDDIEUTRI numeric(22,0) DEFAULT 0,NGAYUD timestamp DEFAULT sysdate,CONSTRAINT PK_BA_CHAMSOC PRIMARY KEY (ID) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("create table "+xxx+".ba_chamsocct(ID numeric(22,0),STT numeric(3,0),LOAI numeric(2,0),NOIDUNG text,GHICHU text,THUCHIEN text,CONSTRAINT PK_BA_CHAMSOCCT PRIMARY KEY (ID,STT) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("create table "+xxx+".ba_linhmau(ID numeric(22,0),IDTHUCHIEN numeric(22,0),SOPHIEU VARCHAR(10),NGAYLINH timestamp,DONVI text,CHEPHAM text,NHOMMAU numeric(1,0) DEFAULT 0,LANTHU numeric(3,0) DEFAULT 0,NGUOILINH VARCHAR(4),BSDT VARCHAR(4),PHONGPHAT text,BVPHAT text,DVPHAT text,NGAYPHAT DATE,NGUOIPHAT VARCHAR(4),TRUONGKHOA VARCHAR(4),DONE numeric(1,0) DEFAULT 0,USERID numeric(5,0) DEFAULT 0,NGAYUD timestamp DEFAULT now(),CONSTRAINT PK_BA_LINHMAU PRIMARY KEY (ID) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("create table "+xxx+".ba_linhmauct(ID numeric(22,0),STT numeric(3,0),CHEPHAM text,MASO VARCHAR(10),NHOMMAU numeric(1,0) DEFAULT 0,CONSTRAINT PK_BA_LINHMAUCT PRIMARY KEY (ID,STT) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("create table "+xxx+".ba_truyenmau(ID numeric(22,0),IDTHUCHIEN numeric(22,0),NGAY timestamp,CHEPHAM text,MASO VARCHAR(10),NGAYLAY timestamp,HANDUNG timestamp,SOLUONG text,NOILAM text,KYTHUAT text,SINHPHAM text,HBSAG numeric(1,0),HCV numeric(1,0),GIANGMAI numeric(1,0),SOTRET numeric(1,0),NGUOICHO numeric(1,0),BENHNHAN numeric(1,0),ONG1 text,ONG2 text,TRUONGKHOA VARCHAR(4),KTV1 VARCHAR(4),KTV2 VARCHAR(4),CHEPHAMTR text,MASOTR VARCHAR(10),HANDUNGTR timestamp,LANTHU numeric(3,0),BSCD VARCHAR(4),NGUOICHOTR numeric(1,0) DEFAULT 0,BENHNHANTR numeric(1,0) DEFAULT 0,TAI text,SOLUONGTR text,BATDAU timestamp,KETTHUC timestamp,SOLUONGTHUC text,SACMAT text,NHIPTHO numeric(3,0) DEFAULT 0,NHIETDO numeric(5,2) DEFAULT 0,HUYETAP VARCHAR(7),MACH numeric(3,0) DEFAULT 0,DIENBIEN text,BSTH VARCHAR(4),YTA VARCHAR(4),IDLINH numeric(22,0) DEFAULT 0,USERID numeric(5,0) DEFAULT 0,NGAYUD timestamp DEFAULT sysdate,CONSTRAINT PK_BA_TRUYENMAU PRIMARY KEY (ID) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("create table "+xxx+".ba_truyenmauct(ID numeric(22,0),STT numeric(3,0),NGAY timestamp,SACMAT text,NHIPTHO numeric(3,0) DEFAULT 0,NHIETDO numeric(5,2) DEFAULT 0,HUYETAP VARCHAR(7),MACH numeric(3,0) DEFAULT 0,DIENBIEN text,CONSTRAINT PK_BA_TRUYENMAUCT PRIMARY KEY (ID,STT) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("create table "+xxx+".ba_truyendich(ID numeric(22,0),IDTHUCHIEN numeric(22,0),NGAY timestamp,USERID numeric(5,0),NGAYUD timestamp DEFAULT now(),CONSTRAINT PK_BA_TRUYENDICH PRIMARY KEY (ID) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("create table "+xxx+".ba_truyendichct(ID numeric(22,0),STT numeric(3,0),TEN text,SOLUONG numeric(7,2) DEFAULT 0,LOSX VARCHAR(20),TOCDO text DEFAULT 0,BATDAU timestamp,KETTHUC timestamp,BSCD VARCHAR(4),YTA VARCHAR(4),GHICHU text,USERID numeric(5,0),NGAYUD timestamp DEFAULT now(),CONSTRAINT PK_BA_TRUYENDICHCT PRIMARY KEY (ID,STT) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("create table "+xxx+".ba_puthuoc(ID numeric(22,0),IDTHUCHIEN numeric(22,0),NGAY timestamp,TEN text,PHUONGPHAP text,BSCD VARCHAR(4),NGUOITHU VARCHAR(4),BSDOC VARCHAR(4),KETQUA text,USERID numeric(5,0),NGAYUD timestamp DEFAULT now(),CONSTRAINT PK_BA_PUTHUOC PRIMARY KEY (ID) USING INDEX TABLESPACE medi_index) WITH OIDS TABLESPACE medi_data;");
            m.execute_data("CREATE TABLE "+user+".dmdangkt(id numeric(2) NOT NULL DEFAULT 0,ten text,CONSTRAINT pk_dmdangkt PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH OIDS;ALTER TABLE medibv.dmdangkt OWNER TO medisoft;");
            m.execute_data("CREATE TABLE "+user+".dmmucdokt(id numeric(2) NOT NULL DEFAULT 0,ten text,CONSTRAINT pk_dmmucdokt PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH OIDS;ALTER TABLE medibv.dmmucdokt OWNER TO medisoft;");
            m.execute_data("CREATE TABLE "+user+".khuyettat(maql numeric(22,0) NOT NULL DEFAULT 0,mabn varchar(10),ngay timestamp,id_dang numeric(2),id_mucdo numeric(2),chandoan text,CONSTRAINT pk_khuyettat PRIMARY KEY (maql) USING INDEX TABLESPACE medi_index) WITH OIDS;ALTER TABLE medibv.khuyettat OWNER TO medisoft;");
            m.execute_data("create table "+user+".phanungthuoc_adr(id numeric(22),mabn varchar(10),maql numeric(22),mavaovien numeric(22),msbcdonvi varchar(20),msbctt varchar(20),cannang numeric(7,2) DEFAULT 0,chieucao numeric(5) DEFAULT 0,ngayphanung timestamp,motaphanung text,chandoandieutri text,taisudungthuoc text,trieuchungcu numeric(1) default 0,thuocsudungdongthoi text,benhsulienquan text,userid numeric(5),ngayud timestamp default now(),ngaybaocao timestamp,dangbaocao numeric(1) default 0,CONSTRAINT pk_phanungthuoc_adr PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH OIDS;ALTER TABLE medibv.phanungthuoc_adr OWNER TO medisoft;");
            m.execute_data("create table "+user+".thuocnghingo_adr(id numeric(22),stt numeric(4),mabd numeric(7),lieudungmotlan text,solantrongngay numeric(2),ngaybatdau timestamp,ngayketthuc timestamp,losx varchar(20),userid numeric(5),ngayud timestamp default now(),CONSTRAINT pk_thuocnghingo_adr PRIMARY KEY (id,stt) USING INDEX TABLESPACE medi_index) WITH OIDS;ALTER TABLE medibv.thuocnghingo_adr OWNER TO medisoft;");
            m.execute_data("create table "+user+".xutri_adr(id numeric(22),ngungdungthuoc text,ngung_tientrien numeric(1) default 0,ngung_dieutri numeric(1) default 0,sudungthuockhac text,sudung_tientrien numeric(1) default 0,sudung_dieutri numeric(1) default 0,ketquaxutriADR numeric(7),bsbinhluan text,thamdinhADR_dvyte numeric(1) default 0,thamdinhADR_chuyengia numeric(1) default 0,ykienchuyengia text,userid numeric(5),ngayud timestamp default now(),CONSTRAINT pk_xutri_adr PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH OIDS;ALTER TABLE medibv.xutri_adr OWNER TO medisoft;");
            m.execute_data("create table "+user+".dmkq_adr(id numeric(7),ten text,CONSTRAINT pk_dmkq_adr PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH OIDS;ALTER TABLE medibv.dmkq_adr OWNER TO medisoft;");
            m.execute_data("create table "+user+".bavv_mat(maql numeric(22),ledao_mp text,mimat_mp text,thmathot_mp text,giacmac_mp text,cungmac_mp text,tienphong_mp text,mongmat_mp text,dongtupxa_mp text,thuytinhthe_mp text,thuytinhdich_mp text,soianhdongtu_mp text,thnhancau_mp text,homat_mp text,daymat_mp text,ledao_mt text,mimat_mt text,thmathot_mt text,giacmac_mt text,cungmac_mt text,tienphong_mt text,mongmat_mt text,dongtupxa_mt text,thuytinhthe_mt text,thuytinhdich_mt text,soianhdongtu_mt text,thnhancau_mt text,homat_mt text,daymat_mt text,CONSTRAINT pk_bavv_mat PRIMARY KEY (maql) USING INDEX TABLESPACE medi_index) WITH OIDS;ALTER TABLE medibv.bavv_mat OWNER TO medisoft;");
            m.execute_data("alter table "+xxx+".bavv_tmhct drop CONSTRAINT pk_bavv_tmhct;");
            m.execute_data("alter table "+xxx+".bavv_tmhct add CONSTRAINT pk_bavv_tmhct PRIMARY KEY (maql,stt) USING INDEX TABLESPACE medi_index;");
            m.execute_data("alter table "+xxx+".pttt add bienchung numeric(1);");
            m.execute_data("alter table "+xxx+".bavv_mat add hinh bytea;");
            m.execute_data("alter table "+xxx+".bavv_mat add nhanxet text;");
            m.execute_data("alter table "+xxx+".bavv_mat add chandoan text;");
            m.execute_data("alter table "+user+".khuyettat add ghichu text;");
            m.execute_data("alter table "+user+".khuyettat add CONSTRAINT fk_khuyettat_dmdangkt FOREIGN KEY (id_dang) REFERENCES medibv.dmdangkt(id) MATCH SIMPLE ON UPDATE NO ACTION ON DELETE SET NULL;");
            m.execute_data("alter table "+user+".khuyettat add CONSTRAINT fk_khuyettat_dmmucdokt FOREIGN KEY (id_mucdo) REFERENCES medibv.dmmucdokt(id) MATCH SIMPLE ON UPDATE NO ACTION ON DELETE SET NULL;");
            m.execute_data("alter table "+xxx+".ba_thuchien add CONSTRAINT fk_ba_thuchien_btdbn FOREIGN KEY (mabn) REFERENCES medibv.btdbn (mabn) MATCH SIMPLE ON UPDATE NO ACTION ON DELETE SET NULL;");
            m.execute_data("alter table "+user+".khuyettat add CONSTRAINT fk_khuyettat_btdbn FOREIGN KEY (mabn) REFERENCES medibv.btdbn (mabn) MATCH SIMPLE ON UPDATE NO ACTION ON DELETE SET NULL;");
            m.execute_data("alter table "+user+".phanungthuoc_adr add CONSTRAINT fk_phanungthuoc_adr_btdbn FOREIGN KEY (mabn) REFERENCES medibv.btdbn (mabn) MATCH SIMPLE ON UPDATE NO ACTION ON DELETE SET NULL;");
            m.execute_data("alter table "+user+".d_dmnx add column hide numeric(1) default 0;");
            m.execute_data("alter table "+xxx+".v_ttrvll add column thua numeric(15,4) DEFAULT 0;");
            m.execute_data("CREATE TABLE "+user+".benhantc(mabn varchar(10) NOT NULL,maql numeric(30) NOT NULL, mavaovien numeric(30), ngay timestamp NOT NULL, benh text,diung text, phanungthuoc text, dongkinh text, ungthu text, benhbathang text, benhmotnam text, thai text, vacxin text, nhanxet text, ngayud timestamp DEFAULT now(),userid text) WITHOUT OIDS;ALTER TABLE "+user+".benhantc OWNER TO medisoft;");
            m.execute_data("CREATE TABLE "+xxx+".BA_VANCHUYEN(ID numeric(22,0), IDTHUCHIEN numeric(22,0), NGAY timestamp, KHOADEN text, NGAYVV timestamp, NGAYRK timestamp, NGAYVK timestamp, M_CC numeric(5,0), HA_CC varchar(7), NT_CC numeric(5,0), T_CC numeric(7,2), TG_CC numeric(1,0), M_VC numeric(5,0), HA_VC varchar(7), NT_VC numeric(5,0), T_VC numeric(7,2), TG_VC numeric(1,0), M_KD numeric(5,0), HA_KD varchar(7), NT_KD numeric(5,0), T_KD numeric(7,2), TG_KD numeric(1,0), BS_CC varchar(4), DD_CC varchar(4), BS_VC varchar(4), DD_VC varchar(4), BS_KD varchar(4), DD_KD varchar(4), KHAC text, LUC timestamp, VEDENKHOA timestamp, THANGMAY numeric(3,0), PHONGMO numeric(3,0), NHANBENH numeric(3,0), USERID numeric(5,0), NGAYUD timestamp DEFAULT now(),CONSTRAINT pk_ba_vanchuyen PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH OIDS; ALTER TABLE "+xxx+".ba_vanchuyen OWNER TO medisoft;");
            m.execute_data("CREATE TABLE "+xxx+".BA_VANCHUYENCT(ID numeric(22,0),STT numeric(3,0),CC numeric(1,0) DEFAULT 0,VC numeric(1,0) DEFAULT 0,KD numeric(1,0) DEFAULT 0,CONSTRAINT pk_ba_vanchuyenct PRIMARY KEY (id,stt) USING INDEX TABLESPACE medi_index) WITH OIDS; ALTER TABLE "+xxx+".ba_vanchuyenct OWNER TO medisoft;");
            m.execute_data("CREATE TABLE "+xxx+".BA_HOICHANCC(ID numeric(22,0), IDTHUCHIEN numeric(22,0), NGAY timestamp, NGAYMO timestamp, MAMAU VARCHAR(10),TENPT text, NHOMMAU numeric(1,0), RH numeric(1,0) DEFAULT 0, MAU numeric(7,0) DEFAULT 0, XNKHAC text, PTDUTRU VARCHAR(4), PTCHINH VARCHAR(4), PTPHU VARCHAR(4),PHUONGPHAP numeric(2,0) DEFAULT 0, TUTHE text, YKIEN text, BSTRUONGK VARCHAR(4), BSTRUONG VARCHAR(4), PTV VARCHAR(4), TIENSU text, TIM text, PHOI text, TIENLUONG text, KHAC text, COTSONG text, THANKINH text, ANLANCUOI text, ASA VARCHAR(3), GLODMANN VARCHAR(3), MALLAMPATI VARCHAR(3),BSGAYME VARCHAR(4),BSTRUONGGMHS VARCHAR(4),USERID numeric(5,0), NGAYUD timestamp DEFAULT now(),CONSTRAINT pk_BA_HOICHANCC PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH OIDS; ALTER TABLE "+xxx+".BA_HOICHANCC OWNER TO medisoft;");
            m.execute_data("CREATE TABLE "+xxx+".BA_KIEMSOATCC(ID numeric(22,0),IDTHUCHIEN numeric(22,0),NGAY timestamp,NHANXET text,DDTRUONG VARCHAR(4),DDPMO VARCHAR(4),DDPHUTRACH VARCHAR(4),USERID numeric(5,0),NGAYUD timestamp DEFAULT now(),CONSTRAINT pk_BA_KIEMSOATCC PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH OIDS; ALTER TABLE "+xxx+".BA_KIEMSOATCC OWNER TO medisoft;");
            m.execute_data("CREATE TABLE "+xxx+".BA_KIEMSOATCCCT(ID numeric(22,0),MA numeric(3,0),COKHONG numeric(1,0) DEFAULT 0,GHICHU text,CONSTRAINT pk_BA_KIEMSOATCCCT PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH OIDS; ALTER TABLE "+xxx+".BA_KIEMSOATCCCT OWNER TO medisoft;");
            m.execute_data("CREATE TABLE "+xxx+".BA_HOICHAN(ID numeric(22,0), IDTHUCHIEN numeric(22,0), NGAY timestamp, NGAYMO timestamp, MAMAU VARCHAR(10), TENPT text, THOIGIAN text, SONDE numeric(1,0) DEFAULT 0, NHOMMAU numeric(1,0), RH numeric(1,0) DEFAULT 0, MAU numeric(7,0) DEFAULT 0, XNKHAC text, PTDUTRU VARCHAR(4), PTCHINH VARCHAR(4), PTPHU VARCHAR(4), PHUONGPHAP numeric(2,0) DEFAULT 0, TUTHE text, XQ numeric(1,0) DEFAULT 0, DUNGCU text, KHAC text, YKIEN text, GIAMDOC VARCHAR(4), KHTH VARCHAR(4), GAYME VARCHAR(4), BSTRUONGK VARCHAR(4), PTV VARCHAR(4), USERID numeric(5,0), NGAYUD timestamp DEFAULT now(),CONSTRAINT pk_BA_HOICHAN PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH OIDS; ALTER TABLE "+xxx+".BA_HOICHAN OWNER TO medisoft;");
            m.execute_data("CREATE TABLE "+xxx+".BA_HOICHANXN(ID numeric(22,0),MA numeric(3,0),TINHTRANG numeric(7,2) DEFAULT 0,CONSTRAINT pk_BA_HOICHANXN PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH OIDS; ALTER TABLE "+xxx+".BA_HOICHANXN OWNER TO medisoft;");
            m.execute_data("CREATE TABLE "+xxx+".BA_KHAMTIENME(ID numeric(22,0), NGAY timestamp, MO text, METE numeric(1,0) DEFAULT 0, TAIBIEN numeric(1,0) DEFAULT 0, TRUYENMAU numeric(1,0) DEFAULT 0, DIUNG text, BIEUHIEN text, THUOCLA numeric(1,0) DEFAULT 0, RUOU numeric(1,0) DEFAULT 0, MATUY numeric(1,0) DEFAULT 0, CAOHA numeric(1,0) DEFAULT 0, THATNGUC numeric(1,0) DEFAULT 0, NMCT numeric(1,0) DEFAULT 0, SUYTIM numeric(1,0) DEFAULT 0, TIMBAMSINH numeric(1,0) DEFAULT 0, LAO numeric(1,0) DEFAULT 0, PHEQUAN numeric(1,0) DEFAULT 0, HORAMAU numeric(1,0) DEFAULT 0, COPD numeric(1,0) DEFAULT 0, HH_KHAC numeric(1,0) DEFAULT 0, TAMTHAN numeric(1,0) DEFAULT 0, DONGKINH numeric(1,0) DEFAULT 0, TBMMN numeric(1,0) DEFAULT 0, BUOUCO numeric(1,0) DEFAULT 0, MAUKDONG numeric(1,0) DEFAULT 0, TIEUDUONG numeric(1,0) DEFAULT 0, HETHONG numeric(1,0) DEFAULT 0, TK_KHAC numeric(1,0) DEFAULT 0, CAUTHAN numeric(1,0) DEFAULT 0, SUYTHAN numeric(1,0) DEFAULT 0, SOITHAN numeric(1,0) DEFAULT 0, TN_KHAC numeric(1,0) DEFAULT 0, VANGDA numeric(1,0) DEFAULT 0, VIEMGAN numeric(1,0) DEFAULT 0, TIEUHOA numeric(1,0) DEFAULT 0, THUONGVI numeric(1,0) DEFAULT 0, TH_KHAC numeric(1,0) DEFAULT 0, GIADINH text, CHITIET text, MAP numeric(1,0) DEFAULT 0, PHU numeric(1,0) DEFAULT 0, HONG numeric(1,0) DEFAULT 0, NHOT numeric(1,0) DEFAULT 0, YEU numeric(1,0) DEFAULT 0, KHOTHO numeric(1,0) DEFAULT 0, GLASGOW numeric(5,0) DEFAULT 0, MACH numeric(3,0) DEFAULT 0, HUYETAP varchar(7), NHIETDO numeric(5,2) DEFAULT 0, NHIPTHO numeric(3,0) DEFAULT 0, CANNANG numeric(7,2) DEFAULT 0, CHIEUCAO numeric(5,0) DEFAULT 0, HANCHE numeric(1,0) DEFAULT 0, CONGAN numeric(1,0) DEFAULT 0, LUOITO numeric(1,0) DEFAULT 0, KHOIU numeric(1,0) DEFAULT 0, GIAP numeric(1,0) DEFAULT 0, CUNGHAM numeric(1,0) DEFAULT 0, SEO numeric(1,0) DEFAULT 0, RANGGIA numeric(1,0) DEFAULT 0, TL_KHAC text, TIMMACH numeric(1,0) DEFAULT 0, HOHAP numeric(1,0) DEFAULT 0, THAN numeric(1,0) DEFAULT 0, K_TIEUHOA numeric(1,0) DEFAULT 0, K_KHAC numeric(1,0) DEFAULT 0, GU numeric(1,0) DEFAULT 0, CUNGCOTSONG numeric(1,0) DEFAULT 0, COTSONGCU numeric(1,0) DEFAULT 0, CANLAMSANG text, DIEUTRI text, DENGHI text, ASA varchar(3), GLODMANN varchar(3), MALLAMPATI varchar(3), DUKIEN text, THUTHUAT text, KETLUAN text, MABS varchar(4), TINHMACH text, TM_BT numeric(1,0) DEFAULT 0, TM_CHA numeric(1,0) DEFAULT 0, TM_DTN numeric(1,0) DEFAULT 0, TM_LN numeric(1,0) DEFAULT 0, TM_KHAC text, HH_BT numeric(1,0) DEFAULT 0, HH_COPD numeric(1,0) DEFAULT 0, HH_SUYEN numeric(1,0) DEFAULT 0, K_HH_KHAC text, NT_BT numeric(1,0) DEFAULT 0, NT_BG numeric(1,0) DEFAULT 0, NT_TD numeric(1,0) DEFAULT 0, NT_KHAC text, TK_BT numeric(1,0) DEFAULT 0, TK_YEU numeric(1,0) DEFAULT 0, K_TK_KHAC text,CS_BT numeric(1,0) DEFAULT 0,CS_KHAC text,CONSTRAINT pk_BA_KHAMTIENME PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH OIDS; ALTER TABLE "+xxx+".BA_KHAMTIENME OWNER TO medisoft;");
            m.execute_data("CREATE TABLE "+xxx+".BA_KIEMSOAT(ID numeric(22,0), IDTHUCHIEN numeric(22,0), NGAY timestamp, THUOC text, TIEMBAP numeric(1,0) DEFAULT 0, TIEMTM numeric(1,0) DEFAULT 0, MACH numeric(3,0) DEFAULT 0, HUYETAP varchar(7), NHIETDO numeric(5,2) DEFAULT 0, NHIPTHO numeric(3,0) DEFAULT 0, TRIGIAC text, NHANXET text, DDTRUONG varchar(4), DDPMO varchar(4), DDPHUTRACH varchar(4), USERID numeric(5,0), NGAYUD timestamp DEFAULT now(),CONSTRAINT pk_BA_KIEMSOAT PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH OIDS; ALTER TABLE "+xxx+".BA_KIEMSOAT OWNER TO medisoft;");
            m.execute_data("CREATE TABLE "+xxx+".BA_KIEMSOATCT(ID numeric(22,0), MA numeric(3,0), COKHONG numeric(1,0) DEFAULT 0, GHICHU text,CONSTRAINT pk_BA_KIEMSOATCT PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH OIDS; ALTER TABLE "+xxx+".BA_KIEMSOATCT OWNER TO medisoft;");
            m.execute_data("CREATE TABLE "+xxx+".BA_HOICHANTHUOC(ID numeric(22,0), IDTHUCHIEN numeric(22,0), NGAY timestamp, TU timestamp, DEN timestamp, MABS varchar(4), THUKY varchar(4), THANHVIEN text, TINHTRANG numeric(1,0) DEFAULT 0, GAN text, SGOT text, SGPT text, URE text, CREATIMIN text, ION text, CTM text, TPTNT text, XQ text, VIKHUAN text, KSD text, THUOC text, THAYTHE text, LYDO text, USERID numeric(5,0) DEFAULT 0, NGAYUD timestamp DEFAULT now(),CONSTRAINT pk_BA_HOICHANTHUOC PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH OIDS; ALTER TABLE "+xxx+".BA_HOICHANTHUOC OWNER TO medisoft;");
            m.execute_data("CREATE TABLE "+xxx+".BA_DANHGIA1(ID numeric(22,0), IDTHUCHIEN numeric(22,0), NGAY timestamp, THUOC text, THUOC_K numeric(1,0) DEFAULT 0, CANNANG numeric(7,2) DEFAULT 0, CHIEUCAO numeric(5,0) DEFAULT 0, MACH numeric(3,0) DEFAULT 0, NHIETDO numeric(5,2) DEFAULT 0, HUYETAP varchar(7), NHIPTHO numeric(3,0) DEFAULT 0, DIUNG text, DIUNG_K numeric(1,0) DEFAULT 0, TM text, TM_K numeric(1,0) DEFAULT 0, TM_1 numeric(1,0) DEFAULT 0, TM_2 numeric(1,0) DEFAULT 0, TM_3 numeric(1,0) DEFAULT 0, TM_4 numeric(1,0) DEFAULT 0, TM_5 numeric(1,0) DEFAULT 0, TM_6 numeric(1,0) DEFAULT 0, TM_7 numeric(1,0) DEFAULT 0, HH text, HH_K numeric(1,0) DEFAULT 0, HH_1 numeric(1,0) DEFAULT 0, HH_2 numeric(1,0) DEFAULT 0, HH_3 numeric(1,0) DEFAULT 0, HH_4 numeric(1,0) DEFAULT 0, HH_5 numeric(1,0) DEFAULT 0, HH_6 numeric(1,0) DEFAULT 0, HH_7 numeric(1,0) DEFAULT 0, THAN text, THAN_K numeric(1,0) DEFAULT 0, THAN_1 numeric(1,0) DEFAULT 0, THAN_2 numeric(1,0) DEFAULT 0, THAN_3 numeric(1,0) DEFAULT 0, THAN_4 numeric(1,0) DEFAULT 0,CONSTRAINT pk_BA_DANHGIA1 PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH OIDS; ALTER TABLE "+xxx+".BA_DANHGIA1 OWNER TO medisoft;");
            m.execute_data("CREATE TABLE "+xxx+".BA_DANHGIA2 (ID2 numeric(22,0), NOITIET text, NOITIET_K numeric(1,0) DEFAULT 0, NOITIET_1 numeric(1,0) DEFAULT 0, NOITIET_2 numeric(1,0) DEFAULT 0, NOITIET_3 numeric(1,0) DEFAULT 0, NOITIET_4 numeric(1,0) DEFAULT 0, NOITIET_5 numeric(1,0) DEFAULT 0, NOITIET_6 numeric(1,0) DEFAULT 0, TIEUHOA text, TIEUHOA_K numeric(1,0) DEFAULT 0, TIEUHOA_1 numeric(1,0) DEFAULT 0, TIEUHOA_2 numeric(1,0) DEFAULT 0, TIEUHOA_3 numeric(1,0) DEFAULT 0, TIEUHOA_4 numeric(1,0) DEFAULT 0, TIEUHOA_5 numeric(1,0) DEFAULT 0, TIEUHOA_6 numeric(1,0) DEFAULT 0, TIEUHOA_7 numeric(1,0) DEFAULT 0, THANKINH text, THANKINH_K numeric(1,0) DEFAULT 0, THANKINH_1 numeric(1,0) DEFAULT 0, THANKINH_2 numeric(1,0) DEFAULT 0, THANKINH_3 numeric(1,0) DEFAULT 0, THANKINH_4 numeric(1,0) DEFAULT 0, HUYETHOC text, HUYETHOC_K numeric(1,0) DEFAULT 0, HUYETHOC_1 numeric(1,0) DEFAULT 0, HUYETHOC_2 numeric(1,0) DEFAULT 0, HUYETHOC_3 numeric(1,0) DEFAULT 0,CONSTRAINT pk_BA_DANHGIA2 PRIMARY KEY (id2) USING INDEX TABLESPACE medi_index) WITH OIDS; ALTER TABLE "+xxx+".BA_DANHGIA2 OWNER TO medisoft;");
            m.execute_data("CREATE TABLE "+xxx+".BA_DANHGIA3(ID3 numeric(22,0), LAMSANG text, KHAM text, KHAM_1 numeric(1,0) DEFAULT 0, KHAM_2 numeric(1,0) DEFAULT 0, KHAM_3 numeric(1,0) DEFAULT 0, KHAM_4 numeric(1,0) DEFAULT 0, KHAM_5 numeric(1,0) DEFAULT 0, XN text, CLS text, LUUY text, ASA varchar(1), THAOLUAN_1 numeric(1,0) DEFAULT 0, THAOLUAN_2 numeric(1,0) DEFAULT 0, THAOLUAN_3 numeric(1,0) DEFAULT 0, THAOLUAN_4 numeric(1,0) DEFAULT 0, THAOLUAN_5 numeric(1,0) DEFAULT 0, KEHOACH text, MABS varchar(4), USERID numeric(5,0), NGAYUD timestamp DEFAULT now(),CONSTRAINT pk_BA_DANHGIA3 PRIMARY KEY (id3) USING INDEX TABLESPACE medi_index) WITH OIDS; ALTER TABLE "+xxx+".BA_DANHGIA3 OWNER TO medisoft;");
            m.execute_data("CREATE TABLE "+xxx+".BA_CAMDOAN(ID numeric(22,0), IDTHUCHIEN numeric(22,0), NGAY DATE, HOTEN text, TUOI numeric(3,0) DEFAULT 0, PHAI text, DANTOC text, NGHENGHIEP text, NGOAIKIEU text, DIACHI text, NOILAM text, NGUOINHA text, DONGY numeric(1,0) DEFAULT 0, IMAGE bytea, GHICHU text, USERID numeric(5,0) DEFAULT 0, NGAYUD timestamp DEFAULT now(),CONSTRAINT pk_BA_CAMDOAN PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH OIDS; ALTER TABLE "+xxx+".BA_CAMDOAN OWNER TO medisoft;");
            m.execute_data("CREATE TABLE "+xxx+".BA_GIAONHAN (ID numeric(22,0), IDTHUCHIEN numeric(22,0), NGAY timestamp, TRIGIAC text, MACH numeric(3,0) DEFAULT 0, NHIETDO numeric(5,2) DEFAULT 0, HUYETAP varchar(7), NHIPTHO numeric(3,0) DEFAULT 0, CANNANG numeric(7,2) DEFAULT 0, SPO2 numeric(7,2) DEFAULT 0, CAMTAY text, YTA varchar(4), USERID numeric(5,0), NGAYUD timestamp DEFAULT now(),CONSTRAINT pk_BA_GIAONHAN PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH OIDS; ALTER TABLE "+xxx+".BA_GIAONHAN OWNER TO medisoft;");
            m.execute_data("CREATE TABLE "+xxx+".BA_GIAONHANCT(ID numeric(22,0), STT numeric(3,0), SOLUONG numeric(3,0), LOAI text,CONSTRAINT pk_BA_GIAONHANCT PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH OIDS; ALTER TABLE "+xxx+".BA_GIAONHANCT OWNER TO medisoft;");
            m.execute_data("CREATE TABLE "+xxx+".BA_SOKET(ID numeric(22,0), IDTHUCHIEN numeric(22,0), NGAY timestamp, DIENBIEN text, CLS text, DIEUTRI text, KETQUA text, TIENLUONG text, BSTRUONG varchar(4), MABS varchar(4), USERID numeric(5,0),NGAYUD timestamp DEFAULT now(),CONSTRAINT pk_BA_SOKET PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH OIDS; ALTER TABLE "+xxx+".BA_SOKET OWNER TO medisoft;");
            m.execute_data("create table "+user+".dmchinhanh(id numeric(2),ten text,database text,ip varchar(25),CONSTRAINT pk_dmchinhanh PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH OIDS; ALTER TABLE "+user+".dmchinhanh OWNER TO medisoft;");
            m.execute_data("alter table "+user+".dlogin add chinhanh numeric(2) default 0;");
            m.execute_data("alter table "+user+".d_dlogin add chinhanh numeric(2) default 0;");
            m.execute_data("alter table "+user+".v_dlogin add chinhanh numeric(2) default 0;");
            m.execute_data("create table "+user+".dmphongthuchiencls(id numeric(3),ten text,stt numeric(3),id_loaivp numeric(3),CONSTRAINT pk_dmphongthuchiencls PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH OIDS; ALTER TABLE "+user+".dmphongthuchiencls OWNER TO medisoft;");
            m.execute_data("alter table "+user+".dmtheodoi alter id type varchar(9);");
            m.execute_data("CREATE TABLE "+xxx+".BA_HOICHANCCXN(ID numeric(22,0), MA numeric(3,0), TINHTRANG numeric(7,2) DEFAULT 0,CONSTRAINT pk_BA_HOICHANCCXN PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH OIDS; ALTER TABLE "+xxx+".BA_HOICHANCCXN OWNER TO medisoft;");
            m.execute_data("CREATE TABLE "+xxx+".BA_DONGMACHVANH(ID numeric(22,0), STT numeric(3,0), SOLUONG numeric(5,0) DEFAULT 0, VITRI text,CONSTRAINT pk_BA_DONGMACHVANH PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH OIDS; ALTER TABLE "+xxx+".BA_DONGMACHVANH OWNER TO medisoft;");
            m.execute_data("CREATE TABLE "+xxx+".BA_HINH(ID numeric(22,0), STT numeric(3,0), IMAGE bytea,CONSTRAINT pk_BA_HINH PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH OIDS; ALTER TABLE "+xxx+".BA_HINH OWNER TO medisoft;");
            m.execute_data("CREATE TABLE "+xxx+".BA_NOIKHOA(ID numeric(22,0), CHIDINH text, THOIGIAN timestamp, SOLUONG numeric(5,0) DEFAULT 0, LOAI text, THOIDIEM timestamp,CONSTRAINT pk_BA_NOIKHOA PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH OIDS; ALTER TABLE "+xxx+".BA_NOIKHOA OWNER TO medisoft;");
            m.execute_data("CREATE TABLE "+xxx+".BA_TOMTAT(ID numeric(22,0), BENHNHAN text, LYDO text, CONANG text, THUCTHE text, CLSDACO text,CONSTRAINT pk_BA_TOMTAT PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH OIDS; ALTER TABLE "+xxx+".BA_TOMTAT OWNER TO medisoft;");
            m.execute_data("CREATE TABLE "+xxx+".BA_HBDACDIEM(ID numeric(22,0), MA numeric(3,0), THOIGIAN text,CONSTRAINT pk_BA_HBDACDIEM PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH OIDS; ALTER TABLE "+xxx+".BA_HBDACDIEM OWNER TO medisoft;");
            m.execute_data("alter table "+user+".tenvien add ngoaidm numeric(1) default 0;");
            m.execute_data("alter table "+user+".chuyenvien add daduyet numeric(1) default 0;");
        }
        #endregion

        #region tao database
        private void f_capnhat_db_()
        {
            int i_maxlength_mabn = LibMedi.AccessData.i_maxlength_mabn;
            string s_user = m.user;
            //
            DataSet lds = new DataSet();
            int iPhienban = 2;//moi lan them field thi gan bang so tiep theo
            string user = m.user;
            string asql = "";//
            //           
            //
            asql = " select datao from " + user + ".datao where id=" + iPhienban;
            lds = m.get_data(asql);
            if (lds == null || lds.Tables.Count == 0)
            {
                asql = "create table " + user + ".datao(id number(5), constraint pk_datao primary key (id) USING INDEX TABLESPACE medi_index)  WITH OIDS ";
                m.execute_data(asql);
            }
            else if (lds == null || lds.Tables.Count <= 0 || lds.Tables[0].Rows.Count <= 0)
            {
                //goi ham tang chieu dai id
                //m.f_tangid_medibv();
                sql = "insert into " + user + ".datao (id) values(" + iPhienban + ") ";
                m.execute_data(sql);
            }
            else return;
            //
            asql = "select sothe from " + s_user + ".v_giavp where id=0";
            lds = m.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = " alter table " + s_user + ".v_giavp add sothe varchar(100) ";
                m.execute_data(asql, false);
            }
            asql = "select sothe from " + s_user + ".v_giavp where id=0";
            lds = m.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = " alter table " + s_user + ".d_dmbd add sothe varchar(100) ";
                m.execute_data(asql, false);
            }
            asql = "select hide from " + s_user + ".dmnoicapbhyt where 1=2";
            lds = m.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                sql = "alter table " + s_user + ".dmnoicapbhyt add hide numeric(1) default 0";
                m.execute_data(sql, false);
            }
            asql = "select hide from " + s_user + ".dstt where 1=2";
            lds = m.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = "alter table " + s_user + ".dstt add hide numeric(1) default 0";
                m.execute_data(asql, false);
            }
            asql = "select paid from " + s_user + ".xuatvien where maql=0";
            lds = m.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = "alter table " + s_user + ".xuatvien add paid numeric(1) default 0";
                m.execute_data(asql, false);
            }

            asql = "select tuchoi from " + user + ".benhandt where 1=2";
            lds = m.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = "alter table " + user + ".benhandt add tuchoi numeric(1) default 0";
                m.execute_data(asql, false);
            }
            asql = "select bhyt_tt from " + s_user + ".v_giavp where id=0";
            lds = m.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = " alter table " + s_user + ".v_giavp add bhyt_tt numeric(5,2) default 0 ";
                m.execute_data(asql, false);

                asql = " update " + s_user + ".v_giavp set bhyt_tt=bhyt ";
                m.execute_data(asql, false);
            }
            asql = "select hide from " + s_user + ".icd10 where id=0";
            lds = m.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = " alter table " + s_user + ".icd10 add hide numeric(1) default 0 ";
                m.execute_data(asql, false);
            }
            asql = "select yeucau from " + s_user + ".chuyenvien where maql=0";
            lds = m.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = " alter table " + s_user + ".chuyenvien add yeucau numeric(1) default 0 ";
                m.execute_data(asql, false);
            }

            asql = "select thanhthi from " + s_user + ".btdpxa where 1=2";
            lds = m.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = " alter table " + s_user + ".btdpxa add thanhthi numeric(1) default 1 ";
                m.execute_data(asql, false);
            }
            asql = "select mabn from " + s_user + ".datgiuong where 1=2";
            lds = m.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = " create table " + s_user + ".datgiuong (MABN varchar(" + i_maxlength_mabn.ToString() + "), NGAY timestamp, IDGIUONG numeric(10), DEN timestamp, GHICHU text, USERID numeric(7) default 0, NGAYUD timestamp default now(), constraint pk_datgiuong primary key (mabn, ngay, idgiuong) USING INDEX TABLESPACE medi_index)  WITH OIDS ";
                m.execute_data(asql, false);
            }
            asql = "select mabn from " + s_user + ".sophieurv where 1=2";
            lds = m.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                sql = "create table " + s_user + ".sophieurv(mabn varchar(" + i_maxlength_mabn.ToString() + "),maql numeric(22),loaiba numeric(1),ngay timestamp,madoituong numeric(2),so numeric(5) default 0,lanin numeric(5) default 1,ghichu text,constraint pk_sophieurv primary key(maql,ngay)) with oids";
                m.execute_data(sql, false);
            }
            asql = "select stt from " + s_user + ".capmabns where 1=2";
            lds = m.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                sql = "create table " + s_user + ".capmabns(yy numeric(2),stt numeric(6),loai numeric(1),userid numeric(5),computer numeric(5),constraint pk_capmabns primary key(yy, loai, userid, computer)) with oids";
                m.execute_data(sql, false);
            }
            sql = "select ketoa from " + user + ".d_dmbd where 1=2";
            lds = m.get_data(sql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                sql = "alter table " + user + ".d_dmbd add ketoa numeric(1) default 1";
                m.execute_data(sql);
            }
            asql = "select giuongthem from " + s_user + ".theodoigiuong where id=0";
            lds = m.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                sql = "alter table " + user + ".theodoigiuong add giuongthem numeric(1) default 0";
                m.execute_data(sql);
            }
            asql = "select id from " + s_user + ".dmkhudt where id=0";
            lds = m.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                sql = "create table " + user + ".dmkhudt (id numeric(3), ten text,constraint pk_dmkhudt primary key(id)) with oids";
                m.execute_data(sql);
            }
            asql = "select khu from " + s_user + ".dlogin where id=0";
            lds = m.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                sql = "alter table " + user + ".dlogin add khu varchar(100)";
                m.execute_data(sql);
            }
            asql = "select khu from " + s_user + ".btdkp_bv where makp='???'";
            lds = m.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                sql = "alter table " + user + ".btdkp_bv add khu numeric(3) default 0";
                m.execute_data(sql);
                sql = "alter table " + user + ".btdkp_add add khu numeric(3) default 0";
                m.execute_data(sql);
            }
            asql = "select khu from " + s_user + ".d_duockp where makp='???'";
            lds = m.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                sql = "alter table " + user + ".d_duockp add khu numeric(3) default 0";
                m.execute_data(sql);
            }
            //hien them
            asql = "select c01 from " + s_user + ".dm_11_dk_1 where stt='?'";
            lds = m.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                Capnhat_DB_BYT();
            }
        }
        DataTable dt = new DataTable();
        string xxx = "";
        private void Capnhat_DB_BYT()
        {
            Cursor.Current = Cursors.WaitCursor;
            m = new AccessData();
             xxx = "medibv";
             dt = m.get_data("Select * from " + xxx + ".DMCOSO where TUYEN IN (1,2,3)").Tables[0];
            //			//load xml- hien bo vi de lai mau cu
            //if (System.IO.File.Exists("..\\..\\..\\xml\\dm_11.xml"))
            //{
            //    ds.ReadXml("..\\..\\..\\xml\\dm_11.xml");
            //    foreach (DataRow row in ds.Tables[0].Rows)
            //    {
            //        m.upd_DM11(int.Parse(row["ma"].ToString()), row["stt"].ToString(), row["ten"].ToString(), row["icd10"].ToString());
            //    }
            //}
            //else
            //{
            //    MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy file dm_11.xml !", LibMedi.AccessData.Msg);
            //    return;
            //}
            kh_bieu01();
            kh_bieu02();
            bieu11_1();
            //kh_bieu15();
            dmloaicosoyte();
            //			kh_bieu030();
            kh_bieu031();
            kh_bieu032();
            kh_bieu04();
            kh_bieu05();
            kh_bieu06();
            kh_bieu07();
            kh_bieu08();
            kh_bieu09();
            kh_bieu10();
            kh_bieu11();
            kh_bieu121();
            kh_bieu122();
            kh_bieu13();
            kh_bieu141();
            kh_bieu142();
            kh_bieu143();
            dt_bieu11();
            Cursor.Current = Cursors.Default;
        }

        private void dt_bieu11()
        {
            sql = "CREATE TABLE " + m.user + ".bieu_11_1" +
                     "(" +
                       "id numeric(8) NOT NULL DEFAULT 0,ma numeric(5) NOT NULL ,ngay timestamp without time zone," +
                       "c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0," +
                       "c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0," +
                       "c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,C12 decimal(7) default 0," +
                       "c041 numeric(7) DEFAULT 0,c051 numeric(7) DEFAULT 0,c15 numeric(7) DEFAULT 0,c16 numeric(7) DEFAULT 0," +
                       "c17 numeric(7) DEFAULT 0,c18 numeric(7) DEFAULT 0," +
                       "userid numeric(7) DEFAULT 0," +
                       "ngayud timestamp without time zone DEFAULT now()," +
                       "CONSTRAINT pk_bieu_11_1 PRIMARY KEY (id, ma)" +
                     ") " +
                     "WITH OIDS;ALTER TABLE " + m.user + ".bieu_11_1 OWNER TO medisoft;";
            m.execute_data(sql);

        }
        #region bieu 04
        private void kh_bieu04()
        {
            sql = "CREATE TABLE " + xxx + ".khdm_04(ma numeric(2) NOT NULL ,stt varchar(2),ten text,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,c12 numeric(7) DEFAULT 0,c13 numeric(7) DEFAULT 0,c14 numeric(7) DEFAULT 0,c15 numeric(7) DEFAULT 0,c16 numeric(7) DEFAULT 0,c17 numeric(7) DEFAULT 0,c18 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_04 PRIMARY KEY (ma,stt)) WITH OIDS;ALTER TABLE " + xxx + ".khdm_04 OWNER TO medisoft;";
            m.execute_data(sql);
            // bieu
            sql = "CREATE TABLE " + xxx + ".khbieu_04(id numeric(8) NOT NULL DEFAULT 0,ma numeric(2) NOT NULL ,ngay timestamp without time zone,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,c12 numeric(7) DEFAULT 0,c13 numeric(7) DEFAULT 0,c14 numeric(7) DEFAULT 0,c15 numeric(7) DEFAULT 0,c16 numeric(7) DEFAULT 0,c17 numeric(7) DEFAULT 0,c18 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp without time zone DEFAULT now(),CONSTRAINT pk_khbieu_04 PRIMARY KEY (id, ma)) WITH OIDS;ALTER TABLE " + xxx + ".khbieu_04 OWNER TO medisoft;";
            m.execute_data(sql);
            //INSERT KHDM_04
            m.upd_danhmuc(0, "A", "Tổng số", "khdm_04");//Tổng số
            m.upd_danhmuc(1, "1", "Tiến sỹ Y", "khdm_04");//Tiến sỹ Y
            m.upd_danhmuc(2, "2", "Thạc sỹ Y", "khdm_04");//Thạc sỹ Y
            m.upd_danhmuc(3, "3", "Chuyên khoa II", "khdm_04");//Chuyên khoa II
            m.upd_danhmuc(4, "4", "Chuyên khoa I", "khdm_04");
            m.upd_danhmuc(5, "5", "Bác sỹ", "khdm_04");
            m.upd_danhmuc(6, "6", "Tiến sỹ Dược", "khdm_04");
            m.upd_danhmuc(7, "7", "Thạc sỹ Dược", "khdm_04");
            m.upd_danhmuc(8, "8", "Chuyên khoa II Dược", "khdm_04");
            m.upd_danhmuc(9, "9", "Chuyên khoa I Dược", "khdm_04");
            m.upd_danhmuc(10, "10", "Dược sỹ đại học", "khdm_04");
            m.upd_danhmuc(11, "11", "Thạc sỹ y tế Công cộng", "khdm_04");
            m.upd_danhmuc(12, "12", "Đại học y tế Công cộng", "khdm_04");
            m.upd_danhmuc(13, "13", "Cao đẳng y tế Công cộng", "khdm_04");
            m.upd_danhmuc(14, "14", "Y sỹ", "khdm_04");
            m.upd_danhmuc(15, " ", "Trong đó: Y sỹ sản nhi", "khdm_04");
            m.upd_danhmuc(16, "15", "KTV y đại học", "khdm_04");
            m.upd_danhmuc(17, "16", "KTV y cao đẳng", "khdm_04");
            m.upd_danhmuc(18, "17", "KTV y trung học", "khdm_04");
            m.upd_danhmuc(19, "18", "KTV y sơ học", "khdm_04");
            m.upd_danhmuc(20, "19", "Dược sỹ/KTV TH Dược", "khdm_04");
            m.upd_danhmuc(21, "20", "Dược tá", "khdm_04");
            m.upd_danhmuc(22, "21", "ĐD (y tá) đại học", "khdm_04");
            m.upd_danhmuc(23, "22", "ĐD (y tá) cao đẳng", "khdm_04");
            m.upd_danhmuc(24, "23", "ĐD (y tá) trung học", "khdm_04");
            m.upd_danhmuc(25, "24", "ĐD (y tá) sơ học", "khdm_04");
            m.upd_danhmuc(26, "25", "Hộ sinh Đại học", "khdm_04");
            m.upd_danhmuc(27, "26", "Hộ sinh Cao đẳng", "khdm_04");
            m.upd_danhmuc(28, "27", "Hộ sinh Trung học", "khdm_04");
            m.upd_danhmuc(29, "28", "Hộ sinh Sơ học", "khdm_04");
            m.upd_danhmuc(30, "29", "Lương y/ Lương dược", "khdm_04");
            m.upd_danhmuc(31, "30", "Đại học ngành khác", "khdm_04");
            m.upd_danhmuc(32, "31", "Cán bộ khác", "khdm_04");

            //CREATE TABLE KHDM_04_DK
            sql = "create table " + xxx + ".khdm_04_dk(MA varchar(3), TEN Text, DK Text, constraint PK_khdm_04_dk primary key(ma)) with OIDS;ALTER TABLE " + xxx + ".khdm_04_dk OWNER TO medisoft;";
            m.execute_data(sql);
            //INSERT KHDM_04
            m.upd_danhmuc_dk("C03", "<Tổng số>", "C03>=0", "khdm_04_dk");
            m.upd_danhmuc_dk("C04", "<Số Nữ>", "C04<=C03", "khdm_04_dk");
            m.upd_danhmuc_dk("C05", "<Tổng số/QLNN/Tuyến quận(huyện)>", "C05+C07+..+C19<=C03", "khdm_04_dk");
            m.upd_danhmuc_dk("C06", "<Số Nữ/QLNN/Tuyến quận(huyện)>", "C04<=C03", "khdm_04_dk");
            m.upd_danhmuc_dk("C07", "<Tổng số/Phòng bệnh/Tuyến quận(huyện)>", "C05+C07+..+C19<=C03", "khdm_04_dk");
            m.upd_danhmuc_dk("C08", "<Số Nữ/Phòng bệnh/Tuyến quận(huyện)>", "C08<=C07", "khdm_04_dk");
            m.upd_danhmuc_dk("C09", "<Tổng số/Chữa bệnh/Tuyến quận(huyện)>", "C05+C07+..+C19<=C03", "khdm_04_dk");
            m.upd_danhmuc_dk("C10", "<Số Nữ/Chữa bệnh/Tuyến quận(huyện)>", "C10<=C09", "khdm_04_dk");
            m.upd_danhmuc_dk("C11", "<Tổng số/Trung tâm dân số/Tuyến quận(huyện)>", "C05+C07+..+C19<=C03", "khdm_04_dk");
            m.upd_danhmuc_dk("C12", "<Số Nữ/Trung tâm dân số/Tuyến quận(huyện)>", "C12<=C10", "khdm_04_dk");
            m.upd_danhmuc_dk("C13", "<Tổng số/Trạm Y tế/Tuyến xã(phường)>", "C05+C07+..+C19<=C03", "khdm_04_dk");
            m.upd_danhmuc_dk("C14", "<Số Nữ/Trạm Y tế/Tuyến xã(phường)>", "C14<=C13", "khdm_04_dk");
            m.upd_danhmuc_dk("C15", "<Tổng số/Thôn bản/Tuyến xã(phường)>", "C05+C07+..+C19<=C03", "khdm_04_dk");
            m.upd_danhmuc_dk("C16", "<Số Nữ/Thôn bản/Tuyến xã(phường)>", "C16<=C15", "khdm_04_dk");
            m.upd_danhmuc_dk("C17", "<Tổng số/Phòng khám/Tư nhân>", "C05+C07+..+C19<=C03", "khdm_04_dk");
            m.upd_danhmuc_dk("C18", "<Số Nữ/Phòng khám/Tư nhân>", "C18<=C17", "khdm_04_dk");
            m.upd_danhmuc_dk("C19", "<Tổng số/Cơ sở khác/Tư nhân>", "C05+C07+..+C19<=C03", "khdm_04_dk");
            m.upd_danhmuc_dk("C20", "<Số Nữ/Cơ sở khác/Tư nhân>", "C20<=C19", "khdm_04_dk");

        }
#endregion
        #region khe hoach bieu 05
        void kh_bieu05()
        {
            m.execute_data("alter table " + xxx + ".dmcoso modify  ma numeric(5)");
            m.upd_dmtuyen(3, "Tư nhân");

            sql = "CREATE TABLE " + xxx + ".khdm_05(ma numeric(2) NOT NULL ,stt varchar(2),ten text,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,c12 numeric(7) DEFAULT 0,c13 numeric(7) DEFAULT 0,c14 numeric(7) DEFAULT 0,c15 numeric(7) DEFAULT 0,c16 numeric(7) DEFAULT 0,c17 numeric(7) DEFAULT 0,c18 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_05 PRIMARY KEY (ma,stt)) WITH OIDS;ALTER TABLE " + xxx + ".khdm_05 OWNER TO medisoft;";
            m.execute_data(sql);
            // bieu
            sql = "CREATE TABLE " + xxx + ".khbieu_05(id numeric(8) NOT NULL DEFAULT 0,ma numeric(2) NOT NULL ,ngay timestamp without time zone,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,c12 numeric(7) DEFAULT 0,c13 numeric(7) DEFAULT 0,c14 numeric(7) DEFAULT 0,c15 numeric(7) DEFAULT 0,c16 numeric(7) DEFAULT 0,c17 numeric(7) DEFAULT 0,c18 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp without time zone DEFAULT now(),CONSTRAINT pk_khbieu_05 PRIMARY KEY (id, ma)) WITH OIDS;ALTER TABLE " + xxx + ".khbieu_05 OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc(-1, "A", "Cơ sở y tế công", "khdm_05");
            m.upd_danhmuc(150, "B", "Tư nhân", "khdm_05");
            sql = "Create table " + xxx + ".KHDM_05_DK (MA varchar(3) primary key , TEN Text,DK Text) with OIDS;ALTER TABLE " + xxx + ".khdm_05_dk OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "Phụ nữ có thai/Tổng số", "C03>=0", "khdm_05_dk");
            m.upd_danhmuc_dk("C04", "Phụ nữ có thai/trong đó vị thành niên", "(C04<=C03)", "khdm_05_dk");
            m.upd_danhmuc_dk("C05", "Tổng số lần khám thai", "C05>=0", "khdm_05_dk");
            m.upd_danhmuc_dk("C06", "Số đẻ được quản lý thai", "C06>=0", "khdm_05_dk");
            m.upd_danhmuc_dk("C07", "Số phụ nữ đẻ được tiêm đủ UV", "C07>=0", "khdm_05_dk");
            m.upd_danhmuc_dk("C08", "Phụ nữ đẻ/Tổng số PN đẻ", "(C08>=0)", "khdm_05_dk");
            m.upd_danhmuc_dk("C09", "Phụ nữ đẻ/Trong đó/Khám >=3 lần trong 3 kỳ", "(C09<=C08 AND C09+..+C14 <=C08)", "khdm_05_dk");
            m.upd_danhmuc_dk("C10", "Phụ nữ đẻ/Trong đó/ FX-GH", "(C10<=C08 AND C09+..+C14 <=C08))", "khdm_05_dk");
            m.upd_danhmuc_dk("C11", "Phụ nữ đẻ/Trong đó/Mổ lấy thai", "(C11<=C08 AND C09+..+C14 <=C08)", "khdm_05_dk");
            m.upd_danhmuc_dk("C12", "Phụ nữ đẻ/Trong đó/Đẻ con thứ 3 trở lên", "(C12<=C08 AND C09+..+C14 <=C08)", "khdm_05_dk");
            m.upd_danhmuc_dk("C13", "Phụ nữ đẻ/Trong đó/Đẻ do cán bộ y tế đỡ", "(C13<=C08 AND C09+..+C14 <=C08)", "khdm_05_dk");
            m.upd_danhmuc_dk("C14", "Phụ nữ đẻ/Trong đó/Đẻ tại cở sở y tế", "(C14<=C08 AND C09+..+C14 <=C08))", "khdm_05_dk");
            m.upd_danhmuc_dk("C15", "Bá mẹ và trẻ SS được chăm sóc sau sinh/Tổng số", "(C15>=0)", "khdm_05_dk");
            m.upd_danhmuc_dk("C16", "Bá mẹ và trẻ SS được chăm sóc sau sinh/Trong đó tuần đầu", "(C16<=C15)", "khdm_05_dk");
            foreach (DataRow row in dt.Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), "", row["ten"].ToString(), "KHDM_05");
            }
            m.sort_stt05("KHDM_05");
        }
        #endregion
        #region ke hoach bieu 06
        void kh_bieu06()
        {
            sql = "CREATE TABLE " + xxx + ".khdm_06(ma numeric(5) NOT NULL ,stt varchar(5),ten text,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_06 PRIMARY KEY (ma,stt)) WITH OIDS;ALTER TABLE " + xxx + ".khdm_06 OWNER TO medisoft;";
            m.execute_data(sql);
            sql = "CREATE TABLE " + xxx + ".khbieu_06(id numeric(8) NOT NULL DEFAULT 0,ma numeric(5) NOT NULL ,ngay timestamp without time zone,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp without time zone DEFAULT now(),CONSTRAINT pk_khbieu_06 PRIMARY KEY (id, ma)) WITH OIDS;ALTER TABLE " + xxx + ".khbieu_06 OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc(-1, "A", "Cơ sở y tế công", "khdm_06");
            m.upd_danhmuc(150, "B", "Cơ sở y tế tư", "khdm_06");
            sql = "Create table " + xxx + ".KHDM_06_DK (MA varchar(3) primary key , TEN Text,DK Text) with OIDS;ALTER TABLE " + xxx + ".khdm_06_dk OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "Băng huyết/ Mắc", "C03>=0", "khdm_06_dk");
            m.upd_danhmuc_dk("C04", "Băng huyết/ Chết", "C03<=C04", "khdm_06_dk");
            m.upd_danhmuc_dk("C05", "Sản giật/ Mắc", "C05>=0", "khdm_06_dk");
            m.upd_danhmuc_dk("C06", "Sản giật/ Chết", "C06<=C05", "khdm_06_dk");
            m.upd_danhmuc_dk("C07", "Uốn ván SS/ Mắc", "C07>=0", "khdm_06_dk");
            m.upd_danhmuc_dk("C08", "Uốn ván SS/ Chết", "C08<=C07", "khdm_06_dk");
            m.upd_danhmuc_dk("C09", "Vở tử cung/ Mắc", "C09>=0", "khdm_06_dk");
            m.upd_danhmuc_dk("C10", "Vở tử cung/ Chết", "C10<=C09", "khdm_06_dk");
            m.upd_danhmuc_dk("C11", "Nhiễm tử cung/ Mắc", "C11>=0", "khdm_06_dk");
            m.upd_danhmuc_dk("C12", "Nhiễm tử cung/ Mắc", "C12<=C11", "khdm_06_dk");
            foreach (DataRow row in dt.Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), "", row["ten"].ToString(), "KHDM_06");
            }
            m.sort_stt05("KHDM_06");
        }
        #endregion
        #region ke hoach bieu 07
        void kh_bieu07()
        {
            sql = "CREATE TABLE " + xxx + ".khdm_07(ma numeric(5) NOT NULL ,stt varchar(5),ten text,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_07 PRIMARY KEY (ma,stt)) WITH OIDS;ALTER TABLE " + xxx + ".khdm_07 OWNER TO medisoft;";
            m.execute_data(sql);
            sql = "CREATE TABLE " + xxx + ".khbieu_07(id numeric(8) NOT NULL DEFAULT 0,ma numeric(5) NOT NULL ,ngay timestamp without time zone,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp without time zone DEFAULT now(),CONSTRAINT pk_khbieu_07 PRIMARY KEY (id, ma)) WITH OIDS;ALTER TABLE " + xxx + ".khbieu_07 OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc(-1, "A", "Cơ sở y tế công", "khdm_07");
            m.upd_danhmuc(150, "B", "Cơ sở y tế tư", "khdm_07");
            sql = "Create table " + xxx + ".KHDM_07_DK (MA varchar(3) primary key , TEN Text,DK Text) with OIDS;ALTER TABLE " + xxx + ".KHDM_07_DK OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "Tổng số phụ nữ >=15", "C03>=0", "khdm_07_dk");
            m.upd_danhmuc_dk("C04", "Tổng số lượt khám phụ khoa", "C04 >=0", "khdm_07_dk");
            m.upd_danhmuc_dk("C05", "Tổng số lượt chữa phụ khoa", "C05>=0", "khdm_07_dk");
            m.upd_danhmuc_dk("C06", "Phá thai/ Số phá thai theo tuần/ <=7 tuần ", "C06>=0", "khdm_07_dk");
            m.upd_danhmuc_dk("C07", "Phá thai/ Số phá thai theo tuần/ Trên 7 tuần đến <=12 tuần", "C07>=0", "khdm_07_dk");
            m.upd_danhmuc_dk("C08", "Phá thai/ Số phá thai theo tuần/ >12 tuần", "C08>=0", "khdm_07_dk");
            m.upd_danhmuc_dk("C09", "Phá thai/ Trong đó vị thàn niên", "C09>=0 AND C09 <= C06+C07+c08 ", "khdm_07_dk");
            m.upd_danhmuc_dk("C10", "Tai biến di nạo phá thai/ Số mắc", "C10 >=0", "khdm_07_dk");
            m.upd_danhmuc_dk("C11", "Tai biến di nạo phá thai/ Số chết", "C11 <= C10", "khdm_07_dk");
            foreach (DataRow row in dt.Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), "", row["ten"].ToString(), "KHDM_07");
            }
            m.sort_stt05("KHDM_07");
        }
        #endregion
        #region ke hoach bieu 08
        void kh_bieu08()
        {
            sql = "CREATE TABLE " + xxx + ".khdm_08(ma numeric(5) NOT NULL ,stt varchar(5),ten text,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_08 PRIMARY KEY (ma,stt)) WITH OIDS;ALTER TABLE " + xxx + ".khdm_08 OWNER TO medisoft;";
            m.execute_data(sql);
            sql = "CREATE TABLE " + xxx + ".khbieu_08(id numeric(8) NOT NULL DEFAULT 0,ma numeric(5) NOT NULL ,ngay timestamp without time zone,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp without time zone DEFAULT now(),CONSTRAINT pk_khbieu_08 PRIMARY KEY (id, ma)) WITH OIDS;ALTER TABLE " + xxx + ".khbieu_08 OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc(-1, "A", "Cơ sở y tế công", "khdm_08");
            m.upd_danhmuc(150, "B", "Cơ sở y tế tư", "khdm_08");
            sql = "Create table " + xxx + ".KHDM_08_DK (MA varchar(3) primary key , TEN Text,DK Text) with OIDS;ALTER TABLE " + xxx + ".khdm_08_dk OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "Tổng số người mới thực hiện BPTT", "C04+C05+C06+C07+c08+C09 <= C03", "khdm_08_dk");
            m.upd_danhmuc_dk("C04", "Tổng số người mới thực hiện BPTT/ Trong đó : số đặt dụng cụ tử cung ", "C04+C05+C06+C07+c08+C09 <= C03", "khdm_08_dk");
            m.upd_danhmuc_dk("C05", "Tổng số người mới thực hiện BPTT/ Trong đó /Thuốc tránh thai : Thuốc viên ", "C04+C05+C06+C07+c08+C09 <= C03", "khdm_08_dk");
            m.upd_danhmuc_dk("C06", "Tổng số người mới thực hiện BPTT/ Trong đó /Thuốc tránh thai : thuốc tiêm ", "C04+C05+C06+C07+c08+C09 <= C03", "khdm_08_dk");
            m.upd_danhmuc_dk("C07", "Tổng số người mới thực hiện BPTT/ Trong đó /Thuốc tránh thai : Thuốc cấy", "C04+C05+C06+C07+c08+C09 <= C03", "khdm_08_dk");
            m.upd_danhmuc_dk("C08", "Tổng số người mới thực hiện BPTT/ Trong đó : bao cao su", "C04+C05+C06+C07+c08+C09 <= C03", "khdm_08_dk");
            m.upd_danhmuc_dk("C09", "Tổng số người mới thực hiện BPTT/ Triệt sản mới : Tổng số", "C04+C05+C06+C07+c08+C09 <= C03", "khdm_08_dk");
            m.upd_danhmuc_dk("C10", "Tổng số người mới thực hiện BPTT/ Triệt sản mới : Nữ", "C10 <= C09", "khdm_08_dk");
            m.upd_danhmuc_dk("C11", "Tai biến do thực hiện KHHGD: Số mắc", "C11 <= C03", "khdm_08_dk");
            m.upd_danhmuc_dk("C12", "Tai biến do thực hiện KHHGD: Số chết", "C12 <= C11", "khdm_08_dk");
            foreach (DataRow row in dt.Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), "", row["ten"].ToString(), "KHDM_08");
            }
            m.sort_stt05("KHDM_08");
        }
        #endregion
        #region ke hoach bieu 09
        void kh_bieu09()
        {
            sql = "CREATE TABLE " + xxx + ".khdm_09(ma numeric(5) NOT NULL ,stt varchar(5),ten text,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_09 PRIMARY KEY (ma,stt)) WITH OIDS;ALTER TABLE " + xxx + ".khdm_09 OWNER TO medisoft;";
            m.execute_data(sql);
            sql = "CREATE TABLE " + xxx + ".khbieu_09(id numeric(8) NOT NULL DEFAULT 0,ma numeric(5) NOT NULL ,ngay timestamp without time zone,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp without time zone DEFAULT now(),CONSTRAINT pk_khbieu_09 PRIMARY KEY (id, ma)) WITH OIDS;ALTER TABLE " + xxx + ".khbieu_09 OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc(-1, "A", "Cơ sở y tế công", "khdm_09");
            m.upd_danhmuc(150, "B", "Tư nhân", "khdm_09");
            sql = "Create table " + xxx + ".KHDM_09_DK (MA varchar(3) primary key , TEN Text,DK Text) with OIDS;ALTER TABLE " + xxx + ".khdm_09_dk OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "Số trẻ đẻ ra sống: Tổng số", "C03>=0", "khdm_09_dk");
            m.upd_danhmuc_dk("C04", "Số trẻ đẻ ra sống: Trong đó nữ ", "C04 <= C03", "khdm_09_dk");
            m.upd_danhmuc_dk("C05", "Số trẻ được cân : Tổng số", "C05 >=0", "khdm_09_dk");
            m.upd_danhmuc_dk("C06", "Số trẻ được cân : Trong đó <2500g", "C06 <= C05", "khdm_09_dk");
            m.upd_danhmuc_dk("C07", "Chết thai nhi và chết trẻ em: Chết thai nhi từ 22 tuần đến khi đẻ", "C07>=0", "khdm_09_dk");
            m.upd_danhmuc_dk("C08", "Chết thai nhi và chết trẻ em: Số chết <7 ngày", "C08>=0", "khdm_09_dk");
            m.upd_danhmuc_dk("C09", "Chết thai nhi và chết trẻ em: Số chết sơ sinh (<=28 ngày)", "C09>=0", "khdm_09_dk");
            m.upd_danhmuc_dk("C10", "Tỷ lệ SDD trẻ em <5 tuổi(cân/tuổi)", "C10>=0", "khdm_09_dk");
            foreach (DataRow row in dt.Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), "", row["ten"].ToString(), "KHDM_09");
            }
            m.sort_stt05("KHDM_09");
        }
        #endregion
        #region Biểu 10 vụ kế hoạch
        private void kh_bieu10()
        {
            sql = "CREATE TABLE " + xxx + ".khdm_10(ma varchar(7) NOT NULL ,stt varchar(5),ten text,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_10 PRIMARY KEY (ma,stt)) WITH OIDS;ALTER TABLE " + xxx + ".khdm_10 OWNER TO medisoft;";
            m.execute_data(sql);
            sql = "CREATE TABLE " + xxx + ".khbieu_10(id numeric(8) NOT NULL DEFAULT 0,ma varchar(7) NOT NULL ,ngay timestamp without time zone,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp without time zone DEFAULT now(),CONSTRAINT pk_khbieu_10 PRIMARY KEY (id, ma)) WITH OIDS;ALTER TABLE " + xxx + ".khbieu_10 OWNER TO medisoft;";
            m.execute_data(sql);
            sql = "Create table " + xxx + ".KHDM_10_DK (MA varchar(3) , TEN Text,DK Text) with OIDS;ALTER TABLE " + xxx + ".khdm_10_dk OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "Số trẻ em <1 tuổi", "(C03>0)", "khdm_10_dk");
            m.upd_danhmuc_dk("C04", "Số trẻ TCĐĐ 7 loại vắc xin", "(C04>0)", "khdm_10_dk");
            m.upd_danhmuc_dk("C05", "Số trẻ TCĐĐ 7 loại vắc xin/Trong đó:BCG", "(C05+..+C09 <= C04)", "khdm_10_dk");
            m.upd_danhmuc_dk("C06", "Số trẻ TCĐĐ 7 loại vắc xin/Trong đó:DPT", "(C05+..+C09 <= C04)", "khdm_10_dk");
            m.upd_danhmuc_dk("C07", "Số trẻ TCĐĐ 7 loại vắc xin/Trong đó:OPV", "(C05+..+C09 <= C04)", "khdm_10_dk");
            m.upd_danhmuc_dk("C08", "Số trẻ TCĐĐ 7 loại vắc xin/Trong đó:Viêm gan B", "(C05+..+C09 <= C04)", "khdm_10_dk");
            m.upd_danhmuc_dk("C09", "Số trẻ TCĐĐ 7 loại vắc xin/Trong đó:Sởi", "(C05+..+C09 <= C04)", "khdm_10_dk");
            m.upd_danhmuc_dk("C10", "Viêm não nhật bản", "(C10>0)", "khdm_10_dk");
            m.upd_danhmuc_dk("C11", "Tả", "(C11>0)", "khdm_10_dk");
            m.upd_danhmuc_dk("C12", "Thương hàn", "(C12>0)", "khdm_10_dk");
            m.upd_danhmuc_dk("C13", "Số phụ nữ có thai được ưu tiên UV2+", "(C13>0)", "khdm_10_dk");
            sql = "select a.maphuongxa as ma,a.tenpxa from " + xxx + ".btdpxa a," + xxx + ".btdtt b," + xxx + ".btdquan c where a.maqu=c.maqu and b.matt=c.matt and b.matt ='" + m.Mabv.Substring(0, 3) + "'";
            int stt = 1;
            m.execute_data("delete from khdm_10");
            foreach (DataRow row in m.get_data(sql).Tables[0].Rows)
            {
                if (row["ma"].ToString().Substring(5, 2) != "00")
                {
                    m.upd_danhmuc(row["ma"].ToString(), stt.ToString(), row["tenpxa"].ToString(), "khdm_10");
                    stt++;
                }
            }

        }
        #endregion
        #region kh bieu 11
        #region ke hoach bieu 11
        void kh_bieu11()
        {
            sql = "CREATE TABLE " + xxx + ".khdm_11(ma numeric(5) NOT NULL ,stt varchar(5),ten text,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,c12 numeric(7) DEFAULT 0,c13 numeric(7) DEFAULT 0,c14 numeric(7) DEFAULT 0,c15 numeric(7) DEFAULT 0,c16 numeric(7) DEFAULT 0,c17 numeric(7) DEFAULT 0,c18 numeric(7) DEFAULT 0,c19 numeric(7) DEFAULT 0,c20 numeric(7) DEFAULT 0,c21 numeric(7) DEFAULT 0,c22 numeric(7) DEFAULT 0,c23 numeric(7) DEFAULT 0,c24 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_11 PRIMARY KEY (ma,stt)) WITH OIDS;ALTER TABLE " + xxx + ".khdm_11 OWNER TO medisoft;";
            m.execute_data(sql);
            sql = "CREATE TABLE " + xxx + ".khbieu_11(id numeric(8) NOT NULL DEFAULT 0,ma numeric(5) NOT NULL ,ngay timestamp without time zone,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,c12 numeric(7) DEFAULT 0,c13 numeric(7) DEFAULT 0,c14 numeric(7) DEFAULT 0,c15 numeric(7) DEFAULT 0,c16 numeric(7) DEFAULT 0,c17 numeric(7) DEFAULT 0,c18 numeric(7) DEFAULT 0,c19 numeric(7) DEFAULT 0,c20 numeric(7) DEFAULT 0,c21 numeric(7) DEFAULT 0,c22 numeric(7) DEFAULT 0,c23 numeric(7) DEFAULT 0,c24 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp without time zone DEFAULT now(),CONSTRAINT pk_khbieu_11 PRIMARY KEY (id, ma)) WITH OIDS;ALTER TABLE " + xxx + ".khbieu_11 OWNER TO medisoft;";
            m.execute_data(sql);
            m.execute_data("delete from khdm_11");
            m.upd_danhmuc(-1, "A", "Tổng số", "khdm_11");
            sql = "Create table " + xxx + ".KHDM_11_DK (MA varchar(3) primary key , TEN Text,DK Text)with OIDS;ALTER TABLE " + xxx + ".khdm_11_dk OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "Sởi:Mắc", "C03>=0", "khdm_11_dk");
            m.upd_danhmuc_dk("C04", "Sởi:Chết", "C04 <= C03", "khdm_11_dk");
            m.upd_danhmuc_dk("C05", "Ho gà:Mắc", "C05 >=0", "khdm_11_dk");
            m.upd_danhmuc_dk("C06", "Ho gà:Chết", "C06 <= C05", "khdm_11_dk");
            m.upd_danhmuc_dk("C07", "LMC:Mắc", "C07>=0", "khdm_11_dk");
            m.upd_danhmuc_dk("C08", "LMC:Chết", "C08<= C07", "khdm_11_dk");
            m.upd_danhmuc_dk("C09", "Bạch hầu:Mắc", "C09>=0", "khdm_11_dk");
            m.upd_danhmuc_dk("C10", "Bạch hầu:Chết", "C10<=C09", "khdm_11_dk");
            m.upd_danhmuc_dk("C11", "UVSS:Mắc", "C11>=0", "khdm_11_dk");
            m.upd_danhmuc_dk("C12", "UVSS:Chết", "C12<=C11", "khdm_11_dk");
            m.upd_danhmuc_dk("C13", "UV Khác:Mắc", "C13>=0", "khdm_11_dk");
            m.upd_danhmuc_dk("C14", "UV Khác:Chết", "C14<=C13", "khdm_11_dk");
            m.upd_danhmuc_dk("C15", "Lao màng não:Mắc", "C15>=0", "khdm_11_dk");
            m.upd_danhmuc_dk("C16", "Lao màng não:Chết", "C16<=C15", "khdm_11_dk");
            m.upd_danhmuc_dk("C17", "Lao khác:Mắc", "C17>=0", "khdm_11_dk");
            m.upd_danhmuc_dk("C18", "Lao khác:Chết", "C18<=C17", "khdm_11_dk");
            m.upd_danhmuc_dk("C19", "Viêm gan virus:Mắc", "C19>=0", "khdm_11_dk");
            m.upd_danhmuc_dk("C20", "Viêm gan virus:Chết", "C20<=C19", "khdm_11_dk");
            m.upd_danhmuc_dk("C21", "Viêm não virus:Mắc", "C21>=0", "khdm_11_dk");
            m.upd_danhmuc_dk("C22", "Viêm não virus:Chết", "C22<=C21", "khdm_11_dk");
            m.upd_danhmuc_dk("C23", "Tả:Mắc", "C23>=0", "khdm_11_dk");
            m.upd_danhmuc_dk("C24", "Tả:Chết", "C24<=C23", "khdm_11_dk");
            m.upd_danhmuc_dk("C25", "Thương hàn:Mắc", "C25>=0", "khdm_11_dk");
            m.upd_danhmuc_dk("C26", "Thương hàn:Chết", "C26<=C25", "khdm_11_dk");

            foreach (DataRow row in m.get_data("Select * from " + xxx + ".DMCOSO order by ma").Tables[0].Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), "", row["ten"].ToString(), "KHDM_11");

            }
            m.sort_danhmuc("KHDM_11");
        }
        #endregion
        #endregion
        #region ke hoach bieu 121
        void kh_bieu121()
        {
            sql = "CREATE TABLE " + xxx + ".khdm_121(ma numeric(5) NOT NULL ,stt varchar(5),ten text,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_121 PRIMARY KEY (ma,stt)) WITH OIDS;ALTER TABLE " + xxx + ".khdm_121 OWNER TO medisoft;";
            m.execute_data(sql);
            sql = "CREATE TABLE " + xxx + ".khbieu_121(id numeric(8) NOT NULL DEFAULT 0,ma numeric(5) NOT NULL ,ngay timestamp without time zone,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp without time zone DEFAULT now(),CONSTRAINT pk_khbieu_121 PRIMARY KEY (id, ma)) WITH OIDS;ALTER TABLE " + xxx + ".khbieu_121 OWNER TO medisoft;";
            m.execute_data(sql);
            m.execute_data("delete from khdm_121");
            m.upd_danhmuc(-1, "A", "Cơ sở y tế nhà nước", "khdm_121");
            m.upd_danhmuc(150, "B", "Cơ sở y tế tư nhân", "khdm_121");
            sql = "Create table " + xxx + ".khdm_121_dk (MA varchar(3) primary key , TEN Text,DK Text)with OIDS;ALTER TABLE " + xxx + ".khdm_121_dk OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "Số lần khám:Tổng số", "C03>=0", "khdm_121_dk");
            m.upd_danhmuc_dk("C04", "Số lần khám/trong đó:YHCT", "C04<=C03", "khdm_121_dk");
            m.upd_danhmuc_dk("C05", "Số lần khám/Trong đó:TE<6 tuổi", "C04<=C03 ", "khdm_121_dk");
            m.upd_danhmuc_dk("C06", "Khám dự phòng", "C06>=0", "khdm_121_dk");
            m.upd_danhmuc_dk("C07", "Số lượt điều trị nội trú:Tổng số", "C07>=0", "khdm_121_dk");
            m.upd_danhmuc_dk("C08", "Số lượt điều trị nội trú/trong đó:YHCT", "C08 <=C07", "khdm_121_dk");
            m.upd_danhmuc_dk("C09", "Số lượt điều trị nội trú/Trong đó:TE<6 tuổi", "C09 <=C07", "khdm_121_dk");
            m.upd_danhmuc_dk("C10", "Tổng số ngày điều trị", "C10 >=C07", "khdm_121_dk");
            foreach (DataRow row in dt.Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), "", row["ten"].ToString(), "KHDM_121");
            }
            m.sort_stt05("KHDM_121");
        }
        #endregion
        #region ke hoach bieu 122
        void kh_bieu122()
        {
            sql = "CREATE TABLE " + xxx + ".khdm_122(ma numeric(5) NOT NULL ,stt varchar(5),ten text,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_122 PRIMARY KEY (ma,stt)) WITH OIDS;ALTER TABLE " + xxx + ".khdm_122 OWNER TO medisoft;";
            m.execute_data(sql);
            sql = "CREATE TABLE " + xxx + ".khbieu_122(id numeric(8) NOT NULL DEFAULT 0,ma numeric(5) NOT NULL ,ngay timestamp without time zone,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp without time zone DEFAULT now(),CONSTRAINT pk_khbieu_122 PRIMARY KEY (id, ma)) WITH OIDS;ALTER TABLE " + xxx + ".khbieu_122 OWNER TO medisoft;";
            m.execute_data(sql);
            m.execute_data("delete from khdm_122");
            m.upd_danhmuc(-1, "A", "Cơ sở y tế nhà nước", "khdm_122");
            m.upd_danhmuc(150, "B", "Cơ sở y tế tư nhân", "khdm_122");
            sql = "Create table " + xxx + ".khdm_122_dk (MA varchar(3) primary key , TEN Text,DK Text)with OIDS;ALTER TABLE " + xxx + ".khdm_122_dk OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "Số lần điều trị ngoại trú:Tổng số", "C03>=0", "khdm_122_dk");
            m.upd_danhmuc_dk("C04", "Số lần điều trị ngoại trú/trong đó:YHCT", "C04 <= C03", "khdm_122_dk");
            m.upd_danhmuc_dk("C05", "Số lần điều trị ngoại trú/Trong đó:TE<6 tuổi", "C05 <= C03 ", "khdm_122_dk");
            m.upd_danhmuc_dk("C06", "Số bệnh nhân chết tại cơ sở y tế:Tổng số", "C06>=0", "khdm_122_dk");
            m.upd_danhmuc_dk("C07", "Số bệnh nhân chết tại cơ sở y tế/trong đó:Trẻ em < 1 tuổi", "C07 >=0 AND C07+c08 <= C06", "khdm_122_dk");
            m.upd_danhmuc_dk("C08", "Số bệnh nhân chết tại cơ sở y tế/trong đó:Trẻ em < 5 tuổi", "C08>=0  AND C07+C08 <=C06", "khdm_122_dk");
            m.upd_danhmuc_dk("C09", "Số lần xét nghiệm", "C09>=0", "khdm_122_dk");
            m.upd_danhmuc_dk("C10", "Số lần chụp X quang", "C10 >=0", "khdm_122_dk");
            m.upd_danhmuc_dk("C11", "Số lần siêu âm", "C11 >=0", "khdm_122_dk");
            m.upd_danhmuc_dk("C12", "Tổng số phẫu thuật", "C12 >=0", "khdm_122_dk");
            foreach (DataRow row in dt.Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), "", row["ten"].ToString(), "KHDM_122");
            }
            m.sort_stt05("KHDM_122");
        }
        #endregion
        #region ke hoach bieu 13
        #region khb 03
        void kh_bieu131()
        {
            foreach (DataRow row in m.get_data("select ma,ten from " + xxx + ".dmcoso where tuyen in (1,2)").Tables[0].Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), "", row["ten"].ToString(), "KH_DM_131");
            }
            m.sort_stt("kh_dm_131");
        }
        #endregion
        #region khb 03
        void kh_bieu132()
        {
            foreach (DataRow row in m.get_data("select ma,ten from " + xxx + ".dmcoso where tuyen in (1,2)").Tables[0].Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), "", row["ten"].ToString(), "KH_DM_132");
            }
            m.sort_stt("kh_dm_132");
        }
        #endregion
        #region khb 03
        void kh_bieu133()
        {
            foreach (DataRow row in m.get_data("select ma,ten from " + xxx + ".dmcoso where tuyen in (1,2)").Tables[0].Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), "", row["ten"].ToString(), "KH_DM_133");
            }
            m.sort_stt("kh_dm_133");
        }
        #endregion
        void kh_bieu13()
        {
            sql = "CREATE TABLE " + xxx + ".khdm_13(ma numeric(5) NOT NULL ,stt varchar(5),ten text,soluong numeric(7) default 0 ,ghichu text,CONSTRAINT pk_khdm_13 PRIMARY KEY (ma,stt)) WITH OIDS;ALTER TABLE " + xxx + ".khdm_13 OWNER TO medisoft;";
            m.execute_data(sql);
            sql = "CREATE TABLE " + xxx + ".khbieu_13(id numeric(8) NOT NULL DEFAULT 0,ma numeric(5) NOT NULL ,ngay timestamp without time zone,soluong numeric(7) DEFAULT 0,ghichu text,userid numeric(5) DEFAULT 0,ngayud timestamp without time zone DEFAULT now(),CONSTRAINT pk_khbieu_13 PRIMARY KEY (id, ma)) WITH OIDS;ALTER TABLE " + xxx + ".khbieu_13 OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc(1, "I", "Phòng chống lao", "khdm_13");
            m.upd_danhmuc(2, "1", "Tổng số bệnh nhân thu nhận", "khdm_13");
            m.upd_danhmuc(3, "2", "Số bệnh nhân lao phổi AFB(+)", "khdm_13");
            m.upd_danhmuc(4, " ", "Trong đó:- Mới", "khdm_13");
            m.upd_danhmuc(5, " ", "         - Tái phát", "khdm_13");
            m.upd_danhmuc(6, " ", "         - Thất bại", "khdm_13");
            m.upd_danhmuc(7, " ", "         - Điều trị lại", "khdm_13");
            m.upd_danhmuc(8, "3", "Lao phổi AFB(-)", "khdm_13");
            m.upd_danhmuc(9, "4", "Bệnh nhân lao ngoài phổi", "khdm_13");
            m.upd_danhmuc(10, "5", "Khác", "khdm_13");
            m.upd_danhmuc(11, "6", "Kết quả điều trị Lao phổi AFB(+) mới", "khdm_13");
            m.upd_danhmuc(12, " ", "Trong đó:- Điều trị thành công", "khdm_13");
            m.upd_danhmuc(13, " ", "         - Số chết", "khdm_13");
            m.upd_danhmuc(14, "II", "Phòng chống sốt rét", "khdm_13");
            m.upd_danhmuc(15, "1", "Số bệnh nhân được xét nghiệm sốt rét", "khdm_13");
            m.upd_danhmuc(16, " ", "Trong đó:- Số có KSTSR", "khdm_13");
            m.upd_danhmuc(17, "2", "Tổng số bệnh nhân SR", "khdm_13");
            m.upd_danhmuc(18, " ", "- Số BNSR được xét nghiệm", "khdm_13");
            m.upd_danhmuc(19, " ", "- Số bệnh nhân ngoại tỉnh", "khdm_13");
            m.upd_danhmuc(20, "3", "Số bệnh nhân sốt rét thường", "khdm_13");
            m.upd_danhmuc(21, "3.1", "Số bệnh nhân sốt rét lâm sàng", "khdm_13");
            m.upd_danhmuc(22, " ", "Trong đó: - trẻ em <5 tuổi", "khdm_13");
            m.upd_danhmuc(23, " ", "          - trẻ em từ 5-14 tuổi", "khdm_13");
            m.upd_danhmuc(24, " ", "          - phụ nữ có thai", "khdm_13");
            m.upd_danhmuc(25, "3.2", "Số BNSR có KST", "khdm_13");
            m.upd_danhmuc(26, " ", "Trong đó: - trẻ em <5 tuổi", "khdm_13");
            m.upd_danhmuc(27, " ", "          - trẻ em từ 5-14 tuổi", "khdm_13");
            m.upd_danhmuc(28, " ", "          - Phụ nữ có thai", "khdm_13");
            m.upd_danhmuc(29, "4", "Số bệnh nhân SRAT ", "khdm_13");
            m.upd_danhmuc(30, " ", "Trong đó: - trẻ em <5 tuổi", "khdm_13");
            m.upd_danhmuc(31, " ", "          - trẻ em từ 5-14 tuổi", "khdm_13");
            m.upd_danhmuc(32, " ", "          - phụ nữ có thai", "khdm_13");
            m.upd_danhmuc(33, " ", "- Số BNSRAT có KST", "khdm_13");
            m.upd_danhmuc(34, "5", "Số bệnh nhân chết sốt rét", "khdm_13");
            m.upd_danhmuc(35, " ", "Trong đó: - trẻ em <5 tuổi", "khdm_13");
            m.upd_danhmuc(36, " ", "          - trẻ em từ 5-14 tuổi", "khdm_13");
            m.upd_danhmuc(37, " ", "          - phụ nữ có thai", "khdm_13");
            m.upd_danhmuc(38, "6", "Số vụ sốt rét", "khdm_13");
            m.upd_danhmuc(39, "III", "Phòng chống HIV/AIDS", "khdm_13");
            m.upd_danhmuc(40, "1", "Số hiện mắc HIV", "khdm_13");
            m.upd_danhmuc(41, " ", "Trong đó:- Nữ", "khdm_13");
            m.upd_danhmuc(42, " ", "         - Mới phát hiện HIV", "khdm_13");
            m.upd_danhmuc(43, "2", "Số hiện mắc AIDS", "khdm_13");
            m.upd_danhmuc(44, " ", "Trong đó:- Nữ", "khdm_13");
            m.upd_danhmuc(45, " ", "         - Mới chuyển sang AIDS", "khdm_13");
            m.upd_danhmuc(46, "3", "Số chết do bị AIDS", "khdm_13");
            m.upd_danhmuc(47, "IV", "Sức khỏe tâm thần", "khdm_13");
            m.upd_danhmuc(48, "1", "Số hiện mắc mắc động kinh", "khdm_13");
            m.upd_danhmuc(49, " ", "Số được quản lý", "khdm_13");
            m.upd_danhmuc(50, " ", "Trong đó: Số mới phát hiện", "khdm_13");
            m.upd_danhmuc(51, " ", "          Số đang điều trị ", "khdm_13");
            m.upd_danhmuc(52, " ", "          Số tử vong", "khdm_13");
            m.upd_danhmuc(53, "2", "Số hiện mắc TTPL", "khdm_13");
            m.upd_danhmuc(54, " ", "Số được quản lý", "khdm_13");
            m.upd_danhmuc(55, " ", "Trong đó: Số mới phát hiện", "khdm_13");
            m.upd_danhmuc(56, " ", "          Số đang điều trị ", "khdm_13");
            m.upd_danhmuc(57, " ", "          Số tử vong", "khdm_13");
            m.upd_danhmuc(58, "3", "Số hiện mắc trầm cảm", "khdm_13");
            m.upd_danhmuc(59, " ", "Số được quản lý", "khdm_13");
            m.upd_danhmuc(60, " ", "Trong đó: Số mới phát hiện", "khdm_13");
            m.upd_danhmuc(61, " ", "          Số đang điều trị ", "khdm_13");
            m.upd_danhmuc(62, " ", "          Số tử vong", "khdm_13");
            m.upd_danhmuc(63, "V", "Phòng chống hoa liễu", "khdm_13");
            m.upd_danhmuc(64, "1", "Số bệnh nhân lậu mới phát hiện trong kỳ", "khdm_13");
            m.upd_danhmuc(65, " ", "trong đó: Lậu mắt trẻ sơ sinh", "khdm_13");
            m.upd_danhmuc(66, "2", "Số bệnh giang mai mới phát hiện", "khdm_13");
            m.upd_danhmuc(67, " ", "trong đó: giang mai bẩm sinh", "khdm_13");
            m.upd_danhmuc(68, "VI", "Phòng chống bệnh phong", "khdm_13");
            m.upd_danhmuc(69, "1", "Số bệnh hiện mắc bệnh phong", "khdm_13");
            m.upd_danhmuc(70, " ", "trong đó: Số bệnh nhân mới phát hiện", "khdm_13");
            m.upd_danhmuc(71, "2", "Số bênh nhân phong mới bị tàn tật độ II", "khdm_13");
            //
            sql = "Create table " + xxx + ".KHDM_13_DK (MA varchar(3) primary key , TEN Text,DK Text) with OIDS;ALTER TABLE " + xxx + ".khdm_13_dk OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "Số lượng", "soluong >=0", "khdm_13_dk");

        }
        #endregion
        #region ke hoach bieu 14.1
        void kh_bieu141()
        {
            sql = "CREATE TABLE " + xxx + ".khdm_141(ma numeric(5) NOT NULL ,stt varchar(5),ten text,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,c12 numeric(7) DEFAULT 0,c13 numeric(7) DEFAULT 0,c14 numeric(7) DEFAULT 0,c15 numeric(7) DEFAULT 0,c16 numeric(7) DEFAULT 0,c17 numeric(7) DEFAULT 0,c18 numeric(7) DEFAULT 0,c19 numeric(7) DEFAULT 0,c20 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_141 PRIMARY KEY (ma,stt)) WITH OIDS;ALTER TABLE " + xxx + ".khdm_141 OWNER TO medisoft;";
            m.execute_data(sql);
            sql = "CREATE TABLE " + xxx + ".khbieu_141(id numeric(8) NOT NULL DEFAULT 0,ma numeric(5) NOT NULL ,ngay timestamp without time zone,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,c12 numeric(7) DEFAULT 0,c13 numeric(7) DEFAULT 0,c14 numeric(7) DEFAULT 0,c15 numeric(7) DEFAULT 0,c16 numeric(7) DEFAULT 0,c17 numeric(7) DEFAULT 0,c18 numeric(7) DEFAULT 0,c19 numeric(7) DEFAULT 0,c20 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp without time zone DEFAULT now(),CONSTRAINT pk_khbieu_141 PRIMARY KEY (id, ma)) WITH OIDS;ALTER TABLE " + xxx + ".khbieu_141 OWNER TO medisoft;";
            m.execute_data(sql);
            m.execute_data("delete from " + xxx + ".khdm_141");
            m.upd_danhmuc(-1, "A", "Tổng số", "khdm_141");
            sql = "Create table " + xxx + ".KHDM_141_DK (MA varchar(3) primary key , TEN Text,DK Text) with OIDS;ALTER TABLE " + xxx + ".khdm_141_dk OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "Phảy khuẩn tả:Mắc", "C03>=0", "khdm_141_dk");
            m.upd_danhmuc_dk("C04", "Phảy khuẩn tả:Chết", "C04 <= C03", "khdm_141_dk");
            m.upd_danhmuc_dk("C05", "Thương hàn:Mắc", "C05 >=0", "khdm_141_dk");
            m.upd_danhmuc_dk("C06", "Thương hàn:Chết", "C06 <= C05", "khdm_141_dk");
            m.upd_danhmuc_dk("C07", "Ly trực trùng:Mắc", "C07>=0", "khdm_141_dk");
            m.upd_danhmuc_dk("C08", "Ly trực trùng:Chết", "C08<= C07", "khdm_141_dk");
            m.upd_danhmuc_dk("C09", "Lỵ A mip:Mắc", "C09>=0", "khdm_141_dk");
            m.upd_danhmuc_dk("C10", "Lỵ A mip:Chết", "C10<=C09", "khdm_141_dk");
            m.upd_danhmuc_dk("C11", "Hội chứng lỵ:Mắc", "C11>=0", "khdm_141_dk");
            m.upd_danhmuc_dk("C12", "Hội chứng lỵ:Chết", "C12<=C11", "khdm_141_dk");
            m.upd_danhmuc_dk("C13", "Tiêu chảy:Mắc", "C13>=0", "khdm_141_dk");
            m.upd_danhmuc_dk("C14", "Tiêu chảy:Chết", "C14<=C13", "khdm_141_dk");
            m.upd_danhmuc_dk("C15", "Viêm não virus:Mắc", "C15>=0", "khdm_141_dk");
            m.upd_danhmuc_dk("C16", "Viêm não virus:Chết", "C16<=C15", "khdm_141_dk");
            m.upd_danhmuc_dk("C17", "Sốt xuất huyết:Mắc", "C17>=0", "khdm_141_dk");
            m.upd_danhmuc_dk("C18", "Sốt xuất huyết:Chết", "C18<=C17", "khdm_141_dk");
            m.upd_danhmuc_dk("C19", "B.Chân - tay - miêng:Mắc", "C19>=0", "khdm_141_dk");
            m.upd_danhmuc_dk("C20", "B. Chân - tay - miệng:Chết", "C20<=C19", "khdm_141_dk");
            m.upd_danhmuc_dk("C21", "Viêm gan Virus:Mắc", "C21>=0", "khdm_141_dk");
            m.upd_danhmuc_dk("C22", "Viêm gan Virus:Chết", "C22<=C21", "khdm_141_dk");
            foreach (DataRow row in m.get_data("Select * from " + xxx + ".DMCOSO order by ma").Tables[0].Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), "", row["ten"].ToString(), "KHDM_141");
            }
            m.sort_danhmuc("KHDM_141");
        }
        #endregion
        #region ke hoach bieu 14.2
        void kh_bieu142()
        {
            sql = "CREATE TABLE " + xxx + ".khdm_142(ma numeric(5) NOT NULL ,stt varchar(5),ten text,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,c12 numeric(7) DEFAULT 0,c13 numeric(7) DEFAULT 0,c14 numeric(7) DEFAULT 0,c15 numeric(7) DEFAULT 0,c16 numeric(7) DEFAULT 0,c17 numeric(7) DEFAULT 0,c18 numeric(7) DEFAULT 0,c19 numeric(7) DEFAULT 0,c20 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_142 PRIMARY KEY (ma,stt)) WITH OIDS;ALTER TABLE " + xxx + ".khdm_142 OWNER TO medisoft;";
            m.execute_data(sql);
            sql = "CREATE TABLE " + xxx + ".khbieu_142(id numeric(8) NOT NULL DEFAULT 0,ma numeric(5) NOT NULL ,ngay timestamp without time zone,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,c12 numeric(7) DEFAULT 0,c13 numeric(7) DEFAULT 0,c14 numeric(7) DEFAULT 0,c15 numeric(7) DEFAULT 0,c16 numeric(7) DEFAULT 0,c17 numeric(7) DEFAULT 0,c18 numeric(7) DEFAULT 0,c19 numeric(7) DEFAULT 0,c20 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp without time zone DEFAULT now(),CONSTRAINT pk_khbieu_142 PRIMARY KEY (id, ma)) WITH OIDS;ALTER TABLE " + xxx + ".khbieu_142 OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc(-1, "A", "Tổng số", "khdm_142");
            sql = "Create table " + xxx + ".KHDM_142_DK (MA varchar(3) primary key , TEN Text,DK Text) with OIDS;ALTER TABLE " + xxx + ".khdm_142_dk OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "Dại và nghi dại:Mắc", "C03>=0", "khdm_142_dk");
            m.upd_danhmuc_dk("C04", "Dại và nghi dại:Chết", "C04 <= C03", "khdm_142_dk");
            m.upd_danhmuc_dk("C05", "Viêm màng não mô cầu:Mắc", "C05 >=0", "khdm_142_dk");
            m.upd_danhmuc_dk("C06", "Viêm màng não mô cầu:Chết", "C06 <= C05", "khdm_142_dk");
            m.upd_danhmuc_dk("C07", "Thủy đậu:Mắc", "C07>=0", "khdm_142_dk");
            m.upd_danhmuc_dk("C08", "Thủy đậu:Chết", "C08<= C07", "khdm_142_dk");
            m.upd_danhmuc_dk("C09", "Uốn ván:Mắc", "C09>=0", "khdm_142_dk");
            m.upd_danhmuc_dk("C10", "Uốn ván:Chết", "C10<=C09", "khdm_142_dk");
            m.upd_danhmuc_dk("C11", "Quai bị :Mắc", "C11>=0", "khdm_142_dk");
            m.upd_danhmuc_dk("C12", "Quai bị :Chết", "C12<=C11", "khdm_142_dk");
            m.upd_danhmuc_dk("C13", "Viêm đường hô hấp trên:Mắc", "C13>=0", "khdm_142_dk");
            m.upd_danhmuc_dk("C14", "Viêm đường hô hấp trên:Chết", "C14<=C13", "khdm_142_dk");
            m.upd_danhmuc_dk("C15", "Viêm phế quản:Mắc", "C15>=0", "khdm_142_dk");
            m.upd_danhmuc_dk("C16", "Viêm phế quản:Chết", "C16<=C15", "khdm_142_dk");
            m.upd_danhmuc_dk("C17", "Viêm phổi:Mắc", "C17>=0", "khdm_142_dk");
            m.upd_danhmuc_dk("C18", "Viêm phổi:Chết", "C18<=C17", "khdm_142_dk");
            m.upd_danhmuc_dk("C19", "Cúm A(H5N1):Mắc", "C19>=0", "khdm_142_dk");
            m.upd_danhmuc_dk("C20", "Cúm A(H5N1):Chết", "C20<=C19", "khdm_142_dk");
            m.upd_danhmuc_dk("C21", "Cúm A(H1N1):Mắc", "C21>=0", "khdm_142_dk");
            m.upd_danhmuc_dk("C22", "Cúm A(H1N1)", "C22<=C21", "khdm_142_dk");
            foreach (DataRow row in m.get_data("Select * from " + xxx + ".DMCOSO order by ma").Tables[0].Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), "", row["ten"].ToString(), "KHDM_142");
            }
            m.sort_danhmuc("KHDM_142");
        }
        #endregion
        #region ke hoach bieu 14.3
        void kh_bieu143()
        {
            sql = "CREATE TABLE " + xxx + ".khdm_143(ma numeric(5) NOT NULL ,stt varchar(5),ten text,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,c12 numeric(7) DEFAULT 0,c13 numeric(7) DEFAULT 0,c14 numeric(7) DEFAULT 0,c15 numeric(7) DEFAULT 0,c16 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_143 PRIMARY KEY (ma,stt)) WITH OIDS;ALTER TABLE " + xxx + ".khdm_143 OWNER TO medisoft;";
            m.execute_data(sql);
            sql = "CREATE TABLE " + xxx + ".khbieu_143(id numeric(8) NOT NULL DEFAULT 0,ma numeric(5) NOT NULL ,ngay timestamp without time zone,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,c12 numeric(7) DEFAULT 0,c13 numeric(7) DEFAULT 0,c14 numeric(7) DEFAULT 0,c15 numeric(7) DEFAULT 0,c16 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp without time zone DEFAULT now(),CONSTRAINT pk_khbieu_143 PRIMARY KEY (id, ma)) WITH OIDS;ALTER TABLE " + xxx + ".khbieu_143 OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc(-1, "A", "Tổng số", "khdm_143");
            sql = "Create table " + xxx + ".KHDM_143_DK (MA varchar(3) primary key , TEN Text,DK Text) with OIDS;ALTER TABLE " + xxx + ".khdm_143_dk OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "Dịch hạch:Mắc", "C03>=0", "khdm_143_dk");
            m.upd_danhmuc_dk("C04", "Dịch hạch:Chết", "C04 <= C03", "khdm_143_dk");
            m.upd_danhmuc_dk("C05", "Lepto:Mắc", "C05 >=0", "khdm_143_dk");
            m.upd_danhmuc_dk("C06", "Lepto:Chết", "C06 <= C05", "khdm_143_dk");
            m.upd_danhmuc_dk("C07", "Tai nạn, ngộ độc chấn thương các loại/Tự tử:Mắc", "C07>=0", "khdm_143_dk");
            m.upd_danhmuc_dk("C08", "Tai nạn, ngộ độc chấn thương các loại/Tự tử:Chết", "C08<= C07", "khdm_143_dk");
            m.upd_danhmuc_dk("C09", "Tai nạn, ngộ độc chấn thương các loại/Ngộ độc thực phẩm:Mắc", "C09>=0", "khdm_143_dk");
            m.upd_danhmuc_dk("C10", "Tai nạn, ngộ độc chấn thương các loại/Ngộ độc thực phẩm:Chết", "C10<=C09", "khdm_143_dk");
            m.upd_danhmuc_dk("C11", "Tai nạn, ngộ độc chấn thương các loại/TNGT:Mắc", "C11>=0", "khdm_143_dk");
            m.upd_danhmuc_dk("C12", "Tai nạn, ngộ độc chấn thương các loại/TNGT:Chết", "C12<=C11", "khdm_143_dk");
            m.upd_danhmuc_dk("C13", "Tai nạn, ngộ độc chấn thương các loại/TN LĐ:Mắc", "C13>=0", "khdm_143_dk");
            m.upd_danhmuc_dk("C14", "Tai nạn, ngộ độc chấn thương các loại/TN LĐ:Chết", "C14<=C13", "khdm_143_dk");
            m.upd_danhmuc_dk("C15", "Tai nạn, ngộ độc chấn thương các loại/NĐ h.chất:Mắc", "C15>=0", "khdm_143_dk");
            m.upd_danhmuc_dk("C16", "Tai nạn, ngộ độc chấn thương các loại/NĐ h.chất", "C16<=C15", "khdm_143_dk");
            m.upd_danhmuc_dk("C17", "Tai nạn, ngộ độc chấn thương các loại/TN khác:Mắc", "C17>=0", "khdm_143_dk");
            m.upd_danhmuc_dk("C18", "Tai nạn, ngộ độc chấn thương các loại/TN khác:Chết", "C18<=C17", "khdm_143_dk");
            foreach (DataRow row in m.get_data("Select * from " + xxx + ".DMCOSO order by ma").Tables[0].Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), "", row["ten"].ToString(), "KHDM_143");
            }
            m.sort_danhmuc("KHDM_143");
        }
        #endregion
        #region khb 14.4
        void kh_bieu144()
        {
            foreach (DataRow row in m.get_data("select ma,ten from " + xxx + ".dmcoso where tuyen in (1,2)").Tables[0].Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), "", row["ten"].ToString(), "KH_DM_144");
            }
            m.sort_stt("kh_dm_144");
        }
        #endregion
        #region bieu 03.1 vu ke hoach
        private void kh_bieu031()
        {
            sql = "CREATE TABLE " + xxx + ".khdm_031(ma numeric(3) NOT NULL ,stt varchar(2),ten text,sttt numeric(4) default 0,idloaics numeric(4) default 0,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_031 PRIMARY KEY (ma)) WITH OIDS;ALTER TABLE " + xxx + ".khdm_031 OWNER TO medisoft;";
            m.execute_data(sql);
            sql = "CREATE TABLE " + xxx + ".khbieu_031(id numeric(8) NOT NULL DEFAULT 0,ma numeric(5) NOT NULL ,ngay timestamp without time zone,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp without time zone DEFAULT now(),CONSTRAINT pk_khbieu_031 PRIMARY KEY (id, ma)) WITH OIDS;ALTER TABLE " + xxx + ".khbieu_031 OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_dmkhbieu_03();
            sql = "Create table " + xxx + ".KHDM_031_DK (MA varchar(3) primary key , TEN text,DK Text) with oids;ALTER TABLE " + xxx + ".khdm_031_dk OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "Bệnh viện/Cơ sở", "(C03>0)", "khdm_031_dk");
            m.upd_danhmuc_dk("C04", "Bệnh viện/Giương bệnh/ kế hoạch", "(C04>0)", "khdm_031_dk");
            m.upd_danhmuc_dk("C05", "Bệnh viện/Giường bệnh/ thực kê", "(C05>0)", "khdm_031_dk");
            m.upd_danhmuc_dk("C06", "Phòng khám/Cơ sở", "(C06>0)", "khdm_031_dk");
            m.upd_danhmuc_dk("C07", "Phòng khám/Giường bệnh", "(C07>0)", "khdm_031_dk");
            m.upd_danhmuc_dk("C08", "Nhà hộ sinh/Cơ sở", "(C08>0)", "khdm_031_dk");
            m.upd_danhmuc_dk("C09", "Nhà hộ sinh/Giường bệnh", "(C09>0)", "khdm_031_dk");
            m.upd_danhmuc_dk("C10", "Trạm y tế/Cơ sở", "(C10>0)", "khdm_031_dk");
            m.upd_danhmuc_dk("C11", "Trạm y tế/Giường bệnh", "(C11>0)", "khdm_031_dk");
            m.upd_danhmuc_dk("C12", "Cơ sở khác/Cơ sở", "(C12>0)", "khdm_031_dk");
            m.upd_danhmuc_dk("C13", "Cơ sở khác/Giường bệnh", "(C13>0)", "khdm_031_dk");

        }
        #endregion
        #region Biểu 3.2 vụ kế hoạch
        private void kh_bieu032()
        {    // danh muc
            sql = "CREATE TABLE " + xxx + ".khdm_032(ma varchar(8) NOT NULL ,stt varchar(10),ten text,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_032 PRIMARY KEY (ma,stt)) WITH OIDS;ALTER TABLE " + xxx + ".khdm_032 OWNER TO medisoft;";
            m.execute_data(sql);
            // bieu
            sql = "CREATE TABLE " + xxx + ".khbieu_032(id numeric(8) NOT NULL DEFAULT 0,ma varchar(8) NOT NULL ,ngay timestamp without time zone,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp without time zone DEFAULT now(),CONSTRAINT pk_khbieu_032 PRIMARY KEY (id, ma)) WITH OIDS;ALTER TABLE " + xxx + ".khbieu_032 OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc("0", "0", "Tổng số", "khdm_032");
            sql = "select a.maphuongxa as ma,a.tenpxa from " + xxx + ".btdpxa a," + xxx + ".btdtt b," + xxx + ".btdquan c where a.maqu=c.maqu and b.matt=c.matt and b.matt ='" + m.Mabv.Substring(0, 3) + "'";
            int stt = 1;
            foreach (DataRow row in m.get_data(sql).Tables[0].Rows)
            {
                if (row["ma"].ToString().Substring(5, 2) != "00")
                {
                    m.upd_danhmuc(row["ma"].ToString(), stt.ToString(), row["tenpxa"].ToString(), "khdm_032");
                    stt++;
                }
            }
            sql = "Create table " + xxx + ".KHDM_032_DK (MA varchar(3) , TEN Text,DK Text) with oids;ALTER TABLE " + xxx + ".khdm_032_dk OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "Trạm y tế/Tổ YHCT", "(C03>0)", "khdm_032_dk");
            m.upd_danhmuc_dk("C04", "Trạm y tế/Bác Sỹ", "(C04>0)", "khdm_032_dk");
            m.upd_danhmuc_dk("C05", "Trạm y tế/ NHS-YSSN", "(C05>0)", "khdm_032_dk");
            m.upd_danhmuc_dk("C06", "Trạm đạt chuẩn quốc gia", "(C06>0)", "khdm_032_dk");
            m.upd_danhmuc_dk("C07", "Số bản thôn có nhân viên y tế", "(C07>0)", "khdm_032_dk");

        }

        #endregion
        #region danh mục loại cơ sở y tế
        private void dmloaicosoyte()
        {
            string sql = "CREATE TABLE " + xxx + ".DMLOAICOSO ";
            sql += " ( ID numeric(5) default 0 , STT numeric(5) default 0 , ";
            sql += "TEN text,Constraint PK_DMLOAICOSO primary key(id,stt))with oids;ALTER TABLE " + xxx + ".DMLOAICOSO OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_dmloaics(0, 0, "Không xác định", "DMLOAICOSO");
            m.upd_dmloaics(1, 1, "Thuộc lĩnh vực y tế quản lý", "DMLOAICOSO");
            m.upd_dmloaics(2, 2, "Y tế các ngành", "DMLOAICOSO");
            m.upd_dmloaics(3, 3, "Y tế tư nhân", "DMLOAICOSO");
            m.execute_data("ALTER TABLE " + xxx + ".DMCOSO ADD IDLOAICOSO numeric(5) default 0 ");
            m.execute_data("update " + xxx + ".DMCOSO set IDLOAICOSO = 0 where IDLOAICOSO is null");

        }
        #endregion
        #region ke hoach bieu 02
        private void kh_bieu02()
        {
            sql = "CREATE TABLE " + xxx + ".khbieu_02" +
                   "(" +
                     "id numeric(8) NOT NULL DEFAULT 0,ma numeric(3) NOT NULL ,ngay timestamp without time zone," +
                     "c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0," +
                     "c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0," +
                     "c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,c12 numeric(7) DEFAULT 0," +
                     "c13 numeric(7) DEFAULT 0,c14 numeric(7) DEFAULT 0,c15 numeric(7) DEFAULT 0," +
                     "c16 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0," +
                     "ngayud timestamp without time zone DEFAULT now()," +
                     "CONSTRAINT pk_khbieu_02 PRIMARY KEY (id, ma)" +
                   ") WITH OIDS;ALTER TABLE " + xxx + ".khbieu_02 OWNER TO medisoft;";
            m.execute_data(sql);
            // danh muc
            sql = "CREATE TABLE " + xxx + ".khdm_02" +
            "(" +
              "ma numeric(7) NOT NULL ,stt varchar(3),ten text,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0," +
              "c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0," +
              "c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0," +
              "c12 numeric(7) DEFAULT 0,c13 numeric(7) DEFAULT 0,c14 numeric(7) DEFAULT 0,c15 numeric(7) DEFAULT 0," +
              "c16 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_02 PRIMARY KEY (ma)" +
            ") WITH OIDS;ALTER TABLE " + xxx + ".khdm_02 OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc(-1, "A", "Tổng số", "khdm_02");
            foreach (DataRow row in m.get_data("select ma,ten from " + xxx + ".dmcoso where tuyen in (1,2)").Tables[0].Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), " ", row["ten"].ToString(), "KHDM_02");
            }
            m.sort_stt02("KHDM_02");
            // dk
            sql = "Create Table " + xxx + ".KHDM_02_DK ";
            sql += "(";
            sql += "MA varchar(3) NOT NULL , TEN text, DK text,CONSTRAINT pk_khdm_02_dk PRIMARY KEY (ma)";
            sql += ")WITH OIDS;ALTER TABLE " + xxx + ".khdm_02_dk OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "<TỔNG SỐ THU (Đơn vị tính : Nghìn đồng)/Tổng số>", "C03>0", "khdm_02_dk");
            m.upd_danhmuc_dk("C04", "<TỔNG SỐ THU (Đơn vị tính : Nghìn đồng)/Từ ngân sách/Trung ương>", "C04+…+C09<=C03", "khdm_02_dk");
            m.upd_danhmuc_dk("C05", "<TỔNG SỐ THU (Đơn vị tính : Nghìn đồng)/Từ ngân sách/Địa phương>", "C04+…+C09<=C03", "khdm_02_dk");
            m.upd_danhmuc_dk("C06", "<TỔNG SỐ THU (Đơn vị tính : Nghìn đồng)/Thu từ BHYT>", " C04+…+C09<=C03", "khdm_02_dk");
            m.upd_danhmuc_dk("C07", "<TỔNG SỐ THU (Đơn vị tính : Nghìn đồng)/Viện phí>", "C04+…+C09<=C03", "khdm_02_dk");
            m.upd_danhmuc_dk("C08", "<TỔNG SỐ THU (Đơn vị tính : Nghìn đồng)/Viện trợ>", "C04+…+C09<=C03", "khdm_02_dk");
            m.upd_danhmuc_dk("C09", "<TỔNG SỐ THU (Đơn vị tính : Nghìn đồng)/Khác", "C04+…+C09<=C03", "khdm_02_dk");
            m.upd_danhmuc_dk("C10", "<TỔNG SỐ CHI (Đơn vị tính : Nghìn đồng)/ Tổng Số>", "C10 > 0", "khdm_02_dk");
            m.upd_danhmuc_dk("C11", "<TỔNG SỐ CHI (Đơn vị tính : Nghìn đồng)/Tổng số chi thường xuyên/Giáo dục và đào tạo>", "C11+..+C18<= C10", "khdm_02_dk");
            m.upd_danhmuc_dk("C12", "<TỔNG SỐ CHI (Đơn vị tính : Nghìn đồng)/Tổng số chi thường xuyên/Phòng bệnh>", "C11+..+C18<= C10", "khdm_02_dk");
            m.upd_danhmuc_dk("C13", "<TỔNG SỐ CHI (Đơn vị tính : Nghìn đồng)/Tổng số chi thường xuyên/Chữa bệnh>", "C11+..+C18<= C10", "khdm_02_dk");
            m.upd_danhmuc_dk("C14", "<TỔNG SỐ CHI (Đơn vị tính : Nghìn đồng)/Tổng số chi thường xuyên/DS & KHHGD", "C11+..+C18<= C10", "khdm_02_dk");
            m.upd_danhmuc_dk("C15", "<TỔNG SỐ CHI (Đơn vị tính : Nghìn đồng)/Tổng số chi thường xuyên/Quản lý nhà nước>", "C11+..+C18<= C10", "khdm_02_dk");
            m.upd_danhmuc_dk("C16", "<TỔNG SỐ CHI (Đơn vị tính : Nghìn đồng)/Tổng số chi thường xuyên/Chương trình y tế QG>", "C11+..+C18<= C10", "khdm_02_dk");
            m.upd_danhmuc_dk("C17", "<TỔNG SỐ CHI (Đơn vị tính : Nghìn đồng)/Tổng số chi thường xuyên/Khác>", "C11+..+C18<= C10", "khdm_02_dk");
            m.upd_danhmuc_dk("C18", "<TỔNG SỐ CHI (Đơn vị tính : Nghìn đồng)/Đầu tư phát triển>", "C11+..+C118<= C10", "khdm_02_dk");

        }
        #endregion
        #region khb 03
        void kh_bieu030()
        {
            foreach (DataRow row in m.get_data("select ma,ten from " + xxx + ".dmcoso where tuyen in (1,2)").Tables[0].Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), "", row["ten"].ToString(), "KH_DM_03");
            }
            m.sort_danhmuc("kh_dm_03");
        }
        #endregion
        #region ke hoach bieu 01
        private void kh_bieu01()
        {
            // bieu 01
            sql = "CREATE TABLE " + xxx + ".khbieu_01" +
                     "(" +
                       "id numeric(8) NOT NULL DEFAULT 0,ma varchar(7) NOT NULL ,ngay timestamp without time zone," +
                       "c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0," +
                       "c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0," +
                       "c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,c12 numeric(7) DEFAULT 0," +
                       "c13 numeric(7) DEFAULT 0,c14 numeric(7) DEFAULT 0,c15 numeric(7) DEFAULT 0," +
                       "c16 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0," +
                       "ngayud timestamp without time zone DEFAULT now()," +
                       "CONSTRAINT pk_khbieu_01 PRIMARY KEY (id, ma)" +
                     ") " +
                     "WITH OIDS;ALTER TABLE " + xxx + ".khbieu_01 OWNER TO medisoft;";
            m.execute_data(sql);
            // Danh muc
            sql = "CREATE TABLE " + xxx + ".khdm_01" +
            "(" +
              "ma varchar(7) NOT NULL ,stt varchar(2),ten text,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0," +
              "c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0," +
              "c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0," +
              "c12 numeric(7) DEFAULT 0,c13 numeric(7) DEFAULT 0,c14 numeric(7) DEFAULT 0,c15 numeric(7) DEFAULT 0," +
              "c16 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_01 PRIMARY KEY (ma)" +
            ") " +
            "WITH OIDS;ALTER TABLE " + xxx + ".khdm_01 OWNER TO medisoft;";
            m.execute_data(sql);
            m.execute_data("delete from " + xxx + ".khdm_01");
            m.upd_danhmuc("0", "A", "Tổng số", "khdm_01");
            int i = 1;
            foreach (DataRow r in m.get_data("Select * from " + xxx + ".btdpxa where maqu='" + m.Maqu + "' and maphuongxa<>'" + m.Maqu + "00'").Tables[0].Rows)
            {
                m.upd_danhmuc(r["maphuongxa"].ToString(), i.ToString(), r["tenpxa"].ToString(), "khdm_01");
                i++;
            }
            //							
            // KE HOACH DANH MUC DIEU KIEN
            sql = "Create Table " + xxx + ".KHDM_01_DK ";
            sql += "(";
            sql += "MA varchar(3) NOT NULL , TEN text, DK text,CONSTRAINT pk_khdm_01_dk PRIMARY KEY (ma)";
            sql += ")WITH OIDS;ALTER TABLE " + xxx + ".khdm_01_dk OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "Đơn vị hành chính/ Phân loại xã", "C03 >=0", "khdm_01_dk");
            m.upd_danhmuc_dk("C04", "Đơn vị hành chính/ Số bản thôn", "C04 >=0", "khdm_01_dk");
            m.upd_danhmuc_dk("C05", "Dân số 1/7", "C05 >=0", "khdm_01_dk");
            m.upd_danhmuc_dk("C06", "Dân số 1/7 / Trong đó nữ", "C06+C07+c08+C09 <= C05", "khdm_01_dk");
            m.upd_danhmuc_dk("C07", "Dân số 1/7/ Trong đó trẻ em <5 tuổi", "C06+C07+c08+C09 <= C05", "khdm_01_dk");
            m.upd_danhmuc_dk("C08", "Dân số 1/7/ Trong đó trẻ em <6 tuổi", "C06+C07+c08+C09 <= C05", "khdm_01_dk");
            m.upd_danhmuc_dk("C09", "Dân số 1/7/ Trong đó trẻ em <15 tuổi", "C06+C07+c08+C09 <= C05", "khdm_01_dk");
            m.upd_danhmuc_dk("C10", "Trẻ em đẻ ra sống/ Tổng số", "C10 <= C07", "khdm_01_dk");
            m.upd_danhmuc_dk("C11", "Trẻ em đẻ ra sống/ Trong đó nữ", "C11 <= C10", "khdm_01_dk");
            m.upd_danhmuc_dk("C12", "Số chết/Tổng số", "C12 <= C07", "khdm_01_dk");
            m.upd_danhmuc_dk("C13", "Số chết / Trong đó nữ", "C13 <= C12", "khdm_01_dk");
            m.upd_danhmuc_dk("C14", "Số chết/ Trong đó/ <1 tuổi/ tổng số", "C14+C16+C18 <= C12", "khdm_01_dk");
            m.upd_danhmuc_dk("C15", "Số chết/ Trong đó/ <1 tuổi/ trong đó nữ", "C15 <= C14", "khdm_01_dk");
            m.upd_danhmuc_dk("C16", "Số chết/ Trong đó/ <5 tuổi/ tổng số", "C14+c16+c18 <= c12", "khdm_01_dk");
            m.upd_danhmuc_dk("C17", "Số chết/ Trong đó/ <5 tuổi/ trong đó nữ ", "C17 <= C16", "khdm_01_dk");
            m.upd_danhmuc_dk("C18", "Số chết/ Trong đó/ Chết mẹ", "C14+c16+c18 <= c12", "khdm_01_dk");
        }
        #endregion

        private void bieu11_1()
        {
            string user = m.user;
            sql = "create table " + user + ".dm_11_dk_1 as select * from " + user + ".dm_11_dk ";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C01", "<Tại khoa khám bệnh/Tổng số>", "(C01>=MAX(C02,C03,C04)", "dm_11_dk_1");
            m.upd_danhmuc_dk("C02", "<Tại khoa khám bệnh/Trong đó Nữ>", "(C02<=C01)", "dm_11_dk_1");
            m.upd_danhmuc_dk("C03", "<Tại khoa khám bệnh/Trong đó TE<15 tuổi>", "(C03<=C01)", "dm_11_dk_1");
            m.upd_danhmuc_dk("C04", "<Tại khoa khám bệnh/trong đó Số tử vong>", "(C04<=C01)", "dm_11_dk_1");
            m.upd_danhmuc_dk("C05", "<Điều trị nội trú/Tổng số/Mắc/Tổng số  >", "(C05>=MAX(C07,C09,C11))", "dm_11_dk_1");
            m.upd_danhmuc_dk("C06", "<Điều trị nội trú/Tổng số/Mắc / trong đó Nữ >", "(C06<= C05)", "dm_11_dk_1");
            m.upd_danhmuc_dk("C07", "<Điều trị nội trú/Tổng số/Số tử vong/ Tổng số  >", "(C07<=C05)", "dm_11_dk_1");
            m.upd_danhmuc_dk("C08", "<Điều trị nội trú/Tổng số/Số tử vong / trong đó Nữ >", "(C08<=C07)", "dm_11_dk_1");
            m.upd_danhmuc_dk("C09", "<Điều trị nội trú/Trong đó TE<15 tuổi /Mắc/ Tổng số >", "(C09<=C05)", "dm_11_dk_1");
            m.upd_danhmuc_dk("C10", "<Điều trị nội trú/Trong đó TE<15 tuổi /Mắc/ TE<5 tuổi >", "(C10<=C09)", "dm_11_dk_1");
            m.upd_danhmuc_dk("C11", "<Điều trị nội trú/Trong đó TE<15 tuổi /Số tử vong/ Tổng số >", "(C11<=C09 AND C11<=C07)", "dm_11_dk_1");
            m.upd_danhmuc_dk("C12", "<Điều trị nội trú/Trong đó TE<15 tuổi /Số tử vong/ <5 tuổi >", "(C12<=C11)", "dm_11_dk_1");
        }
        private void bieu11()
        {
            m.upd_danhmuc_dk("C01", "<Tại khoa khám bệnh/Tổng số>", "(C01>=MAX(C02,C03,C04)", "DM_11_DK");
            m.upd_danhmuc_dk("C02", "<Tại khoa khám bệnh/Trong đó Nữ>", "(C02<=C01)", "DM_11_DK");
            m.upd_danhmuc_dk("C03", "<Tại khoa khám bệnh/Trong đó TE<15 tuổi>", "(C03<=C01)", "DM_11_DK");
            m.upd_danhmuc_dk("C04", "<Tại khoa khám bệnh/trong đó Số tử vong>", "(C04<=C01)", "DM_11_DK");
            m.upd_danhmuc_dk("C05", "<Điều trị nội trú/Tổng số/Mắc/Tổng số  >", "(C05>=MAX(C07,C09,C11))", "DM_11_DK");
            m.upd_danhmuc_dk("C06", "<Điều trị nội trú/Tổng số/Mắc / trong đó Nữ >", "(C06<= C05)", "DM_11_DK");
            m.upd_danhmuc_dk("C07", "<Điều trị nội trú/Tổng số/Số tử vong/ Tổng số  >", "(C07<=C05)", "DM_11_DK");
            m.upd_danhmuc_dk("C08", "<Điều trị nội trú/Tổng số/Số tử vong / trong đó Nữ >", "(C08<=C07)", "DM_11_DK");
            m.upd_danhmuc_dk("C09", "<Điều trị nội trú/Trong đó TE<15 tuổi /Mắc/ Tổng số >", "(C09<=C05)", "DM_11_DK");
            m.upd_danhmuc_dk("C10", "<Điều trị nội trú/Trong đó TE<15 tuổi /Mắc/ TE<5 tuổi >", "(C10<=C09)", "DM_11_DK");
            m.upd_danhmuc_dk("C11", "<Điều trị nội trú/Trong đó TE<15 tuổi /Số tử vong/ Tổng số >", "(C11<=C09 AND C11<=C07)", "DM_11_DK");
            m.upd_danhmuc_dk("C12", "<Điều trị nội trú/Trong đó TE<15 tuổi /Số tử vong/ <5 tuổi >", "(C12<=C11)", "DM_11_DK");
        }
        private void kh_bieu15()
        {
            sql = "CREATE TABLE " + xxx + ".khbieu_15" +
                     "(" +
                       "id numeric(8) NOT NULL DEFAULT 0,ma numeric(5) NOT NULL ,ngay timestamp without time zone," +
                       "c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0," +
                       "c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0," +
                       "c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,C12 decimal(7) default 0," +
                       "userid numeric(5) DEFAULT 0," +
                       "ngayud timestamp without time zone DEFAULT now()," +
                       "CONSTRAINT pk_khbieu_15 PRIMARY KEY (id, ma)" +
                     ") " +
                     "WITH OIDS;ALTER TABLE " + xxx + ".khbieu_15 OWNER TO medisoft;";
            m.execute_data(sql);

        }
        #endregion
        #region LICENSE
        private void f_Uncheck_License()
        {
            try
            {
                txtKey.Text = m.s_computer_key;
                txtKey.BackColor = Color.SteelBlue;
                txtKey.ForeColor = Color.White;
                groLicense.Visible = false;
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
                txtKey.Text = m.s_computer_key;
                if (!m.is_licensed)
                {
                    txtKey.BackColor = Color.Black;
                    txtKey.ForeColor = Color.White;
                    groLicense.Visible = true;
                    this.Height = 225;

                    txtuser.Enabled = false;
                    txtpassword.Enabled = false;
                    cmdOk.Enabled = false;

                    txtLicense.Focus();
                }
                else
                {
                    txtKey.BackColor = Color.SteelBlue;
                    txtKey.ForeColor = Color.White;
                    groLicense.Visible = false;
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

        private void butTiepTuc_Click(object sender, EventArgs e)
        {
            groLicense.Visible = false;
            this.Width = 280;
            this.Height = 146;
        }

        private void butDangKi_Click(object sender, EventArgs e)
        {
            if (txtLicense.Text.Trim() != "")
            {
                string s_key = Medisoft2009.License.Encryption.DeCode(txtKey.Text, Medisoft2009.License.Encryption.Key);
                if (Medisoft2009.License.Encryption.ValidLicense(s_key, txtLicense.Text))
                {
                    m.ComputerKey = txtKey.Text;
                    m.License = txtLicense.Text;
                    if (!m.RegisterLicense())
                    {
                        MessageBox.Show("Bản quyền sử dụng đăng ký không thành công. Vui lòng kiểm tra lại License", "Medisoft");
                        groLicense.Visible = true;
                        bChuaDangKiLicense = true;
                    }
                    else
                    {
                        MessageBox.Show("Đăng kí thành công!","Medisoft");
                        groLogin.Enabled = true;
                        bChuaDangKiLicense = false;
                        groLicense.Visible = false;
                        this.Width = 280;
                        this.Height = 146;
                    }
                }
                else
                {
                    MessageBox.Show("Bản quyền không hợp lệ. Vui lòng liên hệ với quản trị hệ thống", "Medisoft");
                    txtLicense.Focus();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập License", "Medisoft");
            }
        }
	}
}
