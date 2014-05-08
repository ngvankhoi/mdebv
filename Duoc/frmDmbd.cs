using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;

namespace Duoc
{
	public class frmDmbd : System.Windows.Forms.Form
    {
        #region Khai bao
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
		private DataRow r;
		private DataTable dt=new DataTable();
		private DataTable dtnhom=new DataTable();
		private DataTable dtloai=new DataTable();
		private DataTable dthang=new DataTable();
		private DataTable dtnuoc=new DataTable();
		private DataTable dtnhombo=new DataTable();
		private DataTable dtnhomin=new DataTable();
		private DataTable dtsotk=new DataTable();
		private DataTable dthc=new DataTable();
		private DataTable dtcc=new DataTable();
        private DataTable dtthuoc = new DataTable();
        private DataTable dtdd = new DataTable();
        private DataTable dtatc_hoatchat = new DataTable();
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private decimal l_id;
		private int i_nhom,iNhom,iLoai,iHang,iNuoc,iNhomin,iNhombo,iSotk,pos,iNgaytra,i_thuoc,i_nhacc,itable,i_userid;
		private System.Windows.Forms.TextBox ten;
		private System.Windows.Forms.TextBox ma;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private LibList.List listHC;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tenhc;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox hamluong;
		private System.Windows.Forms.TextBox dang;
		private System.Windows.Forms.TextBox manhom;
		private System.Windows.Forms.TextBox maloai;
		private System.Windows.Forms.TextBox mahang;
		private System.Windows.Forms.TextBox manuoc;
		private System.Windows.Forms.TextBox sotk;
		private System.Windows.Forms.TextBox soluong;
		private System.Windows.Forms.CheckBox thietyeu;
		private string sql,s_mmyy,s_manhom,user,route,generic;
        private bool bgiaban, bPhattron, bAdmin, bNhomin_mabd, bNhacc, bMabd_doituong, bChenhlech_thuoc_dannhmuc, bBhyt_admin;
		private System.Windows.Forms.ComboBox bhyt;
		private System.Windows.Forms.TextBox tenhc1;
        private LibList.List listDang;
		private LibList.List listLoai;
		private LibList.List listHang;
		private LibList.List listNuoc;
		private LibList.List listNhombo;
		private LibList.List listSotk;
		private LibList.List listNhom;
		private System.Windows.Forms.Label lNhombo;
		private System.Windows.Forms.Label lSotk;
		private System.Windows.Forms.Label lPhanloai;
		private System.Windows.Forms.Label lHang;
		private System.Windows.Forms.TextBox nhombo;
		private System.Windows.Forms.Label lNuoc;
		private System.Windows.Forms.Label lBhyt;
		private System.Windows.Forms.Label lSoluong;
		private System.Windows.Forms.Button butIn;
		private MaskedTextBox.MaskedTextBox sodk;
		private MaskedTextBox.MaskedTextBox sltoithieu;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown ngaytra;
		private System.Windows.Forms.CheckBox tutruc;
		private System.Windows.Forms.CheckBox phatsau;
		private System.Windows.Forms.Label lsltoithieu;
		private System.Windows.Forms.Label lngaytra;
        private MaskedTextBox.MaskedTextBox tyle;
		private System.Windows.Forms.Label lphantram;
		private System.Windows.Forms.Button butKemtheo;
		private System.Windows.Forms.Button butTD;
		private System.Windows.Forms.NumericUpDown stt;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button butSTT;
		private System.Windows.Forms.TextBox nhomin;
		private LibList.List listNhomin;
		private System.Windows.Forms.Label lNhomin;
		private System.Windows.Forms.TextBox find;
		private System.Windows.Forms.CheckBox sunghiep;
		private System.Windows.Forms.TextBox duongdung;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button butNo;
		private LibList.List listDD;
		private LibList.List listNhacc;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox tencc;
		private System.Windows.Forms.TextBox macc;
        private TextBox donvi;
        private Label label11;
        private CheckBox hide;
        private CheckBox phattron;
        private MaskedTextBox.MaskedTextBox sldonggoi;
        private Label label12;
        private ComboBox madoituong;
        private Label lmadoituong;
        private CheckBox kythuat;
        private CheckBox chenhlech;
        private TextBox donvisudung;
        private Label label13;
        private ToolTip toolTip1;
        private CheckBox choduyet;
        private Button butToithieu;
        private Button butNhatky;
        private CheckBox chkkhongcungchitra;
        private LibList.List listdonggoi;
        private ComboBox cbdungluc;
        private Label label14;
        private CheckBox chkketoa;
        private CheckBox chktt10;
        private CheckBox chktt11;
        private CheckBox chkVac;
        private Label label15;
        private Label label17;
        private TextBox txtSttVB;
        private TextBox txtStt02;
        private LibList.List listThuoc;
        private TextBox txtmaatc;
        private Label label18;
        private TextBox txtgeneric;
        private Label label19;
        private TextBox txtStt;
        private IContainer components;
        private CheckBox chkTreem;
        private TextBox txtSttByt;
        private Label label20;
        private ComboBox cmbLoaithuoc;
        private Label label21;
        private TextBox txtnguongoc;
        private Label label22;
        private TextBox txtChaogia;
        private Label label16;
        private TextBox txtSTT12;
        private Label label23;
        private Label label24;
        private MaskedBox.MaskedBox txtNgaycapSDK;
        private CheckBox chkVtyt;
        private CheckBox chkSinhpham;
        private Button butImpExcel;
        private bool bNew = false;
        #endregion

        public frmDmbd(AccessData acc,int nhom,int thuoc,string mmyy,bool giaban,bool admin,string _manhom,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;i_nhom=nhom;i_thuoc=thuoc;
			bgiaban=giaban;s_manhom=_manhom;
            bAdmin = admin; s_mmyy = mmyy; i_userid = userid;
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
			//
			// TODO: Add any constructor code after InitializeComponent call
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
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDmbd));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label2 = new System.Windows.Forms.Label();
            this.ten = new System.Windows.Forms.TextBox();
            this.ma = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lNhombo = new System.Windows.Forms.Label();
            this.lBhyt = new System.Windows.Forms.Label();
            this.lSotk = new System.Windows.Forms.Label();
            this.listHC = new LibList.List();
            this.label3 = new System.Windows.Forms.Label();
            this.tenhc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lPhanloai = new System.Windows.Forms.Label();
            this.lHang = new System.Windows.Forms.Label();
            this.lNuoc = new System.Windows.Forms.Label();
            this.lSoluong = new System.Windows.Forms.Label();
            this.hamluong = new System.Windows.Forms.TextBox();
            this.dang = new System.Windows.Forms.TextBox();
            this.manhom = new System.Windows.Forms.TextBox();
            this.maloai = new System.Windows.Forms.TextBox();
            this.mahang = new System.Windows.Forms.TextBox();
            this.manuoc = new System.Windows.Forms.TextBox();
            this.nhombo = new System.Windows.Forms.TextBox();
            this.sotk = new System.Windows.Forms.TextBox();
            this.soluong = new System.Windows.Forms.TextBox();
            this.thietyeu = new System.Windows.Forms.CheckBox();
            this.bhyt = new System.Windows.Forms.ComboBox();
            this.tenhc1 = new System.Windows.Forms.TextBox();
            this.listDang = new LibList.List();
            this.listLoai = new LibList.List();
            this.listHang = new LibList.List();
            this.listNuoc = new LibList.List();
            this.listNhombo = new LibList.List();
            this.listSotk = new LibList.List();
            this.listNhom = new LibList.List();
            this.sodk = new MaskedTextBox.MaskedTextBox();
            this.sltoithieu = new MaskedTextBox.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lsltoithieu = new System.Windows.Forms.Label();
            this.lngaytra = new System.Windows.Forms.Label();
            this.tutruc = new System.Windows.Forms.CheckBox();
            this.phatsau = new System.Windows.Forms.CheckBox();
            this.ngaytra = new System.Windows.Forms.NumericUpDown();
            this.tyle = new MaskedTextBox.MaskedTextBox();
            this.lphantram = new System.Windows.Forms.Label();
            this.stt = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.lNhomin = new System.Windows.Forms.Label();
            this.nhomin = new System.Windows.Forms.TextBox();
            this.listNhomin = new LibList.List();
            this.find = new System.Windows.Forms.TextBox();
            this.sunghiep = new System.Windows.Forms.CheckBox();
            this.duongdung = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.butNo = new System.Windows.Forms.Button();
            this.listDD = new LibList.List();
            this.listNhacc = new LibList.List();
            this.label10 = new System.Windows.Forms.Label();
            this.tencc = new System.Windows.Forms.TextBox();
            this.macc = new System.Windows.Forms.TextBox();
            this.donvi = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.hide = new System.Windows.Forms.CheckBox();
            this.phattron = new System.Windows.Forms.CheckBox();
            this.sldonggoi = new MaskedTextBox.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.lmadoituong = new System.Windows.Forms.Label();
            this.kythuat = new System.Windows.Forms.CheckBox();
            this.chenhlech = new System.Windows.Forms.CheckBox();
            this.donvisudung = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.choduyet = new System.Windows.Forms.CheckBox();
            this.butNhatky = new System.Windows.Forms.Button();
            this.butToithieu = new System.Windows.Forms.Button();
            this.butSTT = new System.Windows.Forms.Button();
            this.butTD = new System.Windows.Forms.Button();
            this.butKemtheo = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.chkkhongcungchitra = new System.Windows.Forms.CheckBox();
            this.listdonggoi = new LibList.List();
            this.cbdungluc = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.chkketoa = new System.Windows.Forms.CheckBox();
            this.chktt10 = new System.Windows.Forms.CheckBox();
            this.chktt11 = new System.Windows.Forms.CheckBox();
            this.chkVac = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtSttVB = new System.Windows.Forms.TextBox();
            this.txtStt02 = new System.Windows.Forms.TextBox();
            this.listThuoc = new LibList.List();
            this.txtmaatc = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtgeneric = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtStt = new System.Windows.Forms.TextBox();
            this.chkTreem = new System.Windows.Forms.CheckBox();
            this.txtSttByt = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbLoaithuoc = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtnguongoc = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtChaogia = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtSTT12 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtNgaycapSDK = new MaskedBox.MaskedBox();
            this.chkVtyt = new System.Windows.Forms.CheckBox();
            this.chkSinhpham = new System.Windows.Forms.CheckBox();
            this.butImpExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngaytra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stt)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
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
            this.dataGrid1.Location = new System.Drawing.Point(4, 6);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(976, 307);
            this.dataGrid1.TabIndex = 19;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(115, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 23);
            this.label2.TabIndex = 112;
            this.label2.Text = "Tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ten
            // 
            this.ten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(150, 316);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(247, 21);
            this.ten.TabIndex = 1;
            this.ten.TextChanged += new System.EventHandler(this.ten_TextChanged);
            this.ten.Validated += new System.EventHandler(this.ten_Validated);
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // ma
            // 
            this.ma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ma.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ma.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ma.Enabled = false;
            this.ma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ma.Location = new System.Drawing.Point(63, 316);
            this.ma.MaxLength = 10;
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(60, 21);
            this.ma.TabIndex = 0;
            this.ma.Validated += new System.EventHandler(this.ma_Validated);
            this.ma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(33, 317);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 23);
            this.label1.TabIndex = 109;
            this.label1.Text = "Mã :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Location = new System.Drawing.Point(655, 337);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 23);
            this.label4.TabIndex = 94;
            this.label4.Text = "Nhóm :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lNhombo
            // 
            this.lNhombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lNhombo.Location = new System.Drawing.Point(191, 359);
            this.lNhombo.Name = "lNhombo";
            this.lNhombo.Size = new System.Drawing.Size(56, 23);
            this.lNhombo.TabIndex = 87;
            this.lNhombo.Text = "Dược BV :";
            this.lNhombo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.lNhombo, "Nhóm báo cáo dược Bệnh viện (báo cáo biểu 07)");
            // 
            // lBhyt
            // 
            this.lBhyt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lBhyt.Location = new System.Drawing.Point(183, 405);
            this.lBhyt.Name = "lBhyt";
            this.lBhyt.Size = new System.Drawing.Size(61, 19);
            this.lBhyt.TabIndex = 84;
            this.lBhyt.Text = "BHYT trả:";
            this.lBhyt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.lBhyt, "Tỷ lệ BHYT chi trả");
            // 
            // lSotk
            // 
            this.lSotk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lSotk.Location = new System.Drawing.Point(616, 403);
            this.lSotk.Name = "lSotk";
            this.lSotk.Size = new System.Drawing.Size(88, 23);
            this.lSotk.TabIndex = 91;
            this.lSotk.Text = "Nhóm kế toán:";
            this.lSotk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listHC
            // 
            this.listHC.BackColor = System.Drawing.SystemColors.Info;
            this.listHC.ColumnCount = 0;
            this.listHC.Location = new System.Drawing.Point(440, 562);
            this.listHC.MatchBufferTimeOut = 1000;
            this.listHC.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listHC.Name = "listHC";
            this.listHC.Size = new System.Drawing.Size(75, 17);
            this.listHC.TabIndex = 60;
            this.listHC.TextIndex = -1;
            this.listHC.TextMember = null;
            this.listHC.ValueIndex = -1;
            this.listHC.Visible = false;
            this.listHC.Validated += new System.EventHandler(this.listHC_Validated);
            this.listHC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listHC_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(3, 337);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 23);
            this.label3.TabIndex = 108;
            this.label3.Text = "Hoạt chất :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenhc
            // 
            this.tenhc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tenhc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenhc.Enabled = false;
            this.tenhc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenhc.Location = new System.Drawing.Point(63, 338);
            this.tenhc.Name = "tenhc";
            this.tenhc.Size = new System.Drawing.Size(334, 21);
            this.tenhc.TabIndex = 5;
            this.tenhc.TextChanged += new System.EventHandler(this.tenhc_TextChanged);
            this.tenhc.Validated += new System.EventHandler(this.tenhc_Validated);
            this.tenhc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenhc_KeyDown);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.Location = new System.Drawing.Point(538, 316);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 23);
            this.label8.TabIndex = 98;
            this.label8.Text = "ĐVT :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.Location = new System.Drawing.Point(387, 316);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 20);
            this.label9.TabIndex = 99;
            this.label9.Text = "Hàm lượng :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lPhanloai
            // 
            this.lPhanloai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lPhanloai.Location = new System.Drawing.Point(5, 360);
            this.lPhanloai.Name = "lPhanloai";
            this.lPhanloai.Size = new System.Drawing.Size(58, 20);
            this.lPhanloai.TabIndex = 107;
            this.lPhanloai.Text = "Phân loại :";
            this.lPhanloai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lHang
            // 
            this.lHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lHang.Location = new System.Drawing.Point(647, 381);
            this.lHang.Name = "lHang";
            this.lHang.Size = new System.Drawing.Size(57, 23);
            this.lHang.TabIndex = 92;
            this.lHang.Text = "Hãng SX :";
            this.lHang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lNuoc
            // 
            this.lNuoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lNuoc.Location = new System.Drawing.Point(644, 359);
            this.lNuoc.Name = "lNuoc";
            this.lNuoc.Size = new System.Drawing.Size(61, 23);
            this.lNuoc.TabIndex = 93;
            this.lNuoc.Text = "Nước SX :";
            this.lNuoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lSoluong
            // 
            this.lSoluong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lSoluong.Location = new System.Drawing.Point(-2, 404);
            this.lSoluong.Name = "lSoluong";
            this.lSoluong.Size = new System.Drawing.Size(66, 21);
            this.lSoluong.TabIndex = 83;
            this.lSoluong.Text = "ĐV lĩnh :";
            this.lSoluong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hamluong
            // 
            this.hamluong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.hamluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hamluong.Enabled = false;
            this.hamluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hamluong.Location = new System.Drawing.Point(458, 316);
            this.hamluong.MaxLength = 20;
            this.hamluong.Name = "hamluong";
            this.hamluong.Size = new System.Drawing.Size(72, 21);
            this.hamluong.TabIndex = 2;
            this.hamluong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hamluong_KeyDown);
            // 
            // dang
            // 
            this.dang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dang.Enabled = false;
            this.dang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dang.Location = new System.Drawing.Point(572, 316);
            this.dang.MaxLength = 20;
            this.dang.Name = "dang";
            this.dang.Size = new System.Drawing.Size(61, 21);
            this.dang.TabIndex = 3;
            this.dang.TextChanged += new System.EventHandler(this.dang_TextChanged);
            this.dang.Validated += new System.EventHandler(this.dang_Validated);
            this.dang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dang_KeyDown);
            // 
            // manhom
            // 
            this.manhom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.manhom.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manhom.Enabled = false;
            this.manhom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manhom.Location = new System.Drawing.Point(703, 338);
            this.manhom.Name = "manhom";
            this.manhom.Size = new System.Drawing.Size(277, 21);
            this.manhom.TabIndex = 7;
            this.manhom.TextChanged += new System.EventHandler(this.manhom_TextChanged);
            this.manhom.Validated += new System.EventHandler(this.manhom_Validated);
            this.manhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manhom_KeyDown);
            // 
            // maloai
            // 
            this.maloai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.maloai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maloai.Enabled = false;
            this.maloai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maloai.Location = new System.Drawing.Point(63, 360);
            this.maloai.Name = "maloai";
            this.maloai.Size = new System.Drawing.Size(125, 21);
            this.maloai.TabIndex = 8;
            this.maloai.TextChanged += new System.EventHandler(this.maloai_TextChanged);
            this.maloai.Validated += new System.EventHandler(this.maloai_Validated);
            this.maloai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maloai_KeyDown);
            // 
            // mahang
            // 
            this.mahang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mahang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mahang.Enabled = false;
            this.mahang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mahang.Location = new System.Drawing.Point(703, 382);
            this.mahang.Name = "mahang";
            this.mahang.Size = new System.Drawing.Size(277, 21);
            this.mahang.TabIndex = 16;
            this.mahang.TextChanged += new System.EventHandler(this.mahang_TextChanged);
            this.mahang.Validated += new System.EventHandler(this.mahang_Validated);
            this.mahang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mahang_KeyDown);
            // 
            // manuoc
            // 
            this.manuoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.manuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manuoc.Enabled = false;
            this.manuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manuoc.Location = new System.Drawing.Point(703, 360);
            this.manuoc.Name = "manuoc";
            this.manuoc.Size = new System.Drawing.Size(277, 21);
            this.manuoc.TabIndex = 11;
            this.manuoc.TextChanged += new System.EventHandler(this.manuoc_TextChanged);
            this.manuoc.Validated += new System.EventHandler(this.manuoc_Validated);
            this.manuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manuoc_KeyDown);
            // 
            // nhombo
            // 
            this.nhombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nhombo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhombo.Enabled = false;
            this.nhombo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhombo.Location = new System.Drawing.Point(241, 360);
            this.nhombo.Name = "nhombo";
            this.nhombo.Size = new System.Drawing.Size(156, 21);
            this.nhombo.TabIndex = 9;
            this.nhombo.TextChanged += new System.EventHandler(this.nhombo_TextChanged);
            this.nhombo.Validated += new System.EventHandler(this.nhombo_Validated);
            this.nhombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhombo_KeyDown);
            // 
            // sotk
            // 
            this.sotk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sotk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sotk.Enabled = false;
            this.sotk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sotk.Location = new System.Drawing.Point(703, 404);
            this.sotk.Name = "sotk";
            this.sotk.Size = new System.Drawing.Size(277, 21);
            this.sotk.TabIndex = 21;
            this.sotk.TextChanged += new System.EventHandler(this.sotk_TextChanged);
            this.sotk.Validated += new System.EventHandler(this.sotk_Validated);
            this.sotk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sotk_KeyDown);
            // 
            // soluong
            // 
            this.soluong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(63, 404);
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(125, 21);
            this.soluong.TabIndex = 17;
            this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
            this.soluong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLoaithuoc_KeyDown);
            // 
            // thietyeu
            // 
            this.thietyeu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.thietyeu.BackColor = System.Drawing.SystemColors.Control;
            this.thietyeu.Enabled = false;
            this.thietyeu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.thietyeu.Location = new System.Drawing.Point(240, 493);
            this.thietyeu.Name = "thietyeu";
            this.thietyeu.Size = new System.Drawing.Size(73, 20);
            this.thietyeu.TabIndex = 39;
            this.thietyeu.Text = "Thiết yếu";
            this.thietyeu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.thietyeu.UseVisualStyleBackColor = false;
            this.thietyeu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLoaithuoc_KeyDown);
            // 
            // bhyt
            // 
            this.bhyt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bhyt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bhyt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bhyt.Enabled = false;
            this.bhyt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bhyt.Location = new System.Drawing.Point(242, 404);
            this.bhyt.Name = "bhyt";
            this.bhyt.Size = new System.Drawing.Size(56, 21);
            this.bhyt.TabIndex = 18;
            this.bhyt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bhyt_KeyDown);
            // 
            // tenhc1
            // 
            this.tenhc1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenhc1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenhc1.Location = new System.Drawing.Point(40, 287);
            this.tenhc1.Name = "tenhc1";
            this.tenhc1.Size = new System.Drawing.Size(392, 21);
            this.tenhc1.TabIndex = 111;
            this.tenhc1.TextChanged += new System.EventHandler(this.tenhc1_TextChanged);
            // 
            // listDang
            // 
            this.listDang.BackColor = System.Drawing.SystemColors.Info;
            this.listDang.ColumnCount = 0;
            this.listDang.Location = new System.Drawing.Point(494, 562);
            this.listDang.MatchBufferTimeOut = 1000;
            this.listDang.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listDang.Name = "listDang";
            this.listDang.Size = new System.Drawing.Size(75, 17);
            this.listDang.TabIndex = 61;
            this.listDang.TextIndex = -1;
            this.listDang.TextMember = null;
            this.listDang.ValueIndex = -1;
            this.listDang.Visible = false;
            // 
            // listLoai
            // 
            this.listLoai.BackColor = System.Drawing.SystemColors.Info;
            this.listLoai.ColumnCount = 0;
            this.listLoai.Location = new System.Drawing.Point(88, 562);
            this.listLoai.MatchBufferTimeOut = 1000;
            this.listLoai.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listLoai.Name = "listLoai";
            this.listLoai.Size = new System.Drawing.Size(75, 17);
            this.listLoai.TabIndex = 54;
            this.listLoai.TextIndex = -1;
            this.listLoai.TextMember = null;
            this.listLoai.ValueIndex = -1;
            this.listLoai.Visible = false;
            // 
            // listHang
            // 
            this.listHang.BackColor = System.Drawing.SystemColors.Info;
            this.listHang.ColumnCount = 0;
            this.listHang.Location = new System.Drawing.Point(246, 562);
            this.listHang.MatchBufferTimeOut = 1000;
            this.listHang.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listHang.Name = "listHang";
            this.listHang.Size = new System.Drawing.Size(75, 17);
            this.listHang.TabIndex = 45;
            this.listHang.TextIndex = -1;
            this.listHang.TextMember = null;
            this.listHang.ValueIndex = -1;
            this.listHang.Visible = false;
            // 
            // listNuoc
            // 
            this.listNuoc.BackColor = System.Drawing.SystemColors.Info;
            this.listNuoc.ColumnCount = 0;
            this.listNuoc.Location = new System.Drawing.Point(243, 562);
            this.listNuoc.MatchBufferTimeOut = 1000;
            this.listNuoc.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listNuoc.Name = "listNuoc";
            this.listNuoc.Size = new System.Drawing.Size(75, 17);
            this.listNuoc.TabIndex = 57;
            this.listNuoc.TextIndex = -1;
            this.listNuoc.TextMember = null;
            this.listNuoc.ValueIndex = -1;
            this.listNuoc.Visible = false;
            // 
            // listNhombo
            // 
            this.listNhombo.BackColor = System.Drawing.SystemColors.Info;
            this.listNhombo.ColumnCount = 0;
            this.listNhombo.Location = new System.Drawing.Point(382, 562);
            this.listNhombo.MatchBufferTimeOut = 1000;
            this.listNhombo.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listNhombo.Name = "listNhombo";
            this.listNhombo.Size = new System.Drawing.Size(75, 17);
            this.listNhombo.TabIndex = 59;
            this.listNhombo.TextIndex = -1;
            this.listNhombo.TextMember = null;
            this.listNhombo.ValueIndex = -1;
            this.listNhombo.Visible = false;
            // 
            // listSotk
            // 
            this.listSotk.BackColor = System.Drawing.SystemColors.Info;
            this.listSotk.ColumnCount = 0;
            this.listSotk.Location = new System.Drawing.Point(320, 562);
            this.listSotk.MatchBufferTimeOut = 1000;
            this.listSotk.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listSotk.Name = "listSotk";
            this.listSotk.Size = new System.Drawing.Size(75, 17);
            this.listSotk.TabIndex = 58;
            this.listSotk.TextIndex = -1;
            this.listSotk.TextMember = null;
            this.listSotk.ValueIndex = -1;
            this.listSotk.Visible = false;
            // 
            // listNhom
            // 
            this.listNhom.BackColor = System.Drawing.SystemColors.Info;
            this.listNhom.ColumnCount = 0;
            this.listNhom.Location = new System.Drawing.Point(570, 562);
            this.listNhom.MatchBufferTimeOut = 1000;
            this.listNhom.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listNhom.Name = "listNhom";
            this.listNhom.Size = new System.Drawing.Size(75, 17);
            this.listNhom.TabIndex = 62;
            this.listNhom.TextIndex = -1;
            this.listNhom.TextMember = null;
            this.listNhom.ValueIndex = -1;
            this.listNhom.Visible = false;
            // 
            // sodk
            // 
            this.sodk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sodk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sodk.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sodk.Enabled = false;
            this.sodk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sodk.Location = new System.Drawing.Point(347, 426);
            this.sodk.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sodk.Name = "sodk";
            this.sodk.Size = new System.Drawing.Size(108, 21);
            this.sodk.TabIndex = 24;
            this.sodk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLoaithuoc_KeyDown);
            // 
            // sltoithieu
            // 
            this.sltoithieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sltoithieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sltoithieu.Enabled = false;
            this.sltoithieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sltoithieu.Location = new System.Drawing.Point(546, 404);
            this.sltoithieu.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.sltoithieu.Name = "sltoithieu";
            this.sltoithieu.Size = new System.Drawing.Size(64, 21);
            this.sltoithieu.TabIndex = 20;
            this.sltoithieu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sltoithieu.Validated += new System.EventHandler(this.sltoithieu_Validated);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Location = new System.Drawing.Point(305, 426);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 21);
            this.label5.TabIndex = 104;
            this.label5.Text = "Số ĐK :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lsltoithieu
            // 
            this.lsltoithieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lsltoithieu.Location = new System.Drawing.Point(455, 403);
            this.lsltoithieu.Name = "lsltoithieu";
            this.lsltoithieu.Size = new System.Drawing.Size(96, 23);
            this.lsltoithieu.TabIndex = 78;
            this.lsltoithieu.Text = "Tồn tối thiểu :";
            this.lsltoithieu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lngaytra
            // 
            this.lngaytra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lngaytra.Location = new System.Drawing.Point(310, 403);
            this.lngaytra.Name = "lngaytra";
            this.lngaytra.Size = new System.Drawing.Size(95, 23);
            this.lngaytra.TabIndex = 77;
            this.lngaytra.Text = "Ngày trả sau lĩnh:";
            this.lngaytra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tutruc
            // 
            this.tutruc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tutruc.BackColor = System.Drawing.SystemColors.Control;
            this.tutruc.Enabled = false;
            this.tutruc.Location = new System.Drawing.Point(348, 493);
            this.tutruc.Name = "tutruc";
            this.tutruc.Size = new System.Drawing.Size(82, 20);
            this.tutruc.TabIndex = 40;
            this.tutruc.Text = "Lĩnh tủ trực";
            this.tutruc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tutruc.UseVisualStyleBackColor = false;
            this.tutruc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLoaithuoc_KeyDown);
            // 
            // phatsau
            // 
            this.phatsau.BackColor = System.Drawing.SystemColors.Control;
            this.phatsau.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.phatsau.Enabled = false;
            this.phatsau.Location = new System.Drawing.Point(682, 565);
            this.phatsau.Name = "phatsau";
            this.phatsau.Size = new System.Drawing.Size(70, 24);
            this.phatsau.TabIndex = 66;
            this.phatsau.Text = "Lĩnh dồn";
            this.phatsau.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.phatsau.UseVisualStyleBackColor = false;
            this.phatsau.Visible = false;
            this.phatsau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thietyeu_KeyDown);
            // 
            // ngaytra
            // 
            this.ngaytra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ngaytra.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaytra.Enabled = false;
            this.ngaytra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaytra.Location = new System.Drawing.Point(405, 404);
            this.ngaytra.Name = "ngaytra";
            this.ngaytra.Size = new System.Drawing.Size(49, 21);
            this.ngaytra.TabIndex = 19;
            this.ngaytra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thietyeu_KeyDown);
            // 
            // tyle
            // 
            this.tyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tyle.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tyle.Enabled = false;
            this.tyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tyle.Location = new System.Drawing.Point(142, 564);
            this.tyle.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.tyle.Name = "tyle";
            this.tyle.Size = new System.Drawing.Size(55, 21);
            this.tyle.TabIndex = 19;
            this.tyle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tyle.Visible = false;
            this.tyle.Validated += new System.EventHandler(this.tyle_Validated);
            // 
            // lphantram
            // 
            this.lphantram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lphantram.Location = new System.Drawing.Point(299, 403);
            this.lphantram.Name = "lphantram";
            this.lphantram.Size = new System.Drawing.Size(16, 23);
            this.lphantram.TabIndex = 90;
            this.lphantram.Text = "%";
            this.lphantram.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stt
            // 
            this.stt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.stt.Enabled = false;
            this.stt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stt.Location = new System.Drawing.Point(242, 425);
            this.stt.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.stt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(56, 21);
            this.stt.TabIndex = 23;
            this.stt.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.stt.Visible = false;
            this.stt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thietyeu_KeyDown);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.Enabled = false;
            this.label6.Location = new System.Drawing.Point(214, 427);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 16);
            this.label6.TabIndex = 103;
            this.label6.Text = "STT:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Visible = false;
            // 
            // lNhomin
            // 
            this.lNhomin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lNhomin.Location = new System.Drawing.Point(402, 359);
            this.lNhomin.Name = "lNhomin";
            this.lNhomin.Size = new System.Drawing.Size(56, 23);
            this.lNhomin.TabIndex = 101;
            this.lNhomin.Text = "Nhóm in :";
            this.lNhomin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhomin
            // 
            this.nhomin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nhomin.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhomin.Enabled = false;
            this.nhomin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhomin.Location = new System.Drawing.Point(458, 360);
            this.nhomin.Name = "nhomin";
            this.nhomin.Size = new System.Drawing.Size(175, 21);
            this.nhomin.TabIndex = 10;
            this.nhomin.TextChanged += new System.EventHandler(this.nhomin_TextChanged);
            this.nhomin.Validated += new System.EventHandler(this.nhomin_Validated);
            this.nhomin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhomin_KeyDown);
            // 
            // listNhomin
            // 
            this.listNhomin.BackColor = System.Drawing.SystemColors.Info;
            this.listNhomin.ColumnCount = 0;
            this.listNhomin.Location = new System.Drawing.Point(7, 562);
            this.listNhomin.MatchBufferTimeOut = 1000;
            this.listNhomin.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listNhomin.Name = "listNhomin";
            this.listNhomin.Size = new System.Drawing.Size(75, 17);
            this.listNhomin.TabIndex = 53;
            this.listNhomin.TextIndex = -1;
            this.listNhomin.TextMember = null;
            this.listNhomin.ValueIndex = -1;
            this.listNhomin.Visible = false;
            // 
            // find
            // 
            this.find.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.find.BackColor = System.Drawing.SystemColors.HighlightText;
            this.find.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.find.Location = new System.Drawing.Point(4, 2);
            this.find.Name = "find";
            this.find.Size = new System.Drawing.Size(976, 21);
            this.find.TabIndex = 67;
            this.find.Text = "Tìm kiếm";
            this.find.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.find.TextChanged += new System.EventHandler(this.find_TextChanged);
            this.find.Enter += new System.EventHandler(this.find_Enter);
            // 
            // sunghiep
            // 
            this.sunghiep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sunghiep.BackColor = System.Drawing.SystemColors.Control;
            this.sunghiep.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.sunghiep.Enabled = false;
            this.sunghiep.Location = new System.Drawing.Point(105, 555);
            this.sunghiep.Name = "sunghiep";
            this.sunghiep.Size = new System.Drawing.Size(74, 24);
            this.sunghiep.TabIndex = 67;
            this.sunghiep.Text = "Sự nghiệp";
            this.sunghiep.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.sunghiep.UseVisualStyleBackColor = false;
            this.sunghiep.Visible = false;
            this.sunghiep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thietyeu_KeyDown);
            // 
            // duongdung
            // 
            this.duongdung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.duongdung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.duongdung.Enabled = false;
            this.duongdung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.duongdung.Location = new System.Drawing.Point(703, 316);
            this.duongdung.Name = "duongdung";
            this.duongdung.Size = new System.Drawing.Size(277, 21);
            this.duongdung.TabIndex = 4;
            this.duongdung.TextChanged += new System.EventHandler(this.duongdung_TextChanged);
            this.duongdung.Validated += new System.EventHandler(this.duongdung_Validated);
            this.duongdung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.duongdung_KeyDown);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.Location = new System.Drawing.Point(619, 318);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 95;
            this.label7.Text = "Đường dùng :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // butNo
            // 
            this.butNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butNo.Enabled = false;
            this.butNo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butNo.Location = new System.Drawing.Point(12, 316);
            this.butNo.Name = "butNo";
            this.butNo.Size = new System.Drawing.Size(24, 21);
            this.butNo.TabIndex = 110;
            this.butNo.Text = "...";
            this.butNo.Click += new System.EventHandler(this.butNo_Click);
            // 
            // listDD
            // 
            this.listDD.BackColor = System.Drawing.SystemColors.Info;
            this.listDD.ColumnCount = 0;
            this.listDD.Location = new System.Drawing.Point(165, 562);
            this.listDD.MatchBufferTimeOut = 1000;
            this.listDD.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listDD.Name = "listDD";
            this.listDD.Size = new System.Drawing.Size(75, 17);
            this.listDD.TabIndex = 55;
            this.listDD.TextIndex = -1;
            this.listDD.TextMember = null;
            this.listDD.ValueIndex = -1;
            this.listDD.Visible = false;
            this.listDD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listDD_KeyDown);
            // 
            // listNhacc
            // 
            this.listNhacc.BackColor = System.Drawing.SystemColors.Info;
            this.listNhacc.ColumnCount = 0;
            this.listNhacc.Location = new System.Drawing.Point(198, 565);
            this.listNhacc.MatchBufferTimeOut = 1000;
            this.listNhacc.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listNhacc.Name = "listNhacc";
            this.listNhacc.Size = new System.Drawing.Size(75, 17);
            this.listNhacc.TabIndex = 56;
            this.listNhacc.TextIndex = -1;
            this.listNhacc.TextMember = null;
            this.listNhacc.ValueIndex = -1;
            this.listNhacc.Visible = false;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.Location = new System.Drawing.Point(326, 383);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 19);
            this.label10.TabIndex = 88;
            this.label10.Text = "C ty phân phối :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tencc
            // 
            this.tencc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tencc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tencc.Enabled = false;
            this.tencc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tencc.Location = new System.Drawing.Point(458, 382);
            this.tencc.Name = "tencc";
            this.tencc.Size = new System.Drawing.Size(175, 21);
            this.tencc.TabIndex = 15;
            this.tencc.TextChanged += new System.EventHandler(this.tencc_TextChanged);
            this.tencc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tencc_KeyDown);
            // 
            // macc
            // 
            this.macc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.macc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.macc.Enabled = false;
            this.macc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.macc.Location = new System.Drawing.Point(405, 382);
            this.macc.Name = "macc";
            this.macc.Size = new System.Drawing.Size(49, 21);
            this.macc.TabIndex = 14;
            this.macc.Validated += new System.EventHandler(this.macc_Validated);
            this.macc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.macc_KeyDown);
            // 
            // donvi
            // 
            this.donvi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.donvi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.donvi.Enabled = false;
            this.donvi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donvi.Location = new System.Drawing.Point(63, 382);
            this.donvi.Name = "donvi";
            this.donvi.Size = new System.Drawing.Size(125, 21);
            this.donvi.TabIndex = 12;
            this.donvi.TextChanged += new System.EventHandler(this.donvi_TextChanged);
            this.donvi.Validated += new System.EventHandler(this.donvi_Validated);
            this.donvi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.donvi_KeyDown);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.Location = new System.Drawing.Point(1, 381);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 23);
            this.label11.TabIndex = 106;
            this.label11.Text = "Đóng gói :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hide
            // 
            this.hide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.hide.Enabled = false;
            this.hide.Location = new System.Drawing.Point(95, 474);
            this.hide.Name = "hide";
            this.hide.Size = new System.Drawing.Size(104, 19);
            this.hide.TabIndex = 32;
            this.hide.Text = "Không nhập mới";
            this.hide.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.hide.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLoaithuoc_KeyDown);
            // 
            // phattron
            // 
            this.phattron.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.phattron.Enabled = false;
            this.phattron.Location = new System.Drawing.Point(348, 473);
            this.phattron.Name = "phattron";
            this.phattron.Size = new System.Drawing.Size(72, 20);
            this.phattron.TabIndex = 34;
            this.phattron.Text = "Phát tròn";
            this.phattron.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.phattron.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLoaithuoc_KeyDown);
            // 
            // sldonggoi
            // 
            this.sldonggoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sldonggoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sldonggoi.Enabled = false;
            this.sldonggoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sldonggoi.Location = new System.Drawing.Point(242, 381);
            this.sldonggoi.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.sldonggoi.Name = "sldonggoi";
            this.sldonggoi.Size = new System.Drawing.Size(56, 21);
            this.sldonggoi.TabIndex = 13;
            this.sldonggoi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.Location = new System.Drawing.Point(216, 380);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 23);
            this.label12.TabIndex = 102;
            this.label12.Text = "SL :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madoituong
            // 
            this.madoituong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.madoituong.Enabled = false;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.FormattingEnabled = true;
            this.madoituong.Location = new System.Drawing.Point(703, 493);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(277, 21);
            this.madoituong.TabIndex = 42;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thietyeu_KeyDown);
            // 
            // lmadoituong
            // 
            this.lmadoituong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lmadoituong.Location = new System.Drawing.Point(646, 492);
            this.lmadoituong.Name = "lmadoituong";
            this.lmadoituong.Size = new System.Drawing.Size(63, 23);
            this.lmadoituong.TabIndex = 75;
            this.lmadoituong.Text = "Đối tượng :";
            this.lmadoituong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kythuat
            // 
            this.kythuat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kythuat.Enabled = false;
            this.kythuat.Location = new System.Drawing.Point(464, 515);
            this.kythuat.Name = "kythuat";
            this.kythuat.Size = new System.Drawing.Size(244, 19);
            this.kythuat.TabIndex = 46;
            this.kythuat.Text = "Thuốc điều trị ung thư, chống thải ghép";
            this.kythuat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLoaithuoc_KeyDown);
            // 
            // chenhlech
            // 
            this.chenhlech.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chenhlech.Enabled = false;
            this.chenhlech.Location = new System.Drawing.Point(240, 474);
            this.chenhlech.Name = "chenhlech";
            this.chenhlech.Size = new System.Drawing.Size(115, 19);
            this.chenhlech.TabIndex = 33;
            this.chenhlech.Text = "Tính chênh lệch";
            this.chenhlech.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLoaithuoc_KeyDown);
            // 
            // donvisudung
            // 
            this.donvisudung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.donvisudung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.donvisudung.Enabled = false;
            this.donvisudung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donvisudung.Location = new System.Drawing.Point(63, 426);
            this.donvisudung.Name = "donvisudung";
            this.donvisudung.Size = new System.Drawing.Size(125, 21);
            this.donvisudung.TabIndex = 22;
            this.toolTip1.SetToolTip(this.donvisudung, "Đơn vị cấp cho BN dùng (đơn vị nhỏ nhất)");
            this.donvisudung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.soluong_KeyDown);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.Location = new System.Drawing.Point(22, 429);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 15);
            this.label13.TabIndex = 86;
            this.label13.Text = "ĐVSD:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.label13, "Đơn vị cấp cho BN dùng (đơn vị nhỏ nhất)");
            // 
            // choduyet
            // 
            this.choduyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.choduyet.Enabled = false;
            this.choduyet.Location = new System.Drawing.Point(21, 560);
            this.choduyet.Name = "choduyet";
            this.choduyet.Size = new System.Drawing.Size(82, 19);
            this.choduyet.TabIndex = 31;
            this.choduyet.Text = "Chờ duyệt";
            this.choduyet.Visible = false;
            this.choduyet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thietyeu_KeyDown);
            // 
            // butNhatky
            // 
            this.butNhatky.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butNhatky.Image = ((System.Drawing.Image)(resources.GetObject("butNhatky.Image")));
            this.butNhatky.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butNhatky.Location = new System.Drawing.Point(618, 533);
            this.butNhatky.Name = "butNhatky";
            this.butNhatky.Size = new System.Drawing.Size(68, 25);
            this.butNhatky.TabIndex = 57;
            this.butNhatky.Text = "Nhật ký";
            this.butNhatky.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butNhatky.Click += new System.EventHandler(this.butNhatky_Click);
            // 
            // butToithieu
            // 
            this.butToithieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butToithieu.Image = global::Duoc.Properties.Resources.ok;
            this.butToithieu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butToithieu.Location = new System.Drawing.Point(686, 533);
            this.butToithieu.Name = "butToithieu";
            this.butToithieu.Size = new System.Drawing.Size(88, 25);
            this.butToithieu.TabIndex = 58;
            this.butToithieu.Text = "Tồn tối thiếu";
            this.butToithieu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butToithieu.Click += new System.EventHandler(this.butToithieu_Click);
            // 
            // butSTT
            // 
            this.butSTT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSTT.Image = global::Duoc.Properties.Resources.chonkhoa;
            this.butSTT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSTT.Location = new System.Drawing.Point(392, 533);
            this.butSTT.Name = "butSTT";
            this.butSTT.Size = new System.Drawing.Size(55, 25);
            this.butSTT.TabIndex = 54;
            this.butSTT.Text = "   Stt";
            this.butSTT.Click += new System.EventHandler(this.butSTT_Click);
            // 
            // butTD
            // 
            this.butTD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butTD.Image = global::Duoc.Properties.Resources.Export;
            this.butTD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTD.Location = new System.Drawing.Point(523, 533);
            this.butTD.Name = "butTD";
            this.butTD.Size = new System.Drawing.Size(95, 25);
            this.butTD.TabIndex = 56;
            this.butTD.Text = "Tương đương";
            this.butTD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butTD.Click += new System.EventHandler(this.butTD_Click);
            // 
            // butKemtheo
            // 
            this.butKemtheo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butKemtheo.Image = global::Duoc.Properties.Resources.copy_enabled;
            this.butKemtheo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKemtheo.Location = new System.Drawing.Point(447, 533);
            this.butKemtheo.Name = "butKemtheo";
            this.butKemtheo.Size = new System.Drawing.Size(76, 25);
            this.butKemtheo.TabIndex = 55;
            this.butKemtheo.Text = "Kèm theo";
            this.butKemtheo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKemtheo.Click += new System.EventHandler(this.butKemtheo_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butIn.Image = global::Duoc.Properties.Resources.Print1;
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(337, 533);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(55, 25);
            this.butIn.TabIndex = 53;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butHuy.Image = global::Duoc.Properties.Resources.delete_enabled;
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(282, 533);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(55, 25);
            this.butHuy.TabIndex = 52;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = global::Duoc.Properties.Resources.undo_ok;
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(222, 533);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(60, 25);
            this.butBoqua.TabIndex = 51;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = global::Duoc.Properties.Resources.save;
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(167, 533);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(55, 25);
            this.butLuu.TabIndex = 48;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSua.Image = global::Duoc.Properties.Resources.quick_edit;
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(112, 533);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(55, 25);
            this.butSua.TabIndex = 49;
            this.butSua.Text = "    &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butMoi.Image = global::Duoc.Properties.Resources.add;
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(57, 533);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(55, 25);
            this.butMoi.TabIndex = 50;
            this.butMoi.Text = "     &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(860, 533);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(68, 25);
            this.butKetthuc.TabIndex = 59;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // chkkhongcungchitra
            // 
            this.chkkhongcungchitra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkkhongcungchitra.BackColor = System.Drawing.SystemColors.Control;
            this.chkkhongcungchitra.Enabled = false;
            this.chkkhongcungchitra.Location = new System.Drawing.Point(464, 471);
            this.chkkhongcungchitra.Name = "chkkhongcungchitra";
            this.chkkhongcungchitra.Size = new System.Drawing.Size(135, 24);
            this.chkkhongcungchitra.TabIndex = 35;
            this.chkkhongcungchitra.Text = "BN không cùng chi trả";
            this.chkkhongcungchitra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkkhongcungchitra.UseVisualStyleBackColor = false;
            this.chkkhongcungchitra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLoaithuoc_KeyDown);
            // 
            // listdonggoi
            // 
            this.listdonggoi.BackColor = System.Drawing.SystemColors.Info;
            this.listdonggoi.ColumnCount = 0;
            this.listdonggoi.Location = new System.Drawing.Point(633, 562);
            this.listdonggoi.MatchBufferTimeOut = 1000;
            this.listdonggoi.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listdonggoi.Name = "listdonggoi";
            this.listdonggoi.Size = new System.Drawing.Size(75, 17);
            this.listdonggoi.TabIndex = 63;
            this.listdonggoi.TextIndex = -1;
            this.listdonggoi.TextMember = null;
            this.listdonggoi.ValueIndex = -1;
            this.listdonggoi.Visible = false;
            // 
            // cbdungluc
            // 
            this.cbdungluc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbdungluc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbdungluc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbdungluc.Enabled = false;
            this.cbdungluc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbdungluc.FormattingEnabled = true;
            this.cbdungluc.Location = new System.Drawing.Point(839, 470);
            this.cbdungluc.Name = "cbdungluc";
            this.cbdungluc.Size = new System.Drawing.Size(141, 21);
            this.cbdungluc.TabIndex = 37;
            this.cbdungluc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLoaithuoc_KeyDown);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.Location = new System.Drawing.Point(783, 469);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 23);
            this.label14.TabIndex = 105;
            this.label14.Text = "Dùng lúc :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkketoa
            // 
            this.chkketoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkketoa.Enabled = false;
            this.chkketoa.Location = new System.Drawing.Point(95, 515);
            this.chkketoa.Name = "chkketoa";
            this.chkketoa.Size = new System.Drawing.Size(102, 19);
            this.chkketoa.TabIndex = 43;
            this.chkketoa.Text = "Kê toa (TT08)";
            this.chkketoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLoaithuoc_KeyDown);
            // 
            // chktt10
            // 
            this.chktt10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chktt10.Enabled = false;
            this.chktt10.Location = new System.Drawing.Point(240, 515);
            this.chktt10.Name = "chktt10";
            this.chktt10.Size = new System.Drawing.Size(114, 19);
            this.chktt10.TabIndex = 44;
            this.chktt10.Text = "Gây nghiện(TT10)";
            this.chktt10.CheckedChanged += new System.EventHandler(this.chktt10_CheckedChanged);
            this.chktt10.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLoaithuoc_KeyDown);
            // 
            // chktt11
            // 
            this.chktt11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chktt11.Enabled = false;
            this.chktt11.Location = new System.Drawing.Point(348, 515);
            this.chktt11.Name = "chktt11";
            this.chktt11.Size = new System.Drawing.Size(121, 19);
            this.chktt11.TabIndex = 45;
            this.chktt11.Text = "Hướng thần (TT11)";
            this.chktt11.CheckedChanged += new System.EventHandler(this.chktt11_CheckedChanged);
            this.chktt11.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLoaithuoc_KeyDown);
            // 
            // chkVac
            // 
            this.chkVac.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkVac.Enabled = false;
            this.chkVac.Location = new System.Drawing.Point(4, 474);
            this.chkVac.Name = "chkVac";
            this.chkVac.Size = new System.Drawing.Size(78, 19);
            this.chkVac.TabIndex = 47;
            this.chkVac.Text = "Vacxin";
            this.chkVac.CheckedChanged += new System.EventHandler(this.chkVac_CheckedChanged);
            this.chkVac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLoaithuoc_KeyDown);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.Location = new System.Drawing.Point(-6, 448);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 21);
            this.label15.TabIndex = 68;
            this.label15.Text = "STT của BHXH :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.Location = new System.Drawing.Point(249, 447);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(100, 23);
            this.label17.TabIndex = 74;
            this.label17.Text = "STT trong DM 02 :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSttVB
            // 
            this.txtSttVB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSttVB.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtSttVB.Enabled = false;
            this.txtSttVB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSttVB.Location = new System.Drawing.Point(94, 448);
            this.txtSttVB.Name = "txtSttVB";
            this.txtSttVB.Size = new System.Drawing.Size(94, 21);
            this.txtSttVB.TabIndex = 27;
            this.txtSttVB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLoaithuoc_KeyDown);
            // 
            // txtStt02
            // 
            this.txtStt02.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtStt02.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtStt02.Enabled = false;
            this.txtStt02.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStt02.Location = new System.Drawing.Point(347, 448);
            this.txtStt02.Name = "txtStt02";
            this.txtStt02.Size = new System.Drawing.Size(108, 21);
            this.txtStt02.TabIndex = 28;
            this.txtStt02.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLoaithuoc_KeyDown);
            // 
            // listThuoc
            // 
            this.listThuoc.BackColor = System.Drawing.SystemColors.Info;
            this.listThuoc.ColumnCount = 0;
            this.listThuoc.Location = new System.Drawing.Point(713, 562);
            this.listThuoc.MatchBufferTimeOut = 1000;
            this.listThuoc.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listThuoc.Name = "listThuoc";
            this.listThuoc.Size = new System.Drawing.Size(75, 17);
            this.listThuoc.TabIndex = 65;
            this.listThuoc.TextIndex = -1;
            this.listThuoc.TextMember = null;
            this.listThuoc.ValueIndex = -1;
            this.listThuoc.Visible = false;
            this.listThuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listThuoc_KeyDown);
            // 
            // txtmaatc
            // 
            this.txtmaatc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtmaatc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtmaatc.Enabled = false;
            this.txtmaatc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmaatc.Location = new System.Drawing.Point(458, 338);
            this.txtmaatc.Name = "txtmaatc";
            this.txtmaatc.Size = new System.Drawing.Size(175, 21);
            this.txtmaatc.TabIndex = 6;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label18.Location = new System.Drawing.Point(400, 337);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 23);
            this.label18.TabIndex = 100;
            this.label18.Text = "ATC :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtgeneric
            // 
            this.txtgeneric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtgeneric.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtgeneric.Enabled = false;
            this.txtgeneric.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtgeneric.Location = new System.Drawing.Point(105, 90);
            this.txtgeneric.Name = "txtgeneric";
            this.txtgeneric.Size = new System.Drawing.Size(364, 21);
            this.txtgeneric.TabIndex = 96;
            this.txtgeneric.Visible = false;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label19.Location = new System.Drawing.Point(365, 105);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(52, 23);
            this.label19.TabIndex = 97;
            this.label19.Text = "Generic :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label19.Visible = false;
            // 
            // txtStt
            // 
            this.txtStt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtStt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtStt.Enabled = false;
            this.txtStt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStt.Location = new System.Drawing.Point(795, 559);
            this.txtStt.Name = "txtStt";
            this.txtStt.Size = new System.Drawing.Size(56, 21);
            this.txtStt.TabIndex = 64;
            this.txtStt.Visible = false;
            // 
            // chkTreem
            // 
            this.chkTreem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkTreem.AutoSize = true;
            this.chkTreem.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTreem.Enabled = false;
            this.chkTreem.Location = new System.Drawing.Point(95, 495);
            this.chkTreem.Name = "chkTreem";
            this.chkTreem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkTreem.Size = new System.Drawing.Size(136, 17);
            this.chkTreem.TabIndex = 38;
            this.chkTreem.Text = "Thuốc sử dụng cho TE";
            this.chkTreem.UseVisualStyleBackColor = true;
            this.chkTreem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLoaithuoc_KeyDown);
            // 
            // txtSttByt
            // 
            this.txtSttByt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSttByt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtSttByt.Enabled = false;
            this.txtSttByt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSttByt.Location = new System.Drawing.Point(546, 448);
            this.txtSttByt.MaxLength = 10;
            this.txtSttByt.Name = "txtSttByt";
            this.txtSttByt.Size = new System.Drawing.Size(64, 21);
            this.txtSttByt.TabIndex = 29;
            this.txtSttByt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLoaithuoc_KeyDown);
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.Location = new System.Drawing.Point(456, 447);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(101, 23);
            this.label20.TabIndex = 69;
            this.label20.Text = "STT trong DM 05:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbLoaithuoc
            // 
            this.cmbLoaithuoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLoaithuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbLoaithuoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoaithuoc.DropDownWidth = 300;
            this.cmbLoaithuoc.Enabled = false;
            this.cmbLoaithuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoaithuoc.FormattingEnabled = true;
            this.cmbLoaithuoc.Location = new System.Drawing.Point(703, 425);
            this.cmbLoaithuoc.Name = "cmbLoaithuoc";
            this.cmbLoaithuoc.Size = new System.Drawing.Size(277, 21);
            this.cmbLoaithuoc.TabIndex = 26;
            this.cmbLoaithuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLoaithuoc_KeyDown);
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label21.Location = new System.Drawing.Point(639, 425);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(63, 23);
            this.label21.TabIndex = 71;
            this.label21.Text = "Loại thuốc :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtnguongoc
            // 
            this.txtnguongoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtnguongoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtnguongoc.Enabled = false;
            this.txtnguongoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnguongoc.Location = new System.Drawing.Point(703, 470);
            this.txtnguongoc.MaxLength = 20;
            this.txtnguongoc.Name = "txtnguongoc";
            this.txtnguongoc.Size = new System.Drawing.Size(85, 21);
            this.txtnguongoc.TabIndex = 36;
            this.txtnguongoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLoaithuoc_KeyDown);
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label22.Location = new System.Drawing.Point(639, 469);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(75, 23);
            this.label22.TabIndex = 70;
            this.label22.Text = "Nguồn gốc :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtChaogia
            // 
            this.txtChaogia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChaogia.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtChaogia.Enabled = false;
            this.txtChaogia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChaogia.Location = new System.Drawing.Point(909, 448);
            this.txtChaogia.MaxLength = 10;
            this.txtChaogia.Name = "txtChaogia";
            this.txtChaogia.Size = new System.Drawing.Size(71, 21);
            this.txtChaogia.TabIndex = 31;
            this.txtChaogia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLoaithuoc_KeyDown);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.Location = new System.Drawing.Point(788, 448);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(132, 21);
            this.label16.TabIndex = 114;
            this.label16.Text = "STT trong DM chào giá:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSTT12
            // 
            this.txtSTT12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSTT12.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtSTT12.Enabled = false;
            this.txtSTT12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSTT12.Location = new System.Drawing.Point(703, 448);
            this.txtSTT12.MaxLength = 10;
            this.txtSTT12.Name = "txtSTT12";
            this.txtSTT12.Size = new System.Drawing.Size(85, 21);
            this.txtSTT12.TabIndex = 30;
            this.txtSTT12.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLoaithuoc_KeyDown);
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label23.Location = new System.Drawing.Point(610, 448);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(95, 21);
            this.label23.TabIndex = 116;
            this.label23.Text = "STT trong DM 12:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label24.Location = new System.Drawing.Point(457, 428);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(90, 18);
            this.label24.TabIndex = 117;
            this.label24.Text = "Ngày cấp SĐK:";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNgaycapSDK
            // 
            this.txtNgaycapSDK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNgaycapSDK.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtNgaycapSDK.Enabled = false;
            this.txtNgaycapSDK.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgaycapSDK.Location = new System.Drawing.Point(546, 426);
            this.txtNgaycapSDK.Mask = "##/##/####";
            this.txtNgaycapSDK.MaxLength = 10;
            this.txtNgaycapSDK.Name = "txtNgaycapSDK";
            this.txtNgaycapSDK.Size = new System.Drawing.Size(64, 21);
            this.txtNgaycapSDK.TabIndex = 25;
            this.txtNgaycapSDK.Text = "  /  /    ";
            this.txtNgaycapSDK.Validated += new System.EventHandler(this.txtNgaycapSDK_Validated);
            this.txtNgaycapSDK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLoaithuoc_KeyDown);
            // 
            // chkVtyt
            // 
            this.chkVtyt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkVtyt.Enabled = false;
            this.chkVtyt.Location = new System.Drawing.Point(464, 492);
            this.chkVtyt.Name = "chkVtyt";
            this.chkVtyt.Size = new System.Drawing.Size(127, 19);
            this.chkVtyt.TabIndex = 118;
            this.chkVtyt.Text = "VTYT";
            // 
            // chkSinhpham
            // 
            this.chkSinhpham.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSinhpham.Enabled = false;
            this.chkSinhpham.Location = new System.Drawing.Point(4, 493);
            this.chkSinhpham.Name = "chkSinhpham";
            this.chkSinhpham.Size = new System.Drawing.Size(78, 19);
            this.chkSinhpham.TabIndex = 119;
            this.chkSinhpham.Text = "Sinh phẩm";
            this.chkSinhpham.CheckedChanged += new System.EventHandler(this.chkSinhpham_CheckedChanged);
            // 
            // butImpExcel
            // 
            this.butImpExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butImpExcel.Image = ((System.Drawing.Image)(resources.GetObject("butImpExcel.Image")));
            this.butImpExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butImpExcel.Location = new System.Drawing.Point(773, 533);
            this.butImpExcel.Name = "butImpExcel";
            this.butImpExcel.Size = new System.Drawing.Size(88, 25);
            this.butImpExcel.TabIndex = 120;
            this.butImpExcel.Text = "Imp_Excel";
            this.butImpExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butImpExcel.UseVisualStyleBackColor = true;
            this.butImpExcel.Click += new System.EventHandler(this.butImpExcel_Click);
            // 
            // frmDmbd
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(984, 577);
            this.Controls.Add(this.butImpExcel);
            this.Controls.Add(this.chkSinhpham);
            this.Controls.Add(this.chkVtyt);
            this.Controls.Add(this.chkVac);
            this.Controls.Add(this.kythuat);
            this.Controls.Add(this.bhyt);
            this.Controls.Add(this.stt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.phattron);
            this.Controls.Add(this.txtSttByt);
            this.Controls.Add(this.txtStt02);
            this.Controls.Add(this.txtSttVB);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtChaogia);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.sodk);
            this.Controls.Add(this.txtNgaycapSDK);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.tencc);
            this.Controls.Add(this.chkkhongcungchitra);
            this.Controls.Add(this.txtnguongoc);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.cmbLoaithuoc);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.chkTreem);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.lmadoituong);
            this.Controls.Add(this.txtmaatc);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.listThuoc);
            this.Controls.Add(this.chktt11);
            this.Controls.Add(this.chktt10);
            this.Controls.Add(this.chkketoa);
            this.Controls.Add(this.cbdungluc);
            this.Controls.Add(this.sltoithieu);
            this.Controls.Add(this.listdonggoi);
            this.Controls.Add(this.ngaytra);
            this.Controls.Add(this.butNhatky);
            this.Controls.Add(this.butToithieu);
            this.Controls.Add(this.choduyet);
            this.Controls.Add(this.donvisudung);
            this.Controls.Add(this.duongdung);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.chenhlech);
            this.Controls.Add(this.sldonggoi);
            this.Controls.Add(this.donvi);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.sotk);
            this.Controls.Add(this.hide);
            this.Controls.Add(this.tyle);
            this.Controls.Add(this.dang);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.maloai);
            this.Controls.Add(this.macc);
            this.Controls.Add(this.manuoc);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.listNhacc);
            this.Controls.Add(this.butNo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.find);
            this.Controls.Add(this.listNhomin);
            this.Controls.Add(this.manhom);
            this.Controls.Add(this.nhombo);
            this.Controls.Add(this.nhomin);
            this.Controls.Add(this.lNhomin);
            this.Controls.Add(this.butSTT);
            this.Controls.Add(this.butTD);
            this.Controls.Add(this.butKemtheo);
            this.Controls.Add(this.lphantram);
            this.Controls.Add(this.phatsau);
            this.Controls.Add(this.tutruc);
            this.Controls.Add(this.lngaytra);
            this.Controls.Add(this.soluong);
            this.Controls.Add(this.lsltoithieu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.listNhom);
            this.Controls.Add(this.listSotk);
            this.Controls.Add(this.listNhombo);
            this.Controls.Add(this.listNuoc);
            this.Controls.Add(this.listHang);
            this.Controls.Add(this.listDang);
            this.Controls.Add(this.ma);
            this.Controls.Add(this.thietyeu);
            this.Controls.Add(this.mahang);
            this.Controls.Add(this.hamluong);
            this.Controls.Add(this.lSoluong);
            this.Controls.Add(this.lNuoc);
            this.Controls.Add(this.lHang);
            this.Controls.Add(this.lPhanloai);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tenhc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listHC);
            this.Controls.Add(this.lSotk);
            this.Controls.Add(this.lNhombo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.sunghiep);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.listDD);
            this.Controls.Add(this.listLoai);
            this.Controls.Add(this.txtgeneric);
            this.Controls.Add(this.tenhc1);
            this.Controls.Add(this.txtStt);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtSTT12);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.lBhyt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDmbd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục vật tư, sản phẩm, hàng hóa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDmbd_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDmbd_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngaytra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmDmbd_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = d.user; itable = d.tableid("", "d_dmbd");
            //
            f_capnhat_db();
            //
            bBhyt_admin = d.bBhyt_admin(i_nhom);
            bChenhlech_thuoc_dannhmuc = d.bChenhlech_thuoc_dannhmuc;
			bNhacc=d.bNhacc_dmbd(i_nhom);
			bPhattron=d.bPhattron(i_nhom);
			bNhomin_mabd=d.bNhomin_mabd(i_nhom);
            bMabd_doituong = d.bMabd_doituong(i_nhom);
			butNo.Visible=!d.bMabd;
			//if (!bNhomin_mabd) this.nhombo.Size = new System.Drawing.Size(264, 21);
			lBhyt.Visible=i_thuoc==1;
			if (!lBhyt.Visible)
			{
				bhyt.Visible=lBhyt.Visible;
				lSoluong.Visible=lBhyt.Visible;
				soluong.Visible=lBhyt.Visible;
				lsltoithieu.Visible=lBhyt.Visible;
				sltoithieu.Visible=lBhyt.Visible;
				lngaytra.Visible=lBhyt.Visible;
				ngaytra.Visible=lBhyt.Visible;
				//phatsau.Visible=lBhyt.Visible;
				tutruc.Visible=lBhyt.Visible;
				thietyeu.Visible=lBhyt.Visible;
			}
			if (lSoluong.Visible)
			{
				lSoluong.Visible=bPhattron;
				soluong.Visible=lSoluong.Visible;
			}
            lmadoituong.Visible = bMabd_doituong;
            madoituong.Visible = bMabd_doituong;
            //sunghiep.Visible = !bMabd_doituong;
            thietyeu.Visible = !bMabd_doituong;
			butKemtheo.Enabled=bgiaban;
			//ltyle.Visible=!lBhyt.Visible;//linh
			//tyle.Visible=ltyle.Visible;//linh
			//lphantram.Visible=ltyle.Visible;//linh
			iNgaytra=d.Ngaylanh_Ngaytra;
            madoituong.DisplayMember = "DOITUONG";
            madoituong.ValueMember = "MADOITUONG";
            madoituong.DataSource = d.get_data("select * from " + user + ".d_doituong order by madoituong").Tables[0];
            //
            cbdungluc.DisplayMember = "TEN";
            cbdungluc.ValueMember = "ID";
            cbdungluc.DataSource = d.get_data("select * from " + user + ".d_dmthoidiemdung order by stt").Tables[0];
            //
			bhyt.DisplayMember="CHITRA";
			bhyt.ValueMember="CHITRA";

			listHC.DisplayMember="TEN";
			listHC.ValueMember="TEN";

			listNhom.DisplayMember="TEN";
			listNhom.ValueMember="TEN";

			listNhacc.DisplayMember="MA";
			listNhacc.ValueMember="TEN";

			listLoai.DisplayMember="TEN";
			listLoai.ValueMember="TEN";

			listHang.DisplayMember="TEN";
			listHang.ValueMember="TEN";

			listNuoc.DisplayMember="TEN";
			listNuoc.ValueMember="TEN";

			listNhombo.DisplayMember="TEN";
			listNhombo.ValueMember="TEN";

			listNhomin.DisplayMember="TEN";
			listNhomin.ValueMember="TEN";

			listSotk.DisplayMember="TEN";
			listSotk.ValueMember="TEN";

			listDang.DisplayMember="TEN";
			listDang.ValueMember="TEN";

            listdonggoi.DisplayMember = "TEN";
            listdonggoi.ValueMember = "TEN";

			listDD.DisplayMember="TEN";
			listDD.ValueMember="TEN";
            // hien 23-05-2011
            cmbLoaithuoc.DisplayMember = "TEN";
            cmbLoaithuoc.ValueMember = "ID";
            cmbLoaithuoc.DataSource = d.get_data("select * from " + user + ".d_dmloaithuoc order by id").Tables[0];
            //end hien
            //TU:04/05/2011
            listThuoc.DisplayMember = "TEN";
            listThuoc.ValueMember = "TEN";
            
            //END TU

			load_dm();
			//dataGrid1.Height=(d.bHoatchat)?339:363;
			load_grid();
			AddGridTableStyle();
			ref_text(0);
		}

        private void load_dm()
        {
            bhyt.DataSource = d.get_data("select * from " + user + ".d_dmbhyt order by stt").Tables[0];
            sql = "select * from " + user + ".d_dmnhom where nhom=" + i_nhom;
            if (s_manhom != "") sql += " and id in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
            sql += " order by stt";
            dtnhom = d.get_data(sql).Tables[0];
            dtloai = d.get_data("select * from " + user + ".d_dmloai where nhom=" + i_nhom + " order by stt").Tables[0];
            dthang = d.get_data("select * from " + user + ".d_dmhang where nhom=" + i_nhom + " order by stt").Tables[0];
            dtnuoc = d.get_data("select * from " + user + ".d_dmnuoc where nhom=" + i_nhom + " order by stt").Tables[0];
            dtnhombo = d.get_data("select * from " + user + ".d_nhombo where nhom=" + i_nhom + " order by stt").Tables[0];
            dtnhomin = d.get_data("select * from " + user + ".d_nhomin where nhom=" + i_nhom + " order by stt").Tables[0];
            dtsotk = d.get_data("select id,ten,ma from " + user + ".d_dmnhomkt where nhom=" + i_nhom + " order by stt").Tables[0];
            listDang.DataSource = d.get_data("select * from " + user + ".d_dmdvt order by stt").Tables[0];
            listdonggoi.DataSource = d.get_data("select * from " + user + ".d_dmdonggoi order by stt").Tables[0];
            dtdd = d.get_data("select viettat,ten,route from " + user + ".d_dmduongdung order by stt").Tables[0];
            listDD.DataSource = dtdd;
            dtatc_hoatchat = d.get_data("select * from " + user + ".d_dmhoatchat ").Tables[0];
            //dthc = d.get_data("select * from " + user + ".d_dmhoatchat where nhom=" + i_nhom + " order by ten").Tables[0];
            dthc = d.get_data("select ma, ten from " + user + ".d_dmhoatchat order by ten").Tables[0];
            dtcc = d.get_data("select ma,ten,id from " + user + ".d_dmnx where nhom=" + i_nhom + " and hide=0 order by ten").Tables[0];
            try
            {
                //dtthuoc = d.get_data("select a.id,a.ten,dang,hamluong,duongdung,a.atc,a.generic,a.tenhc,b.ten as tennhom,c.ten as tenloai,d.ten as nhombo "
                //+ "from medibv.d_dmthuoc a left join medibv.d_dmnhom b on a.nhom_bc=b.id_medisoft left join medibv.d_dmloai c on a.loai_bc=c.id_medisoft left join "
                //+ "medibv.d_nhombo d on a.nhom_bo=d.id_medisoft").Tables[0];
                dtthuoc = d.get_data("select a.id,a.ten,dang,hamluong,duongdung,a.atc,a.generic,a.tenhc,b.ten as tennhom,c.ten as tenloai,d.ten as nhombo "
                + "from medibv.d_dmthuoc a left join medibv.d_dmnhom_medisoft b on a.nhom_bc=b.id left join medibv.d_dmloai_medisoft c on a.loai_bc=c.id left join "
                + "medibv.d_nhombo_medisoft d on a.nhom_bo=d.id").Tables[0];
            }
            catch
            {
                d.execute_data("alter table " + user + ".d_dmthuoc add hamluong varchar(20);");
                d.execute_data("alter table " + user + ".d_dmthuoc add duongdung text;");
                d.execute_data("alter table " + user + ".d_dmthuoc add generic text;");
                d.execute_data("alter table " + user + ".d_dmthuoc add atc text;");
                d.execute_data("alter table " + user + ".d_dmthuoc add nhom_bo numeric(3) default 0;");
                d.execute_data("alter table " + user + ".d_dmthuoc add nhom_bc numeric(3) default 0;");
                d.execute_data("alter table " + user + ".d_dmthuoc add loai_bc numeric(3) default 0;");

                d.execute_data("alter table " + user + ".d_dmnhom add id_medisoft numeric(3)");
                d.execute_data("alter table " + user + ".d_dmloai add id_medisoft numeric(3)");
                d.execute_data("alter table " + user + ".d_nhombo add id_medisoft numeric(3)");

                //dtthuoc = d.get_data("select a.id,a.ten,dang,hamluong,duongdung,a.atc,a.generic,a.tenhc,b.ten as tennhom,c.ten as tenloai,d.ten as nhombo "
                //+ " from medibv.d_dmthuoc a,medibv.d_dmnhom b,medibv.d_dmloai c,medibv.d_nhombo d "
                //+ " where a.nhom_bc=b.id_medisoft(+) and a.loai_bc=c.id_medisoft(+) and a.nhom_bo=d.id_medisoft(+)").Tables[0];
                dtthuoc = d.get_data("select a.id,a.ten,dang,hamluong,duongdung,a.atc,a.generic,a.tenhc,b.ten as tennhom,c.ten as tenloai,d.ten as nhombo" +
            " from medibv.d_dmthuoc a left join medibv.d_dmnhom_medisoft b on a.nhom_bc=b.id left join medibv.d_dmloai_medisoft c on a.loai_bc=c.id" +
            " left join medibv.d_nhombo_medisoft d on a.nhom_bo=d.id").Tables[0];
            }
            listThuoc.DataSource = dtthuoc;
            listHC.DataSource = dthc;
            listSotk.DataSource = dtsotk;
            listNhombo.DataSource = dtnhombo;
            listNhomin.DataSource = dtnhomin;
            listNuoc.DataSource = dtnuoc;
            listHang.DataSource = dthang;
            listLoai.DataSource = dtloai;
            listNhom.DataSource = dtnhom;
            listNhacc.DataSource = dtcc;
            //
            f_Load_Kythuatcao();
        }

		private void load_grid()
		{
			sql="select a.*,trim(a.ten)||' '||a.hamluong as tenbd,b.ten as tennhom,nullif(c.ten,' ') as tenloai,nullif(d.ten,' ') as tenhang,nullif(e.ten,' ') as tennuoc,nullif(f.ten,' ') as tenbo,nullif(g.ten,' ') as nhomkt,nullif(h.ten,' ') as tenin,nullif(i.ten,' ') as tennx, ";
            sql += "to_char(a.ngaycapsdk,'dd/mm/yyyy') as ngaycap_sdk";
            sql += " from " + user + ".d_dmbd a left join " + user + ".d_dmnhom b on a.manhom=b.id left join " + user + ".d_dmloai c ";
            sql += " on a.maloai=c.id left join " + user + ".d_dmhang d on a.mahang=d.id left join " + user + ".d_dmnuoc e ";
            sql += " on a.manuoc=e.id left join " + user + ".d_nhombo f on a.nhombo=f.id left join " + user + ".d_dmnhomkt g ";
            sql += " on a.sotk=g.id left join "+user + ".d_nhomin h on a.nhomin=h.id left join " + user + ".d_dmnx i ";
            sql += " on a.madv=i.id where a.nhom="+i_nhom+" and a.hide<>-1";
			if (s_manhom!="") sql+=" and a.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			sql+=" order by ";
			if (d.bSort_mabd) sql+=" a.ma";
			else sql+="a.ten";
			dt=d.get_data(sql).Tables[0];
			dataGrid1.DataSource=dt;
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dt.TableName;
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
			TextCol.MappingName = "id";
			TextCol.HeaderText = "ID";
			TextCol.Width = 40;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "stt";
			TextCol.HeaderText = "Stt";
			TextCol.Width = 40;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenhc";
			TextCol.HeaderText = "Hoạt chất";
			TextCol.Width = (d.bHoatchat)?200:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã";
			TextCol.Width = 53;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenbd";
			TextCol.HeaderText = "Tên";
			TextCol.Width = 200;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "donvi";
            TextCol.HeaderText = "Đóng gói";
            TextCol.Width = 50;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tennhom";
			TextCol.HeaderText = "Nhóm";
			TextCol.Width = 250;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenloai";
			TextCol.HeaderText = "Loại";
			TextCol.Width = 200;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenhang";
			TextCol.HeaderText = "Hãng";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tennuoc";
			TextCol.HeaderText = "Nước";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenin";
			TextCol.HeaderText = (bNhomin_mabd)?"Phiếu in":"";
			TextCol.Width = (bNhomin_mabd)?150:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenbo";
			TextCol.HeaderText = "Dược bệnh viện";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tennx";
			TextCol.HeaderText = "Nhà cung cấp";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "bhyt";
            TextCol.HeaderText = "BHYT";
            TextCol.Width = 50;
            TextCol.Alignment = HorizontalAlignment.Right;
            TextCol.Format = "###.##";
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "duongdung";
            TextCol.HeaderText = "Đường dùng";
            TextCol.Width = 150;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "mathoidiemdung";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void ten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listThuoc.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listThuoc.Visible) listThuoc.Focus();
                else SendKeys.Send("{Tab}");
            }
		}

		private void ena_object(bool ena)
		{
            txtSttByt.Enabled = ena;
            txtnguongoc.Enabled = ena;
            cmbLoaithuoc.Enabled = ena;
            chkTreem.Enabled = ena;
			if (!d.bMabd) ma.Enabled=ena;
			ten.Enabled=ena;
			if (d.bHoatchat) tenhc.Enabled=ena;
			dataGrid1.Enabled=!ena;
            
			hamluong.Enabled=ena;
			dang.Enabled=ena;            
            donvi.Enabled = ena;
            sldonggoi.Enabled = ena;
			stt.Enabled=ena;
			manhom.Enabled=ena;
			maloai.Enabled=ena;
			mahang.Enabled=ena;
			manuoc.Enabled=ena;
            bhyt.Enabled = ena;
			sodk.Enabled=ena;
            donvisudung.Enabled = ena;
			sltoithieu.Enabled=ena;
            chkkhongcungchitra.Enabled = ena;
            if (bChenhlech_thuoc_dannhmuc) chenhlech.Enabled = ena;
            if (bMabd_doituong) madoituong.Enabled = ena;
            else
            {
                sunghiep.Enabled = ena;
                thietyeu.Enabled = ena;
            }
            choduyet.Enabled=phattron.Enabled = ena;
            kythuat.Enabled = ena;
            hide.Enabled = ena;
			duongdung.Enabled=ena;
			if (bNhacc)
			{
				macc.Enabled=ena;
				tencc.Enabled=ena;
			}
			if (butNo.Visible) butNo.Enabled=ena;
			if (bNhomin_mabd) nhomin.Enabled=ena;
			if (d.bNhombc) nhombo.Enabled=ena;
			if (d.bNhomkt) sotk.Enabled=ena;
			if (tyle.Visible) tyle.Enabled=ena;
            //
            cbdungluc.Enabled = ena;
            //cbKythuatcao.Enabled = ena;//linh
            cbdungluc.Enabled = ena;
            chkketoa.Enabled = ena;
            //
			butSTT.Enabled=ena;
			ngaytra.Enabled=ena;
			tutruc.Enabled=ena;
			phatsau.Enabled=ena;
			soluong.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			if (bgiaban) butKemtheo.Enabled=!ena;             
			butToithieu.Enabled=butTD.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
            chktt10.Enabled = ena;
            chktt11.Enabled = ena;
            chkVac.Enabled = ena;
            chkSinhpham.Enabled = ena;
            txtStt02.Enabled = ena;
            //linh
            //txtSTT05.Enabled = ena;
            txtSTT12.Enabled = ena;
            txtChaogia.Enabled = ena;
            txtNgaycapSDK.Enabled = ena;
            txtSttVB.Enabled = ena;
            chkVtyt.Enabled = ena;
			if (!ena) butMoi.Focus();
			else
			{
				if (d.bDanhmuc)
				{
					d.writeXml("d_thongso","c01","0");
					load_dm();
				}
			}
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
            bNew = true;
			l_id=0;
			try
			{
				DataTable tmp=d.get_data("select max(stt) as stt from "+user+".d_dmbd where nhom="+i_nhom).Tables[0];
				if (tmp.Rows[0]["stt"].ToString()!="")
					stt.Value=int.Parse(tmp.Rows[0]["stt"].ToString())+1;
			}
			catch{stt.Value=1;}
			ma.Text="";
			ten.Text="";
			tenhc.Text="";
			manhom.Text="";
			maloai.Text="";
			mahang.Text="";
			manuoc.Text="";
			nhombo.Text="";
			nhomin.Text="";
			sotk.Text="";
			macc.Text="";
			tencc.Text="";
			soluong.Text="1";
            sldonggoi.Text = "";
			sodk.Text="";
			sltoithieu.Text="";
			dang.Text="";
            donvi.Text = "";
			tyle.Text="0";
			bhyt.SelectedValue="100";
			hamluong.Text="";
            //linh
            txtSTT12.Text = "";
            txtChaogia.Text = "";
            txtNgaycapSDK.Text = "";
            txtSttVB.Text = "";
            chkVtyt.Checked = false;
            //end linh
			choduyet.Checked=chenhlech.Checked=kythuat.Checked=tutruc.Checked=phatsau.Checked=phattron.Checked = hide.Checked = false;
            if (bMabd_doituong) madoituong.SelectedIndex = -1;
            //else
            //{
                thietyeu.Checked = false;
                sunghiep.Checked = false;
            //}
            cbdungluc.SelectedIndex = -1;
			duongdung.Text="";
			ngaytra.Value=iNgaytra;
            ena_object(true);
			if (ma.Enabled) ma.Focus();
			else ten.Focus();
            //else if (tenhc.Enabled) tenhc.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
            bNew = false;
			if (dt.Rows.Count==0) return;
			l_id=decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,0].ToString());
			ref_text(l_id);
			ena_object(true);
            //try
            //{
            //    chkkhongcungchitra.Enabled = decimal.Parse(bhyt.Text) == 100;
            //}
            //catch { }
			if (!bAdmin)
			{
                if (d.get_data("select * from " + user + ".d_dmbd_sudung where mabd=" + l_id).Tables[0].Rows.Count != 0)
				{
					tenhc.Enabled=false;ten.Enabled=false;dang.Enabled=false;
					hamluong.Enabled=false;mahang.Enabled=false;manuoc.Enabled=false;
				}
			}
			ma.Enabled=false;
            if (bBhyt_admin) bhyt.Enabled = bAdmin;
			ten.Focus();
		}

		private bool Exist(string ten,string hamluong,string dang,string manuoc,string mahang)
		{
			r=d.getrowbyid(dt,"tenbd='"+ten+" "+hamluong+"' and dang='"+dang+"' and tennuoc='"+manuoc+"' and tenhang='"+mahang+"'");
			return r!=null;
		}

		private bool kiemtra()
		{
			if (l_id==0)
			{
				if (Exist(ten.Text.Trim(),hamluong.Text.Trim(),dang.Text.Trim(),manuoc.Text.Trim(),mahang.Text.Trim()))
				{
					MessageBox.Show(lan.Change_language_MessageText("Đã tồn tại tên :")+" "+ten.Text.Trim()+" "+hamluong.Text+" "+lan.Change_language_MessageText("Dạng :")+" "+dang.Text+" "+lan.Change_language_MessageText("Nước sx :")+" "+manuoc.Text+" "+lan.Change_language_MessageText("Tên hãng:")+" "+mahang.Text,d.Msg);
					ten.Focus();
					return false;
				}
			}
			if (ma.Enabled)
			{
				if (ma.Text=="")
				{
					ma.Focus();
					return false;
				}
			}
			if (ten.Text=="")
			{
				ten.Focus();
				return false;
			}
			if (manhom.Text.Trim()=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn nhóm !"),d.Msg);
				manhom.Focus();
				return false;
			}
			else 
			{
				r=d.getrowbyid(dtnhom,"ten='"+manhom.Text.Trim()+"'");
				if (r==null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhóm không hợp lệ!"),d.Msg);
					manhom.Focus();
					return false;
				}
				else iNhom=int.Parse(r["id"].ToString());
			}
			if (maloai.Text.Trim()=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn loại !"),d.Msg);
				maloai.Focus();
				return false;
			}
			else 
			{
				r=d.getrowbyid(dtloai,"ten='"+maloai.Text.Trim()+"'");
				if (r==null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Loại không hợp lệ!"),d.Msg);
					maloai.Focus();
					return false;
				}
				else iLoai=int.Parse(r["id"].ToString());
			}
			if (mahang.Text.Trim()=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn hãng !"),d.Msg);
				mahang.Focus();
				return false;
			}
			else 
			{
				r=d.getrowbyid(dthang,"ten='"+mahang.Text.Trim()+"'");
				if (r==null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Hãng không hợp lệ!"),d.Msg);
					mahang.Focus();
					return false;
				}
				else iHang=int.Parse(r["id"].ToString());
			}
			if (manuoc.Text.Trim()=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn nước !"),d.Msg);
				manuoc.Focus();
				return false;
			}
			else 
			{
				r=d.getrowbyid(dtnuoc,"ten='"+manuoc.Text.Trim()+"'");
				if (r==null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Nước không hợp lệ!"),d.Msg);
					manuoc.Focus();
					return false;
				}
				else iNuoc=int.Parse(r["id"].ToString());
			}
            if (donvisudung.Text.Trim() == "") donvisudung.Text = dang.Text;
			if (sotk.Enabled)
			{
				if (sotk.Text.Trim()=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Chọn nhóm kế toán !"),d.Msg);
					sotk.Focus();
					return false;
				}
				else 
				{
					r=d.getrowbyid(dtsotk,"ten='"+sotk.Text.Trim()+"'");
					if (r==null)
					{
						MessageBox.Show(lan.Change_language_MessageText("Nhóm kế toán không hợp lệ!"),d.Msg);
						sotk.Focus();
						return false;
					}
					else iSotk=int.Parse(r["id"].ToString());
				}
			}
            //else
            //{
            //    if (sotk.Text.Trim()=="") iSotk=0;
            //    else
            //    {
            //        r=d.getrowbyid(dtsotk,"ten='"+sotk.Text.Trim()+"'");
            //        if (r==null)
            //        {
            //            MessageBox.Show(lan.Change_language_MessageText("Nhóm kế toán không hợp lệ!"),d.Msg);
            //            sotk.Focus();
            //            return false;
            //        }
            //        else iSotk=int.Parse(r["id"].ToString());
            //    }
            //}
			if (nhombo.Enabled)
			{
				if (nhombo.Text.Trim()=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Chọn nhóm báo cáo !"),d.Msg);
					nhombo.Focus();
					return false;
				}
				else 
				{
					r=d.getrowbyid(dtnhombo,"ten='"+nhombo.Text.Trim()+"'");
					if (r==null)
					{
						MessageBox.Show(lan.Change_language_MessageText("Nhóm báo cáo không hợp lệ!"),d.Msg);
						nhombo.Focus();
						return false;
					}
					else iNhombo=int.Parse(r["id"].ToString());
				}
			}
			else
			{
				if (nhombo.Text.Trim()=="") iNhombo=0;
				else
				{
					r=d.getrowbyid(dtnhombo,"ten='"+nhombo.Text.Trim()+"'");
					if (r==null)
					{
						MessageBox.Show(lan.Change_language_MessageText("Nhóm báo cáo không hợp lệ!"),d.Msg);
						nhombo.Focus();
						return false;
					}
					else iNhombo=int.Parse(r["id"].ToString());
				}
			}
			i_nhacc=0;
			if (bNhacc)
			{
				if (macc.Text=="" || tencc.Text.Trim()=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Chọn nhà cung cấp !"),d.Msg);
					macc.Focus();
					return false;
				}
				r=d.getrowbyid(dtcc,"ma='"+macc.Text.Trim()+"'");
				if (r!=null) i_nhacc=int.Parse(r["id"].ToString());
			}
			if (nhomin.Enabled)
			{
				if (nhomin.Text.Trim()=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Chọn nhóm in phiếu !"),d.Msg);
					nhomin.Focus();
					return false;
				}
				else 
				{
					r=d.getrowbyid(dtnhomin,"ten='"+nhomin.Text.Trim()+"'");
					if (r==null)
					{
						MessageBox.Show(lan.Change_language_MessageText("Nhóm in phiếu không hợp lệ!"),d.Msg);
						nhomin.Focus();
						return false;
					}
					else iNhomin=int.Parse(r["id"].ToString());
				}
			}
			else iNhomin=0;
			if (soluong.Text=="" || soluong.Text=="0") soluong.Text="1";
            if (tenhc.Text != "")//Thuy 18.03.2013 .Ktra mặt hang có khai hoạt chất thì bắt buột nhập đường dùng mới cho lưu
            {
                if (duongdung.Text.Trim() == "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Vui lòng nhập đường dùng!"), d.Msg);
                    duongdung.Focus();
                    return false;
                }
            }
			return true;
		}

		private string getMahc(string s)
		{
			string s2=s+"+",s3="",mahc="",ma="";
			int len=s2.Length;
			for(int i=0;i<len;i++)
			{
				if (s2.Substring(i,1)=="+")
				{
					r=d.getrowbyid(dthc,"ten='"+s3.Trim()+"'");
					if (r==null)
					{
						ma=d.getMabd("d_dmhoatchat",s3,i_nhom);
						mahc+=ma+"+";
						d.upd_dmhoatchat(ma,s3.Trim(),i_nhom);
						if (!d.bDanhmuc) d.writeXml("d_thongso","c01","1");
					}
					else mahc+=r["ma"].ToString()+"+";
					s3="";
				}
				else s3+=s2.Substring(i,1);
			}
			return mahc;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return ;
            if (bNew)//Tu:21/05/2011
            {
                if (ma.Text == "") ma.Text = d.getMabd("d_dmbd", ten.Text, i_nhom);
                if (l_id == 0)
                {
                    d.upd_eve_tables(itable, i_userid, "ins");
                    DataRow r = d.getrowbyid(dt, "ma='" + ma.Text + "'");
                    if (r != null)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Mã mặt hàng đã tồn tại !"), d.Msg);
                        if (!ma.Enabled) ma.Enabled = true;
                        ma.Focus();
                        return;
                    }
                    l_id = d.get_id_dmbd;
                    //hien them: sửa lại id = id_chinhanh + id;
                    //l_id = decimal.Parse(d.i_Chinhanh_hientai.ToString() + "5" + l_id.ToString().PadLeft(5, '0'));
                    //end hien
                }
                else
                {
                    d.upd_eve_tables(itable, i_userid, "upd");
                    d.upd_eve_upd_del(itable, i_userid, "upd", d.fields(user + ".d_dmbd", "id=" + l_id));
                    d.upd_dmbd_luu(l_id);
                }
            }//end Tu
			if (!d.upd_dmbd(l_id,ma.Text,ten.Text,dang.Text,hamluong.Text,iNhom,iLoai,iHang,iNuoc,iNhombo,decimal.Parse(bhyt.SelectedValue.ToString()),
                (thietyeu.Checked)?1:0,iSotk,tenhc.Text,getMahc(tenhc.Text),int.Parse(soluong.Text),i_nhom,sodk.Text,
                (sltoithieu.Text=="")?0:decimal.Parse(sltoithieu.Text),Convert.ToInt16(ngaytra.Value),(tutruc.Checked)?1:0,(phatsau.Checked)?1:0,
                (tyle.Text!="")?decimal.Parse(tyle.Text):0,stt.Value,"",iNhomin,(sunghiep.Checked)?1:0,duongdung.Text,"",i_nhacc,donvi.Text,
                (sldonggoi.Text!="")?decimal.Parse(sldonggoi.Text):0,donvisudung.Text,i_userid))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật thông tin")+" "+this.Text.Trim()+" !",d.Msg);
				return;
			}
            //Tu:21/05/2011
            // hien 23-05-2011
            if(!d.upd_dmbd(l_id,(chkTreem.Checked ? 1:0),txtnguongoc.Text,txtSttByt.Text,decimal.Parse(cmbLoaithuoc.SelectedValue.ToString())))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin loại thuốc"));
            }
            //end hien
            DataRow dr_thuoc = d.getrowbyid(dtthuoc,"ten='"+ten.Text.Trim()+"'");
            if (dr_thuoc == null)
            {
                decimal i_id_dmthuoc = 1;
                try { i_id_dmthuoc = decimal.Parse(d.get_data("select (max(id)+1) from " + user + ".d_dmthuoc").Tables[0].Rows[0][0].ToString()); }
                catch { i_id_dmthuoc = 1; }
                int i_nhom_bc = 0, i_loai_bc = 0, i_nhom_bo = 0;
                try { i_nhom_bc = int.Parse(d.get_data("select id_medisoft from " + user + ".d_dmnhom where id=" + iNhom + "").Tables[0].Rows[0][0].ToString()); }
                catch { i_nhom_bc = 10; }
                try { i_loai_bc = int.Parse(d.get_data("select id_medisoft from " + user + ".d_dmloai where id=" + iLoai + "").Tables[0].Rows[0][0].ToString()); }
                catch { i_loai_bc = 96; }
                try { i_nhom_bo = int.Parse(d.get_data("select id_medisoft from " + user + ".d_nhombo where id=" + iNhombo + "").Tables[0].Rows[0][0].ToString()); }
                catch { i_nhom_bo = 26; }
                if (!d.upd_dmthuoc(i_id_dmthuoc, ten.Text, dang.Text, "", tenhc.Text, i_nhom_bc, i_loai_bc, i_nhom_bo, txtgeneric.Text, txtmaatc.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật thông tin") + " " + this.Text.Trim() + " !", d.Msg);
                    return;
                }
            }
            //end Tu
            if (madoituong.Visible) d.execute_data("update " + user + ".d_dmbd set madoituong=" + ((madoituong.SelectedIndex!=-1) ? int.Parse(madoituong.SelectedValue.ToString()) : 0) + " where id=" + l_id);
            if (bChenhlech_thuoc_dannhmuc) d.execute_data("update " + user + ".d_dmbd set chenhlech=" + ((chenhlech.Checked) ? 1 : 0) + " where id=" + l_id);
			if (!d.bDmbd) d.writeXml("d_thongso","c06","1");
            if (txtSttByt.Text.Trim() == "")
            {
                txtSttByt.Text = "0";
            }
            d.execute_data("update " + user + ".d_dmbd set hide=" + ((hide.Checked) ? 1 : 0) + ",phattron=" + ((phattron.Checked) ? 1 : 0) + ",kythuat=" + ((kythuat.Checked) ? 1 : -1) + ",choduyet=" + ((choduyet.Checked) ? 1 : 0) + ", kcct=" + ((chkkhongcungchitra.Checked) ? "1" : "0") + "," +
                "ketoa=" + (chkketoa.Checked ? "1" : "0") + ", mathoidiemdung=" + ((cbdungluc.SelectedIndex < 0) ? "0" : cbdungluc.SelectedValue.ToString()) + "," +
                "sttvb='" + txtSttVB.Text.Trim() + "',stt05=" + txtSttByt.Text + "," +
                "stt02='" + txtStt02.Text.Trim() + "',tt10=" + ((chktt10.Checked) ? 1 : 0) + "," +
                "tt11=" + ((chktt11.Checked) ? 1 : 0) + ",vacxin=" + ((chkVac.Checked) ? 1 : 0) + ",stt_dm12='" + txtSTT12.Text.Trim() + "'," +
                "stt_chaohang='" + txtChaogia.Text.Trim() + "',vtyt=" + (chkVtyt.Checked ? "1" : "0") + " where id=" + l_id.ToString());
            if (txtNgaycapSDK.Text.Trim().Trim('/').Trim() != "")
            {
                d.execute_data("update " + user + ".d_dmbd set ngaycapsdk=to_date('" + txtNgaycapSDK.Text + "','dd/mm/yyyy') where id=" + l_id.ToString());
            }
			load_grid();
            if (find.Text != "Tìm kiếm") RefreshChildren(find.Text);	
			ena_object(false);
			ref_text(l_id);
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
			ref_text(0);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (dt.Rows.Count==1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cho phép hủy !"),d.Msg);
				return;
			}	
			try
			{
                if (d.get_data("select * from "+user+".d_dmbd_sudung where mabd=" + decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 0].ToString())).Tables[0].Rows.Count != 0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Nội dung đang sử dụng không cho phép hủy !"),d.Msg);
					return;
				}
			}
			catch{}
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này !"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
                d.upd_eve_tables(itable, i_userid, "del");
                d.upd_eve_upd_del(itable, i_userid, "del", d.fields(user + ".d_dmbd", "id=" + decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 0].ToString())));
                d.execute_data("delete from " + user + ".d_dmbd where id=" + decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 0].ToString()));
				if (!d.bDmbd) d.writeXml("d_thongso","c06","1");
				load_grid();
				ref_text(0);
			}
		}

		private void ref_text(decimal id)
		{
			try
			{
				if (id==0)
				{
					int i=dataGrid1.CurrentCell.RowNumber;
					r=d.getrowbyid(dt,"id="+decimal.Parse(dataGrid1[i,0].ToString()));
				}
				else r=d.getrowbyid(dt,"id="+id);
				if (r!=null)
				{
                    txtmaatc.Text = r["atc"].ToString();
					tenhc.Text=r["tenhc"].ToString();
					ma.Text=r["ma"].ToString();
					ten.Text=r["ten"].ToString();
					hamluong.Text=r["hamluong"].ToString();
					dang.Text=r["dang"].ToString();
                    donvi.Text = r["donvi"].ToString();
					manhom.Text=r["tennhom"].ToString();
					maloai.Text=r["tenloai"].ToString();
					mahang.Text=r["tenhang"].ToString();
					manuoc.Text=r["tennuoc"].ToString();
					sotk.Text=r["nhomkt"].ToString();
					nhombo.Text=r["tenbo"].ToString();
					nhomin.Text=r["tenin"].ToString();
					bhyt.SelectedValue=r["bhyt"].ToString();
                    txtStt02.Text = r["stt02"].ToString();
                    //linh
                    //txtSTT05.Text = r["stt05"].ToString();
                    txtNgaycapSDK.Text = r["ngaycap_sdk"].ToString();
                    txtChaogia.Text = r["stt_chaohang"].ToString();
                    txtSTT12.Text = r["stt_dm12"].ToString();
                    chkVtyt.Checked = (r["vtyt"].ToString() == "1") ? true : false;
                    //end
                    txtSttVB.Text = r["sttvb"].ToString();
                    chktt10.Checked = (r["tt10"].ToString() == "1") ? true : false;
                    chktt11.Checked = (r["tt11"].ToString() == "1") ? true : false;
                    chkVac.Checked = (r["vacxin"].ToString() == "1") ? true : false;
                    if (bMabd_doituong) madoituong.SelectedValue = r["madoituong"].ToString();
                    //else//linh
                    //{
                        thietyeu.Checked = (r["thietyeu"].ToString() == "1") ? true : false;
                        sunghiep.Checked = (r["sunghiep"].ToString() == "1") ? true : false;
                    //}
					tutruc.Checked=(r["tutruc"].ToString()=="1")?true:false;
					phatsau.Checked=(r["phatsau"].ToString()=="1")?true:false;					
                    phattron.Checked =(r["phattron"].ToString() == "1") ? true : false;
                    kythuat.Checked = (r["kythuat"].ToString() == "-1") ? false : true;//linh
                    hide.Checked = (r["hide"].ToString() == "1") ? true : false;
					soluong.Text=r["soluong"].ToString();
					sodk.Text=r["sodk"].ToString();
					duongdung.Text=r["duongdung"].ToString();
					sltoithieu.Text=r["sltoithieu"].ToString();
					ngaytra.Value=decimal.Parse(r["ngaytra"].ToString());
					stt.Value=decimal.Parse(r["stt"].ToString());
                    sldonggoi.Text = r["sldonggoi"].ToString();
                    donvisudung.Text = r["donvidung"].ToString();
					l_id=decimal.Parse(r["id"].ToString());
					if (tyle.Visible)
					{
						decimal dtyle=decimal.Parse(r["tyle"].ToString());
						tyle.Text=dtyle.ToString("##0.00");
					}
					macc.Text="";tencc.Text="";
					if (bNhacc)
					{
						DataRow r1=d.getrowbyid(dtcc,"id="+int.Parse(r["madv"].ToString()));
						if (r1!=null)
						{
							macc.Text=r1["ma"].ToString();
							tencc.Text=r1["ten"].ToString();
						}
					}
                    if (bChenhlech_thuoc_dannhmuc) chenhlech.Checked = r["chenhlech"].ToString() == "1";
                    choduyet.Checked = r["choduyet"].ToString() == "1";
                    chkkhongcungchitra.Checked = r["kcct"].ToString() == "1";
                    cbdungluc.SelectedValue = r["mathoidiemdung"].ToString();
                    //cbKythuatcao.SelectedIndex = (r["kythuat"].ToString().Trim() == "") ? 0 : int.Parse(r["kythuat"].ToString()) + 1;
                    chkketoa.Checked = r["ketoa"].ToString() == "1";
                    chkTreem.Checked = (r["sdte"].ToString() == "1");
                    txtnguongoc.Text = r["nguongoc"].ToString();
                    txtSttByt.Text = r["sttbyt"].ToString();
                    cmbLoaithuoc.SelectedValue = r["idloaithuoc"].ToString();
				}
			}
			catch (Exception ex){}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text(0);
		}

		private void frmDmbd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

		private void ma_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");	
		}

		private void ma_Validated(object sender, System.EventArgs e)
		{
			if (ma.Text!="")
			{
				r=d.getrowbyid(dt,"ma='"+ma.Text+"'");
				if (r!=null)
				{
					MessageBox.Show(
lan.Change_language_MessageText("Mã này đã nhập !"),d.Msg);
					ma.Focus();
					return;
				}
				if (ten.Text=="") ten.Text=ma.Text;
			}
		}

		private void hamluong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void bhyt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void soluong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void thietyeu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void soluong_Validated(object sender, System.EventArgs e)
		{
			try
			{
				int iSoluong=int.Parse(soluong.Text);
				if (iSoluong==0) soluong.Text="1";
			}
			catch{soluong.Text="1";}
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

        private void Filter1(string ten)//,LibList.List list
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listThuoc.DataSource];
				DataView dv=(DataView)cm.List;
				//dv.RowFilter="ten like '%"+ten.Trim()+"%'";
                dv.RowFilter = "ten like'" + ten.Trim() + "%'";
			}
			catch{}
		}

		private void tenhc_TextChanged(object sender, System.EventArgs e)
		{
            if (this.ActiveControl == tenhc)
            {
                //tenhc.Text = tenhc.Text.Trim();
                string s = tenhc.Text;
                if (tenhc.Text == "")
                {
                    pos = 0;
                    tenhc1.Text = "";
                }
                try
                {
                    if (s.Substring(s.Length - 1, 1) == "+")
                    {
                        tenhc1.Text = "";
                        pos = s.Length;
                    }
                    else tenhc1.Text = s.Substring(pos, s.Length - pos);
                }
                catch { tenhc1.Text = ""; }
            }
		}

		private void tenhc_Validated(object sender, System.EventArgs e)
		{
            try
            {
                if (!listHC.Focused) listHC.Hide();
                DataRow r = d.getrowbyid(dthc, "ten='" + ten.Text.Trim() + "'");
                if (r != null) generic = r["ten"].ToString();
                DataRow r1 = d.getrowbyid(dtatc_hoatchat, "route='" + route.Trim() + "' and ten='"+tenhc.Text.Trim()+"'");
                if (r1 != null)
                {
                    //txtmaatc.Text = r1["atc_code"].ToString().Trim() + route;
                    txtmaatc.Text = r1["atc"].ToString().Trim();//gam 02042012 bac yeu cau ma atc chi lay act_code, khong công thêm route
                    txtgeneric.Text = r1["generic"].ToString().Trim();
                    if (txtmaatc.Text != "")
                    {
                        //Nhom bo
                        string strNhom_bo = txtmaatc.Text.ToUpper(), strManhom_bo = "";
                        //if (txtmaatc.Text.ToUpper() == "DY") strManhom = "7";
                        if (txtmaatc.Text.Length >= 1)
                        {
                            strNhom_bo = txtmaatc.Text.Substring(0, 1).ToUpper();
                            if (strNhom_bo == "J" && (strNhom_bo != "J06" || strNhom_bo != "J07")) strManhom_bo = "3";//Khang sinh
                            else if (txtmaatc.Text.Length >= 3)
                            {
                                strNhom_bo = txtmaatc.Text.Substring(0, 3).ToUpper();
                                if (strNhom_bo == "A11" || strNhom_bo == "B01" || strNhom_bo == "B02" || strNhom_bo == "B03" || strNhom_bo == "B04" || strNhom_bo == "B05") strManhom_bo = "4";//Vitamin
                                else if (strNhom_bo == "N01") strManhom_bo = "6";//Gay me
                                else if (strNhom_bo == "=HC") strManhom_bo = "8";//Hoa chat
                                else if (txtmaatc.Text.Length >= 5)
                                {
                                    strNhom_bo = txtmaatc.Text.Substring(0, 5).ToUpper();
                                    if (strNhom_bo == "H02AB") strManhom_bo = "5";//Corticoid
                                    //else if (strNhom == "V07AD") strManhom = "8";
                                    if (route.Trim() == "P_IV")
                                    {
                                        if (strNhom_bo == "B05XB" || strNhom_bo == "B05BA01") strManhom_bo = "14";//Dich truyen co dam
                                        else strManhom_bo = "13";//Dich truyen khong dam mua
                                    }
                                }
                            }
                        }
                        if (strManhom_bo != "")
                        {
                            DataRow dr = d.getrowbyid(dtnhombo, "id_medisoft=" + strManhom_bo);
                            nhombo.Text = dr["ten"].ToString();
                        }
                        //End Nhom bo

                        //Nhom
                        string strManhom = "";
                        if (route.Trim() == "P_IV")
                            strManhom = "5";//Dich truyen
                        else if (txtmaatc.Text.Trim() == "VI")
                            strManhom = "6";//Duoc lieu dong y
                        else if (txtmaatc.Text.Trim() == "Z01")
                            strManhom = "7";//Thanh pham dong y
                        else if (txtmaatc.Text.Trim() == "VTTH")
                            strManhom = "8";//Vat tu tieu hao
                        else if (txtmaatc.Text.Trim() == "VTYT")
                            strManhom = "9";//Vat tu y te
                        else if (txtmaatc.Text.Trim() == "=HC")
                            strManhom = "4";//Hoa chat
                        DataTable dthuongthan = new DataTable();
                        try { dthuongthan = d.get_data("select * from " + user + ".huongthan where atc='" + txtmaatc.Text.Trim() + "'").Tables[0]; }
                        catch { MessageBox.Show("Thiếu table huongthan"); }
                        DataTable dtgaynghien = new DataTable();
                        try { dtgaynghien = d.get_data("select * from " + user + ".gaynghien where atc='" + txtmaatc.Text.Trim() + "'").Tables[0]; }
                        catch { MessageBox.Show("Thiếu table gaynghien"); }
                        DataRow dr1 = d.getrowbyid(dthuongthan,"atc='"+txtmaatc.Text.Trim()+"'");
                        if (dr1 != null) strManhom = "1";
                        DataRow dr2 = d.getrowbyid(dtgaynghien, "atc='" + txtmaatc.Text.Trim() + "'");
                        if (dr2 != null) strManhom = "2";
                        if (strManhom == "") strManhom = "3";
                        if (strManhom != "")
                        {
                            DataRow dr0 = d.getrowbyid(dtnhom, "id_medisoft=" + strManhom);
                            manhom.Text = dr0["ten"].ToString();
                        }
                        //End Nhom

                        //Loai
                        if (txtmaatc.Text.Length >= 3)
                        {
                            DataRow dr3 = d.getrowbyid(dtloai, "atc_loai='" + txtmaatc.Text.Substring(0, 3) + "'");
                            maloai.Text = dr3["ten"].ToString();
                        }
                        //End Loai
                    }
                }
                else
                {
                    if (bNew)//gam 02042012
                    {
                        txtmaatc.Text = "";
                        txtgeneric.Text = "";
                        nhombo.Text = "";
                        manhom.Text = "";
                        maloai.Text = "";
                        nhomin.Text = "";
                        manuoc.Text = "";
                        mahang.Text = "";
                    }
                }
            }
            catch { }
		}

		private void tenhc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listHC.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{                
				if (listHC.Visible)	listHC.Focus();
				else SendKeys.Send("{Tab}");
                if (tenhc.Text.IndexOf("+")==-1 && ten.Text=="") ten.Text=tenhc.Text;
                ////donvi.Focus();
                //nhomin.Focus();
			}
		}

		private void tenhc1_TextChanged(object sender, System.EventArgs e)
		{
			Filter(tenhc1.Text,listHC);
			listHC.BrowseToHC(tenhc);
		}

		private void listHC_Validated(object sender, System.EventArgs e)
		{
		}

		private void dang_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDang.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listDang.Visible) listDang.Focus();
				else SendKeys.Send("{Tab}");
			}
		}

		private void dang_TextChanged(object sender, System.EventArgs e)
		{
            if (this.ActiveControl == dang)
            {
                Filter(dang.Text, listDang);
                //listDang.BrowseToDanhmuc(dang, donvi, 150);
                listDang.BrowseToDanhmuc(dang, duongdung, 150);
            }
		}

		private void dang_Validated(object sender, System.EventArgs e)
		{
			if(!listDang.Focused) listDang.Hide();
            //if(donvisudung.Text.Trim()=="")donvisudung.Text = dang.Text;
		}

		private void manhom_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listNhom.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listNhom.Visible) listNhom.Focus();
				else SendKeys.Send("{Tab}");
			}
		}

		private void manhom_TextChanged(object sender, System.EventArgs e)
		{
            if (this.ActiveControl == manhom)
            {
                Filter(manhom.Text, listNhom);
                listNhom.BrowseToDanhmuc(manhom, maloai, lPhanloai.Width + maloai.Width);
            }
		}

		private void manhom_Validated(object sender, System.EventArgs e)
		{
			if(!listNhom.Focused) listNhom.Hide();
		}

		private void maloai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listLoai.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listLoai.Visible) listLoai.Focus();
				else SendKeys.Send("{Tab}");
			}
		}

		private void maloai_TextChanged(object sender, System.EventArgs e)
		{
            if (this.ActiveControl == maloai)
            {
                Filter(maloai.Text, listLoai);
                listLoai.BrowseToDanhmuc(maloai, (nhombo.Enabled)?nhombo:mahang, lHang.Width + mahang.Width);
            }
		}

		private void maloai_Validated(object sender, System.EventArgs e)
		{
			if(!listLoai.Focused) listLoai.Hide();
		}

		private void mahang_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listHang.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listHang.Visible) listHang.Focus();
				else SendKeys.Send("{Tab}");
			}
		}

		private void mahang_TextChanged(object sender, System.EventArgs e)
		{
            if (this.ActiveControl == mahang)
            {
                Filter(mahang.Text, listHang);
                //listHang.BrowseToDanhmuc(mahang, manuoc, lNuoc.Width + manuoc.Width);
                listHang.BrowseToDanhmuc(mahang, stt, lNuoc.Width + manuoc.Width);
            }
		}

		private void mahang_Validated(object sender, System.EventArgs e)
		{
			if(!listHang.Focused) listHang.Hide();		
		}

		private void manuoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listNuoc.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listNuoc.Visible) listNuoc.Focus();
				else SendKeys.Send("{Tab}{F4}");
			}
		}

		private void manuoc_TextChanged(object sender, System.EventArgs e)
		{
            if (this.ActiveControl == manuoc)
            {
                Filter(manuoc.Text, listNuoc);
                if (donvi.Enabled) listNuoc.BrowseToDanhmuc(manuoc, donvi, 0);
                else listNuoc.BrowseToDanhmuc(manuoc, sldonggoi, 0);
            }
		}

		private void manuoc_Validated(object sender, System.EventArgs e)
		{
			if(!listNuoc.Focused) listNuoc.Hide();
		}

		private void nhombo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listNhombo.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listNhombo.Visible)	listNhombo.Focus();
				else SendKeys.Send("{Tab}");
			}
		}

		private void nhombo_TextChanged(object sender, System.EventArgs e)
		{
            if (this.ActiveControl == nhombo)
            {
                Filter(nhombo.Text, listNhombo);
                if (nhomin.Enabled)
                    listNhombo.BrowseToDanhmuc(nhombo, nhomin, lBhyt.Width + bhyt.Width);
                else
                    listNhombo.BrowseToDanhmuc(nhombo, manuoc, lBhyt.Width + bhyt.Width);
            }
		}

		private void nhombo_Validated(object sender, System.EventArgs e)
		{
			if(!listNhombo.Focused) listNhombo.Hide();
		}

		private void sotk_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listSotk.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listSotk.Visible) listSotk.Focus();
				else SendKeys.Send("{Tab}");
			}
		}

		private void sotk_TextChanged(object sender, System.EventArgs e)
		{
            if (this.ActiveControl == sotk)
            {
                Filter(sotk.Text, listSotk);
                listSotk.BrowseToDanhmuc(sotk, soluong, lSoluong.Width + soluong.Width);
            }
		}

		private void sotk_Validated(object sender, System.EventArgs e)
		{
			if(!listSotk.Focused) listSotk.Hide();		
		}

		public void RefreshChildren(string text)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid1.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="tenbd like '%"+text.Trim()+"%'"+" or tenhc like '%"+text.Trim()+"%'"+" or ma like '%"+text.Trim()+"%'"+" or tennhom like '%"+text.Trim()+"%'"+" or tenloai like '%"+text.Trim()+"%'"+" or tenin like '%"+text.Trim()+"%'";
				if (text!="")
				{
					ref_text(0);
					l_id=decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,0].ToString());
				}
				else ref_text(l_id);
			}
			catch{}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
            frmChonindmbd f1 = new frmChonindmbd(d, d.get_data("select * from " + user + ".d_dmnhom where nhom=" + i_nhom + " order by stt").Tables[0], d.get_data("select * from " + user + ".d_dmloai where nhom=" + i_nhom + " order by stt").Tables[0], s_mmyy, i_nhom, i_userid);
			f1.ShowDialog(this);
		}

		private void sltoithieu_Validated(object sender, System.EventArgs e)
		{
			try
			{
				int iSoluong=int.Parse(sltoithieu.Text);
				sltoithieu.Text=iSoluong.ToString("###,###,###");
			}
			catch{sltoithieu.Text="0";}
		}

		private void tyle_Validated(object sender, System.EventArgs e)
		{
			try
			{
				decimal dtl=(tyle.Text!="")?decimal.Parse(tyle.Text):0;
				tyle.Text=dtl.ToString("##0.00");
			}
			catch{tyle.Text="0";}
		}

		private void butKemtheo_Click(object sender, System.EventArgs e)
		{
			if (l_id!=0)
			{
                frmDmbdkemtheo f = new frmDmbdkemtheo(d, i_nhom, Convert.ToInt64(l_id), ten.Text.Trim() + " " + hamluong.Text.Trim() + " " + dang.Text, i_userid);
				f.ShowDialog(this);
			}
		}

		private void butTD_Click(object sender, System.EventArgs e)
		{
			if (l_id!=0)
			{
				frmDmbdtd f=new frmDmbdtd(d,i_nhom,Convert.ToInt64(l_id),ten.Text.Trim() + " " + hamluong.Text.Trim() + " " + dang.Text,i_userid);
				f.ShowDialog(this);
			}
		}

		private void butSTT_Click(object sender, System.EventArgs e)
		{
			frmSuastt f=new frmSuastt(d,i_nhom);
			f.ShowDialog();
			load_grid();
		}

		private void nhomin_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listNhomin.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listNhomin.Visible)	listNhomin.Focus();
				else SendKeys.Send("{Tab}{F4}");
			}
		}

		private void nhomin_TextChanged(object sender, System.EventArgs e)
		{
            if (this.ActiveControl == nhomin)
            {
                Filter(nhomin.Text, listNhomin);
                //listNhomin.BrowseToDanhmuc(nhomin, stt, lBhyt.Width + bhyt.Width);
                listNhomin.BrowseToDanhmuc(nhomin, manuoc, lBhyt.Width + bhyt.Width);
            }
		}

		private void nhomin_Validated(object sender, System.EventArgs e)
		{
			if(!listNhomin.Focused) listNhomin.Hide();
		}

		private void find_TextChanged(object sender, System.EventArgs e)
	    {
			if (this.ActiveControl==find) RefreshChildren(find.Text);		
		}

		private void find_Enter(object sender, System.EventArgs e)
		{
			find.Text="";
		}

		private void butNo_Click(object sender, System.EventArgs e)
		{
            
            if (ma.Text!="")
			{
				MessageBox.Show(
lan.Change_language_MessageText("Số thứ tự mã")+" "+ma.Text.Trim()+"\n"+
lan.Change_language_MessageText("là")+" "+d.get_stt(ma.Text.Trim(),i_nhom),d.Msg);
				ma.Focus();
			}
		}

		private void duongdung_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDD.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listDD.Visible) listDD.Focus();
				else SendKeys.Send("{Tab}{Home}");
			}
		}

		private void duongdung_TextChanged(object sender, System.EventArgs e)
		{
            if (this.ActiveControl == duongdung)
            {
                Filter(duongdung.Text, listDD);
                if (tenhc.Enabled || tenhc.Text == "")
                {
                    tenhc.Enabled = true;
                    listDD.BrowseToDanhmuc(duongdung, tenhc, duongdung.Width + manhom.Width);
                }
                else
                    listDD.BrowseToDanhmuc(duongdung, donvi, duongdung.Width + manhom.Width);
            }
		}

		private void duongdung_Validated(object sender, System.EventArgs e)
		{
			if(!listDD.Focused) listDD.Hide();
		}

		private void macc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void macc_Validated(object sender, System.EventArgs e)
		{
			DataRow r=d.getrowbyid(dtcc,"ma='"+macc.Text+"'");
			if (r!=null) tencc.Text=r["ten"].ToString();
			else tencc.Text="";
		}

		private void tencc_TextChanged(object sender, System.EventArgs e)
		{
			Filter(tencc.Text,listNhacc);
			listNhacc.BrowseToDanhmuc(tencc,macc,mahang);
		}

		private void tencc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listNhacc.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listNhacc.Visible) listNhacc.Focus();
				else SendKeys.Send("{Tab}");
			}		
		}

        private void butToithieu_Click(object sender, EventArgs e)
        {
            if (l_id != 0)
            {
                frmDmbdtoithieu f = new frmDmbdtoithieu(d, i_nhom, Convert.ToInt64(l_id), ten.Text.Trim() + " " + hamluong.Text.Trim() + " " + dang.Text);
                f.ShowDialog(this);
            }			
        }

        private void butNhatky_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "select ma,trim(ten)||' '||trim(hamluong) as tenbd,dang,bhyt,to_char(ngayud,'dd/mm/yyyy hh24:mi') as ngayud,to_char(ngayud,'yymmdd hh24:mi') as yymmdd from " + user + ".d_dmbd_luu where id=" + l_id+" order by yymmdd";
                frmNhatkybd f = new frmNhatkybd(ten.Text.Trim() + " " + dang.Text, d.get_data(sql).Tables[0]);
                f.ShowDialog();
            }
            catch { }
        }

        private void donvi_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == donvi)
            {
                Filter(donvi.Text, listdonggoi);
                listdonggoi.BrowseToDanhmuc(donvi, sldonggoi, donvi.Width+soluong.Width);
            }
        }

        private void donvi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listdonggoi.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listdonggoi.Visible) listdonggoi.Focus();
                else SendKeys.Send("{Tab}");
            }
        }

        private void donvi_Validated(object sender, EventArgs e)
        {
            if (!listdonggoi.Focused) listdonggoi.Hide();
        }

        private void f_capnhat_db()
        {
            string asql = "select id from " + user + ".d_dmdonggoi where 1=2";
            DataSet lds = d.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = "create table " + user + ".d_dmdonggoi (id numeric (7), ten text, nhom numeric(3), stt numeric(5), ngayud timestamp DEFAULT now(), CONSTRAINT pk_dmdonggoi primary key (id) using INDEX TABLESPACE medi_index) WITH OIDS ";
                d.execute_data(asql);
            }
            asql = "select id from " + user + ".d_dmthoidiemdung where 1=2";
            lds = d.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = "create table " + user + ".d_dmthoidiemdung (id numeric(3), ten text, nhom numeric(3) default 0, stt numeric (3) default 0, ngayud timestamp DEFAULT now(), readonly numeric (1) default 0, CONSTRAINT pk_d_dmthoidiemdung primary key (id) using INDEX TABLESPACE medi_index) WITH OIDS ";
                d.execute_data(asql);
            }
            asql = "select mathoidiemdung from " + user + ".d_dmbd where 1=2";
            lds = d.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = "alter table " + user + ".d_dmbd add mathoidiemdung numeric(3) default 0";
                d.execute_data(asql);
            }

            asql = "select ketoa from " + user + ".d_dmbd where 1=2";
            lds = d.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = "alter table " + user + ".d_dmbd add ketoa numeric(1) default 0";
                d.execute_data(asql);
            }
            asql = "select sttvb,stt05,stt02,tt10,tt11,vacxin from " + user + ".d_dmbd where 1=2";
            lds = d.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = "alter table " + user + ".d_dmbd add sttvb varchar2(20); \n";
                asql += "alter table " + user + ".d_dmbd add stt05 varchar2(20); \n";
                asql += "alter table " + user + ".d_dmbd add stt02 varchar2(20); \n";
                asql += "alter table " + user + ".d_dmbd add tt10 numeric(1) default 0; \n";
                asql += "alter table " + user + ".d_dmbd add tt11 numeric(1) default 0; \n";
                asql += "alter table " + user + ".d_dmbd add vacxin numeric(1) default 0; \n";
                d.execute_data(asql);
            }
            // Hiền thêm 23-05-2011
            asql = "select sdte,nguongoc,sttbyt,idloaithuoc from " + user + ".d_dmbd where 1=2";
            lds = d.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = "alter table " + user + ".d_dmbd add sdte numeric(1) default 0; \n";
                asql += "alter table " + user + ".d_dmbd add nguongoc varchar2(20); \n";
                asql += "alter table " + user + ".d_dmbd add sttbyt varchar2(10); \n";
                asql += "alter table " + user + ".d_dmbd add idloaithuoc numeric(3) default 0; \n";
                d.execute_data(asql);
            }
            asql = "select id from " + user + ".d_dmloaithuoc where 1=0";
            lds = d.get_data(asql);
            if (lds == null || lds.Tables[0].Rows.Count <= 0)
            {
                asql = "create table " + user + ".d_dmloaithuoc (id numeric(3) not null,ten text,nhom numeric(3) default 1,stt numeric(5) default 0, ngayud timestamp default now(), readonly numeric(1) default 1, constraint pk_dmloaithuoc primary key(id) using INDEX TABLESPACE medi_index) WITH OIDS ";                
                d.execute_data(asql);
                d.upd_dmloaithuoc(0, " ");
                d.upd_dmloaithuoc(1, "Thuốc có tên trong danh mục, bao gồm các thuốc phối hợp nhiều thành phần");
                d.upd_dmloaithuoc(2, "Thuốc phối hợp nhiều đơn chất, mà sự phối hợp này chưa có sẵn trong danh mục");
                d.upd_dmloaithuoc(3, "Thuốc vượt tuyến CMKT");
                d.upd_dmloaithuoc(4, "Thuốc điều trị ung thư, chống thải ghép ngoài danh mục, được quỹ BHYT hỗ trợ 50% chi phí");
                d.upd_dmloaithuoc(5, "Thuốc chuyên khoa do cơ sở KCB tự pha chế hoặc nhượng lại từ cơ sở KCB khác");
                d.upd_dmloaithuoc(6, "Thuốc có trong danh mục nhưng đường dùng, dạng dùng là si-rô, bột thơm, cốm, nhũ dịch, dạng axit chưa có trong danh mục");
                d.upd_dmloaithuoc(7, "Chế phẩm YHCT có trong danh mục thuốc");
                d.upd_dmloaithuoc(8, "Chế phẩm YHCT thay thế các thuốc có trong danh mục thuốc chế phẩm YHCT");
                d.upd_dmloaithuoc(9, "Chế phẩm YHCT do cơ sở KCB sản xuất");
                d.upd_dmloaithuoc(10, "Khác");
            }
            // end hien
        }

        private void f_Load_Kythuatcao()
        {
            try
            {
                //linh
                //DataSet adsKTC = new DataSet();
                //adsKTC.Tables.Add("Table");
                //adsKTC.Tables[0].Columns.Add("id");
                //adsKTC.Tables[0].Columns.Add("ten");
                //adsKTC.Tables[0].Rows.Add(new string[] { "-1", " " });
                //adsKTC.Tables[0].Rows.Add(new string[] { "0", "Dịch vụ kỹ thuật cao, chi phí lớn" });
                //adsKTC.Tables[0].Rows.Add(new string[] { "1", "Chăm sóc thai sản, sinh đẻ" });
                //adsKTC.Tables[0].Rows.Add(new string[] { "2", "Thuốc chống thải ghép, ngoài danh mục" });

                //cbKythuatcao.DisplayMember = "TEN";
                //cbKythuatcao.ValueMember = "ID";
                //cbKythuatcao.DataSource = adsKTC.Tables[0];
                //try
                //{
                //    cbKythuatcao.SelectedValue = "-1";
                //}
                //catch
                //{

                //}
                //end linh

            }
            catch
            {

            }
        }

        private void txtSttVB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtSTT05_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtStt02_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void ten_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.ActiveControl == ten)
                {
                    Filter1(ten.Text);//, listThuoc
                    //listThuoc.BrowseToDanhmuc(ten, ma, (Control)hamluong, 100);
                    listThuoc.BrowseToToathuoc(ten, txtStt, hamluong, ma.Width + ma.Width + ten.Width + 10 + dang.Width + 10 + donvi.Width+sldonggoi.Width+100);//hamluong.Width
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void ten_Validated(object sender, EventArgs e)
        {
            if (!listThuoc.Focused) listThuoc.Hide();
            //if (dtthuoc.Rows.Count <= 0) return;
            //tu 210511
            if (bNew)
            {
                DataRow r = d.getrowbyid(dtthuoc, "ten='" + ten.Text.Trim() + "'");
                if (r == null)
                {
                    dang.Text = "";
                    nhombo.Text = "";
                    manhom.Text = "";
                    maloai.Text = "";
                    tenhc.Text = "";
                    txtmaatc.Text = "";
                    txtgeneric.Text = "";
                    //hamluong.Focus();
                    //listThuoc.Hide();
                    //ma.Text = d.get_data("select (max(id)+1) from "+user+".d_dmthuoc").Tables[0].Rows[0][0].ToString();

                }
            }
        }

        private void listThuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                try
                {
                    DataRow r = d.getrowbyid(dtthuoc, "id=" + decimal.Parse(txtStt.Text));
                    if (r != null)
                    {
                        ma.Text = d.getMabd("d_dmbd", ten.Text, i_nhom);
                        hamluong.Text = r["hamluong"].ToString();
                        duongdung.Text = r["duongdung"].ToString();
                        dang.Text = r["dang"].ToString();
                        nhombo.Text = r["nhombo"].ToString();
                        manhom.Text = r["tennhom"].ToString();
                        maloai.Text = r["tenloai"].ToString();
                        tenhc.Text = r["tenhc"].ToString();
                        txtmaatc.Text = r["atc"].ToString();
                        txtgeneric.Text = r["generic"].ToString();
                    }
                    else
                    {
                        hamluong.Text = "";
                        duongdung.Text = "";
                    }
                }
                catch { }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void listDD_KeyDown(object sender, KeyEventArgs e)
        {
            DataRow r = d.getrowbyid(dtdd, "ten='" + duongdung.Text.Trim() + "'");
            if (r != null) route = r["route"].ToString();
        }

        private void listHC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{Tab}");
                //nhomin.Focus();
            }
        }

        private void chkTreem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtSttByt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtnguongoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void cmbLoaithuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void f_caplai_mabd()
        {
            sql = "update " + user + ".d_dmbd set ma='000000' where nhom=" + i_nhom;// +" and ma='BAN001'";
            d.execute_data(sql);
            sql = "select id, ma, ten from " + user + ".d_dmbd where nhom=" + i_nhom + " order by ten, id ";//+" and ma='000000' 
            DataSet lds = d.get_data(sql);
            string s_ma = "";
            int i1 = lds.Tables[0].Rows.Count;
            int i2 = 0;
            foreach (DataRow r in lds.Tables[0].Rows)
            {
                s_ma = d.getMabd("d_dmbd", r["ten"].ToString(), i_nhom);
                sql = "update " + user + ".d_dmbd set ma='" + s_ma + "' where id=" + r["id"].ToString();
                d.execute_data(sql);
                i2 += 1;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            //f_caplai_mabd();
            //load_grid();
        }

        private void txtNgaycapSDK_Validated(object sender, EventArgs e)
        {
            if (txtNgaycapSDK.Text.Trim().Trim('/').Trim() != "")
            {
                try {
                    DateTime dttime = d.StringToDate(txtNgaycapSDK.Text);
                }
                catch {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ"),"Medisoft");
                    txtNgaycapSDK.Text = "";
                    txtNgaycapSDK.Focus();
                }
            }
        }

        private void chktt10_CheckedChanged(object sender, EventArgs e)
        {
            if (chktt10.Checked)
            {
                chktt11.Checked = false;
                chkVac.Checked = false;
            }
        }

        private void chktt11_CheckedChanged(object sender, EventArgs e)
        {
            if (chktt11.Checked)
            {
                chktt10.Checked = false;
                chkVac.Checked = false;
            }
        }

        private void chkVac_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVac.Checked)
            {
                chktt10.Checked = false;
                chktt11.Checked = false;
            }
        }
        //Thuy 14.12.2011
        private void chkSinhpham_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSinhpham.Checked)
            {
                chkVac.Checked = true;
            }
        }

        private void butImpExcel_Click(object sender, EventArgs e)
        {
            frmNhap_dmbd f = new frmNhap_dmbd();
            f.ShowDialog();
            load_grid();
        }
        //end Thuy 14.12.2011
	}
}
