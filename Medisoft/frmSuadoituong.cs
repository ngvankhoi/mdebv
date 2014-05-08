using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibDuoc;
using LibVienphi;
 
namespace Medisoft
{
	/// <summary>
	/// Summary description for frmRavien.
	/// </summary>
	public class frmSuadoituong : System.Windows.Forms.Form
	{
		Language lan = new Language();
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox namsinh;
		private System.Windows.Forms.TextBox tenkp;
		private System.Windows.Forms.TextBox diachi;
		private System.Windows.Forms.Button butTiep;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butExit;
		private DataSet ds=new DataSet();
		private DataSet dsngay=new DataSet();
		private DataTable dt=new DataTable();
		private LibMedi.AccessData m;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
		private long l_maql,l_idkhoa,l_mavaovien;
		private int i_loaiba;
		private bool b_ndot,bThanhtoan_khoa;
		private DataRow r;
		private string s_makp,sql,s_ngayvao;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.TextBox makp;
		private System.Windows.Forms.ComboBox ngayvao;
		private MaskedBox.MaskedBox ngayra;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox solieu;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox madtcu;
		private System.Windows.Forms.ComboBox madtmoi;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox theo;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butSua;
		private CurrencyManager objStudentCM;
		private DataGridTableStyle ts;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.CheckBox chkKX;
		private System.Windows.Forms.Button butTHThuoc;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSuadoituong(LibMedi.AccessData acc,string makp,int loaiba)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			m=acc;
			s_makp=makp;i_loaiba=loaiba;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmSuadoituong));
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.mabn = new System.Windows.Forms.TextBox();
			this.hoten = new System.Windows.Forms.TextBox();
			this.namsinh = new System.Windows.Forms.TextBox();
			this.tenkp = new System.Windows.Forms.TextBox();
			this.diachi = new System.Windows.Forms.TextBox();
			this.butTiep = new System.Windows.Forms.Button();
			this.butLuu = new System.Windows.Forms.Button();
			this.butBoqua = new System.Windows.Forms.Button();
			this.butExit = new System.Windows.Forms.Button();
			this.makp = new System.Windows.Forms.TextBox();
			this.ngayvao = new System.Windows.Forms.ComboBox();
			this.ngayra = new MaskedBox.MaskedBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.solieu = new System.Windows.Forms.ComboBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.madtcu = new System.Windows.Forms.ComboBox();
			this.madtmoi = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.theo = new System.Windows.Forms.ComboBox();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.butSua = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.chkKX = new System.Windows.Forms.CheckBox();
			this.butTHThuoc = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(184, 7);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 23);
			this.label2.TabIndex = 20;
			this.label2.Text = "Họ tên :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(435, 7);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 23);
			this.label3.TabIndex = 22;
			this.label3.Text = "Năm sinh :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(-8, 29);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 23);
			this.label4.TabIndex = 2;
			this.label4.Text = "Ngày vào :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(152, 29);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 23);
			this.label5.TabIndex = 3;
			this.label5.Text = "Ngày ra :";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(327, 29);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(88, 23);
			this.label6.TabIndex = 5;
			this.label6.Text = "Khoa xuất viện :";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(536, 8);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(72, 23);
			this.label8.TabIndex = 24;
			this.label8.Text = "Địa chỉ :";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mabn
			// 
			this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mabn.Location = new System.Drawing.Point(56, 8);
			this.mabn.MaxLength = 8;
			this.mabn.Name = "mabn";
			this.mabn.Size = new System.Drawing.Size(112, 21);
			this.mabn.TabIndex = 1;
			this.mabn.Text = "";
			this.mabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
			this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
			// 
			// hoten
			// 
			this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
			this.hoten.Enabled = false;
			this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.hoten.Location = new System.Drawing.Point(233, 8);
			this.hoten.Name = "hoten";
			this.hoten.Size = new System.Drawing.Size(207, 21);
			this.hoten.TabIndex = 21;
			this.hoten.Text = "";
			// 
			// namsinh
			// 
			this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
			this.namsinh.Enabled = false;
			this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.namsinh.Location = new System.Drawing.Point(496, 8);
			this.namsinh.Name = "namsinh";
			this.namsinh.Size = new System.Drawing.Size(40, 21);
			this.namsinh.TabIndex = 23;
			this.namsinh.Text = "";
			// 
			// tenkp
			// 
			this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tenkp.Enabled = false;
			this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tenkp.Location = new System.Drawing.Point(440, 31);
			this.tenkp.Name = "tenkp";
			this.tenkp.Size = new System.Drawing.Size(224, 21);
			this.tenkp.TabIndex = 7;
			this.tenkp.Text = "";
			// 
			// diachi
			// 
			this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
			this.diachi.Enabled = false;
			this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.diachi.Location = new System.Drawing.Point(608, 8);
			this.diachi.Name = "diachi";
			this.diachi.Size = new System.Drawing.Size(176, 21);
			this.diachi.TabIndex = 25;
			this.diachi.Text = "";
			// 
			// butTiep
			// 
			this.butTiep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butTiep.Image = ((System.Drawing.Bitmap)(resources.GetObject("butTiep.Image")));
			this.butTiep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butTiep.Location = new System.Drawing.Point(271, 493);
			this.butTiep.Name = "butTiep";
			this.butTiep.Size = new System.Drawing.Size(80, 28);
			this.butTiep.TabIndex = 15;
			this.butTiep.Text = "         &Tiếp";
			this.butTiep.Click += new System.EventHandler(this.butTiep_Click);
			// 
			// butLuu
			// 
			this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butLuu.Image = ((System.Drawing.Bitmap)(resources.GetObject("butLuu.Image")));
			this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLuu.Location = new System.Drawing.Point(352, 493);
			this.butLuu.Name = "butLuu";
			this.butLuu.Size = new System.Drawing.Size(80, 28);
			this.butLuu.TabIndex = 13;
			this.butLuu.Text = "          &Lưu";
			this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
			// 
			// butBoqua
			// 
			this.butBoqua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butBoqua.Image")));
			this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butBoqua.Location = new System.Drawing.Point(648, 536);
			this.butBoqua.Name = "butBoqua";
			this.butBoqua.Size = new System.Drawing.Size(74, 28);
			this.butBoqua.TabIndex = 14;
			this.butBoqua.Text = "&Bỏ qua";
			this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butBoqua.Visible = false;
			this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
			// 
			// butExit
			// 
			this.butExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butExit.Image = ((System.Drawing.Bitmap)(resources.GetObject("butExit.Image")));
			this.butExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butExit.Location = new System.Drawing.Point(433, 493);
			this.butExit.Name = "butExit";
			this.butExit.Size = new System.Drawing.Size(88, 28);
			this.butExit.TabIndex = 16;
			this.butExit.Text = "&Kết thúc";
			this.butExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butExit.Click += new System.EventHandler(this.butExit_Click);
			// 
			// makp
			// 
			this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
			this.makp.Enabled = false;
			this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.makp.Location = new System.Drawing.Point(416, 31);
			this.makp.Name = "makp";
			this.makp.Size = new System.Drawing.Size(23, 21);
			this.makp.TabIndex = 6;
			this.makp.Text = "";
			// 
			// ngayvao
			// 
			this.ngayvao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ngayvao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ngayvao.Location = new System.Drawing.Point(56, 31);
			this.ngayvao.Name = "ngayvao";
			this.ngayvao.Size = new System.Drawing.Size(112, 21);
			this.ngayvao.TabIndex = 2;
			this.ngayvao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngayvao_KeyDown);
			this.ngayvao.SelectedIndexChanged += new System.EventHandler(this.ngayvao_SelectedIndexChanged);
			// 
			// ngayra
			// 
			this.ngayra.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ngayra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ngayra.Location = new System.Drawing.Point(233, 31);
			this.ngayra.Mask = "##/##/#### ##:##";
			this.ngayra.Name = "ngayra";
			this.ngayra.Size = new System.Drawing.Size(95, 21);
			this.ngayra.TabIndex = 4;
			this.ngayra.Text = "";
			this.ngayra.Validated += new System.EventHandler(this.ngayra_Validated);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "&Mã BN :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(168, 56);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(64, 23);
			this.label10.TabIndex = 26;
			this.label10.Text = "Số liệu :";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// solieu
			// 
			this.solieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.solieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.solieu.Items.AddRange(new object[] {
														"Thuốc",
														"Viện phí",
														""});
			this.solieu.Location = new System.Drawing.Point(232, 56);
			this.solieu.Name = "solieu";
			this.solieu.Size = new System.Drawing.Size(96, 21);
			this.solieu.TabIndex = 9;
			this.solieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.solieu_KeyDown);
			this.solieu.SelectedIndexChanged += new System.EventHandler(this.solieu_SelectedIndexChanged);
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(332, 56);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(80, 23);
			this.label11.TabIndex = 28;
			this.label11.Text = "Đối tượng củ :";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(544, 53);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(96, 23);
			this.label12.TabIndex = 29;
			this.label12.Text = "Đối tượng mới :";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// madtcu
			// 
			this.madtcu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.madtcu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.madtcu.Location = new System.Drawing.Point(416, 56);
			this.madtcu.Name = "madtcu";
			this.madtcu.Size = new System.Drawing.Size(128, 21);
			this.madtcu.TabIndex = 10;
			this.madtcu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madtcu_KeyDown);
			this.madtcu.SelectedIndexChanged += new System.EventHandler(this.madtcu_SelectedIndexChanged);
			// 
			// madtmoi
			// 
			this.madtmoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.madtmoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.madtmoi.Location = new System.Drawing.Point(640, 54);
			this.madtmoi.Name = "madtmoi";
			this.madtmoi.Size = new System.Drawing.Size(112, 21);
			this.madtmoi.TabIndex = 11;
			this.madtmoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madtmoi_KeyDown);
			this.madtmoi.SelectedIndexChanged += new System.EventHandler(this.madtmoi_SelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(-8, 53);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 23);
			this.label7.TabIndex = 32;
			this.label7.Text = "Theo :";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// theo
			// 
			this.theo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.theo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.theo.Items.AddRange(new object[] {
													  "Toàn bộ",
													  "Chi tiết"});
			this.theo.Location = new System.Drawing.Point(56, 54);
			this.theo.Name = "theo";
			this.theo.Size = new System.Drawing.Size(112, 21);
			this.theo.TabIndex = 8;
			this.theo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.theo_KeyDown);
			this.theo.SelectedIndexChanged += new System.EventHandler(this.theo_SelectedIndexChanged);
			// 
			// dataGrid1
			// 
			this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
			this.dataGrid1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
			this.dataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F);
			this.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.FlatMode = true;
			this.dataGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
			this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
			this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
			this.dataGrid1.Location = new System.Drawing.Point(8, 64);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
			this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.RowHeaderWidth = 5;
			this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid1.Size = new System.Drawing.Size(776, 416);
			this.dataGrid1.TabIndex = 34;
			// 
			// butSua
			// 
			this.butSua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butSua.Image")));
			this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSua.Location = new System.Drawing.Point(576, 536);
			this.butSua.Name = "butSua";
			this.butSua.Size = new System.Drawing.Size(74, 28);
			this.butSua.TabIndex = 12;
			this.butSua.Text = "         &Sửa";
			this.butSua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSua.Visible = false;
			this.butSua.Click += new System.EventHandler(this.butSua_Click);
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button1.Location = new System.Drawing.Point(760, 54);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(24, 21);
			this.button1.TabIndex = 35;
			this.button1.Text = "...";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// chkKX
			// 
			this.chkKX.Location = new System.Drawing.Point(672, 32);
			this.chkKX.Name = "chkKX";
			this.chkKX.Size = new System.Drawing.Size(116, 20);
			this.chkKX.TabIndex = 36;
			this.chkKX.Text = "Theo khoa xuất";
			// 
			// butTHThuoc
			// 
			this.butTHThuoc.Image = ((System.Drawing.Bitmap)(resources.GetObject("butTHThuoc.Image")));
			this.butTHThuoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butTHThuoc.Location = new System.Drawing.Point(608, 504);
			this.butTHThuoc.Name = "butTHThuoc";
			this.butTHThuoc.Size = new System.Drawing.Size(112, 28);
			this.butTHThuoc.TabIndex = 37;
			this.butTHThuoc.Text = "         Tổ&ng hợp lại";
			this.butTHThuoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butTHThuoc.Visible = false;
			this.butTHThuoc.Click += new System.EventHandler(this.butTHThuoc_Click);
			// 
			// frmSuadoituong
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 573);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.butTHThuoc,
																		  this.chkKX,
																		  this.button1,
																		  this.butSua,
																		  this.theo,
																		  this.label7,
																		  this.madtmoi,
																		  this.madtcu,
																		  this.label12,
																		  this.label11,
																		  this.solieu,
																		  this.label10,
																		  this.ngayra,
																		  this.mabn,
																		  this.ngayvao,
																		  this.makp,
																		  this.butExit,
																		  this.butBoqua,
																		  this.butLuu,
																		  this.butTiep,
																		  this.diachi,
																		  this.tenkp,
																		  this.namsinh,
																		  this.hoten,
																		  this.label8,
																		  this.label6,
																		  this.label5,
																		  this.label4,
																		  this.label3,
																		  this.label2,
																		  this.label1,
																		  this.dataGrid1});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmSuadoituong";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Sửa đối tượng";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmSuadoituong_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmSuadoituong_Load(object sender, System.EventArgs e)
		{
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			solieu.SelectedIndex=solieu.Items.Count-1;// 0;
			theo.SelectedIndex=0;
			ena_madt();
			b_ndot=m.bThanhtoan_ndot;
            bThanhtoan_khoa = m.bThanhtoan_khoa;
			dt=m.get_data("select * from d_doituong order by madoituong").Tables[0];
			madtcu.DisplayMember="DOITUONG";
			madtcu.ValueMember="MADOITUONG";
			madtcu.DataSource=dt;

			madtmoi.DisplayMember="DOITUONG";
			madtmoi.ValueMember="MADOITUONG";
			load_madtmoi();
			dsngay.ReadXml("..\\..\\..\\xml\\m_ngayvao.xml");
            dsngay.Tables[0].Columns.Add("mabs");
            dsngay.Tables[0].Columns.Add("tenbs");
			ngayvao.DisplayMember="NGAYVAO";
			ngayvao.ValueMember="NGAYVAO";
			ngayvao.DataSource=dsngay.Tables[0];
			ds.ReadXml("..\\..\\..\\xml\\m_suamadt.xml");
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

		}

		private void mabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void mabn_Validated(object sender, System.EventArgs e)
		{
			int i=0;long o_maql;
            hoten.Text = ""; l_mavaovien = 0; l_maql = 0; l_idkhoa = 0; dsngay.Clear();
			if (mabn.Text=="" || mabn.Text.Trim().Length<3) return;
			if (mabn.Text.Trim().Length!=8) mabn.Text=mabn.Text.Substring(0,2)+mabn.Text.Substring(2).PadLeft(6,'0');
			if (b_ndot || bThanhtoan_khoa)
			{
				sql="select c.hoten,c.namsinh,c.phai,c.sonha,c.thon,h.mavaovien,a.maql,a.id,a.giuong,to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngayvao,decode(b.ngay,null,to_char(sysdate,'dd/mm/yyyy hh24:mi'),to_char(b.ngay,'dd/mm/yyyy hh24:mi')) ngayra,a.makp,d.tenkp,nvl(b.chandoan,' ') chandoan,nvl(b.maicd,' ') maicd,nvl(e.tentt,' ') tentt,nvl(f.tenquan,' ') tenquan,nvl(g.tenpxa,' ') tenpxa from nhapkhoa a,xuatkhoa b,btdbn c,btdkp_bv d,btdtt e,btdquan f,btdpxa g,benhandt h where a.id=b.id(+) and a.mabn=c.mabn and a.makp=d.makp and c.matt=e.matt(+) and c.maqu=f.maqu(+) and c.maphuongxa=g.maphuongxa(+) and a.maql=h.maql and a.mabn='"+mabn.Text+"' and h.loaiba="+i_loaiba;
				if (s_makp!="") sql+=" and a.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
				sql+=" order by a.id desc";
			}
			else
			{				
				if (s_makp!="" && chkKX.Checked)
					sql="select c.hoten,c.namsinh,c.phai,c.sonha,c.thon,h.mavaovien,a.maql,a.id,a.giuong,to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngayvao,decode(b.ngay,null,to_char(sysdate,'dd/mm/yyyy hh24:mi'),to_char(b.ngay,'dd/mm/yyyy hh24:mi')) ngayra,a.makp,d.tenkp,nvl(b.chandoan,' ') chandoan,nvl(b.maicd,' ') maicd,nvl(e.tentt,' ') tentt,nvl(f.tenquan,' ') tenquan,nvl(g.tenpxa,' ') tenpxa from nhapkhoa a,xuatkhoa b,btdbn c,btdkp_bv d,btdtt e,btdquan f,btdpxa g,benhandt h where a.id=b.id(+) and a.mabn=c.mabn and a.makp=d.makp and c.matt=e.matt(+) and c.maqu=f.maqu(+) and c.maphuongxa=g.maphuongxa(+) and a.maql=h.maql and a.makp in ("+s_makp.Substring(0,s_makp.Length-1)+") and a.mabn='"+mabn.Text+"' and h.loaiba="+i_loaiba+" order by a.id desc";
				else
					sql="select c.hoten,c.namsinh,c.phai,c.sonha,c.thon,a.mavaovien,a.maql,0 id,' ' giuong,to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngayvao,decode(b.ngay,null,to_char(sysdate,'dd/mm/yyyy hh24:mi'),to_char(b.ngay,'dd/mm/yyyy hh24:mi')) ngayra,decode(b.makp,null,a.makp,b.makp) makp,decode(b.makp,null,h.tenkp,d.tenkp) tenkp,nvl(b.chandoan,' ') chandoan,nvl(b.maicd,' ') maicd,nvl(e.tentt,' ') tentt,nvl(f.tenquan,' ') tenquan,nvl(g.tenpxa,' ') tenpxa from benhandt a,xuatvien b,btdbn c,btdkp_bv d,btdtt e,btdquan f,btdpxa g,btdkp_bv h where a.maql=b.maql(+) and a.mabn=c.mabn and b.makp=d.makp(+) and c.matt=e.matt(+) and c.maqu=f.maqu(+) and c.maphuongxa=g.maphuongxa(+) and a.makp=h.makp and a.mabn='"+mabn.Text+"' and a.loaiba="+i_loaiba+" order by a.maql desc";
			}
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				if (i==0)
				{
					hoten.Text=r["hoten"].ToString();
					namsinh.Text=r["namsinh"].ToString();
					s_ngayvao=r["ngayvao"].ToString();
					ngayra.Text=r["ngayra"].ToString();
					diachi.Text=r["sonha"].ToString().Trim()+" "+r["thon"].ToString().Trim();
					makp.Text=r["makp"].ToString();
					tenkp.Text=r["tenkp"].ToString();
                    l_mavaovien = long.Parse(r["mavaovien"].ToString());
					l_maql=long.Parse(r["maql"].ToString());
					l_idkhoa=long.Parse(r["id"].ToString());
				}
				o_maql=long.Parse(r["maql"].ToString());
				m.updrec_ravien(dsngay,mabn.Text,o_maql,long.Parse(r["id"].ToString()),
					hoten.Text,r["namsinh"].ToString(),(r["phai"].ToString()=="0")?"Nam":"Nữ",r["sonha"].ToString().Trim()+" "+r["thon"].ToString().Trim()+", "+r["tenpxa"].ToString().Trim()+", "+r["tenquan"].ToString().Trim()+", "+r["tentt"].ToString().Trim(),
					0,"","","","","",r["giuong"].ToString(),r["makp"].ToString(),r["tenkp"].ToString(),r["ngayvao"].ToString(),r["ngayra"].ToString(),r["chandoan"].ToString(),r["maicd"].ToString(),"",0,0,0,"");
				i++;
			}
			if (l_maql==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Người bệnh này chưa hoàn tất thủ tục !"),LibMedi.AccessData.Msg);
				mabn.Focus();
			}
			else ngayvao.SelectedValue=s_ngayvao;
			//
			mabn.Enabled=false;
			//
		}

		private void ngayvao_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ena_but(bool ena)
		{
			butTiep.Enabled=!ena;
			butSua.Enabled=ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butExit.Enabled=!ena;
		}

		private void butTiep_Click(object sender, System.EventArgs e)
		{
			ds.Clear();
			mabn.Enabled=true;
			mabn.Text="";
			hoten.Text="";
			namsinh.Text="";
			ngayra.Text=m.Ngaygio_hienhanh;
			tenkp.Text="";
			makp.Text="";
			diachi.Text="";
            l_maql = 0; l_idkhoa = 0; l_mavaovien = 0;
			//ena_but(true);
			mabn.Focus();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{			
			if(mabn.Text=="" || mabn.Text.Length!=8)return;
			if(chkKX.Checked==false)l_idkhoa=0;

			Cursor=Cursors.WaitCursor;
			if (theo.SelectedIndex==0) //tonghop
			{
				foreach(DataRow r1 in ds.Tables[0].Select("madoituong="+int.Parse(madtcu.SelectedValue.ToString())))
				{
					if (madtmoi.SelectedValue.ToString()=="1" && int.Parse(r1["bhyt"].ToString())==0)
					{
						//nothing
					}
					else
					{
						if (solieu.SelectedIndex==0)
						{
							d.execute_data("delete from "+d.user+r1["mmyy"].ToString().PadLeft(4,'0')+".d_tienthuoc where mabn='"+r1["mabn"].ToString()+"' and maql="+long.Parse(r1["maql"].ToString())+" and idkhoa="+long.Parse(r1["idkhoa"].ToString())+" and to_char(ngay,'dd/mm/yyyy')='"+r1["ngay"].ToString()+"' and makp="+int.Parse(r1["makp"].ToString())+" and madoituong="+int.Parse(madtcu.SelectedValue.ToString())+" and mabd="+int.Parse(r1["ma"].ToString()));
							d.upd_tienthuoc(r1["mmyy"].ToString().PadLeft(4,'0'),r1["mabn"].ToString(),long.Parse(r1["mavaovien"].ToString()),long.Parse(r1["maql"].ToString()),long.Parse(r1["idkhoa"].ToString()),r1["ngay"].ToString(),int.Parse(r1["makp"].ToString()),int.Parse(madtmoi.SelectedValue.ToString()),int.Parse(r1["ma"].ToString()),decimal.Parse(r1["soluong"].ToString()),decimal.Parse(r1["giaban"].ToString()),decimal.Parse(r1["giamua"].ToString()));
							d.upd_theodoicongno(d.delete,r1["mabn"].ToString(),long.Parse(r1["mavaovien"].ToString()),long.Parse(r1["maql"].ToString()),long.Parse(r1["idkhoa"].ToString()),int.Parse(madtcu.SelectedValue.ToString()),decimal.Parse(r1["sotien"].ToString()),"thuoc");
							d.upd_theodoicongno(d.insert,r1["mabn"].ToString(),long.Parse(r1["mavaovien"].ToString()),long.Parse(r1["maql"].ToString()),long.Parse(r1["idkhoa"].ToString()),int.Parse(madtmoi.SelectedValue.ToString()),decimal.Parse(r1["sotien"].ToString()),"thuoc");
						}
						else  
						{
							d.upd_theodoicongno(d.delete,r1["mabn"].ToString(),long.Parse(r1["mavaovien"].ToString()),long.Parse(r1["maql"].ToString()),long.Parse(r1["idkhoa"].ToString()),int.Parse(madtcu.SelectedValue.ToString()),decimal.Parse(r1["sotien"].ToString()),"vienphi");
							v.execute_data("update v_vpkhoa set madoituong="+int.Parse(madtmoi.SelectedValue.ToString())+" where id="+long.Parse(r1["id"].ToString()));
							if(madtmoi.SelectedValue.ToString()=="1")
								v.execute_data("update v_vpkhoa a set dongia=(select gia_bh from "+m.user+".v_giavp b where a.mavp=b.id) where id="+long.Parse(r1["id"].ToString()));
							else
								v.execute_data("update v_vpkhoa a set dongia=(select gia_th from "+m.user+".v_giavp b where a.mavp=b.id) where id="+long.Parse(r1["id"].ToString()));
							//
							d.upd_theodoicongno(d.insert,r1["mabn"].ToString(),long.Parse(r1["mavaovien"].ToString()),long.Parse(r1["maql"].ToString()),long.Parse(r1["idkhoa"].ToString()),int.Parse(madtmoi.SelectedValue.ToString()),decimal.Parse(r1["sotien"].ToString()),"vienphi");	
						}
					}
				}
			}
			else
			{
				foreach(DataRow r1 in ds.Tables[0].Select("doituongcu<>doituong"))
				{
					r=d.getrowbyid(dt,"doituong='"+r1["doituong"].ToString()+"'");
					if (r!=null)
					{
						if (int.Parse(r["madoituong"].ToString())==1 && int.Parse(r1["bhyt"].ToString())==0)
						{
							//nothing
						}
						else
						{
							if (solieu.SelectedIndex==0)
							{
								d.execute_data("delete from "+d.user+r1["mmyy"].ToString().PadLeft(4,'0')+".d_tienthuoc where mabn='"+r1["mabn"].ToString()+"' and maql="+long.Parse(r1["maql"].ToString())+" and idkhoa="+long.Parse(r1["idkhoa"].ToString())+" and to_char(ngay,'dd/mm/yyyy')='"+r1["ngay"].ToString()+"' and makp="+int.Parse(r1["makp"].ToString())+" and madoituong="+int.Parse(r1["madoituong"].ToString())+" and mabd="+int.Parse(r1["ma"].ToString()));
								d.upd_tienthuoc(r1["mmyy"].ToString().PadLeft(4,'0'),r1["mabn"].ToString(),long.Parse(r1["mavaovien"].ToString()),long.Parse(r1["maql"].ToString()),long.Parse(r1["idkhoa"].ToString()),r1["ngay"].ToString(),int.Parse(r1["makp"].ToString()),int.Parse(r["madoituong"].ToString()),int.Parse(r1["ma"].ToString()),decimal.Parse(r1["soluong"].ToString()),decimal.Parse(r1["giaban"].ToString()),decimal.Parse(r1["giamua"].ToString()));
								d.upd_theodoicongno(d.delete,r1["mabn"].ToString(),long.Parse(r1["mavaovien"].ToString()),long.Parse(r1["maql"].ToString()),long.Parse(r1["idkhoa"].ToString()),int.Parse(r1["madoituong"].ToString()),decimal.Parse(r1["sotien"].ToString()),"thuoc");
                                d.upd_theodoicongno(d.insert, r1["mabn"].ToString(), long.Parse(r1["mavaovien"].ToString()), long.Parse(r1["maql"].ToString()), long.Parse(r1["idkhoa"].ToString()), int.Parse(r["madoituong"].ToString()), decimal.Parse(r1["sotien"].ToString()), "thuoc");
							}
							else
							{
                                d.upd_theodoicongno(d.delete, r1["mabn"].ToString(), long.Parse(r1["mavaovien"].ToString()), long.Parse(r1["maql"].ToString()), long.Parse(r1["idkhoa"].ToString()), int.Parse(r["madoituong"].ToString()), decimal.Parse(r1["sotien"].ToString()), "vienphi");	
								v.execute_data("update v_vpkhoa set madoituong="+int.Parse(r["madoituong"].ToString())+" where id="+long.Parse(r1["id"].ToString()));
								if(r["madoituong"].ToString()=="1")
									v.execute_data("update v_vpkhoa a set dongia=(select gia_bh from "+m.user+".v_giavp b where a.mavp=b.id) where id="+long.Parse(r1["id"].ToString()));
								else
									v.execute_data("update v_vpkhoa a set dongia=(select gia_th from "+m.user+".v_giavp b where a.mavp=b.id) where id="+long.Parse(r1["id"].ToString()));
								//
                                d.upd_theodoicongno(d.insert, r1["mabn"].ToString(), long.Parse(r1["mavaovien"].ToString()), long.Parse(r1["maql"].ToString()), long.Parse(r1["idkhoa"].ToString()), int.Parse(r1["madoituong"].ToString()), decimal.Parse(r1["sotien"].ToString()), "vienphi");
							}
						}
					}
				}
			}
			//ena_but(false);
			Cursor=Cursors.Default;
			butSua_Click(null,null);
			MessageBox.Show(lan.Change_language_MessageText("Đã đổi xong đối tượng !"));
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_but(false);
		}

		private void butExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void AddGridTableStyle()
		{
			int IntAvgCharWidth;
			ts = new DataGridTableStyle();
			IntAvgCharWidth=(int)(System.Drawing.Graphics.FromHwnd(this.Handle).MeasureString("ABCDEFGHIJKLMNOPQRSTUVWXYZ",this.Font).Width/26);
			objStudentCM = (System.Windows.Forms.CurrencyManager)this.BindingContext[ds.Tables[0]];
			ts.MappingName = ds.Tables[0].TableName;

			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.ReadOnly=false;

			ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM .GetItemProperties()["ngay"]));
			ts.GridColumnStyles[0].MappingName = "ngay";
			ts.GridColumnStyles[0].HeaderText = "Ngày";
			ts.GridColumnStyles[0].Width=70;
			ts.ReadOnly=true;
			ts.GridColumnStyles[0].Alignment = HorizontalAlignment.Left;
			ts.GridColumnStyles[0].NullText = string.Empty;

			ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM .GetItemProperties()["ten"]));
			ts.GridColumnStyles[1].MappingName = "ten";
			ts.GridColumnStyles[1].HeaderText = "Tên thuốc - dịch vụ";
			ts.GridColumnStyles[1].Width=335;
			ts.ReadOnly=true;
			ts.GridColumnStyles[1].Alignment = HorizontalAlignment.Left;
			ts.GridColumnStyles[1].NullText = string.Empty;

			ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM .GetItemProperties()["dvt"]));
			ts.GridColumnStyles[2].MappingName = "dvt";
			ts.GridColumnStyles[2].HeaderText = "ĐVT";
			ts.GridColumnStyles[2].Width=60;
			ts.ReadOnly=true;
			ts.GridColumnStyles[2].Alignment = HorizontalAlignment.Left;
			ts.GridColumnStyles[2].NullText = string.Empty;

			ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM .GetItemProperties()["soluong"]));
			ts.GridColumnStyles[3].MappingName = "soluong";
			ts.GridColumnStyles[3].HeaderText = "Số lượng";
			ts.GridColumnStyles[3].Width=80;
			ts.ReadOnly=true;
			ts.GridColumnStyles[3].Alignment = HorizontalAlignment.Right;
			ts.GridColumnStyles[3].NullText = string.Empty;

			ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM .GetItemProperties()["doituongcu"]));
			ts.GridColumnStyles[4].MappingName = "doituongcu";
			ts.GridColumnStyles[4].HeaderText = "Đối tượng củ";
			ts.GridColumnStyles[4].Width=80;
			ts.ReadOnly=true;
			ts.GridColumnStyles[4].Alignment = HorizontalAlignment.Left;
			ts.GridColumnStyles[4].NullText = string.Empty;

			ts.GridColumnStyles.Add(new DataGridComboBoxColumn(dt,1,1));
			ts.GridColumnStyles[5].MappingName = "doituong";
			ts.GridColumnStyles[5].HeaderText = "Đối tượng mới";
			ts.GridColumnStyles[5].Width=100;
			ts.GridColumnStyles[5].Alignment = HorizontalAlignment.Left;
			ts.GridColumnStyles[5].NullText = string.Empty;			
			dataGrid1.CaptionText = string.Empty;
			dataGrid1.DataSource = ds;
			dataGrid1.DataMember = ds.Tables[0].TableName;
			dataGrid1.TableStyles.Add(ts);
			//Binh
			ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM .GetItemProperties()["makp"]));
			ts.GridColumnStyles[6].MappingName = "makp";
			ts.GridColumnStyles[6].HeaderText = "Mã KP";
			ts.GridColumnStyles[6].Width=40;
			ts.ReadOnly=true;
			ts.GridColumnStyles[6].Alignment = HorizontalAlignment.Left;
			ts.GridColumnStyles[6].NullText = string.Empty;
			ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM .GetItemProperties()["stt"]));
			ts.GridColumnStyles[7].MappingName = "stt";
			ts.GridColumnStyles[7].HeaderText = "stt";
			ts.GridColumnStyles[7].Width=40;
			ts.ReadOnly=true;
			ts.GridColumnStyles[7].Alignment = HorizontalAlignment.Left;
			ts.GridColumnStyles[7].NullText = string.Empty;
			//
		}
	
		private void ngayvao_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==ngayvao)
			{
				if (ngayvao.Items.Count>0)
				{
					ngayra.Text=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ngayra"].ToString();
					makp.Text=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["makp"].ToString();
					tenkp.Text=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["tenkp"].ToString();
					l_maql=long.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString());
                    l_mavaovien = long.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["mavaovien"].ToString());
					l_idkhoa=long.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["idkhoa"].ToString());
					//

					//
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
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày và giờ !"),LibMedi.AccessData.Msg);
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
		}

		private void solieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (solieu.SelectedIndex==-1) solieu.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void theo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (theo.SelectedIndex==-1) theo.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void madtcu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (madtcu.SelectedIndex==-1) madtcu.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void madtmoi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (madtmoi.SelectedIndex==-1) madtmoi.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void madtcu_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==madtcu) load_madtmoi();		
		}

		private void load_madtmoi()
		{
			sql="select * from d_doituong where madoituong<>"+int.Parse(madtcu.SelectedValue.ToString())+" order by madoituong";
			madtmoi.DataSource=m.get_data(sql).Tables[0];
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{			
			if (v.get_done_thvp(ngayra.Text.Substring(8,2),mabn.Text,l_maql,l_idkhoa,ngayvao.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Người bệnh \n")+hoten.Text+"\n"+ngayvao.Text+lan.Change_language_MessageText("\nđã thanh toán !"),LibMedi.AccessData.Msg);
				mabn.Focus();
				return;
			}
			if(chkKX.Checked==false)l_idkhoa=0;
			d.execute_data("delete from d_suamadt");
			if (solieu.SelectedIndex==0) load_thuoc();
			else load_vienphi();
			ds=d.get_data("select * from d_suamadt order by substr(ngay,7,4),substr(ngay,4,2),substr(ngay,1,2),ten");
			objStudentCM = (System.Windows.Forms.CurrencyManager)this.BindingContext[ds.Tables[0]];
			ts.MappingName = ds.Tables[0].TableName;
			dataGrid1.DataSource = ds;
			dataGrid1.DataMember = ds.Tables[0].TableName;
			//ena_but(true);
		}

		private void load_thuoc()
		{
			DateTime dt1=d.StringToDate(ngayvao.Text.Substring(0,10)).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(ngayra.Text.Substring(0,10)).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			string mmyy="";
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(mmyy))
					{
						sql="select "+mmyy+" mmyy,0 id,a.mabn,a.maql,a.idkhoa,to_char(a.ngay,'dd/mm/yyyy') ngay,to_char(a.makp,'00') makp,a.madoituong,a.mabd ma,trim(b.tenhc)||' ('|trim(b.ten)||') '||trim(b.hamluong)||'['||trim(c.ten)||']' ten,b.dang dvt,a.soluong,d.doituong doituongcu,d.doituong,b.bhyt,a.sotien,a.giaban,a.giamua ";
						sql+=" from "+d.user+"d"+mmyy+".d_tienthuoc a,"+d.user+".d_dmbd b,"+d.user+".d_dmhang c,"+d.user+".d_doituong d ";
						sql+=" where a.mabd=b.id and b.mahang=c.id and a.madoituong=d.madoituong ";
						sql+=" and a.done=0 and a.mabn='"+mabn.Text+"' and to_date(a.ngay,'dd/mm/yy') between to_date('"+ngayvao.Text.Substring(0,10)+"','dd/mm/yy') and to_date('"+ngayra.Text.Substring(0,10)+"','dd/mm/yy')";
						if (l_idkhoa!=0) sql+=" and a.idkhoa="+l_idkhoa;
						else sql+=" and a.maql="+l_maql;						
						d.execute_data("insert into d_suamadt "+sql);
					}
				}
			}
		}

		private void load_vienphi()
		{
			int yy1=int.Parse(ngayvao.Text.Substring(8,2)),yy2=int.Parse(ngayra.Text.Substring(8,2));
			string yy;
			for(int i=yy1;i<=yy2;i++)
			{
				yy=i.ToString().PadLeft(2,'0');
				/*if (v.bYy(yy))
				{
					sql="select 00"+yy+" mmyy,a.id,a.mabn,a.maql,a.idkhoa,to_char(a.ngay,'dd/mm/yyyy') ngay,a.makp,a.madoituong,a.mavp ma,b.ten,b.dvt,a.soluong,d.doituong doituongcu,d.doituong,b.bhyt,a.soluong*(a.dongia+a.vattu) sotien,0 giaban,a.dongia+a.vattu giamua ";
					sql+=" from "+d.user+"v"+yy+".v_vpkhoa a,"+d.user+".v_giavp b,"+d.user+".d_doituong d ";
					sql+=" where a.mavp=b.id and a.madoituong=d.madoituong ";
					sql+=" and a.done=0 and a.mabn='"+mabn.Text+"' and to_date(a.ngay,'dd/mm/yy') between to_date('"+ngayvao.Text.Substring(0,10)+"','dd/mm/yy') and to_date('"+ngayra.Text.Substring(0,10)+"','dd/mm/yy')";
					if (l_idkhoa!=0) sql+=" and a.idkhoa="+l_idkhoa;
					else sql+=" and a.maql="+l_maql;
					sql+=" order by to_char(a.ngay,'yyyymmdd'),b.ten";
					d.execute_data("insert into d_suamadt "+sql);
				}*/
			}
		}

		private void theo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==theo) ena_madt();
		}

		private void ena_madt()
		{
			madtcu.Enabled=theo.SelectedIndex==0;
			madtmoi.Enabled=madtcu.Enabled;
		}

		private void solieu_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.ActiveControl==solieu)
				butSua_Click(null,null);
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			frmsuabhyt f=new frmsuabhyt(mabn.Text);
			f.ShowDialog();
		}

		private void madtmoi_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(madtmoi.SelectedValue.ToString()=="1")
				button1.Enabled=true;
			else
				button1.Enabled=false;
		}

		private void butTHThuoc_Click(object sender, System.EventArgs e)
		{
			if(mabn.Text!="" && l_maql>0)
			{
				DialogResult dlg=MessageBox.Show(lan.Change_language_MessageText("Bạn có muốn kiểm tra lại tiền thuốc của Bệnh nhân không ?"),lan.Change_language_MessageText("Tiền thuốc"),MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
				if(DialogResult.Yes==dlg)
				{
					DateTime dt1=d.StringToDate(ngayvao.Text).AddDays(-d.iNgaykiemke);
					DateTime dt2=d.StringToDate(ngayra.Text).AddDays(d.iNgaykiemke);
					int y1=dt1.Year,m1=dt1.Month;
					int y2=dt2.Year,m2=dt2.Month;
					int itu,iden;
					string mmyy="";		
					for(int i=y1;i<=y2;i++)
					{
						itu=(i==y1)?m1:1;
						iden=(i==y2)?m2:12;
						for(int j=itu;j<=iden;j++)
						{
							mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
							if (d.bMmyy(mmyy) && mmyy!="06005")
							{
								d.kiemtratienthuoc(mmyy,mabn.Text,l_maql);								
							}
						}
					}					
				}
				else
					return;
			}
		}

	}
}