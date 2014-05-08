using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using LibDuoc;
using LibMedi;
using LibVienphi;

namespace DllPhonggiuong
{
	public class frmBaohiem : System.Windows.Forms.Form
	{
		Language lang = new Language();
		private System.Windows.Forms.Label label1;
		private MaskedTextBox.MaskedTextBox mabn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.TextBox tenbd;
		private System.Windows.Forms.TextBox tenhc;
		private System.Windows.Forms.Label lTenhc;
		private System.Windows.Forms.TextBox mabd;
		private System.Windows.Forms.Label lTen;
		private System.Windows.Forms.Label lMabd;
		private MaskedTextBox.MaskedTextBox soluong;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label ldvt;
		private System.Windows.Forms.TextBox cachdung;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butXoa;
		private System.Windows.Forms.Button butThem;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butCholai;
		private System.Windows.Forms.ComboBox cmbMabn;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private LibMedi.AccessData v=new LibMedi.AccessData();
		private int i_nhom,i_userid,i_old,i_mabd,i_loai,i_sudungthuoc,i_madoituong,i_bhyt_inrieng,i_loaiba,kho_dtngoaitru=0,iUserid_duyet;
		private string user,xxx,s_makho,s_ngay,sql,s_mmyy,s_manguon,s_msg,s_diachi,s_ngayht,nam,s_makho_makp,makp_dtngoaitru="";
		private string s_mabn,s_Hoten,s_Namsinh,s_Sothe,s_Tenkp,s_Tenbs,s_Maicd,s_Chandoan,s_makp,s_mabs,s_doituong,s_noidkkcb,s_madoituong,s_phai;
		private long l_id=0,l_maql;
		private decimal d_soluongcu,d_soluong,d_soluongton,d_lan,soluong_max;
		private bool bNew,bEdit,bDiungthuoc,bDone,bChidinh,bKiemtrathuoc,bSolan,bLetet,bDieutringtr,bSongay_donthuoc,bThuoc_1don,bDuyet,bKhoaso,bNgoaitonkho;
		private DataRow r;
		private DataTable dtton=new DataTable();
		private DataTable dtll=new DataTable();
		private DataTable dtct=new DataTable();
		private DataTable dtsave=new DataTable();
		private DataTable dtdmbd=new DataTable();
		private DataTable dtletet=new DataTable();
		private DataTable dtdon=new DataTable();
		private DataTable dtkp=new DataTable();
		private DataSet dsxoa=new DataSet();
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.ComboBox makho;
		private System.Windows.Forms.TextBox stt;
		private System.Windows.Forms.Label diung;
		private System.Windows.Forms.TextBox mahc;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.ComboBox manguon;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.TextBox namsinh;
		private System.Windows.Forms.TextBox sothe;
		private System.Windows.Forms.TextBox chandoan;
		private System.Windows.Forms.TextBox maicd;
		private System.Windows.Forms.TextBox tenpk;
		private System.Windows.Forms.TextBox tenbs;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button butIn;
		private Print print=new Print();
		private System.Windows.Forms.Button butHen;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox ghichu;
		private System.Windows.Forms.CheckBox chkVP;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.NumericUpDown solan;
		private MaskedTextBox.MaskedTextBox lan;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label dvt;
		private System.Windows.Forms.ComboBox donthuoc;
		private System.Windows.Forms.CheckBox chkChon;
		private System.Windows.Forms.NumericUpDown songay;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.ComboBox madoituong;
		private LibList.List listCachdung;
		private LibList.List listDmbd;
		private System.Windows.Forms.TextBox dang;
		private System.Windows.Forms.CheckBox chkThuoc;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmBaohiem(bool dieutringtr,string mabn,int loai,string mmyy,string ngay,int nhom,int userid,string title,long lMaql,string sHoten,string sNamsinh,string sSothe,string sTenkp,string sTenbs,string sMaicd,string sChandoan,int madoituong,string makp,string mabs,string doituong,string diachi,string _nam,int loaiba,string makho,string _madoituong,string _noidkkcb,string _phai)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lang.Read_Language_to_Xml(this.Name.ToString(),this);
			lang.Changelanguage_to_English(this.Name.ToString(),this);
			s_mmyy=mmyy;s_ngay=ngay;i_loai=loai;
			s_mabn=mabn;l_maql=lMaql;bDieutringtr=dieutringtr;
			s_Hoten=sHoten;s_Namsinh=sNamsinh;s_noidkkcb=_noidkkcb;
			s_Sothe=sSothe;s_Tenkp=sTenkp;s_Tenbs=sTenbs;s_Maicd=sMaicd;s_Chandoan=sChandoan;
			i_userid=userid;s_makp=makp;s_mabs=mabs;nam=_nam;s_madoituong=_madoituong;
			i_nhom=nhom;i_madoituong=madoituong;s_doituong=doituong;s_phai=_phai;
			this.Text=title;s_diachi=diachi;i_loaiba=loaiba;s_makho=makho;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmBaohiem));
			this.label1 = new System.Windows.Forms.Label();
			this.mabn = new MaskedTextBox.MaskedTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.hoten = new System.Windows.Forms.TextBox();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.tenbd = new System.Windows.Forms.TextBox();
			this.tenhc = new System.Windows.Forms.TextBox();
			this.lTenhc = new System.Windows.Forms.Label();
			this.mabd = new System.Windows.Forms.TextBox();
			this.lTen = new System.Windows.Forms.Label();
			this.lMabd = new System.Windows.Forms.Label();
			this.soluong = new MaskedTextBox.MaskedTextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.ldvt = new System.Windows.Forms.Label();
			this.cachdung = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.butKetthuc = new System.Windows.Forms.Button();
			this.butHuy = new System.Windows.Forms.Button();
			this.butBoqua = new System.Windows.Forms.Button();
			this.butXoa = new System.Windows.Forms.Button();
			this.butThem = new System.Windows.Forms.Button();
			this.butLuu = new System.Windows.Forms.Button();
			this.butSua = new System.Windows.Forms.Button();
			this.butMoi = new System.Windows.Forms.Button();
			this.butCholai = new System.Windows.Forms.Button();
			this.cmbMabn = new System.Windows.Forms.ComboBox();
			this.label20 = new System.Windows.Forms.Label();
			this.makho = new System.Windows.Forms.ComboBox();
			this.stt = new System.Windows.Forms.TextBox();
			this.diung = new System.Windows.Forms.Label();
			this.mahc = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.manguon = new System.Windows.Forms.ComboBox();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.namsinh = new System.Windows.Forms.TextBox();
			this.sothe = new System.Windows.Forms.TextBox();
			this.chandoan = new System.Windows.Forms.TextBox();
			this.maicd = new System.Windows.Forms.TextBox();
			this.tenpk = new System.Windows.Forms.TextBox();
			this.tenbs = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.butIn = new System.Windows.Forms.Button();
			this.butHen = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.ghichu = new System.Windows.Forms.TextBox();
			this.chkVP = new System.Windows.Forms.CheckBox();
			this.label11 = new System.Windows.Forms.Label();
			this.solan = new System.Windows.Forms.NumericUpDown();
			this.lan = new MaskedTextBox.MaskedTextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.dvt = new System.Windows.Forms.Label();
			this.donthuoc = new System.Windows.Forms.ComboBox();
			this.chkChon = new System.Windows.Forms.CheckBox();
			this.songay = new System.Windows.Forms.NumericUpDown();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.madoituong = new System.Windows.Forms.ComboBox();
			this.listCachdung = new LibList.List();
			this.listDmbd = new LibList.List();
			this.dang = new System.Windows.Forms.TextBox();
			this.chkThuoc = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.solan)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.songay)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Mã BN :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mabn
			// 
			this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
			this.mabn.Enabled = false;
			this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mabn.Location = new System.Drawing.Point(48, 6);
			this.mabn.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.mabn.MaxLength = 8;
			this.mabn.Name = "mabn";
			this.mabn.Size = new System.Drawing.Size(96, 21);
			this.mabn.TabIndex = 1;
			this.mabn.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(139, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Họ tên :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// hoten
			// 
			this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
			this.hoten.Enabled = false;
			this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.hoten.Location = new System.Drawing.Point(189, 6);
			this.hoten.Name = "hoten";
			this.hoten.Size = new System.Drawing.Size(211, 21);
			this.hoten.TabIndex = 2;
			this.hoten.Text = "";
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
			this.dataGrid1.Location = new System.Drawing.Point(9, 61);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
			this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.RowHeaderWidth = 5;
			this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
			this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid1.Size = new System.Drawing.Size(615, 243);
			this.dataGrid1.TabIndex = 28;
			this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
			// 
			// tenbd
			// 
			this.tenbd.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tenbd.Enabled = false;
			this.tenbd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tenbd.Location = new System.Drawing.Point(280, 308);
			this.tenbd.Name = "tenbd";
			this.tenbd.Size = new System.Drawing.Size(168, 21);
			this.tenbd.TabIndex = 7;
			this.tenbd.Text = "";
			this.tenbd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbd_KeyDown);
			this.tenbd.Validated += new System.EventHandler(this.tenbd_Validated);
			this.tenbd.TextChanged += new System.EventHandler(this.tenbd_TextChanged);
			// 
			// tenhc
			// 
			this.tenhc.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tenhc.Enabled = false;
			this.tenhc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tenhc.Location = new System.Drawing.Point(504, 308);
			this.tenhc.Name = "tenhc";
			this.tenhc.Size = new System.Drawing.Size(144, 21);
			this.tenhc.TabIndex = 8;
			this.tenhc.Text = "";
			// 
			// lTenhc
			// 
			this.lTenhc.Location = new System.Drawing.Point(432, 308);
			this.lTenhc.Name = "lTenhc";
			this.lTenhc.Size = new System.Drawing.Size(72, 23);
			this.lTenhc.TabIndex = 70;
			this.lTenhc.Text = "Hoạt chất :";
			this.lTenhc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mabd
			// 
			this.mabd.BackColor = System.Drawing.SystemColors.HighlightText;
			this.mabd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.mabd.Enabled = false;
			this.mabd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mabd.Location = new System.Drawing.Point(192, 308);
			this.mabd.Name = "mabd";
			this.mabd.Size = new System.Drawing.Size(60, 21);
			this.mabd.TabIndex = 6;
			this.mabd.Text = "";
			this.mabd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabd_KeyDown);
			this.mabd.TextChanged += new System.EventHandler(this.mabd_TextChanged);
			// 
			// lTen
			// 
			this.lTen.Location = new System.Drawing.Point(248, 308);
			this.lTen.Name = "lTen";
			this.lTen.Size = new System.Drawing.Size(32, 23);
			this.lTen.TabIndex = 69;
			this.lTen.Text = "Tên :";
			this.lTen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lMabd
			// 
			this.lMabd.Location = new System.Drawing.Point(160, 308);
			this.lMabd.Name = "lMabd";
			this.lMabd.Size = new System.Drawing.Size(32, 23);
			this.lMabd.TabIndex = 68;
			this.lMabd.Text = "Mã :";
			this.lMabd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// soluong
			// 
			this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
			this.soluong.Enabled = false;
			this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.soluong.Location = new System.Drawing.Point(432, 331);
			this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
			this.soluong.Name = "soluong";
			this.soluong.Size = new System.Drawing.Size(48, 21);
			this.soluong.TabIndex = 14;
			this.soluong.Text = "";
			this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(376, 331);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(56, 23);
			this.label16.TabIndex = 74;
			this.label16.Text = "Số lượng :";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ldvt
			// 
			this.ldvt.Location = new System.Drawing.Point(648, 308);
			this.ldvt.Name = "ldvt";
			this.ldvt.Size = new System.Drawing.Size(34, 23);
			this.ldvt.TabIndex = 73;
			this.ldvt.Text = "ĐVT :";
			this.ldvt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cachdung
			// 
			this.cachdung.BackColor = System.Drawing.SystemColors.HighlightText;
			this.cachdung.Enabled = false;
			this.cachdung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cachdung.Location = new System.Drawing.Point(544, 331);
			this.cachdung.Name = "cachdung";
			this.cachdung.Size = new System.Drawing.Size(248, 21);
			this.cachdung.TabIndex = 15;
			this.cachdung.Text = "";
			this.cachdung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cachdung_KeyDown);
			this.cachdung.Validated += new System.EventHandler(this.cachdung_Validated);
			this.cachdung.TextChanged += new System.EventHandler(this.cachdung_TextChanged);
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(456, 330);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(88, 23);
			this.label25.TabIndex = 76;
			this.label25.Text = "Cách dùng :";
			this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// butKetthuc
			// 
			this.butKetthuc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.butKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("butKetthuc.Image")));
			this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butKetthuc.Location = new System.Drawing.Point(662, 361);
			this.butKetthuc.Name = "butKetthuc";
			this.butKetthuc.Size = new System.Drawing.Size(74, 28);
			this.butKetthuc.TabIndex = 25;
			this.butKetthuc.Text = "&Kết thúc";
			this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
			// 
			// butHuy
			// 
			this.butHuy.Image = ((System.Drawing.Bitmap)(resources.GetObject("butHuy.Image")));
			this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butHuy.Location = new System.Drawing.Point(464, 361);
			this.butHuy.Name = "butHuy";
			this.butHuy.Size = new System.Drawing.Size(61, 28);
			this.butHuy.TabIndex = 22;
			this.butHuy.Text = "       &Hủy";
			this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
			// 
			// butBoqua
			// 
			this.butBoqua.Enabled = false;
			this.butBoqua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butBoqua.Image")));
			this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butBoqua.Location = new System.Drawing.Point(392, 361);
			this.butBoqua.Name = "butBoqua";
			this.butBoqua.Size = new System.Drawing.Size(70, 28);
			this.butBoqua.TabIndex = 19;
			this.butBoqua.Text = "&Bỏ qua";
			this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
			// 
			// butXoa
			// 
			this.butXoa.Enabled = false;
			this.butXoa.Image = ((System.Drawing.Bitmap)(resources.GetObject("butXoa.Image")));
			this.butXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butXoa.Location = new System.Drawing.Point(326, 361);
			this.butXoa.Name = "butXoa";
			this.butXoa.Size = new System.Drawing.Size(64, 28);
			this.butXoa.TabIndex = 17;
			this.butXoa.Text = "      &Xóa";
			this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
			// 
			// butThem
			// 
			this.butThem.Enabled = false;
			this.butThem.Image = ((System.Drawing.Bitmap)(resources.GetObject("butThem.Image")));
			this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butThem.Location = new System.Drawing.Point(259, 361);
			this.butThem.Name = "butThem";
			this.butThem.Size = new System.Drawing.Size(65, 28);
			this.butThem.TabIndex = 16;
			this.butThem.Tag = "";
			this.butThem.Text = "&Thêm";
			this.butThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butThem.Click += new System.EventHandler(this.butThem_Click);
			// 
			// butLuu
			// 
			this.butLuu.Enabled = false;
			this.butLuu.Image = ((System.Drawing.Bitmap)(resources.GetObject("butLuu.Image")));
			this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLuu.Location = new System.Drawing.Point(191, 361);
			this.butLuu.Name = "butLuu";
			this.butLuu.Size = new System.Drawing.Size(66, 28);
			this.butLuu.TabIndex = 18;
			this.butLuu.Text = "       &Lưu";
			this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
			// 
			// butSua
			// 
			this.butSua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butSua.Image")));
			this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSua.Location = new System.Drawing.Point(125, 361);
			this.butSua.Name = "butSua";
			this.butSua.Size = new System.Drawing.Size(64, 28);
			this.butSua.TabIndex = 21;
			this.butSua.Text = "       &Sữa";
			this.butSua.Click += new System.EventHandler(this.butSua_Click);
			// 
			// butMoi
			// 
			this.butMoi.Image = ((System.Drawing.Bitmap)(resources.GetObject("butMoi.Image")));
			this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butMoi.Location = new System.Drawing.Point(59, 361);
			this.butMoi.Name = "butMoi";
			this.butMoi.Size = new System.Drawing.Size(64, 28);
			this.butMoi.TabIndex = 20;
			this.butMoi.Text = "       &Mới";
			this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
			// 
			// butCholai
			// 
			this.butCholai.Enabled = false;
			this.butCholai.Image = ((System.Drawing.Bitmap)(resources.GetObject("butCholai.Image")));
			this.butCholai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butCholai.Location = new System.Drawing.Point(593, 361);
			this.butCholai.Name = "butCholai";
			this.butCholai.Size = new System.Drawing.Size(67, 28);
			this.butCholai.TabIndex = 24;
			this.butCholai.Text = "&Cho lại";
			this.butCholai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butCholai.Click += new System.EventHandler(this.butCholai_Click);
			// 
			// cmbMabn
			// 
			this.cmbMabn.BackColor = System.Drawing.SystemColors.HighlightText;
			this.cmbMabn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmbMabn.Location = new System.Drawing.Point(48, 6);
			this.cmbMabn.Name = "cmbMabn";
			this.cmbMabn.Size = new System.Drawing.Size(96, 21);
			this.cmbMabn.TabIndex = 0;
			this.cmbMabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMabn_KeyDown);
			this.cmbMabn.SelectedIndexChanged += new System.EventHandler(this.cmbMabn_SelectedIndexChanged);
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(712, 308);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(34, 23);
			this.label20.TabIndex = 96;
			this.label20.Text = "Kho :";
			this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// makho
			// 
			this.makho.BackColor = System.Drawing.SystemColors.HighlightText;
			this.makho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.makho.Enabled = false;
			this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.makho.Location = new System.Drawing.Point(744, 308);
			this.makho.Name = "makho";
			this.makho.Size = new System.Drawing.Size(48, 21);
			this.makho.TabIndex = 10;
			// 
			// stt
			// 
			this.stt.Enabled = false;
			this.stt.Location = new System.Drawing.Point(152, 232);
			this.stt.Name = "stt";
			this.stt.Size = new System.Drawing.Size(24, 20);
			this.stt.TabIndex = 98;
			this.stt.Text = "";
			// 
			// diung
			// 
			this.diung.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.diung.ForeColor = System.Drawing.Color.Blue;
			this.diung.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.diung.Location = new System.Drawing.Point(752, 6);
			this.diung.Name = "diung";
			this.diung.Size = new System.Drawing.Size(44, 23);
			this.diung.TabIndex = 101;
			this.diung.Text = "DỊ ỨNG";
			this.diung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.diung.Click += new System.EventHandler(this.diung_Click);
			// 
			// mahc
			// 
			this.mahc.Location = new System.Drawing.Point(104, 192);
			this.mahc.Name = "mahc";
			this.mahc.Size = new System.Drawing.Size(48, 20);
			this.mahc.TabIndex = 102;
			this.mahc.Text = "";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(0, 328);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(56, 23);
			this.label22.TabIndex = 103;
			this.label22.Text = "Nguồn :";
			this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// manguon
			// 
			this.manguon.BackColor = System.Drawing.SystemColors.HighlightText;
			this.manguon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.manguon.Enabled = false;
			this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.manguon.Location = new System.Drawing.Point(56, 331);
			this.manguon.Name = "manguon";
			this.manguon.Size = new System.Drawing.Size(96, 21);
			this.manguon.TabIndex = 11;
			// 
			// treeView1
			// 
			this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.treeView1.ImageIndex = -1;
			this.treeView1.ItemHeight = 16;
			this.treeView1.Location = new System.Drawing.Point(627, 104);
			this.treeView1.Name = "treeView1";
			this.treeView1.SelectedImageIndex = -1;
			this.treeView1.Size = new System.Drawing.Size(163, 176);
			this.treeView1.TabIndex = 26;
			// 
			// namsinh
			// 
			this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
			this.namsinh.Enabled = false;
			this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.namsinh.Location = new System.Drawing.Point(496, 6);
			this.namsinh.Name = "namsinh";
			this.namsinh.Size = new System.Drawing.Size(32, 21);
			this.namsinh.TabIndex = 105;
			this.namsinh.Text = "";
			// 
			// sothe
			// 
			this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
			this.sothe.Enabled = false;
			this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.sothe.Location = new System.Drawing.Point(568, 6);
			this.sothe.Name = "sothe";
			this.sothe.Size = new System.Drawing.Size(176, 21);
			this.sothe.TabIndex = 106;
			this.sothe.Text = "";
			// 
			// chandoan
			// 
			this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
			this.chandoan.Enabled = false;
			this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.chandoan.Location = new System.Drawing.Point(64, 30);
			this.chandoan.Name = "chandoan";
			this.chandoan.Size = new System.Drawing.Size(320, 21);
			this.chandoan.TabIndex = 107;
			this.chandoan.Text = "";
			// 
			// maicd
			// 
			this.maicd.BackColor = System.Drawing.SystemColors.HighlightText;
			this.maicd.Enabled = false;
			this.maicd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.maicd.Location = new System.Drawing.Point(386, 30);
			this.maicd.Name = "maicd";
			this.maicd.Size = new System.Drawing.Size(38, 21);
			this.maicd.TabIndex = 108;
			this.maicd.Text = "";
			// 
			// tenpk
			// 
			this.tenpk.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tenpk.Enabled = false;
			this.tenpk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tenpk.Location = new System.Drawing.Point(496, 30);
			this.tenpk.Name = "tenpk";
			this.tenpk.Size = new System.Drawing.Size(96, 21);
			this.tenpk.TabIndex = 109;
			this.tenpk.Text = "";
			// 
			// tenbs
			// 
			this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tenbs.Enabled = false;
			this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tenbs.Location = new System.Drawing.Point(632, 30);
			this.tenbs.Name = "tenbs";
			this.tenbs.Size = new System.Drawing.Size(160, 21);
			this.tenbs.TabIndex = 110;
			this.tenbs.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(432, 6);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 23);
			this.label3.TabIndex = 111;
			this.label3.Text = "Năm sinh :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(520, 6);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 23);
			this.label4.TabIndex = 112;
			this.label4.Text = "Số thẻ :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(0, 30);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 23);
			this.label5.TabIndex = 113;
			this.label5.Text = "Chẩn đoán :";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(416, 30);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 23);
			this.label6.TabIndex = 114;
			this.label6.Text = "Khoa/phòng :";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(592, 30);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 23);
			this.label7.TabIndex = 115;
			this.label7.Text = "Bác sĩ :";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// butIn
			// 
			this.butIn.Image = ((System.Drawing.Bitmap)(resources.GetObject("butIn.Image")));
			this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butIn.Location = new System.Drawing.Point(527, 361);
			this.butIn.Name = "butIn";
			this.butIn.Size = new System.Drawing.Size(64, 28);
			this.butIn.TabIndex = 23;
			this.butIn.Text = "     &In";
			this.butIn.Click += new System.EventHandler(this.butIn_Click);
			// 
			// butHen
			// 
			this.butHen.Location = new System.Drawing.Point(402, 5);
			this.butHen.Name = "butHen";
			this.butHen.Size = new System.Drawing.Size(33, 23);
			this.butHen.TabIndex = 116;
			this.butHen.Text = "Hẹn";
			this.butHen.Click += new System.EventHandler(this.butHen_Click);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(160, 52);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(56, 23);
			this.label8.TabIndex = 119;
			this.label8.Text = "Ghi chú :";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ghichu
			// 
			this.ghichu.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ghichu.Enabled = false;
			this.ghichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ghichu.Location = new System.Drawing.Point(216, 53);
			this.ghichu.Name = "ghichu";
			this.ghichu.Size = new System.Drawing.Size(208, 21);
			this.ghichu.TabIndex = 4;
			this.ghichu.Text = "";
			this.ghichu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ghichu_KeyDown);
			// 
			// chkVP
			// 
			this.chkVP.Location = new System.Drawing.Point(628, 284);
			this.chkVP.Name = "chkVP";
			this.chkVP.Size = new System.Drawing.Size(128, 20);
			this.chkVP.TabIndex = 120;
			this.chkVP.Text = "In kèm theo chỉ định";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(152, 331);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(38, 23);
			this.label11.TabIndex = 124;
			this.label11.Text = "Ngày :";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// solan
			// 
			this.solan.BackColor = System.Drawing.SystemColors.HighlightText;
			this.solan.Enabled = false;
			this.solan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.solan.Location = new System.Drawing.Point(192, 331);
			this.solan.Maximum = new System.Decimal(new int[] {
																  99,
																  0,
																  0,
																  0});
			this.solan.Minimum = new System.Decimal(new int[] {
																  1,
																  0,
																  0,
																  0});
			this.solan.Name = "solan";
			this.solan.Size = new System.Drawing.Size(40, 21);
			this.solan.TabIndex = 12;
			this.solan.Value = new System.Decimal(new int[] {
																1,
																0,
																0,
																0});
			this.solan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.solan_KeyDown);
			this.solan.Validated += new System.EventHandler(this.solan_Validated);
			// 
			// lan
			// 
			this.lan.BackColor = System.Drawing.SystemColors.HighlightText;
			this.lan.Enabled = false;
			this.lan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lan.Location = new System.Drawing.Point(280, 331);
			this.lan.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
			this.lan.Name = "lan";
			this.lan.Size = new System.Drawing.Size(48, 21);
			this.lan.TabIndex = 13;
			this.lan.Text = "";
			this.lan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.lan.Validated += new System.EventHandler(this.solan_Validated);
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(208, 331);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(72, 23);
			this.label12.TabIndex = 126;
			this.label12.Text = "lần , lần :";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// dvt
			// 
			this.dvt.Location = new System.Drawing.Point(328, 331);
			this.dvt.Name = "dvt";
			this.dvt.Size = new System.Drawing.Size(48, 23);
			this.dvt.TabIndex = 127;
			this.dvt.Text = "viên";
			this.dvt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// donthuoc
			// 
			this.donthuoc.Enabled = false;
			this.donthuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.donthuoc.Location = new System.Drawing.Point(425, 53);
			this.donthuoc.Name = "donthuoc";
			this.donthuoc.Size = new System.Drawing.Size(328, 21);
			this.donthuoc.TabIndex = 128;
			this.donthuoc.SelectedIndexChanged += new System.EventHandler(this.donthuoc_SelectedIndexChanged);
			// 
			// chkChon
			// 
			this.chkChon.Appearance = System.Windows.Forms.Appearance.Button;
			this.chkChon.Enabled = false;
			this.chkChon.Location = new System.Drawing.Point(752, 53);
			this.chkChon.Name = "chkChon";
			this.chkChon.Size = new System.Drawing.Size(39, 21);
			this.chkChon.TabIndex = 129;
			this.chkChon.Text = "Chọn";
			this.chkChon.CheckedChanged += new System.EventHandler(this.chkChon_CheckedChanged);
			// 
			// songay
			// 
			this.songay.BackColor = System.Drawing.SystemColors.HighlightText;
			this.songay.Enabled = false;
			this.songay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.songay.Location = new System.Drawing.Point(80, 53);
			this.songay.Name = "songay";
			this.songay.Size = new System.Drawing.Size(48, 21);
			this.songay.TabIndex = 3;
			this.songay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ghichu_KeyDown);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(0, 52);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(88, 23);
			this.label10.TabIndex = 123;
			this.label10.Text = "Đơn thuốc cấp ";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(128, 54);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(32, 16);
			this.label9.TabIndex = 122;
			this.label9.Text = "ngày";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(-8, 304);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(64, 23);
			this.label13.TabIndex = 130;
			this.label13.Text = "Đối tượng :";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// madoituong
			// 
			this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
			this.madoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.madoituong.Enabled = false;
			this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.madoituong.Location = new System.Drawing.Point(56, 308);
			this.madoituong.Name = "madoituong";
			this.madoituong.Size = new System.Drawing.Size(104, 21);
			this.madoituong.TabIndex = 5;
			this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
			// 
			// listCachdung
			// 
			this.listCachdung.BackColor = System.Drawing.SystemColors.Info;
			this.listCachdung.ColumnCount = 0;
			this.listCachdung.Location = new System.Drawing.Point(296, 408);
			this.listCachdung.MatchBufferTimeOut = 1000;
			this.listCachdung.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
			this.listCachdung.Name = "listCachdung";
			this.listCachdung.Size = new System.Drawing.Size(75, 17);
			this.listCachdung.TabIndex = 132;
			this.listCachdung.TextIndex = -1;
			this.listCachdung.TextMember = null;
			this.listCachdung.ValueIndex = -1;
			this.listCachdung.Visible = false;
			// 
			// listDmbd
			// 
			this.listDmbd.BackColor = System.Drawing.SystemColors.Info;
			this.listDmbd.ColumnCount = 0;
			this.listDmbd.Location = new System.Drawing.Point(408, 408);
			this.listDmbd.MatchBufferTimeOut = 1000;
			this.listDmbd.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
			this.listDmbd.Name = "listDmbd";
			this.listDmbd.Size = new System.Drawing.Size(75, 17);
			this.listDmbd.TabIndex = 131;
			this.listDmbd.TextIndex = -1;
			this.listDmbd.TextMember = null;
			this.listDmbd.ValueIndex = -1;
			this.listDmbd.Visible = false;
			this.listDmbd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listDmbd_KeyDown);
			// 
			// dang
			// 
			this.dang.BackColor = System.Drawing.SystemColors.HighlightText;
			this.dang.Enabled = false;
			this.dang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dang.Location = new System.Drawing.Point(680, 308);
			this.dang.Name = "dang";
			this.dang.Size = new System.Drawing.Size(34, 21);
			this.dang.TabIndex = 9;
			this.dang.Text = "";
			this.dang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.solan_KeyDown);
			// 
			// chkThuoc
			// 
			this.chkThuoc.Location = new System.Drawing.Point(629, 80);
			this.chkThuoc.Name = "chkThuoc";
			this.chkThuoc.Size = new System.Drawing.Size(155, 20);
			this.chkThuoc.TabIndex = 133;
			this.chkThuoc.Text = "Xem thuốc đã sử dụng";
			this.chkThuoc.CheckedChanged += new System.EventHandler(this.chkThuoc_CheckedChanged);
			// 
			// frmBaohiem
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.butKetthuc;
			this.ClientSize = new System.Drawing.Size(794, 439);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.chkThuoc,
																		  this.dang,
																		  this.listCachdung,
																		  this.listDmbd,
																		  this.madoituong,
																		  this.label13,
																		  this.chkChon,
																		  this.donthuoc,
																		  this.dvt,
																		  this.solan,
																		  this.label12,
																		  this.lan,
																		  this.soluong,
																		  this.label11,
																		  this.songay,
																		  this.label10,
																		  this.label9,
																		  this.treeView1,
																		  this.chkVP,
																		  this.ghichu,
																		  this.label8,
																		  this.butHen,
																		  this.butIn,
																		  this.namsinh,
																		  this.maicd,
																		  this.hoten,
																		  this.chandoan,
																		  this.tenbs,
																		  this.label7,
																		  this.label6,
																		  this.label5,
																		  this.label4,
																		  this.label3,
																		  this.tenpk,
																		  this.sothe,
																		  this.makho,
																		  this.manguon,
																		  this.label22,
																		  this.diung,
																		  this.tenhc,
																		  this.label20,
																		  this.cmbMabn,
																		  this.butCholai,
																		  this.butKetthuc,
																		  this.butHuy,
																		  this.butBoqua,
																		  this.butXoa,
																		  this.butThem,
																		  this.butLuu,
																		  this.butSua,
																		  this.butMoi,
																		  this.cachdung,
																		  this.label25,
																		  this.label16,
																		  this.ldvt,
																		  this.tenbd,
																		  this.lTenhc,
																		  this.mabd,
																		  this.lTen,
																		  this.lMabd,
																		  this.mabn,
																		  this.label2,
																		  this.label1,
																		  this.dataGrid1,
																		  this.stt,
																		  this.mahc});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "frmBaohiem";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Đơn thuốc";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBaohiem_KeyDown);
			this.Load += new System.EventHandler(this.frmBaohiem_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.solan)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.songay)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmBaohiem_Load(object sender, System.EventArgs e)
		{
			bNgoaitonkho=m.bNgoaitonkho;
			bDuyet=(i_loaiba==1 || i_loaiba==4)?m.bDuyet_donve:false;iUserid_duyet=m.iUserid_donve;
			if (bDuyet) bKhoaso=d.bKhoaso(i_nhom,s_mmyy);
			s_makho_makp="";
			if (bDieutringtr)
			{
				kho_dtngoaitru=m.kho_dtngoaitru;
				makp_dtngoaitru=m.makp_dtngoaitru;
			}
			soluong_max=m.Soluong_max;
			dtkp=m.get_data("select * from d_duockp").Tables[0];
			DataRow r1=d.getrowbyid(dtkp,"makp='"+s_makp+"'");
			if (r1!=null) s_makho_makp=r1["makho"].ToString().Trim();
			if (nam=="") nam=m.get_nam(s_mabn);
			user=m.user;xxx=user+m.mmyy(s_ngay);
			s_ngayht=m.ngayhienhanh_server;
			bSolan=m.bSolan_donthuoc;bThuoc_1don=m.bThuoc_1don;
			bSongay_donthuoc=m.bSongay_donthuoc;
			i_bhyt_inrieng=d.iBhyt_inrieng(i_nhom);
			bKiemtrathuoc=m.bThuoc_ngay;
			s_msg=LibMedi.AccessData.Msg;
			i_sudungthuoc=m.iSudungthuoc;
			s_manguon=d.get_manguon_doituong(i_madoituong).Trim();
			if (s_manguon=="") s_manguon=d.get_manguon(i_loai).Trim();
			if (s_makho=="") s_makho=d.get_dmkho(i_loai).Trim();
			bChidinh=m.bInchidinh_donthuoc;
			chkVP.Checked=bChidinh;
			if (!bDieutringtr)
			{
				dtletet=m.get_data("select * from letet").Tables[0];
				r=m.getrowbyid(dtletet,"ngay='"+s_ngay.Substring(0,5)+"'");
				bLetet=r!=null;
				int hh1,hh2,hh3,mm1,mm2,mm3;
				string kho="";
				hh1=int.Parse(s_ngayht.Substring(11,2));//hh1=int.Parse(s_ngay.Substring(11,2));
				mm1=int.Parse(s_ngayht.Substring(14,2));//mm1=int.Parse(s_ngay.Substring(14,2));
				hh3=int.Parse(m.sGiobaocao.Substring(0,2));
				mm3=int.Parse(m.sGiobaocao.Substring(3,2));
				DateTime dt=m.StringToDate(s_ngay.Substring(0,10));
				string ddd=dt.DayOfWeek.ToString().Substring(0,3);
				if (i_madoituong==m.iTreem6tuoi && i_nhom==m.nhom_duoc && s_makho!="" && m.gio_treem!="00:00")
				{
					hh2=int.Parse(m.gio_treem.Substring(0,2));
					mm2=int.Parse(m.gio_treem.Substring(3,2));
					kho=m.kho_treem;
					if (kho!="") kho+=",";
					if (bLetet || ddd=="Sat" || ddd=="Sun" || hh1>hh2 || (hh1==hh2 && mm1>mm2) || hh1<hh3 || (hh1==hh3 && mm1<mm3)) s_makho=kho;
					else if (kho!="" && s_makho.IndexOf(kho)!=-1) s_makho=s_makho.Remove(s_makho.IndexOf(kho),kho.Length);
				}
				else if (i_madoituong==1 && i_nhom==m.nhom_duoc && s_makho!="" && m.gio_bhyt!="00:00")
				{
					hh2=int.Parse(m.gio_bhyt.Substring(0,2));
					mm2=int.Parse(m.gio_bhyt.Substring(3,2));
					kho=m.kho_bhyt;
					if (kho!="") kho+=",";
					if (bLetet || ddd=="Sat" || ddd=="Sun" || hh1>hh2 || (hh1==hh2 && mm1>mm2) || hh1<hh3 || (hh1==hh3 && mm1<mm3)) s_makho=kho;
					else if (kho!="" && s_makho.IndexOf(kho)!=-1) s_makho=s_makho.Remove(s_makho.IndexOf(kho),kho.Length);
				}
				else if (i_madoituong==2 && m.bDanhmuc_nhathuoc && i_nhom==m.nhom_nhathuoc && s_makho!="" && m.gio_nhathuoc!="00:00") //nha thuoc
				{
					hh2=int.Parse(m.gio_nhathuoc.Substring(0,2));
					mm2=int.Parse(m.gio_nhathuoc.Substring(3,2));
					kho=m.kho_nhathuoc;
					if (kho!="") kho+=",";
					if (bLetet || ddd=="Sat" || ddd=="Sun" || hh1>hh2 || (hh1==hh2 && mm1>mm2) || hh1<hh3 || (hh1==hh3 && mm1<mm3)) s_makho=kho;
					else if (kho!="" && s_makho.IndexOf(kho)!=-1) s_makho=s_makho.Remove(s_makho.IndexOf(kho),kho.Length);
				}
			}
			else if (kho_dtngoaitru!=0 && makp_dtngoaitru!="")
			{
				if (makp_dtngoaitru.IndexOf("'"+s_makp+"'")!=-1)
				{
					s_makho=kho_dtngoaitru.ToString().Trim()+",";	
					s_makho_makp="";
				}
			}
			diung.Tag="";
			bDiungthuoc=m.bDiungthuoc;
			diung.Visible=bDiungthuoc;
			dtdmbd=d.get_data("select * from d_dmbd where nhom="+i_nhom).Tables[0];

			sql="select * from doituong";
			if (s_madoituong!="") sql+=" where madoituong in ("+s_madoituong.Substring(0,s_madoituong.Length-1)+")";			
			sql+=" order by madoituong";
			madoituong.DisplayMember="DOITUONG";
			madoituong.ValueMember="MADOITUONG";
			madoituong.DataSource=m.get_data(sql).Tables[0];

			listDmbd.DisplayMember="TEN";
			listDmbd.ValueMember="STT";

			listCachdung.DisplayMember="STT";
			listCachdung.ValueMember="TEN";

			sql="select a.*,' ' as hoten from d_theodonll a where a.mabs='"+s_mabs+"' and a.maicd='"+s_Maicd+"' order by a.stt";
			dtdon=m.get_data(sql).Tables[0];
			if (dtdon.Rows.Count==0) 
			{
				sql="select a.*,b.hoten from d_theodonll a,dmbs b where a.mabs=b.ma(+) and a.maicd='"+s_Maicd+"' order by a.stt";
				dtdon=m.get_data(sql).Tables[0];
			}
			foreach(DataRow r in dtdon.Rows) r["ghichu"]=r["stt"].ToString().Trim()+". Đơn thuốc "+r["songay"].ToString().Trim()+" ngày , "+r["so"].ToString()+" loại "+((r["hoten"].ToString().Trim()!="")?"["+r["hoten"].ToString().Trim()+"]":"");
			donthuoc.DisplayMember="GHICHU";
			donthuoc.ValueMember="ID";
			donthuoc.DataSource=dtdon;

			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			manguon.DataSource=d.get_data("select * from d_dmnguon").Tables[0];

			makho.DisplayMember="TEN";
			makho.ValueMember="ID";
			sql="select * from d_dmkho";
			if (s_makho!="") sql+=" where id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			sql+=" order by stt";
			makho.DataSource=d.get_data(sql).Tables[0];
            cmbMabn.DisplayMember="MABN";
			cmbMabn.ValueMember="ID";

			sql="select a.id,a.mabn,b.hoten,a.maql,to_char(a.ngay,'dd/mm/yyyy') ngay,a.done,";
			sql+=" b.namsinh,nvl(d.sothe,' ') sothe,a.chandoan,a.maicd,e.tenkp,nvl(f.hoten,' ') tenbs,a.ghichu,a.songay,a.lan ";
			sql+=" from "+xxx+".d_thuocbhytll a,btdbn b,"+xxx+".bhyt d,btdkp_bv e,dmbs f ";
			sql+=" where a.mabn=b.mabn and a.maql=d.maql(+)";
			sql+=" and a.makp=e.makp and a.mabs=f.ma(+)";
			sql+=" and a.mabn='"+s_mabn+"' and a.maql="+l_maql+" and a.madoituong="+i_madoituong;
			if (d.bLocbaohiem) sql+=" and to_char(a.ngay,'dd/mm/yyyy')='"+s_ngay.Substring(0,10)+"'";
			sql+=" order by a.id";
			dtll=d.get_data(sql).Tables[0];
			cmbMabn.DataSource=dtll;
			if (cmbMabn.Items.Count>0) l_id=long.Parse(cmbMabn.SelectedValue.ToString());
			else l_id=0;
			load_head();
			AddGridTableStyle();
			lang.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lang.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			ref_text();
			dsxoa.ReadXml("..\\..\\..\\xml\\d_dutruct.xml");
			if (i_sudungthuoc!=3) load_treeview();
		}

		private void load_grid()
		{
			sql="select a.stt,g.doituong,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong ten,nvl(b.tenhc,' ') tenhc,b.dang,f.ten tenkho,a.slyeucau soluong,a.madoituong,a.makho,nvl(a.cachdung,' ') cachdung,b.mahc,' ' diung,a.manguon,0 tutruc,0 idvpkhoa,a.solan,a.lan ";
			sql+=" from "+xxx+".d_thuocbhytct a,d_dmbd b,d_dmkho f,doituong g where a.mabd=b.id and a.makho=f.id and a.madoituong=g.madoituong and a.id="+l_id+" order by a.stt";
			dtct=d.get_data(sql).Tables[0];
			if (bDiungthuoc) upd_diung();
			dataGrid1.DataSource=dtct;
		}

		private void upd_diung()
		{
			if (diung.Tag.ToString()!="")
			{
				int i=0;
				foreach(DataRow r in dtct.Rows)
				{
					i=0;
					while (i<diung.Tag.ToString().Length)
					{
						if (r["mahc"].ToString().IndexOf(diung.Tag.ToString().Substring(i,7))!=-1)
						{
							r["diung"]="1";
							break;
						}
						i+=7;
					}
				}
				dtct.AcceptChanges();
			}
		}

		private void AddGridTableStyle()
		{
			DataGridColoredTextBoxColumn TextCol;
			delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dtct.TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.ReadOnly=false;
			ts.RowHeaderWidth=5;
						
			TextCol=new DataGridColoredTextBoxColumn(de, 0);
			TextCol.MappingName = "stt";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 1);
			TextCol.MappingName = "doituong";
			TextCol.HeaderText = (i_loaiba==1 || i_loaiba==4 || bDieutringtr)?"Đối tượng":"";
			TextCol.Width = (i_loaiba==1 || i_loaiba==4 || bDieutringtr)?80:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 2);
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã số";
			TextCol.Width = 45;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 3);
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên";
			TextCol.Width = 155;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 4);
			TextCol.MappingName = "tenhc";
			TextCol.HeaderText = "Hoạt chất";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 5);
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 34;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 6);
			TextCol.MappingName = "soluong";
			TextCol.HeaderText = "Số lượng";
			TextCol.Width = 50;
			TextCol.Format="#,###,##0.00";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 7);
			TextCol.MappingName = "madoituong";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 8);
			TextCol.MappingName = "makho";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 9);
			TextCol.MappingName = "cachdung";
			TextCol.HeaderText = "Cách dùng";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 10);
			TextCol.MappingName = "mahc";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 11);
			TextCol.MappingName = "diung";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 12);
			TextCol.MappingName = "manguon";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 13);
			TextCol.MappingName = "solan";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 14);
			TextCol.MappingName = "lan";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			if (this.dataGrid1[row,11].ToString().Trim()=="1") return Color.Red;
			else return Color.Black;
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

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				stt.Text=dataGrid1[i,0].ToString();
				mabd.Text=dataGrid1[i,2].ToString();
				tenbd.Text=dataGrid1[i,3].ToString();
				tenhc.Text=dataGrid1[i,4].ToString();
				dang.Text=dataGrid1[i,5].ToString();
				d_soluong=(dataGrid1[i,6].ToString()!="")?decimal.Parse(dataGrid1[i,6].ToString()):0;
				soluong.Text=d_soluong.ToString("###,###,##0.00");
				madoituong.SelectedValue=dataGrid1[i,7].ToString();
				makho.SelectedValue=dataGrid1[i,8].ToString();
				cachdung.Text=dataGrid1[i,9].ToString();
				mahc.Text=dataGrid1[i,10].ToString();
				manguon.SelectedValue=dataGrid1[i,12].ToString();
				solan.Value=decimal.Parse(dataGrid1[i,13].ToString());
				d_lan=(dataGrid1[i,14].ToString()!="")?decimal.Parse(dataGrid1[i,14].ToString()):0;
				lan.Text=d_lan.ToString();
				dvt.Text=dang.Text;
				d_soluongcu=d_soluong;
			}
			catch{}
		}

		private void ena_object(bool ena)
		{
			if (bSolan) solan.Enabled=ena;
			lan.Enabled=solan.Enabled;
			mabn.Visible=ena;
			cmbMabn.Visible=!ena;
			if (d.bNhapmaso) mabd.Enabled=ena;
			if (i_loaiba==1 || i_loaiba==4 || bDieutringtr) madoituong.Enabled=ena;
			songay.Enabled=ena;
			ghichu.Enabled=ena;
			tenbd.Enabled=ena;
			if (bNgoaitonkho) dang.Enabled=ena;
			soluong.Enabled=ena;
			cachdung.Enabled=ena;
			butThem.Enabled=ena;
			butXoa.Enabled=ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butMoi.Enabled=!ena;
			butCholai.Enabled=ena;
			butIn.Enabled=!ena;
			butHuy.Enabled=!ena;
			butSua.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			chkChon.Enabled=ena;
			donthuoc.Enabled=ena;
			i_old=cmbMabn.SelectedIndex;
			if (ena) load_dm();
		}

		private void emp_head()
		{
			if (bDiungthuoc)
			{
				diung.ForeColor=Color.FromArgb(0,0,128);
				diung.Tag="";
			}
			mabn.Text=s_mabn;hoten.Text=s_Hoten;namsinh.Text=s_Namsinh;
			chandoan.Text=s_Chandoan;maicd.Text=s_Maicd;ghichu.Text="";
			tenpk.Text=s_Tenkp;tenbs.Text=s_Tenbs;sothe.Text=s_Sothe;
			l_id=0;dsxoa.Clear();
		}

		private void emp_detail()
		{
			solan.Value=1;mabd.Text="";tenbd.Text="";tenhc.Text="";dang.Text="";cachdung.Text="";mahc.Text="";dvt.Text="";
			soluong.Text="";makho.SelectedIndex=-1;stt.Text=d.get_stt(dtct).ToString();
			d_soluongcu=0;d_lan=0;madoituong.SelectedValue=i_madoituong.ToString();
		}

		private void load_dm()
		{
			if (!d.bCapnhat_tonkho(i_nhom))
			{
				if ((i_loaiba==1 || i_loaiba==4) && (bDuyet))
				{
					sql="select id from d_dmkho where nhom="+i_nhom;
					if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
					foreach(DataRow r in d.get_data(sql).Tables[0].Rows) d.upd_tonkho(s_mmyy,int.Parse(r["id"].ToString()));
				}
			}
			dtton=d.get_tonkhoth_dutru_bhyt(i_nhom,s_mmyy,s_makho,s_makho_makp,s_manguon,(bDieutringtr || i_loaiba==1 || i_loaiba==4 || i_nhom==m.nhom_nhathuoc)?0:int.Parse(madoituong.SelectedValue.ToString()));
			listDmbd.DataSource=dtton;
			listCachdung.DataSource=d.get_data("select ten stt,ten from d_dmcachdung order by ten").Tables[0];
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			if (!d.bMmyy(s_mmyy))
			{
				MessageBox.Show(lang.Change_language_MessageText("Số liệu tồn kho tháng ")+s_mmyy.Substring(0,2)+lang.Change_language_MessageText(" năm 20")+s_mmyy.Substring(2)+lang.Change_language_MessageText(" chưa tạo !"),s_msg);
				return;
			}
			if (m.bDonthuoc_khambenh_1lan && i_loaiba!=1)
			{
				DataRow r1=m.getrowbyid(dtll,"mabn='"+mabn.Text+"'");
				if (r1!=null)
				{
					MessageBox.Show("Đơn thuốc đã nhập !",LibMedi.AccessData.Msg);
					butSua.Focus();
					return;
				}
			}
			if (i_loaiba==1 || i_loaiba==4)
			{
				if (bKhoaso)
				{
					MessageBox.Show("Số liệu tháng "+s_mmyy.Substring(0,2)+" năm "+s_mmyy.Substring(2,2)+" đã khóa !\nNếu cần thay đổi thì vào mục khai báo hệ thống",d.Msg);
					return;
				}
				if (m.bRavien(l_maql))
				{
					MessageBox.Show("Người bệnh này đã ra viện !",LibMedi.AccessData.Msg);
					return;
				}
			}
			bool bExit=false;
			decimal d_songay=0;
			string ngay_cap="";
			if (nam!="")
			{
				sql="select songay,to_char(ngay,'dd/mm/yyyy') as ngay from xxx.d_thuocbhytll where mabn='"+s_mabn+"' and nhom="+i_nhom+" and madoituong="+i_madoituong;
				sql+=" and to_date(ngay,'dd/mm/yy')<to_date('"+s_ngay.Substring(0,10)+"','dd/mm/yy')";
				sql+=" order by ngay desc";
				foreach(DataRow r in m.get_data_nam_dec(nam,sql).Tables[0].Rows)
				{
					ngay_cap=r["ngay"].ToString();
					d_songay=decimal.Parse(r["songay"].ToString());
					if (d_songay>0)	bExit=Math.Abs(m.songay(m.StringToDate(s_ngay.Substring(0,10)),m.StringToDate(r["ngay"].ToString()),0))<d_songay;
					break;
				}
			}
			if (bExit)
				if (MessageBox.Show("Ngày "+ngay_cap+" cấp đơn thuốc "+d_songay.ToString().Trim()+" ngày\nBạn có muốn cấp tiếp không ?",LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No) return; 
			dtct.Clear();
			dtsave.Clear();
			emp_head();
			emp_detail();
			ena_object(true);
			bNew=true;
			bEdit=true;
			songay.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (dtll.Rows.Count==0) return;
			l_id=long.Parse(cmbMabn.SelectedValue.ToString());
			if (i_loaiba!=1 || (i_loaiba==1 && !bDuyet))
			{
				bDone=d.get_done_thuocbhyt(s_ngay,l_id);
				if (bDone)
				{
					MessageBox.Show(lang.Change_language_MessageText("Đã cập nhật !"),s_msg);
					return;
				}
			}
			if (i_loaiba==1 || i_loaiba==4)
			{
				if (bKhoaso)
				{
					MessageBox.Show("Số liệu tháng "+s_mmyy.Substring(0,2)+" năm "+s_mmyy.Substring(2,2)+" đã khóa !\nNếu cần thay đổi thì vào mục khai báo hệ thống",d.Msg);
					return;
				}
				if (m.bRavien(l_maql))
				{
					MessageBox.Show("Người bệnh này đã ra viện !",LibMedi.AccessData.Msg);
					return;
				}
			}
			if (m.getrowbyid(dtll,"lan>0 and id="+l_id)!=null)
			{
				MessageBox.Show("Đơn thuốc này đã in !",LibMedi.AccessData.Msg);
				return;
			}
			ena_object(true);
			butCholai.Enabled=false;
			bNew=false;
			bEdit=true;
			dtsave=dtct.Copy();
			dsxoa.Clear();
			ref_text();
			dataGrid1.Focus();
		}

		private bool kiemtra()
		{
			if (bKiemtrathuoc)
			{
				string ret=d.kiemtra_toathuoc(dtdmbd,dtct,mabn.Text,i_nhom,s_ngay,l_id);
				if (ret!="")
				{
					if (bThuoc_1don)
					{
						MessageBox.Show("Những thuốc sau đã kê toa :\n"+ret+"Không cho phép thêm trong toa này !",LibMedi.AccessData.Msg);
						return false;
					}
					else if (MessageBox.Show("Những thuốc sau đã kê toa :\n"+ret+"Bạn có đồng ý kê toa này !",LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No) return false;
				}
			}
			if (bSongay_donthuoc && songay.Value==0)
			{
				MessageBox.Show("Yêu cầu nhập số ngày cấp đơn !",LibMedi.AccessData.Msg);
				songay.Focus();
				return false;
			}
			if (dtct.Rows.Count==0)
			{
				MessageBox.Show("Đề nghị nhập thuốc !",LibMedi.AccessData.Msg);
				butThem.Focus();
				return false;
			}
			return true;
		}
		private void butLuu_Click(object sender, System.EventArgs e)
		{
			bEdit=false;
			if (tenbd.Text!="") upd_table(dtct,"-");
			dtct.AcceptChanges();
			i_old=(bNew)?0:1;
			l_id=(bNew)?d.get_id_bhyt:l_id;
			if (!kiemtra()) return;
			if (!d.upd_thuocbhytll(l_id,i_nhom,s_ngay,mabn.Text,l_maql,i_madoituong,ghichu.Text,songay.Value,s_makp,s_mabs,s_Chandoan,s_Maicd,i_loaiba,i_userid))
			{
				MessageBox.Show(lang.Change_language_MessageText("Không cập nhật được thông tin !"),s_msg);
				return;
			}
			if (!bNew)
			{
				foreach(DataRow r1 in dsxoa.Tables[0].Rows)
				{
					d.execute_data("delete from "+xxx+".d_thuocbhytct where id="+l_id+" and stt="+long.Parse(r1["stt"].ToString()));
					d.upd_suahuy("d_theodoihuy","d_thuocbhytct",l_id,int.Parse(r1["mabd"].ToString()),decimal.Parse(r1["soluong"].ToString()),i_userid);
				}
				foreach(DataRow r1 in dtsave.Rows)
					d.upd_tonkhoth_dutru(d.delete,i_nhom,s_mmyy,int.Parse(r1["makho"].ToString()),int.Parse(r1["manguon"].ToString()),int.Parse(r1["mabd"].ToString()),decimal.Parse(r1["soluong"].ToString()));
			}
			foreach(DataRow r1 in dtct.Rows)
			{
				if (bSolan) d.upd_thuocbhytct(s_ngay,l_id,int.Parse(r1["stt"].ToString()),int.Parse(r1["makho"].ToString()),int.Parse(r1["mabd"].ToString()),decimal.Parse(r1["soluong"].ToString()),r1["cachdung"].ToString(),int.Parse(r1["manguon"].ToString()),decimal.Parse(r1["solan"].ToString()),decimal.Parse(r1["lan"].ToString()),int.Parse(r1["madoituong"].ToString()));
				else d.upd_thuocbhytct(s_ngay,l_id,int.Parse(r1["stt"].ToString()),int.Parse(r1["makho"].ToString()),int.Parse(r1["mabd"].ToString()),decimal.Parse(r1["soluong"].ToString()),r1["cachdung"].ToString(),int.Parse(r1["manguon"].ToString()),int.Parse(r1["madoituong"].ToString()));
				d.upd_tonkhoth_dutru(d.insert,i_nhom,s_mmyy,int.Parse(r1["makho"].ToString()),int.Parse(r1["manguon"].ToString()),int.Parse(r1["mabd"].ToString()),decimal.Parse(r1["soluong"].ToString()));
				if (r1["cachdung"].ToString()!="") d.upd_dmcachdung(r1["cachdung"].ToString());
			}
			d.updrec_thuocbhytll(dtll,l_id,s_ngay,mabn.Text,l_maql,hoten.Text,namsinh.Text,sothe.Text,chandoan.Text,maicd.Text,tenpk.Text,tenbs.Text,ghichu.Text);
			DataRow [] dr=dtll.Select("id="+l_id);
			if (dr.Length>0) dr[0]["lan"]=0;
			try
			{
				if (i_old==0 && dtll.Rows.Count>0) cmbMabn.SelectedIndex=dtll.Rows.Count-1;
			}
			catch{}
			if (bDiungthuoc) upd_diung();
			load_grid();
			ena_object(false);
			if (m.bLuu_Donthuoc_bacsy) luu_don();
			if ((i_loaiba==1 || i_loaiba==4) && (bDuyet)) upd_duoc();
			butMoi.Focus();
		}

		private void luu_don()
		{
			string ma1="",ma2="";
			int so=dtct.Select("soluong>0").Length;
			DataTable tmp;
			bool bFound=false;
			foreach(DataRow r in dtct.Select("soluong>0","mabd,soluong")) ma1+=r["mabd"].ToString().PadLeft(7,'0')+r["soluong"].ToString().Trim()+",";
			foreach(DataRow r in m.get_data("select * from d_theodonll where mabs='"+s_mabs+"' and maicd='"+s_Maicd+"'").Tables[0].Rows)
			{
				tmp=m.get_data("select * from d_theodonct where id="+long.Parse(r["id"].ToString())).Tables[0];
				if (so==tmp.Select("soluong>0").Length)
				{
					ma2="";
					foreach(DataRow r1 in tmp.Select("soluong>0","mabd,soluong")) ma2+=r1["mabd"].ToString().PadLeft(7,'0')+r1["soluong"].ToString().Trim()+",";
					if (ma1==ma2)
					{
						bFound=true;break;
					}
				}
			}
			if (!bFound)
			{
				long id=d.get_id_donthuoc_bacsy();
				d.upd_theodonll(id,s_mabs,s_Maicd,s_Chandoan,m.stt(s_mabs,s_Maicd,id),so,songay.Value);
				foreach(DataRow r in dtct.Select("soluong>0")) 
					d.upd_theodonct(id,int.Parse(r["mabd"].ToString()),decimal.Parse(r["soluong"].ToString()),r["cachdung"].ToString());
			}
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			bEdit=false;
			try
			{
				cmbMabn.SelectedIndex=i_old;
				if (cmbMabn.Items.Count>0) l_id=long.Parse(cmbMabn.SelectedValue.ToString());
				else l_id=0;
			}
			catch{l_id=0;}
			load_head();
			ena_object(false);
			butMoi.Focus();
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

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void cachdung_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cachdung)
			{
				Filter_cachdung(cachdung.Text);
				listCachdung.BrowseToBtdkp(cachdung,cachdung,butThem);
			}
		}

		private void cachdung_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listCachdung.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listCachdung.Visible) listCachdung.Focus();
				else SendKeys.Send("{Tab}");
			}		
			else if(e.KeyCode==Keys.F2)
			{				
				cachdung.Text=m.Viettat(cachdung.Text)+" ";
				SendKeys.Send("{END}");				
			}
		}

		private void Filter_mabd(string ma)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDmbd.DataSource];
				DataView dv=(DataView)cm.List;
				sql="soluong>0 and ma like '%"+ma.Trim()+"%'";
				if (madoituong.SelectedValue.ToString()=="1") sql+=" and bhyt>0";
				dv.RowFilter=sql;
			}
			catch{}
		}

		private void Filter_dmbd(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDmbd.DataSource];
				DataView dv=(DataView)cm.List;
				sql="(soluong>0) and (ten like '%"+ten.Trim()+"%'"+" or tenhc like '%"+ten.Trim()+"%')";
				if (madoituong.SelectedValue.ToString()=="1") sql+=" and (bhyt>0)";
				dv.RowFilter=sql;
			}
			catch{}
		}


		private void mabd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==mabd)
			{
				if (butMoi.Enabled) return;
				Filter_mabd(mabd.Text);
				if (solan.Enabled)	listDmbd.Tonkhoct(mabd,tenbd,solan,madoituong.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lMabd.Width+lTenhc.Width+tenhc.Width-28+ldvt.Width+dang.Width+makho.Width+madoituong.Width+makho.Width-10,mabd.Height+5);
				else listDmbd.Tonkhoct(mabd,tenbd,soluong,madoituong.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lMabd.Width+lTenhc.Width+tenhc.Width-28+ldvt.Width+dang.Width+makho.Width+madoituong.Width+makho.Width-10,mabd.Height+5);
			}
		}

		private void tenbd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbd)
			{
				if (butMoi.Enabled) return;
				Filter_dmbd(tenbd.Text);
				if (solan.Enabled) listDmbd.Tonkhoct(tenbd,mabd,solan,madoituong.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lMabd.Width+lTenhc.Width+tenhc.Width-28+ldvt.Width+dang.Width+makho.Width+madoituong.Width+makho.Width-10,mabd.Height+5);
				else listDmbd.Tonkhoct(tenbd,mabd,soluong,madoituong.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lMabd.Width+lTenhc.Width+tenhc.Width-28+ldvt.Width+dang.Width+makho.Width+madoituong.Width+makho.Width-10,mabd.Height+5);
			}
		}

		private void tenbd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDmbd.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listDmbd.Visible) listDmbd.Focus();
				else SendKeys.Send("{Tab}");
			}
		}

		private void tenbd_Validated(object sender, System.EventArgs e)
		{
			if(!listDmbd.Focused) listDmbd.Hide();
		}

		private void listDmbd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				try
				{
					r=d.getrowbyid(dtton,"stt="+int.Parse(mabd.Text));
					if (r!=null)
					{
						mabd.Text=r["ma"].ToString();
						tenbd.Text=r["ten"].ToString();
						tenhc.Text=r["tenhc"].ToString();
						dang.Text=r["dang"].ToString();
						dvt.Text=dang.Text;
						makho.SelectedValue=r["makho"].ToString();
						mahc.Text=r["mahc"].ToString().Trim();
						manguon.SelectedValue=r["manguon"].ToString();
					#region diung
						if (bDiungthuoc)
						{
							bool bFound=false;
							if (diung.Tag.ToString()!="" && mahc.Text!="")
							{
								int i=0;
								while (i<diung.Tag.ToString().Length)
								{
									if (mahc.Text.IndexOf(diung.Tag.ToString().Substring(i,7))!=-1)
									{
										bFound=true;
										break;
									}
									i+=7;
								}
							}
							if (bFound)
							{
								if (MessageBox.Show("Người bệnh dị ứng thuốc \n"+tenhc.Text.Trim()+"\nBạn có đồng ý thêm vào không !",LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes) soluong.Focus();
								else
								{
									mabd.Text="";tenbd.Text="";tenhc.Text="";dang.Text="";mahc.Text="";
									mabd.Focus();
								}
							}
						}
					#endregion
					}
				}
				catch{}
			}
		}

		private void cachdung_Validated(object sender, System.EventArgs e)
		{
			if(!listCachdung.Focused) listCachdung.Hide();
		}

		private void cmbMabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void cmbMabn_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cmbMabn) 
			{
				try
				{
					l_id=long.Parse(cmbMabn.SelectedValue.ToString());
				}
				catch{l_id=0;}
				load_head();
			}
		}

		private void load_head()
		{
			try
			{
				r=d.getrowbyid(dtll,"id="+l_id);
				if (r!=null)
				{
					mabn.Text=r["mabn"].ToString();
					hoten.Text=r["hoten"].ToString();
					tenbs.Text=s_Tenbs;//["tenbs"].ToString();
					tenpk.Text=s_Tenkp;//["tenkp"].ToString();
					chandoan.Text=s_Chandoan;//["chandoan"].ToString();
					maicd.Text=s_Maicd;//["maicd"].ToString();
					namsinh.Text=s_Namsinh;//["namsinh"].ToString();
					sothe.Text=s_Sothe;//["sothe"].ToString();
					ghichu.Text=r["ghichu"].ToString();
					songay.Value=decimal.Parse(r["songay"].ToString());
					//l_maql=long.Parse(r["maql"].ToString());
					if (i_sudungthuoc!=3) load_treeview();
					if (bDiungthuoc) load_diungthuoc(mabn.Text);
				}
			}
			catch{l_id=0;}
			load_grid();
			ref_text();
		}

		private bool KiemtraDetail()
		{
			i_mabd=0;
			if (mabd.Text=="" && tenbd.Text=="" && !bNgoaitonkho)
			{
				if (mabd.Enabled) mabd.Focus();
				else tenbd.Focus();
				return false;
			}
			if (!bNgoaitonkho &&  (mabd.Text=="" && tenbd.Text!="") || (mabd.Text!="" && tenbd.Text==""))
			{
				if (mabd.Text=="" && mabd.Enabled)
				{
					MessageBox.Show("Nhập mã số !",s_msg);
					mabd.Focus();
					return false;
				}
				else if (tenbd.Text=="" && (soluong.Text!="" || soluong.Text!="0"))
				{
					MessageBox.Show("Nhập tên !",s_msg);
					tenbd.Focus();
					return false;
				}
			}
			if (bNgoaitonkho)
			{
				if (tenbd.Text.Trim()=="" && (soluong.Text.Trim()!="" || soluong.Text.Trim()!="0" || soluong.Text.Trim()!="0.00"))
				{
					MessageBox.Show("Nhập tên !",s_msg);
					tenbd.Focus();
					return false;
				}
				r=d.getrowbyid(dtton,"ten='"+tenbd.Text+"'");
				if (r==null)
				{
					i_mabd=Convert.ToInt16(d.get_id_dmbd);
					mabd.Text=d.getMabd("d_dmbd",tenbd.Text,i_nhom);
					d.upd_dmthuoc(Convert.ToInt32(i_mabd),tenbd.Text,dang.Text,cachdung.Text,tenhc.Text,2);
					d.upd_dmbd(Convert.ToInt32(i_mabd),mabd.Text,tenbd.Text,dang.Text,"",0,0,0,0,0,0,0,0,"","",0,i_nhom,"",0,0,0,0,0,0,"",0,0,"","",0,"");
					if (makho.SelectedIndex==-1) makho.SelectedIndex=0;
				}
				else i_mabd=int.Parse(r["id"].ToString());
			}
			else
			{
				sql="ma='"+mabd.Text+"'";
				if (madoituong.SelectedValue.ToString()=="1") sql+=" and bhyt<>0";
				r=d.getrowbyid(dtton,sql);
				if (r==null)
				{
					MessageBox.Show("Mã số không hợp lệ !",s_msg);
					if (mabd.Enabled) mabd.Focus();
					else tenbd.Focus();
					return false;
				}
				i_mabd=int.Parse(r["id"].ToString());
			}
			if (soluong.Text=="" || soluong.Text=="0.00" || soluong.Text=="0")
			{
				MessageBox.Show(lang.Change_language_MessageText("Nhập số lượng !"),s_msg);
				soluong.Focus();
				return false;
			}
			return true;
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
			if (d.bNhapmaso) mabd.Enabled=true;
			tenbd.Enabled=true;
			soluong.Enabled=true;
			if (!upd_table(dtct,"-")) return;
			emp_detail();
			if (madoituong.Enabled) madoituong.Focus();
			else if (mabd.Enabled) mabd.Focus();
			else tenbd.Focus();
		}

		private void butXoa_Click(object sender, System.EventArgs e)
		{
			if (!upd_table(dsxoa.Tables[0],"+")) return;
			d.delrec(dtct,"stt="+int.Parse(stt.Text));
			dtct.AcceptChanges();
			if (dtct.Rows.Count==0) emp_detail();
			else ref_text();
		}

		private bool upd_table(DataTable dt,string tt)
		{
			if (!KiemtraDetail()) return false;
			d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
			if (!bNew && d_soluong!=d_soluongcu) d.upd_suahuy("d_theodoisua","d_thuocbhytct",l_id,i_mabd,d_soluongcu,i_userid);
			if (bSolan) d.updrec_dutruct_solan(tt,dt,int.Parse(stt.Text),madoituong.Text,i_mabd,mabd.Text,tenbd.Text,tenhc.Text,dang.Text,makho.Text,d_soluong,int.Parse(madoituong.SelectedValue.ToString()),int.Parse(makho.SelectedValue.ToString()),cachdung.Text,mahc.Text,int.Parse(manguon.SelectedValue.ToString()),0,0,solan.Value,(lan.Text=="")?0:decimal.Parse(lan.Text),dtton);
			else d.updrec_dutruct(tt,dt,int.Parse(stt.Text),madoituong.Text,i_mabd,mabd.Text,tenbd.Text,tenhc.Text,dang.Text,makho.Text,d_soluong,int.Parse(madoituong.SelectedValue.ToString()),int.Parse(makho.SelectedValue.ToString()),cachdung.Text,mahc.Text,int.Parse(manguon.SelectedValue.ToString()),0,0,dtton);
			return true;
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void soluong_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (!bEdit) return;
				d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
				if (soluong_max!=0 && d_soluong>soluong_max && m.Hoten_khongdau(dang.Text)=="VIEN")
				{
					if (MessageBox.Show("Có đúng số lượng "+d_soluong.ToString("###,###,###.00")+" không ?",LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No)
					{
						soluong.Focus();
						return;
					}
				}
				soluong.Text=d_soluong.ToString("#,###,##0.00");
				if (mabd.Text!="" && tenbd.Text!="")
				{
					r=d.getrowbyid(dtton,"ma='"+mabd.Text+"'");
					if (r!=null)
					{
						i_mabd=int.Parse(r["id"].ToString());
						d_soluongton=d.get_slton_nguon_tutruc(dtton,int.Parse(makho.SelectedValue.ToString()),i_mabd,int.Parse(manguon.SelectedValue.ToString()),0,d_soluongcu);
						if (d_soluong>d_soluongton)
						{
							MessageBox.Show(lang.Change_language_MessageText("Số lượng xuất lớn hơn số lượng tồn !(")+d_soluongton.ToString()+")",s_msg);
							soluong.Focus();
							return;
						}
					}
				}
				if (d_soluongcu!=0) upd_table(dtct,"-");
			}
			catch{}
		}
		private void butHuy_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (dtll.Rows.Count==0) return;
				l_id=long.Parse(cmbMabn.SelectedValue.ToString());
				if (i_loaiba!=1 || (i_loaiba==1 && !bDuyet))
				{
					bDone=d.get_done_thuocbhyt(s_ngay,l_id);
					if (bDone)
					{
						MessageBox.Show(lang.Change_language_MessageText("Đã cập nhật !"),s_msg);
						return;
					}
				}
				if (i_loaiba==1)
				{
					if (bKhoaso)
					{
						MessageBox.Show("Số liệu tháng "+s_mmyy.Substring(0,2)+" năm "+s_mmyy.Substring(2,2)+" đã khóa !\nNếu cần thay đổi thì vào mục khai báo hệ thống",d.Msg);
						return;
					}
					if (m.bRavien(l_maql))
					{
						MessageBox.Show("Người bệnh này đã ra viện !",LibMedi.AccessData.Msg);
						return;
					}
				}
				if (m.getrowbyid(dtll,"lan>0 and id="+l_id)!=null)
				{
					MessageBox.Show("Đơn thuốc này đã in !",LibMedi.AccessData.Msg);
					return;
				}
				if (MessageBox.Show(lang.Change_language_MessageText("Đồng ý hủy số phiếu này ?"),s_msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					if (bDuyet)
					{
						foreach(DataRow r1 in d.get_data(s_mmyy,"select * from bhytthuoc where id="+l_id).Tables[0].Rows)
							d.upd_tonkhoct_xuat(d.delete,s_mmyy,long.Parse(r1["sttt"].ToString()),int.Parse(r1["makho"].ToString()),int.Parse(r1["manguon"].ToString()),int.Parse(r1["nhomcc"].ToString()),int.Parse(r1["mabd"].ToString()),r1["handung"].ToString(),r1["losx"].ToString(),decimal.Parse(r1["soluong"].ToString()),decimal.Parse(r1["sotien"].ToString()),0,0);
						d.execute_data(s_mmyy,"delete from d_chandoan where loai=1 and id="+l_id);
						d.execute_data(s_mmyy,"delete from bhytthuoc where id="+l_id);
						d.execute_data(s_mmyy,"delete from bhytkb where sobienlai=0 and id="+l_id);
					}
					d.execute_data("delete from "+xxx+".d_thuocbhytct where id="+l_id);
					d.execute_data("delete from "+xxx+".d_thuocbhytll where id="+l_id);
					foreach(DataRow r1 in dtct.Rows)
					{
						d.upd_suahuy("d_theodoihuy","d_thuocbhytct",l_id,int.Parse(r1["mabd"].ToString()),decimal.Parse(r1["soluong"].ToString()),i_userid);
						d.upd_tonkhoth_dutru(d.delete,i_nhom,s_mmyy,int.Parse(r1["makho"].ToString()),int.Parse(r1["manguon"].ToString()),int.Parse(r1["mabd"].ToString()),decimal.Parse(r1["soluong"].ToString()));
					}
					d.delrec(dtll,"id="+l_id);
					dtll.AcceptChanges();
					cmbMabn.Refresh();
					if (cmbMabn.Items.Count>0) l_id=long.Parse(cmbMabn.SelectedValue.ToString());
					else l_id=0;
					load_head();
				}
			}
			catch{}
		}

		private void load_treeview()
		{
			if (l_maql==0) return;
			sql="select to_char(a.ngay,'yyyymmdd')||nvl(a.makp,' ') ngay,e.tenkp,b.mabd,sum(b.slyeucau) soluong ";
			sql+=" from xxx.d_thuocbhytll a,xxx.d_thuocbhytct b,"+user+".d_dmbd d,"+user+".btdkp_bv e ";
			sql+=" where a.id=b.id and b.mabd=d.id and a.makp=e.makp(+)";
			sql+=" and a.mabn='"+s_mabn+"'";
			if (i_sudungthuoc==2) sql+=" and a.maql="+l_maql;
			sql+=" group by to_char(a.ngay,'yyyymmdd')||nvl(a.makp,' '),e.tenkp,b.mabd";
			treeView1.Nodes.Clear();
			TreeNode node;
			DataTable dtngay=(nam!="" && i_sudungthuoc!=2)?m.get_data_nam(nam,sql).Tables[0]:m.get_data_mmyy(sql,s_ngay,s_ngay,false).Tables[0];
			string ngay="";
			DataRow [] dr;
			foreach(DataRow r1 in dtngay.Select("true","ngay desc"))
			{
				if (ngay!=r1["ngay"].ToString()+"["+r1["tenkp"].ToString().Trim()+"]")
				{
					ngay=r1["ngay"].ToString()+"["+r1["tenkp"].ToString().Trim()+"]";
					node=treeView1.Nodes.Add(ngay.Substring(6,2)+"/"+ngay.Substring(4,2)+"/"+ngay.Substring(0,4)+ngay.Substring(10));
					dr=dtngay.Select("ngay='"+ngay.Substring(0,10)+"'");
					for(int i=0;i<dr.Length;i++)
					{
						r=d.getrowbyid(dtdmbd,"id="+int.Parse(dr[i]["mabd"].ToString()));
						if (r!=null) node.Nodes.Add(r["ten"].ToString().Trim()+" "+r["hamluong"].ToString().Trim()+"/"+r["tenhc"].ToString().Trim()+" "+r["dang"].ToString().Trim()+" ("+dr[i]["soluong"].ToString().Trim()+")");
					}
				}
			}
		}

		private void butCholai_Click(object sender, System.EventArgs e)
		{
			if (mabn.Text.Trim().Length!=8)
			{
				mabn.Focus();
				return;
			}
			long idcholai=d.get_cholai_bhyt(nam,s_ngay,mabn.Text);
			if (idcholai==0) return;
			sql="select b.stt,b.madoituong,b.makho,b.mabd,b.slyeucau soluong,b.cachdung, ";
			sql+=" g.doituong,e.ten tenkho,f.ma,trim(f.ten)||' '||trim(f.hamluong) as ten,f.hamluong,f.tenhc,f.dang,f.mahc,b.manguon,0 tutruc,b.solan,b.lan,f.bhyt ";
			if (nam!="") sql+=" from xxx.d_thuocbhytll a,xxx.d_thuocbhytct b,"+user+".d_dmkho e,"+user+".d_dmbd f,"+user+".doituong g";
			else sql+=" from "+xxx+".d_thuocbhytll a,"+xxx+".d_thuocbhytct b,"+user+".d_dmkho e,"+user+".d_dmbd f,"+user+".doituong g";
			sql+=" where a.id=b.id ";
			sql+=" and b.makho=e.id and b.mabd=f.id and b.madoituong=g.madoituong and a.id="+idcholai; 
			sql+=" order by b.stt";
			DataTable tmp=(nam!="")?m.get_data_nam(nam,sql).Tables[0]:m.get_data(sql).Tables[0];
			upd_thuoc(tmp);
		}

		private void get_don()
		{
			if (chkChon.Checked)
			{
				long id_donthuoc=long.Parse(donthuoc.SelectedValue.ToString());
				if (id_donthuoc!=0)
				{
					songay.Value=decimal.Parse(dtdon.Rows[donthuoc.SelectedIndex]["songay"].ToString());
					sql="select rownum as stt,"+i_madoituong+" as madoituong,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.hamluong,b.dang,b.mahc,b.tenhc,a.soluong,a.cachdung,0 as solan,0 as lan,b.bhyt from d_theodonct a,d_dmbd b";
					sql+=" where a.mabd=b.id and a.id="+id_donthuoc;
					upd_thuoc(d.get_data(sql).Tables[0]);
				}
				else MessageBox.Show("Không có trong danh mục !",LibMedi.AccessData.Msg);
			}
			else dtct.Clear();
		}

		private void upd_thuoc(DataTable tmp)
		{			
			string s_ten="";
			int i_mabd=0;
			bool bFound=false;
			decimal _soluong=0;
			DataRow r1,r2;
			foreach(DataRow r in tmp.Select("true","stt"))
			{
				bFound=false;
				i_mabd=int.Parse(r["mabd"].ToString());
				_soluong=decimal.Parse(r["soluong"].ToString());
				sql="soluong>="+_soluong+" and id="+i_mabd;
				r1=d.getrowbyid(dtton,sql);
				if (r1==null)
				{
					sql="soluong>="+_soluong+" and ten='"+r["ten"].ToString()+"' and dang='"+r["dang"].ToString()+"'";
					sql+=" and bhyt="+int.Parse(r["bhyt"].ToString());
					r2=d.getrowbyid(dtton,sql);
					if (r2!=null)
					{
						bFound=true;
						r["mabd"]=r2["id"].ToString();
						r["ten"]=r2["ten"].ToString();
						r["dang"]=r2["dang"].ToString();
						r["ma"]=r2["ma"].ToString();
						r["mahc"]=r2["mahc"].ToString();
						r["tenhc"]=r2["tenhc"].ToString();
						i_mabd=int.Parse(r2["id"].ToString());
					}
					else //tuong duong
					{
						foreach(DataRow r3 in d.get_data("select mabd,soluong from d_dmbdtd where id="+i_mabd).Tables[0].Rows)
						{
							_soluong=decimal.Parse(r["soluong"].ToString())*decimal.Parse(r3["soluong"].ToString());
							sql="id="+int.Parse(r3["mabd"].ToString())+" and soluong>="+d_soluong;
							sql+=" and bhyt="+int.Parse(r["bhyt"].ToString());
							r2=d.getrowbyid(dtton,sql);
							if (r2!=null)
							{
								r["mabd"]=r2["id"].ToString();
								r["ten"]=r2["ten"].ToString();
								r["dang"]=r2["dang"].ToString();
								r["ma"]=r2["ma"].ToString();
								r["mahc"]=r2["mahc"].ToString();
								r["tenhc"]=r2["tenhc"].ToString();
								r["soluong"]=_soluong;
								i_mabd=int.Parse(r2["id"].ToString());
								bFound=true;
								break;
							}
						}
						//hoatchat - hamluong - dvt 
						if (!bFound && r["tenhc"].ToString()!="")
						{
							sql="soluong>="+_soluong+" and tenhc='"+r["tenhc"].ToString()+"' and dang='"+r["dang"].ToString()+"' and hamluong='"+r["hamluong"].ToString()+"'";
							sql+=" and bhyt="+int.Parse(r["bhyt"].ToString());
							r2=d.getrowbyid(dtton,sql);
							if (r2!=null)
							{
								r["mabd"]=r2["id"].ToString();
								r["ten"]=r2["ten"].ToString();
								r["dang"]=r2["dang"].ToString();
								r["ma"]=r2["ma"].ToString();
								r["mahc"]=r2["mahc"].ToString();
								r["tenhc"]=r2["tenhc"].ToString();
								i_mabd=int.Parse(r2["id"].ToString());
							}
						}
					}
				}
				else bFound=true;
				if (!bFound) s_ten+=r["ten"].ToString().Trim()+"\n";
				else 
				{
					if (bSolan) d.updrec_dutruct_solan("-",dtct,m.get_stt(dtct),madoituong.Text,int.Parse(r["mabd"].ToString()),r["ma"].ToString(),r["ten"].ToString(),r["tenhc"].ToString(),r["dang"].ToString(),(makho.SelectedIndex!=-1)?makho.Text:"",decimal.Parse(r["soluong"].ToString()),int.Parse(r["madoituong"].ToString()),int.Parse(r1["makho"].ToString()),r["cachdung"].ToString(),r["mahc"].ToString(),int.Parse(r1["manguon"].ToString()),0,0,decimal.Parse(r["solan"].ToString()),decimal.Parse(r["lan"].ToString()),dtton);
					else d.updrec_dutruct("-",dtct,m.get_stt(dtct),madoituong.Text,int.Parse(r["mabd"].ToString()),r["ma"].ToString(),r["ten"].ToString(),r["tenhc"].ToString(),r["dang"].ToString(),(makho.SelectedIndex!=-1)?makho.Text:"",decimal.Parse(r["soluong"].ToString()),int.Parse(r["madoituong"].ToString()),int.Parse(r1["makho"].ToString()),r["cachdung"].ToString(),r["mahc"].ToString(),int.Parse(r1["manguon"].ToString()),0,0,dtton);
				}
			}
			if (s_ten.Length>0) MessageBox.Show("Những mặt hàng sau không đủ tồn\n"+s_ten,LibMedi.AccessData.Msg);
			ref_text();
		}

		private void frmBaohiem_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F8) diung_Click(sender,e);	
			else if (e.KeyCode==Keys.F3) butTheo_Click(sender,e);
			else if (e.KeyCode==Keys.F5) butCholai_Click(sender,e);
			else if (e.KeyCode==Keys.F6) butKhaibao_Click(sender,e);
			else if (e.KeyCode==Keys.F9) butIn_Click(sender,e);
		}

		private void diung_Click(object sender, System.EventArgs e)
		{
			if (cmbMabn.Items.Count==0) return;
			frmDiungthuoc f=new frmDiungthuoc(m,cmbMabn.Text,hoten.Text,"","");
			f.ShowDialog(this);
			load_diungthuoc(cmbMabn.Text);
		}

		private void load_diungthuoc(string mabn)
		{
			DataTable dt=m.get_data("select * from diungthuoc where mabn='"+mabn+"'").Tables[0];
			string s="";
			foreach(DataRow r in dt.Rows) s+=r["mahc"].ToString().Trim()+"+";
			diung.ForeColor=(dt.Rows.Count!=0)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
			diung.Tag=s;
		}

		private void get_items(int stt)
		{
			try
			{
				r=d.getrowbyid(dtton,"stt="+stt);
				if (r!=null)
				{
					mabd.Text=r["ma"].ToString();
					tenbd.Text=r["ten"].ToString();
					tenhc.Text=r["tenhc"].ToString();
					dang.Text=r["dang"].ToString();
					makho.SelectedValue=r["makho"].ToString();
					mahc.Text=r["mahc"].ToString().Trim();
					manguon.SelectedValue=r["manguon"].ToString();
					dvt.Text=dang.Text;
					#region diung
					if (bDiungthuoc)
					{
						bool bFound=false;
						if (diung.Tag.ToString()!="" && mahc.Text!="")
						{
							int i=0;
							while (i<diung.Tag.ToString().Length)
							{
								if (mahc.Text.IndexOf(diung.Tag.ToString().Substring(i,7))!=-1)
								{
									bFound=true;
									break;
								}
								i+=7;
							}
						}
						if (bFound)
						{
							if (MessageBox.Show("Người bệnh dị ứng thuốc \n"+tenhc.Text.Trim()+"\nBạn có đồng ý thêm vào không !",LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes) soluong.Focus();
							else
							{
								mabd.Text="";tenbd.Text="";tenhc.Text="";dang.Text="";mahc.Text="";
								mabd.Focus();
							}
						}
					}
					#endregion
					listDmbd.Hide();
					if (solan.Enabled) solan.Focus();
					else soluong.Focus();
				}
			}
			catch{}		
		}

		private void listDmbd_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				get_items(int.Parse(listDmbd.Text));
			}
			catch{}
		}

		private void mabd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDmbd.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				sql="ma like '"+mabd.Text.Trim()+"%'";
				DataRow [] dr=dtton.Select(sql);
				if (dr.Length==1)
				{
					mabd.Text=dr[0]["stt"].ToString();
					get_items(int.Parse(mabd.Text));
					if(!listDmbd.Focused) listDmbd.Hide();
					if (solan.Enabled) solan.Focus();
					else soluong.Focus();
				}
				else
				{
					if (listDmbd.Visible) 
					{
						listDmbd.Focus();
						SendKeys.Send("{Up}");
					}
					else SendKeys.Send("{Tab}");
				}
			}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			string lydo=m.get_lydokham(s_ngay,l_maql).Trim(),stuoi="",schandoan=chandoan.Text.Trim()+";";
			string tuden="Từ ngày "+s_ngay.Substring(0,10)+" đến "+m.DateToString("dd/MM/yyyy",m.StringToDate(s_ngay.Substring(0,10)).AddDays(Convert.ToDouble(songay.Value)));
			s_noidkkcb="";
			if (sothe.Text!="")
			{
				sql="select a.tenbv from "+user+".dmnoicapbhyt a,"+xxx+".bhyt b where a.mabv=b.mabv and b.sothe='"+sothe.Text+"' and b.maql="+l_maql;
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows) 
				{
					s_noidkkcb=r["tenbv"].ToString(); 
					break;
				}
				if (s_noidkkcb=="")
				{
					sql="select a.tenbv from "+user+".dmnoicapbhyt a,"+user+".bhyt b where a.mabv=b.mabv and b.sothe='"+sothe.Text+"' and b.maql="+l_maql;
					foreach(DataRow r in m.get_data(sql).Tables[0].Rows) 
					{
						s_noidkkcb=r["tenbv"].ToString(); 
						break;
					}
				}
			}
            foreach(DataRow r in m.get_data("select chandoan from "+xxx+".cdkemtheo where maql="+l_maql+" order by stt").Tables[0].Rows)
				schandoan+=r["chandoan"].ToString()+";";
			if (namsinh.Text!="") 
			{
				int tuoi=DateTime.Now.Year-int.Parse(namsinh.Text);
				stuoi=tuoi.ToString();
			}
			DataTable tmp;
			if (chkVP.Checked || i_bhyt_inrieng!=0)
			{
				sql="select a.stt,' ' doituong,b.ma,trim(b.ten)||' '||b.hamluong ten,nvl(b.tenhc,' ') tenhc,b.dang,f.ten tenkho,a.slyeucau soluong,"+i_madoituong+" as madoituong,a.makho,nvl(a.cachdung,' ') cachdung,b.mahc,' ' diung,a.manguon,b.bhyt as tutruc,0 idvpkhoa ";
				if (i_bhyt_inrieng==0) sql+=",0 as mabd";
				else sql+=",case when c.nhomvp="+i_bhyt_inrieng+" then 1 else 0 end as mabd";
				sql+=",nvl(u.hoten,' ') as tenuser";
				sql+=" from "+xxx+".d_thuocbhytct a,d_dmbd b,d_dmnhom c,d_dmkho f,"+xxx+".d_thuocbhytll d,dlogin u";
				sql+=" where a.id=d.id and a.mabd=b.id and b.manhom=c.id and a.makho=f.id and d.userid=u.id(+) and a.id="+l_id+" order by a.stt";
				DataSet dstmp=m.get_data(sql);
				if (chkVP.Checked)
				{
					string s="",s1="",ret="";
					decimal sl=1;
					sql="select rownum,mavp,soluong from v_chidinh where maql="+l_maql;
					DataTable dttmp=m.get_data_v(v.mmyy(s_ngay),sql).Tables[0];
					if (dttmp.Rows.Count>0)
					{
						foreach(DataRow r1 in dttmp.Select("true","rownum"))
						{
							s+=r1["mavp"].ToString().Trim().PadLeft(7,'0')+",";
							sl=decimal.Parse(r1["soluong"].ToString());
						}
						sql="select distinct id from v_trongoi where id_gia in ("+s.Substring(0,s.Length-1)+")";
						int rec=dttmp.Rows.Count;
						foreach(DataRow r2 in m.get_data(sql).Tables[0].Rows) 
						{
							sql="select id_gia,stt from v_trongoi where id="+int.Parse(r2["id"].ToString())+" order by stt";
							dttmp=m.get_data(sql).Tables[0];
							s1="";
							foreach(DataRow r1 in dttmp.Select("true","stt"))
								s1+=r1["id_gia"].ToString().Trim().PadLeft(7,'0')+",";
							if (s.IndexOf(s1)!=-1)
							{
								ret+=r2["id"].ToString()+",";
								s=s.Replace(s1,"");
							}
						}
					}
					int stt=dtct.Rows.Count;
					if (s!="")
					{
						sql="select rownum+"+stt+" as stt,' ' doituong,b.ma,trim(b.ten) ten,' ' tenhc,b.dvt as dang,' ' tenkho,a.soluong,a.madoituong,0 as makho,' ' as cachdung,' ' as mahc,' ' diung,0 as manguon,b.bhyt as tutruc,0 idvpkhoa ";
						if (i_bhyt_inrieng==0) sql+=",0 as mabd";
						else sql+=",case when d.ma="+i_bhyt_inrieng+" then 1 else 0 end as mabd";
						sql+=",nvl(u.hoten,' ') as tenuser";
						sql+=" from "+xxx+".v_chidinh a,v_giavp b,v_loaivp c,v_nhomvp d,dlogin u";
						sql+=" where a.mavp=b.id and b.id_loai=c.id and c.id_nhom=d.ma and a.userid=u.id(+) and a.maql="+l_maql;
						sql+=" and a.mavp in ("+s.Substring(0,s.Length-1)+")";
						dstmp.Merge(m.get_data(sql));
					}
					if (ret!="")
					{
						stt=dstmp.Tables[0].Rows.Count;
						sql="select rownum+"+stt+" as stt,' ' doituong,b.ma,trim(b.ten) ten,' ' tenhc,b.dvt as dang,' ' tenkho,"+sl+" as soluong,"+i_madoituong+" as madoituong,0 as makho,' ' as cachdung,' ' as mahc,' ' diung,0 as manguon,b.bhyt as tutruc,0 idvpkhoa ";
						if (i_bhyt_inrieng==0) sql+=",0 as mabd";
						else sql+=",case when d.ma="+i_bhyt_inrieng+" then 1 else 0 end as mabd";
						sql+=",' ' as tenuser";
						sql+=" from v_giavp b,v_loaivp c,v_nhomvp d ";
						sql+=" where b.id_loai=c.id and c.id_nhom=d.ma";
						if (ret!="") sql+=" and b.id in ("+ret.Substring(0,ret.Length-1)+")";
						dstmp.Merge(v.get_data(sql));
					}
				}
				tmp=dstmp.Tables[0];
			}
			else
			{
				sql="select a.stt,' ' doituong,0 as mabd,b.ma,trim(b.ten)||' '||b.hamluong ten,nvl(b.tenhc,' ') tenhc,";
				sql+="b.dang,f.ten tenkho,a.slyeucau soluong,"+i_madoituong+" as madoituong,a.makho,nvl(a.cachdung,' ') cachdung,";
				sql+="b.mahc,' ' diung,a.manguon,b.bhyt as tutruc,0 idvpkhoa,nvl(u.hoten,' ') as tenuser ";
				sql+=" from "+xxx+".d_thuocbhytct a,d_dmbd b,d_dmkho f,"+xxx+".d_thuocbhytll d,dlogin u ";
				sql+=" where a.id=d.id and a.mabd=b.id and a.makho=f.id and d.userid=u.id and a.id="+l_id+" order by a.stt";
				tmp=d.get_data(sql).Tables[0];
			}
			if(Directory.Exists("c:\\reportpic")==false)Directory.CreateDirectory("c:\\reportpic");
			if(Directory.Exists("..\\..\\..\\chuky\\")==false)Directory.CreateDirectory("..\\..\\..\\chuky\\");
			if(File.Exists("..\\..\\..\\chuky\\"+s_mabs+".bmp")==true)
				File.Copy("..\\..\\..\\chuky\\"+s_mabs+".bmp","c:\\reportpic\\chuky.bmp",true);
			else
				File.Copy("..\\..\\..\\xml\\000.bmp","c:\\reportpic\\chuky.bmp",true);
			if (m.bPreview)
			{
				frmReport f=new frmReport(m,tmp,"d_donthuoc.rpt",hoten.Text+"^"+s_phai,stuoi.Trim()+"^"+tuden,((sothe.Text.Trim()=="")?" ":sothe.Text.Trim())+"^"+s_noidkkcb,schandoan,s_diachi,tenbs.Text,dtct.Rows.Count.ToString(),mabn.Text,(lydo!="")?lydo:ghichu.Text,s_doituong+"^"+s_ngay);
				f.ShowDialog(this);
			}
			else print.Printer(m,tmp,"d_donthuoc.rpt",hoten.Text+"^"+s_phai,stuoi.Trim()+"^"+tuden,((sothe.Text.Trim()=="")?" ":sothe.Text.Trim())+"^"+s_noidkkcb,schandoan,s_diachi,tenbs.Text,dtct.Rows.Count.ToString(),mabn.Text,(lydo!="")?lydo:ghichu.Text,s_doituong+"^"+s_ngay,1);
		}

		private void butHen_Click(object sender, System.EventArgs e)
		{
			try
			{
				Lichhen.LICHHEN f=new Lichhen.LICHHEN(mabn.Text,l_maql,s_makp,s_mabs,0,3);
				f.ShowDialog(this);
				//if (f.strGhichu!="") ghichu.Text=f.strGhichu.Trim();
			}
			catch{}
		}

		private void butKhaibao_Click(object sender, System.EventArgs e)
		{
			if (dtct.Rows.Count>0)
			{
				long id_donthuoc=d.get_id_donthuoc_bacsy(s_mabs,maicd.Text);
				if (id_donthuoc!=0) d.execute_data("delete from d_theodonct where id="+id_donthuoc);
				else id_donthuoc=d.get_id_donthuoc_bacsy();
				d.upd_theodonll(id_donthuoc,s_mabs,maicd.Text,"",1,1,songay.Value);
				foreach(DataRow r in dtct.Rows)
					d.upd_theodonct(id_donthuoc,int.Parse(r["mabd"].ToString()),decimal.Parse(r["soluong"].ToString()),r["cachdung"].ToString());
				butMoi.Focus();
			}
		}

		private void butTheo_Click(object sender, System.EventArgs e)
		{
			long id_donthuoc=d.get_id_donthuoc_bacsy(s_mabs,maicd.Text);
			if (id_donthuoc!=0)
			{
				string s_ten="";
				sql="select a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.dang,b.mahc,nvl(b.tenhc,' ') tenhc,a.soluong,a.cachdung from d_theodonct a,d_dmbd b";
				sql+=" where a.mabd=b.id and a.id="+id_donthuoc;
				DataRow r1;
				foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
				{
					r1=d.getrowbyid(dtton,"id="+int.Parse(r["mabd"].ToString()));
					if (r1!=null)
					{
						d_soluongton=d.get_slton_nguon_tutruc(dtton,int.Parse(r1["makho"].ToString()),int.Parse(r["mabd"].ToString()),int.Parse(r1["manguon"].ToString()),0,0);
						if (decimal.Parse(r["soluong"].ToString())>d_soluongton) s_ten+=r["ten"].ToString().Trim()+"\n";
						else d.updrec_dutruct("-",dtct,m.get_stt(dtct),"",int.Parse(r["mabd"].ToString()),r["ma"].ToString(),r["ten"].ToString(),r["tenhc"].ToString(),r["dang"].ToString(),(makho.SelectedIndex!=-1)?makho.Text:"",decimal.Parse(r["soluong"].ToString()),1,int.Parse(r1["makho"].ToString()),r["cachdung"].ToString(),r["mahc"].ToString(),int.Parse(r1["manguon"].ToString()),0,0,dtton);
					}
					if (s_ten.Length>0) MessageBox.Show("Những mặt hàng sau không đủ tồn\n"+s_ten,LibMedi.AccessData.Msg);
				}
				ref_text();
			}
			else MessageBox.Show("Không có trong danh mục !",LibMedi.AccessData.Msg);
		}

		private void ghichu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void solan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void solan_Validated(object sender, System.EventArgs e)
		{
			gc_cachdung();
		}
	
		private void gc_cachdung()
		{
			if (lan.Text!="")
			{
				r=d.getrowbyid(dtton,"ma='"+mabd.Text+"'");			
				if (r!=null)
				{
					DataRow r1=d.getrowbyid(dtdmbd,"id="+int.Parse(r["id"].ToString()));
					if (r1!=null)
						cachdung.Text=r1["duongdung"].ToString().Trim()+" ngày "+solan.Value.ToString()+" lần , lần "+lan.Text.ToString().Trim()+" "+r1["dang"].ToString().Trim(); 						
				}
				else cachdung.Text="ngày "+solan.Value.ToString()+" lần , lần "+lan.Text.ToString().Trim()+" "+dang.Text.Trim();
				decimal sl=Math.Max(1,songay.Value)*solan.Value*decimal.Parse(lan.Text);
				soluong.Text=sl.ToString();
				soluong.Refresh();
				soluong_Validated(null,null);
			}
		}

		private void chkChon_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==chkChon && donthuoc.SelectedIndex!=-1) get_don();
		}

		private void donthuoc_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==donthuoc && donthuoc.SelectedIndex!=-1) 
			{
				dtct.Clear();
				get_don();
			}
		}

		private void madoituong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (madoituong.SelectedIndex==-1) madoituong.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private DataTable load_thuoc(long id)
		{
			sql="select a.stt,0 sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong ten,";
			sql+=" b.tenhc,b.dang,e.ten tenkho,c.ten tennguon,' ' tennhomcc,";
			sql+=" ' ' handung,' ' losx,a.slyeucau soluong,0 dongia,0 sotien,0 giaban,0 sotienmua,";
			sql+=" a.cachdung,a.makho,a.manguon,0 nhomcc,0 giamua,a.madoituong ";
			sql+=" from "+xxx+".d_thuocbhytct a,d_dmbd b,d_dmnguon c,d_dmkho e ";
			sql+=" where a.mabd=b.id and a.manguon=c.id and a.makho=e.id ";
			sql+=" and a.id="+id+" order by a.stt";
			return d.get_data(sql).Tables[0];
		}

		private void upd_duoc()
		{
			if (!bNew)
			{
				foreach(DataRow r1 in d.get_data(s_mmyy,"select * from bhytthuoc where id="+l_id).Tables[0].Rows)
				{
					d.execute_data(s_mmyy,"delete from bhytthuoc where id="+l_id+" and stt="+long.Parse(r1["stt"].ToString()));
					d.upd_tonkhoct_xuat(d.delete,s_mmyy,long.Parse(r1["sttt"].ToString()),int.Parse(r1["makho"].ToString()),int.Parse(r1["manguon"].ToString()),int.Parse(r1["nhomcc"].ToString()),int.Parse(r1["mabd"].ToString()),r1["handung"].ToString(),r1["losx"].ToString(),decimal.Parse(r1["soluong"].ToString()),decimal.Parse(r1["sotienmua"].ToString()),decimal.Parse(r1["giaban"].ToString()),decimal.Parse(r1["giamua"].ToString()));
				}
			}
			if (!d.upd_bhytkb(l_id,i_nhom,s_ngay,s_mabn,l_maql,s_makp,s_Chandoan,s_Maicd,s_mabs,s_Sothe,i_madoituong,s_noidkkcb,s_mmyy,iUserid_duyet,3))
			{
				MessageBox.Show("Không cập nhật được thông tin !",LibMedi.AccessData.Msg);
				return;
			}
			if (!d.upd_bhytds(s_mmyy,s_mabn,s_Hoten,s_Namsinh,s_diachi))
			{
				MessageBox.Show("Không cập nhật được thông tin !",LibMedi.AccessData.Msg);
				return;
			}
			DataTable tmp=d.get_bhytthuoc(s_mmyy,load_thuoc(l_id),l_id,(i_loaiba==2)?0:i_madoituong);
			d.execute_data("update "+xxx+".d_thuocbhytll set done=1 where id="+l_id);
		}

		private void chkThuoc_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==chkThuoc)
			{
				if (chkThuoc.Checked) load_treeview();
				else treeView1.Nodes.Clear();
			}		
		}
	}
}
