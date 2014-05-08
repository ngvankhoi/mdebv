using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibDuoc;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmXuatvien.
	/// </summary>
	public class frmNhapcls : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private LibMedi.AccessData m;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private DataSet ds=new DataSet();
		private string mmyy,s_userid,s_makp,s_mabn,s_msg,s_ngayvv,sql,s_madoituong,s_cls,s_hinh,user,xxx,nam;
		private int i_userid,i_loai,itable;
		private decimal l_id=0,l_maql=0,l_matd=0;
		private DataSet dsmau=new DataSet();
		private DataSet dslmau=new DataSet();
		private DataSet dsxml=new DataSet();
		private DataTable dtba=new DataTable();
		private DataTable dt=new DataTable();
		private DataTable dtbs=new DataTable();
		private DataTable dtytaphu=new DataTable();
		private DataTable dtxutri=new DataTable();
		private DataTable dtloai=new DataTable();
		private DataSet dsloai=new DataSet();
		private DataSet dsbnmoi=new DataSet();
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private MaskedTextBox.MaskedTextBox mabn2;
		private MaskedTextBox.MaskedTextBox mabn3;
		private System.Windows.Forms.Label label6;
		private MaskedTextBox.MaskedTextBox namsinh;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox loaituoi;
		private System.Windows.Forms.TextBox tuoi;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.Label label42;
		private MaskedTextBox.MaskedTextBox icd_chinh;
		private System.Windows.Forms.TextBox mabs;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.Button butTiep;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butKetthuc;
		private int songay=30,iTreem6,iTreem15,iKhamnhi;
        private bool b_Edit = false, b_Hoten = false, bAdmin, bChuyenkhoasan, bTiepdon, bBacsy, bTudong, bCapso = false;
		private System.ComponentModel.IContainer components;
		private bool b_khambenh,b_trongngoai,bChandoan;
		private System.Windows.Forms.ComboBox tennuoc;
		private System.Windows.Forms.ComboBox tendantoc;
		private System.Windows.Forms.ComboBox tentqx;
		private System.Windows.Forms.TextBox cholam;
		private System.Windows.Forms.TextBox thon;
		private System.Windows.Forms.TextBox mapxa2;
		private System.Windows.Forms.TextBox maqu2;
		private System.Windows.Forms.TextBox matt;
		private System.Windows.Forms.TextBox tqx;
		private System.Windows.Forms.TextBox manuoc;
		private System.Windows.Forms.TextBox madantoc;
		private System.Windows.Forms.TextBox mann;
		private System.Windows.Forms.ComboBox tennn;
		private System.Windows.Forms.ComboBox tenquan;
		private System.Windows.Forms.ComboBox tentinh;
		private System.Windows.Forms.ComboBox tenpxa;
		private MaskedTextBox.MaskedTextBox mapxa1;
		private MaskedTextBox.MaskedTextBox maqu1;
		private System.Windows.Forms.Label lcholam;
		private MaskedTextBox.MaskedTextBox sonha;
		private System.Windows.Forms.ComboBox phai;
		private System.Windows.Forms.Label lphai;
		private System.Windows.Forms.Label lmann;
		private System.Windows.Forms.Label lsonha;
		private System.Windows.Forms.Label lmanuoc;
		private System.Windows.Forms.Label lmadantoc;
		private System.Windows.Forms.Label lthon;
		private System.Windows.Forms.Label lmatt;
		private System.Windows.Forms.Label ltqx;
		private System.Windows.Forms.Label lmaphuongxa;
		private System.Windows.Forms.Label lmaqu;
		private System.Windows.Forms.ComboBox tenkp;
		private System.Windows.Forms.TextBox madoituong;
		private System.Windows.Forms.ComboBox tendoituong;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox makp;
		private System.Windows.Forms.Label label1;
		private MaskedBox.MaskedBox ngayvv;
		private MaskedBox.MaskedBox ngaysinh;
		private System.Windows.Forms.TreeView treeView1;
		private string s_icd_chinh;
		private System.Windows.Forms.TextBox cd_chinh;
		private LibList.List listICD;
		private System.Windows.Forms.Label label10;
		private LibList.List listBS;
		private System.Windows.Forms.TextBox tenbs;
		private System.Windows.Forms.Label lbl;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label55;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.ComboBox bnmoi;
		private System.Windows.Forms.Label l_bnmoi;
		private System.Windows.Forms.TextBox ghichu;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox ma;
		private System.Windows.Forms.ComboBox cmbma;
		private System.Windows.Forms.TextBox ten;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.CheckBox hen;
		private System.Windows.Forms.ComboBox denghi;
		private System.Windows.Forms.NumericUpDown hen_ngay;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox hen_ghichu;
		private System.Windows.Forms.Panel p_hen;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ComboBox loaibn;
		private LibList.List listpttt;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.ComboBox loai;
		private System.Windows.Forms.ComboBox ketqua;
		private System.Windows.Forms.TextBox bsth;
		private System.Windows.Forms.TextBox tenbsth;
		private LibList.List listBSTH;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox tenytaphu;
		private System.Windows.Forms.TextBox ytaphu;
		private System.Windows.Forms.Panel pmat;
		private LibList.List listytaphu;
		private System.Windows.Forms.CheckBox mp;
		private System.Windows.Forms.CheckBox mt;
		private System.Windows.Forms.ComboBox hen_loai;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.ComboBox thuoc;
		private System.Windows.Forms.CheckBox canquang;
		private System.Windows.Forms.CheckBox gayme;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.CheckBox chkXem;
		private DataTable dticd=new DataTable();
		private System.Windows.Forms.PictureBox pic;
		private System.Windows.Forms.Button butHinh;
        private MaskedBox.MaskedBox giovv;
        private Label label37;
        private dllReportM.Print print = new dllReportM.Print();

		public frmNhapcls(LibMedi.AccessData acc,string makp,string hoten,int userid,string _madoituong,string cls)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
			s_makp=makp;s_madoituong=_madoituong;
			s_userid=hoten;s_cls=cls;
			i_userid=userid;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhapcls));
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mabn2 = new MaskedTextBox.MaskedTextBox();
            this.mabn3 = new MaskedTextBox.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.namsinh = new MaskedTextBox.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.loaituoi = new System.Windows.Forms.ComboBox();
            this.tuoi = new System.Windows.Forms.TextBox();
            this.hoten = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.icd_chinh = new MaskedTextBox.MaskedTextBox();
            this.mabs = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.hen = new System.Windows.Forms.CheckBox();
            this.label52 = new System.Windows.Forms.Label();
            this.butTiep = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.tennuoc = new System.Windows.Forms.ComboBox();
            this.manuoc = new System.Windows.Forms.TextBox();
            this.lmanuoc = new System.Windows.Forms.Label();
            this.sonha = new MaskedTextBox.MaskedTextBox();
            this.tendantoc = new System.Windows.Forms.ComboBox();
            this.tentqx = new System.Windows.Forms.ComboBox();
            this.cholam = new System.Windows.Forms.TextBox();
            this.thon = new System.Windows.Forms.TextBox();
            this.mapxa2 = new System.Windows.Forms.TextBox();
            this.maqu2 = new System.Windows.Forms.TextBox();
            this.matt = new System.Windows.Forms.TextBox();
            this.tqx = new System.Windows.Forms.TextBox();
            this.madantoc = new System.Windows.Forms.TextBox();
            this.mann = new System.Windows.Forms.TextBox();
            this.tennn = new System.Windows.Forms.ComboBox();
            this.tenquan = new System.Windows.Forms.ComboBox();
            this.tentinh = new System.Windows.Forms.ComboBox();
            this.tenpxa = new System.Windows.Forms.ComboBox();
            this.mapxa1 = new MaskedTextBox.MaskedTextBox();
            this.lmaphuongxa = new System.Windows.Forms.Label();
            this.maqu1 = new MaskedTextBox.MaskedTextBox();
            this.lmaqu = new System.Windows.Forms.Label();
            this.lmatt = new System.Windows.Forms.Label();
            this.ltqx = new System.Windows.Forms.Label();
            this.lcholam = new System.Windows.Forms.Label();
            this.lthon = new System.Windows.Forms.Label();
            this.lsonha = new System.Windows.Forms.Label();
            this.lmadantoc = new System.Windows.Forms.Label();
            this.lmann = new System.Windows.Forms.Label();
            this.phai = new System.Windows.Forms.ComboBox();
            this.lphai = new System.Windows.Forms.Label();
            this.bnmoi = new System.Windows.Forms.ComboBox();
            this.loaibn = new System.Windows.Forms.ComboBox();
            this.ngayvv = new MaskedBox.MaskedBox();
            this.tenkp = new System.Windows.Forms.ComboBox();
            this.madoituong = new System.Windows.Forms.TextBox();
            this.tendoituong = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.l_bnmoi = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.ngaysinh = new MaskedBox.MaskedBox();
            this.cd_chinh = new System.Windows.Forms.TextBox();
            this.listICD = new LibList.List();
            this.label10 = new System.Windows.Forms.Label();
            this.listBS = new LibList.List();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.lbl = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.ghichu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ma = new System.Windows.Forms.TextBox();
            this.cmbma = new System.Windows.Forms.ComboBox();
            this.ten = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.denghi = new System.Windows.Forms.ComboBox();
            this.hen_ngay = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.hen_ghichu = new System.Windows.Forms.TextBox();
            this.p_hen = new System.Windows.Forms.Panel();
            this.hen_loai = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.listpttt = new LibList.List();
            this.label15 = new System.Windows.Forms.Label();
            this.loai = new System.Windows.Forms.ComboBox();
            this.ketqua = new System.Windows.Forms.ComboBox();
            this.bsth = new System.Windows.Forms.TextBox();
            this.tenbsth = new System.Windows.Forms.TextBox();
            this.listBSTH = new LibList.List();
            this.label16 = new System.Windows.Forms.Label();
            this.tenytaphu = new System.Windows.Forms.TextBox();
            this.ytaphu = new System.Windows.Forms.TextBox();
            this.pmat = new System.Windows.Forms.Panel();
            this.mt = new System.Windows.Forms.CheckBox();
            this.mp = new System.Windows.Forms.CheckBox();
            this.listytaphu = new LibList.List();
            this.label13 = new System.Windows.Forms.Label();
            this.thuoc = new System.Windows.Forms.ComboBox();
            this.canquang = new System.Windows.Forms.CheckBox();
            this.gayme = new System.Windows.Forms.CheckBox();
            this.butIn = new System.Windows.Forms.Button();
            this.chkXem = new System.Windows.Forms.CheckBox();
            this.pic = new System.Windows.Forms.PictureBox();
            this.butHinh = new System.Windows.Forms.Button();
            this.giovv = new MaskedBox.MaskedBox();
            this.label37 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.hen_ngay)).BeginInit();
            this.p_hen.SuspendLayout();
            this.pmat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(13, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "&Mã BN :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Location = new System.Drawing.Point(128, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Họ và tên :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Location = new System.Drawing.Point(344, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "Sinh ngày :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn2
            // 
            this.mabn2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn2.Location = new System.Drawing.Point(59, 34);
            this.mabn2.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mabn2.MaxLength = 2;
            this.mabn2.Name = "mabn2";
            this.mabn2.Size = new System.Drawing.Size(22, 21);
            this.mabn2.TabIndex = 1;
            this.mabn2.Validated += new System.EventHandler(this.mabn2_Validated);
            // 
            // mabn3
            // 
            this.mabn3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabn3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn3.Location = new System.Drawing.Point(83, 34);
            this.mabn3.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mabn3.MaxLength = 6;
            this.mabn3.Name = "mabn3";
            this.mabn3.Size = new System.Drawing.Size(45, 21);
            this.mabn3.TabIndex = 2;
            this.mabn3.Validated += new System.EventHandler(this.mabn3_Validated);
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Location = new System.Drawing.Point(464, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 9;
            this.label6.Text = "Năm sinh :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // namsinh
            // 
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(528, 34);
            this.namsinh.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.namsinh.MaxLength = 4;
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(34, 21);
            this.namsinh.TabIndex = 5;
            this.namsinh.Validated += new System.EventHandler(this.namsinh_Validated);
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.Location = new System.Drawing.Point(555, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 23);
            this.label7.TabIndex = 16;
            this.label7.Text = "Tuổi :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loaituoi
            // 
            this.loaituoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaituoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loaituoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaituoi.Items.AddRange(new object[] {
            "Tuổi",
            "Tháng",
            "Ngày",
            "Giờ"});
            this.loaituoi.Location = new System.Drawing.Point(622, 34);
            this.loaituoi.Name = "loaituoi";
            this.loaituoi.Size = new System.Drawing.Size(58, 21);
            this.loaituoi.TabIndex = 7;
            this.loaituoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loaituoi_KeyDown);
            // 
            // tuoi
            // 
            this.tuoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuoi.Location = new System.Drawing.Point(592, 34);
            this.tuoi.MaxLength = 3;
            this.tuoi.Name = "tuoi";
            this.tuoi.Size = new System.Drawing.Size(28, 21);
            this.tuoi.TabIndex = 6;
            this.tuoi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tuoi_KeyPress);
            this.tuoi.Validated += new System.EventHandler(this.tuoi_Validated);
            this.tuoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tuoi_KeyDown);
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(192, 34);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(158, 21);
            this.hoten.TabIndex = 3;
            this.hoten.Validated += new System.EventHandler(this.hoten_Validated);
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
            // 
            // label42
            // 
            this.label42.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label42.Location = new System.Drawing.Point(276, 181);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(72, 23);
            this.label42.TabIndex = 20;
            this.label42.Text = "Chẩn đoán :";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // icd_chinh
            // 
            this.icd_chinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_chinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_chinh.Location = new System.Drawing.Point(344, 181);
            this.icd_chinh.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_chinh.MaxLength = 9;
            this.icd_chinh.Name = "icd_chinh";
            this.icd_chinh.Size = new System.Drawing.Size(59, 21);
            this.icd_chinh.TabIndex = 37;
            this.icd_chinh.Validated += new System.EventHandler(this.icd_chinh_Validated);
            this.icd_chinh.TextChanged += new System.EventHandler(this.icd_chinh_TextChanged);
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(59, 204);
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(38, 21);
            this.mabs.TabIndex = 39;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // label49
            // 
            this.label49.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label49.Location = new System.Drawing.Point(5, 318);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(58, 23);
            this.label49.TabIndex = 117;
            this.label49.Text = "Y Bác sĩ :";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hen
            // 
            this.hen.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.hen.Location = new System.Drawing.Point(59, 460);
            this.hen.Name = "hen";
            this.hen.Size = new System.Drawing.Size(51, 24);
            this.hen.TabIndex = 55;
            this.hen.Text = "Hẹn";
            this.hen.CheckedChanged += new System.EventHandler(this.hen_CheckedChanged);
            this.hen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hen_KeyDown);
            // 
            // label52
            // 
            this.label52.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label52.Location = new System.Drawing.Point(8, 11);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(152, 23);
            this.label52.TabIndex = 141;
            this.label52.Text = "I. HÀNH CHÍNH :";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butTiep
            // 
            this.butTiep.BackColor = System.Drawing.Color.Transparent;
            this.butTiep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTiep.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butTiep.Image = ((System.Drawing.Image)(resources.GetObject("butTiep.Image")));
            this.butTiep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTiep.Location = new System.Drawing.Point(211, 496);
            this.butTiep.Name = "butTiep";
            this.butTiep.Size = new System.Drawing.Size(70, 25);
            this.butTiep.TabIndex = 59;
            this.butTiep.Text = "&Tiếp";
            this.butTiep.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butTiep.UseVisualStyleBackColor = false;
            this.butTiep.Click += new System.EventHandler(this.butTiep_Click);
            // 
            // butLuu
            // 
            this.butLuu.BackColor = System.Drawing.Color.Transparent;
            this.butLuu.Enabled = false;
            this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLuu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(281, 496);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 57;
            this.butLuu.Text = "&Lưu";
            this.butLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butLuu.UseVisualStyleBackColor = false;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.BackColor = System.Drawing.Color.Transparent;
            this.butBoqua.Enabled = false;
            this.butBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butBoqua.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(351, 496);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 58;
            this.butBoqua.Text = "Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.UseVisualStyleBackColor = false;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.BackColor = System.Drawing.Color.Transparent;
            this.butHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butHuy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(421, 496);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 61;
            this.butHuy.Text = "&Hủy";
            this.butHuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butHuy.UseVisualStyleBackColor = false;
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.BackColor = System.Drawing.Color.Transparent;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(561, 496);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 62;
            this.butKetthuc.Text = "Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.UseVisualStyleBackColor = false;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // tennuoc
            // 
            this.tennuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennuoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tennuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennuoc.Location = new System.Drawing.Point(539, 57);
            this.tennuoc.Name = "tennuoc";
            this.tennuoc.Size = new System.Drawing.Size(141, 21);
            this.tennuoc.TabIndex = 14;
            this.tennuoc.SelectedIndexChanged += new System.EventHandler(this.tennuoc_SelectedIndexChanged);
            this.tennuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennuoc_KeyDown);
            // 
            // manuoc
            // 
            this.manuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manuoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.manuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manuoc.Location = new System.Drawing.Point(513, 57);
            this.manuoc.Name = "manuoc";
            this.manuoc.Size = new System.Drawing.Size(24, 21);
            this.manuoc.TabIndex = 13;
            this.manuoc.Validated += new System.EventHandler(this.manuoc_Validated);
            this.manuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manuoc_KeyDown);
            // 
            // lmanuoc
            // 
            this.lmanuoc.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lmanuoc.Location = new System.Drawing.Point(449, 55);
            this.lmanuoc.Name = "lmanuoc";
            this.lmanuoc.Size = new System.Drawing.Size(64, 23);
            this.lmanuoc.TabIndex = 65;
            this.lmanuoc.Text = "Quốc tịch :";
            this.lmanuoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sonha
            // 
            this.sonha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sonha.Location = new System.Drawing.Point(728, 57);
            this.sonha.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sonha.MaxLength = 10;
            this.sonha.Name = "sonha";
            this.sonha.Size = new System.Drawing.Size(56, 21);
            this.sonha.TabIndex = 15;
            // 
            // tendantoc
            // 
            this.tendantoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendantoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tendantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendantoc.Location = new System.Drawing.Point(328, 57);
            this.tendantoc.Name = "tendantoc";
            this.tendantoc.Size = new System.Drawing.Size(126, 21);
            this.tendantoc.TabIndex = 12;
            this.tendantoc.SelectedIndexChanged += new System.EventHandler(this.tendantoc_SelectedIndexChanged);
            this.tendantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendantoc_KeyDown);
            // 
            // tentqx
            // 
            this.tentqx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tentqx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tentqx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tentqx.Location = new System.Drawing.Point(372, 80);
            this.tentqx.Name = "tentqx";
            this.tentqx.Size = new System.Drawing.Size(225, 21);
            this.tentqx.TabIndex = 18;
            this.tentqx.SelectedIndexChanged += new System.EventHandler(this.tentqx_SelectedIndexChanged);
            this.tentqx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentqx_KeyDown);
            // 
            // cholam
            // 
            this.cholam.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cholam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cholam.Location = new System.Drawing.Point(645, 103);
            this.cholam.Name = "cholam";
            this.cholam.Size = new System.Drawing.Size(141, 21);
            this.cholam.TabIndex = 27;
            this.cholam.Validated += new System.EventHandler(this.cholam_Validated);
            this.cholam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cholam_KeyDown);
            // 
            // thon
            // 
            this.thon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thon.Location = new System.Drawing.Point(58, 80);
            this.thon.Name = "thon";
            this.thon.Size = new System.Drawing.Size(212, 21);
            this.thon.TabIndex = 16;
            this.thon.Validated += new System.EventHandler(this.thon_Validated);
            this.thon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thon_KeyDown);
            // 
            // mapxa2
            // 
            this.mapxa2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapxa2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapxa2.Location = new System.Drawing.Point(364, 103);
            this.mapxa2.Name = "mapxa2";
            this.mapxa2.Size = new System.Drawing.Size(23, 21);
            this.mapxa2.TabIndex = 25;
            this.mapxa2.Validated += new System.EventHandler(this.mapxa2_Validated);
            this.mapxa2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mapxa2_KeyDown);
            // 
            // maqu2
            // 
            this.maqu2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maqu2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maqu2.Location = new System.Drawing.Point(87, 103);
            this.maqu2.Name = "maqu2";
            this.maqu2.Size = new System.Drawing.Size(23, 21);
            this.maqu2.TabIndex = 22;
            this.maqu2.Validated += new System.EventHandler(this.maqu2_Validated);
            this.maqu2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maqu2_KeyDown);
            // 
            // matt
            // 
            this.matt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.matt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matt.Location = new System.Drawing.Point(646, 80);
            this.matt.MaxLength = 3;
            this.matt.Name = "matt";
            this.matt.Size = new System.Drawing.Size(27, 21);
            this.matt.TabIndex = 19;
            this.matt.Validated += new System.EventHandler(this.matt_Validated);
            this.matt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matt_KeyDown);
            // 
            // tqx
            // 
            this.tqx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tqx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tqx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tqx.Location = new System.Drawing.Point(323, 80);
            this.tqx.Name = "tqx";
            this.tqx.Size = new System.Drawing.Size(48, 21);
            this.tqx.TabIndex = 17;
            this.tqx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tqx_KeyDown);
            // 
            // madantoc
            // 
            this.madantoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madantoc.Location = new System.Drawing.Point(302, 57);
            this.madantoc.Name = "madantoc";
            this.madantoc.Size = new System.Drawing.Size(24, 21);
            this.madantoc.TabIndex = 11;
            this.madantoc.Validated += new System.EventHandler(this.madantoc_Validated);
            this.madantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madantoc_KeyDown);
            // 
            // mann
            // 
            this.mann.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mann.Location = new System.Drawing.Point(59, 57);
            this.mann.Name = "mann";
            this.mann.Size = new System.Drawing.Size(22, 21);
            this.mann.TabIndex = 9;
            this.mann.Validated += new System.EventHandler(this.mann_Validated);
            this.mann.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mann_KeyDown);
            // 
            // tennn
            // 
            this.tennn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tennn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennn.Location = new System.Drawing.Point(83, 57);
            this.tennn.Name = "tennn";
            this.tennn.Size = new System.Drawing.Size(173, 21);
            this.tennn.TabIndex = 10;
            this.tennn.SelectedIndexChanged += new System.EventHandler(this.tennn_SelectedIndexChanged);
            this.tennn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennn_KeyDown);
            // 
            // tenquan
            // 
            this.tenquan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenquan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenquan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenquan.Location = new System.Drawing.Point(112, 103);
            this.tenquan.Name = "tenquan";
            this.tenquan.Size = new System.Drawing.Size(138, 21);
            this.tenquan.TabIndex = 23;
            this.tenquan.SelectedIndexChanged += new System.EventHandler(this.tenquan_SelectedIndexChanged);
            this.tenquan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenquan_KeyDown);
            // 
            // tentinh
            // 
            this.tentinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tentinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tentinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tentinh.Location = new System.Drawing.Point(674, 80);
            this.tentinh.Name = "tentinh";
            this.tentinh.Size = new System.Drawing.Size(112, 21);
            this.tentinh.TabIndex = 20;
            this.tentinh.SelectedIndexChanged += new System.EventHandler(this.tentinh_SelectedIndexChanged);
            this.tentinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentinh_KeyDown);
            // 
            // tenpxa
            // 
            this.tenpxa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenpxa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenpxa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenpxa.Location = new System.Drawing.Point(389, 103);
            this.tenpxa.Name = "tenpxa";
            this.tenpxa.Size = new System.Drawing.Size(184, 21);
            this.tenpxa.TabIndex = 26;
            this.tenpxa.SelectedIndexChanged += new System.EventHandler(this.tenpxa_SelectedIndexChanged);
            this.tenpxa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenpxa_KeyDown);
            // 
            // mapxa1
            // 
            this.mapxa1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapxa1.Enabled = false;
            this.mapxa1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapxa1.Location = new System.Drawing.Point(323, 103);
            this.mapxa1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mapxa1.MaxLength = 5;
            this.mapxa1.Name = "mapxa1";
            this.mapxa1.Size = new System.Drawing.Size(40, 21);
            this.mapxa1.TabIndex = 24;
            // 
            // lmaphuongxa
            // 
            this.lmaphuongxa.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lmaphuongxa.Location = new System.Drawing.Point(252, 101);
            this.lmaphuongxa.Name = "lmaphuongxa";
            this.lmaphuongxa.Size = new System.Drawing.Size(72, 23);
            this.lmaphuongxa.TabIndex = 77;
            this.lmaphuongxa.Text = "Phường/Xã :";
            this.lmaphuongxa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // maqu1
            // 
            this.maqu1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maqu1.Enabled = false;
            this.maqu1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maqu1.Location = new System.Drawing.Point(58, 103);
            this.maqu1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.maqu1.MaxLength = 3;
            this.maqu1.Name = "maqu1";
            this.maqu1.Size = new System.Drawing.Size(27, 21);
            this.maqu1.TabIndex = 21;
            // 
            // lmaqu
            // 
            this.lmaqu.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lmaqu.Location = new System.Drawing.Point(-20, 101);
            this.lmaqu.Name = "lmaqu";
            this.lmaqu.Size = new System.Drawing.Size(80, 23);
            this.lmaqu.TabIndex = 76;
            this.lmaqu.Text = "Quận/H :";
            this.lmaqu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmatt
            // 
            this.lmatt.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lmatt.Location = new System.Drawing.Point(591, 80);
            this.lmatt.Name = "lmatt";
            this.lmatt.Size = new System.Drawing.Size(56, 23);
            this.lmatt.TabIndex = 75;
            this.lmatt.Text = "Tỉnh/TP :";
            this.lmatt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ltqx
            // 
            this.ltqx.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.ltqx.Location = new System.Drawing.Point(252, 80);
            this.ltqx.Name = "ltqx";
            this.ltqx.Size = new System.Drawing.Size(72, 23);
            this.ltqx.TabIndex = 74;
            this.ltqx.Text = "T/Q/PXã :";
            this.ltqx.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lcholam
            // 
            this.lcholam.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lcholam.Location = new System.Drawing.Point(575, 101);
            this.lcholam.Name = "lcholam";
            this.lcholam.Size = new System.Drawing.Size(72, 23);
            this.lcholam.TabIndex = 73;
            this.lcholam.Text = "Nơi làm việc :";
            this.lcholam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lthon
            // 
            this.lthon.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lthon.Location = new System.Drawing.Point(-12, 80);
            this.lthon.Name = "lthon";
            this.lthon.Size = new System.Drawing.Size(72, 23);
            this.lthon.TabIndex = 72;
            this.lthon.Text = "Thôn, phố :";
            this.lthon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lsonha
            // 
            this.lsonha.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lsonha.Location = new System.Drawing.Point(664, 55);
            this.lsonha.Name = "lsonha";
            this.lsonha.Size = new System.Drawing.Size(64, 23);
            this.lsonha.TabIndex = 70;
            this.lsonha.Text = "Số nhà :";
            this.lsonha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmadantoc
            // 
            this.lmadantoc.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lmadantoc.Location = new System.Drawing.Point(249, 55);
            this.lmadantoc.Name = "lmadantoc";
            this.lmadantoc.Size = new System.Drawing.Size(56, 23);
            this.lmadantoc.TabIndex = 61;
            this.lmadantoc.Text = "Dân tộc :";
            this.lmadantoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmann
            // 
            this.lmann.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lmann.Location = new System.Drawing.Point(-17, 55);
            this.lmann.Name = "lmann";
            this.lmann.Size = new System.Drawing.Size(80, 23);
            this.lmann.TabIndex = 0;
            this.lmann.Text = "Ng nghiệp :";
            this.lmann.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.phai.Location = new System.Drawing.Point(728, 34);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(56, 21);
            this.phai.TabIndex = 8;
            this.phai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phai_KeyDown);
            // 
            // lphai
            // 
            this.lphai.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lphai.Location = new System.Drawing.Point(675, 34);
            this.lphai.Name = "lphai";
            this.lphai.Size = new System.Drawing.Size(56, 23);
            this.lphai.TabIndex = 161;
            this.lphai.Text = "Giới tính :";
            this.lphai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bnmoi
            // 
            this.bnmoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bnmoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bnmoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnmoi.Items.AddRange(new object[] {
            "Mới",
            "Cũ"});
            this.bnmoi.Location = new System.Drawing.Point(59, 181);
            this.bnmoi.Name = "bnmoi";
            this.bnmoi.Size = new System.Drawing.Size(64, 21);
            this.bnmoi.TabIndex = 34;
            this.bnmoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bnmoi_KeyDown);
            // 
            // loaibn
            // 
            this.loaibn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaibn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loaibn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaibn.Location = new System.Drawing.Point(571, 157);
            this.loaibn.Name = "loaibn";
            this.loaibn.Size = new System.Drawing.Size(72, 21);
            this.loaibn.TabIndex = 33;
            this.loaibn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loaibn_KeyDown);
            // 
            // ngayvv
            // 
            this.ngayvv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvv.Location = new System.Drawing.Point(251, 157);
            this.ngayvv.Mask = "##/##/####";
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(70, 21);
            this.ngayvv.TabIndex = 29;
            this.ngayvv.Text = "  /  /    ";
            this.ngayvv.Validated += new System.EventHandler(this.ngayvv_Validated);
            // 
            // tenkp
            // 
            this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(438, 157);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(90, 21);
            this.tenkp.TabIndex = 32;
            this.tenkp.SelectedIndexChanged += new System.EventHandler(this.tenkp_SelectedIndexChanged);
            this.tenkp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenkp_KeyDown);
            // 
            // madoituong
            // 
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(176, 181);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(18, 21);
            this.madoituong.TabIndex = 35;
            this.madoituong.Validated += new System.EventHandler(this.madoituong_Validated);
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // tendoituong
            // 
            this.tendoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tendoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendoituong.Location = new System.Drawing.Point(196, 181);
            this.tendoituong.Name = "tendoituong";
            this.tendoituong.Size = new System.Drawing.Size(88, 21);
            this.tendoituong.TabIndex = 36;
            this.tendoituong.SelectedIndexChanged += new System.EventHandler(this.tendoituong_SelectedIndexChanged);
            this.tendoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendoituong_KeyDown);
            // 
            // label23
            // 
            this.label23.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label23.Location = new System.Drawing.Point(117, 181);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(64, 23);
            this.label23.TabIndex = 12;
            this.label23.Text = "Đối tượng :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label19.Location = new System.Drawing.Point(189, 157);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 23);
            this.label19.TabIndex = 0;
            this.label19.Text = "Ngày :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(412, 157);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(24, 21);
            this.makp.TabIndex = 31;
            this.makp.Validated += new System.EventHandler(this.makp_Validated);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(343, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 165;
            this.label1.Text = "Khoa :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label34
            // 
            this.label34.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label34.Location = new System.Drawing.Point(524, 157);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(48, 23);
            this.label34.TabIndex = 252;
            this.label34.Text = "Đến từ :";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // l_bnmoi
            // 
            this.l_bnmoi.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.l_bnmoi.Location = new System.Drawing.Point(-9, 181);
            this.l_bnmoi.Name = "l_bnmoi";
            this.l_bnmoi.Size = new System.Drawing.Size(72, 23);
            this.l_bnmoi.TabIndex = 251;
            this.l_bnmoi.Text = "Người bệnh :";
            this.l_bnmoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(648, 157);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(136, 147);
            this.treeView1.TabIndex = 207;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // ngaysinh
            // 
            this.ngaysinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaysinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysinh.Location = new System.Drawing.Point(408, 34);
            this.ngaysinh.Mask = "##/##/####";
            this.ngaysinh.Name = "ngaysinh";
            this.ngaysinh.Size = new System.Drawing.Size(64, 21);
            this.ngaysinh.TabIndex = 4;
            this.ngaysinh.Text = "  /  /    ";
            this.ngaysinh.Validated += new System.EventHandler(this.ngaysinh_Validated);
            // 
            // cd_chinh
            // 
            this.cd_chinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_chinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_chinh.Location = new System.Drawing.Point(405, 181);
            this.cd_chinh.Name = "cd_chinh";
            this.cd_chinh.Size = new System.Drawing.Size(238, 21);
            this.cd_chinh.TabIndex = 38;
            this.cd_chinh.TextChanged += new System.EventHandler(this.cd_chinh_TextChanged);
            this.cd_chinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_chinh_KeyDown);
            // 
            // listICD
            // 
            this.listICD.BackColor = System.Drawing.SystemColors.Info;
            this.listICD.ColumnCount = 0;
            this.listICD.Location = new System.Drawing.Point(320, 552);
            this.listICD.MatchBufferTimeOut = 1000;
            this.listICD.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listICD.Name = "listICD";
            this.listICD.Size = new System.Drawing.Size(75, 17);
            this.listICD.TabIndex = 216;
            this.listICD.TextIndex = -1;
            this.listICD.TextMember = null;
            this.listICD.ValueIndex = -1;
            this.listICD.Visible = false;
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label10.Location = new System.Drawing.Point(-1, 364);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 23);
            this.label10.TabIndex = 217;
            this.label10.Text = "Đề nghị :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listBS
            // 
            this.listBS.BackColor = System.Drawing.SystemColors.Info;
            this.listBS.ColumnCount = 0;
            this.listBS.Location = new System.Drawing.Point(408, 552);
            this.listBS.MatchBufferTimeOut = 1000;
            this.listBS.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listBS.Name = "listBS";
            this.listBS.Size = new System.Drawing.Size(75, 17);
            this.listBS.TabIndex = 225;
            this.listBS.TextIndex = -1;
            this.listBS.TextMember = null;
            this.listBS.ValueIndex = -1;
            this.listBS.Visible = false;
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(99, 204);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(253, 21);
            this.tenbs.TabIndex = 40;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.ForeColor = System.Drawing.Color.Red;
            this.lbl.Location = new System.Drawing.Point(120, 11);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(60, 13);
            this.lbl.TabIndex = 236;
            this.lbl.Text = "diungthuoc";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label12.Location = new System.Drawing.Point(-6, 384);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 23);
            this.label12.TabIndex = 237;
            this.label12.Text = "Ghi chú :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label55
            // 
            this.label55.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label55.Location = new System.Drawing.Point(635, 137);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(152, 23);
            this.label55.TabIndex = 206;
            this.label55.Text = "&CÁC LẦN THỰC HIỆN";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ghichu
            // 
            this.ghichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ghichu.Location = new System.Drawing.Point(59, 387);
            this.ghichu.Multiline = true;
            this.ghichu.Name = "ghichu";
            this.ghichu.Size = new System.Drawing.Size(293, 69);
            this.ghichu.TabIndex = 54;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(-9, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 253;
            this.label2.Text = "BS chỉ định :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label8.Location = new System.Drawing.Point(7, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 23);
            this.label8.TabIndex = 256;
            this.label8.Text = "Nội dung :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ma
            // 
            this.ma.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ma.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ma.Location = new System.Drawing.Point(59, 227);
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(53, 21);
            this.ma.TabIndex = 41;
            this.ma.TextChanged += new System.EventHandler(this.ma_TextChanged);
            this.ma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // cmbma
            // 
            this.cmbma.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbma.Location = new System.Drawing.Point(114, 227);
            this.cmbma.Name = "cmbma";
            this.cmbma.Size = new System.Drawing.Size(238, 21);
            this.cmbma.TabIndex = 42;
            this.cmbma.SelectedIndexChanged += new System.EventHandler(this.cmbma_SelectedIndexChanged);
            this.cmbma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbma_KeyDown);
            // 
            // ten
            // 
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(355, 204);
            this.ten.Multiline = true;
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(288, 252);
            this.ten.TabIndex = 43;
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label9.Location = new System.Drawing.Point(7, 294);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 23);
            this.label9.TabIndex = 261;
            this.label9.Text = "Kết quả :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // denghi
            // 
            this.denghi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.denghi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.denghi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.denghi.Location = new System.Drawing.Point(59, 364);
            this.denghi.Name = "denghi";
            this.denghi.Size = new System.Drawing.Size(293, 21);
            this.denghi.TabIndex = 53;
            this.denghi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.denghi_KeyDown);
            // 
            // hen_ngay
            // 
            this.hen_ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hen_ngay.Location = new System.Drawing.Point(50, 0);
            this.hen_ngay.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.hen_ngay.Name = "hen_ngay";
            this.hen_ngay.Size = new System.Drawing.Size(41, 21);
            this.hen_ngay.TabIndex = 0;
            this.hen_ngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hen_ngay_KeyDown);
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label14.Location = new System.Drawing.Point(168, -1);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 23);
            this.label14.TabIndex = 266;
            this.label14.Text = "Ghi chú :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hen_ghichu
            // 
            this.hen_ghichu.Location = new System.Drawing.Point(224, 0);
            this.hen_ghichu.Name = "hen_ghichu";
            this.hen_ghichu.Size = new System.Drawing.Size(358, 20);
            this.hen_ghichu.TabIndex = 2;
            this.hen_ghichu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lydo_KeyDown);
            // 
            // p_hen
            // 
            this.p_hen.Controls.Add(this.hen_ngay);
            this.p_hen.Controls.Add(this.hen_loai);
            this.p_hen.Controls.Add(this.label14);
            this.p_hen.Controls.Add(this.hen_ghichu);
            this.p_hen.Location = new System.Drawing.Point(62, 462);
            this.p_hen.Name = "p_hen";
            this.p_hen.Size = new System.Drawing.Size(586, 24);
            this.p_hen.TabIndex = 56;
            this.p_hen.Visible = false;
            // 
            // hen_loai
            // 
            this.hen_loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hen_loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hen_loai.Items.AddRange(new object[] {
            "Ngày",
            "Tháng",
            "Năm"});
            this.hen_loai.Location = new System.Drawing.Point(92, 0);
            this.hen_loai.Name = "hen_loai";
            this.hen_loai.Size = new System.Drawing.Size(84, 21);
            this.hen_loai.TabIndex = 1;
            this.hen_loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hen_KeyDown);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label11.Location = new System.Drawing.Point(8, 132);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(200, 23);
            this.label11.TabIndex = 269;
            this.label11.Text = "II. THÔNG TIN CẬN LÂM SÀNG :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listpttt
            // 
            this.listpttt.BackColor = System.Drawing.SystemColors.Info;
            this.listpttt.ColumnCount = 0;
            this.listpttt.Location = new System.Drawing.Point(632, 552);
            this.listpttt.MatchBufferTimeOut = 1000;
            this.listpttt.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listpttt.Name = "listpttt";
            this.listpttt.Size = new System.Drawing.Size(75, 17);
            this.listpttt.TabIndex = 270;
            this.listpttt.TextIndex = -1;
            this.listpttt.TextMember = null;
            this.listpttt.ValueIndex = -1;
            this.listpttt.Visible = false;
            this.listpttt.Validated += new System.EventHandler(this.listpttt_Validated);
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label15.Location = new System.Drawing.Point(7, 157);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 23);
            this.label15.TabIndex = 271;
            this.label15.Text = "Loại :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loai
            // 
            this.loai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(59, 157);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(156, 21);
            this.loai.TabIndex = 28;
            this.loai.SelectedIndexChanged += new System.EventHandler(this.loai_SelectedIndexChanged);
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loai_KeyDown);
            // 
            // ketqua
            // 
            this.ketqua.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ketqua.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ketqua.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ketqua.Location = new System.Drawing.Point(59, 294);
            this.ketqua.Name = "ketqua";
            this.ketqua.Size = new System.Drawing.Size(293, 21);
            this.ketqua.TabIndex = 48;
            this.ketqua.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ketqua_KeyDown);
            // 
            // bsth
            // 
            this.bsth.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bsth.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.bsth.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsth.Location = new System.Drawing.Point(59, 318);
            this.bsth.Name = "bsth";
            this.bsth.Size = new System.Drawing.Size(38, 21);
            this.bsth.TabIndex = 49;
            this.bsth.Validated += new System.EventHandler(this.bsth_Validated);
            this.bsth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bsth_KeyDown);
            // 
            // tenbsth
            // 
            this.tenbsth.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbsth.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbsth.Location = new System.Drawing.Point(100, 318);
            this.tenbsth.Name = "tenbsth";
            this.tenbsth.Size = new System.Drawing.Size(252, 21);
            this.tenbsth.TabIndex = 50;
            this.tenbsth.TextChanged += new System.EventHandler(this.tenbsth_TextChanged);
            this.tenbsth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbsth_KeyDown);
            // 
            // listBSTH
            // 
            this.listBSTH.BackColor = System.Drawing.SystemColors.Info;
            this.listBSTH.ColumnCount = 0;
            this.listBSTH.Location = new System.Drawing.Point(240, 552);
            this.listBSTH.MatchBufferTimeOut = 1000;
            this.listBSTH.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listBSTH.Name = "listBSTH";
            this.listBSTH.Size = new System.Drawing.Size(75, 17);
            this.listBSTH.TabIndex = 272;
            this.listBSTH.TextIndex = -1;
            this.listBSTH.TextMember = null;
            this.listBSTH.ValueIndex = -1;
            this.listBSTH.Visible = false;
            // 
            // label16
            // 
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label16.Location = new System.Drawing.Point(5, 340);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 23);
            this.label16.TabIndex = 273;
            this.label16.Text = "Y tá phụ :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenytaphu
            // 
            this.tenytaphu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenytaphu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenytaphu.Location = new System.Drawing.Point(100, 341);
            this.tenytaphu.Name = "tenytaphu";
            this.tenytaphu.Size = new System.Drawing.Size(252, 21);
            this.tenytaphu.TabIndex = 52;
            this.tenytaphu.TextChanged += new System.EventHandler(this.tenytaphu_TextChanged);
            this.tenytaphu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenytaphu_KeyDown);
            // 
            // ytaphu
            // 
            this.ytaphu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ytaphu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ytaphu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ytaphu.Location = new System.Drawing.Point(59, 341);
            this.ytaphu.Name = "ytaphu";
            this.ytaphu.Size = new System.Drawing.Size(38, 21);
            this.ytaphu.TabIndex = 51;
            this.ytaphu.Validated += new System.EventHandler(this.ytaphu_Validated);
            this.ytaphu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bsth_KeyDown);
            // 
            // pmat
            // 
            this.pmat.Controls.Add(this.mt);
            this.pmat.Controls.Add(this.mp);
            this.pmat.Location = new System.Drawing.Point(58, 272);
            this.pmat.Name = "pmat";
            this.pmat.Size = new System.Drawing.Size(153, 24);
            this.pmat.TabIndex = 45;
            this.pmat.Visible = false;
            // 
            // mt
            // 
            this.mt.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mt.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.mt.Location = new System.Drawing.Point(80, 0);
            this.mt.Name = "mt";
            this.mt.Size = new System.Drawing.Size(72, 24);
            this.mt.TabIndex = 30;
            this.mt.Text = "Mắt trái :";
            this.mt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mp_KeyDown);
            // 
            // mp
            // 
            this.mp.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mp.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.mp.Location = new System.Drawing.Point(-31, 0);
            this.mp.Name = "mp";
            this.mp.Size = new System.Drawing.Size(104, 24);
            this.mp.TabIndex = 0;
            this.mp.Text = "Mắt phải :";
            this.mp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mp_KeyDown);
            // 
            // listytaphu
            // 
            this.listytaphu.BackColor = System.Drawing.SystemColors.Info;
            this.listytaphu.ColumnCount = 0;
            this.listytaphu.Location = new System.Drawing.Point(520, 552);
            this.listytaphu.MatchBufferTimeOut = 1000;
            this.listytaphu.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listytaphu.Name = "listytaphu";
            this.listytaphu.Size = new System.Drawing.Size(75, 17);
            this.listytaphu.TabIndex = 274;
            this.listytaphu.TextIndex = -1;
            this.listytaphu.TextMember = null;
            this.listytaphu.ValueIndex = -1;
            this.listytaphu.Visible = false;
            // 
            // label13
            // 
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label13.Location = new System.Drawing.Point(15, 249);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 23);
            this.label13.TabIndex = 275;
            this.label13.Text = "Thuốc :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // thuoc
            // 
            this.thuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thuoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.thuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thuoc.Location = new System.Drawing.Point(59, 250);
            this.thuoc.Name = "thuoc";
            this.thuoc.Size = new System.Drawing.Size(293, 21);
            this.thuoc.TabIndex = 44;
            this.thuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thuoc_KeyDown);
            // 
            // canquang
            // 
            this.canquang.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.canquang.Location = new System.Drawing.Point(212, 276);
            this.canquang.Name = "canquang";
            this.canquang.Size = new System.Drawing.Size(80, 16);
            this.canquang.TabIndex = 46;
            this.canquang.Text = "Cản quang";
            this.canquang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mp_KeyDown);
            // 
            // gayme
            // 
            this.gayme.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.gayme.Location = new System.Drawing.Point(292, 276);
            this.gayme.Name = "gayme";
            this.gayme.Size = new System.Drawing.Size(64, 16);
            this.gayme.TabIndex = 47;
            this.gayme.Text = "Gây mê";
            this.gayme.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mp_KeyDown);
            // 
            // butIn
            // 
            this.butIn.BackColor = System.Drawing.Color.Transparent;
            this.butIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butIn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(491, 496);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 60;
            this.butIn.Text = "&In";
            this.butIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butIn.UseVisualStyleBackColor = false;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // chkXem
            // 
            this.chkXem.Location = new System.Drawing.Point(656, 464);
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(128, 16);
            this.chkXem.TabIndex = 276;
            this.chkXem.Text = "Xem trước khi in";
            // 
            // pic
            // 
            this.pic.Location = new System.Drawing.Point(653, 312);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(128, 112);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic.TabIndex = 277;
            this.pic.TabStop = false;
            // 
            // butHinh
            // 
            this.butHinh.Location = new System.Drawing.Point(648, 432);
            this.butHinh.Name = "butHinh";
            this.butHinh.Size = new System.Drawing.Size(136, 23);
            this.butHinh.TabIndex = 278;
            this.butHinh.Text = "Chọn hình";
            this.butHinh.Click += new System.EventHandler(this.butHinh_Click);
            // 
            // giovv
            // 
            this.giovv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giovv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giovv.Location = new System.Drawing.Point(344, 157);
            this.giovv.Mask = "##:##";
            this.giovv.Name = "giovv";
            this.giovv.Size = new System.Drawing.Size(36, 21);
            this.giovv.TabIndex = 30;
            this.giovv.Text = "  :  ";
            this.giovv.Validated += new System.EventHandler(this.giovv_Validated);
            // 
            // label37
            // 
            this.label37.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label37.Location = new System.Drawing.Point(315, 155);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(32, 23);
            this.label37.TabIndex = 280;
            this.label37.Text = "giờ :";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmNhapcls
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.ngayvv);
            this.Controls.Add(this.giovv);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.madantoc);
            this.Controls.Add(this.tqx);
            this.Controls.Add(this.butHinh);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.chkXem);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.ketqua);
            this.Controls.Add(this.gayme);
            this.Controls.Add(this.canquang);
            this.Controls.Add(this.tendoituong);
            this.Controls.Add(this.thuoc);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.listytaphu);
            this.Controls.Add(this.pmat);
            this.Controls.Add(this.tenbsth);
            this.Controls.Add(this.tenytaphu);
            this.Controls.Add(this.ytaphu);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.hen);
            this.Controls.Add(this.listBSTH);
            this.Controls.Add(this.bsth);
            this.Controls.Add(this.loai);
            this.Controls.Add(this.tenkp);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.listpttt);
            this.Controls.Add(this.loaituoi);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cholam);
            this.Controls.Add(this.mapxa1);
            this.Controls.Add(this.mapxa2);
            this.Controls.Add(this.tenpxa);
            this.Controls.Add(this.maqu1);
            this.Controls.Add(this.matt);
            this.Controls.Add(this.thon);
            this.Controls.Add(this.tennuoc);
            this.Controls.Add(this.tendantoc);
            this.Controls.Add(this.mann);
            this.Controls.Add(this.loaibn);
            this.Controls.Add(this.p_hen);
            this.Controls.Add(this.ghichu);
            this.Controls.Add(this.denghi);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbma);
            this.Controls.Add(this.ma);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bnmoi);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label55);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.listBS);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.listICD);
            this.Controls.Add(this.cd_chinh);
            this.Controls.Add(this.icd_chinh);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.ngaysinh);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.lphai);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butTiep);
            this.Controls.Add(this.label52);
            this.Controls.Add(this.label49);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.tuoi);
            this.Controls.Add(this.mabn3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mabn2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.l_bnmoi);
            this.Controls.Add(this.lmann);
            this.Controls.Add(this.tennn);
            this.Controls.Add(this.lmadantoc);
            this.Controls.Add(this.lmanuoc);
            this.Controls.Add(this.manuoc);
            this.Controls.Add(this.lsonha);
            this.Controls.Add(this.sonha);
            this.Controls.Add(this.lthon);
            this.Controls.Add(this.ltqx);
            this.Controls.Add(this.tentqx);
            this.Controls.Add(this.lmatt);
            this.Controls.Add(this.tentinh);
            this.Controls.Add(this.lmaqu);
            this.Controls.Add(this.maqu2);
            this.Controls.Add(this.tenquan);
            this.Controls.Add(this.lmaphuongxa);
            this.Controls.Add(this.lcholam);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmNhapcls";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medisoft";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNhapcls_KeyDown);
            this.Load += new System.EventHandler(this.frmNhapcls_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hen_ngay)).EndInit();
            this.p_hen.ResumeLayout(false);
            this.p_hen.PerformLayout();
            this.pmat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmNhapcls_Load(object sender, System.EventArgs e)
		{
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = m.user;
			if (m.Mabv_so==701424) pmat.Visible=true;
			chkXem.Checked=m.bPreview;
			dsxml.ReadXml("..//..//..//xml//m_cls.xml");
			bTudong=m.bMabn_tudong_cdh;
			bChuyenkhoasan=m.bChuyenkhoasan;
			bChandoan=m.bChandoan_icd10;
			b_trongngoai=m.bKham_trong_ngoai_gio;
			dsloai.ReadXml("..//..//..//xml//m_loaibn.xml");
			loaibn.DisplayMember="TEN";
			loaibn.ValueMember="ID";
			loaibn.DataSource=dsloai.Tables[0];
			dsbnmoi.ReadXml("..//..//..//xml//m_bnmoi.xml");
			bnmoi.DisplayMember="TEN";
			bnmoi.ValueMember="ID";
			bnmoi.DataSource=dsbnmoi.Tables[0];
			bnmoi.Enabled=m.bMoi_cu;
			bBacsy=m.bBacsy_tiepdon;
			bTiepdon=m.bTiepdon(LibMedi.AccessData.Cls);
			lbl.Text="";
			bAdmin=m.bAdmin(i_userid);
			b_Hoten=m.bHoten_gioitinh;
			load_dm();
			iKhamnhi=m.iTuoi_khamnhi;
			phai.SelectedIndex=0;
			s_ngayvv=m.Ngaygio;
            ngayvv.Text = s_ngayvv.Substring(0, 10);
            giovv.Text = s_ngayvv.Substring(11);
			songay=m.Ngaylv_Ngayht;
			s_msg=LibMedi.AccessData.Msg;
			cd_chinh.Enabled=m.bChandoan;
			b_khambenh=m.bKhambenh;
			iTreem6=m.iTreem6;
			iTreem15=m.iTreem15;
		}

		private void load_loai()
		{
            dsmau = m.get_data("select a.ma,a.ten from " + user + ".cls_noidung a left join " + user + ".cls_mota b on a.id=b.id where a.loai=" + i_loai + " order by a.ma");
			listpttt.DataSource=dsmau.Tables[0];
            ketqua.DataSource = m.get_data("select * from " + user + ".cls_ketqua where loai=" + i_loai + " order by id").Tables[0];
            denghi.DataSource = m.get_data("select * from " + user + ".cls_denghi where loai=" + i_loai + " order by id").Tables[0];
            thuoc.DataSource = m.get_data("select * from " + user + ".cls_thuoc where loai=" + i_loai + " order by id").Tables[0];
            dslmau = m.get_data("select a.*,b.noidung from " + user + ".cls_noidung a left join " + user + ".cls_mota b on a.id=b.id where a.loai=" + i_loai + " order by a.ma");
			cmbma.DataSource=dsmau.Tables[0];
			if (cmbma.SelectedIndex!=-1)
			{
				DataRow r=m.getrowbyid(dslmau.Tables[0],"ma='"+cmbma.SelectedValue.ToString()+"'");
				if (r!=null)
				{
					ten.Text=(r["noidung"].ToString()!="")?r["noidung"].ToString():r["ten"].ToString();
					ma.Text=r["ma"].ToString();
				}
			}
			try
			{
				thuoc.Enabled=dtloai.Rows[loai.SelectedIndex]["thuoc"].ToString()=="1";
				ytaphu.Enabled=dtloai.Rows[loai.SelectedIndex]["ytaphu"].ToString()=="1";
				tenytaphu.Enabled=ytaphu.Enabled;
				canquang.Enabled=dtloai.Rows[loai.SelectedIndex]["canquang"].ToString()=="1";
				gayme.Enabled=dtloai.Rows[loai.SelectedIndex]["gayme"].ToString()=="1";
				butHinh.Enabled=dtloai.Rows[loai.SelectedIndex]["hinh"].ToString()=="1";
			}
			catch{}
		}

		private void load_dm()
		{
            sql = "select * from " + user + ".cls_loai";
			if (s_cls!="") sql+=" where id in ("+s_cls.Substring(0,s_cls.Length-1)+")";
			sql+=" order by id";	
			dtloai=m.get_data(sql).Tables[0];
			loai.DisplayMember="TEN";
			loai.ValueMember="ID";
			loai.DataSource=dtloai;
			if (loai.SelectedIndex!=-1) loai.SelectedIndex=0;
			i_loai=(loai.SelectedIndex!=-1)?int.Parse(loai.SelectedValue.ToString()):0;
			listpttt.DisplayMember="TEN";
			listpttt.ValueMember="MA";

            dticd = m.get_data("select cicd10,vviet from " + user + ".icd10 order by cicd10").Tables[0];
			listICD.DisplayMember="CICD10";
			listICD.ValueMember="VVIET";
			listICD.DataSource=dticd;

            sql = "select * from " + user + ".btdkp_bv ";
			if (s_makp!="") sql+=" where makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			sql+=" order by loai,makp";
            tenkp.DisplayMember="TENKP";
			tenkp.ValueMember="MAKP";
			tenkp.DataSource=m.get_data(sql).Tables[0];
			if (tenkp.Items.Count>0) tenkp.SelectedIndex=0;

			mabn2.Text=DateTime.Now.Year.ToString().Substring(2,2);

			tennn.DisplayMember="TENNN";
			tennn.ValueMember="MANN";
			load_btdnn(0);
			
			tendantoc.DisplayMember="DANTOC";
			tendantoc.ValueMember="MADANTOC";
            tendantoc.DataSource = m.get_data("select * from " + user + ".btddt order by madantoc").Tables[0];
			tendantoc.SelectedValue="25";

			tentinh.DisplayMember="TENTT";
			tentinh.ValueMember="MATT";
            tentinh.DataSource = m.get_data("select * from " + user + ".btdtt order by tentt").Tables[0];
			tentinh.SelectedValue=m.Mabv.Substring(0,3);

			tenquan.DisplayMember="TENQUAN";
			tenquan.ValueMember="MAQU";
			load_quan();
            
			tenpxa.DisplayMember="TENPXA";
			tenpxa.ValueMember="MAPHUONGXA";
			load_pxa();
			
			tennuoc.DisplayMember="TEN";
			tennuoc.ValueMember="MA";
            tennuoc.DataSource = m.get_data("select * from " + user + ".dmquocgia order by ma").Tables[0];
			tennuoc.SelectedIndex=-1;

			tentqx.DisplayMember="TEN";
			tentqx.ValueMember="MAPHUONGXA";

            sql = "select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a";
			if (s_madoituong!="") sql+=" where madoituong in ("+s_madoituong.Substring(0,s_madoituong.Length-1)+")";
			sql+=" order by madoituong";
			tendoituong.DisplayMember="DOITUONG";
			tendoituong.ValueMember="MADOITUONG";
			tendoituong.DataSource=m.get_data(sql).Tables[0];
			if (tendoituong.SelectedIndex!=-1) madoituong.Text=tendoituong.SelectedValue.ToString();

            dtytaphu = m.get_data("select * from " + user + ".dmbs where nhom in (" + LibMedi.AccessData.nhanvien + "," + LibMedi.AccessData.ybs_cls + "," + LibMedi.AccessData.nghiviec + ") order by ma").Tables[0];
            dtbs = m.get_data("select * from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nhanvien + "," + LibMedi.AccessData.nghiviec + ") order by ma").Tables[0];
			listBS.DisplayMember="MA";
			listBS.ValueMember="HOTEN";
			listBS.DataSource=dtbs;

			listBSTH.DisplayMember="MA";
			listBSTH.ValueMember="HOTEN";
            listBSTH.DataSource = m.get_data("select * from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nhanvien + "," + LibMedi.AccessData.nghiviec + ") order by ma").Tables[0];//m.get_data("select * from dmbs where nhom="+LibMedi.AccessData.ybs_cls+" order by ma").Tables[0];

            listytaphu.DisplayMember="MA";
			listytaphu.ValueMember="HOTEN";
			listytaphu.DataSource=dtytaphu;

			thuoc.DisplayMember="TEN";
			thuoc.ValueMember="ID";

			denghi.DisplayMember="TEN";
			denghi.ValueMember="ID";

			ketqua.DisplayMember="TEN";
			ketqua.ValueMember="ID";

			cmbma.DisplayMember="TEN";
			cmbma.ValueMember="MA";
			load_loai();
		}

		private void load_tqx()
		{
			tentqx.DataSource=m.Tqx(tqx.Text).Tables[0];
		}

		private void ena_tuoi(bool ena)
		{
			tuoi.Enabled=ena;
			loaituoi.Enabled=ena;
		}

		private void ena_namsinh(bool ena)
		{
			namsinh.Enabled=ena;
		}

		private void load_quan()
		{
            tenquan.DataSource = m.get_data("select * from " + user + ".btdquan where matt='" + tentinh.SelectedValue.ToString() + "'" + " order by maqu").Tables[0];
		}

		private void load_pxa()
		{
            tenpxa.DataSource = m.get_data("select * from " + user + ".btdpxa where maqu='" + tenquan.SelectedValue.ToString() + "'" + " order by maphuongxa").Tables[0];
		}

		private void hoten_Validated(object sender, System.EventArgs e)
		{
			if (hoten.Text=="") mabn2.Focus();
			else
			{
				if (m.bvodanh(hoten.Text))
				{
					hoten.Text=m.vodanh;
					tuoi.Text=m.vodanh_tuoi.ToString();
					loaituoi.SelectedIndex=0;
					namsinh.Text=m.Namsinh("",int.Parse(tuoi.Text),loaituoi.SelectedIndex).ToString();
					phai.SelectedIndex=m.vodanh_gioitinh;
					tendantoc.SelectedValue=m.vodanh_dantoc;
					madantoc.Text=tendantoc.SelectedValue.ToString();
					try
					{
						tennn.SelectedValue=m.vodanh_nghenghiep;
					}
					catch{tennn.SelectedIndex=0;}
					mann.Text=tennn.SelectedValue.ToString();
					tentinh.SelectedValue=m.vodanh_tinh;
					load_quan();
					tenquan.SelectedValue=tentinh.SelectedValue.ToString()+"00";
					maqu1.Text=tentinh.SelectedValue.ToString();
					maqu2.Text="00";
					load_pxa();
					tenpxa.SelectedValue=tenquan.SelectedValue.ToString()+"00";
					loai.Focus();
				}
			}
		}

		private void tenkp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tenkp.SelectedIndex==-1) tenkp.SelectedIndex=0;
				SendKeys.Send("{Tab}{Home}");
			}
		}

		private void loaituoi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (loaituoi.SelectedIndex==-1) loaituoi.SelectedIndex=0;
				namsinh.Text=m.Namsinh("",int.Parse(tuoi.Text),loaituoi.SelectedIndex).ToString();
				int ituoi=DateTime.Now.Year-int.Parse(namsinh.Text);
				if (ituoi>m.iTuoi_nguoibenh)
				{
					MessageBox.Show(lan.Change_language_MessageText("Năm sinh không hợp lệ !"),LibMedi.AccessData.Msg);
					namsinh.Focus();
					return;
				}
				if (!load_tim_mabn())
				{
					if (phai.Enabled) SendKeys.Send("{Tab}{F4}");
					else SendKeys.Send("{Tab}");
				}
			}
		}

		private void phai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (phai.SelectedIndex==-1) phai.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private bool load_tim_mabn()
		{
			string s_mann=mann.Text;
			load_btdnn(1);
			tennn.SelectedValue=s_mann;
			if (!b_Edit)
			{
				s_ngayvv="";
				s_mabn=mabn2.Text+mabn3.Text;
                DataTable dt = m.get_Timmabn(hoten.Text, ngaysinh.Text, namsinh.Text, s_mabn).Tables[0];
				if (dt.Rows.Count>0)
				{
					frmTimMabn f=new frmTimMabn(dt);
					f.ShowDialog();
					if (f.m_mabn!="")
					{
						mabn2.Text=f.m_mabn.Substring(0,2);
						mabn3.Text=f.m_mabn.Substring(2,6);
						s_mabn=mabn2.Text+mabn3.Text;
						load_mabn();
						loai.Focus();
						//SendKeys.Send("{Home}");
						return true;
					}
				}
			}
			return false;
		}

		private void tennn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tennn.SelectedIndex==-1) tennn.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void ena_nuoc(bool ena)
		{
			manuoc.Enabled=ena;
			tennuoc.Enabled=ena;
		}

		private void tennn_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				mann.Text=tennn.SelectedValue.ToString();
			}
			catch{mann.Text="";}
		}

		private void tendantoc_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				madantoc.Text=tendantoc.SelectedValue.ToString();
				if (madantoc.Text=="55") ena_nuoc(true);			
				else
				{
					ena_nuoc(false);
					tennuoc.SelectedValue="VN";
				}
			}
			catch{madantoc.Text="";}
		}

		private void tendantoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tendantoc.SelectedIndex==-1) tendantoc.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void tennuoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tennuoc.SelectedIndex==-1) tennuoc.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void tennuoc_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				manuoc.Text=tennuoc.SelectedValue.ToString();
			}
			catch{manuoc.Text="";}
		}

		private void tentqx_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				tentinh.SelectedValue=tentqx.SelectedValue.ToString().Substring(0,3);
				tenquan.SelectedValue=tentqx.SelectedValue.ToString().Substring(0,5);
				tenpxa.SelectedValue=tentqx.SelectedValue.ToString();
			}
			catch{tqx.Text="";}
		}

		private void tentqx_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				try
				{
					if (tentqx.SelectedIndex==-1) tentqx.SelectedIndex=0;
					tentinh.SelectedValue=tentqx.SelectedValue.ToString().Substring(0,3);
					tenquan.SelectedValue=tentqx.SelectedValue.ToString().Substring(0,5);
					tenpxa.SelectedValue=tentqx.SelectedValue.ToString();
					cholam.Focus();
					return;
				}
				catch{}
				SendKeys.Send("{Tab}");
			}
		}

		private void tentinh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) 
			{
				if (tentinh.SelectedIndex==-1) tentinh.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void tentinh_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				matt.Text=tentinh.SelectedValue.ToString();
				load_quan();
			}
			catch{matt.Text="";}
		}

		private void tenquan_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				maqu1.Text=tenquan.SelectedValue.ToString().Substring(0,3);
				maqu2.Text=tenquan.SelectedValue.ToString().Substring(3,2);
				load_pxa();
			}
			catch
			{
				maqu1.Text="";
				maqu2.Text="";
			}
		}

		private void tenquan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tenquan.SelectedIndex==-1) tenquan.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void tenpxa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tenpxa.SelectedIndex==-1) tenpxa.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void tenpxa_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				mapxa1.Text=tenpxa.SelectedValue.ToString().Substring(0,5);
				mapxa2.Text=tenpxa.SelectedValue.ToString().Substring(5,2);
			}
			catch
			{
				mapxa1.Text="";
				mapxa2.Text="";
			}
		}

		private void makp_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tenkp.SelectedValue=makp.Text;
			}
			catch{}
		}

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void maba_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void tuoi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void mann_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void madantoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void manuoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void matt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void matt_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tentinh.SelectedValue=matt.Text;
			}
			catch{}
		}

		private void mann_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tennn.SelectedValue=mann.Text;
			}
			catch{}
		}

		private void madantoc_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tendantoc.SelectedValue=madantoc.Text;
			}
			catch{}
		}

		private void manuoc_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tennuoc.SelectedValue=manuoc.Text;
			}
			catch{}
		}

		private void maqu2_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tenquan.SelectedValue=maqu1.Text+maqu2.Text;
			}
			catch{}
		}

		private void maqu2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void mapxa2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void mapxa2_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tenpxa.SelectedValue=mapxa1.Text+mapxa2.Text;
			}
			catch{}
		}

		private void tqx_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tqx.Text=="") matt.Focus();
				else
				{
					load_tqx();
					if (tentqx.Items.Count==1)
					{
						try
						{
							string s=tentqx.SelectedValue.ToString();
							tentinh.SelectedValue=s.Substring(0,3);
							tenquan.SelectedValue=s.Substring(0,5);
							tenpxa.SelectedValue=s;
							cholam.Focus();
						}
						catch{}
					}
					else SendKeys.Send("{Tab}{F4}");
				}
			}
		}

		private void mabn2_Validated(object sender, System.EventArgs e)
		{
			mabn2.Text=mabn2.Text.PadLeft(2,'0');		
		}

		private void mabn3_Validated(object sender, System.EventArgs e)
		{
			load_btdnn(0);
			bCapso=false;
			if (bChuyenkhoasan) phai.SelectedIndex=1;
			if (mabn3.Text=="")
			{
				if (mabn2.Text=="")
				{
					mabn2.Focus();
					return;
				}
				if (bTudong) 
				{
					bCapso=true;
					mabn3.Text=m.get_mabn(int.Parse(mabn2.Text),3,3,true).ToString().PadLeft(6,'0');
				}
				else return;
			}
			mabn3.Text=mabn3.Text.PadLeft(6,'0');
			s_mabn=mabn2.Text+mabn3.Text;
			emp_text(true);
			if (load_mabn())
			{
				if (ngayvv.Text=="")
				{
					if (load_vv_mabn())
					{
						if (!bAdmin) ena_but(false);
					}
					else load_tiepdon(m.Ngayhienhanh,true);
					s_icd_chinh=icd_chinh.Text;
				}
				if (bAdmin)
				{
					if (MessageBox.Show(lan.Change_language_MessageText("Bạn có sửa thông tin hành chính không ?"),s_msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
					{
						b_Edit=true;
						hoten.Focus();
					}
					else 
					{
						loai.Focus();
						//SendKeys.Send("{Home}");
					}
				}
				else
				{
					loai.Focus();
					//SendKeys.Send("{Home}");
				}
			} 
			else treeView1.Visible=true;
		}

		private bool load_mabn()
		{
			bool ret=false;
            foreach (DataRow r in m.get_data("select * from " + user + ".btdbn where mabn='" + s_mabn + "'").Tables[0].Rows)
			{
                nam = r["nam"].ToString();
				hoten.Text=r["hoten"].ToString();
				namsinh.Text=r["namsinh"].ToString();
				if (r["ngaysinh"].ToString()!="")
				{
					ngaysinh.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngaysinh"].ToString()));
					string tuoivao=m.Tuoivao("",ngaysinh.Text);
					tuoi.Text=tuoivao.Substring(2).PadLeft(3,'0');
					loaituoi.SelectedIndex=int.Parse(tuoivao.Substring(0,1));
				}
				else
				{
					tuoi.Text=Convert.ToString(DateTime.Now.Year-int.Parse(namsinh.Text)).PadLeft(3,'0');
					loaituoi.SelectedIndex=0;
				}
				phai.SelectedIndex=int.Parse(r["phai"].ToString());
				tennn.SelectedValue=r["mann"].ToString();
				tendantoc.SelectedValue=r["madantoc"].ToString();
				sonha.Text=r["sonha"].ToString();
				thon.Text=r["thon"].ToString();
				cholam.Text=r["cholam"].ToString();
				tentinh.SelectedValue=r["matt"].ToString();
				load_quan();
				tenquan.SelectedValue=r["maqu"].ToString();
				load_pxa();
				tenpxa.SelectedValue=r["maphuongxa"].ToString();
				ret=true;
				break;
			}
            if (ret && manuoc.Enabled) tennuoc.SelectedValue = m.get_data("select id_nuoc from " + user + ".nuocngoai where mabn='" + s_mabn + "'").Tables[0].Rows[0][0].ToString();
			load_treeView();
			return ret;
		}

		private void load_tiepdon(string m_ngay,bool skip)
		{
			l_matd=0;
			string mmyy=m.mmyy(m_ngay),user=m.user;
			if (!m.bMmyy(mmyy)) return;
			sql="select * from "+user+mmyy+".tiepdon where mabn='"+s_mabn+"'"+" and to_char(ngay,'dd/mm/yyyy')='"+m_ngay+"'";
			if (s_makp!="" )
			{
				string s=s_makp.Replace(",","','");
				sql+=" and makp in ('"+s.Substring(0,s.Length-3)+"')";
			}
			sql+=" order by ngay desc";
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				if (skip)
				{
					s_ngayvv=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
                    ngayvv.Text = s_ngayvv.Substring(0, 10);
                    giovv.Text = s_ngayvv.Substring(11);
				}
				tendoituong.SelectedValue=r["madoituong"].ToString();
				madoituong.Text=r["madoituong"].ToString();
				tenkp.SelectedValue=r["makp"].ToString();
				string stuoi=r["tuoivao"].ToString();
				if (stuoi.Length==4)
				{
					tuoi.Text=stuoi.Substring(0,3);
					loaituoi.SelectedIndex=Math.Min(int.Parse(stuoi.Substring(3,1)),3);
				}
				l_maql=decimal.Parse(r["maql"].ToString());
				l_matd=l_maql;
				break;
			}
			if (l_maql!=0)
			{
				foreach(DataRow r in m.get_data("select * from "+user+mmyy+".lienhe where maql="+l_maql).Tables[0].Rows)
				{
					if (bBacsy)
					{
						mabs.Text=r["mabs"].ToString();
						DataRow r1=m.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
						if (r1!=null) tenbs.Text=r1["hoten"].ToString();
						else tenbs.Text="";
					}
					bnmoi.SelectedIndex=int.Parse(r["bnmoi"].ToString());
				}
			}
			treeView1.Visible=true;
		}

		private void load_vv_maql(bool skip)
		{
			//emp_vv();
            if (ngayvv.Text == "") return;
            xxx = user + m.mmyy(ngayvv.Text);
			ena_but(true);
            DataRow r1;
			foreach(DataRow r in m.get_data("select * from "+xxx+".benhanpk where maql="+l_maql).Tables[0].Rows)
			{
				if (!skip)
				{
					s_ngayvv=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
                    ngayvv.Text = s_ngayvv.Substring(0, 10);
                    giovv.Text = s_ngayvv.Substring(11);
				}
				tendoituong.SelectedValue=r["madoituong"].ToString();
				madoituong.Text=r["madoituong"].ToString();
				tenkp.SelectedValue=r["makp"].ToString();
                cd_chinh.Text = r["chandoan"].ToString();
                icd_chinh.Text = r["maicd"].ToString();
                mabs.Text = r["mabs"].ToString();
                r1 = m.getrowbyid(dtbs, "ma='" + mabs.Text + "'");
                if (r1 != null) tenbs.Text = r1["hoten"].ToString();
                else tenbs.Text = "";
				if (!bAdmin) ena_but(false);
			}
			load_vv();
		}

		private bool load_vv_mabn()
		{
            if (nam == "") return false;
			l_maql=0;
			emp_vv();
            xxx = user + nam.Substring(nam.Length - 5, 4);
			foreach(DataRow r in m.get_data("select * from "+xxx+".benhanpk where mabn='"+s_mabn+"'"+" order by ngay desc").Tables[0].Rows)
			{
				l_maql=decimal.Parse(r["maql"].ToString());
				s_ngayvv=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
                ngayvv.Text = s_ngayvv.Substring(0, 10);
                giovv.Text = s_ngayvv.Substring(11);
				tenkp.SelectedValue=r["makp"].ToString();
				tendoituong.SelectedValue=r["madoituong"].ToString();
				madoituong.Text=r["madoituong"].ToString();
				break;
			}
			load_vv();
			return l_maql!=0;
		}

		private void load_vv()
		{
            xxx = user + m.mmyy(ngayvv.Text);
			foreach(DataRow r in m.get_data("select * from "+xxx+".lienhe where maql="+l_maql).Tables[0].Rows)
			{
				bnmoi.SelectedIndex=int.Parse(r["bnmoi"].ToString());
				break;
			}
			string stuoi=m.get_tuoivao(ngayvv.Text,l_maql).Trim();
			if (stuoi.Length==4)
			{
				tuoi.Text=stuoi.Substring(0,3);
				loaituoi.SelectedIndex=Math.Min(int.Parse(stuoi.Substring(3,1)),3);
			}
			treeView1.Visible=true;
		}

		private void load_cls()
		{
			hen.Checked=false;
			hen_ngay.Value=0;
			hen_ghichu.Text="";
			pic.Image=null;
			p_hen.Visible=false;
			if (l_id!=0)
			{
                xxx = user + m.mmyy(ngayvv.Text);
				DataRow r1;
                sql = "select a.*,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,case when b.songay is null then 0 else b.songay end as songay,";
                sql+="b.ghichu as hen_ghichu,case when b.loai is null then 0 else b.loai end as hen_loai,c.hinh ";
                sql+="from "+xxx+".cls_thuchien a left join "+xxx+".cls_hen b on a.id=b.id ";
                sql+=" left join "+xxx+".cls_hinh c on a.id=c.id where a.id=" + l_id;
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					s_ngayvv=r["ngayvv"].ToString();
                    ngayvv.Text = s_ngayvv.Substring(0, 10);
                    giovv.Text = s_ngayvv.Substring(11);
					cd_chinh.Text=r["chandoan"].ToString();
					icd_chinh.Text=r["maicd"].ToString();
					mabs.Text=r["bscd"].ToString();
					r1=m.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
					if (r1!=null) tenbs.Text=r1["hoten"].ToString();
					else tenbs.Text="";
					tenkp.SelectedValue=r["makp"].ToString();
					tendoituong.SelectedValue=r["madoituong"].ToString();
					madoituong.Text=r["madoituong"].ToString();
					loaibn.SelectedIndex=int.Parse(r["loaibn"].ToString());
					bnmoi.SelectedIndex=int.Parse(r["kham"].ToString());
					bsth.Text=r["bsth"].ToString();
					r1=m.getrowbyid(dtbs,"ma='"+bsth.Text+"'");
					if (r1!=null) tenbsth.Text=r1["hoten"].ToString();
					else tenbsth.Text="";
					ytaphu.Text=r["ytaphu"].ToString();
					r1=m.getrowbyid(dtytaphu,"ma='"+ytaphu.Text+"'");
					if (r1!=null) tenytaphu.Text=r1["hoten"].ToString();
					else tenytaphu.Text="";
					denghi.SelectedValue=r["denghi"].ToString();
					ketqua.SelectedValue=r["ketqua"].ToString();
					ghichu.Text=r["ghichu"].ToString();
					ma.Text=r["ma"].ToString();
					cmbma.SelectedValue=ma.Text;
					ten.Text=r["ten"].ToString();
					if (r["songay"].ToString()!="0")
					{
						hen.Checked=true;
						p_hen.Visible=true;
						hen_ngay.Value=decimal.Parse(r["songay"].ToString());
						hen_ghichu.Text=r["hen_ghichu"].ToString();
						hen_loai.SelectedIndex=int.Parse(r["hen_loai"].ToString());
					}
					s_hinh=r["hinh"].ToString().Trim();
					if (s_hinh!="") if (System.IO.File.Exists(s_hinh)) pic.Image=Image.FromFile(s_hinh);
					break;
				}
				if (pmat.Visible)
				{
					foreach(DataRow r in m.get_data("select * from "+xxx+".cls_mat where id="+l_id).Tables[0].Rows)
					{
						mp.Checked=r["mp"].ToString().Trim()=="1";
						mt.Checked=r["mt"].ToString().Trim()=="1";
						break;
					}
				}
				if (thuoc.Enabled)
				{
					foreach(DataRow r in m.get_data("select * from "+xxx+".cls_sdthuoc where id="+l_id).Tables[0].Rows)
					{
						thuoc.SelectedValue=r["thuoc"].ToString();
						break;
					}
				}
				if (canquang.Enabled || gayme.Enabled)
				{
					foreach(DataRow r in m.get_data("select * from "+xxx+".cls_motact where id="+l_id).Tables[0].Rows)
					{
						canquang.Checked=r["canquang"].ToString().Trim()=="1";
						gayme.Checked=r["gayme"].ToString().Trim()=="1";
						break;
					}
				}
			}
		}

		private void ngaysinh_Validated(object sender, System.EventArgs e)
		{
			if (ngaysinh.Text=="") return;
			ngaysinh.Text=ngaysinh.Text.Trim();
			if (!m.bNgay(ngaysinh.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày sinh không hợp lệ !"));
				ngaysinh.Focus();
				return;
			}
			ngaysinh.Text=m.Ktngaygio(ngaysinh.Text,10);
			if (!m.bNgay("",ngaysinh.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày sinh không hợp lệ !"));
				ngaysinh.Focus();
				return;
			}
			try
			{
				string tuoivao=m.Tuoivao("",ngaysinh.Text);
				tuoi.Text=tuoivao.Substring(2).PadLeft(3,'0');
				loaituoi.SelectedIndex=int.Parse(tuoivao.Substring(0,1));
				namsinh.Text=m.Namsinh(ngaysinh.Text).ToString();
				if (int.Parse(tuoi.Text)>m.iTuoi_nguoibenh && loaituoi.SelectedIndex==0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày sinh không hợp lệ !"),LibMedi.AccessData.Msg);
					ngaysinh.Focus();
					return;
				}
				if (tuoi.Text=="000")
				{
					MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập tuổi vào !"),s_msg);
					tuoi.Focus();
					return;
				}
				if (!load_tim_mabn())
				{
					if (phai.Enabled)
					{
						phai.Focus();
						SendKeys.Send("{F4}");
					}
					else mann.Focus();
				}
			}
			catch{}
		}

		private void namsinh_Validated(object sender, System.EventArgs e)
		{
			if(namsinh.Text!="")
			{
				if (int.Parse(namsinh.Text)>DateTime.Now.Year)
				{
					MessageBox.Show(lan.Change_language_MessageText("Năm sinh không hợp lệ !"),LibMedi.AccessData.Msg);
					namsinh.Focus();
					return;
				}
				if (namsinh.Text.Length<4) namsinh.Text=Convert.ToString(DateTime.Now.Year-int.Parse(namsinh.Text));
				tuoi.Text=Convert.ToString(DateTime.Now.Year-int.Parse(namsinh.Text)).PadLeft(3,'0');
				loaituoi.SelectedIndex=0;
				if (int.Parse(tuoi.Text)>m.iTuoi_nguoibenh)
				{
					MessageBox.Show(lan.Change_language_MessageText("Năm sinh không hợp lệ !"),LibMedi.AccessData.Msg);
					namsinh.Focus();
					return;
				}
				if (tuoi.Text=="000")
				{
					MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập tuổi vào !"),s_msg);
					tuoi.Focus();
					return;
				}
				if (!load_tim_mabn())
				{
					if (phai.Enabled) SendKeys.Send("{Tab}{Tab}");
					else mann.Focus();
				}
			}
		}

		private void tuoi_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (int.Parse(tuoi.Text)==0) ngaysinh.Focus();
			}
			catch{ngaysinh.Focus();}
		}

		private void hoten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F2)
			{
				hoten.Text=m.Viettat(hoten.Text)+" ";
				SendKeys.Send("{END}");
			}
			else if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{Home}");
		}

		private void thon_Validated(object sender, System.EventArgs e)
		{
			thon.Text=m.Caps(thon.Text);
		}

		private void thon_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F2)
			{
				thon.Text=m.Viettat(thon.Text)+" ";
				SendKeys.Send("{END}");
			}
			else if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void cholam_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F2)
			{
				cholam.Text=m.Viettat(cholam.Text)+" ";
				SendKeys.Send("{END}");
			}
			else if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{Home}");
		}

		private void cholam_Validated(object sender, System.EventArgs e)
		{
			cholam.Text=m.Caps(cholam.Text);		
		}

		private void frmNhapcls_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F10:
					butKetthuc_Click(sender,e);
					break;
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void madoituong_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tendoituong.SelectedValue=madoituong.Text;
			}
			catch{}
		}

		private void madoituong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void tendoituong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void mabs_Validated(object sender, System.EventArgs e)
		{
			if (mabs.Text!="")
			{
				DataRow r=m.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
				if (r!=null) tenbs.Text=r["hoten"].ToString();
				else tenbs.Text="";
			}
		}

		private void mabs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void cd_chinh_Validated(object sender, System.EventArgs e)
		{
			if (icd_chinh.Text=="") icd_chinh.Text=m.get_cicd10(cd_chinh.Text);
			if (!m.bMaicd(icd_chinh.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã ICD10 này không có trong danh mục !"),s_msg);
				icd_chinh.Text="";
				icd_chinh.Focus();
			}
		}

		private void icd_chinh_Validated(object sender, System.EventArgs e)
		{
			if (icd_chinh.Text=="" && !cd_chinh.Enabled)
			{
				cd_chinh.Text="";
				butLuu.Focus();
				return;
			}
			else if (icd_chinh.Text!=s_icd_chinh)
			{
				cd_chinh.Text=m.get_vviet(icd_chinh.Text);
				if (cd_chinh.Text=="" && icd_chinh.Text!="")
				{
                    dllDanhmucMedisoft.frmDMICD10 f = new dllDanhmucMedisoft.frmDMICD10(m, "icd10", icd_chinh.Text, cd_chinh.Text, true);
					f.ShowDialog();
					if (f.mICD!="")
					{
						cd_chinh.Text=f.mTen;
						icd_chinh.Text=f.mICD;
					}
				}
				s_icd_chinh=icd_chinh.Text;
			}
		}

		private void emp_text(bool skip)
		{
			ena_but(true);
			if (!skip)
			{
				mabn2.Text=DateTime.Now.Year.ToString().Substring(2,2);
				mabn3.Text="";
			}
			loaituoi.SelectedIndex=0;
			hoten.Text="";ngaysinh.Text="";
			namsinh.Text="";tuoi.Text="";
			sonha.Text="";thon.Text="";
			cholam.Text="";s_hinh="";bsth.Text="";tenbsth.Text="";
			ytaphu.Text="";tenytaphu.Text="";
			pic.Image=null;
			if (pmat.Visible)
			{
				mp.Checked=false;mt.Checked=false;
			}
			canquang.Checked=false;
			gayme.Checked=false;
			tentqx.SelectedIndex=-1;
			tqx.Text="";
			bnmoi.SelectedIndex=0;
			l_maql=0;
			l_matd=0;
			l_id=0;
			b_Edit=false;
			tentinh.SelectedValue=m.Mabv.Substring(0,3);
			tendantoc.SelectedValue="25";
			tennuoc.SelectedValue="VN";
			treeView1.Nodes.Clear();
			hen.Checked=false;
			hen_ngay.Value=0;
			hen_ghichu.Text="";
			p_hen.Visible=false;
			load_quan();
			load_pxa();
			emp_vv();
		}


		private void emp_vv()
		{
			string s=m.Ngaygio;
            ngayvv.Text = s.Substring(0, 10);
            giovv.Text = s.Substring(11);
			s_ngayvv="";
			try
			{
				madoituong.Text="2";
				tendoituong.SelectedValue=madoituong.Text;
			}
			catch{}
			cd_chinh.Text="";
			icd_chinh.Text="";
			s_icd_chinh="";
			mabs.Text="";tenbs.Text="";
			ghichu.Text="";
			ten.Text="";
			ketqua.Text="";
			hen_ghichu.Text="";
			hen_ngay.Value=0;
		}

		private void butTiep_Click(object sender, System.EventArgs e)
		{
			emp_text(false);
			mabn2.Focus();
		}

		private bool kiemtra()
		{
			if (mabn2.Text=="" || mabn3.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập mã bệnh nhân !"),s_msg);
				mabn2.Focus();
				return false;
			}

			if (mann.Text=="" || tennn.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập nghề nghiệp !"),s_msg);
				mann.Focus();
				return false;
			}
			if (hoten.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập họ tên bệnh nhân !"),s_msg);
				hoten.Focus();
				return false;
			}

			if (namsinh.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập ngày sinh !"),s_msg);
				ngaysinh.Focus();
				return false;
			}

			if (tennuoc.Enabled)
			{
				if (tennuoc.SelectedValue.ToString()=="VN" && tendantoc.SelectedValue.ToString()=="55")
				{
					MessageBox.Show(lan.Change_language_MessageText("Quốc tịch không hợp lệ !"),LibMedi.AccessData.Msg);
					tennuoc.Focus();
					return false;
				}
			}

			if (b_Hoten)
			{
				if ((hoten.Text.Trim().IndexOf(" VĂN ")!=-1 && phai.SelectedIndex==1) || (hoten.Text.Trim().IndexOf(" THỊ ")!=-1 && phai.SelectedIndex==0))
				{
					MessageBox.Show(lan.Change_language_MessageText("Họ tên và giới tính không hợp lệ !"),LibMedi.AccessData.Msg);
					if (phai.Enabled) phai.Focus();
					else hoten.Focus();
					return false;
				}
			}

			if (tuoi.Text=="" || loaituoi.SelectedIndex==-1)
			{
				if (namsinh.Text.Length<4) namsinh.Text=Convert.ToString(DateTime.Now.Year-int.Parse(namsinh.Text));
				tuoi.Text=Convert.ToString(DateTime.Now.Year-int.Parse(namsinh.Text)).PadLeft(3,'0');
				loaituoi.SelectedIndex=0;
			}
            if (ngayvv.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập ngày vào khám bệnh !"),s_msg);
				ngayvv.Focus();
				return false;
			}

			if (madoituong.Text=="" || tendoituong.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập đối tượng !"),s_msg);
				tendoituong.Focus();
				return false;
			}
			if (tentinh.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn tỉnh/thành phố !"),s_msg);
				tentinh.Focus();
				return false;
			}

			if (tenquan.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn quận/huyện !"),s_msg);
				tenquan.Focus();
				return false;
			}

			if (tenpxa.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn phường xã !"),s_msg);
				tenpxa.Focus();
				return false;
			}

			if (madantoc.Text=="" || tendantoc.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn dân tộc !"),s_msg);
				tendantoc.Focus();
				return false;
			}

			if (tennuoc.SelectedIndex==-1 && tennuoc.Enabled)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn quốc tịch !"),s_msg);
				tennuoc.Focus();
				return false;
			}

			if (makp.Text=="" || tenkp.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn khoa/phòng !"),s_msg);
				tenkp.Focus();
				return false;
			}

			if (icd_chinh.Text!="" && cd_chinh.Text!="")
			{

				if (icd_chinh.Text=="" && cd_chinh.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD bệnh chính !"),s_msg);
					icd_chinh.Focus();
					return false;
				}
				else if (icd_chinh.Text=="" && cd_chinh.Text!="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD bệnh chính !"),s_msg);
					icd_chinh.Focus();
					return false;
				}
				else if (cd_chinh.Text=="" && icd_chinh.Text!="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập chẩn đoán bệnh chính !"),s_msg);
					if (cd_chinh.Enabled) cd_chinh.Focus();
					else icd_chinh.Focus();
					return false;
				}
				if (!m.Kiemtra_maicd(dticd,icd_chinh.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Mã ICD không hợp lệ !"),LibMedi.AccessData.Msg);
					icd_chinh.Focus();
					return false;
				}
				if (bChandoan)
				{
					if (!m.Kiemtra_tenbenh(dticd,cd_chinh.Text))
					{
						MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"),LibMedi.AccessData.Msg);
						cd_chinh.Focus();
						return false;
					}
				}
				if (mabs.Text=="" && tenbs.Text!="" || mabs.Text!="" && tenbs.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập bác sĩ điều trị !"),s_msg);
					mabs.Focus();
					return false;
				}
			}

			if (namsinh.Text!="" && mann.Text!="")
			{
				if (!m.Kiemtra_mann(mann.Text,DateTime.Now.Year-int.Parse(namsinh.Text),iTreem6,iTreem15))
				{
					MessageBox.Show(lan.Change_language_MessageText("Nghề nghiệp và độ tuổi không hợp lệ !"),LibMedi.AccessData.Msg);
					mann.Focus();
					return false;
				}
			}
			if (namsinh.Text!="" && makp.Text!="")
			{
				if (DateTime.Now.Year-int.Parse(namsinh.Text)>iKhamnhi)
				{
					if (m.kiemtra_khamnhi(makp.Text))
					{
						MessageBox.Show(lan.Change_language_MessageText("Độ tuổi và phòng khám không hợp lệ !"),LibMedi.AccessData.Msg);
						makp.Focus();
						return false;
					}
				}
			}
			if (loaibn.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Đến từ !"),LibMedi.AccessData.Msg);
				return false;
			}
			if (bsth.Text=="" || tenbsth.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Y bác sỹ thực hiện !"),LibMedi.AccessData.Msg);
				return false;
			}
			if (pmat.Visible && !(canquang.Enabled || gayme.Enabled))
			{
				if (!mp.Checked && !mt.Checked)
				{
					MessageBox.Show(lan.Change_language_MessageText("Chọn mắt thực hiện !"),LibMedi.AccessData.Msg);
					mp.Focus();
					return false;
				}
			}
			if (ketqua.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn kết quả !"),LibMedi.AccessData.Msg);
				ketqua.Focus();
				return false;
			}
			if (denghi.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn đề nghị !"),LibMedi.AccessData.Msg);
				denghi.Focus();
				return false;
			}
			if (hen_loai.SelectedIndex==-1) hen_loai.SelectedIndex=0;
			if (thuoc.Enabled && thuoc.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn thuốc !"),LibMedi.AccessData.Msg);
				thuoc.Focus();
				return false;
			}
			mmyy=m.mmyy(ngayvv.Text);
			if (!m.bMmyy(mmyy)) m.tao_schema(mmyy,i_userid);
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			s_mabn=mabn2.Text+mabn3.Text;
            xxx = user + m.mmyy(ngayvv.Text);
            if (nam.IndexOf(m.mmyy(ngayvv.Text) + "+") == -1) nam = nam + m.mmyy(ngayvv.Text) + "+";
			if (!m.upd_btdbn(s_mabn,hoten.Text,ngaysinh.Text,namsinh.Text,phai.SelectedIndex,mann.Text,madantoc.Text,sonha.Text,thon.Text,cholam.Text,matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,i_userid,nam))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
			l_matd=m.get_tiepdon(s_mabn,ngayvv.Text+" "+giovv.Text);
			if (bTiepdon)
			{
				if (l_matd==0)
				{
                    l_matd = m.getidyymmddhhmiss_stt_computer;//m.get_capid(1);
					m.upd_tiepdon(s_mabn,l_maql,l_matd,makp.Text,ngayvv.Text+" "+giovv.Text,int.Parse(madoituong.Text),"",tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),i_userid,0,LibMedi.AccessData.Cls,0);
				}
			}
			m.upd_sukien(ngayvv.Text+" "+giovv.Text,s_mabn,l_matd,LibMedi.AccessData.Cls,l_maql);
			if (manuoc.Enabled && manuoc.Text!="") m.upd_nuocngoai(s_mabn,manuoc.Text);
			else m.execute_data("delete from "+user+".nuocngoai where mabn='"+s_mabn+"'");
            itable = m.tableid(m.mmyy(ngayvv.Text), "cls_thuchien");
            if (m.get_id_cls(s_mabn, ngayvv.Text+" "+giovv.Text, i_loai,true) != 0)
            {
                m.upd_eve_tables(ngayvv.Text, itable, i_userid, "upd");
                m.upd_eve_upd_del(ngayvv.Text, itable, i_userid, "upd", l_id.ToString() + "^" + s_mabn + "^" + l_matd.ToString() + "^" + l_maql.ToString() + "^" + makp.Text + "^" + ngayvv.Text+" "+giovv.Text + "^" + i_loai.ToString() + "^" + mabs.Text + "^" + bsth.Text + "^" + icd_chinh.Text + "^" + cd_chinh.Text + "^" + loaibn.SelectedIndex.ToString() + "^" + bnmoi.SelectedIndex.ToString() + "^" + madoituong.Text + "^" + ma.Text + "^" + ten.Text + "^" + ketqua.SelectedValue.ToString() + "^" + denghi.SelectedValue.ToString() + "^" + ghichu.Text + "^" + i_userid.ToString()+"^"+ytaphu.Text);
            }
            else m.upd_eve_tables(ngayvv.Text, itable, i_userid, "ins");
			l_id=m.get_id_cls(s_mabn,makp.Text,ngayvv.Text+" "+giovv.Text,i_loai);
			m.upd_cls_thuchien(l_id,s_mabn,l_matd,l_maql,makp.Text,ngayvv.Text+" "+giovv.Text,i_loai,mabs.Text,bsth.Text,icd_chinh.Text,cd_chinh.Text,loaibn.SelectedIndex,bnmoi.SelectedIndex,int.Parse(madoituong.Text),ma.Text,ten.Text,int.Parse(ketqua.SelectedValue.ToString()),int.Parse(denghi.SelectedValue.ToString()),ghichu.Text,i_userid,ytaphu.Text);
			if (pmat.Visible && !(canquang.Enabled || gayme.Enabled)) m.upd_cls_mat(ngayvv.Text,l_id,(mp.Checked)?1:0,(mt.Checked)?1:0);
			if (thuoc.Enabled) m.upd_cls_sdthuoc(ngayvv.Text,l_id,int.Parse(thuoc.SelectedValue.ToString()),0);
			if (hen.Checked) m.upd_cls_hen(ngayvv.Text,l_id,Convert.ToInt16(hen_ngay.Value),hen_ghichu.Text,hen_loai.SelectedIndex,"","");
			else m.execute_data("delete from "+xxx+".cls_hen where id="+l_id);
			if (s_hinh!="") m.upd_cls_hinh(ngayvv.Text,l_id,1,s_hinh);
			else m.execute_data("delete from "+xxx+".cls_hinh where id="+l_id);
			if (canquang.Enabled || gayme.Enabled)
			{
				if (canquang.Checked || gayme.Checked) m.upd_cls_motact(ngayvv.Text,l_id,(canquang.Checked)?1:0,(gayme.Checked)?1:0,0,0);
				else m.execute_data("delete from "+xxx+".cls_motact where id="+l_id);
			}
			if (sender!=null)
			{
				ena_but(false);
				butTiep.Focus();
			}
		}

		private void ena_but(bool ena)
		{
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			butTiep_Click(null,null);
		}

		private void load_treeView()
		{
			s_mabn=mabn2.Text+mabn3.Text;
			treeView1.Nodes.Clear();
            if (nam == "") return;
			TreeNode node;
            sql = "select ngay,ten,to_char(ngay,'yyyymmdd') as yyyymmdd from xxx.cls_thuchien where mabn='" + s_mabn + "'";
			if (s_cls!="") sql+=" and loai in ("+s_cls.Substring(0,s_cls.Length-1)+")";
            foreach (DataRow r in m.get_data_nam(nam, sql).Tables[0].Select("true", "yyyymmdd desc"))
			{
				node=treeView1.Nodes.Add(m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString())));
				node.Nodes.Add(r["ten"].ToString());
			}
			//treeView1.ExpandAll();
		}

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (e.Action==TreeViewAction.ByMouse || e.Action==TreeViewAction.ByKeyboard)
			{
				try
				{
					string s=e.Node.FullPath.Trim();
					int iPos=s.IndexOf("/");
					string ngay=s.Substring(iPos-2,16);
					s_mabn=mabn2.Text+mabn3.Text;
                    xxx = user + m.mmyy(ngay);
					sql="select loai from "+xxx+".cls_thuchien where mabn='"+s_mabn+"' and to_char(ngay,'dd/mm/yyyy hh24:mi')='"+ngay+"'";
					DataTable tmp=m.get_data(sql).Tables[0];
					if (tmp.Rows.Count>0)
					{
						try
						{
							i_loai=int.Parse(tmp.Rows[0]["loai"].ToString());
							loai.SelectedValue=i_loai.ToString();
							load_loai();
							l_maql=m.get_maql_benhanpk(s_mabn,ngay);
							if (l_maql!=0)
							{
								load_vv_maql(true);
                                ngayvv.Text = ngay.Substring(0, 10);
                                giovv.Text = ngay.Substring(11);
							}
							l_id=m.get_id_cls(s_mabn,ngay,i_loai,true);
							load_cls();
						}
						catch{}
					}
				}
				catch{}
			}
		}

		private void tenkp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				makp.Text=tenkp.SelectedValue.ToString();
			}
			catch{makp.Text="";}
		}

		private void load_btdnn(int i)
		{
			if (i==0) tennn.DataSource=m.get_data("select * from "+user+".btdnn_bv order by mann").Tables[0];
			else
			{
				if (namsinh.Text!="")
				{
					if (DateTime.Now.Year-int.Parse(namsinh.Text)<iTreem6)
                        tennn.DataSource = m.get_data("select * from " + user + ".btdnn_bv where mannbo='01' order by mann").Tables[0];
					else if (DateTime.Now.Year-int.Parse(namsinh.Text)<iTreem15)
                        tennn.DataSource = m.get_data("select * from " + user + ".btdnn_bv where mannbo in ('01','02') order by mann").Tables[0];
                    else tennn.DataSource = m.get_data("select * from " + user + ".btdnn_bv where mannbo<>'01' order by mann").Tables[0];
				}
			}
		}

		private void cd_chinh_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cd_chinh)
			{
				if (bChandoan || icd_chinh.Text=="")
				{
					Filt_ICD(cd_chinh.Text);
					listICD.BrowseToICD10(cd_chinh,icd_chinh,mabs,icd_chinh.Location.X,icd_chinh.Location.Y+icd_chinh.Height,icd_chinh.Width+cd_chinh.Width+2,icd_chinh.Height);
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

		private void tuoi_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			m.MaskDigit(e);
		}


		private void tenbs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listBS.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listBS.Visible) listBS.Focus();
				else SendKeys.Send("{Tab}{Home}");
			}		
		}

		private void tenbs_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbs)
			{
				Filt_tenbs(tenbs.Text);
				listBS.BrowseToICD10(tenbs,mabs,ma,mabs.Location.X,mabs.Location.Y+mabs.Height,mabs.Width+tenbs.Width+2,mabs.Height);
			}		
		}

		private void Filt_tenbsth(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listBSTH.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="hoten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void Filt_tenbs(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listBS.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="hoten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void lydo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F2)
			{
				ghichu.Text=m.Viettat(ghichu.Text)+" ";
				SendKeys.Send("{END}");
			}
			else if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void bnmoi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (bnmoi.SelectedIndex==-1) bnmoi.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}		
		}

		private void hen_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==hen) p_hen.Visible=hen.Checked;
		}

		private void loaibn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (loaibn.SelectedIndex==-1) loaibn.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}		
		}

		private void ma_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listpttt.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listpttt.Visible)
				{
					listpttt.Focus();
					SendKeys.Send("{Up}");
				}
				else SendKeys.Send("{Tab}");
			}
		}

		private void ma_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==ma)
			{
				Filt_pttt(ma.Text);
				listpttt.BrowseToPTTT(ma,ma,ten,ma.Location.X,ma.Location.Y+ma.Height,ma.Width+cmbma.Width+4,ma.Height);
			}
		}

		private void cmbma_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (cmbma.SelectedIndex==-1 && cmbma.Items.Count>0) cmbma.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void cmbma_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cmbma)
			{
				DataRow r=m.getrowbyid(dslmau.Tables[0],"ma='"+cmbma.SelectedValue.ToString()+"'");
				if (r!=null)
				{
					ten.Text=(r["noidung"].ToString()!="")?r["noidung"].ToString():r["ten"].ToString();
					ma.Text=r["ma"].ToString();
				}
			}
		}

		private void load_mau(string ma)
		{
            dsmau = m.get_data("select ma,ten from " + user + ".cls_noidung where loai=" + i_loai + " and ma like '%" + ma.Trim() + "%' order by ma");
			cmbma.DataSource=dsmau.Tables[0];
		}

		private void Filt_pttt(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listpttt.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ten LIKE '%"+ten.Trim()+"%' or ma like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void listpttt_Validated(object sender, System.EventArgs e)
		{
			if (ma.Text!="")
			{
				DataRow r=m.getrowbyid(dslmau.Tables[0],"ma='"+ma.Text+"'");
				if (r!=null)
				{
					ten.Text=(r["noidung"].ToString()!="")?r["noidung"].ToString():r["ten"].ToString();
					load_mau(ma.Text);
					cmbma.SelectedValue=ma.Text;
				}
			}
		}

		private void cd_chinh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listICD.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listICD.Visible) listICD.Focus();
				else SendKeys.Send("{Tab}{Home}");
			}		
		}

		private void loai_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==loai)
			{
				i_loai=(loai.SelectedIndex!=-1)?int.Parse(loai.SelectedValue.ToString()):0;
				load_loai();
			}
		}

		private void loai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (loai.SelectedIndex==-1 && loai.Items.Count>0) loai.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void hen_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void denghi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (denghi.SelectedIndex==-1 && denghi.Items.Count>0) denghi.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void ketqua_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (ketqua.SelectedIndex==-1 && ketqua.Items.Count>0) ketqua.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void bsth_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void bsth_Validated(object sender, System.EventArgs e)
		{
			if (bsth.Text!="")
			{
				DataRow r=m.getrowbyid(dtbs,"ma='"+bsth.Text+"'");
				if (r!=null) tenbsth.Text=r["hoten"].ToString();
				else tenbsth.Text="";
			}
		}

		private void tenbsth_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listBSTH.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listBSTH.Visible) listBSTH.Focus();
				else SendKeys.Send("{Tab}{Home}");
			}		
		}

		private void tenbsth_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbsth)
			{
				Filt_tenbsth(tenbsth.Text);
				if (ytaphu.Enabled) listBSTH.BrowseToICD10(tenbsth,bsth,ytaphu,bsth.Location.X,bsth.Location.Y+bsth.Height,bsth.Width+tenbsth.Width+2,bsth.Height);
				else listBSTH.BrowseToICD10(tenbsth,bsth,denghi,bsth.Location.X,bsth.Location.Y+bsth.Height,bsth.Width+tenbsth.Width+2,bsth.Height);
			}		
		}

		private void ytaphu_Validated(object sender, System.EventArgs e)
		{
			if (ytaphu.Text!="")
			{
				DataRow r=m.getrowbyid(dtytaphu,"ma='"+ytaphu.Text+"'");
				if (r!=null) tenytaphu.Text=r["hoten"].ToString();
				else tenytaphu.Text="";
			}
		}

		private void tenytaphu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listytaphu.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listytaphu.Visible) listytaphu.Focus();
				else SendKeys.Send("{Tab}{Home}");
			}		
		}

		private void tenytaphu_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenytaphu)
			{
				Filt_tenytaphu(tenytaphu.Text);
				listytaphu.BrowseToICD10(tenytaphu,ytaphu,denghi,ytaphu.Location.X,ytaphu.Location.Y+ytaphu.Height,ytaphu.Width+tenytaphu.Width+2,ytaphu.Height);
			}		
		}

		private void Filt_tenytaphu(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listytaphu.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="hoten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void mp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void icd_chinh_TextChanged(object sender, System.EventArgs e)
		{
			listICD.Hide();
		}

		private void hen_ngay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");		
		}

		private void tendoituong_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tendoituong) madoituong.Text=tendoituong.SelectedValue.ToString();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			s_mabn=mabn2.Text+mabn3.Text;
			if (s_mabn.Length!=8 || ngayvv.Text=="") return;
			l_id=m.get_id_cls(s_mabn,ngayvv.Text,i_loai,true);
			if (l_id!=0)
			{
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{                    
                    xxx = user + m.mmyy(ngayvv.Text);
                    itable = m.tableid(m.mmyy(ngayvv.Text), "cls_thuchien");
                    m.upd_eve_tables(ngayvv.Text, itable, i_userid, "del");
                    m.upd_eve_upd_del(ngayvv.Text, itable, i_userid, "del",m.fields(xxx+".cls_thuchien","id="+l_id));
                    m.execute_data("delete from " + xxx + ".cls_hen where id=" + l_id);
                    m.execute_data("delete from " + xxx + ".cls_motact where id=" + l_id);
                    m.execute_data("delete from " + xxx + ".cls_mat where id=" + l_id);
                    m.execute_data("delete from " + xxx + ".cls_sdthuoc where id=" + l_id);
                    m.execute_data("delete from " + xxx + ".cls_thuchien where id=" + l_id);
					butTiep_Click(sender,e);
				}
			}
		}

		private void thuoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (thuoc.SelectedIndex==-1 && thuoc.Items.Count>0) thuoc.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			if (hoten.Text=="") return;
			dsxml.Clear();
			DataRow r;
			r=dsxml.Tables[0].NewRow();
			r["mabn"]=mabn2.Text+mabn3.Text;
			r["hoten"]=hoten.Text;
			r["tuoi"]=tuoi.Text;
			r["phai"]=phai.Text;
			r["diachi"]=sonha.Text.Trim()+" "+thon.Text.Trim()+" "+tentinh.Text.Trim()+"-"+tenquan.Text.Trim()+"-"+tenpxa.Text;
			r["khoa"]=tenkp.Text;
			r["ngay"]=ngayvv.Text+" "+giovv.Text;
			r["chandoan"]=cd_chinh.Text;
			r["chidinh"]=cmbma.Text;
			r["bscd"]=tenbs.Text;
			r["bsth"]=tenbsth.Text;
			r["canquang"]=(canquang.Checked)?"Có cản quang":"";
			r["gayme"]=(gayme.Checked)?"Có gây mê":"";
			r["mp"]=(mp.Checked)?"Mắt phải":"";
			r["mt"]=(mt.Checked)?"Mắt trái":"";
			r["noidung"]=ten.Text;
			r["ghichu"]=ghichu.Text;
			r["ketqua"]=ketqua.Text;
			r["denghi"]=denghi.Text;
			r["loai"]=loai.Text;
			dsxml.Tables[0].Rows.Add(r);
			if (chkXem.Checked)
			{
				dllReportM.frmReport f=new dllReportM.frmReport(m,dsxml,"","rptCLS.rpt",true);
				f.ShowDialog();
			}
			else print.Printer(m,dsxml,"rptCLS.rpt","",1);
			butTiep.Focus();
		}

		private void butHinh_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog of = new OpenFileDialog();
			of.Title = "Chọn hình";
			of.Filter = "Files (*.jpg)|*.jpg|All Files (*.*)|*.*";
			of.RestoreDirectory=true;
			of.InitialDirectory = "..//..//..//Picture";
			if (of.ShowDialog() == DialogResult.OK)
			{
				s_hinh=of.FileName;
				pic.Image=Image.FromFile(s_hinh);
			}
		}

        private void ngayvv_Validated(object sender, System.EventArgs e)
        {
            if (ngayvv.Text == "")
            {
                ngayvv.Focus();
                return;
            }
            ngayvv.Text = ngayvv.Text.Trim();
            if (ngayvv.Text.Length == 6) ngayvv.Text = ngayvv.Text + DateTime.Now.Year.ToString();
            if (ngayvv.Text.Length < 10)
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày và giờ !"), s_msg);
                ngayvv.Focus();
                return;
            }
            if (!m.bNgay(ngayvv.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
                ngayvv.Focus();
                return;
            }
            if (s_ngayvv != "")
            {
                if (ngayvv.Text != s_ngayvv.Substring(0, 10))
                {
                    string s = ngayvv.Text;
                    if (tuoi.Text != "")
                    {
                        if (namsinh.Text != m.Namsinh("", int.Parse(tuoi.Text), loaituoi.SelectedIndex).ToString())
                        {
                            tuoi.Text = Convert.ToString(int.Parse(ngayvv.Text.Substring(6, 4)) - int.Parse(namsinh.Text)).PadLeft(3, '0');
                            loaituoi.SelectedIndex = 0;
                        }
                    }
                    s_mabn = mabn2.Text + mabn3.Text;
                    if (!bTiepdon)
                    {
                        if (m.get_tiepdon(s_mabn, ngayvv.Text+" "+giovv.Text) == 0)
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Người bệnh này chưa qua đăng ký khám bệnh !"), s_msg);
                            butBoqua_Click(sender, e);
                            return;
                        }
                    }
                    if (!m.ngay(m.StringToDate(ngayvv.Text.Substring(0, 10)), DateTime.Now, songay))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Ngày khám bệnh không hợp lệ so với khai báo hệ thống (") + songay.ToString() + ")!", s_msg);
                        ngayvv.Focus();
                        s_ngayvv = "";
                        return;
                    }
                    emp_vv();
                    ngayvv.Text = s;
                    if (ngayvv.Text != "") load_tiepdon(ngayvv.Text.Substring(0, 10), false);
                    l_maql = 0;
                    s_ngayvv = ngayvv.Text;
                }
            }
        }

        private void giovv_Validated(object sender, EventArgs e)
        {
            string sgio = (giovv.Text.Trim() == "") ? "00:00" : giovv.Text.Trim();
            giovv.Text = sgio.Substring(0, 2).Trim().PadLeft(2, '0') + ":" + sgio.Substring(3).Trim().PadRight(2, '0');
            if (!m.bGio(giovv.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"));
                giovv.Focus();
                return;
            }
            string s = ngayvv.Text + " " + giovv.Text;
            if (s != s_ngayvv)
            {
                s_mabn = mabn2.Text + mabn3.Text;
                l_maql = m.get_maql_benhanpk(s_mabn, s);
                if (l_maql != 0)
                {
                    load_vv_maql(true);
                    ngayvv.Text = s.Substring(0, 10);
                    giovv.Text = s.Substring(11);
                }
                else
                {
                    if (ngayvv.Text.Substring(0, 10) == m.Ngayhienhanh)
                    {
                        string m_ngay = m.get_ngaytiepdon(s_mabn, ngayvv.Text + " " + giovv.Text);
                        if (m_ngay != "")
                        {
                            if (!m.bNgaygio(ngayvv.Text+" "+giovv.Text, m_ngay))
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Ngày giờ thực hiện không được nhỏ ngày giờ tiếp đón !(") + m_ngay + ")", s_msg);
                                ngayvv.Focus();
                                return;
                            }
                        }
                    }
                }
                s_ngayvv = ngayvv.Text+" "+giovv.Text;
            }
            l_id = m.get_id_cls(s_mabn, ngayvv.Text+" "+giovv.Text, i_loai, true);
            if (l_id == 0)
            {
                l_id = m.get_id_cls(s_mabn, ngayvv.Text, i_loai, false);
                if (l_id != 0)
                    if (MessageBox.Show(lan.Change_language_MessageText("Đã nhập ") + loai.Text.Trim().ToUpper() + lan.Change_language_MessageText(" trong ngày ") + ngayvv.Text.Substring(0, 10) + lan.Change_language_MessageText(" xem lại ?"), LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        l_id = 0;
            }
            load_cls();
        }
	}
}
