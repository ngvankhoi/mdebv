using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibVienphi;

namespace DllPhonggiuong
{
	/// <summary>
	/// Summary description for frmDm.
	/// </summary>
	public class frmDmgiuong : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butKetthuc;
		private DataTable dtp=new DataTable();
		private LibMedi.AccessData m;
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
		private DataTable dt=new DataTable();
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.TextBox ten;
		private long id;
		private int i_userid;
		private string sql,user;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown stt;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox ma;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.ComboBox phong;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private MaskedTextBox.MaskedTextBox gia_th;
		private MaskedTextBox.MaskedTextBox gia_bh;
		private MaskedTextBox.MaskedTextBox gia_cs;
		private MaskedTextBox.MaskedTextBox gia_nn;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox bhyt;
		private MaskedTextBox.MaskedTextBox gia_dv;
		private System.Windows.Forms.Label label11;
        private CheckBox chkChenhlech;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDmgiuong(LibMedi.AccessData acc,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDmgiuong));
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
            this.label1 = new System.Windows.Forms.Label();
            this.ma = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.ComboBox();
            this.phong = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gia_th = new MaskedTextBox.MaskedTextBox();
            this.gia_bh = new MaskedTextBox.MaskedTextBox();
            this.gia_cs = new MaskedTextBox.MaskedTextBox();
            this.gia_nn = new MaskedTextBox.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.bhyt = new System.Windows.Forms.ComboBox();
            this.gia_dv = new MaskedTextBox.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkChenhlech = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stt)).BeginInit();
            this.SuspendLayout();
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 8);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(608, 296);
            this.dataGrid1.TabIndex = 17;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(430, 378);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 19;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(200, 312);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "Tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ten
            // 
            this.ten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(240, 312);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(240, 21);
            this.ten.TabIndex = 6;
            this.ten.Validated += new System.EventHandler(this.ten_Validated);
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(125, 378);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(60, 25);
            this.butMoi.TabIndex = 16;
            this.butMoi.Text = "    &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(186, 378);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(60, 25);
            this.butSua.TabIndex = 17;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(247, 378);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(60, 25);
            this.butLuu.TabIndex = 14;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(308, 378);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(60, 25);
            this.butBoqua.TabIndex = 15;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(369, 378);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(60, 25);
            this.butHuy.TabIndex = 18;
            this.butHuy.Text = "    &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(-8, 312);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 23);
            this.label3.TabIndex = 18;
            this.label3.Text = "Stt :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // stt
            // 
            this.stt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stt.Enabled = false;
            this.stt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stt.Location = new System.Drawing.Point(24, 312);
            this.stt.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(40, 21);
            this.stt.TabIndex = 4;
            this.stt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(56, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 19;
            this.label1.Text = "Mã số :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ma
            // 
            this.ma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ma.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ma.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ma.Enabled = false;
            this.ma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ma.Location = new System.Drawing.Point(104, 312);
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(104, 21);
            this.ma.TabIndex = 5;
            this.ma.Validated += new System.EventHandler(this.ma_Validated);
            this.ma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Khoa :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(40, 3);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(208, 21);
            this.makp.TabIndex = 1;
            this.makp.SelectedIndexChanged += new System.EventHandler(this.makp_SelectedIndexChanged);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // phong
            // 
            this.phong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.phong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.phong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phong.Location = new System.Drawing.Point(296, 3);
            this.phong.Name = "phong";
            this.phong.Size = new System.Drawing.Size(320, 21);
            this.phong.TabIndex = 3;
            this.phong.SelectedIndexChanged += new System.EventHandler(this.phong_SelectedIndexChanged);
            this.phong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(248, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "Phòng :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Location = new System.Drawing.Point(-8, 336);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 21;
            this.label5.Text = "Đơn giá :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gia_th
            // 
            this.gia_th.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gia_th.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gia_th.Enabled = false;
            this.gia_th.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gia_th.Location = new System.Drawing.Point(48, 336);
            this.gia_th.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.gia_th.Name = "gia_th";
            this.gia_th.Size = new System.Drawing.Size(68, 21);
            this.gia_th.TabIndex = 8;
            this.gia_th.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.gia_th.Validated += new System.EventHandler(this.gia_th_Validated);
            // 
            // gia_bh
            // 
            this.gia_bh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gia_bh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gia_bh.Enabled = false;
            this.gia_bh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gia_bh.Location = new System.Drawing.Point(171, 336);
            this.gia_bh.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.gia_bh.Name = "gia_bh";
            this.gia_bh.Size = new System.Drawing.Size(68, 21);
            this.gia_bh.TabIndex = 9;
            this.gia_bh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.gia_bh.Validated += new System.EventHandler(this.gia_bh_Validated);
            // 
            // gia_cs
            // 
            this.gia_cs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gia_cs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gia_cs.Enabled = false;
            this.gia_cs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gia_cs.Location = new System.Drawing.Point(304, 336);
            this.gia_cs.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.gia_cs.Name = "gia_cs";
            this.gia_cs.Size = new System.Drawing.Size(68, 21);
            this.gia_cs.TabIndex = 10;
            this.gia_cs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.gia_cs.Validated += new System.EventHandler(this.gia_cs_Validated);
            // 
            // gia_nn
            // 
            this.gia_nn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gia_nn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gia_nn.Enabled = false;
            this.gia_nn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gia_nn.Location = new System.Drawing.Point(552, 336);
            this.gia_nn.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.gia_nn.Name = "gia_nn";
            this.gia_nn.Size = new System.Drawing.Size(68, 21);
            this.gia_nn.TabIndex = 12;
            this.gia_nn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.gia_nn.Validated += new System.EventHandler(this.gia_nn_Validated);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.Location = new System.Drawing.Point(107, 336);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 23);
            this.label7.TabIndex = 22;
            this.label7.Text = "Bảo hiểm :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.Location = new System.Drawing.Point(224, 336);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 23);
            this.label8.TabIndex = 23;
            this.label8.Text = "Chính sách :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.Location = new System.Drawing.Point(472, 336);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 23);
            this.label9.TabIndex = 24;
            this.label9.Text = "Nước ngoài :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.Location = new System.Drawing.Point(472, 312);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 23);
            this.label10.TabIndex = 25;
            this.label10.Text = "BHYT chi trả :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bhyt
            // 
            this.bhyt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bhyt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bhyt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bhyt.Enabled = false;
            this.bhyt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bhyt.Location = new System.Drawing.Point(552, 312);
            this.bhyt.Name = "bhyt";
            this.bhyt.Size = new System.Drawing.Size(68, 21);
            this.bhyt.TabIndex = 7;
            this.bhyt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bhyt_KeyDown);
            // 
            // gia_dv
            // 
            this.gia_dv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gia_dv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gia_dv.Enabled = false;
            this.gia_dv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gia_dv.Location = new System.Drawing.Point(419, 336);
            this.gia_dv.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.gia_dv.Name = "gia_dv";
            this.gia_dv.Size = new System.Drawing.Size(61, 21);
            this.gia_dv.TabIndex = 11;
            this.gia_dv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.gia_dv.Validated += new System.EventHandler(this.gia_dv_Validated);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.Location = new System.Drawing.Point(364, 336);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 23);
            this.label11.TabIndex = 27;
            this.label11.Text = "Dịch vụ :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkChenhlech
            // 
            this.chkChenhlech.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkChenhlech.AutoSize = true;
            this.chkChenhlech.Enabled = false;
            this.chkChenhlech.Location = new System.Drawing.Point(48, 362);
            this.chkChenhlech.Name = "chkChenhlech";
            this.chkChenhlech.Size = new System.Drawing.Size(80, 17);
            this.chkChenhlech.TabIndex = 13;
            this.chkChenhlech.Text = "Chênh lệch";
            this.chkChenhlech.UseVisualStyleBackColor = true;
            this.chkChenhlech.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // frmDmgiuong
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(624, 413);
            this.Controls.Add(this.gia_dv);
            this.Controls.Add(this.chkChenhlech);
            this.Controls.Add(this.gia_cs);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.bhyt);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.gia_bh);
            this.Controls.Add(this.gia_th);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.gia_nn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.phong);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ma);
            this.Controls.Add(this.stt);
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
            this.Name = "frmDmgiuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục giường";
            this.Load += new System.EventHandler(this.frmDmgiuong_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDmgiuong_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmDmgiuong_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			bhyt.DisplayMember="CHITRA";
			bhyt.ValueMember="CHITRA";
            bhyt.DataSource = v.get_data("select * from " + user + ".d_dmbhyt order by stt").Tables[0];

			makp.DisplayMember="TENKP";
			makp.ValueMember="MAKP";
            makp.DataSource = m.get_data("select * from " + user + ".btdkp_bv where makp<>'01' and loai in (0,4) order by loai,makp").Tables[0];

			phong.DisplayMember="TEN";
			phong.ValueMember="ID";
			if (makp.SelectedIndex!=-1) 
			{
                dtp = m.get_data("select * from " + user + ".dmphong where makp='" + makp.SelectedValue.ToString() + "' order by stt").Tables[0];
				phong.DataSource=dtp;
			}

			load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
		}

		private void load_grid()
		{
			if (phong.SelectedIndex!=-1)
                sql = "select a.*,b.chenhlech from " + user + ".dmgiuong a,"+user+".v_giavp b where a.id=b.id and a.idphong=" + int.Parse(phong.SelectedValue.ToString()) + " order by a.stt";
			else
                sql = "select a.*,b.chenhlech from " + user + ".dmgiuong a,"+user+".v_giavp b where a.id=b.id and a.idphong=0 order by a.stt";
            dt = m.get_data(sql).Tables[0];
            dataGrid1.DataSource = dt;
            ref_text();
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

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "stt";
			TextCol.HeaderText = "Stt";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã số";
			TextCol.Width = 80;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên";
			TextCol.Width = 110;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "bhyt";
			TextCol.HeaderText = "BHYT";
			TextCol.Width = 40;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "gia_th";
			TextCol.HeaderText = "Đơn giá";
			TextCol.Width = 63;
			TextCol.Alignment=HorizontalAlignment.Right;
			TextCol.Format="### ### ###";
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "gia_bh";
			TextCol.HeaderText = "Bảo hiểm";
			TextCol.Width = 63;
			TextCol.Alignment=HorizontalAlignment.Right;
			TextCol.Format="### ### ###";
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "gia_cs";
			TextCol.HeaderText = "Chính sách";
			TextCol.Width = 63;
			TextCol.Alignment=HorizontalAlignment.Right;
			TextCol.Format="### ### ###";
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "gia_dv";
			TextCol.HeaderText = "Dịch vụ";
			TextCol.Width = 63;
			TextCol.Alignment=HorizontalAlignment.Right;
			TextCol.Format="### ### ###";
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "gia_nn";
			TextCol.HeaderText = "Nước ngoài";
			TextCol.Width = 63;
			TextCol.Alignment=HorizontalAlignment.Right;
			TextCol.Format="### ### ###";
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "chenhlech";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void ten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ena_object(bool ena)
		{
			makp.Enabled=!ena;
			phong.Enabled=!ena;
			stt.Enabled=ena;
			ma.Enabled=ena;
			ten.Enabled=ena;
			bhyt.Enabled=ena;
			gia_th.Enabled=ena;
			gia_bh.Enabled=ena;
			gia_cs.Enabled=ena;
			gia_dv.Enabled=ena;
			gia_nn.Enabled=ena;
            chkChenhlech.Enabled = ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			if (phong.SelectedIndex==-1)
			{
				phong.Focus();
				return;
			}
			id=0;
			try
			{
                stt.Value = decimal.Parse(m.get_data("select max(stt) from " + user + ".dmgiuong where idphong=" + int.Parse(phong.SelectedValue.ToString())).Tables[0].Rows[0][0].ToString()) + 1;
			}
			catch{stt.Value=1;}
			ma.Text=dtp.Rows[phong.SelectedIndex]["ma"].ToString().Trim()+"-"+stt.Value.ToString().Trim();ten.Text="";
            gia_th.Text = ""; gia_bh.Text = ""; gia_cs.Text = ""; gia_dv.Text = ""; gia_nn.Text = ""; chkChenhlech.Checked = false;
			ena_object(true);
			stt.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (id==0) return;
			ena_object(true);
			stt.Focus();
		}

		private bool kiemtra()
		{
			if (ma.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập mã số !"),LibMedi.AccessData.Msg);
				ma.Focus();
				return false;
			}
			if (ten.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập tên !"),LibMedi.AccessData.Msg);
				ten.Focus();
				return false;
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
            if (id==0) id=v.get_id_giavp;
			if (!m.upd_dmgiuong(int.Parse(phong.SelectedValue.ToString()),id,stt.Value,ma.Text,ten.Text,decimal.Parse(bhyt.SelectedValue.ToString()),(gia_th.Text!="")?decimal.Parse(gia_th.Text):0,(gia_bh.Text!="")?decimal.Parse(gia_bh.Text):0,(gia_cs.Text!="")?decimal.Parse(gia_cs.Text):0,(gia_dv.Text!="")?decimal.Parse(gia_dv.Text):0,(gia_nn.Text!="")?decimal.Parse(gia_nn.Text):0,i_userid))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật thông tin !"));
				return;
			}
            v.upd_giavp(id, int.Parse(dtp.Rows[phong.SelectedIndex]["loaivp"].ToString()), Convert.ToInt16(stt.Value), ma.Text, ten.Text, "Ngày", (gia_th.Text != "") ? decimal.Parse(gia_th.Text) : 0, (gia_bh.Text != "") ? decimal.Parse(gia_bh.Text) : 0, (gia_cs.Text != "") ? decimal.Parse(gia_cs.Text) : 0,(gia_dv.Text != "") ? decimal.Parse(gia_dv.Text) : 0, (gia_nn.Text != "") ? decimal.Parse(gia_nn.Text) : 0,0, i_userid, 0, 0, 0, 0, 0, 0, 0,(chkChenhlech.Checked)?1:0,"");
            v.execute_data("update " + user + ".v_giavp set bhyt=" + decimal.Parse(bhyt.SelectedValue.ToString()) + " where id=" + id);
			load_grid();
			ena_object(false);
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (id==0) return;
			if (m.get_data("select * from "+user+".theodoigiuong where idgiuong="+id).Tables[0].Rows.Count>0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Giường đang sử dụng !"),LibMedi.AccessData.Msg);
				return;
			}
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này !"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
                m.execute_data("delete from " + user + ".dmgiuong where id=" + id);
                m.execute_data("delete from " + user + ".v_giavp where id=" + id);
				load_grid();
			}
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				id=long.Parse(dataGrid1[i,0].ToString());
				stt.Value=decimal.Parse(dataGrid1[i,1].ToString());
				ma.Text=dataGrid1[i,2].ToString();
				ten.Text=dataGrid1[i,3].ToString();
				bhyt.SelectedValue=dataGrid1[i,4].ToString();
				decimal gia=decimal.Parse(dataGrid1[i,5].ToString());
				gia_th.Text=gia.ToString("###,###,###");
				gia=decimal.Parse(dataGrid1[i,6].ToString());
				gia_bh.Text=gia.ToString("###,###,###");
				gia=decimal.Parse(dataGrid1[i,7].ToString());
				gia_cs.Text=gia.ToString("###,###,###");
				gia=decimal.Parse(dataGrid1[i,8].ToString());
				gia_dv.Text=gia.ToString("###,###,###");
				gia=decimal.Parse(dataGrid1[i,9].ToString());
				gia_nn.Text=gia.ToString("###,###,###.00");
                chkChenhlech.Checked = dataGrid1[i, 10].ToString() == "1";
			}
			catch{}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void frmDmgiuong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

		private void makp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==makp && makp.SelectedIndex!=-1)
			{
                dtp = m.get_data("select * from " + user + ".dmphong where makp='" + makp.SelectedValue.ToString() + "' order by stt").Tables[0];
				phong.DataSource=dtp;
				load_grid();
			}
		}

		private void phong_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==phong && phong.SelectedIndex!=-1) load_grid();		
		}

		private void gia_th_Validated(object sender, System.EventArgs e)
		{
			try
			{
				decimal gia=(gia_th.Text!="")?decimal.Parse(gia_th.Text):0;
				gia_th.Text=gia.ToString("###,###,###");
				if (gia_bh.Text=="") gia_bh.Text=gia_th.Text;
				if (gia_cs.Text=="") gia_cs.Text=gia_th.Text;
				if (gia_dv.Text=="") gia_dv.Text=gia_th.Text;
				if (gia_nn.Text=="") gia_nn.Text=gia_th.Text;
			}
			catch{gia_th.Text="";}
		}

		private void gia_bh_Validated(object sender, System.EventArgs e)
		{
			try
			{
				decimal gia=(gia_bh.Text!="")?decimal.Parse(gia_bh.Text):0;
				gia_bh.Text=gia.ToString("###,###,###");
			}
			catch{gia_bh.Text="";}
		
		}

		private void gia_cs_Validated(object sender, System.EventArgs e)
		{
			try
			{
				decimal gia=(gia_cs.Text!="")?decimal.Parse(gia_cs.Text):0;
				gia_cs.Text=gia.ToString("###,###,###");
			}
			catch{gia_cs.Text="";}
		}

		private void gia_nn_Validated(object sender, System.EventArgs e)
		{
			try
			{
				decimal gia=(gia_nn.Text!="")?decimal.Parse(gia_nn.Text):0;
				gia_nn.Text=gia.ToString("###,###,###.00");
			}
			catch{gia_nn.Text="";}		
		}

		private void ma_Validated(object sender, System.EventArgs e)
		{
			if (ma.Text!="")
			{
				if (ten.Text=="") ten.Text=ma.Text;
				if (m.bMagiuong(id,ma.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Mã đã nhập !"),LibMedi.AccessData.Msg);
					ma.Focus();
					return;
				}
			}
		}

		private void ten_Validated(object sender, System.EventArgs e)
		{
			DataRow r=m.getrowbyid(dt,"ten='"+ten.Text+"' and id<>"+id);
			if (r!=null)
			{
				MessageBox.Show(lan.Change_language_MessageText("Tên đã nhập !"),LibMedi.AccessData.Msg);
				ten.Focus();
				return;
			}
		}

		private void bhyt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (bhyt.SelectedIndex==-1) bhyt.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void gia_dv_Validated(object sender, System.EventArgs e)
		{
			try
			{
				decimal gia=(gia_dv.Text!="")?decimal.Parse(gia_dv.Text):0;
				gia_dv.Text=gia.ToString("###,###,###");
			}
			catch{gia_dv.Text="";}		
		}
	}
}
