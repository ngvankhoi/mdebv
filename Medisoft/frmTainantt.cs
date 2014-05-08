using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using CrystalDecisions.CrystalReports.Engine;

namespace Medisoft
{
	public class frmTainantt : System.Windows.Forms.Form
    {
        #region Khai bao
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox namsinh;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox mann;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox diachi;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox diadiem;
		private System.Windows.Forms.ComboBox bophan;
		private System.Windows.Forms.ComboBox nguyennhan;
		private System.Windows.Forms.ComboBox ngodoc;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butLuu;
		private AccessData m;
		private decimal l_maql;
		private int songay,i_userid;
        private string user, ngay_lv, s_ngaytt, s_cmnd = "", nam = "";
        private string  ngayrv, ngaysinh;
		private bool bAdmin;
		private System.Windows.Forms.Label label19;
		private MaskedBox.MaskedBox ngay;
		private System.Windows.Forms.ComboBox dienbien;
		private System.Windows.Forms.ComboBox xutri;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private MaskedTextBox.MaskedTextBox maqu1;
		private System.Windows.Forms.Label lthon;
		private System.Windows.Forms.TextBox thon;
		private System.Windows.Forms.Label ltqx;
		private System.Windows.Forms.TextBox tqx;
		private System.Windows.Forms.ComboBox tentqx;
		private System.Windows.Forms.Label lmatt;
		private System.Windows.Forms.TextBox matt;
		private System.Windows.Forms.ComboBox tentinh;
		private System.Windows.Forms.Label lmaqu;
		private System.Windows.Forms.TextBox maqu2;
		private System.Windows.Forms.ComboBox tenquan;
		private System.Windows.Forms.Label lmaphuongxa;
		private MaskedTextBox.MaskedTextBox mapxa1;
		private System.Windows.Forms.TextBox mapxa2;
		private System.Windows.Forms.ComboBox tenpxa;
		private LibList.List list;
        private MaskedBox.MaskedBox gio;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private TextBox lydo;
        private TextBox chandoan;
        private TextBox dieutri;
        private TextBox lucvao;
        private TextBox lucra;
        private Button butTainangt;
        private Button btnIn;
        private TextBox txtNoicap;
        private Label label18;
        private TextBox txtCMND;
        private Label label20;
        private TextBox txtNoilam;
        private Label label21;
		private System.ComponentModel.Container components = null;
        private Button butBaoluc;
        private bool bbadt = false;
        private string s_makp = "";
        public TreeView treeView1;
        private DataTable dtnguyennhan = new DataTable();
        #endregion

        public frmTainantt(AccessData acc, decimal maql, string s_mabn, string s_ngay, string s_hoten, string s_namsinh, string s_mann, string s_diachi, int userid, string _s_makp, string _nam_mmyy)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
            mabn.Text = s_mabn;
            hoten.Text = s_hoten;
            namsinh.Text = s_namsinh;
            mann.Text = s_mann;
            diachi.Text = s_diachi;
            l_maql = maql;
            ngay_lv = s_ngay;
            ngay.Text = s_ngay.Substring(0, 10);
            gio.Text = s_ngay.Substring(11);
            i_userid = userid;
            s_makp = _s_makp;
            nam = _nam_mmyy;
        }
        public frmTainantt(AccessData acc, decimal maql, string s_mabn, string s_ngay, string s_hoten, string s_namsinh, string s_mann, string s_diachi, int userid,string _ngayrv, string _ngaysinh,string _noilamviec,string _nam_mmyy)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
            mabn.Text = s_mabn;
            hoten.Text = s_hoten;
            namsinh.Text = s_namsinh;
            mann.Text = s_mann;
            diachi.Text = s_diachi;
            l_maql = maql;
            ngay_lv = s_ngay;
            ngay.Text = s_ngay.Substring(0, 10);
            gio.Text = s_ngay.Substring(11);
            i_userid = userid;
            ngayrv = _ngayrv;
            ngaysinh = _ngaysinh;
            txtNoilam.Text = _noilamviec;
            nam = _nam_mmyy;
        }
        //Tu:25/05/2011
        public frmTainantt(AccessData acc, decimal maql, string s_mabn, string s_ngay, string s_hoten, string s_namsinh, string s_mann, string s_diachi, int userid,bool _badt,string _s_chandoan,string _s_lydovv, string _nam_mmyy)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
            mabn.Text = s_mabn;
            hoten.Text = s_hoten;
            namsinh.Text = s_namsinh;
            mann.Text = s_mann;
            diachi.Text = s_diachi;
            l_maql = maql;
            ngay_lv = s_ngay;
            ngay.Text = s_ngay.Substring(0, 10);
            gio.Text = s_ngay.Substring(11);
            i_userid = userid;
            bbadt = _badt;
            lydo.Text = _s_lydovv;
            chandoan.Text = _s_chandoan;
            nam = _nam_mmyy;
        }
        //end Tu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTainantt));
            this.label1 = new System.Windows.Forms.Label();
            this.namsinh = new System.Windows.Forms.TextBox();
            this.hoten = new System.Windows.Forms.TextBox();
            this.mabn = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mann = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.diachi = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.diadiem = new System.Windows.Forms.ComboBox();
            this.bophan = new System.Windows.Forms.ComboBox();
            this.nguyennhan = new System.Windows.Forms.ComboBox();
            this.ngodoc = new System.Windows.Forms.ComboBox();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.ngay = new MaskedBox.MaskedBox();
            this.dienbien = new System.Windows.Forms.ComboBox();
            this.xutri = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.maqu1 = new MaskedTextBox.MaskedTextBox();
            this.lthon = new System.Windows.Forms.Label();
            this.thon = new System.Windows.Forms.TextBox();
            this.ltqx = new System.Windows.Forms.Label();
            this.tqx = new System.Windows.Forms.TextBox();
            this.tentqx = new System.Windows.Forms.ComboBox();
            this.lmatt = new System.Windows.Forms.Label();
            this.matt = new System.Windows.Forms.TextBox();
            this.tentinh = new System.Windows.Forms.ComboBox();
            this.lmaqu = new System.Windows.Forms.Label();
            this.maqu2 = new System.Windows.Forms.TextBox();
            this.tenquan = new System.Windows.Forms.ComboBox();
            this.lmaphuongxa = new System.Windows.Forms.Label();
            this.mapxa1 = new MaskedTextBox.MaskedTextBox();
            this.mapxa2 = new System.Windows.Forms.TextBox();
            this.tenpxa = new System.Windows.Forms.ComboBox();
            this.list = new LibList.List();
            this.gio = new MaskedBox.MaskedBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lydo = new System.Windows.Forms.TextBox();
            this.chandoan = new System.Windows.Forms.TextBox();
            this.dieutri = new System.Windows.Forms.TextBox();
            this.lucvao = new System.Windows.Forms.TextBox();
            this.lucra = new System.Windows.Forms.TextBox();
            this.butTainangt = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.txtNoicap = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtCMND = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtNoilam = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.butBaoluc = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(64, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 23);
            this.label1.TabIndex = 50;
            this.label1.Text = "Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(526, 8);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(43, 21);
            this.namsinh.TabIndex = 2;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(302, 8);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(168, 21);
            this.hoten.TabIndex = 1;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(182, 8);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(73, 21);
            this.mabn.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(467, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 52;
            this.label3.Text = "Năm sinh :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(254, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 51;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(32, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 23);
            this.label4.TabIndex = 48;
            this.label4.Text = "Nghề nghiệp :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mann
            // 
            this.mann.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mann.Enabled = false;
            this.mann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mann.Location = new System.Drawing.Point(182, 55);
            this.mann.Name = "mann";
            this.mann.Size = new System.Drawing.Size(136, 21);
            this.mann.TabIndex = 5;
            this.mann.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mann_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 23);
            this.label5.TabIndex = 43;
            this.label5.Text = "Địa điểm xảy ra :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(314, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 23);
            this.label6.TabIndex = 58;
            this.label6.Text = "Bộ phận bị thương :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 238);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(175, 23);
            this.label7.TabIndex = 42;
            this.label7.Text = "Nguyên nhân :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(328, 238);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 23);
            this.label8.TabIndex = 59;
            this.label8.Text = "Ngộ độc các loại :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // diachi
            // 
            this.diachi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(183, 78);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(386, 21);
            this.diachi.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(135, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 23);
            this.label9.TabIndex = 47;
            this.label9.Text = "Địa chỉ :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // diadiem
            // 
            this.diadiem.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diadiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.diadiem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diadiem.Location = new System.Drawing.Point(182, 215);
            this.diadiem.Name = "diadiem";
            this.diadiem.Size = new System.Drawing.Size(144, 21);
            this.diadiem.TabIndex = 21;
            this.diadiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.diadiem_KeyDown);
            // 
            // bophan
            // 
            this.bophan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bophan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bophan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bophan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bophan.Location = new System.Drawing.Point(422, 215);
            this.bophan.Name = "bophan";
            this.bophan.Size = new System.Drawing.Size(300, 21);
            this.bophan.TabIndex = 22;
            this.bophan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bophan_KeyDown);
            // 
            // nguyennhan
            // 
            this.nguyennhan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nguyennhan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nguyennhan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nguyennhan.Location = new System.Drawing.Point(182, 238);
            this.nguyennhan.Name = "nguyennhan";
            this.nguyennhan.Size = new System.Drawing.Size(144, 21);
            this.nguyennhan.TabIndex = 23;
            this.nguyennhan.SelectedIndexChanged += new System.EventHandler(this.nguyennhan_SelectedIndexChanged);
            this.nguyennhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nguyennhan_KeyDown);
            // 
            // ngodoc
            // 
            this.ngodoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ngodoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngodoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ngodoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngodoc.Location = new System.Drawing.Point(422, 238);
            this.ngodoc.Name = "ngodoc";
            this.ngodoc.Size = new System.Drawing.Size(300, 21);
            this.ngodoc.TabIndex = 24;
            this.ngodoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngodoc_KeyDown);
            // 
            // butBoqua
            // 
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(484, 505);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 35;
            this.butBoqua.Text = "&Kết thúc";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(169, 505);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 32;
            this.butLuu.Text = "      &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // label19
            // 
            this.label19.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label19.Location = new System.Drawing.Point(-25, 101);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(208, 23);
            this.label19.TabIndex = 10;
            this.label19.Text = "Thời điểm xảy ra tai nạn :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngay
            // 
            this.ngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Location = new System.Drawing.Point(182, 101);
            this.ngay.Mask = "##/##/####";
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(70, 21);
            this.ngay.TabIndex = 8;
            this.ngay.Text = "  /  /    ";
            this.ngay.Validated += new System.EventHandler(this.ngay_Validated);
            // 
            // dienbien
            // 
            this.dienbien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dienbien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dienbien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dienbien.Location = new System.Drawing.Point(182, 261);
            this.dienbien.Name = "dienbien";
            this.dienbien.Size = new System.Drawing.Size(144, 21);
            this.dienbien.TabIndex = 25;
            this.dienbien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dienbien_KeyDown);
            // 
            // xutri
            // 
            this.xutri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xutri.BackColor = System.Drawing.SystemColors.HighlightText;
            this.xutri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.xutri.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xutri.Location = new System.Drawing.Point(422, 261);
            this.xutri.Name = "xutri";
            this.xutri.Size = new System.Drawing.Size(300, 21);
            this.xutri.TabIndex = 26;
            this.xutri.KeyDown += new System.Windows.Forms.KeyEventHandler(this.xutri_KeyDown);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(328, 261);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 23);
            this.label10.TabIndex = 60;
            this.label10.Text = "Xử trí sau tai nạn :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(-8, 261);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(191, 23);
            this.label11.TabIndex = 41;
            this.label11.Text = "Diễn biến sau tai nạn :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // maqu1
            // 
            this.maqu1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maqu1.Enabled = false;
            this.maqu1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maqu1.Location = new System.Drawing.Point(371, 169);
            this.maqu1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.maqu1.MaxLength = 3;
            this.maqu1.Name = "maqu1";
            this.maqu1.Size = new System.Drawing.Size(27, 21);
            this.maqu1.TabIndex = 15;
            // 
            // lthon
            // 
            this.lthon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lthon.Location = new System.Drawing.Point(-40, 124);
            this.lthon.Name = "lthon";
            this.lthon.Size = new System.Drawing.Size(223, 23);
            this.lthon.TabIndex = 29;
            this.lthon.Text = "Nơi xảy ra tai nạn,Thôn :";
            this.lthon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // thon
            // 
            this.thon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thon.Location = new System.Drawing.Point(182, 124);
            this.thon.Name = "thon";
            this.thon.Size = new System.Drawing.Size(387, 21);
            this.thon.TabIndex = 10;
            this.thon.TextChanged += new System.EventHandler(this.thon_TextChanged);
            this.thon.Validated += new System.EventHandler(this.thon_Validated);
            this.thon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thon_KeyDown);
            // 
            // ltqx
            // 
            this.ltqx.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ltqx.Location = new System.Drawing.Point(48, 144);
            this.ltqx.Name = "ltqx";
            this.ltqx.Size = new System.Drawing.Size(135, 23);
            this.ltqx.TabIndex = 46;
            this.ltqx.Text = "T/Q/PXã :";
            this.ltqx.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tqx
            // 
            this.tqx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tqx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tqx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tqx.Location = new System.Drawing.Point(182, 146);
            this.tqx.Name = "tqx";
            this.tqx.Size = new System.Drawing.Size(64, 21);
            this.tqx.TabIndex = 11;
            this.tqx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tqx_KeyDown);
            // 
            // tentqx
            // 
            this.tentqx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tentqx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tentqx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tentqx.ItemHeight = 13;
            this.tentqx.Location = new System.Drawing.Point(248, 146);
            this.tentqx.Name = "tentqx";
            this.tentqx.Size = new System.Drawing.Size(321, 21);
            this.tentqx.TabIndex = 12;
            this.tentqx.SelectedIndexChanged += new System.EventHandler(this.tentqx_SelectedIndexChanged);
            this.tentqx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentqx_KeyDown);
            // 
            // lmatt
            // 
            this.lmatt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmatt.Location = new System.Drawing.Point(56, 168);
            this.lmatt.Name = "lmatt";
            this.lmatt.Size = new System.Drawing.Size(127, 23);
            this.lmatt.TabIndex = 45;
            this.lmatt.Text = "Tỉnh/TP :";
            this.lmatt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // matt
            // 
            this.matt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.matt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matt.Location = new System.Drawing.Point(182, 169);
            this.matt.MaxLength = 3;
            this.matt.Name = "matt";
            this.matt.Size = new System.Drawing.Size(27, 21);
            this.matt.TabIndex = 13;
            this.matt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matt_KeyDown);
            // 
            // tentinh
            // 
            this.tentinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tentinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tentinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tentinh.ItemHeight = 13;
            this.tentinh.Location = new System.Drawing.Point(211, 169);
            this.tentinh.Name = "tentinh";
            this.tentinh.Size = new System.Drawing.Size(112, 21);
            this.tentinh.TabIndex = 14;
            this.tentinh.SelectedIndexChanged += new System.EventHandler(this.tentinh_SelectedIndexChanged);
            this.tentinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentinh_KeyDown);
            // 
            // lmaqu
            // 
            this.lmaqu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmaqu.Location = new System.Drawing.Point(316, 168);
            this.lmaqu.Name = "lmaqu";
            this.lmaqu.Size = new System.Drawing.Size(56, 23);
            this.lmaqu.TabIndex = 57;
            this.lmaqu.Text = "Quận/H :";
            this.lmaqu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // maqu2
            // 
            this.maqu2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maqu2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maqu2.Location = new System.Drawing.Point(399, 169);
            this.maqu2.Name = "maqu2";
            this.maqu2.Size = new System.Drawing.Size(21, 21);
            this.maqu2.TabIndex = 16;
            this.maqu2.Validated += new System.EventHandler(this.maqu2_Validated);
            this.maqu2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maqu2_KeyDown);
            // 
            // tenquan
            // 
            this.tenquan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenquan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenquan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenquan.ItemHeight = 13;
            this.tenquan.Location = new System.Drawing.Point(422, 169);
            this.tenquan.Name = "tenquan";
            this.tenquan.Size = new System.Drawing.Size(147, 21);
            this.tenquan.TabIndex = 17;
            this.tenquan.SelectedIndexChanged += new System.EventHandler(this.tenquan_SelectedIndexChanged);
            this.tenquan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenquan_KeyDown);
            // 
            // lmaphuongxa
            // 
            this.lmaphuongxa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmaphuongxa.Location = new System.Drawing.Point(40, 188);
            this.lmaphuongxa.Name = "lmaphuongxa";
            this.lmaphuongxa.Size = new System.Drawing.Size(143, 23);
            this.lmaphuongxa.TabIndex = 44;
            this.lmaphuongxa.Text = "Phường/Xã :";
            this.lmaphuongxa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mapxa1
            // 
            this.mapxa1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapxa1.Enabled = false;
            this.mapxa1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapxa1.Location = new System.Drawing.Point(182, 192);
            this.mapxa1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mapxa1.MaxLength = 5;
            this.mapxa1.Name = "mapxa1";
            this.mapxa1.Size = new System.Drawing.Size(40, 21);
            this.mapxa1.TabIndex = 18;
            // 
            // mapxa2
            // 
            this.mapxa2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapxa2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapxa2.Location = new System.Drawing.Point(223, 192);
            this.mapxa2.Name = "mapxa2";
            this.mapxa2.Size = new System.Drawing.Size(23, 21);
            this.mapxa2.TabIndex = 19;
            this.mapxa2.Validated += new System.EventHandler(this.mapxa2_Validated);
            this.mapxa2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mapxa2_KeyDown);
            // 
            // tenpxa
            // 
            this.tenpxa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenpxa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenpxa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenpxa.ItemHeight = 13;
            this.tenpxa.Location = new System.Drawing.Point(248, 192);
            this.tenpxa.Name = "tenpxa";
            this.tenpxa.Size = new System.Drawing.Size(321, 21);
            this.tenpxa.TabIndex = 20;
            this.tenpxa.SelectedIndexChanged += new System.EventHandler(this.tenpxa_SelectedIndexChanged);
            this.tenpxa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenpxa_KeyDown);
            // 
            // list
            // 
            this.list.BackColor = System.Drawing.SystemColors.Info;
            this.list.ColumnCount = 0;
            this.list.Location = new System.Drawing.Point(490, 101);
            this.list.MatchBufferTimeOut = 1000;
            this.list.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(75, 17);
            this.list.TabIndex = 55;
            this.list.TextIndex = -1;
            this.list.TextMember = null;
            this.list.ValueIndex = -1;
            this.list.Visible = false;
            // 
            // gio
            // 
            this.gio.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gio.Location = new System.Drawing.Point(278, 101);
            this.gio.Mask = "##:##";
            this.gio.Name = "gio";
            this.gio.Size = new System.Drawing.Size(40, 21);
            this.gio.TabIndex = 9;
            this.gio.Text = "  :  ";
            this.gio.Validated += new System.EventHandler(this.gio_Validated);
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label12.Location = new System.Drawing.Point(251, 99);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 23);
            this.label12.TabIndex = 56;
            this.label12.Text = "giờ :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(-8, 283);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(191, 23);
            this.label13.TabIndex = 40;
            this.label13.Text = "Lí do vào viện :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(-8, 326);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(191, 23);
            this.label14.TabIndex = 39;
            this.label14.Text = "Chẩn đoán :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(-8, 370);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(191, 23);
            this.label15.TabIndex = 38;
            this.label15.Text = "Điều trị :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(-8, 412);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(191, 23);
            this.label16.TabIndex = 37;
            this.label16.Text = "Tình trạng thương tích lúc vào viện :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(-8, 458);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(191, 23);
            this.label17.TabIndex = 36;
            this.label17.Text = "Tình trạng thương tích lúc ra viện :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lydo
            // 
            this.lydo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lydo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lydo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lydo.Location = new System.Drawing.Point(182, 283);
            this.lydo.Multiline = true;
            this.lydo.Name = "lydo";
            this.lydo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.lydo.Size = new System.Drawing.Size(540, 42);
            this.lydo.TabIndex = 27;
            this.lydo.TextChanged += new System.EventHandler(this.lydo_TextChanged);
            // 
            // chandoan
            // 
            this.chandoan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(182, 326);
            this.chandoan.Multiline = true;
            this.chandoan.Name = "chandoan";
            this.chandoan.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.chandoan.Size = new System.Drawing.Size(540, 42);
            this.chandoan.TabIndex = 28;
            this.chandoan.TextChanged += new System.EventHandler(this.chandoan_TextChanged);
            // 
            // dieutri
            // 
            this.dieutri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dieutri.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dieutri.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dieutri.Location = new System.Drawing.Point(182, 370);
            this.dieutri.Multiline = true;
            this.dieutri.Name = "dieutri";
            this.dieutri.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dieutri.Size = new System.Drawing.Size(540, 42);
            this.dieutri.TabIndex = 29;
            this.dieutri.TextChanged += new System.EventHandler(this.dieutri_TextChanged);
            // 
            // lucvao
            // 
            this.lucvao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lucvao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lucvao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lucvao.Location = new System.Drawing.Point(182, 413);
            this.lucvao.Multiline = true;
            this.lucvao.Name = "lucvao";
            this.lucvao.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.lucvao.Size = new System.Drawing.Size(540, 42);
            this.lucvao.TabIndex = 30;
            this.lucvao.TextChanged += new System.EventHandler(this.lucvao_TextChanged);
            // 
            // lucra
            // 
            this.lucra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lucra.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lucra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lucra.Location = new System.Drawing.Point(182, 457);
            this.lucra.Multiline = true;
            this.lucra.Name = "lucra";
            this.lucra.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.lucra.Size = new System.Drawing.Size(540, 42);
            this.lucra.TabIndex = 31;
            this.lucra.TextChanged += new System.EventHandler(this.lucra_TextChanged);
            // 
            // butTainangt
            // 
            this.butTainangt.Image = ((System.Drawing.Image)(resources.GetObject("butTainangt.Image")));
            this.butTainangt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTainangt.Location = new System.Drawing.Point(309, 505);
            this.butTainangt.Name = "butTainangt";
            this.butTainangt.Size = new System.Drawing.Size(83, 25);
            this.butTainangt.TabIndex = 34;
            this.butTainangt.Text = "Giao thông";
            this.butTainangt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butTainangt.Click += new System.EventHandler(this.butTainangt_Click);
            // 
            // btnIn
            // 
            this.btnIn.Image = ((System.Drawing.Image)(resources.GetObject("btnIn.Image")));
            this.btnIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIn.Location = new System.Drawing.Point(239, 505);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(70, 25);
            this.btnIn.TabIndex = 33;
            this.btnIn.Text = "  &In";
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // txtNoicap
            // 
            this.txtNoicap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtNoicap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoicap.Location = new System.Drawing.Point(374, 32);
            this.txtNoicap.Name = "txtNoicap";
            this.txtNoicap.Size = new System.Drawing.Size(195, 21);
            this.txtNoicap.TabIndex = 4;
            this.txtNoicap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNoicap_KeyDown);
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(317, 31);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(55, 23);
            this.label18.TabIndex = 53;
            this.label18.Text = "Nơi cấp :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCMND
            // 
            this.txtCMND.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtCMND.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCMND.Location = new System.Drawing.Point(182, 32);
            this.txtCMND.MaxLength = 9;
            this.txtCMND.Name = "txtCMND";
            this.txtCMND.Size = new System.Drawing.Size(136, 21);
            this.txtCMND.TabIndex = 3;
            this.txtCMND.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCMND_KeyDown);
            this.txtCMND.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(32, 32);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(151, 23);
            this.label20.TabIndex = 49;
            this.label20.Text = "Số CMND :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNoilam
            // 
            this.txtNoilam.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtNoilam.Enabled = false;
            this.txtNoilam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoilam.Location = new System.Drawing.Point(374, 55);
            this.txtNoilam.Name = "txtNoilam";
            this.txtNoilam.Size = new System.Drawing.Size(195, 21);
            this.txtNoilam.TabIndex = 6;
            this.txtNoilam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNoilam_KeyDown);
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(317, 53);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(55, 23);
            this.label21.TabIndex = 54;
            this.label21.Text = "Nơi làm :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butBaoluc
            // 
            this.butBaoluc.Image = ((System.Drawing.Image)(resources.GetObject("butBaoluc.Image")));
            this.butBaoluc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBaoluc.Location = new System.Drawing.Point(392, 505);
            this.butBaoluc.Name = "butBaoluc";
            this.butBaoluc.Size = new System.Drawing.Size(92, 25);
            this.butBaoluc.TabIndex = 61;
            this.butBaoluc.Text = "Bạo lực GĐ";
            this.butBaoluc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBaoluc.Click += new System.EventHandler(this.butBaoluc_Click);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.BackColor = System.Drawing.SystemColors.Info;
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(572, 8);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(149, 204);
            this.treeView1.TabIndex = 208;
            // 
            // frmTainantt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(730, 597);
            this.ControlBox = false;
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.butBaoluc);
            this.Controls.Add(this.txtNoilam);
            this.Controls.Add(this.txtNoicap);
            this.Controls.Add(this.txtCMND);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.butTainangt);
            this.Controls.Add(this.lucra);
            this.Controls.Add(this.lucvao);
            this.Controls.Add(this.dieutri);
            this.Controls.Add(this.chandoan);
            this.Controls.Add(this.lydo);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.gio);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.list);
            this.Controls.Add(this.dienbien);
            this.Controls.Add(this.nguyennhan);
            this.Controls.Add(this.diadiem);
            this.Controls.Add(this.mapxa1);
            this.Controls.Add(this.tqx);
            this.Controls.Add(this.matt);
            this.Controls.Add(this.thon);
            this.Controls.Add(this.maqu1);
            this.Controls.Add(this.lthon);
            this.Controls.Add(this.ltqx);
            this.Controls.Add(this.tentqx);
            this.Controls.Add(this.lmatt);
            this.Controls.Add(this.tentinh);
            this.Controls.Add(this.lmaqu);
            this.Controls.Add(this.maqu2);
            this.Controls.Add(this.tenquan);
            this.Controls.Add(this.lmaphuongxa);
            this.Controls.Add(this.mapxa2);
            this.Controls.Add(this.tenpxa);
            this.Controls.Add(this.bophan);
            this.Controls.Add(this.xutri);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.ngodoc);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mann);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label21);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTainantt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin tai nạn, thương tích";
            this.Load += new System.EventHandler(this.frmTainantt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTainantt_Load(object sender, System.EventArgs e)
        {
            if (bbadt)
            {
                this.Location = new System.Drawing.Point(188 - 38, 120);//151
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Size = new Size(829 + 40, 610);
            }
            user = m.user;
			bAdmin=m.bAdmin(i_userid);
			songay=m.Ngaylv_Ngayht;
			load_dm();
            alterTable();
            string s = "";
            foreach (DataRow r in m.get_data("select a.*,b.cmnd,b.noicap from " + user + m.mmyy(ngay_lv) + ".tainantt a left join " + user + ".lienhe b on a.maql=b.maql  where a.maql=" + l_maql).Tables[0].Rows)
			{
				s=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
                ngay.Text = s.Substring(0, 10);
                gio.Text = s.Substring(11);
				diadiem.SelectedIndex=int.Parse(r["diadiem"].ToString());
				bophan.SelectedIndex=int.Parse(r["bophan"].ToString());
				nguyennhan.SelectedIndex=int.Parse(r["nguyennhan"].ToString());
				ngodoc.SelectedIndex=int.Parse(r["ngodoc"].ToString());
				dienbien.SelectedIndex=int.Parse(r["dienbien"].ToString());
				xutri.SelectedIndex=int.Parse(r["xutri"].ToString());
				thon.Text=r["thon"].ToString();
				tentinh.SelectedValue=r["matt"].ToString();
				load_quan();
				tenquan.SelectedValue=r["maqu"].ToString();
				load_pxa();
				tenpxa.SelectedValue=r["maphuongxa"].ToString();
                lydo.Text = r["lydo"].ToString();
                chandoan.Text = r["chandoan"].ToString();
                dieutri.Text = r["dieutri"].ToString();
                lucvao.Text = r["lucvao"].ToString();
                lucra.Text = r["lucra"].ToString();
                txtCMND.Text = r["cmnd"].ToString();
                txtNoicap.Text = r["noicap"].ToString();
				break;
			}
            txtCMND.Text = s_cmnd;
            s_ngaytt = ngay.Text + " " + gio.Text;
            try
            {
                DataSet ds_cl = m.get_data("select cholam,ngaysinh from " + user + ".btdbn where mabn='" + mabn.Text.Trim() + "'");
                txtNoilam.Text = ds_cl.Tables[0].Rows[0]["cholam"].ToString();
                ngaysinh = ds_cl.Tables[0].Rows[0]["ngaysinh"].ToString();
                nam = ds_cl.Tables[0].Rows[0]["nam"].ToString();
                
            }
            catch { }

            load_treeView();
			SendKeys.Send("{HOME}");
            
		}
        /// <summary>
        /// tạo thêm 2 field  số chứng minh nhân dân và nơi cấp
        /// </summary>
        private void alterTable()
        {
            try
            {
                DataTable temp = m.get_data("select cmnd from " + m.user  + ".lienhe where 1=0").Tables[0];
            }
            catch
            {
                m.execute_data("alter table " + m.user + ".lienhe add cmnd varchar2(11)");
            }
            try
            {
                DataTable temp = m.get_data("select noicap from " + m.user  + ".lienhe where 1=0").Tables[0];
            }
            catch
            {
                m.execute_data("alter table " + m.user  + ".lienhe add noicap text ");
            }
        }

		private void load_dm()
		{
			list.DisplayMember="THON";
			list.ValueMember="THON";
			list.DataSource=m.get_data("select thon as ma,thon from "+user+".dmthon order by thon").Tables[0];

			dienbien.ValueMember="MA";
			dienbien.DisplayMember="TEN";
			dienbien.DataSource=m.get_data("select * from "+user+".dmdienbien order by ma").Tables[0];
            dienbien.SelectedIndex = -1;

			xutri.ValueMember="MA";
			xutri.DisplayMember="TEN";
            xutri.DataSource = m.get_data("select * from " + user + ".dmxutri order by ma").Tables[0];
            xutri.SelectedIndex = -1;

			diadiem.ValueMember="MA";
			diadiem.DisplayMember="TEN";
            diadiem.DataSource = m.get_data("select * from " + user + ".dmdiadiem order by ma").Tables[0];
            diadiem.SelectedIndex = -1;

			bophan.ValueMember="MA";
			bophan.DisplayMember="TEN";
            bophan.DataSource = m.get_data("select * from " + user + ".dmbophan order by ma").Tables[0];
            bophan.SelectedIndex = -1;

			nguyennhan.ValueMember="MA";
            nguyennhan.DisplayMember = "TEN";
            dtnguyennhan = m.get_data("select * from " + user + ".dmnguyennhan order by ma").Tables[0];
            nguyennhan.DataSource = m.get_data("select * from " + user + ".dmnguyennhan order by ma").Tables[0];
            nguyennhan.SelectedIndex = -1;

			ngodoc.ValueMember="MA";
			ngodoc.DisplayMember="TEN";
            ngodoc.DataSource = m.get_data("select * from " + user + ".dmngodoc order by ma").Tables[0];
            ngodoc.SelectedIndex = -1;

			tentinh.DisplayMember="TENTT";
			tentinh.ValueMember="MATT";
            tentinh.DataSource = m.get_data("select * from " + user + ".btdtt order by matt").Tables[0];
			tentinh.SelectedValue=m.Mabv.Substring(0,3);

			tenquan.DisplayMember="TENQUAN";
			tenquan.ValueMember="MAQU";
			load_quan();
            
			tenpxa.DisplayMember="TENPXA";
			tenpxa.ValueMember="MAPHUONGXA";
			load_pxa();
			
			tentqx.DisplayMember="TEN";
			tentqx.ValueMember="MAPHUONGXA";

            foreach (DataRow r in m.get_data("select trim(sonha)||' '||trim(thon) as diachi,b.tentt,c.tenquan,d.tenpxa,a.cmnd, a.nam from " + user + ".btdbn a," + user + ".btdtt b," + user + ".btdquan c," + user + ".btdpxa d where a.matt=b.matt and a.maqu=c.maqu and a.maphuongxa=d.maphuongxa and a.mabn='" + mabn.Text + "'").Tables[0].Rows)
            {
                diachi.Text = r["diachi"].ToString().Trim() + " " + r["tenpxa"].ToString().Trim() + " " + r["tenquan"].ToString().Trim() + " " + r["tentt"].ToString().Trim();
                s_cmnd = r["cmnd"].ToString();
                nam = r["nam"].ToString();
                break;
            }
		}

		private void load_quan()
		{
            tenquan.DataSource = m.get_data("select * from " + user + ".btdquan where matt='" + tentinh.SelectedValue.ToString() + "'" + " order by maqu").Tables[0];
		}

		private void load_pxa()
		{
            tenpxa.DataSource = m.get_data("select * from " + user + ".btdpxa where maqu='" + tenquan.SelectedValue.ToString() + "'" + " order by maphuongxa").Tables[0];
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
					diadiem.Focus();
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

		private void load_tqx()
		{
			tentqx.DataSource=m.Tqx(tqx.Text).Tables[0];
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
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
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
							diadiem.Focus();
						}
						catch{}
					}
					else SendKeys.Send("{Tab}{F4}");
				}
			}
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
			else
			{
				if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) list.Focus(); 
				else if (e.KeyCode==Keys.Enter)
				{
					if (list.Visible) list.Focus();
					else SendKeys.Send("{Tab}{Home}");
				}		
			}
		}

		private void diadiem_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) 
			{
				if (diadiem.SelectedIndex==-1) diadiem.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void bophan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) 
			{
				if (bophan.SelectedIndex==-1) bophan.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void nguyennhan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) 
			{
				if (nguyennhan.SelectedIndex==-1) nguyennhan.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void ngodoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) 
			{
				if (ngodoc.SelectedIndex==-1) ngodoc.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private bool kiemtra()
		{
            if (txtCMND.Text.Trim() != "" && txtNoicap.Text.Trim() == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập nơi cấp chứng minh nhân dân !"), LibMedi.AccessData.Msg);
                tentinh.Focus();
                return false;   
            }
			if (tentinh.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn tỉnh/thành phố !"),LibMedi.AccessData.Msg);
				tentinh.Focus();
				return false;
			}

			if (tenquan.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn quận/huyện !"),LibMedi.AccessData.Msg);
				tenquan.Focus();
				return false;
			}

			if (tenpxa.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn phường xã !"),LibMedi.AccessData.Msg);
				tenpxa.Focus();
				return false;
			}
			if (nguyennhan.SelectedIndex==6 && ngodoc.SelectedIndex==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu loại ngộ độc !"),LibMedi.AccessData.Msg);
				ngodoc.Focus();
				return false;
			}
			else 
			{
				if (bophan.SelectedIndex==0 && nguyennhan.SelectedIndex!=7 && bophan.Enabled)
				{
					MessageBox.Show(lan.Change_language_MessageText("Yêu cầu bộ phận xảy ra !"),LibMedi.AccessData.Msg);
					bophan.Focus();
					return false;
				}
			}
            string sql = "select * from " + user + m.mmyy(ngay_lv) + ".tainantt where mabn='" + mabn.Text + "' and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + ngay.Text + " " + gio.Text + "' and maql<>" + l_maql;
            if (m.get_data(sql).Tables[0].Rows.Count > 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Người bệnh")+" " + hoten.Text + " tai nạn ngày " + ngay.Text + " " + gio.Text + "\nĐã nhập !", LibMedi.AccessData.Msg);
                return false;
            }
			return true;
		}
		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
            Cursor = Cursors.WaitCursor;
			if (!bAdmin)
			{
				if (m.get_data("select * from "+user+m.mmyy(ngay_lv)+".tainantt where maql="+l_maql).Tables[0].Rows.Count!=0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Bạn không có quyền chỉnh sửa thông tin !"),LibMedi.AccessData.Msg);
					return;
				}
			}
            int itable = m.tableid(m.mmyy(ngay_lv), "tainantt");
            if (m.get_data("select * from " + user + m.mmyy(ngay_lv) + ".tainantt where maql=" + l_maql).Tables[0].Rows.Count != 0)
            {
                m.upd_eve_tables(ngay_lv, itable, i_userid, "upd");
                m.upd_eve_upd_del(ngay_lv, itable, i_userid, "upd", mabn.Text + "^" + l_maql.ToString() + "^" + ngay.Text + " " + gio.Text + "^" + diadiem.SelectedIndex.ToString() + "^" + bophan.SelectedIndex.ToString() + "^" + nguyennhan.SelectedIndex.ToString() + "^" + ngodoc.SelectedIndex.ToString() + "^" + dienbien.SelectedIndex.ToString() + "^" + xutri.SelectedIndex.ToString() + "^" + thon.Text + "^" + matt.Text + "^" + maqu1.Text + maqu2.Text + "^" + mapxa1.Text + mapxa2.Text);
            }
            else m.upd_eve_tables(ngay_lv, itable, i_userid, "ins");
			m.upd_tainantt(mabn.Text,l_maql,ngay.Text+" "+gio.Text,diadiem.SelectedIndex,bophan.SelectedIndex,nguyennhan.SelectedIndex,ngodoc.SelectedIndex,dienbien.SelectedIndex,xutri.SelectedIndex,thon.Text,matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,lydo.Text,chandoan.Text,dieutri.Text,lucvao.Text,lucra.Text);
            // hien them cap nhat so cmnd
            if (txtCMND.Text.Trim() != "")
            {
                m.upd_lienhe(ngay_lv, l_maql, txtCMND.Text, txtNoicap.Text);
            }
			if (thon.Text!="") m.upd_dmthon(thon.Text);
            string xxx = m.mmyy(ngay.Text);
            Cursor = Cursors.Default;
            load_treeView();
            if (nguyennhan.SelectedIndex == 0 && m.get_data("select * from " + user + xxx + ".tainangt where maql=" + l_maql).Tables[0].Rows.Count == 0)
            {
                butTainangt_Click(null, null);
            }
            else if (nguyennhan.SelectedIndex == 8 )
            {
                butBaoluc_Click(null, null);
            }
            else m.close();
            btnIn.Focus();
            
            //this.Close(); //Khuong 25/11/2011 comment
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
            //string xxx = user + m.mmyy(ngay.Text);
            //if (m.get_data("select * from " + xxx + ".tainantt where maql=" + l_maql).Tables[0].Rows.Count != 0)
            //{
            //    if (nguyennhan.SelectedIndex == 0 && m.get_data("select * from " + xxx + ".tainangt where maql=" + l_maql).Tables[0].Rows.Count == 0)
            //    {
            //        MessageBox.Show(lan.Change_language_MessageText("Chưa nhập thông tin về tai nạn giao thông !"), LibMedi.AccessData.Msg);
            //        butTainangt.Focus();
            //        return;
            //    }
            //}
			m.close();this.Close();
		}

		private void nguyennhan_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				ngodoc.Enabled=nguyennhan.SelectedIndex==6;
				bophan.Enabled=!ngodoc.Enabled;
				if (!ngodoc.Enabled) ngodoc.SelectedIndex=0;
				if (!bophan.Enabled) bophan.SelectedIndex=0;
			}
			catch{}
		}

		private void dienbien_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) 
			{
				if (dienbien.SelectedIndex==-1) dienbien.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}		
		}

		private void xutri_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) 
			{
				if (xutri.SelectedIndex==-1) xutri.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}		
		}	

		private void Filter(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[list.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="thon like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void thon_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==thon)
			{
				Filter(thon.Text);
				list.BrowseToThon(thon,thon,tqx);
			}		
		}

        private void ngay_Validated(object sender, System.EventArgs e)
        {
            if (ngay.Text == "")
            {
                ngay.Focus();
                return;
            }
            ngay.Text = ngay.Text.Trim();
            if (ngay.Text.Length == 6) ngay.Text = ngay.Text + DateTime.Now.Year.ToString();
            if (ngay.Text.Length < 10)
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập ngày !"));
                ngay.Focus();
                return;
            }
            if (!m.bNgay(ngay.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
                ngay.Focus();
                return;
            }
            if (!m.ngay(m.StringToDate(ngay.Text.Substring(0, 10)), DateTime.Now, songay))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày tai nạn, thương tích không hợp lệ so với khai báo hệ thống (") + songay.ToString() + ")!", LibMedi.AccessData.Msg);
                ngay.Focus();
                return;
            }
        }

        private void gio_Validated(object sender, EventArgs e)
        {
            string sgio = (gio.Text.Trim() == "") ? "00:00" : gio.Text.Trim();
            gio.Text = sgio.Substring(0, 2).Trim().PadLeft(2, '0') + ":" + sgio.Substring(3).Trim().PadRight(2, '0');
            if (!m.bGio(gio.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"));
                gio.Focus();
                return;
            }
            if (ngay.Text+" "+gio.Text != s_ngaytt)
            {
                if (!m.bNgaygio(ngay_lv, ngay.Text+" "+gio.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày tai nạn, thương tích không được lớn hơn ngày vào (") + ngay_lv + ")", LibMedi.AccessData.Msg);
                    ngay.Focus();
                    return;
                }
            }
            SendKeys.Send("{F4}");
        }

        private void lydo_TextChanged(object sender, EventArgs e)
        {
            if (lydo.Text == "\r\n") SendKeys.Send("{Tab}");
        }

        private void chandoan_TextChanged(object sender, EventArgs e)
        {
            if (chandoan.Text == "\r\n") SendKeys.Send("{Tab}");
        }

        private void dieutri_TextChanged(object sender, EventArgs e)
        {
            if (dieutri.Text == "\r\n") SendKeys.Send("{Tab}");
        }

        private void lucvao_TextChanged(object sender, EventArgs e)
        {
            if (lucvao.Text == "\r\n") SendKeys.Send("{Tab}");
        }

        private void lucra_TextChanged(object sender, EventArgs e)
        {
            if (lucra.Text == "\r\n") SendKeys.Send("{Tab}");
        }

        private void butTainangt_Click(object sender, EventArgs e)
        {
            if (l_maql == 0)
                return;
            string xxx = user + m.mmyy(ngay.Text);
            if (m.get_data("select * from " + xxx + ".tainantt where maql=" + l_maql).Tables[0].Rows.Count == 0)//nếu click nut giao thông mà chưa lưu thì tự động lưu lại
            {
                butLuu_Click(null, null);
            }
            //Thuy 30.05.2012
            bool btainangt = false;
            try
            {
                DataRow r = m.getrowbyid(dtnguyennhan, "ma=" + nguyennhan.SelectedValue.ToString());
                if (r["tainangt"].ToString() == "1")
                {
                    btainangt = true;
                }
                if (btainangt)//nguyennhan.SelectedIndex == 0 
                {
                    frmTainangt f = new frmTainangt(m, l_maql, mabn.Text, ngay_lv, hoten.Text, namsinh.Text, mann.Text, diachi.Text, i_userid, diadiem.SelectedIndex, ngay.Text + " " + gio.Text);
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nguyên nhân không hợp lệ."));
                    return;
                }
            }
            catch
            {
                MessageBox.Show(lan.Change_language_MessageText("Nguyên nhân không hợp lệ."));
                return;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            DataSet dsReport = new DataSet();
            if (System.IO.File.Exists("..//..//..//xml//tntt.xml"))
            {
                dsReport.ReadXml("..//..//..//xml//tntt.xml", XmlReadMode.ReadSchema);
            }
            else
            {
                DataTable temp = new DataTable("Table");
                temp.Columns.Add("MABN",typeof(string));
                temp.Columns.Add("HOTEN", typeof(string));
                temp.Columns.Add("NGAYSINH", typeof(string));
                temp.Columns.Add("NAMSINH", typeof(string));
                temp.Columns.Add("NGHENGHIEP", typeof(string));
                temp.Columns.Add("NOILAMVIEC", typeof(string));
                temp.Columns.Add("SOCMND", typeof(string));
                temp.Columns.Add("NOICAP", typeof(string));
                temp.Columns.Add("DIACHI", typeof(string));
                temp.Columns.Add("NGAYVV", typeof(string));
                temp.Columns.Add("NGAYRV", typeof(string));
                temp.Columns.Add("LYDO", typeof(string));
                temp.Columns.Add("CHANDOAN", typeof(string));
                temp.Columns.Add("DIEUTRI", typeof(string));
                temp.Columns.Add("TTTTV", typeof(string));
                temp.Columns.Add("TTTTR", typeof(string));
                dsReport.Tables.Add(temp);
                dsReport.WriteXml("..//..//..//xml//tntt.xml", XmlWriteMode.WriteSchema);
           }
           DataRow row = dsReport.Tables[0].NewRow();
           row["mabn"] = mabn.Text;
           row["hoten"] = hoten.Text;
           row["ngaysinh"] = ngaysinh;
           row["namsinh"] = namsinh.Text;
           row["nghenghiep"] = mann.Text;
           row["noilamviec"] = txtNoilam.Text;
           row["diachi"] = diachi.Text;
           row["socmnd"] = txtCMND.Text;
           row["noicap"] = txtNoicap.Text;
           row["ngayvv"] = ngay.Text+( gio.Text.ToString()=="" ? "":gio.Text.ToString());
           row["ngayrv"] = ngayrv;
           row["lydo"] = lydo.Text;
           row["chandoan"] = chandoan.Text;
           row["dieutri"] = dieutri.Text;
           row["ttttv"] = lucvao.Text;
           row["ttttr"] = lucra.Text;
           dsReport.Tables[0].Rows.Add(row);
           dllReportM.frmReport f = new dllReportM.frmReport(m, dsReport, m.i_Chinhanh_hientai.ToString(), "rptTainantt.rpt");//rpttntt.rpt
            f.ShowDialog();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCMND_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtNoicap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtNoilam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void mann_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void butBaoluc_Click(object sender, EventArgs e)
        {
            try
            {
                if (l_maql == 0)
                    return;
                string s_mmyy = m.mmyy(ngay.Text), asql = "";
                DataTable dt;
                if (m.get_data("select * from " + m.user + s_mmyy + ".tainantt where maql=" + l_maql).Tables[0].Rows.Count == 0)//nếu click nut giao thông mà chưa lưu thì tự động lưu lại
                {
                    butLuu_Click(null, null);
                }
                decimal mavaovien = 0;
                if (nguyennhan.SelectedIndex == 8)
                {
                    asql = "select mavaovien from " + m.user + s_mmyy + ".benhancc where maql=" + l_maql;
                    asql += " union all ";
                    asql += "select mavaovien from " + m.user + s_mmyy + ".benhanpk where maql=" + l_maql;
                    asql += " union all ";
                    asql += "select mavaovien from " + m.user + ".benhandt where maql=" + l_maql;
                    dt = m.get_data(asql).Tables[0];
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy thông tin vào viện."));
                        return;
                    }
                    mavaovien = decimal.Parse(dt.Rows[0][0].ToString());
                    frmPhieusanglocBLGD f = new frmPhieusanglocBLGD(m, mabn.Text, hoten.Text, mavaovien, decimal.Parse(l_maql.ToString()), DateTime.Now.Year - int.Parse(namsinh.Text.Length == 4 ? namsinh.Text : namsinh.Text.Substring(6, 4)), "", "", ngay.Text,s_makp, i_userid, "", "", "", "");//gam 06/12/2011
                    //(m, l_maql, mabn.Text, ngay_lv, hoten.Text, namsinh.Text, mann.Text, diachi.Text, i_userid, diadiem.SelectedIndex, ngay.Text + " " + gio.Text);
                    f.ShowInTaskbar = false;
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nguyên nhân không hợp lệ."));
                    return;
                }
            }
            catch { }
        }

        private void load_treeView()
        {
            treeView1.Nodes.Clear();
            if (mabn.Text == "") return;
            if (nam == "") return;
            if (nam.Length > 15) nam = nam.Substring(nam.Length - 15);
            string s_mabn = mabn.Text;
            TreeNode node;
            try
            {
                string sql = "select to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,b.ten,to_char(a.ngay,'yyyymmddhh24mi') as yymmdd, a.maql from xxx.tainantt a," + user + ".dmnguyennhan b where a.nguyennhan=b.ma and a.mabn='" + s_mabn + "'";                
                foreach (DataRow r in m.get_data_nam(nam, sql).Tables[0].Select("true", "yymmdd desc"))
                {
                    node = treeView1.Nodes.Add(r["ngay"].ToString() + "-" + r["maql"].ToString());
                    node.Nodes.Add(r["ten"].ToString());
                }
            }
            catch { }
            //treeView1.ExpandAll();
        }
	}
}
