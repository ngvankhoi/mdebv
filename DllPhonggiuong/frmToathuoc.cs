using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;
using LibDuoc;
using LibMedi;

namespace DllPhonggiuong
{
	public class frmToathuoc : System.Windows.Forms.Form
	{
		Language lan = new Language();
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.TextBox tenkp;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox tuoi;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox ngay;
		private System.Windows.Forms.TextBox tenbs;
		private System.Windows.Forms.TextBox chandoan;
		private System.Windows.Forms.TextBox maicd;
		private MaskedTextBox.MaskedTextBox ghichu;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private MaskedTextBox.MaskedTextBox soluong;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox cachdung;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.TextBox stt;
		private LibDuoc.AccessData d;
		private LibMedi.AccessData m;
		private string s_makp,s_mabs,sql,s_ngay,s_diachi,s_tenbs,s_tenkp,s_phai;
		private long l_maql,l_id;
		private int i_userid,i_row,iSudung,i_ma;
		private bool bDanhmuc;
		private decimal d_soluong,soluong_max;
		private Print print=new Print();
		private DataTable dtkp=new DataTable();
		private DataTable dtbs=new DataTable();
		private DataTable dtll=new DataTable();
		private DataTable dtthuoc=new DataTable();
		private DataTable dtngay=new DataTable();
		private DataSet dsct=new DataSet();
		private DataSet dsxoa=new DataSet();
		private System.Windows.Forms.ComboBox cmbNgay;
		private System.Windows.Forms.TextBox ma;
		private System.Windows.Forms.Button butXoa;
		private System.Windows.Forms.Button butThem;
		private System.Windows.Forms.Label ltenhc;
		private System.Windows.Forms.TextBox tenhc;
		private System.Windows.Forms.TextBox ten;
		private System.Windows.Forms.TextBox dvt;
		private System.Windows.Forms.TextBox mabs;
		private System.Windows.Forms.Button butHen;
		private LibList.List listCachdung;
		private LibList.List listDang;
		private LibList.List listThuoc;
		private LibList.List listDMBS;
		private System.Windows.Forms.CheckBox chkXML;
		private System.Windows.Forms.CheckBox chkXem;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmToathuoc(LibMedi.AccessData acc,string s_mabn,string s_hoten,string s_tuoi,string ngayvv,string makp,string tenkp,string mabs,string tenbs,string s_chandoan,string s_icd,long maql,int userid,string diachi,string _phai)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			d=new LibDuoc.AccessData();
			m=acc;mabn.Text=s_mabn;hoten.Text=s_hoten;
			tuoi.Text=s_tuoi;s_ngay=ngayvv;
			ngay.Text=s_ngay;s_makp=makp;s_mabs=mabs;
			s_diachi=diachi;s_tenkp=tenkp;s_tenbs=tenbs;
			chandoan.Text=s_chandoan;maicd.Text=s_icd;
			l_maql=maql;i_userid=userid;s_phai=_phai;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmToathuoc));
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.tenkp = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.hoten = new System.Windows.Forms.TextBox();
			this.tuoi = new System.Windows.Forms.TextBox();
			this.mabn = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.ngay = new System.Windows.Forms.TextBox();
			this.tenbs = new System.Windows.Forms.TextBox();
			this.chandoan = new System.Windows.Forms.TextBox();
			this.maicd = new System.Windows.Forms.TextBox();
			this.ghichu = new MaskedTextBox.MaskedTextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.tenhc = new System.Windows.Forms.TextBox();
			this.ltenhc = new System.Windows.Forms.Label();
			this.ten = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.soluong = new MaskedTextBox.MaskedTextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.cachdung = new System.Windows.Forms.TextBox();
			this.butKetthuc = new System.Windows.Forms.Button();
			this.butHuy = new System.Windows.Forms.Button();
			this.butBoqua = new System.Windows.Forms.Button();
			this.butLuu = new System.Windows.Forms.Button();
			this.butSua = new System.Windows.Forms.Button();
			this.butMoi = new System.Windows.Forms.Button();
			this.butIn = new System.Windows.Forms.Button();
			this.stt = new System.Windows.Forms.TextBox();
			this.cmbNgay = new System.Windows.Forms.ComboBox();
			this.ma = new System.Windows.Forms.TextBox();
			this.butXoa = new System.Windows.Forms.Button();
			this.butThem = new System.Windows.Forms.Button();
			this.dvt = new System.Windows.Forms.TextBox();
			this.mabs = new System.Windows.Forms.TextBox();
			this.butHen = new System.Windows.Forms.Button();
			this.listCachdung = new LibList.List();
			this.listDang = new LibList.List();
			this.listDMBS = new LibList.List();
			this.listThuoc = new LibList.List();
			this.chkXML = new System.Windows.Forms.CheckBox();
			this.chkXem = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// treeView1
			// 
			this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.treeView1.ImageIndex = -1;
			this.treeView1.Location = new System.Drawing.Point(573, 5);
			this.treeView1.Name = "treeView1";
			this.treeView1.SelectedImageIndex = -1;
			this.treeView1.Size = new System.Drawing.Size(187, 291);
			this.treeView1.TabIndex = 0;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			// 
			// dataGrid1
			// 
			this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
			this.dataGrid1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
			this.dataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.FlatMode = true;
			this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
			this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
			this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
			this.dataGrid1.Location = new System.Drawing.Point(8, 85);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
			this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.RowHeaderWidth = 10;
			this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
			this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid1.Size = new System.Drawing.Size(560, 235);
			this.dataGrid1.TabIndex = 15;
			this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
			// 
			// tenkp
			// 
			this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tenkp.Enabled = false;
			this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tenkp.Location = new System.Drawing.Point(340, 31);
			this.tenkp.Name = "tenkp";
			this.tenkp.Size = new System.Drawing.Size(228, 21);
			this.tenkp.TabIndex = 5;
			this.tenkp.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(261, 31);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 23);
			this.label4.TabIndex = 25;
			this.label4.Text = "Khoa/phòng :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// hoten
			// 
			this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
			this.hoten.Enabled = false;
			this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.hoten.Location = new System.Drawing.Point(161, 8);
			this.hoten.Name = "hoten";
			this.hoten.Size = new System.Drawing.Size(143, 21);
			this.hoten.TabIndex = 1;
			this.hoten.Text = "";
			// 
			// tuoi
			// 
			this.tuoi.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tuoi.Enabled = false;
			this.tuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tuoi.Location = new System.Drawing.Point(340, 8);
			this.tuoi.Name = "tuoi";
			this.tuoi.Size = new System.Drawing.Size(76, 21);
			this.tuoi.TabIndex = 2;
			this.tuoi.Text = "";
			// 
			// mabn
			// 
			this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
			this.mabn.Enabled = false;
			this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mabn.Location = new System.Drawing.Point(61, 8);
			this.mabn.Name = "mabn";
			this.mabn.Size = new System.Drawing.Size(56, 21);
			this.mabn.TabIndex = 0;
			this.mabn.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(306, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 23);
			this.label3.TabIndex = 23;
			this.label3.Text = "Tuổi :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(113, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 23);
			this.label2.TabIndex = 21;
			this.label2.Text = "Họ tên :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(15, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 23);
			this.label1.TabIndex = 19;
			this.label1.Text = "Mã BN :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(416, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 23);
			this.label5.TabIndex = 27;
			this.label5.Text = "Ngày :";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(0, 31);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 23);
			this.label6.TabIndex = 28;
			this.label6.Text = "Bác sĩ :";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(-9, 54);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(72, 23);
			this.label7.TabIndex = 29;
			this.label7.Text = "Chẩn đoán :";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(488, 54);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(32, 23);
			this.label8.TabIndex = 30;
			this.label8.Text = "ICD :";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(0, 78);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(64, 23);
			this.label9.TabIndex = 31;
			this.label9.Text = "Ghi chú :";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ngay
			// 
			this.ngay.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ngay.Enabled = false;
			this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ngay.Location = new System.Drawing.Point(456, 8);
			this.ngay.Name = "ngay";
			this.ngay.Size = new System.Drawing.Size(112, 21);
			this.ngay.TabIndex = 3;
			this.ngay.Text = "";
			// 
			// tenbs
			// 
			this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tenbs.Enabled = false;
			this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tenbs.Location = new System.Drawing.Point(61, 31);
			this.tenbs.Name = "tenbs";
			this.tenbs.Size = new System.Drawing.Size(203, 21);
			this.tenbs.TabIndex = 4;
			this.tenbs.Text = "";
			this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
			this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
			// 
			// chandoan
			// 
			this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
			this.chandoan.Enabled = false;
			this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.chandoan.Location = new System.Drawing.Point(61, 54);
			this.chandoan.Name = "chandoan";
			this.chandoan.Size = new System.Drawing.Size(419, 21);
			this.chandoan.TabIndex = 6;
			this.chandoan.Text = "";
			// 
			// maicd
			// 
			this.maicd.BackColor = System.Drawing.SystemColors.HighlightText;
			this.maicd.Enabled = false;
			this.maicd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.maicd.Location = new System.Drawing.Point(520, 54);
			this.maicd.Name = "maicd";
			this.maicd.Size = new System.Drawing.Size(48, 21);
			this.maicd.TabIndex = 7;
			this.maicd.Text = "";
			// 
			// ghichu
			// 
			this.ghichu.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ghichu.Enabled = false;
			this.ghichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ghichu.Location = new System.Drawing.Point(61, 77);
			this.ghichu.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.ghichu.Name = "ghichu";
			this.ghichu.Size = new System.Drawing.Size(472, 21);
			this.ghichu.TabIndex = 8;
			this.ghichu.Text = "";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(-31, 328);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(111, 23);
			this.label10.TabIndex = 37;
			this.label10.Text = "Tên thuốc :";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tenhc
			// 
			this.tenhc.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tenhc.Enabled = false;
			this.tenhc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tenhc.Location = new System.Drawing.Point(432, 328);
			this.tenhc.Name = "tenhc";
			this.tenhc.Size = new System.Drawing.Size(328, 21);
			this.tenhc.TabIndex = 10;
			this.tenhc.Text = "";
			this.tenhc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenhc_KeyDown);
			// 
			// ltenhc
			// 
			this.ltenhc.Location = new System.Drawing.Point(360, 328);
			this.ltenhc.Name = "ltenhc";
			this.ltenhc.Size = new System.Drawing.Size(72, 23);
			this.ltenhc.TabIndex = 39;
			this.ltenhc.Text = "Hoạt chất :";
			this.ltenhc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ten
			// 
			this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ten.Enabled = false;
			this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ten.Location = new System.Drawing.Point(80, 328);
			this.ten.Name = "ten";
			this.ten.Size = new System.Drawing.Size(280, 21);
			this.ten.TabIndex = 9;
			this.ten.Text = "";
			this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
			this.ten.Validated += new System.EventHandler(this.ten_Validated);
			this.ten.TextChanged += new System.EventHandler(this.ten_TextChanged);
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(8, 352);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(72, 23);
			this.label12.TabIndex = 41;
			this.label12.Text = "ĐVT :";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(200, 352);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(56, 23);
			this.label13.TabIndex = 43;
			this.label13.Text = "Số lượng :";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// soluong
			// 
			this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
			this.soluong.Enabled = false;
			this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.soluong.Location = new System.Drawing.Point(256, 351);
			this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
			this.soluong.Name = "soluong";
			this.soluong.Size = new System.Drawing.Size(104, 21);
			this.soluong.TabIndex = 13;
			this.soluong.Text = "";
			this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(352, 352);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(80, 23);
			this.label14.TabIndex = 45;
			this.label14.Text = "Cách dùng :";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cachdung
			// 
			this.cachdung.BackColor = System.Drawing.SystemColors.HighlightText;
			this.cachdung.Enabled = false;
			this.cachdung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cachdung.Location = new System.Drawing.Point(432, 351);
			this.cachdung.Name = "cachdung";
			this.cachdung.Size = new System.Drawing.Size(328, 21);
			this.cachdung.TabIndex = 14;
			this.cachdung.Text = "";
			this.cachdung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cachdung_KeyDown);
			this.cachdung.TextChanged += new System.EventHandler(this.cachdung_TextChanged);
			// 
			// butKetthuc
			// 
			this.butKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("butKetthuc.Image")));
			this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butKetthuc.Location = new System.Drawing.Point(608, 381);
			this.butKetthuc.Name = "butKetthuc";
			this.butKetthuc.Size = new System.Drawing.Size(74, 28);
			this.butKetthuc.TabIndex = 23;
			this.butKetthuc.Text = "&Kết thúc";
			this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
			// 
			// butHuy
			// 
			this.butHuy.Image = ((System.Drawing.Bitmap)(resources.GetObject("butHuy.Image")));
			this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butHuy.Location = new System.Drawing.Point(482, 381);
			this.butHuy.Name = "butHuy";
			this.butHuy.Size = new System.Drawing.Size(64, 28);
			this.butHuy.TabIndex = 21;
			this.butHuy.Text = "     &Hủy";
			this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
			// 
			// butBoqua
			// 
			this.butBoqua.Enabled = false;
			this.butBoqua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butBoqua.Image")));
			this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butBoqua.Location = new System.Drawing.Point(414, 381);
			this.butBoqua.Name = "butBoqua";
			this.butBoqua.Size = new System.Drawing.Size(65, 28);
			this.butBoqua.TabIndex = 18;
			this.butBoqua.Text = "&Bỏ qua";
			this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
			// 
			// butLuu
			// 
			this.butLuu.Enabled = false;
			this.butLuu.Image = ((System.Drawing.Bitmap)(resources.GetObject("butLuu.Image")));
			this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLuu.Location = new System.Drawing.Point(212, 381);
			this.butLuu.Name = "butLuu";
			this.butLuu.Size = new System.Drawing.Size(64, 28);
			this.butLuu.TabIndex = 17;
			this.butLuu.Text = "     &Lưu";
			this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
			// 
			// butSua
			// 
			this.butSua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butSua.Image")));
			this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSua.Location = new System.Drawing.Point(147, 381);
			this.butSua.Name = "butSua";
			this.butSua.Size = new System.Drawing.Size(62, 28);
			this.butSua.TabIndex = 20;
			this.butSua.Text = "     &Sửa";
			this.butSua.Click += new System.EventHandler(this.butSua_Click);
			// 
			// butMoi
			// 
			this.butMoi.Image = ((System.Drawing.Bitmap)(resources.GetObject("butMoi.Image")));
			this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butMoi.Location = new System.Drawing.Point(80, 381);
			this.butMoi.Name = "butMoi";
			this.butMoi.Size = new System.Drawing.Size(64, 28);
			this.butMoi.TabIndex = 0;
			this.butMoi.Text = "     &Mới";
			this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
			// 
			// butIn
			// 
			this.butIn.Image = ((System.Drawing.Bitmap)(resources.GetObject("butIn.Image")));
			this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butIn.Location = new System.Drawing.Point(549, 381);
			this.butIn.Name = "butIn";
			this.butIn.Size = new System.Drawing.Size(56, 28);
			this.butIn.TabIndex = 22;
			this.butIn.Text = "     &In";
			this.butIn.Click += new System.EventHandler(this.butIn_Click);
			// 
			// stt
			// 
			this.stt.Location = new System.Drawing.Point(16, 272);
			this.stt.Name = "stt";
			this.stt.Size = new System.Drawing.Size(48, 20);
			this.stt.TabIndex = 54;
			this.stt.Text = "";
			// 
			// cmbNgay
			// 
			this.cmbNgay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbNgay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmbNgay.Location = new System.Drawing.Point(456, 8);
			this.cmbNgay.Name = "cmbNgay";
			this.cmbNgay.Size = new System.Drawing.Size(112, 21);
			this.cmbNgay.TabIndex = 3;
			this.cmbNgay.SelectedIndexChanged += new System.EventHandler(this.cmbNgay_SelectedIndexChanged);
			// 
			// ma
			// 
			this.ma.Location = new System.Drawing.Point(64, 272);
			this.ma.Name = "ma";
			this.ma.Size = new System.Drawing.Size(80, 20);
			this.ma.TabIndex = 58;
			this.ma.Text = "";
			// 
			// butXoa
			// 
			this.butXoa.Enabled = false;
			this.butXoa.Image = ((System.Drawing.Bitmap)(resources.GetObject("butXoa.Image")));
			this.butXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butXoa.Location = new System.Drawing.Point(346, 381);
			this.butXoa.Name = "butXoa";
			this.butXoa.Size = new System.Drawing.Size(65, 28);
			this.butXoa.TabIndex = 16;
			this.butXoa.Text = "     &Xóa";
			this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
			// 
			// butThem
			// 
			this.butThem.Enabled = false;
			this.butThem.Image = ((System.Drawing.Bitmap)(resources.GetObject("butThem.Image")));
			this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butThem.Location = new System.Drawing.Point(279, 381);
			this.butThem.Name = "butThem";
			this.butThem.Size = new System.Drawing.Size(64, 28);
			this.butThem.TabIndex = 15;
			this.butThem.Text = "&Thêm";
			this.butThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butThem.Click += new System.EventHandler(this.butThem_Click);
			// 
			// dvt
			// 
			this.dvt.BackColor = System.Drawing.SystemColors.HighlightText;
			this.dvt.Enabled = false;
			this.dvt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dvt.Location = new System.Drawing.Point(80, 352);
			this.dvt.Name = "dvt";
			this.dvt.Size = new System.Drawing.Size(120, 21);
			this.dvt.TabIndex = 12;
			this.dvt.Text = "";
			this.dvt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dvt_KeyDown);
			this.dvt.Validated += new System.EventHandler(this.dvt_Validated);
			this.dvt.TextChanged += new System.EventHandler(this.dvt_TextChanged);
			// 
			// mabs
			// 
			this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
			this.mabs.Enabled = false;
			this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mabs.Location = new System.Drawing.Point(345, 221);
			this.mabs.Name = "mabs";
			this.mabs.Size = new System.Drawing.Size(32, 21);
			this.mabs.TabIndex = 100;
			this.mabs.Text = "";
			// 
			// butHen
			// 
			this.butHen.Location = new System.Drawing.Point(535, 77);
			this.butHen.Name = "butHen";
			this.butHen.Size = new System.Drawing.Size(33, 23);
			this.butHen.TabIndex = 101;
			this.butHen.Text = "Hẹn";
			this.butHen.Click += new System.EventHandler(this.butHen_Click);
			// 
			// listCachdung
			// 
			this.listCachdung.BackColor = System.Drawing.SystemColors.Info;
			this.listCachdung.ColumnCount = 0;
			this.listCachdung.Location = new System.Drawing.Point(336, 424);
			this.listCachdung.MatchBufferTimeOut = 1000;
			this.listCachdung.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
			this.listCachdung.Name = "listCachdung";
			this.listCachdung.Size = new System.Drawing.Size(75, 17);
			this.listCachdung.TabIndex = 105;
			this.listCachdung.TextIndex = -1;
			this.listCachdung.TextMember = null;
			this.listCachdung.ValueIndex = -1;
			this.listCachdung.Visible = false;
			// 
			// listDang
			// 
			this.listDang.BackColor = System.Drawing.SystemColors.Info;
			this.listDang.ColumnCount = 0;
			this.listDang.Location = new System.Drawing.Point(240, 424);
			this.listDang.MatchBufferTimeOut = 1000;
			this.listDang.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
			this.listDang.Name = "listDang";
			this.listDang.Size = new System.Drawing.Size(75, 17);
			this.listDang.TabIndex = 104;
			this.listDang.TextIndex = -1;
			this.listDang.TextMember = null;
			this.listDang.ValueIndex = -1;
			this.listDang.Visible = false;
			// 
			// listDMBS
			// 
			this.listDMBS.BackColor = System.Drawing.SystemColors.Info;
			this.listDMBS.ColumnCount = 0;
			this.listDMBS.Location = new System.Drawing.Point(152, 424);
			this.listDMBS.MatchBufferTimeOut = 1000;
			this.listDMBS.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
			this.listDMBS.Name = "listDMBS";
			this.listDMBS.Size = new System.Drawing.Size(75, 17);
			this.listDMBS.TabIndex = 103;
			this.listDMBS.TextIndex = -1;
			this.listDMBS.TextMember = null;
			this.listDMBS.ValueIndex = -1;
			this.listDMBS.Visible = false;
			// 
			// listThuoc
			// 
			this.listThuoc.BackColor = System.Drawing.SystemColors.Info;
			this.listThuoc.ColumnCount = 0;
			this.listThuoc.Location = new System.Drawing.Point(448, 424);
			this.listThuoc.MatchBufferTimeOut = 1000;
			this.listThuoc.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
			this.listThuoc.Name = "listThuoc";
			this.listThuoc.Size = new System.Drawing.Size(75, 17);
			this.listThuoc.TabIndex = 102;
			this.listThuoc.TextIndex = -1;
			this.listThuoc.TextMember = null;
			this.listThuoc.ValueIndex = -1;
			this.listThuoc.Visible = false;
			this.listThuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listThuoc_KeyDown);
			// 
			// chkXML
			// 
			this.chkXML.Location = new System.Drawing.Point(680, 304);
			this.chkXML.Name = "chkXML";
			this.chkXML.Size = new System.Drawing.Size(104, 16);
			this.chkXML.TabIndex = 106;
			this.chkXML.Text = "Xuất ra XML";
			// 
			// chkXem
			// 
			this.chkXem.Location = new System.Drawing.Point(576, 304);
			this.chkXem.Name = "chkXem";
			this.chkXem.Size = new System.Drawing.Size(104, 16);
			this.chkXem.TabIndex = 107;
			this.chkXem.Text = "Xem trước khi in";
			// 
			// frmToathuoc
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(762, 447);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.chkXem,
																		  this.chkXML,
																		  this.listCachdung,
																		  this.listDang,
																		  this.listDMBS,
																		  this.listThuoc,
																		  this.butXoa,
																		  this.butThem,
																		  this.butIn,
																		  this.butKetthuc,
																		  this.butHuy,
																		  this.butBoqua,
																		  this.butLuu,
																		  this.butSua,
																		  this.butMoi,
																		  this.butHen,
																		  this.dvt,
																		  this.soluong,
																		  this.tenhc,
																		  this.tuoi,
																		  this.cmbNgay,
																		  this.cachdung,
																		  this.label14,
																		  this.label13,
																		  this.label12,
																		  this.ten,
																		  this.ltenhc,
																		  this.label10,
																		  this.ghichu,
																		  this.maicd,
																		  this.chandoan,
																		  this.tenbs,
																		  this.ngay,
																		  this.label9,
																		  this.label8,
																		  this.label7,
																		  this.label6,
																		  this.label5,
																		  this.tenkp,
																		  this.label4,
																		  this.hoten,
																		  this.mabn,
																		  this.label3,
																		  this.label2,
																		  this.label1,
																		  this.dataGrid1,
																		  this.treeView1,
																		  this.stt,
																		  this.ma,
																		  this.mabs});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmToathuoc";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Đơn thuốc";
			this.Load += new System.EventHandler(this.frmToathuoc_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmToathuoc_Load(object sender, System.EventArgs e)
		{
			chkXem.Checked=m.bPreview;
			soluong_max=m.Soluong_max;
			bDanhmuc=m.bDanhmucthuocbv;
			listDMBS.DisplayMember="MA";
			listDMBS.ValueMember="HOTEN";
			dtbs=d.get_data("select ma,hoten from dmbs where nhom not in ("+LibMedi.AccessData.nhanvien+","+LibMedi.AccessData.nghiviec+") order by hoten").Tables[0];
			listDMBS.DataSource=dtbs;
			tenkp.Text=s_tenkp;
			tenbs.Text=s_tenbs;
			listCachdung.DisplayMember="TEN";
			listCachdung.ValueMember="TEN";
			load_cachdung();
			listThuoc.DisplayMember="ID";
			listThuoc.ValueMember="TEN";
			load_thuoc();
			listDang.DisplayMember="TEN";
			listDang.ValueMember="TEN";
			load_dang();
			dsxoa.ReadXml("..\\..\\..\\xml\\d_toathuocct.xml");
			iSudung=m.iSudungthuoc;
			dtkp=m.get_data("select * from btdkp_bv").Tables[0];
			cmbNgay.DisplayMember="NGAY";
			cmbNgay.ValueMember="ID";
			load_ngay();
			load_head();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

			ref_text();
			if (iSudung!=3) load_treeView();
		}

		private void load_ngay()
		{
			dtll=m.get_data("select id,makp,chandoan,maicd,mabs,ghichu,to_char(ngay,'dd/mm/yyyy hh24:mi') NGAY,lan from d_toathuocll where maql="+l_maql).Tables[0];
			cmbNgay.DataSource=dtll;
			if (dtll.Rows.Count>0) l_id=long.Parse(cmbNgay.SelectedValue.ToString());
			else l_id=0;
		}

		private void load_head()
		{
			DataRow r=m.getrowbyid(dtll,"id="+l_id);
			if (r!=null)
			{
				DataRow r1;
				s_makp=r["makp"].ToString();
				s_mabs=r["mabs"].ToString();
				s_ngay=r["ngay"].ToString();
				chandoan.Text=r["chandoan"].ToString();
				maicd.Text=r["maicd"].ToString();
				ghichu.Text=r["ghichu"].ToString();
				r1=m.getrowbyid(dtkp,"makp='"+s_makp+"'");
				if (r1!=null) tenkp.Text=r1["tenkp"].ToString();
				r1=m.getrowbyid(dtbs,"ma='"+s_mabs+"'");
				if (r1!=null) tenbs.Text=r1["hoten"].ToString();
			}
			load_grid();
		}

		private void load_grid()
		{
			sql="select a.stt,a.mabd,b.ten,b.dang,nvl(b.tenhc,' ') tenhc,a.soluong,a.cachdung from d_toathuocct a,d_dmthuoc b";
			sql+=" where a.mabd=b.id and a.id="+l_id+" order by a.stt";
			dsct=m.get_data(sql);
			dataGrid1.DataSource=dsct.Tables[0];
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
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.ReadOnly=false;
			ts.RowHeaderWidth=10;
						
			DataGridTextBoxColumn TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "stt";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "mabd";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenhc";
			TextCol.HeaderText = "Tên hoạt chất";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên thuốc";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "soluong";
			TextCol.HeaderText = "Số lượng";
			TextCol.Width = 50;
			TextCol.Format="### ###.00";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "cachdung";
			TextCol.HeaderText = "Cách dùng";
			TextCol.Width = 127;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}

		private void ref_text()
		{
			try
			{
				i_row=dataGrid1.CurrentCell.RowNumber;
				stt.Text=dataGrid1[i_row,0].ToString();
				ma.Text=dataGrid1[i_row,1].ToString();
				ten.Text=dataGrid1[i_row,3].ToString();
				dvt.Text=dataGrid1[i_row,4].ToString();
				tenhc.Text=dataGrid1[i_row,2].ToString();
				d_soluong=decimal.Parse(dataGrid1[i_row,5].ToString());
				soluong.Text=d_soluong.ToString("###,###.00");
				cachdung.Text=dataGrid1[i_row,6].ToString();
			}
			catch{}
		}

		private void load_cachdung()
		{
			listCachdung.DataSource=m.get_data("select ten,ten stt from d_dmcachdung order by stt,ten").Tables[0];
		}

		private void load_dang()
		{
			listDang.DataSource=d.get_data("select * from d_dmdvt order by stt").Tables[0];
		}

		private void load_thuoc()
		{
			if (bDanhmuc) sql="select a.id,trim(a.ten)||' '||trim(a.hamluong) ten,a.tenhc,a.dang,a.mahc from d_dmbd a,d_dmnhomkho b where a.nhom=b.id and b.loai=1 order by a.tenhc";
			else sql="select id,ten,tenhc,dang,cachdung from d_dmthuoc where hide=0 order by stt,ten";
			dtthuoc=m.get_data(sql).Tables[0];
			listThuoc.DataSource=dtthuoc;
		}

		private void Filter_cachdung(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listCachdung.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void Filter_thuoc(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listThuoc.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ten like '%"+ten.Trim()+"%' or tenhc like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void ten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listThuoc.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listThuoc.Visible && bDanhmuc) listThuoc.Focus();
				else
				{
					listThuoc.Hide();
					SendKeys.Send("{Tab}");
				}
			}		
		}

		private void ten_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==ten)
			{
				Filter_thuoc(ten.Text);
				if (tenhc.Enabled)
					listThuoc.BrowseToToathuoc(ten,ma,tenhc,ten.Width+ltenhc.Width+tenhc.Width);
				else
					listThuoc.BrowseToToathuoc(ten,ma,soluong,ten.Width+ltenhc.Width+tenhc.Width);
			}
		}

		private void soluong_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (soluong.Text=="") soluong.Text="1";
				d_soluong=decimal.Parse(soluong.Text);
				if (soluong_max!=0 && d_soluong>soluong_max && m.Hoten_khongdau(dvt.Text)=="VIEN")
				{
					if (MessageBox.Show("Có đúng số lượng "+d_soluong.ToString("###,###,###.00")+" không ?",LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No)
					{
						soluong.Focus();
						return;
					}
				}
				soluong.Text=d_soluong.ToString("###,###.00");
			}
			catch{soluong.Text="1";}
		}

		private void cachdung_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listCachdung.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listCachdung.Visible) listCachdung.Focus();
				else SendKeys.Send("{Tab}");
			}		
		}

		private void cachdung_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cachdung)
			{
				Filter_cachdung(cachdung.Text);
				listCachdung.BrowseToDanhmuc(cachdung,cachdung,butThem,0);
			}		
		}

		private void cmbNgay_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cmbNgay)
			{
				try
				{
					l_id=long.Parse(cmbNgay.SelectedValue.ToString());
				}
				catch{l_id=0;}
				load_head();
			}
		}

		private void ena_object(bool ena)
		{
			dsxoa.Clear();
			cmbNgay.Visible=!ena;
			if (s_mabs=="") tenbs.Enabled=ena;
			ghichu.Enabled=ena;
			ten.Enabled=ena;
			soluong.Enabled=ena;
			cachdung.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butThem.Enabled=ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butXoa.Enabled=ena;
			butIn.Enabled=!ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			if (!bDanhmuc)
			{
				dvt.Enabled=ena;
				tenhc.Enabled=ena;
			}
			if (ena) load_thuoc();
			if (ena && l_id==0)
			{
				dsct.Clear();
				ghichu.Text="";
				emp_item();
			}
			else butMoi.Focus();
		}

		private void emp_item()
		{
			stt.Text=m.get_stt(dsct.Tables[0]).ToString();
			ten.Text="";
			tenhc.Text="";
			dvt.Text="";
			soluong.Text="";
			cachdung.Text="";
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			l_id=0;
			ena_object(true);
			if (tenbs.Enabled) tenbs.Focus();
			else ghichu.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (dtll.Rows.Count==0) return;
			try
			{
				l_id=long.Parse(cmbNgay.SelectedValue.ToString());
			}
			catch{}
			if (m.getrowbyid(dtll,"lan>0 and id="+l_id)!=null)
			{
				MessageBox.Show("Đơn thuốc này đã in !",LibMedi.AccessData.Msg);
				return;
			}
			ena_object(true);
			dsxoa.Clear();
			ghichu.Focus();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!add_item(true)) return;
			if (tenbs.Enabled)
			{
				DataRow r=d.getrowbyid(dtbs,"hoten='"+tenbs.Text+"'");
				if (r==null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Họ tên bác sĩ không hợp lệ !"),d.Msg);
					tenbs.Focus();
					return;
				}
				else s_mabs=r["ma"].ToString();
			}
			if (dsct.Tables[0].Rows.Count==0)
			{
				MessageBox.Show("Đề nghị nhập thuốc !",LibMedi.AccessData.Msg);
				butThem.Focus();
				return;
			}
			if (l_id==0)
			{
				if (dsct.Tables[0].Rows.Count==0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập thuốc !"),LibMedi.AccessData.Msg);
					return;
				}
				l_id=d.get_id_toathuoc;
			}
			if (!d.upd_toathuocll(l_id,0,mabn.Text,l_maql,s_ngay,s_makp,chandoan.Text,maicd.Text,s_mabs,ghichu.Text,i_userid))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin"),LibMedi.AccessData.Msg);
				return;
			}
			foreach(DataRow r in dsxoa.Tables[0].Rows) m.execute_data("delete from d_toathuocct where id="+l_id+" and stt="+int.Parse(r["stt"].ToString()));
			foreach(DataRow r in dsct.Tables[0].Rows)
			{
				try
				{
					i_ma=int.Parse(r["mabd"].ToString());
					if (bDanhmuc)
						d.upd_dmthuoc(i_ma,r["ten"].ToString(),r["dang"].ToString(),r["cachdung"].ToString(),r["tenhc"].ToString());
					else
					{
						i_ma=d.get_dmthuoc(r["ten"].ToString(),r["dang"].ToString(),r["cachdung"].ToString(),r["tenhc"].ToString());
						m.updrec_toathuocct(dsct.Tables[0],int.Parse(r["stt"].ToString()),i_ma,r["ten"].ToString(),r["dang"].ToString(),r["tenhc"].ToString(),decimal.Parse(r["soluong"].ToString()),r["cachdung"].ToString());
					}
					d.upd_toathuocct(l_id,int.Parse(r["stt"].ToString()),i_ma,decimal.Parse(r["soluong"].ToString()),r["cachdung"].ToString());
				}
				catch(Exception ex){MessageBox.Show(ex.Message);}
			}
			m.updrec_toathuocll(dtll,l_id,s_ngay,s_makp,s_mabs,chandoan.Text,maicd.Text,ghichu.Text);
			DataRow [] dr=dtll.Select("id="+l_id);
			if (dr.Length>0) dr[0]["lan"]=0;
			ref_text();
			ena_object(false);
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			try
			{
				l_id=long.Parse(cmbNgay.SelectedValue.ToString());
				load_head();
				load_grid();
				ref_text();
			}
			catch{}
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (dtll.Rows.Count==0) return;
			if (m.getrowbyid(dtll,"lan>0 and id="+l_id)!=null)
			{
				MessageBox.Show("Đơn thuốc này đã in !",LibMedi.AccessData.Msg);
				return;
			}
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
				m.execute_data("delete from d_toathuocct where id="+l_id);
				m.execute_data("delete from d_toathuocll where id="+l_id);
				m.delrec(dtll,"id="+l_id);
				dtll.AcceptChanges();
				if (dtll.Rows.Count>0) l_id=long.Parse(cmbNgay.SelectedValue.ToString());
				else l_id=0;
				load_head();
				ref_text();
			}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			DataSet tmp=new DataSet();
			tmp=dsct.Copy();
			foreach(DataRow r in tmp.Tables[0].Rows) r["mabd"]=0;
			string schandoan=chandoan.Text.Trim()+";";
			foreach(DataRow r in m.get_data("select chandoan from cdkemtheo where maql="+l_maql+" order by stt").Tables[0].Rows)
				schandoan+=r["chandoan"].ToString()+";";
			if(Directory.Exists("c:\\reportpic")==false)Directory.CreateDirectory("c:\\reportpic");
			if(Directory.Exists("..\\..\\..\\chuky\\")==false)Directory.CreateDirectory("..\\..\\..\\chuky\\");
			if(File.Exists("..\\..\\..\\chuky\\"+s_mabs+".bmp")==true)
				File.Copy("..\\..\\..\\chuky\\"+s_mabs+".bmp","c:\\reportpic\\chuky.bmp",true);
			else
				File.Copy("..\\..\\..\\xml\\000.bmp","c:\\reportpic\\chuky.bmp",true);
			if (chkXML.Checked)
			{
				if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
				dsct.WriteXml("..\\xml\\toathuoc.xml",XmlWriteMode.WriteSchema);
			}
			if (chkXem.Checked)
			{
				frmReport f=new frmReport(m,tmp.Tables[0],"d_donthuoc_mn.rpt",hoten.Text,tuoi.Text,s_diachi,schandoan,ghichu.Text,tenbs.Text,dsct.Tables[0].Rows.Count.ToString(),mabn.Text,s_phai,cmbNgay.Text);
				f.ShowDialog(this);
			}
			else print.Printer(m,tmp,"d_donthuoc_mn.rpt",hoten.Text,tuoi.Text,s_diachi,schandoan,ghichu.Text,tenbs.Text,dsct.Tables[0].Rows.Count.ToString(),mabn.Text,s_phai,cmbNgay.Text,1,1);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
			if (!add_item(false)) return;
			emp_item();
			ten.Focus();
		}

		private void butXoa_Click(object sender, System.EventArgs e)
		{
			if (dsct.Tables[0].Rows.Count==0) return;
			m.updrec_toathuocct(dsxoa.Tables[0],int.Parse(stt.Text),int.Parse(ma.Text),ten.Text,dvt.Text,tenhc.Text,decimal.Parse(soluong.Text),cachdung.Text);
			m.delrec(dsct.Tables[0],"stt="+int.Parse(stt.Text));
			dsct.AcceptChanges();
			dsxoa.AcceptChanges();
			if (dsct.Tables[0].Rows.Count==0) emp_item();
			else ref_text();
		}

		private bool add_item(bool skip)
		{
			if (skip && (ten.Text=="" || ma.Text=="" || soluong.Text=="")) return true;
			if (!bDanhmuc) ma.Text="0";
			if (ten.Text=="" || ma.Text=="")
			{
				ten.Focus();
				return false;
			}
			if (soluong.Text=="")
			{
				soluong.Focus();
				return false;
			}
			if (stt.Text=="" || stt.Text=="0") stt.Text=m.get_stt(dsct.Tables[0]).ToString();
			m.updrec_toathuocct(dsct.Tables[0],int.Parse(stt.Text),int.Parse(ma.Text),ten.Text,dvt.Text,tenhc.Text,decimal.Parse(soluong.Text),cachdung.Text);
			return true;
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void listThuoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				try
				{
					DataRow r=m.getrowbyid(dtthuoc,"id="+int.Parse(ma.Text));
					if (r!=null)
					{
						tenhc.Text=r["tenhc"].ToString();
						ten.Text=r["ten"].ToString();
						dvt.Text=r["dang"].ToString();
						if (!bDanhmuc) cachdung.Text=r["cachdung"].ToString();
					}
				}
				catch{}
			}
		}

		private void load_treeView()
		{
			treeView1.Nodes.Clear();
			TreeNode node;
			sql="select b.id,to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngay,a.maql from benhandt a,d_toathuocll b where a.maql=b.maql and a.loaiba=3";
			if (iSudung==1) sql+=" and a.mabn='"+mabn.Text+"'";
			else sql+=" and a.maql='"+l_maql+"'";
			sql+=" order by a.ngay desc";
			dtngay=m.get_data(sql).Tables[0];
			foreach(DataRow r in dtngay.Rows)
			{
				node=treeView1.Nodes.Add(r["ngay"].ToString());
				sql="select trim(b.ten)||' '||trim(b.hamluong)||' '||trim(b.dang) tenbd,a.soluong from d_toathuocct a,d_dmbd b where a.mabd=b.id";
				sql+=" and a.id="+decimal.Parse(r["id"].ToString());
				sql+=" order by a.stt";
				foreach(DataRow r1 in m.get_data(sql).Tables[0].Rows)
					node.Nodes.Add(r1["tenbd"].ToString().Trim()+"("+r1["soluong"].ToString().Trim()+")");
			}
		}

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (e.Action==TreeViewAction.ByMouse)
			{
				try
				{
					string s=e.Node.FullPath.Trim();
					int iPos=s.IndexOf("/");
					s_ngay=s.Substring(iPos-2,16);
					DataRow r=m.getrowbyid(dtngay,"ngay='"+s_ngay+"'");
					if (r!=null)
					{
						l_maql=long.Parse(r["maql"].ToString());
						load_ngay();
						load_head();
						load_grid();
						ref_text();
					}
				}
				catch{}
			}
		}

		private void ten_Validated(object sender, System.EventArgs e)
		{
//			if (!bDanhmuc && tenhc.Text=="")
//			{
//				listThuoc.Hide();
//				tenhc.Text=tenhc.Text;
//				if (ten.Enabled) tenhc.Focus();
//			}
		}

		private void tenhc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void dvt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDang.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listDang.Visible) listDang.Focus();
				else SendKeys.Send("{Tab}");
			}
		}

		private void dvt_TextChanged(object sender, System.EventArgs e)
		{
			Filter(dvt.Text,listDang);
			listDang.BrowseToDanhmuc(dvt,soluong,0);
		}

		private void dvt_Validated(object sender, System.EventArgs e)
		{
			if(!listDang.Focused) listDang.Hide();
		}

		private void Filter(string ten,LibList.List list)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[list.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void tenbs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDMBS.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listDMBS.Visible) listDMBS.Focus();
				else SendKeys.Send("{Tab}");
			}		
		}

		private void Filt_dmbs(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDMBS.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="hoten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void tenbs_TextChanged(object sender, System.EventArgs e)
		{
			Filt_dmbs(tenbs.Text);
			listDMBS.BrowseToDanhmuc(tenbs,mabs,ghichu);
		}

		private void butHen_Click(object sender, System.EventArgs e)
		{
			try
			{
				Lichhen.LICHHEN f=new Lichhen.LICHHEN(mabn.Text,l_maql,s_makp,s_mabs,0,3);
				f.ShowDialog(this);
				if (f.strGhichu!="") ghichu.Text=f.strGhichu.Trim();
			}
			catch{}
		}

		private void butKhaibao_Click(object sender, System.EventArgs e)
		{
			if (dsct.Tables[0].Rows.Count>0)
			{
				long id_donthuoc=d.get_id_donthuoc_bacsy(s_mabs,maicd.Text);
				if (id_donthuoc!=0) d.execute_data("delete from d_theodonct where id="+id_donthuoc);
				else id_donthuoc=d.get_id_donthuoc_bacsy();
				d.upd_theodonll(id_donthuoc,s_mabs,maicd.Text,ghichu.Text,1,1,1);
				foreach(DataRow r in dsct.Tables[0].Rows)
					d.upd_theodonct(id_donthuoc,int.Parse(r["mabd"].ToString()),decimal.Parse(r["soluong"].ToString()),r["cachdung"].ToString());
			}
			butMoi.Focus();
		}

		private void butTheo_Click(object sender, System.EventArgs e)
		{
			long id_donthuoc=d.get_id_donthuoc_bacsy(s_mabs,maicd.Text);
			if (id_donthuoc!=0)
			{
				string tenfile=(bDanhmuc)?"d_dmbd":"d_dmthuoc";
				sql="select a.mabd,b.ten,b.dang,nvl(b.tenhc,' ') tenhc,a.soluong,a.cachdung from d_theodonct a,"+tenfile+" b";
				sql+=" where a.mabd=b.id and a.id="+id_donthuoc;
				foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
					m.updrec_toathuocct(dsct.Tables[0],m.get_stt(dsct.Tables[0]),int.Parse(r["mabd"].ToString()),r["ten"].ToString(),r["dang"].ToString(),r["tenhc"].ToString(),decimal.Parse(r["soluong"].ToString()),r["cachdung"].ToString());
				ref_text();
			}
			else MessageBox.Show("Không có trong danh mục !",LibMedi.AccessData.Msg);
		}
	}
}
