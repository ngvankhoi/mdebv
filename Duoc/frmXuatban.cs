using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using LibMedi;
using LibVienphi;
using doiso;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Duoc
{
	public class frmXuatban : System.Windows.Forms.Form
    {
        #region
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private int i_soluong_le=0,i_dongia_le=0,i_thanhtien_le=0,i_quayban=0,i_solanin,i_kyhieu=0,songayduyet;
        private string s_tenquay = "";
        private bool bNhathuoc_dkbnmoi = false;
        private int i_maxlength_mabn = 8;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private MaskedBox.MaskedBox ngaysp;
		private LibList.List listDMBD;
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
		private string xxx,user,s_mmyy,s_ngay,sql,s_ngaysp,s_makho,s_kho,s_makp,s_userid,tmp_ngaygio,s_manguon,format_soluong,format_dongia,format_sotien,format_sotienban,s_tenkho,stime,s_tu,s_den,sComputer,s_mabn="";
		private int i_nhom,i_userid,i_mabd,i_old,i_songay,i_loai,i_makp,i_sotoa,i_row,itable,i_paid, tmp_userid;
		private decimal l_id,l_sttt;
        private string l_id1,s_mabn_tmp="";
		private decimal d_soluong,d_dongia,d_sotien,d_giaban,d_soluongton,d_soluongcu,d_sotiencu,d_tongcong,d_sotienban,d_sothang;
        private bool bKhoaso, bNew, bEdit = true, bGiaban, bAdmin, bChandoan, bMaso_ten, bBacsy, bKytu_traiphai, bBienlai_sohieu, bTinnhan_sound, bQuanly_xuatban_theomavach = false, bGiaban_theodot=false;
        private bool bHotennt, bNgtru_khoa, bNgtru_bacsi, bNamsinhnt, bNhapmaso, bNgtru_mabn, bInphieuxuatban, bBienlai, bIncachdung, bThuhoi, bXuatban_vienphi, bKho_dongy = false, bTrutonao = false, bHuyxuatban_userthuoc_duocphep = false, bXuatban_sua_trenluoi=false;
        private DataTable dtToaCT;
		private LibDuoc.AccessData d;
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
		private Doisototext doiso=new Doisototext();
		private DataTable dttonct=new DataTable();
		private DataTable dtton=new DataTable();
        private DataTable dtcachdung = new DataTable();
		private DataTable dtll=new DataTable();
		private DataTable dtct=new DataTable();
		private DataTable dtsave=new DataTable();
		private DataTable dtduockp=new DataTable();
		private DataTable dtbs=new DataTable();
		private DataSet dsxoa=new DataSet();
		private DataTable dtdmbd=new DataTable();
		private DataSet dsxml=new DataSet();
		private DataSet dslien=new DataSet();
        private DataTable dtkho = new DataTable();
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
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox manguon;
		private System.Windows.Forms.ComboBox nhomcc;
		private System.Windows.Forms.TextBox stt;
		private System.Windows.Forms.TextBox sttt;
		private System.Windows.Forms.Label lMabd;
		private System.Windows.Forms.TextBox tenkp;
		private LibList.List listDuockp;
		private System.Windows.Forms.ComboBox makho;
		private System.Windows.Forms.Label label5;
		private System.Drawing.Printing.PrintDocument docToPrint = new System.Drawing.Printing.PrintDocument();
		private PrintDialog p=new PrintDialog();
		private DialogResult result;
		private Print print=new Print();
		private System.Windows.Forms.ComboBox loai;
		private System.Windows.Forms.Label label4;
		private MaskedTextBox.MaskedTextBox hoten;
		private MaskedTextBox.MaskedTextBox namsinh;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox makp;
		private System.Windows.Forms.TextBox tenbs;
		private System.Windows.Forms.Label label11;
		private LibList.List listDMBS;
		private System.Windows.Forms.TextBox sum;
		private System.Windows.Forms.TextBox mabs;
		private MaskedTextBox.MaskedTextBox sotienban;
		private System.Windows.Forms.Button butMua;
		private System.Windows.Forms.Button butDonthuoc;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox timkiem;
		private System.Windows.Forms.Label toaso;
		private System.Windows.Forms.Label lbl;
		private System.Windows.Forms.Label ltoaso;
		private System.Windows.Forms.Label label1;
		private MaskedTextBox.MaskedTextBox maicd;
		private System.Windows.Forms.TextBox chandoan;
		private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.TextBox bsma;
		private System.Windows.Forms.Button butBienlai;
		private System.Windows.Forms.Panel pBienlai;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox sohieu;
		private System.Windows.Forms.NumericUpDown sobienlai;
		private System.Windows.Forms.TextBox label14;
		private System.Windows.Forms.CheckBox chkBienlai;
        private System.Windows.Forms.Button butTon;
        private Button butSohieu;
        private Label label21;
        private MaskedTextBox.MaskedTextBox diachi;
        private Timer Clock;
        private Label label22;
        private TextBox songay;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem butGoi;
        private ToolStripMenuItem chkXem;
        private TextBox cachdung;
        private Label label23;
        private LibList.List listcachdung;
        private Label lbldungluc;
        private TextBox mavach_sttt;
        private Label label26;
        private Button butbnmoi;
        #endregion
        private ToolTip toolTip1;
        private ToolStripMenuItem chkXml;
        private IContainer components;

        public frmXuatban(LibDuoc.AccessData acc,int loai,string mmyy,string ngay,int nhom,int userid,string kho,string makp,string title,bool b_giaban,string user,bool admin, int quayban,string _tenkho,string _tenquay,bool thuhoi,string _sohieu,int _kyhieu)
		{
			InitializeComponent();
			d=acc;
			i_nhom=nhom;s_tenkho=_tenkho;
			s_kho=kho;s_makp=makp;i_userid=userid;
            tmp_userid = userid;
			s_mmyy=mmyy;s_ngay=ngay;s_userid=user;
			i_loai=loai;bGiaban=b_giaban;
            bAdmin = admin; i_quayban = quayban; bThuhoi = thuhoi;
			this.Text=title+"-"+_tenkho.Trim()+"("+_tenquay.Trim()+")";            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            sohieu.Text = _sohieu;
            i_kyhieu = _kyhieu;
            if (_sohieu!="" && i_kyhieu!=0) sobienlai.Value = m.get_sobienlai(i_kyhieu, 1);
            s_tenquay = _tenquay;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXuatban));
            this.lbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ngaysp = new MaskedBox.MaskedBox();
            this.listDMBD = new LibList.List();
            this.lMabd = new System.Windows.Forms.Label();
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
            this.cmbSophieu = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.handung = new MaskedBox.MaskedBox();
            this.losx = new MaskedBox.MaskedBox();
            this.tenhc = new System.Windows.Forms.TextBox();
            this.lTenhc = new System.Windows.Forms.Label();
            this.sophieu = new MaskedTextBox.MaskedTextBox();
            this.giaban = new MaskedTextBox.MaskedTextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.nhomcc = new System.Windows.Forms.ComboBox();
            this.stt = new System.Windows.Forms.TextBox();
            this.sttt = new System.Windows.Forms.TextBox();
            this.tenkp = new System.Windows.Forms.TextBox();
            this.listDuockp = new LibList.List();
            this.makho = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.loai = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.hoten = new MaskedTextBox.MaskedTextBox();
            this.namsinh = new MaskedTextBox.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.TextBox();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.listDMBS = new LibList.List();
            this.sum = new System.Windows.Forms.TextBox();
            this.mabs = new System.Windows.Forms.TextBox();
            this.sotienban = new MaskedTextBox.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.timkiem = new System.Windows.Forms.TextBox();
            this.ltoaso = new System.Windows.Forms.Label();
            this.toaso = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.maicd = new MaskedTextBox.MaskedTextBox();
            this.chandoan = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.bsma = new System.Windows.Forms.TextBox();
            this.pBienlai = new System.Windows.Forms.Panel();
            this.sobienlai = new System.Windows.Forms.NumericUpDown();
            this.sohieu = new System.Windows.Forms.TextBox();
            this.butSohieu = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkBienlai = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.diachi = new MaskedTextBox.MaskedTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.songay = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.butGoi = new System.Windows.Forms.ToolStripMenuItem();
            this.chkXem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkXml = new System.Windows.Forms.ToolStripMenuItem();
            this.butTon = new System.Windows.Forms.Button();
            this.butBienlai = new System.Windows.Forms.Button();
            this.butDonthuoc = new System.Windows.Forms.Button();
            this.butMua = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butXoa = new System.Windows.Forms.Button();
            this.butThem = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.cachdung = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.listcachdung = new LibList.List();
            this.lbldungluc = new System.Windows.Forms.Label();
            this.mavach_sttt = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.butbnmoi = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.pBienlai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sobienlai)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.Location = new System.Drawing.Point(103, 28);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(46, 23);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "Mã BN :";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-8, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(272, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 23);
            this.label9.TabIndex = 8;
            this.label9.Text = "Họ tên :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(510, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 23);
            this.label10.TabIndex = 9;
            this.label10.Text = "Khoa :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngaysp
            // 
            this.ngaysp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaysp.Enabled = false;
            this.ngaysp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysp.Location = new System.Drawing.Point(40, 28);
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
            this.listDMBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listDMBD.Location = new System.Drawing.Point(327, 555);
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
            // lMabd
            // 
            this.lMabd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lMabd.Location = new System.Drawing.Point(24, 427);
            this.lMabd.Name = "lMabd";
            this.lMabd.Size = new System.Drawing.Size(32, 23);
            this.lMabd.TabIndex = 28;
            this.lMabd.Text = "Mã :";
            this.lMabd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lTen
            // 
            this.lTen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTen.Location = new System.Drawing.Point(128, 427);
            this.lTen.Name = "lTen";
            this.lTen.Size = new System.Drawing.Size(80, 23);
            this.lTen.TabIndex = 29;
            this.lTen.Text = "Tên :";
            this.lTen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ldvt
            // 
            this.ldvt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ldvt.Location = new System.Drawing.Point(8, 451);
            this.ldvt.Name = "ldvt";
            this.ldvt.Size = new System.Drawing.Size(48, 23);
            this.ldvt.TabIndex = 30;
            this.ldvt.Text = "ĐVT :";
            this.ldvt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.Location = new System.Drawing.Point(154, 451);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 23);
            this.label16.TabIndex = 31;
            this.label16.Text = "Số lượng :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.Location = new System.Drawing.Point(315, 501);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 23);
            this.label17.TabIndex = 32;
            this.label17.Text = "Giá mua :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label18.Location = new System.Drawing.Point(472, 451);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 23);
            this.label18.TabIndex = 33;
            this.label18.Text = "Số tiền :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.Location = new System.Drawing.Point(-8, 501);
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
            this.tenbd.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbd.Location = new System.Drawing.Point(210, 427);
            this.tenbd.Name = "tenbd";
            this.tenbd.Size = new System.Drawing.Size(254, 23);
            this.tenbd.TabIndex = 16;
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
            this.mabd.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabd.Location = new System.Drawing.Point(57, 427);
            this.mabd.Name = "mabd";
            this.mabd.Size = new System.Drawing.Size(88, 23);
            this.mabd.TabIndex = 15;
            this.mabd.TextChanged += new System.EventHandler(this.mabd_TextChanged);
            this.mabd.Validated += new System.EventHandler(this.mabd_Validated);
            this.mabd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabd_KeyDown);
            // 
            // dang
            // 
            this.dang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dang.Enabled = false;
            this.dang.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dang.Location = new System.Drawing.Point(57, 452);
            this.dang.Mask = "";
            this.dang.MaxLength = 10;
            this.dang.Name = "dang";
            this.dang.Size = new System.Drawing.Size(88, 23);
            this.dang.TabIndex = 18;
            // 
            // soluong
            // 
            this.soluong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(210, 452);
            this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(94, 23);
            this.soluong.TabIndex = 19;
            this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
            // 
            // dongia
            // 
            this.dongia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dongia.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dongia.Enabled = false;
            this.dongia.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dongia.Location = new System.Drawing.Point(370, 501);
            this.dongia.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.dongia.Name = "dongia";
            this.dongia.Size = new System.Drawing.Size(94, 23);
            this.dongia.TabIndex = 26;
            this.dongia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // sotien
            // 
            this.sotien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sotien.Enabled = false;
            this.sotien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sotien.Location = new System.Drawing.Point(136, 344);
            this.sotien.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sotien.Name = "sotien";
            this.sotien.Size = new System.Drawing.Size(104, 21);
            this.sotien.TabIndex = 14;
            this.sotien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbSophieu
            // 
            this.cmbSophieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSophieu.Location = new System.Drawing.Point(149, 28);
            this.cmbSophieu.Name = "cmbSophieu";
            this.cmbSophieu.Size = new System.Drawing.Size(91, 21);
            this.cmbSophieu.TabIndex = 1;
            this.cmbSophieu.SelectedIndexChanged += new System.EventHandler(this.cmbSophieu_SelectedIndexChanged);
            this.cmbSophieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSophieu_KeyDown);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.Location = new System.Drawing.Point(467, 501);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 23);
            this.label15.TabIndex = 61;
            this.label15.Text = "Hạn dùng :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label24.Location = new System.Drawing.Point(596, 501);
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
            this.handung.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.handung.Location = new System.Drawing.Point(530, 501);
            this.handung.Mask = "####";
            this.handung.Name = "handung";
            this.handung.Size = new System.Drawing.Size(62, 23);
            this.handung.TabIndex = 27;
            this.handung.Text = "    ";
            // 
            // losx
            // 
            this.losx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.losx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.losx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.losx.Enabled = false;
            this.losx.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.losx.Location = new System.Drawing.Point(674, 501);
            this.losx.Mask = "&&&&&&&&&&";
            this.losx.MaxLength = 10;
            this.losx.Name = "losx";
            this.losx.Size = new System.Drawing.Size(110, 23);
            this.losx.TabIndex = 28;
            this.losx.Text = "          ";
            // 
            // tenhc
            // 
            this.tenhc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenhc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenhc.Enabled = false;
            this.tenhc.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenhc.Location = new System.Drawing.Point(530, 427);
            this.tenhc.Name = "tenhc";
            this.tenhc.Size = new System.Drawing.Size(254, 23);
            this.tenhc.TabIndex = 17;
            // 
            // lTenhc
            // 
            this.lTenhc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTenhc.Location = new System.Drawing.Point(462, 426);
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
            this.sophieu.Location = new System.Drawing.Point(149, 28);
            this.sophieu.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sophieu.MaxLength = 10;
            this.sophieu.Name = "sophieu";
            this.sophieu.Size = new System.Drawing.Size(91, 21);
            this.sophieu.TabIndex = 2;
            this.sophieu.Validated += new System.EventHandler(this.sophieu_Validated);
            // 
            // giaban
            // 
            this.giaban.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.giaban.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giaban.Enabled = false;
            this.giaban.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giaban.Location = new System.Drawing.Point(370, 452);
            this.giaban.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.giaban.Name = "giaban";
            this.giaban.Size = new System.Drawing.Size(94, 23);
            this.giaban.TabIndex = 20;
            this.giaban.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label25.Location = new System.Drawing.Point(315, 451);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 23);
            this.label25.TabIndex = 66;
            this.label25.Text = "Giá bán :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(139, 502);
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
            this.manguon.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(57, 501);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(88, 24);
            this.manguon.TabIndex = 24;
            // 
            // nhomcc
            // 
            this.nhomcc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nhomcc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhomcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhomcc.Enabled = false;
            this.nhomcc.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhomcc.Location = new System.Drawing.Point(210, 501);
            this.nhomcc.Name = "nhomcc";
            this.nhomcc.Size = new System.Drawing.Size(94, 24);
            this.nhomcc.TabIndex = 25;
            // 
            // stt
            // 
            this.stt.Location = new System.Drawing.Point(32, 352);
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(24, 20);
            this.stt.TabIndex = 68;
            // 
            // sttt
            // 
            this.sttt.Location = new System.Drawing.Point(64, 352);
            this.sttt.Name = "sttt";
            this.sttt.Size = new System.Drawing.Size(24, 20);
            this.sttt.TabIndex = 69;
            // 
            // tenkp
            // 
            this.tenkp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkp.Enabled = false;
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(591, 51);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(193, 21);
            this.tenkp.TabIndex = 8;
            this.tenkp.TextChanged += new System.EventHandler(this.tenkp_TextChanged);
            this.tenkp.Validated += new System.EventHandler(this.tenkp_Validated);
            this.tenkp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenkp_KeyDown);
            // 
            // listDuockp
            // 
            this.listDuockp.BackColor = System.Drawing.SystemColors.Info;
            this.listDuockp.ColumnCount = 0;
            this.listDuockp.Location = new System.Drawing.Point(246, 555);
            this.listDuockp.MatchBufferTimeOut = 1000;
            this.listDuockp.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listDuockp.Name = "listDuockp";
            this.listDuockp.Size = new System.Drawing.Size(75, 17);
            this.listDuockp.TabIndex = 71;
            this.listDuockp.TextIndex = -1;
            this.listDuockp.TextMember = null;
            this.listDuockp.ValueIndex = -1;
            this.listDuockp.Visible = false;
            // 
            // makho
            // 
            this.makho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.makho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makho.Enabled = false;
            this.makho.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.Location = new System.Drawing.Point(674, 452);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(110, 24);
            this.makho.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Location = new System.Drawing.Point(642, 451);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 23);
            this.label5.TabIndex = 73;
            this.label5.Text = "Kho :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loai
            // 
            this.loai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.loai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loai.Enabled = false;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.ItemHeight = 13;
            this.loai.Location = new System.Drawing.Point(627, 28);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(80, 21);
            this.loai.TabIndex = 5;
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loai_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(491, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 23);
            this.label4.TabIndex = 74;
            this.label4.Text = "Năm sinh :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(315, 28);
            this.hoten.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(184, 21);
            this.hoten.TabIndex = 3;
            this.hoten.Validated += new System.EventHandler(this.hoten_Validated);
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(559, 28);
            this.namsinh.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.namsinh.MaxLength = 4;
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(39, 21);
            this.namsinh.TabIndex = 4;
            this.namsinh.Validated += new System.EventHandler(this.namsinh_Validated);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(591, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 23);
            this.label6.TabIndex = 77;
            this.label6.Text = "Loại :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.makp.Enabled = false;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(559, 51);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(30, 21);
            this.makp.TabIndex = 7;
            this.makp.Validated += new System.EventHandler(this.makp_Validated);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Enabled = false;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(91, 74);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(220, 21);
            this.tenbs.TabIndex = 10;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.Validated += new System.EventHandler(this.tenbs_Validated);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(-16, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 23);
            this.label11.TabIndex = 93;
            this.label11.Text = "Bác sĩ :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listDMBS
            // 
            this.listDMBS.BackColor = System.Drawing.SystemColors.Info;
            this.listDMBS.ColumnCount = 0;
            this.listDMBS.Location = new System.Drawing.Point(165, 555);
            this.listDMBS.MatchBufferTimeOut = 1000;
            this.listDMBS.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listDMBS.Name = "listDMBS";
            this.listDMBS.Size = new System.Drawing.Size(75, 17);
            this.listDMBS.TabIndex = 99;
            this.listDMBS.TextIndex = -1;
            this.listDMBS.TextMember = null;
            this.listDMBS.ValueIndex = -1;
            this.listDMBS.Visible = false;
            // 
            // sum
            // 
            this.sum.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sum.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sum.ForeColor = System.Drawing.Color.Red;
            this.sum.Location = new System.Drawing.Point(40, 122);
            this.sum.Name = "sum";
            this.sum.ReadOnly = true;
            this.sum.Size = new System.Drawing.Size(104, 23);
            this.sum.TabIndex = 1001;
            this.sum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabs.Enabled = false;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(40, 74);
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(48, 21);
            this.mabs.TabIndex = 9;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // sotienban
            // 
            this.sotienban.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sotienban.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sotienban.Enabled = false;
            this.sotienban.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sotienban.Location = new System.Drawing.Point(530, 452);
            this.sotienban.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sotienban.Name = "sotienban";
            this.sotienban.Size = new System.Drawing.Size(104, 23);
            this.sotienban.TabIndex = 21;
            this.sotienban.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(-40, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 23);
            this.label8.TabIndex = 103;
            this.label8.Text = "Tổng :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Blue;
            this.label12.Location = new System.Drawing.Point(42, 97);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 23);
            this.label12.TabIndex = 104;
            this.label12.Text = "0";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(-5, 122);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 23);
            this.label13.TabIndex = 105;
            this.label13.Text = "Số tiền :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timkiem
            // 
            this.timkiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timkiem.BackColor = System.Drawing.SystemColors.HighlightText;
            this.timkiem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timkiem.ForeColor = System.Drawing.SystemColors.WindowText;
            this.timkiem.Location = new System.Drawing.Point(631, 122);
            this.timkiem.Name = "timkiem";
            this.timkiem.Size = new System.Drawing.Size(155, 23);
            this.timkiem.TabIndex = 107;
            this.timkiem.Text = "Tìm kiếm";
            this.timkiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.timkiem.TextChanged += new System.EventHandler(this.timkiem_TextChanged);
            this.timkiem.Enter += new System.EventHandler(this.timkiem_Enter);
            // 
            // ltoaso
            // 
            this.ltoaso.Location = new System.Drawing.Point(107, 97);
            this.ltoaso.Name = "ltoaso";
            this.ltoaso.Size = new System.Drawing.Size(48, 23);
            this.ltoaso.TabIndex = 1002;
            this.ltoaso.Text = "Toa số :";
            this.ltoaso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toaso
            // 
            this.toaso.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toaso.ForeColor = System.Drawing.Color.Blue;
            this.toaso.Location = new System.Drawing.Point(154, 97);
            this.toaso.Name = "toaso";
            this.toaso.Size = new System.Drawing.Size(40, 23);
            this.toaso.TabIndex = 1003;
            this.toaso.Text = "0";
            this.toaso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(198, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 23);
            this.label1.TabIndex = 1004;
            this.label1.Text = "Chẩn đoán :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // maicd
            // 
            this.maicd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maicd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.maicd.Enabled = false;
            this.maicd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maicd.Location = new System.Drawing.Point(262, 99);
            this.maicd.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.maicd.Name = "maicd";
            this.maicd.Size = new System.Drawing.Size(48, 21);
            this.maicd.TabIndex = 11;
            this.maicd.Validated += new System.EventHandler(this.maicd_Validated);
            // 
            // chandoan
            // 
            this.chandoan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(312, 99);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(395, 21);
            this.chandoan.TabIndex = 12;
            this.chandoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
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
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid1.Location = new System.Drawing.Point(8, 128);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 269);
            this.dataGrid1.TabIndex = 1005;
            this.dataGrid1.Leave += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // bsma
            // 
            this.bsma.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bsma.Enabled = false;
            this.bsma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsma.Location = new System.Drawing.Point(365, 276);
            this.bsma.Name = "bsma";
            this.bsma.Size = new System.Drawing.Size(62, 21);
            this.bsma.TabIndex = 1006;
            // 
            // pBienlai
            // 
            this.pBienlai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pBienlai.Controls.Add(this.sobienlai);
            this.pBienlai.Controls.Add(this.sohieu);
            this.pBienlai.Controls.Add(this.butSohieu);
            this.pBienlai.Controls.Add(this.label19);
            this.pBienlai.Controls.Add(this.label7);
            this.pBienlai.Controls.Add(this.chkBienlai);
            this.pBienlai.Location = new System.Drawing.Point(314, 73);
            this.pBienlai.Name = "pBienlai";
            this.pBienlai.Size = new System.Drawing.Size(472, 24);
            this.pBienlai.TabIndex = 1008;
            // 
            // sobienlai
            // 
            this.sobienlai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sobienlai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sobienlai.Enabled = false;
            this.sobienlai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sobienlai.Location = new System.Drawing.Point(317, 1);
            this.sobienlai.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.sobienlai.Name = "sobienlai";
            this.sobienlai.Size = new System.Drawing.Size(76, 21);
            this.sobienlai.TabIndex = 2;
            this.sobienlai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sohieu_KeyDown);
            // 
            // sohieu
            // 
            this.sohieu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sohieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sohieu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sohieu.Enabled = false;
            this.sohieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sohieu.Location = new System.Drawing.Point(105, 1);
            this.sohieu.Name = "sohieu";
            this.sohieu.Size = new System.Drawing.Size(170, 21);
            this.sohieu.TabIndex = 1;
            this.sohieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sohieu_KeyDown);
            // 
            // butSohieu
            // 
            this.butSohieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butSohieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSohieu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSohieu.Location = new System.Drawing.Point(395, 0);
            this.butSohieu.Name = "butSohieu";
            this.butSohieu.Size = new System.Drawing.Size(75, 23);
            this.butSohieu.TabIndex = 1011;
            this.butSohieu.Text = "Số hiệu";
            this.butSohieu.Click += new System.EventHandler(this.butSohieu_Click);
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.Location = new System.Drawing.Point(253, 1);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 23);
            this.label19.TabIndex = 1;
            this.label19.Text = "Số :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(63, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 23);
            this.label7.TabIndex = 0;
            this.label7.Text = "Số hiệu :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkBienlai
            // 
            this.chkBienlai.Enabled = false;
            this.chkBienlai.Location = new System.Drawing.Point(3, 2);
            this.chkBienlai.Name = "chkBienlai";
            this.chkBienlai.Size = new System.Drawing.Size(70, 24);
            this.chkBienlai.TabIndex = 0;
            this.chkBienlai.Text = "Biên lai";
            this.chkBienlai.CheckedChanged += new System.EventHandler(this.chkBienlai_CheckedChanged);
            this.chkBienlai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sohieu_KeyDown);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(145, 122);
            this.label14.Name = "label14";
            this.label14.ReadOnly = true;
            this.label14.Size = new System.Drawing.Size(484, 23);
            this.label14.TabIndex = 1009;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(-15, 49);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(165, 23);
            this.label21.TabIndex = 1012;
            this.label21.Text = "Địa chỉ  ( điện thoại ) liên hệ :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // diachi
            // 
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(149, 51);
            this.diachi.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(350, 21);
            this.diachi.TabIndex = 6;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.Location = new System.Drawing.Point(698, 99);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(64, 23);
            this.label22.TabIndex = 1013;
            this.label22.Text = "Số thang :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // songay
            // 
            this.songay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.songay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.songay.Enabled = false;
            this.songay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songay.ForeColor = System.Drawing.Color.Red;
            this.songay.Location = new System.Drawing.Point(761, 99);
            this.songay.Name = "songay";
            this.songay.Size = new System.Drawing.Size(25, 21);
            this.songay.TabIndex = 13;
            this.songay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.songay.Validated += new System.EventHandler(this.songay_Validated);
            this.songay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.songay_KeyDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(792, 25);
            this.toolStrip1.TabIndex = 1014;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.butGoi,
            this.chkXem,
            this.chkXml});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(56, 22);
            this.toolStripDropDownButton1.Text = "Tiện ích";
            this.toolStripDropDownButton1.ToolTipText = " ";
            // 
            // butGoi
            // 
            this.butGoi.Enabled = false;
            this.butGoi.Name = "butGoi";
            this.butGoi.Size = new System.Drawing.Size(161, 22);
            this.butGoi.Text = "Chọn gói";
            this.butGoi.Click += new System.EventHandler(this.butGoi_Click);
            // 
            // chkXem
            // 
            this.chkXem.CheckOnClick = true;
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(161, 22);
            this.chkXem.Text = "Xem trước khi in";
            // 
            // chkXml
            // 
            this.chkXml.CheckOnClick = true;
            this.chkXml.Name = "chkXml";
            this.chkXml.Size = new System.Drawing.Size(161, 22);
            this.chkXml.Text = "Xuất ra Xml";
            // 
            // butTon
            // 
            this.butTon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butTon.Image = ((System.Drawing.Image)(resources.GetObject("butTon.Image")));
            this.butTon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTon.Location = new System.Drawing.Point(709, 27);
            this.butTon.Name = "butTon";
            this.butTon.Size = new System.Drawing.Size(75, 23);
            this.butTon.TabIndex = 1010;
            this.butTon.Text = "Xem tồn";
            this.butTon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butTon.Click += new System.EventHandler(this.butTon_Click);
            // 
            // butBienlai
            // 
            this.butBienlai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBienlai.Image = global::Duoc.Properties.Resources.VIENPHI;
            this.butBienlai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBienlai.Location = new System.Drawing.Point(648, 530);
            this.butBienlai.Name = "butBienlai";
            this.butBienlai.Size = new System.Drawing.Size(70, 25);
            this.butBienlai.TabIndex = 38;
            this.butBienlai.Text = "In biên lai";
            this.butBienlai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBienlai.Click += new System.EventHandler(this.butBienlai_Click);
            // 
            // butDonthuoc
            // 
            this.butDonthuoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butDonthuoc.Image = ((System.Drawing.Image)(resources.GetObject("butDonthuoc.Image")));
            this.butDonthuoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDonthuoc.Location = new System.Drawing.Point(4, 530);
            this.butDonthuoc.Name = "butDonthuoc";
            this.butDonthuoc.Size = new System.Drawing.Size(84, 25);
            this.butDonthuoc.TabIndex = 40;
            this.butDonthuoc.Text = "Đơn thuốc";
            this.butDonthuoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butDonthuoc.Click += new System.EventHandler(this.butDonthuoc_Click);
            // 
            // butMua
            // 
            this.butMua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMua.Image = ((System.Drawing.Image)(resources.GetObject("butMua.Image")));
            this.butMua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMua.Location = new System.Drawing.Point(548, 530);
            this.butMua.Name = "butMua";
            this.butMua.Size = new System.Drawing.Size(100, 25);
            this.butMua.TabIndex = 37;
            this.butMua.Text = "Mua thêm đơn";
            this.butMua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butMua.Click += new System.EventHandler(this.butMua_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(718, 530);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 39;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(483, 530);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(65, 25);
            this.butIn.TabIndex = 36;
            this.butIn.Text = "&In đơn";
            this.butIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(428, 530);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(55, 25);
            this.butHuy.TabIndex = 35;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(368, 530);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(60, 25);
            this.butBoqua.TabIndex = 34;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butXoa
            // 
            this.butXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butXoa.Enabled = false;
            this.butXoa.Image = ((System.Drawing.Image)(resources.GetObject("butXoa.Image")));
            this.butXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXoa.Location = new System.Drawing.Point(313, 530);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(55, 25);
            this.butXoa.TabIndex = 31;
            this.butXoa.Text = "    &Xóa";
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butThem
            // 
            this.butThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butThem.Enabled = false;
            this.butThem.Image = ((System.Drawing.Image)(resources.GetObject("butThem.Image")));
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(253, 530);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(60, 25);
            this.butThem.TabIndex = 29;
            this.butThem.Text = "&Thêm";
            this.butThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(198, 530);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(55, 25);
            this.butLuu.TabIndex = 30;
            this.butLuu.Text = "&Lưu";
            this.butLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(143, 530);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(55, 25);
            this.butSua.TabIndex = 32;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(88, 530);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(55, 25);
            this.butMoi.TabIndex = 33;
            this.butMoi.Text = "&Mới";
            this.butMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // cachdung
            // 
            this.cachdung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cachdung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cachdung.Enabled = false;
            this.cachdung.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cachdung.Location = new System.Drawing.Point(57, 477);
            this.cachdung.Name = "cachdung";
            this.cachdung.Size = new System.Drawing.Size(617, 23);
            this.cachdung.TabIndex = 23;
            this.cachdung.TextChanged += new System.EventHandler(this.cachdung_TextChanged);
            this.cachdung.Validated += new System.EventHandler(this.cachdung_Validated);
            this.cachdung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cachdung_KeyDown);
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label23.Location = new System.Drawing.Point(-6, 477);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(63, 23);
            this.label23.TabIndex = 1016;
            this.label23.Text = "Cách dùng";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listcachdung
            // 
            this.listcachdung.BackColor = System.Drawing.SystemColors.Info;
            this.listcachdung.ColumnCount = 0;
            this.listcachdung.Location = new System.Drawing.Point(530, 555);
            this.listcachdung.MatchBufferTimeOut = 1000;
            this.listcachdung.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listcachdung.Name = "listcachdung";
            this.listcachdung.Size = new System.Drawing.Size(75, 17);
            this.listcachdung.TabIndex = 1017;
            this.listcachdung.TextIndex = -1;
            this.listcachdung.TextMember = null;
            this.listcachdung.ValueIndex = -1;
            this.listcachdung.Visible = false;
            // 
            // lbldungluc
            // 
            this.lbldungluc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbldungluc.Location = new System.Drawing.Point(674, 478);
            this.lbldungluc.Name = "lbldungluc";
            this.lbldungluc.Size = new System.Drawing.Size(110, 23);
            this.lbldungluc.TabIndex = 1018;
            this.lbldungluc.Text = "Sau ăn";
            this.lbldungluc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mavach_sttt
            // 
            this.mavach_sttt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mavach_sttt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mavach_sttt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mavach_sttt.Enabled = false;
            this.mavach_sttt.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mavach_sttt.Location = new System.Drawing.Point(57, 403);
            this.mavach_sttt.Name = "mavach_sttt";
            this.mavach_sttt.Size = new System.Drawing.Size(406, 23);
            this.mavach_sttt.TabIndex = 14;
            this.mavach_sttt.Validated += new System.EventHandler(this.mavach_sttt_Validated);
            this.mavach_sttt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.songay_KeyDown);
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label26.Location = new System.Drawing.Point(-2, 403);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(58, 23);
            this.label26.TabIndex = 1020;
            this.label26.Text = "Mã vạch:";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butbnmoi
            // 
            this.butbnmoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butbnmoi.ForeColor = System.Drawing.Color.Black;
            this.butbnmoi.Location = new System.Drawing.Point(240, 27);
            this.butbnmoi.Name = "butbnmoi";
            this.butbnmoi.Size = new System.Drawing.Size(37, 23);
            this.butbnmoi.TabIndex = 1021;
            this.butbnmoi.Text = "BNMới";
            this.butbnmoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.butbnmoi, "Bệnh nhân Đăng ký mới");
            this.butbnmoi.UseVisualStyleBackColor = true;
            this.butbnmoi.Visible = false;
            this.butbnmoi.Click += new System.EventHandler(this.butbnmoi_Click);
            // 
            // frmXuatban
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.butbnmoi);
            this.Controls.Add(this.mavach_sttt);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.lbldungluc);
            this.Controls.Add(this.listcachdung);
            this.Controls.Add(this.cachdung);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.chandoan);
            this.Controls.Add(this.songay);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.butTon);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.timkiem);
            this.Controls.Add(this.tenkp);
            this.Controls.Add(this.pBienlai);
            this.Controls.Add(this.butBienlai);
            this.Controls.Add(this.sum);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.maicd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toaso);
            this.Controls.Add(this.ltoaso);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.loai);
            this.Controls.Add(this.butDonthuoc);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.butMua);
            this.Controls.Add(this.sotienban);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.listDMBS);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.makho);
            this.Controls.Add(this.listDuockp);
            this.Controls.Add(this.ngaysp);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl);
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
            this.Controls.Add(this.dongia);
            this.Controls.Add(this.mabd);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.ldvt);
            this.Controls.Add(this.lTen);
            this.Controls.Add(this.lMabd);
            this.Controls.Add(this.listDMBD);
            this.Controls.Add(this.stt);
            this.Controls.Add(this.sttt);
            this.Controls.Add(this.sotien);
            this.Controls.Add(this.bsma);
            this.Controls.Add(this.cmbSophieu);
            this.Controls.Add(this.sophieu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmXuatban";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu xuất bán";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmXuatban_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmXuatban_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmXuatban_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.pBienlai.ResumeLayout(false);
            this.pBienlai.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sobienlai)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmXuatban_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            bTinnhan_sound = d.bTinnhan_sound(i_nhom);
            user = d.user; xxx = user + s_mmyy; songayduyet = d.songayduyet(i_nhom);
            //
            f_load_option();
            //gam 24/08/2011
            if (d.bGiaban_theodot(i_nhom))
            {
                f_modify_database();
            }
            //end gam
            s_tu = m.DateToString("dd/MM/yyyy", m.StringToDate(s_ngay).AddDays(-1 * songayduyet));
            s_den = s_ngay; stime = "dd/mm/yyyy";
			bIncachdung=d.bIncachdung_xuatban(i_nhom);
            i_solanin = d.iLanin_xuatban(i_nhom); bXuatban_vienphi = d.bXuatban_vienphi(i_nhom);
            bBienlai_sohieu = d.bBienlai_sohieu(i_nhom);
			dsxml.ReadXml("..\\..\\..\\xml\\v_bienlai.xml");
			dslien.ReadXml("..\\..\\..\\xml\\v_lien.xml");
            bKho_dongy = bDongy(s_kho.Trim().Trim(','), 1);
            bHuyxuatban_userthuoc_duocphep = d.bHuyxuatban_userthuoc_duocphep(i_nhom);
            bXuatban_sua_trenluoi = d.bXuatban_sua_trenluoi(i_nhom);
			bBienlai=d.bBienlai_nhathuoc(i_nhom);
			bKytu_traiphai=d.bLockytu_traiphai(i_nhom);
			butBienlai.Enabled=bBienlai;
			bBacsy=d.bBacsy_xuatban(i_nhom);
			chkXem.Checked=d.bPreview;
			bMaso_ten=d.bMaso_ten(i_nhom);
			bInphieuxuatban=!d.bInPhieuxuatban(i_nhom);
			i_soluong_le=d.d_soluong_le(i_nhom);
			i_dongia_le=d.d_dongia_le(i_nhom);
			i_thanhtien_le=d.d_thanhtien_le(i_nhom);
			format_sotienban=d.format_giaban(i_nhom);
			format_sotien=d.format_sotien(i_nhom);
			format_dongia=d.format_dongia(i_nhom);
			format_soluong=d.format_soluong(i_nhom);
			bHotennt=d.bHotennt;bNgtru_khoa=d.bNgtru_khoa;
			bNgtru_bacsi=d.bNgtru_bacsi;bNamsinhnt=d.bNamsinhnt;
			bNhapmaso=d.bNhapmaso;bNgtru_mabn=d.bNgtru_mabn;
			if (!bNgtru_mabn)
			{
				lbl.Text="Số toa :";
				ltoaso.Visible=false;toaso.Visible=false;
			}
			bKhoaso=d.bKhoaso(i_nhom,s_mmyy);
			bChandoan=d.bChandoan_xuatban(i_nhom);
			i_songay=d.Ngaylv_Ngayht;
			s_makho="";
			s_manguon=d.get_manguon(i_loai).Trim();
			s_manguon=(s_manguon=="")?"":s_manguon.Substring(0,s_manguon.Length-1);
			sql="select ma,trim(ten)||' '||hamluong as ten,tenhc,dang,id,dongia,giaban from "+user+".d_dmbd where nhom="+i_nhom;
			if (d.bSort_mabd) sql+=" order by ma";
			else sql+=" order by ten";
			dtdmbd=d.get_data(sql).Tables[0];
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

			loai.DisplayMember="TEN";
			loai.ValueMember="ID";
            loai.DataSource = d.get_data("select * from " + user + ".d_dmloaint where nhom=" + i_nhom + " order by stt").Tables[0];//((i_quayban>0)?" and id="+i_quayban:"")+

			makho.DisplayMember="TEN";
			makho.ValueMember="ID";
            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
			if (s_makho!="") sql+=" and id in ("+s_makho+")";
			else if (s_kho!="") sql+=" and id in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			sql+=" order by stt";
            dtkho = d.get_data(sql).Tables[0];
            makho.DataSource = dtkho;
            sComputer = (dtkho.Rows.Count>0)?dtkho.Rows[0]["computer"].ToString():"";

			listDMBD.DisplayMember="TEN";
			listDMBD.ValueMember="STT";

			listDMBS.DisplayMember="VIETTAT";
			listDMBS.ValueMember="HOTEN";
            dtbs = d.get_data("select viettat,hoten,ma from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nhanvien + "," + LibMedi.AccessData.nghiviec + ") order by hoten").Tables[0];
			listDMBS.DataSource=dtbs;

			listDuockp.DisplayMember="ID";
			listDuockp.ValueMember="TEN";
            sql = "select ma,ten,id from " + user + ".d_duockp where nhom like '%" + i_nhom.ToString() + ",%'";
			if (s_makp!="") sql+=" and id in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			sql+=" order by stt";
			dtduockp=d.get_data(sql).Tables[0];
			listDuockp.DataSource=dtduockp;
            sql = "select distinct a.id,a.mabn,a.hoten,a.namsinh,to_char(a.ngay,'dd/mm/yyyy') as ngay,a.mabs,a.makp,a.loai,";
            sql+="a.done,a.userid,a.sotoa,a.maql,a.diachi,a.ghichu,a.songay,a.idttrv from " + xxx + ".d_ngtrull a," + xxx + ".d_ngtruct b where a.id=b.id and a.nhom=" + i_nhom;
			if (!bAdmin) sql+=" and a.userid="+i_userid;
			sql+=" and a.loai="+i_quayban;
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (d.bLocngoaitru) sql+=" and to_char(a.ngay,'dd/mm/yyyy')='"+s_ngay+"'";
			sql+=" order by a.loai,a.sotoa";
			dtll=d.get_data(sql).Tables[0];
			//
			label12.Text=dtll.Rows.Count.ToString("###,###,###");
			//
			cmbSophieu.DisplayMember=(bNgtru_mabn)?"MABN":"SOTOA";
			cmbSophieu.ValueMember="ID";
			cmbSophieu.DataSource=dtll;
			if (dtll.Rows.Count>0) cmbSophieu.SelectedIndex=dtll.Rows.Count-1;
			l_id=(dtll.Rows.Count==0)?0:decimal.Parse(dtll.Rows[dtll.Rows.Count-1]["id"].ToString());
			load_head(l_id);
			//load_grid();
			AddGridTableStyle();
			ref_text();
			dsxoa.ReadXml("..\\..\\..\\xml\\d_ngtruct.xml");
            dsxoa.Tables[0].Columns.Add("paid", typeof(decimal)).DefaultValue=0;
            try { dsxoa.Tables[0].Columns.Add("cachdung"); }
            catch { }
            butSohieu.Visible = bBienlai && bBienlai_sohieu;
            if (!d.bDuyetcap_sotien(i_nhom)) this.dongia.PasswordChar = '*';
            if (bTinnhan_sound)
            {
                Clock = new Timer();
                Clock.Interval = m.delay_tinnhan;
                Clock.Start();
                Clock.Tick += new EventHandler(Timer_Tick);
            }
            //Thuy 24.02.2012
            if (!b_quantri && i_kyhieu!=0)
            {
                butHuy.Enabled = b_quantri;
            }
		}

        public void Timer_Tick(object sender, EventArgs eArgs)
        {
            if (sender == Clock)
            {
                try
                {
                    m.get_tinnhan(sComputer,"duoc");
                }
                catch { }
            }
        }

		private void load_grid()
		{
			dataGrid1.DataSource=null;
			sql="select a.stt,a.sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,e.ten as tenkho,c.ten as tennguon,d.ten as tennhomcc,t.handung,t.losx,a.soluong,t.giamua as dongia,a.soluong*t.giamua as sotien,a.giaban,t.giamua,a.makho,t.manguon,t.nhomcc,a.soluong*a.giaban as sotienban,a.soluong as soluongcu,a.soluong*t.giamua as sotiencu,a.madoituong,a.paid, a.cachdung ";
            sql += " from " + xxx + ".d_ngtruct a," + user + ".d_dmbd b," + user + ".d_dmnguon c," + user + ".d_dmnx d," + user + ".d_dmkho e," + xxx + ".d_theodoi t where a.sttt=t.id and a.mabd=b.id and t.manguon=c.id and t.nhomcc=d.id and a.makho=e.id and a.id=" + l_id + " order by a.stt";
			dtct=d.get_data(sql).Tables[0];
			dataGrid1.DataSource=dtct;

		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				stt.Text=dataGrid1[i,0].ToString();
				mabd.Text=dataGrid1[i,1].ToString();
				tenbd.Text=dataGrid1[i,2].ToString();
				tenhc.Text=dataGrid1[i,3].ToString();
				dang.Text=dataGrid1[i,4].ToString();
				handung.Text=dataGrid1[i,8].ToString();
				losx.Text=dataGrid1[i,9].ToString();
				d_soluong=(dataGrid1[i,10].ToString()!="")?decimal.Parse(dataGrid1[i,10].ToString()):0;
                //try { d_sothang = (songay.Text != "" || songay.Text.Trim() == "0") ? decimal.Parse(songay.Text) : 1; }
                //catch { d_sothang = 1; }
                //if (d_sothang != 0) d_soluong = d_soluong / d_sothang;
                //else d_sothang = 1;
				d_dongia=(dataGrid1[i,11].ToString()!="")?decimal.Parse(dataGrid1[i,11].ToString()):0;
				d_sotien=(dataGrid1[i,12].ToString()!="")?decimal.Parse(dataGrid1[i,12].ToString()):0;
				d_giaban=(dataGrid1[i,13].ToString()!="")?decimal.Parse(dataGrid1[i,13].ToString()):0;
				soluong.Text=d_soluong.ToString(format_soluong);
				dongia.Text=d_dongia.ToString(format_dongia);
				sotien.Text=d_sotien.ToString(format_sotien);
				giaban.Text=d_giaban.ToString("#,###,###,##0");
				makho.SelectedValue=dataGrid1[i,14].ToString();
				manguon.SelectedValue=dataGrid1[i,15].ToString();
				nhomcc.SelectedValue=dataGrid1[i,16].ToString();
				sttt.Text=dataGrid1[i,17].ToString();
				d_sotienban=d_soluong*d_giaban;
				//dataGrid1[i,18]=d_sotienban;
				sotienban.Text=d_sotienban.ToString(format_sotien);
                d_soluongcu = (bNew) ? 0 : d_soluong;
				d_sotiencu=d_sotien;
                i_paid = int.Parse(dataGrid1[i, 20].ToString());
				if (butLuu.Enabled)
				{
					tenbd.Enabled=sttt.Text=="0";
					if (bNhapmaso) mabd.Enabled=tenbd.Enabled;
                    if (bQuanly_xuatban_theomavach) mavach_sttt.Enabled = tenbd.Enabled;
					//soluong.Enabled=tenbd.Enabled;
					sum_sotienban();
				}
                cachdung.Text = dataGrid1[i, 21].ToString();
                //
                DataRow dr = d.getrowbyid(dtct, "stt=" + stt.Text);
                if (dr != null)
                {
                    sttt.Text  = dr["sttt"].ToString();
                    mavach_sttt.Text=dr["sttt"].ToString();
                }
                //
			}
			catch{}
		}

		private void AddGridTableStyle()
		{
			DataGridColoredTextBoxColumn TextCol;
			delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.RowHeaderWidth=10;
			ts.MappingName = dtct.TableName;
			ts.AllowSorting=false;
           
			
			TextCol=new DataGridColoredTextBoxColumn(de, 0);
			TextCol.MappingName = "stt";
			TextCol.HeaderText = "TT";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 1);
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã số";
			TextCol.Width = 80;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 2);
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên";
			TextCol.Width = 310;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 3);
			TextCol.MappingName = "tenhc";
			TextCol.HeaderText = "";//(d.bHoatchat)?"Hoạt chất":"";
			TextCol.Width = 0;//(d.bHoatchat)?200:0;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 4);
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 60;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 5);
			TextCol.MappingName = "tenkho";
			TextCol.HeaderText = "Kho xuất";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 6);
			TextCol.MappingName = "tennguon";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 7);
			TextCol.MappingName = "tennhomcc";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 8);
			TextCol.MappingName = "handung";
			TextCol.HeaderText ="";
			TextCol.Width =0;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 9);
			TextCol.MappingName = "losx";
			TextCol.HeaderText = "";
			TextCol.Width =0;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 10);
			TextCol.MappingName = "soluong";
			TextCol.HeaderText = "Số lượng";
			TextCol.Width = 70;
			TextCol.Format=format_soluong;
            TextCol.ReadOnly = !bXuatban_sua_trenluoi;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 11);
			TextCol.MappingName = "dongia";
			TextCol.HeaderText = "";
			TextCol.Width =0;
			TextCol.Format=format_dongia;
			TextCol.Alignment=HorizontalAlignment.Right;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de,12);
			TextCol.MappingName = "sotien";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 13);
			TextCol.MappingName = "giaban";
			TextCol.HeaderText = (bGiaban)?"Giá bán":"";
			TextCol.Width = (bGiaban)?90:0;
			TextCol.Format="###,###,###,##0";
			TextCol.Alignment=HorizontalAlignment.Right;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 14);
			TextCol.MappingName = "makho";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 15);
			TextCol.MappingName = "manguon";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 16);
			TextCol.MappingName = "nhomcc";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 17);
			TextCol.MappingName = "sttt";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 18);
			TextCol.MappingName = "sotienban";
			TextCol.HeaderText = "Số tiền";
			TextCol.Width = 100;
			TextCol.Format=format_sotien;
			TextCol.Alignment=HorizontalAlignment.Right;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 19);
			TextCol.MappingName = "soluongcu";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 20);
            TextCol.MappingName = "paid";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 21);
            TextCol.MappingName = "cachdung";
            TextCol.HeaderText = "Cách dùng";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
            return (dataGrid1[row, 10].ToString() == "0" || dataGrid1[row, 20].ToString() == "0") ? Color.Red : Color.Black;
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
		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
                if (butSua.Enabled) { ref_text(); return; }
                if (bXuatban_sua_trenluoi==false) { ref_text(); return; }
				//if (dataGrid1.CurrentCell.ColumnNumber==10 && i_row<dtct.Rows.Count)
                int tmp_index = dataGrid1.CurrentRowIndex;
                if (i_row < dtct.Rows.Count)
				{
					if (!bNew)
					{
						if (decimal.Parse(dataGrid1[i_row,10].ToString())!=d_soluongcu)
						{
							d.updrec_ngtruct(dsxoa.Tables[0],int.Parse(stt.Text),decimal.Parse(dataGrid1[i_row,17].ToString()),i_mabd,mabd.Text,tenbd.Text,tenhc.Text,dang.Text,makho.Text,(manguon.SelectedIndex==-1)?"":manguon.Text,(nhomcc.SelectedIndex==-1)?"":nhomcc.Text,handung.Text,losx.Text,d_soluongcu,d_dongia,d_soluongcu*d_dongia,d_giaban,d_dongia,Math.Round(d_soluongcu*d_giaban,3),int.Parse(makho.SelectedValue.ToString()),(manguon.SelectedIndex==-1)?0:int.Parse(manguon.SelectedValue.ToString()),(nhomcc.SelectedIndex==-1)?0:int.Parse(nhomcc.SelectedValue.ToString()),dtton,d_soluongcu,d_sotiencu,dataGrid1[i_row,21].ToString());
							dataGrid1[i_row,17]=0;
						}
					}
                    if (!bNew && dataGrid1[i_row, 17].ToString() != "0" && dataGrid1[i_row, 17].ToString().Trim() != "")//sttt>0
					{
						if (decimal.Parse(dataGrid1[i_row,10].ToString())>decimal.Parse(dataGrid1[i_row,19].ToString()))//soluog > slcu
                            if (dataGrid1[i_row, 19].ToString() != "0" && dataGrid1[i_row, 19].ToString().Trim()!="")dataGrid1[i_row, dataGrid1.CurrentCell.ColumnNumber] = decimal.Parse(dataGrid1[i_row, 19].ToString());
					}
					else
					{
						r=d.getrowbyid(dtton,"ma='"+dataGrid1[i_row,1].ToString()+"'");
						if (r!=null)
						{
							i_mabd=int.Parse(r["id"].ToString());
							d_soluongton=d.get_slton_nguon(dtton,int.Parse(dataGrid1[i_row,14].ToString()),i_mabd,int.Parse(dataGrid1[i_row,15].ToString()),decimal.Parse(dataGrid1[i_row,19].ToString()));
                            if (decimal.Parse(dataGrid1[i_row, 10].ToString()) > d_soluongton)
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Số lượng xuất lớn hơn số lượng tồn !(") + d_soluongton.ToString() + ")", d.Msg);
                                dataGrid1[i_row, 10] = dataGrid1[i_row, 19].ToString(); //d_soluongcu;//dataGrid1[i_row,dataGrid1.CurrentCell.ColumnNumber]=0;
                            }
                            else
                            {
                                tmp_index = dataGrid1.CurrentRowIndex;
                                dataGrid1[i_row, 19] = dataGrid1[i_row, 10].ToString();
                            }
						}
					}
					upd_rec(int.Parse(dataGrid1[i_row,0].ToString()),decimal.Parse(dataGrid1[i_row,10].ToString())*decimal.Parse(dataGrid1[i_row,13].ToString()));
				}
                i_row = tmp_index;
                dataGrid1.CurrentRowIndex=tmp_index;
			}
            catch { i_row = dataGrid1.CurrentRowIndex; }
			ref_text();
		}

		private void upd_rec(int stt,decimal sotien)
		{
			DataRow [] dr=dtct.Select("stt="+stt);
			if (dr.Length>0) dr[0]["sotienban"]=sotien;
			sum_sotienban();
		}

		private void sum_sotienban()
		{
			d_tongcong=0;
			foreach(DataRow r in dtct.Select("soluong>0 and paid=1"))
				d_tongcong+=decimal.Parse(r["soluong"].ToString())*decimal.Parse(r["giaban"].ToString());
			sum.Text=d_tongcong.ToString("###,###,###,##0");
			string s_chu=doiso.Doiso_Unicode(Convert.ToInt64(d_tongcong).ToString());
			label14.Text=s_chu;
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
                catch { l_id = 0; l_id1 = ""; }
				load_head(l_id);
			}
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
				if (bKytu_traiphai) sql="(soluong>0) and (ten like '"+ten.Trim()+"%'"+" or tenhc like '"+ten.Trim()+"%')";
				else sql="(soluong>0) and (ten like '%"+ten.Trim()+"%'"+" or tenhc like '%"+ten.Trim()+"%')";
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
				listDMBD.Tonkhoct_xuatban(tenbd,mabd,soluong,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lTenhc.Width+tenhc.Width+lMabd.Width-45,mabd.Height+5);
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
			//ngaysp.Enabled=ena;
            if (butbnmoi.Visible) butbnmoi.Enabled = ena;
            else butbnmoi.Enabled = false;
			if (bHotennt) hoten.Enabled=ena;
			loai.Enabled=(i_quayban>0)?false:ena;
			if (bNgtru_khoa) tenkp.Enabled=ena;
			if (bNgtru_bacsi) tenbs.Enabled=ena;
			if (bNamsinhnt) namsinh.Enabled=ena;
			if (bNhapmaso) mabd.Enabled=ena;
			if (bNgtru_mabn) sophieu.Enabled=ena;
			if (bChandoan) maicd.Enabled=ena;
            if (butSohieu.Visible) butSohieu.Enabled = ena;
            diachi.Enabled = hoten.Enabled;
			chandoan.Enabled=maicd.Enabled;
			makp.Enabled=tenkp.Enabled;
			mabs.Enabled=tenbs.Enabled;
            cachdung.Enabled = ena;
            if (bKho_dongy) songay.Enabled = ena;
			tenbd.Enabled=ena;
            timkiem.Enabled = !ena;
			soluong.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butThem.Enabled=ena;
            butMua.Enabled = (bQuanly_xuatban_theomavach || bGiaban_theodot) ? false : !ena; //butMua.Enabled = !ena;
            mavach_sttt.Enabled = (bQuanly_xuatban_theomavach) ? ena : false; //
            mavach_sttt.Visible = bQuanly_xuatban_theomavach;
			butDonthuoc.Enabled=!ena;
			butXoa.Enabled=ena;
            butHuy.Enabled = !ena;
			butGoi.Enabled= butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butIn.Enabled=!ena;
			if (bBienlai)
			{
				butBienlai.Enabled=!ena;
				chkBienlai.Enabled=ena;
			}
            if (!ena)
            {
                sohieu.Enabled = ena;
                sobienlai.Enabled = ena;
            }
            //else
            //{
            //timkiem.Text = "";
            //CurrencyManager cm = (CurrencyManager)BindingContext[cmbSophieu.DataSource];
            //DataView dv = (DataView)cm.List;
            //dv.RowFilter = "";
            //}
            
			butKetthuc.Enabled=!ena;
			i_old=cmbSophieu.SelectedIndex;
			if (ena) load_dm();
			dataGrid1.ReadOnly=!ena;
			CurrencyManager cm1= (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember];  
			DataView dv1 = (DataView) cm1.List; 
			//dv.AllowNew = false; 
        }

		private void emp_head()
		{
            l_id = 0;
            l_id1 = "";
            s_mabn = "";
			if (timkiem.Text!="") timkiem.Text="";
            if (sophieu.Enabled) sophieu.Text = "";
            else
            {
                s_mabn_tmp= d.get_sotoa_xuatban(s_mmyy, i_quayban, s_ngay).ToString();//;d.get_stt(dtll,"mabn").ToString();
                sophieu.Text = s_mabn_tmp;
            }
			ngaysp.Text=s_ngay;
			s_ngaysp=ngaysp.Text;
			diachi.Text=hoten.Text=namsinh.Text="";
			tenkp.Text=makp.Text=mabs.Text=tenbs.Text=bsma.Text="";
			sum.Text="0";toaso.Text="";
			songay.Text=label14.Text=maicd.Text=chandoan.Text="";
			chkBienlai.Checked=false;
			if(i_quayban>0)loai.SelectedValue=i_quayban.ToString();
			if (bBienlai)
			{
				sohieu.Text=v.Thongso("c01");
                if (bBienlai_sohieu)
                {
                    if (i_kyhieu == 0)
                    {
                        foreach (DataRow r in m.get_data("select id from " + user + ".v_quyenso where sohieu='" + sohieu.Text + "'").Tables[0].Rows)
                            i_kyhieu = int.Parse(r["id"].ToString());
                    }
                    sobienlai.Value = m.get_sobienlai(i_kyhieu, 1);
                }
                else sobienlai.Value=d.get_sobienlai(s_mmyy);
			}
            //timkiem.Text = "";
            //CurrencyManager cm = (CurrencyManager)BindingContext[cmbSophieu.DataSource];
            //DataView dv = (DataView)cm.List;
            //dv.RowFilter = "";
			dtct.Clear();
			dsxoa.Clear();
		}
		
		private void emp_detail()
		{
            mavach_sttt.Text = "";
			sttt.Text=stt.Text=mabd.Text="";
			tenbd.Text=tenhc.Text=dang.Text="";
            lbldungluc.Text = "";
			soluong.Text="0";
			dongia.Text="0";
			sotien.Text="0";
			sotienban.Text="0";
			handung.Text="";
			losx.Text="";
			giaban.Text="0";
            i_paid = 1;
			manguon.SelectedIndex=-1;
			nhomcc.SelectedIndex=-1;
			makho.SelectedIndex=-1;
			stt.Text=d.get_stt(dtct).ToString();
			d_soluongcu=0;
			d_sotiencu=0;
            cachdung.Text = "";
		}
		private void butMoi_Click(object sender, System.EventArgs e)
		{
			if (bKhoaso)
			{
				MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng")+" "+s_mmyy.Substring(0,2)+" "+lan.Change_language_MessageText("năm")+" "+s_mmyy.Substring(2,2)+" "+lan.Change_language_MessageText("đã khóa !")+"\n"+lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"),d.Msg);
				return;
			}   
            //
            timkiem.Text = "";
            //
			ena_object(true);
			dtct.Clear();
			dtsave.Clear();
			emp_head();
			emp_detail();
            tmp_userid = i_userid;
			bNew=true;
			bEdit=true;
            
            if (bNhapmaso) mabd.Enabled = true;
			if (sophieu.Enabled) sophieu.Focus();
            else if (bQuanly_xuatban_theomavach && mavach_sttt.Enabled) mavach_sttt.Focus();
			else if (hoten.Enabled) hoten.Focus();
			else if (makp.Enabled) makp.Focus();
			else if (mabs.Enabled) mabs.Focus();
			else if (maicd.Enabled) maicd.Focus();
			else if (mabd.Enabled) mabd.Focus();
			else if (tenbd.Enabled) tenbd.Focus();

            sophieu.Text = s_mabn_tmp;
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
			if (dtll.Rows[cmbSophieu.SelectedIndex]["done"].ToString()=="1" && !bAdmin)
			{
				MessageBox.Show(lan.Change_language_MessageText("Đơn thuốc đã in") + "\n" +lan.Change_language_MessageText("Bạn không được sửa !"), d.Msg);
				return;
			}
            if (!bThuhoi)
            {
                MessageBox.Show(lan.Change_language_MessageText("Bạn không có quyền chỉnh sửa !"), d.Msg);
                return;
            }
			ena_object(true);
			bNew=false;
			bEdit=true;
			dtsave=dtct.Copy();
			if (chkBienlai.Checked)
			{
				sohieu.Enabled=true;
				sobienlai.Enabled=true;
			}
			dsxoa.Clear();
			if (sophieu.Enabled) sophieu.Focus();
			else hoten.Focus();
			ref_text();
		}
		private bool KiemtraHead()
		{
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
			if (loai.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập loại !"),d.Msg);
				loai.Focus();
				return false;
			}
			i_makp=0;
			if (tenkp.Enabled)
			{
				r=d.getrowbyid(dtduockp,"ten='"+tenkp.Text+"'");
				if (r==null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Khoa không hợp lệ !"),d.Msg);
					tenkp.Focus();
					return false;
				}
				i_makp=int.Parse(r["id"].ToString());
			}
			if (mabs.Enabled)
			{
				if (bBacsy)
				{
					if (mabs.Text=="" || tenbs.Text=="")
					{
						MessageBox.Show(lan.Change_language_MessageText("Bác sỹ không hợp lệ !"),d.Msg);
						if (mabs.Text=="") mabs.Focus();
						else tenbs.Focus();
						return false;
					}
				}
                /*
				else if ((mabs.Text!="" && tenbs.Text=="") || (mabs.Text=="" && tenbs.Text!=""))
				{
					if (mabs.Text=="") mabs.Focus();
					else tenbs.Focus();
					return false;
				}*/
				r=d.getrowbyid(dtbs,"viettat='"+mabs.Text+"'");
				if (r!=null) bsma.Text=r["ma"].ToString();
				else bsma.Text="";
			}
			if  (dtct.Rows.Count==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập mặt hàng !"),d.Msg);
				butThem.Focus();
				return false;
			}
			if (bNew)
			{
				try
				{
					int i_toaso=d.kiemtra_xuatban(dtll,dtct,hoten.Text.Trim(),s_mmyy);
					if (i_toaso!=0)
					{
						if (MessageBox.Show(lan.Change_language_MessageText("Họ tên")+" "+hoten.Text.Trim()+"\n"+lan.Change_language_MessageText("đã nhập toa số")+" "+i_toaso.ToString()+"\n"+lan.Change_language_MessageText("Bạn có muốn nhập thêm không ?"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No)
							return false;
						else
							hoten.Text=hoten.Text.Trim()+lan.Change_language_MessageText("(Mua thêm đơn)");
					}
				}
				catch{}
			}
			if (chkBienlai.Checked && chkBienlai.Enabled)
			{
				if (sohieu.Text=="")
				{
					MessageBox.Show(
lan.Change_language_MessageText("Nhập số hiệu biên lai !"),d.Msg);
					sohieu.Focus();
					return false;
				}
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
					MessageBox.Show(
lan.Change_language_MessageText("Nhập mã số !"),d.Msg);
					mabd.Focus();
					return false;
				}
				else if (tenbd.Text=="")
				{
					MessageBox.Show(
lan.Change_language_MessageText("Nhập tên !"),d.Msg);
					tenbd.Focus();
					return false;
				}
			}
			r=d.getrowbyid(dtton,"ma='"+mabd.Text+"'");
			if (r==null)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Mã số không hợp lệ !"),d.Msg);
				if (mabd.Enabled) mabd.Focus();
				else tenbd.Focus();
				return false;
			}
			i_mabd=int.Parse(r["id"].ToString());
			return true;
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			bEdit=false;
			try
			{
				cmbSophieu.SelectedIndex=i_old;
                if (cmbSophieu.Items.Count > 0) l_id = decimal.Parse(cmbSophieu.SelectedValue.ToString());
                else
                {
                    l_id = 0;
                    l_id1 = "";
                }

				load_head(l_id);
			}
			catch{}
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
			if (bNhapmaso) mabd.Enabled=true;
			tenbd.Enabled=true;
			soluong.Enabled=true;
            cachdung.Enabled = true;
            if(bQuanly_xuatban_theomavach) mavach_sttt.Enabled = true;
			if (!upd_table(dtct,false)) return;
            if (bQuanly_xuatban_theomavach)
            {
                foreach (DataRow r_ct in dtToaCT.Select("ma='" + mabd.Text + "'"))
                {
                    r_ct["slyeucau"] = decimal.Parse(r_ct["slyeucau"].ToString()) - decimal.Parse(soluong.Text);
                }
            }
			emp_detail();
            if (bQuanly_xuatban_theomavach && mavach_sttt.Enabled) mavach_sttt.Focus();
			else if (mabd.Enabled) mabd.Focus();
			else tenbd.Focus();
		}

		private void butXoa_Click(object sender, System.EventArgs e)
		{
			if (!upd_table(dsxoa.Tables[0],true)) return;
            if (bQuanly_xuatban_theomavach)
            {
                foreach (DataRow r_ct in dtToaCT.Select("ma='" + mabd.Text + "'"))
                {
                    r_ct["slyeucau"] = decimal.Parse(r_ct["slyeucau"].ToString()) + decimal.Parse(soluong.Text);
                }
            }
			d.delrec(dtct,"stt="+int.Parse(stt.Text));
			dtct.AcceptChanges();
			if (dtct.Rows.Count==0) emp_detail();
			else ref_text();
		}

        private bool KiemtraSL()
        {
            string asql = " select * from "+ d.user+"mmyy.d_thuocbhytct where mabn='"+sohieu.Text+"' ";
            return false;
        }

		private bool upd_table(DataTable dt,bool del)
		{
			if (!KiemtraDetail()) return false;
            d_soluong = (soluong.Text != "") ? decimal.Parse(soluong.Text) : 0;
            if (songay.Enabled)
            {
                try { d_sothang = (songay.Text != "" && songay.Text.Trim() != "0") ? decimal.Parse(songay.Text) : 1; }
                catch { d_sothang = 1; }
                if (d_sothang == 0) d_sothang = 1;
            }
            else d_sothang = 1;
			d_dongia=(dongia.Text!="")?decimal.Parse(dongia.Text):0;
			d_sotien=(sotien.Text!="")?decimal.Parse(sotien.Text):0;
			d_giaban=(giaban.Text!="")?decimal.Parse(giaban.Text):0;
			l_sttt=(sttt.Text!="")?decimal.Parse(sttt.Text):0;
			if (!bNew)
			{
				if (d_soluong*d_sothang!=d_soluongcu)
				{
					d.updrec_ngtruct(dsxoa.Tables[0],int.Parse(stt.Text),l_sttt,i_mabd,mabd.Text,tenbd.Text,tenhc.Text,dang.Text,makho.Text,(manguon.SelectedIndex==-1)?"":manguon.Text,(nhomcc.SelectedIndex==-1)?"":nhomcc.Text,handung.Text,losx.Text,d_soluongcu,d_dongia,d_soluongcu*d_dongia,d_giaban,d_dongia,Math.Round(d_soluongcu*d_giaban,3),int.Parse(makho.SelectedValue.ToString()),(manguon.SelectedIndex==-1)?0:int.Parse(manguon.SelectedValue.ToString()),(nhomcc.SelectedIndex==-1)?0:int.Parse(nhomcc.SelectedValue.ToString()),dtton,d_soluongcu,d_sotiencu,cachdung.Text);
					l_sttt=0;
				}
			}
            string s_cachdung = cachdung.Text;
            if (lbldungluc.Text.Trim() != "" && s_cachdung.IndexOf(lbldungluc.Text.Trim()) < 0) s_cachdung = s_cachdung.Trim() + " " + lbldungluc.Text;
            d.updrec_ngtruct(dt, int.Parse(stt.Text), l_sttt, i_mabd, mabd.Text, tenbd.Text, tenhc.Text, dang.Text, makho.Text, (manguon.SelectedIndex == -1) ? "" : manguon.Text, (nhomcc.SelectedIndex == -1) ? "" : nhomcc.Text, handung.Text, losx.Text, d_soluong * d_sothang, d_dongia, d_sotien, d_giaban, d_dongia, Math.Round(d_soluong * d_sothang * d_giaban, 3), int.Parse(makho.SelectedValue.ToString()), (manguon.SelectedIndex == -1) ? 0 : int.Parse(manguon.SelectedValue.ToString()), (nhomcc.SelectedIndex == -1) ? 0 : int.Parse(nhomcc.SelectedValue.ToString()), (del) ? null : dtton, d_soluongcu, d_sotiencu, s_cachdung, bQuanly_xuatban_theomavach || bGiaban_theodot);
            DataRow r = d.getrowbyid(dt, "stt=" + int.Parse(stt.Text));
            if (r != null) r["paid"] = i_paid;
			dt.AcceptChanges();
			if (bGiaban) tongcong_giaban(dtct);
			else tongcong(dtct);
			sum.Text=d_tongcong.ToString("###,###,###,##0");
            string s_chu=doiso.Doiso_Unicode(Convert.ToInt64(d_tongcong).ToString());
            label14.Text=s_chu;
			return true;
		}

		private void mabd_Validated(object sender, System.EventArgs e)
		{
			//if(!listDMBD.Focused) listDMBD.Hide();
		}

		private void listDMBD_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				try
				{
                    get_items(mabd.Text); //get_items(int.Parse(mabd.Text));			
				}
				catch{mabd.Focus();}
			}
		}

		private void tinh_giatri()
		{
			try
			{
                if (songay.Enabled)
                {
                    try { d_soluong = (soluong.Text != "" && songay.Text.Trim() != "0") ? decimal.Parse(soluong.Text) : 1; }
                    catch { d_sothang = 1; }
                    if (d_sothang == 0) d_sothang = 1;
                }
                else d_sothang = 1;
                d_soluong = d_soluong * d_sothang;
				d_dongia=(dongia.Text!="")?decimal.Parse(dongia.Text):0;
				d_giaban=(giaban.Text!="")?decimal.Parse(giaban.Text):0;
				d_sotienban=Math.Round(d_soluong*d_giaban,3);
				d_sotien=Math.Round(d_soluong*d_dongia,3);
				sotienban.Text=d_sotienban.ToString(format_sotienban);
				sotien.Text=d_sotien.ToString(format_sotien);
			}
			catch{}
		}
        private decimal get_slyeucau(DataTable mdtct, string exp)
        {
            decimal sum = 0;
            try
            {
                foreach (DataRow r in mdtct.Select(exp))
                {
                    sum += decimal.Parse(r["slyeucau"].ToString());
                }
            }
            catch { return -1; }
            return sum;
        }
		private void soluong_Validated(object sender, System.EventArgs e)
		{
			try
			{
                decimal tongsl = 0;
				if (!bEdit) return;
				d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
                if (songay.Enabled)
                {
                    try
                    {
                        d_sothang = (songay.Text != "" && songay.Text.Trim() != "0") ? decimal.Parse(songay.Text) : 1;
                    }
                    catch { d_sothang = 1; }
                    if (d_sothang == 0) d_sothang = 1;
                }
                else d_sothang = 1;
				soluong.Text=d_soluong.ToString(format_soluong);
				if (mabd.Text!="" && tenbd.Text!="")
				{
                    string exp = "ma='" + mabd.Text + "'";
                    if (bQuanly_xuatban_theomavach || bGiaban_theodot) exp += " and stt=" + sttt.Text;
                    r = d.getrowbyid(dtton, exp);
					if (r!=null)
					{
						i_mabd=int.Parse(r["id"].ToString());
                        if (bQuanly_xuatban_theomavach || bGiaban_theodot) d_soluongton = d.get_slton_nguon(dtton, int.Parse(makho.SelectedValue.ToString()), i_mabd, int.Parse(manguon.SelectedValue.ToString()), d_soluongcu, decimal.Parse(sttt.Text));
                        else d_soluongton = d.get_slton_nguon(dtton, int.Parse(makho.SelectedValue.ToString()), i_mabd, int.Parse(manguon.SelectedValue.ToString()), d_soluongcu);
                        if (bQuanly_xuatban_theomavach)
                            tongsl = get_slyeucau(dtToaCT, "ma='" + mabd.Text + "'");
						if (d_soluong*d_sothang > d_soluongton)
						{
							MessageBox.Show(lan.Change_language_MessageText("Số lượng xuất lớn hơn số lượng tồn !(")+(d_soluongton*d_sothang).ToString()+")",d.Msg);
							soluong.Focus();
							return;
						}
                        else if (bQuanly_xuatban_theomavach && d_soluong * d_sothang > tongsl)
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Số lượng xuất lớn hơn số lượng yêu cầu !") , d.Msg);
                            soluong.Focus();
                            return;
                        }

					}
				}
			}
			catch{}
			tinh_giatri();
			if (soluong.Text=="" || soluong.Text=="0.00" || soluong.Text=="0")return;
			upd_table(dtct,false);
			r=d.getrowbyid(dtdmbd,"ma='"+mabd.Text+"'");
			if (r!=null)
			{
				DataTable tmp=d.get_data("select a.*,trim(b.ten)||' '||trim(b.hamluong)||' '||trim(b.dang) as ten,trim(b.ten)||' '||b.hamluong as tenbd,b.dang,b.tenhc,b.ma,b.giaban,b.dongia from "+user+".d_dmbdkemtheo a,"+user+".d_dmbd b where a.mabd=b.id and a.id="+int.Parse(r["id"].ToString())).Tables[0];
				if (tmp.Rows.Count>0)
				{
					string s="";
					foreach(DataRow r1 in tmp.Rows)
					{
						i_mabd=int.Parse(r1["mabd"].ToString());
						d_soluongton=d.get_slton_nguon(dtton,int.Parse(makho.SelectedValue.ToString()),i_mabd,int.Parse(manguon.SelectedValue.ToString()),d_soluongcu);
						if (d_soluong>d_soluongton) s+=r1["ten"].ToString().Trim()+"\n";
                        else d.updrec_ngtruct(dtct, d.get_stt(dtct), 0, i_mabd, r1["ma"].ToString(), r1["tenbd"].ToString(), r1["tenhc"].ToString(), r1["dang"].ToString(), makho.Text, (manguon.SelectedIndex == -1) ? "" : manguon.Text, (nhomcc.SelectedIndex == -1) ? "" : nhomcc.Text, handung.Text, losx.Text, decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["dongia"].ToString()), decimal.Parse(r1["soluong"].ToString()) * decimal.Parse(r1["dongia"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["dongia"].ToString()), decimal.Parse(r1["soluong"].ToString()) * decimal.Parse(r1["giaban"].ToString()), int.Parse(makho.SelectedValue.ToString()), (manguon.SelectedIndex == -1) ? 0 : int.Parse(manguon.SelectedValue.ToString()), (nhomcc.SelectedIndex == -1) ? 0 : int.Parse(nhomcc.SelectedValue.ToString()), dtton, d_soluongcu, d_sotiencu, cachdung.Text,bQuanly_xuatban_theomavach);//d.updrec_ngtruct(dtct,d.get_stt(dtct),0,i_mabd,r1["ma"].ToString(),r1["tenbd"].ToString(),r1["tenhc"].ToString(),r1["dang"].ToString(),makho.Text,(manguon.SelectedIndex==-1)?"":manguon.Text,(nhomcc.SelectedIndex==-1)?"":nhomcc.Text,handung.Text,losx.Text,decimal.Parse(r1["soluong"].ToString()),decimal.Parse(r1["dongia"].ToString()),decimal.Parse(r1["soluong"].ToString())*decimal.Parse(r1["dongia"].ToString()),decimal.Parse(r1["giaban"].ToString()),decimal.Parse(r1["dongia"].ToString()),decimal.Parse(r1["soluong"].ToString())*decimal.Parse(r1["giaban"].ToString()),int.Parse(makho.SelectedValue.ToString()),(manguon.SelectedIndex==-1)?0:int.Parse(manguon.SelectedValue.ToString()),(nhomcc.SelectedIndex==-1)?0:int.Parse(nhomcc.SelectedValue.ToString()),dtton,d_soluongcu,d_sotiencu,cachdung.Text);
                        
					}						 			
					if (bGiaban) tongcong_giaban(dtct);
					else tongcong(dtct);
					sum.Text=d_tongcong.ToString("###,###,###,##0");
					string s_chu=doiso.Doiso_Unicode(Convert.ToInt64(d_tongcong).ToString());
					label14.Text=s_chu;
					if (s!="") MessageBox.Show(lan.Change_language_MessageText("Những mặt hàng sau không đủ tồn")+"\n"+s,d.Msg);
				}
			}
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
                if (!bAdmin && !bHuyxuatban_userthuoc_duocphep)
				{
					MessageBox.Show(lan.Change_language_MessageText("Bạn không có quyền hủy !"),d.Msg);
					return;
				}
                DataRow r_temp = m.get_data("select idttrv,done from " + xxx + ".d_ngtrull where id=" + decimal.Parse(cmbSophieu.SelectedValue.ToString())).Tables[0].Rows[0];
                //DataRow r_temp1 = m.getrowbyid(dtll, "id='" + l_id + "'");
                if (r_temp["done"].ToString()=="1" || r_temp["idttrv"].ToString() != "0")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đơn thuốc đã được cập nhật") + "\n" + lan.Change_language_MessageText("Bạn không có quyền hủy !"), d.Msg);
                    return;
                }
                if (!bThuhoi)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bạn không có quyền hủy !"), d.Msg);
                    return;
                }
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy số phiếu này ?"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
				{
					l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
                    if (bBienlai) d.execute_data("delete from " + xxx + ".d_bienlai where id=" + l_id);
                    itable = d.tableid(s_mmyy, "d_ngtruct");
                    foreach (DataRow r1 in dtct.Rows)
                    {
                        d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                        d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".d_ngtruct", "id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())));
                        d.upd_tonkhoct_xuat(d.delete, s_mmyy, decimal.Parse(r1["sttt"].ToString()), int.Parse(r1["makho"].ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["nhomcc"].ToString()), int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["sotien"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()));
                    }                    

                    itable = d.tableid(s_mmyy, "d_ngtrull");
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".d_ngtrull", "id=" + l_id));
                    d.execute_data("insert into " + xxx + ".d_huybanll(id,nhom,mabn,hoten,namsinh,ngay,mabs,makp,loai,done,userid,ngayud,lanin,sotoa,maql,idduyet) select id,nhom,mabn,hoten,namsinh,ngay,mabs,makp,loai,done,userid,ngayud,lanin,sotoa,maql,idduyet from " + xxx + ".d_ngtrull where id=" + l_id);
                    d.execute_data("insert into " + xxx + ".d_huybanct select * from " + xxx + ".d_ngtruct where id=" + l_id);
                    d.execute_data("delete from " + xxx + ".d_ngtruct where id=" + l_id);
                    d.execute_data("delete from " + xxx + ".d_ngtrull where id=" + l_id);
                    d.execute_data_mmyy("update xxx.d_thuocbhytll set done=0 where idduyet=" + l_id,s_tu,s_den,songayduyet);
                    if(bQuanly_xuatban_theomavach)
                        d.execute_data_mmyy("update xxx.d_thuocbhytll set done=0 where id=" + l_id, s_tu, s_den, songayduyet);
					d.delrec(dtll,"id="+l_id);
					dtll.AcceptChanges();
					cmbSophieu.Refresh();
					try
					{
						if (dtll.Rows.Count>0) cmbSophieu.SelectedIndex=dtll.Rows.Count-1;
					}
					catch{}
                    if (cmbSophieu.Items.Count > 0) l_id = decimal.Parse(cmbSophieu.SelectedValue.ToString());
                    else { l_id = 0; l_id1 = "";}
					load_head(l_id);
					butMoi.Focus();
				}
			}
            catch { }
		}

		private void load_dm()
		{
            if (bQuanly_xuatban_theomavach || bGiaban_theodot)
                dtton = d.get_tonkhoth_dotnhap(s_mmyy, s_makho, s_kho, s_manguon, bTrutonao);
            else dtton = d.get_tonkhoth(s_mmyy, s_makho, s_kho, s_manguon, bTrutonao);
            //
			listDMBD.DataSource=dtton;
            dtcachdung = d.get_data("select ten as stt,ten from " + user + ".d_dmcachdung order by ten").Tables[0];
            listcachdung.DataSource = dtcachdung;
		}
		private void load_tonct()
		{
			dttonct=d.get_tonkhoct(s_mmyy,s_makho,s_kho,s_manguon,i_nhom);
		}

		private void tongcong_giaban(DataTable dt)
		{
			d_tongcong=0;
            foreach (DataRow r1 in dt.Select("soluong>0")) d_tongcong += decimal.Parse(r1["sotienban"].ToString());// and paid=1
		}

		private void tongcong(DataTable dt)
		{
			d_tongcong=0;
			foreach(DataRow r1 in dt.Select("soluong>0 and paid=1")) d_tongcong+=decimal.Parse(r1["sotien"].ToString());
		}

		private void tenkp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDuockp.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listDuockp.Visible)	listDuockp.Focus();
				else SendKeys.Send("{Tab}");
			}
		}

		private void Filter_dmkp(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDuockp.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void tenkp_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenkp)
			{
				Filter_dmkp(tenkp.Text);
				if (mabs.Enabled)
					listDuockp.BrowseToBtdkp(tenkp,makp,mabs);
				else
					listDuockp.BrowseToBtdkp(tenkp,makp,butThem);
			}
		}

		private void tenkp_Validated(object sender, System.EventArgs e)
		{
			if(!listDuockp.Focused) listDuockp.Hide();
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
			SendKeys.Send("{F4}");
		}

		private void loai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (loai.SelectedIndex==-1) loai.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void sophieu_Validated(object sender, System.EventArgs e)
		{
            //if (sophieu.Text=="" || sophieu.Text.Trim().Length<3) return;
            //if (sophieu.Text.Trim().Length != 8) sophieu.Text = sophieu.Text.Substring(0, 2) + sophieu.Text.Substring(2).PadLeft(6,'0');
            if (bNgtru_mabn)
            {
                if (sophieu.Text.Trim().Length != 0)
                {
                    if (sophieu.Text.Trim().Length != i_maxlength_mabn) sophieu.Text = sophieu.Text.Substring(0, 2) + sophieu.Text.Substring(2).PadLeft(6, '0');
                    if (d.get_data("select mabn from " + user + ".btdbn where mabn='" + sophieu.Text.Trim() + "'").Tables[0].Rows.Count == 0)
                    {
                        //MessageBox.Show("Người bệnh này chưa có thông tin, đề nghị nhập lại thông tin người bệnh!");
                        //if (butbnmoi.Enabled) butbnmoi.Focus();
                        //ena_object(false);
                        //return;
                        butbnmoi_Click(sender, e);
                        sophieu.Text = s_mabn_tmp;
                    }
                }
                else
                {
                    butbnmoi_Click(sender, e);
                    sophieu.Text = s_mabn_tmp;
                }
            }
			foreach(DataRow r1 in d.get_data("select a.hoten,a.namsinh,(a.sonha||' '||a.thon||' '||d.tenpxa||' '||c.tenquan||' '||b.tentt) as diachi from "+user+".btdbn a,"+user+".btdtt b,"+user+".btdquan c,"+user+".btdpxa d where a.matt=b.matt(+) and a.maqu=c.maqu(+) and a.maphuongxa=d.maphuongxa(+) and a.mabn='"+sophieu.Text+"'").Tables[0].Rows)
			{
				hoten.Text=r1["hoten"].ToString();
				namsinh.Text=r1["namsinh"].ToString();
                diachi.Text = r1["diachi"].ToString();
                s_mabn = sophieu.Text;
				break;
			}
            if (bQuanly_xuatban_theomavach)//gam 13-06-2011 
            {
                int i_makho = int.Parse(s_kho.Substring(0, s_kho.Length - 1).ToString());
                string sql = "select a.id,a.mabn,a.maql,'' as diachi, a.makp as kp,a.mabs,b.mabd,c.ma,b.slyeucau,";
                sql += "a.chandoan,a.maicd,0 as sotien,a.loaiba,a.songay from xxx.d_thuocbhytll a ";
                sql += "inner join xxx.d_thuocbhytct b on a.id=b.id inner join medibv.d_dmbd c on b.mabd=c.id ";
                sql += " where a.done=0 and to_date(to_char(a.ngay, 'dd/mm/yyyy'), 'dd/mm/yyyy') " + 
                    " between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";
                sql += " and a.nhom=" + i_nhom + " and b.makho=" + i_makho + " and b.paid=1 and b.idttrv <>0 and a.mabn='"+s_mabn+"'";
                //sql += " and a.madoituong=5 ";
                dtToaCT = d.get_data_mmyy(sql,s_tu,s_den,songayduyet).Tables[0];
            }
			if (!bHotennt || !bNamsinhnt) SendKeys.Send("{F4}");

		}

		private void hoten_Validated(object sender, System.EventArgs e)
		{
			if (!bNamsinhnt) SendKeys.Send("{F4}");
		}

		private void mabd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==mabd)
			{
				if (butMoi.Enabled) return;
				Filter_mabd(mabd.Text);
				listDMBD.Tonkhoct_xuatban(mabd,tenbd,soluong,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lTenhc.Width+tenhc.Width+lMabd.Width-45,mabd.Height+5);
			}		
		}

		private void Filter_mabd(string ma)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDMBD.DataSource];
				DataView dv=(DataView)cm.List;
				if (bKytu_traiphai)
				{
					if (bMaso_ten) sql="(soluong>0) and (ma like '"+ma.Trim()+"%' or ten like '"+ma.Trim()+"%' or tenhc like '"+ma.Trim()+"%')";
					else sql="soluong>0 and ma like '"+ma.Trim()+"%'";
				}
				else
				{
					if (bMaso_ten) sql="(soluong>0) and (ma like '%"+ma.Trim()+"%' or ten like '%"+ma.Trim()+"%' or tenhc like '%"+ma.Trim()+"%')";
					else sql="soluong>0 and ma like '%"+ma.Trim()+"%'";
				}
				dv.RowFilter=sql;
			}
			catch{}
		}

		private void tenbs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDMBS.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listDMBS.Visible) listDMBS.Focus();
				else SendKeys.Send("{Tab}");
			}		
		}

		private void tenbs_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbs)
			{
				Filt_dmbs(tenbs.Text);
				if (maicd.Enabled) listDMBS.BrowseToDanhmuc(tenbs,mabs,maicd);
				else listDMBS.BrowseToDanhmuc(tenbs,mabs,butThem);
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

		private void tenbs_Validated(object sender, System.EventArgs e)
		{
			if(!listDMBS.Focused) listDMBS.Hide();
		}

		private void frmXuatban_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F3:
					if(butMoi.Enabled) butMoi_Click(sender,e);
					break;
				case Keys.F6:
					if(butIn.Enabled)butIn_Click(sender,e);
					break;
				case Keys.F5:
					if(butLuu.Enabled)butLuu_Click(sender,e);
					break;
				case Keys.F7:
					if(butDonthuoc.Enabled)butDonthuoc_Click(sender,e);
					break;
				case Keys.F8:
					if(butThem.Enabled) butThem_Click(sender,e);
					break;
				case Keys.F9:
					butTon_Click(sender,e);
					break;
				case Keys.F10:
					if(butKetthuc.Enabled)butKetthuc_Click(sender,e);
					break;
			}
		}

		public void RefreshChildren(string text)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[cmbSophieu.DataSource];
				DataView dv=(DataView)cm.List;			
				dv.RowFilter="hoten like '%"+text.Trim()+"%' or mabn like '%"+text+"%'";
				if(cmbSophieu.SelectedIndex>=0)
				{
					cmbSophieu.SelectedIndex=cmbSophieu.Items.Count-1;
					load_head(decimal.Parse(cmbSophieu.SelectedValue.ToString()));
				}
				else
					load_head(0);
			}
			catch(Exception ex){MessageBox.Show(ex.Message);}
		}

		private void load_head(decimal id)
		{
			try
			{
				l_id=id;
				r=d.getrowbyid(dtll,"id="+l_id);
				DataRow r1;
				if (r!=null)
				{
					chandoan.Text="";maicd.Text="";
					sophieu.Text=r["mabn"].ToString();
                    s_mabn = sophieu.Text;
					hoten.Text=r["hoten"].ToString();
					namsinh.Text=r["namsinh"].ToString();
					ngaysp.Text=r["ngay"].ToString();
					r1=d.getrowbyid(dtduockp,"id="+int.Parse(r["makp"].ToString()));
					if (r1!=null)
					{
						tenkp.Text=r1["ten"].ToString();
						makp.Text=r1["ma"].ToString();
					}
					else
					{
						tenkp.Text="";
						makp.Text="";
					}
					bsma.Text=r["mabs"].ToString();
					r1=d.getrowbyid(dtbs,"ma='"+bsma.Text+"'");
					if (r1!=null)
					{
						tenbs.Text=r1["hoten"].ToString();
						mabs.Text=r1["viettat"].ToString();
					}
					else
					{
						tenbs.Text="";
						mabs.Text="";
					}
					loai.SelectedValue=r["loai"].ToString();
					s_ngaysp=ngaysp.Text;
					tmp_userid=int.Parse(r["userid"].ToString());
					toaso.Text=r["sotoa"].ToString();
                    diachi.Text = r["diachi"].ToString();
                    if (tenbs.Text == "") tenbs.Text = r["ghichu"].ToString();
                    //if (bChandoan)
                    //{
                        foreach (DataRow r2 in d.get_data("select * from " + xxx + ".d_chandoan where id=" + l_id + " and loai=0").Tables[0].Rows)
						{
							chandoan.Text=r2["chandoan"].ToString();
							maicd.Text=r2["maicd"].ToString();
						}
                    //}
					chkBienlai.Checked=false;
					sohieu.Text="";
					sobienlai.Value=0;
					if (bBienlai)
					{
                        foreach (DataRow r2 in d.get_data("select * from " + xxx + ".d_bienlai where id=" + l_id).Tables[0].Rows)
						{
							sohieu.Text=r2["sohieu"].ToString();
							sobienlai.Value=int.Parse(r2["sobienlai"].ToString());
							chkBienlai.Checked=true;
						}
					}
                    songay.Text = r["songay"].ToString();
                    songay.Tag= r["songay"].ToString();
				}
			}
            catch { l_id = 0; l_id1 = ""; }
			load_grid();
			ref_text();
			if (bGiaban) tongcong_giaban(dtct);
			else tongcong(dtct);
			sum.Text=d_tongcong.ToString("###,###,###,##0");
			string s_chu=doiso.Doiso_Unicode(Convert.ToInt64(d_tongcong).ToString());
			label14.Text=s_chu;
		}

		private void butMua_Click(object sender, System.EventArgs e)
		{
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
			if (MessageBox.Show(
lan.Change_language_MessageText("Đồng ý mua thêm nguyên đơn ?"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
				bNew=true;
				dtton=d.get_tonkhoth(s_mmyy,s_makho,s_kho,s_manguon);
				if (!bNgtru_mabn) sophieu.Text=d.get_stt(dtll,"mabn").ToString();
				foreach(DataRow r in dtct.Rows) r["sttt"]=0;
				dtct.AcceptChanges();
				hoten.Text=hoten.Text.Trim()+"(Mua thêm đơn)";
				sttt.Text="0";
				dataGrid1.Focus();
				if (MessageBox.Show(
lan.Change_language_MessageText("Có sửa thuốc không ?"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No)
					butLuu_Click(sender,e);
				else ena_object(true);
			}
		}

		private void listDMBD_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				mabd.Text=listDMBD.Text;
                r = d.getrowbyid(dtton, "stt='" + mabd.Text+"'");//r=d.getrowbyid(dtton,"stt="+int.Parse(mabd.Text));
				if (r!=null)
				{
					mabd.Text=r["ma"].ToString();
					tenbd.Text=r["ten"].ToString();
					tenhc.Text=r["tenhc"].ToString();
					dang.Text=r["dang"].ToString();
					makho.SelectedValue=r["makho"].ToString();
					manguon.SelectedValue=r["manguon"].ToString();
					if (bGiaban)
					{
						d_giaban=decimal.Parse(r["giaban"].ToString());
						giaban.Text=d_giaban.ToString("###,###,###,##0");
					}
                    if (bQuanly_xuatban_theomavach || bGiaban_theodot) sttt.Text = r["stt"].ToString();//theo ma vach
					listDMBD.Hide();
					soluong.Focus();
				}
			}
			catch{}
		}

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void makp_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (makp.Text!="")
				{
					DataRow r1=d.getrowbyid(dtduockp,"ma='"+makp.Text+"'");
					if (r1!=null) tenkp.Text=r1["ten"].ToString();
				}
			}
			catch{}
		}

		private void mabs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void mabs_Validated(object sender, System.EventArgs e)
		{
			if (mabs.Text!="")
			{
				DataRow r1=d.getrowbyid(dtbs,"viettat='"+mabs.Text+"'");
				if (r1!=null)
				{
					tenbs.Text=r1["hoten"].ToString();			
					bsma.Text=r1["ma"].ToString();
					SendKeys.Send("{Tab}");
				}
			}
			else if (!bBacsy) SendKeys.Send("{Tab}");
		}

		private void makp_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			d.MaskDigit(e);
		}

		private void butDonthuoc_Click(object sender, System.EventArgs e)
		{
			frmDuyetdon f=new frmDuyetdon(d,dtll,i_nhom,s_kho,s_ngay,i_userid,s_mmyy,i_quayban,s_makho,s_manguon,s_userid,loai.Text,s_tenkho);
            f.Userid_vp = userid_vp;//Thuy 29.02.2012 .....
            f.ShowDialog(this);
			if (f.bOk)
			{
				dtll=f.dtll;
				dtll.AcceptChanges();
                cmbSophieu.Update();
				cmbSophieu.Refresh();
                if (dtll.Rows.Count > 0)
                {
                    cmbSophieu.SelectedIndex = cmbSophieu.Items.Count - 1;// dtll.Rows.Count - 1;//l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
                    l_id = decimal.Parse(cmbSophieu.SelectedValue.ToString());
                }
                else { l_id = 0; l_id1 = ""; }
				load_head(l_id);
			}
		}
		private void tongcong_n_lien(DataTable dt, int i_lien)
		{
			d_tongcong=0;
			int i=0,j=0;
			foreach(DataRow r1 in dt.Rows) 
			{
				d_tongcong+=decimal.Parse(r1["sotienban"].ToString());
				r1["lien"]=1;
				i+=1;
			}
			if(i_lien>1)
			{
				for(j=i;j<6;j++)
				{
					DataRow lr=dt.NewRow();
					lr["lien"]=1;
					lr["stt"]=j;
					lr["soluong"]=0;
					dt.Rows.Add(lr);
				}			
				DataTable tmpdt=dt.Copy();
				j=0;
				for(int k=2;k<4;k++)
				{				
					foreach(DataRow lr2 in tmpdt.Rows)
					{									
						dt.Rows.Add(lr2.ItemArray);
						dt.Rows[dt.Rows.Count-1]["lien"]=k;
					}				
				}
			}
		}

		private void timkiem_TextChanged(object sender, System.EventArgs e)
		{
			RefreshChildren(timkiem.Text);
		}

		private void timkiem_Enter(object sender, System.EventArgs e)
		{
			timkiem.Text="";
		}

		private void mabd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDMBD.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				sql="ma like '"+mabd.Text.Trim()+"%'";
				DataRow [] dr=dtton.Select(sql);
				if (dr.Length==1)
				{
					mabd.Text=dr[0]["stt"].ToString();
                    get_items(mabd.Text); //get_items(int.Parse(mabd.Text));
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

		private bool get_items(string tt)
		{
			try
			{
				r=d.getrowbyid(dtton,"stt='"+tt+"'");
				if (r!=null)
				{
					mabd.Text=r["ma"].ToString();
					tenbd.Text=r["ten"].ToString();
					tenhc.Text=r["tenhc"].ToString();
					dang.Text=r["dang"].ToString();
					makho.SelectedValue=r["makho"].ToString();
					manguon.SelectedValue=r["manguon"].ToString();
					if (bGiaban)
					{
						d_giaban=decimal.Parse(r["giaban"].ToString());
						giaban.Text=d_giaban.ToString("###,###,###,##0");
					}
                    if (bQuanly_xuatban_theomavach || bGiaban_theodot)
                    {
                        sttt.Text = r["stt"].ToString();//theo ma vach
                    }
                    if (bQuanly_xuatban_theomavach)// gam 13-05-2011 lay len so luong thuoc bn da thanh toan, neu chua thi thong bao.
                    {
                        DataRow rct = d.getrowbyid(dtToaCT, "ma='" + r["ma"].ToString() + "'");
                        if (rct == null)
                        {
                            MessageBox.Show("Thuốc " + r["ma"].ToString() + " chưa đóng tiền !");
                            emp_detail();
                            mavach_sttt.Focus();
                            return false;
                        }
                        soluong.Text = rct["slyeucau"].ToString();
                        if (l_id1.ToString().IndexOf(rct["id"].ToString() + ",") < 0)
                            l_id1 += rct["id"].ToString()+",";
                    }
                    lbldungluc.Text = r["dungluc"].ToString();
                   
				}
			}
			catch{}
            return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!KiemtraHead()) return;
			bool bNew_old=bNew;
			bEdit=false;
			upd_table(dtct,false);
			dtct.AcceptChanges();
			upd_data();
			if (bInphieuxuatban) printer(i_sotoa);
			try
			{
				if (bNew_old && dtll.Rows.Count>0) cmbSophieu.SelectedIndex=dtll.Rows.Count-1;
			}
			catch{}
            if (cmbSophieu.Items.Count > 0) l_id = decimal.Parse(cmbSophieu.SelectedValue.ToString());
            else { l_id = 0; l_id1 = ""; }
			load_head(l_id);
			butMoi.Focus();
		}

		private void upd_data()
		{
			i_old=(bNew)?0:1;
			l_id=(bNew)?d.get_id_xuatban:l_id;
            itable = d.tableid(s_mmyy, "d_ngtrull");
            if (bNew) d.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
            else
            {
                d.upd_eve_tables(s_mmyy, itable, i_userid, "upd");
                d.upd_eve_upd_del(s_mmyy, itable, i_userid, "upd", l_id.ToString() + "^" + i_nhom.ToString() + "^" + sophieu.Text + "^" + hoten.Text + "^" + namsinh.Text + "^" + ngaysp.Text + "^" + bsma.Text + "^" + i_makp.ToString() + "^" + loai.SelectedValue.ToString() + "^" + i_userid.ToString() + "^" + i_sotoa.ToString() + "^" + "0");
            }
			i_sotoa=d.get_sotoa_xuatban(s_mmyy,l_id,i_quayban,ngaysp.Text);
            decimal l_maql = 0;
            if (bXuatban_vienphi && sophieu.Text.Trim().Length == i_maxlength_mabn)
            {
                l_maql = m.get_tiepdon(sophieu.Text, ngaysp.Text);
                if (l_maql == 0)
                {
                    int tuoi = (namsinh.Text != "") ? int.Parse(ngaysp.Text.Substring(6, 4)) - int.Parse(namsinh.Text) : 0;
                    l_maql = m.getidyymmddhhmiss_stt_computer;//m.get_capid(1);
                    string nam = m.get_mabn_nam(sophieu.Text);
                    bool bFound = nam != "";
                    if (nam.IndexOf(s_mmyy + "+") == -1) nam = nam + s_mmyy + "+";
                    if (!bFound)
                        m.upd_btdbn(sophieu.Text, hoten.Text, "", (namsinh.Text != "") ? namsinh.Text : "0000", m.vodanh_gioitinh, m.vodanh_nghenghiep, m.vodanh_dantoc, "", diachi.Text, "", m.vodanh_tinh, m.vodanh_tinh + "00", m.vodanh_tinh + "0000", i_userid, nam);
                    else
                        m.execute_data("update " + user + ".btdbn set nam='" + nam + "' where mabn='" + sophieu.Text + "'");
                    m.upd_lienhe(ngaysp.Text, l_maql, "", diachi.Text, "", m.vodanh_tinh, m.vodanh_tinh + "00", m.vodanh_tinh + "0000", tuoi.ToString().PadLeft(3, '0') + "0", 0, 0);
                    m.upd_tiepdon(sophieu.Text, l_maql, l_maql, "01", ngaysp.Text, 1, "", tuoi.ToString().PadLeft(3, '0') + "0", i_userid, 0, LibMedi.AccessData.Duoc, 0);
                }
                m.upd_sukien(ngaysp.Text, sophieu.Text, l_maql, LibMedi.AccessData.Duoc, l_maql);
            }
			if (!bNgtru_mabn) sophieu.Text=i_sotoa.ToString();
            //
            string s_diachi = diachi.Text;
            string[] adc = diachi.Text.Split('^');
            if (adc.Length > 1) s_diachi = diachi.Text;
            else s_diachi = s_diachi + "^" + tenkp.Text;
            //
            if (!d.upd_ngtrull(s_mmyy, l_id, i_nhom, sophieu.Text, hoten.Text, namsinh.Text, ngaysp.Text, 
                bsma.Text, i_makp, int.Parse(loai.SelectedValue.ToString()), 
                (tmp_userid == i_userid) ? i_userid : tmp_userid, i_sotoa, l_maql, s_diachi, tenbs.Text,userid_vp))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin !"),d.Msg);
				return;
			}
            if (songay.Text != "" && songay.Text.Trim() != "0") d.execute_data("update " + user + s_mmyy + ".d_ngtrull set songay=" + decimal.Parse(songay.Text) + " where id=" + l_id);
			ena_object(false);
            itable = d.tableid(s_mmyy, "d_ngtruct");
			if (!bNew)
			{
				foreach(DataRow r1 in dsxoa.Tables[0].Rows)
				{
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".d_ngtruct", "id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())));
                    d.execute_data("delete from " + xxx + ".d_ngtruct where id=" + l_id + " and stt=" + decimal.Parse(r1["stt"].ToString()));
					//d.upd_tonkhoct_xuat(d.delete,s_mmyy,decimal.Parse(r1["sttt"].ToString()),int.Parse(r1["makho"].ToString()),int.Parse(r1["manguon"].ToString()),int.Parse(r1["nhomcc"].ToString()),int.Parse(r1["mabd"].ToString()),r1["handung"].ToString(),r1["losx"].ToString(),decimal.Parse(r1["soluong"].ToString()),decimal.Parse(r1["sotien"].ToString()),decimal.Parse(r1["giaban"].ToString()),decimal.Parse(r1["giamua"].ToString()));
				}

                foreach (DataRow r1 in dtsave.Rows)
                {
                    d.upd_tonkhoct_xuat(d.delete, s_mmyy, decimal.Parse(r1["sttt"].ToString()), int.Parse(r1["makho"].ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["nhomcc"].ToString()), int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["sotien"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()));
                }
			}
			if (bChandoan) d.upd_chandoan(s_mmyy,l_id,0,maicd.Text,chandoan.Text);

            if (bQuanly_xuatban_theomavach || bGiaban_theodot)//binh 01062011
            {
                dtct = d.get_ngtruct_mavach(s_mmyy, dtct, l_id);
                d.execute_data("update " + d.user + s_mmyy + ".d_ngtruct set madoituong=2 where id="+l_id);// gam 20-06-2011
            }
            else
            {
                dtct = d.get_ngtruct(s_mmyy, dtct, l_id);
                d.execute_data("update " + d.user + s_mmyy + ".d_ngtruct set madoituong=2 where id=" + l_id);// gam 20-06-2011
            }
            if(bQuanly_xuatban_theomavach)
                d.execute_data_mmyy("update xxx.d_thuocbhytll set done=1 where id in (" + l_id1.Trim(',')+")", s_tu, s_den, songayduyet);
            d.updrec_ngtrull_ban(dtll, l_id, sophieu.Text, hoten.Text, namsinh.Text, ngaysp.Text, bsma.Text, i_makp, int.Parse(loai.SelectedValue.ToString()), 0, (tmp_userid != i_userid) ? tmp_userid : i_userid, i_sotoa, 0, diachi.Text, tenbs.Text, (songay.Text != "") ? decimal.Parse(songay.Text) : 0);
			load_grid();
			if (bGiaban) tongcong_giaban(dtct);
			else tongcong(dtct);
			sum.Text=d_tongcong.ToString("###,###,###,##0");
            if (chkBienlai.Checked)
            {
                d.upd_bienlai(s_mmyy, l_id, sohieu.Text, Convert.ToInt32(sobienlai.Value), d_tongcong);
                if (bBienlai_sohieu) m.upd_sobienlai(i_kyhieu, int.Parse(sobienlai.Text));
            }
            else if (!bNew) d.execute_data("delete from " + xxx + ".d_bienlai where id=" + l_id);
			string s_chu=doiso.Doiso_Unicode(Convert.ToInt64(d_tongcong).ToString());
			label14.Text=s_chu;
			label12.Text=dtll.Rows.Count.ToString("###,###");
			toaso.Text=i_sotoa.ToString();
			bNew=false;
			if (bBienlai) v.writeXml("v_thongso","c01",sohieu.Text);
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			if (cmbSophieu.Items.Count==0 || toaso.Text=="") return;
			printer(int.Parse(toaso.Text));
			butMoi_Click(sender,e);
		}

		private void printer(int toa)
		{
			if (dtct.Rows.Count==0) return;
			DataTable dt=d.get_data("select lanin from "+xxx+".d_ngtrull where id="+l_id).Tables[0];
			int lanin=(dt.Rows.Count>0)?int.Parse(dt.Rows[0]["lanin"].ToString()):0;
			if (bInphieuxuatban)
			{
				if (lanin>0)
				{
					lanin++;
					if (lanin>i_solanin)
					{
						MessageBox.Show(lan.Change_language_MessageText("Lần in vượt quá số lần có phép (")+i_solanin.ToString()+")",d.Msg);
						return;
					}
					if (MessageBox.Show(lan.Change_language_MessageText("Lần in thứ")+" "+lanin.ToString()+"\n"+lan.Change_language_MessageText("Bạn có muốn in ?"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No) return;
				}
			}
			DataTable ldt=dtct.Copy();
            ldt.Columns.Add("sothang", typeof(decimal));
            ldt.Columns.Add("sohieu");
            ldt.Columns.Add("sobienlai", typeof(decimal)); 
            ldt.Columns.Add("quayban");
            //ldt.Clear();
			DataRow r1,r2;
			DataRow [] dr;
            string _diachi="", _phai="", _hen = "",sql="";
            decimal gb = 0, stb = 0,gm=0;
            foreach (DataRow dr00 in ldt.Rows)
            {
                dr00["quayban"] = s_tenquay;
            }
            ldt.AcceptChanges();
            //foreach(DataRow r3 in dtct.Select("true"))
            //{
                //gb = (r3["paid"].ToString() == "1") ? decimal.Parse(r3["giaban"].ToString()) : 0;
                //gm = (r3["paid"].ToString() == "1") ? decimal.Parse(r3["giamua"].ToString()) : 0;
                //stb = (r3["paid"].ToString() == "1") ? decimal.Parse(r3["sotienban"].ToString()) : 0;
                //gm = (r3["paid"].ToString() == "1") ? decimal.Parse(r3["giamua"].ToString()) : 0;
                //stb = (r3["paid"].ToString() == "1") ? decimal.Parse(r3["sotienban"].ToString()) : 0;
            //    sql = "mabd=" + int.Parse(r3["mabd"].ToString()) + " and giaban=" + gb + " and paid=" + int.Parse(r3["paid"].ToString())+" and giamua="+gm;
            //    r1=d.getrowbyid(ldt,sql);
            //    if (r1==null)
            //    {
            //        r2=ldt.NewRow();
            //        r2["paid"] = r3["paid"].ToString();
            //        r2["stt"]=r3["stt"].ToString();
            //        r2["mabd"]=r3["mabd"].ToString();
            //        r2["ma"]=r3["ma"].ToString();
            //        r2["ten"]=r3["ten"].ToString();
            //        r2["tenhc"]=r3["tenhc"].ToString();
            //        r2["dang"]=r3["dang"].ToString();
            //        r2["handung"]=r3["handung"].ToString();
            //        r2["losx"]=r3["losx"].ToString();
            //        r2["soluong"]=r3["soluong"].ToString();
            //        r2["giamua"] = gm;
            //        r2["giaban"]=gb;
            //        r2["sotienban"]=stb;
            //        r2["sothang"] = (songay.Text != "" ) ? decimal.Parse(songay.Text) : 0;
            //        r2["sohieu"] = sohieu.Text;
            //        r2["sobienlai"] = sobienlai.Value;
            //        r2["cachdung"] = r3["cachdung"].ToString();
            //        ldt.Rows.Add(r2);
            //    }
            //    else
            //    {
            //        dr=ldt.Select(sql);
            //        if (dr.Length>0)
            //        {
            //            dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())+decimal.Parse(r3["soluong"].ToString());
            //            dr[0]["sotienban"]=decimal.Parse(dr[0]["sotienban"].ToString())+stb;
            //        }
            //    }
            //}
			string ghichu="",stuoi=namsinh.Text,s_chandoan=chandoan.Text.Trim()+";";
			decimal l_maql=0;    
			if (bIncachdung)
			{
				sql="select a.maql,a.ghichu,b.mabd,b.cachdung from xxx.d_thuocbhytll a,xxx.d_thuocbhytct b where a.id=b.id and a.idduyet="+l_id;
				foreach(DataRow r3 in d.get_data_mmyy(sql,s_tu,s_den,songayduyet).Tables[0].Rows)
				{
					r1=d.getrowbyid(ldt,"mabd="+int.Parse(r3["mabd"].ToString()));
					if (r1!=null) r1["tennhomcc"]=r3["cachdung"].ToString();
					ghichu=r3["ghichu"].ToString();
					l_maql=decimal.Parse(r3["maql"].ToString());
				}
                if (l_maql != 0)
                {
                    if (s_chandoan.Trim().Trim(';') == "")
                    {
                        foreach (DataRow r4 in d.get_data_mmyy("select chandoan from xxx.d_chandoan where id=" + l_id, s_tu, s_den, songayduyet).Tables[0].Rows)
                            s_chandoan += r4["chandoan"].ToString() + ";";
                    }
                    foreach (DataRow r3 in d.get_data_mmyy("select chandoan from xxx.cdkemtheo where maql=" + l_maql + " order by stt",s_tu,s_den,songayduyet).Tables[0].Rows)
                        s_chandoan += r3["chandoan"].ToString() + ";";

                    sql = "select a.sonha,a.thon,b.tentt,c.tenquan,d.tenpxa,a.phai,";
                    sql += " case when f.songay is null then 0 else f.songay end as songay,";
                    sql += " case when f.loai is null then 0 else f.loai end as loai,";
                    sql += " case when f.ghichu is null then '' else f.ghichu end as ghichu ";
                    sql += " from " + user + ".btdbn a left join " + user + ".btdtt b on a.matt=b.matt ";
                    sql += " left join " + user + ".btdquan c on a.maqu=c.maqu left join " + user + ".btdpxa d";
                    sql += " on a.maphuongxa=d.maphuongxa left join xxx.benhanpk e on a.mabn=e.mabn ";
                    sql += " left join xxx.hen f on e.maql=f.maql where e.maql=" + l_maql;
                    foreach (DataRow r3 in d.get_data_mmyy(sql,s_tu,s_den,songayduyet).Tables[0].Rows)
                    {
                        _diachi = r3["sonha"].ToString().Trim() + " " + r3["thon"].ToString().Trim() + " " + r3["tenpxa"].ToString().Trim() + " " + r3["tenquan"].ToString().Trim() + " " + r3["tentt"].ToString();
                        if (r3["songay"].ToString() != "0")
                        {
                            _hen = r3["ghichu"].ToString().Trim() + " " + r3["songay"].ToString();
                            switch (int.Parse(r3["loai"].ToString()))
                            {
                                case 0: _hen += " Ngày liên tục"; break;
                                case 1: _hen += " Ngày"; break;
                                case 2: _hen += " Tuần"; break;
                                default: _hen += " Tháng"; break;
                            }
                        }
                        _phai = (r3["phai"].ToString() == "0") ? " Nam" : " Nữ";
                    }
                }
			}
            if (diachi.Text == "" && _diachi != "") diachi.Text = _diachi;
			ldt.Columns.Add("lien");
			int i_lien=1;
			string d_tenrpt=(i_lien>1)?"d_xuatban.rpt":"d_xuatban_a5.rpt";
			string s_c8=(lanin>1 && bInphieuxuatban)?"Lần in thứ "+lanin.ToString():s_tenkho;
			tongcong_n_lien(ldt,i_lien);
			decimal d_sotoa=Convert.ToDecimal(toa);
			tmp_ngaygio=s_ngay+" "+DateTime.Now.Hour.ToString().PadLeft(2,'0')+":"+DateTime.Now.Minute.ToString().PadLeft(2,'0');
			string s_toa=(bNgtru_mabn)?sophieu.Text:d_sotoa.ToString("###,###");
			s_toa+=" ("+tmp_ngaygio+" - "+loai.Text+")";
			toaso.Text=d_sotoa.ToString("###,###");
			sum.Text=d_tongcong.ToString("###,###,###,##0");
			string s_chu=doiso.Doiso_Unicode(Convert.ToInt64(d_tongcong).ToString());
			string lydo=loai.Text;
			r=d.getrowbyid(dtll,"id="+l_id);
			if (r!=null) r["done"]=1;
            d.execute_data("update " + xxx + ".d_ngtrull set lanin=lanin+1,done=1 where id=" + l_id);
            string _hoten = hoten.Text.Trim() + " - " + sophieu.Text;
            string s_diungthuoc = d.f_get_diung(s_mabn);
            if (chkXml.Checked)
            {
                if (!System.IO.Directory.Exists("..//..//dataxml")) System.IO.Directory.CreateDirectory("..//..//dataxml");
               ldt.WriteXml("..\\..\\dataxml\\d_xuatban.xml", XmlWriteMode.WriteSchema);
            }
            int sobanin = d.iSobanin(i_nhom);
			if (chkXem.Checked)
			{
                frmReport f = new frmReport(d, ldt,i_userid, d_tenrpt, s_toa, _hoten, tenbs.Text + "^" + tenkp.Text, stuoi, ngaysp.Text, s_userid + "^" + d_sotoa.ToString("#####"), s_chu, s_c8 + "^" + diachi.Text, ghichu + "^" + _hen, s_chandoan + "^" + _phai + "^" + songay.Text + "^" + s_diungthuoc,sobanin);
				f.ShowDialog();
			}
			else
			{
				try
				{
					ReportDocument oRpt=new ReportDocument();
					oRpt.Load("..\\..\\..\\report\\"+d_tenrpt,OpenReportMethod.OpenReportByTempCopy);
					oRpt.SetDataSource(ldt);
					oRpt.DataDefinition.FormulaFields["soyte"].Text="'"+d.Syte+"'";
					oRpt.DataDefinition.FormulaFields["benhvien"].Text="'"+d.Tenbv+"'";
					oRpt.DataDefinition.FormulaFields["c1"].Text="'"+s_toa+"'";
					oRpt.DataDefinition.FormulaFields["c2"].Text="'"+_hoten+"'";
					oRpt.DataDefinition.FormulaFields["c3"].Text="'"+tenbs.Text+"^"+tenkp.Text+"'";
					oRpt.DataDefinition.FormulaFields["c4"].Text="'"+stuoi+"'";
					oRpt.DataDefinition.FormulaFields["c5"].Text="'"+ngaysp.Text+"'";
                    oRpt.DataDefinition.FormulaFields["c6"].Text = "'" + s_userid + "^" + d_sotoa.ToString("#####") + "'";
					oRpt.DataDefinition.FormulaFields["c7"].Text="'"+s_chu+"'";
					oRpt.DataDefinition.FormulaFields["c8"].Text="'"+s_c8+"'^'"+diachi.Text;
					oRpt.DataDefinition.FormulaFields["c9"].Text="'"+ghichu+"'^'"+_hen;
                    oRpt.DataDefinition.FormulaFields["c10"].Text = "'" + s_chandoan + "'^'" + _phai + "^" + songay.Text + "^" + s_diungthuoc;
					oRpt.DataDefinition.FormulaFields["giamdoc"].Text="";
					oRpt.DataDefinition.FormulaFields["phutrach"].Text="";
					oRpt.DataDefinition.FormulaFields["thongke"].Text="";
					oRpt.DataDefinition.FormulaFields["ketoan"].Text="";
					oRpt.DataDefinition.FormulaFields["thukho"].Text="";
					oRpt.DataDefinition.FormulaFields["l_soluong"].Text=i_soluong_le.ToString();
					oRpt.DataDefinition.FormulaFields["l_dongia"].Text=i_dongia_le.ToString();
					oRpt.DataDefinition.FormulaFields["l_thanhtien"].Text=i_thanhtien_le.ToString();
					//oRpt.PrintOptions.PaperSize=PaperSize.DefaultPaperSize;
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
				catch(Exception ex)
				{
					MessageBox.Show(ex.ToString());
					return;
				}
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

		private void butBienlai_Click(object sender, System.EventArgs e)
		{
			//d_tongcong=(sum.Text!="")?decimal.Parse(sum.Text):0;
            d_tongcong = 0;
            foreach (DataRow r1 in dtct.Select("soluong>0 and paid=1")) d_tongcong += decimal.Parse(r1["sotienban"].ToString());
			if (d_tongcong!=0)
			{
				string lydo="Thanh toán tiền thuốc";
				dsxml.Clear();
				DataRow r1;	
				for(int i=0;i<dslien.Tables[0].Rows.Count;i++)
				{
					r1=dsxml.Tables[0].NewRow();
					r1["syt"]=m.Syte;
					r1["bv"]=m.Tenbv;
					r1["diachibv"]=m.Diachi;
					r1["tongcucthue"]="";
					r1["cucthue"]="";
					r1["masothue"]=v.Masothue;
					r1["mauso"]=v.Mausobienlai;
                    r1["nguoiin"] = diachi.Text;
					r1["ngaysinh"]="'"+namsinh.Text+"'";
					r1["gioitinh"]="";
					r1["quyenso"]=sohieu.Text;
					r1["sobienlai"]=sobienlai.Value.ToString();
					r1["hoten"]=hoten.Text;
					r1["mabn"]=sophieu.Text;
					r1["diachi"]=tenbs.Text;
					r1["khoa"]=tenkp.Text;
					r1["lydo"]=lydo;
					r1["sotien"]=d_tongcong.ToString();
					r1["chutien"]=doiso.Doiso_Unicode(Convert.ToInt64(d_tongcong).ToString());
					r1["diengiai"]=lydo;
					r1["ghichu"]=chandoan.Text;
					r1["ngayin"]=ngaysp.Text.Substring(0,10);
					r1["lien"]=dslien.Tables[0].Rows[i]["ten"].ToString();
					r1["nguoithu"]=s_userid;
					dsxml.Tables[0].Rows.Add(r1);
                }
                if (chkXml.Checked)
                {
                    if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
                    dsxml.WriteXml("..\\xml\\bienlaithuvienphi.xml", XmlWriteMode.WriteSchema);
                }
				if (d.bPreview)
				{
					frmReport f=new frmReport(d,dsxml.Tables[0],i_userid,"","","v_bienlaithuvienphi.rpt");
					f.ShowDialog(this);
				}
				else  print.Printer(d,dsxml,"v_bienlaithuvienphi.rpt","","",0);
				d.upd_bienlai(s_mmyy,l_id,sohieu.Text,Convert.ToInt32( sobienlai.Value),d_tongcong);
			}
		}

		private void sohieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butKTbienlai_Click(object sender, System.EventArgs e)
		{
			pBienlai.Visible=false;
		}

		private void chkBienlai_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==chkBienlai && butLuu.Enabled)
			{
				sohieu.Enabled=chkBienlai.Checked;
				sobienlai.Enabled=chkBienlai.Checked;
			}
		}

		private void butTon_Click(object sender, System.EventArgs e)
		{
			frmXemtonthck2 f=new frmXemtonthck2(d,s_mmyy,i_nhom,s_kho);
			f.ShowDialog();
		}

        private void butSohieu_Click(object sender, EventArgs e)
        {
            frmSohieu f = new frmSohieu();
            f.ShowDialog();
            if (f.iKyhieu != 0)
            {
                sohieu.Text = v.Thongso("c01");
                i_kyhieu = f.iKyhieu;
                sobienlai.Value = m.get_sobienlai(i_kyhieu, 1);
            }
        }

        private void frmXuatban_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (bTinnhan_sound) Clock.Stop();
        }

        private void songay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void songay_Validated(object sender, EventArgs e)
        {
            if (songay.Text.Trim() == "") songay.Text = "1";
            if (!bKho_dongy) return;
            int i_sotoacu = -1;
            try { i_sotoacu = int.Parse(songay.Tag.ToString()); }
            catch { }
            if (i_sotoacu>0)
            {
                foreach (DataRow r1 in dtct.Rows)
                {
                    //d.updrec_ngtruct(dsxoa.Tables[0], int.Parse(r1["stt"].ToString()), decimal.Parse(r1["sttt"].ToString()), int.Parse(r1["mabd"].ToString()), r1["ma"].ToString(), r1["ten"].ToString(), r1["tenhc"].ToString(), r1["dang"].ToString(), r1["tenkho"].ToString(), r1["tennguon"].ToString(), r1["tennhomcc"].ToString(), r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["dongia"].ToString()), decimal.Parse(r1["sotien"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["sotienban"].ToString()), int.Parse(r1["makho"].ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["nhomcc"].ToString()), dtton, 0, 0);
                    r1["soluong"] = decimal.Parse(r1["soluong"].ToString()) * decimal.Parse(songay.Text) / i_sotoacu;
                    r1["sotien"] = decimal.Parse(r1["soluong"].ToString()) * decimal.Parse(r1["dongia"].ToString());
                    r1["sotienban"] = decimal.Parse(r1["soluong"].ToString()) * decimal.Parse(r1["giaban"].ToString());
                    r1["sttt"] = 0;
                }
                dtct.AcceptChanges();
                dataGrid1.Focus();
                emp_detail();
                //dataGrid1.DataSource = dtct;
                //ref_text();
            }
            songay.Tag = songay.Text;
        }

        private bool bDongy(string makho, int dongy)
        {
            sql = "select * from " + user + ".d_dmkho where hide=0 and dongy =" + dongy;
            if (makho != "") sql += " and id in (" + makho.Trim().Trim(',') + ")";
            return m.get_data(sql).Tables[0].Rows.Count > 0;
        }

        private void butGoi_Click(object sender, EventArgs e)
        {
            frmChongoi f = new frmChongoi(-1, i_nhom);
            f.ShowDialog();
            if (f.dt.Rows.Count > 0)
            {
                string s = ""; i_mabd = 0;
                DataRow r1;
                decimal sl;
                foreach (DataRow r in f.dt.Rows)
                {
                    i_mabd = int.Parse(r["mabd"].ToString());
                    if (songay.Enabled) d_sothang = (songay.Text != "") ? decimal.Parse(songay.Text) : 1;
                    else d_sothang = 1;
                    d_soluong=sl = d_sothang * decimal.Parse(r["soluong"].ToString());
                    r1 = m.getrowbyid(dtton, "id=" + i_mabd);
                    if (r1 != null)
                    {
                        d_soluongton = d.get_slton_nguon(dtton, int.Parse(r1["makho"].ToString()), i_mabd, int.Parse(r1["manguon"].ToString()),0);
                        if (d_soluong > d_soluongton)
                        {
                            s += r["ten"].ToString() + " " + r["dang"].ToString() + " (" + d_soluongton.ToString("###,###,###0.000") + ")\n";
                            sl = (d_soluong > d_soluongton) ? d_soluongton : d_soluong;
                        }
                        d.updrec_ngtruct(dtct, d.get_stt(dtct),0, i_mabd,r["ma"].ToString(),r["ten"].ToString(),r["tenhc"].ToString(),r["dang"].ToString(),r1["tenkho"].ToString(),"", "","","",sl,0,0,0,0,0, int.Parse(r1["makho"].ToString()),int.Parse(r1["manguon"].ToString()),0,dtton,0,0,"");
                    }
                }
                if (i_mabd != 0 && s != "")
                    MessageBox.Show(lan.Change_language_MessageText("Những mặt hàng sau không đủ trong tồn \n") + s,LibMedi.AccessData.Msg);
                ref_text();
            }
        }

        private void cachdung_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == cachdung)
            {
                Filter_cachdung(cachdung.Text);
                listcachdung.BrowseToBtdkp(cachdung, cachdung, butThem);
            }
        }
        private void Filter_cachdung(string ten)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[listcachdung.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "ten like '%" + ten.Trim() + "%'";
            }
            catch { }
        }

        private void cachdung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listcachdung.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listcachdung.Visible) listcachdung.Focus();
                else SendKeys.Send("{Tab}");
            }
        }

        private void cachdung_Validated(object sender, EventArgs e)
        {
            if (!listcachdung.Focused) listcachdung.Hide();		
        }

        private void f_load_option()
        {
            bQuanly_xuatban_theomavach = d.bQuanly_xuatban_theomavach(i_nhom);
            label26.Visible = mavach_sttt.Visible = bQuanly_xuatban_theomavach;
            bGiaban_theodot = d.bGiaban_theodot(i_nhom);
            
            i_maxlength_mabn = LibDuoc.AccessData.i_maxlength_mabn;
            //sophieu.MaxLength = i_maxlength_mabn;
            butbnmoi.Visible = bNhathuoc_dkbnmoi;
        }

        private void mavach_sttt_Validated(object sender, EventArgs e)
        {
            string s_sttt = mavach_sttt.Text;
            DataRow r = d.getrowbyid(dtton, "stt=" + s_sttt);
            if(r!=null)
            {
                sttt.Text = r["stt"].ToString();
                mabd.Text = r["ma"].ToString();
                if (!get_items(s_sttt))
                {
                    listDMBD.Hide();
                    return;
                }
                if (tenbd.Text != "") soluong.Focus();
                else if (mabd.Enabled) mabd.Focus();
                else tenbd.Focus();
            }
        }

        private void butbnmoi_Click(object sender, EventArgs e)
        {
            frmSuahc f = new frmSuahc(m, "", i_userid, false, "");
            f.ShowDialog();
            s_mabn_tmp = f.s_mabn;
        }
        //gam 24/08/2011 
        private void f_modify_database()
        {
            string asql = "update "+d.user+".d_dmbd a set a.dongia=b.dongia,a.giaban=b.giaban from (";
            asql += " select mabd,max(giamua) as dongia,max(giaban) as giaban from " + d.user + s_mmyy +".d_theodoi group by mabd ) b where a.id=b.mabd";
            d.execute_data(asql);
        }
        //end gam
        //Thuy 29.02.2012
        bool b_quantri = false;
        public bool Quantri
        {
            set { b_quantri = value; }
        }
        int userid_vp = 0;
        public int Userid_vp
        {
            set { userid_vp = value; }
        }
        //end
	}
}
