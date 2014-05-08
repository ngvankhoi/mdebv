using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using LibMedi;
using LibDuoc;
using LibVienphi;


namespace dllvpkhoa_chidinh
{
	/// <summary>
    /// Summary description for Kiemsoatdv.
	/// </summary>
	public class Kiemsoatdv : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private int i_maxlength_mabn = 8;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.DataGrid dataGrid1;
		private LibList.List list;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox madoituong;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox mavp;
        private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butLuu;
        private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butKetthuc;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibMedi.AccessData m;
        private LibVienphi.AccessData v;
        private DataSet dsngay = new DataSet();
        private string xxx, user, nam = "", s_ngay, s_makp, s_tenkp, sql, s_dvt, s_table, s_loaivp = "", s_mucvp = "", s_ngayvao = "", s_chenhlech, s_title = "", i_nhomvp_pttt = "", username = "",smakp="";
        private int i_madoituong, i_loai, i_done, i_paid, i_row = 0, i_userid, iChidinh, v1, v2, i_madoituongvao, i_tunguyen, i_vienphi, i_traituyen=0;
		private decimal l_maql,l_idkhoa,l_id,l_mavaovien,l_idchidinh;
        private decimal d_soluong, d_dongia, d_vattu, d_soluongcu, Tamung_min=0, chiphi=0, tamung=0;
        private bool bMadoituong, bNhapten, bNew, bEdit = false, bHansd_thuoc, bChidinh_exp_txt, bCD_BS_Chidinh, bChuky, bChidinh_thutienlien, bChenhlech_doituong, bChidinh_loaivp, bAdmin, bNhapPTTT_chidinh_vpkhoa_miengiam, bNhapPTTT_chenhlech_miengiamtheo_I08;
        private bool bAdminHethong = false, bChidinh_lietke_kemgia=true;
		private DataRow r;
		private DataSet ds=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dtngay=new DataTable();
		private DataTable dtkp=new DataTable();
		private DataTable dthoten=new DataTable();
		private DataTable dtll=new DataTable();
        private DataTable dtdt = new DataTable();
        private DataTable dtbs = new DataTable();
        private LibList.List listHoten;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox sothe;
        private Brush disabledBackBrush;
        private Brush disabledTextBrush;
        private Brush disabledTextBrush1;
        private Brush alertBackBrush;
        private Font alertFont;
        private Brush alertTextBrush;
        private Font currentRowFont;
        private Brush currentRowBackBrush;
        bool afterCurrentCellChanged=true;
        private int checkCol = 0, i_loaiba = 1;
        private byte[] image;
        private System.IO.FileStream fstr;
        private TextBox mabs;
        private TextBox maicd;
        private bool bChidinh_dain_khongchohuy = false;
        private TreeView treeView1;
        private ComboBox ngayvao;
        private DateTimePicker ngayvv;
        private Label label11;
        private MaskedBox.MaskedBox ngayra;
        private Label label5;
        private Label label6;
        private TextBox khoa;
        private ComboBox tenkhoa;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Kiemsoatdv(LibMedi.AccessData acc,string ngay,string makp,string tenkp,int userid,int loai,int loaiba,bool admin)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; v = new LibVienphi.AccessData(); if (m.bBogo) tv.GanBogo(this, textBox111);
            s_ngay = ngay; s_makp = makp; s_tenkp = tenkp;
            i_userid = userid; i_loai = loai; i_loaiba = loaiba; bAdmin = admin;
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
                    if (disabledBackBrush != null)
                    {
                        disabledBackBrush.Dispose();
                        disabledTextBrush.Dispose();
                        disabledTextBrush1.Dispose();
                        alertBackBrush.Dispose();
                        alertFont.Dispose();
                        alertTextBrush.Dispose();
                        currentRowFont.Dispose();
                        currentRowBackBrush.Dispose();
                    }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kiemsoatdv));
            this.label1 = new System.Windows.Forms.Label();
            this.mabn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hoten = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.list = new LibList.List();
            this.label4 = new System.Windows.Forms.Label();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.mavp = new System.Windows.Forms.TextBox();
            this.butMoi = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.listHoten = new LibList.List();
            this.label3 = new System.Windows.Forms.Label();
            this.sothe = new System.Windows.Forms.TextBox();
            this.mabs = new System.Windows.Forms.TextBox();
            this.maicd = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.ngayvao = new System.Windows.Forms.ComboBox();
            this.ngayvv = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.ngayra = new MaskedBox.MaskedBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.khoa = new System.Windows.Forms.TextBox();
            this.tenkhoa = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 18;
            this.label1.Text = "Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(58, 6);
            this.mabn.MaxLength = 8;
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(125, 21);
            this.mabn.TabIndex = 0;
            this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
            this.mabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(184, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(229, 6);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(249, 21);
            this.hoten.TabIndex = 12;
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
            this.dataGrid1.Location = new System.Drawing.Point(9, 55);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(699, 336);
            this.dataGrid1.TabIndex = 19;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // list
            // 
            this.list.BackColor = System.Drawing.SystemColors.Info;
            this.list.ColumnCount = 0;
            this.list.Location = new System.Drawing.Point(424, 465);
            this.list.MatchBufferTimeOut = 1000;
            this.list.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(75, 17);
            this.list.TabIndex = 30;
            this.list.TextIndex = -1;
            this.list.TextMember = null;
            this.list.ValueIndex = -1;
            this.list.Visible = false;
            this.list.DoubleClick += new System.EventHandler(this.list_DoubleClick);
            this.list.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(478, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 27;
            this.label4.Text = "Đối tượng :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madoituong
            // 
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.madoituong.Enabled = false;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(544, 30);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(136, 21);
            this.madoituong.TabIndex = 7;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(475, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 23);
            this.label7.TabIndex = 21;
            this.label7.Text = "Khoa :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mavp
            // 
            this.mavp.Enabled = false;
            this.mavp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mavp.Location = new System.Drawing.Point(64, 204);
            this.mavp.Name = "mavp";
            this.mavp.Size = new System.Drawing.Size(46, 21);
            this.mavp.TabIndex = 24;
            this.mavp.Validated += new System.EventHandler(this.mavp_Validated);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(226, 407);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(64, 25);
            this.butMoi.TabIndex = 7;
            this.butMoi.Text = "    &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(290, 407);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(64, 25);
            this.butLuu.TabIndex = 5;
            this.butLuu.Text = "    &Xem";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(354, 407);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(64, 25);
            this.butBoqua.TabIndex = 6;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(418, 407);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(71, 25);
            this.butKetthuc.TabIndex = 11;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // listHoten
            // 
            this.listHoten.BackColor = System.Drawing.SystemColors.Info;
            this.listHoten.ColumnCount = 0;
            this.listHoten.Location = new System.Drawing.Point(335, 465);
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
            this.label3.Location = new System.Drawing.Point(541, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 23);
            this.label3.TabIndex = 74;
            this.label3.Text = "Số thẻ :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Visible = false;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(588, 6);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(119, 21);
            this.sothe.TabIndex = 73;
            this.sothe.Visible = false;
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.Enabled = false;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(335, 238);
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(44, 21);
            this.mabs.TabIndex = 263;
            // 
            // maicd
            // 
            this.maicd.Enabled = false;
            this.maicd.Location = new System.Drawing.Point(424, 251);
            this.maicd.Name = "maicd";
            this.maicd.Size = new System.Drawing.Size(51, 20);
            this.maicd.TabIndex = 266;
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(588, 29);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(121, 161);
            this.treeView1.TabIndex = 23;
            this.treeView1.Visible = false;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // ngayvao
            // 
            this.ngayvao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ngayvao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvao.Location = new System.Drawing.Point(59, 31);
            this.ngayvao.Name = "ngayvao";
            this.ngayvao.Size = new System.Drawing.Size(124, 21);
            this.ngayvao.TabIndex = 2;
            this.ngayvao.SelectedIndexChanged += new System.EventHandler(this.ngayvao_SelectedIndexChanged);
            this.ngayvao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngayvao_KeyDown);
            // 
            // ngayvv
            // 
            this.ngayvv.CalendarMonthBackground = System.Drawing.SystemColors.HighlightText;
            this.ngayvv.CustomFormat = "dd/MM/yyyy HH:mm";
            this.ngayvv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvv.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngayvv.Location = new System.Drawing.Point(229, 31);
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(122, 21);
            this.ngayvv.TabIndex = 4;
            this.ngayvv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngayvv_KeyDown);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(186, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 23);
            this.label11.TabIndex = 282;
            this.label11.Text = "Từ :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngayra
            // 
            this.ngayra.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayra.Location = new System.Drawing.Point(379, 30);
            this.ngayra.Mask = "##/##/#### ##:##";
            this.ngayra.Name = "ngayra";
            this.ngayra.Size = new System.Drawing.Size(99, 21);
            this.ngayra.TabIndex = 285;
            this.ngayra.Text = "  /  /       :  ";
            this.ngayra.Validated += new System.EventHandler(this.ngayra_Validated);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(350, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 23);
            this.label5.TabIndex = 284;
            this.label5.Text = "đến :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(-7, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 280;
            this.label6.Text = "Ngày vào :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // khoa
            // 
            this.khoa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.khoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khoa.Location = new System.Drawing.Point(515, 7);
            this.khoa.Name = "khoa";
            this.khoa.Size = new System.Drawing.Size(24, 21);
            this.khoa.TabIndex = 286;
            this.khoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.khoa_KeyDown);
            // 
            // tenkhoa
            // 
            this.tenkhoa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenkhoa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkhoa.Location = new System.Drawing.Point(544, 6);
            this.tenkhoa.Name = "tenkhoa";
            this.tenkhoa.Size = new System.Drawing.Size(136, 21);
            this.tenkhoa.TabIndex = 287;
            this.tenkhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenkhoa_KeyDown);
            // 
            // Kiemsoatdv
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(714, 446);
            this.Controls.Add(this.tenkhoa);
            this.Controls.Add(this.khoa);
            this.Controls.Add(this.ngayvao);
            this.Controls.Add(this.ngayvv);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.ngayra);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.listHoten);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.list);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.mavp);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.maicd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "Kiemsoatdv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kiểm soát dịch vụ";
            this.Load += new System.EventHandler(this.Kiemsoatdv_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Kiemsoatdv_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void load_mabn(string s_mabn)
		{
            string sql = "select distinct d.mabn,d.hoten,case when d.ngaysinh is null then d.namsinh else to_char(d.ngaysinh,'dd/mm/yyyy') end as namsinh, ";
            sql += "d.phai,d.sonha,d.thon,c.mavaovien,c.maql,a.id as idkhoa,' ' as giuong,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,";
            sql += "case when b.ngay is null then to_char(now(),'dd/mm/yyyy hh24:mi') else to_char(b.ngay,'dd/mm/yyyy hh24:mi') end as ngayra,e.makp,e.tenkp ";
            sql += "from "+user+".nhapkhoa a left join "+user+".xuatkhoa b on a.id=b.id inner join "+user+".benhandt c on a.maql=c.maql ";
            sql += "inner join "+user+".btdbn d on a.mabn=d.mabn left join "+user+".btdkp_bv e on a.makp=e.makp where a.mabn='" + s_mabn + "'";
            dtll = m.get_data_mmyy(sql,ngayvv.Text,ngayra.Text,false).Tables[0];
		}
        private void AddGridTableStyle()
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = ds.Tables[0].TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            ts.SelectionBackColor = Color.FromArgb(0, 255, 255);
            ts.SelectionForeColor = Color.PaleGreen;
            ts.RowHeaderWidth = 5;

            FormattableBooleanColumn discontinuedCol = new FormattableBooleanColumn();
            discontinuedCol.MappingName = "chon";
            discontinuedCol.HeaderText = "Đã thanh toán";
            discontinuedCol.Width = 90;
            discontinuedCol.AllowNull = false;

            discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
            ts.GridColumnStyles.Add(discontinuedCol);
            dataGrid1.TableStyles.Add(ts);

            FormattableTextBoxColumn TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "id";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "tenkp";
            TextCol1.HeaderText = "Khoa/phòng";
            TextCol1.Width = 100;
            TextCol1.ReadOnly = true;
            TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "ngay";
            TextCol1.HeaderText = "Ngày";
            TextCol1.Width = 100;
            TextCol1.ReadOnly = true;
            TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "doituong";
            TextCol1.HeaderText = "Đối tượng";
            TextCol1.Width = 60;
            TextCol1.ReadOnly = true;
            TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "ten";
            TextCol1.HeaderText = "Dịch vụ";
            TextCol1.Width = 200;
            TextCol1.ReadOnly = true;
            TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "dvt";
            TextCol1.HeaderText = "ĐVT";
            TextCol1.Width = 30;
            TextCol1.ReadOnly = true;
            TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "soluong";
            TextCol1.HeaderText = "SL";
            TextCol1.Width = 30;
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "makp";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "madoituong";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "mavp";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "dongia";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "paid";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "done";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "maql";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "idkhoa";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "vattu";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "tinhtrang";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "thuchien";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "ma";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "mavaovien";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "ghichu";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "tylegiam";
            TextCol1.HeaderText = "%Giảm";
            TextCol1.Width = 40;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "stgiam";
            TextCol1.HeaderText = "ST Giảm";
            TextCol1.Width = 70;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "lydogiam";
            TextCol1.HeaderText = "Lý do giảm";
            TextCol1.Width = 100;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);
        }

        private void SetCellFormat(object sender, DataGridFormatCellEventArgs e)
        {
            try
            {
                if (this.dataGrid1[e.Row, 12].ToString().Trim() == "1" )//|| this.dataGrid1[e.Row, 13].ToString().Trim() == "1")
                    e.ForeBrush = this.disabledTextBrush;
                else if (this.dataGrid1[e.Row, 13].ToString().Trim() == "1")// || this.dataGrid1[e.Row, 13].ToString().Trim() == "1")
                    e.ForeBrush = this.disabledTextBrush1;
                bool discontinued = (bool)((e.Column != 0) ? this.dataGrid1[e.Row, 0] : e.CurrentCellValue);
                if (e.Column > 0 && (bool)(this.dataGrid1[e.Row, 0])) e.ForeBrush = new SolidBrush(Color.Blue);
                else if (e.Column > 0 && e.Row == this.dataGrid1.CurrentRowIndex)
                {
                    e.BackBrush = this.currentRowBackBrush;
                    e.TextFont = this.currentRowFont;
                }
            }
            catch { }
        }

        private void BoolValueChanged(object sender, BoolValueChangedEventArgs e)
        {
            this.dataGrid1.EndEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"], e.Row, false);
            RefreshRow(e.Row);
            this.dataGrid1.BeginEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"], e.Row);
        }
        private void RefreshRow(int row)
        {
            Rectangle rect = this.dataGrid1.GetCellBounds(row, 0);
            rect = new Rectangle(rect.Right, rect.Top, this.dataGrid1.Width, rect.Height);
            this.dataGrid1.Invalidate(rect);
        }

        private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            if ((bool)this.dataGrid1[this.dataGrid1.CurrentRowIndex, checkCol])
                this.dataGrid1.CurrentCell = new DataGridCell(this.dataGrid1.CurrentRowIndex, checkCol);
            ref_text();
        }

        private void dataGrid1_Click(object sender, System.EventArgs e)
        {
            Point pt = this.dataGrid1.PointToClient(Control.MousePosition);
            DataGrid.HitTestInfo hti = this.dataGrid1.HitTest(pt);
            BindingManagerBase bmb = this.BindingContext[this.dataGrid1.DataSource, this.dataGrid1.DataMember];
            if (afterCurrentCellChanged && hti.Row < bmb.Count
                && hti.Type == DataGrid.HitTestType.Cell
                && hti.Column == checkCol)
            {
                this.dataGrid1[hti.Row, checkCol] = !(bool)this.dataGrid1[hti.Row, checkCol];
                RefreshRow(hti.Row);
            }
        }

		private void load_grid(decimal maql,decimal idkhoa)
		{
            string stime = "'" + m.f_ngay + "'";
			sql="select a.id,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.makp,d.tenkp,a.madoituong,c.doituong,a.mavp,b.ten,b.dvt,a.soluong,a.dongia,a.paid,a.done,a.mavaovien,a.maql,a.idkhoa,a.vattu,a.tinhtrang,a.thuchien,b.ma,a.mabs,a.maicd,a.chandoan,a.loaiba,a.ghichu ";
            sql += ", a.tylegiam, a.stgiam, a.lydogiam,a.hide ";
			sql+=" from xxx.v_chidinh a,"+user+".v_giavp b,"+user+".doituong c,"+user+".btdkp_bv d ";
			sql+=" where a.mavp=b.id and a.madoituong=c.madoituong and a.makp=d.makp ";
			sql+=" and a.mabn='"+mabn.Text+"'";
            //if (idkhoa > 0) sql += " and a.idkhoa=" + idkhoa;
            if (tenkhoa.SelectedIndex != -1) sql += " and a.makp = '"+tenkhoa.SelectedValue.ToString()+"'";
            if (maql > 0) sql += " and a.maql=" + maql;
            sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + ngayvv.Text.Substring(0, 10) + "'," + stime + ") and to_date('" + ngayra.Text.Substring(0, 10) + "'," + stime + ")";
			sql+=" order by a.ngay";
			ds=m.get_data_mmyy(sql,ngayvv.Text,ngayra.Text,false);
            ds.Tables[0].Columns.Add("Chon", typeof(bool));
            dataGrid1.DataSource = ds.Tables[0];
            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource, dataGrid1.DataMember];
            DataView dv = (DataView)cm.List;
            dv.AllowNew = false;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row["paid"].ToString() == "1")
                {
                    row["chon"] = true;
                }
                else
                {
                    row["chon"] = false;
                }
            }
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

		private void ten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) list.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (list.Visible) list.Focus();
				else SendKeys.Send("{Tab}");
			}		
		}

		private void ten_TextChanged(object sender, System.EventArgs e)
		{
            //if (this.ActiveControl==ten)
            //{
            //    Filter(ten.Text);
            //    list.BrowseToDanhmuc_ma(ten,mavp,soluong,80);
            //}
		}

		private void soluong_Validated(object sender, System.EventArgs e)
		{
            //try
            //{
            //    if (soluong.Text=="") soluong.Text="1";
            //    d_soluong=decimal.Parse(soluong.Text);
            //    soluong.Text=d_soluong.ToString("###,###.00");
            //}
            //catch{soluong.Text="1";}
		}

		private void ref_text()
		{
			try
			{
				i_row=dataGrid1.CurrentCell.RowNumber;
				madoituong.SelectedValue=dataGrid1[i_row,9].ToString();
				mavp.Text=dataGrid1[i_row,10].ToString();
                //ten.Text=dataGrid1[i_row,5].ToString();
				s_dvt=dataGrid1[i_row,6].ToString();
				d_dongia=decimal.Parse(dataGrid1[i_row,11].ToString());
				d_vattu=decimal.Parse(dataGrid1[i_row,16].ToString());
				i_paid=int.Parse(dataGrid1[i_row,12].ToString());
				i_done=int.Parse(dataGrid1[i_row,13].ToString());
				d_soluong=decimal.Parse(dataGrid1[i_row,7].ToString());
                //soluong.Text=d_soluong.ToString("###,###.00");
				l_id=decimal.Parse(dataGrid1[i_row,1].ToString());
                //tinhtrang.SelectedValue=dataGrid1[i_row,17].ToString();
                //thuchien.SelectedValue=dataGrid1[i_row,18].ToString();
                //ma.Text=dataGrid1[i_row,19].ToString();
                l_maql = (dataGrid1[i_row, 14].ToString() == "") ? 0 : decimal.Parse(dataGrid1[i_row, 14].ToString());
                l_idkhoa = (dataGrid1[i_row, 15].ToString() == "") ? 0 : decimal.Parse(dataGrid1[i_row, 15].ToString());
                l_mavaovien = (dataGrid1[i_row, 20].ToString() == "") ? 0 : decimal.Parse(dataGrid1[i_row, 20].ToString());
				d_soluongcu=d_soluong;
                DataRow r = m.getrowbyid(ds.Tables[0], "id=" + l_id);
                if (r != null)
                {
                    mabs.Text = r["mabs"].ToString();
                    DataRow r1 = m.getrowbyid(dtbs, "ma='" + mabs.Text + "'");
                    //tenbs.Text = (r1 != null) ? r1["hoten"].ToString() : "";
                    //chandoan.Text = r["chandoan"].ToString();
                    maicd.Text = r["maicd"].ToString();
                    //tylegiam.Text = r["tylegiam"].ToString();
                    //stgiam.Text = r["stgiam"].ToString();
                    //lydogiam.Text = r["lydogiam"].ToString();
                    //if (butLuu.Enabled && r["hide"].ToString() != "1") enable_giam(get_nhomvp_pttt(int.Parse(mavp.Text)));
                    //else enable_giam(false);
                }
                //ghichu.Text = dataGrid1[i_row, 21].ToString();
			}
			catch{}
		}


		private void ena_object(bool ena)
		{
            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource, dataGrid1.DataMember];
            DataView dv = (DataView)cm.List;
            dv.AllowNew = false;
			mabn.Enabled=ena;
			hoten.Enabled=ena;
			madoituong.Enabled=ena;
            khoa.Enabled = ena;
            tenkhoa.Enabled = ena;
           
			butMoi.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			if (ena && l_id==0)
			{
                ds.Clear();
				s_dvt="";i_paid=0;i_done=0;
			}
			else butMoi.Focus();
		}
		private void butMoi_Click(object sender, System.EventArgs e)
		{
            bNew = true;
            l_id = 0; l_idchidinh = v.get_id_chidinhll;
            mabn.Text = "";
            hoten.Text = "";
            ngayra.Text = m.Ngaygio_hienhanh;
            tenkhoa.Text = "";
            khoa.Text = "";
            l_maql = 0; l_idkhoa = 0;
            ena_object(true);
            dsngay.Clear();
            try
            {
                mabn.Focus();
            }
            catch { }
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
            if (m.bRavien(l_maql))
            {
                MessageBox.Show(lan.Change_language_MessageText("Người bệnh đã ra viện !"), LibMedi.AccessData.Msg);
                try
                {
                    mabn.Focus();
                }
                catch { }
                return;
            }
            if (!bAdmin)
            {
                r = m.getrowbyid(dthoten, "mabn='" + mabn.Text + "'");
                if (r == null)
                {
                    MessageBox.Show("Người bệnh này không còn hiện diện !", LibMedi.AccessData.Msg);
                    return;
                }
                else i_madoituongvao = int.Parse(r["madoituong"].ToString());
            }
            bEdit = true;
            ref_text();
  			ena_object(true);
            bNew = false; d_soluongcu = 0;
            mabn.Enabled = hoten.Enabled = bNew;
			r=d.getrowbyid(dthoten,"mabn='"+mabn.Text+"'");
            if (r != null)
            {
                hoten.Text = r["hoten"].ToString();
                nam = r["nam"].ToString();
                s_ngayvao = r["ngay"].ToString();
                l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
                l_maql = decimal.Parse(r["maql"].ToString());
                l_idkhoa = decimal.Parse(r["id"].ToString());
                i_madoituong=i_madoituongvao = d.get_madoituong(l_maql);
                madoituong.SelectedValue = i_madoituong.ToString();
                sothe.Text = r["sothe"].ToString();
                mabs.Text = r["mabs"].ToString();
                DataRow r1 = m.getrowbyid(dtbs, "ma='" + mabs.Text + "'");
                //tenbs.Text = (r1 != null) ? r1["hoten"].ToString() : "";
                //chandoan.Text = r["chandoan"].ToString();
                maicd.Text = r["maicd"].ToString();
            }
            //ghichu.Text = ma.Text = ten.Text = lydogiam.Text = ""; soluong.Text = "1";
            //tylegiam.Text = stgiam.Text = "0";
            bEdit = false;
		}

		private bool kiemtra()
		{
            decimal tmp_mavv = l_mavaovien;
			if ((mabn.Text!="" && hoten.Text=="") || (mabn.Text=="" && hoten.Text!=""))
			{
				MessageBox.Show(lan.Change_language_MessageText("Họ tên người bệnh !"),LibMedi.AccessData.Msg);
                if (mabn.Text == "")
                {
                    try
                    {
                        mabn.Focus();
                    }
                    catch { }
                }
                else if (hoten.Text == "")
                {
                    try
                    {
                        hoten.Focus();
                    }
                    catch { }                    
                }
				return false;
			}
			if (l_maql==0 || l_idkhoa==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Người bệnh không hợp lệ !"),LibMedi.AccessData.Msg);
                try
                {
                    mabn.Focus();
                }
                catch { }
				return false;
			}        
			return true;
		}
		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
            load_grid(l_maql, l_idkhoa);
            ena_object(false);
		}

        private void upd_data(int i_mavp, decimal d_soluong, int i_madt, decimal dongia, int idtrongoi)
        {
            bool bCont = true;
            string fie = "gia_bh";
            decimal d_tyle_traituyen = 1;
            int s_doituong_chenhlech = (i_madt == i_tunguyen || i_madt == i_madoituongvao) ? i_madoituongvao : i_madt;//binh 050109
            DataRow r = m.getrowbyid(dtdt, "madoituong=" + s_doituong_chenhlech);//binh 050109
            if (r != null) { fie = r["field_gia"].ToString(); bCont = r["chenhlech"].ToString() == "1"; }
            else bCont = false;
            r = m.getrowbyid(dt, "id=" + i_mavp);
            if (r != null)
            {
                //if (madoituong.SelectedValue.ToString() != "1") d_tyle_traituyen = 1;
                //else if (i_traituyen > 0) d_tyle_traituyen = decimal.Parse(r["bhyt_tt"].ToString()) / 100;
                //else d_tyle_traituyen = decimal.Parse(r["bhyt"].ToString()) / 100;

                bCont = bCont && s_chenhlech.IndexOf((bChenhlech_doituong?i_madoituongvao.ToString(): i_madt.ToString().Trim()) + ",") != -1//bCont && s_chenhlech.IndexOf(i_madoituongvao.ToString().Trim() + ",") != -1
                        && r["chenhlech"].ToString().Trim() == "1" //&& i_loaiba == 3
                        && decimal.Parse(r[m.field_gia(i_tunguyen.ToString())].ToString()) > decimal.Parse(r[fie].ToString());
                if (bChenhlech_doituong) bCont = bCont && (i_madt == i_tunguyen);
                if (i_madoituongvao == 1) bCont = bCont && (decimal.Parse(r["bhyt"].ToString()) > 0);
                if (bCont)
                {
                    madoituong.SelectedValue = i_madoituongvao.ToString();
                    madoituong.Update();
                    //upd_detail(false, i_mavp, d_soluong, dongia, idtrongoi);
                    m.execute_data("update " + xxx + ".v_chidinh set dachenhlech=1 where id=" + l_id + " and mavp=" + i_mavp);
                    l_id = -l_id;// 0;
                    madoituong.SelectedValue = i_tunguyen.ToString();
                    madoituong.Update();
                    //upd_detail(true, i_mavp, d_soluong, dongia, idtrongoi);
                    m.execute_data("update " + xxx + ".v_chidinh set dachenhlech=1 where id=" + l_id + " and mavp=" + i_mavp);
                }
                else
                {
                    madoituong.SelectedValue = i_madt.ToString();
                    madoituong.Update();
                    //upd_detail(false, i_mavp, d_soluong, dongia, idtrongoi);
                }
            }
            
        }

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
			try
			{
                //bool bFound = true;
				i_row=dataGrid1.CurrentCell.RowNumber;
                l_id = decimal.Parse(dataGrid1[i_row, 1].ToString());
                /*
                DataTable tmp = m.getChidinh(s_ngay, l_id);
                if (tmp.Rows.Count > 0)
                {
                    if (tmp.Rows[0]["paid"].ToString() == "1" || tmp.Rows[0]["done"].ToString() == "1") //(dataGrid1[i_row,12].ToString()=="1" || dataGrid1[i_row,13].ToString()=="1")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Số liệu đã cập nhật không thể hủy !"), LibMedi.AccessData.Msg);
                        return;
                    }
                }*/

                //Tu:19/08/2011 kiem tra benh nhan xuat khoa thi ko cho xoa //gam comment ngày 17/09/2011 --> bà rịa yêu cầu admin được quyền hủy khi bệnh nhân đã xuất khoa
                //DataRow r0 = d.getrowbyid(dthoten, "mabn='" + mabn.Text + "'");
                //if (r0 == null)
                //{
                //    MessageBox.Show(lan.Change_language_MessageText("Người bệnh đã ra khỏi khoa !"), LibMedi.AccessData.Msg);
                //    return;
                //}//end Tu

                DataTable tmp = m.getChidinh(s_ngay, l_id);
                if (tmp.Rows.Count > 0)
                {
                    if (tmp.Rows[0]["madoituong"].ToString()=="1" && tmp.Rows[0]["paid"].ToString() != "1")
                    {
                        DataTable tmp_cl = m.getChidinh_chenhlech_dathanhtoan(s_ngay, decimal.Parse(tmp.Rows[0]["maql"].ToString()), int.Parse(tmp.Rows[0]["mavp"].ToString()));
                        if (tmp_cl.Rows.Count > 0)
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Dịch vụ đã đóng tiền phần chênh lệch, không thể hủy !"), LibMedi.AccessData.Msg);
                            return;
                        }
                    }
                    if (!bAdminHethong && tmp.Rows[0]["hide"].ToString() == "1")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Phần chênh lệch dịch vụ, không hủy được, đề nghị liên hệ phòng máy tính!"), LibMedi.AccessData.Msg);
                        return;
                    }
                    if (tmp.Rows[0]["paid"].ToString() == "1" || tmp.Rows[0]["done"].ToString() == "1")//(dataGrid1[i_row,12].ToString()=="1" || dataGrid1[i_row,13].ToString()=="1")
                    {
                        //bFound = false;
                        if (tmp.Rows[0]["done"].ToString() == "1" && tmp.Rows[0]["paid"].ToString() == "0")//(dataGrid1[i_row, 13].ToString() == "1" && dataGrid1[i_row, 12].ToString() == "0")
                        {
                            //gam 26/10/2011
                            //if (!bAdminHethong)
                            //{
                            //    DataRow r = m.getrowbyid(ds.Tables[0], "id=" + l_id);
                            //    if (r != null)
                            //    {
                            //        if (int.Parse(r["madoituong"].ToString()) == i_tunguyen)
                            //            bFound = m.getrowbyid(dt, "chenhlech=1 and id=" + decimal.Parse(r["mavp"].ToString())) != null;
                            //    }
                            //}
                            //else bFound = true; 
                            //if (!bFound)
                            //{
                                MessageBox.Show(lan.Change_language_MessageText("Dịch vụ này đã thực hiện, không hủy được !"), LibMedi.AccessData.Msg);
                                return;
                            //}
                        }
                        else //da dong tien
                        {
                            if (bAdminHethong && tmp.Rows[0]["idttrv"].ToString()=="0")
                            {
                                //DialogResult dlg = MessageBox.Show(lan.Change_language_MessageText("Dịch vụ đã đóng tiền, Bạn có muốn hủy không !"), LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                                //if (dlg == DialogResult.No) return;
                            }
                            else
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Dịch vụ đã đóng tiền, không thể hủy !"), LibMedi.AccessData.Msg);
                                return;
                            }
                        }
                    }
                    //Tu:10/08/2011
                    if (tmp.Rows[0]["done"].ToString() == "2")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Số liệu đã cập nhật, không thể hủy !"), LibMedi.AccessData.Msg);
                        return;
                    }
                    //end Tu
                }
                //if (!bFound)
                //{
                //    MessageBox.Show(lan.Change_language_MessageText("Số liệu đã cập nhật không thể hủy !"), LibMedi.AccessData.Msg);
                //    return;
                //}

                DataRow r1 = d.getrowbyid(dthoten, "mabn='" + mabn.Text + "'");
                if (r1 == null && !bAdmin && !bAdminHethong)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Người bệnh đã ra khỏi khoa !"), LibMedi.AccessData.Msg);
                    return;
                }
                if (!bAdminHethong && bChidinh_dain_khongchohuy)
                {
                    if (m.get_dain_chidinh(m.mmyy(s_ngay), l_id))
                    {
                        MessageBox.Show("Đã in không có hủy !", LibMedi.AccessData.Msg);
                        return;
                    }
                }
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					l_id=decimal.Parse(dataGrid1[i_row,1].ToString());
                    string mmyy=m.mmyy(s_ngay);
                    int itable = m.tableid(mmyy, "v_chidinh");
                    m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "del", m.fields(xxx + ".v_chidinh", "id = " + l_id));
                    //
                    //                    
                    string s_field = d.f_get_select_field_mmyy(mmyy, "v_chidinh", "");
                    if (s_field != "")
                    {
                        sql = "insert into " + xxx + ".v_chidinh_huy select " + s_field + " from " + xxx + ".v_chidinh where id in(" + l_id + ",-" + l_id + ")";
                        m.execute_data(sql);
                    }
                    //
                    //
                    m.execute_data("delete from " + xxx + ".v_chidinh where id=" + l_id);
                    m.execute_data("delete from " + xxx + ".v_chidinh where id=-" + l_id);
					m.delrec(ds.Tables[0],"id="+l_id);
                    m.delrec(ds.Tables[0], "id=-" + l_id);
					ref_text();
                    
				}
			}
			catch{}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void butLietke_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) 
                return;
            i_madoituong=int.Parse(madoituong.SelectedValue.ToString());
            frmChonchidinh f = new frmChonchidinh(m, mabn.Text, i_madoituong, s_loaivp, s_mucvp, i_loai, sothe.Text, v1, v2, false, l_mavaovien);
			f.ShowDialog(this);
			if (f.dt.Rows.Count>0)
			{
				DataRow [] dr;
                DataRow rvp;
                int _madt = (madoituong.SelectedIndex != -1) ? int.Parse(madoituong.SelectedValue.ToString()) : 0;
                int tmp_madt = _madt;
				foreach(DataRow r in f.dt.Rows)
				{
                    _madt = tmp_madt;
                    madoituong.SelectedValue = _madt;
                    madoituong.Update();
					l_id=0;
					dr=dt.Select("trongoi=1 and id="+int.Parse(r["mavp"].ToString()));
                    if (_madt == 1)
                    {
                        sql = "id=" + decimal.Parse(r["mavp"].ToString()) + " and bhyt<>0";
                        if (sothe.Text.Trim().Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + sothe.Text.Trim().Substring(v1, v2) + "%' or locthe like '%" + sothe.Text.Substring(0, 2) + ",%')";
                        if (m.getrowbyid(dt, sql) == null)
                        {
                            madoituong.SelectedValue = 2;// i_tunguyen.ToString();
                            madoituong.Update();
                            _madt = 2;
                        }
                    }
                   
                    if (dr.Length > 0)
                    {
                        sql = "select a.*, b.sothe from " + user + ".v_trongoi a," + user + ".v_giavp b ";
                        sql += " where a.id_gia=b.id and a.id=" + int.Parse(r["mavp"].ToString());
                        if (madoituong.SelectedValue.ToString() == "1") sql += " and b.bhyt>0";
                        sql += " order by a.stt";
                        foreach (DataRow r1 in v.get_data(sql).Tables[0].Rows)
                        {
                            l_id = 0;
                            madoituong.SelectedValue = tmp_madt.ToString();
                            madoituong.Update();
                            if (madoituong.SelectedValue.ToString() == "1" && sothe.Text.Trim() != "" && r1["sothe"].ToString().Trim().Trim(',') != "")
                            {
                                string s_loaithe_bn = sothe.Text.Substring(0, m.iSokytuthe_xet_chiphivanchuyen);
                                if (r1["sothe"].ToString().Trim().IndexOf(s_loaithe_bn + ",") < 0)//the khong thuoc nhung The qui dinh --> BHYT khong thanh toan
                                {
                                    madoituong.SelectedValue = 2;
                                    madoituong.Update();
                                }
                            }
                            if (bChidinh_thutienlien)
                                upd_data(int.Parse(r1["id_gia"].ToString()), decimal.Parse(r1["soluong"].ToString()), (int.Parse(r1["madoituong"].ToString()) == 0) ? _madt : int.Parse(r1["madoituong"].ToString()), decimal.Parse(r1["sotien"].ToString()), int.Parse(r1["id"].ToString()));
                            else upd_data(int.Parse(r1["id_gia"].ToString()), decimal.Parse(r1["soluong"].ToString()));
                        }
                        if (l_id == 0)
                        {
                            if (bChidinh_thutienlien) upd_data(int.Parse(r["mavp"].ToString()),decimal.Parse(r["soluong"].ToString()), _madt, 0, 0);
                            else upd_data(int.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()));
                        }
                    }
                    else
                    {
                        rvp = m.getrowbyid(dt, "id=" + r["mavp"].ToString());
                        if (rvp != null)
                        {
                            if (_madt == 1 && sothe.Text.Trim() != "" && rvp["sothe"].ToString().Trim().Trim(',') != "")
                            {
                                string s_loaithe_bn = sothe.Text.Substring(0, m.iSokytuthe_xet_chiphivanchuyen);
                                if (rvp["sothe"].ToString().Trim().IndexOf(s_loaithe_bn + ",") < 0)//the khong thuoc nhung The qui dinh --> BHYT khong thanh toan
                                {
                                    madoituong.SelectedValue = 2;
                                    madoituong.Update();
                                }
                            }
                        }
                        //
                        if (bChidinh_thutienlien) upd_data(int.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), _madt, 0, 0);
                        else upd_data(int.Parse(r["mavp"].ToString()),decimal.Parse(r["soluong"].ToString()));
                    }
				}
                if (Tamung_min != 0) thongbao(false);
                m.updrec_vpkhoa(dtll, mabn.Text, hoten.Text, l_mavaovien, l_maql, l_idkhoa);
                ena_object(false);
			}
			//butLuu_Click(sender,e);
		}

		private void load_treeView()
		{
			treeView1.Nodes.Clear();
            if (nam == "" || s_ngayvao == "") return;
			TreeNode node;
				sql="select distinct b.ngay,b.mavaovien,a.maql,a.id as idkhoa from "+s_table+" a,xxx.v_chidinh b where a.id=b.idkhoa";
				sql+=" and a.mabn='"+mabn.Text+"'";
				if (iChidinh==2) sql+=" and a.maql='"+l_maql+"'";
				else if (iChidinh==3) sql+=" and a.id='"+l_idkhoa+"'";
				sql+=" order by b.ngay desc";
            
                dtngay = m.get_data_mmyy(sql, s_ngayvao, s_ngay.Substring(0, 10), false).Tables[0];// : m.get_data_nam(nam, sql).Tables[0];//gam 05/12/2011 
			foreach(DataRow r in dtngay.Rows)
			{
                node = treeView1.Nodes.Add(m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString()))+"-"+r["idkhoa"].ToString());
                sql = "select b.ten from " + user + m.mmyy(m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString()))) + ".v_chidinh a," + user + ".v_giavp b where a.mavp=b.id";
                if (l_idkhoa == 0) sql += " and a.maql=" + decimal.Parse(r["maql"].ToString());
                else sql += " and a.idkhoa=" + decimal.Parse(r["idkhoa"].ToString());
                sql += " and a.mabn='" + mabn.Text + "'";
                sql += " and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString())) + "'";//gam 22/09/2011 thêm đk hh24:mi khi add node con
                foreach (DataRow r1 in m.get_data(sql).Tables[0].Rows)
                    node.Nodes.Add(r1["ten"].ToString());
                r["ngay"] = m.StringToDateTime(m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString())));
			}
		}

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (e.Action==TreeViewAction.ByMouse)
			{
			}
		}

		private void list_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
                select_list();
			}
		}
        private void select_list()
        {
            try
            {
                DataRow r = m.getrowbyid(dt, "id=" + int.Parse(mavp.Text));
                if (r != null)
                {
                    s_dvt = r["dvt"].ToString();
                    if (madoituong.SelectedValue.ToString() == "1")
                    {
                        sql = "id=" + decimal.Parse(mavp.Text) + " and bhyt<>0";
                        if (sothe.Text.Trim().Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + sothe.Text.Trim().Substring(v1, v2) + "%' or locthe like '%" + sothe.Text.Substring(0, 2) + ",%')";
                        if (m.getrowbyid(dt, sql) == null)
                        {

                            madoituong.SelectedValue = 2;// i_tunguyen.ToString();
                            madoituong.Update();
                        }
                    }
                    string gia = m.field_gia(madoituong.SelectedValue.ToString());
                    string giavt = "vattu_" + gia.Substring(4).Trim();
                    decimal tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                    d_dongia = decimal.Parse(r[gia].ToString()) * tygia;
                    d_vattu = decimal.Parse(r[giavt].ToString()) * tygia;
                }
            }
            catch { s_dvt = ""; d_dongia = 0; d_vattu = 0; }
        }

		private void tinhtrang_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
           
		}

		private void thuchien_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
        
		}

		private void mavp_Validated(object sender, System.EventArgs e)
		{
            
		}

		private void ma_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
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
                //Filt_hoten(hoten.Text);
                //listHoten.BrowseToDanhmuc(hoten,mabn,tenbs);
			}
		}

		private void mabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void mabn_Validated(object sender, System.EventArgs e)
		{
            try
            {
                hoten.Text = ""; l_mavaovien = 0; l_maql = 0; l_idkhoa = 0; nam = ""; s_ngayvao = ""; dsngay.Clear();
                if (mabn.Text == "" || mabn.Text.Trim().Length < 3) return;
                if (mabn.Text.Trim().Length != i_maxlength_mabn) mabn.Text = mabn.Text.Substring(0, 2) + mabn.Text.Substring(2).PadLeft(6, '0');//(6,'0');
                load_mabn(mabn.Text);
                foreach (DataRow r1 in dtll.Select("mabn='" + mabn.Text + "'"))
                {
                    hoten.Text = r1["hoten"].ToString();
                    tenkhoa.Text = r1["tenkp"].ToString();
                    khoa.Text = r1["makp"].ToString();
                    s_ngayvao = r1["ngayvao"].ToString();
                    s_ngay = r1["ngayra"].ToString();
                    ngayra.Text = r1["ngayra"].ToString();
                    l_mavaovien = decimal.Parse(r1["mavaovien"].ToString());
                    l_maql = decimal.Parse(r1["maql"].ToString());
                    l_idkhoa = decimal.Parse(r1["idkhoa"].ToString());
                    i_madoituong = i_madoituongvao = d.get_madoituong(l_maql);
                    madoituong.SelectedValue = i_madoituong.ToString();
                    int dd = int.Parse(s_ngayvao.Substring(0, 2));
                    int mm = int.Parse(s_ngayvao.Substring(3, 2));
                    int yyyy = int.Parse(s_ngayvao.Substring(6, 4));
                    int hh = int.Parse(s_ngayvao.Substring(11, 2));
                    int mi = int.Parse(s_ngayvao.Substring(14, 2));
                    if (!ngayvv.Enabled) ngayvv.Value = new DateTime(yyyy, mm, dd, hh, mi, 0);
                    if (ngayvv.Enabled && ngayra.Text != "")
                    {
                        if (m.bNgaygio(m.ngayhienhanh_server, s_ngayvao))
                            ngayvv.Value = new DateTime(yyyy, mm, dd, hh, mi, 0);
                    }
                    m.updrec_ravien(dsngay, mabn.Text, l_mavaovien, l_maql, l_idkhoa, hoten.Text, r1["namsinh"].ToString(), (r1["phai"].ToString() == "0") ? "Nam" : "Nữ", r1["sonha"].ToString().Trim() + " " + r1["thon"].ToString().Trim(), i_madoituong, "", "",
                            "", "", "", "", r1["makp"].ToString(), r1["tenkp"].ToString(), s_ngayvao, s_ngay, "", "", "", 0, 0, 0, "", "", "", "", 0);
                }

                if (l_maql == 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Người bệnh không hợp lệ !"), LibMedi.AccessData.Msg);
                    mabn.Focus();
                }
                else
                {
                    ngayvao.SelectedIndex = 0;
                }
               
            }
            catch { }
		}

		private void listHoten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				mabn_Validated(null,null);
			}
		}

		private void load_head()
		{
            if (l_idkhoa != 0)
                r = m.getrowbyid(dtll, "idkhoa=" + l_idkhoa);
			if (r!=null)
			{
				mabn.Text=r["mabn"].ToString();
				hoten.Text=r["hoten"].ToString();
                l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
				l_maql=decimal.Parse(r["maql"].ToString());
                DataRow r1 = d.getrowbyid(dthoten, "mabn='" + mabn.Text + "'");
                if (r1 != null)
                {
                    nam = r1["nam"].ToString();
                    s_ngayvao = r1["ngay"].ToString();
                    sothe.Text = r1["sothe"].ToString();
                }
			}
			else l_idkhoa=0;
			load_grid(l_maql,l_idkhoa);
		}
		private void upd_data(int i_mavp,decimal d_soluong)
		{
            DataRow r = m.getrowbyid(ds.Tables[0], "id=" + l_id);
            if (r != null)
            {
                if (r["done"].ToString() == "1" || r["paid"].ToString() == "1")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Số liệu đã cập nhật không thể hủy !"), LibMedi.AccessData.Msg);
                    return;
                }
            }
			r=m.getrowbyid(dt,"id="+i_mavp);
			if (r!=null)
			{
                int itable = m.tableid(m.mmyy(s_ngay), "v_chidinh");
                if (l_id == 0)
                {
                    l_id = v.get_id_chidinh;
                    m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
                }
                else
                {
                    m.upd_eve_tables(s_ngay, itable, i_userid, "upd");
                    //m.upd_eve_upd_del(s_ngay, itable, i_userid, "upd", l_id.ToString() + "^" + mabn.Text + "^" + l_mavaovien.ToString() + "^" + l_maql.ToString() + "^" + l_idkhoa.ToString() + "^" + s_ngay + "^" + i_loai.ToString() + "^" + s_makp + "^" + madoituong.SelectedValue.ToString() + "^" + i_mavp.ToString() + "^" + d_soluong.ToString() + "^" + d_dongia.ToString() + "^" + d_vattu.ToString() + "^" + i_userid.ToString() + "^" + tinhtrang.SelectedValue.ToString() + "^" + thuchien.SelectedValue.ToString());
                }              
                string gia = m.field_gia(madoituong.SelectedValue.ToString());
                string giavt = "vattu_" + gia.Substring(4).Trim();
                decimal tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                d_dongia = decimal.Parse(r[gia].ToString()) * tygia;
                d_vattu = decimal.Parse(r[giavt].ToString()) * tygia;
                string giosrv = m.ngayhienhanh_server.Substring(11);
                //if (!v.upd_chidinh(l_id,mabn.Text,l_mavaovien,l_maql,l_idkhoa,s_ngay.Substring(0,10)+" "+giosrv,i_loai,s_makp,int.Parse(madoituong.SelectedValue.ToString()),i_mavp,d_soluong,d_dongia,d_vattu,i_userid,int.Parse(tinhtrang.SelectedValue.ToString()),int.Parse(thuchien.SelectedValue.ToString()),l_idchidinh,maicd.Text,chandoan.Text,mabs.Text,1,ghichu.Text))
                //{
                //    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin chỉ định !"),LibMedi.AccessData.Msg);
                //    return;
                //}
                //m.execute_data("update " + m.user + m.mmyy(s_ngay.Substring(0, 10)) + ".v_chidinh set traituyen=" + i_traituyen + ",tylegiam=" + (tylegiam.Text.Trim() == "" ? 0 : decimal.Parse(tylegiam.Text)) + ",stgiam=" + (stgiam.Text.Trim() == "" ? 0 : decimal.Parse(stgiam.Text)) + ",lydogiam='" + lydogiam.Text + "',dachenhlech=0  where id =" + l_id);//gam 16/11/2011
                if (bChidinh_exp_txt) m.exp_chidinh(m.mmyy(s_ngay), l_id.ToString(), "0");
                //m.updrec_chidinh(ds.Tables[0], l_id, s_ngay.Substring(0, 10) + " " + giosrv, s_makp, s_tenkp, int.Parse(madoituong.SelectedValue.ToString()), madoituong.Text, i_mavp, r["ten"].ToString(), r["dvt"].ToString(), d_soluong, d_dongia, d_vattu, 0, 0, int.Parse(tinhtrang.SelectedValue.ToString()), int.Parse(thuchien.SelectedValue.ToString()), r["ma"].ToString(), maicd.Text, chandoan.Text, mabs.Text, 1, ghichu.Text, (tylegiam.Text.Trim() == "" ? 0 : decimal.Parse(tylegiam.Text)), (stgiam.Text.Trim() == "" ? 0 : decimal.Parse(stgiam.Text)), lydogiam.Text);
                DataRow[] dr = ds.Tables[0].Select("id=" + l_id);
                if (dr.Length > 0) dr[0]["chon"] = true;
			}
        }
        private void upd_data_cholai(int i_mavp, decimal d_soluong)
        {
            DataRow r = m.getrowbyid(ds.Tables[0], "id=" + l_id);
            if (r != null)
            {
                if (r["done"].ToString() == "1" || r["paid"].ToString() == "1")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Số liệu đã cập nhật không thể hủy !"), LibMedi.AccessData.Msg);
                    return;
                }
            }
            r = m.getrowbyid(dt, "id=" + i_mavp);
            if (r != null)
            {
                int itable = m.tableid(m.mmyy(s_ngay), "v_chidinh");
                if (l_id == 0)
                {
                    l_id = v.get_id_chidinh;
                    m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
                }
                else
                {
                }
                string gia = m.field_gia(madoituong.SelectedValue.ToString());
                string giavt = "vattu_" + gia.Substring(4).Trim();
                decimal tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                d_dongia = decimal.Parse(r[gia].ToString()) * tygia;
                d_vattu = decimal.Parse(r[giavt].ToString()) * tygia;
                string giosrv = m.ngayhienhanh_server.Substring(11);
                if (bChidinh_exp_txt) m.exp_chidinh(m.mmyy(s_ngay), l_id.ToString(), "0");
                //m.updrec_chidinh(ds.Tables[0], l_id, s_ngay.Substring(0, 10) + " " + giosrv, s_makp, s_tenkp, int.Parse(madoituong.SelectedValue.ToString()), madoituong.Text, i_mavp, r["ten"].ToString(), r["dvt"].ToString(), d_soluong, d_dongia, d_vattu, 0, 0, int.Parse(tinhtrang.SelectedValue.ToString()), int.Parse(thuchien.SelectedValue.ToString()), r["ma"].ToString(), maicd.Text, chandoan.Text, mabs.Text, 1, ghichu.Text, (tylegiam.Text.Trim() == "" ? 0 : decimal.Parse(tylegiam.Text)), (stgiam.Text.Trim() == "" ? 0 : decimal.Parse(stgiam.Text)), lydogiam.Text);
                DataRow[] dr = ds.Tables[0].Select("id=" + l_id);
                if (dr.Length > 0) dr[0]["chon"] = true;
            }
        }

		private void butIn_Click(object sender, System.EventArgs e)
		{
            
		}

        private void ghichu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void load_congno()
        {
            if (i_vienphi != 4)
            {
                decimal congno = d.congno(i_vienphi, mabn.Text, l_maql, l_idkhoa);
                if (congno == 0) this.Text = s_title;
                else
                {
                    if (congno > 0) this.Text = s_title + ",Thiếu :" + congno.ToString("###,###,###,##0.00");
                    else
                    {
                        congno = Math.Abs(congno);
                        this.Text = s_title + ",Thừa :" + congno.ToString("###,###,###,##0.00");
                    }
                }
            }
        }

        //
        private void thongbao(bool skip)
        {
            if (Tamung_min != 0)
            {
                string s = m.get_chiphi_mabn(mabn.Text, (i_loaiba == 2) ? l_mavaovien : l_maql, i_loaiba, false);
                string[] a_chiphi = s.Split('~');
                chiphi = decimal.Parse(a_chiphi[0]);// (s.Substring(0, s.IndexOf("~")));
                tamung = decimal.Parse(a_chiphi[1]);//s.Substring(s.IndexOf("~") + 1));
                decimal bhyttra = decimal.Parse(a_chiphi[2]);//s.Substring(s.IndexOf("~") + 1));
                decimal bntra = decimal.Parse(a_chiphi[3]);
                decimal conlai =tamung +bhyttra- chiphi;//chi phi -tamung - bhyttra;
                if (conlai < Tamung_min && !skip)
                {
                    s = "Tổng chi phí :" + chiphi.ToString("### ### ### ### ###").PadLeft(20, ' ') + "\n";
                    s += "Tạm ứng      :" + tamung.ToString("### ### ### ### ###").PadLeft(20, ' ') + "\n";
                    s += "BHYT Trả      :" + bhyttra.ToString("### ### ### ### ###").PadLeft(20, ' ') + "\n";
                    s += "BN phải Trả      :" + bntra.ToString("### ### ### ### ###").PadLeft(20, ' ') + "\n";
                    if (conlai > 0)
                    {
                        s += "BN Thừa tiền    :" + conlai.ToString("### ### ### ### ###").PadLeft(20, ' ') + "\n\n";
                        s += "Yêu cầu người bệnh đóng tạm ứng !";
                    }
                    else
                    {
                        conlai = conlai * -1;
                        s += "Còn thiếu    :" + conlai.ToString("### ### ### ### ###").PadLeft(20, ' ') + "\n\n";
                    }
                    
                    MessageBox.Show(s, LibMedi.AccessData.Msg);
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void mnu_thongbaochiphi_Click(object sender, EventArgs e)
        {
            //m.writeXml("thongso", "thongbaochiphi_cd", mnu_thongbaochiphi.Checked ? "1" : "0");
        }

        private void tmn_xemlaichidinh_Click(object sender, EventArgs e)
        {
            iChidinh = 0;
            load_treeView();
        }
        private bool get_nhomvp_pttt(int i_mavp)
        {
            bool bln = false;
            string sexp = "id=" + i_mavp;
            if (i_nhomvp_pttt.Trim().Trim(',') != "") sexp += " and id_nhom in(" + i_nhomvp_pttt.Trim().Trim(',') + ")";
            DataRow dr = m.getrowbyid(dt, sexp);// "id=" + i_mavp + " and id_nhom=" + i_nhomvp_pttt);
            bln = dr != null;
            return bln;
        }

        private void f_capnhat_db()
        {
            string xxx = m.user + m.mmyy(s_ngay);
            string asql = "select tylegiam from " + xxx + ".v_chidinh where 1=2";
            DataSet lds = m.get_data(asql);
            bool bln = (lds==null || lds.Tables.Count==0);
            if (bln)
            {
                asql = "alter table " + xxx + ".v_chidinh add tylegiam numeric(5,2) default 0";
                m.execute_data(asql, false);
                asql = "alter table " + xxx + ".v_chidinh add stgiam numeric(18) default 0";
                m.execute_data(asql, false);
                asql = "alter table " + xxx + ".v_chidinh add lydogiam text";
                m.execute_data(asql, false);
            }
            asql = "select id from " + xxx + ".v_chidinh_huy where 1=2";
            lds = m.get_data(asql);
            bln = false;
            bln = (lds==null || lds.Tables.Count==0);
            if (bln)
            {
                asql = "create table " + xxx + ".v_chidinh_huy as select * from " + xxx + ".v_chidinh where 1=2";
                m.execute_data(asql, false);
            }
            asql = "select dachenhlech from " + xxx + ".v_chidinh where 1=2";
            lds = m.get_data(asql);
            if (lds != null && lds.Tables.Count <= 0)
            {
                asql = " alter table " + xxx + ".v_chidinh add dachenhlech number(1) default 0";
                m.execute_data(asql);
                asql = " alter table " + xxx + ".v_vpkhoa add dachenhlech number(1) default 0";
                m.execute_data(asql);
            }
        }
        private void tmn_hienthichenhlech_Click(object sender, EventArgs e)
        {
            //load_grid(l_maql, l_idkhoa);
            //m.writeXml("thongso", "chidinh_chenhlech", tmn_hienthichenhlech.Checked ? "1" : "0");
        }

        private void list_DoubleClick(object sender, EventArgs e)
        {
            select_list();
        }

        private void Kiemsoatdv_Load(object sender, EventArgs e)
        {
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            i_maxlength_mabn = LibMedi.AccessData.i_maxlength_mabn;
            mabn.MaxLength = i_maxlength_mabn;
            bNhapten = m.bNhapthuoc_ten;
            bMadoituong = m.bSuadt_thuoc_vp;
            user = m.user;
            ngayra.Text = m.Ngaygio_hienhanh;
            string sql = "select * from " + user + ".btdkp_bv where makp<>'01' and loai=0";
            if (s_makp != "")
            {
                smakp = s_makp.Replace(",", "','");
                if (smakp.Length > 3) smakp = smakp.Substring(0, smakp.Length - 3);
                sql += " and makp in ('" + smakp + "')";
            }
            sql += " order by makp";
            tenkhoa.DisplayMember = "TENKP";
            tenkhoa.ValueMember = "MAKP";
            dtkp = m.get_data(sql).Tables[0];
            tenkhoa.DataSource = dtkp;

            lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString() + "_" + dataGrid1.Name.ToString());
            lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString() + "_" + dataGrid1.Name.ToString());
            this.disabledBackBrush = new SolidBrush(Color.Black);
            this.disabledTextBrush = new SolidBrush(Color.Red);
            this.disabledTextBrush1 = new SolidBrush(Color.Chocolate);

            this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
            this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
            this.alertTextBrush = new SolidBrush(Color.White);

            this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
            this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0, 255, 255));
            load_grid(0, 0);
            butMoi_Click(null, null);
            AddGridTableStyle();

            s_ngay = ngayra.Text.Substring(0, 10);
            //sql = "select a.mabn,b.hoten,a.id,c.mavaovien,a.maql,c.madoituong,d.sothe,b.nam,to_char(c.ngay,'dd/mm/yyyy') as ngay,coalesce(to_char(d.ngaygiahan,'dd/mm/yyyy'),to_char(d.denngay,'dd/mm/yyyy')) as denngay,e.mabs,e.chandoan,e.maicd, nvl(to_char(d.tungay,'dd/mm/yyyy'),to_char(c.ngay,'dd/mm/yyyy')) as tungay, nvl(d.traituyen,0) as traituyen ";
            //sql += " from " + user + ".hiendien a inner join " + user + ".btdbn b on a.mabn=b.mabn ";
            //sql += " inner join " + user + ".benhandt c on a.maql=c.maql ";
            //sql += " left join " + user + ".bhyt d on a.maql=d.maql ";
            //sql += " inner join " + user + ".nhapkhoa e on a.id=e.id ";
            //sql += " where 1=1 ";
            //if (s_makp != "") sql += " and a.makp in ('" + smakp + "')";
            //sql += " and substr(a.ngay,1,10)<=to_date('" + s_ngay + "','" + m.f_ngay + "')";
            //sql += " and (d.sudung is null or d.sudung=1)";
            //sql += " order by a.id desc";
            //dthoten = m.get_data(sql).Tables[0];

            dsngay.ReadXml("..//..//..//xml//m_ngayvao.xml");
            dsngay.Tables[0].Columns.Add("mabs");
            dsngay.Tables[0].Columns.Add("tenbs");
            dsngay.Tables[0].Columns.Add("cholam");
            try
            {
                dsngay.Tables[0].Columns.Add("MAVAOVIEN", typeof(decimal));
            }
            catch { }
            dsngay.Tables[0].Columns.Add("traituyen", typeof(decimal));
            ngayvao.DisplayMember = "NGAYVAO";
            ngayvao.ValueMember = "NGAYVAO";
            ngayvao.DataSource = dsngay.Tables[0];

            madoituong.DisplayMember = "DOITUONG";
            madoituong.ValueMember = "MADOITUONG";
            madoituong.DataSource = m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a order by madoituong").Tables[0];
            try
            {
                madoituong.SelectedValue = i_madoituong.ToString();
            }
            catch { }
        }

        private void Kiemsoatdv_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void tenkhoa_TextChanged(object sender, EventArgs e)
        {
            if (tenkhoa.Text != "")
            {
                foreach(DataRow r in dtkp.Select("tenkp='"+tenkhoa.Text+"'"))
                {
                    khoa.Text = r["makp"].ToString();
                }
            }
        }

        private void khoa_TextChanged(object sender, EventArgs e)
        {
            if (khoa.Text != "")
            {
                foreach (DataRow r in dtkp.Select("makp='" + khoa.Text + "'"))
                {
                    tenkhoa.Text = r["tenkp"].ToString();
                }
            }
        }

        private void ngayvao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == ngayvao && ngayvao.SelectedIndex != -1)
            {
                ngayra.Text = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ngayra"].ToString();
                khoa.Text = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["makp"].ToString();
                tenkhoa.Text = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["tenkp"].ToString();
                madoituong.SelectedValue = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["madoituong"].ToString();
                l_mavaovien = decimal.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["mavaovien"].ToString());
                l_maql = decimal.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString());
                l_idkhoa = decimal.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["idkhoa"].ToString());
                //if (sothe.Text!="") maphu.SelectedIndex=d.get_maphu(sothe.Text);
                int dd = int.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ngayvao"].ToString().Substring(0, 2));
                int mm = int.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ngayvao"].ToString().Substring(3, 2));
                int yyyy = int.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ngayvao"].ToString().Substring(6, 4));
                int hh = int.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ngayvao"].ToString().Substring(11, 2));
                int mi = int.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ngayvao"].ToString().Substring(14, 2));
                ngayvv.Value = new DateTime(yyyy, mm, dd, hh, mi, 0);
                ena_object(true);
            }
        }

        private void ngayvao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void ngayvv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void ngayra_Validated(object sender, EventArgs e)
        {
            if (ngayra.Text == "")
            {
                ngayra.Focus();
                return;
            }
            ngayra.Text = ngayra.Text.Trim();
            if (ngayra.Text.Length < 16)
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày và giờ !"), LibMedi.AccessData.Msg);
                ngayra.Focus();
                return;
            }
            if (!m.bNgay(ngayra.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
                ngayra.Focus();
                return;
            }
            //
            //
            ngayra.Text = m.Ktngaygio(ngayra.Text, 16);
        }

        private void tenkhoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tenkhoa.Items.Count > 0 && tenkhoa.SelectedIndex == -1) tenkhoa.SelectedIndex = 0;
                khoa.Text = tenkhoa.SelectedValue.ToString();
                SendKeys.Send("{Tab}");
            }
        }

        private void khoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tenkhoa.SelectedValue = khoa.Text;
                SendKeys.Send("{Tab}{F4}");
            }
        }
	}
}
