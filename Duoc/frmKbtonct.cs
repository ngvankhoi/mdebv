using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using CrystalDecisions.CrystalReports.Engine;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmNhap.
	/// </summary>
	public class frmKbtonct : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox manguon;
		private LibList.List listDMBD;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label lTen;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox tenbd;
		private System.Windows.Forms.TextBox mabd;
		private MaskedBox.MaskedBox dang;
		private MaskedTextBox.MaskedTextBox soluong;
		private MaskedTextBox.MaskedTextBox sotien;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private string s_mmyy,sql,format_sotien,format_dongia,format_soluong,format_giaban,user,xxx;
		private int i_nhom,i_makho,i_mabd,i_userid,itable;
		private decimal l_id;
		private decimal d_soluong,d_sotien,d_slnhap,d_slxuat,d_giaban,d_soluongcu,d_dongia,d_gianovat,d_giabancu;
		private bool bKhoaso,bGiaban,bGiaban_nguon;
		private AccessData d;
		private DataTable dtdmbd=new DataTable();
		private DataTable dt=new DataTable();
		private DataTable dtnguon=new DataTable();
		private System.Windows.Forms.Label ldvt;
		private DataRow r;
		private System.Windows.Forms.TextBox stt;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label24;
		private MaskedBox.MaskedBox handung;
		private System.Windows.Forms.TextBox tenhc;
		private System.Windows.Forms.Label lTenhc;
		private MaskedTextBox.MaskedTextBox giaban;
        private System.Windows.Forms.Label label25;
		private System.Windows.Forms.ComboBox nhomcc;
		private frmMain parent;
		private System.Windows.Forms.Label label1;
		private MaskedTextBox.MaskedTextBox dongia;
		private MaskedTextBox.MaskedTextBox losx;
		private System.Windows.Forms.TextBox tim;
        private MaskedTextBox.MaskedTextBox gianovat;
        private Label label2;
        private Button butMavach;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmKbtonct(AccessData acc,string mmyy,int nhom,int kho,string title,bool ban,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            d = acc; i_nhom = nhom; i_makho = kho; s_mmyy = mmyy; bGiaban = ban; i_userid = userid;
			this.Text="Tồn đầu "+title.Trim()+" tháng "+mmyy.Substring(0,2)+" năm "+mmyy.Substring(2,2);
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKbtonct));
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.nhomcc = new System.Windows.Forms.ComboBox();
            this.listDMBD = new LibList.List();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label13 = new System.Windows.Forms.Label();
            this.lTen = new System.Windows.Forms.Label();
            this.ldvt = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tenbd = new System.Windows.Forms.TextBox();
            this.mabd = new System.Windows.Forms.TextBox();
            this.dang = new MaskedBox.MaskedBox();
            this.soluong = new MaskedTextBox.MaskedTextBox();
            this.sotien = new MaskedTextBox.MaskedTextBox();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.stt = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.handung = new MaskedBox.MaskedBox();
            this.tenhc = new System.Windows.Forms.TextBox();
            this.lTenhc = new System.Windows.Forms.Label();
            this.giaban = new MaskedTextBox.MaskedTextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dongia = new MaskedTextBox.MaskedTextBox();
            this.losx = new MaskedTextBox.MaskedTextBox();
            this.tim = new System.Windows.Forms.TextBox();
            this.gianovat = new MaskedTextBox.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butMavach = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.Location = new System.Drawing.Point(103, 465);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 23);
            this.label9.TabIndex = 8;
            this.label9.Text = "Nguồn :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.Location = new System.Drawing.Point(438, 465);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 23);
            this.label10.TabIndex = 9;
            this.label10.Text = "Nhà cung cấp :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // manguon
            // 
            this.manguon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.manguon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manguon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manguon.Enabled = false;
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(149, 465);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(306, 21);
            this.manguon.TabIndex = 5;
            this.manguon.SelectedIndexChanged += new System.EventHandler(this.manguon_SelectedIndexChanged);
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manguon_KeyDown);
            // 
            // nhomcc
            // 
            this.nhomcc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nhomcc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhomcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhomcc.Enabled = false;
            this.nhomcc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhomcc.Location = new System.Drawing.Point(529, 465);
            this.nhomcc.Name = "nhomcc";
            this.nhomcc.Size = new System.Drawing.Size(256, 21);
            this.nhomcc.TabIndex = 6;
            this.nhomcc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhomcc_KeyDown);
            // 
            // listDMBD
            // 
            this.listDMBD.BackColor = System.Drawing.SystemColors.Info;
            this.listDMBD.ColumnCount = 0;
            this.listDMBD.Location = new System.Drawing.Point(376, 544);
            this.listDMBD.MatchBufferTimeOut = 1000;
            this.listDMBD.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listDMBD.Name = "listDMBD";
            this.listDMBD.Size = new System.Drawing.Size(75, 17);
            this.listDMBD.TabIndex = 26;
            this.listDMBD.TextIndex = -1;
            this.listDMBD.TextMember = null;
            this.listDMBD.ValueIndex = -1;
            this.listDMBD.Visible = false;
            this.listDMBD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listDMBD_KeyDown);
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 5);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 431);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.Location = new System.Drawing.Point(18, 442);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 23);
            this.label13.TabIndex = 28;
            this.label13.Text = "Mã :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lTen
            // 
            this.lTen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTen.Location = new System.Drawing.Point(95, 442);
            this.lTen.Name = "lTen";
            this.lTen.Size = new System.Drawing.Size(56, 23);
            this.lTen.TabIndex = 29;
            this.lTen.Text = "Tên :";
            this.lTen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ldvt
            // 
            this.ldvt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ldvt.Location = new System.Drawing.Point(-1, 465);
            this.ldvt.Name = "ldvt";
            this.ldvt.Size = new System.Drawing.Size(51, 23);
            this.ldvt.TabIndex = 30;
            this.ldvt.Text = "ĐVT :";
            this.ldvt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.Location = new System.Drawing.Point(-4, 488);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 23);
            this.label16.TabIndex = 31;
            this.label16.Text = "Số lượng :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label18.Location = new System.Drawing.Point(323, 488);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 23);
            this.label18.TabIndex = 33;
            this.label18.Text = "Số tiền :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenbd
            // 
            this.tenbd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tenbd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbd.Enabled = false;
            this.tenbd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbd.Location = new System.Drawing.Point(149, 442);
            this.tenbd.Name = "tenbd";
            this.tenbd.Size = new System.Drawing.Size(306, 21);
            this.tenbd.TabIndex = 2;
            this.tenbd.Validated += new System.EventHandler(this.tenbd_Validated);
            this.tenbd.TextChanged += new System.EventHandler(this.tenbd_TextChanged);
            this.tenbd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbd_KeyDown);
            // 
            // mabd
            // 
            this.mabd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mabd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabd.Enabled = false;
            this.mabd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabd.Location = new System.Drawing.Point(50, 442);
            this.mabd.Name = "mabd";
            this.mabd.Size = new System.Drawing.Size(54, 21);
            this.mabd.TabIndex = 1;
            this.mabd.Validated += new System.EventHandler(this.mabd_Validated);
            this.mabd.TextChanged += new System.EventHandler(this.mabd_TextChanged);
            this.mabd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbd_KeyDown);
            // 
            // dang
            // 
            this.dang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dang.Enabled = false;
            this.dang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dang.Location = new System.Drawing.Point(50, 465);
            this.dang.Mask = "";
            this.dang.MaxLength = 10;
            this.dang.Name = "dang";
            this.dang.Size = new System.Drawing.Size(54, 21);
            this.dang.TabIndex = 4;
            // 
            // soluong
            // 
            this.soluong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(50, 488);
            this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(54, 21);
            this.soluong.TabIndex = 7;
            this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
            // 
            // sotien
            // 
            this.sotien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sotien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sotien.Enabled = false;
            this.sotien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sotien.Location = new System.Drawing.Point(377, 488);
            this.sotien.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.sotien.Name = "sotien";
            this.sotien.Size = new System.Drawing.Size(78, 21);
            this.sotien.TabIndex = 10;
            this.sotien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sotien.Validated += new System.EventHandler(this.sotien_Validated);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.Image = global::Duoc.Properties.Resources.add;
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(87, 517);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 16;
            this.butMoi.Text = "      &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = global::Duoc.Properties.Resources.quick_edit;
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(157, 517);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 17;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = global::Duoc.Properties.Resources.save;
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(227, 517);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 14;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = global::Duoc.Properties.Resources.undo_ok;
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(297, 517);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 15;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = global::Duoc.Properties.Resources.delete_enabled;
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(367, 517);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 18;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = global::Duoc.Properties.Resources.Print1;
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(437, 517);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 19;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(583, 517);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 20;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // stt
            // 
            this.stt.Enabled = false;
            this.stt.Location = new System.Drawing.Point(64, 352);
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(40, 20);
            this.stt.TabIndex = 60;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.Location = new System.Drawing.Point(595, 488);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 23);
            this.label15.TabIndex = 61;
            this.label15.Text = "Hạn dùng :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label24.Location = new System.Drawing.Point(681, 488);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(39, 23);
            this.label24.TabIndex = 62;
            this.label24.Text = "Lô :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // handung
            // 
            this.handung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.handung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.handung.Enabled = false;
            this.handung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.handung.Location = new System.Drawing.Point(656, 488);
            this.handung.Mask = "####";
            this.handung.Name = "handung";
            this.handung.Size = new System.Drawing.Size(39, 21);
            this.handung.TabIndex = 12;
            this.handung.Text = "    ";
            // 
            // tenhc
            // 
            this.tenhc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenhc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenhc.Enabled = false;
            this.tenhc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenhc.Location = new System.Drawing.Point(529, 442);
            this.tenhc.Name = "tenhc";
            this.tenhc.Size = new System.Drawing.Size(256, 21);
            this.tenhc.TabIndex = 3;
            // 
            // lTenhc
            // 
            this.lTenhc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTenhc.Location = new System.Drawing.Point(444, 441);
            this.lTenhc.Name = "lTenhc";
            this.lTenhc.Size = new System.Drawing.Size(90, 23);
            this.lTenhc.TabIndex = 64;
            this.lTenhc.Text = "Hoạt chất :";
            this.lTenhc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // giaban
            // 
            this.giaban.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.giaban.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giaban.Enabled = false;
            this.giaban.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giaban.Location = new System.Drawing.Point(529, 488);
            this.giaban.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.giaban.Name = "giaban";
            this.giaban.Size = new System.Drawing.Size(66, 21);
            this.giaban.TabIndex = 11;
            this.giaban.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.giaban.Validated += new System.EventHandler(this.giaban_Validated);
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label25.Location = new System.Drawing.Point(476, 488);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 23);
            this.label25.TabIndex = 66;
            this.label25.Text = "Giá bán :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(212, 488);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 67;
            this.label1.Text = "Đơn giá :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dongia
            // 
            this.dongia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dongia.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dongia.Enabled = false;
            this.dongia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dongia.Location = new System.Drawing.Point(265, 488);
            this.dongia.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.dongia.Name = "dongia";
            this.dongia.Size = new System.Drawing.Size(70, 21);
            this.dongia.TabIndex = 9;
            this.dongia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.dongia.Validated += new System.EventHandler(this.dongia_Validated);
            // 
            // losx
            // 
            this.losx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.losx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.losx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.losx.Enabled = false;
            this.losx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.losx.Location = new System.Drawing.Point(720, 488);
            this.losx.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.losx.MaxLength = 20;
            this.losx.Name = "losx";
            this.losx.Size = new System.Drawing.Size(64, 21);
            this.losx.TabIndex = 13;
            // 
            // tim
            // 
            this.tim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tim.Location = new System.Drawing.Point(8, 2);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(776, 20);
            this.tim.TabIndex = 68;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            // 
            // gianovat
            // 
            this.gianovat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gianovat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gianovat.Enabled = false;
            this.gianovat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gianovat.Location = new System.Drawing.Point(149, 488);
            this.gianovat.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.gianovat.Name = "gianovat";
            this.gianovat.Size = new System.Drawing.Size(70, 21);
            this.gianovat.TabIndex = 8;
            this.gianovat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.gianovat.Validated += new System.EventHandler(this.gianovat_Validated);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(95, 488);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 70;
            this.label2.Text = "Giá gốc :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butMavach
            // 
            this.butMavach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMavach.Image = ((System.Drawing.Image)(resources.GetObject("butMavach.Image")));
            this.butMavach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMavach.Location = new System.Drawing.Point(507, 517);
            this.butMavach.Name = "butMavach";
            this.butMavach.Size = new System.Drawing.Size(76, 25);
            this.butMavach.TabIndex = 71;
            this.butMavach.Text = "Mã vạch";
            this.butMavach.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butMavach.Click += new System.EventHandler(this.butMavach_Click);
            // 
            // frmKbtonct
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.butMavach);
            this.Controls.Add(this.soluong);
            this.Controls.Add(this.gianovat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.losx);
            this.Controls.Add(this.dongia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mabd);
            this.Controls.Add(this.sotien);
            this.Controls.Add(this.giaban);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.tenbd);
            this.Controls.Add(this.tenhc);
            this.Controls.Add(this.lTenhc);
            this.Controls.Add(this.handung);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dang);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.ldvt);
            this.Controls.Add(this.lTen);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.nhomcc);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.listDMBD);
            this.Controls.Add(this.stt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKbtonct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tồn đầu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmKbtonct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmKbtonct_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = d.user; itable = d.tableid(s_mmyy, "d_tonkhoct"); xxx = user + s_mmyy;
			format_sotien=d.format_sotien(i_nhom);
			format_dongia=d.format_dongia(i_nhom);
			format_soluong=d.format_soluong(i_nhom);
			bGiaban_nguon=d.bGiaban_nguon(i_nhom);
			format_giaban=d.format_giaban(i_nhom);
			bKhoaso=d.bKhoaso(i_nhom,s_mmyy);
			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			if (d.bQuanlynguon(i_nhom))
				dtnguon=d.get_data("select * from "+user+".d_dmnguon where nhom="+i_nhom+" order by stt").Tables[0];
			else
                dtnguon = d.get_data("select * from " + user + ".d_dmnguon where id=0 or nhom=" + i_nhom + " order by stt").Tables[0];
			manguon.DataSource=dtnguon;
			nhomcc.DisplayMember="TEN";
			nhomcc.ValueMember="ID";
			if (d.bQuanlynhomcc(i_nhom))
                nhomcc.DataSource = d.get_data("select * from " + user + ".d_dmnx where nhom=" + i_nhom + " order by stt").Tables[0];
			else
                nhomcc.DataSource = d.get_data("select * from " + user + ".d_dmnx where id=0 or nhom=" + i_nhom + " order by stt").Tables[0];

			listDMBD.DisplayMember="TEN";
			listDMBD.ValueMember="MA";
			load_dm();
			
			load_grid();
			AddGridTableStyle();
			ref_text(0);
		}

		private void load_grid()
		{
			sql=" select 1 as tt,a.stt,e.manguon,e.nhomcc,c.ten as tennguon,d.ten as tennhomcc,b.ma,trim(b.ten)||' '||b.hamluong as tenbd,b.tenhc,b.dang,e.handung,e.losx,a.tondau,a.tondau*e.giamua as sttondau,a.slnhap,a.slnhap*e.giamua as stnhap,a.slxuat,a.slxuat*e.giamua as stxuat,e.giaban,e.giamua as dongia,e.gianovat ";
            sql += ", a.tondau+a.slnhap-a.slxuat as cuoiky,(a.tondau+a.slnhap-a.slxuat)*e.giamua as stcuoiky ";
            sql += " from " + xxx + ".d_tonkhoct a," + user + ".d_dmbd b," + user + ".d_dmnguon c," + user + ".d_dmnx d,"+xxx+".d_theodoi e";
            sql += " where a.stt=e.id and a.mabd=b.id and e.manguon=c.id and e.nhomcc=d.id  and a.makho=" + i_makho;
            sql += " and a.tondau<>0";
            sql += " order by a.stt";
			dt=d.get_data(sql).Tables[0];
            string mmyyt = d.Mmyy_truoc(s_mmyy);
            if (d.bMmyy(mmyyt))
            {
                DataRow r1;
                DataTable tmp = d.get_data("select stt from "+user+mmyyt+".d_tonkhoct where (tondau<>0 or slnhap<>0 or slxuat<>0) and (makho=" + i_makho + ")").Tables[0];
                foreach (DataRow r in dt.Rows)
                {
                    r1 = d.getrowbyid(tmp, "stt=" + decimal.Parse(r["stt"].ToString()));
                    if (r1 == null) r["tt"] = 0;
                }
            }
			dataGrid1.DataSource=dt;
		}

        private void AddGridTableStyle()
        {
            DataGridColoredTextBoxColumn TextCol;
            delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            ts.SelectionBackColor = Color.Teal;
            ts.SelectionForeColor = Color.PaleGreen;
            ts.RowHeaderWidth = 10;
            ts.MappingName = dt.TableName;
            ts.AllowSorting = false;

            TextCol = new DataGridColoredTextBoxColumn(de, 0);
            TextCol.MappingName = "stt";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 1);
            TextCol.MappingName = "tennguon";
            TextCol.HeaderText = "Nguồn";
            TextCol.Width = (d.bQuanlynguon(i_nhom)) ? 80 : 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 2);
            TextCol.MappingName = "tennhomcc";
            TextCol.HeaderText = "Nhà cung cấp";
            TextCol.Width = (d.bQuanlynhomcc(i_nhom)) ? 90 : 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 3);
            TextCol.MappingName = "ma";
            TextCol.HeaderText = "Mã số";
            TextCol.Width = 50;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 4);
            TextCol.MappingName = "tenbd";
            TextCol.HeaderText = "Tên";
            TextCol.Width = (d.bHoatchat || bGiaban || d.bQuanlyhandung(i_nhom) || d.bQuanlylosx(i_nhom) || d.bQuanlynguon(i_nhom) || d.bQuanlynhomcc(i_nhom)) ? 200 : 450;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 5);
            TextCol.MappingName = "tenhc";
            TextCol.HeaderText = "Hoạt chất";
            TextCol.Width = (d.bHoatchat) ? 200 : 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 6);
            TextCol.MappingName = "dang";
            TextCol.HeaderText = "ĐVT";
            TextCol.Width = 50;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 7);
            TextCol.MappingName = "handung";
            TextCol.HeaderText = "Date";
            TextCol.Width = (d.bQuanlyhandung(i_nhom)) ? 30 : 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 8);
            TextCol.MappingName = "losx";
            TextCol.HeaderText = "Lô SX";
            TextCol.Width = (d.bQuanlylosx(i_nhom)) ? 50 : 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 9);
            TextCol.MappingName = "tondau";
            TextCol.HeaderText = "Tồn đầu";
            TextCol.Width = 80;
            TextCol.Format = format_soluong;
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 10);
            TextCol.MappingName = "gianovat";
            TextCol.HeaderText = "Giá gốc";
            TextCol.Width = 80;
            TextCol.Format = format_dongia;
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 11);
            TextCol.MappingName = "dongia";
            TextCol.HeaderText = "Đơn giá";
            TextCol.Width = 80;
            TextCol.Format = format_dongia;
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 12);
            TextCol.MappingName = "sttondau";
            TextCol.HeaderText = "Số tiền";
            TextCol.Width = 100;
            TextCol.Format = format_sotien;
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 13);
            TextCol.MappingName = "giaban";
            TextCol.HeaderText = (bGiaban) ? "Giá bán" : "";
            TextCol.Width = (bGiaban) ? 80 : 0;
            TextCol.Format = "###,###,###,##0";
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 14);
            TextCol.MappingName = "tt";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            //
            TextCol = new DataGridColoredTextBoxColumn(de, 15);
            TextCol.MappingName = "slnhap";
            TextCol.HeaderText = "SL nhập";
            TextCol.Width = 80;
            TextCol.Format = format_sotien;
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 16);
            TextCol.MappingName = "stnhap";
            TextCol.HeaderText = "ST Nhập";
            TextCol.Width = 100;
            TextCol.Format = format_soluong;
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 17);
            TextCol.MappingName = "slxuat";
            TextCol.HeaderText = "SL Xuất";
            TextCol.Width = 80;
            TextCol.Format = format_sotien;
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 18);
            TextCol.MappingName = "stxuat";
            TextCol.HeaderText = "ST Xuất";
            TextCol.Width = 100;
            TextCol.Format = format_soluong;
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 19);
            TextCol.MappingName = "cuoiky";
            TextCol.HeaderText = "SL Cuối kỳ";
            TextCol.Width = 80;
            TextCol.Format = format_sotien;
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 20);
            TextCol.MappingName = "stcuoiky";
            TextCol.HeaderText = "ST Cuối kỳ";
            TextCol.Width = 100;
            TextCol.Format = format_soluong;
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
        }

        public Color MyGetColorRowCol(int row, int col)
        {
            return (this.dataGrid1[row, 14].ToString().Trim() == "0") ? Color.Red : Color.Black;
        }

        public delegate Color delegateGetColorRowCol(int row, int col);
        public class DataGridColoredTextBoxColumn : DataGridTextBoxColumn
        {
            private delegateGetColorRowCol _getColorRowCol;
            private int _column;
            public DataGridColoredTextBoxColumn(delegateGetColorRowCol getcolorRowCol, int column)
            {
                _getColorRowCol = getcolorRowCol;
                _column = column;
            }
            protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Brush backBrush, System.Drawing.Brush foreBrush, bool alignToRight)
            {
                try
                {
                    foreBrush = new SolidBrush(_getColorRowCol(rowNum, this._column));
                    //backBrush = new SolidBrush(Color.GhostWhite);
                }

                catch { }
                finally
                {
                    base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
                }
            }
        }

		private void ref_text(decimal id)
		{
			try
			{
				if (id==0)
				{
					int i=dataGrid1.CurrentCell.RowNumber;
					r=d.getrowbyid(dt,"stt="+decimal.Parse(dataGrid1[i,0].ToString()));
				}
				else r=d.getrowbyid(dt,"stt="+id);
				if (r!=null)
				{
					stt.Text=r["stt"].ToString();
					manguon.SelectedValue=r["manguon"].ToString();
					nhomcc.SelectedValue=r["nhomcc"].ToString();
					mabd.Text=r["ma"].ToString();
					tenbd.Text=r["tenbd"].ToString();
					tenhc.Text=r["tenhc"].ToString();
					dang.Text=r["dang"].ToString();
					handung.Text=r["handung"].ToString();
					losx.Text=r["losx"].ToString();
					d_soluong=(r["tondau"].ToString()!="")?decimal.Parse(r["tondau"].ToString()):0;
					d_sotien=(r["sttondau"].ToString()!="")?decimal.Parse(r["sttondau"].ToString()):0;
					d_dongia=(r["dongia"].ToString()!="")?decimal.Parse(r["dongia"].ToString()):0;
                    d_gianovat = (r["gianovat"].ToString() != "") ? decimal.Parse(r["gianovat"].ToString()) : 0;
					d_giaban=(r["giaban"].ToString()!="")?decimal.Parse(r["giaban"].ToString()):0;
					d_slnhap=(r["slnhap"].ToString()!="")?decimal.Parse(r["slnhap"].ToString()):0;
					d_slxuat=(r["slxuat"].ToString()!="")?decimal.Parse(r["slxuat"].ToString()):0;
					soluong.Text=d_soluong.ToString(format_soluong);
                    gianovat.Text = d_gianovat.ToString(format_dongia);
					dongia.Text=d_dongia.ToString(format_dongia);
					sotien.Text=d_sotien.ToString(format_sotien);
					giaban.Text=d_giaban.ToString(format_giaban);
					l_id=decimal.Parse(stt.Text);
					d_soluongcu=d_soluong;
                    d_giabancu = d_giaban;
				}
			}
			catch{}
		}

		private void load_dm()
		{
            dtdmbd = d.get_data("select a.ma,trim(a.ten)||' '||a.hamluong as ten,trim(a.tenhc)||'/'||b.ten as tenhc,a.dang,a.id from " + user + ".d_dmbd a left join " + user + ".d_dmhang b on a.mahang=b.id where a.nhom=" + i_nhom + " and a.hide=0 order by a.ten").Tables[0];
			listDMBD.DataSource=dtdmbd;
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void Filter_dmbd(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDMBD.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ten like '%"+ten.Trim()+"%'"+" or tenhc like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void tenbd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDMBD.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listDMBD.Visible) listDMBD.Focus();
				else SendKeys.Send("{Tab}");
			}
		}

		private void tenbd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbd)
			{
				Filter_dmbd(tenbd.Text);
				if (manguon.Enabled)
					listDMBD.BrowseToDmbd(tenbd,mabd,manguon,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lTenhc.Width+tenhc.Width-32,mabd.Height+5);
				else 
					listDMBD.BrowseToDmbd(tenbd,mabd,soluong,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lTenhc.Width+tenhc.Width-32,mabd.Height+5);
			}
		}

		private void tenbd_Validated(object sender, System.EventArgs e)
		{
			if(!listDMBD.Focused) listDMBD.Hide();
			if (tenbd.Text!="" && mabd.Text=="")
			{
				r=d.getrowbyid(dtdmbd,"ten='"+tenbd.Text+"'");
				if (r!=null)
				{
					mabd.Text=r["ma"].ToString();
					dang.Text=r["dang"].ToString();
					tenhc.Text=r["tenhc"].ToString();
				}
			}
			SendKeys.Send("{F4}");
		}

		private void ena_object(bool ena)
		{
			dataGrid1.Enabled=!ena;
			if (d.bQuanlynguon(i_nhom)) manguon.Enabled=ena;
			else manguon.SelectedValue="0";
			if (d.bQuanlynhomcc(i_nhom)) nhomcc.Enabled=ena;
			else nhomcc.SelectedValue="0";
			if (d.bNhapmaso) mabd.Enabled=ena;
			tenbd.Enabled=ena;
			soluong.Enabled=ena;
			if (d.bQuanlyhandung(i_nhom)) handung.Enabled=ena;
			if (d.bQuanlylosx(i_nhom)) losx.Enabled=ena;
			if (manguon.Enabled && bGiaban_nguon) giaban.Enabled=ena;
			else if (bGiaban) giaban.Enabled=ena;
			if (bGiaban_nguon && ena && manguon.SelectedIndex!=-1 && manguon.Enabled)
				giaban.Enabled=dtnguon.Rows[manguon.SelectedIndex]["loai"].ToString()=="1";
			if (d.bDongia(i_nhom)) dongia.Enabled=ena;
			else sotien.Enabled=ena;
            gianovat.Enabled = ena;//dongia.Enabled;
            dongia.Enabled = sotien.Enabled = ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butIn.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			if (d.bDanhmuc || d.bDmbd)
			{
				if (d.bDanhmuc) d.writeXml("d_thongso","c01","0");
				else d.writeXml("d_thongso","c06","0");
				load_dm();
			}
        }

		private void emp_detail()
		{
			l_id=0;
			mabd.Text=tenbd.Text=tenhc.Text=dang.Text=soluong.Text="";
			sotien.Text=dongia.Text=handung.Text=losx.Text="";
			giaban.Text="0";
			stt.Text=gianovat.Text = "";
            d_soluongcu = 0; d_giabancu = 0;
			d_slnhap=0;
			d_slxuat=0;
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			if (bKhoaso)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Số liệu tháng")+" "+s_mmyy.Substring(0,2)+" "+
lan.Change_language_MessageText("năm")+" "+s_mmyy.Substring(2,2)+" "+
lan.Change_language_MessageText("đã khóa !")+"\n"+
lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"),d.Msg);
				return;
			}
			ena_object(true);
			emp_detail();
			if (mabd.Enabled) mabd.Focus();
			else tenbd.Focus();
		}
		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (dt.Rows.Count==0) return;
			if (bKhoaso)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Số liệu tháng")+" "+s_mmyy.Substring(0,2)+" "+
lan.Change_language_MessageText("năm")+" "+s_mmyy.Substring(2,2)+" "+
lan.Change_language_MessageText("đã khóa !")+"\n"+
lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"),d.Msg);
				return;
			}
			l_id=decimal.Parse(stt.Text);
			ena_object(true);
            //
            mabd.Enabled = false;
            tenbd.Enabled = false;
            soluong.Focus();
            //
			//if (mabd.Enabled) mabd.Focus();
			//else tenbd.Focus();
		}

		private bool KiemtraDetail()
		{
			i_mabd=0;
			if (mabd.Text=="" && tenbd.Text=="")
			{
				mabd.Focus();
				return false;
			}
			if ((mabd.Text=="" && tenbd.Text!="") || (mabd.Text!="" && tenbd.Text==""))
			{
				if (mabd.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập mã số !"),d.Msg);
					mabd.Focus();
					return false;
				}
				else if (tenbd.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập tên !"),d.Msg);
					tenbd.Focus();
					return false;
				}
			}
			r=d.getrowbyid(dtdmbd,"ma='"+mabd.Text+"'");
			if (r==null)
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã số không hợp lệ !"),d.Msg);
				mabd.Focus();
				return false;
			}
			i_mabd=int.Parse(r["id"].ToString());
			if (soluong.Text=="" || soluong.Text=="0.00" || soluong.Text=="0")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập số lượng !"),d.Msg);
				soluong.Focus();
				return false;
			}
			if (d.bQuanlynguon(i_nhom))
			{
				if (manguon.SelectedIndex==-1 || manguon.SelectedValue.ToString()=="0")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nguồn không hợp lệ !"),d.Msg);
					manguon.Focus();
					return false;
				}
			}
			else manguon.SelectedValue="0";
			if (d.bQuanlynhomcc(i_nhom))
			{
				if (nhomcc.SelectedIndex==-1 || nhomcc.SelectedValue.ToString()=="0")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhà cung cấp không hợp lệ !"),d.Msg);
					nhomcc.Focus();
					return false;
				}
			}
			else nhomcc.SelectedValue="0";
			d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
			d_dongia=(dongia.Text!="")?decimal.Parse(dongia.Text):0;
            d_gianovat = (gianovat.Text != "") ? decimal.Parse(gianovat.Text) : d_dongia;
			d_sotien=(sotien.Text!="")?decimal.Parse(sotien.Text):0;
			d_giaban=(giaban.Text!="")?decimal.Parse(giaban.Text):d_dongia;
			handung.Text=handung.Text.Trim().PadRight(4,'0');
			//losx.Text=losx.Text.Trim().PadRight(10,'.');
			handung.Refresh();
			losx.Refresh();
            if (l_id!=0 && giaban.Enabled)
            {
                if (d_giaban != d_giabancu)
                {
                    if (MessageBox.Show(lan.Change_language_MessageText("Giá bán khác giá bán củ (") + d_giabancu.ToString() + "\n"+lan.Change_language_MessageText("Bạn có đồng ý sửa lại không ?"), d.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        giaban.Focus();
                        return false;
                    }
                }
            }
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!KiemtraDetail()) return;
			bool bEdit=l_id!=0;
            if (l_id == 0)
            {
                // hien 10-06-2011: nang id len numeric(24)
                l_id = d.get_id_tonkho;
                d.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
            }
            else
            {
                d.upd_eve_upd_del(s_mmyy, itable, i_userid, "upd", d.fields(xxx + ".d_tonkhoct", "makho=" + i_makho + " and stt=" + l_id));
                d.upd_eve_tables(s_mmyy, itable, i_userid, "upd");
            }
            decimal _dongia = d.Round(d_sotien / d_soluong, 10);
            d.upd_theodoi(s_mmyy, l_id, i_mabd, int.Parse(manguon.SelectedValue.ToString()), int.Parse(nhomcc.SelectedValue.ToString()), handung.Text, losx.Text, "","","", 0, 0, 0,_dongia, d_giaban,d_gianovat,0,0);
			if (!d.upd_tonkhoct(s_mmyy,i_makho,l_id,i_mabd,d_soluong))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin tồn kho !"),d.Msg);
				return;
			}
			d.upd_tonkhoth(s_mmyy,i_makho,int.Parse(manguon.SelectedValue.ToString()),i_mabd,d_soluong,"tondau");
			decimal tyle=d.get_tyle(i_mabd);
			if (tyle!=0) d.upd_theodoitscd(s_mmyy,l_id,decimal.Parse("20"+s_mmyy.Substring(2,2)),tyle,0);
			if (bEdit) d.upd_tonkho(s_mmyy,i_nhom,1);
            d.upd_hcton(i_nhom, s_mmyy, i_userid);
			ena_object(false);
			load_grid();
			ref_text(0);
			butMoi.Focus();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
			butMoi.Focus();
		}

		private void manguon_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (manguon.SelectedIndex==-1) manguon.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void mabd_Validated(object sender, System.EventArgs e)
		{
			if (mabd.Text!="")
			{
				r=d.getrowbyid(dtdmbd,"ma='"+mabd.Text+"'");
				if (r!=null) 
				{
					tenbd.Text=r["ten"].ToString();
					tenhc.Text=r["tenhc"].ToString();
					dang.Text=r["dang"].ToString();
				}
			}
			if(!listDMBD.Focused) listDMBD.Hide();
		}

		private void listDMBD_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)	mabd_Validated(null,null);
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text(0);
		}

		private void sotien_Validated(object sender, System.EventArgs e)
		{
			try
			{
				d_sotien=(sotien.Text!="")?decimal.Parse(sotien.Text):0;
				sotien.Text=d_sotien.ToString(format_sotien);
			}
			catch{}
			tinh_giatri(false);
		}

		private void soluong_Validated(object sender, System.EventArgs e)
		{
			try
			{
				d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
				soluong.Text=d_soluong.ToString(format_soluong);
				if (d_soluong+d_slnhap-d_slxuat<0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Số lượng không hợp lệ (Tồn kho sẽ bị âm) !"),d.Msg);
					soluong.Text=d_soluongcu.ToString(format_soluong);
					soluong.Focus();
				}
			}
			catch{}
			tinh_giatri(true);
		}

        private void tinh_giatri(bool bdongia)
        {
            try
            {
                d_soluong = (soluong.Text != "") ? decimal.Parse(soluong.Text) : 0;
                if (bdongia)
                {
                    d_dongia = (dongia.Text != "") ? decimal.Parse(dongia.Text) : 0;
                    d_sotien = Math.Round(d_soluong * d_dongia, 3);
                    sotien.Text = d_sotien.ToString(format_sotien);
                }
                else
                {
                    d_sotien = (sotien.Text != "") ? decimal.Parse(sotien.Text) : 0;
                    d_dongia = Math.Round(d_sotien / d_soluong, 3);
                    dongia.Text = d_dongia.ToString(format_dongia);
                }
                if (giaban.Enabled == false && (giaban.Text == "" || giaban.Text.Trim() == "0")) giaban.Text = d_dongia.ToString(format_giaban);               
            }
            catch { }
        }
		private void tinh_giatri()
		{
			try
			{
				d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
				if (d.bDongia(i_nhom))
				{
					d_dongia=(dongia.Text!="")?decimal.Parse(dongia.Text):0;
					d_sotien=Math.Round(d_soluong*d_dongia,3);
					sotien.Text=d_sotien.ToString(format_sotien);
				}
				else
				{	
					d_sotien=(sotien.Text!="")?decimal.Parse(sotien.Text):0;
					d_dongia=Math.Round(d_sotien/d_soluong,3);
					dongia.Text=d_dongia.ToString(format_dongia);
				}
                if (giaban.Enabled == false && (giaban.Text == "" || giaban.Text.Trim() == "0")) giaban.Text = d_dongia.ToString(format_giaban);
                d_gianovat = (gianovat.Text != "") ? decimal.Parse(gianovat.Text) : 0;
                d_gianovat = (d_gianovat == 0) ? d_dongia : d_gianovat;
                gianovat.Text = d_gianovat.ToString(format_dongia);
			}
			catch{}
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (dt.Rows.Count==0) return;
				if (bKhoaso)
				{
					MessageBox.Show(
lan.Change_language_MessageText("Số liệu tháng")+" "+s_mmyy.Substring(0,2)+" "+
lan.Change_language_MessageText("năm")+" "+s_mmyy.Substring(2,2)+" "+
lan.Change_language_MessageText("đã khóa !")+"\n"+
lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"),d.Msg);
					return;
				}
				if (d_slnhap!=0 || d_slxuat!=0)
				{
					MessageBox.Show(tenbd.Text.Trim()+" "+dang.Text.Trim()+"\nĐã nhập/xuất không cho phép hủy !",d.Msg);
					return;
				}
				if (MessageBox.Show(
lan.Change_language_MessageText("Đồng ý hủy thông tin này ?"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					r=d.getrowbyid(dtdmbd,"ma='"+mabd.Text+"'");
					if (r!=null)
					{
                        d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".d_tonkhoct", "makho=" + i_makho + " and stt=" + l_id));
                        d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                        d.execute_data("delete from " + xxx + ".d_tonkhoct where makho=" + i_makho + " and stt=" + l_id);
						d.upd_tonkhoth(d.delete,s_mmyy,i_makho,int.Parse(r["id"].ToString()),int.Parse(manguon.SelectedValue.ToString()),decimal.Parse(soluong.Text),"tondau");
						load_grid();
						ref_text(0);
					}
				}
			}
			catch{}
		}

		private void giaban_Validated(object sender, System.EventArgs e)
		{
			try
			{
				d_giaban=(giaban.Text!="")?decimal.Parse(giaban.Text):0;
				giaban.Text=d_giaban.ToString(format_giaban);
			}
			catch{giaban.Text="0";}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			string sql="select b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,a.tondau,a.tondau*e.giamua as sttondau, c.stt, c.ten as nhombd, e.manguon, d.ten as tennguon,e.giamua,e.giaban "+
				" from "+user+s_mmyy+".d_tonkhoct a,"+user+".d_dmbd b,"+user+".d_dmnhom c,"+user+".d_dmnguon d,"+user+s_mmyy+".d_theodoi e"+
				" where a.stt=e.id and a.mabd=b.id and b.manhom=c.id and e.manguon=d.id and a.tondau<>0 and a.makho="+i_makho+" order by b.ten";
			DataTable ldt=d.get_data(sql).Tables[0];
			string tenfile=(bGiaban)?"d_tondau_gban.rpt":"d_tondau.rpt";
			frmReport f=new frmReport(d,ldt,i_userid,tenfile,this.Text.Trim().ToUpper(),"","","","","","","","","");
			f.ShowDialog();			
		}

		private void nhomcc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) SendKeys.Send("{Tab}");
		}

		private void mabd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==mabd)
			{
				Filter_mabd(mabd.Text);
				if (manguon.Enabled)
					listDMBD.BrowseToDmbd(mabd,tenbd,manguon,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lTenhc.Width+tenhc.Width-32,mabd.Height+5);
				else 
					listDMBD.BrowseToDmbd(mabd,tenbd,soluong,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lTenhc.Width+tenhc.Width-32,mabd.Height+5);
			}		
		}

		private void Filter_mabd(string ma)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDMBD.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ma like '%"+ma.Trim()+"%'";
			}
			catch{}
		}

		private void dongia_Validated(object sender, System.EventArgs e)
		{
			try
			{
				d_dongia=(dongia.Text!="")?decimal.Parse(dongia.Text):0;
				dongia.Text=d_dongia.ToString(format_dongia);
			}
			catch{dongia.Text="0";}
			tinh_giatri(true);
		}

		private void manguon_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==manguon)
				if (bGiaban_nguon && butLuu.Enabled && manguon.SelectedIndex!=-1)
					giaban.Enabled=dtnguon.Rows[manguon.SelectedIndex]["loai"].ToString()=="1";
		}

		private void tim_Enter(object sender, System.EventArgs e)
		{
			tim.Text="";
		}

		private void tim_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tim) RefreshChildren(tim.Text);
		}

        public void RefreshChildren(string text)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "tenbd like '%" + text.Trim() + "%'" + " or tenhc like '%" + text.Trim() + "%' or ma like '%" + text.Trim() + "%'";
                if (text != "") ref_text(0);
                else ref_text(l_id);
            }
            catch { }
        }

        private void gianovat_Validated(object sender, EventArgs e)
        {
            try
            {
                d_dongia = (dongia.Text != "") ? decimal.Parse(dongia.Text) : 0;
                d_gianovat = (gianovat.Text != "") ? decimal.Parse(gianovat.Text) : 0;
                gianovat.Text = d_gianovat.ToString(format_dongia);
                if (d_dongia == 0) dongia.Text = gianovat.Text;
            }
            catch { gianovat.Text = "0"; }
            tinh_giatri();            
        }

        private void butMavach_Click(object sender, EventArgs e)
        {
            if (stt.Text == "") return;
            try
            {
                DataTable dttmp = new DataTable();
                dttmp.Columns.Add("ten", typeof(string)).DefaultValue = tenbd.Text;
                dttmp.Columns.Add("tenhc", typeof(string)).DefaultValue = tenhc.Text;
                dttmp.Columns.Add("dang", typeof(string)).DefaultValue = dang.Text;
                dttmp.Columns.Add("sttt", typeof(decimal)).DefaultValue = decimal.Parse(stt.Text);
                DataRow nr = dttmp.NewRow();
                dttmp.Rows.Add(nr);
                frmReport f = new frmReport(d, dttmp,i_userid, "", "d_phieunhap_mavach.rpt");
                f.ShowDialog();
            }
            catch { }
        }
	}
}
