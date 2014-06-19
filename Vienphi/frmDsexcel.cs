using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;

namespace Vienphi
{
    public  class frmDsexcel : Form
    {
        public string s_ngayhieuluc = "";
        //
        Language lan = new Language();
        //
        DataSet dscn;
        //
        int i_IDCN =0;
        string s_cols = "";
        string s_values = "";
        private int iLoaiImport = 0;
        //
        private LibVP.AccessData m_v = LibVP.AccessData.GetImplement();
		private int i_userid,i_phai;
        private decimal l_doan = 0, l_idcongty=0;
        private string s_mmyy,s_ma = "",s_mabn="",s_hoten="",s_ngaysinh="",s_namsinh="",nam="",s_mann="",s_madantoc="",s_matt="",vd_namsinh="",sql,tenchucvu="";
        private DataTable dt = new DataTable();
		private DataTable dtdv =new DataTable();
		private DataTable dthoten=new DataTable();
		private DataTable dtnn=new DataTable();
		private DataTable dtdkkcb=new DataTable();
        private DataTable dtbtdbn = new DataTable();
		private DataTable dtmuc=new DataTable();
        private DataTable dtchucvu = new DataTable();
        private DataTable mauhs;
        private DataTable donvi;
        private DataSet dsbnksk;
        string id_mau = "";
        private bool bMabn_ct = false;
        public bool bOk = false;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Label lblTenbn;
		private System.Windows.Forms.Label lblDonvi;
		private System.Windows.Forms.Label lblTongso;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtPathImage;
		private System.Windows.Forms.Button butImage;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.DataGrid dataGrid1;
        private Label label3;
        private MaskedTextBox txtNgayhieuluc;
        private CheckBox chkUpdChinhanh;
        private Panel panel1;
        private RadioButton radKTCao_cplon;
        private RadioButton radHSNgtru;
        private RadioButton radBBhoaichan;
        private RadioButton chktenViettat;
        private RadioButton chkmanhom_mack;
        private RadioButton chkCapnhat_mahoabhyt;
        private RadioButton radmaluong;
       
		private DataSet ds=new DataSet();
        public frmDsexcel(LibVP.AccessData acc,string userid)
        {
            InitializeComponent();
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m_v = acc; 			
            i_userid = int.Parse(userid);
            iLoaiImport = (int)LibVP.AccessData.IDLoaiImport.Import_DMKT_gia;
        }
        public frmDsexcel(LibVP.AccessData acc, string userid, int _LoaiImport)
        {
            InitializeComponent();

            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m_v = acc;
            i_userid = int.Parse(userid);
            iLoaiImport = _LoaiImport;
        }
		private System.ComponentModel.IContainer components = null;
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

        #region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDsexcel));
            this.label20 = new System.Windows.Forms.Label();
            this.path = new System.Windows.Forms.TextBox();
            this.butPath = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.butImage = new System.Windows.Forms.Button();
            this.sheet = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tt = new System.Windows.Forms.ComboBox();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.lblTenbn = new System.Windows.Forms.Label();
            this.lblDonvi = new System.Windows.Forms.Label();
            this.lblTongso = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPathImage = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNgayhieuluc = new System.Windows.Forms.MaskedTextBox();
            this.chkUpdChinhanh = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radBBhoaichan = new System.Windows.Forms.RadioButton();
            this.radHSNgtru = new System.Windows.Forms.RadioButton();
            this.radKTCao_cplon = new System.Windows.Forms.RadioButton();
            this.chkCapnhat_mahoabhyt = new System.Windows.Forms.RadioButton();
            this.chkmanhom_mack = new System.Windows.Forms.RadioButton();
            this.chktenViettat = new System.Windows.Forms.RadioButton();
            this.radmaluong = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(2, 12);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(68, 13);
            this.label20.TabIndex = 0;
            this.label20.Text = "Tập tin excel";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // path
            // 
            this.path.BackColor = System.Drawing.SystemColors.HighlightText;
            this.path.Enabled = false;
            this.path.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.path.Location = new System.Drawing.Point(72, 7);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(280, 21);
            this.path.TabIndex = 1;
            // 
            // butPath
            // 
            this.butPath.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butPath.Location = new System.Drawing.Point(356, 7);
            this.butPath.Name = "butPath";
            this.butPath.Size = new System.Drawing.Size(24, 21);
            this.butPath.TabIndex = 2;
            this.butPath.Text = "...";
            this.toolTip1.SetToolTip(this.butPath, "Chọn tập tin");
            this.butPath.Click += new System.EventHandler(this.butPath_Click);
            // 
            // butImage
            // 
            this.butImage.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butImage.Location = new System.Drawing.Point(792, 224);
            this.butImage.Name = "butImage";
            this.butImage.Size = new System.Drawing.Size(24, 21);
            this.butImage.TabIndex = 2;
            this.butImage.Text = "...";
            this.toolTip1.SetToolTip(this.butImage, "Chọn tập tin");
            this.butImage.Visible = false;
            this.butImage.Click += new System.EventHandler(this.butImage_Click);
            // 
            // sheet
            // 
            this.sheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sheet.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sheet.Location = new System.Drawing.Point(424, 8);
            this.sheet.Name = "sheet";
            this.sheet.Size = new System.Drawing.Size(280, 21);
            this.sheet.TabIndex = 4;
            this.sheet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sheet_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(384, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sheet";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tt
            // 
            this.tt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tt.DropDownWidth = 400;
            this.tt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tt.Items.AddRange(new object[] {
            "STT;Họ và Tên;Ngày sinh;Giới tính;Đơn vị;Số thẻ BHYT;Nơi Đăng ký BHYT;Ngày đăng k" +
                "ý BHYT;Ngày hết hạn BHYT;Nghề nghiệp;Địa chỉ thường trú;Môi trường làm việc"});
            this.tt.Location = new System.Drawing.Point(432, 409);
            this.tt.Name = "tt";
            this.tt.Size = new System.Drawing.Size(280, 21);
            this.tt.TabIndex = 5;
            this.tt.Visible = false;
            // 
            // butLuu
            // 
            this.butLuu.BackColor = System.Drawing.SystemColors.Control;
            this.butLuu.Cursor = System.Windows.Forms.Cursors.Default;
            this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLuu.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(285, 405);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(68, 25);
            this.butLuu.TabIndex = 291;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.UseVisualStyleBackColor = false;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.BackColor = System.Drawing.SystemColors.Control;
            this.butBoqua.Cursor = System.Windows.Forms.Cursors.Default;
            this.butBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butBoqua.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(356, 405);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(68, 25);
            this.butBoqua.TabIndex = 292;
            this.butBoqua.Text = "&Kết thúc";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.UseVisualStyleBackColor = false;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // lblTenbn
            // 
            this.lblTenbn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTenbn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTenbn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenbn.Location = new System.Drawing.Point(0, 519);
            this.lblTenbn.Name = "lblTenbn";
            this.lblTenbn.Size = new System.Drawing.Size(706, 24);
            this.lblTenbn.TabIndex = 293;
            this.lblTenbn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDonvi
            // 
            this.lblDonvi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDonvi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblDonvi.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonvi.Location = new System.Drawing.Point(0, 479);
            this.lblDonvi.Name = "lblDonvi";
            this.lblDonvi.Size = new System.Drawing.Size(706, 40);
            this.lblDonvi.TabIndex = 294;
            this.lblDonvi.Text = "Cập nhật DMKT";
            this.lblDonvi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTongso
            // 
            this.lblTongso.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTongso.Location = new System.Drawing.Point(0, 452);
            this.lblTongso.Name = "lblTongso";
            this.lblTongso.Size = new System.Drawing.Size(706, 27);
            this.lblTongso.TabIndex = 295;
            this.lblTongso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(524, 376);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Thư mục hình ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Visible = false;
            // 
            // txtPathImage
            // 
            this.txtPathImage.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtPathImage.Enabled = false;
            this.txtPathImage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPathImage.Location = new System.Drawing.Point(744, 224);
            this.txtPathImage.Name = "txtPathImage";
            this.txtPathImage.Size = new System.Drawing.Size(144, 21);
            this.txtPathImage.TabIndex = 1;
            this.txtPathImage.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(600, 370);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 25);
            this.button2.TabIndex = 292;
            this.button2.Text = "   &Import hình";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.CaptionForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGrid1.CaptionText = "Định dạng tập tin Excel mẫu";
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(8, 32);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 5;
            this.dataGrid1.Size = new System.Drawing.Size(688, 330);
            this.dataGrid1.TabIndex = 307;
            this.dataGrid1.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dataGrid1_Navigate);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 409);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 17);
            this.label3.TabIndex = 309;
            this.label3.Text = "Ngày hiệu lực :";
            // 
            // txtNgayhieuluc
            // 
            this.txtNgayhieuluc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNgayhieuluc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgayhieuluc.Location = new System.Drawing.Point(131, 405);
            this.txtNgayhieuluc.Mask = "00/00/0000";
            this.txtNgayhieuluc.Name = "txtNgayhieuluc";
            this.txtNgayhieuluc.PromptChar = ' ';
            this.txtNgayhieuluc.Size = new System.Drawing.Size(103, 26);
            this.txtNgayhieuluc.TabIndex = 308;
            this.txtNgayhieuluc.ValidatingType = typeof(System.DateTime);
            // 
            // chkUpdChinhanh
            // 
            this.chkUpdChinhanh.AutoSize = true;
            this.chkUpdChinhanh.Location = new System.Drawing.Point(532, 437);
            this.chkUpdChinhanh.Name = "chkUpdChinhanh";
            this.chkUpdChinhanh.Size = new System.Drawing.Size(172, 17);
            this.chkUpdChinhanh.TabIndex = 310;
            this.chkUpdChinhanh.Text = "Cập nhật xuống các chi nhánh";
            this.chkUpdChinhanh.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radmaluong);
            this.panel1.Controls.Add(this.chktenViettat);
            this.panel1.Controls.Add(this.chkmanhom_mack);
            this.panel1.Controls.Add(this.chkCapnhat_mahoabhyt);
            this.panel1.Controls.Add(this.radKTCao_cplon);
            this.panel1.Controls.Add(this.radHSNgtru);
            this.panel1.Controls.Add(this.radBBhoaichan);
            this.panel1.Location = new System.Drawing.Point(5, 432);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(699, 45);
            this.panel1.TabIndex = 314;
            // 
            // radBBhoaichan
            // 
            this.radBBhoaichan.AutoSize = true;
            this.radBBhoaichan.Location = new System.Drawing.Point(573, 4);
            this.radBBhoaichan.Name = "radBBhoaichan";
            this.radBBhoaichan.Size = new System.Drawing.Size(123, 17);
            this.radBBhoaichan.TabIndex = 0;
            this.radBBhoaichan.Text = "4. Biên bản hội chẩn";
            this.radBBhoaichan.UseVisualStyleBackColor = true;
            this.radBBhoaichan.Click += new System.EventHandler(this.chkCapnhat_mahoabhyt_Click);
            // 
            // radHSNgtru
            // 
            this.radHSNgtru.AutoSize = true;
            this.radHSNgtru.Location = new System.Drawing.Point(10, 26);
            this.radHSNgtru.Name = "radHSNgtru";
            this.radHSNgtru.Size = new System.Drawing.Size(98, 17);
            this.radHSNgtru.TabIndex = 1;
            this.radHSNgtru.Text = "5. HS Ngoại trú";
            this.radHSNgtru.UseVisualStyleBackColor = true;
            this.radHSNgtru.Click += new System.EventHandler(this.chkCapnhat_mahoabhyt_Click);
            // 
            // radKTCao_cplon
            // 
            this.radKTCao_cplon.AutoSize = true;
            this.radKTCao_cplon.Location = new System.Drawing.Point(235, 25);
            this.radKTCao_cplon.Name = "radKTCao_cplon";
            this.radKTCao_cplon.Size = new System.Drawing.Size(132, 17);
            this.radKTCao_cplon.TabIndex = 2;
            this.radKTCao_cplon.Text = "6. KT Cao - chi phí lơn";
            this.radKTCao_cplon.UseVisualStyleBackColor = true;
            this.radKTCao_cplon.Click += new System.EventHandler(this.chkCapnhat_mahoabhyt_Click);
            // 
            // chkCapnhat_mahoabhyt
            // 
            this.chkCapnhat_mahoabhyt.AutoSize = true;
            this.chkCapnhat_mahoabhyt.Location = new System.Drawing.Point(10, 4);
            this.chkCapnhat_mahoabhyt.Name = "chkCapnhat_mahoabhyt";
            this.chkCapnhat_mahoabhyt.Size = new System.Drawing.Size(213, 17);
            this.chkCapnhat_mahoabhyt.TabIndex = 3;
            this.chkCapnhat_mahoabhyt.Text = "1. Cập nhật Mã hóa dịch vụ theo BHYT";
            this.chkCapnhat_mahoabhyt.UseVisualStyleBackColor = true;
            this.chkCapnhat_mahoabhyt.Click += new System.EventHandler(this.chkCapnhat_mahoabhyt_Click);
            // 
            // chkmanhom_mack
            // 
            this.chkmanhom_mack.AutoSize = true;
            this.chkmanhom_mack.Location = new System.Drawing.Point(235, 3);
            this.chkmanhom_mack.Name = "chkmanhom_mack";
            this.chkmanhom_mack.Size = new System.Drawing.Size(215, 17);
            this.chkmanhom_mack.TabIndex = 4;
            this.chkmanhom_mack.Text = "2. Cập nhật mã nhóm - mã Chuyên khoa";
            this.chkmanhom_mack.UseVisualStyleBackColor = true;
            this.chkmanhom_mack.Click += new System.EventHandler(this.chkCapnhat_mahoabhyt_Click);
            // 
            // chktenViettat
            // 
            this.chktenViettat.AutoSize = true;
            this.chktenViettat.Location = new System.Drawing.Point(456, 4);
            this.chktenViettat.Name = "chktenViettat";
            this.chktenViettat.Size = new System.Drawing.Size(91, 17);
            this.chktenViettat.TabIndex = 5;
            this.chktenViettat.Text = "3. Tên viết tắt";
            this.chktenViettat.UseVisualStyleBackColor = true;
            this.chktenViettat.Click += new System.EventHandler(this.chkCapnhat_mahoabhyt_Click);
            // 
            // radmaluong
            // 
            this.radmaluong.AutoSize = true;
            this.radmaluong.Checked = true;
            this.radmaluong.Location = new System.Drawing.Point(456, 26);
            this.radmaluong.Name = "radmaluong";
            this.radmaluong.Size = new System.Drawing.Size(81, 17);
            this.radmaluong.TabIndex = 6;
            this.radmaluong.TabStop = true;
            this.radmaluong.Text = "7. Mã lương";
            this.radmaluong.UseVisualStyleBackColor = true;
            this.radmaluong.Click += new System.EventHandler(this.chkCapnhat_mahoabhyt_Click);
            // 
            // frmDsexcel
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(706, 543);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chkUpdChinhanh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNgayhieuluc);
            this.Controls.Add(this.txtPathImage);
            this.Controls.Add(this.path);
            this.Controls.Add(this.lblTongso);
            this.Controls.Add(this.lblDonvi);
            this.Controls.Add(this.lblTenbn);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.tt);
            this.Controls.Add(this.sheet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.butPath);
            this.Controls.Add(this.butImage);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGrid1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDsexcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDsexcel";
            this.Load += new System.EventHandler(this.frmDsexcel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        #endregion

		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox path;
		private System.Windows.Forms.Button butPath;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ComboBox sheet;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox tt;

        private void f_luu_giavp()
        {
            if (txtNgayhieuluc.Text.Trim() != "" && txtNgayhieuluc.Text.Trim() == "/  /")
            {
                MessageBox.Show(lan.Change_language_MessageText("Đề nghị nhập ngày hiệu lực."));
                return;
            }
           
            s_ngayhieuluc = txtNgayhieuluc.Text;
            imp_dmgiavp_15042012(path.Text, txtNgayhieuluc.Text);
        }
        private void f_luu_maluong()
        {
            string sql = "";
            DataTable dtdm = m_v.get_data("select ma, id, ten from medibv.v_giavp ").Tables[0];
            DataTable dt = get_excel(path.Text).Tables[0];

            DataRow r1;
            decimal l_id = 0;

            string v_manhomluong = "", v_maluong = "", d_mavp = "";
            //
            string asql = "select manhomluong from medibv.v_giavp where 1=2";
            DataSet lds1 = m_v.get_data(asql);
            if (lds1 == null || lds1.Tables.Count <= 0)
            {
                asql = "alter table medibv.v_giavp add manhomluong varchar(20)";
                m_v.execute_data(asql);
                asql = "alter table medibv.v_giavp add maluong varchar(20)";
                m_v.execute_data(asql);

            }
            //
            int i_stt = 0, i_count = dt.Rows.Count;
            //
            foreach (DataRow r in dt.Rows)
            {
                if (r[2].ToString().Trim() != "")
                {
                    i_stt += 1;
                    lblTenbn.Text = i_stt.ToString() + "/" + i_count.ToString() + " - " + r[2].ToString();
                    lblTenbn.Refresh();
                    //
                    d_mavp = r[2].ToString();
                    // i_stt = int.Parse(r[0].ToString());
                    r1 = m_v.getrowbyid(dtdm, "trim(ma)='" + d_mavp + "'");
                    if (r1 != null)
                    {
                        l_id = decimal.Parse(r1["id"].ToString());
                        d_mavp = r[2].ToString();
                        //v_tuyen = (r[6].ToString() == "") ? 7 : int.Parse(r[6].ToString());
                        //7
                        v_manhomluong = r[3].ToString();
                        v_maluong = r[4].ToString();

                        sql = " update medibv.v_giavp set  maluong='" + v_maluong + "'";
                        if (v_manhomluong.Trim() != "") sql += ", manhomluong ='" + v_manhomluong + "'";
                        sql += " where id=" + l_id;
                        m_v.execute_data(sql);
                        //
                        //
                    }
                }
            }

            if (chkUpdChinhanh.Checked)
            {
                if (chkUpdChinhanh.Checked)
                {
                    string str_databaselink = "";
                    foreach (DataRow drcn in dscn.Tables[0].Select("matmang=0 and id<>" + i_IDCN))
                    {
                        str_databaselink = drcn["database"].ToString();
                        if (str_databaselink.Trim().Trim('@') == "") continue;
                        else str_databaselink = "@" + str_databaselink.Trim().Trim('@');
                        //
                        foreach (DataRow r in dt.Rows)
                        {
                            if (r[2].ToString().Trim() != "")
                            {
                                d_mavp = r[2].ToString();
                                // i_stt = int.Parse(r[0].ToString());
                                r1 = m_v.getrowbyid(dtdm, "trim(ma)='" + d_mavp + "'");
                                if (r1 != null)
                                {
                                    l_id = decimal.Parse(r1["id"].ToString());
                                    d_mavp = r[2].ToString();
                                    //v_tuyen = (r[6].ToString() == "") ? 7 : int.Parse(r[6].ToString());
                                    //7
                                    v_manhomluong = r[3].ToString();
                                    v_maluong = r[4].ToString();

                                    sql = " update medibv.v_giavp" + str_databaselink + " set manhomluong ='" + v_manhomluong + "', maluong='" + v_maluong + "'";
                                    sql += " where id=" + l_id;
                                    m_v.execute_data(sql);
                                    //
                                    //
                                }
                            }
                        }
                    }
                }
            }
        }

        private void f_luu_mahoa_bhyt()
        {
            string sql = "";
            DataTable dtdm = m_v.get_data("select ma, id, ten from medibv.v_giavp ").Tables[0];
            DataTable dt = get_excel(path.Text).Tables[0];

            DataRow r1;
            decimal l_id = 0;

            string v_mahoa_bhyt1 = "", v_mahoa_bhyt2 = "", d_mavp = "";
            //
            string asql = "select mahoa_bhyt1, mahoa_bhyt2 from medibv.v_giavp where 1=2";
            DataSet lds1 = m_v.get_data(asql);
            if (lds1 == null || lds1.Tables.Count <= 0)
            {
                asql = "alter table medibv.v_giavp add mahoa_bhyt1 varchar(20)";
                m_v.execute_data(asql);
                asql = "alter table medibv.v_giavp add mahoa_bhyt2 varchar(20)";
                m_v.execute_data(asql);

            }
            //
            int i_stt = 0, i_count = dt.Rows.Count;
            //
            foreach (DataRow r in dt.Rows)
            {
                if (r[2].ToString().Trim() != "")
                {
                    i_stt += 1;
                    lblTenbn.Text = i_stt.ToString() + "/" + i_count.ToString() + " - " + r[2].ToString();
                    lblTenbn.Refresh();
                    //
                    d_mavp = r[2].ToString();
                    // i_stt = int.Parse(r[0].ToString());
                    r1 = m_v.getrowbyid(dtdm, "trim(ma)='" + d_mavp + "'");
                    if (r1 != null)
                    {
                        l_id = decimal.Parse(r1["id"].ToString());
                        d_mavp = r[2].ToString();
                        //v_tuyen = (r[6].ToString() == "") ? 7 : int.Parse(r[6].ToString());
                        //7
                        v_mahoa_bhyt1 = r[4].ToString();
                        v_mahoa_bhyt2 = r[5].ToString();

                        sql = " update medibv.v_giavp set mahoa_bhyt1 ='" + v_mahoa_bhyt1 + "', mahoa_bhyt2='" + v_mahoa_bhyt2 + "'";
                        sql += " where id=" + l_id;
                        m_v.execute_data(sql);
                        //
                        //
                    }
                }
            }
            if (chkUpdChinhanh.Checked)
            {
                if (chkUpdChinhanh.Checked)
                {
                    string str_databaselink = "";
                    foreach (DataRow drcn in dscn.Tables[0].Select("matmang=0 and id<>" + i_IDCN))
                    {
                        str_databaselink = drcn["database"].ToString();
                        if (str_databaselink.Trim().Trim('@') == "") continue;
                        else str_databaselink = "@" + str_databaselink.Trim().Trim('@');
                        foreach (DataRow r in dt.Rows)
                        {
                            if (r[2].ToString().Trim() != "")
                            {
                                d_mavp = r[2].ToString();
                                // i_stt = int.Parse(r[0].ToString());
                                r1 = m_v.getrowbyid(dtdm, "trim(ma)='" + d_mavp + "'");
                                if (r1 != null)
                                {
                                    l_id = decimal.Parse(r1["id"].ToString());
                                    d_mavp = r[2].ToString();
                                    //v_tuyen = (r[6].ToString() == "") ? 7 : int.Parse(r[6].ToString());
                                    //7
                                    v_mahoa_bhyt1 = r[4].ToString();
                                    v_mahoa_bhyt2 = r[5].ToString();

                                    sql = " update medibv.v_giavp" + str_databaselink + " set mahoa_bhyt1 ='" + v_mahoa_bhyt1 + "', mahoa_bhyt2='" + v_mahoa_bhyt2 + "'";
                                    sql += " where id=" + l_id;
                                    m_v.execute_data(sql);
                                    //
                                    //
                                }
                            }
                        }
                    }
                }
            }
        }

        private void f_luu_manham_machuyenkhoa_dmkt()
        {
            string sql = "";
            DataTable dtdm = m_v.get_data("select ma, id, ten from medibv.v_giavp ").Tables[0];
            DataTable dt = get_excel(path.Text).Tables[0];

            DataRow r1;
            decimal l_id = 0;

            string v_manhom = "", v_machuyenkhoa = "", v_maphongcmy="", d_mavp = "";
            //
            string asql = "select manhom, machuyenkhoa,maphongcmy from medibv.v_giavp where 1=2";
            DataSet lds1 = m_v.get_data(asql);
            if (lds1 == null || lds1.Tables.Count <= 0)
            {
                asql = "alter table medibv.v_giavp add manhom varchar(20)";
                m_v.execute_data(asql);
                asql = "alter table medibv.v_giavp add machuyenkhoa varchar(20)";
                m_v.execute_data(asql);
                asql = "alter table medibv.v_giavp add maphongcmy varchar(20)";
                m_v.execute_data(asql);

            }
            //
            int i_stt = 0, i_count = dt.Rows.Count;
            //
            foreach (DataRow r in dt.Rows)
            {
                if (r[2].ToString().Trim() != "")
                {
                    i_stt += 1;
                    lblTenbn.Text = i_stt.ToString() + "/" + i_count.ToString() + " - " + r[2].ToString();
                    lblTenbn.Refresh();
                    //
                    d_mavp = r[2].ToString();
                    r1 = m_v.getrowbyid(dtdm, "trim(ma)='" + d_mavp + "'");
                    if (r1 != null)
                    {
                        l_id = decimal.Parse(r1["id"].ToString());
                        d_mavp = r[2].ToString();
                        v_manhom  = r[3].ToString();
                        v_machuyenkhoa = r[4].ToString();
                        v_maphongcmy = r[5].ToString();

                        sql = " update medibv.v_giavp set manhom ='" + v_manhom + "', machuyenkhoa='" + v_machuyenkhoa + "', maphongcmy='" + v_maphongcmy + "'";
                        sql += " where id=" + l_id;
                        m_v.execute_data(sql);
                        //
                        //
                    }
                }
            }
            if (chkUpdChinhanh.Checked)
            {
                if (chkUpdChinhanh.Checked)
                {
                    string str_databaselink = "";
                    foreach (DataRow drcn in dscn.Tables[0].Select("matmang=0 and id<>" + i_IDCN))
                    {
                        str_databaselink = drcn["database"].ToString();
                        if (str_databaselink.Trim().Trim('@') == "") continue;
                        else str_databaselink = "@" + str_databaselink.Trim().Trim('@');
                        foreach (DataRow r in dt.Rows)
                        {
                            if (r[2].ToString().Trim() != "")
                            {
                                d_mavp = r[2].ToString();
                                // i_stt = int.Parse(r[0].ToString());
                                r1 = m_v.getrowbyid(dtdm, "trim(ma)='" + d_mavp + "'");
                                if (r1 != null)
                                {
                                    l_id = decimal.Parse(r1["id"].ToString());
                                    d_mavp = r[2].ToString();
                                    v_manhom = r[3].ToString();
                                    v_machuyenkhoa = r[4].ToString();
                                    v_maphongcmy = r[5].ToString();

                                    sql = " update medibv.v_giavp" + str_databaselink + " set manhom ='" + v_manhom + "', machuyenkhoa='" + v_machuyenkhoa + "', maphongcmy='" + v_maphongcmy + "'";
                                    sql += " where id=" + l_id;                                    
                                    m_v.execute_data(sql);
                                    //
                                    //
                                }
                            }
                        }
                    }
                }
            }
        }

        private void f_luu_TenViettat_dmkt()
        {
            string sql = "";
            DataTable dtdm = m_v.get_data("select ma, id, ten from medibv.v_giavp ").Tables[0];
            DataTable dt = get_excel(path.Text).Tables[0];

            DataRow r1;
            decimal l_id = 0;

            string v_tenviettat = "", d_mavp = "";
            //
            string asql = "select tenviettat from medibv.v_giavp where 1=2";
            DataSet lds1 = m_v.get_data(asql);
            if (lds1 == null || lds1.Tables.Count <= 0)
            {
                asql = "alter table medibv.v_giavp add tenviettat varchar(255)";
                m_v.execute_data(asql);               

            }
            //
            int i_stt = 0, i_count = dt.Rows.Count;
            //
            foreach (DataRow r in dt.Rows)
            {
                if (r[2].ToString().Trim() != "")
                {
                    i_stt += 1;
                    lblTenbn.Text = i_stt.ToString() + "/" + i_count.ToString() + " - " + r[2].ToString();
                    lblTenbn.Refresh();
                    d_mavp = r[2].ToString();
                    r1 = m_v.getrowbyid(dtdm, "trim(ma)='" + d_mavp + "'");
                    if (r1 != null)
                    {
                        l_id = decimal.Parse(r1["id"].ToString());
                        d_mavp = r[2].ToString();
                        v_tenviettat = r[3].ToString();                       

                        sql = " update medibv.v_giavp set tenviettat ='" + v_tenviettat + "'";
                        sql += " where id=" + l_id;
                        m_v.execute_data(sql);
                        //
                        //
                    }
                }
            }
            if (chkUpdChinhanh.Checked)
            {
                if (chkUpdChinhanh.Checked)
                {
                    string str_databaselink = "";
                    foreach (DataRow drcn in dscn.Tables[0].Select("matmang=0 and id<>" + i_IDCN))
                    {
                        str_databaselink = drcn["database"].ToString();
                        if (str_databaselink.Trim().Trim('@') == "") continue;
                        else str_databaselink = "@" + str_databaselink.Trim().Trim('@');
                        foreach (DataRow r in dt.Rows)
                        {
                            if (r[2].ToString().Trim() != "")
                            {
                                d_mavp = r[2].ToString();
                                // i_stt = int.Parse(r[0].ToString());
                                r1 = m_v.getrowbyid(dtdm, "trim(ma)='" + d_mavp + "'");
                                if (r1 != null)
                                {
                                    l_id = decimal.Parse(r1["id"].ToString());
                                    d_mavp = r[2].ToString();
                                    v_tenviettat = r[3].ToString();

                                    sql = " update medibv.v_giavp" + str_databaselink + " set tenviettat ='" + v_tenviettat + "'";
                                    sql += " where id=" + l_id;
                                    m_v.execute_data(sql);
                                    //
                                    //
                                }
                            }
                        }
                    }
                }
            }
        }

        private void f_luu_HSNgoaitru()
        {
            string sql = "";
            DataTable dtdm = m_v.get_data("select ma, id, ten from medibv.v_giavp ").Tables[0];
            DataTable dt = get_excel(path.Text).Tables[0];

            DataRow r1;
            decimal l_id = 0;
            
            string v_value = "", d_mavp = "";
            //
            //string asql = "select tenviettat from medibv.v_giavp where 1=2";
            //DataSet lds1 = m_v.get_data(asql);
           
            //
            int i_stt = 0, i_count = dt.Rows.Count;
            //
            foreach (DataRow r in dt.Rows)
            {
                if (r[2].ToString().Trim() != "")
                {
                    i_stt += 1;
                    lblTenbn.Text = i_stt.ToString() + "/" + i_count.ToString() + " - " + r[1].ToString();
                    lblTenbn.Refresh();
                    d_mavp = r[2].ToString();
                    r1 = m_v.getrowbyid(dtdm, "trim(ma)='" + d_mavp + "'");
                    if (r1 != null)
                    {
                        l_id = decimal.Parse(r1["id"].ToString());
                        d_mavp = r[2].ToString();
                        v_value = (r[3].ToString() == "x") ? "1" : "0";
                        //if (r[3].ToString() !="") { string ddd = ""; }
                        sql = " update medibv.v_giavp set xamlan =" + v_value + "";
                        sql += " where id=" + l_id;
                        m_v.execute_data(sql);
                        //
                        //
                    }
                }
            }
            if (chkUpdChinhanh.Checked)
            {
                if (chkUpdChinhanh.Checked)
                {
                    string str_databaselink = "";
                    foreach (DataRow drcn in dscn.Tables[0].Select("matmang=0 and id<>" + i_IDCN))
                    {
                        str_databaselink = drcn["database"].ToString();
                        if (str_databaselink.Trim().Trim('@') == "") continue;
                        else str_databaselink = "@" + str_databaselink.Trim().Trim('@');
                        foreach (DataRow r in dt.Rows)
                        {
                            if (r[2].ToString().Trim() != "")
                            {
                                d_mavp = r[2].ToString();
                                // i_stt = int.Parse(r[0].ToString());
                                r1 = m_v.getrowbyid(dtdm, "trim(ma)='" + d_mavp + "'");
                                if (r1 != null)
                                {
                                    l_id = decimal.Parse(r1["id"].ToString());
                                    d_mavp = r[2].ToString();
                                    v_value = (r[3].ToString() == "x") ? "1" : "0";
                                    sql = " update medibv.v_giavp" + str_databaselink + " set xamlan =" + v_value + "";
                                    sql += " where id=" + l_id;
                                    m_v.execute_data(sql);
                                    //
                                    //
                                }
                            }
                        }
                    }
                }
            }
        }

        private void f_luu_BBHoiChan()
        {
            string sql = "";
            DataTable dtdm = m_v.get_data("select ma, id, ten from medibv.v_giavp ").Tables[0];
            DataTable dt = get_excel(path.Text).Tables[0];

            DataRow r1;
            decimal l_id = 0;

            string v_value = "", d_mavp = "";
            //
            //string asql = "select tenviettat from medibv.v_giavp where 1=2";
            //DataSet lds1 = m_v.get_data(asql);

            //
            int i_stt = 0, i_count = dt.Rows.Count;
            //
            foreach (DataRow r in dt.Rows)
            {
                if (r[2].ToString().Trim() != "")
                {
                    i_stt += 1;
                    lblTenbn.Text = i_stt.ToString() + "/" + i_count.ToString() + " - " + r[2].ToString();
                    lblTenbn.Refresh();
                    d_mavp = r[2].ToString();
                    r1 = m_v.getrowbyid(dtdm, "trim(ma)='" + d_mavp + "'");
                    if (r1 != null)
                    {
                        l_id = decimal.Parse(r1["id"].ToString());
                        d_mavp = r[2].ToString();
                        v_value = (r[3].ToString() == "x") ? "1" : "0";

                        sql = " update medibv.v_giavp set hoichan =" + v_value + "";
                        sql += " where id=" + l_id;
                        m_v.execute_data(sql);
                        //
                        //
                    }
                }
            }
            if (chkUpdChinhanh.Checked)
            {
                if (chkUpdChinhanh.Checked)
                {
                    string str_databaselink = "";
                    foreach (DataRow drcn in dscn.Tables[0].Select("matmang=0 and id<>" + i_IDCN))
                    {
                        str_databaselink = drcn["database"].ToString();
                        if (str_databaselink.Trim().Trim('@') == "") continue;
                        else str_databaselink = "@" + str_databaselink.Trim().Trim('@');
                        foreach (DataRow r in dt.Rows)
                        {
                            if (r[2].ToString().Trim() != "")
                            {
                                d_mavp = r[2].ToString();
                                // i_stt = int.Parse(r[0].ToString());
                                r1 = m_v.getrowbyid(dtdm, "trim(ma)='" + d_mavp + "'");
                                if (r1 != null)
                                {
                                    l_id = decimal.Parse(r1["id"].ToString());
                                    d_mavp = r[2].ToString();
                                    v_value = (r[3].ToString() == "x") ? "1" : "0";

                                    sql = " update medibv.v_giavp" + str_databaselink + " set hoichan =" + v_value + "";
                                    sql += " where id=" + l_id;
                                    m_v.execute_data(sql);
                                    //
                                    //
                                }
                            }
                        }
                    }
                }
            }
        }

        private void f_luu_KTCao_CPLon()
        {
            string sql = "";
            DataTable dtdm = m_v.get_data("select ma, id, ten from medibv.v_giavp ").Tables[0];
            DataTable dt = get_excel(path.Text).Tables[0];

            DataRow r1;
            decimal l_id = 0;

            string v_value = "", d_mavp = "";
            //
            //string asql = "select tenviettat from medibv.v_giavp where 1=2";
            //DataSet lds1 = m_v.get_data(asql);

            //
            int i_stt = 0, i_count = dt.Rows.Count;
            //
            foreach (DataRow r in dt.Rows)
            {
                if (r[2].ToString().Trim() != "")
                {
                    i_stt += 1;
                    lblTenbn.Text = i_stt.ToString() + "/" + i_count.ToString() + " - " + r[2].ToString();
                    lblTenbn.Refresh();
                    d_mavp = r[2].ToString();
                    r1 = m_v.getrowbyid(dtdm, "trim(ma)='" + d_mavp + "'");
                    if (r1 != null)
                    {
                        l_id = decimal.Parse(r1["id"].ToString());
                        d_mavp = r[2].ToString();
                        v_value = (r[3].ToString() == "x") ? "0" : "-1";

                        sql = " update medibv.v_giavp set kythuat =" + v_value + "";
                        sql += " where id=" + l_id;
                        m_v.execute_data(sql);
                        //
                        //
                    }
                }
            }
            if (chkUpdChinhanh.Checked)
            {
                if (chkUpdChinhanh.Checked)
                {
                    string str_databaselink = "";
                    foreach (DataRow drcn in dscn.Tables[0].Select("matmang=0 and id<>" + i_IDCN))
                    {
                        str_databaselink = drcn["database"].ToString();
                        if (str_databaselink.Trim().Trim('@') == "") continue;
                        else str_databaselink = "@" + str_databaselink.Trim().Trim('@');
                        foreach (DataRow r in dt.Rows)
                        {
                            if (r[2].ToString().Trim() != "")
                            {
                                d_mavp = r[2].ToString();
                                // i_stt = int.Parse(r[0].ToString());
                                r1 = m_v.getrowbyid(dtdm, "trim(ma)='" + d_mavp + "'");
                                if (r1 != null)
                                {
                                    l_id = decimal.Parse(r1["id"].ToString());
                                    d_mavp = r[2].ToString();
                                    v_value = (r[3].ToString() == "x") ? "0" : "-1";

                                    sql = " update medibv.v_giavp" + str_databaselink + " set kythua =" + v_value + "";
                                    sql += " where id=" + l_id;
                                    m_v.execute_data(sql);
                                    //
                                    //
                                }
                            }
                        }
                    }
                }
            }
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show(lan.Change_language_MessageText("Bạn đã kiểm tra xem đã chọn đúng sheet của file excel chưa ?"), "medisoft THIS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlg == DialogResult.No)
            {
                return;
            }
            dlg = MessageBox.Show(lan.Change_language_MessageText("Bạn đã kiểm tra xem các cột trong file Excel có đúng với yêu cầu liệt trên danh sách chưa ?"), "medisoft THIS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlg == DialogResult.No)
            {
                return;
            }
            Cursor = Cursors.WaitCursor;
            if (iLoaiImport == (int)LibVP.AccessData.IDLoaiImport.Import_DMKT_gia )
            {
                f_luu_giavp();
            }
            else if (iLoaiImport == (int)LibVP.AccessData.IDLoaiImport.Import_DMKT_MaLuong )
            {
                if (chkCapnhat_mahoabhyt.Checked)
                {
                    f_luu_mahoa_bhyt();
                }
                else if (chkmanhom_mack.Checked)
                {
                    f_luu_manham_machuyenkhoa_dmkt();
                }
                else if (chktenViettat.Checked)
                {
                    f_luu_TenViettat_dmkt();
                }
                else if (radKTCao_cplon.Checked)
                {
                    f_luu_KTCao_CPLon();
                }
                else if (radHSNgtru.Checked)
                {
                    f_luu_HSNgoaitru();
                }
                else if (radBBhoaichan.Checked)
                {
                    f_luu_BBHoiChan();
                }
                else
                {
                    f_luu_maluong();
                }
            }
            Cursor = Cursors.Default;
        }
		
        private void butBoqua_Click(object sender, EventArgs e)
        {
            GC.Collect(); this.Close();
        }
        private void sheet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }
        private void butPath_Click(object sender, EventArgs e)
        {
            string sDir = System.Environment.CurrentDirectory.ToString();
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "*.XLS|*.*";
            of.ShowDialog();
            path.Text = of.FileName.ToString();
            System.Environment.CurrentDirectory = sDir;
            if (path.Text != "") sheet.DataSource = LoadSchemaFromFile(path.Text); 
        }
        private OleDbConnection ReturnConnection(string fileName)
        {
            return new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" +
                "Data Source=" + fileName + ";" +
                " Jet OLEDB:Engine Type=5;Extended Properties=\"Excel 8.0;\"");
        }
        private string[] LoadSchemaFromFile(string fileName)
        {
            string[] SheetNames = null;
            OleDbConnection conn = this.ReturnConnection(fileName);
            try
            {
                conn.Open();

                DataTable SchemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null });
                if (SchemaTable.Rows.Count > 0)
                {
                    SheetNames = new string[SchemaTable.Rows.Count];
                    int i = 0;
                    foreach (DataRow TmpRow in SchemaTable.Rows)
                    {
                        SheetNames[i] = TmpRow["TABLE_NAME"].ToString();
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return SheetNames;
        }
        private DataSet get_excel(string fileName)
        {
            OleDbConnection con = this.ReturnConnection(fileName);
            con.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet.Text + "]", con);
            OleDbDataAdapter dest = new OleDbDataAdapter();
            dest.SelectCommand = cmd;
            DataSet ds = new DataSet();
            try
            {
                dest.Fill(ds);
            }catch(Exception ex)
            {
                ex.ToString();
            }
            cmd.Dispose();
            con.Close();
            return ds;
        }
        private void frmDsexcel_Load(object sender, EventArgs e)
        {
            //
            //chkCapnhat_mahoabhyt.Visible = iLoaiImport == (int)LibVP.AccessData.IDLoaiImport.Import_DMKT_MaLuong;
            panel1.Visible = iLoaiImport == (int)LibVP.AccessData.IDLoaiImport.Import_DMKT_MaLuong;
            i_IDCN = m_v.i_Chinhanh_hientai;
            //
            dscn = m_v.get_data("select * from medibv.dmchinhanh where id >0 and matmang=0 ");
            //
            Load_Form();
            
        }

        private void Load_Form()
        {
            tt.SelectedIndex = 0;
            string[] arr_columngia;
            string[] arr_values;
            string[] arr_valuesct;
            //s_cols = "Stt,Ten,machyenkhoa,manhom, maphongcmy, makt, thuchien,tuyen,gia_tg, gia_ng, gia_le, bh_tg, bh_ng, bh_le, bh_duyet, pt_tg, pt_ng, pt_le, cophuthu, syt_1, syt_2, syt_3, syt_4, syt_5, syt_6, cnad_1, cnad_2, cnad_3, cnad_4, cnad_5, cnad_6, cv_1, cv_2, cv_3, cv_4, cv_5, cv_6, bbhoichan, giaycamdoan, benhanngtru ";
            //s_values = "A:STT,B:Tên KT, C:Mã chuyên khoa, D:Mã nhóm, E:Mã Phòng CMY, F:Mã KT, G:Thựcc hiện/gửi,H:Tuyến, I:Giá TG, J:Giá NG, K:Giá lễ, L:Giá BH TG, M:Giá BH NG, N:Giá BH Lễ, O:Giá BH Duyệt, P:Phụ thu TG, Q:Phụ thu NG, R:Phụ thu lễ, S:Có phụ thu: 0-1, T:SYT duyệt CN1, U:SYT duyệt CN2, V:SYT duyệt CN3, W:SYT duyệt CN4, X:SYT duyệt CN5, Y:SYT duyệt CN6, Z:CN Áp dụng 1, AA:CN Áp dụng 2, AB:CN Áp dụng 3, AC:CN Áp dụng 4, AD:CN Áp dụng 5, AE:CN Áp dụng 6, AF:Tiếp nhận CV 1, AG:Tiếp nhận CV 2, AH:Tiếp nhận CV 3, AI:Tiến nhận CV 4, AJ:Tiếp nhận CV 5, AK:Tiếp nhận CV 6, AL:BB Hội chẩn, AM:Guấy cam đoan, AN:HSBA Ngoại trú ";
            s_cols = "cot, diengiai";// "Stt,Ten,machyenkhoa,manhom, maphongcmy, makt, thuchien,tuyen, syt_1, syt_2, syt_3, syt_4, syt_5, syt_6, cnad_1, cnad_2, cnad_3, cnad_4, cnad_5, cnad_6, cv_1, cv_2, cv_3, cv_4, cv_5, cv_6, bbhoichan, giaycamdoan, benhanngtru, kythuat, gia_tg, gia_le, pt_tg, pt_le, bh_duyet ";
            s_values = "A:STT, B:Tên KT, C:Mã chuyên khoa, D:Mã nhóm, E:Mã Phòng CMY, F:Mã KT, G:Thực hiện/gửi, H:Tuyến, I:CN Áp dụng 1, J:CN Áp dụng 2, K:CN Áp dụng 3, L:CN Áp dụng 4, M:CN Áp dụng 5, N:CN Áp dụng 6, O:Tiếp nhận CV 1, P:Tiếp nhận CV 2, Q:Tiếp nhận CV 3, R:Tiến nhận CV 4, S:Tiếp nhận CV 5, T:Tiếp nhận CV 6, U:BB Hội chẩn, V:Giấy cam đoan, W:HSBA Ngoại trú, X: KTCao-CPlớn, Y:Giá TG, Z:Giá lễ, AA:Phụ thu TG, AB:Phụ thu lễ, AC:Giá BHYT, AD: Mã lương ";
            //
            if (iLoaiImport == (int)LibVP.AccessData.IDLoaiImport.Import_DMKT_MaLuong)
            {
                if (chkCapnhat_mahoabhyt.Checked)
                {
                    s_values = "A:STT, B: TÊN KT, C: MÃ KT, D: Tên Kỹ thuật, E: Mã hóa BHYT 1, F: Mã hóa BHYT 2";
                }
                else if (chkmanhom_mack.Checked)
                {
                    s_values = "A:STT, B: TÊN KT, C: MÃ KT, D: Mã nhóm, E: Mã Chuyên khoa, F: Phòng CMY";
                }
                else if (chktenViettat.Checked)
                {
                    s_values = "A:STT, B: TÊN KT, C: MÃ KT, D: Tên Viết tắt";
                }
                else if (radBBhoaichan.Checked)
                {
                    s_values = "A:STT, B: TÊN KT, C: MÃ KT, D: BB Hội chẩn(x-có)";
                }
                else if (radHSNgtru.Checked)
                {
                    s_values = "A:STT, B: TÊN KT, C: MÃ KT, D: HS Ngoại trú(x-có)";
                }
                else if (radKTCao_cplon.Checked)
                {
                    s_values = "A:STT, B: TÊN KT, C: MÃ KT, D: KT Cao - CP lớn(x-có)";
                }
                else if(radmaluong.Checked)
                {                    
                    s_values = "A:STT, B: TÊN KT, C: MÃ KT, D: Mã nhóm lương, E: Mã lương";
                }
                else s_values = "A:STT, B: TÊN KT, C: MÃ KT, D: Mã nhóm lương, E: Mã lương";
            }
            //
            arr_columngia = s_cols.Split(',');
            sql = "select ";
            for (int i = 0; i < arr_columngia.Length; i++)
            {
                sql += " '' as " + arr_columngia[i] + ",";
            }
            sql = sql.Trim().Trim(',');
            ds = m_v.get_data(sql);
            ds.Clear();
            arr_values = s_values.Split(',');
            //
            if (s_ngayhieuluc != "") txtNgayhieuluc.Text = s_ngayhieuluc;
            //
            DataRow r;
            for (int j = 0; j < arr_values.Length; j++)
            {
                arr_valuesct = arr_values[j].Split(':');
                r = ds.Tables[0].NewRow();
                for (int k = 0; k < arr_valuesct.Length; k++)
                {
                    r[k] = arr_valuesct[k].Trim();
                }
                ds.Tables[0].Rows.Add(r);
            }
            
            dataGrid1.DataSource = ds.Tables[0];
            AddGridTableStyle1();
        }
        private void Load_Form_cu()
        {
            tt.SelectedIndex = 0;
            string[] arr_columngia;
            string[] arr_values;
            //s_cols = "Stt,Ten,machyenkhoa,manhom, maphongcmy, makt, thuchien,tuyen,gia_tg, gia_ng, gia_le, bh_tg, bh_ng, bh_le, bh_duyet, pt_tg, pt_ng, pt_le, cophuthu, syt_1, syt_2, syt_3, syt_4, syt_5, syt_6, cnad_1, cnad_2, cnad_3, cnad_4, cnad_5, cnad_6, cv_1, cv_2, cv_3, cv_4, cv_5, cv_6, bbhoichan, giaycamdoan, benhanngtru ";
            //s_values = "A:STT,B:Tên KT, C:Mã chuyên khoa, D:Mã nhóm, E:Mã Phòng CMY, F:Mã KT, G:Thựcc hiện/gửi,H:Tuyến, I:Giá TG, J:Giá NG, K:Giá lễ, L:Giá BH TG, M:Giá BH NG, N:Giá BH Lễ, O:Giá BH Duyệt, P:Phụ thu TG, Q:Phụ thu NG, R:Phụ thu lễ, S:Có phụ thu: 0-1, T:SYT duyệt CN1, U:SYT duyệt CN2, V:SYT duyệt CN3, W:SYT duyệt CN4, X:SYT duyệt CN5, Y:SYT duyệt CN6, Z:CN Áp dụng 1, AA:CN Áp dụng 2, AB:CN Áp dụng 3, AC:CN Áp dụng 4, AD:CN Áp dụng 5, AE:CN Áp dụng 6, AF:Tiếp nhận CV 1, AG:Tiếp nhận CV 2, AH:Tiếp nhận CV 3, AI:Tiến nhận CV 4, AJ:Tiếp nhận CV 5, AK:Tiếp nhận CV 6, AL:BB Hội chẩn, AM:Guấy cam đoan, AN:HSBA Ngoại trú ";
            s_cols = "Stt,Ten,machyenkhoa,manhom, maphongcmy, makt, thuchien,tuyen, syt_1, syt_2, syt_3, syt_4, syt_5, syt_6, cnad_1, cnad_2, cnad_3, cnad_4, cnad_5, cnad_6, cv_1, cv_2, cv_3, cv_4, cv_5, cv_6, bbhoichan, giaycamdoan, benhanngtru, kythuat, gia_tg, gia_le, pt_tg, pt_le, bh_duyet ";
            s_values = "A:STT, B:Tên KT, C:Mã chuyên khoa, D:Mã nhóm, E:Mã Phòng CMY, F:Mã KT, G:Thực hiện/gửi, H:Tuyến, I:CN Áp dụng 1, J:CN Áp dụng 2, K:CN Áp dụng 3, L:CN Áp dụng 4, M:CN Áp dụng 5, N:CN Áp dụng 6, O:Tiếp nhận CV 1, P:Tiếp nhận CV 2, Q:Tiếp nhận CV 3, R:Tiến nhận CV 4, S:Tiếp nhận CV 5, T:Tiếp nhận CV 6, U:BB Hội chẩn, V:Giấy cam đoan, W:HSBA Ngoại trú, X: KTCao-CPlớn, Y:Giá TG, Z:Giá lễ, AA:Phụ thu TG, AB:Phụ thu lễ, AC:Giá BHYT ";
            arr_columngia = s_cols.Split(',');
            sql = "select ";
            for (int i = 0; i < arr_columngia.Length; i++)
            {
                sql += " '' as " + arr_columngia[i] + ",";
            }
            sql = sql.Trim().Trim(',');
            ds = m_v.get_data(sql);
            ds.Clear();
            arr_values = s_values.Split(',');
            DataRow r = ds.Tables[0].NewRow();
            for (int j = 0; j < arr_values.Length; j++)
            {
                r[j] = arr_values[j];
            }

            ds.Tables[0].Rows.Add(r);
            dataGrid1.DataSource = ds.Tables[0];
            AddGridTableStyle1();
        }
        private void AddGridTableStyle1()
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = ds.Tables[0].TableName;
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
            dataGrid1.TableStyles.Clear();

            DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "cot";
            TextCol.HeaderText = "Cột";
            TextCol.Width = 70;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "diengiai";
            TextCol.HeaderText = "Tên cột";
            TextCol.Width = 300;
            TextCol.Alignment = HorizontalAlignment.Left;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
        }
        private void AddGridTableStyle12()
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = ds.Tables[0].TableName;
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

            
            string[] arr_head;
            string[] arr_clos;
            arr_head = s_values.Split(',');
            arr_clos = s_cols.Split(',');
            DataGridTextBoxColumn TextCol;
            for (int i = 0; i < arr_head.Length; i++)
            {
                TextCol = new DataGridTextBoxColumn();
                TextCol.MappingName = arr_clos[i].Trim();
                TextCol.HeaderText = arr_head[i];
                TextCol.Width = 100;
                ts.GridColumnStyles.Add(TextCol);               
            }
             dataGrid1.TableStyles.Add(ts);
        }
		private void AddGridTableStyle1111()
		{
			DataGridTableStyle ts = new DataGridTableStyle();
			ts.MappingName = ds.Tables[0].TableName;
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
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "manv";
			TextCol.HeaderText = "Mã NV";
			TextCol.Width = 40;
			TextCol.Alignment = HorizontalAlignment.Right;
			TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "madv";
			TextCol.HeaderText = "Mã Đvị";
			TextCol.Width = 50;
			TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "ho";
			TextCol.HeaderText = "Họ";
			TextCol.Width = 100;
			TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên";
			TextCol.Width = 50;
			TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "cmnd";
            TextCol.HeaderText = "CMND";
            TextCol.Width = 70;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "ngaysinh";
			TextCol.HeaderText = "Ngày sinh";
			TextCol.Width = 70;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "phai";
			TextCol.HeaderText = "Phái";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "lapgiadinh";
			TextCol.HeaderText = "Lập Gia Đình";
			TextCol.Width = 50;
            TextCol.Alignment = HorizontalAlignment.Center;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "chucvu";
            TextCol.HeaderText = "Chức Vụ";
            TextCol.Width = 75;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "vip";
            TextCol.HeaderText = "VIP";
            TextCol.Width = 50;
            TextCol.Alignment = HorizontalAlignment.Center;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);


            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "optionchitra";
            TextCol.HeaderText = "Option Chi Trả";
            TextCol.Width = 100;
            TextCol.Alignment = HorizontalAlignment.Center;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "donvi";
			TextCol.HeaderText = "Đơn vị";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            //TextCol = new DataGridTextBoxColumn();
            //TextCol.MappingName = "sothe";
            //TextCol.HeaderText = "Số thẻ BHYT";
            //TextCol.Width = 80;
            //ts.GridColumnStyles.Add(TextCol);
            //dataGrid1.TableStyles.Add(ts);
			
            //TextCol = new DataGridTextBoxColumn();
            //TextCol.MappingName = "dkkcb";
            //TextCol.HeaderText = "Nơi đăng ký BHYT";
            //TextCol.Width = 100;
            //ts.GridColumnStyles.Add(TextCol);
            //dataGrid1.TableStyles.Add(ts);

            //TextCol = new DataGridTextBoxColumn();
            //TextCol.MappingName = "denngay";
            //TextCol.HeaderText = "Ngày hết hạn";
            //TextCol.Width = 80;
            //ts.GridColumnStyles.Add(TextCol);
            //dataGrid1.TableStyles.Add(ts);

			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "nghenghiep";
			TextCol.HeaderText = "Nghề nghiệp";
			TextCol.Width = 160;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "diachi";
			TextCol.HeaderText = "Địa chỉ";
			TextCol.Width = 160;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "mabn";
			TextCol.HeaderText = "Mã số";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}
		
		private void butImage_Click(object sender, System.EventArgs e)
		{
			try
			{
				string atmp=System.Environment.CurrentDirectory,atmp1="";
				SaveFileDialog asf = new SaveFileDialog();
				asf.CheckPathExists=true;
				asf.InitialDirectory=txtPathImage.Text;
				asf.FileName="tmp";
				if(asf.ShowDialog()==DialogResult.OK)
				{
					if(asf.FileName!="")
					{
						txtPathImage.Text=asf.FileName;
						try
						{
							atmp1=txtPathImage.Text.Substring(0,txtPathImage.Text.LastIndexOf("\\")+1);
						}
						catch
						{
							atmp1="";
						}
						txtPathImage.Text=atmp1;
					}
				}
				asf.Dispose();
				System.Environment.CurrentDirectory=atmp;
			}
			catch
			{
			}		
		}
		
        private void dataGrid1_Navigate(object sender, NavigateEventArgs ne)
        {

        }

        private void chkMann_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void imp_dmgiavp_01012012(string file, string v_ngayhieuluc)
        {
            
            string sql = "";
            DataTable dtdm = m_v.get_data("select * from " + m_v.user + ".v_giavp ").Tables[0];
            DataTable dt = get_excel(path.Text).Tables[0];
            //file excel dmkt_15032012
            DataRow r1;

            decimal l_id = 0, d_pt_th = 0, d_pt_dv = 0, d_pt_nn = 0, d_pt_cs = 0;
            decimal d_gia_th = 0, d_gia_dv = 0, d_gia_nn = 0, d_gia_cs = 0, d_gia_bh = 0;
            int i_tw = 0, i_tinh = 0, i_huyen = 0, i_xa = 0, i_tuyen = 0;
            int i_stt = 0, i_bbhoichan = 0, i_giaycamdoan = 0, i_hsngoaitru = 0;
            string d_mavp = "", s_mack = "", s_manhom = "", s_tgtrakq = "", s_cn = "";
            int i_col_chinhanh = 5;//ma
            i_tuyen = 7;
            string s_cnapdung = "", s_tncv_1 = "", s_tncv_2 = "", s_tncv_3 = "", s_tncv_4 = "", s_tncv_5 = "", s_tncv_6 = "", s_cnapdung1 = "";
            foreach (DataRow r in dt.Rows)
            {
                d_mavp = r[5].ToString();
                if (d_mavp != "")
                {
                    d_mavp = r[5].ToString();
                    try
                    {
                        i_stt = int.Parse(r[0].ToString());
                    }
                    catch { i_stt = 0; continue; }
                    r1 = m_v.getrowbyid(dtdm, "trim(ma)='" + d_mavp + "'");
                    if (r1 != null)
                    {
                        l_id = decimal.Parse(r1["id"].ToString());
                        i_tuyen = (r[7].ToString() == "") ? 7 : int.Parse(r[7].ToString());
                        d_gia_bh = (r[14].ToString() == "") ? 0 : decimal.Parse(r[14].ToString());
                        d_gia_th = (r[8].ToString() == "") ? 0 : decimal.Parse(r[8].ToString());
                        d_gia_dv = (r[8].ToString() == "") ? 0 : decimal.Parse(r[8].ToString());
                        d_gia_nn = (r[10].ToString() == "") ? 0 : decimal.Parse(r[10].ToString());
                        d_gia_cs = (r[10].ToString() == "") ? 0 : decimal.Parse(r[10].ToString());

                        d_pt_th = (r[15].ToString() == "") ? 0 : decimal.Parse(r[15].ToString());
                        d_pt_dv = (r[15].ToString() == "") ? 0 : decimal.Parse(r[15].ToString());
                        d_pt_nn = (r[17].ToString() == "") ? 0 : decimal.Parse(r[17].ToString());
                        d_pt_cs = (r[17].ToString() == "") ? 0 : decimal.Parse(r[17].ToString());

                        if (d_gia_nn == 0) d_gia_nn = d_gia_th;
                        if (d_gia_cs == 0) d_gia_cs = d_gia_th;

                        if (d_pt_nn == 0) d_pt_nn = d_pt_th;
                        if (d_pt_cs == 0) d_pt_cs = d_pt_th;
                        //
                        //25-26-27-28-29-30: cn ap dung
                        s_cnapdung = "";
                        int ij1 = 0;
                        for (int ij = 25; ij <= 30; ij++)
                        {
                            ij1 = ij - 24;
                            s_cnapdung1 = r[ij].ToString().Trim().ToLower();
                            s_cnapdung += (s_cnapdung1 == "x") ? ij1.ToString() + "," : "";
                        }

                        //31..36: tiep nhan chuyen vien
                        ij1 = 31;
                        s_tncv_1 = r[ij1].ToString().Trim(); ij1 += 1;
                        s_tncv_2 = r[ij1].ToString().Trim(); ij1 += 1;
                        s_tncv_3 = r[ij1].ToString().Trim(); ij1 += 1;
                        s_tncv_4 = r[ij1].ToString().Trim(); ij1 += 1;
                        s_tncv_5 = r[ij1].ToString().Trim(); ij1 += 1;
                        s_tncv_6 = r[ij1].ToString().Trim(); ij1 += 1;
                        //
                        i_bbhoichan = r[37].ToString().ToLower() == "x" ? 1 : 0;
                        i_giaycamdoan = r[38].ToString().ToLower() == "x" ? 1 : 0;
                        i_hsngoaitru = r[39].ToString().ToLower() == "x" ? 1 : 0;
                        //

                        //
                        m_v.upd_v_giavp_truoc(l_id, decimal.Parse(r1["id_loai"].ToString()), decimal.Parse(i_stt.ToString()), d_mavp, r[1].ToString(), r1["dvt"].ToString(), decimal.Parse(r1["bhyt"].ToString()),
                            d_gia_th, d_gia_bh, d_gia_dv, d_gia_nn, d_gia_cs, d_gia_cs, d_pt_th, d_pt_dv, d_pt_nn, d_pt_cs, decimal.Parse(r1["userid"].ToString()), "0", v_ngayhieuluc, i_tuyen, s_cnapdung.Trim().Trim(','), s_tncv_1, s_tncv_2, s_tncv_3, s_tncv_4, s_tncv_5, s_tncv_6, i_bbhoichan, i_giaycamdoan, i_hsngoaitru, -1, "", "", "");
                    }
                }
            }
        }
        private void imp_dmgiavp_15042012(string file, string v_ngayhieuluc)
        {

            string sql = "";
            dscn = m_v.get_data("select * from medibv.dmchinhanh where id >0 and matmang=0 ");
            i_IDCN = m_v.i_Chinhanh_hientai;
            int tmp_idcn = 0;
            bool bTrungtam = m_v.bServercenter(i_IDCN);
            string sdbclient = "", s_cn_dblink = "";
            //
            DataTable dtloaivp = m_v.get_data("select id, ten, viettat from medibv.v_loaivp ").Tables[0];
            DataTable dtdm = m_v.get_data("select id, ma, dvt, id_loai, userid, bhyt, bhyt_tt from " + m_v.user + ".v_giavp ").Tables[0];
            DataTable dt = get_excel(path.Text).Tables[0];
            //file excel dmkt_15032012
            DataRow r1;

            decimal l_id = 0, d_pt_th = 0, d_pt_dv = 0, d_pt_nn = 0, d_pt_cs = 0;
            decimal d_gia_th = 0, d_gia_dv = 0, d_gia_nn = 0, d_gia_cs = 0, d_gia_bh = 0;
            int i_tw = 0, i_tinh = 0, i_huyen = 0, i_xa = 0, i_tuyen = 0;
            int i_stt = 0, i_bbhoichan = 0, i_giaycamdoan = 0, i_hsngoaitru = 0;
            string d_mavp = "", s_mack = "", s_manhom = "", s_tgtrakq = "", s_cn = "";
            int i_col_chinhanh = 5, i_kythuatcao = -1;//ma
            i_tuyen = 7;
            string s_cnapdung = "", s_tncv_1 = "", s_tncv_2 = "", s_tncv_3 = "", s_tncv_4 = "", s_tncv_5 = "", s_tncv_6 = "", s_cnapdung1 = "", s_doituongapdung = "", s_maluong;
            decimal d_id_loai = 101;//MAC DINH LAI kt nGOAI TONG QUAT
            DataRow drLoaivp;
            int i_count = dt.Rows.Count, i_dangthuchien=0, i_moi=0;
            int i_bhyt = 0;
            string s_doituong = "";
            foreach (DataRow r in dt.Rows)
            {
                i_dangthuchien += 1;
                lblDonvi.Text = r[5].ToString() + " - " + r[1].ToString();
                lblDonvi.Refresh();
                d_mavp = r[5].ToString();
                if (d_mavp != "")
                {
                    d_mavp = r[5].ToString();
                    try
                    {
                        i_stt = int.Parse(r[0].ToString());
                    }
                    catch { i_stt = 0; continue; }
                    r1 = m_v.getrowbyid(dtdm, "trim(ma)='" + d_mavp + "'");
                    if (bTrungtam && r1 == null)
                    {
                        i_moi += 1;
                        //dm moi
                        l_id=m_v.get_id_v_giavp;
                        d_id_loai=101;
                        //
                        drLoaivp = m_v.getrowbyid(dtloaivp, "lower(viettat)='" + r[2].ToString().ToLower().Trim() + "'");
                        if (drLoaivp != null)
                        {
                            d_id_loai = decimal.Parse(drLoaivp["id"].ToString());
                        }
                        //
                        d_gia_bh = (r[28].ToString() == "") ? 0 : decimal.Parse(r[28].ToString());
                        d_gia_th = (r[24].ToString() == "") ? 0 : decimal.Parse(r[24].ToString());
                        d_gia_dv = (r[24].ToString() == "") ? 0 : decimal.Parse(r[24].ToString());
                        d_gia_nn = (r[25].ToString() == "") ? 0 : decimal.Parse(r[25].ToString());
                        d_gia_cs = (r[25].ToString() == "") ? 0 : decimal.Parse(r[25].ToString());

                        d_pt_th = (r[26].ToString() == "") ? 0 : decimal.Parse(r[26].ToString());
                        d_pt_dv = (r[26].ToString() == "") ? 0 : decimal.Parse(r[26].ToString());
                        d_pt_nn = (r[27].ToString() == "") ? 0 : decimal.Parse(r[27].ToString());
                        d_pt_cs = (r[27].ToString() == "") ? 0 : decimal.Parse(r[27].ToString());
                        //
                        s_cnapdung = "";
                        s_doituongapdung = "";
                        int ij1 = 0;
                        i_bhyt = 0;
                        for (int ij = 8; ij <= 13; ij++)
                        {
                            ij1 = ij - 7;
                            s_cnapdung1 = r[ij].ToString().Trim().ToLower();
                            s_cnapdung += (s_cnapdung1 == "x" || s_cnapdung1 == "bh" || s_cnapdung1=="dv") ? ij1.ToString() + "," : "";                            
                            s_doituongapdung += s_cnapdung1 + ",";
                            if (ij1 == i_IDCN && i_IDCN != 9 && s_cnapdung1 == "bh" && d_gia_bh > 0) i_bhyt = 100;
                            else if (ij1 == i_IDCN && i_IDCN != 9 && s_cnapdung1 == "dv") i_bhyt = 0;
                            else if (ij1 == i_IDCN && i_IDCN != 9) i_bhyt = d_gia_bh > 0 ? 100 : 0;//chi nhanh
                            else if (i_IDCN == 9) i_bhyt = d_gia_bh > 0 ? 100 : 0;//cty
                        }
                        s_doituong = r[31].ToString();//
                        if (s_doituong.ToUpper() == "BHYT") i_bhyt = 100;
                        else i_bhyt = 0;
                        //31..36: tiep nhan chuyen vien
                        ij1 = 14;
                        s_tncv_1 = r[ij1].ToString().Trim().Trim(','); ij1 += 1;
                        s_tncv_2 = r[ij1].ToString().Trim().Trim(','); ij1 += 1;
                        s_tncv_3 = r[ij1].ToString().Trim().Trim(','); ij1 += 1;
                        s_tncv_4 = r[ij1].ToString().Trim().Trim(','); ij1 += 1;
                        s_tncv_5 = r[ij1].ToString().Trim().Trim(','); ij1 += 1;
                        s_tncv_6 = r[ij1].ToString().Trim().Trim(','); ij1 += 1;
                        //
                        i_bbhoichan = r[20].ToString().ToLower() == "x" ? 1 : 0;
                        i_giaycamdoan = r[21].ToString().ToLower() == "x" ? 1 : 0;
                        i_hsngoaitru = r[22].ToString().ToLower() == "x" ? 1 : 0;
                        i_kythuatcao = r[23].ToString().ToLower() == "x" ? 0 : -1;
                        //
                        s_maluong = r[29].ToString();
                        //
                        m_v.upd_v_giavp(l_id, d_id_loai, i_stt, d_mavp, r[1].ToString().Trim(), "Lần", d_gia_th, d_gia_bh, d_gia_dv, d_gia_nn, d_gia_cs, 0, 0, 0, 0, 0, (d_gia_bh > 0) ? 100 : 0, 0, 0, 0, 0, 0,(d_pt_th + d_pt_dv + d_pt_nn > 0) ? 1 : 0, 0, "", 0, i_userid, 0, d_gia_th, 0, 1, i_kythuatcao, "");
                        sql = "update medibv.v_giavp set phuthu_th=" + d_pt_th + ",phuthu_dv=" + d_pt_dv + ",phuthu_nn=" + d_pt_nn + ",phuthu_cs=" + d_pt_cs;
                        sql += ", hide=1, cosothay='" + s_cnapdung + "',hoichan=" + i_bbhoichan + ",giaycamdoan=" + i_giaycamdoan + ",xamlan=" + i_hsngoaitru;
                        sql += " where id=" + l_id;
                        m_v.execute_data(sql);
                        //Cap nhat 6 chi nhanh
                        foreach (DataRow drcn in dscn.Tables[0].Select("id<>" + i_IDCN))
                        {
                            m_v.databaselinks_name = "";
                            sdbclient = "";
                            tmp_idcn = int.Parse(drcn["id"].ToString());
                            s_cn_dblink = "@" + drcn["database"].ToString().Trim('@');
                            if (m_v.bDblinkAlive(s_cn_dblink.Trim().Trim('@')) == false) continue;

                            m_v.databaselinks_name = s_cn_dblink;

                            m_v.upd_v_giavp(l_id, d_id_loai, i_stt, d_mavp, r[1].ToString().Trim(), "Lần", d_gia_th, d_gia_bh, d_gia_dv, d_gia_nn, d_gia_cs, 0, 0, 0, 0, 0, (d_gia_bh > 0) ? 100 : 0, 0, 0, 0, 0, 0, (d_pt_th + d_pt_dv + d_pt_nn > 0) ? 1 : 0, 0, "", 0, i_userid, 0, d_gia_th, 0, 1, i_kythuatcao, "");
                            m_v.databaselinks_name = "";
                            //
                            s_cn_dblink = "@" + s_cn_dblink.Trim('@');
                            sql = "update medibv.v_giavp" + s_cn_dblink + " set phuthu_th=" + d_pt_th + ",phuthu_dv=" + d_pt_dv + ",phuthu_nn=" + d_pt_nn + ",phuthu_cs=" + d_pt_cs;
                            sql += ", hide=1, cosothay='" + s_cnapdung + "',hoichan=" + i_bbhoichan + ",giaycamdoan=" + i_giaycamdoan + ",xamlan=" + i_hsngoaitru;
                            sql += " where id=" + l_id;
                            m_v.execute_data(sql);
                        }
                        //
                        dtdm = m_v.get_data("select * from " + m_v.user + ".v_giavp ").Tables[0];
                        r1 = m_v.getrowbyid(dtdm, "trim(ma)='" + d_mavp + "'");
                        //
                        //

                    }
                    lblTongso.Text = i_count.ToString() + "/" + i_dangthuchien.ToString() + "/" + i_moi.ToString();
                    lblTongso.Refresh();
                    if (r1 != null)
                    {
                        l_id = decimal.Parse(r1["id"].ToString());
                        i_tuyen = (r[7].ToString() == "") ? 7 : int.Parse(r[7].ToString());
                        //
                        d_gia_bh = (r[28].ToString() == "") ? 0 : decimal.Parse(r[28].ToString());
                        d_gia_th = (r[24].ToString() == "") ? 0 : decimal.Parse(r[24].ToString());
                        d_gia_dv = (r[24].ToString() == "") ? 0 : decimal.Parse(r[24].ToString());
                        d_gia_nn = (r[25].ToString() == "") ? 0 : decimal.Parse(r[25].ToString());
                        d_gia_cs = (r[25].ToString() == "") ? 0 : decimal.Parse(r[25].ToString());

                        d_pt_th = (r[26].ToString() == "") ? 0 : decimal.Parse(r[26].ToString());
                        d_pt_dv = (r[26].ToString() == "") ? 0 : decimal.Parse(r[26].ToString());
                        d_pt_nn = (r[27].ToString() == "") ? 0 : decimal.Parse(r[27].ToString());
                        d_pt_cs = (r[27].ToString() == "") ? 0 : decimal.Parse(r[27].ToString());

                        if (d_gia_nn == 0) d_gia_nn = d_gia_th;
                        if (d_gia_cs == 0) d_gia_cs = d_gia_th;

                        if (d_pt_nn == 0) d_pt_nn = d_pt_th;
                        if (d_pt_cs == 0) d_pt_cs = d_pt_th;
                        //
                        //8,9,10,11,12,13: cn ap dung
                        s_cnapdung = "";
                        s_doituongapdung = "";
                        int ij1 = 0;
                        i_bhyt = 0;
                        for (int ij = 8; ij <= 13; ij++)
                        {
                            ij1 = ij - 7;
                            s_cnapdung1 = r[ij].ToString().Trim().ToLower();                            
                            s_cnapdung += (s_cnapdung1 == "x" || s_cnapdung1 == "bh" || s_cnapdung1 == "dv") ? ij1.ToString() + "," : "";
                            s_doituongapdung +=  s_cnapdung1+",";
                            if (ij1 == i_IDCN && i_IDCN != 9 && s_cnapdung1 == "bh" && d_gia_bh > 0) i_bhyt = 100;
                            else if (ij1 == i_IDCN && i_IDCN != 9 && s_cnapdung1 == "dv") i_bhyt = 0;
                            else if (ij1 == i_IDCN && i_IDCN != 9) i_bhyt = d_gia_bh > 0 ? 100 : 0;//chi nhanh
                            else if (i_IDCN == 9) i_bhyt = d_gia_bh > 0 ? 100 : 0;//cty
                        }

                        //31..36: tiep nhan chuyen vien
                        ij1 = 14;
                        s_tncv_1 = r[ij1].ToString().Trim().Trim(','); ij1 += 1;
                        s_tncv_2 = r[ij1].ToString().Trim().Trim(','); ij1 += 1;
                        s_tncv_3 = r[ij1].ToString().Trim().Trim(','); ij1 += 1;
                        s_tncv_4 = r[ij1].ToString().Trim().Trim(','); ij1 += 1;
                        s_tncv_5 = r[ij1].ToString().Trim().Trim(','); ij1 += 1;
                        s_tncv_6 = r[ij1].ToString().Trim().Trim(','); ij1 += 1;
                        //
                        i_bbhoichan = r[20].ToString().ToLower() == "x" ? 1 : 0;
                        i_giaycamdoan = r[21].ToString().ToLower() == "x" ? 1 : 0;
                        i_hsngoaitru = r[22].ToString().ToLower() == "x" ? 1 : 0;
                        i_kythuatcao = r[23].ToString().ToLower() == "x" ? 0 : -1;
                        //
                        s_maluong = r[29].ToString();
                        //
                        m_v.upd_v_giavp_truoc(l_id, decimal.Parse(r1["id_loai"].ToString()), decimal.Parse(i_stt.ToString()), d_mavp, r[1].ToString(), r1["dvt"].ToString(), i_bhyt ,
                            d_gia_th, d_gia_bh, d_gia_dv, d_gia_nn, d_gia_cs, d_gia_cs, d_pt_th, d_pt_dv, d_pt_nn, d_pt_cs, decimal.Parse(r1["userid"].ToString()), "0", v_ngayhieuluc, i_tuyen, s_cnapdung.Trim().Trim(','), s_tncv_1, s_tncv_2, s_tncv_3, s_tncv_4, s_tncv_5, s_tncv_6, i_bbhoichan, i_giaycamdoan, i_hsngoaitru, i_kythuatcao, "", s_doituongapdung, s_maluong);//decimal.Parse(r1["bhyt"].ToString())
                        if (chkUpdChinhanh.Checked)
                        {
                            foreach (DataRow drcn in dscn.Tables[0].Select("matmang=0 and id<>" + i_IDCN))
                            {
                                s_cn_dblink = "@" + drcn["database"].ToString().Trim('@');
                                //if (m_v.bDblinkAlive(s_cn_dblink.Trim().Trim('@')) == false) continue;
                                m_v.upd_v_giavp_truoc(l_id, decimal.Parse(r1["id_loai"].ToString()), decimal.Parse(i_stt.ToString()), d_mavp, r[1].ToString(), r1["dvt"].ToString(), i_bhyt,
                                d_gia_th, d_gia_bh, d_gia_dv, d_gia_nn, d_gia_cs, d_gia_cs, d_pt_th, d_pt_dv, d_pt_nn, d_pt_cs, decimal.Parse(r1["userid"].ToString()), "0", v_ngayhieuluc, i_tuyen, s_cnapdung.Trim().Trim(','), s_tncv_1, s_tncv_2, s_tncv_3, s_tncv_4, s_tncv_5, s_tncv_6, i_bbhoichan, i_giaycamdoan, i_hsngoaitru, i_kythuatcao, s_cn_dblink, s_doituongapdung, s_maluong);//decimal.Parse(r1["bhyt"].ToString())
                            }
                        }
                    }
                }
            }
        }

        public int LoaiImport
        {
            set
            {
                iLoaiImport = value;
            }
        }

        private void chkCapnhat_mahoabhyt_Click(object sender, EventArgs e)
        {

            //if (chkCapnhat_mahoabhyt1.Checked)
            //{
            //    chkmanhom_mack1.Checked = false;
            //    chktenViettat1.Checked = false;
            Load_Form();
            //} 
        }

        
    }
}