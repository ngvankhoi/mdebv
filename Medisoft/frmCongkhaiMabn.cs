using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using LibMedi;
using LibVienphi;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Excel;

namespace Medisoft
{
	public class frmCongkhaiMabn : System.Windows.Forms.Form
	{
        Language lan = new Language(); Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private string s_mabn,sql;
		System.Data.DataTable dtnhom=new System.Data.DataTable();
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.DateTimePicker ngayvao;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.TextBox m1;
		private System.Windows.Forms.TextBox m2;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox namsinh;
		private System.Windows.Forms.TextBox phai;
		private System.Windows.Forms.TextBox chandoan;
		private DataSet ds=new DataSet();
		private DataSet dsngay=new DataSet();
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
		private decimal l_maql,l_id;
		private int col,songay,i_loaiba=1,nhom_khac=0;
		private System.Windows.Forms.Button butTiep;
		private System.Data.DataTable dt,dttmp;
		private decimal tien_khac=0;
		private bool bCapve,bNdot;
		private DataColumn dc;
		private DataSet ds1=new DataSet();
		Excel.Application oxl;
		Excel._Workbook owb;
		Excel._Worksheet osheet;
		Excel.Range orange;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox chkXem;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox sothe;
		private MaskedBox.MaskedBox ngayra;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox diachi;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox ngayvv;
		private System.Windows.Forms.TextBox soluutru;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label lblpt;
		private System.Windows.Forms.ComboBox tenkp;
		private System.Windows.Forms.CheckBox chkVienphi;
		private System.Windows.Forms.Panel p;
		private System.ComponentModel.Container components = null;

		public frmCongkhaiMabn(string _mabn)
		{
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			m1.Text=_mabn.Substring(0,2);m2.Text=_mabn.Substring(2);
		}
        public frmCongkhaiMabn(string _mabn,int _i_loaiba)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m1.Text = _mabn.Substring(0, 2); m2.Text = _mabn.Substring(2);
            i_loaiba = _i_loaiba;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCongkhaiMabn));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.m1 = new System.Windows.Forms.TextBox();
            this.m2 = new System.Windows.Forms.TextBox();
            this.hoten = new System.Windows.Forms.TextBox();
            this.namsinh = new System.Windows.Forms.TextBox();
            this.phai = new System.Windows.Forms.TextBox();
            this.chandoan = new System.Windows.Forms.TextBox();
            this.ngayvao = new System.Windows.Forms.DateTimePicker();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butTiep = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chkXem = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.sothe = new System.Windows.Forms.TextBox();
            this.ngayra = new MaskedBox.MaskedBox();
            this.label11 = new System.Windows.Forms.Label();
            this.diachi = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ngayvv = new System.Windows.Forms.ComboBox();
            this.soluutru = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblpt = new System.Windows.Forms.Label();
            this.tenkp = new System.Windows.Forms.ComboBox();
            this.chkVienphi = new System.Windows.Forms.CheckBox();
            this.p = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-16, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã BN :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(136, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Họ tên :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(320, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "NS :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(394, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "Giới tính :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(152, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 23);
            this.label8.TabIndex = 19;
            this.label8.Text = "Từ :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(333, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 23);
            this.label9.TabIndex = 21;
            this.label9.Text = "đến :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(126, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 23);
            this.label10.TabIndex = 23;
            this.label10.Text = "Chẩn đoán :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m1
            // 
            this.m1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.m1.Enabled = false;
            this.m1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m1.Location = new System.Drawing.Point(56, 7);
            this.m1.MaxLength = 2;
            this.m1.Name = "m1";
            this.m1.Size = new System.Drawing.Size(26, 23);
            this.m1.TabIndex = 0;
            this.m1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m1_KeyPress);
            this.m1.Validated += new System.EventHandler(this.m1_Validated);
            this.m1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m1_KeyDown);
            // 
            // m2
            // 
            this.m2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.m2.Enabled = false;
            this.m2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m2.Location = new System.Drawing.Point(85, 7);
            this.m2.MaxLength = 6;
            this.m2.Name = "m2";
            this.m2.Size = new System.Drawing.Size(59, 23);
            this.m2.TabIndex = 1;
            this.m2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m2_KeyPress);
            this.m2.Validated += new System.EventHandler(this.m2_Validated);
            this.m2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m2_KeyDown);
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(184, 7);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(152, 23);
            this.hoten.TabIndex = 3;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(365, 7);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(48, 23);
            this.namsinh.TabIndex = 5;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.Enabled = false;
            this.phai.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Location = new System.Drawing.Point(460, 7);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(48, 23);
            this.phai.TabIndex = 6;
            // 
            // chandoan
            // 
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(200, 58);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(320, 23);
            this.chandoan.TabIndex = 24;
            // 
            // ngayvao
            // 
            this.ngayvao.CustomFormat = "dd/MM/yyyy HH:mm";
            this.ngayvao.Enabled = false;
            this.ngayvao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngayvao.Location = new System.Drawing.Point(208, 33);
            this.ngayvao.Name = "ngayvao";
            this.ngayvao.Size = new System.Drawing.Size(128, 23);
            this.ngayvao.TabIndex = 9;
            this.ngayvao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngayvao_KeyDown);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(323, 496);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(72, 25);
            this.butIn.TabIndex = 25;
            this.butIn.Text = "      &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(395, 496);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(72, 25);
            this.butKetthuc.TabIndex = 27;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butTiep
            // 
            this.butTiep.Image = ((System.Drawing.Image)(resources.GetObject("butTiep.Image")));
            this.butTiep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTiep.Location = new System.Drawing.Point(192, 536);
            this.butTiep.Name = "butTiep";
            this.butTiep.Size = new System.Drawing.Size(74, 30);
            this.butTiep.TabIndex = 26;
            this.butTiep.Text = "         &Tiếp";
            this.butTiep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTiep.Visible = false;
            this.butTiep.Click += new System.EventHandler(this.butTiep_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(643, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "Khoa :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkXem
            // 
            this.chkXem.Location = new System.Drawing.Point(7, 488);
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(104, 24);
            this.chkXem.TabIndex = 28;
            this.chkXem.Text = "Xem trước khi in";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(472, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 23);
            this.label7.TabIndex = 11;
            this.label7.Text = "Số thẻ :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(520, 32);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(128, 23);
            this.sothe.TabIndex = 11;
            // 
            // ngayra
            // 
            this.ngayra.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayra.Enabled = false;
            this.ngayra.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayra.Location = new System.Drawing.Point(365, 33);
            this.ngayra.Mask = "##/##/#### ##:##";
            this.ngayra.Name = "ngayra";
            this.ngayra.Size = new System.Drawing.Size(112, 23);
            this.ngayra.TabIndex = 10;
            this.ngayra.Text = "  /  /       :  ";
            this.ngayra.Validated += new System.EventHandler(this.ngayra_Validated);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(484, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 23);
            this.label11.TabIndex = 7;
            this.label11.Text = "Địa chỉ :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // diachi
            // 
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(552, 7);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(232, 23);
            this.diachi.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(-16, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 23);
            this.label12.TabIndex = 15;
            this.label12.Text = "Ngày vào :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngayvv
            // 
            this.ngayvv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ngayvv.Enabled = false;
            this.ngayvv.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvv.Location = new System.Drawing.Point(56, 32);
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(133, 24);
            this.ngayvv.TabIndex = 8;
            this.ngayvv.SelectedIndexChanged += new System.EventHandler(this.ngayvv_SelectedIndexChanged);
            this.ngayvv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngayvao_KeyDown);
            // 
            // soluutru
            // 
            this.soluutru.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluutru.Enabled = false;
            this.soluutru.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluutru.Location = new System.Drawing.Point(56, 58);
            this.soluutru.Name = "soluutru";
            this.soluutru.Size = new System.Drawing.Size(80, 23);
            this.soluutru.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(-8, 56);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 23);
            this.label13.TabIndex = 31;
            this.label13.Text = "Số lưu trữ :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblpt
            // 
            this.lblpt.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpt.ForeColor = System.Drawing.Color.Red;
            this.lblpt.Location = new System.Drawing.Point(528, 59);
            this.lblpt.Name = "lblpt";
            this.lblpt.Size = new System.Drawing.Size(256, 29);
            this.lblpt.TabIndex = 33;
            // 
            // tenkp
            // 
            this.tenkp.Enabled = false;
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(680, 32);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(104, 24);
            this.tenkp.TabIndex = 12;
            this.tenkp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenkp_KeyDown);
            // 
            // chkVienphi
            // 
            this.chkVienphi.Location = new System.Drawing.Point(552, 120);
            this.chkVienphi.Name = "chkVienphi";
            this.chkVienphi.Size = new System.Drawing.Size(104, 24);
            this.chkVienphi.TabIndex = 34;
            this.chkVienphi.Text = "Xem trước khi in";
            // 
            // p
            // 
            this.p.Location = new System.Drawing.Point(0, 0);
            this.p.Name = "p";
            this.p.Size = new System.Drawing.Size(811, 488);
            this.p.TabIndex = 35;
            // 
            // frmCongkhaiMabn
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(829, 579);
            this.Controls.Add(this.p);
            this.Controls.Add(this.chkVienphi);
            this.Controls.Add(this.butTiep);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.chkXem);
            this.Controls.Add(this.tenkp);
            this.Controls.Add(this.lblpt);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.soluutru);
            this.Controls.Add(this.ngayvv);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.ngayra);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ngayvao);
            this.Controls.Add(this.chandoan);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.m2);
            this.Controls.Add(this.m1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmCongkhaiMabn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu công khai";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCongkhaiMabn_KeyDown);
            this.Load += new System.EventHandler(this.frmCongkhaiMabn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmCongkhaiMabn_Load(object sender, System.EventArgs e)
		{
            this.Location = new System.Drawing.Point(188, 151);	
			bNdot=m.bThanhtoan_ndot;
			bCapve=m.bCapve_noitru;
			dsngay.ReadXml("..\\..\\..\\xml\\m_ngayvao.xml");
			ngayvv.DisplayMember="NGAYVAO";
			ngayvv.ValueMember="MAQL";
			ngayvv.DataSource=dsngay.Tables[0];
			songay=m.Ngaylv_Ngayht;
			chkXem.Checked=m.bPreview;
            tenkp.DataSource = m.get_data("select * from " + m.user + ".btdkp_bv order by loai,makp").Tables[0];
			tenkp.DisplayMember="TENKP";
			tenkp.ValueMember="MAKP";
			m2_Validated(sender,e);
			gan_data();
			load_grid();
		}

		private void m1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void m2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ngayvao_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void m1_Validated(object sender, System.EventArgs e)
		{
			m1.Text=m1.Text.PadLeft(2,'0');
		}

		private void m2_Validated(object sender, System.EventArgs e)
		{
			if (m2.Text=="")
			{
				m1.Text="";
				m1.Focus();
				return;
			}
			dsngay.Clear();
			m2.Text=m2.Text.PadLeft(6,'0');
			l_maql=0;l_id=0;
			s_mabn=m1.Text+m2.Text;
			if (bNdot)
			{
                if (i_loaiba == 4)
                {
                    sql = "select d.makp,d.tenkp,b.hoten, b.namsinh,b.phai,a.maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngayvv, to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') ngayrv, nvl(a.chandoan,a.chandoan) chandoan, nvl(a.maicd,a.maicd) maicd,nvl(e.sothe,'') sothe, ";
                    sql += " b.sonha,b.thon,nvl(f.tentt,' ') as tentt,nvl(g.tenquan,' ') as tenquan,nvl(h.tenpxa,' ') as tenpxa,i.soluutru,a.chandoanrv as chandoanrv,nvl(a.mabs,a.mabs) as mabs ";
                    sql += " from " + m.user + m.mmyy(ngayvao.Text.Substring(0,10)) + ".benhancc a, " + m.user + ".btdbn b," + m.user + ".btdkp_bv d," + m.user + ".bhyt e," + m.user + ".btdtt f," + m.user + ".btdquan g," + m.user + ".btdpxa h," + m.user + ".lienhe i ";
                    sql += " where a.mabn=b.mabn and a.makp=d.makp and a.maql=e.maql(+)";
                    sql += " and b.matt=f.matt(+) and b.maqu=g.maqu(+) and b.maphuongxa=h.maphuongxa(+) and a.maql=i.maql(+)";
                    sql += " and a.mabn='" + s_mabn + "' order by a.maql desc ";
                }
                else
                {
                    sql = "select d.makp,d.tenkp,b.hoten, b.namsinh,b.phai,a.id,a.maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngayvv, to_char(c.ngay,'dd/mm/yyyy hh24:mi') ngayrv, nvl(c.chandoan,a.chandoan) chandoan, nvl(c.maicd,a.maicd) maicd,nvl(e.sothe,'') sothe, ";
                    sql += " b.sonha,b.thon,nvl(f.tentt,' ') as tentt,nvl(g.tenquan,' ') as tenquan,nvl(h.tenpxa,' ') as tenpxa,i.soluutru,c.chandoan as chandoanrv,nvl(c.mabs,a.mabs) as mabs ";
                    sql += " from " + m.user + ".nhapkhoa a, " + m.user + ".btdbn b, " + m.user + ".xuatkhoa c," + m.user + ".btdkp_bv d," + m.user + ".bhyt e," + m.user + ".btdtt f," + m.user + ".btdquan g," + m.user + ".btdpxa h," + m.user + ".lienhe i," + m.user + ".benhandt j ";
                    sql += " where a.mabn=b.mabn and a.maql=j.maql and a.makp=d.makp and a.id=c.id(+) and a.maql=e.maql(+)";
                    sql += " and b.matt=f.matt(+) and b.maqu=g.maqu(+) and b.maphuongxa=h.maphuongxa(+) and a.maql=i.maql(+)";
                    sql += " and a.mabn='" + s_mabn + "' and j.loaiba=" + i_loaiba + " order by a.id desc ";
                }
			}
			else
			{
                if (i_loaiba == 4)
                {
                    sql = "select d.makp,d.tenkp,b.hoten, b.namsinh,b.phai,a.maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngayvv, to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') ngayrv, nvl(a.chandoan,a.chandoan) chandoan, nvl(a.maicd,a.maicd) maicd,nvl(e.sothe,'') sothe, ";
                    sql += " b.sonha,b.thon,nvl(f.tentt,' ') as tentt,nvl(g.tenquan,' ') as tenquan,nvl(h.tenpxa,' ') as tenpxa,i.soluutru,a.chandoanrv as chandoanrv,nvl(a.mabs,a.mabs) as mabs ";
                    sql += " from " + m.user + m.mmyy(ngayvao.Text.Substring(0, 10)) + ".benhancc a, " + m.user + ".btdbn b," + m.user + ".btdkp_bv d," + m.user + ".bhyt e," + m.user + ".btdtt f," + m.user + ".btdquan g," + m.user + ".btdpxa h," + m.user + ".lienhe i ";
                    sql += " where a.mabn=b.mabn and a.makp=d.makp and a.maql=e.maql(+)";
                    sql += " and b.matt=f.matt(+) and b.maqu=g.maqu(+) and b.maphuongxa=h.maphuongxa(+) and a.maql=i.maql(+)";
                    sql += " and a.mabn='" + s_mabn + "' order by a.maql desc ";
                }
                else
                {
                    sql = "select d.makp,d.tenkp,b.hoten, b.namsinh,b.phai,0 as id,a.maql, to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngayvv, to_char(c.ngay,'dd/mm/yyyy hh24:mi') ngayrv, nvl(c.chandoan,a.chandoan) chandoan, nvl(c.maicd,a.maicd) maicd,nvl(e.sothe,'') sothe, ";
                    sql += " b.sonha,b.thon,nvl(f.tentt,' ') as tentt,nvl(g.tenquan,' ') as tenquan,nvl(h.tenpxa,' ') as tenpxa,i.soluutru,c.chandoan as chandoanrv,nvl(c.mabs,a.mabs) as mabs ";
                    sql += " from " + m.user + ".benhandt a, " + m.user + ".btdbn b, " + m.user + ".xuatvien c," + m.user + ".btdkp_bv d," + m.user + ".bhyt e," + m.user + ".btdtt f," + m.user + ".btdquan g," + m.user + ".btdpxa h," + m.user + ".lienhe i ";
                    sql += " where a.mabn=b.mabn and a.makp=d.makp and a.maql=c.maql(+) and a.maql=e.maql(+)";
                    sql += " and b.matt=f.matt(+) and b.maqu=g.maqu(+) and b.maphuongxa=h.maphuongxa(+) and a.maql=i.maql(+)";
                    sql += " and a.mabn='" + s_mabn + "' and a.loaiba=" + i_loaiba + " order by a.maql desc ";
                }
			}
			ds=m.get_data(sql);
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy !"),LibMedi.AccessData.Msg);
				m1.Focus();
				return;
			}
			int i=1;
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				if (i==1)
				{
					l_maql=decimal.Parse(r["maql"].ToString());
                    try { l_id = (i_loaiba == 2) ? 0 : decimal.Parse(r["id"].ToString()); }
                    catch { l_id = 0; }
					hoten.Text=r["hoten"].ToString();
					namsinh.Text=r["namsinh"].ToString();
					phai.Text=(int.Parse(r["phai"].ToString())==1)?"Nữ":"Nam";				
					diachi.Text=r["sonha"].ToString().Trim()+" "+r["thon"].ToString().Trim()+" "+r["tenpxa"].ToString().Trim()+"-"+r["tenquan"].ToString().Trim()+"-"+r["tentt"].ToString().Trim();
					chandoan.Text=r["chandoan"].ToString()+" ["+r["maicd"].ToString()+"]";
					int dd=int.Parse(r["ngayvv"].ToString().Substring(0,2));
					int mm=int.Parse(r["ngayvv"].ToString().Substring(3,2));
					int yyyy=int.Parse(r["ngayvv"].ToString().Substring(6,4));
					int hh=int.Parse(r["ngayvv"].ToString().Substring(11,2));
					int mi=int.Parse(r["ngayvv"].ToString().Substring(14,2));
					ngayvao.Value=new DateTime(yyyy,mm,dd,hh,mi,0);
                    string s_ngayra=r["ngayrv"].ToString();
                    if (s_ngayra == "") ngayra.Text = "";
                    else ngayra.Text = s_ngayra;
					tenkp.SelectedValue=r["makp"].ToString();
					sothe.Text=r["sothe"].ToString();
					soluutru.Text=r["soluutru"].ToString();
					chkVienphi.Checked=r["chandoanrv"].ToString().Trim()!="";;
				}
				i++;
                //m.updrec_ravien(dsngay, s_mabn, decimal.Parse(r["mavaovien"].ToString()), decimal.Parse(r["maql"].ToString()), decimal.Parse(r["id"].ToString()),
                //    r["hoten"].ToString(), r["namsinh"].ToString(), (r["phai"].ToString() == "0") ? "Nam" : "Nữ", r["sonha"].ToString().Trim() + " " + r["thon"].ToString().Trim() + ", " + r["tenpxa"].ToString().Trim() + ", " + r["tenquan"].ToString().Trim() + ", " + r["tentt"].ToString().Trim(),
                //    0, "", r["sothe"].ToString(), "", "", "", "", r["chandoanrv"].ToString(), r["tenkp"].ToString(), r["ngayvv"].ToString(), r["ngayrv"].ToString(),
                //    r["chandoan"].ToString(), r["maicd"].ToString(), r["makp"].ToString(), 2, 0, 1, "", r["mabs"].ToString(), "", "", true, "", "", "");
			}			
			if(ngayra.Text=="")ngayra.Text=m.Ngaygio_hienhanh;
		}

		private void butTiep_Click(object sender, System.EventArgs e)
		{
			m2.Text="";
			hoten.Text="";
			namsinh.Text="";
			phai.Text="";
			ngayra.Text="";
			chandoan.Text="";
			tenkp.SelectedIndex=-1;
			sothe.Text="";
			diachi.Text="";
			soluutru.Text="";
			l_maql=0;
			l_id=0;
			dsngay.Clear();
			dataGrid1.DataSource=null;
			lblpt.Text="";
			m1.Focus();
			chkVienphi.Checked=false;
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{			
			this.Close();
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			d.check_process_Excel();
			imp_excel();
		}

		private void load_grid()
		{
			//foreach(System.Windows.Forms.Control c in this.Controls) if (c.Name=="dataGrid1") this.Controls.Remove(c);
			dataGrid1=new System.Windows.Forms.DataGrid();
			this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
			this.dataGrid1.CaptionForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.FlatMode = true;
			this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;			
			this.dataGrid1.Location = new System.Drawing.Point(5, -16);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.RowHeaderWidth = 10;
			this.dataGrid1.Size = new System.Drawing.Size(784, 504);
			this.dataGrid1.TabIndex = 32;
			dataGrid1.DataSource=dt;
			AddGridTableStyle();
			this.p.Controls.Add(dataGrid1);
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts1=new DataGridTableStyle();
			DataGridColoredTextBoxColumn TextCol;
			delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
			ts1.MappingName = dt.TableName;
			ts1.AlternatingBackColor = Color.Beige;
			ts1.BackColor = Color.GhostWhite;
			ts1.ForeColor = Color.MidnightBlue;
			ts1.GridLineColor = Color.RoyalBlue;
			ts1.HeaderBackColor = Color.MidnightBlue;
			ts1.HeaderForeColor = Color.Lavender;
			ts1.SelectionBackColor = Color.Teal;
			ts1.SelectionForeColor = Color.PaleGreen;
			ts1.ReadOnly=false;
			ts1.RowHeaderWidth=5;

			TextCol=new DataGridColoredTextBoxColumn(de, 0);
			TextCol.MappingName = "loai";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts1);

			TextCol=new DataGridColoredTextBoxColumn(de, 1);
			TextCol.MappingName = "tenbd";
			TextCol.HeaderText = "Tên thuốc - hàm lượng";
			TextCol.Width = 200;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts1);

			TextCol=new DataGridColoredTextBoxColumn(de, 2);
			TextCol.MappingName = "dangbd";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 40;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts1);
			int i=3;
			string ngay;
			for(;i<dt.Columns.Count-7;i++)
			{
				ngay=dt.Columns[i].ColumnName.ToString().Substring(2);
				TextCol=new DataGridColoredTextBoxColumn(de,i);
				TextCol.MappingName = dt.Columns[i].ColumnName.ToString();
				TextCol.HeaderText = ngay.Substring(6,2)+"/"+ngay.Substring(4,2);
				TextCol.Width = 40;
				TextCol.Format="#,###,###.##";
				TextCol.Alignment=HorizontalAlignment.Right;
				ts1.GridColumnStyles.Add(TextCol);
				dataGrid1.TableStyles.Add(ts1);
			}
			TextCol=new DataGridColoredTextBoxColumn(de,i);
			TextCol.MappingName = "tongso";
			TextCol.HeaderText = "Tổng số";
			TextCol.Width = 60;
			TextCol.Format="#,###,###.##";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts1);

			TextCol=new DataGridColoredTextBoxColumn(de,i+1);
			TextCol.MappingName = "dongia";
			TextCol.HeaderText = "Đơn giá";
			TextCol.Width = 80;
			TextCol.Format="#,###,###.##";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts1);

			TextCol=new DataGridColoredTextBoxColumn(de,i+2);
			TextCol.MappingName = "thanhtien";
			TextCol.HeaderText = "Số tiền";
			TextCol.Width = 80;
			TextCol.Format="#,###,###.##";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts1);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			return (dataGrid1[row,0].ToString()=="1")?Color.Blue:Color.Black;
		}

		public delegate Color delegateGetColorRowCol(int row, int col);
		public class DataGridColoredTextBoxColumn : DataGridTextBoxColumn
		{
			private delegateGetColorRowCol _getColorRowCol;
			private int _column;
			public DataGridColoredTextBoxColumn(delegateGetColorRowCol getcolorRowCol, int column)
			{
				_getColorRowCol = getcolorRowCol;
				_column = column;
			}
			protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Brush backBrush, System.Drawing.Brush foreBrush, bool alignToRight)
			{
				try
				{
					foreBrush = new SolidBrush(_getColorRowCol(rowNum, this._column));
					//backBrush = new SolidBrush(Color.GhostWhite);
				}
				catch{}
				finally
				{
					base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
				}
			}
		}

		private void gan_data()
		{
			col=0;
			ds1=get_congkhai(ngayvao.Text,ngayra.Text,m1.Text+m2.Text,l_maql,l_id);
			dttmp=new System.Data.DataTable();

			dc=new DataColumn();
			dc.ColumnName="NGAY";
			dc.DataType=Type.GetType("System.String");
			dc.MaxLength=8;
			dttmp.Columns.Add(dc);

			dc=new DataColumn();
			dc.ColumnName="SOLUONG";
			dc.DataType=Type.GetType("System.Decimal");
			dttmp.Columns.Add(dc);

			dt=new System.Data.DataTable();

			dc=new DataColumn();
			dc.ColumnName="MABD";
			dc.DataType=Type.GetType("System.String");
			dt.Columns.Add(dc);

			dc=new DataColumn();
			dc.ColumnName="TENBD";
			dc.DataType=Type.GetType("System.String");
			dt.Columns.Add(dc);

			dc=new DataColumn();
			dc.ColumnName="DANGBD";
			dc.DataType=Type.GetType("System.String");
			dt.Columns.Add(dc);

			foreach(DataRow r in ds1.Tables[0].Select("true","loai,stt,nhomvp,ngay,tenbd"))
			{
				if (updrec_p_congkhai(dttmp,r["ngay"].ToString(),double.Parse(r["sotien"].ToString())))
				{
					dc=new DataColumn();
					dc.ColumnName="C_"+r["ngay"].ToString();
					dc.DataType=Type.GetType("System.Decimal");
					dt.Columns.Add(dc);
					col++;
				}
			}
			dc=new DataColumn();
			dc.ColumnName="TONGSO";
			dc.DataType=Type.GetType("System.Decimal");
			dt.Columns.Add(dc);

			dc=new DataColumn();
			dc.ColumnName="DONGIA";
			dc.DataType=Type.GetType("System.Decimal");
			dt.Columns.Add(dc);

			dc=new DataColumn();
			dc.ColumnName="THANHTIEN";
			dc.DataType=Type.GetType("System.Decimal");
			dt.Columns.Add(dc);

			dc=new DataColumn();
			dc.ColumnName="STT";
			dc.DataType=Type.GetType("System.Decimal");
			dt.Columns.Add(dc);

			dc=new DataColumn();
			dc.ColumnName="NHOMVP";
			dc.DataType=Type.GetType("System.String");
			dt.Columns.Add(dc);

			dc=new DataColumn();
			dc.ColumnName="LOAI";
			dc.DataType=Type.GetType("System.Decimal");
			dt.Columns.Add(dc);

			dc=new DataColumn();
			dc.ColumnName="BHYT";
			dc.DataType=Type.GetType("System.Decimal");
			dt.Columns.Add(dc);

			foreach(DataRow r in ds1.Tables[0].Select("true","loai,stt,nhomvp,ngay,tenbd"))
			{
				for(int i=3;i<dt.Columns.Count-6;i++)
				{
					if (r["ngay"].ToString()==dt.Columns[i].ToString().Substring(2,8))
					{
						updrec_p_congkhai(dt,r["loai"].ToString(),r["stt"].ToString(),r["nhomvp"].ToString(),r["mabd"].ToString(),r["tenbd"].ToString(),r["dangbd"].ToString(),double.Parse(r["soluong"].ToString()),double.Parse(r["dongia"].ToString()),int.Parse(r["bhyt"].ToString()),i);
						break;
					}
				}
			}
		}

		private void sort()
		{
			System.Data.DataTable dt1=new System.Data.DataTable();
			dt1=dt.Copy();
			dt.Clear();
			string nhomvp="";
			DataRow r1;
			foreach(DataRow r in dt1.Select("true","loai,stt,nhomvp,tenbd"))
			{
				if (r["nhomvp"].ToString()!=nhomvp)
				{
					r1=dt.NewRow();
					r1["mabd"]=0;
					r1["tenbd"]=r["nhomvp"].ToString().ToUpper();
					r1["dangbd"]="";
					for(int i=3;i<dt1.Columns.Count-6;i++) r1[i]=0;
					r1["tongso"]=0;
					r1["dongia"]=0;
					r1["thanhtien"]=sum(r["nhomvp"].ToString(),dt1);
					dt.Rows.Add(r1);
					nhomvp=r["nhomvp"].ToString();
				}
				r1=dt.NewRow();
				for(int i=0;i<dt1.Columns.Count;i++) r1[i]=r[i].ToString();
				dt.Rows.Add(r1);
			}
		}

		private decimal sum(string nhomvp,System.Data.DataTable tmp)
		{
			decimal  tc=0;
			foreach(DataRow r in tmp.Select("nhomvp='"+nhomvp+"'")) tc+=decimal.Parse(r["tongso"].ToString())*decimal.Parse(r["dongia"].ToString());
			return tc;
		}

		private void imp_excel()
		{
			sort();
			string tenpt="";
            sql = "select a.tenpt,to_char(a.ngay,'dd/mm/yyyy') as ngay,c.ten as loaipt,a.somat,a.molaimien from xxx.pttt a," + m.user + ".dmpttt b," + m.user + ".loaipttt c where a.mapt=b.mapt and b.loaipt=c.ma and a.mabn='" + m1.Text + m2.Text + "'";
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + ngayvao.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + ngayra.Text.Substring(0, 10) + "','dd/mm/yyyy')";
            foreach (DataRow r in d.get_data_mmyy(sql, ngayvao.Text, ngayra.Text, false).Tables[0].Rows)
			{
				tenpt+=r["tenpt"].ToString().Trim()+"("+r["loaipt"].ToString().Trim()+";"+r["ngay"].ToString()+";"+r["somat"].ToString()+")";
				tenpt+=(r["molaimien"].ToString()=="1")?" MỔ LẠI MIỄN":"";
			}
			oxl=new Excel.Application();
			owb=(Excel._Workbook)(oxl.Workbooks.Add(Missing.Value));
			osheet=(Excel._Worksheet)owb.ActiveSheet;
			int i,j,be=9,cot=dt.Columns.Count-1,dong=dt.Rows.Count;
			int tuoi=int.Parse(DateTime.Now.Year.ToString())-int.Parse(namsinh.Text.ToString());
			string ten="";
			double ftc=0;
			osheet.Cells[8,1]="TT";
			for(i=1;i<cot-6;i++)//-6
			{ 
				ten=dt.Columns[i].ColumnName.ToString();
				if (i>2) ten="'"+ten.Substring(8,2).PadLeft(2,'0')+"/"+ten.Substring(6,2).PadLeft(2,'0');//+"/"+ten.Substring(2,4);
				else ten=(i==1)?"Tên thuốc,hàm lượng":"Đơn vị";
				osheet.Cells[8,i+1]=ten;
			}
			osheet.Cells[8,i+1]="Tổng số";
			osheet.Cells[8,i+2]="Đơn giá";
			osheet.Cells[8,i+3]="Thành tiền";
			//osheet.Cells[8,i+4]="Ghi chú";
			int stt=1,tt=0;
			for(i=0;i<dong;i++)
			{
				tt=i+be;
				if (dt.Rows[i]["mabd"].ToString()=="0")	osheet.get_Range(m.getIndex(0)+tt.ToString(),m.getIndex(cot)+tt.ToString()).Font.Bold=true;
				else osheet.Cells[i+be,1]=stt;
				for(j=1;j<cot-3;j++) osheet.Cells[i+be,j+1]=dt.Rows[i][j].ToString();
				ftc+=double.Parse(dt.Rows[i][cot-6].ToString())*double.Parse(dt.Rows[i][cot-5].ToString());
				if (dt.Rows[i]["mabd"].ToString()!="0") stt++;				
				if (sothe.Text!="" && dt.Rows[i]["bhyt"].ToString()=="0")
					osheet.get_Range(m.getIndex(0)+tt.ToString(),m.getIndex(cot)+tt.ToString()).Font.Bold=true;
			}
			osheet.get_Range(d.getIndex(1)+"1",d.getIndex(1)+"1").ColumnWidth = 20;
			osheet.get_Range(d.getIndex(1)+"8",d.getIndex(1)+tt.ToString()).WrapText=true;
			j=4;
			osheet.Cells[dong+be,cot-3]=ftc;
			osheet.get_Range(m.getIndex(2)+"8",m.getIndex(cot-6)+"8").Orientation=90;
			orange=osheet.get_Range(m.getIndex(0)+"8",m.getIndex(1)+"8");
			orange.VerticalAlignment=Excel.XlVAlign.xlVAlignCenter;
			orange.HorizontalAlignment=Excel.XlVAlign.xlVAlignCenter;
			orange=osheet.get_Range(m.getIndex(cot-col-6)+"8",m.getIndex(cot)+"8");
			orange.VerticalAlignment=Excel.XlVAlign.xlVAlignCenter;
			orange.HorizontalAlignment=Excel.XlVAlign.xlVAlignCenter;
			dong+=be;
			osheet.get_Range(m.getIndex(0)+dong.ToString(),m.getIndex(cot)+dong.ToString()).Font.Bold=true;
			osheet.Cells[dong,2]="TỔNG CỘNG";
            int line=dong+1;
			osheet.get_Range(d.getIndex(0)+"8",d.getIndex(cot-4)+dong.ToString()).Borders.LineStyle=XlBorderWeight.xlHairline;
			osheet.get_Range(d.getIndex(cot-6)+"8",d.getIndex(cot-4)+dong.ToString()).NumberFormat="#,##0.00";
			dong+=4;
			osheet.get_Range(m.getIndex(0)+"8",m.getIndex(cot-4)+dong.ToString()).EntireColumn.AutoFit();
			osheet.Cells[line,1]=tenpt;
			//osheet.Cells[line+3,1]=nhomvp;
			osheet.Cells[line+3,cot-6]="Y TÁ HÀNH CHÁNH";
			osheet.Cells[1,1]=m.Syte;
			osheet.Cells[2,1]=m.Tenbv;
			osheet.Cells[1,3]="   PHIẾU TỔNG HỢP THUỐC DÙNG HÀNG NGÀY  ";
			osheet.Cells[2,3]="VÀ THANH TOÁN TIỀN CHO BỆNH NHÂN RA VIỆN";
			osheet.get_Range("C1","C2").Font.Size=11;
			osheet.get_Range("C1","C2").Font.Bold=true;
			osheet.Cells[3,1]="Khoa :"+tenkp.Text;
			osheet.Cells[4,1]="Họ tên :"+m1.Text+m2.Text+"-"+hoten.Text.Trim();
			osheet.Cells[4,6]="Tuổi "+tuoi.ToString().Trim()+" Giới tính "+phai.Text;
			osheet.Cells[4,9]="Số thẻ "+sothe.Text.Trim();
			osheet.Cells[5,1]="Địa chỉ : "+diachi.Text.Trim();
			osheet.Cells[6,1]="Số giường :"+"";
			osheet.Cells[6,3]="Số lưu trữ :"+soluutru.Text;//"Buồng :";
			osheet.Cells[6,9]="Ngày vào viện :"+ngayvao.Text.Trim();
			osheet.Cells[7,1]="Chẩn đoán : "+chandoan.Text.Trim();
			osheet.Cells[7,9]="Ngày ra viện : "+ngayra.Text.Trim();
			osheet.PageSetup.Orientation=XlPageOrientation.xlLandscape;
			//osheet.PageSetup.PaperSize=XlPaperSize.xlPaperA4;
			oxl.ActiveWindow.DisplayZeros=false;
			if (chkXem.Checked) oxl.Visible=true;
			else osheet.PrintOut(Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value);
		}

		#region phieucaongkhaithuoc
		public DataSet get_congkhai(string d_tu, string d_den, string d_mabn, decimal d_maql,decimal d_id)
		{
            if (d_den == "") d_den = m.ngayhienhanh_server;
            string sql = "delete from " + m.user + ".t_congkhai where maql=" + d_maql;
            int haophi = d.iHaophi;
            m.execute_data(sql);
            DateTime dt1 = d.StringToDate(d_tu).AddDays(-d.iNgaykiemke);
            DateTime dt2 = d.StringToDate(d_den).AddDays(d.iNgaykiemke);
            int y1 = dt1.Year, m1 = dt1.Month;
            int y2 = dt2.Year, m2 = dt2.Month;
            int itu, iden;
            string mmyy = "";		
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
                    mmyy = j.ToString().PadLeft(2, '0') + i.ToString().Substring(2, 2);
					if (m.bMmyy(mmyy))
					{
                        sql = " insert into " + m.user + ".t_congkhai " +
                            " select c.makp," + l_maql + " as maql,a.mabd,to_char(a.ngay,'yyyymmdd') ngay,sum(a.soluong) soluong,sum(a.soluong*decode(d.loai,0,a.giamua,a.giaban)) sotien,decode(d.loai,0,a.giamua,a.giaban) as dongia,0 as loai " +
                            " from " + m.user + mmyy + ".d_tienthuoc a, " + m.user + ".d_dmbd b," + m.user + ".d_duockp c," + m.user + ".d_doituong d where a.mabd=b.id and a.makp=c.id and a.madoituong=d.madoituong and a.mabn='" + d_mabn + "'";
                        if (i_loaiba == 1) sql += " and a.maql=" + d_maql;
						if (d_id!=0)
						{
                            sql += " and a.idkhoa=" + d_id.ToString();
							sql+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+d_tu.Substring(0,10)+"','dd/mm/yy') and to_date('"+d_den.Substring(0,10)+"','dd/mm/yy')";
						}
						else if (i_loaiba==2) sql+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+d_tu.Substring(0,10)+"','dd/mm/yy') and to_date('"+d_den.Substring(0,10)+"','dd/mm/yy')";
						sql+=" and a.madoituong<>"+haophi;
						if (!chkVienphi.Checked && tenkp.SelectedIndex!=-1) sql+=" and c.makp='"+tenkp.SelectedValue.ToString()+"'";
						sql+=" group by 0,c.makp,"+l_maql+",a.mabd,decode(d.loai,0,a.giamua,a.giaban),to_char(a.ngay,'yyyymmdd')";
                        m.execute_data(sql);
						if (bCapve || i_loaiba==2)
						{
							sql=" insert into "+m.user+".t_congkhai "+
								" select k.makp,"+l_maql+" as maql,a.mabd,to_char(k.ngay,'yyyymmdd') ngay,sum(a.soluong) soluong,sum(a.soluong*a.giamua) sotien,a.giamua as dongia,0 as loai "+
                                " from " + m.user + mmyy + ".bhytkb k," + m.user + mmyy + ".bhytthuoc a," + m.user + ".d_dmbd b where k.id=a.id and a.mabd=b.id and k.mabn='" + d_mabn + "'";
							if (bCapve && i_loaiba==1) sql+=" and k.maql="+d_maql;
							sql+=" and to_date(k.ngay,'dd/mm/yy') between to_date('"+d_tu.Substring(0,10)+"','dd/mm/yy') and to_date('"+d_den.Substring(0,10)+"','dd/mm/yy')";
							if (!chkVienphi.Checked && tenkp.SelectedIndex!=-1) sql+=" and k.makp='"+tenkp.SelectedValue.ToString()+"'";
							sql+=" group by 0,k.makp,"+l_maql+",a.mabd,a.giamua,to_char(k.ngay,'yyyymmdd')";
                            d.execute_data(sql);
							//hoantra
							if (i_loaiba==2)
							{
                                sql = " insert into " + m.user + ".t_congkhai " +
                                    " select k.co as makp," + l_maql + " as maql,a.mabd,to_char(k.ngaysp,'yyyymmdd') ngay,sum(-1*a.soluong) soluong,sum(-1*a.soluong*a.giamua) sotien,a.giamua as dongia,0 as loai " +
                                    " from " + m.user + mmyy + ".d_nhapll k," + m.user + mmyy + ".d_nhapct a," + m.user + ".d_dmbd b where k.id=a.id and a.mabd=b.id and k.sophieu='" + d_mabn + "'";
                                sql += " and k.loai='B' and to_date(k.ngaysp,'dd/mm/yy') between to_date('" + d_tu.Substring(0, 10) + "','dd/mm/yy') and to_date('" + d_den.Substring(0, 10) + "','dd/mm/yy')";
                                if (!chkVienphi.Checked && tenkp.SelectedIndex != -1) sql += " and trim(k.co)='" + tenkp.SelectedValue.ToString() + "'";
                                sql += " group by 0,k.co," + l_maql + ",a.mabd,a.giamua,to_char(k.ngaysp,'yyyymmdd')";
                                d.execute_data(sql);
							}
                            sql = " insert into " + m.user + ".t_congkhai " +
                                " select k.makp," + l_maql + " as maql,a.mavp as mabd,to_char(k.ngay,'yyyymmdd') ngay,sum(a.soluong) soluong,sum(a.soluong*a.dongia) sotien,a.dongia as dongia,1 as loai " +
                                " from " + m.user + mmyy + ".bhytkb k," + m.user + mmyy + ".bhytcls a," + m.user + ".v_giavp b where k.id=a.id and a.mavp=b.id and k.mabn='" + d_mabn + "'";
                            if (bCapve && i_loaiba == 1) sql += " and k.maql=" + d_maql;
                            sql += " and to_date(k.ngay,'dd/mm/yy') between to_date('" + d_tu.Substring(0, 10) + "','dd/mm/yy') and to_date('" + d_den.Substring(0, 10) + "','dd/mm/yy')";
                            if (!chkVienphi.Checked && tenkp.SelectedIndex != -1) sql += " and k.makp='" + tenkp.SelectedValue.ToString() + "'";
                            sql += " group by 1,k.makp," + l_maql + ",a.mavp,a.dongia,to_char(k.ngay,'yyyymmdd')";
                            d.execute_data(sql);
						}
                        sql = " insert into " + m.user + ".t_congkhai " +
                            " select a.makp," + l_maql + " as maql,a.mavp as mabd,to_char(a.ngay,'yyyymmdd') ngay,sum(a.soluong) soluong,sum(a.soluong*(a.dongia+a.vattu)) sotien,a.dongia+a.vattu as dongia,1 as loai "+
                            " from " + m.user + mmyy + ".v_vpkhoa a," + m.user + ".v_giavp b where a.mavp=b.id and a.mabn='" + d_mabn + "'"+
                            " and a.maql=" + d_maql;
						if (d_id!=0)
						{
							sql+=" and a.idkhoa="+d_id;
							sql+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+d_tu.Substring(0,10)+"','dd/mm/yy') and to_date('"+d_den.Substring(0,10)+"','dd/mm/yy')";
						}
                        if (!chkVienphi.Checked && tenkp.SelectedIndex != -1) sql += " and a.makp='" + tenkp.SelectedValue.ToString() + "'";
                        sql += " group by 1,a.makp," + l_maql + ",a.mavp,a.dongia+a.vattu,to_char(a.ngay,'yyyymmdd')";
						m.execute_data(sql);
						if (m.bChidinh_vienphi)
						{
                            sql = " insert into " + m.user + ".t_congkhai " +
                                " select a.makp," + l_maql + " as maql,a.mavp as mabd,to_char(a.ngay,'yyyymmdd') ngay,sum(a.soluong) soluong,sum(a.soluong*(a.dongia+a.vattu)) sotien,a.dongia+a.vattu as dongia,1 as loai " +
                                " from " + m.user + mmyy + ".v_chidinh a," + m.user + ".v_giavp b where a.mavp=b.id and a.mabn='" + d_mabn + "' and a.paid=0";
                            if (i_loaiba == 1) sql += " and a.maql=" + d_maql;
                            sql += " and to_date(a.ngay,'dd/mm/yy') between to_date('" + d_tu.Substring(0, 10) + "','dd/mm/yy') and to_date('" + d_den.Substring(0, 10) + "','dd/mm/yy')";
                            if (!chkVienphi.Checked && tenkp.SelectedIndex != -1) sql += " and a.makp='" + tenkp.SelectedValue.ToString() + "'";
                            sql += " group by 1,a.makp," + l_maql + ",a.mavp,a.dongia+a.vattu,to_char(a.ngay,'yyyymmdd')";
							m.execute_data(sql);
						}
					}
				}
			}
			if (tien_khac!=0)
			{
                sql = " insert into " + m.user + ".t_congkhai " +
                    " select distinct '01' as makp," + l_maql + " as maql,b.id as mabd,'" + d_den.Substring(6, 4) + d_den.Substring(3, 2) + d_den.Substring(0, 2) + "' as ngay,1 as soluong," + tien_khac + " as sotien," + tien_khac + " as dongia,1 as loai " +
                    " from " + m.user + ".v_giavp b," + m.user + ".v_loaivp c where b.id_loai=c.id and c.id_nhom=" + nhom_khac + " and b.gia_th=" + tien_khac;
				m.execute_data(sql);
			}
            sql = " select d.stt,d.ten as nhomvp,a.loai,a.mabd,trim(b.ten)||' '||b.hamluong as tenbd, " +
                " b.dang dangbd,a.ngay,a.soluong,a.dongia,a.sotien,b.bhyt " +
                " from " + m.user + ".t_congkhai a," + m.user + ".d_dmbd b," + m.user + ".d_dmnhom c," + m.user + ".v_nhomvp d where a.mabd=b.id and b.manhom=c.id and c.nhomvp=d.ma and a.maql=" + d_maql +
                " union all select d.stt,d.ten as nhomvp,a.loai,a.mabd,b.ten as tenbd,b.dvt dangbd,a.ngay,a.soluong,a.dongia,a.sotien,100 as bhyt " +
                " from " + m.user + ".t_congkhai a," + m.user + ".v_giavp b," + m.user + ".v_loaivp c," + m.user + ".v_nhomvp d where a.mabd=b.id and b.id_loai=c.id and c.id_nhom=d.ma and a.maql=" + d_maql;
			return m.get_data(sql);
		}
		public bool updrec_p_congkhai (System.Data.DataTable dt,string ngay,double soluong)
		{
			string exp="ngay='"+ngay+"'";
			int i=(soluong!=0)?1:0;
			DataRow r = m.getrowbyid (dt,exp); 
			if ( r == null )
			{
				DataRow nrow = dt.NewRow ( ) ;
				nrow[0] = ngay;
				nrow[1] = i;
				dt.Rows.Add ( nrow ) ;
				return true;
			}
			else
			{
				DataRow[] dr = dt.Select(exp);
				double f=double.Parse(dr[0][1].ToString())+i;
				dr[0][0] = ngay;
				dr[0][1] = f;
				return false;
			}
		}

		private void frmCongkhaiMabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F9) butIn_Click(sender,e);
			else if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

		private void tenkp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ngayvv_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==ngayvv)
			{
				if (ngayvv.Items.Count>0)
				{
					int dd=int.Parse(dsngay.Tables[0].Rows[ngayvv.SelectedIndex]["ngayvao"].ToString().Substring(0,2));
					int mm=int.Parse(dsngay.Tables[0].Rows[ngayvv.SelectedIndex]["ngayvao"].ToString().Substring(3,2));
					int yyyy=int.Parse(dsngay.Tables[0].Rows[ngayvv.SelectedIndex]["ngayvao"].ToString().Substring(6,4));
					int hh=int.Parse(dsngay.Tables[0].Rows[ngayvv.SelectedIndex]["ngayvao"].ToString().Substring(11,2));
					int mi=int.Parse(dsngay.Tables[0].Rows[ngayvv.SelectedIndex]["ngayvao"].ToString().Substring(14,2));
					ngayvao.Value=new DateTime(yyyy,mm,dd,hh,mi,0);
					ngayra.Text=dsngay.Tables[0].Rows[ngayvv.SelectedIndex]["ngayra"].ToString();
					sothe.Text=dsngay.Tables[0].Rows[ngayvv.SelectedIndex]["sothe"].ToString();
					chandoan.Text=dsngay.Tables[0].Rows[ngayvv.SelectedIndex]["chandoan"].ToString();
					tenkp.SelectedValue=dsngay.Tables[0].Rows[ngayvv.SelectedIndex]["nguoinha"].ToString();
					l_maql=decimal.Parse(dsngay.Tables[0].Rows[ngayvv.SelectedIndex]["maql"].ToString());
					l_id=decimal.Parse(dsngay.Tables[0].Rows[ngayvv.SelectedIndex]["idkhoa"].ToString());
					chkVienphi.Checked=dsngay.Tables[0].Rows[ngayvv.SelectedIndex]["makp"].ToString().Trim()!="";
				}
			}
		}

		private void ngayra_Validated(object sender, System.EventArgs e)
		{
			if (ngayra.Text=="")
			{
				ngayra.Focus();
				return;
			}
			ngayra.Text=ngayra.Text.Trim();
			if (ngayra.Text.Length<16)
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày và giờ ra viện !"));
				ngayra.Focus();
				return;
			}
			if (!m.bNgay(ngayra.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
				ngayra.Focus();
				return;
			}
			ngayra.Text=m.Ktngaygio(ngayra.Text,16);		
			if (!m.bNgaygio(ngayra.Text,ngayvao.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày ra viện không được nhỏ hơn ngày vào viện !"));
				ngayra.Focus();
				return;
			}
		}

		private void m1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			d.MaskDigit(e);
		}	

		private void m2_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			d.MaskDigit(e);
		}

		public void updrec_p_congkhai (System.Data.DataTable dt,string loai,string stt,string nhomvp,string mabd,string tenbd,string dangbd,double soluong,double dongia,int bhyt,int i)
		{
			string exp="mabd='"+mabd+"'"+" and dongia="+dongia;
			DataRow r = m.getrowbyid (dt,exp); 
			if ( r == null )
			{
				DataRow nrow = dt.NewRow ( ) ;
				nrow["loai"]=loai;
				nrow["stt"]=stt;
				nrow["nhomvp"]=nhomvp;
				nrow["mabd"] = mabd;
				nrow["tenbd"] = tenbd;
				nrow["dangbd"] = dangbd;
				for(int k=3;k<dt.Columns.Count-3;k++) nrow[k]=0;
				nrow[i] = soluong;
				nrow["tongso"]= soluong;
				nrow["dongia"]	= dongia;
				nrow["thanhtien"]=soluong*dongia;
				nrow["bhyt"]=bhyt;
				dt.Rows.Add ( nrow ) ;
			}
			else
			{
				DataRow[] dr = dt.Select(exp);
				double f=double.Parse(dr[0]["tongso"].ToString())+soluong;
				dr[0][i] = double.Parse(dr[0][i].ToString())+soluong;
				dr[0]["tongso"]= f;
				dr[0]["dongia"] = dongia;
				dr[0]["thanhtien"]=f*dongia;
			}
		}

		#endregion
	}
}
