using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibVienphi;
namespace Medisoft
{
	/// <summary>
	/// Summary description for frmXuatvien.
	/// </summary>
	public class frmKhambenh2 : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private LibMedi.AccessData m;
		private LibVienphi.AccessData v;
		private DataSet ds=new DataSet();
		private string user,nam,s_userid,s_makp,s_mabn,s_msg,s_ngayvv,sql,s_madoituong;
		private int i_userid;
		private decimal l_maql=0,l_matd=0;
		private DataTable dt=new DataTable();
		private DataTable dtbs=new DataTable();
		private DataTable dtxutri=new DataTable();
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
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label42;
		private MaskedTextBox.MaskedTextBox icd_chinh;
		private System.Windows.Forms.TextBox mabs;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.Button butTiep;
		private System.Windows.Forms.Button butLuu;
        private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butKetthuc;
		private int songay=30;
		private bool b_Edit=false,b_Hoten=false,bAdmin,bBacsy;
		private System.ComponentModel.IContainer components;
		private bool bChandoan,b701424,bTiepdon;
		private System.Windows.Forms.ComboBox tennuoc;
		private System.Windows.Forms.ComboBox tendantoc;
		private System.Windows.Forms.ComboBox tentqx;
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
		private string s_icd_chinh,s_chonxutri="";
		private System.Windows.Forms.TextBox cd_chinh;
		private LibList.List listICD;
		private LibList.List listBS;
		private System.Windows.Forms.TextBox tenbs;
		private System.Windows.Forms.CheckedListBox xutri;
		private MaskedTextBox.MaskedTextBox maxutri;
		private System.Windows.Forms.Label label55;
		private System.Windows.Forms.Panel pmat;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label33;
		private MaskedTextBox.MaskedTextBox mp;
		private MaskedTextBox.MaskedTextBox mt;
		private MaskedTextBox.MaskedTextBox nhanapp;
		private MaskedTextBox.MaskedTextBox nhanapt;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label53;
        private Label label2;
        private MaskedBox.MaskedBox giovv;
        private Button button1;
		private DataTable dticd=new DataTable();

		public frmKhambenh2(LibMedi.AccessData acc,string makp,string hoten,int userid,string _madoituong)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
			v=new LibVienphi.AccessData();
			s_makp=makp;s_madoituong=_madoituong;
			s_userid=hoten;
			i_userid=userid;
            loaituoi.Items.Clear();
            loaituoi.Items.AddRange(new string[]{lan.Change_language_MessageText("Năm tuổi"),
                                                 lan.Change_language_MessageText("Tháng tuổi"),
                                                 lan.Change_language_MessageText("Ngày tuổi"),
                                                 lan.Change_language_MessageText("Giờ tuổi")});

            phai.Items.Clear();
            phai.Items.AddRange(new string[]{lan.Change_language_MessageText("Nam"),
                                                 lan.Change_language_MessageText("Nữ")});
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhambenh2));
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
            this.label40 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.icd_chinh = new MaskedTextBox.MaskedTextBox();
            this.mabs = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.butTiep = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.tennuoc = new System.Windows.Forms.ComboBox();
            this.manuoc = new System.Windows.Forms.TextBox();
            this.lmanuoc = new System.Windows.Forms.Label();
            this.sonha = new MaskedTextBox.MaskedTextBox();
            this.tendantoc = new System.Windows.Forms.ComboBox();
            this.tentqx = new System.Windows.Forms.ComboBox();
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
            this.lthon = new System.Windows.Forms.Label();
            this.lsonha = new System.Windows.Forms.Label();
            this.lmadantoc = new System.Windows.Forms.Label();
            this.lmann = new System.Windows.Forms.Label();
            this.phai = new System.Windows.Forms.ComboBox();
            this.lphai = new System.Windows.Forms.Label();
            this.ngayvv = new MaskedBox.MaskedBox();
            this.tenkp = new System.Windows.Forms.ComboBox();
            this.madoituong = new System.Windows.Forms.TextBox();
            this.tendoituong = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.ngaysinh = new MaskedBox.MaskedBox();
            this.cd_chinh = new System.Windows.Forms.TextBox();
            this.listICD = new LibList.List();
            this.listBS = new LibList.List();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.xutri = new System.Windows.Forms.CheckedListBox();
            this.maxutri = new MaskedTextBox.MaskedTextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.pmat = new System.Windows.Forms.Panel();
            this.nhanapt = new MaskedTextBox.MaskedTextBox();
            this.nhanapp = new MaskedTextBox.MaskedTextBox();
            this.mt = new MaskedTextBox.MaskedTextBox();
            this.mp = new MaskedTextBox.MaskedTextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.giovv = new MaskedBox.MaskedBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pmat.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(16, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "&Mã BN :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(163, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Họ và tên :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(424, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "Sinh ngày :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn2
            // 
            this.mabn2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn2.Location = new System.Drawing.Point(64, 34);
            this.mabn2.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mabn2.MaxLength = 2;
            this.mabn2.Name = "mabn2";
            this.mabn2.Size = new System.Drawing.Size(32, 23);
            this.mabn2.TabIndex = 1;
            this.mabn2.Validated += new System.EventHandler(this.mabn2_Validated);
            // 
            // mabn3
            // 
            this.mabn3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabn3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn3.Location = new System.Drawing.Point(99, 34);
            this.mabn3.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mabn3.MaxLength = 6;
            this.mabn3.Name = "mabn3";
            this.mabn3.Size = new System.Drawing.Size(70, 23);
            this.mabn3.TabIndex = 2;
            this.mabn3.Validated += new System.EventHandler(this.mabn3_Validated);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(570, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 14;
            this.label6.Text = "Năm sinh :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // namsinh
            // 
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(630, 34);
            this.namsinh.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.namsinh.MaxLength = 4;
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(40, 23);
            this.namsinh.TabIndex = 5;
            this.namsinh.Validated += new System.EventHandler(this.namsinh_Validated);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(647, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 23);
            this.label7.TabIndex = 16;
            this.label7.Text = "Tuổi :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loaituoi
            // 
            this.loaituoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaituoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loaituoi.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaituoi.Items.AddRange(new object[] {
            "Tuổi",
            "Tháng",
            "Ngày",
            "Giờ"});
            this.loaituoi.Location = new System.Drawing.Point(729, 34);
            this.loaituoi.Name = "loaituoi";
            this.loaituoi.Size = new System.Drawing.Size(57, 24);
            this.loaituoi.TabIndex = 7;
            this.loaituoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loaituoi_KeyDown);
            // 
            // tuoi
            // 
            this.tuoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tuoi.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuoi.Location = new System.Drawing.Point(699, 34);
            this.tuoi.MaxLength = 3;
            this.tuoi.Name = "tuoi";
            this.tuoi.Size = new System.Drawing.Size(28, 23);
            this.tuoi.TabIndex = 6;
            this.tuoi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tuoi_KeyPress);
            this.tuoi.Validated += new System.EventHandler(this.tuoi_Validated);
            this.tuoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tuoi_KeyDown);
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(225, 34);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(206, 23);
            this.hoten.TabIndex = 3;
            this.hoten.Validated += new System.EventHandler(this.hoten_Validated);
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
            // 
            // label40
            // 
            this.label40.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label40.Location = new System.Drawing.Point(344, 242);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(72, 23);
            this.label40.TabIndex = 96;
            this.label40.Text = "Xử trí :";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label42
            // 
            this.label42.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label42.Location = new System.Drawing.Point(-16, 192);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(120, 23);
            this.label42.TabIndex = 20;
            this.label42.Text = "Chẩn đoán :";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // icd_chinh
            // 
            this.icd_chinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_chinh.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_chinh.Location = new System.Drawing.Point(104, 194);
            this.icd_chinh.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_chinh.MaxLength = 9;
            this.icd_chinh.Name = "icd_chinh";
            this.icd_chinh.Size = new System.Drawing.Size(59, 23);
            this.icd_chinh.TabIndex = 33;
            this.icd_chinh.Validated += new System.EventHandler(this.icd_chinh_Validated);
            this.icd_chinh.TextChanged += new System.EventHandler(this.icd_chinh_TextChanged);
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(104, 243);
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(61, 23);
            this.mabs.TabIndex = 36;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // label49
            // 
            this.label49.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label49.Location = new System.Drawing.Point(0, 242);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(104, 23);
            this.label49.TabIndex = 117;
            this.label49.Text = "Bác sĩ khám :";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label52
            // 
            this.label52.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label52.Location = new System.Drawing.Point(8, 4);
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
            this.butTiep.Location = new System.Drawing.Point(268, 420);
            this.butTiep.Name = "butTiep";
            this.butTiep.Size = new System.Drawing.Size(70, 25);
            this.butTiep.TabIndex = 42;
            this.butTiep.Text = "     &Tiếp";
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
            this.butLuu.Location = new System.Drawing.Point(338, 420);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 40;
            this.butLuu.Text = "     &Lưu";
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
            this.butBoqua.Location = new System.Drawing.Point(408, 420);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 41;
            this.butBoqua.Text = "Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.UseVisualStyleBackColor = false;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.BackColor = System.Drawing.Color.Transparent;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(478, 420);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 44;
            this.butKetthuc.Text = "Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.UseVisualStyleBackColor = false;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // tennuoc
            // 
            this.tennuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennuoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tennuoc.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennuoc.Location = new System.Drawing.Point(668, 59);
            this.tennuoc.Name = "tennuoc";
            this.tennuoc.Size = new System.Drawing.Size(118, 24);
            this.tennuoc.TabIndex = 14;
            this.tennuoc.SelectedIndexChanged += new System.EventHandler(this.tennuoc_SelectedIndexChanged);
            this.tennuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennuoc_KeyDown);
            // 
            // manuoc
            // 
            this.manuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manuoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.manuoc.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manuoc.Location = new System.Drawing.Point(630, 59);
            this.manuoc.Name = "manuoc";
            this.manuoc.Size = new System.Drawing.Size(36, 23);
            this.manuoc.TabIndex = 13;
            this.manuoc.Validated += new System.EventHandler(this.manuoc_Validated);
            this.manuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manuoc_KeyDown);
            // 
            // lmanuoc
            // 
            this.lmanuoc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lmanuoc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmanuoc.Location = new System.Drawing.Point(567, 60);
            this.lmanuoc.Name = "lmanuoc";
            this.lmanuoc.Size = new System.Drawing.Size(67, 23);
            this.lmanuoc.TabIndex = 65;
            this.lmanuoc.Text = "Quốc tịch :";
            this.lmanuoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sonha
            // 
            this.sonha.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sonha.Location = new System.Drawing.Point(64, 85);
            this.sonha.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sonha.MaxLength = 10;
            this.sonha.Name = "sonha";
            this.sonha.Size = new System.Drawing.Size(74, 23);
            this.sonha.TabIndex = 15;
            // 
            // tendantoc
            // 
            this.tendantoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendantoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tendantoc.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendantoc.Location = new System.Drawing.Point(460, 59);
            this.tendantoc.Name = "tendantoc";
            this.tendantoc.Size = new System.Drawing.Size(106, 24);
            this.tendantoc.TabIndex = 12;
            this.tendantoc.SelectedIndexChanged += new System.EventHandler(this.tendantoc_SelectedIndexChanged);
            this.tendantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendantoc_KeyDown);
            // 
            // tentqx
            // 
            this.tentqx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tentqx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tentqx.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tentqx.Location = new System.Drawing.Point(563, 84);
            this.tentqx.Name = "tentqx";
            this.tentqx.Size = new System.Drawing.Size(223, 24);
            this.tentqx.TabIndex = 18;
            this.tentqx.SelectedIndexChanged += new System.EventHandler(this.tentqx_SelectedIndexChanged);
            this.tentqx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentqx_KeyDown);
            // 
            // thon
            // 
            this.thon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thon.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thon.Location = new System.Drawing.Point(203, 85);
            this.thon.Name = "thon";
            this.thon.Size = new System.Drawing.Size(229, 23);
            this.thon.TabIndex = 16;
            this.thon.Validated += new System.EventHandler(this.thon_Validated);
            this.thon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thon_KeyDown);
            // 
            // mapxa2
            // 
            this.mapxa2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapxa2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapxa2.Location = new System.Drawing.Point(615, 112);
            this.mapxa2.Name = "mapxa2";
            this.mapxa2.Size = new System.Drawing.Size(23, 23);
            this.mapxa2.TabIndex = 25;
            this.mapxa2.Validated += new System.EventHandler(this.mapxa2_Validated);
            this.mapxa2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mapxa2_KeyDown);
            // 
            // maqu2
            // 
            this.maqu2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maqu2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maqu2.Location = new System.Drawing.Point(336, 112);
            this.maqu2.Name = "maqu2";
            this.maqu2.Size = new System.Drawing.Size(23, 23);
            this.maqu2.TabIndex = 22;
            this.maqu2.Validated += new System.EventHandler(this.maqu2_Validated);
            this.maqu2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maqu2_KeyDown);
            // 
            // matt
            // 
            this.matt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.matt.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matt.Location = new System.Drawing.Point(64, 112);
            this.matt.MaxLength = 3;
            this.matt.Name = "matt";
            this.matt.Size = new System.Drawing.Size(32, 23);
            this.matt.TabIndex = 19;
            this.matt.Validated += new System.EventHandler(this.matt_Validated);
            this.matt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matt_KeyDown);
            // 
            // tqx
            // 
            this.tqx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tqx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tqx.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tqx.Location = new System.Drawing.Point(488, 85);
            this.tqx.Name = "tqx";
            this.tqx.Size = new System.Drawing.Size(72, 23);
            this.tqx.TabIndex = 17;
            this.tqx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tqx_KeyDown);
            // 
            // madantoc
            // 
            this.madantoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madantoc.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madantoc.Location = new System.Drawing.Point(431, 59);
            this.madantoc.Name = "madantoc";
            this.madantoc.Size = new System.Drawing.Size(28, 23);
            this.madantoc.TabIndex = 11;
            this.madantoc.Validated += new System.EventHandler(this.madantoc_Validated);
            this.madantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madantoc_KeyDown);
            // 
            // mann
            // 
            this.mann.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mann.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mann.Location = new System.Drawing.Point(203, 59);
            this.mann.Name = "mann";
            this.mann.Size = new System.Drawing.Size(34, 23);
            this.mann.TabIndex = 9;
            this.mann.Validated += new System.EventHandler(this.mann_Validated);
            this.mann.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mann_KeyDown);
            // 
            // tennn
            // 
            this.tennn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tennn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennn.Location = new System.Drawing.Point(239, 59);
            this.tennn.Name = "tennn";
            this.tennn.Size = new System.Drawing.Size(144, 24);
            this.tennn.TabIndex = 10;
            this.tennn.SelectedIndexChanged += new System.EventHandler(this.tennn_SelectedIndexChanged);
            this.tennn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennn_KeyDown);
            // 
            // tenquan
            // 
            this.tenquan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenquan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenquan.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenquan.Location = new System.Drawing.Point(360, 111);
            this.tenquan.Name = "tenquan";
            this.tenquan.Size = new System.Drawing.Size(138, 24);
            this.tenquan.TabIndex = 23;
            this.tenquan.SelectedIndexChanged += new System.EventHandler(this.tenquan_SelectedIndexChanged);
            this.tenquan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenquan_KeyDown);
            // 
            // tentinh
            // 
            this.tentinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tentinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tentinh.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tentinh.Location = new System.Drawing.Point(99, 111);
            this.tentinh.Name = "tentinh";
            this.tentinh.Size = new System.Drawing.Size(141, 24);
            this.tentinh.TabIndex = 20;
            this.tentinh.SelectedIndexChanged += new System.EventHandler(this.tentinh_SelectedIndexChanged);
            this.tentinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentinh_KeyDown);
            // 
            // tenpxa
            // 
            this.tenpxa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenpxa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenpxa.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenpxa.Location = new System.Drawing.Point(640, 111);
            this.tenpxa.Name = "tenpxa";
            this.tenpxa.Size = new System.Drawing.Size(146, 24);
            this.tenpxa.TabIndex = 26;
            this.tenpxa.SelectedIndexChanged += new System.EventHandler(this.tenpxa_SelectedIndexChanged);
            this.tenpxa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenpxa_KeyDown);
            // 
            // mapxa1
            // 
            this.mapxa1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapxa1.Enabled = false;
            this.mapxa1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapxa1.Location = new System.Drawing.Point(573, 112);
            this.mapxa1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mapxa1.MaxLength = 5;
            this.mapxa1.Name = "mapxa1";
            this.mapxa1.Size = new System.Drawing.Size(40, 23);
            this.mapxa1.TabIndex = 24;
            // 
            // lmaphuongxa
            // 
            this.lmaphuongxa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lmaphuongxa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmaphuongxa.Location = new System.Drawing.Point(496, 112);
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
            this.maqu1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maqu1.Location = new System.Drawing.Point(295, 112);
            this.maqu1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.maqu1.MaxLength = 3;
            this.maqu1.Name = "maqu1";
            this.maqu1.Size = new System.Drawing.Size(40, 23);
            this.maqu1.TabIndex = 21;
            // 
            // lmaqu
            // 
            this.lmaqu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lmaqu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmaqu.Location = new System.Drawing.Point(215, 112);
            this.lmaqu.Name = "lmaqu";
            this.lmaqu.Size = new System.Drawing.Size(80, 23);
            this.lmaqu.TabIndex = 76;
            this.lmaqu.Text = "Quận/H :";
            this.lmaqu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmatt
            // 
            this.lmatt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lmatt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmatt.Location = new System.Drawing.Point(8, 112);
            this.lmatt.Name = "lmatt";
            this.lmatt.Size = new System.Drawing.Size(56, 23);
            this.lmatt.TabIndex = 75;
            this.lmatt.Text = "Tỉnh/TP :";
            this.lmatt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ltqx
            // 
            this.ltqx.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ltqx.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ltqx.Location = new System.Drawing.Point(416, 88);
            this.ltqx.Name = "ltqx";
            this.ltqx.Size = new System.Drawing.Size(72, 23);
            this.ltqx.TabIndex = 74;
            this.ltqx.Text = "T/Q/PXã :";
            this.ltqx.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lthon
            // 
            this.lthon.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lthon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lthon.Location = new System.Drawing.Point(134, 85);
            this.lthon.Name = "lthon";
            this.lthon.Size = new System.Drawing.Size(72, 23);
            this.lthon.TabIndex = 72;
            this.lthon.Text = "Thôn, phố :";
            this.lthon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lsonha
            // 
            this.lsonha.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lsonha.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lsonha.Location = new System.Drawing.Point(6, 85);
            this.lsonha.Name = "lsonha";
            this.lsonha.Size = new System.Drawing.Size(60, 23);
            this.lsonha.TabIndex = 70;
            this.lsonha.Text = "Số nhà :";
            this.lsonha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmadantoc
            // 
            this.lmadantoc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lmadantoc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmadantoc.Location = new System.Drawing.Point(378, 60);
            this.lmadantoc.Name = "lmadantoc";
            this.lmadantoc.Size = new System.Drawing.Size(56, 23);
            this.lmadantoc.TabIndex = 61;
            this.lmadantoc.Text = "Dân tộc :";
            this.lmadantoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmann
            // 
            this.lmann.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lmann.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmann.Location = new System.Drawing.Point(124, 60);
            this.lmann.Name = "lmann";
            this.lmann.Size = new System.Drawing.Size(81, 23);
            this.lmann.TabIndex = 0;
            this.lmann.Text = "Nghề nghiệp :";
            this.lmann.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.phai.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.phai.Location = new System.Drawing.Point(64, 59);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(64, 24);
            this.phai.TabIndex = 8;
            this.phai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phai_KeyDown);
            // 
            // lphai
            // 
            this.lphai.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lphai.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lphai.Location = new System.Drawing.Point(9, 60);
            this.lphai.Name = "lphai";
            this.lphai.Size = new System.Drawing.Size(56, 23);
            this.lphai.TabIndex = 161;
            this.lphai.Text = "Giới tính :";
            this.lphai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngayvv
            // 
            this.ngayvv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvv.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvv.Location = new System.Drawing.Point(104, 170);
            this.ngayvv.Mask = "##/##/####";
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(80, 23);
            this.ngayvv.TabIndex = 27;
            this.ngayvv.Text = "  /  /    ";
            this.ngayvv.Validated += new System.EventHandler(this.ngayvv_Validated);
            // 
            // tenkp
            // 
            this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(338, 169);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(141, 24);
            this.tenkp.TabIndex = 30;
            this.tenkp.SelectedIndexChanged += new System.EventHandler(this.tenkp_SelectedIndexChanged);
            this.tenkp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenkp_KeyDown);
            // 
            // madoituong
            // 
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(536, 170);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(24, 23);
            this.madoituong.TabIndex = 31;
            this.madoituong.Validated += new System.EventHandler(this.madoituong_Validated);
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // tendoituong
            // 
            this.tendoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tendoituong.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendoituong.Location = new System.Drawing.Point(562, 169);
            this.tendoituong.Name = "tendoituong";
            this.tendoituong.Size = new System.Drawing.Size(76, 24);
            this.tendoituong.TabIndex = 32;
            this.tendoituong.SelectedIndexChanged += new System.EventHandler(this.tendoituong_SelectedIndexChanged);
            this.tendoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendoituong_KeyDown);
            // 
            // label23
            // 
            this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label23.Location = new System.Drawing.Point(475, 170);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(64, 23);
            this.label23.TabIndex = 12;
            this.label23.Text = "Đối tượng :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(8, 170);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(96, 23);
            this.label19.TabIndex = 271;
            this.label19.Text = "Khám bệnh lúc :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(313, 170);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(23, 23);
            this.makp.TabIndex = 29;
            this.makp.Validated += new System.EventHandler(this.makp_Validated);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(233, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 165;
            this.label1.Text = "Khám :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(644, 170);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(140, 248);
            this.treeView1.TabIndex = 207;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // ngaysinh
            // 
            this.ngaysinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaysinh.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysinh.Location = new System.Drawing.Point(486, 34);
            this.ngaysinh.Mask = "##/##/####";
            this.ngaysinh.Name = "ngaysinh";
            this.ngaysinh.Size = new System.Drawing.Size(80, 23);
            this.ngaysinh.TabIndex = 4;
            this.ngaysinh.Text = "  /  /    ";
            this.ngaysinh.Validated += new System.EventHandler(this.ngaysinh_Validated);
            // 
            // cd_chinh
            // 
            this.cd_chinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_chinh.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_chinh.Location = new System.Drawing.Point(165, 194);
            this.cd_chinh.Name = "cd_chinh";
            this.cd_chinh.Size = new System.Drawing.Size(473, 23);
            this.cd_chinh.TabIndex = 34;
            this.cd_chinh.TextChanged += new System.EventHandler(this.cd_chinh_TextChanged);
            this.cd_chinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
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
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(167, 243);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(169, 23);
            this.tenbs.TabIndex = 37;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // xutri
            // 
            this.xutri.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xutri.Location = new System.Drawing.Point(416, 268);
            this.xutri.Name = "xutri";
            this.xutri.Size = new System.Drawing.Size(224, 148);
            this.xutri.TabIndex = 39;
            this.xutri.KeyDown += new System.Windows.Forms.KeyEventHandler(this.xutri_KeyDown);
            // 
            // maxutri
            // 
            this.maxutri.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maxutri.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.maxutri.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxutri.Location = new System.Drawing.Point(416, 243);
            this.maxutri.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.maxutri.Name = "maxutri";
            this.maxutri.Size = new System.Drawing.Size(224, 23);
            this.maxutri.TabIndex = 38;
            this.maxutri.Validated += new System.EventHandler(this.maxutri_Validated);
            // 
            // label55
            // 
            this.label55.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label55.Location = new System.Drawing.Point(615, 151);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(206, 21);
            this.label55.TabIndex = 206;
            this.label55.Text = "&CÁC LẦN KHÁM BỆNH :";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pmat
            // 
            this.pmat.Controls.Add(this.nhanapt);
            this.pmat.Controls.Add(this.nhanapp);
            this.pmat.Controls.Add(this.mt);
            this.pmat.Controls.Add(this.mp);
            this.pmat.Controls.Add(this.label33);
            this.pmat.Controls.Add(this.label22);
            this.pmat.Controls.Add(this.label18);
            this.pmat.Controls.Add(this.label35);
            this.pmat.Controls.Add(this.label36);
            this.pmat.Controls.Add(this.label37);
            this.pmat.Location = new System.Drawing.Point(-11, 218);
            this.pmat.Name = "pmat";
            this.pmat.Size = new System.Drawing.Size(659, 24);
            this.pmat.TabIndex = 35;
            // 
            // nhanapt
            // 
            this.nhanapt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhanapt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nhanapt.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhanapt.Location = new System.Drawing.Point(586, 0);
            this.nhanapt.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.nhanapt.MaxLength = 10;
            this.nhanapt.Name = "nhanapt";
            this.nhanapt.Size = new System.Drawing.Size(64, 23);
            this.nhanapt.TabIndex = 26;
            // 
            // nhanapp
            // 
            this.nhanapp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhanapp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nhanapp.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhanapp.Location = new System.Drawing.Point(471, 0);
            this.nhanapp.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.nhanapp.MaxLength = 10;
            this.nhanapp.Name = "nhanapp";
            this.nhanapp.Size = new System.Drawing.Size(64, 23);
            this.nhanapp.TabIndex = 25;
            // 
            // mt
            // 
            this.mt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mt.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mt.Location = new System.Drawing.Point(247, 0);
            this.mt.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mt.MaxLength = 10;
            this.mt.Name = "mt";
            this.mt.Size = new System.Drawing.Size(64, 23);
            this.mt.TabIndex = 24;
            // 
            // mp
            // 
            this.mp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mp.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mp.Location = new System.Drawing.Point(115, 0);
            this.mp.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mp.MaxLength = 10;
            this.mp.Name = "mp";
            this.mp.Size = new System.Drawing.Size(60, 23);
            this.mp.TabIndex = 23;
            // 
            // label33
            // 
            this.label33.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label33.Location = new System.Drawing.Point(315, 4);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(24, 16);
            this.label33.TabIndex = 5;
            this.label33.Text = "/10";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label22.Location = new System.Drawing.Point(542, 4);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(40, 16);
            this.label22.TabIndex = 3;
            this.label22.Text = "Trái :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(344, 4);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(128, 16);
            this.label18.TabIndex = 2;
            this.label18.Text = "Nhãn áp phải :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label35
            // 
            this.label35.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label35.Location = new System.Drawing.Point(206, 4);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(40, 16);
            this.label35.TabIndex = 1;
            this.label35.Text = "Trái :";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label36
            // 
            this.label36.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label36.Location = new System.Drawing.Point(178, 4);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(24, 16);
            this.label36.TabIndex = 4;
            this.label36.Text = "/10";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label37
            // 
            this.label37.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label37.Location = new System.Drawing.Point(16, 4);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(104, 16);
            this.label37.TabIndex = 0;
            this.label37.Text = "Thị lực phải :";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label53
            // 
            this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label53.Location = new System.Drawing.Point(8, 151);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(315, 21);
            this.label53.TabIndex = 0;
            this.label53.Text = "II. THÔNG TIN VÀO KHÁM BỆNH :";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(177, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 23);
            this.label2.TabIndex = 226;
            this.label2.Text = "giờ :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // giovv
            // 
            this.giovv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giovv.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giovv.Location = new System.Drawing.Point(208, 170);
            this.giovv.Mask = "##:##";
            this.giovv.Name = "giovv";
            this.giovv.Size = new System.Drawing.Size(40, 23);
            this.giovv.TabIndex = 28;
            this.giovv.Text = "  :  ";
            this.giovv.Validated += new System.EventHandler(this.giovv_Validated);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(788, 119);
            this.button1.TabIndex = 272;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmKhambenh2
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.madantoc);
            this.Controls.Add(this.thon);
            this.Controls.Add(this.mann);
            this.Controls.Add(this.ngayvv);
            this.Controls.Add(this.giovv);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.tenkp);
            this.Controls.Add(this.tentinh);
            this.Controls.Add(this.sonha);
            this.Controls.Add(this.manuoc);
            this.Controls.Add(this.pmat);
            this.Controls.Add(this.label55);
            this.Controls.Add(this.maxutri);
            this.Controls.Add(this.xutri);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.listBS);
            this.Controls.Add(this.listICD);
            this.Controls.Add(this.cd_chinh);
            this.Controls.Add(this.icd_chinh);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.ngaysinh);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.lphai);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butTiep);
            this.Controls.Add(this.label52);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.label49);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.tuoi);
            this.Controls.Add(this.mabn3);
            this.Controls.Add(this.loaituoi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mabn2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.tendoituong);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label53);
            this.Controls.Add(this.lmaqu);
            this.Controls.Add(this.maqu1);
            this.Controls.Add(this.maqu2);
            this.Controls.Add(this.tenquan);
            this.Controls.Add(this.lmaphuongxa);
            this.Controls.Add(this.mapxa1);
            this.Controls.Add(this.mapxa2);
            this.Controls.Add(this.tenpxa);
            this.Controls.Add(this.lthon);
            this.Controls.Add(this.ltqx);
            this.Controls.Add(this.tqx);
            this.Controls.Add(this.tentqx);
            this.Controls.Add(this.lmatt);
            this.Controls.Add(this.matt);
            this.Controls.Add(this.lmann);
            this.Controls.Add(this.tennn);
            this.Controls.Add(this.lmadantoc);
            this.Controls.Add(this.tendantoc);
            this.Controls.Add(this.lmanuoc);
            this.Controls.Add(this.tennuoc);
            this.Controls.Add(this.lsonha);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmKhambenh2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medisoft";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmKhambenh2_KeyDown);
            this.Load += new System.EventHandler(this.frmKhambenh2_Load);
            this.pmat.ResumeLayout(false);
            this.pmat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmKhambenh2_Load(object sender, System.EventArgs e)
		{
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = m.user;
			bTiepdon=m.bTiepdon(LibMedi.AccessData.Khambenh);
			bBacsy=m.bBacsy_tiepdon;
			b701424=m.Mabv_so==701424;
			pmat.Visible=b701424;
			bChandoan=m.bChandoan_icd10;
			bAdmin=m.bAdmin(i_userid);
			load_dm();
			phai.SelectedIndex=0;
            s_ngayvv = m.Ngaygio;
            ngayvv.Text = s_ngayvv.Substring(0,10);
            giovv.Text = s_ngayvv.Substring(11);		
			songay=m.Ngaylv_Ngayht;
			s_msg=LibMedi.AccessData.Msg;
		}

		private void load_dm()
		{
            dticd = m.get_data("select cicd10,vviet from " + user + ".icd10 where hide=0 order by cicd10").Tables[0];
			listICD.DisplayMember="CICD10";
			listICD.ValueMember="VVIET";
			listICD.DataSource=dticd;

            sql = "select * from " + user + ".btdkp_bv where makp<>'01' and loai=1";
			if (s_makp!="") sql+=" and makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			sql+=" order by makp";
            tenkp.DisplayMember="TENKP";
			tenkp.ValueMember="MAKP";
			tenkp.DataSource=m.get_data(sql).Tables[0];
			if (tenkp.Items.Count>0) tenkp.SelectedIndex=0;

			mabn2.Text=DateTime.Now.Year.ToString().Substring(2,2);

			tennn.DisplayMember="TENNN";
			tennn.ValueMember="MANN";
            tennn.DataSource = m.get_data("select * from " + user + ".btdnn_bv order by mann").Tables[0];
			
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

            dtxutri = m.get_data("select ma,to_char(ma,'00')||'   '||ten as ten from " + user + ".xutrikb order by ma").Tables[0];
			xutri.DataSource=dtxutri;
            xutri.DisplayMember = "TEN";
            xutri.ValueMember = "MA";

			listBS.DisplayMember="MA";
			listBS.ValueMember="HOTEN";

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
					ngayvv.Focus();
				}
			}
		}

		private void tenkp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tenkp.SelectedIndex==-1) tenkp.SelectedIndex=0;
				if (makp.Text!="" && l_maql==0) load_phongkham();
				SendKeys.Send("{Tab}{Home}");
			}
		}

		private void loaituoi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (loaituoi.SelectedIndex==-1) loaituoi.SelectedIndex=0;
				namsinh.Text=m.Namsinh("",int.Parse(tuoi.Text),loaituoi.SelectedIndex).ToString();
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
						ngayvv.Focus();
						SendKeys.Send("{Home}");
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
					ngayvv.Focus();
					SendKeys.Send("{HOME}");
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
							ngayvv.Focus();
							SendKeys.Send("{HOME}");
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
			if (mabn3.Text=="") return;
            nam = "";
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
						ngayvv.Focus();
						SendKeys.Send("{Home}");
					}
				}
				else
				{
					ngayvv.Focus();
					SendKeys.Send("{Home}");
				}
			} 
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
				tentinh.SelectedValue=r["matt"].ToString();
				load_quan();
				tenquan.SelectedValue=r["maqu"].ToString();
				load_pxa();
				tenpxa.SelectedValue=r["maphuongxa"].ToString();
				ret=true;
				break;
			}
            if (ret && manuoc.Enabled)
                foreach (DataRow r1 in m.get_data("select id_nuoc from " + user + ".nuocngoai where mabn='" + s_mabn + "'").Tables[0].Rows) tennuoc.SelectedValue = r1["id_nuoc"].ToString();
			load_treeView();
			return ret;
		}

		private void load_tiepdon(string m_ngay,bool skip)
		{
			l_matd=0;
			sql="select * from "+user+m.mmyy(m_ngay)+".tiepdon where mabn='"+s_mabn+"' and to_char(ngay,'dd/mm/yyyy')='"+m_ngay+"'";
            if (s_makp != "")
            {
                string s = s_makp.Replace(",", "','");
                sql += " and makp in ('" + s.Substring(0, s.Length - 3) + "')";
            }
            sql += " order by ngay desc";
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				if (skip)
				{
                    s_ngayvv = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString()));
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
				foreach(DataRow r in m.get_data("select * from "+user+m.mmyy(m_ngay)+".lienhe where maql="+l_maql).Tables[0].Rows)
				{
					if (bBacsy)
					{
						mabs.Text=r["mabs"].ToString();
						DataRow r1=m.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
						if (r1!=null) tenbs.Text=r1["hoten"].ToString();
						else tenbs.Text="";
					}
				}
			}
		}

		private void load_vv_maql(bool skip)
		{
			//emp_vv();
			emp_rv();
            if (ngayvv.Text == "") return;
            ena_but(true);
            DataRow r1;
            string s_xutri = "", xxx = user + m.mmyy(ngayvv.Text);
            sql = "select * from " + xxx + ".benhanpk where maql=" + l_maql;
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				if (!skip)
				{
					s_ngayvv=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
                    ngayvv.Text = s_ngayvv.Substring(0, 10);
                    giovv.Text = s_ngayvv.Substring(11);
				}
                l_matd = decimal.Parse(r["mavaovien"].ToString());
    			tendoituong.SelectedValue=r["madoituong"].ToString();
				madoituong.Text=r["madoituong"].ToString();
				tenkp.SelectedValue=r["makp"].ToString();
                cd_chinh.Text = r["chandoan"].ToString();
                icd_chinh.Text = r["maicd"].ToString();
                mabs.Text = r["mabs"].ToString();
                r1 = m.getrowbyid(dtbs, "ma='" + mabs.Text + "'");
                if (r1 != null) tenbs.Text = r1["hoten"].ToString();
                else tenbs.Text = "";
                s_xutri = m.get_xutri(ngayvv.Text, l_maql, 0).ToString().Trim().PadLeft(2, '0');
                if (s_xutri == "") s_xutri = r["ttlucrv"].ToString().Trim().PadLeft(2, '0') + ",";
                maxutri.Text = s_xutri;
                if (s_xutri != "")
                {
                    for (int i = 0; i <= xutri.Items.Count; i++)
                        if (s_xutri.IndexOf(i.ToString().Trim().PadLeft(2, '0') + ",") != -1) xutri.SetItemCheckState(i - 1, CheckState.Checked);
                }
                s_icd_chinh = icd_chinh.Text;
                if (!bAdmin) ena_but(false);
                break;
			}
			load_vv();
		}

		private bool load_vv_mabn()
		{
			l_maql=0;
			emp_vv();
			emp_rv();
            if (nam == "") return false;
            DataRow r1;
            string s_xutri, xxx = user + nam.Substring(nam.Length - 5, 4);
            sql = "select * from " + xxx + ".benhanpk where mabn='" + s_mabn + "' order by ngay desc";
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
                l_matd = decimal.Parse(r["mavaovien"].ToString());
				l_maql=decimal.Parse(r["maql"].ToString());
				s_ngayvv=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
                ngayvv.Text = s_ngayvv.Substring(0, 10);
                giovv.Text = s_ngayvv.Substring(11);
				tenkp.SelectedValue=r["makp"].ToString();
				tendoituong.SelectedValue=r["madoituong"].ToString();
				madoituong.Text=r["madoituong"].ToString();
                cd_chinh.Text = r["chandoan"].ToString();
                icd_chinh.Text = r["maicd"].ToString();
                mabs.Text = r["mabs"].ToString();
                r1 = m.getrowbyid(dtbs, "ma='" + mabs.Text + "'");
                if (r1 != null) tenbs.Text = r1["hoten"].ToString();
                else tenbs.Text = "";
                s_xutri = m.get_xutri(ngayvv.Text, l_maql, 0).ToString().Trim().PadLeft(2, '0');
                if (s_xutri == "") s_xutri = r["ttlucrv"].ToString().Trim().PadLeft(2, '0') + ",";
                maxutri.Text = s_xutri;
                if (s_xutri != "")
                {
                    for (int i = 0; i <= xutri.Items.Count; i++)
                        if (s_xutri.IndexOf(i.ToString().Trim().PadLeft(2, '0') + ",") != -1) xutri.SetItemCheckState(i - 1, CheckState.Checked);
                }
                s_icd_chinh = icd_chinh.Text;
				break;
			}
			load_vv();
			return l_maql!=0;
		}

		private void load_vv()
		{
			string stuoi=m.get_tuoivao(l_maql).Trim();
			if (stuoi.Length==4)
			{
				tuoi.Text=stuoi.Substring(0,3);
				loaituoi.SelectedIndex=Math.Min(int.Parse(stuoi.Substring(3,1)),3);
			}
			if (pmat.Visible)
			{
				foreach(DataRow r in m.get_data("select * from "+user+m.mmyy(ngayvv.Text)+".ttmat where maql="+l_maql).Tables[0].Rows)
				{
					mp.Text=r["mp"].ToString();
					mt.Text=r["mt"].ToString();
					nhanapp.Text=r["nhanapp"].ToString();
					nhanapt.Text=r["nhanapt"].ToString();
					break;
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

		private void frmKhambenh2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
			if (e.KeyCode==Keys.Enter)
			{
				if (tendoituong.SelectedIndex==-1) tendoituong.SelectedIndex=0;
				SendKeys.Send("{Tab}{HOME}");
			}
		}

		private void tendoituong_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tendoituong)
			{
				try
				{
					madoituong.Text=tendoituong.SelectedValue.ToString();
				}
				catch{tendoituong.SelectedIndex=0;}
			}
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
			hoten.Text="";
			ngaysinh.Text="";
			namsinh.Text="";
			tuoi.Text="";
			sonha.Text="";
			thon.Text="";
			tentqx.SelectedIndex=-1;
			tqx.Text="";
			l_maql=0;
			l_matd=0;
			b_Edit=false;
			tentinh.SelectedValue=m.Mabv.Substring(0,3);
			tendantoc.SelectedValue="25";
			tennuoc.SelectedValue="VN";
			treeView1.Nodes.Clear();
			load_quan();
			load_pxa();
			emp_vv();
			emp_rv();
		}

		private void emp_vv()
		{
			s_ngayvv=m.Ngaygio;
            ngayvv.Text = s_ngayvv.Substring(0, 10);
            giovv.Text = s_ngayvv.Substring(11);
			s_ngayvv="";
			try
			{
				madoituong.Text="2";
				tendoituong.SelectedValue=madoituong.Text;
			}
			catch{}
			if (b701424)
			{
				mabs.Text="";tenbs.Text="";
				mp.Text="";mt.Text="";
				nhanapp.Text="";nhanapt.Text="";
			}
		}

		private void emp_rv()
		{
			cd_chinh.Text="";
			icd_chinh.Text="";
			s_icd_chinh="";
			for(int i=0;i<xutri.Items.Count;i++) xutri.SetItemCheckState(i,CheckState.Unchecked);
			maxutri.Text="";

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

			s_chonxutri=chon_xutri();
			if (icd_chinh.Text=="" || cd_chinh.Text=="" || s_chonxutri=="")
			{
				if (s_chonxutri=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập xử trí khám bệnh !"),s_msg);
					xutri.Focus();
					return false;
				}

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
				if (mabs.Text=="" || tenbs.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập bác sĩ điều trị !"),s_msg);
					mabs.Focus();
					return false;
				}

			}
            if (!m.bMmyy(ngayvv.Text)) m.tao_schema(m.mmyy(ngayvv.Text), i_userid);
			s_mabn=mabn2.Text+mabn3.Text;
            l_maql = m.get_maql_ngay_makp(s_mabn, makp.Text, ngayvv.Text + " " + giovv.Text);
            if (l_maql != 0)
                if (MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã khám bệnh tại phòng khám {") + tenkp.Text.Trim().ToUpper() + "}" + "\n" + lan.Change_language_MessageText("Bạn có muốn lưu thêm 1 đợt nữa không ?"), LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    butTiep.Focus();
                    return false;
                }
            return true;
		}

		private string chon_xutri()
		{
			string s="";
			for(int i=0;i<xutri.Items.Count;i++)
				if (xutri.GetItemChecked(i)) s+=dtxutri.Rows[i]["ma"].ToString().Trim().PadLeft(2,'0')+",";
			maxutri.Text=s;
			return s;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			int p=0;string s_ttlucrv="1";
			if (s_chonxutri!="")
			{
				p=s_chonxutri.IndexOf(",");
				s_ttlucrv=s_chonxutri.Substring(0,p);
			}
			s_mabn=mabn2.Text+mabn3.Text;
            if (nam.IndexOf(m.mmyy(ngayvv.Text) + "+") == -1) nam = nam + m.mmyy(ngayvv.Text) + "+";
			if (!m.upd_btdbn(s_mabn,hoten.Text,ngaysinh.Text,namsinh.Text,phai.SelectedIndex,mann.Text,madantoc.Text,sonha.Text,thon.Text,"",matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,i_userid,nam))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
            int itable = m.tableid(m.mmyy(ngayvv.Text), "benhanpk");
            if (m.get_maql_benhanpk(s_mabn, ngayvv.Text + " " + giovv.Text, makp.Text, false) != 0)
            {
                m.upd_eve_tables(ngayvv.Text, itable, i_userid, "upd");
                m.upd_eve_upd_del(ngayvv.Text, itable, i_userid,"upd", s_mabn + "^" + l_matd.ToString() + "^" + l_maql.ToString() + "^" + makp.Text + "^" + ngayvv.Text + " " + giovv.Text + "^" + "2" + "^" + "2" + "^" + tendoituong.SelectedValue.ToString() + "^" + cd_chinh.Text + "^" + icd_chinh.Text + "^" +  s_ttlucrv + "^" + mabs.Text + "^" + "" + "^" + "0" + "^" + "0" + "^" + "0" + "^" + "0"+"^"+i_userid.ToString());
            }
            else m.upd_eve_tables(ngayvv.Text, itable, i_userid, "ins");
			l_maql=m.get_maql_benhanpk(s_mabn,ngayvv.Text+" "+giovv.Text,makp.Text,true);
            if (l_matd == 0)
            {
                l_matd = m.get_tiepdon(s_mabn, ngayvv.Text + " " + giovv.Text);
                if (bTiepdon)
                {
                    if (l_matd == 0)
                    {
                        l_matd = m.getidyymmddhhmiss_stt_computer;//m.get_capid(1);
                        m.upd_tiepdon(s_mabn,l_maql, l_matd, makp.Text, ngayvv.Text + " " + giovv.Text, int.Parse(madoituong.Text), "", tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), 0, i_userid, LibMedi.AccessData.Khambenh, 0);
                    }
                }
                m.upd_sukien(ngayvv.Text, s_mabn, l_matd, LibMedi.AccessData.Khambenh, l_maql);
            }
			if (!m.upd_lienhe(ngayvv.Text,l_maql,sonha.Text,thon.Text,"",matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),0,0))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
            if (!m.upd_benhanpk(s_mabn, l_matd, l_maql, makp.Text, ngayvv.Text + " " + giovv.Text, 2, 2, int.Parse(tendoituong.SelectedValue.ToString()), cd_chinh.Text, icd_chinh.Text, (s_ttlucrv == "") ? 0 : int.Parse(s_ttlucrv), mabs.Text, "", 0, 0, 0, 0, i_userid))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin vào viện !"), s_msg);
                return;
            }
			if (manuoc.Enabled && manuoc.Text!="") m.upd_nuocngoai(s_mabn,manuoc.Text);
			else m.execute_data("delete from "+user+".nuocngoai where mabn='"+s_mabn+"'");
			if (s_chonxutri!="" && icd_chinh.Text!="" && cd_chinh.Text!="")
			{
				if (pmat.Visible) m.upd_ttmat(ngayvv.Text,l_maql,mp.Text,mt.Text,nhanapp.Text,nhanapt.Text);
				if (s_chonxutri.IndexOf("07,")!=-1)
				{
					if (m.get_data("select * from "+user+".tuvong where maql="+l_maql).Tables[0].Rows.Count==0)
						l_tuvong_Click(null,null);
				}
				m.upd_xutrikbct(ngayvv.Text,l_maql,s_chonxutri,"");
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
            treeView1.Nodes.Clear();
            if (nam == "") return;
            s_mabn = mabn2.Text + mabn3.Text;
            TreeNode node;
            foreach (DataRow r in m.get_data_nam(nam, "select ngay,chandoan,to_char(ngay,'yyyymmdd') as yyyymmdd from xxx.benhanpk where mabn='" + s_mabn + "'").Tables[0].Select("true", "yyyymmdd desc"))
            {
                node = treeView1.Nodes.Add(m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString())));
                node.Nodes.Add(r["chandoan"].ToString());
            }
			//treeView1.ExpandAll();
		}

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (e.Action==TreeViewAction.ByMouse || e.Action==TreeViewAction.ByKeyboard)
			{
                try
                {
                    string s = e.Node.FullPath.Trim();
                    int iPos = s.IndexOf("/");
                    string ngay = s.Substring(iPos - 2, 16);
                    s_mabn = mabn2.Text + mabn3.Text;
                    l_maql = m.get_maql_benhanpk(s_mabn, ngay);
                    if (l_maql != 0)
                    {
                        ngayvv.Text = ngay.Substring(0,10);
                        giovv.Text = ngay.Substring(11);
                        load_vv_maql(true);
                    }
                }
                catch { }
			}
		}

		private void tenkp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				makp.Text=tenkp.SelectedValue.ToString();
				dtbs=m.get_data("select * from "+user+".dmbs where nhom not in ("+LibMedi.AccessData.nhanvien+","+LibMedi.AccessData.nghiviec+") order by ma").Tables[0];
				listBS.DataSource=dtbs;
			}
			catch{makp.Text="";}
		}

		private void cd_chinh_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cd_chinh)
			{
				if (bChandoan || icd_chinh.Text=="")
				{
					Filt_ICD(cd_chinh.Text);
					if (pmat.Visible) listICD.BrowseToICD10(cd_chinh,icd_chinh,mp,icd_chinh.Location.X,icd_chinh.Location.Y+icd_chinh.Height,icd_chinh.Width+cd_chinh.Width+2,icd_chinh.Height);
					else listICD.BrowseToICD10(cd_chinh,icd_chinh,mabs,icd_chinh.Location.X,icd_chinh.Location.Y+icd_chinh.Height,icd_chinh.Width+cd_chinh.Width+2,icd_chinh.Height);
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

		private void cd_kkb_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listICD.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listICD.Visible) listICD.Focus();
				else SendKeys.Send("{Tab}{Home}");
			}		
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
				listBS.BrowseToICD10(tenbs,mabs,maxutri,mabs.Location.X,mabs.Location.Y+mabs.Height,mabs.Width+tenbs.Width+2,mabs.Height);
			}		
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

		private void l_tuvong_Click(object sender, System.EventArgs e)
		{
			s_mabn=mabn2.Text+mabn3.Text;
            l_maql = m.get_maql(3, s_mabn, makp.Text, ngayvv.Text + " " + giovv.Text, false);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
            frmTuvong f = new frmTuvong(m, s_mabn, hoten.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), ngayvv.Text + " " + giovv.Text, "1", l_maql, i_userid);
			f.ShowDialog();
		}

		private void xutri_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) SendKeys.Send("{Tab}");
		}

		private void maxutri_Validated(object sender, System.EventArgs e)
		{
			s_chonxutri=maxutri.Text.Trim();
			if (s_chonxutri!="")
			{
				if (s_chonxutri.Substring(s_chonxutri.Length)!=",") s_chonxutri+=",";
				for(int i=0;i<xutri.Items.Count;i++) xutri.SetItemCheckState(i,CheckState.Unchecked);
				for(int i=0;i<=xutri.Items.Count;i++)
					if (s_chonxutri.IndexOf(i.ToString().Trim().PadLeft(2,'0')+",")!=-1) xutri.SetItemCheckState(i-1,CheckState.Checked);
				SendKeys.Send("{Tab}");
			}
		}

		private bool load_phongkham()
		{
            l_maql = m.get_maql_ngay(s_mabn, makp.Text, ngayvv.Text + " " + giovv.Text);
            if (l_maql != 0)
            {
                if (MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã khám bệnh tại phòng khám {") + tenkp.Text.Trim().ToUpper() + "}" + "\n" + lan.Change_language_MessageText("Bạn có muốn xem lại !"), LibMedi.AccessData.Msg, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    load_vv_maql(false);
                    s_ngayvv = ngayvv.Text + " " + giovv.Text;
                    return false;
                }
            }
            return true;
		}

		private void icd_chinh_TextChanged(object sender, System.EventArgs e)
		{
			listICD.Hide();
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
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập ngày khám bệnh !"), s_msg);
                ngayvv.Focus();
                return;
            }
            if (!m.bNgay(ngayvv.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
                ngayvv.Focus();
                return;
            }
            if (!m.bMmyy(m.mmyy(ngayvv.Text))) return;
            s_mabn = mabn2.Text + mabn3.Text;
            if (!bTiepdon)
            {
                if (m.get_tiepdon(s_mabn, ngayvv.Text + " " + giovv.Text) == 0)
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
            if (!makp.Enabled && makp.Text != "")
                if (!load_phongkham()) return;
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
            if (!m.bMmyy(m.mmyy(ngayvv.Text))) return;
            s_mabn = mabn2.Text + mabn3.Text;
            string s = ngayvv.Text + " " + giovv.Text;
            if (s != s_ngayvv)
            {
                if (tuoi.Text != "")
                {
                    if (namsinh.Text != m.Namsinh("", int.Parse(tuoi.Text), loaituoi.SelectedIndex).ToString())
                    {
                        tuoi.Text = Convert.ToString(int.Parse(ngayvv.Text.Substring(6, 4)) - int.Parse(namsinh.Text)).PadLeft(3, '0');
                        loaituoi.SelectedIndex = 0;
                    }
                }
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
                        string m_ngay = m.get_ngaytiepdon(s_mabn, s);
                        if (m_ngay != "")
                        {
                            if (!m.bNgaygio(s, m_ngay))
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Ngày giờ khám bệnh không được nhỏ ngày giờ tiếp đón !(") + m_ngay + ")", s_msg);
                                ngayvv.Focus();
                                return;
                            }
                        }
                    }
                    emp_vv();
                    emp_rv();
                    ngayvv.Text = s.Substring(0, 10);
                    giovv.Text = s.Substring(11);
                    if (ngayvv.Text != "") load_tiepdon(ngayvv.Text.Substring(0, 10), false);
                    l_maql = 0;
                }
                s_ngayvv = s;
            }
        }
	}
}
