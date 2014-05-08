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
	public class frmChuyenphong : System.Windows.Forms.Form
    {
        //--linh
        public int idgiuong = 0;
        int i_loaikp = 0;
        string tmp_makp = "";
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
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butKetthuc;
		private LibMedi.AccessData m;
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
		private string s_ngay,s_makp,sql,user,xxx,nam="";
        private int i_madoituong, i_userid, itable, madoituong_giuongdichvu;
		private decimal l_maql,l_idkhoa,l_id,l_mavaovien,l_idtam;
        private bool bEdit = false, bDoi = false, bChenhlech, bNgayra_ngayvao_1, bTienGiuong_Tudong = false;
		private DataRow r;
		private DataSet ds=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dthoten=new DataTable();
		private DataTable dtdt=new DataTable();
        private DataTable dtgiagiuongbhyt = new DataTable();
		private LibList.List listHoten;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox namsinh;
		private System.Windows.Forms.TextBox giuongold;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox giuongnew;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox dongia;
		private System.Windows.Forms.Button butPhong;
		private System.Windows.Forms.TextBox tu;
		private MaskedBox.MaskedBox den;
		private System.Windows.Forms.TextBox tim;
        private Button butDoi;
        //TU:01/04/2011
        public int i_idgiuong = 0;
        private TextBox txtNgayvaovien;
        private CheckBox chkKiemtraTheoMabn;
        private TextBox txtMabn_Giuong;
        private Label label10;
        private TextBox txtHoten_Giuong;
        private Label label11;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmChuyenphong(LibMedi.AccessData acc,string ngay,string makp,string tenkp,int userid)
		{
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			m=acc;s_ngay=ngay;s_makp=makp;i_userid=userid;
			this.Text=lan.Change_language_MessageText("Chuyển phòng giường khoa")+" "+tenkp.Trim();
            if (m.bBogo) tv.GanBogo(this, textBox111);
		}
        //--linh
        public frmChuyenphong(LibMedi.AccessData acc, string ngay, string makp, string tenkp, int userid, string mabn, decimal idkhoa)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChuyenphong));
            this.label1 = new System.Windows.Forms.Label();
            this.mabn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hoten = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label4 = new System.Windows.Forms.Label();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.listHoten = new LibList.List();
            this.label3 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.namsinh = new System.Windows.Forms.TextBox();
            this.giuongold = new System.Windows.Forms.TextBox();
            this.den = new MaskedBox.MaskedBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.giuongnew = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dongia = new System.Windows.Forms.TextBox();
            this.butPhong = new System.Windows.Forms.Button();
            this.tim = new System.Windows.Forms.TextBox();
            this.butDoi = new System.Windows.Forms.Button();
            this.txtNgayvaovien = new System.Windows.Forms.TextBox();
            this.chkKiemtraTheoMabn = new System.Windows.Forms.CheckBox();
            this.txtMabn_Giuong = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtHoten_Giuong = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
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
            this.mabn.Location = new System.Drawing.Point(48, 347);
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
            this.hoten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(160, 347);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(179, 21);
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
            this.madoituong.Size = new System.Drawing.Size(152, 21);
            this.madoituong.TabIndex = 5;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Location = new System.Drawing.Point(584, 346);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 23);
            this.label5.TabIndex = 28;
            this.label5.Text = "Giường :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(228, 403);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 13;
            this.butSua.Text = "&Chuyển";
            this.butSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(298, 403);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 10;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(368, 403);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 11;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(438, 403);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 14;
            this.butHuy.Text = "    &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(508, 403);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 15;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // listHoten
            // 
            this.listHoten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listHoten.BackColor = System.Drawing.SystemColors.Info;
            this.listHoten.ColumnCount = 0;
            this.listHoten.Location = new System.Drawing.Point(629, 428);
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
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(390, 347);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 23);
            this.label3.TabIndex = 74;
            this.label3.Text = "Ngày giờ vào :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tu.Enabled = false;
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(470, 347);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(112, 21);
            this.tu.TabIndex = 3;
            this.tu.Validated += new System.EventHandler(this.tu_Validated);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.Location = new System.Drawing.Point(332, 346);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 23);
            this.label6.TabIndex = 75;
            this.label6.Text = "NS :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // namsinh
            // 
            this.namsinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(360, 346);
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
            this.giuongold.Location = new System.Drawing.Point(632, 346);
            this.giuongold.Name = "giuongold";
            this.giuongold.Size = new System.Drawing.Size(72, 21);
            this.giuongold.TabIndex = 4;
            // 
            // den
            // 
            this.den.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.den.BackColor = System.Drawing.SystemColors.HighlightText;
            this.den.Enabled = false;
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(296, 370);
            this.den.Mask = "##/##/#### ##:##";
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(100, 21);
            this.den.TabIndex = 6;
            this.den.Text = "  /  /       :  ";
            this.den.Validated += new System.EventHandler(this.den_Validated);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.Location = new System.Drawing.Point(200, 370);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 23);
            this.label7.TabIndex = 79;
            this.label7.Text = "Ngày giờ chuyển :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.Location = new System.Drawing.Point(392, 370);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 23);
            this.label8.TabIndex = 80;
            this.label8.Text = "Sang giường :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // giuongnew
            // 
            this.giuongnew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.giuongnew.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giuongnew.Enabled = false;
            this.giuongnew.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giuongnew.Location = new System.Drawing.Point(470, 370);
            this.giuongnew.Name = "giuongnew";
            this.giuongnew.Size = new System.Drawing.Size(88, 21);
            this.giuongnew.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.Location = new System.Drawing.Point(576, 370);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 23);
            this.label9.TabIndex = 82;
            this.label9.Text = "Đơn giá :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dongia
            // 
            this.dongia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dongia.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dongia.Enabled = false;
            this.dongia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dongia.Location = new System.Drawing.Point(632, 370);
            this.dongia.Name = "dongia";
            this.dongia.Size = new System.Drawing.Size(72, 21);
            this.dongia.TabIndex = 9;
            this.dongia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // butPhong
            // 
            this.butPhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butPhong.Enabled = false;
            this.butPhong.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butPhong.Location = new System.Drawing.Point(560, 370);
            this.butPhong.Name = "butPhong";
            this.butPhong.Size = new System.Drawing.Size(24, 21);
            this.butPhong.TabIndex = 8;
            this.butPhong.Text = "...";
            this.butPhong.Click += new System.EventHandler(this.butPhong_Click);
            // 
            // tim
            // 
            this.tim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.ForeColor = System.Drawing.Color.Red;
            this.tim.Location = new System.Drawing.Point(462, 3);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(242, 21);
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
            this.butDoi.Location = new System.Drawing.Point(158, 403);
            this.butDoi.Name = "butDoi";
            this.butDoi.Size = new System.Drawing.Size(70, 25);
            this.butDoi.TabIndex = 84;
            this.butDoi.Text = "    &Sửa";
            this.butDoi.Click += new System.EventHandler(this.butDoi_Click);
            // 
            // txtNgayvaovien
            // 
            this.txtNgayvaovien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNgayvaovien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtNgayvaovien.Enabled = false;
            this.txtNgayvaovien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgayvaovien.Location = new System.Drawing.Point(12, 30);
            this.txtNgayvaovien.Name = "txtNgayvaovien";
            this.txtNgayvaovien.Size = new System.Drawing.Size(112, 21);
            this.txtNgayvaovien.TabIndex = 85;
            this.txtNgayvaovien.Visible = false;
            // 
            // chkKiemtraTheoMabn
            // 
            this.chkKiemtraTheoMabn.AutoSize = true;
            this.chkKiemtraTheoMabn.Location = new System.Drawing.Point(9, 8);
            this.chkKiemtraTheoMabn.Name = "chkKiemtraTheoMabn";
            this.chkKiemtraTheoMabn.Size = new System.Drawing.Size(105, 17);
            this.chkKiemtraTheoMabn.TabIndex = 86;
            this.chkKiemtraTheoMabn.Text = "Theo bệnh nhân";
            this.chkKiemtraTheoMabn.UseVisualStyleBackColor = true;
            this.chkKiemtraTheoMabn.Click += new System.EventHandler(this.chkKiemtraTheoMabn_Click);
            this.chkKiemtraTheoMabn.CheckedChanged += new System.EventHandler(this.chkKiemtraTheoMabn_CheckedChanged);
            // 
            // txtMabn_Giuong
            // 
            this.txtMabn_Giuong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtMabn_Giuong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMabn_Giuong.Location = new System.Drawing.Point(160, 3);
            this.txtMabn_Giuong.Name = "txtMabn_Giuong";
            this.txtMabn_Giuong.ReadOnly = true;
            this.txtMabn_Giuong.Size = new System.Drawing.Size(72, 21);
            this.txtMabn_Giuong.TabIndex = 87;
            this.txtMabn_Giuong.TabStop = false;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(114, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 23);
            this.label10.TabIndex = 88;
            this.label10.Text = "Mã BN :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtHoten_Giuong
            // 
            this.txtHoten_Giuong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtHoten_Giuong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoten_Giuong.Location = new System.Drawing.Point(277, 3);
            this.txtHoten_Giuong.Name = "txtHoten_Giuong";
            this.txtHoten_Giuong.ReadOnly = true;
            this.txtHoten_Giuong.Size = new System.Drawing.Size(179, 21);
            this.txtHoten_Giuong.TabIndex = 89;
            this.txtHoten_Giuong.TabStop = false;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(233, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 23);
            this.label11.TabIndex = 90;
            this.label11.Text = "Họ tên :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmChuyenphong
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(714, 447);
            this.Controls.Add(this.txtHoten_Giuong);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtMabn_Giuong);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.chkKiemtraTheoMabn);
            this.Controls.Add(this.butDoi);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.butPhong);
            this.Controls.Add(this.dongia);
            this.Controls.Add(this.giuongnew);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.den);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.giuongold);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listHoten);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.txtNgayvaovien);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmChuyenphong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyển phòng/giường";
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
            bTienGiuong_Tudong = m.bTienGiuongBHYT_TuDong; //Khuong 23/11/2011 lay option J10
            //Khuong 03/11 : neu 1 trong 2 option J05 và J05.1 được check thì bNgayra_ngayvao_1=true
            bNgayra_ngayvao_1 = m.bNgayra_ngayvao_1 || m.bNgaygiuong_tinhtheo_sangchieu;
            dtgiagiuongbhyt = m.get_data("select * from "+user+".v_giagiuongbhyt").Tables[0];
            dthoten = m.get_hiendien(s_makp, s_ngay).Tables[0];
			listHoten.DisplayMember="MABN";
			listHoten.ValueMember="HOTEN";
			listHoten.DataSource=dthoten;
            dt = m.get_data("select a.*,b.chenhlech,c.dichvu from " + user + ".dmgiuong a," + user + ".v_giavp b,"+user+".dmphong c where a.id=b.id and a.idphong=c.id").Tables[0];
            dtdt = m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a order by madoituong").Tables[0];
			madoituong.DisplayMember="DOITUONG";
			madoituong.ValueMember="MADOITUONG";
			madoituong.DataSource=dtdt;
			load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
            sql = "select loai from medibv.btdkp_bv where makp='" + s_makp + "'";
            i_loaikp = int.Parse(m.get_data(sql).Tables[0].Rows[0][0].ToString());

            chkKiemtraTheoMabn.Enabled = m.bAdminHethong(i_userid);
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
			TextCol1.HeaderText = "Giường";
			TextCol1.Width = 70;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);
            //gam 23/08/2011 
            TextCol1 = new DataGridColoredTextBoxColumn(de, 6);
            TextCol1.MappingName = "ten";
            TextCol1.HeaderText = "Tên giường";
            TextCol1.Width = 100;
            TextCol1.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 7);
			TextCol1.MappingName = "tu";
			TextCol1.HeaderText = "Từ";
			TextCol1.Width = 100;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 8);
			TextCol1.MappingName = "den";
			TextCol1.HeaderText = "Đến";
			TextCol1.Width = 100;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 8);
            TextCol1.MappingName = "tenkp";
            TextCol1.HeaderText = "Khoa - Phòng";
            TextCol1.Width = 100;
            TextCol1.ReadOnly = true;
            TextCol1.NullText = string.Empty;
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
			sql="select a.id,a.mabn,a.mavaovien,a.maql,a.idkhoa,c.hoten,c.namsinh,a.madoituong,e.doituong,f.sothe,";
            sql += "a.idgiuong,b.ma,aa.ten ||' , ' || b.ten as ten ,to_char(a.tu,'dd/mm/yyyy hh24:mi') as tu,to_char(a.den,'dd/mm/yyyy hh24:mi') as den,a.dongia,c.nam, a.makp";//gam 23/08/2011
            sql += ", g.tenkp ";
            sql += " from " + user + ".theodoigiuong a inner join " + user + ".dmgiuong b on a.idgiuong=b.id ";//gam 23/08/2011
            sql += " inner join " + user + ".dmphong aa on b.idphong=aa.id";
            sql+=" inner join " + user + ".btdbn c on a.mabn=c.mabn ";
            sql+=" inner join " + user + ".doituong e on a.madoituong=e.madoituong ";
            sql+=" left join " + user + ".bhyt f on a.maql=f.maql and (f.sudung=1 or f.sudung is null)";
            sql += " inner join medibv.btdkp_bv g on a.makp=g.makp";
			//sql+=" where (to_char(a.den,'dd/mm/yyyy')='"+s_ngay+"' or a.den is null) and a.makp='"+s_makp+"'";
            sql += " where a.den is null and a.makp='" + s_makp + "'";
			sql+=" order by a.tu";
			ds=m.get_data(sql);
			dataGrid1.DataSource=ds.Tables[0];
			ref_text();
		}

        private void load_grid_mabn(string amban, string amavaovien)
        {
            sql = "select a.id,a.mabn,a.mavaovien,a.maql,a.idkhoa,c.hoten,c.namsinh,a.madoituong,e.doituong,f.sothe,";
            sql += "a.idgiuong,b.ma,aa.ten ||' , ' || b.ten as ten ,to_char(a.tu,'dd/mm/yyyy hh24:mi') as tu,to_char(a.den,'dd/mm/yyyy hh24:mi') as den,a.dongia,c.nam, a.makp";//gam 23/08/2011
            sql += ", g.tenkp ";
            sql += " from " + user + ".theodoigiuong a inner join " + user + ".dmgiuong b on a.idgiuong=b.id ";//gam 23/08/2011
            sql += " inner join " + user + ".dmphong aa on b.idphong=aa.id";
            sql += " inner join " + user + ".btdbn c on a.mabn=c.mabn ";
            sql += " inner join " + user + ".doituong e on a.madoituong=e.madoituong ";
            sql += " left join " + user + ".bhyt f on a.maql=f.maql and (f.sudung=1 or f.sudung is null)";
            sql += " inner join medibv.btdkp_bv g on a.makp=g.makp";
            //sql+=" where (to_char(a.den,'dd/mm/yyyy')='"+s_ngay+"' or a.den is null) and a.makp='"+s_makp+"'";
            sql += " where a.mabn='" + amban + "' and a.mavaovien=" + amavaovien;
            sql += " order by to_char(a.tu,'yyyymmddhh24:mi'), a.id ";
            ds = m.get_data(sql);
            dataGrid1.DataSource = ds.Tables[0];
            //if (kiemtra_BNNgaygiuong_lientuc())
            //{
            //    MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này có ngày kết thúc khoa trước, và ngày bắt đầu giường sau không liên tục.") + "\n" + lan.Change_language_MessageText("Cần chỉnh lại ngày giờ."));
            //}
            ref_text();
        }

        private bool kiemtra_BNNgaygiuong_lientuc()
        {
            bool bln = false;
            try
            {
                string s_den_khoatruoc = "";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (s_den_khoatruoc == "") s_den_khoatruoc = dr["den"].ToString().Substring(0, 10);
                    else if (dr["tu"].ToString().Substring(0,10) == s_den_khoatruoc)
                    {
                        bln = false;
                        s_den_khoatruoc = dr["den"].ToString().Substring(0, 10);
                    }
                    else { bln = true; break; }
                }
            }
            catch { bln = false; }
            return bln;
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
                    tu.Tag = r1["tu"].ToString();
					den.Text=r1["den"].ToString();
                    den.Tag = r1["den"].ToString();
					madoituong.SelectedValue=r1["madoituong"].ToString();
					giuongold.Text=r1["ma"].ToString();
					giuongnew.Text="";
					dongia.Text=r1["dongia"].ToString();
                    nam = r1["nam"].ToString();
					bEdit=den.Text=="";
                    //
                    txtMabn_Giuong.Text = r1["mabn"].ToString();
                    txtHoten_Giuong.Text = r1["hoten"].ToString();
                    tmp_makp = r1["makp"].ToString();
                    if (chkKiemtraTheoMabn.Checked)
                    {
                        giuongnew.Text = r1["ma"].ToString();
                        giuongnew.Tag = r1["ma"].ToString();
                    }
                    else giuongnew.Text = "";
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
			madoituong.Enabled=ena;
			den.Enabled=ena;
			butPhong.Enabled=ena;
			butSua.Enabled=!ena;
            butDoi.Enabled = !ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			tim.Enabled=!ena;
            dataGrid1.Enabled = !ena;
            if (chkKiemtraTheoMabn.Checked)
            {
                tu.Enabled = ena;
                //den.Enabled = ena;
            }
            else
            {
                tu.Enabled = false ;
                //den.Enabled = false ;
            }
            chkKiemtraTheoMabn.Enabled = !ena;
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			l_maql=0;
			ena_object(true);
			mabn.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
			if (den.Text!="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Đã chuyển phòng giường không được thay đổi !"),LibMedi.AccessData.Msg);
				return;
			}
            bDoi = false;
			ena_object(true);
			if (bEdit) den.Text=m.ngayhienhanh_server;
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
            if (r == null && chkKiemtraTheoMabn.Checked ==false)
            {
                MessageBox.Show(lan.Change_language_MessageText("Người bệnh không hợp lệ !"), LibMedi.AccessData.Msg);
                mabn.Focus();
                return false;
            }
            else if (!bDoi && den.Text!="")
            {
                if (!m.bNgaygio(den.Text, tu.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày giờ chuyển không được nhỏ hơn ngày vào (" + tu.Text + ")!"), LibMedi.AccessData.Msg);
                    den.Focus();
                    return false;
                }
                if (!m.bNgaygio(den.Text,r["ngay"].ToString()))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày giờ chuyển không được nhỏ hơn ngày vào viện ("+r["ngay"].ToString()+")!"),LibMedi.AccessData.Msg);
                    den.Focus();
                    return false;
                }
            }
			if ((mabn.Text!="" && hoten.Text=="") || (mabn.Text=="" && hoten.Text!=""))
			{
				MessageBox.Show(lan.Change_language_MessageText("Họ tên người bệnh !"),LibMedi.AccessData.Msg);
				if (mabn.Text=="") mabn.Focus();
				else if (hoten.Text=="") hoten.Focus();
				return false;
			}
			if (den.Text=="" && !bDoi)
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập ngày giờ chuyển !"),LibMedi.AccessData.Msg);
				den.Focus();
				return false;
			}
			if (giuongnew.Text=="" && !bDoi)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn phòng giường chuyển !"),LibMedi.AccessData.Msg);
				butPhong.Focus();
				return false;
			}
            
			return true;
		}
		private void butLuu_Click(object sender, System.EventArgs e)
		{
            //linh 14/05/2012
			if (!kiemtra()) return;
            bool bPhongluuc = m.get_phongluu_nhapkhoa(l_maql);
			decimal songay=0;
            int _madoituong = 0,so=0;
            DataTable dtpttt = new DataTable();
            string s_ngayvao = "";
            if (i_loaikp == 4)
            {
                sql = "select to_char(ngay,'dd/mm/yyyy') as ngay from xxx.benhancc where mavaovien=" + l_mavaovien;
                s_ngayvao = m.get_data_nam(nam, sql).Tables[0].Rows[0][0].ToString();
            }
            else
            {
                sql = "select to_char(ngay,'dd/mm/yyyy') as ngay from " + user + ".benhandt where mavaovien=" + l_mavaovien;
                s_ngayvao = m.get_data(sql).Tables[0].Rows[0][0].ToString();
            }
            DataRow r2, r3 = m.getrowbyid(dt, "ma='" + giuongnew.Text + "'");
            
            int itunguyen = m.iTunguyen;
            foreach (DataRow r1 in m.get_data("select a.id,to_char(a.tu,'dd/mm/yyyy hh24:mi') as tu,a.dongia,a.idgiuong,a.madoituong,c.dichvu,d.chenhlech,b.idphong as loaiphong from " + 
                user + ".theodoigiuong a," + user + ".dmgiuong b," + user + ".dmphong c," + 
                user + ".v_giavp d where b.id=d.id and a.idgiuong=b.id and b.idphong=c.id and a.id=" + l_id).Tables[0].Rows)
            {
                if (!bDoi)
                {
                    if (r1["tu"].ToString() == den.Text.Trim())
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Không cho phép chuyển trong cùng một thời điểm!"), LibMedi.AccessData.Msg);
                        return;
                    }
                    if (!bPhongluuc)
                    {
                        bool Khoakb = m.get_data("select * from " + user + ".nhapkhoa where khoachuyen='01' and id=" + l_idkhoa).Tables[0].Rows.Count > 0;
                        if (Khoakb)
                        {
                            r2 = m.getrowbyid(dthoten, "mabn='" + mabn.Text + "'");
                            if (r2 != null) so = (Khoakb && r2["ngay"].ToString() == r1["tu"].ToString()) ? 1 : 0;
                        }
                    }
                    if (bNgayra_ngayvao_1 && madoituong_giuongdichvu != 0) _madoituong = (r1["dichvu"].ToString() == "1" && r1["chenhlech"].ToString() == "0") ? madoituong_giuongdichvu : int.Parse(r1["madoituong"].ToString());
                    songay = (bNgayra_ngayvao_1) ? m.songaygiuong(m.StringToDateTime(den.Text), m.StringToDateTime(r1["tu"].ToString()), 1, int.Parse(r1["idgiuong"].ToString())) : Math.Max(0, m.songay(m.StringToDateTime(den.Text.Substring(0, 10)), m.StringToDateTime(r1["tu"].ToString().Substring(0, 10)), so));
                    m.upd_theodoigiuong(decimal.Parse(r1["id"].ToString()), den.Text, int.Parse(r1["madoituong"].ToString()), songay);
                    //linh 16062012
                }
                else
                {
                    if (chkKiemtraTheoMabn.Checked)
                    {
                        if (chkKiemtraTheoMabn.Checked && tu.Text != tu.Tag.ToString())
                        {
                            m.execute_data("update " + user + ".theodoigiuong set tu=to_date('" + tu.Text + "','dd/mm/yyyy hh24:mi') where id=" + r1["id"].ToString() + "");
                        }
                        if (chkKiemtraTheoMabn.Checked && den.Text != den.Tag.ToString())
                        {
                            m.execute_data("update " + user + ".theodoigiuong set den=to_date('" + den.Text + "','dd/MM/yyyy hh24:mi') where id=" + r1["id"].ToString() + "");
                        }
                    }
                }
                if (r3 != null)
                {
                    try
                    {
                        m.execute_data("update " + user + ".dmgiuong set soluong=soluong-1,tinhtrang=0 where id=" + int.Parse(r1["idgiuong"].ToString())+" and soluong>0");                        
                        if (chkKiemtraTheoMabn.Checked && giuongnew.Text != giuongnew.Tag.ToString()) 
                        {
                            decimal d_DonggiaGiuong = decimal.Parse(r3[m.field_gia(madoituong.SelectedValue.ToString())].ToString());

                            m.execute_data("update " + user + ".theodoigiuong set idgiuong=" + r3["id"].ToString() + ", dongia=" + d_DonggiaGiuong + " where id=" + r1["id"].ToString() + "");
                        }
                    }
                    catch (Exception exx)
                    {
                       
                    }
                }
                break;
            }
            m.upd_eve_tables(itable, i_userid, "upd");
            m.upd_eve_upd_del(itable, i_userid, "upd", m.fields(user + ".theodoigiuong", "id=" + l_id));
            string fie = "gia_th";
            l_id = (bDoi) ? l_id : v.get_id_vpkhoa;
            _madoituong = int.Parse(madoituong.SelectedValue.ToString());
            if (r3 != null)
            {
                if (bNgayra_ngayvao_1 && madoituong_giuongdichvu != 0) _madoituong = (r3["dichvu"].ToString() == "1" && r3["chenhlech"].ToString() == "0") ? madoituong_giuongdichvu : int.Parse(madoituong.SelectedValue.ToString());

                if (_madoituong == 1 && r3["chenhlech"].ToString() == "1" && bChenhlech && r3["bhyt"].ToString() == "0") _madoituong = m.iTunguyen;
                r2 = m.getrowbyid(dtdt, "madoituong=" + _madoituong);
                if (r2 != null) fie = r2["field_gia"].ToString().Trim();
                decimal tygia = (fie.IndexOf("_nn") != -1) ? m.dTygia : 1;
                int idgiuong = int.Parse(r3["id"].ToString());
                string amakp=s_makp;
                if (chkKiemtraTheoMabn.Checked) amakp = tmp_makp;
                m.upd_theodoigiuong(l_id, amakp, mabn.Text, l_mavaovien, l_maql, l_idkhoa, _madoituong, int.Parse(r3["id"].ToString()), (bDoi) ? tu.Text : den.Text, decimal.Parse(r3[fie].ToString()) * tygia, i_userid);
                m.execute_data("update " + user + ".dmgiuong set tinhtrang=2,soluong=soluong+1 where id=" + int.Parse(r3["id"].ToString()));
                m.execute_data("update " + user + ".hiendien set idgiuong=" + idgiuong + " where id=" + l_idkhoa);
                m.upd_eve_tables(itable, i_userid, "ins");
                m.upd_eve_upd_del(itable, i_userid, "ins", m.fields(user + ".theodoigiuong", "id=" + l_id));
                if (s_makp == "99") m.execute_data("update " + user + m.mmyy(tu.Text) + ".benhancc set giuong='" + giuongnew.Text + "' where maql=" + l_maql);
                else m.execute_data("update " + user + ".nhapkhoa set giuong='" + giuongnew.Text + "' where id=" + l_idkhoa);
                i_idgiuong = idgiuong;
            }
            else if (bDoi) m.execute_data("update " + user + ".theodoigiuong set madoituong=" + _madoituong + " where id=" + l_id);
            if (chkKiemtraTheoMabn.Checked)
            {
                load_grid_mabn(txtMabn_Giuong.Text, l_mavaovien.ToString());
            }
            else { load_grid(); }
			ena_object(false);
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
            ref_text();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
            DataTable dtgiuongtrongngay = new DataTable();
			if (ds.Tables[0].Rows.Count==0) return;
			try
			{
                if (den.Text != "" && chkKiemtraTheoMabn.Checked == false)
				{
					MessageBox.Show(lan.Change_language_MessageText("Đã chuyển phòng giường không được hủy !"),LibMedi.AccessData.Msg);
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
                    string asql = "select * from " + user + ".theodoigiuong ";
                    if (chkKiemtraTheoMabn.Checked == false)
                    {
                        asql += " where idkhoa=" + l_idkhoa + " and to_char(den,'dd/mm/yyyy hh24:mi')='" + tu.Text + "' order by tungay desc";
                    }

                    else
                    {
                        asql += " where id=" + l_id;
                    }
                        dtgiuongtrongngay = m.get_data(asql).Tables[0];
                    
                    foreach (DataRow r1 in dtgiuongtrongngay.Rows)
					{
						idgiuong=int.Parse(r1["idgiuong"].ToString());
                        m.execute_data("update " + user + ".dmgiuong set tinhtrang=2,soluong=soluong+1 where id=" + idgiuong);
                        m.execute_data("update " + user + ".hiendien set idgiuong=" + idgiuong + " where id=" + l_id);
                        m.execute_data("update " + user + ".theodoigiuong set soluong=0,den=null where id=" + decimal.Parse(r1["id"].ToString()));
                        m.execute_data("delete from " + user + m.mmyy(tu.Text) + ".v_vpkhoa where idcha<>0 and idcha=" + decimal.Parse(r1["id"].ToString()));
                        m.execute_data("delete from " + user + m.mmyy(tu.Text) + ".v_vpkhoa where id=" + decimal.Parse(r1["id"].ToString()));
					}
					if (idgiuong!=0)
					{
						m.upd_eve_tables(itable,i_userid,"del");
						m.upd_eve_upd_del(itable,i_userid,"del",m.fields(user+".theodoigiuong","id="+l_id));
						DataRow r=m.getrowbyid(dt,"ma='"+giuongold.Text+"'");
                        if (r != null)
                        {
                            try
                            {
                                m.execute_data("update " + user + ".dmgiuong set tinhtrang=0,soluong=soluong-1 where id=" + int.Parse(r["id"].ToString()));
                            }
                            catch (Exception exx)
                            {
                                MessageBox.Show(exx.Message);
                                m.execute_data("update " + user + ".dmgiuong set tinhtrang=0,soluong=0 where id=" + int.Parse(r["id"].ToString()));
                            }
                        }
						r=m.getrowbyid(dt,"id="+idgiuong);
                        if (r != null) m.execute_data("update " + user + ".nhapkhoa set giuong='" + r["ma"].ToString() + "' where id=" + l_idkhoa);
                        m.execute_data("delete from " + user + ".theodoigiuong where id=" + l_id);
                        if (chkKiemtraTheoMabn.Checked == false)
                        {
                            load_grid();
                        }
                        else
                        {
                            load_grid_mabn(txtMabn_Giuong.Text, l_mavaovien.ToString());
                        }
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
				listHoten.BrowseToDanhmuc(hoten,mabn,madoituong);
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
				i_madoituong=int.Parse(r["madoituong"].ToString());
				madoituong.SelectedValue=i_madoituong.ToString();
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
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) butSua.Focus();
		}

		private void den_Validated(object sender, System.EventArgs e)
		{
			if (den.Text=="")
			{
				den.Focus();
				return;
			}
			den.Text=den.Text.Trim();
			if (den.Text.Length<16)
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày và giờ chuyển !"),LibMedi.AccessData.Msg);
				den.Focus();
				return;
			}
			if (!m.bNgay(den.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
				den.Focus();
				return;
			}
			den.Text=m.Ktngaygio(den.Text,16);
		}

		private void butPhong_Click(object sender, System.EventArgs e)
		{
			if (bEdit || chkKiemtraTheoMabn.Checked)
			{
                string amakp = s_makp;
                if (chkKiemtraTheoMabn.Checked) amakp = tmp_makp;
				frmDsgiuong f=new frmDsgiuong(m,amakp,int.Parse(madoituong.SelectedValue.ToString()));
				f.ShowDialog();
				if (f.ma!="")
				{
					giuongnew.Text=f.ma;
					string fie="gia_th";
					DataRow r1=m.getrowbyid(dtdt,"madoitong="+int.Parse(madoituong.SelectedValue.ToString()));
					if (r1!=null) fie=r1["field_gia"].ToString().Trim();
					r1=m.getrowbyid(dt,"ma='"+giuongnew.Text+"'");
					if (r1!=null) dongia.Text=r1[fie].ToString();
					butLuu.Focus();
				}
			}
		}

        private void butDoi_Click(object sender, EventArgs e)
        {
            bDoi = true;
            if (ds.Tables[0].Rows.Count == 0) return;
            if (den.Text != "" && chkKiemtraTheoMabn.Checked ==false)
            {
                MessageBox.Show(lan.Change_language_MessageText("Đã chuyển phòng giường không được thay đổi !"), LibMedi.AccessData.Msg);
                return;
            }
            ena_object(true);
            den.Enabled = (chkKiemtraTheoMabn.Checked) ? den.Enabled : false;
            //madoituong.Enabled = false;
            butPhong.Focus();
        }

        private void chkKiemtraTheoMabn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkKiemtraTheoMabn_Click(object sender, EventArgs e)
        {
            if (chkKiemtraTheoMabn.Checked)
            {
                load_grid_mabn(txtMabn_Giuong.Text, l_mavaovien.ToString());
            }
            else
            {
                load_grid ();
            }
        }

        private void tu_Validated(object sender, EventArgs e)
        {
            if (tu.Text == "")
            {
                tu.Focus();
                return;
            }
            tu.Text = tu.Text.Trim();
            if (tu.Text.Length < 16)
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập đúng Ngày và giờ bắt đầu tính giường!"), LibMedi.AccessData.Msg);
                tu.Focus();
                return;
            }
            if (!m.bNgay(tu.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
                tu.Focus();
                return;
            }
            tu.Text = m.Ktngaygio(tu.Text, 16);
        }
	}
}
