using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;

namespace Medisoft
{
	public class frmdmchinhanh : System.Windows.Forms.Form
    {
        DataTable dttenvien = new DataTable();
        #region Khai bao
        Language lan = new Language();
        Bogotiengviet tv = new Bogotiengviet();
        private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData m;
		private DataTable dt=new DataTable();
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
        private System.Windows.Forms.Button butHuy;
		private bool bNew;
		private int i_id;
        private string user;
		private System.Windows.Forms.Button butSua;
        private TextBox txtid;
        private TextBox txtten;
        private Label label2;
        private TextBox txtip;
        private Label label3;
        private TextBox txtdatabaselink;
        private Label label4;
        private TextBox txtviettat;
        private Label label5;
        private CheckBox chkserver;
        private Label label6;
        protected MaskedTextBox.MaskedTextBox mabv;
        private string s_mabv = "";
        private Label label7;
        private TextBox txtDatabase;
        private Label label8;
        private TextBox txtTenvien;
        private LibList.List listTenvien;
        private System.Windows.Forms.MaskedTextBox txtPort;
		private System.ComponentModel.Container components = null;
        #endregion

        public frmdmchinhanh(AccessData acc)
		{
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
		}

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmdmchinhanh));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.butMoi = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.txtid = new System.Windows.Forms.TextBox();
            this.txtten = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtip = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtdatabaselink = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtviettat = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkserver = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mabv = new MaskedTextBox.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTenvien = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.MaskedTextBox();
            this.listTenvien = new LibList.List();
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
            this.dataGrid1.Location = new System.Drawing.Point(8, -15);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(624, 332);
            this.dataGrid1.TabIndex = 9;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(562, 415);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 26);
            this.butKetthuc.TabIndex = 15;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(18, 320);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã số:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(217, 415);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(64, 26);
            this.butMoi.TabIndex = 12;
            this.butMoi.Text = "   &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(352, 415);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 26);
            this.butLuu.TabIndex = 10;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(422, 415);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 26);
            this.butBoqua.TabIndex = 11;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(492, 415);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 26);
            this.butHuy.TabIndex = 13;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(282, 415);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 26);
            this.butSua.TabIndex = 14;
            this.butSua.Text = "   &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // txtid
            // 
            this.txtid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtid.BackColor = System.Drawing.Color.White;
            this.txtid.Enabled = false;
            this.txtid.Location = new System.Drawing.Point(79, 323);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(51, 20);
            this.txtid.TabIndex = 0;
            this.txtid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbv_KeyDown);
            // 
            // txtten
            // 
            this.txtten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtten.BackColor = System.Drawing.Color.White;
            this.txtten.Enabled = false;
            this.txtten.Location = new System.Drawing.Point(181, 323);
            this.txtten.Name = "txtten";
            this.txtten.Size = new System.Drawing.Size(451, 20);
            this.txtten.TabIndex = 1;
            this.txtten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbv_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(146, 320);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 12;
            this.label2.Text = "Tên:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtip
            // 
            this.txtip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtip.BackColor = System.Drawing.Color.White;
            this.txtip.Enabled = false;
            this.txtip.Location = new System.Drawing.Point(467, 367);
            this.txtip.Name = "txtip";
            this.txtip.Size = new System.Drawing.Size(165, 20);
            this.txtip.TabIndex = 5;
            this.txtip.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbv_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(434, 365);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 23);
            this.label3.TabIndex = 16;
            this.label3.Text = "IP :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtdatabaselink
            // 
            this.txtdatabaselink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdatabaselink.BackColor = System.Drawing.Color.White;
            this.txtdatabaselink.Enabled = false;
            this.txtdatabaselink.Location = new System.Drawing.Point(79, 367);
            this.txtdatabaselink.Name = "txtdatabaselink";
            this.txtdatabaselink.Size = new System.Drawing.Size(354, 20);
            this.txtdatabaselink.TabIndex = 4;
            this.txtdatabaselink.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbv_KeyDown);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Location = new System.Drawing.Point(-6, 365);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 23);
            this.label4.TabIndex = 14;
            this.label4.Text = "Database link:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtviettat
            // 
            this.txtviettat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtviettat.BackColor = System.Drawing.Color.White;
            this.txtviettat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtviettat.Enabled = false;
            this.txtviettat.Location = new System.Drawing.Point(79, 389);
            this.txtviettat.Name = "txtviettat";
            this.txtviettat.Size = new System.Drawing.Size(51, 20);
            this.txtviettat.TabIndex = 6;
            this.txtviettat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbv_KeyDown);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Location = new System.Drawing.Point(14, 387);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 23);
            this.label5.TabIndex = 18;
            this.label5.Text = "Viết tắt:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkserver
            // 
            this.chkserver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkserver.AutoSize = true;
            this.chkserver.Location = new System.Drawing.Point(528, 391);
            this.chkserver.Name = "chkserver";
            this.chkserver.Size = new System.Drawing.Size(104, 17);
            this.chkserver.TabIndex = 9;
            this.chkserver.Text = "Server trung tâm";
            this.chkserver.UseVisualStyleBackColor = true;
            this.chkserver.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbv_KeyDown);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.Location = new System.Drawing.Point(5, 344);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 21);
            this.label6.TabIndex = 19;
            this.label6.Text = "Mã chi nhánh:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mabv
            // 
            this.mabv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mabv.BackColor = System.Drawing.Color.White;
            this.mabv.Enabled = false;
            this.mabv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabv.Location = new System.Drawing.Point(79, 345);
            this.mabv.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabv.MaxLength = 8;
            this.mabv.Name = "mabv";
            this.mabv.Size = new System.Drawing.Size(97, 21);
            this.mabv.TabIndex = 2;
            this.mabv.Validated += new System.EventHandler(this.mabv_Validated);
            this.mabv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbv_KeyDown);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(434, 388);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 20);
            this.label7.TabIndex = 77;
            this.label7.Text = "Port:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDatabase
            // 
            this.txtDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDatabase.BackColor = System.Drawing.Color.White;
            this.txtDatabase.Enabled = false;
            this.txtDatabase.Location = new System.Drawing.Point(181, 389);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(252, 20);
            this.txtDatabase.TabIndex = 7;
            this.txtDatabase.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbv_KeyDown);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.Location = new System.Drawing.Point(128, 387);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 23);
            this.label8.TabIndex = 80;
            this.label8.Text = "Database:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTenvien
            // 
            this.txtTenvien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenvien.BackColor = System.Drawing.Color.White;
            this.txtTenvien.Enabled = false;
            this.txtTenvien.Location = new System.Drawing.Point(181, 345);
            this.txtTenvien.Name = "txtTenvien";
            this.txtTenvien.Size = new System.Drawing.Size(451, 20);
            this.txtTenvien.TabIndex = 3;
            this.txtTenvien.TextChanged += new System.EventHandler(this.txtTenvien_TextChanged);
            this.txtTenvien.Validated += new System.EventHandler(this.txtTenvien_Validated);
            this.txtTenvien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenvien_KeyDown);
            // 
            // txtPort
            // 
            this.txtPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPort.BackColor = System.Drawing.Color.White;
            this.txtPort.Enabled = false;
            this.txtPort.Location = new System.Drawing.Point(467, 388);
            this.txtPort.Mask = "0000";
            this.txtPort.Name = "txtPort";
            this.txtPort.PromptChar = ' ';
            this.txtPort.Size = new System.Drawing.Size(55, 20);
            this.txtPort.TabIndex = 8;
            this.txtPort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbv_KeyDown);
            // 
            // listTenvien
            // 
            this.listTenvien.BackColor = System.Drawing.SystemColors.Info;
            this.listTenvien.ColumnCount = 0;
            this.listTenvien.FormattingEnabled = true;
            this.listTenvien.Location = new System.Drawing.Point(89, 414);
            this.listTenvien.MatchBufferTimeOut = 1000;
            this.listTenvien.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listTenvien.Name = "listTenvien";
            this.listTenvien.Size = new System.Drawing.Size(75, 17);
            this.listTenvien.TabIndex = 82;
            this.listTenvien.TextIndex = -1;
            this.listTenvien.TextMember = null;
            this.listTenvien.ValueIndex = -1;
            this.listTenvien.Visible = false;
            // 
            // frmdmchinhanh
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(644, 443);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.listTenvien);
            this.Controls.Add(this.txtTenvien);
            this.Controls.Add(this.txtviettat);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.mabv);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkserver);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtip);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtdatabaselink);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtten);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmdmchinhanh";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục chi nhánh";
            this.Load += new System.EventHandler(this.frmdmchinhanh_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmdmchinhanh_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmdmchinhanh_Load(object sender, System.EventArgs e)
		{
            user = m.user;
            ena_form(false);
            //ena_object(false);
            load_tenvien();
			load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			ref_text();
		}

		private void load_grid()
		{
            dt = m.get_data("select * from " + user + ".dmchinhanh order by ten").Tables[0];
			dataGrid1.DataSource=dt;
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
						
			DataGridTextBoxColumn TextCol=new DataGridTextBoxColumn();//0
			TextCol.MappingName = "id";
			TextCol.HeaderText = "ID";
			TextCol.Width = 0;
            TextCol.NullText = "";
			ts.GridColumnStyles.Add(TextCol);
			

			TextCol=new DataGridTextBoxColumn();//1
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên";
			TextCol.Width =170;
            TextCol.NullText = "";
            ts.GridColumnStyles.Add(TextCol);
			

			TextCol=new DataGridTextBoxColumn();//2
			TextCol.MappingName = "database";
            TextCol.HeaderText = "Database Links";
			TextCol.Width = 150;
            TextCol.NullText = "";
            ts.GridColumnStyles.Add(TextCol);
			

            TextCol = new DataGridTextBoxColumn();//3
            TextCol.MappingName = "ip";
            TextCol.HeaderText = "IP";
            TextCol.Width = 100;
            TextCol.NullText = "";
            ts.GridColumnStyles.Add(TextCol);
            

            TextCol = new DataGridTextBoxColumn();//4
            TextCol.MappingName = "viettat";
            TextCol.HeaderText = "Viết tắt";
            TextCol.Width = 100;
            TextCol.NullText = "";
            ts.GridColumnStyles.Add(TextCol);
            

            TextCol = new DataGridTextBoxColumn();//5
            TextCol.MappingName = "trungtam";
            TextCol.HeaderText = "TT";
            TextCol.Width = 30;
            TextCol.NullText = "";
            ts.GridColumnStyles.Add(TextCol);
            

            TextCol = new DataGridTextBoxColumn();//6
            TextCol.MappingName = "mabv";
            TextCol.HeaderText = "Mã bv";
            TextCol.Width = 80;
            TextCol.NullText = "";
            ts.GridColumnStyles.Add(TextCol);

            TextCol = new DataGridTextBoxColumn();//7
            TextCol.MappingName = "database_local";
            TextCol.HeaderText = "Database Local";
            TextCol.NullText = "";
            TextCol.Width = 100;
            TextCol.NullText = "";
            ts.GridColumnStyles.Add(TextCol);

            TextCol = new DataGridTextBoxColumn();//8
            TextCol.MappingName = "port";
            TextCol.HeaderText = "Port";
            TextCol.NullText = "";
            TextCol.Width = 60;
            TextCol.NullText = "";
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Clear();
            dataGrid1.TableStyles.Add(ts);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
            int flag = 0;
            foreach (DataRow r in dt.Rows)
            {
                if (r["trungtam"].ToString().Trim() == "1") { flag = 1; break; }
            }
            if (flag == 0 && dt.Rows.Count>0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Bạn chưa chọn server trung tâm!"));
                chkserver.Focus();
                return;
            }
			m.close();this.Close();
		}

        private void ena_form(bool ena)
        {
           // txtid.Enabled = false;
            txtten.Enabled = ena;
            txtdatabaselink.Enabled = ena;
            txtip.Enabled = ena;
            txtviettat.Enabled = ena;
            txtTenvien.Enabled = ena;
            mabv.Enabled = ena;
            chkserver.Enabled = ena;
            txtPort.Enabled = ena;
            txtDatabase.Enabled = ena;
            dataGrid1.Enabled = !ena;
        }
		private void ena_object(bool ena)
		{
			butMoi.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			butSua.Enabled=!ena;
            
		}

        private void emp_object()
        {
            txtid.Text = "";
            txtten.Text = "";
            txtdatabaselink.Text = "";
            txtip.Text = "";
            txtviettat.Text = "";
            mabv.Text = "";
            txtTenvien.Text = "";
            s_mabv = "";
            chkserver.Checked = false;
        }
		private void butMoi_Click(object sender, System.EventArgs e)
		{
			bNew=true;
            //i_id = 0;            
			ena_object(true);
            ena_form(true);
            emp_object();
			txtten.Focus();
            i_id = f_get_id_chinhanh();
            txtid.Text = i_id.ToString();//txtid.Text = get_id().ToString();
		}

        private int get_id()
        {
            i_id = 1;
            try
            {
                i_id = int.Parse(m.get_data("select max(id) from " + user + ".dmchinhanh").Tables[0].Rows[0][0].ToString()) + 1;
            }
            catch { i_id = 1; }
            return i_id;
        }

		private bool kiemtra()
		{
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Select("id<>" + txtid.Text.Trim() + ""))
                {
                    if (txtten.Text.Trim()!="" && txtten.Text.Trim() == r["ten"].ToString().Trim())
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Tên chi nhánh này đã tồn tại, xem lại!"));
                        txtten.Focus();
                        return false;
                    }
                    //if (txtip.Text.Trim() != "" && txtip.Text.Trim() == r["ip"].ToString().Trim())
                    //{
                    //    MessageBox.Show(lan.Change_language_MessageText("IP này đã tồn tại, xem lại!"));
                    //    txtip.Focus();
                    //    return false;
                    //}
                    if (txtdatabaselink.Text.Trim() != "" && txtdatabaselink.Text.Trim() == r["database"].ToString().Trim())
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Tên database này đã tồn tại, xem lại!"));
                        txtdatabaselink.Focus();
                        return false;
                    }
                    if (txtviettat.Text.Trim()!="" && txtviettat.Text.Trim() == r["viettat"].ToString().Trim())
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Tên viết tắt này đã tồn tại, xem lại!"));
                        txtviettat.Focus();
                        return false;
                    }
                }
            }
            if (chkserver.Checked)
            {
                foreach (DataRow r in dt.Select("id<>"+txtid.Text.Trim()+""))
                {
                    if (r["trungtam"].ToString().Trim() == "1")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Chỉ được chọn 1 server trung tâm!"));
                        return false;
                    }
                }                
            }
            if (txtPort.Text.Trim() == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Vui lòng nhập Port server!"));
                return false;
            }
            if (txtDatabase.Text.Trim() == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Database local server!"));
                return false;
            }
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
            if (i_id == 0)
            {
                i_id = f_get_id_chinhanh();//binh 01062011
            }
            if (!m.upd_dmchinhanh(i_id, txtten.Text, txtdatabaselink.Text.Trim(), txtip.Text, txtviettat.Text, (chkserver.Checked) ? 1 : 0, mabv.Text.Trim(),txtPort.Text,txtDatabase.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật thông tin !"));
                return;
            }
            //linh
            m.execute_data("drop database link " + txtdatabaselink.Text.Trim());
            m.execute_data("CREATE PUBLIC DATABASE LINK " + txtdatabaselink.Text.Trim() + " CONNECT TO " + m.User_database + " IDENTIFIED BY '" + m.Password_database + "' USING libpq 'host=" + txtip.Text.Trim() + " port=" + txtPort.Text + " dbname=" + txtDatabase.Text + "';");
            //end linh
			load_grid();
            ena_form(false);
			ena_object(false);
            try
            {
                butMoi.Focus();
            }
            catch{}
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
            load_grid();
            ena_form(false);
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này !"),AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					i_id=int.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,0].ToString());
                    DataTable dt_xoa = m.get_data("select id from "+user+".dmchinhanh where id="+i_id+" and id not in(select chinhanh from "+user+".dlogin)").Tables[0];
                    if (dt_xoa.Rows.Count > 0)
                        m.execute_data("delete from " + user + ".dmchinhanh where id=" + i_id + " and id not in(select chinhanh from " + user + ".dlogin)");
                    else MessageBox.Show(lan.Change_language_MessageText("Chi nhánh này đã dùng rồi không thể xóa!"), LibMedi.AccessData.Msg);
					load_grid();
				}
			}
			catch{}
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				txtid.Text=dataGrid1[i,0].ToString();
				txtten.Text=dataGrid1[i,1].ToString();
                txtdatabaselink.Text = dataGrid1[i, 2].ToString();
                txtip.Text = dataGrid1[i, 3].ToString();
                txtviettat.Text = dataGrid1[i, 4].ToString();
                if (dataGrid1[i, 5].ToString() == "1") chkserver.Checked = true;
                else chkserver.Checked = false;
                mabv.Text = dataGrid1[i, 6].ToString();
                mabv_Validated(null, null);
                s_mabv = dataGrid1[i, 6].ToString();
                txtDatabase.Text = dataGrid1[i, 7].ToString();
                txtPort.Text = dataGrid1[i, 8].ToString();
			}
			catch{}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void frmdmchinhanh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			try
			{
				i_id=int.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,0].ToString());
				bNew=false;
                ena_form(true);
				ena_object(true);
				txtten.Focus();
                mabv.Text = s_mabv;
			}
			catch{}
		}

        private int f_get_id_chinhanh()
        {
            int i_idcn = 0;
            string exp = "";
            DataSet lds = m.get_data("select id from " + user + ".dmchinhanh");
            DataRow dr;
            bool b_id = false;
            for (int i = 1; i < 10; i++)
            {
                i_idcn = i;
                exp = "id=" + i_idcn;
                dr = m.getrowbyid(lds.Tables[0], exp);
                if (dr == null) { b_id = true; break; }
            }
            if (b_id==false && i_idcn >= 10)
            {
                i_idcn = int.Parse(m.get_data("select max(id) as id from " + user + ".dmchinhanh").Tables[0].Rows[0][0].ToString()) + 1;
            }
            return i_idcn;
        }

        private void mabv_Validated(object sender, EventArgs e)
        {
            try
            {
                if (mabv.Text != "")
                {
                    DataRow rbv = m.getrowbyid(dttenvien, "mabv='" + mabv.Text + "'");
                    if (rbv != null)
                    {
                        txtTenvien.Text = rbv["tenbv"].ToString();
                    }
                }
                else
                {
                    txtTenvien.Text = "";
                }
            }
            catch { }
        }
        private void load_tenvien()
        {
            dttenvien=m.get_data("select mabv,tenbv from " + user + ".tenvien").Tables[0];
            listTenvien.DataSource = dttenvien;
            listTenvien.DisplayMember = "TENBV";
            listTenvien.ValueMember = "TENBV";
        }

        private void tenbv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtPort_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{Home}");
            txtPort.SelectAll();
        }

        private void txtTenvien_TextChanged(object sender, EventArgs e)
        {
            if (ActiveControl == txtTenvien)
            {
                Filt_dstt(txtTenvien.Text);
                listTenvien.BrowseToText(txtTenvien, mabv, txtdatabaselink, mabv.Location.X, mabv.Location.Y + mabv.Height, mabv.Width + txtTenvien.Width + 2, mabv.Height);
            }
        }
        private void Filt_dstt(string ten)
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[listTenvien.DataSource];
            DataView dv = (DataView)cm.List;
            dv.RowFilter = "tenbv like '%" + ten.Trim() + "%'";
            if (dv.Table.Rows.Count == 0) listTenvien.Hide();
            else listTenvien.Visible = true;
        }

        private void txtTenvien_Validated(object sender, EventArgs e)
        {
            if (!listTenvien.Focused)
            {
                listTenvien.Hide();
            }
        }

        private void txtTenvien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listTenvien.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listTenvien.Visible)
                {
                    listTenvien.Focus();
                    SendKeys.Send("{Down}");
                }
                else SendKeys.Send("{Tab}");
            }
        }
	}
}
