using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
namespace Duoc
{
	/// <summary>
	/// Summary description for frmDm.
	/// </summary>
	public class frmDuockp : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
		private DataTable dt=new DataTable();
		private DataSet dsxml=new DataSet();
		private DataRow r;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown stt;
		private int i_id,i_matutruc,i_nhom, i_khu,i_userid=0;
		private string table,s_makho,s_nhomkho,sql,user,d_mmyy,s_tutruc="",s_phieu,s_loai, s_khudt="";
		private System.Windows.Forms.TextBox ten;
		private System.Windows.Forms.TextBox ma;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.CheckedListBox makho;
		private DataTable dtkho=new DataTable();
		private DataTable dtnhom=new DataTable();
        private DataTable dttt = new DataTable();
        private DataTable dtphieu = new DataTable();
        private DataTable dtloai = new DataTable();
		private System.Windows.Forms.CheckedListBox nhomkho;
        private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox nguoilinh;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.CheckBox chkAll;
		private System.Windows.Forms.ComboBox computer;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.NumericUpDown somay;
        private CheckedListBox matutruc;
        private CheckedListBox loaiphieu;
        private CheckedListBox phieu;
        private ComboBox khudt;
        private Label label8;
        private int i_chinhanh=0;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDuockp(AccessData acc,string tab,string title,int nhom,string mmyy, int _userid, int _chinhanh)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
            this.Text = title; d_mmyy = mmyy;
			table=tab;i_nhom=nhom;
            i_userid = _userid;
            s_khudt = d.f_get_khudt(i_userid);
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            i_chinhanh = _chinhanh;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDuockp));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ten = new System.Windows.Forms.TextBox();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.stt = new System.Windows.Forms.NumericUpDown();
            this.ma = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.ComboBox();
            this.makho = new System.Windows.Forms.CheckedListBox();
            this.nhomkho = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nguoilinh = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.computer = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.somay = new System.Windows.Forms.NumericUpDown();
            this.matutruc = new System.Windows.Forms.CheckedListBox();
            this.loaiphieu = new System.Windows.Forms.CheckedListBox();
            this.phieu = new System.Windows.Forms.CheckedListBox();
            this.khudt = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.somay)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGrid1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid1.Location = new System.Drawing.Point(5, -13);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(490, 499);
            this.dataGrid1.TabIndex = 19;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(562, 540);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 14;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(241, 492);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 23;
            this.label2.Text = "Tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ten
            // 
            this.ten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(275, 492);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(220, 21);
            this.ten.TabIndex = 2;
            this.ten.Validated += new System.EventHandler(this.ten_Validated);
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.Image = global::Duoc.Properties.Resources.add;
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(212, 540);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 11;
            this.butMoi.Text = "      &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = global::Duoc.Properties.Resources.quick_edit;
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(282, 540);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 12;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = global::Duoc.Properties.Resources.save;
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(352, 540);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 9;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = global::Duoc.Properties.Resources.undo_ok;
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(422, 540);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 10;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = global::Duoc.Properties.Resources.delete_enabled;
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(492, 540);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 13;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(7, 493);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 19);
            this.label3.TabIndex = 24;
            this.label3.Text = "STT :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // stt
            // 
            this.stt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stt.Enabled = false;
            this.stt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stt.Location = new System.Drawing.Point(57, 492);
            this.stt.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(50, 21);
            this.stt.TabIndex = 0;
            this.stt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // ma
            // 
            this.ma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ma.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ma.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ma.Enabled = false;
            this.ma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ma.Location = new System.Drawing.Point(140, 492);
            this.ma.MaxLength = 50;
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(78, 21);
            this.ma.TabIndex = 1;
            this.ma.TextChanged += new System.EventHandler(this.ma_TextChanged);
            this.ma.Validated += new System.EventHandler(this.ma_Validated);
            this.ma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(98, 492);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 26;
            this.label1.Text = "Mã :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Location = new System.Drawing.Point(494, 492);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 23);
            this.label4.TabIndex = 27;
            this.label4.Text = "Khoa lâm sàng :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.Enabled = false;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(585, 491);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(204, 21);
            this.makp.TabIndex = 3;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // makho
            // 
            this.makho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makho.CheckOnClick = true;
            this.makho.Enabled = false;
            this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.Location = new System.Drawing.Point(500, 142);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(147, 132);
            this.makho.TabIndex = 28;
            // 
            // nhomkho
            // 
            this.nhomkho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhomkho.CheckOnClick = true;
            this.nhomkho.Enabled = false;
            this.nhomkho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhomkho.Location = new System.Drawing.Point(500, 6);
            this.nhomkho.Name = "nhomkho";
            this.nhomkho.Size = new System.Drawing.Size(147, 132);
            this.nhomkho.TabIndex = 29;
            this.nhomkho.SelectedIndexChanged += new System.EventHandler(this.nhomkho_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(501, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 22);
            this.label5.TabIndex = 30;
            this.label5.Text = "Sử dụng thêm tủ trực :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nguoilinh
            // 
            this.nguoilinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nguoilinh.Enabled = false;
            this.nguoilinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nguoilinh.Location = new System.Drawing.Point(58, 515);
            this.nguoilinh.Name = "nguoilinh";
            this.nguoilinh.Size = new System.Drawing.Size(160, 21);
            this.nguoilinh.TabIndex = 5;
            this.nguoilinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.Location = new System.Drawing.Point(-4, 516);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 23);
            this.label11.TabIndex = 31;
            this.label11.Text = "Người lĩnh :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkAll
            // 
            this.chkAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAll.Location = new System.Drawing.Point(708, 546);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(104, 19);
            this.chkAll.TabIndex = 32;
            this.chkAll.Text = "Xem tất cả";
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // computer
            // 
            this.computer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.computer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.computer.Enabled = false;
            this.computer.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.computer.Location = new System.Drawing.Point(275, 515);
            this.computer.Name = "computer";
            this.computer.Size = new System.Drawing.Size(220, 21);
            this.computer.TabIndex = 6;
            this.computer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.Location = new System.Drawing.Point(217, 514);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 23);
            this.label6.TabIndex = 34;
            this.label6.Text = "Tên máy :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.Location = new System.Drawing.Point(687, 514);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 23);
            this.label7.TabIndex = 35;
            this.label7.Text = "Số máy :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // somay
            // 
            this.somay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.somay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.somay.Enabled = false;
            this.somay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.somay.Location = new System.Drawing.Point(749, 514);
            this.somay.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.somay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.somay.Name = "somay";
            this.somay.Size = new System.Drawing.Size(40, 21);
            this.somay.TabIndex = 8;
            this.somay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.somay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // matutruc
            // 
            this.matutruc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.matutruc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.matutruc.CheckOnClick = true;
            this.matutruc.Enabled = false;
            this.matutruc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matutruc.Location = new System.Drawing.Point(501, 298);
            this.matutruc.Name = "matutruc";
            this.matutruc.Size = new System.Drawing.Size(147, 180);
            this.matutruc.TabIndex = 36;
            // 
            // loaiphieu
            // 
            this.loaiphieu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.loaiphieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaiphieu.CheckOnClick = true;
            this.loaiphieu.Enabled = false;
            this.loaiphieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaiphieu.Location = new System.Drawing.Point(649, 139);
            this.loaiphieu.Name = "loaiphieu";
            this.loaiphieu.Size = new System.Drawing.Size(140, 340);
            this.loaiphieu.TabIndex = 38;
            // 
            // phieu
            // 
            this.phieu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.phieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phieu.CheckOnClick = true;
            this.phieu.Enabled = false;
            this.phieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phieu.Location = new System.Drawing.Point(649, 6);
            this.phieu.Name = "phieu";
            this.phieu.Size = new System.Drawing.Size(140, 132);
            this.phieu.TabIndex = 37;
            this.phieu.SelectedIndexChanged += new System.EventHandler(this.phieu_SelectedIndexChanged);
            // 
            // khudt
            // 
            this.khudt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.khudt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.khudt.Enabled = false;
            this.khudt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khudt.Location = new System.Drawing.Point(585, 514);
            this.khudt.Name = "khudt";
            this.khudt.Size = new System.Drawing.Size(111, 21);
            this.khudt.TabIndex = 7;
            this.khudt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.Location = new System.Drawing.Point(497, 514);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 23);
            this.label8.TabIndex = 40;
            this.label8.Text = "Cơ sở (khu) :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmDuockp
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.khudt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nguoilinh);
            this.Controls.Add(this.loaiphieu);
            this.Controls.Add(this.phieu);
            this.Controls.Add(this.matutruc);
            this.Controls.Add(this.somay);
            this.Controls.Add(this.computer);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.stt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nhomkho);
            this.Controls.Add(this.makho);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ma);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDuockp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục khoa/phòng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDuockp_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDuockp_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.somay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmDuockp_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = d.user;
            f_capnhat_db();
            //
			dsxml.ReadXml("..\\..\\..\\xml\\d_danhmuc.xml");
			r=d.getrowbyid(dsxml.Tables[0],"table='"+table+"'");
			makho.DisplayMember="TEN";
			makho.ValueMember="ID";

			computer.DisplayMember="COMPUTER";
			computer.ValueMember="COMPUTER";
			computer.DataSource=d.get_data("select distinct computer from "+user+".dmcomputer order by computer").Tables[0];

            dtnhom = d.get_data("select * from " + user + ".d_dmnhomkho order by stt").Tables[0];
			nhomkho.DataSource=dtnhom;
            nhomkho.DisplayMember = "TEN";
            nhomkho.ValueMember = "ID";

            sql = "select * from " + user + ".d_duockp ";
            sql += " where nhom like '%" + i_nhom.ToString().Trim() + "%'";
            sql += " order by stt";
            dttt = d.get_data(sql).Tables[0];
            matutruc.DataSource = dttt;
			matutruc.DisplayMember="TEN";
			matutruc.ValueMember="ID";

            dtphieu = d.get_data("select * from " + user + ".d_dmphieu where id<5 order by stt").Tables[0];
            phieu.DataSource = dtphieu;
            phieu.DisplayMember = "TEN";
            phieu.ValueMember = "ID";

            loaiphieu.DisplayMember = "TEN";
            loaiphieu.ValueMember = "ID";

            sql="select * from " + user + ".btdkp_bv ";
            if (i_chinhanh > 0) sql += " where chinhanh=" + i_chinhanh;
                
            sql += " order by loai,makp";
            makp.DataSource = d.get_data(sql).Tables[0];
            makp.DisplayMember = "TENKP";
            makp.ValueMember = "MAKP";


            sql = "select * from " + user + ".dmkhudt ";
            if (s_khudt.Trim().Trim(',') != "") sql += " where  id in(" + s_khudt.Trim().Trim(',') + ")";
            khudt.DataSource = d.get_data(sql).Tables[0];
            khudt.DisplayMember = "TEN";
            khudt.ValueMember = "ID";

			load_grid(chkAll.Checked);
			AddGridTableStyle();
			ref_text();
		}

		private void load_grid(bool all)
		{
            sql = "select a.*,nullif(b.tenkp,' ') as tenkp,nullif(c.ten,' ') as tentutruc from " + user + "." + table + " a left join " + user + ".btdkp_bv b on a.makp=b.makp left join " + user + ".d_duockp c on a.matutruc=c.id ";
			if (!all) sql+=" where a.nhom like '%"+i_nhom.ToString().Trim()+"%'";
            if (s_khudt.Trim().Trim(',') != "") sql += " and (a.khu=0 or a.khu in(" + s_khudt.Trim().Trim(',') + "))";
			sql+=" order by a.stt";
			dt=d.get_data(sql).Tables[0];
			dataGrid1.DataSource=dt;
            makp.DisplayMember = "TENKP";
            makp.ValueMember = "MAKP";
            sql = "select * from " + user + ".d_duockp ";
			if (!all) sql+=" where nhom like '%"+i_nhom.ToString().Trim()+"%'";
            if (s_khudt.Trim().Trim(',') != "") sql += " and (khu=0 or khu in(" + s_khudt.Trim().Trim(',') + "))";
			sql+=" order by stt";
            dttt = d.get_data(sql).Tables[0];
			matutruc.DataSource=dttt;
            matutruc.DisplayMember = "TEN";
            matutruc.ValueMember = "ID";
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dt.TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.ReadOnly=false;
			ts.RowHeaderWidth=10;
						
			DataGridTextBoxColumn TextCol=new DataGridTextBoxColumn();
            TextCol.MappingName = "id";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "stt";
			TextCol.HeaderText = "STT";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Nội dung";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenkp";
			TextCol.HeaderText = "Khoa lâm sàng";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "khu";
            TextCol.HeaderText = "CS";
            TextCol.Width = 30;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void ten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ena_object(bool ena)
		{
			dataGrid1.Enabled=!ena;
			makho.Enabled=ena;
			nhomkho.Enabled=ena;
			stt.Enabled=ena;
			ma.Enabled=ena;
			ten.Enabled=ena;
            khudt.Enabled = (khudt.Items.Count > 0) ? ena : false;
			phieu.Enabled=loaiphieu.Enabled=makp.Enabled=ena;
			nguoilinh.Enabled=ena;
			matutruc.Enabled=ena;
			computer.Enabled=ena;
			somay.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			try
			{
                stt.Value = decimal.Parse(d.get_data("select max(stt) from " + user + "." + table).Tables[0].Rows[0][0].ToString()) + 1;
			}
			catch{stt.Value=1;}
			i_id=0;
			ma.Text="";
			ten.Text="";
			nguoilinh.Text="";
			makp.SelectedIndex=-1;
			somay.Value=1;
			for(int k=0;k<makho.Items.Count;k++) makho.SetItemCheckState(k,CheckState.Unchecked);
			for(int k=0;k<nhomkho.Items.Count;k++) nhomkho.SetItemCheckState(k,CheckState.Unchecked);
            for (int k = 0; k < matutruc.Items.Count; k++) matutruc.SetItemCheckState(k, CheckState.Unchecked);
            for (int k = 0; k < phieu.Items.Count; k++) phieu.SetItemCheckState(k, CheckState.Unchecked);
            for (int k = 0; k < loaiphieu.Items.Count; k++) loaiphieu.SetItemCheckState(k, CheckState.Unchecked);
			ena_object(true);
			matutruc.Enabled=false;
			stt.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (dt.Rows.Count==0) return;
			i_id=int.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,0].ToString());
			ena_object(true);
			stt.Focus();
		}

		private bool kiemtra()
		{
			if (ma.Text=="")
			{
				ma.Focus();
				return false;
			}
			if (ten.Text=="")
			{
				ten.Focus();
				return false;
			}
			if (computer.SelectedIndex==-1)
			{
				computer.Focus();
				return false;
			}
			s_nhomkho="";
			for(int i=0;i<nhomkho.Items.Count;i++)
				if (nhomkho.GetItemChecked(i)) s_nhomkho+=dtnhom.Rows[i]["id"].ToString().Trim()+",";
			s_makho="";
			for(int i=0;i<makho.Items.Count;i++)
				if (makho.GetItemChecked(i)) s_makho+=dtkho.Rows[i]["id"].ToString().Trim()+",";
            s_tutruc = "";
            for (int i = 0; i < matutruc.Items.Count; i++)
                if (matutruc.GetItemChecked(i)) s_tutruc += dttt.Rows[i]["id"].ToString().Trim() + ",";
            s_phieu = "";
            for (int i = 0; i < phieu.Items.Count; i++)
                if (phieu.GetItemChecked(i)) s_phieu += dtphieu.Rows[i]["id"].ToString().Trim() + ",";
            s_loai = "";
            for (int i = 0; i < loaiphieu.Items.Count; i++)
                if (loaiphieu.GetItemChecked(i)) s_loai += dtloai.Rows[i]["id"].ToString().Trim().PadLeft(3, '0') + ",";

            if (khudt.Items.Count > 0 && khudt.SelectedIndex < 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Đề nghị chọn cơ sở!"), LibMedi.AccessData.Msg);
                khudt.Focus();
                return false;
            }
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			if (i_id==0)
			{
                try
                {
                    //Tu: 18/08/2011
                    int id_duockp = 0, id_capid = 0;
                    try { id_duockp = int.Parse(d.get_data("select max(id) as id from " + user + ".d_duockp").Tables[0].Rows[0][0].ToString()); }
                    catch { id_duockp = 1; }
                    try { id_capid = int.Parse(d.get_data("select id from " + user + ".d_capid where ma=999").Tables[0].Rows[0][0].ToString()); }
                    catch { id_capid = 1; }
                    try
                    {
                        ////if (id_capid < id_duockp)
                        ////    d.execute_data("update " + user + ".d_capid set id=" + id_duockp + " where ma=999");
                    }
                    catch { }
                    //end Tu

                    // hien: 03-06-2011 cap lai id khoa phong
                    int i_chinhanh_hientai = d.i_Chinhanh_hientai;
                    if (i_chinhanh_hientai == -1) i_chinhanh_hientai = 0;
                    if (i_chinhanh_hientai == 0)
                    {
                        i_id = int.Parse(d.get_capid(999).ToString().PadLeft(3, '0'));// int.Parse(d.get_data("select max(id) from " + user + "." + table).Tables[0].Rows[0][0].ToString()) + 1;
                    }
                    else
                    {
                        i_id = int.Parse(i_chinhanh_hientai.ToString() + d.get_capid(999).ToString().PadLeft(3, '0'));
                    }
                    //end
                }
                catch { i_id = 1; }
			}
			if (matutruc.SelectedIndex!=-1) i_matutruc=int.Parse(matutruc.SelectedValue.ToString()); 
			else i_matutruc=0;
            i_khu = (khudt.Items.Count == 0 || khudt.SelectedIndex < 0) ? 0 : int.Parse(khudt.SelectedValue.ToString());
            if (!d.upd_duockp(i_id,ma.Text,ten.Text,s_nhomkho,int.Parse(stt.Value.ToString()),(makp.SelectedIndex==-1)?"":makp.SelectedValue.ToString(),s_makho,i_matutruc,nguoilinh.Text,computer.SelectedValue.ToString(),Convert.ToInt16(somay.Value)))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật thông tin")+" "+this.Text.Trim()+" !",d.Msg);
				return;
			}
            d.execute_data("update "+user+".d_duockp set tutruc='" + ((s_tutruc != "") ? s_tutruc.Substring(0, s_tutruc.Length - 1) : "") + "',phieu='"+s_phieu+"',loaiphieu='"+s_loai+"' where id=" + i_id);
			load_grid(chkAll.Checked);
			ena_object(false);
			ref_text();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ref_text();
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (dt.Rows.Count==1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cho phép hủy ?"),d.Msg);
				return;
			}	
			try
			{
				if (r!=null)
				{
                    sql = r["sql"].ToString();
                    if (sql.IndexOf("xxx") != -1) sql = sql.Replace("xxx", user + d_mmyy);
                    else sql = sql.Replace("yyy", user);
					if (d.get_data(sql+decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,0].ToString())).Tables[0].Rows.Count!=0)
					{
						MessageBox.Show(lan.Change_language_MessageText("Nội dung đang sử dụng không cho phép hủy !"),d.Msg);
						return;
					}
				}
			}
			catch{}
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này !"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
				d.execute_data("delete from "+user+"."+table+" where id="+decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,0].ToString()));
				load_grid(chkAll.Checked);
			}
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
                decimal id = decimal.Parse(dataGrid1[i, 0].ToString());
                DataRow r = d.getrowbyid(dt, "id=" + id);
                if (r != null)
                {
                    stt.Value = decimal.Parse(r["stt"].ToString());
                    ma.Text = r["ma"].ToString();
                    ten.Text = r["ten"].ToString();
                    makp.SelectedValue = r["makp"].ToString();
                    s_makho = "," + r["makho"].ToString();
                    s_nhomkho = "," + r["nhom"].ToString();
                    for (int j = 0; j < dtnhom.Rows.Count; j++)
                        if (s_nhomkho.IndexOf("," + dtnhom.Rows[j]["id"].ToString().Trim() + ",") != -1) nhomkho.SetItemCheckState(j, CheckState.Checked);
                        else nhomkho.SetItemCheckState(j, CheckState.Unchecked);
                    load_dmkho(r["nhom"].ToString());
                    for (int j = 0; j < dtkho.Rows.Count; j++)
                        if (s_makho.IndexOf("," + dtkho.Rows[j]["id"].ToString().Trim() + ",") != -1) makho.SetItemCheckState(j, CheckState.Checked);
                        else makho.SetItemCheckState(j, CheckState.Unchecked);
                    if (r["matutruc"].ToString() != "0") matutruc.SelectedValue = r["matutruc"].ToString();
                    else matutruc.SelectedIndex = -1;
                    nguoilinh.Text = r["nguoilinh"].ToString();
                    computer.SelectedValue = r["computer"].ToString();
                    somay.Value = int.Parse(r["somay"].ToString());
                    s_tutruc = "," + r["tutruc"].ToString() + ",";
                    for (int j = 0; j < dttt.Rows.Count; j++)
                        if (s_tutruc.IndexOf("," + dttt.Rows[j]["id"].ToString().Trim() + ",") != -1) matutruc.SetItemCheckState(j, CheckState.Checked);
                        else matutruc.SetItemCheckState(j, CheckState.Unchecked);
                    s_phieu = r["phieu"].ToString(); s_loai = r["loaiphieu"].ToString();
                    for (int k = 0; k < phieu.Items.Count; k++) phieu.SetItemCheckState(k, CheckState.Unchecked);
                    for (int k = 0; k < loaiphieu.Items.Count; k++) loaiphieu.SetItemCheckState(k, CheckState.Unchecked);
                    for (int j = 0; j < dtphieu.Rows.Count; j++)
                        if (s_phieu.IndexOf(dtphieu.Rows[j]["id"].ToString().Trim() + ",") != -1) phieu.SetItemCheckState(j, CheckState.Checked);
                        else phieu.SetItemCheckState(j, CheckState.Unchecked);
                    load_loai();
                    for (int j = 0; j < dtloai.Rows.Count; j++)
                        if (s_loai.IndexOf(dtloai.Rows[j]["id"].ToString().Trim().PadLeft(3, '0') + ",") != -1) loaiphieu.SetItemCheckState(j, CheckState.Checked);
                        else loaiphieu.SetItemCheckState(j, CheckState.Unchecked);

                    i_khu = (r["khu"].ToString() == "") ? 0 : int.Parse(r["khu"].ToString());
                    khudt.SelectedValue = i_khu;
                }
			}
			catch{}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void frmDuockp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

		private void stt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void ma_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");	
		}

		private void ma_Validated(object sender, System.EventArgs e)
		{
			if (ma.Text!="" && i_id==0)
			{
				DataRow r1=d.getrowbyid(dt,"ma='"+ma.Text+"'");
				if (r1!=null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Mã này đã nhập !"),d.Msg);
					ma.Focus();
					return;
				}
				if (ten.Text=="") ten.Text=ma.Text;
			}
		}

		private void ten_Validated(object sender, System.EventArgs e)
		{
			if (i_id==0 && ten.Text!="")
			{
				DataRow r1=d.getrowbyid(dt,"ten='"+ten.Text+"'");
				if (r1!=null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Nội dung đã nhập !"),d.Msg);
					ten.Focus();
				}
			}
		}

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void nhomkho_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (this.ActiveControl == nhomkho)
            {
                load_dmkho("");
                //
                int i = dataGrid1.CurrentCell.RowNumber;
                decimal id = decimal.Parse(dataGrid1[i, 0].ToString());
                DataRow r = d.getrowbyid(dt, "id=" + id);
                if (r != null)
                {
                    s_makho = "," + r["makho"].ToString();
                    s_tutruc = "," + r["tutruc"].ToString() + ",";
                    for (int j = 0; j < dtkho.Rows.Count; j++)
                        if (s_makho.IndexOf("," + dtkho.Rows[j]["id"].ToString().Trim() + ",") != -1) makho.SetItemCheckState(j, CheckState.Checked);
                        else makho.SetItemCheckState(j, CheckState.Unchecked);
                    for (int j = 0; j < dttt.Rows.Count; j++)
                        if (s_tutruc.IndexOf("," + dttt.Rows[j]["id"].ToString().Trim() + ",") != -1) matutruc.SetItemCheckState(j, CheckState.Checked);
                        else matutruc.SetItemCheckState(j, CheckState.Unchecked);
                }
            }
		}

		private void load_dmkho(string nhom)
		{
			s_nhomkho=nhom;
			if (s_nhomkho=="") for(int i=0;i<nhomkho.Items.Count;i++) if (nhomkho.GetItemChecked(i)) s_nhomkho+=dtnhom.Rows[i]["id"].ToString().Trim()+",";
            sql = "select * from " + user + ".d_dmkho where hide=0 ";
            if (s_nhomkho != "") sql += " and nhom in (" + s_nhomkho.Substring(0, s_nhomkho.Length - 1) + ")";
            if (i_chinhanh > 0) sql += " and chinhanh=" + i_chinhanh;
			sql+=" order by nhom,stt";
			dtkho=d.get_data(sql).Tables[0];
			makho.DataSource=dtkho;
            makho.DisplayMember = "TEN";
            makho.ValueMember = "ID";
		}

		private void matutruc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (matutruc.SelectedIndex==-1 && matutruc.Items.Count>0) matutruc.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void chkAll_CheckedChanged(object sender, System.EventArgs e)
		{
			load_grid(chkAll.Checked);
		}

        private void phieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == phieu) load_loai();
        }

        private void load_loai()
        {
            s_phieu = "";
            for (int i = 0; i < phieu.Items.Count; i++) if (phieu.GetItemChecked(i)) s_phieu += dtphieu.Rows[i]["id"].ToString().Trim() + ",";
            sql = "select a.id,trim(a.ten) as ten from " + user + ".d_loaiphieu a," + user + ".d_dmphieu b where a.loai=b.id and a.nhom=" + i_nhom;
            if (s_phieu != "") sql += " and a.loai in (" + s_phieu.Substring(0, s_phieu.Length - 1) + ")";
            else sql += " and a.loai=-1";
            sql += " order by a.loai,a.stt";
            dtloai = d.get_data(sql).Tables[0];
            loaiphieu.DataSource = dtloai;
            loaiphieu.DisplayMember = "TEN";
            loaiphieu.ValueMember = "ID";
        }

        private void f_capnhat_db()
        {
            if (i_chinhanh > 0)
            {
                sql = "alter table medibv.d_duockp alter column makp type varchar(3) ";
                d.execute_data(sql);
            }
            sql = "select chinhanh from " + user + ".d_duockp where 1=2";
            DataSet lds = d.get_data(sql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                sql = "alter table " + user + ".d_duockp add chinhanh number(2) default 0";
                d.execute_data(sql);
            }

        }

        private void ma_TextChanged(object sender, EventArgs e)
        {

        }
	}
}
