using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using gpblib;
using Medisoft.Utilities;
using ProcessImage;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using LibList;

using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
namespace XN
{	
	public class frmGPB : System.Windows.Forms.Form
	{
		#region linh
		DataSet dsbs=new DataSet();
        private gpblib.AccessData k = new gpblib.AccessData();
		bool bCapnhatvp=false;
		int i_mavp;
		decimal dongia=0,vattu=0;
		LibVienphi.AccessData v=new LibVienphi.AccessData();
		#endregion

		byte[] imagenone;
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private DataSet ds,ads,dsChandoan,dsNhuom,dsVtst,dsListVtst,dsListChandoan;
		private byte [] Anh;
		private DateUtil d=new DateUtil();
		Language lan  = new Language();	
		private string file_resize="..\\..\\picture_resize";
		protected string strProgName,user;
		protected string strFileName;
		protected Image image;
		private string m_mabn="",sql="",s_message="",s_sogpb="";
		private decimal s_maql;
		private long l_id=0;
		private int songay=30;
		private int s_loaibn=0;
		private AccessData b = new AccessData();
		private DataTable dtNgayvao=new DataTable();
		private DataTable dtbs=new DataTable();
		private DataTable dtChandoan;
		BindingManagerBase bManager;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPageYEUCAU;
		private System.Windows.Forms.TabPage tabPageXETNGHIEM;
		private System.Windows.Forms.TabPage tabPageDACBIET;
		private System.Windows.Forms.TabPage tabPageKETLUAN;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox textBoxSoGPB;
		private System.Windows.Forms.ComboBox cmbKhoaYC;
		private System.Windows.Forms.TextBox txtKhoaYC;
		private System.Windows.Forms.Label lbVithe;
		private System.Windows.Forms.TextBox txtVithe;
		private System.Windows.Forms.TextBox txtDaithe;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox txtTenBS1;
		private System.Windows.Forms.TextBox txtBanluan;
		private System.Windows.Forms.TextBox txtKetluan;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox txtChandoanlamsang;
		private System.Windows.Forms.TextBox txtVTST1;
		private System.Windows.Forms.Label lbName;
		private System.Windows.Forms.Label lbVTST;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox txtPhuongphapnhuom;
		private System.Windows.Forms.ComboBox cmbPhuongphapnhuom;
		private System.Windows.Forms.ComboBox cmbCuongdo;
		private System.Windows.Forms.CheckBox checkBoxDT;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.CheckBox checkBoxSTTT;
		private System.Windows.Forms.TextBox txtChandoan;
		private System.Windows.Forms.TextBox txtSTTT;
		private System.Windows.Forms.ComboBox cmbSTTT;
		private System.Windows.Forms.TextBox txtTruongkhoa;
		private System.Windows.Forms.ComboBox cmbTruongkhoa;
		private System.Windows.Forms.ComboBox cmbMaBS;
		private System.Windows.Forms.ComboBox cmbMaVTST_DB;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.TextBox txtMaVTSTDB;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.TextBox txtMaVTST;
		private System.Windows.Forms.TextBox txtTile;
		private System.Windows.Forms.TextBox txtGhichu;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.TextBox txtVTST;
		private System.Windows.Forms.CheckBox checkBoxNhuomdacbiet;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.DataGrid dtgAn;
		private System.Windows.Forms.Label lbPath_ofpicture;
		private System.Windows.Forms.PictureBox pictureBoxAnh;
		private System.Windows.Forms.GroupBox grbTim;
		private System.Windows.Forms.Button buttonKetquatim;
		private System.Windows.Forms.TextBox txtTim;
		private System.Windows.Forms.RadioButton rdoSoHS;
		private System.Windows.Forms.RadioButton rdosoGPB;
		private System.Windows.Forms.Button buttonOK_DB_Sua;
		private System.Windows.Forms.Label lbMaHMMD;
		private System.Windows.Forms.Button btnView;
		private MaskedBox.MaskedBox textBoxNgayNhan;
		private MaskedBox.MaskedBox txtNgaytra;
		private System.Windows.Forms.GroupBox groupBox3;
		private MaskedBox.MaskedBox txtNgaySinh;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.ComboBox cbohonhan;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.Button btnBoQua;
		private System.Windows.Forms.Button btnFirst;
		private System.Windows.Forms.Button btnhuy;
		private System.Windows.Forms.Button btnketthuc;
		private System.Windows.Forms.Button btnLast;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnPrevious;
		private System.Windows.Forms.Button btnSua;
		private System.Windows.Forms.Button btnThem;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TreeView treeViewAll;
		private System.Windows.Forms.ComboBox cbophai;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ComboBox cbodantoc;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label ltqx;
		private System.Windows.Forms.Label label5;
		private MaskedTextBox.MaskedTextBox txtmabn1;
		private System.Windows.Forms.TextBox txthoten;
		private System.Windows.Forms.Label lblchuandon;
		private System.Windows.Forms.Button btnLuu;
		private System.Windows.Forms.TextBox txtbacsiyeucau;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label lblnhanpxn;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.Button buttonBacsi;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.DataGrid dtgVTST;
		private MaskedBox.MaskedBox tuoi;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.TextBox tcls;
		private System.Windows.Forms.TextBox nxdt;
		private System.Windows.Forms.TextBox kqst_first;
		private System.Windows.Forms.TextBox qtdt;
		private System.Windows.Forms.ComboBox cmbLoaist;
		private System.Windows.Forms.TextBox txtMaloai;
		private System.Windows.Forms.ComboBox loaibn;
		private MaskedBox.MaskedBox sohs;
		private System.Windows.Forms.ComboBox quan;
		private MaskedBox.MaskedBox para1;
		private MaskedBox.MaskedBox para2;
		private MaskedBox.MaskedBox para3;
		private MaskedBox.MaskedBox para4;
		private System.Windows.Forms.ComboBox tinh;
		private System.Windows.Forms.TextBox txtdiachi;
		private System.Windows.Forms.Label lblSohs;
		private System.Windows.Forms.DataGrid dtgNhuom;
		private System.Windows.Forms.DataGrid dtgChandoan;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label lblIcd;
		private System.Windows.Forms.Button butOk_Cdgpb;
		private System.Windows.Forms.ComboBox ngayvao;
		private System.Windows.Forms.ComboBox mapx;
		private System.Windows.Forms.Button butMinus;
		private System.Windows.Forms.Button butNhuomMiinus;
		private System.Windows.Forms.CheckBox chkNhuom;
		private System.Windows.Forms.Button bMinusVtst;
		private System.Windows.Forms.Label lblTimbn;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.TextBox tenbs;
		private System.Windows.Forms.GroupBox grpPhieumoi;
		private System.Windows.Forms.TextBox listMavtst;
		private LibList.List lb_bs,lstVitrist,lstChandoan;
		private System.Windows.Forms.TextBox listChandoan;
		private bool bNgayht,bUpdate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox tebbsbp;
		private System.Windows.Forms.TextBox mabsbp;
		private System.Windows.Forms.Label label3;
		private MaskedBox.MaskedBox txtngaypha;
		private MaskedBox.MaskedBox txtSomanh;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox mabstb;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox tenbstb;
		private MaskedBox.MaskedBox txtNgaykt;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.CheckBox chkPhuhop;
		private System.Windows.Forms.PictureBox pictureBoxAnh2;
		private System.Windows.Forms.Label buttonLoadHinh;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label lblhotenbn;
		private System.Windows.Forms.DataGrid dtgVTSTDacBiet;
		private System.Windows.Forms.TabPage tabTuychon;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.TextBox txtPath;
		private System.Windows.Forms.Button butChonPath;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.NumericUpDown w;
		private System.Windows.Forms.NumericUpDown h;
        private CheckBox chkXml;
		private System.Windows.Forms.TextBox txtmabn;

		public frmGPB()
		{
			InitializeComponent();
			this.ActiveControl=this.loaibn;
			txtmabn1.Text= DateTime.Now.Year.ToString().Substring(2,2);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGPB));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageYEUCAU = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.listMavtst = new System.Windows.Forms.TextBox();
            this.bMinusVtst = new System.Windows.Forms.Button();
            this.lblIcd = new System.Windows.Forms.Label();
            this.txtMaloai = new System.Windows.Forms.TextBox();
            this.cmbLoaist = new System.Windows.Forms.ComboBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtChandoanlamsang = new System.Windows.Forms.TextBox();
            this.txtVTST1 = new System.Windows.Forms.TextBox();
            this.dtgAn = new System.Windows.Forms.DataGrid();
            this.lbVTST = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtgVTST = new System.Windows.Forms.DataGrid();
            this.lbName = new System.Windows.Forms.Label();
            this.lstVitrist = new LibList.List();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lb_bs = new LibList.List();
            this.label28 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.qtdt = new System.Windows.Forms.TextBox();
            this.kqst_first = new System.Windows.Forms.TextBox();
            this.nxdt = new System.Windows.Forms.TextBox();
            this.tcls = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.treeViewAll = new System.Windows.Forms.TreeView();
            this.grpPhieumoi = new System.Windows.Forms.GroupBox();
            this.textBoxSoGPB = new System.Windows.Forms.TextBox();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtKhoaYC = new System.Windows.Forms.TextBox();
            this.cmbKhoaYC = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxNgayNhan = new MaskedBox.MaskedBox();
            this.txtbacsiyeucau = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.grbTim = new System.Windows.Forms.GroupBox();
            this.rdosoGPB = new System.Windows.Forms.RadioButton();
            this.rdoSoHS = new System.Windows.Forms.RadioButton();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.buttonKetquatim = new System.Windows.Forms.Button();
            this.lblnhanpxn = new System.Windows.Forms.Label();
            this.tabPageXETNGHIEM = new System.Windows.Forms.TabPage();
            this.chkPhuhop = new System.Windows.Forms.CheckBox();
            this.txtNgaykt = new MaskedBox.MaskedBox();
            this.label42 = new System.Windows.Forms.Label();
            this.mabstb = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tenbstb = new System.Windows.Forms.ComboBox();
            this.txtSomanh = new MaskedBox.MaskedBox();
            this.txtngaypha = new MaskedBox.MaskedBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mabsbp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tebbsbp = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDaithe = new System.Windows.Forms.TextBox();
            this.txtVithe = new System.Windows.Forms.TextBox();
            this.lbVithe = new System.Windows.Forms.Label();
            this.tabPageDACBIET = new System.Windows.Forms.TabPage();
            this.dtgVTSTDacBiet = new System.Windows.Forms.DataGrid();
            this.pictureBoxAnh2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxAnh = new System.Windows.Forms.PictureBox();
            this.txtVTST = new System.Windows.Forms.TextBox();
            this.txtMaVTST = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.buttonLoadHinh = new System.Windows.Forms.Label();
            this.chkNhuom = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dtgNhuom = new System.Windows.Forms.DataGrid();
            this.txtGhichu = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.butNhuomMiinus = new System.Windows.Forms.Button();
            this.buttonOK_DB_Sua = new System.Windows.Forms.Button();
            this.cmbCuongdo = new System.Windows.Forms.ComboBox();
            this.txtTile = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtPhuongphapnhuom = new System.Windows.Forms.TextBox();
            this.cmbPhuongphapnhuom = new System.Windows.Forms.ComboBox();
            this.lbMaHMMD = new System.Windows.Forms.Label();
            this.checkBoxDT = new System.Windows.Forms.CheckBox();
            this.checkBoxNhuomdacbiet = new System.Windows.Forms.CheckBox();
            this.lbPath_ofpicture = new System.Windows.Forms.Label();
            this.tabPageKETLUAN = new System.Windows.Forms.TabPage();
            this.cmbMaBS = new System.Windows.Forms.ComboBox();
            this.txtTenBS1 = new System.Windows.Forms.TextBox();
            this.txtMaVTSTDB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listChandoan = new System.Windows.Forms.TextBox();
            this.butMinus = new System.Windows.Forms.Button();
            this.dtgChandoan = new System.Windows.Forms.DataGrid();
            this.label15 = new System.Windows.Forms.Label();
            this.txtNgaytra = new MaskedBox.MaskedBox();
            this.butOk_Cdgpb = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.cmbMaVTST_DB = new System.Windows.Forms.ComboBox();
            this.txtSTTT = new System.Windows.Forms.TextBox();
            this.cmbSTTT = new System.Windows.Forms.ComboBox();
            this.txtChandoan = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtTruongkhoa = new System.Windows.Forms.TextBox();
            this.cmbTruongkhoa = new System.Windows.Forms.ComboBox();
            this.txtBanluan = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblchuandon = new System.Windows.Forms.Label();
            this.txtKetluan = new System.Windows.Forms.TextBox();
            this.lstChandoan = new LibList.List();
            this.label24 = new System.Windows.Forms.Label();
            this.checkBoxSTTT = new System.Windows.Forms.CheckBox();
            this.buttonBacsi = new System.Windows.Forms.Button();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.tabTuychon = new System.Windows.Forms.TabPage();
            this.h = new System.Windows.Forms.NumericUpDown();
            this.w = new System.Windows.Forms.NumericUpDown();
            this.label46 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.butChonPath = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtNgaySinh = new MaskedBox.MaskedBox();
            this.txthoten = new System.Windows.Forms.TextBox();
            this.txtdiachi = new System.Windows.Forms.TextBox();
            this.cbohonhan = new System.Windows.Forms.ComboBox();
            this.cbodantoc = new System.Windows.Forms.ComboBox();
            this.txtmabn = new System.Windows.Forms.TextBox();
            this.mapx = new System.Windows.Forms.ComboBox();
            this.ngayvao = new System.Windows.Forms.ComboBox();
            this.para4 = new MaskedBox.MaskedBox();
            this.para3 = new MaskedBox.MaskedBox();
            this.para2 = new MaskedBox.MaskedBox();
            this.para1 = new MaskedBox.MaskedBox();
            this.tinh = new System.Windows.Forms.ComboBox();
            this.quan = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.sohs = new MaskedBox.MaskedBox();
            this.loaibn = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.tuoi = new MaskedBox.MaskedBox();
            this.txtmabn1 = new MaskedTextBox.MaskedTextBox();
            this.ltqx = new System.Windows.Forms.Label();
            this.cbophai = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblSohs = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.btnhuy = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnketthuc = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnBoQua = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnLuu = new System.Windows.Forms.Button();
            this.label34 = new System.Windows.Forms.Label();
            this.lblTimbn = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblhotenbn = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkXml = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPageYEUCAU.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVTST)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.grpPhieumoi.SuspendLayout();
            this.grbTim.SuspendLayout();
            this.tabPageXETNGHIEM.SuspendLayout();
            this.tabPageDACBIET.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVTSTDacBiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAnh2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAnh)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgNhuom)).BeginInit();
            this.tabPageKETLUAN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgChandoan)).BeginInit();
            this.tabTuychon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.h)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.w)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageYEUCAU);
            this.tabControl1.Controls.Add(this.tabPageXETNGHIEM);
            this.tabControl1.Controls.Add(this.tabPageDACBIET);
            this.tabControl1.Controls.Add(this.tabPageKETLUAN);
            this.tabControl1.Controls.Add(this.tabTuychon);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(8, 200);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1000, 456);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPageYEUCAU
            // 
            this.tabPageYEUCAU.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPageYEUCAU.Controls.Add(this.groupBox5);
            this.tabPageYEUCAU.Controls.Add(this.groupBox2);
            this.tabPageYEUCAU.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageYEUCAU.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPageYEUCAU.Location = new System.Drawing.Point(4, 22);
            this.tabPageYEUCAU.Name = "tabPageYEUCAU";
            this.tabPageYEUCAU.Size = new System.Drawing.Size(992, 430);
            this.tabPageYEUCAU.TabIndex = 0;
            this.tabPageYEUCAU.Text = "Yều cầu";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.listMavtst);
            this.groupBox5.Controls.Add(this.bMinusVtst);
            this.groupBox5.Controls.Add(this.lblIcd);
            this.groupBox5.Controls.Add(this.txtMaloai);
            this.groupBox5.Controls.Add(this.cmbLoaist);
            this.groupBox5.Controls.Add(this.buttonOK);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.txtChandoanlamsang);
            this.groupBox5.Controls.Add(this.txtVTST1);
            this.groupBox5.Controls.Add(this.dtgAn);
            this.groupBox5.Controls.Add(this.lbVTST);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.dtgVTST);
            this.groupBox5.Controls.Add(this.lbName);
            this.groupBox5.Controls.Add(this.lstVitrist);
            this.groupBox5.Font = new System.Drawing.Font("Arial", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(632, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(360, 432);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            // 
            // listMavtst
            // 
            this.listMavtst.BackColor = System.Drawing.SystemColors.HighlightText;
            this.listMavtst.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listMavtst.Location = new System.Drawing.Point(136, 156);
            this.listMavtst.Name = "listMavtst";
            this.listMavtst.Size = new System.Drawing.Size(216, 21);
            this.listMavtst.TabIndex = 1;
            this.listMavtst.TextChanged += new System.EventHandler(this.listMavtst_TextChanged);
            this.listMavtst.Validated += new System.EventHandler(this.listMavtst_Validated);
            this.listMavtst.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listMavtst_KeyDown);
            this.listMavtst.Leave += new System.EventHandler(this.Color_Leave);
            this.listMavtst.Enter += new System.EventHandler(this.Color_Enter);
            // 
            // bMinusVtst
            // 
            this.bMinusVtst.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bMinusVtst.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bMinusVtst.ForeColor = System.Drawing.Color.Red;
            this.bMinusVtst.Image = ((System.Drawing.Image)(resources.GetObject("bMinusVtst.Image")));
            this.bMinusVtst.Location = new System.Drawing.Point(329, 180);
            this.bMinusVtst.Name = "bMinusVtst";
            this.bMinusVtst.Size = new System.Drawing.Size(22, 20);
            this.bMinusVtst.TabIndex = 113;
            this.bMinusVtst.Click += new System.EventHandler(this.bMinusVtst_Click);
            // 
            // lblIcd
            // 
            this.lblIcd.Font = new System.Drawing.Font("Arial", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIcd.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblIcd.Location = new System.Drawing.Point(141, 208);
            this.lblIcd.Name = "lblIcd";
            this.lblIcd.Size = new System.Drawing.Size(128, 16);
            this.lblIcd.TabIndex = 112;
            // 
            // txtMaloai
            // 
            this.txtMaloai.BackColor = System.Drawing.Color.White;
            this.txtMaloai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaloai.Location = new System.Drawing.Point(72, 180);
            this.txtMaloai.Name = "txtMaloai";
            this.txtMaloai.Size = new System.Drawing.Size(30, 21);
            this.txtMaloai.TabIndex = 2;
            this.txtMaloai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaloai_KeyDown);
            // 
            // cmbLoaist
            // 
            this.cmbLoaist.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbLoaist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoaist.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoaist.ItemHeight = 13;
            this.cmbLoaist.Location = new System.Drawing.Point(104, 180);
            this.cmbLoaist.MaxDropDownItems = 25;
            this.cmbLoaist.Name = "cmbLoaist";
            this.cmbLoaist.Size = new System.Drawing.Size(200, 21);
            this.cmbLoaist.TabIndex = 3;
            this.cmbLoaist.SelectedValueChanged += new System.EventHandler(this.cmbLoaist_SelectedValueChanged);
            this.cmbLoaist.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Enter);
            // 
            // buttonOK
            // 
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonOK.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK.Image = ((System.Drawing.Image)(resources.GetObject("buttonOK.Image")));
            this.buttonOK.Location = new System.Drawing.Point(305, 180);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(22, 20);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            this.buttonOK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buttonOK_KeyDown);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label13.Location = new System.Drawing.Point(7, 208);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(128, 16);
            this.label13.TabIndex = 8;
            this.label13.Text = "Chẩn đoán lâm sàng";
            // 
            // txtChandoanlamsang
            // 
            this.txtChandoanlamsang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtChandoanlamsang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChandoanlamsang.Location = new System.Drawing.Point(8, 224);
            this.txtChandoanlamsang.MaxLength = 2000;
            this.txtChandoanlamsang.Multiline = true;
            this.txtChandoanlamsang.Name = "txtChandoanlamsang";
            this.txtChandoanlamsang.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChandoanlamsang.Size = new System.Drawing.Size(352, 200);
            this.txtChandoanlamsang.TabIndex = 4;
            this.txtChandoanlamsang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChandoanlamsang_KeyDown);
            this.txtChandoanlamsang.Leave += new System.EventHandler(this.Color_Leave);
            this.txtChandoanlamsang.Enter += new System.EventHandler(this.Color_Enter);
            // 
            // txtVTST1
            // 
            this.txtVTST1.BackColor = System.Drawing.Color.White;
            this.txtVTST1.Enabled = false;
            this.txtVTST1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVTST1.Location = new System.Drawing.Point(72, 156);
            this.txtVTST1.Name = "txtVTST1";
            this.txtVTST1.Size = new System.Drawing.Size(63, 21);
            this.txtVTST1.TabIndex = 0;
            this.txtVTST1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKhoaYC_KeyDown);
            this.txtVTST1.Leave += new System.EventHandler(this.Color_Leave);
            this.txtVTST1.Enter += new System.EventHandler(this.Color_Enter);
            // 
            // dtgAn
            // 
            this.dtgAn.DataMember = "";
            this.dtgAn.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgAn.Location = new System.Drawing.Point(24, 272);
            this.dtgAn.Name = "dtgAn";
            this.dtgAn.Size = new System.Drawing.Size(8, 8);
            this.dtgAn.TabIndex = 9;
            // 
            // lbVTST
            // 
            this.lbVTST.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVTST.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lbVTST.Location = new System.Drawing.Point(24, 158);
            this.lbVTST.Name = "lbVTST";
            this.lbVTST.Size = new System.Drawing.Size(48, 22);
            this.lbVTST.TabIndex = 6;
            this.lbVTST.Text = "VTST :";
            this.lbVTST.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label7.Location = new System.Drawing.Point(6, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 22);
            this.label7.TabIndex = 7;
            this.label7.Text = "Loại VTST :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtgVTST
            // 
            this.dtgVTST.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dtgVTST.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dtgVTST.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgVTST.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgVTST.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dtgVTST.CaptionVisible = false;
            this.dtgVTST.DataMember = "";
            this.dtgVTST.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgVTST.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dtgVTST.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dtgVTST.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dtgVTST.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dtgVTST.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dtgVTST.LinkColor = System.Drawing.Color.Teal;
            this.dtgVTST.Location = new System.Drawing.Point(8, 32);
            this.dtgVTST.Name = "dtgVTST";
            this.dtgVTST.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dtgVTST.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dtgVTST.ReadOnly = true;
            this.dtgVTST.RowHeaderWidth = 10;
            this.dtgVTST.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dtgVTST.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dtgVTST.Size = new System.Drawing.Size(344, 120);
            this.dtgVTST.TabIndex = 111;
            this.dtgVTST.CurrentCellChanged += new System.EventHandler(this.dtgVTST_CurrentCellChanged);
            // 
            // lbName
            // 
            this.lbName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(8, 16);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(336, 20);
            this.lbName.TabIndex = 12;
            // 
            // lstVitrist
            // 
            this.lstVitrist.BackColor = System.Drawing.SystemColors.Info;
            this.lstVitrist.ColumnCount = 0;
            this.lstVitrist.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstVitrist.Location = new System.Drawing.Point(88, 96);
            this.lstVitrist.MatchBufferTimeOut = 1000;
            this.lstVitrist.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.lstVitrist.Name = "lstVitrist";
            this.lstVitrist.Size = new System.Drawing.Size(240, 17);
            this.lstVitrist.TabIndex = 115;
            this.lstVitrist.TextIndex = -1;
            this.lstVitrist.TextMember = null;
            this.lstVitrist.ValueIndex = -1;
            this.lstVitrist.Visible = false;
            this.lstVitrist.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstVitrist_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lb_bs);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.qtdt);
            this.groupBox2.Controls.Add(this.kqst_first);
            this.groupBox2.Controls.Add(this.nxdt);
            this.groupBox2.Controls.Add(this.tcls);
            this.groupBox2.Controls.Add(this.groupBox9);
            this.groupBox2.Controls.Add(this.grpPhieumoi);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.grbTim);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(624, 432);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // lb_bs
            // 
            this.lb_bs.BackColor = System.Drawing.SystemColors.Info;
            this.lb_bs.ColumnCount = 0;
            this.lb_bs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_bs.Location = new System.Drawing.Point(8, -8);
            this.lb_bs.MatchBufferTimeOut = 1000;
            this.lb_bs.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.lb_bs.Name = "lb_bs";
            this.lb_bs.Size = new System.Drawing.Size(48, 17);
            this.lb_bs.TabIndex = 110;
            this.lb_bs.TextIndex = -1;
            this.lb_bs.TextMember = null;
            this.lb_bs.ValueIndex = -1;
            this.lb_bs.Visible = false;
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label28.Location = new System.Drawing.Point(5, 224);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(93, 48);
            this.label28.TabIndex = 109;
            this.label28.Text = "Nhận xét đại thể khi sinh thiết";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label26.Location = new System.Drawing.Point(5, 168);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(93, 48);
            this.label26.TabIndex = 108;
            this.label26.Text = "Kết qủa sinh thiết tế bào trước đây";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // qtdt
            // 
            this.qtdt.AcceptsReturn = true;
            this.qtdt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.qtdt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtdt.Location = new System.Drawing.Point(99, 296);
            this.qtdt.MaxLength = 2000;
            this.qtdt.Multiline = true;
            this.qtdt.Name = "qtdt";
            this.qtdt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.qtdt.Size = new System.Drawing.Size(517, 128);
            this.qtdt.TabIndex = 4;
            this.qtdt.TextChanged += new System.EventHandler(this.qtdt_TextChanged);
            this.qtdt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_qtdt);
            // 
            // kqst_first
            // 
            this.kqst_first.AcceptsReturn = true;
            this.kqst_first.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kqst_first.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kqst_first.Location = new System.Drawing.Point(99, 168);
            this.kqst_first.MaxLength = 2000;
            this.kqst_first.Multiline = true;
            this.kqst_first.Name = "kqst_first";
            this.kqst_first.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.kqst_first.Size = new System.Drawing.Size(517, 62);
            this.kqst_first.TabIndex = 2;
            this.kqst_first.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kqst_first_KeyDown);
            // 
            // nxdt
            // 
            this.nxdt.AcceptsReturn = true;
            this.nxdt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nxdt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nxdt.Location = new System.Drawing.Point(99, 232);
            this.nxdt.MaxLength = 2000;
            this.nxdt.Multiline = true;
            this.nxdt.Name = "nxdt";
            this.nxdt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.nxdt.Size = new System.Drawing.Size(517, 62);
            this.nxdt.TabIndex = 3;
            this.nxdt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nxdt_KeyDown);
            // 
            // tcls
            // 
            this.tcls.AcceptsReturn = true;
            this.tcls.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tcls.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcls.Location = new System.Drawing.Point(99, 104);
            this.tcls.MaxLength = 2000;
            this.tcls.Multiline = true;
            this.tcls.Name = "tcls";
            this.tcls.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tcls.Size = new System.Drawing.Size(517, 62);
            this.tcls.TabIndex = 1;
            this.tcls.TextChanged += new System.EventHandler(this.tcls_TextChanged);
            this.tcls.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tcls_KeyDown);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.treeViewAll);
            this.groupBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox9.ForeColor = System.Drawing.Color.Navy;
            this.groupBox9.Location = new System.Drawing.Point(400, 8);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(216, 96);
            this.groupBox9.TabIndex = 0;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Các lần GPB_TB";
            // 
            // treeViewAll
            // 
            this.treeViewAll.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewAll.Location = new System.Drawing.Point(4, 17);
            this.treeViewAll.Name = "treeViewAll";
            this.treeViewAll.Size = new System.Drawing.Size(204, 74);
            this.treeViewAll.TabIndex = 15;
            this.treeViewAll.Enter += new System.EventHandler(this.Color_Enter);
            this.treeViewAll.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewAll_AfterSelect);
            this.treeViewAll.Leave += new System.EventHandler(this.Color_Leave);
            // 
            // grpPhieumoi
            // 
            this.grpPhieumoi.Controls.Add(this.textBoxSoGPB);
            this.grpPhieumoi.Controls.Add(this.tenbs);
            this.grpPhieumoi.Controls.Add(this.label9);
            this.grpPhieumoi.Controls.Add(this.label6);
            this.grpPhieumoi.Controls.Add(this.txtKhoaYC);
            this.grpPhieumoi.Controls.Add(this.cmbKhoaYC);
            this.grpPhieumoi.Controls.Add(this.label12);
            this.grpPhieumoi.Controls.Add(this.textBoxNgayNhan);
            this.grpPhieumoi.Controls.Add(this.txtbacsiyeucau);
            this.grpPhieumoi.Controls.Add(this.label8);
            this.grpPhieumoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPhieumoi.ForeColor = System.Drawing.Color.Navy;
            this.grpPhieumoi.Location = new System.Drawing.Point(2, 8);
            this.grpPhieumoi.Name = "grpPhieumoi";
            this.grpPhieumoi.Size = new System.Drawing.Size(398, 96);
            this.grpPhieumoi.TabIndex = 0;
            this.grpPhieumoi.TabStop = false;
            this.grpPhieumoi.Text = "Phiếu mới";
            // 
            // textBoxSoGPB
            // 
            this.textBoxSoGPB.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBoxSoGPB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxSoGPB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSoGPB.Location = new System.Drawing.Point(64, 20);
            this.textBoxSoGPB.MaxLength = 10;
            this.textBoxSoGPB.Name = "textBoxSoGPB";
            this.textBoxSoGPB.Size = new System.Drawing.Size(84, 21);
            this.textBoxSoGPB.TabIndex = 0;
            this.textBoxSoGPB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSoGPB_KeyDown);
            this.textBoxSoGPB.Leave += new System.EventHandler(this.Color_Leave);
            this.textBoxSoGPB.Enter += new System.EventHandler(this.Color_Enter);
            this.textBoxSoGPB.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxSoGPB_Validating);
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(105, 66);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(287, 21);
            this.tenbs.TabIndex = 5;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label9.Location = new System.Drawing.Point(11, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 16);
            this.label9.TabIndex = 106;
            this.label9.Text = "Khoa : ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label6.Location = new System.Drawing.Point(0, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Số GPB : ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtKhoaYC
            // 
            this.txtKhoaYC.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtKhoaYC.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKhoaYC.Location = new System.Drawing.Point(64, 43);
            this.txtKhoaYC.Name = "txtKhoaYC";
            this.txtKhoaYC.Size = new System.Drawing.Size(39, 21);
            this.txtKhoaYC.TabIndex = 2;
            this.txtKhoaYC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKhoaYC_KeyDown);
            this.txtKhoaYC.Leave += new System.EventHandler(this.Color_Leave);
            this.txtKhoaYC.Enter += new System.EventHandler(this.Color_Enter);
            // 
            // cmbKhoaYC
            // 
            this.cmbKhoaYC.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbKhoaYC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKhoaYC.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKhoaYC.Location = new System.Drawing.Point(105, 43);
            this.cmbKhoaYC.MaxDropDownItems = 20;
            this.cmbKhoaYC.Name = "cmbKhoaYC";
            this.cmbKhoaYC.Size = new System.Drawing.Size(287, 21);
            this.cmbKhoaYC.TabIndex = 3;
            this.cmbKhoaYC.SelectedIndexChanged += new System.EventHandler(this.cmbKhoaYC_SelectedIndexChanged);
            this.cmbKhoaYC.Leave += new System.EventHandler(this.Color_Leave);
            this.cmbKhoaYC.Enter += new System.EventHandler(this.Color_Enter);
            this.cmbKhoaYC.Validated += new System.EventHandler(this.cmbKhoaYC_Validated);
            this.cmbKhoaYC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbKhoaYC_KeyDown);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label12.Location = new System.Drawing.Point(1, 70);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 16);
            this.label12.TabIndex = 13;
            this.label12.Text = "Bác sĩ  : ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxNgayNhan
            // 
            this.textBoxNgayNhan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBoxNgayNhan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNgayNhan.Location = new System.Drawing.Point(316, 16);
            this.textBoxNgayNhan.Mask = "##/##/####";
            this.textBoxNgayNhan.Name = "textBoxNgayNhan";
            this.textBoxNgayNhan.Size = new System.Drawing.Size(76, 21);
            this.textBoxNgayNhan.TabIndex = 1;
            this.textBoxNgayNhan.Text = "  /  /    ";
            this.textBoxNgayNhan.Validated += new System.EventHandler(this.textBoxNgayNhan_Validated);
            this.textBoxNgayNhan.Leave += new System.EventHandler(this.Color_Leave);
            this.textBoxNgayNhan.Enter += new System.EventHandler(this.Color_Enter);
            // 
            // txtbacsiyeucau
            // 
            this.txtbacsiyeucau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtbacsiyeucau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbacsiyeucau.Location = new System.Drawing.Point(64, 66);
            this.txtbacsiyeucau.Name = "txtbacsiyeucau";
            this.txtbacsiyeucau.Size = new System.Drawing.Size(39, 21);
            this.txtbacsiyeucau.TabIndex = 4;
            this.txtbacsiyeucau.Validated += new System.EventHandler(this.txtbacsiyeucau_Validated);
            this.txtbacsiyeucau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbacsiyeucau_KeyDown);
            this.txtbacsiyeucau.Leave += new System.EventHandler(this.Color_Leave);
            this.txtbacsiyeucau.Enter += new System.EventHandler(this.Color_Enter);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label8.Location = new System.Drawing.Point(232, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 16);
            this.label8.TabIndex = 105;
            this.label8.Text = "Ngày nhận : ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label25.Location = new System.Drawing.Point(5, 104);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(93, 48);
            this.label25.TabIndex = 1;
            this.label25.Text = "Tóm tắt triệu chứng lâm sàng và XN liên quan";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label29.Location = new System.Drawing.Point(8, 288);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(91, 48);
            this.label29.TabIndex = 110;
            this.label29.Text = "Phương pháp điều trị đã dùng";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grbTim
            // 
            this.grbTim.Controls.Add(this.rdosoGPB);
            this.grbTim.Controls.Add(this.rdoSoHS);
            this.grbTim.Controls.Add(this.txtTim);
            this.grbTim.Controls.Add(this.buttonKetquatim);
            this.grbTim.Controls.Add(this.lblnhanpxn);
            this.grbTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grbTim.ForeColor = System.Drawing.Color.Navy;
            this.grbTim.Location = new System.Drawing.Point(176, 17);
            this.grbTim.Name = "grbTim";
            this.grbTim.Size = new System.Drawing.Size(224, 151);
            this.grbTim.TabIndex = 22;
            this.grbTim.TabStop = false;
            this.grbTim.Text = "TÌM THÔNG TIN";
            this.grbTim.Visible = false;
            // 
            // rdosoGPB
            // 
            this.rdosoGPB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rdosoGPB.ForeColor = System.Drawing.Color.Blue;
            this.rdosoGPB.Location = new System.Drawing.Point(32, 80);
            this.rdosoGPB.Name = "rdosoGPB";
            this.rdosoGPB.Size = new System.Drawing.Size(104, 24);
            this.rdosoGPB.TabIndex = 2;
            this.rdosoGPB.Text = "Theo số GPB";
            this.rdosoGPB.Leave += new System.EventHandler(this.Color_Leave);
            this.rdosoGPB.Enter += new System.EventHandler(this.Color_Enter);
            this.rdosoGPB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdosoGPB_KeyDown);
            // 
            // rdoSoHS
            // 
            this.rdoSoHS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rdoSoHS.ForeColor = System.Drawing.Color.Blue;
            this.rdoSoHS.Location = new System.Drawing.Point(32, 56);
            this.rdoSoHS.Name = "rdoSoHS";
            this.rdoSoHS.Size = new System.Drawing.Size(128, 24);
            this.rdoSoHS.TabIndex = 1;
            this.rdoSoHS.Text = "Theo mã bệnh nhân";
            this.rdoSoHS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdoSoHS_KeyDown);
            // 
            // txtTim
            // 
            this.txtTim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTim.Location = new System.Drawing.Point(16, 24);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(176, 21);
            this.txtTim.TabIndex = 0;
            this.txtTim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTim_KeyDown);
            this.txtTim.Leave += new System.EventHandler(this.Color_Leave);
            this.txtTim.Enter += new System.EventHandler(this.Color_Enter);
            // 
            // buttonKetquatim
            // 
            this.buttonKetquatim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonKetquatim.ForeColor = System.Drawing.Color.Blue;
            this.buttonKetquatim.Location = new System.Drawing.Point(136, 92);
            this.buttonKetquatim.Name = "buttonKetquatim";
            this.buttonKetquatim.Size = new System.Drawing.Size(64, 28);
            this.buttonKetquatim.TabIndex = 3;
            this.buttonKetquatim.Text = "Kết Quả";
            // 
            // lblnhanpxn
            // 
            this.lblnhanpxn.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnhanpxn.ForeColor = System.Drawing.Color.Blue;
            this.lblnhanpxn.Location = new System.Drawing.Point(16, 112);
            this.lblnhanpxn.Name = "lblnhanpxn";
            this.lblnhanpxn.Size = new System.Drawing.Size(200, 32);
            this.lblnhanpxn.TabIndex = 23;
            this.lblnhanpxn.Text = "Phiếu giải phẩu";
            // 
            // tabPageXETNGHIEM
            // 
            this.tabPageXETNGHIEM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPageXETNGHIEM.Controls.Add(this.chkPhuhop);
            this.tabPageXETNGHIEM.Controls.Add(this.txtNgaykt);
            this.tabPageXETNGHIEM.Controls.Add(this.label42);
            this.tabPageXETNGHIEM.Controls.Add(this.mabstb);
            this.tabPageXETNGHIEM.Controls.Add(this.label10);
            this.tabPageXETNGHIEM.Controls.Add(this.tenbstb);
            this.tabPageXETNGHIEM.Controls.Add(this.txtSomanh);
            this.tabPageXETNGHIEM.Controls.Add(this.txtngaypha);
            this.tabPageXETNGHIEM.Controls.Add(this.label4);
            this.tabPageXETNGHIEM.Controls.Add(this.label3);
            this.tabPageXETNGHIEM.Controls.Add(this.mabsbp);
            this.tabPageXETNGHIEM.Controls.Add(this.label2);
            this.tabPageXETNGHIEM.Controls.Add(this.tebbsbp);
            this.tabPageXETNGHIEM.Controls.Add(this.label14);
            this.tabPageXETNGHIEM.Controls.Add(this.txtDaithe);
            this.tabPageXETNGHIEM.Controls.Add(this.txtVithe);
            this.tabPageXETNGHIEM.Controls.Add(this.lbVithe);
            this.tabPageXETNGHIEM.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageXETNGHIEM.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPageXETNGHIEM.Location = new System.Drawing.Point(4, 22);
            this.tabPageXETNGHIEM.Name = "tabPageXETNGHIEM";
            this.tabPageXETNGHIEM.Size = new System.Drawing.Size(992, 430);
            this.tabPageXETNGHIEM.TabIndex = 1;
            this.tabPageXETNGHIEM.Text = "Xét nghiệm";
            // 
            // chkPhuhop
            // 
            this.chkPhuhop.Enabled = false;
            this.chkPhuhop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPhuhop.ForeColor = System.Drawing.SystemColors.WindowText;
            this.chkPhuhop.Location = new System.Drawing.Point(8, 408);
            this.chkPhuhop.Name = "chkPhuhop";
            this.chkPhuhop.Size = new System.Drawing.Size(248, 16);
            this.chkPhuhop.TabIndex = 9;
            this.chkPhuhop.Text = "Phù hợp với chẩn đoán lâm sàng";
            this.chkPhuhop.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tebbsbp_KeyDown);
            // 
            // txtNgaykt
            // 
            this.txtNgaykt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtNgaykt.Enabled = false;
            this.txtNgaykt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgaykt.Location = new System.Drawing.Point(272, 107);
            this.txtNgaykt.Mask = "##/##/####";
            this.txtNgaykt.Name = "txtNgaykt";
            this.txtNgaykt.Size = new System.Drawing.Size(76, 21);
            this.txtNgaykt.TabIndex = 5;
            this.txtNgaykt.Text = "  /  /    ";
            this.txtNgaykt.Validated += new System.EventHandler(this.txtNgaykt_Validated);
            this.txtNgaykt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tebbsbp_KeyDown);
            // 
            // label42
            // 
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label42.Location = new System.Drawing.Point(151, 110);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(136, 16);
            this.label42.TabIndex = 15;
            this.label42.Text = "Ngày làm xong tiêu bản : ";
            // 
            // mabstb
            // 
            this.mabstb.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabstb.Enabled = false;
            this.mabstb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabstb.Location = new System.Drawing.Point(454, 107);
            this.mabstb.Name = "mabstb";
            this.mabstb.Size = new System.Drawing.Size(40, 21);
            this.mabstb.TabIndex = 6;
            this.mabstb.Validated += new System.EventHandler(this.mabstb_Validated);
            this.mabstb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabsbp_KeyDown);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label10.Location = new System.Drawing.Point(354, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 16);
            this.label10.TabIndex = 16;
            this.label10.Text = "Người làm tiêu bản : ";
            // 
            // tenbstb
            // 
            this.tenbstb.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbstb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenbstb.Enabled = false;
            this.tenbstb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbstb.Location = new System.Drawing.Point(496, 107);
            this.tenbstb.Name = "tenbstb";
            this.tenbstb.Size = new System.Drawing.Size(488, 21);
            this.tenbstb.TabIndex = 7;
            this.tenbstb.SelectedIndexChanged += new System.EventHandler(this.tenbstb_SelectedIndexChanged);
            this.tenbstb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tebbsbp_KeyDown);
            // 
            // txtSomanh
            // 
            this.txtSomanh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtSomanh.Enabled = false;
            this.txtSomanh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSomanh.Location = new System.Drawing.Point(944, 8);
            this.txtSomanh.Mask = "##";
            this.txtSomanh.Name = "txtSomanh";
            this.txtSomanh.Size = new System.Drawing.Size(40, 21);
            this.txtSomanh.TabIndex = 3;
            this.txtSomanh.Text = "  ";
            this.txtSomanh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tebbsbp_KeyDown);
            // 
            // txtngaypha
            // 
            this.txtngaypha.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtngaypha.Enabled = false;
            this.txtngaypha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtngaypha.Location = new System.Drawing.Point(792, 8);
            this.txtngaypha.Mask = "##/##/####";
            this.txtngaypha.Name = "txtngaypha";
            this.txtngaypha.Size = new System.Drawing.Size(76, 21);
            this.txtngaypha.TabIndex = 2;
            this.txtngaypha.Text = "  /  /    ";
            this.txtngaypha.Validated += new System.EventHandler(this.txtngaypha_Validated);
            this.txtngaypha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tebbsbp_KeyDown);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(888, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Số mảnh :";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(736, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Ngày pha : ";
            // 
            // mabsbp
            // 
            this.mabsbp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabsbp.Enabled = false;
            this.mabsbp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabsbp.Location = new System.Drawing.Point(272, 8);
            this.mabsbp.Name = "mabsbp";
            this.mabsbp.Size = new System.Drawing.Size(40, 21);
            this.mabsbp.TabIndex = 0;
            this.mabsbp.Validated += new System.EventHandler(this.mabsbp_Validated);
            this.mabsbp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabsbp_KeyDown);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(127, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Người đọc && pha bệnh phẩm : ";
            // 
            // tebbsbp
            // 
            this.tebbsbp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tebbsbp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tebbsbp.Enabled = false;
            this.tebbsbp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tebbsbp.Location = new System.Drawing.Point(314, 8);
            this.tebbsbp.Name = "tebbsbp";
            this.tebbsbp.Size = new System.Drawing.Size(416, 21);
            this.tebbsbp.TabIndex = 1;
            this.tebbsbp.SelectedIndexChanged += new System.EventHandler(this.tebbsbp_SelectedIndexChanged);
            this.tebbsbp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tebbsbp_KeyDown);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label14.Location = new System.Drawing.Point(8, 11);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(127, 16);
            this.label14.TabIndex = 10;
            this.label14.Text = "NHẬN XÉT ĐẠI THỂ";
            // 
            // txtDaithe
            // 
            this.txtDaithe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtDaithe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDaithe.Location = new System.Drawing.Point(8, 32);
            this.txtDaithe.Multiline = true;
            this.txtDaithe.Name = "txtDaithe";
            this.txtDaithe.Size = new System.Drawing.Size(976, 72);
            this.txtDaithe.TabIndex = 4;
            this.txtDaithe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDaithe_KeyDown);
            this.txtDaithe.Leave += new System.EventHandler(this.Color_Leave);
            this.txtDaithe.Enter += new System.EventHandler(this.Color_Enter);
            // 
            // txtVithe
            // 
            this.txtVithe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtVithe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVithe.Location = new System.Drawing.Point(8, 131);
            this.txtVithe.Multiline = true;
            this.txtVithe.Name = "txtVithe";
            this.txtVithe.Size = new System.Drawing.Size(976, 271);
            this.txtVithe.TabIndex = 8;
            this.txtVithe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVithe_KeyDown);
            this.txtVithe.Leave += new System.EventHandler(this.Color_Leave);
            this.txtVithe.Enter += new System.EventHandler(this.Color_Enter);
            // 
            // lbVithe
            // 
            this.lbVithe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVithe.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbVithe.Location = new System.Drawing.Point(8, 110);
            this.lbVithe.Name = "lbVithe";
            this.lbVithe.Size = new System.Drawing.Size(137, 16);
            this.lbVithe.TabIndex = 14;
            this.lbVithe.Text = "NHẬN XÉT VI THỂ";
            // 
            // tabPageDACBIET
            // 
            this.tabPageDACBIET.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPageDACBIET.Controls.Add(this.dtgVTSTDacBiet);
            this.tabPageDACBIET.Controls.Add(this.pictureBoxAnh2);
            this.tabPageDACBIET.Controls.Add(this.pictureBoxAnh);
            this.tabPageDACBIET.Controls.Add(this.txtVTST);
            this.tabPageDACBIET.Controls.Add(this.txtMaVTST);
            this.tabPageDACBIET.Controls.Add(this.label43);
            this.tabPageDACBIET.Controls.Add(this.buttonLoadHinh);
            this.tabPageDACBIET.Controls.Add(this.chkNhuom);
            this.tabPageDACBIET.Controls.Add(this.groupBox6);
            this.tabPageDACBIET.Controls.Add(this.checkBoxNhuomdacbiet);
            this.tabPageDACBIET.Controls.Add(this.lbPath_ofpicture);
            this.tabPageDACBIET.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageDACBIET.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPageDACBIET.Location = new System.Drawing.Point(4, 22);
            this.tabPageDACBIET.Name = "tabPageDACBIET";
            this.tabPageDACBIET.Size = new System.Drawing.Size(992, 430);
            this.tabPageDACBIET.TabIndex = 2;
            this.tabPageDACBIET.Text = "Đặc biệt";
            // 
            // dtgVTSTDacBiet
            // 
            this.dtgVTSTDacBiet.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dtgVTSTDacBiet.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dtgVTSTDacBiet.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgVTSTDacBiet.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgVTSTDacBiet.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dtgVTSTDacBiet.CaptionVisible = false;
            this.dtgVTSTDacBiet.DataMember = "";
            this.dtgVTSTDacBiet.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgVTSTDacBiet.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dtgVTSTDacBiet.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dtgVTSTDacBiet.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dtgVTSTDacBiet.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dtgVTSTDacBiet.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dtgVTSTDacBiet.LinkColor = System.Drawing.Color.Teal;
            this.dtgVTSTDacBiet.Location = new System.Drawing.Point(8, 5);
            this.dtgVTSTDacBiet.Name = "dtgVTSTDacBiet";
            this.dtgVTSTDacBiet.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dtgVTSTDacBiet.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dtgVTSTDacBiet.ReadOnly = true;
            this.dtgVTSTDacBiet.RowHeaderWidth = 10;
            this.dtgVTSTDacBiet.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dtgVTSTDacBiet.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dtgVTSTDacBiet.Size = new System.Drawing.Size(776, 123);
            this.dtgVTSTDacBiet.TabIndex = 117;
            this.dtgVTSTDacBiet.Enter += new System.EventHandler(this.Color_Enter);
            this.dtgVTSTDacBiet.Leave += new System.EventHandler(this.Color_Leave);
            this.dtgVTSTDacBiet.CurrentCellChanged += new System.EventHandler(this.dtgVTSTDacBiet_CurrentCellChanged);
            // 
            // pictureBoxAnh2
            // 
            this.pictureBoxAnh2.BackColor = System.Drawing.Color.White;
            this.pictureBoxAnh2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxAnh2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pictureBoxAnh2.Location = new System.Drawing.Point(792, 224);
            this.pictureBoxAnh2.Name = "pictureBoxAnh2";
            this.pictureBoxAnh2.Size = new System.Drawing.Size(192, 200);
            this.pictureBoxAnh2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxAnh2.TabIndex = 114;
            this.pictureBoxAnh2.TabStop = false;
            // 
            // pictureBoxAnh
            // 
            this.pictureBoxAnh.BackColor = System.Drawing.Color.White;
            this.pictureBoxAnh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxAnh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pictureBoxAnh.Location = new System.Drawing.Point(792, 24);
            this.pictureBoxAnh.Name = "pictureBoxAnh";
            this.pictureBoxAnh.Size = new System.Drawing.Size(192, 184);
            this.pictureBoxAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxAnh.TabIndex = 48;
            this.pictureBoxAnh.TabStop = false;
            // 
            // txtVTST
            // 
            this.txtVTST.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtVTST.Enabled = false;
            this.txtVTST.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVTST.Location = new System.Drawing.Point(184, 152);
            this.txtVTST.Name = "txtVTST";
            this.txtVTST.Size = new System.Drawing.Size(600, 21);
            this.txtVTST.TabIndex = 43;
            this.txtVTST.Leave += new System.EventHandler(this.Color_Leave);
            this.txtVTST.Enter += new System.EventHandler(this.Color_Enter);
            // 
            // txtMaVTST
            // 
            this.txtMaVTST.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtMaVTST.Enabled = false;
            this.txtMaVTST.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaVTST.Location = new System.Drawing.Point(127, 152);
            this.txtMaVTST.Name = "txtMaVTST";
            this.txtMaVTST.Size = new System.Drawing.Size(56, 21);
            this.txtMaVTST.TabIndex = 42;
            this.txtMaVTST.Leave += new System.EventHandler(this.Color_Leave);
            this.txtMaVTST.Enter += new System.EventHandler(this.Color_Enter);
            // 
            // label43
            // 
            this.label43.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(792, 207);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(144, 18);
            this.label43.TabIndex = 116;
            this.label43.Text = "Hình 2";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.label43, "Chọn hình ");
            this.label43.Click += new System.EventHandler(this.label43_Click);
            // 
            // buttonLoadHinh
            // 
            this.buttonLoadHinh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLoadHinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoadHinh.Location = new System.Drawing.Point(792, 6);
            this.buttonLoadHinh.Name = "buttonLoadHinh";
            this.buttonLoadHinh.Size = new System.Drawing.Size(139, 19);
            this.buttonLoadHinh.TabIndex = 115;
            this.buttonLoadHinh.Text = "Hình 1";
            this.buttonLoadHinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.buttonLoadHinh, "Chọn hình ");
            this.buttonLoadHinh.Click += new System.EventHandler(this.buttonLoadHinh_Click_1);
            // 
            // chkNhuom
            // 
            this.chkNhuom.Checked = true;
            this.chkNhuom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNhuom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNhuom.ForeColor = System.Drawing.SystemColors.WindowText;
            this.chkNhuom.Location = new System.Drawing.Point(8, 130);
            this.chkNhuom.Name = "chkNhuom";
            this.chkNhuom.Size = new System.Drawing.Size(128, 24);
            this.chkNhuom.TabIndex = 113;
            this.chkNhuom.Text = "NHUỘM HE";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dtgNhuom);
            this.groupBox6.Controls.Add(this.txtGhichu);
            this.groupBox6.Controls.Add(this.textBox1);
            this.groupBox6.Controls.Add(this.butNhuomMiinus);
            this.groupBox6.Controls.Add(this.buttonOK_DB_Sua);
            this.groupBox6.Controls.Add(this.cmbCuongdo);
            this.groupBox6.Controls.Add(this.txtTile);
            this.groupBox6.Controls.Add(this.label22);
            this.groupBox6.Controls.Add(this.label21);
            this.groupBox6.Controls.Add(this.label20);
            this.groupBox6.Controls.Add(this.label19);
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.Controls.Add(this.txtPhuongphapnhuom);
            this.groupBox6.Controls.Add(this.cmbPhuongphapnhuom);
            this.groupBox6.Controls.Add(this.lbMaHMMD);
            this.groupBox6.Controls.Add(this.checkBoxDT);
            this.groupBox6.Location = new System.Drawing.Point(8, 176);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(776, 248);
            this.groupBox6.TabIndex = 39;
            this.groupBox6.TabStop = false;
            // 
            // dtgNhuom
            // 
            this.dtgNhuom.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dtgNhuom.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dtgNhuom.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dtgNhuom.CaptionBackColor = System.Drawing.SystemColors.ControlLight;
            this.dtgNhuom.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgNhuom.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dtgNhuom.CaptionVisible = false;
            this.dtgNhuom.DataMember = "";
            this.dtgNhuom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgNhuom.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dtgNhuom.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dtgNhuom.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dtgNhuom.HeaderBackColor = System.Drawing.Color.Gainsboro;
            this.dtgNhuom.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dtgNhuom.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dtgNhuom.LinkColor = System.Drawing.Color.Teal;
            this.dtgNhuom.Location = new System.Drawing.Point(2, 7);
            this.dtgNhuom.Name = "dtgNhuom";
            this.dtgNhuom.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dtgNhuom.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dtgNhuom.ReadOnly = true;
            this.dtgNhuom.RowHeaderWidth = 10;
            this.dtgNhuom.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dtgNhuom.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dtgNhuom.Size = new System.Drawing.Size(766, 184);
            this.dtgNhuom.TabIndex = 113;
            this.dtgNhuom.Enter += new System.EventHandler(this.Color_Enter);
            this.dtgNhuom.Leave += new System.EventHandler(this.Color_Leave);
            this.dtgNhuom.CurrentCellChanged += new System.EventHandler(this.dtgNhuom_CurrentCellChanged);
            // 
            // txtGhichu
            // 
            this.txtGhichu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtGhichu.Enabled = false;
            this.txtGhichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhichu.Location = new System.Drawing.Point(337, 216);
            this.txtGhichu.Name = "txtGhichu";
            this.txtGhichu.Size = new System.Drawing.Size(397, 21);
            this.txtGhichu.TabIndex = 5;
            this.txtGhichu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGhichu_KeyDown);
            this.txtGhichu.Leave += new System.EventHandler(this.Color_Leave);
            this.txtGhichu.Enter += new System.EventHandler(this.Color_Enter);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox1.Location = new System.Drawing.Point(325, 200);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(16, 13);
            this.textBox1.TabIndex = 80;
            this.textBox1.Text = "(%)";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // butNhuomMiinus
            // 
            this.butNhuomMiinus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butNhuomMiinus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butNhuomMiinus.ForeColor = System.Drawing.Color.Blue;
            this.butNhuomMiinus.Image = ((System.Drawing.Image)(resources.GetObject("butNhuomMiinus.Image")));
            this.butNhuomMiinus.Location = new System.Drawing.Point(755, 216);
            this.butNhuomMiinus.Name = "butNhuomMiinus";
            this.butNhuomMiinus.Size = new System.Drawing.Size(19, 21);
            this.butNhuomMiinus.TabIndex = 114;
            this.butNhuomMiinus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butNhuomMiinus.Click += new System.EventHandler(this.butNhuomMiinus_Click);
            // 
            // buttonOK_DB_Sua
            // 
            this.buttonOK_DB_Sua.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonOK_DB_Sua.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK_DB_Sua.ForeColor = System.Drawing.Color.Red;
            this.buttonOK_DB_Sua.Image = ((System.Drawing.Image)(resources.GetObject("buttonOK_DB_Sua.Image")));
            this.buttonOK_DB_Sua.Location = new System.Drawing.Point(735, 216);
            this.buttonOK_DB_Sua.Name = "buttonOK_DB_Sua";
            this.buttonOK_DB_Sua.Size = new System.Drawing.Size(19, 21);
            this.buttonOK_DB_Sua.TabIndex = 81;
            this.buttonOK_DB_Sua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonOK_DB_Sua.Click += new System.EventHandler(this.buttonOK_DB_Sua_Click);
            // 
            // cmbCuongdo
            // 
            this.cmbCuongdo.BackColor = System.Drawing.Color.White;
            this.cmbCuongdo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCuongdo.Enabled = false;
            this.cmbCuongdo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCuongdo.ItemHeight = 13;
            this.cmbCuongdo.Items.AddRange(new object[] {
            "Mạnh",
            "Trung Bình",
            "Yếu"});
            this.cmbCuongdo.Location = new System.Drawing.Point(221, 216);
            this.cmbCuongdo.Name = "cmbCuongdo";
            this.cmbCuongdo.Size = new System.Drawing.Size(74, 21);
            this.cmbCuongdo.TabIndex = 3;
            this.cmbCuongdo.Leave += new System.EventHandler(this.Color_Leave);
            this.cmbCuongdo.Enter += new System.EventHandler(this.Color_Enter);
            this.cmbCuongdo.Validated += new System.EventHandler(this.cmbCuongdo_Validated);
            this.cmbCuongdo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCuongdo_KeyDown);
            // 
            // txtTile
            // 
            this.txtTile.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtTile.Enabled = false;
            this.txtTile.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTile.Location = new System.Drawing.Point(296, 216);
            this.txtTile.MaxLength = 3;
            this.txtTile.Name = "txtTile";
            this.txtTile.Size = new System.Drawing.Size(40, 21);
            this.txtTile.TabIndex = 4;
            this.txtTile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTile_KeyDown);
            this.txtTile.Leave += new System.EventHandler(this.Color_Leave);
            this.txtTile.Enter += new System.EventHandler(this.Color_Enter);
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label22.Location = new System.Drawing.Point(222, 200);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(67, 16);
            this.label22.TabIndex = 44;
            this.label22.Text = "CƯỜNG ĐỘ";
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label21.Location = new System.Drawing.Point(352, 200);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(59, 16);
            this.label21.TabIndex = 43;
            this.label21.Text = "GHI CHÚ";
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label20.Location = new System.Drawing.Point(294, 200);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(35, 16);
            this.label20.TabIndex = 42;
            this.label20.Text = "TỈ LỆ";
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label19.Location = new System.Drawing.Point(198, 200);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(24, 16);
            this.label19.TabIndex = 41;
            this.label19.Text = "DT";
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label18.Location = new System.Drawing.Point(7, 200);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(185, 16);
            this.label18.TabIndex = 40;
            this.label18.Text = "PHƯƠNG PHÁP NHUỘM";
            // 
            // txtPhuongphapnhuom
            // 
            this.txtPhuongphapnhuom.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtPhuongphapnhuom.Enabled = false;
            this.txtPhuongphapnhuom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhuongphapnhuom.Location = new System.Drawing.Point(8, 216);
            this.txtPhuongphapnhuom.Name = "txtPhuongphapnhuom";
            this.txtPhuongphapnhuom.Size = new System.Drawing.Size(39, 21);
            this.txtPhuongphapnhuom.TabIndex = 2;
            this.txtPhuongphapnhuom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPhuongphapnhuom_KeyDown);
            this.txtPhuongphapnhuom.Leave += new System.EventHandler(this.Color_Leave);
            this.txtPhuongphapnhuom.Enter += new System.EventHandler(this.Color_Enter);
            // 
            // cmbPhuongphapnhuom
            // 
            this.cmbPhuongphapnhuom.BackColor = System.Drawing.Color.White;
            this.cmbPhuongphapnhuom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPhuongphapnhuom.Enabled = false;
            this.cmbPhuongphapnhuom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPhuongphapnhuom.ItemHeight = 13;
            this.cmbPhuongphapnhuom.Location = new System.Drawing.Point(48, 216);
            this.cmbPhuongphapnhuom.Name = "cmbPhuongphapnhuom";
            this.cmbPhuongphapnhuom.Size = new System.Drawing.Size(146, 21);
            this.cmbPhuongphapnhuom.TabIndex = 1;
            this.cmbPhuongphapnhuom.SelectedIndexChanged += new System.EventHandler(this.cmbPhuongphapnhuom_SelectedIndexChanged);
            this.cmbPhuongphapnhuom.Leave += new System.EventHandler(this.Color_Leave);
            this.cmbPhuongphapnhuom.Enter += new System.EventHandler(this.Color_Enter);
            this.cmbPhuongphapnhuom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmbPhuongphapnhuom_MouseDown);
            this.cmbPhuongphapnhuom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPhuongphapnhuom_KeyDown);
            // 
            // lbMaHMMD
            // 
            this.lbMaHMMD.Location = new System.Drawing.Point(408, 200);
            this.lbMaHMMD.Name = "lbMaHMMD";
            this.lbMaHMMD.Size = new System.Drawing.Size(80, 16);
            this.lbMaHMMD.TabIndex = 82;
            this.lbMaHMMD.Visible = false;
            // 
            // checkBoxDT
            // 
            this.checkBoxDT.Enabled = false;
            this.checkBoxDT.Location = new System.Drawing.Point(200, 216);
            this.checkBoxDT.Name = "checkBoxDT";
            this.checkBoxDT.Size = new System.Drawing.Size(32, 24);
            this.checkBoxDT.TabIndex = 2;
            this.checkBoxDT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.checkBoxDT_KeyDown);
            // 
            // checkBoxNhuomdacbiet
            // 
            this.checkBoxNhuomdacbiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxNhuomdacbiet.ForeColor = System.Drawing.SystemColors.WindowText;
            this.checkBoxNhuomdacbiet.Location = new System.Drawing.Point(8, 152);
            this.checkBoxNhuomdacbiet.Name = "checkBoxNhuomdacbiet";
            this.checkBoxNhuomdacbiet.Size = new System.Drawing.Size(128, 24);
            this.checkBoxNhuomdacbiet.TabIndex = 0;
            this.checkBoxNhuomdacbiet.Text = "NHUỘM ĐẶC BIỆT";
            this.checkBoxNhuomdacbiet.CheckStateChanged += new System.EventHandler(this.checkBoxNhuomdacbiet_CheckStateChanged);
            this.checkBoxNhuomdacbiet.Click += new System.EventHandler(this.checkBoxNhuomdacbiet_Click);
            this.checkBoxNhuomdacbiet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.checkBoxNhuomdacbiet_KeyDown);
            // 
            // lbPath_ofpicture
            // 
            this.lbPath_ofpicture.Location = new System.Drawing.Point(607, 336);
            this.lbPath_ofpicture.Name = "lbPath_ofpicture";
            this.lbPath_ofpicture.Size = new System.Drawing.Size(148, 38);
            this.lbPath_ofpicture.TabIndex = 46;
            this.lbPath_ofpicture.TextChanged += new System.EventHandler(this.lbPath_ofpicture_TextChanged);
            // 
            // tabPageKETLUAN
            // 
            this.tabPageKETLUAN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPageKETLUAN.Controls.Add(this.cmbMaBS);
            this.tabPageKETLUAN.Controls.Add(this.txtTenBS1);
            this.tabPageKETLUAN.Controls.Add(this.txtMaVTSTDB);
            this.tabPageKETLUAN.Controls.Add(this.label1);
            this.tabPageKETLUAN.Controls.Add(this.listChandoan);
            this.tabPageKETLUAN.Controls.Add(this.butMinus);
            this.tabPageKETLUAN.Controls.Add(this.dtgChandoan);
            this.tabPageKETLUAN.Controls.Add(this.label15);
            this.tabPageKETLUAN.Controls.Add(this.txtNgaytra);
            this.tabPageKETLUAN.Controls.Add(this.butOk_Cdgpb);
            this.tabPageKETLUAN.Controls.Add(this.label27);
            this.tabPageKETLUAN.Controls.Add(this.cmbMaVTST_DB);
            this.tabPageKETLUAN.Controls.Add(this.txtSTTT);
            this.tabPageKETLUAN.Controls.Add(this.cmbSTTT);
            this.tabPageKETLUAN.Controls.Add(this.txtChandoan);
            this.tabPageKETLUAN.Controls.Add(this.label23);
            this.tabPageKETLUAN.Controls.Add(this.txtTruongkhoa);
            this.tabPageKETLUAN.Controls.Add(this.cmbTruongkhoa);
            this.tabPageKETLUAN.Controls.Add(this.txtBanluan);
            this.tabPageKETLUAN.Controls.Add(this.label17);
            this.tabPageKETLUAN.Controls.Add(this.label16);
            this.tabPageKETLUAN.Controls.Add(this.lblchuandon);
            this.tabPageKETLUAN.Controls.Add(this.txtKetluan);
            this.tabPageKETLUAN.Controls.Add(this.lstChandoan);
            this.tabPageKETLUAN.Controls.Add(this.label24);
            this.tabPageKETLUAN.Controls.Add(this.checkBoxSTTT);
            this.tabPageKETLUAN.Controls.Add(this.buttonBacsi);
            this.tabPageKETLUAN.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageKETLUAN.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPageKETLUAN.Location = new System.Drawing.Point(4, 22);
            this.tabPageKETLUAN.Name = "tabPageKETLUAN";
            this.tabPageKETLUAN.Size = new System.Drawing.Size(992, 430);
            this.tabPageKETLUAN.TabIndex = 3;
            this.tabPageKETLUAN.Text = "Kết luận";
            // 
            // cmbMaBS
            // 
            this.cmbMaBS.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbMaBS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaBS.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMaBS.Location = new System.Drawing.Point(109, 400);
            this.cmbMaBS.Name = "cmbMaBS";
            this.cmbMaBS.Size = new System.Drawing.Size(246, 21);
            this.cmbMaBS.TabIndex = 12;
            this.cmbMaBS.SelectedIndexChanged += new System.EventHandler(this.cmbMaBS_SelectedIndexChanged);
            this.cmbMaBS.Leave += new System.EventHandler(this.Color_Leave);
            this.cmbMaBS.Enter += new System.EventHandler(this.Color_Enter);
            this.cmbMaBS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMaBS_KeyDown);
            // 
            // txtTenBS1
            // 
            this.txtTenBS1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtTenBS1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenBS1.Location = new System.Drawing.Point(67, 400);
            this.txtTenBS1.Name = "txtTenBS1";
            this.txtTenBS1.Size = new System.Drawing.Size(40, 21);
            this.txtTenBS1.TabIndex = 13;
            this.txtTenBS1.Validated += new System.EventHandler(this.txtTenBS1_Validated);
            this.txtTenBS1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenBS1_KeyDown);
            this.txtTenBS1.Leave += new System.EventHandler(this.Color_Leave);
            this.txtTenBS1.Enter += new System.EventHandler(this.Color_Enter);
            // 
            // txtMaVTSTDB
            // 
            this.txtMaVTSTDB.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtMaVTSTDB.Enabled = false;
            this.txtMaVTSTDB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaVTSTDB.Location = new System.Drawing.Point(64, 179);
            this.txtMaVTSTDB.Name = "txtMaVTSTDB";
            this.txtMaVTSTDB.Size = new System.Drawing.Size(46, 21);
            this.txtMaVTSTDB.TabIndex = 3;
            this.txtMaVTSTDB.Leave += new System.EventHandler(this.Color_Leave);
            this.txtMaVTSTDB.Enter += new System.EventHandler(this.Color_Enter);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(24, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 16);
            this.label1.TabIndex = 116;
            this.label1.Text = "Nhận xét";
            // 
            // listChandoan
            // 
            this.listChandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.listChandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listChandoan.Location = new System.Drawing.Point(488, 179);
            this.listChandoan.Name = "listChandoan";
            this.listChandoan.Size = new System.Drawing.Size(453, 21);
            this.listChandoan.TabIndex = 4;
            this.listChandoan.TextChanged += new System.EventHandler(this.listChandoan_TextChanged);
            this.listChandoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listChandoan_KeyDown);
            // 
            // butMinus
            // 
            this.butMinus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butMinus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butMinus.ForeColor = System.Drawing.Color.Blue;
            this.butMinus.Image = ((System.Drawing.Image)(resources.GetObject("butMinus.Image")));
            this.butMinus.Location = new System.Drawing.Point(963, 179);
            this.butMinus.Name = "butMinus";
            this.butMinus.Size = new System.Drawing.Size(19, 21);
            this.butMinus.TabIndex = 114;
            this.butMinus.Click += new System.EventHandler(this.butMinus_Click);
            // 
            // dtgChandoan
            // 
            this.dtgChandoan.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dtgChandoan.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dtgChandoan.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dtgChandoan.CaptionBackColor = System.Drawing.SystemColors.ControlLight;
            this.dtgChandoan.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgChandoan.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dtgChandoan.CaptionVisible = false;
            this.dtgChandoan.DataMember = "";
            this.dtgChandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgChandoan.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dtgChandoan.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dtgChandoan.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dtgChandoan.HeaderBackColor = System.Drawing.SystemColors.ControlDark;
            this.dtgChandoan.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dtgChandoan.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dtgChandoan.LinkColor = System.Drawing.Color.Teal;
            this.dtgChandoan.Location = new System.Drawing.Point(24, 24);
            this.dtgChandoan.Name = "dtgChandoan";
            this.dtgChandoan.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dtgChandoan.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dtgChandoan.ReadOnly = true;
            this.dtgChandoan.RowHeaderWidth = 10;
            this.dtgChandoan.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dtgChandoan.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dtgChandoan.Size = new System.Drawing.Size(960, 152);
            this.dtgChandoan.TabIndex = 113;
            this.dtgChandoan.Enter += new System.EventHandler(this.Color_Enter);
            this.dtgChandoan.Leave += new System.EventHandler(this.Color_Leave);
            this.dtgChandoan.CurrentCellChanged += new System.EventHandler(this.dtgChandoan_CurrentCellChanged);
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label15.Location = new System.Drawing.Point(5, 404);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 16);
            this.label15.TabIndex = 25;
            this.label15.Text = "Bác sĩ đọc : ";
            // 
            // txtNgaytra
            // 
            this.txtNgaytra.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtNgaytra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgaytra.Location = new System.Drawing.Point(432, 400);
            this.txtNgaytra.Mask = "##/##/####";
            this.txtNgaytra.Name = "txtNgaytra";
            this.txtNgaytra.Size = new System.Drawing.Size(81, 21);
            this.txtNgaytra.TabIndex = 14;
            this.txtNgaytra.Text = "  /  /    ";
            this.txtNgaytra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNgaytra_KeyDown);
            this.txtNgaytra.Leave += new System.EventHandler(this.Color_Leave);
            this.txtNgaytra.Enter += new System.EventHandler(this.Color_Enter);
            this.txtNgaytra.Validating += new System.ComponentModel.CancelEventHandler(this.txtNgaytra_Validating);
            // 
            // butOk_Cdgpb
            // 
            this.butOk_Cdgpb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butOk_Cdgpb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butOk_Cdgpb.ForeColor = System.Drawing.Color.Red;
            this.butOk_Cdgpb.Image = ((System.Drawing.Image)(resources.GetObject("butOk_Cdgpb.Image")));
            this.butOk_Cdgpb.Location = new System.Drawing.Point(943, 179);
            this.butOk_Cdgpb.Name = "butOk_Cdgpb";
            this.butOk_Cdgpb.Size = new System.Drawing.Size(19, 21);
            this.butOk_Cdgpb.TabIndex = 9;
            this.butOk_Cdgpb.Click += new System.EventHandler(this.butOk_Cdgpb_Click);
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label27.Location = new System.Drawing.Point(26, 183);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(38, 16);
            this.label27.TabIndex = 22;
            this.label27.Text = "VTST :";
            // 
            // cmbMaVTST_DB
            // 
            this.cmbMaVTST_DB.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbMaVTST_DB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaVTST_DB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMaVTST_DB.Location = new System.Drawing.Point(112, 179);
            this.cmbMaVTST_DB.Name = "cmbMaVTST_DB";
            this.cmbMaVTST_DB.Size = new System.Drawing.Size(232, 21);
            this.cmbMaVTST_DB.TabIndex = 2;
            this.cmbMaVTST_DB.SelectedIndexChanged += new System.EventHandler(this.cmbMaVTST_DB_SelectedIndexChanged);
            this.cmbMaVTST_DB.Leave += new System.EventHandler(this.Color_Leave);
            this.cmbMaVTST_DB.Enter += new System.EventHandler(this.Color_Enter);
            this.cmbMaVTST_DB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMaVTST_DB_KeyDown);
            // 
            // txtSTTT
            // 
            this.txtSTTT.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSTTT.Enabled = false;
            this.txtSTTT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSTTT.Location = new System.Drawing.Point(488, 179);
            this.txtSTTT.Name = "txtSTTT";
            this.txtSTTT.Size = new System.Drawing.Size(47, 21);
            this.txtSTTT.TabIndex = 8;
            this.txtSTTT.Visible = false;
            this.txtSTTT.Leave += new System.EventHandler(this.Color_Leave);
            this.txtSTTT.Enter += new System.EventHandler(this.Color_Enter);
            // 
            // cmbSTTT
            // 
            this.cmbSTTT.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbSTTT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSTTT.DropDownWidth = 300;
            this.cmbSTTT.Enabled = false;
            this.cmbSTTT.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSTTT.Location = new System.Drawing.Point(584, 179);
            this.cmbSTTT.MaxDropDownItems = 20;
            this.cmbSTTT.Name = "cmbSTTT";
            this.cmbSTTT.Size = new System.Drawing.Size(123, 22);
            this.cmbSTTT.TabIndex = 7;
            this.cmbSTTT.Visible = false;
            this.cmbSTTT.SelectedIndexChanged += new System.EventHandler(this.cmbSTTT_SelectedIndexChanged_1);
            this.cmbSTTT.Leave += new System.EventHandler(this.Color_Leave);
            this.cmbSTTT.Enter += new System.EventHandler(this.Color_Enter);
            this.cmbSTTT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSTTT_KeyDown);
            // 
            // txtChandoan
            // 
            this.txtChandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtChandoan.Enabled = false;
            this.txtChandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChandoan.Location = new System.Drawing.Point(430, 179);
            this.txtChandoan.Name = "txtChandoan";
            this.txtChandoan.Size = new System.Drawing.Size(56, 21);
            this.txtChandoan.TabIndex = 5;
            this.txtChandoan.Validated += new System.EventHandler(this.txtChandoan_Validated);
            this.txtChandoan.Leave += new System.EventHandler(this.Color_Leave);
            this.txtChandoan.Enter += new System.EventHandler(this.Color_Enter);
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label23.Location = new System.Drawing.Point(347, 183);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(101, 16);
            this.label23.TabIndex = 16;
            this.label23.Text = "Chẩn đoán LS  :";
            // 
            // txtTruongkhoa
            // 
            this.txtTruongkhoa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtTruongkhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTruongkhoa.Location = new System.Drawing.Point(606, 400);
            this.txtTruongkhoa.Name = "txtTruongkhoa";
            this.txtTruongkhoa.Size = new System.Drawing.Size(40, 21);
            this.txtTruongkhoa.TabIndex = 15;
            this.txtTruongkhoa.Validated += new System.EventHandler(this.txtTruongkhoa_Validated);
            this.txtTruongkhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTruongkhoa_KeyDown);
            this.txtTruongkhoa.Leave += new System.EventHandler(this.Color_Leave);
            this.txtTruongkhoa.Enter += new System.EventHandler(this.Color_Enter);
            // 
            // cmbTruongkhoa
            // 
            this.cmbTruongkhoa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbTruongkhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTruongkhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTruongkhoa.Location = new System.Drawing.Point(648, 400);
            this.cmbTruongkhoa.Name = "cmbTruongkhoa";
            this.cmbTruongkhoa.Size = new System.Drawing.Size(336, 21);
            this.cmbTruongkhoa.TabIndex = 16;
            this.cmbTruongkhoa.SelectedIndexChanged += new System.EventHandler(this.cmbTruongkhoa_SelectedIndexChanged);
            this.cmbTruongkhoa.Leave += new System.EventHandler(this.Color_Leave);
            this.cmbTruongkhoa.Enter += new System.EventHandler(this.Color_Enter);
            this.cmbTruongkhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbTruongkhoa_KeyDown);
            // 
            // txtBanluan
            // 
            this.txtBanluan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtBanluan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBanluan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBanluan.Location = new System.Drawing.Point(24, 336);
            this.txtBanluan.Multiline = true;
            this.txtBanluan.Name = "txtBanluan";
            this.txtBanluan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBanluan.Size = new System.Drawing.Size(960, 59);
            this.txtBanluan.TabIndex = 11;
            this.txtBanluan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBanluan_KeyDown);
            this.txtBanluan.Leave += new System.EventHandler(this.Color_Leave);
            this.txtBanluan.Enter += new System.EventHandler(this.Color_Enter);
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label17.Location = new System.Drawing.Point(380, 403);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 16);
            this.label17.TabIndex = 4;
            this.label17.Text = "Ngày trả :";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Navy;
            this.label16.Location = new System.Drawing.Point(24, 320);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(176, 16);
            this.label16.TabIndex = 3;
            this.label16.Text = "Chẩn đoán giải phẫu bệnh lý";
            // 
            // lblchuandon
            // 
            this.lblchuandon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblchuandon.ForeColor = System.Drawing.Color.Navy;
            this.lblchuandon.Location = new System.Drawing.Point(24, 8);
            this.lblchuandon.Name = "lblchuandon";
            this.lblchuandon.Size = new System.Drawing.Size(176, 16);
            this.lblchuandon.TabIndex = 2;
            this.lblchuandon.Text = "CHẨN ĐOÁN GIẢI PHẪU BỆNH";
            // 
            // txtKetluan
            // 
            this.txtKetluan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtKetluan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKetluan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKetluan.Location = new System.Drawing.Point(24, 224);
            this.txtKetluan.Multiline = true;
            this.txtKetluan.Name = "txtKetluan";
            this.txtKetluan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtKetluan.Size = new System.Drawing.Size(960, 96);
            this.txtKetluan.TabIndex = 0;
            this.txtKetluan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKetluan_KeyDown);
            this.txtKetluan.Leave += new System.EventHandler(this.txtKetluan_Leave);
            this.txtKetluan.Enter += new System.EventHandler(this.txtKetluan_Enter);
            // 
            // lstChandoan
            // 
            this.lstChandoan.BackColor = System.Drawing.SystemColors.Info;
            this.lstChandoan.ColumnCount = 0;
            this.lstChandoan.Location = new System.Drawing.Point(344, 64);
            this.lstChandoan.MatchBufferTimeOut = 1000;
            this.lstChandoan.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.lstChandoan.Name = "lstChandoan";
            this.lstChandoan.Size = new System.Drawing.Size(408, 17);
            this.lstChandoan.TabIndex = 115;
            this.lstChandoan.TextIndex = -1;
            this.lstChandoan.TextMember = null;
            this.lstChandoan.ValueIndex = -1;
            this.lstChandoan.Visible = false;
            this.lstChandoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstChandoan_KeyDown);
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label24.Location = new System.Drawing.Point(528, 404);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(80, 16);
            this.label24.TabIndex = 26;
            this.label24.Text = "Trưởng khoa : ";
            // 
            // checkBoxSTTT
            // 
            this.checkBoxSTTT.Enabled = false;
            this.checkBoxSTTT.ForeColor = System.Drawing.Color.Blue;
            this.checkBoxSTTT.Location = new System.Drawing.Point(432, 179);
            this.checkBoxSTTT.Name = "checkBoxSTTT";
            this.checkBoxSTTT.Size = new System.Drawing.Size(55, 20);
            this.checkBoxSTTT.TabIndex = 6;
            this.checkBoxSTTT.Text = "STTT";
            this.checkBoxSTTT.Visible = false;
            this.checkBoxSTTT.CheckStateChanged += new System.EventHandler(this.checkBoxSTTT_CheckStateChanged);
            this.checkBoxSTTT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.checkBoxSTTT_KeyDown);
            // 
            // buttonBacsi
            // 
            this.buttonBacsi.ContextMenu = this.contextMenu1;
            this.buttonBacsi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBacsi.ForeColor = System.Drawing.Color.Blue;
            this.buttonBacsi.Location = new System.Drawing.Point(216, 400);
            this.buttonBacsi.Name = "buttonBacsi";
            this.buttonBacsi.Size = new System.Drawing.Size(67, 22);
            this.buttonBacsi.TabIndex = 17;
            this.buttonBacsi.Text = "Chọn khoa";
            this.toolTip1.SetToolTip(this.buttonBacsi, "Bạn Click phải chuột để chọn khoa");
            this.buttonBacsi.Visible = false;
            this.buttonBacsi.Click += new System.EventHandler(this.buttonBacsi_Click);
            // 
            // tabTuychon
            // 
            this.tabTuychon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabTuychon.Controls.Add(this.h);
            this.tabTuychon.Controls.Add(this.w);
            this.tabTuychon.Controls.Add(this.label46);
            this.tabTuychon.Controls.Add(this.label45);
            this.tabTuychon.Controls.Add(this.butChonPath);
            this.tabTuychon.Controls.Add(this.txtPath);
            this.tabTuychon.Controls.Add(this.label44);
            this.tabTuychon.Location = new System.Drawing.Point(4, 22);
            this.tabTuychon.Name = "tabTuychon";
            this.tabTuychon.Size = new System.Drawing.Size(992, 430);
            this.tabTuychon.TabIndex = 4;
            this.tabTuychon.Text = "Tùy chọn";
            // 
            // h
            // 
            this.h.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.h.Location = new System.Drawing.Point(120, 52);
            this.h.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.h.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.h.Name = "h";
            this.h.Size = new System.Drawing.Size(56, 21);
            this.h.TabIndex = 6;
            this.h.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // w
            // 
            this.w.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.w.Location = new System.Drawing.Point(120, 30);
            this.w.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.w.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.w.Name = "w";
            this.w.Size = new System.Drawing.Size(56, 21);
            this.w.TabIndex = 5;
            this.w.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label46
            // 
            this.label46.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(16, 49);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(104, 23);
            this.label46.TabIndex = 4;
            this.label46.Text = "Độ cao hình : ";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label45
            // 
            this.label45.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(16, 29);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(104, 23);
            this.label45.TabIndex = 3;
            this.label45.Text = "Độ rộng hình : ";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butChonPath
            // 
            this.butChonPath.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butChonPath.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butChonPath.Location = new System.Drawing.Point(962, 8);
            this.butChonPath.Name = "butChonPath";
            this.butChonPath.Size = new System.Drawing.Size(24, 21);
            this.butChonPath.TabIndex = 2;
            this.butChonPath.Text = "...";
            this.butChonPath.Click += new System.EventHandler(this.butChonPath_Click);
            // 
            // txtPath
            // 
            this.txtPath.BackColor = System.Drawing.Color.White;
            this.txtPath.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPath.Location = new System.Drawing.Point(120, 8);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(840, 21);
            this.txtPath.TabIndex = 1;
            // 
            // label44
            // 
            this.label44.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(8, 8);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(112, 23);
            this.label44.TabIndex = 0;
            this.label44.Text = "Đường dẩn lưu hình : ";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnView
            // 
            this.btnView.Enabled = false;
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Image = ((System.Drawing.Image)(resources.GetObject("btnView.Image")));
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(596, 664);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(60, 25);
            this.btnView.TabIndex = 9;
            this.btnView.Text = "     &In";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtNgaySinh);
            this.groupBox3.Controls.Add(this.txthoten);
            this.groupBox3.Controls.Add(this.txtdiachi);
            this.groupBox3.Controls.Add(this.cbohonhan);
            this.groupBox3.Controls.Add(this.cbodantoc);
            this.groupBox3.Controls.Add(this.txtmabn);
            this.groupBox3.Controls.Add(this.mapx);
            this.groupBox3.Controls.Add(this.ngayvao);
            this.groupBox3.Controls.Add(this.para4);
            this.groupBox3.Controls.Add(this.para3);
            this.groupBox3.Controls.Add(this.para2);
            this.groupBox3.Controls.Add(this.para1);
            this.groupBox3.Controls.Add(this.tinh);
            this.groupBox3.Controls.Add(this.quan);
            this.groupBox3.Controls.Add(this.label37);
            this.groupBox3.Controls.Add(this.label36);
            this.groupBox3.Controls.Add(this.sohs);
            this.groupBox3.Controls.Add(this.loaibn);
            this.groupBox3.Controls.Add(this.label30);
            this.groupBox3.Controls.Add(this.tuoi);
            this.groupBox3.Controls.Add(this.txtmabn1);
            this.groupBox3.Controls.Add(this.ltqx);
            this.groupBox3.Controls.Add(this.cbophai);
            this.groupBox3.Controls.Add(this.label33);
            this.groupBox3.Controls.Add(this.label32);
            this.groupBox3.Controls.Add(this.label35);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.lblSohs);
            this.groupBox3.Controls.Add(this.label39);
            this.groupBox3.Controls.Add(this.label40);
            this.groupBox3.Controls.Add(this.label41);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label31);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Blue;
            this.groupBox3.Location = new System.Drawing.Point(8, 64);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1000, 107);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // txtNgaySinh
            // 
            this.txtNgaySinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtNgaySinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgaySinh.Location = new System.Drawing.Point(760, 13);
            this.txtNgaySinh.Mask = "####";
            this.txtNgaySinh.Name = "txtNgaySinh";
            this.txtNgaySinh.Size = new System.Drawing.Size(46, 21);
            this.txtNgaySinh.TabIndex = 4;
            this.txtNgaySinh.Text = "    ";
            this.txtNgaySinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNgaySinh_KeyDown);
            this.txtNgaySinh.Leave += new System.EventHandler(this.Color_Leave);
            this.txtNgaySinh.Enter += new System.EventHandler(this.Color_Enter);
            // 
            // txthoten
            // 
            this.txthoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txthoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txthoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txthoten.Location = new System.Drawing.Point(456, 13);
            this.txthoten.Name = "txthoten";
            this.txthoten.Size = new System.Drawing.Size(224, 21);
            this.txthoten.TabIndex = 3;
            this.txthoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txthoten_KeyDown);
            this.txthoten.Leave += new System.EventHandler(this.Color_Leave);
            this.txthoten.Enter += new System.EventHandler(this.Color_Enter);
            // 
            // txtdiachi
            // 
            this.txtdiachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtdiachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdiachi.Location = new System.Drawing.Point(456, 35);
            this.txtdiachi.Name = "txtdiachi";
            this.txtdiachi.Size = new System.Drawing.Size(224, 21);
            this.txtdiachi.TabIndex = 10;
            // 
            // cbohonhan
            // 
            this.cbohonhan.AllowDrop = true;
            this.cbohonhan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbohonhan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbohonhan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbohonhan.Items.AddRange(new object[] {
            "Ðộc thân",
            "Lập gia đình"});
            this.cbohonhan.Location = new System.Drawing.Point(280, 35);
            this.cbohonhan.Name = "cbohonhan";
            this.cbohonhan.Size = new System.Drawing.Size(88, 21);
            this.cbohonhan.TabIndex = 8;
            this.cbohonhan.Leave += new System.EventHandler(this.Color_Leave);
            this.cbohonhan.Enter += new System.EventHandler(this.Color_Enter);
            this.cbohonhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbohonhan_KeyDown);
            // 
            // cbodantoc
            // 
            this.cbodantoc.BackColor = System.Drawing.Color.Snow;
            this.cbodantoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbodantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbodantoc.ItemHeight = 13;
            this.cbodantoc.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cbodantoc.Location = new System.Drawing.Point(64, 35);
            this.cbodantoc.Name = "cbodantoc";
            this.cbodantoc.Size = new System.Drawing.Size(152, 21);
            this.cbodantoc.TabIndex = 7;
            this.cbodantoc.Leave += new System.EventHandler(this.Color_Leave);
            this.cbodantoc.Enter += new System.EventHandler(this.Color_Enter);
            this.cbodantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbodantoc_KeyDown);
            // 
            // txtmabn
            // 
            this.txtmabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmabn.Location = new System.Drawing.Point(305, 13);
            this.txtmabn.MaxLength = 6;
            this.txtmabn.Name = "txtmabn";
            this.txtmabn.Size = new System.Drawing.Size(63, 21);
            this.txtmabn.TabIndex = 2;
            this.txtmabn.Validated += new System.EventHandler(this.txtmabn_Validated);
            this.txtmabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmabn_KeyDown);
            this.txtmabn.Leave += new System.EventHandler(this.Color_Leave);
            this.txtmabn.Enter += new System.EventHandler(this.Color_Enter);
            // 
            // mapx
            // 
            this.mapx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapx.Location = new System.Drawing.Point(280, 57);
            this.mapx.Name = "mapx";
            this.mapx.Size = new System.Drawing.Size(400, 21);
            this.mapx.TabIndex = 37;
            // 
            // ngayvao
            // 
            this.ngayvao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ngayvao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvao.Location = new System.Drawing.Point(64, 79);
            this.ngayvao.Name = "ngayvao";
            this.ngayvao.Size = new System.Drawing.Size(152, 21);
            this.ngayvao.TabIndex = 36;
            this.ngayvao.SelectedIndexChanged += new System.EventHandler(this.ngayvao_SelectedIndexChanged);
            this.ngayvao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngayvao_KeyDown);
            // 
            // para4
            // 
            this.para4.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para4.Location = new System.Drawing.Point(880, 57);
            this.para4.Mask = "####";
            this.para4.Name = "para4";
            this.para4.Size = new System.Drawing.Size(104, 21);
            this.para4.TabIndex = 19;
            this.para4.Text = "    ";
            // 
            // para3
            // 
            this.para3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para3.Location = new System.Drawing.Point(840, 57);
            this.para3.Mask = "####";
            this.para3.Name = "para3";
            this.para3.Size = new System.Drawing.Size(38, 21);
            this.para3.TabIndex = 18;
            this.para3.Text = "    ";
            // 
            // para2
            // 
            this.para2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para2.Location = new System.Drawing.Point(800, 57);
            this.para2.Mask = "####";
            this.para2.Name = "para2";
            this.para2.Size = new System.Drawing.Size(38, 21);
            this.para2.TabIndex = 17;
            this.para2.Text = "    ";
            // 
            // para1
            // 
            this.para1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para1.Location = new System.Drawing.Point(760, 57);
            this.para1.Mask = "####";
            this.para1.Name = "para1";
            this.para1.Size = new System.Drawing.Size(38, 21);
            this.para1.TabIndex = 16;
            this.para1.Text = "    ";
            // 
            // tinh
            // 
            this.tinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tinh.Location = new System.Drawing.Point(64, 57);
            this.tinh.Name = "tinh";
            this.tinh.Size = new System.Drawing.Size(152, 21);
            this.tinh.TabIndex = 13;
            // 
            // quan
            // 
            this.quan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.quan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.quan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quan.Location = new System.Drawing.Point(760, 35);
            this.quan.Name = "quan";
            this.quan.Size = new System.Drawing.Size(224, 21);
            this.quan.TabIndex = 12;
            // 
            // label37
            // 
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label37.Location = new System.Drawing.Point(688, 30);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(80, 23);
            this.label37.TabIndex = 31;
            this.label37.Text = "Quận/Huyện : ";
            this.label37.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label36.Location = new System.Drawing.Point(414, 30);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(64, 22);
            this.label36.TabIndex = 28;
            this.label36.Text = "Địa chỉ : ";
            this.label36.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // sohs
            // 
            this.sohs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sohs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sohs.Location = new System.Drawing.Point(280, 79);
            this.sohs.Mask = "####";
            this.sohs.Name = "sohs";
            this.sohs.Size = new System.Drawing.Size(400, 21);
            this.sohs.TabIndex = 15;
            this.sohs.Text = "    ";
            // 
            // loaibn
            // 
            this.loaibn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaibn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loaibn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaibn.ItemHeight = 13;
            this.loaibn.Items.AddRange(new object[] {
            "Phòng khám",
            "Ngoại trú",
            "Nội trú"});
            this.loaibn.Location = new System.Drawing.Point(64, 13);
            this.loaibn.Name = "loaibn";
            this.loaibn.Size = new System.Drawing.Size(152, 21);
            this.loaibn.TabIndex = 0;
            this.loaibn.SelectedIndexChanged += new System.EventHandler(this.loaibn_SelectedIndexChanged);
            this.loaibn.Leave += new System.EventHandler(this.Color_Leave);
            this.loaibn.Enter += new System.EventHandler(this.Color_Enter);
            this.loaibn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Enter);
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label30.Location = new System.Drawing.Point(9, 8);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(66, 23);
            this.label30.TabIndex = 21;
            this.label30.Text = "Loại BN :";
            this.label30.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // tuoi
            // 
            this.tuoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuoi.Location = new System.Drawing.Point(808, 13);
            this.tuoi.Mask = "####";
            this.tuoi.Name = "tuoi";
            this.tuoi.Size = new System.Drawing.Size(35, 21);
            this.tuoi.TabIndex = 5;
            this.tuoi.Text = "    ";
            // 
            // txtmabn1
            // 
            this.txtmabn1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtmabn1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmabn1.Location = new System.Drawing.Point(280, 13);
            this.txtmabn1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.txtmabn1.MaxLength = 2;
            this.txtmabn1.Name = "txtmabn1";
            this.txtmabn1.Size = new System.Drawing.Size(24, 21);
            this.txtmabn1.TabIndex = 1;
            this.txtmabn1.Validated += new System.EventHandler(this.txtmabn1_Validated);
            this.txtmabn1.Leave += new System.EventHandler(this.Color_Leave);
            this.txtmabn1.Enter += new System.EventHandler(this.Color_Enter);
            // 
            // ltqx
            // 
            this.ltqx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltqx.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ltqx.Location = new System.Drawing.Point(216, 61);
            this.ltqx.Name = "ltqx";
            this.ltqx.Size = new System.Drawing.Size(72, 14);
            this.ltqx.TabIndex = 30;
            this.ltqx.Text = "Phường xã : ";
            this.ltqx.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cbophai
            // 
            this.cbophai.BackColor = System.Drawing.Color.Snow;
            this.cbophai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbophai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbophai.ItemHeight = 13;
            this.cbophai.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cbophai.Location = new System.Drawing.Point(912, 13);
            this.cbophai.Name = "cbophai";
            this.cbophai.Size = new System.Drawing.Size(72, 21);
            this.cbophai.TabIndex = 6;
            this.cbophai.Leave += new System.EventHandler(this.Color_Leave);
            this.cbophai.Enter += new System.EventHandler(this.Color_Enter);
            this.cbophai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbophai_KeyDown);
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label33.Location = new System.Drawing.Point(865, 8);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(56, 22);
            this.label33.TabIndex = 25;
            this.label33.Text = "Giới tính : ";
            this.label33.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label32.Location = new System.Drawing.Point(709, 18);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(60, 13);
            this.label32.TabIndex = 24;
            this.label32.Text = "NS/ Tuổi : ";
            this.label32.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label35
            // 
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label35.Location = new System.Drawing.Point(414, 9);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(45, 22);
            this.label35.TabIndex = 23;
            this.label35.Text = "Họ tên :";
            this.label35.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label11.Location = new System.Drawing.Point(10, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 23);
            this.label11.TabIndex = 26;
            this.label11.Text = "Dân tộc : ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblSohs
            // 
            this.lblSohs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSohs.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblSohs.Location = new System.Drawing.Point(209, 77);
            this.lblSohs.Name = "lblSohs";
            this.lblSohs.Size = new System.Drawing.Size(76, 22);
            this.lblSohs.TabIndex = 34;
            this.lblSohs.Text = "Số hồ sơ : ";
            this.lblSohs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label39
            // 
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label39.Location = new System.Drawing.Point(7, 51);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(64, 23);
            this.label39.TabIndex = 32;
            this.label39.Text = "Tỉnh/Tp : ";
            this.label39.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label40
            // 
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label40.Location = new System.Drawing.Point(6, 76);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(80, 21);
            this.label40.TabIndex = 33;
            this.label40.Text = "Ngày vào : ";
            this.label40.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label41
            // 
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label41.Location = new System.Drawing.Point(718, 54);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(48, 22);
            this.label41.TabIndex = 0;
            this.label41.Text = "Para : ";
            this.label41.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(241, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 22);
            this.label5.TabIndex = 22;
            this.label5.Text = "Mã BN :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.toolTip1.SetToolTip(this.label5, "Số hồ sơ bệnh nhân");
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label31.Location = new System.Drawing.Point(220, 29);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(64, 23);
            this.label31.TabIndex = 27;
            this.label31.Text = "Tình trạng :";
            this.label31.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label38
            // 
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label38.Location = new System.Drawing.Point(8, 178);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(144, 16);
            this.label38.TabIndex = 207;
            this.label38.Text = "II.GIẢI PHẪU BỆNH";
            // 
            // btnhuy
            // 
            this.btnhuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnhuy.Image = ((System.Drawing.Image)(resources.GetObject("btnhuy.Image")));
            this.btnhuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnhuy.Location = new System.Drawing.Point(535, 664);
            this.btnhuy.Name = "btnhuy";
            this.btnhuy.Size = new System.Drawing.Size(60, 25);
            this.btnhuy.TabIndex = 7;
            this.btnhuy.Text = "      &Hủy";
            this.toolTip1.SetToolTip(this.btnhuy, "Huỷ Giải Phẩu bệnh");
            this.btnhuy.Click += new System.EventHandler(this.btnhuy_Click);
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Location = new System.Drawing.Point(80, 696);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(32, 32);
            this.btnNext.TabIndex = 202;
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Visible = false;
            // 
            // btnketthuc
            // 
            this.btnketthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnketthuc.Image = ((System.Drawing.Image)(resources.GetObject("btnketthuc.Image")));
            this.btnketthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnketthuc.Location = new System.Drawing.Point(657, 664);
            this.btnketthuc.Name = "btnketthuc";
            this.btnketthuc.Size = new System.Drawing.Size(68, 25);
            this.btnketthuc.TabIndex = 8;
            this.btnketthuc.Text = "Kết thúc";
            this.btnketthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnketthuc.Click += new System.EventHandler(this.btnketthuc_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Enabled = false;
            this.btnFirst.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirst.ForeColor = System.Drawing.Color.Red;
            this.btnFirst.Image = ((System.Drawing.Image)(resources.GetObject("btnFirst.Image")));
            this.btnFirst.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFirst.Location = new System.Drawing.Point(16, 696);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(32, 32);
            this.btnFirst.TabIndex = 204;
            this.btnFirst.Text = "|";
            this.btnFirst.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFirst.Visible = false;
            // 
            // btnLast
            // 
            this.btnLast.Enabled = false;
            this.btnLast.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLast.ForeColor = System.Drawing.Color.Red;
            this.btnLast.Image = ((System.Drawing.Image)(resources.GetObject("btnLast.Image")));
            this.btnLast.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLast.Location = new System.Drawing.Point(112, 696);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(32, 32);
            this.btnLast.TabIndex = 203;
            this.btnLast.Text = "|";
            this.btnLast.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLast.Visible = false;
            // 
            // btnBoQua
            // 
            this.btnBoQua.Enabled = false;
            this.btnBoQua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBoQua.Image = ((System.Drawing.Image)(resources.GetObject("btnBoQua.Image")));
            this.btnBoQua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBoQua.Location = new System.Drawing.Point(474, 664);
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(60, 25);
            this.btnBoQua.TabIndex = 5;
            this.btnBoQua.Text = "&Bỏ qua";
            this.btnBoQua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnBoQua, "Bỏ qua phiên làm việc");
            this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Enabled = false;
            this.btnPrevious.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevious.Image")));
            this.btnPrevious.Location = new System.Drawing.Point(48, 696);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(32, 32);
            this.btnPrevious.TabIndex = 201;
            this.btnPrevious.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrevious.Visible = false;
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(352, 664);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(60, 25);
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "     &Sửa";
            this.toolTip1.SetToolTip(this.btnSua, "Sữa một bệnh nhân (Giải phẩu bệnh)");
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(291, 664);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(60, 25);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "&Thêm ";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnThem, "Thêm mới một bệnh nhân");
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Enabled = false;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(413, 664);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(60, 25);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "     &Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // label34
            // 
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label34.Location = new System.Drawing.Point(8, 53);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(160, 14);
            this.label34.TabIndex = 208;
            this.label34.Text = "I.HÀNH CHÍNH";
            // 
            // lblTimbn
            // 
            this.lblTimbn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTimbn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimbn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTimbn.Location = new System.Drawing.Point(880, 176);
            this.lblTimbn.Name = "lblTimbn";
            this.lblTimbn.Size = new System.Drawing.Size(120, 21);
            this.lblTimbn.TabIndex = 209;
            this.lblTimbn.Text = "Tìm bệnh nhân";
            this.lblTimbn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTimbn.Click += new System.EventHandler(this.lblTimbn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.ForestGreen;
            this.panel1.Controls.Add(this.lblhotenbn);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 48);
            this.panel1.TabIndex = 210;
            // 
            // lblhotenbn
            // 
            this.lblhotenbn.BackColor = System.Drawing.Color.ForestGreen;
            this.lblhotenbn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblhotenbn.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhotenbn.ForeColor = System.Drawing.Color.White;
            this.lblhotenbn.Location = new System.Drawing.Point(72, 0);
            this.lblhotenbn.Name = "lblhotenbn";
            this.lblhotenbn.Size = new System.Drawing.Size(944, 48);
            this.lblhotenbn.TabIndex = 283;
            this.lblhotenbn.Text = "PHIẾU GIẢI PHẨU BỆNH";
            this.lblhotenbn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // chkXml
            // 
            this.chkXml.AutoSize = true;
            this.chkXml.Location = new System.Drawing.Point(931, 664);
            this.chkXml.Name = "chkXml";
            this.chkXml.Size = new System.Drawing.Size(80, 17);
            this.chkXml.TabIndex = 211;
            this.chkXml.Text = "Xuất ra Xml";
            this.chkXml.UseVisualStyleBackColor = true;
            // 
            // frmGPB
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(1016, 741);
            this.Controls.Add(this.chkXml);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTimbn);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnhuy);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnketthuc);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnBoQua);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.label34);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGPB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu giải phẩu bệnh";
            this.Load += new System.EventHandler(this.frmGPB_Load);
            this.Closed += new System.EventHandler(this.frmGPB_Closed);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmGPB_Closing);
            this.tabControl1.ResumeLayout(false);
            this.tabPageYEUCAU.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVTST)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.grpPhieumoi.ResumeLayout(false);
            this.grpPhieumoi.PerformLayout();
            this.grbTim.ResumeLayout(false);
            this.grbTim.PerformLayout();
            this.tabPageXETNGHIEM.ResumeLayout(false);
            this.tabPageXETNGHIEM.PerformLayout();
            this.tabPageDACBIET.ResumeLayout(false);
            this.tabPageDACBIET.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVTSTDacBiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAnh2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAnh)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgNhuom)).EndInit();
            this.tabPageKETLUAN.ResumeLayout(false);
            this.tabPageKETLUAN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgChandoan)).EndInit();
            this.tabTuychon.ResumeLayout(false);
            this.tabTuychon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.h)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.w)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		
		
		private void buttonKetthuc_Click(object sender, System.EventArgs e)
		{			
			this.Close();
		}
		
		private void frmGPB_Load(object sender, System.EventArgs e)
		{
			if(!Directory.Exists(file_resize))Directory.CreateDirectory(file_resize);
            user = k.user;
			ThietlapFormLoad(false);
			enable_hanhchinh(false);
			dsChandoan=m.get_data("select * from "+user+".gpb_chandoan where 1=0");
            dsNhuom = m.get_data("select * from " + user + ".gpb_xnhmmd where 1=0");
            dsVtst = m.get_data("select a.mavtst,a.malvtst,b.tenvtst,b.namevtst,c.ten from " + user + ".gpb_vtstxn a," + user + ".gpb_vtst b," + user + ".gpb_loaivtst c where a.mavtst=b.mavtst and a.malvtst=c.ma and 1=0");
            dsbs = m.get_data("select ma,hoten from " + user + ".dmbs where nhom not in(" + LibMedi.AccessData.nghiviec + ") order by hoten");
			AddTableChandoan();
			cmbMaBS.DisplayMember="HOTEN";
			cmbMaBS.ValueMember="MA";
			Load_ComboMaBS();
			Load_ComboTruongkhoa();
			Load_ComboSTTT();
			Load_ComboPhuongphapnhuom();
			LoadGridStyleVTST();
			LoadGridStyleVTSTDB();
			LoadGridStyleChandoan();
			LoadGridStyleNhuom();			
			ena_print(true);

			mapx.DisplayMember="TENPXA";
			mapx.ValueMember="MAPHUONGXA";
            mapx.DataSource = k.get_data("select maphuongxa,tenpxa from " + user + ".btdpxa order by maphuongxa").Tables[0];
			mapx.SelectedIndex=-1;

			quan.DisplayMember="TENQUAN";
			quan.ValueMember="MAQU";
            quan.DataSource = k.get_data("select maqu,tenquan from " + user + ".btdquan order by maqu").Tables[0];
			quan.SelectedIndex=-1;

			tinh.DisplayMember="TENTT";
			tinh.ValueMember="MATT";
            tinh.DataSource = k.get_data("select matt,tentt from " + user + ".btdtt order by matt").Tables[0];
			tinh.SelectedIndex=-1;

			ngayvao.ValueMember="MAQL";
			ngayvao.DisplayMember="NGAY";

			cmbMaVTST_DB.DisplayMember="TENVTST";
			cmbMaVTST_DB.ValueMember="MAVTST";

			ds=new DataSet();
			ds.ReadXml(@"..\\..\\..\\xml\\right.xml",XmlReadMode.Auto);
			bNgayht=ds.Tables[0].Rows[0]["ngayht"].ToString()=="1" ? true :false;

			cmbLoaist.DisplayMember="TEN";
			cmbLoaist.ValueMember="MA";
            cmbLoaist.DataSource = k.get_data("select ma,ten from " + user + ".gpb_loaivtst order by ma").Tables[0];
			cmbLoaist.SelectedIndex=-1;

			cmbKhoaYC.DisplayMember="TENKP";
			cmbKhoaYC.ValueMember="MAKP";

			ngayvao.DisplayMember="NGAY";
			ngayvao.ValueMember="MAQL";
			
			tenbstb.DisplayMember="HOTEN";
			tenbstb.ValueMember="MA";
			tebbsbp.DisplayMember="HOTEN";
			tebbsbp.ValueMember="MA";
			loadDanhmuc();

			loaibn.Focus();
			bUpdate=true;

			#region linh
			bCapnhatvp=k.b_capnhatvp;
			if(bCapnhatvp)
			{
				i_mavp=k.i_mavp;
                foreach (DataRow r in k.get_data("select * from " + user + ".v_giavp where id=" + i_mavp.ToString()).Tables[0].Rows)
				{
					dongia=decimal.Parse(r["gia_th"].ToString());
					vattu=decimal.Parse(r["vattu_th"].ToString());
				}
			}
			#endregion

			FileStream fstr;
			
			fstr=new FileStream("none.bmp",FileMode.Open,FileAccess.Read);
			imagenone=new byte[fstr.Length];
			fstr.Read(imagenone,0,System.Convert.ToInt32(fstr.Length));
			fstr.Close();
			f_Load_Local();
			loaibn.SelectedIndex=2;
		}

		private void AddTableChandoan()
		{
			dtChandoan=new DataTable();
			DataColumn dc= new DataColumn();
			dc.ColumnName="mavtst";
			dc.DataType=Type.GetType("System.String");
			dtChandoan.Columns.Add(dc);

			dc= new DataColumn();
			dc.ColumnName="tenvtst";
			dc.DataType=Type.GetType("System.String");
			dtChandoan.Columns.Add(dc);

			dc= new DataColumn();
			dc.ColumnName="magpb";
			dc.DataType=Type.GetType("System.String");
			dtChandoan.Columns.Add(dc);

			dc= new DataColumn();
			dc.ColumnName="tengpb";
			dc.DataType=Type.GetType("System.String");
			dtChandoan.Columns.Add(dc);

			dc= new DataColumn();
			dc.ColumnName="masttt";
			dc.DataType=Type.GetType("System.String");
			dtChandoan.Columns.Add(dc);

			dc= new DataColumn();
			dc.ColumnName="tensttt";
			dc.DataType=Type.GetType("System.String");
			dtChandoan.Columns.Add(dc);
		}

		private void loadDanhmuc()
		{
			cbodantoc.DisplayMember ="DANTOC";
			cbodantoc.ValueMember ="MADANTOC";
            cbodantoc.DataSource = b.get_data("select * from " + user + ".btddt").Tables[0];	

			tebbsbp.DataSource=dsbs.Tables[0].Copy();
			tenbstb.DataSource=dsbs.Tables[0].Copy();
			
			lb_bs.DisplayMember="HOTEN";
			lb_bs.ValueMember="HOTEN";
			lb_bs.DataSource=dsbs.Tables[0];

			lstVitrist.DisplayMember="TENVTST";
			lstVitrist.ValueMember="TENVTST";
            dsListVtst = m.get_data("select mavtst, tenvtst, hadt, havt, namevtst from " + user + ".gpb_vtst order by tenvtst");
			lstVitrist.DataSource=dsListVtst.Tables[0];

			lstChandoan.DisplayMember="TENGPB";
			lstChandoan.ValueMember="TENGPB";
            dsListChandoan = m.get_data("select magpb, tengpb, nhanxet, chandoan from " + user + ".gpb_gpb order by magpb");
			lstChandoan.DataSource=dsListChandoan.Tables[0];
		}
	
		private void LoadGridStyleVTST()
		{			
			DataGridTableStyle tbs=new DataGridTableStyle();			
			tbs.MappingName=dsVtst.Tables[0].TableName;
			tbs.AlternatingBackColor = Color.Beige;
			tbs.BackColor = Color.GhostWhite;
			tbs.ForeColor = Color.MidnightBlue;
			tbs.GridLineColor = Color.RoyalBlue;
			tbs.HeaderBackColor = Color.Gainsboro;
			tbs.HeaderForeColor = Color.Blue;
			tbs.SelectionBackColor = Color.Teal;
			tbs.SelectionForeColor = Color.PaleGreen;
			tbs.RowHeaderWidth=20;
			tbs.PreferredRowHeight=22;
			tbs.ReadOnly=true;

			DataGridTextBoxColumn textCol=new DataGridTextBoxColumn();
			textCol.MappingName="mavtst";
			textCol.HeaderText="Mã VTST";
			textCol.Width=80;
			tbs.GridColumnStyles.Add(textCol);
			dtgVTST.TableStyles.Add(tbs);

			textCol=new DataGridTextBoxColumn();
			textCol.MappingName="tenvtst";
			textCol.HeaderText="Tên VTST";
			textCol.Width=180;
			tbs.GridColumnStyles.Add(textCol);
			dtgVTST.TableStyles.Add(tbs);
		
			textCol=new DataGridTextBoxColumn();
			textCol.MappingName="namevtst";
			textCol.HeaderText="";
			textCol.Width=0;
			tbs.GridColumnStyles.Add(textCol);
			dtgVTST.TableStyles.Add(tbs);

			textCol=new DataGridTextBoxColumn();
			textCol.MappingName="malvtst";
			textCol.HeaderText="Mã loại VTST";
			textCol.Width=dtgVTST.Width-280;
			tbs.GridColumnStyles.Add(textCol);
			dtgVTST.TableStyles.Add(tbs);
		}
    
		private void LoadGridStyleNhuom()
		{
			DataGridTableStyle tbs=new DataGridTableStyle();
			tbs.MappingName=dsNhuom.Tables[0].TableName;
			tbs.AlternatingBackColor = Color.Beige;
			tbs.BackColor = Color.GhostWhite;
			tbs.ForeColor = Color.MidnightBlue;
			tbs.GridLineColor = Color.RoyalBlue;
			tbs.HeaderBackColor = Color.Gainsboro;
			tbs.HeaderForeColor = Color.Blue;
			tbs.SelectionBackColor = Color.Teal;
			tbs.SelectionForeColor = Color.PaleGreen;
			tbs.RowHeaderWidth=20;
			tbs.PreferredRowHeight=22;
			tbs.ReadOnly=true;

			dtgNhuom.TableStyles.Add(tbs);
			DataGridTextBoxColumn c0=new DataGridTextBoxColumn();
			c0.MappingName="MaHMMD";
			c0.HeaderText="Mã HMMD";
			c0.Width=70;
			tbs.GridColumnStyles.Add(c0);
			dtgNhuom.TableStyles.Add(tbs);

			DataGridTextBoxColumn textCol=new DataGridTextBoxColumn();
			textCol.MappingName="TenHMMD";
			textCol.HeaderText="Tên HMMD";
			textCol.Width=80;
			tbs.GridColumnStyles.Add(textCol);
			dtgNhuom.TableStyles.Add(tbs);
		
			DataGridBoolColumn c2 = new DataGridBoolColumn();
			c2.MappingName="DuongTinh";
			c2.HeaderText="Dương Tính";
			c2.Width=80;
			tbs.GridColumnStyles.Add(c2);
			dtgNhuom.TableStyles.Add(tbs);

			textCol=new DataGridTextBoxColumn();
			textCol.MappingName="CuongDo";
			textCol.HeaderText="Cường Độ";
			textCol.Width=80;
			tbs.GridColumnStyles.Add(textCol);
			dtgNhuom.TableStyles.Add(tbs);

			textCol=new DataGridTextBoxColumn();
			textCol.MappingName="MucDo";
			textCol.HeaderText="Mức Độ";
			textCol.Width=70;
			tbs.GridColumnStyles.Add(textCol);
			dtgNhuom.TableStyles.Add(tbs);

			textCol=new DataGridTextBoxColumn();
			textCol.MappingName="GhiChu";
			textCol.HeaderText="Ghi Chú";
			textCol.Width=dtgNhuom.Width-400;
			tbs.GridColumnStyles.Add(textCol);
			dtgNhuom.TableStyles.Add(tbs);
		}

		private void LoadGridStyleVTSTDB()
		{			
			DataGridTableStyle tbs=new DataGridTableStyle();
			tbs.MappingName=ds.Tables[0].TableName;
			tbs.AlternatingBackColor = Color.Beige;
			tbs.BackColor = Color.GhostWhite;
			tbs.ForeColor = Color.MidnightBlue;
			tbs.GridLineColor = Color.RoyalBlue;
			tbs.HeaderBackColor = Color.Gainsboro;
			tbs.HeaderForeColor = Color.Blue;
			tbs.SelectionBackColor = Color.Teal;
			tbs.SelectionForeColor = Color.PaleGreen;
			tbs.RowHeaderWidth=20;
			tbs.PreferredRowHeight=22;
			tbs.ReadOnly=true;

			DataGridTextBoxColumn textCol=new DataGridTextBoxColumn();
			textCol.MappingName="MaVTST";
			textCol.HeaderText="Mã VTST";
			textCol.Width=110;
			tbs.GridColumnStyles.Add(textCol);
			dtgVTSTDacBiet.TableStyles.Add(tbs);

			textCol=new DataGridTextBoxColumn();
			textCol.MappingName="TenVTST";
			textCol.HeaderText="Tên VTST";
			textCol.Width=dtgVTSTDacBiet.Width-130;
			tbs.GridColumnStyles.Add(textCol);
			dtgVTSTDacBiet.TableStyles.Add(tbs);
		
			textCol=new DataGridTextBoxColumn();
			textCol.MappingName="NameVTST";
			textCol.HeaderText="";
			textCol.Width=0;
			tbs.GridColumnStyles.Add(textCol);			
			dtgVTSTDacBiet.TableStyles.Add(tbs);
		}	

		private void LoadGridStyleChandoan()
		{			
			DataGridTableStyle tbs = new DataGridTableStyle();
			//tbs.MappingName=dsChandoan.Tables[0].TableName;
			tbs.MappingName=dtChandoan.TableName;
			tbs.AlternatingBackColor = Color.Beige;
			tbs.BackColor = Color.GhostWhite;
			tbs.ForeColor = Color.MidnightBlue;
			tbs.GridLineColor = Color.RoyalBlue;
			tbs.HeaderBackColor = Color.Gainsboro;
			tbs.HeaderForeColor = Color.Blue;
			tbs.SelectionBackColor = Color.Teal;
			tbs.SelectionForeColor = Color.PaleGreen;
			tbs.RowHeaderWidth=20;
			tbs.PreferredRowHeight=22;
			tbs.ReadOnly=true;
		
			DataGridTextBoxColumn textCol=new DataGridTextBoxColumn();
			textCol.MappingName="MaGPB";
			textCol.HeaderText="Mã GPB";
			textCol.Width=80;
			textCol.NullText="";
			tbs.GridColumnStyles.Add(textCol);
			dtgChandoan.TableStyles.Add(tbs);

			textCol=new DataGridTextBoxColumn();
			textCol.MappingName="TenGPB";
			textCol.HeaderText="Chẩn đoán";
			textCol.Width=300;
			textCol.NullText="";
			tbs.GridColumnStyles.Add(textCol);
			dtgChandoan.TableStyles.Add(tbs);

			textCol=new DataGridTextBoxColumn();
			textCol.MappingName="TenVTST";
			textCol.HeaderText="Tên VTST";
			textCol.Width=dtgChandoan.Width-460;
			tbs.GridColumnStyles.Add(textCol);
			dtgChandoan.TableStyles.Add(tbs);

			textCol=new DataGridTextBoxColumn();
			textCol.MappingName="MaSTTT";
			textCol.HeaderText="";
			textCol.Width=0;
			textCol.NullText="";
			tbs.GridColumnStyles.Add(textCol);
			dtgChandoan.TableStyles.Add(tbs);

			textCol=new DataGridTextBoxColumn();
			textCol.MappingName="TenSTTT";
			textCol.HeaderText="";
			textCol.Width=0;
			textCol.NullText="";
			tbs.GridColumnStyles.Add(textCol);
			dtgChandoan.TableStyles.Add(tbs);

			textCol=new DataGridTextBoxColumn();
			textCol.MappingName="MaVTST";
			textCol.HeaderText="Mã VTST";
			textCol.Width=60;
			tbs.GridColumnStyles.Add(textCol);
			dtgChandoan.TableStyles.Add(tbs);
		}	

		private void ThietlapFormLoad(bool ena)
		{
			tenbs.Enabled=ena;
			txtBanluan.Enabled=ena;			
			txtChandoanlamsang.Enabled=ena;			
			txtKhoaYC.Enabled=ena;
			txtDaithe.Enabled=ena;
			txtKetluan.Enabled=ena;
			txtNgaytra.Enabled=ena;			
			txtVithe.Enabled=ena;	
			textBoxNgayNhan.Enabled=ena;
			textBoxSoGPB.Enabled=ena;
			listChandoan.Enabled=ena;
			cmbKhoaYC.Enabled=ena;
			txtbacsiyeucau.Enabled=ena;
			cmbMaBS.Enabled=ena;
			cmbTruongkhoa.Enabled=ena;			
			listMavtst.Enabled=ena;
			cmbMaVTST_DB.Enabled=ena;			
			buttonBacsi.Enabled=ena;
			buttonOK.Enabled=ena;
			checkBoxNhuomdacbiet.Enabled=ena;	
			checkBoxSTTT.Enabled=ena;			
			tcls.Enabled=ena;
			txtMaloai.Enabled=ena;
			cmbLoaist.Enabled=ena;
			kqst_first.Enabled=ena;
			nxdt.Enabled=ena;
			qtdt.Enabled=ena;
			txtVTST1.Enabled=ena;
			txtPhuongphapnhuom.Enabled=ena;
			cmbPhuongphapnhuom.Enabled=ena;
			checkBoxDT.Enabled=ena;
			cmbCuongdo.Enabled=ena;
			txtTile.Enabled=ena;
			txtGhichu.Enabled=ena;
			buttonOK.Enabled=ena;
			bMinusVtst.Enabled=ena;
			buttonOK_DB_Sua.Enabled=ena;
			butNhuomMiinus.Enabled=ena;
			butOk_Cdgpb.Enabled=ena;
			butMinus.Enabled=ena;
			chkNhuom.Enabled=ena;
			chkPhuhop.Enabled=ena;
			tenbstb.Enabled=ena;
			mabstb.Enabled=ena;
			tebbsbp.Enabled=ena;
			mabsbp.Enabled=ena;
			txtNgaykt.Enabled=ena;
			txtngaypha.Enabled=ena;
			txtSomanh.Enabled=ena;
		}

		private void enable_hanhchinh(bool ena)
		{
			txthoten.Enabled=ena;
			tuoi.Enabled=ena;
			cbophai.Enabled=ena;
			cbohonhan.Enabled=ena;
			txtNgaySinh.Enabled=ena;
			cbodantoc.Enabled=ena;
			mapx.Enabled= ena;			
			txtdiachi.Enabled=ena;
			tinh.Enabled=ena;
			quan.Enabled=ena;
			sohs.Enabled=ena;
			para1.Enabled=ena;
			para2.Enabled=ena;
			para3.Enabled=ena;
			para4.Enabled=ena;
		}

		private void buttonToanbo_Click(object sender, System.EventArgs e)
		{	
			btnSua.Enabled=false;
			Ena_button_Navigation(true);//Ena buttons Chuyển hướng
			Ena_button_Toanbo(false);	//Unena buttons Them xoa sua ...
			ShowTextToanbo();			// Show Text khi nhấn nút Toàn Bộ	
			ShowGrid_TheoSoGPB();		// Show Grid khi nhấn nút Toàn Bộ			
		}

		private void buttonBacsi_Click(object sender, System.EventArgs e)
		{
			ds = new DataSet();
			MenuItem mnu ;
            sql = "select makp,tenkp from " + user + ".btdkp_bv where makp<>'01' and loai= 0 order by makp";
			ds= k.get_data(sql);
			contextMenu1.MenuItems.Clear();
			
			foreach  (DataRow rr in  ds.Tables[0].Rows)
			{
				mnu = new MenuItem(rr["makp"].ToString()+ " - "+rr["tenkp"].ToString());			
				mnu.Click+= new System.EventHandler(mnu_Click);
				contextMenu1.MenuItems.Add(mnu);
			}			
		}

		private void mnu_Click(object sender, System.EventArgs e)
		{
			MenuItem mnu = (MenuItem) sender;
			mnu.Checked= true;
            sql = "select makp,tenkp  from " + user + ".btdkp_bv where makp<>'01' and loai= 0 and makp in ( " + mnu.Text.ToString().Substring(0, 2) + ") order by makp";
			ds = new DataSet();
			ds= k.get_data(sql);
			ds.WriteXml(@"..\\..\\..\\xml\GPB_chonkhoa.xml",XmlWriteMode.WriteSchema);
		}

		private void buttonThem_Click(object sender, System.EventArgs e)
		{			
			tabPageXETNGHIEM.Focus();
			text_Clear();
			ThietlapFormLoad(true);
			EnalbeButton(true);
			btnLuu.Visible=true;		
			btnLuu.Enabled=true;			
			textBoxNgayNhan.Text= b.Ngayhienhanh;
			txtNgaytra.Text= b.Ngayhienhanh;
            Ena_button_Navigation(false);
			tabControl1.SelectedIndex=0;
			txtmabn.Focus();
		}

		private void cmbKhoaYC_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.ActiveControl==cmbKhoaYC)
			{
				if (cmbKhoaYC.SelectedIndex!=-1 && cmbKhoaYC.Text.Trim()!="" )  
				{
					txtKhoaYC.Text = cmbKhoaYC.SelectedValue.ToString();				
				}
				else txtKhoaYC.Text="";
			}
		}
	
		private void Load_ComboMaBS()
		{
            ds = new DataSet();
			ds.ReadXml(@"..\\..\\..\\xml\GPB_chonkhoa.xml");
            sql = "select ma,hoten from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nghiviec + ") order by hoten";
			dtbs=k.get_data(sql).Tables[0];
			cmbMaBS.DataSource=dtbs;
//		    k.OutputCMB(cmbMaBS,k.get_data(sql).Tables[0],"MA","HOTEN");			
		}

		private void Load_ComboTruongkhoa()
		{
            sql = "select ma,hoten from " + user + ".dmbs where nhom not in(" + LibMedi.AccessData.nghiviec + "," + LibMedi.AccessData.giamdoc + "," + LibMedi.AccessData.phogiamdoc + ") order by hoten";
			k.OutputCMB(cmbTruongkhoa, k.get_data(sql).Tables[0],"MA","HOTEN");
		}

		private void cmbMaBS_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (cmbMaBS.SelectedIndex!=-1) txtTenBS1.Text=cmbMaBS.SelectedValue.ToString();
			else txtTenBS1.Text="";
		}

		private void cmbTruongkhoa_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (cmbTruongkhoa.SelectedIndex!=-1) txtTruongkhoa.Text=cmbTruongkhoa.SelectedValue.ToString();
			else txtTruongkhoa.Text="";
		}		

		private void LoadTab_Dacbiet(bool ena)
		{
			dtgVTSTDacBiet.Enabled=ena;
			dtgNhuom.Enabled=ena;
			txtGhichu.Enabled=ena;
			cmbCuongdo.Enabled=ena;
			txtPhuongphapnhuom.Enabled=ena;
			cmbPhuongphapnhuom.Enabled=ena;
//			checkBoxAnh.Enabled=ena;
			checkBoxDT.Enabled=ena;
			txtTile.Enabled=ena;
			dtgNhuom.Enabled=ena;
			dtgVTSTDacBiet.Enabled=ena;
		}

		private void checkBoxNhuomdacbiet_CheckStateChanged(object sender, System.EventArgs e)
		{			
			if(checkBoxNhuomdacbiet.Checked==true)
			{	
				LoadTab_Dacbiet(true);
                sql = "Select GPB_VTSTXN.MaVTST, GPB_VTST.TenVTST, GPB_VTST.NameVTST FROM " + user + ".GPB_VTST INNER JOIN " + user + ".GPB_VTSTXN ON GPB_VTST.MaVTST = GPB_VTSTXN.MaVTST WHERE GPB_VTSTXN.SoGPB='" + textBoxSoGPB.Text.ToString().Trim() + "'";
				ads = k.get_data(sql);
				if(ads.Tables[0].Rows.Count>0)
				{
					dtgVTSTDacBiet.DataSource=ads.Tables[0];// Tim nhung VTST cua so GPB cu.
				}
				//Truong hop nay chi xay ra khi chung ta them mot so GPB moi.

				if(dtgVTSTDacBiet.VisibleRowCount == 0)
				{
					txtMaVTST.Text="";
					txtVTST.Text="";
					dtgVTSTDacBiet.CaptionText= "";
				}
				else
				{
					txtMaVTST.Text = dtgVTSTDacBiet[dtgVTSTDacBiet.CurrentRowIndex,0].ToString();
					txtVTST.Text=dtgVTSTDacBiet[dtgVTSTDacBiet.CurrentRowIndex,1].ToString();				
					dtgVTSTDacBiet.CaptionText = dtgVTSTDacBiet[dtgVTSTDacBiet.CurrentRowIndex,2].ToString();
				}
			}
			else
			{
				//LoadTab_Dacbiet(false);	
				dtgNhuom.DataSource=null;		
			}
		}
		
		private void Load_ComboPhuongphapnhuom()
		{
            sql = "Select MaHMMD,TenHMMD From " + user + ".GPB_HMMD Order by TenHMMD Asc";
			k.OutputCMB(cmbPhuongphapnhuom,k.get_data(sql).Tables[0],"MaHMMD","TenHMMD");			
		}
		
		private void cmbPhuongphapnhuom_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (cmbPhuongphapnhuom.SelectedIndex!=-1) txtPhuongphapnhuom.Text=cmbPhuongphapnhuom.SelectedValue.ToString();
		}

		
		private void Load_ComboSTTT()
		{
            sql = "select magpb,tengpb from " + user + ".gpb_gpb";
			k.OutputCMB(cmbSTTT,k.get_data(sql).Tables[0],"magpb","tengpb");
		}

		private void cmbSTTT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtSTTT.Text=cmbSTTT.SelectedValue.ToString();
		}
		
		private void buttonOK_Click(object sender, System.EventArgs e)
		{		
			if(txtVTST1.Text=="" && listMavtst.Text=="")
			{
				MessageBox.Show("Bạn chưa chọn VTST",LibMedi.AccessData.Msg);
				listMavtst.Focus();
				return;
			}
			if(txtMaloai.Text=="")
			{
				MessageBox.Show("Bạn chưa chọn loại VTST",LibMedi.AccessData.Msg);
				cmbLoaist.Focus();
				cmbLoaist.DroppedDown=true;
				return;
			}
			
			string s_mavtst=txtVTST1.Text.Trim();
			if(dsVtst.Tables[0].Select("mavtst='"+s_mavtst+"'").Length==0 && s_mavtst!=null)
			{
				DataRow r =dsVtst.Tables[0].NewRow();
				r["mavtst"]=txtVTST1.Text.Trim();
				r["tenvtst"]=listMavtst.Text.Trim();
				r["malvtst"]=txtMaloai.Text.Trim();
				dsVtst.Tables[0].Rows.Add(r);
				dtgVTST.DataSource=dsVtst.Tables[0];
				dtgVTSTDacBiet.DataSource=dsVtst.Tables[0];
				cmbMaVTST_DB.DataSource=dsVtst.Tables[0];
			}
			else
			{
				MessageBox.Show("Vị trí sinh thiết này đã được chọn!",LibMedi.AccessData.Msg);
				return;
			}
		}

		private void ShowGrid(string m_sql)
		{			
			ads = k.get_data(m_sql); 
			dtgVTST.DataSource = ads.Tables[0];
			dtgVTSTDacBiet.DataSource=ads.Tables[0];
		}
		
		private void dtgVTST_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				txtVTST1.Text= dtgVTST[dtgVTST.CurrentRowIndex,0].ToString();			
				lbName.Text = dtgVTST[dtgVTST.CurrentRowIndex,2].ToString();
				listMavtst.Text=k.get_tenvtst(txtVTST1.Text.Trim());
				txtMaloai.Text=dtgVTST[dtgVTST.CurrentRowIndex,3].ToString();
				cmbLoaist.SelectedValue=txtMaloai.Text.Trim();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message,LibMedi.AccessData.Msg);
			}
		}

		private void dtgVTSTDacBiet_CurrentCellChanged(object sender, System.EventArgs e)
		{
			if(dtgVTSTDacBiet.VisibleRowCount==1)
			{
				dtgVTSTDacBiet.CaptionText= dtgVTSTDacBiet[0,2].ToString();
				txtMaVTST.Text=dtgVTSTDacBiet[0,0].ToString();
				txtVTST.Text=dtgVTSTDacBiet[0,1].ToString();
			}
			dtgVTSTDacBiet.CaptionText= dtgVTSTDacBiet[dtgVTSTDacBiet.CurrentRowIndex,2].ToString();
			txtMaVTST.Text=dtgVTSTDacBiet[dtgVTSTDacBiet.CurrentRowIndex,0].ToString();
			txtVTST.Text=dtgVTSTDacBiet[dtgVTSTDacBiet.CurrentRowIndex,1].ToString();

            sql = "select a.mahmmd,b.tenhmmd,a.duongtinh,a.cuongdo,a.mucdo,a.ghichu from " + user + ".gpb_xnhmmd a inner join " + user + ".gpb_hmmd b on a.mahmmd=b.mahmmd where a.sogpb='" + textBoxSoGPB.Text.ToString().Trim() + "' and a.mavtst='" + txtMaVTST.Text.ToString().Trim() + "'";
			dsNhuom=m.get_data(sql);
			if(dsNhuom!=null) dtgNhuom.DataSource=dsNhuom.Tables[0];
			else
			{
                dsNhuom = k.get_data("select a.mahmmd,a.tenhmmd,a.duongtinh,a.cuongdo,a.mucdo,a.ghichu from " + user + ".gpb_xnhmmd1 a where a.mavtst='" + txtMaVTST.Text.ToString().Trim() + "'");
				dtgNhuom.DataSource=dsNhuom.Tables[0];				
			}
		}

		private void txtNamsinh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{		
			if(e.KeyCode == Keys.Enter) 
			{
				cbophai.Focus();
				cbophai.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void textBoxSoHoSo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void textBoxHotenBN_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}")			;
		}

		private void radioButton1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}")			;
		}

		private void radioButton2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}")			;
		}

		private void textBoxSoGPB_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}")			;
		}

		private void textBoxNgayNhan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}")	;
		}

		private void cmbKhoaYC_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter) 
			{
				SendKeys.Send("{Tab}{F4}");
			}
		}
	
		private void cmbPhuongphapnhuom_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(dtgVTSTDacBiet.VisibleRowCount == 0)
			{
				MessageBox.Show("Bạn chưa chọn VTST",LibMedi.AccessData.Msg);
			}
			else
			{
				if(txtMaVTST.Text=="")
				{
					MessageBox.Show("Hãy chọn VTST từ danh sách",LibMedi.AccessData.Msg);
				}	
			}			
		}

		private void cmbPhuongphapnhuom_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(dtgVTSTDacBiet.VisibleRowCount == 0)
			{
				MessageBox.Show("Bạn chưa chọn VTST",LibMedi.AccessData.Msg);
			}
			else
			{
				if(txtMaVTST.Text=="")
				{
					MessageBox.Show("Hãy chọn VTST từ danh sách",LibMedi.AccessData.Msg);
				}	
			}

			if(e.KeyCode==Keys.Enter)SendKeys.Send("{Tab}");
		}

		private void cmbMaVTST_DB_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(cmbMaVTST_DB.SelectedIndex!=-1) txtMaVTSTDB.Text=cmbMaVTST_DB.SelectedValue.ToString();
		}

		private void buttonOKKetluan_Click(object sender, System.EventArgs e)
		{
			if(checkBoxSTTT.Checked == false)
                k.execute_data("update " + user + ".gpb_vtst1 set magpb='" + txtChandoan.Text + "',tengpb='" + listChandoan.Text + "' where mavtst='" + txtMaVTSTDB.Text + "'");
			if(checkBoxSTTT.Checked==true)
                k.execute_data("update " + user + ".gpb_vtst1 set magpb='" + txtChandoan.Text + "',tengpb='" + listChandoan.Text + "',masttt='"+txtSTTT.Text+"',tensttt='"+cmbSTTT.Text+"' where mavtst='" + txtMaVTSTDB.Text + "'");
            dtgChandoan.DataSource = k.get_data("select * from " + user + ".gpb_vtst1").Tables[0];
		}

		private void cmbSTTT_SelectedIndexChanged_1(object sender, System.EventArgs e)
		{
			if (cmbSTTT.SelectedIndex!=-1)txtSTTT.Text= cmbSTTT.SelectedValue.ToString();
		}

		
		private void cmbPhai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter ) 	textBoxSoGPB.Focus();
		}

		private void Insert_to_tableVTSTXN()
		{
            k.execute_data("Insert into " + user + ".GPB_VTSTXN(SoGPB,MaVTST,MaGPB,MaSTTT) Select SoGPB,MaVTST,MaGPB,MaSTTT From " + user + ".GPB_PXN,GPB_VTST1 Where GPB_PXN.SoGPB = '" + textBoxSoGPB.Text.ToString().Trim() + "'");
		}

		private void txtKetluan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.F2)
			{
				txtKetluan.Text=k.get_viettat(txtKetluan.Text.Trim());
				txtKetluan.SelectionStart=txtKetluan.Text.Trim().Length;
			}
		}

		private void cmbMaVTST_DB_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				listChandoan.Focus();
				SendKeys.Send("{f4}");
				
			}
		}

		private void txtBanluan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.F2)
			{
				txtBanluan.Text=k.get_viettat(txtBanluan.Text.Trim());
				txtBanluan.SelectionStart=txtBanluan.Text.Trim().Length;
			}
		}

		private void cmbMaBS_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void txtNgaytra_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) 
			{
				cmbTruongkhoa.Focus();
				SendKeys.Send("{f4}");
			}
		}
		
		public void Insert_to_VTSTHMMD()
		{
            k.execute_data("Insert into " + user + ".GPB_VTSTHMMD(SoGPB,MaVTST) Select SoGPB,MaVTST From " + user + ".GPB_VTSTXN Where GPB_VTSTXN.SoGPB = '" + textBoxSoGPB.Text.ToString().Trim() + "'");		
		}

		private void Insert_to_XNHMMD()
		{
            k.execute_data("Insert into " + user + ".GPB_XNHMMD(SoGPB,MaVTST,MaHMMD,DuongTinh,CuongDo,MucDo,GhiChu) Select SoGPB,MaVTST,MaHMMD,DuongTinh,CuongDo,MucDo,GhiChu From " + user + ".GPB_XNHMMD1 ");
		}		

		private bool Kiemtrangay(string ngay)
		{
			if(txtNgaytra.TextLength ==0)
			{
				MessageBox.Show("Nhập ngày trả",LibMedi.AccessData.Msg);
				txtNgaytra.Focus();
				tabControl1.SelectedIndex=3;
				return false;
			}
			return true;
		}

		private void dtgChandoan_CurrentCellChanged(object sender, System.EventArgs e)
		{
			txtMaVTSTDB.Text=dtgChandoan[dtgChandoan.CurrentCell.RowNumber,5].ToString();
			cmbMaVTST_DB.SelectedValue=txtMaVTSTDB.Text.Trim();
			txtChandoan.Text=dtgChandoan[dtgChandoan.CurrentCell.RowNumber,0].ToString();
			listChandoan.Text=k.get_tengpb(txtChandoan.Text.Trim());
			txtSTTT.Text=dtgChandoan[dtgChandoan.CurrentCell.RowNumber,4].ToString();
			cmbSTTT.SelectedValue=txtSTTT.Text.Trim();
			if(dtgChandoan[dtgChandoan.CurrentCell.RowNumber,4].ToString()== "")
				checkBoxSTTT.Checked=false;
			else
				checkBoxSTTT.Checked=true;
		}
		
		private void checkBoxNhuomdacbiet_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)	
			{
				cmbPhuongphapnhuom.Focus();
				SendKeys.Send("{f4}");
			}
		}

		private void txtPhuongphapnhuom_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)	SendKeys.Send("{Tab}");
		}

		private void checkBoxDT_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)	SendKeys.Send("{Tab}{f4}");
		}

		private void cmbCuongdo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)	SendKeys.Send("{Tab}");
		}

		private void txtTile_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)	SendKeys.Send("{Tab}");		
		}

		private void txtGhichu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)	SendKeys.Send("{Tab}");
		}

		private void buttonPrevious_Click(object sender, System.EventArgs e)
		{
			if(bManager.Position>=1)
			{
				bManager.Position -=1;
				ShowGrid_TheoSoGPB();
				LoadTenKhoaYC();
			}
		}

		private void buttonNext_Click(object sender, System.EventArgs e)
		{
			if(bManager.Position<=bManager.Count-2)
			{
				bManager.Position +=1;	
				ShowGrid_TheoSoGPB();
				LoadTenKhoaYC();
			}
		}		

		private void buttonFrist_Click(object sender, System.EventArgs e)
		{
			bManager.Position=0;
			ShowGrid_TheoSoGPB();
			LoadTenKhoaYC();
		}

		private void buttonLast_Click(object sender, System.EventArgs e)
		{					
			bManager.Position= (bManager.Count -1) ;	
			ShowGrid_TheoSoGPB();
			LoadTenKhoaYC();
		}

		private void Ena_button_Navigation(bool ena)
		{
            btnFirst.Enabled=ena;
			btnLast.Enabled=ena;
			btnPrevious.Enabled=ena;
			btnNext.Enabled=ena;
		}

//=========================Show text và Grid khi nhấn nút toàn bộ=====================//
		private void ShowTextToanbo()
		{
			try
			{
                sql = "select a.sogpb,a.sohs,to_char(a.ngaynhan,'dd/mm/yyyy') as ngaynhan,b.hotenbn,b.namsinh,b.gioitinh,a.dvyc,a.bsyc,a.cdls,a.thongtinlienquan,a.hadt,a.havt,a.nhuomdb,a.coanh,a.anh,a.sttt,a.lcdgpb,a.banluan,to_char(ngaytra,'dd/mm/yyyy') as ngaytra,a.bacsidoc,a.truongkhoa from " + user + ".gpb_pxn a," + user + ".gpb_btdbn b where a.sohs=b.mabn order by a.sogpb desc"; 
				ads = k.Get_DataToanbo(sql,"GPB_PXN");
				textBoxNgayNhan.DataBindings.Clear();
				textBoxSoGPB.DataBindings.Clear();
				txtBanluan.DataBindings.Clear();
				txtChandoanlamsang.DataBindings.Clear();
				cbophai.DataBindings.Clear();
				txtKetluan.DataBindings.Clear();
				txtVithe.DataBindings.Clear();
				txtDaithe.DataBindings.Clear();
				txtNgaytra.DataBindings.Clear();
				checkBoxNhuomdacbiet.DataBindings.Clear();
				checkBoxSTTT.DataBindings.Clear();
				//checkBoxAnh.DataBindings.Clear();
				lbPath_ofpicture.DataBindings.Clear();
				txtKhoaYC.DataBindings.Clear();
				cmbKhoaYC.DataBindings.Clear();
				textBoxNgayNhan.DataBindings.Add("Text",ads,"GPB_PXN.NgayNhan");
				txtBanluan.DataBindings.Add("Text",ads,"GPB_PXN.BanLuan");
				txtChandoanlamsang.DataBindings.Add("Text",ads,"GPB_PXN.CDLS");
				cbophai.DataBindings.Add("SelectedIndex",ads,"GPB_PXN.GioiTinh");
				txtKetluan.DataBindings.Add("Text",ads,"GPB_PXN.LCDGPB");
				txtVithe.DataBindings.Add("Text",ads,"GPB_PXN.HAVT");
				txtDaithe.DataBindings.Add("Text",ads,"GPB_PXN.HADT");
				txtNgaytra.DataBindings.Add("Text",ads,"GPB_PXN.NgayTra");
				txtbacsiyeucau.DataBindings.Add("Text",ads,"GPB_PXN.BSYC");
				checkBoxNhuomdacbiet.DataBindings.Add("Checked",ads,"GPB_PXN.NhuomDB");
				checkBoxSTTT.DataBindings.Add("Checked",ads,"GPB_PXN.STTT");
				//checkBoxAnh.DataBindings.Add("Checked",ads,"GPB_PXN.CoAnh");
				lbPath_ofpicture.DataBindings.Add("Text",ads,"GPB_PXN.Anh");	
				txtKhoaYC.DataBindings.Add("Text",ads,"GPB_PXN.DVYC");
				cmbKhoaYC.DataBindings.Add("SelectedValue",ads,"GPB_PXN.DVYC");

				bManager = this.BindingContext[ads,"GPB_PXN"];
				loadTree(m_mabn);
				LoadTenKhoaYC();			
			}
			catch(Exception caught)
			{
				MessageBox.Show(caught.Message);
			}
		}

		public void ShowGrid_TheoSoGPB()
		{
            string sql = "Select GPB_VTSTXN.MaVTST, GPB_VTST.TenVTST, GPB_VTST.NameVTST FROM " + user + ".GPB_VTST  JOIN " + user + ".GPB_VTSTXN ON GPB_VTST.MaVTST = GPB_VTSTXN.MaVTST WHERE GPB_VTSTXN.SoGPB='" + textBoxSoGPB.Text.ToString().Trim() + "'"; 
			ads = k.get_data(sql);
			if(ds.Tables[0].Rows.Count != 0)
			{
				dtgVTST.DataSource=ads.Tables[0];
				dtgVTSTDacBiet.DataSource=ads.Tables[0];
				dtgVTSTDacBiet_CurrentCellChanged(null,null);
			}
            ads = k.get_data("SELECT GPB_VTSTXN.MaVTST, GPB_VTST.TenVTST, GPB_VTSTXN.MaGPB, GPB_GPB.TenGPB, GPB_VTSTXN.MaSTTT, GPB_1.TenGPB AS TenSTTT FROM (" + user + ".GPB_GPB  JOIN (" + user + ".GPB_VTST JOIN " + user + ".GPB_VTSTXN ON GPB_VTST.MaVTST = GPB_VTSTXN.MaVTST) ON GPB_GPB.MaGPB = GPB_VTSTXN.MaGPB) LEFT JOIN " + user + ".GPB_GPB  GPB_1 ON GPB_VTSTXN.MaSTTT = GPB_1.MaGPB WHERE GPB_VTSTXN.SoGPB= '" + textBoxSoGPB.Text.ToString().Trim() + "' ");
			dtgChandoan.DataSource=ads.Tables[0];			
			loadTree(m_mabn);
			dtgNhuom.DataSource=null;
		}		

		private void dtgNhuom_CurrentCellChanged(object sender, System.EventArgs e)
		{
			txtPhuongphapnhuom.Text=dtgNhuom[dtgNhuom.CurrentCell.RowNumber,0].ToString();
			lbMaHMMD.Text=dtgNhuom[dtgNhuom.CurrentCell.RowNumber,0].ToString();
			cmbPhuongphapnhuom.SelectedValue=txtPhuongphapnhuom.Text.Trim();
			string t=dtgNhuom[dtgNhuom.CurrentRowIndex,2].ToString();
			if(dtgNhuom[dtgNhuom.CurrentCell.RowNumber,2].ToString()=="1") checkBoxDT.Checked=true;
			else checkBoxDT.Checked=false;
			cmbCuongdo.Text=dtgNhuom[dtgNhuom.CurrentCell.RowNumber,3].ToString();
			txtTile.Text=dtgNhuom[dtgNhuom.CurrentCell.RowNumber,4].ToString();
			txtGhichu.Text=dtgNhuom[dtgNhuom.CurrentCell.RowNumber,5].ToString();
		}

		private void lbPath_ofpicture_TextChanged(object sender, System.EventArgs e)
		{
			if(lbPath_ofpicture.Text !="")			
			{
				pictureBoxAnh.Image =Image.FromFile(lbPath_ofpicture.Text.ToString());
//				pictureBoxAnh.Tag=lbPath_ofpicture.Text.ToString();
				// cai nay giu duong dan file hay ban than cua file
				//cainay ko su dung dau
			}
			else
			{
				pictureBoxAnh.Image=null;
			}
		}

		private void buttonLoadHinh_Click(object sender, System.EventArgs e)
		{
			
		}
//===========TAM THOI BO TIM DU LIEU THEO TEXTBOXSOGPB_VALIDATING====================//
		private void textBoxSoGPB_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			textBoxSoGPB.Text=m.Hoten_khongdau(textBoxSoGPB.Text);
			textBoxSoGPB.Text=textBoxSoGPB.Text.Trim().PadLeft(8,'0');
            if (k.Kiemtratrungma("Select SoGPB From " + user + ".GPB_PXN", textBoxSoGPB.Text))
			{
				MessageBox.Show("Đã có số GPB này rồi",LibMedi.AccessData.Msg);
				textBoxSoGPB.Focus();
			}
		}

		private bool LoadDataSoGPB()
		{
			try
			{		
				string soGPB = textBoxSoGPB.Text.ToString().Trim();
                ads = k.get_data("SELECT GPB_PXN.SoGPB, GPB_PXN.SoHS, GPB_PXN.NgayNhan, GPB_PXN.DVYC, GPB_PXN.BSYC, GPB_PXN.CDLS, GPB_PXN.ThongTinLienQuan, GPB_PXN.HADT, GPB_PXN.HAVT, GPB_PXN.NhuomDB, GPB_PXN.CoAnh, GPB_PXN.Anh, GPB_PXN.STTT, GPB_PXN.LCDGPB, GPB_PXN.BanLuan, GPB_PXN.NgayTra, GPB_PXN.BacSiDoc, GPB_PXN.TruongKhoa,  GPB_DVYC.TenDVYC, GPB_DVYC.MaloaiDV, GPB_DONVI.TenloaiDV FROM " + user + ".GPB_DONVI INNER JOIN (" + user + ".GPB_DVYC INNER JOIN " + user + ".GPB_PXN ON GPB_DVYC.MaDVYC = GPB_PXN.DVYC) ON GPB_DONVI.MaloaiDV = GPB_DVYC.MaloaiDV WHERE GPB_PXN.SoGPB='" + textBoxSoGPB.Text.ToString().Trim() + "';"); 
				if(ads!= null )					
				{						
					DataRow[] r=ads.Tables[0].Select("SoGPB= '"+soGPB+"'");
					if(r.Length>0)
					{
						ThietlapFormLoad(false); // Cho mờ các Textbox khi thấy dữ liệu
						textBoxNgayNhan.Text= b.DateToString("dd/MM/yyyy",DateTime.Parse(r[0]["NgayNhan"].ToString()));
						txtBanluan.Text = r[0]["Banluan"].ToString();//DataBindings.Add("Text",dv,"BanLuan");
						txtChandoanlamsang.Text=r[0]["CDLS"].ToString();  //.DataBindings.Add("Text",dv,"");
						cbophai.Text=r[0]["GioiTinh"].ToString();//.DataBindings.Add("Text",dv,"GioiTinhBN");
						txtKetluan.Text=r[0]["LCDGPB"].ToString();//.DataBindings.Add("Text",dv,"LCDGPB");
						txtVithe.Text = r[0]["HAVT"].ToString();//DataBindings.Add("Text",dv,"HAVT");
						txtDaithe.Text=r[0]["HADT"].ToString();//DataBindi.Add("Text",dv,"HADT");
						txtNgaytra.Text=b.DateToString("dd/MM/yyyy",DateTime.Parse(r[0]["NgayTra"].ToString()));//DataBindings.Add("Text",dv,"NgayTra");
						txtbacsiyeucau.Text=r[0]["BSYC"].ToString();//DataBindings.Add("Text",dv,"BSYC");
						txtKhoaYC.Text=r[0]["DVYC"].ToString();
						if(r[0]["NhuomDB"].ToString()=="1")	checkBoxNhuomdacbiet.Checked=true;
						else 	checkBoxNhuomdacbiet.Checked=false;
						if(r[0]["STTT"].ToString() =="True")	checkBoxSTTT.Checked=true;
						else	checkBoxSTTT.Checked=false;						
						
						if (System.IO.File.Exists(r[0]["Anh"].ToString())) 
						{
							//checkBoxAnh.Checked=true;
							pictureBoxAnh.Image=Image.FromFile(r[0]["Anh"].ToString());
							pictureBoxAnh.Tag=r[0]["Anh"].ToString();
						}
						else
						{
							pictureBoxAnh.Image=null;
							pictureBoxAnh.Tag="";
						}
					}//cboBoPhan.SelectedValue=txtMaBP.Text;						
					//-----------------------------------------------------------------//
                    ads = k.get_data("Select GPB_VTSTXN.MaVTST, GPB_VTST.TenVTST, GPB_VTST.NameVTST FROM " + user + ".GPB_VTST INNER JOIN " + user + ".GPB_VTSTXN ON GPB_VTST.MaVTST = GPB_VTSTXN.MaVTST WHERE GPB_VTSTXN.SoGPB='" + textBoxSoGPB.Text.ToString().Trim() + "'");
					if(ads!=null) dtgVTST.DataSource=ads.Tables[0];
					//-----------------------------------------------------------------//											
                    dsChandoan = k.get_data("SELECT GPB_VTSTXN.MaVTST, GPB_VTST.TenVTST, GPB_VTSTXN.MaGPB, GPB_GPB.TenGPB, GPB_VTSTXN.MaSTTT, GPB_1.TenGPB AS TenSTTT FROM (" + user + ".GPB_GPB INNER JOIN (" + user + ".GPB_VTST INNER JOIN " + user + ".GPB_VTSTXN ON GPB_VTST.MaVTST = GPB_VTSTXN.MaVTST) ON GPB_GPB.MaGPB = GPB_VTSTXN.MaGPB) LEFT JOIN " + user + ".GPB_GPB AS GPB_1 ON GPB_VTSTXN.MaSTTT = GPB_1.MaGPB WHERE GPB_VTSTXN.SoGPB= '" + textBoxSoGPB.Text.ToString().Trim() + "' ");
					if(dsChandoan!=null)	dtgChandoan.DataSource=dsChandoan.Tables[0];
					//-----------------------------------------------------------------//
					// lấy các lần GPB của một bệnh nhân
					//Ds=k.get_data("Select SoGPB From GPB_PXN Where SoHS ='"+m_mabn+"'");
					//if(Ds!=null)
					loadTree(m_mabn);
					//===================================================================//
					LoadTenKhoaYC(); // Goi ten Khoa YC theo maKhoaYC
				//	LoadTenLoaiDV();
					//================================================================
					MessageBox.Show("Đã tồn tại GPB này ", LibMedi.AccessData.Msg);
				}
				else
				{
					return false;
				}
			}
			catch(Exception caught)
			{			
				MessageBox.Show(caught.Message);
				return false;
			}
			return true;			
		}		

		private void btnketthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnThem_Click(object sender, System.EventArgs e)
		{
			l_id=0;
			text_Clear();
			bUpdate=true;
			ThietlapFormLoad(true);
			EnalbeButton(false);
			Ena_button_Navigation(false);
            k.execute_data("delete  from " + user + ".GPB_XNHMMD1");
            k.execute_data("delete  from " + user + ".GPB_VTST1");
			if(loaibn.SelectedIndex==-1)
			{
				loaibn.Focus();
				SendKeys.Send("{F4}");
				return;
			}
			tabControl1.SelectedIndex=0;
			textBoxSoGPB.Text=b.getSogpb("GPB_PXN");
			txtmabn.Focus();
		}

		private void get_gpbtbed(string s_mabn)
		{
            sql = "select a.sogpb,c.tengpb,c.name from " + user + ".gpb_pxn a," + user + ".gpb_chandoan b," + user + ".gpb_gpb c where a.sogpb=b.sogpb and b.magpb=c.magpb and a.mabn='" + s_mabn + "'";
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows) kqst_first.Text=kqst_first.Text.Trim()+r["tengpb"].ToString()+",";
		}

		private void btnhuy_Click(object sender, System.EventArgs e)
		{
			if(textBoxSoGPB.TextLength!=0)
			{
				if(MessageBox.Show("Bạn muốn huỷ thông tin của số giải phẫu bệnh này ? ("+textBoxSoGPB.Text.ToString().Trim()+")",LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes )
				{
                    k.execute_data("Delete  From " + user + ".GPB_VTSTXN Where SoGPB='" + textBoxSoGPB.Text.ToString().Trim() + "'");
                    k.execute_data("Delete  From " + user + ".GPB_XNHMMD Where SoGPB = '" + textBoxSoGPB.Text.ToString().Trim() + "'");
                    k.execute_data("Delete  From " + user + ".GPB_VTSTHMMD Where SoGPB = '" + textBoxSoGPB.Text.ToString().Trim() + "'");
					try
					{
						k.execute_data("delete "+m.user+textBoxNgayNhan.Text.Substring(3,2)+textBoxNgayNhan.Text.Substring(8,2)+".v_vpkhoa where id in(select id_vpkhoa from gpb_pxn where sogpb='"+textBoxSoGPB.Text.ToString().Trim()+"')");
					}
					catch{};
                    k.execute_data("Delete  From " + user + ".GPB_PXN Where SoGPB ='" + textBoxSoGPB.Text.ToString().Trim() + "'");
					text_Clear();
				}
			}
			else MessageBox.Show("Hãy chọn số giải phẫu bệnh muốn huỷ!",LibMedi.AccessData.Msg);
		}

		private void btnBoQua_Click(object sender, System.EventArgs e)
		{
			text_Clear();
			ThietlapFormLoad(false);
			EnalbeButton(true);
			Ena_button_Navigation(false);
			btnLuu.Visible=true;
			btnLuu.Enabled=false;
            k.execute_data("delete  from " + user + ".GPB_XNHMMD1");
            k.execute_data("delete  from " + user + ".GPB_VTST1");
			tabPageYEUCAU.Focus();
			btnThem.Focus();
		}

		private void btnLuu_Click(object sender, System.EventArgs e)
		{
			s_sogpb=textBoxSoGPB.Text.Trim();
			if(!Kiemtra()) return;
			if(l_id==0)l_id=k.get_cap_id_gpb;
			if(!Kiemtrangay(txtNgaytra.Text.ToString())) return;
			if(bUpdate)
			{
                if (m.get_data("select * from " + user + ".gpb_pxn a where a.sogpb='" + s_sogpb + "'").Tables[0].Rows.Count > 0)
				{
					MessageBox.Show("Số giải phẫu bệnh này đã được dùng",LibMedi.AccessData.Msg);
					textBoxSoGPB.Focus();
					return;
				}
			}
			string m_madantoc=cbodantoc.SelectedValue.ToString();
			if(!k.updgpb_btdbn(m_mabn,txthoten.Text,txtNgaySinh.Text,m_madantoc,cbophai.SelectedIndex,txtdiachi.Text.Trim()+((mapx.Text.ToLower().IndexOf("không xác định")!=-1)?"":" - "+mapx.Text)+((quan.Text.ToLower().IndexOf("không xác định")!=-1)?"":" - "+quan.Text)+((tinh.Text.ToLower().IndexOf("không xác định")!=-1)?"":" - "+tinh.Text),Convert.ToInt16(cbohonhan.SelectedIndex)))
			{
				MessageBox.Show("Không cập nhật được thông tin hành chính",LibMedi.AccessData.Msg);
				return;
			}

			string mabacsidoc  = txtTenBS1.Text;
			int i_nhuomhe=(chkNhuom.Checked) ? 1 : 0;
			int i_nhuomdb=(checkBoxNhuomdacbiet.Checked) ? 1 : 0;
			int i_sttt=(checkBoxSTTT.Checked) ? 1 : 0;
			int i_somanh=(txtSomanh.Text.Trim()!="")?int.Parse(txtSomanh.Text):0;
			long id_vpkhoa=0;
			s_maql=decimal.Parse(ngayvao.SelectedValue.ToString());
			if(loaibn.SelectedIndex>0 && bCapnhatvp)
			{
                foreach (DataRow r in k.get_data("select id_vpkhoa from " + user + ".gpb_pxn where sogpb='" + s_sogpb + "'").Tables[0].Rows)
				{
					id_vpkhoa=long.Parse(r["id_vpkhoa"].ToString());
					break;
				}
				if(id_vpkhoa==0)id_vpkhoa=v.get_id_vpkhoa;
				upd_vpkhoa(long.Parse(s_maql.ToString()),id_vpkhoa);
			}

			if(!k.updgpb_pxn(l_id, s_sogpb,m_mabn,textBoxNgayNhan.Text.Trim(),txtKhoaYC.Text.Trim(),txtbacsiyeucau.Text.Trim(),txtChandoanlamsang.Text.Trim(),txtDaithe.Text.Trim(),txtVithe.Text.Trim(),i_nhuomdb,0,i_sttt,txtKetluan.Text.Trim(),txtBanluan.Text.Trim(),txtNgaytra.Text.Trim(),mabacsidoc,txtTruongkhoa.Text,m_mabn,s_maql,i_nhuomhe,mabsbp.Text,txtngaypha.Text,i_somanh,txtNgaykt.Text,mabstb.Text,chkPhuhop.Checked?1:0,id_vpkhoa))
			{
					MessageBox.Show("Không cập nhật được thông tin giải phẫu bệnh!",LibMedi.AccessData.Msg);
					return;
			}
			byte []Image1;
			byte []Image2;
			if(pictureBoxAnh.Tag.ToString().Trim()=="")
			{
				Image1=imagenone;
			}
			else Image1=(byte[])(pictureBoxAnh.Tag);
			if(pictureBoxAnh2.Tag.ToString().Trim()=="")
			{
				Image2=imagenone;
			}else Image2=(byte[])(pictureBoxAnh2.Tag);
			if (Image1.Length>0 || Image2.Length>0) k.updgpb_pxn(l_id, s_sogpb, s_maql, Image1,Image2);

			
            m.execute_data("delete from " + user + ".gpb_vtstxn a where a.sogpb='"+s_sogpb+"'");//a.id=" + l_id);
            m.execute_data("delete from " + user + ".gpb_vtsthmmd a where a.sogpb='"+s_sogpb+"'");//a.id=" + l_id);

             foreach (DataRow r in dsVtst.Tables[0].Rows)//dv.Table.Rows)
		    {
			    if(!k.updgpb_vtstxn(l_id, s_sogpb,r["mavtst"].ToString(),"","",r["malvtst"].ToString()))
			    {
				    MessageBox.Show("Không cập nhật được thông tin vị trí sinh thiết!",LibMedi.AccessData.Msg);
				    return;
			    }

			    if(!k.updgpb_vtsthmmd(l_id, s_sogpb,r["mavtst"].ToString(),r["malvtst"].ToString()))
			    {
				    MessageBox.Show("Không cập nhật được thông tin vị trí sinh thiết hóa mô miễn dịch!",LibMedi.AccessData.Msg);
				    return;
			    }
		    }
        
            m.execute_data("delete from " + user + ".gpb_xnhmmd a where a.sogpb='"+s_sogpb+"'");//a.id=" + l_id);
            foreach (DataRow r in dsNhuom.Tables[0].Rows)//dv1.Table.Rows)
			{
				if(!k.updgpb_xnhmmd(l_id, s_sogpb,r["mavtst"].ToString(),decimal.Parse(r["mahmmd"].ToString()),int.Parse(r["duongtinh"].ToString()),r["cuongdo"].ToString(),decimal.Parse(r["mucdo"].ToString()),r["ghichu"].ToString()))
				{
					MessageBox.Show("Không cập nhật được thông tin xét nghiệm hóa mô miễn dịch!",LibMedi.AccessData.Msg);
					return;
				}
			}
      
			if(!k.updgpb_ttkhac(l_id, textBoxSoGPB.Text.Trim(),tcls.Text.Trim(),kqst_first.Text.Trim(),nxdt.Text.Trim(),qtdt.Text.Trim()))
			{
				MessageBox.Show("Không cập nhật được thông tin chi tiết!",LibMedi.AccessData.Msg);
				return;
			}

            m.execute_data("delete from " + user + ".gpb_chandoan a where a.sogpb=" + l_id);

			try
			{
				if(dtgChandoan.DataSource!=null)
				{
					CurrencyManager cm2=(CurrencyManager)BindingContext[dtgChandoan.DataSource,dtgChandoan.DataMember];
					DataView dv2=(DataView)cm2.List;

					foreach(DataRow r in dv2.Table.Rows)
					{
						if(!k.updgpb_chandoan(l_id, s_sogpb,r["mavtst"].ToString(),r["magpb"].ToString(),r["masttt"].ToString()))
						{
							MessageBox.Show("Không cập nhật được thông tin chẩn đoán bệnh!",LibMedi.AccessData.Msg);
							return;	
						}
					}
				}
			}
			catch
			{
				MessageBox.Show("Không cập nhật được thông tin chẩn đoán","Thông báo");
			}
            k.execute_data("delete  from " + user + ".GPB_XNHMMD1");
            k.execute_data("delete  from " + user + ".GPB_VTST1");
        	loadTree(m_mabn);
			ThietlapFormLoad(false);
			EnalbeButton(true);
			btnThem.Focus();
		}
		
		private bool Kiemtra()
		{
			if(txtmabn.TextLength==0)
			{
				MessageBox.Show("Chưa nhập mã bệnh nhân!",LibMedi.AccessData.Msg);
				txtmabn.Focus();
				tabControl1.SelectedIndex=0;
				return false;
			}
			if(txtChandoanlamsang.Text=="")
			{
				MessageBox.Show("Nhập chẩn đoán từ khoa lâm sàng!",LibMedi.AccessData.Msg);
				tabControl1.SelectedIndex=0;
				txtChandoanlamsang.Focus();
				return false;
			}
			if(txtNgaySinh.TextLength==0)
			{				
				MessageBox.Show("Nhập năm sinh của bệnh nhân",LibMedi.AccessData.Msg);								
				tabControl1.SelectedIndex=0;
				txtNgaySinh.Focus();
				return false;
			}
			else
			{
				if(txtNgaySinh.TextLength !=4)
				{
					MessageBox.Show("Nhập năm sinh không đúng (1998)",LibMedi.AccessData.Msg);
					tabControl1.SelectedIndex=0;
					txtNgaySinh.Focus();	
					return false;
				}
				else
				{
					try
					{	
						int namsinh = int.Parse(txtNgaySinh.Text);		
						int namnay = int.Parse(DateTime.Today.Year.ToString());
						int tuoi = namnay-namsinh;
						if(tuoi >120)
						{
							MessageBox.Show("Nhập năm sinh không đúng");
							txtNgaySinh.Focus();
							tabControl1.SelectedIndex=0;
							return false;
						}
						
					}
					catch
					{		
						MessageBox.Show("Nhập năm sinh bằng 4 ký tự số (1983)");
						txtNgaySinh.Focus();			
						tabControl1.SelectedIndex=0;
						return false;
					}					
				}
			}
			//===================================================
			if(textBoxSoGPB.TextLength==0)
			{
				MessageBox.Show("Nhập số GPB",LibMedi.AccessData.Msg);
				tabControl1.SelectedIndex=0;
				textBoxSoGPB.Focus();
				return false;
			}
			//===================================================
			if(txtNgaytra.TextLength==0)
			{
				MessageBox.Show("Nhập ngày trả kết quả",LibMedi.AccessData.Msg);
				tabControl1.SelectedIndex=3;
				txtNgaytra.Focus();
				return false;
			}
			//===================================================			
			if(txtKetluan.TextLength==0)
			{
				MessageBox.Show("Nhập bàn luận giải phẫu bệnh!",LibMedi.AccessData.Msg);
				tabControl1.SelectedIndex=3;
				txtKetluan.Focus();
				return false;
			}
//			if(dtgVTST.VisibleRowCount==0)
			if(dtgVTST.DataSource==null)
			{
				MessageBox.Show("Chọn vị trí sinh thiết cần làm giải phẫu bệnh!",LibMedi.AccessData.Msg);
				tabControl1.SelectedIndex=0;
				listMavtst.Focus();
				return false;
			}
//			if(dtgChandoan[0,1].ToString()=="" || dtgChandoan.VisibleRowCount==0)
			if(dtgChandoan.DataSource==null)
			{
				MessageBox.Show("Nhập chẩn đoán giải phẫu bệnh!",LibMedi.AccessData.Msg);
				tabControl1.SelectedIndex=3;
				listChandoan.Focus();
				return false;
			}
			return true;
		}

		private void txtKetluan_Leave(object sender, System.EventArgs e)
		{
			Color_Leave(sender,e);
			lblchuandon.Visible = true;
		}

		private void txtKetluan_Enter(object sender, System.EventArgs e)
		{
			Color_Enter(sender,e);			
			lblchuandon.Visible=false;
		}

		private void buttonOK_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode== Keys.Enter)
			{
				SendKeys.Send("{Tab}");
			}
		}

		private void cmbLoaiBN_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter )
			{
				SendKeys.Send("{Tab}{F4}");
			}
		}
		
		private void buttonHuy_Click(object sender, System.EventArgs e)
		{
			if(textBoxSoGPB.TextLength!=0)
			{
				if(MessageBox.Show("Bạn muốn huỷ hết mọi thông tin của số GPB này ? ("+textBoxSoGPB.Text.ToString().Trim()+")","Chú ý ",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes )
				{
                    k.execute_data("Delete  From " + user + ".GPB_VTSTXN Where SoGPB='" + textBoxSoGPB.Text.ToString().Trim() + "'");
                    k.execute_data("Delete  From " + user + ".GPB_XNHMMD Where SoGPB = '" + textBoxSoGPB.Text.ToString().Trim() + "'");
                    k.execute_data("Delete  From " + user + ".GPB_VTSTHMMD Where SoGPB = '" + textBoxSoGPB.Text.ToString().Trim() + "'");
                    k.execute_data("Delete  From " + user + ".GPB_PXN Where SoGPB ='" + textBoxSoGPB.Text.ToString().Trim() + "'");
					text_Clear();
				}
			}
			else
			MessageBox.Show("Hãy chọn Số GPB muốn huỷ",LibMedi.AccessData.Msg);
		}

		//=============Ena or Unena buttons Thêm xóa sửa =====================================//
		private void EnalbeButton(bool ena)
		{
			btnSua.Enabled=ena;
			btnThem.Enabled=ena;			
			btnketthuc.Enabled=ena;
			btnBoQua.Enabled=!ena;
			btnLuu.Enabled=!ena;
			btnhuy.Enabled= ena;		
		}
        //===============Ena or Unena button thêm xóa sửa khi nhấn nút toàn bộ===============//
		private void Ena_button_Toanbo(bool ena)
		{
			btnSua.Enabled=!ena;
			btnThem.Enabled=ena;			
			btnketthuc.Enabled=ena;
			btnBoQua.Enabled=!ena;
			btnLuu.Enabled=ena;
		}

		private void buttonBoqua_Click(object sender, System.EventArgs e)
		{
			ThietlapFormLoad(false);
			EnalbeButton(true);
			Ena_button_Navigation(false);
			clear();
			text_Clear();
			btnLuu.Visible=true;
			btnLuu.Enabled=false;
            k.execute_data("delete  from " + user + ".GPB_XNHMMD1");
            k.execute_data("delete  from " + user + ".GPB_VTST1");
			btnketthuc.Focus();
		}
 
		private void txtTim_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) 	SendKeys.Send("{Tab}");		
		}

		private void rdoSoHS_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");						
		}

		private void rdosoGPB_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void text_Clear()
		{
			dtNgayvao.Clear();
			treeViewAll.Nodes.Clear();
			
			quan.SelectedIndex=-1;
			tinh.SelectedIndex=-1;
			cmbKhoaYC.SelectedIndex=-1;
			cmbMaBS.SelectedIndex=-1;
			cbophai.SelectedIndex=-1;
			

			dtgVTST.DataSource=null;
			cmbLoaist.SelectedIndex=-1;
			dtgVTSTDacBiet.DataSource=null;
			cmbMaVTST_DB.SelectedIndex=-1;
			cmbCuongdo.SelectedIndex=-1;
			dtgNhuom.DataSource=null;
			cmbPhuongphapnhuom.SelectedIndex=-1;
			dtgChandoan.DataSource=null;
			cmbTruongkhoa.SelectedIndex=-1;
			
			mapx.SelectedIndex=-1;
			cbohonhan.SelectedIndex=-1;
			cbodantoc.SelectedIndex =-1;
			
			textBoxNgayNhan.Clear();
			tenbs.Clear();
			listMavtst.Clear();
			textBoxSoGPB.Clear();				
			txtBanluan.Clear();
			txtChandoan.Clear();
			txtChandoanlamsang.Clear();
			txtDaithe.Clear();
			txtGhichu.Clear();
			txtKetluan.Clear();					
			txtNgaytra.Clear();
			txtTile.Clear();					
			txtVithe.Clear();
			txtVTST.Clear();
			txtKhoaYC.Clear();
			txtPhuongphapnhuom.Clear();
			txtMaVTSTDB.Clear();
			txtTenBS1.Clear();
			txtTruongkhoa.Clear();
			txtSTTT.Clear();
			txtMaVTST.Clear();
			txtmabn.Text="";
			txthoten.Text="";
			txtNgaySinh.Text="";			
			tuoi.Text="";
			para1.Text="";
			para2.Text="";
			para3.Text="";
			para4.Text="";
			sohs.Text="";
			txtdiachi.Text="";
			tcls.Text="";
			kqst_first.Text="";
			nxdt.Text="";
			qtdt.Text="";

			//checkBoxAnh.Checked=false;
			checkBoxDT.Checked=false;
			checkBoxNhuomdacbiet.Checked=false;
			checkBoxSTTT.Checked=false;
			dsNhuom.Clear();
			dsChandoan.Clear();
			dsVtst.Clear();
			dtChandoan.Clear();
			dtNgayvao.Clear();

			txtngaypha.Text="";
			txtNgaykt.Text="";
			mabsbp.Text="";
			mabstb.Text="";
			chkPhuhop.Checked=true;
			tenbstb.SelectedIndex=-1;
			tebbsbp.SelectedIndex=-1;
			txtSomanh.Text="0";
			//checkBoxAnh.Checked=false;
			pictureBoxAnh.Tag=pictureBoxAnh2.Tag="";
			pictureBoxAnh.Image=pictureBoxAnh2.Image=null;
		}

		private void ClearTextAdd()
		{
			treeViewAll.Nodes.Clear();
			
			listChandoan.Text="";
			cmbCuongdo.SelectedIndex=-1;
			cmbKhoaYC.SelectedIndex=-1;
			cmbMaBS.SelectedIndex=-1;
			cmbPhuongphapnhuom.SelectedIndex=-1;
			cmbSTTT.SelectedIndex=-1;			
			cmbTruongkhoa.SelectedIndex=-1;
			cmbLoaist.SelectedIndex=-1;

			tenbs.Clear();
			listMavtst.Clear();
			txtMaloai.Clear();
			txtBanluan.Clear();
			txtChandoan.Clear();
			txtChandoanlamsang.Clear();			
			txtDaithe.Clear();
			txtGhichu.Clear();
			txtKetluan.Clear();
			txtTile.Clear();					
			txtVithe.Clear();
			txtVTST.Clear();
			txtVTST1.Clear();
			txtKhoaYC.Clear();
			txtbacsiyeucau.Clear();
			txtPhuongphapnhuom.Clear();
			txtMaVTSTDB.Clear();
			txtTenBS1.Clear();
			txtTruongkhoa.Clear();
			txtSTTT.Clear();
			txtMaVTST.Clear();
			tcls.Text=kqst_first.Text=nxdt.Text=qtdt.Text="";

			checkBoxDT.Checked=false;
			checkBoxNhuomdacbiet.Checked=false;
			checkBoxSTTT.Checked=false;	
			
			dtgChandoan.DataSource=null;			
			dtgNhuom.DataSource=null;
			dtgVTST.DataSource=null;
			dtgVTST.DataSource=null;
			dtgVTSTDacBiet.DataSource=null;
		}
		
		private void frmGPB_Closed(object sender, System.EventArgs e)
		{
            k.execute_data("delete  from " + user + ".GPB_XNHMMD1");
            k.execute_data("delete  from " + user + ".GPB_VTST1");
		}

		private void LoadTenKhoaYC()
		{
            ads = k.get_data("Select MAKP,TENKP From " + user + ".BTDKP_BV Where MAKP = '" + txtKhoaYC.Text + "' ");
			if(ads!=null)
			{
				DataRow[] r=ads.Tables[0].Select("MAKP= "+txtKhoaYC.Text+" ");
				if(r.Length>0)
				{				
					cmbKhoaYC.Text= r[0]["TENKP"].ToString();	
				}
			}
		}

		private void buttonOK_DB_Sua_Click(object sender, System.EventArgs e)
		{
			if(l_id==0) l_id=k.get_cap_id_gpb;
			if(dsNhuom.Tables[0].Select("mahmmd='"+txtPhuongphapnhuom.Text.Trim()+"'").Length>0)
			{
				MessageBox.Show("Phương pháp hóa mô miễn dịch này đã nhập!",LibMedi.AccessData.Msg);
				cmbPhuongphapnhuom.Focus();
				return;
			}
			if(!k.updgpb_xnhmmd(l_id, textBoxSoGPB.Text.Trim(),txtMaVTST.Text.Trim(),decimal.Parse(cmbPhuongphapnhuom.SelectedValue.ToString()),checkBoxDT.Checked ? 1 : 0,cmbCuongdo.Text.ToString(),(txtTile.Text.ToString()!="") ? decimal.Parse(txtTile.Text.ToString()) : 0,txtGhichu.Text.Trim()))
			{
				MessageBox.Show("Lỗi cập nhật!",LibMedi.AccessData.Msg);
				return;
			}
            dsNhuom = k.get_data("select a.tenhmmd,a.mahmmd,b.duongtinh,b.mavtst,b.cuongdo,b.mucdo,b.ghichu from " + user + ".gpb_hmmd a inner join " + user + ".gpb_xnhmmd b on a.mahmmd=b.mahmmd where b.sogpb= '" + textBoxSoGPB.Text.ToString().Trim() + "' and b.mavtst='" + txtMaVTST.Text.ToString().Trim() + "'");
			dtgNhuom.DataSource = dsNhuom.Tables[0];
		}

		private bool Kiemtratextsua()
		{		
			//===================================================
			if(txtNgaytra.TextLength==0)
			{
				MessageBox.Show("Nhập ngày trả kết quả",LibMedi.AccessData.Msg);
				txtNgaytra.Focus();
				tabControl1.SelectedIndex=3;
				return false;
			}
			//===================================================		
			if(txtKetluan.TextLength==0)
			{
				MessageBox.Show("Nhập kết luận",LibMedi.AccessData.Msg);
				txtKetluan.Focus();
				tabControl1.SelectedIndex=3;
				return false;
			}	
			//===================================================		
			if(cmbMaBS.Text=="")		
			{
				MessageBox.Show("Nhập Bác Sĩ xem",LibMedi.AccessData.Msg);
				cmbMaBS.Focus();
				tabControl1.SelectedIndex=3;
				return false;
			}
			//===================================================		
			if(cmbTruongkhoa.Text=="")		
			{
				MessageBox.Show(cmbTruongkhoa.Text +"   "+txtTruongkhoa.Text);
				MessageBox.Show("Nhập Trưởng Khoa xem",LibMedi.AccessData.Msg);
				cmbTruongkhoa.Focus();
				tabControl1.SelectedIndex=3;
				return false;
			}
			return true;
		}

		private void cmbLoaiBN_Click(object sender, System.EventArgs e)
		{
			//SendKeys.Send("{f4}");
		}

		private void cmbKhoaYC_Click(object sender, System.EventArgs e)
		{
			SendKeys.Send("{f4}");
		}

		private void cmbPhai_Click(object sender, System.EventArgs e)
		{
			SendKeys.Send("{Tab}{f4}");
		}

		private void cmbPhuongphapnhuom_Click(object sender, System.EventArgs e)
		{
			SendKeys.Send("{Tab}{f4}");
		}

		private void cmbCuongdo_Click(object sender, System.EventArgs e)
		{
			SendKeys.Send("{Tab}{F4}");
		}

		private void cmbMaVTST_DB_Click(object sender, System.EventArgs e)
		{
			SendKeys.Send("{Tab}{F4}");
		}

		private void cmbTruongkhoa_Click(object sender, System.EventArgs e)
		{
			SendKeys.Send("{Tab}{F4}");
		}

		private void checkBoxSTTT_CheckStateChanged(object sender, System.EventArgs e)
		{
			if(checkBoxSTTT.Checked==true)
			{				
				cmbSTTT.Enabled=true;				
			}
			else
			{
				cmbSTTT.Enabled=false;
				cmbSTTT.Text="";
				txtSTTT.Text="";
			}
		}

		public void clear()
		{
			textBoxNgayNhan.DataBindings.Clear();
			textBoxSoGPB.DataBindings.Clear();
			txtBanluan.DataBindings.Clear();
			txtChandoanlamsang.DataBindings.Clear();
			cbophai.DataBindings.Clear();
			txtKetluan.DataBindings.Clear();
			txtVithe.DataBindings.Clear();
			txtDaithe.DataBindings.Clear();
			txtNgaytra.DataBindings.Clear();
			checkBoxNhuomdacbiet.DataBindings.Clear();
			checkBoxSTTT.DataBindings.Clear();
			//checkBoxAnh.DataBindings.Clear();
			lbPath_ofpicture.DataBindings.Clear();
			txtKhoaYC.DataBindings.Clear();			
		}

		private void cmbTruongkhoa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				btnLuu.Focus();
		}

		private void cmbChandoan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				SendKeys.Send("{Tab}");
			}
		}

		private void checkBoxSTTT_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode== Keys.Enter)
			{
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void cmbSTTT_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				SendKeys.Send("{Tab}");
			}
		}

		private void btnView_Click(object sender, System.EventArgs e)
		{
			this.Cursor=Cursors.WaitCursor;
			ds=k.get_bangkq(textBoxSoGPB.Text);
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Hãy chọn 1 phiếu để in !", b.Msg);
                this.Cursor = Cursors.Default;
                return;
            }
            if (chkXml.Checked)
            {
                if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
                ds.WriteXml("..\\xml\\gpb.xml", XmlWriteMode.WriteSchema);
            }					
			frmPrintAll f=new frmPrintAll();
			f.BangKQ(false,ds,m.Syte,m.Tenbv,sohs.Text,cmbMaBS.Text,cmbTruongkhoa.Text,tenbs.Text);
			f.ShowDialog();
			this.Cursor=Cursors.Default;
		}
		
		private void ena_print(bool b)
		{
			btnView.Enabled=b;			
		}
	
		private void GetNewSogpb()
		{
			textBoxSoGPB.Text=b.getSogpb("pxn");
		}		
		
		private void vis_upd(bool b)//true:update
		{
			btnLuu.Visible=!b;
			btnLuu.Enabled=!b;
		}

		private void AddEventMoveTab(Control con)
		{
			foreach(Control c in con.Controls)
			{
				if(c.GetType().ToString()!="System.Windows.Forms.Label")
				{
					if(c.Controls.Count!=0)
					//	c.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_keydown);			
					//else
						AddEventMoveTab(c);
				}
			}
		}

		private void cmbCuongdo_Validated(object sender, System.EventArgs e)
		{
			if(cmbCuongdo.SelectedIndex<0)cmbCuongdo.SelectedIndex=0;
		}
	
		private void txtNgaytra_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(txtNgaytra.Text!="")
			if(!d.isValidDate(txtNgaytra.Text))
			{
				MessageBox.Show("Ngày trả không hợp lệ !",b.Msg,MessageBoxButtons.OK,MessageBoxIcon.Warning);
				txtNgaytra.Focus();
			}		
		}

		private void txtsohs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void Color_Enter(object sender, System.EventArgs e)
		{			
			((Control)sender).BackColor = Color.Beige;
			if(((Control)sender).GetType()==typeof(NumericUpDown)) ((NumericUpDown)sender).Select(0,((NumericUpDown)sender).Value.ToString().Length);
			if(((Control)sender).GetType()==typeof(MaskedBox.MaskedBox)) ((MaskedBox.MaskedBox)sender).Select(0,0);
		}

		private void Color_Leave(object sender, System.EventArgs e)
		{
			((Control)sender).BackColor = System.Drawing.SystemColors.HighlightText;
		}

		private void txtmabn_Validated(object sender, System.EventArgs e)
		{
//			int ketqua ;
			if(txtmabn.Text!="") txtmabn.Text=txtmabn.Text.Trim().PadLeft(6,'0');
			else return;
			m_mabn=txtmabn1.Text.Trim()+txtmabn.Text;
			if(loaibn.SelectedIndex==-1)
			{
				MessageBox.Show("Chọn loại bệnh nhân cần làm giải phẫu bệnh!",LibMedi.AccessData.Msg);
				loaibn.Focus();
				return;
			}
			if( txtmabn.Text.ToString()=="")
			{
				btnBoQua.Focus();
				return;
			}
			else if(m_mabn.Substring(2,6)=="000000")
			{
				MessageBox.Show("Nhập mã bệnh nhân cần làm giải phẫu bệnh!",LibMedi.AccessData.Msg);
				txtmabn1.Focus();
				return;
			}
			else
			{
				if(!loadInfoBn(m_mabn)) 
				{
					MessageBox.Show("Bệnh nhân này chưa có thông tin!",b.Msg,MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
					return;
				}
//				ketqua = load_bn(m_mabn);
				if(!load_bn(m_mabn))
//				if(ketqua==-1)
				{
					if(MessageBox.Show("Bệnh nhân này chưa được chỉ định"+s_message+", nhập lại bệnh nhân khác! ",b.Msg,MessageBoxButtons.YesNo)==DialogResult.Yes)
					{
						buttonBoqua_Click(null,null);
						txtmabn.Focus();
						return;
					}
					else 
					{
						buttonBoqua_Click(null,null);
						btnketthuc.Focus();
					}
				}
				else
				{
					ClearTextAdd();
					loadTree(m_mabn);					
					ThietlapFormLoad(true);
					EnalbeButton(false);
					Ena_button_Navigation(false);
					tabControl1.SelectedIndex=0;
					textBoxNgayNhan.Text= b.Ngayhienhanh;	
					txtNgaytra.Text= b.Ngayhienhanh;
					txtmabn.Enabled=true;
					txtmabn1.Enabled=true;
					get_gpbtbed(m_mabn);
					textBoxSoGPB.Text=b.getSogpb("GPB_PXN");
					textBoxNgayNhan.Focus();
				}
			}
		}

		private bool loadInfoBn(string s_mabn)
		{
            sql = "select d.mabn,d.namsinh,d.phai as gioitinh,d.maqu,d.matt,d.maphuongxa,d.hoten,d.sonha,d.thon,d.madantoc,d.madantoc from " + user + ".btdbn d where d.mabn='" + s_mabn + "'";
			foreach (DataRow rr in m.get_data(sql).Tables[0].Rows)
			{
				txthoten.Text =rr["hoten"].ToString();
				txtNgaySinh.Text = rr["namsinh"].ToString();
				cbophai.SelectedIndex = int.Parse(rr["gioitinh"].ToString());
				txtdiachi.Text=rr["sonha"].ToString().Trim()+" "+rr["thon"].ToString().Trim();
				mapx.SelectedValue=rr["maphuongxa"].ToString().Trim();
				quan.SelectedValue=rr["maqu"].ToString().Trim();
				tinh.SelectedValue=rr["matt"].ToString().Trim();
				cbodantoc.SelectedValue=rr["madantoc"].ToString();
				return true;
			}
			return false;
		}

		private void load_loaibn(int l_loai)
		{
			//ngayvao.Items.Clear();
//			ngayvao.DataSource=null;
			ngayvao.DisplayMember="NGAY";
			ngayvao.ValueMember="MAQL";
			s_message="";
			DateTime m_tu=DateTime.Now.AddMonths(-2);
			DateTime m_den=DateTime.Now.AddMonths(1);
			string tu=m_tu.Day.ToString().PadLeft(2,'0')+"/"+m_tu.Month.ToString().PadLeft(2,'0')+"/"+m_tu.Year.ToString().PadLeft(4,'0');
			string den=m_den.Day.ToString().PadLeft(2,'0')+"/"+m_den.Month.ToString().PadLeft(2,'0')+"/"+m_den.Year.ToString().PadLeft(4,'0');
			
			if(l_loai==2)
			{
				sql="select a.mabn,a.maql,a.sovaovien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,b.para,";
				sql+=" substr(c.tuoivao,1,3)||case when substr(c.tuoivao,4,1)=0 then 'TU' else case when substr(c.tuoivao,4,1)=1 then 'TH' else case when substr(c.tuoivao,4,1)=2 then 'NG' else 'GI' end end end as tuoivao,";
				sql+=" d.namsinh,d.phai as gioitinh,d.maqu,d.matt,d.maphuongxa,d.hoten,d.sonha,d.thon,d.madantoc,e.tinhtrang,e.dantoc";
                sql += " from " + user + ".benhandt a," + user + ".ttkhamthai b," + user + ".lienhe c," + user + ".btdbn d," + user + ".gpb_btdbn e";
				sql+=" where a.mabn=d.mabn and a.maql=b.maql(+) and a.mabn='"+m_mabn+"' and a.maql=c.maql";
				sql+=" and a.mabn=e.mabn(+) and a.loaiba=1";
				//sql+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+tu+"','dd/mm/yy') and to_date('"+den+"','dd/mm/yy')";
				sql+=" order by a.maql desc";
				s_message=" khoa Điều trị lâm sàng";
			}
			//ads=m.get_data(sql);
			if(l_loai==1)
			{
				sql="select a.mabn,a.maql,a.soluutru as sovaovien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,b.para,";
				sql+=" substr(c.tuoivao,1,3)||decode(substr(c.tuoivao,4,1),'0','TU',decode(substr(c.tuoivao,4,1),'1','TH',decode(substr(c.tuoivao,4,1),'2','NG','GI'))) as tuoivao,";
				sql+=" d.namsinh,d.phai as gioitinh,d.maqu,d.matt,d.maphuongxa,d.hoten,d.sonha,d.thon,d.madantoc,e.tinhtrang,e.dantoc";
                sql += " from " + user + ".benhanngtr a," + user + ".ttkhamthai b," + user + ".lienhe c," + user + ".btdbn d," + user + ".gpb_btdbn e";
				sql+=" where a.mabn=d.mabn and a.maql=b.maql(+) and a.mabn='"+m_mabn+"' and a.maql=c.maql";
				sql+=" and a.mabn=e.mabn(+)";
				sql+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+tu+"','dd/mm/yy') and to_date('"+den+"','dd/mm/yy')";
				sql+=" order by a.maql desc";
				s_message=" khoa Điều trị ngoại trú";
			}
			//ads.Merge(m.get_data(sql));
			if(l_loai==0)
			{
				sql="select a.mabn,a.maql,a.sovaovien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,b.para,";
				sql+=" substr(c.tuoivao,1,3)||decode(substr(c.tuoivao,4,1),'0','TU',decode(substr(c.tuoivao,4,1),'1','TH',decode(substr(c.tuoivao,4,1),'2','NG','GI'))) as tuoivao,";
				sql+=" d.namsinh,d.phai as gioitinh,d.maqu,d.matt,d.maphuongxa,d.hoten,d.sonha,d.thon,d.madantoc,e.tinhtrang,e.dantoc,";
				sql+=" a.maicd,a.chandoan,a.makp,0 as id,'' as maba";
                sql += " from xxx.benhanpk a,xxx.ttkhamthai b,xxx.lienhe c," + user + ".btdbn d," + user + ".gpb_btdbn e";
				sql+=" where a.mabn=d.mabn and a.maql=b.maql(+) and a.mabn='"+m_mabn+"' and a.maql=c.maql";
				sql+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+tu+"','dd/mm/yy') and to_date('"+den+"','dd/mm/yy')";
				sql+=" and a.mabn=e.mabn(+)";
//				sql+=" and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('"+tu+"','dd/mm/yyyy')";
//				sql+=" and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+den+"','dd/mm/yyyy')";
				sql+=" order by a.maql desc";
				s_message=" phòng khám";
			}
			
			dtNgayvao=new DataTable();
			dtNgayvao=(l_loai>=1) ? m.get_data(sql).Tables[0] : (l_loai>=0) ? m.get_data_mmyy(sql,tu,den,false).Tables[0] : null;
			ngayvao.DataSource=dtNgayvao;
		}
		
		private int load_bn_cu(string mabn)
		{
			//ngayvao.DataSource=null;
			
			s_message="";
			DateTime m_tu=DateTime.Now.AddMonths(-2);
			DateTime m_den=DateTime.Now.AddMonths(1);
			string tu=m_tu.Day.ToString().PadLeft(2,'0')+"/"+m_tu.Month.ToString().PadLeft(2,'0')+"/"+m_tu.Year.ToString().PadLeft(4,'0');
			string den=m_den.Day.ToString().PadLeft(2,'0')+"/"+m_den.Month.ToString().PadLeft(2,'0')+"/"+m_den.Year.ToString().PadLeft(4,'0');
			
			if(s_loaibn==2)
			{
				sql="select a.mabn,a.maql,a.sovaovien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,b.para,";
				sql+=" substr(c.tuoivao,1,3)||case when substr(c.tuoivao,4,1)=0 then 'TU' else case when substr(c.tuoivao,4,1)=1 then 'TH' else case when substr(c.tuoivao,4,1)=2 then 'NG' else 'GI' end end end as tuoivao,e.tinhtrang";
                sql += " from " + user + ".benhandt a," + user + ".ttkhamthai b," + user + ".lienhe c," + user + ".gpb_btdbn e";
				sql+=" where a.maql=b.maql(+) and a.mabn='"+m_mabn+"' and a.maql=c.maql and a.mabn=e.mabn(+) and a.loaiba=1";
				//sql+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+tu+"','dd/mm/yy') and to_date('"+den+"','dd/mm/yy')";
				sql+=" order by a.maql desc";
				s_message=" khoa Điều trị lâm sàng";
			}
			//ads=m.get_data(sql);
			if(s_loaibn==1)
			{
				sql="select a.mabn,a.maql,a.soluutru as sovaovien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,b.para,";
				sql+=" substr(c.tuoivao,1,3)||case when substr(c.tuoivao,4,1)=0 then 'TU' else case when substr(c.tuoivao,4,1)=1 then 'TH' else case when substr(c.tuoivao,4,1)=2 then 'NG' else 'GI' end end end as tuoivao,e.tinhtrang";
                sql += " from " + user + ".benhanngtr a," + user + ".ttkhamthai b," + user + ".lienhe c," + user + ".gpb_btdbn e";
				sql+=" where a.maql=b.maql(+) and a.mabn='"+m_mabn+"' and a.maql=c.maql";
				sql+=" and a.mabn=e.mabn(+) ";
				//sql+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+tu+"','dd/mm/yy') and to_date('"+den+"','dd/mm/yy')";
				sql+=" order by a.maql desc";
				s_message=" khoa Điều trị ngoại trú";
			}
			//ads.Merge(m.get_data(sql));
			if(s_loaibn==0)
			{
				sql="select a.mabn,a.maql,a.sovaovien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,b.para,";
				sql+=" substr(c.tuoivao,1,3)||case when substr(c.tuoivao,4,1)=0 then 'TU' else case when substr(c.tuoivao,4,1)=1 then 'TH' else case when substr(c.tuoivao,4,1)=2 then 'NG' else 'GI' end end end as tuoivao,e.tinhtrang,";
				sql+=" a.maicd,a.chandoan,a.makp,0 as id,'' as maba";
                sql += " from xxx.benhanpk a,xxx.ttkhamthai b,xxx.lienhe c," + user + ".gpb_btdbn e";
				sql+=" where a.maql=b.maql(+) and a.mabn='"+m_mabn+"' and a.maql=c.maql";
				//sql+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+tu+"','dd/mm/yy') and to_date('"+den+"','dd/mm/yy')";
				sql+=" and a.mabn=e.mabn(+) ";
				sql+=" order by a.maql desc";
				s_message=" phòng khám";
			}
			
			dtNgayvao=new DataTable();
			dtNgayvao=(s_loaibn>=1) ? m.get_data(sql).Tables[0] : (s_loaibn>=0) ? m.get_data_mmyy(sql,tu,den,false).Tables[0] : null;
			ngayvao.DataSource=dtNgayvao;
			if(dtNgayvao.Rows.Count==0 || dtNgayvao==null) return -1;
			else
			{
				if(dtNgayvao.Rows[0]["tinhtrang"].ToString()!="")//Đã nhập giãi phẫu bệnh
				{
					cbohonhan.SelectedIndex=(dtNgayvao.Rows[0]["tinhtrang"].ToString()!="") ? int.Parse(dtNgayvao.Rows[0]["tinhtrang"].ToString()): 0;
					return 0;
				}
				else
				{
					cbohonhan.SelectedIndex=(dtNgayvao.Rows[0]["tinhtrang"].ToString()!="") ? int.Parse(dtNgayvao.Rows[0]["tinhtrang"].ToString()): 0;
					return 1;
				}
			}
		}

		private void textBoxNgayNhan_Validated(object sender, System.EventArgs e)
		{
			if (textBoxNgayNhan.Text=="")
			{
				textBoxNgayNhan.Focus();
				return;
			}
			textBoxNgayNhan.Text=textBoxNgayNhan.Text.Trim();
			if (textBoxNgayNhan.Text.Length<10)
			{
				MessageBox.Show(("Yêu cầu nhập Ngày nhận  !"),LibMedi.AccessData.Msg);
				textBoxNgayNhan.Focus();
				return;
			}
			if (!b.bNgay(textBoxNgayNhan.Text))
			{
				MessageBox.Show(("Ngày không hợp lệ !"));
				textBoxNgayNhan.Focus();
				return;
			}
			textBoxNgayNhan.Text=b.Ktngaygio(textBoxNgayNhan.Text,10);
//			if (b.maccesscon.get_tiepdon(m_mabn,textBoxNgayNhan.Text)==0)
//			{
//				MessageBox.Show(("Người bệnh này chưa qua đăng ký khám bệnh !"),LibMedi.AccessData.Msg);
//				buttonBoqua_Click(sender,e);
//				btnThem.Focus();
//				return; 
//			}
			if (!b.ngay(b.StringToDate(textBoxNgayNhan.Text.Substring(0,10)),DateTime.Now,songay))
			{
				MessageBox.Show("Ngày khám bệnh không hợp lệ so với khai báo hệ thống (" +songay.ToString()+")!",LibMedi.AccessData.Msg);
				textBoxNgayNhan.Focus();
				return;
			}
			SendKeys.Send("{F4}");
		}
		
		private void loadTree(string mabenhnhan)
		{
			sql="select a.id, b.hotenbn,to_char(a.ngaynhan,'dd/mm/yyyy') as ngaynhan,a.sohs,";
			sql+=" a.banluan,a.cdls,b.namsinh,b.gioitinh,b.tinhtrang,a.lcdgpb,a.havt,a.hadt,";
			sql+=" to_char(a.ngaytra,'dd/mm/yyyy') as ngaytra,a.bsyc,a.dvyc,a.bacsidoc,a.truongkhoa,";
			sql+=" a.sogpb,c.matt,c.maqu,c.maphuongxa,b.diachi,a.nhuomdb,a.sttt,a.anh1,a.anh2,d.tt_tcls,d.kq_sttd,d.nx_dtkst,d.qtdt,a.mabs_bp,a.mabs_tb,to_char(a.ngaybdpha,'dd/mm/yyyy') ngaybdpha,to_char(a.ngaykttb,'dd/mm/yyyy') ngaykttb,a.phuhop,a.somanh";
            sql += " from " + user + ".gpb_pxn a ," + user + ".gpb_btdbn b," + user + ".btdbn c," + user + ".gpb_ttkhac d";
			sql+=" where a.sohs= b.mabn and a.sohs=c.mabn and a.id=d.id(+)";
			if(mabenhnhan!=""&& mabenhnhan!=null)  sql+=" and sohs='"+mabenhnhan+"'";
			ds=k.get_data(sql);
			nodePXN node;
			treeViewAll.Nodes.Clear();
			foreach (DataRow rr in ds.Tables[0].Rows)
			{
				node= new nodePXN(rr);
				treeViewAll.Nodes.Add(node);				
			}
			treeViewAll.Enabled= true;
		}

		private void LoadDataSoGPBGrid(DataRow r)
		{
			try
			{		
				if(r!=null)
				{
					byte [] image ;
					MemoryStream memo ;
					Bitmap map ;
					//
					ThietlapFormLoad(false); 
					l_id=long.Parse(r["id"].ToString());
					txthoten.Text= r["HoTenBN"].ToString();
					textBoxNgayNhan.Text= r["NgayNhan"].ToString();
					txtmabn1.Text=r["SoHS"].ToString().Substring(0,2);
					txtmabn.Text=r["SoHS"].ToString().Substring(2,6); 
					txtBanluan.Text = r["Banluan"].ToString();
					txtChandoanlamsang.Text=r["CDLS"].ToString();
					txtNgaySinh.Text=r["NamSinh"].ToString();
					cbophai.SelectedIndex=int.Parse(r["GioiTinh"].ToString());
					cbohonhan.SelectedIndex=int.Parse(r["tinhtrang"].ToString());
					txtKetluan.Text=r["LCDGPB"].ToString();
					txtVithe.Text = r["HAVT"].ToString();
					txtDaithe.Text=r["HADT"].ToString();
					txtNgaytra.Text=r["NgayTra"].ToString();
					txtKhoaYC.Text=r["DVYC"].ToString();
					cmbKhoaYC.SelectedValue=r["DVYC"].ToString();
					txtbacsiyeucau.Text=r["BSYC"].ToString();
					tenbs.Text=k.get_tenbs(txtbacsiyeucau.Text.Trim());
					txtTenBS1.Text=r["bacsidoc"].ToString();
					cmbMaBS.SelectedValue=txtTenBS1.Text.Trim();					
					txtTruongkhoa.Text=r["truongkhoa"].ToString();
					cmbTruongkhoa.SelectedValue=txtTruongkhoa.Text.Trim();
					textBoxSoGPB.Text=r["SoGPB"].ToString();
					txtdiachi.Text=r["diachi"].ToString();
					tinh.SelectedValue=r["matt"].ToString().Trim();
					quan.SelectedValue=r["maqu"].ToString().Trim();
					mapx.SelectedValue=r["maphuongxa"].ToString().Trim();
					tcls.Text=r["tt_tcls"].ToString();
					kqst_first.Text=r["kq_sttd"].ToString();
					nxdt.Text=r["nx_dtkst"].ToString();
					qtdt.Text=r["qtdt"].ToString();
					//
					mabstb.Text=r["mabs_tb"].ToString();
					tenbstb.SelectedValue=mabstb.Text;
					mabsbp.Text=r["mabs_bp"].ToString();
					tebbsbp.SelectedValue=mabsbp.Text;
					txtSomanh.Text=r["somanh"].ToString();
					txtngaypha.Text=r["ngaybdpha"].ToString();
					txtNgaykt.Text=r["ngaykttb"].ToString();
					chkPhuhop.Checked=r["phuhop"].ToString()=="1";
					if(r["NhuomDB"].ToString()=="1")
						checkBoxNhuomdacbiet.Checked=true;
					else
						checkBoxNhuomdacbiet.Checked=false;
					if(r["STTT"].ToString()=="1")
						checkBoxSTTT.Checked=true;
					else
						checkBoxSTTT.Checked=false;

					
					try
					{
						image = new byte[0];
						image = (byte[])(r["anh1"]);
						memo = new MemoryStream(image);
						map = new Bitmap(Image.FromStream(memo));
						pictureBoxAnh.Image = (Bitmap)map;
						pictureBoxAnh.Tag = image;
					
						image = (byte[])(r["anh2"]);
						memo = new MemoryStream(image);
						map = new Bitmap(Image.FromStream(memo));
						pictureBoxAnh2.Image = (Bitmap)map;
						pictureBoxAnh2.Tag = image;
					}
					catch
					{
						pictureBoxAnh.Image=pictureBoxAnh2.Image=null;
						pictureBoxAnh.Tag=pictureBoxAnh2.Tag="";
					}
				}
                dsVtst = k.get_data("select a.mavtst,b.tenvtst,b.namevtst,a.malvtst from " + user + ".gpb_vtstxn a left join " + user + ".gpb_vtst b on a.mavtst=b.mavtst where a.sogpb='" + textBoxSoGPB.Text.ToString().Trim() + "'");
				if(dsVtst!=null)
				{
					dtgVTST.DataSource=dsVtst.Tables[0];
					dtgVTSTDacBiet.DataSource=dsVtst.Tables[0];
					cmbMaVTST_DB.DataSource=dsVtst.Tables[0];
				}

                dsNhuom = k.get_data("select a.tenhmmd,a.mahmmd,b.duongtinh,b.mavtst,b.cuongdo,b.mucdo,b.ghichu from " + user + ".gpb_hmmd a inner join " + user + ".gpb_xnhmmd b on a.mahmmd=b.mahmmd where b.sogpb= '" + textBoxSoGPB.Text.ToString().Trim() + "'");
				dtgNhuom.DataSource=dsNhuom.Tables[0];
				dtChandoan.Clear();
                sql = "select a.mavtst,c.tenvtst,a.magpb,b.tengpb,a.masttt,d.tengpb as tensttt from " + user + ".gpb_chandoan a," + user + ".gpb_gpb b," + user + ".gpb_vtst c," + user + ".gpb_gpb d where a.magpb=b.magpb and a.mavtst=c.mavtst and a.masttt=d.magpb(+) and a.sogpb='" + r["sogpb"].ToString() + "'";
				foreach(DataRow r2 in k.get_data(sql).Tables[0].Rows)
				{
					DataRow r1=dtChandoan.NewRow();
					r1["mavtst"]=r2["mavtst"].ToString();
					r1["tenvtst"]=r2["tenvtst"].ToString();
					r1["magpb"]=r2["magpb"].ToString();
					r1["tengpb"]=r2["tengpb"].ToString();
					r1["masttt"]=r2["masttt"].ToString();
					r1["tensttt"]=r2["tensttt"].ToString();
					dtChandoan.Rows.Add(r1);
					break;	
				}
				dtgChandoan.DataSource=dtChandoan;
				LoadTenKhoaYC();
			}
			catch(Exception caught)
			{			
				MessageBox.Show(caught.Message);
			}					
		}

		private void treeViewAll_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			nodePXN _node ;
			_node =(nodePXN) treeViewAll.SelectedNode; 
			LoadDataSoGPBGrid(_node.get_node());
			EnalbeButton(true);
		}

		private void txtChandoanlamsang_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{

		}

		private void txtNgaySinh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode== Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void cbophai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode== Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void txtdantoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode== Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void txthoten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			
			if (e.KeyCode== Keys.Enter)
			{
				if (txthoten.Text=="")
				{
					MessageBox.Show("Phải nhập tên !",b.Msg);
					txthoten.Focus();
				}
				else
					txtNgaySinh.Focus();
			}
		}

		private void cbodantoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode== Keys.Enter)
				SendKeys.Send("{Tab}");
		}

		private void dtgChandoan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode== Keys.Enter)
			{
				SendKeys.Send("{Tab}");
			}
		}

		private void txtKhoaYC_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode== Keys.Enter)
			{
				cmbKhoaYC.SelectedValue= txtKhoaYC.Text;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void cbohonhan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				ngayvao.Focus();
				SendKeys.Send("{F4}");
			}
		}

		private void loaibn_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.ActiveControl==loaibn)
			{
                sql = "select makp,tenkp from " + user + ".btdkp_bv where makp is not null";
				if(loaibn.SelectedIndex==2)
				{
					lblSohs.Text="Số vào viện";
					s_loaibn=2;
					sql+=" and loai=0";
				}
				if(loaibn.SelectedIndex==1)
				{
					lblSohs.Text="Số lưu trữ";
					s_loaibn=1;
				}
				if(loaibn.SelectedIndex==0)
				{
					lblSohs.Text="Số lưu trữ";
					s_loaibn=0;
					sql+=" and loai=1";
				}
				sql+=" order by makp";
				cmbKhoaYC.DataSource=m.get_data(sql).Tables[0];
			}
		}

		private void KeyDown_Enter(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				SendKeys.Send("{Tab}");
		}

		private void ngayvao_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int index_nv=ngayvao.SelectedIndex;
			if(index_nv!=-1)
			{
				try
				{
					if(dtNgayvao!=null &&dtNgayvao.Rows.Count>0)
					{
						sohs.Text=dtNgayvao.Rows[index_nv]["sovaovien"].ToString();
						string m_para=dtNgayvao.Rows[index_nv]["para"].ToString();
						para1.Text=m_para.Substring(0,2);
						para2.Text=m_para.Substring(2,2);
						para3.Text=m_para.Substring(4,2);
						para4.Text=m_para.Substring(6,2);
						tuoi.Text=dtNgayvao.Rows[index_nv]["tuoivao"].ToString();
						s_maql=decimal.Parse(dtNgayvao.Rows[index_nv]["maql"].ToString());
					}
				}
				catch
				{
					s_maql=0;
				}
			}
		}

		private void ngayvao_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				textBoxNgayNhan.Focus();
		}

		private void txtmabn1_Validated(object sender, System.EventArgs e)
		{
			txtmabn.Focus();
		}
		
		private void cmbLoaist_SelectedValueChanged(object sender, System.EventArgs e)
		{
			if(cmbLoaist.SelectedIndex!=-1) txtMaloai.Text=cmbLoaist.SelectedValue.ToString();
			else txtMaloai.Text="";
		}
		
		private void txtMaloai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}
		
		private void cmbKhoaYC_Validated(object sender, System.EventArgs e)
		{
			if(cmbKhoaYC.SelectedIndex!=-1)
			{
				if(loaibn.SelectedIndex!=0) 
				{
                    sql = "select a.maicd,a.chandoan from " + user + ".nhapkhoa a where a.makp='" + txtKhoaYC.Text.Trim() + "' and a.maql=" + s_maql + " order by id";
					//				else sql="select a.maicd,a.chandoan from benhandt a where a.makp='"+txtKhoaYC.Text.Trim()+"' and a.maql="+s_maql+" order by id";
					ads=m.get_data(sql);
					txtChandoanlamsang.Text=(ads.Tables[0].Rows.Count>0) ? ads.Tables[0].Rows[0]["chandoan"].ToString() : "";
					if(txtChandoanlamsang.Text!="") lblIcd.Text="("+ads.Tables[0].Rows[0]["maicd"].ToString()+")";
				}
			}
			else txtKhoaYC.Text="";
		}

		private void butOk_Cdgpb_Click(object sender, System.EventArgs e)
		{
			if(txtMaVTSTDB.TextLength==0 && bUpdate)
			{
				MessageBox.Show("Chọn vị trí sinh thiết bạn muốn sửa!",LibMedi.AccessData.Msg);
			}
			else
			{
				try
				{
					DataRow r =dtChandoan.NewRow();
					r["mavtst"]=txtMaVTSTDB.Text.Trim();
					r["tenvtst"]=cmbMaVTST_DB.Text;
					r["magpb"]=txtChandoan.Text.Trim();
					r["tengpb"]=listChandoan.Text;
					if(checkBoxSTTT.Checked) 
					{
						r["masttt"]=txtSTTT.Text.Trim();
						r["tensttt"]=cmbSTTT.Text;
					}
					dtChandoan.Rows.Add(r);
					dtgChandoan.DataSource=dtChandoan;
				}
				catch {}
			}
		}

		private void tcls_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.F2)
			{
				tcls.Text=k.get_viettat(tcls.Text.Trim());
				tcls.SelectionStart=tcls.Text.Trim().Length;
			}
		}

		private void kqst_first_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.F2)
			{
				kqst_first.Text=k.get_viettat(kqst_first.Text.Trim());
				kqst_first.SelectionStart=kqst_first.Text.Trim().Length;
			}
		}

		private void nxdt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.F2)
			{
				nxdt.Text=k.get_viettat(nxdt.Text.Trim());
				nxdt.SelectionStart=nxdt.Text.Trim().Length;
			}
		}

		private void txtDaithe_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.F2)
			{
				txtDaithe.Text=k.get_viettat(txtDaithe.Text.Trim());
				txtDaithe.SelectionStart=txtDaithe.Text.Trim().Length;
			}
		}

		private void txtVithe_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.F2)
			{
				txtVithe.Text=k.get_viettat(txtVithe.Text.Trim());
				txtVithe.SelectionStart=txtVithe.Text.Trim().Length;
			}
		}

		private void butMinus_Click(object sender, System.EventArgs e)
		{
			if(txtMaVTSTDB.TextLength==0 && bUpdate)
			{
				MessageBox.Show("Hãy chọn VTST muốn sửa từ bảng trên",LibMedi.AccessData.Msg);
			}
			else
			{
				try
				{
					int ind=dtgChandoan.CurrentRowIndex;
					dtChandoan.Rows.RemoveAt(ind);
					dtgChandoan.DataSource=dtChandoan;
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message,LibMedi.AccessData.Msg);
				}
			}
		}

		private void butNhuomMiinus_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(dtgNhuom.CurrentRowIndex!=-1 &&dtgVTSTDacBiet.CurrentRowIndex!=-1)
				{
					int ind=dtgNhuom.CurrentRowIndex;
					dsNhuom.Tables[0].Rows.RemoveAt(ind);
					dtgNhuom.DataSource = dsNhuom.Tables[0];
				}	
			}
			catch{}
		}

		private void checkBoxNhuomdacbiet_Click(object sender, System.EventArgs e)
		{
			if(checkBoxNhuomdacbiet.Checked) LoadTab_Dacbiet(true);
			else LoadTab_Dacbiet(false);
		}

		private void txtbacsiyeucau_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void bMinusVtst_Click(object sender, System.EventArgs e)
		{
			try
			{
				int ind=dtgVTST.CurrentRowIndex;
				if(ind!=-1 && ind<dsVtst.Tables[0].Rows.Count)
				{
					dsVtst.Tables[0].Rows.RemoveAt(ind);
					dtgVTST.DataSource=dsVtst.Tables[0];
				}
			}
			catch 
			{
				MessageBox.Show("Không hợp lệ!",LibMedi.AccessData.Msg);
				return;
			}
		}

		private void lblTimbn_Click(object sender, System.EventArgs e)
		{
			frmTimbn f = new frmTimbn();
			f.ShowDialog();
		}

		private void Filt_BsYeucau(string ten)
		{
			CurrencyManager cm = (CurrencyManager)BindingContext[lb_bs.DataSource];
			DataView dv = (DataView)cm.List;
			dv.RowFilter = "HOTEN LIKE '%" + ten + "%'";
			if (ten != "")
			{
				dv.RowFilter = "HOTEN LIKE '%" + ten + "%'";
			}
			else
			{
				dv.RowFilter = "";
			}
		}

		private void Filt_Mavtst(string ten)
		{
			CurrencyManager cm = (CurrencyManager)BindingContext[lstVitrist.DataSource];
			DataView dv = (DataView)cm.List;
			dv.RowFilter = "TENVTST LIKE '%" + ten + "%'";
			if (ten != "")
			{
				dv.RowFilter = "TENVTST LIKE '%" + ten + "%'";
			}
			else
			{
				dv.RowFilter = "";
			}
		}

		private void Filt_Chandoan(string ten)
		{
			CurrencyManager cm = (CurrencyManager)BindingContext[lstChandoan.DataSource];
			DataView dv = (DataView)cm.List;
			dv.RowFilter = "TENGPB LIKE '%" + ten + "%'";
			if (ten != "")
			{
				dv.RowFilter = "TENGPB LIKE '%" + ten + "%'";
			}
			else
			{
				dv.RowFilter = "";
			}
		}

		private void tenbs_TextChanged(object sender, System.EventArgs e)
		{
			Filt_BsYeucau(tenbs.Text.Trim());//272, 120
			lb_bs.BrowseToText(tenbs,txtbacsiyeucau,tcls,txtbacsiyeucau.Location.X+grpPhieumoi.Location.X,txtbacsiyeucau.Location.Y+grpPhieumoi.Location.Y+tenbs.Height,txtbacsiyeucau.Width+tenbs.Width,25);
			//lb_bs.BrowseToText(tenbs,txtbacsiyeucau,tcls,272,120,txtbacsiyeucau.Width+tenbs.Width,50);
		}

		private void tenbs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Up||e.KeyCode==Keys.Down) lb_bs.Focus();
			else if(e.KeyCode==Keys.Enter) 
			{
				lb_bs.Hide();
				SendKeys.Send("{Tab}");
			}
		}

		private void listMavtst_TextChanged(object sender, System.EventArgs e)
		{
			Filt_Mavtst(listMavtst.Text.Trim());
			lstVitrist.BrowseToText(listMavtst,txtVTST1,txtMaloai,txtVTST1.Location.X,txtVTST1.Location.Y+20,txtVTST1.Width+listMavtst.Width,25);
		}

		private void listMavtst_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Up||e.KeyCode==Keys.Down) 
			{
				lstVitrist.Focus();
			}
			if(e.KeyCode==Keys.Enter) lstVitrist.Hide();
		}

		private void listMavtst_Validated(object sender, System.EventArgs e)
		{

		}

		private void listChandoan_TextChanged(object sender, System.EventArgs e)
		{
			Filt_Chandoan(listChandoan.Text.Trim());
			lstChandoan.BrowseToText(listChandoan,txtChandoan,butOk_Cdgpb,txtChandoan.Location.X,txtChandoan.Location.Y+20,txtChandoan.Width+listChandoan.Width,25);
		}

		private void listChandoan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Up||e.KeyCode==Keys.Down) lstChandoan.Focus();
			if(e.KeyCode==Keys.Enter) lstChandoan.Hide();
		}

		private void btnSua_Click(object sender, System.EventArgs e)
		{
			if(txtmabn1.Text=="" || txtmabn1.Text.PadLeft(6,'0')=="000000")
			{
				MessageBox.Show("Chọn bệnh nhân cần sữa lại thông tin giải phẫu bệnh!",LibMedi.AccessData.Msg);
				txtmabn1.Focus();
				return;
			}
			else
			{
				if(treeViewAll.Nodes.Count==0)
				{
					MessageBox.Show("Bệnh nhân này chưa có thông tin giải phẫu bệnh!",LibMedi.AccessData.Msg);
					txtmabn1.Focus();
					return;
				}
				else
				{
					bUpdate=false;
					ThietlapFormLoad(true);
					EnalbeButton(false);
					textBoxNgayNhan.Focus();
				}
			}
		}

		private void KeyDown_qtdt(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.F2)
			{
				qtdt.Text=k.get_viettat(qtdt.Text.Trim());
				qtdt.SelectionStart=qtdt.Text.Trim().Length;
			}
			if(e.KeyCode==Keys.Enter) listMavtst.Focus();
		}

		private void txtmabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)SendKeys.Send("{Tab}");
		}

		private void mabsbp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)SendKeys.Send("{Tab}{F4}");
		}

		private void tebbsbp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)SendKeys.Send("{Tab}");
		}

		private void txtngaypha_Validated(object sender, System.EventArgs e)
		{
			if(!m.bNgay(txtngaypha.Text))
			{
				MessageBox.Show("Ngày pha không hợp lệ!");
				txtngaypha.Focus();
			}
		}

		private void txtNgaykt_Validated(object sender, System.EventArgs e)
		{
			if(!m.bNgay(txtNgaykt.Text))
			{
				MessageBox.Show("Ngày không hợp lệ!");
				txtNgaykt.Focus();
			}		
		}

		private void tenbstb_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(ActiveControl==tenbstb)
			{
				try
				{
					mabstb.Text=tenbstb.SelectedValue.ToString();
				}
				catch{mabstb.Text="";}
			}
		}

		private void tebbsbp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(ActiveControl==tebbsbp)
			{
				try
				{
					mabsbp.Text=tebbsbp.SelectedValue.ToString();
				}
				catch{mabsbp.Text="";}
			}
		}

		private void mabsbp_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tebbsbp.SelectedValue=mabsbp.Text;
			}
			catch{tebbsbp.SelectedIndex=-1;}
		}

		private void mabstb_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tenbstb.SelectedValue=mabstb.Text;
			}
			catch{tenbstb.SelectedIndex=-1;}
		}

		private void txtbacsiyeucau_Validated(object sender, System.EventArgs e)
		{
			DataRow r=m.getrowbyid(dsbs.Tables[0],"ma='"+txtbacsiyeucau.Text+"'");
			if(r!=null)tenbs.Text=r["hoten"].ToString();
		}	

		private bool load_bn(string mabn)
		{
			s_message="";sql="";			
            if (loaibn.SelectedIndex == 0)//pkham
            {
                DateTime m_tu = DateTime.Now.AddMonths(-1);
                DateTime m_den = DateTime.Now.AddMonths(1);
                while (DateTime.Compare(m_tu, m_den) <= 0)
                {
                    string s_mmyy = m_tu.Month.ToString().PadLeft(2, '0') + m_tu.Year.ToString().Substring(2);
                    if (m.bMmyy(s_mmyy))
                    {
                        if (sql != "") sql += " union all";
                        sql += " select b.mabn,b.maql,a.sovaovien,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngay,'' para, substr(c.tuoivao,1,3)||case when substr(c.tuoivao,4,1)=0 then 'TU' else case when substr(c.tuoivao,4,1)=1 then 'TH' else case when substr(c.tuoivao,4,1)=2 then 'NG' else 'GI' end end end as tuoivao,e.tinhtrang from " + user + s_mmyy + ".benhanpk a," + user + s_mmyy + ".v_chidinh b," + user + s_mmyy + ".lienhe c," + user + ".gpb_btdbn e where b.maql=a.maql(+) and b.maql=c.maql(+) and b.mabn=e.mabn(+) and b.mabn='" + m_mabn + "'";
                    }
                    m_tu = m_tu.AddMonths(1);
                }
            }
            else if (loaibn.SelectedIndex == 1)//ngoaitru
            {
                sql = "select distinct x.* from (select a.mabn,a.maql,a.sovaovien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,b.para,";
                sql += " substr(c.tuoivao,1,3)||case when substr(c.tuoivao,4,1)=0 then 'TU' else case when substr(c.tuoivao,4,1)=1 then 'TH' else case when substr(c.tuoivao,4,1)=2 then 'NG' else 'GI' end end end as tuoivao,e.tinhtrang";
                sql += " from " + user + ".benhanngtr a," + user + ".ttkhamthai b," + user + ".lienhe c," + user + ".gpb_btdbn e";
                sql += " where a.maql=b.maql(+) and a.mabn='" + m_mabn + "' and a.maql=c.maql and a.mabn=e.mabn(+) ";
                sql += ") x order by maql desc";
            }
            else//noi tru
            {
                sql = "select distinct x.* from (select a.mabn,a.maql,a.sovaovien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,b.para,";
                sql += " substr(c.tuoivao,1,3)||case when substr(c.tuoivao,4,1)=0 then 'TU' else case when substr(c.tuoivao,4,1)=1 then 'TH' else case when substr(c.tuoivao,4,1)=2 then 'NG' else 'GI' end end end as tuoivao,e.tinhtrang";
                sql += " from " + user + ".benhandt a," + user + ".ttkhamthai b," + user + ".lienhe c," + user + ".gpb_btdbn e";
                sql += " where a.maql=b.maql(+) and a.mabn='" + m_mabn + "' and a.maql=c.maql and a.mabn=e.mabn(+)";
                sql += ") x order by maql desc";   
            }           
			dtNgayvao=new DataTable();
			dtNgayvao=m.get_data(sql).Tables[0];
			if(dtNgayvao.Rows.Count==0) return false;
			ngayvao.DataSource=dtNgayvao;
			cbohonhan.SelectedIndex=(dtNgayvao.Rows[0]["tinhtrang"].ToString()!="") ? int.Parse(dtNgayvao.Rows[0]["tinhtrang"].ToString()): 0;
			return true;
		}
		private void upd_vpkhoa(long g_maql,long id)
		{
			if(k.b_hiendien(g_maql) && i_mavp>=0)
			{
				long idkhoa=0;
				int i_madoituong=2;
				string s_mabn=txtmabn1.Text.PadLeft(2,'0')+txtmabn.Text.PadLeft(6,'0');
				string s_makp=cmbKhoaYC.SelectedValue.ToString();
				string s_ngay=textBoxNgayNhan.Text;
				string s_mmyy=s_ngay.Substring(3,2)+s_ngay.Substring(8,2);
				string s_sophieu=textBoxSoGPB.Text;
				string sql="select * from " + user + ".nhapkhoa a," + user + ".benhandt b where a.maql=b.maql and a.maql="+g_maql.ToString()+" and a.makp='"+s_makp+"' order by id desc";
				DataSet tmp=new DataSet();
				tmp=k.get_data(sql);
				foreach(DataRow r in tmp.Tables[0].Rows)
				{
					idkhoa=long.Parse(r["id"].ToString());
					i_madoituong=int.Parse(r["madoituong"].ToString());
					break;
				}
				if(v.bMmyy(s_mmyy))v.upd_vpkhoa(id,s_mabn,g_maql,g_maql,idkhoa,s_ngay,s_makp,i_madoituong,i_mavp,1,dongia,vattu,-1,0);
			}
		}

		private void tcls_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void txtTenBS1_Validated(object sender, System.EventArgs e)
		{
			DataRow r=m.getrowbyid(dtbs,"ma='"+txtTenBS1.Text+"'");
			if(r!=null)
			{
				txtTenBS1.Text=r["ma"].ToString();
				cmbMaBS.SelectedValue=txtTenBS1.Text;
			}
			else 
			{
				cmbMaBS.Focus();
				cmbMaBS.DroppedDown=true;
			}
		}

		private void txtTruongkhoa_Validated(object sender, System.EventArgs e)
		{
			try
			{
				cmbTruongkhoa.SelectedValue=txtTruongkhoa.Text.PadLeft(4,'0');
				txtTruongkhoa.Text=cmbTruongkhoa.SelectedValue.ToString();
			}
			catch{}
		}

		private void txtTenBS1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				txtTenBS1_Validated(sender,e);
				SendKeys.Send("{Tab}");
			}
		}

		private void txtTruongkhoa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				txtTruongkhoa_Validated(sender,e);
				SendKeys.Send("{Tab}");
			}
		}

		private void lstVitrist_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				DataRow r = m.getrowbyid(dsListVtst.Tables[0],"mavtst='"+txtVTST1.Text.Trim()+"'");
				if(r!=null)
				{
					lbName.Text=r["namevtst"].ToString();
					txtDaithe.Text=r["hadt"].ToString();
					txtVithe.Text=r["havt"].ToString();
				}
			}
			catch{}		
		}

		private void lstChandoan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				DataRow r = m.getrowbyid(dsListChandoan.Tables[0],"magpb='"+txtChandoan.Text.Trim()+"'");
				if(r!=null)
				{
					txtKetluan.Text=r["nhanxet"].ToString();
					txtBanluan.Text=r["chandoan"].ToString();
				}
			}
			catch{}		
		}

		
		private void f_Chonhinh(PictureBox pic)
		{

			string file="",file_name="",afile_resize="";
			if(!Directory.Exists(file_resize))Directory.CreateDirectory(file_resize);
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Title = "Chọn hình ";
			dlg.Filter = "Files (*.jpg)|*.jpg|All Files (*.*)|*.*";
			dlg.RestoreDirectory=true;
			dlg.InitialDirectory = txtPath.Text;
			dlg.Multiselect=false;
			pic.Tag="";
			if (dlg.ShowDialog() == DialogResult.OK)			
			{
				file=dlg.FileName;
				if(File.Exists(file))
				{
					file_name=file.Substring(file.LastIndexOf("\\") +1);
					afile_resize=file_resize+"\\"+file_name;
					try
					{
						ImageResize(file,afile_resize , int.Parse(w.Value.ToString()), int.Parse(h.Value.ToString()));
					}
					catch{}
					
					System.IO.FileStream fstr = new System.IO.FileStream(afile_resize, System.IO.FileMode.Open, System.IO.FileAccess.Read);
					Anh = new byte[fstr.Length];
					fstr.Read(Anh, 0, System.Convert.ToInt32(fstr.Length));
					pic.Tag = Anh;
					pic.Image = Image.FromFile(afile_resize);
					fstr.Close();

				}
				
			}

		}

		private void buttonLoadHinh_Click_1(object sender, System.EventArgs e)
		{
			f_Chonhinh(pictureBoxAnh);
		}

		private void butChonPath_Click(object sender, System.EventArgs e)
		{
			try
			{
				string dir = System.IO.Directory.GetCurrentDirectory();
				OpenFileDialog opf = new OpenFileDialog();
				if(txtPath.Text!="") opf.InitialDirectory=txtPath.Text;
				opf.Multiselect = false;
				opf.Filter = "All (*.*)|*.*|*.Exe|*.Exe";
				DialogResult dr = opf.ShowDialog();
				if (dr == DialogResult.OK && opf.FileNames.Length > 0)
				{
					txtPath.Text = opf.FileName.ToString().Substring(0,opf.FileName.ToString().LastIndexOf("\\"));
				}
				System.Environment.CurrentDirectory = dir;
			}
			catch
			{ }
		}


		private void f_Save_Local()
		{
			DataSet ads = new DataSet();
			try
			{

				ads = new DataSet();
				ads.Tables.Add("Table");
				DataColumn dc = new DataColumn("id", typeof(string));
				ads.Tables[0].Columns.Add(dc);
				DataRow r = ads.Tables[0].NewRow();
				r["id"] = txtPath.Text;
				ads.Tables[0].Rows.Add(r);
				ads.WriteXml("..\\..\\..\\xml\\gpb_path.xml", XmlWriteMode.WriteSchema);
			}
			catch
			{
			}
			ads = new DataSet();
			try
			{

				ads = new DataSet();
				ads.Tables.Add("Table");
				DataColumn dc = new DataColumn("w", typeof(string));
				ads.Tables[0].Columns.Add(dc);
				dc = new DataColumn("h", typeof(string));
				ads.Tables[0].Columns.Add(dc);
				DataRow r = ads.Tables[0].NewRow();
				r["w"] = w.Value.ToString();
				r["h"] = h.Value.ToString();
				ads.Tables[0].Rows.Add(r);
				ads.WriteXml("..\\..\\..\\xml\\gpb_hinh.xml", XmlWriteMode.WriteSchema);
			}
			catch
			{
			}

		}
		

		private void f_Load_Local()
		{
			DataSet ads = new DataSet();
			try
			{
				ads.ReadXml("..\\..\\..\\xml\\gpb_path.xml");
				txtPath.Text = ads.Tables[0].Rows[0][0].ToString();
			}
			catch
			{
				ads = new DataSet();
				ads.Tables.Add("Table");
				DataColumn dc = new DataColumn("id", typeof(string));
				ads.Tables[0].Columns.Add(dc);
				DataRow r = ads.Tables[0].NewRow();
				txtPath.Text="..\\..\\..\\..\\picture";
				if(!Directory.Exists(txtPath.Text))Directory.CreateDirectory(txtPath.Text);
				r["id"] = txtPath.Text;
				ads.Tables[0].Rows.Add(r);
				ads.WriteXml("..\\..\\..\\xml\\gpb_path.xml", XmlWriteMode.WriteSchema);
			}
			ads=new DataSet();
			try
			{
				ads.ReadXml("..\\..\\..\\xml\\gpb_hinh.xml");
				w.Value = decimal.Parse(ads.Tables[0].Rows[0]["w"].ToString());
				h.Value = decimal.Parse(ads.Tables[0].Rows[0]["h"].ToString());
				ads.WriteXml("..\\..\\..\\xml\\gpb_benh.xml", XmlWriteMode.WriteSchema);
			}
			catch
			{
				w.Value=320;
				h.Value=240;
			}
		}

		private void frmGPB_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			f_Save_Local();
		}

		private void label43_Click(object sender, System.EventArgs e)
		{
			f_Chonhinh(pictureBoxAnh2);
		}

		private void ImageResize(string OriginalFileName, string ResizedFileName, int newWidth, int newHeight)
		{
			/* Định lại kích thước của 1 file ảnh */
			string oldImage = OriginalFileName;
			string newImage = ResizedFileName;

			Image currentImage = Image.FromFile(oldImage);
			Image imgPhoto = null;

			imgPhoto = FixedSize(currentImage, newWidth, newHeight);
			imgPhoto.Save(newImage, System.Drawing.Imaging.ImageFormat.Jpeg);
			imgPhoto.Dispose();
		}
		private Image FixedSize(Image imgPhoto, int Width, int Height)
		{
			int sourceWidth = imgPhoto.Width;
			int sourceHeight = imgPhoto.Height;
			int sourceX = 0;
			int sourceY = 0;
			int destX = 0;
			int destY = 0;

			float nPercent = 0;
			float nPercentW = 0;
			float nPercentH = 0;

			nPercentW = ((float)Width / (float)sourceWidth);
			nPercentH = ((float)Height / (float)sourceHeight);

			//if we have to pad the height pad both the top and the bottom
			//with the difference between the scaled height and the desired height
			if (nPercentH < nPercentW)
			{
				nPercent = nPercentH;
				destX = (int)((Width - (sourceWidth * nPercent)) / 2);
			}
			else
			{
				nPercent = nPercentW;
				destY = (int)((Height - (sourceHeight * nPercent)) / 2);
			}

			int destWidth = (int)(sourceWidth * nPercent);
			int destHeight = (int)(sourceHeight * nPercent);

			Bitmap bmPhoto = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
			bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

			Graphics grPhoto = Graphics.FromImage(bmPhoto);
			grPhoto.Clear(Color.Red);
			grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

			grPhoto.DrawImage(imgPhoto,
				new Rectangle(destX, destY, destWidth, destHeight),
				new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
				GraphicsUnit.Pixel);

			grPhoto.Dispose();
			return bmPhoto;

		}

		private void txtChandoan_Validated(object sender, System.EventArgs e)
		{
			try
			{
				DataRow r = m.getrowbyid(dsListChandoan.Tables[0],"magpb='"+txtChandoan.Text.Trim()+"'");
				if(r!=null)
				{
					txtChandoan.Text=r["magpb"].ToString();
					listChandoan.Text=r["tengpb"].ToString();
				}
				else listChandoan.Focus();
			}
			catch{}
		}

        private void qtdt_TextChanged(object sender, EventArgs e)
        {

        }
	}
}
