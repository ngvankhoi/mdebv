using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
namespace dllDanhmucMedisoft
{
	/// <summary>
	/// Summary description for frmDm.
	/// </summary>
	public class frmDmbsgioithieu : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData m;
		private DataTable dt=new DataTable();
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.TextBox txtmanv;
        private System.Windows.Forms.TextBox txtten;
        private string user;
        private int itable, i_userid;
        private TextBox txtmabv;
        private Label label3;
        private TextBox txttenbv;
        private TextBox txttennv;
        private Label label5;
        private TextBox txtmabs;
        private AsYetUnnamed.MultiColumnListBox list_bv;
        private AsYetUnnamed.MultiColumnListBox list_nv;
        private Label label4;
        private TextBox txtemail;
        private Label label7;
        private TextBox txtdtnha;
        private Label label8;
        private TextBox txtdtdidong;
        private Label label9;
        private System.Windows.Forms.MaskedTextBox mtbngaysinh;
        private Label label6;
        private TextBox txtdiachi;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public frmDmbsgioithieu(AccessData acc, int userid)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDmbsgioithieu));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtmanv = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtten = new System.Windows.Forms.TextBox();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.txtmabv = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txttenbv = new System.Windows.Forms.TextBox();
            this.txttennv = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtmabs = new System.Windows.Forms.TextBox();
            this.list_bv = new AsYetUnnamed.MultiColumnListBox();
            this.list_nv = new AsYetUnnamed.MultiColumnListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtdtnha = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtdtdidong = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.mtbngaysinh = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtdiachi = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
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
            this.dataGrid1.Location = new System.Drawing.Point(7, -16);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(785, 400);
            this.dataGrid1.TabIndex = 19;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(525, 500);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 18;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(495, 429);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Nơi làm việc :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtmanv
            // 
            this.txtmanv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtmanv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtmanv.Enabled = false;
            this.txtmanv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmanv.Location = new System.Drawing.Point(565, 399);
            this.txtmanv.MaxLength = 4;
            this.txtmanv.Name = "txtmanv";
            this.txtmanv.Size = new System.Drawing.Size(60, 21);
            this.txtmanv.TabIndex = 2;
            this.txtmanv.Validated += new System.EventHandler(this.txtmanv_Validated);
            this.txtmanv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(127, 398);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 22);
            this.label2.TabIndex = 23;
            this.label2.Text = "Họ và tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtten
            // 
            this.txtten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtten.Enabled = false;
            this.txtten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtten.Location = new System.Drawing.Point(187, 399);
            this.txtten.Name = "txtten";
            this.txtten.Size = new System.Drawing.Size(297, 21);
            this.txtten.TabIndex = 1;
            this.txtten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(175, 500);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 14;
            this.butMoi.Text = "     &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(245, 500);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 15;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(315, 500);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 13;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(385, 500);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 16;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(455, 500);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 17;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // txtmabv
            // 
            this.txtmabv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtmabv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtmabv.Enabled = false;
            this.txtmabv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmabv.Location = new System.Drawing.Point(565, 426);
            this.txtmabv.MaxLength = 20;
            this.txtmabv.Name = "txtmabv";
            this.txtmabv.Size = new System.Drawing.Size(60, 21);
            this.txtmabv.TabIndex = 6;
            this.txtmabv.Validated += new System.EventHandler(this.txtmabv_Validated);
            this.txtmabv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtstt_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(490, 399);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 22);
            this.label3.TabIndex = 34;
            this.label3.Text = "NVPT:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txttenbv
            // 
            this.txttenbv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txttenbv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txttenbv.Enabled = false;
            this.txttenbv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttenbv.Location = new System.Drawing.Point(625, 426);
            this.txttenbv.MaxLength = 3000;
            this.txttenbv.Name = "txttenbv";
            this.txttenbv.Size = new System.Drawing.Size(162, 21);
            this.txttenbv.TabIndex = 7;
            this.txttenbv.TextChanged += new System.EventHandler(this.txttenbv_TextChanged);
            this.txttenbv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txttenbv_KeyDown);
            // 
            // txttennv
            // 
            this.txttennv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txttennv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txttennv.Enabled = false;
            this.txttennv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttennv.Location = new System.Drawing.Point(625, 399);
            this.txttennv.MaxLength = 3000;
            this.txttennv.Name = "txttennv";
            this.txttennv.Size = new System.Drawing.Size(162, 21);
            this.txttennv.TabIndex = 3;
            this.txttennv.TextChanged += new System.EventHandler(this.txttennv_TextChanged);
            this.txttennv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txttennv_KeyDown);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Location = new System.Drawing.Point(56, 399);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 23);
            this.label5.TabIndex = 34;
            this.label5.Text = "Mã:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtmabs
            // 
            this.txtmabs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtmabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtmabs.Enabled = false;
            this.txtmabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmabs.Location = new System.Drawing.Point(84, 399);
            this.txtmabs.MaxLength = 4;
            this.txtmabs.Name = "txtmabs";
            this.txtmabs.Size = new System.Drawing.Size(37, 21);
            this.txtmabs.TabIndex = 0;
            this.txtmabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtstt_KeyDown);
            // 
            // list_bv
            // 
            this.list_bv.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.list_bv.BackColor = System.Drawing.SystemColors.Info;
            this.list_bv.ColumnCount = 0;
            this.list_bv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_bv.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.list_bv.FormattingEnabled = true;
            this.list_bv.Location = new System.Drawing.Point(764, 426);
            this.list_bv.MatchBufferTimeOut = 1000;
            this.list_bv.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.list_bv.Name = "list_bv";
            this.list_bv.Size = new System.Drawing.Size(23, 17);
            this.list_bv.TabIndex = 8;
            this.list_bv.TextIndex = -1;
            this.list_bv.TextMember = null;
            this.list_bv.ValueIndex = -1;
            this.list_bv.Visible = false;
            this.list_bv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_bv_KeyDown);
            // 
            // list_nv
            // 
            this.list_nv.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.list_nv.BackColor = System.Drawing.SystemColors.Info;
            this.list_nv.ColumnCount = 0;
            this.list_nv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_nv.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.list_nv.FormattingEnabled = true;
            this.list_nv.Location = new System.Drawing.Point(764, 400);
            this.list_nv.MatchBufferTimeOut = 1000;
            this.list_nv.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.list_nv.Name = "list_nv";
            this.list_nv.Size = new System.Drawing.Size(15, 17);
            this.list_nv.TabIndex = 4;
            this.list_nv.TextIndex = -1;
            this.list_nv.TextMember = null;
            this.list_nv.ValueIndex = -1;
            this.list_nv.Visible = false;
            this.list_nv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_nv_KeyDown);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(528, 456);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Email :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtemail
            // 
            this.txtemail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtemail.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtemail.Enabled = false;
            this.txtemail.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtemail.Location = new System.Drawing.Point(565, 452);
            this.txtemail.MaxLength = 100;
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(222, 21);
            this.txtemail.TabIndex = 12;
            this.txtemail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtstt_KeyDown);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(157, 456);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Điện Thoại :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtdtnha
            // 
            this.txtdtnha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdtnha.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtdtnha.Enabled = false;
            this.txtdtnha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdtnha.Location = new System.Drawing.Point(220, 453);
            this.txtdtnha.MaxLength = 25;
            this.txtdtnha.Name = "txtdtnha";
            this.txtdtnha.Size = new System.Drawing.Size(112, 21);
            this.txtdtnha.TabIndex = 10;
            this.txtdtnha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtstt_KeyDown);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(344, 456);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Di động :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtdtdidong
            // 
            this.txtdtdidong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdtdidong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtdtdidong.Enabled = false;
            this.txtdtdidong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdtdidong.Location = new System.Drawing.Point(393, 453);
            this.txtdtdidong.MaxLength = 11;
            this.txtdtdidong.Name = "txtdtdidong";
            this.txtdtdidong.Size = new System.Drawing.Size(91, 21);
            this.txtdtdidong.TabIndex = 11;
            this.txtdtdidong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtstt_KeyDown);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 456);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Ngày sinh :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mtbngaysinh
            // 
            this.mtbngaysinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mtbngaysinh.Enabled = false;
            this.mtbngaysinh.Location = new System.Drawing.Point(84, 453);
            this.mtbngaysinh.Mask = "00/00/0000";
            this.mtbngaysinh.Name = "mtbngaysinh";
            this.mtbngaysinh.Size = new System.Drawing.Size(66, 20);
            this.mtbngaysinh.TabIndex = 9;
            this.mtbngaysinh.ValidatingType = typeof(System.DateTime);
            this.mtbngaysinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtbngaysinh_KeyDown);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 429);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Địa chỉ :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtdiachi
            // 
            this.txtdiachi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdiachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtdiachi.Enabled = false;
            this.txtdiachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdiachi.Location = new System.Drawing.Point(84, 426);
            this.txtdiachi.MaxLength = 1000;
            this.txtdiachi.Name = "txtdiachi";
            this.txtdiachi.Size = new System.Drawing.Size(400, 21);
            this.txtdiachi.TabIndex = 5;
            this.txtdiachi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtstt_KeyDown);
            // 
            // frmDmbsgioithieu
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(799, 542);
            this.Controls.Add(this.mtbngaysinh);
            this.Controls.Add(this.list_nv);
            this.Controls.Add(this.list_bv);
            this.Controls.Add(this.txtdtdidong);
            this.Controls.Add(this.txtdtnha);
            this.Controls.Add(this.txtdiachi);
            this.Controls.Add(this.txtemail);
            this.Controls.Add(this.txtmabs);
            this.Controls.Add(this.txttennv);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txttenbv);
            this.Controls.Add(this.txtmabv);
            this.Controls.Add(this.txtmanv);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtten);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDmbsgioithieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục bác sĩ giới thiệu";
            this.Load += new System.EventHandler(this.frmDmxutri_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDmxutri_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmDmxutri_Load(object sender, System.EventArgs e)
		{
            user = m.user; 
            //itable = m.tableid("", "dmbschidinh");
            
            load_dm();
			load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

			ref_text();
		}

		private void load_grid()
		{
            dt = m.get_data("select a.id,a.mabs,a.manv,a.ten,a.mabv "
                + ",a.noilamviec tenbv"
                +",a.diachi,a.ngaysinh,a.dienthoainha,a.dtdd,a.email"
                + ",c1.ten tenvung"
                + ",c.id_vung idvung,c.hoten tennv"
                
                + " from " + user + ".dmbschidinh a"                
                + " left join " + user + ".dmbs c on a.manv=c.ma"
                + " left join " + user + ".dmvungsale c1 on c.id_vung=c1.id"
                + " left join " + user + ".tenvien d on a.mabv=d.mabv"
                + " order by a.id").Tables[0];
			dataGrid1.DataSource=dt;
		}
        void load_dm()
        {
            try
            {
                list_bv.DataSource = m.get_data("select mabv,tenbv from " + user + ".tenvien order by tenbv").Tables[0];
                //list_bv.DisplayMember = "mabv";
                //list_bv.ValueMember = "tenbv";
                list_bv.ColumnWidths[0] = 50;
                list_bv.ColumnWidths[1] = 150;
            }
            catch { }
            try
            {
                list_nv.DataSource = m.get_data("select ma,hoten from " + user + ".dmbs order by hoten").Tables[0];
                //list_bv.DisplayMember = "mabv";
                //list_bv.ValueMember = "tenbv";
                list_nv.ColumnWidths[0] = 30;
                list_nv.ColumnWidths[1] = 150;
            }
            catch { }
            
            
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
			//0			
			DataGridTextBoxColumn TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "mabs";
			TextCol.HeaderText = "Mã";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
            //1
			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Họ và tên";
			TextCol.Width = 200;
			ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
            //2
            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tenvung";
            TextCol.HeaderText = "Vùng sale";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
            
            //3
            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "manv";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
            //4
            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tennv";
            TextCol.HeaderText = "NV phụ trách";
            TextCol.Width = 200;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
            //5
            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "mabv";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
            //6
            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tenbv";
            TextCol.HeaderText = "Bệnh viện";
            TextCol.Width = 200;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
            //7
            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "id";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
            //8
            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "idvung";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
            //9
            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ngaysinh";
            TextCol.HeaderText = "Ngày sinh";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
            //10
            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "diachi";
            TextCol.HeaderText = "Địa chỉ";
            TextCol.Width = 150;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
            //11
            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "dienthoainha";
            TextCol.HeaderText = "ĐT nhà";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
            //12
            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "dtdd";
            TextCol.HeaderText = "DTDD";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
            //13
            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "email";
            TextCol.HeaderText = "Email";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void ma_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void ena_object(bool ena)
		{
			txtmabs.Enabled=ena;
			txtten.Enabled=ena;
            txtmabv.Enabled = ena;
            txttenbv.Enabled = ena;
            txtmanv.Enabled = txttennv.Enabled = ena;
            txtdiachi.Enabled = txtdtdidong.Enabled = txtdtnha.Enabled = txtemail.Enabled = mtbngaysinh.Enabled = ena;
            //cbbvungsale.Enabled = ena;
            
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
            txtmabs.Tag = 0;
            txtmabs.Text = "";
			txtmanv.Text=txttennv.Text="";
			txtten.Text="";
            txtdiachi.Text = txtdtdidong.Text = txtdtnha.Text= txtemail.Text = mtbngaysinh.Text = "";
            
            txtmabv.Text = txttenbv.Text = "";
			ena_object(true);
            txtmabs.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
			txtmanv.Enabled=false;
			txtten.Focus();
		}

		private bool kiemtra()
		{
			if (txtmanv.Text=="")
			{
				txtmanv.Focus();
				return false;
			}
			if (txtten.Text=="")
			{
				txtten.Focus();
				return false;
			}

			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return ;
            if (m.get_data("select * from " + user + ".dmbschidinh where id=" + txtmabs.Tag.ToString()).Tables[0].Rows.Count != 0)
            {
                m.upd_eve_tables(itable, i_userid, "upd");
                m.upd_eve_upd_del(itable, i_userid, "upd", txtmabs.Text + "^" + txtten.Text);
            }
            else m.upd_eve_tables(itable, i_userid, "ins");
            if (!m.upd_dmbschidinh(long.Parse(txtmabs.Tag.ToString()), txtmabs.Text, txtten.Text, txttenbv.Text, "", txtmabv.Text, txtmanv.Text
                ,mtbngaysinh.Text,txtdiachi.Text,txtdtnha.Text,txtdtdidong.Text,txtemail.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin bác sĩ giới thiệu !"));
                return;
            }
           
            
			load_grid();
			ena_object(false);
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
            //if (m.get_data("select * from " + user + ".dmbschidinh where id=" + txtmanv.Tag.ToString() ).Tables[0].Rows.Count != 0)
            //{
            //    MessageBox.Show(lan.Change_language_MessageText("Địa điểm đã sử dụng không thể huỷ !"),LibMedi.AccessData.Msg);
            //    return;
            //}
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này !")
                ,LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
                m.upd_eve_tables(itable, i_userid, "del");
                m.upd_eve_upd_del(itable, i_userid, "del", m.fields(user + ".dmbschidinh", "id=" + txtmabs.Tag.ToString()));
                m.execute_data("delete from " + user + ".dmbschidinh where id=" + txtmabs.Tag.ToString());
				load_grid();
			}
		}

		private void mann_Validated(object sender, System.EventArgs e)
		{
			try
			{
                if (m.get_data("select * from " + user + ".dmbschidinh where ma='" + txtmabs.Text + "'").Tables[0].Rows.Count != 0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Mã này đã có !"));
					txtmanv.Focus();
					return;
				}
			}
			catch{}
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
                txtmabs.Tag = dataGrid1[i, 7].ToString();
				txtmabs.Text=dataGrid1[i,0].ToString();
				txtten.Text=dataGrid1[i,1].ToString();
				txtmabv.Text=dataGrid1[i,5].ToString();
                txttenbv.Text = dataGrid1[i, 6].ToString(); ;
                
                txtmanv.Text = dataGrid1[i, 3].ToString();
                txtmanv_Validated(null, null);

                txtdiachi.Text = dataGrid1[i, 10].ToString();
                mtbngaysinh.Text = dataGrid1[i, 9].ToString();
                txtdtnha.Text = dataGrid1[i, 11].ToString();
                txtdtdidong.Text = dataGrid1[i, 12].ToString();
                txtemail.Text = dataGrid1[i, 12].ToString();
                
			}
			catch{}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void ten_Validated(object sender, System.EventArgs e)
		{
			txtten.Text=m.Caps(txtten.Text);
		}

		private void frmDmxutri_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

        private void txtstt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        
        void Filter(DataTable dttam, string filter)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[dttam];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = filter;
            }
            catch { }
        }
        private void txttenbv_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (ActiveControl != txttenbv) return;
                list_bv.Width = txttenbv.Width + txttenbv.Location.X - txtmabv.Location.X;
                list_bv.Height = 100;
                list_bv.Location = new Point(txtmabv.Location.X, txtmabv.Height + txtmabv.Location.Y + 2);
                list_bv.Visible = true;
                Filter((DataTable)list_bv.DataSource, "tenbv like '%"+txttenbv.Text+"%'");
            }
            catch { }
        }

        private void txtmabv_Validated(object sender, EventArgs e)
        {
            try
            {
                DataTable dttam = (DataTable)list_bv.DataSource;
                DataRow[] arrdr = dttam.Select("mabv='" + txtmabv.Text + "'");
                txttenbv.Text = arrdr[0]["tenbv"].ToString();
            }
            catch { txttenbv.Text = txtmabv.Text = ""; }
        }

        private void txttenbv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                list_bv.Visible = false;
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                list_bv.Visible = true;
                list_bv.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                list_bv.Visible = false;
            }
        }

        private void txttennv_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (ActiveControl != txttennv) return;
                list_nv.Width = txttennv.Width + txttennv.Location.X - txtmanv.Location.X;
                list_nv.Height = 100;
                list_nv.Location = new Point(txtmanv.Location.X, txtmanv.Height + txtmanv.Location.Y + 2);
                list_nv.Visible = true;
                Filter((DataTable)list_nv.DataSource, "hoten like '%" + txttennv.Text + "%'");
            }
            catch { }
        }

        private void txtmanv_Validated(object sender, EventArgs e)
        {
            try
            {
                DataTable dttam = (DataTable)list_nv.DataSource;
                DataRow[] arrdr = dttam.Select("ma='" + txtmanv.Text + "'");
                txttennv.Text = arrdr[0]["hoten"].ToString();
            }
            catch { txttennv.Text = txtmanv.Text = ""; }
        }

        private void list_bv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    DataRowView drv =(DataRowView) list_bv.SelectedItem;
                    txtmabv.Text = drv[0].ToString();
                    txtmabv_Validated(null, null);
                    list_bv.Visible = false;
                }
                catch { }
            }
        }
        private void list_nv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    DataRowView drv = (DataRowView)list_nv.SelectedItem;
                    txtmanv.Text = drv[0].ToString();
                    txtmanv_Validated(null, null);
                    list_nv.Visible = false;
                }
                catch { }
            }
        }

        private void txttennv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                list_nv.Visible = true;
                list_nv.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                list_nv.Visible = false;
            }
        }

        private void mtbngaysinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }
       
	}
}
