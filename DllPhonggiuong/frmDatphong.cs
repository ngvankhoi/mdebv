using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;

namespace DllPhonggiuong
{
	public class frmDatphong : System.Windows.Forms.Form
	{
		Language lan = new Language();
		private Process p=new Process();
		private dichso.numbertotext dichso=new dichso.numbertotext();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox hoten;
		private DataSet dsin=new DataSet();
		private DataTable dtct=new DataTable();
		private DataTable dtxoa=new DataTable();
		private LibMedi.AccessData m;
        private LibVienphi.AccessData m_v=new LibVienphi.AccessData();
		private string sql,user,s_ngay="",s_makp="";
		private int i_userid,itable,iTreem15=15,iTreem6=6,iwChange;
		private bool bNew=false,bEdit=false,bSkip=true,bSkip1=true,bTiepdon=false, bTinhGiuong_lucdatgiuong=true;
        private long m_id=0;
		private DataSet ds=new DataSet();
		private DataTable dthd=new DataTable();
		private DataTable dtkp=new DataTable();
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox namsinh;
		private System.Windows.Forms.TextBox tim;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox diachi;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox tuoi;
		private System.Windows.Forms.ComboBox loaituoi;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox phai;
		private System.Windows.Forms.TextBox mann;
		private System.Windows.Forms.ComboBox tennn;
		private System.Windows.Forms.Label lmann;
		private System.Windows.Forms.ComboBox tennuoc;
		private System.Windows.Forms.TextBox manuoc;
		private System.Windows.Forms.Label lmanuoc;
		private System.Windows.Forms.ComboBox tendantoc;
		private System.Windows.Forms.TextBox madantoc;
		private System.Windows.Forms.Label lmadantoc;
		private System.Windows.Forms.TextBox matt;
		private System.Windows.Forms.ComboBox tentinh;
		private System.Windows.Forms.Label lmatt;
		private System.Windows.Forms.TextBox maqu2;
		private System.Windows.Forms.ComboBox tenquan;
		private MaskedTextBox.MaskedTextBox maqu1;
		private System.Windows.Forms.Label lmaqu;
		private System.Windows.Forms.TextBox mapxa2;
		private System.Windows.Forms.ComboBox tenpxa;
		private MaskedTextBox.MaskedTextBox mapxa1;
		private System.Windows.Forms.Label lmaphuongxa;
		private System.Windows.Forms.TextBox cholam;
		private System.Windows.Forms.Label lcholam;
		private System.Windows.Forms.GroupBox gHanhchinh;
		private System.Windows.Forms.GroupBox gGiuong;
		private PinkieControls.ButtonXP butBoqua;
		private PinkieControls.ButtonXP butLuu;
		private PinkieControls.ButtonXP butSua;
		private PinkieControls.ButtonXP butIn;
		private PinkieControls.ButtonXP butKetthuc;
		private PinkieControls.ButtonXP butXoa;
		private System.Windows.Forms.Panel pGrid;
		private System.Windows.Forms.Panel pButton;
		private System.Windows.Forms.Panel pThongtin;
		private System.Windows.Forms.Label lbThongtinhanhchanh;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label lThongtinBN;
		private System.Windows.Forms.GroupBox gThongtinBN;
		private MaskedTextBox.MaskedTextBox mabn1;
		private MaskedTextBox.MaskedTextBox ngaysinh;
		private MaskedTextBox.MaskedTextBox mabn2;
		private System.Windows.Forms.TextBox ghichu;
		private PinkieControls.ButtonXP butMoi;
		private System.Windows.Forms.Label l_chongiuong;
		private System.Windows.Forms.TextBox magiuong;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Panel pChon;
		private System.Windows.Forms.Panel pGiuong;
		private System.Windows.Forms.Panel pTtin;
		private System.Windows.Forms.Panel panelMain;
		private System.Windows.Forms.Panel panelAAAA;
		private System.Windows.Forms.Label lbRefresh;
		private System.Windows.Forms.Panel pGrid1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cboTinhtrang;
		private System.Windows.Forms.Panel pMain;
		private System.Windows.Forms.Panel pDatgiuong;
		private System.Windows.Forms.Panel pBut;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox dienthoainha;
		private System.Windows.Forms.TextBox coquan;
		private System.Windows.Forms.TextBox didong;
		private System.Windows.Forms.Label label14;
		private System.ComponentModel.Container components = null;

		public frmDatphong(LibMedi.AccessData acc,int userid)
		{
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			m=acc;i_userid=userid;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDatphong));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.hoten = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.namsinh = new System.Windows.Forms.TextBox();
            this.tim = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.diachi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.lbThongtinhanhchanh = new System.Windows.Forms.Label();
            this.pGrid = new System.Windows.Forms.Panel();
            this.pGrid1 = new System.Windows.Forms.Panel();
            this.lbRefresh = new System.Windows.Forms.Label();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.gHanhchinh = new System.Windows.Forms.GroupBox();
            this.didong = new System.Windows.Forms.TextBox();
            this.coquan = new System.Windows.Forms.TextBox();
            this.dienthoainha = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.mapxa1 = new MaskedTextBox.MaskedTextBox();
            this.madantoc = new System.Windows.Forms.TextBox();
            this.mabn1 = new MaskedTextBox.MaskedTextBox();
            this.tendantoc = new System.Windows.Forms.ComboBox();
            this.manuoc = new System.Windows.Forms.TextBox();
            this.tennuoc = new System.Windows.Forms.ComboBox();
            this.matt = new System.Windows.Forms.TextBox();
            this.lmatt = new System.Windows.Forms.Label();
            this.tennn = new System.Windows.Forms.ComboBox();
            this.mann = new System.Windows.Forms.TextBox();
            this.tentinh = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.phai = new System.Windows.Forms.ComboBox();
            this.loaituoi = new System.Windows.Forms.ComboBox();
            this.lmadantoc = new System.Windows.Forms.Label();
            this.ngaysinh = new MaskedTextBox.MaskedTextBox();
            this.tenpxa = new System.Windows.Forms.ComboBox();
            this.mabn2 = new MaskedTextBox.MaskedTextBox();
            this.lmaphuongxa = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.maqu1 = new MaskedTextBox.MaskedTextBox();
            this.cholam = new System.Windows.Forms.TextBox();
            this.tuoi = new System.Windows.Forms.TextBox();
            this.maqu2 = new System.Windows.Forms.TextBox();
            this.tenquan = new System.Windows.Forms.ComboBox();
            this.mapxa2 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.lcholam = new System.Windows.Forms.Label();
            this.lmaqu = new System.Windows.Forms.Label();
            this.lmann = new System.Windows.Forms.Label();
            this.lmanuoc = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.ghichu = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pMain = new System.Windows.Forms.Panel();
            this.pDatgiuong = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.gGiuong = new System.Windows.Forms.GroupBox();
            this.panelAAAA = new System.Windows.Forms.Panel();
            this.pGiuong = new System.Windows.Forms.Panel();
            this.magiuong = new System.Windows.Forms.TextBox();
            this.gThongtinBN = new System.Windows.Forms.GroupBox();
            this.lThongtinBN = new System.Windows.Forms.Label();
            this.pTtin = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboTinhtrang = new System.Windows.Forms.ComboBox();
            this.pChon = new System.Windows.Forms.Panel();
            this.l_chongiuong = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.pButton = new System.Windows.Forms.Panel();
            this.pBut = new System.Windows.Forms.Panel();
            this.butLuu = new PinkieControls.ButtonXP();
            this.butKetthuc = new PinkieControls.ButtonXP();
            this.butMoi = new PinkieControls.ButtonXP();
            this.butXoa = new PinkieControls.ButtonXP();
            this.butIn = new PinkieControls.ButtonXP();
            this.butSua = new PinkieControls.ButtonXP();
            this.butBoqua = new PinkieControls.ButtonXP();
            this.pThongtin = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel3.SuspendLayout();
            this.pGrid.SuspendLayout();
            this.pGrid1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.gHanhchinh.SuspendLayout();
            this.pMain.SuspendLayout();
            this.pDatgiuong.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.gGiuong.SuspendLayout();
            this.panelAAAA.SuspendLayout();
            this.pGiuong.SuspendLayout();
            this.gThongtinBN.SuspendLayout();
            this.pTtin.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pChon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.pButton.SuspendLayout();
            this.pBut.SuspendLayout();
            this.pThongtin.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(32, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(161, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hoten
            // 
            this.hoten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(208, 22);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(201, 21);
            this.hoten.TabIndex = 4;
            this.hoten.Validated += new System.EventHandler(this.hoten_Validated);
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn1_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-88, 296);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 74;
            this.label3.Text = "Ngày giờ đặt :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(208, 45);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(60, 21);
            this.namsinh.TabIndex = 8;
            this.namsinh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tuoi_KeyPress);
            this.namsinh.Validated += new System.EventHandler(this.namsinh_Validated);
            this.namsinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn1_KeyDown);
            // 
            // tim
            // 
            this.tim.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.ForeColor = System.Drawing.Color.Red;
            this.tim.Location = new System.Drawing.Point(8, -32);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(768, 21);
            this.tim.TabIndex = 83;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.Visible = false;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(32, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 23);
            this.label4.TabIndex = 23;
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
            this.diachi.Location = new System.Drawing.Point(80, 114);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(329, 21);
            this.diachi.TabIndex = 24;
            this.diachi.Validated += new System.EventHandler(this.diachi_Validated);
            this.diachi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn1_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-88, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 23);
            this.label5.TabIndex = 88;
            this.label5.Text = "Ghi chú :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 2);
            this.panel1.TabIndex = 89;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.Control;
            this.splitter1.Location = new System.Drawing.Point(0, 2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(2, 590);
            this.splitter1.TabIndex = 90;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(2, 590);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(796, 2);
            this.panel2.TabIndex = 92;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.lbThongtinhanhchanh);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(796, 30);
            this.panel3.TabIndex = 93;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.BackColor = System.Drawing.Color.Lavender;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Blue;
            this.label14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label14.Location = new System.Drawing.Point(560, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(232, 32);
            this.label14.TabIndex = 153;
            this.label14.Text = "CẬP NHẬT LẠI GIƯỜNG TRỐNG";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // lbThongtinhanhchanh
            // 
            this.lbThongtinhanhchanh.BackColor = System.Drawing.Color.Lavender;
            this.lbThongtinhanhchanh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbThongtinhanhchanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbThongtinhanhchanh.Font = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThongtinhanhchanh.ForeColor = System.Drawing.Color.Navy;
            this.lbThongtinhanhchanh.Image = ((System.Drawing.Image)(resources.GetObject("lbThongtinhanhchanh.Image")));
            this.lbThongtinhanhchanh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbThongtinhanhchanh.Location = new System.Drawing.Point(0, 0);
            this.lbThongtinhanhchanh.Name = "lbThongtinhanhchanh";
            this.lbThongtinhanhchanh.Size = new System.Drawing.Size(796, 30);
            this.lbThongtinhanhchanh.TabIndex = 8;
            this.lbThongtinhanhchanh.Text = "    ĐẶT GIƯỜNG";
            this.lbThongtinhanhchanh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pGrid
            // 
            this.pGrid.BackColor = System.Drawing.Color.AliceBlue;
            this.pGrid.Controls.Add(this.pGrid1);
            this.pGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pGrid.Location = new System.Drawing.Point(2, 358);
            this.pGrid.Name = "pGrid";
            this.pGrid.Size = new System.Drawing.Size(796, 232);
            this.pGrid.TabIndex = 94;
            // 
            // pGrid1
            // 
            this.pGrid1.Controls.Add(this.lbRefresh);
            this.pGrid1.Controls.Add(this.dataGrid2);
            this.pGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pGrid1.Location = new System.Drawing.Point(0, 0);
            this.pGrid1.Name = "pGrid1";
            this.pGrid1.Size = new System.Drawing.Size(796, 232);
            this.pGrid1.TabIndex = 195;
            // 
            // lbRefresh
            // 
            this.lbRefresh.BackColor = System.Drawing.Color.AliceBlue;
            this.lbRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("lbRefresh.Image")));
            this.lbRefresh.Location = new System.Drawing.Point(3, 2);
            this.lbRefresh.Name = "lbRefresh";
            this.lbRefresh.Size = new System.Drawing.Size(18, 18);
            this.lbRefresh.TabIndex = 194;
            this.lbRefresh.Click += new System.EventHandler(this.lbRefresh_Click);
            // 
            // dataGrid2
            // 
            this.dataGrid2.BackgroundColor = System.Drawing.Color.Lavender;
            this.dataGrid2.CaptionBackColor = System.Drawing.Color.AliceBlue;
            this.dataGrid2.CaptionForeColor = System.Drawing.Color.Blue;
            this.dataGrid2.CaptionText = "     Danh sách đặt giường";
            this.dataGrid2.DataMember = "";
            this.dataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid2.FlatMode = true;
            this.dataGrid2.HeaderForeColor = System.Drawing.Color.Lavender;
            this.dataGrid2.Location = new System.Drawing.Point(0, 0);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.ReadOnly = true;
            this.dataGrid2.RowHeaderWidth = 10;
            this.dataGrid2.Size = new System.Drawing.Size(796, 232);
            this.dataGrid2.TabIndex = 0;
            this.dataGrid2.CurrentCellChanged += new System.EventHandler(this.dataGrid2_CurrentCellChanged);
            // 
            // gHanhchinh
            // 
            this.gHanhchinh.BackColor = System.Drawing.Color.Lavender;
            this.gHanhchinh.Controls.Add(this.didong);
            this.gHanhchinh.Controls.Add(this.coquan);
            this.gHanhchinh.Controls.Add(this.dienthoainha);
            this.gHanhchinh.Controls.Add(this.label7);
            this.gHanhchinh.Controls.Add(this.label4);
            this.gHanhchinh.Controls.Add(this.label12);
            this.gHanhchinh.Controls.Add(this.hoten);
            this.gHanhchinh.Controls.Add(this.mapxa1);
            this.gHanhchinh.Controls.Add(this.madantoc);
            this.gHanhchinh.Controls.Add(this.mabn1);
            this.gHanhchinh.Controls.Add(this.tendantoc);
            this.gHanhchinh.Controls.Add(this.manuoc);
            this.gHanhchinh.Controls.Add(this.tennuoc);
            this.gHanhchinh.Controls.Add(this.matt);
            this.gHanhchinh.Controls.Add(this.namsinh);
            this.gHanhchinh.Controls.Add(this.lmatt);
            this.gHanhchinh.Controls.Add(this.label1);
            this.gHanhchinh.Controls.Add(this.tennn);
            this.gHanhchinh.Controls.Add(this.mann);
            this.gHanhchinh.Controls.Add(this.tentinh);
            this.gHanhchinh.Controls.Add(this.label11);
            this.gHanhchinh.Controls.Add(this.phai);
            this.gHanhchinh.Controls.Add(this.loaituoi);
            this.gHanhchinh.Controls.Add(this.lmadantoc);
            this.gHanhchinh.Controls.Add(this.ngaysinh);
            this.gHanhchinh.Controls.Add(this.tenpxa);
            this.gHanhchinh.Controls.Add(this.mabn2);
            this.gHanhchinh.Controls.Add(this.lmaphuongxa);
            this.gHanhchinh.Controls.Add(this.label10);
            this.gHanhchinh.Controls.Add(this.maqu1);
            this.gHanhchinh.Controls.Add(this.cholam);
            this.gHanhchinh.Controls.Add(this.tuoi);
            this.gHanhchinh.Controls.Add(this.diachi);
            this.gHanhchinh.Controls.Add(this.maqu2);
            this.gHanhchinh.Controls.Add(this.tenquan);
            this.gHanhchinh.Controls.Add(this.mapxa2);
            this.gHanhchinh.Controls.Add(this.label16);
            this.gHanhchinh.Controls.Add(this.lcholam);
            this.gHanhchinh.Controls.Add(this.lmaqu);
            this.gHanhchinh.Controls.Add(this.lmann);
            this.gHanhchinh.Controls.Add(this.lmanuoc);
            this.gHanhchinh.Controls.Add(this.label2);
            this.gHanhchinh.Controls.Add(this.label13);
            this.gHanhchinh.Controls.Add(this.ghichu);
            this.gHanhchinh.Controls.Add(this.label8);
            this.gHanhchinh.Controls.Add(this.label9);
            this.gHanhchinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gHanhchinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gHanhchinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gHanhchinh.Location = new System.Drawing.Point(0, 0);
            this.gHanhchinh.Name = "gHanhchinh";
            this.gHanhchinh.Size = new System.Drawing.Size(412, 282);
            this.gHanhchinh.TabIndex = 0;
            this.gHanhchinh.TabStop = false;
            this.gHanhchinh.Text = "THÔNG TIN HÀNH CHÍNH ";
            // 
            // didong
            // 
            this.didong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.didong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.didong.Enabled = false;
            this.didong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.didong.Location = new System.Drawing.Point(356, 229);
            this.didong.Name = "didong";
            this.didong.Size = new System.Drawing.Size(53, 21);
            this.didong.TabIndex = 44;
            this.didong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cholam_KeyDown);
            // 
            // coquan
            // 
            this.coquan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.coquan.Enabled = false;
            this.coquan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coquan.Location = new System.Drawing.Point(218, 229);
            this.coquan.Name = "coquan";
            this.coquan.Size = new System.Drawing.Size(88, 21);
            this.coquan.TabIndex = 42;
            this.coquan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cholam_KeyDown);
            // 
            // dienthoainha
            // 
            this.dienthoainha.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dienthoainha.Enabled = false;
            this.dienthoainha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dienthoainha.Location = new System.Drawing.Point(80, 229);
            this.dienthoainha.Name = "dienthoainha";
            this.dienthoainha.Size = new System.Drawing.Size(88, 21);
            this.dienthoainha.TabIndex = 39;
            this.dienthoainha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cholam_KeyDown);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label7.Location = new System.Drawing.Point(-8, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 38;
            this.label7.Text = "Điện thoại nhà :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label12.Location = new System.Drawing.Point(272, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 23);
            this.label12.TabIndex = 9;
            this.label12.Text = "Tuổi :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mapxa1
            // 
            this.mapxa1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapxa1.Enabled = false;
            this.mapxa1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapxa1.Location = new System.Drawing.Point(80, 183);
            this.mapxa1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mapxa1.MaxLength = 5;
            this.mapxa1.Name = "mapxa1";
            this.mapxa1.Size = new System.Drawing.Size(71, 21);
            this.mapxa1.TabIndex = 33;
            this.mapxa1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn1_KeyDown);
            // 
            // madantoc
            // 
            this.madantoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madantoc.Enabled = false;
            this.madantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madantoc.Location = new System.Drawing.Point(80, 91);
            this.madantoc.MaxLength = 2;
            this.madantoc.Name = "madantoc";
            this.madantoc.Size = new System.Drawing.Size(30, 21);
            this.madantoc.TabIndex = 18;
            this.madantoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tuoi_KeyPress);
            this.madantoc.Validated += new System.EventHandler(this.madantoc_Validated);
            this.madantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn1_KeyDown);
            // 
            // mabn1
            // 
            this.mabn1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn1.Location = new System.Drawing.Point(80, 22);
            this.mabn1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabn1.MaxLength = 2;
            this.mabn1.Name = "mabn1";
            this.mabn1.Size = new System.Drawing.Size(22, 21);
            this.mabn1.TabIndex = 1;
            this.mabn1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn1_KeyDown);
            // 
            // tendantoc
            // 
            this.tendantoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendantoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tendantoc.Enabled = false;
            this.tendantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendantoc.Location = new System.Drawing.Point(112, 91);
            this.tendantoc.Name = "tendantoc";
            this.tendantoc.Size = new System.Drawing.Size(98, 21);
            this.tendantoc.TabIndex = 19;
            this.tendantoc.SelectedIndexChanged += new System.EventHandler(this.tendantoc_SelectedIndexChanged);
            this.tendantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn1_KeyDown);
            // 
            // manuoc
            // 
            this.manuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manuoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.manuoc.Enabled = false;
            this.manuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manuoc.Location = new System.Drawing.Point(276, 91);
            this.manuoc.MaxLength = 2;
            this.manuoc.Name = "manuoc";
            this.manuoc.Size = new System.Drawing.Size(32, 21);
            this.manuoc.TabIndex = 21;
            this.manuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn1_KeyDown);
            // 
            // tennuoc
            // 
            this.tennuoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tennuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennuoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tennuoc.Enabled = false;
            this.tennuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennuoc.Location = new System.Drawing.Point(308, 91);
            this.tennuoc.Name = "tennuoc";
            this.tennuoc.Size = new System.Drawing.Size(101, 21);
            this.tennuoc.TabIndex = 22;
            this.tennuoc.SelectedIndexChanged += new System.EventHandler(this.tennuoc_SelectedIndexChanged);
            this.tennuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn1_KeyDown);
            // 
            // matt
            // 
            this.matt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.matt.Enabled = false;
            this.matt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matt.Location = new System.Drawing.Point(80, 137);
            this.matt.MaxLength = 3;
            this.matt.Name = "matt";
            this.matt.Size = new System.Drawing.Size(30, 21);
            this.matt.TabIndex = 26;
            this.matt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn1_KeyDown);
            // 
            // lmatt
            // 
            this.lmatt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lmatt.Location = new System.Drawing.Point(24, 137);
            this.lmatt.Name = "lmatt";
            this.lmatt.Size = new System.Drawing.Size(56, 23);
            this.lmatt.TabIndex = 25;
            this.lmatt.Text = "Tỉnh/TP :";
            this.lmatt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tennn
            // 
            this.tennn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tennn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tennn.Enabled = false;
            this.tennn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennn.Location = new System.Drawing.Point(237, 68);
            this.tennn.Name = "tennn";
            this.tennn.Size = new System.Drawing.Size(172, 21);
            this.tennn.TabIndex = 16;
            this.tennn.SelectedIndexChanged += new System.EventHandler(this.tennn_SelectedIndexChanged);
            this.tennn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn1_KeyDown);
            // 
            // mann
            // 
            this.mann.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mann.Enabled = false;
            this.mann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mann.Location = new System.Drawing.Point(208, 68);
            this.mann.MaxLength = 2;
            this.mann.Name = "mann";
            this.mann.Size = new System.Drawing.Size(28, 21);
            this.mann.TabIndex = 15;
            this.mann.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn1_KeyDown);
            // 
            // tentinh
            // 
            this.tentinh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tentinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tentinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tentinh.Enabled = false;
            this.tentinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tentinh.Location = new System.Drawing.Point(112, 137);
            this.tentinh.Name = "tentinh";
            this.tentinh.Size = new System.Drawing.Size(297, 21);
            this.tentinh.TabIndex = 27;
            this.tentinh.SelectedIndexChanged += new System.EventHandler(this.tentinh_SelectedIndexChanged);
            this.tentinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn1_KeyDown);
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label11.Location = new System.Drawing.Point(16, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 23);
            this.label11.TabIndex = 12;
            this.label11.Text = "Giới tính :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.phai.Enabled = false;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.phai.Location = new System.Drawing.Point(80, 68);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(50, 21);
            this.phai.TabIndex = 13;
            this.phai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn1_KeyDown);
            // 
            // loaituoi
            // 
            this.loaituoi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.loaituoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaituoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loaituoi.Enabled = false;
            this.loaituoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaituoi.Items.AddRange(new object[] {
            "Tuổi",
            "Tháng",
            "Ngày",
            "Giờ"});
            this.loaituoi.Location = new System.Drawing.Point(336, 45);
            this.loaituoi.Name = "loaituoi";
            this.loaituoi.Size = new System.Drawing.Size(73, 21);
            this.loaituoi.TabIndex = 11;
            this.loaituoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn1_KeyDown);
            // 
            // lmadantoc
            // 
            this.lmadantoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lmadantoc.Location = new System.Drawing.Point(24, 91);
            this.lmadantoc.Name = "lmadantoc";
            this.lmadantoc.Size = new System.Drawing.Size(56, 23);
            this.lmadantoc.TabIndex = 17;
            this.lmadantoc.Text = "Dân tộc :";
            this.lmadantoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngaysinh
            // 
            this.ngaysinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaysinh.Enabled = false;
            this.ngaysinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysinh.Location = new System.Drawing.Point(80, 45);
            this.ngaysinh.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.ngaysinh.MaxLength = 10;
            this.ngaysinh.Name = "ngaysinh";
            this.ngaysinh.Size = new System.Drawing.Size(74, 21);
            this.ngaysinh.TabIndex = 6;
            this.ngaysinh.Validated += new System.EventHandler(this.ngaysinh_Validated);
            this.ngaysinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn1_KeyDown);
            // 
            // tenpxa
            // 
            this.tenpxa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenpxa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenpxa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenpxa.Enabled = false;
            this.tenpxa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenpxa.Location = new System.Drawing.Point(184, 183);
            this.tenpxa.Name = "tenpxa";
            this.tenpxa.Size = new System.Drawing.Size(225, 21);
            this.tenpxa.TabIndex = 35;
            this.tenpxa.SelectedIndexChanged += new System.EventHandler(this.tenpxa_SelectedIndexChanged);
            this.tenpxa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn1_KeyDown);
            // 
            // mabn2
            // 
            this.mabn2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn2.Location = new System.Drawing.Point(104, 22);
            this.mabn2.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabn2.MaxLength = 6;
            this.mabn2.Name = "mabn2";
            this.mabn2.Size = new System.Drawing.Size(50, 21);
            this.mabn2.TabIndex = 2;
            this.mabn2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tuoi_KeyPress);
            this.mabn2.Validated += new System.EventHandler(this.mabn_Validated);
            this.mabn2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn1_KeyDown);
            // 
            // lmaphuongxa
            // 
            this.lmaphuongxa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lmaphuongxa.Location = new System.Drawing.Point(8, 183);
            this.lmaphuongxa.Name = "lmaphuongxa";
            this.lmaphuongxa.Size = new System.Drawing.Size(72, 23);
            this.lmaphuongxa.TabIndex = 32;
            this.lmaphuongxa.Text = "Phường/Xã :";
            this.lmaphuongxa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label10.Location = new System.Drawing.Point(16, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 23);
            this.label10.TabIndex = 5;
            this.label10.Text = "Ngày sinh :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // maqu1
            // 
            this.maqu1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maqu1.Enabled = false;
            this.maqu1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maqu1.Location = new System.Drawing.Point(80, 160);
            this.maqu1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.maqu1.MaxLength = 3;
            this.maqu1.Name = "maqu1";
            this.maqu1.Size = new System.Drawing.Size(30, 21);
            this.maqu1.TabIndex = 29;
            this.maqu1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn1_KeyDown);
            // 
            // cholam
            // 
            this.cholam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cholam.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cholam.Enabled = false;
            this.cholam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cholam.Location = new System.Drawing.Point(80, 206);
            this.cholam.Name = "cholam";
            this.cholam.Size = new System.Drawing.Size(329, 21);
            this.cholam.TabIndex = 37;
            this.cholam.Validated += new System.EventHandler(this.cholam_Validated);
            this.cholam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cholam_KeyDown);
            // 
            // tuoi
            // 
            this.tuoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tuoi.Enabled = false;
            this.tuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuoi.Location = new System.Drawing.Point(304, 45);
            this.tuoi.MaxLength = 3;
            this.tuoi.Name = "tuoi";
            this.tuoi.Size = new System.Drawing.Size(32, 21);
            this.tuoi.TabIndex = 10;
            this.tuoi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tuoi_KeyPress);
            this.tuoi.Validated += new System.EventHandler(this.tuoi_Validated);
            this.tuoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn1_KeyDown);
            // 
            // maqu2
            // 
            this.maqu2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maqu2.Enabled = false;
            this.maqu2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maqu2.Location = new System.Drawing.Point(112, 160);
            this.maqu2.MaxLength = 2;
            this.maqu2.Name = "maqu2";
            this.maqu2.Size = new System.Drawing.Size(39, 21);
            this.maqu2.TabIndex = 30;
            this.maqu2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn1_KeyDown);
            // 
            // tenquan
            // 
            this.tenquan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenquan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenquan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenquan.Enabled = false;
            this.tenquan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenquan.Location = new System.Drawing.Point(152, 160);
            this.tenquan.Name = "tenquan";
            this.tenquan.Size = new System.Drawing.Size(257, 21);
            this.tenquan.TabIndex = 31;
            this.tenquan.SelectedIndexChanged += new System.EventHandler(this.tenquan_SelectedIndexChanged);
            this.tenquan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn1_KeyDown);
            // 
            // mapxa2
            // 
            this.mapxa2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapxa2.Enabled = false;
            this.mapxa2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapxa2.Location = new System.Drawing.Point(152, 183);
            this.mapxa2.MaxLength = 2;
            this.mapxa2.Name = "mapxa2";
            this.mapxa2.Size = new System.Drawing.Size(31, 21);
            this.mapxa2.TabIndex = 34;
            this.mapxa2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn1_KeyDown);
            // 
            // label16
            // 
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label16.Location = new System.Drawing.Point(145, 45);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 23);
            this.label16.TabIndex = 7;
            this.label16.Text = "Năm sinh :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lcholam
            // 
            this.lcholam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lcholam.Location = new System.Drawing.Point(8, 206);
            this.lcholam.Name = "lcholam";
            this.lcholam.Size = new System.Drawing.Size(72, 23);
            this.lcholam.TabIndex = 36;
            this.lcholam.Text = "Nơi làm việc :";
            this.lcholam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmaqu
            // 
            this.lmaqu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lmaqu.Location = new System.Drawing.Point(16, 160);
            this.lmaqu.Name = "lmaqu";
            this.lmaqu.Size = new System.Drawing.Size(64, 23);
            this.lmaqu.TabIndex = 28;
            this.lmaqu.Text = "Quận/H :";
            this.lmaqu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmann
            // 
            this.lmann.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lmann.Location = new System.Drawing.Point(128, 68);
            this.lmann.Name = "lmann";
            this.lmann.Size = new System.Drawing.Size(80, 23);
            this.lmann.TabIndex = 14;
            this.lmann.Text = "Nghề nghiệp :";
            this.lmann.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmanuoc
            // 
            this.lmanuoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lmanuoc.Location = new System.Drawing.Point(209, 91);
            this.lmanuoc.Name = "lmanuoc";
            this.lmanuoc.Size = new System.Drawing.Size(64, 23);
            this.lmanuoc.TabIndex = 20;
            this.lmanuoc.Text = "Quốc tịch :";
            this.lmanuoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label13.Location = new System.Drawing.Point(30, 253);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 16);
            this.label13.TabIndex = 45;
            this.label13.Text = "Ghi chú :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ghichu
            // 
            this.ghichu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ghichu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ghichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ghichu.Location = new System.Drawing.Point(80, 252);
            this.ghichu.Multiline = true;
            this.ghichu.Name = "ghichu";
            this.ghichu.Size = new System.Drawing.Size(329, 26);
            this.ghichu.TabIndex = 46;
            this.ghichu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ghichu_KeyDown);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label8.Location = new System.Drawing.Point(130, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 41;
            this.label8.Text = "Cơ quan :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label9.Location = new System.Drawing.Point(268, 232);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 16);
            this.label9.TabIndex = 43;
            this.label9.Text = "Di động :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pMain
            // 
            this.pMain.BackColor = System.Drawing.Color.Lavender;
            this.pMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pMain.Controls.Add(this.pDatgiuong);
            this.pMain.Controls.Add(this.label3);
            this.pMain.Controls.Add(this.label5);
            this.pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMain.ForeColor = System.Drawing.Color.Navy;
            this.pMain.Location = new System.Drawing.Point(2, 32);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(796, 326);
            this.pMain.TabIndex = 127;
            // 
            // pDatgiuong
            // 
            this.pDatgiuong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pDatgiuong.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDatgiuong.Controls.Add(this.panelMain);
            this.pDatgiuong.Location = new System.Drawing.Point(416, -2);
            this.pDatgiuong.Name = "pDatgiuong";
            this.pDatgiuong.Size = new System.Drawing.Size(376, 286);
            this.pDatgiuong.TabIndex = 89;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.gGiuong);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(372, 282);
            this.panelMain.TabIndex = 1;
            // 
            // gGiuong
            // 
            this.gGiuong.BackColor = System.Drawing.Color.Lavender;
            this.gGiuong.Controls.Add(this.panelAAAA);
            this.gGiuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gGiuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gGiuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gGiuong.Location = new System.Drawing.Point(0, 0);
            this.gGiuong.Name = "gGiuong";
            this.gGiuong.Size = new System.Drawing.Size(372, 282);
            this.gGiuong.TabIndex = 0;
            this.gGiuong.TabStop = false;
            this.gGiuong.Text = "THÔNG TIN ĐẶT GIƯỜNG";
            // 
            // panelAAAA
            // 
            this.panelAAAA.Controls.Add(this.pGiuong);
            this.panelAAAA.Controls.Add(this.pTtin);
            this.panelAAAA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAAAA.Location = new System.Drawing.Point(3, 16);
            this.panelAAAA.Name = "panelAAAA";
            this.panelAAAA.Size = new System.Drawing.Size(366, 263);
            this.panelAAAA.TabIndex = 158;
            // 
            // pGiuong
            // 
            this.pGiuong.Controls.Add(this.magiuong);
            this.pGiuong.Controls.Add(this.gThongtinBN);
            this.pGiuong.Dock = System.Windows.Forms.DockStyle.Top;
            this.pGiuong.Location = new System.Drawing.Point(0, 0);
            this.pGiuong.Name = "pGiuong";
            this.pGiuong.Size = new System.Drawing.Size(366, 88);
            this.pGiuong.TabIndex = 157;
            // 
            // magiuong
            // 
            this.magiuong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.magiuong.Enabled = false;
            this.magiuong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.magiuong.Location = new System.Drawing.Point(112, 144);
            this.magiuong.Name = "magiuong";
            this.magiuong.Size = new System.Drawing.Size(42, 21);
            this.magiuong.TabIndex = 154;
            this.magiuong.Visible = false;
            // 
            // gThongtinBN
            // 
            this.gThongtinBN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gThongtinBN.Controls.Add(this.lThongtinBN);
            this.gThongtinBN.ForeColor = System.Drawing.Color.Red;
            this.gThongtinBN.Location = new System.Drawing.Point(0, 0);
            this.gThongtinBN.Name = "gThongtinBN";
            this.gThongtinBN.Size = new System.Drawing.Size(367, 88);
            this.gThongtinBN.TabIndex = 12;
            this.gThongtinBN.TabStop = false;
            this.gThongtinBN.Text = "Thông tin bệnh nhân";
            // 
            // lThongtinBN
            // 
            this.lThongtinBN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lThongtinBN.BackColor = System.Drawing.Color.Lavender;
            this.lThongtinBN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lThongtinBN.Location = new System.Drawing.Point(8, 16);
            this.lThongtinBN.Name = "lThongtinBN";
            this.lThongtinBN.Size = new System.Drawing.Size(352, 64);
            this.lThongtinBN.TabIndex = 0;
            this.lThongtinBN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pTtin
            // 
            this.pTtin.BackColor = System.Drawing.Color.Lavender;
            this.pTtin.Controls.Add(this.groupBox1);
            this.pTtin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pTtin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.pTtin.Location = new System.Drawing.Point(0, 0);
            this.pTtin.Name = "pTtin";
            this.pTtin.Size = new System.Drawing.Size(366, 263);
            this.pTtin.TabIndex = 155;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cboTinhtrang);
            this.groupBox1.Controls.Add(this.pChon);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dataGrid1);
            this.groupBox1.Location = new System.Drawing.Point(0, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 177);
            this.groupBox1.TabIndex = 156;
            this.groupBox1.TabStop = false;
            // 
            // cboTinhtrang
            // 
            this.cboTinhtrang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTinhtrang.BackColor = System.Drawing.Color.White;
            this.cboTinhtrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTinhtrang.Location = new System.Drawing.Point(57, 128);
            this.cboTinhtrang.Name = "cboTinhtrang";
            this.cboTinhtrang.Size = new System.Drawing.Size(308, 21);
            this.cboTinhtrang.TabIndex = 1;
            // 
            // pChon
            // 
            this.pChon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pChon.Controls.Add(this.l_chongiuong);
            this.pChon.Location = new System.Drawing.Point(3, 151);
            this.pChon.Name = "pChon";
            this.pChon.Size = new System.Drawing.Size(357, 24);
            this.pChon.TabIndex = 156;
            this.pChon.Paint += new System.Windows.Forms.PaintEventHandler(this.pChon_Paint);
            // 
            // l_chongiuong
            // 
            this.l_chongiuong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.l_chongiuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_chongiuong.ForeColor = System.Drawing.Color.Blue;
            this.l_chongiuong.Image = ((System.Drawing.Image)(resources.GetObject("l_chongiuong.Image")));
            this.l_chongiuong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.l_chongiuong.Location = new System.Drawing.Point(11, 1);
            this.l_chongiuong.Name = "l_chongiuong";
            this.l_chongiuong.Size = new System.Drawing.Size(346, 20);
            this.l_chongiuong.TabIndex = 152;
            this.l_chongiuong.Text = "        CHỌN GIƯỜNG BỆNH";
            this.l_chongiuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.l_chongiuong.Click += new System.EventHandler(this.l_chongiuong_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label6.Location = new System.Drawing.Point(-6, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tình trạng :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.BackgroundColor = System.Drawing.Color.Lavender;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataGrid1.CaptionVisible = false;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(3, 11);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.Size = new System.Drawing.Size(362, 114);
            this.dataGrid1.TabIndex = 155;
            // 
            // pButton
            // 
            this.pButton.BackColor = System.Drawing.Color.Lavender;
            this.pButton.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pButton.Controls.Add(this.pBut);
            this.pButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pButton.Location = new System.Drawing.Point(2, 318);
            this.pButton.Name = "pButton";
            this.pButton.Size = new System.Drawing.Size(796, 40);
            this.pButton.TabIndex = 128;
            // 
            // pBut
            // 
            this.pBut.Controls.Add(this.butLuu);
            this.pBut.Controls.Add(this.butKetthuc);
            this.pBut.Controls.Add(this.butMoi);
            this.pBut.Controls.Add(this.butXoa);
            this.pBut.Controls.Add(this.butIn);
            this.pBut.Controls.Add(this.butSua);
            this.pBut.Controls.Add(this.butBoqua);
            this.pBut.Location = new System.Drawing.Point(3, 1);
            this.pBut.Name = "pBut";
            this.pBut.Size = new System.Drawing.Size(786, 35);
            this.pBut.TabIndex = 0;
            // 
            // butLuu
            // 
            this.butLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.butLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butLuu.DefaultScheme = true;
            this.butLuu.DialogResult = System.Windows.Forms.DialogResult.None;
            this.butLuu.Hint = "";
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.Location = new System.Drawing.Point(181, 1);
            this.butLuu.Name = "butLuu";
            this.butLuu.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.butLuu.Size = new System.Drawing.Size(79, 33);
            this.butLuu.TabIndex = 0;
            this.butLuu.Text = "&Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            this.butLuu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.butMoi_KeyDown);
            // 
            // butKetthuc
            // 
            this.butKetthuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.butKetthuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butKetthuc.DefaultScheme = true;
            this.butKetthuc.DialogResult = System.Windows.Forms.DialogResult.None;
            this.butKetthuc.Hint = "";
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.Location = new System.Drawing.Point(585, 1);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.butKetthuc.Size = new System.Drawing.Size(88, 33);
            this.butKetthuc.TabIndex = 6;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            this.butKetthuc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.butMoi_KeyDown);
            // 
            // butMoi
            // 
            this.butMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.butMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butMoi.DefaultScheme = true;
            this.butMoi.DialogResult = System.Windows.Forms.DialogResult.None;
            this.butMoi.Hint = "";
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.Location = new System.Drawing.Point(104, 1);
            this.butMoi.Name = "butMoi";
            this.butMoi.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.butMoi.Size = new System.Drawing.Size(77, 33);
            this.butMoi.TabIndex = 1;
            this.butMoi.Text = "&Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            this.butMoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.butMoi_KeyDown);
            // 
            // butXoa
            // 
            this.butXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.butXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butXoa.DefaultScheme = true;
            this.butXoa.DialogResult = System.Windows.Forms.DialogResult.None;
            this.butXoa.Hint = "";
            this.butXoa.Image = ((System.Drawing.Image)(resources.GetObject("butXoa.Image")));
            this.butXoa.Location = new System.Drawing.Point(342, 1);
            this.butXoa.Name = "butXoa";
            this.butXoa.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.butXoa.Size = new System.Drawing.Size(81, 33);
            this.butXoa.TabIndex = 3;
            this.butXoa.Text = "&Xoá";
            this.butXoa.Click += new System.EventHandler(this.butHuy_Click);
            this.butXoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.butMoi_KeyDown);
            // 
            // butIn
            // 
            this.butIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.butIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butIn.DefaultScheme = true;
            this.butIn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.butIn.Hint = "";
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.Location = new System.Drawing.Point(507, 1);
            this.butIn.Name = "butIn";
            this.butIn.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.butIn.Size = new System.Drawing.Size(78, 33);
            this.butIn.TabIndex = 5;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            this.butIn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.butMoi_KeyDown);
            // 
            // butSua
            // 
            this.butSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.butSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butSua.DefaultScheme = true;
            this.butSua.DialogResult = System.Windows.Forms.DialogResult.None;
            this.butSua.Hint = "";
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.Location = new System.Drawing.Point(260, 1);
            this.butSua.Name = "butSua";
            this.butSua.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.butSua.Size = new System.Drawing.Size(82, 33);
            this.butSua.TabIndex = 2;
            this.butSua.Text = "&Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            this.butSua.KeyDown += new System.Windows.Forms.KeyEventHandler(this.butMoi_KeyDown);
            // 
            // butBoqua
            // 
            this.butBoqua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.butBoqua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butBoqua.DefaultScheme = true;
            this.butBoqua.DialogResult = System.Windows.Forms.DialogResult.None;
            this.butBoqua.Hint = "";
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.Location = new System.Drawing.Point(423, 1);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.butBoqua.Size = new System.Drawing.Size(84, 33);
            this.butBoqua.TabIndex = 4;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            this.butBoqua.KeyDown += new System.Windows.Forms.KeyEventHandler(this.butMoi_KeyDown);
            // 
            // pThongtin
            // 
            this.pThongtin.BackColor = System.Drawing.Color.Lavender;
            this.pThongtin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pThongtin.Controls.Add(this.gHanhchinh);
            this.pThongtin.Dock = System.Windows.Forms.DockStyle.Left;
            this.pThongtin.Location = new System.Drawing.Point(2, 32);
            this.pThongtin.Name = "pThongtin";
            this.pThongtin.Size = new System.Drawing.Size(416, 286);
            this.pThongtin.TabIndex = 126;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(798, 2);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(2, 590);
            this.splitter2.TabIndex = 91;
            this.splitter2.TabStop = false;
            // 
            // frmDatphong
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(800, 592);
            this.ControlBox = false;
            this.Controls.Add(this.pThongtin);
            this.Controls.Add(this.pButton);
            this.Controls.Add(this.pMain);
            this.Controls.Add(this.pGrid);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tim);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDatphong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đặt phòng/giường";
            this.SizeChanged += new System.EventHandler(this.frmDatphong_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDatphong_KeyDown);
            this.Load += new System.EventHandler(this.frmDatphong_Load);
            this.panel3.ResumeLayout(false);
            this.pGrid.ResumeLayout(false);
            this.pGrid1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.gHanhchinh.ResumeLayout(false);
            this.gHanhchinh.PerformLayout();
            this.pMain.ResumeLayout(false);
            this.pDatgiuong.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.gGiuong.ResumeLayout(false);
            this.panelAAAA.ResumeLayout(false);
            this.pGiuong.ResumeLayout(false);
            this.pGiuong.PerformLayout();
            this.gThongtinBN.ResumeLayout(false);
            this.pTtin.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.pChon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.pButton.ResumeLayout(false);
            this.pBut.ResumeLayout(false);
            this.pThongtin.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmDatphong_Load(object sender, System.EventArgs e)
		{
            if (m.Mabv == "101.4.18" || m.Mabv == "711.7.10")
			{
				DataSet ads=new DataSet();
				ads.ReadXml(@"..\..\..\xml\tinhtrang.xml",XmlReadMode.ReadSchema);
				DataRow nrow = ads.Tables[0].NewRow();
				nrow["ma"]="";
				nrow["ten"]="";
				ads.Tables[0].Rows.InsertAt(nrow,0);
				cboTinhtrang.DisplayMember="ten";
				cboTinhtrang.ValueMember="ma";
				cboTinhtrang.DataSource=ads.Tables[0];
				bTiepdon=false;
			}
			else 
			{
				label6.Visible=false;
				cboTinhtrang.Visible=false;
				bTiepdon=true;
			}
            //
            p.f_tao_db_phonggiuong();
            //
            bTinhGiuong_lucdatgiuong = m.bTinhtiengiuong_lucdatgiuong;
			DataSet dsxml=new DataSet();
			//
			dsin=m.get_data("select '' mabn,'' hoten,'' namsinh,'' diachi,'' ngaygio,'' khoaphong,'' giuong,0 dongia from dual");
			itable=m.tableid("","datgiuong");
			user=m.user;
            dtkp = m.get_data("select * from " + user + ".btdkp_bv where loai=0").Tables[0];
			
			//Load danh muc hanh chinh
			phai.SelectedIndex=0;
			loaituoi.SelectedIndex=0;
			load_danhmuc();
			lan.Read_dtgrid_to_Xml(dataGrid2, this.Name.ToString()+"_"+dataGrid2.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid2, this.Name.ToString()+"_"+dataGrid2.Name.ToString());
			ena_button(false);
			bNew=true;bEdit=false;
			mabn1.Text=DateTime.Now.Year.ToString().Substring(2);
			SendKeys.Send("{Tab}");
		}
		private void load_danhmuc()
		{
			tennn.DisplayMember="TENNN";
			tennn.ValueMember="MANN";
			load_btdnn(0);
			
			tendantoc.DisplayMember="DANTOC";
			tendantoc.ValueMember="MADANTOC";
            tendantoc.DataSource = m.get_data("select * from " + user + ".btddt order by madantoc").Tables[0];
			tendantoc.SelectedValue="25";

			tentinh.DisplayMember="TENTT";
			tentinh.ValueMember="MATT";
            tentinh.DataSource = m.get_data("select * from " + user + ".btdtt order by matt").Tables[0];
			tentinh.SelectedValue=m.Mabv.Substring(0,3);

			tenquan.DisplayMember="TENQUAN";
			tenquan.ValueMember="MAQU";
			load_quan();
            
			tenpxa.DisplayMember="TENPXA";
			tenpxa.ValueMember="MAPHUONGXA";
			load_pxa();
			
			tennuoc.DisplayMember="TEN";
			tennuoc.ValueMember="MA";
            tennuoc.DataSource = m.get_data("select * from " + user + ".dmquocgia order by ma").Tables[0];
			tennuoc.SelectedIndex=-1;
		}
		private void load_btdnn(int i)
		{
            if (i == 0) tennn.DataSource = m.get_data("select * from " + user + ".btdnn_bv order by mann").Tables[0];
			else
			{
				if (namsinh.Text!="")
				{
					if (DateTime.Now.Year-int.Parse(namsinh.Text)<iTreem6)
                        tennn.DataSource = m.get_data("select * from " + user + ".btdnn_bv where mannbo='01' order by mann").Tables[0];
					else if (DateTime.Now.Year-int.Parse(namsinh.Text)<iTreem15)
                        tennn.DataSource = m.get_data("select * from " + user + ".btdnn_bv where mannbo in ('01','02') order by mann").Tables[0];
                    else tennn.DataSource = m.get_data("select * from " + user + ".btdnn_bv where mannbo<>'01' order by mann").Tables[0];
				}
			}
		}
		private void load_mann(bool btreem)
		{
			if (btreem)
                tennn.DataSource = m.get_data("select * from " + user + ".btdnn_bv where mannbo='01' order by mann").Tables[0];
			else
                tennn.DataSource = m.get_data("select * from " + user + ".btdnn_bv order by mann").Tables[0];
		}
		private void ena_tuoi(bool ena)
		{
			tuoi.Enabled=ena;
			loaituoi.Enabled=ena;
		}
		private void ena_namsinh(bool ena)
		{
			namsinh.Enabled=ena;
		}

		private void load_quan()
		{
            tenquan.DataSource = m.get_data("select * from " + user + ".btdquan where matt='" + tentinh.SelectedValue.ToString() + "'" + " order by maqu").Tables[0];
		}

		private void load_pxa()
		{
            tenpxa.DataSource = m.get_data("select * from " + user + ".btdpxa where maqu='" + tenquan.SelectedValue.ToString() + "'" + " order by maphuongxa").Tables[0];
		}
		private bool load_tim_mabn()
		{
			string s_mann=mann.Text;
			load_btdnn(1);
			tennn.SelectedValue=s_mann;
			string s_mabn=mabn1.Text+mabn2.Text;
			DataTable dt=m.get_Timmabn(hoten.Text.Trim().ToUpper(),ngaysinh.Text,namsinh.Text,s_mabn).Tables[0];
			if (dt.Rows.Count>0)
			{
				frmTimMabn f=new frmTimMabn(dt);
				f.ShowDialog();
				if (f.m_mabn!="")
				{
					mabn1.Text=f.m_mabn.Substring(0,2);
					mabn2.Text=f.m_mabn.Substring(2,6);
					s_mabn=mabn1.Text+mabn2.Text;
					load_mabn(s_mabn);
					ghichu.Focus();
					return true;
				}
			}
			return false;
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
			TextCol1.MappingName = "ngay";
			TextCol1.HeaderText = "Ngày đặt";
			TextCol1.Width = 100;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid2.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 1);
			TextCol1.MappingName = "mabn";
			TextCol1.HeaderText = "Mã BN";
			TextCol1.Width = 60;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid2.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 2);
			TextCol1.MappingName = "hoten";
			TextCol1.HeaderText = "Họ và tên";
			TextCol1.Width =180;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid2.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 3);
			TextCol1.MappingName = "namsinh";
			TextCol1.HeaderText = "Năm sinh";
			TextCol1.Width =80;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid2.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 4);
			TextCol1.MappingName = "diachi";
			TextCol1.HeaderText = "Địa chỉ";
			TextCol1.Width = 0;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid2.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 5);
			TextCol1.MappingName = "ma";
			TextCol1.HeaderText = "Giường";
			TextCol1.Width = 70;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid2.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 6);
			TextCol1.MappingName = "ghichu";
			TextCol1.HeaderText = "Ghi chú";
			TextCol1.Width = 200;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid2.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 7);
			TextCol1.MappingName = "den";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid2.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 8);
			TextCol1.MappingName = "tinhtrang";
			TextCol1.HeaderText = "Tình trạng";
			TextCol1.Width = 136+(iwChange*2);
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid2.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 9);
            TextCol1.MappingName = "idtheodoigiuong";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            TextCol1.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid2.TableStyles.Add(ts);
		}
		private void AddGridTableStyle1()
		{
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
			ts.MappingName = dtct.TableName;
			ts.AllowSorting=false;
			
			DataGridTextBoxColumn TextCol1=new DataGridTextBoxColumn();
			TextCol1.MappingName = "id";
			TextCol1.HeaderText = "ID";
			TextCol1.Width = 0;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridTextBoxColumn();
			TextCol1.MappingName = "ma";
			TextCol1.HeaderText = "Mã";
			TextCol1.Width = 60;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridTextBoxColumn();
			TextCol1.MappingName = "ten";
			TextCol1.HeaderText = "Phòng/giường";
			TextCol1.Width = 190;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridTextBoxColumn();
			TextCol1.MappingName = "dongia";
			TextCol1.HeaderText = "Đơn giá";
			TextCol1.Width =80+iwChange;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);
		}
		public Color MyGetColorRowCol(int row, int col)
		{
			return (this.dataGrid2[row,7].ToString().Trim()!="")?Color.Red:Color.Black;
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
			s_ngay=m.ngayhienhanh_server;
			sql="select distinct a.mabn,c.hoten,c.namsinh,c.ngaysinh,c.phai,c.cholam,nvl(a.ghichu,' ') ghichu,trim(c.sonha)||' '||trim(c.thon) as diachi,c.matt,c.maqu,c.maphuongxa,c.madantoc,c.mann,";
			sql+="to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,to_char(a.den,'dd/mm/yyyy hh24:mi') as den,nvl(d.ghichu,' ') tinhtrang, a.idtheodoigiuong ";
            sql += " from " + user + ".datgiuong a," + user + ".btdbn c," + user + ".dmgiuong d where a.mabn=c.mabn and a.idgiuong=d.id";			 
			sql+=" and a.den is null and to_char(a.ngay,'dd/mm/yyyy')='"+s_ngay.Substring(0,10)+"'";//and a.userid="+i_userid;
			ds=m.get_data(sql);
			dataGrid2.DataSource=ds.Tables[0];
			if(bSkip)
			{
				AddGridTableStyle();
				bSkip=false;
			}
		}
		private void load_grid2(string mabn)
		{
			sql="select a.idgiuong id,b1.id idphong,b.ma,b1.ma phong,b1.ten||' - '||b.ten ten,";
            sql += "b.gia_th as dongia,b1.makp from " + user + ".datgiuong a," + user + ".dmgiuong b," + user + ".dmphong b1";//b.soluong,			
			sql+=" where a.idgiuong=b.id and b.idphong=b1.id and a.den is null";
			sql+=" and a.mabn='"+mabn+"'";// and a.userid="+i_userid;
			dtct=m.get_data(sql).Tables[0];
			dtxoa=dtct.Clone();
			dataGrid1.DataSource=dtct;
			if(bSkip1)
			{
				AddGridTableStyle1();
				bSkip1=false;
			}
		}
		private void load_hiendien(string mabn)
		{
			sql="select a.mabn,a.maql,case when b.maql is not null and b.nhapkhoa=1 and b.xuatkhoa=0 then b.makp||'_1' else ";
			sql+=" case when b.maql is not null and b.nhapkhoa=0 and b.xuatkhoa=0 then b.makp||'_0' else a.makp||'_2' end end makp, b.makp makphd, b.id, a.mavaovien, b.nhapkhoa, b.xuatkhoa ";
            sql += " from " + user + ".benhandt a,(select * from " + user + ".hiendien order by id desc) b, " + user + ".xuatvien c ";
			sql+=" where a.maql=c.maql(+) and c.maql is null and a.maql=b.maql(+) and a.loaiba=1 ";
			if(mabn!="") sql+=" and a.mabn='"+mabn+"'";
            if (bTinhGiuong_lucdatgiuong) sql += " and  b.nhapkhoa=1 and b.xuatkhoa=0 ";
			sql+=" order by a.maql desc";
			dthd=m.get_data(sql).Tables[0];
		}
		private void ref_text()
		{
			try
			{
				string s_mabn=dataGrid2[dataGrid2.CurrentCell.RowNumber,1].ToString();
				string tt=dataGrid2[dataGrid2.CurrentCell.RowNumber,8].ToString();
                m_id = (dataGrid2[dataGrid2.CurrentCell.RowNumber, 9].ToString() == "") ? 0 : long.Parse(dataGrid2[dataGrid2.CurrentCell.RowNumber, 9].ToString());
				if(tt!=" ") cboTinhtrang.SelectedValue=tt;
				else cboTinhtrang.SelectedIndex=0;
				mabn1.Text=s_mabn.Substring(0,2);
				mabn2.Text=s_mabn.Substring(2);
				load_grid2(s_mabn);
				load_thongtinhc(ds.Tables[0],s_mabn);
				ena_button(true);
				bNew=false;bEdit=false;
			}
			catch{}
		}
		private void load_head()
		{
			try
			{
				string s_mabn=mabn1.Text+mabn2.Text;
				load_grid2(s_mabn);
				load_thongtinhc(ds.Tables[0],s_mabn);
				ena_button(true);
				bNew=false;bEdit=false;
			}
			catch{}
		}
		private bool load_thongtinhc(DataTable dt,string s_mabn)
		{
			try
			{
				DataRow r1=m.getrowbyid(dt,"mabn='"+s_mabn+"'");
				if (r1!=null)
				{
					hoten.Text=r1["hoten"].ToString();
					namsinh.Text=r1["namsinh"].ToString();
					diachi.Text=r1["diachi"].ToString();
					if (r1["ngaysinh"].ToString()!="")
					{
						ngaysinh.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r1["ngaysinh"].ToString()));
						string tuoivao=m.Tuoivao("",ngaysinh.Text);
						tuoi.Text=tuoivao.Substring(2).PadLeft(3,'0');
						loaituoi.SelectedIndex=int.Parse(tuoivao.Substring(0,1));
					}
					else
					{
						tuoi.Text=Convert.ToString(DateTime.Now.Year-int.Parse(namsinh.Text)).PadLeft(3,'0');
						loaituoi.SelectedIndex=0;
					}
					phai.SelectedIndex=int.Parse(r1["phai"].ToString());
					mann.Text=r1["mann"].ToString();
					tennn.SelectedValue=mann.Text;
					madantoc.Text=r1["madantoc"].ToString();
					tendantoc.SelectedValue=madantoc.Text;
					if (madantoc.Text=="55") ena_nuoc(true);			
					else
					{
						ena_nuoc(false);
						manuoc.Text="VN";
						tennuoc.SelectedValue="VN";
					}
                    if (manuoc.Enabled) tennuoc.SelectedValue = m.get_data("select id_nuoc from " + user + ".nuocngoai where mabn='" + s_mabn + "'").Tables[0].Rows[0][0].ToString();
					matt.Text=r1["matt"].ToString();
					tentinh.SelectedValue=matt.Text;
					maqu1.Text=r1["maqu"].ToString().Substring(0,3);
					maqu2.Text=r1["maqu"].ToString().Substring(3,2);
					tenquan.SelectedValue=r1["maqu"].ToString();
					mapxa1.Text=r1["maphuongxa"].ToString().Substring(0,5);
					mapxa2.Text=r1["maphuongxa"].ToString().Substring(5,2);
					tenpxa.SelectedValue=r1["maphuongxa"].ToString();
					cholam.Text=r1["cholam"].ToString();
					ghichu.Text=r1["ghichu"].ToString();
					s_ngay=r1["ngay"].ToString();
					load_hiendien(s_mabn);
					DataRow r2=m.getrowbyid(dthd,"mabn='"+s_mabn+"'");
					lThongtinBN.Text="";s_makp="";
					if(r2!=null)
					{
						s_makp=r2["makp"].ToString();
						DataRow r3=m.getrowbyid(dtkp,"makp='"+r2["makp"].ToString().Substring(0,r2["makp"].ToString().Length-2)+"'");
						if(r3!=null)
						{
							if(r2["makp"].ToString().IndexOf("_0")!=-1) 
								lThongtinBN.Text="Bệnh nhân đã nhập viện và được chỉ định vào khoa :\n"+r3["tenkp"].ToString().ToUpper();
							else if(r2["makp"].ToString().IndexOf("_1")!=-1) lThongtinBN.Text="Bệnh nhân đang điều trị tại khoa :\n"+r3["tenkp"].ToString().ToUpper();
							else if(r2["makp"].ToString().IndexOf("_2")!=-1) lThongtinBN.Text="Bệnh nhân chưa đựơc chỉ định vào khoa :\n"+r3["tenkp"].ToString().ToUpper();
						}
					}
					load_grid2(s_mabn);
					if(dtct.Rows.Count>0)
					{
						ena_button(true);
						bNew=false;bEdit=false;
					}
				}
				else
				{
					lThongtinBN.Text="";
					if(!bTiepdon)
					{
						MessageBox.Show("Bệnh nhân chưa nhập viện!\nPhải nhập viện mới được phép đặt giường!");
						empty_text();
						mabn1.Focus();
						return false;
					}
					else return false;
				}
			}
			catch{return false;}
			return true;
		}
		private bool load_mabn(string s_mabn)
		{
			bool ret=false;
            foreach (DataRow r in m.get_data("select * from " + user + ".btdbn where mabn='" + s_mabn + "'").Tables[0].Rows)
			{
				hoten.Text=r["hoten"].ToString();
				namsinh.Text=r["namsinh"].ToString();
				if (r["ngaysinh"].ToString()!="")
				{
					ngaysinh.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngaysinh"].ToString()));
					string tuoivao=m.Tuoivao("",ngaysinh.Text);
					tuoi.Text=tuoivao.Substring(2).PadLeft(3,'0');
					loaituoi.SelectedIndex=int.Parse(tuoivao.Substring(0,1));
				}
				else
				{
					tuoi.Text=Convert.ToString(DateTime.Now.Year-int.Parse(namsinh.Text)).PadLeft(3,'0');
					loaituoi.SelectedIndex=0;
				}
				phai.SelectedIndex=int.Parse(r["phai"].ToString());
				tennn.SelectedValue=r["mann"].ToString();
				tendantoc.SelectedValue=r["madantoc"].ToString();
				diachi.Text=(r["sonha"].ToString()+" "+r["thon"].ToString()).Trim();
				cholam.Text=r["cholam"].ToString();
				tentinh.SelectedValue=r["matt"].ToString();
				load_quan();
				tenquan.SelectedValue=r["maqu"].ToString();
				load_pxa();
				tenpxa.SelectedValue=r["maphuongxa"].ToString();
				ret=true;
                foreach (DataRow r1 in m.get_data("select * from " + user + ".dienthoai where mabn='" + s_mabn + "'").Tables[0].Rows)
				{
					dienthoainha.Text=r1["nha"].ToString();
					coquan.Text=r1["coquan"].ToString();
					didong.Text=r1["didong"].ToString();
				}
				break;
			}
            if (ret && manuoc.Enabled) tennuoc.SelectedValue = m.get_data("select id_nuoc from " + user + ".nuocngoai where mabn='" + s_mabn + "'").Tables[0].Rows[0][0].ToString();
			return ret;
		}
		private void ena_nuoc(bool ena)
		{
			manuoc.Enabled=ena;
			tennuoc.Enabled=ena;
		}
		private void dataGrid2_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void ena_object(bool ena)
		{
			hoten.Enabled=ena;
			phai.Enabled=ena;
			ngaysinh.Enabled=ena;
			namsinh.Enabled=ena;
			tuoi.Enabled=ena;
			loaituoi.Enabled=ena;
			mann.Enabled=ena;
			tennn.Enabled=ena;
			madantoc.Enabled=ena;
			tendantoc.Enabled=ena;
			tentinh.Enabled=ena;
			tenquan.Enabled=ena;
			tenpxa.Enabled=ena;
			diachi.Enabled=ena;
			cholam.Enabled=ena;
			ghichu.Enabled=ena;
			dienthoainha.Enabled=ena;
			coquan.Enabled=ena;
			didong.Enabled=ena;
		}
		private void empty_text()
		{
			mabn1.Text="";
			mabn2.Text="";
			hoten.Text="";
			namsinh.Text="";
			ngaysinh.Text="";
			tuoi.Text="";
			diachi.Text="";
			cholam.Text="";
			ghichu.Text="";
			dienthoainha.Text="";
			coquan.Text="";
			didong.Text="";
			lThongtinBN.Text="";
			tentinh.SelectedValue=m.Mabv.Substring(0,3);
			tendantoc.SelectedValue="25";
			tennuoc.SelectedValue="VN";
			load_quan();
			load_pxa();
		}
		private void ena_button(bool ena)
		{
			mabn1.Enabled=!ena;
			mabn2.Enabled=!ena;
			ghichu.Enabled=!ena;
			cboTinhtrang.Enabled=!ena;
			butMoi.Enabled=ena;
			butLuu.Enabled=!ena;
			butBoqua.Enabled=!ena;
			butSua.Enabled=ena;
			butXoa.Enabled=ena;
			butKetthuc.Enabled=ena;
			butIn.Enabled=ena;
		}
		private void butMoi_Click(object sender, System.EventArgs e)
		{
			dtct.Clear();dtxoa.Clear();
            bTinhGiuong_lucdatgiuong = m.bTinhtiengiuong_lucdatgiuong;
			lThongtinBN.Text="";
			bNew=true;bEdit=false;
			ena_button(false);
			empty_text();
            m_id = 0;
			s_ngay=m.ngayhienhanh_server;
			mabn1.Text=System.DateTime.Now.Year.ToString().Substring(2);
			mabn1.Focus();
		}
		
		private bool kiemtra_luu()
		{
			if(mabn1.Text=="" || mabn2.Text=="" || hoten.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập họ tên người bệnh !"),LibMedi.AccessData.Msg);
				if (mabn1.Text=="" || mabn2.Text=="") mabn1.Focus();
				else if (hoten.Text=="") hoten.Focus();
				return false;
			}
			if(mabn1.Text.Length+mabn2.Text.Length!=8)
			{
				MessageBox.Show("Mã bệnh nhân không hợp lệ (phải đủ 8 kí tự)!",LibMedi.AccessData.Msg);
				mabn1.Focus();
				return false;
			}
			if(namsinh.Text.Trim()=="")
			{
				MessageBox.Show("Nhập năm sinh của Bệnh nhân !",LibMedi.AccessData.Msg);
				namsinh.Focus();
				return false;
			}
			if (dtct.Rows.Count<=0)
			{
				MessageBox.Show("Chọn phòng giường !",LibMedi.AccessData.Msg);
				return false;
			}
            if (m.Mabv == "101.4.18" || m.Mabv == "711.7.10") //if (m.Mabv.Trim() == "101.4.18")
			{
				if(cboTinhtrang.SelectedIndex==0 || cboTinhtrang.SelectedIndex==-1)
				{
					MessageBox.Show("Chọn tình trạng bệnh nhân !",LibMedi.AccessData.Msg);
					cboTinhtrang.Focus();
					return false;
				}
			}
			return true;
		}
		private bool kiemtra_chongiuong()
		{
			if(bNew||bEdit)
			{
				if(mabn1.Text=="" || mabn2.Text=="" || hoten.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập họ tên người bệnh !"),LibMedi.AccessData.Msg);
					if (mabn1.Text=="" || mabn2.Text=="") mabn1.Focus();
					else if (hoten.Text=="") hoten.Focus();
					return false;
				}
				if(s_makp!="")
				{
					if(s_makp.IndexOf("_2")!=-1)
					{
						MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân chưa được chỉ định vào khoa!"),LibMedi.AccessData.Msg);
						return false;
					}
				}
				if(dtct.Rows.Count<=0)
				{
                    sql = "select a.mabn,trim(c.ten||' - '||b.ten) ten from " + user + ".datgiuong a," + user + ".dmgiuong b," + user + ".dmphong c where a.idgiuong=b.id and b.idphong=c.id and a.mabn='" + mabn1.Text + mabn2.Text + "' and a.den is null";
					DataTable dttmp=m.get_data(sql).Tables[0];
					if(dttmp.Rows.Count>0)
					{
						MessageBox.Show("Bệnh nhân đã đặt giường : "+dttmp.Rows[0]["ten"].ToString()+"\nKhông thể đặt thêm giường khác!");
						return false;
					}
				}
                sql = "select a.mabn,trim(c.ten||' - '||b.ten) ten from " + user + ".datgiuong a," + user + ".dmgiuong b," + user + ".dmphong c where a.idgiuong=b.id and b.idphong=c.id and a.mabn='" + mabn1.Text + mabn2.Text + "' and to_char(a.ngay,'dd/mm/yyyy')='" + m.ngayhienhanh_server.Substring(0, 10) + "' and a.den is not null";
				DataTable ldt=m.get_data(sql).Tables[0];
				if(ldt.Rows.Count>0)
				{
					DialogResult dl=MessageBox.Show("Ngày hôm nay bệnh nhân đã đặt giường : "+ldt.Rows[0]["ten"].ToString()+"\nBạn có muốn đặt thêm giường khác không?","Thông báo",MessageBoxButtons.YesNo);
					if(dl==DialogResult.No)
					{
						butBoqua_Click(null,null);
						return false;
					}
				}
			}
			return true;
		}
		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra_luu()) return;
			string s_mabn=mabn1.Text.PadLeft(2,'0')+mabn2.Text.PadLeft(6,'0');
			if(s_ngay.Trim()=="") s_ngay=m.ngayhienhanh_server;
			if(!kiemtra_btdbn(s_mabn))
			{
				string nam = m.mmyy(s_ngay) + "+";
				m.upd_btdbn(s_mabn,hoten.Text.Trim(),ngaysinh.Text.Trim(),namsinh.Text,phai.SelectedIndex,mann.Text,madantoc.Text,"",diachi.Text,cholam.Text,matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,i_userid,nam);
				if(dienthoainha.Text!="" || coquan.Text!="" || didong.Text!="")
					m.upd_dienthoai(s_mabn,dienthoainha.Text,coquan.Text,didong.Text,"");
			}
			if (bEdit&&dtxoa.Rows.Count>0)
			{
				foreach(DataRow r in dtct.Rows)
				{
                    m.execute_data("update " + user + ".dmgiuong set tinhtrang=0,soluong=soluong-1,ghichu='' where tinhtrang=1 and id=" + int.Parse(r["id"].ToString()));
                    m.execute_data("delete from " + user + ".datgiuong where mabn='" + s_mabn + "' and idgiuong=" + int.Parse(r["id"].ToString())); 
					m.upd_eve_tables(itable,i_userid,"upd");
					m.upd_eve_upd_del(itable,i_userid,"upd",s_mabn+"-"+int.Parse(r["id"].ToString()));
				}
				upd_data(dtxoa,s_mabn);
			}
			else
			{
				upd_data(dtct,s_mabn);
			}
			load_grid();
			load_head();
			ena_object(false);
		}
		private void upd_data(DataTable adt,string s_mabn)
		{
			string file="",tt="ins",s_stt="";
			int idex1,idex2;
			if(bEdit) tt="upd";
			foreach(DataRow r in adt.Rows)
			{
				int idgiuong=int.Parse(r["id"].ToString());
				if(bNew||(bEdit&&dtxoa.Rows.Count>0)) file=",soluong=soluong+1";
				p.upd_dmgiuong(idgiuong,(cboTinhtrang.Visible)?cboTinhtrang.SelectedValue.ToString():ghichu.Text,1);
                if (file != "") m.execute_data("update " + user + ".dmgiuong set soluong=soluong+1 where id=" + idgiuong);
				p.upd_datgiuong(s_mabn,s_ngay,idgiuong,(cboTinhtrang.Visible)?cboTinhtrang.SelectedValue.ToString():ghichu.Text,i_userid);
				m.upd_eve_tables(itable,i_userid,tt);
				m.upd_eve_upd_del(itable,i_userid,tt,m.fields(user+".datgiuong","mabn='"+s_mabn+"' and to_char(ngay,'dd/mm/yyyy hh24:mi')='"+s_ngay+"'"));
				if(r["ma"].ToString().IndexOf("TG")!=-1)//Tron goi
				{
					idex1=r["ma"].ToString().IndexOf("TG")+2;
					idex2=r["ma"].ToString().IndexOf("/");
					s_stt=r["ma"].ToString().Substring(idex1,idex2-idex1)+","+r["ma"].ToString().Substring(idex2+1);
					DataTable dtmp=get_giuong_trongoi(int.Parse(r["idphong"].ToString()),s_stt);
					foreach(DataRow r1 in dtmp.Rows)
					{
						p.upd_dmgiuong(int.Parse(r1["id"].ToString()),(cboTinhtrang.Visible)?cboTinhtrang.SelectedValue.ToString():ghichu.Text,1);
                        if (file != "") m.execute_data("update " + user + ".dmgiuong set soluong=soluong+1 where id=" + int.Parse(r1["id"].ToString()));
					}
				}
                if (bTinhGiuong_lucdatgiuong)
                {
                    if (m_id == 0) m_id = m_v.get_id_vpkhoa;
                    DataRow rhd = m.getrowbyid(dthd, "mabn='" + s_mabn + "' and nhapkhoa=1");
                    if (rhd != null)
                    {
                        long l_idkhoa = long.Parse(rhd["id"].ToString());
                        long l_maql = long.Parse(rhd["maql"].ToString());
                        string m_makp = rhd["makphd"].ToString();
                        long m_mavaovien = long.Parse(rhd["mavaovien"].ToString());
                        decimal d_dongia = decimal.Parse(r["dongia"].ToString());
                        m.upd_theodoigiuong(m_id, m_makp, s_mabn, l_maql, l_idkhoa, m.iTunguyen, idgiuong, s_ngay, d_dongia, i_userid,m_mavaovien);
                        m.execute_data("update " + user + ".theodoigiuong set giuongthem=1 where id=" + m_id);
                        m.execute_data("update " + user + ".datgiuong set idtheodoigiuong=" + m_id + " where mabn='" + s_mabn + "' and idgiuong=" + idgiuong + " and den is null ");
                    }
                }
			}
		}
		private DataTable get_giuong_trongoi(int idphong,string s_stt)
		{
            sql = "select * from " + user + ".dmgiuong where idphong=" + idphong + " and stt in(" + s_stt + ")";
			DataTable dtmp=m.get_data(sql).Tables[0];
			return dtmp;
		}
		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			load_grid();
			bNew=false;bEdit=false;
			ena_button(true);
			ena_object(false);
			ref_text();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (dtct.Rows.Count==0) return;
			try
			{
				string s_mabn=mabn1.Text+mabn2.Text;
				if (kiemtra_huy(dtct.Rows[0]["id"].ToString(),s_mabn))
				{
					MessageBox.Show("Giường đã được sử dụng, không được hủy!",LibMedi.AccessData.Msg);
					return;
				}
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					foreach(DataRow r in dtct.Rows)
					{
                        m.execute_data("update " + user + ".dmgiuong set tinhtrang=0,soluong=soluong-1,ghichu='' where id=" + int.Parse(r["id"].ToString()));
                        m.execute_data("delete from " + user + ".datgiuong where mabn='" + s_mabn + "' and idgiuong=" + int.Parse(r["id"].ToString()));
						m.upd_eve_tables(itable,i_userid,"del");
//						m.upd_eve_upd_del(itable,i_userid,"del",m.fields(user+".datgiuong","mabn='"+s_mabn+"' and idgiuong="+int.Parse(r["id"].ToString())));
						m.upd_eve_upd_del(itable,i_userid,"del",s_mabn+"-"+r["id"].ToString());
						if(r["ma"].ToString().IndexOf("TG")!=-1)
						{
							int idex1=r["ma"].ToString().IndexOf("TG")+2;
							int idex2=r["ma"].ToString().IndexOf("/");
							string s_stt=r["ma"].ToString().Substring(idex1,idex2-idex1)+","+r["ma"].ToString().Substring(idex2+1);
							DataTable dtmp=get_giuong_trongoi(int.Parse(r["idphong"].ToString()),s_stt);
							foreach(DataRow r1 in dtmp.Rows)
							{
                                m.execute_data("update " + user + ".dmgiuong set tinhtrang=0,soluong=soluong-1,ghichu='' where id=" + int.Parse(r1["id"].ToString()));
							}
						}
					}
                    if (m_id > 0) m.execute_data("delete from " + user + ".theodoigiuong where id=" + m_id);
					m.delrec(dtct,"");
					load_grid();
				}
			}
			catch{}
		}
		private bool kiemtra_huy(string ma,string mabn)
		{
			try
			{
                sql = "select * from " + user + ".datgiuong where idgiuong='" + ma + "' and mabn='" + mabn + "' and den is not null";
				return m.get_data(sql).Tables[0].Rows.Count>0;
			}
			catch{return false;}
		}
		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void mabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void mabn_Validated(object sender, System.EventArgs e)
		{
			
            hoten.Text="";
			string s_mabn="";
			if (mabn1.Text=="") 
			{
				mabn1.Focus();
				return;
			}
			mabn1.Text=mabn1.Text.PadLeft(2,'0');
			if(mabn2.Text.Trim()!="")
			{
				mabn2.Text=mabn2.Text.PadLeft(6,'0');
				s_mabn=mabn1.Text+mabn2.Text;
				if(kiemtra_btdbn(s_mabn))
				{
					load_hiendien(s_mabn);
                    if (bTinhGiuong_lucdatgiuong && dthd.Rows.Count <= 0)
                    {
                        MessageBox.Show("Bệnh nhân này đã ra khỏi khoa.");
                        mabn2.Focus();
                    }
					sql="select a.mabn,c.hoten,c.namsinh,c.ngaysinh,c.phai,c.cholam,' ' ghichu,' ' ngay,";
					sql+="trim(c.sonha)||' '||trim(c.thon) as diachi,c.matt,c.maqu,c.maphuongxa,c.madantoc,c.mann";
                    sql += " from " + user + ".benhandt a," + user + ".xuatvien b," + user + ".btdbn c where a.maql=b.maql(+) and b.maql is null and a.mabn=c.mabn and a.loaiba=1 and a.mabn='" + s_mabn + "'";
					if(!load_thongtinhc(m.get_data(sql).Tables[0],s_mabn))
					{
						if(bTiepdon)
						{
							load_mabn(s_mabn);
							ghichu.Focus();
						}
					}
				}
				else
				{
					if(bTiepdon)
					{
						ena_object(true);
						hoten.Focus();
					}
					else
					{
						MessageBox.Show("Không tìm thấy thông tin hành chính bệnh nhân!",LibMedi.AccessData.Msg);
						mabn1.Focus();return;
					}
				}
			}
			else
			{
				if(bTiepdon)
				{
					ena_object(true);
					hoten.Focus();
				}
				else
				{
					mabn1.Focus();
				}
			}
		}
		private bool kiemtra_btdbn(string mabn)
		{
            return m.get_data("select mabn from " + user + ".btdbn where mabn='" + mabn + "'").Tables[0].Rows.Count > 0;
		}
		private void frmDatphong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F5:
					l_chongiuong_Click(sender,e);
					break;
			}
		}

		private void mabn1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				SendKeys.Send("{Tab}{F4}");
		}

		private void butMoi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				SendKeys.Send("{Tab}");
		}

		private void l_chongiuong_Click(object sender, System.EventArgs e)
		{
			if(!kiemtra_chongiuong()) return;
			DataSet dstmp=new DataSet();
			frmDsgiuong f=new frmDsgiuong(m,dtct,s_makp,0,bNew,bEdit);
			f.ShowDialog();
			if (f.ma!=""&&f.dsct.Tables[0].Rows.Count>0)
			{
				dstmp.Merge(f.dsct.Tables[0].Select("","dongia"));
				if(bEdit) 
				{
					upd_dtct(dstmp.Tables[0],dtxoa);
					dtxoa.AcceptChanges();
				}
				else 
				{
					dtct.Clear();
					upd_dtct(dstmp.Tables[0],dtct);
					dtct.AcceptChanges();
				}
				if(bNew||bEdit) 
				{
					if(cboTinhtrang.Visible)
					{
						cboTinhtrang.Focus();
						cboTinhtrang.DroppedDown=true;
					}
					else butLuu.Focus();
				}
			}
		}
		private void upd_dtct(DataTable dt,DataTable dt1)
		{
			foreach(DataRow r in dt.Rows)
				dt1.Rows.Add(r.ItemArray);
			dt1.AcceptChanges();
		}
		private void tentinh_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				matt.Text=tentinh.SelectedValue.ToString();
				load_quan();
			}
			catch{}
		}

		private void tenquan_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				maqu1.Text=tenquan.SelectedValue.ToString().Substring(0,3);
				maqu2.Text=tenquan.SelectedValue.ToString().Substring(3);
				load_pxa();
			}
			catch{}
		}

		private void tenpxa_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				mapxa1.Text=tenpxa.SelectedValue.ToString().Substring(0,5);
				mapxa2.Text=tenpxa.SelectedValue.ToString().Substring(5);
			}
			catch{}
		}

		private void tendantoc_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				madantoc.Text=tendantoc.SelectedValue.ToString();
				if (madantoc.Text=="55") ena_nuoc(true);			
				else
				{
					ena_nuoc(false);
					tennuoc.SelectedValue="VN";
				}
			}
			catch{madantoc.Text="";}
		}

		private void tennuoc_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				manuoc.Text=tennuoc.SelectedValue.ToString();
			}
			catch{}
		}

		private void tennn_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				mann.Text=tennn.SelectedValue.ToString();
			}
			catch{}
		}
		private void butSua_Click(object sender, System.EventArgs e)
		{
			if(ds.Tables[0].Rows.Count==0) return;
			if (kiemtra_huy(magiuong.Text,mabn1.Text+mabn2.Text))
			{
				MessageBox.Show("Đã chuyển phòng giường không được thay đổi !",LibMedi.AccessData.Msg);
				return;
			}
			bNew=false;bEdit=true;
			ena_button(false);		
		}

		private void lbRefresh_Click(object sender, System.EventArgs e)
		{
			load_grid();
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			if(dtct.Rows.Count==0) return;
			if(ds.Tables[0].Select("mabn='"+mabn1.Text+mabn2.Text+"'").Length==0) 
			{
				MessageBox.Show("Chưa cập nhật thông tin đặt giường!\nVui lòng xem lại danh sách đặt giường!");
				return;
			}
			dsin.Clear();
			try
			{
				DataRow r=dsin.Tables[0].NewRow();
				r["mabn"]=mabn1.Text+mabn2.Text;
				r["hoten"]=hoten.Text;
				r["namsinh"]=namsinh.Text;
				r["diachi"]=(diachi.Text+" - "+tenpxa.Text+" - "+tenquan.Text+" - "+tentinh.Text).Trim().Trim('-');
				r["ngaygio"]=s_ngay;
				r["khoaphong"]=dtkp.Select("makp='"+dtct.Rows[0]["makp"].ToString()+"'")[0]["tenkp"].ToString();
				r["giuong"]=dtct.Rows[0]["ten"].ToString();
				r["dongia"]=dtct.Rows[0]["dongia"].ToString();
				dsin.Tables[0].Rows.Add(r);
			}
			catch{}
//			dsin.WriteXml(@"..\phieudatgiuong.xml",XmlWriteMode.WriteSchema);
			frmReport f=new frmReport(m,dsin,"","rPhieudatgiuong.rpt");
			f.ShowDialog();
		}
		private void frmDatphong_SizeChanged(object sender, System.EventArgs e)
		{
            iwChange = (this.Width - 800) / 2;
            int ihChange = (this.Height - 592) / 2 + 10;
            pThongtin.Width = 416 + iwChange;
            pDatgiuong.Width = 376 + iwChange;
            pDatgiuong.Location = new Point(416 + iwChange, -2);
            pGrid.Height = 232 + ihChange;
            pBut.Location = new Point(2 + iwChange, 1);
            ghichu.Height = 26 + gHanhchinh.Height - 282;
            if (iwChange != 0)
            {
                load_grid();
                load_grid2(mabn1.Text + mabn2.Text);
            }
		}

		private void ngaysinh_Validated(object sender, System.EventArgs e)
		{
			if (ngaysinh.Text=="") return;
			ngaysinh.Text=ngaysinh.Text.Trim();
			if (!m.bNgay(ngaysinh.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày sinh không hợp lệ !"));
				ngaysinh.Focus();
				return;
			}
			ngaysinh.Text=m.Ktngaygio(ngaysinh.Text,10);
			if (!m.bNgay("",ngaysinh.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày sinh không hợp lệ !"));
				ngaysinh.Focus();
				return;
			}
			try
			{
				string tuoivao=m.Tuoivao("",ngaysinh.Text);
				tuoi.Text=tuoivao.Substring(2).PadLeft(3,'0');
				loaituoi.SelectedIndex=int.Parse(tuoivao.Substring(0,1));
				namsinh.Text=m.Namsinh(ngaysinh.Text).ToString();
				if (int.Parse(tuoi.Text)>m.iTuoi_nguoibenh && loaituoi.SelectedIndex==0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày sinh không hợp lệ !"),LibMedi.AccessData.Msg);
					ngaysinh.Focus();
					return;
				}
				if (tuoi.Text=="000")
				{
					MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập tuổi vào !"),LibMedi.AccessData.Msg);
					tuoi.Focus();
					return;
				}
				if (!load_tim_mabn())
				{
					if(mabn2.Text.Trim()=="") mabn2.Focus();
					else if (phai.Enabled)
					{
						phai.Focus();
						SendKeys.Send("{F4}");
					}
					else mann.Focus();
				}
			}
			catch{}
		}

		private void ghichu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				if(ghichu.Text=="\r\n")
				{
					if(cboTinhtrang.Visible)
					{
						cboTinhtrang.Focus();
						cboTinhtrang.DroppedDown=true;
					}
				}
			}
		}

		private void namsinh_Validated(object sender, System.EventArgs e)
		{
			if(namsinh.Text!="")
			{
				if (int.Parse(namsinh.Text)>DateTime.Now.Year)
				{
					MessageBox.Show(lan.Change_language_MessageText("Năm sinh không hợp lệ !"),LibMedi.AccessData.Msg);
					namsinh.Focus();
					return;
				}
				if (namsinh.Text.Length<4) namsinh.Text=Convert.ToString(DateTime.Now.Year-int.Parse(namsinh.Text));
				tuoi.Text=Convert.ToString(DateTime.Now.Year-int.Parse(namsinh.Text)).PadLeft(3,'0');
				loaituoi.SelectedIndex=0;
				if (int.Parse(tuoi.Text)>m.iTuoi_nguoibenh)
				{
					MessageBox.Show(lan.Change_language_MessageText("Năm sinh không hợp lệ !"),LibMedi.AccessData.Msg);
					namsinh.Focus();
					return;
				}
				if (tuoi.Text=="000")
				{
					MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập tuổi vào !"),LibMedi.AccessData.Msg);
					tuoi.Focus();
					return;
				}
				if (!load_tim_mabn())
				{
					if(mabn2.Text.Trim()=="") mabn2.Focus();
					else if (phai.Enabled) SendKeys.Send("{Tab}{Tab}");
					else mann.Focus();
				}
			}
		}

		private void madantoc_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tendantoc.SelectedValue=madantoc.Text;
			}
			catch{}
		}

		private void cholam_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				SendKeys.Send("{Tab}");
			}
		}

		private void tuoi_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (int.Parse(tuoi.Text)==0) ngaysinh.Focus();
				else
				{
					if(namsinh.Text=="")
					{
						namsinh.Text=(DateTime.Now.Year-int.Parse(tuoi.Text)).ToString();
						if (!load_tim_mabn())
						{
							if(mabn2.Text.Trim()=="") mabn2.Focus();
							else if (phai.Enabled) SendKeys.Send("{Tab}{Tab}");
							else mann.Focus();
						}
					}
				}
				
			}
			catch{ngaysinh.Focus();}
		}
		private void tuoi_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			m.MaskDigit(e);
		}

		private void diachi_Validated(object sender, System.EventArgs e)
		{
			diachi.Text=m.Caps(diachi.Text);
		}

		private void cholam_Validated(object sender, System.EventArgs e)
		{
			cholam.Text=m.Caps(cholam.Text);
		}

		private void hoten_Validated(object sender, System.EventArgs e)
		{
			if(hoten.Text=="") mabn2.Focus();
		}

		private void label14_Click(object sender, System.EventArgs e)
		{
			Cursor=Cursors.WaitCursor;
            m.execute_data("update " + user + ".dmgiuong set tinhtrang=0, soluong=0 where tinhtrang=2 and soluong<=0 ");
			Cursor=Cursors.Default;
			MessageBox.Show("Đã cập nhật xong.");

		}

        private void pChon_Paint(object sender, PaintEventArgs e)
        {

        }

	}
}
