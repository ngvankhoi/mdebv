using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using LibMedi;

namespace Medisoft
{
	public class frmToathuoc : System.Windows.Forms.Form
    {
        #region Khai bao
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.TextBox tenkp;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox tuoi;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox ngay;
		private System.Windows.Forms.TextBox tenbs;
		private System.Windows.Forms.TextBox chandoan;
        private System.Windows.Forms.TextBox maicd;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private MaskedTextBox.MaskedTextBox soluong;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox cachdung;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.TextBox stt;
		private LibList.List listThuoc;
		private LibList.List listCachdung;
		private LibDuoc.AccessData d;
		private LibMedi.AccessData m;
        private string nam, user, s_makp, s_mabs, sql, s_ngay, s_diachi, s_tenbs, s_tenkp, s_ngaymakp="",s_ngaykham="";
        private decimal l_maql, l_id, i_ma;
        private int i_userid, i_row,  i_sudungthuoc;
		private bool bDanhmuc,bSolan;
		private decimal d_soluong;
        private dllReportM.Print print = new dllReportM.Print();
		private DataTable dtkp=new DataTable();
		private DataTable dtbs=new DataTable();
		private DataTable dtll=new DataTable();
		private DataTable dtthuoc=new DataTable();
		private DataTable dtngay=new DataTable();
		private DataSet dsct=new DataSet();
		private DataSet dsxoa=new DataSet();
		private System.Windows.Forms.ComboBox cmbNgay;
		private System.Windows.Forms.TextBox ma;
		private System.Windows.Forms.Button butXoa;
		private System.Windows.Forms.Button butThem;
		private System.Windows.Forms.Label ltenhc;
		private System.Windows.Forms.TextBox tenhc;
		private System.Windows.Forms.TextBox ten;
		private LibList.List listDang;
		private System.Windows.Forms.TextBox dvt;
		private LibList.List listDMBS;
		private System.Windows.Forms.TextBox mabs;
        private System.Windows.Forms.Button butHen;
        private NumericUpDown songay;
        private Label label11;
        private Label label15;
        private NumericUpDown solan;
        private Label label16;
        private Label lbldvt;
        private MaskedTextBox.MaskedTextBox moilan;
        private Label label17;
        private TextBox ghichu;
        private ToolTip toolTip1;
        private CheckBox chkXml;
        private CheckBox chkXem;
        private IContainer components;
        //Tu:28/03/2011
        private string s_phai = "";
        private Button butCholai;
        private int i_loaiba = 0,i_maxlength_mabn=8,i_chinhanh=0;//Tu: them chi nhanh 02/06/2011
        private bool bbadt = false;
        //
        #endregion

        public frmToathuoc(LibMedi.AccessData acc,string s_mabn,string s_hoten,string s_tuoi,string ngayvv,string makp,string tenkp,string mabs,string tenbs,string s_chandoan,string s_icd,decimal maql,int userid,string diachi,string _nam)
		{
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			d=new LibDuoc.AccessData();
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
			mabn.Text=s_mabn;
			hoten.Text=s_hoten;
			tuoi.Text=s_tuoi;
			s_ngaykham=s_ngay=ngayvv;
			ngay.Text=s_ngay;
			s_makp=makp;
			s_mabs=mabs;
			s_diachi=diachi;
			s_tenkp=tenkp;
			s_tenbs=tenbs;
			chandoan.Text=s_chandoan;
			maicd.Text=s_icd;
			l_maql=maql;
            i_userid = userid; nam = _nam;
		}
        //TU:28/03/2011
        public frmToathuoc(LibMedi.AccessData acc, string s_mabn, string s_hoten, string s_tuoi, string ngayvv, string makp, string tenkp, string mabs, string tenbs, string s_chandoan, string s_icd, decimal maql, int userid, string diachi, string _phai, int _loaiba,int _i_chinhanh)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            d = new LibDuoc.AccessData();
            m = acc; mabn.Text = s_mabn; hoten.Text = s_hoten;
            tuoi.Text = s_tuoi; s_ngay = ngayvv;
            s_ngaykham = ngayvv;
            ngay.Text = s_ngay; s_makp = makp; s_mabs = mabs;
            s_diachi = diachi; s_tenkp = tenkp; s_tenbs = tenbs;
            chandoan.Text = s_chandoan; maicd.Text = s_icd;
            l_maql = maql; i_userid = userid; s_phai = _phai; i_loaiba = _loaiba;
            i_chinhanh = _i_chinhanh;
        }
        public frmToathuoc(LibMedi.AccessData acc, string s_mabn, string s_hoten, string s_tuoi, string ngayvv, string makp, string tenkp, string mabs, string tenbs, string s_chandoan, string s_icd, decimal maql, int userid, string diachi, string _phai, int _loaiba,int _i_chinhanh,bool _badt)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            d = new LibDuoc.AccessData();
            m = acc; mabn.Text = s_mabn; hoten.Text = s_hoten;
            tuoi.Text = s_tuoi; s_ngay = ngayvv;
            s_ngaykham = ngayvv;
            ngay.Text = s_ngay; s_makp = makp; s_mabs = mabs;
            s_diachi = diachi; s_tenkp = tenkp; s_tenbs = tenbs;
            chandoan.Text = s_chandoan; maicd.Text = s_icd;
            l_maql = maql; i_userid = userid; s_phai = _phai; i_loaiba = _loaiba;
            bbadt = _badt; i_chinhanh = _i_chinhanh;
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
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmToathuoc));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.tenkp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.hoten = new System.Windows.Forms.TextBox();
            this.tuoi = new System.Windows.Forms.TextBox();
            this.mabn = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ngay = new System.Windows.Forms.TextBox();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.chandoan = new System.Windows.Forms.TextBox();
            this.maicd = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tenhc = new System.Windows.Forms.TextBox();
            this.ltenhc = new System.Windows.Forms.Label();
            this.ten = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.soluong = new MaskedTextBox.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cachdung = new System.Windows.Forms.TextBox();
            this.stt = new System.Windows.Forms.TextBox();
            this.listThuoc = new LibList.List();
            this.listCachdung = new LibList.List();
            this.cmbNgay = new System.Windows.Forms.ComboBox();
            this.ma = new System.Windows.Forms.TextBox();
            this.listDang = new LibList.List();
            this.dvt = new System.Windows.Forms.TextBox();
            this.listDMBS = new LibList.List();
            this.mabs = new System.Windows.Forms.TextBox();
            this.songay = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.solan = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.lbldvt = new System.Windows.Forms.Label();
            this.moilan = new MaskedTextBox.MaskedTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.ghichu = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkXml = new System.Windows.Forms.CheckBox();
            this.chkXem = new System.Windows.Forms.CheckBox();
            this.butCholai = new System.Windows.Forms.Button();
            this.butXoa = new System.Windows.Forms.Button();
            this.butThem = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.butHen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.songay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.solan)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(573, 5);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(187, 310);
            this.treeView1.TabIndex = 49;
            this.toolTip1.SetToolTip(this.treeView1, "F7 Cho lại");
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyDown);
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 85);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(560, 230);
            this.dataGrid1.TabIndex = 45;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // tenkp
            // 
            this.tenkp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkp.Enabled = false;
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(340, 31);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(228, 21);
            this.tenkp.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(261, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 23);
            this.label4.TabIndex = 32;
            this.label4.Text = "Khoa/phòng :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(161, 8);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(143, 21);
            this.hoten.TabIndex = 2;
            // 
            // tuoi
            // 
            this.tuoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tuoi.Enabled = false;
            this.tuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuoi.Location = new System.Drawing.Point(340, 8);
            this.tuoi.Name = "tuoi";
            this.tuoi.Size = new System.Drawing.Size(76, 21);
            this.tuoi.TabIndex = 3;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(61, 8);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(66, 21);
            this.mabn.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(306, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 23);
            this.label3.TabIndex = 29;
            this.label3.Text = "Tuổi :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(124, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 22);
            this.label2.TabIndex = 28;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 27;
            this.label1.Text = "Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(416, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 23);
            this.label5.TabIndex = 30;
            this.label5.Text = "Ngày :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(0, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 23);
            this.label6.TabIndex = 31;
            this.label6.Text = "Bác sĩ :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(-9, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 23);
            this.label7.TabIndex = 33;
            this.label7.Text = "Chẩn đoán :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(488, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 23);
            this.label8.TabIndex = 34;
            this.label8.Text = "ICD :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(152, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 23);
            this.label9.TabIndex = 37;
            this.label9.Text = "Ghi chú :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngay
            // 
            this.ngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay.Enabled = false;
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Location = new System.Drawing.Point(456, 8);
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(112, 21);
            this.ngay.TabIndex = 3;
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Enabled = false;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(61, 31);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(203, 21);
            this.tenbs.TabIndex = 5;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // chandoan
            // 
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(61, 54);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(419, 21);
            this.chandoan.TabIndex = 7;
            // 
            // maicd
            // 
            this.maicd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.maicd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maicd.Enabled = false;
            this.maicd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maicd.Location = new System.Drawing.Point(520, 54);
            this.maicd.Name = "maicd";
            this.maicd.Size = new System.Drawing.Size(48, 21);
            this.maicd.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.Location = new System.Drawing.Point(-31, 336);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 23);
            this.label10.TabIndex = 39;
            this.label10.Text = "Tên thuốc :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenhc
            // 
            this.tenhc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tenhc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenhc.Enabled = false;
            this.tenhc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenhc.Location = new System.Drawing.Point(419, 336);
            this.tenhc.Name = "tenhc";
            this.tenhc.Size = new System.Drawing.Size(341, 21);
            this.tenhc.TabIndex = 12;
            this.tenhc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenhc_KeyDown);
            // 
            // ltenhc
            // 
            this.ltenhc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ltenhc.Location = new System.Drawing.Point(350, 336);
            this.ltenhc.Name = "ltenhc";
            this.ltenhc.Size = new System.Drawing.Size(72, 23);
            this.ltenhc.TabIndex = 40;
            this.ltenhc.Text = "Hoạt chất :";
            this.ltenhc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ten
            // 
            this.ten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(80, 336);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(280, 21);
            this.ten.TabIndex = 11;
            this.ten.Validated += new System.EventHandler(this.ten_Validated);
            this.ten.TextChanged += new System.EventHandler(this.ten_TextChanged);
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.Location = new System.Drawing.Point(8, 360);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 23);
            this.label12.TabIndex = 41;
            this.label12.Text = "ĐVT :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.Location = new System.Drawing.Point(366, 356);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 23);
            this.label13.TabIndex = 42;
            this.label13.Text = "Số lượng :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // soluong
            // 
            this.soluong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(419, 360);
            this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(45, 21);
            this.soluong.TabIndex = 16;
            this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.Location = new System.Drawing.Point(444, 358);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 23);
            this.label14.TabIndex = 44;
            this.label14.Text = "Cách dùng:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cachdung
            // 
            this.cachdung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cachdung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cachdung.Enabled = false;
            this.cachdung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cachdung.Location = new System.Drawing.Point(520, 360);
            this.cachdung.Name = "cachdung";
            this.cachdung.Size = new System.Drawing.Size(240, 21);
            this.cachdung.TabIndex = 17;
            this.cachdung.TextChanged += new System.EventHandler(this.cachdung_TextChanged);
            this.cachdung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cachdung_KeyDown);
            // 
            // stt
            // 
            this.stt.Location = new System.Drawing.Point(16, 272);
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(48, 20);
            this.stt.TabIndex = 46;
            // 
            // listThuoc
            // 
            this.listThuoc.BackColor = System.Drawing.SystemColors.Info;
            this.listThuoc.ColumnCount = 0;
            this.listThuoc.Location = new System.Drawing.Point(470, 456);
            this.listThuoc.MatchBufferTimeOut = 1000;
            this.listThuoc.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listThuoc.Name = "listThuoc";
            this.listThuoc.Size = new System.Drawing.Size(75, 17);
            this.listThuoc.TabIndex = 52;
            this.listThuoc.TextIndex = -1;
            this.listThuoc.TextMember = null;
            this.listThuoc.ValueIndex = -1;
            this.listThuoc.Visible = false;
            this.listThuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listThuoc_KeyDown);
            // 
            // listCachdung
            // 
            this.listCachdung.BackColor = System.Drawing.SystemColors.Info;
            this.listCachdung.ColumnCount = 0;
            this.listCachdung.Location = new System.Drawing.Point(551, 456);
            this.listCachdung.MatchBufferTimeOut = 1000;
            this.listCachdung.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listCachdung.Name = "listCachdung";
            this.listCachdung.Size = new System.Drawing.Size(75, 17);
            this.listCachdung.TabIndex = 53;
            this.listCachdung.TextIndex = -1;
            this.listCachdung.TextMember = null;
            this.listCachdung.ValueIndex = -1;
            this.listCachdung.Visible = false;
            // 
            // cmbNgay
            // 
            this.cmbNgay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbNgay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNgay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNgay.Location = new System.Drawing.Point(456, 8);
            this.cmbNgay.Name = "cmbNgay";
            this.cmbNgay.Size = new System.Drawing.Size(112, 21);
            this.cmbNgay.TabIndex = 4;
            this.cmbNgay.SelectedIndexChanged += new System.EventHandler(this.cmbNgay_SelectedIndexChanged);
            // 
            // ma
            // 
            this.ma.Location = new System.Drawing.Point(64, 272);
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(80, 20);
            this.ma.TabIndex = 47;
            // 
            // listDang
            // 
            this.listDang.BackColor = System.Drawing.SystemColors.Info;
            this.listDang.ColumnCount = 0;
            this.listDang.Location = new System.Drawing.Point(389, 456);
            this.listDang.MatchBufferTimeOut = 1000;
            this.listDang.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listDang.Name = "listDang";
            this.listDang.Size = new System.Drawing.Size(75, 17);
            this.listDang.TabIndex = 51;
            this.listDang.TextIndex = -1;
            this.listDang.TextMember = null;
            this.listDang.ValueIndex = -1;
            this.listDang.Visible = false;
            // 
            // dvt
            // 
            this.dvt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dvt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dvt.Enabled = false;
            this.dvt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dvt.Location = new System.Drawing.Point(80, 360);
            this.dvt.Name = "dvt";
            this.dvt.Size = new System.Drawing.Size(48, 21);
            this.dvt.TabIndex = 13;
            this.dvt.Validated += new System.EventHandler(this.dvt_Validated);
            this.dvt.TextChanged += new System.EventHandler(this.dvt_TextChanged);
            this.dvt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dvt_KeyDown);
            // 
            // listDMBS
            // 
            this.listDMBS.BackColor = System.Drawing.SystemColors.Info;
            this.listDMBS.ColumnCount = 0;
            this.listDMBS.Location = new System.Drawing.Point(309, 456);
            this.listDMBS.MatchBufferTimeOut = 1000;
            this.listDMBS.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listDMBS.Name = "listDMBS";
            this.listDMBS.Size = new System.Drawing.Size(75, 17);
            this.listDMBS.TabIndex = 50;
            this.listDMBS.TextIndex = -1;
            this.listDMBS.TextMember = null;
            this.listDMBS.ValueIndex = -1;
            this.listDMBS.Visible = false;
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.Enabled = false;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(345, 221);
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(32, 21);
            this.mabs.TabIndex = 48;
            // 
            // songay
            // 
            this.songay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.songay.Enabled = false;
            this.songay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songay.Location = new System.Drawing.Point(61, 77);
            this.songay.Name = "songay";
            this.songay.Size = new System.Drawing.Size(56, 21);
            this.songay.TabIndex = 9;
            this.songay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.songay_KeyDown);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(0, 75);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 23);
            this.label11.TabIndex = 35;
            this.label11.Text = "Cấp :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(116, 80);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 16);
            this.label15.TabIndex = 36;
            this.label15.Text = "ngày";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // solan
            // 
            this.solan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.solan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.solan.Enabled = false;
            this.solan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solan.Location = new System.Drawing.Point(168, 360);
            this.solan.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.solan.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.solan.Name = "solan";
            this.solan.Size = new System.Drawing.Size(37, 21);
            this.solan.TabIndex = 14;
            this.solan.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.solan.Validated += new System.EventHandler(this.solan_Validated);
            this.solan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.songay_KeyDown);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.Location = new System.Drawing.Point(114, 359);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(50, 23);
            this.label16.TabIndex = 43;
            this.label16.Text = "Ngày :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbldvt
            // 
            this.lbldvt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbldvt.Location = new System.Drawing.Point(293, 358);
            this.lbldvt.Name = "lbldvt";
            this.lbldvt.Size = new System.Drawing.Size(68, 23);
            this.lbldvt.TabIndex = 65;
            this.lbldvt.Text = "viên";
            this.lbldvt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // moilan
            // 
            this.moilan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.moilan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.moilan.Enabled = false;
            this.moilan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moilan.Location = new System.Drawing.Point(248, 360);
            this.moilan.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.moilan.Name = "moilan";
            this.moilan.Size = new System.Drawing.Size(43, 21);
            this.moilan.TabIndex = 15;
            this.moilan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.moilan.Validated += new System.EventHandler(this.moilan_Validated);
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.Location = new System.Drawing.Point(202, 359);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(55, 23);
            this.label17.TabIndex = 64;
            this.label17.Text = "lần , lần :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ghichu
            // 
            this.ghichu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ghichu.Enabled = false;
            this.ghichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ghichu.Location = new System.Drawing.Point(218, 77);
            this.ghichu.Name = "ghichu";
            this.ghichu.Size = new System.Drawing.Size(262, 21);
            this.ghichu.TabIndex = 10;
            this.ghichu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ghichu_KeyDown);
            // 
            // chkXml
            // 
            this.chkXml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkXml.AutoSize = true;
            this.chkXml.Location = new System.Drawing.Point(673, 317);
            this.chkXml.Name = "chkXml";
            this.chkXml.Size = new System.Drawing.Size(85, 17);
            this.chkXml.TabIndex = 66;
            this.chkXml.Text = "Xuất ra XML";
            this.chkXml.UseVisualStyleBackColor = true;
            // 
            // chkXem
            // 
            this.chkXem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkXem.AutoSize = true;
            this.chkXem.Location = new System.Drawing.Point(574, 318);
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(88, 17);
            this.chkXem.TabIndex = 67;
            this.chkXem.Text = "Xem trước in ";
            this.chkXem.UseVisualStyleBackColor = true;
            // 
            // butCholai
            // 
            this.butCholai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butCholai.Enabled = false;
            this.butCholai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCholai.Location = new System.Drawing.Point(29, 411);
            this.butCholai.Name = "butCholai";
            this.butCholai.Size = new System.Drawing.Size(70, 25);
            this.butCholai.TabIndex = 68;
            this.butCholai.Text = "&Cho lại";
            this.butCholai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCholai.Click += new System.EventHandler(this.butCholai_Click);
            // 
            // butXoa
            // 
            this.butXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butXoa.Enabled = false;
            this.butXoa.Image = ((System.Drawing.Image)(resources.GetObject("butXoa.Image")));
            this.butXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXoa.Location = new System.Drawing.Point(379, 411);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(70, 25);
            this.butXoa.TabIndex = 19;
            this.butXoa.Text = "    &Xóa";
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butThem
            // 
            this.butThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butThem.Enabled = false;
            this.butThem.Image = ((System.Drawing.Image)(resources.GetObject("butThem.Image")));
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(309, 411);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(70, 25);
            this.butThem.TabIndex = 18;
            this.butThem.Text = "&Thêm";
            this.butThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(589, 411);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 25;
            this.butIn.Text = "    &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(659, 411);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 26;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(519, 411);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 23;
            this.butHuy.Text = "    &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(449, 411);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 21;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(239, 411);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 20;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(169, 411);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 22;
            this.butSua.Text = "    &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(99, 411);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 0;
            this.butMoi.Text = "    &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butHen
            // 
            this.butHen.Image = ((System.Drawing.Image)(resources.GetObject("butHen.Image")));
            this.butHen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHen.Location = new System.Drawing.Point(519, 77);
            this.butHen.Name = "butHen";
            this.butHen.Size = new System.Drawing.Size(50, 23);
            this.butHen.TabIndex = 38;
            this.butHen.Text = "Hẹn";
            this.butHen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butHen.Click += new System.EventHandler(this.butHen_Click);
            // 
            // frmToathuoc
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(762, 479);
            this.Controls.Add(this.butCholai);
            this.Controls.Add(this.chkXem);
            this.Controls.Add(this.chkXml);
            this.Controls.Add(this.ghichu);
            this.Controls.Add(this.dvt);
            this.Controls.Add(this.lbldvt);
            this.Controls.Add(this.moilan);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.soluong);
            this.Controls.Add(this.solan);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.songay);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.butXoa);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.butHen);
            this.Controls.Add(this.listDMBS);
            this.Controls.Add(this.listDang);
            this.Controls.Add(this.tenhc);
            this.Controls.Add(this.tuoi);
            this.Controls.Add(this.cmbNgay);
            this.Controls.Add(this.listCachdung);
            this.Controls.Add(this.listThuoc);
            this.Controls.Add(this.cachdung);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.ltenhc);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.maicd);
            this.Controls.Add(this.chandoan);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tenkp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.stt);
            this.Controls.Add(this.ma);
            this.Controls.Add(this.mabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmToathuoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đơn thuốc";
            this.Load += new System.EventHandler(this.frmToathuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.songay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.solan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmToathuoc_Load(object sender, System.EventArgs e)
		{
            if (bbadt)
            {
                this.Location = new System.Drawing.Point(188 - 38, 120);//151
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Size = new Size(829 + 40, 610);
            }

            i_maxlength_mabn =LibMedi.AccessData.i_maxlength_mabn;
            mabn.MaxLength = i_maxlength_mabn;

            if (nam == "" || nam == null) nam = m.mmyy(s_ngay);
            user = d.user;
            if (m.bNgayhienhanh_thuoc_chidinh)
            {
                s_ngay = m.ngayhienhanh_server;
                ngay.Text = s_ngay;
            }
            bSolan = m.bSolan_donthuoc;
			bDanhmuc=m.bDanhmucthuocbv;
			listDMBS.DisplayMember="MA";
			listDMBS.ValueMember="HOTEN";
			dtbs=d.get_data("select ma,hoten from "+user+".dmbs where nhom not in ("+LibMedi.AccessData.nhanvien+","+LibMedi.AccessData.nghiviec+") order by hoten").Tables[0];
			listDMBS.DataSource=dtbs;
			tenkp.Text=s_tenkp;
			tenbs.Text=s_tenbs;
			listCachdung.DisplayMember="TEN";
			listCachdung.ValueMember="TEN";
			load_cachdung();
			listThuoc.DisplayMember="ID";
			listThuoc.ValueMember="TEN";
			load_thuoc();
			listDang.DisplayMember="TEN";
			listDang.ValueMember="TEN";
			load_dang();
			dsxoa.ReadXml("..//..//..//xml//d_toathuocct.xml");
            try
            {
                dsxoa.Tables[0].Columns.Add("lan", typeof(decimal)).DefaultValue = 0;
            }
            catch { }
			i_sudungthuoc = m.iSudungthuoc;
            sql = "select * from " + user + ".btdkp_bv ";
            if (i_chinhanh != 0) sql += " where (chinhanh=0 or chinhanh=" + i_chinhanh + ") ";
            dtkp = m.get_data(sql).Tables[0];
			cmbNgay.DisplayMember="NGAY";
			cmbNgay.ValueMember="ID";
			load_ngay();
			load_head();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			ref_text();
			load_treeView();
            chkXem.Checked = m.bPreview;
		}

		private void load_ngay()
		{
			dtll=m.get_data("select id,makp,chandoan,maicd,mabs,ghichu,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay,songay from "+user+d.mmyy(s_ngay)+".d_toathuocll where maql="+l_maql).Tables[0];
			cmbNgay.DataSource=dtll;
			if (dtll.Rows.Count>0) l_id=decimal.Parse(cmbNgay.SelectedValue.ToString());
			else l_id=0;
		}

		private void load_head()
		{
			DataRow r=m.getrowbyid(dtll,"id="+l_id);
			if (r!=null)
			{
				DataRow r1;
				s_makp=r["makp"].ToString();
				s_mabs=r["mabs"].ToString();
				s_ngay=r["ngay"].ToString();
				chandoan.Text=r["chandoan"].ToString();
				maicd.Text=r["maicd"].ToString();
				ghichu.Text=r["ghichu"].ToString();
				r1=m.getrowbyid(dtkp,"makp='"+s_makp+"'");
				if (r1!=null) tenkp.Text=r1["tenkp"].ToString();
				r1=m.getrowbyid(dtbs,"ma='"+s_mabs+"'");
				if (r1!=null) tenbs.Text=r1["hoten"].ToString();
                songay.Value = decimal.Parse(r["songay"].ToString());
			}
			load_grid();
		}

		private void load_grid()
		{
			sql="select a.stt,a.mabd,b.ten,b.dang,nullif(b.tenhc,' ') as tenhc,a.soluong,a.cachdung,a.solan,a.lan from "+user+d.mmyy(s_ngay)+".d_toathuocct a,"+user+".d_dmthuoc b";
			sql+=" where a.mabd=b.id and a.id="+l_id+" order by a.stt";
			dsct=m.get_data(sql);
			dataGrid1.DataSource=dsct.Tables[0];
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dsct.Tables[0].TableName;
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
			TextCol.MappingName = "stt";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "mabd";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenhc";
			TextCol.HeaderText = "Tên hoạt chất";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên thuốc";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "soluong";
			TextCol.HeaderText = "Số lượng";
			TextCol.Width = 50;
			TextCol.Format="### ###.00";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "cachdung";
			TextCol.HeaderText = "Cách dùng";
			TextCol.Width = 127;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "solan";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "lan";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		private void ref_text()
		{
			try
			{
				i_row=dataGrid1.CurrentCell.RowNumber;
				stt.Text=dataGrid1[i_row,0].ToString();
				ma.Text=dataGrid1[i_row,1].ToString();
				ten.Text=dataGrid1[i_row,3].ToString();
				dvt.Text=dataGrid1[i_row,4].ToString();
				tenhc.Text=dataGrid1[i_row,2].ToString();
				d_soluong=decimal.Parse(dataGrid1[i_row,5].ToString());
				soluong.Text=d_soluong.ToString("###,###.00");
				cachdung.Text=dataGrid1[i_row,6].ToString();
                solan.Value = decimal.Parse(dataGrid1[i_row, 7].ToString());
                moilan.Text = dataGrid1[i_row,8].ToString();
			}
			catch{}
		}

		private void load_cachdung()
		{
			listCachdung.DataSource=m.get_data("select ten,ten as stt from "+user+".d_dmcachdung order by stt,ten").Tables[0];
		}

		private void load_dang()
		{
			listDang.DataSource=d.get_data("select * from "+user+".d_dmdvt order by stt").Tables[0];
		}

		private void load_thuoc()
		{
			if (bDanhmuc) sql="select a.id,trim(a.ten)||' '||trim(a.hamluong) as ten,a.tenhc,a.dang,a.mahc,a.duongdung from "+user+".d_dmbd a,"+user+".d_dmnhomkho b where a.nhom=b.id and b.loai=1 and a.nhom="+m.nhom_duoc+" order by a.tenhc";
			else sql="select id,ten,tenhc,dang,cachdung,'' as duongdung from "+user+".d_dmthuoc where hide=0 order by stt,ten";
			dtthuoc=m.get_data(sql).Tables[0];
			listThuoc.DataSource=dtthuoc;
		}

		private void Filter_cachdung(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listCachdung.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void Filter_thuoc(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listThuoc.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ten like '%"+ten.Trim()+"%' or tenhc like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void ten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listThuoc.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listThuoc.Visible && bDanhmuc) listThuoc.Focus();
				else
				{
					listThuoc.Hide();
					SendKeys.Send("{Tab}");
				}
			}		
		}

		private void ten_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==ten)
			{
				Filter_thuoc(ten.Text);
				if (tenhc.Enabled)
					listThuoc.BrowseToToathuoc(ten,ma,tenhc,ten.Width+ltenhc.Width+tenhc.Width);
                    //linh 28/11/2007
                else if(solan.Enabled)
                    listThuoc.BrowseToToathuoc(ten, ma, solan, ten.Width + ltenhc.Width + tenhc.Width);
                    //end linh
				else
					listThuoc.BrowseToToathuoc(ten,ma,soluong,ten.Width+ltenhc.Width+tenhc.Width);
			}
		}

		private void soluong_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (soluong.Text=="") soluong.Text="1";
				d_soluong=decimal.Parse(soluong.Text);
				soluong.Text=d_soluong.ToString("###,###.00");
			}
			catch{soluong.Text="1";}
		}

		private void cachdung_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listCachdung.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listCachdung.Visible) listCachdung.Focus();
				else SendKeys.Send("{Tab}");
			}		
		}

		private void cachdung_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cachdung)
			{
				Filter_cachdung(cachdung.Text);
				listCachdung.BrowseToDanhmuc(cachdung,cachdung,butThem,0);
			}		
		}

		private void cmbNgay_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cmbNgay)
			{
				try
				{
					l_id=decimal.Parse(cmbNgay.SelectedValue.ToString());
				}
				catch{l_id=0;}
				load_head();
			}
		}

		private void ena_object(bool ena)
		{
			dsxoa.Clear();
			cmbNgay.Visible=!ena;
			if (s_mabs=="") tenbs.Enabled=ena;
            songay.Enabled = ena;
            if (bSolan)
            {
                solan.Enabled = ena;
                moilan.Enabled = ena;
            }
			ghichu.Enabled=ena;
			ten.Enabled=ena;
			soluong.Enabled=ena;
			cachdung.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
            butCholai.Enabled = ena;
			butThem.Enabled=ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butXoa.Enabled=ena;
			butIn.Enabled=!ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			if (!bDanhmuc)
			{
				dvt.Enabled=ena;
				tenhc.Enabled=ena;
			}
			if (ena && !bDanhmuc) load_thuoc();
			if (ena && l_id==0)
			{
				dsct.Clear();
				ghichu.Text="";
				emp_item();
			}
			else butMoi.Focus();
		}

		private void emp_item()
		{
			stt.Text=m.get_stt(dsct.Tables[0]).ToString();
			ten.Text="";
			tenhc.Text="";
			dvt.Text="";
			soluong.Text="";
			cachdung.Text="";
            solan.Value = 1;
            moilan.Text = "1";
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			l_id=0;
            s_ngaymakp = "";
			ena_object(true);
			if (tenbs.Enabled) tenbs.Focus();
			else songay.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (dtll.Rows.Count==0) return;
			try
			{
				l_id=decimal.Parse(cmbNgay.SelectedValue.ToString());
			}
			catch{}
			ena_object(true);
			dsxoa.Clear();
			ghichu.Focus();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!add_item(true)) return;
			if (tenbs.Enabled)
			{
				DataRow r=d.getrowbyid(dtbs,"hoten='"+tenbs.Text+"'");
				if (r==null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Họ tên bác sĩ không hợp lệ !"),d.Msg);
					tenbs.Focus();
					return;
				}
				else s_mabs=r["ma"].ToString();
			}
            int itable = m.tableid(m.mmyy(s_ngay), "d_toathuocll");
            if (l_id == 0)
            {
                if (dsct.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập thuốc !"), LibMedi.AccessData.Msg);
                    return;
                }
                l_id = d.get_id_toathuoc;
                m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
            }
            else
            {
                m.upd_eve_tables(s_ngay, itable, i_userid, "upd");
                m.upd_eve_upd_del(s_ngay, itable, i_userid, "upd", l_id.ToString() + "^" + "0" + "^" + mabn.Text + "^" + l_maql.ToString() + "^" + s_ngay + "^" + s_makp + "^" + chandoan.Text + "^" + maicd.Text + "^" + s_mabs + "^" + ghichu.Text + "^" + i_userid.ToString() + "^" + songay.Value.ToString());
            }
            itable = m.tableid(m.mmyy(s_ngay), "d_toathuocct");
			if (!d.upd_toathuocll(l_id,0,mabn.Text,l_maql,s_ngay,s_makp,chandoan.Text,maicd.Text,s_mabs,ghichu.Text,i_userid,songay.Value))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin"),LibMedi.AccessData.Msg);
				return;
			}
            foreach (DataRow r in dsxoa.Tables[0].Rows)
            {
                m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                m.upd_eve_upd_del(s_ngay, itable, i_userid, "del", m.fields(user + d.mmyy(s_ngay) + ".d_toathuocct", "id=" + l_id + " and stt=" + decimal.Parse(r["stt"].ToString())));
                m.execute_data("delete from " + user + d.mmyy(s_ngay) + ".d_toathuocct where id=" + l_id + " and stt=" + decimal.Parse(r["stt"].ToString()));
            }
			foreach(DataRow r in dsct.Tables[0].Rows)
			{
				try
				{
					i_ma=decimal.Parse(r["mabd"].ToString());
					if (bDanhmuc)
						d.upd_dmthuoc(i_ma,r["ten"].ToString(),r["dang"].ToString(),r["cachdung"].ToString(),r["tenhc"].ToString());
					else
					{
						i_ma=Convert.ToInt64(d.get_dmthuoc(r["ten"].ToString(),r["dang"].ToString(),r["cachdung"].ToString(),r["tenhc"].ToString()));
                        m.updrec_toathuocct(dsct.Tables[0], decimal.Parse(r["stt"].ToString()), i_ma, r["ten"].ToString(), r["dang"].ToString(), r["tenhc"].ToString(), decimal.Parse(r["soluong"].ToString()), r["cachdung"].ToString(), decimal.Parse(r["solan"].ToString()), decimal.Parse(r["lan"].ToString()));
					}
                    d.upd_toathuocct(s_ngay, l_id, decimal.Parse(r["stt"].ToString()), i_ma, decimal.Parse(r["soluong"].ToString()), r["cachdung"].ToString(), decimal.Parse(r["solan"].ToString()), decimal.Parse(r["lan"].ToString()));
                    m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
				}
				catch(Exception ex){MessageBox.Show(ex.Message);}
			}
			m.updrec_toathuocll(dtll,l_id,s_ngay,s_makp,s_mabs,chandoan.Text,maicd.Text,ghichu.Text,songay.Value);
			ref_text();
			ena_object(false);
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			try
			{
				l_id=decimal.Parse(cmbNgay.SelectedValue.ToString());
				load_head();
				load_grid();
				ref_text();
			}
			catch{}
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (dtll.Rows.Count==0) return;
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
                int itable = m.tableid(m.mmyy(s_ngay), "d_toathuocll");
                m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                m.upd_eve_upd_del(s_ngay, itable, i_userid, "del", m.fields(user + d.mmyy(s_ngay) + ".d_toathuocll", "id=" + l_id));
                itable = m.tableid(m.mmyy(s_ngay), "d_toathuocct");
                foreach (DataRow r in m.get_data("select * from " + user + d.mmyy(s_ngay) + ".d_toathuocct where id=" + l_id).Tables[0].Rows)
                {
                    m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "del", m.fields(user + d.mmyy(s_ngay) + ".d_toathuocct", "id=" + l_id + " and stt=" + decimal.Parse(r["stt"].ToString())));
                }
				m.execute_data("delete from "+user+d.mmyy(s_ngay)+".d_toathuocct where id="+l_id);
                m.execute_data("delete from " + user + d.mmyy(s_ngay) + ".d_toathuocll where id=" + l_id);
				m.delrec(dtll,"id="+l_id);
				dtll.AcceptChanges();
				if (dtll.Rows.Count>0) l_id=decimal.Parse(cmbNgay.SelectedValue.ToString());
				else l_id=0;
				load_head();
				ref_text();
			}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
            sql = "select a.stt,a.mabd,b.ten,b.dang,nullif(b.tenhc,' ') as tenhc,a.soluong,a.cachdung,a.solan,a.lan from " + user + d.mmyy(s_ngay) + ".d_toathuocct a," + user + ".d_dmthuoc b";
            sql += " where a.mabd=b.id and a.id=" + l_id + " order by a.stt";
            DataSet dsxml = m.get_data(sql);
            dsxml.Tables[0].Columns.Add("nguoinha");
			string schandoan=chandoan.Text.Trim()+";",ngayhen="",ghichuhen="";
            foreach (DataRow r in m.get_data("select chandoan from " + user + d.mmyy(s_ngay) + ".cdkemtheo where maql=" + l_maql + " order by stt").Tables[0].Rows)
				schandoan+=r["chandoan"].ToString()+";";
            foreach (DataRow r in m.get_data("select * from " + user + d.mmyy(s_ngay) + ".hen where maql=" + l_maql).Tables[0].Rows)
            {
                DateTime dt = m.StringToDate(s_ngay);
                switch (int.Parse(r["loai"].ToString()))
                {
                    case 1: ngayhen = m.DateToString("dd/MM/yyyy", dt.AddDays(int.Parse(r["songay"].ToString())));
                        break;
                    case 2: ngayhen = m.DateToString("dd/MM/yyyy", dt.AddDays(7 * int.Parse(r["songay"].ToString())));
                        break;
                    case 3: ngayhen = m.DateToString("dd/MM/yyyy", dt.AddMonths(int.Parse(r["songay"].ToString())));
                        break;
                    default: ngayhen = m.DateToString("dd/MM/yyyy", dt.AddYears(int.Parse(r["songay"].ToString())));
                        break;
                }
                ghichuhen = r["ghichu"].ToString();
            }
            string stuoi = tuoi.Text;
            string gioitinh = "",nguoinha="";
            foreach (DataRow r in m.get_data("select * from " + user + d.mmyy(s_ngay) + ".quanhe where maql=" + l_maql).Tables[0].Rows)
            {
                nguoinha = r["quanhe"].ToString().Trim() + " " + r["hoten"].ToString();
                break;
            }
            if (nguoinha != "")
                foreach (DataRow r in dsxml.Tables[0].Rows) r["nguoinha"] = nguoinha;
            foreach (DataRow r in m.get_data("select phai from " + user + ".btdbn where mabn='" + mabn.Text + "'").Tables[0].Rows)
                gioitinh = (r["phai"].ToString() == "0") ? "Nam" : "Nữ";
            stuoi = stuoi + "^" + gioitinh;
            if (chkXml.Checked)
            {
                if (!System.IO.Directory.Exists("..//xml")) System.IO.Directory.CreateDirectory("..//xml");
                dsxml.WriteXml("..//xml//donthuoc.xml", XmlWriteMode.WriteSchema);
            }
			if (chkXem.Checked)
			{
				dllReportM.frmReport f=new dllReportM.frmReport(m,dsxml.Tables[0],"d_donthuoc.rpt",hoten.Text,stuoi,s_diachi,schandoan,ghichu.Text,tenbs.Text,dsct.Tables[0].Rows.Count.ToString(),mabn.Text,ngayhen+"^"+s_ngaykham,ghichuhen+"^"+tenkp.Text);
				f.ShowDialog(this);
			}
			else print.Printer(m,dsxml,"d_donthuoc.rpt",hoten.Text,stuoi,s_diachi,schandoan,ghichu.Text,tenbs.Text,dsct.Tables[0].Rows.Count.ToString(),mabn.Text,ngayhen+"^"+s_ngaykham,ghichuhen+"^"+tenkp.Text,1);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
			if (!add_item(false)) return;
			emp_item();
			ten.Focus();
		}

		private void butXoa_Click(object sender, System.EventArgs e)
		{
			if (dsct.Tables[0].Rows.Count==0) return;
            m.updrec_toathuocct(dsxoa.Tables[0], decimal.Parse(stt.Text), decimal.Parse(ma.Text), ten.Text, dvt.Text, tenhc.Text, decimal.Parse(soluong.Text), cachdung.Text, solan.Value, (moilan.Text != "") ? decimal.Parse(moilan.Text) : 1);
			m.delrec(dsct.Tables[0],"stt="+decimal.Parse(stt.Text));
			dsct.AcceptChanges();
			dsxoa.AcceptChanges();
			if (dsct.Tables[0].Rows.Count==0) emp_item();
			else ref_text();
		}

		private bool add_item(bool skip)
		{
			if (skip && (ten.Text=="" || ma.Text=="" || soluong.Text=="")) return true;
			if (!bDanhmuc) ma.Text="0";
			if (ten.Text=="" || ma.Text=="")
			{
				ten.Focus();
				return false;
			}
			if (soluong.Text=="")
			{
				soluong.Focus();
				return false;
			}
			if (stt.Text=="" || stt.Text=="0") stt.Text=m.get_stt(dsct.Tables[0]).ToString();
            m.updrec_toathuocct(dsct.Tables[0], decimal.Parse(stt.Text), decimal.Parse(ma.Text), ten.Text, dvt.Text, tenhc.Text, decimal.Parse(soluong.Text), cachdung.Text, solan.Value, (moilan.Text != "") ? decimal.Parse(moilan.Text) : 1);
			return true;
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void listThuoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				try
				{
					DataRow r=m.getrowbyid(dtthuoc,"id="+decimal.Parse(ma.Text));
					if (r!=null)
					{
						tenhc.Text=r["tenhc"].ToString();
						ten.Text=r["ten"].ToString();
						dvt.Text=r["dang"].ToString();
						if (!bDanhmuc) cachdung.Text=r["cachdung"].ToString();
					}
				}
				catch{}
			}
		}

		private void load_treeView()
		{
            if ((i_sudungthuoc == 2 && l_maql == 0) || nam == "") return;
            sql = "select to_char(a.ngay,'yyyymmdd')||a.makp as ngay,e.tenkp,a.id,b.mabd,sum(b.soluong) as soluong ";
            sql += " from xxx.d_toathuocll a inner join xxx.d_toathuocct b on a.id=b.id left join " + user + ".btdkp_bv e on a.makp=e.makp";
            sql += " where a.mabn='" + mabn.Text + "'";
            if (i_sudungthuoc == 2) sql += " and a.maql=" + l_maql;
            if (i_chinhanh != 0) sql += " and (chinhanh=0 or chinhanh=" + i_chinhanh + ") ";
            sql += " group by to_char(a.ngay,'yyyymmdd')||a.makp,e.tenkp,a.id,b.mabd";
            treeView1.Nodes.Clear();
            TreeNode node;
            DataTable dtngay = m.get_data_nam(nam, sql).Tables[0];
            //DataTable dtngay = m
            string ngay = "";
            DataRow[] dr;
            DataRow r;
            foreach (DataRow r1 in dtngay.Select("true", "ngay desc"))
            {
                if (ngay != r1["ngay"].ToString() + "[" + r1["tenkp"].ToString().Trim() + "]")
                {
                    ngay = r1["ngay"].ToString() + "[" + r1["tenkp"].ToString().Trim() + "]";
                    node = treeView1.Nodes.Add(ngay.Substring(6, 2).PadLeft(2,'0') + "/" + ngay.Substring(4, 2).PadLeft(2,'0') + "/" + ngay.Substring(0, 4) + ngay.Substring(10));
                    dr = dtngay.Select("ngay='" + ngay.Substring(0, 10) + "'");
                    for (int i = 0; i < dr.Length; i++)
                    {
                        r = d.getrowbyid(dtthuoc, "id=" + decimal.Parse(dr[i]["mabd"].ToString()));
                        if (r != null) node.Nodes.Add(r["ten"].ToString().Trim() + "/" + r["tenhc"].ToString().Trim() + " " + r["dang"].ToString().Trim() + " (" + dr[i]["soluong"].ToString().Trim() + ")");
                    }
                }
            }
		}

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
            if (e.Action == TreeViewAction.ByMouse || e.Action == TreeViewAction.ByKeyboard)
            {
                try
                {
                    s_ngaymakp = e.Node.FullPath.Trim();
                    if (e.Node.Level == 0)
                    {
                        s_ngay = e.Node.Text.Substring(0, 10);
                    }
                    else
                    {
                        s_ngay = e.Node.Parent.Text.Substring(0, 10);
                    }
                }
                catch { s_ngaymakp = ""; }
            }
        }

		private void ten_Validated(object sender, System.EventArgs e)
		{
//			if (!bDanhmuc && tenhc.Text=="")
//			{
//				listThuoc.Hide();
//				tenhc.Text=tenhc.Text;
//				if (ten.Enabled) tenhc.Focus();
//			}
		}

		private void tenhc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void dvt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDang.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listDang.Visible) listDang.Focus();
				else SendKeys.Send("{Tab}");
			}
		}

		private void dvt_TextChanged(object sender, System.EventArgs e)
		{
			Filter(dvt.Text,listDang);
			listDang.BrowseToDanhmuc(dvt,soluong,0);
		}

		private void dvt_Validated(object sender, System.EventArgs e)
		{
			if(!listDang.Focused) listDang.Hide();
		}

		private void Filter(string ten,LibList.List list)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[list.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void tenbs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDMBS.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listDMBS.Visible) listDMBS.Focus();
				else SendKeys.Send("{Tab}");
			}		
		}

		private void Filt_dmbs(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDMBS.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="hoten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void tenbs_TextChanged(object sender, System.EventArgs e)
		{
			Filt_dmbs(tenbs.Text);
			listDMBS.BrowseToDanhmuc(tenbs,mabs,ghichu);
		}

		private void butHen_Click(object sender, System.EventArgs e)
		{
		}

        private void songay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");    
        }

        private void solan_Validated(object sender, EventArgs e)
        {
            gc_cachdung();
        }
        private void gc_cachdung()
        {
            if (moilan.Text != "" && ma.Text.Trim()!="")
            {
                DataRow r1 = d.getrowbyid(dtthuoc, "id=" + decimal.Parse(ma.Text));
                if (r1 != null)
                     cachdung.Text = r1["duongdung"].ToString().Trim() + " " + lan.Change_language_MessageText("ngày") + " " + solan.Value.ToString() + " " + lan.Change_language_MessageText("lần , lần") + " " + moilan.Text.ToString().Trim() + " " + r1["dang"].ToString().Trim();
                decimal sl = Math.Max(songay.Value, 1) * solan.Value * decimal.Parse(moilan.Text);
                soluong.Text = sl.ToString();
                soluong.Refresh();
            }
        }

        private void moilan_Validated(object sender, EventArgs e)
        {
            gc_cachdung();
        }

        private void ghichu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                ghichu.Text = m.Viettat(ghichu.Text) + " ";
                SendKeys.Send("{END}");
            }
            else if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7 && butLuu.Enabled)
            {
                try
                {
                    DataRow r1 = m.getrowbyid(dtngay, "substring(ngay,1,8)='" + s_ngaymakp.Substring(6, 4) + s_ngaymakp.Substring(3, 2) + s_ngaymakp.Substring(0, 2) + "' and tenkp='" + s_ngaymakp.Substring(11, s_ngaymakp.Length - 12) + "'");
                    if (r1 != null) get_cholai(decimal.Parse(r1["id"].ToString()));
                }
                catch { }
            }
        }
        private void get_cholai(decimal idcholai)
        {
            dsct.Clear();
            sql = "select a.stt,a.mabd,b.ten,b.dang,nullif(b.tenhc,' ') as tenhc,a.soluong,a.cachdung,a.solan,a.lan ";
            sql += " from xxx.d_toathuocct a," + user + ".d_dmthuoc b";
            sql += " where a.mabd=b.id and a.id=" + idcholai + " order by a.stt";
            foreach (DataRow r in d.get_data_nam(nam, sql).Tables[0].Rows)
                m.updrec_toathuocct(dsct.Tables[0], decimal.Parse(r["stt"].ToString()), decimal.Parse(r["mabd"].ToString()), r["ten"].ToString(), r["dang"].ToString(), r["tenhc"].ToString(), decimal.Parse(r["soluong"].ToString()), r["cachdung"].ToString(), decimal.Parse(r["solan"].ToString()), decimal.Parse(r["lan"].ToString()));
            ref_text();
        }

        private void butCholai_Click(object sender, EventArgs e)
        {
            string sql1 = "";
            if (butMoi.Enabled) return;
            if (mabn.Text.Trim().Length != i_maxlength_mabn)
            {
                mabn.Focus();
                return;
            }
            
            sql1 = "select a.id,to_char(a.ngay,'yyyymmdd') as ngay from xxx.d_toathuocll a,xxx.d_toathuocct c where a.id=c.id  and a.mabn='" + mabn.Text.Trim() + "' and to_char(a.ngay,'dd/mm/yyyy')='"+s_ngay.Substring(0,10)+"'";
            DataSet ads = d.get_thuoc(s_ngay, ngay.Text, sql1);// gam 10-05-2011
            string idcholai = "0";
            if (ads.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ads.Tables[0].Select("true", "ngay desc"))
                {
                    idcholai += r["id"].ToString() + ",";                    
                }
                idcholai = idcholai.Substring(0, idcholai.Length - 1);
            }
            else
                idcholai = "0";
            if (idcholai == "0") return;

            sql1 = "select a.songay,b.mabd,b.soluong,b.cachdung,f.ma,f.ten,f.tenhc,f.dang,f.mahc,";
            sql1 += "b.solan,b.lan from xxx.d_toathuocll a,xxx.d_toathuocct b,medibv.d_dmbd f ";
            sql1 += "where a.id=b.id and b.mabd=f.id and a.id in (" + idcholai + ") order by a.id,b.stt";

            DataTable tmp = d.get_thuoc(s_ngay, s_ngay, sql1).Tables[0];
            int i = 0;
            dsct.Clear();
            foreach (DataRow rct in tmp.Rows)
            {
                
                i++;
                m.updrec_toathuocct(dsct.Tables[0], i, decimal.Parse(rct["mabd"].ToString()), rct["ten"].ToString(),
                    rct["dang"].ToString(), rct["tenhc"].ToString(), decimal.Parse(rct["soluong"].ToString()), 
                    rct["cachdung"].ToString(), decimal.Parse(rct["solan"].ToString()), decimal.Parse(rct["lan"].ToString()));
               
            }
            s_ngay = m.Ngayhienhanh;
            l_id = 0;
            emp_item();// gam 18-05-2011
            //butLuu_Click(null, null);

           

        }
	}
}
