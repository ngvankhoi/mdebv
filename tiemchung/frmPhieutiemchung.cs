using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibDuoc;

namespace tiemchung
{
	public class frmPhieutiemchung : System.Windows.Forms.Form
    {
        #region Khai bao
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox tuoi;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGrid dataGrid1;
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
		private string sql,user,ngaysrv,s_makp="";
		private int i_row,i_userid,i_loaiba=0;
		private DataSet ds=new DataSet();
        private DataSet dsthuoc = new DataSet();
        
		private System.ComponentModel.Container components = null;
        private TextBox gioitinh;
        private Label label7;
        private Label label6;
        private Label label8;
        private TextBox txttenthuoc;
        private Label label9;
        private TextBox txtmuitiem;
        private ComboBox cbomabenh;
        private Label label11;
        private Label label13;
        private System.Windows.Forms.MaskedTextBox txtngaytiem;
        private LibList.List listthuoc;
        private Button butthem;
        private bool bbadt = false, bNew = false, bDangky_homqua=false;
        private Button butin;
        private CheckBox chkXML;
        private System.Windows.Forms.MaskedTextBox txtngaytiemhen;
        private Label label5;
        private ComboBox cbocosotiem;
        private Label label10;
        private TextBox txtsophieu;
        private AsYetUnnamed.MultiColumnListBox listDscho;
        private decimal d_id = 0,idduoc=0;

        DataTable dtlist = new DataTable();
        DataTable dtbs = new DataTable();
        DataTable dtvaccin = new DataTable();
        int mabd = 0,i_chinhanh=0,i_ngaylv_ngayht=0;

        private Label label12;
        private Label label14;
        private DataGrid dataGrid2;
        private Label label15;
        private System.Windows.Forms.MaskedTextBox ngaychidinh;
        private Button butPhanung;
        private Label label16;
        private Label label17;
        private TextBox txtVitri;
        private TextBox txtDuongtiem;
        private Label label18;
        private TextBox txtTenbs;
        private TextBox txtMabs;
        private LibList.List listBS;
        private Button button1;
        private Button button2;
        DataRow drbn;

        #endregion

        public frmPhieutiemchung()
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            if (m.bBogo) tv.GanBogo(this, textBox111);
        }

        public frmPhieutiemchung(LibMedi.AccessData acc, string s_mabn, string s_hoten, string s_tuoi, string s_diachi, bool _badt, int _i_userid, int _i_loaiba,int _chinhanh,string _makp)
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
            i_chinhanh = _chinhanh;
            s_makp = _makp;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhieutiemchung));
            this.hoten = new System.Windows.Forms.TextBox();
            this.tuoi = new System.Windows.Forms.TextBox();
            this.mabn = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label4 = new System.Windows.Forms.Label();
            this.diachi = new System.Windows.Forms.TextBox();
            this.list = new LibList.List();
            this.ma = new System.Windows.Forms.TextBox();
            this.gioitinh = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txttenthuoc = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtmuitiem = new System.Windows.Forms.TextBox();
            this.cbomabenh = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtngaytiem = new System.Windows.Forms.MaskedTextBox();
            this.listthuoc = new LibList.List();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.txtngaytiemhen = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbocosotiem = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtsophieu = new System.Windows.Forms.TextBox();
            this.listDscho = new AsYetUnnamed.MultiColumnListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.ngaychidinh = new System.Windows.Forms.MaskedTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtVitri = new System.Windows.Forms.TextBox();
            this.txtDuongtiem = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtTenbs = new System.Windows.Forms.TextBox();
            this.txtMabs = new System.Windows.Forms.TextBox();
            this.listBS = new LibList.List();
            this.butPhanung = new System.Windows.Forms.Button();
            this.butin = new System.Windows.Forms.Button();
            this.butthem = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
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
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(53, 4);
            this.mabn.MaxLength = 10;
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(69, 21);
            this.mabn.TabIndex = 0;
            this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
            this.mabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
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
            this.dataGrid1.Location = new System.Drawing.Point(6, 31);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(811, 297);
            this.dataGrid1.TabIndex = 14;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
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
            this.list.Location = new System.Drawing.Point(739, 496);
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
            this.ma.Location = new System.Drawing.Point(240, 176);
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(40, 21);
            this.ma.TabIndex = 22;
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
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(159, 449);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Phòng bệnh :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.Location = new System.Drawing.Point(164, 468);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 23);
            this.label8.TabIndex = 33;
            this.label8.Text = "Tên vaccin:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txttenthuoc
            // 
            this.txttenthuoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txttenthuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txttenthuoc.Enabled = false;
            this.txttenthuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttenthuoc.Location = new System.Drawing.Point(231, 470);
            this.txttenthuoc.Name = "txttenthuoc";
            this.txttenthuoc.Size = new System.Drawing.Size(209, 21);
            this.txttenthuoc.TabIndex = 11;
            this.txttenthuoc.TextChanged += new System.EventHandler(this.txttenthuoc_TextChanged);
            this.txttenthuoc.Validated += new System.EventHandler(this.txttenthuoc_Validated);
            this.txttenthuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txttenthuoc_KeyDown);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(35, 449);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Mũi tiêm :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtmuitiem
            // 
            this.txtmuitiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtmuitiem.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtmuitiem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmuitiem.Location = new System.Drawing.Point(88, 446);
            this.txtmuitiem.Name = "txtmuitiem";
            this.txtmuitiem.Size = new System.Drawing.Size(68, 21);
            this.txtmuitiem.TabIndex = 7;
            this.txtmuitiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // cbomabenh
            // 
            this.cbomabenh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbomabenh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbomabenh.FormattingEnabled = true;
            this.cbomabenh.Location = new System.Drawing.Point(231, 445);
            this.cbomabenh.Name = "cbomabenh";
            this.cbomabenh.Size = new System.Drawing.Size(209, 21);
            this.cbomabenh.TabIndex = 8;
            this.cbomabenh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbomabenh_KeyDown);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(658, 474);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "Hẹn ngày tiêm :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(453, 473);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 13);
            this.label13.TabIndex = 47;
            this.label13.Text = "Ngày tiêm :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtngaytiem
            // 
            this.txtngaytiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtngaytiem.Location = new System.Drawing.Point(513, 471);
            this.txtngaytiem.Mask = "##/##/#### ##:##";
            this.txtngaytiem.Name = "txtngaytiem";
            this.txtngaytiem.Size = new System.Drawing.Size(115, 20);
            this.txtngaytiem.TabIndex = 12;
            this.txtngaytiem.ValidatingType = typeof(System.DateTime);
            this.txtngaytiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            this.txtngaytiem.Validated += new System.EventHandler(this.txtngaytiem_Validated);
            // 
            // listthuoc
            // 
            this.listthuoc.BackColor = System.Drawing.SystemColors.Info;
            this.listthuoc.ColumnCount = 0;
            this.listthuoc.Location = new System.Drawing.Point(708, 507);
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
            // chkXML
            // 
            this.chkXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkXML.AutoSize = true;
            this.chkXML.Location = new System.Drawing.Point(22, 518);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(85, 17);
            this.chkXML.TabIndex = 50;
            this.chkXML.Text = "Xuất ra XML";
            this.chkXML.UseVisualStyleBackColor = true;
            // 
            // txtngaytiemhen
            // 
            this.txtngaytiemhen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtngaytiemhen.Location = new System.Drawing.Point(745, 470);
            this.txtngaytiemhen.Mask = "00/00/0000";
            this.txtngaytiemhen.Name = "txtngaytiemhen";
            this.txtngaytiemhen.Size = new System.Drawing.Size(70, 20);
            this.txtngaytiemhen.TabIndex = 13;
            this.txtngaytiemhen.ValidatingType = typeof(System.DateTime);
            this.txtngaytiemhen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            this.txtngaytiemhen.Validated += new System.EventHandler(this.txtngaytiemhen_Validated);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Location = new System.Drawing.Point(41, 543);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 23);
            this.label5.TabIndex = 52;
            this.label5.Text = "Cơ sở tiêm :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Visible = false;
            // 
            // cbocosotiem
            // 
            this.cbocosotiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbocosotiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbocosotiem.FormattingEnabled = true;
            this.cbocosotiem.Location = new System.Drawing.Point(109, 544);
            this.cbocosotiem.Name = "cbocosotiem";
            this.cbocosotiem.Size = new System.Drawing.Size(171, 21);
            this.cbocosotiem.TabIndex = 11;
            this.cbocosotiem.Visible = false;
            this.cbocosotiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(362, 543);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 54;
            this.label10.Text = "Số phiếu :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.Visible = false;
            // 
            // txtsophieu
            // 
            this.txtsophieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtsophieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtsophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsophieu.Location = new System.Drawing.Point(419, 540);
            this.txtsophieu.Name = "txtsophieu";
            this.txtsophieu.ReadOnly = true;
            this.txtsophieu.Size = new System.Drawing.Size(68, 21);
            this.txtsophieu.TabIndex = 5;
            this.txtsophieu.Visible = false;
            this.txtsophieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsophieu_KeyDown);
            // 
            // listDscho
            // 
            this.listDscho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listDscho.BackColor = System.Drawing.SystemColors.Info;
            this.listDscho.ColumnCount = 0;
            this.listDscho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listDscho.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.listDscho.FormattingEnabled = true;
            this.listDscho.Location = new System.Drawing.Point(6, 70);
            this.listDscho.MatchBufferTimeOut = 1000;
            this.listDscho.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listDscho.Name = "listDscho";
            this.listDscho.Size = new System.Drawing.Size(228, 251);
            this.listDscho.TabIndex = 55;
            this.listDscho.TextIndex = -1;
            this.listDscho.TextMember = null;
            this.listDscho.ValueIndex = -1;
            this.listDscho.DoubleClick += new System.EventHandler(this.listDscho_DoubleClick);
            this.listDscho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listDscho_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(5, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 13);
            this.label12.TabIndex = 56;
            this.label12.Text = "Vaccin đã tiêm";
            // 
            // dataGrid2
            // 
            this.dataGrid2.AllowNavigation = false;
            this.dataGrid2.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid2.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.DataMember = "";
            this.dataGrid2.FlatMode = true;
            this.dataGrid2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid2.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid2.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid2.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid2.Location = new System.Drawing.Point(8, 333);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid2.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.ReadOnly = true;
            this.dataGrid2.RowHeaderWidth = 10;
            this.dataGrid2.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid2.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.Size = new System.Drawing.Size(811, 103);
            this.dataGrid2.TabIndex = 57;
            this.dataGrid2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGrid2_MouseClick);
            this.dataGrid2.CurrentCellChanged += new System.EventHandler(this.dataGrid2_CurrentCellChanged);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(5, 333);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(105, 13);
            this.label14.TabIndex = 58;
            this.label14.Text = "Vaccin chưa tiêm";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.Location = new System.Drawing.Point(1, 468);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(86, 23);
            this.label15.TabIndex = 60;
            this.label15.Text = "Ngày chỉ định :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngaychidinh
            // 
            this.ngaychidinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ngaychidinh.Location = new System.Drawing.Point(88, 470);
            this.ngaychidinh.Mask = "00/00/0000";
            this.ngaychidinh.Name = "ngaychidinh";
            this.ngaychidinh.Size = new System.Drawing.Size(68, 20);
            this.ngaychidinh.TabIndex = 59;
            this.ngaychidinh.ValidatingType = typeof(System.DateTime);
            this.ngaychidinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            this.ngaychidinh.Validated += new System.EventHandler(this.ngaychidinh_Validated);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(446, 449);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 13);
            this.label16.TabIndex = 62;
            this.label16.Text = "Đường tiêm :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(634, 449);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(57, 13);
            this.label17.TabIndex = 63;
            this.label17.Text = "Vị trí tiêm :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVitri
            // 
            this.txtVitri.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVitri.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtVitri.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVitri.Location = new System.Drawing.Point(691, 445);
            this.txtVitri.Name = "txtVitri";
            this.txtVitri.Size = new System.Drawing.Size(123, 21);
            this.txtVitri.TabIndex = 10;
            this.txtVitri.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // txtDuongtiem
            // 
            this.txtDuongtiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDuongtiem.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtDuongtiem.Enabled = false;
            this.txtDuongtiem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDuongtiem.Location = new System.Drawing.Point(513, 446);
            this.txtDuongtiem.Name = "txtDuongtiem";
            this.txtDuongtiem.Size = new System.Drawing.Size(115, 21);
            this.txtDuongtiem.TabIndex = 9;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(501, 333);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(63, 13);
            this.label18.TabIndex = 67;
            this.label18.Text = "Người tiêm :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTenbs
            // 
            this.txtTenbs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtTenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenbs.Location = new System.Drawing.Point(614, 330);
            this.txtTenbs.Name = "txtTenbs";
            this.txtTenbs.Size = new System.Drawing.Size(205, 21);
            this.txtTenbs.TabIndex = 6;
            this.txtTenbs.TextChanged += new System.EventHandler(this.txtTenbs_TextChanged);
            this.txtTenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenbs_KeyDown);
            // 
            // txtMabs
            // 
            this.txtMabs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtMabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMabs.Location = new System.Drawing.Point(561, 330);
            this.txtMabs.Name = "txtMabs";
            this.txtMabs.Size = new System.Drawing.Size(51, 21);
            this.txtMabs.TabIndex = 5;
            this.txtMabs.Validated += new System.EventHandler(this.txtMabs_Validated);
            this.txtMabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // listBS
            // 
            this.listBS.BackColor = System.Drawing.SystemColors.Info;
            this.listBS.ColumnCount = 0;
            this.listBS.Location = new System.Drawing.Point(412, 332);
            this.listBS.MatchBufferTimeOut = 1000;
            this.listBS.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listBS.Name = "listBS";
            this.listBS.Size = new System.Drawing.Size(75, 17);
            this.listBS.TabIndex = 68;
            this.listBS.TextIndex = -1;
            this.listBS.TextMember = null;
            this.listBS.ValueIndex = -1;
            this.listBS.Visible = false;
            // 
            // butPhanung
            // 
            this.butPhanung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butPhanung.Image = ((System.Drawing.Image)(resources.GetObject("butPhanung.Image")));
            this.butPhanung.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butPhanung.Location = new System.Drawing.Point(141, 513);
            this.butPhanung.Name = "butPhanung";
            this.butPhanung.Size = new System.Drawing.Size(179, 25);
            this.butPhanung.TabIndex = 61;
            this.butPhanung.Text = "    Phản ứng sau tiêm chủng";
            this.butPhanung.UseVisualStyleBackColor = true;
            this.butPhanung.Click += new System.EventHandler(this.butPhanung_Click);
            // 
            // butin
            // 
            this.butin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butin.Enabled = false;
            this.butin.Image = ((System.Drawing.Image)(resources.GetObject("butin.Image")));
            this.butin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butin.Location = new System.Drawing.Point(605, 513);
            this.butin.Name = "butin";
            this.butin.Size = new System.Drawing.Size(70, 25);
            this.butin.TabIndex = 17;
            this.butin.Text = "&In";
            this.butin.Click += new System.EventHandler(this.butin_Click);
            // 
            // butthem
            // 
            this.butthem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butthem.Image = ((System.Drawing.Image)(resources.GetObject("butthem.Image")));
            this.butthem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butthem.Location = new System.Drawing.Point(286, 540);
            this.butthem.Name = "butthem";
            this.butthem.Size = new System.Drawing.Size(70, 25);
            this.butthem.TabIndex = 12;
            this.butthem.Text = "     &Thêm";
            this.butthem.Visible = false;
            this.butthem.Click += new System.EventHandler(this.butthem_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(747, 513);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 19;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(676, 513);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 18;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(534, 513);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 14;
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
            this.butLuu.Location = new System.Drawing.Point(463, 513);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 14;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(392, 513);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 16;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(321, 513);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 15;
            this.butMoi.Text = "     &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(4, 540);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(11, 11);
            this.button1.TabIndex = 69;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(16, 540);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(11, 11);
            this.button2.TabIndex = 70;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // frmPhieutiemchung
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(827, 552);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBS);
            this.Controls.Add(this.txtMabs);
            this.Controls.Add(this.txtTenbs);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtDuongtiem);
            this.Controls.Add(this.txtVitri);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.butPhanung);
            this.Controls.Add(this.txtngaytiem);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.ngaychidinh);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.listDscho);
            this.Controls.Add(this.butin);
            this.Controls.Add(this.butthem);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.txtsophieu);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbocosotiem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtngaytiemhen);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.listthuoc);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbomabenh);
            this.Controls.Add(this.txtmuitiem);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txttenthuoc);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.gioitinh);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.list);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.tuoi);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.ma);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPhieutiemchung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu tiêm chủng";
            this.Load += new System.EventHandler(this.frmPhieutiemchung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmPhieutiemchung_Load(object sender, System.EventArgs e)
		{
            ngaysrv = m.ngayhienhanh_server;
            i_ngaylv_ngayht = m.Ngaylv_Ngayht;
            ngaychidinh.Text = ngaysrv.Substring(0, 10);
            if (bbadt)
            {
                this.Location = new System.Drawing.Point(188 - 38, 120);//151
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Size = new Size(829 + 40, 610);
            }
            user = m.user;
			listthuoc.DisplayMember="ID";
            listthuoc.ValueMember = "TEN";
            dsthuoc=d.get_data("select id,ten from " + user + ".d_dmbd where vacxin=1 order by ten");
            listthuoc.DataSource = dsthuoc.Tables[0];

            cbomabenh.DisplayMember = "TEN";
            cbomabenh.ValueMember = "ID";
            cbomabenh.DataSource = m.get_data("select id,ten from "+user+".dmbenhtc").Tables[0];

            cbocosotiem.DisplayMember = "TEN";
            cbocosotiem.ValueMember = "ID";
            //cbocosotiem.DataSource = m.get_data("select a.id,a.ten from " + user + ".dmchinhanh a,"+user+".dlogin b where a.id=b.chinhanh and b.id="+i_userid+"").Tables[0];
            cbocosotiem.DataSource = m.get_data("select id,ten from " + user + ".dmchinhanh").Tables[0];

            sql = "select ma,hoten from "+user+".dmbs where chinhanh="+i_chinhanh;
            dtbs = m.get_data(sql).Tables[0];
            listBS.DataSource = dtbs;
            listBS.ValueMember = "hoten";
            listBS.DisplayMember = "ma";

            listDscho.DisplayMember = "HOTEN";
            listDscho.ValueMember = "mabn";
            listDscho.ColumnWidths[0] = 40;
            listDscho.ColumnWidths[1] = 70;
            listDscho.ColumnWidths[2] = list.Width - 190;
            listDscho.ColumnWidths[3] = 0;
            listDscho.ColumnWidths[4] = 0;
            listDscho.ColumnWidths[5] = 0;
            listDscho.ColumnWidths[6] = 90;
            listDscho.ColumnWidths[7] = 0;
            listDscho.SetSensive2(5, '3', Color.DarkRed);
            listDscho.SetSensive1(4, '?', Color.Blue);
            listDscho.SetSensive(5, '1', Color.Red);
            //list.SetSensive(5);
            load_ref();
            if (listDscho.Items.Count == 0) listDscho.Visible = false;
            else listDscho.Focus();
            sql = "select '' ten,0 mabd,'' duongdung,0 id from dual";
            dtvaccin = m.get_data(sql).Tables[0];
            dataGrid2.DataSource = dtvaccin;
			load_grid();
			AddGridTableStyle();
            AddGridTableStyle2();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
            txtngaytiem.Text = ngaysrv;
            txtngaytiemhen.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
			ref_text();
            ena_object(false);
		}

        private void load_ref()
        {
            string usermmyy = m.user + m.mmyy(ngaysrv.Substring(0, 10));
            sql = "select a.sovaovien,a.mabn,b.hoten||'('||b.namsinh||')' as hoten, case when a.noitiepdon=16 then 'x' else 'y' end as noitiepdon, a.done,case when a.done='?' then '2' else case when a.done='d' then '3' else case when a.noitiepdon=16 then '1' else '4' end end end as tt, case when a.done='?' then 'Đi tiêm chủng' else case when a.done='d' then 'Có kết quả' else case when a.noitiepdon=16 then 'Tái khám' else 'Chờ khám' end end end as tk, a.makp,to_char(a.ngay,'yymmddhh24:mi') as yymmdd,a.oid as stt,a.mavaovien,e.idduoc,e.id idchidinh ";
            sql += " from " + usermmyy + ".tiepdon a," + m.user + ".btdbn b, " + m.user + ".btdkp_bv c ," + usermmyy + ".v_chidinh e, " + m.user + ".v_giavp f ";
            sql += " where a.mabn=b.mabn and a.makp=c.makp and c.tiemchung=1 and a.mavaovien =e.mavaovien and e.mavp=f.id ";
            sql += " and f.trongoi=1 and e.idduoc in(select id from " + usermmyy + ".d_xuatsdct where done=0)";
            sql += " and to_char(a.ngay,'dd/mm/yyyy')='"+ngaysrv.Substring(0,10)+"' order by tt,makp,yymmdd,mabn";
            dtlist = m.get_data(sql).Tables[0];
            listDscho.DataSource = dtlist;
        }

		private void load_grid()
		{
            dataGrid2.DataSource = null;
            sql = "select distinct a.sophieu,c.ten as tenbenh,b.ten,a.muitiem,to_char(a.ngaytiem,'dd/mm/yyyy hh24:mi') as ngaytiem,";
            sql += "to_char(a.ngaytiem_hen,'dd/mm/yyyy') as ngaytiem_hen,d.ten as tencoso,a.id_benhtc,a.mabd,a.cosotiem,a.id,b.duongdung,a.vitritiem,a.mabs ";
            sql += "from " + user + ".phieutiemchung a inner join " + user + ".d_dmbd b on a.mabd=b.id inner join ";
            sql += "" + user + ".dmbenhtc c on a.id_benhtc=c.id inner join " + user + ".dmchinhanh d ";
            sql += "on a.cosotiem=d.id ";
            sql += " where a.mabn='" + mabn.Text + "'";
			ds=d.get_data(sql);
			dataGrid1.DataSource=ds.Tables[0];
            try
            {
                if (drbn != null)
                {
                    sql = "select b.ten,b.id mabd,b.duongdung,d.id,d.idduoc from " + user + m.mmyy(ngaysrv) + ".d_xuatsdct a," + user + m.mmyy(ngaysrv) + ".d_xuatsdll c, " + user + ".d_dmbd b," + user + m.mmyy(ngaychidinh.Text.Trim()) + ".v_chidinh d where d.idduoc=a.id and a.id=" + drbn["idduoc"].ToString() + " and a.done=0 and a.id=c.id and to_char(c.ngay,'dd/mm/yyyy')='" + ngaychidinh.Text.Trim() + "' and a.mabd=b.id";
                }
                else
                {
                    sql = "select b.ten,b.id mabd,b.duongdung,d.id,d.idduoc from " + user + m.mmyy(ngaychidinh.Text.Trim()) + ".d_xuatsdct a," + user + m.mmyy(ngaychidinh.Text.Trim()) + ".d_xuatsdll c, " + user + ".d_dmbd b," + user + m.mmyy(ngaychidinh.Text.Trim()) + ".v_chidinh d,"+user+".v_giavp e where  d.mavp=e.id and e.trongoi=1 and a.done=0 and d.mabn='"+mabn.Text.Trim()+"' and d.idduoc=a.id and a.id=c.id and to_char(c.ngay,'dd/mm/yyyy')='" + ngaychidinh.Text.Trim() + "' and a.mabd=b.id";
                }
                    dtvaccin = m.get_data(sql).Tables[0];
                dataGrid2.DataSource = dtvaccin;
            }
            catch(Exception exx) { }
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
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.ReadOnly=false;
			ts.RowHeaderWidth=10;
						
			DataGridTextBoxColumn TextCol=new DataGridTextBoxColumn();//0
			TextCol.MappingName = "sophieu";
			TextCol.HeaderText = lan.Change_language_MessageText("Số phiếu");
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();//1
			TextCol.MappingName = "tenbenh";
			TextCol.HeaderText = lan.Change_language_MessageText("Phòng bệnh");
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//2
            TextCol.MappingName = "ten";
            TextCol.HeaderText = lan.Change_language_MessageText("Tên Vaccin");
            TextCol.Width = 150;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();//3
			TextCol.MappingName = "muitiem";
			TextCol.HeaderText = lan.Change_language_MessageText("Mũi tiêm");
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();//4
			TextCol.MappingName = "ngaytiem";
			TextCol.HeaderText = lan.Change_language_MessageText("Ngày tiêm");
			TextCol.Width = 70;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//5
            TextCol.MappingName = "ngaytiem_hen";
            TextCol.HeaderText = lan.Change_language_MessageText("Hẹn ngày tiêm lần sau");
            TextCol.Width = 150;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//6
            TextCol.MappingName = "tencoso";
            TextCol.HeaderText = lan.Change_language_MessageText("Cơ sở tiêm Vx");
            TextCol.Width = 150;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//7
            TextCol.MappingName = "id_benhtc";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//8
            TextCol.MappingName = "mabd";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//9
            TextCol.MappingName = "cosotiem";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//10
            TextCol.MappingName = "id";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//11
            TextCol.MappingName = "duongdung";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//12
            TextCol.MappingName = "vitritiem";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//13
            TextCol.MappingName = "mabs";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

        private void AddGridTableStyle2()
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dtvaccin.TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            ts.SelectionBackColor = Color.Teal;
            ts.SelectionForeColor = Color.PaleGreen;
            ts.ReadOnly = true ;
            ts.RowHeaderWidth = 10;

            DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ten";
            TextCol.HeaderText = lan.Change_language_MessageText("Tên Vaccin");
            TextCol.Width = 450;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "mabd";
            TextCol.HeaderText = "mabd";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "duongdung";
            TextCol.HeaderText = "duongdung";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "id";
            TextCol.HeaderText = "id";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "idduoc";
            TextCol.HeaderText = "id";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);
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
				i_row=dataGrid1.CurrentCell.RowNumber;
				mabd=int.Parse(dataGrid1[i_row,8].ToString());
                txtsophieu.Text = dataGrid1[i_row, 0].ToString();
                cbomabenh.SelectedValue=dataGrid1[i_row,7].ToString();
                txttenthuoc.Text = dataGrid1[i_row, 2].ToString();
                txtmuitiem.Text = dataGrid1[i_row, 3].ToString();
                txtngaytiem.Text = dataGrid1[i_row, 4].ToString();
                txtngaytiemhen.Text = dataGrid1[i_row, 5].ToString();
                cbocosotiem.SelectedValue = dataGrid1[i_row, 9].ToString();
                d_id = long.Parse(dataGrid1[i_row, 10].ToString());
                txtDuongtiem.Text = dataGrid1[i_row, 11].ToString();
                txtVitri.Text = dataGrid1[i_row, 12].ToString();
                txtMabs.Text = dataGrid1[i_row, 13].ToString();

                bNew = false;
                txtMabs_Validated(null, null);
			}
			catch{}
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
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember];  
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			txtsophieu.Enabled=cbomabenh.Enabled=txtmuitiem.Enabled=txtngaytiem.Enabled=txtngaytiemhen.Enabled=cbocosotiem.Enabled=txtVitri.Enabled= ena;
			butMoi.Enabled=!ena;
            butin.Enabled = !ena;
			butSua.Enabled=!ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			butLuu.Enabled=ena;
            butthem.Enabled = ena;
			butBoqua.Enabled=ena;
            tuoi.Enabled = gioitinh.Enabled = diachi.Enabled = ena;
            txtsophieu.Enabled = ena;
            //txttenthuoc.Enabled = ena;
            cbomabenh.Enabled=ena;
            cbocosotiem.Enabled=ena;
            txtmuitiem.Enabled = ena;
			if (!ena) butMoi.Focus();
		}

        private void emp_text()
        {
            txtsophieu.Text = "";
            txtmuitiem.Text = "1";
            txttenthuoc.Text = "";
            hoten.Text = "";
            tuoi.Text = "";
            gioitinh.Text = "";
            diachi.Text = "";
            cbomabenh.SelectedIndex = 0;
        }

		private void butMoi_Click(object sender, System.EventArgs e)
		{
            bNew = true;
			//ena_object(true);
            
            mabn.Text = "";
            emp_text();
            mabn_Validated(null, null);
            ds.Clear();
            load_ref();
            listDscho.Visible = true;
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
			ena_object(true);
		}

		private bool kiemtra()
		{
            if (txtngaytiem.Text.Trim() == "/  /")
            {
                MessageBox.Show(lan.Change_language_MessageText("Chưa nhập ngày tiêm, đề nghị nhập ngày tiêm!"));
                txtngaytiem.Focus();
                return false;
            }
            if (txtMabs.Text.Trim() == "" || txtTenbs.Text.Trim() == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập người tiêm !"), LibMedi.AccessData.Msg);
                txtMabs.Focus();
                return false;
            }
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
            if (d_id != 0)
            {
                if (!m.upd_phieutiemchung(d_id, 0, mabn.Text, "", int.Parse(cbomabenh.SelectedValue.ToString()),mabd, txtmuitiem.Text
                    , txtngaytiem.Text.Trim(),txtngaytiemhen.Text.Trim(), i_chinhanh, i_userid,txtVitri.Text.Trim(),txtMabs.Text.Trim(),s_makp))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin !"), LibMedi.AccessData.Msg);
                    return;
                }
                if (bNew)
                {

                    m.execute_data("update " + user + m.mmyy(ngaychidinh.Text) + ".d_xuatsdct set done=1 where id=" + idduoc + " and mabd=" + mabd);
                }
            }
			ena_object(false);
            load_grid();
            dataGrid2_MouseClick(null, null);
		}

        public void updrec_giaythuphanungthuoc(DataTable dt, string ma, string ten)//, int mucdo, string tenmucdo)
        {
            string exp = "id=" + d_id + "";
            DataRow r = m.getrowbyid(dt, exp);
            if (r == null)
            {
                DataRow nrow = dt.NewRow();
                nrow["sophieu"] = txtsophieu.Text;
                nrow["tenbenh"] = cbomabenh.Text;
                nrow["ten"] = ten;
                nrow["muitiem"] = txtmuitiem.Text;
                nrow["ngaytiem"] = txtngaytiem.Text;
                nrow["ngaytiem_hen"] = txtngaytiemhen.Text;
                nrow["tencoso"] = cbocosotiem.Text;
                nrow["id_benhtc"] = cbomabenh.SelectedValue.ToString();
                nrow["cosotiem"] = cbocosotiem.SelectedValue.ToString();
                nrow["mabd"] = ma;
                ds.Tables[0].Rows.Add(nrow);
            }
            else
            {
                //ds.Clear();
                DataRow[] dr = dt.Select(exp);
                dr[0]["sophieu"] = txtsophieu.Text;
                dr[0]["tenbenh"] = cbomabenh.Text;
                dr[0]["ten"] = ten;
                dr[0]["muitiem"] = txtmuitiem.Text;
                dr[0]["ngaytiem"] = txtngaytiem.Text;
                dr[0]["ngaytiem_hen"] = txtngaytiemhen.Text;
                dr[0]["tencoso"] = cbocosotiem.Text;
                dr[0]["id_benhtc"] = cbomabenh.SelectedValue.ToString();
                dr[0]["cosotiem"] = cbocosotiem.SelectedValue.ToString();
                dr[0]["mabd"] = ma;
                //DataRow nrow = dt.NewRow();
                //nrow["sophieu"] = txtsophieu.Text;
                //nrow["tenbenh"] = cbomabenh.Text;
                //nrow["ten"] = ten;
                //nrow["muitiem"] = txtmuitiem.Text;
                //nrow["ngaytiem"] = txtngaytiem.Text;
                //nrow["ngaytiem_hen"] = txtngaytiemhen.Text;
                //nrow["tencoso"] = cbocosotiem.Text;
                //nrow["id_benhtc"] = cbomabenh.SelectedValue.ToString();
                //nrow["cosotiem"] = cbocosotiem.SelectedValue.ToString();
                //nrow["mabd"] = ma;
                //ds.Tables[0].Rows.Add(nrow);
            }
        }

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
            load_grid();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
            DataTable dttam = new DataTable();
            string[] s_mmyy = m.get_s_mmyy(m.StringToDate(txtngaytiem.Text).AddDays(-i_ngaylv_ngayht), m.StringToDate(txtngaytiem.Text).AddDays(i_ngaylv_ngayht)).Split(',');
			if (ds.Tables[0].Rows.Count==0) return;
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin tiêm chủng này?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
                for (int i = 0; i < s_mmyy.Length; i++)
                {
                    try
                    {
                        sql = "select a.idduoc from " + user + s_mmyy[i] + ".v_chidinh a," + user + s_mmyy[i] + ".d_xuatsdct b where a.idduoc=b.id and a.id=" + d_id + " and b.mabd=" + mabd;
                        dttam = m.get_data(sql).Tables[0];
                        if (dttam.Rows.Count != 0)
                        {
                            d.execute_data("update " + user + s_mmyy[i] + ".d_xuatsdct set done=0 where id=" + dttam.Rows[0][0].ToString() + " and mabd=" + mabd);
                            break;
                        }
                    }
                    catch { }
                }
                
                d.execute_data("delete from " + user + ".phieutiemchung where id=" + d_id + " and mabd=" + mabd);
				ref_text();
			}
            load_grid();
            dataGrid2_MouseClick(null, null);
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
            updrec_giaythuphanungthuoc(ds.Tables[0], ma.Text, txttenthuoc.Text);
            //dataGrid1.DataSource = dsthuoc.Tables[0];
            txtsophieu.Focus();
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
                listthuoc.BrowseToDmbd(txttenthuoc, ma, txtmuitiem, txttenthuoc.Location.X, txttenthuoc.Location.Y+21, txttenthuoc.Width, ma.Width);
            }
        }

        private void txttenbsdockq_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtngaytiem.Focus();
        }

        private void mabn_Validated(object sender, EventArgs e)
        {
            if (mabn.Text == "") return;
            DataSet ds_hc = new DataSet();
            string sql="";
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
            }
            load_grid();
            txtsophieu.Focus();
            dataGrid2_MouseClick(null, null);
        }

        private void butin_Click(object sender, EventArgs e)
        {
            DataSet ds_in = new DataSet();
            string sql = "", s_dienthoai = "", title = "";
            //sql = "select distinct a.mabn sophieu,a.id_benhtc,c.ten as tenbenh,to_char(a.ngaytiem,'dd/mm/yyyy') as ngaytiem,b.ten as tenthuoc";
            //sql += ",a.muitiem,to_char(a.ngaytiem_hen,'dd/mm/yyyy') as ngaytiem_hen,a.mabd,a.cosotiem,d.ten as tencoso ";
            //sql += ",case when f.ngaysinh is null then f.namsinh else to_char(f.ngaysinh,'dd/mm/yyyy') end ngaysinh ";
            //sql += "from " + user + ".phieutiemchung a inner join " + user + ".d_dmbd b on a.mabd=b.id inner join ";
            //sql += ""+user+".dmbenhtc c on a.id_benhtc=c.id inner join "+user+".dmchinhanh d on a.cosotiem=d.id ";
            //sql += "inner join "+user+".btdbn f on a.mabn=f.mabn ";
            //sql += " where a.mabn='" + mabn.Text + "'";
            sql += "select distinct a.mabn sophieu,a.id_benhtc,c.ten as tenbenh,to_char(a.ngaytiem,'dd/mm/yyyy') as ngaytiem,b.ten as tenthuoc,a.muitiem, ";
            sql += " to_char(a.ngaytiem_hen,'dd/mm/yyyy') as ngaytiem_hen,a.mabd,a.cosotiem,d.ten as tencoso ,case when f.ngaysinh is null then f.namsinh  ";
            sql += " else to_char(f.ngaysinh,'dd/mm/yyyy') end ngaysinh  ";
            sql += " from " + user + ".dmbenhtc c left join " + user + ".phieutiemchung a on a.id_benhtc=c.id and a.mabn='" + mabn.Text + "' left join " + user + ".d_dmbd b on a.mabd=b.id left join " + user + ".dmchinhanh d on a.cosotiem=d.id  ";
            sql += " left join " + user + ".btdbn f on a.mabn=f.mabn ";
            ds_in = d.get_data(sql);
            try { s_dienthoai = m.get_data("select didong from " + user + ".dienthoai where mabn='" + mabn.Text + "'").Tables[0].Rows[0][0].ToString(); }
            catch { s_dienthoai = ""; }
            if (chkXML.Checked)
            {
                if (!System.IO.Directory.Exists("..\\..\\dataxml")) System.IO.Directory.CreateDirectory("..\\..\\dataxml");
                ds_in.WriteXml("..\\..\\dataxml\\Phieutiemchung.xml", XmlWriteMode.WriteSchema);
            }
            if (int.Parse(tuoi.Text) < m.iTuoi_khamnhi)
                title = lan.Change_language_MessageText("PHIẾU TIÊM CHỦNG TRẺ EM");
            else
                title = lan.Change_language_MessageText("PHIẾU TIÊM CHỦNG NGƯỜI LỚN");
            if (ds_in.Tables[0].Rows.Count > 0)
            {
                dllReportM.frmReport f = new dllReportM.frmReport(m, ds_in.Tables[0], "rptPhieutiemchung.rpt", diachi.Text, hoten.Text, gioitinh.Text, s_dienthoai, ds_in.Tables[0].Rows[0]["ngaysinh"].ToString(), ds_in.Tables[0].Rows[0]["sophieu"].ToString(), title, "", "", "");
                f.ShowDialog();
            }
        }

        private void mabn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        }

        private void cbomabenh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txttenthuoc.Focus();            
        }

        private void txtsophieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}{F4}");
        }

        private void txtngaytiemhen_Validated(object sender, EventArgs e)
        {
            if (!m.bNgay(txtngaytiemhen.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày hẹn tiêm không hợp lệ !"));
                txtngaytiemhen.Focus();
                return;
            }
            if (txtngaytiem.Text.Trim() != "/  /" && txtngaytiemhen.Text.Trim() != "/  /")
            {
                int i_kiemtra = DateTime.Compare(DateTime.Parse(txtngaytiem.Text), DateTime.Parse(txtngaytiemhen.Text));
                if (i_kiemtra == 1)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày hẹn tiêm không được nhỏ hơn ngày tiêm!"));
                    txtngaytiemhen.Focus();
                    return;
                }
            }
        }

        private void listDscho_DoubleClick(object sender, EventArgs e)
        {
            if (dtlist.Rows.Count != 0)
            {
                drbn = m.getrowbyid(dtlist, "mabn='" + listDscho.SelectedValue.ToString() + "'");
            }
            else
                drbn = null;
            load_head();
            bNew = true;
            ena_object(true);
        }

        private void load_head()
        {
            if (drbn == null)
            {
                emp_text();
                d_id = 0;
            }
            else
            {
                mabn.Text = drbn["mabn"].ToString();
                d_id = decimal.Parse(drbn["idchidinh"].ToString());
                mabn_Validated(null, null);
            }
            listDscho.Visible = false;
        }

        private void listDscho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                listDscho.Visible = false;
                mabn.Focus();
            }
        }

        private void dataGrid2_CurrentCellChanged(object sender, EventArgs e)
        { 
            try
            {
                i_row = dataGrid2.CurrentCell.RowNumber;
                txttenthuoc.Text = dataGrid2[i_row, 0].ToString();
                mabd = int.Parse(dataGrid2[i_row, 1].ToString());
                txtDuongtiem.Text = dataGrid2[i_row, 2].ToString();
                d_id = decimal.Parse(dataGrid2[i_row, 3].ToString());
                idduoc = decimal.Parse(dataGrid2[i_row, 4].ToString());
                ena_object(true);
                txtmuitiem.Focus();
                bNew = true;
            }
            catch (Exception exx) { mabd = 0; }
        }

        private void ngaychidinh_Validated(object sender, EventArgs e)
        {
            if (!m.bNgay(ngaychidinh.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày chỉ định không hợp lệ !"));
                ngaychidinh.Focus();
                return;
            }
            load_grid();
        }

        private void txtngaytiem_Validated(object sender, EventArgs e)
        {
            if (!m.bNgay(txtngaytiem.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày tiêm không hợp lệ !"));
                txtngaytiem.Focus();
                return;
            }
            if (m.StringToDate(txtngaytiem.Text.Trim()) > m.StringToDate(ngaysrv).AddDays(i_ngaylv_ngayht) || m.StringToDate(txtngaytiem.Text.Trim()) < m.StringToDate(ngaysrv).AddDays(-i_ngaylv_ngayht))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày tiêm không được vượt quá "+i_ngaylv_ngayht+" ngày so với ngày hệ thống !"));
                txtngaytiem.Focus();
                return;
            }
        }

        private void dataGrid2_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                i_row = dataGrid2.CurrentCell.RowNumber;
                txttenthuoc.Text = dataGrid2[i_row, 0].ToString();
                mabd = int.Parse(dataGrid2[i_row, 1].ToString());
                txtDuongtiem.Text = dataGrid2[i_row, 2].ToString();
                d_id = decimal.Parse(dataGrid2[i_row, 3].ToString());
                idduoc = decimal.Parse(dataGrid2[i_row, 4].ToString());
                ena_object(true);
                txtmuitiem.Focus();
                bNew = true;
            }
            catch (Exception exx) { mabd = 0; }
        }

        private void txtTenbs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listBS.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listBS.Visible) listBS.Focus();
                else SendKeys.Send("{Tab}{Home}");
            }		
        }

        private void txtTenbs_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == txtTenbs)
            {
                Filt_tenbs(txtTenbs.Text);

                listBS.BrowseToICD10(txtTenbs, txtMabs, ngaychidinh, txtMabs.Location.X, txtMabs.Location.Y + txtMabs.Height - 2, txtMabs.Width + txtTenbs.Width + 2, txtTenbs.Height);
                
            }		
        }

        private void Filt_tenbs(string ten)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[listBS.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "hoten like '%" + ten.Trim() + "%'";
            }
            catch { }
        }

        private void txtMabs_Validated(object sender, EventArgs e)
        {
           
			if (txtMabs.Text!="")
			{
                DataRow r = m.getrowbyid(dtbs, "ma='" + txtMabs.Text.Trim() + "'");
				if (r!=null) txtTenbs.Text=r["hoten"].ToString();
                else txtTenbs.Text = "";
			}
		
        }

        private void butPhanung_Click(object sender, EventArgs e)
        {
            if (d_id != 0)
            {

                frmPhanungsautiemchung f = new frmPhanungsautiemchung(m, mabn.Text.Trim(), hoten.Text.Trim(), tuoi.Text.Trim(), gioitinh.Text.Trim(), diachi.Text.Trim(), d_id, i_userid);
                f.ShowInTaskbar = false;
                f.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //frmSoquanlyVaccin f = new frmSoquanlyVaccin(m);
            //f.ShowDialog();
        }
	}
}
