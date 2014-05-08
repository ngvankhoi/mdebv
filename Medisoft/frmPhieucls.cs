using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibDuoc;
using LibVienphi;
using ConvertFont;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmXuatvien.
	/// </summary>
	public class frmPhieucls : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private ConvertFont.MyClass cvf = new ConvertFont.MyClass();
		private LibMedi.AccessData m;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
        private LibVienphi.AccessData v = new LibVienphi.AccessData();
		private DataSet ds=new DataSet();
		private string mmyy,s_userid,s_makp,s_mabn,s_msg,s_ngayvv,sql,s_madoituong,s_cls,s_hinh,user,xxx,nam,file_ct2003,s_dongthem="",s_trasau="",s_may;
		private int i_userid,i_loai=0,itable;
        private DataRow r3, r4;
		private decimal l_id=0,l_maql=0,l_matd=0;
        private DataSet dscq = new DataSet();
		private DataSet dslmau=new DataSet();
        private DataSet dslloai = new DataSet();
		private DataSet dsxml=new DataSet();
        private DataSet dsnhan = new DataSet();
		private DataTable dtba=new DataTable();
		private DataTable dt=new DataTable();
		private DataTable dtbs=new DataTable();
		private DataTable dtytaphu=new DataTable();
		private DataTable dtxutri=new DataTable();
		private DataTable dtloai=new DataTable();
		private DataSet dsloai=new DataSet();
		private DataSet dsbnmoi=new DataSet();
        private DataTable dtbscd = new DataTable();
        private DataTable dtbv = new DataTable();
        private DataTable dtkhoa = new DataTable();
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
        private System.Windows.Forms.Label label49;
		private System.Windows.Forms.Button butTiep;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butKetthuc;
		private int songay=30,iTreem6,iTreem15,iKhamnhi,idvung,recno=0,idloai;
        private bool b_Edit = false, b_Hoten = false, bAdmin, bChuyenkhoasan, bTiepdon, bBacsy, bTudong, bCapso = false,bSend_ct2003,bInmavach,bIdcls;
		private System.ComponentModel.IContainer components;
        private bool b_khambenh, b_trongngoai, bChandoan,bDanhsach_chidinh,bLoad_ketqua;
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
        private System.Windows.Forms.TextBox madoituong;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox makp;
		private System.Windows.Forms.Label label1;
		private MaskedBox.MaskedBox ngayvv;
		private MaskedBox.MaskedBox ngaysinh;
		private System.Windows.Forms.TreeView treeView1;
        private LibList.List listICD;
		private LibList.List listBS;
        private System.Windows.Forms.TextBox bscd;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox ma;
		private System.Windows.Forms.ComboBox cmbma;
        private System.Windows.Forms.TextBox ten;
        private System.Windows.Forms.CheckBox hen;
        private System.Windows.Forms.Panel p_hen;
		private LibList.List listpttt;
		private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox loai;
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
        private Label label17;
        private TextBox idcls;
        private Label label18;
        private TextBox bvcd;
        private Label label9;
        private Label label10;
        private Label label12;
        private TextBox idvp;
        private ComboBox may;
        private Label label20;
        private ComboBox phanloai;
        private Label label11;
        private Label label14;
        private TextBox nhankq;
        private Label label21;
        private CheckBox kqcuoi;
        private CheckBox phanung;
        private CheckBox sa;
        private Label label22;
        private Label label24;
        private TextBox madia;
        private MaskedTextBox.MaskedTextBox soluongphim;
        private MaskedBox.MaskedBox giotra;
        private MaskedBox.MaskedBox ngaytra;
        private LibList.List listbv;
        private LibList.List listbscd;
        private TextBox chandoan;
        private Button butInnhan;
        private TextBox cp;
        private TextBox lt;
        private ComboBox idvungdg;
        private LibList.List listkhoa;
        private MaskedTextBox.MaskedTextBox slthuoc;
        private Button butPrev;
        private Button butNext;
        private CheckBox chkidcls;
        private Button butFind;
        private TextBox bh;
        private Label label25;
        private dllReportM.Print print = new dllReportM.Print();
        private TextBox maloai;
        private LibList.List listLoai;
        private ColorComboBox tendoituong;

		public frmPhieucls(LibMedi.AccessData acc,string makp,string hoten,int userid,string _madoituong,string cls,string _may)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; s_makp = makp; s_madoituong = _madoituong; if (m.bBogo) tv.GanBogo(this, textBox111);
            s_userid = hoten; s_cls = cls; s_may = _may;i_userid=userid;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhieucls));
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
            this.label49 = new System.Windows.Forms.Label();
            this.hen = new System.Windows.Forms.CheckBox();
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
            this.ngayvv = new MaskedBox.MaskedBox();
            this.madoituong = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.ngaysinh = new MaskedBox.MaskedBox();
            this.listICD = new LibList.List();
            this.listBS = new LibList.List();
            this.bscd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ma = new System.Windows.Forms.TextBox();
            this.cmbma = new System.Windows.Forms.ComboBox();
            this.ten = new System.Windows.Forms.TextBox();
            this.p_hen = new System.Windows.Forms.Panel();
            this.giotra = new MaskedBox.MaskedBox();
            this.ngaytra = new MaskedBox.MaskedBox();
            this.label14 = new System.Windows.Forms.Label();
            this.listpttt = new LibList.List();
            this.label15 = new System.Windows.Forms.Label();
            this.loai = new System.Windows.Forms.ComboBox();
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
            this.butHinh = new System.Windows.Forms.Button();
            this.giovv = new MaskedBox.MaskedBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.idcls = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.bvcd = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.idvp = new System.Windows.Forms.TextBox();
            this.may = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.phanloai = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.nhankq = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.kqcuoi = new System.Windows.Forms.CheckBox();
            this.phanung = new System.Windows.Forms.CheckBox();
            this.sa = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.madia = new System.Windows.Forms.TextBox();
            this.soluongphim = new MaskedTextBox.MaskedTextBox();
            this.listbv = new LibList.List();
            this.listbscd = new LibList.List();
            this.chandoan = new System.Windows.Forms.TextBox();
            this.butInnhan = new System.Windows.Forms.Button();
            this.cp = new System.Windows.Forms.TextBox();
            this.lt = new System.Windows.Forms.TextBox();
            this.idvungdg = new System.Windows.Forms.ComboBox();
            this.listkhoa = new LibList.List();
            this.slthuoc = new MaskedTextBox.MaskedTextBox();
            this.butPrev = new System.Windows.Forms.Button();
            this.butNext = new System.Windows.Forms.Button();
            this.chkidcls = new System.Windows.Forms.CheckBox();
            this.butFind = new System.Windows.Forms.Button();
            this.bh = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.pic = new System.Windows.Forms.PictureBox();
            this.maloai = new System.Windows.Forms.TextBox();
            this.listLoai = new LibList.List();
            this.p_hen.SuspendLayout();
            this.pmat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(15, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "&Mã BN :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(128, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Họ và tên :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(344, 4);
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
            this.mabn2.Location = new System.Drawing.Point(59, 4);
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
            this.mabn3.Location = new System.Drawing.Point(83, 4);
            this.mabn3.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mabn3.MaxLength = 6;
            this.mabn3.Name = "mabn3";
            this.mabn3.Size = new System.Drawing.Size(45, 21);
            this.mabn3.TabIndex = 2;
            this.mabn3.Validated += new System.EventHandler(this.mabn3_Validated);
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(464, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 9;
            this.label6.Text = "Năm sinh :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // namsinh
            // 
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(528, 4);
            this.namsinh.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.namsinh.MaxLength = 4;
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(34, 21);
            this.namsinh.TabIndex = 5;
            this.namsinh.Validated += new System.EventHandler(this.namsinh_Validated);
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(555, 4);
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
            this.loaituoi.Location = new System.Drawing.Point(622, 4);
            this.loaituoi.Name = "loaituoi";
            this.loaituoi.Size = new System.Drawing.Size(51, 21);
            this.loaituoi.TabIndex = 7;
            this.loaituoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loaituoi_KeyDown);
            // 
            // tuoi
            // 
            this.tuoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuoi.Location = new System.Drawing.Point(592, 4);
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
            this.hoten.Location = new System.Drawing.Point(192, 4);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(158, 21);
            this.hoten.TabIndex = 3;
            this.hoten.Validated += new System.EventHandler(this.hoten_Validated);
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
            // 
            // label42
            // 
            this.label42.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label42.Location = new System.Drawing.Point(-9, 210);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(72, 23);
            this.label42.TabIndex = 20;
            this.label42.Text = "Chẩn đoán :";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label49
            // 
            this.label49.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label49.Location = new System.Drawing.Point(5, 257);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(58, 23);
            this.label49.TabIndex = 117;
            this.label49.Text = "Y Bác sĩ :";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hen
            // 
            this.hen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hen.Location = new System.Drawing.Point(375, 470);
            this.hen.Name = "hen";
            this.hen.Size = new System.Drawing.Size(51, 24);
            this.hen.TabIndex = 64;
            this.hen.Text = "Hẹn";
            this.hen.CheckedChanged += new System.EventHandler(this.hen_CheckedChanged);
            this.hen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hen_KeyDown);
            // 
            // butTiep
            // 
            this.butTiep.BackColor = System.Drawing.Color.Transparent;
            this.butTiep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTiep.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butTiep.Image = ((System.Drawing.Image)(resources.GetObject("butTiep.Image")));
            this.butTiep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTiep.Location = new System.Drawing.Point(3, 496);
            this.butTiep.Name = "butTiep";
            this.butTiep.Size = new System.Drawing.Size(70, 25);
            this.butTiep.TabIndex = 68;
            this.butTiep.Text = "&Mới";
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
            this.butLuu.Location = new System.Drawing.Point(73, 496);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 66;
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
            this.butBoqua.Location = new System.Drawing.Point(427, 496);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 67;
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
            this.butHuy.Location = new System.Drawing.Point(143, 496);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 71;
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
            this.butKetthuc.Location = new System.Drawing.Point(637, 496);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(80, 25);
            this.butKetthuc.TabIndex = 72;
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
            this.tennuoc.Location = new System.Drawing.Point(539, 27);
            this.tennuoc.Name = "tennuoc";
            this.tennuoc.Size = new System.Drawing.Size(134, 21);
            this.tennuoc.TabIndex = 14;
            this.tennuoc.SelectedIndexChanged += new System.EventHandler(this.tennuoc_SelectedIndexChanged);
            this.tennuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennuoc_KeyDown);
            // 
            // manuoc
            // 
            this.manuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manuoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.manuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manuoc.Location = new System.Drawing.Point(513, 27);
            this.manuoc.Name = "manuoc";
            this.manuoc.Size = new System.Drawing.Size(24, 21);
            this.manuoc.TabIndex = 13;
            this.manuoc.Validated += new System.EventHandler(this.manuoc_Validated);
            this.manuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manuoc_KeyDown);
            // 
            // lmanuoc
            // 
            this.lmanuoc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmanuoc.Location = new System.Drawing.Point(449, 25);
            this.lmanuoc.Name = "lmanuoc";
            this.lmanuoc.Size = new System.Drawing.Size(64, 23);
            this.lmanuoc.TabIndex = 65;
            this.lmanuoc.Text = "Quốc tịch :";
            this.lmanuoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sonha
            // 
            this.sonha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sonha.Location = new System.Drawing.Point(728, 27);
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
            this.tendantoc.Location = new System.Drawing.Point(328, 27);
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
            this.tentqx.Location = new System.Drawing.Point(372, 50);
            this.tentqx.Name = "tentqx";
            this.tentqx.Size = new System.Drawing.Size(201, 21);
            this.tentqx.TabIndex = 18;
            this.tentqx.SelectedIndexChanged += new System.EventHandler(this.tentqx_SelectedIndexChanged);
            this.tentqx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentqx_KeyDown);
            // 
            // cholam
            // 
            this.cholam.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cholam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cholam.Location = new System.Drawing.Point(645, 73);
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
            this.thon.Location = new System.Drawing.Point(59, 50);
            this.thon.Name = "thon";
            this.thon.Size = new System.Drawing.Size(196, 21);
            this.thon.TabIndex = 16;
            this.thon.Validated += new System.EventHandler(this.thon_Validated);
            this.thon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thon_KeyDown);
            // 
            // mapxa2
            // 
            this.mapxa2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapxa2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapxa2.Location = new System.Drawing.Point(364, 73);
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
            this.maqu2.Location = new System.Drawing.Point(87, 73);
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
            this.matt.Location = new System.Drawing.Point(646, 50);
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
            this.tqx.Location = new System.Drawing.Point(323, 50);
            this.tqx.Name = "tqx";
            this.tqx.Size = new System.Drawing.Size(48, 21);
            this.tqx.TabIndex = 17;
            this.tqx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tqx_KeyDown);
            // 
            // madantoc
            // 
            this.madantoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madantoc.Location = new System.Drawing.Point(302, 27);
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
            this.mann.Location = new System.Drawing.Point(59, 27);
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
            this.tennn.Location = new System.Drawing.Point(83, 27);
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
            this.tenquan.Location = new System.Drawing.Point(112, 73);
            this.tenquan.Name = "tenquan";
            this.tenquan.Size = new System.Drawing.Size(142, 21);
            this.tenquan.TabIndex = 23;
            this.tenquan.SelectedIndexChanged += new System.EventHandler(this.tenquan_SelectedIndexChanged);
            this.tenquan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenquan_KeyDown);
            // 
            // tentinh
            // 
            this.tentinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tentinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tentinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tentinh.Location = new System.Drawing.Point(674, 50);
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
            this.tenpxa.Location = new System.Drawing.Point(389, 73);
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
            this.mapxa1.Location = new System.Drawing.Point(323, 73);
            this.mapxa1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mapxa1.MaxLength = 5;
            this.mapxa1.Name = "mapxa1";
            this.mapxa1.Size = new System.Drawing.Size(40, 21);
            this.mapxa1.TabIndex = 24;
            // 
            // lmaphuongxa
            // 
            this.lmaphuongxa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmaphuongxa.Location = new System.Drawing.Point(252, 71);
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
            this.maqu1.Location = new System.Drawing.Point(59, 73);
            this.maqu1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.maqu1.MaxLength = 3;
            this.maqu1.Name = "maqu1";
            this.maqu1.Size = new System.Drawing.Size(27, 21);
            this.maqu1.TabIndex = 21;
            // 
            // lmaqu
            // 
            this.lmaqu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmaqu.Location = new System.Drawing.Point(-17, 71);
            this.lmaqu.Name = "lmaqu";
            this.lmaqu.Size = new System.Drawing.Size(80, 23);
            this.lmaqu.TabIndex = 76;
            this.lmaqu.Text = "Quận/H :";
            this.lmaqu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmatt
            // 
            this.lmatt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmatt.Location = new System.Drawing.Point(568, 50);
            this.lmatt.Name = "lmatt";
            this.lmatt.Size = new System.Drawing.Size(79, 23);
            this.lmatt.TabIndex = 75;
            this.lmatt.Text = "Tỉnh/TP :";
            this.lmatt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ltqx
            // 
            this.ltqx.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ltqx.Location = new System.Drawing.Point(252, 50);
            this.ltqx.Name = "ltqx";
            this.ltqx.Size = new System.Drawing.Size(72, 23);
            this.ltqx.TabIndex = 74;
            this.ltqx.Text = "T/Q/PXã :";
            this.ltqx.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lcholam
            // 
            this.lcholam.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lcholam.Location = new System.Drawing.Point(575, 71);
            this.lcholam.Name = "lcholam";
            this.lcholam.Size = new System.Drawing.Size(72, 23);
            this.lcholam.TabIndex = 73;
            this.lcholam.Text = "Điện thoại :";
            this.lcholam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lthon
            // 
            this.lthon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lthon.Location = new System.Drawing.Point(-9, 50);
            this.lthon.Name = "lthon";
            this.lthon.Size = new System.Drawing.Size(72, 23);
            this.lthon.TabIndex = 72;
            this.lthon.Text = "Thôn, phố :";
            this.lthon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lsonha
            // 
            this.lsonha.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lsonha.Location = new System.Drawing.Point(669, 25);
            this.lsonha.Name = "lsonha";
            this.lsonha.Size = new System.Drawing.Size(59, 23);
            this.lsonha.TabIndex = 70;
            this.lsonha.Text = "Số nhà :";
            this.lsonha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmadantoc
            // 
            this.lmadantoc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmadantoc.Location = new System.Drawing.Point(249, 25);
            this.lmadantoc.Name = "lmadantoc";
            this.lmadantoc.Size = new System.Drawing.Size(56, 23);
            this.lmadantoc.TabIndex = 61;
            this.lmadantoc.Text = "Dân tộc :";
            this.lmadantoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmann
            // 
            this.lmann.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmann.Location = new System.Drawing.Point(-17, 25);
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
            this.phai.Location = new System.Drawing.Point(728, 4);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(56, 21);
            this.phai.TabIndex = 8;
            this.phai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phai_KeyDown);
            // 
            // lphai
            // 
            this.lphai.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lphai.Location = new System.Drawing.Point(675, 4);
            this.lphai.Name = "lphai";
            this.lphai.Size = new System.Drawing.Size(56, 23);
            this.lphai.TabIndex = 161;
            this.lphai.Text = "Giới tính :";
            this.lphai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngayvv
            // 
            this.ngayvv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvv.Location = new System.Drawing.Point(238, 96);
            this.ngayvv.Mask = "##/##/####";
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(70, 21);
            this.ngayvv.TabIndex = 29;
            this.ngayvv.Text = "  /  /    ";
            this.ngayvv.Validated += new System.EventHandler(this.ngayvv_Validated);
            // 
            // madoituong
            // 
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(255, 165);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(18, 21);
            this.madoituong.TabIndex = 36;
            this.madoituong.Validated += new System.EventHandler(this.madoituong_Validated);
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // label23
            // 
            this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label23.Location = new System.Drawing.Point(193, 162);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(64, 23);
            this.label23.TabIndex = 12;
            this.label23.Text = "Đối tượng :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(178, 94);
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
            this.makp.Location = new System.Drawing.Point(255, 142);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(117, 21);
            this.makp.TabIndex = 34;
            this.makp.Validated += new System.EventHandler(this.makp_Validated);
            this.makp.TextChanged += new System.EventHandler(this.makp_TextChanged);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(185, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 165;
            this.label1.Text = "Khoa :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(704, 96);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(83, 373);
            this.treeView1.TabIndex = 207;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // ngaysinh
            // 
            this.ngaysinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaysinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysinh.Location = new System.Drawing.Point(408, 4);
            this.ngaysinh.Mask = "##/##/####";
            this.ngaysinh.Name = "ngaysinh";
            this.ngaysinh.Size = new System.Drawing.Size(64, 21);
            this.ngaysinh.TabIndex = 4;
            this.ngaysinh.Text = "  /  /    ";
            this.ngaysinh.Validated += new System.EventHandler(this.ngaysinh_Validated);
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
            // bscd
            // 
            this.bscd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bscd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.bscd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bscd.Location = new System.Drawing.Point(59, 142);
            this.bscd.Name = "bscd";
            this.bscd.Size = new System.Drawing.Size(133, 21);
            this.bscd.TabIndex = 33;
            this.bscd.Validated += new System.EventHandler(this.bscd_Validated);
            this.bscd.TextChanged += new System.EventHandler(this.bscd_TextChanged);
            this.bscd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bscd_KeyDown);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(-9, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 253;
            this.label2.Text = "BS chỉ định :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(-6, 326);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 23);
            this.label8.TabIndex = 256;
            this.label8.Text = "Vùng :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ma
            // 
            this.ma.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ma.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ma.Location = new System.Drawing.Point(59, 326);
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(79, 21);
            this.ma.TabIndex = 47;
            this.ma.TextChanged += new System.EventHandler(this.ma_TextChanged);
            this.ma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // cmbma
            // 
            this.cmbma.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbma.Location = new System.Drawing.Point(139, 326);
            this.cmbma.Name = "cmbma";
            this.cmbma.Size = new System.Drawing.Size(233, 21);
            this.cmbma.TabIndex = 48;
            this.cmbma.SelectedIndexChanged += new System.EventHandler(this.cmbma_SelectedIndexChanged);
            this.cmbma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbma_KeyDown);
            // 
            // ten
            // 
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(377, 97);
            this.ten.Multiline = true;
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(330, 372);
            this.ten.TabIndex = 49;
            // 
            // p_hen
            // 
            this.p_hen.Controls.Add(this.giotra);
            this.p_hen.Controls.Add(this.ngaytra);
            this.p_hen.Controls.Add(this.label14);
            this.p_hen.Location = new System.Drawing.Point(417, 470);
            this.p_hen.Name = "p_hen";
            this.p_hen.Size = new System.Drawing.Size(230, 24);
            this.p_hen.TabIndex = 65;
            this.p_hen.Visible = false;
            // 
            // giotra
            // 
            this.giotra.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giotra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giotra.Location = new System.Drawing.Point(190, 1);
            this.giotra.Mask = "##:##";
            this.giotra.Name = "giotra";
            this.giotra.Size = new System.Drawing.Size(36, 21);
            this.giotra.TabIndex = 1;
            this.giotra.Text = "  :  ";
            this.giotra.Validated += new System.EventHandler(this.giotra_Validated);
            // 
            // ngaytra
            // 
            this.ngaytra.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaytra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaytra.Location = new System.Drawing.Point(118, 1);
            this.ngaytra.Mask = "##/##/####";
            this.ngaytra.Name = "ngaytra";
            this.ngaytra.Size = new System.Drawing.Size(70, 21);
            this.ngaytra.TabIndex = 0;
            this.ngaytra.Text = "  /  /    ";
            this.ngaytra.Validated += new System.EventHandler(this.ngaytra_Validated);
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(1, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(115, 23);
            this.label14.TabIndex = 0;
            this.label14.Text = "Ngày trả kết quả lúc :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listpttt
            // 
            this.listpttt.BackColor = System.Drawing.SystemColors.Info;
            this.listpttt.ColumnCount = 0;
            this.listpttt.Location = new System.Drawing.Point(568, 552);
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
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(7, 96);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 23);
            this.label15.TabIndex = 271;
            this.label15.Text = "Loại  :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loai
            // 
            this.loai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(59, 96);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(133, 21);
            this.loai.TabIndex = 28;
            this.loai.SelectedIndexChanged += new System.EventHandler(this.loai_SelectedIndexChanged);
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loai_KeyDown);
            // 
            // bsth
            // 
            this.bsth.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bsth.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.bsth.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsth.Location = new System.Drawing.Point(59, 257);
            this.bsth.Name = "bsth";
            this.bsth.Size = new System.Drawing.Size(38, 21);
            this.bsth.TabIndex = 42;
            this.bsth.Validated += new System.EventHandler(this.bsth_Validated);
            this.bsth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bsth_KeyDown);
            // 
            // tenbsth
            // 
            this.tenbsth.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbsth.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbsth.Location = new System.Drawing.Point(100, 257);
            this.tenbsth.Name = "tenbsth";
            this.tenbsth.Size = new System.Drawing.Size(272, 21);
            this.tenbsth.TabIndex = 43;
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
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(-6, 279);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(69, 23);
            this.label16.TabIndex = 273;
            this.label16.Text = "KTV :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenytaphu
            // 
            this.tenytaphu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenytaphu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenytaphu.Location = new System.Drawing.Point(100, 280);
            this.tenytaphu.Name = "tenytaphu";
            this.tenytaphu.Size = new System.Drawing.Size(272, 21);
            this.tenytaphu.TabIndex = 45;
            this.tenytaphu.TextChanged += new System.EventHandler(this.tenytaphu_TextChanged);
            this.tenytaphu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenytaphu_KeyDown);
            // 
            // ytaphu
            // 
            this.ytaphu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ytaphu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ytaphu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ytaphu.Location = new System.Drawing.Point(59, 280);
            this.ytaphu.Name = "ytaphu";
            this.ytaphu.Size = new System.Drawing.Size(38, 21);
            this.ytaphu.TabIndex = 44;
            this.ytaphu.Validated += new System.EventHandler(this.ytaphu_Validated);
            this.ytaphu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bsth_KeyDown);
            // 
            // pmat
            // 
            this.pmat.Controls.Add(this.mt);
            this.pmat.Controls.Add(this.mp);
            this.pmat.Location = new System.Drawing.Point(219, 394);
            this.pmat.Name = "pmat";
            this.pmat.Size = new System.Drawing.Size(153, 24);
            this.pmat.TabIndex = 55;
            this.pmat.Visible = false;
            // 
            // mt
            // 
            this.mt.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mt.Location = new System.Drawing.Point(79, 0);
            this.mt.Name = "mt";
            this.mt.Size = new System.Drawing.Size(68, 24);
            this.mt.TabIndex = 1;
            this.mt.Text = "Mắt trái :";
            this.mt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mp_KeyDown);
            // 
            // mp
            // 
            this.mp.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mp.ForeColor = System.Drawing.SystemColors.ControlText;
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
            this.listytaphu.Location = new System.Drawing.Point(487, 552);
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
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(12, 393);
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
            this.thuoc.Location = new System.Drawing.Point(59, 394);
            this.thuoc.Name = "thuoc";
            this.thuoc.Size = new System.Drawing.Size(126, 21);
            this.thuoc.TabIndex = 53;
            this.thuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thuoc_KeyDown);
            // 
            // canquang
            // 
            this.canquang.ForeColor = System.Drawing.SystemColors.ControlText;
            this.canquang.Location = new System.Drawing.Point(63, 420);
            this.canquang.Name = "canquang";
            this.canquang.Size = new System.Drawing.Size(90, 20);
            this.canquang.TabIndex = 57;
            this.canquang.Text = "Tương phản";
            this.canquang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mp_KeyDown);
            // 
            // gayme
            // 
            this.gayme.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gayme.Location = new System.Drawing.Point(3, 419);
            this.gayme.Name = "gayme";
            this.gayme.Size = new System.Drawing.Size(64, 20);
            this.gayme.TabIndex = 56;
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
            this.butIn.Location = new System.Drawing.Point(357, 496);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 70;
            this.butIn.Text = "&In";
            this.butIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butIn.UseVisualStyleBackColor = false;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // chkXem
            // 
            this.chkXem.Location = new System.Drawing.Point(647, 468);
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(128, 16);
            this.chkXem.TabIndex = 276;
            this.chkXem.Text = "Xem trước khi in";
            // 
            // butHinh
            // 
            this.butHinh.Location = new System.Drawing.Point(651, 522);
            this.butHinh.Name = "butHinh";
            this.butHinh.Size = new System.Drawing.Size(136, 23);
            this.butHinh.TabIndex = 278;
            this.butHinh.Text = "Chọn hình";
            this.butHinh.Visible = false;
            this.butHinh.Click += new System.EventHandler(this.butHinh_Click);
            // 
            // giovv
            // 
            this.giovv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giovv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giovv.Location = new System.Drawing.Point(336, 96);
            this.giovv.Mask = "##:##";
            this.giovv.Name = "giovv";
            this.giovv.Size = new System.Drawing.Size(36, 21);
            this.giovv.TabIndex = 30;
            this.giovv.Text = "  :  ";
            this.giovv.Validated += new System.EventHandler(this.giovv_Validated);
            // 
            // label37
            // 
            this.label37.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label37.Location = new System.Drawing.Point(307, 94);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(32, 23);
            this.label37.TabIndex = 280;
            this.label37.Text = "giờ :";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(5, 118);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(58, 22);
            this.label17.TabIndex = 281;
            this.label17.Text = "ID CLS :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // idcls
            // 
            this.idcls.BackColor = System.Drawing.SystemColors.HighlightText;
            this.idcls.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idcls.Location = new System.Drawing.Point(59, 119);
            this.idcls.MaxLength = 9;
            this.idcls.Name = "idcls";
            this.idcls.Size = new System.Drawing.Size(133, 21);
            this.idcls.TabIndex = 31;
            this.idcls.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.idcls_KeyPress);
            this.idcls.Validated += new System.EventHandler(this.idcls_Validated);
            this.idcls.KeyDown += new System.Windows.Forms.KeyEventHandler(this.idcls_KeyDown);
            // 
            // label18
            // 
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(-9, 163);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(72, 23);
            this.label18.TabIndex = 283;
            this.label18.Text = "BV chỉ định :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bvcd
            // 
            this.bvcd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bvcd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bvcd.Location = new System.Drawing.Point(59, 165);
            this.bvcd.Name = "bvcd";
            this.bvcd.Size = new System.Drawing.Size(133, 21);
            this.bvcd.TabIndex = 35;
            this.bvcd.Validated += new System.EventHandler(this.bvcd_Validated);
            this.bvcd.TextChanged += new System.EventHandler(this.bvcd_TextChanged);
            this.bvcd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bvcd_KeyDown);
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(20, 187);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 23);
            this.label9.TabIndex = 285;
            this.label9.Text = "CP :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(125, 188);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 23);
            this.label10.TabIndex = 287;
            this.label10.Text = "LT :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(189, 123);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 17);
            this.label12.TabIndex = 289;
            this.label12.Text = "ID viện phí :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // idvp
            // 
            this.idvp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.idvp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idvp.Location = new System.Drawing.Point(255, 119);
            this.idvp.Name = "idvp";
            this.idvp.Size = new System.Drawing.Size(117, 21);
            this.idvp.TabIndex = 32;
            this.idvp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mp_KeyDown);
            // 
            // may
            // 
            this.may.BackColor = System.Drawing.SystemColors.HighlightText;
            this.may.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.may.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.may.Location = new System.Drawing.Point(59, 303);
            this.may.Name = "may";
            this.may.Size = new System.Drawing.Size(313, 21);
            this.may.TabIndex = 46;
            this.may.KeyDown += new System.Windows.Forms.KeyEventHandler(this.may_KeyDown);
            // 
            // label20
            // 
            this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label20.Location = new System.Drawing.Point(-6, 301);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(69, 23);
            this.label20.TabIndex = 292;
            this.label20.Text = "Máy :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // phanloai
            // 
            this.phanloai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phanloai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.phanloai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phanloai.Location = new System.Drawing.Point(139, 371);
            this.phanloai.Name = "phanloai";
            this.phanloai.Size = new System.Drawing.Size(233, 21);
            this.phanloai.TabIndex = 52;
            this.phanloai.SelectedIndexChanged += new System.EventHandler(this.phanloai_SelectedIndexChanged);
            this.phanloai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phanloai_KeyDown);
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(-3, 348);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 23);
            this.label11.TabIndex = 294;
            this.label11.Text = "Phân loại :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhankq
            // 
            this.nhankq.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhankq.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhankq.Location = new System.Drawing.Point(59, 471);
            this.nhankq.Name = "nhankq";
            this.nhankq.Size = new System.Drawing.Size(313, 21);
            this.nhankq.TabIndex = 63;
            this.nhankq.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mp_KeyDown);
            // 
            // label21
            // 
            this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label21.Location = new System.Drawing.Point(-32, 470);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(95, 23);
            this.label21.TabIndex = 297;
            this.label21.Text = "Nhận KQ :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kqcuoi
            // 
            this.kqcuoi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.kqcuoi.Location = new System.Drawing.Point(154, 420);
            this.kqcuoi.Name = "kqcuoi";
            this.kqcuoi.Size = new System.Drawing.Size(92, 20);
            this.kqcuoi.TabIndex = 58;
            this.kqcuoi.Text = "Kết quả cuối";
            this.kqcuoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mp_KeyDown);
            // 
            // phanung
            // 
            this.phanung.ForeColor = System.Drawing.SystemColors.ControlText;
            this.phanung.Location = new System.Drawing.Point(238, 420);
            this.phanung.Name = "phanung";
            this.phanung.Size = new System.Drawing.Size(86, 20);
            this.phanung.TabIndex = 59;
            this.phanung.Text = "Phản ứng";
            this.phanung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mp_KeyDown);
            // 
            // sa
            // 
            this.sa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sa.Location = new System.Drawing.Point(310, 420);
            this.sa.Name = "sa";
            this.sa.Size = new System.Drawing.Size(64, 20);
            this.sa.TabIndex = 60;
            this.sa.Text = "Siêu âm";
            this.sa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mp_KeyDown);
            // 
            // label22
            // 
            this.label22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label22.Location = new System.Drawing.Point(-32, 446);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(95, 23);
            this.label22.TabIndex = 301;
            this.label22.Text = "Mã đĩa lưu :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label24.Location = new System.Drawing.Point(213, 446);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(95, 23);
            this.label24.TabIndex = 302;
            this.label24.Text = "Số lượng phim :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madia
            // 
            this.madia.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.madia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madia.Location = new System.Drawing.Point(59, 448);
            this.madia.Name = "madia";
            this.madia.Size = new System.Drawing.Size(168, 21);
            this.madia.TabIndex = 61;
            this.madia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mp_KeyDown);
            // 
            // soluongphim
            // 
            this.soluongphim.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluongphim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluongphim.Location = new System.Drawing.Point(311, 448);
            this.soluongphim.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.soluongphim.Name = "soluongphim";
            this.soluongphim.Size = new System.Drawing.Size(61, 21);
            this.soluongphim.TabIndex = 62;
            this.soluongphim.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soluongphim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mp_KeyDown);
            // 
            // listbv
            // 
            this.listbv.BackColor = System.Drawing.SystemColors.Info;
            this.listbv.ColumnCount = 0;
            this.listbv.Location = new System.Drawing.Point(152, 552);
            this.listbv.MatchBufferTimeOut = 1000;
            this.listbv.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listbv.Name = "listbv";
            this.listbv.Size = new System.Drawing.Size(75, 17);
            this.listbv.TabIndex = 304;
            this.listbv.TextIndex = -1;
            this.listbv.TextMember = null;
            this.listbv.ValueIndex = -1;
            this.listbv.Visible = false;
            // 
            // listbscd
            // 
            this.listbscd.BackColor = System.Drawing.SystemColors.Info;
            this.listbscd.ColumnCount = 0;
            this.listbscd.Location = new System.Drawing.Point(58, 552);
            this.listbscd.MatchBufferTimeOut = 1000;
            this.listbscd.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listbscd.Name = "listbscd";
            this.listbscd.Size = new System.Drawing.Size(75, 17);
            this.listbscd.TabIndex = 303;
            this.listbscd.TextIndex = -1;
            this.listbscd.TextMember = null;
            this.listbscd.ValueIndex = -1;
            this.listbscd.Visible = false;
            this.listbscd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listbscd_KeyDown);
            // 
            // chandoan
            // 
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(59, 211);
            this.chandoan.Multiline = true;
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(313, 43);
            this.chandoan.TabIndex = 41;
            // 
            // butInnhan
            // 
            this.butInnhan.BackColor = System.Drawing.Color.Transparent;
            this.butInnhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butInnhan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butInnhan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butInnhan.Location = new System.Drawing.Point(213, 496);
            this.butInnhan.Name = "butInnhan";
            this.butInnhan.Size = new System.Drawing.Size(70, 25);
            this.butInnhan.TabIndex = 69;
            this.butInnhan.Text = "In &nhãn";
            this.butInnhan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butInnhan.UseVisualStyleBackColor = false;
            this.butInnhan.Click += new System.EventHandler(this.butInnhan_Click);
            // 
            // cp
            // 
            this.cp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cp.Location = new System.Drawing.Point(59, 188);
            this.cp.Name = "cp";
            this.cp.Size = new System.Drawing.Size(79, 21);
            this.cp.TabIndex = 38;
            this.cp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cp_KeyPress);
            this.cp.Validated += new System.EventHandler(this.cp_Validated);
            this.cp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mp_KeyDown);
            // 
            // lt
            // 
            this.lt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lt.Location = new System.Drawing.Point(165, 188);
            this.lt.Name = "lt";
            this.lt.Size = new System.Drawing.Size(79, 21);
            this.lt.TabIndex = 39;
            this.lt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.lt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cp_KeyPress);
            this.lt.Validated += new System.EventHandler(this.lt_Validated);
            this.lt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mp_KeyDown);
            // 
            // idvungdg
            // 
            this.idvungdg.BackColor = System.Drawing.SystemColors.HighlightText;
            this.idvungdg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.idvungdg.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idvungdg.Location = new System.Drawing.Point(59, 348);
            this.idvungdg.Name = "idvungdg";
            this.idvungdg.Size = new System.Drawing.Size(313, 21);
            this.idvungdg.TabIndex = 50;
            this.idvungdg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.idvungdg_KeyDown);
            // 
            // listkhoa
            // 
            this.listkhoa.BackColor = System.Drawing.SystemColors.Info;
            this.listkhoa.ColumnCount = 0;
            this.listkhoa.Location = new System.Drawing.Point(-23, 552);
            this.listkhoa.MatchBufferTimeOut = 1000;
            this.listkhoa.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listkhoa.Name = "listkhoa";
            this.listkhoa.Size = new System.Drawing.Size(75, 17);
            this.listkhoa.TabIndex = 305;
            this.listkhoa.TextIndex = -1;
            this.listkhoa.TextMember = null;
            this.listkhoa.ValueIndex = -1;
            this.listkhoa.Visible = false;
            // 
            // slthuoc
            // 
            this.slthuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.slthuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slthuoc.Location = new System.Drawing.Point(188, 394);
            this.slthuoc.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.slthuoc.Name = "slthuoc";
            this.slthuoc.Size = new System.Drawing.Size(30, 21);
            this.slthuoc.TabIndex = 54;
            this.slthuoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // butPrev
            // 
            this.butPrev.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butPrev.Image = ((System.Drawing.Image)(resources.GetObject("butPrev.Image")));
            this.butPrev.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butPrev.Location = new System.Drawing.Point(497, 496);
            this.butPrev.Name = "butPrev";
            this.butPrev.Size = new System.Drawing.Size(70, 25);
            this.butPrev.TabIndex = 306;
            this.butPrev.Text = "&Trước";
            this.butPrev.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butPrev.UseVisualStyleBackColor = true;
            this.butPrev.Click += new System.EventHandler(this.butPrev_Click);
            // 
            // butNext
            // 
            this.butNext.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butNext.Image = ((System.Drawing.Image)(resources.GetObject("butNext.Image")));
            this.butNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butNext.Location = new System.Drawing.Point(567, 496);
            this.butNext.Name = "butNext";
            this.butNext.Size = new System.Drawing.Size(70, 25);
            this.butNext.TabIndex = 307;
            this.butNext.Text = "&Sau";
            this.butNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butNext.UseVisualStyleBackColor = true;
            this.butNext.Click += new System.EventHandler(this.butNext_Click);
            // 
            // chkidcls
            // 
            this.chkidcls.Location = new System.Drawing.Point(647, 482);
            this.chkidcls.Name = "chkidcls";
            this.chkidcls.Size = new System.Drawing.Size(128, 19);
            this.chkidcls.TabIndex = 308;
            this.chkidcls.Text = "ID CLS tự động tăng";
            this.chkidcls.CheckedChanged += new System.EventHandler(this.chkidcls_CheckedChanged);
            // 
            // butFind
            // 
            this.butFind.BackColor = System.Drawing.Color.Transparent;
            this.butFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butFind.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butFind.Image = ((System.Drawing.Image)(resources.GetObject("butFind.Image")));
            this.butFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butFind.Location = new System.Drawing.Point(283, 496);
            this.butFind.Name = "butFind";
            this.butFind.Size = new System.Drawing.Size(74, 25);
            this.butFind.TabIndex = 309;
            this.butFind.Text = "Tìm kiếm";
            this.butFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butFind.UseVisualStyleBackColor = false;
            this.butFind.Click += new System.EventHandler(this.butFind_Click);
            // 
            // bh
            // 
            this.bh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bh.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.bh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bh.Location = new System.Drawing.Point(293, 188);
            this.bh.Name = "bh";
            this.bh.Size = new System.Drawing.Size(79, 21);
            this.bh.TabIndex = 40;
            this.bh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.bh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bh_KeyPress);
            this.bh.Validated += new System.EventHandler(this.bh_Validated);
            this.bh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mp_KeyDown);
            // 
            // label25
            // 
            this.label25.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label25.Location = new System.Drawing.Point(235, 187);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(59, 23);
            this.label25.TabIndex = 311;
            this.label25.Text = "Phí BH :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pic
            // 
            this.pic.Location = new System.Drawing.Point(656, 543);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(128, 44);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic.TabIndex = 277;
            this.pic.TabStop = false;
            this.pic.Visible = false;
            // 
            // maloai
            // 
            this.maloai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maloai.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.maloai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maloai.Location = new System.Drawing.Point(59, 371);
            this.maloai.Name = "maloai";
            this.maloai.Size = new System.Drawing.Size(79, 21);
            this.maloai.TabIndex = 51;
            this.maloai.TextChanged += new System.EventHandler(this.maloai_TextChanged);
            this.maloai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maloai_KeyDown);
            // 
            // listLoai
            // 
            this.listLoai.BackColor = System.Drawing.SystemColors.Info;
            this.listLoai.ColumnCount = 0;
            this.listLoai.Location = new System.Drawing.Point(364, 544);
            this.listLoai.MatchBufferTimeOut = 1000;
            this.listLoai.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listLoai.Name = "listLoai";
            this.listLoai.Size = new System.Drawing.Size(75, 17);
            this.listLoai.TabIndex = 312;
            this.listLoai.TextIndex = -1;
            this.listLoai.TextMember = null;
            this.listLoai.ValueIndex = -1;
            this.listLoai.Visible = false;
            this.listLoai.Validated += new System.EventHandler(this.listLoai_Validated);
            // 
            // frmPhieucls
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.idcls);
            this.Controls.Add(this.listLoai);
            this.Controls.Add(this.maloai);
            this.Controls.Add(this.canquang);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.bh);
            this.Controls.Add(this.lt);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.butFind);
            this.Controls.Add(this.chkidcls);
            this.Controls.Add(this.butNext);
            this.Controls.Add(this.butPrev);
            this.Controls.Add(this.slthuoc);
            this.Controls.Add(this.listkhoa);
            this.Controls.Add(this.idvungdg);
            this.Controls.Add(this.cp);
            this.Controls.Add(this.butInnhan);
            this.Controls.Add(this.chandoan);
            this.Controls.Add(this.listbv);
            this.Controls.Add(this.listbscd);
            this.Controls.Add(this.soluongphim);
            this.Controls.Add(this.madia);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.sa);
            this.Controls.Add(this.phanung);
            this.Controls.Add(this.kqcuoi);
            this.Controls.Add(this.nhankq);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.phanloai);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.may);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.idvp);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.bvcd);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.loai);
            this.Controls.Add(this.label17);
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
            this.Controls.Add(this.gayme);
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
            this.Controls.Add(this.label15);
            this.Controls.Add(this.listpttt);
            this.Controls.Add(this.loaituoi);
            this.Controls.Add(this.bscd);
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
            this.Controls.Add(this.p_hen);
            this.Controls.Add(this.cmbma);
            this.Controls.Add(this.ma);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBS);
            this.Controls.Add(this.listICD);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.ngaysinh);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.lphai);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butTiep);
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
            this.Name = "frmPhieucls";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu chẩn đoán";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPhieucls_KeyDown);
            this.Load += new System.EventHandler(this.frmPhieucls_Load);
            this.p_hen.ResumeLayout(false);
            this.p_hen.PerformLayout();
            this.pmat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmPhieucls_Load(object sender, System.EventArgs e)
		{
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Text = "Phiếu chẩn đoán";
            user = m.user; bInmavach = v.bInmavach;
            if (bInmavach)
            {
                mabn2.MaxLength = 8;
                mabn3.MaxLength = 8;
            }
            if (m.Mabv_so == 701424) pmat.Visible = true; bDanhsach_chidinh = m.bDanhsach_bsbvchidinh;
            chkidcls.Checked = m.bIdcls_tudong; bSend_ct2003 = m.bSend_ct2003; bIdcls = m.bIdcls;
            idcls.Enabled = !chkidcls.Checked;
            chkXem.Checked = m.bPreview; bLoad_ketqua = m.bLoad_Ketqua;
            sql = "select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a where trasau=1 order by madoituong";
            foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
                s_trasau += r["madoituong"].ToString().Trim().PadLeft(2,'0') + ",";
            dscq.ReadXml("..//..//..//xml//m_cquang.xml");
			dsxml.ReadXml("..//..//..//xml//m_cls.xml");
            dsnhan.ReadXml("..//..//..//xml//m_nhan.xml");
			bTudong=m.bMabn_tudong_cdh;
			bChuyenkhoasan=m.bChuyenkhoasan;
			bChandoan=m.bChandoan_icd10;
			b_trongngoai=m.bKham_trong_ngoai_gio;
			dsloai.ReadXml("..//..//..//xml//m_loaibn.xml");
			dsbnmoi.ReadXml("..//..//..//xml//m_bnmoi.xml");
			bBacsy=m.bBacsy_tiepdon;
			bTiepdon=m.bTiepdon(LibMedi.AccessData.Cls);
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
			chandoan.Enabled=m.bChandoan;
			b_khambenh=m.bKhambenh;
			iTreem6=m.iTreem6;
			iTreem15=m.iTreem15;
            xxx = user + m.mmyy(s_ngayvv);
		}

		private void load_loai()
		{
			listpttt.DataSource=m.get_data("select a.ma,a.ten from " + user + ".cls_noidung a left join " + user + ".cls_mota b on a.id=b.id where a.loai=" + i_loai + " order by a.ma").Tables[0];
            listLoai.DataSource = m.get_data("select ma,ten,id from " + user + ".cls_phanloai where loai=" + i_loai + " order by ma").Tables[0];
            thuoc.DataSource = m.get_data("select * from " + user + ".cls_thuoc where loai=" + i_loai + " order by id").Tables[0];

            sql = "select * from " + user + ".cls_may where loai=" + i_loai;
            if (s_may != "") sql += " and id in (" + s_may.Substring(0, s_may.Length - 1) + ")";
            sql+=" order by id";           
            may.DataSource = m.get_data(sql).Tables[0];

            //idvungdg.DataSource = m.get_data("select * from " + user + ".cls_vung where loai=" + i_loai + " order by id").Tables[0];
            idvungdg.DataSource = m.get_data("select ma,ten,id from " + user + ".cls_phanloai where loai=" + i_loai + " order by ma").Tables[0];
            idvungdg.SelectedIndex = -1;
            dslloai = m.get_data("select ma,ten,id from " + user + ".cls_phanloai where loai=" + i_loai + " order by ma");
            phanloai.DataSource = dslloai.Tables[0];
            phanloai.SelectedIndex = -1;
            dslmau = m.get_data("select a.*,b.noidung from " + user + ".cls_noidung a left join " + user + ".cls_mota b on a.id=b.id where a.loai=" + i_loai + " order by a.ma");
			cmbma.DataSource=m.get_data("select a.ma,a.ten from " + user + ".cls_noidung a left join " + user + ".cls_mota b on a.id=b.id where a.loai=" + i_loai + " order by a.ma").Tables[0];
			try
			{
				thuoc.Enabled=dtloai.Rows[loai.SelectedIndex]["thuoc"].ToString()=="1";
                slthuoc.Enabled = thuoc.Enabled;
				ytaphu.Enabled=dtloai.Rows[loai.SelectedIndex]["ytaphu"].ToString()=="1";
				tenytaphu.Enabled=ytaphu.Enabled;
                canquang.Text = (i_loai == 2) ? "Tương phản" : "Cản quang";
				canquang.Enabled=dtloai.Rows[loai.SelectedIndex]["canquang"].ToString()=="1";
				gayme.Enabled=dtloai.Rows[loai.SelectedIndex]["gayme"].ToString()=="1";
                mp.Enabled = dtloai.Rows[loai.SelectedIndex]["mat"].ToString() == "1";
                mt.Enabled = dtloai.Rows[loai.SelectedIndex]["mat"].ToString() == "1";
                phanung.Enabled = dtloai.Rows[loai.SelectedIndex]["phanung"].ToString() == "1";
                sa.Enabled = dtloai.Rows[loai.SelectedIndex]["sa"].ToString() == "1";
                soluongphim.Enabled = dtloai.Rows[loai.SelectedIndex]["phim"].ToString() == "1";
                madia.Enabled = dtloai.Rows[loai.SelectedIndex]["madia"].ToString() == "1";
                may.Enabled = dtloai.Rows[loai.SelectedIndex]["may"].ToString() == "1";
				butHinh.Enabled=dtloai.Rows[loai.SelectedIndex]["hinh"].ToString()=="1";
                file_ct2003 = dtloai.Rows[loai.SelectedIndex]["path_access"].ToString();
                ten.ReadOnly = file_ct2003 != "";
                ten.BackColor = (ten.ReadOnly) ? Color.FromArgb(255,255,245) : Color.White;
                //ten.ReadOnly = file_ct2003 != "";
                DataRow r1 = m.getrowbyid(dscq.Tables[0], "mavp<>'' and loai=" + i_loai);
                s_dongthem = (r1 != null) ? r1["mavp"].ToString().Trim() : "";
			}
			catch{}
            if (cmbma.SelectedIndex != -1)
            {
                DataRow r = m.getrowbyid(dslmau.Tables[0], "ma='" + cmbma.SelectedValue.ToString() + "'");
                if (r != null)
                {
                    if (file_ct2003 == "") ten.Text = r["noidung"].ToString();//(r["noidung"].ToString() != "") ? r["noidung"].ToString() : r["ten"].ToString();
                    ma.Text = r["ma"].ToString();
                }
            }
		}

		private void load_dm()
		{
            dtkhoa = m.get_data("select ten,ten as stt from " + user + ".dmkhoachidinh order by ten").Tables[0];
            listkhoa.DataSource = dtkhoa;
            listkhoa.DisplayMember = "TEN";
            listkhoa.ValueMember = "TEN";

            dtbv = m.get_data("select ten,ten as stt from " + user + ".dmbvchidinh order by ten").Tables[0];
            listbv.DataSource = dtbv;
            listbv.DisplayMember = "TEN";
            listbv.ValueMember = "TEN";

            dtbscd = m.get_data("select * from " + user + ".dmbschidinh order by ten,benhvien ").Tables[0];
            listbscd.DataSource = dtbscd;
            listbscd.DisplayMember = "TEN";
            listbscd.ValueMember = "TEN";

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

            listLoai.DisplayMember = "TEN";
            listLoai.ValueMember = "MA";

            dticd = m.get_data("select cicd10,vviet from " + user + ".icd10 order by cicd10").Tables[0];
			listICD.DisplayMember="CICD10";
			listICD.ValueMember="VVIET";
			listICD.DataSource=dticd;

            sql = "select * from " + user + ".btdkp_bv ";
			if (s_makp!="") sql+=" where makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			sql+=" order by loai,makp";

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
            sql+=" order by trasau,madoituong";

            m.get_data(sql).WriteXml("..//..//..//xml//m_doituong.xml", XmlWriteMode.WriteSchema);
            tendoituong = new ColorComboBox(false);
            this.tendoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tendoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendoituong.Location = new System.Drawing.Point(274, 165);
            this.tendoituong.Name = "tendoituong";
            this.tendoituong.Size = new System.Drawing.Size(98, 21);
            this.tendoituong.BringToFront();
            this.tendoituong.TabIndex = 37;
            this.tendoituong.SelectedIndexChanged += new System.EventHandler(this.tendoituong_SelectedIndexChanged);
            this.tendoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendoituong_KeyDown);
            this.Controls.Add(tendoituong);
			if (tendoituong.SelectedIndex!=-1) madoituong.Text=tendoituong.SelectedValue.ToString();
            bh.Enabled = madoituong.Text == "1";

            dtytaphu = m.get_data("select * from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nghiviec + ") order by ma").Tables[0];
            dtbs = m.get_data("select * from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nghiviec + ") order by ma").Tables[0];
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

            may.DisplayMember = "TEN";
            may.ValueMember = "ID";

            phanloai.DisplayMember = "TEN";
            phanloai.ValueMember = "MA";

            idvungdg.DisplayMember = "TEN";
            idvungdg.ValueMember = "ID";

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
            butPrev.Enabled = true;
            butNext.Enabled = true;
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
            if (!listkhoa.Focused) listkhoa.Hide();
		}

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listkhoa.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                sql = "ten like '%" + makp.Text.Trim() + "%'";
                DataRow[] dr = dtkhoa.Select(sql);
                if (dr.Length == 1)
                {
                    makp.Text = dr[0]["ten"].ToString();
                    SendKeys.Send("{Tab}");
                }
                else if (listkhoa.Visible) listkhoa.Focus();
                else SendKeys.Send("{Tab}");
            }				
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
            if (bInmavach)
            {
                string s = mabn2.Text;
                if (s.Length == 8)
                {
                    mabn2.Text = s.Substring(0, 2);
                    mabn3.Text = s.Substring(2,6);
                    mabn3_Validated(sender, e);
                }
            }
            mabn2.Text = mabn2.Text.PadLeft(2, '0');
		}

		private void mabn3_Validated(object sender, System.EventArgs e)
		{
			load_btdnn(0);
            nam = "";
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
					//mabn3.Text=m.get_mabn(int.Parse(mabn2.Text),3,3,true).ToString().PadLeft(6,'0');
                    mabn3.Text = m.get_mabn(int.Parse(mabn2.Text), 1, 1, true).ToString().PadLeft(6, '0');
                    mabn3.Text = mabn3.Text.PadLeft(6, '0');
                    s_mabn = mabn2.Text + mabn3.Text;
                    emp_text(true);
                    return;
				}
				else return;
			}
            if (bInmavach)
            {
                string s = mabn3.Text;
                if (s.Length == 8)
                {
                    mabn2.Text = s.Substring(0, 2);
                    mabn3.Text = s.Substring(2,6);
                }
            }
			mabn3.Text=mabn3.Text.PadLeft(6,'0');
			s_mabn=mabn2.Text+mabn3.Text;
			emp_text(true);
            phanloai.DataSource = m.get_data("select ma,ten,id from " + user + ".cls_phanloai where loai=" + i_loai + " order by ma").Tables[0];
            cmbma.DataSource = m.get_data("select a.ma,a.ten from " + user + ".cls_noidung a left join " + user + ".cls_mota b on a.id=b.id where a.loai=" + i_loai + " order by a.ma").Tables[0];
			if (load_mabn())
			{
				if (ngayvv.Text=="")
				{
					if (load_vv_mabn())
					{
						if (!bAdmin) ena_but(false);
					}
					else load_tiepdon(m.Ngayhienhanh,true);
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
			sql="select a.*,b.bacsy,b.benhvien from "+user+mmyy+".tiepdon a,"+user+mmyy+".tttiepdon b where a.maql=b.maql and a.mabn='"+s_mabn+"'"+" and to_char(a.ngay,'dd/mm/yyyy')='"+m_ngay+"'";
			if (s_makp!="" )
			{
				string s=s_makp.Replace(",","','");
				sql+=" and a.makp in ('"+s.Substring(0,s.Length-3)+"')";
			}
			sql+=" order by a.ngay desc";
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
                bh.Enabled = madoituong.Text == "1";
                bscd.Text = r["bacsy"].ToString();
                bvcd.Text = r["benhvien"].ToString();
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
			treeView1.Visible=true;
		}

		private void load_vv_maql(bool skip)
		{
			//emp_vv();
            if (ngayvv.Text == "") return;
            xxx = user + m.mmyy(ngayvv.Text);
			ena_but(true);
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
                bh.Enabled = madoituong.Text == "1";
                chandoan.Text = r["chandoan"].ToString();
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
				tendoituong.SelectedValue=r["madoituong"].ToString();
				madoituong.Text=r["madoituong"].ToString();
                bh.Enabled = madoituong.Text == "1";
				break;
			}
			load_vv();
			return l_maql!=0;
		}

		private void load_vv()
		{
            xxx = user + m.mmyy(ngayvv.Text);
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
            ngaytra.Text = ""; giotra.Text = "";
			pic.Image=null;
			p_hen.Visible=false;
            bool bAdd = false;
			if (l_id!=0)
			{
                xxx = user + m.mmyy(ngayvv.Text);
				DataRow r1;
                bool bTra1 = false, bTra2=false;
                decimal st = 0, cps = 0,lts=0;
                sql = "select a.*,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,to_char(b.ngaytra,'dd/mm/yyyy hh24:mi') as ngaytra,c.hinh,d.ma ";
                sql+="from "+xxx+".cls_ketqua a left join "+xxx+".cls_hen b on a.id=b.id ";
                sql+=" left join "+xxx+".cls_hinh c on a.id=c.id left join "+user+".cls_noidung d on a.idvung=d.id where a.id=" + l_id;
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					s_ngayvv=r["ngayvv"].ToString();
                    ngayvv.Text = s_ngayvv.Substring(0, 10);
                    giovv.Text = s_ngayvv.Substring(11);
					chandoan.Text=r["chandoan"].ToString();
                    makp.Text = r["makpcd"].ToString();
                    bscd.Text = r["bscd"].ToString();
                    bvcd.Text = r["bvcd"].ToString();
					tendoituong.SelectedValue=r["madoituong"].ToString();
					madoituong.Text=r["madoituong"].ToString();
                    bh.Enabled = madoituong.Text == "1";
					bsth.Text=r["mabs"].ToString();
					r1=m.getrowbyid(dtbs,"ma='"+bsth.Text+"'");
					if (r1!=null) tenbsth.Text=r1["hoten"].ToString();
					else tenbsth.Text="";
					ytaphu.Text=r["maktv"].ToString();
					r1=m.getrowbyid(dtytaphu,"ma='"+ytaphu.Text+"'");
					if (r1!=null) tenytaphu.Text=r1["hoten"].ToString();
					else tenytaphu.Text="";
                    may.SelectedValue = r["idmay"].ToString();
					ma.Text=r["ma"].ToString();
					cmbma.SelectedValue=ma.Text;
                    //ten.Text = r["ketqua"].ToString();
                    r1=m.getrowbyid(dslloai.Tables[0],"id="+int.Parse(r["idloai"].ToString()));
                    if (r1 != null)
                    {
                        maloai.Text = r1["ma"].ToString();
                        phanloai.SelectedValue = maloai.Text;
                    }
                    else
                    {
                        maloai.Text = ""; phanloai.SelectedIndex = -1;
                    }
                    idvungdg.SelectedValue = r["idvungdg"].ToString();
                    kqcuoi.Checked = r["kqcuoi"].ToString().Trim() == "1";
                    madia.Text = r["madia"].ToString();
                    soluongphim.Text = r["soluongphim"].ToString();
                    nhankq.Text = r["nhankq"].ToString();
                    idcls.Text = r["idcls"].ToString();
                    idvp.Text = r["idvp"].ToString();
                    ten.Text = r["ketqua"].ToString();
                    cps = decimal.Parse(r["cp"].ToString());
                    lts = decimal.Parse(r["lt"].ToString());
                    if (file_ct2003 != "" && idcls.Text.Trim().Length==9)
                    {
                        //ten.Text = cvf.Vni_Uni(m.get_ket_qua_cls(file_ct2003, idcls.Text));
                        foreach (DataRow r2 in m.get_data_acc("select * from bnhan where trim(id)='" + idcls.Text.Trim() + "'", file_ct2003).Tables[0].Rows)
                        {
                            ten.Text = cvf.Vni_Uni(r2["ketqua"].ToString());
                            chandoan.Text = cvf.Vni_Uni(r2["lamsang"].ToString());
                            tenbsth.Text = cvf.Vni_Uni(r2["bs_kham"].ToString());
                            r1 = m.getrowbyid(dtbs, "hoten='" + tenbsth.Text + "'");
                            if (r1 != null) bsth.Text = r1["ma"].ToString();
                            if (bscd.Text == "") bscd.Text = cvf.Vni_Uni(r2["bs_cd"].ToString());
                            if (makp.Text == "") makp.Text = cvf.Vni_Uni(r2["khoa_cd"].ToString());
                            if (bvcd.Text == "") bvcd.Text = cvf.Vni_Uni(r2["bv_cd"].ToString());
                            canquang.Checked = r2["canquang"].ToString().Trim().IndexOf("010") != -1;
                            tenytaphu.Text = cvf.Vni_Uni(r2["ktv_kham1"].ToString());
                            r1 = m.getrowbyid(dtbs, "hoten='" + tenytaphu.Text + "'");
                            if (r1 != null) ytaphu.Text = r1["ma"].ToString();
                            break;
                        }
                    }
                    //else ten.Text = r["ketqua"].ToString();
                    if (idvp.Text != "")
                    {
                        sql = "select a.id,b.soluong*b.dongia as sotien from xxx.v_vienphill a,xxx.v_vienphict b," + user + ".v_giavp c," + user + ".v_loaivp d," + user + ".cls_loai e";
                        sql += " where a.id=b.id and b.mavp=c.id and c.id_loai=d.id and d.id=e.nhomvp and e.id=" + i_loai;
                        sql += " and a.mabn='" + mabn2.Text + mabn3.Text + "'";
                        sql += " and b.tra>0 and a.id="+decimal.Parse(idvp.Text);
                        if (s_dongthem != "") sql += " and b.mavp not in (" + s_dongthem + ")";
                        bTra1 = m.get_data_mmyy(sql, ngayvv.Text, ngayvv.Text, true).Tables[0].Rows.Count > 0;
                        if (!bTra1)
                        {
                            sql = "select a.id,b.soluong*b.dongia as sotien from xxx.v_vienphill a,xxx.v_vienphict b," + user + ".v_giavp c," + user + ".v_loaivp d," + user + ".cls_loai e";
                            sql += " where a.id=b.id and b.mavp=c.id and c.id_loai=d.id and d.id=e.nhomvp and e.id=" + i_loai;
                            sql += " and a.mabn='" + mabn2.Text + mabn3.Text + "'";
                            sql += " and b.tra>0 ";
                            if (s_dongthem != "") sql += " and b.mavp in (" + s_dongthem + ")";
                            bTra2 = m.get_data_mmyy(sql, ngayvv.Text, ngayvv.Text, true).Tables[0].Rows.Count > 0;
                        }
                    }
                    else if (cps == 0 && lts == 0)
                    {
                        mmyy = m.mmyy(ngayvv.Text);
                        if (m.bMmyy(mmyy))
                        {
                            sql = "select a.id,b.soluong*b.dongia as sotien from xxx.v_vienphill a,xxx.v_vienphict b," + user + ".v_giavp c," + user + ".v_loaivp d," + user + ".cls_loai e";
                            sql += " where a.id=b.id and b.mavp=c.id and c.id_loai=d.id and d.id=e.nhomvp and e.id=" + i_loai;
                            sql += " and a.mabn='" + mabn2.Text + mabn3.Text + "'";
                            sql += " and b.tra=0 and b.done=0";
                            if (s_dongthem != "") sql += " and b.mavp not in (" + s_dongthem + ")";
                            sql += " order by a.ngay,b.stt";
                            st = 0;
                            foreach (DataRow r2 in m.get_data_mmyy(sql, ngayvv.Text, ngayvv.Text, true).Tables[0].Rows)
                            {
                                idvp.Text = r2["id"].ToString();
                                st = decimal.Parse(r2["sotien"].ToString());
                                cp.Text = st.ToString("#,###,###,###");
                                lt.Text = cp.Text;
                                break;
                            }
                            if (s_dongthem != "")
                            {
                                sql = "select a.id,b.soluong*b.dongia as sotien from xxx.v_vienphill a,xxx.v_vienphict b," + user + ".v_giavp c," + user + ".v_loaivp d," + user + ".cls_loai e";
                                sql += " where a.id=b.id and b.mavp=c.id and c.id_loai=d.id and d.id=e.nhomvp and e.id=" + i_loai;
                                sql += " and a.mabn='" + mabn2.Text + mabn3.Text + "'";
                                sql += " and b.tra=0 and b.done=0";
                                sql += " and b.mavp in (" + s_dongthem + ")";
                                sql += " order by a.ngay,b.stt";
                                foreach (DataRow r2 in m.get_data_mmyy(sql, ngayvv.Text, ngayvv.Text, true).Tables[0].Rows)
                                {
                                    st += decimal.Parse(r2["sotien"].ToString());
                                    cp.Text = st.ToString("#,###,###,###");
                                    lt.Text = cp.Text;
                                    break;
                                }
                            }
                            bAdd = st != 0;
                            cps = st; lts = st;
                        }
                    }
                    if (bTra1 || bTra2)
                    {
                        sql = "select a.id,b.soluong*b.dongia as sotien from xxx.v_vienphill a,xxx.v_vienphict b," + user + ".v_giavp c," + user + ".v_loaivp d," + user + ".cls_loai e";
                        sql += " where a.id=b.id and b.mavp=c.id and c.id_loai=d.id and d.id=e.nhomvp and e.id=" + i_loai;
                        sql += " and a.mabn='" + mabn2.Text + mabn3.Text + "'";
                        sql += " and b.tra=0 ";
                        if (bTra1) sql += "and b.done=0";
                        if (s_dongthem != "") sql += " and b.mavp not in (" + s_dongthem + ")";
                        sql += " order by a.ngay,b.stt";
                        st = 0;
                        foreach (DataRow r2 in m.get_data_mmyy(sql, ngayvv.Text, ngayvv.Text, true).Tables[0].Rows)
                        {
                            idvp.Text = r2["id"].ToString();
                            st = decimal.Parse(r2["sotien"].ToString());
                            cp.Text = st.ToString("#,###,###,###");
                            lt.Text = cp.Text;
                            break;
                        }
                        if (s_dongthem != "")
                        {
                            sql = "select b.done,a.id,b.soluong*b.dongia as sotien from xxx.v_vienphill a,xxx.v_vienphict b," + user + ".v_giavp c," + user + ".v_loaivp d," + user + ".cls_loai e";
                            sql += " where a.id=b.id and b.mavp=c.id and c.id_loai=d.id and d.id=e.nhomvp and e.id=" + i_loai;
                            sql += " and a.mabn='" + mabn2.Text + mabn3.Text + "'";
                            sql += " and b.tra=0";
                            sql += " and b.mavp in (" + s_dongthem + ")";
                            sql += " order by a.ngay,b.stt";
                            bool bFound = false,bDone=false;                            
                            foreach (DataRow r2 in m.get_data_mmyy(sql, ngayvv.Text, ngayvv.Text, true).Tables[0].Rows)
                            {
                                if (r2["done"].ToString() == "1") bDone = true;
                                else if (r2["done"].ToString() == "0" && !bFound)
                                {
                                    st += decimal.Parse(r2["sotien"].ToString());
                                    bFound = true;
                                }                                
                            }
                            if (bDone)
                            {
                                cp.Text = cps.ToString("#,###,###,###");
                                lt.Text=lts.ToString("#,###,###,###");
                            }
                            else
                            {
                                cp.Text = st.ToString("#,###,###,###");
                                lt.Text = cp.Text;
                            }
                        }
                    }
                    else
                    {
                        if (!bAdd)
                        {
                            st = decimal.Parse(r["cp"].ToString());
                            cp.Text = st.ToString("#,###,###,###");
                            st = decimal.Parse(r["lt"].ToString());
                            lt.Text = st.ToString("#,###,###,###");
                        }
                        else
                        {
                            cp.Text = cps.ToString("#,###,###,###");
                            lt.Text = lts.ToString("#,###,###,###");
                        }
                        if (s_dongthem != "")
                        {
                            sql = "select a.id,b.soluong*b.dongia as sotien from xxx.v_vienphill a,xxx.v_vienphict b," + user + ".v_giavp c," + user + ".v_loaivp d," + user + ".cls_loai e";
                            sql += " where a.id=b.id and b.mavp=c.id and c.id_loai=d.id and d.id=e.nhomvp and e.id=" + i_loai;
                            sql += " and a.mabn='" + mabn2.Text + mabn3.Text + "'";
                            sql += " and b.tra=0 and b.done=0";
                            sql += " and b.mavp in (" + s_dongthem + ")";
                            sql += " order by a.ngay,b.stt";
                            foreach (DataRow r2 in m.get_data_mmyy(sql, ngayvv.Text, ngayvv.Text, true).Tables[0].Rows)
                            {
                                st += decimal.Parse(r2["sotien"].ToString());
                                cp.Text = st.ToString("#,###,###,###");
                                lt.Text = st.ToString("#,###,###,###");
                                break;
                            }
                        }
                        st = decimal.Parse(r["bh"].ToString());
                        bh.Text = st.ToString("#,###,###,###");
                    }
					if (r["ngaytra"].ToString()!="")
					{
						hen.Checked=true;
						p_hen.Visible=true;
                        ngaytra.Text = r["ngaytra"].ToString().Substring(0, 10);
                        giotra.Text = r["ngaytra"].ToString().Substring(11);
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
                        slthuoc.Text = r["soluong"].ToString();
						break;
					}
				}
				if (canquang.Enabled || gayme.Enabled || phanung.Enabled || sa.Enabled)
				{
					foreach(DataRow r in m.get_data("select * from "+xxx+".cls_motact where id="+l_id).Tables[0].Rows)
					{
						canquang.Checked=r["canquang"].ToString().Trim()=="1";
						gayme.Checked=r["gayme"].ToString().Trim()=="1";
                        phanung.Checked = r["phanung"].ToString().Trim() == "1";
                        sa.Checked = r["sa"].ToString().Trim() == "1";
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

		private void frmPhieucls_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
                bh.Enabled = madoituong.Text == "1";
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
            sonha.Text = ""; thon.Text = ""; idcls.Text = ""; idvp.Text = "";
            cholam.Text = ""; s_hinh = ""; bsth.Text = ""; tenbsth.Text = ""; idvungdg.SelectedIndex = -1;
            ytaphu.Text = ""; tenytaphu.Text = ""; maloai.Text = ""; phanloai.SelectedIndex = -1;
            bscd.Text = ""; bvcd.Text = ""; madia.Text = ""; cp.Text = ""; lt.Text = ""; bh.Text = ""; soluongphim.Text = "";
            phanung.Checked = false; sa.Checked = false; kqcuoi.Checked = false; nhankq.Text = "";
            pic.Image = null; slthuoc.Text = "";
			if (pmat.Visible)
			{
				mp.Checked=false;mt.Checked=false;
			}
			canquang.Checked=false;
			gayme.Checked=false;
			tentqx.SelectedIndex=-1;
			tqx.Text="";	l_maql=0;	l_matd=0;	l_id=0;	b_Edit=false;
			tentinh.SelectedValue=m.Mabv.Substring(0,3);
			tendantoc.SelectedValue="25";
			tennuoc.SelectedValue="VN";
			treeView1.Nodes.Clear();
			hen.Checked=false;
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
                bh.Enabled = madoituong.Text == "1";
			}
			catch{}
			chandoan.Text="";
			ten.Text="";
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

			if (namsinh.Text!="" && mann.Text!="")
			{
				if (!m.Kiemtra_mann(mann.Text,DateTime.Now.Year-int.Parse(namsinh.Text),iTreem6,iTreem15))
				{
					MessageBox.Show(lan.Change_language_MessageText("Nghề nghiệp và độ tuổi không hợp lệ !"),LibMedi.AccessData.Msg);
					mann.Focus();
					return false;
				}
			}
            //if (namsinh.Text!="" && makp.Text!="")
            //{
            //    if (DateTime.Now.Year-int.Parse(namsinh.Text)>iKhamnhi)
            //    {
            //        if (m.kiemtra_khamnhi(makp.Text))
            //        {
            //            MessageBox.Show(lan.Change_language_MessageText("Độ tuổi và phòng khám không hợp lệ !"),LibMedi.AccessData.Msg);
            //            makp.Focus();
            //            return false;
            //        }
            //    }
            //}
			if ((bsth.Text=="" && tenbsth.Text!="") || (bsth.Text!="" && tenbsth.Text==""))
			{
				MessageBox.Show(lan.Change_language_MessageText("Y bác sỹ thực hiện !"),LibMedi.AccessData.Msg);
                bsth.Focus();
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
			if (thuoc.Enabled && thuoc.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn thuốc !"),LibMedi.AccessData.Msg);
				thuoc.Focus();
				return false;
			}
            if (idcls.Text.Trim().Length!=9 && idcls.Enabled)
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập ID cận lâm sàng !"), s_msg);
                idcls.Focus();
                return false;
            }
            if (idcls.Enabled)
            {
                if (idcls.Text.Substring(0, 6) != ngayvv.Text.Substring(8, 2) + ngayvv.Text.Substring(3, 2) + ngayvv.Text.Substring(0, 2))
                {
                    MessageBox.Show(lan.Change_language_MessageText("ID cận lâm sàng 6 ký tự đầu phải là :") + ngayvv.Text.Substring(8, 2) + ngayvv.Text.Substring(3, 2) + ngayvv.Text.Substring(0, 2), s_msg);
                    if (idcls.Text.Length == 9)
                        idcls.Text = ngayvv.Text.Substring(8, 2) + ngayvv.Text.Substring(3, 2) + ngayvv.Text.Substring(0, 2) + idcls.Text.Substring(6);
                    idcls.Focus();
                    return false;
                }
                if (idcls.Focused) return false;
            }
            idvung = 0;
            DataRow r = m.getrowbyid(dslmau.Tables[0], "ma='" + cmbma.SelectedValue.ToString() + "'");
            if (r != null) idvung = int.Parse(r["id"].ToString());
            idloai = 0;
            r = m.getrowbyid(dslloai.Tables[0], "ma='" + maloai.Text + "'");
            if (r != null) idloai = int.Parse(r["id"].ToString());
			mmyy=m.mmyy(ngayvv.Text);
			if (!m.bMmyy(mmyy)) m.tao_schema(mmyy,i_userid);
            if (bIdcls && idcls.Text.Trim().Length==9)
            {
                string s=m.Kiemtra_idcls(ngayvv.Text, i_loai, mabn2.Text + mabn3.Text, idcls.Text);
                if (s!="")
                {
                    MessageBox.Show(lan.Change_language_MessageText("ID CLS ") + idcls.Text + "\n"+lan.Change_language_MessageText("Đã nhập vào ") + s, LibMedi.AccessData.Msg);
                    return false;
                }
            }
            if (cp.Text != "")
            {
                decimal _cp = decimal.Parse(cp.Text);
                if (_cp < 0 && s_trasau.IndexOf(madoituong.Text.Trim().PadLeft(2, '0')) == -1)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Yêu cầu chọn đối tượng trả sau !"), LibMedi.AccessData.Msg);
                    tendoituong.Focus();
                    return false;
                }
                if (_cp > 0 && madoituong.Text.Trim() == "3")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Yêu cầu chọn đối tượng thu phí !"), LibMedi.AccessData.Msg);
                    tendoituong.Focus();
                    return false;
                }
            }
            if (lt.Text == "")
            {
                if (madoituong.Text != "3" && s_trasau.IndexOf(madoituong.Text.Trim().PadLeft(2, '0')) == -1)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Yêu cầu chọn đối tượng trả sau !"), LibMedi.AccessData.Msg);
                    tendoituong.Focus();
                    return false;
                }
            }
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
					m.upd_tiepdon(s_mabn,l_maql,l_matd,"01",ngayvv.Text+" "+giovv.Text,int.Parse(madoituong.Text),"",tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),i_userid,0,LibMedi.AccessData.Cls,0);
				}
			}
			m.upd_sukien(ngayvv.Text+" "+giovv.Text,s_mabn,l_matd,LibMedi.AccessData.Cls,l_maql);
			if (manuoc.Enabled && manuoc.Text!="") m.upd_nuocngoai(s_mabn,manuoc.Text);
			else m.execute_data("delete from "+user+".nuocngoai where mabn='"+s_mabn+"'");
            itable = m.tableid(m.mmyy(ngayvv.Text), "cls_ketqua");
            if (m.get_id_cls_ketqua(s_mabn, ngayvv.Text+" "+giovv.Text, i_loai,true) != 0)
            {
                m.upd_eve_tables(ngayvv.Text, itable, i_userid, "upd");
                m.upd_eve_upd_del(ngayvv.Text, itable, i_userid, "upd", l_id.ToString() + "^" + i_loai.ToString() + "^" + s_mabn + "^" + l_matd.ToString() + "^" + l_maql.ToString() + "^" + ngayvv.Text + " " + giovv.Text + "^" + madoituong.Text + "^" + idcls.Text + "^" + idvp.Text + "^" + bscd.Text + "^" + makp.Text + "^" + bvcd.Text + "^" + ((cp.Text == "") ? "0" : cp.Text) + "^" + ((lt.Text == "") ? "0" : lt.Text) + "^" + ((bh.Text == "") ? "0" : bh.Text) + "^" + chandoan.Text + "^" + ten.Text + "^" + bsth.Text + "^" + ytaphu.Text + "^" + ((may.SelectedIndex != -1) ? may.SelectedValue.ToString() : "0") + "^" + idvung.ToString() + "^" + ((idvungdg.SelectedIndex != -1) ? idvungdg.SelectedValue.ToString() : "0") + "^" + ((phanloai.SelectedIndex != -1) ? phanloai.SelectedValue.ToString() : "0") + "^" + ((kqcuoi.Checked) ? "1" : "0") + "^" + madia.Text + "^" + ((soluongphim.Text == "") ? "0" : soluongphim.Text) + "^" + nhankq.Text + "^" + i_userid.ToString());
            }
            else m.upd_eve_tables(ngayvv.Text, itable, i_userid, "ins");
			l_id=m.get_id_cls_ketqua(s_mabn,ngayvv.Text+" "+giovv.Text,i_loai);
            m.upd_cls_ketqua(l_id, i_loai, s_mabn, l_matd, l_maql, ngayvv.Text + " " + giovv.Text, int.Parse(madoituong.Text), idcls.Text, idvp.Text, bscd.Text, makp.Text, bvcd.Text, (cp.Text == "") ? 0 : decimal.Parse(cp.Text), (lt.Text == "") ? 0 : decimal.Parse(lt.Text), (bh.Text == "") ? 0 : decimal.Parse(bh.Text), chandoan.Text, ten.Text, bsth.Text, ytaphu.Text, (may.SelectedIndex != -1) ? int.Parse(may.SelectedValue.ToString()) : 0, idvung, (idvungdg.SelectedIndex != -1) ? int.Parse(idvungdg.SelectedValue.ToString()) : 0, idloai,(kqcuoi.Checked) ? 1 : 0, madia.Text, (soluongphim.Text == "") ? 0 : int.Parse(soluongphim.Text), nhankq.Text, i_userid);
			if (pmat.Visible && !(canquang.Enabled || gayme.Enabled)) m.upd_cls_mat(ngayvv.Text,l_id,(mp.Checked)?1:0,(mt.Checked)?1:0);
			if (thuoc.Enabled) m.upd_cls_sdthuoc(ngayvv.Text,l_id,int.Parse(thuoc.SelectedValue.ToString()),(slthuoc.Text=="")?0:decimal.Parse(slthuoc.Text));
			if (hen.Checked) m.upd_cls_hen(ngayvv.Text,l_id,0,"",0,"",ngaytra.Text+" "+giotra.Text);
			else m.execute_data("delete from "+xxx+".cls_hen where id="+l_id);
			if (s_hinh!="") m.upd_cls_hinh(ngayvv.Text,l_id,1,s_hinh);
			else m.execute_data("delete from "+xxx+".cls_hinh where id="+l_id);
			//if (canquang.Enabled || gayme.Enabled || phanung.Checked || sa.Checked)
                m.upd_cls_motact(ngayvv.Text, l_id, (canquang.Checked) ? 1 : 0, (gayme.Checked) ? 1 : 0, (phanung.Checked) ? 1 : 0, (sa.Checked) ? 1 : 0);
            //if (ten.Text != "" && bLoad_ketqua) m.upd_cls_mota(idvung,ten.Text);
            if (file_ct2003 != "" && bSend_ct2003)
            {
                string m_diachi = "";
                m_diachi = sonha.Text.Trim() + " " + thon.Text.Trim();
                if (matt.Text != "100" || matt.Text != "000")
                {
                    if (mapxa2.Text != "00") m_diachi += " " + tenpxa.Text.Trim();
                    if (maqu2.Text != "00") m_diachi += "  " + tenquan.Text.Trim();
                    if (matt.Text != "100" && matt.Text != "000") m_diachi += "  " + tentinh.Text.Trim();
                }
                m_diachi += " - " + cholam.Text.Trim();
                m.upd_ketqua_ct(@file_ct2003, idcls.Text, cvf.Uni_vni(hoten.Text), tuoi.Text,cvf.Uni_vni(m_diachi), (phai.Text == "Nam" ? -1 : 0), cvf.Uni_vni(bscd.Text),
                    cvf.Uni_vni(makp.Text), cvf.Uni_vni(bvcd.Text), cvf.Uni_vni(cmbma.Text),(canquang.Checked)?"010":"100", m.StringToMMDDYYYY(ngayvv.Text) + " " + giovv.Text, m.StringToMMDDYYYY(ngayvv.Text) + " " + giovv.Text,cvf.Uni_vni(chandoan.Text),
                        "", cvf.Uni_vni(tenbsth.Text).ToUpper(), cvf.Uni_vni(tenytaphu.Text), may.Text, (cp.Text != "" ? decimal.Parse(cp.Text) : 0), "", ngaytra.Text, madia.Text,
                        (soluongphim.Text != "" ? int.Parse(soluongphim.Text) : 0), idcls.Text, idcls.Text.Substring(0, 6), (canquang.Checked ? 0 : -1), "", (sa.Checked ? 0 : -1), (phanung.Checked ? 0 : -1), (kqcuoi.Checked ? 0 : -1));
                if (idcls.Text!="" && idcls.Enabled) ins_idcls();
            }
            if (idvp.Text != "")
            {
                sql = "select a.id,to_char(a.ngay,'dd/mm/yyyy') as ngay,b.mavp from xxx.v_vienphill a,xxx.v_vienphict b," + user + ".v_giavp c," + user + ".v_loaivp d," + user + ".cls_loai e";
                sql += " where a.id=b.id and b.mavp=c.id and c.id_loai=d.id and d.id=e.nhomvp and e.id=" + i_loai;
                sql += " and a.mabn='" + mabn2.Text + mabn3.Text + "'";
                sql += " and b.tra=0 and b.done=0 and a.id="+decimal.Parse(idvp.Text);
                if (s_dongthem != "") sql += " and b.mavp not in (" + s_dongthem + ")";
                sql += " order by a.ngay,b.stt";
                foreach (DataRow r in m.get_data_mmyy(sql, ngayvv.Text, ngayvv.Text, true).Tables[0].Rows)
                {
                    m.execute_data("update " + user + m.mmyy(r["ngay"].ToString()) + ".v_vienphict set done=1 where tra=0 and done=0 and mavp=" + decimal.Parse(r["mavp"].ToString()) + " and id=" + decimal.Parse(r["id"].ToString()));
                    break;
                }
                if (s_dongthem!="")
                {
                    sql = "select a.id,to_char(a.ngay,'dd/mm/yyyy') as ngay,b.mavp from xxx.v_vienphill a,xxx.v_vienphict b," + user + ".v_giavp c," + user + ".v_loaivp d," + user + ".cls_loai e";
                    sql += " where a.id=b.id and b.mavp=c.id and c.id_loai=d.id and d.id=e.nhomvp and e.id=" + i_loai;
                    sql += " and a.mabn='" + mabn2.Text + mabn3.Text + "'";
                    sql += " and b.tra=0 and b.done=0 and b.mavp in ("+s_dongthem+")";
                    sql += " order by a.ngay,b.stt";
                    foreach (DataRow r in m.get_data_mmyy(sql, ngayvv.Text, ngayvv.Text, true).Tables[0].Rows)
                    {
                        m.execute_data("update " + user + m.mmyy(r["ngay"].ToString()) + ".v_vienphict set done=1 where tra=0 and done=0 and mavp=" + decimal.Parse(r["mavp"].ToString()) + " and id=" + decimal.Parse(r["id"].ToString()));
                        break;
                    }
                }
            }
            if (bDanhsach_chidinh)
            {
                r3 = m.getrowbyid(dtbscd, "ten='" + bscd.Text + "' and benhvien='" + bvcd.Text + "'");
                if (r3 == null)
                {
                    r4 = dtbscd.NewRow();
                    r4["ten"] = bscd.Text;
                    r4["benhvien"] = bvcd.Text;
                    r4["khoa"] = makp.Text;
                    dtbscd.Rows.Add(r4);
                }
                r3 = m.getrowbyid(dtbv, "ten='" + bvcd.Text + "'");
                if (r3 == null)
                {
                    r4 = dtbv.NewRow();
                    r4["ten"] = bvcd.Text;
                    dtbv.Rows.Add(r4);
                }
                r3 = m.getrowbyid(dtkhoa, "ten='" + makp.Text + "'");
                if (r3 == null)
                {
                    r4 = dtkhoa.NewRow();
                    r4["ten"] = makp.Text;
                    dtkhoa.Rows.Add(r4);
                }
                m.upd_dmbschidinh(bscd.Text, bvcd.Text, makp.Text);
                m.upd_dmbvchidinh(bvcd.Text);
                m.upd_dmkhoachidinh(makp.Text);
            }
			if (sender!=null)
			{
				ena_but(false);
				butTiep.Focus();
			}
		}

        private void ins_idcls()
        {
            sql= "select to_number(substr(idcls,7,3),'999') as so from " + user + m.mmyy(ngayvv.Text) + ".cls_ketqua where loai=" + int.Parse(loai.SelectedValue.ToString());
            sql+= " and to_char(ngay,'dd/mm/yyyy')='" + ngayvv.Text.Substring(0, 10) + "'";
            sql+=" and to_number(substr(idcls,7,3),'999')<"+int.Parse(idcls.Text.Substring(6));
            sql += " order by idcls desc";
            DataTable tmp = m.get_data(sql).Tables[0];
            int i = 1;
            if (tmp.Rows.Count > 0) i = int.Parse(tmp.Rows[0]["so"].ToString());
            DataRow r;
            for (; i < int.Parse(idcls.Text.Substring(6)); i++)
            {
                r = m.getrowbyid(tmp, "so=" + i);
                if (r==null) m.execute_data_acc("insert into bnhan(id,vung_ct) values ('" + idcls.Text.Substring(0, 6) + i.ToString().PadLeft(3, '0') + "',' ')", file_ct2003);
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
            try
            {
                TreeNode node;
                sql = "select ngay,ketqua,to_char(ngay,'yyyymmdd') as yyyymmdd from xxx.cls_ketqua where mabn='" + s_mabn + "'";
                if (s_cls != "") sql += " and loai in (" + s_cls.Substring(0, s_cls.Length - 1) + ")";
                foreach (DataRow r in m.get_data_nam(nam, sql).Tables[0].Select("true", "yyyymmdd desc"))
                {
                    node = treeView1.Nodes.Add(m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString())));
                    node.Nodes.Add(r["ketqua"].ToString());
                }
                //treeView1.ExpandAll();
            }
            catch { }
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
					sql="select loai from "+xxx+".cls_ketqua where mabn='"+s_mabn+"' and to_char(ngay,'dd/mm/yyyy hh24:mi')='"+ngay+"'";
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
							l_id=m.get_id_cls_ketqua(s_mabn,ngay,i_loai,true);
							load_cls();
						}
						catch{}
					}
				}
				catch{}
			}
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

		private void tuoi_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			m.MaskDigit(e);
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

		private void hen_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==hen) p_hen.Visible=hen.Checked;
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
					//if (file_ct2003=="" && bLoad_ketqua) ten.Text=r["noidung"].ToString();//(r["noidung"].ToString()!="")?r["noidung"].ToString():r["ten"].ToString();
					ma.Text=r["ma"].ToString();
				}
			}
		}

		private void load_mau(string ma)
		{
			cmbma.DataSource=m.get_data("select ma,ten from " + user + ".cls_noidung where loai=" + i_loai + " and ma like '%" + ma.Trim() + "%' order by ma").Tables[0];
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
					//if (file_ct2003=="" && bLoad_ketqua) ten.Text=r["noidung"].ToString();//(r["noidung"].ToString()!="")?r["noidung"].ToString():r["ten"].ToString();
					load_mau(ma.Text);
					cmbma.SelectedValue=ma.Text;
				}
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
				else SendKeys.Send("{Tab}");
			}		
		}

		private void tenbsth_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbsth)
			{
				Filt_tenbsth(tenbsth.Text);
				if (ytaphu.Enabled) listBSTH.BrowseToICD10(tenbsth,bsth,ytaphu,bsth.Location.X,bsth.Location.Y+bsth.Height,bsth.Width+tenbsth.Width+2,bsth.Height);
				else if (may.Enabled) listBSTH.BrowseToICD10(tenbsth,bsth,may,bsth.Location.X,bsth.Location.Y+bsth.Height,bsth.Width+tenbsth.Width+2,bsth.Height);
                else listBSTH.BrowseToICD10(tenbsth, bsth, ma, bsth.Location.X, bsth.Location.Y + bsth.Height, bsth.Width + tenbsth.Width + 2, bsth.Height);
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
				else SendKeys.Send("{Tab}");
			}		
		}

		private void tenytaphu_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenytaphu)
			{
				Filt_tenytaphu(tenytaphu.Text);
                if (may.Enabled) listytaphu.BrowseToICD10(tenytaphu,ytaphu,may,ytaphu.Location.X,ytaphu.Location.Y+ytaphu.Height,ytaphu.Width+tenytaphu.Width+2,ytaphu.Height);
                else listytaphu.BrowseToICD10(tenytaphu, ytaphu, ma, ytaphu.Location.X, ytaphu.Location.Y + ytaphu.Height, ytaphu.Width + tenytaphu.Width + 2, ytaphu.Height);
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
            if (this.ActiveControl == tendoituong)
            {
                madoituong.Text = tendoituong.SelectedValue.ToString();
                bh.Enabled = madoituong.Text == "1";
            }
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			s_mabn=mabn2.Text+mabn3.Text;
			if (s_mabn.Length!=8 || ngayvv.Text=="") return;
			l_id=m.get_id_cls_ketqua(s_mabn,ngayvv.Text+" "+giovv.Text,i_loai,true);
			if (l_id!=0)
			{
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
                    if (file_ct2003 != "" && bSend_ct2003 && idcls.Text != "")
                    {
                        if (m.get_data_acc("select * from bnhan where id='" + idcls.Text + "' and ketqua is null", file_ct2003).Tables[0].Rows.Count == 0)
                        {
                            MessageBox.Show(lan.Change_language_MessageText("ID :")+" " + idcls.Text + "\nĐã có kết quả, không được hủy !", LibMedi.AccessData.Msg);
                            return;
                        }
                    }
                    if (idvp.Text != "")
                    {
                        sql = "select a.id,to_char(a.ngay,'dd/mm/yyyy') as ngay,b.mavp from xxx.v_vienphill a,xxx.v_vienphict b," + user + ".v_giavp c," + user + ".v_loaivp d," + user + ".cls_loai e";
                        sql += " where a.id=b.id and b.mavp=c.id and c.id_loai=d.id and d.id=e.nhomvp and e.id=" + i_loai;
                        sql += " and a.mabn='" + mabn2.Text + mabn3.Text + "'";
                        sql += " and b.tra=0 and b.done=1 and a.id=" + decimal.Parse(idvp.Text);
                        if (s_dongthem != "") sql += " and b.mavp not in (" + s_dongthem + ")";
                        sql += " order by a.ngay,b.stt";
                        foreach (DataRow r in m.get_data_mmyy(sql, ngayvv.Text, ngayvv.Text, true).Tables[0].Rows)
                        {
                            m.execute_data("update " + user + m.mmyy(r["ngay"].ToString()) + ".v_vienphict set done=0 where tra=0 and done=1 and mavp=" + decimal.Parse(r["mavp"].ToString()) + " and id=" + decimal.Parse(r["id"].ToString()));
                            break;
                        }
                        if (s_dongthem != "")
                        {
                            sql = "select a.id,to_char(a.ngay,'dd/mm/yyyy') as ngay,b.mavp from xxx.v_vienphill a,xxx.v_vienphict b," + user + ".v_giavp c," + user + ".v_loaivp d," + user + ".cls_loai e";
                            sql += " where a.id=b.id and b.mavp=c.id and c.id_loai=d.id and d.id=e.nhomvp and e.id=" + i_loai;
                            sql += " and a.mabn='" + mabn2.Text + mabn3.Text + "'";
                            sql += " and b.tra=0 and b.done=1 ";
                            sql += " and b.mavp in (" + s_dongthem + ")";
                            sql += " order by a.ngay,b.stt";
                            foreach (DataRow r in m.get_data_mmyy(sql, ngayvv.Text, ngayvv.Text, true).Tables[0].Rows)
                            {
                                m.execute_data("update " + user + m.mmyy(r["ngay"].ToString()) + ".v_vienphict set done=0 where tra=0 and done=1 and mavp=" + decimal.Parse(r["mavp"].ToString()) + " and id=" + decimal.Parse(r["id"].ToString()));
                                break;
                            }
                        }
                    }
                    xxx = user + m.mmyy(ngayvv.Text);
                    itable = m.tableid(m.mmyy(ngayvv.Text), "cls_ketqua");
                    m.upd_eve_tables(ngayvv.Text, itable, i_userid, "del");
                    m.upd_eve_upd_del(ngayvv.Text, itable, i_userid, "del",m.fields(xxx+".cls_ketqua","id="+l_id));
                    m.execute_data("delete from " + xxx + ".cls_hen where id=" + l_id);
                    m.execute_data("delete from " + xxx + ".cls_motact where id=" + l_id);
                    m.execute_data("delete from " + xxx + ".cls_mat where id=" + l_id);
                    m.execute_data("delete from " + xxx + ".cls_sdthuoc where id=" + l_id);
                    m.execute_data("delete from " + xxx + ".cls_ketqua where id=" + l_id);
                    if (file_ct2003 != "" && bSend_ct2003 && idcls.Text != "")
                        m.execute_data_acc("delete from bnhan where id='" + idcls.Text + "'", file_ct2003);
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
            string m_diachi = "";
            m_diachi = sonha.Text + " " + thon.Text;
            if (matt.Text != "100" || matt.Text != "000")
            {
                if (mapxa2.Text != "00") m_diachi += " " + tenpxa.Text;
                if (maqu2.Text != "00") m_diachi += "  " + tenquan.Text;
                if (matt.Text != "100" && matt.Text != "000") m_diachi += "  " + tentinh.Text;
            }
			dsxml.Clear();
			DataRow r;
			r=dsxml.Tables[0].NewRow();
			r["mabn"]=mabn2.Text+mabn3.Text;
			r["hoten"]=hoten.Text;
			r["tuoi"]=tuoi.Text;
			r["phai"]=phai.Text;
            r["diachi"] = m_diachi;
            r["dienthoai"] = cholam.Text;
			r["khoa"]=makp.Text;
			r["ngay"]=ngayvv.Text+" "+giovv.Text;
			r["chandoan"]=chandoan.Text;
            r["chidinh"] = cmbma.Text;
			r["bscd"]=bscd.Text;
            r["bvcd"] = bvcd.Text;
			r["bsth"]=tenbsth.Text;
            if (i_loai == 2) r["canquang"] = (canquang.Checked) ? "Không,sau đó tiêm thuốc tương phản" : "Không có thuốc tương phản";
            else r["canquang"] = (canquang.Checked) ? "Không,sau đó tiêm cản quang" : "Không tiêm cản quang";
			r["gayme"]=(gayme.Checked)?"Có gây mê":"";
			r["mp"]=(mp.Checked)?"Mắt phải":"";
			r["mt"]=(mt.Checked)?"Mắt trái":"";
			r["noidung"]=ten.Text;
            r["ghichu"] = may.Text;
            r["ketqua"] = idcls.Text;
            r["denghi"] = bvcd.Text;
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
            l_id = m.get_id_cls_ketqua(s_mabn, ngayvv.Text+" "+giovv.Text, i_loai, true);
            if (l_id == 0)
            {
                l_id = m.get_id_cls_ketqua(s_mabn, ngayvv.Text, i_loai, false);
                if (l_id != 0)
                    if (MessageBox.Show(lan.Change_language_MessageText("Đã nhập")+" " + loai.Text.Trim().ToUpper() + " trong ngày " + ngayvv.Text.Substring(0, 10) + " xem lại ?", LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) l_id = 0;
                    else load_cls();
                if (l_id == 0)
                {
                    if (ngayvv.Text != "") load_tiepdon(ngayvv.Text.Substring(0, 10), false);
                    if (chkidcls.Checked)
                    {
                        idcls.Text = ngayvv.Text.Substring(8, 2) + ngayvv.Text.Substring(3, 2) + ngayvv.Text.Substring(0, 2) + m.get_stt_cls_ketqua(ngayvv.Text.Substring(0, 10), i_loai);
                        if (file_ct2003 != "")
                        {
                            foreach (DataRow r in m.get_data_acc("select * from bnhan where trim(id)='" + idcls.Text.Trim() + "'", file_ct2003).Tables[0].Rows)
                            {
                                ten.Text = cvf.Vni_Uni(r["ketqua"].ToString());
                                chandoan.Text = cvf.Vni_Uni(r["lamsang"].ToString());
                                tenbsth.Text = cvf.Vni_Uni(r["bs_kham"].ToString());
                                DataRow r1 = m.getrowbyid(dtbs, "hoten='" + tenbsth.Text + "'");
                                if (r1 != null) bsth.Text = r1["ma"].ToString();
                                if (bscd.Text == "") bscd.Text = cvf.Vni_Uni(r["bs_cd"].ToString());
                                if (makp.Text == "") makp.Text = cvf.Vni_Uni(r["khoa_cd"].ToString());
                                if (bvcd.Text == "") bvcd.Text = cvf.Vni_Uni(r["bv_cd"].ToString());
                                canquang.Checked = r["canquang"].ToString().Trim().IndexOf("010") != -1;
                                tenytaphu.Text = cvf.Vni_Uni(r["ktv_kham1"].ToString());
                                r1 = m.getrowbyid(dtbs, "hoten='" + tenytaphu.Text + "'");
                                if (r1 != null) ytaphu.Text = r1["ma"].ToString();
                                break;
                            }
                        }
                    }
                    else
                    {
                        idcls.Text = ngayvv.Text.Substring(8, 2) + ngayvv.Text.Substring(3, 2) + ngayvv.Text.Substring(0, 2);
                        SendKeys.Send("{End}");
                    }
                    mmyy = m.mmyy(ngayvv.Text);
                    if (m.bMmyy(mmyy))
                    {
                        sql = "select a.id,b.soluong*b.dongia as sotien from xxx.v_vienphill a,xxx.v_vienphict b," + user + ".v_giavp c," + user + ".v_loaivp d," + user + ".cls_loai e";
                        sql += " where a.id=b.id and b.mavp=c.id and c.id_loai=d.id and d.id=e.nhomvp and e.id=" + i_loai;
                        sql += " and a.mabn='" + mabn2.Text + mabn3.Text + "'";
                        sql += " and b.tra=0 and b.done=0";
                        if (s_dongthem != "") sql += " and b.mavp not in (" + s_dongthem + ")";
                        sql += " order by a.ngay,b.stt";
                        decimal st = 0;
                        foreach (DataRow r in m.get_data_mmyy(sql, ngayvv.Text, ngayvv.Text, true).Tables[0].Rows)
                        {
                            idvp.Text = r["id"].ToString();
                            st = decimal.Parse(r["sotien"].ToString());
                            cp.Text = st.ToString("#,###,###,###");
                            lt.Text = cp.Text;
                            break;
                        }
                        if (s_dongthem != "")
                        {
                            sql = "select a.id,b.soluong*b.dongia as sotien from xxx.v_vienphill a,xxx.v_vienphict b," + user + ".v_giavp c," + user + ".v_loaivp d," + user + ".cls_loai e";
                            sql += " where a.id=b.id and b.mavp=c.id and c.id_loai=d.id and d.id=e.nhomvp and e.id=" + i_loai;
                            sql += " and a.mabn='" + mabn2.Text + mabn3.Text + "'";
                            sql += " and b.tra=0 and b.done=0";
                            sql += " and b.mavp in (" + s_dongthem + ")";
                            sql += " order by a.ngay,b.stt";
                            foreach (DataRow r in m.get_data_mmyy(sql, ngayvv.Text, ngayvv.Text, true).Tables[0].Rows)
                            {
                                st += decimal.Parse(r["sotien"].ToString());
                                cp.Text = st.ToString("#,###,###,###");
                                lt.Text = cp.Text;
                                break;
                            }
                        }
                    }
                }
            }
            else load_cls();
        }

        private void may_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (may.SelectedIndex == -1 && may.Items.Count > 0) may.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }

        private void phanloai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                //if (phanloai.SelectedIndex == -1 && phanloai.Items.Count > 0) phanloai.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }

        private void cp_Validated(object sender, EventArgs e)
        {
            decimal st=(cp.Text=="")?0:decimal.Parse(cp.Text);
            cp.Text=st.ToString("#,###,###,###");
            if (lt.Text == "" || lt.Text == "0") lt.Text = cp.Text;
        }

        private void lt_Validated(object sender, EventArgs e)
        {
            decimal st = (lt.Text == "") ? 0 : decimal.Parse(lt.Text);
            lt.Text = st.ToString("#,###,###,###");
        }

        private void ngaytra_Validated(object sender, EventArgs e)
        {
            if (ngaytra.Text == "") return;
            ngaytra.Text = ngaytra.Text.Trim();
            if (ngaytra.Text.Length == 6) ngaytra.Text = ngaytra.Text + DateTime.Now.Year.ToString();
            if (ngaytra.Text.Length < 10)
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày và giờ !"), s_msg);
                ngaytra.Focus();
                return;
            }
            if (!m.bNgay(ngaytra.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
                ngaytra.Focus();
                return;
            }
        }

        private void giotra_Validated(object sender, EventArgs e)
        {
            string sgio = (giotra.Text.Trim() == "") ? "00:00" : giotra.Text.Trim();
            giotra.Text = sgio.Substring(0, 2).Trim().PadLeft(2, '0') + ":" + sgio.Substring(3).Trim().PadRight(2, '0');
            if (!m.bGio(giotra.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"));
                giotra.Focus();
                return;
            }
            if (!m.bNgaygio(ngaytra.Text + " " + giotra.Text, ngayvv.Text + " " + giovv.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày hẹn không được nhỏ hơn ngày !"), s_msg);
                ngaytra.Focus();
                return;
            }
        }

        private void bscd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listbscd.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                sql = "ten like '%" + bscd.Text.Trim() + "%'";
                DataRow[] dr = dtbscd.Select(sql);
                if (dr.Length == 1)
                {
                    bscd.Text = dr[0]["ten"].ToString();
                    bvcd.Text = dr[0]["benhvien"].ToString();
                    makp.Text = dr[0]["khoa"].ToString();
                    SendKeys.Send("{Tab}");
                }
                else if (listbscd.Visible) listbscd.Focus();
                else SendKeys.Send("{Tab}");
            }				
        }

        private void bscd_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == bscd && bDanhsach_chidinh)
            {
                Filt_bacsy(bscd.Text);
                listbscd.BrowseToDmnx(bscd, bscd, makp);
            }
        }

        private void Filt_bacsy(string ten)
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[listbscd.DataSource];
            DataView dv = (DataView)cm.List;
            dv.RowFilter = "ten LIKE '%" + ten.Trim() + "%'";
        }

        private void bscd_Validated(object sender, EventArgs e)
        {
            if (!listbscd.Focused) listbscd.Hide();
        }

        private void bvcd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listbv.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                sql = "ten like '%" + bvcd.Text.Trim() + "%'";
                DataRow[] dr = dtbv.Select(sql);
                if (dr.Length == 1)
                {
                    bvcd.Text = dr[0]["ten"].ToString();
                    SendKeys.Send("{Tab}");
                }
                else if (listbv.Visible) listbv.Focus();
                else SendKeys.Send("{Tab}");
            }				
        }

        private void bvcd_Validated(object sender, EventArgs e)
        {
            if (!listbv.Focused) listbv.Hide();
        }

        private void bvcd_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == bvcd && bDanhsach_chidinh)
            {
                Filt_ten(bvcd.Text, listbv);
                listbv.BrowseToThon(bvcd, bvcd,madoituong);
            }
        }

        private void Filt_ten(string ten, LibList.List list)
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[list.DataSource];
            DataView dv = (DataView)cm.List;
            dv.RowFilter = "ten LIKE '%" + ten.Trim() + "%'";
        }

        private void listbscd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || bvcd.Text == "")
            {
                DataRow r = m.getrowbyid(dtbscd, "ten='" + bscd.Text + "'");
                if (r != null)
                {
                    bvcd.Text = r["benhvien"].ToString();
                    makp.Text = r["khoa"].ToString();
                }
            }
        }

        private void butInnhan_Click(object sender, EventArgs e)
        {
            #region 17102006
            /*
            if (hoten.Text == "") return;
            dsnhan.Clear();
            DataRow r;
            r = dsnhan.Tables[0].NewRow();
            r["mabn"] = mabn2.Text + mabn3.Text;
            r["hoten"] = hoten.Text;
            r["tuoi"] = tuoi.Text+" "+loaituoi.Text;
            r["phai"] = phai.Text;
            r["diachi"] = sonha.Text.Trim() + " " + thon.Text.Trim() + " " + tenpxa.Text.Trim() + " " + tenquan.Text.Trim() + " " + tentinh.Text;
            r["khoa"] = makp.Text;
            r["ngay"] = ngayvv.Text + " " + giovv.Text;
            r["idcls"] = idcls.Text;
            r["bscd"] = bscd.Text;
            r["bvcd"] = bvcd.Text;
            r["loai"] = loai.Text;
            r["vung"] = cmbma.Text;
            dsnhan.Tables[0].Rows.Add(r);
            if (chkXem.Checked)
            {
                dllReportM.frmReport f = new dllReportM.frmReport(m, dsnhan, "", "rptNhan.rpt", true);
                f.ShowDialog();
            }
            else print.Printer(m, dsnhan, "rptNhan.rpt", "", 1);
             */
            #endregion
            string ngay = m.ngayhienhanh_server.Substring(0, 10);
            if (!m.bMmyy(m.mmyy(ngay))) return;
            xxx = user + m.mmyy(ngay);
            sql = "select a.mabn,b.hoten,to_number(to_char(now(),'yyyy'))-to_number(b.namsinh) as tuoi,";
            sql += " case when b.phai=0 then 'M' else 'F' end as phai,";
            sql += " trim(b.sonha)||' '||trim(b.thon)||' '||trim(e.tenpxa)||' '||trim(d.tenquan)||' '||c.tentt as diachi,";
            sql += " a.makpcd as makp,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,";
            sql += " a.idcls,a.bscd,a.bvcd,f.ten as loai,g.ten as vung ";
            sql += " from " + xxx + ".cls_ketqua a," + user + ".btdbn b," + user + ".btdtt c," + user + ".btdquan d," + user + ".btdpxa e ";
            sql += "," + user + ".cls_loai f," + user + ".cls_noidung g ";
            sql += " where a.mabn=b.mabn and b.matt=c.matt and b.maqu=d.maqu and b.maphuongxa=e.maphuongxa ";
            sql += " and a.loai=f.id and a.idvung=g.id and to_char(a.ngay,'dd/mm/yyyy')='" + ngay + "'";
            //sql += " and a.userid=" + i_userid;
            sql += " order by a.idcls";
            frmChonin f = new frmChonin(m, m.get_data(sql).Tables[0], dsnhan,ngay,i_userid);
            f.ShowDialog();
            butTiep.Focus();
        }

        private void cp_KeyPress(object sender, KeyPressEventArgs e)
        {
            m.MaskDigit_dautru(e);            
        }

        private void idvungdg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                //if (idvungdg.SelectedIndex == -1 && idvungdg.Items.Count > 0) idvungdg.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }

        private void makp_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == makp && bDanhsach_chidinh)
            {
                Filt_ten(makp.Text, listkhoa);
                listkhoa.BrowseToThon(makp, makp, bvcd);
            }
        }


        private void butPrev_Click(object sender, EventArgs e)
        {
            if (!m.bMmyy(m.mmyy(ngayvv.Text)))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy !"), LibMedi.AccessData.Msg);
                return;
            }
            sql = "select id,mabn,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay,loai,idcls from " + xxx + ".cls_ketqua ";
            sql += " where to_char(ngay,'dd/mm/yyyy')='" + ngayvv.Text.Substring(0, 10) + "'";
            if (s_cls != "") sql += " and loai in (" + s_cls.Substring(0, s_cls.Length - 1) + ")";
            if (s_may != "") sql += " and idmay in (" + s_may.Substring(0, s_may.Length - 1) + ")";
            if (idcls.Text.Length == 9 && loai.Items.Count == 1)
            {
                sql += " and idcls<'" + idcls.Text + "'";
                sql += " order by idcls desc";
            }
            else
            {
                sql += " and id<" + l_id;
                sql += " order by id desc";
            }
            bool bFound = false;
            foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
            {
                mabn2.Text = r["mabn"].ToString().Substring(0, 2);
                mabn3.Text = r["mabn"].ToString().Substring(2);
                s_mabn = mabn2.Text + mabn3.Text;
                load_mabn();
                loai.SelectedValue = r["loai"].ToString();
                i_loai = int.Parse(loai.SelectedValue.ToString());
                load_loai();
                ngayvv.Text = r["ngay"].ToString().Substring(0, 10);
                giovv.Text = r["ngay"].ToString().Substring(11);
                l_id = decimal.Parse(r["id"].ToString());
                load_cls();
                bFound = true;
                break;
            }
            if (!bFound)
            {
                bFound = false;
                string _ngay = ngayvv.Text;
                ngayvv.Text = m.DateToString("dd/MM/yyyy", m.StringToDate(ngayvv.Text).AddDays(-1));
                xxx = user + m.mmyy(ngayvv.Text);
                if (m.bMmyy(m.mmyy(ngayvv.Text)))
                {
                    sql = "select id,mabn,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay,loai,idcls from " + xxx + ".cls_ketqua ";
                    sql += " where to_char(ngay,'dd/mm/yyyy')='" + ngayvv.Text.Substring(0, 10) + "'";
                    if (s_cls != "") sql += " and loai in (" + s_cls.Substring(0, s_cls.Length - 1) + ")";
                    if (s_may != "") sql += " and idmay in (" + s_may.Substring(0, s_may.Length - 1) + ")";
                    if (loai.Items.Count == 1) sql += " order by idcls desc";
                    else sql += " order by id desc";
                    foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
                    {
                        mabn2.Text = r["mabn"].ToString().Substring(0, 2);
                        mabn3.Text = r["mabn"].ToString().Substring(2);
                        s_mabn = mabn2.Text + mabn3.Text;
                        load_mabn();
                        loai.SelectedValue = r["loai"].ToString();
                        i_loai = int.Parse(loai.SelectedValue.ToString());
                        load_loai();
                        ngayvv.Text = r["ngay"].ToString().Substring(0, 10);
                        giovv.Text = r["ngay"].ToString().Substring(11);
                        l_id = decimal.Parse(r["id"].ToString());
                        load_cls();
                        bFound = true;
                        break;
                    }
                }
                if (!bFound)
                {
                    ngayvv.Text = _ngay;
                    MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy !"), LibMedi.AccessData.Msg);
                    return;
                }
            }
        }

        private void butNext_Click(object sender, EventArgs e)
        {
            if (!m.bMmyy(m.mmyy(ngayvv.Text)))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy !"), LibMedi.AccessData.Msg);
                return;
            }
            sql = "select id,mabn,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay,loai,idcls from " + xxx + ".cls_ketqua ";
            sql += " where to_char(ngay,'dd/mm/yyyy')='" + ngayvv.Text.Substring(0, 10) + "'";
            if (s_cls != "") sql += " and loai in (" + s_cls.Substring(0, s_cls.Length - 1) + ")";
            if (s_may != "") sql += " and idmay in (" + s_may.Substring(0, s_may.Length - 1) + ")";
            if (idcls.Text.Length == 9 && loai.Items.Count == 1)
            {
                sql += " and idcls>'" + idcls.Text + "'";
                sql += " order by idcls";
            }
            else
            {
                sql += " and id>" + l_id;
                sql += " order by id";
            }
            bool bFound = false;
            foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
            {
                mabn2.Text = r["mabn"].ToString().Substring(0, 2);
                mabn3.Text = r["mabn"].ToString().Substring(2);
                s_mabn = mabn2.Text + mabn3.Text;
                load_mabn();
                loai.SelectedValue = r["loai"].ToString();
                i_loai = int.Parse(loai.SelectedValue.ToString());
                load_loai();
                ngayvv.Text = r["ngay"].ToString().Substring(0, 10);
                giovv.Text = r["ngay"].ToString().Substring(11);
                l_id = decimal.Parse(r["id"].ToString());
                load_cls();
                bFound = true;
                break;
            }
            if (!bFound)
            {
                string _ngay = ngayvv.Text;
                ngayvv.Text = m.DateToString("dd/MM/yyyy", m.StringToDate(ngayvv.Text).AddDays(1));
                xxx = user + m.mmyy(ngayvv.Text);
                bFound = false;
                if (m.bMmyy(m.mmyy(ngayvv.Text)))
                {
                    sql = "select id,mabn,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay,loai,idcls from " + xxx + ".cls_ketqua ";
                    sql += " where to_char(ngay,'dd/mm/yyyy')='" + ngayvv.Text.Substring(0, 10) + "'";
                    if (s_cls != "") sql += " and loai in (" + s_cls.Substring(0, s_cls.Length - 1) + ")";
                    if (s_may != "") sql += " and idmay in (" + s_may.Substring(0, s_may.Length - 1) + ")";
                    if (loai.Items.Count == 1) sql += " order by idcls";
                    else sql += " order by id";
                    foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
                    {
                        mabn2.Text = r["mabn"].ToString().Substring(0, 2);
                        mabn3.Text = r["mabn"].ToString().Substring(2);
                        s_mabn = mabn2.Text + mabn3.Text;
                        load_mabn();
                        loai.SelectedValue = r["loai"].ToString();
                        i_loai = int.Parse(loai.SelectedValue.ToString());
                        load_loai();
                        ngayvv.Text = r["ngay"].ToString().Substring(0, 10);
                        giovv.Text = r["ngay"].ToString().Substring(11);
                        l_id = decimal.Parse(r["id"].ToString());
                        load_cls();
                        bFound = true;
                        break;
                    }
                }
                if (!bFound)
                {
                    ngayvv.Text = _ngay;
                    MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy !"), LibMedi.AccessData.Msg);
                    return;
                }
            }
        }

        private void chkidcls_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkidcls)
            {
                idcls.Enabled = !chkidcls.Checked;
                if (idcls.Enabled)
                {
                    mmyy = m.mmyy(ngayvv.Text);
                    if (m.bMmyy(mmyy))
                    {
                        sql = "select a.id,b.soluong*b.dongia as sotien from xxx.v_vienphill a,xxx.v_vienphict b," + user + ".v_giavp c," + user + ".v_loaivp d," + user + ".cls_loai e";
                        sql += " where a.id=b.id and b.mavp=c.id and c.id_loai=d.id and d.id=e.nhomvp and e.id=" + i_loai;
                        sql += " and a.mabn='" + mabn2.Text + mabn3.Text + "'";
                        sql += " and b.tra=0 and b.done=0";
                        if (s_dongthem != "") sql += " and b.mavp not in (" + s_dongthem + ")";
                        sql += " order by a.ngay,b.stt";
                        decimal st = 0;
                        foreach (DataRow r in m.get_data_mmyy(sql,ngayvv.Text,ngayvv.Text,true).Tables[0].Rows)
                        {
                            idvp.Text = r["id"].ToString();
                            st = decimal.Parse(r["sotien"].ToString());
                            cp.Text = st.ToString("#,###,###,###");
                            lt.Text = cp.Text;
                            break;
                        }
                        if (s_dongthem != "")
                        {
                            sql = "select a.id,b.soluong*b.dongia as sotien from xxx.v_vienphill a,xxx.v_vienphict b," + user + ".v_giavp c," + user + ".v_loaivp d," + user + ".cls_loai e";
                            sql += " where a.id=b.id and b.mavp=c.id and c.id_loai=d.id and d.id=e.nhomvp and e.id=" + i_loai;
                            sql += " and a.mabn='" + mabn2.Text + mabn3.Text + "'";
                            sql += " and b.tra=0 ";//and b.done=0";
                            sql += " and b.mavp in (" + s_dongthem + ")";
                            sql += " order by a.ngay,b.stt";
                            foreach (DataRow r in m.get_data_mmyy(sql, ngayvv.Text, ngayvv.Text, true).Tables[0].Rows)
                            {
                                st += decimal.Parse(r["sotien"].ToString());
                                cp.Text = st.ToString("#,###,###,###");
                                lt.Text = cp.Text;
                                break;
                            }
                        }
                    }
                    idcls.Text = ngayvv.Text.Substring(8, 2) + ngayvv.Text.Substring(3, 2) + ngayvv.Text.Substring(0, 2);
                    idcls.Focus();
                    SendKeys.Send("{End}");
                }
            }
        }

        private void butFind_Click(object sender, EventArgs e)
        {
            frmTimcls f = new frmTimcls(m, s_cls);
            f.ShowDialog();
            if (f.mabn != "")
            {
                mabn2.Text = f.mabn.Substring(0, 2);
                mabn3.Text = f.mabn.Substring(2);
                s_mabn = mabn2.Text + mabn3.Text;
                load_mabn();
                i_loai = f.i_loai;
                loai.SelectedValue = i_loai.ToString();
                load_loai();
                ngayvv.Text = f.ngay.Substring(0, 10);
                giovv.Text = f.ngay.Substring(11);
                l_id = m.get_id_cls_ketqua(s_mabn, ngayvv.Text + " " + giovv.Text, int.Parse(loai.SelectedValue.ToString()), true);
                if (l_id != 0) load_cls();
            }
        }

        private void idcls_KeyPress(object sender, KeyPressEventArgs e)
        {
            m.MaskDigit(e);
        }

        private void bh_KeyPress(object sender, KeyPressEventArgs e)
        {
            m.MaskDigit(e);
        }

        private void bh_Validated(object sender, EventArgs e)
        {
            decimal st = (bh.Text == "") ? 0 : decimal.Parse(bh.Text);
            bh.Text = st.ToString("#,###,###,###");
        }

        private void idcls_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void idcls_Validated(object sender, EventArgs e)
        {
            if (file_ct2003 != "" && idcls.Text.Trim().Length == 9)
            {
                foreach (DataRow r in m.get_data_acc("select * from bnhan where trim(id)='" + idcls.Text.Trim() + "'", file_ct2003).Tables[0].Rows)
                {
                    ten.Text = cvf.Vni_Uni(r["ketqua"].ToString());
                    chandoan.Text = cvf.Vni_Uni(r["lamsang"].ToString());
                    tenbsth.Text = cvf.Vni_Uni(r["bs_kham"].ToString());
                    DataRow r1 = m.getrowbyid(dtbs, "hoten='" + tenbsth.Text + "'");
                    if (r1 != null) bsth.Text = r1["ma"].ToString();
                    if (bscd.Text == "") bscd.Text = cvf.Vni_Uni(r["bs_cd"].ToString());
                    if (makp.Text == "") makp.Text = cvf.Vni_Uni(r["khoa_cd"].ToString());
                    if (bvcd.Text == "") bvcd.Text = cvf.Vni_Uni(r["bv_cd"].ToString());
                    canquang.Checked = r["canquang"].ToString().Trim().IndexOf("010") != -1;
                    tenytaphu.Text = cvf.Vni_Uni(r["ktv_kham1"].ToString());
                    r1 = m.getrowbyid(dtbs, "hoten='" + tenytaphu.Text + "'");
                    if (r1 != null) ytaphu.Text = r1["ma"].ToString();
                    break;
                }
            }
        }

        private void maloai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listLoai.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listLoai.Visible)
                {
                    listLoai.Focus();
                    SendKeys.Send("{Up}");
                }
                else SendKeys.Send("{Tab}");
            }
        }

        private void maloai_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == maloai)
            {
                Filt_loai(maloai.Text);
                listLoai.BrowseToPTTT(maloai, maloai, phanloai, maloai.Location.X, maloai.Location.Y + maloai.Height, maloai.Width + phanloai.Width + 4, maloai.Height);
            }
        }

        private void Filt_loai(string ten)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[listLoai.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "ten LIKE '%" + ten.Trim() + "%' or ma like '%" + ten.Trim() + "%'";
            }
            catch { }
        }

        private void phanloai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == phanloai && phanloai.SelectedIndex!=-1) maloai.Text=phanloai.SelectedValue.ToString();
        }

        private void listLoai_Validated(object sender, EventArgs e)
        {
            if (maloai.Text != "")
            {
               phanloai.DataSource = m.get_data("select ma,ten,id from " + user + ".cls_phanloai where loai=" + i_loai + " and ma like '%" + maloai.Text.Trim() + "%' order by ma").Tables[0];
               //phanloai.SelectedValue = ma.Text;
               if (phanloai.Items.Count>0) phanloai.SelectedIndex = 0;
            }
        }
	}
}
