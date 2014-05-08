using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;
using LibMedi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmVanchuyen.
	/// </summary>
	public class frmVanchuyen : System.Windows.Forms.Form
	{
        Language lan = new Language(); Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.TextBox chandoan;
		private System.Windows.Forms.TextBox sothe;
		private System.Windows.Forms.TextBox giuong;
		private System.Windows.Forms.TextBox phong;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox diachi;
		private System.Windows.Forms.TextBox phai;
		private System.Windows.Forms.TextBox namsinh;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox sovaovien;
		private System.Windows.Forms.Label label90;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.TextBox ngayvv;
		private MaskedBox.MaskedBox gio;
		private MaskedBox.MaskedBox ngay;
		private System.ComponentModel.IContainer components;
		private DataSet ds=new DataSet();
		private DataSet dsct=new DataSet();
		private DataTable dtnv=new DataTable(); 
		private LibMedi.AccessData m;
		private int i_userid;
		private string s_makp,user,xxx,s_ngayrv,sql,s_mabs,s_nhomkho,s_userid,s_tenkp;
		private decimal l_id,l_idthuchien,l_idkhoa,l_maql;
		private LibList.List listNv;
		private Brush disabledBackBrush;
		private Brush disabledTextBrush;
		private Brush alertBackBrush;
		private Font alertFont;
		private Brush alertTextBrush;
		private Font currentRowFont;
		private Brush currentRowBackBrush;
		private bool afterCurrentCellChanged=true;
		private int checkCol=2;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.ComboBox cmbNgay;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label lgio;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox khoaden;
		private System.Windows.Forms.Label label19;
		private MaskedBox.MaskedBox giovk;
		private MaskedBox.MaskedBox ngayvk;
		private System.Windows.Forms.Label label20;
		private MaskedBox.MaskedBox giork;
		private MaskedBox.MaskedBox ngayrk;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private MaskedTextBox.MaskedTextBox m_cc;
		private MaskedBox.MaskedBox t_cc;
		private MaskedBox.MaskedBox ha_cc;
		private MaskedTextBox.MaskedTextBox nt_cc;
		private System.Windows.Forms.ComboBox tg_cc;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.TextBox khac;
		private System.Windows.Forms.TextBox tenbs_cc;
		private MaskedTextBox.MaskedTextBox bs_cc;
		private System.Windows.Forms.TextBox tenbs_vc;
		private MaskedTextBox.MaskedTextBox bs_vc;
		private System.Windows.Forms.ComboBox tg_vc;
		private MaskedTextBox.MaskedTextBox m_vc;
		private MaskedBox.MaskedBox t_vc;
		private MaskedBox.MaskedBox ha_vc;
		private MaskedTextBox.MaskedTextBox nt_vc;
		private System.Windows.Forms.ComboBox tg_kd;
		private MaskedTextBox.MaskedTextBox m_kd;
		private MaskedBox.MaskedBox t_kd;
		private MaskedBox.MaskedBox ha_kd;
		private MaskedTextBox.MaskedTextBox nt_kd;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.TextBox tenbs_kd;
		private MaskedTextBox.MaskedTextBox bs_kd;
		private System.Windows.Forms.TextBox tendd_kd;
		private MaskedTextBox.MaskedTextBox dd_kd;
		private System.Windows.Forms.TextBox tendd_vc;
		private MaskedTextBox.MaskedTextBox dd_vc;
		private System.Windows.Forms.TextBox tendd_cc;
		private MaskedTextBox.MaskedTextBox dd_cc;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.Label label53;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.CheckBox chkThangmay;
		private System.Windows.Forms.NumericUpDown thangmay;
		private System.Windows.Forms.Label label55;
		private System.Windows.Forms.Label label56;
		private System.Windows.Forms.NumericUpDown phongmo;
		private System.Windows.Forms.CheckBox chkPhongmo;
		private System.Windows.Forms.Label label57;
		private System.Windows.Forms.NumericUpDown nhanbenh;
		private System.Windows.Forms.CheckBox chkNhanbenh;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel6;
		private MaskedBox.MaskedBox ngayluc;
		private MaskedBox.MaskedBox gioluc;
		private MaskedBox.MaskedBox ngayve;
		private MaskedBox.MaskedBox giove;
		private System.Windows.Forms.CheckBox chkXML;

		public frmVanchuyen(LibMedi.AccessData acc,string _mabn,decimal _maql,decimal _idkhoa,decimal _idthuchien,string _sovaovien,string _makp,string _hoten,string _namsinh,string _phai,string _diachi,string _ngayvv,string _sothe,string _phong,string _giuong,string _ngayrv,string _mabs,int _userid,string _nhomkho,string suserid,string _chandoan,string _tenkp)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m=acc;mabn.Text=_mabn;l_maql=_maql;l_idkhoa=_idkhoa;l_idthuchien=_idthuchien;sovaovien.Text=_sovaovien;i_userid=_userid;s_tenkp=_tenkp;
			hoten.Text=_hoten;chandoan.Text=_chandoan;s_makp=_makp;namsinh.Text=_namsinh;phai.Text=_phai;diachi.Text=_diachi;s_mabs=_mabs;s_nhomkho=_nhomkho;
			ngayvv.Text=_ngayvv;sothe.Text=_sothe;phong.Text=_phong;giuong.Text=_giuong;s_ngayrv=_ngayrv;s_userid=suserid;
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
					if(disabledBackBrush != null)
					{
						disabledBackBrush.Dispose();
						disabledTextBrush.Dispose();
						alertBackBrush.Dispose();
						alertFont.Dispose();
						alertTextBrush.Dispose();
						currentRowFont.Dispose();
						currentRowBackBrush.Dispose();
					}
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVanchuyen));
            this.chandoan = new System.Windows.Forms.TextBox();
            this.sothe = new System.Windows.Forms.TextBox();
            this.giuong = new System.Windows.Forms.TextBox();
            this.phong = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ngayvv = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.diachi = new System.Windows.Forms.TextBox();
            this.phai = new System.Windows.Forms.TextBox();
            this.namsinh = new System.Windows.Forms.TextBox();
            this.hoten = new System.Windows.Forms.TextBox();
            this.mabn = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sovaovien = new System.Windows.Forms.TextBox();
            this.gio = new MaskedBox.MaskedBox();
            this.ngay = new MaskedBox.MaskedBox();
            this.lgio = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.listNv = new LibList.List();
            this.khac = new System.Windows.Forms.TextBox();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tenbs_cc = new System.Windows.Forms.TextBox();
            this.bs_cc = new MaskedTextBox.MaskedTextBox();
            this.tenbs_vc = new System.Windows.Forms.TextBox();
            this.bs_vc = new MaskedTextBox.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbNgay = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.m_cc = new MaskedTextBox.MaskedTextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.t_cc = new MaskedBox.MaskedBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.ha_cc = new MaskedBox.MaskedBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.nt_cc = new MaskedTextBox.MaskedTextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.khoaden = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.giovk = new MaskedBox.MaskedBox();
            this.ngayvk = new MaskedBox.MaskedBox();
            this.label20 = new System.Windows.Forms.Label();
            this.giork = new MaskedBox.MaskedBox();
            this.ngayrk = new MaskedBox.MaskedBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.tg_cc = new System.Windows.Forms.ComboBox();
            this.tg_vc = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.m_vc = new MaskedTextBox.MaskedTextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.t_vc = new MaskedBox.MaskedBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.ha_vc = new MaskedBox.MaskedBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.nt_vc = new MaskedTextBox.MaskedTextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.tg_kd = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.m_kd = new MaskedTextBox.MaskedTextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.t_kd = new MaskedBox.MaskedBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.ha_kd = new MaskedBox.MaskedBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.nt_kd = new MaskedTextBox.MaskedTextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.tenbs_kd = new System.Windows.Forms.TextBox();
            this.bs_kd = new MaskedTextBox.MaskedTextBox();
            this.tendd_kd = new System.Windows.Forms.TextBox();
            this.dd_kd = new MaskedTextBox.MaskedTextBox();
            this.tendd_vc = new System.Windows.Forms.TextBox();
            this.dd_vc = new MaskedTextBox.MaskedTextBox();
            this.tendd_cc = new System.Windows.Forms.TextBox();
            this.dd_cc = new MaskedTextBox.MaskedTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.ngayluc = new MaskedBox.MaskedBox();
            this.gioluc = new MaskedBox.MaskedBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.ngayve = new MaskedBox.MaskedBox();
            this.giove = new MaskedBox.MaskedBox();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.chkThangmay = new System.Windows.Forms.CheckBox();
            this.thangmay = new System.Windows.Forms.NumericUpDown();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.phongmo = new System.Windows.Forms.NumericUpDown();
            this.chkPhongmo = new System.Windows.Forms.CheckBox();
            this.label57 = new System.Windows.Forms.Label();
            this.nhanbenh = new System.Windows.Forms.NumericUpDown();
            this.chkNhanbenh = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thangmay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phongmo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhanbenh)).BeginInit();
            this.SuspendLayout();
            // 
            // chandoan
            // 
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(75, 49);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(637, 21);
            this.chandoan.TabIndex = 71;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(372, 26);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(164, 21);
            this.sothe.TabIndex = 63;
            // 
            // giuong
            // 
            this.giuong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giuong.Enabled = false;
            this.giuong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giuong.Location = new System.Drawing.Point(752, 26);
            this.giuong.Name = "giuong";
            this.giuong.Size = new System.Drawing.Size(136, 21);
            this.giuong.TabIndex = 70;
            // 
            // phong
            // 
            this.phong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phong.Enabled = false;
            this.phong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phong.Location = new System.Drawing.Point(584, 26);
            this.phong.Name = "phong";
            this.phong.Size = new System.Drawing.Size(120, 21);
            this.phong.TabIndex = 69;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(-3, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 16);
            this.label13.TabIndex = 68;
            this.label13.Text = "Chẩn đoán :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(704, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 16);
            this.label12.TabIndex = 67;
            this.label12.Text = "Giường :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(533, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 16);
            this.label11.TabIndex = 66;
            this.label11.Text = "Phòng :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngayvv
            // 
            this.ngayvv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvv.Enabled = false;
            this.ngayvv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvv.Location = new System.Drawing.Point(75, 26);
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(109, 21);
            this.ngayvv.TabIndex = 65;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(31, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 16);
            this.label7.TabIndex = 64;
            this.label7.Text = "Ngày :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(323, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 62;
            this.label6.Text = "Số thẻ :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // diachi
            // 
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(539, 3);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(349, 21);
            this.diachi.TabIndex = 61;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.Enabled = false;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Location = new System.Drawing.Point(459, 3);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(32, 21);
            this.phai.TabIndex = 60;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(372, 3);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(32, 21);
            this.namsinh.TabIndex = 59;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(179, 3);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(160, 21);
            this.hoten.TabIndex = 58;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(75, 3);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(56, 21);
            this.mabn.TabIndex = 52;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(491, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 57;
            this.label5.Text = "Địa chỉ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(403, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 56;
            this.label4.Text = "Giới tính :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(339, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 55;
            this.label3.Text = "NS :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(131, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 54;
            this.label1.Text = "Họ tên :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(22, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 16);
            this.label10.TabIndex = 53;
            this.label10.Text = "Mã BN :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(184, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 72;
            this.label2.Text = "Số vào viện :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sovaovien
            // 
            this.sovaovien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sovaovien.Enabled = false;
            this.sovaovien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sovaovien.Location = new System.Drawing.Point(256, 26);
            this.sovaovien.Name = "sovaovien";
            this.sovaovien.Size = new System.Drawing.Size(64, 21);
            this.sovaovien.TabIndex = 73;
            // 
            // gio
            // 
            this.gio.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gio.Enabled = false;
            this.gio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gio.Location = new System.Drawing.Point(853, 49);
            this.gio.Mask = "##:##";
            this.gio.Name = "gio";
            this.gio.Size = new System.Drawing.Size(36, 21);
            this.gio.TabIndex = 2;
            this.gio.Text = "  :  ";
            this.gio.Validated += new System.EventHandler(this.gio_Validated);
            // 
            // ngay
            // 
            this.ngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay.Enabled = false;
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Location = new System.Drawing.Point(753, 49);
            this.ngay.Mask = "##/##/####";
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(72, 21);
            this.ngay.TabIndex = 1;
            this.ngay.Text = "  /  /    ";
            this.ngay.Validated += new System.EventHandler(this.ngay_Validated);
            // 
            // lgio
            // 
            this.lgio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lgio.Location = new System.Drawing.Point(823, 51);
            this.lgio.Name = "lgio";
            this.lgio.Size = new System.Drawing.Size(32, 16);
            this.lgio.TabIndex = 302;
            this.lgio.Text = "Giờ :";
            this.lgio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label90
            // 
            this.label90.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label90.Location = new System.Drawing.Point(8, 545);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(112, 16);
            this.label90.TabIndex = 301;
            this.label90.Text = "Bàn giao xong lúc :";
            this.label90.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid1.Location = new System.Drawing.Point(0, 174);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(888, 258);
            this.dataGrid1.TabIndex = 54;
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // butMoi
            // 
            this.butMoi.Location = new System.Drawing.Point(201, 598);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 48;
            this.butMoi.Text = "&Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Location = new System.Drawing.Point(271, 598);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 49;
            this.butSua.Text = "&Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Location = new System.Drawing.Point(341, 598);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 46;
            this.butLuu.Text = "&Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Location = new System.Drawing.Point(411, 598);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 47;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Location = new System.Drawing.Point(481, 598);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 50;
            this.butHuy.Text = "&Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butIn
            // 
            this.butIn.Location = new System.Drawing.Point(551, 598);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 51;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Location = new System.Drawing.Point(621, 598);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 52;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // listNv
            // 
            this.listNv.BackColor = System.Drawing.SystemColors.Info;
            this.listNv.ColumnCount = 0;
            this.listNv.Location = new System.Drawing.Point(32, 504);
            this.listNv.MatchBufferTimeOut = 1000;
            this.listNv.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listNv.Name = "listNv";
            this.listNv.Size = new System.Drawing.Size(75, 17);
            this.listNv.TabIndex = 311;
            this.listNv.TextIndex = -1;
            this.listNv.TextMember = null;
            this.listNv.ValueIndex = -1;
            this.listNv.Visible = false;
            // 
            // khac
            // 
            this.khac.BackColor = System.Drawing.SystemColors.HighlightText;
            this.khac.Enabled = false;
            this.khac.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khac.Location = new System.Drawing.Point(120, 501);
            this.khac.Multiline = true;
            this.khac.Name = "khac";
            this.khac.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.khac.Size = new System.Drawing.Size(768, 40);
            this.khac.TabIndex = 35;
            // 
            // chkXML
            // 
            this.chkXML.Location = new System.Drawing.Point(8, 592);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(88, 24);
            this.chkXML.TabIndex = 324;
            this.chkXML.Text = "Xuất ra XML";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(-7, 435);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 16);
            this.label8.TabIndex = 325;
            this.label8.Text = "Bác sĩ :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(-7, 460);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 16);
            this.label9.TabIndex = 326;
            this.label9.Text = "Điều dưỡng :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenbs_cc
            // 
            this.tenbs_cc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs_cc.Enabled = false;
            this.tenbs_cc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs_cc.Location = new System.Drawing.Point(186, 436);
            this.tenbs_cc.Name = "tenbs_cc";
            this.tenbs_cc.Size = new System.Drawing.Size(214, 21);
            this.tenbs_cc.TabIndex = 24;
            this.tenbs_cc.TextChanged += new System.EventHandler(this.tenbs_cc_TextChanged);
            this.tenbs_cc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // bs_cc
            // 
            this.bs_cc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bs_cc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.bs_cc.Enabled = false;
            this.bs_cc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bs_cc.Location = new System.Drawing.Point(145, 436);
            this.bs_cc.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.bs_cc.MaxLength = 9;
            this.bs_cc.Name = "bs_cc";
            this.bs_cc.Size = new System.Drawing.Size(40, 21);
            this.bs_cc.TabIndex = 23;
            this.bs_cc.Validated += new System.EventHandler(this.bs_cc_Validated);
            this.bs_cc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tenbs_vc
            // 
            this.tenbs_vc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs_vc.Enabled = false;
            this.tenbs_vc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs_vc.Location = new System.Drawing.Point(459, 436);
            this.tenbs_vc.Name = "tenbs_vc";
            this.tenbs_vc.Size = new System.Drawing.Size(189, 21);
            this.tenbs_vc.TabIndex = 26;
            this.tenbs_vc.TextChanged += new System.EventHandler(this.tenbs_vc_TextChanged);
            this.tenbs_vc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // bs_vc
            // 
            this.bs_vc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bs_vc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.bs_vc.Enabled = false;
            this.bs_vc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bs_vc.Location = new System.Drawing.Point(417, 436);
            this.bs_vc.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.bs_vc.MaxLength = 9;
            this.bs_vc.Name = "bs_vc";
            this.bs_vc.Size = new System.Drawing.Size(40, 21);
            this.bs_vc.TabIndex = 25;
            this.bs_vc.Validated += new System.EventHandler(this.bs_vc_Validated);
            this.bs_vc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(713, 50);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 16);
            this.label14.TabIndex = 327;
            this.label14.Text = "Ngày :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbNgay
            // 
            this.cmbNgay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbNgay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNgay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNgay.Location = new System.Drawing.Point(752, 49);
            this.cmbNgay.Name = "cmbNgay";
            this.cmbNgay.Size = new System.Drawing.Size(136, 21);
            this.cmbNgay.TabIndex = 0;
            this.cmbNgay.SelectedIndexChanged += new System.EventHandler(this.cmbNgay_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(168, 170);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 16);
            this.label15.TabIndex = 341;
            this.label15.Text = "Tri giác :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label48
            // 
            this.label48.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.Location = new System.Drawing.Point(184, 123);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(40, 16);
            this.label48.TabIndex = 330;
            this.label48.Text = "Mạch :";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_cc
            // 
            this.m_cc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.m_cc.Enabled = false;
            this.m_cc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cc.Location = new System.Drawing.Point(224, 123);
            this.m_cc.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.m_cc.MaxLength = 5;
            this.m_cc.Name = "m_cc";
            this.m_cc.Size = new System.Drawing.Size(32, 21);
            this.m_cc.TabIndex = 8;
            this.m_cc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label39
            // 
            this.label39.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label39.Location = new System.Drawing.Point(259, 124);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(21, 19);
            this.label39.TabIndex = 337;
            this.label39.Text = "l/p";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label47
            // 
            this.label47.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.Location = new System.Drawing.Point(288, 146);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(24, 16);
            this.label47.TabIndex = 331;
            this.label47.Text = "T° :";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_cc
            // 
            this.t_cc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.t_cc.Enabled = false;
            this.t_cc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_cc.Location = new System.Drawing.Point(312, 146);
            this.t_cc.Mask = "##.##";
            this.t_cc.Name = "t_cc";
            this.t_cc.Size = new System.Drawing.Size(44, 21);
            this.t_cc.TabIndex = 11;
            this.t_cc.Text = "  .  ";
            // 
            // label40
            // 
            this.label40.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label40.Location = new System.Drawing.Point(360, 147);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(24, 16);
            this.label40.TabIndex = 338;
            this.label40.Text = "°C";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label46
            // 
            this.label46.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(280, 123);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(32, 16);
            this.label46.TabIndex = 333;
            this.label46.Text = "HA :";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ha_cc
            // 
            this.ha_cc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ha_cc.Enabled = false;
            this.ha_cc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ha_cc.Location = new System.Drawing.Point(312, 123);
            this.ha_cc.Mask = "###/###";
            this.ha_cc.Name = "ha_cc";
            this.ha_cc.Size = new System.Drawing.Size(44, 21);
            this.ha_cc.TabIndex = 9;
            this.ha_cc.Text = "   /   ";
            // 
            // label41
            // 
            this.label41.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label41.Location = new System.Drawing.Point(360, 126);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(38, 16);
            this.label41.TabIndex = 339;
            this.label41.Text = "mmHg";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label45
            // 
            this.label45.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(168, 146);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(56, 16);
            this.label45.TabIndex = 335;
            this.label45.Text = "Nhịp thở :";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nt_cc
            // 
            this.nt_cc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nt_cc.Enabled = false;
            this.nt_cc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nt_cc.Location = new System.Drawing.Point(224, 146);
            this.nt_cc.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.nt_cc.MaxLength = 5;
            this.nt_cc.Name = "nt_cc";
            this.nt_cc.Size = new System.Drawing.Size(32, 21);
            this.nt_cc.TabIndex = 10;
            this.nt_cc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label42
            // 
            this.label42.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label42.Location = new System.Drawing.Point(259, 147);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(19, 16);
            this.label42.TabIndex = 340;
            this.label42.Text = "l/p";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(6, 74);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 16);
            this.label18.TabIndex = 343;
            this.label18.Text = "Khoa đến :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // khoaden
            // 
            this.khoaden.BackColor = System.Drawing.SystemColors.HighlightText;
            this.khoaden.Enabled = false;
            this.khoaden.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khoaden.Location = new System.Drawing.Point(75, 72);
            this.khoaden.Name = "khoaden";
            this.khoaden.Size = new System.Drawing.Size(349, 21);
            this.khoaden.TabIndex = 3;
            this.khoaden.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(416, 75);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(120, 16);
            this.label19.TabIndex = 345;
            this.label19.Text = "Giờ rời khoa cấp cứu :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // giovk
            // 
            this.giovk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giovk.Enabled = false;
            this.giovk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giovk.Location = new System.Drawing.Point(752, 72);
            this.giovk.Mask = "##:##";
            this.giovk.Name = "giovk";
            this.giovk.Size = new System.Drawing.Size(34, 21);
            this.giovk.TabIndex = 6;
            this.giovk.Text = "  :  ";
            this.giovk.Validated += new System.EventHandler(this.giovk_Validated);
            // 
            // ngayvk
            // 
            this.ngayvk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvk.Enabled = false;
            this.ngayvk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvk.Location = new System.Drawing.Point(824, 72);
            this.ngayvk.Mask = "##/##/####";
            this.ngayvk.Name = "ngayvk";
            this.ngayvk.Size = new System.Drawing.Size(64, 21);
            this.ngayvk.TabIndex = 7;
            this.ngayvk.Text = "  /  /    ";
            this.ngayvk.Validated += new System.EventHandler(this.ngayvk_Validated);
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(570, 74);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(40, 16);
            this.label20.TabIndex = 348;
            this.label20.Text = "Ngày :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // giork
            // 
            this.giork.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giork.Enabled = false;
            this.giork.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giork.Location = new System.Drawing.Point(536, 72);
            this.giork.Mask = "##:##";
            this.giork.Name = "giork";
            this.giork.Size = new System.Drawing.Size(34, 21);
            this.giork.TabIndex = 4;
            this.giork.Text = "  :  ";
            this.giork.Validated += new System.EventHandler(this.giork_Validated);
            // 
            // ngayrk
            // 
            this.ngayrk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayrk.Enabled = false;
            this.ngayrk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayrk.Location = new System.Drawing.Point(611, 72);
            this.ngayrk.Mask = "##/##/####";
            this.ngayrk.Name = "ngayrk";
            this.ngayrk.Size = new System.Drawing.Size(64, 21);
            this.ngayrk.TabIndex = 5;
            this.ngayrk.Text = "  /  /    ";
            this.ngayrk.Validated += new System.EventHandler(this.ngayrk_Validated);
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(632, 75);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(120, 16);
            this.label21.TabIndex = 351;
            this.label21.Text = "Giờ đến khoa :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(784, 74);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(40, 16);
            this.label22.TabIndex = 352;
            this.label22.Text = "Ngày :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tg_cc
            // 
            this.tg_cc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tg_cc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tg_cc.Enabled = false;
            this.tg_cc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tg_cc.Items.AddRange(new object[] {
            "Tỉnh",
            "Lơ mơ",
            "Mê"});
            this.tg_cc.Location = new System.Drawing.Point(224, 169);
            this.tg_cc.Name = "tg_cc";
            this.tg_cc.Size = new System.Drawing.Size(136, 21);
            this.tg_cc.TabIndex = 12;
            this.tg_cc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tg_vc
            // 
            this.tg_vc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tg_vc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tg_vc.Enabled = false;
            this.tg_vc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tg_vc.Items.AddRange(new object[] {
            "Tỉnh",
            "Lơ mơ",
            "Mê"});
            this.tg_vc.Location = new System.Drawing.Point(471, 169);
            this.tg_vc.Name = "tg_vc";
            this.tg_vc.Size = new System.Drawing.Size(136, 21);
            this.tg_vc.TabIndex = 17;
            this.tg_vc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(407, 170);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(64, 16);
            this.label23.TabIndex = 366;
            this.label23.Text = "Tri giác :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(431, 123);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(40, 16);
            this.label24.TabIndex = 358;
            this.label24.Text = "Mạch :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_vc
            // 
            this.m_vc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.m_vc.Enabled = false;
            this.m_vc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_vc.Location = new System.Drawing.Point(471, 123);
            this.m_vc.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.m_vc.MaxLength = 5;
            this.m_vc.Name = "m_vc";
            this.m_vc.Size = new System.Drawing.Size(32, 21);
            this.m_vc.TabIndex = 13;
            this.m_vc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label25.Location = new System.Drawing.Point(506, 124);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(21, 19);
            this.label25.TabIndex = 362;
            this.label25.Text = "l/p";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(535, 146);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(24, 16);
            this.label26.TabIndex = 359;
            this.label26.Text = "T° :";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_vc
            // 
            this.t_vc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.t_vc.Enabled = false;
            this.t_vc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_vc.Location = new System.Drawing.Point(559, 146);
            this.t_vc.Mask = "##.##";
            this.t_vc.Name = "t_vc";
            this.t_vc.Size = new System.Drawing.Size(44, 21);
            this.t_vc.TabIndex = 16;
            this.t_vc.Text = "  .  ";
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label27.Location = new System.Drawing.Point(607, 147);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(24, 16);
            this.label27.TabIndex = 363;
            this.label27.Text = "°C";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(527, 123);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(32, 16);
            this.label28.TabIndex = 360;
            this.label28.Text = "HA :";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ha_vc
            // 
            this.ha_vc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ha_vc.Enabled = false;
            this.ha_vc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ha_vc.Location = new System.Drawing.Point(559, 123);
            this.ha_vc.Mask = "###/###";
            this.ha_vc.Name = "ha_vc";
            this.ha_vc.Size = new System.Drawing.Size(44, 21);
            this.ha_vc.TabIndex = 14;
            this.ha_vc.Text = "   /   ";
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label29.Location = new System.Drawing.Point(607, 126);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(38, 16);
            this.label29.TabIndex = 364;
            this.label29.Text = "mmHg";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(415, 146);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(56, 16);
            this.label30.TabIndex = 361;
            this.label30.Text = "Nhịp thở :";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nt_vc
            // 
            this.nt_vc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nt_vc.Enabled = false;
            this.nt_vc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nt_vc.Location = new System.Drawing.Point(471, 146);
            this.nt_vc.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.nt_vc.MaxLength = 5;
            this.nt_vc.Name = "nt_vc";
            this.nt_vc.Size = new System.Drawing.Size(32, 21);
            this.nt_vc.TabIndex = 15;
            this.nt_vc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label31.Location = new System.Drawing.Point(506, 147);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(19, 16);
            this.label31.TabIndex = 365;
            this.label31.Text = "l/p";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tg_kd
            // 
            this.tg_kd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tg_kd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tg_kd.Enabled = false;
            this.tg_kd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tg_kd.Items.AddRange(new object[] {
            "Tỉnh",
            "Lơ mơ",
            "Mê"});
            this.tg_kd.Location = new System.Drawing.Point(720, 169);
            this.tg_kd.Name = "tg_kd";
            this.tg_kd.Size = new System.Drawing.Size(136, 21);
            this.tg_kd.TabIndex = 22;
            this.tg_kd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(648, 170);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(72, 16);
            this.label32.TabIndex = 380;
            this.label32.Text = "Tri giác :";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(680, 123);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(40, 16);
            this.label33.TabIndex = 372;
            this.label33.Text = "Mạch :";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_kd
            // 
            this.m_kd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.m_kd.Enabled = false;
            this.m_kd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_kd.Location = new System.Drawing.Point(720, 123);
            this.m_kd.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.m_kd.MaxLength = 5;
            this.m_kd.Name = "m_kd";
            this.m_kd.Size = new System.Drawing.Size(32, 21);
            this.m_kd.TabIndex = 18;
            this.m_kd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label34
            // 
            this.label34.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label34.Location = new System.Drawing.Point(755, 124);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(21, 19);
            this.label34.TabIndex = 376;
            this.label34.Text = "l/p";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label35
            // 
            this.label35.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(784, 146);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(24, 16);
            this.label35.TabIndex = 373;
            this.label35.Text = "T° :";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_kd
            // 
            this.t_kd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.t_kd.Enabled = false;
            this.t_kd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_kd.Location = new System.Drawing.Point(808, 146);
            this.t_kd.Mask = "##.##";
            this.t_kd.Name = "t_kd";
            this.t_kd.Size = new System.Drawing.Size(44, 21);
            this.t_kd.TabIndex = 21;
            this.t_kd.Text = "  .  ";
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label36.Location = new System.Drawing.Point(856, 147);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(24, 16);
            this.label36.TabIndex = 377;
            this.label36.Text = "°C";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label37
            // 
            this.label37.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(776, 123);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(32, 16);
            this.label37.TabIndex = 374;
            this.label37.Text = "HA :";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ha_kd
            // 
            this.ha_kd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ha_kd.Enabled = false;
            this.ha_kd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ha_kd.Location = new System.Drawing.Point(808, 123);
            this.ha_kd.Mask = "###/###";
            this.ha_kd.Name = "ha_kd";
            this.ha_kd.Size = new System.Drawing.Size(44, 21);
            this.ha_kd.TabIndex = 19;
            this.ha_kd.Text = "   /   ";
            // 
            // label38
            // 
            this.label38.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label38.Location = new System.Drawing.Point(856, 126);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(38, 16);
            this.label38.TabIndex = 378;
            this.label38.Text = "mmHg";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label43
            // 
            this.label43.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(664, 146);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(56, 16);
            this.label43.TabIndex = 375;
            this.label43.Text = "Nhịp thở :";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nt_kd
            // 
            this.nt_kd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nt_kd.Enabled = false;
            this.nt_kd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nt_kd.Location = new System.Drawing.Point(720, 146);
            this.nt_kd.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.nt_kd.MaxLength = 5;
            this.nt_kd.Name = "nt_kd";
            this.nt_kd.Size = new System.Drawing.Size(32, 21);
            this.nt_kd.TabIndex = 20;
            this.nt_kd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label44
            // 
            this.label44.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label44.Location = new System.Drawing.Point(755, 147);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(19, 16);
            this.label44.TabIndex = 379;
            this.label44.Text = "l/p";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label49
            // 
            this.label49.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.Location = new System.Drawing.Point(232, 100);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(128, 16);
            this.label49.TabIndex = 382;
            this.label49.Text = "KHOA CẤP CỨU";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label50
            // 
            this.label50.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.Location = new System.Drawing.Point(464, 100);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(128, 16);
            this.label50.TabIndex = 383;
            this.label50.Text = "VẬN CHUYỂN";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label51
            // 
            this.label51.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.Location = new System.Drawing.Point(720, 100);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(128, 16);
            this.label51.TabIndex = 384;
            this.label51.Text = "KHOA ĐẾN";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tenbs_kd
            // 
            this.tenbs_kd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs_kd.Enabled = false;
            this.tenbs_kd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs_kd.Location = new System.Drawing.Point(706, 436);
            this.tenbs_kd.Name = "tenbs_kd";
            this.tenbs_kd.Size = new System.Drawing.Size(174, 21);
            this.tenbs_kd.TabIndex = 28;
            this.tenbs_kd.TextChanged += new System.EventHandler(this.tenbs_kd_TextChanged);
            this.tenbs_kd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // bs_kd
            // 
            this.bs_kd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bs_kd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.bs_kd.Enabled = false;
            this.bs_kd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bs_kd.Location = new System.Drawing.Point(665, 436);
            this.bs_kd.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.bs_kd.MaxLength = 9;
            this.bs_kd.Name = "bs_kd";
            this.bs_kd.Size = new System.Drawing.Size(40, 21);
            this.bs_kd.TabIndex = 27;
            this.bs_kd.Validated += new System.EventHandler(this.bs_kd_Validated);
            this.bs_kd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tendd_kd
            // 
            this.tendd_kd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendd_kd.Enabled = false;
            this.tendd_kd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendd_kd.Location = new System.Drawing.Point(706, 459);
            this.tendd_kd.Name = "tendd_kd";
            this.tendd_kd.Size = new System.Drawing.Size(174, 21);
            this.tendd_kd.TabIndex = 34;
            this.tendd_kd.TextChanged += new System.EventHandler(this.tendd_kd_TextChanged);
            this.tendd_kd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // dd_kd
            // 
            this.dd_kd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dd_kd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.dd_kd.Enabled = false;
            this.dd_kd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dd_kd.Location = new System.Drawing.Point(665, 459);
            this.dd_kd.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.dd_kd.MaxLength = 9;
            this.dd_kd.Name = "dd_kd";
            this.dd_kd.Size = new System.Drawing.Size(40, 21);
            this.dd_kd.TabIndex = 33;
            this.dd_kd.Validated += new System.EventHandler(this.dd_kd_Validated);
            this.dd_kd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tendd_vc
            // 
            this.tendd_vc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendd_vc.Enabled = false;
            this.tendd_vc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendd_vc.Location = new System.Drawing.Point(459, 459);
            this.tendd_vc.Name = "tendd_vc";
            this.tendd_vc.Size = new System.Drawing.Size(189, 21);
            this.tendd_vc.TabIndex = 32;
            this.tendd_vc.TextChanged += new System.EventHandler(this.tendd_vc_TextChanged);
            this.tendd_vc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // dd_vc
            // 
            this.dd_vc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dd_vc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.dd_vc.Enabled = false;
            this.dd_vc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dd_vc.Location = new System.Drawing.Point(417, 459);
            this.dd_vc.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.dd_vc.MaxLength = 9;
            this.dd_vc.Name = "dd_vc";
            this.dd_vc.Size = new System.Drawing.Size(40, 21);
            this.dd_vc.TabIndex = 31;
            this.dd_vc.Validated += new System.EventHandler(this.dd_vc_Validated);
            this.dd_vc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tendd_cc
            // 
            this.tendd_cc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendd_cc.Enabled = false;
            this.tendd_cc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendd_cc.Location = new System.Drawing.Point(186, 459);
            this.tendd_cc.Name = "tendd_cc";
            this.tendd_cc.Size = new System.Drawing.Size(214, 21);
            this.tendd_cc.TabIndex = 30;
            this.tendd_cc.TextChanged += new System.EventHandler(this.tendd_cc_TextChanged);
            this.tendd_cc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // dd_cc
            // 
            this.dd_cc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dd_cc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.dd_cc.Enabled = false;
            this.dd_cc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dd_cc.Location = new System.Drawing.Point(145, 459);
            this.dd_cc.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.dd_cc.MaxLength = 9;
            this.dd_cc.Name = "dd_cc";
            this.dd_cc.Size = new System.Drawing.Size(40, 21);
            this.dd_cc.TabIndex = 29;
            this.dd_cc.Validated += new System.EventHandler(this.dd_cc_Validated);
            this.dd_cc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(16, 483);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(408, 16);
            this.label16.TabIndex = 393;
            this.label16.Text = "Nguyên nhân khác :  (Ghi cụ thể : thiếu brancard, chờ phẫu thuật viên ... )";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ngayluc
            // 
            this.ngayluc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayluc.Enabled = false;
            this.ngayluc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayluc.Location = new System.Drawing.Point(196, 543);
            this.ngayluc.Mask = "##/##/####";
            this.ngayluc.Name = "ngayluc";
            this.ngayluc.Size = new System.Drawing.Size(64, 21);
            this.ngayluc.TabIndex = 37;
            this.ngayluc.Text = "  /  /    ";
            this.ngayluc.Validated += new System.EventHandler(this.ngayluc_Validated);
            // 
            // gioluc
            // 
            this.gioluc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gioluc.Enabled = false;
            this.gioluc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gioluc.Location = new System.Drawing.Point(120, 543);
            this.gioluc.Mask = "##:##";
            this.gioluc.Name = "gioluc";
            this.gioluc.Size = new System.Drawing.Size(34, 21);
            this.gioluc.TabIndex = 36;
            this.gioluc.Text = "  :  ";
            this.gioluc.Validated += new System.EventHandler(this.gioluc_Validated);
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(156, 545);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(40, 16);
            this.label17.TabIndex = 394;
            this.label17.Text = "Ngày :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label52
            // 
            this.label52.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.Location = new System.Drawing.Point(297, 545);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(144, 16);
            this.label52.TabIndex = 397;
            this.label52.Text = "Giờ về đến khoa cấp cứu :";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngayve
            // 
            this.ngayve.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayve.Enabled = false;
            this.ngayve.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayve.Location = new System.Drawing.Point(513, 543);
            this.ngayve.Mask = "##/##/####";
            this.ngayve.Name = "ngayve";
            this.ngayve.Size = new System.Drawing.Size(64, 21);
            this.ngayve.TabIndex = 39;
            this.ngayve.Text = "  /  /    ";
            this.ngayve.Validated += new System.EventHandler(this.ngayve_Validated);
            // 
            // giove
            // 
            this.giove.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giove.Enabled = false;
            this.giove.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giove.Location = new System.Drawing.Point(441, 543);
            this.giove.Mask = "##:##";
            this.giove.Name = "giove";
            this.giove.Size = new System.Drawing.Size(34, 21);
            this.giove.TabIndex = 38;
            this.giove.Text = "  :  ";
            this.giove.Validated += new System.EventHandler(this.giove_Validated);
            // 
            // label53
            // 
            this.label53.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.Location = new System.Drawing.Point(473, 545);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(40, 16);
            this.label53.TabIndex = 398;
            this.label53.Text = "Ngày :";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label54
            // 
            this.label54.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.Location = new System.Drawing.Point(8, 569);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(112, 16);
            this.label54.TabIndex = 401;
            this.label54.Text = "Ghi chú :";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkThangmay
            // 
            this.chkThangmay.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkThangmay.Enabled = false;
            this.chkThangmay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkThangmay.Location = new System.Drawing.Point(120, 569);
            this.chkThangmay.Name = "chkThangmay";
            this.chkThangmay.Size = new System.Drawing.Size(104, 16);
            this.chkThangmay.TabIndex = 40;
            this.chkThangmay.Text = "Chờ thang máy";
            this.chkThangmay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkThangmay.CheckedChanged += new System.EventHandler(this.chkThangmay_CheckedChanged);
            this.chkThangmay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // thangmay
            // 
            this.thangmay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thangmay.Enabled = false;
            this.thangmay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thangmay.Location = new System.Drawing.Point(227, 566);
            this.thangmay.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.thangmay.Name = "thangmay";
            this.thangmay.Size = new System.Drawing.Size(40, 21);
            this.thangmay.TabIndex = 41;
            this.thangmay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label55
            // 
            this.label55.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.Location = new System.Drawing.Point(270, 569);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(56, 16);
            this.label55.TabIndex = 404;
            this.label55.Text = "phút";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label56
            // 
            this.label56.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label56.Location = new System.Drawing.Point(490, 569);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(56, 16);
            this.label56.TabIndex = 407;
            this.label56.Text = "phút";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // phongmo
            // 
            this.phongmo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phongmo.Enabled = false;
            this.phongmo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phongmo.Location = new System.Drawing.Point(442, 566);
            this.phongmo.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.phongmo.Name = "phongmo";
            this.phongmo.Size = new System.Drawing.Size(40, 21);
            this.phongmo.TabIndex = 43;
            this.phongmo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // chkPhongmo
            // 
            this.chkPhongmo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkPhongmo.Enabled = false;
            this.chkPhongmo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPhongmo.Location = new System.Drawing.Point(336, 569);
            this.chkPhongmo.Name = "chkPhongmo";
            this.chkPhongmo.Size = new System.Drawing.Size(104, 16);
            this.chkPhongmo.TabIndex = 42;
            this.chkPhongmo.Text = "Chờ phòng mổ";
            this.chkPhongmo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkPhongmo.CheckedChanged += new System.EventHandler(this.chkPhongmo_CheckedChanged);
            this.chkPhongmo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label57
            // 
            this.label57.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label57.Location = new System.Drawing.Point(714, 569);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(56, 16);
            this.label57.TabIndex = 410;
            this.label57.Text = "phút";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nhanbenh
            // 
            this.nhanbenh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhanbenh.Enabled = false;
            this.nhanbenh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhanbenh.Location = new System.Drawing.Point(666, 566);
            this.nhanbenh.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nhanbenh.Name = "nhanbenh";
            this.nhanbenh.Size = new System.Drawing.Size(40, 21);
            this.nhanbenh.TabIndex = 45;
            this.nhanbenh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // chkNhanbenh
            // 
            this.chkNhanbenh.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNhanbenh.Enabled = false;
            this.chkNhanbenh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNhanbenh.Location = new System.Drawing.Point(560, 569);
            this.chkNhanbenh.Name = "chkNhanbenh";
            this.chkNhanbenh.Size = new System.Drawing.Size(104, 16);
            this.chkNhanbenh.TabIndex = 44;
            this.chkNhanbenh.Text = "Chờ nhận bệnh";
            this.chkNhanbenh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNhanbenh.CheckedChanged += new System.EventHandler(this.chkNhanbenh_CheckedChanged);
            this.chkNhanbenh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(128, 96);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 96);
            this.panel1.TabIndex = 53;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(120, 434);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(768, 48);
            this.panel2.TabIndex = 412;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(408, 96);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 95);
            this.panel3.TabIndex = 413;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(656, 96);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1, 95);
            this.panel4.TabIndex = 414;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Location = new System.Drawing.Point(408, 435);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1, 46);
            this.panel5.TabIndex = 415;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Location = new System.Drawing.Point(656, 435);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1, 46);
            this.panel6.TabIndex = 416;
            // 
            // frmVanchuyen
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(892, 637);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label57);
            this.Controls.Add(this.nhanbenh);
            this.Controls.Add(this.chkNhanbenh);
            this.Controls.Add(this.label56);
            this.Controls.Add(this.phongmo);
            this.Controls.Add(this.chkPhongmo);
            this.Controls.Add(this.label55);
            this.Controls.Add(this.thangmay);
            this.Controls.Add(this.chkThangmay);
            this.Controls.Add(this.label54);
            this.Controls.Add(this.ngayve);
            this.Controls.Add(this.giove);
            this.Controls.Add(this.label53);
            this.Controls.Add(this.label52);
            this.Controls.Add(this.ngayluc);
            this.Controls.Add(this.gioluc);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.tendd_kd);
            this.Controls.Add(this.dd_kd);
            this.Controls.Add(this.tendd_vc);
            this.Controls.Add(this.dd_vc);
            this.Controls.Add(this.tendd_cc);
            this.Controls.Add(this.dd_cc);
            this.Controls.Add(this.tenbs_kd);
            this.Controls.Add(this.bs_kd);
            this.Controls.Add(this.label51);
            this.Controls.Add(this.label50);
            this.Controls.Add(this.label49);
            this.Controls.Add(this.tg_kd);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.m_kd);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.t_kd);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.ha_kd);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.nt_kd);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.tg_vc);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.m_vc);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.t_vc);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.ha_vc);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.nt_vc);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.tg_cc);
            this.Controls.Add(this.khoaden);
            this.Controls.Add(this.giovk);
            this.Controls.Add(this.ngayrk);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.giork);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.ngayvk);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.m_cc);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.t_cc);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.ha_cc);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.nt_cc);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.cmbNgay);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tenbs_vc);
            this.Controls.Add(this.bs_vc);
            this.Controls.Add(this.tenbs_cc);
            this.Controls.Add(this.bs_cc);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.gio);
            this.Controls.Add(this.khac);
            this.Controls.Add(this.listNv);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.lgio);
            this.Controls.Add(this.label90);
            this.Controls.Add(this.ngayvv);
            this.Controls.Add(this.sovaovien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chandoan);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.giuong);
            this.Controls.Add(this.phong);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVanchuyen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu vận chuyển bệnh nhân";
            this.Load += new System.EventHandler(this.frmVanchuyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thangmay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phongmo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhanbenh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmVanchuyen_Load(object sender, System.EventArgs e)
		{
			user=m.user;xxx=user+m.mmyy(ngayvv.Text);
			dtnv=m.get_data("select ma,hoten,nhom from "+user+".dmbs where nhom<>"+LibMedi.AccessData.nghiviec+" order by hoten").Tables[0];
			listNv.DisplayMember="MA";
			listNv.ValueMember="HOTEN";
			listNv.DataSource=dtnv;
			cmbNgay.DisplayMember="NGAY";
			cmbNgay.ValueMember="ID";
			sql="select a.id,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.khoaden,";
			sql+="to_char(a.ngayvv,'dd/mm/yyyy hh24:mi') as ngayvv,to_char(a.ngayrk,'dd/mm/yyyy hh24:mi') as ngayrk,";
			sql+="to_char(a.ngayvk,'dd/mm/yyyy hh24:mi') as ngayvk,";
			sql+="a.m_cc,a.ha_cc,a.nt_cc,a.t_cc,a.tg_cc,";
			sql+="a.m_vc,a.ha_vc,a.nt_vc,a.t_vc,a.tg_vc,";
			sql+="a.m_kd,a.ha_kd,a.nt_kd,a.t_kd,a.tg_kd,";
			sql+="a.bs_cc,a.dd_cc,a.bs_vc,a.dd_vc,a.bs_kd,a.dd_kd,";
			sql+="a.khac,to_char(a.luc,'dd/mm/yyyy hh24:mi') as luc,to_char(a.vedenkhoa,'dd/mm/yyyy hh24:mi') as vedenkhoa,";
			sql+="a.thangmay,a.phongmo,a.nhanbenh ";
			sql+=" from "+xxx+".ba_vanchuyen a,"+xxx+".ba_thuchien b where a.idthuchien=b.id and b.id="+l_idthuchien+" order by a.ngay";
			ds=m.get_data(sql);				

			cmbNgay.DataSource=ds.Tables[0];
			load_head();
			AddGridTableStyle();
			this.disabledBackBrush = new SolidBrush(Color.Black);
			this.disabledTextBrush = new SolidBrush(Color.Red);

			this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
			this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
			this.alertTextBrush = new SolidBrush(Color.White);
			
			this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
			this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0,255, 255));
			dataGrid1.ReadOnly=true;
		}

		private void load_head()
		{			
			l_id=(cmbNgay.SelectedIndex!=-1)?decimal.Parse(cmbNgay.SelectedValue.ToString()):0;
			DataRow r=m.getrowbyid(ds.Tables[0],"id="+l_id);
			if (r!=null)
			{
				khoaden.Text=r["khoaden"].ToString();
				ngay.Text=r["ngay"].ToString().Substring(0,10);
				gio.Text=r["ngay"].ToString().Substring(11);
				
				ngayrk.Text=r["ngayrk"].ToString().Substring(0,10);
				giork.Text=r["ngayrk"].ToString().Substring(11);

				ngayvk.Text=r["ngayvk"].ToString().Substring(0,10);
				giovk.Text=r["ngayvk"].ToString().Substring(11);

				m_cc.Text=(r["m_cc"].ToString()!="0")?r["m_cc"].ToString():"";
				t_cc.Text=(r["t_cc"].ToString()!="0")?r["t_cc"].ToString():"";
				ha_cc.Text=r["ha_cc"].ToString();
				nt_cc.Text=(r["nt_cc"].ToString()!="0")?r["nt_cc"].ToString():"";
				tg_cc.SelectedIndex=int.Parse(r["tg_cc"].ToString());

				m_vc.Text=(r["m_vc"].ToString()!="0")?r["m_vc"].ToString():"";
				t_vc.Text=(r["t_vc"].ToString()!="0")?r["t_vc"].ToString():"";
				ha_vc.Text=r["ha_vc"].ToString();
				nt_vc.Text=(r["nt_vc"].ToString()!="0")?r["nt_vc"].ToString():"";
				tg_vc.SelectedIndex=int.Parse(r["tg_vc"].ToString());

				m_kd.Text=(r["m_kd"].ToString()!="0")?r["m_kd"].ToString():"";
				t_kd.Text=(r["t_kd"].ToString()!="0")?r["t_kd"].ToString():"";
				ha_kd.Text=r["ha_kd"].ToString();
				nt_kd.Text=(r["nt_kd"].ToString()!="0")?r["nt_kd"].ToString():"";
				tg_kd.SelectedIndex=int.Parse(r["tg_kd"].ToString());

				bs_cc.Text=r["bs_cc"].ToString();
				get_ten(bs_cc,tenbs_cc);			
				bs_vc.Text=r["bs_vc"].ToString();
				get_ten(bs_vc,tenbs_vc);
				bs_kd.Text=r["bs_kd"].ToString();
				get_ten(bs_kd,tenbs_kd);

				dd_cc.Text=r["dd_cc"].ToString();
				get_ten(dd_cc,tendd_cc);			
				dd_vc.Text=r["dd_vc"].ToString();
				get_ten(dd_vc,tendd_vc);
				dd_kd.Text=r["dd_kd"].ToString();
				get_ten(dd_kd,tendd_kd);

				khac.Text=r["khac"].ToString();

				ngayluc.Text=r["luc"].ToString().Substring(0,10);
				gioluc.Text=r["luc"].ToString().Substring(11);

				ngayve.Text=r["vedenkhoa"].ToString().Substring(0,10);
				giove.Text=r["vedenkhoa"].ToString().Substring(11);

				chkThangmay.Checked=r["thangmay"].ToString()!="0";
				thangmay.Value=decimal.Parse(r["thangmay"].ToString());
				chkPhongmo.Checked=r["phongmo"].ToString()!="0";
				phongmo.Value=decimal.Parse(r["phongmo"].ToString());
				chkNhanbenh.Checked=r["nhanbenh"].ToString()!="0";
				nhanbenh.Value=decimal.Parse(r["nhanbenh"].ToString());
				thangmay.Enabled=chkThangmay.Checked;
				phongmo.Enabled=chkPhongmo.Checked;
				nhanbenh.Enabled=chkNhanbenh.Checked;

			}
			load_grid(0);
		}
		private void sophieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ngay_Validated(object sender, System.EventArgs e)
		{
			ngay.Text=ngay.Text.Trim();
			if (ngay.Text.Length==6) ngay.Text=ngay.Text+DateTime.Now.Year.ToString();
			if (!m.bNgay(ngay.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
				ngay.Focus();
				return;
			}
		}

		private void gio_Validated(object sender, System.EventArgs e)
		{
			string sgio=(gio.Text.Trim()=="")?"00:00":gio.Text.Trim();
			gio.Text=sgio.Substring(0,2).PadLeft(2,'0')+":"+sgio.Substring(3).Trim().PadRight(2,'0');
			if (!m.bGio(gio.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"));
				gio.Focus();
				return;
			}
		}

		private void tenbs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listNv.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listNv.Visible) listNv.Focus();
				else SendKeys.Send("{Tab}");
			}	
		}

		private void Filt_dmbs(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listNv.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="hoten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void load_grid(int loai)
		{
            if (loai == -1) sql = "select stt,id as ma,ten,0 as cc,0 as vc,0 as kd from " + user + ".ba_dmvanchuyen order by stt";
			else
			{
				sql="select b.stt,b.id as ma,b.ten,nvl(a.cc,0) as cc,nvl(a.vc,0) as vc,nvl(a.kd,0) as kd from "+xxx+".ba_vanchuyenct a,"+user+".ba_dmvanchuyen b";
				sql+=" where a.stt=b.id and a.id="+l_id+" order by b.stt";
			}								
			dsct=m.get_data(sql);				
			dsct.Tables[0].Columns.Add("cc1",typeof(bool));
			dsct.Tables[0].Columns.Add("vc1",typeof(bool));
			dsct.Tables[0].Columns.Add("kd1",typeof(bool));
			dataGrid1.DataSource=dsct.Tables[0];
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember]; 
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			foreach (DataRow r in dsct.Tables[0].Rows)
			{
				r["cc1"]=(r["cc"].ToString()=="1")?true:false;
				r["vc1"]=(r["vc"].ToString()=="1")?true:false;
				r["kd1"]=(r["kd"].ToString()=="1")?true:false;
			}
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dsct.Tables[0].TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.FromArgb(0,255,255);
			ts.SelectionForeColor = Color.PaleGreen;
			ts.RowHeaderWidth=5;

			FormattableTextBoxColumn TextCol1 = new FormattableTextBoxColumn();
			TextCol1.MappingName = "stt";
			TextCol1.HeaderText = "TT";
			TextCol1.Width = 0;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "ten";
			TextCol1.HeaderText = "Nội dung";
			TextCol1.Width =120;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			FormattableBooleanColumn discontinuedCol = new FormattableBooleanColumn();
			discontinuedCol.MappingName = "cc1";
			discontinuedCol.HeaderText = "Có/Không";
			discontinuedCol.Width = 275;
			discontinuedCol.AllowNull = false;

			discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
			ts.GridColumnStyles.Add(discontinuedCol);
			dataGrid1.TableStyles.Add(ts);

			discontinuedCol = new FormattableBooleanColumn();
			discontinuedCol.MappingName = "vc1";
			discontinuedCol.HeaderText = "Có/Không";
			discontinuedCol.Width = 250;
			discontinuedCol.AllowNull = false;

			discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
			ts.GridColumnStyles.Add(discontinuedCol);
			dataGrid1.TableStyles.Add(ts);

			discontinuedCol = new FormattableBooleanColumn();
			discontinuedCol.MappingName = "kd1";
			discontinuedCol.HeaderText = "Có/Không";
			discontinuedCol.Width = 215;
			discontinuedCol.AllowNull = false;

			discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
			ts.GridColumnStyles.Add(discontinuedCol);
			dataGrid1.TableStyles.Add(ts);

		}
	
		private void SetCellFormat(object sender, DataGridFormatCellEventArgs e)
		{
			try
			{
				bool discontinued = (bool) ((e.Column != 0) ? this.dataGrid1[e.Row, 0] : e.CurrentCellValue);
				if(e.Column > 0 && (bool)(this.dataGrid1[e.Row, 0])) e.ForeBrush = new SolidBrush(Color.Blue);
				else if(e.Column > 0 && e.Row == this.dataGrid1.CurrentRowIndex)
				{
					e.BackBrush = this.currentRowBackBrush;
					e.TextFont = this.currentRowFont;
				}				
			}
			catch{}
		}

		private void BoolValueChanged(object sender, BoolValueChangedEventArgs e)
		{
			this.dataGrid1.EndEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"],e.Row, false);
			RefreshRow(e.Row);
			this.dataGrid1.BeginEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"],e.Row);
		}
		private void RefreshRow(int row)
		{
			Rectangle rect = this.dataGrid1.GetCellBounds(row, 0);
			rect = new Rectangle(rect.Right, rect.Top, this.dataGrid1.Width, rect.Height);
			this.dataGrid1.Invalidate(rect);
		}

		private void dataGrid1_Click(object sender, System.EventArgs e)
		{
			Point pt = this.dataGrid1.PointToClient(Control.MousePosition);
			DataGrid.HitTestInfo hti = this.dataGrid1.HitTest(pt);
			BindingManagerBase bmb = this.BindingContext[this.dataGrid1.DataSource, this.dataGrid1.DataMember];
			if(afterCurrentCellChanged && hti.Row < bmb.Count && hti.Type == DataGrid.HitTestType.Cell &&  hti.Column == checkCol )
			{	
				this.dataGrid1[hti.Row, checkCol] = !(bool)this.dataGrid1[hti.Row, checkCol];
				RefreshRow(hti.Row);
			}
		}

		private void emp_text()
		{
			l_id=0;dsct.Clear();load_grid(-1);
			string _ngay=m.ngayhienhanh_server;
			ngay.Text=_ngay.Substring(0,10);
			gio.Text=_ngay.Substring(11);
			ngayvk.Text=ngay.Text;giovk.Text=gio.Text;
			ngayrk.Text=ngay.Text;giork.Text=gio.Text;
			ngayluc.Text=ngay.Text;gioluc.Text=gio.Text;
			ngayve.Text=ngay.Text;giove.Text=gio.Text;khoaden.Text="";
			m_cc.Text="";ha_cc.Text="";nt_cc.Text="";t_cc.Text="";tg_cc.SelectedIndex=0;
			m_vc.Text="";ha_vc.Text="";nt_vc.Text="";t_vc.Text="";tg_vc.SelectedIndex=0;
			m_kd.Text="";ha_kd.Text="";nt_kd.Text="";t_kd.Text="";tg_kd.SelectedIndex=0;
			bs_cc.Text="";bs_vc.Text="";bs_kd.Text="";dd_cc.Text="";dd_vc.Text="";dd_kd.Text="";
			khac.Text="";chkThangmay.Checked=false;thangmay.Value=0;
			chkPhongmo.Checked=false;phongmo.Value=0;
			chkNhanbenh.Checked=false;nhanbenh.Value=0;
			decimal _id=m.get_idchung(ngayvv.Text,l_idthuchien);
		}

		private void ena_object(bool ena)
		{
			ngay.Enabled=ena;
			gio.Enabled=ena;
			ngay.Visible=ena;
			gio.Visible=ena;
			lgio.Visible=ena;
			cmbNgay.Visible=!ena;
			cmbNgay.Enabled=!ena;
			khoaden.Enabled=ena;
			ngayvk.Enabled=ena;
			giovk.Enabled=ena;
			ngayrk.Enabled=ena;
			giork.Enabled=ena;
			m_cc.Enabled=ena;
			ha_cc.Enabled=ena;
			nt_cc.Enabled=ena;
			t_cc.Enabled=ena;
			tg_cc.Enabled=ena;
			m_vc.Enabled=ena;
			ha_vc.Enabled=ena;
			nt_vc.Enabled=ena;
			t_vc.Enabled=ena;
			tg_vc.Enabled=ena;
			m_kd.Enabled=ena;
			ha_kd.Enabled=ena;
			nt_kd.Enabled=ena;
			t_kd.Enabled=ena;
			tg_kd.Enabled=ena;
			bs_cc.Enabled=ena;
			tenbs_cc.Enabled=ena;
			bs_vc.Enabled=ena;
			tenbs_vc.Enabled=ena;
			bs_kd.Enabled=ena;
			tenbs_kd.Enabled=ena;
			dd_cc.Enabled=ena;
			tendd_cc.Enabled=ena;
			dd_vc.Enabled=ena;
			tendd_vc.Enabled=ena;
			dd_kd.Enabled=ena;
			tendd_kd.Enabled=ena;
			khac.Enabled=ena;
			ngayluc.Enabled=ena;
			gioluc.Enabled=ena;
			ngayve.Enabled=ena;
			giove.Enabled=ena;
			chkThangmay.Enabled=ena;
			chkPhongmo.Enabled=ena;
			chkNhanbenh.Enabled=ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butIn.Enabled=!ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			dataGrid1.ReadOnly=!ena;
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
			emp_text();
			ngay.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (cmbNgay.SelectedIndex==-1) return;
			ena_object(true);
			dataGrid1.Focus();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();
			System.GC.Collect();
			this.Close();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (cmbNgay.SelectedIndex==-1) return;
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
				m.execute_data("delete from "+xxx+".ba_vanchuyenct where id="+l_id);
				m.execute_data("delete from "+xxx+".ba_vanchuyen where id="+l_id);
				m.delrec(ds.Tables[0],"id="+l_id);
				cmbNgay.Update();
				load_head();
			}
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
			load_head();
			thangmay.Enabled=false;
			phongmo.Enabled=false;
			nhanbenh.Enabled=false;
			butMoi.Focus();
		}

		private bool kiemtra()
		{
			if (ngay.Text.Trim().Length!=10)
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"),LibMedi.AccessData.Msg);
				ngay.Focus();
				return false;
			}
			if (gio.Text.Trim().Length!=5)
			{
				MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"),LibMedi.AccessData.Msg);
				gio.Focus();
				return false;
			}
			if (khoaden.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Khoa đến !"),LibMedi.AccessData.Msg);
				khoaden.Focus();
				return false;
			}
			if (ngayvk.Text.Trim().Length!=10)
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"),LibMedi.AccessData.Msg);
				ngayvk.Focus();
				return false;
			}
			if (giovk.Text.Trim().Length!=5)
			{
				MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"),LibMedi.AccessData.Msg);
				giovk.Focus();
				return false;
			}
			if (ngayrk.Text.Trim().Length!=10)
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"),LibMedi.AccessData.Msg);
				ngayrk.Focus();
				return false;
			}
			if (giork.Text.Trim().Length!=5)
			{
				MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"),LibMedi.AccessData.Msg);
				giork.Focus();
				return false;
			}
			if (bs_cc.Text=="" || tenbs_cc.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Bác sĩ không hợp lệ !"),LibMedi.AccessData.Msg);
				bs_cc.Focus();
				return false;
			}
			if (dd_cc.Text=="" || tendd_cc.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Điều dưỡng không hợp lệ !"),LibMedi.AccessData.Msg);
				dd_cc.Focus();
				return false;
			}
			if (bs_vc.Text=="" || tenbs_vc.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Bác sĩ không hợp lệ !"),LibMedi.AccessData.Msg);
				bs_vc.Focus();
				return false;
			}
			if (dd_vc.Text=="" || tendd_vc.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Điều dưỡng không hợp lệ !"),LibMedi.AccessData.Msg);
				dd_vc.Focus();
				return false;
			}
			if (bs_kd.Text=="" || tenbs_kd.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Bác sĩ không hợp lệ !"),LibMedi.AccessData.Msg);
				bs_kd.Focus();
				return false;
			}
			if (dd_kd.Text=="" || tendd_kd.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Điều dưỡng không hợp lệ !"),LibMedi.AccessData.Msg);
				dd_kd.Focus();
				return false;
			}
			if (!m.bNgaygio(ngayrk.Text+" "+giork.Text,ngayvv.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày ra khoa cấp cứu không được nhỏ hơn ngày giờ vào viện !"),LibMedi.AccessData.Msg);
				ngayrk.Focus();
				return false;
			}
			if (!m.bNgaygio(ngayvk.Text+" "+giovk.Text,ngayrk.Text+" "+giork.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày giờ đến khoa không được nhỏ hơn ngày giờ ra khoa cấp cứu !"),LibMedi.AccessData.Msg);
				ngayvk.Focus();
				return false;
			}
			if (!m.bNgaygio(ngayluc.Text+" "+gioluc.Text,ngayvk.Text+" "+giovk.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày giờ bàn giao xong không được nhỏ hơn ngày giờ đến khoa !"),LibMedi.AccessData.Msg);
				ngayluc.Focus();
				return false;
			}
			if (!m.bNgaygio(ngayve.Text+" "+giove.Text,ngayluc.Text+" "+gioluc.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày giờ về đến khoa không được nhỏ hơn ngày giờ bàn giao !"),LibMedi.AccessData.Msg);
				ngayve.Focus();
				return false;
			}
			if (ngayluc.Text+" "+gioluc.Text==ngayve.Text+" "+giove.Text)
			{
				if (thangmay.Value!=0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Chờ thang máy không hợp lệ !"),LibMedi.AccessData.Msg);
					thangmay.Focus();
					return false;
				}
				if (phongmo.Value!=0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Chờ phòng mổ không hợp lệ !"),LibMedi.AccessData.Msg);
					phongmo.Focus();
					return false;
				}
				if (nhanbenh.Value!=0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Chờ nhận bệnh không hợp lệ !"),LibMedi.AccessData.Msg);
					nhanbenh.Focus();
					return false;
				}
			}
			else
			{
				DateTime dt1=m.StringToDateTime(ngayluc.Text+" "+gioluc.Text);
				DateTime dt2=m.StringToDateTime(ngayve.Text+" "+giove.Text);
				double ztime=double.Parse(thangmay.Value.ToString())+double.Parse(phongmo.Value.ToString())+double.Parse(nhanbenh.Value.ToString());
				if (dt1.AddMinutes(ztime)!=dt2)
				{
					MessageBox.Show(lan.Change_language_MessageText("Tổng thời gian")+" "+ztime.ToString()+" "+lan.Change_language_MessageText("phút di chuyển không hợp lệ")+"\n"+lan.Change_language_MessageText("So với lúc bàn giao")+" "+ngayluc.Text+" "+gioluc.Text+" "+lan.Change_language_MessageText("về đến khoa")+" "+ngayve.Text+" "+giove.Text+" !",LibMedi.AccessData.Msg);
					thangmay.Focus();
					return false;
				}
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			l_idthuchien=m.get_idthuchien(ngayvv.Text,l_idkhoa);
			if (l_idthuchien==0) 
			{
				l_idthuchien=m.getidyymmddhhmiss_stt_computer;//get_capid(-300);
				m.upd_ba_thuchien(ngayvv.Text,l_idthuchien,mabn.Text,l_maql,l_idkhoa,s_makp,phong.Text,giuong.Text,chandoan.Text);
			}
			if (l_id==0) l_id=m.getidyymmddhhmiss_stt_computer;//get_capid(-409);
			else m.execute_data("delete from "+xxx+".ba_vanchuyenct where id="+l_id);
			m.upd_ba_vanchuyen(mabn.Text,l_id,l_idthuchien,ngay.Text+" "+gio.Text,khoaden.Text,ngayvv.Text,ngayrk.Text+" "+giork.Text,ngayvk.Text+" "+giovk.Text,
				(m_cc.Text!="")?decimal.Parse(m_cc.Text):0,ha_cc.Text,(nt_cc.Text!="")?decimal.Parse(nt_cc.Text):0,(t_cc.Text!="")?decimal.Parse(t_cc.Text):0,tg_cc.SelectedIndex,
				(m_vc.Text!="")?decimal.Parse(m_vc.Text):0,ha_vc.Text,(nt_vc.Text!="")?decimal.Parse(nt_vc.Text):0,(t_vc.Text!="")?decimal.Parse(t_vc.Text):0,tg_vc.SelectedIndex,
				(m_kd.Text!="")?decimal.Parse(m_kd.Text):0,ha_kd.Text,(nt_kd.Text!="")?decimal.Parse(nt_kd.Text):0,(t_cc.Text!="")?decimal.Parse(t_cc.Text):0,tg_kd.SelectedIndex,
				bs_cc.Text,dd_cc.Text,bs_vc.Text,dd_vc.Text,bs_kd.Text,dd_kd.Text,khac.Text,ngayluc.Text+" "+gioluc.Text,ngayve.Text+" "+giove.Text,thangmay.Value,phongmo.Value,nhanbenh.Value,i_userid);
			foreach(DataRow r in dsct.Tables[0].Select("true","stt")) 
				m.upd_ba_vanchuyenct(ngayvv.Text,l_id,int.Parse(r["ma"].ToString()),(r["cc1"].ToString().ToLower()=="true")?1:0,(r["vc1"].ToString().ToLower()=="true")?1:0,(r["kd1"].ToString().ToLower()=="true")?1:0);
			upd_items();
			ena_object(false);
			thangmay.Enabled=false;
			phongmo.Enabled=false;
			nhanbenh.Enabled=false;
			butMoi.Focus();
		}

		private void upd_items()
		{
			DataRow r1,r2;
			r1=m.getrowbyid(ds.Tables[0],"id="+l_id);
			if (r1==null)
			{
				r2=ds.Tables[0].NewRow();
				r2["id"]=l_id;
				r2["ngay"]=ngay.Text+" "+gio.Text;
				r2["ngayvk"]=ngayvk.Text+" "+giovk.Text;
				r2["ngayrk"]=ngayrk.Text+" "+giork.Text;

				r2["m_cc"]=(m_cc.Text!="")?decimal.Parse(m_cc.Text):0;
				r2["t_cc"]=(t_cc.Text!="")?decimal.Parse(t_cc.Text):0;
				r2["ha_cc"]=ha_cc.Text;
				r2["nt_cc"]=(nt_cc.Text!="")?decimal.Parse(nt_cc.Text):0;
				r2["tg_cc"]=tg_cc.SelectedIndex;

				r2["m_vc"]=(m_vc.Text!="")?decimal.Parse(m_vc.Text):0;
				r2["t_vc"]=(t_vc.Text!="")?decimal.Parse(t_vc.Text):0;
				r2["ha_vc"]=ha_vc.Text;
				r2["nt_vc"]=(nt_vc.Text!="")?decimal.Parse(nt_vc.Text):0;
				r2["tg_vc"]=tg_vc.SelectedIndex;

				r2["m_kd"]=(m_kd.Text!="")?decimal.Parse(m_kd.Text):0;
				r2["t_kd"]=(t_kd.Text!="")?decimal.Parse(t_kd.Text):0;
				r2["ha_kd"]=ha_kd.Text;
				r2["nt_kd"]=(nt_kd.Text!="")?decimal.Parse(nt_kd.Text):0;
				r2["tg_kd"]=tg_kd.SelectedIndex;

				r2["bs_cc"]=bs_cc.Text;
				r2["dd_cc"]=dd_cc.Text;
				r2["bs_vc"]=bs_vc.Text;
				r2["dd_vc"]=dd_vc.Text;
				r2["bs_kd"]=bs_kd.Text;
				r2["dd_kd"]=dd_kd.Text;

				r2["khac"]=khac.Text;
				r2["luc"]=ngayluc.Text+" "+gioluc.Text;
				r2["vedenkhoa"]=ngayve.Text+" "+giove.Text;
				r2["thangmay"]=thangmay.Value;
				r2["phongmo"]=phongmo.Value;
				r2["nhanbenh"]=nhanbenh.Value;
				ds.Tables[0].Rows.Add(r2);
			}
			else
			{
				DataRow [] dr=ds.Tables[0].Select("id="+l_id);
				dr[0]["ngay"]=ngay.Text+" "+gio.Text;
				dr[0]["ngayvk"]=ngayvk.Text+" "+giovk.Text;
				dr[0]["ngayrk"]=ngayrk.Text+" "+giork.Text;

				dr[0]["m_cc"]=(m_cc.Text!="")?decimal.Parse(m_cc.Text):0;
				dr[0]["t_cc"]=(t_cc.Text!="")?decimal.Parse(t_cc.Text):0;
				dr[0]["ha_cc"]=ha_cc.Text;
				dr[0]["nt_cc"]=(nt_cc.Text!="")?decimal.Parse(nt_cc.Text):0;
				dr[0]["tg_cc"]=tg_cc.SelectedIndex;

				dr[0]["m_vc"]=(m_vc.Text!="")?decimal.Parse(m_vc.Text):0;
				dr[0]["t_vc"]=(t_vc.Text!="")?decimal.Parse(t_vc.Text):0;
				dr[0]["ha_vc"]=ha_vc.Text;
				dr[0]["nt_vc"]=(nt_vc.Text!="")?decimal.Parse(nt_vc.Text):0;
				dr[0]["tg_vc"]=tg_vc.SelectedIndex;

				dr[0]["m_kd"]=(m_kd.Text!="")?decimal.Parse(m_kd.Text):0;
				dr[0]["t_kd"]=(t_kd.Text!="")?decimal.Parse(t_kd.Text):0;
				dr[0]["ha_kd"]=ha_kd.Text;
				dr[0]["nt_kd"]=(nt_kd.Text!="")?decimal.Parse(nt_kd.Text):0;
				dr[0]["tg_kd"]=tg_kd.SelectedIndex;

				dr[0]["bs_cc"]=bs_cc.Text;
				dr[0]["dd_cc"]=dd_cc.Text;
				dr[0]["bs_vc"]=bs_vc.Text;
				dr[0]["dd_vc"]=dd_vc.Text;
				dr[0]["bs_kd"]=bs_kd.Text;
				dr[0]["dd_kd"]=dd_kd.Text;

				dr[0]["khac"]=khac.Text;
				dr[0]["luc"]=ngayluc.Text+" "+gioluc.Text;
				dr[0]["vedenkhoa"]=ngayve.Text+" "+giove.Text;
				dr[0]["thangmay"]=thangmay.Value;
				dr[0]["phongmo"]=phongmo.Value;
				dr[0]["nhanbenh"]=nhanbenh.Value;

			}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			string stuoi=m.get_tuoivao(l_maql).Trim();
			sql="select '' as sovaovien,'' as mabn,'' as hoten,'' as tuoi,'' as phai,'' as tenkp,";
			sql+="'' as phong,'' as giuong,'' as chandoan,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,";
			sql+="a.khoaden,";
			sql+="to_char(a.ngayvv,'dd/mm/yyyy hh24:mi') as ngayvv,to_char(a.ngayrk,'dd/mm/yyyy hh24:mi') as ngayrk,";
			sql+="to_char(a.ngayvk,'dd/mm/yyyy hh24:mi') as ngayvk,";
			sql+="a.m_cc,a.ha_cc,a.nt_cc,a.t_cc,a.tg_cc,";
			sql+="a.m_vc,a.ha_vc,a.nt_vc,a.t_vc,a.tg_vc,";
			sql+="a.m_kd,a.ha_kd,a.nt_kd,a.t_kd,a.tg_kd,";
			sql+="d.hoten bs_cc,e.hoten dd_cc,f.hoten bs_vc,g.hoten dd_vc,h.hoten bs_kd,i.hoten dd_kd,";
			sql+="a.khac,to_char(a.luc,'dd/mm/yyyy hh24:mi') as luc,to_char(a.vedenkhoa,'dd/mm/yyyy hh24:mi') as vedenkhoa,";
			sql+="a.thangmay,a.phongmo,a.nhanbenh,";
            sql += "'' as i_bs_cc,'' as i_dd_cc,'' as i_bs_vc,'' as i_dd_vc,'' as i_bs_kd,'' as i_dd_kd,";//d.image,e.image,f.image,g.image,h.image,i.image
            sql += "c.ten,b.cc,b.vc,b.kd";
			sql+=" from "+xxx+".ba_vanchuyen a,"+user+".ba_dmvanchuyen c,"+xxx+".ba_vanchuyenct b,";
			sql+=user+".dmbs d,"+user+".dmbs e,"+user+".dmbs f,"+user+".dmbs g,"+user+".dmbs h,"+user+".dmbs i ";
			sql+=" where a.id=b.id and b.stt=c.id and a.bs_cc=d.ma(+) and a.dd_cc=e.ma(+) and a.bs_vc=f.ma(+) ";
			sql+=" and a.dd_vc=g.ma(+) and a.bs_kd=h.ma(+) and a.dd_kd=i.ma(+)";
			sql+=" and a.id="+l_id;
			DataSet dsxml=m.get_data(sql);				
			if (chkXML.Checked)
			{
				if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
				dsxml.WriteXml("..\\xml\\vanchuyen.xml",XmlWriteMode.WriteSchema);
			}
			foreach(DataRow r in dsxml.Tables[0].Rows)
			{
				r["sovaovien"]=sovaovien.Text;
				r["mabn"]=mabn.Text;
				r["hoten"]=hoten.Text;
				r["tuoi"]=stuoi;
				r["phai"]=phai.Text;
				r["tenkp"]=s_tenkp;
				r["phong"]=phong.Text;
				r["giuong"]=giuong.Text;
				r["chandoan"]=chandoan.Text;
			}
			if (dsxml.Tables[0].Rows.Count>0)
			{
                dllReportM.frmReport f = new dllReportM.frmReport(m, dsxml, "", "rVanchuyen.rpt");
				f.ShowDialog();
			}
			else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
		}

		private void bs_cc_Validated(object sender, System.EventArgs e)
		{
			get_ten(bs_cc,tenbs_cc);
		}

		private void get_ten(MaskedTextBox.MaskedTextBox ma,TextBox ten)
		{
			if (ma.Text=="") return;
			DataRow r=m.getrowbyid(dtnv,"ma='"+ma.Text+"'");
			if (r!=null) ten.Text=r["hoten"].ToString();
			else ten.Text="";	
		}

		private void tenbs_cc_TextChanged(object sender, System.EventArgs e)
		{
			focus_ten(tenbs_cc,bs_cc,bs_vc);
		}

		private void focus_ten(TextBox t1,MaskedTextBox.MaskedTextBox t2,MaskedTextBox.MaskedTextBox t3)
		{
			if (this.ActiveControl==t1)
			{
				Filt_dmbs(t1.Text);
				listNv.BrowseToDanhmuc(t1,t2,t3,35);
			}
		}

		private void focus_ten1(TextBox t1,MaskedTextBox.MaskedTextBox t2,TextBox t3)
		{
			if (this.ActiveControl==t1)
			{
				Filt_dmbs(t1.Text);
				listNv.BrowseToDanhmuc(t1,t2,t3,35);
			}
		}

		private void cmbNgay_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cmbNgay && cmbNgay.SelectedIndex!=-1) load_head();
		}

		private void ngayvk_Validated(object sender, System.EventArgs e)
		{
			ngayvk.Text=ngayvk.Text.Trim();
			if (ngayvk.Text.Length==6) ngayvk.Text=ngayvk.Text+DateTime.Now.Year.ToString();
			if (!m.bNgay(ngayvk.Text))
			{
                MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"), LibMedi.AccessData.Msg);
				ngayvk.Focus();
				return;
			}
		}

		private void ngayrk_Validated(object sender, System.EventArgs e)
		{
			ngayrk.Text=ngayrk.Text.Trim();
			if (ngayrk.Text.Length==6) ngayrk.Text=ngayrk.Text+DateTime.Now.Year.ToString();
			if (!m.bNgay(ngayrk.Text))
			{
                MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"), LibMedi.AccessData.Msg);
				ngayrk.Focus();
				return;
			}
		}

		private void giork_Validated(object sender, System.EventArgs e)
		{
			string sgio=(giork.Text.Trim()=="")?"00:00":giork.Text.Trim();
			giork.Text=sgio.Substring(0,2).PadLeft(2,'0')+":"+sgio.Substring(3).Trim().PadRight(2,'0');
			if (!m.bGio(giork.Text))
			{
                MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"), LibMedi.AccessData.Msg);
				giork.Focus();
				return;
			}
		}

		private void giovk_Validated(object sender, System.EventArgs e)
		{
			string sgio=(giovk.Text.Trim()=="")?"00:00":giovk.Text.Trim();
			giovk.Text=sgio.Substring(0,2).PadLeft(2,'0')+":"+sgio.Substring(3).Trim().PadRight(2,'0');
			if (!m.bGio(giovk.Text))
			{
                MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"), LibMedi.AccessData.Msg);
				giovk.Focus();
				return;
			}
		}

		private void gioluc_Validated(object sender, System.EventArgs e)
		{
			string sgio=(gioluc.Text.Trim()=="")?"00:00":gioluc.Text.Trim();
			gioluc.Text=sgio.Substring(0,2).PadLeft(2,'0')+":"+sgio.Substring(3).Trim().PadRight(2,'0');
			if (!m.bGio(gioluc.Text))
			{
                MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"), LibMedi.AccessData.Msg);
				gioluc.Focus();
				return;
			}
		}

		private void ngayluc_Validated(object sender, System.EventArgs e)
		{
			ngayluc.Text=ngayrk.Text.Trim();
			if (ngayluc.Text.Length==6) ngayluc.Text=ngayluc.Text+DateTime.Now.Year.ToString();
			if (!m.bNgay(ngayrk.Text))
			{
                MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"), LibMedi.AccessData.Msg);
				ngayluc.Focus();
				return;
			}		
		}

		private void giove_Validated(object sender, System.EventArgs e)
		{
			string sgio=(giove.Text.Trim()=="")?"00:00":giove.Text.Trim();
			giove.Text=sgio.Substring(0,2).PadLeft(2,'0')+":"+sgio.Substring(3).Trim().PadRight(2,'0');
			if (!m.bGio(giove.Text))
			{
                MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"), LibMedi.AccessData.Msg);
				giove.Focus();
				return;
			}
		}

		private void ngayve_Validated(object sender, System.EventArgs e)
		{
			ngayve.Text=ngayve.Text.Trim();
			if (ngayve.Text.Length==6) ngayve.Text=ngayve.Text+DateTime.Now.Year.ToString();
			if (!m.bNgay(ngayve.Text))
			{
                MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"), LibMedi.AccessData.Msg);
				ngayve.Focus();
				return;
			}		
		}

		private void bs_vc_Validated(object sender, System.EventArgs e)
		{
			get_ten(bs_vc,tenbs_vc);
		}

		private void bs_kd_Validated(object sender, System.EventArgs e)
		{
			get_ten(bs_kd,tenbs_kd);
		}

		private void dd_cc_Validated(object sender, System.EventArgs e)
		{
			get_ten(dd_cc,tendd_cc);
		}

		private void dd_vc_Validated(object sender, System.EventArgs e)
		{
			get_ten(dd_vc,tendd_vc);
		}

		private void dd_kd_Validated(object sender, System.EventArgs e)
		{
			get_ten(dd_kd,tendd_kd);
		}

		private void tenbs_vc_TextChanged(object sender, System.EventArgs e)
		{
			focus_ten(tenbs_vc,bs_vc,bs_kd);		
		}

		private void tenbs_kd_TextChanged(object sender, System.EventArgs e)
		{
			focus_ten(tenbs_kd,bs_kd,dd_cc);
		}

		private void tendd_cc_TextChanged(object sender, System.EventArgs e)
		{
			focus_ten(tendd_cc,dd_cc,dd_vc);
		}

		private void tendd_vc_TextChanged(object sender, System.EventArgs e)
		{
			focus_ten(tendd_vc,dd_vc,dd_kd);
		}

		private void tendd_kd_TextChanged(object sender, System.EventArgs e)
		{
			focus_ten1(tendd_kd,dd_kd,khac);
		}

		private void chkThangmay_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==chkThangmay) thangmay.Enabled=chkThangmay.Checked;
		}

		private void chkPhongmo_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==chkPhongmo) phongmo.Enabled=chkPhongmo.Checked;
		}

		private void chkNhanbenh_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==chkNhanbenh) nhanbenh.Enabled=chkNhanbenh.Checked;
		}
	}
}
