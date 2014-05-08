using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibDuoc;

namespace Medisoft
{
	public class frmGiaythuphanungthuoc : System.Windows.Forms.Form
    {
        #region Khai bao
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private LibMedi.AccessData m;
		private LibDuoc.AccessData d;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox tuoi;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.TextBox txtchandoan;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox diachi;
		private LibList.List list;
		private System.Windows.Forms.TextBox ma;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butMoi;
		private string sql,user;
		private int i_row,i_userid,i_loaiba=0;
        
		private DataSet ds=new DataSet();
        private DataSet dsthuoc = new DataSet();
		private System.ComponentModel.Container components = null;
        private TextBox gioitinh;
        private Label label7;
        private System.Windows.Forms.MaskedTextBox ngaythu;
        private Label label6;
        private Label label8;
        private TextBox txttenthuoc;
        private Label label9;
        private TextBox txtppthu;
        private Label label10;
        private TextBox txtmabschidinh;
        private ComboBox txttenbschidinh;
        private ComboBox txttennguoithu;
        private TextBox txtmanguoithu;
        private Label label11;
        private ComboBox txttenbsdockq;
        private TextBox txtmabsdockq;
        private Label label12;
        private Label label13;
        private System.Windows.Forms.MaskedTextBox txtngaydockq;
        private LibList.List listthuoc;
        private Button butthem;
        private bool bbadt = false;
        private Button butin;
        private CheckBox chkXML;
        private LibList.List listbschidinh;
        private LibList.List listnguoithu;
        private LibList.List listbsdoc;
        DataTable dtbs = new DataTable();
        private TextBox txtbschidinh;
        private TextBox txtnguoithu;
        private TextBox txtbsdoc;
        private DataGridView dataGridView1;
        private DataGridViewCheckBoxColumn chon;
        private DataGridViewTextBoxColumn cngaythu;
        private DataGridViewTextBoxColumn tenthuoc;
        private DataGridViewTextBoxColumn ppthu;
        private DataGridViewTextBoxColumn bschidinh;
        private DataGridViewTextBoxColumn nguoithu;
        private DataGridViewTextBoxColumn bsdockq;
        private DataGridViewTextBoxColumn ngaydockq;
        private DataGridViewTextBoxColumn mabd;
        private DataGridViewTextBoxColumn mabs;
        private DataGridViewTextBoxColumn mabsthu;
        private DataGridViewTextBoxColumn mabsdoc;
        private DataGridViewTextBoxColumn id;
        private decimal l_id = 0;
        #endregion

        public frmGiaythuphanungthuoc(LibMedi.AccessData acc,string s_mabn,string s_hoten,string s_tuoi,string s_diachi)
		{
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
			d=new LibDuoc.AccessData();
			mabn.Text=s_mabn;
			hoten.Text=s_hoten;
			tuoi.Text=s_tuoi;
			diachi.Text=s_diachi;
		}
        //Tu:25/05/2011
        public frmGiaythuphanungthuoc(LibMedi.AccessData acc, string s_mabn, string s_hoten, string s_tuoi, string s_diachi,bool _badt,int _i_userid,int _i_loaiba)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
            d = new LibDuoc.AccessData();
            mabn.Text = s_mabn;
            hoten.Text = s_hoten;
            tuoi.Text = s_tuoi;
            diachi.Text = s_diachi;
            bbadt = _badt;
            i_userid = _i_userid;
            i_loaiba = _i_loaiba;
        }
        //end Tu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGiaythuphanungthuoc));
            this.hoten = new System.Windows.Forms.TextBox();
            this.tuoi = new System.Windows.Forms.TextBox();
            this.mabn = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.txtchandoan = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.diachi = new System.Windows.Forms.TextBox();
            this.list = new LibList.List();
            this.ma = new System.Windows.Forms.TextBox();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.gioitinh = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ngaythu = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txttenthuoc = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtppthu = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtmabschidinh = new System.Windows.Forms.TextBox();
            this.txttenbschidinh = new System.Windows.Forms.ComboBox();
            this.txttennguoithu = new System.Windows.Forms.ComboBox();
            this.txtmanguoithu = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txttenbsdockq = new System.Windows.Forms.ComboBox();
            this.txtmabsdockq = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtngaydockq = new System.Windows.Forms.MaskedTextBox();
            this.listthuoc = new LibList.List();
            this.butthem = new System.Windows.Forms.Button();
            this.butin = new System.Windows.Forms.Button();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.listbschidinh = new LibList.List();
            this.listnguoithu = new LibList.List();
            this.listbsdoc = new LibList.List();
            this.txtbschidinh = new System.Windows.Forms.TextBox();
            this.txtnguoithu = new System.Windows.Forms.TextBox();
            this.txtbsdoc = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cngaythu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenthuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ppthu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bschidinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nguoithu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsdockq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaydockq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mabd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mabs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mabsthu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mabsdoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(168, 4);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(152, 21);
            this.hoten.TabIndex = 1;
            // 
            // tuoi
            // 
            this.tuoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tuoi.Enabled = false;
            this.tuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuoi.Location = new System.Drawing.Point(350, 4);
            this.tuoi.Name = "tuoi";
            this.tuoi.Size = new System.Drawing.Size(41, 21);
            this.tuoi.TabIndex = 2;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(53, 4);
            this.mabn.MaxLength = 10;
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(69, 21);
            this.mabn.TabIndex = 0;
            this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
            this.mabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(317, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tuổi :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(120, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.dataGrid1.Location = new System.Drawing.Point(6, 367);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(78, 28);
            this.dataGrid1.TabIndex = 14;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // txtchandoan
            // 
            this.txtchandoan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtchandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtchandoan.Enabled = false;
            this.txtchandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtchandoan.Location = new System.Drawing.Point(70, 401);
            this.txtchandoan.Name = "txtchandoan";
            this.txtchandoan.Size = new System.Drawing.Size(753, 21);
            this.txtchandoan.TabIndex = 5;
            this.txtchandoan.TextChanged += new System.EventHandler(this.ten_TextChanged);
            this.txtchandoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Location = new System.Drawing.Point(-4, 401);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 23);
            this.label5.TabIndex = 16;
            this.label5.Text = "Chẩn đoán :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(486, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 23);
            this.label4.TabIndex = 17;
            this.label4.Text = "Địa chỉ :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // diachi
            // 
            this.diachi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(532, 4);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(291, 21);
            this.diachi.TabIndex = 4;
            // 
            // list
            // 
            this.list.BackColor = System.Drawing.SystemColors.Info;
            this.list.ColumnCount = 0;
            this.list.Location = new System.Drawing.Point(125, 516);
            this.list.MatchBufferTimeOut = 1000;
            this.list.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(75, 17);
            this.list.TabIndex = 21;
            this.list.TextIndex = -1;
            this.list.TextMember = null;
            this.list.ValueIndex = -1;
            this.list.Visible = false;
            // 
            // ma
            // 
            this.ma.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ma.Enabled = false;
            this.ma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ma.Location = new System.Drawing.Point(-81, 516);
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(40, 21);
            this.ma.TabIndex = 22;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(747, 496);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 22;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(677, 496);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 21;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(537, 496);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 18;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(397, 496);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 17;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(327, 496);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 20;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(257, 496);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 19;
            this.butMoi.Text = "     &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // gioitinh
            // 
            this.gioitinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gioitinh.Enabled = false;
            this.gioitinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gioitinh.Location = new System.Drawing.Point(446, 4);
            this.gioitinh.Name = "gioitinh";
            this.gioitinh.Size = new System.Drawing.Size(41, 21);
            this.gioitinh.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(393, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 23);
            this.label7.TabIndex = 29;
            this.label7.Text = "Giới tính :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngaythu
            // 
            this.ngaythu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ngaythu.Location = new System.Drawing.Point(70, 424);
            this.ngaythu.Mask = "00/00/0000 90:00";
            this.ngaythu.Name = "ngaythu";
            this.ngaythu.Size = new System.Drawing.Size(100, 20);
            this.ngaythu.TabIndex = 6;
            this.ngaythu.ValidatingType = typeof(System.DateTime);
            this.ngaythu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.Location = new System.Drawing.Point(-4, 424);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 23);
            this.label6.TabIndex = 32;
            this.label6.Text = "Ngày thử :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.Location = new System.Drawing.Point(171, 424);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 23);
            this.label8.TabIndex = 33;
            this.label8.Text = "Tên thuốc:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txttenthuoc
            // 
            this.txttenthuoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txttenthuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txttenthuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttenthuoc.Location = new System.Drawing.Point(228, 424);
            this.txttenthuoc.Name = "txttenthuoc";
            this.txttenthuoc.Size = new System.Drawing.Size(322, 21);
            this.txttenthuoc.TabIndex = 7;
            this.txttenthuoc.TextChanged += new System.EventHandler(this.txttenthuoc_TextChanged);
            this.txttenthuoc.Validated += new System.EventHandler(this.txttenthuoc_Validated);
            this.txttenthuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txttenthuoc_KeyDown);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Location = new System.Drawing.Point(552, 422);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 23);
            this.label9.TabIndex = 35;
            this.label9.Text = "Phương pháp thử:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtppthu
            // 
            this.txtppthu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtppthu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtppthu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtppthu.Location = new System.Drawing.Point(646, 424);
            this.txtppthu.Name = "txtppthu";
            this.txtppthu.Size = new System.Drawing.Size(177, 21);
            this.txtppthu.TabIndex = 8;
            this.txtppthu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.Location = new System.Drawing.Point(-4, 447);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 23);
            this.label10.TabIndex = 37;
            this.label10.Text = "Bác sĩ chỉ định :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtmabschidinh
            // 
            this.txtmabschidinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtmabschidinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtmabschidinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmabschidinh.Location = new System.Drawing.Point(80, 447);
            this.txtmabschidinh.Name = "txtmabschidinh";
            this.txtmabschidinh.Size = new System.Drawing.Size(42, 21);
            this.txtmabschidinh.TabIndex = 9;
            this.txtmabschidinh.Validated += new System.EventHandler(this.txtmabschidinh_Validated);
            this.txtmabschidinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // txttenbschidinh
            // 
            this.txttenbschidinh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txttenbschidinh.FormattingEnabled = true;
            this.txttenbschidinh.Location = new System.Drawing.Point(-94, 516);
            this.txttenbschidinh.Name = "txttenbschidinh";
            this.txttenbschidinh.Size = new System.Drawing.Size(159, 21);
            this.txttenbschidinh.TabIndex = 10;
            this.txttenbschidinh.Visible = false;
            this.txttenbschidinh.SelectedValueChanged += new System.EventHandler(this.txttenbschidinh_SelectedValueChanged);
            this.txttenbschidinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // txttennguoithu
            // 
            this.txttennguoithu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txttennguoithu.FormattingEnabled = true;
            this.txttennguoithu.Location = new System.Drawing.Point(-94, 516);
            this.txttennguoithu.Name = "txttennguoithu";
            this.txttennguoithu.Size = new System.Drawing.Size(158, 21);
            this.txttennguoithu.TabIndex = 12;
            this.txttennguoithu.Visible = false;
            this.txttennguoithu.SelectedValueChanged += new System.EventHandler(this.txttennguoithu_SelectedValueChanged);
            this.txttennguoithu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // txtmanguoithu
            // 
            this.txtmanguoithu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtmanguoithu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtmanguoithu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmanguoithu.Location = new System.Drawing.Point(349, 447);
            this.txtmanguoithu.Name = "txtmanguoithu";
            this.txtmanguoithu.Size = new System.Drawing.Size(42, 21);
            this.txtmanguoithu.TabIndex = 11;
            this.txtmanguoithu.Validated += new System.EventHandler(this.txtmanguoithu_Validated);
            this.txtmanguoithu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.Location = new System.Drawing.Point(288, 447);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 23);
            this.label11.TabIndex = 40;
            this.label11.Text = "Người thử :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txttenbsdockq
            // 
            this.txttenbsdockq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txttenbsdockq.FormattingEnabled = true;
            this.txttenbsdockq.Location = new System.Drawing.Point(-90, 516);
            this.txttenbsdockq.Name = "txttenbsdockq";
            this.txttenbsdockq.Size = new System.Drawing.Size(154, 21);
            this.txttenbsdockq.TabIndex = 14;
            this.txttenbsdockq.Visible = false;
            this.txttenbsdockq.SelectedValueChanged += new System.EventHandler(this.txttenbsdockq_SelectedValueChanged);
            this.txttenbsdockq.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txttenbsdockq_KeyDown);
            // 
            // txtmabsdockq
            // 
            this.txtmabsdockq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtmabsdockq.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtmabsdockq.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmabsdockq.Location = new System.Drawing.Point(620, 447);
            this.txtmabsdockq.Name = "txtmabsdockq";
            this.txtmabsdockq.Size = new System.Drawing.Size(42, 21);
            this.txtmabsdockq.TabIndex = 13;
            this.txtmabsdockq.Validated += new System.EventHandler(this.txtmabsdockq_Validated);
            this.txtmabsdockq.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.Location = new System.Drawing.Point(554, 447);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 23);
            this.label12.TabIndex = 43;
            this.label12.Text = "Bác sĩ đọc :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.Location = new System.Drawing.Point(-4, 470);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 23);
            this.label13.TabIndex = 47;
            this.label13.Text = "Ngày đọc kết quả :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtngaydockq
            // 
            this.txtngaydockq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtngaydockq.Location = new System.Drawing.Point(100, 470);
            this.txtngaydockq.Mask = "00/00/0000 90:00";
            this.txtngaydockq.Name = "txtngaydockq";
            this.txtngaydockq.Size = new System.Drawing.Size(100, 20);
            this.txtngaydockq.TabIndex = 15;
            this.txtngaydockq.ValidatingType = typeof(System.DateTime);
            this.txtngaydockq.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // listthuoc
            // 
            this.listthuoc.BackColor = System.Drawing.SystemColors.Info;
            this.listthuoc.ColumnCount = 0;
            this.listthuoc.Location = new System.Drawing.Point(80, 516);
            this.listthuoc.MatchBufferTimeOut = 1000;
            this.listthuoc.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listthuoc.Name = "listthuoc";
            this.listthuoc.Size = new System.Drawing.Size(75, 17);
            this.listthuoc.TabIndex = 48;
            this.listthuoc.TextIndex = -1;
            this.listthuoc.TextMember = null;
            this.listthuoc.ValueIndex = -1;
            this.listthuoc.Visible = false;
            // 
            // butthem
            // 
            this.butthem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butthem.Enabled = false;
            this.butthem.Image = ((System.Drawing.Image)(resources.GetObject("butthem.Image")));
            this.butthem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butthem.Location = new System.Drawing.Point(467, 496);
            this.butthem.Name = "butthem";
            this.butthem.Size = new System.Drawing.Size(70, 25);
            this.butthem.TabIndex = 16;
            this.butthem.Text = "     &Thêm";
            this.butthem.Click += new System.EventHandler(this.butthem_Click);
            // 
            // butin
            // 
            this.butin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butin.Enabled = false;
            this.butin.Image = ((System.Drawing.Image)(resources.GetObject("butin.Image")));
            this.butin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butin.Location = new System.Drawing.Point(607, 496);
            this.butin.Name = "butin";
            this.butin.Size = new System.Drawing.Size(70, 25);
            this.butin.TabIndex = 49;
            this.butin.Text = "&In";
            this.butin.Click += new System.EventHandler(this.butin_Click);
            // 
            // chkXML
            // 
            this.chkXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkXML.AutoSize = true;
            this.chkXML.Location = new System.Drawing.Point(4, 499);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(85, 17);
            this.chkXML.TabIndex = 50;
            this.chkXML.Text = "Xuất ra XML";
            this.chkXML.UseVisualStyleBackColor = true;
            // 
            // listbschidinh
            // 
            this.listbschidinh.BackColor = System.Drawing.SystemColors.Info;
            this.listbschidinh.ColumnCount = 0;
            this.listbschidinh.Location = new System.Drawing.Point(176, 516);
            this.listbschidinh.MatchBufferTimeOut = 1000;
            this.listbschidinh.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listbschidinh.Name = "listbschidinh";
            this.listbschidinh.Size = new System.Drawing.Size(75, 17);
            this.listbschidinh.TabIndex = 51;
            this.listbschidinh.TextIndex = -1;
            this.listbschidinh.TextMember = null;
            this.listbschidinh.ValueIndex = -1;
            this.listbschidinh.Visible = false;
            // 
            // listnguoithu
            // 
            this.listnguoithu.BackColor = System.Drawing.SystemColors.Info;
            this.listnguoithu.ColumnCount = 0;
            this.listnguoithu.Location = new System.Drawing.Point(205, 516);
            this.listnguoithu.MatchBufferTimeOut = 1000;
            this.listnguoithu.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listnguoithu.Name = "listnguoithu";
            this.listnguoithu.Size = new System.Drawing.Size(75, 17);
            this.listnguoithu.TabIndex = 52;
            this.listnguoithu.TextIndex = -1;
            this.listnguoithu.TextMember = null;
            this.listnguoithu.ValueIndex = -1;
            this.listnguoithu.Visible = false;
            // 
            // listbsdoc
            // 
            this.listbsdoc.BackColor = System.Drawing.SystemColors.Info;
            this.listbsdoc.ColumnCount = 0;
            this.listbsdoc.Location = new System.Drawing.Point(240, 516);
            this.listbsdoc.MatchBufferTimeOut = 1000;
            this.listbsdoc.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listbsdoc.Name = "listbsdoc";
            this.listbsdoc.Size = new System.Drawing.Size(75, 17);
            this.listbsdoc.TabIndex = 53;
            this.listbsdoc.TextIndex = -1;
            this.listbsdoc.TextMember = null;
            this.listbsdoc.ValueIndex = -1;
            this.listbsdoc.Visible = false;
            // 
            // txtbschidinh
            // 
            this.txtbschidinh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbschidinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtbschidinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbschidinh.Location = new System.Drawing.Point(123, 447);
            this.txtbschidinh.Name = "txtbschidinh";
            this.txtbschidinh.Size = new System.Drawing.Size(159, 21);
            this.txtbschidinh.TabIndex = 10;
            this.txtbschidinh.TextChanged += new System.EventHandler(this.txtbschidinh_TextChanged);
            this.txtbschidinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbschidinh_KeyDown);
            // 
            // txtnguoithu
            // 
            this.txtnguoithu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtnguoithu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtnguoithu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnguoithu.Location = new System.Drawing.Point(392, 447);
            this.txtnguoithu.Name = "txtnguoithu";
            this.txtnguoithu.Size = new System.Drawing.Size(158, 21);
            this.txtnguoithu.TabIndex = 12;
            this.txtnguoithu.TextChanged += new System.EventHandler(this.txtnguoithu_TextChanged);
            this.txtnguoithu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtnguoithu_KeyDown);
            // 
            // txtbsdoc
            // 
            this.txtbsdoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtbsdoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtbsdoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbsdoc.Location = new System.Drawing.Point(663, 447);
            this.txtbsdoc.Name = "txtbsdoc";
            this.txtbsdoc.Size = new System.Drawing.Size(160, 21);
            this.txtbsdoc.TabIndex = 14;
            this.txtbsdoc.TextChanged += new System.EventHandler(this.txtbsdoc_TextChanged);
            this.txtbsdoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbsdoc_KeyDown);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chon,
            this.cngaythu,
            this.tenthuoc,
            this.ppthu,
            this.bschidinh,
            this.nguoithu,
            this.bsdockq,
            this.ngaydockq,
            this.mabd,
            this.mabs,
            this.mabsthu,
            this.mabsdoc,
            this.id});
            this.dataGridView1.Location = new System.Drawing.Point(4, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(819, 364);
            this.dataGridView1.TabIndex = 57;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // chon
            // 
            this.chon.DataPropertyName = "chon";
            this.chon.FalseValue = "0";
            this.chon.HeaderText = "In";
            this.chon.Name = "chon";
            this.chon.TrueValue = "1";
            this.chon.Width = 30;
            // 
            // cngaythu
            // 
            this.cngaythu.DataPropertyName = "ngaythu";
            this.cngaythu.HeaderText = "Ngày thử";
            this.cngaythu.Name = "cngaythu";
            this.cngaythu.ReadOnly = true;
            this.cngaythu.Width = 90;
            // 
            // tenthuoc
            // 
            this.tenthuoc.DataPropertyName = "ten";
            this.tenthuoc.HeaderText = "Tên thuốc";
            this.tenthuoc.Name = "tenthuoc";
            this.tenthuoc.ReadOnly = true;
            this.tenthuoc.Width = 200;
            // 
            // ppthu
            // 
            this.ppthu.DataPropertyName = "ppthu";
            this.ppthu.HeaderText = "Phương pháp thử";
            this.ppthu.Name = "ppthu";
            this.ppthu.ReadOnly = true;
            this.ppthu.Width = 120;
            // 
            // bschidinh
            // 
            this.bschidinh.DataPropertyName = "bschidinh";
            this.bschidinh.HeaderText = "Bác sĩ chỉ định";
            this.bschidinh.Name = "bschidinh";
            this.bschidinh.ReadOnly = true;
            this.bschidinh.Width = 150;
            // 
            // nguoithu
            // 
            this.nguoithu.DataPropertyName = "nguoithu";
            this.nguoithu.HeaderText = "Người thử";
            this.nguoithu.Name = "nguoithu";
            this.nguoithu.ReadOnly = true;
            this.nguoithu.Width = 150;
            // 
            // bsdockq
            // 
            this.bsdockq.DataPropertyName = "bsdockq";
            this.bsdockq.HeaderText = "Bác sĩ đọc kết quả";
            this.bsdockq.Name = "bsdockq";
            this.bsdockq.ReadOnly = true;
            this.bsdockq.Width = 150;
            // 
            // ngaydockq
            // 
            this.ngaydockq.DataPropertyName = "ngay_dockq";
            this.ngaydockq.HeaderText = "Ngày đọc kết quả";
            this.ngaydockq.Name = "ngaydockq";
            this.ngaydockq.ReadOnly = true;
            this.ngaydockq.Width = 90;
            // 
            // mabd
            // 
            this.mabd.DataPropertyName = "mabd";
            this.mabd.HeaderText = "mabd";
            this.mabd.Name = "mabd";
            this.mabd.ReadOnly = true;
            this.mabd.Visible = false;
            // 
            // mabs
            // 
            this.mabs.DataPropertyName = "mabs";
            this.mabs.HeaderText = "Column1";
            this.mabs.Name = "mabs";
            this.mabs.ReadOnly = true;
            this.mabs.Visible = false;
            // 
            // mabsthu
            // 
            this.mabsthu.DataPropertyName = "mabs_thu";
            this.mabsthu.HeaderText = "Column1";
            this.mabsthu.Name = "mabsthu";
            this.mabsthu.ReadOnly = true;
            this.mabsthu.Visible = false;
            // 
            // mabsdoc
            // 
            this.mabsdoc.DataPropertyName = "mabs_doc";
            this.mabsdoc.HeaderText = "Column1";
            this.mabsdoc.Name = "mabsdoc";
            this.mabsdoc.ReadOnly = true;
            this.mabsdoc.Visible = false;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "Column1";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // frmGiaythuphanungthuoc
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(827, 533);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtbsdoc);
            this.Controls.Add(this.txtnguoithu);
            this.Controls.Add(this.txtbschidinh);
            this.Controls.Add(this.listbsdoc);
            this.Controls.Add(this.listnguoithu);
            this.Controls.Add(this.listbschidinh);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.butin);
            this.Controls.Add(this.butthem);
            this.Controls.Add(this.listthuoc);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtngaydockq);
            this.Controls.Add(this.txttenbsdockq);
            this.Controls.Add(this.txtmabsdockq);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txttennguoithu);
            this.Controls.Add(this.txtmanguoithu);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txttenbschidinh);
            this.Controls.Add(this.txtmabschidinh);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtppthu);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txttenthuoc);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ngaythu);
            this.Controls.Add(this.gioitinh);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.list);
            this.Controls.Add(this.txtchandoan);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.tuoi);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.ma);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGiaythuphanungthuoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dị ứng thuốc";
            this.Load += new System.EventHandler(this.frmGiaythuphanungthuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmGiaythuphanungthuoc_Load(object sender, System.EventArgs e)
		{
            if (bbadt)
            {
                this.Location = new System.Drawing.Point(188 - 38, 120);//151
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Size = new Size(829 + 40, 610);
            }
            user = m.user;
			listthuoc.DisplayMember="ID";
            listthuoc.ValueMember = "TEN";
            dsthuoc=d.get_data("select id,ten from " + user + ".d_dmbd order by ten");
            listthuoc.DataSource = dsthuoc.Tables[0];

            dtbs = m.get_data("select ma,hoten from " + user + ".dmbs").Tables[0];

            listbschidinh.DataSource = dtbs;
            listbschidinh.ValueMember = "hoten";
            listbschidinh.DisplayMember = "ma";

            listnguoithu.DataSource = dtbs.Copy();
            listnguoithu.ValueMember = "hoten";
            listnguoithu.DisplayMember = "ma";

            listbsdoc.DataSource = dtbs.Copy();
            listbsdoc.ValueMember = "hoten";
            listbsdoc.DisplayMember = "ma";


			load_grid();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

			ref_text();
            ngaythu.Text = m.ngayhienhanh_server;
            txtngaydockq.Text = m.ngayhienhanh_server;
		}

		private void load_grid()
		{
            sql = "select 0 chon,to_char(a.ngaythu,'dd/mm/yyyy hh24:mi') as ngaythu,b.ten,a.ppthu,c.hoten as bschidinh,d.hoten as nguoithu,e.hoten as bsdockq,to_char(a.ngay_dockq,'dd/mm/yyyy hh24:mi') as ngay_dockq,a.mabd,a.mabs,a.mabs_thu,a.mabs_doc,a.id ";
            sql += "from " + user + ".giaythuphanungthuoc a inner join " + user + ".d_dmbd b on a.mabd=b.id inner join " + user + ".dmbs c ";
            sql += "on a.mabs=c.ma inner join " + user + ".dmbs d on a.mabs_thu=d.ma inner join " + user + ".dmbs e on a.mabs_doc=e.ma ";
            sql += " where a.mabn='" + mabn.Text + "'";
			ds=d.get_data(sql);
			dataGridView1.DataSource=ds.Tables[0];
		}

		

		private void ten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
		}

		private void ten_TextChanged(object sender, System.EventArgs e)
		{
			
		}

		private void ref_text()
		{
			try
			{
				i_row=dataGridView1.CurrentCell.RowIndex;
				//mucdo.SelectedValue=dataGrid1[i_row,2].ToString();
                ma.Text = dataGridView1[8, i_row].Value.ToString();
                ngaythu.Text = dataGridView1[1, i_row].Value.ToString();
                txttenthuoc.Text = dataGridView1[2, i_row].Value.ToString();
                txtppthu.Text = dataGridView1[3, i_row].Value.ToString();
                txtbschidinh.Text = dataGridView1[4, i_row].Value.ToString();
                txtnguoithu.Text = dataGridView1[5, i_row].Value.ToString();
                txtbsdoc.Text = dataGridView1[6, i_row].Value.ToString();
                txtngaydockq.Text = dataGridView1[7, i_row].Value.ToString();
                txtmabschidinh.Text = dataGridView1[9, i_row].Value.ToString();
                txtmanguoithu.Text = dataGridView1[10, i_row].Value.ToString();
                txtmabsdockq.Text = dataGridView1[11, i_row].Value.ToString();
                l_id = decimal.Parse(dataGridView1[12, i_row].Value.ToString());
			}
			catch(Exception exx){}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void Filter(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listthuoc.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void ena_object(bool ena)
		{
            //CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember];  
            //DataView dv = (DataView) cm.List; 
            //dv.AllowNew = false; 
			txtchandoan.Enabled=ena;
			butMoi.Enabled=!ena;
            butin.Enabled = !ena;
			butSua.Enabled=!ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			butLuu.Enabled=ena;
            butthem.Enabled = ena;
			butBoqua.Enabled=ena;
            mabn.Enabled = ena;
			if (!ena) butMoi.Focus();
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
            emp_head();
			ena_object(true);
			ngaythu.Focus();
            ds.Clear();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
			ena_object(true);
			txtchandoan.Enabled=false;
		}

		private bool kiemtra()
		{
            //if (txtchandoan.Text=="" || ma.Text=="")
            //{
            //    txtchandoan.Focus();
            //    return false;
            //}
			return true;
		}
		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
            
            
            foreach (DataRow r in ds.Tables[0].Rows)
            {
             l_id=decimal.Parse(r["id"].ToString());
                if (l_id == 0) l_id = m.getidyymmddhhmiss_stt_computer;
                if (!m.upd_giaythuphanungthuoc(l_id,0, mabn.Text, txtchandoan.Text, r["ngaythu"].ToString(),int.Parse(r["mabd"].ToString()),r["ppthu"].ToString()
                    ,r["mabs"].ToString(),r["mabs_thu"].ToString(),r["mabs_doc"].ToString(),r["ngay_dockq"].ToString(),i_userid))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin !"), LibMedi.AccessData.Msg);
                    return;
                }
            }
            //updrec_giaythuphanungthuoc(ds.Tables[0], ma.Text, txtchandoan.Text, int.Parse(mucdo.SelectedValue.ToString()), mucdo.Text);	
			ena_object(false);
            load_grid();
		}

        public void updrec_giaythuphanungthuoc(DataTable dt, string ma, string ten)//, int mucdo, string tenmucdo)
        {
            string exp = "id='" + l_id + "' and ngaythu='"+ngaythu.Text+"' and mabd="+ma;
            DataRow r = m.getrowbyid(dt, exp);
            if (r == null)
            {
                DataRow nrow = dt.NewRow();
                nrow["ngaythu"] = ngaythu.Text;
                nrow["ten"] = ten;
                nrow["ppthu"] = txtppthu.Text;
                nrow["mabs"] = txtmabschidinh.Text;
                nrow["mabs_thu"] = txtmanguoithu.Text;
                nrow["mabs_doc"] = txtmabsdockq.Text;
                nrow["ngay_dockq"] = txtngaydockq.Text;
                nrow["bschidinh"] = txtbschidinh.Text;
                nrow["nguoithu"] = txtnguoithu.Text;
                nrow["bsdockq"] = txtbsdoc.Text;
                nrow["mabd"] = ma;
                nrow["id"] = 0;
                nrow["chon"] = 0;
                ds.Tables[0].Rows.Add(nrow);
            }
            else
            {
                DataRow[] dr = dt.Select(exp);
                dr[0]["ngaythu"] = ngaythu.Text;
                dr[0]["ten"] = ten;
                dr[0]["ppthu"] = txtppthu.Text;
                dr[0]["mabs"] = txtmabschidinh.Text;
                dr[0]["mabs_thu"] = txtmanguoithu.Text;
                dr[0]["mabs_doc"] = txtmabsdockq.Text;
                dr[0]["ngay_dockq"] = txtngaydockq.Text;
                dr[0]["bschidinh"] = txtbschidinh.Text;
                dr[0]["nguoithu"] = txtnguoithu.Text;
                dr[0]["bsdockq"] = txtbsdoc.Text;
                dr[0]["mabd"] = ma;
                dr[0]["id"] = l_id;
            }
        }

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
            load_grid();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
                d.execute_data("delete from " + user + ".giaythuphanungthuoc where mabn='" + mabn.Text + "'" + " and mabd='" + ma.Text + "' and to_char(ngaythu,'dd/mm/yyyy hh24:mi')='"+ngaythu.Text+"'");
                m.delrec(ds.Tables[0], "mabd='" + ma.Text + "' and ngaythu='" + ngaythu.Text + "'");
				ref_text();
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void butthem_Click(object sender, EventArgs e)
        {
            //stt = m.get_stt(dsthuoc.Tables[0]).ToString();
            if (txtmabschidinh.Text.Trim() == "" || txtmanguoithu.Text.Trim() == "" || txtmabsdockq.Text.Trim() == "" || ma.Text.Trim() == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập đầy đủ thông tin !"), LibMedi.AccessData.Msg);
                if (ma.Text.Trim() == "") txttenthuoc.Focus();
                else if (txtmabschidinh.Text.Trim() == "") txtbschidinh.Focus();
                else if (txtmanguoithu.Text.Trim() == "") txtnguoithu.Focus();
                else if (txtmabsdockq.Text.Trim() == "") txtbsdoc.Focus();
                return;
            }
            if(m.getrowbyid(ds.Tables[0],"id="+l_id+" and mabd="+ma)!=null)
            {
                emp_detail();
                return;
            }
            l_id = 0;
            updrec_giaythuphanungthuoc(ds.Tables[0], ma.Text, txttenthuoc.Text);
            emp_detail();
            //dataGrid1.DataSource = dsthuoc.Tables[0];
            ngaythu.Focus();
            //load_grid();
        }

        private void txttenthuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listthuoc.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listthuoc.Visible) listthuoc.Focus();
                else SendKeys.Send("{Tab}");
            }
            DataRow dr = m.getrowbyid(dsthuoc.Tables[0],"ma='"+ma.Text+"'");
        }

        private void txttenthuoc_Validated(object sender, EventArgs e)
        {
            
        }

        private void txttenthuoc_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == txttenthuoc)
            {
                Filter(txttenthuoc.Text);
                listthuoc.BrowseToDmbd(txttenthuoc, ma, txtppthu, txttenthuoc.Location.X, txtppthu.Location.Y+21, txttenthuoc.Width, ma.Width);
            }
        }

        private void txttenbsdockq_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtngaydockq.Focus();
        }

        private void mabn_Validated(object sender, EventArgs e)
        {
            if (mabn.Text == "") return;
            DataSet ds_hc = new DataSet();
            string sql="",s_nam="",s_chandoan="";
            sql = "select a.nam,a.hoten,(to_number(to_char(sysdate,'yyyy'))-to_number(a.namsinh)) as tuoi, ";
            sql += "(case when a.phai=0 then 'Nam' else 'Nữ' end) as gioitinh,(d.tenpxa||'-'||c.tenquan||'-'||b.tentt) as diachi ";
            sql += "from "+user+".btdbn a,"+user+".btdtt b,"+user+".btdquan c,"+user+".btdpxa d ";
            sql += "where a.matt=b.matt and a.maqu=c.maqu and a.maphuongxa=d.maphuongxa and a.mabn='"+mabn.Text.Trim()+"'";
            ds_hc = m.get_data(sql);
            foreach (DataRow r in ds_hc.Tables[0].Rows)
            {
                hoten.Text = r["hoten"].ToString();
                tuoi.Text = r["tuoi"].ToString();
                gioitinh.Text = r["gioitinh"].ToString();
                diachi.Text = r["diachi"].ToString();
                s_nam = r["nam"].ToString();
            }

            if(s_nam=="" || s_nam.Trim().Trim('+')=="")s_nam=m.mmyy(m.ngayhienhanh_server.Substring(0,10));
            s_nam = s_nam.Trim('+');
            if (i_loaiba == 3) sql = "select maicd,chandoan from " + user + s_nam + ".benhanpk where mabn='" + mabn.Text.Trim() + "'";
            else if (i_loaiba == 2) sql = "select maicd,chandoan from " + user + ".benhanngtr where mabn='" + mabn.Text.Trim() + "'";
            foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
            {
                s_chandoan += r["chandoan"].ToString() + ",";
            }
            s_chandoan = s_chandoan.Trim(',');
            txtchandoan.Text = s_chandoan;
            load_grid();
            ngaythu.Focus();
        }

        private void txtmabschidinh_Validated(object sender, EventArgs e)
        {
            try
            {
                if (txtmabschidinh.Text != "") txtbschidinh.Text = m.getrowbyid(dtbs, "ma='" + txtmabschidinh.Text + "'")["hoten"].ToString();
            }
            catch { }
        }

        private void txtmanguoithu_Validated(object sender, EventArgs e)
        {
            try
            {
                if (txtmanguoithu.Text != "") txtnguoithu.Text = m.getrowbyid(dtbs, "ma='" + txtmanguoithu.Text + "'")["hoten"].ToString();
            }
            catch { }
        }

        private void txtmabsdockq_Validated(object sender, EventArgs e)
        {
            try
            {
                if (txtmabsdockq.Text != "") txtbsdoc.Text = m.getrowbyid(dtbs, "ma='" + txtbsdoc.Text + "'")["hoten"].ToString();
            }
            catch { }
        }

        private void txttenbschidinh_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == txttenbschidinh)
                txtmabschidinh.Text = txttenbschidinh.SelectedValue.ToString();
        }

        private void txttennguoithu_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == txttennguoithu)
                txtmanguoithu.Text = txttennguoithu.SelectedValue.ToString();
        }

        private void txttenbsdockq_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == txttenbsdockq)
                txtmabsdockq.Text = txttenbsdockq.SelectedValue.ToString();
        }

        private void butin_Click(object sender, EventArgs e)
        {
            DataSet ds_in = new DataSet();
            //string sql = "";
            //sql = "select distinct a.mabn,f.hoten,a.chandoan,to_char(a.ngaythu,'dd/mm/yyyy hh24:mi') as ngaythu,b.ten,a.ppthu,c.hoten as bschidinh,d.hoten as nguoithu,e.hoten as bsdockq,to_char(a.ngay_dockq,'dd/mm/yyyy hh24:mi') as ngay_dockq,a.mabd,a.mabs,a.mabs_thu,a.mabs_doc, ";
            //sql += "to_char(to_number(to_char(sysdate,'yyyy'))-to_number(f.namsinh)) as tuoi,(case when f.phai=0 then 'Nam' else 'Nữ' end) as gioitinh ";
            //sql += "from " + user + ".giaythuphanungthuoc a inner join " + user + ".d_dmbd b on a.mabd=b.id inner join " + user + ".dmbs c ";
            //sql += "on a.mabs=c.ma inner join " + user + ".dmbs d on a.mabs_thu=d.ma inner join " + user + ".dmbs e on a.mabs_doc=e.ma ";
            //sql += "inner join "+user+".btdbn f on a.mabn=f.mabn ";
            //sql += " where a.mabn='" + mabn.Text + "'";
            //ds_in = d.get_data(sql);
            ds_in.Tables.Add(ds.Tables[0].Copy());
            //ds_in.Tables[0] = ds.Tables[0].Clone();
            try
            {
                
                foreach (DataRow r in ds_in.Tables[0].Select("chon=0"))
                {
                    ds_in.Tables[0].Rows.Remove(r);
                }
            }
            catch (Exception exx){ }
            if (chkXML.Checked)
            {
                if (!System.IO.Directory.Exists("..//dataxml")) System.IO.Directory.CreateDirectory("..//dataxml");
                ds_in.WriteXml("..//dataxml//giaythuphanungthuoc.xml", XmlWriteMode.WriteSchema);
            }
            if (ds_in.Tables[0].Rows.Count > 0)
            {
                dllReportM.frmReport f = new dllReportM.frmReport(m, ds, "rptGiaythuphanungthuoc.rpt", diachi.Text,hoten.Text,gioitinh.Text,txtchandoan.Text,tuoi.Text,mabn.Text);
                f.ShowDialog();
            }
        }

        private void txtbschidinh_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == txtbschidinh)
            {
                Filterbschidinh(txtbschidinh.Text);
                listbschidinh.BrowseToICD10(txtbschidinh, txtmabschidinh, txtnguoithu, txtmabschidinh.Location.X, txtmabschidinh.Location.Y + 21, txtbschidinh.Width + txtmabschidinh.Width, txtbschidinh.Width);
            }
        }
        private void Filterbschidinh(string ten)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[listbschidinh.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "hoten like '%" + ten.Trim() + "%'";
            }
            catch { }
        }

        private void txtnguoithu_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == txtnguoithu)
            {
                Filternguoithu(txtnguoithu.Text);
                listnguoithu.BrowseToICD10(txtnguoithu, txtmanguoithu, txtnguoithu, txtmanguoithu.Location.X, txtmanguoithu.Location.Y + 21, txtnguoithu.Width + txtmanguoithu.Width, txtnguoithu.Width);
            }
        }

        private void Filternguoithu(string ten)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[listnguoithu.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "hoten like '%" + ten.Trim() + "%'";
            }
            catch { }
        }

        private void txtbsdoc_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == txtbsdoc)
            {
                Filterbsdoc(txtbsdoc.Text);
                listbsdoc.BrowseToICD10(txtbsdoc, txtmabsdockq, txtbsdoc, txtmabsdockq.Location.X, txtmabsdockq.Location.Y + 21, txtbsdoc.Width + txtmabsdockq.Width, txtbsdoc.Width);
            }
        }
        private void Filterbsdoc(string ten)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[listbsdoc.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "hoten like '%" + ten.Trim() + "%'";
            }
            catch { }
        }

        private void txtbschidinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listbschidinh.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listbschidinh.Visible) listbschidinh.Focus();
                else SendKeys.Send("{Tab}");
            }
            //DataRow dr = m.getrowbyid(dsthuoc.Tables[0], "ma='" + ma.Text + "'");
        }

        private void txtnguoithu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listnguoithu.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listnguoithu.Visible) listnguoithu.Focus();
                else SendKeys.Send("{Tab}");
            }
        }

        private void txtbsdoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listbsdoc.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listbsdoc.Visible) listbsdoc.Focus();
                else SendKeys.Send("{Tab}");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ref_text();
        }
        private void emp_detail()
        {
            txttenthuoc.Text = "";
            txtppthu.Text = "";
            ngaythu.Text = m.ngayhienhanh_server;
            txtngaydockq.Text = m.ngayhienhanh_server;
        }
        private void emp_head()
        {
            emp_detail();
            mabn.Text = "";
            hoten.Text = "";
            tuoi.Text = "";
            gioitinh.Text = "";
            diachi.Text = "";
            txtchandoan.Text = "";
            txtmabschidinh.Text = "";
            txtbschidinh.Text = "";
            txtmanguoithu.Text = "";
            txtnguoithu.Text = "";
            txtmabsdockq.Text = "";
            txtbsdoc.Text = "";
            //dataGridView1.DataSource = null;
        }
	}
}
