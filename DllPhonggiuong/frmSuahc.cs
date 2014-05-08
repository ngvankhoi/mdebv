using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;


namespace DllPhonggiuong
{
	public class frmSuahc : System.Windows.Forms.Form
	{
		Language lan = new Language();
		private LibMedi.AccessData m;
		private string s_userid,s_mabn,s_msg;
		public string m_mabn;
		private int i_userid;
		private bool add_soltru;
		private DataTable dtba=new DataTable();
		private DataTable dt=new DataTable();
		private DataTable dtgia=new DataTable();
		private DataTable dtkp=new DataTable();
		private DataTable dtkh=new DataTable();
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
		private System.Windows.Forms.Button butTiep;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butKetthuc;
		private int iTreem6,iTreem15;
		private bool b_Hoten=false;
		private System.ComponentModel.IContainer components=null;
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
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox soluutru;
		private MaskedBox.MaskedBox ngaysinh;
		public frmSuahc(LibMedi.AccessData acc,string hoten,int userid, bool add_soluutru,string mabn)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			m=acc;
			s_userid=hoten;
			i_userid=userid;
			add_soltru=add_soluutru;m_mabn=mabn;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmSuahc));
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
			this.ngaysinh = new MaskedBox.MaskedBox();
			this.label1 = new System.Windows.Forms.Label();
			this.soluutru = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label3.Location = new System.Drawing.Point(0, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "&Mã BN :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label4.Location = new System.Drawing.Point(128, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 23);
			this.label4.TabIndex = 10;
			this.label4.Text = "Họ tên :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label5.Location = new System.Drawing.Point(319, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 23);
			this.label5.TabIndex = 12;
			this.label5.Text = "Sinh ngày :";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mabn2
			// 
			this.mabn2.BackColor = System.Drawing.SystemColors.HighlightText;
			this.mabn2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mabn2.Location = new System.Drawing.Point(64, 16);
			this.mabn2.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
			this.mabn2.MaxLength = 2;
			this.mabn2.Name = "mabn2";
			this.mabn2.Size = new System.Drawing.Size(22, 21);
			this.mabn2.TabIndex = 1;
			this.mabn2.Text = "";
			this.mabn2.Validated += new System.EventHandler(this.mabn2_Validated);
			// 
			// mabn3
			// 
			this.mabn3.BackColor = System.Drawing.SystemColors.HighlightText;
			this.mabn3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.mabn3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mabn3.Location = new System.Drawing.Point(88, 16);
			this.mabn3.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
			this.mabn3.MaxLength = 6;
			this.mabn3.Name = "mabn3";
			this.mabn3.Size = new System.Drawing.Size(45, 21);
			this.mabn3.TabIndex = 2;
			this.mabn3.Text = "";
			this.mabn3.Validated += new System.EventHandler(this.mabn3_Validated);
			// 
			// label6
			// 
			this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label6.Location = new System.Drawing.Point(439, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 23);
			this.label6.TabIndex = 14;
			this.label6.Text = "Năm sinh :";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// namsinh
			// 
			this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.namsinh.Location = new System.Drawing.Point(503, 16);
			this.namsinh.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
			this.namsinh.MaxLength = 4;
			this.namsinh.Name = "namsinh";
			this.namsinh.Size = new System.Drawing.Size(34, 21);
			this.namsinh.TabIndex = 5;
			this.namsinh.Text = "";
			this.namsinh.Validated += new System.EventHandler(this.namsinh_Validated);
			// 
			// label7
			// 
			this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label7.Location = new System.Drawing.Point(535, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(32, 23);
			this.label7.TabIndex = 16;
			this.label7.Text = "Tuổi :";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// loaituoi
			// 
			this.loaituoi.BackColor = System.Drawing.SystemColors.HighlightText;
			this.loaituoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.loaituoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.loaituoi.Items.AddRange(new object[] {
														  "Tuổi",
														  "Tháng",
														  "Ngày",
														  "Giờ"});
			this.loaituoi.Location = new System.Drawing.Point(596, 15);
			this.loaituoi.Name = "loaituoi";
			this.loaituoi.Size = new System.Drawing.Size(76, 21);
			this.loaituoi.TabIndex = 7;
			this.loaituoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loaituoi_KeyDown);
			// 
			// tuoi
			// 
			this.tuoi.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tuoi.Location = new System.Drawing.Point(567, 16);
			this.tuoi.MaxLength = 3;
			this.tuoi.Name = "tuoi";
			this.tuoi.Size = new System.Drawing.Size(28, 21);
			this.tuoi.TabIndex = 6;
			this.tuoi.Text = "";
			this.tuoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tuoi_KeyDown);
			this.tuoi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tuoi_KeyPress);
			this.tuoi.Validated += new System.EventHandler(this.tuoi_Validated);
			// 
			// hoten
			// 
			this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
			this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.hoten.Location = new System.Drawing.Point(176, 16);
			this.hoten.Name = "hoten";
			this.hoten.Size = new System.Drawing.Size(144, 21);
			this.hoten.TabIndex = 3;
			this.hoten.Text = "";
			this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
			this.hoten.Validated += new System.EventHandler(this.hoten_Validated);
			// 
			// butTiep
			// 
			this.butTiep.BackColor = System.Drawing.SystemColors.Control;
			this.butTiep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butTiep.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.butTiep.Image = ((System.Drawing.Bitmap)(resources.GetObject("butTiep.Image")));
			this.butTiep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butTiep.Location = new System.Drawing.Point(200, 168);
			this.butTiep.Name = "butTiep";
			this.butTiep.Size = new System.Drawing.Size(65, 28);
			this.butTiep.TabIndex = 30;
			this.butTiep.Text = "     &Tiếp";
			this.butTiep.Click += new System.EventHandler(this.butTiep_Click);
			// 
			// butLuu
			// 
			this.butLuu.BackColor = System.Drawing.SystemColors.Control;
			this.butLuu.Enabled = false;
			this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butLuu.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.butLuu.Image = ((System.Drawing.Bitmap)(resources.GetObject("butLuu.Image")));
			this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLuu.Location = new System.Drawing.Point(268, 168);
			this.butLuu.Name = "butLuu";
			this.butLuu.Size = new System.Drawing.Size(65, 28);
			this.butLuu.TabIndex = 28;
			this.butLuu.Text = "      &Lưu";
			this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
			// 
			// butBoqua
			// 
			this.butBoqua.BackColor = System.Drawing.SystemColors.Control;
			this.butBoqua.Enabled = false;
			this.butBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butBoqua.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.butBoqua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butBoqua.Image")));
			this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butBoqua.Location = new System.Drawing.Point(336, 168);
			this.butBoqua.Name = "butBoqua";
			this.butBoqua.Size = new System.Drawing.Size(67, 28);
			this.butBoqua.TabIndex = 29;
			this.butBoqua.Text = "Bỏ qua";
			this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
			// 
			// butKetthuc
			// 
			this.butKetthuc.BackColor = System.Drawing.SystemColors.Control;
			this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butKetthuc.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.butKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("butKetthuc.Image")));
			this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butKetthuc.Location = new System.Drawing.Point(406, 168);
			this.butKetthuc.Name = "butKetthuc";
			this.butKetthuc.Size = new System.Drawing.Size(74, 28);
			this.butKetthuc.TabIndex = 31;
			this.butKetthuc.Text = "Kết thúc";
			this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
			// 
			// tennuoc
			// 
			this.tennuoc.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tennuoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tennuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tennuoc.Location = new System.Drawing.Point(593, 38);
			this.tennuoc.Name = "tennuoc";
			this.tennuoc.Size = new System.Drawing.Size(79, 21);
			this.tennuoc.TabIndex = 14;
			this.tennuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennuoc_KeyDown);
			this.tennuoc.SelectedIndexChanged += new System.EventHandler(this.tennuoc_SelectedIndexChanged);
			// 
			// manuoc
			// 
			this.manuoc.BackColor = System.Drawing.SystemColors.HighlightText;
			this.manuoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.manuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.manuoc.Location = new System.Drawing.Point(567, 38);
			this.manuoc.Name = "manuoc";
			this.manuoc.Size = new System.Drawing.Size(24, 21);
			this.manuoc.TabIndex = 13;
			this.manuoc.Text = "";
			this.manuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manuoc_KeyDown);
			this.manuoc.Validated += new System.EventHandler(this.manuoc_Validated);
			// 
			// lmanuoc
			// 
			this.lmanuoc.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lmanuoc.Location = new System.Drawing.Point(503, 40);
			this.lmanuoc.Name = "lmanuoc";
			this.lmanuoc.Size = new System.Drawing.Size(64, 23);
			this.lmanuoc.TabIndex = 65;
			this.lmanuoc.Text = "Quốc tịch :";
			this.lmanuoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// sonha
			// 
			this.sonha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.sonha.Location = new System.Drawing.Point(63, 61);
			this.sonha.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.sonha.MaxLength = 10;
			this.sonha.Name = "sonha";
			this.sonha.Size = new System.Drawing.Size(81, 21);
			this.sonha.TabIndex = 15;
			this.sonha.Text = "";
			// 
			// tendantoc
			// 
			this.tendantoc.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tendantoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tendantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tendantoc.Location = new System.Drawing.Point(442, 38);
			this.tendantoc.Name = "tendantoc";
			this.tendantoc.Size = new System.Drawing.Size(65, 21);
			this.tendantoc.TabIndex = 12;
			this.tendantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendantoc_KeyDown);
			this.tendantoc.SelectedIndexChanged += new System.EventHandler(this.tendantoc_SelectedIndexChanged);
			// 
			// tentqx
			// 
			this.tentqx.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tentqx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tentqx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tentqx.Location = new System.Drawing.Point(113, 85);
			this.tentqx.Name = "tentqx";
			this.tentqx.Size = new System.Drawing.Size(279, 21);
			this.tentqx.TabIndex = 18;
			this.tentqx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentqx_KeyDown);
			this.tentqx.SelectedIndexChanged += new System.EventHandler(this.tentqx_SelectedIndexChanged);
			// 
			// cholam
			// 
			this.cholam.BackColor = System.Drawing.SystemColors.HighlightText;
			this.cholam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cholam.Location = new System.Drawing.Point(63, 131);
			this.cholam.Name = "cholam";
			this.cholam.Size = new System.Drawing.Size(457, 21);
			this.cholam.TabIndex = 27;
			this.cholam.Text = "";
			this.cholam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cholam_KeyDown);
			this.cholam.Validated += new System.EventHandler(this.cholam_Validated);
			// 
			// thon
			// 
			this.thon.BackColor = System.Drawing.SystemColors.HighlightText;
			this.thon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.thon.Location = new System.Drawing.Point(208, 61);
			this.thon.Name = "thon";
			this.thon.Size = new System.Drawing.Size(464, 21);
			this.thon.TabIndex = 16;
			this.thon.Text = "";
			this.thon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thon_KeyDown);
			this.thon.Validated += new System.EventHandler(this.thon_Validated);
			// 
			// mapxa2
			// 
			this.mapxa2.BackColor = System.Drawing.SystemColors.HighlightText;
			this.mapxa2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mapxa2.Location = new System.Drawing.Point(488, 108);
			this.mapxa2.Name = "mapxa2";
			this.mapxa2.Size = new System.Drawing.Size(23, 21);
			this.mapxa2.TabIndex = 25;
			this.mapxa2.Text = "";
			this.mapxa2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mapxa2_KeyDown);
			this.mapxa2.Validated += new System.EventHandler(this.mapxa2_Validated);
			// 
			// maqu2
			// 
			this.maqu2.BackColor = System.Drawing.SystemColors.HighlightText;
			this.maqu2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.maqu2.Location = new System.Drawing.Point(92, 108);
			this.maqu2.Name = "maqu2";
			this.maqu2.Size = new System.Drawing.Size(23, 21);
			this.maqu2.TabIndex = 22;
			this.maqu2.Text = "";
			this.maqu2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maqu2_KeyDown);
			this.maqu2.Validated += new System.EventHandler(this.maqu2_Validated);
			// 
			// matt
			// 
			this.matt.BackColor = System.Drawing.SystemColors.HighlightText;
			this.matt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.matt.Location = new System.Drawing.Point(448, 85);
			this.matt.MaxLength = 3;
			this.matt.Name = "matt";
			this.matt.Size = new System.Drawing.Size(27, 21);
			this.matt.TabIndex = 19;
			this.matt.Text = "";
			this.matt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matt_KeyDown);
			this.matt.Validated += new System.EventHandler(this.matt_Validated);
			// 
			// tqx
			// 
			this.tqx.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tqx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tqx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tqx.Location = new System.Drawing.Point(63, 85);
			this.tqx.Name = "tqx";
			this.tqx.Size = new System.Drawing.Size(48, 21);
			this.tqx.TabIndex = 17;
			this.tqx.Text = "";
			this.tqx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tqx_KeyDown);
			// 
			// madantoc
			// 
			this.madantoc.BackColor = System.Drawing.SystemColors.HighlightText;
			this.madantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.madantoc.Location = new System.Drawing.Point(416, 38);
			this.madantoc.Name = "madantoc";
			this.madantoc.Size = new System.Drawing.Size(24, 21);
			this.madantoc.TabIndex = 11;
			this.madantoc.Text = "";
			this.madantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madantoc_KeyDown);
			this.madantoc.Validated += new System.EventHandler(this.madantoc_Validated);
			// 
			// mann
			// 
			this.mann.BackColor = System.Drawing.SystemColors.HighlightText;
			this.mann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mann.Location = new System.Drawing.Point(184, 38);
			this.mann.Name = "mann";
			this.mann.Size = new System.Drawing.Size(22, 21);
			this.mann.TabIndex = 9;
			this.mann.Text = "";
			this.mann.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mann_KeyDown);
			this.mann.Validated += new System.EventHandler(this.mann_Validated);
			// 
			// tennn
			// 
			this.tennn.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tennn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tennn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tennn.Location = new System.Drawing.Point(208, 38);
			this.tennn.Name = "tennn";
			this.tennn.Size = new System.Drawing.Size(159, 21);
			this.tennn.TabIndex = 10;
			this.tennn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennn_KeyDown);
			this.tennn.SelectedIndexChanged += new System.EventHandler(this.tennn_SelectedIndexChanged);
			// 
			// tenquan
			// 
			this.tenquan.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tenquan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tenquan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tenquan.Location = new System.Drawing.Point(117, 108);
			this.tenquan.Name = "tenquan";
			this.tenquan.Size = new System.Drawing.Size(251, 21);
			this.tenquan.TabIndex = 23;
			this.tenquan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenquan_KeyDown);
			this.tenquan.SelectedIndexChanged += new System.EventHandler(this.tenquan_SelectedIndexChanged);
			// 
			// tentinh
			// 
			this.tentinh.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tentinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tentinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tentinh.Location = new System.Drawing.Point(476, 85);
			this.tentinh.Name = "tentinh";
			this.tentinh.Size = new System.Drawing.Size(196, 21);
			this.tentinh.TabIndex = 20;
			this.tentinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentinh_KeyDown);
			this.tentinh.SelectedIndexChanged += new System.EventHandler(this.tentinh_SelectedIndexChanged);
			// 
			// tenpxa
			// 
			this.tenpxa.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tenpxa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tenpxa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tenpxa.Location = new System.Drawing.Point(512, 108);
			this.tenpxa.Name = "tenpxa";
			this.tenpxa.Size = new System.Drawing.Size(160, 21);
			this.tenpxa.TabIndex = 26;
			this.tenpxa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenpxa_KeyDown);
			this.tenpxa.SelectedIndexChanged += new System.EventHandler(this.tenpxa_SelectedIndexChanged);
			// 
			// mapxa1
			// 
			this.mapxa1.BackColor = System.Drawing.SystemColors.HighlightText;
			this.mapxa1.Enabled = false;
			this.mapxa1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mapxa1.Location = new System.Drawing.Point(448, 108);
			this.mapxa1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.mapxa1.MaxLength = 5;
			this.mapxa1.Name = "mapxa1";
			this.mapxa1.Size = new System.Drawing.Size(38, 21);
			this.mapxa1.TabIndex = 24;
			this.mapxa1.Text = "";
			// 
			// lmaphuongxa
			// 
			this.lmaphuongxa.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lmaphuongxa.Location = new System.Drawing.Point(376, 108);
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
			this.maqu1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.maqu1.Location = new System.Drawing.Point(63, 108);
			this.maqu1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.maqu1.MaxLength = 3;
			this.maqu1.Name = "maqu1";
			this.maqu1.Size = new System.Drawing.Size(27, 21);
			this.maqu1.TabIndex = 21;
			this.maqu1.Text = "";
			// 
			// lmaqu
			// 
			this.lmaqu.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lmaqu.Location = new System.Drawing.Point(-16, 108);
			this.lmaqu.Name = "lmaqu";
			this.lmaqu.Size = new System.Drawing.Size(80, 23);
			this.lmaqu.TabIndex = 76;
			this.lmaqu.Text = "Quận/H :";
			this.lmaqu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lmatt
			// 
			this.lmatt.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lmatt.Location = new System.Drawing.Point(392, 84);
			this.lmatt.Name = "lmatt";
			this.lmatt.Size = new System.Drawing.Size(56, 23);
			this.lmatt.TabIndex = 75;
			this.lmatt.Text = "Tỉnh/TP :";
			this.lmatt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ltqx
			// 
			this.ltqx.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.ltqx.Location = new System.Drawing.Point(-8, 84);
			this.ltqx.Name = "ltqx";
			this.ltqx.Size = new System.Drawing.Size(72, 23);
			this.ltqx.TabIndex = 74;
			this.ltqx.Text = "T/Q/PXã :";
			this.ltqx.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lcholam
			// 
			this.lcholam.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lcholam.Location = new System.Drawing.Point(-4, 131);
			this.lcholam.Name = "lcholam";
			this.lcholam.Size = new System.Drawing.Size(72, 23);
			this.lcholam.TabIndex = 73;
			this.lcholam.Text = "Nơi làm việc :";
			this.lcholam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lthon
			// 
			this.lthon.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lthon.Location = new System.Drawing.Point(136, 62);
			this.lthon.Name = "lthon";
			this.lthon.Size = new System.Drawing.Size(72, 23);
			this.lthon.TabIndex = 72;
			this.lthon.Text = "Thôn, phố :";
			this.lthon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lsonha
			// 
			this.lsonha.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lsonha.Location = new System.Drawing.Point(8, 62);
			this.lsonha.Name = "lsonha";
			this.lsonha.Size = new System.Drawing.Size(56, 23);
			this.lsonha.TabIndex = 70;
			this.lsonha.Text = "Số nhà :";
			this.lsonha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lmadantoc
			// 
			this.lmadantoc.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lmadantoc.Location = new System.Drawing.Point(360, 40);
			this.lmadantoc.Name = "lmadantoc";
			this.lmadantoc.Size = new System.Drawing.Size(56, 16);
			this.lmadantoc.TabIndex = 61;
			this.lmadantoc.Text = "Dân tộc :";
			this.lmadantoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lmann
			// 
			this.lmann.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lmann.Location = new System.Drawing.Point(104, 40);
			this.lmann.Name = "lmann";
			this.lmann.Size = new System.Drawing.Size(80, 23);
			this.lmann.TabIndex = 58;
			this.lmann.Text = "Nghề nghiệp :";
			this.lmann.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// phai
			// 
			this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
			this.phai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.phai.Items.AddRange(new object[] {
													  "Nam",
													  "Nữ"});
			this.phai.Location = new System.Drawing.Point(63, 38);
			this.phai.Name = "phai";
			this.phai.Size = new System.Drawing.Size(43, 21);
			this.phai.TabIndex = 8;
			this.phai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phai_KeyDown);
			// 
			// lphai
			// 
			this.lphai.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lphai.Location = new System.Drawing.Point(0, 40);
			this.lphai.Name = "lphai";
			this.lphai.Size = new System.Drawing.Size(64, 23);
			this.lphai.TabIndex = 161;
			this.lphai.Text = "Giới tính :";
			this.lphai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ngaysinh
			// 
			this.ngaysinh.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ngaysinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ngaysinh.Location = new System.Drawing.Point(383, 16);
			this.ngaysinh.Mask = "##/##/####";
			this.ngaysinh.Name = "ngaysinh";
			this.ngaysinh.Size = new System.Drawing.Size(64, 21);
			this.ngaysinh.TabIndex = 4;
			this.ngaysinh.Text = "";
			this.ngaysinh.Validated += new System.EventHandler(this.ngaysinh_Validated);
			// 
			// label1
			// 
			this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label1.Location = new System.Drawing.Point(514, 130);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 162;
			this.label1.Text = "Số lưu trữ";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// soluutru
			// 
			this.soluutru.BackColor = System.Drawing.SystemColors.HighlightText;
			this.soluutru.Enabled = false;
			this.soluutru.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.soluutru.ForeColor = System.Drawing.Color.Red;
			this.soluutru.Location = new System.Drawing.Point(582, 132);
			this.soluutru.Name = "soluutru";
			this.soluutru.Size = new System.Drawing.Size(89, 21);
			this.soluutru.TabIndex = 163;
			this.soluutru.Text = "";
			this.soluutru.KeyDown += new System.Windows.Forms.KeyEventHandler(this.soluutru_KeyDown);
			// 
			// frmSuahc
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(680, 229);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.soluutru,
																		  this.thon,
																		  this.loaituoi,
																		  this.cholam,
																		  this.maqu1,
																		  this.tqx,
																		  this.sonha,
																		  this.phai,
																		  this.mann,
																		  this.tennn,
																		  this.madantoc,
																		  this.tendantoc,
																		  this.manuoc,
																		  this.tennuoc,
																		  this.butKetthuc,
																		  this.butBoqua,
																		  this.butLuu,
																		  this.butTiep,
																		  this.ngaysinh,
																		  this.lphai,
																		  this.namsinh,
																		  this.hoten,
																		  this.tuoi,
																		  this.mabn3,
																		  this.label7,
																		  this.label6,
																		  this.mabn2,
																		  this.label5,
																		  this.label4,
																		  this.label3,
																		  this.lmann,
																		  this.lmadantoc,
																		  this.lmanuoc,
																		  this.lsonha,
																		  this.lthon,
																		  this.ltqx,
																		  this.tentqx,
																		  this.lmatt,
																		  this.matt,
																		  this.tentinh,
																		  this.lmaqu,
																		  this.maqu2,
																		  this.tenquan,
																		  this.lmaphuongxa,
																		  this.mapxa1,
																		  this.mapxa2,
																		  this.tenpxa,
																		  this.lcholam,
																		  this.label1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "frmSuahc";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Medisoft";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSuahc_KeyDown);
			this.Load += new System.EventHandler(this.frmSuahc_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmSuahc_Load(object sender, System.EventArgs e)
		{
			load_dm();
			s_msg=LibMedi.AccessData.Msg;
			iTreem6=m.iTreem6;
			iTreem15=m.iTreem15;
			b_Hoten=m.bHoten_gioitinh;
			butTiep.Enabled=m_mabn=="";
			if (m_mabn!="") 
			{
				mabn2.Text=m_mabn.Substring(0,2);
				mabn3.Text=m_mabn.Substring(2);
				mabn2.Enabled=false;
				mabn3.Enabled=false;
				butLuu.Enabled=true;
			}
		}

		private void load_dm()
		{
			mabn2.Text=DateTime.Now.Year.ToString().Substring(2,2);

			tennn.DisplayMember="TENNN";
			tennn.ValueMember="MANN";
			load_btdnn(0);			

			tendantoc.DisplayMember="DANTOC";
			tendantoc.ValueMember="MADANTOC";
			tendantoc.DataSource=m.get_data("select * from btddt order by madantoc").Tables[0];
			tendantoc.SelectedValue="25";

			tentinh.DisplayMember="TENTT";
			tentinh.ValueMember="MATT";
			tentinh.DataSource=m.get_data("select * from btdtt order by tentt").Tables[0];
			tentinh.SelectedValue=m.Mabv.Substring(0,3);

			tenquan.DisplayMember="TENQUAN";
			tenquan.ValueMember="MAQU";
			load_quan();
            
			tenpxa.DisplayMember="TENPXA";
			tenpxa.ValueMember="MAPHUONGXA";
			load_pxa();
			
			tennuoc.DisplayMember="TEN";
			tennuoc.ValueMember="MA";
			tennuoc.DataSource=m.get_data("select * from dmquocgia order by ma").Tables[0];
			tennuoc.SelectedIndex=-1;

			tentqx.DisplayMember="TEN";
			tentqx.ValueMember="MAPHUONGXA";
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
			tenquan.DataSource=m.get_data("select * from btdquan where matt='"+tentinh.SelectedValue.ToString()+"'"+" order by maqu").Tables[0];
		}

		private void load_pxa()
		{
			tenpxa.DataSource=m.get_data("select * from btdpxa where maqu='"+tenquan.SelectedValue.ToString()+"'"+" order by maphuongxa").Tables[0];
		}

		private void hoten_Validated(object sender, System.EventArgs e)
		{
			if (hoten.Text=="") mabn2.Focus();
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
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
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
			s_mabn=mabn2.Text+mabn3.Text;
			DataTable dt=m.get_Timmabn(hoten.Text.Trim().ToUpper(),ngaysinh.Text,namsinh.Text,s_mabn).Tables[0];
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
					return true;
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
			if (mabn3.Text=="") return;
			mabn3.Text=mabn3.Text.PadLeft(6,'0');
			s_mabn=mabn2.Text+mabn3.Text;
			emp_text(true);
			if (m_mabn=="")
			{
				if (!load_mabn())
				{
					MessageBox.Show(lan.Change_language_MessageText("Mã người bệnh không tìm thấy !"),s_msg);
					mabn2.Focus();
				}
					// cập nhật số lưu trữ
				else
				{
					if(add_soltru)
					{
						soluutru.Enabled=true;
						DataTable tb= new DataTable();
						string sql="select a.soluutru from lienhe a, benhandt b where b.maql=(select max(maql) from benhandt where mabn='"+s_mabn+"') and a.maql =b.maql";
						tb=m.get_data(sql).Tables[0];
						if(tb.Rows.Count <=0)
						{
							sql="select a.soluutru from lienhe a, tiepdon b where b.maql=(select max(maql) from tiepdon where mabn='"+s_mabn+"') and a.maql=b.maql";
							tb=m.get_data(sql).Tables[0];
							if(tb.Rows.Count > 0) soluutru.Text=tb.Rows[0]["SOLUUTRU"].ToString();						
						}
						else
						{
							soluutru.Text=tb.Rows[0]["SOLUUTRU"].ToString();						
						}					
					}
					else
					{
						soluutru.Enabled=false;
					}
				}
				// end cập nhật số lưu trữ
			}
		}

		private bool load_mabn()
		{
			bool ret=false;
			foreach(DataRow r in m.get_data("select * from btdbn where mabn='"+s_mabn+"'").Tables[0].Rows)
			{
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
			if (ret && manuoc.Enabled) tennuoc.SelectedValue=m.get_data("select id_nuoc from nuocngoai where mabn='"+s_mabn+"'").Tables[0].Rows[0][0].ToString();
			return ret;
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

		private void frmSuahc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
			m_mabn="";
			this.Close();
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
			cholam.Text="";
			soluutru.Text="";
			tentqx.SelectedIndex=-1;
			tqx.Text="";
			tentinh.SelectedValue=m.Mabv.Substring(0,3);
			tendantoc.SelectedValue="25";
			tennuoc.SelectedValue="VN";
			load_quan();
			load_pxa();
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
			else
			{
				if (namsinh.Text!=m.Namsinh("",int.Parse(tuoi.Text),loaituoi.SelectedIndex).ToString())
				{
					if (MessageBox.Show(lan.Change_language_MessageText("Tuổi và năm sinh không hợp lệ\nBạn có muốn chương trình tính lại không ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
					{
						ngaysinh.Text="";
                        namsinh.Text=m.Namsinh("",int.Parse(tuoi.Text),loaituoi.SelectedIndex).ToString();
					}
					else
					{
						if (ngaysinh.Text!="") ngaysinh.Focus();
						else namsinh.Focus();
						return false;
					}
				}
			}

			if (mann.Text=="" || tennn.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập nghề nghiệp !"),s_msg);
				mann.Focus();
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
			s_mabn=mabn2.Text+mabn3.Text;
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			// cập nhật số lưu trữ Uông Bí
			if(soluutru.TextLength >0) upd_slt();
			// end cập nhật số lưu trữ Uông Bí
			if (!m.upd_btdbn(s_mabn,hoten.Text,ngaysinh.Text,namsinh.Text,phai.SelectedIndex,mann.Text,madantoc.Text,sonha.Text,thon.Text,cholam.Text,matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,i_userid))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
			if (manuoc.Enabled && manuoc.Text!="") m.upd_nuocngoai(s_mabn,manuoc.Text);
			else m.execute_data("delete from nuocngoai where mabn='"+s_mabn+"'");
			ena_but(false);
			if (m_mabn!="") this.Close();
			else butTiep.Focus();
		}

		private void upd_slt()
		{
			string sql = "update lienhe set soluutru='"+soluutru.Text.ToString()+"' where lienhe.maql=(select max(maql) from benhandt where mabn='"+s_mabn+"' and loaiba=1)";
            m.execute_data(sql);
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

		private void load_btdnn(int i)
		{
			if (i==0) tennn.DataSource=m.get_data("select * from btdnn_bv order by mann").Tables[0];
			else
			{
				if (namsinh.Text!="")
				{
					if (DateTime.Now.Year-int.Parse(namsinh.Text)<iTreem6)
						tennn.DataSource=m.get_data("select * from btdnn_bv where mannbo='01' order by mann").Tables[0];
					else if (DateTime.Now.Year-int.Parse(namsinh.Text)<iTreem15)
						tennn.DataSource=m.get_data("select * from btdnn_bv where mannbo in ('01','02') order by mann").Tables[0];
					else tennn.DataSource=m.get_data("select * from btdnn_bv where mannbo<>'01' order by mann").Tables[0];
				}
			}
		}

		private void tuoi_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			m.MaskDigit(e);
		}

		private void soluutru_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) butLuu.Focus();
		}
	}
}
