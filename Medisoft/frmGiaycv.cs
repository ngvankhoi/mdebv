using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
 
namespace Medisoft
{
	public class frmGiaycv : System.Windows.Forms.Form
    {
        #region Khai bao
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();
        private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox namsinh;
		private System.Windows.Forms.TextBox ngayra;
		private System.Windows.Forms.TextBox tenkp;
		private System.Windows.Forms.TextBox diachi;
		private System.Windows.Forms.Button butTiep;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butExit;
        private LibDuoc.AccessData d = new LibDuoc.AccessData();
		private DataSet ds=new DataSet();
		private DataSet dsngay=new DataSet();
		private DataSet dsxml=new DataSet();
		private DataTable dt=new DataTable();
		private AccessData m;
        private decimal l_maql;
		private int i_userid,soluongle;
        private string s_makp, sql, s_ngayvao, nam, ngaysrv, s_sochuyenvien="";
		private Brush disabledBackBrush;
		private Brush disabledTextBrush;
		private Brush alertBackBrush;
		private Font alertFont;
		private Brush alertTextBrush;
		private Font currentRowFont;
		private Brush currentRowBackBrush;
		bool afterCurrentCellChanged;
		int checkCol=0;
        private string user;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.TextBox sothe;
		private System.Windows.Forms.TextBox makp;
		private System.Windows.Forms.ComboBox ngayvao;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox lamsang;
        private System.Windows.Forms.TextBox chandoan;
		private System.Windows.Forms.TextBox nguoidua;
		private System.Windows.Forms.TextBox vanchuyen;
		private MaskedBox.MaskedBox gio;
		private MaskedBox.MaskedBox ngay;
		private System.Windows.Forms.Label label88;
		private System.Windows.Forms.TextBox lydo;
		private System.Windows.Forms.TextBox tinhtrang;
        private RichTextBox thuoc;
        private ComboBox loaibn;
        private Label label36;
        private DataSet dsloaibn = new DataSet();
        private string s_mabn = "",s_tuoivao = "";
        private int i_loai;
        private CheckBox chkXml;
        private RichTextBox xn;
        private TextBox sochuyenvien;
        private Label label14;
        private bool bSochuyenvien_tudong = true, bKhongSuaChanDoan = false;
        private CheckBox chkyeucau;
        private CheckBox chkduyet;
		private System.ComponentModel.Container components = null;
        protected GroupBox danhsach;
        protected AsYetUnnamed.MultiColumnListBox list;
        protected TextBox tim;
        protected Button butRef;
        private Label label19;
        private TextBox soluutru;
        //Tu:08/08/2011 enable nút in 
        private int i_ngoaidm = 0;
        #endregion

        public frmGiaycv(AccessData acc,string makp,int userid,string _mabn,int _loai)
		{
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; s_makp = makp; i_userid = userid; s_mabn = _mabn; i_loai = _loai;
            if (m.bBogo) tv.GanBogo(this, textBox111);
		}
        //Tu:20/06/2011
        public frmGiaycv(AccessData acc, string makp, int userid, string _mabn, int _loai,int _cungtuyen)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; s_makp = makp; i_userid = userid; s_mabn = _mabn; i_loai = _loai;
            if (m.bBogo) tv.GanBogo(this, textBox111);
            i_ngoaidm = _cungtuyen;
        }
        //end Tu

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
					if(disabledBackBrush != null)
					{
						disabledBackBrush.Dispose();
						disabledTextBrush.Dispose();
						alertBackBrush.Dispose();
						alertFont.Dispose();
						alertTextBrush.Dispose();
						currentRowFont.Dispose();
						currentRowBackBrush.Dispose();
					}
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGiaycv));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.mabn = new System.Windows.Forms.TextBox();
            this.hoten = new System.Windows.Forms.TextBox();
            this.namsinh = new System.Windows.Forms.TextBox();
            this.ngayra = new System.Windows.Forms.TextBox();
            this.tenkp = new System.Windows.Forms.TextBox();
            this.diachi = new System.Windows.Forms.TextBox();
            this.sothe = new System.Windows.Forms.TextBox();
            this.butTiep = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butExit = new System.Windows.Forms.Button();
            this.makp = new System.Windows.Forms.TextBox();
            this.ngayvao = new System.Windows.Forms.ComboBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lamsang = new System.Windows.Forms.TextBox();
            this.chandoan = new System.Windows.Forms.TextBox();
            this.nguoidua = new System.Windows.Forms.TextBox();
            this.vanchuyen = new System.Windows.Forms.TextBox();
            this.gio = new MaskedBox.MaskedBox();
            this.ngay = new MaskedBox.MaskedBox();
            this.label88 = new System.Windows.Forms.Label();
            this.lydo = new System.Windows.Forms.TextBox();
            this.tinhtrang = new System.Windows.Forms.TextBox();
            this.thuoc = new System.Windows.Forms.RichTextBox();
            this.loaibn = new System.Windows.Forms.ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.chkXml = new System.Windows.Forms.CheckBox();
            this.xn = new System.Windows.Forms.RichTextBox();
            this.sochuyenvien = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.chkyeucau = new System.Windows.Forms.CheckBox();
            this.chkduyet = new System.Windows.Forms.CheckBox();
            this.danhsach = new System.Windows.Forms.GroupBox();
            this.tim = new System.Windows.Forms.TextBox();
            this.butRef = new System.Windows.Forms.Button();
            this.list = new AsYetUnnamed.MultiColumnListBox();
            this.label19 = new System.Windows.Forms.Label();
            this.soluutru = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.danhsach.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(184, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(300, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(478, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 22;
            this.label3.Text = "NS :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(2, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ngày vào :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(167, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 23);
            this.label5.TabIndex = 26;
            this.label5.Text = "Ngày ra :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(319, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 23);
            this.label6.TabIndex = 28;
            this.label6.Text = "Khoa / phòng :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(572, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 23);
            this.label7.TabIndex = 31;
            this.label7.Text = "Số thẻ :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(572, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 23);
            this.label8.TabIndex = 24;
            this.label8.Text = "Địa chỉ :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(233, 8);
            this.mabn.MaxLength = 10;
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(71, 21);
            this.mabn.TabIndex = 1;
            this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
            this.mabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(345, 8);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(169, 21);
            this.hoten.TabIndex = 2;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(538, 9);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(36, 21);
            this.namsinh.TabIndex = 3;
            // 
            // ngayra
            // 
            this.ngayra.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayra.Enabled = false;
            this.ngayra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayra.Location = new System.Drawing.Point(233, 31);
            this.ngayra.Name = "ngayra";
            this.ngayra.Size = new System.Drawing.Size(95, 21);
            this.ngayra.TabIndex = 6;
            // 
            // tenkp
            // 
            this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkp.Enabled = false;
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(404, 31);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(170, 21);
            this.tenkp.TabIndex = 7;
            // 
            // diachi
            // 
            this.diachi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(619, 9);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(165, 21);
            this.diachi.TabIndex = 4;
            // 
            // sothe
            // 
            this.sothe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(619, 31);
            this.sothe.MaxLength = 16;
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(164, 21);
            this.sothe.TabIndex = 8;
            // 
            // butTiep
            // 
            this.butTiep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTiep.Image = ((System.Drawing.Image)(resources.GetObject("butTiep.Image")));
            this.butTiep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTiep.Location = new System.Drawing.Point(179, 493);
            this.butTiep.Name = "butTiep";
            this.butTiep.Size = new System.Drawing.Size(70, 25);
            this.butTiep.TabIndex = 22;
            this.butTiep.Text = "    &Tiếp";
            this.butTiep.Click += new System.EventHandler(this.butTiep_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(249, 493);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 21;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(319, 493);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 23;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(459, 493);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 26;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(389, 493);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 24;
            this.butIn.Text = "    &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butExit
            // 
            this.butExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butExit.Image = ((System.Drawing.Image)(resources.GetObject("butExit.Image")));
            this.butExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExit.Location = new System.Drawing.Point(529, 493);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(70, 25);
            this.butExit.TabIndex = 25;
            this.butExit.Text = "&Kết thúc";
            this.butExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.Enabled = false;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(121, 531);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(24, 21);
            this.makp.TabIndex = 29;
            this.makp.Visible = false;
            // 
            // ngayvao
            // 
            this.ngayvao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ngayvao.Enabled = false;
            this.ngayvao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvao.Location = new System.Drawing.Point(65, 31);
            this.ngayvao.Name = "ngayvao";
            this.ngayvao.Size = new System.Drawing.Size(112, 21);
            this.ngayvao.TabIndex = 5;
            this.ngayvao.SelectedIndexChanged += new System.EventHandler(this.ngayvao_SelectedIndexChanged);
            this.ngayvao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngayvao_KeyDown);
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(12, 40);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.Size = new System.Drawing.Size(164, 448);
            this.dataGrid1.TabIndex = 33;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(184, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 23);
            this.label9.TabIndex = 34;
            this.label9.Text = "- Dấu hiệu lâm sàng :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(184, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 23);
            this.label10.TabIndex = 35;
            this.label10.Text = "- Các xét nghiệm :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(184, 194);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 23);
            this.label11.TabIndex = 36;
            this.label11.Text = "- Chẩn đoán :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(184, 242);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 23);
            this.label12.TabIndex = 37;
            this.label12.Text = "- Thuốc đã dùng :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.Location = new System.Drawing.Point(184, 343);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(232, 23);
            this.label13.TabIndex = 38;
            this.label13.Text = "- Tình trạng người bệnh lúc chuyển viện :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.Location = new System.Drawing.Point(184, 367);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(136, 23);
            this.label15.TabIndex = 39;
            this.label15.Text = "- Lý do chuyển viện :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.Location = new System.Drawing.Point(184, 389);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(136, 23);
            this.label16.TabIndex = 40;
            this.label16.Text = "- Chuyển viện hồi :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.Location = new System.Drawing.Point(184, 439);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(160, 23);
            this.label17.TabIndex = 41;
            this.label17.Text = "- Phương tiện vận chuyển :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label18.Location = new System.Drawing.Point(184, 463);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(192, 23);
            this.label18.TabIndex = 42;
            this.label18.Text = "- Họ tên, chức danh người đưa đi :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lamsang
            // 
            this.lamsang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lamsang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lamsang.Enabled = false;
            this.lamsang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lamsang.Location = new System.Drawing.Point(288, 55);
            this.lamsang.Multiline = true;
            this.lamsang.Name = "lamsang";
            this.lamsang.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.lamsang.Size = new System.Drawing.Size(496, 44);
            this.lamsang.TabIndex = 9;
            // 
            // chandoan
            // 
            this.chandoan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(288, 197);
            this.chandoan.Multiline = true;
            this.chandoan.Name = "chandoan";
            this.chandoan.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.chandoan.Size = new System.Drawing.Size(496, 45);
            this.chandoan.TabIndex = 11;
            this.chandoan.TextChanged += new System.EventHandler(this.chandoan_TextChanged);
            // 
            // nguoidua
            // 
            this.nguoidua.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nguoidua.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nguoidua.Enabled = false;
            this.nguoidua.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nguoidua.Location = new System.Drawing.Point(384, 464);
            this.nguoidua.Name = "nguoidua";
            this.nguoidua.Size = new System.Drawing.Size(401, 21);
            this.nguoidua.TabIndex = 20;
            this.nguoidua.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // vanchuyen
            // 
            this.vanchuyen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.vanchuyen.BackColor = System.Drawing.SystemColors.HighlightText;
            this.vanchuyen.Enabled = false;
            this.vanchuyen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vanchuyen.Location = new System.Drawing.Point(384, 441);
            this.vanchuyen.Name = "vanchuyen";
            this.vanchuyen.Size = new System.Drawing.Size(401, 21);
            this.vanchuyen.TabIndex = 19;
            this.vanchuyen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // gio
            // 
            this.gio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gio.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gio.Enabled = false;
            this.gio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gio.Location = new System.Drawing.Point(500, 393);
            this.gio.Mask = "##:##";
            this.gio.Name = "gio";
            this.gio.Size = new System.Drawing.Size(40, 21);
            this.gio.TabIndex = 16;
            this.gio.Text = "  :  ";
            this.gio.Validated += new System.EventHandler(this.gio_Validated);
            // 
            // ngay
            // 
            this.ngay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay.Enabled = false;
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Location = new System.Drawing.Point(384, 393);
            this.ngay.Mask = "##/##/####";
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(72, 21);
            this.ngay.TabIndex = 15;
            this.ngay.Text = "  /  /    ";
            this.ngay.Validated += new System.EventHandler(this.ngay_Validated);
            // 
            // label88
            // 
            this.label88.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label88.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label88.Location = new System.Drawing.Point(472, 395);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(32, 16);
            this.label88.TabIndex = 43;
            this.label88.Text = "Giờ :";
            this.label88.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lydo
            // 
            this.lydo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lydo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lydo.Enabled = false;
            this.lydo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lydo.Location = new System.Drawing.Point(384, 370);
            this.lydo.Name = "lydo";
            this.lydo.Size = new System.Drawing.Size(401, 21);
            this.lydo.TabIndex = 14;
            this.lydo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // tinhtrang
            // 
            this.tinhtrang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tinhtrang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tinhtrang.Enabled = false;
            this.tinhtrang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tinhtrang.Location = new System.Drawing.Point(384, 347);
            this.tinhtrang.Name = "tinhtrang";
            this.tinhtrang.Size = new System.Drawing.Size(400, 21);
            this.tinhtrang.TabIndex = 13;
            this.tinhtrang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // thuoc
            // 
            this.thuoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.thuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thuoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thuoc.Enabled = false;
            this.thuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thuoc.Location = new System.Drawing.Point(288, 243);
            this.thuoc.Name = "thuoc";
            this.thuoc.Size = new System.Drawing.Size(497, 98);
            this.thuoc.TabIndex = 12;
            this.thuoc.Text = "";
            // 
            // loaibn
            // 
            this.loaibn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaibn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loaibn.Enabled = false;
            this.loaibn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaibn.Location = new System.Drawing.Point(65, 8);
            this.loaibn.Name = "loaibn";
            this.loaibn.Size = new System.Drawing.Size(111, 21);
            this.loaibn.TabIndex = 0;
            this.loaibn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngayvao_KeyDown);
            // 
            // label36
            // 
            this.label36.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label36.Location = new System.Drawing.Point(-6, 6);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(72, 23);
            this.label36.TabIndex = 72;
            this.label36.Text = "Người bệnh :";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkXml
            // 
            this.chkXml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkXml.AutoSize = true;
            this.chkXml.Location = new System.Drawing.Point(688, 488);
            this.chkXml.Name = "chkXml";
            this.chkXml.Size = new System.Drawing.Size(85, 17);
            this.chkXml.TabIndex = 73;
            this.chkXml.Text = "Xuất ra XML";
            this.chkXml.UseVisualStyleBackColor = true;
            // 
            // xn
            // 
            this.xn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.xn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xn.Enabled = false;
            this.xn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xn.Location = new System.Drawing.Point(288, 100);
            this.xn.Name = "xn";
            this.xn.Size = new System.Drawing.Size(497, 95);
            this.xn.TabIndex = 10;
            this.xn.Text = "";
            // 
            // sochuyenvien
            // 
            this.sochuyenvien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sochuyenvien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sochuyenvien.Enabled = false;
            this.sochuyenvien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sochuyenvien.Location = new System.Drawing.Point(644, 417);
            this.sochuyenvien.MaxLength = 8;
            this.sochuyenvien.Name = "sochuyenvien";
            this.sochuyenvien.Size = new System.Drawing.Size(141, 21);
            this.sochuyenvien.TabIndex = 18;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.Location = new System.Drawing.Point(541, 415);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(102, 23);
            this.label14.TabIndex = 74;
            this.label14.Text = "Số chuyển viện :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkyeucau
            // 
            this.chkyeucau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkyeucau.AutoSize = true;
            this.chkyeucau.Location = new System.Drawing.Point(688, 508);
            this.chkyeucau.Name = "chkyeucau";
            this.chkyeucau.Size = new System.Drawing.Size(92, 17);
            this.chkyeucau.TabIndex = 75;
            this.chkyeucau.Text = "Theo yêu cầu";
            this.chkyeucau.UseVisualStyleBackColor = true;
            // 
            // chkduyet
            // 
            this.chkduyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkduyet.AutoSize = true;
            this.chkduyet.Location = new System.Drawing.Point(688, 531);
            this.chkduyet.Name = "chkduyet";
            this.chkduyet.Size = new System.Drawing.Size(101, 17);
            this.chkduyet.TabIndex = 76;
            this.chkduyet.Text = "Giám đốc duyệt";
            this.chkduyet.UseVisualStyleBackColor = true;
            this.chkduyet.Visible = false;
            // 
            // danhsach
            // 
            this.danhsach.Controls.Add(this.tim);
            this.danhsach.Controls.Add(this.butRef);
            this.danhsach.Controls.Add(this.list);
            this.danhsach.Location = new System.Drawing.Point(12, 508);
            this.danhsach.Name = "danhsach";
            this.danhsach.Size = new System.Drawing.Size(103, 53);
            this.danhsach.TabIndex = 77;
            this.danhsach.TabStop = false;
            this.danhsach.Text = "DANH SÁCH CHỜ DUYỆT CHUYỂN VIỆN";
            this.danhsach.Visible = false;
            // 
            // tim
            // 
            this.tim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tim.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.ForeColor = System.Drawing.Color.Red;
            this.tim.Location = new System.Drawing.Point(0, 16);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(82, 21);
            this.tim.TabIndex = 0;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // butRef
            // 
            this.butRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butRef.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butRef.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butRef.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butRef.Location = new System.Drawing.Point(81, 16);
            this.butRef.Name = "butRef";
            this.butRef.Size = new System.Drawing.Size(22, 21);
            this.butRef.TabIndex = 1;
            this.butRef.Text = "...";
            // 
            // list
            // 
            this.list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.list.ColumnCount = 0;
            this.list.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list.Location = new System.Drawing.Point(0, 37);
            this.list.MatchBufferTimeOut = 1000;
            this.list.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(103, 17);
            this.list.TabIndex = 1;
            this.list.TextIndex = -1;
            this.list.TextMember = null;
            this.list.ValueIndex = -1;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label19.Location = new System.Drawing.Point(184, 415);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(136, 23);
            this.label19.TabIndex = 78;
            this.label19.Text = "- Số lưu trữ :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // soluutru
            // 
            this.soluutru.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.soluutru.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluutru.Enabled = false;
            this.soluutru.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluutru.Location = new System.Drawing.Point(384, 417);
            this.soluutru.MaxLength = 8;
            this.soluutru.Name = "soluutru";
            this.soluutru.Size = new System.Drawing.Size(156, 21);
            this.soluutru.TabIndex = 17;
            this.soluutru.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sovaovien_KeyDown);
            // 
            // frmGiaycv
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.soluutru);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.danhsach);
            this.Controls.Add(this.chkduyet);
            this.Controls.Add(this.chkyeucau);
            this.Controls.Add(this.sochuyenvien);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.xn);
            this.Controls.Add(this.chkXml);
            this.Controls.Add(this.loaibn);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.thuoc);
            this.Controls.Add(this.tinhtrang);
            this.Controls.Add(this.lydo);
            this.Controls.Add(this.gio);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.label88);
            this.Controls.Add(this.vanchuyen);
            this.Controls.Add(this.nguoidua);
            this.Controls.Add(this.chandoan);
            this.Controls.Add(this.lamsang);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ngayvao);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butTiep);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.tenkp);
            this.Controls.Add(this.ngayra);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGiaycv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In giấy chuyển viện";
            this.Load += new System.EventHandler(this.frmGiaycv_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.danhsach.ResumeLayout(false);
            this.danhsach.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmGiaycv_Load(object sender, System.EventArgs e)
		{
            if (s_mabn == "") this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ngaysrv = m.ngayhienhanh_server.Substring(0, 10);
            user = m.user;
            bKhongSuaChanDoan = m.bKhongsuachandoantrongingiaychuyenvien_I11;
            //
            capnhat_cautruc_chuyenvien();//
            bSochuyenvien_tudong = m.bSochuyenvien_tudong;
            //
            dsloaibn.ReadXml("..//..//..//xml//m_loaibn.xml");
            m.delrec(dsloaibn.Tables[0], "id=4");
			//dsngay.ReadXml("..//..//..//xml//m_giaycv.xml");			
			dsxml.ReadXml("..//..//..//xml//m_giaycv.xml");
            //ds.ReadXml("..//..//..//xml//m_giaycv.xml");
            dsxml.Tables[0].Columns.Add("loaibn", typeof(decimal));
            dsxml.Tables[0].Columns.Add("lanin", typeof(decimal));
            dsxml.Tables[0].Columns.Add("sochuyenvien");
            dsxml.Tables[0].Columns.Add("tungay");
            dsxml.Tables[0].Columns.Add("yeucau", typeof(decimal)).DefaultValue = 0;
            dsxml.Tables[0].Columns.Add("daduyet", typeof(decimal)).DefaultValue = 0;//Tu:06/06/2011
            try { dsxml.Tables[0].Columns.Add("soluutru"); }
            catch { }
            dsxml.Tables[0].Columns.Add("tuoivao");
            dsxml.Tables[0].Columns.Add("ngaysinh");
            dsxml.Tables[0].Columns.Add("thangtuoi");

            dsngay = dsxml.Copy();
            ds = dsxml.Copy();            
			ds.Tables[0].Columns.Add("chon",typeof(bool));
            //ds.Tables[0].Columns.Add("loaibn", typeof(decimal));
            //ds.Tables[0].Columns.Add("lanin", typeof(decimal));
            //ds.Tables[0].Columns.Add("sochuyenvien", typeof(decimal));
            //dsngay.Tables[0].Columns.Add("loaibn", typeof(decimal));
            //dsngay.Tables[0].Columns.Add("lanin", typeof(decimal));
            //
            ngayvao.DisplayMember = "NGAYVAO";
            ngayvao.ValueMember = "NGAYVAO";
            ngayvao.DataSource = dsngay.Tables[0];
            //
			dataGrid1.DataSource=ds.Tables[0];
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

			this.disabledBackBrush = new SolidBrush(Color.FromArgb(255,255,192));//SystemColors.Info
			//this.disabledTextBrush = new SolidBrush(SystemColors.GrayText);
			this.disabledTextBrush = new SolidBrush(Color.FromArgb(255,0,0));

			this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
			this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
			this.alertTextBrush = new SolidBrush(Color.White);
			
			this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
			this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0,255, 255));

            loaibn.DisplayMember = "TEN";
            loaibn.ValueMember = "ID";
            loaibn.DataSource = dsloaibn.Tables[0];
            soluongle = d.d_soluong_le(m.nhom_duoc);
            nam = m.mmyy(ngaysrv) + "+";
            if (s_mabn != "")
            {
                loaibn.SelectedIndex = i_loai;
                load_data("", 3,0);
                butTiep_Click(sender, e);
            }
            else for (int i = 0; i < 4; i++) load_data("", i,0);

            //Tu:06/06/2011
            //try { string s_daduyet = m.get_data("select daduyet,userid_duyet from " + user + ".chuyenvien where 1=0").Tables[0].Columns["daduyet"].ToString(); }
            //catch
            //{
            //    m.execute_data("alter table " + user + ".chuyenvien add daduyet numeric(1) default 0");
            //    m.execute_data("alter table " + user + ".chuyenvien add userid_duyet numeric(5) default 0");
            //}

            //int i_duyetcv = 0;
            //try { i_duyetcv = int.Parse(m.get_data("select duyetcv from " + user + ".dlogin where id=" + i_userid + "").Tables[0].Rows[0][0].ToString()); }
            //catch { i_duyetcv = 0; }
            //if (i_duyetcv==1)
            //    chkduyet.Visible = true;
            //end Tu
		}

        private void mabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void mabn_Validated(object sender, System.EventArgs e)
		{
			hoten.Text="";dsngay.Clear();
			l_maql=0;
			if (mabn.Text=="" || mabn.Text.Trim().Length<3) return;
			if (mabn.Text.Trim().Length!=8) mabn.Text=mabn.Text.Substring(0,2)+mabn.Text.Substring(2).PadLeft(6,'0');
            nam = "";
            if (loaibn.SelectedIndex > 1)
            {
                foreach (DataRow r in m.get_data("select nam from " + user + ".btdbn where mabn='" + mabn.Text + "'").Tables[0].Rows)
                    nam = r["nam"].ToString().Trim();
            }
            if (loaibn.SelectedIndex > 1 && nam == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy !"), LibMedi.AccessData.Msg);
                return;
            }
            load_data(mabn.Text,loaibn.SelectedIndex,0);
            if (l_maql == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Người bệnh này chưa hoàn tất thủ tục !"), LibMedi.AccessData.Msg);
                mabn.Focus();
            }
            else
            {//Khuong 05/11/2011
                try
                {
                    if (dsngay.Tables[0].Rows.Count > 0)
                    {
                        ngayvao.SelectedIndex = 0;
                        ngayvao_SelectedIndexChanged(null, null);
                    }
                }
                catch
                {
                    ngayvao.SelectedValue = s_ngayvao;
                }
            }
		}

        private void load_data(string ma,int loai,decimal maql)
        {
            string s = "";
            string s_chandoan = "", s_maicd = "", xxx = "";
            int i = 0;
            if (loai == 0)
            {
                sql = "select distinct a.mabn,c.hoten,c.namsinh,c.sonha,c.thon,c.phai,a.maql,c.cholam,k.tenbv,";
                sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngayvao,to_char(b.ngay,'dd/mm/yyyy hh24:mi') ngayra,";
                sql += "b.makp,d.tenkp,e.tennn,f.dantoc,g.tentt,l.sothe,to_char(l.denngay,'dd/mm/yyyy') as denngay,gg.hoten as tenbs,hh.doituong,";
                sql += "h.tenquan,i.tenpxa,case when j.chandoan is null then b.chandoan else j.chandoan end as chandoan,b.maicd,";
                sql += "x.tenbv as noigioithieu,y.tenbv as noidkkcb,";
                sql += "j.lamsang,j.xn,j.thuoc,j.tinhtrang,j.lydo,case when j.ngay is null then to_char(b.ngay,'dd/mm/yyyy hh24:mi') else to_char(j.ngay,'dd/mm/yyyy hh24:mi') end as ngay,j.vanchuyen,j.nguoidua,j.lanin, j.sochuyenvien ";
                sql += ", to_char(l.tungay,'dd/mm/yyyy') as tungay, j.yeucau, a.sovaovien, b.soluutru,j.daduyet ";
                sql += " ,substr(b1.tuoivao,1,3)||case when substr(b1.tuoivao,4,1)=0 then 'Tuổi' else case when substr(b1.tuoivao,4,1)=1 then 'Tháng' else case when substr(b1.tuoivao,4,1)=2 then 'Ngày' else 'Giờ' end end end as tuoivao,to_char(c.ngaysinh,'dd/mm/yyyy') as ngaysinh ";
                sql += " from " + user + ".benhandt a inner join " + user + ".xuatvien b on a.maql=b.maql ";
                sql += " inner join "+user+".nhapkhoa b1 on a.maql=b1.maql ";
                sql += " inner join " + user + ".btdbn c on a.mabn=c.mabn ";
                sql += " inner join " + user + ".btdkp_bv d on b.makp=d.makp ";
                sql += " inner join " + user + ".btdnn_bv e on c.mann=e.mann ";
                sql += " inner join " + user + ".btddt f on c.madantoc=f.madantoc ";
                sql += " left join " + user + ".btdtt g on c.matt=g.matt ";
                sql += " left join " + user + ".btdquan h on c.maqu=h.maqu ";
                sql += " left join " + user + ".btdpxa i on c.maphuongxa=i.maphuongxa ";
                sql += " inner join " + user + ".chuyenvien j on b.maql=j.maql ";
                sql += " left join " + user + ".tenvien k on j.mabv=k.mabv ";
                sql += " left join " + user + ".bhyt l on b.maql=l.maql ";
                sql += " left join " + user + ".dmbs gg on b.mabs=gg.ma ";
                sql += " inner join " + user + ".doituong hh on a.madoituong=hh.madoituong ";
                sql += " left join " + user + ".noigioithieu z on a.maql=z.maql ";
                sql += " left join " + user + ".dstt x on z.mabv=x.mabv ";
                sql += " left join " + user + ".dmnoicapbhyt y on l.mabv=y.mabv ";
                sql += " where a.loaiba=1";
                if (s_makp != "")
                {
                    s = s_makp.Replace(",", "','");
                    sql += " and b.makp in ('" + s.Substring(0, s.Length - 3) + "')";
                }
                if (ma != "") sql += " and a.mabn='" + ma + "'";
                else sql += " and to_char(j.ngayud,'dd/mm/yyyy')='" + ngaysrv + "'";
                if (maql != 0) sql += " and j.maql=" + maql;
                if (s_mabn != "") sql += " and a.mabn='" + s_mabn + "'";
                sql += " order by a.maql desc";
            }
            else if (loai == 1)
            {
                sql = "select a.mabn,c.hoten,c.namsinh,c.sonha,c.thon,c.phai,a.maql,c.cholam,k.tenbv,";
                sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngayvao,to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') ngayra,";
                sql += "a.makp,d.tenkp,e.tennn,f.dantoc,g.tentt,l.sothe,to_char(l.denngay,'dd/mm/yyyy') as denngay,gg.hoten as tenbs,hh.doituong,";
                sql += "h.tenquan,i.tenpxa,case when j.chandoan is null then a.chandoanrv else j.chandoan end as chandoan,a.maicdrv as maicd,";
                sql += "x.tenbv as noigioithieu,y.tenbv as noidkkcb,";
                sql += "j.lamsang,j.xn,j.thuoc,j.tinhtrang,j.lydo,case when j.ngay is null then to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') else to_char(j.ngay,'dd/mm/yyyy hh24:mi') end as ngay,j.vanchuyen,j.nguoidua,j.lanin, j.sochuyenvien ";
                sql += ", to_char(l.tungay,'dd/mm/yyyy') as tungay, j.yeucau, a.sovaovien, lh.soluutru,j.daduyet ";
                sql += " ,substr(lh.tuoivao,1,3)||case when substr(lh.tuoivao,4,1)=0 then 'Tuổi' else case when substr(lh.tuoivao,4,1)=1 then 'Tháng' else case when substr(lh.tuoivao,4,1)=2 then 'Ngày' else 'Giờ' end end end as tuoivao,to_char(c.ngaysinh,'dd/mm/yyyy') as ngaysinh ";
                sql += " from " + user + ".benhanngtr a inner join " + user + ".btdbn c on a.mabn=c.mabn ";
                sql += " inner join " + user + ".btdkp_bv d on a.makp=d.makp ";
                sql += " inner join " + user + ".btdnn_bv e on c.mann=e.mann ";
                sql += " inner join " + user + ".btddt f on c.madantoc=f.madantoc ";
                sql += " left join " + user + ".btdtt g on c.matt=g.matt ";
                sql += " left join " + user + ".btdquan h on c.maqu=h.maqu ";
                sql += " left join " + user + ".btdpxa i on c.maphuongxa=i.maphuongxa ";
                sql += " inner join " + user + ".chuyenvien j on a.maql=j.maql ";
                sql += " left join " + user + ".tenvien k on j.mabv=k.mabv ";
                sql += " left join " + user + ".bhyt l on a.maql=l.maql ";
                sql += " left join " + user + ".dmbs gg on a.mabs=gg.ma ";
                sql += " inner join " + user + ".doituong hh on a.madoituong=hh.madoituong ";
                sql += " left join " + user + ".noigioithieu z on a.maql=z.maql ";
                sql += " left join " + user + ".dstt x on z.mabv=x.mabv ";
                sql += " left join " + user + ".dmnoicapbhyt y on l.mabv=y.mabv ";
                sql += " left join " + user + ".lienhe lh on a.maql=lh.maql ";
                sql += " where true";
                if (s_makp != "")
                {
                    s = s_makp.Replace(",", "','");
                    sql += " and a.makp in ('" + s.Substring(0, s.Length - 3) + "')";
                }
                if (ma != "") sql += " and a.mabn='" + ma + "'";
                else sql += " and to_char(j.ngayud,'dd/mm/yyyy')='" + ngaysrv + "'";
                if (maql != 0) sql += " and j.maql=" + maql;
                if (s_mabn != "") sql += " and a.mabn='" + s_mabn + "'";
                sql += " order by a.maql desc";
            }
            else if (loai == 2)
            {
                sql = "select a.mabn,c.hoten,c.namsinh,c.sonha,c.thon,c.phai,a.maql,c.cholam,k.tenbv,";
                sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngayvao,to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') ngayra,";
                sql += "a.makp,d.tenkp,e.tennn,f.dantoc,g.tentt,l.sothe,to_char(l.denngay,'dd/mm/yyyy') as denngay,gg.hoten as tenbs,hh.doituong,";
                sql += "h.tenquan,i.tenpxa,case when j.chandoan is null then a.chandoanrv else j.chandoan end as chandoan,a.maicdrv as maicd,";
                sql += "x.tenbv as noigioithieu,y.tenbv as noidkkcb,";
                sql += "j.lamsang,j.xn,j.thuoc,j.tinhtrang,j.lydo,case when j.ngay is null then to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') else to_char(j.ngay,'dd/mm/yyyy hh24:mi') end as ngay,j.vanchuyen,j.nguoidua,j.lanin, j.sochuyenvien ";
                sql += ", to_char(l.tungay,'dd/mm/yyyy') as tungay, j.yeucau, a.sovaovien, lh.soluutru,j.daduyet ";
                sql += " ,substr(lh.tuoivao,1,3)||case when substr(lh.tuoivao,4,1)=0 then 'Tuổi' else case when substr(lh.tuoivao,4,1)=1 then 'Tháng' else case when substr(lh.tuoivao,4,1)=2 then 'Ngày' else 'Giờ' end end end as tuoivao,to_char(c.ngaysinh,'dd/mm/yyyy') as ngaysinh ";
                sql += " from xxx.benhancc a inner join " + user + ".btdbn c on a.mabn=c.mabn ";
                sql += " inner join " + user + ".btdkp_bv d on a.makp=d.makp ";
                sql += " inner join " + user + ".btdnn_bv e on c.mann=e.mann ";
                sql += " inner join " + user + ".btddt f on c.madantoc=f.madantoc ";
                sql += " left join " + user + ".btdtt g on c.matt=g.matt ";
                sql += " left join " + user + ".btdquan h on c.maqu=h.maqu ";
                sql += " left join " + user + ".btdpxa i on c.maphuongxa=i.maphuongxa ";
                sql += " inner join " + user + ".chuyenvien j on a.maql=j.maql ";
                sql += " left join " + user + ".tenvien k on j.mabv=k.mabv ";
                sql += " left join xxx.bhyt l on a.maql=l.maql ";
                sql += " left join " + user + ".dmbs gg on a.mabs=gg.ma ";
                sql += " inner join " + user + ".doituong hh on a.madoituong=hh.madoituong ";
                sql += " left join " + user + ".noigioithieu z on a.maql=z.maql ";
                sql += " left join " + user + ".dstt x on z.mabv=x.mabv ";
                sql += " left join " + user + ".dmnoicapbhyt y on l.mabv=y.mabv ";
                sql += " left join xxx.lienhe lh on a.maql=lh.maql ";
                sql += " where true";
                if (ma != "") sql += " and a.mabn='" + ma + "'";
                else sql += " and to_char(j.ngayud,'dd/mm/yyyy')='" + ngaysrv + "'";
                if (maql != 0) sql += " and j.maql=" + maql;
                if (s_mabn != "") sql += " and a.mabn='" + s_mabn + "'";
                sql += " order by a.maql desc";
            }
            else
            {
                sql = "select a.mabn,c.hoten,c.namsinh,c.sonha,c.thon,c.phai,a.maql,c.cholam,k.tenbv,";
                sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngayvao,to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngayra,";
                sql += "a.makp,d.tenkp,e.tennn,f.dantoc,g.tentt,l.sothe,to_char(l.denngay,'dd/mm/yyyy') as denngay,gg.hoten as tenbs,hh.doituong,";
                sql += "h.tenquan,i.tenpxa,case when j.chandoan is null then a.chandoan else j.chandoan end as chandoan,a.maicd,";
                sql += "x.tenbv as noigioithieu,y.tenbv as noidkkcb,";
                sql += "j.lamsang,j.xn,j.thuoc,j.tinhtrang,j.lydo,case when j.ngay is null then to_char(a.ngay,'dd/mm/yyyy hh24:mi') else to_char(j.ngay,'dd/mm/yyyy hh24:mi') end as ngay,j.vanchuyen,j.nguoidua,j.lanin, j.sochuyenvien ";
                sql += ", to_char(l.tungay,'dd/mm/yyyy') as tungay, j.yeucau, a.sovaovien, lh.soluutru,j.daduyet ";
                sql += " ,substr(lh.tuoivao,1,3)||case when substr(lh.tuoivao,4,1)=0 then 'Tuổi' else case when substr(lh.tuoivao,4,1)=1 then 'Tháng' else case when substr(lh.tuoivao,4,1)=2 then 'Ngày' else 'Giờ' end end end as tuoivao,to_char(c.ngaysinh,'dd/mm/yyyy') as ngaysinh ";
                sql += " from xxx.benhanpk a inner join " + user + ".btdbn c on a.mabn=c.mabn ";
                sql += " inner join " + user + ".btdkp_bv d on a.makp=d.makp ";
                sql += " inner join " + user + ".btdnn_bv e on c.mann=e.mann ";
                sql += " inner join " + user + ".btddt f on c.madantoc=f.madantoc ";
                sql += " left join " + user + ".btdtt g on c.matt=g.matt ";
                sql += " left join " + user + ".btdquan h on c.maqu=h.maqu ";
                sql += " left join " + user + ".btdpxa i on c.maphuongxa=i.maphuongxa ";
                sql += " inner join " + user + ".chuyenvien j on a.maql=j.maql ";
                sql += " left join " + user + ".tenvien k on j.mabv=k.mabv ";
                sql += " left join xxx.bhyt l on a.maql=l.maql ";
                sql += " left join " + user + ".dmbs gg on a.mabs=gg.ma ";
                sql += " inner join " + user + ".doituong hh on a.madoituong=hh.madoituong ";
                sql += " left join " + user + ".noigioithieu z on a.maql=z.maql ";
                sql += " left join " + user + ".dstt x on z.mabv=x.mabv ";
                sql += " left join " + user + ".dmnoicapbhyt y on l.mabv=y.mabv ";
                sql += " left join xxx.lienhe lh on a.maql=lh.maql ";
                sql += " where true";
                if (s_makp != "")
                {
                    s = s_makp.Replace(",", "','");
                    if (s.Length > 3) s = s.Substring(0, s.Length - 3);
                    sql += " and a.makp in ('" + s + "')";
                }
                if (ma != "") sql += " and a.mabn='" + ma + "'";
                else sql += " and to_char(j.ngayud,'dd/mm/yyyy')='" + ngaysrv + "'";
                if (maql != 0) sql += " and j.maql=" + maql;
                if (s_mabn != "") sql += " and a.mabn='" + s_mabn + "'";
                sql += "  order by a.maql desc";
            }
            foreach (DataRow r in (nam != "") ? m.get_data_nam_dec(nam, sql).Tables[0].Rows : m.get_data(sql).Tables[0].Rows)
            {
                l_maql = decimal.Parse(r["maql"].ToString());
                mabn.Text = r["mabn"].ToString();
                hoten.Text = r["hoten"].ToString();
                namsinh.Text = r["namsinh"].ToString();
                s_ngayvao = r["ngayvao"].ToString();
                ngayra.Text = r["ngayra"].ToString();
                diachi.Text = r["sonha"].ToString().Trim() + " " + r["thon"].ToString().Trim() + " ," + r["tenpxa"].ToString().Trim() + " ," + r["tenquan"].ToString().Trim() + " ," + r["tentt"].ToString().Trim();
                makp.Text = r["makp"].ToString();
                tenkp.Text = r["tenkp"].ToString();
                sothe.Text = r["sothe"].ToString();
                lamsang.Text = r["lamsang"].ToString();
                xn.Text = r["xn"].ToString();
                thuoc.Text = r["thuoc"].ToString();
                if (thuoc.Text == "" && loaibn.SelectedIndex == 0) getThuoc(s_ngayvao);
                if (xn.Text.Trim() == "") get_cls(s_ngayvao);
                tinhtrang.Text = r["tinhtrang"].ToString();
                lydo.Text = r["lydo"].ToString();
                ngay.Text = r["ngay"].ToString().Substring(0, 10);
                gio.Text = r["ngay"].ToString().Substring(11);
                sochuyenvien.Text = r["sochuyenvien"].ToString().Trim();
                vanchuyen.Text = r["vanchuyen"].ToString();
                nguoidua.Text = r["nguoidua"].ToString();
                s_chandoan = r["chandoan"].ToString().Trim() + ";";
                s_maicd = r["maicd"].ToString().Trim() + ";";
                s_tuoivao = r["tuoivao"].ToString();
                xxx = user + ((loaibn.SelectedIndex == 0 || loaibn.SelectedIndex == 1) ? "" : m.mmyy(s_ngayvao));
                soluutru.Text = r["soluutru"].ToString().Trim();//gam 17/08/2011
                foreach (DataRow r1 in m.get_data("select distinct maicd,chandoan from " + xxx + ".cdkemtheo where maql=" + l_maql).Tables[0].Rows)
                {
                    if (s_chandoan.IndexOf(r1["chandoan"].ToString().Trim() + ";") == -1) s_chandoan += r1["chandoan"].ToString().Trim() + ";";
                    if (s_maicd.IndexOf(r1["maicd"].ToString().Trim() + ";") == -1) s_maicd += r1["maicd"].ToString().Trim() + ";";
                }
                chandoan.Text = s_chandoan;
                if (loai == 0)//noi tru
                {
                    s_ngayvao = m.get_ngay_Capcuu_noitru(s_ngayvao, m.get_mavaovien(l_maql));
                }
                updrec(dsngay, r["doituong"].ToString(), mabn.Text, hoten.Text, namsinh.Text, r["phai"].ToString(), s_ngayvao,
                    r["ngayra"].ToString(), r["sothe"].ToString(), r["denngay"].ToString(), tenkp.Text, r["tennn"].ToString(), r["dantoc"].ToString(),
                    r["sonha"].ToString().Trim() + " " + r["thon"].ToString().Trim() + " ," + r["tenpxa"].ToString().Trim() + " ," + r["tenquan"].ToString().Trim() + " ," + r["tentt"].ToString().Trim(),
                    r["cholam"].ToString(), s_chandoan, s_maicd, r["tenbs"].ToString(), r["tenbv"].ToString(), r["noidkkcb"].ToString(), r["noigioithieu"].ToString(),
                    r["lamsang"].ToString(), r["xn"].ToString(), r["thuoc"].ToString(), r["tinhtrang"].ToString(), r["lydo"].ToString(),
                    r["ngay"].ToString(), r["vanchuyen"].ToString(), r["nguoidua"].ToString(), l_maql, false, loai, 1, r["sochuyenvien"].ToString(), r["tungay"].ToString(), 
                    int.Parse(r["yeucau"].ToString()), r["soluutru"].ToString() + "^" + r["sovaovien"].ToString(), 
                    int.Parse(r["daduyet"].ToString()),s_tuoivao,r["ngaysinh"].ToString(),"");
                if (ma == "")
                {
                    //int i = ngayvao.SelectedIndex;
                    updrec(ds, dsngay.Tables[0].Rows[i]["doituong"].ToString(), mabn.Text, hoten.Text, namsinh.Text,
                        dsngay.Tables[0].Rows[i]["phai"].ToString(), ngayvao.Text, ngayra.Text, sothe.Text, dsngay.Tables[0].Rows[i]["denngay"].ToString(), tenkp.Text,
                        dsngay.Tables[0].Rows[i]["tennn"].ToString(), dsngay.Tables[0].Rows[i]["dantoc"].ToString(),
                        dsngay.Tables[0].Rows[i]["diachi"].ToString(), dsngay.Tables[0].Rows[i]["noilamviec"].ToString(),
                        dsngay.Tables[0].Rows[i]["chandoan"].ToString(), dsngay.Tables[0].Rows[i]["maicd"].ToString(),
                        dsngay.Tables[0].Rows[i]["tenbs"].ToString(), dsngay.Tables[0].Rows[i]["tenbv"].ToString(), dsngay.Tables[0].Rows[i]["noidkkcb"].ToString(), dsngay.Tables[0].Rows[i]["noigioithieu"].ToString(),
                        lamsang.Text, xn.Text, thuoc.Text, tinhtrang.Text, lydo.Text, ngay.Text + " " + gio.Text, vanchuyen.Text, nguoidua.Text, l_maql, 
                        true, int.Parse(dsngay.Tables[0].Rows[i]["loaibn"].ToString()), 1, dsngay.Tables[0].Rows[i]["sochuyenvien"].ToString(), 
                        dsngay.Tables[0].Rows[i]["tungay"].ToString(), int.Parse(dsngay.Tables[0].Rows[i]["yeucau"].ToString()),
                        dsngay.Tables[0].Rows[i]["soluutru"].ToString(), int.Parse(r["daduyet"].ToString()), s_tuoivao, dsngay.Tables[0].Rows[i]["ngaysinh"].ToString(),"");
                    i += 1;
                }
            }
            
            
            //load check daduyet
            //foreach (DataRow r in m.get_data("select daduyet from " + user + ".chuyenvien where maql=" + l_maql + "").Tables[0].Rows)
            //{
            //    if (r["daduyet"].ToString() == "1") chkduyet.Checked = true;
            //}
        }

		private void getThuoc(string _ngayvao)
		{
			sql="select b.mabd,trim(d.ten)||' '||d.hamluong as tenbd,d.dang,trunc(sum(b.slyeucau),"+soluongle+") as soluong ";
			sql+=" from xxx.d_dutrull a,xxx.d_dutruct b,xxx.d_duyet c,"+user+".d_dmbd d,"+user+".d_dmnhom e ";
            sql+=" where a.id=b.id and a.idduyet=c.id and b.mabd=d.id and d.manhom=e.id and e.nhomin in (1,2,3,4)";
			sql+=" and a.maql="+l_maql;
			sql+=" group by b.mabd,trim(d.ten)||' '||d.hamluong,d.dang";
            DataSet tmp = m.get_data_mmyy(sql, _ngayvao.Substring(0, 10), ngayra.Text.Substring(0, 10), true);
			sql=" select b.mabd,trim(d.ten)||' '||d.hamluong as tenbd,d.dang,trunc(sum(b.slyeucau),"+soluongle+") as soluong ";
			sql+=" from xxx.d_xtutrucll a,xxx.d_xtutrucct b,xxx.d_duyet c,"+user+".d_dmbd d,"+user+".d_dmnhom e ";
			sql+=" where a.id=b.id and a.idduyet=c.id and b.mabd=d.id and d.manhom=e.id and e.nhomin in (1,2,3,4)";
			sql+=" and a.maql="+l_maql;
			sql+=" group by b.mabd,trim(d.ten)||' '||d.hamluong,d.dang";
			DataRow r1,r2;
			DataRow [] dr;
            foreach (DataRow r in m.get_data_mmyy(sql,_ngayvao.Substring(0,10), ngayra.Text.Substring(0,10), true).Tables[0].Rows)
			{
				r1=m.getrowbyid(tmp.Tables[0],"mabd="+int.Parse(r["mabd"].ToString()));
				if (r1==null)
				{
					r2=tmp.Tables[0].NewRow();
					r2["mabd"]=r["mabd"].ToString();
					r2["tenbd"]=r["tenbd"].ToString();
					r2["dang"]=r["dang"].ToString();
					r2["soluong"]=r["soluong"].ToString();
					tmp.Tables[0].Rows.Add(r2);
				}
				else
				{
					dr=tmp.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
					if (dr.Length>0) dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())+decimal.Parse(r["soluong"].ToString());
				}
			}
			string s="";
			foreach(DataRow r in tmp.Tables[0].Rows)
				s+=r["tenbd"].ToString().Trim()+" "+r["soluong"].ToString().Trim()+" "+r["dang"].ToString()+";\n";
			thuoc.Text=s;

            sql = "select b.ten from xxx.v_chidinh a," + user + ".v_giavp b ";
            sql += " where a.mavp=b.id ";
            sql += " and a.maql=" + l_maql;
            sql += " order by a.id";
            tmp = m.get_data_mmyy(sql, _ngayvao.Substring(0, 10), ngayra.Text.Substring(0, 10), true);
            s = "";
            foreach (DataRow r in tmp.Tables[0].Rows)
                s += r["ten"].ToString().Trim() + ";\n";
            xn.Text = s;
		}
        private void get_cls(string _ngayvao)
        {
            sql = "select b.ten from xxx.v_chidinh a," + user + ".v_giavp b ";
            sql += " where a.mavp=b.id ";
            sql += " and a.maql=" + l_maql;
            sql += " order by a.id";
            DataSet tmp = new DataSet();
            tmp = m.get_data_mmyy(sql, _ngayvao.Substring(0, 10), ngayra.Text.Substring(0, 10), true);
            string s = "";
            foreach (DataRow r in tmp.Tables[0].Rows)
                s += r["ten"].ToString().Trim() + ";\n";
            xn.Text = s;
        }

		private void updrec(DataSet ds,string doituong,string mabn,string hoten,string namsinh,string phai,
			string ngayvao,string ngayra,string sothe,string denngay,string tenkp,string tennn,string dantoc,string diachi,
			string cholam,string chandoan,string maicd,string tenbs,string tenbv,string noidkkcb,string noigioithieu,
			string lamsang,string xn,string thuoc,string tinhtrang,string lydo,string ngay,string vanchuyen,string nguoidua,
			decimal maql,bool chon,int loaibn,int lanin, string sochuyenvien, string tungay, int yeucau, string soluutru,
            int daduyet,string tuoivao,string ngaysinh,string thangtuoi)
		{
            DataRow r = m.getrowbyid(ds.Tables[0], "maql=" + maql);
            if (r == null)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr["maql"] = maql;
                dr["mabn"] = mabn;
                dr["hoten"] = hoten;
                dr["namsinh"] = namsinh;
                dr["phai"] = (phai.Trim() == "0") ? "Nam" : ((phai.Trim() == "Nam") ? "Nam" : "Nữ");
                dr["tennn"] = tennn;
                dr["dantoc"] = dantoc;
                dr["ngayvao"] = ngayvao;
                dr["ngayra"] = ngayra;
                dr["tenkp"] = tenkp;
                dr["doituong"] = doituong;
                dr["sothe"] = sothe;
                dr["denngay"] = denngay;
                dr["tungay"] = tungay;
                dr["noilamviec"] = cholam;
                dr["diachi"] = diachi;
                dr["chandoan"] = chandoan.Trim().Trim(';');
                dr["maicd"] = maicd.Trim().Trim(';');
                dr["tenbs"] = tenbs;
                dr["tenbv"] = tenbv;
                dr["noidkkcb"] = noidkkcb;
                dr["noigioithieu"] = noigioithieu;
                dr["lamsang"] = lamsang;
                dr["xn"] = xn;
                dr["thuoc"] = thuoc;
                dr["tinhtrang"] = tinhtrang;
                dr["lydo"] = lydo;
                dr["ngay"] = ngay;
                dr["vanchuyen"] = vanchuyen;
                dr["nguoidua"] = nguoidua;
                if (chon) dr["chon"] = chon;
                dr["loaibn"] = loaibn;
                dr["lanin"] = lanin;
                dr["sochuyenvien"] = sochuyenvien ;
                dr["yeucau"] = yeucau;
                dr["soluutru"] = soluutru ;
                dr["daduyet"] = daduyet;
                dr["tuoivao"] = tuoivao;
                dr["ngaysinh"] = ngaysinh;
                dr["thangtuoi"] = thangtuoi;
                ds.Tables[0].Rows.Add(dr);
            }
            else
            {
                DataRow[] dr1 = ds.Tables[0].Select("maql=" + maql);
                if (dr1.Length > 0)
                {
                    dr1[0]["maql"] = maql;
                    dr1[0]["mabn"] = mabn;
                    dr1[0]["hoten"] = hoten;
                    dr1[0]["namsinh"] = namsinh;
                    dr1[0]["phai"] = (phai.Trim() == "0") ? "Nam" : ((phai.Trim() == "Nam") ? "Nam" : "Nữ");
                    dr1[0]["tennn"] = tennn;
                    dr1[0]["dantoc"] = dantoc;
                    dr1[0]["ngayvao"] = ngayvao;
                    dr1[0]["ngayra"] = ngayra;
                    dr1[0]["tenkp"] = tenkp;
                    dr1[0]["doituong"] = doituong;
                    dr1[0]["sothe"] = sothe;
                    dr1[0]["denngay"] = denngay;
                    dr1[0]["tungay"] = tungay;
                    dr1[0]["noilamviec"] = cholam;
                    dr1[0]["diachi"] = diachi;
                    dr1[0]["chandoan"] = chandoan.Trim().Trim(';');
                    dr1[0]["maicd"] = maicd.Trim().Trim(';');
                    dr1[0]["tenbs"] = tenbs;
                    dr1[0]["tenbv"] = tenbv;
                    dr1[0]["noidkkcb"] = noidkkcb;
                    dr1[0]["noigioithieu"] = noigioithieu;
                    dr1[0]["lamsang"] = lamsang;
                    dr1[0]["xn"] = xn;
                    dr1[0]["thuoc"] = thuoc;
                    dr1[0]["tinhtrang"] = tinhtrang;
                    dr1[0]["lydo"] = lydo;
                    dr1[0]["ngay"] = ngay;
                    dr1[0]["vanchuyen"] = vanchuyen;
                    dr1[0]["nguoidua"] = nguoidua;
                    if (chon) dr1[0]["chon"] = chon;
                    dr1[0]["loaibn"] = loaibn;
                    dr1[0]["lanin"] = lanin;
                    dr1[0]["sochuyenvien"] = sochuyenvien;
                    dr1[0]["yeucau"] = yeucau;
                    dr1[0]["soluutru"] = soluutru;
                    dr1[0]["daduyet"] = daduyet;
                    dr1[0]["tuoivao"] = tuoivao;
                    dr1[0]["ngaysinh"] = ngaysinh;
                    dr1[0]["thangtuoi"] = thangtuoi;
                }
            }
		}

		private void ngayvao_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ena_but(bool ena)
		{
			mabn.Enabled=ena;
			ngayvao.Enabled=ena;
			lamsang.Enabled=ena;
            sochuyenvien.Enabled = (bSochuyenvien_tudong) ? false : ena;
			xn.Enabled=ena;
            loaibn.Enabled = ena;
			chandoan.Enabled=bKhongSuaChanDoan?!ena:ena;
			thuoc.Enabled=ena;
			tinhtrang.Enabled=ena;
			lydo.Enabled=ena;
			ngay.Enabled=ena;
			gio.Enabled=ena;
			vanchuyen.Enabled=ena;
			nguoidua.Enabled=ena;
			butTiep.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
            if (i_ngoaidm == 1)
            {
                butIn.Enabled = false;
            }
            else
            {
                butIn.Enabled = !ena;
            }
			butExit.Enabled=!ena;
		}

        private void emp_text()
        {
            mabn.Text = ""; hoten.Text = ""; namsinh.Text = "";
            ngayra.Text = ""; tenkp.Text = ""; makp.Text = "";
            sothe.Text = ""; diachi.Text = ""; lamsang.Text = ""; xn.Text = ""; chandoan.Text = ""; thuoc.Text = "";
            tinhtrang.Text = ""; lydo.Text = ""; ngay.Text = ""; gio.Text = ""; vanchuyen.Text = ""; nguoidua.Text = "";
            sochuyenvien.Text = ""; s_sochuyenvien = "";
            l_maql = 0;
            ena_but(true);
        }

		private void butTiep_Click(object sender, System.EventArgs e)
		{
            emp_text();
            if (s_mabn != "")
            {
                loaibn.SelectedIndex = i_loai;
                mabn.Text = s_mabn;
                mabn_Validated(sender, e);
                ngayvao.Focus();
            }
			else loaibn.Focus();
		}

		private bool kiemtra()
		{
			if (ngay.Text.Trim().Length!=10)
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"),LibMedi.AccessData.Msg);
				ngay.Focus();
				return false;
			}
			if (gio.Text.Trim().Length!=5)
			{
				MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"),LibMedi.AccessData.Msg);
				gio.Focus();
				return false;
			}
			return true;
		}
		private void butLuu_Click(object sender, System.EventArgs e)
		{
            if (hoten.Text != "")
            {
                int i = ngayvao.SelectedIndex;
                if (sochuyenvien.Text.Trim() == "")// gam 06-05-2011
                {
                    s_sochuyenvien = m.get_capid(51, ngayra.Text.Substring(8, 2)).ToString().PadLeft(7, '0') + "/" + ngayra.Text.Substring(8, 2);// get_sochuyenvien(ngayra.Text.Substring(8, 2));
                    //sql = " update " + m.user + ".chuyenvien set sochuyenvien='" + s_sochuyenvien + "' where maql=" + l_maql;//gam 15/08/2011 tehm field soluutru
                    sql = " update " + m.user + ".chuyenvien set sochuyenvien='" + s_sochuyenvien + "',soluutru='"+soluutru+"' where maql=" + l_maql;
                    m.execute_data(sql);
                    sochuyenvien.Text = s_sochuyenvien;
                }
                else
                {
                    s_sochuyenvien = sochuyenvien.Text.Trim();// gam 10-05-2011
                }
                string _ngayvv = ngayvao.Text;
                if (loaibn.SelectedIndex == 0)//noi tru
                {
                    _ngayvv = m.get_ngay_Capcuu_noitru(_ngayvv, m.get_mavaovien(l_maql));
                    if (_ngayvv == "") _ngayvv = ngayvao.Text;
                }
                updrec(ds, dsngay.Tables[0].Rows[i]["doituong"].ToString(), mabn.Text, hoten.Text, namsinh.Text,
                    dsngay.Tables[0].Rows[i]["phai"].ToString(), _ngayvv , ngayra.Text, sothe.Text, dsngay.Tables[0].Rows[i]["denngay"].ToString(), tenkp.Text,
                    dsngay.Tables[0].Rows[i]["tennn"].ToString(), dsngay.Tables[0].Rows[i]["dantoc"].ToString(),
                    dsngay.Tables[0].Rows[i]["diachi"].ToString(), dsngay.Tables[0].Rows[i]["noilamviec"].ToString(),
                    chandoan.Text, dsngay.Tables[0].Rows[i]["maicd"].ToString(),//dsngay.Tables[0].Rows[i]["chandoan"].ToString()
                    dsngay.Tables[0].Rows[i]["tenbs"].ToString(), dsngay.Tables[0].Rows[i]["tenbv"].ToString(), dsngay.Tables[0].Rows[i]["noidkkcb"].ToString(), dsngay.Tables[0].Rows[i]["noigioithieu"].ToString(),
                    lamsang.Text, xn.Text, thuoc.Text, tinhtrang.Text, lydo.Text, ngay.Text + " " + gio.Text, 
                    vanchuyen.Text, nguoidua.Text, l_maql, true, int.Parse(dsngay.Tables[0].Rows[i]["loaibn"].ToString()), 1, 
                    s_sochuyenvien, dsngay.Tables[0].Rows[i]["tungay"].ToString(), int.Parse(dsngay.Tables[0].Rows[i]["yeucau"].ToString()), 
                    dsngay.Tables[0].Rows[i]["soluutru"].ToString(), int.Parse(dsngay.Tables[0].Rows[i]["daduyet"].ToString()),
                    dsngay.Tables[0].Rows[i]["tuoivao"].ToString(), dsngay.Tables[0].Rows[i]["ngaysinh"].ToString(),"");
                string as_xn = "";
                as_xn = (xn.Text.Trim() != "") ? xn.Text.Replace("\n", "") : "";
                m.upd_chuyenvien(l_maql, lamsang.Text, xn.Text, chandoan.Text, thuoc.Text, tinhtrang.Text, lydo.Text, ngay.Text + " " + gio.Text, vanchuyen.Text, nguoidua.Text, i_userid, chkyeucau.Checked ? 1 : 0);
                m.execute_data("update "+ m.user + ".chuyenvien set sochuyenvien='"+s_sochuyenvien+"' where maql="+l_maql); // gam 10-05-2011
                //if (chkduyet.Visible)
                //{
                //    int i_daduyet = chkduyet.Checked ? 1 : 0;
                //    m.execute_data("update " + m.user + ".chuyenvien set daduyet=" + i_daduyet + ",userid_duyet="+i_userid+" where maql=" + l_maql); // Tu 06-06-2011
                //}
            }
			ena_but(false);
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_but(false);
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			dsxml.Clear();
			DataRow [] r=ds.Tables[0].Select("chon=true");
            int lanin = 0;
			for(int i=0;i<r.Length;i++)
			{
                foreach (DataRow r1 in m.get_data("select * from " + user + ".chuyenvien where maql=" + decimal.Parse(r[i]["maql"].ToString())).Tables[0].Rows)
                {
                    lanin = int.Parse(r1["lanin"].ToString());
                    s_sochuyenvien = r1["sochuyenvien"].ToString();
                }
                if (s_sochuyenvien == "")
                {
                    s_sochuyenvien = m.get_capid(51, r[i]["ngayra"].ToString().Substring(8, 2)).ToString().PadLeft(7, '0') + "/" + r[i]["ngayra"].ToString().Substring(8, 2);
                    sql = " update " + m.user + ".chuyenvien set sochuyenvien='" + s_sochuyenvien + "' where maql=" + decimal.Parse(r[i]["maql"].ToString());
                    m.execute_data(sql);
                    sochuyenvien.Text = s_sochuyenvien;
                }
                foreach (DataRow r2 in m.get_data("select mabv from " + user + ".dmnoicapbhyt where tenbv='" + r[i]["noidkkcb"].ToString() + "'").Tables[0].Rows)
                {
                    r[i]["noidkkcb"] = r2["mabv"].ToString() +"^"+ r[i]["noidkkcb"].ToString();
                }
                try
                {
                    int tuoi = 0;
                    string s_thangsinh = m.Tuoivao(r[i]["ngayvao"].ToString(), r[i]["ngaysinh"].ToString());
                    string[] thangsinh = s_thangsinh.Split('/');
                    if (m.iSoThangTuoiGioiHanTheHienThangTuoi >= int.Parse(thangsinh[1].ToString()))
                    {
                        r[i]["thangtuoi"] = thangsinh[1].ToString() + " Tháng tuổi";
                    }
                    else
                    {
                        tuoi = DateTime.Now.Year - int.Parse(r[i]["namsinh"].ToString());
                        r[i]["thangtuoi"] = tuoi.ToString();
                    }
                }
                catch
                {
                    int stuoi = DateTime.Now.Year - int.Parse(r[i]["namsinh"].ToString());
                    r[i]["thangtuoi"] = stuoi.ToString();
                }
                updrec(dsxml, r[i]["doituong"].ToString(), r[i]["mabn"].ToString(), r[i]["hoten"].ToString(), r[i]["namsinh"].ToString(), r[i]["phai"].ToString(), r[i]["ngayvao"].ToString(),
                    r[i]["ngayra"].ToString(), r[i]["sothe"].ToString(), r[i]["denngay"].ToString(), r[i]["tenkp"].ToString(), r[i]["tennn"].ToString(), r[i]["dantoc"].ToString(), r[i]["diachi"].ToString(), r[i]["noilamviec"].ToString(),
                    r[i]["chandoan"].ToString(), r[i]["maicd"].ToString(), r[i]["tenbs"].ToString(), r[i]["tenbv"].ToString(), r[i]["noidkkcb"].ToString(), r[i]["noigioithieu"].ToString(), r[i]["lamsang"].ToString(), r[i]["xn"].ToString(),
                    r[i]["thuoc"].ToString(), r[i]["tinhtrang"].ToString(), r[i]["lydo"].ToString(), r[i]["ngay"].ToString(), r[i]["vanchuyen"].ToString(),
                    r[i]["nguoidua"].ToString(), decimal.Parse(r[i]["maql"].ToString()), false, int.Parse(r[i]["loaibn"].ToString()), lanin, s_sochuyenvien,
                    r[i]["tungay"].ToString(), int.Parse(r[i]["yeucau"].ToString()), r[i]["soluutru"].ToString(), int.Parse(r[i]["daduyet"].ToString()), s_tuoivao, r[i]["ngaysinh"].ToString(),r[i]["thangtuoi"].ToString());
				m.execute_data("update "+user+".chuyenvien set lanin=lanin+1 where maql="+decimal.Parse(r[i]["maql"].ToString()));
			}
            if (chkXml.Checked)
            {
                if (!System.IO.Directory.Exists("..//xml")) System.IO.Directory.CreateDirectory("..//xml");
                dsxml.WriteXml("..//xml//giaycv.xml", XmlWriteMode.WriteSchema);
            }
            if (i_ngoaidm == 0)//trong danh mục
            {
                //if (!chkduyet.Visible)
                //{
                    if (dsxml.Tables[0].Rows.Count > 0)
                    {
                        dllReportM.frmReport f = new dllReportM.frmReport(m, dsxml, "GIẤY CHUYỂN VIỆN", "rptGiaycv.rpt", true);
                        f.ShowDialog();
                    }
                    else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"), LibMedi.AccessData.Msg);
                //}
            }
            else //Ngoài danh mục
            {
                try
                {
                    DataSet ds_duyet = m.get_data("select daduyet from " + user + ".chuyenvien where maql=" + l_maql + "");
                    if (ds_duyet.Tables[0].Rows[0]["daduyet"].ToString() == "1")
                    {
                        if (dsxml.Tables[0].Rows.Count > 0)
                        {
                            dllReportM.frmReport f = new dllReportM.frmReport(m, dsxml, "GIẤY CHUYỂN VIỆN", "rptGiaycv.rpt", true);
                            f.ShowDialog();
                        }
                    }
                    else
                        MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân chưa được duyệt chuyển viện !"), LibMedi.AccessData.Msg);
                }
                catch { }
            }
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			ds.Clear();
		}

		private void butExit_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = ds.Tables[0].TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.FromArgb(0,255,255);
			ts.SelectionForeColor = Color.PaleGreen;
			ts.RowHeaderWidth=10;
					
			FormattableBooleanColumn discontinuedCol = new FormattableBooleanColumn();
			discontinuedCol.MappingName = "chon";
			discontinuedCol.HeaderText = "Chọn";
			discontinuedCol.Width = 35;
			discontinuedCol.AllowNull = false;

			discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
			ts.GridColumnStyles.Add(discontinuedCol);
			dataGrid1.TableStyles.Add(ts);

			FormattableTextBoxColumn TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "mabn";
			TextCol.HeaderText = "Mã BN";
			TextCol.Width = 60;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
			
			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "hoten";
			TextCol.HeaderText = "Họ tên";
			TextCol.Width = 150;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "maql";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}
	
		// Provides the format for the given cell.
		private void SetCellFormat(object sender, DataGridFormatCellEventArgs e)
		{
			try
			{
				//conditionally set properties in e depending upon e.Row and e.Col
				bool discontinued = (bool) ((e.Column != 0) ? this.dataGrid1[e.Row, 0] : e.CurrentCellValue);
				//check is discontinued
				if(e.Column > 0 && !(bool)(this.dataGrid1[e.Row, 0]))//discontinued)
				{
					//				e.BackBrush = this.disabledBackBrush;
					e.ForeBrush = this.disabledTextBrush;
				}
				else if(e.Column > 0 && e.Row == this.dataGrid1.CurrentRowIndex)//discontinued)
				{
					e.BackBrush = this.currentRowBackBrush;
					e.TextFont = this.currentRowFont;
				}
			}
			catch{}
		}

		private void BoolValueChanged(object sender, BoolValueChangedEventArgs e)
		{
			this.dataGrid1.EndEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"],e.Row, false);
			RefreshRow(e.Row);
			this.dataGrid1.BeginEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"],e.Row);
		}
		private void RefreshRow(int row)
		{
			Rectangle rect = this.dataGrid1.GetCellBounds(row, 0);
			rect = new Rectangle(rect.Right, rect.Top, this.dataGrid1.Width, rect.Height);
			this.dataGrid1.Invalidate(rect);
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			if((bool)this.dataGrid1[this.dataGrid1.CurrentRowIndex, checkCol])
				this.dataGrid1.CurrentCell = new DataGridCell(this.dataGrid1.CurrentRowIndex, checkCol);
			afterCurrentCellChanged = true;
            try
            {
                //if (butTiep.Enabled)
                //{                    
                    emp_text();
                    int irow = dataGrid1.CurrentCell.RowNumber;
                    DataRow r = m.getrowbyid(ds.Tables[0], "mabn='" + dataGrid1[irow, 1].ToString() + "'");
                    if (r != null)
                    {
                        loaibn.SelectedIndex = int.Parse(r["loaibn"].ToString());
                        mabn.Text = r["mabn"].ToString();
                        l_maql = decimal.Parse(r["maql"].ToString());
                        load_data(mabn.Text,loaibn.SelectedIndex, l_maql);
                        //if (r["daduyet"].ToString() == "1") chkduyet.Checked = true;
                        //else chkduyet.Checked = false;
                    }
                //}
            }
            catch { }
		}

		private void dataGrid1_Click(object sender, System.EventArgs e)
		{
			Point pt = this.dataGrid1.PointToClient(Control.MousePosition);
			DataGrid.HitTestInfo hti = this.dataGrid1.HitTest(pt);
			BindingManagerBase bmb = this.BindingContext[this.dataGrid1.DataSource, this.dataGrid1.DataMember];
			if(afterCurrentCellChanged && hti.Row < bmb.Count 
				&& hti.Type == DataGrid.HitTestType.Cell 
				&&  hti.Column == checkCol )
			{	
				this.dataGrid1[hti.Row, checkCol] = !(bool)this.dataGrid1[hti.Row, checkCol];
				RefreshRow(hti.Row);
			}
			afterCurrentCellChanged = false;
		}

		private void ngayvao_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            
            string s_chandoan = "", s_maicd = "", xxx = "";
			if (this.ActiveControl==ngayvao && ngayvao.SelectedIndex!=-1)
			{
                try
                {
                    ngayra.Text = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ngayra"].ToString();
                    sothe.Text = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["sothe"].ToString();
                    tenkp.Text = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["tenkp"].ToString();
                    l_maql = decimal.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString());
                    //Khuong 05/11/2011
                    s_ngayvao = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ngayvao"].ToString();
                    lamsang.Text = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["lamsang"].ToString();
                    xn.Text = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["xn"].ToString();
                    thuoc.Text = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["thuoc"].ToString();
                    if (thuoc.Text == "" && loaibn.SelectedIndex == 0) getThuoc(s_ngayvao);
                    if (xn.Text.Trim() == "") get_cls(s_ngayvao);
                    tinhtrang.Text = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["tinhtrang"].ToString();
                    lydo.Text = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["lydo"].ToString();
                    ngay.Text = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ngay"].ToString().Substring(0, 10);
                    gio.Text = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ngay"].ToString().Substring(11);
                    sochuyenvien.Text = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["sochuyenvien"].ToString().Trim();
                    try
                    {// KHuong 15/11/2011
                        soluutru.Text = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["soluutru"].ToString().Trim().Split('^')[0];
                    }
                    catch {
                        soluutru.Text = "";
                    }
                    vanchuyen.Text = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["vanchuyen"].ToString();
                    nguoidua.Text = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["nguoidua"].ToString();
                    s_chandoan = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["chandoan"].ToString().Trim() + ";";
                    s_maicd = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["maicd"].ToString().Trim() + ";";
                    xxx = user + ((loaibn.SelectedIndex == 0 || loaibn.SelectedIndex == 1) ? "" : m.mmyy(s_ngayvao));
                    foreach (DataRow r1 in m.get_data("select distinct maicd,chandoan from " + xxx + ".cdkemtheo where maql=" + l_maql).Tables[0].Rows)
                    {
                        if (s_chandoan.IndexOf(r1["chandoan"].ToString().Trim() + ";") == -1) s_chandoan += r1["chandoan"].ToString().Trim() + ";";
                        if (s_maicd.IndexOf(r1["maicd"].ToString().Trim() + ";") == -1) s_maicd += r1["maicd"].ToString().Trim() + ";";
                    }
                    chandoan.Text = s_chandoan;
                }
                catch { }
                //end Khuong 05/11/2011
			}
		}

		private void ngay_Validated(object sender, System.EventArgs e)
		{
			ngay.Text=ngay.Text.Trim();
			if (ngay.Text.Length==6) ngay.Text=ngay.Text+DateTime.Now.Year.ToString();
			if (!m.bNgay(ngay.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
				ngay.Focus();
				return;
			}
		}

		private void gio_Validated(object sender, System.EventArgs e)
		{
			string sgio=(gio.Text.Trim()=="")?"00:00":gio.Text.Trim();
			gio.Text=sgio.Substring(0,2).PadLeft(2,'0')+":"+sgio.Substring(3).Trim().PadRight(2,'0');
			if (!m.bGio(gio.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"));
				gio.Focus();
				return;
			}
		}

        private void chandoan_TextChanged(object sender, EventArgs e)
        {
            if (chandoan.Text == "\r\n") SendKeys.Send("{Tab}");
        }

        private string get_sochuyenvien(string s_yy)
        {
            decimal l_socv = 0;
            sql = "select max(substr(sochuyenvien,3)) as sochuyenvien from " + m.user + ".chuyenvien where length(sochuyenvien)=10";
            DataSet lds = m.get_data(sql);
            if (lds.Tables.Count < 0)
            {
                m.execute_data("alter table " + m.user + ".chuyenvien add sochuyenvien varchar(10)");
                sql = "select max(substr(sochuyenvien,3)) as sochuyenvien from " + m.user + ".chuyenvien where length(sochuyenvien)=10";
                lds = m.get_data(sql);
            }
            l_socv = (lds.Tables[0].Rows[0][0].ToString() == "") ? 0 : decimal.Parse(lds.Tables[0].Rows[0][0].ToString());
            l_socv += 1;
            return s_yy+l_socv.ToString().PadLeft(8,'0');
        }

        private void capnhat_cautruc_chuyenvien()
        {
            sql = " alter table " + m.user + ".chuyenvien add sochuyenvien varchar (10)";
            m.execute_data(sql);
        }
        //linh
        public decimal MaQuanLy
        {
            get { return l_maql; }
        }

        private void sovaovien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }
	}
}
