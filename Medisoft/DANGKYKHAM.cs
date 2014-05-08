using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Lib_LH;
using LibMedi;
 
namespace Medisoft
{	
	public class DANGKYKHAM : System.Windows.Forms.Form
	{
        Language lan = new Language();
		Lib_LH.Access_Data k = new Lib_LH.Access_Data();	
		AccessData m = new AccessData();	
		DataSet Dssothutu;
		private string ngayk;
		private bool moi_;
		private string stt,mabacsi_ , mabn_;
		private System.Windows.Forms.Label lbHANHCHINH;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Button cmdKetthuc;
		private System.Windows.Forms.Button cmdBoqua;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Button cmdLuu;
		private System.Windows.Forms.TextBox txthoten;
		private System.Windows.Forms.TextBox txtnamsinh;
		private System.Windows.Forms.ComboBox cmbgioitinh;
		private System.Windows.Forms.TextBox txttuoi;
		private System.Windows.Forms.TextBox txtemail;
		private System.Windows.Forms.TextBox txtquanhuyen1;
		private System.Windows.Forms.TextBox txtdtnha;
		private System.Windows.Forms.TextBox txtnoilamviec;
		private System.Windows.Forms.TextBox txtdtcq;
		private System.Windows.Forms.TextBox txtgiokham;
		private System.Windows.Forms.ComboBox cmbtinhtrang;
		private System.Windows.Forms.ComboBox cmbbacsi;
		private System.Windows.Forms.ComboBox cmbphongkham;
		private System.Windows.Forms.TextBox txtghichu;
		private System.Windows.Forms.TextBox txtthonpho;
		private System.Windows.Forms.TextBox txtmabn2;
		private System.Windows.Forms.ComboBox cmbtuoi;
		private System.Windows.Forms.TextBox txtnghenghiep;
		private System.Windows.Forms.ComboBox cmbnghenghiep;
		private System.Windows.Forms.TextBox txtdantoc;
		private System.Windows.Forms.ComboBox cmbdantoc;
		private System.Windows.Forms.TextBox txtquoctich;
		private System.Windows.Forms.ComboBox cmbquoctich;
		private System.Windows.Forms.TextBox txtsonha;
		private System.Windows.Forms.TextBox txttqpxa;
		private System.Windows.Forms.ComboBox cmbtqpxa;
		private System.Windows.Forms.TextBox txttinhtp;
		private System.Windows.Forms.ComboBox cmbtinhtp;
		private System.Windows.Forms.TextBox txtquanhuyen2;
		private System.Windows.Forms.ComboBox cmbquanhuyen;
		private System.Windows.Forms.TextBox txtphuongxa1;
		private System.Windows.Forms.ComboBox cmbphuongxa;
		private System.Windows.Forms.TextBox txtphuongxa2;
		private System.Windows.Forms.TextBox txtdtdd;
		private System.Windows.Forms.ComboBox cmbloaihen;
		private MaskedBox.MaskedBox mkbngaykham;
		private System.Windows.Forms.TextBox txtmabn1;
		private MaskedBox.MaskedBox mkbngaysinh;
		private System.Windows.Forms.Label lbphongkham;
		private System.Windows.Forms.TextBox txtphongkham;
		private System.Windows.Forms.TextBox txttinhtrang;
		private System.Windows.Forms.TextBox txtbacsi;
		private System.Windows.Forms.TextBox txtloaihen;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.TextBox txtsothutu;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.TextBox txtid;
		private System.Windows.Forms.ComboBox cmbthoigian;
		private System.Windows.Forms.Label lbmanhom;
		private System.Windows.Forms.Label lb_maql;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.Button cmdprint;		
		private System.ComponentModel.Container components = null;

		public DANGKYKHAM(System.Windows.Forms.Form frmlichhen,string ngaykham,string giokham,string khoaphong, string idbacsi,string maql,string mabn,long u_maql,int u_loaiba,long u_idnhapkhoa,bool moi)
		{				
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            mkbngaykham.Text=ngaykham;			
			txtgiokham.Text=giokham;			
			lbphongkham.Text=khoaphong;	
			lbmanhom.Text=idbacsi;
			ngayk=ngaykham;
			lb_maql.Text =maql;
			moi_=moi;
			mabn_ = mabn;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DANGKYKHAM));
			this.lbHANHCHINH = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txthoten = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtnamsinh = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cmbgioitinh = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtmabn1 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txttuoi = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtemail = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtquanhuyen1 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtdtnha = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.txtnoilamviec = new System.Windows.Forms.TextBox();
			this.txtdtcq = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.txtgiokham = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.cmbthoigian = new System.Windows.Forms.ComboBox();
			this.label17 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.cmbtinhtrang = new System.Windows.Forms.ComboBox();
			this.label20 = new System.Windows.Forms.Label();
			this.cmbbacsi = new System.Windows.Forms.ComboBox();
			this.cmbphongkham = new System.Windows.Forms.ComboBox();
			this.txtghichu = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.txtthonpho = new System.Windows.Forms.TextBox();
			this.cmdKetthuc = new System.Windows.Forms.Button();
			this.cmdBoqua = new System.Windows.Forms.Button();
			this.cmdLuu = new System.Windows.Forms.Button();
			this.txtmabn2 = new System.Windows.Forms.TextBox();
			this.cmbtuoi = new System.Windows.Forms.ComboBox();
			this.txtnghenghiep = new System.Windows.Forms.TextBox();
			this.cmbnghenghiep = new System.Windows.Forms.ComboBox();
			this.txtdantoc = new System.Windows.Forms.TextBox();
			this.cmbdantoc = new System.Windows.Forms.ComboBox();
			this.label13 = new System.Windows.Forms.Label();
			this.txtquoctich = new System.Windows.Forms.TextBox();
			this.cmbquoctich = new System.Windows.Forms.ComboBox();
			this.label18 = new System.Windows.Forms.Label();
			this.txtsonha = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.txttqpxa = new System.Windows.Forms.TextBox();
			this.cmbtqpxa = new System.Windows.Forms.ComboBox();
			this.label25 = new System.Windows.Forms.Label();
			this.txttinhtp = new System.Windows.Forms.TextBox();
			this.cmbtinhtp = new System.Windows.Forms.ComboBox();
			this.txtquanhuyen2 = new System.Windows.Forms.TextBox();
			this.cmbquanhuyen = new System.Windows.Forms.ComboBox();
			this.txtphuongxa1 = new System.Windows.Forms.TextBox();
			this.cmbphuongxa = new System.Windows.Forms.ComboBox();
			this.txtphuongxa2 = new System.Windows.Forms.TextBox();
			this.label26 = new System.Windows.Forms.Label();
			this.label27 = new System.Windows.Forms.Label();
			this.txtdtdd = new System.Windows.Forms.TextBox();
			this.label28 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.cmbloaihen = new System.Windows.Forms.ComboBox();
			this.mkbngaykham = new MaskedBox.MaskedBox();
			this.mkbngaysinh = new MaskedBox.MaskedBox();
			this.lbphongkham = new System.Windows.Forms.Label();
			this.txtphongkham = new System.Windows.Forms.TextBox();
			this.txttinhtrang = new System.Windows.Forms.TextBox();
			this.txtbacsi = new System.Windows.Forms.TextBox();
			this.txtloaihen = new System.Windows.Forms.TextBox();
			this.label36 = new System.Windows.Forms.Label();
			this.txtsothutu = new System.Windows.Forms.TextBox();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.txtid = new System.Windows.Forms.TextBox();
			this.lbmanhom = new System.Windows.Forms.Label();
			this.lb_maql = new System.Windows.Forms.Label();
			this.dataGrid2 = new System.Windows.Forms.DataGrid();
			this.cmdprint = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
			this.SuspendLayout();
			// 
			// lbHANHCHINH
			// 
			this.lbHANHCHINH.BackColor = System.Drawing.SystemColors.Control;
			this.lbHANHCHINH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline), System.Drawing.GraphicsUnit.Point, ((System.Byte)(163)));
			this.lbHANHCHINH.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.lbHANHCHINH.Location = new System.Drawing.Point(8, 16);
			this.lbHANHCHINH.Name = "lbHANHCHINH";
			this.lbHANHCHINH.Size = new System.Drawing.Size(176, 16);
			this.lbHANHCHINH.TabIndex = 1;
			this.lbHANHCHINH.Text = "1. THÔNG TIN HÀNH CHÍNH";
			this.lbHANHCHINH.Click += new System.EventHandler(this.lbHANHCHINH_Click);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.SystemColors.Control;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline), System.Drawing.GraphicsUnit.Point, ((System.Byte)(163)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label1.Location = new System.Drawing.Point(8, 184);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(160, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "2. THÔNG TIN HẸN KHÁM";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.SystemColors.Control;
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label2.Location = new System.Drawing.Point(144, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Họ Tên ";
			// 
			// txthoten
			// 
			this.txthoten.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txthoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txthoten.Location = new System.Drawing.Point(190, 46);
			this.txthoten.Name = "txthoten";
			this.txthoten.Size = new System.Drawing.Size(200, 20);
			this.txthoten.TabIndex = 3;
			this.txthoten.Text = "";
			this.txthoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txthoten_KeyDown);
			this.txthoten.Leave += new System.EventHandler(this.txthoten_Leave);
			this.txthoten.Enter += new System.EventHandler(this.txthoten_Enter);
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.SystemColors.Control;
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label3.Location = new System.Drawing.Point(405, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "Ngày Sinh ";
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.SystemColors.Control;
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label4.Location = new System.Drawing.Point(544, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 7;
			this.label4.Text = "Năm Sinh ";
			// 
			// txtnamsinh
			// 
			this.txtnamsinh.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txtnamsinh.Location = new System.Drawing.Point(600, 46);
			this.txtnamsinh.MaxLength = 4;
			this.txtnamsinh.Name = "txtnamsinh";
			this.txtnamsinh.Size = new System.Drawing.Size(40, 20);
			this.txtnamsinh.TabIndex = 5;
			this.txtnamsinh.Text = "";
			this.txtnamsinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtnamsinh_KeyDown);
			this.txtnamsinh.Validated += new System.EventHandler(this.txtnamsinh_Validated);
			this.txtnamsinh.Leave += new System.EventHandler(this.txtnamsinh_Leave);
			this.txtnamsinh.Enter += new System.EventHandler(this.txtnamsinh_Enter);
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.SystemColors.Control;
			this.label5.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label5.Location = new System.Drawing.Point(8, 72);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(59, 16);
			this.label5.TabIndex = 9;
			this.label5.Text = "Giới Tính  ";
			// 
			// cmbgioitinh
			// 
			this.cmbgioitinh.BackColor = System.Drawing.SystemColors.HighlightText;
			this.cmbgioitinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbgioitinh.Location = new System.Drawing.Point(64, 68);
			this.cmbgioitinh.Name = "cmbgioitinh";
			this.cmbgioitinh.Size = new System.Drawing.Size(49, 21);
			this.cmbgioitinh.TabIndex = 8;
			this.cmbgioitinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbgioitinh_KeyDown);
			this.cmbgioitinh.Validated += new System.EventHandler(this.cmbgioitinh_Validated);
			this.cmbgioitinh.Leave += new System.EventHandler(this.cmbgioitinh_Leave);
			this.cmbgioitinh.Enter += new System.EventHandler(this.cmbgioitinh_Enter);
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.SystemColors.Control;
			this.label6.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label6.Location = new System.Drawing.Point(7, 49);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(60, 16);
			this.label6.TabIndex = 11;
			this.label6.Text = "Mã BN    ";
			// 
			// txtmabn1
			// 
			this.txtmabn1.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txtmabn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(163)));
			this.txtmabn1.Location = new System.Drawing.Point(64, 46);
			this.txtmabn1.MaxLength = 2;
			this.txtmabn1.Name = "txtmabn1";
			this.txtmabn1.Size = new System.Drawing.Size(24, 20);
			this.txtmabn1.TabIndex = 0;
			this.txtmabn1.Text = "";
			this.txtmabn1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmabn1_KeyDown);
			this.txtmabn1.Validated += new System.EventHandler(this.txtmabn1_Validated);
			this.txtmabn1.Leave += new System.EventHandler(this.txtmabn1_Leave);
			this.txtmabn1.Enter += new System.EventHandler(this.txtmabn1_Enter);
			// 
			// label7
			// 
			this.label7.BackColor = System.Drawing.SystemColors.Control;
			this.label7.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label7.Location = new System.Drawing.Point(649, 49);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(40, 16);
			this.label7.TabIndex = 13;
			this.label7.Text = "Tuổi ";
			// 
			// txttuoi
			// 
			this.txttuoi.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txttuoi.Location = new System.Drawing.Point(682, 46);
			this.txttuoi.MaxLength = 3;
			this.txttuoi.Name = "txttuoi";
			this.txttuoi.Size = new System.Drawing.Size(28, 20);
			this.txttuoi.TabIndex = 6;
			this.txttuoi.Text = "";
			this.txttuoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txttuoi_KeyDown);
			this.txttuoi.Validated += new System.EventHandler(this.txttuoi_Validated);
			this.txttuoi.Leave += new System.EventHandler(this.txttuoi_Leave);
			this.txttuoi.Enter += new System.EventHandler(this.txttuoi_Enter);
			// 
			// label8
			// 
			this.label8.BackColor = System.Drawing.SystemColors.Control;
			this.label8.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label8.Location = new System.Drawing.Point(118, 72);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(80, 16);
			this.label8.TabIndex = 15;
			this.label8.Text = "Nghề Nghiệp ";
			// 
			// txtemail
			// 
			this.txtemail.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txtemail.Location = new System.Drawing.Point(640, 136);
			this.txtemail.Name = "txtemail";
			this.txtemail.Size = new System.Drawing.Size(144, 20);
			this.txtemail.TabIndex = 31;
			this.txtemail.Text = "";
			this.txtemail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtemail_KeyDown);
			this.txtemail.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtemail_MouseDown);
			this.txtemail.Leave += new System.EventHandler(this.txtemail_Leave);
			this.txtemail.Enter += new System.EventHandler(this.txtemail_Enter);
			// 
			// label9
			// 
			this.label9.BackColor = System.Drawing.SystemColors.Control;
			this.label9.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label9.Location = new System.Drawing.Point(9, 117);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(66, 16);
			this.label9.TabIndex = 17;
			this.label9.Text = "Quận/ H  ";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtquanhuyen1
			// 
			this.txtquanhuyen1.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txtquanhuyen1.Enabled = false;
			this.txtquanhuyen1.Location = new System.Drawing.Point(64, 113);
			this.txtquanhuyen1.Name = "txtquanhuyen1";
			this.txtquanhuyen1.Size = new System.Drawing.Size(28, 20);
			this.txtquanhuyen1.TabIndex = 21;
			this.txtquanhuyen1.Text = "";
			this.txtquanhuyen1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtquanhuyen1_KeyDown);
			// 
			// label10
			// 
			this.label10.BackColor = System.Drawing.SystemColors.Control;
			this.label10.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label10.Location = new System.Drawing.Point(8, 139);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(96, 16);
			this.label10.TabIndex = 19;
			this.label10.Text = "Điện Thoại Nhà  ";
			// 
			// txtdtnha
			// 
			this.txtdtnha.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txtdtnha.Location = new System.Drawing.Point(96, 136);
			this.txtdtnha.Name = "txtdtnha";
			this.txtdtnha.Size = new System.Drawing.Size(72, 20);
			this.txtdtnha.TabIndex = 28;
			this.txtdtnha.Text = "";
			this.txtdtnha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtdtnha_KeyDown);
			this.txtdtnha.Leave += new System.EventHandler(this.txtdtnha_Leave);
			this.txtdtnha.Enter += new System.EventHandler(this.txtdtnha_Enter);
			// 
			// label11
			// 
			this.label11.BackColor = System.Drawing.SystemColors.Control;
			this.label11.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label11.Location = new System.Drawing.Point(290, 117);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(72, 16);
			this.label11.TabIndex = 21;
			this.label11.Text = "Phường/Xã";
			// 
			// label12
			// 
			this.label12.BackColor = System.Drawing.SystemColors.Control;
			this.label12.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label12.Location = new System.Drawing.Point(384, 139);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(120, 16);
			this.label12.TabIndex = 22;
			this.label12.Text = "Điện Thoại Cơ Quan  ";
			// 
			// txtnoilamviec
			// 
			this.txtnoilamviec.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txtnoilamviec.Location = new System.Drawing.Point(650, 114);
			this.txtnoilamviec.Name = "txtnoilamviec";
			this.txtnoilamviec.Size = new System.Drawing.Size(134, 20);
			this.txtnoilamviec.TabIndex = 27;
			this.txtnoilamviec.Text = "";
			this.txtnoilamviec.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtnoilamviec_KeyDown);
			this.txtnoilamviec.Leave += new System.EventHandler(this.txtnoilamviec_Leave);
			this.txtnoilamviec.Enter += new System.EventHandler(this.txtnoilamviec_Enter);
			// 
			// txtdtcq
			// 
			this.txtdtcq.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txtdtcq.Location = new System.Drawing.Point(496, 136);
			this.txtdtcq.Name = "txtdtcq";
			this.txtdtcq.Size = new System.Drawing.Size(88, 20);
			this.txtdtcq.TabIndex = 30;
			this.txtdtcq.Text = "";
			this.txtdtcq.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtdtcq_KeyDown);
			this.txtdtcq.Leave += new System.EventHandler(this.txtdtcq_Leave);
			this.txtdtcq.Enter += new System.EventHandler(this.txtdtcq_Enter);
			// 
			// label14
			// 
			this.label14.BackColor = System.Drawing.SystemColors.Control;
			this.label14.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label14.Location = new System.Drawing.Point(64, 234);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(72, 16);
			this.label14.TabIndex = 26;
			this.label14.Text = "Ngày Khám ";
			// 
			// label15
			// 
			this.label15.BackColor = System.Drawing.SystemColors.Control;
			this.label15.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label15.Location = new System.Drawing.Point(208, 234);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(72, 16);
			this.label15.TabIndex = 28;
			this.label15.Text = "Giờ Khám ";
			// 
			// txtgiokham
			// 
			this.txtgiokham.BackColor = System.Drawing.Color.WhiteSmoke;
			this.txtgiokham.Location = new System.Drawing.Point(264, 233);
			this.txtgiokham.Name = "txtgiokham";
			this.txtgiokham.Size = new System.Drawing.Size(40, 20);
			this.txtgiokham.TabIndex = 33;
			this.txtgiokham.Text = "";
			this.txtgiokham.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtgiokham_KeyDown);
			this.txtgiokham.Validated += new System.EventHandler(this.txtgiokham_Validated);
			this.txtgiokham.Leave += new System.EventHandler(this.txtgiokham_Leave);
			this.txtgiokham.Enter += new System.EventHandler(this.txtgiokham_Enter);
			// 
			// label16
			// 
			this.label16.BackColor = System.Drawing.SystemColors.Control;
			this.label16.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label16.Location = new System.Drawing.Point(322, 234);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(145, 16);
			this.label16.TabIndex = 30;
			this.label16.Text = "Thời Gian Khám (Phút) ";
			// 
			// cmbthoigian
			// 
			this.cmbthoigian.BackColor = System.Drawing.Color.WhiteSmoke;
			this.cmbthoigian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbthoigian.Items.AddRange(new object[] {
															 "05",
															 "10",
															 "15",
															 "20",
															 "25",
															 "30"});
			this.cmbthoigian.Location = new System.Drawing.Point(440, 232);
			this.cmbthoigian.MaxDropDownItems = 15;
			this.cmbthoigian.Name = "cmbthoigian";
			this.cmbthoigian.Size = new System.Drawing.Size(46, 21);
			this.cmbthoigian.TabIndex = 34;
			this.cmbthoigian.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtthoigian_KeyDown);
			this.cmbthoigian.Leave += new System.EventHandler(this.cmbthoigian_Leave);
			this.cmbthoigian.Enter += new System.EventHandler(this.cmbthoigian_Enter);
			// 
			// label17
			// 
			this.label17.BackColor = System.Drawing.SystemColors.Control;
			this.label17.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label17.Location = new System.Drawing.Point(504, 234);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(80, 16);
			this.label17.TabIndex = 32;
			this.label17.Text = "Phòng Khám";
			// 
			// label19
			// 
			this.label19.BackColor = System.Drawing.SystemColors.Control;
			this.label19.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label19.Location = new System.Drawing.Point(64, 258);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(72, 16);
			this.label19.TabIndex = 37;
			this.label19.Text = "Tình Trạng  ";
			// 
			// cmbtinhtrang
			// 
			this.cmbtinhtrang.BackColor = System.Drawing.SystemColors.HighlightText;
			this.cmbtinhtrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbtinhtrang.Location = new System.Drawing.Point(165, 255);
			this.cmbtinhtrang.Name = "cmbtinhtrang";
			this.cmbtinhtrang.Size = new System.Drawing.Size(113, 21);
			this.cmbtinhtrang.TabIndex = 38;
			this.cmbtinhtrang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbtinhtrang_KeyDown);
			this.cmbtinhtrang.SelectedIndexChanged += new System.EventHandler(this.cmbtinhtrang_SelectedIndexChanged);
			this.cmbtinhtrang.Leave += new System.EventHandler(this.cmbtinhtrang_Leave);
			this.cmbtinhtrang.Enter += new System.EventHandler(this.cmbtinhtrang_Enter);
			// 
			// label20
			// 
			this.label20.BackColor = System.Drawing.SystemColors.Control;
			this.label20.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label20.Location = new System.Drawing.Point(522, 258);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(72, 16);
			this.label20.TabIndex = 39;
			this.label20.Text = "BS Khám ";
			// 
			// cmbbacsi
			// 
			this.cmbbacsi.BackColor = System.Drawing.Color.WhiteSmoke;
			this.cmbbacsi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbbacsi.DropDownWidth = 150;
			this.cmbbacsi.Location = new System.Drawing.Point(614, 256);
			this.cmbbacsi.Name = "cmbbacsi";
			this.cmbbacsi.Size = new System.Drawing.Size(114, 21);
			this.cmbbacsi.TabIndex = 42;
			this.cmbbacsi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbbacsi_KeyDown);
			this.cmbbacsi.SelectedIndexChanged += new System.EventHandler(this.cmbbacsi_SelectedIndexChanged);
			this.cmbbacsi.Leave += new System.EventHandler(this.cmbbacsi_Leave);
			this.cmbbacsi.Enter += new System.EventHandler(this.cmbbacsi_Enter);
			// 
			// cmbphongkham
			// 
			this.cmbphongkham.BackColor = System.Drawing.SystemColors.HighlightText;
			this.cmbphongkham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbphongkham.Location = new System.Drawing.Point(614, 233);
			this.cmbphongkham.Name = "cmbphongkham";
			this.cmbphongkham.Size = new System.Drawing.Size(114, 21);
			this.cmbphongkham.TabIndex = 36;
			this.cmbphongkham.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbphongkham_KeyDown);
			this.cmbphongkham.SelectedIndexChanged += new System.EventHandler(this.cmbphongkham_SelectedIndexChanged);
			this.cmbphongkham.Leave += new System.EventHandler(this.cmbphongkham_Leave);
			this.cmbphongkham.Enter += new System.EventHandler(this.cmbphongkham_Enter);
			// 
			// txtghichu
			// 
			this.txtghichu.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txtghichu.Location = new System.Drawing.Point(128, 296);
			this.txtghichu.Multiline = true;
			this.txtghichu.Name = "txtghichu";
			this.txtghichu.Size = new System.Drawing.Size(600, 64);
			this.txtghichu.TabIndex = 43;
			this.txtghichu.Text = "";
			this.txtghichu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtghichu_KeyDown);
			this.txtghichu.Leave += new System.EventHandler(this.txtghichu_Leave);
			this.txtghichu.Enter += new System.EventHandler(this.txtghichu_Enter);
			// 
			// label21
			// 
			this.label21.BackColor = System.Drawing.SystemColors.Control;
			this.label21.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label21.Location = new System.Drawing.Point(64, 280);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(80, 16);
			this.label21.TabIndex = 43;
			this.label21.Text = "Ghi Chú       ";
			// 
			// label22
			// 
			this.label22.BackColor = System.Drawing.SystemColors.Control;
			this.label22.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label22.Location = new System.Drawing.Point(352, 72);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(56, 16);
			this.label22.TabIndex = 44;
			this.label22.Text = "Dân Tộc :";
			// 
			// label23
			// 
			this.label23.BackColor = System.Drawing.SystemColors.Control;
			this.label23.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label23.Location = new System.Drawing.Point(8, 94);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(88, 16);
			this.label23.TabIndex = 46;
			this.label23.Text = "Thôn Phố ";
			// 
			// txtthonpho
			// 
			this.txtthonpho.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txtthonpho.Location = new System.Drawing.Point(64, 91);
			this.txtthonpho.Name = "txtthonpho";
			this.txtthonpho.Size = new System.Drawing.Size(158, 20);
			this.txtthonpho.TabIndex = 16;
			this.txtthonpho.Text = "";
			this.txtthonpho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtthonpho_KeyDown);
			this.txtthonpho.Leave += new System.EventHandler(this.txtthonpho_Leave);
			this.txtthonpho.Enter += new System.EventHandler(this.txtthonpho_Enter);
			// 
			// cmdKetthuc
			// 
			this.cmdKetthuc.BackColor = System.Drawing.SystemColors.Desktop;
			this.cmdKetthuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(163)));
			this.cmdKetthuc.ForeColor = System.Drawing.Color.White;
			this.cmdKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdKetthuc.Location = new System.Drawing.Point(477, 408);
			this.cmdKetthuc.Name = "cmdKetthuc";
			this.cmdKetthuc.Size = new System.Drawing.Size(76, 33);
			this.cmdKetthuc.TabIndex = 47;
			this.cmdKetthuc.Text = "Kết thúc";
			this.cmdKetthuc.Click += new System.EventHandler(this.cmdKetthuc_Click);
			// 
			// cmdBoqua
			// 
			this.cmdBoqua.BackColor = System.Drawing.SystemColors.Desktop;
			this.cmdBoqua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(163)));
			this.cmdBoqua.ForeColor = System.Drawing.Color.White;
			this.cmdBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdBoqua.Location = new System.Drawing.Point(336, 408);
			this.cmdBoqua.Name = "cmdBoqua";
			this.cmdBoqua.Size = new System.Drawing.Size(70, 33);
			this.cmdBoqua.TabIndex = 45;
			this.cmdBoqua.Text = "Bỏ qua";
			this.cmdBoqua.Click += new System.EventHandler(this.cmdBoqua_Click);
			// 
			// cmdLuu
			// 
			this.cmdLuu.BackColor = System.Drawing.SystemColors.Desktop;
			this.cmdLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(163)));
			this.cmdLuu.ForeColor = System.Drawing.Color.White;
			this.cmdLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdLuu.Location = new System.Drawing.Point(280, 408);
			this.cmdLuu.Name = "cmdLuu";
			this.cmdLuu.Size = new System.Drawing.Size(58, 33);
			this.cmdLuu.TabIndex = 44;
			this.cmdLuu.Text = "Lưu";
			this.cmdLuu.Click += new System.EventHandler(this.cmdLuu_Click);
			this.cmdLuu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmdLuu_KeyDown);
			// 
			// txtmabn2
			// 
			this.txtmabn2.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txtmabn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(163)));
			this.txtmabn2.Location = new System.Drawing.Point(90, 46);
			this.txtmabn2.MaxLength = 6;
			this.txtmabn2.Name = "txtmabn2";
			this.txtmabn2.Size = new System.Drawing.Size(50, 20);
			this.txtmabn2.TabIndex = 1;
			this.txtmabn2.Text = "";
			this.txtmabn2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmabn2_KeyDown);
			this.txtmabn2.Validated += new System.EventHandler(this.txtmabn2_Validated);
			this.txtmabn2.Leave += new System.EventHandler(this.txtmabn2_Leave);
			this.txtmabn2.Enter += new System.EventHandler(this.txtmabn2_Enter);
			// 
			// cmbtuoi
			// 
			this.cmbtuoi.BackColor = System.Drawing.SystemColors.HighlightText;
			this.cmbtuoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbtuoi.Items.AddRange(new object[] {
														 "Tuổi",
														 "Tháng",
														 "Ngày"});
			this.cmbtuoi.Location = new System.Drawing.Point(712, 46);
			this.cmbtuoi.Name = "cmbtuoi";
			this.cmbtuoi.Size = new System.Drawing.Size(72, 21);
			this.cmbtuoi.TabIndex = 7;
			this.cmbtuoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbtuoi_KeyDown);
			this.cmbtuoi.Validated += new System.EventHandler(this.cmbtuoi_Validated);
			this.cmbtuoi.Leave += new System.EventHandler(this.cmbtuoi_Leave);
			this.cmbtuoi.Enter += new System.EventHandler(this.cmbtuoi_Enter);
			// 
			// txtnghenghiep
			// 
			this.txtnghenghiep.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txtnghenghiep.Location = new System.Drawing.Point(190, 68);
			this.txtnghenghiep.Name = "txtnghenghiep";
			this.txtnghenghiep.Size = new System.Drawing.Size(26, 20);
			this.txtnghenghiep.TabIndex = 9;
			this.txtnghenghiep.Text = "";
			this.txtnghenghiep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtnghenghiep_KeyDown);
			this.txtnghenghiep.Validated += new System.EventHandler(this.txtnghenghiep_Validated);
			this.txtnghenghiep.Leave += new System.EventHandler(this.txtnghenghiep_Leave);
			this.txtnghenghiep.Enter += new System.EventHandler(this.txtnghenghiep_Enter);
			// 
			// cmbnghenghiep
			// 
			this.cmbnghenghiep.BackColor = System.Drawing.SystemColors.HighlightText;
			this.cmbnghenghiep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbnghenghiep.Location = new System.Drawing.Point(218, 68);
			this.cmbnghenghiep.Name = "cmbnghenghiep";
			this.cmbnghenghiep.Size = new System.Drawing.Size(127, 21);
			this.cmbnghenghiep.TabIndex = 10;
			this.cmbnghenghiep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbnghenghiep_KeyDown);
			this.cmbnghenghiep.SelectedIndexChanged += new System.EventHandler(this.cmbnghenghiep_SelectedIndexChanged);
			this.cmbnghenghiep.Leave += new System.EventHandler(this.cmbnghenghiep_Leave);
			this.cmbnghenghiep.Enter += new System.EventHandler(this.cmbnghenghiep_Enter);
			// 
			// txtdantoc
			// 
			this.txtdantoc.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txtdantoc.Location = new System.Drawing.Point(400, 68);
			this.txtdantoc.Name = "txtdantoc";
			this.txtdantoc.Size = new System.Drawing.Size(26, 20);
			this.txtdantoc.TabIndex = 11;
			this.txtdantoc.Text = "";
			this.txtdantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtdantoc_KeyDown);
			this.txtdantoc.Validated += new System.EventHandler(this.txtdantoc_Validated);
			this.txtdantoc.Leave += new System.EventHandler(this.txtdantoc_Leave);
			this.txtdantoc.Enter += new System.EventHandler(this.txtdantoc_Enter);
			// 
			// cmbdantoc
			// 
			this.cmbdantoc.BackColor = System.Drawing.SystemColors.HighlightText;
			this.cmbdantoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbdantoc.Location = new System.Drawing.Point(428, 68);
			this.cmbdantoc.Name = "cmbdantoc";
			this.cmbdantoc.Size = new System.Drawing.Size(72, 21);
			this.cmbdantoc.TabIndex = 12;
			this.cmbdantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbdantoc_KeyDown);
			this.cmbdantoc.SelectedIndexChanged += new System.EventHandler(this.cmbdantoc_SelectedIndexChanged);
			this.cmbdantoc.Leave += new System.EventHandler(this.cmbdantoc_Leave);
			this.cmbdantoc.Enter += new System.EventHandler(this.cmbdantoc_Enter);
			// 
			// label13
			// 
			this.label13.BackColor = System.Drawing.SystemColors.Control;
			this.label13.ForeColor = System.Drawing.Color.Blue;
			this.label13.Location = new System.Drawing.Point(512, 72);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(64, 16);
			this.label13.TabIndex = 81;
			this.label13.Text = "Quốc Tịch ";
			// 
			// txtquoctich
			// 
			this.txtquoctich.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txtquoctich.Location = new System.Drawing.Point(571, 68);
			this.txtquoctich.Name = "txtquoctich";
			this.txtquoctich.Size = new System.Drawing.Size(27, 20);
			this.txtquoctich.TabIndex = 13;
			this.txtquoctich.Text = "";
			this.txtquoctich.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtquoctich_KeyDown);
			this.txtquoctich.Validated += new System.EventHandler(this.txtquoctich_Validated);
			this.txtquoctich.Leave += new System.EventHandler(this.txtquoctich_Leave);
			this.txtquoctich.Enter += new System.EventHandler(this.txtquoctich_Enter);
			// 
			// cmbquoctich
			// 
			this.cmbquoctich.BackColor = System.Drawing.SystemColors.HighlightText;
			this.cmbquoctich.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbquoctich.Location = new System.Drawing.Point(600, 68);
			this.cmbquoctich.Name = "cmbquoctich";
			this.cmbquoctich.Size = new System.Drawing.Size(77, 21);
			this.cmbquoctich.TabIndex = 14;
			this.cmbquoctich.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbquoctich_KeyDown);
			this.cmbquoctich.SelectedIndexChanged += new System.EventHandler(this.cmbquoctich_SelectedIndexChanged);
			this.cmbquoctich.Leave += new System.EventHandler(this.cmbquoctich_Leave);
			this.cmbquoctich.Enter += new System.EventHandler(this.cmbquoctich_Enter);
			// 
			// label18
			// 
			this.label18.BackColor = System.Drawing.SystemColors.Control;
			this.label18.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label18.Location = new System.Drawing.Point(680, 72);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(48, 16);
			this.label18.TabIndex = 84;
			this.label18.Text = "Số Nhà ";
			// 
			// txtsonha
			// 
			this.txtsonha.BackColor = System.Drawing.Color.WhiteSmoke;
			this.txtsonha.Location = new System.Drawing.Point(728, 68);
			this.txtsonha.Name = "txtsonha";
			this.txtsonha.Size = new System.Drawing.Size(56, 20);
			this.txtsonha.TabIndex = 15;
			this.txtsonha.Text = "";
			this.txtsonha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsonha_KeyDown);
			this.txtsonha.Leave += new System.EventHandler(this.txtsonha_Leave);
			this.txtsonha.Enter += new System.EventHandler(this.txtsonha_Enter);
			// 
			// label24
			// 
			this.label24.BackColor = System.Drawing.SystemColors.Control;
			this.label24.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label24.Location = new System.Drawing.Point(230, 94);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(64, 16);
			this.label24.TabIndex = 86;
			this.label24.Text = "T/Q/PXã ";
			// 
			// txttqpxa
			// 
			this.txttqpxa.AcceptsReturn = true;
			this.txttqpxa.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txttqpxa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txttqpxa.Location = new System.Drawing.Point(286, 91);
			this.txttqpxa.MaxLength = 6;
			this.txttqpxa.Name = "txttqpxa";
			this.txttqpxa.Size = new System.Drawing.Size(53, 20);
			this.txttqpxa.TabIndex = 17;
			this.txttqpxa.Text = "";
			this.txttqpxa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txttqpxa_KeyDown);
			this.txttqpxa.Leave += new System.EventHandler(this.txttqpxa_Leave);
			this.txttqpxa.Enter += new System.EventHandler(this.txttqpxa_Enter);
			// 
			// cmbtqpxa
			// 
			this.cmbtqpxa.BackColor = System.Drawing.SystemColors.HighlightText;
			this.cmbtqpxa.DropDownWidth = 220;
			this.cmbtqpxa.Location = new System.Drawing.Point(341, 91);
			this.cmbtqpxa.Name = "cmbtqpxa";
			this.cmbtqpxa.Size = new System.Drawing.Size(179, 21);
			this.cmbtqpxa.TabIndex = 18;
			this.cmbtqpxa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbtqpxa_KeyDown);
			this.cmbtqpxa.SelectedIndexChanged += new System.EventHandler(this.cmbtqpxa_SelectedIndexChanged);
			this.cmbtqpxa.Leave += new System.EventHandler(this.cmbtqpxa_Leave);
			this.cmbtqpxa.Enter += new System.EventHandler(this.cmbtqpxa_Enter);
			// 
			// label25
			// 
			this.label25.BackColor = System.Drawing.SystemColors.Control;
			this.label25.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label25.Location = new System.Drawing.Point(516, 94);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(56, 16);
			this.label25.TabIndex = 89;
			this.label25.Text = "Tỉnh/TP ";
			this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txttinhtp
			// 
			this.txttinhtp.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txttinhtp.Location = new System.Drawing.Point(571, 91);
			this.txttinhtp.MaxLength = 3;
			this.txttinhtp.Name = "txttinhtp";
			this.txttinhtp.Size = new System.Drawing.Size(28, 20);
			this.txttinhtp.TabIndex = 19;
			this.txttinhtp.Text = "";
			this.txttinhtp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txttinhtp_KeyDown);
			this.txttinhtp.Validated += new System.EventHandler(this.txttinhtp_Validated);
			this.txttinhtp.Leave += new System.EventHandler(this.txttinhtp_Leave);
			this.txttinhtp.Enter += new System.EventHandler(this.txttinhtp_Enter);
			// 
			// cmbtinhtp
			// 
			this.cmbtinhtp.BackColor = System.Drawing.SystemColors.HighlightText;
			this.cmbtinhtp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbtinhtp.Location = new System.Drawing.Point(601, 91);
			this.cmbtinhtp.Name = "cmbtinhtp";
			this.cmbtinhtp.Size = new System.Drawing.Size(183, 21);
			this.cmbtinhtp.TabIndex = 20;
			this.cmbtinhtp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbtinhtp_KeyDown);
			this.cmbtinhtp.SelectedIndexChanged += new System.EventHandler(this.cmbtinhtp_SelectedIndexChanged);
			this.cmbtinhtp.Leave += new System.EventHandler(this.cmbtinhtp_Leave);
			this.cmbtinhtp.Enter += new System.EventHandler(this.cmbtinhtp_Enter);
			// 
			// txtquanhuyen2
			// 
			this.txtquanhuyen2.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txtquanhuyen2.Location = new System.Drawing.Point(94, 113);
			this.txtquanhuyen2.MaxLength = 2;
			this.txtquanhuyen2.Name = "txtquanhuyen2";
			this.txtquanhuyen2.Size = new System.Drawing.Size(27, 20);
			this.txtquanhuyen2.TabIndex = 22;
			this.txtquanhuyen2.Text = "";
			this.txtquanhuyen2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtquanhuyen2_KeyDown);
			this.txtquanhuyen2.Validated += new System.EventHandler(this.txtquanhuyen2_Validated);
			this.txtquanhuyen2.Leave += new System.EventHandler(this.txtquanhuyen2_Leave);
			this.txtquanhuyen2.Enter += new System.EventHandler(this.txtquanhuyen2_Enter);
			// 
			// cmbquanhuyen
			// 
			this.cmbquanhuyen.BackColor = System.Drawing.SystemColors.HighlightText;
			this.cmbquanhuyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbquanhuyen.Location = new System.Drawing.Point(123, 113);
			this.cmbquanhuyen.Name = "cmbquanhuyen";
			this.cmbquanhuyen.Size = new System.Drawing.Size(156, 21);
			this.cmbquanhuyen.TabIndex = 23;
			this.cmbquanhuyen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbquanhuyen_KeyDown);
			this.cmbquanhuyen.SelectedIndexChanged += new System.EventHandler(this.cmbquanhuyen_SelectedIndexChanged);
			this.cmbquanhuyen.Leave += new System.EventHandler(this.cmbquanhuyen_Leave);
			this.cmbquanhuyen.Enter += new System.EventHandler(this.cmbquanhuyen_Enter);
			// 
			// txtphuongxa1
			// 
			this.txtphuongxa1.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txtphuongxa1.Enabled = false;
			this.txtphuongxa1.Location = new System.Drawing.Point(354, 113);
			this.txtphuongxa1.Name = "txtphuongxa1";
			this.txtphuongxa1.Size = new System.Drawing.Size(40, 20);
			this.txtphuongxa1.TabIndex = 24;
			this.txtphuongxa1.Text = "";
			this.txtphuongxa1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtphuongxa1_KeyDown);
			this.txtphuongxa1.Leave += new System.EventHandler(this.txtphuongxa1_Leave);
			this.txtphuongxa1.Enter += new System.EventHandler(this.txtphuongxa1_Enter);
			// 
			// cmbphuongxa
			// 
			this.cmbphuongxa.BackColor = System.Drawing.SystemColors.HighlightText;
			this.cmbphuongxa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbphuongxa.DropDownWidth = 150;
			this.cmbphuongxa.Location = new System.Drawing.Point(422, 113);
			this.cmbphuongxa.MaxDropDownItems = 12;
			this.cmbphuongxa.Name = "cmbphuongxa";
			this.cmbphuongxa.Size = new System.Drawing.Size(144, 21);
			this.cmbphuongxa.TabIndex = 26;
			this.cmbphuongxa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbphuongxa_KeyDown);
			this.cmbphuongxa.SelectedIndexChanged += new System.EventHandler(this.cmbphuongxa_SelectedIndexChanged);
			this.cmbphuongxa.Leave += new System.EventHandler(this.cmbphuongxa_Leave);
			this.cmbphuongxa.Enter += new System.EventHandler(this.cmbphuongxa_Enter);
			// 
			// txtphuongxa2
			// 
			this.txtphuongxa2.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txtphuongxa2.Location = new System.Drawing.Point(396, 113);
			this.txtphuongxa2.MaxLength = 2;
			this.txtphuongxa2.Name = "txtphuongxa2";
			this.txtphuongxa2.Size = new System.Drawing.Size(24, 20);
			this.txtphuongxa2.TabIndex = 25;
			this.txtphuongxa2.Text = "";
			this.txtphuongxa2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtphuongxa2_KeyDown);
			this.txtphuongxa2.Validated += new System.EventHandler(this.txtphuongxa2_Validated);
			this.txtphuongxa2.Leave += new System.EventHandler(this.txtphuongxa2_Leave);
			this.txtphuongxa2.Enter += new System.EventHandler(this.txtphuongxa2_Enter);
			// 
			// label26
			// 
			this.label26.BackColor = System.Drawing.SystemColors.Control;
			this.label26.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label26.Location = new System.Drawing.Point(572, 117);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(80, 16);
			this.label26.TabIndex = 96;
			this.label26.Text = "Nơi Làm Việc";
			// 
			// label27
			// 
			this.label27.BackColor = System.Drawing.SystemColors.Control;
			this.label27.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label27.Location = new System.Drawing.Point(184, 139);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(120, 16);
			this.label27.TabIndex = 98;
			this.label27.Text = "Điện Thoại Di Động ";
			// 
			// txtdtdd
			// 
			this.txtdtdd.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txtdtdd.Location = new System.Drawing.Point(288, 136);
			this.txtdtdd.Name = "txtdtdd";
			this.txtdtdd.Size = new System.Drawing.Size(72, 20);
			this.txtdtdd.TabIndex = 29;
			this.txtdtdd.Text = "";
			this.txtdtdd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtdtdd_KeyDown);
			this.txtdtdd.Leave += new System.EventHandler(this.txtdtdd_Leave);
			this.txtdtdd.Enter += new System.EventHandler(this.txtdtdd_Enter);
			// 
			// label28
			// 
			this.label28.BackColor = System.Drawing.SystemColors.Control;
			this.label28.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label28.Location = new System.Drawing.Point(600, 139);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(40, 16);
			this.label28.TabIndex = 100;
			this.label28.Text = "Email ";
			// 
			// label29
			// 
			this.label29.BackColor = System.Drawing.SystemColors.Control;
			this.label29.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label29.Location = new System.Drawing.Point(282, 258);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(72, 16);
			this.label29.TabIndex = 102;
			this.label29.Text = "Loại Hẹn ";
			// 
			// cmbloaihen
			// 
			this.cmbloaihen.BackColor = System.Drawing.Color.WhiteSmoke;
			this.cmbloaihen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbloaihen.Location = new System.Drawing.Point(368, 255);
			this.cmbloaihen.Name = "cmbloaihen";
			this.cmbloaihen.Size = new System.Drawing.Size(148, 21);
			this.cmbloaihen.TabIndex = 40;
			this.cmbloaihen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbloaihen_KeyDown);
			this.cmbloaihen.SelectedIndexChanged += new System.EventHandler(this.cmbloaihen_SelectedIndexChanged);
			this.cmbloaihen.Leave += new System.EventHandler(this.cmbloaihen_Leave);
			this.cmbloaihen.Enter += new System.EventHandler(this.cmbloaihen_Enter);
			// 
			// mkbngaykham
			// 
			this.mkbngaykham.BackColor = System.Drawing.Color.WhiteSmoke;
			this.mkbngaykham.Location = new System.Drawing.Point(128, 233);
			this.mkbngaykham.Mask = "##/##/####";
			this.mkbngaykham.Name = "mkbngaykham";
			this.mkbngaykham.Size = new System.Drawing.Size(72, 20);
			this.mkbngaykham.TabIndex = 32;
			this.mkbngaykham.Text = "";
			this.mkbngaykham.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mkbngaykham_KeyDown);
			this.mkbngaykham.Leave += new System.EventHandler(this.mkbngaykham_Leave);
			this.mkbngaykham.Validated += new System.EventHandler(this.mkbngaykham_Validated);
			this.mkbngaykham.Enter += new System.EventHandler(this.mkbngaykham_Enter);
			// 
			// mkbngaysinh
			// 
			this.mkbngaysinh.Location = new System.Drawing.Point(464, 46);
			this.mkbngaysinh.Mask = "##/##/####";
			this.mkbngaysinh.Name = "mkbngaysinh";
			this.mkbngaysinh.Size = new System.Drawing.Size(67, 20);
			this.mkbngaysinh.TabIndex = 4;
			this.mkbngaysinh.Text = "";
			this.mkbngaysinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mkbngaysinh_KeyDown);
			this.mkbngaysinh.Leave += new System.EventHandler(this.mkbngaysinh_Leave);
			this.mkbngaysinh.Validated += new System.EventHandler(this.mkbngaysinh_Validated);
			this.mkbngaysinh.Enter += new System.EventHandler(this.mkbngaysinh_Enter);
			// 
			// lbphongkham
			// 
			this.lbphongkham.Location = new System.Drawing.Point(576, 192);
			this.lbphongkham.Name = "lbphongkham";
			this.lbphongkham.Size = new System.Drawing.Size(136, 23);
			this.lbphongkham.TabIndex = 112;
			this.lbphongkham.Visible = false;
			// 
			// txtphongkham
			// 
			this.txtphongkham.BackColor = System.Drawing.Color.WhiteSmoke;
			this.txtphongkham.Location = new System.Drawing.Point(576, 233);
			this.txtphongkham.Name = "txtphongkham";
			this.txtphongkham.Size = new System.Drawing.Size(36, 20);
			this.txtphongkham.TabIndex = 35;
			this.txtphongkham.Text = "";
			this.txtphongkham.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtphongkham_KeyDown);
			this.txtphongkham.Validated += new System.EventHandler(this.txtphongkham_Validated);
			this.txtphongkham.Leave += new System.EventHandler(this.txtphongkham_Leave);
			this.txtphongkham.Enter += new System.EventHandler(this.txtphongkham_Enter);
			// 
			// txttinhtrang
			// 
			this.txttinhtrang.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txttinhtrang.Location = new System.Drawing.Point(128, 255);
			this.txttinhtrang.Name = "txttinhtrang";
			this.txttinhtrang.Size = new System.Drawing.Size(35, 20);
			this.txttinhtrang.TabIndex = 37;
			this.txttinhtrang.Text = "";
			this.txttinhtrang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txttinhtrang_KeyDown);
			this.txttinhtrang.Validated += new System.EventHandler(this.txttinhtrang_Validated);
			this.txttinhtrang.Leave += new System.EventHandler(this.txttinhtrang_Leave);
			this.txttinhtrang.Enter += new System.EventHandler(this.txttinhtrang_Enter);
			// 
			// txtbacsi
			// 
			this.txtbacsi.BackColor = System.Drawing.Color.WhiteSmoke;
			this.txtbacsi.Location = new System.Drawing.Point(576, 256);
			this.txtbacsi.Name = "txtbacsi";
			this.txtbacsi.Size = new System.Drawing.Size(36, 20);
			this.txtbacsi.TabIndex = 41;
			this.txtbacsi.Text = "";
			this.txtbacsi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbacsi_KeyDown);
			this.txtbacsi.Validated += new System.EventHandler(this.txtbacsi_Validated);
			this.txtbacsi.Leave += new System.EventHandler(this.txtbacsi_Leave);
			this.txtbacsi.Enter += new System.EventHandler(this.txtbacsi_Enter);
			// 
			// txtloaihen
			// 
			this.txtloaihen.BackColor = System.Drawing.Color.WhiteSmoke;
			this.txtloaihen.Location = new System.Drawing.Point(331, 255);
			this.txtloaihen.Name = "txtloaihen";
			this.txtloaihen.Size = new System.Drawing.Size(35, 20);
			this.txtloaihen.TabIndex = 39;
			this.txtloaihen.Text = "";
			this.txtloaihen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtloaihen_KeyDown);
			this.txtloaihen.Validated += new System.EventHandler(this.txtloaihen_Validated);
			this.txtloaihen.Leave += new System.EventHandler(this.txtloaihen_Leave);
			this.txtloaihen.Enter += new System.EventHandler(this.txtloaihen_Enter);
			// 
			// label36
			// 
			this.label36.BackColor = System.Drawing.SystemColors.Control;
			this.label36.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label36.Location = new System.Drawing.Point(64, 212);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(72, 16);
			this.label36.TabIndex = 113;
			this.label36.Text = "Số thứ tự     ";
			// 
			// txtsothutu
			// 
			this.txtsothutu.BackColor = System.Drawing.Color.WhiteSmoke;
			this.txtsothutu.Enabled = false;
			this.txtsothutu.Location = new System.Drawing.Point(128, 211);
			this.txtsothutu.Name = "txtsothutu";
			this.txtsothutu.Size = new System.Drawing.Size(30, 20);
			this.txtsothutu.TabIndex = 114;
			this.txtsothutu.Text = "";
			// 
			// dataGrid1
			// 
			this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid1.CaptionBackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.FlatMode = true;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(32, 456);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(656, 112);
			this.dataGrid1.TabIndex = 116;
			// 
			// txtid
			// 
			this.txtid.Location = new System.Drawing.Point(168, 211);
			this.txtid.Name = "txtid";
			this.txtid.Size = new System.Drawing.Size(48, 20);
			this.txtid.TabIndex = 117;
			this.txtid.Text = "";
			this.txtid.Visible = false;
			// 
			// lbmanhom
			// 
			this.lbmanhom.Location = new System.Drawing.Point(24, 320);
			this.lbmanhom.Name = "lbmanhom";
			this.lbmanhom.TabIndex = 118;
			this.lbmanhom.Visible = false;
			// 
			// lb_maql
			// 
			this.lb_maql.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.lb_maql.Location = new System.Drawing.Point(232, 8);
			this.lb_maql.Name = "lb_maql";
			this.lb_maql.TabIndex = 119;
			this.lb_maql.Visible = false;
			// 
			// dataGrid2
			// 
			this.dataGrid2.CaptionVisible = false;
			this.dataGrid2.DataMember = "";
			this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid2.Location = new System.Drawing.Point(8, 456);
			this.dataGrid2.Name = "dataGrid2";
			this.dataGrid2.Size = new System.Drawing.Size(784, 96);
			this.dataGrid2.TabIndex = 120;
			this.dataGrid2.Visible = false;
			// 
			// cmdprint
			// 
			this.cmdprint.BackColor = System.Drawing.SystemColors.Desktop;
			this.cmdprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(163)));
			this.cmdprint.ForeColor = System.Drawing.Color.White;
			this.cmdprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdprint.Location = new System.Drawing.Point(402, 408);
			this.cmdprint.Name = "cmdprint";
			this.cmdprint.Size = new System.Drawing.Size(76, 33);
			this.cmdprint.TabIndex = 46;
			this.cmdprint.Text = "In Phiếu";
			this.cmdprint.Click += new System.EventHandler(this.cmdprint_Click);
			// 
			// DANGKYKHAM
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(802, 573);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.cmdprint,
																		  this.dataGrid2,
																		  this.lb_maql,
																		  this.dataGrid1,
																		  this.lbmanhom,
																		  this.txtid,
																		  this.cmbtqpxa,
																		  this.txtsothutu,
																		  this.label36,
																		  this.txtloaihen,
																		  this.txtbacsi,
																		  this.txttinhtrang,
																		  this.txtphongkham,
																		  this.lbphongkham,
																		  this.mkbngaysinh,
																		  this.mkbngaykham,
																		  this.cmdKetthuc,
																		  this.cmdBoqua,
																		  this.cmdLuu,
																		  this.cmbloaihen,
																		  this.label29,
																		  this.txtemail,
																		  this.txtnoilamviec,
																		  this.label28,
																		  this.txtdtdd,
																		  this.label27,
																		  this.txtphuongxa2,
																		  this.label26,
																		  this.cmbphuongxa,
																		  this.txtphuongxa1,
																		  this.cmbquanhuyen,
																		  this.txtquanhuyen2,
																		  this.cmbtinhtp,
																		  this.txttinhtp,
																		  this.label25,
																		  this.txttqpxa,
																		  this.label24,
																		  this.txtsonha,
																		  this.label18,
																		  this.cmbquoctich,
																		  this.txtquoctich,
																		  this.label13,
																		  this.cmbdantoc,
																		  this.txtdantoc,
																		  this.cmbnghenghiep,
																		  this.txtnghenghiep,
																		  this.cmbtuoi,
																		  this.txtmabn2,
																		  this.txtthonpho,
																		  this.label23,
																		  this.label22,
																		  this.txtghichu,
																		  this.label21,
																		  this.cmbphongkham,
																		  this.cmbbacsi,
																		  this.label20,
																		  this.cmbtinhtrang,
																		  this.label19,
																		  this.label17,
																		  this.cmbthoigian,
																		  this.label16,
																		  this.txtgiokham,
																		  this.label15,
																		  this.label14,
																		  this.txtdtcq,
																		  this.label12,
																		  this.label11,
																		  this.txtdtnha,
																		  this.label10,
																		  this.txtquanhuyen1,
																		  this.label9,
																		  this.label8,
																		  this.txttuoi,
																		  this.label7,
																		  this.txtmabn1,
																		  this.label6,
																		  this.cmbgioitinh,
																		  this.label5,
																		  this.txtnamsinh,
																		  this.label4,
																		  this.label3,
																		  this.txthoten,
																		  this.label2,
																		  this.label1,
																		  this.lbHANHCHINH});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "DANGKYKHAM";
			this.Text = "Đăng ký khám";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.DANGKYKHAM_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void cmdKetthuc_Click(object sender, System.EventArgs e)
		{				
			this.Close();			
		}

		private void DANGKYKHAM_Load(object sender, System.EventArgs e)
		{			
			LoadCombo_dm();				
			LoadText();	            		
			Load_maxid();
			Load_stt();
			Load_hand();
			Load_ttcuochen();	
			if(moi_ == false)
			{Load_sothutu();}
			if(txtsothutu.TextLength>0)
				stt=txtsothutu.Text.ToString();
			if(txtbacsi.TextLength>0)
				mabacsi_=txtbacsi.Text.ToString();
			if(moi_==true)
			{	
				mkbngaykham.Enabled=false;				
				txtgiokham.Enabled=false;
//				txtphongkham.Enabled=false;
//				cmbphongkham.Enabled=false;
			}
			else
			{}	
//			if()
		}

		private void LoadText()
		{
			if(mabn_==null )
			{
			txtmabn1.Text=DateTime.Now.Year.ToString().Substring(2,2);
			txtmabn1.Focus();			
			}
			else
			{
				get_btdbn(mabn_);
			}
		}

		private void txtmabn1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void txtmabn2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void txtsokham_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void txthoten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{		
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void mkbngaysinh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void txtnamsinh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void txttuoi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{f4}");
		}

		private void cmbtuoi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{		
			if(e.KeyCode.ToString()=="Enter") 
			{			
				SendKeys.Send("{Tab}{f4}");					
			}			
		}

		private void cmbgioitinh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void txtnghenghiep_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{f4}");
		}

		private void cmbnghenghiep_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) 
			{
				txtdantoc.Focus();				
			}
		}

		private void txtdantoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void cmbdantoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void txtquoctich_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{f4}");
		}

		private void cmbquoctich_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void txtsonha_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void txtthonpho_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void txttqpxa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{			
			if(e.KeyCode==Keys.Enter) 
			{
				if(txttqpxa.TextLength!=0)
				{
					//dataGrid1.DataSource=k.get_viettatbtdpxa(txttqpxa.Text.ToString()).Tables[0];
					cmbtqpxa.DisplayMember="TEN";
					cmbtqpxa.ValueMember="MAPHUONGXA";
					cmbtqpxa.DataSource=k.get_viettatbtdpxa(txttqpxa.Text.ToString()).Tables[0];
					if(cmbtqpxa.Items.Count==1)
					{
						string s=cmbtqpxa.SelectedValue.ToString();
						cmbtinhtp.SelectedValue=s.Substring(0,3);
						cmbquanhuyen.SelectedValue=s.Substring(0,5);
						cmbphuongxa.SelectedValue=s;
						txtnoilamviec.Focus();
					}
					else
					{
						if(cmbtqpxa.Items.Count>1)
						{
							cmbtqpxa.Focus();
							SendKeys.Send("{f4}");
						}
						else
						{
							txttqpxa.Clear();
							txttinhtp.Focus();							
						}
					}
				}
				else
				{
					txttinhtp.Focus();
				}
			}					
		}

		private void cmbtqpxa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				try
				{
					if (cmbtqpxa.SelectedIndex==-1)
						cmbtqpxa.SelectedIndex=0;
					cmbtinhtp.SelectedValue=cmbtinhtp.SelectedValue.ToString().Substring(0,3);
					cmbquanhuyen.SelectedValue=cmbquanhuyen.SelectedValue.ToString().Substring(0,5);
					cmbphuongxa.SelectedValue=cmbphuongxa.SelectedValue.ToString();
					txtnoilamviec.Focus();					
					return;
				}
				catch{}
				txttqpxa.Text="";
				SendKeys.Send("{Tab}");
			}		
		}

		private void txttinhtp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{f4}");
		}

		private void cmbtinhtp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) txtquanhuyen2.Focus();
		}

		private void txtquanhuyen1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void txtquanhuyen2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{f4}");
		}

		private void cmbquanhuyen_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void txtphuongxa1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void txtphuongxa2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{f4}");
		}

		private void cmbphuongxa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void txtnoilamviec_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void txtdtnha_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void txtdtdd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void txtdtcq_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void txtemail_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void mkbngaykham_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{f4}");
		}

		private void txtgiokham_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void txtthoigian_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void cmbloaihen_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void cmbtinhtrang_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void cmbbacsi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void cmbphongkham_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void txtghichu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void cmdLuu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void txtmabn2_Validated(object sender, System.EventArgs e)
		{
			if(txtmabn2.TextLength!=0 && txtmabn1.TextLength==2)
			{
				txtmabn2.Text=txtmabn2.Text.PadLeft(6,'0');		
				Load_mabn(txtmabn1.Text.ToString().Trim()+txtmabn2.Text.ToString().Trim());
			}		
			else
			{
				txtmabn1.Text="";
			}
		}

		private void LoadCombo_dm()
		{
			cmbtuoi.SelectedIndex=0;
			Load_cmbgioitinh();
			Load_cmbquoctich();
			Load_cmbnghenghiep();	
			Load_cmbdantoc();
			Load_cmbtinh();
			Load_cmbloaihen();	
			Load_cmbbacsi();
			Load_cmbtinhtrang();
			Load_cmbphongkham();					
		}

		private void cmbnghenghiep_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				txtnghenghiep.Text=cmbnghenghiep.SelectedValue.ToString();
			}
			catch{txtnghenghiep.Text="";}
		}

		private void txtnghenghiep_Validated(object sender, System.EventArgs e)
		{
			try
			{
				cmbnghenghiep.SelectedValue=txtnghenghiep.Text;
			}
			catch{}
		}

		private void cmbdantoc_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				txtdantoc.Text=cmbdantoc.SelectedValue.ToString().Trim();
				if(txtdantoc.Text=="55")
				{
					txtquoctich.Enabled=true;
					cmbquoctich.Enabled=true;				
				}
				else
				{
					txtquoctich.Enabled=false;
					cmbquoctich.Enabled=false;				
				}

			}
			catch
			{txtdantoc.Text="";}
		}

		private void txtdantoc_Validated(object sender, System.EventArgs e)
		{
			try
			{cmbdantoc.SelectedValue=txtdantoc.Text;}
			catch
			{}
		}

		private void cmbtinhtp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				txttinhtp.Text=cmbtinhtp.SelectedValue.ToString();
				txtquanhuyen1.Text=cmbtinhtp.SelectedValue.ToString();
				Load_cmbquanhuyen();
			}
			catch(Exception caught)
			{
				MessageBox.Show(caught.Message);
				txttinhtp.Text="";
			}
		}

		private void txttinhtp_Validated(object sender, System.EventArgs e)
		{
			try
			{cmbtinhtp.SelectedValue=txttinhtp.Text;}
			catch
			{}
		}

		private void Load_cmbquanhuyen()
		{
			//DataSet Ds = new DataSet();
			//Ds = k.Get_btdquan(cmbtinhtp.SelectedValue.ToString());
			//if(Ds.Tables[0].Rows.Count==0)
			//	MessageBox.Show("Nothing");	
			if(cmbtinhtp.SelectedIndex!=0)
			{
				cmbquanhuyen.DisplayMember="TENQUAN";
				cmbquanhuyen.ValueMember="MAQU";			
				cmbquanhuyen.DataSource=k.Get_btdquan(cmbtinhtp.SelectedValue.ToString()).Tables[0];
				cmbquanhuyen.SelectedIndex=0;
			}
		}

		private void cmbquanhuyen_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtquanhuyen2.Text=cmbquanhuyen.SelectedValue.ToString().Substring(3,2);
			txtphuongxa1.Text=cmbquanhuyen.SelectedValue.ToString();
			Load_cmbphuongxa();
		}

		private void txtquanhuyen2_Validated(object sender, System.EventArgs e)
		{
			try
			{
				cmbquanhuyen.SelectedValue = txtquanhuyen1.Text.ToString().Trim()+txtquanhuyen2.Text.ToString().Trim();
			}
			catch{}
		}

		private void Load_cmbphuongxa()
		{
			cmbphuongxa.DisplayMember="TENPXA";
			cmbphuongxa.ValueMember="MAPHUONGXA";
			cmbphuongxa.DataSource= k.Get_btdpxa(cmbquanhuyen.SelectedValue.ToString()).Tables[0];
			cmbphuongxa.SelectedIndex=0;
		}

		private void cmbphuongxa_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtphuongxa2.Text=cmbphuongxa.SelectedValue.ToString().Substring(5,2);
		}

		private void txtphuongxa2_Validated(object sender, System.EventArgs e)
		{
			try
			{
				cmbphuongxa.SelectedValue=txtphuongxa1.Text.ToString().Trim()+txtphuongxa2.Text.ToString().Trim();
			}
			catch{}
		}

		private void cmbphongkham_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				txtphongkham.Text=cmbphongkham.SelectedValue.ToString();			
			}
			catch{}
			Load_sothutu();
		}

		private void txtphongkham_Validated(object sender, System.EventArgs e)
		{
			try
			{
				cmbphongkham.SelectedValue=txtphongkham.Text.Trim();
			}
			catch{}
		}

		private void cmbtinhtrang_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txttinhtrang.Text=cmbtinhtrang.SelectedValue.ToString();
		}

		private void txttinhtrang_Validated(object sender, System.EventArgs e)
		{
			try
			{
				cmbtinhtrang.SelectedValue=txttinhtrang.Text.Trim();
			}
			catch{}
		}

		private void cmbbacsi_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				txtbacsi.Text=cmbbacsi.SelectedValue.ToString();
			}
			catch{}
		}

		private void txtbacsi_Validated(object sender, System.EventArgs e)
		{
			try
			{
				cmbbacsi.SelectedValue=txtbacsi.Text.Trim();
			}
			catch{}
		}

		private void cmbloaihen_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtloaihen.Text=cmbloaihen.SelectedValue.ToString();
		}

		private void txtloaihen_Validated(object sender, System.EventArgs e)
		{
			try
			{
				cmbloaihen.SelectedValue=txtloaihen.Text.Trim();
			}
			catch
			{}
		}

		private void txtquoctich_Validated(object sender, System.EventArgs e)
		{
			try
			{
				cmbquoctich.SelectedValue= txtquoctich.Text;
			}
			catch
			{}
		}

		private void cmbquoctich_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtquoctich.Text=cmbquoctich.SelectedValue.ToString();
		}

		private void Load_mabn(string mabn)
		{	
			try
			{
				DataTable datatable = k.get_btdbn(mabn).Tables[0];
				if(datatable.Rows.Count >0)
				{
					txthoten.Text= datatable.Rows[0]["HOTEN"].ToString();
					txtnamsinh.Text=datatable.Rows[0]["NAMSINH"].ToString();
					txttuoi.Text =k.Tinhtuoi(txtnamsinh.Text.ToString().Trim()).ToString();				
					cmbgioitinh.SelectedValue=datatable.Rows[0]["PHAI"].ToString();
					if(datatable.Rows[0]["NGAYSINH"].ToString()!="")
					{
						mkbngaysinh.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(datatable.Rows[0]["NGAYSINH"].ToString()));// Co sai khong ??	
						string tuoi = k.Tinhthangngay(mkbngaysinh.Text.ToString().Substring(0,10).Trim());
						if(tuoi!="0000")
						{
							txttuoi.Text=tuoi.Substring(0,3).ToString();
							cmbtuoi.SelectedIndex=int.Parse(tuoi.Substring(3,1).ToString().Trim());
						}
					}
					cmbgioitinh.SelectedValue =int.Parse(datatable.Rows[0]["PHAI"].ToString().Trim());
					cmbnghenghiep.SelectedValue=datatable.Rows[0]["MANN"].ToString();
					cmbdantoc.SelectedValue=datatable.Rows[0]["MADANTOC"].ToString();
					if(cmbquoctich.Enabled)
					{
						//DataTable tbb= k.Get_idnuoc(mabn).Tables[0];
						DataTable tbb =k.get_data("select * from nuocngoai where mabn='"+mabn+"'").Tables[0];
						//MessageBox.Show(tbb.Rows[0]["ID_NUOC"].ToString());
						if(tbb.Rows.Count >0)
						{
							//MessageBox.Show(tb.Rows[0]["ID_NUOC"].ToString());
							cmbquoctich.SelectedValue= tbb.Rows[0]["ID_NUOC"].ToString();//row["ID_NUOC"].ToString();
						}
					}
					txtsonha.Text=datatable.Rows[0]["SONHA"].ToString();
					txtthonpho.Text=datatable.Rows[0]["THON"].ToString();				
					cmbtinhtp.SelectedValue=datatable.Rows[0]["MATT"].ToString();
					cmbquanhuyen.SelectedValue=datatable.Rows[0]["MAQU"].ToString().Trim();
					cmbphuongxa.SelectedValue=datatable.Rows[0]["MAPHUONGXA"].ToString().Trim();
					txtnoilamviec.Text=datatable.Rows[0]["CHOLAM"].ToString();
					if(MessageBox.Show("Có sửa thông tin hành chánh không ?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)== DialogResult.Yes)
					{
						txthoten.Focus();
						return;
					}
					else
					{
						cmbthoigian.Focus();
						SendKeys.Send("{f4}");
						return;
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void Load_cmbquoctich()
		{
			cmbquoctich.DisplayMember="VIETNAMESE";
			cmbquoctich.ValueMember="MA";
			cmbquoctich.DataSource=k.get_dmquocgia().Tables[0];
			cmbquoctich.SelectedValue="VN";
		}

		private void Load_cmbgioitinh()
		{
			cmbgioitinh.DisplayMember="TEN";
			cmbgioitinh.ValueMember="MA";
			cmbgioitinh.DataSource=k.get_dmphai().Tables[0];			
		}

		private void Load_cmbnghenghiep()
		{
			cmbnghenghiep.DisplayMember="TENNN";
			cmbnghenghiep.ValueMember="MANN";
			cmbnghenghiep.DataSource=k.Get_btdnn().Tables[0];
			cmbnghenghiep.SelectedIndex=0;
		}

		private void Load_cmbdantoc()
		{
			cmbdantoc.DisplayMember="DANTOC";
			cmbdantoc.ValueMember="MADANTOC";
			cmbdantoc.DataSource= k.Get_btddt().Tables[0];
			cmbdantoc.SelectedValue=25;
		}

		private void Load_cmbtinh()
		{			
			cmbtinhtp.DisplayMember="TENTT";
			cmbtinhtp.ValueMember="MATT";
			cmbtinhtp.DataSource=k.Get_btdtt().Tables[0];
			cmbtinhtp.SelectedIndex=1;
			cmbtinhtp.SelectedValue =701;//Phan nay ta lay ma theo mabvien
			//cmbtinhtp.SelectedValue=k.Mabv.Substring(0,3);			
		}

		private void Load_cmbloaihen()
		{
			cmbloaihen.DisplayMember="TENHK";
			cmbloaihen.ValueMember="MAHK";
			cmbloaihen.DataSource=k.Get_Henkham().Tables[0];
			cmbloaihen.SelectedIndex=0;
		}

		private void Load_cmbbacsi()
		{
			cmbbacsi.DisplayMember="HOTEN";
			cmbbacsi.ValueMember="MA";
			cmbbacsi.DataSource=k.Get_dmbacsi().Tables[0];			
			cmbbacsi.SelectedValue=lbmanhom.Text;			
		}

		private void Load_cmbtinhtrang()
		{
			cmbtinhtrang.DisplayMember="TENTT";
			cmbtinhtrang.ValueMember="MATT";
			cmbtinhtrang.DataSource=k.Get_Tinhtrang().Tables[0];
			cmbtinhtrang.SelectedIndex=0;
		}

		private void Load_cmbphongkham()
		{
			cmbphongkham.DisplayMember="TENKP";
			cmbphongkham.ValueMember="MAKP";
			DataSet Dss = k.Get_Khoaphong();			
			cmbphongkham.DataSource=Dss.Tables[0];
			cmbphongkham.SelectedIndex=-1;
			txtphongkham.Clear();
			if(lbphongkham.Text.Length <=0)
			{
				txtphongkham.Enabled=true;
				cmbphongkham.Enabled=true;
			}
			else
			{
				txtphongkham.Enabled=false;
				cmbphongkham.Enabled=false;
				DataRow[] r=Dss.Tables[0].Select("TENKP='"+lbphongkham.Text.Trim()+"'");
				if(r.Length>0)
				{
					lbphongkham.Text=r[0]["MAKP"].ToString().Trim();			
				}
				cmbphongkham.SelectedValue=lbphongkham.Text;
			}			
		}

		private void txttinhtrang_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)SendKeys.Send("{Tab}{f4}");
		}

		private void txtloaihen_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)SendKeys.Send("{Tab}{f4}");
		}

		private void txtbacsi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)SendKeys.Send("{Tab}{f4}");
		}

		private void txtphongkham_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)SendKeys.Send("{Tab}{f4}");
		}

		private void txtnamsinh_Validated(object sender, System.EventArgs e)
		{
			if(txtnamsinh.TextLength!=0)
			{
				if(txtnamsinh.TextLength!=4)
				{
					MessageBox.Show("Nhập năm sinh không phù hợp","Thông Báo");
					txtnamsinh.Focus();
					return;
				}
				if(int.Parse(txtnamsinh.Text.Trim())>int.Parse(DateTime.Now.Year.ToString()))
				{
					MessageBox.Show("Nhập năm sinh không phù hợp","Thông Báo");
					txtnamsinh.Focus();
					return;
				}
				int i=int.Parse(DateTime.Now.Year.ToString())-int.Parse(txtnamsinh.Text.ToString().Trim());
				if(i==0)
				{
					MessageBox.Show("Yêu cầu nhập tuổi vào","Thông Báo");
					txttuoi.Focus();
					return;
				}
				else
				{					
					if(i>120)
					{
						MessageBox.Show("Nhập năm sinh không phù hợp","Thông Báo");
						txtnamsinh.Focus();
						return;
					}
					else
					{						
						txttuoi.Text=i.ToString();
						cmbtuoi.SelectedIndex=0;
						cmbgioitinh.Focus();
						SendKeys.Send("{f4}");
					}
				}
				DataSet Ds=k.Get_benhnhan(txthoten.Text.ToString().Trim(),txtnamsinh.Text.ToString().Trim());
				if(Ds.Tables[0].Rows.Count >0)
				{
					DSBENHNHAN frmdsbn = new DSBENHNHAN(this,Ds);
					frmdsbn.ShowDialog();
					
					if(frmdsbn.mabncu!="")
					{
						Load_mabn(frmdsbn.mabncu.ToString().Trim());
					}
					else
					{
						cmbgioitinh.Focus();
						SendKeys.Send("{f4}");
					}
				}
			}
 	    }

		private void cmbtuoi_Validated(object sender, System.EventArgs e)
		{
			if(txttuoi.TextLength!=0)
			{
				if(cmbtuoi.Text=="Tháng" && int.Parse(txttuoi.Text.ToString().Trim())>12)
				{
					int tuoi=Int16.Parse(txttuoi.Text.ToString().Trim())/12;
					tuoi =int.Parse(DateTime.Now.Year.ToString())-tuoi;
					txtnamsinh.Text=tuoi.ToString();
				}

				if(cmbtuoi.Text=="Tháng" && int.Parse(txttuoi.Text.ToString().Trim())<12)
				{
					txtnamsinh.Text=DateTime.Now.Year.ToString();
				}
			
				if(cmbtuoi.Text=="Tuổi" && txttuoi.TextLength>0)
				{
					int t = int.Parse(DateTime.Now.Year.ToString())-int.Parse(txttuoi.Text.ToString().Trim());
					txtnamsinh.Text=t.ToString();
				}
			}
			
		}

		private void txttuoi_Validated(object sender, System.EventArgs e)
		{
			if(txttuoi.TextLength>0)
			{
				if(int.Parse(txttuoi.Text.ToString())>120 || int.Parse(txttuoi.Text.ToString())==0)
				{
					MessageBox.Show("Nhập tuổi không phù hợp","Thông Báo");
					txttuoi.Focus();
					return;
				}				
			}
		}

		private void mkbngaysinh_Validated(object sender, System.EventArgs e)
		{
			if(mkbngaysinh.TextLength!=0)
			{				
				if(!k.checkngay(mkbngaysinh.Text.ToString()))
				{
					MessageBox.Show("Nhập định dạng ngày không đúng","Thông báo");
					mkbngaysinh.Focus();
					return;
				}
				else
				{
					DateTime ngaysinh = DateTime.Parse(mkbngaysinh.Text.ToString());
					if(ngaysinh>DateTime.Now.Date)
					{
						MessageBox.Show("Nhập ngày sinh không phù hợp","Thông Báo");
						mkbngaysinh.Focus();
						return;
					}
				}
				Tinhngaythang();                
			}
			else
			{
				if(txthoten.TextLength==0)
				{
					txthoten.Focus();
					return;
				}
			}
		}

		private void Tinhngaythang()
		{
			int namsinh = int.Parse(mkbngaysinh.Text.Substring(6,4).ToString());
			int thangsinh = int.Parse(mkbngaysinh.Text.Substring(3,2).ToString());
			int ngaysinh = int.Parse(mkbngaysinh.Text.Substring(0,2).ToString());
			txtnamsinh.Text=mkbngaysinh.Text.Substring(6,4).ToString();
			int tuoi = int.Parse(DateTime.Now.Year.ToString())-int.Parse(mkbngaysinh.Text.Substring(6,4).ToString());
			if(tuoi>=1)
			{
				txttuoi.Text=tuoi.ToString();
				cmbtuoi.SelectedIndex=0;
				cmbgioitinh.Focus();
				SendKeys.Send("{f4}");
			}else
			{
				int thang = int.Parse(DateTime.Now.Month.ToString())-thangsinh;
				if(thang>=1)
				{
					txttuoi.Text=thang.ToString();
					cmbtuoi.SelectedIndex=1;
					cmbgioitinh.Focus();
					SendKeys.Send("{f4}");
				}else
				{
					int ngay = int.Parse(DateTime.Now.Day.ToString())-ngaysinh;
					if(ngay>=1)
					{
						txttuoi.Text=ngay.ToString();
						cmbtuoi.SelectedIndex=2;
						cmbgioitinh.Focus();
						SendKeys.Send("{f4}");
					}
				}
			}
		}

		private void cmbgioitinh_Validated(object sender, System.EventArgs e)
		{
			txtnghenghiep.Focus();
		}

		private void txtmabn1_Validated(object sender, System.EventArgs e)
		{
			if(txtmabn1.TextLength!=2)		txtmabn1.Text="00";			
		}

		private void Load_stt()
		{		
			string buoi;
			if(int.Parse(txtgiokham.Text.Substring(0,2).ToString())>12)
				buoi ="C";
			else
				buoi = "S";

			DataSet Ds = k.Loadgio_stt();				
			DataRow[] r=Ds.Tables[0].Select("Gio = '"+txtgiokham.Text.Trim()+"'");
			if(r.Length>0)
			{
				txtsothutu.Text = buoi+r[0]["Sothutu"].ToString();
			}
		}

		private void cmbtqpxa_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{                
				cmbtinhtp.SelectedValue=cmbtqpxa.SelectedValue.ToString().Substring(0,3);
				cmbquanhuyen.SelectedValue=cmbtqpxa.SelectedValue.ToString().Substring(0,5);
				cmbphuongxa.SelectedValue=cmbtqpxa.SelectedValue.ToString();
			}catch(Exception caught)
			{
				MessageBox.Show(caught.Message);
			}
		}
		
		private void Load_maxid()
		{
			txtid.Text=k.get_maxid().ToString();
		}

		private bool CheckData()
		{
			if(txthoten.TextLength==0)
			{
				MessageBox.Show("Nhập họ tên","Thông Báo");
				return  false;
			}
			if(txttuoi.TextLength==0)
			{
				MessageBox.Show("Nhập tuổi","Thông Báo");
				return  false;			
			}
			if(cmbthoigian.Text=="")
			{
				MessageBox.Show("Chọn thời gian khám","Thông Báo");
				return  false;	
			}
			if(cmbgioitinh.Text=="")
			{
				MessageBox.Show("Chọn giới tính","Thông Báo");
				return  false;	
			}
			if(cmbnghenghiep.Text=="" || txtnghenghiep.TextLength <=0)
			{
				MessageBox.Show("Nhập nghề nghiệp","Thông Báo");
				return false;
			}
			if(cmbbacsi.Text=="" || txtbacsi.TextLength <=0)
			{
				MessageBox.Show("Nhập Bác Sĩ","Thông Báo");
				return false;
			}
			if(cmbphongkham.Text=="" || txtphongkham.TextLength <=0)
			{
				MessageBox.Show("Nhập Phòng Khám","Thông Báo");
				return false;
			}
			return true;
		}

		private void cmdBoqua_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void cmdLuu_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(!CheckData()) return;
				if(!kt_trungBS()) return ;
				if(txtmabn2.TextLength==0) txtmabn1.Text="";
				string maquanhuyen = txtquanhuyen1.Text.ToString().Trim()+txtquanhuyen2.Text.ToString().Trim();
				string maphuongxa =txtphuongxa1.Text.ToString().Trim()+txtphuongxa2.Text.ToString().Trim();

				k.ins_benhnhan(txtmabn1.Text.ToString()+txtmabn2.Text.ToString(),txthoten.Text.ToString(),
					mkbngaysinh.Text.ToString(),txtnamsinh.Text.ToString(),
					int.Parse(cmbgioitinh.SelectedValue.ToString()),cmbnghenghiep.SelectedValue.ToString(),
					cmbdantoc.SelectedValue.ToString(),txtsonha.Text.ToString(),txtthonpho.Text.ToString(),
					txtnoilamviec.Text.ToString(),cmbtinhtp.SelectedValue.ToString(),maquanhuyen,
					maphuongxa,txtdtnha.Text.ToString(),txtdtcq.Text.ToString(),
					txtdtdd.Text.ToString(),txtemail.Text.ToString(),txtid.Text.ToString());
				k.ins_khambenh(txtmabn1.Text.ToString()+txtmabn2.Text.ToString(),mkbngaykham.Text.ToString(),
					txtgiokham.Text.ToString(),cmbthoigian.Text.ToString(),cmbphongkham.SelectedValue.ToString(),
					cmbloaihen.SelectedValue.ToString(),cmbtinhtrang.SelectedValue.ToString(),
					cmbbacsi.SelectedValue.ToString(),txtghichu.Text.ToString(),txtsothutu.Text.Remove(0,1),
					txtid.Text);									
				cmdLuu.Enabled=false;
				cmdBoqua.Enabled=false;
				cmdKetthuc.Focus();			
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message,"Lưu",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void txthoten_Leave(object sender, System.EventArgs e)
		{
			txthoten.BackColor = Color.White;
		}

		private void txthoten_Enter(object sender, System.EventArgs e)
		{
			txthoten.BackColor=Color.LightYellow;
		}

		private void mkbngaysinh_Enter(object sender, System.EventArgs e)
		{
			mkbngaysinh.BackColor = Color.LightYellow;
		}

		private void mkbngaysinh_Leave(object sender, System.EventArgs e)
		{
			mkbngaysinh.BackColor = Color.White;
		}

		private void txtmabn1_Leave(object sender, System.EventArgs e)
		{
			txtmabn1.BackColor=Color.White;
		}

		private void txtmabn1_Enter(object sender, System.EventArgs e)
		{
			txtmabn1.BackColor=Color.LightYellow;
		}

		private void txtmabn2_Enter(object sender, System.EventArgs e)
		{
			txtmabn2.BackColor=Color.LightYellow;
		}

		private void txtmabn2_Leave(object sender, System.EventArgs e)
		{
			txtmabn2.BackColor=Color.White;
		}

		private void txtnamsinh_Leave(object sender, System.EventArgs e)
		{
			txtnamsinh.BackColor=Color.White;
		}

		private void txtnamsinh_Enter(object sender, System.EventArgs e)
		{
			txtnamsinh.BackColor=Color.LightYellow;
		}

		private void txttuoi_Leave(object sender, System.EventArgs e)
		{
			txttuoi.BackColor=Color.White;
		}

		private void txttuoi_Enter(object sender, System.EventArgs e)
		{
			txttuoi.BackColor=Color.LightYellow;
		}

		private void cmbtuoi_Enter(object sender, System.EventArgs e)
		{
			cmbtuoi.BackColor=Color.LightYellow;
		}

		private void cmbtuoi_Leave(object sender, System.EventArgs e)
		{
			cmbtuoi.BackColor=Color.White;
		}

		private void cmbgioitinh_Leave(object sender, System.EventArgs e)
		{
			cmbgioitinh.BackColor=Color.White;
		}

		private void cmbgioitinh_Enter(object sender, System.EventArgs e)
		{
			cmbgioitinh.BackColor=Color.LightYellow;
		}

		private void txtnghenghiep_Leave(object sender, System.EventArgs e)
		{
			txtnghenghiep.BackColor=Color.White;
		}

		private void txtnghenghiep_Enter(object sender, System.EventArgs e)
		{
			txtnghenghiep.BackColor=Color.LightYellow;
		}

		private void cmbnghenghiep_Leave(object sender, System.EventArgs e)
		{
			cmbnghenghiep.BackColor=Color.White;
		}

		private void cmbnghenghiep_Enter(object sender, System.EventArgs e)
		{
			cmbnghenghiep.BackColor=Color.LightYellow;
		}

		private void txtdantoc_Enter(object sender, System.EventArgs e)
		{
			txtdantoc.BackColor=Color.LightYellow;
		}

		private void txtdantoc_Leave(object sender, System.EventArgs e)
		{
			txtdantoc.BackColor=Color.White;
		}

		private void txtquoctich_Leave(object sender, System.EventArgs e)
		{
			txtquoctich.BackColor=Color.White;
		}

		private void txtquoctich_Enter(object sender, System.EventArgs e)
		{
			txtquoctich.BackColor=Color.LightYellow;
		}

		private void cmbquoctich_Enter(object sender, System.EventArgs e)
		{
			cmbquoctich.BackColor=Color.LightYellow;
		}

		private void cmbquoctich_Leave(object sender, System.EventArgs e)
		{
			cmbquoctich.BackColor=Color.White;
		}

		private void txtsonha_Enter(object sender, System.EventArgs e)
		{
			txtsonha.BackColor=Color.LightYellow;
		}

		private void txtsonha_Leave(object sender, System.EventArgs e)
		{
			txtsonha.BackColor=Color.White;
		}

		private void txtquanhuyen2_Leave(object sender, System.EventArgs e)
		{
			txtquanhuyen2.BackColor=Color.White;
		}

		private void txtquanhuyen2_Enter(object sender, System.EventArgs e)
		{
			txtquanhuyen2.BackColor=Color.LightYellow;
		}

		private void cmbquanhuyen_Enter(object sender, System.EventArgs e)
		{
			cmbquanhuyen.BackColor=Color.LightYellow;
		}

		private void cmbquanhuyen_Leave(object sender, System.EventArgs e)
		{
			cmbquanhuyen.BackColor=Color.White;
		}

		private void txtphuongxa1_Enter(object sender, System.EventArgs e)
		{
			txtphuongxa1.BackColor=Color.LightYellow;
		}

		private void txtphuongxa1_Leave(object sender, System.EventArgs e)
		{
			txtphuongxa1.BackColor=Color.White;
		}

		private void txtphuongxa2_Leave(object sender, System.EventArgs e)
		{
			txtphuongxa2.BackColor=Color.White;
		}

		private void txtphuongxa2_Enter(object sender, System.EventArgs e)
		{
			txtphuongxa2.BackColor=Color.LightYellow;
		}

		private void cmbphuongxa_Enter(object sender, System.EventArgs e)
		{
			cmbphuongxa.BackColor=Color.LightYellow;
		}

		private void cmbphuongxa_Leave(object sender, System.EventArgs e)
		{
			cmbphuongxa.BackColor=Color.White;
		}

		private void txtnoilamviec_Leave(object sender, System.EventArgs e)
		{
			txtnoilamviec.BackColor=Color.White;
		}

		private void txtnoilamviec_Enter(object sender, System.EventArgs e)
		{
			txtnoilamviec.BackColor=Color.LightYellow;
		}

		private void txtemail_Enter(object sender, System.EventArgs e)
		{
			txtemail.BackColor=Color.LightYellow;
		}

		private void txtemail_Leave(object sender, System.EventArgs e)
		{
			txtemail.BackColor=Color.White;
		}

		private void txtdtnha_Enter(object sender, System.EventArgs e)
		{
			txtdtnha.BackColor=Color.LightYellow;
		}

		private void txtdtnha_Leave(object sender, System.EventArgs e)
		{
			txtdtnha.BackColor=Color.White;
		}

		private void txtdtdd_Leave(object sender, System.EventArgs e)
		{
			txtdtdd.BackColor=Color.White;
		}

		private void txtdtdd_Enter(object sender, System.EventArgs e)
		{
			txtdtdd.BackColor=Color.LightYellow;
		}

		private void txtdtcq_Leave(object sender, System.EventArgs e)
		{
			txtdtcq.BackColor=Color.White;
		}

		private void txtdtcq_Enter(object sender, System.EventArgs e)
		{
			txtdtcq.BackColor=Color.LightYellow;
		}

		private void txtghichu_Enter(object sender, System.EventArgs e)
		{
			txtghichu.BackColor=Color.LightYellow;
		}

		private void txtghichu_Leave(object sender, System.EventArgs e)
		{
			txtghichu.BackColor=Color.White;
		}

		private void mkbngaykham_Leave(object sender, System.EventArgs e)
		{
			mkbngaykham.BackColor=Color.White;
		}

		private void mkbngaykham_Enter(object sender, System.EventArgs e)
		{
			mkbngaykham.BackColor=Color.LightYellow;
		}

		private void txtgiokham_Enter(object sender, System.EventArgs e)
		{
			txtgiokham.BackColor=Color.LightYellow;
		}

		private void txtgiokham_Leave(object sender, System.EventArgs e)
		{
			txtgiokham.BackColor=Color.White;
		}

		private void txttinhtrang_Leave(object sender, System.EventArgs e)
		{
			txttinhtrang.BackColor=Color.White;
		}

		private void txttinhtrang_Enter(object sender, System.EventArgs e)
		{
			txttinhtrang.BackColor=Color.LightYellow;
		}

		private void cmbtinhtrang_Leave(object sender, System.EventArgs e)
		{
			cmbtinhtrang.BackColor=Color.White;
		}

		private void cmbtinhtrang_Enter(object sender, System.EventArgs e)
		{
			cmbtinhtrang.BackColor=Color.LightYellow;
		}

		private void txtloaihen_Enter(object sender, System.EventArgs e)
		{
			txtloaihen.BackColor=Color.LightYellow;
		}

		private void txtloaihen_Leave(object sender, System.EventArgs e)
		{
			txtloaihen.BackColor=Color.White;
		}

		private void cmbloaihen_Leave(object sender, System.EventArgs e)
		{
			cmbloaihen.BackColor=Color.White;
		}

		private void cmbloaihen_Enter(object sender, System.EventArgs e)
		{
			cmbloaihen.BackColor=Color.LightYellow;
		}

		private void txtbacsi_Enter(object sender, System.EventArgs e)
		{
			txtbacsi.BackColor=Color.LightYellow;
		}

		private void txtbacsi_Leave(object sender, System.EventArgs e)
		{
			txtbacsi.BackColor=Color.White;
		}

		private void cmbbacsi_Leave(object sender, System.EventArgs e)
		{
			cmbbacsi.BackColor=Color.White;
		}

		private void cmbbacsi_Enter(object sender, System.EventArgs e)
		{
			cmbbacsi.BackColor=Color.LightYellow;
		}

		private void cmbphongkham_Enter(object sender, System.EventArgs e)
		{
			cmbphongkham.BackColor=Color.LightYellow;
		}

		private void cmbphongkham_Leave(object sender, System.EventArgs e)
		{
			cmbphongkham.BackColor=Color.White;
		}

		private void txtphongkham_Leave(object sender, System.EventArgs e)
		{
			txtphongkham.BackColor=Color.White;
		}

		private void txtphongkham_Enter(object sender, System.EventArgs e)
		{
			txtphongkham.BackColor=Color.LightYellow;
		}

		private void cmbthoigian_Enter(object sender, System.EventArgs e)
		{
			cmbthoigian.BackColor=Color.LightYellow;
		}

		private void cmbthoigian_Leave(object sender, System.EventArgs e)
		{
			cmbthoigian.BackColor=Color.White;
		}

		private void Load_hand()
		{
			cmdBoqua.Cursor=Cursors.Hand;
			cmdKetthuc.Cursor=Cursors.Hand;
			cmdLuu.Cursor=Cursors.Hand;
			cmdprint.Cursor=Cursors.Hand;
		}

		private void txtthonpho_Leave(object sender, System.EventArgs e)
		{
			txtthonpho.BackColor=Color.White;
		}

		private void txtthonpho_Enter(object sender, System.EventArgs e)
		{
			txtthonpho.BackColor=Color.LightYellow;
		}

		private void txttqpxa_Enter(object sender, System.EventArgs e)
		{
			txttqpxa.BackColor=Color.LightYellow;
		}

		private void txttqpxa_Leave(object sender, System.EventArgs e)
		{
			txttqpxa.BackColor=Color.White;
		}

		private void cmbtqpxa_Leave(object sender, System.EventArgs e)
		{
			cmbtqpxa.BackColor=Color.White;
		}

		private void cmbtqpxa_Enter(object sender, System.EventArgs e)
		{
			cmbtqpxa.BackColor=Color.LightYellow;
		}

		private void txttinhtp_Enter(object sender, System.EventArgs e)
		{
			txttinhtp.BackColor=Color.LightYellow;
		}

		private void txttinhtp_Leave(object sender, System.EventArgs e)
		{
			txttinhtp.BackColor=Color.White;
		}

		private void cmbtinhtp_Leave(object sender, System.EventArgs e)
		{
			cmbtinhtp.BackColor=Color.White;
		}

		private void cmbtinhtp_Enter(object sender, System.EventArgs e)
		{
			cmbtinhtp.BackColor=Color.LightYellow;
		}

		private void cmbdantoc_Enter(object sender, System.EventArgs e)
		{
			cmbdantoc.BackColor=Color.LightYellow;
		}

		private void cmbdantoc_Leave(object sender, System.EventArgs e)
		{
			cmbdantoc.BackColor=Color.White;
		}

		private void Load_ttcuochen()
		{			
			if(lb_maql.Text!="" && moi_==false)
			{
				DataSet Ds = k.get_ttcuochen(int.Parse(lb_maql.Text.ToString()));
				dataGrid2.DataSource=Ds.Tables[0];	
				DataTable tb=Ds.Tables[0];
				if(tb.Rows.Count>0)
				{
					if(tb.Rows[0]["mabn"].ToString()!="")
					{
						txtmabn1.Text = tb.Rows[0]["mabn"].ToString().Substring(0,2);
						txtmabn2.Text = tb.Rows[0]["mabn"].ToString().Remove(0,2);
					}
					else
					{
						txtmabn1.Text = "";
						txtmabn2.Text = "";
					}
					txthoten.Text=tb.Rows[0]["hoten"].ToString();
					txtnamsinh.Text=tb.Rows[0]["namsinh"].ToString();
					cmbgioitinh.SelectedValue=tb.Rows[0]["phai"].ToString();
					cmbnghenghiep.SelectedValue=tb.Rows[0]["mann"].ToString();
					cmbdantoc.SelectedValue=tb.Rows[0]["madantoc"].ToString();
					txtdtcq.Text=tb.Rows[0]["dtcq"].ToString();
					txtdtdd.Text=tb.Rows[0]["dtdd"].ToString();
					txtdtnha.Text=tb.Rows[0]["dtnha"].ToString();
					txtemail.Text=tb.Rows[0]["email"].ToString();
					txtid.Text=tb.Rows[0]["maql"].ToString();
					txtnoilamviec.Text=tb.Rows[0]["cholam"].ToString();
					cmbphongkham.SelectedValue=tb.Rows[0]["phongkham"].ToString();
					cmbloaihen.SelectedValue=tb.Rows[0]["lydohen"].ToString();
					cmbbacsi.SelectedValue=tb.Rows[0]["mabs"].ToString();
					txtghichu.Text=tb.Rows[0]["ghichu"].ToString();
					txtgiokham.Text=tb.Rows[0]["giokham"].ToString();
					cmbthoigian.Text=tb.Rows[0]["thoigian"].ToString();
					cmbtinhtp.SelectedValue=tb.Rows[0]["matt"].ToString();
					cmbquanhuyen.SelectedValue=tb.Rows[0]["maqu"].ToString();
					cmbphuongxa.SelectedValue=tb.Rows[0]["maphuongxa"].ToString();
					txtthonpho.Text=tb.Rows[0]["thon"].ToString();
					int tuoi= int.Parse(DateTime.Now.Year.ToString()) - int.Parse(tb.Rows[0]["namsinh"].ToString());
					txttuoi.Text=tuoi.ToString();
					if(int.Parse(tb.Rows[0]["giokham"].ToString().Substring(0,2))<12)
					{
						txtsothutu.Text="S"+tb.Rows[0]["stt"].ToString();
					}
					else
					{
						txtsothutu.Text="C"+tb.Rows[0]["stt"].ToString();
					}
				}
			}
		}

		private void txtgiokham_Validated(object sender, System.EventArgs e)
		{	
			try
			{
				txtgiokham.Text=txtgiokham.Text.Substring(0,2)+":"+txtgiokham.Text.Substring(2,2);
			}
			catch
			{}
			try
			{
				if(txtgiokham.TextLength!=0)
				{
					if(!Check())
					{
						MessageBox.Show("Nhập giờ không đúng","Thông Báo");
						txtgiokham.Focus();
						return;
					}
					int gio =int.Parse(txtgiokham.Text.Substring(0,2).ToString());
					string buoi;
					if(gio<12)
						buoi = "S";
					else
						buoi = "C";   
					DataSet Ds = k.Loadgio_stt();			
					//			DataTable tb = Ds.Tables[0];
					//string hhh=txtgiokham.Text.Substring(0,2).ToString()+"/"+txtgiokham.Text.Substring(3,2).ToString();
					DataRow[] r=Ds.Tables[0].Select("Gio = '"+txtgiokham.Text.Trim()+"'");
					if(r.Length>0)
					{
						txtsothutu.Text = buoi+r[0]["Sothutu"].ToString();
					}
					else
					{
						txtsothutu.Text="";
					}

					if(txtsothutu.TextLength!=0)
					{
						if(!check_trunggio())
						{
							txtgiokham.Focus();
							return;
						}
					}
				}
			}
			catch
			{
				MessageBox.Show("Nhập giờ không đúng","Thông Báo");
				txtgiokham.Focus();
				return;
			}
		}

		private bool check_trunggio()
		{			
			DataRow [] dtr = Dssothutu.Tables[0].Select("stt='"+txtsothutu.Text.Remove(0,1).ToString()+"'");
			if(dtr.Length >0)
			{
				MessageBox.Show("Có cuộc hẹn trùng thời gian này","Thông Báo");
				return false;
			}
			else
			{
				return true;		
			}		
		}
		
		private bool Check()
		{
			DataSet Ds = k.get_thoigian("Select * from lh_thoigian");
			DataTable tb = Ds.Tables[0];
			int tgbd = int.Parse(tb.Rows[0]["TGBD"].ToString().Substring(0,2));
			int tgkt = int.Parse(tb.Rows[0]["TGKT"].ToString().Substring(0,2));
			int phutkt = int.Parse(tb.Rows[0]["TGKT"].ToString().Substring(3,2));
			string a = txtgiokham.Text.ToString().Trim();			

			int gio = int.Parse(txtgiokham.Text.Substring(0,2).ToString());
			int phut = int.Parse(txtgiokham.Text.Substring(3,2).ToString());
			if(phut>59)
			{
				return false;
			}
			if(gio<tgbd)
			{
				MessageBox.Show("Giờ hẹn phải lớn hơn giờ bắt đầu làm việc","Thông Báo");
				txtgiokham.Focus();
				return false;
			}
			if(gio>tgkt)
			{
				MessageBox.Show("Giờ hẹn phải nhỏ hơn giờ nghỉ","Thông Báo");
				txtgiokham.Focus();
				return false;
			}
			if(gio == tgkt && phutkt>phut)
			{
				MessageBox.Show("Giờ hẹn phải nhỏ hơn giờ nghỉ","Thông Báo");
				txtgiokham.Focus();
				return false;
			}
			return true;
		}

		private void Load_sothutu()
		{
			try
			{
				string sql="Select stt,mabs  from lh_khambenh where  phongkham ='"+txtphongkham.Text.ToString()+"' and to_char(ngaykham,'dd/mm/yyyy')='"+mkbngaykham.Text+"' ";	
				Dssothutu=k.get_data(sql);					
			}
			catch(Exception m)
			{
				MessageBox.Show(m.Message);
			}
		}

		private void mkbngaykham_Validated(object sender, System.EventArgs e)
		{			
			Load_sothutu();
		}

		private void txtemail_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			cmbthoigian.Focus();
			SendKeys.Send("{f4}");
		}

		private void lbHANHCHINH_Click(object sender, System.EventArgs e)
		{
			if(dataGrid2.Visible==true)
			{
				dataGrid2.Visible=false;
			}
			else
			{
				dataGrid2.Visible=true;
			}
		}

		private void label1_Click(object sender, System.EventArgs e)
		{
			if(txtid.Visible==true)
			{
				txtid.Visible=false;				
				lb_maql.Visible=false;
			}
			else
			{
				txtid.Visible=true;				
				lb_maql.Visible=true;
			}
		}

		private bool kt_trungBS()
		{
			DataRow [] dtr = Dssothutu.Tables[0].Select("stt='"+txtsothutu.Text.Remove(0,1).ToString()+"' and mabs='"+txtbacsi.Text+"'");
			if(dtr.Length >0)
			{
				if(txtsothutu.Text.ToString()==stt && txtbacsi.Text.ToString()==mabacsi_)
				{return true;
				}
				MessageBox.Show("Đã có cuộc hẹn với Bác Sĩ này","Thông Báo");
				return false;
			}
			else
			{
				return true;		
			}		
		}

		private void dataGrid3_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne)
		{
		
		}

		private void cmdprint_Click(object sender, System.EventArgs e)
		{
			try
			{
				string id=txtid.Text;
				string sql="Select a.mabn,a.hoten,a.namsinh,a.sonha||' '||a.thon tenduong,b.tenpxa||' - '||c.tenquan||' - '||d.tentt diachi,e.giokham,e.stt,f.hoten as bacsi,e.ngaykham,e.ghichu,g.tenkp from lh_benhnhan a,btdpxa b, btdquan c,btdtt d,lh_khambenh e,dmbs f,btdkp_bv g where a.maql=e.maql and a.maphuongxa=b.maphuongxa and a.maqu=c.maqu and a.matt=d.matt and e.phongkham=g.makp and e.mabs=f.ma and a.maql="+id+" and e.maql="+id+"";
				DataSet ds = k.get_data(sql);
				frmReport f=new frmReport(m,ds,"","lh_phieuhen.rpt");
				f.ShowDialog();
			}
			catch
			{
				MessageBox.Show("Không có dữ liệu","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}
		}

		private void get_btdbn(string mabn)
		{	
			try
			{
				DataTable datatable = k.get_btdbn(mabn).Tables[0];
				if(datatable.Rows.Count >0)
				{
					txtmabn1.Text=mabn.Substring(0,2);
					txtmabn2.Text=mabn.Substring(2,6);
					txthoten.Text= datatable.Rows[0]["HOTEN"].ToString();
					txtnamsinh.Text=datatable.Rows[0]["NAMSINH"].ToString();
					txttuoi.Text =k.Tinhtuoi(txtnamsinh.Text.ToString().Trim()).ToString();				
					cmbgioitinh.SelectedValue=datatable.Rows[0]["PHAI"].ToString();
					if(datatable.Rows[0]["NGAYSINH"].ToString()!="")
					{
						mkbngaysinh.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(datatable.Rows[0]["NGAYSINH"].ToString()));// Co sai khong ??					
						string tuoi = k.Tinhthangngay(mkbngaysinh.Text.ToString().Substring(0,10).Trim());
						if(tuoi!="0000")
						{
							txttuoi.Text=tuoi.Substring(0,3).ToString();
							cmbtuoi.SelectedIndex=int.Parse(tuoi.Substring(3,1).ToString().Trim());
						}
					}
					cmbgioitinh.SelectedValue=int.Parse(datatable.Rows[0]["PHAI"].ToString().Trim());
					cmbnghenghiep.SelectedValue=datatable.Rows[0]["MANN"].ToString();
					cmbdantoc.SelectedValue=datatable.Rows[0]["MADANTOC"].ToString();
					if(cmbquoctich.Enabled)
					{
						//DataTable tbb= k.Get_idnuoc(mabn).Tables[0];
						DataTable tbb =k.get_data("select * from nuocngoai where mabn='"+mabn+"'").Tables[0];
						//MessageBox.Show(tbb.Rows[0]["ID_NUOC"].ToString());
						if(tbb.Rows.Count >0)
						{
							//MessageBox.Show(tb.Rows[0]["ID_NUOC"].ToString());
							cmbquoctich.SelectedValue= tbb.Rows[0]["ID_NUOC"].ToString();//row["ID_NUOC"].ToString();
						}
					}
					txtsonha.Text=datatable.Rows[0]["SONHA"].ToString();
					txtthonpho.Text=datatable.Rows[0]["THON"].ToString();				
					cmbtinhtp.SelectedValue=datatable.Rows[0]["MATT"].ToString();
					cmbquanhuyen.SelectedValue=datatable.Rows[0]["MAQU"].ToString().Trim();
					cmbphuongxa.SelectedValue=datatable.Rows[0]["MAPHUONGXA"].ToString().Trim();
					txtnoilamviec.Text=datatable.Rows[0]["CHOLAM"].ToString();
					cmbthoigian.Focus();
					SendKeys.Send("{f4}");
					return;					
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}

		
