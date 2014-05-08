using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibVienphi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmChidinh.
	/// </summary>
	public class frmThemphong : System.Windows.Forms.Form
    {
        //--linh
        public int idgiuong = 0;
        //end
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox madoituong;
        private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butKetthuc;
		private LibMedi.AccessData m;
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
		private string s_ngay,s_makp,sql,user,xxx;
        private int i_madoituong, i_userid, itable, madoituong_giuongdichvu;
		private decimal l_maql,l_idkhoa,l_id,l_mavaovien;
        private bool bEdit = false, bDoi = false, bChenhlech, bNgayra_ngayvao_1;
		private DataRow r;
		private DataSet ds=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dthoten=new DataTable();
		private DataTable dtdt=new DataTable();
		private LibList.List listHoten;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox namsinh;
        private System.Windows.Forms.TextBox giuongold;
		private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox dongia;
		private System.Windows.Forms.TextBox tim;
        private Button butDoi;
        private Button butMoi;
        private Button butphongthem;
        private CheckBox chktragiuong;
        private MaskedBox.MaskedBox tu;
        private MaskedBox.MaskedBox den;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmThemphong(LibMedi.AccessData acc,string ngay,string makp,string tenkp,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			m=acc;s_ngay=ngay;s_makp=makp;i_userid=userid;
			this.Text=lan.Change_language_MessageText("Chuyển phòng giường khoa")+" "+tenkp.Trim();
            if (m.bBogo) tv.GanBogo(this, textBox111);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
        //--linh
        public frmThemphong(LibMedi.AccessData acc, string ngay, string makp, string tenkp, int userid, string mabn, decimal idkhoa)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this); tv.GanBogo(this, textBox111);
            m = acc; s_ngay = ngay; s_makp = makp; i_userid = userid;
            this.Text = lan.Change_language_MessageText("Chuyển phòng giường khoa") + " " + tenkp.Trim();
        }
        //--end
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemphong));
            this.label1 = new System.Windows.Forms.Label();
            this.mabn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hoten = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label4 = new System.Windows.Forms.Label();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.listHoten = new LibList.List();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.namsinh = new System.Windows.Forms.TextBox();
            this.giuongold = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dongia = new System.Windows.Forms.TextBox();
            this.tim = new System.Windows.Forms.TextBox();
            this.butDoi = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.butphongthem = new System.Windows.Forms.Button();
            this.chktragiuong = new System.Windows.Forms.CheckBox();
            this.tu = new MaskedBox.MaskedBox();
            this.den = new MaskedBox.MaskedBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(2, 347);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 18;
            this.label1.Text = "Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn
            // 
            this.mabn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(48, 348);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(72, 21);
            this.mabn.TabIndex = 0;
            this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
            this.mabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(116, 347);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hoten
            // 
            this.hoten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(160, 348);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(250, 21);
            this.hoten.TabIndex = 1;
            this.hoten.TextChanged += new System.EventHandler(this.hoten_TextChanged);
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
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
            this.dataGrid1.Location = new System.Drawing.Point(9, 8);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(696, 336);
            this.dataGrid1.TabIndex = 19;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Location = new System.Drawing.Point(-13, 368);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 27;
            this.label4.Text = "Đ. tượng :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madoituong
            // 
            this.madoituong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.madoituong.Enabled = false;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(48, 371);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(116, 21);
            this.madoituong.TabIndex = 4;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Location = new System.Drawing.Point(168, 370);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 23);
            this.label5.TabIndex = 28;
            this.label5.Text = "Giường :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(270, 403);
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
            this.butBoqua.Location = new System.Drawing.Point(340, 403);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 14;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(410, 403);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 15;
            this.butHuy.Text = "    &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(480, 403);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 16;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // listHoten
            // 
            this.listHoten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listHoten.BackColor = System.Drawing.SystemColors.Info;
            this.listHoten.ColumnCount = 0;
            this.listHoten.Location = new System.Drawing.Point(600, 416);
            this.listHoten.MatchBufferTimeOut = 1000;
            this.listHoten.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listHoten.Name = "listHoten";
            this.listHoten.Size = new System.Drawing.Size(75, 17);
            this.listHoten.TabIndex = 31;
            this.listHoten.TextIndex = -1;
            this.listHoten.TextMember = null;
            this.listHoten.ValueIndex = -1;
            this.listHoten.Visible = false;
            this.listHoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listHoten_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(503, 347);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 23);
            this.label3.TabIndex = 74;
            this.label3.Text = "Ngày giờ vào :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(409, 347);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 23);
            this.label6.TabIndex = 75;
            this.label6.Text = "NS :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // namsinh
            // 
            this.namsinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(437, 348);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(36, 21);
            this.namsinh.TabIndex = 2;
            // 
            // giuongold
            // 
            this.giuongold.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.giuongold.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giuongold.Enabled = false;
            this.giuongold.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giuongold.Location = new System.Drawing.Point(215, 370);
            this.giuongold.Name = "giuongold";
            this.giuongold.Size = new System.Drawing.Size(142, 21);
            this.giuongold.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Location = new System.Drawing.Point(382, 370);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 23);
            this.label9.TabIndex = 82;
            this.label9.Text = "Đơn giá :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dongia
            // 
            this.dongia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dongia.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dongia.Enabled = false;
            this.dongia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dongia.Location = new System.Drawing.Point(437, 370);
            this.dongia.Name = "dongia";
            this.dongia.Size = new System.Drawing.Size(72, 21);
            this.dongia.TabIndex = 7;
            this.dongia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tim
            // 
            this.tim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.ForeColor = System.Drawing.Color.Red;
            this.tim.Location = new System.Drawing.Point(8, 3);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(696, 21);
            this.tim.TabIndex = 83;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tim_KeyDown);
            // 
            // butDoi
            // 
            this.butDoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butDoi.Image = ((System.Drawing.Image)(resources.GetObject("butDoi.Image")));
            this.butDoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDoi.Location = new System.Drawing.Point(200, 403);
            this.butDoi.Name = "butDoi";
            this.butDoi.Size = new System.Drawing.Size(70, 25);
            this.butDoi.TabIndex = 11;
            this.butDoi.Text = "    &Sửa";
            this.butDoi.Click += new System.EventHandler(this.butDoi_Click);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(130, 403);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 10;
            this.butMoi.Text = "     &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butphongthem
            // 
            this.butphongthem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butphongthem.Enabled = false;
            this.butphongthem.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butphongthem.Location = new System.Drawing.Point(359, 370);
            this.butphongthem.Name = "butphongthem";
            this.butphongthem.Size = new System.Drawing.Size(24, 21);
            this.butphongthem.TabIndex = 6;
            this.butphongthem.Text = "...";
            this.butphongthem.Click += new System.EventHandler(this.butphongthem_Click);
            // 
            // chktragiuong
            // 
            this.chktragiuong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chktragiuong.AutoSize = true;
            this.chktragiuong.Location = new System.Drawing.Point(512, 375);
            this.chktragiuong.Name = "chktragiuong";
            this.chktragiuong.Size = new System.Drawing.Size(68, 17);
            this.chktragiuong.TabIndex = 8;
            this.chktragiuong.Text = "Trả ngày";
            this.chktragiuong.UseVisualStyleBackColor = true;
            this.chktragiuong.CheckedChanged += new System.EventHandler(this.chktragiuong_CheckedChanged);
            // 
            // tu
            // 
            this.tu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tu.Enabled = false;
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(585, 348);
            this.tu.Mask = "##/##/#### ##:##";
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(125, 21);
            this.tu.TabIndex = 3;
            this.tu.Text = "  /  /       :  ";
            this.tu.Validated += new System.EventHandler(this.tu_Validated);
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // den
            // 
            this.den.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.den.BackColor = System.Drawing.SystemColors.HighlightText;
            this.den.Enabled = false;
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(585, 370);
            this.den.Mask = "##/##/#### ##:##";
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(125, 21);
            this.den.TabIndex = 9;
            this.den.Text = "  /  /       :  ";
            this.den.Validated += new System.EventHandler(this.den_Validated);
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // frmThemphong
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(714, 447);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.chktragiuong);
            this.Controls.Add(this.butphongthem);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.butDoi);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.dongia);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.giuongold);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listHoten);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmThemphong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký thêm phòng/giường";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmChuyenphong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmChuyenphong_Load(object sender, System.EventArgs e)
		{
			itable=m.tableid("","theodoigiuong");
			user=m.user;xxx=user+m.mmyy(s_ngay);
            string stime = "'" + m.f_ngay + "'";
            bChenhlech = m.bChenhlech;
            madoituong_giuongdichvu = (m.bMadoituong_giuongdichvu) ? m.madoituong_giuongdichvu : 0;
            bNgayra_ngayvao_1 = m.bNgayra_ngayvao_1;

            dthoten = m.get_hiendien(s_makp, s_ngay).Tables[0];
            /*
            sql = "select a.mabn,b.hoten,b.namsinh,a.maql,c.madoituong,d.sothe,c.mavaovien ";
            sql += " from " + user + ".hiendien a inner join " + user + ".btdbn b on a.mabn=b.mabn ";
            sql += " inner join " + user + ".benhandt c on a.maql=c.maql ";
            sql += " left join " + user + ".bhyt d on a.maql=d.maql ";
            sql += " where a.nhapkhoa=1 and a.xuatkhoa=0 and a.makp='" + s_makp + "'";
            sql += " and " + m.for_ngay("a.ngay", stime) + " <= to_date('" + s_ngay + "'," + stime + ")";
            sql += " order by a.id desc";
            dthoten = m.get_data(sql).Tables[0];
            */
			listHoten.DisplayMember="MABN";
			listHoten.ValueMember="HOTEN";
			listHoten.DataSource=dthoten;

            dt = m.get_data("select a.*,b.chenhlech,c.dichvu from " + user + ".dmgiuong a," + user + ".v_giavp b,"+user+".dmphong c where a.id=b.id and a.idphong=c.id").Tables[0];

            dtdt = m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a where (donvi<>1 and mien<>1) order by madoituong").Tables[0];
			madoituong.DisplayMember="DOITUONG";
			madoituong.ValueMember="MADOITUONG";
			madoituong.DataSource=dtdt;

			load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
		}

		private void AddGridTableStyle()
		{
			DataGridColoredTextBoxColumn TextCol1;
			delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.RowHeaderWidth=10;
			ts.MappingName = ds.Tables[0].TableName;
			ts.AllowSorting=false;
			
			TextCol1=new DataGridColoredTextBoxColumn(de, 0);
			TextCol1.MappingName = "id";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 1);
			TextCol1.MappingName = "mabn";
			TextCol1.HeaderText = "Mã BN";
			TextCol1.Width = 60;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 2);
			TextCol1.MappingName = "hoten";
			TextCol1.HeaderText = "Họ tên";
			TextCol1.Width =140;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 3);
			TextCol1.MappingName = "namsinh";
			TextCol1.HeaderText = "NS";
			TextCol1.Width =30;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 4);
			TextCol1.MappingName = "doituong";
			TextCol1.HeaderText = "Đối tượng";
			TextCol1.Width = 80;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 5);
			TextCol1.MappingName = "sothe";
			TextCol1.HeaderText = "Số thẻ";
			TextCol1.Width = 80;
			TextCol1.ReadOnly=true;
            TextCol1.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 6);
			TextCol1.MappingName = "ma";
			TextCol1.HeaderText = "Mã giường";
			TextCol1.Width = 70;
			TextCol1.ReadOnly=true;
            TextCol1.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 7);
			TextCol1.MappingName = "tu";
			TextCol1.HeaderText = "Từ";
			TextCol1.Width = 100;
			TextCol1.ReadOnly=true;
            TextCol1.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 8);
			TextCol1.MappingName = "den";
			TextCol1.HeaderText = "Đến";
			TextCol1.Width = 100;
			TextCol1.ReadOnly=true;
            TextCol1.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);


            TextCol1 = new DataGridColoredTextBoxColumn(de, 8);
            TextCol1.MappingName = "tengiuong";
            TextCol1.HeaderText = "Giường";
            TextCol1.Width = 150;
            TextCol1.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 8);
            TextCol1.MappingName = "phong";
            TextCol1.HeaderText = "Phòng";
            TextCol1.Width = 150;
            TextCol1.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			return Color.Black;//(this.dataGrid1[row,7].ToString().Trim()=="x")?Color.Red:Color.Black;
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
			
				catch{}
				finally
				{
					base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
				}
			}
		}
		private void load_grid()
		{
            sql = "select a.id,a.mabn,a.mavaovien,a.maql,a.idkhoa,c.hoten,c.namsinh,a.madoituong,e.doituong,f.sothe,";
            sql += " a.idgiuong,b.ma,b.ten,to_char(a.tu,'dd/mm/yyyy hh24:mi') as tu,to_char(a.den,'dd/mm/yyyy hh24:mi') as den,a.dongia";
            sql += ", b.ten as tengiuong, p.ten as phong ";
            sql += " from " + user + ".theodoigiuong a inner join " + user + ".dmgiuong b on a.idgiuong=b.id ";
            sql += " inner join " + user + ".btdbn c on a.mabn=c.mabn ";
            sql += " inner join " + user + ".doituong e on a.madoituong=e.madoituong ";
            sql += " left join " + user + ".bhyt f on a.maql=f.maql ";
            sql += " inner join " + user + ".dmphong p on b.idphong=p.id ";
            sql += " where (to_date(to_char(a.den,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + s_ngay + "','dd/mm/yyyy') or a.den is null) and a.makp='" + s_makp + "'";
            sql += " and giuongthem=1";
            sql += " order by a.tu";
			ds=m.get_data(sql);
			dataGrid1.DataSource=ds.Tables[0];
			ref_text();
		}
		private void madoituong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (madoituong.SelectedIndex==-1) madoituong.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void ref_text()
		{
			try
			{
				l_id=decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,0].ToString());
				DataRow r1=m.getrowbyid(ds.Tables[0],"id="+l_id);
				if (r1!=null)
				{
                    l_mavaovien = decimal.Parse(r1["mavaovien"].ToString());
					l_maql=decimal.Parse(r1["maql"].ToString());
					l_idkhoa=decimal.Parse(r1["idkhoa"].ToString());
					mabn.Text=r1["mabn"].ToString();
					hoten.Text=r1["hoten"].ToString();
					namsinh.Text=r1["namsinh"].ToString();
					tu.Text=r1["tu"].ToString();
                    den.Text=r1["den"].ToString();
					madoituong.SelectedValue=r1["madoituong"].ToString();
					giuongold.Text=r1["ma"].ToString();
                    //giuongnew.Text="";
					dongia.Text=r1["dongia"].ToString();
					
				}
			}
			catch{}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void ena_object(bool ena)
		{
            mabn.Enabled = ena;
            hoten.Enabled = ena;
            tu.Enabled =  ena;
			madoituong.Enabled=ena;
            butphongthem.Enabled = ena;
            chktragiuong.Enabled = !ena;
            //den.Enabled=ena;
            //butPhong.Enabled=ena;
            //butSua.Enabled=!ena;
            butDoi.Enabled = !ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
            butMoi.Enabled = !ena;
			tim.Enabled=!ena;
            dataGrid1.Enabled = !ena;
            chktragiuong.Checked = false;
		}

        private void ena_but(bool ena)
        {            
            butDoi.Enabled = !ena;
            butHuy.Enabled = !ena;
            butKetthuc.Enabled = !ena;
            butLuu.Enabled = ena;
            butBoqua.Enabled = ena;
            butMoi.Enabled = !ena;
            tim.Enabled = !ena;
            dataGrid1.Enabled = !ena;
        }
		private void butMoi_Click(object sender, System.EventArgs e)
		{
			l_maql=0;
            mabn.Text = hoten.Text = den.Text = "";
            tu.Text = m.ngayhienhanh_server;
			ena_object(true);
            giuongold.Tag = "";
			mabn.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
            bEdit = true;
            if (den.Text != "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Đã trả giường không được thay đổi !"), LibMedi.AccessData.Msg);
                return;
            }
            bDoi = false;
			ena_object(true);
			//if (bEdit) den.Text=m.ngayhienhanh_server;
			madoituong.Focus();
		}

		private bool kiemtra()
		{
			if (madoituong.SelectedIndex==-1)
			{
				madoituong.Focus();
				return false;
			}
			r=m.getrowbyid(dthoten,"mabn='"+mabn.Text+"'");
            if (r == null)
            {
                MessageBox.Show(lan.Change_language_MessageText("Người bệnh không hợp lệ !"), LibMedi.AccessData.Msg);
                mabn.Focus();
                return false;
            }
            //else if (!bDoi && den.Text!="")
            //{
            //    if (!m.bNgaygio(den.Text, tu.Text))
            //    {
            //        MessageBox.Show(lan.Change_language_MessageText("Ngày giờ chuyển không được nhỏ hơn ngày vào (" + tu.Text + ")!"), LibMedi.AccessData.Msg);
            //        den.Focus();
            //        return false;
            //    }
            //    if (!m.bNgaygio(den.Text,r["ngay"].ToString()))
            //    {
            //        MessageBox.Show(lan.Change_language_MessageText("Ngày giờ chuyển không được nhỏ hơn ngày vào viện ("+r["ngay"].ToString()+")!"),LibMedi.AccessData.Msg);
            //        den.Focus();
            //        return false;
            //    }
            //}
			if ((mabn.Text!="" && hoten.Text=="") || (mabn.Text=="" && hoten.Text!=""))
			{
				MessageBox.Show(lan.Change_language_MessageText("Họ tên người bệnh !"),LibMedi.AccessData.Msg);
				if (mabn.Text=="") mabn.Focus();
				else if (hoten.Text=="") hoten.Focus();
				return false;
			}
            //if (den.Text=="" && !bDoi)
            //{
            //    MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập ngày giờ chuyển !"),LibMedi.AccessData.Msg);
            //    den.Focus();
            //    return false;
            //}
            //if (giuongnew.Text=="" && !bDoi)
            //{
            //    MessageBox.Show(lan.Change_language_MessageText("Chọn phòng giường chuyển !"),LibMedi.AccessData.Msg);
            //    butPhong.Focus();
            //    return false;
            //}
            
			return true;
		}
		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
            bool bPhongluuc = m.get_phongluu_nhapkhoa(l_maql);
			decimal songay=0;
            int _madoituong = 0,so=0;
            DataRow r2, r3 = m.getrowbyid(dt, "ma='" + giuongold.Text + "'");            
            m.upd_eve_tables(itable, i_userid, "upd");
            m.upd_eve_upd_del(itable, i_userid, "upd", m.fields(user + ".theodoigiuong", "id=" + l_id));            
            string fie = "gia_th";
            l_id = (bEdit)?l_id:v.get_id_vpkhoa;
            _madoituong = int.Parse(madoituong.SelectedValue.ToString());
            if (chktragiuong.Checked==false)
            {
                if (r3 != null)
                {
                    if (bNgayra_ngayvao_1 && madoituong_giuongdichvu != 0) _madoituong = (r3["dichvu"].ToString() == "1") ? madoituong_giuongdichvu : int.Parse(madoituong.SelectedValue.ToString());
                    r2 = m.getrowbyid(dtdt, "madoituong=" + _madoituong);
                    if (r2 != null) fie = r2["field_gia"].ToString().Trim();
                    decimal tygia = (fie.IndexOf("_nn") != -1) ? m.dTygia : 1;
                    int idgiuong = int.Parse(r3["id"].ToString());
                    m.upd_theodoigiuong(l_id, s_makp, mabn.Text, l_mavaovien, l_maql, l_idkhoa, _madoituong, int.Parse(r3["id"].ToString()), tu.Text, decimal.Parse(r3[fie].ToString()) * tygia, i_userid);
                    m.execute_data("update " + user + ".dmgiuong set tinhtrang=2,soluong=soluong+1 where id=" + int.Parse(r3["id"].ToString()));
                    m.execute_data("update " + user + ".theodoigiuong set giuongthem=1 where id=" + l_id);
                    m.upd_eve_tables(itable, i_userid, "ins");
                    m.upd_eve_upd_del(itable, i_userid, "ins", m.fields(user + ".theodoigiuong", "id=" + l_id));
                }
            }
            if (chktragiuong.Checked)
            {
                //cap nhat vp khoa
                r3 = m.getrowbyid(dt, "ma='" + giuongold.Text + "'");
                foreach (DataRow r1 in m.get_data("select a.id,to_char(a.tu,'dd/mm/yyyy hh24:mi') as tu,a.dongia,a.idgiuong,a.madoituong,c.dichvu, d.chenhlech from " + user + ".theodoigiuong a," + user + ".dmgiuong b," + user + ".dmphong c," + user + ".v_giavp d where a.idgiuong=b.id and b.idphong=c.id and b.id=d.id and a.id=" + l_id).Tables[0].Rows)
                {                    
                    if (bNgayra_ngayvao_1 && madoituong_giuongdichvu != 0) _madoituong = (r1["dichvu"].ToString() == "1" && r1["chenhlech"].ToString()=="0") ? madoituong_giuongdichvu : int.Parse(r1["madoituong"].ToString());
                    songay = (bNgayra_ngayvao_1) ? m.songaygiuong(m.StringToDateTime(den.Text), m.StringToDateTime(r1["tu"].ToString()), 1, int.Parse(r1["idgiuong"].ToString())) : Math.Max(0, m.songay(m.StringToDateTime(den.Text.Substring(0, 10)), m.StringToDateTime(r1["tu"].ToString().Substring(0, 10)), so));
                    m.upd_theodoigiuong(decimal.Parse(r1["id"].ToString()), den.Text, int.Parse(r1["madoituong"].ToString()), songay);
                    if (songay != 0) v.upd_vpkhoa(l_id, mabn.Text, l_mavaovien, l_maql, l_idkhoa, den.Text, s_makp, int.Parse(r1["madoituong"].ToString()), int.Parse(r1["idgiuong"].ToString()), Convert.ToDecimal(songay), decimal.Parse(r1["dongia"].ToString()), 0, i_userid, 0);
                    if (r3 != null)
                    {
                        try
                        {
                            m.execute_data("update " + user + ".dmgiuong set soluong=soluong-1,tinhtrang=0 where id=" + int.Parse(r1["idgiuong"].ToString()));
                        }
                        catch (Exception exx)
                        {
                            MessageBox.Show(exx.Message);
                            m.execute_data("update " + user + ".dmgiuong set soluong=0,tinhtrang=0 where id=" + int.Parse(r1["idgiuong"].ToString()));
                        }
                    }
                    break;
                }                
            }
			load_grid();
			ena_object(false);
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
            ref_text();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
			try
			{
                if (den.Text != "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đã trả phòng giường, không được hủy !"), LibMedi.AccessData.Msg);
                    return;
                }
				if (ds.Tables[0].Select("idkhoa="+l_idkhoa).Length==1)
				{
					MessageBox.Show(lan.Change_language_MessageText("Không được hủy !"),LibMedi.AccessData.Msg);
					return;
				}
				int i_row=dataGrid1.CurrentCell.RowNumber;
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					l_id=decimal.Parse(dataGrid1[i_row,0].ToString());					
					int idgiuong=0;
                    foreach (DataRow r1 in m.get_data("select * from " + user + ".theodoigiuong where idkhoa=" + l_idkhoa + " and to_char(den,'dd/mm/yyyy hh24:mi')='" + tu.Text + "'").Tables[0].Rows)
					{
						idgiuong=int.Parse(r1["idgiuong"].ToString());
                        m.execute_data("update " + user + ".dmgiuong set tinhtrang=2,soluong=soluong+1 where id=" + idgiuong);
                        m.execute_data("update " + user + ".hiendien set idgiuong=" + idgiuong + " where id=" + l_id);
                        m.execute_data("update " + user + ".theodoigiuong set soluong=0,den=null where id=" + decimal.Parse(r1["id"].ToString()));
						m.execute_data("delete from "+user+m.mmyy(tu.Text)+".v_vpkhoa where id="+decimal.Parse(r1["id"].ToString()));
					}
					if (idgiuong!=0)
					{
						m.upd_eve_tables(itable,i_userid,"del");
						m.upd_eve_upd_del(itable,i_userid,"del",m.fields(user+".theodoigiuong","id="+l_id));
						DataRow r=m.getrowbyid(dt,"ma='"+giuongold.Text+"'");
                        if (r != null)
                        {
                            //Khuong 02/11/2011
                            try
                            {
                                m.execute_data("update " + user + ".dmgiuong set tinhtrang=0,soluong=soluong-1 where id=" + int.Parse(r["id"].ToString()));
                            }
                            catch (Exception exx)
                            {
                                MessageBox.Show(exx.Message);
                                m.execute_data("update " + user + ".dmgiuong set soluong=0,tinhtrang=0 where id=" + int.Parse(r["id"].ToString()));
                            }
                        }
						r=m.getrowbyid(dt,"id="+idgiuong);
                        if (r != null) m.execute_data("update " + user + ".nhapkhoa set giuong='" + r["ma"].ToString() + "' where id=" + l_idkhoa);
                        m.execute_data("delete from " + user + ".theodoigiuong where id=" + l_id);
						load_grid();
					}
				}
			}
			catch{}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void Filt_hoten(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listHoten.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="hoten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void hoten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listHoten.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listHoten.Visible) listHoten.Focus();
				else SendKeys.Send("{Tab}");
			}				
		}

		private void hoten_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==hoten)
			{
				Filt_hoten(hoten.Text);
				listHoten.BrowseToDanhmuc(hoten,mabn,tu);
			}
		}

		private void mabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void mabn_Validated(object sender, System.EventArgs e)
		{
			if (mabn.Text=="" || mabn.Text.Trim().Length<3) return;
			if (mabn.Text.Trim().Length!=8) mabn.Text=mabn.Text.Substring(0,2)+mabn.Text.Substring(2).PadLeft(6,'0');
			r=m.getrowbyid(dthoten,"mabn='"+mabn.Text+"'");
			if (r!=null)
			{
				hoten.Text=r["hoten"].ToString();
				namsinh.Text=r["namsinh"].ToString();
                i_madoituong = 2;// int.Parse(r["madoituong"].ToString());
				madoituong.SelectedValue=i_madoituong.ToString();

                l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
                l_maql = decimal.Parse(r["maql"].ToString());
                l_idkhoa = decimal.Parse(r["id"].ToString());                
			}
			else{hoten.Text="";l_maql=0;namsinh.Text="";}
		}

		private void listHoten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) mabn_Validated(null,null);
		}

		private void tim_Enter(object sender, System.EventArgs e)
		{
			tim.Text="";
		}

		private void tim_TextChanged(object sender, System.EventArgs e)
		{
			RefreshChildren(tim.Text);
		}

		private void RefreshChildren(string text)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid1.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="mabn like '%"+text.Trim()+"%'"+" or hoten like '%"+text.Trim()+"%'"+" or ma like '%"+text.Trim()+"%'"+" or ten like '%"+text.Trim()+"%'"+" or sothe like '%"+text.Trim()+"%'";
				ref_text();
			}
			catch{}
		}

		private void tim_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                //butSua.Focus();
            }
		}

		private void den_Validated(object sender, System.EventArgs e)
		{
            if (den.Text == "")
            {
                den.Focus();
                return;
            }
            den.Text = den.Text.Trim();
            if (den.Text.Length < 16)
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày và giờ chuyển !"), LibMedi.AccessData.Msg);
                den.Focus();
                return;
            }
            if (!m.bNgay(den.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
                den.Focus();
                return;
            }
            den.Text = m.Ktngaygio(den.Text, 16);
		}

		private void butPhong_Click(object sender, System.EventArgs e)
		{
            //if (bEdit)
            //{
            //    frmDsgiuong f=new frmDsgiuong(m,s_makp,int.Parse(madoituong.SelectedValue.ToString()));
            //    f.ShowDialog();
            //    if (f.ma!="")
            //    {
            //        giuongnew.Text=f.ma;
            //        string fie="gia_th";
            //        DataRow r1=m.getrowbyid(dtdt,"madoitong="+int.Parse(madoituong.SelectedValue.ToString()));
            //        if (r1!=null) fie=r1["field_gia"].ToString().Trim();
            //        r1=m.getrowbyid(dt,"ma='"+giuongnew.Text+"'");
            //        if (r1!=null) dongia.Text=r1[fie].ToString();
            //        butLuu.Focus();
            //    }
            //}
		}

        private void butDoi_Click(object sender, EventArgs e)
        {
            if (m.bAdminHethong(i_userid) == false)
            {
                MessageBox.Show(lan.Change_language_MessageText("Bạn chưa được phân quyền để đổi giường, đề nghị liên hệ phòng máy tính."));
                return;
            }
            bDoi = true;
            if (ds.Tables[0].Rows.Count == 0) return;           
            ena_object(true);
            //den.Enabled = false;
            //madoituong.Enabled = false;
            giuongold.Tag = giuongold.Text;
            butphongthem.Focus();
        }

        private void butphongthem_Click(object sender, EventArgs e)
        {
            if (bEdit==false)
            {
                frmDsgiuong f = new frmDsgiuong(m, s_makp, int.Parse(madoituong.SelectedValue.ToString()));
                f.ShowDialog();
                if (f.ma != "")
                {
                    giuongold.Text = f.ma;
                    string fie = "gia_th";
                    DataRow r1 = m.getrowbyid(dtdt, "madoitong=" + int.Parse(madoituong.SelectedValue.ToString()));
                    if (r1 != null) fie = r1["field_gia"].ToString().Trim();
                    r1 = m.getrowbyid(dt, "ma='" + giuongold.Text + "'");
                    if (r1 != null) dongia.Text = r1[fie].ToString();
                    butLuu.Focus();
                }
            }
        }

        private void chktragiuong_CheckedChanged(object sender, EventArgs e)
        {
            den.Enabled = chktragiuong.Checked;
            ena_but(chktragiuong.Checked);
            den.Text = m.ngayhienhanh_server;
            bEdit = chktragiuong.Checked;
            den.Focus();
        }

        private void tu_Validated(object sender, EventArgs e)
        {
            //if (tu.Text.Trim().Length==16 && !m.bNgay(tu.Text))
            //{
            //    MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !") + "/n" + lan.Change_language_MessageText("Nhập ngày theo dạng: 'dd/MM/yyyy HH:mm'"));
            //    tu.Focus();
            //    return;
            //}

            if (tu.Text == "")
            {
                tu.Focus();
                return;
            }
            tu.Text = tu.Text.Trim();
            if (tu.Text.Length < 16)
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày và giờ nhận giường !"), LibMedi.AccessData.Msg);
                tu.Focus();
                return;
            }
            if (!m.bNgay(tu.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !") + "/n" + lan.Change_language_MessageText("Nhập ngày theo dạng: 'dd/MM/yyyy HH:mm'"));
                tu.Focus();
                return;
            }
            tu.Text = m.Ktngaygio(tu.Text, 16);
        }
        
	}
}
