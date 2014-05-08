using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
namespace DllPhonggiuong
{
	public class frmDsgiuong : System.Windows.Forms.Form
	{
		public DataSet dsct=new DataSet();
		private LibMedi.AccessData m;
		private DataTable dt=new DataTable();
		private DataTable dtgiuong=new DataTable();
		private DataTable dtkp=new DataTable();
		private DataTable dtp=new DataTable();
		private DataTable dtdt=new DataTable();
		private int _index,i_madoituong,i_giuong_old=0,iSobutton=0,iSogio=5;
        private string sql, s_makp, fie, s_tungay = "", s_denngay = "", s_user = "";
		private bool b1guong=false,bNew,bEdit,bDoi=false,bXem=false;
		private Button but;
		public long id=0;
        private bool bChophep_BNKhoaA_namgiuong_khoaB = false;
		public string ma="";
		private ToolTip tooltip;
		private System.Windows.Forms.ComboBox phong;
		private System.Windows.Forms.ComboBox cboKhoa;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Panel pPhong;
		private System.Windows.Forms.Panel pThongtin;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel p;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lHoten;
		private System.Windows.Forms.Label lNgayden;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lGiuong;
		private System.Windows.Forms.Label lDieutri;
		private PinkieControls.ButtonXP butCancel;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lMaBN;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lGiuongtrong;
		private System.Windows.Forms.Label lDattruoc;
		private System.Windows.Forms.Label lConguoi;
		private System.Windows.Forms.Panel pBenhnhan;
		private System.Windows.Forms.Label lEmpty;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.Label l_giuongghep;
		private System.Windows.Forms.GroupBox gTinhtrang;
		private System.Windows.Forms.GroupBox gThongtin;
		private System.Windows.Forms.NumericUpDown giotrong;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
        private NumericUpDown Giuongtoida;
		private System.ComponentModel.IContainer components;
		public frmDsgiuong(LibMedi.AccessData acc,DataTable adt,string _makp,int _madoituong,bool bnew,bool bedit)
		{
			InitializeComponent();
			m=acc;s_makp=_makp;i_madoituong=_madoituong;bNew=bnew;dtgiuong=adt;bEdit=bedit;
		}
		public frmDsgiuong(LibMedi.AccessData acc,string _makp,int _madoituong,bool bdoi,int giuongold)
		{
			InitializeComponent();
			m=acc;s_makp=_makp;i_madoituong=_madoituong;bDoi=bdoi;i_giuong_old=giuongold;
		}
		public frmDsgiuong(LibMedi.AccessData acc,string _makp,bool xem)
		{
			InitializeComponent();
			m=acc;s_makp=_makp;bXem=xem;
			if(_makp=="") butCancel.Text="Kết thúc";
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDsgiuong));
            this.pThongtin = new System.Windows.Forms.Panel();
            this.gTinhtrang = new System.Windows.Forms.GroupBox();
            this.l_giuongghep = new System.Windows.Forms.Label();
            this.lGiuongtrong = new System.Windows.Forms.Label();
            this.lDattruoc = new System.Windows.Forms.Label();
            this.lConguoi = new System.Windows.Forms.Label();
            this.gThongtin = new System.Windows.Forms.GroupBox();
            this.pBenhnhan = new System.Windows.Forms.Panel();
            this.lGiuong = new System.Windows.Forms.Label();
            this.lMaBN = new System.Windows.Forms.Label();
            this.lNgayden = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lDieutri = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lHoten = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lEmpty = new System.Windows.Forms.Label();
            this.butCancel = new PinkieControls.ButtonXP();
            this.phong = new System.Windows.Forms.ComboBox();
            this.cboKhoa = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pPhong = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.giotrong = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.p = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.Giuongtoida = new System.Windows.Forms.NumericUpDown();
            this.pThongtin.SuspendLayout();
            this.gTinhtrang.SuspendLayout();
            this.gThongtin.SuspendLayout();
            this.pBenhnhan.SuspendLayout();
            this.pPhong.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.giotrong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Giuongtoida)).BeginInit();
            this.SuspendLayout();
            // 
            // pThongtin
            // 
            this.pThongtin.AutoScroll = true;
            this.pThongtin.Controls.Add(this.gTinhtrang);
            this.pThongtin.Controls.Add(this.gThongtin);
            this.pThongtin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pThongtin.Location = new System.Drawing.Point(0, 447);
            this.pThongtin.Name = "pThongtin";
            this.pThongtin.Size = new System.Drawing.Size(794, 128);
            this.pThongtin.TabIndex = 2;
            // 
            // gTinhtrang
            // 
            this.gTinhtrang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gTinhtrang.BackColor = System.Drawing.Color.Lavender;
            this.gTinhtrang.Controls.Add(this.l_giuongghep);
            this.gTinhtrang.Controls.Add(this.lGiuongtrong);
            this.gTinhtrang.Controls.Add(this.lDattruoc);
            this.gTinhtrang.Controls.Add(this.lConguoi);
            this.gTinhtrang.ForeColor = System.Drawing.Color.Blue;
            this.gTinhtrang.Location = new System.Drawing.Point(645, -1);
            this.gTinhtrang.Name = "gTinhtrang";
            this.gTinhtrang.Size = new System.Drawing.Size(149, 128);
            this.gTinhtrang.TabIndex = 10;
            this.gTinhtrang.TabStop = false;
            this.gTinhtrang.Text = "Tình trạng giường";
            // 
            // l_giuongghep
            // 
            this.l_giuongghep.BackColor = System.Drawing.Color.Lavender;
            this.l_giuongghep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.l_giuongghep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.l_giuongghep.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_giuongghep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.l_giuongghep.Image = ((System.Drawing.Image)(resources.GetObject("l_giuongghep.Image")));
            this.l_giuongghep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.l_giuongghep.Location = new System.Drawing.Point(4, 97);
            this.l_giuongghep.Name = "l_giuongghep";
            this.l_giuongghep.Size = new System.Drawing.Size(141, 26);
            this.l_giuongghep.TabIndex = 7;
            this.l_giuongghep.Text = "      Giường trọn gói";
            this.l_giuongghep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.l_giuongghep.Click += new System.EventHandler(this.l_giuongghep_Click);
            // 
            // lGiuongtrong
            // 
            this.lGiuongtrong.BackColor = System.Drawing.Color.Lavender;
            this.lGiuongtrong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lGiuongtrong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lGiuongtrong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lGiuongtrong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lGiuongtrong.Image = ((System.Drawing.Image)(resources.GetObject("lGiuongtrong.Image")));
            this.lGiuongtrong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lGiuongtrong.Location = new System.Drawing.Point(4, 16);
            this.lGiuongtrong.Name = "lGiuongtrong";
            this.lGiuongtrong.Size = new System.Drawing.Size(141, 26);
            this.lGiuongtrong.TabIndex = 4;
            this.lGiuongtrong.Text = "      Giường trống";
            this.lGiuongtrong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lGiuongtrong.Click += new System.EventHandler(this.lGiuongtrong_Click);
            // 
            // lDattruoc
            // 
            this.lDattruoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lDattruoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lDattruoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lDattruoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDattruoc.ForeColor = System.Drawing.Color.Black;
            this.lDattruoc.Image = ((System.Drawing.Image)(resources.GetObject("lDattruoc.Image")));
            this.lDattruoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lDattruoc.Location = new System.Drawing.Point(4, 43);
            this.lDattruoc.Name = "lDattruoc";
            this.lDattruoc.Size = new System.Drawing.Size(141, 26);
            this.lDattruoc.TabIndex = 5;
            this.lDattruoc.Text = "      Đặt trước";
            this.lDattruoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lDattruoc.Click += new System.EventHandler(this.lDattruoc_Click);
            // 
            // lConguoi
            // 
            this.lConguoi.BackColor = System.Drawing.Color.Lavender;
            this.lConguoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lConguoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lConguoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lConguoi.ForeColor = System.Drawing.Color.Red;
            this.lConguoi.Image = ((System.Drawing.Image)(resources.GetObject("lConguoi.Image")));
            this.lConguoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lConguoi.Location = new System.Drawing.Point(4, 70);
            this.lConguoi.Name = "lConguoi";
            this.lConguoi.Size = new System.Drawing.Size(141, 26);
            this.lConguoi.TabIndex = 6;
            this.lConguoi.Text = "      Có người";
            this.lConguoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lConguoi.Click += new System.EventHandler(this.lConguoi_Click);
            // 
            // gThongtin
            // 
            this.gThongtin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gThongtin.BackColor = System.Drawing.Color.Lavender;
            this.gThongtin.Controls.Add(this.pBenhnhan);
            this.gThongtin.Controls.Add(this.lEmpty);
            this.gThongtin.ForeColor = System.Drawing.Color.Blue;
            this.gThongtin.Location = new System.Drawing.Point(3, -1);
            this.gThongtin.Name = "gThongtin";
            this.gThongtin.Size = new System.Drawing.Size(641, 129);
            this.gThongtin.TabIndex = 7;
            this.gThongtin.TabStop = false;
            this.gThongtin.Text = "Thông tin bệnh nhân";
            // 
            // pBenhnhan
            // 
            this.pBenhnhan.Controls.Add(this.lGiuong);
            this.pBenhnhan.Controls.Add(this.lMaBN);
            this.pBenhnhan.Controls.Add(this.lNgayden);
            this.pBenhnhan.Controls.Add(this.label6);
            this.pBenhnhan.Controls.Add(this.lDieutri);
            this.pBenhnhan.Controls.Add(this.label4);
            this.pBenhnhan.Controls.Add(this.label5);
            this.pBenhnhan.Controls.Add(this.lHoten);
            this.pBenhnhan.Controls.Add(this.label7);
            this.pBenhnhan.Location = new System.Drawing.Point(3, 14);
            this.pBenhnhan.Name = "pBenhnhan";
            this.pBenhnhan.Size = new System.Drawing.Size(634, 113);
            this.pBenhnhan.TabIndex = 0;
            // 
            // lGiuong
            // 
            this.lGiuong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lGiuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lGiuong.ForeColor = System.Drawing.Color.Navy;
            this.lGiuong.Location = new System.Drawing.Point(448, 8);
            this.lGiuong.Name = "lGiuong";
            this.lGiuong.Size = new System.Drawing.Size(176, 16);
            this.lGiuong.TabIndex = 4;
            this.lGiuong.Text = "Giuong";
            // 
            // lMaBN
            // 
            this.lMaBN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lMaBN.ForeColor = System.Drawing.Color.Navy;
            this.lMaBN.Location = new System.Drawing.Point(72, 8);
            this.lMaBN.Name = "lMaBN";
            this.lMaBN.Size = new System.Drawing.Size(69, 16);
            this.lMaBN.TabIndex = 7;
            this.lMaBN.Text = "Ma BN";
            // 
            // lNgayden
            // 
            this.lNgayden.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNgayden.ForeColor = System.Drawing.Color.Navy;
            this.lNgayden.Location = new System.Drawing.Point(72, 32);
            this.lNgayden.Name = "lNgayden";
            this.lNgayden.Size = new System.Drawing.Size(116, 16);
            this.lNgayden.TabIndex = 2;
            this.lNgayden.Text = "Ngay den";
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(3, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Ngày đến :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lDieutri
            // 
            this.lDieutri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lDieutri.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDieutri.ForeColor = System.Drawing.Color.Navy;
            this.lDieutri.Location = new System.Drawing.Point(8, 80);
            this.lDieutri.Name = "lDieutri";
            this.lDieutri.Size = new System.Drawing.Size(624, 24);
            this.lDieutri.TabIndex = 5;
            this.lDieutri.Text = "Dieu tri";
            this.lDieutri.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(137, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Họ tên BN :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(8, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Mã BN :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lHoten
            // 
            this.lHoten.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lHoten.ForeColor = System.Drawing.Color.Navy;
            this.lHoten.Location = new System.Drawing.Point(201, 8);
            this.lHoten.Name = "lHoten";
            this.lHoten.Size = new System.Drawing.Size(190, 16);
            this.lHoten.TabIndex = 1;
            this.lHoten.Text = "Ho ten BN";
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(385, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "Giường :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lEmpty
            // 
            this.lEmpty.ForeColor = System.Drawing.Color.Navy;
            this.lEmpty.Location = new System.Drawing.Point(8, 40);
            this.lEmpty.Name = "lEmpty";
            this.lEmpty.Size = new System.Drawing.Size(520, 28);
            this.lEmpty.TabIndex = 9;
            this.lEmpty.Text = "Dieu tri";
            this.lEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butCancel
            // 
            this.butCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.butCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butCancel.DefaultScheme = true;
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.butCancel.Hint = "";
            this.butCancel.Image = ((System.Drawing.Image)(resources.GetObject("butCancel.Image")));
            this.butCancel.Location = new System.Drawing.Point(544, 8);
            this.butCancel.Name = "butCancel";
            this.butCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.butCancel.Size = new System.Drawing.Size(76, 24);
            this.butCancel.TabIndex = 5;
            this.butCancel.Text = "&Bỏ qua";
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // phong
            // 
            this.phong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.phong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.phong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phong.Location = new System.Drawing.Point(316, 9);
            this.phong.Name = "phong";
            this.phong.Size = new System.Drawing.Size(160, 21);
            this.phong.TabIndex = 0;
            this.phong.SelectedIndexChanged += new System.EventHandler(this.phong_SelectedIndexChanged);
            // 
            // cboKhoa
            // 
            this.cboKhoa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKhoa.Location = new System.Drawing.Point(56, 9);
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.Size = new System.Drawing.Size(220, 21);
            this.cboKhoa.TabIndex = 1;
            this.cboKhoa.SelectedIndexChanged += new System.EventHandler(this.cboKhoa_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(8, 11);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 16);
            this.label14.TabIndex = 0;
            this.label14.Text = "Khoa :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(270, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 16);
            this.label13.TabIndex = 2;
            this.label13.Text = "&Phòng :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pPhong
            // 
            this.pPhong.Controls.Add(this.groupBox1);
            this.pPhong.Dock = System.Windows.Forms.DockStyle.Top;
            this.pPhong.Location = new System.Drawing.Point(0, 0);
            this.pPhong.Name = "pPhong";
            this.pPhong.Size = new System.Drawing.Size(794, 32);
            this.pPhong.TabIndex = 19;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Lavender;
            this.groupBox1.Controls.Add(this.Giuongtoida);
            this.groupBox1.Controls.Add(this.phong);
            this.groupBox1.Controls.Add(this.cboKhoa);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.butCancel);
            this.groupBox1.Controls.Add(this.giotrong);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(2, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(791, 34);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // giotrong
            // 
            this.giotrong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.giotrong.Location = new System.Drawing.Point(720, 10);
            this.giotrong.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.giotrong.Name = "giotrong";
            this.giotrong.Size = new System.Drawing.Size(40, 20);
            this.giotrong.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(616, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Giường trống sau :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(760, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Giờ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // p
            // 
            this.p.BackColor = System.Drawing.Color.WhiteSmoke;
            this.p.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p.Location = new System.Drawing.Point(0, 32);
            this.p.Name = "p";
            this.p.Size = new System.Drawing.Size(794, 415);
            this.p.TabIndex = 1;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            // 
            // Giuongtoida
            // 
            this.Giuongtoida.Location = new System.Drawing.Point(478, 9);
            this.Giuongtoida.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.Giuongtoida.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.Giuongtoida.Name = "Giuongtoida";
            this.Giuongtoida.Size = new System.Drawing.Size(65, 20);
            this.Giuongtoida.TabIndex = 12;
            this.Giuongtoida.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // frmDsgiuong
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(794, 575);
            this.Controls.Add(this.p);
            this.Controls.Add(this.pPhong);
            this.Controls.Add(this.pThongtin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmDsgiuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục giường";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmDsgiuong_KeyDown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDsgiuong_KeyDown);
            this.Load += new System.EventHandler(this.frmDsgiuong_Load);
            this.pThongtin.ResumeLayout(false);
            this.gTinhtrang.ResumeLayout(false);
            this.gThongtin.ResumeLayout(false);
            this.pBenhnhan.ResumeLayout(false);
            this.pPhong.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.giotrong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Giuongtoida)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmDsgiuong_Load(object sender, System.EventArgs e)
		{
			//
            s_user = m.user;
			try
			{
				iSogio= int.Parse(m.Thongso("giuongtrongsauNgio"));				
			}
			catch{iSogio=5;}
			giotrong.Value=iSogio;
			//
			iSobutton=(p.Height-45)/25;
			int i=0;
			if(DateTime.Now.Day<10) i=-1;
			s_tungay="01/"+DateTime.Now.AddMonths(i).Month.ToString().PadLeft(2,'0')+"/"+DateTime.Now.Year.ToString();
			s_denngay=m.ngayhienhanh_server.Substring(0,10);
            //
            bChophep_BNKhoaA_namgiuong_khoaB = m.bChophep_BNKhoaA_namgiuong_khoaB;
            //
			dsct.Merge(dtgiuong);
			if(!bEdit||bNew) dsct.Clear();
            dtkp = m.get_data("select * from " + s_user + ".btdkp_bv where loai=0").Tables[0];
            sql = "select distinct a.makp,a.tenkp from " + s_user + ".btdkp_bv a, " + s_user + ".dmphong b where a.makp=b.makp";
			if(!bXem)
			{
				if((bNew||bEdit||bDoi) && s_makp!="")
				{
					if(s_makp.IndexOf("_3")!=-1) sql+=" and a.makp='"+s_makp.Substring(0,s_makp.Length-2)+"'";
					//else if(s_makp.IndexOf("_1")!=-1) sql+=" and a.makp<>'"+s_makp.Substring(0,s_makp.Length-2)+"'";
                    //gam 30/08/2011 comment bv phụ sản bình dương 
                    //yêu cầu bệnh nhân đang hiện diện tại kh0a vẫn có thể đặt thêm giường cùng phòng cho người nhà
				}
			}
			else 
			{
				bNew=false;bEdit=false;bDoi=false;
				if(s_makp!="") sql+=" and a.makp in("+s_makp+")";
				if(s_makp=="") bDoi=true;
			}
			sql+=" order by a.makp";
			DataTable dtkhoa=m.get_data(sql).Tables[0];
			cboKhoa.DisplayMember="TENKP";
			cboKhoa.ValueMember="MAKP";
			cboKhoa.DataSource=dtkhoa;
			//Kiem tra trang thai giuong
            m.execute_data("update " + s_user + ".dmgiuong set tinhtrang= 1,soluong = 1 where id in(select idgiuong from " + s_user + ".datgiuong where den is null)");
            m.execute_data("update " + s_user + ".dmgiuong set tinhtrang= 2,soluong = 1 where id in(select idgiuong from " + s_user + ".theodoigiuong where den is null)");
            sql = "select a.idgiuong,to_char(den,'dd/mm/yyyy hh24:mi') ngayra,b.ma,b.idphong from " + s_user + ".theodoigiuong a, " + s_user + ".dmgiuong b,(select idgiuong from " + s_user + ".theodoigiuong where den is null union all select idgiuong from " + s_user + ".datgiuong where den is null) c ";
            sql += " where a.idgiuong=b.id and a.den is not null and a.idgiuong=c.idgiuong(+) and c.idgiuong is null and instr(b.ma,'TG')>0 and to_date(to_char(a.den,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tungay + "','dd/mm/yyyy') and to_date('" + s_denngay + "','dd/mm/yyyy')";
			foreach(DataRow row in m.get_data(sql).Tables[0].Rows)
			{
				int idex1=row["ma"].ToString().IndexOf("TG")+2;
				int idex2=row["ma"].ToString().IndexOf("/");
				string s_stt=row["ma"].ToString().Substring(idex1,idex2-idex1)+","+row["ma"].ToString().Substring(idex2+1);
                m.execute_data("update " + s_user + ".dmgiuong set tinhtrang=0,soluong=0 where tinhtrang<>3 and id=" + int.Parse(row["idgiuong"].ToString()));
                foreach (DataRow row1 in m.get_data("select * from " + s_user + ".dmgiuong where idphong=" + int.Parse(row["idphong"].ToString()) + " and stt in(" + s_stt + ")").Tables[0].Rows)
                    m.execute_data("update " + s_user + ".dmgiuong set tinhtrang=0,soluong=0 where tinhtrang<>3 and id=" + int.Parse(row1["id"].ToString()) + " and id not in(select idgiuong from " + s_user + ".theodoigiuong where den is null union all select idgiuong from " + s_user + ".datgiuong where den is null)");
			}
            sql = "select a.idgiuong,to_char(a.den,'dd/mm/yyyy hh24:mi') ngayra,b.ma,b.idphong from " + s_user + ".xuatvien xv," + s_user + ".theodoigiuong a," + s_user + ".dmgiuong b,(select idgiuong from " + s_user + ".theodoigiuong where den is null union all select idgiuong from " + s_user + ".datgiuong where den is null) c where xv.maql=a.maql and a.idgiuong=b.id and a.den is not null and a.idgiuong=c.idgiuong(+) and c.idgiuong is null and to_char(a.den,'dd/mm/yyyy')='" + m.ngayhienhanh_server.Substring(0, 10) + "'";
			foreach(DataRow row in m.get_data(sql).Tables[0].Rows)
			{
				string file="";
				if(m.bNgaygio(m.DateToString("dd/MM/yyyy HH:mm",m.StringToDateTime(row["ngayra"].ToString()).AddHours(iSogio)),m.ngayhienhanh_server))
				{
                    m.execute_data("update " + s_user + ".dmgiuong set tinhtrang=2 where tinhtrang<>3 and id=" + int.Parse(row["idgiuong"].ToString()));
					file="tinhtrang=2";
				}
				else
				{
                    m.execute_data("update " + s_user + ".dmgiuong set tinhtrang=0,soluong=0 where tinhtrang<>3 and id=" + int.Parse(row["idgiuong"].ToString()) + " and idphong not in(select idphong from " + s_user + ".dmgiuong where idphong=" + int.Parse(row["idphong"].ToString()) + " and instr(ma,'TG')>0 and tinhtrang<>3)");
					file="tinhtrang=0,soluong=0";
				}
				if(row["ma"].ToString().IndexOf("TG")!=-1)
				{
					int idex1=row["ma"].ToString().IndexOf("TG")+2;
					int idex2=row["ma"].ToString().IndexOf("/");
					string s_stt=row["ma"].ToString().Substring(idex1,idex2-idex1)+","+row["ma"].ToString().Substring(idex2+1);
                    m.execute_data("update " + s_user + ".3dmgiuong set " + file + " where tinhtrang<>3 and idphong=" + int.Parse(row["idphong"].ToString()) + " and stt in(" + s_stt + ") and id not in(select idgiuong from " + s_user + ".datgiuong where den is null union all select idgiuong from " + s_user + ".theodoigiuong where den is null)");
				}
			}
            sql = "select a.*,b.ma,b.idphong from " + s_user + ".theodoigiuong a, " + s_user + ".dmgiuong b where a.idgiuong=b.id and a.den is null and instr(b.ma,'TG')>0";
			foreach(DataRow row in m.get_data(sql).Tables[0].Rows)
			{
                //int idex1=row["ma"].ToString().IndexOf("TG")+2;
                //int idex2=row["ma"].ToString().IndexOf("/");
                //string s_stt=row["ma"].ToString().Substring(idex1,idex2-idex1)+","+row["ma"].ToString().Substring(idex2+1);
                m.execute_data("update " + s_user + ".dmgiuong set tinhtrang=2 where tinhtrang<>3 and idphong=" + int.Parse(row["idphong"].ToString()) + "and ma='" + row["ma"].ToString() + "'");// " and stt in(" + s_stt + ")");
			}
            sql = "select a.*,b.ma,b.idphong from " + s_user + ".datgiuong a, " + s_user + ".dmgiuong b where a.idgiuong=b.id and a.den is null and instr(b.ma,'TG')>0";
			foreach(DataRow row in m.get_data(sql).Tables[0].Rows)
			{
				int idex1=row["ma"].ToString().IndexOf("TG")+2;
				int idex2=row["ma"].ToString().IndexOf("/");
				string s_stt=row["ma"].ToString().Substring(idex1,idex2-idex1)+","+row["ma"].ToString().Substring(idex2+1);
                m.execute_data("update " + s_user + ".dmgiuong set tinhtrang=1 where tinhtrang<>3 and idphong=" + int.Parse(row["idphong"].ToString()) + " and stt in(" + s_stt + ")");
			}
            m.execute_data("update " + s_user + ".dmgiuong set ghichu='' where tinhtrang=0");
			//End kiem tra
			b1guong=m.b1giuong;
			fie="gia_th";
            dtdt = m.get_data("select * from " + s_user + ".doituong").Tables[0];
			DataRow r1=m.getrowbyid(dtdt,"madoituong="+i_madoituong);
			if (r1!=null) fie=r1["field_gia"].ToString().Trim();
			phong.DisplayMember="TEN";
			phong.ValueMember="ID";
			load_phong();
			load_grid(3);
			pBenhnhan.Visible=false;
			lEmpty.Visible=false;
		}
		private void load_phong()
		{
            sql = "select * from " + s_user + ".dmphong";
			if (cboKhoa.SelectedIndex!=-1) sql+=" where makp='"+cboKhoa.SelectedValue.ToString()+"'";
			sql+=" order by makp,stt";
			dtp=m.get_data(sql).Tables[0];
			DataRow r1=dtp.NewRow();
			r1["makp"]=s_makp;
			r1["id"]=0;
			r1["stt"]=0;
			r1["ma"].ToString();
			r1["ten"]="Tất cả";
			dtp.Rows.InsertAt(r1,0);
			phong.DataSource=dtp;
		}
		private void load_grid(int i_tinhtrang)
		{
			if (phong.SelectedValue.ToString()=="0")
			{
				sql="select a.id,a.idphong,a.stt,b.makp,a.ma,b.ma phong,case when instr(a.ma,'TG')=0 then 0 else 1 end tgoi,decode(a.ghichu,null,trim(b.ten)||'/'||trim(a.ten),trim(b.ten)||'/'||trim(a.ten)||'('||a.ghichu||')') as ten,trim(b.ten)||' - '||trim(a.ten) as tengiuong,a.tinhtrang,a.soluong,a.gia_th,a.gia_bh,a.gia_cs,a.gia_dv,a.gia_nn,a.bhyt";
                sql += " from " + s_user + ".dmgiuong a, " + s_user + ".dmphong b where a.idphong=b.id ";
				if (cboKhoa.SelectedIndex!=-1) sql+=" and b.makp='"+cboKhoa.SelectedValue.ToString()+"'";
				if(i_tinhtrang!=3 && i_tinhtrang!=4) sql+=" and a.tinhtrang="+i_tinhtrang;
				//if(i_tinhtrang==4) sql+=" and instr(a.ma,'TG')>0";
				sql+=" order by b.makp,b.ten,a.stt";//b.stt
			}
			else
			{
				sql="select a.id,a.idphong,a.stt,b.makp,a.ma,b.ma phong,case when instr(a.ma,'TG')=0 then 0 else 1 end tgoi,decode(a.ghichu,null,trim(a.ten),trim(a.ten)||'('||a.ghichu||')') as ten,trim(b.ten)||' - '||trim(a.ten) as tengiuong,a.tinhtrang,a.soluong,a.gia_th,a.gia_bh,a.gia_cs,a.gia_dv,a.gia_nn,a.bhyt ";
                sql += " from " + s_user + ".dmgiuong a, " + s_user + ".dmphong b where a.idphong=b.id and a.idphong=" + int.Parse(phong.SelectedValue.ToString());
				if(i_tinhtrang!=3 && i_tinhtrang!=4) sql+=" and a.tinhtrang="+i_tinhtrang;
				//if(i_tinhtrang==4) sql+=" and instr(a.ma,'TG')>0";
				sql+=" order by b.makp,b.ten,a.stt";//b.stt
			}
			dt=m.get_data(sql).Tables[0];
			if(dt.Rows.Count>0)
			{
				lGiuongtrong.Text="      Giường trống ("+dt.Select("tinhtrang=0 and tgoi=0").Length+")";
				lDattruoc.Text="      Đặt trước ("+dt.Select("tinhtrang=1 and tgoi=0").Length+")";
				lConguoi.Text="      Có người ("+dt.Select("tinhtrang=2 and tgoi=0").Length+")";
			}
			load();
		}

		private void phong_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            try
            {                
                    load_grid(3);
            }
            catch { }
		}
		private void load()
		{
			p.Controls.Clear();
			_index=0;
			int t=5,l=5,j=0;
			foreach(DataRow r in dt.Rows)
			{
				if (j%iSobutton==0 && j!=0)
				{
					t=5;
					l+=130;
				}
				Addchkbox(r["ma"].ToString(),r["ten"].ToString(),r["id"].ToString(),int.Parse(r["tinhtrang"].ToString()),decimal.Parse(r["soluong"].ToString()),decimal.Parse(r[fie].ToString()),decimal.Parse(r["bhyt"].ToString()),t,l);//,new EventHandler(onClickEvent));
				t+=27;
				j++;
                if (j > int.Parse(Giuongtoida.Value.ToString())) break;
			}
			p.AutoScroll=true;
		}
		#region Old
		/*
		public void chkEvent(object sender, EventArgs e)
		{
			Control ctrl=(Control)sender;
			button c=ctrl.Tag as button;
			id=long.Parse(c.index.ToString());
			DataRow r=m.getrowbyid(dt,"id="+id);
			ma=(r!=null)?r["ma"].ToString():"";
			DataRow r1;
			c.FlatStyle=FlatStyle.Popup;
			string s1=c.BackColor.R+c.BackColor.A.ToString()+c.BackColor.B.ToString()+c.BackColor.G.ToString();
			Button c1=(Button)c;
			c1.BackColor=Color.Green;
			if(bNew||bEdit)
			{
				if(s1=="255200208") 
				{
					r1=dtct.NewRow();
					r1["id"]=id;
					r1["ma"]=ma;
					r1["ten"]=r["tengiuong"].ToString();
					r1["dongia"]=r["gia_th"].ToString();
					dtct.Rows.Add(r1);
				}
				else 
				{
					c.BackColor=Color.White;
					m.delrec(dtct,"id="+id);
				}
				if(r["tinhtrang"].ToString()=="2")
				{
					MessageBox.Show("Đã có người nằm, vui lòng chọn giường khác!");
					load_thongtin(r["tinhtrang"].ToString(),id);
					return;
				}
				if(b1guong&&r["tinhtrang"].ToString()=="1")
				{
					MessageBox.Show("Đã có người đặt trước, vui lòng chọn giường khác!");
					load_thongtin(r["tinhtrang"].ToString(),id);
					return;
				}
				this.Close();
			}
			else load_thongtin(r["tinhtrang"].ToString(),id);
		}
		//
		public class button : Button
		{
			public string index;
			public string Index
			{
				get
				{
					return index;
				}
			}
			public button(string index,EventHandler onClickEvent)
			{
				this.index=index;
				Click+=onClickEvent;
			}
		}
		*/
		#endregion
		private void load_thongtin(string ttrang,long idgiuong,int idphong,string stt)
		{
			DataTable dtmp=new DataTable();
			sql="";
            if (ttrang == "1") sql = "select to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngay,a.* from " + s_user + ".datgiuong a where a.den is null and a.idgiuong=" + idgiuong;
            else if (ttrang == "2") sql = "select to_char(a.tu,'dd/mm/yyyy hh24:mi') ngay,a.* from " + s_user + ".theodoigiuong a where a.den is null and a.idgiuong=" + idgiuong;
			if(ttrang=="0") 
			{
				pBenhnhan.Visible=false;
				lEmpty.Visible=true;
				lEmpty.BringToFront();
				lEmpty.Text="Giường trống";
				return;
			}
			else
			{
				pBenhnhan.Visible=true;
				lEmpty.SendToBack();
			}
			if(sql=="") return;
			dtmp=m.get_data(sql).Tables[0];
			if(dtmp.Rows.Count<=0) dtmp=giuong_sudung_trongoi(idphong,stt);
            DataTable dthiendien;
			foreach(DataRow r in dtmp.Rows)
			{
                dthiendien = load_hiendien(r["mabn"].ToString());
                if (dthiendien.Rows.Count > 0)
                {
                    DataRow r1 = dthiendien.Rows[0];
                    lMaBN.Text = r["mabn"].ToString();
                    lHoten.Text = r1["hoten"].ToString();
                    lGiuong.Text = m.getrowbyid(dt, "id=" + id)["ten"].ToString();
                    lNgayden.Text = r["ngay"].ToString();
                    DataRow r2 = m.getrowbyid(dtkp, "makp='" + r1["makp"].ToString().Substring(0, r1["makp"].ToString().Length - 2) + "'");
                    if (r2 != null)
                    {
                        if (r1["makp"].ToString().IndexOf("_0") != -1)
                            lDieutri.Text = "Bệnh nhân được chỉ định vào khoa : " + r2["tenkp"].ToString().ToUpper();
                        else lDieutri.Text = "Bệnh nhân đang điều trị tại khoa : " + r2["tenkp"].ToString().ToUpper();
                    }
                }
                else
                {
                    dthiendien = load_thongtinbn(r["mabn"].ToString());
                    if (dthiendien.Rows.Count > 0)
                    {
                        DataRow r1 = dthiendien.Rows[0];
                        lMaBN.Text = r["mabn"].ToString();
                        lHoten.Text = r1["hoten"].ToString();
                        lGiuong.Text = m.getrowbyid(dt, "id=" + id)["ten"].ToString();
                        lNgayden.Text = r["ngay"].ToString();
                        lDieutri.Text = "Bệnh nhân đã ra khoa : ";
                    }
                }
				break;
			}						 
		}
//		private void get_xuatvien(int idgiuong)
//		{
//			sql="select from xuatvien a,theodoigiuong b where a.maql=b.maql b.den is not null and b.idgiuong="+idgiuong+" and to_char(a.ngay,'dd/mm/yyyy')='"+m.ngayhienhanh_server.Substring(0,10)+"'";
//		}
		private DataTable giuong_sudung_trongoi(int idphong,string stt)
		{
            sql = "select to_char(a.tu,'dd/mm/yyyy hh24:mi') ngay,a.* from (select mabn,tu,den,idgiuong from " + s_user + ".theodoigiuong union all select mabn,ngay tu,den,idgiuong from " + s_user + ".datgiuong) a,(select id,idphong,tinhtrang,substr(ma,1,instr(ma,'/')-1) ma1,substr(ma,instr(ma,'/')+1) ma2 ";
            sql += "from (select id,idphong,tinhtrang,substr(ma,instr(ma,'TG')+2) ma from " + s_user + ".dmgiuong where instr(ma,'TG')>0)bb) b ";
            sql += "where a.idgiuong=b.id and a.den is null and b.idphong=" + idphong + " and (b.ma1=" + stt + " or b.ma2=" + stt + ")";
			return m.get_data(sql).Tables[0];
		}
		private DataTable load_hiendien(string s_mabn)
		{
			sql=" select a.mabn,a.maql,d.hoten,case when b.maql is not null and b.nhapkhoa=1 and xuatkhoa=0 then b.makp||'_1' else b.makp||'_0' end makp";
            sql += " from " + s_user + ".benhandt a, " + s_user + ".hiendien b, " + s_user + ".xuatvien c, " + s_user + ".btdbn d ";
            sql += " where a.mabn=d.mabn and a.maql=c.maql(+) and c.maql is null and a.maql=b.maql and a.loaiba=1 and a.mabn='" + s_mabn + "' order by a.maql desc";
			return m.get_data(sql).Tables[0];
		}

        private DataTable load_thongtinbn(string s_mabn)
        {
            sql = " select a.mabn,a.maql,d.hoten, c.makp||'_0' makp";
            sql += " from " + s_user + ".benhandt a, " + s_user + ".xuatvien c, " + s_user + ".btdbn d ";
            sql += " where a.mabn=d.mabn and a.maql=c.maql(+) and a.loaiba=1 and a.mabn='" + s_mabn + "' order by a.maql desc";
            return m.get_data(sql).Tables[0];
        }
		public void Addchkbox(string ma,string text,string name,int tt,decimal sl,decimal dg,decimal bhyt,int t,int l)//,EventHandler onClickEvent)
		{
			but=new Button();
			tooltip=new ToolTip();
			but.TabIndex=_index;
			but.Text=text.Replace("Giường số","").Replace("Giường","").Replace("và","-").Replace(" ","");
			but.Name=name;
			but.Tag=name;
			tooltip.SetToolTip(but,dg.ToString("### ### ###"));
			but.Top=t;
			but.Left=l;
			but.BackColor=Color.White;
			switch(tt)
			{
				case 0:but.Image=imageList1.Images[0];//giuong trong
					but.ForeColor=Color.Navy;
					break;
				case 1://co nguoi dat giuong
					but.BackColor=Color.FromArgb(255, 255, 192);
					but.Image=imageList1.Images[1];
					but.ForeColor=Color.Black;
					break;
				case 2://co benh nhan
					but.ForeColor=Color.Red;
					but.Image=imageList1.Images[2];
					break;
				case 3://giu giuong
					but.ForeColor=Color.White;
					but.BackColor=Color.Blue;
					break;
			}
			if(ma.IndexOf("TG")!=-1 && tt!=2)but.Image=imageList1.Images[3];
			but.ImageAlign=ContentAlignment.MiddleRight;
			but.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			but.Cursor = System.Windows.Forms.Cursors.Hand;
			but.Size = new System.Drawing.Size(132, 25);
//			but.Click+=onClickEvent;
			but.Click += new System.EventHandler(this.but_Click);
//			but.Tag=butClick;
			but.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.p.Controls.Add(but);
			_index++;
		}
		private void but_Click(object sender, System.EventArgs e)
		{
			Button c=(Button)sender;
			id=long.Parse(c.Tag.ToString());
			DataRow r=m.getrowbyid(dt,"id="+id);
			ma=(r!=null)?r["ma"].ToString():"";
			DataRow r1,r2;
			if(!bDoi)
			{
				if(bNew||bEdit)
				{
					if(r["gia_th"].ToString()!="0")
					{
						if(r["tinhtrang"].ToString()!="0" && r["tinhtrang"].ToString()!="3")
						{
							load_thongtin(r["tinhtrang"].ToString(),id,int.Parse(r["idphong"].ToString()),r["stt"].ToString());
							return;
						}
						if(!kiemtra(id)) return;
						if(giuong_trongoi(int.Parse(r["idphong"].ToString()),ma))
						{
							MessageBox.Show("Đã có người đặt!\nKhông thể đặt cả phòng!");
							return;
						}
					}
					r2=m.getrowbyid(dsct.Tables[0],"id="+id);
					if(r2==null)
					{
						r1=dsct.Tables[0].NewRow();
						r1["id"]=id;
						r1["idphong"]=r["idphong"].ToString();
						r1["ma"]=ma;
						r1["phong"]=r["phong"].ToString();
						r1["ten"]=r["tengiuong"].ToString();
						r1["dongia"]=r["gia_th"].ToString();
						r1["makp"]=r["makp"].ToString();
						dsct.Tables[0].Rows.Add(r1);
					}
					else 
					{
						r2["id"]=id;
						r2["idphong"]=r["idphong"].ToString();
						r2["ma"]=ma;
						r2["phong"]=r["phong"].ToString();
						r2["ten"]=r["tengiuong"].ToString();
						r2["dongia"]=r["gia_th"].ToString();
						r2["makp"]=r["makp"].ToString();
					}
					dsct.AcceptChanges();
					this.Close();
				}
				else load_thongtin(r["tinhtrang"].ToString(),id,int.Parse(r["idphong"].ToString()),r["stt"].ToString());
			}
			else 
			{
				if(r["tinhtrang"].ToString()!="0" && r["tinhtrang"].ToString()!="3")
				{
					load_thongtin(r["tinhtrang"].ToString(),id,int.Parse(r["idphong"].ToString()),r["stt"].ToString());
					return;
				}
				if(!kiemtra(id)) return;
				if(giuong_trongoi(int.Parse(r["idphong"].ToString()),ma))
				{
					MessageBox.Show("Đã có người đặt!\nKhông thể đặt cả phòng!");
					return;
				}
				if(s_makp=="")
				{
					if(c.FlatStyle==FlatStyle.Flat)c.FlatStyle=FlatStyle.Standard;
					else c.FlatStyle=FlatStyle.Flat;
					if(c.FlatStyle==FlatStyle.Flat)
					{
						c.BackColor=Color.Blue;
						c.ForeColor=Color.White;
                        m.execute_data("update " + s_user + ".dmgiuong set tinhtrang=3 where id=" + id);//giu giuong cho BN tron goi
					}
					else
					{
						c.Image=imageList1.Images[0];
						c.ForeColor=Color.Navy;
						c.BackColor=Color.White;
                        m.execute_data("update " + s_user + ".dmgiuong set tinhtrang=0 where id=" + id);
					}
				}
				if(s_makp!="") this.Close();
			}
		}
		private bool kiemtra(long id)
		{
            if (m.get_data("select * from " + s_user + ".datgiuong where idgiuong=" + id + " and den is null").Tables[0].Rows.Count > 0)
			{
				MessageBox.Show("Giường đã có người đặt!\nVui lòng chọn giường khác!",LibMedi.AccessData.Msg);
                m.execute_data("update " + s_user + ".dmgiuong set tinhtrang=1 where id=" + id);
				return false;
			}
            if (m.get_data("select * from " + s_user + ".theodoigiuong where idgiuong=" + id + " and den is null").Tables[0].Rows.Count > 0)
			{
				MessageBox.Show("Giường đã có người nằm!\nVui lòng chọn giường khác!",LibMedi.AccessData.Msg);
                m.execute_data("update " + s_user + ".dmgiuong set tinhtrang=2 where id=" + id);
				return false;
			}
            if (m.get_data("select * from " + s_user + ".hiendien where idgiuong=" + id + " and nhapkhoa=1 and xuatkhoa=0").Tables[0].Rows.Count > 0)
			{
				MessageBox.Show("Giường đã có người nằm!\nVui lòng chọn giường khác!",LibMedi.AccessData.Msg);
                m.execute_data("update " + s_user + ".dmgiuong set tinhtrang=2 where id=" + id);
				return false;
			}
			return true;
		}
		private bool giuong_trongoi(int idphong,string ma)
		{
			if(ma.IndexOf("TG")!=-1)//Tron goi
			{
				int idex1=ma.IndexOf("TG")+2;
				int idex2=ma.IndexOf("/");
				string s_stt=ma.Substring(idex1,idex2-idex1)+","+ma.Substring(idex2+1);
                sql = " select * from " + s_user + ".dmgiuong where idphong=" + idphong + " and stt in(" + s_stt + ") and tinhtrang<>0";	
				if(bDoi&&i_giuong_old!=0) sql+=" and id<>"+i_giuong_old;
				return m.get_data(sql).Tables[0].Rows.Count>0;
			}
			return false;
		}
		private void frmDsgiuong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				int index=this.ActiveControl.TabIndex;
				int n=index+15-index-1;
				if (e.KeyCode==Keys.Left) for(int i=0;i<n;i++) SendKeys.Send("{Up}");
				else if (e.KeyCode==Keys.Right)	for(int i=0;i<n;i++) SendKeys.Send("{Tab}");
			}
			catch{}
		}

		private void phong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void cboKhoa_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            try
            {
                if (this.ActiveControl  == cboKhoa)
                    load_phong();
            }
            catch { }
		}

		private void butCancel_Click(object sender, System.EventArgs e)
		{
			if(!bNew||!bEdit) 
			{
				ma="";id=0;
				dsct.Clear();
			}
			//
			m.writeXml("thongso","giuongtrongsauNgio",giotrong.Value.ToString());
			//
			this.Close();
		}

		private void lGiuongtrong_Click(object sender, System.EventArgs e)
		{
			load_grid(0);
		}

		private void lDattruoc_Click(object sender, System.EventArgs e)
		{
			load_grid(1);
		}

		private void lConguoi_Click(object sender, System.EventArgs e)
		{
			load_grid(2);
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
//			if((bNew||bEdit) && dsct.Tables[0].Rows.Count<=0)
//			{
//				MessageBox.Show("Chọn phòng giường!");
//				return;
//			}
//			this.Close();
		}

		private void l_giuongghep_Click(object sender, System.EventArgs e)
		{
			load_grid(4);
		}

		private void label1_Click(object sender, System.EventArgs e)
		{
			Cursor=Cursors.WaitCursor;
            m.execute_data("update " + s_user + ".dmgiuong set tinhtrang=0 where tinhtrang=2 and soluong<=0 ");
            m.execute_data("update " + s_user + ".dmgiuong set tinhtrang=0, soluong=0 where id in(select a.idgiuong from  " + s_user + ".theodoigiuong a,  " + s_user + ".xuatvien b where a.maql=b.maql and den is null) ");
            m.execute_data("update " + s_user + ".theodoigiuong set den=tu where id in(select a.id from " + s_user + ".theodoigiuong a, " + s_user + ".xuatvien b where a.maql=b.maql and den is null) and den is null ");
            
			Cursor=Cursors.Default;
		}
	}
}
