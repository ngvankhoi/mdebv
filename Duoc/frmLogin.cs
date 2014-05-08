using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using LibDuoc;
using LibMedi;
using System.Data;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmLogin.
	/// </summary>
	public class frmLogin : System.Windows.Forms.Form
	{
        bool bChuaDangKiLicense = false;
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private LibDuoc.AccessData d;
        private LibMedi.AccessData m = new LibMedi.AccessData();
		private string sql,user;
		public string mRight="",mUserid="",mMmyy,mNgay,mMakho,mMakp,mManhom,mTennhom,mLoaint,mLoaikhac;
		public int iUserid=0,iNhomkho;
        public int i_chinhanh = 0;//Tu:20/05/2011 them i_khudt// hien sua thanh i_chinhanh--static
		private DataSet ds=new DataSet();
        public bool mExit = false, bTao = false, bAdmin = false, bThuhoi = false;
        private bool bAuto_tonkho;
        private GroupBox groLogin;
        private Label lblkiemtra;
        private NumericUpDown mm;
        private NumericUpDown yyyy;
        private DateTimePicker ngay;
        private Label label5;
        private Label label4;
        private Label label3;
        private Wildgrape.Aqua.Controls.Button cmdCancle;
        private Wildgrape.Aqua.Controls.Button cmdOk;
        private TextBox txtpassword;
        private TextBox txtuser;
        private Label label2;
        private Label label1;
        private GroupBox groLicense;
        private GroupBox groupBox1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label8;
        private Wildgrape.Aqua.Controls.Button button1;
        private Label label9;
        private Wildgrape.Aqua.Controls.Button button2;
        private Label lblLicense;
        private RichTextBox txtLicense;
        private RichTextBox txtKey;
        private Button butTiepTuc;
        private Button butDangKi;
        private Label label10;
        private Label label11;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmLogin(LibDuoc.AccessData acc)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
            string s_cn = d.f_getten_chinhanh(d.i_Chinhanh_hientai);
            this.Text = d.Msg + ((s_cn.Trim() == "") ? "" : " - " + s_cn);
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
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
            this.groLogin = new System.Windows.Forms.GroupBox();
            this.lblkiemtra = new System.Windows.Forms.Label();
            this.mm = new System.Windows.Forms.NumericUpDown();
            this.yyyy = new System.Windows.Forms.NumericUpDown();
            this.ngay = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdCancle = new Wildgrape.Aqua.Controls.Button();
            this.cmdOk = new Wildgrape.Aqua.Controls.Button();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groLicense = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new Wildgrape.Aqua.Controls.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new Wildgrape.Aqua.Controls.Button();
            this.lblLicense = new System.Windows.Forms.Label();
            this.txtLicense = new System.Windows.Forms.RichTextBox();
            this.txtKey = new System.Windows.Forms.RichTextBox();
            this.butTiepTuc = new System.Windows.Forms.Button();
            this.butDangKi = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).BeginInit();
            this.groLicense.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groLogin
            // 
            this.groLogin.Controls.Add(this.lblkiemtra);
            this.groLogin.Controls.Add(this.mm);
            this.groLogin.Controls.Add(this.yyyy);
            this.groLogin.Controls.Add(this.ngay);
            this.groLogin.Controls.Add(this.label5);
            this.groLogin.Controls.Add(this.label4);
            this.groLogin.Controls.Add(this.label3);
            this.groLogin.Controls.Add(this.cmdCancle);
            this.groLogin.Controls.Add(this.cmdOk);
            this.groLogin.Controls.Add(this.txtpassword);
            this.groLogin.Controls.Add(this.txtuser);
            this.groLogin.Controls.Add(this.label2);
            this.groLogin.Controls.Add(this.label1);
            this.groLogin.Location = new System.Drawing.Point(0, -7);
            this.groLogin.Name = "groLogin";
            this.groLogin.Size = new System.Drawing.Size(245, 184);
            this.groLogin.TabIndex = 11;
            this.groLogin.TabStop = false;
            // 
            // lblkiemtra
            // 
            this.lblkiemtra.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblkiemtra.ForeColor = System.Drawing.Color.Red;
            this.lblkiemtra.Location = new System.Drawing.Point(7, 150);
            this.lblkiemtra.Name = "lblkiemtra";
            this.lblkiemtra.Size = new System.Drawing.Size(238, 21);
            this.lblkiemtra.TabIndex = 24;
            this.lblkiemtra.Text = "Đang kiểm tra số liệu tồn, xin chờ !";
            this.lblkiemtra.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mm
            // 
            this.mm.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mm.Location = new System.Drawing.Point(108, 87);
            this.mm.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.mm.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mm.Name = "mm";
            this.mm.Size = new System.Drawing.Size(35, 22);
            this.mm.TabIndex = 16;
            this.mm.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mm_KeyDown);
            // 
            // yyyy
            // 
            this.yyyy.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yyyy.Location = new System.Drawing.Point(177, 87);
            this.yyyy.Maximum = new decimal(new int[] {
            3004,
            0,
            0,
            0});
            this.yyyy.Minimum = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yyyy.Name = "yyyy";
            this.yyyy.Size = new System.Drawing.Size(50, 22);
            this.yyyy.TabIndex = 17;
            this.yyyy.Value = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yyyy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.yyyy_KeyDown);
            // 
            // ngay
            // 
            this.ngay.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.CustomFormat = "dd/MM/yyyy";
            this.ngay.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngay.Location = new System.Drawing.Point(108, 63);
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(119, 22);
            this.ngay.TabIndex = 14;
            this.ngay.Validated += new System.EventHandler(this.ngay_Validated);
            this.ngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(146, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "Năm :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Số liệu tháng :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Ngày làm việc :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdCancle
            // 
            this.cmdCancle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancle.Location = new System.Drawing.Point(118, 120);
            this.cmdCancle.Name = "cmdCancle";
            this.cmdCancle.SizeToLabel = false;
            this.cmdCancle.TabIndex = 20;
            this.cmdCancle.Text = "Kết thúc";
            this.cmdCancle.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOk
            // 
            this.cmdOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOk.Location = new System.Drawing.Point(38, 120);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.SizeToLabel = false;
            this.cmdOk.TabIndex = 18;
            this.cmdOk.Text = "Chọn";
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // txtpassword
            // 
            this.txtpassword.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpassword.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtpassword.Location = new System.Drawing.Point(108, 39);
            this.txtpassword.MaxLength = 30;
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '*';
            this.txtpassword.Size = new System.Drawing.Size(119, 22);
            this.txtpassword.TabIndex = 13;
            this.txtpassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpassword_KeyDown);
            // 
            // txtuser
            // 
            this.txtuser.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtuser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtuser.Location = new System.Drawing.Point(108, 15);
            this.txtuser.MaxLength = 10;
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(119, 22);
            this.txtuser.TabIndex = 11;
            this.txtuser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtuser_KeyDown);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Mật khẩu truy cập :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tên người sử dụng :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groLicense
            // 
            this.groLicense.Controls.Add(this.groupBox1);
            this.groLicense.Controls.Add(this.lblLicense);
            this.groLicense.Controls.Add(this.txtLicense);
            this.groLicense.Controls.Add(this.txtKey);
            this.groLicense.Controls.Add(this.butTiepTuc);
            this.groLicense.Controls.Add(this.butDangKi);
            this.groLicense.Controls.Add(this.label10);
            this.groLicense.Controls.Add(this.label11);
            this.groLicense.Location = new System.Drawing.Point(4, -2);
            this.groLicense.Name = "groLicense";
            this.groLicense.Size = new System.Drawing.Size(389, 235);
            this.groLicense.TabIndex = 12;
            this.groLicense.TabStop = false;
            this.groLicense.Text = "License";
            this.groLicense.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(378, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 252);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox1.Location = new System.Drawing.Point(183, 75);
            this.textBox1.MaxLength = 10;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 23);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox2.Location = new System.Drawing.Point(183, 102);
            this.textBox2.MaxLength = 20;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(120, 23);
            this.textBox2.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(82, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 14);
            this.label8.TabIndex = 0;
            this.label8.Text = "&Tên người sử dụng :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(201, 142);
            this.button1.Name = "button1";
            this.button1.SizeToLabel = false;
            this.button1.TabIndex = 5;
            this.button1.Text = "Kết thúc";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(87, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 20);
            this.label9.TabIndex = 2;
            this.label9.Text = "&Mật khẩu truy cập :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(120, 142);
            this.button2.Name = "button2";
            this.button2.SizeToLabel = false;
            this.button2.TabIndex = 4;
            this.button2.Text = "Chọn";
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
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(-17, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 14);
            this.label10.TabIndex = 9;
            this.label10.Text = "License :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(21, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 22);
            this.label11.TabIndex = 7;
            this.label11.Text = "Key";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmLogin
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(386, 234);
            this.ControlBox = false;
            this.Controls.Add(this.groLogin);
            this.Controls.Add(this.groLicense);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin ";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.groLogin.ResumeLayout(false);
            this.groLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).EndInit();
            this.groLicense.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void txtuser_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");	
		}

		private void txtpassword_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");	
		}

		private void cmdOk_Click(object sender, System.EventArgs e)
		{
            m.setStandar();
            string Ngaydemo = m.Ngaydemo("duoc");
            
            if (Ngaydemo != "")
            {
                int songay = m.Songaydemo;
                if (songay != 0)
                {
                    decimal conlai = songay - m.songay(m.StringToDate(m.ngayhienhanh_server.Substring(0, 10)), m.StringToDate(Ngaydemo), 0);
                    if (conlai <= 0)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Đã hết thời gian chạy thử")+"\n"+lan.Change_language_MessageText("Liên hệ nhà cung cấp:")+"\n"+lan.Change_language_MessageText("Phone : 08.7155019")+"\n"+lan.Change_language_MessageText("Mobile : 090 3937066"), LibMedi.AccessData.Msg);
                        return;
                    }
                    else if (conlai <= 3)
                        MessageBox.Show(lan.Change_language_MessageText("Thời gian chạy thử còn")+" " + conlai.ToString() + " "+lan.Change_language_MessageText("ngày"), LibMedi.AccessData.Msg);
                }
            }
            DataTable dtver = m.get_data("select * from " + user + ".version").Tables[0];
            if (dtver.Rows.Count > 0)
            {
                if (dtver.Rows[0]["duoc"].ToString().Trim() != "")
                {
                    string tenfile = m.file_exe("duoc");
                    if (dtver.Rows[0]["duoc"].ToString().Trim() != m.file_modify(tenfile))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Không đúng version đang sử dụng !"), d.Msg);
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
            int i = d.check_process("DUOC"), iProcess = d.soprocess(iNhomkho);
            if (i > iProcess)
            {
                MessageBox.Show(lan.Change_language_MessageText("Số chương trình kích hoạt :")+" " + i.ToString() + " "+lan.Change_language_MessageText("nhiều hơn cho phép :") + iProcess.ToString());
                Application.Exit();
            }
			bool bKiemtra=false;
            //
            mMmyy = mm.Value.ToString().PadLeft(2, '0') + yyyy.Value.ToString().PadLeft(4, '0').Substring(2, 2);
            string a_mmyy = d.mmyy(ngay.Text);
            if (mm.Enabled == false)
            {
                mm.Value = decimal.Parse(a_mmyy.Substring(0, 2));
                yyyy.Value = 2000 + decimal.Parse(a_mmyy.Substring(2, 2));
                this.Refresh();
                mMmyy = mm.Value.ToString().PadLeft(2, '0') + yyyy.Value.ToString().PadLeft(4, '0').Substring(2, 2);
            }
            else if (a_mmyy != "" && mMmyy != a_mmyy && mm.Enabled)
            {
                long l_ngaykk =Math.Min( d.iNgaykiemke,30)+3;
                long l_songay = d.songay(d.StringToDate(ngay.Text), d.StringToDate("28/" + mMmyy.Substring(0, 2) + "/" + yyyy.Value.ToString()), 0);
                if (l_songay < 0) l_songay = l_songay * -1;
                if (l_songay < l_ngaykk)
                {
                    DialogResult dlg = MessageBox.Show("Ngày làm việc (" + ngay.Text + ") nhưng số liệu tháng lại là : " + mMmyy + ".\nKích YES lấy số liệu tháng : " + a_mmyy.Substring(0, 2) + "/20" + a_mmyy.Substring(2, 2) + "\n Kích NO lấy số liệu tháng: " + mMmyy.Substring(0, 2) + "/20" + mMmyy.Substring(2, 2), "Medisoft THIS", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (dlg == DialogResult.Yes)
                    {
                        mm.Value = decimal.Parse(a_mmyy.Substring(0, 2));
                        yyyy.Value = 2000 + decimal.Parse(a_mmyy.Substring(2, 2));
                        this.Refresh();
                        mMmyy = mm.Value.ToString().PadLeft(2, '0') + yyyy.Value.ToString().PadLeft(4, '0').Substring(2, 2);
                    }
                    else if (dlg == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                else
                {
                    mm.Value = decimal.Parse(a_mmyy.Substring(0, 2));
                    yyyy.Value = 2000 + decimal.Parse(a_mmyy.Substring(2, 2));
                    this.Refresh();
                    mMmyy = mm.Value.ToString().PadLeft(2, '0') + yyyy.Value.ToString().PadLeft(4, '0').Substring(2, 2);
                }
            }
            //
			mMmyy=mm.Value.ToString().PadLeft(2,'0')+yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
			mNgay=ngay.Text;
			string ddmmyy = DateTime.Now.Day.ToString().PadLeft(2,'0')+DateTime.Now.Month.ToString().PadLeft(2,'0')+DateTime.Now.Year.ToString().PadLeft(4, '0').Substring(2);
			if (txtuser.Text==LibDuoc.AccessData.links_userid && txtpassword.Text==LibDuoc.AccessData.links_pass+ddmmyy)
				iNhomkho=0;
			else
			{
                string mmyyt = d.Mmyy_truoc(mMmyy);
                bAuto_tonkho = d.bAuto_tonkho(iNhomkho);
				if (!bTao && !d.bMmyy(mMmyy))
				{
					MessageBox.Show(lan.Change_language_MessageText("Bạn không có quyền tạo số liệu tháng mới !"),d.Msg);
					return;
				}
                bool b_TaoSoLieuThangMoi = false;
                int iret = d.bKiemtrasolieu(iNhomkho, mMmyy, iUserid);//, ref b_TaoSoLieuThangMoi
                if (b_TaoSoLieuThangMoi)
                {
                    m.tao_schema(mMmyy, iUserid);
                }
                if (iret == 0)
                {
                    if (MessageBox.Show(lan.Change_language_MessageText("Bạn có muốn tạo số liệu tháng")+" " + mMmyy.Substring(0, 2) + " "+lan.Change_language_MessageText("năm")+" " + mMmyy.Substring(2, 2) + "?", d.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        Cursor = Cursors.WaitCursor;                        
                        if (!d.bKhoaso(iNhomkho, mmyyt) && bAuto_tonkho)
                        {
                            bKiemtra = true;
                            d.upd_tonkho(iNhomkho, mmyyt);
                        }

                        //foreach (DataRow r in d.get_data("select * from " + user + ".d_dmkho where nhom=" + iNhomkho).Tables[0].Rows)
                        //{
                        //    d.upd_kiemtratutrucdau(mMmyy, 0, int.Parse(r["id"].ToString()), iUserid, true);
                        //    foreach (DataRow r1 in d.get_data("select * from " + user + ".d_duockp where nhom like '%" + iNhomkho.ToString() + ",%'").Tables[0].Rows)
                        //        d.upd_kiemtratutrucdau(mMmyy, int.Parse(r1["id"].ToString()), int.Parse(r["id"].ToString()), iUserid,false);
                        //    d.upd_kiemtratondau(mMmyy, int.Parse(r["id"].ToString()), iUserid,true);
                        //}
                        

                        //bbbb
                        foreach (DataRow r in d.get_data("select * from " + user + ".d_dmkho where hide=0 and nhom=" + iNhomkho).Tables[0].Rows)
                        {
                            foreach (DataRow r1 in d.get_data("select * from " + user + ".d_duockp where nhom like '%" + iNhomkho.ToString() + ",%'").Tables[0].Rows)
                            {
                                d.upd_kiemtratutrucdau(mMmyy, int.Parse(r1["id"].ToString()), int.Parse(r["id"].ToString()), iUserid);
                            }
                            d.upd_kiemtratondau(mMmyy, int.Parse(r["id"].ToString()), iUserid);
                        }
                        //bbbb
                        d.upd_tonkho(mMmyy, iNhomkho, 0);
                        if (d.bMmyy(mmyyt))
                        {
                            d.upd_khoaso(iNhomkho, mmyyt, iUserid);
                            d.upd_cosotutruc(iNhomkho, mmyyt, mMmyy);
                        }
                        d.execute_data("delete from " + user + mMmyy + ".d_tonkhoct where tondau=0 and slnhap=0 and slxuat=0");
                        d.execute_data("delete from " + user + mMmyy + ".d_tonkhoth where tondau=0 and slnhap=0 and slxuat=0");
                        d.execute_data("delete from " + user + mMmyy + ".d_tutrucct where tondau=0 and slnhap=0 and slxuat=0");
                        d.execute_data("delete from " + user + mMmyy + ".d_tutructh where tondau=0 and slnhap=0 and slxuat=0");
                        //
                        d.upd_taosolieu_duoc(iNhomkho, mMmyy, iUserid);

                        //
                        Cursor = Cursors.Default;
                    }
                    else return;
                }
                else if (iret == -1) return;
                if (!d.bKhoaso(iNhomkho, mmyyt) && d.bMmyy(mmyyt))
                {
                    if (MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng")+" " + mmyyt.Substring(0, 2) + " "+lan.Change_language_MessageText("năm 20") + mmyyt.Substring(2) + " "+lan.Change_language_MessageText("chưa khóa")+"\n"+lan.Change_language_MessageText("Yêu cầu vào cấu hình hệ thống khóa lại")+"\n"+lan.Change_language_MessageText("Bạn có muốn tiếp tục không ?"), LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                }
			}
			if (iNhomkho!=0 && !bKiemtra)
			{
                if (!d.bKhoaso(iNhomkho, mMmyy) && d.get_kiemtra(mMmyy, iNhomkho, ngay.Text))
                {
                    d.f_capnhat_tonkhoct(mMmyy, iNhomkho);
                    d.upd_kiemtra(mMmyy, iNhomkho, ngay.Text, iUserid);
                    sql = " select a.makho from " + user + mMmyy + ".d_tonkhoct a," + user + ".d_dmkho b where a.makho=b.id and a.tondau+a.slnhap-a.slxuat<0 and b.nhom=" + iNhomkho;
                    sql += " union all ";
                    sql += " select a.makho from " + user + mMmyy + ".d_tutrucct a," + user + ".d_dmkho b where a.makho=b.id and a.tondau+a.slnhap-a.slxuat<0 and b.nhom=" + iNhomkho;
                    if (d.get_data(sql).Tables[0].Rows.Count > 0)
                    {
                        lblkiemtra.Text = "Đang kiểm tra số liệu tồn, xin chờ !";
                        Cursor = Cursors.WaitCursor;
                        d.upd_tonkho(iNhomkho, mMmyy);
                        Cursor = Cursors.Default;
                        lblkiemtra.Text = "";
                    }
                }
                else d.kiemtra_cstt_nhap(mMmyy, iNhomkho);
			}
            else d.kiemtra_cstt_nhap(mMmyy, iNhomkho);
			this.mExit=false;
            if (m.bDelFileTemp) m.delFileTemp();
            string mmyys = d.Mmyy_truoc(mMmyy);
            if (d.bHcton(iNhomkho, mmyys) && d.bMmyy(mmyys))
            {
                if (MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng")+" " + mmyys.Substring(0, 2) + " "+lan.Change_language_MessageText("năm 20") + mmyys.Substring(2) + " "+lan.Change_language_MessageText("có chỉnh sửa")+"\n"+lan.Change_language_MessageText("Bạn phải kiểm tra lại tồn đầu tháng")+" " + mMmyy.Substring(0, 2) + " "+lan.Change_language_MessageText("năm 20") + mMmyy.Substring(2) + "\n"+lan.Change_language_MessageText("Bạn có muốn tiếp tục không ?"), d.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    mm.Focus();
                    return;
                }
            }
            //hien 06-06-2011
            m.f_capnhat_db_danhmuc("duoc.exe", mMmyy);
            if (m.bQuanly_Theo_Chinhanh)
            {
                f_capnhat_db_hien();
                f_capnhat_db_hien(mMmyy);
            }
            //end hien
            d.Tao_view(mMmyy);//Thuy 09.01.2012
            d.setStandar();
			d.close();this.Close();
		}
		
		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			mUserid="";
			this.mExit=true;
            d.set_current();
			Application.Exit();
		}

		private bool kiemtra()
		{
            string ddmmyy = DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString().PadLeft(4, '0').Substring(2);
			if (txtuser.Text==LibDuoc.AccessData.links_userid && txtpassword.Text==LibDuoc.AccessData.links_pass.Trim()+ ddmmyy)
			{
                mUserid = txtuser.Text.Trim() + txtpassword.Text.Trim().Replace(ddmmyy, "");
				return true;
			}
			try
			{
                bool bMahoa = d.bMahoamatkhau;
                string makhau = txtpassword.Text.ToString().Trim().ToUpper();
                sql = "select a.*,b.ten as tennhom from "+user+".d_dlogin a,"+user+".d_dmnhomkho b where a.nhomkho=b.id and b.loai=1 ";
                sql += " and upper(trim(a.userid))='" + txtuser.Text.ToString().Trim().ToUpper() + "'";
                if (bMahoa) sql += " and a.password_='" + m.encode(makhau) + "'";
                else sql += " and upper(trim(a.password_))='" + makhau + "'";
                ds = m.get_data(sql);		
				if (ds.Tables[0].Rows.Count>0)
				{
					mMakho=ds.Tables[0].Rows[0]["makho"].ToString();
					iNhomkho=int.Parse(ds.Tables[0].Rows[0]["nhomkho"].ToString());
					mRight=ds.Tables[0].Rows[0]["right_"].ToString();
					mUserid=ds.Tables[0].Rows[0]["hoten"].ToString();
					iUserid=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
					mMakp=ds.Tables[0].Rows[0]["makp"].ToString();
					mManhom=ds.Tables[0].Rows[0]["manhom"].ToString();
					mTennhom=ds.Tables[0].Rows[0]["tennhom"].ToString();
					mLoaint=ds.Tables[0].Rows[0]["loaint"].ToString();
					mLoaikhac=ds.Tables[0].Rows[0]["loaikhac"].ToString();
					bAdmin=int.Parse(ds.Tables[0].Rows[0]["admin"].ToString())==1;
					bTao=int.Parse(ds.Tables[0].Rows[0]["tao"].ToString())==1;
                    bThuhoi = int.Parse(ds.Tables[0].Rows[0]["thuhoi"].ToString()) == 1;
                    // hien: 03-03-2011 
                    try
                    {
                        i_chinhanh = int.Parse(ds.Tables[0].Rows[0]["chinhanh"].ToString());
                    }
                    catch
                    {
                        i_chinhanh = 0;
                    }
                    //linh
                    //if (d.bQuanly_Theo_Chinhanh && i_chinhanh != 0 && i_chinhanh != d.i_Chinhanh_hientai)
                    //{
                    //    MessageBox.Show(lan.Change_language_MessageText("Bạn không thuộc chi nhánh này. Đề nghị liên hệ phòng máy tính."), "Medisoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    return false;
                    //}
                    //end linh
					DataSet dsxml=new DataSet();
					dsxml.ReadXml("..\\..\\..\\xml\\d_nhomkholog.xml");
					dsxml.Tables[0].Rows[0]["nhomkho"]=iNhomkho.ToString();
					dsxml.WriteXml("..\\..\\..\\xml\\d_nhomkholog.xml",XmlWriteMode.WriteSchema);
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

		private void ngay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void frmLogin_Load(object sender, System.EventArgs e)
		{
            user = d.user;
            try { string chinhanh = m.get_data("select chinhanh from " + user + ".d_dlogin where 1=0").Tables[0].Rows[0][0].ToString(); }
            catch { m.execute_data("alter table medibv.d_dlogin add chinhanh numeric(2) default 0", false); }
            lblkiemtra.Text = "";
			mm.Value=DateTime.Now.Month;
			yyyy.Value=DateTime.Now.Year;

            groLogin.BringToFront();
            groLicense.Visible = false;
            //28.02.2013
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
                    groLicense.BringToFront();
                    groLicense.Visible = true;
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
                    this.Width = 247;
                    this.Height = 182;
                }
                //28.02.2013
            }
            else
            {
                this.Width = 247;
                this.Height = 182;
            }
            try
            {
                bool update = m.bAutoupdate && m.Path_medisoft != "";
                if (update)
                {
                    string file = "duoc", path = m.Path_medisoft + "\\" + file + "\\bin\\debug";
                    if (!m.bUpdate(System.IO.Directory.GetCurrentDirectory(), path, file))
                    {
                        m.writeXml("thongso", "version", "Version " + m.f_modify(m.file_exe_update(path, file)));
                        m.writeXml("thongso", "file", file);
                        mUserid = "";
                        this.mExit = true;
                        Application.Exit();
                        string filerun = @m.path_medisofthis() + "\\version\\bin\\debug\\version.exe";
                        backup f = new backup(filerun);
                        f.Launch();
                    }
                }
            }
            catch { }
            f_capnhat_db();
		}

		private void mm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void yyyy_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

        private void f_capnhat_db()
        {
            string ss_mmyy = mm.Value.ToString().PadLeft(2, '0') + yyyy.Value.ToString().PadLeft(4, '0').Substring(2, 2);
            m.f_capnhat_db_danhmuc("duoc.exe");
            sql = "update " + d.user + ".v_giavp set bhyt_tt=bhyt where bhyt_tt is null or bhyt_tt=0 ";
            m.execute_data(sql);
            //if(m.bQuanly_Theo_Chinhanh==false) 
            //m.f_kiemtra_idduoc_idgiavp();
            //ThanhCuong 01/03/2012
            sql = "alter table " + user + ss_mmyy + ".d_dutruct add userid numeric(7) default 0";
            d.execute_data(sql, false);
            sql = "alter table " + user + ss_mmyy + ".d_xtutrucct add userid numeric(7) default 0";
            d.execute_data(sql, false);
            sql = "alter table " + user + ss_mmyy + ".d_haophict add userid numeric(7) default 0";
            d.execute_data(sql, false);
            //
        }
        private void f_capnhat_db_()
        {
            string sql = "alter table " + user + ".d_dmnhom add loaivp numeric(7) default 0";
            d.execute_data(sql,false);

            sql = "select mathoidiemdung from " + user + ".d_dmbd where 1=2";
            try
            {
                if (d.get_data(sql).Tables.Count <= 0)
                {
                    sql = "alter table " + user + ".d_dmbd add mathoidiemdung numeric(7) default 0";
                    d.execute_data(sql, false);
                }
            }
            catch
            {
                sql = "alter table " + user + ".d_dmbd add mathoidiemdung numeric(7) default 0";
                d.execute_data(sql, false);
            }
            sql = "select id from " + user + ".d_dmthoidiemdung where 1=2";
            try
            {
                if (d.get_data(sql).Tables.Count <= 0)
                {
                    sql = "create table " + user + ".d_dmthoidiemdung (id numeric(3), ten text, nhom numeric(3) default 0, stt numeric (3) default 0, ngayud timestamp DEFAULT now(), readonly numeric (1) default 0, CONSTRAINT pk_d_dmthoidiemdung primary key (id) using INDEX TABLESPACE medi_index) WITH OIDS ";
                    d.execute_data(sql, false);
                }
            }
            catch
            {
                sql = "create table " + user + ".d_dmthoidiemdung (id numeric(3), ten text, nhom numeric(3) default 0, stt numeric (3) default 0, ngayud timestamp DEFAULT now(), readonly numeric (1) default 0, CONSTRAINT pk_d_dmthoidiemdung primary key (id) using INDEX TABLESPACE medi_index) WITH OIDS ";
                d.execute_data(sql, false);
            }

            sql = "select bhyt_tt from " + user + ".v_giavp where 1=2";
            try
            {
                if (d.get_data(sql).Tables.Count <= 0)
                {
                    sql = "alter table " + user + ".v_giavp add bhyt_tt numeric(5,2) default 0";
                    d.execute_data(sql, false);
                }
            }
            catch
            {
                sql = "alter table " + user + ".v_giavp add bhyt_tt numeric(5,2) default 0";
                d.execute_data(sql, false);
            }
             sql = "select mmyy from " + user + ".d_taosolieu where 1=2";
             try
             {
                 if (d.get_data(sql).Tables.Count <= 0)
                 {
                     sql = "create table " + user + ".d_taosolieu (nhom numeric(5), mmyy varchar(4), userid numeric(7), ngayud timestamp default now(), constraint pk_taosolieu primary key (nhom, mmyy) )";
                     d.execute_data(sql);
                 }
             }
             catch { }

             sql = "select ketoa from " + user + ".d_dmbd where 1=2";
             DataSet lds = d.get_data(sql);
             if (lds == null || lds.Tables.Count <= 0)
             {
                 sql = "alter table " + user + ".d_dmbd add ketoa numeric(1) default 1";
                 d.execute_data(sql);
             }

             sql = "select id from " + user + ".dmkhudt where id=0";
             lds = m.get_data(sql);
             if (lds == null || lds.Tables.Count <= 0)
             {
                 sql = "create table " + user + ".dmkhudt (id numeric(3), ten text,constraint pk_dmkhudt primary key(id)) with oids";
                 m.execute_data(sql);
             }
             sql = "select khu from " + user + ".d_dlogin where id=0";
             lds = m.get_data(sql);
             if (lds == null || lds.Tables.Count <= 0)
             {
                 sql = "alter table " + user + ".d_dlogin add khu varchar(100)";
                 m.execute_data(sql);
             }
             sql = "select khu from " + user + ".d_duockp where 1=2";
             lds = m.get_data(sql);
             if (lds == null || lds.Tables.Count <= 0)
             {
                 sql = "alter table " + user + ".d_duockp add khu numeric(3) default 0";
                 m.execute_data(sql);                 
             }
             sql = "select khu from " + user + ".btdkp_bv where 1=2";
             lds = m.get_data(sql);
             if (lds == null || lds.Tables.Count <= 0)
             {
                 sql = "alter table " + user + ".btdkp_bv add khu numeric(3) default 0";
                 m.execute_data(sql);
             }
             sql = "select khu from " + user + ".d_dmkho where id=0";
             lds = m.get_data(sql);
             if (lds == null || lds.Tables.Count <= 0)
             {
                 sql = "alter table " + user + ".d_dmkho add khu numeric(3) default 0";
                 m.execute_data(sql);
             }
             sql = "select syn from " + user + ".d_dmbd where id=0";
             lds = m.get_data(sql);
             if (lds == null || lds.Tables.Count <= 0)
             {
                 sql = "alter table " + user + ".d_dmbd add syn numeric(1) default 0";
                 m.execute_data(sql);
             }
        }
        private void f_capnhat_db_hien()
        {
            // d_dmbd
            string mmyy = mm.Value.ToString().PadLeft(2, '0') + yyyy.Value.ToString().PadLeft(4, '0').Substring(2, 2);
            string s_user = d.user;
            string s_gio_modify = "01/06/2011 01:00";
           
            string asql = "select ngaygio from " + s_user + ".datao where to_char(ngaygio,'dd/mm/yyyy hh24:mi')='" + s_gio_modify + "'";
            DataSet lds = d.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = " drop table " + s_user + ".datao ";
                d.execute_data(asql);
                asql = " create table " + s_user + ".datao (ngaygio timestamp, constraint pk_datao primary key (ngaygio) USING INDEX TABLESPACE medi_index)  WITH OIDS ";
                d.execute_data(asql);
            }
            else if (lds.Tables[0].Rows.Count > 0) return;
            asql = "insert into " + s_user + ".datao (ngaygio) values (to_date('" + s_gio_modify + "','dd/mm/yyyy hh24:mi'))";
            d.execute_data(asql);

            d.alterColumn(s_user, "d_dmbd", "id", "numeric(9)");
            d.alterColumn(s_user, "v_giavp", "id", "numeric(9)");
            d.alterColumn(s_user, "btdkp_bv", "mavp", "numeric(9)");
            d.alterColumn(s_user, "btdkp_bv", "mavptk", "numeric(9)");

            d.alterColumn(s_user, "d_suamdt", "ma", "numeric(9)");

            d.alterColumn(s_user, "d_dmthauct", "mabd", "numeric(9)");
            d.alterColumn(s_user, "d_theodoigia", "mabd", "numeric(9)");
            d.alterColumn(s_user, "d_dmnuoc", "id", "numeric(7)");
            d.alterColumn(s_user, "d_dmbd", "manuoc", "numeric(7)");
            d.alterColumn(s_user, "d_dmhang", "id", "numeric(7)");
            d.alterColumn(s_user, "d_dmnhom", "id", "numeric(6)");
            d.alterColumn(s_user, "d_dmloai", "id", "numeric(6)");
            d.alterColumn(s_user, "d_dmnx", "id", "numeric(7)");
            d.alterColumn(s_user, "d_dmthaull", "madv", "numeric(7)");
            d.alterColumn(s_user, "d_nhombc", "id", "numeric(5)");
            d.alterColumn(s_user, "d_nhomctd", "id", "numeric(5)");
            d.alterColumn(s_user, "d_dmphieu", "id", "numeric(5)");
            d.alterColumn(s_user, "d_ngayduyet", "loai", "numeric(5)");
            d.alterColumn(s_user, "d_sophieu", "loai", "numeric(5)");
            d.alterColumn(s_user, "d_theodoiduyet", "loai", "numeric(5)");
            d.alterColumn(s_user, "d_dmnhomkt", "id", "numeric(5)"); 
            d.alterColumn(s_user, "d_loaiphieu", "id", "numeric(6)");
            d.alterColumn(s_user, "d_daduyet", "loai", "numeric(5)");
            d.alterColumn(s_user, "d_daduyet", "phieu", "numeric(6)");
            d.alterColumn(s_user, "d_ngayduyet", "phieu", "numeric(6)");
            d.alterColumn(s_user, "d_sophieu", "phieu", "numeric(6)");
            d.alterColumn(s_user, "d_nhomkho", "id", "numeric(4)");
            d.alterColumn(s_user, "d_daduyet", "nhom", "numeric(4)");
            d.alterColumn(s_user, "d_dmkho", "id", "numeric(5)");
            d.alterColumn(s_user, "d_daduyet", "makho", "numeric(5)");
            d.alterColumn(s_user, "d_solankiemtra", "makho", "numeric(5)");
            d.alterColumn(s_user, "d_solankiemtracstt", "makho", "numeric(5)");
            d.alterColumn(s_user, "d_sophieu", "makho", "numeric(5)");
            d.alterColumn(s_user, "d_dmnguon", "id", "numeric(5)");
            d.alterColumn(s_user, "d_nhomkhoa", "id", "numeric(5)");
            d.alterColumn(s_user, "d_duockp", "id", "numeric(5)");
            d.alterColumn(s_user, "d_daduyet", "makp", "numeric(5)");
            d.alterColumn(s_user, "d_ngayduyet", "makp", "numeric(5)");
            d.alterColumn(s_user, "d_phieuxuat", "makp", "numeric(5)");
            d.alterColumn(s_user, "d_solankiemtracstt", "makp", "numeric(5)");
            d.alterColumn(s_user, "d_sophieu", "makp", "numeric(5)");
            d.alterColumn(s_user, "d_theodoiduyet", "makp", "numeric(5)");
            d.alterColumn(s_user, "d_dmvay", "id", "numeric(5)");
            d.alterColumn(s_user, "dmbs", "ma", "varchar(6)");
            d.alterColumn(s_user, "d_theodonll", "id", "numeric(22)");
            d.alterColumn(s_user, "d_theodonct", "id", "numeric(22)");

            // tao du tru thuoc ll
            sql = "create table " + user + ".d_dutrukholl(ID numeric(22) not null,nhom numeric(2),sophieu numeric(12) not null,ngay date ,makho varchar(100),done numeric(1) not null default 0,userid numeric(5),ngayud date default now(),constraint pk_d_dutrukholl primary key(ID)) with (oids=true);";
            d.execute_data(sql);
            sql = "create or replace Function " + user + ".upd_d_dutrukholl(d_id numeric,d_nhom numeric,d_sophieu numeric,d_ngay varchar,d_makho varchar,d_done numeric,d_userid numeric)returns void as ";
            sql += "\n $BODY$";
            sql += "\n begin ";
            sql += "\n update " + user + ".d_dutrukholl set  makho=d_makho, done=d_done, userid=d_userid where id=d_id and nhom=d_nhom and sophieu=d_sophieu;";
            sql += "\n if(found=false) then ";
            sql += "\n insert into " + user + ".d_dutrukholl(id,nhom,sophieu,ngay,makho,done,userid) values(d_id,d_nhom,d_sophieu,to_date(d_ngay,'dd/mm/yyyy'),d_makho,d_done,d_userid);";
            sql += "\n end if;";
            sql += "\n end;";
            sql += "\n $BODY$ ";
            sql += "\n language 'plpgsql' volatile;";
            d.execute_data(sql);
            sql = "create or replace function " + user + ".del_d_dutrukho(d_id numeric,d_sophieu numeric)";
            sql += "returns void as";
            sql += "\n $BODY$";
            sql += "\n begin ";
            sql += "\n delete from " + user + ".d_dutrukhoct where id=d_id;";
            sql += "\n delete from " + user + ".d_dutrukholl where id=d_id and sophieu=d_sophieu;";
            sql += "\n end;";
            sql += "\n $BODY$";
            sql += "\n language 'plpgsql' volatile;  ";
            d.execute_data(sql);
            // du tru kho ct
            sql = "create table " + user + ".d_dutrukhoct (ID numeric(22) not null,stt numeric(5) not null default 0,mabd numeric(9) not null,slton numeric(14,2) not null default 0,xuat10 numeric(14,2) not null default 0,xuat30 numeric(14,2) not null default 0,xuat numeric(1) not null default 0,slgoiy numeric(14,2) not null default 0,soluong numeric(14,2) not null default 0,donvi varchar(50),nhacc varchar(50),manguon varchar(50),lydo text,constraint pk_d_dutrukhoct primary key(ID,stt,mabd),constraint fk_d_dutrukhoct_d_dutrukholl foreign key(ID) references "+user+".d_dutrukholl(ID) match simple on update no action on delete set null)with (oids=true);";
            d.execute_data(sql);

            sql = "create or replace Function " + user + ".upd_d_dutrukhoct(d_id numeric,d_stt numeric,d_mabd numeric,d_slton numeric,d_xuat10 numeric,d_xuat30 numeric,d_slgoiy numeric,d_soluong numeric,d_donvi varchar,d_nhacc varchar,d_manguon varchar,d_lydo varchar)returns void as ";
            sql += "\n $BODY$";
            sql += "\n begin ";
            sql += "\n update " + user + ".d_dutrukhoct set slton=d_slton, xuat10=d_xuat10, xuat30=d_xuat30,slgoiy=d_slgoiy,soluong=d_soluong,donvi=d_donvi,nhacc=d_nhacc,manguon=d_manguon,lydo=d_lydo,stt=d_stt where id=d_id  and mabd=d_mabd;";
            sql += "\n if(found=false) then ";
            sql += "\n insert into " + user + ".d_dutrukhoct(id,stt,mabd,slton,xuat10,xuat30,slgoiy,soluong,donvi,nhacc,manguon,lydo) values(d_id,d_stt,d_mabd,d_slton,d_xuat10,d_xuat30,d_slgoiy,d_soluong,d_donvi,d_nhacc,d_manguon,d_lydo);";
            sql += "\n end if;";
            sql += "\n end;";
            sql += "\n $BODY$";
            sql += "\n language 'plpgsql' volatile;";
            d.execute_data(sql);
            // duyet du tru ll
            sql = "create table " + user + ".d_duyetdutrukholl(id numeric(22) not null default 0,phieu numeric(12) not null,ngay date ,userid numeric(5),constraint pk_d_duyetdutrukholl primary key(id)) with(oids=true)";
            d.execute_data(sql);

            sql = "create or replace function " + user + ".upd_d_duyetdutrukholl(d_id numeric,d_phieu numeric,d_ngay varchar,d_user numeric)returns void as";
            sql += "\n $BODY$";
            sql += "\n begin";
            sql += "\n update " + user + ".d_duyetdutrukholl set ngay=to_date(d_ngay,'dd/mm/yyyy'),userid=d_user where id=d_id and phieu=d_phieu;";
            sql += "\n if found=false then ";
            sql += "\n insert into " + user + ".d_duyetdutrukholl(id,phieu,ngay,userid) values (d_id,d_phieu,to_date(d_ngay,'dd/mm/yyyy'),d_user);";
            sql += "\n end if;";
            sql += "\n end;";
            sql += "\n $BODY$";
            sql += "\n language 'plpgsql' volatile;";
            d.execute_data(sql);
            // duyet du tru kho ct
            sql = "create table " + user + ".d_duyetdutrukhoct(id numeric(22) not null,stt numeric(5) not null default 1,mabd numeric(9) not null,soluong numeric(14,2) not null default 0,sldutru numeric(14,2) not null,constraint pk_d_duyetdutrukhoct primary key (id,stt),constraint fk_d_duyetdutrukhoct_d_duyetdutrukholl foreign key(ID)references "+user+".d_duyetdutrukholl(ID) match simple on update no action on delete set null)";
            d.execute_data(sql);

            sql = "create or replace function " + user + ".upd_d_duyetdutrukhoct(d_id numeric,d_stt numeric,d_mabd numeric,d_soluong numeric,d_sldutru numeric) returns void as ";
            sql += "\n $BODY$";
            sql += "\n begin";
            sql += "\n update " + user + ".d_duyetdutrukhoct set stt=d_stt,soluong=d_soluong,sldutru=d_sldutru where id=d_id and mabd=d_mabd;";
            sql += "\n if found= false then";
            sql += "\n insert into " + user + ".d_duyetdutrukhoct (id,stt,mabd,soluong,sldutru) values(d_id,d_stt,d_mabd,d_soluong,d_sldutru);";
            sql += "\n end if;";
            sql += "\n end;";
            sql += "\n $BODY$";
            sql += "\n language 'plpgsql' volatile;";
            d.execute_data(sql);
            // theo doi duyet du tru 
            sql = "create table " + user + ".d_theodoiduyetdutru(id numeric(22) not null,id_dutru numeric(22) not null,makho numeric(5) ,id_chinhanh numeric(3), done numeric(1) not null default 0,constraint pk_d_theodoiduyetdutru primary key(id))with (oids=true)";
            d.execute_data(sql);

            sql = "create or replace function " + user + ".upd_d_theodoiduyetdutru(d_id numeric,d_iddutru numeric,d_makho numeric,d_idchinhanh numeric,d_done numeric) returns void as";
            sql += "\n $BODY$";
            sql += "\n begin";
            sql += "\n update " + user + ".d_theodoiduyetdutru set id_chinhanh=d_idchinhanh,makho=d_makho,id_dutru=d_iddutru,done=d_done where id=d_id;";
            sql += "\n if found =false then";
            sql += "\n insert into " + user + ".d_theodoiduyetdutru(id,id_dutru,makho,id_chinhanh,done) values (d_id,d_iddutru,d_makho,d_idchinhanh,d_done);";
            sql += "\n end if;";
            sql += "\n update " + user + ".d_dutrukholl set done =1 where id=d_iddutru;";
            sql += "\n end;";
            sql += "\n $BODY$";
            sql += "\n language 'plpgsql' volatile;";
            d.execute_data(sql);

            sql = "create or replace function " + user + ".huy_duyetdutrukho(d_id numeric,d_iddutru numeric,d_makho numeric,d_sophieu numeric)returns void as";
            sql += "\n $BODY$";
            sql += "\n begin ";
            sql += "\n delete " + user + ".d_theodoiduyetdutru where id=d_id and makho=d_makho and id_dutru=d_iddutru and done<>1;";
            sql += "\n if found = false then exit;";
            sql += "\n end if;";
            sql += "\n delete " + user + ".d_duyetdutrukhoct where id=d_id;";
            sql += "\n delete " + user + ".d_duyetdutrukholl where id=d_id and phieu=d_sophieu;";
            sql += "\n update " + user + ".d_dutrukholl set done=2 where id=d_iddutru;";
            sql += "\n end;";
            sql += "\n $BODY$";
            sql += "\n language 'plpgsql' volatile;";
            d.execute_data(sql);
        }
        private void f_capnhat_db_hien(string d_mmyy)
        {
            // d_dmbd
            string mmyy = mm.Value.ToString().PadLeft(2, '0') + yyyy.Value.ToString().PadLeft(4, '0').Substring(2, 2);
            string s_user = d.user;
            string s_gio_modify = d.ngayhienhanh_server;
            string s_mmyy = d.mmyy(d.ngayhienhanh_server);
            string xxx = s_user + s_mmyy;

            string tenfile = "duoc.exe";
            if (d.bMmyy(mmyy))
            {
                ///Begin dong

                sql = "select id from " + xxx + ".d_chonhapll ";
                DataSet dstmp = d.get_data(sql);
                if (dstmp == null || dstmp.Tables.Count <= 0)
                {
                    sql = "CREATE TABLE " + xxx + ".d_chonhapll(id numeric(22) NOT NULL DEFAULT 0,nhom numeric(2) DEFAULT 0,sophieu varchar(10),ngaysp timestamp,loai varchar(2),ngayud timestamp DEFAULT now(),done numeric(1) DEFAULT 0,idchinhanhchuyen numeric(2,0) default 0,idchinhanhnhan numeric(2,0) default 0,userid numeric(5,0),chuyendi text,CONSTRAINT pk_d_chonhapll PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH OIDS;ALTER TABLE " + xxx + ".d_chonhapll OWNER TO medisoft;\n";
                    d.execute_data(sql);
                }
                sql = "select id from " + xxx + ".d_chonhapct ";
                DataSet dstmp1 = d.get_data(sql);
                if (dstmp1 == null || dstmp1.Tables.Count <= 0)
                {
                    sql = "CREATE TABLE " + xxx + ".d_chonhapct(id numeric(22) NOT NULL DEFAULT 0,stt numeric(3) NOT NULL DEFAULT 0,mabd numeric(10) DEFAULT 0,handung varchar(10),losx varchar(20),vat numeric(3) DEFAULT 0,soluong numeric(12,4) DEFAULT 0,dongia numeric(24,10) DEFAULT 0,sotien numeric(15,4) DEFAULT 0,giaban numeric(22) DEFAULT 0,giamua numeric(24,10) DEFAULT 0,manguon numeric(2) DEFAULT 0,nhomcc numeric(4) DEFAULT 0,chuyendi text,ngayud timestamp DEFAULT now(),CONSTRAINT pk_d_chonhapct PRIMARY KEY (id, stt) USING INDEX TABLESPACE medi_index,CONSTRAINT fk_d_chonhapct_d_dmbd FOREIGN KEY (mabd) REFERENCES " + user + ".d_dmbd (id) MATCH SIMPLE  ON UPDATE NO ACTION ON DELETE SET NULL,CONSTRAINT fk_d_chonhapct_d_chonhapll FOREIGN KEY (id) REFERENCES " + xxx + ".d_chonhapll (id) MATCH SIMPLE ON UPDATE NO ACTION ON DELETE SET NULL,CONSTRAINT fk_d_chonhapct_d_dmnguon FOREIGN KEY (manguon) REFERENCES " + user + ".d_dmnguon (id) MATCH SIMPLE ON UPDATE NO ACTION ON DELETE SET NULL) WITH OIDS;ALTER TABLE " + xxx + ".d_chonhapct OWNER TO medisoft;\n";
                    d.execute_data(sql);
                }
                sql = "select idchinhanh from " + xxx + ".d_nhapll ";
                dstmp1 = d.get_data(sql);
                if (dstmp1 == null || dstmp1.Tables.Count <= 0)
                {
                    d.execute_data("alter table " + xxx + ".d_nhapll add idchinhanh numeric(2,0) default 0");
                }
                sql = "select idchinhanh from " + xxx + ".d_xuatll ";
                dstmp1 = d.get_data(sql);
                if (dstmp1 == null || dstmp1.Tables.Count <= 0)
                {
                    d.execute_data("alter table " + xxx + ".d_xuatll add idchinhanh numeric(2,0) default 0");
                }
                ///End dong
                try
                {
                    s_gio_modify = System.IO.File.GetLastWriteTime(tenfile).ToString("dd/MM/yyyy HH:mm");
                }
                catch { s_gio_modify = d.ngayhienhanh_server; }
                string asql = "select ngaygio from " + xxx + ".datao where to_char(ngaygio,'dd/mm/yyyy hh24:mi')='" + s_gio_modify + "'";
                DataSet lds = d.get_data(asql);
                if (lds == null || lds.Tables.Count <= 0)
                {
                    asql = " drop table " + xxx + ".datao ";
                    d.execute_data(asql);
                    asql = " create table " + xxx + ".datao (ngaygio timestamp, constraint pk_datao primary key (ngaygio) USING INDEX TABLESPACE medi_index)  WITH OIDS ";
                    d.execute_data(asql);
                }
                else if (lds.Tables[0].Rows.Count > 0) return;
                asql = "insert into " + xxx + ".datao (ngaygio) values (to_date('" + s_gio_modify + "','dd/mm/yyyy hh24:mi'))";
                d.execute_data(asql);
                

                #region d_dmbd
                d.alterColumn(s_user + mmyy, "bhytthuoc", "mabd", "numeric(9)");
                d.alterColumn(s_user + mmyy, "d_bucstt", "mabd", "numeric(9)");
                d.alterColumn(s_user + mmyy, "d_chuyenct", "mabd", "numeric(9)");
                d.alterColumn(s_user + mmyy, "d_dutruct", "mabd", "numeric(9)");
                d.alterColumn(s_user + mmyy, "d_haophict", "mabd", "numeric(9)");
                d.alterColumn(s_user + mmyy, "d_hoantract", "mabd", "numeric(9)");
                d.alterColumn(s_user + mmyy, "d_htrathuocct", "mabd", "numeric(9)");
                d.alterColumn(s_user + mmyy, "d_huybanct", "mabd", "numeric(9)");
                d.alterColumn(s_user + mmyy, "d_ngtruct", "mabd", "numeric(9)");
                d.alterColumn(s_user + mmyy, "d_nhapbbct", "mabd", "numeric(9)");
                d.alterColumn(s_user + mmyy, "d_nhapct", "mabd", "numeric(9)");
                d.alterColumn(s_user + mmyy, "d_nhapct2", "mabd", "numeric(9)");
                d.alterColumn(s_user + mmyy, "d_nhapslct", "mabd", "numeric(9)");
                d.alterColumn(s_user + mmyy, "d_theodoi", "mabd", "numeric(9)");
                d.alterColumn(s_user + mmyy, "d_theodoigia", "mabd", "numeric(9)");
                d.alterColumn(s_user + mmyy, "d_thucbucstt", "mabd", "numeric(9)");
                d.alterColumn(s_user + mmyy, "d_thucxuat", "mabd", "numeric(9)");
                d.alterColumn(s_user + mmyy, "d_thucxuat2", "mabd", "numeric(9)");
                d.alterColumn(s_user + mmyy, "d_thuocbhytct", "mabd", "numeric(9)");
                d.alterColumn(s_user + mmyy, "d_tienthuoc", "mabd", "numeric(9)");
                d.alterColumn(s_user + mmyy, "d_tonkhoct", "mabd", "numeric(9)");
                d.alterColumn(s_user + mmyy, "d_tonkhokemtheo", "mabd", "numeric(9)");
                d.alterColumn(s_user + mmyy, "d_tonkhoth", "mabd", "numeric(9)");
                d.alterColumn(s_user + mmyy, "d_tutrucct", "mabd", "numeric(9)");
                d.alterColumn(s_user + mmyy, "d_tutruckemtheo", "mabd", "numeric(9)");
                d.alterColumn(s_user + mmyy, "d_tutructh", "mabd", "numeric(9)");
                d.alterColumn(s_user + mmyy, "d_xtutrucct", "mabd", "numeric(9)");
                d.alterColumn(s_user + mmyy, "d_xuatct", "mabd", "numeric(9)");
                d.alterColumn(s_user + mmyy, "d_xuatsdct", "mabd", "numeric(9)");
                #endregion
                // lien quan den d_dmnx
                d.alterColumn(s_user + mmyy, "d_nhapbbll", "madv", "numeric(7)");
                d.alterColumn(s_user + mmyy, "d_nhapbbll", "nhomcc", "numeric(7)");
                d.alterColumn(s_user + mmyy, "d_nhapslll", "madv", "numeric(7)");
                // dm phieu
                d.alterColumn(s_user + mmyy, "d_daduyet", "loai", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_duyet", "loai", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_ngayduyet", "loai", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_sophieu", "loai", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_theodoiduyet", "loai", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_xuatsdll", "loai", "numeric(5)");
                // dm loai phieu
                d.alterColumn(s_user, "d_loaiphieu", "phieu", "numeric(6)");
                d.alterColumn(s_user + mmyy, "d_duyet", "phieu", "numeric(6)");
                d.alterColumn(s_user + mmyy, "d_ngayduyet", "phieu", "numeric(6)");
                d.alterColumn(s_user + mmyy, "d_sophieu", "phieu", "numeric(6)");
                d.alterColumn(s_user + mmyy, "d_xuatsdll", "phieu", "numeric(6)");

                d.alterColumn(s_user + mmyy, "v_vpkhoa", "mavp", "numeric(9)");
                d.alterColumn(s_user + mmyy, "v_chidinh", "mavp", "numeric(9)");
                d.alterColumn(s_user + mmyy, "v_thvpct", "mavp", "numeric(9)");
                d.alterColumn(s_user + mmyy, "v_ttrvct", "mavp", "numeric(9)");
                d.alterColumn(s_user + mmyy, "v_vienphict", "mavp", "numeric(9)");
                d.alterColumn(s_user + mmyy, "v_hoantract", "mavp", "numeric(9)");
                d.alterColumn(s_user + mmyy, "bhytcls", "mavp", "numeric(9)");
                // dm kho
                #region dm kho
                d.alterColumn(s_user + mmyy, "d_bucstt", "makho", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_chuyenct", "makho", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_ctghisoct", "makho", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_daduyet", "makho", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_dutruct", "makho", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_haophict", "makho", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_hoantract", "makho", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_htrathuocct", "makho", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_huybanct", "makho", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_ngtruct", "makho", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_nhapbbll", "makho", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_nhapll", "makho", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_nhapslll", "makho", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_solankiemtra", "makho", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_solankiemtracstt", "makho", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_sophieu", "makho", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_thucbucstt", "makho", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_thucxuat", "makho", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_thucxuat2", "makho", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_thuocbhytct", "makho", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_tonkhoct", "makho", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_tonkhokemtheo", "makho", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_tonkhoth", "makho", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_tutrucct", "makho", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_tutruckemtheo", "makho", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_tutructh", "makho", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_xtutrucct", "makho", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_xuatsdct", "makho", "numeric(5)");
               
                #endregion
                #region dm nguon
                d.alterColumn(s_user + mmyy, "d_chuyenct", "nguonchuyen", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_dutrucapct", "manguon", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_dutruct", "manguon", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_haophict", "manguon", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_hoantract", "manguon", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_nhapbbll", "manguon", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_nhapll", "manguon", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_theodoi", "manguon", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_thuocbhytct", "manguon", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_tutructh", "manguon", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_xtutrucct", "manguon", "numeric(5)");
                #endregion
                #region duoc khoa phong
                d.alterColumn(s_user + mmyy, "d_ctghisoct", "makp", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_daduyet", "makp", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_duyet", "makp", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_ngayduyet", "makp", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_phieuxuat", "makp", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_solankiemtracstt", "makp", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_sophieu", "makp", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_theodoiduyet", "makp", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_tienthuoc", "makp", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_tutrucct", "makp", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_tutruckemtheo", "makp", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_tutructh", "makp", "numeric(5)");
                d.alterColumn(s_user + mmyy, "d_xuatsdll", "makp", "numeric(5)");
                #endregion
                #region kho - ton dau
                // d_theodoi
                d.alterColumn(s_user + mmyy, "d_theodoi", "id", "numeric(24)");
                d.alterColumn(s_user + mmyy, "d_bucstt", "sttt", "numeric(24)");
                d.alterColumn(s_user + mmyy, "d_chuyenct", "sttt", "numeric(24)");
                d.alterColumn(s_user + mmyy, "d_huyban", "sttt", "numeric(24)");
                d.alterColumn(s_user + mmyy, "d_ngtruct", "sttt", "numeric(24)");
                d.alterColumn(s_user + mmyy, "d_thucbucstt", "sttt", "numeric(24)");
                d.alterColumn(s_user + mmyy, "d_thucxuat", "sttt", "numeric(24)");
                d.alterColumn(s_user + mmyy, "d_thucxuat2", "sttt", "numeric(24)");
                d.alterColumn(s_user + mmyy, "d_tonkhoct", "stt", "numeric(24)");
                d.alterColumn(s_user + mmyy, "d_tonkhokemtheo", "sttt", "numeric(24)");
                d.alterColumn(s_user + mmyy, "d_tutrucct", "stt", "numeric(24)");
                d.alterColumn(s_user + mmyy, "d_tutruckemtheo", "stt", "numeric(24)");
                d.alterColumn(s_user + mmyy, "d_xuatct", "sttt", "numeric(24)");
                d.alterColumn(s_user + mmyy, "d_xuatsdct", "sttt", "numeric(24)");
                d.alterColumn(s_user + mmyy, "d_theodoitscd", "sttt", "numeric(24)");
                // tonkhoct

                #endregion
            }
        }

        private void butTiepTuc_Click(object sender, EventArgs e)
        {
            groLicense.Visible = false;
            this.Width = 247;
            this.Height = 182;
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
                        MessageBox.Show("Bản quyền sử dụng đăng ký không thành công. Vui lòng kiểm tra lại License", "Dược");
                        groLicense.Visible = true;
                        bChuaDangKiLicense = true;
                    }
                    else
                    {
                        MessageBox.Show("Đăng ký thành công!", "Dược");
                        groLogin.Enabled = true;
                        bChuaDangKiLicense = false;
                        groLicense.Visible = false;
                        this.Width = 247;
                        this.Height = 182;
                    }
                }
                else
                {
                    MessageBox.Show("Bản quyền không hợp lệ. Vui lòng liên hệ với quản trị hệ thống", "Dược");
                    txtLicense.Focus();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập License", "Dược");
            }
        }

        

        private void ngay_Validated(object sender, EventArgs e)
        {
            string a_mmyy = d.mmyy(ngay.Text);
            if (a_mmyy != "")
            {
                mm.Value = decimal.Parse(a_mmyy.Substring(0, 2));
                yyyy.Value = 2000 + decimal.Parse(a_mmyy.Substring(2, 2));
            }
        }
	}
}
