using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using LibMedi;
using dichso;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmDuyet.
	/// </summary>
	public class frmDuyetbhyt : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.DataGrid dataGrid1;
		private Brush disabledBackBrush;
		private Brush disabledTextBrush;
		private Brush alertBackBrush;
		private Font alertFont,alertFont2;
		private Brush alertTextBrush;
		private Font currentRowFont,currentRowFont2;
		private Brush currentRowBackBrush,RowBackBrushVP;
        private bool afterCurrentCellChanged, bSkip = false, bCongkham_pl, bIncstt, bKhoaso, bQuyenso, bDuyettoa_ketthuc, bAdmin, bChuyenkham_congkham, bInchiphi_chandoan_bacsy, bDuyetcls, bChenhlech, bGia_bh_quydinh_giamua, bPhongkhamduyetrieng=true;
        private bool bThuchenhlechtruoc_duyettoasau = false, bLaygiamua_khi_giabh_0_giabh_nho_giamua = true, bBHYT_Traituyen_tinh_Tyle_khac = false, bTraituyen_bhtra = false, bBhyt_tra_1_congkham = false, bCapve_noitru = false;
        private int checkCol = 0, i_userid, i_row, i_mavp, iMavp_congkham, songayduyet, i_tunguyen, i_quyen_duyetmau38=0;
		private LibDuoc.AccessData d;
        private LibMedi.AccessData m = new LibMedi.AccessData();
		private int i_nhom,i_madoituong,i_loaiba,itable,_madoituong,iTraituyen, i_khudt=0;
		private decimal l_id,l_maql,l_mavaovien,lTraituyen;
        private string user, xxx, yyy, sql, s_kho, s_ngay, s_manguon, s_mmyy, s_mabn, s_makp, s_hoten, s_tu, s_den, stime, s_mabs, s_userid, s_mavp = "", s_chenhlech, fie_tunguyen, s_tunguyen, ngay_reset_phieu38="";
        private string s_idcomputer = "";
		private DataSet ds=new DataSet();
        private DataSet ds1 = new DataSet();
        private DataSet dsxmlin = new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dtct=new DataTable();
		private DataTable dtton=new DataTable();
		private DataTable dttonct=new DataTable();
		private DataTable dtmavp=new DataTable();
		public DataTable dtll=new DataTable();
        private DataTable dtkp = new DataTable();
        private DataTable dtbs = new DataTable();
        private DataTable dtdt = new DataTable();
        private DataTable dtvpin = new DataTable();
        private DataTable dtbd = new DataTable();
        private DataTable dtdtf = new DataTable();
        private DataTable dtnv = new DataTable();
        public bool bOk = false, bHoadon, bGiaban = false, bkhongChoDuyetToaBNHen_E8 = false;
		public int sobienlai,i_bhyt_inrieng;
		private numbertotext doiso=new numbertotext();
        private System.Windows.Forms.TextBox tim;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.TextBox tim2;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.CheckBox checkBox1;
        private CheckBox checkBox2;
        private FileStream fstr;
        private byte[] image,imageuser;
        private CheckBox chkXML;
        private CheckBox chkXem;
        private CheckBox chkChiphi;
        private Button butList;
        private CheckBox chkList;
        private CheckBox chkDonChiphi;
        private Label label1;
        private NumericUpDown soban;
        private Button butAll;
        private ToolTip toolTip1;
        private IContainer components;
        private decimal Bhyt_7cn;
        private bool bchenhlech_thuoc, bGia_bh_quydinh, bChenhlech_thuoc_dannhmuc,bduyetkhambenhchuyenvaongoaitru = false;
        private CheckBox chkNhapvien;
        private CheckBox chkKodichvu;
        private CheckBox chkcls;
        private CheckBox chkintrongngay;
        private bool bAutoLoad = true;
        private DataTable dtvp = new DataTable();
        private Label lblTongtien;
        private bool bChuahoantatkham = false;

		public frmDuyetbhyt(LibDuoc.AccessData acc,DataTable dt,int nhom,string kho,string nguon,string ngay,int userid,string mmyy,bool hoadon,int madoituong,int loaiba,bool admin,string tenuser, int _khudt)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            d = acc; i_loaiba = loaiba;
            dtll = dt; i_nhom = nhom; i_userid = userid; s_userid = tenuser;
            s_kho = kho; s_ngay = ngay; s_manguon = nguon; bAdmin = admin;
			s_mmyy=mmyy;bHoadon=hoadon;i_madoituong=madoituong;            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            i_khudt = _khudt;
            //
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

        public frmDuyetbhyt(LibDuoc.AccessData acc, DataTable dt, int nhom, string kho, string nguon, string ngay, int userid, string mmyy, bool hoadon, int madoituong, int loaiba, bool admin, string tenuser, bool autoload, int _khudt,bool chuahoantatkham)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            d = acc; i_loaiba = loaiba;
            dtll = dt; i_nhom = nhom; i_userid = userid; s_userid = tenuser;
            s_kho = kho; s_ngay = ngay; s_manguon = nguon; bAdmin = admin;
            s_mmyy = mmyy; bHoadon = hoadon; i_madoituong = madoituong;
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            bAutoLoad = autoload;
            i_khudt = _khudt;
            bChuahoantatkham = chuahoantatkham;

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if( disposing )
			{
				if(components != null)
				{
					if(disabledBackBrush != null)
					{
						disabledBackBrush.Dispose();
						disabledTextBrush.Dispose();
						alertBackBrush.Dispose();
						alertFont.Dispose();
						alertTextBrush.Dispose();
						currentRowFont.Dispose();
						currentRowBackBrush.Dispose();
						RowBackBrushVP.Dispose();
						alertFont2.Dispose();
						currentRowFont2.Dispose();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDuyetbhyt));
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.tim = new System.Windows.Forms.TextBox();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.tim2 = new System.Windows.Forms.TextBox();
            this.butIn = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.chkXem = new System.Windows.Forms.CheckBox();
            this.chkChiphi = new System.Windows.Forms.CheckBox();
            this.butList = new System.Windows.Forms.Button();
            this.chkList = new System.Windows.Forms.CheckBox();
            this.chkDonChiphi = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.soban = new System.Windows.Forms.NumericUpDown();
            this.butAll = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkcls = new System.Windows.Forms.CheckBox();
            this.chkNhapvien = new System.Windows.Forms.CheckBox();
            this.chkKodichvu = new System.Windows.Forms.CheckBox();
            this.chkintrongngay = new System.Windows.Forms.CheckBox();
            this.lblTongtien = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soban)).BeginInit();
            this.SuspendLayout();
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(375, 429);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(72, 25);
            this.butLuu.TabIndex = 7;
            this.butLuu.Text = "      &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(447, 429);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(72, 25);
            this.butBoqua.TabIndex = 8;
            this.butBoqua.Text = "&Kết thúc";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(9, -16);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 3;
            this.dataGrid1.Size = new System.Drawing.Size(415, 408);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dataGrid1_Navigate);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // tim
            // 
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.Location = new System.Drawing.Point(100, 400);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(301, 21);
            this.tim.TabIndex = 3;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tim_KeyDown);
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            // 
            // dataGrid2
            // 
            this.dataGrid2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid2.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.DataMember = "";
            this.dataGrid2.FlatMode = true;
            this.dataGrid2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(433, -16);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.RowHeaderWidth = 3;
            this.dataGrid2.Size = new System.Drawing.Size(352, 329);
            this.dataGrid2.TabIndex = 1;
            this.dataGrid2.CurrentCellChanged += new System.EventHandler(this.dataGrid2_CurrentCellChanged);
            this.dataGrid2.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dataGrid2_Navigate);
            this.dataGrid2.Click += new System.EventHandler(this.dataGrid2_Click);
            // 
            // tim2
            // 
            this.tim2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim2.Location = new System.Drawing.Point(432, 400);
            this.tim2.Name = "tim2";
            this.tim2.Size = new System.Drawing.Size(181, 21);
            this.tim2.TabIndex = 5;
            this.tim2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim2.TextChanged += new System.EventHandler(this.tim2_TextChanged);
            this.tim2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tim_KeyDown);
            // 
            // butIn
            // 
            this.butIn.Enabled = false;
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(303, 429);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(72, 25);
            this.butIn.TabIndex = 6;
            this.butIn.Text = "Lưu && &in";
            this.butIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.ForeColor = System.Drawing.Color.Red;
            this.checkBox1.Location = new System.Drawing.Point(8, 424);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(344, 19);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Danh sách có khám không sử dụng thuốc && dịch vụ";
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.ForeColor = System.Drawing.Color.Red;
            this.checkBox2.Location = new System.Drawing.Point(8, 440);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(187, 19);
            this.checkBox2.TabIndex = 9;
            this.checkBox2.Text = "Thu tiền khám không lấy thuốc";
            // 
            // chkXML
            // 
            this.chkXML.AutoSize = true;
            this.chkXML.Location = new System.Drawing.Point(720, 477);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(73, 17);
            this.chkXML.TabIndex = 237;
            this.chkXML.Text = "Xuất XML";
            this.chkXML.UseVisualStyleBackColor = true;
            // 
            // chkXem
            // 
            this.chkXem.AutoSize = true;
            this.chkXem.Location = new System.Drawing.Point(616, 477);
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(102, 17);
            this.chkXem.TabIndex = 238;
            this.chkXem.Text = "Xem trước khi in";
            this.chkXem.UseVisualStyleBackColor = true;
            // 
            // chkChiphi
            // 
            this.chkChiphi.AutoSize = true;
            this.chkChiphi.Location = new System.Drawing.Point(616, 460);
            this.chkChiphi.Name = "chkChiphi";
            this.chkChiphi.Size = new System.Drawing.Size(106, 17);
            this.chkChiphi.TabIndex = 239;
            this.chkChiphi.Text = "In chi phí điều trị";
            this.chkChiphi.UseVisualStyleBackColor = true;
            this.chkChiphi.CheckedChanged += new System.EventHandler(this.chkChiphi_CheckedChanged);
            // 
            // butList
            // 
            this.butList.Image = ((System.Drawing.Image)(resources.GetObject("butList.Image")));
            this.butList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butList.Location = new System.Drawing.Point(519, 429);
            this.butList.Name = "butList";
            this.butList.Size = new System.Drawing.Size(84, 25);
            this.butList.TabIndex = 9;
            this.butList.Text = "&Danh sách";
            this.butList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butList.Click += new System.EventHandler(this.butList_Click);
            // 
            // chkList
            // 
            this.chkList.Checked = true;
            this.chkList.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkList.ForeColor = System.Drawing.Color.Red;
            this.chkList.Location = new System.Drawing.Point(8, 457);
            this.chkList.Name = "chkList";
            this.chkList.Size = new System.Drawing.Size(225, 19);
            this.chkList.TabIndex = 241;
            this.chkList.Text = "Tự động hiện lại danh sách sau khi in";
            // 
            // chkDonChiphi
            // 
            this.chkDonChiphi.AutoSize = true;
            this.chkDonChiphi.Location = new System.Drawing.Point(616, 442);
            this.chkDonChiphi.Name = "chkDonChiphi";
            this.chkDonChiphi.Size = new System.Drawing.Size(167, 17);
            this.chkDonChiphi.TabIndex = 242;
            this.chkDonChiphi.Text = "In đơn thuốc + chi phí điều trị";
            this.chkDonChiphi.UseVisualStyleBackColor = true;
            this.chkDonChiphi.CheckedChanged += new System.EventHandler(this.chkDonChiphi_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 404);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 243;
            this.label1.Text = "Số bản in :";
            // 
            // soban
            // 
            this.soban.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soban.Location = new System.Drawing.Point(60, 400);
            this.soban.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.soban.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.soban.Name = "soban";
            this.soban.Size = new System.Drawing.Size(38, 21);
            this.soban.TabIndex = 244;
            this.soban.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // butAll
            // 
            this.butAll.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butAll.Location = new System.Drawing.Point(403, 399);
            this.butAll.Name = "butAll";
            this.butAll.Size = new System.Drawing.Size(24, 22);
            this.butAll.TabIndex = 4;
            this.butAll.Text = "...";
            this.toolTip1.SetToolTip(this.butAll, "Chọn tất cả");
            this.butAll.UseVisualStyleBackColor = true;
            this.butAll.Click += new System.EventHandler(this.butAll_Click);
            // 
            // chkcls
            // 
            this.chkcls.AutoSize = true;
            this.chkcls.BackColor = System.Drawing.Color.Transparent;
            this.chkcls.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.chkcls.Location = new System.Drawing.Point(8, 476);
            this.chkcls.Name = "chkcls";
            this.chkcls.Size = new System.Drawing.Size(187, 17);
            this.chkcls.TabIndex = 245;
            this.chkcls.Text = "Cận lâm sàng chưa thực hiện màu";
            this.chkcls.UseVisualStyleBackColor = false;
            this.chkcls.CheckedChanged += new System.EventHandler(this.chkcls_CheckedChanged);
            // 
            // chkNhapvien
            // 
            this.chkNhapvien.AutoSize = true;
            this.chkNhapvien.Checked = true;
            this.chkNhapvien.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNhapvien.Location = new System.Drawing.Point(616, 404);
            this.chkNhapvien.Name = "chkNhapvien";
            this.chkNhapvien.Size = new System.Drawing.Size(157, 17);
            this.chkNhapvien.TabIndex = 246;
            this.chkNhapvien.Text = "Không hiện xử trí nhập viện";
            this.chkNhapvien.UseVisualStyleBackColor = true;
            this.chkNhapvien.CheckedChanged += new System.EventHandler(this.chkNhapvien_CheckedChanged);
            // 
            // chkKodichvu
            // 
            this.chkKodichvu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkKodichvu.AutoSize = true;
            this.chkKodichvu.Location = new System.Drawing.Point(616, 423);
            this.chkKodichvu.Name = "chkKodichvu";
            this.chkKodichvu.Size = new System.Drawing.Size(183, 17);
            this.chkKodichvu.TabIndex = 247;
            this.chkKodichvu.Text = "Không in chi phí chênh lệch CLS";
            this.chkKodichvu.UseVisualStyleBackColor = true;
            this.chkKodichvu.CheckedChanged += new System.EventHandler(this.chkKodichvu_CheckedChanged);
            // 
            // chkintrongngay
            // 
            this.chkintrongngay.AutoSize = true;
            this.chkintrongngay.Location = new System.Drawing.Point(720, 458);
            this.chkintrongngay.Name = "chkintrongngay";
            this.chkintrongngay.Size = new System.Drawing.Size(106, 17);
            this.chkintrongngay.TabIndex = 248;
            this.chkintrongngay.Text = "In chi phí điều trị";
            this.chkintrongngay.UseVisualStyleBackColor = true;
            // 
            // lblTongtien
            // 
            this.lblTongtien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongtien.ForeColor = System.Drawing.Color.Blue;
            this.lblTongtien.Location = new System.Drawing.Point(429, 316);
            this.lblTongtien.Name = "lblTongtien";
            this.lblTongtien.Size = new System.Drawing.Size(356, 76);
            this.lblTongtien.TabIndex = 249;
            this.lblTongtien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmDuyetbhyt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.butBoqua;
            this.ClientSize = new System.Drawing.Size(794, 505);
            this.Controls.Add(this.lblTongtien);
            this.Controls.Add(this.chkintrongngay);
            this.Controls.Add(this.chkKodichvu);
            this.Controls.Add(this.chkNhapvien);
            this.Controls.Add(this.chkcls);
            this.Controls.Add(this.butAll);
            this.Controls.Add(this.soban);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkDonChiphi);
            this.Controls.Add(this.chkList);
            this.Controls.Add(this.butList);
            this.Controls.Add(this.chkChiphi);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.chkXem);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.tim2);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(0, 38);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDuyetbhyt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đơn thuốc bảo hiểm";
            this.Load += new System.EventHandler(this.frmDuyetbhyt_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDuyetbhyt_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soban)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmDuyetbhyt_Load(object sender, System.EventArgs e)
		{
            user = d.user; xxx = user + d.mmyy(s_ngay); yyy = user + s_mmyy;
            //
            s_idcomputer = m.get_dmcomputer(System.Environment.MachineName).ToString().PadLeft(4, '0');
            f_load_option();
            //
            dtbs = d.get_data("select * from "+user+".dmbs where nhom not in (" + LibMedi.AccessData.nhanvien + "," + LibMedi.AccessData.nghiviec + ") order by hoten").Tables[0];
            bchenhlech_thuoc = (m.bChenhlech) ? m.bChenhlech_thuoc : false;
            bChenhlech_thuoc_dannhmuc = (bchenhlech_thuoc) ? m.bChenhlech_thuoc_dannhmuc : false;
            bGia_bh_quydinh = m.bGia_bh_quydinh;
            bGia_bh_quydinh_giamua = m.bGia_bh_quydinh_giamua;
            i_tunguyen = m.iTunguyen; bDuyetcls = m.bDuyetcls;
            s_chenhlech = "";
            lTraituyen = (m.bTraituyen) ? m.lTraituyen_phongkham : 0;
            iTraituyen = (m.bTraituyen) ? m.iTraituyen_bhyt : 0;
            foreach (DataRow r in d.get_data("select * from " + user + ".doituong").Tables[0].Rows)
            {
                if (int.Parse(r["madoituong"].ToString()) == i_tunguyen)
                {
                    s_tunguyen = r["doituong"].ToString();
                    fie_tunguyen = r["field_gia"].ToString();
                }
                if (int.Parse(r["chenhlech"].ToString()) == 1) s_chenhlech += r["madoituong"].ToString().PadLeft(2, '0') + ",";
            }
            bChenhlech = m.bChenhlech;
            //Thuy 15.11.2012
            bCapve_noitru = m.bCapve_noitru;
            if (d.bChuakham_choduyet(i_nhom))
            {
                foreach (DataRow r in d.get_data("select distinct mavp from " + user + ".btdkp_bv where loai=1").Tables[0].Rows)
                    s_mavp += r["mavp"].ToString() + ",";
            }
            s_mavp = (s_mavp != "") ? s_mavp.Substring(0, s_mavp.Length - 1) : "";
            dtdtf = d.get_data("select * from " + user + ".d_doituong").Tables[0];
            bDuyettoa_ketthuc = d.bDuyettoa_ketthuc(i_nhom);
            bInchiphi_chandoan_bacsy = d.bInchiphi_chandoan_bacsy(i_nhom);
            DateTime dt = d.StringToDate(s_ngay.Substring(0, 10));
            string ddd = dt.DayOfWeek.ToString().Substring(0, 3);
            Bhyt_7cn = (ddd == "Sat" || ddd == "Sun") ? m.Bhyt_7cn : 0;
            bKhoaso=d.bKhoaso(i_nhom,s_mmyy);
            bQuyenso = d.bQuyenso(i_nhom);
            songayduyet = d.songayduyet(i_nhom);//chon ben duoc
            int ikhoangcachngaycaptoa = m.iKhoangcachngaycaptoa_voingaykham;//tuy chon nay chon ben medisoft
            songayduyet = (songayduyet > ikhoangcachngaycaptoa) ? songayduyet : ikhoangcachngaycaptoa;//lay max cua 2 khoang cach

            s_tu = m.DateToString("dd/MM/yyyy", m.StringToDate(s_ngay).AddDays(-1 * songayduyet));
            s_den = s_ngay;stime = "'dd/mm/yyyy'";
            bChuyenkham_congkham = d.bChuyenkham_congkham(i_nhom);
            soban.Value = decimal.Parse(d.iSobanin(i_nhom).ToString());
			i_bhyt_inrieng=d.iBhyt_inrieng(i_nhom);
            bIncstt = d.bIncstt(i_nhom);
            chkChiphi.Visible = bHoadon;
            chkDonChiphi.Visible = bHoadon;
            if (bHoadon) chkChiphi.Checked = true;
			checkBox1.Visible=bHoadon;
            checkBox2.Visible = i_loaiba != 2;
            chkXem.Checked=d.bPreview;
            _madoituong = i_madoituong;
            bCongkham_pl = d.bCongkham_pl(i_nhom);
			i_mavp=d.iMavp_congkham(i_nhom);
			dtmavp=d.get_data("select * from "+user+".v_giavp").Tables[0];
            if (i_madoituong == 1) bGiaban = d.get_data("select * from " + user + ".d_doituong where loai=1 and madoituong=" + i_madoituong).Tables[0].Rows.Count > 0;
			this.disabledBackBrush = new SolidBrush(Color.FromArgb(255,255,192));
			this.disabledTextBrush = new SolidBrush(Color.FromArgb(255,0,0));

			this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
			this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
			this.alertTextBrush = new SolidBrush(Color.White);
			this.alertFont2 = new Font(this.dataGrid2.Font.Name, this.dataGrid2.Font.Size, FontStyle.Bold);
			this.currentRowFont2 = new Font(this.dataGrid2.Font.Name, this.dataGrid2.Font.Size, FontStyle.Regular);

			this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
			this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0,255, 255));
			this.RowBackBrushVP = new SolidBrush(Color.Blue);

            ds1.ReadXml("..\\..\\..\\xml\\m_inravien.xml");
            dsxmlin.ReadXml("..\\..\\..\\xml\\m_inravien.xml");
            dsxmlin.Tables[0].Columns.Add("Image", typeof(byte[]));
            dsxmlin.Tables[0].Columns.Add("Imagetk", typeof(byte[]));
            dsxmlin.Tables[0].Columns.Add("Imageuser", typeof(byte[]));
            dsxmlin.Tables[0].Columns.Add("mabs");
            dsxmlin.Tables[0].Columns.Add("tenbs");
            dsxmlin.Tables[0].Columns.Add("makprv");
            dsxmlin.Tables[0].Columns.Add("tenuser");
            dsxmlin.Tables[0].Columns.Add("cholam");
            dsxmlin.Tables[0].Columns.Add("madt", typeof(decimal));
            dsxmlin.Tables[0].Columns.Add("haophi", typeof(decimal));
            dsxmlin.Tables[0].Columns.Add("gianovat", typeof(decimal));
            dsxmlin.Tables[0].Columns.Add("idttrv", typeof(decimal));
            dsxmlin.Tables[0].Columns.Add("sotientra", typeof(decimal));
            dsxmlin.Tables[0].Columns.Add("traituyen", typeof(decimal));           
            dsxmlin.Tables[0].Columns.Add("kythuat", typeof(decimal));
            dsxmlin.Tables[0].Columns.Add("loaikythuat", typeof(string));
            dsxmlin.Tables[0].Columns.Add("sotoa", typeof(string));
            dsxmlin.Tables[0].Columns.Add("sttbhyt", typeof(decimal)).DefaultValue = 0;
            dsxmlin.Tables[0].Columns.Add("idnhombhyt", typeof(decimal)).DefaultValue = 0;
            dsxmlin.Tables[0].Columns.Add("tennhombhyt", typeof(string));

			ds.ReadXml("..\\..\\..\\xml\\d_duyetbhyt.xml");
			dataGrid2.DataSource=ds.Tables[0];
			AddGridTableStyle2();
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid2.DataSource,dataGrid1.DataMember]; 
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			ds.Tables[0].Columns.Add("Chon",typeof(bool));
            ds.Tables[0].Columns.Add("done", typeof(decimal));
            ds.Tables[0].Columns.Add("mabn");
            ds.Tables[0].Columns.Add("ngay");
            ds.Tables[0].Columns.Add("ngayud");

            chkNhapvien.Checked = d.Thongso("duyetnv") == "1";
			if(bAutoLoad)load_grid("");
            chkList.Checked = bAutoLoad;

            if (bHoadon)
            {
                iMavp_congkham = d.iMavp_congkham(i_nhom);
                dtkp = d.get_data("select makp,tenkp,loaivp,mucvp from "+user+".btdkp_bv order by tenkp").Tables[0];
                sql = "select a.id,a.ma,a.ten,a.dvt,b.stt as sttloai,b.ten as loai,c.stt as sttnhom,c.ten as nhom, a.bhyt, a.kcct, case when a.kythuat is null then -1 else a.kythuat end as kythuat, a.bhyt_tt, c.idnhombhyt, d.stt as sttbhyt, d.ten as tennhombhyt ";
                sql += ",a.sothe ";
                sql += " from "+user+".v_giavp a,"+user+".v_loaivp b,"+user+".v_nhomvp c, "+user+".v_nhombhyt d";
                sql += " where a.id_loai=b.id and b.id_nhom=c.ma and c.idnhombhyt=d.id ";
                dtvpin = m.get_data(sql).Tables[0];

                sql = "select a.id,a.ma,trim(a.ten)||' '||trim(a.hamluong)||' ['||trim(b.ten)||']' as ten,";
                sql += "a.dang as dvt,c.stt as sttloai,c.ten as loai,d.stt as sttnhom,d.ten as nhom, a.bhyt, a.kcct, case when a.kythuat is null then -1 else a.kythuat end as kythuat, a.bhyt as bhyt_tt, d.idnhombhyt, e.stt as sttbhyt, e.ten as tennhombhyt ";
                sql += " ,'' as sothe";
                sql += " from "+user+".d_dmbd a,"+user+".d_dmhang b,"+user+".d_dmnhom c,"+user+".v_nhomvp d,"+user+".v_nhombhyt e";
                sql += " where a.mahang=b.id and a.manhom=c.id and c.nhomvp=d.ma and d.idnhombhyt=e.id";
                dtbd = m.get_data(sql).Tables[0];
                dtdt = m.get_data("select * from "+user+".doituong").Tables[0];
            }
            chkDonChiphi.Checked = d.Thongso("dbhyt") == "1";
            chkChiphi.Checked = !chkDonChiphi.Checked;
            chkcls.Checked = d.Thongso("duyetcls") == "1";
            chkKodichvu.Checked = d.Thongso("Kodichvu") == "1";
            //
            ngay_reset_phieu38 = s_ngay;
            if (d.bSophieu_mau38_tangtheonam(i_nhom))
            {
                ngay_reset_phieu38 = "31/12/20" + s_mmyy.Substring(2, 2);

            }
            else if (d.bSophieu_mau38_tangtheonam_tinhtuthang12(i_nhom))
            {
                ngay_reset_phieu38 = d.get_ngaytao_solieu_thangmoi("01" + s_mmyy.Substring(2, 2), i_nhom); //d.iNgaytinh_Sophieu_mau38_tangtheonam(i_nhom).ToString().PadLeft(2, '0') + "/12/20" + (int.Parse(s_mmyy.Substring(2, 2)) - 1).ToString().PadLeft(2, '0');
            }
            else
            {
                if (d.bSophieu_mau38_tangtheothang(i_nhom)) ngay_reset_phieu38 = "01/" + s_mmyy.Substring(0, 2) + "/20" + s_mmyy.Substring(2, 2);
                else if (d.bSophieu_mau38_tangtheothang_tinhtuthangtruoc(i_nhom))
                {
                    //int tmp_mm = int.Parse(s_mmyy.Substring(0, 2));
                    //int tmp_yy = int.Parse(s_mmyy.Substring(2, 2));
                    //if (tmp_mm == 1) { tmp_mm = 12; tmp_yy = tmp_yy - 1; }
                    //else tmp_mm = tmp_mm - 1;
                    ngay_reset_phieu38 = d.get_ngaytao_solieu_thangmoi(s_mmyy, i_nhom); //d.iNgaytinh_Sophieu_mau38_tangthang(i_nhom).ToString().PadLeft(2, '0') + "/" + tmp_mm.ToString().PadLeft(2, '0') + "/20" + tmp_yy.ToString().PadLeft(2, '0');
                }
            }           
            //gam 16/08/2011
            sql = "select a.id,a.ma,a.ten,a.dvt,b.stt as sttloai,b.ten as loai,c.stt as sttnhom,c.ten as nhom,a.bhyt";
            sql += ",a.gia_th,a.gia_bh,a.gia_cs,a.gia_dv,a.gia_nn,a.vattu_th,a.vattu_bh,a.vattu_cs,a.vattu_dv,a.vattu_nn,a.chenhlech,a.kythuat,c.ma as manhomvp ";
            sql += ", a.kcct, a.bhyt_tt, a.sothe ";
            sql += " from " + user + ".v_giavp a," + user + ".v_loaivp b," + user + ".v_nhomvp c";
            sql += " where a.id_loai=b.id and b.id_nhom=c.ma";
            dtvp = m.get_data(sql).Tables[0];
            //end gam
		}

		private void AddGridTableStyle2()
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
			ts.RowHeaderWidth=3;
			ts.AllowSorting=false;

			FormattableBooleanColumn discontinuedCol = new FormattableBooleanColumn();
			discontinuedCol.MappingName = "chon";
			discontinuedCol.HeaderText = "Bỏ";
			discontinuedCol.Width = 0;//Thuy an cot Bo, khong cho nguoi dung chon bo thuoc trong toa
			discontinuedCol.AllowNull = false;

			discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat2);
			discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged2);
			ts.GridColumnStyles.Add(discontinuedCol);
			dataGrid2.TableStyles.Add(ts);

			FormattableTextBoxColumn TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "hoten";
			TextCol.HeaderText = "Họ tên";
			TextCol.Width =125;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat2);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên thuốc";
			TextCol.Width =100;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat2);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "dang";
            TextCol.HeaderText = "ĐVT";
            TextCol.Width = 25;
            TextCol.ReadOnly = true;
            TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat2);
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "soluong";
			TextCol.HeaderText = "Số lượng";
			TextCol.Width = 50;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat2);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "makho";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat2);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "done";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat2);
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);
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
			ts.SelectionBackColor = Color.FromArgb(0,255,255);
			ts.SelectionForeColor = Color.PaleGreen;
			ts.RowHeaderWidth=3;
			ts.AllowSorting=false;

			FormattableBooleanColumn discontinuedCol = new FormattableBooleanColumn();
			discontinuedCol.MappingName = "chon";
			discontinuedCol.HeaderText = "Chọn";
			discontinuedCol.Width = 30;
			discontinuedCol.AllowNull = false;

			discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
			ts.GridColumnStyles.Add(discontinuedCol);
			dataGrid1.TableStyles.Add(ts);

			FormattableTextBoxColumn TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "mabn";
			TextCol.HeaderText = "Mã BN";
			TextCol.Width =60;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "sothe";
			TextCol.HeaderText = "Số thẻ";
			TextCol.Width = 100;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "hoten";
			TextCol.HeaderText = "Họ tên";
			TextCol.Width = 120;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "id";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "makp";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "tenkp";
            TextCol.HeaderText = "Khoa";
            TextCol.Width = 70;
            TextCol.ReadOnly = true;
            TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "maql";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "madoituong";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "mavaovien";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "mabs";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}
	
		private void SetCellFormat(object sender, DataGridFormatCellEventArgs e)
		{
			try
			{
				bool discontinued = (bool) ((e.Column != 0) ? this.dataGrid1[e.Row, 0] : e.CurrentCellValue);
				if(e.Column > 0 && (bool)(this.dataGrid1[e.Row, 0]))//discontinued)
					e.ForeBrush = this.disabledTextBrush;
				else if(e.Column > 0 && e.Row == this.dataGrid1.CurrentRowIndex)//discontinued)
				{
					e.BackBrush = this.currentRowBackBrush;
					e.TextFont = this.currentRowFont;
				}
			}
			catch{}
		}

		private void SetCellFormat2(object sender, DataGridFormatCellEventArgs e)
		{
			try
			{
				bool discontinued = (bool) ((e.Column != 0) ? this.dataGrid2[e.Row, 0] : e.CurrentCellValue);
                if (e.Column > 0 && (bool)(this.dataGrid2[e.Row, 0])) e.ForeBrush = this.disabledTextBrush;
                else if (e.Column > 0 && this.dataGrid2[e.Row, 4].ToString() == "0") e.ForeBrush = this.RowBackBrushVP;
                else if (e.Column > 0 && this.dataGrid2[e.Row, 6].ToString() == "0" && chkcls.Checked)
                {
                    e.ForeBrush = new SolidBrush(Color.FromArgb(192, 0, 192));
                    //e.BackBrush = new SolidBrush(Color.FromArgb(192, 192, 192));
                }
                else if (e.Column > 0 && e.Row == this.dataGrid2.CurrentRowIndex)
                {
                    e.BackBrush = this.currentRowBackBrush;
                    e.TextFont = this.currentRowFont2;
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
			Rectangle rect = this.dataGrid1.GetCellBounds(row,0);
			rect = new Rectangle(rect.Right, rect.Top, this.dataGrid1.Width, rect.Height);
			this.dataGrid1.Invalidate(rect);
		}


		private void BoolValueChanged2(object sender, BoolValueChangedEventArgs e)
		{
			this.dataGrid2.EndEdit(this.dataGrid2.TableStyles[0].GridColumnStyles["Discontinued"],e.Row, false);
			RefreshRow2(e.Row);
			this.dataGrid2.BeginEdit(this.dataGrid2.TableStyles[0].GridColumnStyles["Discontinued"],e.Row);
		}
		private void RefreshRow2(int row)
		{
			Rectangle rect = this.dataGrid2.GetCellBounds(row,0);
			rect = new Rectangle(rect.Right, rect.Top, this.dataGrid2.Width, rect.Height);
			this.dataGrid2.Invalidate(rect);
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			if((bool)this.dataGrid1[this.dataGrid1.CurrentRowIndex, checkCol]) this.dataGrid1.CurrentCell = new DataGridCell(this.dataGrid1.CurrentRowIndex, checkCol);
			afterCurrentCellChanged = true;
			i_row=dataGrid1.CurrentRowIndex;
		}

		private void dataGrid1_Click(object sender, System.EventArgs e)
		{
            try
            {
                Point pt = this.dataGrid1.PointToClient(Control.MousePosition);
                DataGrid.HitTestInfo hti = this.dataGrid1.HitTest(pt);
                BindingManagerBase bmb = this.BindingContext[this.dataGrid1.DataSource, this.dataGrid1.DataMember];
                if (afterCurrentCellChanged && hti.Row < bmb.Count && hti.Type == DataGrid.HitTestType.Cell && hti.Column == checkCol)
                {
                    this.dataGrid1[hti.Row, checkCol] = !(bool)this.dataGrid1[hti.Row, checkCol];
                    RefreshRow(hti.Row);
                }
                afterCurrentCellChanged = false;
                //
                l_id = decimal.Parse(dataGrid1[i_row, 4].ToString());
                l_maql = decimal.Parse(dataGrid1[i_row, 7].ToString()); // gam 29-04-2011???
                _madoituong = int.Parse(dataGrid1[i_row, 8].ToString());
                l_mavaovien = decimal.Parse(dataGrid1[i_row, 9].ToString());
                s_makp = dataGrid1[i_row, 5].ToString();
                s_mabn = dataGrid1[i_row, 1].ToString();
                s_mabs = dataGrid1[i_row, 10].ToString();
                if (dataGrid1[i_row, 0].ToString().Trim() == "True")
                {
                    lblTongtien.Text = "";
                    load_dtct();
                    foreach (DataRow r in dtct.Rows)
                    {
                        updrec_thuocbhytct(ds.Tables[0], r["mabn"].ToString(), r["ngay"].ToString(), dataGrid1[i_row, 3].ToString(), l_id,(r["stt"].ToString()=="")?1: int.Parse(r["stt"].ToString()), decimal.Parse(r["sttt"].ToString()), int.Parse(r["mabd"].ToString()),
                            r["ma"].ToString(), r["ten"].ToString(), r["tenhc"].ToString(), r["dang"].ToString(), r["tenkho"].ToString(),
                            (r["tennguon"].ToString() == "") ? s_mabs : r["tennguon"].ToString(), r["maql"].ToString(), r["handung"].ToString(), r["losx"].ToString(), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()),
                            decimal.Parse(r["sotien"].ToString()), r["cachdung"].ToString(), int.Parse(r["makho"].ToString()), int.Parse(r["manguon"].ToString()), int.Parse(r["nhomcc"].ToString()), r["ngayud"].ToString(), int.Parse(r["done"].ToString()));
                    }
                    f_tinhtongtien(s_mabn, l_maql, l_mavaovien);
                }
                else d.delrec(ds.Tables[0], "id=" + l_id);
            }
            catch (Exception ex)
            {
                string strerr = ex.ToString();
            }
		}

        private void load_grid(string mabn)
        {
            //
            string sql_bhyt = "";
            //Neu ngay hien tai so voi dau thang > ngay kiem ke chi lay trong thang
            if (d.iNgaykiemke < d.songay(m.StringToDate(s_ngay), m.StringToDate("01/" + s_mmyy.Substring(0, 2) + "/20" + s_mmyy.Substring(2, 2)), 1)) sql_bhyt = "xxx.bhyt ";
            else
            {
                sql_bhyt = "select mabn, maql, sothe, tungay, denngay, mabv, traituyen, sudung from xxx.bhyt ";
                sql_bhyt = m.get_sql_mmyy(sql_bhyt, s_ngay, s_ngay, true);
                sql_bhyt = "(" + sql_bhyt + ")";
            }
            //
            sql = "select distinct a.id,a.mabn,a.maql,a.mavaovien,";//,coalesce(c.traituyen,0) as traituyen
            //binh 31082013
            if (i_loaiba == 2) sql += "coalesce(cc.sothe,c.sothe) as sothe, coalesce(cc.traituyen,coalesce(c.traituyen,0)) as traituyen, coalesce(cc.sothe,c.sothe) as sothengtr,";
            else sql += "c.sothe,coalesce(c.traituyen,0) as traituyen,c.sothe as sothengtr,";
            //
            sql += " b.hoten,b.namsinh,trim(b.sonha)||' '||b.thon as diachi,b.cholam,x.tentt,y.tenquan,z.tenpxa,";
            if (i_loaiba == 2) sql += " coalesce(c.mabv,'0') as mabv,";
            else sql += "c.mabv,";
            sql += "a.makp,d.tenkp,a.chandoan,a.maicd,a.mabs,a.madoituong,e.mien,coalesce(e.field_gia,'gia_th') as field_gia,a.loaiba,a.ngaynghi,0 as mangtr";//coalesce(c.mabv,f.mabv) as mabv// Thuy 03.01.2012
            sql += " from xxx.d_thuocbhytll a inner join " + user + ".btdbn b on a.mabn=b.mabn ";
            sql += " left join " + user + ".btdkp_bv d on a.makp=d.makp ";
            if (i_loaiba == 2 || i_loaiba == 1)
            {
                sql += " left join " + user + ".bhyt c on a.maql=c.maql ";
                if (i_loaiba == 2) sql += " left join " + sql_bhyt + " cc on a.maql=cc.maql";//sql += " left join xxx.bhyt cc on a.maql=cc.maql";////binh 31082013
            }
            else
            {
                sql += " left join " + sql_bhyt + " c on a.maql=c.maql"; //sql += " left join xxx.bhyt c on a.maql=c.maql ";
            }
            sql += " inner join " + user + ".doituong e on a.madoituong=e.madoituong";
            sql += " inner join xxx.d_thuocbhytct t on a.id=t.id ";
            sql += " left join " + user + ".btdtt x on b.matt=x.matt ";
            sql += " left join " + user + ".btdquan y on b.maqu=y.maqu ";
            sql += " left join " + user + ".btdpxa z on b.maphuongxa=z.maphuongxa ";
            if (chkNhapvien.Checked) sql += " left join xxx.xutrikbct s on a.maql=s.maql ";
            sql += " where a.done=0 ";
            if (s_tu == s_den) sql += " and to_char(a.ngay,'dd/mm/yyyy')='" + s_tu + "'";
            else sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";
            if (chkNhapvien.Checked) sql += " and (s.xutri is null or s.xutri not like '%05,%')";
            if (i_madoituong == 1) sql += " and a.madoituong=1";            
            else if (i_loaiba != 2) sql += " and a.madoituong<>1 and (e.mien=1 or e.trasau=1)";//linh 20/04/2012
            else sql += " and a.madoituong<>1 ";
            if (i_loaiba == 2 && bCapve_noitru)
            {
                sql += " and a.loaiba in (2)";
                bduyetkhambenhchuyenvaongoaitru = true;
            }
            else if (i_loaiba == 2) sql += " and a.loaiba=" + i_loaiba;
            else
            {
                sql += " and a.loaiba<>2";
            }
            sql += " and a.nhom=" + i_nhom;
            if (s_kho != "") sql += " and t.makho in (" + s_kho.Substring(0, s_kho.Length) + ")";
            if (mabn != "") sql += " and a.mabn like '%" + mabn + "%'";
            if (bHoadon)
            {
                // lay thong tin chi dinh dich vu
                sql += " union all select distinct 0 as id,a.mabn,to_number('0') as maql,a.mavaovien,";
                ////binh 31082013
                if (i_loaiba != 2) sql += " c.sothe,coalesce(c.traituyen,0) as traituyen,c.sothe as sothengtr";
                else sql += " coalesce(cc.sothe, c.sothe) as sothe,coalesce(cc.traituyen,coalesce(c.traituyen,0)) as traituyen,coalesce(cc.sothe,c.sothe) as sothengtr";
                //
                sql += " ,b.hoten,b.namsinh,trim(b.sonha)||' '||b.thon as diachi,b.cholam,x.tentt,y.tenquan,z.tenpxa,";
                sql += " c.mabv,a.makp,f.tenkp,";
                sql += "'' as chandoan,'' as maicd,'' as mabs,";//PK(co icd)+TD(0 co icd) --> de khong hien thi 2 dong: nen khong lay cd, chi lay chan doa khi luu
                sql += " a.madoituong,e.mien,coalesce(e.field_gia,'gia_th') as field_gia,a.loaiba,0 as ngaynghi,a.mangtr ";
                sql += " from (select distinct u.ngay,u.mabn,u.mavaovien,u.maql,u.madoituong,u.makp,u.loaiba,u.paid, " +
                    "coalesce(nullif(u.chandoan,''),v.chandoan) as chandoan,coalesce(nullif(u.maicd,''),v.maicd) as maicd,v.mangtr " +
                    " from xxx.v_chidinh u left join (select distinct mavaovien, maql,mangtr, maicd,chandoan from xxx.benhanpk) v on ";
                if (i_loaiba == 2)
                {
                    sql += " u.maql = v.maql ";
                }
                else
                {
                    sql += " u.mavaovien=v.mavaovien ";
                }
                sql += " where u.paid=0) a inner join " + user + ".btdbn b on a.mabn=b.mabn ";
                if (i_loaiba == 2 || i_loaiba == 1)
                {
                    sql += " left join " + user + ".bhyt c on a.maql=c.maql ";
                    if (i_loaiba == 2) sql += " left join " + sql_bhyt + " cc on a.maql=cc.maql"; //sql += " left join xxx.bhyt cc on a.maql=cc.maql";//binh 31082013
                }
                else
                {
                    sql += " left join " + sql_bhyt + " c on a.maql=c.maql ";// sql += " left join xxx.bhyt c on a.maql=c.maql ";
                }
                sql += " inner join " + user + ".doituong e on a.madoituong=e.madoituong ";
                sql += " left join " + user + ".btdkp_bv f on a.makp=f.makp ";
                sql += " left join " + user + ".btdtt x on b.matt=x.matt ";
                sql += " left join " + user + ".btdquan y on b.maqu=y.maqu ";
                sql += " left join " + user + ".btdpxa z on b.maphuongxa=z.maphuongxa ";
                if (chkNhapvien.Checked) sql += " left join xxx.xutrikbct s on a.maql=s.maql ";
                sql += " where a.paid=0 ";
                if (s_tu == s_den) sql += " and to_char(a.ngay,'dd/mm/yyyy')='" + s_tu + "'";
                else sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";
                if (chkNhapvien.Checked) sql += " and (s.xutri is null or s.xutri not like '%05,%')";
                if (bDuyetcls) sql += " and a.duyet=1";
                if (i_madoituong == 1) sql += " and a.madoituong=1";
                else if (i_loaiba != 2) sql += " and a.madoituong<>1 and (e.mien=1 or e.trasau=1)";//linh 20/04/2012
                else sql += " and a.madoituong<>1 ";
                if (i_loaiba == 2) sql += " and (a.mangtr<>0 or a.mavaovien in (select  mavaovien from " + user + ".benhanngtr))";//linh 07112012
                else
                {
                    sql += " and (a.mangtr=0 or a.mangtr is null)";
                    sql += " and a.loaiba<>1";
                }
                if (mabn != "") sql += " and a.mabn like '%" + mabn + "%'";
                sql += " and to_char(a.mavaovien)||a.makp not in (select to_char(mavaovien)||makp from xxx.d_thuocbhytll where done=0 and " + m.for_ngay("ngay", stime) + " between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";//to_char(ngay,'dd/mm/yyyy')='"+s_ngay+"'";
                sql += " and nhom=" + i_nhom;
                if (i_madoituong == 1) sql += " and madoituong=1";
                else sql += " and madoituong<>1";
                if (i_loaiba == 2) sql += " and loaiba=" + i_loaiba;
                else
                {
                    sql += " and loaiba<>2";
                }
                sql += ")";
            }
            dt = d.get_data_mmyy(sql, s_tu, s_den, songayduyet).Tables[0];
            DataRow r1;
            if (s_mavp != "")
            {
                DataTable dtpk = d.get_data_mmyy("select distinct mavaovien,makp from xxx.benhanpk", s_tu, s_den, songayduyet).Tables[0];
                foreach (DataRow r in dt.Select("loaiba=3 and id=0"))
                {
                    sql = "select * from xxx.v_chidinh where mavaovien=" + decimal.Parse(r["mavaovien"].ToString()) + " and makp='" + r["makp"].ToString() + "'";
                    sql += " and mavp in (" + s_mavp + ")";
                    foreach (DataRow r2 in d.get_data_mmyy(sql, s_tu, s_den, songayduyet).Tables[0].Rows)
                    {
                        r1 = d.getrowbyid(dtpk, "mavaovien='" + decimal.Parse(r2["mavaovien"].ToString()) + "' and makp=" + r2["makp"].ToString());
                        if (r1 == null) r.Delete();
                    }
                }
                dt.AcceptChanges();
            }
            if (chkNhapvien.Checked)
                dtnv = d.get_data_mmyy("select a.mavaovien from xxx.benhanpk a,xxx.xutrikbct b where a.maql=b.maql and b.xutri like '%05,%' and " + m.for_ngay("a.ngay", stime) + " between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')", s_tu, s_den, songayduyet).Tables[0];
            DataTable dtchidinh = new DataTable();
            foreach (DataRow r in dt.Select("id=0"))
            {
                //r["id"] = d.get_id_bhyt;
                sql = "select * from xxx.v_chidinh where mavaovien=" + decimal.Parse(r["mavaovien"].ToString()) + " and makp='" + r["makp"].ToString() + "'";
                dtchidinh = d.get_data_mmyy(sql, s_tu, s_den, songayduyet).Tables[0];
                if (dtchidinh.Rows.Count == 0)
                {
                    r.Delete();
                }
                else
                {
                    foreach (DataRow r2 in dtchidinh.Rows)
                    {
                        r["id"] = r2["id"].ToString();
                        r["maql"] = r2["maql"].ToString();
                    }
                }
            }
            bool bExit = false;
            foreach (DataRow r in dt.Rows)
            {
                if (i_loaiba == 2) r["sothe"] = (r["sothe"].ToString() == "") ? r["sothengtr"].ToString() : r["sothe"].ToString();
                if (r["madoituong"].ToString() == "1" && r["sothe"].ToString().Trim() == "")
                {
                    bExit = false;
                    foreach (DataRow r2 in d.get_data("select * from " + user + m.mmyy(s_ngay) + ".bhyt where mabn='" + r["mabn"].ToString() + "' order by maql desc").Tables[0].Rows)
                    {
                        r["sothe"] = r2["sothe"].ToString();
                        r["mabv"] = r2["mabv"].ToString();
                        bExit = true;
                        break;
                    }
                    if (!bExit)
                    {
                        foreach (DataRow r2 in d.get_data("select * from " + user + ".bhyt where mabn='" + r["mabn"].ToString() + "' order by maql desc").Tables[0].Rows)
                        {
                            r["sothe"] = r2["sothe"].ToString();
                            r["mabv"] = r2["mabv"].ToString();
                            break;
                        }
                    }
                }
                if (chkNhapvien.Checked)
                {
                    r1 = d.getrowbyid(dtnv, "mavaovien='" + decimal.Parse(r["mavaovien"].ToString())+"'");
                    if (r1 != null) r.Delete();
                }
            }
            dt.AcceptChanges();
            dataGrid1.DataSource = dt;
            if (!bSkip) AddGridTableStyle();
            bSkip = true;
            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource, dataGrid1.DataMember];
            DataView dv = (DataView)cm.List;
            dv.AllowNew = false;
            dt.Columns.Add("Chon", typeof(bool));
            foreach (DataRow row in dt.Rows)
            {
                row["chon"] = false;
            }
            butLuu.Enabled = dt.Rows.Count != 0;
            butIn.Enabled = butLuu.Enabled;
            dataGrid1.Focus();
            i_row = dataGrid1.CurrentRowIndex;
            load_items();
        }
		private void load_grid________(string mabn)
		{
            sql = "select distinct a.id,a.mabn,a.maql,a.mavaovien,c.sothe,coalesce(c.traituyen,0) as traituyen,";
            if (i_loaiba == 2) sql += "c.sothe as sothengtr,";
            else sql += "c.sothe as sothengtr,";
            sql+=" b.hoten,b.namsinh,trim(b.sonha)||' '||b.thon as diachi,b.cholam,x.tentt,y.tenquan,z.tenpxa,";
            if (i_loaiba == 2) sql += " coalesce(c.mabv,'0') as mabv,";
            else sql += "c.mabv,";
            sql += "a.makp,d.tenkp,a.chandoan,a.maicd,a.mabs,a.madoituong,e.mien,coalesce(e.field_gia,'gia_th') as field_gia,a.loaiba,a.ngaynghi,0 as mangtr";//coalesce(c.mabv,f.mabv) as mabv// Thuy 03.01.2012
			sql+=" from xxx.d_thuocbhytll a inner join "+user+".btdbn b on a.mabn=b.mabn ";
            sql+=" left join "+ user+".btdkp_bv d on a.makp=d.makp ";
            if (i_loaiba == 2 || i_loaiba == 1)
            {
                sql += " left join " + user + ".bhyt c on a.maql=c.maql ";
            }
            else
            {
                sql += " left join xxx.bhyt c on a.maql=c.maql ";
            }
            sql += " inner join "+user+".doituong e on a.madoituong=e.madoituong";
            sql += " inner join xxx.d_thuocbhytct t on a.id=t.id ";
            sql += " left join " + user + ".btdtt x on b.matt=x.matt ";
            sql += " left join " + user + ".btdquan y on b.maqu=y.maqu ";
            sql += " left join " + user + ".btdpxa z on b.maphuongxa=z.maphuongxa ";
            if (chkNhapvien.Checked) sql += " left join xxx.xutrikbct s on a.maql=s.maql ";
            sql += " where a.done=0 ";
            if (s_tu==s_den) sql+=" and to_char(a.ngay,'dd/mm/yyyy')='"+s_tu+"'";
            else sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";
            if (chkNhapvien.Checked) sql += " and (s.xutri is null or s.xutri not like '%05,%')";
            if (i_madoituong == 1 && i_loaiba!=2) sql += " and a.madoituong=1";
            else if(i_loaiba!=2) sql += " and a.madoituong<>1 and e.mien=1 and e.trasau=1";//linh 20/04/2012
            if (i_loaiba == 2 && bCapve_noitru)
            {
                sql += " and a.loaiba in (2)";
                bduyetkhambenhchuyenvaongoaitru = true;
            }
            else if (i_loaiba == 2) sql += " and a.loaiba=" + i_loaiba;
            else
            {
                sql += " and a.loaiba<>2";
            }
			sql+=" and a.nhom="+i_nhom;
            if (s_kho != "") sql += " and t.makho in (" + s_kho.Substring(0, s_kho.Length) + ")";
            if (mabn != "") sql += " and a.mabn like '%" + mabn + "%'";
			if (bHoadon)
			{
                // lay thong tin chi dinh dich vu
                sql += " union all select distinct 0 as id,a.mabn,to_number('0') as maql,a.mavaovien,c.sothe,coalesce(c.traituyen,0) as traituyen,c.sothe as sothengtr,b.hoten,b.namsinh,trim(b.sonha)||' '||b.thon as diachi,b.cholam,x.tentt,y.tenquan,z.tenpxa,";
                sql += " c.mabv,a.makp,f.tenkp,";
                sql += "'' as chandoan,'' as maicd,'' as mabs,";//PK(co icd)+TD(0 co icd) --> de khong hien thi 2 dong: nen khong lay cd, chi lay chan doa khi luu
                sql += " a.madoituong,e.mien,coalesce(e.field_gia,'gia_th') as field_gia,a.loaiba,0 as ngaynghi,a.mangtr ";
                sql += " from (select distinct u.ngay,u.mabn,u.mavaovien,u.maql,u.madoituong,u.makp,u.loaiba,u.paid, " +
                    "coalesce(nullif(u.chandoan,''),v.chandoan) as chandoan,coalesce(nullif(u.maicd,''),v.maicd) as maicd,v.mangtr " +
                    " from xxx.v_chidinh u left join (select distinct mavaovien, maql,mangtr, maicd,chandoan from xxx.benhanpk) v on ";
                if (i_loaiba == 2)
                {
                    sql += " u.maql = v.maql ";
                }
                else
                {
                    sql += " u.mavaovien=v.mavaovien ";
                }
                sql += " where u.paid=0) a inner join " + user + ".btdbn b on a.mabn=b.mabn ";
                if (i_loaiba == 2 || i_loaiba == 1)
                {
                    sql += " left join " + user + ".bhyt c on a.maql=c.maql ";
                }
                else
                {
                    sql += " left join xxx.bhyt c on a.maql=c.maql ";
                }
                sql += " inner join " + user + ".doituong e on a.madoituong=e.madoituong ";
                sql += " left join " + user + ".btdkp_bv f on a.makp=f.makp ";
                sql += " left join " + user + ".btdtt x on b.matt=x.matt ";
                sql += " left join " + user + ".btdquan y on b.maqu=y.maqu ";
                sql += " left join " + user + ".btdpxa z on b.maphuongxa=z.maphuongxa ";
                if (chkNhapvien.Checked) sql += " left join xxx.xutrikbct s on a.maql=s.maql ";
                sql += " where a.paid=0 ";
                if (s_tu == s_den) sql += " and to_char(a.ngay,'dd/mm/yyyy')='"+s_tu+"'";
                else sql+=" and " + m.for_ngay("a.ngay", stime) + " between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";
                if (chkNhapvien.Checked) sql += " and (s.xutri is null or s.xutri not like '%05,%')";
                if (bDuyetcls) sql += " and a.duyet=1";
                if (i_madoituong == 1) sql += " and a.madoituong=1";
                else sql += " and a.madoituong<>1 and e.mien=1 and e.trasau=1";//linh 20/04/2012
                if (i_loaiba == 2) sql += " and (a.mangtr<>0 or a.mavaovien in (select  mavaovien from " + user + ".benhanngtr))";//linh 07112012
                else
                {
                    sql += " and (a.mangtr=0 or a.mangtr is null)";
                    sql += " and a.loaiba<>1";
                }
                if (mabn != "") sql += " and a.mabn like '%" + mabn + "%'";
                sql += " and to_char(a.mavaovien)||a.makp not in (select to_char(mavaovien)||makp from xxx.d_thuocbhytll where done=0 and " + m.for_ngay("ngay", stime) + " between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";//to_char(ngay,'dd/mm/yyyy')='"+s_ngay+"'";
				sql += " and nhom="+i_nhom;
                if (i_madoituong == 1) sql += " and madoituong=1";
                else sql += " and madoituong<>1"; 
                if (i_loaiba == 2) sql += " and loaiba=" + i_loaiba;
                else
                {
                    sql += " and loaiba<>2";
                }
				sql+=")";
            }
			dt=d.get_data_mmyy(sql,s_tu,s_den,songayduyet).Tables[0];
            DataRow r1;
            if (s_mavp != "")
            {
                DataTable dtpk = d.get_data_mmyy("select distinct mavaovien,makp from xxx.benhanpk",s_tu,s_den,songayduyet).Tables[0];                
                foreach (DataRow r in dt.Select("loaiba=3 and id=0"))
                {
                    sql = "select * from xxx.v_chidinh where mavaovien=" + decimal.Parse(r["mavaovien"].ToString()) + " and makp='" + r["makp"].ToString() + "'";
                    sql += " and mavp in (" + s_mavp + ")";
                    foreach(DataRow r2 in d.get_data_mmyy(sql, s_tu, s_den, songayduyet).Tables[0].Rows)
                    {
                        r1 = d.getrowbyid(dtpk, "mavaovien='" + decimal.Parse(r2["mavaovien"].ToString()) + "' and makp=" + r2["makp"].ToString());
                        if (r1 == null) r.Delete();
                    }
                }
                dt.AcceptChanges();
            }
            if (chkNhapvien.Checked)
                dtnv = d.get_data_mmyy("select a.mavaovien from xxx.benhanpk a,xxx.xutrikbct b where a.maql=b.maql and b.xutri like '%05,%' and " + m.for_ngay("a.ngay", stime) + " between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')",s_tu,s_den,songayduyet).Tables[0];
            DataTable dtchidinh = new DataTable();
            foreach (DataRow r in dt.Select("id=0"))
            {
                //r["id"] = d.get_id_bhyt;
                sql = "select * from xxx.v_chidinh where mavaovien=" + decimal.Parse(r["mavaovien"].ToString()) + " and makp='" + r["makp"].ToString() + "'";
                dtchidinh =  d.get_data_mmyy(sql, s_tu, s_den, songayduyet).Tables[0];
                if (dtchidinh.Rows.Count == 0)
                {
                    r.Delete();
                }
                else
                {
                    foreach (DataRow r2 in dtchidinh.Rows)
                    {
                        r["id"] = r2["id"].ToString();
                        r["maql"] = r2["maql"].ToString();
                    }
                }
            }
            bool bExit = false;
            foreach (DataRow r in dt.Rows)
            {
                if (i_loaiba == 2) r["sothe"] = (r["sothe"].ToString() == "") ? r["sothengtr"].ToString() : r["sothe"].ToString();
                if (r["madoituong"].ToString() == "1" && r["sothe"].ToString().Trim() == "")
                {
                    bExit = false;
                    foreach (DataRow r2 in d.get_data("select * from " + user+m.mmyy(s_ngay) + ".bhyt where mabn='" + r["mabn"].ToString() + "' order by maql desc").Tables[0].Rows)
                    {
                        r["sothe"] = r2["sothe"].ToString();
                        r["mabv"] = r2["mabv"].ToString();
                        bExit = true;
                        break;
                    }
                    if (!bExit)
                    {
                        foreach (DataRow r2 in d.get_data("select * from " + user + ".bhyt where mabn='" + r["mabn"].ToString() + "' order by maql desc").Tables[0].Rows)
                        {
                            r["sothe"] = r2["sothe"].ToString();
                            r["mabv"] = r2["mabv"].ToString();
                            break;
                        }
                    }
                }
                if (chkNhapvien.Checked)
                {
                    r1=d.getrowbyid(dtnv,"mavaovien='"+decimal.Parse(r["mavaovien"].ToString())+"'");
                    if (r1 != null) r.Delete();
                }
            }
            dt.AcceptChanges();
			dataGrid1.DataSource=dt;
			if (!bSkip) AddGridTableStyle();
			bSkip=true;
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember]; 
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			dt.Columns.Add("Chon",typeof(bool));
            foreach (DataRow row in dt.Rows)
            {
                row["chon"] = false;
            }
			butLuu.Enabled=dt.Rows.Count!=0;
			butIn.Enabled=butLuu.Enabled;
			dataGrid1.Focus();
			i_row=dataGrid1.CurrentRowIndex;
			load_items();
		}

		private void load_items()
		{
			ds.Clear();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			luu_in(false);
            lblTongtien.Text = "";
		}

		private void load_tonct()
		{
			dttonct=d.get_tonkhoct_bhyt(s_mmyy,s_kho,"",s_manguon,i_madoituong,i_nhom);
		}

		private void load_dtct()
		{
            DataSet dstmp, ds1;
            
            //lấy thông tin toa thuốc
			sql="select f.maql,f.maql as maql1,a.stt,to_number('0') as sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,";
            sql += " b.tenhc,b.dang,e.ten as tenkho,f.mabs as tennguon,f.mabs as tennhomcc,";//c.ten as tennguon
            sql += " ' ' as handung,' ' as losx,ceiling(a.slyeucau) as soluong,b.dongia as dongia,ceiling(a.slyeucau)*b.dongia as sotien,0 as giaban,0 as giamua,0 as sotienmua,";
            sql += " a.cachdung,a.makho,a.manguon,0 as nhomcc,1 as done,to_char(f.ngay,'dd/mm/yyyy') as ngay,to_char(f.ngayud,'dd/mm/yyyy hh24:mi') as ngayud,f.mabn ";
            sql += " from xxx.d_thuocbhytct a," + user + ".d_dmbd b," + user + ".d_dmnguon c," + user + ".d_dmkho e,xxx.d_thuocbhytll f ";
            sql += " where a.id=f.id and a.mabd=b.id and a.manguon=c.id and a.makho=e.id ";
            if (i_loaiba == 2 && bCapve_noitru)
            {
                sql += " and f.maql ="+l_maql;
                sql += " and f.madoituong=" + _madoituong;
            }
            else
            {
                sql += " and a.id=" + l_id;// +" order by a.stt";
            }
			if (bHoadon)
			{
                // lấy thông tin chỉ định dịch vụ
                sql += " union all ";
                sql += " select a.maql, case when c.maql is null then 0 else c.maql end as j,a.stt as stt,a.id as sttt,a.mavp as mabd,b.ma,b.ten,";
                sql += " case when a.chandoan='' or a.chandoan=c.chandoan then c.chandoan else a.chandoan||';'||c.chandoan end as tenhc,b.dvt as dang,";
                sql += " case when a.maicd='' or a.maicd=c.maicd then c.maicd else a.maicd||';'||c.maicd end as tenkho,";
				sql += " case when a.mabs='' then c.mabs else a.mabs end as tennguon,";
                sql += " a.mabs as tennhomcc,a.makp as handung,a.mabn as losx,a.soluong,a.dongia+a.vattu as dongia,";
                sql += " a.soluong*(a.dongia+a.vattu) as sotien,0 as giaban,0 as giamua,0 as sotienmua,' ' as cachdung,0 as makho,0 as manguon,0 as nhomcc,a.done,to_char(a.ngay,'dd/mm/yyyy') as ngay,to_char(a.ngayud,'dd/mm/yyyy hh24:mi') as ngayud,a.mabn ";
				sql += " from xxx.v_chidinh a left join xxx.benhanpk c on a.maql=c.maql left join "+user+".v_giavp b on a.mavp=b.id ";
                //sql += " from xxx.v_chidinh a left join " + user + ".vbenhanpk_" + s_idcomputer + " c on a.maql=c.maql left join " + user + ".v_giavp b on a.mavp=b.id ";
                sql += " where a.paid=0 and a.mabn='" + s_mabn + "' and " + m.for_ngay("a.ngay", stime) + " between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";//to_char(a.ngay,'dd/mm/yyyy')='"+s_ngay.Substring(0,10)+"'";
                if (bDuyetcls) sql += " and a.duyet=1";
                sql += " and a.makp='"+s_makp+"'";
                //Thuy 23.12.2011 -- tai sao lai bo ra vay? binh 02082012: phuc hoi lai
                //if (l_maql != 0 && bPhongkhamduyetrieng) sql += " and a.maql in (" + l_maql + "," + l_mavaovien + ")";
                //else 
                sql += " and a.mavaovien=" + l_mavaovien;
                //end Thuy // xoa dieu kien if else
                sql += " and a.loaiba<>1";
                sql += " and a.madoituong=" + _madoituong;
			}
            dstmp = d.get_data_mmyy(sql,s_tu,s_den,songayduyet);
            ds1 = dstmp.Copy();
            dstmp.Clear();
            dstmp.Merge(ds1.Tables[0].Select("true", "sttt,stt"));
			dtct=dstmp.Tables[0];
            decimal maql1=l_maql, maql2=l_maql;
            //if (maql1 == 0 && dtct.Rows.Count > 0) maql1 = decimal.Parse(dtct.Rows[dtct.Rows.Count-1]["maql"].ToString());
            //if (maql2 == 0) maql2 = maql1;
            foreach (DataRow r in dtct.Select("sttt<>0 and tennguon is null"))
            {
                if (maql1 == 0 && decimal.Parse(r["maql"].ToString()) != 0 && decimal.Parse(r["maql1"].ToString())!=0) maql1 = decimal.Parse(r["maql"].ToString());
                if (maql2 == 0 && decimal.Parse(r["maql"].ToString()) != 0 && decimal.Parse(r["maql1"].ToString())!=0) maql2 = decimal.Parse(r["maql"].ToString());
                foreach (DataRow r1 in d.get_data_mmyy("select * from xxx.benhanpk where mavaovien=" + decimal.Parse(r["maql"].ToString()) + " and makp='" + r["handung"].ToString()+"'", s_tu, s_den, songayduyet).Tables[0].Rows)
                {
                    r["tennguon"] = r1["mabs"].ToString();
                    r["tenkho"] = r1["maicd"].ToString();
                    r["tenhc"] = r1["chandoan"].ToString();
                    break;
                }
            }
            try
            {
                DataRow r2 = d.getrowbyid(dt, "id='" + l_id + "' and maql=0");
                if (r2 != null) r2["maql"] = maql1;
                else
                {
                    r2 = d.getrowbyid(dt, "maql=0 and mabn='" + s_mabn + "' and makp='" + s_makp + "'");
                    if (r2 != null) r2["maql"] = maql2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
		}

		private bool kiemtra(DataRow [] dr,string mabn,string hoten)
		{
			s_hoten="";
			try
			{
				int i_toaso=d.kiemtra_baohiem(dr,s_ngay,mabn,s_mmyy);
				if (i_toaso!=0)
				{
					if (MessageBox.Show(lan.Change_language_MessageText("Họ tên")+" "+hoten+"\n"+lan.Change_language_MessageText("đã nhập toa số")+" "+i_toaso.ToString()+"\n"+lan.Change_language_MessageText("Bạn có muốn nhập thêm không ?"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No)
						return false;
					else
						s_hoten="(+)";
				}
			}
			catch{}
			return true;
		}

		private void upd_data(bool prn)
		{
			s_hoten="";
			decimal o_id=0;
			int maphu;
			decimal d_thuoc,d_bntra=0,d_bhyttra=0;
			DataRow r;
			DataRow [] dr=ds.Tables[0].Select("chon=false and soluong>0","id,stt");
            
			for(int i=0;i<dr.Length;i++)
			{
               
				l_id=decimal.Parse(dr[i]["id"].ToString());
				if (o_id!=l_id)
				{
					r=d.getrowbyid(dt,"chon=true and id='"+l_id+"'");
					if (r!=null)
					{
						if (!kiemtra(ds.Tables[0].Select("soluong>0 and chon=false and id='"+l_id+"'","mabd,soluong"),r["mabn"].ToString(),r["hoten"].ToString().Trim())) return;
						d_thuoc=0;maphu=int.Parse(r["madoituong"].ToString());d_bntra=0;d_bhyttra=0;
                        itable = d.tableid(s_mmyy, "bhytkb");
                        d.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
                        d.upd_bhytds(s_mmyy, r["mabn"].ToString(), r["hoten"].ToString().Trim().Trim().Trim('-').Trim('+').Trim('-') + s_hoten.Trim().Trim('-').Trim('+').Trim('-'), r["namsinh"].ToString(), r["diachi"].ToString().Trim().Trim().Trim('-').Trim('+').Trim('-') + " " + r["tenpxa"].ToString().Trim() + " " + r["tenquan"].ToString().Trim() + " " + r["tentt"].ToString());//r["cholam"].ToString().Trim()+";"+
                        d.upd_bhytkb(s_mmyy, l_id, i_nhom, 0, 0, s_ngay, r["mabn"].ToString(), decimal.Parse(r["mavaovien"].ToString()), decimal.Parse(r["maql"].ToString()), r["makp"].ToString(), r["chandoan"].ToString().Trim().Trim('-').Trim('+').Trim('-'), r["maicd"].ToString().Trim().Trim('-').Trim('+').Trim('-'), r["mabs"].ToString(), (r["sothe"].ToString() == "") ? r["sothengtr"].ToString() : r["sothe"].ToString(), maphu, r["mabv"].ToString(), 0, d_thuoc, 0, d_bntra, d_bhyttra, i_userid, r["mangtr"].ToString() =="0"?int.Parse(r["loaiba"].ToString()):2, int.Parse(r["traituyen"].ToString()),(bChuahoantatkham ? 1 : 0));
                        itable = d.tableid(s_mmyy, "bhytthuoc");                      
                        foreach (DataRow r1 in d.get_bhytthuoc(s_ngay, s_mmyy, ds.Tables[0].Select("chon=false and id='" + l_id+"'", "stt"), l_id, (i_loaiba == 2) ? 0 : i_madoituong).Rows)
                        {
                            d.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
                            d_thuoc = d_thuoc + decimal.Parse(r1["soluong"].ToString()) * ((bGiaban) ? decimal.Parse(r1["giaban"].ToString()) : decimal.Parse(r1["giamua"].ToString()));
                        }
						d_bntra=0;d_bhyttra=d_thuoc;
						if (r["mien"].ToString()=="0")
						{
							d_bntra=d_thuoc;
							d_bhyttra=0;
						}
						//d.execute_data("update "+yyy+".bhytkb set thuoc="+d_thuoc+",cls=0,congkham=0,bntra="+d_bntra+",bhyttra="+d_bhyttra+" where id="+l_id);
                        // hien: ngay nghi
                        d.execute_data("update " + yyy + ".bhytkb set thuoc=" + d_thuoc + 
                            ",cls=0,congkham=0,bntra=" + d_bntra + ",bhyttra=" + d_bhyttra + ",ngaynghi="+r["ngaynghi"].ToString()+" where id=" + l_id);
                        // end hien
                        d.updrec_bhytll(dtll, l_id, r["mabn"].ToString(), decimal.Parse(r["mavaovien"].ToString()), decimal.Parse(r["maql"].ToString()), r["hoten"].ToString(), r["namsinh"].ToString(), s_ngay, r["diachi"].ToString().Trim() + " " + r["tenpxa"].ToString().Trim() + " " + r["tenquan"].ToString().Trim() + " " + r["tentt"].ToString(), r["makp"].ToString(), r["chandoan"].ToString(), r["maicd"].ToString(), r["mabs"].ToString(), (r["sothe"].ToString() == "") ? r["sothengtr"].ToString() : r["sothe"].ToString(), maphu, r["mabv"].ToString(), 0);
						d.execute_data_mmyy("update xxx.d_thuocbhytll set done=1 where id="+l_id,s_tu,s_den,songayduyet);
					}
					o_id=l_id;
                    if (prn && r!=null) printer(l_id, d_bntra, d_bhyttra, r["mabn"].ToString(), r["hoten"].ToString(), r["namsinh"].ToString(), r["diachi"].ToString().Trim() + " " + r["tenpxa"].ToString().Trim() + " " + r["tenquan"].ToString().Trim() + " " + r["tentt"].ToString(), (r["sothe"].ToString() == "") ? r["sothengtr"].ToString() : r["sothe"].ToString(), r["chandoan"].ToString(), d_bntra + d_bhyttra, 0, 0, r["mabs"].ToString(),int.Parse(r["traituyen"].ToString()));//r["cholam"].ToString().Trim() + ";" + 
				}
			}
		}

		private void upd_data_hoadon(bool prn)
		{
			decimal o_id=0;
			DataRow r;
			DataRow [] dr1,dr=ds.Tables[0].Select("chon=false and soluong>0","id,stt");			
			string kyhieu=d.Thongso("c00").ToString(),_sothe="";
            string s_chandoan = "", s_icd = "", stttoa="";
			DataTable dtqs=d.get_data("select * from "+user+".v_quyenso").Tables[0];
			int i_quyenso=0;
            int maphu = 1, ma;
            decimal chitra;
            decimal d_thuoc, d_bntra = 0, d_bhyttra = 0, d_cls, d_chiphi = 0, d_congkham = d.Congkham(i_nhom), d_tcbn_ctthem_thuoc = 0, d_tcbn_ctthem_cls = 0, d_dichvu_tt = 0, d_dichvu_tt_bhchitra = 0, d_dichvu_tt_bnchitra = 0,d_cpvc= 0;
            //gam 16/08/2011
            string s_sothe_huong_cpvc = "", s_loaithe_bn = "";
            string s_vitri_xet_chiphivanchuyen = d.thetunguyen_vitri(1);
            DataRow r23;
            int iKytubegin_xet_chiphivanchuyen = 0, ikytuend_xet_chiphivanchuyen = 0;
            try
            {
                iKytubegin_xet_chiphivanchuyen = int.Parse(s_vitri_xet_chiphivanchuyen.Substring(0, 1));
                ikytuend_xet_chiphivanchuyen = int.Parse(s_vitri_xet_chiphivanchuyen.Substring(2, 1));

            }
            catch
            {
                iKytubegin_xet_chiphivanchuyen = 0;
                ikytuend_xet_chiphivanchuyen = 2;
            }
            //end gam
            if (bQuyenso)
            {
                r = d.getrowbyid(dtqs, "sohieu='" + kyhieu + "'");
                if (r != null)
                {
                    i_quyenso = int.Parse(r["id"].ToString());
                    sobienlai = int.Parse(r["soghi"].ToString());
                }
                else sobienlai = 0;// dtll.Rows.Count + 1;
            }
            else  i_quyenso = sobienlai = 0;
            string s_ngaynghi = "0";
            foreach (DataRow r1 in dt.Select("chon=true"))
            {
                r = ds1.Tables[0].NewRow();
                r["mabn"] = r1["mabn"].ToString();
                r["sophieu"] = r1["id"].ToString();
                ds1.Tables[0].Rows.Add(r);
            }

			for(int i=0;i<dr.Length;i++)
			{
				l_id=decimal.Parse(dr[i]["id"].ToString());
				if (o_id!=l_id)
				{
                    //kiem tra xem bn da di het phong kham chua

                    //
                    d_dichvu_tt = 0; d_dichvu_tt_bhchitra = 0;
					dr1=ds.Tables[0].Select("makho=0 and id='"+l_id+"'","sttt");
					if (dr1.Length>0) s_mabn=dr1[0]["losx"].ToString();
					else s_mabn="";
					r=d.getrowbyid(dt,"chon=true and id='"+l_id+"'");
					if (r!=null)
					{
                        if ((r["loaiba"].ToString() == "3" && i_loaiba != 2) || (r["loaiba"].ToString() == "4" && bCongkham_pl)) d_congkham = d.Congkham(i_nhom);
                        else d_congkham = 0;
						if (!kiemtra(ds.Tables[0].Select("soluong>0 and chon=false and id='"+l_id+"'","mabd,soluong"),r["mabn"].ToString(),r["hoten"].ToString().Trim())) return;
						if(bQuyenso)sobienlai+=1;
						d_thuoc=0;d_cls=0;maphu=int.Parse(r["madoituong"].ToString());d_bntra=0;d_bhyttra=0;
                        itable = d.tableid(s_mmyy, "bhytkb");
                        d.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
                        l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
                        s_chandoan = (r["chandoan"].ToString().Trim() != "") ? r["chandoan"].ToString() + "; " : dr[i]["tenhc"].ToString() + "; ";
                        s_icd = (r["maicd"].ToString().Trim() != "") ? r["maicd"].ToString() + "; " : dr[i]["tenkho"].ToString() + "; ";
                        if (i_loaiba == 2)
                        {
                            foreach (DataRow r1 in m.get_data("select chandoan,maicd, chandoanrv, maicdrv from " + user + ".benhanngtr where mavaovien=" + l_mavaovien + " and mavaovien<>0 ").Tables[0].Rows)
                            {
                                if (r1["chandoanrv"].ToString().Trim() != "")
                                {
                                    s_chandoan += (s_chandoan.IndexOf(r1["chandoanrv"].ToString().Trim() + ";") < 0) ? r1["chandoanrv"].ToString().Trim() + "; " : "";
                                    s_icd += s_icd.IndexOf(r1["maicdrv"].ToString().Trim() + ";") < 0 ? r1["maicdrv"].ToString().Trim() + "; " : "";
                                }
                                s_chandoan += (s_chandoan.IndexOf(r1["chandoan"].ToString().Trim() + ";") < 0) ? r1["chandoan"].ToString().Trim() + "; " : "";
                                s_icd += s_icd.IndexOf(r1["maicd"].ToString().Trim() + ";") < 0 ? r1["maicd"].ToString().Trim() + "; " : "";
                            }
                        }
                        if (s_chandoan.Trim() == "" || s_chandoan.Trim()==";")
                        {
                            get_chandoan_chinh(s_mmyy, int.Parse(r["loaiba"].ToString()), decimal.Parse(r["mavaovien"].ToString()), r["mabn"].ToString(), r["makp"].ToString(), ref s_chandoan, ref s_icd);
                        }
                        d.upd_bhytds(s_mmyy, r["mabn"].ToString(), r["hoten"].ToString().Trim() + s_hoten, r["namsinh"].ToString(), r["diachi"].ToString().Trim() + " " + r["tenpxa"].ToString().Trim() + " " + r["tenquan"].ToString().Trim() + " " + r["tentt"].ToString());// r["cholam"].ToString().Trim() + ";" + 
                        d.upd_bhytkb(s_mmyy, l_id, i_nhom, i_quyenso, sobienlai,( s_ngay.Length == 10 ? s_ngay + d.ngayhienhanh_server.Substring(10, 6) : s_ngay ), r["mabn"].ToString(), decimal.Parse(r["mavaovien"].ToString()), 
                            (r["maql"].ToString() == "0") ? decimal.Parse(dr[i]["tennhomcc"].ToString()) : decimal.Parse(r["maql"].ToString()),
                            r["makp"].ToString(), s_chandoan, s_icd, (dr[i]["tennguon"].ToString().Trim().Length == 4) ? dr[i]["tennguon"].ToString() 
                            : r["mabs"].ToString(), (r["sothe"].ToString() == "") ? r["sothengtr"].ToString() : r["sothe"].ToString(), maphu,
                            r["mabv"].ToString(), d_congkham, d_thuoc, d_cls, d_bntra, d_bhyttra, i_userid, (r["mangtr"].ToString() == "0" && !bduyetkhambenhchuyenvaongoaitru) ? int.Parse(r["loaiba"].ToString()) : 2,
                            int.Parse(r["traituyen"].ToString()),(bChuahoantatkham ? 1 : 0 ));//gam 07/11/2011
                        itable = d.tableid(s_mmyy, "bhytthuoc");
                        foreach (DataRow r1 in d.get_bhytthuoc(s_ngay, s_mmyy, ds.Tables[0].Select("chon=false and makho>0 and id='" + l_id+"'", "stt"), l_id, (i_loaiba == 2) ? 0 : i_madoituong).Rows)
                        {

                            d.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
                            //
                            DataRow dr11 = d.getrowbyid(dtbd, "id='" + r1["mabd"].ToString() +"'");
                            if (dr11 != null)
                            {
                                if (decimal.Parse(dr11["bhyt"].ToString()) != 100)
                                {
                                    d_tcbn_ctthem_thuoc += (decimal.Parse(dr11["bhyt"].ToString()) / 100) * decimal.Parse(r1["soluong"].ToString()) * ((bGiaban) ? decimal.Parse(r1["giaban"].ToString()) : decimal.Parse(r1["giamua"].ToString()));
                                    d_thuoc = d_thuoc + (decimal.Parse(dr11["bhyt"].ToString()) / 100) * decimal.Parse(r1["soluong"].ToString()) * ((bGiaban) ? decimal.Parse(r1["giaban"].ToString()) : decimal.Parse(r1["giamua"].ToString()));
                                }
                                else
                                {
                                    //
                                    d_thuoc = d_thuoc + decimal.Parse(r1["soluong"].ToString()) * ((bGiaban) ? decimal.Parse(r1["giaban"].ToString()) : decimal.Parse(r1["giamua"].ToString()));
                                }
                            }
                        }
                        itable = d.tableid(s_mmyy, "bhytcls");
						dr1=ds.Tables[0].Select("chon=false and makho=0 and soluong>0 and handung='"+r["makp"].ToString()+"' and losx='"+s_mabn+"' and id='"+l_id+"'","sttt");
						for(int j=0;j<dr1.Length;j++)
						{
                            s_sothe_huong_cpvc = ""; //gam 16/08/2011
                            d.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
                            //
                            //
                            DataRow dr12 = d.getrowbyid(dtvpin, "id='" + dr1[j]["mabd"].ToString()+"'");
                            if (dr12 != null)
                            {
                                 _sothe = (r["sothe"].ToString() == "") ? r["sothengtr"].ToString() : r["sothe"].ToString();
                                //gam 16/08/2011 chi phi van chuyen tinh theo the huong 100%
                                r23 = d.getrowbyid(dtvpin, "id='" + dr1[j]["mabd"].ToString() +"'"); 
                                if (r23 != null)
                                {
                                    s_sothe_huong_cpvc = r23["sothe"].ToString().Trim().Trim(',') + ",";
                                }
                           
                                if (_sothe != "" && s_sothe_huong_cpvc != "" && s_sothe_huong_cpvc.IndexOf(_sothe.Substring(iKytubegin_xet_chiphivanchuyen,ikytuend_xet_chiphivanchuyen)) > 0)
                                {
                                    d_cpvc += decimal.Parse(dr1[j]["sotien"].ToString());

                                }
                                //end gam
                                else if (decimal.Parse(dr12["bhyt"].ToString()) != 100)
                                {
                                    d_tcbn_ctthem_cls += ((100 - decimal.Parse(dr12["bhyt"].ToString())) / 100) * decimal.Parse(dr1[j]["sotien"].ToString());
                                    d_cls += (decimal.Parse(dr12["bhyt"].ToString()) / 100) * decimal.Parse(dr1[j]["sotien"].ToString()); 
                                }
                                else
                                {
                                    d_cls += decimal.Parse(dr1[j]["sotien"].ToString());
                                }
                                //
                                decimal chitra_dv_tt = (dr12["bhyt_tt"].ToString() == "") ? decimal.Parse(dr12["bhyt"].ToString()) : decimal.Parse(dr12["bhyt_tt"].ToString());
                                if (int.Parse(r["traituyen"].ToString()) != 0 && bBHYT_Traituyen_tinh_Tyle_khac && chitra_dv_tt > 0 && chitra_dv_tt < 100 && chitra_dv_tt < 100)
                                {
                                    d_dichvu_tt += decimal.Parse(dr1[j]["sotien"].ToString());
                                    d_dichvu_tt_bhchitra += decimal.Parse(dr1[j]["sotien"].ToString()) * chitra_dv_tt / 100;
                                }	
                                //
                            }
                            //		
                            
							d.upd_bhytcls(s_mmyy,l_id,j+1,int.Parse(dr1[j]["mabd"].ToString()),decimal.Parse(dr1[j]["soluong"].ToString()),decimal.Parse(dr1[j]["dongia"].ToString()),decimal.Parse(dr1[j]["sttt"].ToString()));
							d.execute_data_mmyy("update xxx.v_chidinh set paid=1 where paid=0 and id="+decimal.Parse(dr1[j]["sttt"].ToString())+" and mavp="+int.Parse(dr1[j]["mabd"].ToString()),s_tu,s_den,songayduyet);
                            
						}
						d_chiphi=d_thuoc+d_cls+d_congkham  ;d_bntra=0;d_bhyttra=d_chiphi ;
                       
                        if (_sothe != "" && int.Parse(r["traituyen"].ToString()) != 0 && !bTraituyen_bhtra)
                        {
                            chitra = iTraituyen;
                            d_bhyttra = ((d_chiphi - d_dichvu_tt) * chitra / 100 + d_dichvu_tt_bhchitra);
                            d_bntra = d_chiphi - d_bhyttra  + d_tcbn_ctthem_thuoc + d_tcbn_ctthem_cls;
                        }
                        else if (_sothe != "" && int.Parse(r["traituyen"].ToString()) != 0 && bTraituyen_bhtra)
                        {
                             ma = d.get_maphu_ngtru(_sothe, d_chiphi, i_nhom);
                             chitra = (ma == 1) ? 80 : (ma == 2) ? 95 : 100;
                             chitra = chitra * (decimal.Parse(iTraituyen.ToString()) / 100);
                            
                            //chitra = iTraituyen;
                            d_bhyttra = ((d_chiphi - d_dichvu_tt) * chitra / 100 + d_dichvu_tt_bhchitra);
                            d_bntra = d_chiphi - d_bhyttra + d_tcbn_ctthem_thuoc + d_tcbn_ctthem_cls;
                        }
                        else if (_sothe != "" && Bhyt_7cn!=0 && d_chiphi>Bhyt_7cn)
                        {
                            d_bhyttra = Bhyt_7cn;
                            d_bntra = d_chiphi - d_bhyttra;
                        }
						else if (r["mien"].ToString()=="0")
						{
							d_bntra=d_thuoc+d_cls+d_congkham ;
							d_bhyttra = 0;
						}
                        else if (maphu == 1 && _sothe != "")
                        {
                            ma = d.get_maphu_ngtru(_sothe, d_chiphi, i_nhom);
                            if (ma !=0)
                            {
                                chitra = (ma == 1) ? 80 : 95;
                                d_bhyttra = (d_chiphi * chitra / 100) ;
                                d_bntra = d_chiphi - d_bhyttra + d_tcbn_ctthem_thuoc + d_tcbn_ctthem_cls;
                            }
                            if (lTraituyen != 0 && d_bhyttra > lTraituyen && int.Parse(r["traituyen"].ToString()) != 0)
                            {
                                d_bhyttra = lTraituyen ;
                                d_bntra = d_chiphi - lTraituyen;
                            }
                        }
                        decimal amaql = (r["maql"].ToString() == "0") ? decimal.Parse(dr[i]["tennhomcc"].ToString()) : decimal.Parse(r["maql"].ToString());
                       // d.execute_data("update " + yyy + ".bhytkb set thuoc=" + (d_thuoc + d_tcbn_ctthem_thuoc).ToString() + ",cls=" + (d_cls + d_tcbn_ctthem_cls).ToString() + ",congkham=" + d_congkham + ",bntra=" + d_bntra + ",bhyttra=" + d_bhyttra + ",maql=" + amaql+ " where id=" + l_id);
                        d.execute_data("update " + yyy + ".bhytkb set thuoc=" + (d_thuoc + d_tcbn_ctthem_thuoc).ToString() + ",cls=" + (d_cls + d_tcbn_ctthem_cls + d_cpvc).ToString() + 
                            ",congkham=" + d_congkham + ",bntra=" + d_bntra + ",bhyttra=" +( d_bhyttra +d_cpvc)+ ",maql=" + amaql + ",ngaynghi="+r["ngaynghi"].ToString()+" where id=" + l_id);
						d.execute_data_mmyy("update xxx.d_thuocbhytll set done=1 where id="+l_id,s_tu,s_den,songayduyet);
                        d.updrec_bhytll(dtll, l_id, r["mabn"].ToString(), decimal.Parse(r["mavaovien"].ToString()), (r["maql"].ToString() == "0") ? decimal.Parse(dr[i]["tennhomcc"].ToString()) : decimal.Parse(r["maql"].ToString()), r["hoten"].ToString(), r["namsinh"].ToString(), s_ngay, r["diachi"].ToString().Trim() + " " + r["tenpxa"].ToString().Trim() + " " + r["tenquan"].ToString().Trim() + " " + r["tentt"].ToString(), r["makp"].ToString(), s_chandoan, s_icd, (dr[i]["tennguon"].ToString().Trim().Length == 4) ? dr[i]["tennguon"].ToString() : r["mabs"].ToString(), (r["sothe"].ToString() == "") ? r["sothengtr"].ToString() : r["sothe"].ToString(), maphu, r["mabv"].ToString(), sobienlai, i_quyenso, d_congkham, d_thuoc, d_cls + d_tcbn_ctthem_cls, d_thuoc + d_tcbn_ctthem_thuoc, d_bntra, d_bhyttra, "", "", "", "", "", int.Parse(r["traituyen"].ToString()));//(r["chandoan"].ToString().Trim() != "") ? r["chandoan"].ToString() : dr[i]["tenhc"].ToString(), (r["maicd"].ToString().Trim() != "") ? r["maicd"].ToString() : dr[i]["tenkho"].ToString()
					}
					o_id=l_id;
                    if (prn && r!=null)
                    {
                        if (chkChiphi.Checked)
                        {
                            int d_toaso = d.get_sotoa_bhyt(s_mmyy, l_id, s_ngay, maphu);
                            d.execute_data("update " + yyy + ".bhytkb set sotoa=" + d_toaso + " where id=" + l_id);
                            d.delrec(ds1.Tables[0], "sophieu='" + l_id+"'");
                            if (ds1.Tables[0].Select("mabn='" + r["mabn"].ToString() + "'", "maql desc").Length == 0)
                                get_data_printer(r["mabn"].ToString(), decimal.Parse(r["maql"].ToString()), s_chandoan, d_congkham.ToString(), r["hoten"].ToString(), r["sothe"].ToString(), maphu, "", "", "", "", s_icd, r["makp"].ToString(), r["mabs"].ToString(), int.Parse(r["traituyen"].ToString()), d_toaso.ToString());
                        }
                        else
                        {
                            stttoa=printer(l_id, d_bntra, d_bhyttra, r["mabn"].ToString(), r["hoten"].ToString(), r["namsinh"].ToString(), r["diachi"].ToString().Trim() + " " + r["tenpxa"].ToString().Trim() + " " + r["tenquan"].ToString().Trim() + " " + r["tentt"].ToString(), (r["sothe"].ToString() == "") ? r["sothengtr"].ToString() : r["sothe"].ToString(), s_chandoan + "^" +s_icd , d_bntra + d_bhyttra, d_congkham, sobienlai, r["mabs"].ToString(), int.Parse(r["traituyen"].ToString()));//r["cholam"].ToString().Trim() + ";" +
                            if (chkDonChiphi.Checked)
                            {
                                d.delrec(ds1.Tables[0], "sophieu='" + l_id+"'");
                                if (ds1.Tables[0].Select("mabn='" + r["mabn"].ToString() + "'", "maql desc").Length == 0)
                                    get_data_printer(r["mabn"].ToString(), decimal.Parse(r["maql"].ToString()),s_chandoan, d_congkham.ToString(), r["hoten"].ToString(), r["sothe"].ToString(), maphu, "", "", "", "", s_icd, r["makp"].ToString(), r["mabs"].ToString(), int.Parse(r["traituyen"].ToString()), stttoa);
                            }
                        }
                    }
				}				
			}
		}

		private void tim_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tim_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tim)
			{
				refresh_list(tim.Text.Trim());
			}
		}

		private void tim2_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tim2)
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid2.DataSource];
				DataView dv=(DataView)cm.List;
				if (tim2.Text!="")
					dv.RowFilter="ten like '%"+tim2.Text.Trim()+"%' or hoten like '%"+tim2.Text.Trim()+"%'";
				else
					dv.RowFilter="";
			}
		}

		private void dataGrid2_Click(object sender, System.EventArgs e)
		{
			try
			{
				Point pt = this.dataGrid1.PointToClient(Control.MousePosition);
				DataGrid.HitTestInfo hti = this.dataGrid1.HitTest(pt);
				BindingManagerBase bmb = this.BindingContext[this.dataGrid2.DataSource, this.dataGrid2.DataMember];
				if(afterCurrentCellChanged && hti.Row < bmb.Count && hti.Type == DataGrid.HitTestType.Cell &&  hti.Column == checkCol )
				{	
					this.dataGrid2[hti.Row, checkCol] = !(bool)this.dataGrid2[hti.Row, checkCol];
					RefreshRow(hti.Row);
				}
				afterCurrentCellChanged = false;
			}
			catch{}
		}

		private void dataGrid2_CurrentCellChanged(object sender, System.EventArgs e)
		{
			if((bool)this.dataGrid2[this.dataGrid2.CurrentRowIndex, checkCol]) this.dataGrid2.CurrentCell = new DataGridCell(this.dataGrid2.CurrentRowIndex, checkCol);
			afterCurrentCellChanged = true;
		}

		private void luu_in(bool prn)
		{
            if (bKhoaso)
            {
                MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng") + " " + s_mmyy.Substring(0, 2) + " " + lan.Change_language_MessageText("năm") + " " + s_mmyy.Substring(2, 2) + " " +
                lan.Change_language_MessageText("đã khóa !") + "\n" + lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"), d.Msg);
                return;
            }
            //
            if (bPhongkhamduyetrieng)
            {
                string s_mabn_chuaduyet = check_mabn_chuaduyet();
                if (s_mabn_chuaduyet.Trim() != "")
                {
                    DialogResult dlg = MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân có mã số '")+" " + s_mabn_chuaduyet + " "+lan.Change_language_MessageText("còn sót toa chưa đánh dấu duyệt.")+"\n"+lan.Change_language_MessageText("Bạn có muốn ngưng duyệt và đánh dấu lại để duyệt không ?"), lan.Change_language_MessageText("Duyệt thuốc"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (dlg == DialogResult.Yes)
                        return;
                }
            }
            //
            string _mabn = "", _xutri = "";
            bool bln_chuakham = false, bln_chuakhamxong_hen = false;
            if ((bDuyettoa_ketthuc || (bkhongChoDuyetToaBNHen_E8 && i_madoituong==1)) && i_loaiba == 3)
            {
                foreach (DataRow r in dt.Select("chon=true and madoituong=1"))
                {
                    sql = "select b.xutri from xxx.benhanpk a left join xxx.xutrikbct b on a.maql=b.maql left join xxx.tiepdon c on a.maql=c.maql ";
                    sql += " where a.mabn='" + r["mabn"].ToString() + "' and " + m.for_ngay("a.ngay",stime) + " between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";//to_char(a.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                    sql += " and a.madoituong=" + int.Parse(r["madoituong"].ToString());
                    sql += " order by a.maql desc";//and c.done='x' 
                    _xutri = "";
                    foreach (DataRow r1 in d.get_data_mmyy(sql,s_tu,s_den,songayduyet).Tables[0].Rows)
                    {
                        _xutri = r1["xutri"].ToString().Trim();
                        
                        if (bkhongChoDuyetToaBNHen_E8)
                        {
                            if (_xutri.IndexOf("03,") != -1 || _xutri.Trim() == "") { _mabn += r["mabn"].ToString() + " " + r["hoten"].ToString() + "\n"; bln_chuakhamxong_hen = true; break; }
                        }
                        else if (_xutri.IndexOf("08,") != -1 || _xutri.Trim() == "") { _mabn += r["mabn"].ToString() + " " + r["hoten"].ToString() + "\n"; break; }
                        break;
                    }
                    //if (_xutri.IndexOf("08,") != -1 || _xutri.Trim() == "") _mabn += r["mabn"].ToString() + " " + r["hoten"].ToString() + "\n";
                }
                if (_mabn.Trim() == "")
                {
                    foreach (DataRow r in dt.Select("chon=true and madoituong=1"))
                    {
                        sql = "select b.maql, c.tenkp||'-'||a.makp as tenkp ";
                        sql += " from xxx.tiepdon a left join xxx.benhanpk b on a.mavaovien=b.mavaovien and a.makp=b.makp";                        
                        sql += " inner join " + user + ".btdkp_bv c on a.makp=c.makp ";
                        sql += " where a.mabn='" + r["mabn"].ToString() + "' and " + m.for_ngay("a.ngay", stime) + " between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";//to_char(a.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                        sql += " and a.madoituong=" + int.Parse(r["madoituong"].ToString());
                        sql += " and a.noitiepdon in(0,1,5) ";
                        sql += " order by a.maql desc";
                        _xutri = "";
                        foreach (DataRow r1 in d.get_data_mmyy(sql, s_tu, s_den, songayduyet).Tables[0].Rows)
                        {
                            _xutri = r1["maql"].ToString().Trim();
                            if (_xutri.Trim() == "") { _mabn += r["mabn"].ToString() + " " + r["hoten"].ToString() + " [" + r1["tenkp"].ToString() + "]" + "\n"; break; }
                        }
                        bln_chuakham = true;
                    }
                }
            }
            if (_mabn != "")
            {
                if (bln_chuakhamxong_hen == false)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Những người bệnh sau chưa kết thúc khám bệnh") + " \n" + _mabn, d.Msg);
                    if (bln_chuakham)
                    {
                        DialogResult dlg = MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này còn phòng khám chưa khám, Bạn có đồng ý duyệt luôn không?") + "\n" + _mabn, "Duyet toa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (dlg == DialogResult.No) return;
                    }
                    else return;
                }
                else
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đã hẹn, lần sau tái khám duyệt chi phí luôn.") + " [Option E8] " + "\n" + _mabn, "Duyet toa", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                
            }
			Cursor=Cursors.WaitCursor;
			CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid1.DataSource];
			DataView dv=(DataView)cm.List;
			dv.RowFilter="";
			cm= (CurrencyManager)BindingContext[dataGrid2.DataSource];
			dv=(DataView)cm.List;
			dv.RowFilter="";
            if (checkBox1.Checked || checkBox2.Checked) upd_data_hoadon_ck(prn);
			else
			{
				if (bHoadon) upd_data_hoadon(prn);
				else upd_data(prn);
			}
            if (checkBox1.Checked) load_ck();
            else
            {
                if (chkList.Checked) load_grid("");
                else
                {
                    ds.Clear();
                    m.delrec(dt, "chon=true");
                }
            }
			bOk=true;
			Cursor=Cursors.Default;
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			luu_in(true);
            lblTongtien.Text = "";
		}

		private string  printer(decimal id,decimal bntra,decimal bhyttra,string mabn,string hoten,string namsinh,string diachi,string sothe,string chandoan,decimal chiphi,decimal congkham,decimal sobienlai,string mabs,int traituyen)
		{
			int irec=0,d_toaso=d.get_sotoa_bhyt(s_mmyy,id,s_ngay,i_madoituong);
			l_maql=0;
			string s_tenbv="",s_tentt="",s_tungay="",s_denngay="",tenbs="";
			d.execute_data("update "+yyy+".bhytkb set sotoa="+d_toaso+" where id="+id);
			d.updrec_bhytll(dtll,l_id,d_toaso);
            string cholam = "",sngaysinh="";
            foreach (DataRow r1 in d.get_data("select cholam,ngaysinh from " + user + ".btdbn where mabn='" + mabn + "'").Tables[0].Rows)
            {
                cholam = r1["cholam"].ToString();
                sngaysinh = r1["ngaysinh"].ToString();
            }
			int iTuoi=(namsinh!="")?DateTime.Now.Year-int.Parse(namsinh):0;
			sql="select a.maql,to_char(b.tungay,'dd/mm/yyyy') as tungay,to_char(b.denngay,'dd/mm/yyyy') as denngay,c.hoten ";
            sql += "from " + yyy + ".bhytkb a," + xxx + ".bhyt b," + user + ".dmbs c where a.maql=b.maql and a.mabs=c.ma and a.id=" + id;
            //sql += "from " + yyy + ".bhytkb a," + user + ".vbhyt_" + s_idcomputer + " b," + user + ".dmbs c where a.maql=b.maql and a.mabs=c.ma and a.id=" + id;
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				s_tungay=r["tungay"].ToString();s_denngay=r["denngay"].ToString();tenbs=r["hoten"].ToString();
				l_maql=decimal.Parse(r["maql"].ToString());
			}            
            if (l_maql == 0 && songayduyet != 0)
            {
            	sql="select a.maql,to_char(b.tungay,'dd/mm/yyyy') as tungay,to_char(b.denngay,'dd/mm/yyyy') as denngay,c.hoten ";
                sql += "from " + yyy + ".bhytkb a," + user+m.mmyy(s_tu) + ".bhyt b," + user + ".dmbs c where a.maql=b.maql and a.mabs=c.ma and a.id=" + id;
                //sql += "from " + yyy + ".bhytkb a," + user + ".vbhyt_" + s_idcomputer + " b," + user + ".dmbs c where a.maql=b.maql and a.mabs=c.ma and a.id=" + id;
			    foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			    {
				    s_tungay=r["tungay"].ToString();s_denngay=r["denngay"].ToString();tenbs=r["hoten"].ToString();
				    l_maql=decimal.Parse(r["maql"].ToString());
			    }
            }
			if (l_maql!=0)
			{
				foreach(DataRow r3 in d.get_data_mmyy("select b.tenbv from xxx.noigioithieu a,"+user+".dstt b where a.mabv=b.mabv and a.maql="+l_maql,s_tu,s_den,songayduyet).Tables[0].Rows)
					s_tentt=r3["tenbv"].ToString().Trim();
                foreach (DataRow r3 in d.get_data_mmyy("select b.tenbv, a.mabv from xxx.bhyt a," + user + ".dmnoicapbhyt b where a.mabv=b.mabv and a.maql=" + l_maql, s_tu, s_den, songayduyet).Tables[0].Rows) 
					s_tenbv=r3["tenbv"].ToString().Trim()+"^"+r3["mabv"].ToString().Trim();
			}
			DataSet dstmp,ds1;
			if (d.bInBHYT_nhomvp(i_nhom))
			{
                sql = "select " + d_toaso + " as sotoa,'" + s_tungay + "' as tungay,'" + s_denngay + "' as denngay,a.stt,a.sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,e.ten as tenkho,c.ten as tennguon,'' as tennhomcc,t.handung,t.losx,a.soluong,";
                if (bGiaban && i_madoituong != 1) sql += "b.giaban as dongia,a.soluong*b.giaban as sotien,";
                else
                {
                    if (bGia_bh_quydinh && bLaygiamua_khi_giabh_0_giabh_nho_giamua) sql += "(case when a.gia_bh=0 or t.giamua<a.gia_bh then t.giamua else a.gia_bh end) as giaban,(case when a.gia_bh=0 or t.giamua<a.gia_bh then t.giamua else a.gia_bh end)*a.soluong as sotien,";
                    else if (bGia_bh_quydinh && bLaygiamua_khi_giabh_0_giabh_nho_giamua == false) sql += "a.gia_bh as giaban,a.gia_bh*a.soluong as sotien,";
                    else sql += "t.giamua as giaban,a.soluong*t.giamua as sotien,";
                    //sql += "t.giamua as dongia,a.soluong*t.giamua as sotien,";
                }

				sql+="a.soluong*t.giamua as sotienmua,t.giaban,a.cachdung,a.makho,t.manguon,t.nhomcc,h.stt as nhomin,h.ten as tennhomin,g.id as manhom ";
				if (i_bhyt_inrieng==0) sql+=",0 as loaidv";
				else sql+=",case when h.ma="+i_bhyt_inrieng+" then 1 else 0 end as loaidv,"+traituyen+" as traituyen";
                sql += ",i.ten as hangsx, j.ten as nuocsx ";
                sql += " from " + yyy + ".bhytthuoc a," + user + ".d_dmbd b," + user + ".d_dmnguon c," + user + ".d_dmnx d," + user + ".d_dmkho e, " + user + ".d_dmnhom f, " + user + ".d_nhomin g," + user + ".v_nhomvp h," + user + s_mmyy + ".d_theodoi t";
                sql += ", " + user + ".d_dmhang i, " + user + ".d_dmnuoc j ";
				sql+=" where a.sttt=t.id and a.mabd=b.id and t.manguon=c.id and t.nhomcc=d.id and a.makho=e.id and b.manhom=f.id and f.nhomin=g.id and f.nhomvp=h.ma";
                sql += " and b.mahang=i.id(+) and b.manuoc=j.id(+)";
                sql += " and a.id=" + id;// +" order by h.stt,a.stt";			
                sql += " union all ";
                sql += "select " + d_toaso + " as sotoa,'" + s_tungay + "' as tungay,'" + s_denngay + "' as denngay,a.stt,0 as sttt,a.mavp as mabd,b.ma,b.ten,' ' as tenhc,b.dvt as dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,' ' as handung,' ' as losx,a.soluong,a.dongia,a.soluong*a.dongia as sotien,a.soluong*a.dongia as sotienmua,a.dongia as giaban,' ' as cachdung,0 as makho,0 as manguon,0 as nhomcc,d.stt as nhomin,d.ten as tennhomin,0 as manhom ";
				if (i_bhyt_inrieng==0) sql+=",0 as loaidv";
                else sql += ",case when d.ma=" + i_bhyt_inrieng + " then 1 else 0 end as loaidv," + traituyen + " as traituyen";
                sql += ", null as hangsx, null as nuocsx ";
                sql += " from " + yyy + ".bhytcls a," + user + ".v_giavp b," + user + ".v_loaivp c," + user + ".v_nhomvp d where a.mavp=b.id and b.id_loai=c.id and c.id_nhom=d.ma and a.id=" + id ;// +" order by d.stt,a.stt";
			}
			else
			{
                sql = "select " + d_toaso + " as sotoa, '" + s_tungay + "' as tungay,'" + s_denngay + "' as denngay,a.stt,a.sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,e.ten as tenkho,c.ten as tennguon,'' as tennhomcc,t.handung,t.losx,a.soluong,";
                if (bGiaban) { sql += "b.giaban as dongia,a.soluong*b.giaban as sotien,"; }
                else if (bGia_bh_quydinh)
                {
                    sql += "a.gia_bh as dongia, a.gia_bh*a.soluong as sotien,";//gam 10/10/2011
                }
                else { sql += "t.giamua as dongia,a.soluong*t.giamua as sotien,"; }
                sql += "a.soluong*t.giamua as sotienmua,t.giaban,a.cachdung,a.makho,t.manguon,t.nhomcc,case when b.manhom=9 then f.nhomin else 4 end as nhomin,case when b.manhom=9 then f.ten else g.ten end as tennhomin,1 as loaidv,g.id as manhom," + traituyen + " as traituyen";
                sql += ",i.ten as hangsx, j.ten as nuocsx ";
                sql += " from " + yyy + ".bhytthuoc a," + user + ".d_dmbd b," + user + ".d_dmnguon c," + user + ".d_dmnx d," + user + ".d_dmkho e, " + user + ".d_dmnhom f, " + user + ".d_nhomin g," + user + s_mmyy + ".d_theodoi t";
                sql += ", " + user + ".d_dmhang i, " + user + ".d_dmnuoc j ";
				sql+=" where a.sttt=t.id and a.mabd=b.id and t.manguon=c.id and t.nhomcc=d.id and a.makho=e.id and b.manhom=f.id and f.nhomin=g.id ";
                sql += " and b.mahang=i.id(+) and b.manuoc=j.id(+)";
                sql += " and a.id=" + id;// +" order by a.stt";			
                sql += " union all ";
                sql += "select " + d_toaso + " as sotoa,'" + s_tungay + "' as tungay,'" + s_denngay + "' as denngay,a.stt,0 as sttt,a.mavp as mabd,b.ma,b.ten,' ' as tenhc,b.dvt as dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,' ' as handung,' ' as losx,a.soluong,a.dongia,a.soluong*a.dongia as sotien,a.soluong*a.dongia as sotienmua,a.dongia as giaban,' ' as cachdung,0 as makho,0 as manguon,0 as nhomcc,4 as nhomin,' ' as tennhomin, 2 as loaidv,0 as manhom," + traituyen + " as traituyen";
                sql += ", null as hangsx, null as nuocsx ";
                sql += " from " + yyy + ".bhytcls a," + user + ".v_giavp b where a.mavp=b.id and a.id=" + id;// +" order by a.stt";
			}
            dstmp = d.get_data(sql);
            ds1 = dstmp.Copy();
            dstmp.Clear();
            dstmp.Merge(ds1.Tables[0].Select("true", "nhomin,stt"));
            irec = dstmp.Tables[0].Select("sttt<>0").Length;
            DataColumn dc = new DataColumn("Image", typeof(byte[]));
            dstmp.Tables[0].Columns.Add(dc);

			foreach(DataRow r3 in dstmp.Tables[0].Rows) 
			{
				r3["tennhomcc"]=s_tentt;
				r3["tennguon"]=s_tenbv;
			}

            //thêm số tháng
            if (iTuoi <= 6 && sngaysinh != "")
            {
                dstmp.Tables[0].Columns.Add("thangtuoi", typeof(String));
                long songay = m.songay(m.StringToDateTime(s_ngay), DateTime.Parse(sngaysinh), 0);
                long sothang = songay / 30;
                foreach (DataRow r in dstmp.Tables[0].Rows) r["thangtuoi"] = sothang.ToString();
            } 
            if (File.Exists("..\\..\\..\\chuky\\" + mabs + ".bmp"))
            {
                fstr = new FileStream("..\\..\\..\\chuky\\" + mabs + ".bmp", FileMode.Open, FileAccess.Read);
                image = new byte[fstr.Length];
                fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                fstr.Close();
                foreach (DataRow r in dstmp.Tables[0].Rows) r["Image"] = image;
            }

            if (chkXML.Checked)
            {
                if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
                dstmp.WriteXml("..\\xml\\bhyt.xml", XmlWriteMode.WriteSchema);
            }
			if (chkXem.Checked)
			{
                frmReport f = new frmReport(d, dstmp.Tables[0], i_userid , "d_bhyt.rpt", hoten + "   (" + mabn + ")", (iTuoi == 0) ? "" : iTuoi.ToString(), diachi.Trim() + "^" + cholam.Trim(), sothe , chandoan, irec.ToString(), chiphi.ToString(), bntra.ToString(), bhyttra.ToString(), tenbs, d_toaso.ToString() + "/" + sobienlai.ToString(), congkham.ToString(), soban.Value);
				f.ShowDialog();
			}
			else
			{
				ReportDocument oRpt=new ReportDocument();
				oRpt.Load("..\\..\\..\\report\\d_bhyt.rpt",OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(dstmp.Tables[0]);
				oRpt.DataDefinition.FormulaFields["soyte"].Text="'"+d.Syte+"'";
				oRpt.DataDefinition.FormulaFields["benhvien"].Text="'"+d.Tenbv+"'";
				oRpt.DataDefinition.FormulaFields["c1"].Text="'"+hoten+"   ("+mabn+")"+"'";
				oRpt.DataDefinition.FormulaFields["c2"].Text=(iTuoi==0)?"'"+iTuoi.ToString()+"'":"";
				oRpt.DataDefinition.FormulaFields["c3"].Text="'"+diachi.Trim()+"^"+cholam.Trim()+"'";
				oRpt.DataDefinition.FormulaFields["c4"].Text="'"+sothe+"'";
				oRpt.DataDefinition.FormulaFields["c5"].Text="'"+chandoan+"'";
				oRpt.DataDefinition.FormulaFields["c6"].Text="'"+irec.ToString()+"'";
				oRpt.DataDefinition.FormulaFields["c7"].Text="'"+chiphi.ToString()+"'";
				oRpt.DataDefinition.FormulaFields["c8"].Text="'"+bntra.ToString()+"'";
				oRpt.DataDefinition.FormulaFields["c9"].Text="'"+bhyttra.ToString()+"'";
				oRpt.DataDefinition.FormulaFields["c10"].Text="'"+tenbs+"'";
				oRpt.DataDefinition.FormulaFields["giamdoc"].Text="'"+d_toaso.ToString()+"/"+sobienlai.ToString()+"'";
				oRpt.DataDefinition.FormulaFields["phutrach"].Text="'"+d.Phutrach(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["thongke"].Text="'"+congkham.ToString()+"'";
				oRpt.DataDefinition.FormulaFields["ketoan"].Text="'"+d.Ketoan(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["thukho"].Text="'"+d.Thukho(i_nhom)+"'";
				oRpt.PrintToPrinter(Convert.ToInt32(soban.Value),false,0,0);
                oRpt.Close(); oRpt.Dispose();
			}
            return d_toaso.ToString();
		}

		private void frmDuyetbhyt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F9) butIn_Click(sender,e);
			else if (e.KeyCode==Keys.F5) butLuu_Click(sender,e);
		}

		private void load_ck()
		{
            sql = "select distinct d.mabn,d.mavaovien,d.maql,coalesce(c.sothe,'') as sothe,coalesce(c.traituyen,0) as traituyen,b.hoten,b.namsinh,trim(b.sonha)||' '||b.thon as diachi,b.cholam,x.tentt,y.tenquan,z.tenpxa,";
            sql += " c.mabv,d.makp,f.tenkp,d.chandoan,d.maicd,d.mabs,d.madoituong,e.mien,case when e.field_gia is null then 'gia_th' else e.field_gia end as field_gia,to_number('3') as loaiba,to_number('0') as ngaynghi";
			sql+=" from "+user+".btdbn b inner join "+xxx+".benhanpk d on b.mabn=d.mabn left join "+xxx+".bhyt c on d.maql=c.maql inner join "+user+".doituong e on d.madoituong=e.madoituong";
            sql+=" left join " + user + ".btdkp_bv f on d.makp=f.makp ";
            sql += " left join " + user + ".btdtt x on b.matt=x.matt ";
            sql += " left join " + user + ".btdquan y on b.maqu=y.maqu ";
            sql += " left join " + user + ".btdpxa z on b.maphuongxa=z.maphuongxa ";
            sql += " left join " + xxx + ".xutrikbct u on d.maql=u.maql ";
			sql+=" where to_char(d.ngay,'dd/mm/yyyy')='"+s_ngay+"'";
            sql += " and u.maql is not null  ";
            if (bBhyt_tra_1_congkham) sql += " and u.xutri not like '%08,%' and u.xutri not like '%02,%' and u.xutri not like '%05,%' and u.xutri not like '%04,%'";
			if (i_madoituong==1) sql+=" and d.madoituong=1";
			else sql+=" and d.madoituong<>1";
            sql += " and d.mabn not in (select mabn from " + user + s_mmyy + ".bhytkb where to_char(ngay,'dd/mm/yyyy')='" + s_ngay + "')";
            sql += " union all ";//union vơi phòng lưu lấy ds phòng lưu ko có phát sinh chi phí
            sql += "select distinct d.mabn,d.mavaovien,d.maql,coalesce(c.sothe,'') as sothe,coalesce(c.traituyen,0) as traituyen,b.hoten,b.namsinh,trim(b.sonha)||' '||b.thon as diachi,b.cholam,x.tentt,y.tenquan,z.tenpxa,";
            sql += " c.mabv,d.makp,f.tenkp,d.chandoan,d.maicd,d.mabs,d.madoituong,e.mien,case when e.field_gia is null then 'gia_th' else e.field_gia end as field_gia,to_number('4') as loaiba,to_number('0') as ngaynghi";
            sql += " from " + user + ".btdbn b inner join " + xxx + ".benhancc d on b.mabn=d.mabn left join " + xxx + ".bhyt c on d.maql=c.maql inner join " + user + ".doituong e on d.madoituong=e.madoituong";
            sql += " left join " + user + ".btdkp_bv f on d.makp=f.makp ";
            sql += " left join " + user + ".btdtt x on b.matt=x.matt ";
            sql += " left join " + user + ".btdquan y on b.maqu=y.maqu ";
            sql += " left join " + user + ".btdpxa z on b.maphuongxa=z.maphuongxa ";
            sql += " left join " + xxx + ".xutrikbct u on d.maql=u.maql ";
            sql += " where to_char(d.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
            sql += " and u.maql is not null  ";
            if (bBhyt_tra_1_congkham) sql += " and u.xutri not like '%08,%' and u.xutri not like '%02,%' and u.xutri not like '%05,%' and u.xutri not like '%04,%'";
            if (i_madoituong == 1) sql += " and d.madoituong=1";
            else sql += " and d.madoituong<>1";
            sql += " and d.mabn not in (select mabn from " + user + s_mmyy + ".bhytkb where to_char(ngay,'dd/mm/yyyy')='" + s_ngay + "')";
			dt=d.get_data(sql).Tables[0];
            DataColumn dc = new DataColumn("id", typeof(decimal));
            dt.Columns.Add(dc);
            DataTable dt1 = dt.Copy();
            string s_mavv = "";
            int ij=0;
            foreach (DataRow r in dt1.Rows)
            {
                
                if (bBhyt_tra_1_congkham && s_mavv != r["mavaovien"].ToString())
                {
                    s_mavv = r["mavaovien"].ToString();
                    r["id"] = d.get_id_bhyt;
                    dt.Rows[ij]["id"] = d.get_id_bhyt; 
                }
                else if (bBhyt_tra_1_congkham && s_mavv == r["mavaovien"].ToString())
                {
                    dt.Rows.Remove(dt.Rows[ij]);
                    dt.AcceptChanges();
                    ij = ij - 1;
                }
                else dt.Rows[ij]["id"] = d.get_id_bhyt; 
                ij += 1;
            }
            dt1.Dispose();//
            dt.AcceptChanges();
			dataGrid1.DataSource=dt;
			if (!bSkip) AddGridTableStyle();
			bSkip=true;
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember]; 
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			dt.Columns.Add("Chon",typeof(bool));
			foreach (DataRow row in dt.Rows) row["chon"]=false;
			butLuu.Enabled=dt.Rows.Count!=0;
			butIn.Enabled=butLuu.Enabled;
			dataGrid1.Focus();
			i_row=dataGrid1.CurrentRowIndex;
		}

		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			if (checkBox1.Checked) load_ck();
			else load_grid("");
		}

		private void upd_data_hoadon_ck(bool prn)
		{
			DataRow r;
			DataRow [] dr=dt.Select("chon=true","id");
			string kyhieu=d.Thongso("c00").ToString();
			DataTable dtqs=d.get_data("select * from "+user+".v_quyenso").Tables[0];
			int i_quyenso=0;
			int maphu,ma,chitra;
			decimal d_thuoc,d_bntra=0,d_bhyttra=0,d_cls,d_congkham=0,d_chiphi=0;
            string stttoa = "";
            if (bQuyenso)
            {
                r = d.getrowbyid(dtqs, "sohieu='" + kyhieu + "'");
                if (r != null)
                {
                    i_quyenso = int.Parse(r["id"].ToString());
                    sobienlai = int.Parse(r["soghi"].ToString());
                }
                else sobienlai = dtll.Rows.Count + 1;
            }
            else
            {
                i_quyenso = 0; sobienlai = 0;
            }
			for(int i=0;i<dr.Length;i++)
			{
				l_id=decimal.Parse(dr[i]["id"].ToString());
				r=d.getrowbyid(dtmavp,"id="+i_mavp);
				if (r!=null)
				{
					if(bQuyenso)sobienlai+=1;
					d_thuoc=0;d_cls=0;maphu=int.Parse(dr[i]["madoituong"].ToString());d_bntra=0;d_bhyttra=0;
                    itable = d.tableid(s_mmyy, "bhytkb");
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
                    d.upd_bhytds(s_mmyy, dr[i]["mabn"].ToString(), dr[i]["hoten"].ToString().Trim(), dr[i]["namsinh"].ToString(), dr[i]["diachi"].ToString().Trim() + " " + dr[i]["tenpxa"].ToString().Trim() + " " + dr[i]["tenquan"].ToString().Trim() + " " + dr[i]["tentt"].ToString());//dr[i]["cholam"].ToString().Trim()+";"+
                    d.upd_bhytkb(s_mmyy, l_id, i_nhom, i_quyenso, sobienlai, s_ngay, dr[i]["mabn"].ToString(), decimal.Parse(dr[i]["mavaovien"].ToString()), decimal.Parse(dr[i]["maql"].ToString()), dr[i]["makp"].ToString(), dr[i]["chandoan"].ToString(), dr[i]["maicd"].ToString(), dr[i]["mabs"].ToString(), dr[i]["sothe"].ToString(), maphu, dr[i]["mabv"].ToString(), d_congkham, d_thuoc, d_cls, d_bntra, d_bhyttra, i_userid, i_loaiba, int.Parse(dr[i]["traituyen"].ToString()), (bChuahoantatkham ? 1 : 0));
                    itable = d.tableid(s_mmyy, "bhytcls");
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
					d_cls+=decimal.Parse(r[dr[i]["field_gia"].ToString()].ToString());
					d.upd_bhytcls(s_mmyy,l_id,1,i_mavp,1,Convert.ToInt64(d_cls),0);
                    d_chiphi = d_thuoc + d_cls + d_congkham; d_bntra = 0; d_bhyttra = d_chiphi;
                    if (dr[i]["sothe"].ToString() != "" && int.Parse(dr[i]["traituyen"].ToString()) != 0)
                    {
                        chitra = iTraituyen;
                        d_bhyttra = d_chiphi * chitra / 100;
                        d_bntra = d_chiphi - d_bhyttra;
                    }
					else if (dr[i]["mien"].ToString()=="0")
					{
						d_bntra=d_thuoc+d_cls+d_congkham;
						d_bhyttra=0;
					}
                    else if (maphu == 1 && dr[i]["sothe"].ToString() != "")
                    {
                        ma = d.get_maphu_ngtru(dr[i]["sothe"].ToString(), d_chiphi, i_nhom);
                        if (ma !=0)
                        {
                            chitra = (ma == 1) ? 80 : 95;
                            d_bhyttra = d_chiphi * chitra / 100;
                            d_bntra = d_chiphi - d_bhyttra;
                        }
                        if (lTraituyen != 0 && d_bhyttra > lTraituyen && int.Parse(r["traituyen"].ToString()) != 0)
                        {
                            d_bhyttra = lTraituyen;
                            d_bntra = d_chiphi - lTraituyen;
                        }
                    }
					//d.execute_data("update "+yyy+".bhytkb set thuoc="+d_thuoc+",cls="+d_cls+",congkham="+d_congkham+",bntra="+d_bntra+",bhyttra="+d_bhyttra+" where id="+l_id);
                    //hiền thêm: số ngày nghỉ.
                    d.execute_data("update " + yyy + ".bhytkb set thuoc=" + d_thuoc + ",cls=" + d_cls + ",congkham=" + d_congkham +
                        ",bntra=" + d_bntra + ",bhyttra=" + d_bhyttra + ",ngaynghi=" + dr[i]["ngaynghi"].ToString() + " where id=" + l_id);
                    // end hien
                    d.updrec_bhytll(dtll, l_id, dr[i]["mabn"].ToString(), decimal.Parse(dr[i]["mavaovien"].ToString()), decimal.Parse(dr[i]["maql"].ToString()), dr[i]["hoten"].ToString(), dr[i]["namsinh"].ToString(), s_ngay, dr[i]["diachi"].ToString().Trim() + " " + dr[i]["tenpxa"].ToString().Trim() + " " + dr[i]["tenquan"].ToString().Trim() + " " + dr[i]["tentt"].ToString(), dr[i]["makp"].ToString(), dr[i]["chandoan"].ToString(), dr[i]["maicd"].ToString(), dr[i]["mabs"].ToString(), dr[i]["sothe"].ToString(), maphu, dr[i]["mabv"].ToString(), sobienlai, i_quyenso, d_congkham, d_thuoc, d_cls, d_thuoc, d_bntra, d_bhyttra,"","","","","",int.Parse(dr[i]["traituyen"].ToString()));
                    if (checkBox2.Checked) d.execute_data("update " + xxx + ".d_thuocbhytll set done=1 where id=" + l_id);
                    if (prn && dr.Length>0)
                    {
                        if (chkChiphi.Checked) get_data_printer(dr[i]["mabn"].ToString(), decimal.Parse(dr[i]["maql"].ToString()), dr[i]["chandoan"].ToString(), d_congkham.ToString(), dr[i]["hoten"].ToString(), dr[i]["sothe"].ToString(), maphu, "", "", "", "", dr[i]["maicd"].ToString(), dr[i]["makp"].ToString(), dr[i]["mabs"].ToString(),int.Parse(dr[i]["traituyen"].ToString()),"");
                        else
                        {
                            stttoa=printer(l_id, d_bntra, d_bhyttra, dr[i]["mabn"].ToString(), dr[i]["hoten"].ToString(), dr[i]["namsinh"].ToString(), dr[i]["diachi"].ToString().Trim() + " " + dr[i]["tenpxa"].ToString().Trim() + " " + dr[i]["tenquan"].ToString().Trim() + " " + dr[i]["tentt"].ToString(), dr[i]["sothe"].ToString(), dr[i]["chandoan"].ToString(), d_bntra + d_bhyttra, d_congkham, sobienlai, dr[i]["mabs"].ToString(), int.Parse(dr[i]["traituyen"].ToString()));//dr[i]["cholam"].ToString().Trim() + ";" +
                            if (chkDonChiphi.Checked) get_data_printer(dr[i]["mabn"].ToString(), decimal.Parse(dr[i]["maql"].ToString()), dr[i]["chandoan"].ToString(), d_congkham.ToString(), dr[i]["hoten"].ToString(), dr[i]["sothe"].ToString(), maphu, "", "", "", "", dr[i]["maicd"].ToString(), dr[i]["makp"].ToString(), dr[i]["mabs"].ToString(), int.Parse(dr[i]["traituyen"].ToString()), stttoa);
                        }
                    }                    
				}
			}
		}

        private void get_data_printer(string mabn, decimal maql, string chandoan, string congkham, string hoten, string sothe, int imaphu, string maphu, string tenbv, string tenbs, string tenkp, string maicd, string makp, string mabs, int traituyen, string m_stttoa)
        {
            dsxmlin.Clear();
            DataSet dst = new DataSet();
            dst = dsxmlin.Copy();
            DataRow r2,r1 = d.getrowbyid(dtkp, "makp='" + makp + "'");
            tenkp = (r1 != null) ? r1["tenkp"].ToString() : "";
            r1 = d.getrowbyid(dtbs, "ma='" + mabs + "'");
            tenbs = (r1 != null) ? r1["hoten"].ToString() : "";
            r1 = d.getrowbyid(dtdt, "madoituong=" + imaphu);
            maphu = (r1 != null) ? r1["doituong"].ToString() : "";
            string a_tennhombhyt = "";
            int a_sttbhyt = 0, a_idnhombhyt = 0;
            decimal d_dichvu_tt = 0, d_dichvu_tt_BH_tra = 0, d_dichvu_tt_BN_tra=0;
            decimal chitra = 0;
            decimal mavaovien = 0;
            string cholam = "", s_soluutru = "^", s_cachdung = "", s_maql = "", s_tentuyentruoc = "";
            string s_icd_ct = "", s_cd_ct = "";
            bool bTiepdon_nkp_inchungchiphi = m.bTiepdon_nkp_inchungchiphi , b_dacocdkemtheo = false;
            bool bLocbaohiem = d.bLocbaohiem;
            //gam 07/11/2011
            //string s_ngayvv = "", s_ngayrv = "", asql = "";
            //string mmyy_thangsau = "", mmyy_hientai = "", mmyy_truoc="";
            //mmyy_hientai = m.mmyy(s_ngay); mmyy_thangsau = m.Mmyy_sau(mmyy_hientai); mmyy_truoc = m.Mmyy_truoc(mmyy_hientai);

            //asql = "select to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv, to_char((case when b.bove=1 then max(c.ngay) else b.ngay end),'dd/mm/yyyy hh24:mi') as ngayrv ";
            //asql += "from xxx.tiepdon a inner join xxx.bhytkb b on a.mavaovien=b.mavaovien inner join ";
            //asql += "( select ngay,mavaovien from xxx.v_chidinh where mavaovien=" + l_mavaovien + " union all  select ngay,mavaovien from xxx.d_thuocbhytll where mavaovien=" + l_mavaovien + " ) c ";
            //asql += "on b.mavaovien=c.mavaovien where a.mavaovien=" + l_mavaovien + " group by a.ngay,b.bove,b.ngay";
            //if (m.bMmyy(mmyy_thangsau))
            //{
            //    asql += " union select to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv, to_char((case when b.bove=1 then max(c.ngay) else b.ngay end),'dd/mm/yyyy hh24:mi') as ngayrv ";
            //    asql += "from "+user+mmyy_hientai+".tiepdon a inner join xxx.bhytkb b on a.mavaovien=b.mavaovien inner join ";
            //    asql += "( select ngay,mavaovien from xxx.v_chidinh where mavaovien=" + l_mavaovien + " union all  select ngay,mavaovien from " + user + mmyy_hientai + ".d_thuocbhytll where mavaovien=" + l_mavaovien + " ) c ";
            //    asql += "on b.mavaovien=c.mavaovien where a.mavaovien=" + l_mavaovien + " group by a.ngay,b.bove,b.ngay";
            //    asql += " union select to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv, to_char((case when b.bove=1 then max(c.ngay) else b.ngay end),'dd/mm/yyyy hh24:mi') as ngayrv ";
            //    asql += "from " + user + mmyy_hientai + ".tiepdon a inner join " + user + mmyy_thangsau + ".bhytkb b on a.mavaovien=b.mavaovien inner join ";
            //    asql += "( select ngay,mavaovien from xxx.v_chidinh where mavaovien=" + l_mavaovien + " union all  select ngay,mavaovien from " + user + mmyy_hientai + ".d_thuocbhytll where mavaovien=" + l_mavaovien + " ) c ";
            //    asql += "on b.mavaovien=c.mavaovien where a.mavaovien=" + l_mavaovien + " group by a.ngay,b.bove,b.ngay";
            //}
            //DataSet dsngay = d.get_data_mmyy(asql, s_ngay, s_ngay,true);
            //foreach (DataRow r_ct in dsngay.Tables[0].Rows)
            //{
            //    s_ngayvv = r_ct["ngayvv"].ToString();
            //    s_ngayrv = r_ct["ngayrv"].ToString();
            //    break;
            //}
            //end gam

            //Thuy 11.06.2012
            string xxx = m.mmyy(s_ngay);
            string mmyysau = m.Mmyy_sau(s_mmyy);
            string mmyytruoc = m.Mmyy_truoc(s_mmyy );
            string yyysau = user + mmyysau;
            string yyyhientai = user + s_mmyy;
            string yyytruoc = user + mmyytruoc;
            string s_ngayvv = "", s_ngayrv = "", asql = "";
            string asql1 = "(select ngay,mavaovien from xxx.v_chidinh where mavaovien=" + l_mavaovien + " union all  select ngay,mavaovien from xxx.d_thuocbhytll where mavaovien=" + l_mavaovien + " ";
            if(m.bMmyy(yyytruoc))
            {
                asql1 += " union select ngay,mavaovien from " + yyytruoc + ".v_chidinh where mavaovien=" + l_mavaovien + " union all  select ngay,mavaovien from " + yyytruoc + ".d_thuocbhytll where mavaovien=" + l_mavaovien + "";
            }
            asql1 += " )";
            asql = "select to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv, to_char((case when b.bove=1 then max(c.ngay) else b.ngay end),'yyyy/mm/dd hh24:mi') as ngayrv ";
            asql += "from " + user + ".vi_benhanpk a inner join xxx.bhytkb b on a.mavaovien=b.mavaovien left join ";
            asql += asql1;
            asql += " c on b.mavaovien=c.mavaovien where a.mavaovien=" + l_mavaovien + " group by a.ngay,b.bove,b.ngay";
            asql += " union ";
            asql += "select to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv, to_char((case when b.bove=1 then max(c.ngay) else b.ngay end),'yyyy/mm/dd hh24:mi') as ngayrv ";
            asql += "from " + user + ".vi_benhancc a inner join xxx.bhytkb b on a.mavaovien=b.mavaovien left join ";
            asql += asql1;
            asql += " c on b.mavaovien=c.mavaovien where a.mavaovien=" + l_mavaovien + " group by a.ngay,b.bove,b.ngay";
            asql += " union ";
            asql += "select to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv, to_char((case when b.bove=1 then max(c.ngay) else coalesce(a.ngayrv,b.ngay) end),'yyyy/mm/dd hh24:mi') as ngayrv ";
            asql += "from " + user + ".benhanngtr a inner join xxx.bhytkb b on a.mavaovien=b.mavaovien inner join ";
            asql += asql1;
            asql += " c on b.mavaovien=c.mavaovien where a.mavaovien=" + l_mavaovien + " group by a.ngay,b.bove,b.ngay,a.ngayrv";
            DataSet dsngay = d.get_data_mmyy(asql, s_ngay, s_ngay, true);
            if (m.bMmyy(mmyysau))
            {
                asql = "select to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv, to_char((case when b.bove=1 then max(c.ngay) else b.ngay end),'yyyy/mm/dd hh24:mi') as ngayrv ";
                asql += "from " + yyyhientai + ".benhanpk a inner join " + yyysau + ".bhytkb b on a.mavaovien=b.mavaovien inner join ";
                asql += "( select ngay,mavaovien from " + yyyhientai + ".v_chidinh where mavaovien=" + l_mavaovien + " union all  select ngay,mavaovien from " + yyyhientai + ".d_thuocbhytll where mavaovien=" + l_mavaovien + " ) c ";
                asql += "on b.mavaovien=c.mavaovien where a.mavaovien=" + l_mavaovien + " group by a.ngay,b.bove,b.ngay";
                asql += " union ";
                asql += "select to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv, to_char((case when b.bove=1 then max(c.ngay) else b.ngay end),'yyyy/mm/dd hh24:mi') as ngayrv ";
                asql += "from " + yyyhientai + ".benhancc a inner join " + yyysau + ".bhytkb b on a.mavaovien=b.mavaovien inner join ";
                asql += "( select ngay,mavaovien from " + yyyhientai + ".v_chidinh where mavaovien=" + l_mavaovien + " union all  select ngay,mavaovien from " + yyyhientai + ".d_thuocbhytll where mavaovien=" + l_mavaovien + " ) c ";
                asql += "on b.mavaovien=c.mavaovien where a.mavaovien=" + l_mavaovien + " group by a.ngay,b.bove,b.ngay";

                DataSet dsngay1 = d.get_data(asql);
                dsngay.Merge(dsngay1);
            }
            foreach (DataRow r_ct in dsngay.Tables[0].Select("", "ngayrv desc"))
            {
                s_ngayvv = r_ct["ngayvv"].ToString();
                s_ngayrv = r_ct["ngayrv"].ToString().Substring(8, 2).PadLeft(2, '0') + "/" + r_ct["ngayrv"].ToString().Substring(5, 3) + r_ct["ngayrv"].ToString().Substring(0, 4) + r_ct["ngayrv"].ToString().Substring(10);
                break;
            }
            //end Thủy 13.11.2012
            foreach (DataRow r3 in d.get_data("select cholam from " + user + ".btdbn where mabn='" + mabn + "'").Tables[0].Rows)
                cholam = r3["cholam"].ToString();
            string s_chandoan = "",s_maicd="",s_tenkp="",s_tenbs="",maso="";
            if (maql != 0)
            {
                sql = "select mavaovien from xxx.benhanpk where maql=" + maql;
                sql += " union all ";
                sql += "select mavaovien from xxx.tiepdon where maql=" + maql;
                sql += " union all ";
                sql += "select mavaovien from xxx.benhancc where maql=" + maql;

                foreach (DataRow r3 in d.get_data_mmyy(sql, s_tu, s_den, songayduyet).Tables[0].Rows)
                    mavaovien = decimal.Parse(r3["mavaovien"].ToString());
                if (mavaovien == 0)
                {
                    sql = "select mavaovien from " + user + ".benhanngtr where maql=" + maql;
                    sql += " union all ";
                    sql += "select mavaovien from " + user + ".benhandt where maql=" + maql;

                    foreach (DataRow r3 in d.get_data(sql).Tables[0].Rows)
                        mavaovien = decimal.Parse(r3["mavaovien"].ToString());
                }
            }
            if (mavaovien == 0) mavaovien = l_mavaovien;
            sql = "select a.maql,coalesce(a1.chandoan,a.chandoan) as chandoan,coalesce(a1.maicd,a.maicd) as maicd,a.makp,b.tenkp,a.mabs,c.hoten as tenbs,to_char(a.ngay,'dd/mm/yyyy') as ngay from xxx.bhytkb a inner join xxx.benhanpk a1 on a.mavaovien=a1.mavaovien inner join " + user + ".btdkp_bv b on a.makp=b.makp left join " + user + ".dmbs c on a.mabs=c.ma where a.mavaovien=" + l_mavaovien + " order by a.maql";
            foreach (DataRow r in d.get_data_mmyy(sql,s_tu,s_den,songayduyet).Tables[0].Rows)
            {
                if (bInchiphi_chandoan_bacsy)
                {
                    if (s_maql != r["maql"].ToString())
                    {
                        s_icd_ct = r["maicd"].ToString() + "; "; s_cd_ct = r["chandoan"].ToString() + "; ";
                        s_maql = r["maql"].ToString();
                        b_dacocdkemtheo = false;
                        foreach (DataRow r11 in m.get_data("select chandoan,maicd from " + user + m.mmyy(r["ngay"].ToString()) + ".cdkemtheo where maql=" + s_maql + " order by stt").Tables[0].Rows)
                        {
                            s_cd_ct += (s_cd_ct.IndexOf(r11["chandoan"].ToString().Trim() + ";") < 0) ? r11["chandoan"].ToString().Trim() + "; " : "";
                            s_icd_ct += (s_icd_ct.IndexOf(r11["maicd"].ToString().Trim() + ";") < 0) ? r11["maicd"].ToString().Trim() + "; " : "";
                            b_dacocdkemtheo = true;
                        }
                        if (!b_dacocdkemtheo)
                        {
                            string s_maql_pk_pl_makp = m.f_get_maql(l_mavaovien, r["ngay"].ToString(), r["ngay"].ToString(), r["makp"].ToString());
                            if (s_maql_pk_pl_makp.Trim().Trim(',') != "")
                            {
                                foreach (DataRow r11 in m.get_data("select chandoan,maicd from " + user + m.mmyy(r["ngay"].ToString()) + ".cdkemtheo where maql in(" + s_maql_pk_pl_makp.Trim().Trim(',') + ") order by stt").Tables[0].Rows)
                                {
                                    s_cd_ct += (s_cd_ct.IndexOf(r11["chandoan"].ToString().Trim() + ";") < 0) ? r11["chandoan"].ToString().Trim() + "; " : "";
                                    s_icd_ct += s_icd_ct.IndexOf(r11["maicd"].ToString().Trim() + ";") < 0 ? r11["maicd"].ToString().Trim() + "; " : "";
                                }
                            }
                        }
                    }
                    r1 = m.getrowbyid(dst.Tables[0], "maql=" + decimal.Parse(r["maql"].ToString()));
                    if (r1 == null)
                    {
                        maso += r["maql"].ToString() + ",";
                        r2 = dst.Tables[0].NewRow();
                        r2["maql"] = decimal.Parse(r["maql"].ToString());
                        r2["maicd"] = s_icd_ct;// r["maicd"].ToString();
                        r2["chandoan"] = s_cd_ct;// r["chandoan"].ToString();
                        r2["mabs"] = r["mabs"].ToString();
                        r2["tenbs"] = r["tenbs"].ToString();
                        r2["makp"] = r["makp"].ToString();
                        r2["tenkp"] = r["tenkp"].ToString();
                        if (File.Exists("..\\..\\..\\chuky\\" + r["mabs"].ToString() + ".bmp"))
                        {
                            fstr = new FileStream("..\\..\\..\\chuky\\" + r["mabs"].ToString() + ".bmp", FileMode.Open, FileAccess.Read);
                            image = new byte[fstr.Length];
                            fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                            fstr.Close();
                            r2["Image"] = image;
                       }
                       dst.Tables[0].Rows.Add(r2);
                    }
                }
                s_maicd += r["maicd"].ToString().Trim() + ";";
                if (s_chandoan.IndexOf(r["chandoan"].ToString().Trim() + ";") < 0) s_chandoan += r["chandoan"].ToString().Trim() + ";";
                s_tenkp += r["tenkp"].ToString().Trim() + ";";
                s_tenbs += r["tenbs"].ToString() + ";";
                //
                b_dacocdkemtheo = false;
                foreach (DataRow r3 in m.get_data("select chandoan,maicd from " + user+m.mmyy(r["ngay"].ToString()) + ".cdkemtheo where maql=" + decimal.Parse(r["maql"].ToString()) + " order by stt").Tables[0].Rows)
                {
                    if(s_chandoan.IndexOf(r3["chandoan"].ToString().Trim() + ";")<0)s_chandoan += r3["chandoan"].ToString().Trim() + ";";
                    if (s_maicd.IndexOf(r3["maicd"].ToString().Trim() + ";") < 0) s_maicd += r3["maicd"].ToString().Trim() + ";";
                    b_dacocdkemtheo = true;
                }
                if (!b_dacocdkemtheo)
                {
                    string s_maql_pk_pl = m.f_get_maql(mavaovien, r["ngay"].ToString(), r["ngay"].ToString());
                    if (s_maql_pk_pl.Trim().Trim(',') != "")
                    {
                        foreach (DataRow r3 in m.get_data("select chandoan,maicd from " + user + m.mmyy(r["ngay"].ToString()) + ".cdkemtheo where maql in(" + s_maql_pk_pl.Trim().Trim(',') + ") order by stt").Tables[0].Rows)
                        {
                            if (s_chandoan.IndexOf(r3["chandoan"].ToString().Trim() + ";") < 0) s_chandoan += r3["chandoan"].ToString().Trim() + ";";
                            if (s_maicd.IndexOf(r3["maicd"].ToString().Trim() + ";") < 0) s_maicd += r3["maicd"].ToString().Trim() + ";";
                        }
                    }
                }
                //
                if (i_loaiba == 1 || i_loaiba == 2)
                {
                    foreach (DataRow r3 in m.get_data("select chandoan,maicd from " + user + ".cdkemtheo where maql=" + decimal.Parse(r["maql"].ToString()) + " order by stt").Tables[0].Rows)
                    {
                        if (s_chandoan.IndexOf(r3["chandoan"].ToString().Trim() + ";") < 0) s_chandoan += r3["chandoan"].ToString().Trim() + ";";
                        if (s_maicd.IndexOf(r3["maicd"].ToString().Trim() + ";") < 0) s_maicd += r3["maicd"].ToString().Trim() + ";";
                    }
                }
            }
            if (s_chandoan == "" || i_loaiba==2)
            {
                s_chandoan = chandoan.Trim(';') ;
                s_maicd = maicd.Trim(';');
            }

            if (mavaovien == 0)
            {
                foreach (DataRow r3 in d.get_data_mmyy("select * from xxx.benhancc where maql=" + maql, s_tu, s_den, songayduyet).Tables[0].Rows)
                {
                    mavaovien = decimal.Parse(r3["mavaovien"].ToString());
                    s_soluutru = r3["sovaovien"].ToString() + "^" + r3["soluutru"].ToString();
                }
            }
            foreach (DataRow r3 in d.get_data_mmyy("select b.tenbv from xxx.noigioithieu a," + user + ".dstt b where a.mabv=b.mabv and a.maql=" + maql, s_tu, s_den, songayduyet).Tables[0].Rows)
                s_tentuyentruoc = r3["tenbv"].ToString().Trim();

            int _userid = -1;
            int isophieu = d.get_sophieu_bhyt_userid(s_mmyy, mabn, mavaovien, s_ngay, imaphu, _userid, ngay_reset_phieu38 );
            int lanin = d.get_laninkb(s_mmyy, mabn, mavaovien, s_ngay, imaphu);
            DataSet ds1;
            string fie = (bGia_bh_quydinh_giamua) ? "giamua" : "giaban";
            if ((bGiaban || bGia_bh_quydinh) && bchenhlech_thuoc && s_chenhlech.IndexOf(imaphu.ToString().PadLeft(2, '0')) != -1)
            {
                sql = "select 1 as id,a.stt,a.sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,e.ten as tenkho,c.ten as tennguon,d.ten as tennhomcc,t.handung,t.losx,a.soluong,";
                //if (bGia_bh_quydinh) sql += "b.gia_bh as dongia,b.gia_bh*a.soluong as sotien,";
                if (bGia_bh_quydinh && bLaygiamua_khi_giabh_0_giabh_nho_giamua ) sql += "(case when a.gia_bh=0 or t.giamua<a.gia_bh then t.giamua else a.gia_bh end) as dongia,(case when a.gia_bh=0 or t.giamua<a.gia_bh then t.giamua else a.gia_bh end)*a.soluong as sotien,";
                else if (bGia_bh_quydinh && bLaygiamua_khi_giabh_0_giabh_nho_giamua==false) sql += " a.gia_bh as dongia,a.gia_bh*a.soluong as sotien,";
                else sql += "t.giamua as dongia,t.giamua*a.soluong as sotien,";
                sql += "a.cachdung,a.makho,t.manguon,t.nhomcc,f.mabs,f.chandoan,h.tenkp,f.maql,f.makp,f.maphu as madoituong ";
                sql += ",i.ten as hangsx, j.ten as nuocsx ";
                sql += " from xxx.bhytthuoc a," + user + ".d_dmbd b," + user + ".d_dmnguon c," + user + ".d_dmnx d," + user + ".d_dmkho e,xxx.bhytkb f,xxx.d_theodoi t," + user + ".btdkp_bv h";
                sql += ", " + user + ".d_dmhang i, " + user + ".d_dmnuoc j ";
                sql += " where a.sttt=t.id and f.id=a.id and a.mabd=b.id and t.manguon=c.id and t.nhomcc=d.id and a.makho=e.id and f.makp=h.makp";
                sql += " and b.mahang=i.id(+) and b.manuoc=j.id(+)";
                sql += " and f.mabn='" + mabn + "'";// and to_char(f.ngay,'dd/mm/yyyy')='" + s_ngay + "'";//" and id="+l_id+" order by a.stt";
                //if (mavaovien != 0) sql += " and f.mavaovien=" + mavaovien;
                if (chkintrongngay.Checked) sql += " and to_char(f.ngay,'dd/mm/yyyy')='" + s_ngay + "'";//binh 070711 
                //if (bLocbaohiem) sql += " and to_char(f.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                if (bTiepdon_nkp_inchungchiphi && mavaovien != 0) sql += " and (f.mavaovien=" + mavaovien + " or to_char(f.ngay,'dd/mm/yyyy')='" + s_ngay + "')";
                else if (bTiepdon_nkp_inchungchiphi && mavaovien == 0) sql += " and to_char(f.ngay,'dd/mm/yyyy')='" + s_ngay + "'";                
                else sql += " and f.mavaovien=" + mavaovien;
                if (i_khudt != 0) sql += " and (h.khu=0 or h.khu=" + i_khudt + ")";//binh 210411
                //
                if (bThuchenhlechtruoc_duyettoasau == false)
                {
                    sql += " union all ";
                    sql += "select 1 as id,a.stt,a.sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,e.ten as tenkho,c.ten as tennguon,d.ten as tennhomcc,t.handung,t.losx,a.soluong,";
                    //if (bGia_bh_quydinh) sql += "t."+fie+"-b.gia_bh as dongia,(t."+fie+"-b.gia_bh)*a.soluong as sotien,";
                    if (bGia_bh_quydinh && bLaygiamua_khi_giabh_0_giabh_nho_giamua ) sql += "t." + fie + "-(case when a.gia_bh=0 or t.giamua<a.gia_bh then t.giamua else a.gia_bh end) as dongia,(t." + fie + "-(case when a.gia_bh=0 or t.giamua<a.gia_bh then t.giamua else a.gia_bh end))*a.soluong as sotien,";
                    else if (bGia_bh_quydinh && bLaygiamua_khi_giabh_0_giabh_nho_giamua==false) sql += "t." + fie + "- a.gia_bh as dongia,(t." + fie + "- a.gia_bh)*a.soluong as sotien,";
                    else sql += "t.giaban-t.giamua as dongia,(t.giaban-t.giamua)*a.soluong as sotien,";
                    sql += "a.cachdung,a.makho,t.manguon,t.nhomcc,f.mabs,f.chandoan,h.tenkp,f.maql,f.makp," + i_tunguyen + " as madoituong ";
                    sql += ",i.ten as hangsx, j.ten as nuocsx ";
                    sql += " from xxx.bhytthuoc a," + user + ".d_dmbd b," + user + ".d_dmnguon c," + user + ".d_dmnx d," + user + ".d_dmkho e,xxx.bhytkb f,xxx.d_theodoi t," + user + ".btdkp_bv h";
                    sql += ", " + user + ".d_dmhang i, " + user + ".d_dmnuoc j ";
                    sql += " where a.sttt=t.id and f.id=a.id and a.mabd=b.id and t.manguon=c.id and t.nhomcc=d.id and a.makho=e.id and f.makp=h.makp";
                    sql += " and b.mahang=i.id(+) and b.manuoc=j.id(+)";
                    sql += " and f.mabn='" + mabn + "'";// and to_char(f.ngay,'dd/mm/yyyy')='" + s_ngay + "'";//" and id="+l_id+" order by a.stt";
                    //if (mavaovien != 0) sql += " and f.mavaovien=" + mavaovien;
                    if (chkintrongngay.Checked) sql += " and to_char(f.ngay,'dd/mm/yyyy')='" + s_ngay + "'";//binh 070711 
                    if (bTiepdon_nkp_inchungchiphi && mavaovien != 0) sql += " and (f.mavaovien=" + mavaovien + " or to_char(f.ngay,'dd/mm/yyyy')='" + s_ngay + "')";
                    else if (bTiepdon_nkp_inchungchiphi && mavaovien == 0) sql += " and to_char(f.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                    else sql += " and f.mavaovien=" + mavaovien;
                    if (bChenhlech_thuoc_dannhmuc) sql += " and b.chenhlech=1";
                    if (i_khudt != 0) sql += " and (h.khu=0 or h.khu=" + i_khudt + ")";//binh 210411
                }
            }
            else
            {
                sql = "select 1 as id,a.stt,a.sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,e.ten as tenkho,c.ten as tennguon,d.ten as tennhomcc,t.handung,t.losx,a.soluong,";
                //if (bGiaban) sql += "t.giaban as dongia,t.giaban*a.soluong as sotien,";
                //else sql += "t.giamua as dongia,t.giamua*a.soluong as sotien,";
                if (bGiaban)
                {
                    sql += "t.giaban as dongia,t.giaban*a.soluong as sotien,";
                }
                else if (bGia_bh_quydinh)
                {
                    sql += "a.gia_bh as dongia, a.gia_bh*a.soluong as sotien,";//gam 10/10/2011
                }
                else sql += "t.giamua as dongia,t.giamua*a.soluong as sotien,";
                sql += "a.cachdung,a.makho,t.manguon,t.nhomcc,f.mabs,f.chandoan,h.tenkp,f.maql,f.makp,f.maphu as madoituong ";
                sql += ",i.ten as hangsx, j.ten as nuocsx ";
                sql += " from xxx.bhytthuoc a," + user + ".d_dmbd b," + user + ".d_dmnguon c," + user + ".d_dmnx d," + user + ".d_dmkho e,xxx.bhytkb f,xxx.d_theodoi t," + user + ".btdkp_bv h";
                sql += ", " + user + ".d_dmhang i, " + user + ".d_dmnuoc j ";
                sql += " where a.sttt=t.id and f.id=a.id and a.mabd=b.id and t.manguon=c.id and t.nhomcc=d.id and a.makho=e.id and f.makp=h.makp";
                sql += " and b.mahang=i.id(+) and b.manuoc=j.id(+)";
                sql += " and f.mabn='" + mabn + "'";// and to_char(f.ngay,'dd/mm/yyyy')='" + s_ngay + "'";//" and id="+l_id+" order by a.stt";
                if (chkintrongngay.Checked) sql += " and to_char(f.ngay,'dd/mm/yyyy')='" + s_ngay + "'";//binh 070711 
                //if (mavaovien != 0) sql += " and f.mavaovien=" + mavaovien;
                if (bTiepdon_nkp_inchungchiphi && mavaovien != 0) sql += " and (f.mavaovien=" + mavaovien + " or to_char(f.ngay,'dd/mm/yyyy')='" + s_ngay + "')";
                else if (bTiepdon_nkp_inchungchiphi && mavaovien == 0) sql += " and to_char(f.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                else sql += " and f.mavaovien=" + mavaovien;
                if (i_khudt != 0) sql += " and (h.khu=0 or h.khu=" + i_khudt + ")";//binh 210411
                //sql+=" order by f.id,a.stt"; 
            }
            if (bChenhlech && s_chenhlech.IndexOf(imaphu.ToString().PadLeft(2, '0')) != -1 && chkKodichvu.Checked)
            {
                sql += " union all ";
                sql += "select 3 as id,a.stt,0 as sttt,a.mavp as mabd,b.ma,b.ten,' ' as tenhc,b.dvt as dang,' ' as tenkho,";
                sql += "' ' as tennguon,' ' as tennhomcc,' ' as handung,' ' as losx,a.soluong,";
                //sql += " b." + fie_tunguyen + "-b.gia_bh as dongia,a.soluong*(b." + fie_tunguyen + "-b.gia_bh) as sotien,' ' as cachdung,0 as makho,0 as manguon,0 as nhomcc,";
                //if (bBHYT_Traituyen_tinh_Tyle_khac && traituyen != 0)
                //{
                //    sql += " b." + fie_tunguyen + "-(b.gia_bh*b.bhyt_tt/100) as dongia,a.soluong*(b." + fie_tunguyen + "-(b.gia_bh*b.bhyt_tt/100)) as sotien,";
                //}
                //else
                //{
                    sql += " b." + fie_tunguyen + "-b.gia_bh as dongia,a.soluong*(b." + fie_tunguyen + "-b.gia_bh) as sotien,";
                //}
                sql += "' ' as cachdung,0 as makho,0 as manguon,0 as nhomcc,";
                sql += "c.mabs,c.chandoan,h.tenkp,c.maql,c.makp," + i_tunguyen + " as madoituong";
                sql += ", null as hangsx, null as nuocsx ";
                sql += " from xxx.bhytcls a," + user + ".v_giavp b,xxx.bhytkb c," + user + ".btdkp_bv h  where c.id=a.id and a.mavp=b.id and c.makp=h.makp";
                sql += " and c.mabn='" + mabn + "'";// and to_char(c.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                sql += " and b." + fie_tunguyen + "-b.gia_bh>0";
                //if (mavaovien != 0) sql += " and c.mavaovien=" + mavaovien;
                if (bTiepdon_nkp_inchungchiphi && mavaovien != 0) sql += " and (c.mavaovien=" + mavaovien + " or to_char(c.ngay,'dd/mm/yyyy')='" + s_ngay + "')";
                else if (bTiepdon_nkp_inchungchiphi && mavaovien == 0) sql += " and to_char(c.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                else sql += " and c.mavaovien=" + mavaovien;
                if (bChenhlech_thuoc_dannhmuc) sql += " and b.chenhlech=1";
                if (i_khudt != 0) sql += " and (h.khu=0 or h.khu=" + i_khudt + ")";//binh 210411
                sql += " union all ";
                sql += "select 3 as id,a.stt,0 as sttt,a.mavp as mabd,b.ma,b.ten,' ' as tenhc,b.dvt as dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,' ' as handung,' ' as losx,a.soluong,a.dongia,a.soluong*a.dongia as sotien,' ' as cachdung,0 as makho,0 as manguon,0 as nhomcc,c.mabs,c.chandoan,h.tenkp,c.maql,c.makp,c.maphu as madoituong ";
                sql += ", null as hangsx, null as nuocsx ";
                sql += " from xxx.bhytcls a," + user + ".v_giavp b,xxx.bhytkb c," + user + ".btdkp_bv h where c.id=a.id and a.mavp=b.id ";
                sql += " and c.makp=h.makp and c.mabn='" + mabn + "'";// and to_char(c.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                //if (mavaovien != 0) sql += " and c.mavaovien=" + mavaovien;
                if (chkintrongngay.Checked) sql += " and to_char(c.ngay,'dd/mm/yyyy')='" + s_ngay + "'";//binh 070711 
                if (bTiepdon_nkp_inchungchiphi && mavaovien != 0) sql += " and (c.mavaovien=" + mavaovien + " or to_char(c.ngay,'dd/mm/yyyy')='" + s_ngay + "')";
                else if (bTiepdon_nkp_inchungchiphi && mavaovien == 0) sql += " and to_char(c.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                else sql += " and c.mavaovien=" + mavaovien;
                if (i_khudt != 0) sql += " and (h.khu=0 or h.khu=" + i_khudt + ")";//binh 210411
                ds1 = d.get_data_mmyy(sql,s_ngayvv,s_ngayrv,true);
            }
            else
            {
                sql += " union all ";
                sql += "select 3 as id,a.stt,0 as sttt,a.mavp as mabd,b.ma,b.ten,' ' as tenhc,b.dvt as dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,' ' as handung,' ' as losx,a.soluong,a.dongia,a.soluong*a.dongia as sotien,' ' as cachdung,0 as makho,0 as manguon,0 as nhomcc,c.mabs,c.chandoan,h.tenkp,c.maql,c.makp,c.maphu as madoituong ";
                sql += ", null as hangsx, null as nuocsx ";
                sql += " from xxx.bhytcls a," + user + ".v_giavp b,xxx.bhytkb c," + user + ".btdkp_bv h where c.id=a.id and a.mavp=b.id ";
                sql += " and c.makp=h.makp and c.mabn='" + mabn + "'";// and to_char(c.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                if (chkintrongngay.Checked) sql += " and to_char(c.ngay,'dd/mm/yyyy')='" + s_ngay + "'";//binh 070711 
                //if (mavaovien != 0) sql += " and c.mavaovien=" + mavaovien;
                if (bTiepdon_nkp_inchungchiphi && mavaovien != 0) sql += " and (c.mavaovien=" + mavaovien + " or to_char(c.ngay,'dd/mm/yyyy')='" + s_ngay + "')";
                else if (bTiepdon_nkp_inchungchiphi && mavaovien == 0) sql += " and to_char(c.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                else sql += " and c.mavaovien=" + mavaovien;
                if (i_khudt != 0) sql += " and (h.khu=0 or h.khu=" + i_khudt + ")";//binh 210411
                ds1 = d.get_data_mmyy(sql,s_ngayvv,s_ngayrv,true );
            }
            if (bIncstt)
            {
                string s_field_giaban = (d.bGiaban_theodot(i_nhom)) ? "t.giaban" : "b.giaban";
                if ((bGiaban || bGia_bh_quydinh) && bchenhlech_thuoc && s_chenhlech.IndexOf(imaphu.ToString().PadLeft(2, '0')) != -1)
                {
                    sql = "select 2 as id,a.stt,a.sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,e.ten as tenkho,c.ten as tennguon,d.ten as tennhomcc,t.handung,t.losx,a.soluong,";
                    //if (bGia_bh_quydinh) sql += "b.gia_bh as dongia,b.gia_bh*a.soluong as sotien,";
                    if (bGia_bh_quydinh && bLaygiamua_khi_giabh_0_giabh_nho_giamua ) sql += "case when a.madoituong =1 then (case when b.gia_bh=0 or t.giamua<b.gia_bh then t.giamua else b.gia_bh end) else (case when k.loai=1 then " + s_field_giaban + " else t.giamua end) end as dongia,(case when a.madoituong =1 then (case when b.gia_bh=0 or t.giamua<b.gia_bh then t.giamua else b.gia_bh end) else (case when k.loai=1 then " + s_field_giaban + " else t.giamua end) end)*a.soluong as sotien,";
                    else if (bGia_bh_quydinh && bLaygiamua_khi_giabh_0_giabh_nho_giamua==false) sql += "case when a.madoituong =1 then b.gia_bh else (case when k.loai=1 then " + s_field_giaban + " else t.giamua end) end as dongia,(case when a.madoituong =1 then b.gia_bh else (case when k.loai=1 then " + s_field_giaban + " else t.giamua end) end)*a.soluong as sotien,";
                    else sql += "t.giamua as dongia,t.giamua*a.soluong as sotien,";
                    sql += "'' as cachdung,a.makho,t.manguon,t.nhomcc,'" + mabs + "' as mabs,'" + chandoan + "' as chandoan,h.tenkp,f.maql,g.makp,a.madoituong ";
                    sql += ",i.ten as hangsx, j.ten as nuocsx ";
                    sql += " from xxx.d_xuatsdct a," + user + ".d_dmbd b," + user + ".d_dmnguon c," + user + ".d_dmnx d,";
                    sql += user + ".d_dmkho e,xxx.d_xuatsdll f,xxx.d_theodoi t," + user + ".d_duockp g," + user + ".btdkp_bv h ";
                    sql += ", " + user + ".d_dmhang i, " + user + ".d_dmnuoc j, " + user + ".d_doituong k  ";
                    sql += " where f.id=a.id and a.mabd=b.id and a.sttt=t.id and t.manguon=c.id and t.nhomcc=d.id and a.makho=e.id and a.madoituong=k.madoituong ";
                    sql += " and b.mahang=i.id(+) and b.manuoc=j.id(+)";
                    sql += " and f.makp=g.id and g.makp=h.makp and f.mabn='" + mabn + "'";
                    sql += " and f.mavaovien=" + mavaovien;
                    if (i_khudt != 0) sql += " and (h.khu=0 or h.khu=" + i_khudt + ")";//binh 210411
                    if (chkintrongngay.Checked) sql += " and to_char(f.ngay,'dd/mm/yyyy')='" + s_ngay + "'";//binh 070711 
                    //sql += " and to_char(f.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                    //sql += " and a.madoituong=" + imaphu;
                    sql += " and f.loai=2 ";
                    if (i_khudt != 0) sql += " and (g.khu=0 or g.khu=" + i_khudt + ")";//binh 210411
                    sql += " union all ";
                    sql += "select 2 as id,a.stt,a.sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,e.ten as tenkho,c.ten as tennguon,d.ten as tennhomcc,t.handung,t.losx,a.soluong,";
                    //if (bGia_bh_quydinh) sql += "t."+fie+"-b.gia_bh as dongia,(t."+fie+"-b.gia_bh)*a.soluong as sotien,";
                    if (bGia_bh_quydinh && bLaygiamua_khi_giabh_0_giabh_nho_giamua ) sql += "case when a.madoituong=1 then (t." + fie + "-(case when b.gia_bh=0 or t.giamua<b.gia_bh then t.giamua else b.gia_bh end)) else 0 end as dongia,(case when a.madoituong=1 then (t." + fie + "-(case when b.gia_bh=0 or t.giamua<b.gia_bh then t.giamua else b.gia_bh end))else 0 end)*a.soluong as sotien,";
                    else if (bGia_bh_quydinh && bLaygiamua_khi_giabh_0_giabh_nho_giamua==false ) sql += "case when a.madoituong=1 then (t." + fie + "-b.gia_bh) else 0 end as dongia,(case when a.madoituong=1 then (t." + fie + "-b.gia_bh) else 0 end)*a.soluong as sotien,";
                    else sql += "t.giaban-t.giamua as dongia,(t.giaban-t.giamua)*a.soluong as sotien,";
                    sql += "'' as cachdung,a.makho,t.manguon,t.nhomcc,'" + mabs + "' as mabs,'" + chandoan + "' as chandoan,h.tenkp,f.maql,g.makp,"+i_tunguyen+" as madoituong ";
                    sql += ",i.ten as hangsx, j.ten as nuocsx ";
                    sql += " from xxx.d_xuatsdct a," + user + ".d_dmbd b," + user + ".d_dmnguon c," + user + ".d_dmnx d,";
                    sql += user + ".d_dmkho e,xxx.d_xuatsdll f,xxx.d_theodoi t," + user + ".d_duockp g," + user + ".btdkp_bv h ";
                    sql += ", " + user + ".d_dmhang i, " + user + ".d_dmnuoc j ";
                    sql += " where f.id=a.id and a.mabd=b.id and a.sttt=t.id and t.manguon=c.id and t.nhomcc=d.id and a.makho=e.id ";
                    sql += " and b.mahang=i.id(+) and b.manuoc=j.id(+)";
                    sql += " and f.makp=g.id and g.makp=h.makp and f.mabn='" + mabn + "'";
                    sql += " and f.mavaovien=" + mavaovien;
                    //sql += " and to_char(f.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                    if (chkintrongngay.Checked) sql += " and to_char(f.ngay,'dd/mm/yyyy')='" + s_ngay + "'";//binh 070711 
                    sql += " and a.madoituong=" + imaphu;
                    sql += " and f.loai=2 ";
                    if (i_khudt != 0) sql += " and (g.khu=0 or g.khu=" + i_khudt + ")";//binh 210411
                    if (bChenhlech_thuoc_dannhmuc) sql += " and b.chenhlech=1";

                    sql += " union all ";
                    sql += "select 3 as id,0 as stt,0 as sttt,a.mavp as mabd,b.ma,b.ten,' ' as tenhc,b.dvt as dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,' ' as handung,' ' as losx,a.soluong,a.dongia,a.soluong*a.dongia as sotien,' ' as cachdung,0 as makho,0 as manguon,0 as nhomcc,";
                    sql += "'" + mabs + "' as mabs,'" + chandoan + "' as chandoan,h.tenkp,a.maql,a.makp,a.madoituong ";
                    sql += ", null as hangsx, null as nuocsx ";
                    sql += " from xxx.v_vpkhoa a," + user + ".v_giavp b," + user + ".btdkp_bv h where a.mavp=b.id ";//and a.id="+l_id+" order by a.stt";
                    sql += " and a.makp=h.makp and a.mabn='" + mabn + "'";
                    sql += " and a.mavaovien=" + mavaovien;
                    if (chkintrongngay.Checked) sql += " and to_char(a.ngay,'dd/mm/yyyy')='" + s_ngay + "'";//binh 070711 
                    if (i_khudt != 0) sql += " and (h.khu=0 or h.khu=" + i_khudt + ")";//binh 210411
                    //sql += " and to_char(a.ngay,'dd/mm/yyyy')='" + s_ngay + "'";//" and id="+l_id+" order by a.stt";
                    //sql += " and a.madoituong=" + imaphu;
                    ds1.Merge(d.get_data_mmyy(sql,s_ngayvv,s_ngayrv,true ));
                }
                else
                {
                    sql = "select 2 as id,a.stt,a.sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,e.ten as tenkho,c.ten as tennguon,d.ten as tennhomcc,t.handung,t.losx,a.soluong,";
                    if (bGiaban) sql += "t.giaban as dongia,t.giaban*a.soluong as sotien,";
                    else sql += "t.giamua as dongia,t.giamua*a.soluong as sotien,";
                    sql += "'' as cachdung,a.makho,t.manguon,t.nhomcc,'" + mabs + "' as mabs,'" + chandoan + "' as chandoan,h.tenkp,f.maql,g.makp,a.madoituong ";
                    sql += ",i.ten as hangsx, j.ten as nuocsx ";
                    sql += " from xxx.d_xuatsdct a," + user + ".d_dmbd b," + user + ".d_dmnguon c," + user + ".d_dmnx d,";
                    sql += user + ".d_dmkho e,xxx.d_xuatsdll f,xxx.d_theodoi t," + user + ".d_duockp g," + user + ".btdkp_bv h ";
                    sql += ", " + user + ".d_dmhang i, " + user + ".d_dmnuoc j ";
                    sql += " where f.id=a.id and a.mabd=b.id and a.sttt=t.id and t.manguon=c.id and t.nhomcc=d.id and a.makho=e.id ";
                    sql += " and b.mahang=i.id(+) and b.manuoc=j.id(+)";
                    sql += " and f.makp=g.id and g.makp=h.makp and f.mabn='" + mabn + "'";
                    sql += " and f.mavaovien=" + mavaovien;
                    //sql += " and to_char(f.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                    if (chkintrongngay.Checked) sql += " and to_char(f.ngay,'dd/mm/yyyy')='" + s_ngay + "'";//binh 070711 
                    //sql += " and a.madoituong=" + imaphu;
                    sql += " and f.loai=2 ";
                    if (i_khudt != 0) sql += " and (g.khu=0 or g.khu=" + i_khudt + ")";//binh 210411
                    sql += " union all ";
                    sql += "select 3 as id,0 as stt,0 as sttt,a.mavp as mabd,b.ma,b.ten,' ' as tenhc,b.dvt as dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,' ' as handung,' ' as losx,a.soluong,a.dongia,a.soluong*a.dongia as sotien,' ' as cachdung,0 as makho,0 as manguon,0 as nhomcc,";
                    sql += "'" + mabs + "' as mabs,'" + chandoan + "' as chandoan,h.tenkp,a.maql,a.makp,a.madoituong ";
                    sql += ", null as hangsx, null as nuocsx ";
                    sql += " from " + yyy + ".v_vpkhoa a," + user + ".v_giavp b," + user + ".btdkp_bv h where a.mavp=b.id ";//and a.id="+l_id+" order by a.stt";
                    sql += " and a.makp=h.makp and a.mabn='" + mabn + "'";
                    sql += " and a.mavaovien=" + mavaovien;
                    if (chkintrongngay.Checked) sql += " and to_char(a.ngay,'dd/mm/yyyy')='" + s_ngay + "'";//binh 070711 
                    if (i_khudt != 0) sql += " and (h.khu=0 or h.khu=" + i_khudt + ")";//binh 210411

                    //sql += " and to_char(a.ngay,'dd/mm/yyyy')='" + s_ngay + "'";//" and id="+l_id+" order by a.stt";
                    //sql += " and a.madoituong=" + imaphu;
                    ds1.Merge(d.get_data_mmyy(sql,s_ngayvv,s_ngayrv,true ));
                }
            }

            if (bInchiphi_chandoan_bacsy && maso=="")
            {
                foreach(DataRow r in ds1.Tables[0].Rows)
                    if (maso.IndexOf(r["maql"].ToString() + ",") == -1) maso += r["maql"].ToString() + ",";
                if (maso != "")
                {
                    sql = "select a.maql,a.chandoan,a.maicd,a.makp,b.tenkp,a.mabs,c.hoten as tenbs,to_char(a.ngay,'dd/mm/yyyy') as ngay ";
                    sql += " from xxx.benhanpk a inner join " + user + ".btdkp_bv b on a.makp=b.makp left join " + user + ".dmbs c on a.mabs=c.ma where a.maql in ("+maso.Substring(0,maso.Length-1)+") order by a.maql";
                    foreach (DataRow r in d.get_data_mmyy(sql, s_tu, s_den, songayduyet).Tables[0].Rows)
                    {
                        r1 = m.getrowbyid(dst.Tables[0], "maql=" + decimal.Parse(r["maql"].ToString()));
                        if (r1 == null)
                        {
                            r2 = dst.Tables[0].NewRow();
                            r2["maql"] = decimal.Parse(r["maql"].ToString());
                            r2["maicd"] = r["maicd"].ToString();
                            r2["chandoan"] = r["chandoan"].ToString();
                            r2["mabs"] = r["mabs"].ToString();
                            r2["tenbs"] = r["tenbs"].ToString();
                            r2["makp"] = r["makp"].ToString();
                            r2["tenkp"] = r["tenkp"].ToString();
                            if (File.Exists("..\\..\\..\\chuky\\" + r["mabs"].ToString() + ".bmp"))
                            {
                                fstr = new FileStream("..\\..\\..\\chuky\\" + r["mabs"].ToString() + ".bmp", FileMode.Open, FileAccess.Read);
                                image = new byte[fstr.Length];
                                fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                                fstr.Close();
                                r2["Image"] = image;
                            }
                            dst.Tables[0].Rows.Add(r2);
                        }
                    }
                }
            }
            //gam 16/08/2011 chi phi van chuyen tinh theo the khai 100%
            string s_sothe_huong_cpvc = "";
            DataRow r23;
            decimal d_cpvc = 0;
            string s_vitri_xet_chiphivanchuyen = d.thetunguyen_vitri(1);
            int iKytubegin_xet_chiphivanchuyen = 0, ikytuend_xet_chiphivanchuyen = 0;
            try
            {
                iKytubegin_xet_chiphivanchuyen = int.Parse(s_vitri_xet_chiphivanchuyen.Substring(0, 1));
                ikytuend_xet_chiphivanchuyen = int.Parse(s_vitri_xet_chiphivanchuyen.Substring(2, 1));

            }
            catch
            {
                iKytubegin_xet_chiphivanchuyen = 0;
                ikytuend_xet_chiphivanchuyen = 2;
            }
            //end gam
            decimal d_congkham = (congkham == "") ? 0 : decimal.Parse(congkham);
            if (iMavp_congkham != 0 && d_congkham != 0)
            {
                int sl=1;
                if (bChuyenkham_congkham)
                {
                    sl = Math.Max(1,d.get_data_mmyy("select * from xxx.benhanpk where mabn='" + mabn + "' and mavaovien=" + mavaovien,s_tu,s_den,songayduyet).Tables[0].Rows.Count);
                }
                sql = "select 3 as id,0 as stt,0 as sttt,id as mabd,ma,ten,' ' as tenhc,dvt as dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,' ' as handung,' ' as losx,"+sl+" as soluong," + d_congkham + " as dongia," + sl*d_congkham + " as sotien,' ' as cachdung,0 as makho,0 as manguon,0 as nhomcc,";
                sql += "'" + mabs + "' as mabs,'" + chandoan + "' as chandoan,'"+tenkp+"' as tenkp,to_number('0') as maql,'"+s_makp+"' as makp,"+imaphu+" as madoituong ";
                //sql += "'' as makp,'' as tenkp,'" + mabs + "' as mabs,'' as tenbs,' ' as chandoan,' ' as maicd,0 as maql ";
                sql += ",null as hangsx, null as nuocsx ";
                sql += " from "+user+".v_giavp where id=" + iMavp_congkham;
                d.merge(ds1,d.get_data(sql));
            }			

            DataSet dstmp = ds1.Clone();
            dstmp.Merge(ds1.Tables[0].Select("true", "id,stt"));
            dsxmlin.Clear();
            string ns = "", _sothe = sothe, denngay = "", phai = "", diachi = "";
            if (maql != 0)
            {
                foreach (DataRow r in d.get_data_mmyy("select a.sothe,case when a.tungay is null then to_char(a.denngay,'dd/mm/yyyy') else to_char(a.denngay,'dd/mm/yyyy')||' '||to_char(a.tungay,'dd/mm/yyyy') end as denngay,b.tenbv, a.mabv from xxx.bhyt a left join " + user + ".dmnoicapbhyt b on a.mabv=b.mabv where a.maql=" + maql, s_tu, s_den, songayduyet).Tables[0].Rows) //(a.sudung is null or a.sudung=1) and
                {
                    if (_sothe == "") _sothe = r["sothe"].ToString();
                    denngay = r["denngay"].ToString();
                    tenbv = r["tenbv"].ToString() + "^" + r["mabv"].ToString();
                }
            }
            //gam 17/10/2011
            //sql = "select a.*,to_char(a.ngaysinh,'dd/mm/yyyy') as ns,b.sothe,case when b.tungay is null then to_char(b.denngay,'dd/mm/yyyy') else to_char(b.denngay,'dd/mm/yyyy')||' '||to_char(b.tungay,'dd/mm/yyyy') end as denngay,c.tenpxa,d.tenquan,e.tentt, b.mabv, dmnc.tenbv,g.dienthoai,f.sovaovien as sokham  ";
            //sql += "from " + user + ".btdbn a left join xxx.bhyt b on a.mabn=b.mabn inner join " + user + ".btdpxa c on a.maphuongxa=c.maphuongxa inner join " + user + ".btdquan d on a.maqu=d.maqu inner join " + user + ".btdtt e on a.matt=e.matt";
            //sql += " left join " + user + ".dmnoicapbhyt dmnc on b.mabv=dmnc.mabv ";
            //sql += "left join xxx.benhanpk f on b.maql=f.maql left join xxx.quanhe g on b.maql=g.maql ";
            //sql += " where a.mabn='" + mabn + "'";
            //sql += " order by b.maql desc";
            sql = "select a.*,to_char(a.ngaysinh,'dd/mm/yyyy') as ns,b.sothe,case when b.tungay is null then to_char(b.denngay,'dd/mm/yyyy') else to_char(b.denngay,'dd/mm/yyyy')||' '||to_char(b.tungay,'dd/mm/yyyy') end as denngay,c.tenpxa,d.tenquan,e.tentt, b.mabv, dmnc.tenbv,g.dienthoai,f.sovaovien as sokham  ";
            sql += ",dmnc.tenbv,g.dienthoai,f.sovaovien as sokham,n.tenbv as benhvien,n.mabv as mabenhvien,k.tenkp,k.makp,h.xutri,a.ngaysinh," + int.Parse(s_ngayvv.Substring(6, 4)) + "-to_number(a.namsinh,'0000') as tuoi ";
            sql += "from " + user + ".btdbn a left join xxx.bhyt b on a.mabn=b.mabn inner join " + user + ".btdpxa c on a.maphuongxa=c.maphuongxa inner join " + user + ".btdquan d on a.maqu=d.maqu inner join " + user + ".btdtt e on a.matt=e.matt";
            sql += " left join " + user + ".dmnoicapbhyt dmnc on b.mabv=dmnc.mabv ";
            sql += "left join xxx.benhanpk f on b.maql=f.maql left join xxx.quanhe g on b.maql=g.maql ";
            sql += "left join xxx.xutrikbct h on f.maql=h.maql left join " + user + ".chuyenvien i on f.maql=i.maql left join " + user + ".btdkp_bv k  on h.makp=k.makp left join " + user + ".dstt n on i.mabv=n.mabv";
            sql += " where a.mabn='" + mabn + "' and f.mavaovien="+mavaovien;
            sql += " union all ";
            sql += "select a.*,to_char(a.ngaysinh,'dd/mm/yyyy') as ns,b.sothe,case when b.tungay is null then to_char(b.denngay,'dd/mm/yyyy') else to_char(b.denngay,'dd/mm/yyyy')||' '||to_char(b.tungay,'dd/mm/yyyy') end as denngay,c.tenpxa,d.tenquan,e.tentt, b.mabv, dmnc.tenbv,g.dienthoai,f.sovaovien as sokham  ";
            sql += ",dmnc.tenbv,g.dienthoai,f.sovaovien as sokham,n.tenbv,n.mabv,k.tenkp,k.makp,h.xutri,a.ngaysinh," + int.Parse(s_ngayvv.Substring(6, 4)) + "-to_number(a.namsinh,'0000') as tuoi ";
            sql += "from " + user + ".btdbn a left join xxx.bhyt b on a.mabn=b.mabn inner join " + user + ".btdpxa c on a.maphuongxa=c.maphuongxa inner join " + user + ".btdquan d on a.maqu=d.maqu inner join " + user + ".btdtt e on a.matt=e.matt";
            sql += " left join " + user + ".dmnoicapbhyt dmnc on b.mabv=dmnc.mabv ";
            sql += "left join xxx.benhancc f on b.maql=f.maql left join xxx.quanhe g on b.maql=g.maql ";
            sql += "left join xxx.xutrikbct h on f.maql=h.maql left join " + user + ".chuyenvien i on f.maql=i.maql left join " + user + ".btdkp_bv k  on h.makp=k.makp left join " + user + ".dstt n on i.mabv=n.mabv";
            sql += " where a.mabn='" + mabn + "' and f.mavaovien=" + mavaovien;
            sql += " union all ";
            sql += "select a.*,to_char(a.ngaysinh,'dd/mm/yyyy') as ns,b.sothe,case when b.tungay is null then to_char(b.denngay,'dd/mm/yyyy') else to_char(b.denngay,'dd/mm/yyyy')||' '||to_char(b.tungay,'dd/mm/yyyy') end as denngay,c.tenpxa,d.tenquan,e.tentt, b.mabv, dmnc.tenbv,g.dienthoai,f.sovaovien as sokham  ";
            sql += ",dmnc.tenbv,g.dienthoai,f.sovaovien as sokham,n.tenbv,n.mabv,k.tenkp,k.makp,h.xutri,a.ngaysinh," + int.Parse(s_ngayvv.Substring(6, 4)) + "-to_number(a.namsinh,'0000') as tuoi ";
            sql += "from " + user + ".btdbn a left join " + user + ".bhyt b on a.mabn=b.mabn inner join " + user + ".btdpxa c on a.maphuongxa=c.maphuongxa inner join " + user + ".btdquan d on a.maqu=d.maqu inner join " + user + ".btdtt e on a.matt=e.matt";
            sql += " left join " + user + ".dmnoicapbhyt dmnc on b.mabv=dmnc.mabv ";
            sql += "left join " + user + ".benhanngtr f on b.maql=f.maql left join xxx.quanhe g on b.maql=g.maql ";
            sql += "left join xxx.xutrikbct h on f.maql=h.maql left join " + user + ".chuyenvien i on f.maql=i.maql left join " + user + ".btdkp_bv k  on h.makp=k.makp left join " + user + ".dstt n on i.mabv=n.mabv";
            sql += " where a.mabn='" + mabn + "' and f.mavaovien=" + mavaovien;
            //end gam 17/10/2011
            string ssodienthoai = "", ssokham = "",stuoi="",sngaysinh="";
            string schuyenvien = "", snhapvien = "";//gam 17/10/2011 thêm field lay ten benh vien khi xu tri chuyen vien va ten khoa phong neu xu tri nhap vien
            foreach (DataRow r in d.get_data_mmyy(sql,s_tu,s_den,songayduyet).Tables[0].Rows)
            {
                ns = (r["ns"].ToString()!="")?r["ns"].ToString():r["namsinh"].ToString();
                phai = (r["phai"].ToString() == "0") ? "Nam" : "Nữ";
                diachi = r["sonha"].ToString().Trim() + " " + r["thon"].ToString().Trim() + " " + r["tenpxa"].ToString().Trim() + " " + r["tenquan"].ToString().Trim() + " " + r["tentt"].ToString();//r["cholam"].ToString()+";"+
                if (_sothe != "" && r["sothe"].ToString()!="")
                {
                    _sothe = r["sothe"].ToString();
                    denngay = r["denngay"].ToString();
                    tenbv = r["tenbv"].ToString() + "^" + r["mabv"].ToString();
                }
                ssodienthoai = r["dienthoai"].ToString(); 
                ssokham = r["sokham"].ToString();
                schuyenvien += r["mabenhvien"].ToString() + "^" + r["benhvien"].ToString();
                snhapvien += r["makp"].ToString() + "^" + r["tenkp"].ToString();
                stuoi = r["tuoi"].ToString();
                sngaysinh = r["ngaysinh"].ToString();
                //break;
            }
            decimal tc = 0,tck=0,tcbn_ctthem=0,d_sotiendichvu=0;
            bool cstt = dstmp.Tables[0].Select("id=2").Length > 0;
            string s1 = m.get_tamung(mabn, mavaovien, s_ngay, 1, songayduyet+1);
            decimal tamung = decimal.Parse(s1.Substring(0, s1.IndexOf("^")));
            string stamung = s1.Substring(s1.IndexOf("^") + 1), s_doituong = "", s_tendichvu="";
            //
            bool bThuphi_dichvubhytduoi_100 = m.bThuphi_dichvubhytduoi_100;
            int tmp_madt = 2;
            string s_doituongtp = m.f_get_tendoituong(tmp_madt.ToString());
            decimal dg2 = 0, d_dongia2 = 0, d_dongia = 0;
            //
            int atylechitra = 0;
            //Thuy 09.04.2012 them field chiphivanchuyen bhyt tra 100% (cpvc_100)
            bool cpvc_100 = false;
            try
            {
                dsxmlin.Tables[0].Columns.Add("cpvc_100");
            }
            catch { }
            foreach (DataRow r in dstmp.Tables[0].Select("","madoituong"))
            {
                r2 = d.getrowbyid(dtdtf, "madoituong=" + int.Parse(r["madoituong"].ToString()));
                s_doituong = (r2 != null) ? r2["doituong"].ToString() : maphu;
                if (r["sttt"].ToString() == "0")
                {
                    r2 = m.getrowbyid(dtvpin, "id=" + int.Parse(r["mabd"].ToString()));
                    s_sothe_huong_cpvc = r2["sothe"].ToString();
                }
                else
                    r2 = m.getrowbyid(dtbd, "id=" + int.Parse(r["mabd"].ToString()));
                if (r2 != null)
                {
                    s_tendichvu = r["ten"].ToString();
                    if (r["tenhc"].ToString().Trim() != "") s_tendichvu += " [" + r["tenhc"].ToString().Trim() + "]";
                    d_sotiendichvu = decimal.Parse(r["sotien"].ToString());
                    d_dongia2 = decimal.Parse(r["dongia"].ToString());
                    d_dongia = decimal.Parse(r["dongia"].ToString());
                    dg2 = 0;
                    if (s_sothe_huong_cpvc != "" && _sothe != "" && r["madoituong"].ToString() == "1" && s_sothe_huong_cpvc.IndexOf(_sothe.Substring(iKytubegin_xet_chiphivanchuyen,ikytuend_xet_chiphivanchuyen)) >= 0)
                   {
                       d_cpvc += decimal.Parse(r["sotien"].ToString());
                       cpvc_100 = true;
                   }
                    else if (decimal.Parse(r2["bhyt"].ToString()) != 100 && int.Parse(r["madoituong"].ToString()) == 1)
                    {
                        tc += (int.Parse(r["madoituong"].ToString()) == 1) ? (decimal.Parse(r["sotien"].ToString()) * decimal.Parse(r2["bhyt"].ToString()) / 100) : 0;
                        tcbn_ctthem += decimal.Parse(r["sotien"].ToString()) * (100 - decimal.Parse(r2["bhyt"].ToString())) / 100;
                        d_sotiendichvu = decimal.Parse(r["sotien"].ToString()) * decimal.Parse(r2["bhyt"].ToString()) / 100;
                        s_tendichvu += " BHYT chỉ chi trả " + r2["bhyt"].ToString() + "%";
                        dg2 = decimal.Parse(r["sotien"].ToString()) * (100 - decimal.Parse(r2["bhyt"].ToString())) / 100;
                        d_dongia2 = decimal.Parse(r["dongia"].ToString()) * (100 - decimal.Parse(r2["bhyt"].ToString())) / 100;
                        d_dongia = decimal.Parse(r["dongia"].ToString()) * decimal.Parse(r2["bhyt"].ToString()) / 100;
                    }
                    else
                    {
                        tc += (int.Parse(r["madoituong"].ToString()) == 1) ? decimal.Parse(r["sotien"].ToString()) : 0;
                    }
                    //tc += (int.Parse(r["madoituong"].ToString()) == 1) ? decimal.Parse(r["sotien"].ToString()) : 0;
                    tck += (int.Parse(r["madoituong"].ToString()) != 1) ? decimal.Parse(r["sotien"].ToString()) : 0;
                    //
                    //
                    if (traituyen != 0 && iTraituyen != 0 && r["madoituong"].ToString() == "1")
                    {
                        if (bBHYT_Traituyen_tinh_Tyle_khac)
                        {
                            if (decimal.Parse(r2["bhyt_tt"].ToString()) < 100 && decimal.Parse(r2["bhyt_tt"].ToString())>0) //if (decimal.Parse(r2["bhyt"].ToString()) > decimal.Parse(r2["bhyt_tt"].ToString()))
                            {
                                d_dichvu_tt += decimal.Parse(r["sotien"].ToString());
                                d_dichvu_tt_BH_tra += decimal.Parse(r["dongia"].ToString()) * decimal.Parse(r2["bhyt_tt"].ToString()) / 100;
                                d_dichvu_tt_BN_tra += decimal.Parse(r["dongia"].ToString()) * (100 - decimal.Parse(r2["bhyt_tt"].ToString())) / 100;
                                decimal dggoc = decimal.Parse(r["dongia"].ToString()) * 100 / decimal.Parse(r2["bhyt_tt"].ToString());
                                s_tendichvu += " [BN Trái tuyến, BHYT chi trả " + decimal.Parse(r2["bhyt_tt"].ToString()).ToString("###") + "% của giá: " + dggoc.ToString("###,###,###") + "]";
                            }
                        }
                    }
                    //
                    //binh 070711
                    a_sttbhyt = (r2["sttbhyt"].ToString() == "") ? 0 : int.Parse(r2["sttbhyt"].ToString());
                    a_idnhombhyt = (r2["idnhombhyt"].ToString() == "") ? 0 : int.Parse(r2["idnhombhyt"].ToString());
                    a_tennhombhyt = r2["tennhombhyt"].ToString();
                    //
                    //
                    s_cachdung = r["cachdung"].ToString();
                    //gam 07/11/2011  s_ngay,s_ngay
                    m.updrec_ravien(dsxmlin, mabn, mabn, decimal.Parse(r["maql"].ToString()), 0, hoten, ns, phai, diachi.Trim()+"^"+cholam.Trim(),int.Parse(r["madoituong"].ToString()),
                        s_doituong, _sothe, 0, denngay, tenbv+"^"+s_tentuyentruoc,r["mabs"].ToString(),s_tenbs,r["makp"].ToString(),r["tenkp"].ToString(),
                        (s_ngayvv == "" ? s_ngay : s_ngayvv), (s_ngayrv == "" ? s_ngay : s_ngayrv), s_chandoan, s_maicd, int.Parse(r2["sttnhom"].ToString()),
                        r2["nhom"].ToString(), int.Parse(r2["sttloai"].ToString()), r2["loai"].ToString(),
                        int.Parse(r["mabd"].ToString()), s_tendichvu , r["dang"].ToString(),
                        decimal.Parse(r["soluong"].ToString()), d_sotiendichvu,
                        0, tamung, d_congkham, m.get_nguoinha(s_mmyy, mabn, maql), 1, (makp != "") ? m.phuongphapdieutri(makp) : 0, 0, (cstt) 
                        ? "x^" + s_soluutru + "^" + s_chandoan : "^" + s_soluutru + "^" + s_chandoan, d_dongia, bInchiphi_chandoan_bacsy,
                        0, "", "", "", r["hangsx"].ToString() + "^" + r["nuocsx"].ToString(), imaphu, (decimal.Parse(r["soluong"].ToString()) != 0)
                        ? decimal.Parse(r["sotien"].ToString()) / decimal.Parse(r["soluong"].ToString()) : 0, 0, d_sotiendichvu, traituyen,
                        int.Parse(r2["kythuat"].ToString()),a_sttbhyt,a_idnhombhyt,a_tennhombhyt );
                   

                    //
                    if (dg2 != 0)
                    {
                        if (decimal.Parse(r2["bhyt"].ToString()) != 100)
                        {
                            s_tendichvu += " BN chi trả " + (100 - decimal.Parse(r2["bhyt"].ToString())).ToString() + "%";
                            if (m.bThuphi_dichvubhytduoi_100) { tmp_madt = 2; s_doituong = s_doituongtp; }
                            else { tmp_madt = m.iTunguyen; s_doituong = m.f_get_tendoituong(tmp_madt.ToString()); }
                        }
                        else
                        {
                            tmp_madt = int.Parse(r["madoituong"].ToString());
                        }
                        m.updrec_ravien(dsxmlin, mabn, mabn, decimal.Parse(r["maql"].ToString()), 0, hoten, ns, phai, diachi.Trim() + "^" + cholam.Trim(), tmp_madt,
                        s_doituong, _sothe, 0, denngay, tenbv + "^" + s_tentuyentruoc, r["mabs"].ToString(), s_tenbs, r["makp"].ToString(), r["tenkp"].ToString(),
                        (s_ngayvv == "" ? s_ngay : s_ngayvv), (s_ngayrv == "" ? s_ngay : s_ngayrv), s_chandoan, s_maicd, int.Parse(r2["sttnhom"].ToString()),
                        r2["nhom"].ToString(), int.Parse(r2["sttloai"].ToString()), r2["loai"].ToString(),
                        int.Parse(r["mabd"].ToString()), s_tendichvu, r["dang"].ToString(),
                        decimal.Parse(r["soluong"].ToString()), dg2,
                        0, tamung, d_congkham, m.get_nguoinha(s_mmyy, mabn, maql), 1, (makp != "") ? m.phuongphapdieutri(makp) : 0, 0, (cstt) ? "x^" + s_soluutru + "^" + s_chandoan : "^" + s_soluutru + "^" + s_chandoan, d_dongia2, bInchiphi_chandoan_bacsy, 0, "", "", "", r["hangsx"].ToString() + "^" + r["nuocsx"].ToString(), imaphu, (decimal.Parse(r["soluong"].ToString()) != 0) ? decimal.Parse(r["sotien"].ToString()) / decimal.Parse(r["soluong"].ToString()) : 0, 0, dg2, traituyen, int.Parse(r2["kythuat"].ToString()), a_sttbhyt, a_idnhombhyt, a_tennhombhyt);

                        
                    }
                    //Thuy 09.04.2012
                    foreach(DataRow r_r in dsxmlin.Tables[0].Select("ma="+r["mabd"].ToString()))
                    {
                        r_r["cpvc_100"] = cpvc_100;
                    }
                }
                

            }
            //
            //
            if (m.bInmau38_daydu)
            {                
                DataSet ads1 = d.get_data("select a.stt, a.ma, a.ten, a.idnhombhyt, b.stt as sttbhyt, b.ten as tennhombhyt from " + user + ".v_nhomvp a, "+user+".v_nhombhyt b where a.idnhombhyt=b.id ");
                foreach (DataRow rdt in dtdt.Select("madoituong=1"))
                {
                    DataRow[] a_dr = dsxmlin.Tables[0].Select("madoituong=" + rdt["madoituong"].ToString());
                    if (a_dr.Length > 0)
                    {
                        foreach (DataRow adr in ads1.Tables[0].Rows)
                        {
                            //binh 070711
                            a_sttbhyt = (adr["sttbhyt"].ToString() == "") ? 0 : int.Parse(adr["sttbhyt"].ToString());
                            a_idnhombhyt = (adr["idnhombhyt"].ToString() == "") ? 0 : int.Parse(adr["idnhombhyt"].ToString());
                            a_tennhombhyt = adr["tennhombhyt"].ToString();
                            //
                            string s_exp = " madoituong=" + rdt["madoituong"].ToString() + " and sttnhom=" + adr["stt"].ToString();
                            DataRow adr1 = d.getrowbyid(dsxmlin.Tables[0], s_exp);
                            if (adr1 == null)
                            {
                                m.updrec_ravien(dsxmlin, mabn, mabn, decimal.Parse(a_dr[0]["maql"].ToString()), 0, hoten, ns, phai, diachi.Trim() + "^" + cholam.Trim(), int.Parse(rdt["madoituong"].ToString()), rdt["doituong"].ToString(), _sothe, 0, denngay, tenbv + "^" + s_tentuyentruoc, a_dr[0]["mabs"].ToString(), s_tenbs, a_dr[0]["makp"].ToString(), a_dr[0]["tenkp"].ToString(),
                                     s_ngay, s_ngay, s_chandoan, s_maicd, int.Parse(adr["stt"].ToString()), adr["ten"].ToString(), 0, "",
                                     0, "", "", 0, 0, 0, tamung, d_congkham, m.get_nguoinha(s_mmyy, mabn, maql), 1, (makp != "") ? m.phuongphapdieutri(makp) : 0, 0, (cstt) ? "x^" + s_soluutru + "^" : "^" + s_soluutru + "^", 0, bInchiphi_chandoan_bacsy, 0, "", "", "", "^", imaphu, 0, 0, 0, traituyen, -1, a_sttbhyt, a_idnhombhyt, a_tennhombhyt);
                                
                            }
                        }
                    }
                }
            }
            //
            int _maphu = d.get_maphu_ngtru(_sothe,tc, i_nhom);
            string sovaovien="";
            if (i_loaiba == 3)
            {
                sql = "select b.soluutru from " + user + s_mmyy + ".benhanpk a," + user + s_mmyy + ".lienhe b where a.maql=b.maql and a.mabn='" + mabn + "'";
            }
            DataSet lds11 = d.get_data(sql);
            if (lds11 == null || lds11.Tables.Count <= 0 || lds11.Tables[0].Rows.Count<=0)
            {
                sovaovien = "";
            }
            else
                sovaovien = lds11.Tables[0].Rows[0]["soluutru"].ToString();
            
            string chu = doiso.doithapphan(tc.ToString()),chuk = doiso.doithapphan(tck.ToString());
            bool bFound = false, bUserid = false;
            if (File.Exists("..\\..\\..\\chukyuser\\" + i_userid.ToString() + ".bmp"))
            {
                fstr = new FileStream("..\\..\\..\\chukyuser\\" + i_userid.ToString() + ".bmp", FileMode.Open, FileAccess.Read);
                imageuser = new byte[fstr.Length];
                fstr.Read(imageuser, 0, System.Convert.ToInt32(fstr.Length));
                fstr.Close();
                bUserid = true;
            }
            //gam 08-03-2011
            atylechitra = d.get_maphu(_sothe);
            try
            {
                dsxmlin.Tables[0].Columns.Add("tylechitra");
                dsxmlin.Tables[0].Columns.Add("sokham");
                dsxmlin.Tables[0].Columns.Add("dienthoai");
                dsxmlin.Tables[0].Columns.Add("sovaovien");
                dsxmlin.Tables[0].Columns.Add("tyletra", typeof(decimal)).DefaultValue = 0;
            }
            catch { }
            try
            {
                dsxmlin.Tables[0].Columns.Add("chuyenvien");
                dsxmlin.Tables[0].Columns.Add("nhapvien");
                dsxmlin.Tables[0].Columns.Add("thangtuoi");
            }
            catch { }
            try
            {
                dsxmlin.Tables[0].Rows[0]["sovaovien"] = sovaovien;
            }
            catch { }

            try
            {
                dsxmlin.Tables[0].Columns.Add("trieuchung");
            }
            catch { }
            try
            {
                dsxmlin.Tables[0].Columns.Add("cdkemtheo");
            }
            catch { }
            string s_trieuchung = "";
            s_trieuchung = m.get_trieuchung(s_ngay, l_maql);
            string s_cdkemtheo = "";
            if (s_trieuchung == "") // truongthuy 10062014 đối với BN phòng khám xứ trí ngoại trú trong ngoại trú chọn F10 thì lấy triệu chứng tại xxx.lydokham
            {
                foreach (DataRow r in d.get_data("select b.lydo from " + user + s_mmyy + ".benhanpk a inner join " + user + s_mmyy + ".lydokham b on a.maql=b.maql   where a.mabn=" + s_mabn + "").Tables[0].Rows)
                {


                    s_trieuchung = r["lydo"].ToString();

                }
            }
            foreach (DataRow r in d.get_data("select b.chandoan from "+user+s_mmyy+".benhanpk a inner join "+user+s_mmyy+".cdkemtheo b on a.maql=b.maql   where a.mabn="+s_mabn+"").Tables[0].Rows)
            {

                s_cdkemtheo = r["chandoan"].ToString();

            }
            foreach (DataRow r in dsxmlin.Tables[0].Select("","madoituong"))
            {
                r23 = m.getrowbyid(dtvpin,"id="+r["ma"].ToString());
                if (r23 != null)
                {
                    s_sothe_huong_cpvc = r23["sothe"].ToString();
                }
                chitra = 100;
                r["idkhoa"] = isophieu;
                r["tcsotien"] = ((int.Parse(r["madoituong"].ToString()) == 1) ? tc : tck )+ d_cpvc;//gam 16/08/2011
                r["dichso"] = (int.Parse(r["madoituong"].ToString()) == 1) ? chu : chuk;
                r["tenuser"] = s_userid;
                r["chandoan"] = s_chandoan;
                r["tylechitra"] = atylechitra == 0 || r["cpvc_100"].ToString() == "True" || (int.Parse(r["madoituong"].ToString()) == 3) ? "BHYT 100%" : atylechitra == 1 ? "BHYT 80%" : atylechitra == 2 ? "BHYT 95%" : "";
                r["sokham"] = ssokham;
                r["sotoa"] = m_stttoa;
                r["dienthoai"] = ssodienthoai;
                r["tyletra"] = 0;
                r["chuyenvien"] = schuyenvien;
                r["nhapvien"] = snhapvien;
                r["trieuchung"] = s_trieuchung;
                r["cdkemtheo"] = s_cdkemtheo;
                //gam 16/08/2011 chi phi van chuyen tinh theo the khai 100%
                
                //if (s_sothe_huong_cpvc != ""  && _sothe != "" && s_sothe_huong_cpvc.IndexOf(_sothe.Substring(iKytubegin_xet_chiphivanchuyen, ikytuend_xet_chiphivanchuyen)) >= 0)
                //{
                //    r["bhyttra"] = decimal.Parse(r["sotien"].ToString());
                //    r["bntra"] = 0;
                //    r["tylechitra"] = "BHYT 100%";
                //    r["tcsotien"] = ((int.Parse(r["madoituong"].ToString()) == 1) ? tc : tck )+ d_cpvc;//gam 16/08/2011
                //}
                if (_sothe != "" && int.Parse(r["madoituong"].ToString())==1)
                {
                    if (int.Parse(r["traituyen"].ToString()) != 0 && iTraituyen != 0 && !bTraituyen_bhtra)
                    {
                        chitra = iTraituyen;
                        r["bhyttra"] = d_cpvc + ((tc - d_dichvu_tt) * chitra / 100 + d_dichvu_tt_BH_tra);
                        r["bntra"] = (tc - d_dichvu_tt) - ((tc - d_dichvu_tt) * chitra / 100) + tcbn_ctthem + d_dichvu_tt_BN_tra;
                        //gam 21/09/2011
                        r2 = m.getrowbyid(dtvpin, "id=" + int.Parse(r["ma"].ToString()));
                        if (r2 != null && (100 > decimal.Parse(r2["bhyt_tt"].ToString()) && decimal.Parse(r2["bhyt_tt"].ToString()) > 0))
                        {
                            chitra = decimal.Parse(r2["bhyt_tt"].ToString());
                        }
                    }
                    else if (int.Parse(r["traituyen"].ToString()) != 0 && iTraituyen != 0 && bTraituyen_bhtra)
                    {
                        //chitra = iTraituyen;
                        chitra = ((_maphu == 1) ? 80 : (_maphu == 2) ? 95 : 100);
                        chitra = chitra * (decimal.Parse(iTraituyen.ToString()) / 100);
                        r["bhyttra"] = d_cpvc + ((tc - d_dichvu_tt) * chitra / 100 + d_dichvu_tt_BH_tra );//gam 16/08/2011
                        r["bntra"] = (tc - d_dichvu_tt) - ((tc - d_dichvu_tt) * chitra / 100) + tcbn_ctthem + d_dichvu_tt_BN_tra;
                    }
                    else if (Bhyt_7cn != 0 && tc > Bhyt_7cn)
                    {
                        r["bhyttra"] = Bhyt_7cn + d_cpvc;
                        r["bntra"] = tc-Bhyt_7cn;
                    }
                    else
                    {
                        if (_maphu !=0)
                        {
                            chitra = (_maphu == 1) ? 80 : 95;
                            r["bhyttra"] = d_cpvc + (tc * chitra / 100 );//gam 16/08/2011
                            r["bntra"] = tc - (tc * chitra / 100) + tcbn_ctthem;
                        }
                        else
                        {
                            r["bhyttra"] = tc + d_cpvc;//gam 16/08/2011 
                            r["bntra"] = 0;
                            //chitra = 100;
                        }
                        if (lTraituyen != 0 && decimal.Parse(r["bhyttra"].ToString()) > lTraituyen && int.Parse(r["traituyen"].ToString()) != 0)
                        {
                            r["bhyttra"] = lTraituyen + d_cpvc;//gam 16/08/2011
                            r["bntra"] = tc - lTraituyen;
                        }
                    }
                    //Thuy 09.04.2012
                    if (r["cpvc_100"].ToString() == "True")
                    {
                        r["tyletra"] = 100;
                    }
                    else
                    {
                        r["tyletra"] = chitra;
                    }
                    //
                }
                if (bInchiphi_chandoan_bacsy)
                {
                    r1 = m.getrowbyid(dst.Tables[0], "maql=" + decimal.Parse(r["maql"].ToString()));
                    if (r1 != null)
                    {
                        r["maicd"] = r1["maicd"].ToString();
                        r["chandoan"] = r1["chandoan"].ToString();
                        r["mabs"] = r1["mabs"].ToString();
                        r["tenbs"] = r1["tenbs"].ToString();
                        r["image"] = r1["image"];
                        r["tenkp"] = r1["tenkp"].ToString();
                    }
                    else
                    {
                        r1 = m.getrowbyid(dst.Tables[0], "makp='" + r["makp"].ToString() + "'");
                        if (r1 != null)
                        {
                            r["maicd"] = r1["maicd"].ToString();
                            r["chandoan"] = r1["chandoan"].ToString();
                            r["mabs"] = r1["mabs"].ToString();
                            r["tenbs"] = r1["tenbs"].ToString();
                            r["image"] = r1["image"];
                            r["tenkp"] = r1["tenkp"].ToString();
                        }
                        else if (File.Exists("..\\..\\..\\chuky\\" + r["noicap"].ToString() + ".bmp"))
                        {
                            fstr = new FileStream("..\\..\\..\\chuky\\" + r["noicap"].ToString() + ".bmp", FileMode.Open, FileAccess.Read);
                            image = new byte[fstr.Length];
                            fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                            fstr.Close();
                            r["Image"] = image;
                            r["tenbs"] = tenbs;
                        }
                        else r["tenbs"] = tenbs;
                    }
                }
                else
                {
                    if (File.Exists("..\\..\\..\\chuky\\" + r["noicap"].ToString() + ".bmp"))
                    {
                        fstr = new FileStream("..\\..\\..\\chuky\\" + r["noicap"].ToString() + ".bmp", FileMode.Open, FileAccess.Read);
                        image = new byte[fstr.Length];
                        fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                        fstr.Close();
                        r["Image"] = image;
                        bFound = true;
                    }
                    else if (bFound) r["Image"] = image;
                }
                if (bUserid) r["imageuser"] = imageuser;
                r["maql"] = lanin;
                r["sbltamung"] = stamung;
            }
            //thêm số tháng
            if (stuoi != "")
            {
                if (int.Parse(stuoi) <= 6 && sngaysinh != "")
                {
                    long songay = m.songay(m.StringToDateTime(s_ngayvv), DateTime.Parse(sngaysinh), 0);
                    long sothang = songay / 30;
                    foreach (DataRow r in dsxmlin.Tables[0].Rows) r["thangtuoi"] = sothang.ToString();
                }
            }
            if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
            dsxmlin.WriteXml("..\\xml\\cpbhyt.xml", XmlWriteMode.WriteSchema);
            if (chkXem.Checked)
            {
                frmReport f = new frmReport(d, dsxmlin.Tables[0], i_userid ,s_tenkp, "rpt_ttravien_bh.rpt",soban.Value);
                f.ShowDialog();
            }
            else
            {
                ReportDocument oRpt = new ReportDocument();
                oRpt.Load("..\\..\\..\\report\\rpt_ttravien_bh.rpt", OpenReportMethod.OpenReportByTempCopy);
                oRpt.SetDataSource(dsxmlin.Tables[0]);
                oRpt.DataDefinition.FormulaFields["SoYTe"].Text = "'" + d.Syte + "'";
                oRpt.DataDefinition.FormulaFields["BenhVien"].Text = "'" + d.Tenbv + "'";
                oRpt.DataDefinition.FormulaFields["TenBenhAn"].Text = "'" + s_tenkp + "'";
                oRpt.PrintToPrinter(Convert.ToInt32(soban.Value), false, 0, 0);
                oRpt.Close(); oRpt.Dispose();
            }
        }

        private void butList_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (checkBox1.Checked) load_ck();
            else load_grid(""); 
            if (tim.Text.Trim() != "" && tim.Text.Trim() != "Tìm kiếm") refresh_list(tim.Text.Trim());
            Cursor = Cursors.Default;
        }

        private void chkDonChiphi_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkDonChiphi && chkDonChiphi.Checked)
            {
                chkChiphi.Checked = false;
                m.writeXml("d_thongso", "dbhyt", (chkDonChiphi.Checked) ? "1" : "0");
            }
        }

        private void chkChiphi_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkChiphi && chkChiphi.Checked)
            {
                chkDonChiphi.Checked = false;
                m.writeXml("d_thongso", "dbhyt", (chkChiphi.Checked) ? "0" : "1");
            }
        }
        private void kiemtra_duyet(decimal id)
        {
            if (d.get_done_thuocbhyt(s_ngay, id))
            {
                string s_tu = m.DateToString("dd/MM/yyyy", m.StringToDate(s_ngay).AddDays(-1 * songayduyet));
                string s_den = s_ngay;
                if (d.get_data_mmyy("select * from xxx.bhytkb where id=" + id, s_tu, s_den, songayduyet).Tables[0].Rows.Count == 0)
                {
                    d.execute_data("update " + xxx + ".d_thuocbhytct set slthuc=0 where id=" + id);
                    d.execute_data("update " + xxx + ".d_thuocbhytll set done=0 where id=" + id);
                }
            }
        }

        private void butAll_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count <= 0 && tim.Text.Trim().Length == 8) load_grid(tim.Text.Trim());
            Cursor = Cursors.WaitCursor;
            string sql1 = "chon=false";
            if (tim.Text != "")
                sql1 += " and (hoten like '%" + tim.Text.Trim() + "%' or sothe like '%" + tim.Text.Trim() + "%' or mabn like '%" + tim.Text.Trim() + "%' or tenkp like '%" + tim.Text.Trim() + "%')";
            /*
            if (tim.Text.Trim().Length == 8 && dt.Select(sql1).Length == 0)
            {
                bool bFound = false;
                foreach (DataRow r in m.get_data("select * from " + xxx + ".d_thuocbhytll where mabn='" + tim.Text + "' and to_char(ngay,'dd/mm/yyyy')='" + s_ngay + "' and done=1").Tables[0].Rows)
                {
                    kiemtra_duyet(decimal.Parse(r["id"].ToString()));
                    bFound = true;
                }
                if (bFound) load_grid(tim.Text);
            }*/
            foreach (DataRow r1 in dt.Select(sql1))
            {
                l_id = decimal.Parse(r1["id"].ToString());
                s_makp = r1["makp"].ToString();
                s_mabn = r1["mabn"].ToString();
                l_maql = decimal.Parse(r1["maql"].ToString());
                _madoituong = int.Parse(r1["madoituong"].ToString());
                l_mavaovien = decimal.Parse(r1["mavaovien"].ToString());
                load_dtct();
                foreach (DataRow r in dtct.Rows)
                    updrec_thuocbhytct(ds.Tables[0],r["mabn"].ToString(),r["ngay"].ToString(), dataGrid1[i_row, 3].ToString(), l_id, (r["stt"].ToString()=="")?1:int.Parse(r["stt"].ToString()), decimal.Parse(r["sttt"].ToString()), int.Parse(r["mabd"].ToString()),
                      r["ma"].ToString(), r["ten"].ToString(), r["tenhc"].ToString(), r["dang"].ToString(), r["tenkho"].ToString(),
                      r["tennguon"].ToString(), r["maql"].ToString(), r["handung"].ToString(), r["losx"].ToString(), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()),
                      decimal.Parse(r["sotien"].ToString()), r["cachdung"].ToString(), int.Parse(r["makho"].ToString()), int.Parse(r["manguon"].ToString()), int.Parse(r["nhomcc"].ToString()),r["ngayud"].ToString(),int.Parse(r["done"].ToString()));

                r1["chon"] = true;                
            }
            Cursor = Cursors.Default;
            butIn.Focus();
        }

        private void tim_Enter(object sender, EventArgs e)
        {
            tim.Text="";
        }

        private void chkcls_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkcls) d.writeXml("d_thongso", "duyetcls", (chkcls.Checked) ? "1" : "0");
        }

        private void chkNhapvien_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkNhapvien) d.writeXml("d_thongso", "duyetnv", (chkNhapvien.Checked) ? "1" : "0");
        }
            
        private void chkKodichvu_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkKodichvu) d.writeXml("d_thongso", "Kodichvu", (chkKodichvu.Checked) ? "1" : "0");
        }
        public void updrec_thuocbhytct(DataTable dt,string mabn,string ngay,string hoten, decimal id, decimal stt, decimal sttt, 
            int mabd, string ma, string ten, string tenhc, string dang, string tenkho, string tennguon, string tennhomcc, 
            string handung, string losx, decimal soluong, decimal dongia, decimal sotien, string cachdung, int makho, 
            int manguon, int nhomcc, string ngayud, int done)
        {
            string exp = "sttt='" + sttt+"'";
            if (sttt == 0) exp += " and stt=" + stt;
            exp += " and mabd=" + mabd + " and mabn='" + mabn + "' and ngay='" + ngay + "'";
            exp += " and ngayud='" + ngayud + "'";
            DataRow r = d.getrowbyid(dt, exp); 
            if (r == null)
            {
                DataRow nrow = dt.NewRow();
                nrow["hoten"] = hoten;
                nrow["id"] = id;
                nrow["mabn"] = mabn;
                nrow["ngay"] = ngay;
                nrow["ngayud"] = ngayud;
                nrow["stt"] = stt;
                nrow["sttt"] = sttt;
                nrow["mabd"] = mabd;
                nrow["ma"] = ma;
                nrow["ten"] = ten;
                nrow["tenhc"] = tenhc;
                nrow["dang"] = dang;
                nrow["tenkho"] = tenkho;
                nrow["tennguon"] = tennguon;
                nrow["tennhomcc"] = tennhomcc;
                nrow["handung"] = handung;
                nrow["losx"] = losx;
                nrow["soluong"] = soluong;
                nrow["dongia"] = dongia;
                nrow["sotien"] = sotien;
                nrow["cachdung"] = cachdung;
                nrow["makho"] = makho;
                nrow["manguon"] = manguon;
                nrow["nhomcc"] = nhomcc;
                nrow["chon"] = false;
                nrow["done"] = done;
                dt.Rows.Add(nrow);
            }
            else
            {
                DataRow[] dr = dt.Select(exp);
                dr[0]["sttt"] = sttt;
                dr[0]["mabd"] = mabd;
                dr[0]["ma"] = ma;
                dr[0]["ten"] = ten;
                dr[0]["tenhc"] = tenhc;
                dr[0]["dang"] = dang;
                dr[0]["tenkho"] = tenkho;
                dr[0]["tennguon"] = tennguon;
                dr[0]["tennhomcc"] = tennhomcc;
                dr[0]["handung"] = handung;
                dr[0]["losx"] = losx;
                dr[0]["soluong"] = soluong;
                dr[0]["dongia"] = dongia;
                dr[0]["sotien"] = sotien;
                dr[0]["cachdung"] = cachdung;
                dr[0]["makho"] = makho;
                dr[0]["manguon"] = manguon;
                dr[0]["nhomcc"] = nhomcc;
                dr[0]["chon"] = false;
                dr[0]["done"] = done;
            }
        }

        private string check_mabn_chuaduyet()
        {
            string s_mabn = "";
            bool bln = false;
            foreach (DataRow r in dt.Select("chon=true"))
            {
                s_mabn = r["mabn"].ToString();
                foreach (DataRow dr in dt.Select("mabn='" + s_mabn + "' and chon=false"))
                {
                    bln = true;
                    break;
                }
                if (bln) break;
            }
            return (bln) ? s_mabn : "";
        }
        private void f_load_option()
        {
            bThuchenhlechtruoc_duyettoasau = d.bThuchenhlechtruoc_duyettoasau(i_nhom);
            bLaygiamua_khi_giabh_0_giabh_nho_giamua = d.bLaygiamua_khi_giabh_0_giabh_nho_giamua;
            bBHYT_Traituyen_tinh_Tyle_khac = m.bBHYT_Traituyen_tinh_Tyle_khac;
            bTraituyen_bhtra = m.bTraituyen_bhtra;//True: BHYT trai tuyen chi tinh tren tong chi phi BHYT thanh toan sau khi tinh theo ty le the
            bBhyt_tra_1_congkham = m.bBH_chitra_1congkham_conlaikhongtinh_G79_1 || m.bBH_chitra_1congkham;
            i_quyen_duyetmau38 = d.f_quyet_duyet_mau38(i_nhom, i_userid);
            bkhongChoDuyetToaBNHen_E8 = d.bkhongChoDuyetToaBNHen_E8(i_nhom);
        }

        private void refresh_list(string s_tim)
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
            DataView dv = (DataView)cm.List;
            sql = "hoten like '%" + s_tim + "%' or sothe like '%" + s_tim + "%' or mabn like '%" + s_tim + "%'";
            if (s_tim != "")
            {
                dv.RowFilter = sql;
                if (dt.Select(sql).Length == 0)
                {
                    bool bFound = false;
                    foreach (DataRow r in m.get_data("select * from " + xxx + ".d_thuocbhytll where mabn like '%" + s_tim + "%' and to_char(ngay,'dd/mm/yyyy')='" + s_ngay + "' and done=1").Tables[0].Rows)
                    {
                        kiemtra_duyet(decimal.Parse(r["id"].ToString()));
                        bFound = true;
                    }
                    if (bFound) load_grid(s_tim );
                }
            }
            else
                dv.RowFilter = "";
        }

        private bool bBN_Chuakhamxong(string d_mmyy, string d_mavaovien)
        {
            bool bln = false;
            sql = "select a.maql, a.mabn from " + user + d_mmyy + ".benhanpk a left join " + user + d_mmyy + ".xutrikbct b on a.maql=b.maql where b.maql is null and a.mavaovien=" + d_mavaovien;
            DataSet lds = d.get_data(sql);
            if (lds == null || lds.Tables.Count <= 0)
                bln = false;
            else if (lds.Tables[0].Rows.Count > 0) bln = true;
            return bln;
        }
        private void get_chandoan_chinh(string mmyy, int d_loaiba, decimal d_mavaovien, string d_mabn, string d_makp, ref string d_chandoan, ref string d_icd)
        {
            DataSet lds=new DataSet();
            switch (d_loaiba)
            {
                case 1:
                    sql = "select a.chandoan, a.maicd from " + user + ".nhapkhoa a, " + user + ".benhandt b where a.maql=b.maql and b.mavaovien=" + d_mavaovien + " and a.mabn='" + d_mabn + "' and a.makp='" + d_makp + "' order by maql desc, a.id desc";
                    lds = d.get_data(sql);
                    break;
                case 2:
                    sql = "select chandoan, maicd from " + user + ".benhanngtr where mavaovien=" + d_mavaovien + " and mabn='" + d_mabn + "' and makp='" + d_makp + "' ";
                    if (d.bMmyy(mmyy))
                    {
                        sql += "union all ";
                        sql += "select chandoan, maicd from " + user + mmyy + ".benhanngpk where mavaovien=" + d_mavaovien + " and mabn='" + d_mabn + "' and makp='" + d_makp + "' ";
                    }
                    lds = d.get_data(sql);
                    break;
                case 3:
                    if (d.bMmyy(mmyy))
                    {
                        sql = "select chandoan, maicd from " + user + mmyy + ".benhanpk where mavaovien=" + d_mavaovien + " and mabn='" + d_mabn + "' and makp='" + d_makp + "' ";
                        sql += " union all select chandoan,maicd from " + user + m.Mmyy_truoc(mmyy) + ".benhanpk where mavaovien=" + d_mavaovien + " and mabn='" + d_mabn + "' and makp='" + d_makp + "' ";
                        lds = d.get_data(sql);
                    }
                    break;
                case 4:
                    if (d.bMmyy(mmyy))
                    {
                        sql = "select chandoan, maicd from " + user + mmyy + ".benhancc where mavaovien=" + d_mavaovien + " and mabn='" + d_mabn + "' and makp='" + d_makp + "' order by maql desc";
                        lds = d.get_data(sql);
                    }
                    break;
                default:
                    if (d.bMmyy(mmyy))
                    {
                        sql = "select chandoan, maicd from " + user + mmyy + ".benhanpk where mavaovien=" + d_mavaovien + " and mabn='" + d_mabn + "' and makp='" + d_makp + "' order by maql desc";
                        lds = d.get_data(sql);
                    }
                    break;

            }
            if (lds == null || lds.Tables.Count <= 0 || lds.Tables[0].Rows.Count <= 0) { d_chandoan = ""; d_icd = ""; }
            else
            {
                d_chandoan = lds.Tables[0].Rows[0]["chandoan"].ToString();
                d_icd = lds.Tables[0].Rows[0]["maicd"].ToString();
            }
        }

        private void dataGrid2_Navigate(object sender, NavigateEventArgs ne)
        {

        }

        private void dataGrid1_Navigate(object sender, NavigateEventArgs ne)
        {

        }
        private void f_tinhtongtien(string a_mabn, decimal a_maql, decimal a_mavaovien)
        {
            lblTongtien.Text = "";
            DataRow dr = d.getrowbyid(dt, "mabn='" + a_mabn + "' and maql='" + a_maql + "'");
            if (dr != null)
            {
                string d_sothe = dr["sothe"].ToString();
                int d_traituyen = (dr["traituyen"].ToString() == "") ? 0 : int.Parse(dr["traituyen"].ToString());
                if (d_traituyen > 1) d_traituyen = 1;
                //
                decimal d_tongtien = 0, d_bhyttra = 0, d_bntra = 0, d_chiphibhyt_khongtra = 0;
                foreach (DataRow r in dtct.Rows)
                {
                    //
                    d_tongtien += (r["sotien"].ToString() == "") ? 0 : decimal.Parse(r["sotien"].ToString());
                    //
                }
                int i_tyle = 0;
                if (d_sothe.Trim() != "")
                {
                    if (d_traituyen == 0)
                    {
                        i_tyle = d.get_maphu_ngtru(d_sothe, d_tongtien, i_nhom);
                        if (i_tyle == 1) i_tyle = 80;
                        else if (i_tyle == 2) i_tyle = 95;
                        else i_tyle = 100;
                    }
                    else
                    {
                        i_tyle = m.iTraituyen_bhyt;
                    }
                }
                else
                {
                    i_tyle = 0;
                }

                string asql = " select sum(soluong*dongia) as sotien from xxx.v_chidinh where paid=0 and madoituong in(select madoituong from medibv.doituong where mien=0 and trasau=0 and madoituong<>1) and mabn='" + a_mabn + "' and mavaovien=" + a_mavaovien + "";
                DataSet ads = d.get_data_mmyy(asql, s_ngay, s_ngay, true);
                if (ads != null && ads.Tables.Count > 0)
                {
                    foreach (DataRow r in ads.Tables[0].Rows)
                    {
                        //
                        d_chiphibhyt_khongtra += (r["sotien"].ToString() == "") ? 0 : decimal.Parse(r["sotien"].ToString());
                        //
                    }
                }
                //
                d_bhyttra = d_tongtien * i_tyle / 100;
                d_bntra = d_tongtien - d_bhyttra;
                d_bntra += d_chiphibhyt_khongtra;
                d_tongtien += d_chiphibhyt_khongtra;
                //
                lblTongtien.Text = "1. TỔNG CHI PHÍ: " + d_tongtien.ToString("###,###,###.0#") + "\n" + "2. BHYT TRẢ: " + d_bhyttra.ToString("###,###,###.0#");
                lblTongtien.Text += "\n" + "3. DỊCH VỤ NGOÀI BHYT: " + d_chiphibhyt_khongtra.ToString("###,###,###.0#");
                lblTongtien.Text += "\n" + "4. BỆNH NHÂN CÓ THỂ PHẢI TRẢ: " + d_bntra.ToString("###,###,###.0#");
                //
            }
        }
	}
}
