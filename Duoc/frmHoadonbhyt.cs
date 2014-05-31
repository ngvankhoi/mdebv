using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using LibMedi;
using LibVienphi;
using dichso;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmXkhac.
	/// </summary>
	public class frmHoadonbhyt : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private MaskedBox.MaskedBox ngaysp;
		private LibList.List listDMBD;
		private System.Windows.Forms.Label lTen;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
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
        private string user, s_mmyy, xxx, yyy, s_ngay, tmp_ngay, sql, s_ngaysp, s_makho, s_kho, s_manguon, format_soluong, format_dongia, format_sotien, s_tungay, s_denngay, stime, s_tu, s_den, s_userid, s_chenhlech, s_tunguyen, fie_tunguyen,ngay1,ngay2,ngay3,ngay_reset_phieu38="";
        private string s_idcomputer = "";
        private int i_nhom, i_userid, i_mabd, i_old, i_songay, i_loai, i_quyenso = 0, i_mavp, i_madoituong, i_bhyt_inrieng, i_loaiba, itable, iMavp_congkham, songayduyet, i_tunguyen, traituyen, iTraituyen, i_khudt = 0, i_quyen_duyetmau38=0,v1=4,v2=2;
		private decimal l_id,l_sttt,l_maql,l_idchidinh,l_mavaovien,lTraituyen;
		private decimal d_soluong,d_dongia,d_sotien,d_soluongton,d_soluongcu,d_tongcong,d_giaban,d_sotienmua;
        private decimal d_soluongvp, d_dongiavp, d_sotienvp, d_thuoc, d_bntra, d_bhyttra, d_congkham, d_cls, d_chiphi, Bhyt_7cn;
        private decimal d_dichvu_tt_BHYT_tra = 0, d_tongcp_dichvu_tt = 0;
        private bool bKhoaso, bNew, bEdit = true, bQuyenso, bSobienlai, bAdmin, bTiepdon, bMabn, bLoad, bLoc, bCongkham, bThongbao, bChandoan, bSotien, bDenngay_sothe, bIn_Nhomvp, bGiaban = false, bIncstt, bChuyenkham_congkham, bInchiphi_chandoan_bacsy, bchenhlech_thuoc, bGia_bh_quydinh, bChenhlech_thuoc_dannhmuc, bChenhlech, bThuhoi, bGia_bh_quydinh_giamua;
        private bool bThuchenhlechtruoc_duyettoasau = false, bLaygiamua_khi_giabh_0_giabh_nho_giamua = true, bBHYT_Traituyen_tinh_Tyle_khac = false, bTraituyen_bhtra=false;
		private LibDuoc.AccessData d;
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
        //gam 05/11/2011
        private bool bDuyet_khambenh = false;
        private bool bDuyet_donvepl = false, bkhongChoDuyetToaBNHen_E8 = false;
        //end gam
		private numbertotext doiso=new numbertotext();
		private DataTable dttonct=new DataTable();
		private DataTable dtton=new DataTable();
		private DataTable dtll=new DataTable();
		private DataTable dtct=new DataTable();
		private DataTable dtsave=new DataTable();
		private DataTable dtcachdung=new DataTable();
		private DataTable dtdstt=new DataTable();
		private DataTable dtkp=new DataTable();
		private DataTable dtbs=new DataTable();
		private DataTable dticd=new DataTable();
		private DataTable dtqs=new DataTable();
		private DataTable dtvp=new DataTable();
		private DataTable dtdmvp=new DataTable();
		private DataTable dtvpin=new DataTable();
		private DataTable dtbd=new DataTable();
        private DataTable dtdtf = new DataTable();
		private DataSet dsxoa=new DataSet();
		private DataSet dsxoavp=new DataSet();
		private DataSet dsxml=new DataSet();
		private DataSet dsxmlin=new DataSet();
		private DataSet dslien=new DataSet();
		private DataRow r;
		private MaskedBox.MaskedBox handung;
		private MaskedBox.MaskedBox losx;
		private MaskedTextBox.MaskedTextBox sophieu;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.ComboBox manguon;
		private System.Windows.Forms.ComboBox nhomcc;
		private System.Windows.Forms.TextBox stt;
		private System.Windows.Forms.TextBox sttt;
		private System.Windows.Forms.Label lMabd;
		private System.Windows.Forms.ComboBox makho;
		private System.Drawing.Printing.PrintDocument docToPrint = new System.Drawing.Printing.PrintDocument();
		private PrintDialog p=new PrintDialog();
		private DialogResult result;
		private System.Windows.Forms.Label label4;
		private MaskedTextBox.MaskedTextBox hoten;
		private MaskedTextBox.MaskedTextBox namsinh;
		private System.Windows.Forms.TextBox cachdung;
		private System.Windows.Forms.TextBox diachi;
		private LibList.List listcachdung;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox maphu;
		private System.Windows.Forms.TextBox tenbv;
		private System.Windows.Forms.TextBox mabv;
		private LibList.List listDstt;
		private System.Windows.Forms.TextBox sothe;
		private System.Windows.Forms.TextBox tenbs;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox tenkp;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox mabs;
		private System.Windows.Forms.TextBox makp;
		private System.Windows.Forms.TextBox chandoan;
		private MaskedTextBox.MaskedTextBox maicd;
		private LibList.List listBTDKP;
		private LibList.List listDMBS;
		private LibList.List listICD;
		private System.Windows.Forms.Button butDuyet;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private MaskedTextBox.MaskedTextBox congkham;
		private MaskedTextBox.MaskedTextBox thuoc;
		private MaskedTextBox.MaskedTextBox cls;
		private MaskedTextBox.MaskedTextBox chiphi;
		private MaskedTextBox.MaskedTextBox bntra;
		private MaskedTextBox.MaskedTextBox bhyttra;
		private MaskedTextBox.MaskedTextBox quyenso;
		private MaskedTextBox.MaskedTextBox sobienlai;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.TextBox mavp;
		private System.Windows.Forms.TextBox tenvp;
		private MaskedBox.MaskedBox dvt;
		private MaskedTextBox.MaskedTextBox soluongvp;
		private MaskedTextBox.MaskedTextBox dongiavp;
		private MaskedTextBox.MaskedTextBox sotienvp;
		private System.Windows.Forms.Button butThemvp;
		private System.Windows.Forms.Button butXoavp;
		private System.Windows.Forms.Button butDichvu;
		private System.Windows.Forms.TextBox sttvp;
		private LibList.List listVP;
		private System.Windows.Forms.Button butinBL;
		private Print print=new Print();
		private System.Windows.Forms.TextBox giaban;
		private System.Windows.Forms.TextBox sotienmua;
		private DataTable dtdt=new DataTable();
		private System.Windows.Forms.TextBox timkiem;
		private System.Windows.Forms.Button butTreem;
        private FileStream fstr;
        private byte[] image, imageuser;
        private CheckBox chkXML;
        private CheckBox chkXem;
        private Button butList;
        private CheckBox chkKodichvu;
        private CheckBox chkds;
        private CheckBox chkInchuathu;
        private Label lbldungluc;
        private NumericUpDown ngaynghi;
        private Label label28;
        private CheckBox chkintrongngay;
        private bool bChuahoantatkham = false;
        private ComboBox cbTraituyen;
        private CheckBox chkInbienlai_kquyensoKbienlai;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmHoadonbhyt(LibDuoc.AccessData acc,int loai,string mmyy,string ngay,int nhom,int userid,string kho,string title,bool admin,int madoituong,int loaiba,string tenuser,bool thuhoi,bool view, int _khudt,bool Chuahoantatkham)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            d = acc; i_loaiba = loaiba; s_userid = tenuser;
			i_nhom=nhom;s_kho=kho;i_userid=userid;
			s_mmyy=mmyy;s_ngay=ngay;i_loai=loai;
            tmp_ngay = ngay;
            bAdmin = admin; i_madoituong = madoituong; bThuhoi = thuhoi;
			this.Text=title+"(Ngày "+s_ngay+")";            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            butMoi.Enabled = butSua.Enabled = butDuyet.Enabled=butinBL.Enabled=butIn.Enabled=butTreem.Enabled=!view;
            i_khudt = _khudt;
            bChuahoantatkham = Chuahoantatkham;//gam 07/11/2011 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHoadonbhyt));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ngaysp = new MaskedBox.MaskedBox();
            this.listDMBD = new LibList.List();
            this.lMabd = new System.Windows.Forms.Label();
            this.lTen = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
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
            this.handung = new MaskedBox.MaskedBox();
            this.losx = new MaskedBox.MaskedBox();
            this.sophieu = new MaskedTextBox.MaskedTextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.nhomcc = new System.Windows.Forms.ComboBox();
            this.stt = new System.Windows.Forms.TextBox();
            this.sttt = new System.Windows.Forms.TextBox();
            this.diachi = new System.Windows.Forms.TextBox();
            this.makho = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.hoten = new MaskedTextBox.MaskedTextBox();
            this.namsinh = new MaskedTextBox.MaskedTextBox();
            this.cachdung = new System.Windows.Forms.TextBox();
            this.listcachdung = new LibList.List();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.maphu = new System.Windows.Forms.ComboBox();
            this.tenbv = new System.Windows.Forms.TextBox();
            this.mabv = new System.Windows.Forms.TextBox();
            this.listDstt = new LibList.List();
            this.sothe = new System.Windows.Forms.TextBox();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tenkp = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.mabs = new System.Windows.Forms.TextBox();
            this.makp = new System.Windows.Forms.TextBox();
            this.chandoan = new System.Windows.Forms.TextBox();
            this.maicd = new MaskedTextBox.MaskedTextBox();
            this.listBTDKP = new LibList.List();
            this.listDMBS = new LibList.List();
            this.listICD = new LibList.List();
            this.butDuyet = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.congkham = new MaskedTextBox.MaskedTextBox();
            this.thuoc = new MaskedTextBox.MaskedTextBox();
            this.cls = new MaskedTextBox.MaskedTextBox();
            this.chiphi = new MaskedTextBox.MaskedTextBox();
            this.bntra = new MaskedTextBox.MaskedTextBox();
            this.bhyttra = new MaskedTextBox.MaskedTextBox();
            this.quyenso = new MaskedTextBox.MaskedTextBox();
            this.sobienlai = new MaskedTextBox.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkintrongngay = new System.Windows.Forms.CheckBox();
            this.label28 = new System.Windows.Forms.Label();
            this.ngaynghi = new System.Windows.Forms.NumericUpDown();
            this.lbldungluc = new System.Windows.Forms.Label();
            this.chkInchuathu = new System.Windows.Forms.CheckBox();
            this.chkKodichvu = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkInbienlai_kquyensoKbienlai = new System.Windows.Forms.CheckBox();
            this.chkds = new System.Windows.Forms.CheckBox();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.timkiem = new System.Windows.Forms.TextBox();
            this.chkXem = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.mavp = new System.Windows.Forms.TextBox();
            this.tenvp = new System.Windows.Forms.TextBox();
            this.dvt = new MaskedBox.MaskedBox();
            this.soluongvp = new MaskedTextBox.MaskedTextBox();
            this.dongiavp = new MaskedTextBox.MaskedTextBox();
            this.sotienvp = new MaskedTextBox.MaskedTextBox();
            this.butThemvp = new System.Windows.Forms.Button();
            this.butXoavp = new System.Windows.Forms.Button();
            this.butDichvu = new System.Windows.Forms.Button();
            this.sttvp = new System.Windows.Forms.TextBox();
            this.listVP = new LibList.List();
            this.butinBL = new System.Windows.Forms.Button();
            this.giaban = new System.Windows.Forms.TextBox();
            this.sotienmua = new System.Windows.Forms.TextBox();
            this.butTreem = new System.Windows.Forms.Button();
            this.butList = new System.Windows.Forms.Button();
            this.cbTraituyen = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ngaynghi)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(201, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-1, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ký hiệu :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(323, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 23);
            this.label9.TabIndex = 8;
            this.label9.Text = "Họ tên :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(569, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 23);
            this.label10.TabIndex = 9;
            this.label10.Text = "Địa chỉ :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngaysp
            // 
            this.ngaysp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaysp.Enabled = false;
            this.ngaysp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysp.Location = new System.Drawing.Point(128, 232);
            this.ngaysp.Mask = "##/##/####";
            this.ngaysp.MaxLength = 10;
            this.ngaysp.Name = "ngaysp";
            this.ngaysp.Size = new System.Drawing.Size(64, 21);
            this.ngaysp.TabIndex = 0;
            this.ngaysp.Text = "  /  /    ";
            this.ngaysp.Validated += new System.EventHandler(this.ngaysp_Validated);
            // 
            // listDMBD
            // 
            this.listDMBD.BackColor = System.Drawing.SystemColors.Info;
            this.listDMBD.ColumnCount = 0;
            this.listDMBD.Location = new System.Drawing.Point(376, 544);
            this.listDMBD.MatchBufferTimeOut = 1000;
            this.listDMBD.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listDMBD.Name = "listDMBD";
            this.listDMBD.Size = new System.Drawing.Size(75, 17);
            this.listDMBD.TabIndex = 26;
            this.listDMBD.TextIndex = -1;
            this.listDMBD.TextMember = null;
            this.listDMBD.ValueIndex = -1;
            this.listDMBD.Visible = false;
            this.listDMBD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listDMBD_KeyDown);
            // 
            // lMabd
            // 
            this.lMabd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lMabd.Location = new System.Drawing.Point(29, 351);
            this.lMabd.Name = "lMabd";
            this.lMabd.Size = new System.Drawing.Size(32, 17);
            this.lMabd.TabIndex = 128;
            this.lMabd.Text = "Mã :";
            this.lMabd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lTen
            // 
            this.lTen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTen.Location = new System.Drawing.Point(116, 18);
            this.lTen.Name = "lTen";
            this.lTen.Size = new System.Drawing.Size(32, 23);
            this.lTen.TabIndex = 29;
            this.lTen.Text = "Tên :";
            this.lTen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.Location = new System.Drawing.Point(5, 367);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 23);
            this.label16.TabIndex = 31;
            this.label16.Text = "Số lượng :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.Location = new System.Drawing.Point(96, 367);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 23);
            this.label17.TabIndex = 32;
            this.label17.Text = "Đơn giá :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label18.Location = new System.Drawing.Point(245, 367);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 23);
            this.label18.TabIndex = 33;
            this.label18.Text = "Số tiền :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenbd
            // 
            this.tenbd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenbd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbd.Enabled = false;
            this.tenbd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbd.Location = new System.Drawing.Point(148, 345);
            this.tenbd.Name = "tenbd";
            this.tenbd.Size = new System.Drawing.Size(203, 21);
            this.tenbd.TabIndex = 18;
            this.tenbd.Validated += new System.EventHandler(this.tenbd_Validated);
            this.tenbd.TextChanged += new System.EventHandler(this.tenbd_TextChanged);
            this.tenbd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbd_KeyDown);
            // 
            // mabd
            // 
            this.mabd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mabd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabd.Enabled = false;
            this.mabd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabd.Location = new System.Drawing.Point(64, 345);
            this.mabd.Name = "mabd";
            this.mabd.Size = new System.Drawing.Size(56, 21);
            this.mabd.TabIndex = 17;
            this.mabd.Validated += new System.EventHandler(this.mabd_Validated);
            this.mabd.TextChanged += new System.EventHandler(this.mabd_TextChanged);
            this.mabd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabd_KeyDown);
            // 
            // dang
            // 
            this.dang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dang.Enabled = false;
            this.dang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dang.Location = new System.Drawing.Point(353, 345);
            this.dang.Mask = "";
            this.dang.MaxLength = 10;
            this.dang.Name = "dang";
            this.dang.Size = new System.Drawing.Size(40, 21);
            this.dang.TabIndex = 19;
            // 
            // soluong
            // 
            this.soluong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(64, 368);
            this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(40, 21);
            this.soluong.TabIndex = 20;
            this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
            // 
            // dongia
            // 
            this.dongia.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dongia.Enabled = false;
            this.dongia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dongia.Location = new System.Drawing.Point(169, 240);
            this.dongia.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.dongia.Name = "dongia";
            this.dongia.Size = new System.Drawing.Size(79, 21);
            this.dongia.TabIndex = 21;
            this.dongia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // sotien
            // 
            this.sotien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sotien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sotien.Enabled = false;
            this.sotien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sotien.Location = new System.Drawing.Point(297, 368);
            this.sotien.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sotien.Name = "sotien";
            this.sotien.Size = new System.Drawing.Size(96, 21);
            this.sotien.TabIndex = 22;
            this.sotien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.Image = global::Duoc.Properties.Resources.add;
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(76, 533);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(68, 25);
            this.butMoi.TabIndex = 38;
            this.butMoi.Text = "     &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = global::Duoc.Properties.Resources.quick_edit;
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(143, 533);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(68, 25);
            this.butSua.TabIndex = 39;
            this.butSua.Text = "    &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = global::Duoc.Properties.Resources.save;
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(210, 533);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(69, 25);
            this.butLuu.TabIndex = 36;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butThem
            // 
            this.butThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butThem.Enabled = false;
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(62, 110);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(60, 23);
            this.butThem.TabIndex = 24;
            this.butThem.Text = "&Thuốc";
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // butXoa
            // 
            this.butXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butXoa.Enabled = false;
            this.butXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXoa.Location = new System.Drawing.Point(122, 111);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(60, 23);
            this.butXoa.TabIndex = 25;
            this.butXoa.Text = "&Xóa";
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = global::Duoc.Properties.Resources.undo_ok;
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(278, 533);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(69, 25);
            this.butBoqua.TabIndex = 37;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = global::Duoc.Properties.Resources.delete_enabled;
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(346, 533);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(68, 25);
            this.butHuy.TabIndex = 40;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = global::Duoc.Properties.Resources.F7;
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(490, 533);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(90, 25);
            this.butIn.TabIndex = 42;
            this.butIn.Text = "In đơn thuốc";
            this.butIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(723, 533);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(69, 25);
            this.butKetthuc.TabIndex = 44;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // cmbSophieu
            // 
            this.cmbSophieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSophieu.Location = new System.Drawing.Point(246, 7);
            this.cmbSophieu.Name = "cmbSophieu";
            this.cmbSophieu.Size = new System.Drawing.Size(82, 21);
            this.cmbSophieu.TabIndex = 2;
            this.cmbSophieu.SelectedIndexChanged += new System.EventHandler(this.cmbSophieu_SelectedIndexChanged);
            this.cmbSophieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSophieu_KeyDown);
            // 
            // handung
            // 
            this.handung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.handung.Enabled = false;
            this.handung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.handung.Location = new System.Drawing.Point(160, 272);
            this.handung.Mask = "####";
            this.handung.Name = "handung";
            this.handung.Size = new System.Drawing.Size(32, 21);
            this.handung.TabIndex = 24;
            this.handung.Text = "    ";
            // 
            // losx
            // 
            this.losx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.losx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.losx.Enabled = false;
            this.losx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.losx.Location = new System.Drawing.Point(192, 272);
            this.losx.Mask = "&&&&&&&&&&";
            this.losx.MaxLength = 10;
            this.losx.Name = "losx";
            this.losx.Size = new System.Drawing.Size(56, 21);
            this.losx.TabIndex = 25;
            this.losx.Text = "          ";
            // 
            // sophieu
            // 
            this.sophieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sophieu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sophieu.Enabled = false;
            this.sophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sophieu.Location = new System.Drawing.Point(246, 7);
            this.sophieu.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sophieu.MaxLength = 10;
            this.sophieu.Name = "sophieu";
            this.sophieu.Size = new System.Drawing.Size(82, 21);
            this.sophieu.TabIndex = 3;
            this.sophieu.Validated += new System.EventHandler(this.sophieu_Validated);
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label25.Location = new System.Drawing.Point(-19, 391);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(80, 23);
            this.label25.TabIndex = 66;
            this.label25.Text = "Cách dùng :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.dataGrid1.Location = new System.Drawing.Point(7, 59);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(384, 262);
            this.dataGrid1.TabIndex = 27;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // manguon
            // 
            this.manguon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manguon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manguon.Enabled = false;
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(64, 272);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(48, 21);
            this.manguon.TabIndex = 22;
            // 
            // nhomcc
            // 
            this.nhomcc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhomcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhomcc.Enabled = false;
            this.nhomcc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhomcc.Location = new System.Drawing.Point(112, 272);
            this.nhomcc.Name = "nhomcc";
            this.nhomcc.Size = new System.Drawing.Size(46, 21);
            this.nhomcc.TabIndex = 23;
            // 
            // stt
            // 
            this.stt.Location = new System.Drawing.Point(104, 232);
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(24, 20);
            this.stt.TabIndex = 68;
            // 
            // sttt
            // 
            this.sttt.Location = new System.Drawing.Point(64, 232);
            this.sttt.Name = "sttt";
            this.sttt.Size = new System.Drawing.Size(24, 20);
            this.sttt.TabIndex = 69;
            // 
            // diachi
            // 
            this.diachi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(624, 7);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(160, 21);
            this.diachi.TabIndex = 6;
            this.diachi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.diachi_KeyDown);
            // 
            // makho
            // 
            this.makho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makho.Enabled = false;
            this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.Location = new System.Drawing.Point(8, 272);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(56, 21);
            this.makho.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(520, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 23);
            this.label4.TabIndex = 74;
            this.label4.Text = "NS :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(371, 7);
            this.hoten.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(150, 21);
            this.hoten.TabIndex = 4;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(550, 7);
            this.namsinh.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.namsinh.MaxLength = 4;
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(32, 21);
            this.namsinh.TabIndex = 5;
            this.namsinh.Validated += new System.EventHandler(this.namsinh_Validated);
            // 
            // cachdung
            // 
            this.cachdung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cachdung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cachdung.Enabled = false;
            this.cachdung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cachdung.Location = new System.Drawing.Point(62, 63);
            this.cachdung.Name = "cachdung";
            this.cachdung.Size = new System.Drawing.Size(329, 21);
            this.cachdung.TabIndex = 1;
            this.cachdung.Validated += new System.EventHandler(this.cachdung_Validated);
            this.cachdung.TextChanged += new System.EventHandler(this.cachdung_TextChanged);
            this.cachdung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cachdung_KeyDown);
            // 
            // listcachdung
            // 
            this.listcachdung.BackColor = System.Drawing.SystemColors.Info;
            this.listcachdung.ColumnCount = 0;
            this.listcachdung.Location = new System.Drawing.Point(314, 130);
            this.listcachdung.MatchBufferTimeOut = 1000;
            this.listcachdung.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listcachdung.Name = "listcachdung";
            this.listcachdung.Size = new System.Drawing.Size(75, 17);
            this.listcachdung.TabIndex = 80;
            this.listcachdung.TextIndex = -1;
            this.listcachdung.TextMember = null;
            this.listcachdung.ValueIndex = -1;
            this.listcachdung.Visible = false;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(161, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 23);
            this.label6.TabIndex = 81;
            this.label6.Text = "Số thẻ :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(-8, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 23);
            this.label7.TabIndex = 82;
            this.label7.Text = "Đ. tượng :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(385, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 23);
            this.label8.TabIndex = 83;
            this.label8.Text = "Nơi ĐKKCB :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // maphu
            // 
            this.maphu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maphu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.maphu.Enabled = false;
            this.maphu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maphu.Location = new System.Drawing.Point(43, 31);
            this.maphu.Name = "maphu";
            this.maphu.Size = new System.Drawing.Size(109, 21);
            this.maphu.TabIndex = 7;
            this.maphu.SelectedIndexChanged += new System.EventHandler(this.maphu_SelectedIndexChanged);
            this.maphu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maphu_KeyDown);
            // 
            // tenbv
            // 
            this.tenbv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenbv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbv.Enabled = false;
            this.tenbv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbv.Location = new System.Drawing.Point(527, 31);
            this.tenbv.Name = "tenbv";
            this.tenbv.Size = new System.Drawing.Size(257, 21);
            this.tenbv.TabIndex = 10;
            this.tenbv.Validated += new System.EventHandler(this.tenbv_Validated);
            this.tenbv.TextChanged += new System.EventHandler(this.tenbv_TextChanged);
            this.tenbv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbv_KeyDown);
            // 
            // mabv
            // 
            this.mabv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabv.Enabled = false;
            this.mabv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabv.Location = new System.Drawing.Point(464, 31);
            this.mabv.Name = "mabv";
            this.mabv.Size = new System.Drawing.Size(61, 21);
            this.mabv.TabIndex = 9;
            // 
            // listDstt
            // 
            this.listDstt.BackColor = System.Drawing.SystemColors.Info;
            this.listDstt.ColumnCount = 0;
            this.listDstt.Location = new System.Drawing.Point(456, 552);
            this.listDstt.MatchBufferTimeOut = 1000;
            this.listDstt.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listDstt.Name = "listDstt";
            this.listDstt.Size = new System.Drawing.Size(75, 17);
            this.listDstt.TabIndex = 88;
            this.listDstt.TextIndex = -1;
            this.listDstt.TextMember = null;
            this.listDstt.ValueIndex = -1;
            this.listDstt.Visible = false;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(206, 31);
            this.sothe.MaxLength = 20;
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(137, 21);
            this.sothe.TabIndex = 8;
            this.sothe.Validated += new System.EventHandler(this.sothe_Validated);
            this.sothe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sothe_KeyDown);
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Enabled = false;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(240, 54);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(158, 21);
            this.tenbs.TabIndex = 14;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(159, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 23);
            this.label11.TabIndex = 91;
            this.label11.Text = "Bác sĩ :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(-9, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 23);
            this.label12.TabIndex = 92;
            this.label12.Text = "P.Khám :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenkp
            // 
            this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkp.Enabled = false;
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(68, 54);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(92, 21);
            this.tenkp.TabIndex = 12;
            this.tenkp.TextChanged += new System.EventHandler(this.tenkp_TextChanged);
            this.tenkp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenkp_KeyDown);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(393, 54);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 23);
            this.label13.TabIndex = 94;
            this.label13.Text = "Chẩn đoán :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.Enabled = false;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(207, 54);
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(32, 21);
            this.mabs.TabIndex = 13;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.diachi_KeyDown);
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.Enabled = false;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(43, 54);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(24, 21);
            this.makp.TabIndex = 11;
            this.makp.Validated += new System.EventHandler(this.makp_Validated);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.diachi_KeyDown);
            // 
            // chandoan
            // 
            this.chandoan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(527, 54);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(257, 21);
            this.chandoan.TabIndex = 16;
            this.chandoan.TextChanged += new System.EventHandler(this.chandoan_TextChanged);
            this.chandoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chandoan_KeyDown);
            // 
            // maicd
            // 
            this.maicd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maicd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.maicd.Enabled = false;
            this.maicd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maicd.Location = new System.Drawing.Point(464, 54);
            this.maicd.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.maicd.Name = "maicd";
            this.maicd.Size = new System.Drawing.Size(61, 21);
            this.maicd.TabIndex = 15;
            this.maicd.Validated += new System.EventHandler(this.maicd_Validated);
            // 
            // listBTDKP
            // 
            this.listBTDKP.BackColor = System.Drawing.SystemColors.Info;
            this.listBTDKP.ColumnCount = 0;
            this.listBTDKP.Location = new System.Drawing.Point(96, 552);
            this.listBTDKP.MatchBufferTimeOut = 1000;
            this.listBTDKP.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listBTDKP.Name = "listBTDKP";
            this.listBTDKP.Size = new System.Drawing.Size(75, 17);
            this.listBTDKP.TabIndex = 97;
            this.listBTDKP.TextIndex = -1;
            this.listBTDKP.TextMember = null;
            this.listBTDKP.ValueIndex = -1;
            this.listBTDKP.Visible = false;
            // 
            // listDMBS
            // 
            this.listDMBS.BackColor = System.Drawing.SystemColors.Info;
            this.listDMBS.ColumnCount = 0;
            this.listDMBS.Location = new System.Drawing.Point(176, 551);
            this.listDMBS.MatchBufferTimeOut = 1000;
            this.listDMBS.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listDMBS.Name = "listDMBS";
            this.listDMBS.Size = new System.Drawing.Size(75, 17);
            this.listDMBS.TabIndex = 98;
            this.listDMBS.TextIndex = -1;
            this.listDMBS.TextMember = null;
            this.listDMBS.ValueIndex = -1;
            this.listDMBS.Visible = false;
            // 
            // listICD
            // 
            this.listICD.BackColor = System.Drawing.SystemColors.Info;
            this.listICD.ColumnCount = 0;
            this.listICD.Location = new System.Drawing.Point(560, 553);
            this.listICD.MatchBufferTimeOut = 1000;
            this.listICD.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listICD.Name = "listICD";
            this.listICD.Size = new System.Drawing.Size(75, 17);
            this.listICD.TabIndex = 99;
            this.listICD.TextIndex = -1;
            this.listICD.TextMember = null;
            this.listICD.ValueIndex = -1;
            this.listICD.Visible = false;
            // 
            // butDuyet
            // 
            this.butDuyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butDuyet.Image = ((System.Drawing.Image)(resources.GetObject("butDuyet.Image")));
            this.butDuyet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDuyet.Location = new System.Drawing.Point(413, 533);
            this.butDuyet.Name = "butDuyet";
            this.butDuyet.Size = new System.Drawing.Size(78, 25);
            this.butDuyet.TabIndex = 26;
            this.butDuyet.Text = "  Đơn thuốc";
            this.butDuyet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butDuyet.Click += new System.EventHandler(this.butDuyet_Click);
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(101, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 23);
            this.label14.TabIndex = 102;
            this.label14.Text = "Biên lai :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGrid2
            // 
            this.dataGrid2.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid2.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.DataMember = "";
            this.dataGrid2.FlatMode = true;
            this.dataGrid2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid2.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid2.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid2.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid2.Location = new System.Drawing.Point(400, 59);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid2.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.ReadOnly = true;
            this.dataGrid2.RowHeaderWidth = 10;
            this.dataGrid2.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid2.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.Size = new System.Drawing.Size(384, 271);
            this.dataGrid2.TabIndex = 103;
            this.dataGrid2.CurrentCellChanged += new System.EventHandler(this.dataGrid2_CurrentCellChanged);
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label19.Location = new System.Drawing.Point(3, 499);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 23);
            this.label19.TabIndex = 45;
            this.label19.Text = "&Công khám";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label21.Location = new System.Drawing.Point(121, 499);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 23);
            this.label21.TabIndex = 105;
            this.label21.Text = "Thuốc";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label22.Location = new System.Drawing.Point(242, 499);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(56, 23);
            this.label22.TabIndex = 106;
            this.label22.Text = "Dịch vụ";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label23.Location = new System.Drawing.Point(368, 499);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(56, 23);
            this.label23.TabIndex = 107;
            this.label23.Text = "Chi phí";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label26.Location = new System.Drawing.Point(494, 499);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(88, 23);
            this.label26.TabIndex = 108;
            this.label26.Text = "Người bệnh trả";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label27
            // 
            this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label27.Location = new System.Drawing.Point(654, 499);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(106, 23);
            this.label27.TabIndex = 109;
            this.label27.Text = "BHYT trả";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // congkham
            // 
            this.congkham.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.congkham.BackColor = System.Drawing.SystemColors.Info;
            this.congkham.Enabled = false;
            this.congkham.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.congkham.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.congkham.Location = new System.Drawing.Point(64, 500);
            this.congkham.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.congkham.Name = "congkham";
            this.congkham.Size = new System.Drawing.Size(56, 21);
            this.congkham.TabIndex = 46;
            this.congkham.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.congkham.Validated += new System.EventHandler(this.congkham_Validated);
            // 
            // thuoc
            // 
            this.thuoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.thuoc.BackColor = System.Drawing.SystemColors.Info;
            this.thuoc.Enabled = false;
            this.thuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thuoc.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.thuoc.Location = new System.Drawing.Point(158, 500);
            this.thuoc.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.thuoc.Name = "thuoc";
            this.thuoc.Size = new System.Drawing.Size(84, 21);
            this.thuoc.TabIndex = 111;
            this.thuoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cls
            // 
            this.cls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cls.BackColor = System.Drawing.SystemColors.Info;
            this.cls.Enabled = false;
            this.cls.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cls.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.cls.Location = new System.Drawing.Point(284, 500);
            this.cls.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.cls.Name = "cls";
            this.cls.Size = new System.Drawing.Size(84, 21);
            this.cls.TabIndex = 112;
            this.cls.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chiphi
            // 
            this.chiphi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chiphi.BackColor = System.Drawing.SystemColors.Info;
            this.chiphi.Enabled = false;
            this.chiphi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chiphi.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chiphi.Location = new System.Drawing.Point(408, 500);
            this.chiphi.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.chiphi.Name = "chiphi";
            this.chiphi.Size = new System.Drawing.Size(84, 21);
            this.chiphi.TabIndex = 113;
            this.chiphi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // bntra
            // 
            this.bntra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bntra.BackColor = System.Drawing.SystemColors.Info;
            this.bntra.Enabled = false;
            this.bntra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntra.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.bntra.Location = new System.Drawing.Point(569, 500);
            this.bntra.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.bntra.Name = "bntra";
            this.bntra.Size = new System.Drawing.Size(84, 21);
            this.bntra.TabIndex = 114;
            this.bntra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // bhyttra
            // 
            this.bhyttra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bhyttra.BackColor = System.Drawing.SystemColors.Info;
            this.bhyttra.Enabled = false;
            this.bhyttra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bhyttra.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.bhyttra.Location = new System.Drawing.Point(704, 500);
            this.bhyttra.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.bhyttra.Name = "bhyttra";
            this.bhyttra.Size = new System.Drawing.Size(84, 21);
            this.bhyttra.TabIndex = 115;
            this.bhyttra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // quyenso
            // 
            this.quyenso.BackColor = System.Drawing.SystemColors.HighlightText;
            this.quyenso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.quyenso.Enabled = false;
            this.quyenso.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quyenso.Location = new System.Drawing.Point(43, 7);
            this.quyenso.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.quyenso.Name = "quyenso";
            this.quyenso.Size = new System.Drawing.Size(61, 21);
            this.quyenso.TabIndex = 0;
            this.quyenso.Validated += new System.EventHandler(this.quyenso_Validated);
            // 
            // sobienlai
            // 
            this.sobienlai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sobienlai.Enabled = false;
            this.sobienlai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sobienlai.Location = new System.Drawing.Point(145, 7);
            this.sobienlai.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sobienlai.MaxLength = 7;
            this.sobienlai.Name = "sobienlai";
            this.sobienlai.Size = new System.Drawing.Size(56, 21);
            this.sobienlai.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(2, 489);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(790, 40);
            this.groupBox1.TabIndex = 118;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.listcachdung);
            this.groupBox2.Controls.Add(this.chkintrongngay);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.ngaynghi);
            this.groupBox2.Controls.Add(this.lbldungluc);
            this.groupBox2.Controls.Add(this.chkInchuathu);
            this.groupBox2.Controls.Add(this.chkKodichvu);
            this.groupBox2.Controls.Add(this.lTen);
            this.groupBox2.Controls.Add(this.cachdung);
            this.groupBox2.Controls.Add(this.butThem);
            this.groupBox2.Controls.Add(this.butXoa);
            this.groupBox2.Location = new System.Drawing.Point(2, 327);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(396, 165);
            this.groupBox2.TabIndex = 119;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thuốc";
            // 
            // chkintrongngay
            // 
            this.chkintrongngay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkintrongngay.AutoSize = true;
            this.chkintrongngay.Location = new System.Drawing.Point(104, 140);
            this.chkintrongngay.Name = "chkintrongngay";
            this.chkintrongngay.Size = new System.Drawing.Size(88, 17);
            this.chkintrongngay.TabIndex = 1022;
            this.chkintrongngay.Text = "In trong ngày";
            this.chkintrongngay.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            this.label28.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label28.Location = new System.Drawing.Point(-2, 136);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(61, 23);
            this.label28.TabIndex = 1021;
            this.label28.Text = "Ngày nghỉ";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ngaynghi
            // 
            this.ngaynghi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ngaynghi.Enabled = false;
            this.ngaynghi.Location = new System.Drawing.Point(62, 138);
            this.ngaynghi.Name = "ngaynghi";
            this.ngaynghi.Size = new System.Drawing.Size(37, 20);
            this.ngaynghi.TabIndex = 1020;
            // 
            // lbldungluc
            // 
            this.lbldungluc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbldungluc.Location = new System.Drawing.Point(0, 85);
            this.lbldungluc.Name = "lbldungluc";
            this.lbldungluc.Size = new System.Drawing.Size(61, 23);
            this.lbldungluc.TabIndex = 1019;
            this.lbldungluc.Text = "Sau ăn";
            this.lbldungluc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkInchuathu
            // 
            this.chkInchuathu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkInchuathu.AutoSize = true;
            this.chkInchuathu.Location = new System.Drawing.Point(209, 132);
            this.chkInchuathu.Name = "chkInchuathu";
            this.chkInchuathu.Size = new System.Drawing.Size(133, 17);
            this.chkInchuathu.TabIndex = 238;
            this.chkInchuathu.Text = "Chỉ in chi phí chưa thu";
            this.chkInchuathu.UseVisualStyleBackColor = true;
            // 
            // chkKodichvu
            // 
            this.chkKodichvu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkKodichvu.AutoSize = true;
            this.chkKodichvu.Location = new System.Drawing.Point(209, 114);
            this.chkKodichvu.Name = "chkKodichvu";
            this.chkKodichvu.Size = new System.Drawing.Size(183, 17);
            this.chkKodichvu.TabIndex = 236;
            this.chkKodichvu.Text = "Không in chi phí chênh lệch CLS";
            this.chkKodichvu.UseVisualStyleBackColor = true;
            this.chkKodichvu.CheckedChanged += new System.EventHandler(this.chkKodichvu_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.chkInbienlai_kquyensoKbienlai);
            this.groupBox3.Controls.Add(this.chkds);
            this.groupBox3.Controls.Add(this.chkXML);
            this.groupBox3.Controls.Add(this.timkiem);
            this.groupBox3.Controls.Add(this.chkXem);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Location = new System.Drawing.Point(400, 326);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(392, 166);
            this.groupBox3.TabIndex = 120;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dịch vụ";
            // 
            // chkInbienlai_kquyensoKbienlai
            // 
            this.chkInbienlai_kquyensoKbienlai.AutoSize = true;
            this.chkInbienlai_kquyensoKbienlai.Location = new System.Drawing.Point(104, 147);
            this.chkInbienlai_kquyensoKbienlai.Name = "chkInbienlai_kquyensoKbienlai";
            this.chkInbienlai_kquyensoKbienlai.Size = new System.Drawing.Size(227, 17);
            this.chkInbienlai_kquyensoKbienlai.TabIndex = 238;
            this.chkInbienlai_kquyensoKbienlai.Text = "In biên lai không cần quyển sổ, số biên lai ";
            this.chkInbienlai_kquyensoKbienlai.UseVisualStyleBackColor = true;
            // 
            // chkds
            // 
            this.chkds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkds.AutoSize = true;
            this.chkds.Checked = true;
            this.chkds.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkds.Location = new System.Drawing.Point(1, 135);
            this.chkds.Name = "chkds";
            this.chkds.Size = new System.Drawing.Size(103, 17);
            this.chkds.TabIndex = 237;
            this.chkds.Text = "Load danh sách";
            this.chkds.UseVisualStyleBackColor = true;
            this.chkds.Click += new System.EventHandler(this.chkds_Click);
            // 
            // chkXML
            // 
            this.chkXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkXML.AutoSize = true;
            this.chkXML.Location = new System.Drawing.Point(291, 109);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(85, 17);
            this.chkXML.TabIndex = 235;
            this.chkXML.Text = "Xuất ra XML";
            this.chkXML.UseVisualStyleBackColor = true;
            // 
            // timkiem
            // 
            this.timkiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.timkiem.BackColor = System.Drawing.SystemColors.HighlightText;
            this.timkiem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timkiem.ForeColor = System.Drawing.Color.Red;
            this.timkiem.Location = new System.Drawing.Point(55, 64);
            this.timkiem.Name = "timkiem";
            this.timkiem.Size = new System.Drawing.Size(333, 21);
            this.timkiem.TabIndex = 233;
            this.timkiem.Text = "Tìm kiếm";
            this.timkiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.timkiem.Enter += new System.EventHandler(this.timkiem_Enter);
            this.timkiem.TextChanged += new System.EventHandler(this.timkiem_TextChanged);
            // 
            // chkXem
            // 
            this.chkXem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkXem.AutoSize = true;
            this.chkXem.Location = new System.Drawing.Point(291, 93);
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(102, 17);
            this.chkXem.TabIndex = 236;
            this.chkXem.Text = "Xem trước khi in";
            this.chkXem.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(120, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 23);
            this.label5.TabIndex = 122;
            this.label5.Text = "Tên :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label24.Location = new System.Drawing.Point(236, 41);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(56, 23);
            this.label24.TabIndex = 125;
            this.label24.Text = "Số tiền :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(426, 345);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 23);
            this.label3.TabIndex = 121;
            this.label3.Text = "Mã :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.Location = new System.Drawing.Point(402, 366);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 23);
            this.label15.TabIndex = 123;
            this.label15.Text = "Số lượng :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.Location = new System.Drawing.Point(498, 367);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(56, 23);
            this.label20.TabIndex = 124;
            this.label20.Text = "Đơn giá :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mavp
            // 
            this.mavp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mavp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mavp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mavp.Enabled = false;
            this.mavp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mavp.Location = new System.Drawing.Point(455, 344);
            this.mavp.Name = "mavp";
            this.mavp.Size = new System.Drawing.Size(51, 21);
            this.mavp.TabIndex = 27;
            this.mavp.TextChanged += new System.EventHandler(this.mavp_TextChanged);
            this.mavp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mavp_KeyDown);
            // 
            // tenvp
            // 
            this.tenvp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tenvp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenvp.Enabled = false;
            this.tenvp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenvp.Location = new System.Drawing.Point(550, 345);
            this.tenvp.Name = "tenvp";
            this.tenvp.Size = new System.Drawing.Size(196, 21);
            this.tenvp.TabIndex = 28;
            this.tenvp.Validated += new System.EventHandler(this.tenvp_Validated);
            this.tenvp.TextChanged += new System.EventHandler(this.tenvp_TextChanged);
            this.tenvp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenvp_KeyDown);
            // 
            // dvt
            // 
            this.dvt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dvt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dvt.Enabled = false;
            this.dvt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dvt.Location = new System.Drawing.Point(747, 345);
            this.dvt.Mask = "";
            this.dvt.MaxLength = 10;
            this.dvt.Name = "dvt";
            this.dvt.Size = new System.Drawing.Size(40, 21);
            this.dvt.TabIndex = 29;
            // 
            // soluongvp
            // 
            this.soluongvp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.soluongvp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluongvp.Enabled = false;
            this.soluongvp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluongvp.Location = new System.Drawing.Point(455, 367);
            this.soluongvp.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.soluongvp.Name = "soluongvp";
            this.soluongvp.Size = new System.Drawing.Size(52, 21);
            this.soluongvp.TabIndex = 30;
            this.soluongvp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soluongvp.Validated += new System.EventHandler(this.soluongvp_Validated);
            // 
            // dongiavp
            // 
            this.dongiavp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dongiavp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dongiavp.Enabled = false;
            this.dongiavp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dongiavp.Location = new System.Drawing.Point(550, 367);
            this.dongiavp.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.dongiavp.Name = "dongiavp";
            this.dongiavp.Size = new System.Drawing.Size(97, 21);
            this.dongiavp.TabIndex = 31;
            this.dongiavp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // sotienvp
            // 
            this.sotienvp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sotienvp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sotienvp.Enabled = false;
            this.sotienvp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sotienvp.Location = new System.Drawing.Point(691, 367);
            this.sotienvp.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sotienvp.Name = "sotienvp";
            this.sotienvp.Size = new System.Drawing.Size(96, 21);
            this.sotienvp.TabIndex = 32;
            this.sotienvp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // butThemvp
            // 
            this.butThemvp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butThemvp.Enabled = false;
            this.butThemvp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThemvp.Location = new System.Drawing.Point(501, 446);
            this.butThemvp.Name = "butThemvp";
            this.butThemvp.Size = new System.Drawing.Size(60, 23);
            this.butThemvp.TabIndex = 33;
            this.butThemvp.Text = "&Dịch vụ";
            this.butThemvp.Click += new System.EventHandler(this.butThemvp_Click);
            // 
            // butXoavp
            // 
            this.butXoavp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butXoavp.Enabled = false;
            this.butXoavp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXoavp.Location = new System.Drawing.Point(563, 446);
            this.butXoavp.Name = "butXoavp";
            this.butXoavp.Size = new System.Drawing.Size(60, 23);
            this.butXoavp.TabIndex = 34;
            this.butXoavp.Text = "Xóa";
            this.butXoavp.Click += new System.EventHandler(this.butXoavp_Click);
            // 
            // butDichvu
            // 
            this.butDichvu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butDichvu.Enabled = false;
            this.butDichvu.Image = global::Duoc.Properties.Resources.F3;
            this.butDichvu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDichvu.Location = new System.Drawing.Point(625, 446);
            this.butDichvu.Name = "butDichvu";
            this.butDichvu.Size = new System.Drawing.Size(64, 23);
            this.butDichvu.TabIndex = 35;
            this.butDichvu.Text = "Liệt kê";
            this.butDichvu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butDichvu.Click += new System.EventHandler(this.butDichvu_Click);
            // 
            // sttvp
            // 
            this.sttvp.Location = new System.Drawing.Point(496, 276);
            this.sttvp.Name = "sttvp";
            this.sttvp.Size = new System.Drawing.Size(24, 20);
            this.sttvp.TabIndex = 126;
            // 
            // listVP
            // 
            this.listVP.BackColor = System.Drawing.SystemColors.Info;
            this.listVP.ColumnCount = 0;
            this.listVP.Location = new System.Drawing.Point(640, 544);
            this.listVP.MatchBufferTimeOut = 1000;
            this.listVP.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listVP.Name = "listVP";
            this.listVP.Size = new System.Drawing.Size(75, 17);
            this.listVP.TabIndex = 127;
            this.listVP.TextIndex = -1;
            this.listVP.TextMember = null;
            this.listVP.ValueIndex = -1;
            this.listVP.Visible = false;
            this.listVP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listVP_KeyDown);
            // 
            // butinBL
            // 
            this.butinBL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butinBL.Image = global::Duoc.Properties.Resources.VIENPHI;
            this.butinBL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butinBL.Location = new System.Drawing.Point(579, 533);
            this.butinBL.Name = "butinBL";
            this.butinBL.Size = new System.Drawing.Size(70, 25);
            this.butinBL.TabIndex = 43;
            this.butinBL.Text = "In biên lai";
            this.butinBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butinBL.Click += new System.EventHandler(this.butinBL_Click);
            // 
            // giaban
            // 
            this.giaban.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.giaban.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giaban.Enabled = false;
            this.giaban.Location = new System.Drawing.Point(148, 369);
            this.giaban.Name = "giaban";
            this.giaban.Size = new System.Drawing.Size(111, 20);
            this.giaban.TabIndex = 21;
            this.giaban.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // sotienmua
            // 
            this.sotienmua.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sotienmua.Enabled = false;
            this.sotienmua.Location = new System.Drawing.Point(208, 264);
            this.sotienmua.Name = "sotienmua";
            this.sotienmua.Size = new System.Drawing.Size(104, 20);
            this.sotienmua.TabIndex = 232;
            // 
            // butTreem
            // 
            this.butTreem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTreem.Image = global::Duoc.Properties.Resources.F9;
            this.butTreem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTreem.Location = new System.Drawing.Point(648, 533);
            this.butTreem.Name = "butTreem";
            this.butTreem.Size = new System.Drawing.Size(76, 25);
            this.butTreem.TabIndex = 234;
            this.butTreem.Text = "In &chi phí";
            this.butTreem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butTreem.Click += new System.EventHandler(this.butTreem_Click);
            // 
            // butList
            // 
            this.butList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butList.Image = global::Duoc.Properties.Resources.chonkhoa;
            this.butList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butList.Location = new System.Drawing.Point(0, 533);
            this.butList.Name = "butList";
            this.butList.Size = new System.Drawing.Size(77, 25);
            this.butList.TabIndex = 235;
            this.butList.Text = "Danh sách";
            this.butList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butList.Click += new System.EventHandler(this.butList_Click);
            // 
            // cbTraituyen
            // 
            this.cbTraituyen.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbTraituyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTraituyen.DropDownWidth = 150;
            this.cbTraituyen.Enabled = false;
            this.cbTraituyen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTraituyen.Items.AddRange(new object[] {
            "0. Đúng tuyến",
            "1. Trái tuyến"});
            this.cbTraituyen.Location = new System.Drawing.Point(344, 31);
            this.cbTraituyen.Name = "cbTraituyen";
            this.cbTraituyen.Size = new System.Drawing.Size(54, 21);
            this.cbTraituyen.TabIndex = 236;
            this.cbTraituyen.TabStop = false;
            // 
            // frmHoadonbhyt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.cbTraituyen);
            this.Controls.Add(this.butList);
            this.Controls.Add(this.butTreem);
            this.Controls.Add(this.giaban);
            this.Controls.Add(this.butinBL);
            this.Controls.Add(this.listVP);
            this.Controls.Add(this.butDichvu);
            this.Controls.Add(this.butXoavp);
            this.Controls.Add(this.butThemvp);
            this.Controls.Add(this.sotienvp);
            this.Controls.Add(this.dongiavp);
            this.Controls.Add(this.soluongvp);
            this.Controls.Add(this.dvt);
            this.Controls.Add(this.tenvp);
            this.Controls.Add(this.mavp);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.sobienlai);
            this.Controls.Add(this.quyenso);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.bhyttra);
            this.Controls.Add(this.bntra);
            this.Controls.Add(this.chiphi);
            this.Controls.Add(this.cls);
            this.Controls.Add(this.thuoc);
            this.Controls.Add(this.congkham);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.maicd);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.chandoan);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.tenkp);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.mabv);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.butDuyet);
            this.Controls.Add(this.listICD);
            this.Controls.Add(this.listDMBS);
            this.Controls.Add(this.listBTDKP);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.listDstt);
            this.Controls.Add(this.tenbv);
            this.Controls.Add(this.maphu);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.cmbSophieu);
            this.Controls.Add(this.sophieu);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.tenbd);
            this.Controls.Add(this.dang);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.soluong);
            this.Controls.Add(this.sotien);
            this.Controls.Add(this.mabd);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lMabd);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.listDMBD);
            this.Controls.Add(this.stt);
            this.Controls.Add(this.sttt);
            this.Controls.Add(this.ngaysp);
            this.Controls.Add(this.makho);
            this.Controls.Add(this.nhomcc);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.losx);
            this.Controls.Add(this.handung);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.sttvp);
            this.Controls.Add(this.sotienmua);
            this.Controls.Add(this.dongia);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmHoadonbhyt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu xuất bảo hiểm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmHoadonbhyt_KeyDown);
            this.Load += new System.EventHandler(this.frmHoadonbhyt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ngaynghi)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmHoadonbhyt_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = d.user; xxx = user + d.mmyy(s_ngay); yyy = user + s_mmyy;
            //
            m.f_taoview_bhyt(s_ngay);
            m.f_taoview_pk_cc_ngtru_ntru(s_ngay);
            s_idcomputer = m.get_dmcomputer(System.Environment.MachineName).ToString().PadLeft(4, '0');
            f_load_option();
            //
            bIncstt = d.bIncstt(i_nhom);
            songayduyet = d.songayduyet(i_nhom);//chon ben duoc
            int ikhoangcachngaycaptoa = m.iKhoangcachngaycaptoa_voingaykham;//tuy chon nay chon ben medisoft
            songayduyet = (songayduyet > ikhoangcachngaycaptoa) ? songayduyet : ikhoangcachngaycaptoa;//lay max cua 2 khoang cach

            lTraituyen = (m.bTraituyen) ? m.lTraituyen_phongkham : 0;
            iTraituyen = (m.bTraituyen) ? m.iTraituyen_bhyt : 0;
            s_tu = m.DateToString("dd/MM/yyyy", m.StringToDate(s_ngay).AddDays(-1 * songayduyet));
            s_den = s_ngay; stime = "'dd/mm/yyyy'";
            i_tunguyen = m.iTunguyen; s_chenhlech = "";
            bkhongChoDuyetToaBNHen_E8 = d.bkhongChoDuyetToaBNHen_E8(i_nhom);
            //chkds.Checked = d.Thongso("duyetbhyt_loadds") == "1";
            foreach (DataRow r in d.get_data("select * from " + user + ".doituong").Tables[0].Rows)
            {
                if (int.Parse(r["madoituong"].ToString()) == i_tunguyen)
                {
                    s_tunguyen = r["doituong"].ToString();
                    fie_tunguyen = r["field_gia"].ToString();
                }
                if (int.Parse(r["chenhlech"].ToString())==1) s_chenhlech+=r["madoituong"].ToString().PadLeft(2,'0')+",";
            }
            bChenhlech = m.bChenhlech;
            bchenhlech_thuoc = (bChenhlech) ? m.bChenhlech_thuoc : false;
            bChenhlech_thuoc_dannhmuc = (bchenhlech_thuoc) ? m.bChenhlech_thuoc_dannhmuc : false;
            bGia_bh_quydinh_giamua = m.bGia_bh_quydinh_giamua;
            //gam 05/11/2011
            bDuyet_khambenh = m.bDuyet_khambenh;
            bDuyet_donvepl = m.bDuyet_donvepl;
            //end gam
            bGia_bh_quydinh = m.bGia_bh_quydinh;
            DateTime dt = d.StringToDate(s_ngay.Substring(0, 10));
            string ddd = dt.DayOfWeek.ToString().Substring(0, 3);
            Bhyt_7cn = (m.getLetet(s_ngay) || ddd == "Sat" || ddd == "Sun") ? m.Bhyt_7cn : 0;
            bChuyenkham_congkham = d.bChuyenkham_congkham(i_nhom);
            bInchiphi_chandoan_bacsy = d.bInchiphi_chandoan_bacsy(i_nhom);
            chkXem.Checked = d.bPreview;
			if (i_madoituong==1) bGiaban=d.get_data("select * from "+user+".d_doituong where loai=1 and madoituong="+i_madoituong).Tables[0].Rows.Count>0;
			i_bhyt_inrieng=d.iBhyt_inrieng(i_nhom);
			bDenngay_sothe=m.bDenngay_sothe;
            iMavp_congkham = d.iMavp_congkham(i_nhom);
			bIn_Nhomvp=d.bInBHYT_nhomvp(i_nhom);
            
            sql = "select a.id,a.ma,a.ten,a.dvt,b.stt as sttloai,b.ten as loai,c.stt as sttnhom,c.ten as nhom, a.bhyt, a.kcct, case when a.kythuat is null then -1 else a.kythuat end as kythuat, a.bhyt_tt, c.idnhombhyt, d.stt as sttbhyt, d.ten tennhombhyt";
            sql += " ,a.sothe ";//gam 16/08/2011
            sql += " from " + user + ".v_giavp a left join " + user + ".v_loaivp b on a.id_loai=b.id left join " + user + ".v_nhomvp c on b.id_nhom=c.ma left join " + user + ".v_nhombhyt d on c.idnhombhyt=d.id";			
			dtvpin=m.get_data(sql).Tables[0];

            dtdtf = d.get_data("select * from " + user + ".d_doituong").Tables[0];
                        
			sql="select a.id,a.ma,trim(a.ten)||' '||trim(a.hamluong)||' ['||trim(b.ten)||']' as ten,";
            sql += "a.dang as dvt,c.stt as sttloai,c.ten as loai,d.stt as sttnhom,d.ten as nhom, a.bhyt, a.kcct, case when a.kythuat is null then -1 else a.kythuat end as kythuat, a.bhyt as bhyt_tt, d.idnhombhyt, e.stt as sttbhyt, e.ten tennhombhyt ";
            sql += " , '' as sothe ";//gam 16/08/2011
            sql += " from " + user + ".d_dmbd a left join " + user + ".d_dmhang b on  a.mahang=b.id left join " + user + ".d_dmnhom c on a.manhom=c.id left join " + user + ".v_nhomvp d on c.nhomvp=d.ma left join " + user + ".v_nhombhyt e on d.idnhombhyt=e.id ";			
			dtbd=m.get_data(sql).Tables[0];

			bLoc=d.bLoc_bhyt(i_nhom);
			format_sotien=d.format_sotien(i_nhom);
			format_dongia=d.format_dongia(i_nhom);
			format_soluong=d.format_soluong(i_nhom);

            string tmp_ngay=s_ngay;
            int _userid = -1;
            if (d.bSophieu_mau38_tangtheonam(i_nhom) )
            {
                tmp_ngay ="31/12/20" + s_mmyy.Substring(2, 2);
                //
                d.upd_capsotoa(-99, tmp_ngay, 0, _userid);
                d.upd_capsotoa(-99, tmp_ngay, 1, _userid);
                d.upd_capsotoa(2, tmp_ngay, 0);
                d.upd_capsotoa(2, tmp_ngay, 1);
            }
            else if (d.bSophieu_mau38_tangtheonam_tinhtuthang12(i_nhom))
            {
                tmp_ngay = d.get_ngaytao_solieu_thangmoi("01"+ s_mmyy.Substring(2,2), i_nhom);
                //
                d.upd_capsotoa(-99, tmp_ngay, 0, _userid);
                d.upd_capsotoa(-99, tmp_ngay, 1, _userid);
                d.upd_capsotoa(2, tmp_ngay, 0);
                d.upd_capsotoa(2, tmp_ngay, 1);
            }
            else
            {
                if (d.bSophieu_mau38_tangtheothang(i_nhom)) tmp_ngay = "01/" + s_mmyy.Substring(0, 2) + "/20" + s_mmyy.Substring(2, 2);
                else if (d.bSophieu_mau38_tangtheothang_tinhtuthangtruoc(i_nhom))
                {
                    //int tmp_mm = int.Parse(s_mmyy.Substring(0, 2));
                    //int tmp_yy = int.Parse(s_mmyy.Substring(2, 2));
                    //if (tmp_mm == 1) { tmp_mm = 12; tmp_yy = tmp_yy - 1; }
                    //else tmp_mm = tmp_mm - 1;
                    tmp_ngay = d.get_ngaytao_solieu_thangmoi(s_mmyy, i_nhom); //d.iNgaytinh_Sophieu_mau38_tangthang(i_nhom).ToString().PadLeft(2, '0') + "/" + tmp_mm.ToString().PadLeft(2, '0') + "/20" + tmp_yy.ToString().PadLeft(2, '0');
                }
                d.upd_capsotoa(s_mmyy, -99, tmp_ngay, 0, _userid);
                d.upd_capsotoa(s_mmyy, -99, tmp_ngay, 1, _userid);
                d.upd_capsotoa(s_mmyy, 2, tmp_ngay, 0);
                d.upd_capsotoa(s_mmyy, 2, tmp_ngay, 1);
            }
            
            ngay_reset_phieu38 = tmp_ngay;
            //
			bMabn=d.bMabn_bhyt(i_nhom);
			bTiepdon=m.bTiepdon(LibMedi.AccessData.Duoc);
			bThongbao=d.bThongbao_bhyt(i_nhom);
			bChandoan=d.bChandoan_bhyt(i_nhom);
			bCongkham=d.bcongkham_bhyt(i_nhom);
			bSotien=d.bSotien_bhyt(i_nhom);
			dsxml.ReadXml("..\\..\\..\\xml\\v_bienlai.xml");
			dslien.ReadXml("..\\..\\..\\xml\\v_lien.xml");
			bSobienlai=m.bSobienlai;
			d_congkham=d.Congkham(i_nhom);
            dtqs = d.get_data("select * from " + user + ".v_quyenso").Tables[0];
			bQuyenso=d.bQuyenso(i_nhom);
			bKhoaso=d.bKhoaso(i_nhom,s_mmyy);
			i_songay=d.Ngaylv_Ngayht;
			s_makho=d.get_dmkho(i_loai).Trim();
			s_makho=(s_makho=="")?"":s_makho.Substring(0,s_makho.Length-1);
			s_manguon=d.get_manguon(i_loai).Trim();
			s_manguon=(s_manguon=="")?"":s_manguon.Substring(0,s_manguon.Length-1);

			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			if (d.bQuanlynguon(i_nhom))
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where nhom=" + i_nhom + " order by stt").Tables[0];
			else
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where id=0 or nhom=" + i_nhom + " order by stt").Tables[0];

			nhomcc.DisplayMember="TEN";
			nhomcc.ValueMember="ID";
			if (d.bQuanlynhomcc(i_nhom))
                nhomcc.DataSource = d.get_data("select * from " + user + ".d_dmnx where nhom=" + i_nhom + " order by stt").Tables[0];
			else
                nhomcc.DataSource = d.get_data("select * from " + user + ".d_dmnx where id=0 or nhom=" + i_nhom + " order by stt").Tables[0];

			makho.DisplayMember="TEN";
			makho.ValueMember="ID";
            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
			if (s_kho!="") sql+=" and id in ("+s_kho.Substring(0,s_kho.Length-1)+")";
            if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ")";//binh 210411
			sql+=" order by stt";
			makho.DataSource=d.get_data(sql).Tables[0];

            string s = "";
            sql = "select * from "+user+".doituong ";
            if (i_loaiba != (int)LibMedi.LoaiBenhAn.Ngoaitru) //if (i_loaiba != 2)
            {
                if (i_madoituong == 1) sql += " where madoituong=1";
                else
                {
                    sql += "where madoituong<>1";
                    foreach (DataRow r in d.get_data("select madoituong from " + user + ".d_dmphieu where id=" + i_loai).Tables[0].Rows) s = r["madoituong"].ToString().Trim();
                    if (i_loai == (int)LibMedi.NhomPhieuLinh_CapToa.CaptoaThuocChuongTrinh) s = s.Contains("3") ? s.Trim() : s.Trim() +"3,";
                    if (s.Trim().Trim(',') != "") sql += " and madoituong in (" + s.Trim().Trim(',') + ")";
                    
                }
            }
            else
            {
                foreach (DataRow r in d.get_data("select madoituong from " + user + ".d_dmphieu where id=" + i_loai).Tables[0].Rows) s = r["madoituong"].ToString().Trim();
                if (s != "") sql += " where madoituong in (" + s.Substring(0, s.Length - 1) + ")";
            }
            sql += "order by madoituong";
			dtdt=d.get_data(sql).Tables[0];
			maphu.DisplayMember="DOITUONG";
			maphu.ValueMember="MADOITUONG";
			maphu.DataSource=dtdt;

            dtdstt = d.get_data("select * from " + user + ".dmnoicapbhyt order by mabv").Tables[0];
			listDstt.DisplayMember="MABV";
			listDstt.ValueMember="TENBV";
			listDstt.DataSource=dtdstt;

			listICD.DisplayMember="CICD10";
			listICD.ValueMember="VVIET";
            dticd = d.get_data("select cicd10,vviet from " + user + ".icd10 order by cicd10").Tables[0];
			listICD.DataSource=dticd;

			listDMBS.DisplayMember="MA";
			listDMBS.ValueMember="HOTEN";
            dtbs = d.get_data("select ma,hoten from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nhanvien + "," + LibMedi.AccessData.nghiviec + ") order by hoten").Tables[0];
			listDMBS.DataSource=dtbs;

			listBTDKP.DisplayMember="MAKP";
			listBTDKP.ValueMember="TENKP";
            dtkp = d.get_data("select makp,tenkp,loaivp,mucvp from " + user + ".btdkp_bv order by tenkp").Tables[0];
			listBTDKP.DataSource=dtkp;

            dtdmvp = d.get_data("select a.ma,a.ten,a.dvt,a.id,a.gia_bh+a.vattu_bh as dongia from " + user + ".v_giavp a," + user + ".v_loaivp b where a.id_loai=b.id and a.bhyt<>0 order by b.stt,a.stt").Tables[0];
			listVP.DisplayMember="TEN";
			listVP.ValueMember="ID";
			listVP.DataSource=dtdmvp;

			listDMBD.DisplayMember="TEN";
			listDMBD.ValueMember="STT";

			listcachdung.DisplayMember="STT";
			listcachdung.ValueMember="TEN";

            load_list();
			cmbSophieu.DisplayMember="MABN";
			cmbSophieu.ValueMember="ID";
			
            l_id = (cmbSophieu.SelectedIndex != -1) ? decimal.Parse(cmbSophieu.SelectedValue.ToString()) : 0;
			load_head();
			AddGridTableStyle();
			AddGridTableStyle1();
			dsxoa.ReadXml("..\\..\\..\\xml\\d_bhytthuoc.xml");
			dsxoavp.ReadXml("..\\..\\..\\xml\\d_bhytcls.xml");
			dsxmlin.ReadXml("..\\..\\..\\xml\\m_inravien.xml");
            dsxmlin.Tables[0].Columns.Add("Image", typeof(byte[]));
            dsxmlin.Tables[0].Columns.Add("Imagetk", typeof(byte[]));
            dsxmlin.Tables[0].Columns.Add("Imageuser", typeof(byte[]));
            dsxmlin.Tables[0].Columns.Add("mabs");
            dsxmlin.Tables[0].Columns.Add("tenbs");
            dsxmlin.Tables[0].Columns.Add("makprv");
            dsxmlin.Tables[0].Columns.Add("tenuser");
            dsxmlin.Tables[0].Columns.Add("cholam");
            dsxmlin.Tables[0].Columns.Add("madt", typeof(decimal));
            dsxmlin.Tables[0].Columns.Add("haophi", typeof(decimal));
            dsxmlin.Tables[0].Columns.Add("gianovat", typeof(decimal));
            dsxmlin.Tables[0].Columns.Add("idttrv", typeof(decimal));
            dsxmlin.Tables[0].Columns.Add("sotientra", typeof(decimal));
            dsxmlin.Tables[0].Columns.Add("traituyen",typeof(decimal));
            dsxmlin.Tables[0].Columns.Add("kythuat", typeof(decimal));
            dsxmlin.Tables[0].Columns.Add("loaikythuat", typeof(string));

            dsxmlin.Tables[0].Columns.Add("sttbhyt", typeof(decimal)).DefaultValue = 0;
            dsxmlin.Tables[0].Columns.Add("idnhombhyt", typeof(decimal)).DefaultValue=0;
            dsxmlin.Tables[0].Columns.Add("tennhombhyt", typeof(string));
            //
            dsxmlin.Tables[0].Columns.Add("sotoa", typeof(string));
            //
            butHuy.Enabled = bThuhoi;
            string vitri = d.thetunguyen_vitri_ora(m.nhom_duoc);
            if (vitri.Length == 3)
            {
                v1 = int.Parse(vitri.Substring(0, 1)); v2 = int.Parse(vitri.Substring(2, 1));
            }
		}

        private void load_list()
        {
            // hien: them ngay nghi
            sql = "select distinct a.id,a.mabn,a.mavaovien,a.maql,b.hoten,b.namsinh,to_char(a.ngay,'dd/mm/yyyy') as ngay,b.diachi,";
            sql += " a.makp,a.chandoan,a.maicd,a.mabs,a.sothe,a.maphu,a.mabv,a.sobienlai,a.quyenso,a.congkham,";
            sql += " a.thuoc,a.cls,a.congkham+a.thuoc+a.cls as chiphi,a.bntra,a.bhyttra,a.sotoa,";
            sql += " to_char(c.tungay,'dd/mm/yyyy') as tungay,to_char(c.denngay,'dd/mm/yyyy') as denngay, ";
            sql += " to_char(c.ngay1,'dd/mm/yyyy') as ngay1,to_char(c.ngay2,'dd/mm/yyyy') as ngay2,to_char(c.ngay3,'dd/mm/yyyy') as ngay3,a.traituyen,a.ngaynghi";
            sql += " from " + yyy + ".bhytkb a inner join " + yyy + ".bhytds b on a.mabn=b.mabn left join " + yyy + ".bhyt c "; //" + yyy + ".bhyt c ";
            sql += " on a.maql=c.maql ";
            if (i_quyen_duyetmau38 == 1)//chi duyet thuoc
                sql += " inner join " + yyy + ".bhytthuoc t on a.id=t.id ";
            else if (i_quyen_duyetmau38 == 2)//chi duyet CLS
                sql += " inner join " + yyy + ".bhytcls t on a.id=t.id ";
            sql += " where a.nhom=" + i_nhom;
            if (i_loaiba == 2) sql += " and a.loaiba=2";
            else
            {
                sql += " and a.loaiba<>2";
                if (i_madoituong == 1) sql += " and a.maphu=1";
                else sql += " and a.maphu<>1";
            }
            if (bLoc) sql += " and a.userid=" + i_userid;
            if (d.bLocbaohiem) sql += " and to_char(a.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
            if (bChuahoantatkham) sql += " and a.bove=1";
            else sql += " and a.bove=0";
            sql += " order by a.id";
            dtll = d.get_data(sql).Tables[0];
            cmbSophieu.DataSource = dtll;
            chkKodichvu.Checked=d.Thongso("Kodichvu")=="1";
        }

		private void load_grid()
		{
			dataGrid1.DataSource=null;
			dataGrid2.DataSource=null;
			sql="select a.stt,a.sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,e.ten as tenkho,c.ten as tennguon,d.ten as tennhomcc,t.handung,t.losx,a.soluong,";
            sql += "t.giamua as dongia,a.soluong*t.giamua as sotienmua,";
            
            if (bGiaban && i_madoituong != 1) sql += " t.giaban,a.soluong*t.giaban as sotien,";
            else
            {
                if (bGia_bh_quydinh && bLaygiamua_khi_giabh_0_giabh_nho_giamua) sql += "(case when a.gia_bh=0 or t.giamua<a.gia_bh then t.giamua else a.gia_bh end) as giaban,(case when a.gia_bh=0 or t.giamua<a.gia_bh then t.giamua else a.gia_bh end)*a.soluong as sotien,";
                else if (bGia_bh_quydinh && bLaygiamua_khi_giabh_0_giabh_nho_giamua == false) sql += "a.gia_bh as giaban,a.gia_bh*a.soluong as sotien,";
                else sql += "" + (bGiaban ? "t.giaban" : "t.giamua") + " as giaban,a.soluong*" + (bGiaban ? "t.giaban" : "t.giamua") + " as sotien,";
                //sql += " t.giamua as giaban,a.soluong*t.giamua as sotien,";
            }
			sql+="a.cachdung,a.makho,t.manguon,t.nhomcc,t.giamua, b.bhyt, b.bhyt as bhyt_tt ";
            sql+=" from " + yyy + ".bhytthuoc a," + user + ".d_dmbd b," + user + ".d_dmnguon c," + user + ".d_dmnx d," + user + ".d_dmkho e," + yyy + ".d_theodoi t where a.sttt=t.id and a.mabd=b.id and t.manguon=c.id and t.nhomcc=d.id and a.makho=e.id and a.id=" + l_id + " order by a.stt";
			dtct=d.get_data(sql).Tables[0];
			dataGrid1.DataSource=dtct;

            sql = "select a.stt,a.mavp,b.ma,b.ten,b.dvt,a.soluong,a.dongia,a.soluong*a.dongia as sotien,a.idchidinh, b.bhyt, b.bhyt_tt";
            sql += " from " + yyy + ".bhytcls a," + user + ".v_giavp b where a.mavp=b.id and a.id=" + l_id + " order by a.stt";
			dtvp=d.get_data(sql).Tables[0];
			dataGrid2.DataSource=dtvp;
            tinhtong();
		}

		private void ref_text()
		{
            try
            {
                int i = dataGrid1.CurrentCell.RowNumber;
                stt.Text = dataGrid1[i, 0].ToString();
                r = d.getrowbyid(dtct, "stt=" + int.Parse(stt.Text));
                if (r != null)
                {
                    mabd.Text = r["ma"].ToString();
                    tenbd.Text = r["ten"].ToString();
                    dang.Text = r["dang"].ToString();
                    handung.Text = r["handung"].ToString();
                    losx.Text = r["losx"].ToString();
                    d_soluong = (r["soluong"].ToString() != "") ? decimal.Parse(r["soluong"].ToString()) : 0;
                    d_dongia = (r["giaban"].ToString() != "") ? decimal.Parse(r["giaban"].ToString()) : 0;
                    giaban.Text = d_dongia.ToString(format_dongia);
                    d_dongia = (r["dongia"].ToString() != "") ? decimal.Parse(r["dongia"].ToString()) : 0;
                    d_sotien = (r["sotien"].ToString() != "") ? decimal.Parse(r["sotien"].ToString()) : 0;
                    soluong.Text = d_soluong.ToString(format_soluong);
                    dongia.Text = d_dongia.ToString(format_dongia);
                    sotien.Text = d_sotien.ToString(format_sotien);
                    cachdung.Text = r["cachdung"].ToString();
                    makho.SelectedValue = r["makho"].ToString();
                    manguon.SelectedValue = r["manguon"].ToString();
                    nhomcc.SelectedValue = r["nhomcc"].ToString();
                    sttt.Text = r["sttt"].ToString();
                    d_soluongcu = (bNew) ? 0 : d_soluong;                    
                    sotienmua.Text = r["sotienmua"].ToString();
                    if (butLuu.Enabled)
                    {
                        tenbd.Enabled = sttt.Text == "0";
                        if (d.bNhapmaso) mabd.Enabled = tenbd.Enabled;
                        soluong.Enabled = tenbd.Enabled;
                        cachdung.Enabled = tenbd.Enabled;
                    }
                }
            }
            catch { }
		}

		private void ref_text1()
		{
			try
			{
				int i=dataGrid2.CurrentCell.RowNumber;
				sttvp.Text=dataGrid2[i,0].ToString();
				r=d.getrowbyid(dtvp,"stt="+int.Parse(sttvp.Text));
				if (r!=null)
				{	  
					i_mavp=int.Parse(r["mavp"].ToString());
					mavp.Text=r["ma"].ToString();
					tenvp.Text=r["ten"].ToString();
					dvt.Text=r["dvt"].ToString();
					d_soluongvp=(r["soluong"].ToString()!="")?decimal.Parse(r["soluong"].ToString()):0;
					d_dongiavp=(r["dongia"].ToString()!="")?decimal.Parse(r["dongia"].ToString()):0;
					d_sotienvp=(r["sotien"].ToString()!="")?decimal.Parse(r["sotien"].ToString()):0;
					soluongvp.Text=d_soluongvp.ToString("###,##0");
					dongiavp.Text=d_dongiavp.ToString("###,###,###,##0");
					sotienvp.Text=d_sotienvp.ToString("###,###,###,##0");
					l_idchidinh=decimal.Parse(r["idchidinh"].ToString());
				}
			}
			catch{}
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
						
			DataGridTextBoxColumn TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "stt";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã số";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
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

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "soluong";
			TextCol.HeaderText = "Số lượng";
			TextCol.Width = 60;
			TextCol.Format=format_soluong;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = (bGiaban)?"giaban":"dongia";
			TextCol.HeaderText = "Đơn giá";
			TextCol.Width = 80;
			TextCol.Format=format_dongia;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sotien";
			TextCol.HeaderText = "Số tiền";
			TextCol.Width = 80;
			TextCol.Format=format_sotien;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "cachdung";
			TextCol.HeaderText = "Cách dùng";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);			
		}

		private void AddGridTableStyle1()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dtvp.TableName;
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
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã số";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên";
			TextCol.Width = 200;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dvt";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "soluong";
			TextCol.HeaderText = "Số lượng";
			TextCol.Width = 60;
			TextCol.Format="#,###,##0.00";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dongia";
			TextCol.HeaderText = "Đơn giá";
			TextCol.Width = 80;
			TextCol.Format="###,###,###,##0";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sotien";
			TextCol.HeaderText = "Số tiền";
			TextCol.Width = 80;
			TextCol.Format="###,###,###,##0.000";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);			
		}

		private void cmbSophieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) butMoi.Focus();
		}

		private void cmbSophieu_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cmbSophieu) 
			{
				try
				{
					l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
				}
				catch{l_id=0;}
				load_head();
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void Filter_dmvp(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listVP.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void Filter_dmbd(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDMBD.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="(soluong>0) and (ten like '%"+ten.Trim()+"%'"+" or tenhc like '%"+ten.Trim()+"%')";
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
				listDMBD.Tonkhoct(tenbd,mabd,soluong,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+tenbd.Width*3-20,mabd.Height+5);
			}
		}

		private void tenbd_Validated(object sender, System.EventArgs e)
		{
			if(!listDMBD.Focused) listDMBD.Hide();
		}

		private void ena_object(bool ena)
		{
			sophieu.Visible=ena;
			cmbSophieu.Visible=!ena;
            if (bMabn) sophieu.Enabled = ena;
            quyenso.Enabled = false;
            sobienlai.Enabled = false;
            if (bQuyenso)
            {
                quyenso.Enabled = ena;
                sobienlai.Enabled = ena;
            }
			hoten.Enabled=ena;
			diachi.Enabled=ena;
			namsinh.Enabled=ena;
			if (d.bBaobiem_makp) tenkp.Enabled=ena;
			if (d.bBaobiem_bacsi) tenbs.Enabled=ena;
			if (d.bBaohiem_icd) maicd.Enabled=ena;
			chandoan.Enabled=maicd.Enabled;
			if (!bChandoan) maicd.Enabled=false;
			makp.Enabled=tenkp.Enabled;
			mabs.Enabled=tenbs.Enabled;
			maphu.Enabled=ena;
			if (d.bSothe)
			{
				sothe.Enabled=ena;
				tenbv.Enabled=ena;
                //cbTraituyen.Enabled = ena;
			}
			if (!bCongkham)
			{
				if (d.bNhapmaso) mabd.Enabled=ena;
				congkham.Enabled=ena;
				tenbd.Enabled=ena;
				soluong.Enabled=ena;
				cachdung.Enabled=ena;
				butThem.Enabled=ena;
				butXoa.Enabled=ena;
			}
			mavp.Enabled=ena;
			tenvp.Enabled=ena;
			soluongvp.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butThemvp.Enabled=ena;
			butXoavp.Enabled=ena;
			butDichvu.Enabled=ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			if (bThuhoi) butHuy.Enabled=!ena;
            butList.Enabled = !ena;
			butIn.Enabled=!ena;
			butinBL.Enabled=!ena;
			butTreem.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			butDuyet.Enabled=!ena;
			i_old=cmbSophieu.SelectedIndex;
            if (ena) load_dm();
            //else
            //{
            timkiem.Text = "";
                CurrencyManager cm = (CurrencyManager)BindingContext[cmbSophieu.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "";
            //}
        }

		private void emp_head()
		{
			if (!quyenso.Enabled)
			{
				i_quyenso=0;
				quyenso.Text="";
			}
			else quyenso.Text=d.Thongso("c00").ToString();
			RefreshChildren("");
            l_id = 0; l_maql = 0; l_idchidinh = 0; l_mavaovien = 0;
			sophieu.Text="";
			ngaysp.Text=s_ngay;
			s_ngaysp=ngaysp.Text;
            traituyen = 0;
            hoten.Text = namsinh.Text = diachi.Text = cachdung.Text = sothe.Text = tenbv.Text = "";
			ngay1=ngay2=ngay3=s_tungay=s_denngay="";
            mabv.Text = tenbs.Text = mabs.Text = makp.Text = tenkp.Text = maicd.Text = timkiem.Text = chandoan.Text = "";
			sobienlai.Text="0";
            if (maphu.SelectedIndex != -1)
            {
                string so = m.sothe(int.Parse(maphu.SelectedValue.ToString()));
                sothe.Enabled = int.Parse(so.Substring(0, 2)) > 0;
            }
			if (bCongkham) congkham.Text="0";
			else congkham.Text=d_congkham.ToString("###,###,##0");
			thuoc.Text="0";cls.Text="0";bntra.Text="";chiphi.Text="0";bhyttra.Text="0";
			dtct.Clear();
			dtvp.Clear();
			dsxoa.Clear();
			dsxoavp.Clear();
		}
		
		private void emp_detail()
		{
            sttt.Text = mabd.Text = tenbd.Text = dang.Text = "";
            soluong.Text = dongia.Text = sotien.Text = giaban.Text = sotienmua.Text = "0";
            handung.Text = losx.Text = cachdung.Text = "";
			manguon.SelectedIndex=-1;
			nhomcc.SelectedIndex=-1;
			makho.SelectedIndex=-1;
			stt.Text=d.get_stt(dtct).ToString();
			d_soluongcu=0;
            lbldungluc.Text = "";
		}

		private void emp_detail1()
		{
            mavp.Text = tenvp.Text = sttvp.Text = "";
            soluongvp.Text = dongiavp.Text = sotienvp.Text = "0";
			sttvp.Text=d.get_stt(dtvp).ToString();
		}
		private void butMoi_Click(object sender, System.EventArgs e)
		{
			if (bKhoaso)
			{
				MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng")+" "+s_mmyy.Substring(0,2)+" "+lan.Change_language_MessageText("năm")+" "+s_mmyy.Substring(2,2)+" "+lan.Change_language_MessageText("đã khóa !")+"\n"+lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"),d.Msg);
				return;
			}
			bLoad=false;
			ena_object(true);
			dtvp.Clear();
			dtct.Clear();
			dtsave.Clear();
			emp_head();
			emp_detail();
			emp_detail1();
			bNew=true;
			bEdit=true;
            tmp_ngay = s_ngay;
			if (bQuyenso && quyenso.Text=="") quyenso.Focus();
            else if (bQuyenso == false)
            {
                sobienlai.Text="0";
                if (!bMabn)
                {
                    sql = " where nhom=" + i_nhom;
                    if (bLoc) sql += " and userid=" + i_userid;
                    if (i_loaiba != 2)
                    {
                        if (i_madoituong == 1) sql += " and maphu=1";
                        else sql += " and maphu<>1";
                    }
                    sql += " and loaiba=" + i_loaiba;
                    if (d.bLocbaohiem) sql += " and to_char(ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                    string s = (i_madoituong == 1) ? "B" : "T";
                    sophieu.Text = d.get_sophieu(s_mmyy, "bhytkb", "mabn", sql) + s + i_nhom.ToString().PadLeft(1, '0') + s_ngay.Substring(0, 2);//d.get_stt(dtll,"mabn").ToString().PadLeft(3,'0');
                }
                if (sophieu.Enabled) sophieu.Focus();
                else hoten.Focus();
            }
            else
            {
                if (quyenso.Text != "")
                {
                    r = d.getrowbyid(dtqs, "sohieu='" + quyenso.Text + "'");
                    if (r != null)
                    {
                        int iso = int.Parse(r["soghi"].ToString()) + 1;
                        i_quyenso = int.Parse(r["id"].ToString());
                        sobienlai.Text = iso.ToString();
                    }
                }
                else sobienlai.Text = d.get_stt(dtll, "sobienlai").ToString();
                sophieu.Focus();
            }
		}
		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (cmbSophieu.Items.Count==0) return;
			if (bKhoaso)
			{
				MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng")+" "+s_mmyy.Substring(0,2)+" "+lan.Change_language_MessageText("năm")+" "+s_mmyy.Substring(2,2)+" "+lan.Change_language_MessageText("đã khóa !")+"\n"+lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"),d.Msg);
				return;
			}
			l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
            if (d.get_sobienlai_bhytkb(s_mmyy, l_id))
            {
                MessageBox.Show(lan.Change_language_MessageText("Viện phí đã cập nhật!"), d.Msg);
                return;
            }
			if (d.get_done_bhytkb(s_mmyy,l_id))// && !bAdmin)
			{
				MessageBox.Show(lan.Change_language_MessageText("Thông tin này đã cập nhật!"),d.Msg);
				return;
			}
			ena_object(true);
			hoten.Enabled=false;
			sothe.Enabled=false;
			sophieu.Enabled=false;
			tenkp.Enabled=false;
			tenbs.Enabled=false;
			maicd.Enabled=false;
			chandoan.Enabled=false;
			bNew=false;
			bEdit=true;
			bLoad=false;
			dtsave=dtct.Copy();
			dsxoa.Clear();
            
            //dsxoa.Tables[0] = dtct.Copy();
			if (quyenso.Text=="" && bQuyenso) quyenso.Focus();
			else sobienlai.Focus();
			ref_text();
			ref_text1();
		}

		private bool KiemtraHead()
		{
			if (bQuyenso && quyenso.Enabled && quyenso.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập quyển sổ hóa đơn !"),d.Msg);
				quyenso.Focus();
				return false;
			}
			if (bQuyenso && (sobienlai.Text=="" || sobienlai.Text=="0"))
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập số biên lai !"),d.Msg);
				sobienlai.Focus();
				return false;
			}
			if (sophieu.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập mã số người bệnh !"),d.Msg);
				sophieu.Focus();
				return false;
			}
			if (ngaysp.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập ngày số phiếu !"),d.Msg);
				ngaysp.Focus();
				return false;
			}
			if (i_madoituong==1)
			{
				if (sothe.Enabled)
				{
					if (sothe.Text=="")
					{
						MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập số thẻ !"),d.Msg);
						sothe.Focus();
						return false;
					}
				}
				if (tenbv.Enabled)
				{
					r=d.getrowbyid(dtdstt,"mabv='"+mabv.Text+"'");
					if (r==null)
					{
						MessageBox.Show(lan.Change_language_MessageText("Tên nơi ĐKKCB không hợp lệ !"),d.Msg);
						tenbv.Focus();
						return false;
					}
				}
			}
			if (tenbs.Enabled)
			{
				r=d.getrowbyid(dtbs,"hoten='"+tenbs.Text+"'");
				if (r==null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Họ tên bác sĩ không hợp lệ !"),d.Msg);
					tenbs.Focus();
					return false;
				}
			}
			if (tenkp.Enabled)
			{
				r=d.getrowbyid(dtkp,"tenkp='"+tenkp.Text+"'");
				if (r==null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Phòng khám không hợp lệ !"),d.Msg);
					tenkp.Focus();
					return false;
				}
			}
			if (maicd.Enabled)
			{
				r=d.getrowbyid(dticd,"cicd10='"+maicd.Text+"'");
				if (r==null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"),d.Msg);
					chandoan.Focus();
					return false;
				}
			}
			if (!bNew && bSobienlai && bQuyenso)
			{
				r=d.getrowbyid(dtqs,"sohieu='"+quyenso.Text+"'");
				if (r!=null)
				{
					i_quyenso=int.Parse(r["id"].ToString());
					sobienlai.Text=m.get_sobienlai(i_quyenso,1).ToString();
					int so=int.Parse(sobienlai.Text);
					if (!m.kiemtra_bienlai(i_quyenso,so))
					{
						MessageBox.Show(lan.Change_language_MessageText("Số biên lai vượt quá trong khoản từ :")+" "+r["tu"].ToString()+" "+lan.Change_language_MessageText("đến :")+" "+r["den"].ToString(),d.Msg);
						quyenso.Focus();
						return false;
					}
				}
			}

			if (bNew && dtct.Rows.Count>0)
			{
				try
				{
					dtct.AcceptChanges();
					int i_toaso=d.kiemtra_baohiem(dtct.Select("soluong>0","mabd,soluong"),s_ngay,sophieu.Text.Trim(),s_mmyy);
					if (i_toaso!=0)
					{
						if (MessageBox.Show(lan.Change_language_MessageText("Họ tên")+" "+hoten.Text.Trim()+"\n"+lan.Change_language_MessageText("đã nhập toa số")+" "+i_toaso.ToString()+"\n"+lan.Change_language_MessageText("Bạn có muốn nhập thêm không ?"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No)
							return false;
						else
							hoten.Text=hoten.Text.Trim()+"(+)";
					}
				}
				catch{}
			}
			return true;
		}

		private bool KiemtraDetail()
		{
			i_mabd=0;
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
			r=d.getrowbyid(dtton,"ma='"+mabd.Text+"'");
			if (r==null)
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã số không hợp lệ !"),d.Msg);
				if (mabd.Enabled) mabd.Focus();
				else tenbd.Focus();
				return false;
			}
			i_mabd=int.Parse(r["id"].ToString());
            decimal sl = (soluong.Text != "") ? decimal.Parse(soluong.Text) : 0;
			if (sl==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập số lượng !"),d.Msg);
				soluong.Focus();
				return false;
			}
			return true;
		}

		private bool KiemtraDetail1()
		{
			if (mavp.Text=="" && tenvp.Text=="")
			{
				mavp.Focus();
				return false;
			}
			if ((mavp.Text=="" && tenvp.Text!="") || (mavp.Text!="" && tenvp.Text==""))
			{
				if (mavp.Text=="" && mavp.Enabled)
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập mã số !"),d.Msg);
					mavp.Focus();
					return false;
				}
				else if (tenvp.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập tên !"),d.Msg);
					tenvp.Focus();
					return false;
				}
			}
			if (i_mavp==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã số không hợp lệ !"),d.Msg);
				mavp.Focus();
				return false;
			}
            decimal sl = (soluongvp.Text != "") ? decimal.Parse(soluongvp.Text) : 0;
			if (sl==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập số lượng !"),d.Msg);
				soluongvp.Focus();
				return false;
			}
			return true;
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			bEdit=false;
			cmbSophieu.SelectedIndex=i_old;
			if (cmbSophieu.Items.Count>0) l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
			else l_id=0;
			load_head();
			ena_object(false);
			butMoi.Focus();
		}

		private void ngaysp_Validated(object sender, System.EventArgs e)
		{
			if (ngaysp.Text=="") return;
			ngaysp.Text=ngaysp.Text.Trim();
			if (!d.bNgay(ngaysp.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"),d.Msg);
				ngaysp.Focus();
				return;
			}
			ngaysp.Text=d.Ktngaygio(ngaysp.Text,10);
			if (ngaysp.Text!=s_ngaysp)
			{
				if (!d.ngay(d.StringToDate(ngaysp.Text.Substring(0,10)),DateTime.Now,i_songay))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ so với khai báo hệ thống (")+i_songay.ToString()+")!",d.Msg);
					ngaysp.Focus();
					return;
				}
			}
			SendKeys.Send("{F4}");
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
			if (d.bNhapmaso) mabd.Enabled=true;
			tenbd.Enabled=true;
			soluong.Enabled=true;
            cachdung.Enabled = true;
			if (!upd_table(dtct,false)) return;
			emp_detail();
			if (mabd.Enabled) mabd.Focus();
			else tenbd.Focus();
		}

		private void butXoa_Click(object sender, System.EventArgs e)
		{
			if (!upd_table(dsxoa.Tables[0],true)) return;
			d.delrec(dtct,"stt="+int.Parse(stt.Text));
			dtct.AcceptChanges();
			if (dtct.Rows.Count==0) emp_detail();
			else ref_text();
		}

		private bool upd_table(DataTable dt,bool del)
		{
			if (!KiemtraDetail()) return false;
			d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
			d_dongia=(dongia.Text!="")?decimal.Parse(dongia.Text):0;
			d_giaban=(giaban.Text!="")?decimal.Parse(giaban.Text):0;
			d_sotien=(sotien.Text!="")?decimal.Parse(sotien.Text):0;
			d_sotienmua=(sotienmua.Text!="")?decimal.Parse(sotienmua.Text):0;
			l_sttt=(sttt.Text!="")?decimal.Parse(sttt.Text):0;
            string s_cachdung = cachdung.Text;
            if (s_cachdung.Trim() != "" && lbldungluc.Text.Trim() != "" && s_cachdung.IndexOf(lbldungluc.Text.Trim()) < 0) s_cachdung = s_cachdung + " " + lbldungluc.Text;
			d.updrec_bhytthuoc(dt,int.Parse(stt.Text),l_sttt,i_mabd,mabd.Text,tenbd.Text,"",dang.Text,makho.Text,(manguon.SelectedIndex==-1)?"":manguon.Text,(nhomcc.SelectedIndex==-1)?"":nhomcc.Text,handung.Text,losx.Text,d_soluong,d_dongia,d_sotienmua,d_giaban,d_dongia,d_sotien,s_cachdung,int.Parse(makho.SelectedValue.ToString()),(manguon.SelectedIndex==-1)?0:int.Parse(manguon.SelectedValue.ToString()),(nhomcc.SelectedIndex==-1)?0:int.Parse(nhomcc.SelectedValue.ToString()),(del)?null:dtton);
			return true;
		}

		private bool upd_table1(DataTable dt)
		{
			if (!KiemtraDetail1()) return false;
			d_soluongvp=(soluongvp.Text!="")?decimal.Parse(soluongvp.Text):0;
			d_dongiavp=(dongiavp.Text!="")?decimal.Parse(dongiavp.Text):0;
			d_sotienvp=(sotienvp.Text!="")?decimal.Parse(sotienvp.Text):0;
			d.updrec_bhytcls(dt,int.Parse(sttvp.Text),i_mavp,mavp.Text,tenvp.Text,dvt.Text,d_soluongvp,d_dongiavp,d_sotienvp,l_idchidinh);
			return true;
		}

		private void mabd_Validated(object sender, System.EventArgs e)
		{
			if(!listDMBD.Focused) listDMBD.Hide();
		}

		private void listDMBD_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
						dang.Text=r["dang"].ToString();
						makho.SelectedValue=r["makho"].ToString();
						manguon.SelectedValue=r["manguon"].ToString();
                        lbldungluc.Text = r["dungluc"].ToString();                        
					}
				}
				catch{}
			}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
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

		private void tinh_giatri1()
		{
			try
			{
				d_soluongvp=(soluongvp.Text!="")?decimal.Parse(soluongvp.Text):0;
				d_dongiavp=(dongiavp.Text!="")?decimal.Parse(dongiavp.Text):0;
				d_sotienvp=d_soluongvp*d_dongiavp;
				sotienvp.Text=d_sotienvp.ToString("###,###,###,##0");
			}
			catch{}
		}

		private void soluong_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (!bEdit) return;
				d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
				soluong.Text=d_soluong.ToString(format_soluong);
				if (mabd.Text!="" && tenbd.Text!="")
				{
					r=d.getrowbyid(dtton,"ma='"+mabd.Text+"'");
					if (r!=null)
					{
						i_mabd=int.Parse(r["id"].ToString());
						d_soluongton=d.get_slton_nguon(dtton,int.Parse(makho.SelectedValue.ToString()),i_mabd,int.Parse(manguon.SelectedValue.ToString()),d_soluongcu);
						if (d_soluong>d_soluongton)
						{
							MessageBox.Show(lan.Change_language_MessageText("Số lượng xuất lớn hơn số lượng tồn !(")+d_soluongton.ToString()+")",d.Msg);
							soluong.Focus();
							return;
						}
					}
				}
			}
			catch{}
			tinh_giatri();
            cachdung.Focus();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (cmbSophieu.Items.Count==0) return;
				if (bKhoaso)
				{
					MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng")+" "+s_mmyy.Substring(0,2)+" "+lan.Change_language_MessageText("năm")+" "+s_mmyy.Substring(2,2)+" "+lan.Change_language_MessageText("đã khóa !")+"\n"+lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"),d.Msg);
					return;
				}
                if (d.get_sobienlai_bhytkb(s_mmyy, l_id))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Viện phí đã cập nhật!"), d.Msg);
                    return;
                }
				if (d.get_done_bhytkb(s_mmyy,l_id))// && !bAdmin)
				{
					MessageBox.Show(lan.Change_language_MessageText("Thông tin này đã cập nhật!"),d.Msg);
					return;
				}
                if (d.get_sotoa_bhytkb(s_mmyy, l_id) && !bAdmin)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Thông tin này đã in!"), d.Msg);
                    return;
                }
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy số phiếu này ?"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
                    itable = d.tableid(s_mmyy, "bhytcls");
                    foreach (DataRow r in dtvp.Rows)
                    {
                        d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                        d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".bhytcls", "id=" + l_id + " and stt=" + int.Parse(r["stt"].ToString())));
                        d.execute_data_mmyy("update xxx.v_chidinh set paid=0 where id=" + decimal.Parse(r["idchidinh"].ToString()) + " and mavp=" + int.Parse(r["mavp"].ToString()),s_tu,s_den,songayduyet);
                    }
                    itable = d.tableid(s_mmyy, "bhytthuoc");
                    foreach (DataRow r1 in dtct.Rows)
                    {
                        d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                        d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".bhytthuoc", "id=" + l_id + " and stt=" + int.Parse(r["stt"].ToString())));
                        d.upd_tonkhoct_xuat(d.delete, s_mmyy, decimal.Parse(r1["sttt"].ToString()), int.Parse(r1["makho"].ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["nhomcc"].ToString()), int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["sotienmua"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()));
                    }
                    itable = d.tableid(s_mmyy, "bhytkb");
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".bhytkb", "id=" + l_id));
					d.execute_data("delete from " + yyy + ".bhytcls where id="+l_id);
                    d.execute_data("delete from " + yyy + ".bhytthuoc where id=" + l_id);
                    d.execute_data("delete from " + yyy + ".bhytkb where id=" + l_id);
					foreach(DataRow r1 in d.get_data_mmyy("select * from xxx.d_thuocbhytct where id="+l_id,s_tu,s_den,songayduyet).Tables[0].Rows)
                        d.upd_tonkhoth_dutru(d.dutru, i_nhom, s_mmyy, int.Parse(r1["makho"].ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["slthuc"].ToString()));
					d.execute_data_mmyy("update xxx.d_thuocbhytct set slthuc=0 where id="+l_id,s_tu,s_den,songayduyet);
					d.execute_data_mmyy("update xxx.d_thuocbhytll set done=0 where id="+l_id,s_tu,s_den,songayduyet);
					d.delrec(dtll,"id='"+l_id+"'");
					cmbSophieu.Refresh();
					if (cmbSophieu.Items.Count>0) l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
					else l_id=0;
					load_head();
				}
			}
			catch{}
		}

		private void load_dm()
		{
            dtton = d.get_tonkhoth_bhyt(s_mmyy, s_makho, s_kho, s_manguon, i_madoituong, i_khudt);
			listDMBD.DataSource=dtton;
			dtcachdung=d.get_data("select ten as stt,ten from "+user+".d_dmcachdung order by ten").Tables[0];
			listcachdung.DataSource=dtcachdung;
		}
		private void load_tonct()
		{
			dttonct=d.get_tonkhoct_bhyt(s_mmyy,s_makho,s_kho,s_manguon,i_madoituong,i_nhom);
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!KiemtraHead()) return;
			bEdit=false;
            if(butThem.Enabled) //Khuong 15/11/2011 kiem tra neu nut them thuoc enable moi update table
			    upd_table(dtct,false);
			if(butThemvp.Enabled)
                upd_table1(dtvp);
			dtct.AcceptChanges();
			if (bLoad)
				foreach(DataRow r1 in dtct.Rows)
				{
					d.execute_data_mmyy("update xxx.d_thuocbhytct set slthuc=slthuc+"+decimal.Parse(r1["soluong"].ToString())+" where id="+l_id+" and stt="+int.Parse(r1["stt"].ToString()),s_tu,s_den,songayduyet);
                    d.upd_tonkhoth_dutru(d.duyet, i_nhom, s_mmyy, int.Parse(r1["makho"].ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()));
				}
			i_old=(bNew)?0:1;
			l_id=(bNew)?d.get_id_bhyt:l_id;
            itable = d.tableid(s_mmyy, "bhytkb");
            if (bNew) d.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
            else
            {
                d.upd_eve_tables(s_mmyy, itable, i_userid, "upd");
                d.upd_eve_upd_del(s_mmyy, itable, i_userid, "upd", l_id.ToString() + "^" + i_nhom.ToString() + "^" + i_quyenso.ToString() + "^" + ((sobienlai.Text == "") ? "0" : sobienlai.Text) + "^" + ngaysp.Text + "^" + sophieu.Text + "^" + l_mavaovien.ToString() + "^" + l_maql.ToString() + "^" + makp.Text + "^" + chandoan.Text + "^" + maicd.Text + "^" + mabs.Text + "^" + sothe.Text + "^" + maphu.SelectedValue.ToString() + "^" + mabv.Text + "^" + ((congkham.Text == "") ? "0" : congkham.Text) + "^" + d_thuoc.ToString() + "^" + d_cls.ToString() + "^" + d_bntra.ToString() + "^" + d_bhyttra.ToString() + "^" + i_userid.ToString() + "^" + i_loaiba.ToString());
            }
			if (bNew)
			{
				if (bMabn && bTiepdon)
				{
					l_maql=m.get_tiepdon(sophieu.Text,ngaysp.Text);
					if (l_maql==0)
					{
						int tuoi=(namsinh.Text!="")?int.Parse(ngaysp.Text.Substring(6,4))-int.Parse(namsinh.Text):0;
                        l_maql = m.getidyymmddhhmiss_stt_computer;//m.get_capid(1);
                        string nam = m.get_mabn_nam(sophieu.Text);
                        if (nam.IndexOf(s_mmyy + "+") == -1) nam = nam + s_mmyy + "+";
						m.upd_btdbn(sophieu.Text,hoten.Text,"",(namsinh.Text!="")?namsinh.Text:"0000",m.vodanh_gioitinh,m.vodanh_nghenghiep,m.vodanh_dantoc,"",diachi.Text,"",m.vodanh_tinh,m.vodanh_tinh+"00",m.vodanh_tinh+"0000",i_userid,nam);
						m.upd_lienhe(ngaysp.Text,l_maql,"",diachi.Text,"",m.vodanh_tinh,m.vodanh_tinh+"00",m.vodanh_tinh+"0000",tuoi.ToString().PadLeft(3,'0')+"0",0,0);
						m.upd_tiepdon(sophieu.Text,l_maql,l_maql,(makp.Text!="")?makp.Text:"01",ngaysp.Text,1,"",tuoi.ToString().PadLeft(3,'0')+"0",i_userid,0,LibMedi.AccessData.Duoc,0);
						if (sothe.Text!="") m.upd_bhyt(ngaysp.Text,sophieu.Text,l_maql,sothe.Text,s_denngay,mabv.Text,0,s_tungay,ngay1,ngay2,ngay3,traituyen);
					}
					m.upd_sukien(ngaysp.Text,sophieu.Text,l_maql,LibMedi.AccessData.Duoc,l_maql);
                    l_mavaovien = l_maql;
				}
			}
            else if (l_maql == 0 && bMabn)
            {
                l_maql = m.get_tiepdon(sophieu.Text, ngaysp.Text);
                l_mavaovien = l_maql;
            }
            if (!d.upd_bhytds(s_mmyy, sophieu.Text, hoten.Text.Trim().Trim('-').Trim('+').Trim('-'), namsinh.Text, diachi.Text.Trim().Trim('-').Trim('+').Trim('-')))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin bảo hiểm !"), d.Msg);
                return;
            }
            if (!d.upd_bhytkb(s_mmyy, l_id, i_nhom, i_quyenso, (sobienlai.Text == "") ? 0 : decimal.Parse(sobienlai.Text), ngaysp.Text, sophieu.Text, l_mavaovien, l_maql, makp.Text, chandoan.Text.Trim().Trim('-').Trim('+').Trim('-'), maicd.Text.Trim().Trim('-').Trim('+').Trim('-'), mabs.Text, sothe.Text, int.Parse(maphu.SelectedValue.ToString()), mabv.Text, (congkham.Text == "") ? 0 : decimal.Parse(congkham.Text), d_thuoc, d_cls, d_bntra, d_bhyttra, i_userid, i_loaiba, traituyen, (bChuahoantatkham ? 1 : 0)))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin bảo hiểm !"),d.Msg);
				return;
			}
            itable = d.tableid(s_mmyy, "bhytthuoc");
			if (!bNew)
			{
				foreach(DataRow r1 in dtsave.Rows) //Khuong 07/12/2011
				{
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".bhytthuoc", "id=" + l_id + " and stt=" + decimal.Parse(r1["stt"].ToString())));
					d.execute_data("delete from "+user+s_mmyy+".bhytthuoc where id="+l_id+" and stt="+decimal.Parse(r1["stt"].ToString()));
					d.upd_tonkhoct_xuat(d.delete,s_mmyy,decimal.Parse(r1["sttt"].ToString()),int.Parse(r1["makho"].ToString()),
                        int.Parse(r1["manguon"].ToString()),int.Parse(r1["nhomcc"].ToString()),int.Parse(r1["mabd"].ToString()),
                        r1["handung"].ToString(),r1["losx"].ToString(),decimal.Parse(r1["soluong"].ToString()),decimal.Parse(r1["sotienmua"].ToString()),
                        decimal.Parse(r1["giaban"].ToString()),decimal.Parse(r1["giamua"].ToString()));
				}
			}		
			dtct=d.get_bhytthuoc(s_mmyy,dtct,l_id,(i_loaiba==2)?0:i_madoituong);
            itable = d.tableid(s_mmyy, "bhytcls");
			if (dsxoavp.Tables[0].Rows.Count>0)
			{
                foreach (DataRow r1 in dsxoavp.Tables[0].Rows)
                {
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".bhytcls", "id=" + l_id + " and stt=" + decimal.Parse(r1["stt"].ToString())));
                    d.execute_data_mmyy("update xxx.v_chidinh set paid=0 where id=" + decimal.Parse(r1["idchidinh"].ToString()) + " and mavp=" + int.Parse(r1["mavp"].ToString()),s_tu,s_den,songayduyet);
                    d.execute_data("delete from " + yyy + ".bhytcls where id=" + l_id + " and stt=" + decimal.Parse(r1["stt"].ToString()));
                }
			}
            foreach (DataRow r1 in dtvp.Rows)
            {
                if (d.get_data("select * from " + xxx + ".bhytcls where id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())).Tables[0].Rows.Count != 0)
                {
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "upd");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "upd", l_id.ToString() + "^" + r1["stt"].ToString() + "^" + r1["mavp"].ToString() + "^" + r1["soluong"].ToString() + "^" + r1["dongia"].ToString() + "^" + r1["idchidinh"].ToString());
                }
                else d.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
                d.upd_bhytcls(s_mmyy, l_id, int.Parse(r1["stt"].ToString()), int.Parse(r1["mavp"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["dongia"].ToString()),decimal.Parse(r1["idchidinh"].ToString()));
                d.execute_data_mmyy("update xxx.v_chidinh set paid=1 where id=" + decimal.Parse(r1["idchidinh"].ToString()) + " and mavp=" + int.Parse(r1["mavp"].ToString()),s_tu,s_den,songayduyet);
            }
			if (bQuyenso && sobienlai.Text!="")
			{
				m.upd_sobienlai(i_quyenso,int.Parse(sobienlai.Text));
				m.updrec(dtqs,i_quyenso,sobienlai.Text);
			}
			//tinhtong();
            load_grid();//
            d.upd_bhytkb(s_mmyy, l_id, i_nhom, i_quyenso, (sobienlai.Text == "") ? 0 : decimal.Parse(sobienlai.Text), ngaysp.Text, sophieu.Text, l_mavaovien, l_maql, makp.Text, chandoan.Text, maicd.Text, mabs.Text, sothe.Text, int.Parse(maphu.SelectedValue.ToString()), mabv.Text, (congkham.Text == "") ? 0 : decimal.Parse(congkham.Text), d_thuoc, d_cls, d_bntra, d_bhyttra, i_userid, i_loaiba, traituyen, (bChuahoantatkham ? 1 : 0));
			d.execute_data_mmyy("update xxx.bhytkb set ngay=to_timestamp('" + ngaysp.Text +" "+ System.DateTime.Now.ToLongTimeString().ToString() + "','dd/mm/yyyy hh24:mi') where id=" + l_id, s_tu, s_den, songayduyet);//khuyen 13/03/14
            d.updrec_bhytll(dtll,l_id,sophieu.Text,l_mavaovien,l_maql,hoten.Text,namsinh.Text,ngaysp.Text,diachi.Text,makp.Text,chandoan.Text,maicd.Text,mabs.Text,sothe.Text,int.Parse(maphu.SelectedValue.ToString()),mabv.Text,(sobienlai.Text=="")?0:decimal.Parse(sobienlai.Text),i_quyenso,d_congkham,d_thuoc,d_cls,d_chiphi,d_bntra,d_bhyttra,s_tungay,s_denngay,ngay1,ngay2,ngay3,traituyen);
			cmbSophieu.SelectedValue=l_id.ToString();
			d.execute_data_mmyy("update xxx.d_thuocbhytll set done=1 where id="+l_id,s_tu,s_den,songayduyet);
			load_grid();
			ena_object(false);
			butMoi.Focus();
		}

		private void tongcong(DataTable dt)
		{
			d_tongcong=0;
			foreach(DataRow r1 in dt.Rows) d_tongcong=d_tongcong+((bGiaban)?decimal.Parse(r1["soluong"].ToString())*decimal.Parse(r1["giaban"].ToString()):decimal.Parse(r1["sotien"].ToString()));
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			if (dtct.Rows.Count==0 && dtvp.Rows.Count==0) return;
			int d_toaso=d.get_sotoa_bhyt(s_mmyy,l_id,ngaysp.Text,i_madoituong);
			string s_tentt="",s_chandoan=chandoan.Text.Trim()+";";
            
			if (l_maql!=0)
			{
                if (i_loaiba != 1)
                {
                    foreach (DataRow r3 in d.get_data_mmyy("select chandoan from xxx.cdkemtheo where maql=" + l_maql + " order by stt", s_tu, s_den, songayduyet).Tables[0].Rows)
                        s_chandoan += (s_chandoan.IndexOf(r3["chandoan"].ToString() + ";") < 0) ? r3["chandoan"].ToString() + "; " : "";
                }
                if (i_loaiba == 1 || i_loaiba == 2)
                {
                    foreach (DataRow r3 in d.get_data_mmyy("select chandoan from " + user + ".cdkemtheo where maql=" + l_maql + " order by stt", s_tu, s_den, songayduyet).Tables[0].Rows)
                        s_chandoan += (s_chandoan.IndexOf(r3["chandoan"].ToString() + ";") < 0) ? r3["chandoan"].ToString() + "; " : "";
                }
				foreach(DataRow r3 in d.get_data_mmyy("select b.tenbv from xxx.noigioithieu a,"+user+".dstt b where a.mabv=b.mabv and a.maql="+l_maql,s_tu,s_den,songayduyet).Tables[0].Rows)
					s_tentt=r3["tenbv"].ToString().Trim();
			}
            string cholam = "",gioitinh="";
            //
            foreach (DataRow r1 in d.get_data("select cholam,phai from " + user + ".btdbn where mabn='" + sophieu.Text + "'").Tables[0].Rows)
            {
                cholam = r1["cholam"].ToString();
                gioitinh = (r1["phai"].ToString() == "0") ? "Nam" : "Nữ";
            }
            d.execute_data("update " + yyy + ".bhytkb set sotoa=" + d_toaso + " where id=" + l_id);
			d.updrec_bhytll(dtll,l_id,d_toaso);
			int iTuoi=(namsinh.Text!="")?DateTime.Now.Year-int.Parse(namsinh.Text):0;
            sql = "select to_char(b.tungay,'dd/mm/yyyy') as tungay,to_char(b.denngay,'dd/mm/yyyy') as denngay from " + yyy + ".bhytkb a," + yyy + ".bhyt b where a.maql=b.maql and a.id=" + l_id;
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				s_tungay=r["tungay"].ToString();s_denngay=r["denngay"].ToString();

			}
			DataSet dstmp;
			if (bIn_Nhomvp)
			{
				sql="select '"+s_tungay+"' as tungay,'"+s_denngay+"' as denngay,a.stt,a.sttt,a.mabd,b.ma,";
				sql+="trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,e.ten as tenkho,c.ten as tennguon,";
				sql+="'' as tennhomcc,t.handung,t.losx,a.soluong,";
                if (bchenhlech_thuoc && bGiaban && int.Parse(maphu.SelectedValue.ToString()) == 1)
                {
                    if (bGia_bh_quydinh) sql += "b.gia_bh as dongia,b.gia_bh*a.soluong as sotien,";
                    else sql += "t.giamua as dongia,t.giamua*a.soluong as sotien,";
                }
                else
                {
                    if (bGiaban) sql += "t.giaban as dongia,a.soluong*t.giaban as sotien,";
                    else sql += "t.giamua as dongia,a.soluong*t.giamua as sotien,";
                }
				sql+="a.soluong*t.giamua as sotienmua,t.giaban,a.cachdung,a.makho,t.manguon,t.nhomcc,h.stt as nhomin,h.ten as tennhomin,g.id as manhom ";
				if (i_bhyt_inrieng==0) sql+=",0 as loaidv";
				else sql+=",case when h.ma="+i_bhyt_inrieng+" then 1 else 0 end as loaidv";
                sql += ",i.ten as hangsx, j.ten as nuocsx ";
                sql += " from " + yyy + ".bhytthuoc a," + user + ".d_dmbd b," + user + ".d_dmnguon c," + user + ".d_dmnx d," + user + ".d_dmkho e, " + user + ".d_dmnhom f, " + user + ".d_nhomin g," + user + ".v_nhomvp h," + yyy + ".d_theodoi t";
                sql += ", " + user + ".d_dmhang i, " + user + ".d_dmnuoc j ";
				sql+=" where a.sttt=t.id and a.mabd=b.id and t.manguon=c.id and t.nhomcc=d.id and a.makho=e.id and b.manhom=f.id and f.nhomin=g.id and f.nhomvp=h.ma";
                sql += " and b.mahang=i.id(+) and b.manuoc=j.id(+)";
                sql += " and a.id=" + l_id;
                //sql+=" order by h.stt,a.stt";			
                sql += " union all ";
				sql+="select '"+s_tungay+"' as tungay,'"+s_denngay+"' as denngay,a.stt,0 as sttt,a.mavp as mabd,b.ma,";
				sql+="b.ten,' ' as tenhc,b.dvt as dang,' ' as tenkho,' ' as tennguon,'' as as tennhomcc,' ' as handung,' ' as losx,";
				sql+="a.soluong,a.dongia,a.soluong*a.dongia as sotien,a.soluong*a.dongia as sotienmua,a.dongia giaban,' ' as cachdung,0 as makho,0 as manguon,0 as nhomcc,d.stt as  nhomin,d.ten as tennhomin,0 as manhom ";
				if (i_bhyt_inrieng==0) sql+=",0 as loaidv";
				else sql+=",case when d.ma="+i_bhyt_inrieng+" then 1 else 0 end as loaidv";
                sql += ", null as hangsx, null as nuocsx ";
                sql += " from " + yyy + ". bhytcls a," + user + ".v_giavp b," + user + ".v_loaivp c," + user + ".v_nhomvp d ";
				sql+=" where a.mavp=b.id and b.id_loai=c.id and c.id_nhom=d.ma and a.id="+l_id;
				//sql+=" order by d.stt,a.stt";
			}
			else
			{
				sql="select '"+s_tungay+"' as tungay,'"+s_denngay+"' as denngay,a.stt,a.sttt,a.mabd,b.ma,";
				sql+="trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,e.ten as tenkho,c.ten as tennguon,";
				sql+="'' as tennhomcc,t.handung,t.losx,a.soluong,";
                if (bchenhlech_thuoc && bGiaban && int.Parse(maphu.SelectedValue.ToString()) == 1)
                {
                    if (bGia_bh_quydinh) sql += "b.gia_bh as dongia,b.gia_bh*a.soluong as sotien,";
                    else sql += "t.giamua as dongia,t.giamua*a.soluong as sotien,";
                }
                else
                {
                    if (bGiaban) sql += "t.giaban as dongia,a.soluong*t.giaban as sotien,";
                    else sql += "t.giamua as dongia,a.soluong*t.giamua as sotien,";
                }
				sql+="a.soluong*t.giamua as sotienmua,t.giaban,a.cachdung,a.makho,t.manguon,t.nhomcc, case when b.manhom=9 then f.nhomin else 4 end as nhomin,case when b.manhom=9 then f.ten else g.ten end as tennhomin,1 as loaidv,g.id as manhom ";
                sql += ",i.ten as hangsx, j.ten as nuocsx ";
                sql += " from " + yyy + ".bhytthuoc a," + user + ".d_dmbd b," + user + ".d_dmnguon c," + user + ".d_dmnx d," + user + ".d_dmkho e, " + user + ".d_dmnhom f, " + user + ".d_nhomin g," + yyy + ".d_theodoi t";
                sql += ", " + user + ".d_dmhang i, " + user + ".d_dmnuoc j ";
				sql+=" where a.sttt=t.id and a.mabd=b.id and t.manguon=c.id and t.nhomcc=d.id and a.makho=e.id and b.manhom=f.id and f.nhomin=g.id ";
                sql += " and b.mahang=i.id(+) and b.manuoc=j.id(+)";
                sql += " and a.id=" + l_id;
                //sql+=" order by a.stt";
                sql += " union all ";
				sql+="select '"+s_tungay+"' as tungay,'"+s_denngay+"' as denngay,a.stt,a.stt as sttt,a.mavp as mabd,b.ma,b.ten,' ' as tenhc,b.dvt as dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,' ' as handung,' ' as losx,a.soluong,a.dongia,a.soluong*a.dongia as sotien,a.soluong*a.dongia as sotienmua,a.dongia as giaban,' ' as cachdung,0 as makho,0 as manguon,0 as nhomcc,4 as nhomin,' ' as tennhomin, 2 as loaidv,0 as manhom ";
                sql += ",null as hangsx, null as nuocsx  ";
                sql += " from " + yyy + ".bhytcls a," + user + ".v_giavp b where a.mavp=b.id and a.id=" + l_id;
                //sql+=" order by a.stt";
			}
            DataSet ds1 = d.get_data(sql);
            sql = "select b.soluutru from " + user + s_mmyy + ".benhanpk a," + user + s_mmyy + ".lienhe b where a.maql=b.maql and a.maql='" + l_maql + "'";
            if (i_loaiba == 1) sql = "select b.soluutru from " + user +  ".benhandt a," + user + ".lienhe b where a.maql=b.maql and a.maql='" + l_maql + "'";
            DataSet lds = d.get_data(sql);
            string sovaovien = (lds == null || lds.Tables.Count <= 0 || lds.Tables[0].Rows.Count <= 0) ? "" : lds.Tables[0].Rows[0]["soluutru"].ToString();
            dstmp = ds1.Copy();
            dstmp.Clear();
            dstmp.Merge(ds1.Tables[0].Select("true", "nhomin,stt"));
            dstmp.Tables[0].Columns.Add("sovaovien");
            dstmp.Tables[0].Rows[0]["sovaovien"] = sovaovien;
            DataColumn dc = new DataColumn("Image", typeof(byte[]));
            dstmp.Tables[0].Columns.Add(dc);
			foreach(DataRow r3 in dstmp.Tables[0].Rows)
			{
				r3["tennhomcc"]=s_tentt;
				r3["tennguon"]=tenbv.Text;
			}
            if (File.Exists("..\\..\\..\\chuky\\" + mabs.Text + ".bmp"))
            {
                fstr = new FileStream("..\\..\\..\\chuky\\" + mabs.Text + ".bmp", FileMode.Open, FileAccess.Read);
                image = new byte[fstr.Length];
                fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                fstr.Close();
                foreach (DataRow r in dstmp.Tables[0].Rows) r["Image"] = image;
            }

            if (chkXML.Checked)
            {
                if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
                dstmp.WriteXml("..\\xml\\bhyt.xml", XmlWriteMode.WriteSchema);
            }
			if (chkXem.Checked)
			{
                frmReport f = new frmReport(d, dstmp.Tables[0], i_userid, "d_bhyt.rpt", hoten.Text + "   (" + sophieu.Text + ")", (iTuoi == 0) ? "^" + gioitinh : iTuoi.ToString() + "^" + gioitinh, diachi.Text.Trim() + "^" + cholam.Trim(), sothe.Text, s_chandoan, dtct.Rows.Count.ToString(), d_chiphi.ToString(), d_bntra.ToString(), d_bhyttra.ToString(), tenbs.Text, d_toaso.ToString() + "/" + sobienlai.Text+"^"+ngaynghi.Value.ToString(), d_congkham.ToString());
				f.ShowDialog();
			}
			else
			{
				ReportDocument oRpt=new ReportDocument();
				oRpt.Load("..\\..\\..\\report\\d_bhyt.rpt",OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(dstmp.Tables[0]);
				oRpt.DataDefinition.FormulaFields["soyte"].Text="'"+d.Syte+"'";
				oRpt.DataDefinition.FormulaFields["benhvien"].Text="'"+d.Tenbv+"'";
				oRpt.DataDefinition.FormulaFields["c1"].Text="'"+hoten.Text+"   ("+sophieu.Text+")"+"'";
				oRpt.DataDefinition.FormulaFields["c2"].Text=(iTuoi!=0)?"'"+iTuoi.ToString()+"^"+gioitinh+"'":"^"+gioitinh;
				oRpt.DataDefinition.FormulaFields["c3"].Text="'"+diachi.Text.Trim()+"^"+cholam.Trim()+"'";
                oRpt.DataDefinition.FormulaFields["c4"].Text = "'" + sothe.Text + "'";
				oRpt.DataDefinition.FormulaFields["c5"].Text="'"+s_chandoan+"'";
				oRpt.DataDefinition.FormulaFields["c6"].Text="'"+dtct.Rows.Count.ToString()+"'";
				oRpt.DataDefinition.FormulaFields["c7"].Text="'"+d_chiphi.ToString()+"'";
				oRpt.DataDefinition.FormulaFields["c8"].Text="'"+d_bntra.ToString()+"'";
				oRpt.DataDefinition.FormulaFields["c9"].Text="'"+d_bhyttra.ToString()+"'";
				oRpt.DataDefinition.FormulaFields["c10"].Text="'"+tenbs.Text+"'";
                oRpt.DataDefinition.FormulaFields["giamdoc"].Text = "'" + d_toaso.ToString() + "/" + sobienlai.Text + "^" + ngaynghi.Value.ToString() + "'";
				oRpt.DataDefinition.FormulaFields["phutrach"].Text="'"+d.Phutrach(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["thongke"].Text="'"+d_congkham.ToString()+"'";
				oRpt.DataDefinition.FormulaFields["ketoan"].Text="'"+d.Ketoan(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["thukho"].Text="'"+d.Thukho(i_nhom)+"'";
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

		private void Filter_cachdung(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listcachdung.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private DialogResult Thongso()
		{
			p.AllowSomePages = true;
			p.ShowHelp = true;
			p.Document = docToPrint;
			return p.ShowDialog();
		}

		private void namsinh_Validated(object sender, System.EventArgs e)
		{
			if (namsinh.Text!="" && namsinh.Text.Length<4) namsinh.Text=Convert.ToString(DateTime.Now.Year-int.Parse(namsinh.Text));
		}

		private bool get_data(string mabn)
		{
			bool ret=false;
			DataRow r1;
			sql="select a.id,a.mabn,a.mavaovien,a.maql,c.sothe,";
            if (i_loaiba == 2) sql += "d.sothe as sothengtr,";
            else sql += "c.sothe as sothengtr,";
            sql+=" b.hoten,b.namsinh,trim(b.sonha)||' '||b.thon as diachi,b.cholam,e.tentt,f.tenquan,g.tenpxa,";
			sql+=" c.mabv,a.makp,a.chandoan,a.maicd,a.mabs,a.madoituong,to_char(c.tungay,'dd/mm/yyyy') as tungay,to_char(c.denngay,'dd/mm/yyyy') as denngay,a.loaiba, c.traituyen";
			sql+=" from xxx.d_thuocbhytll a inner join "+user+".btdbn b on a.mabn=b.mabn ";
            sql+=" left join xxx.bhyt c on a.maql=c.maql";
            //sql += " left join " + user + ".vbhyt_" + s_idcomputer + " c on a.maql=c.maql";
            if (i_loaiba == 2) sql += " left join " + user + ".bhyt d on a.maql=d.maql ";
            sql += " left join "+user+".btdtt e on b.matt=e.matt ";
            sql += " left join " + user + ".btdquan f on b.maqu=f.maqu ";
            sql += " left join " + user + ".btdpxa g on b.maphuongxa=g.maphuongxa ";
			sql+=" where a.done=0";
            if (i_loaiba == 2) sql += " and a.loaiba=2";
            else
            {
                sql += " and a.loaiba<>2";
                if (i_madoituong == 1) sql += " and a.madoituong=1";
                else sql += " and a.madoituong<>1";
            }
			//sql+=" and to_char(a.ngay,'dd/mm/yyyy')='"+s_ngay+"'";
            sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";
			sql+=" and a.nhom="+i_nhom+" and a.mabn='"+mabn+"'";
			foreach(DataRow r in d.get_data_mmyy(sql,s_tu,s_den,songayduyet).Tables[0].Rows)
			{
				hoten.Text=r["hoten"].ToString();
				namsinh.Text=r["namsinh"].ToString();
                //diachi.Text = r["cholam"].ToString().Trim() + ";" + r["diachi"].ToString().Trim() + " " + r["tenpxa"].ToString().Trim() + " " + r["tenquan"].ToString().Trim() + " " + r["tentt"].ToString();
                diachi.Text = r["diachi"].ToString().Trim() + " " + r["tenpxa"].ToString().Trim() + " " + r["tenquan"].ToString().Trim() + " " + r["tentt"].ToString();
                sothe.Text = (r["sothe"].ToString() == "") ? r["sothengtr"].ToString() : r["sothe"].ToString();
				maphu.SelectedValue=r["madoituong"].ToString();
				chandoan.Text=r["chandoan"].ToString();
				maicd.Text=r["maicd"].ToString();
                l_mavaovien=decimal.Parse(r["mavaovien"].ToString());
				l_maql=decimal.Parse(r["maql"].ToString());
                l_id=decimal.Parse(r["id"].ToString());
				bNew=false;
				bLoad=true;
				makp.Text=r["makp"].ToString();
				mabs.Text=r["mabs"].ToString();
				mabv.Text=r["mabv"].ToString();
				r1=d.getrowbyid(dtkp,"makp='"+makp.Text+"'");
				if (r1!=null) tenkp.Text=r1["tenkp"].ToString();
				else tenkp.Text="";
				r1=d.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
				if (r1!=null) tenbs.Text=r1["hoten"].ToString();
				else tenbs.Text="";
				r1=d.getrowbyid(dtdstt,"mabv='"+mabv.Text+"'");
				if (r1!=null) tenbv.Text=r1["tenbv"].ToString();
				else tenbv.Text="";
				s_tungay=r["tungay"].ToString();
				s_denngay=r["denngay"].ToString();
                if (r["loaiba"].ToString() != "3" || i_loaiba == 2) congkham.Text = "0";
                traituyen = (r["traituyen"].ToString() == "") ? 0 : int.Parse(r["traituyen"].ToString());
                if (bkhongChoDuyetToaBNHen_E8 && i_madoituong==1)
                {
                    string s_thongtinhen = f_Kiemtrabn_chuahoantatkham(sophieu.Text, s_ngay, s_ngay, l_mavaovien.ToString());
                    if (s_thongtinhen.Trim() != "")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đã hẹn, lần sau tái khám duyệt chi phí luôn.") + " [Option E8] " + "\n" + s_thongtinhen, "Duyet toa", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        ret = false;
                        return ret ;
                    }
                }
				ret=true;
				break;
			}
			if (ret)
			{
				load_thuoc(l_id);
				load_vienphi(mabn,makp.Text);
			}
			else
			{
				sql="select b.mavaovien,b.maql,a.hoten,a.namsinh,a.sonha,a.thon,a.cholam,c.sothe,c.mabv,c.maphu,";
				sql+="b.makp,b.mabs,b.maicd,b.chandoan,b.madoituong,to_char(c.tungay,'dd/mm/yyyy') as tungay,"+
                    " to_char(c.denngay,'dd/mm/yyyy') as denngay, c.traituyen,e.tentt,f.tenquan,g.tenpxa ";
                sql += " from " + user + ".btdbn a inner join xxx.benhanpk b on a.mabn=b.mabn left join xxx.bhyt c on b.maql=c.maql inner join xxx.v_chidinh d on b.maql=d.maql";
                sql += " left join " + user + ".btdtt e on a.matt=e.matt ";
                sql += " left join " + user + ".btdquan f on a.maqu=f.maqu ";
                sql += " left join " + user + ".btdpxa g on a.maphuongxa=g.maphuongxa ";
                sql+= " where a.mabn='" + mabn + "' and " + m.for_ngay("d.ngay",stime) + " between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";//to_char(d.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                if (i_loaiba == 2) sql += " and b.mangtr<>0";
                else
                {
                    sql += " and b.mangtr=0";
                    if (i_madoituong == 1) sql += " and b.madoituong=1 ";
                    else sql += " and b.madoituong<>1 ";
                }
				foreach(DataRow r2 in d.get_data_mmyy(sql,s_tu,s_den,songayduyet).Tables[0].Rows)
				{
                    l_mavaovien = decimal.Parse(r2["mavaovien"].ToString());
					l_maql=decimal.Parse(r2["maql"].ToString());
					hoten.Text=r2["hoten"].ToString();
					namsinh.Text=r2["namsinh"].ToString();
					//if (r2["cholam"].ToString()!="")
					//	diachi.Text=r2["cholam"].ToString().Trim();
					//else
                    diachi.Text = r2["sonha"].ToString().Trim() + " " + r2["thon"].ToString().Trim() + " "+r2["tenpxa"].ToString().Trim() + " " + r2["tenquan"].ToString().Trim() + " " + r2["tentt"].ToString(); ;
					sothe.Text=r2["sothe"].ToString();
					maphu.SelectedValue=r2["madoituong"].ToString();
					mabv.Text=r2["mabv"].ToString();
					mabs.Text=r2["mabs"].ToString();
					makp.Text=r2["makp"].ToString();
					maicd.Text=r2["maicd"].ToString();
					chandoan.Text=r2["chandoan"].ToString();
					r1=d.getrowbyid(dtdstt,"mabv='"+mabv.Text+"'");
					if (r1!=null) tenbv.Text=r1["tenbv"].ToString();
					else tenbv.Text="";
					r1=d.getrowbyid(dtkp,"makp='"+makp.Text+"'");
					if (r1!=null) tenkp.Text=r1["tenkp"].ToString();
					else tenkp.Text="";
					r1=d.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
					if (r1!=null) tenbs.Text=r1["hoten"].ToString();
					else tenbs.Text="";
					s_tungay=r2["tungay"].ToString();
					s_denngay=r2["denngay"].ToString();
                    traituyen = (r2["traituyen"].ToString() == "") ? 0 : int.Parse(r2["traituyen"].ToString());
                    ret = load_vienphi(mabn, makp.Text);
                    if (ret) break;
				}
                //ret=load_vienphi(mabn,makp.Text);//bbbb
			}
			if (ret)
			{
				hoten.Enabled=false;
				sothe.Enabled=false;
				sophieu.Enabled=false;
				tenkp.Enabled=false;
				tenbs.Enabled=false;
				maicd.Enabled=false;
				chandoan.Enabled=false;
			}
			return ret;
		}

		private void load_thuoc(decimal id)
		{
			sql="select a.stt,0 as sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,";
			sql+=" b.tenhc,b.dang,e.ten as tenkho,c.ten as tennguon,' ' as tennhomcc,";
			sql+=" ' ' as handung,' ' as losx,a.slyeucau as soluong,0 as dongia,0 as sotien,0 as giaban,0 as sotienmua,";
			sql+=" a.cachdung,a.makho,a.manguon,0 as nhomcc ";
			sql+=" from xxx.d_thuocbhytct a,"+user+".d_dmbd b,"+user+".d_dmnguon c,"+user+".d_dmkho e ";
			sql+=" where a.mabd=b.id and a.manguon=c.id and a.makho=e.id ";
			sql+=" and a.id="+id+" order by a.stt";
			foreach(DataRow r in d.get_data_mmyy(sql,s_tu,s_den,songayduyet).Tables[0].Rows)
				d.updrec_bhytthuoc(dtct,int.Parse(r["stt"].ToString()),0,int.Parse(r["mabd"].ToString()),r["ma"].ToString(),
					r["ten"].ToString(),r["tenhc"].ToString(),r["dang"].ToString(),r["tenkho"].ToString(),r["tennguon"].ToString(),
					r["tennhomcc"].ToString(),r["handung"].ToString(),r["losx"].ToString(),decimal.Parse(r["soluong"].ToString()),
					decimal.Parse(r["dongia"].ToString()),decimal.Parse(r["sotien"].ToString()),0,0,0,r["cachdung"].ToString(),int.Parse(r["makho"].ToString()),
					int.Parse(r["manguon"].ToString()),int.Parse(r["nhomcc"].ToString()),dtton);
		}

		private bool load_vienphi(string mabn,string makp)
		{
			sql="select a.id,a.mavp,b.ma,b.ten,b.dvt,a.soluong,a.dongia,a.soluong*a.dongia as sotien";
			sql+=" from xxx.v_chidinh a,"+user+".v_giavp b ";
			sql+=" where a.mavp=b.id and a.paid=0 ";
            if (i_loaiba != 2)
            {
                if (i_madoituong == 1) sql += " and a.madoituong=1";
                else sql += " and a.madoituong<>1";
            }
			sql+=" and a.mabn='"+mabn+"' and " + m.for_ngay("a.ngay",stime) + " between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";//to_char(a.ngay,'dd/mm/yyyy')='"+s_ngay.Substring(0,10)+"'";
            sql+=" and a.makp='"+makp+"'";
			bool ret=false;
			foreach(DataRow r in d.get_data_mmyy(sql,s_tu,s_den,songayduyet).Tables[0].Rows)
			{
				d.updrec_bhytcls(dtvp,d.get_stt(dtvp),int.Parse(r["mavp"].ToString()),
					r["ma"].ToString(),r["ten"].ToString(),r["dvt"].ToString(),
					decimal.Parse(r["soluong"].ToString()),decimal.Parse(r["dongia"].ToString()),
					decimal.Parse(r["sotien"].ToString()),decimal.Parse(r["id"].ToString()));
				ret=true;
			}
			return ret;
		}

		private void sophieu_Validated(object sender, System.EventArgs e)
		{
			if (sophieu.Text=="") return;
			hoten.Text="";namsinh.Text="";diachi.Text="";
			sothe.Text="";mabv.Text="";
			if (bMabn)
			{
				if (sophieu.Text=="" || sophieu.Text.Trim().Length<3) return;
				if (sophieu.Text.Trim().Length<10) sophieu.Text=sophieu.Text.Substring(0,2)+sophieu.Text.Substring(2).PadLeft(6,'0');
				l_maql=m.get_tiepdon(sophieu.Text,ngaysp.Text);
				if (!bTiepdon)
				{
					if (l_maql==0)
					{
						MessageBox.Show(lan.Change_language_MessageText("Người bệnh chưa qua tiếp đón !"),d.Msg);
						butBoqua.Focus();
						return;
					}
				}
				if (bThongbao)
				{
					string ten=d.thongbao_baohiem(s_mmyy,sophieu.Text,s_ngay);
					if (ten!="")
					{
						if (ten=="?") ten="";
						else ten="tại "+ten;
						if (MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã nhập đơn thuốc")+" "+ten+"\n"+lan.Change_language_MessageText("Bạn có nhập tiếp không ?"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No)
						{
							string sp=sophieu.Text;
							butBoqua_Click(sender,e);
							RefreshChildren(sp);
							return;
						}
					}
				}
				if (l_maql!=0) l_maql=d.get_macap(s_ngay,l_maql,(i_loaiba==2)?LibMedi.AccessData.Ngoaitru:LibMedi.AccessData.Khambenh);
				if (l_maql!=0)
				{
					if (get_data(sophieu.Text)) return;
					sql="select a.hoten,a.namsinh,a.sonha,a.thon,a.cholam,c.sothe,c.mabv,c.maphu,";
					sql+="b.makp,b.mabs,b.maicd,b.chandoan,b.madoituong,to_char(c.tungay,'dd/mm/yyyy')"+
                        " as tungay,to_char(c.denngay,'dd/mm/yyyy') as denngay, c.traituyen,e.tentt,f.tenquan,g.tenpxa ";
                    sql += " from " + user + ".btdbn a inner join " + xxx + ".benhanpk b on a.mabn=b.mabn left join " + xxx + ".bhyt c on b.maql=c.maql ";
                    sql += " left join " + user + ".bhyt b1 on c.maql=b1.maql";//khuyen 07/04/14
                    sql += " left join " + user + ".btdtt e on a.matt=e.matt ";
                    sql += " left join " + user + ".btdquan f on a.maqu=f.maqu ";
                    sql += " left join " + user + ".btdpxa g on a.maphuongxa=g.maphuongxa ";
                    sql += " where b.maql=" + l_maql;
                    if (i_loaiba != 2)
                    {
                        if (i_madoituong == 1) sql += " and b.madoituong=1 ";
                        else sql += " and b.madoituong<>1 ";
                    }
					foreach(DataRow r1 in d.get_data(sql).Tables[0].Rows)
					{
						hoten.Text=r1["hoten"].ToString();
						namsinh.Text=r1["namsinh"].ToString();
						//if (r1["cholam"].ToString()!="")
						//	diachi.Text=r1["cholam"].ToString().Trim();
						//else
                        diachi.Text = r1["sonha"].ToString().Trim() + " " + r1["thon"].ToString().Trim() + " " + r1["tenpxa"].ToString().Trim() + " " + r1["tenquan"].ToString().Trim() + " " + r1["tentt"].ToString();
						sothe.Text=r1["sothe"].ToString();
						maphu.SelectedValue=r1["madoituong"].ToString();
						mabv.Text=r1["mabv"].ToString();
						mabs.Text=r1["mabs"].ToString();
						makp.Text=r1["makp"].ToString();
						maicd.Text=r1["maicd"].ToString();
						chandoan.Text=r1["chandoan"].ToString();
						r=d.getrowbyid(dtdstt,"mabv='"+mabv.Text+"'");
						if (r!=null) tenbv.Text=r["tenbv"].ToString();
						r=d.getrowbyid(dtkp,"makp='"+makp.Text+"'");
						if (r!=null) tenkp.Text=r["tenkp"].ToString();
						else tenkp.Text="";
						r=d.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
						if (r!=null) tenbs.Text=r["hoten"].ToString();
						else tenbs.Text="";
						s_tungay=r1["tungay"].ToString();
						s_denngay=r1["denngay"].ToString();
                        traituyen = (r["traituyen"].ToString() == "") ? 0 : int.Parse(r["traituyen"].ToString());
                        cbTraituyen.SelectedIndex = traituyen;
                        //
					}
				}
				if (hoten.Text=="")
				{
                    sql = "select c.madoituong,a.hoten,a.namsinh,a.sonha,a.thon,a.cholam,case when  b.sothe is not null and b.sothe <>'' then b.sothe else b1.sothe end as sothe,";
                    sql += " case when  b.mabv is not null and b.mabv <>'' then b.mabv else b1.mabv end as mabv,nullif(b.maphu,0) as maphu,c.maql,";
					sql+="to_char(b.tungay,'dd/mm/yyyy') as tungay,to_char(b.denngay,'dd/mm/yyyy') as denngay , "+
                        " b.traituyen,e.tentt,f.tenquan,g.tenpxa,c.makp ";
                    sql += " from " + user + ".btdbn a inner join " + xxx + ".tiepdon c on a.mabn=c.mabn left join " + xxx + ".bhyt b on c.maql=b.maql";
                    sql += " left join " + user + ".bhyt b1 on c.maql=b1.maql";//khuyen 07/04/14
                    sql += " left join " + user + ".btdtt e on a.matt=e.matt ";
                    sql += " left join " + user + ".btdquan f on a.maqu=f.maqu ";
                    sql += " left join " + user + ".btdpxa g on a.maphuongxa=g.maphuongxa ";
					sql+=" where a.mabn='"+sophieu.Text+"'";
                    if (i_loaiba != 2)
                    {
                        if (i_madoituong == 1) sql += " and c.madoituong=" + i_madoituong;
                        else sql += " and c.madoituong<>1";
                    }
					sql+=" order by c.maql desc";
					foreach(DataRow r1 in d.get_data(sql).Tables[0].Rows)
					{
						hoten.Text=r1["hoten"].ToString();
						namsinh.Text=r1["namsinh"].ToString();
						l_maql=decimal.Parse(r1["maql"].ToString());
						//if (r1["cholam"].ToString()!="")
						//	diachi.Text=r1["cholam"].ToString().Trim();
						//else
                        makp.Text = r1["makp"].ToString();
                        makp_Validated(null, null);
                        diachi.Text = r1["sonha"].ToString().Trim() + " " + r1["thon"].ToString().Trim() + " " + r1["tenpxa"].ToString().Trim() + " " + r1["tenquan"].ToString().Trim() + " " + r1["tentt"].ToString();
						sothe.Text=r1["sothe"].ToString().Trim();
						maphu.SelectedValue=int.Parse(r1["madoituong"].ToString());
						mabv.Text=r1["mabv"].ToString().Trim();
						if (mabv.Text!="")
						{
							r=d.getrowbyid(dtdstt,"mabv='"+mabv.Text+"'");
							if (r!=null) tenbv.Text=r["tenbv"].ToString();
						}
						s_tungay=r1["tungay"].ToString();
						s_denngay=r1["denngay"].ToString();
                        traituyen = (r1["traituyen"].ToString() == "") ? 0 : int.Parse(r1["traituyen"].ToString());
                        cbTraituyen.SelectedIndex = traituyen;
						break;
					}
				}
                if (hoten.Text == "")
                {
                    sql = "select a.hoten,a.namsinh,a.sonha,a.thon,a.cholam,e.tentt,f.tenquan,g.tenpxa from " + user + ".btdbn a ";
                    sql += " left join " + user + ".btdtt e on a.matt=e.matt ";
                    sql += " left join " + user + ".btdquan f on a.maqu=f.maqu ";
                    sql += " left join " + user + ".btdpxa g on a.maphuongxa=g.maphuongxa ";
                    sql += " where a.mabn='" + sophieu.Text + "'";
                    foreach (DataRow r1 in d.get_data(sql).Tables[0].Rows)
                    {
                        hoten.Text = r1["hoten"].ToString();
                        namsinh.Text = r1["namsinh"].ToString();
                        //if (r1["cholam"].ToString() != "")
                        //    diachi.Text = r1["cholam"].ToString().Trim();
                        //else
                        diachi.Text = r1["sonha"].ToString().Trim() + " " + r1["thon"].ToString().Trim() + " " + r1["tenpxa"].ToString().Trim() + " " + r1["tenquan"].ToString().Trim() + " " + r1["tentt"].ToString();
                        break;
                    }
                }
                l_mavaovien = l_maql;
			}
			else
			{
                foreach (DataRow r1 in d.get_data("select a.hoten,a.namsinh,a.diachi,b.sothe,b.mabv,b.maphu, b.traituyen from " + yyy + ".bhytds a," + yyy + ".bhytkb b where a.mabn=b.mabn and b.sothe is not null and a.mabn='" + sophieu.Text + "' order by b.id desc").Tables[0].Rows)
				{
					hoten.Text=r1["hoten"].ToString();
					namsinh.Text=r1["namsinh"].ToString();
					diachi.Text=r1["diachi"].ToString();
					sothe.Text=r1["sothe"].ToString();
					maphu.SelectedValue=r1["maphu"].ToString();
					mabv.Text=r1["mabv"].ToString();
					r=d.getrowbyid(dtdstt,"mabv='"+mabv.Text+"'");
					if (r!=null) tenbv.Text=r["tenbv"].ToString();
                    traituyen = (r1["traituyen"].ToString() == "") ? 0 : int.Parse(r1["traituyen"].ToString());
                    cbTraituyen.SelectedIndex = traituyen;
					break;
				}
			}
		}

		private void cachdung_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listcachdung.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listcachdung.Visible)	listcachdung.Focus();
				else SendKeys.Send("{Tab}");
			}		
		}

		private void cachdung_TextChanged(object sender, System.EventArgs e)
		{
            if (this.ActiveControl == cachdung)
            {
                Filter_cachdung(cachdung.Text);
                listcachdung.BrowseToBtdkp(cachdung, cachdung, butThem);
                listcachdung.BringToFront();
                butThem.SendToBack();
                butXoa.SendToBack();
                //listcachdung.BrowseToDanhmuc(
            }
		}

		private void cachdung_Validated(object sender, System.EventArgs e)
		{
			if(!listcachdung.Focused) listcachdung.Hide();		
		}

		private void diachi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tenbv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDstt.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listDstt.Visible)	listDstt.Focus();
				else SendKeys.Send("{Tab}");
			}				
		}

		private void tenbv_Validated(object sender, System.EventArgs e)
		{
			if(!listDstt.Focused) listDstt.Hide();
		}

		private void tenbv_TextChanged(object sender, System.EventArgs e)
		{
			Filter_dstt(tenbv.Text);
			listDstt.BrowseToDanhmuc(tenbv,mabv,makp);
		}

		private void Filter_dstt(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDstt.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="tenbv like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void maphu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (maphu.SelectedIndex==-1) maphu.SelectedIndex=0;
                if (sothe.Enabled)
                {
                    string so = m.sothe(int.Parse(maphu.SelectedValue.ToString()));
                    if (sothe.Text == "" && int.Parse(so.Substring(0, 2)) > 0) load_bhyt();
                    sothe.Enabled = int.Parse(so.Substring(0, 2)) > 0;
                    tenbv.Enabled = so.Substring(3, 1) == "1";
                }
				SendKeys.Send("{Tab}");
			}
		}

		private void load_bhyt()
		{
			string so=m.sothe(int.Parse(maphu.SelectedValue.ToString()));
			if (int.Parse(so.Substring(0,2))>0 && ngaysp.Text!="")
			{
				string s_mabn=sophieu.Text;
				if (so.Substring(2,1)=="1" && bDenngay_sothe)
					sql="select sothe,denngay,mabv from "+xxx+".bhyt where mabn='"+s_mabn+"'"+" and to_timestamp(denngay,'dd/mm/yy')>=to_timestamp('"+ngaysp.Text.Substring(0,10)+"','dd/mm/yy')"+" order by maql desc";
				else
					sql="select sothe,mabv from "+xxx+".bhyt where mabn='"+s_mabn+"' order by maql desc";
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					sothe.Text=r["sothe"].ToString();
					mabv.Text=r["mabv"].ToString();
					try
					{
						if (so.Substring(3,1)=="1")
						{
							if (mabv.Text=="") mabv.Text=m.Mabv;
							tenbv.Text=m.get_data("select tenbv from "+user+".dmnoicapbhyt where mabv='"+mabv.Text+"'").Tables[0].Rows[0][0].ToString();
						}
					}
					catch{}
					break;
				}
			}
			else
			{
				sothe.Text="";
				tenbv.Text="";
			}
		}

		private void sothe_Validated(object sender, System.EventArgs e)
		{
			string so=m.sothe(int.Parse(maphu.SelectedValue.ToString()));
            if (m.sothe(int.Parse(maphu.SelectedValue.ToString()), sothe.Text)) return;
            else
            {
                MessageBox.Show(lan.Change_language_MessageText("Chiều dài số thẻ không hợp lệ :") + sothe.Text.Length.ToString(), d.Msg);
                sothe.Focus();
            }
		}

		private void sothe_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void chandoan_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==chandoan && bChandoan)
			{
				Filt_ICD(chandoan.Text);
				listICD.BrowseToICD10(chandoan,maicd,butThem,maicd.Location.X,maicd.Location.Y+maicd.Height,maicd.Width+chandoan.Width+2,maicd.Height);
			}
		}

		private void maicd_Validated(object sender, System.EventArgs e)
		{
			if (maicd.Text=="") chandoan.Text="";
			else chandoan.Text=m.get_vviet(maicd.Text);
			if (chandoan.Text=="" && maicd.Text!="")
			{
				frmDMICD10 f=new frmDMICD10(m,maicd.Text,chandoan.Text,true);
				f.ShowDialog();
				if (f.mICD!="")
				{
					chandoan.Text=f.mTen;
					maicd.Text=f.mICD;
				}
			}
		}

		private void Filt_ICD(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listICD.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="vviet like '%"+ten.Trim()+"%'";
			}
			catch{}
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

		private void Filt_btdkp(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listBTDKP.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="tenkp like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void chandoan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listICD.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
                if (listICD.Visible) listICD.Focus();
                else butThem_Click(null,null);
			}		
		}

		private void tenkp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listBTDKP.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listBTDKP.Visible) listBTDKP.Focus();
				else SendKeys.Send("{Tab}");
			}		
		}

		private void tenkp_TextChanged(object sender, System.EventArgs e)
		{
			Filt_btdkp(tenkp.Text);
			listBTDKP.BrowseToDanhmuc(tenkp,makp,mabs);
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

		private void tenbs_TextChanged(object sender, System.EventArgs e)
		{
			Filt_dmbs(tenbs.Text);
			listDMBS.BrowseToDanhmuc(tenbs,mabs,maicd);		
		}

		private void mabd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==mabd)
			{
				if (butMoi.Enabled) return;
				Filter_mabd(mabd.Text);
				listDMBD.Tonkhoct(mabd,tenbd,soluong,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+tenbd.Width*3-20,mabd.Height+5);
			}		
		}

		private void Filter_mavp(string ma)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listVP.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ma like '%"+ma.Trim()+"%'";
			}
			catch{}
		}

		private void Filter_mabd(string ma)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDMBD.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="soluong>0 and ma like '%"+ma.Trim()+"%'";
			}
			catch{}
		}

		public void RefreshChildren(string text)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[cmbSophieu.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="hoten like '%"+text.Trim()+"%' or mabn like '%"+text.Trim()+"%' or sothe like '%"+text.Trim()+"%'";
				if (cmbSophieu.Items.Count>0) l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
				else l_id=0;
				load_head();
			}
			catch{l_id=0;load_head();}
		}

		private void load_head()
		{
			try
			{
				r=d.getrowbyid(dtll,"id='"+l_id+"'");
				if (r!=null)
				{
                    l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
					l_maql=decimal.Parse(r["maql"].ToString());
					sophieu.Text=r["mabn"].ToString();
					hoten.Text=r["hoten"].ToString();
					namsinh.Text=r["namsinh"].ToString();
					ngaysp.Text=r["ngay"].ToString();
					diachi.Text=r["diachi"].ToString();
					sothe.Text=r["sothe"].ToString();
					maphu.SelectedValue=r["maphu"].ToString();
                    string sql1 = "select quyenso, sobienlai from " + d.user + s_mmyy + ".bhytkb where id=" + l_id;
                    string tmp_quyenso="0";
                    DataRow r1;
                    DataSet lds = d.get_data(sql1);
                    if (lds.Tables.Count > 0 && lds.Tables[0].Rows.Count > 0)
                    {
                        sobienlai.Text = lds.Tables[0].Rows[0]["sobienlai"].ToString();
                        tmp_quyenso = lds.Tables[0].Rows[0]["quyenso"].ToString();
                        r1 = d.getrowbyid(dtqs, "id=" + tmp_quyenso);
                        if (r1 != null) quyenso.Text = r1["sohieu"].ToString();
                        else quyenso.Text = "";
                    }
                    else
                    {
                        sobienlai.Text = r["sobienlai"].ToString();
                        r1 = d.getrowbyid(dtqs, "id=" + int.Parse(r["quyenso"].ToString()));
                        if (r1 != null) quyenso.Text = r1["sohieu"].ToString();
                        else quyenso.Text = "";
                    }
                    //
                    
					mabv.Text=r["mabv"].ToString();
					maicd.Text=r["maicd"].ToString();
					chandoan.Text=r["chandoan"].ToString();
					makp.Text=r["makp"].ToString();
					mabs.Text=r["mabs"].ToString();
                    tmp_ngay = r["ngay"].ToString();
					r1=d.getrowbyid(dtdstt,"mabv='"+r["mabv"].ToString()+"'");
					if (r1!=null) tenbv.Text=r1["tenbv"].ToString();
					else tenbv.Text="";
					s_tungay=r["tungay"].ToString();
					s_denngay=r["denngay"].ToString();
					r1=d.getrowbyid(dtkp,"makp='"+makp.Text+"'");
					if (r1!=null) tenkp.Text=r1["tenkp"].ToString();
					else tenkp.Text="";
					r1=d.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
					if (r1!=null) tenbs.Text=r1["hoten"].ToString();
					else tenbs.Text="";
					
					s_ngaysp=ngaysp.Text;
					d_congkham=decimal.Parse(r["congkham"].ToString());
					d_thuoc=decimal.Parse(r["thuoc"].ToString());
					d_cls=decimal.Parse(r["cls"].ToString());
					d_bntra=decimal.Parse(r["bntra"].ToString());
					d_bhyttra=decimal.Parse(r["bhyttra"].ToString());
					d_chiphi=d_congkham+d_thuoc+d_cls;
					congkham.Text=d_congkham.ToString("###,###,##0");
					thuoc.Text=d_thuoc.ToString("###,###,##0.000");
					cls.Text=d_cls.ToString("###,###,##0");
					chiphi.Text=d_chiphi.ToString("###,###,##0.000");
					bntra.Text=d_bntra.ToString("###,###,##0.000");
					bhyttra.Text=d_bhyttra.ToString("###,###,##0.000");                    
                    traituyen = (r["traituyen"].ToString() == "") ? 0 : int.Parse(r["traituyen"].ToString());
                    cbTraituyen.SelectedIndex = traituyen;
                    ngay1 = r["ngay1"].ToString();
                    ngay2 = r["ngay2"].ToString();
                    ngay3 = r["ngay3"].ToString();

                    ngaynghi.Value = decimal.Parse(r["ngaynghi"].ToString());
				}
			}
			catch (Exception ex){}
			load_grid();
			emp_detail1();
			ref_text();
			ref_text1();
		}

		private void butDuyet_Click(object sender, System.EventArgs e)
		{
            if (maphu.SelectedIndex == -1)
            {
                if (maphu.Items.Count > 0) maphu.SelectedIndex = 0;
                else
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đối tượng không hợp lệ !"), d.Msg);
                    return;
                }
            }
            frmDuyetbhyt f = new frmDuyetbhyt(d, dtll, i_nhom, s_makho, s_manguon, s_ngay, i_userid, s_mmyy, true, int.Parse(maphu.SelectedValue.ToString()), i_loaiba,bAdmin,s_userid,chkds.Checked,i_khudt,bChuahoantatkham );
			f.ShowDialog(this);
			if (f.bOk)
			{
				dtll=f.dtll;
				dtll.AcceptChanges();
                cmbSophieu.Update();
                if (dtll.Rows.Count > 0)
                {
                    //l_id = decimal.Parse(cmbSophieu.SelectedValue.ToString());
                    l_id = decimal.Parse(dtll.Rows[dtll.Rows.Count - 1]["id"].ToString());
                    cmbSophieu.SelectedValue = l_id;
                    cmbSophieu.Update();
                }
                else l_id = 0;
				if (bQuyenso)
				{
					int so=f.sobienlai;
					m.updrec(dtqs,i_quyenso,so.ToString());
					m.upd_sobienlai(i_quyenso,so);
				}
				load_head();
				hoten.Enabled=false;
				sothe.Enabled=false;
				sophieu.Enabled=false;
				tenkp.Enabled=false;
				tenbs.Enabled=false;
				maicd.Enabled=false;
				chandoan.Enabled=false;
			}
		}

		private void makp_Validated(object sender, System.EventArgs e)
		{
			r=d.getrowbyid(dtkp,"makp='"+makp.Text+"'");
			if (r!=null) tenkp.Text=r["tenkp"].ToString();
			else tenkp.Text="";
		}

		private void mabs_Validated(object sender, System.EventArgs e)
		{
			r=d.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
			if (r!=null) tenbs.Text=r["hoten"].ToString();
			else tenbs.Text="";
		}

		private void mabd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDMBD.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				DataRow [] dr=dtton.Select("ma like '"+mabd.Text.Trim()+"%'");
				if (dr.Length==1)
				{
					mabd.Text=dr[0]["ma"].ToString();
					tenbd.Text=dr[0]["ten"].ToString();
					dang.Text=dr[0]["dang"].ToString();
					makho.SelectedValue=dr[0]["makho"].ToString();
					manguon.SelectedValue=dr[0]["manguon"].ToString();
                    lbldungluc.Text = dr[0]["dungluc"].ToString();
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

		private void butThemvp_Click(object sender, System.EventArgs e)
		{
			if (!upd_table1(dtvp)) return;
			emp_detail1();
			mavp.Focus();		
		}

		private void butXoavp_Click(object sender, System.EventArgs e)
		{
			if (!upd_table1(dsxoavp.Tables[0])) return;
			d.delrec(dtvp,"stt="+int.Parse(sttvp.Text));
			dtvp.AcceptChanges();
			if (dtvp.Rows.Count==0) emp_detail1();
			else ref_text1();		
		}

		private void soluongvp_Validated(object sender, System.EventArgs e)
		{
			d_soluongvp=(soluongvp.Text!="")?decimal.Parse(soluongvp.Text):0;
			soluongvp.Text=d_soluongvp.ToString("#,###,##0");
			tinh_giatri1();
		}

		private void mavp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listVP.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				DataRow [] dr=dtdmvp.Select("ma like '"+mavp.Text.Trim()+"%'");
				if (dr.Length==1)
				{
					mavp.Text=dr[0]["ma"].ToString();
					tenvp.Text=dr[0]["ten"].ToString();
					dvt.Text=dr[0]["dvt"].ToString();
					i_mavp=int.Parse(dr[0]["id"].ToString());
					d_dongiavp=decimal.Parse(dr[0]["dongia"].ToString());
					dongiavp.Text=d_dongiavp.ToString("###,###,##0");
					tinh_giatri1();
					if(!listVP.Focused) listVP.Hide();
					soluongvp.Focus();
				}
				else
				{
					if (listVP.Visible) 
					{
						listVP.Focus();
						SendKeys.Send("{Up}");
					}
					else tenvp.Focus();
				}
			}
		}

		private void mavp_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==mavp)
			{
				if (butMoi.Enabled) return;
				Filter_mavp(mavp.Text);
				listVP.BrowseToICD10(mavp,tenvp,soluongvp,mavp.Location.X,mavp.Location.Y + mavp.Height-2,mavp.Width+tenvp.Width+label5.Width+dvt.Width-5,mavp.Height+5);
			}		
		}

		private void tenvp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listVP.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listVP.Visible) listVP.Focus();
				else SendKeys.Send("{Tab}");
			}
		}

		private void tenvp_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenvp)
			{
				if (butMoi.Enabled) return;
				Filter_dmvp(tenvp.Text);
				listVP.BrowseToICD10(tenvp,mavp,soluongvp,mavp.Location.X,mavp.Location.Y + mavp.Height-2,mavp.Width+tenvp.Width+label5.Width+dvt.Width-5,mavp.Height+5);
			}
		}

		private void dataGrid2_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text1();
		}

		private void listVP_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				try
				{
					r=d.getrowbyid(dtdmvp,"id="+int.Parse(mavp.Text));
					if (r!=null)
					{
						mavp.Text=r["ma"].ToString();
						tenvp.Text=r["ten"].ToString();
						dvt.Text=r["dvt"].ToString();
						i_mavp=int.Parse(r["id"].ToString());
						d_dongiavp=decimal.Parse(r["dongia"].ToString());
						dongiavp.Text=d_dongiavp.ToString("###,###,##0");
						tinh_giatri1();
					}
				}
				catch
				{
					try
					{
						r=d.getrowbyid(dtdmvp,"id="+int.Parse(tenvp.Text));
						if (r!=null)
						{
							mavp.Text=r["ma"].ToString();
							tenvp.Text=r["ten"].ToString();
							dvt.Text=r["dvt"].ToString();
							i_mavp=int.Parse(r["id"].ToString());
							d_dongiavp=decimal.Parse(r["dongia"].ToString());
							dongiavp.Text=d_dongiavp.ToString("###,###,##0");
							tinh_giatri1();
						}
					}
					catch{}
				}
			}
		}

		private void congkham_Validated(object sender, System.EventArgs e)
		{
			decimal d_congkham=(congkham.Text=="")?0:decimal.Parse(congkham.Text);
			congkham.Text=d_congkham.ToString("###,###,##0");
		}

		private void tinhtong()
		{
            d_dichvu_tt_BHYT_tra = 0; d_tongcp_dichvu_tt = 0;
			d_thuoc=zsotien(dtct);
			d_cls=zsotien(dtvp);
            if (bBHYT_Traituyen_tinh_Tyle_khac==false)
            {
                d_dichvu_tt_BHYT_tra = 0; d_tongcp_dichvu_tt = 0;
            }
			d_congkham=(congkham.Text=="")?0:decimal.Parse(congkham.Text);
			thuoc.Text=d_thuoc.ToString(format_sotien);
			cls.Text=d_cls.ToString("###,###,##0");
			d_chiphi=d_thuoc+d_cls+d_congkham;
			chiphi.Text=d_chiphi.ToString("###,###,##0.000");
			d_bntra=0;d_bhyttra=d_chiphi;
            decimal ma, chitra;
			if (maphu.SelectedIndex!=-1)
			{
				if (maphu.SelectedValue.ToString() != "1" && dtdt.Rows[maphu.SelectedIndex]["mien"].ToString()=="0")
				{
					d_bntra=d_chiphi;
					d_bhyttra=0;
				}
                else if (maphu.SelectedValue.ToString() == "1" && sothe.Text != "")
                {
                    if (traituyen != 0 && iTraituyen != 0 && !bTraituyen_bhtra)
                    {
                        chitra = iTraituyen;
                        d_bhyttra = (d_chiphi - d_tongcp_dichvu_tt) * chitra / 100 + d_dichvu_tt_BHYT_tra;
                        d_bntra = d_chiphi - d_bhyttra;
                    }
                    else if (traituyen != 0 && iTraituyen != 0 && bTraituyen_bhtra)
                    {
                        ma = d.get_maphu_ngtru(sothe.Text, 9999999, i_nhom);
                        chitra = (ma == 1) ? 80 : (ma == 2) ? 95 : 100;
                        chitra = chitra * (decimal.Parse(iTraituyen.ToString()) / 100);
                        //chitra = iTraituyen;
                        d_bhyttra = (d_chiphi - d_tongcp_dichvu_tt) * chitra / 100 + d_dichvu_tt_BHYT_tra;
                        d_bntra = d_chiphi - d_bhyttra;
                    }
                    else
                    {
                        ma = d.get_maphu_ngtru(sothe.Text, d_chiphi, i_nhom);
                        if (ma != 0)
                        {
                            chitra = (ma == 1) ? 80 : 95;
                            d_bhyttra = (d_chiphi) * chitra / 100;
                            d_bntra = d_chiphi - d_bhyttra;
                        }
                    }
                }
			}
			bntra.Text=d_bntra.ToString("###,###,###,##0.000");
			bhyttra.Text=d_bhyttra.ToString("###,###,###,##0.000");
		}

		private decimal zsotien(DataTable dt)
		{
			dt.AcceptChanges();
			decimal ret=0;
            decimal tyle_dv_tt = 100;
            foreach (DataRow r in dt.Rows)
            {
                ret += decimal.Parse(r["sotien"].ToString());
                tyle_dv_tt =(r["bhyt_tt"].ToString()=="")?decimal.Parse(r["bhyt"].ToString()): decimal.Parse(r["bhyt_tt"].ToString());
                if (tyle_dv_tt > 0 && tyle_dv_tt < 100 && tyle_dv_tt < 100)
                {
                    d_tongcp_dichvu_tt += decimal.Parse(r["sotien"].ToString());
                    d_dichvu_tt_BHYT_tra += decimal.Parse(r["sotien"].ToString()) * decimal.Parse(r["bhyt_tt"].ToString()) / 100;
                }
            }
			return ret;
		}

		private void quyenso_Validated(object sender, System.EventArgs e)
		{
			if (quyenso.Text=="") return;
			r=d.getrowbyid(dtqs,"sohieu='"+quyenso.Text+"'");
			if (r!=null)
			{
				d.writeXml("d_thongso","c00",quyenso.Text);
				i_quyenso=int.Parse(r["id"].ToString());
				int iso=int.Parse(r["soghi"].ToString())+1;
				sobienlai.Text=iso.ToString();
				m.updrec(dtqs,i_quyenso,sobienlai.Text);
			}
			else 
			{
				MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy !"),d.Msg);
				quyenso.Text="";
			}
		}

		private void butinBL_Click(object sender, System.EventArgs e)
        {
            #region khuyen bo 06/03/2014
            //if (d_bhyttra != 0)
            //{
            //    if (quyenso.Text.Trim().Trim('0') == "" )
            //        {
            //            MessageBox.Show(lan.Change_language_MessageText("Chưa khai báo quyển sổ thu tiền nên không in biên lai được."));
            //            return;
            //        }
            //        else
            //        {
            //            string lydo = lan.Change_language_MessageText("Người bệnh thanh toán") + " ";
            //            dsxml.Clear();
            //            DataRow r1;
            //            DataTable dtuserduyet = m.get_data("select b.hoten from " + xxx + ".bhytkb a inner join " + user + ".d_dlogin b on a.userid=b.id where a.id=" + cmbSophieu.SelectedValue.ToString() + "").Tables[0];
            //            for (int i = 0; i < dslien.Tables[0].Rows.Count; i++)
            //            {
            //                r1 = dsxml.Tables[0].NewRow();
            //                r1["syt"] = m.Syte;
            //                r1["bv"] = m.Tenbv;
            //                r1["diachibv"] = m.Diachi;
            //                r1["tongcucthue"] = "";
            //                r1["cucthue"] = "";
            //                r1["masothue"] = v.Masothue;
            //                r1["mauso"] = v.Mausobienlai;
            //                r1["nguoiin"] = "";
            //                r1["ngaysinh"] = namsinh.Text;
            //                r1["gioitinh"] = "";
            //                r1["quyenso"] = quyenso.Text;
            //                r1["sobienlai"] = sobienlai.Text;
            //                r1["hoten"] = hoten.Text;
            //                r1["mabn"] = sophieu.Text;
            //                r1["diachi"] = diachi.Text;
            //                r1["khoa"] = tenkp.Text;
            //                r1["lydo"] = lydo;
            //                r1["sotien"] = d_bntra.ToString();
            //                r1["chutien"] = doiso.doithapphan(d_bntra.ToString());
            //                r1["diengiai"] = lydo;
            //                r1["ghichu"] = lydo;
            //                r1["ngayin"] = ngaysp.Text.Substring(0, 10);
            //                r1["lien"] = dslien.Tables[0].Rows[i]["ten"].ToString();
            //                r1["nguoithu"] = dtuserduyet.Rows[0]["hoten"].ToString();
            //                dsxml.Tables[0].Rows.Add(r1);
            //            }
            //            if (d.bPreview)
            //            {
            //                frmReport f = new frmReport(d, dsxml.Tables[0], "", "", "v_bienlaithuvienphi.rpt");
            //                f.ShowDialog(this);
            //            }
            //            else print.Printer(d, dsxml, "v_bienlaithuvienphi.rpt", "", "", 0);
            //            d.execute_data("update " + yyy + ".bhytkb set done=1 where id=" + l_id);
            //}
            #endregion
 //khuyen 06/03/14 in ca khi khong co so bien lai va quyen so khi chon check in bien lai khong can quyen so va so bien lai
               
            if (d_bntra!=0)
			{
               
                if (!chkInbienlai_kquyensoKbienlai.Checked)
                {
                    if (quyenso.Text.Trim().Trim('0') == "" || sobienlai.Text.Trim().Trim('0') == "")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Chưa khai báo quyển sổ thu tiền nên không in biên lai được."));
                        return;
                    }
                    else
                    {
                        string lydo = lan.Change_language_MessageText("Người bệnh thanh toán") + " ";
                        dsxml.Clear();
                        DataRow r1;
                        DataTable dtuserduyet = m.get_data("select b.hoten from " + xxx + ".bhytkb a inner join " + user + ".d_dlogin b on a.userid=b.id where a.id=" + cmbSophieu.SelectedValue.ToString() + "").Tables[0];
                        for (int i = 0; i < dslien.Tables[0].Rows.Count; i++)
                        {
                            r1 = dsxml.Tables[0].NewRow();
                            r1["syt"] = m.Syte;
                            r1["bv"] = m.Tenbv;
                            r1["diachibv"] = m.Diachi;
                            r1["tongcucthue"] = "";
                            r1["cucthue"] = "";
                            r1["masothue"] = v.Masothue;
                            r1["mauso"] = v.Mausobienlai;
                            r1["nguoiin"] = "";
                            r1["ngaysinh"] = namsinh.Text;
                            r1["gioitinh"] = "";
                            r1["quyenso"] = quyenso.Text;
                            r1["sobienlai"] = sobienlai.Text;
                            r1["hoten"] = hoten.Text;
                            r1["mabn"] = sophieu.Text;
                            r1["diachi"] = diachi.Text;
                            r1["khoa"] = tenkp.Text;
                            r1["lydo"] = lydo;
                            r1["sotien"] = d_bntra.ToString();
                            r1["chutien"] = doiso.doithapphan(d_bntra.ToString());
                            r1["diengiai"] = lydo;
                            r1["ghichu"] = lydo;
                            r1["ngayin"] = ngaysp.Text.Substring(0, 10);
                            r1["lien"] = dslien.Tables[0].Rows[i]["ten"].ToString();
                            r1["nguoithu"] = dtuserduyet.Rows[0]["hoten"].ToString();
                            dsxml.Tables[0].Rows.Add(r1);
                        }
                        if (d.bPreview)
                        {
                            frmReport f = new frmReport(d, dsxml.Tables[0], i_userid, "", "", "v_bienlaithuvienphi.rpt");
                            f.ShowDialog(this);
                        }
                        else print.Printer(d, dsxml, "v_bienlaithuvienphi.rpt", "", "", 0);
                        d.execute_data("update " + yyy + ".bhytkb set done=1 where id=" + l_id);
                    }
                    //
                }
                else
                {
                    string lydo = lan.Change_language_MessageText("Người bệnh thanh toán") + " ";
                    dsxml.Clear();
                    DataRow r1;
                    DataTable dtuserduyet = m.get_data("select b.hoten from " + xxx + ".bhytkb a inner join " + user + ".d_dlogin b on a.userid=b.id where a.id=" + cmbSophieu.SelectedValue.ToString() + "").Tables[0];
                    for (int i = 0; i < dslien.Tables[0].Rows.Count; i++)
                    {
                        r1 = dsxml.Tables[0].NewRow();
                        r1["syt"] = m.Syte;
                        r1["bv"] = m.Tenbv;
                        r1["diachibv"] = m.Diachi;
                        r1["tongcucthue"] = "";
                        r1["cucthue"] = "";
                        r1["masothue"] = v.Masothue;
                        r1["mauso"] = v.Mausobienlai;
                        r1["nguoiin"] = "";
                        r1["ngaysinh"] = namsinh.Text;
                        r1["gioitinh"] = "";
                        r1["quyenso"] = quyenso.Text;
                        r1["sobienlai"] = sobienlai.Text;
                        r1["hoten"] = hoten.Text;
                        r1["mabn"] = sophieu.Text;
                        r1["diachi"] = diachi.Text;
                        r1["khoa"] = tenkp.Text;
                        r1["lydo"] = lydo;
                        r1["sotien"] = d_bntra.ToString();
                        r1["chutien"] = doiso.doithapphan(d_bntra.ToString());
                        r1["diengiai"] = lydo;
                        r1["ghichu"] = lydo;
                        r1["ngayin"] = ngaysp.Text.Substring(0, 10);
                        r1["lien"] = dslien.Tables[0].Rows[i]["ten"].ToString();
                        r1["nguoithu"] = dtuserduyet.Rows[0]["hoten"].ToString();
                        dsxml.Tables[0].Rows.Add(r1);
                    }
                    if (d.bPreview)
                    {
                        frmReport f = new frmReport(d, dsxml.Tables[0], i_userid, "", "", "v_bienlaithuvienphi.rpt");
                        f.ShowDialog(this);
                    }
                    else print.Printer(d, dsxml, "v_bienlaithuvienphi.rpt", "", "", 0);
                    if (quyenso.Text.Trim().Trim('0') != "" && sobienlai.Text.Trim().Trim('0') != "")//khuyen 06/03/14 
                    {
                        d.execute_data("update " + yyy + ".bhytkb set done=1 where id=" + l_id);
                    }
                   
                }
                
                
			}
            //end khuyen
		}

		private void butDichvu_Click(object sender, System.EventArgs e)
		{
            if (makp.Text == "" || tenkp.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập khoa/phòng !"), d.Msg);
                makp.Focus();
                return;
            }
            r = d.getrowbyid(dtkp, "makp='" + makp.Text + "'");
            if (r != null)
            {
                string s_loaivp = r["loaivp"].ToString().Trim(), s_mucvp = r["mucvp"].ToString().Trim();
                s_loaivp = (s_loaivp == "") ? "" : s_loaivp.Substring(0, s_loaivp.Length - 1);
                s_mucvp = (s_mucvp == "") ? "" : s_mucvp.Substring(0, s_mucvp.Length - 1);
                //frmChonchidinh1 f=new frmChonchidinh1(m,sophieu.Text,1,s_loaivp,s_mucvp);
                //f.ShowDialog(this);
                frmChonchidinh f = new frmChonchidinh(m, sophieu.Text,int.Parse(maphu.SelectedValue.ToString()), s_loaivp, s_mucvp, i_loai, sothe.Text, v1, v2, false, l_mavaovien,"", l_maql, s_ngay);
                f.SapxepTenKT_TheoABC = false;
                f.ShowDialog(this);
                if (f.dt.Rows.Count > 0)
                {
                    DataRow r2;
                    foreach (DataRow r1 in f.dt.Rows)
                    {
                        r2 = d.getrowbyid(dtdmvp, "id=" + int.Parse(r1["mavp"].ToString()));
                        if (r2 != null) d.updrec_bhytcls(dtvp, d.get_stt(dtvp), int.Parse(r1["mavp"].ToString()), r2["ma"].ToString(), r2["ten"].ToString(), r2["dvt"].ToString(), 1, decimal.Parse(r2["dongia"].ToString()), decimal.Parse(r2["dongia"].ToString()), l_idchidinh);
                    }
                    ref_text1();
                }
            }
            else MessageBox.Show(lan.Change_language_MessageText("Khoa/phòng không hợp lệ !"), d.Msg);
		}

		private void tenvp_Validated(object sender, System.EventArgs e)
		{
			if(!listVP.Focused) listVP.Hide();
		}

		private void timkiem_Enter(object sender, System.EventArgs e)
		{
			timkiem.Text="";
		}

		private void timkiem_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==timkiem) RefreshChildren(timkiem.Text);
		}

        private void butTreem_Click(object sender, System.EventArgs e)
        {
            if (dtct.Rows.Count == 0 && dtvp.Rows.Count == 0 || maphu.SelectedIndex==-1) return;
            DataSet dst = new DataSet();
            dst = dsxmlin.Copy();
            DataRow r2, r3;
            string s_chandoan = "", s_maicd = "", s_tenkp = "", s_tenbs = "", maso = "", s_soluutru = "^", s_cachdung = "", s_tentuyentruoc="";// chandoan.Text.Trim() + ";";
            decimal mavaovien = 0;
            //Thuy 11.06.2012
            string xxx = m.mmyy(s_ngay);
            string mmyysau = m.Mmyy_sau(s_mmyy);
            string mmyytruoc = m.Mmyy_truoc(s_mmyy);
            string yyysau = user + mmyysau;
            string yyyhientai = user + s_mmyy ;
            string yyytruoc = user + mmyytruoc;
            //gam 07/11/2011
            string s_ngayvv = "", s_ngayrv = "",asql = "";
            string asql1 = "(select ngay,mavaovien from xxx.v_chidinh where mavaovien=" + l_mavaovien + " union all  select ngay,mavaovien from xxx.d_thuocbhytll where mavaovien=" + l_mavaovien + " ";
            if(m.bMmyy(yyytruoc))
            {
                asql1 += " union select ngay,mavaovien from " + yyytruoc + ".v_chidinh where mavaovien=" + l_mavaovien + " union all  select ngay,mavaovien from " + yyytruoc + ".d_thuocbhytll where mavaovien=" + l_mavaovien + "" ;
            }
            asql1 +=" )";
            asql = "select to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv, to_char((case when b.bove=1 then max(c.ngay) else b.ngay end),'yyyy/mm/dd hh24:mi') as ngayrv "; 
            asql += "from "+user+".vi_benhanpk a inner join xxx.bhytkb b on a.mavaovien=b.mavaovien left join ";
            asql += asql1;
            asql += " c on b.mavaovien=c.mavaovien where a.mavaovien="+l_mavaovien+" group by a.ngay,b.bove,b.ngay";
            asql += " union ";
            asql += "select to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv, to_char((case when b.bove=1 then max(c.ngay) else b.ngay end),'yyyy/mm/dd hh24:mi') as ngayrv ";
            asql += "from " + user + ".vi_benhancc a inner join xxx.bhytkb b on a.mavaovien=b.mavaovien left join ";
            asql += asql1;
            asql += " c on b.mavaovien=c.mavaovien where a.mavaovien=" + l_mavaovien + " group by a.ngay,b.bove,b.ngay";
            asql += " union ";
            asql += " select to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv, to_char((case when b.bove=1 then max(c.ngay) else coalesce(a.ngayrv,b.ngay) end),'yyyy/mm/dd hh24:mi') as ngayrv ";
            asql +=  " from "+user+".benhanngtr a inner join xxx.bhytkb b on a.mavaovien=b.mavaovien inner join ";
            asql += asql1;
            asql += " c on b.mavaovien=c.mavaovien where a.mavaovien=" + l_mavaovien + " group by a.ngay,b.bove,b.ngay,a.ngayrv";
            DataSet dsngay = d.get_data_mmyy(asql,s_ngay,s_ngay,true);
            if (m.bMmyy(mmyysau))
            {
                asql = "select to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv, to_char((case when b.bove=1 then max(c.ngay) else b.ngay end),'yyyy/mm/dd hh24:mi') as ngayrv ";
                asql += "from " + yyyhientai + ".benhanpk a inner join " + yyysau + ".bhytkb b on a.mavaovien=b.mavaovien inner join ";
                asql += "( select ngay,mavaovien from " + yyyhientai + ".v_chidinh where mavaovien=" + l_mavaovien + " union all  select ngay,mavaovien from " + yyyhientai + ".d_thuocbhytll where mavaovien=" + l_mavaovien + " ) c ";
                asql += "on b.mavaovien=c.mavaovien where a.mavaovien=" + l_mavaovien + " group by a.ngay,b.bove,b.ngay";
                asql += " union ";
                asql += "select to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv, to_char((case when b.bove=1 then max(c.ngay) else b.ngay end),'yyyy/mm/dd hh24:mi') as ngayrv ";
                asql += "from " + yyyhientai + ".benhancc a inner join " + yyysau + ".bhytkb b on a.mavaovien=b.mavaovien inner join ";
                asql += "( select ngay,mavaovien from " + yyyhientai + ".v_chidinh where mavaovien=" + l_mavaovien + " union all  select ngay,mavaovien from " + yyyhientai + ".d_thuocbhytll where mavaovien=" + l_mavaovien + " ) c ";
                asql += "on b.mavaovien=c.mavaovien where a.mavaovien=" + l_mavaovien + " group by a.ngay,b.bove,b.ngay";
                
                DataSet dsngay1 = d.get_data(asql);
                dsngay.Merge(dsngay1);
            }
            if (dsngay.Tables[0].Rows.Count == 0)
            {
                asql = "select to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayrv from " + yyyhientai + ".bhytkb a where mavaovien="+l_mavaovien;
                dsngay = d.get_data(asql);
            }
            foreach (DataRow r_ct in dsngay.Tables[0].Select("", "ngayrv desc"))
            {
                s_ngayvv = r_ct["ngayvv"].ToString();
                //Lúc lấy ngayrv theo kieu yyy/mm/dd hh24:mi để desc lấy ngày lớn nhất lên-> cắt chuỗi lấy lại kiểu đ/mm/yyyy hh24:mi
                s_ngayrv = r_ct["ngayrv"].ToString().Substring(8, 2).PadLeft(2, '0') + "/" + r_ct["ngayrv"].ToString().Substring(5, 3) + r_ct["ngayrv"].ToString().Substring(0, 4) + r_ct["ngayrv"].ToString().Substring(10);
                break;
            }
            //end gam
            bool bTiepdon_nkp_inchungchiphi = m.bTiepdon_nkp_inchungchiphi, bLocbaohiem = d.bLocbaohiem;
            bool b_dacocdkemtheo = false; 
            decimal chitra = 100;
            foreach (DataRow r1 in d.get_data_mmyy("select * from xxx.benhanpk where maql=" + l_maql, s_tu, s_den, songayduyet).Tables[0].Rows)
            {
                mavaovien = decimal.Parse(r1["mavaovien"].ToString());
            }
            foreach (DataRow r33 in d.get_data_mmyy("select b.tenbv from xxx.noigioithieu a," + user + ".dstt b where a.mabv=b.mabv and a.maql=" + l_maql, s_tu, s_den, songayduyet).Tables[0].Rows)
            {
                s_tentuyentruoc = r33["tenbv"].ToString().Trim();
            }
            string cholam = "",s_tuoi="",s_ngaysinh="";
            foreach (DataRow r1 in d.get_data("select cholam," + int.Parse(s_ngayvv.Substring(6, 4)) + "-to_number(namsinh,'0000') as tuoi,ngaysinh from " + user + ".btdbn where mabn='" + sophieu.Text + "'").Tables[0].Rows)
            {
                cholam = r1["cholam"].ToString();
                s_tuoi = r1["tuoi"].ToString();
                s_ngaysinh = r1["ngaysinh"].ToString();
            }
             if (l_mavaovien != 0)
             {
                 string s_cd_ct = "", s_icd_ct = "", s_maql = "";
                 sql = "select a.maql,coalesce(a1.chandoan,a.chandoan) as chandoan,coalesce(a1.maicd,a.maicd) as maicd,a.makp,b.tenkp,a.mabs,c.hoten as tenbs,to_char(a.ngay,'dd/mm/yyyy') as ngay from xxx.bhytkb a inner join xxx.benhanpk a1 on a.mavaovien=a1.mavaovien inner join " + user + ".btdkp_bv b on a.makp=b.makp left join " + user + ".dmbs c on a.mabs=c.ma where a.mavaovien=" + l_mavaovien + " order by a.maql";
                 DataSet ads = d.get_data_mmyy(sql, s_tu, s_den, songayduyet);
                 if (ads == null || ads.Tables.Count <= 0 || ads.Tables[0].Rows.Count <= 0)
                 {
                     sql = " select a.maql, a.chandoan, a.maicd, a.makp,b.tenkp,a.mabs,c.hoten as tenbs,to_char(a.ngay,'dd/mm/yyyy') as ngay from xxx.benhanpk a inner join " + user + ".btdkp_bv b on a.makp=b.makp left join " + user + ".dmbs c on a.mabs=c.ma where a.mavaovien=" + l_mavaovien + " order by a.maql";
                     ads = d.get_data_mmyy(sql, s_tu, s_den, songayduyet);
                 }
                 foreach (DataRow r in ads.Tables[0].Rows)
                 {
                     if (bInchiphi_chandoan_bacsy)
                     {
                         if (s_maql != r["maql"].ToString())
                         {
                             s_icd_ct = r["maicd"].ToString() + "; "; s_cd_ct = r["chandoan"].ToString() + "; "; s_maql = r["maql"].ToString();
                             b_dacocdkemtheo = false;
                             foreach (DataRow r1 in m.get_data("select chandoan,maicd from " + user + m.mmyy(r["ngay"].ToString()) + ".cdkemtheo where maql=" + s_maql + " order by stt").Tables[0].Rows)
                             {
                                 s_cd_ct += (s_cd_ct.IndexOf(r1["chandoan"].ToString().Trim() + ";") < 0) ? r1["chandoan"].ToString().Trim() + "; " : "";
                                 s_icd_ct += (s_icd_ct.IndexOf(r1["maicd"].ToString().Trim() + ";") < 0) ? r1["maicd"].ToString().Trim() + "; " : "";
                                 b_dacocdkemtheo = true;
                             }
                             if (!b_dacocdkemtheo)
                             {
                                 string s_maql_pk_pl_makp = m.f_get_maql(l_mavaovien, r["ngay"].ToString(), r["ngay"].ToString(), r["makp"].ToString());
                                 if (s_maql_pk_pl_makp.Trim().Trim(',') != "")
                                 {
                                     foreach (DataRow r1 in m.get_data("select chandoan,maicd from " + user + m.mmyy(r["ngay"].ToString()) + ".cdkemtheo where maql in(" + s_maql_pk_pl_makp.Trim().Trim(',') + ") order by stt").Tables[0].Rows)
                                     {
                                         s_cd_ct += (s_cd_ct.IndexOf(r1["chandoan"].ToString().Trim() + ";") < 0) ? r1["chandoan"].ToString().Trim() + "; " : "";
                                         s_icd_ct += s_icd_ct.IndexOf(r1["maicd"].ToString().Trim() + ";") < 0 ? r1["maicd"].ToString().Trim() + "; " : "";
                                     }
                                 }
                             }
                         }
                         r2 = m.getrowbyid(dst.Tables[0], "maql=" + decimal.Parse(r["maql"].ToString()));
                         if (r2 == null)
                         {
                             maso += r["maql"].ToString() + ",";
                             r3 = dst.Tables[0].NewRow();
                             r3["maql"] = decimal.Parse(r["maql"].ToString());
                             r3["maicd"] = s_icd_ct;// r["maicd"].ToString();
                             r3["chandoan"] = s_cd_ct;// r["chandoan"].ToString();
                             r3["mabs"] = r["mabs"].ToString();
                             r3["tenbs"] = r["tenbs"].ToString();
                             r3["makp"] = r["makp"].ToString();
                             r3["tenkp"] = r["tenkp"].ToString();
                             if (File.Exists("..\\..\\..\\chuky\\" + r["mabs"].ToString() + ".bmp"))
                             {
                                 fstr = new FileStream("..\\..\\..\\chuky\\" + r["mabs"].ToString() + ".bmp", FileMode.Open, FileAccess.Read);
                                 image = new byte[fstr.Length];
                                 fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                                 fstr.Close();
                                 r3["Image"] = image;
                             }
                             dst.Tables[0].Rows.Add(r3);
                         }
                     }
                     if(s_maicd.IndexOf(r["maicd"].ToString().Trim() + ";")<0) s_maicd += r["maicd"].ToString().Trim() + ";";
                     if (s_chandoan.IndexOf(r["chandoan"].ToString().Trim() + ";") < 0) s_chandoan += r["chandoan"].ToString().Trim() + ";";

                     if (s_tenkp.IndexOf(r["tenkp"].ToString().Trim() + ";") < 0) s_tenkp += r["tenkp"].ToString().Trim() + ";";
                     if (s_tenbs.IndexOf(r["tenbs"].ToString().Trim() + ";") < 0) s_tenbs += r["tenbs"].ToString() + "; ";
                     //
                     b_dacocdkemtheo = false;
                     foreach (DataRow r1 in m.get_data("select chandoan,maicd from " + user + m.mmyy(r["ngay"].ToString()) + ".cdkemtheo where maql=" + decimal.Parse(r["maql"].ToString()) + " order by stt").Tables[0].Rows)
                     {
                         s_chandoan += (s_chandoan.IndexOf(r1["chandoan"].ToString().Trim() + ";") < 0) ? r1["chandoan"].ToString().Trim() + "; " : "";
                         s_maicd += s_maicd.IndexOf(r1["maicd"].ToString().Trim() + ";") < 0 ? r1["maicd"].ToString().Trim() + "; " : "";
                         b_dacocdkemtheo = true;
                     }
                     if (!b_dacocdkemtheo)
                     {
                         string s_maql_pk_pl = m.f_get_maql(l_mavaovien, r["ngay"].ToString(), r["ngay"].ToString());
                         if (s_maql_pk_pl.Trim().Trim(',') != "")
                         {
                             foreach (DataRow r1 in m.get_data("select chandoan,maicd from " + user + m.mmyy(r["ngay"].ToString()) + ".cdkemtheo where maql in(" + s_maql_pk_pl.Trim().Trim(',') + ") order by stt").Tables[0].Rows)
                             {
                                 s_chandoan += (s_chandoan.IndexOf(r1["chandoan"].ToString().Trim() + ";") < 0) ? r1["chandoan"].ToString().Trim() + "; " : "";
                                 s_maicd += s_maicd.IndexOf(r1["maicd"].ToString().Trim() + ";") < 0 ? r1["maicd"].ToString().Trim() + "; " : "";
                             }
                         }
                     }
                     //
                     //
                     if (i_loai == 1 || i_loaiba == 2)
                     {
                         foreach (DataRow r1 in m.get_data("select chandoan,maicd from " + user + ".cdkemtheo where maql=" + decimal.Parse(r["maql"].ToString()) + " order by stt").Tables[0].Rows) 
                         {
                             s_chandoan += (s_chandoan.IndexOf(r1["chandoan"].ToString().Trim() + ";") < 0) ? r1["chandoan"].ToString().Trim() + "; " : "";
                             s_maicd += s_maicd.IndexOf(r1["maicd"].ToString().Trim() + ";") < 0 ? r1["maicd"].ToString().Trim() + "; " : "";
                         }
                     }

                     if (i_loaiba == 2)
                     {
                         foreach (DataRow r1 in m.get_data("select chandoan,maicd, chandoanrv, maicdrv from " + user + ".benhanngtr where mavaovien=" + l_mavaovien + " and mavaovien<>0 ").Tables[0].Rows)
                         {
                             if (r1["chandoanrv"].ToString().Trim() != "")
                             {
                                 s_chandoan += (s_chandoan.IndexOf(r1["chandoanrv"].ToString().Trim() + ";") < 0) ? r1["chandoanrv"].ToString().Trim() + "; " : "";
                                 s_maicd += s_maicd.IndexOf(r1["maicdrv"].ToString().Trim() + ";") < 0 ? r1["maicdrv"].ToString().Trim() + "; " : "";
                             }
                             s_chandoan += (s_chandoan.IndexOf(r1["chandoan"].ToString().Trim() + ";") < 0) ? r1["chandoan"].ToString().Trim() + "; " : "";
                             s_maicd += s_maicd.IndexOf(r1["maicd"].ToString().Trim() + ";") < 0 ? r1["maicd"].ToString().Trim() + "; " : "";
                         }
                     }
                 }
             }
            if (s_chandoan == "")
            {
                s_chandoan = chandoan.Text.Trim() + ";";
                s_maicd = maicd.Text + ";";
            }
            if (mavaovien == 0)
            {
                foreach (DataRow r1 in d.get_data_mmyy("select * from xxx.benhancc where maql=" + l_maql, s_tu, s_den, songayduyet).Tables[0].Rows)
                {
                    mavaovien = decimal.Parse(r1["mavaovien"].ToString());
                    s_soluutru = r1["sovaovien"].ToString() + "^" + r1["soluutru"].ToString();
                }
                if (mavaovien == 0)
                {
                    foreach (DataRow r1 in d.get_data("select matiepdon as mavaovien from " + user + ".sukien where macap=" + l_maql).Tables[0].Rows)
                    {
                        mavaovien = decimal.Parse(r1["mavaovien"].ToString());
                        s_soluutru = "^";
                    }
                }
                if (mavaovien == 0)
                {
                    foreach (DataRow r1 in d.get_data_mmyy("select * from "+user+".benhanngtr where maql=" + l_maql, s_tu, s_den, songayduyet).Tables[0].Rows)
                    {
                        mavaovien = decimal.Parse(r1["mavaovien"].ToString());
                        s_soluutru = r1["sovaovien"].ToString() + "^" + r1["soluutru"].ToString();
                    }
                }
            }
            if (m.bSoluutruPK_PL_NGT_tudong ||m.bSoluutrutangtudong_PK_PL_6so)  // truongthuy them 19052014 
            {

                foreach (DataRow r1 in d.get_data_mmyy("select soluutru from " + user + ".lienhe where maql=" + l_maql +" union all select soluutru from xxx.lienhe where maql=" + l_maql +"" , s_tu, s_den, songayduyet).Tables[0].Rows)
                {

                    s_soluutru =  r1["soluutru"].ToString();
                }

            }
            int _userid = -1;
            int isophieu = d.get_sophieu_bhyt_userid(s_mmyy, sophieu.Text, mavaovien, ngaysp.Text, int.Parse(maphu.SelectedValue.ToString()), _userid, ngay_reset_phieu38 );
            int lanin = d.get_laninkb(s_mmyy, sophieu.Text, mavaovien, ngaysp.Text, int.Parse(maphu.SelectedValue.ToString()));
            int d_toaso = d.get_sotoa_bhyt(s_mmyy, l_id, ngaysp.Text, i_madoituong);
            d.execute_data("update " + user + s_mmyy + ".bhytkb set sotoa=" + d_toaso + " where id=" + l_id);
            d.updrec_bhytll(dtll, l_id, d_toaso);
            int iTuoi = (namsinh.Text != "") ? DateTime.Now.Year - int.Parse(namsinh.Text) : 0;
            DataSet ds1;
            //string mmyytruoc = m.Mmyy_truoc(s_mmyy);
            //string yyytruoc = user + mmyytruoc;
            string s_tablebhyt = "";
            if (i_loaiba == 2 || i_loaiba == 1)
            {
                s_tablebhyt = "select mabn,maql,sothe,tungay,denngay,mabv,traituyen,sudung from " + user + ".bhyt where mabn='" + cmbSophieu.Text + "'";
                s_tablebhyt += " union all ";
                s_tablebhyt += "select  mabn,maql,sothe,tungay,denngay,mabv,traituyen,sudung from " + yyy + ".bhyt where mabn='" + cmbSophieu.Text + "'";
                if (m.bMmyy(mmyytruoc))
                {
                    s_tablebhyt += " union all ";
                    s_tablebhyt += "select  mabn,maql,sothe,tungay,denngay,mabv,traituyen,sudung from " + yyytruoc + ".bhyt where mabn='" + cmbSophieu.Text + "'";
                }
            }
            else
            {
                s_tablebhyt = "select  mabn,maql,sothe,tungay,denngay,mabv,traituyen,sudung from " + yyy + ".bhyt where mabn='" + cmbSophieu.Text + "'";
                if (m.bMmyy(mmyytruoc))
                {
                    s_tablebhyt += " union all ";
                    s_tablebhyt += "select  mabn,maql,sothe,tungay,denngay,mabv,traituyen,sudung from " + yyytruoc + ".bhyt where mabn='" + cmbSophieu.Text + "'";
                }
            }

            s_tablebhyt = "(select distinct mabn,maql,sothe,tungay,denngay,mabv,traituyen,sudung from (" + s_tablebhyt + ") o)";
            string fie = (bGia_bh_quydinh_giamua) ? "giamua" : "giaban";
            
            if (bchenhlech_thuoc && (bGiaban || bGia_bh_quydinh) && s_chenhlech.IndexOf(maphu.SelectedValue.ToString().PadLeft(2,'0'))!=-1)
            {
                sql = "select 1 as id,a.stt,a.sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,e.ten as tenkho,c.ten as tennguon,d.ten as tennhomcc,t.handung,t.losx,a.soluong,";
                if (bGia_bh_quydinh && bLaygiamua_khi_giabh_0_giabh_nho_giamua ) sql += "(case when a.gia_bh=0 or t.giamua<a.gia_bh then t.giamua else a.gia_bh end) as dongia,(case when a.gia_bh=0 or t.giamua<a.gia_bh then t.giamua else a.gia_bh end)*a.soluong as sotien,";
                else if (bGia_bh_quydinh && bLaygiamua_khi_giabh_0_giabh_nho_giamua == false) sql += "a.gia_bh as dongia,a.gia_bh*a.soluong as sotien,";
                //else sql += "a.giaban as dongia,a.giaban*a.soluong as sotien,";//gam 10/10/2011
                else sql += ""+ (bGiaban ? "t.giaban" : "t.giamua") + " as dongia,a.soluong*" + (bGiaban ? "t.giaban" : "t.giamua") + " as sotien,";//Thuy 07.11.2012
                sql += "a.cachdung,a.makho,t.manguon,t.nhomcc,f.mabs,f.chandoan,h.tenkp,f.maql,f.makp,f.maphu as madoituong ";
                sql += ",i.ten as hangsx, j.ten as nuocsx, b.bhyt as bhyt_tt ";
                sql += ",k.traituyen ";// gam 17/01/2012 inner join thêm table medibvxxx.bhyt --> lấy field trai tuyến
                sql += " from xxx.bhytthuoc a," + user + ".d_dmbd b," + user + ".d_dmnguon c," + user + ".d_dmnx d," + user + ".d_dmkho e, xxx.bhytkb f, xxx.d_theodoi t," + user + ".btdkp_bv h";
                sql += ", " + user + ".d_dmhang i, " + user + ".d_dmnuoc j , " + s_tablebhyt + " k ";
                sql += " where a.sttt=t.id and f.id=a.id and a.mabd=b.id and t.manguon=c.id and t.nhomcc=d.id and a.makho=e.id and f.makp=h.makp";
                sql += " and b.mahang=i.id(+) and b.manuoc=j.id(+)";
                sql += " and f.maql=k.maql(+) ";//gam 17/01/2012
                sql += " and f.mabn='" + sophieu.Text + "'";
                if (i_khudt != 0) sql += " and (h.khu=0 or h.khu=" + i_khudt + ")";//binh 210411
                if (chkintrongngay.Checked) sql += " and to_char(f.ngay,'dd/mm/yyyy')='" + s_ngay + "'";//binh 070711 
                if (mavaovien != 0 && bTiepdon_nkp_inchungchiphi) sql += " and (f.mavaovien=" + mavaovien + " or to_char(f.ngay,'dd/mm/yyyy')='" + s_ngay + "')";//lay chung ngay hoac cung mavaovien
                else if (mavaovien != 0 && bTiepdon_nkp_inchungchiphi == false) sql += " and f.mavaovien=" + mavaovien;
                //
                if (chkInchuathu.Checked)//chi in nhung chi phi chua thu
                {
                    sql += " and f.quyenso<>0 and f.sobienlai<>0";
                }
                
                if (bThuchenhlechtruoc_duyettoasau == false)
                {
                    sql += " union all ";
                    sql += "select 1 as id,a.stt,a.sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,e.ten as tenkho,c.ten as tennguon,d.ten as tennhomcc,t.handung,t.losx,a.soluong,";
                    //if (bGia_bh_quydinh) sql += "t."+fie+"-b.gia_bh as dongia,(t."+fie+"-b.gia_bh)*a.soluong as sotien,";
                    if (bGia_bh_quydinh && bLaygiamua_khi_giabh_0_giabh_nho_giamua ) sql += "t." + fie + " -(case when a.gia_bh=0 or t.giamua<a.gia_bh then t.giamua else a.gia_bh end) as dongia,(t." + fie + "-(case when a.gia_bh=0 or t.giamua<a.gia_bh then t.giamua else a.gia_bh end))*a.soluong as sotien,";
                    else if (bGia_bh_quydinh && bLaygiamua_khi_giabh_0_giabh_nho_giamua==false ) sql += "t." + fie + " - a.gia_bh as dongia,(t." + fie + "-a.gia_bh )*a.soluong as sotien,";
                    else sql += "t.giaban-t.giamua as dongia,(t.giaban-t.giamua)*a.soluong as sotien,";
                    sql += "a.cachdung,a.makho,t.manguon,t.nhomcc,f.mabs,f.chandoan,h.tenkp,f.maql,f.makp," + i_tunguyen + " as madoituong ";
                    sql += ",i.ten as hangsx, j.ten as nuocsx, b.bhyt as bhyt_tt ";
                    sql += ",k.traituyen ";// gam 17/01/2012
                    sql += " from xxx.bhytthuoc a," + user + ".d_dmbd b," + user + ".d_dmnguon c," + user + ".d_dmnx d," + user + ".d_dmkho e,xxx.bhytkb f,xxx.d_theodoi t," + user + ".btdkp_bv h";
                    sql += ", " + user + ".d_dmhang i, " + user + ".d_dmnuoc j , " + s_tablebhyt + " k ";
                    sql += " where a.sttt=t.id and f.id=a.id and a.mabd=b.id and t.manguon=c.id and t.nhomcc=d.id and a.makho=e.id and f.makp=h.makp";
                    sql += " and b.mahang=i.id(+) and b.manuoc=j.id(+)";
                    sql += " and k.maql=f.maql ";//gam 17/01/2012
                    sql += " and f.mabn='" + sophieu.Text + "'";
                    if (i_khudt != 0) sql += " and (h.khu=0 or h.khu=" + i_khudt + ")";//binh 210411
                    if (chkintrongngay.Checked) sql += " and to_char(f.ngay,'dd/mm/yyyy')='" + s_ngay + "'";//binh 070711 
                    if (mavaovien != 0 && bTiepdon_nkp_inchungchiphi) sql += " and (f.mavaovien=" + mavaovien + " or to_char(f.ngay,'dd/mm/yyyy')='" + s_ngay + "')";//lay chung ngay hoac cung mavaovien
                    else if (mavaovien != 0 && bTiepdon_nkp_inchungchiphi == false) sql += " and f.mavaovien=" + mavaovien;
                    if (bChenhlech_thuoc_dannhmuc) sql += " and b.chenhlech=1";
                    if (chkInchuathu.Checked)//chi in nhung chi phi chua thu
                    {
                        sql += " and f.quyenso<>0 and f.sobienlai<>0";
                    }

                    if (bGia_bh_quydinh && bLaygiamua_khi_giabh_0_giabh_nho_giamua) sql += " and t." + fie + " -(case when a.gia_bh=0 or t.giamua<a.gia_bh then t.giamua else a.gia_bh end)>0";
                    else if (bGia_bh_quydinh && bLaygiamua_khi_giabh_0_giabh_nho_giamua == false) sql += "and t." + fie + " - a.gia_bh >0 ";
                    else sql += "and t.giaban-t.giamua >0";
                }
            }
            else
            {
                sql = "select 1 as id,a.stt,a.sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,e.ten as tenkho,c.ten as tennguon,d.ten as tennhomcc,t.handung,t.losx,a.soluong,";
                //if (bDuyet_donvepl || bDuyet_khambenh)//gam 05/11/2011
                //{
                //    sql += "a.giaban as dongia,a.giaban*a.soluong as sotien,";//gam 10/10/2011
                //}
                //else                 
                if (bGiaban)
                {                   
                    sql += "t.giaban as dongia,t.giaban*a.soluong as sotien,";
                }
                else if (bGia_bh_quydinh)
                {
                    sql += "a.gia_bh as dongia, a.gia_bh*a.soluong as sotien,";//gam 10/10/2011
                }
                else sql += "t.giamua as dongia,t.giamua*a.soluong as sotien,";//gam 10/10/2011
                sql += "a.cachdung,a.makho,t.manguon,t.nhomcc,f.mabs,f.chandoan,h.tenkp,f.maql,f.makp,f.maphu as madoituong ";
                sql += ",i.ten as hangsx, j.ten as nuocsx, b.bhyt as bhyt_tt ";
                if (maphu.SelectedValue.ToString() == "1")
                {
                    sql += ",k.traituyen ";
                }
                else
                {
                    sql += ",0 as traituyen ";
                }
                //sql += " from ,," + user + ".d_dmnguon c," + user + ".d_dmnx d,
                //" + user + ".d_dmkho e, ," + user + ".btdkp_bv h";
                sql += " from xxx.bhytthuoc a inner join " + user + ".d_dmbd b on a.mabd=b.id inner join xxx.bhytkb f on f.id=a.id inner join xxx.d_theodoi t on a.sttt=t.id ";
                sql += " inner join " + user + ".d_dmnguon c on t.manguon=c.id inner join " + user + ".d_dmnx d on t.nhomcc=d.id "+
                    " inner join "+user+".d_dmkho e on a.makho=e.id inner join " + user + ".btdkp_bv h on f.makp=h.makp ";
                sql += " left join " + user + ".d_dmhang i on b.mahang=i.id left join " + user + ".d_dmnuoc j on b.manuoc=j.id ";
                if (maphu.SelectedValue.ToString() == "1")
                {
                    sql += " inner join "+s_tablebhyt+" k on k.maql=f.maql ";
                }
                //" + s_tablebhyt + " k ";
                sql += " where f.mabn='" + sophieu.Text + "'";// and to_char(f.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                if (i_khudt != 0) sql += " and (h.khu=0 or h.khu=" + i_khudt + ")";//binh 210411
                if (chkintrongngay.Checked) sql += " and to_char(f.ngay,'dd/mm/yyyy')='" + s_ngay + "'";//binh 070711 
                if (mavaovien != 0 && bTiepdon_nkp_inchungchiphi) sql += " and (f.mavaovien=" + mavaovien + " or to_char(f.ngay,'dd/mm/yyyy')='" + s_ngay + "')";//lay chung ngay hoac cung mavaovien
                else if (mavaovien != 0 && bTiepdon_nkp_inchungchiphi == false) sql += " and f.mavaovien=" + mavaovien;
                if (chkInchuathu.Checked)//chi in nhung chi phi chua thu
                {
                    sql += " and f.quyenso<>0 and f.sobienlai<>0";
                }
            }
            if (bChenhlech && s_chenhlech.IndexOf(maphu.SelectedValue.ToString().PadLeft(2, '0')) != -1 && !chkKodichvu.Checked)
            {
                sql += " union all ";
                sql += "select 3 as id,a.stt,0 as sttt,a.mavp as mabd,b.ma,b.ten,' ' as tenhc,b.dvt as dang,' ' as tenkho,";
                sql += "' ' as tennguon,' ' as tennhomcc,' ' as handung,' ' as losx,a.soluong,";
                sql += " b." + fie_tunguyen + "-b.gia_bh as dongia,a.soluong*(b." + fie_tunguyen + "-b.gia_bh) as sotien,";
                sql += "' ' as cachdung,0 as makho,0 as manguon,0 as nhomcc,";
                sql += "c.mabs,c.chandoan,h.tenkp,c.maql,c.makp," + i_tunguyen + " as madoituong";
                sql += ", null as hangsx, null as nuocsx, b.bhyt_tt,k.traituyen ";
                sql += " from xxx.bhytcls a," + user + ".v_giavp b,xxx.bhytkb c," + user + ".btdkp_bv h ," + s_tablebhyt + " k where c.id=a.id and a.mavp=b.id and c.makp=h.makp";
                sql += " and b.chenhlech =1 "; //Thuy 23.12.2011
                sql += " and c.maql=k.maql ";//gam 17/01/2012
                sql += " and c.mabn='" + sophieu.Text + "'";// and to_char(c.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                if (i_khudt != 0) sql += " and (h.khu=0 or h.khu=" + i_khudt + ")";//binh 210411
                if (chkintrongngay.Checked) sql += " and to_char(c.ngay,'dd/mm/yyyy')='" + s_ngay + "'";//binh 070711 
                sql += " and c.maphu=" + int.Parse(maphu.SelectedValue.ToString());
                sql += " and b." + fie_tunguyen + "-b.gia_bh>0";
                if (mavaovien != 0 && bTiepdon_nkp_inchungchiphi) sql += " and (c.mavaovien=" + mavaovien + " or to_char(c.ngay,'dd/mm/yyyy')='" + s_ngay + "')";//lay chung ngay hoac cung mavaovien
                else if (mavaovien != 0 && bTiepdon_nkp_inchungchiphi == false) sql += " and c.mavaovien=" + mavaovien;
                if (bChenhlech_thuoc_dannhmuc) sql += " and b.chenhlech=1";
                if (chkInchuathu.Checked)//chi in nhung chi phi chua thu
                {
                    sql += " and c.quyenso<>0 and c.sobienlai<>0";
                }
                sql += " union all ";
                sql += "select 3 as id,a.stt,0 as sttt,a.mavp as mabd,b.ma,b.ten,' ' as tenhc,b.dvt as dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,' ' as handung,' ' as losx,a.soluong,a.dongia,a.soluong*a.dongia as sotien,' ' as cachdung,0 as makho,0 as manguon,0 as nhomcc,";
                sql += "c.mabs,c.chandoan,h.tenkp,c.maql,c.makp,c.maphu as madoituong";
                sql += ", null as hangsx, null as nuocsx, b.bhyt_tt,k.traituyen ";
                sql += " from xxx.bhytcls a," + user + ".v_giavp b, xxx.bhytkb c," + user + ".btdkp_bv h ," + s_tablebhyt + " k where c.id=a.id and a.mavp=b.id and c.makp=h.makp";//and a.id="+l_id+" order by a.stt";
                sql += " and c.maql=k.maql ";
                sql += " and c.mabn='" + sophieu.Text + "'";// and to_char(c.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                if (i_khudt != 0) sql += " and (h.khu=0 or h.khu=" + i_khudt + ")";//binh 210411
                if (chkintrongngay.Checked) sql += " and to_char(c.ngay,'dd/mm/yyyy')='" + s_ngay + "'";//binh 070711 
                sql += " and c.maphu=" + int.Parse(maphu.SelectedValue.ToString());
                if (mavaovien != 0 && bTiepdon_nkp_inchungchiphi) sql += " and (c.mavaovien=" + mavaovien + " or to_char(c.ngay,'dd/mm/yyyy')='" + s_ngay + "')";//lay chung ngay hoac cung mavaovien
                else if (mavaovien != 0 && bTiepdon_nkp_inchungchiphi == false) sql += " and c.mavaovien=" + mavaovien;
                if (chkInchuathu.Checked)//chi in nhung chi phi chua thu
                {
                    sql += " and c.quyenso<>0 and c.sobienlai<>0";
                }
                ds1 = d.get_data_mmyy(sql, s_ngay, s_ngay, true);
            }
            else
            {
                sql += " union all ";
                sql += "select 3 as id,a.stt,0 as sttt,a.mavp as mabd,b.ma,b.ten,' ' as tenhc,b.dvt as dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,' ' as handung,' ' as losx,a.soluong,a.dongia,a.soluong*a.dongia as sotien,' ' as cachdung,0 as makho,0 as manguon,0 as nhomcc,";
                sql += "c.mabs,c.chandoan,h.tenkp,c.maql,c.makp,c.maphu as madoituong";
                sql += ", null as hangsx, null as nuocsx, b.bhyt_tt,k.traituyen ";
                sql += " from xxx.bhytcls a," + user + ".v_giavp b,xxx.bhytkb c," + user + ".btdkp_bv h," + s_tablebhyt + " k  where c.id=a.id and a.mavp=b.id and c.makp=h.makp";//and a.id="+l_id+" order by a.stt";
                sql += " and c.maql=k.maql(+) ";//gam 17/01/2012
                sql += " and c.mabn='" + sophieu.Text + "'";// and to_char(c.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                if (i_khudt != 0) sql += " and (h.khu=0 or h.khu=" + i_khudt + ")";//binh 210411
                if (chkintrongngay.Checked) sql += " and to_char(c.ngay,'dd/mm/yyyy')='" + s_ngay + "'";//binh 070711 
                sql += " and c.maphu=" + int.Parse(maphu.SelectedValue.ToString());
                if (mavaovien != 0 && bTiepdon_nkp_inchungchiphi) sql += " and (c.mavaovien=" + mavaovien + " or to_char(c.ngay,'dd/mm/yyyy')='" + s_ngay + "')";//lay chung ngay hoac cung mavaovien
                else if (mavaovien != 0 && bTiepdon_nkp_inchungchiphi == false) sql += " and c.mavaovien=" + mavaovien;
                if (chkInchuathu.Checked)//chi in nhung chi phi chua thu
                {
                    sql += " and c.quyenso<>0 and c.sobienlai<>0";
                }
                ds1 = d.get_data_mmyy(sql, s_ngay, s_ngay, true);
            }
            if (bIncstt)
            {
                string s_field_giaban = (d.bGiaban_theodot(i_nhom)) ? "t.giaban" : "b.giaban";
                if (bchenhlech_thuoc && (bGiaban || bGia_bh_quydinh) && s_chenhlech.IndexOf(maphu.SelectedValue.ToString().PadLeft(2, '0')) != -1)
                {
                    sql = "select 2 as id,a.stt,a.sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,e.ten as tenkho,c.ten as tennguon,d.ten as tennhomcc,t.handung,t.losx,a.soluong,";
                    if (bGia_bh_quydinh && bLaygiamua_khi_giabh_0_giabh_nho_giamua ) sql += "case when a.madoituong =1 then (case when b.gia_bh=0 or t.giamua<b.gia_bh then t.giamua else b.gia_bh end) else (case when k.loai=1 then " + s_field_giaban + " else t.giamua end) end as dongia,(case when a.madoituong =1 then (case when b.gia_bh=0 or t.giamua<b.gia_bh then t.giamua else b.gia_bh end) else (case when k.loai=1 then " + s_field_giaban + " else t.giamua end) end)*a.soluong as sotien,";
                    else if (bGia_bh_quydinh && bLaygiamua_khi_giabh_0_giabh_nho_giamua==false) sql += "case when a.madoituong =1 then b.gia_bh else (case when k.loai=1 then " + s_field_giaban + " else t.giamua end) end as dongia,(case when a.madoituong =1 then b.gia_bh else (case when k.loai=1 then " + s_field_giaban + " else t.giamua end) end)*a.soluong as sotien,";
                    else sql += "t.giamua as dongia,t.giamua*a.soluong as sotien,";
                    sql += "'' as cachdung,a.makho,t.manguon,t.nhomcc,'" + mabs.Text + "' as mabs,'" + chandoan.Text.Replace("\\", "'\'") + "' as chandoan,h.tenkp,f.maql,f.makp,a.madoituong ";
                    sql += ",i.ten as hangsx, j.ten as nuocsx, b.bhyt as bhyt_tt,f.traituyen ";
                    sql += " from xxx.d_xuatsdct a," + user + ".d_dmbd b," + user + ".d_dmnguon c," + user + ".d_dmnx d,";
                    sql += user + ".d_dmkho e,xxx.d_xuatsdll f,xxx.d_theodoi t," + user + ".d_duockp g," + user + ".btdkp_bv h";
                    sql += ", " + user + ".d_dmhang i, " + user + ".d_dmnuoc j, " + user + ".d_doituong k ";
                    sql += " where f.id=a.id and a.mabd=b.id and a.sttt=t.id and t.manguon=c.id and t.nhomcc=d.id and a.makho=e.id and a.madoituong=k.madoituong ";
                    sql += " and b.mahang=i.id(+) and b.manuoc=j.id(+)";
                    sql += "  and f.makp=g.id and g.makp=h.makp ";
                    sql += " and f.mabn='" + sophieu.Text + "'";
                    if (i_khudt != 0) sql += " and (g.khu=0 or g.khu=" + i_khudt + ")";//binh 210411
                    if (mavaovien != 0 && bTiepdon_nkp_inchungchiphi) sql += " and (f.mavaovien=" + mavaovien + " or to_char(f.ngay,'dd/mm/yyyy')='" + ((bLocbaohiem) ? s_ngay : tmp_ngay) + "')";
                    else if (mavaovien != 0 && bTiepdon_nkp_inchungchiphi == false) sql += " and f.mavaovien=" + mavaovien;
                    sql += " and f.loai=2 ";
                    d.merge(ds1, d.get_data_mmyy(sql, s_tu, s_den, songayduyet));
                    sql = "select 2 as id,a.stt,a.sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,e.ten as tenkho,c.ten as tennguon,d.ten as tennhomcc,t.handung,t.losx,a.soluong,";
                    if (bGia_bh_quydinh &&  bLaygiamua_khi_giabh_0_giabh_nho_giamua ) sql += "(case when a.madoituong=1 then (t." + fie + "-(case when b.gia_bh=0 or t.giamua<b.gia_bh then t.giamua else b.gia_bh end)) else 0 end) as dongia,(case when a.madoituong=1 then (t." + fie + "-(case when b.gia_bh=0 then t.giamua else b.gia_bh end)) else 0 end)*a.soluong as sotien,";
                    else if (bGia_bh_quydinh && bLaygiamua_khi_giabh_0_giabh_nho_giamua ==false) sql += "(case when a.madoituong=1 then (t." + fie + "-b.gia_bh) else 0 end) as dongia,(case when a.madoituong=1 then (t." + fie + "-b.gia_bh) else 0 end)*a.soluong as sotien,";
                    else sql += "t.giaban-t.giamua as dongia,(t.giaban-t.giamua)*a.soluong as sotien,";
                    sql += "'' as cachdung,a.makho,t.manguon,t.nhomcc,'" + mabs.Text + "' as mabs,'" + chandoan.Text.Replace("\\", "'\'") + "' as chandoan,h.tenkp,f.maql,f.makp,"+i_tunguyen+" as madoituong ";
                    sql += ",i.ten as hangsx, j.ten as nuocsx, b.bhyt as bhyt_tt,f.traituyen ";
                    sql += " from xxx.d_xuatsdct a," + user + ".d_dmbd b," + user + ".d_dmnguon c," + user + ".d_dmnx d,";
                    sql += user + ".d_dmkho e,xxx.d_xuatsdll f,xxx.d_theodoi t," + user + ".d_duockp g," + user + ".btdkp_bv h";
                    sql += ", " + user + ".d_dmhang i, " + user + ".d_dmnuoc j ";
                    sql += " where f.id=a.id and a.mabd=b.id and a.sttt=t.id and t.manguon=c.id and t.nhomcc=d.id and a.makho=e.id ";
                    sql += " and b.mahang=i.id(+) and b.manuoc=j.id(+)";
                    sql += "  and f.makp=g.id and g.makp=h.makp ";
                    sql += " and f.mabn='" + sophieu.Text + "'";
                    if (i_khudt != 0) sql += " and (g.khu=0 or g.khu=" + i_khudt + ")";//binh 210411
                    if (mavaovien != 0 && bTiepdon_nkp_inchungchiphi) sql += " and (f.mavaovien=" + mavaovien + " or to_char(f.ngay,'dd/mm/yyyy')='" + ((bLocbaohiem) ? s_ngay : tmp_ngay) + "')";
                    else if (mavaovien != 0 && bTiepdon_nkp_inchungchiphi == false) sql += " and f.mavaovien=" + mavaovien;
                    if (bChenhlech_thuoc_dannhmuc) sql += " and b.chenhlech=1";
                    sql += " and f.loai=2 ";
                    sql += " and a.madoituong=" + maphu.SelectedValue.ToString();
                    d.merge(ds1, d.get_data_mmyy(sql, s_tu, s_den, songayduyet));
                    sql = "select 3 as id,0 as stt,0 as sttt,a.mavp as mabd,b.ma,b.ten,' ' as tenhc,b.dvt as dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,' ' as handung,' ' as losx,a.soluong,a.dongia,a.soluong*a.dongia as sotien,' ' as cachdung,0 as makho,0 as manguon,0 as nhomcc,";
                    sql += "'" + mabs.Text + "' as mabs,'" + chandoan.Text.Replace("\\", "'\'") + "' as chandoan,h.tenkp,a.maql,a.makp,a.madoituong ";
                    sql += ", null as hangsx, null as nuocsx, b.bhyt_tt,a.traituyen ";
                    sql += " from " + yyy + ".v_vpkhoa a," + user + ".v_giavp b," + user + ".btdkp_bv h where a.mavp=b.id ";//and a.id="+l_id+" order by a.stt";
                    sql += " and a.makp=h.makp and a.mabn='" + sophieu.Text + "'";
                    if (i_khudt != 0) sql += " and (h.khu=0 or h.khu=" + i_khudt + ")";//binh 210411
                    if (mavaovien != 0 && bTiepdon_nkp_inchungchiphi) sql += " and (a.mavaovien=" + mavaovien + " or to_char(a.ngay,'dd/mm/yyyy')='" + (bLocbaohiem ? s_ngay : tmp_ngay) + "')";
                    else if (mavaovien != 0 && bTiepdon_nkp_inchungchiphi == false) sql += " and a.mavaovien=" + mavaovien;
                    d.merge(ds1, d.get_data(sql));
                }
                else
                {
                    sql = "select 2 as id,a.stt,a.sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,e.ten as tenkho,c.ten as tennguon,d.ten as tennhomcc,t.handung,t.losx,a.soluong,";
                    if (bGiaban) sql += "t.giaban as dongia,t.giaban*a.soluong as sotien,";
                    else sql += "t.giamua as dongia,t.giamua*a.soluong as sotien,";
                    sql += "'' as cachdung,a.makho,t.manguon,t.nhomcc,'" + mabs.Text + "' as mabs,'" + chandoan.Text.Replace("\\", "'\'") + "' as chandoan,h.tenkp,f.maql,f.makp,a.madoituong ";
                    sql += ",i.ten as hangsx, j.ten as nuocsx, b.bhyt as bhyt_tt,f.traituyen ";
                    sql += " from xxx.d_xuatsdct a," + user + ".d_dmbd b," + user + ".d_dmnguon c," + user + ".d_dmnx d,";
                    sql += user + ".d_dmkho e,xxx.d_xuatsdll f,xxx.d_theodoi t," + user + ".d_duockp g," + user + ".btdkp_bv h";
                    sql += ", " + user + ".d_dmhang i, " + user + ".d_dmnuoc j ";
                    sql += " where f.id=a.id and a.mabd=b.id and a.sttt=t.id and t.manguon=c.id and t.nhomcc=d.id and a.makho=e.id ";
                    sql += " and b.mahang=i.id(+) and b.manuoc=j.id(+)";
                    sql += "  and f.makp=g.id and g.makp=h.makp ";
                    sql += " and f.mabn='" + sophieu.Text + "'";
                    if (i_khudt != 0) sql += " and (g.khu=0 or g.khu=" + i_khudt + ")";//binh 210411
                    if (mavaovien != 0 && bTiepdon_nkp_inchungchiphi) sql += " and (f.mavaovien=" + mavaovien + " or to_char(f.ngay,'dd/mm/yyyy')='" + (bLocbaohiem ? s_ngay : tmp_ngay) + "')";
                    else if (mavaovien != 0 && bTiepdon_nkp_inchungchiphi == false) sql += " and f.mavaovien=" + mavaovien;
                    sql += " and f.loai=2 ";
                    d.merge(ds1, d.get_data_mmyy(sql, s_tu, s_den, songayduyet));
                    sql = "select 3 as id,0 as stt,0 as sttt,a.mavp as mabd,b.ma,b.ten,' ' as tenhc,b.dvt as dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,' ' as handung,' ' as losx,a.soluong,a.dongia,a.soluong*a.dongia as sotien,' ' as cachdung,0 as makho,0 as manguon,0 as nhomcc,";
                    sql += "'" + mabs.Text + "' as mabs,'" + chandoan.Text.Replace("\\", "'\'") + "' as chandoan,h.tenkp,a.maql,a.makp,a.madoituong ";
                    sql += ", null as hangsx, null as nuocsx, b.bhyt_tt,a.traituyen";
                    sql += " from " + yyy + ".v_vpkhoa a," + user + ".v_giavp b," + user + ".btdkp_bv h where a.mavp=b.id ";//and a.id="+l_id+" order by a.stt";
                    sql += " and a.makp=h.makp and a.mabn='" + sophieu.Text + "'";
                    if (i_khudt != 0) sql += " and (h.khu=0 or h.khu=" + i_khudt + ")";//binh 210411
                    if (mavaovien != 0 && bTiepdon_nkp_inchungchiphi) sql += " and (a.mavaovien=" + mavaovien + " or to_char(a.ngay,'dd/mm/yyyy')='" + (bLocbaohiem ? s_ngay : tmp_ngay) + "')";
                    else if (mavaovien != 0 && bTiepdon_nkp_inchungchiphi == false) sql += " and a.mavaovien=" + mavaovien;
                    d.merge(ds1, d.get_data(sql));
                }
            }
            if (bInchiphi_chandoan_bacsy && maso == "")
            {
                foreach (DataRow r in ds1.Tables[0].Rows)
                    if (maso.IndexOf(r["maql"].ToString() + ",") == -1) maso += r["maql"].ToString() + ",";
                if (maso != "")
                {
                    sql = "select a.maql,a.chandoan,a.maicd,a.makp,b.tenkp,a.mabs,c.hoten as tenbs,to_char(a.ngay,'dd/mm/yyyy') as ngay ";
                    sql += " from xxx.benhanpk a inner join " + user + ".btdkp_bv b on a.makp=b.makp left join " + user + ".dmbs c on a.mabs=c.ma where a.maql in (" + maso.Substring(0, maso.Length - 1) + ") order by a.maql";
                    foreach (DataRow r in d.get_data_mmyy(sql, s_tu, s_den, songayduyet).Tables[0].Rows)
                    {
                        r3 = m.getrowbyid(dst.Tables[0], "maql=" + decimal.Parse(r["maql"].ToString()));
                        if (r3 == null)
                        {
                            r2 = dst.Tables[0].NewRow();
                            r2["maql"] = decimal.Parse(r["maql"].ToString());
                            r2["makp"] = r["makp"].ToString();
                            r2["maicd"] = r["maicd"].ToString();
                            r2["chandoan"] = r["chandoan"].ToString();
                            r2["mabs"] = r["mabs"].ToString();
                            r2["tenbs"] = r["tenbs"].ToString();
                            r2["tenkp"] = r["tenkp"].ToString();
                            if (File.Exists("..\\..\\..\\chuky\\" + r["mabs"].ToString() + ".bmp"))
                            {
                                fstr = new FileStream("..\\..\\..\\chuky\\" + r["mabs"].ToString() + ".bmp", FileMode.Open, FileAccess.Read);
                                image = new byte[fstr.Length];
                                fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                                fstr.Close();
                                r2["Image"] = image;
                            }
                            dst.Tables[0].Rows.Add(r2);
                        }
                    }
                }
            }
            //gam 16/08/2011 chi phi van chuyen tinh theo the khai 100%
            string s_sothe_huong_cpvc = "";
            DataRow r23;
            decimal d_cpvc = 0;
            string s_vitri_xet_chiphivanchuyen = d.thetunguyen_vitri(1);
            int iKytubegin_xet_chiphivanchuyen = 0, ikytuend_xet_chiphivanchuyen = 0;
            try
            {
                iKytubegin_xet_chiphivanchuyen = int.Parse(s_vitri_xet_chiphivanchuyen.Substring(0, 1));
                ikytuend_xet_chiphivanchuyen = int.Parse(s_vitri_xet_chiphivanchuyen.Substring(2, 1));

            }
            catch
            {
                iKytubegin_xet_chiphivanchuyen = 0;
                ikytuend_xet_chiphivanchuyen = 2;
            }
            //end gam
            decimal d_congkham = (congkham.Text!="") ? decimal.Parse(congkham.Text):0;
            if (iMavp_congkham != 0 && d_congkham != 0)
            {
                int sl = 1;
                if (bChuyenkham_congkham)
                {
                    sl = Math.Max(1, d.get_data_mmyy("select * from xxx.benhanpk where mabn='" + sophieu.Text + "' and mavaovien=" + mavaovien,s_tu,s_den,songayduyet).Tables[0].Rows.Count);
                }
                sql = "select 3 as id,0 as stt,0 as sttt,id as mabd,ma,ten,' ' as tenhc,dvt as dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,' ' as handung,' ' as losx,"+sl+" as soluong," + d_congkham + " as dongia," + sl*d_congkham + " as sotien,' ' as cachdung,0 as makho,0 as manguon,0 as nhomcc,";
                sql += "'" + mabs.Text + "' as mabs,'" + chandoan.Text.Replace("\\", "'\'") + "' as chandoan,'"+tenkp.Text+"' as tenkp,0 as maql,'"+makp.Text+"' as makp,"+int.Parse(maphu.SelectedValue.ToString())+" as madoituong";
                //sql += "'' as makp,'' as tenkp,'" + mabs + "' as mabs,'' as tenbs,' ' as chandoan,' ' as maicd,0 as maql ";
                sql += " from " + user + ".v_giavp where id=" + iMavp_congkham;
                d.merge(ds1, d.get_data(sql));
            }			
            DataSet dstmp = ds1.Clone();
            dstmp.Merge(ds1.Tables[0].Select("true", "id,stt"));
            dsxmlin.Clear();
            string ns = "", _sothe = sothe.Text, denngay = "", phai = "", diachi = "";
            if (l_maql != 0)
            {
                if (i_loaiba == 2)
                {
                    foreach (DataRow r in d.get_data("select sothe,case when tungay is null then to_char(denngay,'dd/mm/yyyy') else to_char(denngay,'dd/mm/yyyy')||' '||to_char(tungay,'dd/mm/yyyy') end as denngay,traituyen from " + user + ".bhyt where maql=" + l_maql).Tables[0].Rows)
                    {
                        if (_sothe == "")
                        {
                            _sothe = r["sothe"].ToString();
                            traituyen = int.Parse(r["traituyen"].ToString());
                        }
                        denngay = r["denngay"].ToString();
                    }
                }
                else
                {
                    foreach (DataRow r in d.get_data_mmyy("select sothe,case when tungay is null then to_char(denngay,'dd/mm/yyyy') else to_char(denngay,'dd/mm/yyyy')||' '||to_char(tungay,'dd/mm/yyyy') end as denngay,traituyen from xxx.bhyt where maql=" + l_maql, s_tu, s_den, songayduyet).Tables[0].Rows)
                    {
                        if (_sothe == "")
                        {
                            _sothe = r["sothe"].ToString();
                            traituyen = int.Parse(r["traituyen"].ToString());
                        }
                        denngay = r["denngay"].ToString();
                    }
                }
            }
            //gam 17/10/2011
            sql = "select a.*,to_char(a.ngaysinh,'dd/mm/yyyy') as ns,b.sothe,case when b.tungay is null then to_char(b.denngay,'dd/mm/yyyy') else to_char(b.denngay,'dd/mm/yyyy')||' '||to_char(b.tungay,'dd/mm/yyyy') end as denngay,c.tenpxa,d.tenquan,e.tentt, b.mabv, dmnc.tenbv,g.dienthoai,f.sovaovien as sokham  ";
            sql += ",dmnc.tenbv,g.dienthoai,f.sovaovien as sokham,n.tenbv as benhvien,n.mabv as mabenhvien,k.tenkp,k.makp,h.xutri,to_number('0') as nhantu ";
            sql += "from " + user + ".btdbn a left join xxx.bhyt b on a.mabn=b.mabn inner join " + user + ".btdpxa c on a.maphuongxa=c.maphuongxa inner join " + user + ".btdquan d on a.maqu=d.maqu inner join " + user + ".btdtt e on a.matt=e.matt";
            sql += " left join " + user + ".dmnoicapbhyt dmnc on b.mabv=dmnc.mabv ";
            sql += "left join xxx.tiepdon f on ";
            if (maphu.SelectedValue.ToString() == "1")
            {
                sql += "b.maql=f.maql ";
            }
            else
            {
                sql += "a.mabn=f.mabn ";
            }
            sql += " left join xxx.quanhe g on b.maql=g.maql left join xxx.xutrikbct h on f.maql=h.maql left join " + user + ".chuyenvien i on f.maql=i.maql left join " + user + ".btdkp_bv k  on h.makp=k.makp left join " + user + ".dstt n on i.mabv=n.mabv";
            sql += " where a.mabn='" + sophieu.Text + "' and f.mavaovien=" + l_mavaovien;
            sql += " union all ";
            sql += "select a.*,to_char(a.ngaysinh,'dd/mm/yyyy') as ns,b.sothe,case when b.tungay is null then to_char(b.denngay,'dd/mm/yyyy') else to_char(b.denngay,'dd/mm/yyyy')||' '||to_char(b.tungay,'dd/mm/yyyy') end as denngay,c.tenpxa,d.tenquan,e.tentt, b.mabv, dmnc.tenbv,g.dienthoai,f.sovaovien as sokham  ";
            sql += ",dmnc.tenbv,g.dienthoai,f.sovaovien as sokham,n.tenbv as benhvien,n.mabv as mabenhvien,k.tenkp,k.makp,h.xutri,f.nhantu ";
            sql += "from " + user + ".btdbn a left join xxx.bhyt b on a.mabn=b.mabn inner join " + user + ".btdpxa c on a.maphuongxa=c.maphuongxa inner join " + user + ".btdquan d on a.maqu=d.maqu inner join " + user + ".btdtt e on a.matt=e.matt";
            sql += " left join " + user + ".dmnoicapbhyt dmnc on b.mabv=dmnc.mabv ";
            sql += " left join xxx.benhanpk f on ";
            if (maphu.SelectedValue.ToString() == "1")
            {
                sql += "b.maql=f.maql ";
            }
            else
            {
                sql += "a.mabn=f.mabn ";
            }
            sql +=" left join xxx.quanhe g on b.maql=g.maql left join medibv.nhantu y on f.nhantu=y.ma";
            sql += " left join xxx.xutrikbct h on f.maql=h.maql left join " + user + ".chuyenvien i on f.maql=i.maql left join " + user + ".btdkp_bv k  on h.makp=k.makp left join " + user + ".dstt n on i.mabv=n.mabv";
            sql += " where a.mabn='" + sophieu.Text + "' and f.mavaovien=" + l_mavaovien;
            sql += " union all ";
            sql += "select a.*,to_char(a.ngaysinh,'dd/mm/yyyy') as ns,b.sothe,case when b.tungay is null then to_char(b.denngay,'dd/mm/yyyy') else to_char(b.denngay,'dd/mm/yyyy')||' '||to_char(b.tungay,'dd/mm/yyyy') end as denngay,c.tenpxa,d.tenquan,e.tentt, b.mabv, dmnc.tenbv,g.dienthoai,f.sovaovien as sokham  ";
            sql += ",dmnc.tenbv,g.dienthoai,f.sovaovien as sokham,n.tenbv,n.mabv,k.tenkp,k.makp,h.xutri,f.nhantu ";
            sql += "from " + user + ".btdbn a left join xxx.bhyt b on a.mabn=b.mabn inner join " + user + ".btdpxa c on a.maphuongxa=c.maphuongxa inner join " + user + ".btdquan d on a.maqu=d.maqu inner join " + user + ".btdtt e on a.matt=e.matt";
            sql += " left join " + user + ".dmnoicapbhyt dmnc on b.mabv=dmnc.mabv ";
            sql += "left join xxx.benhancc f on ";
            if (maphu.SelectedValue.ToString() == "1")
            {
                sql += "b.maql=f.maql ";
            }
            else
            {
                sql += "a.mabn=f.mabn ";
            }
            sql +=" left join xxx.quanhe g on b.maql=g.maql ";
            sql += "left join xxx.xutrikbct h on f.maql=h.maql left join " + user + ".chuyenvien i on f.maql=i.maql left join " + user + ".btdkp_bv k  on h.makp=k.makp left join " + user + ".dstt n on i.mabv=n.mabv";
            sql += " left join medibv.nhantu y on f.nhantu=y.ma where a.mabn='" + sophieu.Text + "' and f.mavaovien=" + l_mavaovien;
            sql += "union all ";
            sql += "select a.*,to_char(a.ngaysinh,'dd/mm/yyyy') as ns,b.sothe,case when b.tungay is null then ";
            sql += "to_char(b.denngay,'dd/mm/yyyy') else to_char(b.denngay,'dd/mm/yyyy')||' '||to_char(b.tungay,'dd/mm/yyyy') end ";
            sql += "as denngay,c.tenpxa,d.tenquan,e.tentt, b.mabv, dmnc.tenbv,g.dienthoai,f.sovaovien as sokham  ,";
            sql += "dmnc.tenbv,g.dienthoai,f.sovaovien as sokham,n.tenbv,n.mabv,k.tenkp,k.makp,h.xutri,to_number('0') as nhantu ";
            sql += "from " + user + ".btdbn a left join " + user + ".bhyt b on a.mabn=b.mabn inner join " + user + ".btdpxa c ";
            sql += "on a.maphuongxa=c.maphuongxa inner join " + user + ".btdquan d on a.maqu=d.maqu inner join " + user + ".btdtt e ";
            sql += "on a.matt=e.matt left join " + user + ".dmnoicapbhyt dmnc on b.mabv=dmnc.mabv  ";
            sql += "left join " + user + ".benhanngtr f on ";
            if (maphu.SelectedValue.ToString() == "1")
            {
                sql += "b.maql=f.maql ";
            }
            else
            {
                sql += "a.mabn=f.mabn ";
            }
            sql += " left join xxx.quanhe g on b.maql=g.maql ";
            sql += "left join xxx.xutrikbct h on f.maql=h.maql left join " + user + ".chuyenvien i on f.maql=i.maql "; 
            sql += "left join " + user + ".btdkp_bv k  on h.makp=k.makp left join " + user + ".dstt n on i.mabv=n.mabv ";
            sql += "where f.mavaovien=" + l_mavaovien;
            //end gam 17/10/2011
            //gam 22-03-2011 thêm field số điện thoại và số khám
            string ssokham = "", ssodienthoai = "",ssotoa="",snhantu="";
            string schuyenvien = "", snhapvien = "";//gam 17/10/2011 thêm field lay ten benh vien khi xu tri chuyen vien va ten khoa phong neu xu tri nhap vien
            foreach (DataRow r in d.get_data_mmyy(sql,s_tu,s_den,songayduyet).Tables[0].Rows)
            {
                ns = (r["ns"].ToString()!="")?r["ns"].ToString():r["namsinh"].ToString();
                phai = (r["phai"].ToString() == "0") ? "Nam" : "Nữ";
                diachi = r["sonha"].ToString().Trim() + " " + r["thon"].ToString().Trim() + "," + r["tenpxa"].ToString().Trim() + "," + r["tenquan"].ToString().Trim() + "," + r["tentt"].ToString();
                ssokham = r["sokham"].ToString();
                ssodienthoai = r["dienthoai"].ToString();
                if (_sothe == "" && r["sothe"].ToString().Trim() != "")
                {
                    _sothe = r["sothe"].ToString();
                    traituyen = int.Parse(r["traituyen"].ToString());
                }
                if (denngay == "" && r["denngay"].ToString().Trim() != "") denngay = r["denngay"].ToString();
                schuyenvien += r["mabenhvien"].ToString() + "^" + r["benhvien"].ToString();
                snhapvien += r["makp"].ToString() + "^" + r["tenkp"].ToString();
                snhantu = r["nhantu"].ToString();
                //break;
            }
            decimal tc = 0,tck=0,tcbn_ctthem=0,d_sotiendichvu=0, dg2=0;
            bool cstt = dstmp.Tables[0].Select("id=2").Length > 0;
            string s1 = m.get_tamung(sophieu.Text, mavaovien, s_ngay, 1, songayduyet+1);
            decimal tamung = decimal.Parse(s1.Substring(0, s1.IndexOf("^")));
            string stamung = s1.Substring(s1.IndexOf("^") + 1), s_doituong = "", s_tendichvu = "";
            bool bThuphi_dichvubhytduoi_100=m.bThuphi_dichvubhytduoi_100;
            int tmp_madt=2;
            string s_doituongtp=m.f_get_tendoituong(tmp_madt.ToString());
            //
            string a_maql = "", a_madoituong = "", a_sl = "", a_st = "", a_kythuat = "", a_dongia = "", a_dongia2 = "", a_nguoinha = "", a_sttloai = "", a_sttnhom = "", a_maphu = "", a_tennhombhyt = "";
            int a_sttbhyt = 0, a_idnhombhyt = 0;
            int a_ppdieutri = 0;
            decimal d_dichvu_tt = 0, d_dichvu_tt_BH_tra = 0, d_dichvu_tt_BN_tra=0;
            //
            //Thuy 09.04.2012 them field chiphivanchuyen bhyt tra 100% (cpvc_100)
            bool cpvc_100 = false;
            try
            {
                dsxmlin.Tables[0].Columns.Add("cpvc_100");
            }
            catch { }
            
            foreach (DataRow r in dstmp.Tables[0].Select("","madoituong"))
            {
                r2 = d.getrowbyid(dtdtf, "madoituong=" + int.Parse(r["madoituong"].ToString()));
                s_doituong = (r2 != null) ? r2["doituong"].ToString() : maphu.Text;
                
                if (r["sttt"].ToString() == "0")
                    r2 = m.getrowbyid(dtvpin, "id=" + int.Parse(r["mabd"].ToString()));
                else
                    r2 = m.getrowbyid(dtbd, "id=" + int.Parse(r["mabd"].ToString()));
                if (r2 != null)
                {
                    s_sothe_huong_cpvc = r2["sothe"].ToString();//gam 16/08/2011
                    s_tendichvu = r["ten"].ToString();
                    if (r["tenhc"].ToString().Trim() != "") s_tendichvu += " [" + r["tenhc"].ToString().Trim() + "]";
                    d_sotiendichvu = decimal.Parse(r["sotien"].ToString());
                    a_dongia = r["dongia"].ToString();
                    dg2 = 0; a_dongia2 = r["dongia"].ToString();
                    if(_sothe != "" && s_sothe_huong_cpvc != "" && s_sothe_huong_cpvc.IndexOf(_sothe.Substring(iKytubegin_xet_chiphivanchuyen,ikytuend_xet_chiphivanchuyen)) >= 0)
                    {
                        d_cpvc += decimal.Parse(r["sotien"].ToString());
                        cpvc_100 = true;
                    }
                    else if (decimal.Parse(r2["bhyt"].ToString()) != 100 && int.Parse(r["madoituong"].ToString()) == 1)
                    {
                        tc += (int.Parse(r["madoituong"].ToString()) == 1) ? (decimal.Parse(r["sotien"].ToString()) * decimal.Parse(r2["bhyt"].ToString()) / 100) : 0;
                        tcbn_ctthem += decimal.Parse(r["sotien"].ToString()) * (100 - decimal.Parse(r2["bhyt"].ToString())) / 100;
                        d_sotiendichvu = decimal.Parse(r["sotien"].ToString()) * decimal.Parse(r2["bhyt"].ToString()) / 100;
                        a_dongia = (decimal.Parse(r["dongia"].ToString()) * decimal.Parse(r2["bhyt"].ToString()) / 100).ToString();
                        s_tendichvu += " BHYT chỉ chi trả " + r2["bhyt"].ToString() + "%";
                        dg2 = decimal.Parse(r["sotien"].ToString()) * (100- decimal.Parse(r2["bhyt"].ToString())) / 100;
                        a_dongia2 = (decimal.Parse(r["dongia"].ToString()) * (100-decimal.Parse(r2["bhyt"].ToString())) / 100).ToString();
                        cpvc_100 = false;
                    }
                    else
                    {
                        tc += (int.Parse(r["madoituong"].ToString()) == 1) ? decimal.Parse(r["sotien"].ToString()) : 0;
                        cpvc_100 = false;
                    }
                    tck += (int.Parse(r["madoituong"].ToString()) != 1) ? decimal.Parse(r["sotien"].ToString()) : 0;
                    //
                    if (traituyen != 0 && iTraituyen != 0 && r["madoituong"].ToString()=="1")
                    {
                        if (bBHYT_Traituyen_tinh_Tyle_khac)
                        {
                            if (100 > decimal.Parse(r2["bhyt_tt"].ToString()) && decimal.Parse(r2["bhyt_tt"].ToString())>0) //if (decimal.Parse(r2["bhyt"].ToString()) > decimal.Parse(r2["bhyt_tt"].ToString()))
                            {
                                d_dichvu_tt += decimal.Parse(r["sotien"].ToString());
                                d_dichvu_tt_BH_tra += decimal.Parse(r["dongia"].ToString()) * decimal.Parse(r2["bhyt_tt"].ToString())/100;
                                d_dichvu_tt_BN_tra += decimal.Parse(r["dongia"].ToString()) * (100-decimal.Parse(r2["bhyt_tt"].ToString())) / 100;
                                decimal dggoc = decimal.Parse(r["dongia"].ToString()) * 100 / decimal.Parse(r2["bhyt_tt"].ToString());
                                s_tendichvu += " [BN Trái tuyến, BHYT chi trả " + decimal.Parse(r2["bhyt_tt"].ToString()).ToString("###") + "%]";
                            }
                        }
                    }
                    //
                    //  
                    a_maql = r["maql"].ToString();
                    a_madoituong = r["madoituong"].ToString();
                    //a_dongia = r["dongia"].ToString();
                    a_sl = r["soluong"].ToString();
                    a_kythuat = (r2["kythuat"].ToString() == "")? "-1" : r2["kythuat"].ToString();
                    a_st = d_sotiendichvu.ToString();// r["sotien"].ToString();
                    a_sttloai = (r2["sttloai"].ToString() == "") ? "0" : r2["sttloai"].ToString();
                    a_sttnhom = (r2["sttnhom"].ToString() == "") ? "0" : r2["sttnhom"].ToString();
                    a_maphu = maphu.SelectedValue.ToString();
                    a_nguoinha = m.get_nguoinha(s_mmyy, sophieu.Text, l_maql);
                    a_ppdieutri = (makp.Text != "") ? m.phuongphapdieutri(makp.Text) : 0;
                    s_cachdung = r["cachdung"].ToString();
                    //binh 070711
                    a_sttbhyt = (r2["sttbhyt"].ToString() == "") ? 0 : int.Parse(r2["sttbhyt"].ToString());
                    a_idnhombhyt = (r2["idnhombhyt"].ToString() == "") ? 0 : int.Parse(r2["idnhombhyt"].ToString());
                    a_tennhombhyt = r2["tennhombhyt"].ToString();
                    //gam 07/11/2011 ngaysp.Text, ngaysp.Text, s_chandoan, s_maicd, int.Parse(a_sttnhom),
                    m.updrec_ravien(dsxmlin, sophieu.Text, sophieu.Text, decimal.Parse(a_maql), 0, hoten.Text, ns, phai, diachi.Trim() + "^" + cholam.Trim()+"^"+snhantu.Trim(), int.Parse(a_madoituong),
                        s_doituong, _sothe, 0, denngay, tenbv.Text + "^" + mabv.Text + "^" + s_tentuyentruoc, r["mabs"].ToString(), s_tenbs, r["makp"].ToString(), r["tenkp"].ToString(),
                        ( s_ngayvv == "" ?  ngaysp.Text : s_ngayvv),(s_ngayrv == "" ? ngaysp.Text : s_ngayrv), s_chandoan, s_maicd, int.Parse(a_sttnhom),
                        r2["nhom"].ToString(), int.Parse(a_sttloai), r2["loai"].ToString(),
                        int.Parse(r["mabd"].ToString()), s_tendichvu, r["dang"].ToString(),
                        decimal.Parse(a_sl), decimal.Parse(a_st),
                        0, tamung, (congkham.Text != "") ? decimal.Parse(congkham.Text) : 0, a_nguoinha,
                        1, a_ppdieutri, 0, (cstt) ? "x^" + s_soluutru + "^" + s_cachdung : "^" + s_soluutru + "^" + s_cachdung, decimal.Parse(a_dongia),
                        bInchiphi_chandoan_bacsy, 0, "", "", "", r["hangsx"].ToString() + "^" + r["nuocsx"].ToString() + "^" + cholam, 
                        int.Parse(a_maphu), (decimal.Parse(a_sl) != 0) ? decimal.Parse(a_st) / decimal.Parse(a_sl) : 0, 0, d_sotiendichvu,
                        int.Parse(r["traituyen"].ToString() == "" ? traituyen.ToString() : r["traituyen"].ToString()), int.Parse(a_kythuat), a_sttbhyt, a_idnhombhyt, a_tennhombhyt);//gam 17/01/2012 thay traituyen => int.Parse(r["traituyen"].ToString() == "" ? traituyen : r["traituyen"].ToString())
                    if (dg2 != 0)
                    {
                        if (decimal.Parse(r2["bhyt"].ToString()) != 100)
                        {
                            s_tendichvu += " BN chi trả " + (100 - decimal.Parse(r2["bhyt"].ToString())).ToString() + "%";
                            if (m.bThuphi_dichvubhytduoi_100) { tmp_madt = 2; s_doituong = s_doituongtp; }
                            else { tmp_madt = m.iTunguyen; s_doituong = m.f_get_tendoituong(tmp_madt.ToString()); }
                        }
                        else
                        {
                            tmp_madt = int.Parse(r["madoituong"].ToString());
                        }
                        m.updrec_ravien(dsxmlin, sophieu.Text, sophieu.Text, decimal.Parse(r["maql"].ToString()), 0, hoten.Text, ns, phai, diachi.Trim() + "^" + cholam.Trim()+"^"+snhantu.Trim(), tmp_madt,
                        s_doituong, _sothe, 0, denngay, tenbv.Text + "^" + mabv.Text+"^"+s_tentuyentruoc, r["mabs"].ToString(), s_tenbs, r["makp"].ToString(), r["tenkp"].ToString(),
                        (s_ngayvv == "" ? ngaysp.Text : s_ngayvv), (s_ngayrv == "" ? ngaysp.Text : s_ngayrv), s_chandoan, s_maicd, int.Parse(a_sttnhom),
                        r2["nhom"].ToString(), int.Parse(a_sttloai ), r2["loai"].ToString(),
                        int.Parse(r["mabd"].ToString()), s_tendichvu, r["dang"].ToString(),
                        decimal.Parse(r["soluong"].ToString()), d_sotiendichvu,
                        0, tamung, (congkham.Text != "") ? decimal.Parse(congkham.Text) : 0, m.get_nguoinha(s_mmyy, sophieu.Text, l_maql),
                        1, a_ppdieutri, 0, (cstt) ? "x^" + s_soluutru + "^" + s_cachdung : "^" + s_soluutru + "^" + s_cachdung, decimal.Parse(a_dongia2), bInchiphi_chandoan_bacsy, 0, "", "", "", r["hangsx"].ToString() + "^" + r["nuocsx"].ToString() + "^" + cholam, int.Parse(maphu.SelectedValue.ToString()), (decimal.Parse(a_sl) != 0) ? decimal.Parse(a_st) / decimal.Parse(a_sl) : 0, 0, dg2, traituyen, int.Parse(a_kythuat), a_sttbhyt, a_idnhombhyt, a_tennhombhyt);
                    }
                    //chenh lech tien thuoc

                    //Thuy 09.04.2012
                    foreach (DataRow r_r in dsxmlin.Tables[0].Select("ma=" + r["mabd"].ToString()))
                    {
                        r_r["cpvc_100"] = cpvc_100;
                    }
                }
            }
            //
            if (m.bInmau38_daydu)
            {
                DataSet ads1 = d.get_data("select a.stt, a.ma, a.ten, a.idnhombhyt, b.stt as sttbhyt, b.ten tennhombhyt from " + user + ".v_nhomvp a left join "+user+".v_nhombhyt b on a.idnhombhyt=b.id ");

                //dst.WriteXml("c:\\xx.xml", XmlWriteMode.WriteSchema);
                foreach (DataRow rdt in dtdt.Select("madoituong=1"))
                {
                    DataRow[] a_dr = dsxmlin.Tables[0].Select("madoituong=" + rdt["madoituong"].ToString());
                    if (a_dr.Length > 0)
                    {
                        foreach (DataRow adr in ads1.Tables[0].Rows)
                        {
                            a_sttbhyt = (adr["sttbhyt"].ToString() == "") ? 0 : int.Parse(adr["sttbhyt"].ToString());
                            a_idnhombhyt = (adr["idnhombhyt"].ToString() == "") ? 0 : int.Parse(adr["idnhombhyt"].ToString());
                            a_tennhombhyt = adr["tennhombhyt"].ToString();

                            string s_exp = " madoituong=" + rdt["madoituong"].ToString() + " and sttnhom=" + adr["stt"].ToString();
                            DataRow adr1 = d.getrowbyid(dsxmlin.Tables[0], s_exp);
                            if (adr1 == null)
                            {
                                m.updrec_ravien(dsxmlin, sophieu.Text, sophieu.Text, decimal.Parse(a_maql), 0, hoten.Text, ns, phai, diachi.Trim() + "^" + cholam.Trim()+"^"+snhantu.Trim(), int.Parse(rdt["madoituong"].ToString()),
                                    rdt["doituong"].ToString(), _sothe, 0, denngay, tenbv.Text + "^" + mabv.Text + "^" + s_tentuyentruoc, a_dr[0]["mabs"].ToString(), s_tenbs, a_dr[0]["makp"].ToString(), a_dr[0]["tenkp"].ToString(),
                                    ngaysp.Text, ngaysp.Text, s_chandoan, s_maicd, int.Parse(adr["stt"].ToString()),
                                    adr["ten"].ToString(), 0, "", 0, "", "", 0, 0,
                                    0, tamung, (congkham.Text != "") ? decimal.Parse(congkham.Text) : 0, a_nguoinha,
                                    1, a_ppdieutri, 0, (cstt) ? "x^" + s_soluutru + "^" : "^" + s_soluutru + "^", 0, bInchiphi_chandoan_bacsy, 0, "", "", "", "^" + "^" + cholam, int.Parse(a_maphu), 0, 0, 0, traituyen, -1, a_sttbhyt, a_idnhombhyt, a_tennhombhyt);
                            }
                        }
                    }
                }
            }
                
            //
            int _maphu = d.get_maphu_ngtru(sothe.Text, tc, i_nhom);
            string chu = doiso.doithapphan(tc.ToString()), chuk = doiso.doithapphan(tck.ToString());
            bool bFound = false, bUserid = false;
            if (File.Exists("..\\..\\..\\chukyuser\\" + i_userid.ToString() + ".bmp"))
            {
                fstr = new FileStream("..\\..\\..\\chukyuser\\" + i_userid.ToString() + ".bmp", FileMode.Open, FileAccess.Read);
                imageuser = new byte[fstr.Length];
                fstr.Read(imageuser, 0, System.Convert.ToInt32(fstr.Length));
                fstr.Close();
                bUserid = true;
            }
            DataRow dr_tt;
            //them cot tylechitra
            try
            {
                dsxmlin.Tables[0].Columns.Add("tylechitra");
                dsxmlin.Tables[0].Columns.Add("dienthoai");
                dsxmlin.Tables[0].Columns.Add("sokham");
                dsxmlin.Tables[0].Columns.Add("sovaovien");
                dsxmlin.Tables[0].Columns.Add("tyletra", typeof(decimal)).DefaultValue = 0;
            }
            catch{}
            try
            {
                dsxmlin.Tables[0].Columns.Add("chuyenvien");
                dsxmlin.Tables[0].Columns.Add("nhapvien");
            }
            catch { }
            int atylechitra = d.get_maphu(_sothe);
            foreach (DataRow r in dsxmlin.Tables[0].Select("","madoituong"))
            {
                chitra = 100;
                r["idkhoa"] = isophieu;
                r["tcsotien"] = ((int.Parse(r["madoituong"].ToString())==1)?tc:tck) + d_cpvc;//gam 16/08/2011
                r["dichso"] = (int.Parse(r["madoituong"].ToString())==1)?chu:chuk;
                r["sothe"] = _sothe;
                r["tenuser"] = s_userid;
                r["chandoan"] = s_chandoan;
                r["tylechitra"] = atylechitra == 0 || r["cpvc_100"].ToString() == "True" ? "BHYT 100%" : atylechitra == 1 ? "BHYT 80%" : atylechitra == 2 ? "BHYT 95%" : "";
                r["dienthoai"] = ssodienthoai;
                r["sokham"] = ssokham;
                r["tyletra"] = 0;
                r["chuyenvien"] = schuyenvien;
                r["nhapvien"] = snhapvien;
                if (sothe.Text != "" && int.Parse(r["madoituong"].ToString())==1)
                {
                    //gam 16/08/2011 chi phi van chuyen tinh theo the huong 100%
                    //r2 = m.getrowbyid(dtvpin, "id=" + int.Parse(r["ma"].ToString()));
                    //if (r2 != null && _sothe != "" && s_sothe_huong_cpvc != "" && s_sothe_huong_cpvc.IndexOf(_sothe.Substring(iKytubegin_xet_chiphivanchuyen,ikytuend_xet_chiphivanchuyen)) >= 0)
                    //{
                    //    r["bhyttra"] = decimal.Parse(r["sotien"].ToString());
                    //    r["bntra"] = 0;
                    //    r["tcsotien"] = ((int.Parse(r["madoituong"].ToString()) == 1) ? tc : tck) + d_cpvc;//gam 16/08/2011
                    //    r["tylechitra"] = "BHYT 100%";
                    //}
                    //end gam
                    if (int.Parse(r["traituyen"].ToString()) != 0 && iTraituyen != 0 && !bTraituyen_bhtra)
                    {
                        chitra = iTraituyen;
                        r["bhyttra"] = d_cpvc + ((tc - d_dichvu_tt) * chitra / 100 + d_dichvu_tt_BH_tra);//gam 16/08/2011
                        r["bntra"] = (tc - d_dichvu_tt) - ((tc - d_dichvu_tt) * chitra / 100) + tcbn_ctthem + d_dichvu_tt_BN_tra;

                        r2 = m.getrowbyid(dtvpin, "id=" + int.Parse(r["ma"].ToString()));
                        if (r2 != null && (100 > decimal.Parse(r2["bhyt_tt"].ToString()) && decimal.Parse(r2["bhyt_tt"].ToString()) > 0))
                        {
                            chitra = decimal.Parse(r2["bhyt_tt"].ToString());
                        }
                    }
                    else if (int.Parse(r["traituyen"].ToString()) != 0 && iTraituyen != 0 && bTraituyen_bhtra)
                    {
                        chitra = ((_maphu == 1) ? 80 : (_maphu == 2) ? 95 : 100);
                        chitra = chitra * (decimal.Parse(iTraituyen.ToString()) / 100);
                        r["bhyttra"] = ((tc - d_dichvu_tt) * chitra / 100 + d_dichvu_tt_BH_tra) + d_cpvc;//gam 16/08/2011
                        r["bntra"] = (tc - d_dichvu_tt) - ((tc - d_dichvu_tt) * chitra / 100) + tcbn_ctthem + d_dichvu_tt_BN_tra;

                        r2 = m.getrowbyid(dtvpin, "id=" + int.Parse(r["ma"].ToString()));
                        if (r2 != null && (100 > decimal.Parse(r2["bhyt_tt"].ToString()) && decimal.Parse(r2["bhyt_tt"].ToString()) > 0))
                        {
                            chitra = decimal.Parse(r2["bhyt_tt"].ToString());
                        }
                    }
                    else if (Bhyt_7cn != 0 && tc > Bhyt_7cn)
                    {
                        r["bhyttra"] = Bhyt_7cn +d_cpvc;//gam 16/08/2011
                        r["bntra"] = tc - Bhyt_7cn;
                    }
                    else
                    {
                        if (_maphu != 0)
                        {
                            chitra = (_maphu == 1) ? 80 : 95;
                            r["bhyttra"] = (tc * chitra / 100 ) + d_cpvc;//gam 16/08/2011
                            r["bntra"] = tc - (tc * chitra / 100) + tcbn_ctthem;
                        }
                        else
                        {
                            r["bhyttra"] = tc + d_cpvc;//gam 16/08/2011
                            r["bntra"] = 0;
                        }
                        if (lTraituyen != 0 && decimal.Parse(r["bhyttra"].ToString()) > lTraituyen && int.Parse(r["traituyen"].ToString()) != 0)
                        {
                            r["bhyttra"] = lTraituyen + d_cpvc;//gam 16/08/2011
                            r["bntra"] = tc - lTraituyen;
                        }
                    }
                    //Thuy 09.04.2012
                    if (r["cpvc_100"].ToString() == "True")
                    {
                        r["tyletra"] = 100;
                    }
                    else
                    {
                        r["tyletra"] = chitra;
                    }
                }
                if (bInchiphi_chandoan_bacsy)
                {
                    r3 = m.getrowbyid(dst.Tables[0], "maql=" + decimal.Parse(r["maql"].ToString()));
                    if (r3 != null)
                    {
                        r["maicd"] = r3["maicd"].ToString();
                        r["chandoan"] = r3["chandoan"].ToString();
                        r["mabs"] = r3["mabs"].ToString();
                        r["tenbs"] = r3["tenbs"].ToString();
                        r["tenkp"] = r3["tenkp"].ToString();
                        r["image"] = r3["image"];
                    }
                    else
                    {
                        r3 = m.getrowbyid(dst.Tables[0], "makp='" + r["makp"].ToString() + "'");
                        if (r3 != null)
                        {
                            r["maicd"] = r3["maicd"].ToString();
                            r["chandoan"] = r3["chandoan"].ToString();
                            r["mabs"] = r3["mabs"].ToString();
                            r["tenbs"] = r3["tenbs"].ToString();
                            r["tenkp"] = r3["tenkp"].ToString();
                            r["image"] = r3["image"];
                        }
                        else if (File.Exists("..\\..\\..\\chuky\\" + r["noicap"].ToString() + ".bmp"))
                        {
                            fstr = new FileStream("..\\..\\..\\chuky\\" + r["noicap"].ToString() + ".bmp", FileMode.Open, FileAccess.Read);
                            image = new byte[fstr.Length];
                            fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                            fstr.Close();
                            r["Image"] = image;
                            r["tenbs"] = tenbs.Text;
                        }
                        else r["tenbs"] = tenbs.Text;
                    }
                }
                {
                    try
                    {
                        if (File.Exists("..\\..\\..\\chuky\\" + r["noicap"].ToString() + ".bmp"))
                        {
                            fstr = new FileStream("..\\..\\..\\chuky\\" + r["noicap"].ToString() + ".bmp", FileMode.Open, FileAccess.Read);
                            image = new byte[fstr.Length];
                            fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                            fstr.Close();
                            r["Image"] = image;
                            bFound = true;
                        }
                        else if (bFound) r["Image"] = image;
                        if (bUserid) r["imageuser"] = imageuser;
                    }
                    catch { }
                }
                r["mavaovien"] = r["maql"].ToString();
                r["maql"] = lanin;
                r["sbltamung"] = stamung;
            }
            //Tu:21/08/2011 them cot sobienlai va kyhieu quyen so
            try
            {
                dsxmlin.Tables[0].Columns.Add("sobienlai", typeof(string));
                dsxmlin.Tables[0].Columns.Add("quyenso", typeof(string));
            }
            catch { }
            try
            {
                dsxmlin.Tables[0].Columns.Add("sotoa");
            }
            catch { }
            try
            {
                dsxmlin.Tables[0].Columns.Add("trieuchung");
            }
            catch { }
            string s_trieuchung = m.get_trieuchung(s_ngay, l_maql);

            foreach (DataRow row in dsxmlin.Tables[0].Select("mabn='" + cmbSophieu.Text + "'"))
            {
                row["sobienlai"] = sobienlai.Text;
                row["quyenso"] = quyenso.Text;
                row["sotoa"] = d_toaso.ToString();
                row["trieuchung"] = s_trieuchung;
            }
            //thêm số tháng
            if (int.Parse(s_tuoi) <= 6 && s_ngaysinh != "")
            {
                try { dsxmlin.Tables[0].Columns.Add("thangtuoi", typeof(String)); }
                catch { }
                long songay = m.songay(m.StringToDateTime(s_ngayvv), DateTime.Parse(s_ngaysinh), 0);
                long sothang = songay / 30;
                foreach (DataRow r in dsxmlin.Tables[0].Rows) r["thangtuoi"] = sothang.ToString();
            } 
            if (chkXML.Checked)
            {
                if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
                dsxmlin.WriteXml("..\\xml\\cpbhyt.xml", XmlWriteMode.WriteSchema);
            }
            //if (s_tenkp == "") s_tenkp = tenkp.Text;
            if (s_tenkp == "")
            {
                string asql0 = "select a.makp, b.tenkp, c.hoten as tenbs ";
                asql0 += " from xxx.bhytkb a inner join medibv.btdkp_bv b on a.makp=b.makp left join medibv.dmbs c on a.mabs=c.ma";
                asql0 += " where a.mabn='" + sophieu.Text + "' and a.mavaovien=" + l_mavaovien;

                DataSet ads0 = d.get_data_mmyy(asql0, s_ngay, s_ngay, true);
                if (ads0 != null && ads0.Tables.Count > 0 && ads0.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr0 in ads0.Tables[0].Rows)
                    {
                        if (s_tenkp.IndexOf(dr0["tenkp"].ToString().Trim() + ";") < 0) s_tenkp += dr0["tenkp"].ToString().Trim() + ";";
                        if (s_tenbs.IndexOf(dr0["tenbs"].ToString().Trim() + ";") < 0) s_tenbs += dr0["tenbs"].ToString() + "; ";
                    }
                }
                if (s_tenkp == "") s_tenkp = tenkp.Text;
            }

            if (chkXem.Checked)
            {
                if (System.IO.Directory.Exists("..\\Report\\rpt_ttravien_bh1.rpt"))
                {
                    frmReport f = new frmReport(d, dsxmlin.Tables[0], i_userid, s_tenkp, "rpt_ttravien_bh1.rpt");
                    f.ShowDialog();
                }
                else
                {
                    frmReport f = new frmReport(d, dsxmlin.Tables[0], i_userid, s_tenkp, "rpt_ttravien_bh.rpt");
                    f.ShowDialog();
                }
            }
            else
            {
                ReportDocument oRpt = new ReportDocument();
                oRpt.Load("..\\..\\..\\report\\rpt_ttravien_bh.rpt", OpenReportMethod.OpenReportByTempCopy);
                oRpt.SetDataSource(dsxmlin.Tables[0]);
                oRpt.DataDefinition.FormulaFields["SoYTe"].Text = "'" + d.Syte + "'";
                oRpt.DataDefinition.FormulaFields["BenhVien"].Text = "'" + d.Tenbv + "'";
                oRpt.DataDefinition.FormulaFields["TenBenhAn"].Text = "'" + s_tenkp + "'";
                oRpt.PrintToPrinter(1, false, 0, 0);
                oRpt.Close(); oRpt.Dispose();
            }
        }
       
		private void maphu_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//if (butMoi.Enabled) butTreem.Enabled=maphu.SelectedValue.ToString()==m.iTreem6tuoi.ToString();
            if (this.ActiveControl == maphu)
            {
                string so = m.sothe(int.Parse(maphu.SelectedValue.ToString()));
                sothe.Enabled = int.Parse(so.Substring(0, 2)) > 0;
            }
		}

		private void frmHoadonbhyt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F3) butDichvu_Click(sender,e);
			else if (e.KeyCode==Keys.F6) butDuyet_Click(sender,e);
            else if (e.KeyCode == Keys.F7) butIn_Click(sender, e);
			else if (e.KeyCode==Keys.F9) butTreem_Click(sender,e);
		}

        private void butList_Click(object sender, EventArgs e)
        {
            load_list();
        }

        private void chkKodichvu_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkKodichvu) d.writeXml("d_thongso", "Kodichvu", (chkKodichvu.Checked) ? "1" : "0");
        }

        private void f_load_option()
        {
            bThuchenhlechtruoc_duyettoasau = d.bThuchenhlechtruoc_duyettoasau(i_nhom);
            bLaygiamua_khi_giabh_0_giabh_nho_giamua = d.bLaygiamua_khi_giabh_0_giabh_nho_giamua;
            bBHYT_Traituyen_tinh_Tyle_khac = m.bBHYT_Traituyen_tinh_Tyle_khac;
            bTraituyen_bhtra = m.bTraituyen_bhtra;//True: BHYT trai tuyen chi tinh tren tong chi phi BHYT thanh toan sau khi tinh theo ty le the
            i_quyen_duyetmau38 = d.f_quyet_duyet_mau38(i_nhom, i_userid);
        }

        private void chkds_Click(object sender, EventArgs e)
        {
            //d.writeXml("d_thongso", "duyetbhyt_loadds", chkds.Checked ? "1" : "0");
        }

        private string f_Kiemtrabn_chuahoantatkham(string amabn, string s_tu, string s_den, string amavaovien)
        {
            string _xutri = "", _mabn = "";
            sql = "select b.xutri from xxx.benhanpk a left join xxx.xutrikbct b on a.maql=b.maql left join xxx.tiepdon c on a.maql=c.maql ";
            sql += " where a.mabn='" + amabn + "' and " + m.for_ngay("a.ngay", stime) + " between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";//to_char(a.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
            sql += " and a.madoituong=" + i_madoituong;
            if (amavaovien.Trim().Trim('0') != "") sql += " and a.mavaovien=" + amavaovien;
            sql += " order by a.maql desc";//and c.done='x' 
            _xutri = "";
            foreach (DataRow r1 in d.get_data_mmyy(sql, s_tu, s_den, songayduyet).Tables[0].Rows)
            {
                _xutri = r1["xutri"].ToString().Trim();

                if (bkhongChoDuyetToaBNHen_E8)
                {
                    if (_xutri.IndexOf("03,") != -1 || _xutri.Trim() == "") { _mabn += amabn + " " + hoten.Text + "\n"; break; }
                }               
            }
            

            return _mabn;
        }
	}
}
