using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibVienphi;
using LibDuoc;

namespace dllvpkhoa_chidinh
{
	/// <summary>
	/// Summary description for frmChidinh.
	/// </summary>
	public class frmTamung : System.Windows.Forms.Form
	{
		Language lan = new Language();
		//
		decimal o_id=0;//binh: de giu lai IDkhoa cua BN, khi kich nut bo qua thi lay lai ngay BN do
        private int i_maxlength_mabn = 8;
        private bool bQuanly_Theo_Chinhanh = false;
		//
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox madoituong;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox ten;
		private System.Windows.Forms.Label label6;
		private MaskedTextBox.MaskedTextBox soluong;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tenkp;
		private System.Windows.Forms.TextBox mavp;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butKetthuc;
		private LibMedi.AccessData m;
		private LibVienphi.AccessData v;
        private dllReportM.Print print = new dllReportM.Print();
		private string mmyy,s_ngay,s_makp,s_tenkp,sql,s_title,s_ngayvv="",nam,s_denngay="",user;
		private int i_madoituong,i_done,i_row=0,i_userid,i_loai,i_loaibn,i_vienphi, tmp_loaiba=1;
		private decimal l_maql=0,l_idkhoa=0,l_id,l_mavaovien;
		private decimal d_soluong,d_tamung_min;
		private bool bNew,bNhapten,bAdmin,bThongbao;
		private DataSet ds=new DataSet();
		private DataTable dtngay=new DataTable();
		private DataTable dtkp=new DataTable();
		private DataTable dtll=new DataTable();
		private DataTable dtdt=new DataTable();
		private DataTable dthoten=new DataTable();
		private System.Windows.Forms.ComboBox cmbMabn;
		private DataRow r;
		private System.Windows.Forms.Button butThem;
		private System.Windows.Forms.CheckBox chkTree;
		private System.Windows.Forms.TextBox sothe;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.CheckBox chkmadoituong;
		private System.Windows.Forms.Label lblsum;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.TextBox ngay123;
		private LibList.List listHoten;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.CheckBox chkXem;
		private System.Windows.Forms.CheckBox chkXML;
        private CheckBox chkNo;
		private System.ComponentModel.IContainer components;

		public frmTamung(LibMedi.AccessData acc,string ngay,string makp,string tenkp,int userid,int loai,int loaibn,bool admin)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			m=acc;
			v=new LibVienphi.AccessData();
			s_ngay=ngay;s_makp=makp;s_tenkp=tenkp;
			i_userid=userid;i_loai=loai;i_loaibn=loaibn;bAdmin=admin;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTamung));
            this.label1 = new System.Windows.Forms.Label();
            this.mabn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hoten = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label4 = new System.Windows.Forms.Label();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ten = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.soluong = new MaskedTextBox.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tenkp = new System.Windows.Forms.TextBox();
            this.mavp = new System.Windows.Forms.TextBox();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.cmbMabn = new System.Windows.Forms.ComboBox();
            this.butThem = new System.Windows.Forms.Button();
            this.chkTree = new System.Windows.Forms.CheckBox();
            this.sothe = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkmadoituong = new System.Windows.Forms.CheckBox();
            this.lblsum = new System.Windows.Forms.Label();
            this.ngay123 = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.listHoten = new LibList.List();
            this.butIn = new System.Windows.Forms.Button();
            this.chkXem = new System.Windows.Forms.CheckBox();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.chkNo = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(56, 8);
            this.mabn.MaxLength = 8;
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(80, 21);
            this.mabn.TabIndex = 1;
            this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
            this.mabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(136, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(184, 8);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(232, 21);
            this.hoten.TabIndex = 3;
            this.hoten.TextChanged += new System.EventHandler(this.hoten_TextChanged);
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(656, 54);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(136, 318);
            this.treeView1.TabIndex = 19;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
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
            this.dataGrid1.Location = new System.Drawing.Point(5, 14);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(648, 375);
            this.dataGrid1.TabIndex = 70;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Location = new System.Drawing.Point(0, 393);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Đối tượng :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madoituong
            // 
            this.madoituong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.madoituong.Enabled = false;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(64, 395);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(136, 21);
            this.madoituong.TabIndex = 4;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Location = new System.Drawing.Point(168, 395);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "Nội dung :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ten
            // 
            this.ten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(256, 395);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(344, 21);
            this.ten.TabIndex = 5;
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(584, 395);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "Số tiền :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // soluong
            // 
            this.soluong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(656, 395);
            this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(136, 21);
            this.soluong.TabIndex = 6;
            this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(424, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 23);
            this.label7.TabIndex = 15;
            this.label7.Text = "Khoa :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenkp
            // 
            this.tenkp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkp.Enabled = false;
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(496, 8);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(112, 21);
            this.tenkp.TabIndex = 16;
            // 
            // mavp
            // 
            this.mavp.Enabled = false;
            this.mavp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mavp.Location = new System.Drawing.Point(104, 224);
            this.mavp.Name = "mavp";
            this.mavp.Size = new System.Drawing.Size(24, 21);
            this.mavp.TabIndex = 17;
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(129, 440);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 9;
            this.butMoi.Text = "     &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(269, 440);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 10;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(339, 440);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 7;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(409, 440);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 8;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(479, 440);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 12;
            this.butHuy.Text = "      &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(619, 440);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 13;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // cmbMabn
            // 
            this.cmbMabn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMabn.Location = new System.Drawing.Point(56, 8);
            this.cmbMabn.Name = "cmbMabn";
            this.cmbMabn.Size = new System.Drawing.Size(80, 21);
            this.cmbMabn.TabIndex = 2;
            this.cmbMabn.SelectedIndexChanged += new System.EventHandler(this.cmbMabn_SelectedIndexChanged);
            this.cmbMabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMabn_KeyDown);
            // 
            // butThem
            // 
            this.butThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butThem.Enabled = false;
            this.butThem.Image = ((System.Drawing.Image)(resources.GetObject("butThem.Image")));
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(199, 440);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(70, 25);
            this.butThem.TabIndex = 11;
            this.butThem.Text = "&Thêm";
            this.butThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // chkTree
            // 
            this.chkTree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTree.Location = new System.Drawing.Point(656, 29);
            this.chkTree.Name = "chkTree";
            this.chkTree.Size = new System.Drawing.Size(148, 24);
            this.chkTree.TabIndex = 22;
            this.chkTree.Text = "Liệt kê các ngày nhập";
            this.chkTree.CheckedChanged += new System.EventHandler(this.chkTree_CheckedChanged);
            // 
            // sothe
            // 
            this.sothe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(656, 8);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(136, 21);
            this.sothe.TabIndex = 71;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Location = new System.Drawing.Point(608, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 23);
            this.label8.TabIndex = 72;
            this.label8.Text = "Số thẻ :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkmadoituong
            // 
            this.chkmadoituong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkmadoituong.Enabled = false;
            this.chkmadoituong.Location = new System.Drawing.Point(657, 375);
            this.chkmadoituong.Name = "chkmadoituong";
            this.chkmadoituong.Size = new System.Drawing.Size(112, 17);
            this.chkmadoituong.TabIndex = 73;
            this.chkmadoituong.Text = "Đối tượng khi vào";
            this.chkmadoituong.CheckedChanged += new System.EventHandler(this.chkmadoituong_CheckedChanged);
            // 
            // lblsum
            // 
            this.lblsum.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsum.ForeColor = System.Drawing.Color.Red;
            this.lblsum.Location = new System.Drawing.Point(416, 8);
            this.lblsum.Name = "lblsum";
            this.lblsum.Size = new System.Drawing.Size(38, 23);
            this.lblsum.TabIndex = 77;
            this.lblsum.Text = "0";
            this.lblsum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ngay123
            // 
            this.ngay123.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ngay123.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay123.Enabled = false;
            this.ngay123.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay123.Location = new System.Drawing.Point(656, 297);
            this.ngay123.Name = "ngay123";
            this.ngay123.Size = new System.Drawing.Size(136, 21);
            this.ngay123.TabIndex = 78;
            this.toolTip1.SetToolTip(this.ngay123, "Ngày bắt đầu được hưởng chi phí dịch vụ kỹ thuật cao, chăm sóc thai sản,...");
            this.ngay123.Visible = false;
            // 
            // listHoten
            // 
            this.listHoten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listHoten.BackColor = System.Drawing.SystemColors.Info;
            this.listHoten.ColumnCount = 0;
            this.listHoten.Location = new System.Drawing.Point(672, 469);
            this.listHoten.MatchBufferTimeOut = 1000;
            this.listHoten.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listHoten.Name = "listHoten";
            this.listHoten.Size = new System.Drawing.Size(75, 17);
            this.listHoten.TabIndex = 79;
            this.listHoten.TextIndex = -1;
            this.listHoten.TextMember = null;
            this.listHoten.ValueIndex = -1;
            this.listHoten.Visible = false;
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(549, 440);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 80;
            this.butIn.Text = "      &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // chkXem
            // 
            this.chkXem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkXem.Checked = true;
            this.chkXem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkXem.Location = new System.Drawing.Point(16, 437);
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(112, 24);
            this.chkXem.TabIndex = 81;
            this.chkXem.Text = "Xem trước khi in";
            // 
            // chkXML
            // 
            this.chkXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkXML.Location = new System.Drawing.Point(707, 437);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(85, 24);
            this.chkXML.TabIndex = 82;
            this.chkXML.Text = "Xuất ra XML";
            // 
            // chkNo
            // 
            this.chkNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkNo.Enabled = false;
            this.chkNo.Location = new System.Drawing.Point(707, 417);
            this.chkNo.Name = "chkNo";
            this.chkNo.Size = new System.Drawing.Size(45, 24);
            this.chkNo.TabIndex = 83;
            this.chkNo.Text = "Nợ";
            // 
            // frmTamung
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(794, 487);
            this.Controls.Add(this.chkNo);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.chkXem);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.listHoten);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.lblsum);
            this.Controls.Add(this.chkmadoituong);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.soluong);
            this.Controls.Add(this.chkTree);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.cmbMabn);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.tenkp);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.mavp);
            this.Controls.Add(this.ngay123);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTamung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chỉ định tạm ứng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTamung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTamung_Load(object sender, System.EventArgs e)
		{
            mmyy = m.mmyy(s_ngay); user = m.user; bThongbao = false;
			d_tamung_min=m.Tamung_min;i_vienphi=m.iVienphi;
            i_maxlength_mabn = LibMedi.AccessData.i_maxlength_mabn;
            mabn.MaxLength = i_maxlength_mabn;
			tenkp.Text=s_tenkp;
			s_title=this.Text;
			bNhapten=m.bNhapthuoc_ten;
			chkmadoituong.Checked=!m.bSuadt_thuoc_vp;
            dthoten = m.get_hiendien(s_makp, s_ngay, i_loaibn ).Tables[0];
			listHoten.DisplayMember="MABN";
			listHoten.ValueMember="HOTEN";
			listHoten.DataSource=dthoten;

			dtkp=m.get_data("select * from "+user+".btdkp_bv where makp='"+s_makp+"'").Tables[0];
            dtdt = m.get_data("select * from " + user + ".doituong where sothe>0 and ngay>0").Tables[0];
			madoituong.DisplayMember="DOITUONG";
			madoituong.ValueMember="MADOITUONG";
            madoituong.DataSource = m.get_data("select * from " + user + ".doituong order by madoituong").Tables[0];
			try
			{
				madoituong.SelectedValue=i_madoituong.ToString();
			}
			catch{}
			cmbMabn.DisplayMember="MABN";
			cmbMabn.ValueMember="IDKHOA";
			load_mabn();
            cmbMabn_SelectedIndexChanged(null, null);
			load_head();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
            bQuanly_Theo_Chinhanh = m.bQuanly_Theo_Chinhanh;
		}

		private void load_mabn()
		{
			sql="select distinct a.mabn,b.hoten,a.mavaovien,a.maql,a.idkhoa,a.no from "+user+mmyy+".v_tamungcd a,"+user+".btdbn b ";
            sql+=" where a.mabn=b.mabn and a.makp='"+s_makp+"'"+" and to_char(a.ngay,'dd/mm/yyyy')='"+s_ngay+"'";
            if (i_loaibn != 3) sql += " and a.loaibn=" + i_loaibn;
            else sql += " and a.loaibn in(0," + i_loaibn + ")";
			dtll=m.get_data(sql).Tables[0];
			cmbMabn.DataSource=dtll;
			if (cmbMabn.Items.Count>0) l_idkhoa=decimal.Parse(cmbMabn.SelectedValue.ToString());
			else l_idkhoa=0;
			lblsum.Text=dtll.Rows.Count.ToString();
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
			TextCol1.MappingName = "tenkp";
			TextCol1.HeaderText = "Khoa/phòng";
			TextCol1.Width = 80;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 2);
			TextCol1.MappingName = "ngay";
			TextCol1.HeaderText = "Ngày";
			TextCol1.Width =70;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 3);
			TextCol1.MappingName = "doituong";
			TextCol1.HeaderText = "Đối tượng";
			TextCol1.Width = 88;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 4);
			TextCol1.MappingName = "ten";
			TextCol1.HeaderText = "Nội dung";
			TextCol1.Width = 310;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 5);
			TextCol1.MappingName = "sotien";
			TextCol1.HeaderText = "Số tiền";
			TextCol1.Width = 80;
			TextCol1.Format="### ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 6);
			TextCol1.MappingName = "done";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 7);
            TextCol1.MappingName = "user";
            TextCol1.HeaderText = "";
            TextCol1.Width = 100;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			return (this.dataGrid1[row,6].ToString().Trim()=="1")?Color.Red:Color.Black;
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
		private void load_grid(string ngay,decimal idkhoa)
		{
			sql="select a.id,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.makp,d.tenkp,a.madoituong,c.doituong,a.ten,";
            sql+="a.sotien,a.done,a.maql,a.idkhoa,a.mavaovien,e.hoten as user";
			sql+=" from "+user+mmyy+".v_tamungcd a,"+user+".doituong c,"+user+".btdkp_bv d,"+user+".dlogin e ";
			sql+=" where a.madoituong=c.madoituong and a.makp=d.makp and a.userid=e.id ";
            sql += " and a.mabn='" + mabn.Text + "'";
            sql += " and a.makp='" + s_makp + "'";
			if (ngay!="") sql+=" and to_char(a.ngay,'dd/mm/yyyy')='"+ngay.Substring(0,10)+"'";
			if (idkhoa!=0) sql+=" and a.idkhoa="+idkhoa;
            if (i_loaibn != 3)
            {
                sql += " and a.loaibn=" + i_loaibn;
            }
            else sql += " and a.loaibn in(0," + i_loaibn + ")"; 
			sql+=" order by a.ngay";
			ds=m.get_data(sql);
			dataGrid1.DataSource=ds.Tables[0];
		}

		private void madoituong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (madoituong.SelectedIndex==-1) madoituong.SelectedIndex=0;
				DataRow r=m.getrowbyid(dthoten,"mabn='"+mabn.Text+"'");
				if (r!=null)
				{
					if (int.Parse(madoituong.SelectedValue.ToString())!=int.Parse(r["madoituong"].ToString()))
					{
						if (MessageBox.Show(lan.Change_language_MessageText("Không đúng so với đối tượng ban đầu\nBạn có muốn lấy đối tượng ban đầu ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
							madoituong.SelectedValue=r["madoituong"].ToString();
					}
				}
				SendKeys.Send("{Tab}");
			}
		}

		private void soluong_Validated(object sender, System.EventArgs e)
		{
			try
			{
				d_soluong=decimal.Parse(soluong.Text);
				soluong.Text=d_soluong.ToString("###,###,###,###");
			}
			catch{soluong.Text="";}
		}

		private void ref_text()
		
        {
			try
			{							
				i_row=dataGrid1.CurrentCell.RowNumber;
				l_id=decimal.Parse(dataGrid1[i_row,0].ToString());
				DataRow r=m.getrowbyid(ds.Tables[0],"id="+l_id);
				if (r!=null)
				{
					madoituong.SelectedValue=r["madoituong"].ToString();
					ten.Text=r["ten"].ToString();
					i_done=int.Parse(r["done"].ToString());
					d_soluong=decimal.Parse(r["sotien"].ToString());
					soluong.Text=d_soluong.ToString("###,###.00");
					l_maql=decimal.Parse(r["maql"].ToString());
                    l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
					l_idkhoa=decimal.Parse(r["idkhoa"].ToString());
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
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember];  
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false;
			cmbMabn.Visible=!ena;
			mabn.Enabled=ena;
            if (bNhapten && i_loaibn != 3) hoten.Enabled = ena;//Thuy 27.12.2011 sửa i_loaibn ==1 thành != 3(không fai bn phong kham)
            else hoten.Enabled = false;
			if (!chkmadoituong.Checked) madoituong.Enabled=ena;
			ten.Enabled=ena;
			chkmadoituong.Enabled=ena;
			soluong.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butThem.Enabled=ena;
			butIn.Enabled=!ena;
			chkXem.Enabled=!ena;
			chkXML.Enabled=!ena;
            chkNo.Enabled = ena;
			if (ena && l_id==0)
			{
				ten.Text="Tạm ứng";ngay123.Text="";
				i_done=0;
				l_mavaovien=l_maql=l_idkhoa=0;
				soluong.Text=hoten.Text=sothe.Text=mabn.Text="";ds.Clear();
                chkNo.Checked = false;
			}
			else butMoi.Focus();
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			if (bThongbao)
			{
				string ngay_server=m.ngayhienhanh_server.Substring(0,10);
				if (s_ngay!=ngay_server)
					MessageBox.Show("Ngày làm việc :"+s_ngay+"\nKhác ngày hiện hành :"+ngay_server,LibMedi.AccessData.Msg);
			}
			o_id=(cmbMabn.SelectedIndex<0)?0:decimal.Parse(cmbMabn.SelectedValue.ToString());
			l_id=0;
			bNew=true;
			ena_object(true);
			mabn.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
			try
			{
				if (m.bRavien(l_maql) && i_loaibn==0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Người bệnh đã ra viện !"),LibMedi.AccessData.Msg);
					mabn.Focus();
					return;
				}
				if (!bAdmin)
				{
					r=m.getrowbyid(dthoten,"mabn='"+mabn.Text+"'");
					if (r==null)
					{
						MessageBox.Show("Người bệnh này không còn hiện diện !",LibMedi.AccessData.Msg);
						return;
					}
				}
				i_row=dataGrid1.CurrentCell.RowNumber;
				l_id=decimal.Parse(dataGrid1[i_row,0].ToString());
				if (m.get_data("select * from "+user+mmyy+".v_tamungcd where id="+l_id+" and done=1").Tables[0].Rows.Count>0)//if (dataGrid1[i_row,6].ToString()=="1")
				{
					MessageBox.Show(lan.Change_language_MessageText("Số liệu đã cập nhật không thể sửa !"),LibMedi.AccessData.Msg);
					return;
				}				
			}
			catch{l_id=0;}
			bNew=false;
			ena_object(true);
			o_id=(cmbMabn.SelectedIndex<0)?0:decimal.Parse(cmbMabn.SelectedValue.ToString());			
			//butThem_Click(sender,e);//gam 24/08/2011 comment bv phụ sản bình dương yêu cầu click nut sửa cho phép sửa chỉ định cũ chứ không thêm mới.
		}

		private bool kiemtra()
		{
			if (madoituong.SelectedIndex==-1)
			{
				if (!madoituong.Enabled) madoituong.Enabled=true;
				madoituong.Focus();
				return false;
			}
			r=m.getrowbyid(dthoten,"mabn='"+mabn.Text+"'");
			if (r==null)
			{
                /*
				if (bAdmin && i_loaibn==0)
				{
					sql="select a.mabn,a.hoten,c.id,b.maql,b.madoituong,d.sothe,to_char(b.ngay,'dd/mm/yyyy') as ngayvv,";
					sql+="a.nam,to_char(d.denngay,'dd/mm/yyyy') as denngay ";
					sql+=" from "+user+".btdbn a inner join "+user+".benhandt b on a.mabn=b.mabn ";
                    sql+=" inner join " + user + ".hiendien c on b.maql=c.maql ";
                    sql+=" left join " + user + ".bhyt d on b.maql=d.maql ";
					sql+=" where c.nhapkhoa=1 and c.xuatkhoa=0";
					sql+=" and a.mabn='"+mabn.Text+"' order by b.maql desc";
					DataRow r2;
					foreach(DataRow r1 in m.get_data(sql).Tables[0].Rows)
					{
						r2=dthoten.NewRow();
						r2["mabn"]=r1["mabn"].ToString();
						r2["hoten"]=r1["hoten"].ToString();
						r2["id"]=r1["id"].ToString();
						r2["maql"]=r1["maql"].ToString();
						r2["madoituong"]=r1["madoituong"].ToString();
						r2["sothe"]=r1["sothe"].ToString();
						r2["ngayvv"]=r1["ngayvv"].ToString();
						r2["nam"]=r1["nam"].ToString();
						r2["denngay"]=r1["denngay"].ToString();
						dthoten.Rows.Add(r2);
						break;
					}
					r=d.getrowbyid(dthoten,"mabn='"+mabn.Text+"'");
					if (r==null)
					{
						MessageBox.Show(lan.Change_language_MessageText("Người bệnh không hợp lệ !"),LibMedi.AccessData.Msg);
						mabn.Focus();
						return false;
					}
				}
				else
				{*/
					MessageBox.Show(lan.Change_language_MessageText("Người bệnh không hợp lệ !"),LibMedi.AccessData.Msg);
					mabn.Focus();
					return false;
				//}
			}
			if ((mabn.Text!="" && hoten.Text=="") || (mabn.Text=="" && hoten.Text!=""))
			{
				MessageBox.Show(lan.Change_language_MessageText("Họ tên người bệnh !"),LibMedi.AccessData.Msg);
				if (mabn.Text=="") mabn.Focus();
				else if (hoten.Text=="") hoten.Focus();
				return false;
			}
			l_maql=decimal.Parse(r["maql"].ToString());
            l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
			l_idkhoa=decimal.Parse(r["id"].ToString());
			nam=r["nam"].ToString();
			s_denngay=r["denngay"].ToString();
			if (l_maql==0 || l_idkhoa==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Người bệnh không hợp lệ !"),LibMedi.AccessData.Msg);
				mabn.Focus();
				return false;
			}
			if (m.get_paid(mabn.Text,l_maql,l_idkhoa,s_ngay))
			{
				MessageBox.Show(lan.Change_language_MessageText("Người bệnh \n")+hoten.Text+lan.Change_language_MessageText("\nđã thanh toán !"),LibMedi.AccessData.Msg);
				mabn.Focus();
				return false;
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			decimal st=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
			if (ten.Text!="" && st>0)
			{
				if (l_id==0) l_id=v.get_id_tamung;
				if (!v.upd_tamungcd(l_id,mabn.Text,l_mavaovien,l_maql,l_idkhoa,s_ngay,i_loai,(i_loaibn==3)?tmp_loaiba:i_loaibn,s_makp,int.Parse(madoituong.SelectedValue.ToString()),ten.Text,st,i_userid))
				{
					MessageBox.Show("Không cập nhật được thông tin chỉ định tạm ứng!",LibMedi.AccessData.Msg);
					return;
				}//mmyy(v_ngay)
                if (chkNo.Checked)
                {
                    m.execute_data("update " + user + m.mmyy(s_ngay) + ".v_tamungcd set no=1 where id=" + l_id);
                }
				m.updrec_tamung(ds.Tables[0],l_id,s_ngay,s_makp,s_tenkp,int.Parse(madoituong.SelectedValue.ToString()),madoituong.Text,ten.Text,(soluong.Text!="")?decimal.Parse(soluong.Text):0,0);
				m.updrec_vpkhoa(dtll,mabn.Text,hoten.Text,l_mavaovien,l_maql,l_idkhoa,chkNo.Checked?1:0);
				cmbMabn.Refresh();
				cmbMabn.SelectedValue=l_idkhoa.ToString();
				lblsum.Text=dtll.Rows.Count.ToString();
			}
			ena_object(false);
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			load_mabn();
			if(o_id>0)
			{
				cmbMabn.SelectedValue=o_id;	
				l_idkhoa =o_id;
			}
			load_head();
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (cmbMabn.Items.Count==0) return;
			try
			{
                if (m.get_data("select done from " + m.user + mmyy + ".v_tamungcd where done=1 and id=" + l_id).Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Người bệnh \n") + hoten.Text + lan.Change_language_MessageText("\nđã đóng tạm ứng!"), LibMedi.AccessData.Msg);
                    mabn.Focus();
                    return;
                }

				if (m.get_paid(mabn.Text,l_maql,l_idkhoa,s_ngay))
				{
					MessageBox.Show(lan.Change_language_MessageText("Người bệnh \n")+hoten.Text+lan.Change_language_MessageText("\nđã thanh toán !"),LibMedi.AccessData.Msg);
					mabn.Focus();
					return;
				}
				if (m.bRavien(l_maql) && i_loaibn==0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Người bệnh đã ra viện !"),LibMedi.AccessData.Msg);
					mabn.Focus();
					return;
				}
				if (!bAdmin)
				{
					r=m.getrowbyid(dthoten,"mabn='"+mabn.Text+"'");
					if (r==null)
					{
						MessageBox.Show("Người bệnh này không còn hiện diện !",LibMedi.AccessData.Msg);
						return;
					}
				}
				i_row=dataGrid1.CurrentCell.RowNumber;
				l_id=decimal.Parse(dataGrid1[i_row,0].ToString());
				if (m.get_data("select * from "+m.user+mmyy+".v_tamungcd where id="+l_id+" and done=1").Tables[0].Rows.Count>0)//if (dataGrid1[i_row,6].ToString()=="1")
				{
					MessageBox.Show(lan.Change_language_MessageText("Số liệu đã cập nhật không thể hủy !"),LibMedi.AccessData.Msg);
					return;
				}
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					int itableid = m.tableid(m.mmyy(s_ngay),"v_tamungcd");
					m.upd_eve_upd_del(s_ngay,itableid,i_userid , "del",m.fields(user+m.mmyy(s_ngay)+".v_tamungcd","id="+l_id));
					m.upd_eve_tables(s_ngay, itableid, i_userid,"del");

					m.execute_data("delete from "+m.user+mmyy+".v_tamungcd where id="+l_id);
					m.delrec(ds.Tables[0],"id="+l_id);
					ds.AcceptChanges();
					ref_text();
					lblsum.Text=dtll.Rows.Count.ToString();
				}
			}
			catch{}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();
			System.GC.Collect();
			this.Close();
		}

		private void load_treeView()
		{
			treeView1.Nodes.Clear();
			if (s_ngayvv=="") return;
			TreeNode node;
			sql="select distinct ngay,maql,idkhoa from xxx.v_tamungcd ";
			sql+=" where makp='"+s_makp+"' and mabn='"+mabn.Text+"' and maql="+l_maql+" order by ngay desc";
			dtngay=m.get_data_mmyy(sql,s_ngayvv,s_ngay,false).Tables[0];
			foreach(DataRow r in dtngay.Rows)
			{
				node=treeView1.Nodes.Add(m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngay"].ToString())));
				sql="select ten,sotien from xxx.v_tamungcd where ";
				sql+=" to_char(ngay,'dd/mm/yyyy')='"+m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngay"].ToString()))+"'";
				sql+=" and makp='"+s_makp+"'";
				sql+=" and idkhoa="+decimal.Parse(r["idkhoa"].ToString());
				foreach(DataRow r1 in m.get_data_mmyy(sql,s_ngayvv,s_ngay,false).Tables[0].Rows)
					node.Nodes.Add(r1["ten"].ToString().Trim()+" - Số tiền :"+r1["sotien"].ToString().Trim());
				r["ngay"]=m.StringToDate(m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngay"].ToString())));
			}
		}

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
		}

		private void mabn_Validated(object sender, System.EventArgs e)
		{
			if (mabn.Text=="" || mabn.Text.Trim().Length<3) return;
            if (mabn.Text.Trim().Length != i_maxlength_mabn)
            {
                if (bQuanly_Theo_Chinhanh)
                {
                    mabn.Text = mabn.Text.Substring(0, 2) + mabn.Text.Substring(2).PadLeft(i_maxlength_mabn - 2, '0');//(6,'0');
                }
                else
                {
                    mabn.Text = mabn.Text.Substring(0, 2) + mabn.Text.Substring(2).PadLeft(6,'0');//(i_maxlength_mabn - 2, '0');
                }
            }
			r=m.getrowbyid(dthoten,"mabn='"+mabn.Text+"'");
			if (r!=null)
			{
				nam=r["nam"].ToString();
				s_ngayvv=r["ngay"].ToString();
				hoten.Text=r["hoten"].ToString();
				l_maql=decimal.Parse(r["maql"].ToString());
                l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
				l_idkhoa=decimal.Parse(r["id"].ToString());				
				i_madoituong=int.Parse(r["madoituong"].ToString());
				madoituong.SelectedValue=i_madoituong.ToString();
				sothe.Text=r["sothe"].ToString();
                tmp_loaiba = (r["loaiba"].ToString() == "") ? i_loaibn : int.Parse(r["loaiba"].ToString());
				//ngay123.Text=r["ngay123"].ToString();
			}
			else{l_mavaovien=l_maql=l_idkhoa=0;hoten.Text=sothe.Text=ngay123.Text="";}
			if (l_id!=0) return;
			try
			{
				r=m.getrowbyid(dtll,"mabn='"+mabn.Text+"'");
				if (r!=null)
				{
					DialogResult dlg=MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã nhập, Bạn có muốn sửa không?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question);//,MessageBoxDefaultButton.Button2);
					if(dlg==DialogResult.No)
					{
						//mabn.Focus();
						return;
					}
					else
					{
						l_idkhoa=decimal.Parse(r["idkhoa"].ToString());
						cmbMabn.SelectedValue=l_idkhoa.ToString();
						load_head();
						butSua_Click(null,null);
						ten.Text="";soluong.Text="";
						ten.Enabled=true;
						l_id=0;
					}
				}
			}
			catch{}
			if(mabn.Text != "")load_congno();//gam chỉ kiểm tra công nợ khi nhập mới tạm ứng, nếu load lại các lần tạm ứng trước thì bỏ qua
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

		private void hoten_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==hoten)
			{
				Filt_hoten(hoten.Text);
				if (madoituong.Enabled)	listHoten.BrowseToDanhmuc(hoten,mabn,madoituong);
				else listHoten.BrowseToDanhmuc(hoten,mabn,ten);
			}
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

		private void mabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void listHoten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				mabn_Validated(null,null);
			}
		}

		private void cmbMabn_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cmbMabn)
			{
				try
				{
					l_idkhoa=decimal.Parse(cmbMabn.SelectedValue.ToString());
				}
				catch{l_idkhoa=0;}
				load_head();
			}
		}

		private void load_head()
		{
			r=m.getrowbyid(dtll,"idkhoa="+l_idkhoa);
			if (r!=null)
			{
				mabn.Text=r["mabn"].ToString();
				hoten.Text=r["hoten"].ToString();
				l_maql=decimal.Parse(r["maql"].ToString());
                l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
                chkNo.Checked = r["no"].ToString() == "1" ? true : false;
				if (chkTree.Checked) load_treeView();
			}
			else l_idkhoa=0;
			nam="";
			r=m.getrowbyid(dthoten,"mabn='"+mabn.Text+"'");
			if (r!=null) 
			{
				s_ngayvv=r["ngay"].ToString();
				nam=r["nam"].ToString();
				sothe.Text=r["sothe"].ToString();
				//ngay123.Text=r["ngay123"].ToString();
			}
			load_grid(s_ngay,l_idkhoa);
			ref_text();
			if(mabn.Text != "")load_congno(); //gam 13/09/2011
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			decimal st=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
			if (ten.Text!="" && st>0)
			{
				if(l_id==0) l_id=v.get_id_tamung;
				if (!v.upd_tamungcd(l_id,mabn.Text,l_mavaovien,l_maql,l_idkhoa,s_ngay,i_loai,i_loaibn,s_makp,int.Parse(madoituong.SelectedValue.ToString()),ten.Text,(soluong.Text!="")?decimal.Parse(soluong.Text):0,i_userid))
				{
					MessageBox.Show("Không cập nhật được thông tin chỉ định tạm ứng !",LibMedi.AccessData.Msg);
					return;
				}
				m.updrec_tamung(ds.Tables[0],l_id,s_ngay,s_makp,s_tenkp,int.Parse(madoituong.SelectedValue.ToString()),madoituong.Text,ten.Text,(soluong.Text!="")?decimal.Parse(soluong.Text):0,0);
				m.updrec_vpkhoa(dtll,mabn.Text,hoten.Text,l_maql,l_idkhoa);
				ten.Enabled=true;ten.Text="Tạm ứng";soluong.Text="";
			}
			l_id=0;
			if (madoituong.Enabled) madoituong.Focus();
			else ten.Focus();
		}

		private void cmbMabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) butMoi.Focus();
		}

		private void load_congno()
		{
			if (mabn.Text=="") return;
			if (i_vienphi!=4)
			{
				decimal congno=m.congno(i_vienphi,mabn.Text,l_maql,l_idkhoa);
				if (congno==0) this.Text=s_title;
				else
				{
					if (congno>0) this.Text=s_title+",Thiếu :"+congno.ToString("###,###,###,##0.00");
					else
					{
						congno=Math.Abs(congno);
						this.Text=s_title+",Thừa :"+congno.ToString("###,###,###,##0.00");
					}
				}	
			}
			if (d_tamung_min!=0)
			{
				decimal conlai=m.tamung_conlai(2,mabn.Text,l_maql,l_idkhoa);
				if (conlai<=d_tamung_min)
					MessageBox.Show("Số tiền ứng trước còn lại là :"+conlai.ToString("### ### ### ##0.00")+"\nYêu cầu người bệnh đi đóng thêm !",LibMedi.AccessData.Msg);
			}
		}

		private void ten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void chkTree_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==chkTree)
			{
				if (chkTree.Checked)
				{
					if (mabn.Text!="") load_treeView();
				}
				else treeView1.Nodes.Clear();
			}
		}

		private void chkmadoituong_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==chkmadoituong) madoituong.Enabled=!chkmadoituong.Checked;
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			//Kiem tra
			if (ds.Tables[0].Rows.Count==0) return;
			try
			{
				if (m.bRavien(l_maql) && i_loaibn==0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Người bệnh đã ra viện !"),LibMedi.AccessData.Msg);
					mabn.Focus();
					return;
				}
				if (!bAdmin)
				{
					r=m.getrowbyid(dthoten,"mabn='"+mabn.Text+"'");
					if (r==null)
					{
						MessageBox.Show("Người bệnh này không còn hiện diện !",LibMedi.AccessData.Msg);
						return;
					}
				}
				i_row=dataGrid1.CurrentCell.RowNumber;
				if (dataGrid1[i_row,6].ToString()=="1")
				{
					MessageBox.Show(lan.Change_language_MessageText("Số liệu đã cập nhật không thể in lại !"),LibMedi.AccessData.Msg);
					return;
				}
				l_id=decimal.Parse(dataGrid1[i_row,0].ToString());
			}
			catch{l_id=0;}
			//
			if(l_id==0)return;
			//
			DataSet lds=new DataSet();
			string mmyy=s_ngay.Substring(3,2)+s_ngay.Substring(8,2);
			//
			sql=" select b.tenkp, c.hoten, c.phai, c.ngaysinh, c.namsinh, c.cholam, c.sonha, c.thon, e.tentt, f.tenquan, ";
            sql+=" g.tenpxa, h.sothe, h.tungay, h.denngay, h.mabv, i.tenbv,d.sovaovien, a.* ";
            sql+= " from " + user + mmyy + ".v_tamungcd a inner join " + user + ".btdkp_bv b on a.makp=b.makp ";
            sql+=" inner join " + user + ".btdbn c on a.mabn=c.mabn ";            
            //sql += "inner join " + user + ".benhandt d on a.maql=d.maql ";
            sql += " inner join (select maql, madoituong, sovaovien from " + user + ".benhandt union all select maql, madoituong, sovaovien from " + user + mmyy + ".benhanpk union all select maql, madoituong, sovaovien from " + user + mmyy + ".benhancc union all select maql, madoituong, sovaovien from " + user + mmyy + ".tiepdon) d  on a.maql=d.maql ";
            sql+=" inner join " + user + ".btdtt e on c.matt=e.matt ";
            sql+=" inner join " + user + ".btdquan f on c.maqu=f.maqu ";
            sql+=" inner join " + user + ".btdpxa g on c.maphuongxa=g.maphuongxa ";
            sql+=" left join " + user + ".bhyt h on a.maql=h.maql ";
            sql+=" left join " + user + ".dmnoicapbhyt i on h.mabv=i.mabv ";
			sql+=" where (h.sudung=1 or h.sudung is null) and a.id="+l_id;
            sql += " union all ";// gam 05-05-2011
            sql = " select b.tenkp, c.hoten, c.phai, c.ngaysinh, c.namsinh, c.cholam, c.sonha, c.thon, e.tentt, f.tenquan, ";
            sql += " g.tenpxa, h.sothe, h.tungay, h.denngay, h.mabv, i.tenbv,d.sovaovien, a.* ";
            sql += " from " + user + mmyy + ".v_tamungcd a inner join " + user + ".btdkp_bv b on a.makp=b.makp ";
            sql += " inner join " + user + ".btdbn c on a.mabn=c.mabn ";
            //sql += "inner join " + user +mmyy+ ".benhancc d on a.maql=d.maql ";//and a.makp=d.makp ";
            sql += " inner join (select maql, madoituong, sovaovien from " + user + ".benhandt union all select maql, madoituong, sovaovien from " + user + mmyy + ".benhanpk union all select maql, madoituong, sovaovien from " + user + ".benhanngtr union all select maql, madoituong, sovaovien from " + user + mmyy + ".benhancc union all select maql, madoituong, sovaovien from " + user + mmyy + ".tiepdon) d  on a.maql=d.maql ";//Tu: 22/08/2011
            sql += " inner join " + user + ".btdtt e on c.matt=e.matt ";
            sql += " inner join " + user + ".btdquan f on c.maqu=f.maqu ";
            sql += " inner join " + user + ".btdpxa g on c.maphuongxa=g.maphuongxa ";
            sql += " left join " + user + ".bhyt h on a.maql=h.maql ";
            sql += " left join " + user + ".dmnoicapbhyt i on h.mabv=i.mabv ";
            sql += " where (h.sudung=1 or h.sudung is null) and a.id=" + l_id;
			lds=m.get_data(sql);
			if(lds.Tables.Count<=0)return;
			if(lds.Tables[0].Rows.Count<=0)return;
			if(chkXML.Checked)lds.WriteXml("..\\..\\..\\xml\\v_tamungcd.xml",XmlWriteMode.WriteSchema);
			//
            string s_tenreport = chkNo.Checked ? "rptChidinh_tu_no.rpt" : "rptChidinh_tu.rpt";
			if (chkXem.Checked)
			{
                dllReportM.frmReport f = new dllReportM.frmReport(m, lds, s_ngay.Substring(0, 10), s_tenreport);
				f.ShowDialog();
			}
			else print.Printer(m,lds,s_tenreport,s_ngay.Substring(0,10),1);
			//
			lds.Dispose();
			//
		}
	}
}
