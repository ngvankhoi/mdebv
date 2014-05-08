using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibDuoc;
using LibVienphi;
 
namespace Medisoft
{
	/// <summary>
	/// Summary description for frmRavien.
	/// </summary>
	public class frmSuadoituong_ct : System.Windows.Forms.Form
	{
		Language lan = new Language();
        Bogotiengviet tv = new Bogotiengviet();
        private int i_maxlength_mabn = 8;
        private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox namsinh;
		private System.Windows.Forms.TextBox tenkp;
		private System.Windows.Forms.TextBox diachi;
		private System.Windows.Forms.Button butTiep;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butExit;
		private DataSet ds=new DataSet();
		private DataSet dsngay=new DataSet();
		private DataTable dt=new DataTable();
        private DataTable dtkp = new DataTable();
		private DataTable dtgia=new DataTable();
        private DataTable dtdt = new DataTable();
        private DataTable dt_tt = new DataTable();
		private LibMedi.AccessData m;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
		private decimal l_maql,l_idkhoa,maql_phongluu;
        private int i_loaiba, i_tunguyen, i_traituyen = 0;
        private bool b_ndot, bVienphi_phongluu, bThanhtoan_khoa, bChidinh_thutienlien, bTinhchenhlech, bChenhlech_doituong, bDuyet_congdondoituong;
        private DataRow r;
        bool bQuanLyPhongGiuongTuDong = false;
        private string s_makp, sql, s_ngayvao, s_chenhlech, s_maql = "";
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.TextBox makp;
		private System.Windows.Forms.ComboBox ngayvao;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox solieu;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox madtcu;
		private System.Windows.Forms.ComboBox madtmoi;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox theo;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butSua;
		private CurrencyManager objStudentCM;
		private DataGridTableStyle ts;
		private MaskedBox.MaskedBox ngayra;
		private decimal d_dongia,d_vattu;
        private decimal d_tyle_traituyen_dichvu = 1;
		private DataRow [] dr;
		private string gia,giavt,user,xxx,s_ngay,stime,nam;
        private bool bFound = false, bKhoa_suadoituong;
		private System.Windows.Forms.Button butTonghop;
        private MaskedBox.MaskedBox ngayvv;
        private Label label9;
        private CheckBox chktungay;
        private ToolTip toolTip1;
        private IContainer components;
        private bool bQuanly_Theo_Chinhanh = false;

		public frmSuadoituong_ct(LibMedi.AccessData acc,string makp,int loaiba)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			m=acc;s_makp=makp;i_loaiba=loaiba;
            if (m.bBogo) tv.GanBogo(this, textBox111);
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSuadoituong_ct));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.mabn = new System.Windows.Forms.TextBox();
            this.hoten = new System.Windows.Forms.TextBox();
            this.namsinh = new System.Windows.Forms.TextBox();
            this.tenkp = new System.Windows.Forms.TextBox();
            this.diachi = new System.Windows.Forms.TextBox();
            this.butTiep = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butExit = new System.Windows.Forms.Button();
            this.makp = new System.Windows.Forms.TextBox();
            this.ngayvao = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.solieu = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.madtcu = new System.Windows.Forms.ComboBox();
            this.madtmoi = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.theo = new System.Windows.Forms.ComboBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butSua = new System.Windows.Forms.Button();
            this.ngayra = new MaskedBox.MaskedBox();
            this.butTonghop = new System.Windows.Forms.Button();
            this.ngayvv = new MaskedBox.MaskedBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chktungay = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(299, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(497, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 22;
            this.label3.Text = "Năm sinh :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(2, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ngày vào :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(346, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "đến :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(448, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "Khoa xuất viện :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(594, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 23);
            this.label8.TabIndex = 24;
            this.label8.Text = "Địa chỉ :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn
            // 
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(240, 8);
            this.mabn.MaxLength = 8;
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(64, 21);
            this.mabn.TabIndex = 2;
            this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
            this.mabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(345, 8);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(131, 21);
            this.hoten.TabIndex = 21;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(560, 8);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(40, 21);
            this.namsinh.TabIndex = 23;
            // 
            // tenkp
            // 
            this.tenkp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkp.Enabled = false;
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(586, 31);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(198, 21);
            this.tenkp.TabIndex = 8;
            // 
            // diachi
            // 
            this.diachi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(648, 8);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(136, 21);
            this.diachi.TabIndex = 25;
            // 
            // butTiep
            // 
            this.butTiep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTiep.Image = ((System.Drawing.Image)(resources.GetObject("butTiep.Image")));
            this.butTiep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTiep.Location = new System.Drawing.Point(167, 527);
            this.butTiep.Name = "butTiep";
            this.butTiep.Size = new System.Drawing.Size(70, 25);
            this.butTiep.TabIndex = 15;
            this.butTiep.Text = "    &Tiếp";
            this.butTiep.Click += new System.EventHandler(this.butTiep_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(238, 527);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 13;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(380, 527);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 14;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butExit
            // 
            this.butExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butExit.Image = ((System.Drawing.Image)(resources.GetObject("butExit.Image")));
            this.butExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExit.Location = new System.Drawing.Point(542, 527);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(70, 25);
            this.butExit.TabIndex = 16;
            this.butExit.Text = "&Kết thúc";
            this.butExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.Enabled = false;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(560, 31);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(23, 21);
            this.makp.TabIndex = 7;
            // 
            // ngayvao
            // 
            this.ngayvao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ngayvao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvao.Location = new System.Drawing.Point(63, 31);
            this.ngayvao.Name = "ngayvao";
            this.ngayvao.Size = new System.Drawing.Size(112, 21);
            this.ngayvao.TabIndex = 3;
            this.ngayvao.SelectedIndexChanged += new System.EventHandler(this.ngayvao_SelectedIndexChanged);
            this.ngayvao.Validated += new System.EventHandler(this.ngayvv_Validated);
            this.ngayvao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngayvao_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(184, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "&Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(0, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 23);
            this.label10.TabIndex = 26;
            this.label10.Text = "Số liệu :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // solieu
            // 
            this.solieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.solieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solieu.Items.AddRange(new object[] {
            "Thuốc",
            "Viện phí"});
            this.solieu.Location = new System.Drawing.Point(63, 8);
            this.solieu.Name = "solieu";
            this.solieu.Size = new System.Drawing.Size(112, 21);
            this.solieu.TabIndex = 0;
            this.solieu.SelectedIndexChanged += new System.EventHandler(this.solieu_SelectedIndexChanged);
            this.solieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.solieu_KeyDown);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(170, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 23);
            this.label11.TabIndex = 28;
            this.label11.Text = "Đ. tượng củ :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(481, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 23);
            this.label12.TabIndex = 29;
            this.label12.Text = "Đối tượng mới :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madtcu
            // 
            this.madtcu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.madtcu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madtcu.Location = new System.Drawing.Point(240, 54);
            this.madtcu.Name = "madtcu";
            this.madtcu.Size = new System.Drawing.Size(234, 21);
            this.madtcu.TabIndex = 10;
            this.madtcu.SelectedIndexChanged += new System.EventHandler(this.madtcu_SelectedIndexChanged);
            this.madtcu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madtcu_KeyDown);
            // 
            // madtmoi
            // 
            this.madtmoi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.madtmoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.madtmoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madtmoi.Location = new System.Drawing.Point(560, 54);
            this.madtmoi.Name = "madtmoi";
            this.madtmoi.Size = new System.Drawing.Size(224, 21);
            this.madtmoi.TabIndex = 11;
            this.madtmoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madtmoi_KeyDown);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(0, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 23);
            this.label7.TabIndex = 32;
            this.label7.Text = "Theo :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // theo
            // 
            this.theo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.theo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.theo.Items.AddRange(new object[] {
            "Toàn bộ",
            "Chi tiết"});
            this.theo.Location = new System.Drawing.Point(63, 54);
            this.theo.Name = "theo";
            this.theo.Size = new System.Drawing.Size(112, 21);
            this.theo.TabIndex = 9;
            this.theo.SelectedIndexChanged += new System.EventHandler(this.theo_SelectedIndexChanged);
            this.theo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.theo_KeyDown);
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
            this.dataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F);
            this.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid1.Location = new System.Drawing.Point(8, 59);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.RowHeaderWidth = 5;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 462);
            this.dataGrid1.TabIndex = 34;
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(309, 527);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 12;
            this.butSua.Text = "    &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // ngayra
            // 
            this.ngayra.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayra.Location = new System.Drawing.Point(376, 31);
            this.ngayra.Mask = "##/##/#### ##:##";
            this.ngayra.Name = "ngayra";
            this.ngayra.Size = new System.Drawing.Size(100, 21);
            this.ngayra.TabIndex = 5;
            this.ngayra.Text = "  /  /       :  ";
            this.ngayra.Validated += new System.EventHandler(this.ngayra_Validated_1);
            // 
            // butTonghop
            // 
            this.butTonghop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTonghop.Image = ((System.Drawing.Image)(resources.GetObject("butTonghop.Image")));
            this.butTonghop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTonghop.Location = new System.Drawing.Point(451, 527);
            this.butTonghop.Name = "butTonghop";
            this.butTonghop.Size = new System.Drawing.Size(90, 25);
            this.butTonghop.TabIndex = 36;
            this.butTonghop.Text = "&Tổng hợp lại";
            this.butTonghop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butTonghop.Click += new System.EventHandler(this.butTonghop_Click);
            // 
            // ngayvv
            // 
            this.ngayvv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvv.Enabled = false;
            this.ngayvv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvv.Location = new System.Drawing.Point(240, 31);
            this.ngayvv.Mask = "##/##/####";
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(100, 21);
            this.ngayvv.TabIndex = 4;
            this.ngayvv.Text = "  /  /    ";
            this.ngayvv.Validated += new System.EventHandler(this.ngayvv_Validated);
            this.ngayvv.Click += new System.EventHandler(this.ngayvv_Click);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(181, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 23);
            this.label9.TabIndex = 37;
            this.label9.Text = "Từ :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chktungay
            // 
            this.chktungay.AutoSize = true;
            this.chktungay.Location = new System.Drawing.Point(196, 36);
            this.chktungay.Name = "chktungay";
            this.chktungay.Size = new System.Drawing.Size(15, 14);
            this.chktungay.TabIndex = 38;
            this.toolTip1.SetToolTip(this.chktungay, "Khi check cho phép chỉnh sửa đối tượng từ ngày .. đến ngày");
            this.chktungay.UseVisualStyleBackColor = true;
            this.chktungay.Click += new System.EventHandler(this.chktungay_Click);
            this.chktungay.CheckedChanged += new System.EventHandler(this.chktungay_CheckedChanged);
            // 
            // frmSuadoituong_ct
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.chktungay);
            this.Controls.Add(this.ngayvv);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.butTonghop);
            this.Controls.Add(this.ngayra);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.theo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.madtmoi);
            this.Controls.Add(this.madtcu);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.solieu);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.ngayvao);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butTiep);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.tenkp);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSuadoituong_ct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sửa đối tượng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSuadoituong_ct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmSuadoituong_ct_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = m.user; stime = "'" + m.f_ngay + "'";
            //
            capnhat_db();
            i_maxlength_mabn =LibMedi.AccessData.i_maxlength_mabn;
            mabn.MaxLength = i_maxlength_mabn;
            //
            bQuanLyPhongGiuongTuDong = m.bPhonggiuong;
            if (bQuanLyPhongGiuongTuDong)
            {
                this.solieu.Items.AddRange(new object[] {
            "Tiền giường"});
            }
			solieu.SelectedIndex=0;
			theo.SelectedIndex=0;
            bKhoa_suadoituong = m.bKhoa_suadoituong;
            bChidinh_thutienlien = m.bChidinh_thutienlien;
            this.bChenhlech_doituong = this.m.bChenhlech_doituong;
            bDuyet_congdondoituong = d.bPhattron_congdondoituong(m.nhom_duoc);//true: khong tinh theo doi duoc, false: linh theo doi tuong
            i_tunguyen = m.iTunguyen;
            s_chenhlech = "";
            foreach (DataRow row in this.m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + this.user + ".doituong a where chenhlech=1").Tables[0].Rows)
            {
                s_chenhlech = s_chenhlech + row["madoituong"].ToString().Trim().PadLeft(2, '0') + ",";
            }
			ena_madt();
			b_ndot=m.bThanhtoan_ndot;
            bThanhtoan_khoa = m.bThanhtoan_khoa;
			bVienphi_phongluu=m.bCapcuu_noitru;
            dtdt = m.get_data("select * from " + user + ".doituong ").Tables[0];//where sothe=1
            sql = "select 0 as loai,id,gia_th,gia_bh,gia_cs,gia_dv,gia_nn,vattu_th,vattu_bh,vattu_cs,vattu_dv,vattu_nn,bhyt,to_char(ngayud,'yyyymmddhh24mi') as ngaygio,to_char(ngayud,'yyyymmdd') as ngay, chenhlech,0 as kcct, bhyt as bhyt_tt, ' ' as sothe from " + user + ".v_giavp_luu";
			sql+=" union all ";
            sql += "select 1 as loai,id,gia_th,gia_bh,gia_cs,gia_dv,gia_nn,vattu_th,vattu_bh,vattu_cs,vattu_dv,vattu_nn,bhyt,to_char(ngayud,'yyyymmddhh24mi') as ngaygio,to_char(ngayud,'yyyymmdd') as ngay, chenhlech, kcct, bhyt_tt, sothe from " + user + ".v_giavp";
			dtgia=m.get_data(sql).Tables[0];
            dtkp = m.get_data("select id,ten as kpmoi,makp from " + user + ".d_duockp order by id").Tables[0];
            dt = m.get_data("select * from " + user + ".d_doituong order by madoituong").Tables[0];
			madtcu.DisplayMember="DOITUONG";
			madtcu.ValueMember="MADOITUONG";
			madtcu.DataSource=dt;

			madtmoi.DisplayMember="DOITUONG";
			madtmoi.ValueMember="MADOITUONG";
			load_madtmoi();
			dsngay.ReadXml("..//..//..//xml//m_ngayvao.xml");
            dsngay.Tables[0].Columns.Add("mabs");
            dsngay.Tables[0].Columns.Add("tenbs");
            dsngay.Tables[0].Columns.Add("cholam");
            dsngay.Tables[0].Columns.Add("traituyen",typeof(decimal));
            
            ngayvao.DataSource = dsngay.Tables[0];
			ngayvao.DisplayMember="NGAYVAO";
			ngayvao.ValueMember="NGAYVAO";
			
			ds.ReadXml("..//..//..//xml//m_suamadt.xml");
            ds.Tables[0].Columns.Add("traituyen", typeof(decimal)).DefaultValue = 0;
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
            if (i_loaiba == 3)
            {
                solieu.SelectedIndex = 1;
                solieu.Enabled = false;
            }
            bQuanly_Theo_Chinhanh = m.bQuanly_Theo_Chinhanh;
		}

		private void mabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void mabn_Validated(object sender, System.EventArgs e)
		{
			int i=0;decimal o_maql;
            nam = ""; hoten.Text = ""; l_maql = 0; l_idkhoa = 0; dsngay.Clear();
			if (mabn.Text=="" || mabn.Text.Trim().Length<3) return;
            if (mabn.Text.Trim().Length < 8)
            {
                if (bQuanly_Theo_Chinhanh)
                {
                    mabn.Text = mabn.Text.Substring(0, 2) + mabn.Text.Substring(2).PadLeft(i_maxlength_mabn - 2, '0');//.PadLeft(6,'0');            
                }
                else
                {
                    mabn.Text = mabn.Text.Substring(0, 2) + mabn.Text.Substring(2).PadLeft(6,'0');// .PadLeft(i_maxlength_mabn - 2, '0');           
                }
            }
            if ((b_ndot || bThanhtoan_khoa) && i_loaiba==1)
            {
                sql = "select c.hoten,c.namsinh,c.phai,c.sonha,c.thon,h.mavaovien,a.maql,a.id,a.giuong,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,";
                sql += "case when b.ngay is null then to_char(now(),'dd/mm/yyyy hh24:mi') else to_char(b.ngay,'dd/mm/yyyy hh24:mi') end as ngayra,";
                sql += "a.makp,d.tenkp,b.chandoan,b.maicd,e.tentt,f.tenquan,g.tenpxa,c.cholam, bh.sothe, bh.traituyen ";
                sql += " from " + user + ".nhapkhoa a left join " + user + ".xuatkhoa b on a.id=b.id ";
                sql += " inner join " + user + ".btdbn c on a.mabn=c.mabn ";
                sql += " inner join " + user + ".btdkp_bv d on a.makp=d.makp ";
                sql += " inner join " + user + ".btdtt e on c.matt=e.matt ";
                sql += " inner join " + user + ".btdquan f on c.maqu=f.maqu ";
                sql += " inner join " + user + ".btdpxa g on c.maphuongxa=g.maphuongxa ";
                sql += " inner join " + user + ".benhandt h on a.maql=h.maql ";
                sql += "left join " + user + ".bhyt bh on a.maql=bh.maql and (bh.sudung=1 or bh.sudung is null) ";
                sql += " where a.mabn='" + mabn.Text + "'";
                if (s_makp != "")
                {
                    string s = s_makp.Replace(",", "','");
                    sql += " and a.makp in ('" + s.Substring(0, s.Length - 3) + "')";
                }
                sql += " order by a.id desc";
            }
            else
            {
                if (i_loaiba == 1)
                {
                    sql = "select c.hoten,c.namsinh,c.phai,c.sonha,c.thon,a.mavaovien,a.maql,0 as id,' ' as giuong,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,";
                    sql += "case when b.ngay is null then to_char(now(),'dd/mm/yyyy hh24:mi') else to_char(b.ngay,'dd/mm/yyyy hh24:mi') end as ngayra,";
                    sql += "case when b.makp is null then a.makp else b.makp end as makp,case when b.makp is null then h.tenkp else d.tenkp end as tenkp,";
                    sql += "b.chandoan,b.maicd,e.tentt,f.tenquan,g.tenpxa,c.cholam, bh.sothe, bh.traituyen ";
                    sql += "from " + user + ".benhandt a left join " + user + ".xuatvien b on a.maql=b.maql ";
                    sql += "inner join " + user + ".btdbn c on a.mabn=c.mabn ";
                    sql += "left join " + user + ".btdkp_bv d on b.makp=d.makp ";
                    sql += "inner join " + user + ".btdtt e on c.matt=e.matt ";
                    sql += "inner join " + user + ".btdquan f on c.maqu=f.maqu ";
                    sql += "inner join " + user + ".btdpxa g on c.maphuongxa=g.maphuongxa ";
                    sql += "inner join " + user + ".btdkp_bv h on a.makp=h.makp ";
                    sql += "left join " + user + ".bhyt bh on a.maql=bh.maql and (bh.sudung=1 or bh.sudung is null) ";
                    sql += "where a.mabn='" + mabn.Text + "' order by a.maql desc";
                }
                else if (i_loaiba == 2)
                {
                    sql = "select c.hoten,c.namsinh,c.phai,c.sonha,c.thon,a.mavaovien,a.maql,0 as id,' ' as giuong,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,";
                    sql += "case when a.ngayrv is null then to_char(now(),'dd/mm/yyyy hh24:mi') else to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') end as ngayra,";
                    sql += "a.makp,h.tenkp,";
                    sql += "a.chandoan,a.maicd,e.tentt,f.tenquan,g.tenpxa,c.cholam, bh.sothe, bh.traituyen ";
                    sql += "from " + user + ".benhanngtr a inner join " + user + ".btdbn c on a.mabn=c.mabn ";
                    sql += "inner join " + user + ".btdtt e on c.matt=e.matt ";
                    sql += "inner join " + user + ".btdquan f on c.maqu=f.maqu ";
                    sql += "inner join " + user + ".btdpxa g on c.maphuongxa=g.maphuongxa ";
                    sql += "inner join " + user + ".btdkp_bv h on a.makp=h.makp ";
                    sql += "left join " + user + ".bhyt bh on a.maql=bh.maql and (bh.sudung=1 or bh.sudung is null) ";
                    sql += "where a.mabn='" + mabn.Text + "' order by a.maql desc";
                }
                else if (i_loaiba == 4)
                {
                    nam = m.get_mabn_nam(mabn.Text);
                    sql = "select c.hoten,c.namsinh,c.phai,c.sonha,c.thon,a.mavaovien,a.maql,0 as id,' ' as giuong,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,";
                    sql += "case when a.ngayrv is null then to_char(now(),'dd/mm/yyyy hh24:mi') else to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') end as ngayra,";
                    sql += "a.makp,h.tenkp,";
                    sql += "a.chandoan,a.maicd,e.tentt,f.tenquan,g.tenpxa,c.cholam, bh.sothe, bh.traituyen ";
                    sql += "from xxx.benhancc a inner join " + user + ".btdbn c on a.mabn=c.mabn ";
                    sql += "inner join " + user + ".btdtt e on c.matt=e.matt ";
                    sql += "inner join " + user + ".btdquan f on c.maqu=f.maqu ";
                    sql += "inner join " + user + ".btdpxa g on c.maphuongxa=g.maphuongxa ";
                    sql += "inner join " + user + ".btdkp_bv h on a.makp=h.makp ";
                    sql += "left join " + user + ".bhyt bh on a.maql=bh.maql and (bh.sudung=1 or bh.sudung is null) ";
                    sql += "where a.mabn='" + mabn.Text + "' order by a.maql desc";
                }
                else if (i_loaiba == 3)
                {
                    nam = m.get_mabn_nam(mabn.Text);
                    sql = "select c.hoten,c.namsinh,c.phai,c.sonha,c.thon,a.mavaovien,a.maql,0 as id,' ' as giuong,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,";
                    sql += "case when a.ngay is null then to_char(now(),'dd/mm/yyyy hh24:mi') else to_char(a.ngay,'dd/mm/yyyy hh24:mi') end as ngayra,";
                    sql += "a.makp,h.tenkp,";
                    sql += "a.chandoan,a.maicd,e.tentt,f.tenquan,g.tenpxa,c.cholam, bh.sothe, bh.traituyen ";
                    sql += "from xxx.benhanpk a inner join " + user + ".btdbn c on a.mabn=c.mabn ";
                    sql += "inner join " + user + ".btdtt e on c.matt=e.matt ";
                    sql += "inner join " + user + ".btdquan f on c.maqu=f.maqu ";
                    sql += "inner join " + user + ".btdpxa g on c.maphuongxa=g.maphuongxa ";
                    sql += "inner join " + user + ".btdkp_bv h on a.makp=h.makp ";
                    sql += "left join xxx.bhyt bh on a.maql=bh.maql and (bh.sudung=1 or bh.sudung is null) ";
                    sql += "where a.mabn='" + mabn.Text + "' order by a.maql desc";
                }
            }
			foreach(DataRow r in (i_loaiba>2)?m.get_data_nam_dec(nam,sql).Tables[0].Rows:m.get_data(sql).Tables[0].Rows)
			{
				if (i==0)
				{
					hoten.Text=r["hoten"].ToString();
					namsinh.Text=r["namsinh"].ToString();
					s_ngayvao=r["ngayvao"].ToString();
                    ngayvv.Text = s_ngayvao.Substring(0, 10);
					ngayra.Text=r["ngayra"].ToString();
					diachi.Text=r["sonha"].ToString().Trim()+" "+r["thon"].ToString().Trim();
					makp.Text=r["makp"].ToString();
					tenkp.Text=r["tenkp"].ToString();
					l_maql=decimal.Parse(r["maql"].ToString());
					l_idkhoa=decimal.Parse(r["id"].ToString());
                    i_traituyen = (r["traituyen"].ToString() == "") ? 0 : int.Parse(r["traituyen"].ToString());
				}
				o_maql=decimal.Parse(r["maql"].ToString());
				m.updrec_ravien(dsngay,mabn.Text,decimal.Parse(r["mavaovien"].ToString()),o_maql,decimal.Parse(r["id"].ToString()),
					hoten.Text,r["namsinh"].ToString(),(r["phai"].ToString()=="0")?"Nam":"Nữ",r["sonha"].ToString().Trim()+" "+r["thon"].ToString().Trim()+", "+r["tenpxa"].ToString().Trim()+", "+r["tenquan"].ToString().Trim()+", "+r["tentt"].ToString().Trim(),
					0,"","","","","",r["giuong"].ToString(),r["makp"].ToString(),r["tenkp"].ToString(),r["ngayvao"].ToString(),
                    r["ngayra"].ToString(),r["chandoan"].ToString(),r["maicd"].ToString(),"",0,0,0,"","","",r["cholam"].ToString(),0);
				i++;
			}
			if (l_maql==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Người bệnh này chưa hoàn tất thủ tục !"),LibMedi.AccessData.Msg);
				mabn.Focus();
			}
			else ngayvao.SelectedValue=s_ngayvao;
		}

		private void ngayvao_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ena_but(bool ena)
		{
			butTiep.Enabled=!ena;
			butSua.Enabled=ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butExit.Enabled=!ena;
		}

		private void butTiep_Click(object sender, System.EventArgs e)
		{
			ds.Clear();
			mabn.Text="";
			hoten.Text="";
			namsinh.Text="";
			ngayra.Text=m.Ngaygio_hienhanh;
            ngayvv.Enabled = chktungay.Checked;
			tenkp.Text="";
			makp.Text="";
			diachi.Text="";
            l_maql = 0; l_idkhoa = 0; 
			ena_but(true);
			solieu.Focus();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{		
            s_ngay = m.ngayhienhanh_server;
            bool bNhapPTTT_chenhlech_miengiamtheo_I08 = m.bNhapPTTT_chenhlech_miengiamtheo_I08;
            decimal v_idchidinh = 0;
            int iMadoituong = 1;
            decimal d_giabhyt = 0;
            DataRow row;
            DataRow r4 = m.getrowbyid(dtdt, "madoituong=" + int.Parse(madtmoi.SelectedValue.ToString()));
            if (!bKhoa_suadoituong)
            {
                if (m.get_thvpll(ngayra.Text, l_maql, ngayvao.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã chuyển số liệu xuống viện phí !"), LibMedi.AccessData.Msg);
                    return;
                }
                if (v.get_done_thvp(s_ngay, mabn.Text, l_maql, l_idkhoa, ngayvao.Text, i_loaiba == 4))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Người bệnh \n") + hoten.Text + "\n" + ngayvao.Text + lan.Change_language_MessageText("\nđã thanh toán !"), LibMedi.AccessData.Msg);
                    mabn.Focus();
                    return;
                }
            }
            if (r4 != null && theo.SelectedIndex == 0 && (r4["mien"].ToString() == "1" || r4["trasau"].ToString() == "1" || r4["madoituong"].ToString() == "1"))
            {
                if (i_loaiba == 3 || i_loaiba == 4)
                {
                    //nam = m.get_mabn_nam(mabn.Text);
                    sql = "select * from xxx." + ((i_loaiba == 3) ? "benhanpk" : "benhancc") + " where maql=" + l_maql + " and madoituong=" + int.Parse(r4["madoituong"].ToString());
                    if (m.get_data_mmyy(sql,ngayvao.Text.Substring(0,10),ngayra.Text.Substring(0,10),true).Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Đối tượng lúc vào không phải đối tượng ") + madtmoi.Text, LibMedi.AccessData.Msg);
                        return;
                    }
                }
                else if(r4["madoituong"].ToString()=="1")
                {
                    //BN tu doi tuong khac bhyt ma chuyen sang bhyt thi doi tuong vao bat buoc phai la bhyt
                    sql = "select * from "+user+"." + ((i_loaiba == 1) ? "benhandt" : "benhanngtr") + " where maql=" + l_maql + " and madoituong=" + int.Parse(r4["madoituong"].ToString());
                    if (m.get_data(sql).Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Đối tượng lúc vào không phải đối tượng")+" " + madtmoi.Text, LibMedi.AccessData.Msg);
                        return;
                    }
                }
            }
            else if (theo.SelectedIndex == 1)
            {
                string sdoituong = "'",smadoituong="";
                foreach (DataRow r2 in dtdt.Rows)
                {
                    smadoituong += r2["madoituong"].ToString() + ",";
                    sdoituong += r2["doituong"].ToString().Trim() + "','";
                }
                smadoituong = (smadoituong != "") ? smadoituong.Substring(0, smadoituong.Length - 1) : "";
                sdoituong = (sdoituong.Length>1) ? sdoituong.Substring(0, sdoituong.Length - 2) : "";
                bool bFound = false;
                foreach (DataRow r2 in ds.Tables[0].Select("doituong<>doituongcu"))
                {
                    if (sdoituong.IndexOf("'" + r2["doituong"].ToString().Trim() + "'") != -1)
                    {
                        bFound = true;
                        break;
                    }
                }
                if (bFound)
                {
                    if (i_loaiba == 3 || i_loaiba == 4)
                    {
                        //nam = m.get_mabn_nam(mabn.Text);
                        sql = "select * from xxx." + ((i_loaiba == 3) ? "benhanpk" : "benhancc") + " where maql=" + l_maql;
                        if (smadoituong != "") sql += " and madoituong in (" + smadoituong + ")";
                        if (m.get_data_mmyy(sql,ngayvao.Text.Substring(0,10),ngayra.Text.Substring(0,10),true).Tables[0].Rows.Count == 0)
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Đối tượng lúc vào không phải đối tượng đang sửa !"), LibMedi.AccessData.Msg);
                            return;
                        }
                    }
                    else if (r4["madoituong"].ToString() == "1")
                    {
                        sql = "select * from " + user + "." + ((i_loaiba == 1) ? "benhandt" : "benhanngtr") + " where maql=" + l_maql;
                        if (smadoituong != "") sql += " and madoituong in (" + smadoituong + ")";
                        if (m.get_data(sql).Tables[0].Rows.Count == 0)
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Đối tượng lúc vào không phải đối tượng đang sửa !"), LibMedi.AccessData.Msg);
                            return;
                        }
                    }
                }
            }
			if (m.get_thvpll(s_ngay,l_maql,ngayvao.Text) && !bKhoa_suadoituong)
			{
				MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã chuyển số liệu xuống viện phí !"),LibMedi.AccessData.Msg);
				return;
			}
			if (theo.SelectedIndex==0) //tonghop
			{
				foreach(DataRow r1 in ds.Tables[0].Select("madoituong="+int.Parse(madtcu.SelectedValue.ToString())))
				{
                    xxx = user + r1["mmyy"].ToString();
					if (madtmoi.SelectedValue.ToString()=="1" && int.Parse(r1["bhyt"].ToString())==0)
					{
						//nothing
					}
					else
					{
                        if (solieu.SelectedIndex == 2)
                        {
                            d.execute_data("update " + user + ".theodoigiuong set madoituong=" + madtmoi.SelectedValue.ToString() + " where id=" + r1["id"].ToString() + " and madoituong=" + madtcu.SelectedValue.ToString() + " and mabd=" + r1["ma"].ToString());
                        }
						else if (solieu.SelectedIndex==0)
						{
                            if (bDuyet_congdondoituong)
                            {
                                d.execute_data("update " + xxx + ".d_xuatsdct set madoituong=" + madtmoi.SelectedValue.ToString() + " where id=" + r1["id"].ToString() + " and madoituong=" + madtcu.SelectedValue.ToString() + " and mabd=" + r1["ma"].ToString());
                                d.execute_data("update " + xxx + ".d_hoantract set madoituong=" + madtmoi.SelectedValue.ToString() + " where idx=" + r1["id"].ToString() + " and madoituong=" + madtcu.SelectedValue.ToString() + " and mabd=" + r1["ma"].ToString());
                            }
							d.execute_data("delete from "+xxx+".d_tienthuoc where mabn='"+r1["mabn"].ToString()+"' and maql="+decimal.Parse(r1["maql"].ToString())+" and idkhoa="+decimal.Parse(r1["idkhoa"].ToString())+" and to_char(ngay,'dd/mm/yyyy')='"+r1["ngay"].ToString()+"' and makp="+int.Parse(r1["makp"].ToString())+" and madoituong="+int.Parse(madtcu.SelectedValue.ToString())+" and mabd="+int.Parse(r1["ma"].ToString()));
                            d.upd_tienthuoc(r1["mmyy"].ToString().PadLeft(4, '0'), decimal.Parse(r1["id"].ToString()), r1["mabn"].ToString(), decimal.Parse(r1["mavaovien"].ToString()), decimal.Parse(r1["maql"].ToString()), decimal.Parse(r1["idkhoa"].ToString()), r1["ngay"].ToString(), int.Parse(r1["makp"].ToString()), int.Parse(madtmoi.SelectedValue.ToString()), int.Parse(r1["ma"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["gianovat"].ToString()), decimal.Parse(r1["gia_bh"].ToString()),"" );
							d.upd_theodoicongno(d.delete,r1["mabn"].ToString(),decimal.Parse(r1["mavaovien"].ToString()),decimal.Parse(r1["maql"].ToString()),decimal.Parse(r1["idkhoa"].ToString()),int.Parse(madtcu.SelectedValue.ToString()),decimal.Parse(r1["sotien"].ToString()),"thuoc");
							d.upd_theodoicongno(d.insert,r1["mabn"].ToString(),decimal.Parse(r1["mavaovien"].ToString()),decimal.Parse(r1["maql"].ToString()),decimal.Parse(r1["idkhoa"].ToString()),int.Parse(madtmoi.SelectedValue.ToString()),decimal.Parse(r1["sotien"].ToString()),"thuoc");
						}
						else  
						{
							d.upd_theodoicongno(d.delete,r1["mabn"].ToString(),decimal.Parse(r1["mavaovien"].ToString()),decimal.Parse(r1["maql"].ToString()),decimal.Parse(r1["idkhoa"].ToString()),int.Parse(madtcu.SelectedValue.ToString()),decimal.Parse(r1["sotien"].ToString()),"vienphi");
                            foreach (DataRow r2 in v.get_data("select a.*, to_char(ngay,'yyyymmdd') as ngay1, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay2 from " + xxx + ".v_vpkhoa a where id=" + decimal.Parse(r1["id"].ToString())).Tables[0].Rows)
							{
                                if (bChidinh_thutienlien)
                                {
                                    sql = "delete from " + xxx + ".v_vpkhoa where id=-" + r2["id"].ToString();
                                    v.execute_data(sql);
                                    sql = "delete from " + xxx + ".v_vpkhoa where id=" + r2["id"].ToString() + " and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + r2["ngay2"].ToString() + "' and mabn='" + r2["mabn"].ToString() + "' and maql=" + decimal.Parse(r2["maql"].ToString()) + " and idkhoa=" + decimal.Parse(r2["idkhoa"].ToString()) + " and hide=1 and mavp=" + r2["mavp"].ToString();
                                    v.execute_data(sql);
                                }
								get_dongia(decimal.Parse(r2["mavp"].ToString()),madtmoi.SelectedValue.ToString(),r2["ngay1"].ToString());
                                //if (i_traituyen == 0) d_tyle_traituyen_dichvu = 1;
                                d_giabhyt = d_dongia;// *d_tyle_traituyen_dichvu;
                                if (bFound)
                                {
                                    sql = "update " + xxx + ".v_vpkhoa set madoituong=" + int.Parse(madtmoi.SelectedValue.ToString()) + ",dongia=" + d_dongia + ",vattu=" + d_vattu + ", stgiam=((tylegiam*" + d_dongia + ")/100) where id=" + decimal.Parse(r2["id"].ToString());
                                    v.execute_data(sql);                                  
                                }
                                else
                                {
                                    v.execute_data("update " + xxx + ".v_vpkhoa set madoituong=" + int.Parse(madtmoi.SelectedValue.ToString()) + " where id=" + decimal.Parse(r2["id"].ToString()));
                                }
                                //
                                //
                                iMadoituong = int.Parse(madtmoi.SelectedValue.ToString());
                                //row = m.getrowbyid(dtgia, "chenhlech=1 and id=" + int.Parse(r2["mavp"].ToString()));
                                row = get_row_dongia(decimal.Parse(r2["mavp"].ToString()), iMadoituong.ToString(), r2["ngay1"].ToString(), 1);
                                if (row != null && iMadoituong == 1)
                                {
                                    bTinhchenhlech = ((s_chenhlech.IndexOf(iMadoituong.ToString().Trim().PadLeft(2, '0') + ",") != -1) && (row["chenhlech"].ToString().Trim() == "1")) && (decimal.Parse(row[m.field_gia(i_tunguyen.ToString())].ToString()) > decimal.Parse(row[m.field_gia(iMadoituong.ToString())].ToString()));
                                    if (bChenhlech_doituong)
                                    {
                                        bTinhchenhlech = bTinhchenhlech && (iMadoituong == i_tunguyen);
                                    }
                                    if (iMadoituong == 1)
                                    {
                                        bTinhchenhlech = bTinhchenhlech && (decimal.Parse(row["bhyt"].ToString()) > 0);
                                    }
                                    else
                                    {
                                        bTinhchenhlech = bTinhchenhlech && (s_chenhlech.IndexOf(iMadoituong.ToString()) != -1);
                                    }
                                    sql = "select id from " + xxx + ".v_vpkhoa where id=" + decimal.Parse(r2["id"].ToString()) + " and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + r2["ngay2"].ToString() + "' and mavp=" + decimal.Parse(r2["mavp"].ToString()) + " and mabn='" + r2["mabn"].ToString() + "' and maql=" + decimal.Parse(r2["maql"].ToString()) + " and idkhoa=" + decimal.Parse(r2["idkhoa"].ToString());
                                    if (bTinhchenhlech && (v.get_data(sql).Tables[0].Rows.Count == 1))// || d_tyle_traituyen_dichvu < 1) 
                                    {
                                        v.execute_data("update " + xxx + ".v_vpkhoa set dachenhlech=1 where id=" + v_idchidinh);
                                        get_dongia(decimal.Parse(r2["mavp"].ToString()), i_tunguyen.ToString(), r2["ngay1"].ToString());//linh
                                        d_dongia = d_dongia - d_giabhyt;
                                        v_idchidinh = -1 * decimal.Parse(r2["id"].ToString());// v.get_id_chidinh;
                                        v.upd_vpkhoa(v_idchidinh, r2["mabn"].ToString(), decimal.Parse(r2["mavaovien"].ToString()), decimal.Parse(r2["maql"].ToString()), decimal.Parse(r2["idkhoa"].ToString()), r2["ngay2"].ToString(), r2["makp"].ToString(), i_tunguyen, int.Parse(r2["mavp"].ToString()), decimal.Parse(r2["soluong"].ToString()), d_dongia, d_vattu, int.Parse(r2["userid"].ToString()), 0);

                                        decimal d_tylegiam = decimal.Parse(r2["tylegiam"].ToString());
                                        decimal d_stgiam = (d_tylegiam / 100) * d_dongia;
                                        if (bNhapPTTT_chenhlech_miengiamtheo_I08 == false) { d_tylegiam = 0; d_stgiam = 0; };
                                        v.execute_data("update " + xxx + ".v_vpkhoa set dachenhlech=1 where id=" + v_idchidinh);
                                    }
                                }
                                //
							}
							if (m.bChidinh_vienphi)
							{
                                foreach (DataRow r2 in v.get_data("select a.*,to_char(ngay,'yyyymmdd') as ngay1, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay2 from " + xxx + ".v_chidinh a where id=" + decimal.Parse(r1["id"].ToString())).Tables[0].Rows)
								{
                                    if (bChidinh_thutienlien)
                                    {
                                        sql = "delete from " + xxx + ".v_chidinh where id=-" + r2["id"].ToString();
                                        v.execute_data(sql);
                                        sql = "delete from " + xxx + ".v_chidinh where idchidinh=" + r2["idchidinh"].ToString() + " and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + r2["ngay2"].ToString() + "' and mabn='" + r2["mabn"].ToString() + "' and maql=" + decimal.Parse(r2["maql"].ToString()) + " and idkhoa=" + decimal.Parse(r2["idkhoa"].ToString()) + " and hide=1 and mavp=" + r2["mavp"].ToString();
                                        v.execute_data(sql);
                                    }
									get_dongia(decimal.Parse(r2["mavp"].ToString()),madtmoi.SelectedValue.ToString(),r2["ngay1"].ToString());
                                    //if (i_traituyen == 0) d_tyle_traituyen_dichvu = 1;
                                    //d_dongia= d_dongia * d_tyle_traituyen_dichvu;
                                    d_giabhyt = d_dongia;
									if (bFound)
									{
                                        sql = "update " + xxx + ".v_chidinh set madoituong=" + int.Parse(madtmoi.SelectedValue.ToString()) + ",dongia=" + d_dongia + ",vattu=" + d_vattu + ", stgiam=((tylegiam*" + d_dongia + ")/100) where id=" + decimal.Parse(r2["id"].ToString());
										v.execute_data(sql);
									}
									else v.execute_data("update "+xxx+".v_chidinh set madoituong="+int.Parse(madtmoi.SelectedValue.ToString())+" where id="+decimal.Parse(r2["id"].ToString()));
                                    //

                                    //
                                    iMadoituong = int.Parse(madtmoi.SelectedValue.ToString());
                                    //row = m.getrowbyid(dtgia, "chenhlech=1 and id=" + int.Parse(r2["mavp"].ToString()));
                                    row = get_row_dongia(decimal.Parse(r2["mavp"].ToString()), iMadoituong.ToString(), r2["ngay1"].ToString(), 1);
                                    if (row != null && iMadoituong == 1)
                                    {
                                        bTinhchenhlech = ((s_chenhlech.IndexOf(iMadoituong.ToString().Trim().PadLeft(2, '0') + ",") != -1) && (row["chenhlech"].ToString().Trim() == "1")) && (decimal.Parse(row[m.field_gia(i_tunguyen.ToString())].ToString()) > decimal.Parse(row[m.field_gia(iMadoituong.ToString())].ToString()));
                                        if (bChenhlech_doituong)
                                        {
                                            bTinhchenhlech = bTinhchenhlech && (iMadoituong == i_tunguyen);
                                        }
                                        if (iMadoituong == 1)
                                        {
                                            bTinhchenhlech = bTinhchenhlech && (decimal.Parse(row["bhyt"].ToString()) > 0);
                                        }
                                        else
                                        {
                                            bTinhchenhlech = bTinhchenhlech && (s_chenhlech.IndexOf(iMadoituong.ToString()) != -1);
                                        }
                                        sql = "select id from " + xxx + ".v_chidinh where idchidinh=" + decimal.Parse(r2["idchidinh"].ToString()) + " and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + r2["ngay2"].ToString() + "' and mavp=" + decimal.Parse(r2["mavp"].ToString()) + " and mabn='" + r2["mabn"].ToString() + "' and maql=" + decimal.Parse(r2["maql"].ToString()) + " and idkhoa=" + decimal.Parse(r2["idkhoa"].ToString());
                                        if (bTinhchenhlech && (v.get_data(sql).Tables[0].Rows.Count == 1))//||d_tyle_traituyen_dichvu<1)
                                        {
                                            v.execute_data("update " + xxx + ".v_chidinh set dachenhlech=1 where id=" + v_idchidinh);
                                            get_dongia(decimal.Parse(r2["mavp"].ToString()), i_tunguyen.ToString(), r2["ngay1"].ToString());//linh
                                            d_dongia = d_dongia - d_giabhyt;
                                            v_idchidinh = -1 * decimal.Parse(r2["id"].ToString());// v.get_id_chidinh;
                                            v.upd_chidinh(v_idchidinh , r2["mabn"].ToString(), decimal.Parse(r2["mavaovien"].ToString()), decimal.Parse(r2["maql"].ToString()), decimal.Parse(r2["idkhoa"].ToString()), r2["ngay2"].ToString(), int.Parse(r2["loai"].ToString()), r2["makp"].ToString(), i_tunguyen, int.Parse(r2["mavp"].ToString()), decimal.Parse(r2["soluong"].ToString()), d_dongia, d_vattu, int.Parse(r2["userid"].ToString()), int.Parse(r2["tinhtrang"].ToString()), int.Parse(r2["thuchien"].ToString()), decimal.Parse(r2["idchidinh"].ToString()), r2["maicd"].ToString(), r2["chandoan"].ToString(), r2["mabs"].ToString(), int.Parse(r2["loaiba"].ToString()), r2["ghichu"].ToString());

                                            decimal d_tylegiam = decimal.Parse(r2["tylegiam"].ToString());
                                            decimal d_stgiam = (d_tylegiam / 100) * d_dongia;
                                            if (bNhapPTTT_chenhlech_miengiamtheo_I08 == false) { d_tylegiam = 0; d_stgiam = 0; };
                                            v.execute_data("update " + xxx + ".v_chidinh set hide=1,done=1,tylegiam=" + d_tylegiam + ", stgiam=" + d_stgiam + ", dachenhlech=1 where id=" + v_idchidinh);
                                        }
                                    }
								}
							}
							d.upd_theodoicongno(d.insert,r1["mabn"].ToString(),decimal.Parse(r1["mavaovien"].ToString()),decimal.Parse(r1["maql"].ToString()),decimal.Parse(r1["idkhoa"].ToString()),int.Parse(madtmoi.SelectedValue.ToString()),decimal.Parse(r1["sotien"].ToString()),"vienphi");	
                            //
						}
					}
				}
			}
			else
			{
				foreach(DataRow r1 in ds.Tables[0].Select("doituongcu<>doituong"))
				{
                    xxx = user + r1["mmyy"].ToString();
					r=d.getrowbyid(dt,"doituong='"+r1["doituong"].ToString()+"'");
					if (r!=null)
					{
						if (int.Parse(r["madoituong"].ToString())==1 && int.Parse(r1["bhyt"].ToString())==0)
						{
                            if (solieu.SelectedIndex == 2)//tiengiuong
                            {
                                d.execute_data("update " + user + ".theodoigiuong set madoituong=" + get_madoituong(dt, r1["doituong"].ToString()) + " where id=" + r1["id"].ToString() + " and madoituong=" + get_madoituong(dt, r1["doituongcu"].ToString()) + " and idgiuong=" + r1["ma"].ToString());
                            }
						}
						else
						{
                            if (solieu.SelectedIndex == 2)//tiengiuong
                            {
                                d.execute_data("update " + user + ".theodoigiuong set madoituong=" + get_madoituong(dt, r1["doituong"].ToString()) + " where id=" + r1["id"].ToString() + " and madoituong=" + get_madoituong(dt, r1["doituongcu"].ToString()) + " and idgiuong=" + r1["ma"].ToString());
                            }
							else if (solieu.SelectedIndex==0)//thuoc
							{
                                if (bDuyet_congdondoituong)
                                {
                                    d.execute_data("update " + xxx + ".d_xuatsdct set madoituong=" + get_madoituong(dt, r1["doituong"].ToString()) + " where id=" + r1["id"].ToString() + " and madoituong=" + get_madoituong(dt, r1["doituongcu"].ToString()) + " and mabd=" + r1["ma"].ToString());
                                    d.execute_data("update " + xxx + ".d_hoantract set madoituong=" + get_madoituong(dt, r1["doituong"].ToString()) + " where idx=" + r1["id"].ToString() + " and madoituong=" + get_madoituong(dt, r1["doituongcu"].ToString()) + " and mabd=" + r1["ma"].ToString());
                                }
								d.execute_data("delete from "+xxx+".d_tienthuoc where mabn='"+r1["mabn"].ToString()+"' and maql="+decimal.Parse(r1["maql"].ToString())+" and idkhoa="+decimal.Parse(r1["idkhoa"].ToString())+" and to_char(ngay,'dd/mm/yyyy')='"+r1["ngay"].ToString()+"' and makp="+int.Parse(r1["makp"].ToString())+" and madoituong="+int.Parse(r1["madoituong"].ToString())+" and mabd="+int.Parse(r1["ma"].ToString()));
                                d.upd_tienthuoc(r1["mmyy"].ToString().PadLeft(4, '0'), decimal.Parse(r1["id"].ToString()), r1["mabn"].ToString(), decimal.Parse(r1["mavaovien"].ToString()), decimal.Parse(r1["maql"].ToString()), decimal.Parse(r1["idkhoa"].ToString()), r1["ngay"].ToString(), int.Parse(r1["makp"].ToString()), int.Parse(r["madoituong"].ToString()), int.Parse(r1["ma"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["gianovat"].ToString()), decimal.Parse(r1["gia_bh"].ToString()),"");
								d.upd_theodoicongno(d.delete,r1["mabn"].ToString(),decimal.Parse(r1["mavaovien"].ToString()),decimal.Parse(r1["maql"].ToString()),decimal.Parse(r1["idkhoa"].ToString()),int.Parse(r1["madoituong"].ToString()),decimal.Parse(r1["sotien"].ToString()),"thuoc");
								d.upd_theodoicongno(d.insert,r1["mabn"].ToString(),decimal.Parse(r1["mavaovien"].ToString()),decimal.Parse(r1["maql"].ToString()),decimal.Parse(r1["idkhoa"].ToString()),int.Parse(r["madoituong"].ToString()),decimal.Parse(r1["sotien"].ToString()),"thuoc");
							}
							else
							{
								d.upd_theodoicongno(d.delete,r1["mabn"].ToString(),decimal.Parse(r1["mavaovien"].ToString()),decimal.Parse(r1["maql"].ToString()),decimal.Parse(r1["idkhoa"].ToString()),int.Parse(r["madoituong"].ToString()),decimal.Parse(r1["sotien"].ToString()),"vienphi");
                                foreach (DataRow r2 in v.get_data("select a.*,  to_char(a.ngay,'yyyymmdd') as ngay1, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay2 from " + xxx + ".v_vpkhoa a where id=" + decimal.Parse(r1["id"].ToString())).Tables[0].Rows)
								{
                                    if (bChidinh_thutienlien)
                                    {
                                        sql = "delete from " + xxx + ".v_vpkhoa where id=-" + r2["id"].ToString();
                                        v.execute_data(sql);
                                        sql = "delete from " + xxx + ".v_vpkhoa where id=" + r2["id"].ToString() + " and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + r2["ngay2"].ToString() + "' and mabn='" + r2["mabn"].ToString() + "' and maql=" + decimal.Parse(r2["maql"].ToString()) + " and idkhoa=" + decimal.Parse(r2["idkhoa"].ToString()) + " and hide=1 and mavp=" + r2["mavp"].ToString();
                                    }
									get_dongia(decimal.Parse(r2["mavp"].ToString()),r["madoituong"].ToString(),r2["ngay1"].ToString());
                                    //if(i_traituyen ==0) d_tyle_traituyen_dichvu=1;
                                    //d_dongia=d_dongia*d_tyle_traituyen_dichvu;
                                    d_giabhyt=d_dongia;
									if (bFound)
									{
                                        sql = "update " + xxx + ".v_vpkhoa set madoituong=" + int.Parse(r["madoituong"].ToString()) + ",dongia=" + d_dongia + ",vattu=" + d_vattu + ", stgiam=((tylegiam*" + d_dongia + ")/100) where id=" + decimal.Parse(r2["id"].ToString());
										v.execute_data(sql);
									}
									else v.execute_data("update "+xxx+".v_vpkhoa set madoituong="+int.Parse(r["madoituong"].ToString())+" where id="+decimal.Parse(r2["id"].ToString()));
                                    //                                    
                                    iMadoituong = get_madoituong(dt, r1["doituong"].ToString());
                                    //row = m.getrowbyid(dtgia, "chenhlech=1 and id=" + int.Parse(r2["mavp"].ToString()));
                                    row = get_row_dongia(decimal.Parse(r2["mavp"].ToString()),iMadoituong.ToString(), r2["ngay1"].ToString(),1);
                                    if (row != null && iMadoituong == 1)
                                    {
                                        bTinhchenhlech = ((s_chenhlech.IndexOf(iMadoituong.ToString().Trim().PadLeft(2, '0') + ",") != -1) && (row["chenhlech"].ToString().Trim() == "1")) && (decimal.Parse(row[m.field_gia(i_tunguyen.ToString())].ToString()) > decimal.Parse(row[m.field_gia(iMadoituong.ToString())].ToString()));
                                        if (bChenhlech_doituong)
                                        {
                                            bTinhchenhlech = bTinhchenhlech && (iMadoituong == i_tunguyen);
                                        }
                                        if (iMadoituong == 1)
                                        {
                                            bTinhchenhlech = bTinhchenhlech && (decimal.Parse(row["bhyt"].ToString()) > 0);
                                        }
                                        else
                                        {
                                            bTinhchenhlech = bTinhchenhlech && (s_chenhlech.IndexOf(iMadoituong.ToString()) != -1);
                                        }
                                        sql = "select id from " + xxx + ".v_vpkhoa where id=" + decimal.Parse(r2["id"].ToString()) + " and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + r2["ngay2"].ToString() + "' and mavp=" + decimal.Parse(r2["mavp"].ToString()) + " and mabn='" + r2["mabn"].ToString() + "' and maql=" + decimal.Parse(r2["maql"].ToString()) + " and idkhoa=" + decimal.Parse(r2["idkhoa"].ToString());
                                        if (bTinhchenhlech && (v.get_data(sql).Tables[0].Rows.Count == 1))//||d_tyle_traituyen_dichvu<1)
                                        {
                                            v.execute_data("update " + xxx + ".v_vpkhoa set dachenhlech=1 where id=" + v_idchidinh);
                                            get_dongia(decimal.Parse(r2["mavp"].ToString()), i_tunguyen.ToString(), r2["ngay1"].ToString());//linh
                                            d_dongia = d_dongia - d_giabhyt;
                                            v_idchidinh = -1 * decimal.Parse(r2["id"].ToString());// v.get_id_chidinh;
                                            v.upd_vpkhoa(v_idchidinh, r2["mabn"].ToString(), decimal.Parse(r2["mavaovien"].ToString()), decimal.Parse(r2["maql"].ToString()), decimal.Parse(r2["idkhoa"].ToString()), r2["ngay2"].ToString(), r2["makp"].ToString(), i_tunguyen, int.Parse(r2["mavp"].ToString()), decimal.Parse(r2["soluong"].ToString()), d_dongia, d_vattu, int.Parse(r2["userid"].ToString()), 0);
                                            v.execute_data("update " + xxx + ".v_vpkhoa set dachenhlech=1 where id=" + v_idchidinh);
                                        }
                                    }
                                    //
								}
								if (m.bChidinh_vienphi)
								{
                                    foreach (DataRow r2 in v.get_data("select a.*,to_char(ngay,'yyyymmdd') as ngay1, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay2  from " + xxx + ".v_chidinh a where id=" + decimal.Parse(r1["id"].ToString())).Tables[0].Rows)
									{
                                        if (bChidinh_thutienlien)
                                        {
                                            sql = "delete from " + xxx + ".v_chidinh where id=-" + r2["id"].ToString();
                                            v.execute_data(sql);
                                            sql = "delete from " + xxx + ".v_chidinh where idchidinh=" + r2["idchidinh"].ToString() + " and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + r2["ngay2"].ToString() + "' and mabn='" + r2["mabn"].ToString() + "' and maql=" + decimal.Parse(r2["maql"].ToString()) + " and idkhoa=" + decimal.Parse(r2["idkhoa"].ToString()) + " and hide=1 and mavp=" + r2["mavp"].ToString();
                                            v.execute_data(sql);
                                        }
										get_dongia(decimal.Parse(r2["mavp"].ToString()),r["madoituong"].ToString(),r2["ngay1"].ToString());
                                        //if(i_traituyen==0)d_tyle_traituyen_dichvu=1;
                                        //d_dongia=d_dongia*d_tyle_traituyen_dichvu;
                                        d_giabhyt = d_dongia;
										if (bFound)
										{
                                            sql = "update " + xxx + ".v_chidinh set madoituong=" + int.Parse(r["madoituong"].ToString()) + ",dongia=" + d_dongia + ",vattu=" + d_vattu + ", stgiam=((tylegiam*" + d_dongia + ")/100) where id=" + decimal.Parse(r2["id"].ToString());
											v.execute_data(sql);
										}
										else v.execute_data("update "+xxx+".v_chidinh set madoituong="+int.Parse(r["madoituong"].ToString())+" where id="+decimal.Parse(r2["id"].ToString()));
                                        //
                                        iMadoituong = get_madoituong(dt, r1["doituong"].ToString());
                                        if (iMadoituong != 0)
                                        {
                                            //row = m.getrowbyid(dtgia, "chenhlech=1 and id=" + int.Parse(r2["mavp"].ToString()));
                                            row = get_row_dongia(decimal.Parse(r2["mavp"].ToString()), iMadoituong.ToString(), r2["ngay1"].ToString(),1);
                                            if (row != null && iMadoituong == 1)
                                            {                                                
                                                bTinhchenhlech = ((s_chenhlech.IndexOf(iMadoituong.ToString().Trim().PadLeft(2, '0') + ",") != -1) && (row["chenhlech"].ToString().Trim() == "1")) && (decimal.Parse(row[m.field_gia(i_tunguyen.ToString())].ToString()) > decimal.Parse(row[m.field_gia(iMadoituong.ToString())].ToString()));
                                                if (bChenhlech_doituong)
                                                {
                                                    bTinhchenhlech = bTinhchenhlech && (iMadoituong == i_tunguyen);
                                                }
                                                if (iMadoituong == 1)
                                                {
                                                    bTinhchenhlech = bTinhchenhlech && (decimal.Parse(row["bhyt"].ToString()) > 0);
                                                }
                                                else
                                                {
                                                    bTinhchenhlech = bTinhchenhlech && (s_chenhlech.IndexOf(iMadoituong.ToString()) != -1);
                                                }
                                                sql = "select id from " + xxx + ".v_chidinh where idchidinh=" + decimal.Parse(r2["idchidinh"].ToString()) + " and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + r2["ngay2"].ToString() + "' and mavp=" + decimal.Parse(r2["mavp"].ToString()) + " and mabn='" + r2["mabn"].ToString() + "' and maql=" + decimal.Parse(r2["maql"].ToString()) + " and idkhoa=" + decimal.Parse(r2["idkhoa"].ToString());
                                                if (bTinhchenhlech && (v.get_data(sql).Tables[0].Rows.Count == 1))//||d_tyle_traituyen_dichvu<1)
                                                {
                                                    v.execute_data("update " + xxx + ".v_chidinh set dachenhlech=1 where id=" + v_idchidinh);
                                                    get_dongia(decimal.Parse(r2["mavp"].ToString()), i_tunguyen.ToString(), r2["ngay1"].ToString());//linh
                                                    d_dongia = d_dongia - d_giabhyt;
                                                    v_idchidinh = -1 * decimal.Parse(r2["id"].ToString());// v.get_id_chidinh;
                                                    v.upd_chidinh(v_idchidinh, r2["mabn"].ToString(), decimal.Parse(r2["mavaovien"].ToString()), decimal.Parse(r2["maql"].ToString()), decimal.Parse(r2["idkhoa"].ToString()), r2["ngay2"].ToString(), int.Parse(r2["loai"].ToString()), r2["makp"].ToString(), i_tunguyen, int.Parse(r2["mavp"].ToString()), decimal.Parse(r2["soluong"].ToString()), d_dongia, d_vattu, int.Parse(r2["userid"].ToString()), int.Parse(r2["tinhtrang"].ToString()), int.Parse(r2["thuchien"].ToString()), decimal.Parse(r2["idchidinh"].ToString()), r2["maicd"].ToString(), r2["chandoan"].ToString(), r2["mabs"].ToString(), int.Parse(r2["loaiba"].ToString()), r2["ghichu"].ToString());
                                                    //
                                                    decimal d_tylegiam = decimal.Parse(r2["tylegiam"].ToString());
                                                    decimal d_stgiam = (d_tylegiam / 100) * d_dongia;
                                                    if (bNhapPTTT_chenhlech_miengiamtheo_I08 == false) { d_tylegiam = 0; d_stgiam = 0; };
                                                    v.execute_data("update " + xxx + ".v_chidinh set hide=1,done=1,tylegiam=" + d_tylegiam + ", stgiam=" + d_stgiam + " where id=" + v_idchidinh);
                                                    //
                                                    
                                                }
                                            }
                                        }
									}
								}
								d.upd_theodoicongno(d.insert,r1["mabn"].ToString(),decimal.Parse(r1["mavaovien"].ToString()),decimal.Parse(r1["maql"].ToString()),decimal.Parse(r1["idkhoa"].ToString()),int.Parse(r1["madoituong"].ToString()),decimal.Parse(r1["sotien"].ToString()),"vienphi");
							}
						}
					}
				}        
			}
            if (bKhoa_suadoituong)
            {
                foreach (DataRow r1 in ds.Tables[0].Select("kp<>kpmoi"))
                {
                    xxx = user + r1["mmyy"].ToString();
                    r = d.getrowbyid(dtkp, "kpmoi='" + r1["kpmoi"].ToString() + "'");
                    if (r != null)
                    {
                        if (solieu.SelectedIndex == 0)
                        {
                            d.execute_data("delete from " + xxx + ".d_tienthuoc where mabn='" + r1["mabn"].ToString() + "' and maql=" + decimal.Parse(r1["maql"].ToString()) + " and idkhoa=" + decimal.Parse(r1["idkhoa"].ToString()) + " and to_char(ngay,'dd/mm/yyyy')='" + r1["ngay"].ToString() + "' and makp=" + int.Parse(r1["makp"].ToString()) + " and madoituong=" + int.Parse(r1["madoituong"].ToString()) + " and mabd=" + int.Parse(r1["ma"].ToString()));
                            d.upd_tienthuoc(r1["mmyy"].ToString().PadLeft(4, '0'), decimal.Parse(r1["id"].ToString()), r1["mabn"].ToString(), decimal.Parse(r1["mavaovien"].ToString()), decimal.Parse(r1["maql"].ToString()), decimal.Parse(r1["idkhoa"].ToString()), r1["ngay"].ToString(), int.Parse(r["id"].ToString()), int.Parse(r1["madoituong"].ToString()), int.Parse(r1["ma"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["gianovat"].ToString()), decimal.Parse(r1["gia_bh"].ToString()),"");
                        }
                        else
                        {
                            foreach (DataRow r2 in v.get_data("select id,madoituong,mavp,to_char(ngay,'yyyymmdd') as ngay,makp from " + xxx + ".v_vpkhoa where id=" + decimal.Parse(r1["id"].ToString())).Tables[0].Rows)
                                v.execute_data("update " + xxx + ".v_vpkhoa set makp='" + r["makp"].ToString() + "' where id=" + decimal.Parse(r2["id"].ToString()));
                            if (m.bChidinh_vienphi)
                            {
                                foreach (DataRow r2 in v.get_data("select id,madoituong,mavp,to_char(ngay,'yyyymmdd') as ngay,makp from " + xxx + ".v_chidinh where id=" + decimal.Parse(r1["id"].ToString())).Tables[0].Rows)
                                    v.execute_data("update " + xxx + ".v_chidinh set makp='" + r["makp"].ToString() + "' where id=" + decimal.Parse(r2["id"].ToString()));
                            }
                        }
                    }
                }
            }
			ena_but(false);
			butSua.Enabled=true;
			m.upd_dasuamadt(l_maql,l_idkhoa);
		}

		private void get_dongia(decimal mavp,string madoituong,string ngay)
		{
			gia=m.field_gia(madoituong);
			giavt="vattu_"+gia.Substring(4).Trim();
			d_dongia=0;d_vattu=0;
			sql="id="+mavp+" and loai=1 and ngay<="+ngay;//tim trong v_giavp
			dr=dtgia.Select(sql,"ngaygio");
			if (dr.Length>0)
			{
                //d_tyle_traituyen_dichvu = decimal.Parse(dr[0]["bhyt_tt"].ToString()) / 100;
				d_dongia=decimal.Parse(dr[0][gia].ToString());
				d_vattu=decimal.Parse(dr[0][giavt].ToString());
				bFound=true;
			}
			else
			{
				sql="id="+mavp+" and loai=0";
				dr=dtgia.Select(sql,"ngaygio desc");//tim trong v_giavp_luu
				for(int i=0;i<dr.Length;i++)
				{
					if (decimal.Parse(dr[i]["ngay"].ToString())<=decimal.Parse(ngay))
					{
                        //d_tyle_traituyen_dichvu = decimal.Parse(dr[i]["bhyt_tt"].ToString()) / 100;
						d_dongia=decimal.Parse(dr[i][gia].ToString());
						d_vattu=decimal.Parse(dr[i][giavt].ToString());
						bFound=true;
						break;
					}
				}
			}
            if (d_dongia == 0)
            {
                sql = "id=" + mavp + " and loai=1 ";//tim lai trong v_giavp: khong xet ngay
                dr = dtgia.Select(sql, "ngaygio");
                if (dr.Length > 0)
                {
                    //d_tyle_traituyen_dichvu = decimal.Parse(dr[0]["bhyt_tt"].ToString()) / 100;
                    d_dongia = decimal.Parse(dr[0][gia].ToString());
                    d_vattu = decimal.Parse(dr[0][giavt].ToString());
                    bFound = true;
                }
            }
		}

        private DataRow get_row_dongia(decimal mavp, string madoituong, string ngay, int ichenhlech)
        {
            DataRow m_dr = dtgia.NewRow();
            gia = m.field_gia(madoituong);
            giavt = "vattu_" + gia.Substring(4).Trim();
            d_dongia = 0; d_vattu = 0;
            sql = "id=" + mavp + " and loai=1 and ngay<=" + ngay;
            if (ichenhlech > 0) sql += " and chenhlech=" + ichenhlech;
            dr = dtgia.Select(sql, "ngaygio");
            if (dr.Length > 0)
            {
                m_dr = dr[0];
            }
            else
            {
                sql = "id=" + mavp + " and loai=0";
                if (ichenhlech > 0) sql += " and chenhlech=" + ichenhlech;
                dr = dtgia.Select(sql, "ngaygio desc");
                for (int i = 0; i < dr.Length; i++)
                {
                    if (decimal.Parse(dr[i]["ngay"].ToString()) <= decimal.Parse(ngay))
                    {
                        m_dr = dr[i];
                        break;
                    }
                }
            }
            return m_dr;
        }

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_but(false);
			butSua.Enabled=true;
		}

		private void butExit_Click(object sender, System.EventArgs e)
		{
            d.execute_data("delete from " + user + ".d_suamadt where maql=" + l_maql);
			m.close();this.Close();
		}

		private void AddGridTableStyle()
		{
			int IntAvgCharWidth;
			ts = new DataGridTableStyle();
			IntAvgCharWidth=(int)(System.Drawing.Graphics.FromHwnd(this.Handle).MeasureString("ABCDEFGHIJKLMNOPQRSTUVWXYZ",this.Font).Width/26);
			objStudentCM = (System.Windows.Forms.CurrencyManager)this.BindingContext[ds.Tables[0]];
			ts.MappingName = ds.Tables[0].TableName;

			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.ReadOnly=false;

			ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM .GetItemProperties()["ngay"]));
			ts.GridColumnStyles[0].MappingName = "ngay";
			ts.GridColumnStyles[0].HeaderText = "Ngày";
			ts.GridColumnStyles[0].Width=70;
			ts.ReadOnly=true;
			ts.GridColumnStyles[0].Alignment = HorizontalAlignment.Left;
			ts.GridColumnStyles[0].NullText = string.Empty;

			ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM .GetItemProperties()["ten"]));
			ts.GridColumnStyles[1].MappingName = "ten";
			ts.GridColumnStyles[1].HeaderText = "Tên thuốc - dịch vụ";
			ts.GridColumnStyles[1].Width=285;
			ts.ReadOnly=true;
			ts.GridColumnStyles[1].Alignment = HorizontalAlignment.Left;
			ts.GridColumnStyles[1].NullText = string.Empty;

			ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM .GetItemProperties()["dvt"]));
			ts.GridColumnStyles[2].MappingName = "dvt";
			ts.GridColumnStyles[2].HeaderText = "ĐVT";
			ts.GridColumnStyles[2].Width=60;
			ts.ReadOnly=true;
			ts.GridColumnStyles[2].Alignment = HorizontalAlignment.Left;
			ts.GridColumnStyles[2].NullText = string.Empty;

			ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM .GetItemProperties()["soluong"]));
			ts.GridColumnStyles[3].MappingName = "soluong";
			ts.GridColumnStyles[3].HeaderText = "Số lượng";
			ts.GridColumnStyles[3].Width=50;
			ts.ReadOnly=true;
			ts.GridColumnStyles[3].Alignment = HorizontalAlignment.Right;
			ts.GridColumnStyles[3].NullText = string.Empty;

			ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM .GetItemProperties()["doituongcu"]));
			ts.GridColumnStyles[4].MappingName = "doituongcu";
            ts.GridColumnStyles[4].HeaderText = "Đối tượng cũ";
			ts.GridColumnStyles[4].Width=80;
			ts.ReadOnly=true;
			ts.GridColumnStyles[4].Alignment = HorizontalAlignment.Left;
			ts.GridColumnStyles[4].NullText = string.Empty;

			ts.GridColumnStyles.Add(new DataGridComboBoxColumn(dt,1,1));
			ts.GridColumnStyles[5].MappingName = "doituong";
			ts.GridColumnStyles[5].HeaderText = "Đối tượng mới";
			ts.GridColumnStyles[5].Width=100;
			ts.GridColumnStyles[5].Alignment = HorizontalAlignment.Left;
			ts.GridColumnStyles[5].NullText = string.Empty;			
			dataGrid1.CaptionText = string.Empty;

			ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM .GetItemProperties()["kp"]));
			ts.GridColumnStyles[6].MappingName = "kp";
			ts.GridColumnStyles[6].HeaderText = "Khoa";
			ts.GridColumnStyles[6].Width=100;
			ts.ReadOnly=true;
			ts.GridColumnStyles[6].Alignment = HorizontalAlignment.Left;
			ts.GridColumnStyles[6].NullText = string.Empty;

            ts.GridColumnStyles.Add(new DataGridComboBoxColumn(dtkp, 1, 1));
            ts.GridColumnStyles[7].MappingName = "kpmoi";
            ts.GridColumnStyles[7].HeaderText = "Khoa phòng mới";
            ts.GridColumnStyles[7].Width = (bKhoa_suadoituong)?200:0;
            ts.GridColumnStyles[7].Alignment = HorizontalAlignment.Left;
            ts.GridColumnStyles[7].NullText = string.Empty;
            dataGrid1.CaptionText = string.Empty;

            //ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM.GetItemProperties()["traituyen"]));
            //ts.GridColumnStyles[8].MappingName = "traituyencu";
            //ts.GridColumnStyles[8].HeaderText = "Trái tuyến cũ";
            //ts.GridColumnStyles[8].Width = 50;
            //ts.ReadOnly = true;
            //ts.GridColumnStyles[8].Alignment = HorizontalAlignment.Right;
            //ts.GridColumnStyles[8].NullText = string.Empty;

            //ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM.GetItemProperties()["traituyen"]));
            //ts.GridColumnStyles[9].MappingName = "traituyen";
            //ts.GridColumnStyles[9].HeaderText = "Trái tuyến";
            //ts.GridColumnStyles[9].Width = 50;
            //ts.ReadOnly = false ;
            //ts.GridColumnStyles[9].Alignment = HorizontalAlignment.Right;
            //ts.GridColumnStyles[9].NullText = string.Empty;


			dataGrid1.DataSource = ds;
			dataGrid1.DataMember = ds.Tables[0].TableName;
			dataGrid1.TableStyles.Add(ts);
		}
	
		private void ngayvao_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==ngayvao)
			{
				if (ngayvao.SelectedIndex!=-1)
				{
                    ngayvv.Text = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ngayvao"].ToString().Substring(0, 10);
					ngayra.Text=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ngayra"].ToString();
					makp.Text=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["makp"].ToString();
					tenkp.Text=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["tenkp"].ToString();
					l_maql=decimal.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString());
					l_idkhoa=decimal.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["idkhoa"].ToString());
				}
			}
		}

		private void ngayra_Validated(object sender, System.EventArgs e)
		{
			if (ngayra.Text=="")
			{
				ngayra.Focus();
				return;
			}
			ngayra.Text=ngayra.Text.Trim();
			if (ngayra.Text.Length<16)
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày và giờ !"),LibMedi.AccessData.Msg);
				ngayra.Focus();
				return;
			}
			if (!m.bNgay(ngayra.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
				ngayra.Focus();
				return;
			}
			ngayra.Text=m.Ktngaygio(ngayra.Text,16);
		}

		private void solieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (solieu.SelectedIndex==-1) solieu.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void theo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (theo.SelectedIndex==-1) theo.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void madtcu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (madtcu.SelectedIndex==-1) madtcu.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void madtmoi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (madtmoi.SelectedIndex==-1) madtmoi.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void madtcu_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==madtcu) load_madtmoi();		
		}

		private void load_madtmoi()
		{
			sql="select * from "+user+".d_doituong where madoituong<>"+int.Parse(madtcu.SelectedValue.ToString())+" order by madoituong";
			madtmoi.DataSource=m.get_data(sql).Tables[0];
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
            if (solieu.SelectedIndex == 0) dtkp = m.get_data("select id,ten as kpmoi,makp from " + user + ".d_duockp order by id").Tables[0];
            else dtkp = m.get_data("select 0 as id,tenkp as kpmoi,makp from " + user + ".btdkp_bv order by makp").Tables[0];
			s_ngay=m.ngayhienhanh_server;
            //if (!bKhoa_suadoituong)
            //{
            //    if (m.get_thvpll(ngayra.Text, l_maql, ngayvao.Text))
            //    {
            //        MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã chuyển số liệu xuống viện phí !"), LibMedi.AccessData.Msg);
            //        return;
            //    }
            //    if (v.get_done_thvp(s_ngay, mabn.Text, l_maql, l_idkhoa, ngayvao.Text,i_loaiba==4))
            //    {
            //        MessageBox.Show(lan.Change_language_MessageText("Người bệnh \n") + hoten.Text + "\n" + ngayvao.Text + lan.Change_language_MessageText("\nđã thanh toán !"), LibMedi.AccessData.Msg);
            //        mabn.Focus();
            //        return;
            //    }
            //}
            s_maql = l_maql + ",";
            if (i_loaiba == 1 && bVienphi_phongluu)
            {
                s_maql += m.get_maql_phongluu(ngayvao.Text, l_maql) + ",";
            }
            sql = "delete from " + user + ".d_suamadt ";
            if (s_maql.Trim(',') == "") sql += " where maql=" + l_maql;
            else sql += " where maql in(" + s_maql.Trim(',') + ")";
            d.execute_data(sql);
            if (solieu.SelectedIndex == 0)
            {
                load_thuoc();
            }
            else if (solieu.SelectedIndex == 1)
            {
                load_vienphi();
            }
            else
            {
                load_tiengiuong();
            }
			//ds=d.get_data("select * from "+user+".d_suamadt where maql="+l_maql+" order by substr(ngay,7,4),substr(ngay,4,2),substr(ngay,1,2),ten");
            //
            sql = "select * from " + user + ".d_suamadt ";
            if (s_maql.Trim(',') == "") sql += " where maql=" + l_maql;
            else sql += " where maql in(" + s_maql.Trim(',') + ")";
            sql += " order by substr(ngay,7,4),substr(ngay,4,2),substr(ngay,1,2),ten";
            ds = d.get_data(sql);

			objStudentCM = (System.Windows.Forms.CurrencyManager)this.BindingContext[ds.Tables[0]];
			ts.MappingName = ds.Tables[0].TableName;
			dataGrid1.DataSource = ds;
			dataGrid1.DataMember = ds.Tables[0].TableName;
			ena_but(true);
			butSua.Enabled=false;
		}

		private void load_thuoc()
		{
			DateTime dt1=d.StringToDate(ngayvv.Text.Substring(0,10)).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(ngayra.Text.Substring(0,10)).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			string mmyy="";
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(mmyy))
					{
                        xxx = user + mmyy;
                        sql = "select '" + mmyy + "' as mmyy,a.id,a.mabn,a.mavaovien,a.maql,a.idkhoa,to_char(a.ngay,'dd/mm/yyyy') as ngay,a.makp,a.madoituong,a.mabd as ma,trim(b.ten)||' '||trim(b.hamluong)||'['||trim(c.ten)||']' as ten,b.dang as dvt,a.soluong,d.doituong as doituongcu,d.doituong,b.bhyt,a.soluong*a.giamua as sotien,a.giaban,e.ten as kp,a.giamua,a.gianovat,e.ten as kpmoi, a.traituyen as traituyencu, a.traituyen, a.gia_bh ";
						sql+=" from "+xxx+".d_tienthuoc a,"+user+".d_dmbd b,"+user+".d_dmhang c,"+user+".d_doituong d,"+user+".d_duockp e ";
						sql+=" where a.mabd=b.id and b.mahang=c.id and a.madoituong=d.madoituong and a.makp=e.id";
                        if (!bKhoa_suadoituong) sql += " and a.done=0 ";
                        sql+=" and a.mabn='"+mabn.Text+"'";
                        if (l_idkhoa != 0)
                        {
                            sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + ngayvv.Text.Substring(0, 10) + "'," + stime + ") and to_date('" + ngayra.Text.Substring(0, 10) + "'," + stime + ")";
                            if (bThanhtoan_khoa) sql += " and a.idkhoa=" + l_idkhoa;
                        }
                        if (chktungay.Checked) sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + ngayvv.Text.Substring(0, 10) + "'," + stime + ") and to_date('" + ngayra.Text.Substring(0, 10) + "'," + stime + ")";
						sql+=" and a.maql="+l_maql;
						d.execute_data("insert into "+user+".d_suamadt "+sql);
						if (bVienphi_phongluu)
						{
							maql_phongluu=m.get_maql_phongluu(ngayvao.Text,l_maql);
							if (maql_phongluu!=0)
							{
                                sql = "select '" + mmyy + "' as mmyy,a.id,a.mabn,a.mavaovien,a.maql,a.idkhoa,to_char(a.ngay,'dd/mm/yyyy') as ngay,a.makp,a.madoituong,a.mabd as ma,trim(b.ten)||' '||trim(b.hamluong)||'['||trim(c.ten)||']' as ten,b.dang as dvt,a.soluong,d.doituong as doituongcu,d.doituong,b.bhyt,a.soluong*a.giamua as sotien,a.giaban,e.ten as kp,a.giamua,a.gianovat,e.ten as kpmoi, a.traituyen  as traituyencu, a.traituyen, a.gia_bh ";
								sql+=" from "+xxx+".d_tienthuoc a,"+user+".d_dmbd b,"+user+".d_dmhang c,"+user+".d_doituong d,"+user+".d_duockp e ";
								sql+=" where a.mabd=b.id and b.mahang=c.id and a.madoituong=d.madoituong and a.makp=e.id";
                                if (!bKhoa_suadoituong) sql += " and a.done=0 ";
                                sql+=" and a.mabn='"+mabn.Text+"'";
								sql+=" and a.maql="+maql_phongluu;
                                if (chktungay.Checked) sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + ngayvv.Text.Substring(0, 10) + "'," + stime + ") and to_date('" + ngayra.Text.Substring(0, 10) + "'," + stime + ")";
								d.execute_data("insert into "+user+".d_suamadt "+sql);
							}
						}
					}
				}
			}
		}

		private void load_vienphi()
		{
			DateTime dt1=d.StringToDate(ngayvv.Text.Substring(0,10));
			DateTime dt2=d.StringToDate(ngayra.Text.Substring(0,10));
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			string mmyy="";
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (m.bMmyy(mmyy))
					{
                        xxx = user + mmyy;
                        sql = "select '" + mmyy + "' as mmyy,a.id,a.mabn,a.mavaovien,a.maql,a.idkhoa,to_char(a.ngay,'dd/mm/yyyy') as ngay,0 as makp,a.madoituong,a.mavp as ma,b.ten,b.dvt,a.soluong,d.doituong as doituongcu,d.doituong,b.bhyt,a.soluong*(a.dongia+a.vattu) as sotien,0 as giaban,e.tenkp as kp,a.dongia+a.vattu as giamua,a.dongia+a.vattu as gianovat,e.tenkp as kpmoi, a.traituyen  as traituyencu, a.traituyen, a.dongia as gia_bh ";
						sql+=" from "+xxx+".v_vpkhoa a,"+user+".v_giavp b,"+user+".d_doituong d,"+user+".btdkp_bv e";
						sql+=" where a.mavp=b.id and a.madoituong=d.madoituong and a.makp=e.makp";
                        if (!bKhoa_suadoituong) sql += " and a.done=0 ";
                        sql+=" and a.mabn='"+mabn.Text+"'";
                        if (l_idkhoa != 0)
                        {
                            sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + ngayvv.Text.Substring(0, 10) + "'," + stime + ") and to_date('" + ngayra.Text.Substring(0, 10) + "'," + stime + ")";
                            if (bThanhtoan_khoa) sql += " and a.idkhoa=" + l_idkhoa;
                        }
                        if (chktungay.Checked) sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + ngayvv.Text.Substring(0, 10) + "'," + stime + ") and to_date('" + ngayra.Text.Substring(0, 10) + "'," + stime + ")";
						sql+=" and a.maql="+l_maql;
						sql+=" order by to_char(a.ngay,'yyyymmdd'),b.ten";
						d.execute_data("insert into "+user+".d_suamadt "+sql);
						if (bVienphi_phongluu)
						{
                            maql_phongluu = m.get_maql_phongluu(ngayvao.Text, l_maql);
							if (maql_phongluu!=0)
							{
                                sql = "select '" + mmyy + "' as mmyy,a.id,a.mabn,a.mavaovien,a.maql,a.idkhoa,to_char(a.ngay,'dd/mm/yyyy') as ngay,0 as makp,a.madoituong,a.mavp as ma,b.ten,b.dvt,a.soluong,d.doituong as doituongcu,d.doituong,b.bhyt,a.soluong*(a.dongia+a.vattu) as sotien,0 as giaban,e.tenkp as kp,a.dongia+a.vattu as giamua,a.dongia+a.vattu as gianovat,e.tenkp as kpmoi, a.traituyen  as traituyencu, a.traituyen, a.dongia as gia_bh ";
								sql+=" from "+xxx+".v_vpkhoa a,"+user+".v_giavp b,"+user+".d_doituong d,"+user+".btdkp_bv e";
								sql+=" where a.mavp=b.id and a.madoituong=d.madoituong and a.makp=e.makp";
                                if (!bKhoa_suadoituong) sql += " and a.done=0 ";
                                sql+=" and a.mabn='"+mabn.Text+"'";
								sql+=" and a.maql="+maql_phongluu;
                                if (chktungay.Checked) sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + ngayvv.Text.Substring(0, 10) + "'," + stime + ") and to_date('" + ngayra.Text.Substring(0, 10) + "'," + stime + ")";
								sql+=" order by to_char(a.ngay,'yyyymmdd'),b.ten";
								d.execute_data("insert into "+user+".d_suamadt "+sql);
							}
						}
						if (m.bChidinh_vienphi)
						{
                            sql = "select '" + mmyy + "' as mmyy,a.id,a.mabn,a.mavaovien,a.maql,a.idkhoa,to_char(a.ngay,'dd/mm/yyyy') as ngay,0 as makp,a.madoituong,a.mavp as ma,b.ten,b.dvt,a.soluong,d.doituong as doituongcu,d.doituong,b.bhyt,a.soluong*(a.dongia+a.vattu) as sotien,0 as giaban,e.tenkp as kp,a.dongia+a.vattu as giamua,a.dongia+a.vattu as gianovat,e.tenkp as kpmoi, a.traituyen as traituyencu, a.traituyen, a.dongia as gia_bh ";
							sql+=" from "+xxx+".v_chidinh a,"+user+".v_giavp b,"+user+".d_doituong d,"+user+".btdkp_bv e";
							sql+=" where a.mavp=b.id and a.madoituong=d.madoituong and a.makp=e.makp";
                            if (!bKhoa_suadoituong) sql += " and a.paid=0 ";
                            sql+=" and a.mabn='"+mabn.Text+"'";
                            if (l_idkhoa != 0)
                            {
                                sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + ngayvv.Text.Substring(0, 10) + "'," + stime + ") and to_date('" + ngayra.Text.Substring(0, 10) + "'," + stime + ")";
                                if (bThanhtoan_khoa) sql += " and a.idkhoa=" + l_idkhoa;
                            }
                            if (chktungay.Checked) sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + ngayvv.Text.Substring(0, 10) + "'," + stime + ") and to_date('" + ngayra.Text.Substring(0, 10) + "'," + stime + ")";
							sql+=" and a.maql="+l_maql;
							sql+=" order by to_char(a.ngay,'yyyymmdd'),b.ten";
							d.execute_data("insert into "+user+".d_suamadt "+sql);
							if (bVienphi_phongluu)
							{
								maql_phongluu=m.get_maql_phongluu(ngayvao.Text,l_maql);
								if (maql_phongluu!=0)
								{
                                    sql = "select '" + mmyy + "' as mmyy,a.id,a.mabn,a.mavaovien,a.maql,a.idkhoa,to_char(a.ngay,'dd/mm/yyyy') as ngay,0 as makp,a.madoituong,a.mavp as ma,b.ten,b.dvt,a.soluong,d.doituong as doituongcu,d.doituong,b.bhyt,a.soluong*(a.dongia+a.vattu) as sotien,0 as giaban,e.tenkp as kp,a.dongia+a.vattu as giamua,a.dongia+a.vattu as gianovat,e.tenkp as kpmoi, a.traituyen as traituyencu, a.traituyen, a.dongia as gia_bh";
									sql+=" from "+xxx+".v_chidinh a,"+user+".v_giavp b,"+user+".d_doituong d,"+user+".btdkp_bv e";
									sql+=" where a.mavp=b.id and a.madoituong=d.madoituong and a.makp=e.makp";
                                    if (!bKhoa_suadoituong) sql += " and a.paid=0 ";
                                    sql+=" and a.mabn='"+mabn.Text+"'";
									sql+=" and a.maql="+maql_phongluu;
                                    if (chktungay.Checked) sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + ngayvv.Text.Substring(0, 10) + "'," + stime + ") and to_date('" + ngayra.Text.Substring(0, 10) + "'," + stime + ")";
									sql+=" order by to_char(a.ngay,'yyyymmdd'),b.ten";
									d.execute_data("insert into "+user+".d_suamadt "+sql);
								}
							}
						}
					}
				}
			}
		}


        private void load_tiengiuong()
        {
            sql = "select '0000' as mmyy,a.id,a.mabn,a.mavaovien,a.maql,a.idkhoa,to_char(a.tungay,'dd/mm/yyyy') as ngay,0 as makp,a.madoituong,a.idgiuong as ma,b.ten,b.dvt,a.soluong,d.doituong as doituongcu,d.doituong,b.bhyt,a.soluong*(a.dongia) as sotien,0 as giaban,e.tenkp as kp,a.dongia as giamua,a.dongia as gianovat,e.tenkp as kpmoi, a.traituyen  as traituyencu, a.traituyen, a.dongia as gia_bh ";
            sql += " from " + user + ".theodoigiuong a," + user + ".v_giavp b," + user + ".d_doituong d," + user + ".btdkp_bv e";
            sql += " where a.idgiuong=b.id and a.madoituong=d.madoituong and a.makp=e.makp";
            sql += " and a.mabn='" + mabn.Text + "'";
            if (l_idkhoa != 0)
            {
                sql += " and " + m.for_ngay("a.tungay", stime) + " between to_date('" + ngayvv.Text.Substring(0, 10) + "'," + stime + ") and to_date('" + ngayra.Text.Substring(0, 10) + "'," + stime + ")";
                if (bThanhtoan_khoa) sql += " and a.idkhoa=" + l_idkhoa;
            }
            if (chktungay.Checked) sql += " and " + m.for_ngay("a.tungay", stime) + " between to_date('" + ngayvv.Text.Substring(0, 10) + "'," + stime + ") and to_date('" + ngayra.Text.Substring(0, 10) + "'," + stime + ")";
            sql += " and a.maql in (" + s_maql.Trim(',') + ")";
            sql += " order by to_char(a.tungay,'yyyymmdd'),b.ten";
            d.execute_data("insert into " + user + ".d_suamadt " + sql);
        }
		private void theo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==theo) ena_madt();
		}

		private void ena_madt()
		{
			madtcu.Enabled=theo.SelectedIndex==0;
			madtmoi.Enabled=madtcu.Enabled;
		}

		private void butTonghop_Click(object sender, System.EventArgs e)
		{
            if (mabn.Text=="" || l_maql==0) return;
			if (m.get_thvpll(ngayra.Text,l_maql,ngayvao.Text) && !bKhoa_suadoituong)
			{
				MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã chuyển số liệu xuống viện phí !"),LibMedi.AccessData.Msg);
				return;
			}
            //sql = "select * from xxx.d_tienthuoc where maql=" + l_maql + " and (done=1 or idttrv>0)  ";
            //DataSet lds = d.get_data_mmyy(sql, ngayvv.Text, ngayra.Text, true);
            //if (lds.Tables[0].Rows.Count > 0)
            //{
            //    MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã thanh toán rồi, hoặc đã thanh toán một phần, nên không tổng hợp lại được!"), LibMedi.AccessData.Msg);
            //    return;
            //}
			d.upd_laitienthuoc(mabn.Text,l_maql,ngayvv.Text,ngayra.Text,false);
			if (bVienphi_phongluu)
			{
				maql_phongluu=m.get_maql_phongluu(ngayvao.Text,l_maql);
				if (maql_phongluu!=0) d.upd_laitienthuoc(mabn.Text,maql_phongluu,ngayvv.Text,ngayra.Text,false);
			}
			MessageBox.Show(lan.Change_language_MessageText("Đã cập nhật xong !"),LibMedi.AccessData.Msg);
		}

		private void solieu_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==solieu && mabn.Text!="") butSua_Click(sender,e);
		}

        private void ngayvv_Validated(object sender, EventArgs e)
        {
            ngayvv.Text = ngayvv.Text.Trim();
            if (ngayvv.Text.Length == 6) ngayvv.Text = ngayvv.Text + DateTime.Now.Year.ToString();
            if (!m.bNgay(ngayvv.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
                ngayvv.Focus();
                return;
            }
            ngayvv.Text = m.Ktngaygio(ngayvv.Text, 10);
            if (chktungay.Checked)
            {
                d.execute_data("delete from " + user + ".d_suamadt where maql=" + l_maql);
                if (solieu.SelectedIndex == 0) load_thuoc();
                else load_vienphi();
                ds = d.get_data("select * from " + user + ".d_suamadt where maql=" + l_maql + " order by substr(ngay,7,4),substr(ngay,4,2),substr(ngay,1,2),ten");
                objStudentCM = (System.Windows.Forms.CurrencyManager)this.BindingContext[ds.Tables[0]];
                ts.MappingName = ds.Tables[0].TableName;
                dataGrid1.DataSource = ds;
                dataGrid1.DataMember = ds.Tables[0].TableName;
                ena_but(true);
            }
        }

       
        private int get_madoituong(DataTable dtdt, string sdoituong)
        {
            int imadt = 0;
            DataRow r = m.getrowbyid(dtdt, "doituong='" + sdoituong + "'");
            if (r != null) imadt = int.Parse(r["madoituong"].ToString());
            else imadt = 0;
            return imadt;
        }

        private void chktungay_CheckedChanged(object sender, EventArgs e)
        {
            ngayvv.Enabled = chktungay.Checked;
        }

        private void ngayvv_Click(object sender, EventArgs e)
        {

        }

        private void ngayra_Validated_1(object sender, EventArgs e)
        {
            if (chktungay.Checked)
            {
                d.execute_data("delete from " + user + ".d_suamadt where maql=" + l_maql);
                if (solieu.SelectedIndex == 0) load_thuoc();
                else load_vienphi();
                ds = d.get_data("select * from " + user + ".d_suamadt where maql=" + l_maql + " order by substr(ngay,7,4),substr(ngay,4,2),substr(ngay,1,2),ten");
                objStudentCM = (System.Windows.Forms.CurrencyManager)this.BindingContext[ds.Tables[0]];
                ts.MappingName = ds.Tables[0].TableName;
                dataGrid1.DataSource = ds;
                dataGrid1.DataMember = ds.Tables[0].TableName;
                ena_but(true);
            }
        }

        private void chktungay_Click(object sender, EventArgs e)
        {
            if (chktungay.Checked==false)
            {                
                d.execute_data("delete from " + user + ".d_suamadt where maql=" + l_maql);
                if (solieu.SelectedIndex == 0) load_thuoc();
                else load_vienphi();
                ds = d.get_data("select * from " + user + ".d_suamadt where maql=" + l_maql + " order by substr(ngay,7,4),substr(ngay,4,2),substr(ngay,1,2),ten");
                objStudentCM = (System.Windows.Forms.CurrencyManager)this.BindingContext[ds.Tables[0]];
                ts.MappingName = ds.Tables[0].TableName;
                dataGrid1.DataSource = ds;
                dataGrid1.DataMember = ds.Tables[0].TableName;
                ena_but(true);
            }
        }

        private void capnhat_db()
        {
            string sql1 = "";
            DataSet lds = new DataSet();
            sql1 = "select traituyencu from  " + user + ".d_suamadt where 1=2 ";
            lds = m.get_data(sql1);
            if (lds == null || lds.Tables.Count <= 0)
            {
                sql1 = "alter table " + user + ".d_suamadt add traituyencu numeric(1) default 0";
                m.execute_data(sql1);
            }
            sql1 = "select traituyen from  " + user + ".d_suamadt where 1=2 ";
            lds = m.get_data(sql1);
            if (lds == null || lds.Tables.Count <= 0)
            {
                sql1 = "alter table " + user + ".d_suamadt add traituyen numeric(1) default 0";
                m.execute_data(sql1);
            }
            sql1 = "select gia_bh from  " + user + ".d_suamadt where 1=2 ";
            lds = m.get_data(sql1);
            if (lds == null || lds.Tables.Count <= 0)
            {
                sql1 = "alter table " + user + ".d_suamadt add gia_bh numeric default 0";
                m.execute_data(sql1);
            }
        }
	}
}