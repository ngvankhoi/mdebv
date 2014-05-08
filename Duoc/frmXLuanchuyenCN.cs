using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using dichso;
using LibMedi;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Duoc
{
	public class frmXLuanchuyenCN : System.Windows.Forms.Form
    {
        #region Khai bao
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private MaskedBox.MaskedBox ngaysp;
		private LibList.List listDMBD;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label lTen;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox tenbd;
		private System.Windows.Forms.TextBox mabd;
		private MaskedBox.MaskedBox dang;
		private MaskedTextBox.MaskedTextBox soluong;
		private MaskedTextBox.MaskedTextBox dongia;
		private MaskedTextBox.MaskedTextBox sotien;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butThem;
		private System.Windows.Forms.Button butXoa;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.ComboBox cmbSophieu;
		private string xxx,user,s_mmyy,s_ngay,sql,s_loai,s_ngaysp,s_makho,format_soluong,format_dongia,format_sotien,s_loaikhac,s_userid,l_id_kehoachdathang;
		private int i_nhom,i_userid,i_mabd,i_old,i_songay,itable,i_current_row=-1,i_index_datagrid=-1;
        private int i_IDCN_Nhan = 0;
        private string s_DBLink_CNNhan = "";
        private decimal l_id, l_sttt, l_duyet;
		private decimal d_soluong,d_dongia,d_sotien,d_giaban,d_soluongton,d_soluongcu,d_tongcong,d_vat;
        private bool bKhoaso, bNew, bEdit = false, bGiaban, bAdmin, bNhom_nx, bSophieu, bLockytu, b701424, bSophieu_kho, bQuanly_xuatban_theomavach = false, bVattu;
        
        private bool bTrutonao = false, bKhongchohuy = false;
		private LibDuoc.AccessData d;
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private dichso.numbertotext doiso=new dichso.numbertotext();
		private DataTable dtton=new DataTable();
		private DataTable dtll=new DataTable();
		private DataTable dtct=new DataTable("table");
        private DataTable dtct_mavach = new DataTable("table");
		private DataTable dtsave=new DataTable();
		private DataSet dsxoa=new DataSet();
		private DataSet dssp=new DataSet();
        private DataTable dtkhox = new DataTable();
        DataTable dtphieukh;
		private System.Windows.Forms.Label ldvt;
		private DataRow r;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label24;
		private MaskedBox.MaskedBox handung;
		private MaskedBox.MaskedBox losx;
		private System.Windows.Forms.TextBox tenhc;
		private System.Windows.Forms.Label lTenhc;
		private MaskedTextBox.MaskedTextBox sophieu;
		private MaskedTextBox.MaskedTextBox giaban;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.ComboBox khox;
		private System.Windows.Forms.ComboBox khon;
		private MaskedTextBox.MaskedTextBox lydo;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox manguon;
		private System.Windows.Forms.ComboBox nhomcc;
		private System.Windows.Forms.TextBox stt;
		private System.Windows.Forms.TextBox sttt;
		private System.Drawing.Printing.PrintDocument docToPrint = new System.Drawing.Printing.PrintDocument();
		private PrintDialog p=new PrintDialog();
		private DialogResult result;
        private System.Windows.Forms.TextBox find;
		private System.Windows.Forms.CheckBox chkSophieu;
        private CheckBox chkXML;
        private CheckBox chkGianovat;
        private CheckBox chkgiaban;
        private CheckBox chkXem;
        private Label label4;
        private TextBox mavach_sttt;
        private Label label5;
        private ComboBox cbChinhanh;
        private DataSet dschinhanh;
        private int ichinhanh = 0;
        private ComboBox cboSophieu;
        private Label label6;
        private TextBox slton;
        private DataGrid dataGrid2;
        private TextBox txtid;
        private TextBox txtsttt;
        private Label lblTonkho;
        private Label label7;
        private TextBox txtvat;
        private CheckBox chkLosx;
        private ComboBox cmbxuat;
        private Label label11;

        private bool bXuatChuyenTheoKeHoach = false;//True: giong hep, False: Du tru kho cap --> Kho nhan duyet luon: khong qua buoc lap ke hoach (Van phuc)
        #endregion
        private Button butchuyen;

        private System.ComponentModel.Container components = null;
        private bool b_duyetTheoDutruKhoCuaChiNhanh = false;
		public frmXLuanchuyenCN(LibDuoc.AccessData acc,string loai,string mmyy,string ngay,int nhom,int userid,string kho,string title,bool b_giaban,bool admin,string _loaikhac,string _userid,bool view,int _ichinhanh, bool _duyetTheoDutruKhoCuaChiNhanh)
		{
			InitializeComponent();
            d = acc; i_nhom = nhom; s_makho = kho; i_userid = userid; s_mmyy = mmyy;
            s_ngay = ngay; s_loai = loai; s_loaikhac = _loaikhac;
            bGiaban = b_giaban; bAdmin = (!view) ? admin : true; this.Text = title; s_userid = _userid;
            ichinhanh = _ichinhanh;
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            butMoi.Enabled = butSua.Enabled = butHuy.Enabled = butIn.Enabled = !view;
            b_duyetTheoDutruKhoCuaChiNhanh = _duyetTheoDutruKhoCuaChiNhanh;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXLuanchuyenCN));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ngaysp = new MaskedBox.MaskedBox();
            this.khox = new System.Windows.Forms.ComboBox();
            this.khon = new System.Windows.Forms.ComboBox();
            this.listDMBD = new LibList.List();
            this.label13 = new System.Windows.Forms.Label();
            this.lTen = new System.Windows.Forms.Label();
            this.ldvt = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tenbd = new System.Windows.Forms.TextBox();
            this.mabd = new System.Windows.Forms.TextBox();
            this.dang = new MaskedBox.MaskedBox();
            this.soluong = new MaskedTextBox.MaskedTextBox();
            this.dongia = new MaskedTextBox.MaskedTextBox();
            this.sotien = new MaskedTextBox.MaskedTextBox();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butThem = new System.Windows.Forms.Button();
            this.butXoa = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.cmbSophieu = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.handung = new MaskedBox.MaskedBox();
            this.losx = new MaskedBox.MaskedBox();
            this.tenhc = new System.Windows.Forms.TextBox();
            this.lTenhc = new System.Windows.Forms.Label();
            this.sophieu = new MaskedTextBox.MaskedTextBox();
            this.lydo = new MaskedTextBox.MaskedTextBox();
            this.giaban = new MaskedTextBox.MaskedTextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label3 = new System.Windows.Forms.Label();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.nhomcc = new System.Windows.Forms.ComboBox();
            this.stt = new System.Windows.Forms.TextBox();
            this.sttt = new System.Windows.Forms.TextBox();
            this.find = new System.Windows.Forms.TextBox();
            this.chkSophieu = new System.Windows.Forms.CheckBox();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.chkGianovat = new System.Windows.Forms.CheckBox();
            this.chkgiaban = new System.Windows.Forms.CheckBox();
            this.chkXem = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mavach_sttt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbChinhanh = new System.Windows.Forms.ComboBox();
            this.cboSophieu = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.slton = new System.Windows.Forms.TextBox();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.txtid = new System.Windows.Forms.TextBox();
            this.txtsttt = new System.Windows.Forms.TextBox();
            this.lblTonkho = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtvat = new System.Windows.Forms.TextBox();
            this.chkLosx = new System.Windows.Forms.CheckBox();
            this.cmbxuat = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.butchuyen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(31, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số phiếu :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(203, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(740, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 23);
            this.label8.TabIndex = 7;
            this.label8.Text = "Ghi chú :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(388, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 23);
            this.label9.TabIndex = 8;
            this.label9.Text = "Kho xuất : ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(534, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 23);
            this.label10.TabIndex = 9;
            this.label10.Text = "Lý do :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngaysp
            // 
            this.ngaysp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaysp.Enabled = false;
            this.ngaysp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysp.Location = new System.Drawing.Point(248, 3);
            this.ngaysp.Mask = "##/##/####";
            this.ngaysp.MaxLength = 10;
            this.ngaysp.Name = "ngaysp";
            this.ngaysp.Size = new System.Drawing.Size(64, 21);
            this.ngaysp.TabIndex = 1;
            this.ngaysp.Text = "  /  /    ";
            this.ngaysp.Validated += new System.EventHandler(this.ngaysp_Validated);
            // 
            // khox
            // 
            this.khox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.khox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.khox.Enabled = false;
            this.khox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khox.Location = new System.Drawing.Point(446, 3);
            this.khox.Name = "khox";
            this.khox.Size = new System.Drawing.Size(144, 21);
            this.khox.TabIndex = 2;
            this.khox.SelectedIndexChanged += new System.EventHandler(this.khox_SelectedIndexChanged);
            this.khox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.khox_KeyDown);
            // 
            // khon
            // 
            this.khon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.khon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.khon.Enabled = false;
            this.khon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khon.Location = new System.Drawing.Point(622, 4);
            this.khon.Name = "khon";
            this.khon.Size = new System.Drawing.Size(135, 21);
            this.khon.TabIndex = 3;
            this.khon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.khon_KeyDown);
            // 
            // listDMBD
            // 
            this.listDMBD.BackColor = System.Drawing.SystemColors.Info;
            this.listDMBD.ColumnCount = 0;
            this.listDMBD.Location = new System.Drawing.Point(355, 544);
            this.listDMBD.MatchBufferTimeOut = 1000;
            this.listDMBD.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listDMBD.Name = "listDMBD";
            this.listDMBD.Size = new System.Drawing.Size(75, 17);
            this.listDMBD.TabIndex = 26;
            this.listDMBD.TextIndex = -1;
            this.listDMBD.TextMember = null;
            this.listDMBD.ValueIndex = -1;
            this.listDMBD.Visible = false;
            this.listDMBD.DoubleClick += new System.EventHandler(this.listDMBD_DoubleClick);
            this.listDMBD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listDMBD_KeyDown);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.Location = new System.Drawing.Point(18, 433);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 23);
            this.label13.TabIndex = 28;
            this.label13.Text = "Mã :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lTen
            // 
            this.lTen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTen.Location = new System.Drawing.Point(97, 433);
            this.lTen.Name = "lTen";
            this.lTen.Size = new System.Drawing.Size(41, 23);
            this.lTen.TabIndex = 29;
            this.lTen.Text = "Tên :";
            this.lTen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ldvt
            // 
            this.ldvt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ldvt.Location = new System.Drawing.Point(5, 456);
            this.ldvt.Name = "ldvt";
            this.ldvt.Size = new System.Drawing.Size(45, 23);
            this.ldvt.TabIndex = 30;
            this.ldvt.Text = "ĐVT :";
            this.ldvt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.Location = new System.Drawing.Point(112, 455);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 23);
            this.label16.TabIndex = 31;
            this.label16.Text = "Số lượng :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.Location = new System.Drawing.Point(256, 455);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 23);
            this.label17.TabIndex = 32;
            this.label17.Text = "Đơn giá :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label18.Location = new System.Drawing.Point(443, 455);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 23);
            this.label18.TabIndex = 33;
            this.label18.Text = "Số tiền :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.Location = new System.Drawing.Point(-14, 479);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 23);
            this.label20.TabIndex = 35;
            this.label20.Text = "Nguồn :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenbd
            // 
            this.tenbd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tenbd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbd.Enabled = false;
            this.tenbd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbd.Location = new System.Drawing.Point(136, 433);
            this.tenbd.Name = "tenbd";
            this.tenbd.Size = new System.Drawing.Size(304, 21);
            this.tenbd.TabIndex = 10;
            this.tenbd.TextChanged += new System.EventHandler(this.tenbd_TextChanged);
            this.tenbd.Validated += new System.EventHandler(this.tenbd_Validated);
            this.tenbd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbd_KeyDown);
            // 
            // mabd
            // 
            this.mabd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mabd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabd.Enabled = false;
            this.mabd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabd.Location = new System.Drawing.Point(50, 433);
            this.mabd.Name = "mabd";
            this.mabd.Size = new System.Drawing.Size(57, 21);
            this.mabd.TabIndex = 9;
            this.mabd.TextChanged += new System.EventHandler(this.mabd_TextChanged);
            this.mabd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabd_KeyDown);
            // 
            // dang
            // 
            this.dang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dang.Enabled = false;
            this.dang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dang.Location = new System.Drawing.Point(50, 456);
            this.dang.Mask = "";
            this.dang.MaxLength = 10;
            this.dang.Name = "dang";
            this.dang.Size = new System.Drawing.Size(57, 21);
            this.dang.TabIndex = 12;
            // 
            // soluong
            // 
            this.soluong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(168, 456);
            this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(88, 21);
            this.soluong.TabIndex = 13;
            this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
            this.soluong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.soluong_KeyDown);
            // 
            // dongia
            // 
            this.dongia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dongia.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dongia.Enabled = false;
            this.dongia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dongia.Location = new System.Drawing.Point(312, 456);
            this.dongia.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.dongia.Name = "dongia";
            this.dongia.Size = new System.Drawing.Size(128, 21);
            this.dongia.TabIndex = 14;
            this.dongia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // sotien
            // 
            this.sotien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sotien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sotien.Enabled = false;
            this.sotien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sotien.Location = new System.Drawing.Point(498, 456);
            this.sotien.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sotien.Name = "sotien";
            this.sotien.Size = new System.Drawing.Size(233, 21);
            this.sotien.TabIndex = 15;
            this.sotien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butMoi.Image = global::Duoc.Properties.Resources.add;
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(183, 506);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 21;
            this.butMoi.Text = "     &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSua.Image = global::Duoc.Properties.Resources.quick_edit;
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(253, 506);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 22;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = global::Duoc.Properties.Resources.save;
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(323, 506);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 24;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butThem
            // 
            this.butThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butThem.Enabled = false;
            this.butThem.Image = global::Duoc.Properties.Resources.plus;
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(393, 506);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(70, 25);
            this.butThem.TabIndex = 23;
            this.butThem.Text = "&Thêm";
            this.butThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // butXoa
            // 
            this.butXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butXoa.Enabled = false;
            this.butXoa.Image = global::Duoc.Properties.Resources.Cancel;
            this.butXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXoa.Location = new System.Drawing.Point(463, 506);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(70, 25);
            this.butXoa.TabIndex = 25;
            this.butXoa.Text = "     &Xóa";
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = global::Duoc.Properties.Resources.undo_ok;
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(533, 506);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 26;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butHuy.Image = global::Duoc.Properties.Resources.delete_enabled;
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(603, 506);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 27;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butIn.Image = global::Duoc.Properties.Resources.F9;
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(673, 506);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 28;
            this.butIn.Text = "    &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(743, 506);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 29;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // cmbSophieu
            // 
            this.cmbSophieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSophieu.Location = new System.Drawing.Point(85, 3);
            this.cmbSophieu.Name = "cmbSophieu";
            this.cmbSophieu.Size = new System.Drawing.Size(130, 21);
            this.cmbSophieu.TabIndex = 0;
            this.cmbSophieu.SelectedIndexChanged += new System.EventHandler(this.cmbSophieu_SelectedIndexChanged);
            this.cmbSophieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSophieu_KeyDown);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.Location = new System.Drawing.Point(530, 479);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 23);
            this.label15.TabIndex = 61;
            this.label15.Text = "Hạn dùng :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label24.Location = new System.Drawing.Point(619, 479);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(80, 23);
            this.label24.TabIndex = 62;
            this.label24.Text = "Lô sản xuất :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // handung
            // 
            this.handung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.handung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.handung.Enabled = false;
            this.handung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.handung.Location = new System.Drawing.Point(590, 479);
            this.handung.Mask = "####";
            this.handung.Name = "handung";
            this.handung.Size = new System.Drawing.Size(40, 21);
            this.handung.TabIndex = 19;
            this.handung.Text = "    ";
            // 
            // losx
            // 
            this.losx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.losx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.losx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.losx.Enabled = false;
            this.losx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.losx.Location = new System.Drawing.Point(696, 479);
            this.losx.Mask = "&&&&&&&&&&";
            this.losx.MaxLength = 10;
            this.losx.Name = "losx";
            this.losx.Size = new System.Drawing.Size(187, 21);
            this.losx.TabIndex = 20;
            this.losx.Text = "          ";
            // 
            // tenhc
            // 
            this.tenhc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenhc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenhc.Enabled = false;
            this.tenhc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenhc.Location = new System.Drawing.Point(498, 433);
            this.tenhc.Name = "tenhc";
            this.tenhc.Size = new System.Drawing.Size(385, 21);
            this.tenhc.TabIndex = 11;
            // 
            // lTenhc
            // 
            this.lTenhc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTenhc.Location = new System.Drawing.Point(433, 432);
            this.lTenhc.Name = "lTenhc";
            this.lTenhc.Size = new System.Drawing.Size(66, 23);
            this.lTenhc.TabIndex = 64;
            this.lTenhc.Text = "Hoạt chất :";
            this.lTenhc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sophieu
            // 
            this.sophieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sophieu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sophieu.Enabled = false;
            this.sophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sophieu.Location = new System.Drawing.Point(88, 3);
            this.sophieu.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sophieu.Name = "sophieu";
            this.sophieu.Size = new System.Drawing.Size(127, 21);
            this.sophieu.TabIndex = 1;
            this.sophieu.Validated += new System.EventHandler(this.sophieu_Validated);
            // 
            // lydo
            // 
            this.lydo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lydo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lydo.Enabled = false;
            this.lydo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lydo.Location = new System.Drawing.Point(802, 4);
            this.lydo.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.lydo.Name = "lydo";
            this.lydo.Size = new System.Drawing.Size(81, 21);
            this.lydo.TabIndex = 4;
            // 
            // giaban
            // 
            this.giaban.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.giaban.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giaban.Enabled = false;
            this.giaban.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giaban.Location = new System.Drawing.Point(416, 479);
            this.giaban.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.giaban.Name = "giaban";
            this.giaban.Size = new System.Drawing.Size(111, 21);
            this.giaban.TabIndex = 18;
            this.giaban.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label25.Location = new System.Drawing.Point(361, 479);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 23);
            this.label25.TabIndex = 66;
            this.label25.Text = "Giá bán :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 31);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(875, 183);
            this.dataGrid1.TabIndex = 27;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(149, 479);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 23);
            this.label3.TabIndex = 67;
            this.label3.Text = "Nhà CC :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // manguon
            // 
            this.manguon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.manguon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manguon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manguon.Enabled = false;
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(50, 479);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(116, 21);
            this.manguon.TabIndex = 16;
            // 
            // nhomcc
            // 
            this.nhomcc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nhomcc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhomcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhomcc.Enabled = false;
            this.nhomcc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhomcc.Location = new System.Drawing.Point(224, 479);
            this.nhomcc.Name = "nhomcc";
            this.nhomcc.Size = new System.Drawing.Size(139, 21);
            this.nhomcc.TabIndex = 17;
            // 
            // stt
            // 
            this.stt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stt.Location = new System.Drawing.Point(83, 543);
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(24, 20);
            this.stt.TabIndex = 68;
            this.stt.Visible = false;
            // 
            // sttt
            // 
            this.sttt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sttt.Location = new System.Drawing.Point(114, 540);
            this.sttt.Name = "sttt";
            this.sttt.Size = new System.Drawing.Size(24, 20);
            this.sttt.TabIndex = 69;
            this.sttt.Visible = false;
            // 
            // find
            // 
            this.find.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.find.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.find.Location = new System.Drawing.Point(596, 27);
            this.find.Name = "find";
            this.find.Size = new System.Drawing.Size(287, 21);
            this.find.TabIndex = 7;
            this.find.Text = "Tìm kiếm";
            this.find.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.find.TextChanged += new System.EventHandler(this.find_TextChanged);
            this.find.Enter += new System.EventHandler(this.find_Enter);
            // 
            // chkSophieu
            // 
            this.chkSophieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSophieu.Checked = true;
            this.chkSophieu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSophieu.Location = new System.Drawing.Point(771, 455);
            this.chkSophieu.Name = "chkSophieu";
            this.chkSophieu.Size = new System.Drawing.Size(112, 24);
            this.chkSophieu.TabIndex = 108;
            this.chkSophieu.Text = "Số phiếu tự động";
            this.chkSophieu.CheckedChanged += new System.EventHandler(this.chkSophieu_CheckedChanged);
            // 
            // chkXML
            // 
            this.chkXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkXML.AutoSize = true;
            this.chkXML.Location = new System.Drawing.Point(50, 511);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(73, 17);
            this.chkXML.TabIndex = 113;
            this.chkXML.Text = "Xuất XML";
            this.chkXML.UseVisualStyleBackColor = true;
            // 
            // chkGianovat
            // 
            this.chkGianovat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkGianovat.AutoSize = true;
            this.chkGianovat.Location = new System.Drawing.Point(501, 412);
            this.chkGianovat.Name = "chkGianovat";
            this.chkGianovat.Size = new System.Drawing.Size(127, 17);
            this.chkGianovat.TabIndex = 117;
            this.chkGianovat.Text = "In theo giá trước VAT";
            this.chkGianovat.UseVisualStyleBackColor = true;
            this.chkGianovat.Visible = false;
            this.chkGianovat.Click += new System.EventHandler(this.chkGianovat_Click);
            // 
            // chkgiaban
            // 
            this.chkgiaban.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkgiaban.AutoSize = true;
            this.chkgiaban.Location = new System.Drawing.Point(632, 412);
            this.chkgiaban.Name = "chkgiaban";
            this.chkgiaban.Size = new System.Drawing.Size(97, 17);
            this.chkgiaban.TabIndex = 116;
            this.chkgiaban.Text = "In theo giá bán";
            this.chkgiaban.UseVisualStyleBackColor = true;
            this.chkgiaban.Visible = false;
            this.chkgiaban.Click += new System.EventHandler(this.chkgiaban_Click);
            // 
            // chkXem
            // 
            this.chkXem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkXem.AutoSize = true;
            this.chkXem.Location = new System.Drawing.Point(736, 412);
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(102, 17);
            this.chkXem.TabIndex = 115;
            this.chkXem.Text = "Xem trước khi in";
            this.chkXem.UseVisualStyleBackColor = true;
            this.chkXem.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Location = new System.Drawing.Point(-5, 412);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 23);
            this.label4.TabIndex = 118;
            this.label4.Text = "Mã vạch:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mavach_sttt
            // 
            this.mavach_sttt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mavach_sttt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mavach_sttt.Enabled = false;
            this.mavach_sttt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mavach_sttt.Location = new System.Drawing.Point(50, 409);
            this.mavach_sttt.Name = "mavach_sttt";
            this.mavach_sttt.Size = new System.Drawing.Size(180, 21);
            this.mavach_sttt.TabIndex = 8;
            this.mavach_sttt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mavach_sttt.Validated += new System.EventHandler(this.mavach_sttt_Validated);
            this.mavach_sttt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mavach_sttt_KeyDown);
            this.mavach_sttt.Leave += new System.EventHandler(this.mavach_sttt_Leave);
            this.mavach_sttt.Enter += new System.EventHandler(this.mavach_sttt_Enter);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-2, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "Chuyển cho CN :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbChinhanh
            // 
            this.cbChinhanh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbChinhanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChinhanh.Enabled = false;
            this.cbChinhanh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChinhanh.Location = new System.Drawing.Point(85, 26);
            this.cbChinhanh.Name = "cbChinhanh";
            this.cbChinhanh.Size = new System.Drawing.Size(227, 21);
            this.cbChinhanh.TabIndex = 5;
            this.cbChinhanh.SelectedIndexChanged += new System.EventHandler(this.cbChinhanh_SelectedIndexChanged);
            this.cbChinhanh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.khon_KeyDown);
            // 
            // cboSophieu
            // 
            this.cboSophieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cboSophieu.DropDownWidth = 200;
            this.cboSophieu.Enabled = false;
            this.cboSophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSophieu.Location = new System.Drawing.Point(446, 26);
            this.cboSophieu.Name = "cboSophieu";
            this.cboSophieu.Size = new System.Drawing.Size(144, 21);
            this.cboSophieu.TabIndex = 6;
            this.cboSophieu.SelectedIndexChanged += new System.EventHandler(this.cboSophieu_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(346, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 18);
            this.label6.TabIndex = 120;
            this.label6.Text = "Số phiếu kế hoạch :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // slton
            // 
            this.slton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.slton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.slton.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.slton.Enabled = false;
            this.slton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slton.Location = new System.Drawing.Point(292, 543);
            this.slton.Name = "slton";
            this.slton.Size = new System.Drawing.Size(57, 21);
            this.slton.TabIndex = 121;
            this.slton.Visible = false;
            // 
            // dataGrid2
            // 
            this.dataGrid2.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid2.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.CaptionText = "Danh sách các sản phẩm xuất cho chi nhánh";
            this.dataGrid2.DataMember = "";
            this.dataGrid2.FlatMode = true;
            this.dataGrid2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid2.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid2.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid2.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid2.Location = new System.Drawing.Point(8, 220);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid2.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.RowHeaderWidth = 10;
            this.dataGrid2.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid2.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.Size = new System.Drawing.Size(875, 182);
            this.dataGrid2.TabIndex = 122;
            this.dataGrid2.CurrentCellChanged += new System.EventHandler(this.dataGrid2_CurrentCellChanged);
            // 
            // txtid
            // 
            this.txtid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtid.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtid.Enabled = false;
            this.txtid.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtid.Location = new System.Drawing.Point(229, 543);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(57, 21);
            this.txtid.TabIndex = 123;
            this.txtid.Visible = false;
            // 
            // txtsttt
            // 
            this.txtsttt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtsttt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtsttt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtsttt.Enabled = false;
            this.txtsttt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsttt.Location = new System.Drawing.Point(152, 543);
            this.txtsttt.Name = "txtsttt";
            this.txtsttt.Size = new System.Drawing.Size(57, 21);
            this.txtsttt.TabIndex = 124;
            this.txtsttt.Visible = false;
            // 
            // lblTonkho
            // 
            this.lblTonkho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTonkho.ForeColor = System.Drawing.Color.Red;
            this.lblTonkho.Location = new System.Drawing.Point(284, 406);
            this.lblTonkho.Name = "lblTonkho";
            this.lblTonkho.Size = new System.Drawing.Size(156, 23);
            this.lblTonkho.TabIndex = 125;
            this.lblTonkho.Text = "0";
            this.lblTonkho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(231, 406);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 23);
            this.label7.TabIndex = 126;
            this.label7.Text = "Tồn kho :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtvat
            // 
            this.txtvat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtvat.Location = new System.Drawing.Point(439, 537);
            this.txtvat.Name = "txtvat";
            this.txtvat.Size = new System.Drawing.Size(24, 20);
            this.txtvat.TabIndex = 127;
            this.txtvat.Visible = false;
            // 
            // chkLosx
            // 
            this.chkLosx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkLosx.AutoSize = true;
            this.chkLosx.Checked = true;
            this.chkLosx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLosx.Location = new System.Drawing.Point(617, 412);
            this.chkLosx.Name = "chkLosx";
            this.chkLosx.Size = new System.Drawing.Size(115, 17);
            this.chkLosx.TabIndex = 128;
            this.chkLosx.Text = "Xem theo mã vạch";
            this.chkLosx.UseVisualStyleBackColor = true;
            this.chkLosx.Click += new System.EventHandler(this.chkLosx_Click);
            // 
            // cmbxuat
            // 
            this.cmbxuat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxuat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxuat.Items.AddRange(new object[] {
            "Thuốc",
            "Vật tư",
            "Tất cả"});
            this.cmbxuat.Location = new System.Drawing.Point(344, 3);
            this.cmbxuat.Name = "cmbxuat";
            this.cmbxuat.Size = new System.Drawing.Size(53, 21);
            this.cmbxuat.TabIndex = 135;
            this.cmbxuat.SelectedIndexChanged += new System.EventHandler(this.cmbxuat_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(290, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 23);
            this.label11.TabIndex = 136;
            this.label11.Text = "Xuất :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butchuyen
            // 
            this.butchuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butchuyen.Image = global::Duoc.Properties.Resources.Export;
            this.butchuyen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butchuyen.Location = new System.Drawing.Point(813, 506);
            this.butchuyen.Name = "butchuyen";
            this.butchuyen.Size = new System.Drawing.Size(70, 25);
            this.butchuyen.TabIndex = 137;
            this.butchuyen.Text = "     &Chuyển";
            this.butchuyen.Click += new System.EventHandler(this.butchuyen_Click);
            // 
            // frmXLuanchuyenCN
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(891, 572);
            this.Controls.Add(this.butchuyen);
            this.Controls.Add(this.cbChinhanh);
            this.Controls.Add(this.cmbxuat);
            this.Controls.Add(this.chkLosx);
            this.Controls.Add(this.txtvat);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblTonkho);
            this.Controls.Add(this.txtsttt);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.slton);
            this.Controls.Add(this.cboSophieu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mavach_sttt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkGianovat);
            this.Controls.Add(this.chkgiaban);
            this.Controls.Add(this.chkXem);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.chkSophieu);
            this.Controls.Add(this.find);
            this.Controls.Add(this.cmbSophieu);
            this.Controls.Add(this.sophieu);
            this.Controls.Add(this.ngaysp);
            this.Controls.Add(this.lydo);
            this.Controls.Add(this.khon);
            this.Controls.Add(this.khox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nhomcc);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.giaban);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.tenbd);
            this.Controls.Add(this.tenhc);
            this.Controls.Add(this.lTenhc);
            this.Controls.Add(this.losx);
            this.Controls.Add(this.handung);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dang);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butXoa);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.soluong);
            this.Controls.Add(this.sotien);
            this.Controls.Add(this.dongia);
            this.Controls.Add(this.mabd);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.ldvt);
            this.Controls.Add(this.lTen);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.listDMBD);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.sttt);
            this.Controls.Add(this.stt);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.label11);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmXLuanchuyenCN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu xuất luân chuyển cho chi nhánh";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmXLuanchuyenCN_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmXLuanchuyenCN_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private void frmXLuanchuyenCN_Load(object sender, System.EventArgs e)
		{
           //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            f_load_option();
            if (d.i_Chinhanh_hientai_Trungtam > 0)
            {
                this.Text = "Lập phiếu xuất cho chi nhánh";
            }
            else
            {
                this.Text = "Lập phiếu xuất kho trả hàng về công ty";
                //cbChinhanh.Enabled = false;
            }
            user = d.user; xxx = user + s_mmyy;
			dssp.ReadXml("..\\..\\..\\xml\\d_sophieukhac.xml");
			bSophieu=dssp.Tables[0].Rows[0]["sophieu"].ToString()=="1";
			chkSophieu.Checked=bSophieu;
            chkXem.Checked = d.bPreview;
            bSophieu_kho = d.bSophieu_theokho(i_nhom);
			b701424=m.Mabv_so==701424;
            l_duyet = 0;
			bLockytu=d.bLockytu_traiphai(i_nhom);
			format_soluong=d.format_soluong(i_nhom);
			format_sotien=d.format_sotien(i_nhom);
			format_dongia=d.format_dongia(i_nhom);
			bKhoaso=d.bKhoaso(i_nhom,s_mmyy);
			bNhom_nx=d.bNhom_nhapxuat(i_nhom);
            bSophieu_kho = d.bSophieu_theokho(i_nhom);
			i_songay=d.Ngaylv_Ngayht;
			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			if (d.bQuanlynguon(i_nhom))
				manguon.DataSource=d.get_data("select * from "+user+".d_dmnguon where nhom="+i_nhom+" order by stt").Tables[0];
			else
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where id=0 or nhom=" + i_nhom + " order by stt").Tables[0];

			nhomcc.DisplayMember="TEN";
			nhomcc.ValueMember="ID";
			if (d.bQuanlynhomcc(i_nhom))
                nhomcc.DataSource = d.get_data("select * from " + user + ".d_dmnx where nhom=" + i_nhom + " order by stt").Tables[0];
			else
                nhomcc.DataSource = d.get_data("select * from " + user + ".d_dmnx where id=0 or nhom=" + i_nhom + " order by stt").Tables[0];

			khox.DisplayMember="TEN";
			khox.ValueMember="ID";
            sql = "select * from " + user + ".d_dmkho where nhom=" + i_nhom;
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
            if (d.bQuanly_Theo_Chinhanh)
            {
                sql += " and chinhanh="+d.i_Chinhanh_hientai;
            }
			sql+=" order by stt";
            dtkhox = d.get_data(sql).Tables[0];
            khox.DataSource = dtkhox;
            try
            {
                khox.SelectedIndex = 0;
            }
            catch { }
            sql = "select * from " + user + ".d_dmkhac ";
			if (s_loaikhac!="") sql+=" where id in ("+s_loaikhac.Substring(0,s_loaikhac.Length-1)+")";
			else sql+=" where nhom=0 or nhom="+i_nhom;
			sql+=" order by stt";
			khon.DisplayMember="TEN";
			khon.ValueMember="ID";
			khon.DataSource=d.get_data(sql).Tables[0];

			listDMBD.DisplayMember="TEN";
			listDMBD.ValueMember="STT";

			load_dm();

            sql = "select distinct a.id,a.sophieu,to_char(a.ngay,'dd/mm/yyyy') as ngay,a.khox,a.khon,a.lydo,a.idchinhanh,a.id_kehoachdathang ";
            sql+=" from " + xxx + ".d_xuatll a inner join "+xxx+".d_xuatct b on a.id=b.id where a.loai='" + s_loai + "' and a.nhom=" + i_nhom;// +" and idduyet=0";
			if (!bAdmin) sql+=" and a.userid="+i_userid;
            if (s_makho != "") sql += " and a.khox in (" + s_makho.Substring(0, s_makho.Length - 1) + ")";
            if (b_duyetTheoDutruKhoCuaChiNhanh) sql += " and a.idduyet>0 and a.idchinhanh>0";
            else sql += " and a.idduyet=0";
            sql += " and a.idchinhanh is not null ";
            sql += " order by a.id";
            dtll = d.get_data(sql).Tables[0];
			cmbSophieu.DataSource=dtll;
            cmbSophieu.DisplayMember = "SOPHIEU";
            cmbSophieu.ValueMember = "ID";
            l_id = (cmbSophieu.SelectedIndex != -1) ? decimal.Parse(cmbSophieu.SelectedValue.ToString()) : 0;
			load_head();
            if (i_IDCN_Nhan > 0) s_DBLink_CNNhan = d.getDBLink(i_IDCN_Nhan);
            if (s_DBLink_CNNhan.Trim().Trim('@') != "") s_DBLink_CNNhan = "@" + s_DBLink_CNNhan.Trim().Trim('@');
            else s_DBLink_CNNhan = "";
            //
            sql = " select * from " + user + ".dmchinhanh where id>0 and id<>"+d.i_Chinhanh_hientai;
            if (i_IDCN_Nhan > 0) sql += " and id=" + i_IDCN_Nhan;
            sql+=" order by ten";
            dschinhanh = d.get_data(sql);
            cbChinhanh.DisplayMember = "ten";
            cbChinhanh.ValueMember = "id";
            cbChinhanh.DataSource = dschinhanh.Tables[0];
            if (cbChinhanh.Items.Count == 1)
            {
                cbChinhanh.SelectedIndex = 0;
                cbChinhanh_SelectedIndexChanged(null, null);
            }
			AddGridTableStyle();
			dsxoa.ReadXml("..\\..\\..\\xml\\d_xuatct.xml");
            //Hien: load cac phieu ke hoach dat hang
            cboSophieu.DisplayMember = "phieu";
            cboSophieu.ValueMember = "id";
            load_sophieukehoach();
            ena_object(false);
            create_table();
            cmbxuat.SelectedIndex = 0;
            AddGridTableStyle1();
            //end hien
		}

        private void create_table()
        {
            try
            {
                dtct_mavach.Columns.Add("stt", typeof(int)).AutoIncrement = true;
                dtct_mavach.Columns.Add("mabd", typeof(decimal)).DefaultValue = 0;
                dtct_mavach.Columns.Add("ma", typeof(string));
                dtct_mavach.Columns.Add("ten", typeof(string));
                dtct_mavach.Columns.Add("tenhc", typeof(string));
                dtct_mavach.Columns.Add("dang", typeof(string));
                dtct_mavach.Columns.Add("tennguon", typeof(string));
                dtct_mavach.Columns.Add("tennhomcc", typeof(string));
                dtct_mavach.Columns.Add("handung", typeof(string));
                dtct_mavach.Columns.Add("losx", typeof(string));
                dtct_mavach.Columns.Add("soluong", typeof(decimal)).DefaultValue = 0;
                dtct_mavach.Columns.Add("dongia", typeof(decimal)).DefaultValue = 0;
                dtct_mavach.Columns.Add("sotien", typeof(decimal)).DefaultValue = 0;
                dtct_mavach.Columns.Add("giaban", typeof(decimal)).DefaultValue = 0;
                dtct_mavach.Columns.Add("manguon", typeof(string)).DefaultValue = "0";
                dtct_mavach.Columns.Add("nhomcc", typeof(decimal)).DefaultValue = 0;
                dtct_mavach.Columns.Add("giamua", typeof(decimal)).DefaultValue = 0;
                dtct_mavach.Columns.Add("tennuoc", typeof(string));
                dtct_mavach.Columns.Add("makho", typeof(int)).DefaultValue = 0;
                dtct_mavach.Columns.Add("sothe", typeof(string)).DefaultValue = "";
                dtct_mavach.Columns.Add("mabs", typeof(string)).DefaultValue = "";
                dtct_mavach.Columns.Add("tenbs", typeof(string)).DefaultValue = "";
                dtct_mavach.Columns.Add("hotenbn", typeof(string)).DefaultValue = "";
                dtct_mavach.Columns.Add("slton", typeof(decimal)).DefaultValue = 0;
                dtct_mavach.Columns.Add("sttt", typeof(decimal)).DefaultValue = 0;
                dtct_mavach.Columns.Add("mavach", typeof(decimal)).DefaultValue = 0;
                dtct_mavach.Columns.Add("vat", typeof(int)).DefaultValue = 0;
                //
                dtct_mavach.Columns.Add("soluongmoi", typeof(int)).DefaultValue = 0;
                dtct_mavach.Columns.Add("gianovat", typeof(decimal)).DefaultValue = 0;
                dtct_mavach.Columns.Add("sotien_vat", typeof(decimal)).DefaultValue = 0;
            }
            catch { }
            dataGrid2.DataSource = dtct_mavach;
            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid2.DataSource];
            DataView dv = (DataView)cm.List;
            dv.AllowDelete = false;
            dv.AllowNew = false;
        }

        private void f_load_option()
        {
            bQuanly_xuatban_theomavach = d.bQuanly_xuatban_theomavach(i_nhom);
            label4.Visible = mavach_sttt.Visible = bQuanly_xuatban_theomavach;
            chkLosx.Checked = d.Thongso("chkLosx_xccn") == "1";
            
        }
		private void load_grid()
		{
            try
            {
                string str = "d_xuatct";
                if (chkLosx.Checked) str = "d_xuat_mavachct";
                if (khox.SelectedIndex >= 0)
                {
                    sql = "select a.stt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,nullif(b.tenhc,' ') as tenhc,b.dang,";
                    sql+="c.ten as tennguon,d.ten as tennhomcc,t.handung,t.losx,a.soluong,(case when b.vtyt=1 then t.giamua else t.gianovat end) as dongia,(case when b.vtyt=1 then a.soluong*t.giamua else a.soluong*t.gianovat end) as sotien,t.giaban,";
                    sql+="t.manguon,t.nhomcc,a.sttt,t.giamua,a.mabd,e.ten as tennuoc,t.sothe,a.mabs,'' as tenbs,a.hotenbn, " +
                        (khox.SelectedIndex < 0 ? "0" : khox.SelectedValue.ToString()) + " as makho,t.mavach,a.soluong as soluongmoi,b.vat, t.gianovat, t.giamua*a.soluong as sotien_vat ";
                    sql += " from " + xxx + "."+str+" a," + user + ".d_dmbd b," + user + ".d_dmnguon c," + user + ".d_dmnx d," + user + ".d_dmnuoc e," + xxx + ".d_theodoi t ";
                    sql+=" where a.sttt=t.id and a.mabd=b.id and t.manguon=c.id and t.nhomcc=d.id(+) and b.manuoc=e.id and a.id=" + l_id + " order by a.stt";
                    dtct = d.get_data(sql).Tables[0];
                    dataGrid1.DataSource = dtct;
                    CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
                    DataView dv = (DataView)cm.List;
                    dv.AllowDelete = false;
                    dv.AllowNew = false;
                }
            }
            catch { }
            tongcong();
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
                i_current_row = i;
				stt.Text=dataGrid1[i,0].ToString();
				mabd.Text=dataGrid1[i,1].ToString();
				tenbd.Text=dataGrid1[i,2].ToString();
				tenhc.Text=dataGrid1[i,3].ToString();
				dang.Text=dataGrid1[i,4].ToString();
				handung.Text=dataGrid1[i,7].ToString();
				losx.Text=dataGrid1[i,8].ToString();
				d_soluong=(dataGrid1[i,9].ToString()!="")?decimal.Parse(dataGrid1[i,9].ToString()):0;
				d_dongia=(dataGrid1[i,10].ToString()!="")?decimal.Parse(dataGrid1[i,10].ToString()):0;
				d_sotien=(dataGrid1[i,11].ToString()!="")?decimal.Parse(dataGrid1[i,11].ToString()):0;
				d_giaban=(dataGrid1[i,12].ToString()!="")?decimal.Parse(dataGrid1[i,12].ToString()):0;
				soluong.Text=d_soluong.ToString(format_soluong);
				dongia.Text=d_dongia.ToString(format_dongia);
				sotien.Text=d_sotien.ToString(format_sotien);
				giaban.Text=d_giaban.ToString("#,###,###,##0");
                try
                {
                    manguon.SelectedValue = dataGrid1[i, 14].ToString();
                    nhomcc.SelectedValue = dataGrid1[i, 15].ToString();
                }
                catch { }
                sttt.Text = dataGrid1[i, 16].ToString();
                txtid.Text = dataGrid1[i, 17].ToString();
                if (bQuanly_xuatban_theomavach) mavach_sttt.Text = dataGrid1[i, 18].ToString();
                d_soluongcu = (bNew) ? 0 : d_soluong;
                if (butLuu.Enabled)
                {
                    tenbd.Enabled = sttt.Text == "0" || sttt.Text == "0.0";
                    tenbd.Enabled = false;
                    if (d.bNhapmaso) mabd.Enabled = tenbd.Enabled;
                    mavach_sttt.Enabled = soluong.Enabled = tenbd.Enabled;
                }
			}
            catch { emp_detail(); }
		}
        private void ref_text1()
        {
            try
            {
                int i = dataGrid2.CurrentCell.RowNumber;
                i_current_row = i;
                stt.Text = dataGrid2[i, 0].ToString();
                mabd.Text = dataGrid2[i, 1].ToString();
                tenbd.Text = dataGrid2[i, 2].ToString();
                tenhc.Text = dataGrid2[i, 3].ToString();
                dang.Text = dataGrid2[i, 4].ToString();
                handung.Text = dataGrid2[i, 7].ToString();
                losx.Text = dataGrid2[i, 8].ToString();
                d_soluong = (dataGrid2[i, 9].ToString() != "") ? decimal.Parse(dataGrid2[i, 9].ToString()) : 0;
                d_dongia = (dataGrid2[i, 10].ToString() != "") ? decimal.Parse(dataGrid2[i, 10].ToString()) : 0;
                d_sotien = (dataGrid2[i, 11].ToString() != "") ? decimal.Parse(dataGrid2[i, 11].ToString()) : 0;
                d_giaban = (dataGrid2[i, 12].ToString() != "") ? decimal.Parse(dataGrid2[i, 12].ToString()) : 0;
                soluong.Text = d_soluong.ToString(format_soluong);
                dongia.Text = d_dongia.ToString(format_dongia);
                sotien.Text = d_sotien.ToString(format_sotien);
                giaban.Text = d_giaban.ToString("#,###,###,##0");
                try
                {
                    manguon.SelectedValue = dataGrid2[i, 14].ToString();
                    nhomcc.SelectedValue = dataGrid2[i, 15].ToString();
                }
                catch { }
                sttt.Text = dataGrid2[i, 16].ToString();
                if (bQuanly_xuatban_theomavach)
                {
                    mavach_sttt.Text = dataGrid2[i, 18].ToString();
                    txtsttt.Text = dataGrid2[i, 16].ToString();
                }
                d_soluongcu = (bNew) ? 0 : d_soluong;
                if (butLuu.Enabled)
                {
                    tenbd.Enabled = sttt.Text == "0" || sttt.Text == "0.0";
                    tenbd.Enabled = false;
                    if (d.bNhapmaso) mabd.Enabled = tenbd.Enabled;
                    mavach_sttt.Enabled = soluong.Enabled = tenbd.Enabled;
                }
            }
            catch { emp_detail(); }
        }


		private void AddGridTableStyle()
		{
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
			ts.RowHeaderWidth=10;
						
			DataGridTextBoxColumn TextCol=new DataGridTextBoxColumn();//0
			TextCol.MappingName = "stt";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();//1
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã số";
			TextCol.Width = 50;
            TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();//2
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên";
			TextCol.Width = (d.bHoatchat || d.bQuanlyhandung(i_nhom) || d.bQuanlylosx(i_nhom) || d.bQuanlynguon(i_nhom) || d.bQuanlynhomcc(i_nhom) || bGiaban)?200:360;
			ts.GridColumnStyles.Add(TextCol);
            TextCol.ReadOnly = true;
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();//3
			TextCol.MappingName = "tenhc";
			TextCol.HeaderText = "Hoạt chất";
            TextCol.ReadOnly = true;
			TextCol.Width = (d.bHoatchat)?200:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();//4
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 50;
            TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();//5
			TextCol.MappingName = "tennguon";
			TextCol.HeaderText = "Nguồn";
            TextCol.ReadOnly = true;
			TextCol.Width = (d.bQuanlynguon(i_nhom))?80:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();//6
			TextCol.MappingName = "tennhomcc";
            TextCol.HeaderText = "Nhà cung cấp";
            TextCol.ReadOnly = true;
			TextCol.Width = (d.bQuanlynhomcc(i_nhom))?150:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();//7
			TextCol.MappingName = "handung";
			TextCol.HeaderText = "Date";
            TextCol.ReadOnly = true;
			TextCol.Width = (d.bQuanlyhandung(i_nhom))?30:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();//8
			TextCol.MappingName = "losx";
			TextCol.HeaderText = "Lô SX";
			TextCol.Width = (d.bQuanlylosx(i_nhom))?50:0;
			ts.GridColumnStyles.Add(TextCol);
            TextCol.ReadOnly = true;
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();//9
			TextCol.MappingName = "soluong";
			TextCol.HeaderText = "Số lượng";
			TextCol.Width = 80;
			TextCol.Format=format_soluong;
			TextCol.Alignment=HorizontalAlignment.Right;
            TextCol.TextBox.TextChanged += new EventHandler(text_TextboxChang);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();//10
			TextCol.MappingName = "dongia";
			TextCol.HeaderText = "giá trước VAT";
            TextCol.ReadOnly = true;
			TextCol.Width = 100;
			TextCol.Format=format_dongia;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();//11
			TextCol.MappingName = "sotien";
			TextCol.HeaderText = "Số tiền";
			TextCol.Width = 100;
            TextCol.ReadOnly = true;
			TextCol.Format=format_sotien;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//10
            TextCol.MappingName = "giamua";
            TextCol.HeaderText = "giá Sau VAT";
            TextCol.ReadOnly = true;
            TextCol.Width = 100;
            TextCol.Format = format_dongia;
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//11
            TextCol.MappingName = "sotien_vat";
            TextCol.HeaderText = "Số tiền";
            TextCol.Width = 100;
            TextCol.ReadOnly = true;
            TextCol.Format = format_sotien;
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();//12
			TextCol.MappingName = "giaban";
			TextCol.HeaderText = (bGiaban)?"Giá bán":"";
			TextCol.Width = (bGiaban)?100:0;
			TextCol.Format="###,###,###,##0";
            TextCol.ReadOnly = true;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//13
            TextCol.MappingName = "slton";
            TextCol.HeaderText = "Tồn kho";
            TextCol.Width = 80;
            TextCol.Format = "###,###,###,##0";
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();//14
			TextCol.MappingName = "manguon";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
            TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();//15
			TextCol.MappingName = "nhomcc";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
            TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();//16
			TextCol.MappingName = "sttt";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
            TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//17
            TextCol.MappingName = "mabd";
            TextCol.HeaderText = "";
            TextCol.ReadOnly = true;
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//18
            TextCol.MappingName = "mavach";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}
        private void AddGridTableStyle1()
        {
            DataGridTableStyle ts1 = new DataGridTableStyle();
            ts1.MappingName = dtct_mavach.TableName;
            ts1.AlternatingBackColor = Color.Beige;
            ts1.BackColor = Color.GhostWhite;
            ts1.ForeColor = Color.MidnightBlue;
            ts1.GridLineColor = Color.RoyalBlue;
            ts1.HeaderBackColor = Color.MidnightBlue;
            ts1.HeaderForeColor = Color.Lavender;
            ts1.SelectionBackColor = Color.Teal;
            ts1.SelectionForeColor = Color.PaleGreen;
            ts1.ReadOnly = false;
            ts1.RowHeaderWidth = 10;

            DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();//0
            TextCol.MappingName = "stt";
            TextCol.HeaderText = "STT";
            TextCol.Width = 50;
            ts1.GridColumnStyles.Add(TextCol);
            //dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//1
            TextCol.MappingName = "ma";
            TextCol.HeaderText = "Mã số";
            TextCol.Width = 50;
            TextCol.ReadOnly = true;
            ts1.GridColumnStyles.Add(TextCol);
            //dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//2
            TextCol.MappingName = "ten";
            TextCol.HeaderText = "Tên";
            TextCol.Width = (d.bHoatchat || d.bQuanlyhandung(i_nhom) || d.bQuanlylosx(i_nhom) || d.bQuanlynguon(i_nhom) || d.bQuanlynhomcc(i_nhom) || bGiaban) ? 200 : 360;
            ts1.GridColumnStyles.Add(TextCol);
            TextCol.ReadOnly = true;
            //dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//3
            TextCol.MappingName = "tenhc";
            TextCol.HeaderText = "Hoạt chất";
            TextCol.ReadOnly = true;
            TextCol.Width = (d.bHoatchat) ? 200 : 0;
            ts1.GridColumnStyles.Add(TextCol);
            //dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//4
            TextCol.MappingName = "dang";
            TextCol.HeaderText = "ĐVT";
            TextCol.Width = 50;
            TextCol.ReadOnly = true;
            ts1.GridColumnStyles.Add(TextCol);
            //dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//5
            TextCol.MappingName = "tennguon";
            TextCol.HeaderText = "Nguồn";
            TextCol.ReadOnly = true;
            TextCol.Width = (d.bQuanlynguon(i_nhom)) ? 80 : 0;
            ts1.GridColumnStyles.Add(TextCol);
            //dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//6
            TextCol.MappingName = "tennhomcc";
            TextCol.HeaderText = "Nhà cung cấp";
            TextCol.ReadOnly = true;
            TextCol.Width = (d.bQuanlynhomcc(i_nhom)) ? 150 : 0;
            ts1.GridColumnStyles.Add(TextCol);
            //dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//7
            TextCol.MappingName = "handung";
            TextCol.HeaderText = "Date";
            TextCol.ReadOnly = true;
            TextCol.Width = (d.bQuanlyhandung(i_nhom)) ? 30 : 0;
            ts1.GridColumnStyles.Add(TextCol);
            //dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//8
            TextCol.MappingName = "losx";
            TextCol.HeaderText = "Lô SX";
            TextCol.Width = (d.bQuanlylosx(i_nhom)) ? 50 : 0;
            ts1.GridColumnStyles.Add(TextCol);
            TextCol.ReadOnly = true;
            //dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//9
            TextCol.MappingName = "soluong";
            TextCol.HeaderText = "Số lượng";
            TextCol.Width = 80;
            TextCol.Format = format_soluong;
            TextCol.Alignment = HorizontalAlignment.Right;
            TextCol.TextBox.TextChanged += new EventHandler(text_TextboxChang);
            ts1.GridColumnStyles.Add(TextCol);
//            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//10
            TextCol.MappingName = "dongia";
            TextCol.HeaderText = "Đơn giá";
            TextCol.ReadOnly = true;
            TextCol.Width = 100;
            TextCol.Format = format_dongia;
            TextCol.Alignment = HorizontalAlignment.Right;
            ts1.GridColumnStyles.Add(TextCol);
            //dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//11
            TextCol.MappingName = "sotien";
            TextCol.HeaderText = "Số tiền";
            TextCol.Width = 100;
            TextCol.ReadOnly = true;
            TextCol.Format = format_sotien;
            TextCol.Alignment = HorizontalAlignment.Right;
            ts1.GridColumnStyles.Add(TextCol);
            //dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//12
            TextCol.MappingName = "giaban";
            TextCol.HeaderText = (bGiaban) ? "Giá bán" : "";
            TextCol.Width = (bGiaban) ? 100 : 0;
            TextCol.Format = "###,###,###,##0";
            TextCol.ReadOnly = true;
            TextCol.Alignment = HorizontalAlignment.Right;
            ts1.GridColumnStyles.Add(TextCol);
            //dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//13
            TextCol.MappingName = "slton";
            TextCol.HeaderText = "Tồn kho";
            TextCol.Width = 80;
            TextCol.Format = "###,###,###,##0";
            TextCol.ReadOnly = true;
            ts1.GridColumnStyles.Add(TextCol);
//            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//14
            TextCol.MappingName = "manguon";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            ts1.GridColumnStyles.Add(TextCol);
            //dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//15
            TextCol.MappingName = "nhomcc";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            ts1.GridColumnStyles.Add(TextCol);
            //dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//16
            TextCol.MappingName = "sttt";
            TextCol.HeaderText = "sttt";
            TextCol.Width = 80;
            TextCol.ReadOnly = true;
            ts1.GridColumnStyles.Add(TextCol);
//            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//17
            TextCol.MappingName = "mabd";
            TextCol.HeaderText = "";
            TextCol.ReadOnly = true;
            TextCol.Width = 0;
            ts1.GridColumnStyles.Add(TextCol);
            //dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//18
            TextCol.MappingName = "mavach";
            TextCol.HeaderText = "Mã vạch";
            TextCol.Width = 80;
            TextCol.ReadOnly = true;
            ts1.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts1);
        }
        private void text_TextboxChang(object sender, System.EventArgs e)
        {
            System.Windows.Forms.TextBox text=(System.Windows.Forms.TextBox)sender;
            text.Refresh();
            if (ActiveControl == text)
            {
                try
                {
                    decimal soluong = decimal.Parse(text.Text.Trim() == "" ? "0" : text.Text.Trim());
                    decimal dongia = decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 10].ToString());
                    dataGrid1[dataGrid1.CurrentCell.RowNumber, 11] = soluong * dongia;
                }
                catch { }
            }
        }
		private void sophieu_Validated(object sender, System.EventArgs e)
		{
			if (l_id!=0) return;
			try
			{
				r=d.getrowbyid(dtll,"sophieu='"+sophieu.Text+"'");
				if (r!=null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Số phiếu đã nhập !"),d.Msg);
					sophieu.Focus();
				}
			}
			catch{}
		}

		private void cmbSophieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) butMoi.Focus();
		}

		private void cmbSophieu_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (this.ActiveControl == cmbSophieu || sender == null) 
			{
				try
				{
					l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
				}
				catch{l_id=0;}
				load_head();
                try
                {
                    string s_datalink = d.getDBLink(cbChinhanh.SelectedIndex != -1 ? int.Parse(cbChinhanh.SelectedValue.ToString()) : 0);
                    string sql = "select done from " + user + ".d_chonhapll@" + s_datalink + " where id=" + l_id + "";
                    DataTable dt = d.get_data(sql).Tables[0];
                    if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString() == "1")
                    {
                        butchuyen.ForeColor = Color.Red;
                        butchuyen.FlatStyle = FlatStyle.Flat;
                    }
                    else if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString() == "0")
                    {
                        butchuyen.ForeColor = Color.Blue;
                        butchuyen.FlatStyle = FlatStyle.Flat;
                    }
                    else
                    {
                        butchuyen.ForeColor = Color.Black;
                        butchuyen.FlatStyle = FlatStyle.Standard;
                    }
                }
                catch { }
			}
		}

		private void load_head()
		{
			try
			{
				r=d.getrowbyid(dtll,"id="+l_id);
				if (r!=null)
				{
					sophieu.Text=r["sophieu"].ToString();
					ngaysp.Text=r["ngay"].ToString();
					lydo.Text=r["lydo"].ToString();
					khox.SelectedValue=r["khox"].ToString();
					khon.SelectedValue=r["khon"].ToString();
					s_ngaysp=ngaysp.Text;
                    l_id_kehoachdathang = r["id_kehoachdathang"].ToString();
                    try
                    {
                        cbChinhanh.SelectedValue = r["idchinhanh"].ToString();
                    }
                    catch { }
                    //int i_vtyt = i_kho_vtyt(int.Parse(khox.SelectedValue.ToString()));
                    //cmbxuat.SelectedIndex = i_vtyt;
				}
			}
			catch{l_id=0;}
			load_grid();
			ref_text();
		}
		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void Filter_dmbd(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDMBD.DataSource];
				DataView dv=(DataView)cm.List;
				if (bLockytu) sql="(soluong>0) and (ten like '"+ten.Trim()+"%'"+" or tenhc like '"+ten.Trim()+"%')";
				else sql="(soluong>0) and (ten like '%"+ten.Trim()+"%'"+" or tenhc like '%"+ten.Trim()+"%')";
                //if (cmbxuat.SelectedIndex >= 0) sql += " and vtyt=" + cmbxuat.SelectedIndex;
				dv.RowFilter=sql;
			}
			catch{}
		}

		private void tenbd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDMBD.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listDMBD.Visible) listDMBD.Focus();
				else SendKeys.Send("{Tab}");
			}
		}

		private void tenbd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbd)
			{
				if (butMoi.Enabled) return;
				Filter_dmbd(tenbd.Text);
				listDMBD.Tonkhoct(tenbd,mabd,soluong,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lTenhc.Width+tenhc.Width-20,mabd.Height+5);
			}
		}

		private void tenbd_Validated(object sender, System.EventArgs e)
		{
			if(!listDMBD.Focused) listDMBD.Hide();
		}

		private void ena_object(bool ena)
		{
			find.Enabled=!ena;
			sophieu.Visible=ena;
			cmbSophieu.Visible=!ena;
			if (!bSophieu) sophieu.Enabled=ena;
			ngaysp.Enabled=ena;
			lydo.Enabled=ena;
			khox.Enabled=ena;
			khon.Enabled=ena;
            //if (d.bNhapmaso) mabd.Enabled = ena;
            mabd.Enabled = false;
            tenbd.Enabled = false;
			soluong.Enabled=false;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butThem.Enabled=ena;
			butXoa.Enabled=ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
            cmbxuat.Enabled = ena;
			butHuy.Enabled=!ena;
			butIn.Enabled=!ena;
			//butInlinh.Enabled=!ena;
			butKetthuc.Enabled=!ena;
            butchuyen.Enabled = !ena;
            //
			i_old=cmbSophieu.SelectedIndex;
            //
            mavach_sttt.Visible = bQuanly_xuatban_theomavach;
            mavach_sttt.Enabled = (bQuanly_xuatban_theomavach && !bVattu) ? ena : false;

            if (ena) load_dm();
            //else
            //{
            find.Text = "";
                CurrencyManager cm = (CurrencyManager)BindingContext[cmbSophieu.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "";
            //}
                cbChinhanh.Enabled = (bEdit) ? false : ena;
                cboSophieu.Enabled = (bEdit) ? false : ena;
                find.Enabled = (bEdit) ? false : ena;
                cmbxuat.Enabled = ena;// (bEdit) ? false : ena;
                //cboSophieu.Enabled = ena;
          
        }

		private void emp_head()
		{
			l_id=0;
			if (bSophieu) sophieu.Text=d.get_sophieu(s_mmyy,"d_xuatll","sophieu","where idduyet=0 and nhom="+i_nhom+" and loai='"+s_loai+"' and userid="+i_userid);
			else sophieu.Text="";
			ngaysp.Text=s_ngay;
			lydo.Text="";
            //find.Text = "";
            //CurrencyManager cm = (CurrencyManager)BindingContext[cmbSophieu.DataSource];
            //DataView dv = (DataView)cm.List;
            //dv.RowFilter = "";
            try
            {
                khon.SelectedIndex = -1;
                khox.SelectedIndex = 0;
            }
            catch { }
			s_ngaysp=ngaysp.Text;
			dsxoa.Clear();
		}
		
		private void emp_detail()
		{
			sttt.Text="";
			stt.Text="";
			mabd.Text="";
			tenbd.Text="";
			tenhc.Text="";
			dang.Text="";
			soluong.Text="0";
			dongia.Text="0";
			sotien.Text="0";
			handung.Text="";
			losx.Text="";
			giaban.Text="0";
            if (bQuanly_xuatban_theomavach) mavach_sttt.Text = "";
			manguon.SelectedIndex=-1;
			nhomcc.SelectedIndex=-1;
            stt.Text = d.get_stt(dtct.Select("")).ToString(); //d.get_stt(dtct_mavach.Select("")).ToString();
			d_soluongcu=0;
            slton.Clear();
            txtsttt.Clear();
            txtid.Clear();
		}
		private void butMoi_Click(object sender, System.EventArgs e)
		{
			if (bKhoaso)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Số liệu tháng")+" "+s_mmyy.Substring(0,2)+" "+
lan.Change_language_MessageText("năm")+" "+s_mmyy.Substring(2,2)+" "+
lan.Change_language_MessageText("đã khóa !")+"\n"+
lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"),d.Msg);
				return;
			}
			ena_object(true);
			dtct.Clear();
            dtct_mavach.Clear();
			dtsave.Clear();
			emp_head();
            emp_detail(); cmbxuat.SelectedIndex = 2;
			bNew=true;
			bEdit=true;
            //
            butchuyen.ForeColor = Color.Black;
            butchuyen.FlatStyle = FlatStyle.Standard;
            //
			if (sophieu.Enabled) sophieu.Focus();
            else if (bQuanly_xuatban_theomavach && mavach_sttt.Enabled) mavach_sttt.Focus();
			else if (ngaysp.Enabled) ngaysp.Focus();
			else khox.Focus();
		}
		private void butSua_Click(object sender, System.EventArgs e)
		{
            string s_datalink = d.getDBLink(cbChinhanh.SelectedIndex != -1 ? int.Parse(cbChinhanh.SelectedValue.ToString()) : 0);
            string sql = "select done from " + user + ".d_chonhapll@" + s_datalink + " where id=" + cmbSophieu.SelectedValue.ToString() + "";
            DataTable dt = d.get_data(sql).Tables[0];
            if (dt.Rows.Count > 0 && (dt.Rows[0][0].ToString() == "1" || dt.Rows[0][0].ToString() == "0"))
            {
                MessageBox.Show("Phiếu này đã chuyển, không thể sửa !");
                return;
            }
            //MessageBox.Show(lan.Change_language_MessageText("Rất tiếc, chức năng này chưa xử lý"), d.Msg);
            //return;
			if (cmbSophieu.Items.Count==0) return;
			if (bKhoaso)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Số liệu tháng")+" "+s_mmyy.Substring(0,2)+" "+
lan.Change_language_MessageText("năm")+" "+s_mmyy.Substring(2,2)+" "+
lan.Change_language_MessageText("đã khóa !")+"\n"+
lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"),d.Msg);
				return;
			}
			l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
            bEdit = true;
            bNew = false;
			ena_object(true);
			
			
			khox.Enabled=false;
			dtsave=dtct.Copy();
			dsxoa.Clear();
            if (sophieu.Enabled) sophieu.Focus();
            else if (bQuanly_xuatban_theomavach) mavach_sttt.Focus();
			ref_text1();
            if (bQuanly_xuatban_theomavach) mavach_sttt.Enabled = true;
            //if (d.bNhapmaso) mabd.Enabled = true;
            //tenbd.Enabled = true;
            //soluong.Enabled = true;
		}
		private bool KiemtraHead()
		{
			if (sophieu.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập số phiếu !"),d.Msg);
				sophieu.Focus();
				return false;
			}
			if (ngaysp.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập ngày số phiếu !"),d.Msg);
				ngaysp.Focus();
				return false;
			}
			if (khox.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập kho xuất !"),d.Msg);
				khox.Focus();
				return false;
			}
			if (khon.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập lý do xuất !"),d.Msg);
				khon.Focus();
				return false;
			}
            if (cmbxuat.SelectedIndex == -1)
            {
                MessageBox.Show(lan.Change_language_MessageText("Chọn xuất !"), d.Msg);
                cmbxuat.Focus();
                return false;
            }
			return true;
		}

		private bool KiemtraDetail()
		{
			
			if (mabd.Text=="" && tenbd.Text=="")
			{
				if (mabd.Enabled) mabd.Focus();
				else tenbd.Focus();
				return false;
			}
			if ((mabd.Text=="" && tenbd.Text!="") || (mabd.Text!="" && tenbd.Text==""))
			{
				if (mabd.Text=="" && mabd.Enabled)
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập mã số !"),d.Msg);
					mabd.Focus();
					return false;
				}
				else if (tenbd.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập tên !"),d.Msg);
					tenbd.Focus();
					return false;
				}
			}
            if (bVattu)
            {
                r = d.getrowbyid(dtton, "ma='" + mabd.Text + "'");
                if (r == null)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Mã số không hợp lệ !"), d.Msg);
                    if (mabd.Enabled) mabd.Focus();
                    else tenbd.Focus();
                    return false;
                }
                i_mabd = int.Parse(r["id"].ToString());
            }
			if (soluong.Text=="" || soluong.Text=="0.00" || soluong.Text=="0")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập số lượng !"),d.Msg);
				soluong.Focus();
				return false;
			}
			return true;
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
            try
            {
                bEdit = false;
                cmbSophieu.SelectedIndex = i_old;
                if (cmbSophieu.Items.Count > 0)
                {
                    cmbSophieu_SelectedIndexChanged(null, null);
                    l_id = decimal.Parse(cmbSophieu.SelectedValue.ToString());
                }
                else l_id = 0;
                load_head();
                ena_object(false);
                butMoi.Focus();
                dtct_mavach.Clear();
                dataGrid2.DataSource = dtct_mavach;
            }
            catch 
            {
                ena_object(false);
                butMoi.Focus();
            }
		}

		private void ngaysp_Validated(object sender, System.EventArgs e)
		{
			if (ngaysp.Text=="") return;
			ngaysp.Text=ngaysp.Text.Trim();
			if (!d.bNgay(ngaysp.Text))
			{
				MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ !"),d.Msg);
				ngaysp.Focus();
				return;
			}
			ngaysp.Text=d.Ktngaygio(ngaysp.Text,10);
			if (ngaysp.Text!=s_ngaysp)
			{
				if (!d.ngay(d.StringToDate(ngaysp.Text.Substring(0,10)),DateTime.Now,i_songay))
				{
					MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ so với khai báo hệ thống (")+i_songay.ToString()+")!",d.Msg);
					ngaysp.Focus();
					return;
				}
			}
			SendKeys.Send("{F4}");
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
            if (bQuanly_xuatban_theomavach && !bVattu) mavach_sttt.Enabled = true;
            if (d.bNhapmaso) mabd.Enabled = true;
            tenbd.Enabled = true;
			soluong.Enabled=true;
            if (dtct.Columns.Count <= 0) load_grid();
			//if (!upd_table_them(dtct_mavach,false)) return;
            if (!upd_table_them(dtct, false)) return;
			emp_detail();
            if (bQuanly_xuatban_theomavach && mavach_sttt.Enabled) mavach_sttt.Focus();
			else if (mabd.Enabled) mabd.Focus();
			else tenbd.Focus();
            tongcong();
		}

        private void butXoa_Click(object sender, System.EventArgs e)
        {
            if (!upd_table(dsxoa.Tables[0], true))
                return;
            //
            if (i_index_datagrid == 2)
            {
                DataRow dr = d.getrowbyid(dtct_mavach, "stt=" + int.Parse(stt.Text));
                if (dr != null)
                    d.updrec_tonkho_nguon(dtton, int.Parse(dr["mabd"].ToString()), int.Parse(dr["manguon"].ToString()), decimal.Parse(dr["soluong"].ToString()), "+");
                d.delrec(dtct_mavach, "stt=" + int.Parse(stt.Text));
                dtct_mavach.AcceptChanges();
                if (dtct_mavach.Rows.Count == 0)
                    emp_detail();
                else ref_text1();
            }
            else
                if (i_index_datagrid == 1)
                {
                    DataRow dr=d.getrowbyid(dtct,"stt="+ int.Parse(stt.Text));
                    if (dr != null)
                        d.updrec_tonkho_nguon(dtton, int.Parse(dr["mabd"].ToString()), int.Parse(dr["manguon"].ToString()), decimal.Parse(dr["soluong"].ToString()), "+");
                    d.delrec(dtct, "stt=" + int.Parse(stt.Text));
                    dtct.AcceptChanges();
                    if (dtct.Rows.Count == 0)
                        emp_detail();
                    else ref_text();                    
                }
            
        }

		private bool upd_table(DataTable dt,bool del)
		{
			if (!KiemtraDetail()) return false;
			d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
			d_dongia=(dongia.Text!="")?decimal.Parse(dongia.Text):0;
			d_sotien=(sotien.Text!="")?decimal.Parse(sotien.Text):0;
			d_giaban=(giaban.Text!="")?decimal.Parse(giaban.Text):0;
            decimal d_tonkho = (slton.Text.Trim() != "") ? decimal.Parse(slton.Text) : 0;
                // hien
            //if(bQuanly_xuatban_theomavach) l_sttt = decimal.Parse(mavach_sttt.Text == ""?"0":mavach_sttt.Text);
           // else 
            l_sttt = (sttt.Text.Trim() != "0.0" && sttt.Text.Trim() != "") ? decimal.Parse(sttt.Text) : 0;
            i_mabd = (txtid.Text == "") ? 0 : int.Parse(txtid.Text);
            d.updrec_xuatct(dt, int.Parse(stt.Text), l_sttt, i_mabd, mabd.Text, tenbd.Text, tenhc.Text, dang.Text, (manguon.SelectedIndex == -1) ? "" : manguon.Text, (nhomcc.SelectedIndex == -1) ? "" : nhomcc.Text, handung.Text, losx.Text, d_soluong, d_dongia, d_sotien, d_giaban, d_dongia + d_dongia*d_vat/100, (manguon.SelectedIndex == -1) ? 1 : int.Parse(manguon.SelectedValue.ToString()), (nhomcc.SelectedIndex == -1) ? 0 : int.Parse(nhomcc.SelectedValue.ToString()), "", "", "", "", (del) ? null : dtton, int.Parse(khox.SelectedIndex == -1 ? "0" : khox.SelectedValue.ToString()), i_nhom);
			return true;
		}
        private bool upd_table_them(DataTable dt, bool del)
        {
            if (!KiemtraDetail()) return false;
            d_soluong = (soluong.Text != "") ? decimal.Parse(soluong.Text) : 0;
            d_dongia = (dongia.Text != "") ? decimal.Parse(dongia.Text) : 0;
            d_sotien = (sotien.Text != "") ? decimal.Parse(sotien.Text) : 0;
            d_giaban = (giaban.Text != "") ? decimal.Parse(giaban.Text) : 0;
            decimal d_tonkho = (slton.Text.Trim() != "") ? decimal.Parse(slton.Text) : 0;
            if (bQuanly_xuatban_theomavach) l_sttt = decimal.Parse(txtsttt.Text == "" ? "0" : txtsttt.Text);
            else
                l_sttt = (sttt.Text != "" && sttt.Text != "0.0") ? decimal.Parse(sttt.Text.Trim('.')) : 0;
            if (stt.Text.Trim() == "") stt.Text = d.get_stt(dt.Select("")).ToString();//stt.Text = d.get_stt(dtct_mavach.Select("")).ToString();
            try
            {
                if (!bVattu) i_mabd = int.Parse(txtid.Text);
            }
            catch { }
            d.updrec_xuatct(dt, int.Parse(stt.Text), l_sttt, i_mabd, mabd.Text, tenbd.Text, tenhc.Text, dang.Text, (manguon.SelectedIndex == -1) ? "" : manguon.Text, (nhomcc.SelectedIndex == -1) ? "" : nhomcc.Text, handung.Text, losx.Text, d_soluong, d_dongia, d_sotien, d_giaban, d_dongia + d_dongia*d_vat/100, (manguon.SelectedIndex == -1) ? 0 : int.Parse(manguon.SelectedValue.ToString()), (nhomcc.SelectedIndex == -1) ? 0 : decimal.Parse(nhomcc.SelectedValue.ToString()), "", "", "", "", (del) ? null : dtton, int.Parse(khox.SelectedIndex == -1 ? "0" : khox.SelectedValue.ToString()), i_nhom, d_tonkho, mavach_sttt.Text, txtvat.Text);
            return true;
        }
		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
            i_index_datagrid = 1;
		}

		private void tinh_giatri()
		{
			try
			{
				d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
				d_dongia=(dongia.Text!="")?decimal.Parse(dongia.Text):0;
				d_sotien=Math.Round(d_dongia*d_soluong,3);
				sotien.Text=d_sotien.ToString(format_sotien);
			}
			catch{}
		}

		private void soluong_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (!bEdit) return;
                int i_row = dataGrid1.CurrentCell.RowNumber;
				d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
				soluong.Text=d_soluong.ToString(format_soluong);
                string exp = "ma='"+mabd.Text+"'";
             //   if (bQuanly_xuatban_theomavach) exp += " and stt=" + mavach_sttt.Text;
                if (mabd.Text != "" && tenbd.Text != "" && bVattu)
                {
                    r = d.getrowbyid(dtton, exp);
                    if (r != null)
                    {
                        i_mabd = int.Parse(r["id"].ToString());
                        //if (bQuanly_xuatban_theomavach)
                        //    d_soluongton = d.get_slton_nguon(dtton, int.Parse(khox.SelectedValue.ToString()), i_mabd, int.Parse(manguon.SelectedValue.ToString()), d_soluongcu, decimal.Parse(mavach_sttt.Text));
                        //else
                            d_soluongton = d.get_slton_nguon(dtton, int.Parse(khox.SelectedValue.ToString()), i_mabd, int.Parse(manguon.SelectedValue.ToString()), d_soluongcu);
                        //if (d.bQuanly_Theo_Chinhanh && !bVattu) d_soluongton = decimal.Parse(lblTonkho.Text.Trim() == "" ? "0" : lblTonkho.Text);//decimal.Parse(dtct.Rows[i_row]["slton"].ToString());
                        //else d_soluongton = d.get_slton_nguon(dtton, int.Parse(khox.SelectedValue.ToString()), i_mabd, int.Parse(manguon.SelectedValue.ToString()), d_soluongcu);
                        if (d_soluong > d_soluongton)
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Số lượng xuất lớn hơn số lượng tồn !(") + d_soluongton + ")", d.Msg);
                            soluong.Focus();
                            return;
                        }
                    }
                }
                else
                {
                    r = d.getrowbyid(dtton, exp);
                    if (r != null)
                    {
                        i_mabd = int.Parse(r["id"].ToString());
                        //if (d.bQuanly_Theo_Chinhanh && !bVattu) d_soluongton = decimal.Parse(lblTonkho.Text.Trim() == "" ? "0" : lblTonkho.Text);//decimal.Parse(dtct.Rows[i_row]["slton"].ToString());
                        //else 
                        d_soluongton = d.get_slton_nguon(dtton, int.Parse(khox.SelectedValue.ToString()), i_mabd, int.Parse(manguon.SelectedValue.ToString()), d_soluongcu);
                        if (d_soluong > d_soluongton)
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Số lượng xuất lớn hơn số lượng tồn !(") + d_soluongton + ")", d.Msg);
                            soluong.Focus();
                            return;
                        }
                    }
                }
                txtid.Text = i_mabd.ToString();
			}
			catch{}
			tinh_giatri();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			try
			{
                string _sconn = d.f_get_connection(int.Parse(cbChinhanh.SelectedValue.ToString()));
                string s_datalink = d.getDBLink(cbChinhanh.SelectedIndex != -1 ? int.Parse(cbChinhanh.SelectedValue.ToString()) : 0);
                string sql = "select done from " + user + ".d_chonhapll@" + s_datalink + " where id=" + cmbSophieu.SelectedValue.ToString() + "";
                DataTable dt = d.get_data(sql).Tables[0];
                if (dt.Rows.Count > 0 && (dt.Rows[0][0].ToString() == "1"||dt.Rows[0][0].ToString() == "0"))
                {
                    MessageBox.Show("Phiếu này đã chuyển, không thể hủy !");
                    return;
                }
				if (cmbSophieu.Items.Count==0) return;
				if (bKhoaso)
				{
					MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng")+" "+s_mmyy.Substring(0,2)+" "+lan.Change_language_MessageText("năm")+" "+s_mmyy.Substring(2,2)+" "+lan.Change_language_MessageText("đã khóa !")+"\n"+lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"),d.Msg);
					return;
				}
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy số phiếu này ?"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
                    // xu ly xoa ca xuat ma vach va xuat theo nhap truoc xuat truoc
                    sql = "select a.stt,b.ma,trim(b.ten)||' '||b.hamluong as ten,nullif(b.tenhc,' ') as tenhc,b.dang,";
                    sql += " c.ten as tennguon,d.ten as tennhomcc,f.handung,f.losx,a.soluong,(case when b.vtyt=1 then f.giamua else f.gianovat end) as dongia,(case when b.vtyt=1 then a.soluong*f.giamua else a.soluong*f.gianovat end) as sotien,";
                    sql += "f.giaban,f.giamua,f.manguon,a.sttt,f.nhomcc,a.mabd,e.ten as tennuoc,f.sothe,a.mabs,'' as tenbs,a.hotenbn,0.0 as mavach,b.vat,0.0 as slton ";
                    sql += " from " + xxx + ".d_xuatct a," + user + ".d_dmbd b," + user + ".d_dmnguon c," + user + ".d_dmnx d," + user
                        + ".d_dmnuoc e," + xxx + ".d_theodoi f where a.sttt=f.id and a.mabd=b.id and f.manguon=c.id and f.nhomcc=d.id and b.manuoc=e.id and a.id=" + l_id
                        + " order by a.stt";
                    DataTable dt_nomavach = d.get_data(sql).Tables[0];
                    // xoa xuat theo ma vach
                    DataSet dt_xuatmavach = d.get_data(sql.Replace("d_xuatct", "d_xuat_mavachct"));
                    //foreach (DataRow r1 in dt_xuatmavach.Rows)
                    //{
                    //    d_soluongton = d.get_tonkho(s_mmyy, int.Parse(khon.SelectedValue.ToString()), decimal.Parse(r1["sttt"].ToString()));
                    //    if (d_soluongton - decimal.Parse(r1["soluong"].ToString()) < 0)
                    //    {
                    //        MessageBox.Show(r1["ten"].ToString().Trim() + " " + r1["dang"].ToString().Trim() + "\nĐã xuất không cho phép hủy !", d.Msg);
                    //        return;
                    //    }
                    //}
                    // end 
                    itable = d.tableid(s_mmyy, "d_xuatct");
                    //foreach(DataRow r1 in dtct.Rows)
                    //{
                    //    d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                    //    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".d_xuatct", "id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())));
                    //    d.upd_tonkhoct_xuatct(d.delete,s_mmyy,s_loai,int.Parse(khox.SelectedValue.ToString()),int.Parse(khon.SelectedValue.ToString()),decimal.Parse(r1["sttt"].ToString()),int.Parse(r1["manguon"].ToString()),int.Parse(r1["nhomcc"].ToString()),int.Parse(r1["mabd"].ToString()),r1["handung"].ToString(),r1["losx"].ToString(),decimal.Parse(r1["soluong"].ToString()),decimal.Parse(r1["sotien"].ToString()),decimal.Parse(r1["giaban"].ToString()),decimal.Parse(r1["giamua"].ToString()));
                       
                    //}
                    // Huy xuat khong ma vach
                    foreach (DataRow r1 in dt_nomavach.Rows)
                    {
                        d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                        d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".d_xuatct", "id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())));
                        d.upd_tonkhoct_xuatct_mavach(d.delete, s_mmyy, s_loai, int.Parse(khox.SelectedValue.ToString()), int.Parse(khon.SelectedValue.ToString()), decimal.Parse(r1["sttt"].ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["nhomcc"].ToString()), int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["sotien"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()), false);
                    }
                    // Huy xuat co ma vach
                    if (dt_xuatmavach != null && dt_xuatmavach.Tables.Count > 0)
                    {
                        foreach (DataRow r1 in dt_xuatmavach.Tables[0].Rows)
                        {
                            d.upd_tonkhoct_xuatct_mavach(d.delete, s_mmyy, s_loai, int.Parse(khox.SelectedValue.ToString()), int.Parse(khon.SelectedValue.ToString()), decimal.Parse(r1["sttt"].ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["nhomcc"].ToString()), int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["sotien"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()), true);
                        }
                    }
                    d.execute_data("update " + user + ".d_kehoachdathangct set daxuat=0 where id=" + l_id_kehoachdathang + " and id_chinhanh=" + cbChinhanh.SelectedValue.ToString());
                    //
                    if (s_datalink.Trim().Trim('@') != "") s_datalink = "@" + s_datalink.Trim().Trim('@');
                    else s_datalink = "";
                    d.execute_data("update " + user + s_mmyy + ".d_dutrucapct" + s_datalink + " set slthuc=0 where id=" + l_id_kehoachdathang);
                    d.execute_data("update " + user + s_mmyy + ".d_dutrucapll" + s_datalink + " set done=0 where id=" + l_id_kehoachdathang);
                    //
                    itable = d.tableid(s_mmyy, "d_xuatll");
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".d_xuatll", "id=" + l_id));
                    // xoa cho nhap cua chi nhanh-hien
                    try
                    {
                        string id_chinhanhnhan = d.get_data("select idchinhanh from " + xxx + ".d_xuatll where id=" + l_id).Tables[0].Rows[0][0].ToString();
                        d.execute_data("delete from " + user + ".d_chonhapct@" + d.getDBLink(int.Parse(id_chinhanhnhan)) + " where id=" + l_id);
                        d.execute_data("delete from " + user + ".d_chonhapll@" + d.getDBLink(int.Parse(id_chinhanhnhan)) + " where id=" + l_id);
                    }
                    catch { }
                    d.execute_data("delete from " + xxx + ".d_xuatct where id=" + l_id);
                    d.execute_data("delete from " + xxx + ".d_xuat_mavachct where id=" + l_id);
                    d.execute_data("delete from " + xxx + ".d_xuatll where id=" + l_id);
					d.delrec(dtll,"id="+l_id);
					cmbSophieu.Refresh();
					if (cmbSophieu.Items.Count>0) l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
					else l_id=0;
					load_head();
				}
			}
			catch{}
		}

		private void khox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				load_dm();
                cmbxuat.SelectedIndex = khox.SelectedIndex;
			}
			catch{}
		}

		private void khox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (khox.SelectedIndex==-1) khox.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");	
			}
		}

		private void khon_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (khon.SelectedIndex==-1) khon.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void load_dm()
		{
            if (khox.SelectedIndex >= 0)
            {
                //if (bQuanly_xuatban_theomavach)
                    //dtton = d.get_tonkhoth_dotnhap(s_mmyy, (khox.SelectedIndex <0 ? "0":khox.SelectedValue.ToString()) , "", "", bTrutonao,false);
                //else 
                dtton = d.get_tonkhoth(s_mmyy, int.Parse(khox.SelectedValue.ToString()));
                listDMBD.DataSource = dtton;
            }
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
            string s_idkehoach, s_sophieu;
            if (!KiemtraHead()) return;
            bEdit = false;
            upd_table(dtct, false);
            dtct.AcceptChanges();
            if (dtct.Rows.Count <= 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Đề nghị nhập mặt hàng xuất."));
                return;
            }
            string _sconn = d.f_get_connection(int.Parse(cbChinhanh.SelectedValue.ToString()));
            //dtct_mavach.AcceptChanges();
            /*
            try
            {
                foreach (DataRow dtr in dtct.Rows)
                {
                    if (decimal.Parse(dtr["soluong"].ToString()) > decimal.Parse(dtr["slton"].ToString()))
                    {
                        MessageBox.Show("Thuốc " + dtr["ten"].ToString() + " số lượng lớn hơn tồn kho hiện tại", d.Msg);
                        return;
                    }
                }
            }
            catch { }
            */
            i_old = (bNew) ? 0 : 1;
            //l_id = (bNew) ? d.get_id_xuat : l_id;
            //l_id = (bNew) ? d.getidyymmddhhmiss_stt_computer : l_id;
            itable = d.tableid(s_mmyy, "d_xuatll");
            if (bNew)
            {
                for (; ; )
                {
                    l_id = d.getidyymmddhhmiss_stt_computer;
                    sql = "select id from " + xxx + ".d_xuatll where id=" + l_id;
                    if (d.get_data(sql).Tables[0].Rows.Count <= 0) break;
                }

                d.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
                if (bSophieu)
                {
                    sql = "where idduyet=0 and nhom=" + i_nhom + " and loai='" + s_loai + "' and userid=" + i_userid;
                    if (bSophieu_kho) sql += " and khox=" + int.Parse(khox.SelectedValue.ToString());
                    sophieu.Text = cbChinhanh.SelectedValue.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString().Substring(2, 2).PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + d.get_capid((int)LibMedi.IDThongSo.ID_Sophieuxuat).ToString().PadLeft(6, '0'); // +d.get_sophieu(s_mmyy, "d_xuatll", "sophieu", sql);                    
                    //sophieu.Text = cbChinhanh.SelectedValue.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString().Substring(2, 2).PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + d.get_sophieu(s_mmyy, "d_xuatll", "sophieu", sql);
                }
            }
            else
            {
                d.upd_eve_tables(s_mmyy, itable, i_userid, "upd");
                d.upd_eve_upd_del(s_mmyy, itable, i_userid, "upd", l_id.ToString() + "^" + i_nhom.ToString() + "^" + sophieu.Text + "^" + ngaysp.Text + "^" + s_loai + "^" + khox.SelectedValue.ToString() + "^" + khon.SelectedValue.ToString() + "^" + lydo.Text + "^" + i_userid.ToString());
            }
            if (!d.upd_xuatll(s_mmyy, l_id, i_nhom, sophieu.Text, ngaysp.Text, s_loai, int.Parse(khox.SelectedValue.ToString()), int.Parse(khon.SelectedValue.ToString()), lydo.Text, i_userid,int.Parse(cbChinhanh.SelectedValue.ToString())))//select a.stt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,nullif(b.tenhc,' ') as tenhc,b.dang,i.ten as tennguon,d.ten as tennhomcc,'' as handung,'' as losx,a.slthucte as soluong,round(b.dongia,2) as dongia,round(b.dongia*a.slthucte) as sotien,b.giaban as giaban,f.manguon as manguon,0 as nhomcc,b.dongia as giamua,a.mabd,e.ten as tennuoc,0 as makho,'' as sothe,'' as mabs,'' as tenbs,'' as hotenbn,0 as slton,0 as sttt  from medibv.d_kehoachdathangct a,medibv.d_kehoachdathang f,medibv.d_dmbd b,medibv.d_dmnx d,medibv.d_dmnuoc e,medibv.d_dmnguon i where a.mabd=b.id and b.madv=d.id and b.manuoc=e.id and a.id=f.id and a.id=1108230940093129018 and i.id=f.manguon  and a.mabd in (select mabd from medibv0811.d_tonkhoct where makho=1) and a.id_chinhanh=3 order by a.stt
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin phiếu xuất kho !"), d.Msg);
                return;
            }
            if (b_duyetTheoDutruKhoCuaChiNhanh == false)
            {
                try
                {
                    s_sophieu = cboSophieu.Text;
                    s_idkehoach = cboSophieu.SelectedValue.ToString();
                    d.execute_data("update " + user + s_mmyy + ".d_xuatll set sophieudutru=" + s_sophieu + " where id=" + l_id);
                    d.execute_data("update " + user + s_mmyy + ".d_xuatll set id_kehoachdathang=" + s_idkehoach + " where id=" + l_id);
                }
                catch
                {
                    s_idkehoach = "0";
                    s_sophieu = "0";
                }
            }
            else
            {
                try
                {
                    s_sophieu = cboSophieu.Text;
                    s_idkehoach = cboSophieu.SelectedValue.ToString();
                    d.execute_data("update " + user + s_mmyy + ".d_xuatll set sophieudutru=" + s_sophieu + " where id=" + l_id);
                    d.execute_data("update " + user + s_mmyy + ".d_xuatll set id_kehoachdathang=" + s_idkehoach + ",idduyet=" + s_idkehoach + " where id=" + l_id);
                }
                catch
                {
                    s_idkehoach = "0";
                    s_sophieu = "0";
                }
            }
            itable = d.tableid(s_mmyy, "d_xuatct");
            // sửa phiếu nhập kho
			if (!bNew)
			{
				foreach(DataRow r1 in dsxoa.Tables[0].Rows)
				{
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".d_xuatct", "id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())));
                    d.execute_data("delete from " + xxx + ".d_xuatct where id=" + l_id + " and stt=" + decimal.Parse(r1["stt"].ToString()));
                    d.upd_tonkhoct_xuatct(d.delete, s_mmyy, s_loai, int.Parse(khox.SelectedValue.ToString()), int.Parse(khon.SelectedValue.ToString()), decimal.Parse(r1["sttt"].ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["nhomcc"].ToString()), int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["sotien"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()));
				}
			}
            //hien danh dau da xuat của kế hoạch
            if (b_duyetTheoDutruKhoCuaChiNhanh == false)
            {
                foreach (DataRow row in dtct.Rows)
                {
                    d.execute_data("update " + user + ".d_kehoachdathangct set daxuat=" + row["soluong"].ToString() + " where id=" + s_idkehoach + " and mabd=" + row["mabd"].ToString() + " and stt=" + row["stt"].ToString());
                }
            }
            else
            {
                foreach (DataRow row in dtct.Rows)
                {
                    d.execute_data("update " + user + s_mmyy + ".d_dutrucapct" + s_DBLink_CNNhan + " set slthuc=" + row["soluong"].ToString() + " where id=" + s_idkehoach + " and mabd=" + row["mabd"].ToString());// + " and stt=" + row["stt"].ToString());
                }
                d.execute_data("update " + user + s_mmyy + ".d_dutrucapll" + s_DBLink_CNNhan + " set done=1 where id=" + s_idkehoach);
            }
            //d.execute_data("update " + user + ".d_kehoachdathangct set daxuat=slthucte where id=" + s_idkehoach+ " and id_chinhanh=" + cbChinhanh.SelectedValue.ToString());
            //end hien
            sql = "select a.*,b.ten as tennguon,c.ten as tennhomcc,t.handung,t.losx,t.giamua,t.giaban,t.manguon,t.nhomcc,t.mavach from " + xxx + ".d_tonkhoct a," + user + ".d_dmnguon b," + user + ".d_dmnx c," + xxx + ".d_theodoi t where a.stt=t.id and t.manguon=b.id and t.nhomcc=c.id and a.makho=" + int.Parse(khox.SelectedValue.ToString());
            if (bQuanly_xuatban_theomavach)
            {
                dtct = d.get_xuatct_mavach_lc(dtct, s_mmyy, sql, l_id, s_loai, int.Parse(khox.SelectedValue.ToString()), int.Parse(khon.SelectedValue.ToString()), l_duyet, i_nhom, true);
            }
            else
            {
                dtct = d.get_xuatct(dtct, s_mmyy, sql, l_id, s_loai, int.Parse(khox.SelectedValue.ToString()), int.Parse(khon.SelectedValue.ToString()), 0, i_nhom);
            }
            foreach (DataRow r1 in dtct.Rows)
            {
                //d.execute_data("update " + xxx + ".d_theodoi set sohd='" + sophieu.Text + "',ngay=to_date('" + ngaysp.Text + "','dd/mm/yyyy') where id=" + decimal.Parse(r1["sttt"].ToString()) + " ");
                if (d.get_data("select * from " + xxx + ".d_xuatct where id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())).Tables[0].Rows.Count != 0)
                {
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "upd");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "upd", d.fields(xxx + ".d_xuatct", "id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())));
                }
                else
                {
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
                }
            }

            /////Dong them ngay13/07/2011
            //if (d.upd_chonhapll(s_mmyy, l_id, i_nhom, sophieu.Text, ngaysp.Text.Trim(), "", "LC", 0, ichinhanh, cbChinhanh.SelectedIndex != -1 ? int.Parse(cbChinhanh.SelectedValue.ToString()) : 0, i_userid))
            //{
            //    if (dtct.Rows.Count > 0)
            //    {
            //        string s_datalink = d.getDBLink(cbChinhanh.SelectedIndex != -1 ? int.Parse(cbChinhanh.SelectedValue.ToString()) : 0);
            //        d.execute_data("delete " + user + ".d_chonhapct@" + s_datalink + " where id=" + l_id + "");
            //    }
            //    // foreach (DataRow dr1 in dtct.Rows)// hien comment
            //    foreach (DataRow dr1 in dtct.Rows)
            //    {
            //        if (bQuanly_xuatban_theomavach)
            //        {
            //            if (!d.upd_chonhapct_lc(s_mmyy, l_id, decimal.Parse(dr1["stt"].ToString()), int.Parse(dr1["mabd"].ToString()),
            //            dr1["handung"].ToString(), dr1["losx"].ToString(), int.Parse(dr1["vat"].ToString().Trim() == "" ? "0" : dr1["vat"].ToString()), decimal.Parse(dr1["soluong"].ToString()),//
            //            decimal.Parse(dr1["dongia"].ToString()), decimal.Parse(dr1["sotien"].ToString()), decimal.Parse(dr1["giaban"].ToString()),
            //            decimal.Parse(dr1["giamua"].ToString()), int.Parse(dr1["manguon"].ToString()), int.Parse(dr1["nhomcc"].ToString()),
            //            cbChinhanh.SelectedIndex != -1 ? int.Parse(cbChinhanh.SelectedValue.ToString()) : 0, dr1["mavach"].ToString()))//
            //            {
            //                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin xuống d_chonhapct phiếu xuất luân chuyển chi nhánh !"), d.Msg);
            //                return;
            //            }
            //        }
            //        else
            //        {
            //            if (!d.upd_chonhapct_lc(s_mmyy, l_id, decimal.Parse(dr1["stt"].ToString()), int.Parse(dr1["mabd"].ToString()),
            //                dr1["handung"].ToString(), dr1["losx"].ToString(), 0, decimal.Parse(dr1["soluong"].ToString()),//int.Parse(dr1["vat"].ToString().Trim()=="" ? "0":dr1["vat"].ToString())
            //                decimal.Parse(dr1["dongia"].ToString()), decimal.Parse(dr1["sotien"].ToString()), decimal.Parse(dr1["giaban"].ToString()),
            //                decimal.Parse(dr1["giamua"].ToString()), int.Parse(dr1["manguon"].ToString()), int.Parse(dr1["nhomcc"].ToString()),
            //                cbChinhanh.SelectedIndex != -1 ? int.Parse(cbChinhanh.SelectedValue.ToString()) : 0, "0"))//dr1["mavach"].ToString()
            //            {
            //                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin xuống d_chonhapct phiếu xuất luân chuyển chi nhánh !"), d.Msg);
            //                return;
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin phiếu xuất luân chuyển chi nhánh !"), d.Msg);
            //    return;
            //}
            /////End dong

            //TU:11112011 kiểm tra nếu không lưu được vào bảng chi tiết thì xóa luôn trong bảng tổng hợp
            DataTable dt_xuatct = d.get_data("select id from " + user + s_mmyy + ".d_xuatct where id=" + l_id + "").Tables[0];
            if (dt_xuatct.Rows.Count <= 0) d.execute_data("delete " + user + s_mmyy + ".d_xuatll where id=" + l_id + "");
            //end Tu
            if (dt_xuatct.Rows.Count > 0)
                d.updrec_xuatll(dtll, l_id, sophieu.Text, ngaysp.Text, int.Parse(khox.SelectedValue.ToString()), int.Parse(khon.SelectedValue.ToString()), lydo.Text, int.Parse(cbChinhanh.SelectedValue.ToString()), l_id_kehoachdathang);
			try
			{
				if (i_old==0 && dtll.Rows.Count>0)
                    cmbSophieu.SelectedIndex=dtll.Rows.Count-1;
                //if (!bNew)
                //{
                    cmbSophieu.SelectedValue = l_id.ToString();
                    load_head();
                //}
			}
			catch{}
			ena_object(false);
			butMoi.Focus();
            listDMBD.Hide();
            dtct_mavach.Clear();
            dataGrid2.DataSource = dtct_mavach;
            d.upd_tonkho(i_nhom, s_mmyy);
            if (d.bKhoaso(i_nhom, s_mmyy) == false) d.f_capnhat_tonkhoct(s_mmyy, i_nhom);
            d.upd_tonkho(s_mmyy, i_nhom, 1);
		}

		private void tongcong(DataTable dt)
		{
			d_tongcong=0;
			foreach(DataRow r1 in dt.Rows) d_tongcong+=decimal.Parse(r1["sotien"].ToString());
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
            string str = "d_xuatct";
            if (chkLosx.Checked) str = "d_xuat_mavachct";
			if (dtct.Rows.Count==0) 
                return;
            sql = "select a.stt,a.sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten_hamluong,trim(b.ten) tenbd,b.hamluong,nullif(b.tenhc,' ') as tenhc,b.dang,c.ten as tennguon,";
            sql += "d.ten as tennhomcc,t.handung,t.losx,a.soluong ";
            if(chkgiaban.Checked)
                sql+=" ,t.giamua as dongia,a.soluong*t.giamua as sotien";
            else if(chkGianovat.Checked)
                sql += " ,t.gianovat as dongia,a.soluong*t.gianovat as sotien";
            else
                sql += " ,(case when b.vtyt=1 then t.giamua else t.gianovat end) as dongia,(case when b.vtyt=1 then a.soluong*t.giamua else a.soluong*t.gianovat end) as sotien";
            sql += ",case when b.vtyt=1 then t.giamua else t.gianovat end as gia ";
            sql += ",case when b.vtyt=1 then a.soluong*t.giamua else a.soluong*t.gianovat end as thanhtien ";
            sql += " ,t.giaban,t.giamua,t.manguon,t.nhomcc,";
            sql += " e.ten as tennuoc,t.sothe,a.mabs,'' as tenbs,a.hotenbn,t.gianovat,g.ten tencn,idchinhanh,to_char(f.ngay,'dd/mm/yyyy') ngayxuat,f.sophieu,l.id idnhom,l.ten tennhom,l.nhomin idnhomin,f.lydo ghichu,m.id idlydo,m.ten lydo,f.sophieudutru,b.vtyt ";
            sql += " from " + xxx + "."+str+" a inner join " + user + ".d_dmbd b on a.mabd=b.id inner join " + user + ".d_dmnuoc e on b.manuoc=e.id";
            sql += " inner join " + xxx + ".d_theodoi t on a.sttt=t.id inner join " + xxx + ".d_xuatll f on a.id=f.id left join " + user + ".dmchinhanh g on f.idchinhanh=g.id";
            sql += " inner join " + user + ".d_dmnguon c on t.manguon=c.id inner join " + user + ".d_dmnx d on t.nhomcc=d.id inner join " + user + ".d_dmnhom l on b.manhom=l.id inner join " + user + ".d_dmkhac m on f.khon=m.id ";
            sql += " where a.id= " + l_id;
            sql += " order by a.stt";
            DataSet dstmp = d.get_data(sql);
			tongcong(dstmp.Tables[0]);
            string s_title = "";
            if (d.i_Chinhanh_hientai_Trungtam > 0)
            {
                s_title = "1";
            }
            else
            {
                s_title = "0";
            }
            if (chkXML.Checked)
            {
                if (!System.IO.Directory.Exists("..//..//dataxml")) System.IO.Directory.CreateDirectory("..//..//dataxml");
                dstmp.WriteXml("..//..//dataxml//phieuxuat_chinhanh.xml", XmlWriteMode.WriteSchema);
            }
			string tenfile="d_phieuxuat_chinhanh.rpt";
			if (chkXem.Checked)
			{
				frmReport f=new frmReport(d,dstmp.Tables[0], i_userid,tenfile,cmbSophieu.Text,ngaysp.Text,s_title,d.TenChiNhanhHienTai.ToUpper(),lydo.Text,(int.Parse(khon.SelectedValue.ToString())>3)?khon.Text:"",khox.Text,doiso.doithapphan(d_tongcong.ToString()),khon.Text,s_userid);
				f.ShowDialog();
			}
			else
			{
				ReportDocument oRpt=new ReportDocument();
				oRpt.Load("..\\..\\..\\report\\"+tenfile,OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(dstmp.Tables[0]);
				oRpt.DataDefinition.FormulaFields["soyte"].Text="'"+d.Syte+"'";
				oRpt.DataDefinition.FormulaFields["benhvien"].Text="'"+d.Tenbv+"'";
				oRpt.DataDefinition.FormulaFields["c1"].Text="'"+cmbSophieu.Text+"'";
				oRpt.DataDefinition.FormulaFields["c2"].Text="'"+ngaysp.Text+"'";
                oRpt.DataDefinition.FormulaFields["c3"].Text = "'" + s_title + "'";
				oRpt.DataDefinition.FormulaFields["c4"].Text="";
				oRpt.DataDefinition.FormulaFields["c5"].Text="'"+lydo.Text+"'";
				oRpt.DataDefinition.FormulaFields["c6"].Text="'"+((int.Parse(khon.SelectedValue.ToString())>3)?khon.Text:"")+"'";
				oRpt.DataDefinition.FormulaFields["c7"].Text="'"+khox.Text+"'";
				oRpt.DataDefinition.FormulaFields["c8"].Text="'"+doiso.doithapphan(d_tongcong.ToString())+"'";
				oRpt.DataDefinition.FormulaFields["c9"].Text="'"+khon.Text+"'";
				oRpt.DataDefinition.FormulaFields["c10"].Text="'"+s_userid+"'";
				oRpt.DataDefinition.FormulaFields["giamdoc"].Text="'"+d.Giamdoc(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["phutrach"].Text="'"+d.Phutrach(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["thongke"].Text="'"+d.Thongke(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["ketoan"].Text="'"+d.Ketoan(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["thukho"].Text="'"+d.Thukho(i_nhom)+"'";
				oRpt.PrintOptions.PaperSize=PaperSize.DefaultPaperSize;
				oRpt.PrintOptions.PaperOrientation=PaperOrientation.Portrait;
				if (d.bPrintDialog)
				{
					result=Thongso();
					if (result==DialogResult.OK)
					{
						oRpt.PrintOptions.PrinterName=p.PrinterSettings.PrinterName;
						oRpt.PrintToPrinter(p.PrinterSettings.Copies,false,p.PrinterSettings.FromPage,p.PrinterSettings.ToPage);
					}
				}
				else oRpt.PrintToPrinter(1,false,0,0);
                oRpt.Close(); oRpt.Dispose();
			}
		}

		private DialogResult Thongso()
		{
			p.AllowSomePages = true;
			p.ShowHelp = true;
			p.Document = docToPrint;
			return p.ShowDialog();
		}

		private void mabd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==mabd)
			{
				if (butMoi.Enabled) return;
				Filter_mabd(mabd.Text);
				listDMBD.Tonkhoct(mabd,tenbd,soluong,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lTenhc.Width+tenhc.Width-20,mabd.Height+5);
			}
		}

		private void Filter_mabd(string ma)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDMBD.DataSource];
				DataView dv=(DataView)cm.List;
				if (bLockytu) sql="soluong>0 and ma like '"+ma.Trim()+"%'";
				else sql="soluong>0 and ma like '%"+ma.Trim()+"%'";
                if (cmbxuat.SelectedIndex >= 0) sql += " and vtyt=" + cmbxuat.SelectedIndex;
				dv.RowFilter=sql;
			}
			catch{}
		}

		private void get_items(string stt)
		{
			try
			{
				r=d.getrowbyid(dtton,"soluong>0 and stt="+stt);
				if (r!=null)
				{
					mabd.Text=r["ma"].ToString();
					tenbd.Text=r["ten"].ToString();
					tenhc.Text=r["tenhc"].ToString();
					dang.Text=r["dang"].ToString();
					manguon.SelectedValue=r["manguon"].ToString();
                    if (bQuanly_xuatban_theomavach) mavach_sttt.Text = r["sttt"].ToString();// theo ma vach
					listDMBD.Hide();
					soluong.Focus();
				}
			}
			catch{}		
		}

		private void listDMBD_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				try
				{
					r=d.getrowbyid(dtton,"soluong>0 and stt="+mabd.Text);
					if (r!=null)
					{
                        txtid.Text = r["id"].ToString();
						mabd.Text=r["ma"].ToString();
						tenbd.Text=r["ten"].ToString();
						tenhc.Text=r["tenhc"].ToString();
						dang.Text=r["dang"].ToString();
						manguon.SelectedValue=r["manguon"].ToString();
                        if (bQuanly_xuatban_theomavach) mavach_sttt.Text = r["stt"].ToString();
						listDMBD.Hide();
						soluong.Focus();
                        slton.Text = r["soluong"].ToString();
                        if (r["vtyt"].ToString() == "1") dongia.Text = r["dongia"].ToString();
                        else dongia.Text = r["gianovat"].ToString();
                        giaban.Text = r["giaban"].ToString();
                        d_vat = decimal.Parse(r["vat"].ToString() == "" ? "0" : r["vat"].ToString());
					}
				}
				catch{}		
			}
		}

		private void mabd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDMBD.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				sql="soluong>0 and ma like '"+mabd.Text.Trim()+"%'";
				DataRow [] dr=dtton.Select(sql);
				if (dr.Length==1)
				{
					mabd.Text=dr[0]["stt"].ToString();
					get_items(mabd.Text);
					if(!listDMBD.Focused) listDMBD.Hide();
					soluong.Focus();
				}
				else
				{
					if (listDMBD.Visible)
					{
						listDMBD.Focus();
						SendKeys.Send("{Up}");
					}
					else SendKeys.Send("{Tab}");
				}
			}
		}

		private void find_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==find) RefreshChildren(find.Text);
		}

		private void RefreshChildren(string text)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[cmbSophieu.DataSource];
				DataView dv=(DataView)cm.List;			
				dv.RowFilter="sophieu like '%"+text.Trim()+"%'";
				if(cmbSophieu.SelectedIndex>=0)	l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
				else l_id=0;
				load_head();
			}
			catch(Exception ex){MessageBox.Show(ex.Message);}
		}

		private void find_Enter(object sender, System.EventArgs e)
		{
			find.Text="";
		}

		private void butInlinh_Click(object sender, System.EventArgs e)
		{
			sql="select '"+sophieu.Text+"' as sophieu,3 as stt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,";
			sql+="nullif(b.tenhc,' ') as tenhc,b.dang,c.ten as tennguon,' ' as tennhom,t.handung,t.losx,a.soluong,";
			if(chkgiaban.Checked) sql+="t.giaban as dongia,a.soluong*t.giaban as sotien,";
            else if (chkGianovat.Checked) sql += "t.gianovat as dongia,a.soluong*t.gianovat as sotien,";
            else sql += "(case when b.vtyt=1 then t.giamua else t.gianovat end) as dongia,(case when b.vtyt=1 then a.soluong*t.giamua else a.soluong*t.gianovat end) as sotien,";
            sql+=" t.giaban,t.giamua,t.manguon,b.manhom,d.ten as tenhang,e.ten as tennuoc,t.sothe,0 as c_1,1 as lanin,t.gianovat ";
            sql += " from " + xxx + ".d_xuatct a," + user + ".d_dmbd b," + user + ".d_dmnguon c," + user + ".d_dmhang d," + user + ".d_dmnuoc e," + xxx + ".d_theodoi t";
			sql+=" where a.sttt=t.id and a.mabd=b.id and t.manguon=c.id and b.mahang=d.id and b.manuoc=e.id and a.id="+l_id+" order by a.stt";
			DataSet dsxml=d.get_data(sql);
            if (chkXML.Checked)
            {
                if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
                dsxml.WriteXml("..\\xml\\xkhac_linh.xml", XmlWriteMode.WriteSchema);
            }
			frmReport f=new frmReport(d,dsxml.Tables[0], i_userid ,"d_phieulanh_dt_dg_hd.rpt",khox.Text.Trim(),(lydo.Text!="")?"PHIẾU XUẤT "+khon.Text.ToUpper().Trim():"PHIẾU LĨNH","Ngày "+ngaysp.Text,"","",khon.Text.Trim()+": "+lydo.Text.ToUpper().Trim(),"",s_mmyy,"","");
			f.ShowDialog(this);
		}

		private void chkSophieu_CheckedChanged(object sender, System.EventArgs e)
		{
			bSophieu=chkSophieu.Checked;
			dssp.Tables[0].Rows[0]["sophieu"]=(bSophieu)?1:0;
			dssp.WriteXml("..\\..\\..\\xml\\d_sophieukhac.xml");
		}

        private void frmXLuanchuyenCN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7) butInlinh_Click(sender, e);
            else if (e.KeyCode == Keys.F8) butIn_Click(sender, e);
        }
        private void chkGianovat_Click(object sender, EventArgs e)
        {
            if (chkGianovat.Checked) chkgiaban.Checked = false;
        }

        private void chkgiaban_Click(object sender, EventArgs e)
        {
            if (chkgiaban.Checked) chkGianovat.Checked = false;
        }

        private void listDMBD_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                mabd.Text = listDMBD.Text;
                r = d.getrowbyid(dtton, "stt=" + mabd.Text);
                if (r != null)
                {
                    txtid.Text = r["id"].ToString();
                    mabd.Text = r["ma"].ToString();
                    tenbd.Text = r["ten"].ToString();
                    tenhc.Text = r["tenhc"].ToString();
                    dang.Text = r["dang"].ToString();
                    khox.SelectedValue = r["makho"].ToString();
                    manguon.SelectedValue = r["manguon"].ToString();
                    if (bQuanly_xuatban_theomavach) sttt.Text = r["stt"].ToString();//theo ma vach
                    listDMBD.Hide();
                    soluong.Focus();
                    slton.Text = r["soluong"].ToString();
                    if (r["vtyt"].ToString() == "1") dongia.Text = r["dongia"].ToString();
                    else dongia.Text = r["gianovat"].ToString();
                    giaban.Text = r["giaban"].ToString();
                    d_vat = decimal.Parse(r["vat"].ToString() == "" ? "0" : r["vat"].ToString());
                }
            }
            catch { }
        }

        private void mavach_sttt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void mavach_sttt_Validated(object sender, EventArgs e)
        {
            try
            {
                if(mavach_sttt.Text.Trim()=="") return;
                string s_mavach = mavach_sttt.Text;
                //string xxx = s_mavach.Substring(0, 4);
                // kiem tra ton kho
                sql = "select b.ma,b.ten ||' '||b.hamluong as ten,b.tenhc,b.dang , a.mabd,a.handung,a.losx,round(a.giamua,2) as dongia,round(a.giaban,2) giaban,a.manguon,a.nhomcc,a.id as sttt,round(a.giamua,2) as giamua,a.mavach ";
                sql += ",sum(c.tondaumv+c.slnhap-c.slxuatmv) as ton,b.vat ";
                sql += " from " +user+ s_mmyy + ".d_theodoi a,"+user+".d_dmbd b,"+xxx+".d_tonkhoct c where c.stt=a.id and a.mabd=b.id and mavach=" + s_mavach+" and c.makho="+khox.SelectedValue.ToString();// +" and mabd=" + dataGrid1[i_current_row, 16].ToString();
                sql += " group by b.ma,b.ten ||' '||b.hamluong,b.tenhc,b.dang,a.mabd,a.handung,a.losx,round(a.giamua,2),round(a.giaban,2),a.manguon,a.nhomcc,a.id,a.mavach,b.vat";
                DataTable tmp = d.get_data(sql).Tables[0];
                if (tmp.Rows.Count > 0)
                {
                    // hien thi thog tin
                    txtid.Text = tmp.Rows[0]["mabd"].ToString();
                    mabd.Text = tmp.Rows[0]["ma"].ToString();
                    tenbd.Text = tmp.Rows[0]["ten"].ToString();
                    tenhc.Text = tmp.Rows[0]["tenhc"].ToString();
                    dang.Text = tmp.Rows[0]["dang"].ToString();
                    soluong.Text = "0";
                    dongia.Text = tmp.Rows[0]["dongia"].ToString();
                    d_sotien = decimal.Parse(soluong.Text) * decimal.Parse(dongia.Text);
                    sotien.Text = d_sotien.ToString();
                    giaban.Text = tmp.Rows[0]["giaban"].ToString();
                    handung.Text = tmp.Rows[0]["handung"].ToString();
                    losx.Text = tmp.Rows[0]["losx"].ToString();
                    txtsttt.Text = tmp.Rows[0]["sttt"].ToString();
                    slton.Text = tmp.Rows[0]["ton"].ToString();
                    txtvat.Text = tmp.Rows[0]["vat"].ToString().Trim() == "" ? "0" : tmp.Rows[0]["vat"].ToString(); ;
                    try
                    {
                        manguon.SelectedValue = tmp.Rows[0]["manguon"].ToString();
                        nhomcc.SelectedValue = tmp.Rows[0]["nhomcc"].ToString();
                    }
                    catch
                    { }
                    //
                    DataRow row = d.getrowbyid(dtct, "mabd=" + tmp.Rows[0]["mabd"].ToString());
                    if (row != null)
                    {
                        row["dongia"] = tmp.Rows[0]["dongia"].ToString();
                        row["giaban"] = tmp.Rows[0]["giaban"].ToString();
                        row["handung"] = tmp.Rows[0]["handung"].ToString();
                        row["losx"] = tmp.Rows[0]["losx"].ToString();
                        d_sotien = decimal.Parse(row["soluong"].ToString())* decimal.Parse(tmp.Rows[0]["dongia"].ToString());
                        row["sotien"] = Math.Round(d_sotien, 2);
                        row["manguon"] = tmp.Rows[0]["manguon"].ToString();
                        row["nhomcc"] = tmp.Rows[0]["nhomcc"].ToString();
                        row["sttt"] = tmp.Rows[0]["sttt"].ToString();
                        row["slton"] = tmp.Rows[0]["ton"].ToString();
                        row["mavach"] = s_mavach;
                        dtct.AcceptChanges();
                        soluong.Text = ((decimal)decimal.Parse(row["soluong"].ToString())).ToString();
                    }
                    else
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy "+tenbd.Text +" trong danh sách kế hoạch "));
                       // stt.Text=d.get_stt(dtct_mavach.Select("")).ToString();
                    }
                    lblTonkho.Text = ((decimal)decimal.Parse(tmp.Rows[0]["ton"].ToString())).ToString();
                }
                else
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy sản phẩm trong tồn kho"));
                }
                
            }
            catch
            { }
            // Hien comment
            //DataRow r = d.getrowbyid(dtton, "stt=" + s_sttt);
            //if (r != null)
            //{
            //    sttt.Text = r["stt"].ToString();
            //    mabd.Text = r["ma"].ToString();
            //    get_items(s_sttt);
            //    if (tenbd.Text != "") soluong.Focus();
            //    else if (mabd.Enabled) mabd.Focus();
            //    else tenbd.Focus();
            //}
            // End hien
        }

        private void soluong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }
        private void load_sophieukehoach()
        {
            string s_makhotmp = s_makho;
            string s_tu = "01/" + s_ngay.Substring(3);
            DateTime d_tu = d.StringToDate(s_tu).AddDays(-d.iNgaykiemke);
            s_tu = d.DateToString(d_tu);
            DateTime d_den = d.StringToDate(s_ngay).AddDays(d.iNgaykiemke); ;
            string s_den = d.DateToString(d_den);
            //
            sql = "select distinct d.id,d.phieu ";
            sql += " from " + user + ".d_kehoachdathangct a," + user + ".d_kehoachdathangtheodoi b," + user + ".d_kehoachdukientheodoi c," + user + ".d_kehoachdathang d ";
            sql += " where a.id=b.id and d.id=a.id and b.id_duyetdutrukho=c.id and a.daxuat<>a.slthucte ";
            sql += " and a.id_chinhanh="+cbChinhanh.SelectedValue.ToString();
            sql += " and to_date(to_char(d.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";
            dtphieukh = d.get_data(sql).Tables[0];
            cboSophieu.DataSource = dtphieukh;
        }
        //
        private void load_sophieu_dutru_chinhanhkhac(string ammyy)
        {
            string s_makhotmp = s_makho;
            string s_tu = "01/" + s_ngay.Substring(3);
            DateTime d_tu = d.StringToDate(s_tu).AddDays(-d.iNgaykiemke);
            s_tu = d.DateToString(d_tu);
            DateTime d_den = d.StringToDate(s_ngay).AddDays(d.iNgaykiemke); ;
            string s_den = d.DateToString(d_den);
            //
            //string _sconn = d.f_get_connection(int.Parse(cbChinhanh.SelectedValue.ToString()));
            string ausrmmyy = user + ammyy;
            //
            sql = "select distinct a.id,a.sophieu as phieu ";
            sql += " from " + ausrmmyy + ".d_dutrucapll" + s_DBLink_CNNhan + " a," + ausrmmyy + ".d_dutrucapct" + s_DBLink_CNNhan + " b ";
            sql += " where a.id=b.id and b.slyeucau<>b.slthuc ";
            //sql += " and a.id_chinhanh=" + cbChinhanh.SelectedValue.ToString();
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";
            dtphieukh = d.get_data(sql).Tables[0];
            cboSophieu.DataSource = dtphieukh;
        }
        //
        private void cbChinhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == cbChinhanh || sender==null)
            {
                if (b_duyetTheoDutruKhoCuaChiNhanh ==false)
                {
                    load_sophieukehoach();
                }
                else
                {
                    load_sophieu_dutru_chinhanhkhac(s_mmyy);
                }
                dtct.Clear();
                dataGrid2.CaptionText = "Danh sách các sản phẩm được xuất cho "+cbChinhanh.Text;
                dtct_mavach.Clear();
            }
        }

        private void cboSophieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl== cboSophieu)
            {
                load_dm();
                if (b_duyetTheoDutruKhoCuaChiNhanh==false)
                {
                    load_kehoachct();
                }
                else
                {
                    load_dutrucapct(s_mmyy);
                }
                tongcong();
            }
        }

        private void load_kehoachct()
        {
            try
            {
                string s_id_dathang = "0";
                if (cboSophieu.SelectedValue.ToString() == "") s_id_dathang = "0";
                else s_id_dathang = cboSophieu.SelectedValue.ToString();
                //string dblink = "",s_id_dutruchinhanh="0";
                DataRow row = d.getrowbyid(dschinhanh.Tables[0],"id="+cbChinhanh.SelectedValue.ToString());
                //DataRow row1 = d.getrowbyid(dtphieukh, "id=" + cboSophieu.SelectedValue.ToString());
                if (row != null)// && row1!=null)
                {                    
                    sql = "select a.stt as stt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,nullif(b.tenhc,' ') as tenhc,b.dang,i.ten as tennguon," +
                        "d.ten as tennhomcc,'' as handung,'' as losx,sum(a.slthucte-a.daxuat) as soluong,"+
                        "(case when b.vtyt=1 then round(b.dongia,2) else round(b.dongia*100/(100+b.vat),2) end) as dongia,(case when b.vtyt=1 then round(sum((b.dongia*(a.slthucte-a.daxuat))),2) else round(sum(((b.dongia*100/(100+b.vat))*(a.slthucte-a.daxuat))),2) end) as sotien" +
                        ",round(b.giaban,2) as giaban,f.manguon as manguon," +
                        "b.madv as nhomcc,round(b.dongia,2) as giamua,a.mabd,e.ten as tennuoc,0 as makho,'' as sothe,'' as mabs,'' as tenbs,'' as hotenbn,0.0 as slton,0.0 as sttt,0.0 as mavach,b.vat ";
                    sql += " from " + user + ".d_kehoachdathangct a," + user + ".d_kehoachdathang f," + user + ".d_dmbd b," + user + ".d_dmnx d," + user +
                        ".d_dmnuoc e," + user + ".d_dmnguon i ";
                    //sql += ","+xxx+".d_nhapll k,"+xxx+".d_nhapct l ";
                    sql += " where a.mabd=b.id and b.madv=d.id and b.manuoc=e.id(+) and a.id=f.id and a.id=" + s_id_dathang;
                    // chi lay so luong cua chi nhanh du tru
                    sql += " and i.id=f.manguon ";
                    sql += " and a.mabd in (select mabd from " + user+s_mmyy + ".d_tonkhoct where makho=" + khox.SelectedValue.ToString() + " and (tondau+slnhap-slxuat >0 ))";
                    //sql += " and a.mabd in (select mabd from " + user + ".d_tonghopdutruct@"+row["database"].ToString()+" where id="+row1["id_dutruchinhanh"].ToString()+")";
                    sql += " and a.id_chinhanh=" + cbChinhanh.SelectedValue.ToString();
                    sql += " and a.slthucte>0 ";
                    if (cmbxuat.SelectedIndex == 0) sql += " and b.vtyt=0";
                    else if (cmbxuat.SelectedIndex == 1) sql += " and b.vtyt=1";
                   // sql += " and k.id_kehoachdathang=f.id and k.id=l.id ";
                    sql += " group by a.stt,a.mabd,b.ma,b.ten,b.hamluong,b.tenhc,b.dang,i.ten,d.ten,b.madv,b.dongia,b.giaban,f.manguon,e.ten,b.vtyt,b.vat";
                    dtct = d.get_data(sql).Tables[0];
                    //int stt = 1;
                    foreach (DataRow r in dtct.Rows)
                    {
                        DataRow[] dr = dtton.Select("id=" + r["mabd"].ToString());
                        for (int i = 0; i < dr.Length; i++)
                        {
                            r["slton"] = decimal.Parse(r["slton"].ToString()) + decimal.Parse(dr[i]["soluong"].ToString());
                        }
                        //r["stt"] = stt++;
                        if (s_id_dathang != "")
                        {
                            sql = " select b.* from " + xxx + ".d_nhapll a, " + xxx + ".d_nhapct b where a.id=b.id and a.id_kehoachdathang=" + s_id_dathang + " and mabd=" + r["mabd"].ToString()+" and b.stt="+r["stt"].ToString();
                            DataTable tmp = d.get_data(sql).Tables[0];
                            if (tmp.Rows.Count > 0)
                            {
                                r["handung"] = tmp.Rows[0]["handung"].ToString();
                                r["losx"] = tmp.Rows[0]["losx"].ToString();
                                r["dongia"] = tmp.Rows[0]["dongia"].ToString();
                                r["sotien"] =decimal.Parse(r["soluong"].ToString())* decimal.Parse(tmp.Rows[0]["dongia"].ToString());
                                r["giaban"] = tmp.Rows[0]["giaban"].ToString();
                                r["giamua"] = tmp.Rows[0]["giamua"].ToString();
                            }
                        }
                    }
                    dataGrid1.SetDataBinding(dtct,dtct.Namespace);
                    //dataGrid1.DataSource = dtct;
                    CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
                    DataView dv = (DataView)cm.List;
                    dv.AllowDelete = false;
                    dv.AllowNew = false;
                }
            }
            catch 
            {
                dataGrid1.DataSource = null;
            }
        }
        private void load_dutrucapct(string ammyy)
        {
            try
            {
                string s_id_dathang = "0";
                if (cboSophieu.SelectedValue.ToString() == "") s_id_dathang = "0";
                else s_id_dathang = cboSophieu.SelectedValue.ToString();
                //
                l_id_kehoachdathang = s_id_dathang;
                //string dblink = "",s_id_dutruchinhanh="0";
                DataRow row = d.getrowbyid(dschinhanh.Tables[0], "id='" + cbChinhanh.SelectedValue.ToString() + "'");
                //DataRow row1 = d.getrowbyid(dtphieukh, "id=" + cboSophieu.SelectedValue.ToString());
                if (row != null)// && row1!=null)
                {
                    //
                    //string _sconn = d.f_get_connection(int.Parse(row["id"].ToString()));
                    if (s_DBLink_CNNhan.Trim().Trim('@') == "")
                    {
                        s_DBLink_CNNhan = d.getDBLink(i_IDCN_Nhan);
                        if (s_DBLink_CNNhan.Trim().Trim('@') != "") s_DBLink_CNNhan = "@" + s_DBLink_CNNhan.Trim().Trim('@');
                        else s_DBLink_CNNhan = "";
                    }
                    //
                    xxx = user + ammyy;
                    sql = "select to_number('0') as stt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,nullif(b.tenhc,' ') as tenhc,b.dang,i.ten as tennguon," +
                        "d.ten as tennhomcc,'' as handung,'' as losx,sum(a.slyeucau-a.slthuc) as soluong," +
                        "(case when b.vtyt=1 then round(b.dongia,2) else round(b.dongia*100/(100+b.vat),2) end) as dongia,(case when b.vtyt=1 then round(sum((b.dongia*(a.slyeucau-a.slthuc))),2) else round(sum(((b.dongia*100/(100+b.vat))*(a.slyeucau-a.slthuc))),2) end) as sotien" +
                        ",round(b.giaban,2) as giaban,a.manguon as manguon," +
                        "b.madv as nhomcc,round(b.dongia,2) as giamua,a.mabd,e.ten as tennuoc,0 as makho,'' as sothe,'' as mabs,'' as tenbs,'' as hotenbn,0.0 as slton,0.0 as sttt,0.0 as mavach,b.vat ";
                    sql += " from " + xxx + ".d_dutrucapll" + s_DBLink_CNNhan + " aa, " + xxx + ".d_dutrucapct" + s_DBLink_CNNhan + " a," + user + ".d_dmbd" + s_DBLink_CNNhan + " b," + user + ".d_dmnx" + s_DBLink_CNNhan + " d," + user + ".d_dmnuoc" + s_DBLink_CNNhan + " e," + user + ".d_dmnguon" + s_DBLink_CNNhan + " i," + user + ".d_dmkho" + s_DBLink_CNNhan + " j ";
                    sql += " where aa.id=a.id and a.mabd=b.id and b.madv=d.id(+) and b.manuoc=e.id(+) and a.id=" + s_id_dathang;
                    sql += " and a.manguon=i.id(+) ";
                    sql += " and aa.khon=j.id ";
                    sql += " and j.chinhanh=" + cbChinhanh.SelectedValue.ToString();
                    sql += " and a.slyeucau>0 ";
                    if (cmbxuat.SelectedIndex == 0) sql += " and b.vtyt=0";
                    else if (cmbxuat.SelectedIndex == 1) sql += " and b.vtyt=1";
                    sql += " group by a.mabd,b.ma,b.ten,b.hamluong,b.tenhc,b.dang,i.ten,d.ten,b.madv,b.dongia,b.giaban,a.manguon,e.ten,b.vtyt,b.vat";
                    dtct = d.get_data(sql).Tables[0];
                    int stt = 1;
                    foreach (DataRow r in dtct.Rows)
                    {
                        DataRow[] dr = dtton.Select("id=" + r["mabd"].ToString());
                        for (int i = 0; i < dr.Length; i++)
                        {
                            r["slton"] = decimal.Parse(r["slton"].ToString()) + decimal.Parse(dr[i]["soluong"].ToString());
                        }
                        //
                        if (s_id_dathang != "")
                        {
                            sql = " select b.* from " + xxx + ".d_nhapll a, " + xxx + ".d_nhapct b where a.id=b.id and a.id_kehoachdathang=" + s_id_dathang + " and mabd=" + r["mabd"].ToString() + " and b.stt=" + r["stt"].ToString();
                            DataTable tmp = d.get_data(sql).Tables[0];
                            if (tmp.Rows.Count > 0)
                            {
                                r["handung"] = tmp.Rows[0]["handung"].ToString();
                                r["losx"] = tmp.Rows[0]["losx"].ToString();
                                r["dongia"] = tmp.Rows[0]["dongia"].ToString();
                                r["sotien"] = decimal.Parse(r["soluong"].ToString()) * decimal.Parse(tmp.Rows[0]["dongia"].ToString());
                                r["giaban"] = tmp.Rows[0]["giaban"].ToString();
                                r["giamua"] = tmp.Rows[0]["giamua"].ToString();
                            }
                        }
                        //
                        r["stt"] = stt;
                    }
                    dtct.AcceptChanges();
                    dataGrid1.SetDataBinding(dtct, dtct.Namespace);
                    CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
                    DataView dv = (DataView)cm.List;
                    dv.AllowDelete = false;
                    dv.AllowNew = false;
                }
            }
            catch
            {
                dataGrid1.DataSource = null;
            }
        }

        private void mavach_sttt_Enter(object sender, EventArgs e)
        {
            mavach_sttt.BackColor = Color.PaleGoldenrod;
            mavach_sttt.Clear();
        }
        private void tongcong()
        {
            try
            {
            //    decimal d_soluong=0;
            //    decimal d_tt=0;
            //    foreach (DataRow row in dtct.Rows)
            //    {
            //        d_soluong += decimal.Parse(row["soluong"].ToString());
            //        d_tt += decimal.Parse(row["soluong"].ToString()) * decimal.Parse(row["dongia"].ToString());
            //    }
            //    //label7.Text ="Tổng số : "+ d_soluong.ToString("###,###,###,###.##")+" - Tổng tiền : "+d_tt.ToString("###,###,###,###.##");;
                //lbtt.Text = "Tổng tiền : "+d_tt.ToString("###,###,###,###.##");
            }
            catch { }
        }
        private void mavach_sttt_Leave(object sender, EventArgs e)
        {
            mavach_sttt.BackColor = Color.White;
        }

        private void dataGrid2_CurrentCellChanged(object sender, EventArgs e)
        {
            ref_text1();
            i_index_datagrid = 2;
        }

        private void cmbxuat_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                try
                {
                    //if (cmbxuat.SelectedIndex == 0)
                    //{
                    //    tenbd.Enabled = false;
                    //    mabd.Enabled = false;
                    //    mavach_sttt.Enabled = true;
                    //    bVattu = false;
                    //}
                    //else
                    //{
                        //tenbd.Enabled = true;
                        //mabd.Enabled = true;
                        //mavach_sttt.Enabled = false;
                        if (cmbxuat.SelectedIndex == 0) bVattu = false;
                        else bVattu = true;
                    //}
                }
                catch { }
            }
        }

        private void butchuyen_Click(object sender, EventArgs e)
        {
            if (butchuyen.ForeColor == Color.Black)
            {
                butchuyen.ForeColor = Color.Blue;
                butchuyen.FlatStyle = FlatStyle.Flat;
            }
            else if (butchuyen.ForeColor == Color.Blue)
            {
                string s_datalink = d.getDBLink(cbChinhanh.SelectedIndex != -1 ? int.Parse(cbChinhanh.SelectedValue.ToString()) : 0);
                string sql = "select done from " + user + ".d_chonhapll@" + s_datalink + " where id=" + l_id + "";
                DataTable dt = d.get_data(sql).Tables[0];
                if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("Phiếu này đã nhập, không thể thu hồi !");
                    butchuyen.ForeColor = Color.Red;
                    butchuyen.FlatStyle = FlatStyle.Flat;
                    return;
                }
                butchuyen.ForeColor = Color.Black;
                butchuyen.FlatStyle = FlatStyle.Standard;
                if (dtct.Rows.Count > 0)
                {
                    //string s_datalink = d.getDBLink(cbChinhanh.SelectedIndex != -1 ? int.Parse(cbChinhanh.SelectedValue.ToString()) : 0);
                    d.execute_data("delete " + user + ".d_chonhapct@" + s_datalink + " where id=" + l_id + "");
                    d.execute_data("delete " + user + ".d_chonhapll@" + s_datalink + " where id=" + l_id + "");
                    return;
                }
            }
            else
            {
                bKhongchohuy = true;
                return;
            }
            ///Dong them ngay13/07/2011
            if (d.upd_chonhapll(s_mmyy, l_id, i_nhom, sophieu.Text, ngaysp.Text.Trim(), "", "LC", 0, ichinhanh, cbChinhanh.SelectedIndex != -1 ? int.Parse(cbChinhanh.SelectedValue.ToString()) : 0, i_userid))
            {
                // foreach (DataRow dr1 in dtct.Rows)// hien comment
                foreach (DataRow dr1 in dtct.Rows)
                {
                    if (bQuanly_xuatban_theomavach)
                    {
                        if (!d.upd_chonhapct_lc(s_mmyy, l_id, decimal.Parse(dr1["stt"].ToString()), int.Parse(dr1["mabd"].ToString()),
                        dr1["handung"].ToString(), dr1["losx"].ToString(), int.Parse(dr1["vat"].ToString().Trim() == "" ? "0" : dr1["vat"].ToString()), decimal.Parse(dr1["soluong"].ToString()),//
                        decimal.Parse(dr1["dongia"].ToString()), decimal.Parse(dr1["sotien"].ToString()), decimal.Parse(dr1["giaban"].ToString()),
                        decimal.Parse(dr1["giamua"].ToString()), int.Parse(dr1["manguon"].ToString()), int.Parse(dr1["nhomcc"].ToString()),
                        cbChinhanh.SelectedIndex != -1 ? int.Parse(cbChinhanh.SelectedValue.ToString()) : 0, dr1["mavach"].ToString()))//
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin xuống d_chonhapct phiếu xuất luân chuyển chi nhánh !"), d.Msg);
                            return;
                        }
                    }
                    else
                    {
                        if (!d.upd_chonhapct_lc(s_mmyy, l_id, decimal.Parse(dr1["stt"].ToString()), int.Parse(dr1["mabd"].ToString()),
                            dr1["handung"].ToString(), dr1["losx"].ToString(), 0, decimal.Parse(dr1["soluong"].ToString()),//int.Parse(dr1["vat"].ToString().Trim()=="" ? "0":dr1["vat"].ToString())
                            decimal.Parse(dr1["dongia"].ToString()), decimal.Parse(dr1["sotien"].ToString()), decimal.Parse(dr1["giaban"].ToString()),
                            decimal.Parse(dr1["giamua"].ToString()), int.Parse(dr1["manguon"].ToString()), int.Parse(dr1["nhomcc"].ToString()),
                            cbChinhanh.SelectedIndex != -1 ? int.Parse(cbChinhanh.SelectedValue.ToString()) : 0, "0"))//dr1["mavach"].ToString()
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin xuống d_chonhapct phiếu xuất luân chuyển chi nhánh !"), d.Msg);
                            return;
                        }
                    }
                    
                }
            }
            else
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin phiếu xuất luân chuyển chi nhánh !"), d.Msg);
                return;
            }
            ///End dong
        }

        private void chkLosx_Click(object sender, EventArgs e)
        {
            d.writeXml("d_thongso", "chkLosx_xccn", chkLosx.Checked ? "1" : "0");
        }

        //private int i_kho_vtyt(int i_makho)
        //{
        //    int i_vtyt = 0;
        //    string exp = "id=" + i_makho;
        //    DataRow r = d.getrowbyid(dtkhox, exp);
        //    if (r != null) i_vtyt = int.Parse(r["vtyt"].ToString());
        //    else i_vtyt = 0;
        //    return i_vtyt;
        //}

        public int IDChiNhanhNhan
        {
            set { i_IDCN_Nhan = value; }
        }
	}
}
