using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
 
namespace Medisoft
{
	/// <summary>
	/// Summary description for frmRavien.
	/// </summary>
	public class frmSuadoituong_tu : System.Windows.Forms.Form
	{
		Language lan = new Language();
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
        private DataSet dsngay_new = new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dtgia=new DataTable();
		private DataTable dtkp=new DataTable();
		private LibMedi.AccessData m;
        private LibVienphi.AccessData v = new LibVienphi.AccessData();
        private decimal l_maql, l_idkhoa, maql_phongluu, l_mavv=0;
        private int i_loaiba = 1, i_userid = 0;
		private bool b_ndot,bVienphi_phongluu, bAdmin_hethong=false;
		private DataRow r;
		private string s_makp,sql,s_ngayvao,user,stime;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.TextBox makp;
		private System.Windows.Forms.ComboBox ngayvao;
		private System.Windows.Forms.Label label1;
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
		private MaskedBox.MaskedBox ngayvv;
		private System.Windows.Forms.Label label9;
        private ComboBox cbngayvao_new;
        private Button butchuyen;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSuadoituong_tu(LibMedi.AccessData acc,string makp,int loaiba, int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			m=acc;s_makp=makp;i_loaiba=loaiba;
            i_userid = userid;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSuadoituong_tu));
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
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.madtcu = new System.Windows.Forms.ComboBox();
            this.madtmoi = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.theo = new System.Windows.Forms.ComboBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butSua = new System.Windows.Forms.Button();
            this.ngayra = new MaskedBox.MaskedBox();
            this.ngayvv = new MaskedBox.MaskedBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbngayvao_new = new System.Windows.Forms.ComboBox();
            this.butchuyen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(131, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(320, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 22;
            this.label3.Text = "Năm sinh :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-5, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ngày vào :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(280, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Đến :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(394, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "Khoa xuất viện :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(453, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 23);
            this.label8.TabIndex = 24;
            this.label8.Text = "Địa chỉ :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn
            // 
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(55, 8);
            this.mabn.MaxLength = 10;
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(79, 21);
            this.mabn.TabIndex = 2;
            this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
            this.mabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(176, 8);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(152, 21);
            this.hoten.TabIndex = 21;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(384, 8);
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
            this.tenkp.Location = new System.Drawing.Point(530, 31);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(256, 21);
            this.tenkp.TabIndex = 8;
            // 
            // diachi
            // 
            this.diachi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(505, 8);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(281, 21);
            this.diachi.TabIndex = 25;
            // 
            // butTiep
            // 
            this.butTiep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTiep.Image = ((System.Drawing.Image)(resources.GetObject("butTiep.Image")));
            this.butTiep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTiep.Location = new System.Drawing.Point(53, 493);
            this.butTiep.Name = "butTiep";
            this.butTiep.Size = new System.Drawing.Size(70, 25);
            this.butTiep.TabIndex = 15;
            this.butTiep.Text = "     &Tiếp";
            this.butTiep.Click += new System.EventHandler(this.butTiep_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(126, 493);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 13;
            this.butLuu.Text = "       &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(271, 493);
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
            this.butExit.Location = new System.Drawing.Point(344, 493);
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
            this.makp.Location = new System.Drawing.Point(505, 31);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(23, 21);
            this.makp.TabIndex = 7;
            // 
            // ngayvao
            // 
            this.ngayvao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ngayvao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvao.Location = new System.Drawing.Point(55, 31);
            this.ngayvao.Name = "ngayvao";
            this.ngayvao.Size = new System.Drawing.Size(112, 21);
            this.ngayvao.TabIndex = 3;
            this.ngayvao.SelectedIndexChanged += new System.EventHandler(this.ngayvao_SelectedIndexChanged);
            this.ngayvao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngayvao_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "&Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(176, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 23);
            this.label11.TabIndex = 28;
            this.label11.Text = "Đối tượng :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(427, 53);
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
            this.madtcu.Size = new System.Drawing.Size(184, 21);
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
            this.madtmoi.Location = new System.Drawing.Point(505, 54);
            this.madtmoi.Name = "madtmoi";
            this.madtmoi.Size = new System.Drawing.Size(281, 21);
            this.madtmoi.TabIndex = 11;
            this.madtmoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madtmoi_KeyDown);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 23);
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
            this.theo.Location = new System.Drawing.Point(55, 54);
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
            this.dataGrid1.Size = new System.Drawing.Size(776, 428);
            this.dataGrid1.TabIndex = 34;
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(198, 493);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 12;
            this.butSua.Text = "      &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // ngayra
            // 
            this.ngayra.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayra.Location = new System.Drawing.Point(352, 31);
            this.ngayra.Mask = "##/##/####";
            this.ngayra.Name = "ngayra";
            this.ngayra.Size = new System.Drawing.Size(72, 21);
            this.ngayra.TabIndex = 5;
            this.ngayra.Text = "  /  /    ";
            this.ngayra.Validated += new System.EventHandler(this.ngayra_Validated);
            // 
            // ngayvv
            // 
            this.ngayvv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvv.Location = new System.Drawing.Point(240, 32);
            this.ngayvv.Mask = "##/##/####";
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(64, 21);
            this.ngayvv.TabIndex = 4;
            this.ngayvv.Text = "  /  /    ";
            this.ngayvv.Validated += new System.EventHandler(this.ngayvv_Validated);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(200, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 23);
            this.label9.TabIndex = 38;
            this.label9.Text = "Từ :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbngayvao_new
            // 
            this.cbngayvao_new.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbngayvao_new.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbngayvao_new.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbngayvao_new.Location = new System.Drawing.Point(618, 493);
            this.cbngayvao_new.Name = "cbngayvao_new";
            this.cbngayvao_new.Size = new System.Drawing.Size(162, 21);
            this.cbngayvao_new.TabIndex = 39;
            // 
            // butchuyen
            // 
            this.butchuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butchuyen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butchuyen.Location = new System.Drawing.Point(505, 493);
            this.butchuyen.Name = "butchuyen";
            this.butchuyen.Size = new System.Drawing.Size(107, 25);
            this.butchuyen.TabIndex = 41;
            this.butchuyen.Text = " &Chuyển sang đợt";
            this.butchuyen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butchuyen.Click += new System.EventHandler(this.butchuyen_Click);
            // 
            // frmSuadoituong_tu
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.butchuyen);
            this.Controls.Add(this.cbngayvao_new);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ngayvv);
            this.Controls.Add(this.ngayra);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.theo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.madtmoi);
            this.Controls.Add(this.madtcu);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dataGrid1);
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
            this.Name = "frmSuadoituong_tu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sửa đối tượng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSuadoituong_tu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmSuadoituong_tu_Load(object sender, System.EventArgs e)
		{
			if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = m.user; stime = "'" + m.f_ngay + "'";
			dtkp=m.get_data("select * from "+user+".btdkp_bv").Tables[0];
			theo.SelectedIndex=0;
            bAdmin_hethong = m.bAdminHethong(i_userid);
			ena_madt();
            b_ndot = m.bThanhtoan_ndot || m.bThanhtoan_khoa;
			ngayvv.Enabled=b_ndot;
			bVienphi_phongluu=m.bCapcuu_noitru;
            sql = "select 0 as loai,id,gia_th,gia_bh,gia_dv,gia_nn,vattu_th,vattu_bh,vattu_dv,vattu_nn,bhyt,to_char(ngayud,'yyyymmddhh24mi') as ngaygio,to_char(ngayud,'yyyymmdd') as ngay from " + user + ".v_giavp_luu";
			sql+=" union all ";
            sql += "select 1 as loai,id,gia_th,gia_bh,gia_dv,gia_nn,vattu_th,vattu_bh,vattu_dv,vattu_nn,bhyt,to_char(ngayud,'yyyymmddhh24mi') as ngaygio,to_char(ngayud,'yyyymmdd') as ngay from " + user + ".v_giavp";
			dtgia=m.get_data(sql).Tables[0];
            dt = m.get_data("select * from " + user + ".d_doituong order by madoituong").Tables[0];
			madtcu.DisplayMember="DOITUONG";
			madtcu.ValueMember="MADOITUONG";
			madtcu.DataSource=dt;

			madtmoi.DisplayMember="DOITUONG";
			madtmoi.ValueMember="MADOITUONG";
			load_madtmoi();
			dsngay.ReadXml("..\\..\\..\\xml\\m_ngayvao.xml");
            //
            dsngay.Tables[0].Columns.Add("mabs");
            dsngay.Tables[0].Columns.Add("tenbs");
            dsngay.Tables[0].Columns.Add("cholam");
            dsngay.Tables[0].Columns.Add("traituyen", typeof(decimal));
            //
			ngayvao.DisplayMember="NGAYVAO";
			ngayvao.ValueMember="NGAYVAO";
			ngayvao.DataSource=dsngay.Tables[0];
            dsngay_new = dsngay.Copy();
            cbngayvao_new.DisplayMember = "NGAYVAO";
            cbngayvao_new.ValueMember = "NGAYVAO";
            cbngayvao_new.DataSource = dsngay_new.Tables[0];
			ds.ReadXml("..\\..\\..\\xml\\m_suamadt.xml");
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

            visible_chuyendot(false);

		}

		private void mabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void mabn_Validated(object sender, System.EventArgs e)
		{
			int i=0;decimal o_maql=0;
            l_mavv = 0;
            hoten.Text = ""; l_maql = 0; l_idkhoa = 0; dsngay.Clear(); dsngay_new.Clear();
			if (mabn.Text=="" || mabn.Text.Trim().Length<3) return;
			if (mabn.Text.Trim().Length!=8) mabn.Text=mabn.Text.Substring(0,2)+mabn.Text.Substring(2).PadLeft(6,'0');
            if (b_ndot)
            {
                sql = "select c.hoten,c.namsinh,c.phai,c.sonha,c.thon,a.maql,a.id,a.giuong,";
                sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,";
                sql += "case when b.ngay is null then to_char(now(),'dd/mm/yyyy hh24:mi') else to_char(b.ngay,'dd/mm/yyyy hh24:mi') end as ngayra,";
                sql += "a.makp,d.tenkp,b.chandoan,b.maicd,e.tentt,f.tenquan,g.tenpxa,coalesce(b.mabs,a.mabs) as mabs, h.mavaovien ";
                sql += " from " + user + ".nhapkhoa a left join " + user + ".xuatkhoa b on a.id=b.id ";
                sql += " inner join " + user + ".btdbn c on a.mabn=c.mabn ";
                sql += " inner join " + user + ".btdkp_bv d on a.makp=d.makp";
                sql += " inner join " + user + ".btdtt e on c.matt=e.matt";
                sql += " inner join " + user + ".btdquan f on c.maqu=f.maqu";
                sql += " inner join " + user + ".btdpxa g on c.maphuongxa=g.maphuongxa ";
                sql += " inner join " + user + ".benhandt h on a.maql=h.maql ";
                sql += " where a.mabn='" + mabn.Text + "' and h.loaiba=" + i_loaiba;
                if (s_makp != "")
                {
                    string s = s_makp.Replace(",", "','");
                    sql += " and a.makp in ('" + s.Substring(0, s.Length - 3) + "')";
                }
                sql += " order by a.id desc";
            }
            else
            {
                sql = "select c.hoten,c.namsinh,c.phai,c.sonha,c.thon,a.maql,0 as id,' ' as giuong,";
                sql+="to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,case when b.ngay is null then to_char(now(),'dd/mm/yyyy hh24:mi') else to_char(b.ngay,'dd/mm/yyyy hh24:mi') end as ngayra,";
                sql+="coalesce(b.makp,a.makp) as makp,coalesce(h.tenkp,d.tenkp) as tenkp,coalesce(b.chandoan,' ') as chandoan,";
                sql+="coalesce(b.maicd,' ') as maicd,coalesce(e.tentt,' ') as tentt,coalesce(f.tenquan,' ') as tenquan,";
                sql+="coalesce(g.tenpxa,' ') as tenpxa,coalesce(b.mabs,a.mabs) as mabs, a.mavaovien ";
                sql+=" from "+user+".benhandt a left join "+user+".xuatvien b on a.maql=b.maql";
                sql+=" inner join "+user+".btdbn c on a.mabn=c.mabn";
                sql+=" left join "+user+".btdkp_bv d on b.makp=d.makp";
                sql+=" inner join "+user+".btdtt e on c.matt=e.matt";
                sql+=" inner join "+user+".btdquan f on c.maqu=f.maqu";
                sql+=" inner join "+user+".btdpxa g on c.maphuongxa=g.maphuongxa";
                sql+=" inner join "+user+".btdkp_bv h on a.makp=h.makp";
                sql+=" where a.mabn='" + mabn.Text + "' and a.loaiba=" + i_loaiba + " order by a.maql desc";
            }
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				if (i==0)
				{
					hoten.Text=r["hoten"].ToString();
					namsinh.Text=r["namsinh"].ToString();
					s_ngayvao=r["ngayvao"].ToString();
					ngayra.Text=r["ngayra"].ToString().Substring(0,10);
					diachi.Text=r["sonha"].ToString().Trim()+" "+r["thon"].ToString().Trim();
					makp.Text=r["makp"].ToString();
					tenkp.Text=r["tenkp"].ToString();
					l_maql=decimal.Parse(r["maql"].ToString());
					l_idkhoa=decimal.Parse(r["id"].ToString());
                    l_mavv = decimal.Parse(r["mavaovien"].ToString());
				}
				o_maql=decimal.Parse(r["maql"].ToString());
				m.updrec_ravien(dsngay,mabn.Text,l_mavv,o_maql,decimal.Parse(r["id"].ToString()),
					hoten.Text,r["namsinh"].ToString(),(r["phai"].ToString()=="0")?"Nam":"Nữ",r["sonha"].ToString().Trim()+" "+r["thon"].ToString().Trim()+", "+r["tenpxa"].ToString().Trim()+", "+r["tenquan"].ToString().Trim()+", "+r["tentt"].ToString().Trim(),
					0,"","","","","",r["giuong"].ToString(),r["makp"].ToString(),r["tenkp"].ToString(),r["ngayvao"].ToString(),r["ngayra"].ToString(),r["chandoan"].ToString(),r["maicd"].ToString(),"",0,0,0,"",r["mabs"].ToString(),"","",0);
				i++;
			}
            dsngay_new = new DataSet();
            dsngay_new = dsngay.Copy();
            cbngayvao_new.DataSource = dsngay_new.Tables[0];
            visible_chuyendot(bAdmin_hethong && dsngay_new.Tables[0].Rows.Count > 1);
			if (l_maql==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Người bệnh này chưa hoàn tất thủ tục !"),LibMedi.AccessData.Msg);
				mabn.Focus();
			}
			else ngayvao.SelectedValue=s_ngayvao;
			if (ngayvao.SelectedIndex!=-1) ngayvv.Text=ngayvao.Text.Substring(0,10);
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
			ngayra.Text=m.Ngaygio_hienhanh.Substring(0,10);
			tenkp.Text="";
			makp.Text="";
			diachi.Text="";
			l_maql=0;l_idkhoa=0;
			ena_but(true);
			mabn.Focus();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (ngayra.Text=="")
			{
				ngayra.Focus();
				return;
			}
            string s_ngay = m.ngayhienhanh_server;
            if (m.get_thvpll(s_ngay, l_maql, ngayvao.Text))
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
			if (theo.SelectedIndex==0) //tonghop
				foreach(DataRow r1 in ds.Tables[0].Select("madoituong="+int.Parse(madtcu.SelectedValue.ToString())))
					m.execute_data("update "+user+r1["mmyy"].ToString().PadLeft(4,'0')+".v_tamung set madoituong="+int.Parse(madtmoi.SelectedValue.ToString())+" where id="+decimal.Parse(r1["id"].ToString()));
			else
				foreach(DataRow r1 in ds.Tables[0].Select("doituongcu<>doituong"))
				{
					r=m.getrowbyid(dt,"doituong='"+r1["doituong"].ToString()+"'");
					if (r!=null)
						m.execute_data("update "+user+r1["mmyy"].ToString().PadLeft(4,'0')+".v_tamung set madoituong="+int.Parse(r["madoituong"].ToString())+" where id="+decimal.Parse(r1["id"].ToString()));
				}
			ena_but(false);
			butSua.Enabled=true;
			m.upd_dasuamadt(l_maql,l_idkhoa);
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_but(false);
			butSua.Enabled=true;
		}

		private void butExit_Click(object sender, System.EventArgs e)
		{
			m.close();
			System.GC.Collect();
			this.Close();
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

			ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM .GetItemProperties()["sotien"]));
			ts.GridColumnStyles[1].MappingName = "sotien";
			ts.GridColumnStyles[1].HeaderText = "";
			ts.GridColumnStyles[1].Width=0;
			ts.ReadOnly=true;
			ts.GridColumnStyles[1].Alignment = HorizontalAlignment.Left;
			ts.GridColumnStyles[1].NullText = string.Empty;

			ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM .GetItemProperties()["dvt"]));
			ts.GridColumnStyles[2].MappingName = "dvt";
			ts.GridColumnStyles[2].HeaderText = "";
			ts.GridColumnStyles[2].Width=0;
			ts.ReadOnly=true;
			ts.GridColumnStyles[2].Alignment = HorizontalAlignment.Left;
			ts.GridColumnStyles[2].NullText = string.Empty;

			ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM .GetItemProperties()["ten"]));
			ts.GridColumnStyles[3].MappingName = "ten";
			ts.GridColumnStyles[3].HeaderText = "Số tiền";
			ts.GridColumnStyles[3].Width=100;
			ts.ReadOnly=true;
			ts.GridColumnStyles[3].Alignment = HorizontalAlignment.Right;
			ts.GridColumnStyles[3].NullText = string.Empty;

			ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM .GetItemProperties()["doituongcu"]));
			ts.GridColumnStyles[4].MappingName = "doituongcu";
			ts.GridColumnStyles[4].HeaderText = "Đối tượng củ";
			ts.GridColumnStyles[4].Width=120;
			ts.ReadOnly=true;
			ts.GridColumnStyles[4].Alignment = HorizontalAlignment.Left;
			ts.GridColumnStyles[4].NullText = string.Empty;

			ts.GridColumnStyles.Add(new DataGridComboBoxColumn(dt,1,1));
			ts.GridColumnStyles[5].MappingName = "doituong";
			ts.GridColumnStyles[5].HeaderText = "Đối tượng mới";
			ts.GridColumnStyles[5].Width=200;
			ts.GridColumnStyles[5].Alignment = HorizontalAlignment.Left;
			ts.GridColumnStyles[5].NullText = string.Empty;			
			dataGrid1.CaptionText = string.Empty;

			ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM .GetItemProperties()["kp"]));
			ts.GridColumnStyles[6].MappingName = "kp";
			ts.GridColumnStyles[6].HeaderText = "Khoa";
			ts.GridColumnStyles[6].Width=235;
			ts.ReadOnly=true;
			ts.GridColumnStyles[6].Alignment = HorizontalAlignment.Left;
			ts.GridColumnStyles[6].NullText = string.Empty;

            ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM.GetItemProperties()["ID"]));
            ts.GridColumnStyles[7].MappingName = "id";
            ts.GridColumnStyles[7].HeaderText = "ID";
            ts.GridColumnStyles[7].Width = 100;
            ts.ReadOnly = true;
            ts.GridColumnStyles[7].Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles[7].NullText = string.Empty;

			dataGrid1.DataSource = ds;
			dataGrid1.DataMember = ds.Tables[0].TableName;
			dataGrid1.TableStyles.Add(ts);
		}
	
		private void ngayvao_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==ngayvao)
			{
				if (ngayvao.Items.Count>0)
				{
					ngayra.Text=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ngayra"].ToString().Substring(0,10);
					makp.Text=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["makp"].ToString();
					tenkp.Text=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["tenkp"].ToString();
					l_maql=decimal.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString());
					l_idkhoa=decimal.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["idkhoa"].ToString());
					ngayvv.Text=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ngayvao"].ToString().Substring(0,10);
				}
			}
		}

		private void ngayra_Validated(object sender, System.EventArgs e)
		{
			if (ngayra.Text.Trim().Length!=10) return;
			ngayra.Text=ngayra.Text.Trim();
			if (ngayra.Text.Length == 6) ngayra.Text = ngayra.Text + DateTime.Now.Year.ToString();
			if (ngayra.Text.Length<10)
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
			ngayra.Text=m.Ktngaygio(ngayra.Text,10);
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
			if (ngayra.Text.Trim().Length!=10)
			{
				ngayra.Focus();
				return;
			}
            string s_ngay = m.ngayhienhanh_server;
            //if (m.get_thvpll(ngayra.Text, l_maql, ngayvao.Text))
            //{
            //    MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã chuyển số liệu xuống viện phí !"), LibMedi.AccessData.Msg);
            //    return;
            //}
            //if (v.get_done_thvp(s_ngay, mabn.Text, l_maql, l_idkhoa, ngayvao.Text,i_loaiba==4))
            //{
            //    MessageBox.Show(lan.Change_language_MessageText("Người bệnh \n") + hoten.Text + "\n" + ngayvao.Text + lan.Change_language_MessageText("\nđã thanh toán !"), LibMedi.AccessData.Msg);
            //    mabn.Focus();
            //    return;
            //}
			m.execute_data("delete from "+user+".d_suamadt");
			load_tamung();
			ds=m.get_data("select * from "+user+".d_suamadt order by substr(ngay,7,4),substr(ngay,4,2),substr(ngay,1,2),ten");
			objStudentCM = (System.Windows.Forms.CurrencyManager)this.BindingContext[ds.Tables[0]];
			ts.MappingName = ds.Tables[0].TableName;
			dataGrid1.DataSource = ds;
			dataGrid1.DataMember = ds.Tables[0].TableName;
			ena_but(true);
			butSua.Enabled=false;
		}

		private void load_tamung()
		{
            if (ngayvv.Text.Trim().Length < 10) return;
			DateTime dt1=m.StringToDate(ngayvv.Text.Substring(0,10));
			DateTime dt2=m.StringToDate(ngayra.Text.Substring(0,10));
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
						sql="select '"+mmyy+"' as mmyy,a.id,a.mabn,a.mavaovien,a.maql,a.idkhoa,to_char(a.ngay,'dd/mm/yyyy') as ngay,0 as makp,a.madoituong,to_char(a.sotien,'999,999,999,999') as ten,'' as dvt,a.sotien as soluong,d.doituong as doituongcu,d.doituong,0 as bhyt,a.sotien,0 as giaban,e.tenkp as kp,a.sotien as giamua ";
						sql+=" from "+user+mmyy+".v_tamung a,"+user+".d_doituong d,"+user+".btdkp_bv e";
						sql+=" where a.madoituong=d.madoituong and a.makp=e.makp";
						sql+=" and a.done=0 and a.mabn='"+mabn.Text+"'";					
						if (l_idkhoa!=0) 
						{
							if (b_ndot) sql+=" and a.idkhoa="+l_idkhoa;
                            sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + ngayvv.Text.Substring(0, 10) + "'," + stime + ") and to_date('" + ngayra.Text.Substring(0, 10) + "'," + stime + ")";
						}
						sql+=" and a.maql="+l_maql;
						sql+=" order by to_char(a.ngay,'yyyymmdd')";
                        m.execute_data("insert into " + user + ".d_suamadt (mmyy,id,mabn,maql,idkhoa,ngay,makp,madoituong,ten,dvt,soluong,doituongcu,doituong,bhyt,sotien,giaban,kp,giamua) " + sql);
						if (bVienphi_phongluu)
						{
                            maql_phongluu = m.get_maql_phongluu(ngayvao.Text, l_maql);
							if (maql_phongluu!=0)
							{
								sql="select '"+mmyy+"' as mmyy,a.id,a.mabn,a.mavaovien,a.maql,a.idkhoa,to_char(a.ngay,'dd/mm/yyyy') as ngay,0 as makp,a.madoituong,to_char(a.sotien,'999,999,999,999') as ten,'' as dvt,a.sotien as soluong,d.doituong as doituongcu,d.doituong,0 as bhyt,a.sotien,0 as giaban,e.tenkp as kp,a.sotien as giamua ";
								sql+=" from "+user+mmyy+".v_tamung a,"+user+".d_doituong d,"+user+".btdkp_bv e";
								sql+=" where a.madoituong=d.madoituong and a.makp=e.makp";
								sql+=" and a.done=0 and a.mabn='"+mabn.Text+"'";
								sql+=" and a.maql="+maql_phongluu;
								sql+=" order by to_char(a.ngay,'yyyymmdd')";
                                m.execute_data("insert into " + user + ".d_suamadt (mmyy,id,mabn,maql,idkhoa,ngay,makp,madoituong,ten,dvt,soluong,doituongcu,doituong,bhyt,sotien,giaban,kp,giamua) " + sql);
							}
						}
					}
				}
			}
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

		private void ngayvv_Validated(object sender, System.EventArgs e)
		{
			if (ngayvv.Text=="")
			{
				ngayvv.Focus();
				return;
			}
			ngayvv.Text=ngayvv.Text.Trim();
			if (ngayvv.Text.Length == 6) ngayvv.Text = ngayvv.Text + DateTime.Now.Year.ToString();
			if (ngayvv.Text.Length<10)
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập ngày !"),LibMedi.AccessData.Msg);
				ngayvv.Focus();
				return;
			}
			if (!m.bNgay(ngayvv.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
				ngayvv.Focus();
				return;
			}
			ngayvv.Text=m.Ktngaygio(ngayvv.Text,10);		
		}

        private void visible_chuyendot(bool bln)
        {
            butchuyen.Visible = bln;
            cbngayvao_new.Visible = bln;
        }

        private void butchuyen_Click(object sender, EventArgs e)
        {
            if (bAdmin_hethong)
            {
                if (ngayvao.SelectedIndex != cbngayvao_new.SelectedIndex) f_chuyen_dottamung();
                else
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đề nghị chọn đợt cần chuyển sang."), lan.Change_language_MessageText("Chuyển tạm ứng"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbngayvao_new.Focus();
                }
            }
        }
        private void f_chuyen_dottamung()
        {
            decimal l_mavv_new = decimal.Parse(dsngay_new.Tables[0].Rows[cbngayvao_new.SelectedIndex]["mavaovien"].ToString());
            decimal l_maql_new = decimal.Parse(dsngay_new.Tables[0].Rows[cbngayvao_new.SelectedIndex]["maql"].ToString());
            //decimal l_idkhoa_new = decimal.Parse(dsngay_new.Tables[0].Rows[cbngayvao_new.SelectedIndex]["idkhoa"].ToString().Substring(0, 10));
            decimal l_idtu = decimal.Parse(dataGrid1[dataGrid1.CurrentRowIndex, 7].ToString().Trim());
            sql = " update xxx.v_tamung set maql=" + l_maql_new + ", mavaovien=" + l_mavv_new;// +", idkhoa=" + l_idkhoa_new;
            sql += " where id="+l_idtu+" and done=0 ";//maql=" + l_maql + " and mavaovien=" + l_mavv + " and idkhoa=" + l_idkhoa_new;
            m.execute_data_mmyy(sql, cbngayvao_new.Text.Substring(0, 10), ngayra.Text.Substring(0, 10), true); 
        }
	}
}
