using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Drawing.Printing;
using LibBC;

namespace DLLBCTonghop
{
	public class frmQuanlybenhvien : System.Windows.Forms.Form
	{
		private DateTime m_curdate=DateTime.Now;
		private LibBC.AccessData m_bc = new LibBC.AccessData();
		private DataSet m_ds = new DataSet();
		private bool m_admin=false;
		private string m_maql="";
		private string m_idkhoa="";
		private bool m_tinhgio=false;
		private string m_table = "";

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabBN;
		private System.Windows.Forms.TabPage tabSQL;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Button butSQL_Next;
		private System.Windows.Forms.DateTimePicker txtTN;
		private System.Windows.Forms.DateTimePicker txtDN;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Splitter splitter3;
		private System.Windows.Forms.Button butSQL_Pre;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button butSQL_New;
		private System.Windows.Forms.Button butSQL_ClearHistory;
		private System.Windows.Forms.Button butSQL_Refresh;
		private System.Windows.Forms.Splitter splitter5;
		private System.Windows.Forms.DataGrid dgQLBN;
		private System.Windows.Forms.TreeView treeQLBN;
		private System.Windows.Forms.DataGrid dgSQL;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button butExcel;
		private System.Windows.Forms.ComboBox cbHis;
		private System.Windows.Forms.Button butRefresh;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.Panel pAdd_Menu;
		private System.Windows.Forms.TextBox txtAdd_Ten;
		private System.Windows.Forms.Button butAdd_Luu;
		private System.Windows.Forms.Button butAdd_Boqua;
		private System.Windows.Forms.TextBox txtAdd_SQL;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button butAdd_Xoa;
		private System.Windows.Forms.Label lbAdd_Title;
		private System.Windows.Forms.CheckBox chkReadonly;
		private System.Windows.Forms.Button butAdd_Moi;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtAdd_Field;
		private System.Windows.Forms.TextBox txtAdd_Tenfield;
		private System.Windows.Forms.TextBox txtAdd_Width;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtAdd_Report;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox txtAdd_Stt;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.Button butXML;
		private System.Windows.Forms.Panel pNull;
		private System.Windows.Forms.Button butNull_Dong;
		private System.Windows.Forms.Button butNull_Luu;
		private System.Windows.Forms.DataGrid dgNull;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.TextBox txtTimkiem;
		private System.Windows.Forms.ComboBox cbBaocao;
		private System.Windows.Forms.NumericUpDown txtThang;
		private System.Windows.Forms.NumericUpDown txtNam;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label lbThang;
		private System.Windows.Forms.Label lbNam;
		private System.Windows.Forms.Label lbDN;
		private System.Windows.Forms.Label lbTN;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.TextBox txtSQL;
		private System.Windows.Forms.TextBox txtNguoiin;
		private System.Windows.Forms.DateTimePicker txtNgayin;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbKhoa;
		private System.Windows.Forms.ContextMenu contextMenu2;
		private System.Windows.Forms.MenuItem menuItem17;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label lbZoom;
		private System.ComponentModel.IContainer components;

		public frmQuanlybenhvien(string v_table)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m_table = v_table;
			toolTip1.SetToolTip(lbTitle,"medibv."+ v_table);
			m_curdate=m_bc.s_server_date;
			f_SetEvent(this);
			f_Load_Cookie();

			for(int i=0;i<contextMenu1.MenuItems.Count;i++)
			{
				contextMenu1.MenuItems[i].Enabled=m_admin;
			}
            treeQLBN.Tag = "";

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanlybenhvien));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cbBaocao = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtNam = new System.Windows.Forms.NumericUpDown();
            this.txtThang = new System.Windows.Forms.NumericUpDown();
            this.lbNam = new System.Windows.Forms.Label();
            this.lbThang = new System.Windows.Forms.Label();
            this.txtDN = new System.Windows.Forms.DateTimePicker();
            this.lbDN = new System.Windows.Forms.Label();
            this.txtTN = new System.Windows.Forms.DateTimePicker();
            this.lbTN = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabBN = new System.Windows.Forms.TabPage();
            this.dgQLBN = new System.Windows.Forms.DataGrid();
            this.splitter5 = new System.Windows.Forms.Splitter();
            this.treeQLBN = new System.Windows.Forms.TreeView();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem16 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.tabSQL = new System.Windows.Forms.TabPage();
            this.dgSQL = new System.Windows.Forms.DataGrid();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbHis = new System.Windows.Forms.ComboBox();
            this.butSQL_New = new System.Windows.Forms.Button();
            this.butSQL_Refresh = new System.Windows.Forms.Button();
            this.butSQL_Pre = new System.Windows.Forms.Button();
            this.butSQL_Next = new System.Windows.Forms.Button();
            this.butSQL_ClearHistory = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.txtSQL = new System.Windows.Forms.TextBox();
            this.contextMenu2 = new System.Windows.Forms.ContextMenu();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.label17 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtNgayin = new System.Windows.Forms.DateTimePicker();
            this.txtNguoiin = new System.Windows.Forms.TextBox();
            this.txtTimkiem = new System.Windows.Forms.TextBox();
            this.butIn = new System.Windows.Forms.Button();
            this.butXML = new System.Windows.Forms.Button();
            this.butExcel = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butRefresh = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pAdd_Menu = new System.Windows.Forms.Panel();
            this.lbZoom = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pNull = new System.Windows.Forms.Panel();
            this.butNull_Dong = new System.Windows.Forms.Button();
            this.butNull_Luu = new System.Windows.Forms.Button();
            this.dgNull = new System.Windows.Forms.DataGrid();
            this.txtAdd_Stt = new System.Windows.Forms.TextBox();
            this.txtAdd_Report = new System.Windows.Forms.TextBox();
            this.txtAdd_Width = new System.Windows.Forms.TextBox();
            this.txtAdd_SQL = new System.Windows.Forms.TextBox();
            this.txtAdd_Tenfield = new System.Windows.Forms.TextBox();
            this.txtAdd_Field = new System.Windows.Forms.TextBox();
            this.txtAdd_Ten = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.butAdd_Moi = new System.Windows.Forms.Button();
            this.lbAdd_Title = new System.Windows.Forms.Label();
            this.butAdd_Xoa = new System.Windows.Forms.Button();
            this.butAdd_Boqua = new System.Windows.Forms.Button();
            this.butAdd_Luu = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkReadonly = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cbKhoa = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThang)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabBN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgQLBN)).BeginInit();
            this.tabSQL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSQL)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pAdd_Menu.SuspendLayout();
            this.pNull.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgNull)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.ForestGreen;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(786, 50);
            this.panel1.TabIndex = 16;
            // 
            // lbTitle
            // 
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbTitle.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(57, 1);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(344, 46);
            this.lbTitle.TabIndex = 15;
            this.lbTitle.Text = " THỐNG KÊ BÁO CÁO TỔNG HỢP";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 63;
            this.pictureBox1.TabStop = false;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.cbBaocao);
            this.panel7.Controls.Add(this.label14);
            this.panel7.Controls.Add(this.txtNam);
            this.panel7.Controls.Add(this.txtThang);
            this.panel7.Controls.Add(this.lbNam);
            this.panel7.Controls.Add(this.lbThang);
            this.panel7.Controls.Add(this.txtDN);
            this.panel7.Controls.Add(this.lbDN);
            this.panel7.Controls.Add(this.txtTN);
            this.panel7.Controls.Add(this.lbTN);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(207, 1);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(0, 1, 1, 0);
            this.panel7.Size = new System.Drawing.Size(576, 46);
            this.panel7.TabIndex = 75;
            // 
            // cbBaocao
            // 
            this.cbBaocao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBaocao.Location = new System.Drawing.Point(256, 2);
            this.cbBaocao.Name = "cbBaocao";
            this.cbBaocao.Size = new System.Drawing.Size(133, 21);
            this.cbBaocao.TabIndex = 0;
            this.cbBaocao.SelectedIndexChanged += new System.EventHandler(this.cbBaocao_SelectedIndexChanged);
            this.cbBaocao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbBaocao_KeyDown);
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(200, 2);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 21);
            this.label14.TabIndex = 75;
            this.label14.Text = "Báo cáo:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(333, 24);
            this.txtNam.Maximum = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.txtNam.Minimum = new decimal(new int[] {
            1997,
            0,
            0,
            0});
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(56, 20);
            this.txtNam.TabIndex = 2;
            this.txtNam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNam.Value = new decimal(new int[] {
            1997,
            0,
            0,
            0});
            this.txtNam.ValueChanged += new System.EventHandler(this.txtThang_ValueChanged);
            this.txtNam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNam_KeyDown);
            // 
            // txtThang
            // 
            this.txtThang.Location = new System.Drawing.Point(256, 24);
            this.txtThang.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.txtThang.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtThang.Name = "txtThang";
            this.txtThang.Size = new System.Drawing.Size(48, 20);
            this.txtThang.TabIndex = 1;
            this.txtThang.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtThang.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtThang.ValueChanged += new System.EventHandler(this.txtThang_ValueChanged);
            this.txtThang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtThang_KeyDown);
            // 
            // lbNam
            // 
            this.lbNam.ForeColor = System.Drawing.Color.White;
            this.lbNam.Location = new System.Drawing.Point(281, 24);
            this.lbNam.Name = "lbNam";
            this.lbNam.Size = new System.Drawing.Size(56, 21);
            this.lbNam.TabIndex = 1;
            this.lbNam.Text = "Năm:";
            this.lbNam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbThang
            // 
            this.lbThang.ForeColor = System.Drawing.Color.White;
            this.lbThang.Location = new System.Drawing.Point(201, 24);
            this.lbThang.Name = "lbThang";
            this.lbThang.Size = new System.Drawing.Size(56, 21);
            this.lbThang.TabIndex = 76;
            this.lbThang.Text = "Tháng:";
            this.lbThang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDN
            // 
            this.txtDN.CustomFormat = "dd/MM/yyyy HH:mm";
            this.txtDN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDN.Location = new System.Drawing.Point(459, 24);
            this.txtDN.Name = "txtDN";
            this.txtDN.Size = new System.Drawing.Size(115, 20);
            this.txtDN.TabIndex = 4;
            this.txtDN.TabStop = false;
            this.txtDN.ValueChanged += new System.EventHandler(this.txtDN_ValueChanged);
            this.txtDN.Validating += new System.ComponentModel.CancelEventHandler(this.txtDN_Validating);
            this.txtDN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDN_KeyDown);
            // 
            // lbDN
            // 
            this.lbDN.ForeColor = System.Drawing.Color.White;
            this.lbDN.Location = new System.Drawing.Point(404, 22);
            this.lbDN.Name = "lbDN";
            this.lbDN.Size = new System.Drawing.Size(56, 24);
            this.lbDN.TabIndex = 71;
            this.lbDN.Text = "Đến ngày:";
            this.lbDN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTN
            // 
            this.txtTN.CustomFormat = "dd/MM/yyyy HH:mm";
            this.txtTN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtTN.Location = new System.Drawing.Point(459, 2);
            this.txtTN.Name = "txtTN";
            this.txtTN.Size = new System.Drawing.Size(115, 20);
            this.txtTN.TabIndex = 3;
            this.txtTN.TabStop = false;
            this.txtTN.ValueChanged += new System.EventHandler(this.txtTN_ValueChanged);
            this.txtTN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTN_KeyDown);
            // 
            // lbTN
            // 
            this.lbTN.ForeColor = System.Drawing.Color.White;
            this.lbTN.Location = new System.Drawing.Point(404, 2);
            this.lbTN.Name = "lbTN";
            this.lbTN.Size = new System.Drawing.Size(56, 21);
            this.lbTN.TabIndex = 71;
            this.lbTN.Text = "Từ ngày:";
            this.lbTN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Dock = System.Windows.Forms.DockStyle.Top;
            this.label15.Location = new System.Drawing.Point(3, 53);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(786, 3);
            this.label15.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Controls.Add(this.splitter3);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.Color.Blue;
            this.panel2.Location = new System.Drawing.Point(3, 56);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(2);
            this.panel2.Size = new System.Drawing.Size(786, 506);
            this.panel2.TabIndex = 19;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabBN);
            this.tabControl1.Controls.Add(this.tabSQL);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(780, 453);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // tabBN
            // 
            this.tabBN.Controls.Add(this.dgQLBN);
            this.tabBN.Controls.Add(this.splitter5);
            this.tabBN.Controls.Add(this.treeQLBN);
            this.tabBN.Location = new System.Drawing.Point(4, 22);
            this.tabBN.Name = "tabBN";
            this.tabBN.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tabBN.Size = new System.Drawing.Size(772, 427);
            this.tabBN.TabIndex = 0;
            this.tabBN.Text = "Quản lý bệnh viện     ";
            // 
            // dgQLBN
            // 
            this.dgQLBN.AlternatingBackColor = System.Drawing.SystemColors.Info;
            this.dgQLBN.BackColor = System.Drawing.Color.White;
            this.dgQLBN.BackgroundColor = System.Drawing.Color.White;
            this.dgQLBN.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dgQLBN.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dgQLBN.CaptionForeColor = System.Drawing.SystemColors.ControlText;
            this.dgQLBN.CaptionText = "Kết quả";
            this.dgQLBN.DataMember = "";
            this.dgQLBN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgQLBN.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgQLBN.Location = new System.Drawing.Point(195, 5);
            this.dgQLBN.Name = "dgQLBN";
            this.dgQLBN.RowHeaderWidth = 20;
            this.dgQLBN.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.dgQLBN.SelectionForeColor = System.Drawing.Color.White;
            this.dgQLBN.Size = new System.Drawing.Size(577, 422);
            this.dgQLBN.TabIndex = 156;
            this.dgQLBN.TabStop = false;
            // 
            // splitter5
            // 
            this.splitter5.Location = new System.Drawing.Point(192, 5);
            this.splitter5.Name = "splitter5";
            this.splitter5.Size = new System.Drawing.Size(3, 422);
            this.splitter5.TabIndex = 157;
            this.splitter5.TabStop = false;
            // 
            // treeQLBN
            // 
            this.treeQLBN.ContextMenu = this.contextMenu1;
            this.treeQLBN.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeQLBN.Location = new System.Drawing.Point(0, 5);
            this.treeQLBN.Name = "treeQLBN";
            this.treeQLBN.Size = new System.Drawing.Size(192, 422);
            this.treeQLBN.TabIndex = 0;
            this.treeQLBN.DoubleClick += new System.EventHandler(this.treeQLBN_DoubleClick);
            this.treeQLBN.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeQLBN_AfterSelect);
            this.treeQLBN.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeQLBN_BeforeSelect);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem4,
            this.menuItem16,
            this.menuItem2,
            this.menuItem3,
            this.menuItem11,
            this.menuItem12,
            this.menuItem13,
            this.menuItem10,
            this.menuItem9,
            this.menuItem8,
            this.menuItem6,
            this.menuItem15,
            this.menuItem5,
            this.menuItem7,
            this.menuItem14});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "Thêm mục mới cùng cấp";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 1;
            this.menuItem4.Text = "Thêm mục con";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 2;
            this.menuItem16.Text = "Nhân đôi";
            this.menuItem16.Click += new System.EventHandler(this.menuItem16_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 3;
            this.menuItem2.Text = "Xoá";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 4;
            this.menuItem3.Text = "Sữa";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 5;
            this.menuItem11.Text = "-";
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 6;
            this.menuItem12.Text = "Di chuyển lên";
            this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 7;
            this.menuItem13.Text = "Di chuyển xuống";
            this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 8;
            this.menuItem10.Text = "-";
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 9;
            this.menuItem9.Text = "Import danh sách menu";
            this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 10;
            this.menuItem8.Text = "Export danh dách menu";
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 11;
            this.menuItem6.Text = "-";
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 12;
            this.menuItem15.Text = "Sữa danh sách null";
            this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 13;
            this.menuItem5.Text = "Import danh sách null";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 14;
            this.menuItem7.Text = "Export danh sách null";
            this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 15;
            this.menuItem14.Text = "-";
            // 
            // tabSQL
            // 
            this.tabSQL.Controls.Add(this.dgSQL);
            this.tabSQL.Controls.Add(this.panel4);
            this.tabSQL.Controls.Add(this.splitter1);
            this.tabSQL.Controls.Add(this.txtSQL);
            this.tabSQL.Location = new System.Drawing.Point(4, 22);
            this.tabSQL.Name = "tabSQL";
            this.tabSQL.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tabSQL.Size = new System.Drawing.Size(772, 427);
            this.tabSQL.TabIndex = 4;
            this.tabSQL.Text = "Truy vấn thông tin       ";
            // 
            // dgSQL
            // 
            this.dgSQL.AlternatingBackColor = System.Drawing.SystemColors.Info;
            this.dgSQL.BackColor = System.Drawing.Color.White;
            this.dgSQL.BackgroundColor = System.Drawing.Color.White;
            this.dgSQL.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dgSQL.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dgSQL.CaptionForeColor = System.Drawing.SystemColors.ControlText;
            this.dgSQL.CaptionText = "Kết quả";
            this.dgSQL.DataMember = "";
            this.dgSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSQL.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgSQL.Location = new System.Drawing.Point(0, 122);
            this.dgSQL.Name = "dgSQL";
            this.dgSQL.RowHeaderWidth = 20;
            this.dgSQL.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.dgSQL.SelectionForeColor = System.Drawing.Color.White;
            this.dgSQL.Size = new System.Drawing.Size(772, 305);
            this.dgSQL.TabIndex = 1;
            this.dgSQL.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cbHis);
            this.panel4.Controls.Add(this.butSQL_New);
            this.panel4.Controls.Add(this.butSQL_Refresh);
            this.panel4.Controls.Add(this.butSQL_Pre);
            this.panel4.Controls.Add(this.butSQL_Next);
            this.panel4.Controls.Add(this.butSQL_ClearHistory);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel4.Location = new System.Drawing.Point(0, 91);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.panel4.Size = new System.Drawing.Size(772, 31);
            this.panel4.TabIndex = 154;
            // 
            // cbHis
            // 
            this.cbHis.Location = new System.Drawing.Point(208, 5);
            this.cbHis.Name = "cbHis";
            this.cbHis.Size = new System.Drawing.Size(24, 21);
            this.cbHis.TabIndex = 6;
            this.cbHis.Text = "comboBox1";
            this.cbHis.Visible = false;
            // 
            // butSQL_New
            // 
            this.butSQL_New.BackColor = System.Drawing.SystemColors.Control;
            this.butSQL_New.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butSQL_New.Dock = System.Windows.Forms.DockStyle.Right;
            this.butSQL_New.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSQL_New.Image = ((System.Drawing.Image)(resources.GetObject("butSQL_New.Image")));
            this.butSQL_New.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.butSQL_New.Location = new System.Drawing.Point(256, 0);
            this.butSQL_New.Name = "butSQL_New";
            this.butSQL_New.Size = new System.Drawing.Size(113, 28);
            this.butSQL_New.TabIndex = 3;
            this.butSQL_New.Text = "     Câu lệnh &mới";
            this.butSQL_New.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.butSQL_New, "Câu lệnh mới");
            this.butSQL_New.UseVisualStyleBackColor = false;
            this.butSQL_New.Click += new System.EventHandler(this.butSQL_New_Click);
            // 
            // butSQL_Refresh
            // 
            this.butSQL_Refresh.BackColor = System.Drawing.SystemColors.Control;
            this.butSQL_Refresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butSQL_Refresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.butSQL_Refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSQL_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("butSQL_Refresh.Image")));
            this.butSQL_Refresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSQL_Refresh.Location = new System.Drawing.Point(0, 0);
            this.butSQL_Refresh.Name = "butSQL_Refresh";
            this.butSQL_Refresh.Size = new System.Drawing.Size(108, 28);
            this.butSQL_Refresh.TabIndex = 5;
            this.butSQL_Refresh.Text = "      &Xem (F5)";
            this.butSQL_Refresh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSQL_Refresh.UseVisualStyleBackColor = false;
            this.butSQL_Refresh.Click += new System.EventHandler(this.butSQL_Refresh_Click);
            // 
            // butSQL_Pre
            // 
            this.butSQL_Pre.BackColor = System.Drawing.SystemColors.Control;
            this.butSQL_Pre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butSQL_Pre.Dock = System.Windows.Forms.DockStyle.Right;
            this.butSQL_Pre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSQL_Pre.Image = ((System.Drawing.Image)(resources.GetObject("butSQL_Pre.Image")));
            this.butSQL_Pre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSQL_Pre.Location = new System.Drawing.Point(369, 0);
            this.butSQL_Pre.Name = "butSQL_Pre";
            this.butSQL_Pre.Size = new System.Drawing.Size(116, 28);
            this.butSQL_Pre.TabIndex = 2;
            this.butSQL_Pre.Text = "   Câu lệnh &trước";
            this.butSQL_Pre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.butSQL_Pre, "Câu lệnh trước");
            this.butSQL_Pre.UseVisualStyleBackColor = false;
            this.butSQL_Pre.Click += new System.EventHandler(this.butSQL_Pre_Click);
            // 
            // butSQL_Next
            // 
            this.butSQL_Next.BackColor = System.Drawing.SystemColors.Control;
            this.butSQL_Next.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butSQL_Next.Dock = System.Windows.Forms.DockStyle.Right;
            this.butSQL_Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSQL_Next.Image = ((System.Drawing.Image)(resources.GetObject("butSQL_Next.Image")));
            this.butSQL_Next.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butSQL_Next.Location = new System.Drawing.Point(485, 0);
            this.butSQL_Next.Name = "butSQL_Next";
            this.butSQL_Next.Size = new System.Drawing.Size(117, 28);
            this.butSQL_Next.TabIndex = 1;
            this.butSQL_Next.Text = " Câu lệnh &sau";
            this.butSQL_Next.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.butSQL_Next, "Câu lệnh sau");
            this.butSQL_Next.UseVisualStyleBackColor = false;
            this.butSQL_Next.Click += new System.EventHandler(this.butSQL_Next_Click);
            // 
            // butSQL_ClearHistory
            // 
            this.butSQL_ClearHistory.BackColor = System.Drawing.SystemColors.Control;
            this.butSQL_ClearHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butSQL_ClearHistory.Dock = System.Windows.Forms.DockStyle.Right;
            this.butSQL_ClearHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSQL_ClearHistory.Image = ((System.Drawing.Image)(resources.GetObject("butSQL_ClearHistory.Image")));
            this.butSQL_ClearHistory.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.butSQL_ClearHistory.Location = new System.Drawing.Point(602, 0);
            this.butSQL_ClearHistory.Name = "butSQL_ClearHistory";
            this.butSQL_ClearHistory.Size = new System.Drawing.Size(170, 28);
            this.butSQL_ClearHistory.TabIndex = 4;
            this.butSQL_ClearHistory.Text = "     &Xóa các câu lệnh cũ";
            this.butSQL_ClearHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.butSQL_ClearHistory, "Câu lệnh mới");
            this.butSQL_ClearHistory.UseVisualStyleBackColor = false;
            this.butSQL_ClearHistory.Click += new System.EventHandler(this.butSQL_ClearHistory_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 88);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(772, 3);
            this.splitter1.TabIndex = 153;
            this.splitter1.TabStop = false;
            // 
            // txtSQL
            // 
            this.txtSQL.ContextMenu = this.contextMenu2;
            this.txtSQL.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSQL.Location = new System.Drawing.Point(0, 5);
            this.txtSQL.Multiline = true;
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.Size = new System.Drawing.Size(772, 83);
            this.txtSQL.TabIndex = 155;
            // 
            // contextMenu2
            // 
            this.contextMenu2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem17});
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 0;
            this.menuItem17.Text = "Không build sql";
            this.menuItem17.Click += new System.EventHandler(this.menuItem17_Click);
            // 
            // splitter3
            // 
            this.splitter3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter3.ForeColor = System.Drawing.Color.Blue;
            this.splitter3.Location = new System.Drawing.Point(2, 455);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(780, 2);
            this.splitter3.TabIndex = 3;
            this.splitter3.TabStop = false;
            // 
            // label17
            // 
            this.label17.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label17.Location = new System.Drawing.Point(2, 457);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(780, 2);
            this.label17.TabIndex = 156;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(2, 459);
            this.progressBar1.Maximum = 50;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(780, 10);
            this.progressBar1.TabIndex = 155;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.ForestGreen;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtNgayin);
            this.panel3.Controls.Add(this.txtNguoiin);
            this.panel3.Controls.Add(this.txtTimkiem);
            this.panel3.Controls.Add(this.butIn);
            this.panel3.Controls.Add(this.butXML);
            this.panel3.Controls.Add(this.butExcel);
            this.panel3.Controls.Add(this.butKetthuc);
            this.panel3.Controls.Add(this.butRefresh);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(2, 469);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(2);
            this.panel3.Size = new System.Drawing.Size(780, 33);
            this.panel3.TabIndex = 148;
            // 
            // txtNgayin
            // 
            this.txtNgayin.CustomFormat = "dd/MM/yyyy hh:mm";
            this.txtNgayin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtNgayin.Location = new System.Drawing.Point(301, 4);
            this.txtNgayin.Name = "txtNgayin";
            this.txtNgayin.Size = new System.Drawing.Size(85, 20);
            this.txtNgayin.TabIndex = 0;
            this.txtNgayin.TabStop = false;
            this.txtNgayin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNgayin_KeyDown);
            // 
            // txtNguoiin
            // 
            this.txtNguoiin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNguoiin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNguoiin.Location = new System.Drawing.Point(433, 3);
            this.txtNguoiin.MaxLength = 100;
            this.txtNguoiin.Name = "txtNguoiin";
            this.txtNguoiin.Size = new System.Drawing.Size(168, 23);
            this.txtNguoiin.TabIndex = 1;
            this.txtNguoiin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNguoiin_KeyDown);
            // 
            // txtTimkiem
            // 
            this.txtTimkiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimkiem.Location = new System.Drawing.Point(605, 3);
            this.txtTimkiem.MaxLength = 100;
            this.txtTimkiem.Name = "txtTimkiem";
            this.txtTimkiem.Size = new System.Drawing.Size(69, 23);
            this.txtTimkiem.TabIndex = 7;
            this.txtTimkiem.Text = "Tìm kiếm";
            this.txtTimkiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtTimkiem, "Nhập vào từ cần tìm");
            this.txtTimkiem.Enter += new System.EventHandler(this.txtTimkiem_Enter);
            this.txtTimkiem.Leave += new System.EventHandler(this.txtTimkiem_Leave);
            this.txtTimkiem.TextChanged += new System.EventHandler(this.txtTimkiem_TextChanged);
            this.txtTimkiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimkiem_KeyDown);
            // 
            // butIn
            // 
            this.butIn.BackColor = System.Drawing.SystemColors.Control;
            this.butIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butIn.Dock = System.Windows.Forms.DockStyle.Left;
            this.butIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butIn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(200, 2);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(54, 27);
            this.butIn.TabIndex = 2;
            this.butIn.Text = "     &In";
            this.butIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.butIn, "In báo cáo");
            this.butIn.UseVisualStyleBackColor = false;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butXML
            // 
            this.butXML.BackColor = System.Drawing.SystemColors.Control;
            this.butXML.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butXML.Dock = System.Windows.Forms.DockStyle.Left;
            this.butXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butXML.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butXML.Image = ((System.Drawing.Image)(resources.GetObject("butXML.Image")));
            this.butXML.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXML.Location = new System.Drawing.Point(136, 2);
            this.butXML.Name = "butXML";
            this.butXML.Size = new System.Drawing.Size(64, 27);
            this.butXML.TabIndex = 3;
            this.butXML.Text = "    X&ML";
            this.butXML.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.butXML, "Kết xuất ra XML");
            this.butXML.UseVisualStyleBackColor = false;
            this.butXML.Click += new System.EventHandler(this.butXML_Click);
            // 
            // butExcel
            // 
            this.butExcel.BackColor = System.Drawing.SystemColors.Control;
            this.butExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butExcel.Dock = System.Windows.Forms.DockStyle.Left;
            this.butExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butExcel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butExcel.Image = ((System.Drawing.Image)(resources.GetObject("butExcel.Image")));
            this.butExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExcel.Location = new System.Drawing.Point(66, 2);
            this.butExcel.Name = "butExcel";
            this.butExcel.Size = new System.Drawing.Size(70, 27);
            this.butExcel.TabIndex = 4;
            this.butExcel.Text = "    &Excel";
            this.butExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.butExcel, "Kết xuất ra Excell");
            this.butExcel.UseVisualStyleBackColor = false;
            this.butExcel.Click += new System.EventHandler(this.butExcel_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.BackColor = System.Drawing.SystemColors.Control;
            this.butKetthuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butKetthuc.Dock = System.Windows.Forms.DockStyle.Right;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(677, 2);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(99, 27);
            this.butKetthuc.TabIndex = 6;
            this.butKetthuc.TabStop = false;
            this.butKetthuc.Text = "     &Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.UseVisualStyleBackColor = false;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butRefresh
            // 
            this.butRefresh.BackColor = System.Drawing.SystemColors.Control;
            this.butRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butRefresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.butRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butRefresh.Image = ((System.Drawing.Image)(resources.GetObject("butRefresh.Image")));
            this.butRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butRefresh.Location = new System.Drawing.Point(2, 2);
            this.butRefresh.Name = "butRefresh";
            this.butRefresh.Size = new System.Drawing.Size(64, 27);
            this.butRefresh.TabIndex = 5;
            this.butRefresh.Text = "    &Xem";
            this.butRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.butRefresh, "Nạp lại danh sách");
            this.butRefresh.UseVisualStyleBackColor = false;
            this.butRefresh.Click += new System.EventHandler(this.butRefresh_Click);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(380, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 24);
            this.label2.TabIndex = 1004;
            this.label2.Text = "Người in:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(245, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 24);
            this.label1.TabIndex = 1003;
            this.label1.Text = "Ngày in:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pAdd_Menu
            // 
            this.pAdd_Menu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pAdd_Menu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pAdd_Menu.Controls.Add(this.lbZoom);
            this.pAdd_Menu.Controls.Add(this.pNull);
            this.pAdd_Menu.Controls.Add(this.txtAdd_Stt);
            this.pAdd_Menu.Controls.Add(this.txtAdd_Report);
            this.pAdd_Menu.Controls.Add(this.txtAdd_Width);
            this.pAdd_Menu.Controls.Add(this.txtAdd_SQL);
            this.pAdd_Menu.Controls.Add(this.txtAdd_Tenfield);
            this.pAdd_Menu.Controls.Add(this.txtAdd_Field);
            this.pAdd_Menu.Controls.Add(this.txtAdd_Ten);
            this.pAdd_Menu.Controls.Add(this.label9);
            this.pAdd_Menu.Controls.Add(this.label8);
            this.pAdd_Menu.Controls.Add(this.label7);
            this.pAdd_Menu.Controls.Add(this.butAdd_Moi);
            this.pAdd_Menu.Controls.Add(this.lbAdd_Title);
            this.pAdd_Menu.Controls.Add(this.butAdd_Xoa);
            this.pAdd_Menu.Controls.Add(this.butAdd_Boqua);
            this.pAdd_Menu.Controls.Add(this.butAdd_Luu);
            this.pAdd_Menu.Controls.Add(this.label6);
            this.pAdd_Menu.Controls.Add(this.label5);
            this.pAdd_Menu.Controls.Add(this.chkReadonly);
            this.pAdd_Menu.Controls.Add(this.label11);
            this.pAdd_Menu.Controls.Add(this.label13);
            this.pAdd_Menu.ForeColor = System.Drawing.Color.Blue;
            this.pAdd_Menu.Location = new System.Drawing.Point(266, 198);
            this.pAdd_Menu.Name = "pAdd_Menu";
            this.pAdd_Menu.Size = new System.Drawing.Size(514, 308);
            this.pAdd_Menu.TabIndex = 0;
            this.pAdd_Menu.Visible = false;
            this.pAdd_Menu.VisibleChanged += new System.EventHandler(this.pAdd_Menu_VisibleChanged);
            // 
            // lbZoom
            // 
            this.lbZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbZoom.BackColor = System.Drawing.Color.ForestGreen;
            this.lbZoom.ImageIndex = 1;
            this.lbZoom.ImageList = this.imageList1;
            this.lbZoom.Location = new System.Drawing.Point(492, 0);
            this.lbZoom.Name = "lbZoom";
            this.lbZoom.Size = new System.Drawing.Size(22, 18);
            this.lbZoom.TabIndex = 19;
            this.lbZoom.Tag = "1";
            this.lbZoom.Click += new System.EventHandler(this.lbZoom_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // pNull
            // 
            this.pNull.Controls.Add(this.butNull_Dong);
            this.pNull.Controls.Add(this.butNull_Luu);
            this.pNull.Controls.Add(this.dgNull);
            this.pNull.Location = new System.Drawing.Point(424, 275);
            this.pNull.Name = "pNull";
            this.pNull.Padding = new System.Windows.Forms.Padding(2);
            this.pNull.Size = new System.Drawing.Size(40, 24);
            this.pNull.TabIndex = 18;
            // 
            // butNull_Dong
            // 
            this.butNull_Dong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butNull_Dong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butNull_Dong.Image = ((System.Drawing.Image)(resources.GetObject("butNull_Dong.Image")));
            this.butNull_Dong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butNull_Dong.Location = new System.Drawing.Point(245, -8);
            this.butNull_Dong.Name = "butNull_Dong";
            this.butNull_Dong.Size = new System.Drawing.Size(74, 28);
            this.butNull_Dong.TabIndex = 159;
            this.butNull_Dong.Text = "       Đóng";
            this.butNull_Dong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butNull_Dong.Click += new System.EventHandler(this.butNull_Dong_Click);
            // 
            // butNull_Luu
            // 
            this.butNull_Luu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butNull_Luu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butNull_Luu.Image = ((System.Drawing.Image)(resources.GetObject("butNull_Luu.Image")));
            this.butNull_Luu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butNull_Luu.Location = new System.Drawing.Point(185, -8);
            this.butNull_Luu.Name = "butNull_Luu";
            this.butNull_Luu.Size = new System.Drawing.Size(60, 28);
            this.butNull_Luu.TabIndex = 158;
            this.butNull_Luu.Text = "      Lưu";
            this.butNull_Luu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butNull_Luu.Click += new System.EventHandler(this.butNull_Luu_Click);
            // 
            // dgNull
            // 
            this.dgNull.AlternatingBackColor = System.Drawing.SystemColors.Info;
            this.dgNull.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgNull.BackColor = System.Drawing.Color.White;
            this.dgNull.BackgroundColor = System.Drawing.Color.White;
            this.dgNull.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dgNull.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dgNull.CaptionForeColor = System.Drawing.SystemColors.ControlText;
            this.dgNull.CaptionText = "Danh sách null";
            this.dgNull.DataMember = "";
            this.dgNull.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgNull.Location = new System.Drawing.Point(2, 2);
            this.dgNull.Name = "dgNull";
            this.dgNull.RowHeaderWidth = 20;
            this.dgNull.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.dgNull.SelectionForeColor = System.Drawing.Color.White;
            this.dgNull.Size = new System.Drawing.Size(36, 0);
            this.dgNull.TabIndex = 157;
            this.dgNull.TabStop = false;
            // 
            // txtAdd_Stt
            // 
            this.txtAdd_Stt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdd_Stt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdd_Stt.Location = new System.Drawing.Point(440, 37);
            this.txtAdd_Stt.MaxLength = 5;
            this.txtAdd_Stt.Name = "txtAdd_Stt";
            this.txtAdd_Stt.Size = new System.Drawing.Size(64, 21);
            this.txtAdd_Stt.TabIndex = 1;
            this.txtAdd_Stt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAdd_Stt.Validated += new System.EventHandler(this.txtAdd_SttValidated);
            this.txtAdd_Stt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAdd_SttKeyDown);
            // 
            // txtAdd_Report
            // 
            this.txtAdd_Report.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdd_Report.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdd_Report.Location = new System.Drawing.Point(369, 250);
            this.txtAdd_Report.MaxLength = 100;
            this.txtAdd_Report.Name = "txtAdd_Report";
            this.txtAdd_Report.Size = new System.Drawing.Size(135, 21);
            this.txtAdd_Report.TabIndex = 6;
            this.txtAdd_Report.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAdd_Report_KeyDown);
            // 
            // txtAdd_Width
            // 
            this.txtAdd_Width.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdd_Width.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdd_Width.Location = new System.Drawing.Point(7, 250);
            this.txtAdd_Width.MaxLength = 1000;
            this.txtAdd_Width.Name = "txtAdd_Width";
            this.txtAdd_Width.Size = new System.Drawing.Size(360, 21);
            this.txtAdd_Width.TabIndex = 5;
            this.txtAdd_Width.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAdd_Width_KeyDown);
            // 
            // txtAdd_SQL
            // 
            this.txtAdd_SQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdd_SQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdd_SQL.Location = new System.Drawing.Point(6, 75);
            this.txtAdd_SQL.MaxLength = 4000;
            this.txtAdd_SQL.Multiline = true;
            this.txtAdd_SQL.Name = "txtAdd_SQL";
            this.txtAdd_SQL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAdd_SQL.Size = new System.Drawing.Size(498, 84);
            this.txtAdd_SQL.TabIndex = 2;
            // 
            // txtAdd_Tenfield
            // 
            this.txtAdd_Tenfield.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdd_Tenfield.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdd_Tenfield.Location = new System.Drawing.Point(6, 213);
            this.txtAdd_Tenfield.MaxLength = 1000;
            this.txtAdd_Tenfield.Name = "txtAdd_Tenfield";
            this.txtAdd_Tenfield.Size = new System.Drawing.Size(498, 21);
            this.txtAdd_Tenfield.TabIndex = 4;
            this.txtAdd_Tenfield.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAdd_Tenfield_KeyDown);
            // 
            // txtAdd_Field
            // 
            this.txtAdd_Field.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdd_Field.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdd_Field.Location = new System.Drawing.Point(6, 176);
            this.txtAdd_Field.MaxLength = 1000;
            this.txtAdd_Field.Name = "txtAdd_Field";
            this.txtAdd_Field.Size = new System.Drawing.Size(498, 21);
            this.txtAdd_Field.TabIndex = 3;
            this.txtAdd_Field.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAdd_Field_KeyDown);
            // 
            // txtAdd_Ten
            // 
            this.txtAdd_Ten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdd_Ten.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdd_Ten.Location = new System.Drawing.Point(6, 37);
            this.txtAdd_Ten.MaxLength = 100;
            this.txtAdd_Ten.Name = "txtAdd_Ten";
            this.txtAdd_Ten.Size = new System.Drawing.Size(433, 21);
            this.txtAdd_Ten.TabIndex = 0;
            this.txtAdd_Ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAdd_Ten_KeyDown);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.Location = new System.Drawing.Point(6, 231);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(170, 23);
            this.label9.TabIndex = 14;
            this.label9.Text = "Độ rộng cột hiển thị";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.Location = new System.Drawing.Point(5, 194);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(322, 23);
            this.label8.TabIndex = 12;
            this.label8.Text = "Tiêu đề cột hiển thị";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.Location = new System.Drawing.Point(5, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(322, 23);
            this.label7.TabIndex = 10;
            this.label7.Text = "Tên cột hiển thị";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butAdd_Moi
            // 
            this.butAdd_Moi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butAdd_Moi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butAdd_Moi.Image = ((System.Drawing.Image)(resources.GetObject("butAdd_Moi.Image")));
            this.butAdd_Moi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAdd_Moi.Location = new System.Drawing.Point(83, 274);
            this.butAdd_Moi.Name = "butAdd_Moi";
            this.butAdd_Moi.Size = new System.Drawing.Size(79, 28);
            this.butAdd_Moi.TabIndex = 8;
            this.butAdd_Moi.Text = "     Mới";
            this.butAdd_Moi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAdd_Moi.Click += new System.EventHandler(this.butAdd_Moi_Click);
            // 
            // lbAdd_Title
            // 
            this.lbAdd_Title.BackColor = System.Drawing.Color.ForestGreen;
            this.lbAdd_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbAdd_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAdd_Title.ForeColor = System.Drawing.Color.White;
            this.lbAdd_Title.Location = new System.Drawing.Point(0, 0);
            this.lbAdd_Title.Name = "lbAdd_Title";
            this.lbAdd_Title.Size = new System.Drawing.Size(512, 18);
            this.lbAdd_Title.TabIndex = 7;
            this.lbAdd_Title.Text = "THÊM MỚI MỤC";
            this.lbAdd_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butAdd_Xoa
            // 
            this.butAdd_Xoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butAdd_Xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butAdd_Xoa.Image = ((System.Drawing.Image)(resources.GetObject("butAdd_Xoa.Image")));
            this.butAdd_Xoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAdd_Xoa.Location = new System.Drawing.Point(241, 274);
            this.butAdd_Xoa.Name = "butAdd_Xoa";
            this.butAdd_Xoa.Size = new System.Drawing.Size(91, 28);
            this.butAdd_Xoa.TabIndex = 10;
            this.butAdd_Xoa.Text = "       Xoá";
            this.butAdd_Xoa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAdd_Xoa.Click += new System.EventHandler(this.butAdd_Xoa_Click);
            // 
            // butAdd_Boqua
            // 
            this.butAdd_Boqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butAdd_Boqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butAdd_Boqua.Image = ((System.Drawing.Image)(resources.GetObject("butAdd_Boqua.Image")));
            this.butAdd_Boqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAdd_Boqua.Location = new System.Drawing.Point(332, 274);
            this.butAdd_Boqua.Name = "butAdd_Boqua";
            this.butAdd_Boqua.Size = new System.Drawing.Size(91, 28);
            this.butAdd_Boqua.TabIndex = 11;
            this.butAdd_Boqua.Text = "       Đóng";
            this.butAdd_Boqua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAdd_Boqua.Click += new System.EventHandler(this.butAdd_Boqua_Click);
            // 
            // butAdd_Luu
            // 
            this.butAdd_Luu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butAdd_Luu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butAdd_Luu.Image = ((System.Drawing.Image)(resources.GetObject("butAdd_Luu.Image")));
            this.butAdd_Luu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAdd_Luu.Location = new System.Drawing.Point(162, 274);
            this.butAdd_Luu.Name = "butAdd_Luu";
            this.butAdd_Luu.Size = new System.Drawing.Size(79, 28);
            this.butAdd_Luu.TabIndex = 9;
            this.butAdd_Luu.Text = "      Lưu";
            this.butAdd_Luu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAdd_Luu.Click += new System.EventHandler(this.butAdd_Luu_Click);
            // 
            // label6
            // 
            this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Location = new System.Drawing.Point(5, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "Câu truy vấn";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(5, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(322, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tên";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkReadonly
            // 
            this.chkReadonly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkReadonly.Location = new System.Drawing.Point(6, 276);
            this.chkReadonly.Name = "chkReadonly";
            this.chkReadonly.Size = new System.Drawing.Size(104, 24);
            this.chkReadonly.TabIndex = 7;
            this.chkReadonly.Text = "Readonly";
            this.chkReadonly.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkReadonly_KeyDown);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.Location = new System.Drawing.Point(369, 231);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(135, 23);
            this.label11.TabIndex = 15;
            this.label11.Text = "Report";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Location = new System.Drawing.Point(440, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 23);
            this.label13.TabIndex = 17;
            this.label13.Text = "Stt";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbKhoa
            // 
            this.cbKhoa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKhoa.Location = new System.Drawing.Point(468, 58);
            this.cbKhoa.Name = "cbKhoa";
            this.cbKhoa.Size = new System.Drawing.Size(318, 21);
            this.cbKhoa.TabIndex = 78;
            // 
            // frmQuanlybenhvien
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 565);
            this.Controls.Add(this.pAdd_Menu);
            this.Controls.Add(this.cbKhoa);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmQuanlybenhvien";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = " Thống kê báo cáo tổng hợp";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmQuanlybenhvien_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmQuanlybenhvien_KeyDown);
            this.Load += new System.EventHandler(this.frmQuanlybenhvien_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThang)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabBN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgQLBN)).EndInit();
            this.tabSQL.ResumeLayout(false);
            this.tabSQL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSQL)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pAdd_Menu.ResumeLayout(false);
            this.pAdd_Menu.PerformLayout();
            this.pNull.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgNull)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
		private void frmQuanlybenhvien_Load(object sender, System.EventArgs e)
		{
			f_LoadHistory();
			txtNgayin.Value=DateTime.Now;
			pNull.Visible=false;
			toolTip1.SetToolTip(label6,"Nhấn vào đây để kiểm tra câu truy vấn.\n\n:v_tn,:v_dn,:v_mabn,:v_mabn1,:v_mabn2,:v_hoten,:v_namsinh,:v_diachi,:v_phai,:v_mabhyt\n\n để lấy giá trị từ ngày, đến ngày, mã bn lúc thực thi câu lệnh");
			pAdd_Menu.Tag="";
			txtAdd_SQL.Tag="";
			txtAdd_Ten.Tag="";

			butIn.Tag="";
			butIn.Enabled=butIn.Tag.ToString()!="";
			f_Prepare();
			f_Write_Null();
			f_Load_CB_Khoa();
			f_Load_Tree_QLBN();
			f_Load_Histotry();
			f_Load_CB_Baocao();
			cbBaocao_SelectedIndexChanged(null,null);
		}
		private void f_Load_CB_Baocao()
		{
			try
			{
				DataSet ads = new DataSet();
				ads.Tables.Add("Table");
				ads.Tables[0].Columns.Add("MA");
				ads.Tables[0].Columns.Add("TEN");
				ads.Tables[0].Rows.Add(new string[]{"0","Từ ngày ...Đến ngày"});
				ads.Tables[0].Rows.Add(new string[]{"1","Tháng"});
				ads.Tables[0].Rows.Add(new string[]{"2","Quý"});
				cbBaocao.DisplayMember="TEN";
				cbBaocao.ValueMember="MA";
				cbBaocao.DataSource=ads.Tables[0];
				try
				{
					txtTN.Value=DateTime.Now;
					txtDN.Value=DateTime.Now;
				}
				catch
				{
				}
				try
				{
					txtThang.Value=1;
					txtNam.Value=DateTime.Now.Year;
				}
				catch
				{
				}
			}
			catch
			{
			}
		}
		private void f_Prepare()
		{
			try
			{
				if(!System.IO.Directory.Exists("..\\..\\data"))
				{
					System.IO.Directory.CreateDirectory("..\\..\\data");
				}
				try
				{
					string atmp=m_bc.get_data("select * from medibv." + m_table + "").Tables[0].Rows.Count.ToString();
				}
				catch
				{
					m_bc.f_create_treemenu(m_table);
				}

			}
			catch
			{
			}
		}
		private void f_Load_Tree(TreeView v_tree,DataSet v_ds)
		{
			try
			{
				v_tree.Nodes.Clear();
				v_tree.ShowLines=true;
				v_tree.ShowPlusMinus=true;
				v_tree.ShowRootLines=true;
				v_tree.FullRowSelect=true;
				TreeNode anode;
				foreach(DataRow r in v_ds.Tables[0].Select("id_cha=0","stt"))
				{
					anode=new TreeNode(r["ten"].ToString());
					anode.Tag=r["id"].ToString().Trim();
					//anode.Text=(v_tree.Nodes.Count+1).ToString()+". "+anode.Text;
					anode.ForeColor=Color.Black;
					if(v_ds.Tables[0].Select("id_cha="+anode.Tag.ToString(),"stt").Length>0)
					{
						f_Add_Node(anode,v_ds);
					}
					v_tree.Nodes.Add(anode);
				}
			}
			catch
			{
			}
            if (treeQLBN.Nodes.Count > 0)
            {
                try
                {
                    treeQLBN.Tag = treeQLBN.SelectedNode.Tag.ToString();
                }
                catch { }
            }
			v_tree.ExpandAll();
		}
		private void f_Add_Node(TreeNode v_node,DataSet v_ds)
		{
			try
			{
				TreeNode anode;
				foreach(DataRow r in v_ds.Tables[0].Select("id_cha="+v_node.Tag.ToString(),"stt"))
				{
					anode=new TreeNode(r["ten"].ToString());
					anode.Tag=r["id"].ToString().Trim();
					//anode.Text=(v_node.Nodes.Count+1).ToString()+". "+anode.Text;
					anode.ForeColor=Color.Black;
					if(v_ds.Tables[0].Select("id_cha="+anode.Tag.ToString(),"stt").Length>0)
					{
						f_Add_Node(anode,v_ds);
					}
					v_node.Nodes.Add(anode);
				}
			}
			catch
			{
			}
		}
		private void f_Load_Tree_QLBN()
		{
			f_Load_Tree(treeQLBN, m_bc.get_treemenu(m_table));
		}
		private void f_Load_Histotry()
		{
			try
			{
				cbHis.DisplayMember="TEN";
				cbHis.ValueMember="SQL";
				cbHis.DataSource = m_bc.get_data("select * from medibv." + m_table + "_history").Tables[0];
				cbHis.SelectedIndex=0;
			}
			catch
			{
			}
		}

		private void f_Save_Histotry(string v_sql)
		{
			try
			{
				v_sql=v_sql.Trim();
				if(v_sql.Length==0) return;
			}
			catch
			{
			}
		}
		private void f_Load_CB_Khoa()
		{
			try
			{
				DataSet ads = m_bc.get_data("select makp,tenkp from medibv.btdkp_bv order by loai, tenkp");
				DataRow r = ads.Tables[0].NewRow();
				r["makp"]="-1";
				r["tenkp"]="";
				ads.Tables[0].Rows.InsertAt(r,0);
				cbKhoa.DisplayMember="TENKP";
				cbKhoa.ValueMember="MAKP";
				cbKhoa.DataSource = ads.Tables[0];
				cbKhoa.SelectedIndex=0;
			}
			catch(Exception ex)
			{
                MessageBox.Show(ex.ToString());
			}
		}
		private string f_Cur_Date()
		{
			try
			{
				return System.DateTime.Now.Day.ToString().PadLeft(2,'0')+ "/" + System.DateTime.Now.Month.ToString().PadLeft(2,'0')+ "/" + System.DateTime.Now.Year.ToString();
			}
			catch
			{
				return "";
			}
		}

		private void f_SetEvent(System.Windows.Forms.Control v_c)
		{
			try
			{
				foreach(Control c in v_c.Controls)
				{
					if(c.Controls.Count>0)
					{
						f_SetEvent(c);
					}
					else
					{
						c.Leave += new System.EventHandler(this.Control_Leave);
						c.Enter += new System.EventHandler(this.Control_Enter);
					}
				}
			}
			catch
			{
			}
		}
		private void Control_Enter(object sender, System.EventArgs e)
		{
			try
			{
				System.Windows.Forms.Control c = (System.Windows.Forms.Control)(sender);
				if((c.GetType().ToString()=="System.Windows.Forms.TextBox")||(c.GetType().ToString()=="System.Windows.Forms.ComboBox")||(c.GetType().ToString()=="AsYetUnnamed.MultiColumnListBox")||(c.GetType().ToString()=="System.Windows.Forms.TreeView")||(c.GetType().ToString()=="System.Windows.Forms.DataGrid")||(c.GetType().ToString()=="System.Windows.Forms.DateTimePicker")||(c.GetType().ToString()=="System.Windows.Forms.CheckedListBox"))
				{
					c.BackColor=SystemColors.Info;
					if(c.ForeColor!=Color.Red && c.GetType().ToString()!="System.Windows.Forms.TreeView")
					{
						c.ForeColor=SystemColors.InfoText;
					}
					if(c.GetType().ToString()=="System.Windows.Forms.DataGrid")
					{
						System.Windows.Forms.DataGrid c1 = (System.Windows.Forms.DataGrid)(sender);
						c1.BackgroundColor=SystemColors.Info;
					}
					else
						if(c.GetType().ToString()=="System.Windows.Forms.ComboBox")
					{
						System.Windows.Forms.ComboBox c1 = (System.Windows.Forms.ComboBox)(sender);
						if(c1.SelectedIndex<0)
						{
							c1.SelectedIndex=0;
						}
					}
				}
			}
			catch
			{
			}
		}
		private void Control_Leave(object sender, System.EventArgs e)
		{
			try
			{
				System.Windows.Forms.Control c = (System.Windows.Forms.Control)(sender);
				if((c.GetType().ToString()=="System.Windows.Forms.TextBox")||(c.GetType().ToString()=="System.Windows.Forms.ComboBox")||(c.GetType().ToString()=="AsYetUnnamed.MultiColumnListBox")||(c.GetType().ToString()=="System.Windows.Forms.TreeView")||(c.GetType().ToString()=="System.Windows.Forms.DataGrid")||(c.GetType().ToString()=="System.Windows.Forms.DateTimePicker"))
				{
					c.BackColor=Color.FromArgb(255,255,255);
					if(c.ForeColor!=Color.Red)
					{
						c.ForeColor=SystemColors.ControlText;
					}
					if(c.GetType().ToString()=="System.Windows.Forms.DataGrid")
					{
						System.Windows.Forms.DataGrid c1 = (System.Windows.Forms.DataGrid)(sender);
						c1.BackgroundColor=Color.White;
					}
				}
			}
			catch
			{
			}
		}
		private string f_Get_GhiChu()
		{
			try
			{
				string r="";
				if(cbBaocao.SelectedValue.ToString()=="1")
				{
					r="(Tháng "+txtThang.Value.ToString()+" năm "+txtNam.Value.ToString()+")";
					return r;
				}
				if(cbBaocao.SelectedValue.ToString()=="2")
				{
					r="(Quý "+txtThang.Value.ToString()+" năm "+txtNam.Value.ToString()+")";
					return r;
				}
				DateTime ad1 = new DateTime(txtTN.Value.Year,txtTN.Value.Month,txtTN.Value.Day);
				DateTime ad2 = new DateTime(txtDN.Value.Year,txtDN.Value.Month,txtDN.Value.Day);
				if(m_tinhgio)
				{
					ad1 = new DateTime(txtTN.Value.Year,txtTN.Value.Month,txtTN.Value.Day,txtTN.Value.Hour,txtTN.Value.Minute,0);
					ad2 = new DateTime(txtDN.Value.Year,txtDN.Value.Month,txtDN.Value.Day,txtDN.Value.Hour,txtDN.Value.Minute,0);
					if(ad1==ad2)
					{
						r="(Lúc "+ad1.Hour.ToString().PadLeft(2,'0')+ ":" +ad1.Minute.ToString().PadLeft(2,'0') + " ngày " + ad1.Day.ToString().PadLeft(2,'0') + "/" + ad1.Month.ToString().PadLeft(2,'0') + "/" +ad1.Year.ToString() + ")";
					}
					else
					{
						r="(Từ "+ad1.Hour.ToString().PadLeft(2,'0')+ ":" +ad1.Minute.ToString().PadLeft(2,'0')+" ngày " + ad1.Day.ToString().PadLeft(2,'0') + "/" + ad1.Month.ToString().PadLeft(2,'0') + "/" +ad1.Year.ToString()  + " đến "+ad2.Hour.ToString().PadLeft(2,'0')+ ":" +ad2.Minute.ToString().PadLeft(2,'0') +" ngày " + ad2.Day.ToString().PadLeft(2,'0') + "/" + ad2.Month.ToString().PadLeft(2,'0') + "/" +ad2.Year.ToString() + ")";
					}
				}
				else
				{
					if(ad1==ad2)
					{
						r="(Ngày " + ad1.Day.ToString().PadLeft(2,'0') + "/" + ad1.Month.ToString().PadLeft(2,'0') + "/" +ad1.Year.ToString() + ")";
					}
					else
					{
						r="(Từ ngày " + ad1.Day.ToString().PadLeft(2,'0') + "/" + ad1.Month.ToString().PadLeft(2,'0') + "/" +ad1.Year.ToString() + " đến ngày " + ad2.Day.ToString().PadLeft(2,'0') + "/" + ad2.Month.ToString().PadLeft(2,'0') + "/" +ad2.Year.ToString() + ")";
					}
				}
				return r;
			}
			catch
			{
				return "";
			}
		}
		private void f_Export_Excel(DataSet v_ds1, string v_filepath)
		{
			if(v_filepath.ToLower().Substring(v_filepath.Length-4)!=".xls") v_filepath=v_filepath+".xls";
			try
			{
				System.IO.StreamWriter sw  =  new System.IO.StreamWriter(v_filepath,false,System.Text.Encoding.UTF8);
				string astr="";
				astr="<Table border=1 style=\"font-family: Arial; font-size: 10pt; font-weight: normal\">";
				astr+="<tr>";
				for(int k=0;k<v_ds1.Tables[0].Columns.Count;k++)
				{
					astr+="<td style=\"font-family: Arial; font-size: 10pt; font-weight: bold\">";
					astr+=v_ds1.Tables[0].Columns[k].ColumnName;
					astr+="&nbsp;</td>";
				}
				astr+="</tr>";
				sw.Write(astr);
				for(int i=0;i<v_ds1.Tables[0].Rows.Count;i++)
				{
					astr="<tr>";
					for(int k=0;k<v_ds1.Tables[0].Columns.Count;k++)
					{
						astr+="<td>";
						astr+=v_ds1.Tables[0].Rows[i][k].ToString();
						if(v_ds1.Tables[0].Columns[k].DataType.ToString()=="System.String")
						{
							astr+="&nbsp;";
						}
						astr+="</td>";
					}
					astr+="</tr>";
					sw.Write(astr);
				}
				astr="</table>";
				sw.Write(astr);
				sw.Close();
				f_StopTimer();
				System.Diagnostics.Process.Start(v_filepath);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void f_Export_Excel_DG(DataGrid v_dg, string v_filepath, string v_filter)
		{
			CurrencyManager cm = (CurrencyManager)BindingContext[v_dg.DataSource,v_dg.DataMember];  
			DataView dv = (DataView) cm.List; 
			if(v_dg.TableStyles.Count<=0)
			{
				DataSet ads = new DataSet();
				ads.Tables.Add(dv.Table.Copy());
				f_Export_Excel(ads,v_filepath);
			}
			else
			{
				if(v_filepath.ToLower().Substring(v_filepath.Length-4)!=".xls")
				{
					v_filepath=v_filepath+".xls";
				}
				try
				{
					System.IO.StreamWriter sw  =  new System.IO.StreamWriter(v_filepath,false,System.Text.Encoding.UTF8);
					string astr="";
					astr="<Table border=1 style=\"font-family: Arial; font-size: 10pt; font-weight: normal\">";
					astr+="<tr>";
					astr+="<td colspan="+v_dg.TableStyles[0].GridColumnStyles.Count.ToString()+" style=\"border-left:0; border-right:0; border-top:0;border-bottom:0; font-family: Arial; font-size: 12pt; font-weight: bold; text-align:center\">";
					astr+=v_dg.CaptionText.Trim().ToUpper();
					astr+="&nbsp;</td>";
					astr+="</tr>";
					astr+="<tr>";
					astr+="<td colspan="+v_dg.TableStyles[0].GridColumnStyles.Count.ToString()+" style=\"border-left:0; border-right:0; border-top:0;border-bottom:0; font-family: Arial; font-size: 11pt; font-weight: bold; text-align:center\">";
					astr+="(TỪ NGÀY "+txtTN.Text.Substring(0,10)+" ĐẾN NGÀY "+txtDN.Text.Substring(0,10)+")";
					astr+="&nbsp;</td>";
					astr+="</tr>";
					astr+="<tr>";
					astr+="<td colspan="+v_dg.TableStyles[0].GridColumnStyles.Count.ToString()+" style=\"border-left:0; border-right:0; border-top:0;border-bottom:0;font-family: Arial; font-size: 12pt; font-weight: bold; text-align:center\">";
					astr+="&nbsp;</td>";
					astr+="</tr>";
					sw.Write(astr);

					astr="<tr>";
					for(int k=0;k<v_dg.TableStyles[0].GridColumnStyles.Count;k++)
					{
						for(int i=0;i<dv.Table.Columns.Count;i++)
						{
							if(v_dg.TableStyles[0].GridColumnStyles[k].MappingName.ToLower().Trim()==dv.Table.Columns[i].ColumnName.ToLower().Trim())
							{
								astr+="<td style=\"font-family: Arial; font-size: 10pt; font-weight: bold;width="+(v_dg.TableStyles[0].GridColumnStyles[k].Width+20).ToString()+"\">";
								astr+=v_dg.TableStyles[0].GridColumnStyles[k].HeaderText.Trim();
								astr+="&nbsp;</td>";
								break;
							}
						}
					}
					astr+="</tr>";
					sw.Write(astr);
					foreach(DataRow r in dv.Table.Select(v_filter))
					{
						astr="<tr>";
						for(int k=0;k<v_dg.TableStyles[0].GridColumnStyles.Count;k++)
						{
							for(int l=0;l<dv.Table.Columns.Count;l++)
							{
								if(v_dg.TableStyles[0].GridColumnStyles[k].MappingName.ToLower().Trim()==dv.Table.Columns[l].ColumnName.ToLower().Trim())
								{
									astr+="<td>";
									astr+=r[l].ToString();
									if(dv.Table.Columns[l].DataType.ToString()=="System.String")
									{
										astr+="&nbsp;";
									}
									astr+="</td>";
								}
							}
						}
						astr+="</tr>";
						sw.Write(astr);
					}
					astr="</table>";
					sw.Write(astr);
					sw.Close();
					System.Diagnostics.Process.Start(v_filepath);
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmQuanlybenhvien_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.A&&e.Control&&e.Alt&&e.Shift)
				{
					m_admin=!m_admin;
					for(int i=0;i<contextMenu1.MenuItems.Count;i++)
					{
						contextMenu1.MenuItems[i].Enabled=m_admin;
					}
					return;
				}
				switch(e.KeyCode)
				{
					case Keys.F10:
						butKetthuc_Click(null,null);
						break;
					case Keys.F5:
						break;
				}
			}
			catch
			{
			}
		}

		private void txtTN_ValueChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(txtDN.Value<txtTN.Value)
				{
					txtDN.Value=txtTN.Value;
				}
			}
			catch
			{
			}
		}

		private void txtDN_ValueChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(txtTN.Value>txtDN.Value)
				{
					txtTN.Value=txtDN.Value;
				}
			}
			catch
			{
			}
		}

		private void txtTN_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					txtDN.Focus();
				}
			}
			catch
			{
			}
		}

		private void txtDN_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}
		private void tabControl1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
		{
			try
			{
				//This line of code will help you to change the apperance like size,name,style.
				Font f;
				//For background color
				Brush backBrush;
				//For forground color
				Brush foreBrush;
			
				//This construct will hell you to deside which tab page have current focus
				//to change the style.
				if(e.Index == this.tabControl1.SelectedIndex)
				{
					//This line of code will help you to change the apperance like size,name,style.
					f = new Font(e.Font, FontStyle.Regular | FontStyle.Regular);
					f = new Font(e.Font,FontStyle.Regular);

					backBrush = new System.Drawing.SolidBrush(SystemColors.Control);
					foreBrush = Brushes.Blue;
				}
				else
				{
					f = e.Font;
					backBrush = new SolidBrush(SystemColors.Control); 
					foreBrush = new SolidBrush(Color.Navy);
				}
                
				//To set the alignment of the caption.
				string tabName = this.tabControl1.TabPages[e.Index].Text;
				StringFormat sf = new StringFormat();
				sf.Alignment = StringAlignment.Center;
	
				//Thsi will help you to fill the interior portion of
				//selected tabpage.
				
				e.Graphics.FillRectangle(backBrush, e.Bounds);
				Rectangle r = e.Bounds;
				r = new Rectangle(r.X, r.Y + 3, r.Width, r.Height-3);
				e.Graphics.DrawString(tabName, f, foreBrush, r, sf);

				sf.Dispose();
				if(e.Index == this.tabControl1.SelectedIndex)
				{
					f.Dispose();
					backBrush.Dispose();
				}
				else
				{
					backBrush.Dispose();
					foreBrush.Dispose();
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,ex.ToString(),"MEDISOFT THIS",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		private void f_Load_DG(string v_id)
		{
			m_tinhgio=false;
			f_StartTimer();
			butRefresh.Tag=v_id;
			try
			{
				DataRow r = m_bc.get_data("select * from medibv." + m_table + " where id="+v_id).Tables[0].Rows[0];
				string []atenfield=new string[]{""};
				string []acaptionfield=new string[]{""};;
				string []awidth=new string[]{""};;
				butIn.Enabled=r["report"].ToString().Trim()!="";
				butIn.Tag=r["report"].ToString().Trim();
				string asql="";
				if(r["tenfield"].ToString()!="")
				{
					atenfield=r["tenfield"].ToString().Split(',');
				}
				if(r["captionfield"].ToString()!="")
				{
					acaptionfield=r["captionfield"].ToString().Split(',');
				}
				if(r["width"].ToString()!="")
				{
					awidth=r["width"].ToString().Split(',');
				}
				asql=r["sql"].ToString();
				
				m_tinhgio = (asql.IndexOf(":v_tn16")>=0 || asql.IndexOf(":v_dn16")>=0);

				asql=asql.Replace(":v_tn16",txtTN.Text.Substring(0,16));
				asql=asql.Replace(":v_dn16",txtDN.Text.Substring(0,16));
				asql=asql.Replace(":v_tn",txtTN.Text.Substring(0,10));
				asql=asql.Replace(":v_dn",txtDN.Text.Substring(0,10));
				asql=asql.Replace(":v_tn16",txtTN.Text.Substring(0,16));
				asql=asql.Replace(":v_makp",cbKhoa.SelectedValue.ToString().Trim());

				//MessageBox.Show(asql);

				if(tabControl1.SelectedTab==tabBN)
				{
					//AddGridTableStyle(dgQLBN,m_bc.get_data_all(txtTN.Value,txtDN.Value,asql),atenfield,acaptionfield,awidth);
					AddGridTableStyle(dgQLBN,m_bc.get_data_bc(txtTN.Value,txtDN.Value,asql),atenfield,acaptionfield,awidth);
				}
			}
			catch
			{
			}
			f_StopTimer();
		}
		private void f_Load_DG_Null()
		{
			try
			{
				AddGridTableStyle(dgNull,m_bc.get_data("select * from medibv." + m_table + "_null"),new string[]{"id","ten"},new string[]{"Mã","Tên"},new string []{"50","1000"});
				CurrencyManager cm = (CurrencyManager)BindingContext[dgNull.DataSource,dgNull.DataMember];  
				DataView dv = (DataView) cm.List; 
				dv.AllowNew = true; 
				dv.AllowDelete = true; 
				dv.AllowEdit = true; 
				dv.Table.AcceptChanges();
				dgNull.Update();
			}
			catch
			{
			}
		}
		private void f_StartTimer()
		{
			try
			{
				this.Cursor=Cursors.WaitCursor;
				timer1.Enabled=true;
				timer1.Interval=50;
				progressBar1.Value=progressBar1.Minimum+1;
				progressBar1.Update();
			}
			catch
			{
			}
		}
		private void f_StopTimer()
		{
			try
			{
				this.Cursor=Cursors.Default;
				timer1.Enabled=false;
				progressBar1.Value=0;
				progressBar1.Update();
			}
			catch
			{
			}
		}
		private void AddGridTableStyle(DataGrid v_dg, DataSet v_ds, string[] v_field, string[] v_caption, string[] v_length)
		{
			try
			{
				v_dg.TableStyles.Clear();
				v_dg.AllowSorting=true;
				v_dg.CaptionForeColor=Color.Blue;
				DataGridColoredTextBoxColumn TextCol;
				delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
				DataGridTableStyle ts =new DataGridTableStyle();
				ts.MappingName = v_ds.Tables[0].TableName;
				ts.AlternatingBackColor = SystemColors.Info;//Color.Linen;
				ts.BackColor = Color.White;//.GhostWhite;
				ts.ForeColor = Color.Black;//.Navy;
				ts.GridLineColor = SystemColors.Control;
				ts.HeaderBackColor = SystemColors.Control;
				ts.HeaderForeColor = SystemColors.ControlText;
				ts.SelectionBackColor = Color.Teal;
				ts.SelectionForeColor = Color.White;
				ts.RowHeaderWidth=16;
				ts.AllowSorting=true;
				int aidx=0,nit=0;
				foreach(string atmp in v_field)
				{
					try
					{
						for(int i=0;i<v_ds.Tables[0].Columns.Count;i++)
						{
							if(v_ds.Tables[0].Columns[i].ColumnName.Trim().ToLower()==atmp.Trim().ToLower())
							{
								TextCol=new DataGridColoredTextBoxColumn(de, 0);
								TextCol.MappingName = atmp.Trim();
								try
								{
									TextCol.HeaderText = v_caption[aidx].Trim();
								}
								catch
								{
									TextCol.HeaderText = atmp.Trim();
								}
								try
								{
									TextCol.Width = int.Parse(v_length[aidx].ToString().Trim());
								}
								catch
								{
									TextCol.Width = 100;
								}

								TextCol.NullText="";
								if(v_ds.Tables[0].Columns[i].DataType.ToString()=="System.Decimal")
								{
									TextCol.Format="###,###,###.##";
									TextCol.Alignment=HorizontalAlignment.Right;
								}
								//TextCol.ReadOnly=true;
								TextCol.NullText = "";
								ts.GridColumnStyles.Add(TextCol);
								v_dg.TableStyles.Add(ts);
								break;
							}
						}
						nit++;
					}
					catch
					{
					}
					aidx++;
				}
				v_dg.DataSource=v_ds.Tables[0];

				CurrencyManager cm = (CurrencyManager)BindingContext[v_dg.DataSource,v_dg.DataMember];  
				DataView dv = (DataView) cm.List; 
				dv.AllowNew = false; 
				dv.AllowDelete = false; 
				dv.AllowEdit = false; 
				if(nit!=0)
				{
					int n=0,nr=0;
					for(int i=0;i<v_dg.TableStyles[0].GridColumnStyles.Count;i++)
					{
						n=n+v_dg.TableStyles[0].GridColumnStyles[i].Width;
					}
					nr=v_dg.Height/23;
					if(n<v_dg.Width-20)
					{
						if(dv.Table.Rows.Count>nr)
						{
							v_dg.TableStyles[0].GridColumnStyles[v_dg.TableStyles[0].GridColumnStyles.Count-1].Width=v_dg.Width-n+v_dg.TableStyles[0].GridColumnStyles[v_dg.TableStyles[0].GridColumnStyles.Count-1].Width-40;
						}
						else
						{
							v_dg.TableStyles[0].GridColumnStyles[v_dg.TableStyles[0].GridColumnStyles.Count-1].Width=v_dg.Width-n+v_dg.TableStyles[0].GridColumnStyles[v_dg.TableStyles[0].GridColumnStyles.Count-1].Width-24;
						}
					}
				}
				
				try
				{
					if(tabControl1.SelectedTab==tabBN)
					{
						v_dg.CaptionText=treeQLBN.SelectedNode.FullPath.Trim().Replace("\\"," -> ")+" (Tổng số: "+v_ds.Tables[0].Rows.Count.ToString()+")";
					}
				}
				catch
				{
					v_dg.CaptionText="Kết quả: ";
				}
			}
			catch
			{
				v_dg.DataSource=null;
			}
		}
		private void f_resizeDG()
		{
			/*
			try
			{
				CurrencyManager cm = (CurrencyManager)BindingContext[dgHCBN.DataSource,dgHCBN.DataMember];  
				DataView dv = (DataView) cm.List; 
				dv.AllowNew = false; 
				dv.AllowDelete = false; 
				dv.AllowEdit = false; 
				int n=200;
				if(dv.Table.Rows.Count>19)
				{
					dgHCBN.TableStyles[0].GridColumnStyles[1].Width = dgHCBN.Width - n - 16;
				}
				else
				{
					dgHCBN.TableStyles[0].GridColumnStyles[1].Width = dgHCBN.Width - n;
				}
				dgHCBN.Update();
			}
			catch
			{
			}
			*/
		}
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			try
			{
				progressBar1.Value=(progressBar1.Value<progressBar1.Maximum)?progressBar1.Value+1:progressBar1.Minimum;
				progressBar1.Update();
			}
			catch
			{
			}
		}

		private void butSQL_Refresh_Click(object sender, System.EventArgs e)
		{
			f_StartTimer();
			try
			{
				string asql=(txtSQL.SelectedText.Trim()=="")?txtSQL.Text.Trim():txtSQL.SelectedText.Trim();
				string atmp=asql.ToLower();
				if(atmp.IndexOf("delete")>=0 || atmp.IndexOf("update")>=0 || atmp.IndexOf("insert")>=0 || atmp.IndexOf("drop")>=0 || atmp.IndexOf("alter")>=0 || atmp.IndexOf("rename")>=0)
				{
					MessageBox.Show(this,"Không cho phép thực thi câu truy vấn này!","MEDISOFT THIS",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					f_StopTimer();
					return;
				}
				if(menuItem17.Checked)
				{
					//dgSQL.DataSource=m_bc.get_data(asql).Tables[0];
					dgSQL.DataSource=m_bc.get_data(asql).Tables[0];
				}
				else
				{
					//dgSQL.DataSource=m_bc.get_data_all(txtTN.Value,txtDN.Value,asql).Tables[0];
					dgSQL.DataSource=m_bc.get_data_bc(txtTN.Value,txtDN.Value,asql).Tables[0];
				}
				CurrencyManager cm = (CurrencyManager)BindingContext[dgSQL.DataSource,dgSQL.DataMember];  
				DataView dv = (DataView) cm.List; 
				dv.AllowNew=false;
				dv.AllowEdit=false;
				dv.AllowDelete=false;
				dgSQL.CaptionText="Tổng cộng: " + dv.Table.Rows.Count.ToString();
				f_Save_Histotry(asql);
			}
			catch
			{
				f_StopTimer();
				MessageBox.Show(this,"Câu truy vấn sai!","MEDISOFT THIS",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
			f_StopTimer();
		}

		private void f_Export_Tree()
		{
			try
			{
				SaveFileDialog af = new SaveFileDialog();
				af.Filter="XML Document|*.xml";
				af.RestoreDirectory=true;
                af.FileName = m_table +".xml";
				if(af.ShowDialog()==DialogResult.OK && af.FileName!="")
				{
					string afile=af.FileName;
					if(afile.ToLower().Substring(afile.Length-4)!=".xml") afile=afile+".xml";
					m_bc.get_data("select * from medibv." + m_table).WriteXml(afile,XmlWriteMode.WriteSchema);
				}
				af.Dispose();
			}
			catch
			{
			}
		}
		private void f_Export_Null()
		{
			try
			{
				SaveFileDialog af = new SaveFileDialog();
				af.Filter="XML Document|*.xml";
				af.RestoreDirectory=true;
				if(af.ShowDialog()==DialogResult.OK && af.FileName!="")
				{
					string afile=af.FileName;
					if(afile.ToLower().Substring(afile.Length-4)!=".xml") afile=afile+".xml";
					m_bc.get_data("select * from medibv." + m_table + "_null").WriteXml(afile,XmlWriteMode.WriteSchema);
				}
				af.Dispose();
			}
			catch
			{
			}
		}
		private void f_Imp_Tree()
		{
			try
			{
				OpenFileDialog af = new OpenFileDialog();
				af.RestoreDirectory=true;
				af.Filter="XML Document|*.xml";
				if(af.ShowDialog()==DialogResult.OK && af.FileName!="")
				{
					DataSet ads = new DataSet();
					DataSet ads1 = new DataSet();
					ads.ReadXml(af.FileName);
					ads1=m_bc.get_treemenu(m_table);
					for(int i=0;i<ads1.Tables[0].Columns.Count;i++)
					{
						if(ads.Tables[0].Columns[i].ColumnName.ToUpper()!=ads1.Tables[0].Columns[i].ColumnName.ToUpper())
						{
							MessageBox.Show(this,"File dữ liệu không đúng cấu trúc, không thể thu thập!","Medisoft THIS",MessageBoxButtons.OK,MessageBoxIcon.Warning);
							return;
						}
					}
					m_bc.execute_data("delete from medibv." + m_table);
					foreach(DataRow r in ads.Tables[0].Rows)
					{
						m_bc.upd_treemenu(m_table,decimal.Parse(r["id"].ToString()),decimal.Parse(r["id_cha"].ToString()),decimal.Parse(r["stt"].ToString()),r["ten"].ToString().Trim(),r["sql"].ToString().Trim(),r["tenfield"].ToString().Trim(),r["captionfield"].ToString().Trim(),r["width"].ToString().Trim(),r["report"].ToString().Trim(),decimal.Parse(r["readonly"].ToString()));
						f_Load_Tree_QLBN();
					}
				}
				af.Dispose();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		private void f_Imp_Null()
		{
			try
			{
				OpenFileDialog af = new OpenFileDialog();
				af.RestoreDirectory=true;
				af.Filter="XML Document|*.xml";
				if(af.ShowDialog()==DialogResult.OK && af.FileName!="")
				{
					DataSet ads = new DataSet();
					DataSet ads1 = new DataSet();
					ads.ReadXml(af.FileName);
					ads1=m_bc.get_data("select id,ten from medibv." + m_table + "_null");
					for(int i=0;i<ads1.Tables[0].Columns.Count;i++)
					{
						if(ads.Tables[0].Columns[i].ColumnName.ToUpper()!=ads1.Tables[0].Columns[i].ColumnName.ToUpper())
						{
							MessageBox.Show(this,"File dữ liệu không đúng cấu trúc, không thể thu thập!","Medisoft THIS",MessageBoxButtons.OK,MessageBoxIcon.Warning);
							return;
						}
					}
					m_bc.execute_data("delete from medibv." + m_table + "_null");
					foreach(DataRow r in ads.Tables[0].Rows)
					{
						m_bc.upd_null(m_table,r["id"].ToString(),r["ten"].ToString().Trim());
					}
				}
				af.Dispose();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		private void f_Export_Excel()
		{
			try
			{
				if(tabControl1.SelectedTab.Name==tabBN.Name)
				{
					SaveFileDialog af = new SaveFileDialog();
					af.Filter="MS Excell|*.xls";
					af.RestoreDirectory=true;
					af.ShowDialog();
					if(af.FileName!="")
					{
						f_Export_Excel_DG(dgQLBN,af.FileName,f_Filter());
					}
					af.Dispose();
					return;
				}
			}
			catch
			{
			}
		}
		private void f_Export_XML()
		{
			try
			{
				DataSet ads = new DataSet();
				if(tabControl1.SelectedTab.Name==tabBN.Name)
				{
					CurrencyManager cm = (CurrencyManager)BindingContext[dgQLBN.DataSource,dgQLBN.DataMember];  
					DataView dv = (DataView) cm.List; 
					SaveFileDialog af = new SaveFileDialog();
					af.Filter="XML Document|*.xml";
					af.RestoreDirectory=true;
					f_StopTimer();
					af.ShowDialog();
					if(af.FileName!="")
					{
						string afile=af.FileName;
						if(afile.ToLower().Substring(afile.Length-4)!=".xml") afile=afile+".xml";
						ads.Tables.Add(dv.Table.Copy());
						ads.WriteXml(afile,XmlWriteMode.WriteSchema);
					}
					af.Dispose();
					return;
				}
			}
			catch
			{
			}
		}
		private void butExcel_Click(object sender, System.EventArgs e)
		{
			f_StartTimer();
			f_Export_Excel();
			f_StopTimer();
		}

		private void f_In()
		{
			try
			{
				DataSet ads = new DataSet();
				if(tabControl1.SelectedTab.Name==tabBN.Name)
				{
					CurrencyManager cm = (CurrencyManager)BindingContext[dgQLBN.DataSource,dgQLBN.DataMember];  
					DataView dv = (DataView) cm.List; 
					ads.Tables.Add(dv.Table.Copy());
				}

				CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
				crystalReportViewer1.ActiveViewIndex = -1;
				crystalReportViewer1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(239)), ((System.Byte)(239)), ((System.Byte)(239)));
				crystalReportViewer1.DisplayGroupTree = false;
				crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
				crystalReportViewer1.Name = "crystalReportViewer1";
				crystalReportViewer1.ReportSource = null;
				crystalReportViewer1.Size = new System.Drawing.Size(792, 573);
				crystalReportViewer1.TabIndex = 85;

				System.Windows.Forms.Form af = new System.Windows.Forms.Form();
				af.WindowState=FormWindowState.Maximized;
				af.Controls.Add(crystalReportViewer1);
				af.Text="Bảng giá viện phí";
				crystalReportViewer1.BringToFront();
				crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;

				string areport="",asyt="",abv="",angayin="",anguoiin="",aghichu="";
				areport=butIn.Tag.ToString();
				aghichu=f_Get_GhiChu();
				angayin = "Ngày "+txtNgayin.Value.Day.ToString().PadLeft(2,'0')+" tháng "+txtNgayin.Value.Month.ToString().PadLeft(2,'0')+" năm "+txtNgayin.Value.Year.ToString();
				anguoiin=txtNguoiin.Text;
                asyt = m_bc.Syte;
                abv = m_bc.Tenbv;
				if(areport.ToLower().IndexOf(".rpt")<0)
				{
					areport=areport+".rpt";
				}
				if(!System.IO.File.Exists("..\\..\\..\\report\\"+areport))
				{
					MessageBox.Show(this,"Không tìm thấy report: "+areport,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}

				ReportDocument cMain=new ReportDocument();
				cMain.Load("..\\..\\..\\report\\"+areport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(ads);
				cMain.DataDefinition.FormulaFields["v_syt"].Text="'"+asyt.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_bv"].Text="'"+abv.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_ngayin"].Text="'"+angayin+"'";
				cMain.DataDefinition.FormulaFields["v_nguoiin"].Text="'"+anguoiin+"'";
				cMain.DataDefinition.FormulaFields["v_ghichu"].Text="'"+aghichu+"'";
				crystalReportViewer1.ReportSource=cMain;
				af.Text=areport;
				f_StopTimer();
				af.ShowDialog();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void butSQL_New_Click(object sender, System.EventArgs e)
		{
			txtSQL.Text="";
			txtSQL.Focus();
		}

		private void butSQL_ClearHistory_Click(object sender, System.EventArgs e)
		{
			try
			{
				m_bc.execute_data("delete from medibv." + m_table + "_history");
				f_Load_Histotry();
			}
			catch
			{
			}
		}

		private void butSQL_Pre_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(cbHis.SelectedIndex>0)
				{
					cbHis.SelectedIndex=cbHis.SelectedIndex-1;
				}
				else
				{
					cbHis.SelectedIndex=0;
				}
				txtSQL.Text=cbHis.SelectedValue.ToString();
			}
			catch
			{
			}
		}

		private void butSQL_Next_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(cbHis.SelectedIndex<cbHis.Items.Count)
				{
					cbHis.SelectedIndex=cbHis.SelectedIndex+1;
				}
				else
				{
					cbHis.SelectedIndex=cbHis.Items.Count-1;
				}
				txtSQL.Text=cbHis.SelectedValue.ToString();
			}
			catch
			{
			}
		}
		private void f_SaveHistory()
		{
			try
			{
				DataSet ads = new DataSet();
				ads.Tables.Add("QLBV");
				ads.Tables[0].Columns.Add("nguoiin");
				ads.Tables[0].Rows.Add(new string[] {txtNguoiin.Text.Trim()});
				ads.WriteXml("...//...//option//v_optionquanlybenhvien.xml",XmlWriteMode.WriteSchema);
			}
			catch
			{
			}
		}
		private void f_LoadHistory()
		{
			try
			{
				if(!System.IO.Directory.Exists("..//..//option"))
				{
					System.IO.Directory.CreateDirectory("..//..//option");
				}
			}
			catch
			{
				//MessageBox.Show(ex.ToString());
			}
			try
			{
				DataSet ads = new DataSet();
				ads.ReadXml("...//...//option//v_optionquanlybenhvien.xml");
				txtNguoiin.Text=ads.Tables[0].Rows[0]["nguoiin"].ToString();
			}
			catch
			{
			}
		}
		private void treeQLBN_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{

			try
			{
				treeQLBN.SelectedNode.ForeColor=Color.Red;
				f_Load_DG(e.Node.Tag.ToString());
			}
			catch
			{
			}
		}

		private void treeQLBN_BeforeSelect(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			try
			{
				treeQLBN.SelectedNode.ForeColor=Color.Black;
			}
			catch
			{
			}
		}
		private void f_Add_Luu()
		{
			try
			{
				string aid="",aid_cha="",arol="";
				aid=txtAdd_Ten.Tag.ToString();
				aid_cha=txtAdd_SQL.Tag.ToString();
				arol=chkReadonly.Checked?"1":"0";
				if(txtAdd_Ten.Text.Trim()=="")
				{
					MessageBox.Show(this,"Nhập vào tên","Medisoft THIS",MessageBoxButtons.OK,MessageBoxIcon.Information);
					txtAdd_Ten.Focus();
					return;
				}
				if((txtAdd_SQL.Text.Trim()=="") && (MessageBox.Show(this,"Có muốn nhập vào câu truy vấn không?","Medisoft THIS",MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button2)==DialogResult.Yes))
				{
					txtAdd_SQL.Focus();
					return;
				}
				if(aid=="")
				{
					aid=m_bc.get_id_treemenu(m_table);
				}
				if(aid_cha=="")
				{
					aid_cha="0";
				}
				if(aid!="")
				{
					if(pAdd_Menu.Tag.ToString()=="1")
					{
						m_bc.upd_treemenu(m_table,decimal.Parse(aid),decimal.Parse(aid_cha),decimal.Parse(txtAdd_Stt.Text.Trim()),txtAdd_Ten.Text.Trim(),txtAdd_SQL.Text.Trim(),txtAdd_Field.Text.Trim(),txtAdd_Tenfield.Text.Trim(),txtAdd_Width.Text.Trim(),txtAdd_Report.Text.Trim(),decimal.Parse(arol));
						f_Load_Tree_QLBN();
					}
					f_Add_New();
				}
			}
			catch
			{
			}
		}
		private void f_Add_Del()
		{
			try
			{
				if(!m_bc.del_treemenu(m_table,txtAdd_Ten.Tag.ToString()))
				{
					MessageBox.Show(this,"Không cho xoá","Medisoft THIS",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				}
				else
				{
					if(MessageBox.Show(this,"Đồng ý xoá?","Medisoft THIS",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1)==DialogResult.Yes)
					{
						txtAdd_Ten.Tag="";
						txtAdd_Ten.Text="";
						txtAdd_Stt.Text=m_bc.get_stt_treemenu(m_table,txtAdd_SQL.Tag.ToString());
						txtAdd_SQL.Text="";
						txtAdd_Field.Text="";
						txtAdd_Width.Text="";
						txtAdd_Tenfield.Text="";
						txtAdd_Report.Text="";
						txtAdd_Ten.Focus();
						if(pAdd_Menu.Tag.ToString()=="1")
						{
							f_Load_Tree_QLBN();
						}
					}
				}
			}
			catch
			{
			}
		}
		private void f_Add_New()
		{
			try
			{
				txtAdd_Ten.Tag="";
				txtAdd_Ten.Text="";
				txtAdd_Stt.Text=m_bc.get_stt_treemenu(m_table,txtAdd_SQL.Tag.ToString());
				txtAdd_SQL.Text="";
				txtAdd_Field.Text="";
				txtAdd_Width.Text="";
				txtAdd_Tenfield.Text="";
				txtAdd_Report.Text="";
				try
				{
					if(pAdd_Menu.Tag.ToString()=="1")
					{
						try
						{
							lbAdd_Title.Text="MỤC CHA: "+m_bc.get_data("select * from medibv." + m_table + " where id="+txtAdd_SQL.Tag.ToString().Trim()).Tables[0].Rows[0]["ten"].ToString().ToUpper();
						}
						catch
						{
							lbAdd_Title.Text="MỤC GỐC";
						}
					}
					else
						if(pAdd_Menu.Tag.ToString()=="2")
					{
						try
						{
							lbAdd_Title.Text="MỤC CHA: "+m_bc.get_data("select * from medibv." + m_table + " where id="+txtAdd_SQL.Tag.ToString().Trim()).Tables[0].Rows[0]["ten"].ToString().ToUpper();
						}
						catch
						{
							lbAdd_Title.Text="MỤC GỐC";
						}
					}
				}
				catch
				{
				}
				chkReadonly.Checked=false;
				txtAdd_Ten.Focus();
			}
			catch
			{
			}
		}

		private void butAdd_Luu_Click(object sender, System.EventArgs e)
		{
			f_Add_Luu();
		}

		private void txtAdd_Ten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void chkReadonly_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void butAdd_Xoa_Click(object sender, System.EventArgs e)
		{
			f_Add_Del();
		}

		private void butAdd_Moi_Click(object sender, System.EventArgs e)
		{
			f_Add_New();
		}

		private void butAdd_Boqua_Click(object sender, System.EventArgs e)
		{
			try
			{
				pAdd_Menu.Visible=false;
				pAdd_Menu.Tag="";
				txtAdd_Ten.Tag="";
				txtAdd_SQL.Tag="";
			}
			catch
			{
			}
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			try
			{
				pAdd_Menu.Visible=true;
				pAdd_Menu.BringToFront();
				pAdd_Menu.Left=(this.Width-pAdd_Menu.Width)/2;
				pAdd_Menu.Top=(this.Height-pAdd_Menu.Height)/2;
				txtAdd_Ten.Tag="";
				txtAdd_Ten.Text="";
				txtAdd_SQL.Text="";
				txtAdd_Field.Text="";
				txtAdd_Tenfield.Text="";
				txtAdd_Width.Text="";
				txtAdd_Report.Text="";

				if(tabControl1.SelectedTab==tabBN)
				{
					pAdd_Menu.Tag="1";
					try
					{
						txtAdd_SQL.Tag=treeQLBN.SelectedNode.Parent.Tag.ToString();
					}
					catch
					{
						txtAdd_SQL.Tag="";
					}
					txtAdd_Ten.Focus();
				}
			}
			catch
			{
			}
			f_Add_New();
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(tabControl1.SelectedTab==tabBN)
				{
					
					if(MessageBox.Show(this,"Đồng ý xoá?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
					{
						if(m_bc.del_treemenu(m_table,treeQLBN.SelectedNode.Tag.ToString()))
						{
							f_Load_Tree_QLBN();
						}
						else
						{
							MessageBox.Show(this,"Không cho xoá","Medisoft THIS",MessageBoxButtons.OK,MessageBoxIcon.Warning);
						}
					}
				}
			}
			catch
			{
			}
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			try
			{
				pAdd_Menu.Left=(this.Width-pAdd_Menu.Width)/2;
				pAdd_Menu.Top=(this.Height-pAdd_Menu.Height)/2;
				txtAdd_Ten.Text="";
				txtAdd_SQL.Text="";
				txtAdd_Field.Text="";
				txtAdd_Tenfield.Text="";
				txtAdd_Width.Text="";
				txtAdd_Report.Text="";

				if(tabControl1.SelectedTab==tabBN)
				{
					try
					{
						txtAdd_Ten.Tag=treeQLBN.SelectedNode.Tag.ToString();
						DataRow r = m_bc.get_treemenu(m_table).Tables[0].Select("id="+txtAdd_Ten.Tag.ToString())[0];
						txtAdd_Ten.Text=r["ten"].ToString();
						txtAdd_Stt.Text=r["stt"].ToString();
						txtAdd_SQL.Text=r["sql"].ToString();
						txtAdd_Field.Text=r["tenfield"].ToString();
						txtAdd_Tenfield.Text=r["captionfield"].ToString();
						txtAdd_Width.Text=r["width"].ToString();
						txtAdd_Report.Text=r["report"].ToString();
						chkReadonly.Checked=r["readonly"].ToString()=="1";
					}
					catch
					{
						MessageBox.Show(this,"Chọn mục cần sửa","Medisoft THIS",MessageBoxButtons.OK,MessageBoxIcon.Information);
						treeQLBN.Focus();
						txtAdd_Ten.Tag="";
						return;
					}

					try
					{
						txtAdd_SQL.Tag=treeQLBN.SelectedNode.Parent.Tag.ToString();
					}
					catch
					{
						txtAdd_SQL.Tag="";
					}
					try
					{
						lbAdd_Title.Text="MỤC CHA: "+m_bc.get_treemenu(m_table).Tables[0].Select("id="+txtAdd_SQL.Tag.ToString())[0]["ten"].ToString().ToUpper();
					}
					catch
					{
						lbAdd_Title.Text="MỤC GỐC";
					}

					pAdd_Menu.Tag="1";
					pAdd_Menu.Visible=true;
					pAdd_Menu.BringToFront();
					txtAdd_Ten.Focus();
				}
			}
			catch
			{
			}
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			try
			{
				pAdd_Menu.Visible=true;
				pAdd_Menu.BringToFront();
				pAdd_Menu.Left=(this.Width-pAdd_Menu.Width)/2;
				pAdd_Menu.Top=(this.Height-pAdd_Menu.Height)/2;
				txtAdd_Ten.Tag="";
				txtAdd_Ten.Text="";
				txtAdd_SQL.Text="";
				txtAdd_Field.Text="";
				txtAdd_Tenfield.Text="";
				txtAdd_Width.Text="";
				txtAdd_Report.Text="";

				if(tabControl1.SelectedTab==tabBN)
				{
					pAdd_Menu.Tag="1";
					try
					{
						txtAdd_SQL.Tag=treeQLBN.SelectedNode.Tag.ToString();
					}
					catch
					{
						txtAdd_SQL.Tag="";
					}
					txtAdd_Ten.Focus();
				}
			}
			catch
			{
			}
			f_Add_New();
		}
		private void txtAdd_Field_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void txtAdd_Tenfield_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void txtAdd_Width_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void menuItem9_Click(object sender, System.EventArgs e)
		{
			f_Imp_Tree();
		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			f_Export_Tree();
		}

		private void butRefresh_Click(object sender, System.EventArgs e)
		{
			try
			{
				f_Load_DG(butRefresh.Tag.ToString());
			}
			catch
			{
			}
		}

		private void label6_Click(object sender, System.EventArgs e)
		{
			try
			{
				string asql=(txtAdd_SQL.SelectedText.Trim()!="")?txtAdd_SQL.SelectedText.Trim():txtAdd_SQL.Text.Trim();
				
				asql=asql.Replace(":v_tn16",txtTN.Text.Substring(0,16));
				asql=asql.Replace(":v_dn16",txtDN.Text.Substring(0,16));
				asql=asql.Replace(":v_tn",txtTN.Text.Substring(0,10));
				asql=asql.Replace(":v_dn",txtDN.Text.Substring(0,10));
				asql=asql.Replace(":v_tn16",txtTN.Text.Substring(0,16));
				asql=asql.Replace(":v_makp",cbKhoa.SelectedValue.ToString().Trim());

				//string n = m_bc.get_data_all(txtTN.Value,txtDN.Value,asql).Tables[0].Rows.Count.ToString();
				string n = m_bc.get_data_bc(txtTN.Value,txtDN.Value,asql).Tables[0].Rows.Count.ToString();
				MessageBox.Show(this,"Kết quả kiểm tra: "+n+" record.\n\nCâu truy vấn này quá hay.","Medisoft THIS",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			catch
			{
				MessageBox.Show(this,"Kết quả kiểm tra: Error\n\nCâu truy vấn bị lỗi","Medisoft THIS",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void frmQuanlybenhvien_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				f_Save_Cookie(txtSQL.Name,txtSQL.Height.ToString());
				f_Save_Cookie(treeQLBN.Name,treeQLBN.Width.ToString());
			}
			catch
			{
			}
		}

		private void txtAdd_Report_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			f_StartTimer();
			f_SaveHistory();
			f_In();
			f_StopTimer();
		}
		private void f_Write_Null()
		{
			try
			{
				DataSet ads = new DataSet();
				try
				{
					ads.ReadXml("..\\..\\..\\xml\\"+m_table+"_null.xml");
				}
				catch
				{
					ads.Tables.Add("Table");
					ads.Tables[0].Columns.Add("id");
					ads.Tables[0].Columns.Add("ten");
					ads.WriteXml("..\\..\\..\\xml\\"+m_table+"_null.xml",XmlWriteMode.WriteSchema);
				}
			}
			catch
			{
			}
		}

		private void txtAdd_SttValidated(object sender, System.EventArgs e)
		{
			try
			{
				txtAdd_Stt.Text=long.Parse(txtAdd_Stt.Text.Trim()).ToString();
			}
			catch
			{
				txtAdd_Stt.Text="0";
			}
		}

		private void txtAdd_SttKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}
		private void f_Reorder(int v_order)
		{
			try
			{
				if(tabControl1.SelectedTab==tabBN)
				{
					m_bc.reorder_treemenu(m_table,treeQLBN.SelectedNode.Tag.ToString(),v_order);
					f_Load_Tree_QLBN();
				}
			}
			catch
			{
			}
		}
		private void menuItem12_Click(object sender, System.EventArgs e)
		{
			f_Reorder(-1);
		}

		private void menuItem13_Click(object sender, System.EventArgs e)
		{
			f_Reorder(1);
		}

		private void butNull_Luu_Click(object sender, System.EventArgs e)
		{
			try
			{
				CurrencyManager cm = (CurrencyManager)BindingContext[dgNull.DataSource,dgNull.DataMember];  
				DataView dv = (DataView) cm.List; 
				dv.AllowNew = true; 
				dv.AllowDelete = true; 
				dv.AllowEdit = true; 
				dv.Table.AcceptChanges();
				m_bc.execute_data("delete from medibv." + m_table + "_null");
				foreach(DataRow r in dv.Table.Rows)
				{
					m_bc.upd_null(m_table,r["id"].ToString().Trim(),r["ten"].ToString().Trim());
				}
				MessageBox.Show(this,"Cập nhât thành công!","Medisoft THIS",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			catch
			{
				MessageBox.Show(this,"Cập nhât không thành công!","Medisoft THIS",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void butNull_Dong_Click(object sender, System.EventArgs e)
		{
			pAdd_Menu.Visible=false;
			pNull.Visible=false;
		}
		private void pAdd_Menu_VisibleChanged(object sender, System.EventArgs e)
		{
			try
			{
				pAdd_Menu.Left=(this.Width-pAdd_Menu.Width)/2;
				pAdd_Menu.Top=(this.Height-pAdd_Menu.Height)/2;
			}
			catch
			{
			}
		}

		private void txtDN_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			butRefresh_Click(null,null);
		}

		private void butXML_Click(object sender, System.EventArgs e)
		{
			f_StartTimer();
			f_Export_XML();
			f_StopTimer();
		}

		private void txtTimkiem_Enter(object sender, System.EventArgs e)
		{
			try
			{
				if(txtTimkiem.Text.Trim().ToLower()=="tìm kiếm")
				{
					txtTimkiem.Text="";
				}
			}
			catch
			{
			}
		}
		private void f_Save_Cookie(string v_name, string v_val)
		{
			try
			{
				DataSet ads = new DataSet();
				try
				{
					ads.ReadXml("..\\..\\..\\xml\\" + m_table + "_layout.xml");
				}
				catch
				{
					ads.Tables.Add("Table");
					ads.Tables[0].Columns.Add("id");
					ads.Tables[0].Columns.Add("val");
				}
				if(ads.Tables[0].Select("id='"+v_name+"'").Length<=0)
				{
					ads.Tables[0].Rows.Add(new string[]{v_name,v_val});
				}
				else
				{
					ads.Tables[0].Select("id='"+v_name+"'")[0]["val"]=v_val;
				}
                ads.WriteXml("..\\..\\..\\xml\\" + m_table + "_layout.xml", XmlWriteMode.WriteSchema);
			}
			catch
			{
			}
		}
		private void f_Load_Cookie()
		{
			try
			{
				DataSet ads = new DataSet();
				try
				{
                    ads.ReadXml("..\\..\\..\\xml\\" + m_table + "_layout.xml");
				}
				catch
				{
					ads.Tables.Add("Table");
					ads.Tables[0].Columns.Add("id");
					ads.Tables[0].Columns.Add("val");
				}
                ads.WriteXml("..\\..\\..\\xml\\" + m_table + "_layout.xml", XmlWriteMode.WriteSchema);
				int aw=0;
				try
				{
					aw=int.Parse(ads.Tables[0].Select("id='"+treeQLBN.Name+"'")[0]["val"].ToString());
				}
				catch
				{
					aw=0;
				}
				if(aw>0)
				{
					treeQLBN.Width=aw;
				}

				try
				{
					aw=int.Parse(ads.Tables[0].Select("id='"+txtSQL.Name+"'")[0]["val"].ToString());
				}
				catch
				{
					aw=0;
				}
				if(aw>0)
				{
					txtSQL.Height=aw;
				}
			}
			catch
			{
			}
		}
		private void txtTimkiem_Leave(object sender, System.EventArgs e)
		{
			try
			{
				if(txtTimkiem.Text.Trim()=="")
				{
					txtTimkiem.Text="Tìm kiếm";
				}
			}
			catch
			{
			}
		}
		private string f_Filter()
		{
			string aft="";
			try
			{
				string atmp="",aso="";
				string atxt=txtTimkiem.Text.Trim().ToLower()=="tìm kiếm"?"":txtTimkiem.Text.Trim();
				if(tabControl1.SelectedTab==tabBN)
				{
					CurrencyManager cm = (CurrencyManager)BindingContext[dgQLBN.DataSource,dgQLBN.DataMember];  
					DataView dv = (DataView) cm.List; 
					if(atxt!="") 
					{
						try
						{
							aso=decimal.Parse(atxt.Trim()).ToString();
						}
						catch
						{
							aso="";
						}

						for(int i=0;i<dv.Table.Columns.Count;i++)
						{
							if(dv.Table.Columns[i].DataType.ToString()=="System.String")
							{
								if(aft.Trim().Length>0)
								{
									aft=aft.Trim()+" or "+dv.Table.Columns[i].ColumnName+" like '%"+atxt+"%'";
								}
								else
								{
									aft=aft.Trim()+dv.Table.Columns[i].ColumnName+" like '%"+atxt+"%'";
								}
							}
							else
								if(dv.Table.Columns[i].DataType.ToString()=="System.Decimal" && aso!="")
							{
								if(aft.Trim().Length>0)
								{
									aft=aft.Trim()+" or "+dv.Table.Columns[i].ColumnName+" ="+aso;
								}
								else
								{
									aft=aft.Trim()+dv.Table.Columns[i].ColumnName+" ="+aso;
								}
							}
						}
					}
					else
					{
						aft="";
					}
					dv.RowFilter=aft;
					atmp=dgQLBN.CaptionText;
					atmp=atmp.Substring(0,atmp.LastIndexOf("(")-1).Trim();
					dgQLBN.CaptionText=atmp+" (Tổng số: "+dv.Table.Select(aft).Length.ToString()+")";
				}
				else
					if(tabControl1.SelectedTab==tabSQL)
				{
					CurrencyManager cm = (CurrencyManager)BindingContext[dgSQL.DataSource,dgSQL.DataMember];  
					DataView dv = (DataView) cm.List; 
					if(atxt!="") 
					{
						try
						{
							aso=decimal.Parse(atxt.Trim()).ToString();
						}
						catch
						{
							aso="";
						}

						for(int i=0;i<dv.Table.Columns.Count;i++)
						{
							if(dv.Table.Columns[i].DataType.ToString()=="System.String")
							{
								if(aft.Trim().Length>0)
								{
									aft=aft.Trim()+" or "+dv.Table.Columns[i].ColumnName+" like '%"+txtTimkiem.Text.Trim()+"%'";
								}
								else
								{
									aft=aft.Trim()+dv.Table.Columns[i].ColumnName+" like '%"+txtTimkiem.Text.Trim()+"%'";
								}
							}
							else
								if(dv.Table.Columns[i].DataType.ToString()=="System.Decimal" && aso!="")
							{
								if(aft.Trim().Length>0)
								{
									aft=aft.Trim()+" or "+dv.Table.Columns[i].ColumnName+" ="+aso;
								}
								else
								{
									aft=aft.Trim()+dv.Table.Columns[i].ColumnName+" ="+aso;
								}
							}
						}
					}
					else
					{
						aft="";
					}
					dv.RowFilter=aft;
					atmp=atmp.Substring(0,atmp.LastIndexOf("(")-1).Trim();
					dgSQL.CaptionText=atmp+" (Tổng số: "+dv.Table.Select(aft).Length.ToString()+")";
				}
			}
			catch
			{
			}
			return aft;
		}
		private void txtTimkiem_TextChanged(object sender, System.EventArgs e)
		{
			f_Filter();
		}
		private void txtTimkiem_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void cbBaocao_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				switch(cbBaocao.SelectedValue.ToString())
				{
					case "0"://TN-DN
						lbThang.Enabled=false;
						txtThang.Enabled=false;
						lbNam.Enabled=false;
						txtNam.Enabled=false;
						
						lbTN.Enabled=true;
						lbDN.Enabled=true;
						txtTN.Enabled=true;
						txtDN.Enabled=true;

						lbTN.BringToFront();
						lbDN.BringToFront();
						txtTN.BringToFront();
						txtDN.BringToFront();

						break;
					case "1"://Thang
						lbThang.Enabled=true;
						txtThang.Enabled=true;
						lbNam.Enabled=true;
						txtNam.Enabled=true;
						lbThang.Text="Tháng:";
						
						txtThang.Value=1;
						txtThang.Minimum=1;
						txtThang.Maximum=12;
						
						lbTN.Enabled=false;
						lbDN.Enabled=false;
						txtTN.Enabled=false;
						txtDN.Enabled=false;

						lbThang.BringToFront();
						lbThang.BringToFront();
						txtNam.BringToFront();
						txtNam.BringToFront();
						break;
					case "2"://Quy
						lbThang.Enabled=true;
						txtThang.Enabled=true;
						lbNam.Enabled=true;
						txtNam.Enabled=true;
						lbThang.Text="Quý:";
						
						txtThang.Value=1;
						txtThang.Minimum=1;
						txtThang.Maximum=4;
						
						lbTN.Enabled=false;
						lbDN.Enabled=false;
						txtTN.Enabled=false;
						txtDN.Enabled=false;

						lbThang.BringToFront();
						lbThang.BringToFront();
						txtNam.BringToFront();
						txtNam.BringToFront();
						break;
				}

				//				lbThang.Size=lbTN.Size;
				//				lbThang.Location=lbTN.Location;
				//				lbNam.Size=lbDN.Size;
				//				lbNam.Location=lbDN.Location;
				//
				//				txtThang.Size=txtTN.Size;
				//				txtThang.Location=txtTN.Location;
				//				txtNam.Size=txtDN.Size;
				//				txtNam.Location=txtDN.Location;
			}
			catch
			{
			}
		}

		private void txtThang_ValueChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(cbBaocao.SelectedValue.ToString()=="1")//Thang
				{
					txtTN.Value= new DateTime(int.Parse(txtNam.Value.ToString()),int.Parse(txtThang.Value.ToString()),1);
					txtDN.Value= new DateTime(int.Parse(txtNam.Value.ToString()),int.Parse(txtThang.Value.ToString()),DateTime.DaysInMonth(int.Parse(txtNam.Value.ToString()),int.Parse(txtThang.Value.ToString())));
				}
				else
					if(cbBaocao.SelectedValue.ToString()=="2")//Quy
				{
					switch(txtThang.Value.ToString())
					{
						case "1":
							txtTN.Value= new DateTime(int.Parse(txtNam.Value.ToString()),1,1);
							txtDN.Value= new DateTime(int.Parse(txtNam.Value.ToString()),3,DateTime.DaysInMonth(int.Parse(txtNam.Value.ToString()),3));
							break;
						case "2":
							txtTN.Value= new DateTime(int.Parse(txtNam.Value.ToString()),4,1);
							txtDN.Value= new DateTime(int.Parse(txtNam.Value.ToString()),6,DateTime.DaysInMonth(int.Parse(txtNam.Value.ToString()),6));
							break;
						case "3":
							txtTN.Value= new DateTime(int.Parse(txtNam.Value.ToString()),7,1);
							txtDN.Value= new DateTime(int.Parse(txtNam.Value.ToString()),9,DateTime.DaysInMonth(int.Parse(txtNam.Value.ToString()),9));
							break;
						case "4":
							txtTN.Value= new DateTime(int.Parse(txtNam.Value.ToString()),10,1);
							txtDN.Value= new DateTime(int.Parse(txtNam.Value.ToString()),12,DateTime.DaysInMonth(int.Parse(txtNam.Value.ToString()),12));
							break;
					}
				}
			}
			catch
			{
			}
		}

		private void cbBaocao_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void txtThang_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void txtNam_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}
		private void menuItem16_Click(object sender, System.EventArgs e)
		{
			try
			{
				pAdd_Menu.Left=(this.Width-pAdd_Menu.Width)/2;
				pAdd_Menu.Top=(this.Height-pAdd_Menu.Height)/2;
				txtAdd_Ten.Text="";
				txtAdd_SQL.Text="";
				txtAdd_Field.Text="";
				txtAdd_Tenfield.Text="";
				txtAdd_Width.Text="";
				txtAdd_Report.Text="";

				if(tabControl1.SelectedTab==tabBN)
				{
					try
					{
						txtAdd_Ten.Tag=treeQLBN.SelectedNode.Tag.ToString();
						
						string aid = m_bc.get_id_treemenu(m_table);
						string astt = m_bc.get_stt_treemenu(m_table,txtAdd_SQL.Tag.ToString());

                        m_bc.execute_data("insert into medibv." + m_table + " select " + aid + " as id,id_cha," + astt + " as stt,ten,sql,tenfield,captionfield,width,report,readonly from medibv." + m_table + " where id = " + txtAdd_Ten.Tag.ToString());
						txtAdd_Ten.Tag=aid;
						DataRow r = m_bc.get_treemenu(m_table).Tables[0].Select("id="+txtAdd_Ten.Tag.ToString())[0];
						txtAdd_Ten.Text=r["ten"].ToString();
						txtAdd_Stt.Text=r["stt"].ToString();
						txtAdd_SQL.Text=r["sql"].ToString();
						txtAdd_Field.Text=r["tenfield"].ToString();
						txtAdd_Tenfield.Text=r["captionfield"].ToString();
						txtAdd_Width.Text=r["width"].ToString();
						txtAdd_Report.Text=r["report"].ToString();
						chkReadonly.Checked=r["readonly"].ToString()=="1";
					}
					catch(Exception ex)
					{
						MessageBox.Show(this,"Chọn mục cần sửa\n\n"+ex.ToString(),"Medisoft THIS",MessageBoxButtons.OK,MessageBoxIcon.Information);
						treeQLBN.Focus();
						txtAdd_Ten.Tag="";
						return;
					}

					try
					{
						txtAdd_SQL.Tag=treeQLBN.SelectedNode.Parent.Tag.ToString();
					}
					catch
					{
						txtAdd_SQL.Tag="";
					}
					try
					{
						lbAdd_Title.Text="MỤC CHA: "+m_bc.get_treemenu(m_table).Tables[0].Select("id="+txtAdd_SQL.Tag.ToString())[0]["ten"].ToString().ToUpper();
					}
					catch
					{
						lbAdd_Title.Text="MỤC GỐC";
					}

					pAdd_Menu.Tag="1";
					pAdd_Menu.Visible=true;
					pAdd_Menu.BringToFront();
					txtAdd_Ten.Focus();
				}
			}
			catch
			{
			}
		}
	
		#region Datagrid Colored Collum
		public Color MyGetColorRowCol(int row, int col)
		{
			Color c = Color.Black;
			switch (col.ToString())
			{
				case "0":
					c=Color.Black;
					break;
			}
			return c;
		}

		private void txtNgayin_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					txtNguoiin.Focus();
				}
			}
			catch
			{
			}
		}

		private void txtNguoiin_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					if(butIn.Enabled)
					{
						butIn.Focus();
						return;
					}
					if(butExcel.Enabled)
					{
						butExcel.Focus();
						return;
					}
				}
			}
			catch
			{
			}
		}

		private void menuItem17_Click(object sender, System.EventArgs e)
		{
			menuItem17.Checked=!menuItem17.Checked;
		}

		private void lbZoom_Click(object sender, System.EventArgs e)
		{
			try
			{
				lbZoom.Tag=lbZoom.Tag.ToString()=="1"?"2":"1";
				if(lbZoom.Tag.ToString()=="1")
				{
					pAdd_Menu.Width=514;
					pAdd_Menu.Height=308;
					pAdd_Menu.Left=266;
					pAdd_Menu.Top=198;
				}
				else
				{
					pAdd_Menu.Width=this.Width-10;
					pAdd_Menu.Height=this.Height-30;
					pAdd_Menu.Left=2;
					pAdd_Menu.Top=2;
				}
			}
			catch
			{
			}
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
					//foreBrush = new SolidBrush(_getColorRowCol(rowNum, this._column));
					//backBrush = new SolidBrush(Color.GhostWhite);
				}
				catch{}
				finally
				{
					base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
				}
			}
		}

		#endregion

		private void menuItem15_Click(object sender, EventArgs e)
		{
			lbAdd_Title.Text = "SỮA DANH SÁCH NULL";
			pAdd_Menu.Visible = true;
			pNull.Visible = true;
			pNull.Dock = DockStyle.Fill;
			pNull.BringToFront();
			f_Load_DG_Null();
			butNull_Luu.Top = pNull.Height - butNull_Luu.Height - 3;
			butNull_Dong.Top = butNull_Luu.Top;
			dgNull.Height = butNull_Dong.Top - 3 - dgNull.Top;
		}

		private void menuItem5_Click(object sender, EventArgs e)
		{
			f_Imp_Null();
		}

		private void menuItem7_Click(object sender, EventArgs e)
		{
			f_Export_Null();
		}

        private void treeQLBN_DoubleClick(object sender, EventArgs e)
        {
            try
            {
            }
            catch
            {
            }
        }
	}
}
