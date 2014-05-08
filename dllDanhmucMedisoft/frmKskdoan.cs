using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using LibMedi;

namespace dllDanhmucMedisoft
{
	/// <summary>
	/// Summary description for frmKskdoan.
	/// </summary>
	public class frmKskdoan : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

        /// <summary>
		/// Required designer variable.
		/// </summary>
		/// 
		private AccessData m;
		private string sql, s_ma="",s_mmyy,user;
		private int i_userid,i_loai;
		private DataRow r1;
		private bool be = true;
		private decimal l_doan=0, l_donvi=0, l_muc=0,l_save=0;
		private DataSet ds = new DataSet();
		private DataSet dsxml = new DataSet();
		private DataTable dt1 = new DataTable();
		private DataTable dt2 = new DataTable();
		private DataTable dt3 = new DataTable();
		private DataTable dt4 = new DataTable();
		private DataTable dtgia = new DataTable();
		private DataTable dtmuc = new DataTable();
		private DataTable dtmucct = new DataTable();
		private FileStream fstr;
		private byte[] imagemabn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ComboBox loai;
		private System.Windows.Forms.TextBox ten;
		private System.Windows.Forms.TextBox sohd;
		private MaskedBox.MaskedBox ngay;
		private System.Windows.Forms.TextBox diachi;
		private System.Windows.Forms.TextBox fax;
		private System.Windows.Forms.TextBox email;
		private System.Windows.Forms.TextBox masothue;
		private System.Windows.Forms.TextBox nguoilienhe;
		private System.Windows.Forms.TextBox ghichu;
		private System.Windows.Forms.TextBox dienthoai;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.DataGrid dataGrid3;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.DataGrid dataGrid4;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.ComboBox cmbten;
		private System.Windows.Forms.Button butdvthem;
		private System.Windows.Forms.Button butdvsua;
		private System.Windows.Forms.Button butdvxoa;
		private System.Windows.Forms.Button butmucxoa;
		private System.Windows.Forms.Button butmucsua;
		private System.Windows.Forms.Button butmucthem;
		private System.Windows.Forms.Button butdsxoa;
		private System.Windows.Forms.Button butdssua;
		private System.Windows.Forms.Button butdsthem;
		private System.Windows.Forms.Button butctxoa;
		private System.Windows.Forms.Button butctthem;
		private System.Windows.Forms.Button butFile;
		private System.Windows.Forms.TextBox tim;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.CheckBox chkAlldv;
		private System.Windows.Forms.CheckBox chkAll;
		private System.ComponentModel.Container components = null;

		public frmKskdoan(AccessData acc,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

            m = acc; i_userid = userid; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKskdoan));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.loai = new System.Windows.Forms.ComboBox();
            this.ten = new System.Windows.Forms.TextBox();
            this.sohd = new System.Windows.Forms.TextBox();
            this.ngay = new MaskedBox.MaskedBox();
            this.diachi = new System.Windows.Forms.TextBox();
            this.fax = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.masothue = new System.Windows.Forms.TextBox();
            this.nguoilienhe = new System.Windows.Forms.TextBox();
            this.ghichu = new System.Windows.Forms.TextBox();
            this.dienthoai = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.dataGrid3 = new System.Windows.Forms.DataGrid();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.dataGrid4 = new System.Windows.Forms.DataGrid();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.cmbten = new System.Windows.Forms.ComboBox();
            this.butdvthem = new System.Windows.Forms.Button();
            this.butdvsua = new System.Windows.Forms.Button();
            this.butdvxoa = new System.Windows.Forms.Button();
            this.butmucxoa = new System.Windows.Forms.Button();
            this.butmucsua = new System.Windows.Forms.Button();
            this.butmucthem = new System.Windows.Forms.Button();
            this.butdsxoa = new System.Windows.Forms.Button();
            this.butdssua = new System.Windows.Forms.Button();
            this.butdsthem = new System.Windows.Forms.Button();
            this.butctxoa = new System.Windows.Forms.Button();
            this.butctthem = new System.Windows.Forms.Button();
            this.butFile = new System.Windows.Forms.Button();
            this.tim = new System.Windows.Forms.TextBox();
            this.butIn = new System.Windows.Forms.Button();
            this.chkAlldv = new System.Windows.Forms.CheckBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Tên :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(329, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Số hợp đồng :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(561, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Ngày :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-5, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Địa chỉ :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(270, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Điện thoại :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(412, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Fax :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(2, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 43;
            this.label7.Text = "Email :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(159, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 44;
            this.label8.Text = "Mã số thuế :";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(329, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 13);
            this.label9.TabIndex = 45;
            this.label9.Text = "Người liên hệ :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(542, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 46;
            this.label10.Text = "Ghi chú :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(660, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 13);
            this.label11.TabIndex = 39;
            this.label11.Text = "Loại :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loai
            // 
            this.loai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loai.Enabled = false;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Items.AddRange(new object[] {
            "Nội viện",
            "Ngoại viện"});
            this.loai.Location = new System.Drawing.Point(699, 4);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(89, 21);
            this.loai.TabIndex = 4;
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loai_KeyDown);
            // 
            // ten
            // 
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(64, 4);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(262, 21);
            this.ten.TabIndex = 1;
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // sohd
            // 
            this.sohd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sohd.Enabled = false;
            this.sohd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sohd.Location = new System.Drawing.Point(402, 4);
            this.sohd.Name = "sohd";
            this.sohd.Size = new System.Drawing.Size(139, 21);
            this.sohd.TabIndex = 2;
            this.sohd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // ngay
            // 
            this.ngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay.Enabled = false;
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Location = new System.Drawing.Point(598, 4);
            this.ngay.Mask = "##/##/####";
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(70, 21);
            this.ngay.TabIndex = 3;
            this.ngay.Text = "  /  /    ";
            this.ngay.Validated += new System.EventHandler(this.ngay_Validated);
            // 
            // diachi
            // 
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(64, 27);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(207, 21);
            this.diachi.TabIndex = 5;
            this.diachi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // fax
            // 
            this.fax.BackColor = System.Drawing.SystemColors.HighlightText;
            this.fax.Enabled = false;
            this.fax.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fax.Location = new System.Drawing.Point(441, 27);
            this.fax.Name = "fax";
            this.fax.Size = new System.Drawing.Size(100, 21);
            this.fax.TabIndex = 7;
            this.fax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // email
            // 
            this.email.BackColor = System.Drawing.SystemColors.HighlightText;
            this.email.Enabled = false;
            this.email.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email.Location = new System.Drawing.Point(64, 50);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(97, 21);
            this.email.TabIndex = 9;
            this.email.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // masothue
            // 
            this.masothue.BackColor = System.Drawing.SystemColors.HighlightText;
            this.masothue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.masothue.Enabled = false;
            this.masothue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.masothue.Location = new System.Drawing.Point(222, 50);
            this.masothue.Name = "masothue";
            this.masothue.Size = new System.Drawing.Size(104, 21);
            this.masothue.TabIndex = 10;
            this.masothue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // nguoilienhe
            // 
            this.nguoilienhe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nguoilienhe.Enabled = false;
            this.nguoilienhe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nguoilienhe.Location = new System.Drawing.Point(441, 50);
            this.nguoilienhe.Name = "nguoilienhe";
            this.nguoilienhe.Size = new System.Drawing.Size(100, 21);
            this.nguoilienhe.TabIndex = 11;
            this.nguoilienhe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // ghichu
            // 
            this.ghichu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ghichu.Enabled = false;
            this.ghichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ghichu.Location = new System.Drawing.Point(599, 27);
            this.ghichu.Multiline = true;
            this.ghichu.Name = "ghichu";
            this.ghichu.Size = new System.Drawing.Size(189, 42);
            this.ghichu.TabIndex = 8;
            this.ghichu.TextChanged += new System.EventHandler(this.ghichu_TextChanged);
            // 
            // dienthoai
            // 
            this.dienthoai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dienthoai.Enabled = false;
            this.dienthoai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dienthoai.Location = new System.Drawing.Point(328, 27);
            this.dienthoai.Name = "dienthoai";
            this.dienthoai.Size = new System.Drawing.Size(86, 21);
            this.dienthoai.TabIndex = 6;
            this.dienthoai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.CaptionForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGrid1.CaptionText = "Đơn vị trong đoàn";
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(5, 72);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 5;
            this.dataGrid1.Size = new System.Drawing.Size(417, 168);
            this.dataGrid1.TabIndex = 32;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // dataGrid3
            // 
            this.dataGrid3.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid3.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid3.CaptionForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGrid3.CaptionText = "Các mục đăng ký";
            this.dataGrid3.DataMember = "";
            this.dataGrid3.FlatMode = true;
            this.dataGrid3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid3.Location = new System.Drawing.Point(428, 73);
            this.dataGrid3.Name = "dataGrid3";
            this.dataGrid3.RowHeaderWidth = 5;
            this.dataGrid3.Size = new System.Drawing.Size(360, 103);
            this.dataGrid3.TabIndex = 33;
            this.dataGrid3.CurrentCellChanged += new System.EventHandler(this.dataGrid3_CurrentCellChanged);
            // 
            // dataGrid2
            // 
            this.dataGrid2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid2.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.CaptionForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGrid2.CaptionText = "Danh sách trong đơn vị";
            this.dataGrid2.DataMember = "";
            this.dataGrid2.FlatMode = true;
            this.dataGrid2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(5, 243);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.RowHeaderWidth = 5;
            this.dataGrid2.Size = new System.Drawing.Size(417, 222);
            this.dataGrid2.TabIndex = 34;
            // 
            // dataGrid4
            // 
            this.dataGrid4.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid4.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid4.CaptionForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGrid4.CaptionText = "Chi tiết mục đăng ký";
            this.dataGrid4.DataMember = "";
            this.dataGrid4.FlatMode = true;
            this.dataGrid4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid4.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid4.Location = new System.Drawing.Point(428, 182);
            this.dataGrid4.Name = "dataGrid4";
            this.dataGrid4.RowHeaderWidth = 5;
            this.dataGrid4.Size = new System.Drawing.Size(360, 283);
            this.dataGrid4.TabIndex = 35;
            // 
            // butMoi
            // 
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(154, 499);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 14;
            this.butMoi.Text = "    &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(224, 499);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 15;
            this.butSua.Text = "    &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(294, 499);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 12;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(364, 499);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 13;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(504, 499);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 17;
            this.butHuy.Text = "    &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(574, 499);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 18;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // cmbten
            // 
            this.cmbten.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbten.Location = new System.Drawing.Point(64, 4);
            this.cmbten.Name = "cmbten";
            this.cmbten.Size = new System.Drawing.Size(262, 21);
            this.cmbten.TabIndex = 0;
            this.cmbten.SelectedIndexChanged += new System.EventHandler(this.cmbten_SelectedIndexChanged);
            // 
            // butdvthem
            // 
            this.butdvthem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butdvthem.Location = new System.Drawing.Point(263, 73);
            this.butdvthem.Name = "butdvthem";
            this.butdvthem.Size = new System.Drawing.Size(55, 19);
            this.butdvthem.TabIndex = 19;
            this.butdvthem.Text = "Thêm";
            this.butdvthem.Click += new System.EventHandler(this.butdvthem_Click);
            // 
            // butdvsua
            // 
            this.butdvsua.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butdvsua.Location = new System.Drawing.Point(318, 73);
            this.butdvsua.Name = "butdvsua";
            this.butdvsua.Size = new System.Drawing.Size(55, 19);
            this.butdvsua.TabIndex = 20;
            this.butdvsua.Text = "Sửa";
            this.butdvsua.Click += new System.EventHandler(this.butdvsua_Click);
            // 
            // butdvxoa
            // 
            this.butdvxoa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butdvxoa.Location = new System.Drawing.Point(373, 73);
            this.butdvxoa.Name = "butdvxoa";
            this.butdvxoa.Size = new System.Drawing.Size(55, 19);
            this.butdvxoa.TabIndex = 21;
            this.butdvxoa.Text = "Xoá";
            this.butdvxoa.Click += new System.EventHandler(this.butdvxoa_Click);
            // 
            // butmucxoa
            // 
            this.butmucxoa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butmucxoa.Location = new System.Drawing.Point(732, 73);
            this.butmucxoa.Name = "butmucxoa";
            this.butmucxoa.Size = new System.Drawing.Size(55, 19);
            this.butmucxoa.TabIndex = 24;
            this.butmucxoa.Text = "Xoá";
            this.butmucxoa.Click += new System.EventHandler(this.butmucxoa_Click);
            // 
            // butmucsua
            // 
            this.butmucsua.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butmucsua.Location = new System.Drawing.Point(677, 73);
            this.butmucsua.Name = "butmucsua";
            this.butmucsua.Size = new System.Drawing.Size(55, 19);
            this.butmucsua.TabIndex = 23;
            this.butmucsua.Text = "Sửa";
            this.butmucsua.Click += new System.EventHandler(this.butmucsua_Click);
            // 
            // butmucthem
            // 
            this.butmucthem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butmucthem.Location = new System.Drawing.Point(622, 73);
            this.butmucthem.Name = "butmucthem";
            this.butmucthem.Size = new System.Drawing.Size(55, 19);
            this.butmucthem.TabIndex = 22;
            this.butmucthem.Text = "Thêm";
            this.butmucthem.Click += new System.EventHandler(this.butmucthem_Click);
            // 
            // butdsxoa
            // 
            this.butdsxoa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butdsxoa.Location = new System.Drawing.Point(365, 242);
            this.butdsxoa.Name = "butdsxoa";
            this.butdsxoa.Size = new System.Drawing.Size(55, 19);
            this.butdsxoa.TabIndex = 28;
            this.butdsxoa.Text = "Xoá";
            this.butdsxoa.Click += new System.EventHandler(this.butdsxoa_Click);
            // 
            // butdssua
            // 
            this.butdssua.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butdssua.Location = new System.Drawing.Point(310, 242);
            this.butdssua.Name = "butdssua";
            this.butdssua.Size = new System.Drawing.Size(55, 19);
            this.butdssua.TabIndex = 27;
            this.butdssua.Text = "Sửa";
            this.butdssua.Click += new System.EventHandler(this.butdssua_Click);
            // 
            // butdsthem
            // 
            this.butdsthem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butdsthem.Location = new System.Drawing.Point(255, 242);
            this.butdsthem.Name = "butdsthem";
            this.butdsthem.Size = new System.Drawing.Size(55, 19);
            this.butdsthem.TabIndex = 26;
            this.butdsthem.Text = "Thêm";
            this.butdsthem.Click += new System.EventHandler(this.butdsthem_Click);
            // 
            // butctxoa
            // 
            this.butctxoa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butctxoa.Location = new System.Drawing.Point(735, 181);
            this.butctxoa.Name = "butctxoa";
            this.butctxoa.Size = new System.Drawing.Size(55, 19);
            this.butctxoa.TabIndex = 31;
            this.butctxoa.Text = "Xoá";
            this.butctxoa.Click += new System.EventHandler(this.butctxoa_Click);
            // 
            // butctthem
            // 
            this.butctthem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butctthem.Location = new System.Drawing.Point(680, 181);
            this.butctthem.Name = "butctthem";
            this.butctthem.Size = new System.Drawing.Size(55, 19);
            this.butctthem.TabIndex = 29;
            this.butctthem.Text = "Thêm";
            this.butctthem.Click += new System.EventHandler(this.butctthem_Click);
            // 
            // butFile
            // 
            this.butFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butFile.Location = new System.Drawing.Point(200, 242);
            this.butFile.Name = "butFile";
            this.butFile.Size = new System.Drawing.Size(55, 19);
            this.butFile.TabIndex = 25;
            this.butFile.Text = "Excel";
            this.butFile.Visible = false;
            this.butFile.Click += new System.EventHandler(this.butFile_Click);
            // 
            // tim
            // 
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.ForeColor = System.Drawing.Color.Red;
            this.tim.Location = new System.Drawing.Point(5, 471);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(172, 21);
            this.tim.TabIndex = 47;
            this.tim.Text = "tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(434, 499);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 48;
            this.butIn.Text = "    &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // chkAlldv
            // 
            this.chkAlldv.Location = new System.Drawing.Point(593, 467);
            this.chkAlldv.Name = "chkAlldv";
            this.chkAlldv.Size = new System.Drawing.Size(203, 17);
            this.chkAlldv.TabIndex = 285;
            this.chkAlldv.Text = "In tất cả kết quả trong đơn vị";
            this.chkAlldv.Visible = false;
            // 
            // chkAll
            // 
            this.chkAll.Location = new System.Drawing.Point(593, 483);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(198, 17);
            this.chkAll.TabIndex = 284;
            this.chkAll.Text = "In tất cả kết quả trong đoàn";
            this.chkAll.Visible = false;
            // 
            // frmKskdoan
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.butKetthuc;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.chkAlldv);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.butFile);
            this.Controls.Add(this.butctxoa);
            this.Controls.Add(this.butctthem);
            this.Controls.Add(this.butdsxoa);
            this.Controls.Add(this.butdssua);
            this.Controls.Add(this.butdsthem);
            this.Controls.Add(this.butmucxoa);
            this.Controls.Add(this.butmucsua);
            this.Controls.Add(this.butmucthem);
            this.Controls.Add(this.butdvxoa);
            this.Controls.Add(this.butdvsua);
            this.Controls.Add(this.butdvthem);
            this.Controls.Add(this.cmbten);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.dienthoai);
            this.Controls.Add(this.ghichu);
            this.Controls.Add(this.nguoilienhe);
            this.Controls.Add(this.masothue);
            this.Controls.Add(this.email);
            this.Controls.Add(this.fax);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.sohd);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.loai);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.dataGrid3);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.dataGrid4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKskdoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký khám sức khỏe";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmKskdoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmKskdoan_Load(object sender, EventArgs e)
		{
			if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			else this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            user = m.user;
			loai.SelectedIndex = 0;
			DataTable tmp = m.get_data("select id from "+user+".kskloai order by id").Tables[0];
			i_loai = (tmp.Rows.Count > 0) ? int.Parse(tmp.Rows[0]["id"].ToString()) : 0;
			dsxml.ReadXml("..//..//..//xml//m_khamksk.xml");
			dtgia = m.get_data("select * from "+user+".v_giavp").Tables[0];
            sql = "select a.*,to_char(a.ngay,'dd/mm/yyyy') as ngayhd,to_char(a.ngayud,'mmyy') as mmyy from " + user + ".kskdoan a order by a.id desc ";
			ds = m.get_data(sql);
			cmbten.DisplayMember = "TEN";
			cmbten.ValueMember = "ID";
			cmbten.DataSource = ds.Tables[0];
			l_doan = (cmbten.SelectedIndex != -1) ? decimal.Parse(cmbten.SelectedValue.ToString()) : 0;
			load_doan();
		}

		private void ten_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void loai_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
			{
				if (loai.SelectedIndex == -1) loai.SelectedIndex = 0;
				SendKeys.Send("{Tab}");
			}
		}

		private void cmbten_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.ActiveControl == cmbten && cmbten.SelectedIndex!=-1)
			{
				upd_kskmucct();
				l_doan = decimal.Parse(cmbten.SelectedValue.ToString());
				load_doan();
			}
		}

		private void load_doan()
		{
			r1=m.getrowbyid(ds.Tables[0],"id="+l_doan);
			if (r1 != null)
			{
				ten.Text = r1["ten"].ToString();
				sohd.Text = r1["sohd"].ToString();
				ngay.Text = r1["ngayhd"].ToString();
				loai.SelectedIndex = int.Parse(r1["loai"].ToString());
				diachi.Text = r1["diachi"].ToString();
				dienthoai.Text = r1["dienthoai"].ToString();
				fax.Text = r1["fax"].ToString();
				email.Text = r1["email"].ToString();
				masothue.Text = r1["masothue"].ToString();
				nguoilienhe.Text = r1["nguoilienhe"].ToString();
				ghichu.Text = r1["ghichu"].ToString();
				s_ma = r1["ma"].ToString();
				s_mmyy=r1["mmyy"].ToString();
			}
			load_donvi();
			load_danhsach();
			load_muc();
			load_mucct();
			be = false;
		}

		private void ngay_Validated(object sender, EventArgs e)
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
				MessageBox.Show("Yêu cầu nhập Ngày!");
				ngay.Focus();
				return;
			}
			if (!m.bNgay(ngay.Text))
			{
				MessageBox.Show("Ngày và giờ không hợp lệ !");
				ngay.Focus();
				return;
			}

		}

		private void ena_object(bool ena)
		{
			cmbten.Visible = !ena;
			ten.Enabled = ena;
			sohd.Enabled = ena;
			ngay.Enabled = ena;
			loai.Enabled = ena;
			diachi.Enabled = ena;
			dienthoai.Enabled = ena;
			fax.Enabled = ena;
			email.Enabled = ena;
			masothue.Enabled = ena;
			nguoilienhe.Enabled = ena;
			ghichu.Enabled = ena;
			butMoi.Enabled = !ena;
			butSua.Enabled = !ena;
			butLuu.Enabled = ena;
			butBoqua.Enabled = ena;
			butHuy.Enabled = !ena;
			butIn.Enabled = !ena;
			butKetthuc.Enabled = !ena;
			butdvthem.Enabled = !ena;
			butdvsua.Enabled = !ena;
			butdvxoa.Enabled = !ena;
			butmucsua.Enabled = !ena;
			butmucthem.Enabled = !ena;
			butmucxoa.Enabled = !ena;
			butdssua.Enabled = !ena;
			butdsthem.Enabled = !ena;
			butdsxoa.Enabled = !ena;
			butFile.Enabled = !ena;
			butdvsua.Enabled = !ena;
			butctthem.Enabled = !ena;
			butctxoa.Enabled = !ena;
		}

		private void emp_text()
		{
			l_doan = 0; l_donvi = 0; l_muc = 0; s_ma = "";
			ten.Text = ""; sohd.Text = ""; ngay.Text = m.ngayhienhanh_server.Substring(0, 10);
			s_mmyy = m.mmyy(ngay.Text); diachi.Text = ""; dienthoai.Text = ""; fax.Text = ""; email.Text = "";
			masothue.Text = ""; nguoilienhe.Text = ""; ghichu.Text = "";		
			load_doan();
			//dt1.Clear(); dt2.Clear(); dt3.Clear(); dt4.Clear();
		}

		private void butMoi_Click(object sender, EventArgs e)
		{
			upd_kskmucct();
			l_save = (cmbten.SelectedIndex!=-1)?decimal.Parse(cmbten.SelectedValue.ToString()):0;
			ena_object(true);
			emp_text();			
			ten.Focus();
		}

		private void butSua_Click(object sender, EventArgs e)
		{
			if (cmbten.SelectedIndex == -1) return;
			l_save = decimal.Parse(cmbten.SelectedValue.ToString());
			ena_object(true);
			ten.Focus();
		}

		private bool kiemtra()
		{
			if (ten.Text == "")
			{
				MessageBox.Show("Yêu cầu nhập tên đoàn !", LibMedi.AccessData.Msg);
				ten.Focus();
				return false;
			}
			return true;
		}

		private void butLuu_Click(object sender, EventArgs e)
		{
			if (!kiemtra()) return;
			if (l_doan == 0) 
			{
				l_doan = m.getidyymmddhhmiss_stt_computer;
				s_ma=m.get_ma_kskdoan(ngay.Text);
			}
			m.upd_kskdoan(l_doan, sohd.Text, ngay.Text, loai.SelectedIndex, s_ma, ten.Text, diachi.Text, dienthoai.Text, fax.Text, email.Text, masothue.Text, nguoilienhe.Text, ghichu.Text, i_userid);
			updrec();
			cmbten.SelectedValue = l_doan.ToString();
			load_doan();
			ena_object(false);
		}

		private void butBoqua_Click(object sender, EventArgs e)
		{
			cmbten.SelectedValue = l_save.ToString();
			l_doan = (cmbten.SelectedIndex != -1) ? decimal.Parse(cmbten.SelectedValue.ToString()) : 0;
			load_doan();
			ena_object(false);
		}

		private void butHuy_Click(object sender, EventArgs e)
		{
			if (cmbten.SelectedIndex == -1) return;
            if (m.get_data("select a.* from " + user + ".kskbtdbn a," + user + ".kskdonvi b where a.iddonvi=b.id and b.iddoan=" + l_doan + " and a.done=1").Tables[0].Rows.Count > 0)
			{
				MessageBox.Show("Đã nhập kết qủa, không được hủy !", LibMedi.AccessData.Msg);
				return;
			}
			if (MessageBox.Show("Đồng ý hủy\n" + cmbten.Text, LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
                foreach (DataRow r in m.get_data("select * from " + user + ".kskmuc where iddoan=" + l_doan).Tables[0].Rows)
                    m.execute_data("delete from " + user + ".kskmucct where id=" + decimal.Parse(r["id"].ToString()));
                m.execute_data("delete from " + user + ".kskmuc where iddoan=" + l_doan);
                foreach (DataRow r in m.get_data("select * from " + user + ".kskdonvi where iddoan=" + l_doan).Tables[0].Rows)
                    m.execute_data("delete from " + user + ".kskbtdbn where iddonvi=" + decimal.Parse(r["id"].ToString()));
                m.execute_data("delete from " + user + ".kskdonvi where iddoan=" + l_doan);
                m.execute_data("delete from " + user + ".kskdoan where id=" + l_doan);
                sql = "select a.*,to_char(a.ngay,'dd/mm/yyyy') as ngayhd,to_char(a.ngayud,'mmyy') as mmyy from " + user + ".kskdoan a order by a.id desc ";
				ds = m.get_data(sql);
				cmbten.DataSource = ds.Tables[0];
				l_doan = (cmbten.SelectedIndex != -1) ? decimal.Parse(cmbten.SelectedValue.ToString()) : 0;
				load_doan();
			}
		}

		private void butKetthuc_Click(object sender, EventArgs e)
		{
			upd_kskmucct();
			m.close();this.Close();
		}

		private void updrec()
		{
			r1 = m.getrowbyid(ds.Tables[0], "id=" + l_doan);
			if (r1 == null)
			{
				DataRow r2 = ds.Tables[0].NewRow();
				r2["id"] = l_doan;
				r2["ma"] = s_ma;
				r2["ten"] = ten.Text;
				r2["sohd"] = sohd.Text;
				r2["ngayhd"] = ngay.Text;
				r2["loai"] = loai.SelectedIndex;
				r2["diachi"] = diachi.Text;
				r2["dienthoai"] = dienthoai.Text;
				r2["fax"] = fax.Text;
				r2["email"] = email.Text;
				r2["masothue"] = masothue.Text;
				r2["nguoilienhe"] = nguoilienhe.Text;
				r2["ghichu"] = ghichu.Text;
				r2["mmyy"] = s_mmyy;
				ds.Tables[0].Rows.Add(r2);
			}
			else
			{
				DataRow[] dr = ds.Tables[0].Select("id=" + l_doan);
				if (dr.Length > 0)
				{
					dr[0]["ma"] = s_ma;
					dr[0]["ten"] = ten.Text;
					dr[0]["sohd"] = sohd.Text;
					dr[0]["ngayhd"] = ngay.Text;
					dr[0]["loai"] = loai.SelectedIndex;
					dr[0]["diachi"] = diachi.Text;
					dr[0]["dienthoai"] = dienthoai.Text;
					dr[0]["fax"] = fax.Text;
					dr[0]["email"] = email.Text;
					dr[0]["masothue"] = masothue.Text;
					dr[0]["nguoilienhe"] = nguoilienhe.Text;
					dr[0]["ghichu"] = ghichu.Text;
					dr[0]["mmyy"] = s_mmyy;
				}
			}
		}

		private void butdvthem_Click(object sender, EventArgs e)
		{
			if (l_doan == 0) return;
			frmDonvi f = new frmDonvi(m, l_doan, 0, i_userid, dt1, cmbten.Text);
			f.ShowDialog();
			if (f.bOk) load_donvi();
		}

		private void load_donvi()
		{
            sql = "select id,iddoan,stt,ma,ten,to_char(tu,'dd/mm/yyyy') as tu,to_char(den,'dd/mm/yyyy') as den from " + user + ".kskdonvi where iddoan=" + l_doan + " order by stt";
			dt1 = m.get_data(sql).Tables[0];
			dataGrid1.DataSource = dt1;
			l_donvi = (dt1.Rows.Count > 0) ? decimal.Parse(dt1.Rows[0]["id"].ToString()) : 0;
			dataGrid1.CaptionText = "Đơn vị trong đoàn :"+" " + dt1.Rows.Count.ToString();
			if (be) AddGridTableStyle1();
		}

		private void AddGridTableStyle1()
		{
			DataGridTableStyle ts = new DataGridTableStyle();
			ts.MappingName = dt1.TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.ReadOnly = false;
			ts.RowHeaderWidth = 10;

			DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "id";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "stt";
			TextCol.HeaderText = "Stt";
			TextCol.Width = 30;
			TextCol.Alignment = HorizontalAlignment.Right;
			TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Đơn vị";
			TextCol.Width = 225;
			TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "tu";
			TextCol.HeaderText = "Từ ngày";
			TextCol.Width = 65;
			TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "den";
			TextCol.HeaderText = "Đến";
			TextCol.Width = 65;
			TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}

		private void butdvsua_Click(object sender, EventArgs e)
		{
			if (dt1.Rows.Count > 0)
			{
				frmDonvi f = new frmDonvi(m, l_doan,decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,0].ToString()), i_userid, dt1, cmbten.Text);
				f.ShowDialog();
				if (f.bOk) load_donvi();               
			}
		}

		private void butdvxoa_Click(object sender, EventArgs e)
		{
			if (dt1.Rows.Count > 0)
			{
				if (dt2.Select("done=1").Length > 0)
				{
					MessageBox.Show("Đã nhập kết qủa, không được hủy !", LibMedi.AccessData.Msg);
					return;
				}
				if (MessageBox.Show("Đồng ý xóa"+" \n" + dataGrid1[dataGrid1.CurrentCell.RowNumber, 2].ToString() + "?", LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
                    sql = "delete from " + user + ".kskdonvi where id=" + decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 0].ToString());
					m.execute_data(sql);
                    sql = "delete from " + user + ".kskbtdbn where iddonvi=" + decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 0].ToString());
					m.execute_data(sql);
					load_donvi();
					load_danhsach();
				}
			}
		}

		private void load_danhsach()
		{
            sql = "select stt,mabn,hoten,namsinh,phai,mann,dienthoai,diachi,case when phai=0 then 'Nam' else 'Nu ' end as gioitinh,done from " + user + ".kskbtdbn where iddonvi=" + l_donvi + " order by stt";
			dt2 = m.get_data(sql).Tables[0];
			dataGrid2.DataSource = dt2;
			dt1.AcceptChanges();
			dataGrid2.CaptionText = ((dt1.Rows.Count>0)?dataGrid1[dataGrid1.CurrentCell.RowNumber, 2].ToString():"")+ " : " + dt2.Rows.Count.ToString();
			if (be) AddGridTableStyle2();
		}

		private void AddGridTableStyle2()
		{
			DataGridTableStyle ts = new DataGridTableStyle();
			ts.MappingName = dt2.TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.ReadOnly = false;
			ts.RowHeaderWidth = 10;

			DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "stt";
			TextCol.HeaderText = "Stt";
			TextCol.Width = 30;
			TextCol.Alignment = HorizontalAlignment.Right;
			TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "mabn";
			TextCol.HeaderText = "Mã số";
			TextCol.Width = 60;
			TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "hoten";
			TextCol.HeaderText = "Họ và tên";
			TextCol.Width = 225;
			TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "namsinh";
			TextCol.HeaderText = "NS";
			TextCol.Width = 35;
			TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "gioitinh";
			TextCol.HeaderText = "Giới tính";
			TextCol.Width = 35;
			TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "done";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);
		}

		private void butdsthem_Click(object sender, EventArgs e)
		{
			if (dt1.Rows.Count == 0) return;
			l_donvi = decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 0].ToString());
			frmDanhsach f = new frmDanhsach(m, s_mmyy, s_ma + dataGrid1[dataGrid1.CurrentCell.RowNumber, 5].ToString(), "", l_donvi, i_userid, dt2, dataGrid1[dataGrid1.CurrentCell.RowNumber, 2].ToString());
			f.ShowDialog();
			if (f.bOk) load_danhsach();
		}

		private void butdssua_Click(object sender, EventArgs e)
		{
			if (dt1.Rows.Count == 0 || dt2.Rows.Count==0) return;
			l_donvi = decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 0].ToString());
			frmDanhsach f = new frmDanhsach(m,s_mmyy, s_ma + dataGrid1[dataGrid1.CurrentCell.RowNumber, 5].ToString(), dataGrid2[dataGrid2.CurrentCell.RowNumber, 1].ToString(), l_donvi, i_userid, dt2, dataGrid1[dataGrid1.CurrentCell.RowNumber, 2].ToString());
			f.ShowDialog();
			if (f.bOk) load_danhsach();
		}

		private void butdsxoa_Click(object sender, EventArgs e)
		{
			if (dt2.Rows.Count > 0)            
			{
				if (dataGrid2[dataGrid2.CurrentCell.RowNumber, 5].ToString() == "1")
				{
					MessageBox.Show("Đã nhập kết quả, không được hủy !", LibMedi.AccessData.Msg);
					return;
				}
				if (MessageBox.Show("Đồng ý xóa"+" \n" + dataGrid2[dataGrid2.CurrentCell.RowNumber, 2].ToString() + "?", LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
                    sql = "delete from " + user + ".kskbtdbn where mabn='" + dataGrid2[dataGrid2.CurrentCell.RowNumber, 1].ToString() + "' and iddonvi=" + l_donvi;
					m.execute_data(sql);
					load_danhsach();
				}
			}
		}

		private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
		{
			try
			{
				l_donvi = decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 0].ToString());
			}
			catch { l_donvi = 0;}
			load_danhsach();
		}

		private void butFile_Click(object sender, EventArgs e)
		{
			if (dt1.Rows.Count == 0) return;
			l_donvi = decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 0].ToString());
			frmDsexcel f = new frmDsexcel(m, s_mmyy, s_ma + dataGrid1[dataGrid1.CurrentCell.RowNumber, 5].ToString(),l_donvi, i_userid,dataGrid1[dataGrid1.CurrentCell.RowNumber, 2].ToString());
			f.ShowDialog();
			if (f.bOk) load_danhsach();
		}

		private void load_muc()
		{
            sql = "select * from " + user + ".kskmuc where iddoan=" + l_doan + " order by stt";
			dt3 = m.get_data(sql).Tables[0];
			l_muc = (dt3.Rows.Count > 0) ? decimal.Parse(dt3.Rows[0]["id"].ToString()) : 0;
			dataGrid3.DataSource = dt3;
			dataGrid3.CaptionText =	"Mục đăng ký trong đoàn : " + dt3.Rows.Count.ToString();
			if (be) AddGridTableStyle3();
		}

		private void AddGridTableStyle3()
		{
			DataGridTableStyle ts = new DataGridTableStyle();
			ts.MappingName = dt3.TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.ReadOnly = false;
			ts.RowHeaderWidth = 10;

			DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "id";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid3.TableStyles.Add(ts);

			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "stt";
			TextCol.HeaderText = "Stt";
			TextCol.Width = 20;
			TextCol.ReadOnly = true;
			TextCol.Alignment = HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid3.TableStyles.Add(ts);

			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "ghichu";
			TextCol.HeaderText = "Nội dung";
			TextCol.Width = 307;
			TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid3.TableStyles.Add(ts);
		}

		private void butmucthem_Click(object sender, EventArgs e)
		{
			if (l_doan == 0) return;
			frmMuc f = new frmMuc(m,0,l_doan,dt3, cmbten.Text);
			f.ShowDialog();
			if (f.bOk) load_muc();
		}

		private void butmucsua_Click(object sender, EventArgs e)
		{
			if (l_doan == 0 || dt3.Rows.Count==0) return;
			l_muc=decimal.Parse(dataGrid3[dataGrid3.CurrentCell.RowNumber,0].ToString());
			frmMuc f = new frmMuc(m,l_muc, l_doan, dt3, cmbten.Text);
			f.ShowDialog();
			if (f.bOk) load_muc();
		}

		private void butmucxoa_Click(object sender, EventArgs e)
		{
			if (dt3.Rows.Count > 0)
			{
				if (MessageBox.Show("Đồng ý xóa\n" + dataGrid3[dataGrid3.CurrentCell.RowNumber, 2].ToString() + "?", LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
                    sql = "delete from " + user + ".kskmucct where id=" + decimal.Parse(dataGrid3[dataGrid3.CurrentCell.RowNumber, 0].ToString());
					m.execute_data(sql);
                    sql = "delete from " + user + ".kskmuc where id=" + decimal.Parse(dataGrid3[dataGrid3.CurrentCell.RowNumber, 0].ToString());
					m.execute_data(sql);
					load_muc();
					load_mucct();
				}
			}
		}

		private void dataGrid3_CurrentCellChanged(object sender, EventArgs e)
		{
			try
			{
				l_muc = decimal.Parse(dataGrid3[dataGrid3.CurrentCell.RowNumber, 0].ToString());
			}
			catch { l_muc = 0; }
			upd_kskmucct();
			load_mucct();
		}

		private void load_mucct()
		{
            sql = "select a.*,b.ten from " + user + ".kskmucct a," + user + ".v_giavp b where a.mavp=b.id and a.id=" + l_muc + " order by a.stt";
			dt4 = m.get_data(sql).Tables[0];
			dataGrid4.DataSource = dt4;
			dt3.AcceptChanges();
			dataGrid4.CaptionText = ((dt3.Rows.Count > 0) ? dataGrid3[dataGrid3.CurrentCell.RowNumber, 2].ToString() : "") + " : " + dt4.Rows.Count.ToString();
			if (be) AddGridTableStyle4();
		}

		private void AddGridTableStyle4()
		{
			DataGridTableStyle ts = new DataGridTableStyle();
			ts.MappingName = dt4.TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.ReadOnly = false;
			ts.RowHeaderWidth = 10;

			DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "mavp";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.Alignment = HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid4.TableStyles.Add(ts);

			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "stt";
			TextCol.HeaderText = "Stt";
			TextCol.Width = 20;
			TextCol.ReadOnly = true;
			TextCol.Alignment = HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid4.TableStyles.Add(ts);

			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Nội dung";
			TextCol.Width = 130;
			TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid4.TableStyles.Add(ts);

			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "gia_nv";
			TextCol.HeaderText = "Nội viện";
			TextCol.Width = 50;
			TextCol.Alignment = HorizontalAlignment.Right;
			TextCol.Format = "### ### ### ###";
			ts.GridColumnStyles.Add(TextCol);
			dataGrid4.TableStyles.Add(ts);

			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "gia_ngv";
			TextCol.HeaderText = "Ngoại viện";
			TextCol.Width = 50;
			TextCol.Alignment = HorizontalAlignment.Right;
			TextCol.Format = "### ### ### ###";
			ts.GridColumnStyles.Add(TextCol);
			dataGrid4.TableStyles.Add(ts);

			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "ghichu";
			TextCol.HeaderText = "Ghi chú";
			TextCol.Width = 75;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid4.TableStyles.Add(ts);
		}

		private void butctthem_Click(object sender, EventArgs e)
		{
			if (l_muc == 0) return;
			frmChidinh_ksk f = new frmChidinh_ksk(m);
			f.ShowDialog();
			if (f.dt.Rows.Count > 0)
			{
				int stt = 1;
				if (dt4.Rows.Count > 0) stt = int.Parse(dt4.Rows[dt4.Rows.Count - 1]["stt"].ToString()) + 1;
				DataRow r1;
				foreach (DataRow r in f.dt.Rows)
				{
					r1 = m.getrowbyid(dtgia, "id=" + decimal.Parse(r["mavp"].ToString()));
					if (r1!=null)
						m.upd_kskmucct(l_muc, decimal.Parse(r["mavp"].ToString()), stt++, decimal.Parse(r["dongia"].ToString()), decimal.Parse(r["vattu"].ToString()),"");
				}
				load_mucct();
			}
		}

		private void butctxoa_Click(object sender, EventArgs e)
		{
			if (dt4.Rows.Count > 0)
			{
				try
				{
					if (MessageBox.Show("Đồng ý xóa\n" + dataGrid4[dataGrid4.CurrentCell.RowNumber, 2].ToString() + "?", LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
                        sql = "delete from " + user + ".kskmucct where id=" + l_muc + " and mavp=" + decimal.Parse(dataGrid4[dataGrid4.CurrentCell.RowNumber, 0].ToString());
						m.execute_data(sql);
						m.delrec(dt4, "id=" + l_muc + " and mavp=" + decimal.Parse(dataGrid4[dataGrid4.CurrentCell.RowNumber, 0].ToString()));
						dt4.AcceptChanges();
					}
				}
				catch { }
			}
		}

		private void tim_TextChanged(object sender, EventArgs e)
		{
			if (this.ActiveControl == tim) RefreshChildren(tim.Text);
		}

		private void tim_Enter(object sender, EventArgs e)
		{
			tim.Text = "";
		}

		public void RefreshChildren(string text)
		{
			try
			{
				CurrencyManager cm = (CurrencyManager)BindingContext[cmbten.DataSource];
				DataView dv = (DataView)cm.List;
				dv.RowFilter = "ten like '%" + text.Trim() + "%' or sohd like '%" + text + "%'";
				if (cmbten.Items.Count > 0) l_doan = decimal.Parse(cmbten.SelectedValue.ToString());
				else l_doan = 0;                
			}
			catch { l_doan = 0; }
			load_doan();
		}

		private void upd_kskmucct()
		{
			dt4.AcceptChanges();
			foreach (DataRow r in dt4.Rows)
				m.upd_kskmucct(decimal.Parse(r["id"].ToString()), decimal.Parse(r["mavp"].ToString()), decimal.Parse(r["stt"].ToString()),(r["gia_nv"].ToString()=="")?0:decimal.Parse(r["gia_nv"].ToString()),(r["gia_ngv"].ToString()=="")?0:decimal.Parse(r["gia_ngv"].ToString()), r["ghichu"].ToString());
		}

		private void chkAlldv_CheckedChanged(object sender, EventArgs e)
		{
			if (this.ActiveControl == chkAlldv && chkAlldv.Checked && chkAll.Checked) chkAll.Checked = false;
		}

		private void chkAll_CheckedChanged(object sender, EventArgs e)
		{
			if (this.ActiveControl == chkAll && chkAlldv.Checked && chkAll.Checked) chkAlldv.Checked = false;
		}

		private void butIn_Click(object sender, EventArgs e)
		{
			/*
			dsxml.Clear();
			if (cmbten.SelectedIndex == -1) return;
			string s = "'",xxx=user+s_mmyy,_ngay=m.ngayhienhanh_server.Substring(0,10);
			decimal l_id=0;
			if (chkAll.Checked) s = "','";
			else if (chkAlldv.Checked) foreach (DataRow r in dt2.Rows) s += r["mabn"].ToString() + "','";
			else if (dt2.Rows.Count > 0) s += dataGrid2[dataGrid2.CurrentCell.RowNumber, 1].ToString() + "','";
			if (s.Length > 1)
			{
				s = s.Substring(0, s.Length - 2);
				sql = "select f.ten as donvi,a.mabn,a.hoten,a.namsinh,a.phai,a.iddonvi";
				sql += " from " + xxx + ".kskbtdbn a inner join kskdonvi f on a.iddonvi=f.id ";
				if (chkAll.Checked) sql += " where f.iddoan=" + l_doan;
				else sql += " where a.mabn in (" + s + ")";
				sql += " order by f.stt,a.stt";
				dtmuc = m.get_data("select * from kskmuc where iddoan=" + l_doan + " order by stt").Tables[0];
				dtmucct = m.get_data("select b.*,c.ten from kskmuc a,kskmucct b,v_giavp c where a.id=b.id and b.mavp=c.id and a.iddoan=" + l_doan + " order by b.stt").Tables[0];
				foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					barcode.Text = r["mabn"].ToString();
					barcode.Update();
					barcode.Picture.Save("..//..//..//xml//barcode.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
					fstr = new FileStream("..//..//..//xml//barcode.bmp", FileMode.Open, FileAccess.Read);
					imagemabn = new byte[fstr.Length];
					fstr.Read(imagemabn, 0, System.Convert.ToInt32(fstr.Length));
					fstr.Dispose();
					fstr.Close();
					updrec(cmbten.Text.ToUpper(),r["donvi"].ToString(),r["mabn"].ToString(),r["hoten"].ToString(),r["namsinh"].ToString(),int.Parse(r["phai"].ToString()));
					//
					if (m.get_data("select id from " + xxx + ".kskketqua where mabn='" + r["mabn"].ToString() + "' and iddonvi=" + decimal.Parse(r["iddonvi"].ToString())).Tables[0].Rows.Count==0)
					{
						l_id = m.get_id_kskketqua;
						m.upd_kskketqua(s_mmyy, l_id, decimal.Parse(r["iddonvi"].ToString()), r["mabn"].ToString(), _ngay,"",i_loai,"", i_userid);
						foreach (DataRow r1 in dsxml.Tables[0].Select("mabn='"+r["mabn"].ToString()+"'","stt"))
							m.upd_kskchitiet(s_mmyy, l_id, int.Parse(r1["stt"].ToString()), decimal.Parse(r1["mavp"].ToString()), r1["ten"].ToString(), decimal.Parse(r1["dongia"].ToString()), 0, "", "", "");
					}
					//
				}
				if (dsxml.Tables[0].Rows.Count > 0)
				{
					frmReport f = new frmReport(m, dsxml, cmbten.Text.ToUpper(), "rptPhieuksk.rpt");
					f.ShowDialog();
				}
				else MessageBox.Show("Không có số liệu !", LibMedi.AccessData.Msg);
			}
			else MessageBox.Show("Không có số liệu !", LibMedi.AccessData.Msg);
					 */
		}

		private void updrec(string doan,string donvi,string mabn,string hoten,string namsinh,int phai)
		{
			DataRow[] dr;
			bool bFound = false;
			sql = "true";
			if (phai != -1) sql += " and phai=" + phai;
			foreach (DataRow r2 in dtmuc.Select(sql, "stt"))
			{
				sql = "true";
				if (phai != -1) sql += " and phai=" + phai;
				if (namsinh != "") sql += " and namsinh<>'' and namsinh" + r2["tt"].ToString().Trim() + "'" + namsinh + "'";
				foreach (DataRow r in dtmuc.Select(sql, "stt"))
				{
					sql = "true";
					if (phai != -1) sql += " and phai=" + phai;
					if (namsinh != "" && r["namsinh"].ToString() != "") sql += " and namsinh" + r["tt"].ToString().Trim() + "'" + namsinh + "'";
					dr = dtmuc.Select(sql);
					if (dr.Length > 0)
					{
						ins_items(doan,donvi,mabn,hoten,namsinh,phai,decimal.Parse(r["id"].ToString()));
						bFound = true;
						break;
					}
				}
				if (bFound) break;
			}
			if (!bFound)
			{
				sql = "true";
				if (phai != -1) sql += " and phai=" + phai;
				foreach (DataRow r in dtmuc.Select(sql, "phai,namsinh,stt"))
				{
					sql = "true";
					if (phai != -1 && r["phai"].ToString() != "-1") sql += " and phai=" + phai;
					if (namsinh != "" && r["namsinh"].ToString() != "") sql += " and namsinh" + r["tt"].ToString().Trim() + "'" + namsinh + "'";
					dr = dtmuc.Select(sql);
					if (dr.Length > 0)
					{
						ins_items(doan,donvi, mabn, hoten, namsinh, phai, decimal.Parse(r["id"].ToString()));
						break;
					}
				}
			}
		}

		private void ins_items(string doan,string donvi,string mabn,string hoten,string namsinh,int phai,decimal id)
		{
			DataRow r2;
			foreach (DataRow r1 in dtmucct.Select("id=" + id, "stt"))
			{
				r2 = dsxml.Tables[0].NewRow();
				r2["doan"] = doan;
				r2["donvi"] = donvi.ToUpper();
				r2["mabn"] = mabn;
				r2["hoten"] = hoten;
				r2["namsinh"] = namsinh;
				r2["phai"] = (phai == 1) ? "Nữ" : "Nam";
				r2["luuy"] = ghichu.Text;
				r2["image"] = imagemabn;
				r2["stt"] = r1["stt"].ToString();
				r2["mavp"] = r1["mavp"].ToString();
				r2["ten"] = r1["ten"].ToString();
				r2["dongia"] = (loai.SelectedIndex == 0) ? r1["gia_nv"].ToString() : r1["gia_ngv"].ToString();
				r2["ghichu"] = r1["ghichu"].ToString();
				dsxml.Tables[0].Rows.Add(r2);
			}
		}

        private void ghichu_TextChanged(object sender, EventArgs e)
        {
            if (ghichu.Text == "\r\n") SendKeys.Send("{Tab}");
        }
	}

}
